/* ============================================================================
   RHP - Module SP_ : deploiement de la page portail "Télétravail"
   ----------------------------------------------------------------------------
   GENERE PAR le skill "rhp-portal-page-deployer" - NE PAS EDITER A LA MAIN.
   Demande        : EXEMPLE-02               Environnement : development
   Genere par     : rhp-portal-page-deployer v1.0   Pour   : SCRIPT
   Date generation: 2026-08-11
   Description    : Demande de télétravail : periode, jours concernes et
                    soumission au workflow.
   ----------------------------------------------------------------------------
   Operation      : create
   Mode           : @DryRun = 1 => ROLLBACK final (aucun changement persiste)
                    @DryRun = 0 => COMMIT final
   Idempotent     : oui - re-executable sans erreur (tous les ordres gardes).
   Reversible     : oui - voir rollback.sql.
   Cible          : SQL Server 2019 (base RHP). Une seule transaction.
   ============================================================================ */

SET XACT_ABORT ON;
SET NOCOUNT ON;

/* --------------------------------------------------------------------------
   0. Parametres du deploiement
   -------------------------------------------------------------------------- */
DECLARE @DryRun      bit           = 1;   -- 1 = dry-run, 0 = execution reelle
DECLARE @CP          nvarchar(30)  = 'TELETRAVAIL';
DECLARE @CDoc        nvarchar(10)  = 'TT';
DECLARE @Login       nvarchar(50)  = 'SCRIPT';
DECLARE @ChangeRef   nvarchar(50)  = 'EXEMPLE-02';
DECLARE @TableEnt    nvarchar(60)  = 'SP_TT_Ent';
DECLARE @NameEcran   nvarchar(60)  = 'SPP_TELETRAVAIL';

BEGIN TRANSACTION;
BEGIN TRY

/* --------------------------------------------------------------------------
   1. Preconditions bloquantes
   -------------------------------------------------------------------------- */
    -- 1.a Niveau de schema SP_ attendu : SP3
    IF OBJECT_ID('dbo.SP_Page', 'U') IS NULL
        RAISERROR('SP_ metadata absentes : executer 001_SP_Designer_Metadata.sql d''abord.', 16, 1);
    IF COL_LENGTH('dbo.SP_Page', 'Acces_Personnalise') IS NULL
        RAISERROR('Niveau SP2 requis : colonne SP_Page.Acces_Personnalise absente.', 16, 1);
    IF COL_LENGTH('dbo.SP_Page_Champ', 'estCritere') IS NULL
        RAISERROR('Niveau SP3 requis : colonne SP_Page_Champ.estCritere absente.', 16, 1);

    -- 1.b Regles de l'operation
    IF EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP) AND 0 = 0  -- update_if_exists=false
        RAISERROR('La page %s existe deja et update_if_exists=false : arret.', 16, 1, @CP);
    IF EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Document = @CDoc AND Cod_Page <> @CP)
        RAISERROR('Cod_Document %s deja utilise par une autre page : arret.', 16, 1, @CDoc);

    -- 1.c Objets references (section / profils / moteur workflow)
    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Rubriques
                   WHERE Nom_Controle = 'SP_Menu_Portail' AND Valeur = 'MesDemandes')
        RAISERROR('Section du menu portail inconnue : MesDemandes', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Profile WHERE Cod_Profile = '1')
        RAISERROR('Profil inexistant : 1', 16, 1);
    IF OBJECT_ID('dbo.Sys_Workflow_Signature', 'P') IS NULL
        RAISERROR('Workflow actif mais dbo.Sys_Workflow_Signature absent : arret.', 16, 1);

/* --------------------------------------------------------------------------
   2. Section du menu portail : existante ('MesDemandes') - rien a creer.
   -------------------------------------------------------------------------- */

