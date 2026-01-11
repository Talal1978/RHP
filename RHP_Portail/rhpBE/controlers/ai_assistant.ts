import { Request, Response } from "express";
import axios from "axios";
import { lireSql } from "../modules/module_sqlRW";
import { VGLOBALES } from "../modules/module_initialisation";

// Interfaces mirroring SQL Tables
interface IAiAgentConfig {
    id_Societe: number;
    Provider: string;
    aiUrl: string;
    Modele: string;
    ApiKey: string;
    Instructions: string;
    nb_Msg_Memory: number;
}

interface IAiEmbeddingConfig {
    id_Societe: number;
    Provider: string;
    aiUrl: string;
    Modele: string;
    ApiKey: string;
}

interface IKnowledgeChunk {
    Id: string;
    Source: string;
    TextChunk: string;
    Embedding: number[]; // Parsed from string
    Provider_Used?: string;
}

// Imports for Agentic Tools (Reuse existing controllers)
import { rh_agent } from "../controlers/rh_agent";
import { demande_conge_liste } from "../controlers/demande_conge";
import { get_formation_liste } from "../controlers/formation";

// Global Context
let AgentConfig: IAiAgentConfig | null = null;
let EmbeddingConfig: IAiEmbeddingConfig | null = null;
let KnowledgeBase: IKnowledgeChunk[] = [];

let isAiLoading = false;
let isAiLoaded = false;

// --- AGENTIC TOOLS REGISTRY ---

// Adapter to call existing controllers internally with User Security Context
const callController = async (controllerFn: Function, bodyParams: any, realReq: any) => {
    // 1. CLONE SECURITY CONTEXT
    // We pass the exact same "user" (decoded from JWT) and "params" (which usually holds the user info in this architecture)
    // This ensures 'rh_agent' or 'demande_conge_liste' see the REAL user (Matricule, TeamLeader, etc.)
    const mockReq = {
        body: { ...bodyParams },  // AI provides parameters (e.g., filters)
        params: { ...realReq.user }, // CRITICAL: Identity comes from JWT, NOT AI. (rhpBE often stores user info in req.params after validation)
        user: realReq.user
    };

    // 2. Mock Response to capture output
    let resultData = null;
    const mockRes = {
        send: (data: any) => { resultData = data; },
        status: (code: number) => ({ send: (data: any) => { resultData = { ...data, status: code }; } })
    };

    // 3. Execute existing strict logic
    try {
        await controllerFn(mockReq, mockRes);
    } catch (e: any) {
        console.error("[AI] Tool Execution Error:", e);
        return { result: false, message: "Erreur exécution outil: " + e.message };
    }
    return resultData;
};

const TOOLS: any = {
    // 1. Employee Search
    rh_agent: {
        description: "Rechercher des collaborateurs (Annuaire). Filtres: Nom, Service, Fonction, Actif (1/0).",
        // Maps to: mainRooting.post("/rh_agent", ...)
        execute: async (params: any, req: any) => await callController(rh_agent, params, req)
    },
    // 2. Leave Requests
    demande_conge_liste: {
        description: "Lister les demandes de congés (Absences). Filtres: Statut ('En attente', 'Validé'), Matricule (optionnel).",
        // Maps to: mainRooting.post("/demande_conge_liste", ...)
        execute: async (params: any, req: any) => await callController(demande_conge_liste, params, req)
    },
    // 3. Training List
    get_formation_liste: {
        description: "Lister les formations disponibles. Filtres: Theme, Annee.",
        // Maps to: mainRooting.post("/get_formation_liste", ...)
        execute: async (params: any, req: any) => await callController(get_formation_liste, params, req)
    }
};

