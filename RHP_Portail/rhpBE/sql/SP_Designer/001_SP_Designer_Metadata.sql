/* ============================================================================
   RHP - Designer de pages portail (module SP_)
   Script d'installation SQL Server - Tables de métadonnées
   ----------------------------------------------------------------------------
   Contenu :
     1. Tables de métadonnées : SP_Page, SP_Page_Droit, SP_Page_Table,
        SP_Page_Colonne, SP_Page_Champ, SP_Page_Validation, SP_Page_Source,
        SP_Page_DDL_Log
     2. Rubriques système : SP_Statut_Page, SP_Typ_Controle, SP_Typ_Regle,
        SP_Typ_Sql, SP_Etat_Champ, SP_Niveau_Valid, SP_Moment_Valid
     3. Fonction d'habilitation : Controle_Menu_Functions 'SP_DESIGNER'
     4. Catalogue de sources métier : source 'solde_conge' (exemple)
   ----------------------------------------------------------------------------
   Conventions :
     - Les tables MÉTIER générées par le module sont préfixées SP_ :
         entête : SP_<CodDocument>_Ent
         détail : SP_<CodDocument>_Det_<CodTable>
       (réservé : Cod_Page ne peut pas commencer par 'Page')
     - Les booléens suivent la convention RHP : nvarchar(5) 'true'/'false'
     - Colonnes d'audit systématiques : Dat_Crea / Created_By /
       Dat_Modif / Modified_By
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

/* -------------------------------------------------------------------------- */
/* 1. Métadonnées                                                             */
/* -------------------------------------------------------------------------- */

-- 1.1 Définition de la page / du type de document
IF OBJECT_ID('dbo.SP_Page', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SP_Page (
        Cod_Page          nvarchar(30)  NOT NULL,   -- identifiant technique immuable
        Cod_Document      nvarchar(10)  NOT NULL,   -- code du type de document
        Libelle           nvarchar(150) NOT NULL,
        Libelle_Court     nvarchar(50)  NULL,
        Nom_Page          nvarchar(60)  NOT NULL,   -- titre affiché dans le portail
        Menu_Parent       nvarchar(60)  NOT NULL,   -- section du portail (name_ecran racine)
        Rang              int           NOT NULL CONSTRAINT DF_SP_Page_Rang DEFAULT (99),
        Icone             nvarchar(50)  NULL,       -- nom d'icône MUI (MenuIcons)
        Statut_Page       nvarchar(10)  NOT NULL CONSTRAINT DF_SP_Page_Statut DEFAULT ('BROUILLON'), -- BROUILLON/PUBLIE/DESACTIVE/ARCHIVE
        Table_Ent         nvarchar(60)  NOT NULL,   -- SP_<CodDocument>_Ent
        -- Intégrations
        Typ_Document      nvarchar(2)   NULL,       -- type workflow (Param_Workflow_Typ_Document)
        Workflow_Actif    nvarchar(5)   NOT NULL CONSTRAINT DF_SP_Page_Wf DEFAULT ('false'),
        Cod_Modele_Edition nvarchar(20) NULL,       -- Param_Mod_Edition.Cod_Report
        GED_Actif         nvarchar(5)   NOT NULL CONSTRAINT DF_SP_Page_Ged DEFAULT ('false'),
        GED_Categories    nvarchar(500) NULL,       -- json : catégories de pièces autorisées
        GED_Obligatoire   nvarchar(5)   NOT NULL CONSTRAINT DF_SP_Page_GedObl DEFAULT ('false'),
        -- Actions disponibles sur le document
        Act_Enregistrer   nvarchar(5)   NOT NULL CONSTRAINT DF_SP_Page_ActSave DEFAULT ('true'),
        Act_Soumettre     nvarchar(5)   NOT NULL CONSTRAINT DF_SP_Page_ActSubmit DEFAULT ('true'),
        Act_Imprimer      nvarchar(5)   NOT NULL CONSTRAINT DF_SP_Page_ActPrint DEFAULT ('false'),
        Act_Exporter      nvarchar(5)   NOT NULL CONSTRAINT DF_SP_Page_ActExport DEFAULT ('false'),
        -- Habilitations : 'true' = consultation réservée aux profils de SP_Page_Droit ;
        -- 'false' = consultation ouverte à tous les profils (même créés ultérieurement)
        Acces_Personnalise nvarchar(5)  NOT NULL CONSTRAINT DF_SP_Page_AccesPerso DEFAULT ('true'),
        -- Gouvernance
        Version_Page      int           NOT NULL CONSTRAINT DF_SP_Page_Version DEFAULT (1),
        DDL_Genere        nvarchar(5)   NOT NULL CONSTRAINT DF_SP_Page_DDL DEFAULT ('false'),
        Dat_Publication   datetime      NULL,
        Dat_Crea          datetime      NULL,
        Created_By        nvarchar(50)  NULL,
        Dat_Modif         datetime      NULL,
        Modified_By       nvarchar(50)  NULL,
        CONSTRAINT PK_SP_Page PRIMARY KEY (Cod_Page),
        CONSTRAINT UQ_SP_Page_Document UNIQUE (Cod_Document),
        CONSTRAINT CK_SP_Page_Statut CHECK (Statut_Page IN ('BROUILLON','PUBLIE','DESACTIVE','ARCHIVE')),
        CONSTRAINT CK_SP_Page_Ident CHECK (Cod_Page LIKE '[A-Za-z_]%[A-Za-z0-9_]%'
                                           AND Cod_Page NOT LIKE 'Page%')
    );
END
GO

-- 1.1.b Migration : accès personnalisé (bases existantes).
--       'true' par défaut : les pages existantes conservent leurs habilitations
--       par profil inchangées (aucune ouverture de consultation en douce).
IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID('dbo.SP_Page') AND name = 'Acces_Personnalise')
BEGIN
    ALTER TABLE dbo.SP_Page
        ADD Acces_Personnalise nvarchar(5) NOT NULL
            CONSTRAINT DF_SP_Page_AccesPerso DEFAULT ('true') WITH VALUES;
