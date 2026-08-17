/* ============================================================================
   RHP - Enregistrement de l'écran "Affectation des profils portail aux agents"
   (Admin_Profil_Agent) dans la section "Gestion des utilisateurs et des accès"
   (Folder6), à côté d'Admin_Users et Admin_Profile.
   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

-- 1) Arborescence du menu
IF NOT EXISTS (SELECT 1 FROM Controle_TreeView WHERE Name_Ecran = 'Admin_Profil_Agent')
    INSERT INTO Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Rang, Protege)
    VALUES ('Admin_Profil_Agent', N'Affectation des profils portail', 'ECR', 'Folder6', 2, 0);

-- 2) Définition du menu (jointure interne avec Controle_TreeView au chargement)
IF NOT EXISTS (SELECT 1 FROM Controle_Menu WHERE Name_Ecran = 'Admin_Profil_Agent')
    INSERT INTO Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Rang, Protege)
    VALUES ('Admin_Profil_Agent', N'Affectation des profils portail', 'ECR', 'ECR', 2, 0);

-- 3) Définition de l'écran
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran WHERE Name_Ecran = 'Admin_Profil_Agent')
    INSERT INTO Controle_Def_Ecran (Name_Ecran, Modal)
    VALUES ('Admin_Profil_Agent', 0);

-- 4) Boutons : Interroger + Enregistrer
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Button WHERE Name_Ecran = 'Admin_Profil_Agent' AND Cod_Button = 'Request_D')
    INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, ProcName, Img, Lib_Button, Width, Height, Rang)
    VALUES ('Admin_Profil_Agent', 'Request_D', 'Requesting', 'btn_request', N'Interroger', 25, 25, 1);

IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran_Button WHERE Name_Ecran = 'Admin_Profil_Agent' AND Cod_Button = 'Save_D')
    INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, ProcName, Img, Lib_Button, Width, Height, Rang)
    VALUES ('Admin_Profil_Agent', 'Save_D', 'Saving', 'btn_save', N'Enregistrer', 25, 25, 2);

-- 5) Droits : copie ceux d'Admin_Profile (écran réservé aux administrateurs)
INSERT INTO Controle_Droit (Cod_Profile, Name_Ecran, Visible, Actif, Consult, Modify, Delet)
SELECT d.Cod_Profile, 'Admin_Profil_Agent', d.Visible, d.Actif, d.Consult, d.Modify, d.Delet
FROM Controle_Droit d
WHERE d.Name_Ecran = 'Admin_Profile'
  AND NOT EXISTS (SELECT 1 FROM Controle_Droit x
                  WHERE x.Name_Ecran = 'Admin_Profil_Agent' AND x.Cod_Profile = d.Cod_Profile);
GO

SELECT 'Controle_TreeView' AS Element,
       CASE WHEN EXISTS (SELECT 1 FROM Controle_TreeView WHERE Name_Ecran='Admin_Profil_Agent') THEN 'OK' ELSE 'KO' END AS Etat
UNION ALL SELECT 'Controle_Menu',
       CASE WHEN EXISTS (SELECT 1 FROM Controle_Menu WHERE Name_Ecran='Admin_Profil_Agent') THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Controle_Def_Ecran',
       CASE WHEN EXISTS (SELECT 1 FROM Controle_Def_Ecran WHERE Name_Ecran='Admin_Profil_Agent') THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Controle_Def_Ecran_Button (2 boutons)',
       CASE WHEN (SELECT COUNT(*) FROM Controle_Def_Ecran_Button WHERE Name_Ecran='Admin_Profil_Agent') = 2 THEN 'OK' ELSE 'KO' END;
GO
