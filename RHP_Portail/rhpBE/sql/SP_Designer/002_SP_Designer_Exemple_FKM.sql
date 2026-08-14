/* ============================================================================
   RHP - Module SP_ : EXEMPLE de page dynamique "Note de frais kilométriques"
   ----------------------------------------------------------------------------
   Ce script reproduit exactement ce que le Designer (SP_Page_Designer) fait :
     1. insertion des métadonnées (SP_Page, _Table, _Colonne, _Champ,
        _Validation, _Droit) ;
     2. génération des tables métier SP_FKM_Ent / SP_FKM_Det_LIGNES
        (même format que Module_SP_DDL : colonnes techniques + audit + RV + FK) ;
     3. publication contrôlée (Statut_Page='PUBLIE', enregistrement de l'écran
        portail pour la GED, déclaration du type de document au workflow).
   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

DECLARE @CP NVARCHAR(30) = 'FRAIS_KM';

/* -------------------------------------------------------------------------- */
/* 1. Métadonnées                                                             */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM SP_Page WHERE Cod_Page = @CP)
BEGIN
    INSERT INTO SP_Page (Cod_Page, Cod_Document, Libelle, Libelle_Court, Nom_Page, Menu_Parent, Rang, Icone,
        Statut_Page, Table_Ent, Typ_Document, Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Obligatoire,
        Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter, DDL_Genere, Dat_Crea, Created_By)
    VALUES (@CP, 'FKM', 'Note de frais kilométriques', 'Frais KM', 'Frais kilométriques', 'MesDemandes', 90, 'Commute',
        'BROUILLON', 'SP_FKM_Ent', 'FKM', 'true', NULL, 'true', 'false',
        'true', 'true', 'false', 'false', 'true', GETDATE(), 'SCRIPT');
END

DELETE FROM SP_Page_Colonne WHERE Cod_Page = @CP;   -- FK-safe : colonnes avant tables
DELETE FROM SP_Page_Table WHERE Cod_Page = @CP;
INSERT INTO SP_Page_Table (Cod_Page, Cod_Table, Nom_Physique, Role_Table, Libelle, Rang, Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Dat_Crea, Created_By)
VALUES
    (@CP, 'ENT',    'SP_FKM_Ent',        'ENT', 'Entête',            0, 'false', 'false', 'false', 'false', NULL, 'CASCADE', GETDATE(), 'SCRIPT'),
    (@CP, 'LIGNES', 'SP_FKM_Det_LIGNES', 'DET', 'Trajets parcourus', 1, 'true',  'true',  'true',  'true',  NULL, 'CASCADE', GETDATE(), 'SCRIPT');

INSERT INTO SP_Page_Colonne (Cod_Page, Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur, Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Technique, Rang, Dat_Crea, Created_By)
VALUES
    (@CP, 'ENT',    'Matricule',   'Matricule',        'nvarchar', 20,   NULL, NULL, 'false', NULL, 'false', 'false', 'false', 1, GETDATE(), 'SCRIPT'),
    (@CP, 'ENT',    'Dat_Demande', 'Date de demande',  'date',     NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2, GETDATE(), 'SCRIPT'),
    (@CP, 'ENT',    'Commentaire', 'Commentaire',      'nvarchar', 300,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 3, GETDATE(), 'SCRIPT'),
    (@CP, 'ENT',    'Total',       'Total (calculé)',  'decimal',  NULL, 18,   2,    'true',  NULL, 'false', 'false', 'false', 4, GETDATE(), 'SCRIPT'),
    (@CP, 'LIGNES', 'Trajet',      'Trajet',           'nvarchar', 100,  NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 1, GETDATE(), 'SCRIPT'),
    (@CP, 'LIGNES', 'Km',          'Kilomètres',       'float',    NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 2, GETDATE(), 'SCRIPT'),
    (@CP, 'LIGNES', 'Tx',          'Taux / km',        'float',    NULL, NULL, NULL, 'true',  NULL, 'false', 'false', 'false', 3, GETDATE(), 'SCRIPT'),
    (@CP, 'LIGNES', 'Mnt',         'Montant (calculé)','decimal',  NULL, 18,   2,    'true',  NULL, 'false', 'false', 'false', 4, GETDATE(), 'SCRIPT');

DELETE FROM SP_Page_Champ WHERE Cod_Page = @CP;
INSERT INTO SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle, Rang, Largeur, Valeur_Defaut, Obligatoire, Etat,
    Rubrique, Num_Zoom, Source_Metier, Formule, Persiste, Format_Affichage, Decimales, Visible_Grille, Rang_Grille, Largeur_Colonne, Aide, Dat_Crea, Created_By)
