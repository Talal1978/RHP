import { Request, Response } from "express";
import axios from "axios";
import { lireSql } from "../modules/module_sqlRW";
import { VGLOBALES } from "../modules/module_initialisation";
import { Int, NVarChar } from "mssql";

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
import { rh_agent } from "./rh_agent";
import { demande_conge_liste, get_conge_droits } from "./demande_conge";
import { get_formation_liste, get_formation } from "./formation";
import { get_signatures_api } from "./dashboard";
import { noteFraisListe } from "./note_frais";
import { bulletin_liste } from "./rh_bulletin_liste";
import { demande_avance_liste, get_mnt_avances_encours } from "./demande_avance";
import { demande_pret_liste, get_mnt_prets_encours } from "./demande_pret";
import { dossier_maladie_liste } from "./dossier_maladie";
import { getOrganigramme, getPoste } from "./organization";
import { get_recrutement_demande_liste } from "./recrutement";
import { get_avancement_timeline } from "./rh_avancement";
import { discipline_liste } from "./discipline";
import { demandeDocAdminListe } from "./demande_doc_admin";
import { declarationATListe } from "./declaration_at";
import { get_agenda } from "./agenda";
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

    // DEBUG: Log context to ensure we have id_Societe


    const mockReq = {
        body: { ...bodyParams },  // AI provides parameters (e.g., filters)
        params: { ...realReq.params }, // CHANGED: Use realReq.params (contains id_Societe, etc.)
        user: realReq.user
    };

    // 2. Mock Response to capture output
    let resultData: any = null;
    const mockRes = {
        send: (data: any) => { resultData = data; },
        json: (data: any) => { resultData = data; }, // Add json() method for controllers that use res.json()
        status: (code: number) => ({
            send: (data: any) => { resultData = { ...data, status: code }; },
            json: (data: any) => { resultData = { ...data, status: code }; }
        })
    };

    // 3. Execute existing strict logic
    try {
        await controllerFn(mockReq, mockRes);
    } catch (e: any) {
        console.error("[AI] Tool Execution Error:", e);
        return { result: false, message: "Erreur exécution outil: " + e.message };
    }

    // DEBUG: Log Result
    if (resultData && resultData.result === false) {
        console.error("[AI] Tool Logic Failed:", resultData.message);
    } else {

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
    // 3. Leave Rights/Balance
    get_conge_droits: {
        description: "Consulter le solde de congé (droits, restant, cumulé). Param: Matricule (obligatoire, utiliser celui de l'utilisateur ('moi') si non précisé), Dat_Deb_Conge (optionnel, date de référence).",
        // Maps to: mainRooting.post("/get_conge_droits", ...)
        execute: async (params: any, req: any) => {
            // Default Dat_Deb_Conge to today if missing
            if (!params.Dat_Deb_Conge) {
                const now = new Date();
                // Format: DD/MM/YYYY (Safer for French SQL Servers)
                params.Dat_Deb_Conge = `${now.getDate().toString().padStart(2, '0')}/${(now.getMonth() + 1).toString().padStart(2, '0')}/${now.getFullYear()}`;
            }

            // Default Matricule to connected user if missing
            if (!params.Matricule) {
                params.Matricule = req.params.Matricule;
            }

            const res = await callController(get_conge_droits, params, req);
            return res;
        }
    },
    // 4. Training List
    get_formation_liste: {
        description: "Lister les formations disponibles. Filtres: Theme, Annee.",
        // Maps to: mainRooting.post("/get_formation_liste", ...)
        execute: async (params: any, req: any) => await callController(get_formation_liste, params, req)
    },
    // 5. Parapheur (Signatures)
    get_signatures: {
        description: "Lister les documents qui attendent ma signature (parapheur). Aucune paramètre requis.",
        execute: async (params: any, req: any) => {
            return await callController(get_signatures_api, params, req);
        }
    },
    // 6. Expense Reports (Notes de Frais)
    get_notes_frais: {
        description: "Lister mes notes de frais. Filtres: Statut ('SS', 'VAL'), Dat_Du (YYYY-MM-DD), Dat_Au (YYYY-MM-DD).",
        execute: async (params: any, req: any) => {
            // Default Matricule to empty string to avoid SQL NULL issues
            if (!params.Matricule) params.Matricule = "";
            if (!params.Statut) params.Statut = "";

            const res = await callController(noteFraisListe, params, req);
            return res;
        }
    },
    // 7. Payroll Bulletins (Bulletins de Paie)
    get_bulletins: {
        description: "Consulter mes bulletins de paie. Filtres: Dat_Du (YYYY-MM-DD), Dat_Au (YYYY-MM-DD). Retourne la liste des préparations de paie (Année, Mois).",
        execute: async (params: any, req: any) => {
            if (!params.Matricule) params.Matricule = "";

            const res = await callController(bulletin_liste, params, req);
            return res;
        }
    },
    // 8. Demandes d'Avance
    demande_avance_liste: {
        description: "Lister les demandes d'avance. Filtres: Matricule, Dat_Du, Dat_Au.",
        execute: async (params: any, req: any) => await callController(demande_avance_liste, params, req)
    },
    get_mnt_avances_encours: {
        description: "Obtenir le montant des avances en cours. Param: Matricule.",
        execute: async (params: any, req: any) => await callController(get_mnt_avances_encours, params, req)
    },
    // 9. Demandes de Prêt
    demande_pret_liste: {
        description: "Lister les demandes de prêt. Filtres: Matricule, Dat_Du, Dat_Au.",
        execute: async (params: any, req: any) => await callController(demande_pret_liste, params, req)
    },
    get_mnt_prets_encours: {
        description: "Obtenir le montant des prêts en cours. Param: Matricule.",
        execute: async (params: any, req: any) => await callController(get_mnt_prets_encours, params, req)
    },
    // 10. Dossier Maladie
    dossier_maladie_liste: {
        description: "Historique des dossiers maladie. Filtres: Matricule, Dat_Du, Dat_Au.",
        execute: async (params: any, req: any) => await callController(dossier_maladie_liste, params, req)
    },
    // 11. Recrutement
    get_recrutement_demande_liste: {
        description: "Suivi des demandes de recrutement. Filtres: Statut, Dat_Du, Dat_Au.",
        execute: async (params: any, req: any) => await callController(get_recrutement_demande_liste, params, req)
    },
    // 12. Discipline
    discipline_liste: {
        description: "Historique disciplinaire (Sanctions). Filtre: Matricule.",
        execute: async (params: any, req: any) => await callController(discipline_liste, params, req)
    },
    // 13. Documents Admin
    demandeDocAdminListe: {
        description: "Lister les demandes de documents administratifs. Filtres: Matricule, Dat_Du, Dat_Au.",
        execute: async (params: any, req: any) => await callController(demandeDocAdminListe, params, req)
    },
    // 14. Déclaration AT
    declarationATListe: {
        description: "Lister les déclarations d'accident de travail. Filtres: Matricule, Dat_Du, Dat_Au.",
        execute: async (params: any, req: any) => await callController(declarationATListe, params, req)
    },
    // 15. Carrière / Avancement
    get_avancement_timeline: {
        description: "Frise chronologique d'avancement et carrière. Param: Matricule.",
        execute: async (params: any, req: any) => await callController(get_avancement_timeline, params, req)
    },
    // 16. Organisation
    getOrganigramme: {
        description: "Récupère l'arbre hiérarchique. Pour chercher une entité par son NOM (ex: 'Division Export', 'Service IT'), APPELEZ cet outil avec 'cod_entite': '' (chaîne vide) pour tout charger, puis analysez le JSON retourné.",
        execute: async (params: any, req: any) => await callController(getOrganigramme, params, req)
    },
    getPoste: {
        description: "Détails d'un poste. Param: cod_poste.",
        execute: async (params: any, req: any) => await callController(getPoste, params, req)
    },
    // 17. Agenda
    get_agenda: {
        description: "Consulter l'agenda / planning. Filtres: Matricule, Dat_Du, Dat_Au.",
        execute: async (params: any, req: any) => await callController(get_agenda, params, req)
    },
    // 18. Details Formation
    get_formation: {
        description: "Détails d'une formation spécifique. Param: Cod_Formation.",
        execute: async (params: any, req: any) => await callController(get_formation, params, req)
    }
};