// Initialize AI Context (Called at Server Start)
export const initAiContext = async (idSociete: number = 101) => {
    if (isAiLoading) return; // Prevent double init
    isAiLoading = true;
    isAiLoaded = false;

    try {
        console.log("[AI] Initializing Context for Societe:", idSociete);

        // 1. Load Agent Config
        const resAgent = await lireSql(
            `SELECT TOP 1 * FROM Ai_Agent WHERE ISNULL(NULLIF(id_Societe, -1), ${idSociete}) = ${idSociete}`
        );
        if (resAgent.result && resAgent.data.length > 0) {
            AgentConfig = resAgent.data[0];
            console.log(`[AI] Agent Config Loaded: ${AgentConfig?.Provider} / ${AgentConfig?.Modele}`);
        } else {
            console.warn("[AI] No Agent Configuration found.");
        }

        // 2. Load Embedding Config
        const resEmbed = await lireSql(
            `SELECT TOP 1 * FROM Ai_Embedding WHERE ISNULL(NULLIF(id_Societe, -1), ${idSociete}) = ${idSociete}`
        );
        if (resEmbed.result && resEmbed.data.length > 0) {
            EmbeddingConfig = resEmbed.data[0];
            console.log(`[AI] Embedding Config Loaded: ${EmbeddingConfig?.Provider}`);
        } else {
            console.warn("[AI] No Embedding Configuration found.");
        }

        // 3. Load Knowledge Base
        const resKB = await lireSql(
            `SELECT Id, Source, TextChunk, Embedding FROM Ai_KnowledgeBase WHERE ISNULL(NULLIF(id_Societe, -1), ${idSociete}) = ${idSociete}`
        );

        if (resKB.result && resKB.data.length > 0) {
            KnowledgeBase = resKB.data.map((row: any) => {
                let vec: number[] = [];
                try {
                    if (typeof row.Embedding === 'string') {
                        vec = JSON.parse(row.Embedding);
                    }
                } catch (e) {
                    console.error(`[AI] Error parsing embedding for Chunk ${row.Id}`, e);
                }
                return {
                    Id: row.Id,
                    Source: row.Source,
                    TextChunk: row.TextChunk,
                    Embedding: vec
                };
            }).filter((k: IKnowledgeChunk) => k.Embedding && k.Embedding.length > 0);

            console.log(`[AI] Knowledge Base Loaded: ${KnowledgeBase.length} chunks.`);
        } else {
            console.warn("[AI] Knowledge Base is empty.");
            KnowledgeBase = [];
        }

        isAiLoaded = true;

    } catch (error) {
        console.error("[AI] Initialization Error:", error);
    } finally {
        isAiLoading = false;
    }
};

// Cosine Similarity
const cosineSimilarity = (vecA: number[], vecB: number[]) => {
    if (vecA.length !== vecB.length) return 0;
    const dotProduct = vecA.reduce((sum, a, i) => sum + a * vecB[i], 0);
    const magA = Math.sqrt(vecA.reduce((sum, a) => sum + a * a, 0));
    const magB = Math.sqrt(vecB.reduce((sum, b) => sum + b * b, 0));
    if (magA === 0 || magB === 0) return 0;
    return dotProduct / (magA * magB);
};