VALUES
    (@CP, 'Matricule',   'ENT', 'Matricule',   'Matricule',       'ZOOM',    1, 3, 'GV_MATRICULE', 'true',  'S', NULL, 'MS067', NULL, NULL, 'false', NULL, NULL, 'true', 1, NULL, 'Choisir l''agent via le zoom MS067', GETDATE(), 'SCRIPT'),
    (@CP, 'Dat_Demande', 'ENT', 'Dat_Demande', 'Date de demande', 'DATE',    2, 3, 'GV_NOW',       'false', 'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, 'true', 2, NULL, NULL, GETDATE(), 'SCRIPT'),
    (@CP, 'Commentaire', 'ENT', 'Commentaire', 'Commentaire',     'MEMO',    3, 6, NULL,           'false', 'S', NULL, NULL,    NULL, NULL, 'false', NULL, NULL, 'true', 3, NULL, NULL, GETDATE(), 'SCRIPT'),
    (@CP, 'Total',       'ENT', 'Total',       'Total frais',     'CALCULE', 4, 3, NULL,           'false', 'A', NULL, NULL,    NULL,
        '{"op":"SUM","table":"LIGNES","colonne":"Mnt"}', 'true', 'MNT', 2, 'true', 4, NULL, 'Somme des montants des trajets', GETDATE(), 'SCRIPT'),
    (@CP, 'L_Trajet', 'LIGNES', 'Trajet', 'Trajet',          'TEXT',    1, NULL, NULL, 'false', 'S', NULL, NULL, NULL, NULL, 'false', NULL, NULL, 'true', 1, 20, NULL, GETDATE(), 'SCRIPT'),
    (@CP, 'L_Km',     'LIGNES', 'Km',     'Km',            'DEC',     2, NULL, NULL, 'false', 'S', NULL, NULL, NULL, NULL, 'false', NULL, 2,    'true', 2, 5,  NULL, GETDATE(), 'SCRIPT'),
    (@CP, 'L_Tx',     'LIGNES', 'Tx',     'Taux / km',     'DEC',     3, NULL, NULL, 'false', 'S', NULL, NULL, NULL, NULL, 'false', NULL, 2,    'true', 3, 5,  NULL, GETDATE(), 'SCRIPT'),
    (@CP, 'L_Mnt',    'LIGNES', 'Mnt',    'Montant',       'CALCULE', 4, NULL, NULL, 'false', 'A', NULL, NULL, NULL,
        '{"op":"ROUND","args":[{"op":"MUL","args":[{"ref":"Km"},{"ref":"Tx"}]},{"const":2}]}', 'true', NULL, 2, 'true', 4, 8, 'Montant = Km x Taux', GETDATE(), 'SCRIPT'),
    -- Pied de grille : champ calculé rattaché au détail SANS colonne physique
    -- (non persisté) -> affiché sous la grille, évalué au niveau document.
    (@CP, 'Pied_Mnt', 'LIGNES', '',   'Total des trajets', 'CALCULE', 5, NULL, NULL, 'false', 'A', NULL, NULL, NULL,
        '{"op":"SUM","table":"LIGNES","colonne":"Mnt"}', 'false', 'MNT', 2, 'false', 5, NULL, 'Pied de grille : somme des montants des trajets', GETDATE(), 'SCRIPT');

DELETE FROM SP_Page_Validation WHERE Cod_Page = @CP;
INSERT INTO SP_Page_Validation (Cod_Page, Cod_Validation, Portee, Cod_Table, Cod_Champ, Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif, Dat_Crea, Created_By)
VALUES
    (@CP, 'V01_MATRICULE', 'CHAMP',   'ENT',    'Matricule', 'REQUIRED', NULL, NULL,
        'Le matricule est obligatoire.', 'B', 1, 'SAVE', 'true', GETDATE(), 'SCRIPT'),
    (@CP, 'V02_NB_LIGNES', 'DETAIL',  'LIGNES', NULL,        'NB_LIGNES', '{"min":1}', NULL,
        'Au moins une ligne de trajet est requise.', 'B', 2, 'SAVE', 'true', GETDATE(), 'SCRIPT'),
    (@CP, 'V03_KM_MAX',    'LIGNE',   'LIGNES', 'L_Km',      'BETWEEN', '{"min":0,"max":1000}', NULL,
        'Kilométrage inhabituel (attendu entre 0 et 1000 km).', 'W', 3, 'SAVE', 'true', GETDATE(), 'SCRIPT'),
    (@CP, 'V04_TOTAL',     'DOCUMENT', 'ENT',   NULL,        'EXPR',
        '{"expr":{"op":"GE","args":[{"ref":"Total"},{"const":0}]}}', NULL,
        'Le total ne peut pas être négatif.', 'B', 4, 'SAVE', 'true', GETDATE(), 'SCRIPT');

DELETE FROM SP_Page_Droit WHERE Cod_Page = @CP;
INSERT INTO SP_Page_Droit (Cod_Page, Cod_Profile, Consulter, Creer, Modifier, Supprimer, Valider, Imprimer, GED, Dat_Crea, Created_By)
VALUES (@CP, '1', 'true', 'true', 'true', 'true', 'true', 'true', 'true', GETDATE(), 'SCRIPT');

/* -------------------------------------------------------------------------- */
/* 2. Tables métier (même format que la génération Module_SP_DDL)             */
/* -------------------------------------------------------------------------- */
IF OBJECT_ID('dbo.SP_FKM_Ent', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.[SP_FKM_Ent] (
        [Num_Doc] nvarchar(30) NOT NULL,
        [id_Societe] int NOT NULL,
        [Statut] nvarchar(3) NULL CONSTRAINT [DF_SP_FKM_Ent_Statut] DEFAULT (''),
        [Dat_Crea] datetime NULL,
        [Created_By] nvarchar(50) NULL,
        [Dat_Modif] datetime NULL,
        [Modified_By] nvarchar(50) NULL,
        [RV] rowversion NOT NULL,
        [Matricule] nvarchar(20) NOT NULL CONSTRAINT [DF_SP_FKM_Ent_Matricule] DEFAULT (''),
        [Dat_Demande] date NULL,
        [Commentaire] nvarchar(300) NULL,
        [Total] decimal(18,2) NULL,
        CONSTRAINT [PK_SP_FKM_Ent] PRIMARY KEY ([Num_Doc], [id_Societe])
    );
END

IF OBJECT_ID('dbo.SP_FKM_Det_LIGNES', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.[SP_FKM_Det_LIGNES] (
        [RowId] int IDENTITY(1,1) NOT NULL,
        [Num_Doc] nvarchar(30) NOT NULL,
        [id_Societe] int NOT NULL,
        [Dat_Crea] datetime NULL,
        [Created_By] nvarchar(50) NULL,
        [Dat_Modif] datetime NULL,
        [Modified_By] nvarchar(50) NULL,
        [Trajet] nvarchar(100) NULL,
        [Km] float NULL,
        [Tx] float NULL,
        [Mnt] decimal(18,2) NULL,
        CONSTRAINT [PK_SP_FKM_Det_LIGNES] PRIMARY KEY ([RowId])
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_SP_FKM_Det_LIGNES_Ent')
    ALTER TABLE dbo.[SP_FKM_Det_LIGNES] WITH NOCHECK ADD CONSTRAINT [FK_SP_FKM_Det_LIGNES_Ent]
        FOREIGN KEY ([Num_Doc], [id_Societe]) REFERENCES dbo.[SP_FKM_Ent] ([Num_Doc], [id_Societe]) ON DELETE CASCADE;

IF NOT EXISTS (SELECT 1 FROM SP_Page_DDL_Log WHERE Cod_Page = @CP)
    INSERT INTO SP_Page_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec)
    VALUES (@CP, 'CREATE', 'CREATE TABLE SP_FKM_Ent / SP_FKM_Det_LIGNES + FK (script exemple)', 'true', 'Tables créées par le script exemple', 'SCRIPT', GETDATE());

/* -------------------------------------------------------------------------- */
/* 3. Publication (contrôles + rattachements)                                 */
/* -------------------------------------------------------------------------- */
UPDATE SP_Page SET Statut_Page = 'PUBLIE', Dat_Publication = GETDATE(), DDL_Genere = 'true',
       Version_Page = ISNULL(Version_Page, 1) + 1, Dat_Modif = GETDATE(), Modified_By = 'SCRIPT'
WHERE Cod_Page = @CP AND Statut_Page <> 'PUBLIE';

-- Enregistrement de l'écran portail (liaison GED : Name_Ecran + Value_Index)
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran WHERE Name_Ecran = 'SPP_FRAIS_KM')
    INSERT INTO Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
    VALUES ('SPP_FRAIS_KM', 'SP_FKM_Ent', 'Num_Doc', '', 'Num_Doc', 'false', 'true', 'true', GETDATE(), 'SCRIPT');

-- Déclaration du type de document au moteur de workflow existant
-- (code unique de la page = code workflow ; le circuit de signataires se
--  paramètre ensuite via l'écran Workflow_Signatures)
IF NOT EXISTS (SELECT 1 FROM Param_Workflow_Typ_Document WHERE Typ_Document = 'FKM')
    INSERT INTO Param_Workflow_Typ_Document
        (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
    VALUES ('FKM', 'Note de frais kilométriques', 'SP_FKM_Ent', 'Num_Doc', 'false', 'SPP_FRAIS_KM', 'Num_Doc', 'Created_By', -1);

COMMIT TRANSACTION;
GO

SELECT Cod_Page, Statut_Page, Table_Ent, Menu_Parent, Rang FROM SP_Page WHERE Cod_Page = 'FRAIS_KM';