END
GO

-- 1.2 Habilitations par profil et par action
IF OBJECT_ID('dbo.SP_Page_Droit', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SP_Page_Droit (
        Cod_Page     nvarchar(30) NOT NULL,
        Cod_Profile  nvarchar(10) NOT NULL,
        Consulter    nvarchar(5)  NOT NULL CONSTRAINT DF_SPDroit_Cons DEFAULT ('false'),
        Creer        nvarchar(5)  NOT NULL CONSTRAINT DF_SPDroit_Creer DEFAULT ('false'),
        Modifier     nvarchar(5)  NOT NULL CONSTRAINT DF_SPDroit_Modif DEFAULT ('false'),
        Supprimer    nvarchar(5)  NOT NULL CONSTRAINT DF_SPDroit_Suppr DEFAULT ('false'),
        Valider      nvarchar(5)  NOT NULL CONSTRAINT DF_SPDroit_Valid DEFAULT ('false'),
        Imprimer     nvarchar(5)  NOT NULL CONSTRAINT DF_SPDroit_Impr DEFAULT ('false'),
        GED          nvarchar(5)  NOT NULL CONSTRAINT DF_SPDroit_Ged DEFAULT ('false'),
        Dat_Crea     datetime     NULL,
        Created_By   nvarchar(50) NULL,
        Dat_Modif    datetime     NULL,
        Modified_By  nvarchar(50) NULL,
        CONSTRAINT PK_SP_Page_Droit PRIMARY KEY (Cod_Page, Cod_Profile),
        CONSTRAINT FK_SPDroit_Page FOREIGN KEY (Cod_Page) REFERENCES dbo.SP_Page (Cod_Page)
    );
END
GO

-- 1.3 Tables rattachées (entête + 0..n détails)
IF OBJECT_ID('dbo.SP_Page_Table', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SP_Page_Table (
        Cod_Page       nvarchar(30) NOT NULL,
        Cod_Table      nvarchar(20) NOT NULL,       -- 'ENT' ou code du détail (ex: 'LIGNES')
        Nom_Physique   nvarchar(60) NOT NULL,       -- SP_<CodDocument>_Ent / _Det_<Cod_Table>
        Role_Table     nvarchar(3)  NOT NULL,       -- ENT / DET
        Libelle        nvarchar(150) NULL,          -- libellé du bloc de détail
        Rang           int          NOT NULL CONSTRAINT DF_SPTable_Rang DEFAULT (1),
        -- Options d'édition des détails
        Allow_Add      nvarchar(5)  NOT NULL CONSTRAINT DF_SPTable_Add DEFAULT ('true'),
        Allow_Edit     nvarchar(5)  NOT NULL CONSTRAINT DF_SPTable_Edit DEFAULT ('true'),
        Allow_Delete   nvarchar(5)  NOT NULL CONSTRAINT DF_SPTable_Del DEFAULT ('true'),
        Allow_Duplicate nvarchar(5) NOT NULL CONSTRAINT DF_SPTable_Dup DEFAULT ('false'),
        Tri_Defaut     nvarchar(200) NULL,          -- ex: 'Rang asc, Libelle desc' (noms validés)
        Regle_Suppression nvarchar(10) NOT NULL CONSTRAINT DF_SPTable_RglDel DEFAULT ('CASCADE'), -- CASCADE / RESTRICT
        Dat_Crea       datetime     NULL,
        Created_By     nvarchar(50) NULL,
        Dat_Modif      datetime     NULL,
        Modified_By    nvarchar(50) NULL,
        CONSTRAINT PK_SP_Page_Table PRIMARY KEY (Cod_Page, Cod_Table),
        CONSTRAINT UQ_SP_Page_Table_Nom UNIQUE (Nom_Physique),
        CONSTRAINT FK_SPTable_Page FOREIGN KEY (Cod_Page) REFERENCES dbo.SP_Page (Cod_Page),
        CONSTRAINT CK_SPTable_Role CHECK (Role_Table IN ('ENT','DET')),
        CONSTRAINT CK_SPTable_RglDel CHECK (Regle_Suppression IN ('CASCADE','RESTRICT'))
    );
END
GO

-- 1.4 Colonnes physiques des tables
IF OBJECT_ID('dbo.SP_Page_Colonne', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SP_Page_Colonne (
        Cod_Page       nvarchar(30) NOT NULL,
        Cod_Table      nvarchar(20) NOT NULL,
        Nom_Colonne    nvarchar(50) NOT NULL,
        Libelle        nvarchar(150) NULL,
        Typ_Sql        nvarchar(20) NOT NULL,       -- nvarchar/int/bigint/float/decimal/bit/date/datetime/smalldatetime
        Longueur       int          NULL,           -- nvarchar (-1 = max)
        Precision_Sql  int          NULL,           -- decimal
        Echelle_Sql    int          NULL,           -- decimal
        Nullable       nvarchar(5)  NOT NULL CONSTRAINT DF_SPCol_Null DEFAULT ('true'),
        Valeur_Defaut  nvarchar(200) NULL,
        estUnique      nvarchar(5)  NOT NULL CONSTRAINT DF_SPCol_Unique DEFAULT ('false'),
        estPK          nvarchar(5)  NOT NULL CONSTRAINT DF_SPCol_PK DEFAULT ('false'),
        estIndexe      nvarchar(5)  NOT NULL CONSTRAINT DF_SPCol_Idx DEFAULT ('false'),
        Technique      nvarchar(5)  NOT NULL CONSTRAINT DF_SPCol_Tech DEFAULT ('false'), -- colonne système (non supprimable)
        Rang           int          NOT NULL CONSTRAINT DF_SPCol_Rang DEFAULT (1),
        Dat_Crea       datetime     NULL,
        Created_By     nvarchar(50) NULL,
        Dat_Modif      datetime     NULL,
        Modified_By    nvarchar(50) NULL,
        CONSTRAINT PK_SP_Page_Colonne PRIMARY KEY (Cod_Page, Cod_Table, Nom_Colonne),
        CONSTRAINT FK_SPCol_Table FOREIGN KEY (Cod_Page, Cod_Table)
            REFERENCES dbo.SP_Page_Table (Cod_Page, Cod_Table)
    );
END
GO

-- 1.5 Champs de la page (conception UI : entête + colonnes de grilles)
IF OBJECT_ID('dbo.SP_Page_Champ', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SP_Page_Champ (
        Cod_Page       nvarchar(30)  NOT NULL,
        Cod_Champ      nvarchar(50)  NOT NULL,      -- identifiant technique du champ
        Cod_Table      nvarchar(20)  NOT NULL,      -- table associée (ENT ou code détail)
        Nom_Colonne    nvarchar(50)  NOT NULL,      -- colonne physique associée
        Libelle        nvarchar(150) NOT NULL,
        Typ_Controle   nvarchar(20)  NOT NULL,      -- TEXT/MEMO/INT/DEC/MNT/DATE/DATETIME/CHECK/RADIO/COMBO/RUBRIQUE/ZOOM/CALCULE/SOURCE
        -- Placement entête (grille responsive 12 colonnes)
        Rang           int           NOT NULL CONSTRAINT DF_SPChamp_Rang DEFAULT (1),
        Ligne          int           NULL,
        Colonne        int           NULL,
        Largeur        int           NULL,          -- 1..12 (défaut 3)
        Valeur_Defaut  nvarchar(200) NULL,          -- constante ou GV : GV_MATRICULE, GV_NOW...
        Aide           nvarchar(300) NULL,
        Obligatoire    nvarchar(5)   NOT NULL CONSTRAINT DF_SPChamp_Obl DEFAULT ('false'),
        Etat           nvarchar(1)   NOT NULL CONSTRAINT DF_SPChamp_Etat DEFAULT ('S'), -- S=saisissable R=lecture seule A=affiché I=invisible
        -- ComboBox rubrique Param_Rubriques
        Rubrique       nvarchar(60)  NULL,
        -- Zoom
        Num_Zoom       nvarchar(10)  NULL,
        Zoom_Retour    nvarchar(1000) NULL,         -- json : {"ChampCible":"ColonneZoom",...}
        -- Combo libre / source métier
        Source_Metier  nvarchar(50)  NULL,          -- SP_Page_Source.Cod_Source
        -- Champ calculé
        Formule        nvarchar(max) NULL,          -- json déclaratif (jamais de code libre)
        Persiste       nvarchar(5)   NOT NULL CONSTRAINT DF_SPChamp_Persiste DEFAULT ('false'),
        Recalc_Save    nvarchar(5)   NOT NULL CONSTRAINT DF_SPChamp_Recalc DEFAULT ('true'),
        -- Formatage
        Format_Affichage nvarchar(50) NULL,
        Decimales      int           NULL,
        -- Règles dynamiques (json déclaratif)
        Regle_Visibilite nvarchar(max) NULL,
        Regle_Activation nvarchar(max) NULL,
        -- Grille de détail
        Visible_Grille nvarchar(5)   NOT NULL CONSTRAINT DF_SPChamp_VisGrd DEFAULT ('true'),
        Rang_Grille    int           NOT NULL CONSTRAINT DF_SPChamp_RangGrd DEFAULT (1),
        Largeur_Colonne int          NULL,          -- largeur colonne grille (em)
        Total_Grille   nvarchar(10)  NOT NULL CONSTRAINT DF_SPChamp_TotGrd DEFAULT (''), -- '', SUM, AVG, MIN, MAX, COUNT
        -- Critères de sélection de la page Liste
        estCritere     nvarchar(5)   NOT NULL CONSTRAINT DF_SPChamp_Critere DEFAULT ('false'),
        Rang_Critere   int           NULL,
        Dat_Crea       datetime      NULL,
        Created_By     nvarchar(50)  NULL,
        Dat_Modif      datetime      NULL,
        Modified_By    nvarchar(50)  NULL,
        CONSTRAINT PK_SP_Page_Champ PRIMARY KEY (Cod_Page, Cod_Champ),
        CONSTRAINT FK_SPChamp_Page FOREIGN KEY (Cod_Page) REFERENCES dbo.SP_Page (Cod_Page),
        CONSTRAINT CK_SPChamp_Etat CHECK (Etat IN ('S','R','A','I')),
        CONSTRAINT CK_SPChamp_Typ CHECK (Typ_Controle IN
            ('TEXT','MEMO','INT','DEC','MNT','DATE','DATETIME','CHECK','RADIO',
             'COMBO','RUBRIQUE','ZOOM','CALCULE','SOURCE','GED'))
    );
END
GO

-- 1.6 Validations déclaratives (champ + règles globales avant enregistrement)
IF OBJECT_ID('dbo.SP_Page_Validation', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SP_Page_Validation (
        Cod_Page        nvarchar(30)  NOT NULL,
        Cod_Validation  nvarchar(50)  NOT NULL,
        Portee          nvarchar(10)  NOT NULL,     -- CHAMP/ENTETE/LIGNE/DETAIL/DOCUMENT
        Cod_Table       nvarchar(20)  NULL,         -- table cible (défaut ENT)
        Cod_Champ       nvarchar(50)  NULL,         -- champ cible (portée CHAMP)
        Typ_Regle       nvarchar(20)  NOT NULL,     -- REQUIRED/IN/BETWEEN/MIN/MAX/MINLEN/MAXLEN/REGEX/COMPARE/UNIQUE/SOURCE/EXPR/NB_LIGNES
        Parametres      nvarchar(max) NULL,         -- json déclaratif
        Condition_Regle nvarchar(max) NULL,         -- json : condition d'application
        Message         nvarchar(300) NOT NULL,
        Niveau          nvarchar(1)   NOT NULL CONSTRAINT DF_SPValid_Niveau DEFAULT ('B'), -- I/W/B
        Rang            int           NOT NULL CONSTRAINT DF_SPValid_Rang DEFAULT (1),
        Moment          nvarchar(20)  NOT NULL CONSTRAINT DF_SPValid_Moment DEFAULT ('SAVE'), -- SAISIE/CHANGE/AJOUT_LIGNE/SAVE
        Actif           nvarchar(5)   NOT NULL CONSTRAINT DF_SPValid_Actif DEFAULT ('true'),
        Dat_Crea        datetime      NULL,
        Created_By      nvarchar(50)  NULL,
        Dat_Modif       datetime      NULL,
        Modified_By     nvarchar(50)  NULL,
        CONSTRAINT PK_SP_Page_Validation PRIMARY KEY (Cod_Page, Cod_Validation),
        CONSTRAINT FK_SPValid_Page FOREIGN KEY (Cod_Page) REFERENCES dbo.SP_Page (Cod_Page),
        CONSTRAINT CK_SPValid_Portee CHECK (Portee IN ('CHAMP','ENTETE','LIGNE','DETAIL','DOCUMENT')),
        CONSTRAINT CK_SPValid_Niveau CHECK (Niveau IN ('I','W','B')),
        CONSTRAINT CK_SPValid_Typ CHECK (Typ_Regle IN
            ('REQUIRED','IN','BETWEEN','MIN','MAX','MINLEN','MAXLEN','REGEX',
             'COMPARE','UNIQUE','SOURCE','EXPR','NB_LIGNES'))
    );
END
GO

-- 1.7 Catalogue sécurisé de sources métier autorisées
IF OBJECT_ID('dbo.SP_Page_Source', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SP_Page_Source (
        Cod_Source   nvarchar(50)  NOT NULL,
        Libelle      nvarchar(150) NOT NULL,
        Typ_Source   nvarchar(10)  NOT NULL,        -- SQL / PROC
        Code_Sql     nvarchar(max) NOT NULL,        -- SELECT paramétré (whitelist à l'enregistrement)
        Parametres   nvarchar(max) NULL,            -- json : [{Nom, Typ, Obligatoire}]
        Typ_Retour   nvarchar(10)  NOT NULL CONSTRAINT DF_SPSource_Retour DEFAULT ('SCALAIRE'), -- SCALAIRE / TABLE
        Cod_Profile  nvarchar(10)  NOT NULL CONSTRAINT DF_SPSource_Profil DEFAULT (''),        -- '' = tous profils
        Actif        nvarchar(5)   NOT NULL CONSTRAINT DF_SPSource_Actif DEFAULT ('true'),
        Dat_Crea     datetime      NULL,
        Created_By   nvarchar(50)  NULL,
        Dat_Modif    datetime      NULL,
        Modified_By  nvarchar(50)  NULL,
        CONSTRAINT PK_SP_Page_Source PRIMARY KEY (Cod_Source),
        CONSTRAINT CK_SPSource_Typ CHECK (Typ_Source IN ('SQL','PROC')),
        CONSTRAINT CK_SPSource_Retour CHECK (Typ_Retour IN ('SCALAIRE','TABLE'))
    );
END
GO

-- 1.8 Journal des générations / migrations DDL
IF OBJECT_ID('dbo.SP_Page_DDL_Log', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SP_Page_DDL_Log (
        RowId          int IDENTITY(1,1) NOT NULL,
        Cod_Page       nvarchar(30)  NOT NULL,
        Type_Operation nvarchar(20)  NOT NULL,      -- CREATE / MIGRATE
        Script_DDL     nvarchar(max) NOT NULL,
        Resultat       nvarchar(5)   NOT NULL,      -- 'true'/'false'
        Message        nvarchar(max) NULL,
        Login_Exec     nvarchar(50)  NULL,
        Date_Exec      datetime      NOT NULL CONSTRAINT DF_SPDDLLog_Date DEFAULT (GETDATE()),
        CONSTRAINT PK_SP_Page_DDL_Log PRIMARY KEY (RowId),
        CONSTRAINT FK_SPDDLLog_Page FOREIGN KEY (Cod_Page) REFERENCES dbo.SP_Page (Cod_Page)
    );
END
GO

/* -------------------------------------------------------------------------- */
/* 2. Rubriques système du module                                             */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Param_Rubriques WHERE Nom_Controle = 'SP_Statut_Page')
BEGIN
    INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By) VALUES
        ('SP_Statut_Page', 'BROUILLON', 'Brouillon',   1, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Statut_Page', 'PUBLIE',    'Publié',      2, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Statut_Page', 'DESACTIVE', 'Désactivé',   3, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Statut_Page', 'ARCHIVE',   'Archivé',     4, 'S', GETDATE(), 'SCRIPT');
END
GO
IF NOT EXISTS (SELECT 1 FROM Param_Rubriques WHERE Nom_Controle = 'SP_Typ_Controle')
BEGIN
    INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By) VALUES
        ('SP_Typ_Controle', 'TEXT',     'Texte',                    1,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'MEMO',     'Texte multiligne',         2,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'INT',      'Entier',                   3,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'DEC',      'Décimal',                  4,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'MNT',      'Montant',                  5,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'DATE',     'Date',                     6,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'DATETIME', 'Date et heure',            7,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'CHECK',    'Case à cocher',            8,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'RADIO',    'Boutons radio',            9,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'COMBO',    'ComboBox (zoom)',          10, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'RUBRIQUE', 'ComboBox rubrique',        11, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'ZOOM',     'Zoom',                     12, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'CALCULE',  'Champ calculé',            13, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Controle', 'SOURCE',   'Source métier externe',    14, 'S', GETDATE(), 'SCRIPT');
END
GO
IF NOT EXISTS (SELECT 1 FROM Param_Rubriques WHERE Nom_Controle = 'SP_Typ_Sql')
BEGIN
    INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By) VALUES
        ('SP_Typ_Sql', 'nvarchar',      'Texte (nvarchar)',         1, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Sql', 'int',           'Entier (int)',             2, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Sql', 'bigint',        'Entier long (bigint)',     3, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Sql', 'float',         'Flottant (float)',         4, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Sql', 'decimal',       'Décimal (decimal)',        5, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Sql', 'bit',           'Booléen (bit)',            6, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Sql', 'date',          'Date (date)',              7, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Sql', 'datetime',      'Date-heure (datetime)',    8, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Typ_Sql', 'smalldatetime', 'Date-heure (smalldatetime)', 9, 'S', GETDATE(), 'SCRIPT');
END
GO
IF NOT EXISTS (SELECT 1 FROM Param_Rubriques WHERE Nom_Controle = 'SP_Etat_Champ')
BEGIN
    INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By) VALUES
        ('SP_Etat_Champ', 'S', 'Saisissable',   1, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Etat_Champ', 'R', 'Lecture seule', 2, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Etat_Champ', 'A', 'Affiché',       3, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Etat_Champ', 'I', 'Invisible',     4, 'S', GETDATE(), 'SCRIPT');
END
GO
IF NOT EXISTS (SELECT 1 FROM Param_Rubriques WHERE Nom_Controle = 'SP_Niveau_Valid')
BEGIN
    INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By) VALUES
        ('SP_Niveau_Valid', 'I', 'Information',  1, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Niveau_Valid', 'W', 'Avertissement', 2, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Niveau_Valid', 'B', 'Blocage',      3, 'S', GETDATE(), 'SCRIPT');
END
GO
IF NOT EXISTS (SELECT 1 FROM Param_Rubriques WHERE Nom_Controle = 'SP_Moment_Valid')
BEGIN
    INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By) VALUES
        ('SP_Moment_Valid', 'SAISIE',      'Saisie',                 1, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Moment_Valid', 'CHANGE',      'Changement de champ',    2, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Moment_Valid', 'AJOUT_LIGNE', 'Ajout d''une ligne',     3, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Moment_Valid', 'SAVE',        'Enregistrement',         4, 'S', GETDATE(), 'SCRIPT');
END
GO

IF NOT EXISTS (SELECT 1 FROM Param_Rubriques WHERE Nom_Controle = 'SP_Menu_Portail')
BEGIN
    -- Sections racines du menu portail (name_ecran de menus.json) : la page
    -- publiée est automatiquement rattachée à la section et au rang déclarés.
    INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By) VALUES
        ('SP_Menu_Portail', 'orga',             'Données organisation',            1,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'MesDemandes',      'Demandes et documents',           2,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'mesConsultations', 'Consultations',                   3,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'mesEvaluations',   'Evaluations et formations',       4,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'Recrutement_fdr',  'Recrutements',                    5,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'MesDeclarationsAT','Déclarations d''accidents de travail', 6, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'DiverseEditions',  'Diverses Éditions',               7,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'Discipline_fdr',   'Discipline',                      8,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'Outillage',        'Outillage',                       9,  'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'Communication',    'Communication',                   10, 'S', GETDATE(), 'SCRIPT'),
        ('SP_Menu_Portail', 'Sante',            'Santé au travail',                11, 'S', GETDATE(), 'SCRIPT');
END
GO

/* -------------------------------------------------------------------------- */
/* 3. Fonction d'habilitation du configurateur                                */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Functions WHERE Function_Sec = 'SP_DESIGNER')
    INSERT INTO Controle_Menu_Functions (Function_Sec, Description)
    VALUES ('SP_DESIGNER', 'Designer de pages portail (module SP_)');
GO

/* -------------------------------------------------------------------------- */
/* 4. Catalogue de sources métier : exemple 'solde_conge'                     */
/*    Paramètres disponibles : tout paramètre @xxx de Code_Sql doit être      */
/*    déclaré dans Parametres (json). @id_Societe est injecté automatiquement */
/*    par le serveur et ne doit pas être déclaré.                             */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM SP_Page_Source WHERE Cod_Source = 'solde_conge')
BEGIN
    INSERT INTO SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By)
    VALUES ('solde_conge', 'Solde de congé de l''agent', 'SQL',
            'select Solde_Conge from dbo.Sys_Rh_Conge(@id_Societe, convert(date, getdate())) where Matricule = @Matricule',
            '[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true}]',
            'SCALAIRE', '', 'true', GETDATE(), 'SCRIPT');
END
GO

COMMIT TRANSACTION;
GO

/* -------------------------------------------------------------------------- */
/* Après exécution :                                                          */
/*   - Donner la fonction SP_DESIGNER aux profils autorisés via Admin_Profile */
/*   - Enregistrer l'écran Desktop SP_Page_Designer (voir                     */
/*     RHP_DeskTop\RHP\Portail\Script_SQL_SP_Page_Designer.sql)               */
/* -------------------------------------------------------------------------- */
