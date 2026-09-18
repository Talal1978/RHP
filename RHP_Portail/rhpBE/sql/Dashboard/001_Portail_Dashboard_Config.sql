/* ============================================================================
   RHP - Configuration du tableau de bord du portail (widgets + sections)
   ----------------------------------------------------------------------------
   Persiste en base la configuration des widgets du tableau de bord du portail
   (jusqu'ici stockée uniquement dans le localStorage du navigateur) :

     - Typ_Config 'U' : configuration personnelle d'un agent
                        (Cle_Config = Matricule, id_Societe = société de
                        l'agent) — écrite par le portail à chaque
                        enregistrement du "WidgetBuilder" ;
     - Typ_Config 'P' : modèle par défaut d'un profil portail
                        (Cle_Config = Cod_Profile, id_Societe = -1 = toutes
                        sociétés) — alimenté depuis l'écran desktop
                        Admin_Dashboard_Config ;
     - Typ_Config 'G' : modèle global (Cle_Config = '*', id_Societe = -1)
                        — appliqué à tout utilisateur sans configuration
                        personnelle ni modèle de profil.

   Résolution à la lecture (backend portail, controler dashboard_config.ts) :
     U (matricule + société) > P (profil) > G (globale).
   Config_Json : { "widgets": [...UserDashboardWidget], "sections": [...] }
   (structures du hook rhpfe Pages/Dashboard/widgets/useDashboardWidgets.ts).

   L'écran desktop Admin_Dashboard_Config (duplication d'une configuration
   vers d'autres agents + gestion des modèles P/G) attaque directement cette
   table (voir RHP_DeskTop/RHP/Auth/Admin_Dashboard_Config_Menu.sql).

   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

/* ---- 1. Table de configuration ------------------------------------------ */
IF OBJECT_ID('dbo.Portail_Dashboard_Config', 'U') IS NULL
    CREATE TABLE dbo.Portail_Dashboard_Config (
        Typ_Config   char(1)       NOT NULL
            CONSTRAINT DF_Portail_Dashboard_Config_Typ DEFAULT ('U'),   -- U=utilisateur, P=profil, G=globale
        Cle_Config   nvarchar(50)  NOT NULL
            CONSTRAINT DF_Portail_Dashboard_Config_Cle DEFAULT (''),    -- Matricule / Cod_Profile / '*'
        id_Societe   int           NOT NULL
            CONSTRAINT DF_Portail_Dashboard_Config_Soc DEFAULT (-1),    -- société (U) ; -1 = toutes (modèles P/G)
        Config_Json  nvarchar(max) NOT NULL,
        Dat_Modif    datetime      NOT NULL
            CONSTRAINT DF_Portail_Dashboard_Config_DatModif DEFAULT (getdate()),
        Modified_By  nvarchar(50)  NOT NULL
            CONSTRAINT DF_Portail_Dashboard_Config_ModifiedBy DEFAULT (''),
        CONSTRAINT PK_Portail_Dashboard_Config
            PRIMARY KEY (Typ_Config, Cle_Config, id_Societe),
        CONSTRAINT CK_Portail_Dashboard_Config_Typ
            CHECK (Typ_Config IN ('U', 'P', 'G'))
    );

/* ---- 2. Modèle global par défaut (les 3 widgets standards, comme la -----
   ---- migration STD historique du localStorage : Accès rapide, -----------
   ---- Notifications, Actualités RH) -------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM dbo.Portail_Dashboard_Config
               WHERE Typ_Config = 'G' AND Cle_Config = '*' AND id_Societe = -1)
    INSERT INTO dbo.Portail_Dashboard_Config
        (Typ_Config, Cle_Config, id_Societe, Config_Json, Modified_By)
    VALUES
        ('G', '*', -1,
         N'{"widgets":[' +
         N'{"instanceId":"def_quickactions","widgetId":"list-quickactions","title":"Accès Rapide","type":"list","sourceType":"standard","standardId":"quickActions","icon":"Apps","color":"#2e7d32","span":6,"position":0},' +
         N'{"instanceId":"def_notifications","widgetId":"list-notifications","title":"À faire & Notifications","type":"list","sourceType":"standard","standardId":"notifications","icon":"NotificationsOutlined","color":"#8e24aa","span":6,"position":1},' +
         N'{"instanceId":"def_blogs","widgetId":"list-blogs","title":"Actualités RH","type":"list","sourceType":"standard","standardId":"blogs","icon":"Newspaper","color":"#1976d2","span":12,"position":2}],' +
         N'"sections":[]}',
         N'migration');

COMMIT TRANSACTION;
GO

SELECT CASE WHEN OBJECT_ID('dbo.Portail_Dashboard_Config', 'U') IS NOT NULL THEN 'OK' ELSE 'KO' END
       AS [Table Portail_Dashboard_Config],
       (SELECT COUNT(*) FROM dbo.Portail_Dashboard_Config WHERE Typ_Config = 'G') AS [Modèle global];
GO