// Initialize AI Context (Called at Server Start)
export const initAiContext = async (idSociete: number = 101) => {
    if (isAiLoading) return; // Prevent double init
    isAiLoading = true;
    isAiLoaded = false;

    try {


        // 1. Load Agent Config
        const resAgent = await lireSql(
            `SELECT TOP 1 * FROM Ai_Agent WHERE ISNULL(NULLIF(id_Societe, -1), ${idSociete}) = ${idSociete}`
        );
        if (resAgent.result && resAgent.data.length > 0) {
            AgentConfig = resAgent.data[0];

        } else {
            console.warn("[AI] No Agent Configuration found.");
        }

        // 2. Load Embedding Config
        const resEmbed = await lireSql(
            `SELECT TOP 1 * FROM Ai_Embedding WHERE ISNULL(NULLIF(id_Societe, -1), ${idSociete}) = ${idSociete}`
        );
        if (resEmbed.result && resEmbed.data.length > 0) {
            EmbeddingConfig = resEmbed.data[0];

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


        } else {

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

// Intent Classification Helper
const classifyIntent = async (question: string, conversationHistory: any[]): Promise<'ACTION' | 'KNOWLEDGE'> => {
    if (!AgentConfig) return 'KNOWLEDGE';

    // Build list of available actions
    const availableActions = Object.keys(TOOLS).map(toolName => {
        return `- ${toolName}: ${TOOLS[toolName].description}`;
    }).join('\n');

    const classificationPrompt = `Tu es un classificateur d'intentions. Analyse la question de l'utilisateur et détermine s'il s'agit:
- ACTION: Une demande qui nécessite d'interroger une base de données RH (congés, salaires, bulletins, notes de frais, signatures, formations, annuaire)
- KNOWLEDGE: Une question générale sur les procédures, politiques, définitions, ou informations contenues dans des documents

Actions disponibles:
${availableActions}

Historique de conversation (pour contexte):
${conversationHistory.slice(-3).map(msg => `${msg.role === 'user' ? 'Utilisateur' : 'Assistant'}: ${msg.content}`).join('\n')}

Question actuelle: "${question}"

Instructions:
- Si la question demande des DONNÉES PERSONNELLES (mes congés, mon salaire, mes notes de frais, documents à signer, etc.) → ACTION
- Si la question demande des INFORMATIONS sur d'autres employés (qui est en congé, liste des employés, etc.) → ACTION
- Si la question concerne l'ORGANISATION, les SERVICES, les DIVISIONS ou la HIERARCHIE (Où est le service X ?, Qui est le chef de Y ?) → ACTION
- Si la question demande une EXPLICATION, PROCÉDURE, POLITIQUE, ou DÉFINITION → KNOWLEDGE
- En cas de doute, préfère ACTION pour les questions personnelles ("mon", "ma", "mes") ou structurelles.

Réponds UNIQUEMENT par "ACTION" ou "KNOWLEDGE", sans explication.`;

    try {
        let classificationUrl = AgentConfig.aiUrl.replace("{MODEL}", AgentConfig.Modele);
        let classificationHeaders: any = { "Content-Type": "application/json" };
        let classificationPayload: any = {};
        const provider = AgentConfig.Provider.toUpperCase();

        if (provider === "GEMINI") {
            classificationUrl += `?key=${AgentConfig.ApiKey}`;
            classificationPayload = {
                contents: [{ parts: [{ text: classificationPrompt }] }]
            };
        } else if (provider === "OLLAMA") {
            classificationPayload = {
                model: AgentConfig.Modele,
                prompt: classificationPrompt,
                stream: false
            };
        } else {
            classificationHeaders["Authorization"] = `Bearer ${AgentConfig.ApiKey}`;
            if (provider === "AZUREOPENAI") classificationHeaders["api-key"] = AgentConfig.ApiKey;
            classificationPayload = {
                model: AgentConfig.Modele,
                messages: [{ role: "user", content: classificationPrompt }]
            };
        }

        const classificationRes = await axios.post(classificationUrl, classificationPayload, { headers: classificationHeaders });

        let classification = "";
        if (provider === "GEMINI") {
            classification = classificationRes.data.candidates?.[0]?.content?.parts?.[0]?.text || "";
        } else if (provider === "OLLAMA") {
            classification = classificationRes.data.response || "";
        } else {
            classification = classificationRes.data.choices?.[0]?.message?.content || "";
        }

        classification = classification.trim().toUpperCase();


        return classification.includes('ACTION') ? 'ACTION' : 'KNOWLEDGE';
    } catch (error) {
        console.error("[AI] Classification error, defaulting to KNOWLEDGE:", error);
        return 'KNOWLEDGE';
    }
};

export const ask_ai_assistant = async (req: Request, res: Response) => {
    const { question, history } = req.body;

    if (!question) {
        res.send({ result: false, message: "Question vide" });
        return;
    }

    // Ping for status check
    if (question === "PING_STATUS") {
        if (!isAiLoaded) {
            if (!isAiLoading) initAiContext(); // Trigger init if not running
            res.send({ result: true, data: { isAiLoading: true } });
        } else {
            res.send({ result: true, data: { isAiLoading: false } });
        }
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


        // ===== STEP 0: CLASSIFY INTENT =====
        const maxHistory = AgentConfig.nb_Msg_Memory || 10;
        const conversationHistory = Array.isArray(history) ? history.slice(-maxHistory) : [];

        const intent = await classifyIntent(question, conversationHistory);


        // 1. Get Embedding for Question (only for KNOWLEDGE intent)
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
        let docs = KnowledgeBase
            .map(chunk => ({ ...chunk, score: cosineSimilarity(qVec, chunk.Embedding) }))
            .sort((a, b) => b.score - a.score)
            .slice(0, 5); // Top 5 relevant chunks



        const contextText = docs.map(d => d.TextChunk).join("\n\n---\n\n");

        // 3. Prepare System Prompt with Tools (or KB only for KNOWLEDGE intent)
        const toolsDesc = Object.entries(TOOLS).map(([name, def]: any) => `- ${name}: ${def.description}`).join("\n");
        const currentUser = req.params; // Validate middleware puts user info here

        // Rich User Data Fetching
        let richUserData: any = {};
        if (currentUser.Matricule) {
            try {
                const rsUser = await lireSql(`
                    SELECT 
                        a.Nom_Agent, a.Prenom_Agent, a.Sexe, a.Dat_Naissance, a.Dat_Entree,
                        a.Cod_Entite, a.Cod_Poste, a.Cod_Grade,
                        g.Lib_Grade,
                        p.Lib_Poste,
                        e.Lib_Entite,
                        mgr.Nom_Agent as Mgr_Nom, mgr.Prenom_Agent as Mgr_Prenom
                    FROM Rh_Agent a
                    LEFT JOIN Org_Entite e ON a.id_Societe = e.id_Societe AND a.Cod_Entite = e.Cod_Entite
                    LEFT JOIN Rh_Agent mgr ON e.Responsable = mgr.Matricule AND e.id_Societe = mgr.id_Societe
                    LEFT JOIN Org_Poste p ON a.id_Societe = p.id_Societe AND a.Cod_Poste = p.Cod_Poste
                    LEFT JOIN Org_Grade g ON a.id_Societe = g.id_Societe AND a.Cod_Grade = g.Cod_Grade
                    WHERE a.id_Societe = @idSoc AND a.Matricule = @Matricule
                `, [
                    { param: "Matricule", sqlType: NVarChar, valeur: currentUser.Matricule },
                    { param: "idSoc", sqlType: Int, valeur: currentUser.id_Societe || 101 }
                ]);

                if (rsUser.result && rsUser.data.length > 0) {
                    richUserData = rsUser.data[0];
                    // Calculate Age
                    if (richUserData.Dat_Naissance) {
                        const dob = new Date(richUserData.Dat_Naissance);
                        const diffMs = Date.now() - dob.getTime();
                        const ageDt = new Date(diffMs);
                        richUserData.Age = Math.abs(ageDt.getUTCFullYear() - 1970);
                    }
                }
            } catch (err) {
                console.error("[AI] Error fetching rich user data:", err);
            }
        }

        const userContextPrompt = `
User Context:
- Name: ${richUserData.Nom_Agent || currentUser.Nom} ${richUserData.Prenom_Agent || currentUser.Prenom}
- Matricule: ${currentUser.Matricule}
- Age: ${richUserData.Age ? richUserData.Age + " ans" : "N/A"}
- Sexe: ${richUserData.Sexe === 'M' ? 'Homme' : (richUserData.Sexe === 'F' ? 'Femme' : 'N/A')}
- Poste: ${richUserData.Lib_Poste || "N/A"} (Code: ${richUserData.Cod_Poste || "N/A"})
- Grade: ${richUserData.Lib_Grade || "N/A"} (Code: ${richUserData.Cod_Grade || "N/A"})
- Entité/Service: ${richUserData.Lib_Entite || currentUser.Service || "N/A"} (Code: ${richUserData.Cod_Entite || currentUser.Cod_Entite || "N/A"})
- Responsable Hiérarchique: ${richUserData.Mgr_Nom ? richUserData.Mgr_Nom + ' ' + richUserData.Mgr_Prenom : "Non défini (Racine)"}
- Date Entrée: ${richUserData.Dat_Entree ? new Date(richUserData.Dat_Entree).toLocaleDateString('fr-FR') : "N/A"}
- Role: ${currentUser.TeamLeader ? "Manager/Team Leader" : "Collaborator"}

Instructions:
- If the user uses "mon", "ma", "mes", "moi" (my/me), use the Matricule '${currentUser.Matricule}' or Cod_Entite '${richUserData.Cod_Entite || currentUser.Cod_Entite}'.
- If the user asks for "mon équipe" (my team) and is a Manager, do not filter by Matricule.
- When searching organigram data, use the entity CODE (Cod_Entite), not the label.
- You can use the user's age, gender, or seniority to personalize answers if relevant.
- IMPORTANT: If you answer based ONLY on this User Context (e.g. asking for name, id, role, age, manager), append '###PERSONAL_CONTEXT###' at the very end of your answer.
`;

        // Conditionally include tools based on intent classification
        const toolPrompt = intent === 'ACTION' ? `
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
- IMPORTANT: NEVER mention the internal tool names (e.g. 'get_conge_droits', 'rh_agent') in your final answer text.
- IMPORTANT: NEVER list sources or say "D'après les sources..." if you executed an action.
` : `
Rules:
- Use French in conversation.
- Provide informative answers based on the Context below.
- If you don't find relevant information in the Context, say so.
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
            // Gemini Structure - Build contents array with history
            const contents = conversationHistory.map(msg => ({
                role: msg.role === 'user' ? 'user' : 'model', // Gemini uses 'model' instead of 'assistant'
                parts: [{ text: msg.content }]
            }));
            // Add current question
            contents.push({ role: 'user', parts: [{ text: `${fullSystemPrompt}\n\nQuestion: ${question}` }] });
            agentPayload = { contents };
        } else if (providerAgent === "OLLAMA") {
            // Ollama doesn't support multi-turn - append history to prompt
            let historyText = conversationHistory.map(msg => `${msg.role === 'user' ? 'User' : 'Assistant'}: ${msg.content}`).join('\n');
            agentPayload = {
                model: AgentConfig.Modele,
                prompt: `${fullSystemPrompt}\n\nHistorique:\n${historyText}\n\nQuestion: ${question}`,
                stream: false
            };
        } else {
            // OpenAI Standard
            agentHeaders["Authorization"] = `Bearer ${AgentConfig.ApiKey}`;
            if (providerAgent === "AZUREOPENAI") agentHeaders["api-key"] = AgentConfig.ApiKey;

            const messages = [
                { role: "system", content: fullSystemPrompt },
                ...conversationHistory.map(msg => ({ role: msg.role, content: msg.content })),
                { role: "user", content: question }
            ];
            agentPayload = { model: AgentConfig.Modele, messages };
        }



        try {
            const chatRes = await axios.post(agentUrl, agentPayload, { headers: agentHeaders });


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

            // --- PERSONAL CONTEXT CLEANUP ---
            if (answer && answer.includes("###PERSONAL_CONTEXT###")) {
                console.log("[AI] Answer based on Personal Context - Clearing Sources.");
                answer = answer.replace("###PERSONAL_CONTEXT###", "").trim();
                docs = []; // Prevent listing irrelevant sources
            }
            // --------------------------------

            // --- AGENTIC EXECUTION LOGIC ---
            let apiData = null;
            // Improved Regex to be more robust (spaces, case insensitive, dotAll)
            // Matches: ###ACTION### {json} ###ACTION###
            // Or: ### ACTION ### {json} ### ACTION ###
            const actionRegex = /###\s*ACTION\s*###\s*(\{[\s\S]*?\})\s*###\s*ACTION\s*###/i;
            const match = answer.match(actionRegex);

            if (match) {
                try {
                    const actionJson = JSON.parse(match[1]);
                    const toolName = actionJson.tool;
                    const toolParams = actionJson.params;



                    if (TOOLS[toolName]) {
                        // Remove the Action Block from the text answer
                        answer = answer.replace(match[0], "").trim();
                        if (answer.length === 0) answer = "Voici les informations demandées :";

                        try {
                            // console.log(`[AI] Executing tool ${toolName} with params:`, JSON.stringify(toolParams));
                            apiData = await TOOLS[toolName].execute(toolParams, req);
                            // console.log(`[AI] Tool ${toolName} execution completed. Success: ${apiData?.result}, Rows: ${apiData?.data?.length || 0}`);

                            if (!apiData || !apiData.result) {
                                console.error(`[AI] Tool ${toolName} returned error:`, apiData?.sort || 'Unknown error');
                                answer = `Je ne peux pas accéder à cette information pour le moment (erreur technique).`;
                                docs = [];
                            } else if (!apiData.data || apiData.data.length === 0) {
                                console.warn(`[AI] Tool ${toolName} returned empty data`);
                                answer = `Aucune donnée disponible pour cette requête.`;
                                docs = [];
                            } else {
                                // Clear sources if action is successful
                                docs = [];
                                // UX: Replace any preamble with standard success text
                                answer = "Voici les informations demandées :";

                                // --- RE-ACT LOOP: Feed Tool Result back to AI for Analysis ---
                                // We do this to allow the AI to "read" the data (e.g. Organigram) and answer specific questions
                                // instead of just dumping the table.


                                // SMART FILTERING FOR ORGANIGRAM: Reduce data size for "my entity" queries
                                let filteredData = apiData?.data || apiData;
                                if (toolName === 'getOrganigramme' && Array.isArray(filteredData) && filteredData.length > 10) {
                                    const userCodEntite = richUserData?.Cod_Entite || currentUser.Cod_Entite;
                                    if (userCodEntite && (question.toLowerCase().includes('mon') || question.toLowerCase().includes('ma'))) {


                                        // Find user's entity
                                        const userEntity = filteredData.find((e: any) => e.Cod_Entite === userCodEntite);
                                        if (userEntity) {
                                            const parentCode = userEntity.Parent;

                                            // DIRECT ANSWER FOR ATTACHMENT QUESTIONS - BYPASS AI
                                            if (question.toLowerCase().includes('attach') || question.toLowerCase().includes('dépend')) {
                                                if (!parentCode || parentCode === '') {
                                                    answer = `Votre entité **${userEntity.Lib_Entite}** est une entité de niveau racine.###PERSONAL_CONTEXT###`;
                                                    docs = [];
                                                    filteredData = null; // Skip Re-Act
                                                } else {
                                                    const parentEntity = filteredData.find((e: any) => e.Cod_Entite === parentCode);
                                                    if (parentEntity) {
                                                        answer = `Votre entité **${userEntity.Lib_Entite}** dépend de **${parentEntity.Lib_Entite}**.###PERSONAL_CONTEXT###`;
                                                        docs = [];
                                                        filteredData = null; // Skip Re-Act
                                                    }
                                                }
                                            }

                                            // If not direct answer, filter for Re-Act
                                            if (filteredData) {
                                                // Keep: user entity + parent + siblings (same parent) + children
                                                filteredData = filteredData.filter((e: any) =>
                                                    e.Cod_Entite === userCodEntite || // User's entity
                                                    e.Cod_Entite === parentCode || // Parent
                                                    e.Parent === parentCode || // Siblings
                                                    e.Parent === userCodEntite // Children
                                                );
                                            }
                                        }
                                    }

                                    // Only proceed with Re-Act if filteredData is not null (not already answered)
                                    if (filteredData && Array.isArray(filteredData) && filteredData.length > 0) {
                                        const toolResultStr = JSON.stringify(filteredData).substring(0, 50000); // Increased limit
                                        const followUpSystem = `
RÉSULTAT DE L'OUTIL (${toolName}):
${toolResultStr}

INSTRUCTIONS SPÉCIFIQUES:
${toolName === 'getOrganigramme' ? `
Tu as reçu un ORGANIGRAMME hiérarchique. Structure exacte des colonnes:
- **Cod_Entite**: Code unique de l'entité
- **Lib_Entite**: Nom/Libellé de l'entité
- **Parent**: Code de l'entité parente (Attachement_Hierarchique)
- Niveau: Niveau hiérarchique (0 = racine)
- Typ_Entite: Type d'entité
- Responsable: Matricule du responsable

POUR TROUVER L'ENTITÉ PARENTE (attachement):
1. Si la question est "mon entité", trouve d'abord l'objet avec Cod_Entite = "${richUserData.Cod_Entite || currentUser.Cod_Entite}"
2. Lis le champ **"Parent"** de cet objet
3. Cherche l'objet où Cod_Entite = [valeur du Parent]
4. Retourne le **Lib_Entite** de cet objet parent

Si Parent est vide/null, dis que c'est une entité de niveau racine (Direction Générale).

EXEMPLE:
Question: "Quelle est l'entité d'attachement de mon entité ?"
→ Cherche {Cod_Entite: "${richUserData.Cod_Entite || currentUser.Cod_Entite}"}
→ Parent = "DIR_COM"
→ Cherche {Cod_Entite: "DIR_COM"}
→ Réponse: "Votre entité dépend de **[Lib_Entite trouvé]**"
` : `
Utilise les données JSON ci-dessus pour répondre PRÉCISÉMENT à la question.
`}

RÈGLES:
- NE DIS JAMAIS "J'ai consulté", "D'après", "Selon les données". Donne DIRECTEMENT la réponse.
- Si introuvable: "Je ne trouve pas cette information dans l'organigramme."
- Format: Markdown (**gras**)
- MAX 2 phrases
`;
                                        // Re-Call AI with new context
                                        // We reuse the existing configuration 'AgentConfig'
                                        if (AgentConfig) {
                                            try {
                                                const newHistory = [...conversationHistory, { role: 'user', content: question }];
                                                let newPayload: any = {};
                                                let newUrl = AgentConfig.aiUrl.replace("{MODEL}", AgentConfig.Modele);

                                                if (providerAgent === "GEMINI") {
                                                    newUrl += `?key=${AgentConfig.ApiKey}`;
                                                    const contents = newHistory.map(msg => ({
                                                        role: msg.role === 'user' ? 'user' : 'model',
                                                        parts: [{ text: msg.content }]
                                                    }));
                                                    // Add Tool Context
                                                    contents.push({ role: 'user', parts: [{ text: followUpSystem }] });
                                                    newPayload = { contents };
                                                } else if (providerAgent === "OLLAMA") {
                                                    newPayload = {
                                                        model: AgentConfig.Modele,
                                                        prompt: `${fullSystemPrompt}\n${followUpSystem}\nQuestion: ${question}`, // Simplified for Ollama
                                                        stream: false
                                                    };
                                                } else {
                                                    // OpenAI
                                                    const messages = [
                                                        { role: "system", content: fullSystemPrompt },
                                                        ...newHistory,
                                                        { role: "system", content: followUpSystem }
                                                    ];
                                                    newPayload = { model: AgentConfig.Modele, messages };
                                                }

                                                console.log("[AI] Re-Act Loop Call...");
                                                const followupRes = await axios.post(newUrl, newPayload, {
                                                    headers: agentHeaders,
                                                    timeout: 30000 // 30 second timeout
                                                });

                                                let newAnswer = "";
                                                if (providerAgent === "GEMINI") newAnswer = followupRes.data.candidates?.[0]?.content?.parts?.[0]?.text;
                                                else if (providerAgent === "OLLAMA") newAnswer = followupRes.data.response;
                                                else newAnswer = followupRes.data.choices?.[0]?.message?.content;

                                                if (newAnswer) {
                                                    answer = newAnswer;
                                                    console.log("[AI] Re-Act Answer generated.");
                                                } else {
                                                    console.warn("[AI] Re-Act returned empty answer");
                                                    answer = `Voici les données de l'organigramme (analyse automatique échouée) :`;
                                                }
                                            } catch (reActErr: any) {
                                                console.error("[AI] Re-Act Loop Failed:", reActErr.message || reActErr);
                                                // Fallback: Show data table without AI interpretation
                                                answer = `Voici les informations disponibles :`;
                                                answer = `Voici les informations demandées (Analyse auto échouée) :`;
                                            }
                                        }
                                        // -------------------------------------------------------------

                                        // SPECIAL HANDLING FOR LEAVE BALANCE (Legacy/Helper) - Append if not already in answer
                                        if (toolName === 'get_conge_droits' && apiData && apiData.data && apiData.data.length > 0) {
                                            // Context is usually handled by LLM now, but we keep specific logic if needed
                                        }

                                        if (apiData && apiData.data && Array.isArray(apiData.data)) {
                                            apiData = apiData.data;
                                        } else if (apiData && apiData.data) {
                                            apiData = [apiData.data];
                                        }
                                    }
                                } // Close if (filteredData && Array.isArray(filteredData)...)
                            } // Close else (Success block)
                        } catch (toolExecErr: any) {
                            console.error(`[AI] Tool ${toolName} execution failed:`, toolExecErr);
                            answer = `Erreur lors de l'exécution de l'outil : ${toolExecErr.message}`;
                            docs = [];
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
                    sources: [...new Set(docs.map((d: any) => d.Source))], // Return unique sources
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
