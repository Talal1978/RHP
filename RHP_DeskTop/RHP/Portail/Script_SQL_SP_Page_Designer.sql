/* ============================================================================
   RHP - Designer de pages portail (module SP_)
   Script d'enregistrement de l'écran SP_Page_Designer dans RHP_DeskTop
   ----------------------------------------------------------------------------
    - Écran rattaché à : Système / Utilitaires avancés (résolu dynamiquement)
      - Boutons : Nouveau / Enregistrer / Supprimer / Dupliquer / Aperçu DDL / Publier / Aide (F1)
                  / Exporter JSON / Importer JSON (transfert de la configuration
                  d'une page entre environnements, HORS habilitations)
                  / Assistant IA (chat : questions sur l'aide intégrée +
                  génération du JSON d'une page via le skill
                  rsc\rhp-portal-page-deployer.zip — Zoom_SP_Assistant_IA)
    - Droits : profil super-admin (1) par défaut ; à étendre via Admin_Profile
    Prérequis : 001_SP_Designer_Metadata.sql exécuté (tables Controle_Designer*).
    ============================================================================ */

/* -------------------------------------------------------------------------- */
/* 1. Définition de l'écran et de ses boutons                                 */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran WHERE Name_Ecran = 'SP_Page_Designer')
    INSERT INTO Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
    VALUES ('SP_Page_Designer', 'Controle_Designer', 'Cod_Page_txt', '', 'Cod_Page', 'false', 'false', 'true', GETDATE(), 'SCRIPT');
GO

DELETE FROM Controle_Def_Ecran_Button WHERE Name_Ecran = 'SP_Page_Designer';
GO
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES
    ('SP_Page_Designer', 'New_D',   'Nouveau',            'Nouveau',     'btn_add',       25, 25, 1, ''),
    ('SP_Page_Designer', 'Save_D',  'Enregistrer',        'Enregistrer', 'btn_save',      25, 25, 2, 'SC'),
    ('SP_Page_Designer', 'Help_D',  'Aide',               'Aide',        'btn_help',      25, 25, 3, ''),
    ('SP_Page_Designer', 'Del_D',   'Supprimer',          'Deleting',    'btn_delete',    25, 25, 4, 'SC'),
    ('SP_Page_Designer', 'Dupliquer_D', 'Dupliquer',      'Dupliquer',   'btn_duplicate', 25, 25, 5, 'SC'),
    ('SP_Page_Designer', 'Exec_D',  'Aperçu DDL',         'ApercuDDL',   'btn_request',   25, 25, 6, ''),
    ('SP_Page_Designer', 'Publi_D', 'Publier / Désactiver', 'Publier',   'btn_validate',  25, 25, 7, 'SC'),
    ('SP_Page_Designer', 'ExportJson_D', 'Exporter JSON', 'ExporterJson', 'btn_save_doc', 25, 25, 8, ''),
    ('SP_Page_Designer', 'ImportJson_D', 'Importer JSON', 'ImporterJson', 'btn_import',   25, 25, 9, 'SC'),
    ('SP_Page_Designer', 'AssistantIA_D', 'Assistant IA', 'AssistantIA', 'btn_analyse',  25, 25, 10, '');
GO

/* -------------------------------------------------------------------------- */
/* 2. Menu : Système / Utilitaires avancés                                    */
/*    (inséré AVANT Controle_Menu_Avance : FK_Menu_Avance -> Controle_Menu)   */
/* -------------------------------------------------------------------------- */
DECLARE @Parent NVARCHAR(60);
SELECT TOP 1 @Parent = Name_Ecran
FROM Controle_TreeView
WHERE Typ_Ecran = 'FDR' AND Text_Ecran LIKE N'%Utilitaires avanc%';
IF @Parent IS NULL SET @Parent = '4';   -- repli : racine "Système"

