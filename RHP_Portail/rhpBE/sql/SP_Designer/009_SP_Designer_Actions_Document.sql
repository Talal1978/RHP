/* ============================================================================
   RHP - Module SP_ : actions « Dupliquer » / « Supprimer » d'un document
   ----------------------------------------------------------------------------
   Deux options de page (onglet « Conception de la page » du Designer) pilotant
   les boutons Dupliquer / Supprimer du portail (icônes par ligne de la page
   liste SPPL_<Cod_Page> + entrées du menu flottant de la page document) :

     Controle_Designer.Act_Dupliquer  ('true'/'false', défaut 'false') :
       duplication d'un document en une NOUVELLE pièce à l'état brouillon
       (nouveau numéro, entête + lignes de détail physiques copiés, statut
       réinitialisé, audit neuf) — endpoint sp_duplicate_document, droit Creer.
       Opt-in : une nouvelle action n'apparaît sur aucune page existante tant
       qu'elle n'est pas cochée dans le Designer.

     Controle_Designer.Act_Supprimer  ('true'/'false', défaut 'true') :
       suppression d'un document — endpoint sp_delete_document, droit Supprimer.
       Opt-out : 'true' par défaut pour préserver le comportement actuel
       (le bouton Supprimer existait déjà, piloté par la seule habilitation) ;
       décocher la case retire la suppression de la page (liste + document).

   Règle métier serveur associée (supprimerDocument) : une pièce dont le
   statut a ÉVOLUÉ (Statut non vide et différent de 'NSS' : soumise en
   signature, signée, rejetée, validée...) n'est JAMAIS supprimable —
   seuls les brouillons le sont. Cette règle prime sur Figer_Statuts, qu'elle
   couvre intégralement (tous les statuts figés sont non vides).

   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF COL_LENGTH('dbo.Controle_Designer', 'Act_Dupliquer') IS NULL
    ALTER TABLE dbo.Controle_Designer
        ADD Act_Dupliquer nvarchar(5) NOT NULL
            CONSTRAINT DF_SP_Page_ActDupliquer DEFAULT ('false') WITH VALUES;

IF COL_LENGTH('dbo.Controle_Designer', 'Act_Supprimer') IS NULL
    ALTER TABLE dbo.Controle_Designer
        ADD Act_Supprimer nvarchar(5) NOT NULL
            CONSTRAINT DF_SP_Page_ActSupprimer DEFAULT ('true') WITH VALUES;

COMMIT TRANSACTION;
GO

SELECT 'Controle_Designer.Act_Dupliquer' AS Colonne,
       CASE WHEN COL_LENGTH('dbo.Controle_Designer','Act_Dupliquer') IS NULL THEN 'KO' ELSE 'OK' END AS Etat
UNION ALL SELECT 'Controle_Designer.Act_Supprimer',
       CASE WHEN COL_LENGTH('dbo.Controle_Designer','Act_Supprimer') IS NULL THEN 'KO' ELSE 'OK' END;
GO
