/* ============================================================================
   RHP - Profils portail des agents (RH_Agent)
   ----------------------------------------------------------------------------
   Met en place l'affectation d'un profil (Controle_Profile) aux agents pour
   contrôler les droits d'accès aux pages du portail :

     - RH_Agent.Cod_Profile        : profil portail de l'agent (NULL = non
                                     affecté -> profil par défaut) ;
     - Controle_Profile.Portail_Defaut : un seul profil peut être marqué
                                     "profil portail par défaut" (index filtré
                                     unique) ; il s'applique aux agents sans
                                     affectation explicite ;
     - Controle_Menu_Portail       : référentiel des pages/sections STANDARDS
                                     du portail (miroir de menus.json), source
                                     de l'onglet "Portail" de l'écran desktop
                                     Admin_Profile ; les droits sont stockés
                                     dans Controle_Droit (Name_Ecran =
                                     'PRT_' + nom de la page — le préfixe isole
                                     les droits portail des écrans desktop de
                                     mêmes noms —, Visible = affichage menu,
                                     Actif = accès page).

   Règles appliquées par le backend portail :
     - profil '1' : bypass total (convention RHP) ;
     - le contrôle est PAR PROFIL : sans ligne Controle_Droit POUR CE PROFIL
       sur une page, celle-ci est non contrôlée pour lui -> accès libre
       (déploiement progressif sans rupture ; l'enregistrement d'un profil
       dans l'onglet Portail d'Admin_Profile écrit une ligne pour CHAQUE
       page : le profil obtient exactement ce qui a été coché) ;
     - résolution du profil au login : RH_Agent.Cod_Profile > Controle_Users
       (par Mail, compatibilité) > profil par défaut > -1 ; un profil inactif
       est ignoré.

   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

/* ---- 1. Profil portail de l'agent (int, aligné sur Controle_Profile) ----- */
IF COL_LENGTH('dbo.RH_Agent', 'Cod_Profile') IS NULL
    ALTER TABLE dbo.RH_Agent
        ADD Cod_Profile int NULL;

/* ---- 2. Profil portail par défaut (colonne) ------------------------------ */
IF COL_LENGTH('dbo.Controle_Profile', 'Portail_Defaut') IS NULL
    ALTER TABLE dbo.Controle_Profile
        ADD Portail_Defaut nvarchar(5) NOT NULL
            CONSTRAINT DF_Controle_Profile_Portail_Defaut DEFAULT ('false') WITH VALUES;

/* ---- 3. Référentiel des pages standards du portail (table) --------------- */
IF OBJECT_ID('dbo.Controle_Menu_Portail', 'U') IS NULL
    CREATE TABLE dbo.Controle_Menu_Portail (
        Name_Ecran   nvarchar(100) NOT NULL
            CONSTRAINT PK_Controle_Menu_Portail PRIMARY KEY,
        Text_Ecran   nvarchar(200) NOT NULL
            CONSTRAINT DF_CMP_Text DEFAULT (''),
        Typ_Ecran    nvarchar(3)   NOT NULL
            CONSTRAINT DF_CMP_Typ DEFAULT ('ECR'),   -- MNU = section, ECR = page
        Menu_Parent  nvarchar(100) NOT NULL
            CONSTRAINT DF_CMP_Parent DEFAULT (''),
        Rang         int NOT NULL
            CONSTRAINT DF_CMP_Rang DEFAULT (99),
        Created_By   nvarchar(50)  NULL,
        Dat_Crea     datetime      NULL,
        Modified_By  nvarchar(50)  NULL,
        Dat_Modif    datetime      NULL
    );

COMMIT TRANSACTION;
GO

/* ---- 2b. Un seul profil portail par défaut (index filtré unique) --------- */
/* (lot séparé : la colonne Portail_Defaut doit exister à la compilation ;    */
/*  index filtré -> QUOTED_IDENTIFIER / ANSI_NULLS obligatoires)              */
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM sys.indexes
               WHERE name = 'UX_Controle_Profile_Portail_Defaut'
                 AND object_id = OBJECT_ID('dbo.Controle_Profile'))
    CREATE UNIQUE NONCLUSTERED INDEX UX_Controle_Profile_Portail_Defaut
        ON dbo.Controle_Profile (Portail_Defaut)
        WHERE Portail_Defaut = 'true';

COMMIT TRANSACTION;
GO

