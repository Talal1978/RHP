/* ============================================================================
   RHP - Assistant IA : index de chargement de AI_KnowledgeBase
   ----------------------------------------------------------------------------
   Probleme : l'ecran desktop AI_KnowledgeBase (liste des sources de la base
   de connaissances) executait a l'ouverture :

       SELECT Source, COUNT(*), MAX(LastModified)
       FROM AI_KnowledgeBase
       WHERE ISNULL(NULLIF(id_Societe, -1), @soc) = @soc
       GROUP BY Source ORDER BY Source

   Le predicat ISNULL(NULLIF(...)) n'est pas SARGable : analyse complete de la
   table (toutes societes confondues), sans aucun index non cluster (seule la
   PK existait). Or les lignes sont tres larges (TextChunk nvarchar(max) en
   ligne, Embedding nvarchar(max) en LOB) : le cout croit lineairement avec le
   nombre de chunks et le chargement de l'ecran se degradait fortement.

   Correctif (deux volets, ce script = volet base) :
     1. Index couvrant IX_AI_KnowledgeBase_Societe : cle id_Societe, colonnes
        incluses Source + LastModified (Source nvarchar(510) depasse la limite
        de 900 octets d'une cle d'index, d'ou le INCLUDE). L'agregation devient
        un seek sur la societe dans un index etroit (mesure : 1607 -> 59
        lectures logiques, ~183 ms -> ~17 ms sur 5,5k chunks).
     2. Cote ecran (AI_KnowledgeBase.vb) : predicat reecrit en
        (id_Societe = @soc OR id_Societe = -1 OR id_Societe IS NULL) —
        equivalent strict de ISNULL(NULLIF(...)) y compris pour les NULL —
        et chargement asynchrone.

   L'index profite aussi a l'ingestion (LoadExistingFilesIndex,
   DeleteExistingChunks) et a la recherche RAG du portail (meme filtre
   societe) des lors que leurs predicats suivent la meme forme SARGable.

   Idempotent : creation uniquement si l'index est absent.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM sys.indexes
               WHERE name = 'IX_AI_KnowledgeBase_Societe'
                 AND object_id = OBJECT_ID('dbo.AI_KnowledgeBase'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_AI_KnowledgeBase_Societe
    ON dbo.AI_KnowledgeBase (id_Societe)
    INCLUDE (Source, LastModified);
END

COMMIT TRANSACTION;
GO

/* ---- Verification --------------------------------------------------------- */
SELECT i.name AS IndexName, i.type_desc,
       c.name AS Colonne, ic.is_included_column AS EstIncluse
FROM sys.indexes i
JOIN sys.index_columns ic ON ic.object_id = i.object_id AND ic.index_id = i.index_id
JOIN sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
WHERE i.object_id = OBJECT_ID('dbo.AI_KnowledgeBase')
ORDER BY i.name, ic.key_ordinal, ic.index_column_id;
GO
