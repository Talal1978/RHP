/* ============================================================================
   RHP - Module SP_ : renommage des tables de métadonnées SP_Page* en
   Controle_Designer*
   ----------------------------------------------------------------------------
   Les tables de métadonnées du Designer de pages portail sont préfixées
   Controle_Designer_ afin de les distinguer des tables MÉTIER générées par le
   module (SP_<CodDocument>_Ent / SP_<CodDocument>_Det_<CodTable>) :

       SP_Page              -> Controle_Designer
       SP_Page_Champ        -> Controle_Designer_Champ
       SP_Page_Colonne      -> Controle_Designer_Colonne
       SP_Page_DDL_Log      -> Controle_Designer_DDL_Log
       SP_Page_Droit        -> Controle_Designer_Droit
       SP_Page_Source       -> Controle_Designer_Source
       SP_Page_Table        -> Controle_Designer_Table
       SP_Page_Validation   -> Controle_Designer_Validation

   Ce script migre les bases EXISTANTES (001 déjà exécuté avec les anciens
   noms) ; sur une base fraîche (001 version Controle_Designer*), il est sans
   effet. Idempotent : ré-exécutable sans erreur.

   Notes :
     - sp_rename sur une table conserve données, index, contraintes et FK
       (les contraintes gardent leur nom historique PK_SP_Page* / DF_SP_Page_* :
       renommage non requis, aucun impact fonctionnel).
     - Alignement du référentiel écran Desktop : Controle_Def_Ecran.Table_Ref
       de l'écran SP_Page_Designer.
     - Après exécution, vérifier les requêtes stockées éventuelles
       (Param_Query, vues, procédures) référençant les anciens noms.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF OBJECT_ID('dbo.SP_Page', 'U') IS NOT NULL AND OBJECT_ID('dbo.Controle_Designer', 'U') IS NULL
    EXEC sp_rename 'dbo.SP_Page', 'Controle_Designer';
GO
IF OBJECT_ID('dbo.SP_Page_Champ', 'U') IS NOT NULL AND OBJECT_ID('dbo.Controle_Designer_Champ', 'U') IS NULL
    EXEC sp_rename 'dbo.SP_Page_Champ', 'Controle_Designer_Champ';
GO
IF OBJECT_ID('dbo.SP_Page_Colonne', 'U') IS NOT NULL AND OBJECT_ID('dbo.Controle_Designer_Colonne', 'U') IS NULL
    EXEC sp_rename 'dbo.SP_Page_Colonne', 'Controle_Designer_Colonne';
GO
IF OBJECT_ID('dbo.SP_Page_DDL_Log', 'U') IS NOT NULL AND OBJECT_ID('dbo.Controle_Designer_DDL_Log', 'U') IS NULL
    EXEC sp_rename 'dbo.SP_Page_DDL_Log', 'Controle_Designer_DDL_Log';
GO
IF OBJECT_ID('dbo.SP_Page_Droit', 'U') IS NOT NULL AND OBJECT_ID('dbo.Controle_Designer_Droit', 'U') IS NULL
    EXEC sp_rename 'dbo.SP_Page_Droit', 'Controle_Designer_Droit';
GO
IF OBJECT_ID('dbo.SP_Page_Source', 'U') IS NOT NULL AND OBJECT_ID('dbo.Controle_Designer_Source', 'U') IS NULL
    EXEC sp_rename 'dbo.SP_Page_Source', 'Controle_Designer_Source';
GO
IF OBJECT_ID('dbo.SP_Page_Table', 'U') IS NOT NULL AND OBJECT_ID('dbo.Controle_Designer_Table', 'U') IS NULL
    EXEC sp_rename 'dbo.SP_Page_Table', 'Controle_Designer_Table';
GO
IF OBJECT_ID('dbo.SP_Page_Validation', 'U') IS NOT NULL AND OBJECT_ID('dbo.Controle_Designer_Validation', 'U') IS NULL
    EXEC sp_rename 'dbo.SP_Page_Validation', 'Controle_Designer_Validation';
GO

/* Anomalie : ancienne ET nouvelle table présentes (renommage partiel)         */
IF OBJECT_ID('dbo.SP_Page', 'U') IS NOT NULL AND OBJECT_ID('dbo.Controle_Designer', 'U') IS NOT NULL
    RAISERROR('SP_Page et Controle_Designer coexistent : renommage partiel, intervention manuelle requise.', 16, 1);
GO

/* Référentiel écran Desktop : table de référence de l'écran SP_Page_Designer  */
IF OBJECT_ID('dbo.Controle_Def_Ecran', 'U') IS NOT NULL
    UPDATE dbo.Controle_Def_Ecran
    SET Table_Ref = 'Controle_Designer'
    WHERE Name_Ecran = 'SP_Page_Designer' AND Table_Ref = 'SP_Page';
GO

COMMIT TRANSACTION;
GO

/* Contrôle final : les 8 tables doivent exister sous leur nouveau nom        */
SELECT t.name AS Table_Metadonnee
FROM (VALUES ('Controle_Designer'), ('Controle_Designer_Champ'), ('Controle_Designer_Colonne'),
             ('Controle_Designer_DDL_Log'), ('Controle_Designer_Droit'), ('Controle_Designer_Source'),
             ('Controle_Designer_Table'), ('Controle_Designer_Validation')) AS t(name)
WHERE OBJECT_ID('dbo.' + t.name, 'U') IS NULL;
-- Aucune ligne retournée = migration OK ; sinon la table listée est manquante.
GO
