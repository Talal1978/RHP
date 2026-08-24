/* ============================================================================
   RHP - Assistant IA : catalogue des modeles par fournisseur (Ai_LLM_Modeles)
   ----------------------------------------------------------------------------
   Liste des modeles les plus populaires proposes dans l'ecran desktop
   AI_Modeles (combo 'Modele' alimentee par Ai_LLM_Modeles, une ligne par
   fournisseur, modeles separes par '|') — volontairement limitee aux modeles
   phares, sans exhaustivite (etat au 17/08/2026) :

     - KIMI (Moonshot) : kimi-k3, kimi-k2.7-code, kimi-k2.6 ; les vision-preview
       moonshot-v1 sont conserves car encore utilises par des configurations en
       place (retrait annonce le 31/08/2026) ;
     - OpenAI : GPT-5.6, GPT-5, GPT-4o ;
     - Anthropic : Claude Opus 5, Sonnet 5, Haiku 4.5 ;
     - Gemini : gemini-3.7-flash, gemini-3.1-pro-preview, gemini-2.5-pro/flash ;
     - DeepSeek : deepseek-v4-pro / deepseek-v4-flash ;
     - Mistral : alias -latest (Medium, Large, Small, Codestral) ;
     - Groq : GPT-OSS 120B / 20B ;
     - Perplexity : Sonar, Sonar Pro, Sonar Deep Research ;
     - OpenRouter / TogetherAI / HuggingFace : modeles phares heberges —
       HuggingFace bascule sur le routeur OpenAI-compatible
       router.huggingface.co (api-inference.huggingface.co retiree) ;
     - AzureOpenAI / Ollama : noms courants.

   Idempotent : UPDATE si le fournisseur existe, INSERT sinon.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

DECLARE @catalogue TABLE (Provider nvarchar(1000), Modele nvarchar(max), aiUrl nvarchar(max));

INSERT INTO @catalogue (Provider, Modele, aiUrl) VALUES
 (N'Anthropic',   N'claude-opus-5|claude-sonnet-5|claude-haiku-4-5', N'https://api.anthropic.com/v1/messages'),
 (N'AzureOpenAI', N'gpt-5|gpt-4.1|gpt-4o|gpt-4o-mini', N'https://{RESOURCE}.openai.azure.com/openai/deployments/{DEPLOYMENT}/chat/completions'),
 (N'DeepSeek',    N'deepseek-v4-pro|deepseek-v4-flash', N'https://api.deepseek.com/chat/completions'),
 (N'Gemini',      N'gemini-3.7-flash|gemini-3.1-pro-preview|gemini-2.5-pro|gemini-2.5-flash', N'https://generativelanguage.googleapis.com/v1beta/models/{MODEL}:generateContent'),
 (N'Groq',        N'openai/gpt-oss-120b|openai/gpt-oss-20b', N'https://api.groq.com/openai/v1/chat/completions'),
 (N'HuggingFace', N'meta-llama/Llama-3.3-70B-Instruct|deepseek-ai/DeepSeek-R1|Qwen/Qwen3-32B', N'https://router.huggingface.co/v1/chat/completions'),
 (N'KIMI',        N'kimi-k3|kimi-k2.7-code|kimi-k2.6|moonshot-v1-32k-vision-preview|moonshot-v1-8k-vision-preview', N'https://api.moonshot.ai/v1/chat/completions'),
 (N'Mistral',     N'mistral-medium-latest|mistral-large-latest|mistral-small-latest|codestral-latest', N'https://api.mistral.ai/v1/chat/completions'),
 (N'Ollama',      N'llama3.3|llama3.2|qwen3|mistral|deepseek-r1|gemma3', N'http://localhost:11434/api/chat'),
 (N'OpenAI',      N'gpt-5.6|gpt-5|gpt-4o|gpt-4o-mini', N'https://api.openai.com/v1/chat/completions'),
 (N'OpenRouter',  N'openai/gpt-5|anthropic/claude-sonnet-5|google/gemini-3.7-flash|moonshotai/kimi-k3', N'https://openrouter.ai/api/v1/chat/completions'),
 (N'Perplexity',  N'sonar|sonar-pro|sonar-deep-research', N'https://api.perplexity.ai/chat/completions'),
 (N'TogetherAI',  N'meta-llama/Llama-4-Maverick-17B-128E-Instruct-FP8|meta-llama/Llama-3.3-70B-Instruct-Turbo|deepseek-ai/DeepSeek-V3.1', N'https://api.together.xyz/v1/chat/completions');

UPDATE m
SET m.Modele = c.Modele,
    m.aiUrl = c.aiUrl
FROM dbo.Ai_LLM_Modeles m
JOIN @catalogue c ON c.Provider = m.Provider;

INSERT INTO dbo.Ai_LLM_Modeles (Provider, Modele, aiUrl)
SELECT c.Provider, c.Modele, c.aiUrl
FROM @catalogue c
WHERE NOT EXISTS (SELECT 1 FROM dbo.Ai_LLM_Modeles m WHERE m.Provider = c.Provider);

COMMIT TRANSACTION;
GO

/* ---- Verification --------------------------------------------------------- */
SELECT Provider, Modele, aiUrl FROM dbo.Ai_LLM_Modeles ORDER BY Provider;
GO
