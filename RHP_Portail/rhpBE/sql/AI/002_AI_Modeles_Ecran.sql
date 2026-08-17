/* ============================================================================
   RHP - Assistant IA : ecran AI_Modeles (gestion des modeles LLM)
   ----------------------------------------------------------------------------
   La gestion des modeles LLM (table Ai_Agent, multi-modeles) est isolee dans
   un ecran separe AI_Modeles (menu 'Assistant AI', a cote de AI_KnowledgeBase
   qui ne garde que le procede d'embedding) :

     - Controle_Menu / Controle_Def_Ecran : enregistrement de l'ecran (copie
       des attributs de AI_KnowledgeBase) ;
     - Controle_Def_Ecran_Button : bouton 'Enregistrer' (Save_D -> Saving) ;
       le bouton Save_D de AI_KnowledgeBase est retire (rien a y enregistrer :
       la config embedding passe par le zoom Zoom_Ai_EmbeddingConfig) ;
     - Controle_TreeView : entree de menu dans le dossier 'Assistant AI' ;
     - Controle_Droit : memes regles d'acces que AI_KnowledgeBase.

   Idempotent : re-executable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

/* ---- 1. Ecran dans le referentiel (Controle_Menu) ------------------------- */
IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Menu WHERE Name_Ecran = 'AI_Modeles')
    INSERT INTO dbo.Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Image2, Rang, Ges_Sec, Menu_Parent, Flag_Maj, Protege, mobile, deskTop, web)
    SELECT 'AI_Modeles', N'Gestion des Modèles IA (LLM)', Typ_Ecran, Image1, Image2, Rang, Ges_Sec, Menu_Parent, Flag_Maj, Protege, mobile, deskTop, web
    FROM dbo.Controle_Menu WHERE Name_Ecran = 'AI_KnowledgeBase';

/* ---- 2. Definition de l'ecran (copie des attributs de AI_KnowledgeBase) --- */
IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = 'AI_Modeles')
    INSERT INTO dbo.Controle_Def_Ecran (Name_Ecran, Index_Ecran, Table_Ref, Index_Table, Num_Zoom, Description, Condition, Modal, PJ, Info)
    SELECT 'AI_Modeles', Index_Ecran, Table_Ref, Index_Table, Num_Zoom, Description, Condition, Modal, PJ, Info
    FROM dbo.Controle_Def_Ecran WHERE Name_Ecran = 'AI_KnowledgeBase';

/* ---- 3. Bouton 'Enregistrer' (Save_D -> Saving) ---------------------------- */
IF NOT EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran_Button
               WHERE Name_Ecran = 'AI_Modeles' AND Cod_Button = 'Save_D')
    INSERT INTO dbo.Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, Typ_Button, Typ_Security, Img, Width, Height, ProcName, Rang)
    VALUES ('AI_Modeles', 'Save_D', N'Enregistrer', 'STD', 'SC', 'btn_save', 25, 25, 'Saving', 1);

/* ---- 4. Entree dans l'arborescence du menu (dossier 'Assistant AI') ------- */
IF NOT EXISTS (SELECT 1 FROM dbo.Controle_TreeView WHERE Name_Ecran = 'AI_Modeles')
    INSERT INTO dbo.Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Tag, SMenu_Name, Rang, Protege, Flag_Maj)
    SELECT 'AI_Modeles', N'Gestion des Modèles IA (LLM)', 'ECR', Parent, Tag, SMenu_Name, 1, Protege, Flag_Maj
    FROM dbo.Controle_TreeView WHERE Name_Ecran = 'AI_KnowledgeBase';

/* ---- 5. Droits : memes regles d'acces que AI_KnowledgeBase ----------------- */
INSERT INTO dbo.Controle_Droit (Name_Ecran, Cod_Profile, Visible, Actif, Consult, Modify, Delet)
SELECT 'AI_Modeles', Cod_Profile, Visible, Actif, Consult, Modify, Delet
FROM dbo.Controle_Droit d
WHERE d.Name_Ecran = 'AI_KnowledgeBase'
  AND NOT EXISTS (SELECT 1 FROM dbo.Controle_Droit x
                  WHERE x.Name_Ecran = 'AI_Modeles' AND x.Cod_Profile = d.Cod_Profile);

/* ---- 6. AI_KnowledgeBase : retrait du bouton Enregistrer (embedding seul) - */
DELETE FROM dbo.Controle_Def_Ecran_Button
WHERE Name_Ecran = 'AI_KnowledgeBase' AND Cod_Button = 'Save_D';

COMMIT TRANSACTION;
GO

/* ---- Verification --------------------------------------------------------- */
SELECT 'Controle_Menu' AS Element, CASE WHEN EXISTS (SELECT 1 FROM dbo.Controle_Menu WHERE Name_Ecran='AI_Modeles') THEN 'OK' ELSE 'KO' END AS Etat
UNION ALL SELECT 'Controle_Def_Ecran', CASE WHEN EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran WHERE Name_Ecran='AI_Modeles') THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Bouton Save_D (AI_Modeles)', CASE WHEN EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran_Button WHERE Name_Ecran='AI_Modeles' AND Cod_Button='Save_D') THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Controle_TreeView', CASE WHEN EXISTS (SELECT 1 FROM dbo.Controle_TreeView WHERE Name_Ecran='AI_Modeles') THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Controle_Droit', CASE WHEN EXISTS (SELECT 1 FROM dbo.Controle_Droit WHERE Name_Ecran='AI_Modeles') THEN 'OK' ELSE 'KO' END
UNION ALL SELECT 'Save_D retire de AI_KnowledgeBase', CASE WHEN EXISTS (SELECT 1 FROM dbo.Controle_Def_Ecran_Button WHERE Name_Ecran='AI_KnowledgeBase' AND Cod_Button='Save_D') THEN 'KO' ELSE 'OK' END
UNION ALL SELECT 'Libelle menu (accents)', CASE WHEN EXISTS (SELECT 1 FROM dbo.Controle_TreeView WHERE Name_Ecran='AI_Modeles' AND Text_Ecran LIKE N'%Modèles%') THEN 'OK' ELSE 'KO' END;
GO