/* --------------------------------------------------------------------------
   3. Metadonnees : page
   -------------------------------------------------------------------------- */
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = @CP)
    BEGIN
        INSERT INTO dbo.SP_Page (Cod_Page, Cod_Document, Libelle, Libelle_Court, Nom_Page,
            Menu_Parent, Rang, Icone, Statut_Page, Table_Ent, Typ_Document,
            Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Categories, GED_Obligatoire,
            Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter,
            Acces_Personnalise, Dat_Crea, Created_By)
        VALUES (@CP, @CDoc, N'Demande de télétravail', N'Télétravail', N'Télétravail',
            'MesDemandes', 95, 'HomeWork', 'BROUILLON', @TableEnt, @CDoc,
            'true', NULL, 'false', NULL, 'false',
            'true', 'true', 'false', 'false',
            'true', GETDATE(), @Login);
    END

/* --------------------------------------------------------------------------
   4. Metadonnees : collections filles (pattern officiel 002_...sql :
      suppression controlee - strictement limitee a Cod_Page = @CP - puis
      re-insertion deterministe)
   -------------------------------------------------------------------------- */
    DELETE FROM dbo.SP_Page_Table      WHERE Cod_Page = @CP;
    DELETE FROM dbo.SP_Page_Colonne    WHERE Cod_Page = @CP;
    DELETE FROM dbo.SP_Page_Champ      WHERE Cod_Page = @CP;
    DELETE FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP;
    DELETE FROM dbo.SP_Page_Droit      WHERE Cod_Page = @CP;

    -- 4.a Tables (ENT d'abord, Rang 0)
    INSERT INTO dbo.SP_Page_Table (Cod_Page, Cod_Table, Nom_Physique, Role_Table, Libelle, Rang,
        Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Dat_Crea, Created_By)
    VALUES
        (@CP, 'ENT',   'SP_TT_Ent',       'ENT', N'Entête',              0, 'false', 'false', 'false', 'false', NULL,           'CASCADE', GETDATE(), @Login),
        (@CP, 'JOURS', 'SP_TT_Det_JOURS', 'DET', N'Jours de télétravail', 1, 'true',  'true',  'true',  'false', 'Dat_Jour asc', 'CASCADE', GETDATE(), @Login);

    -- 4.b Colonnes physiques (Solde_Conge : champ SOURCE non persiste -> pas de colonne)
    INSERT INTO dbo.SP_Page_Colonne (Cod_Page, Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur,
        Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Technique, Rang, Dat_Crea, Created_By)
    VALUES
        (@CP, 'ENT',   'Matricule',   N'Matricule',        'nvarchar', 20,   NULL, NULL, 'false', NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP, 'ENT',   'Dat_Debut',   N'Date de début',    'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP, 'ENT',   'Dat_Fin',     N'Date de fin',      'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 3, GETDATE(), @Login),
        (@CP, 'ENT',   'Nb_Jours',    N'Nombre de jours',  'decimal',  NULL, 5,    1,    'true',  NULL, 'false', 'false', 'false', 4, GETDATE(), @Login),
        (@CP, 'ENT',   'Motif',       N'Motif',            'nvarchar', 300,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 5, GETDATE(), @Login),
        (@CP, 'JOURS', 'Dat_Jour',    N'Jour',             'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 1, GETDATE(), @Login),
        (@CP, 'JOURS', 'Nb',          N'Quotité',          'float',    NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2, GETDATE(), @Login),
        (@CP, 'JOURS', 'Commentaire', N'Commentaire',      'nvarchar', 200,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 3, GETDATE(), @Login);

    -- 4.c Champs UI
    INSERT INTO dbo.SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle,
        Rang, Largeur, Valeur_Defaut, Obligatoire, Etat, Rubrique, Num_Zoom, Source_Metier, Formule,
        Persiste, Format_Affichage, Decimales, Visible_Grille, Rang_Grille, Largeur_Colonne, Total_Grille,
        estCritere, Rang_Critere, Aide, Dat_Crea, Created_By)
    VALUES
        (@CP, 'Matricule',   'ENT', 'Matricule',   N'Matricule',       'ZOOM',   1, 3, 'GV_MATRICULE', 'true',  'S', NULL, 'MS067', NULL, NULL, 'false', NULL, NULL, 'true', 1, NULL, '', 'true', 1, N'Agent concerné (zoom MS067)', GETDATE(), @Login),
        (@CP, 'Dat_Debut',   'ENT', 'Dat_Debut',   N'Date de début',   'DATE',   2, 3, 'GV_NOW',       'true',  'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, 'true', 2, NULL, '', 'true', 2, NULL, GETDATE(), @Login),
        (@CP, 'Dat_Fin',     'ENT', 'Dat_Fin',     N'Date de fin',     'DATE',   3, 3, NULL,           'true',  'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, 'true', 3, NULL, '', 'false', NULL, NULL, GETDATE(), @Login),
        (@CP, 'Nb_Jours',    'ENT', 'Nb_Jours',    N'Nombre de jours', 'CALCULE', 4, 3, NULL,          'false', 'A', NULL, NULL,    NULL,
            '{"op":"SUM","table":"JOURS","colonne":"Nb"}', 'true', NULL, 1, 'true', 4, NULL, '', 'false', NULL, N'Somme des jours de télétravail saisis', GETDATE(), @Login),
        (@CP, 'Solde_Conge', 'ENT', 'Solde_Conge', N'Solde de congés', 'SOURCE', 5, 3, NULL,           'false', 'A', NULL, NULL,    'solde_conge',
            '{"source":"solde_conge","mapping":{"Matricule":{"ref":"Matricule"}}}', 'false', NULL, NULL, 'false', 5, NULL, '', 'false', NULL, N'Solde de congés de l''agent (source métier solde_conge)', GETDATE(), @Login),
        (@CP, 'Motif',       'ENT', 'Motif',       N'Motif',           'MEMO',   6, 6, NULL,           'false', 'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, 'true', 5, NULL, '', 'false', NULL, NULL, GETDATE(), @Login),
        (@CP, 'L_Dat_Jour',  'JOURS', 'Dat_Jour',  N'Jour',            'DATE',   1, NULL, NULL,        'true',  'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, 'true', 1, 12, '', 'false', NULL, NULL, GETDATE(), @Login),
        (@CP, 'L_Nb',        'JOURS', 'Nb',        N'Quotité',         'DEC',    2, NULL, NULL,        'true',  'S', NULL, NULL,    NULL, NULL, 'false', NULL, 1,    'true', 2, 6,  'SUM', 'false', NULL, N'1 = journée ; 0,5 = demi-journée', GETDATE(), @Login),
        (@CP, 'L_Commentaire', 'JOURS', 'Commentaire', N'Commentaire', 'TEXT',   3, NULL, NULL,        'false', 'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, 'true', 3, 30, '', 'false', NULL, NULL, GETDATE(), @Login);

    -- 4.d Validations
    INSERT INTO dbo.SP_Page_Validation (Cod_Page, Cod_Validation, Portee, Cod_Table, Cod_Champ,
        Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif, Dat_Crea, Created_By)
    VALUES
        (@CP, 'V01_MATRICULE', 'CHAMP',    'ENT',   'Matricule', 'REQUIRED', NULL, NULL,
            N'Le matricule est obligatoire.', 'B', 1, 'SAVE', 'true', GETDATE(), @Login),
        (@CP, 'V02_DATES',     'DOCUMENT', 'ENT',   NULL,        'EXPR',
            '{"expr":{"op":"GE","args":[{"ref":"Dat_Fin"},{"ref":"Dat_Debut"}]}}', NULL,
            N'La date de fin doit être postérieure ou égale à la date de début.', 'B', 2, 'SAVE', 'true', GETDATE(), @Login),
        (@CP, 'V03_NB_JOURS',  'DETAIL',   'JOURS', NULL,        'NB_LIGNES', '{"min":1}', NULL,
            N'Au moins un jour de télétravail est requis.', 'B', 3, 'SAVE', 'true', GETDATE(), @Login),
        (@CP, 'V04_QUOTITE',   'LIGNE',    'JOURS', 'L_Nb',      'BETWEEN', '{"min":0,"max":1}', NULL,
            N'Quotité inhabituelle (attendu : 0,5 ou 1).', 'W', 4, 'SAVE', 'true', GETDATE(), @Login);

    -- 4.e Droits par profil
    INSERT INTO dbo.SP_Page_Droit (Cod_Page, Cod_Profile, Consulter, Creer, Modifier, Supprimer,
        Valider, Imprimer, GED, Dat_Crea, Created_By)
    VALUES (@CP, '1', 'true', 'true', 'true', 'true', 'true', 'false', 'false', GETDATE(), @Login);

/* --------------------------------------------------------------------------
   5. Sources metier (catalogue partage : insertion si absente, jamais
      d'ecrasement). 'solde_conge' est deja seedee par 001_...sql.
   -------------------------------------------------------------------------- */
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'solde_conge')
    BEGIN
        INSERT INTO dbo.SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres,
            Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
        VALUES ('solde_conge', N'Solde de congé de l''agent', 'SQL',
                'select Solde_Conge from dbo.Sys_Rh_Conge(@id_Societe, convert(date, getdate())) where Matricule = @Matricule',
                '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true}]',
                'SCALAIRE', '', 'true', GETDATE(), @Login);
    END

/* --------------------------------------------------------------------------
   6. Tables metier - format exact Module_SP_DDL
      (creation gardee / migration non destructive : ALTER ADD uniquement)
   -------------------------------------------------------------------------- */
    IF OBJECT_ID('dbo.SP_TT_Ent', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_TT_Ent] (
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Statut] nvarchar(3) NULL CONSTRAINT [DF_SP_TT_Ent_Statut] DEFAULT (''),
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [RV] rowversion NOT NULL,
            [Matricule] nvarchar(20) NOT NULL CONSTRAINT [DF_SP_TT_Ent_Matricule] DEFAULT (''),
            [Dat_Debut] date NULL,
            [Dat_Fin] date NULL,
            [Nb_Jours] decimal(5,1) NULL,
            [Motif] nvarchar(300) NULL,
            CONSTRAINT [PK_SP_TT_Ent] PRIMARY KEY ([Num_Doc], [id_Societe])
        );
    END
    ELSE
    BEGIN
        -- Migration non destructive : ADD uniquement, jamais de DROP.
        IF COL_LENGTH('dbo.SP_TT_Ent', 'Matricule') IS NULL
            ALTER TABLE dbo.[SP_TT_Ent] ADD [Matricule] nvarchar(20) NOT NULL CONSTRAINT [DF_SP_TT_Ent_Matricule] DEFAULT ('');
        IF COL_LENGTH('dbo.SP_TT_Ent', 'Dat_Debut') IS NULL
            ALTER TABLE dbo.[SP_TT_Ent] ADD [Dat_Debut] date NULL;
        IF COL_LENGTH('dbo.SP_TT_Ent', 'Dat_Fin') IS NULL
            ALTER TABLE dbo.[SP_TT_Ent] ADD [Dat_Fin] date NULL;
        IF COL_LENGTH('dbo.SP_TT_Ent', 'Nb_Jours') IS NULL
            ALTER TABLE dbo.[SP_TT_Ent] ADD [Nb_Jours] decimal(5,1) NULL;
        IF COL_LENGTH('dbo.SP_TT_Ent', 'Motif') IS NULL
            ALTER TABLE dbo.[SP_TT_Ent] ADD [Motif] nvarchar(300) NULL;
    END

    IF OBJECT_ID('dbo.SP_TT_Det_JOURS', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.[SP_TT_Det_JOURS] (
            [RowId] int IDENTITY(1,1) NOT NULL,
            [Num_Doc] nvarchar(30) NOT NULL,
            [id_Societe] int NOT NULL,
            [Dat_Crea] datetime NULL,
            [Created_By] nvarchar(50) NULL,
            [Dat_Modif] datetime NULL,
            [Modified_By] nvarchar(50) NULL,
            [Dat_Jour] date NULL,
            [Nb] float NULL,
            [Commentaire] nvarchar(200) NULL,
            CONSTRAINT [PK_SP_TT_Det_JOURS] PRIMARY KEY ([RowId])
        );
    END
    ELSE
    BEGIN
        IF COL_LENGTH('dbo.SP_TT_Det_JOURS', 'Dat_Jour') IS NULL
            ALTER TABLE dbo.[SP_TT_Det_JOURS] ADD [Dat_Jour] date NULL;
        IF COL_LENGTH('dbo.SP_TT_Det_JOURS', 'Nb') IS NULL
            ALTER TABLE dbo.[SP_TT_Det_JOURS] ADD [Nb] float NULL;
        IF COL_LENGTH('dbo.SP_TT_Det_JOURS', 'Commentaire') IS NULL
            ALTER TABLE dbo.[SP_TT_Det_JOURS] ADD [Commentaire] nvarchar(200) NULL;
    END

    IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_SP_TT_Det_JOURS_Ent')
        ALTER TABLE dbo.[SP_TT_Det_JOURS] WITH NOCHECK ADD CONSTRAINT [FK_SP_TT_Det_JOURS_Ent]
            FOREIGN KEY ([Num_Doc], [id_Societe]) REFERENCES dbo.[SP_TT_Ent] ([Num_Doc], [id_Societe]) ON DELETE CASCADE;

    -- Journal DDL
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_DDL_Log WHERE Cod_Page = @CP AND Type_Operation = 'CREATE')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES (@CP, 'CREATE', 'CREATE TABLE SP_TT_Ent / SP_TT_Det_JOURS + FK (skill rhp-portal-page-deployer)', 'true',
                N'EXEMPLE-02 - deploiement initial TELETRAVAIL', @Login, GETDATE());

/* --------------------------------------------------------------------------
   7. Publication (controles de coherence - miroir SP_Page_Designer.Publier)
   -------------------------------------------------------------------------- */
    -- 7.1 Tables et colonnes physiques
    IF OBJECT_ID('dbo.SP_TT_Ent', 'U') IS NULL
        RAISERROR('Table physique inexistante : SP_TT_Ent', 16, 1);
    IF OBJECT_ID('dbo.SP_TT_Det_JOURS', 'U') IS NULL
        RAISERROR('Table physique inexistante : SP_TT_Det_JOURS', 16, 1);
    IF EXISTS (SELECT v.Nom FROM (VALUES ('Matricule'), ('Dat_Debut'), ('Dat_Fin'), ('Nb_Jours'), ('Motif')) v(Nom)
               WHERE COL_LENGTH('dbo.SP_TT_Ent', v.Nom) IS NULL)
        RAISERROR('Colonnes manquantes sur SP_TT_Ent', 16, 1);
    IF EXISTS (SELECT v.Nom FROM (VALUES ('Dat_Jour'), ('Nb'), ('Commentaire')) v(Nom)
               WHERE COL_LENGTH('dbo.SP_TT_Det_JOURS', v.Nom) IS NULL)
        RAISERROR('Colonnes manquantes sur SP_TT_Det_JOURS', 16, 1);
    -- 7.2 Zooms / rubriques / sources references
    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Zoom WHERE Num_Zoom = 'MS067')
        RAISERROR('Zoom inexistant : MS067', 16, 1);
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Source WHERE Cod_Source = 'solde_conge' AND ISNULL(Actif, 'true') = 'true')
        RAISERROR('Source metier inexistante ou inactive : solde_conge', 16, 1);
    -- 7.3 Cycles entre champs calcules : controle effectue a la generation (validate_input.py).
    -- 7.4 Habilitations presentes (Acces_Personnalise = 'true')
    IF NOT EXISTS (SELECT 1 FROM dbo.SP_Page_Droit WHERE Cod_Page = @CP AND ISNULL(Consulter, 'false') = 'true')
        RAISERROR('Aucun profil n''a le droit Consulter : la page serait invisible pour tous.', 16, 1);
    -- 7.5 Menu_Parent renseigne : garanti NOT NULL par l''insertion (valeur constante 'MesDemandes').
    -- 7.6 Workflow actif => Cod_Document renseigne : garanti NOT NULL ('TT').

    UPDATE dbo.SP_Page
    SET Statut_Page = 'PUBLIE', Dat_Publication = GETDATE(), DDL_Genere = 'true',
        Version_Page = ISNULL(Version_Page, 1) + 1, Dat_Modif = GETDATE(), Modified_By = @Login
    WHERE Cod_Page = @CP AND Statut_Page <> 'PUBLIE';

    -- Enregistrement de l'ecran portail (liaison GED : Name_Ecran + Value_Index)
    IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = @NameEcran)
        INSERT INTO dbo.Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
        VALUES (@NameEcran, @TableEnt, 'Num_Doc', '', 'Num_Doc', 'false', 'false', 'true', GETDATE(), @Login);
    ELSE
        UPDATE dbo.Controle_Def_Ecran SET Table_Ref = @TableEnt, PJ = 'false' WHERE Name_Ecran = @NameEcran;

    -- Declaration du type de document au moteur de workflow existant
    -- (le circuit de signataires se parametre ensuite via l'ecran Workflow_Signatures)
    IF NOT EXISTS (SELECT 1 FROM dbo.Param_Workflow_Typ_Document WHERE Typ_Document = @CDoc)
        INSERT INTO dbo.Param_Workflow_Typ_Document
            (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
        VALUES (@CDoc, N'Demande de télétravail', @TableEnt, 'Num_Doc', 'false', @NameEcran, 'Num_Doc', 'Created_By', -1);
    ELSE
        UPDATE dbo.Param_Workflow_Typ_Document
        SET Intitule = N'Demande de télétravail', Table_Ref = @TableEnt, Name_Ecran = @NameEcran
        WHERE Typ_Document = @CDoc;

/* --------------------------------------------------------------------------
   8. Verification finale + issue de transaction
   -------------------------------------------------------------------------- */
    SELECT Cod_Page, Cod_Document, Statut_Page, Menu_Parent, Rang, Version_Page
    FROM dbo.SP_Page WHERE Cod_Page = @CP;

    SELECT 'SP_Page_Table' AS Objet, COUNT(*) AS Nb FROM dbo.SP_Page_Table WHERE Cod_Page = @CP
    UNION ALL SELECT 'SP_Page_Colonne', COUNT(*) FROM dbo.SP_Page_Colonne WHERE Cod_Page = @CP
    UNION ALL SELECT 'SP_Page_Champ', COUNT(*) FROM dbo.SP_Page_Champ WHERE Cod_Page = @CP
    UNION ALL SELECT 'SP_Page_Validation', COUNT(*) FROM dbo.SP_Page_Validation WHERE Cod_Page = @CP
    UNION ALL SELECT 'SP_Page_Droit', COUNT(*) FROM dbo.SP_Page_Droit WHERE Cod_Page = @CP;

    IF @DryRun = 1
    BEGIN
        PRINT '*** DRY-RUN : ROLLBACK - aucune modification persistee. ***';
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        COMMIT TRANSACTION;
        PRINT 'Deploiement de ' + @CP + ' termine (EXEMPLE-02).';
    END
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    DECLARE @Msg nvarchar(1000) = LEFT(ERROR_MESSAGE(), 1000);
    IF OBJECT_ID('dbo.SP_Page_DDL_Log', 'U') IS NOT NULL
       AND EXISTS (SELECT 1 FROM dbo.SP_Page WHERE Cod_Page = 'TELETRAVAIL')
        INSERT INTO dbo.SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
        VALUES ('TELETRAVAIL', 'MIGRATE', '', 'false', @Msg, 'SCRIPT', GETDATE());
    PRINT 'Echec deploiement TELETRAVAIL : ' + @Msg;
    ;THROW;
END CATCH;
GO