export const ask_ai_assistant = async (req: Request, res: Response) => {
    const { question } = req.body;

    if (!question) {
        res.send({ result: false, message: "Question vide" });
        return;
    }

    // Check Loading State
    if (!isAiLoaded) {
        if (isAiLoading) {
            res.send({
                result: true,
                data: {
                    answer: "Je suis en train de charger ma base de connaissances. Veuillez patienter quelques instants...",
                    isAiLoading: true
                }
            });
            return;
        } else {
            // Retry Init if failed or not started
            initAiContext();
            res.send({
                result: true,
                data: {
                    answer: "Je démarre l'initialisation de ma mémoire. Réessayez dans quelques secondes...",
                    isAiLoading: true
                }
            });
            return;
        }
    }

    // Ensure Context is Loaded
    if (!AgentConfig || !EmbeddingConfig) {
        res.send({ result: false, message: "IA non configurée sur le serveur." });
        return;
    }


    try {
        console.log(`[AI] Processing Question: "${question}" with Provider Agent: ${AgentConfig.Provider}, Embedding: ${EmbeddingConfig.Provider}`);

        // 1. Get Embedding for Question
        let qVec: number[] = [];
        try {
            // Assuming Config URL is compatible (needs replacement logic similar to Desktop)
            let embedUrl = EmbeddingConfig.aiUrl.replace("{MODEL}", EmbeddingConfig.Modele);
            let embedHeaders: any = { "Content-Type": "application/json" };
            let embedPayload: any = {};

            const providerEmb = EmbeddingConfig.Provider.toUpperCase();

            if (providerEmb === "GEMINI") {
                embedUrl += `?key=${EmbeddingConfig.ApiKey}`;
                // Gemini embedContent uses 'content' (singular)
                embedPayload = { content: { parts: [{ text: question }] } };
            } else if (providerEmb === "OLLAMA") {
                embedPayload = { model: EmbeddingConfig.Modele, prompt: question };
            } else {
                // OpenAI Standard
                embedHeaders["Authorization"] = `Bearer ${EmbeddingConfig.ApiKey}`;
                if (providerEmb === "AZUREOPENAI") embedHeaders["api-key"] = EmbeddingConfig.ApiKey;
                embedPayload = { input: question, model: EmbeddingConfig.Modele };
            }

            console.log(`[AI] Embedding Request URL: ${embedUrl}`);
            // Call Embedding API
            const embRes = await axios.post(embedUrl, embedPayload, { headers: embedHeaders });

            if (providerEmb === "GEMINI") {
                qVec = embRes.data.embedding.values;
            } else if (providerEmb === "OLLAMA") {
                qVec = embRes.data.embedding;
            } else {
                qVec = embRes.data.data[0].embedding;
            }
        } catch (embeddingError: any) {
            console.error("[AI] Embedding API Error:", embeddingError?.response?.data || embeddingError.message);
            throw new Error("Embedding API: " + (embeddingError?.response?.status || 500));
        }

        // 2. Search Knowledge Base
        const docs = KnowledgeBase
            .map(chunk => ({ ...chunk, score: cosineSimilarity(qVec, chunk.Embedding) }))
            .sort((a, b) => b.score - a.score)
            .slice(0, 5); // Top 5 relevant chunks

        console.log(`[AI] Found ${docs.length} relevant chunks. Top Score: ${docs[0]?.score}`);

        const contextText = docs.map(d => d.TextChunk).join("\n\n---\n\n");

        // 3. Prepare System Prompt with Tools
        const toolsDesc = Object.entries(TOOLS).map(([name, def]: any) => `- ${name}: ${def.description}`).join("\n");
        const currentUser = req.params; // Validate middleware puts user info here
        const userContextPrompt = `
User Context:
- Name: ${currentUser.Nom} ${currentUser.Prenom}
- Matricule: ${currentUser.Matricule}
- Role: ${currentUser.TeamLeader ? "Manager/Team Leader" : "Collaborator"}
- Service: ${currentUser.Service || "N/A"}

Instructions:
- If the user uses "mon", "ma", "mes", "moi" (my/me), use the Matricule '${currentUser.Matricule}'.
- If the user asks for "mon équipe" (my team) and is a Manager, do not filter by Matricule.
`;

        const toolPrompt = `
You have access to the following HR Tools (APIs):
${toolsDesc}

If the user asks for data matching these tools, DO NOT just answer text.
Instead, output a JSON Action Block exactly like this:
###ACTION###
{"tool": "rh_agent", "params": {"Service": "IT"}}
###ACTION###

Rules:
- Use French in conversation.
- If data is needed, use ###ACTION###.
- Otherwise, use the Context below to answer.
`;

        const systemInstruction = AgentConfig.Instructions || "Tu es un assistant utile.";
        const fullSystemPrompt = `${systemInstruction}\n${userContextPrompt}\n${toolPrompt}\n\nContexte:\n${contextText}`;

        // 4. Ask Agent (Chat)
        let agentUrl = AgentConfig.aiUrl.replace("{MODEL}", AgentConfig.Modele);
        let agentHeaders: any = { "Content-Type": "application/json" };
        let agentPayload: any = {};

        const providerAgent = AgentConfig.Provider.toUpperCase();

        if (providerAgent === "GEMINI") {
            agentUrl += `?key=${AgentConfig.ApiKey}`;
            // Gemini Structure
            agentPayload = {
                contents: [{ parts: [{ text: `${fullSystemPrompt}\n\nQuestion: ${question}` }] }]
            };
        } else if (providerAgent === "OLLAMA") {
            agentPayload = {
                model: AgentConfig.Modele,
                prompt: `${fullSystemPrompt}\n\nQuestion: ${question}`,
                stream: false
            };
        } else {
            // OpenAI Standard
            agentHeaders["Authorization"] = `Bearer ${AgentConfig.ApiKey}`;
            if (providerAgent === "AZUREOPENAI") agentHeaders["api-key"] = AgentConfig.ApiKey;

            agentPayload = {
                model: AgentConfig.Modele,
                messages: [
                    { role: "system", content: fullSystemPrompt },
                    { role: "user", content: question }
                ]
            };
        }

        console.log(`[AI] Chat Request URL: ${agentUrl} (Provider: ${providerAgent})`);

        try {
            const chatRes = await axios.post(agentUrl, agentPayload, { headers: agentHeaders });
            console.log(`[AI] Chat Response Status: ${chatRes.status}`);

            let answer = "";
            if (providerAgent === "GEMINI") {
                answer = chatRes.data.candidates?.[0]?.content?.parts?.[0]?.text;
            } else if (providerAgent === "OLLAMA") {
                answer = chatRes.data.response;
            } else {
                answer = chatRes.data.choices?.[0]?.message?.content;
            }

            if (!answer) {
                console.error("[AI] Empty answer received from provider. Dump:", JSON.stringify(chatRes.data).substring(0, 500));
            }

            // --- AGENTIC EXECUTION LOGIC ---
            let apiData = null;
            const actionRegex = /###ACTION###\s*(\{.*?\})\s*###ACTION###/s;
            const match = answer.match(actionRegex);

            if (match) {
                try {
                    const actionJson = JSON.parse(match[1]);
                    const toolName = actionJson.tool;
                    const toolParams = actionJson.params;

                    console.log(`[AI] Agent requested Tool Action: ${toolName}`, toolParams);

                    if (TOOLS[toolName]) {
                        // EXECUTE TOOL WITH USER CONTEXT
                        apiData = await TOOLS[toolName].execute(toolParams, req);

                        // Refine answer to confirm action
                        answer = answer.replace(match[0], "").trim();
                        if (!answer) answer = `J'ai trouvé les informations pour : ${toolName}.`;

                        // Assuming apiData is an array of data or a standard response
                        // If it's a standard response object {result: true, data: [...]}, unwrap it
                        if (apiData && apiData.data && Array.isArray(apiData.data)) {
                            // It's likely a list
                            apiData = apiData.data;
                        }
                        // If it's the raw array
                        else if (Array.isArray(apiData)) {
                            // Keep as is
                        }
                        // If it's something else
                        else if (apiData && apiData.data) {
                            apiData = [apiData.data]; // Wrap single obj
                        }

                    } else {
                        console.warn(`[AI] Unknown tool requested: ${toolName}`);
                    }

                } catch (jsonErr) {
                    console.error("[AI] Failed to parse Action JSON:", jsonErr);
                }
            }
            // -----------------------------

            res.send({
                result: true,
                data: {
                    answer: answer || "Désolé, je n'ai reçu aucune réponse du fournisseur d'IA.",
                    sources: [...new Set(docs.map(d => d.Source))], // Return unique sources
                    sqlData: apiData // Attach Tool Data (reusing proposed field name)
                }
            });

        } catch (chatError: any) {
            console.error("[AI] Chat API Error:", chatError?.response?.data || chatError.message);
            throw new Error("Chat API: " + (chatError?.response?.status || 500));
        }

    } catch (error: any) {
        console.error("[AI] Error processing request full details:", error);
        if (error.response) {
            console.error("[AI] Response Data:", JSON.stringify(error.response.data));
            console.error("[AI] Response Status:", error.response.status);
        }
        res.send({ result: false, message: "Erreur IA: " + error.message });
    }
};