/* ---- 4. Seed : miroir de rhpfe/public/menus.json -------------------------- */
/* (ré-exécutable : seules les pages absentes sont insérées)                  */
;WITH src (Name_Ecran, Text_Ecran, Typ_Ecran, Menu_Parent, Rang) AS (
    SELECT * FROM (VALUES
        ('Dashboard',                    N'Tableau de bord',                        'ECR', '',                 0),
        ('orga',                         N'Données organisation',                   'MNU', '',                 1),
        ('RH_Agent',                     N'Fiche agent',                            'ECR', 'orga',             1),
        ('Org_Poste',                    N'Fiche de poste',                         'ECR', 'orga',             2),
        ('Org_Organigramme',             N'Organigramme',                           'ECR', 'orga',             3),
        ('RH_Avancement_Timeline',       N'Chronologie de carrière',                'ECR', 'orga',             4),
        ('MesDemandes',                  N'Demandes et documents',                  'MNU', '',                 2),
        ('RH_Demande_Conge_Liste',       N'Demandes de congé',                      'ECR', 'MesDemandes',      1),
        ('RH_Demande_Avance_Liste',      N'Demandes d''avances',                    'ECR', 'MesDemandes',      2),
        ('RH_Demande_Pret_Liste',        N'Demandes de prêts',                      'ECR', 'MesDemandes',      3),
        ('RH_Dossier_Maladie_Liste',     N'Dossiers de maladie',                    'ECR', 'MesDemandes',      4),
        ('Note_Frais_Liste',             N'Notes de frais',                         'ECR', 'MesDemandes',      5),
        -- Page routée par Ecran.tsx mais absente de menus.json (accès direct)
        ('Demande_Doc_Administratif_Liste', N'Demandes de documents administratifs','ECR', 'MesDemandes',      6),
        ('MesDeclarationsAT',            N'Déclarations d''accidents de travail',   'MNU', '',                 6),
        ('RH_Declaration_AT_Liste',      N'Accidents de travail',                   'ECR', 'MesDeclarationsAT',7),
        ('mesConsultations',             N'Consultations',                          'MNU', '',                 3),
        ('RH_Bulletin_Liste',            N'Edition de bulletins de paie',           'ECR', 'mesConsultations', 1),
        ('RH_Conge_Planning',            N'Planning des congés',                    'ECR', 'mesConsultations', 2),
        ('mesEvaluations',               N'Evaluations et formations',              'MNU', '',                 4),
        ('Evaluation_Liste',             N'Consultation des évaluations',           'ECR', 'mesEvaluations',   1),
        ('Formation_Evaluation_Liste',   N'Evaluation de Formation',                'ECR', 'mesEvaluations',   3),
        ('Formation_Liste',              N'Gestion des formations',                 'ECR', 'mesEvaluations',   2),
        ('Recrutement_fdr',              N'Recrutements',                           'MNU', '',                 5),
        ('Recrutement_Demande_Liste',    N'Demandes de recrutement',                'ECR', 'Recrutement_fdr',  1),
        ('Entretien',                    N'Entretiens',                             'ECR', 'Recrutement_fdr',  2),
        ('DiverseEditions',              N'Diverses éditions',                      'ECR', '',                 7),
        ('Discipline_fdr',               N'Discipline',                             'MNU', '',                 8),
        ('RH_Discipline_Liste',          N'Sanctions disciplinaires',               'ECR', 'Discipline_fdr',   1),
        ('Outillage',                    N'Outillage',                              'MNU', '',                 9),
        ('Outillage_Mouvement_Liste',    N'Mouvements Outillage',                   'ECR', 'Outillage',        1),
        ('Communication',                N'Communication',                          'MNU', '',                 10),
        ('Communication_Blogs_Liste',    N'Blogs',                                  'ECR', 'Communication',    1)
    ) v (Name_Ecran, Text_Ecran, Typ_Ecran, Menu_Parent, Rang)
)
INSERT INTO dbo.Controle_Menu_Portail (Name_Ecran, Text_Ecran, Typ_Ecran, Menu_Parent, Rang)
SELECT s.Name_Ecran, s.Text_Ecran, s.Typ_Ecran, s.Menu_Parent, s.Rang
FROM src s
WHERE NOT EXISTS (SELECT 1 FROM dbo.Controle_Menu_Portail m
                  WHERE m.Name_Ecran = s.Name_Ecran);
GO

/* ---- Vérification -------------------------------------------------------- */
SELECT 'RH_Agent.Cod_Profile' AS Element,
       CASE WHEN COL_LENGTH('dbo.RH_Agent','Cod_Profile') IS NULL THEN 'KO' ELSE 'OK' END AS Etat
UNION ALL SELECT 'Controle_Profile.Portail_Defaut',
       CASE WHEN COL_LENGTH('dbo.Controle_Profile','Portail_Defaut') IS NULL THEN 'KO' ELSE 'OK' END
UNION ALL SELECT 'UX_Controle_Profile_Portail_Defaut',
       CASE WHEN EXISTS (SELECT 1 FROM sys.indexes
                         WHERE name='UX_Controle_Profile_Portail_Defaut'
                           AND object_id=OBJECT_ID('dbo.Controle_Profile')) THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Controle_Menu_Portail',
       CASE WHEN OBJECT_ID('dbo.Controle_Menu_Portail','U') IS NULL THEN 'KO' ELSE 'OK' END
UNION ALL SELECT 'Controle_Menu_Portail (nb pages)',
       CASE WHEN (SELECT COUNT(*) FROM dbo.Controle_Menu_Portail) >= 30 THEN 'OK' ELSE 'KO' END;
GO
