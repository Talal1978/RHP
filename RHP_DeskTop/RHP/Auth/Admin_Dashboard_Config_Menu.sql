/* ============================================================================
   RHP - Enregistrement de l'écran "Configuration du tableau de bord du
   portail" (Admin_Dashboard_Config) dans la section "Gestion des utilisateurs
   et des accès" (Folder6), à côté d'Admin_Users, Admin_Profile et
   Admin_Profil_Agent.

   L'écran duplique la configuration du tableau de bord du portail (table
   Portail_Dashboard_Config — migration
   RHP_Portail/rhpBE/sql/Dashboard/001_Portail_Dashboard_Config.sql) d'un
   agent source vers d'autres agents, et l'enregistre comme modèle par
   défaut (global ou par profil).

   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

-- 1) Arborescence du menu
IF NOT EXISTS (SELECT 1 FROM Controle_TreeView WHERE Name_Ecran = 'Admin_Dashboard_Config')
    INSERT INTO Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Rang, Protege)
    VALUES ('Admin_Dashboard_Config', N'Configuration du tableau de bord portail', 'ECR', 'Folder6', 3, 0);

-- 2) Définition du menu (jointure interne avec Controle_TreeView au chargement)
IF NOT EXISTS (SELECT 1 FROM Controle_Menu WHERE Name_Ecran = 'Admin_Dashboard_Config')
    INSERT INTO Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Rang, Protege)
    VALUES ('Admin_Dashboard_Config', N'Configuration du tableau de bord portail', 'ECR', 'ECR', 3, 0);

-- 3) Définition de l'écran
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran WHERE Name_Ecran = 'Admin_Dashboard_Config')
    INSERT INTO Controle_Def_Ecran (Name_Ecran, Modal)
    VALUES ('Admin_Dashboard_Config', 0);

-- 4) Boutons : Interroger + Dupliquer la configuration + Enregistrer comme modèle
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Button WHERE Name_Ecran = 'Admin_Dashboard_Config' AND Cod_Button = 'Request_D')
    INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, ProcName, Img, Lib_Button, Width, Height, Rang)
    VALUES ('Admin_Dashboard_Config', 'Request_D', 'Requesting', 'btn_request', N'Interroger', 25, 25, 1);

IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Button WHERE Name_Ecran = 'Admin_Dashboard_Config' AND Cod_Button = 'Save_D')
    INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, ProcName, Img, Lib_Button, Width, Height, Rang)
    VALUES ('Admin_Dashboard_Config', 'Save_D', 'Saving', 'btn_duplicate', N'Dupliquer la configuration', 25, 25, 2);

IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Button WHERE Name_Ecran = 'Admin_Dashboard_Config' AND Cod_Button = 'Model_D')
    INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, ProcName, Img, Lib_Button, Width, Height, Rang)
    VALUES ('Admin_Dashboard_Config', 'Model_D', 'SavingModel', 'btn_save', N'Enregistrer comme modèle', 25, 25, 3);

-- 5) Droits : copie ceux d'Admin_Profile (écran réservé aux administrateurs)
INSERT INTO Controle_Droit (Cod_Profile, Name_Ecran, Visible, Actif, Consult, Modify, Delet)
SELECT d.Cod_Profile, 'Admin_Dashboard_Config', d.Visible, d.Actif, d.Consult, d.Modify, d.Delet
FROM Controle_Droit d
WHERE d.Name_Ecran = 'Admin_Profile'
  AND NOT EXISTS (SELECT 1 FROM Controle_Droit x
                  WHERE x.Name_Ecran = 'Admin_Dashboard_Config' AND x.Cod_Profile = d.Cod_Profile);
GO

SELECT 'Controle_TreeView' AS Element,
       CASE WHEN EXISTS (SELECT 1 FROM Controle_TreeView WHERE Name_Ecran='Admin_Dashboard_Config') THEN 'OK' ELSE 'KO' END AS Etat
UNION ALL SELECT 'Controle_Menu',
       CASE WHEN EXISTS (SELECT 1 FROM Controle_Menu WHERE Name_Ecran='Admin_Dashboard_Config') THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Controle_Def_Ecran',
       CASE WHEN EXISTS (SELECT 1 FROM Controle_Def_Ecran WHERE Name_Ecran='Admin_Dashboard_Config') THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Controle_Def_Ecran_Button (3 boutons)',
       CASE WHEN (SELECT COUNT(*) FROM Controle_Def_Ecran_Button WHERE Name_Ecran='Admin_Dashboard_Config') = 3 THEN 'OK' ELSE 'KO' END;
GO
