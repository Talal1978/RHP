/* ============================================================================
   RHP - Assistant IA : multi-modeles (table Ai_Agent)
   ----------------------------------------------------------------------------
   Fait passer la configuration de l'assistant IA (ecran desktop
   AI_KnowledgeBase) d'une logique "un seul modele enregistre" a une logique
   "plusieurs modeles enregistres, dont UN modele par defaut par portee" :

     - Ai_Agent.Id         : cle technique (identite), utilisee par l'ecran
                             pour suivre le modele charge dans le formulaire ;
     - Ai_Agent.Par_Defaut : 'true'/'false' — un seul modele par defaut par
                             portee (index filtre unique ; portee = global
                             id_Societe=-1 ou une societe).

   Resolution du modele utilise par les consommateurs (assistant IA du
   portail rhpBE\controlers\ai_assistant.ts, client desktop Ai_ChatClient,
   script Scan_Piece_Identite.py) — requete inchangee, seul l'ordre evolue :

     SELECT TOP 1 ... FROM Ai_Agent
     WHERE ISNULL(NULLIF(id_Societe, -1), @idSoc) = @idSoc
     ORDER BY CASE WHEN ISNULL(Par_Defaut,'false')='true' THEN 0 ELSE 1 END,
              CASE WHEN id_Societe = @idSoc THEN 0 ELSE 1 END

   => le defaut de la societe prime sur le defaut global ; a defaut de
   modele coche, une configuration propre a la societe prime sur la globale
   (comportement de repli equivalent a l'ancienne logique mono-ligne).

   Idempotent : re-executable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

/* ---- 1. Cle technique ---------------------------------------------------- */
IF COL_LENGTH('dbo.Ai_Agent', 'Id') IS NULL
    ALTER TABLE dbo.Ai_Agent
        ADD Id int IDENTITY(1,1);

IF NOT EXISTS (SELECT 1 FROM sys.key_constraints
               WHERE parent_object_id = OBJECT_ID('dbo.Ai_Agent')
                 AND type = 'PK')
    ALTER TABLE dbo.Ai_Agent
        ADD CONSTRAINT PK_Ai_Agent PRIMARY KEY (Id);

/* ---- 2. Indicateur de modele par defaut (colonne) ------------------------ */
IF COL_LENGTH('dbo.Ai_Agent', 'Par_Defaut') IS NULL
    ALTER TABLE dbo.Ai_Agent
        ADD Par_Defaut nvarchar(5) NOT NULL
            CONSTRAINT DF_Ai_Agent_Par_Defaut DEFAULT ('false') WITH VALUES;

COMMIT TRANSACTION;
GO

/* ---- 3. Seed : les modeles existants deviennent le defaut de leur portee - */
/* (lot separe : la colonne Par_Defaut doit exister a la compilation)         */
SET XACT_ABORT ON;
BEGIN TRANSACTION;

UPDATE dbo.Ai_Agent
SET Par_Defaut = 'true'
WHERE Id IN (SELECT MIN(Id)
             FROM dbo.Ai_Agent
             GROUP BY id_Societe
             HAVING MAX(CASE WHEN ISNULL(Par_Defaut, 'false') = 'true'
                             THEN 1 ELSE 0 END) = 0);

COMMIT TRANSACTION;
GO

/* ---- 4. Un seul modele par defaut par portee (index filtre unique) ------- */
/* (index filtre -> QUOTED_IDENTIFIER / ANSI_NULLS obligatoires)              */
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM sys.indexes
               WHERE name = 'UX_Ai_Agent_Par_Defaut'
                 AND object_id = OBJECT_ID('dbo.Ai_Agent'))
    CREATE UNIQUE NONCLUSTERED INDEX UX_Ai_Agent_Par_Defaut
        ON dbo.Ai_Agent (id_Societe, Par_Defaut)
        WHERE Par_Defaut = 'true';

COMMIT TRANSACTION;
GO

/* ---- Verification -------------------------------------------------------- */
SELECT 'Ai_Agent.Id' AS Element,
       CASE WHEN COL_LENGTH('dbo.Ai_Agent','Id') IS NULL THEN 'KO' ELSE 'OK' END AS Etat
UNION ALL SELECT 'Ai_Agent.Par_Defaut',
       CASE WHEN COL_LENGTH('dbo.Ai_Agent','Par_Defaut') IS NULL THEN 'KO' ELSE 'OK' END
UNION ALL SELECT 'UX_Ai_Agent_Par_Defaut',
       CASE WHEN EXISTS (SELECT 1 FROM sys.indexes
                         WHERE name='UX_Ai_Agent_Par_Defaut'
                           AND object_id=OBJECT_ID('dbo.Ai_Agent')) THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Au moins un defaut par portee',
       CASE WHEN EXISTS (SELECT 1 FROM dbo.Ai_Agent a
                         WHERE NOT EXISTS (SELECT 1 FROM dbo.Ai_Agent d
                                           WHERE d.id_Societe = a.id_Societe
                                             AND d.Par_Defaut = 'true')) THEN 'KO' ELSE 'OK' END;
GO