IF NOT EXISTS (SELECT 1 FROM Controle_TreeView WHERE Name_Ecran='SP_Page_Designer')
    INSERT INTO Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Tag, SMenu_Name, Rang, Protege, Flag_Maj, Created_By, Dat_Crea)
    SELECT 'SP_Page_Designer', N'Designer de pages portail', 'ECR', @Parent, 'Form', NULL, 99, 1, 1526881, 'SCRIPT', GETDATE();
IF NOT EXISTS (SELECT 1 FROM Controle_Menu WHERE Name_Ecran='SP_Page_Designer')
    INSERT INTO Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Image2, Rang, Ges_Sec, Menu_Parent, Flag_Maj, Protege, mobile, deskTop, web)
    VALUES ('SP_Page_Designer', N'Designer de pages portail', 'ECR', 'ECR', NULL, 99, NULL, NULL, 1526881, 1, NULL, NULL, NULL);
GO

/* -------------------------------------------------------------------------- */
/* 3. Sécurité avancée des boutons                                            */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='SP_Page_Designer' AND Name_Controle='Save_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('SP_Page_Designer', 'Save_D', 'Enregistrer', 'STD_Btn', 'SC', 1, 'Enregistrer (crée/migre les tables SP_)', 'S', 1526881);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='SP_Page_Designer' AND Name_Controle='Del_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('SP_Page_Designer', 'Del_D', 'Supprimer', 'STD_Btn', 'SC', 1, 'Supprimer (brouillon sans document uniquement)', 'S', 1526881);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='SP_Page_Designer' AND Name_Controle='Dupliquer_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('SP_Page_Designer', 'Dupliquer_D', 'Dupliquer', 'STD_Btn', 'SC', 1, 'Dupliquer le paramétrage sous une nouvelle identité (écrit à l''enregistrement)', 'S', 1526881);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='SP_Page_Designer' AND Name_Controle='Publi_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('SP_Page_Designer', 'Publi_D', 'Publier / Désactiver', 'STD_Btn', 'SC', 1, 'Publier la page sur le portail', 'S', 1526881);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='SP_Page_Designer' AND Name_Controle='Help_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('SP_Page_Designer', 'Help_D', 'Aide', 'STD_Btn', '', 1, 'Aide du Designer de pages (F1) : guide complet indexé avec recherche', 'S', 1526881);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='SP_Page_Designer' AND Name_Controle='ImportJson_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('SP_Page_Designer', 'ImportJson_D', 'Importer JSON', 'STD_Btn', 'SC', 1, 'Importer une configuration de page (JSON) dans le Designer — écrite en base par ''Enregistrer'' uniquement ; habilitations jamais importées', 'S', 1526881);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='SP_Page_Designer' AND Name_Controle='ExportJson_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('SP_Page_Designer', 'ExportJson_D', 'Exporter JSON', 'STD_Btn', '', 1, 'Exporter la configuration de la page au format JSON (RHP_PAGE_DESIGNER) — habilitations jamais exportées', 'S', 1526881);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='SP_Page_Designer' AND Name_Controle='AssistantIA_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('SP_Page_Designer', 'AssistantIA_D', 'Assistant IA', 'STD_Btn', '', 1, 'Assistant IA du Designer : questions sur l''aide intégrée ou génération du fichier JSON d''une page (skill rhp-portal-page-deployer) — import ensuite via ''Importer JSON''', 'S', 1526881);
GO

/* -------------------------------------------------------------------------- */
/* 4. Droits : super-admin par défaut                                         */
/*    Étendre ensuite aux profils autorisés via l'écran Admin_Profile.        */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Controle_Droit WHERE Cod_Profile = '1' AND Name_Ecran = 'SP_Page_Designer')
    INSERT INTO Controle_Droit (Cod_Profile, Name_Ecran, Visible, Actif, Consult, Modify, Delet)
    VALUES ('1', 'SP_Page_Designer', 'true', 'true', 'true', 'true', 'true');
GO

SELECT Name_Ecran, Text_Ecran, Typ_Ecran, Parent
FROM Controle_TreeView
WHERE Name_Ecran = 'SP_Page_Designer';
