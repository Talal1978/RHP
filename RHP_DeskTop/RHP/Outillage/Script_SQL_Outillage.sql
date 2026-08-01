/* ============================================================================
   RHP - Gestion des Outillages / Matériels
   Script d'installation SQL Server
   ----------------------------------------------------------------------------
   Contenu :
     1. Tables métier : RH_Outillage, RH_Outillage_Mouvement(+_Detail)
     2. Vues de disponibilité : RH_Outillage_Dispo, RH_Outillage_Agent
     3. Rubriques : Typ_Mouvement_Outillage (A=Affectation, R=Retrait)
     4. Zooms : MS210 (outillages), MS211 (disponibles), MS212 (détenus agent),
                MS213 (mouvements)
     5. Définition des écrans : Controle_Def_Ecran + Controle_Def_Ecran_Button
     6. Workflow : Param_Workflow_Typ_Document ('OT')
   ----------------------------------------------------------------------------
   Après exécution :
     - Lancer la "Génération globale" (Admin_TreeView) pour référencer les
       écrans dans le menu, puis les placer dans l'arborescence.
     - Paramétrer le circuit de signature du type 'OT' via l'écran
       "Workflow_Signatures" pour activer la gestion en Workflow.
     - Alimenter la rubrique "Typ_Outillage" (types de matériel) via l'écran
       des rubriques.
   ============================================================================ */

/* -------------------------------------------------------------------------- */
/* 1. Tables métier                                                            */
/* -------------------------------------------------------------------------- */
IF OBJECT_ID('dbo.RH_Outillage', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Outillage (
        Cod_Outillage  nvarchar(20)  NOT NULL,
        id_Societe     int           NOT NULL,
        Lib_Outillage  nvarchar(150) NULL,
        Typ_Outillage  nvarchar(50)  NULL,
        Num_Serie      nvarchar(50)  NULL,
        Qte_Initial    float         NULL,
        Dat_Crea       datetime      NULL,
        Created_By     nvarchar(50)  NULL,
        Dat_Modif      datetime      NULL,
        Modified_By    nvarchar(50)  NULL,
        CONSTRAINT PK_RH_Outillage PRIMARY KEY (Cod_Outillage, id_Societe)
    );
END
GO

IF OBJECT_ID('dbo.RH_Outillage_Mouvement', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Outillage_Mouvement (
        Num_Mouvement  nvarchar(20)  NOT NULL,
        id_Societe     int           NOT NULL,
        Typ_Mouvement  nvarchar(1)   NULL,   -- A = Affectation, R = Retrait
        Matricule      nvarchar(20)  NULL,
        Dat_Mouvement  datetime      NULL,
        Commentaire    nvarchar(500) NULL,
        Statut         nvarchar(3)   NULL,   -- '' brouillon, SS soumis, VA validé, SG signé, RJ rejeté
        Dat_Crea       datetime      NULL,
        Created_By     nvarchar(50)  NULL,
        Dat_Modif      datetime      NULL,
        Modified_By    nvarchar(50)  NULL,
        CONSTRAINT PK_RH_Outillage_Mouvement PRIMARY KEY (Num_Mouvement, id_Societe)
    );
END
GO

IF OBJECT_ID('dbo.RH_Outillage_Mouvement_Detail', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RH_Outillage_Mouvement_Detail (
        RowId          int IDENTITY(1,1) NOT NULL,
        Num_Mouvement  nvarchar(20)      NOT NULL,
        id_Societe     int               NOT NULL,
        Cod_Outillage  nvarchar(20)      NULL,
        Qte            float             NULL,
        CONSTRAINT PK_RH_Outillage_Mouvement_Detail PRIMARY KEY (RowId)
    );
END
GO

/* -------------------------------------------------------------------------- */
/* 2. Vues de disponibilité                                                    */
/*    Qté disponible = Qté initiale - Qté affectée + Qté retirée               */
/*    (les mouvements rejetés 'RJ' ne sont pas comptabilisés)                  */
/* -------------------------------------------------------------------------- */
IF OBJECT_ID('dbo.RH_Outillage_Dispo', 'V') IS NOT NULL DROP VIEW dbo.RH_Outillage_Dispo;
GO
CREATE VIEW dbo.RH_Outillage_Dispo AS
SELECT  o.id_Societe,
        o.Cod_Outillage,
        o.Lib_Outillage,
        o.Typ_Outillage,
        o.Num_Serie,
        o.Qte_Initial,
        o.Qte_Initial - ISNULL(mv.Qte_Affectee, 0) + ISNULL(mv.Qte_Retiree, 0) AS Qte_Disponible
FROM RH_Outillage o
OUTER APPLY (
    SELECT  SUM(CASE WHEN h.Typ_Mouvement = 'A' THEN d.Qte ELSE 0 END) AS Qte_Affectee,
            SUM(CASE WHEN h.Typ_Mouvement = 'R' THEN d.Qte ELSE 0 END) AS Qte_Retiree
    FROM RH_Outillage_Mouvement_Detail d
    INNER JOIN RH_Outillage_Mouvement h
        ON h.Num_Mouvement = d.Num_Mouvement AND h.id_Societe = d.id_Societe
    WHERE d.Cod_Outillage = o.Cod_Outillage
      AND d.id_Societe = o.id_Societe
      AND ISNULL(h.Statut, '') <> 'RJ'
) mv;
GO

IF OBJECT_ID('dbo.RH_Outillage_Agent', 'V') IS NOT NULL DROP VIEW dbo.RH_Outillage_Agent;
GO
CREATE VIEW dbo.RH_Outillage_Agent AS
SELECT  h.id_Societe,
        h.Matricule,
        d.Cod_Outillage,
        o.Lib_Outillage,
        o.Typ_Outillage,
        o.Num_Serie,
        SUM(CASE WHEN h.Typ_Mouvement = 'A' THEN d.Qte ELSE -d.Qte END) AS Qte_Detenus
FROM RH_Outillage_Mouvement_Detail d
INNER JOIN RH_Outillage_Mouvement h
    ON h.Num_Mouvement = d.Num_Mouvement AND h.id_Societe = d.id_Societe
INNER JOIN RH_Outillage o
    ON o.Cod_Outillage = d.Cod_Outillage AND o.id_Societe = d.id_Societe
WHERE ISNULL(h.Statut, '') <> 'RJ'
GROUP BY h.id_Societe, h.Matricule, d.Cod_Outillage, o.Lib_Outillage, o.Typ_Outillage, o.Num_Serie;
GO

/* -------------------------------------------------------------------------- */
/* 3. Rubriques                                                                */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Param_Rubriques WHERE Nom_Controle = 'Typ_Mouvement_Outillage' AND Valeur = 'A')
    INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By) VALUES ('Typ_Mouvement_Outillage', 'A', 'Affectation', 1, 'U', GETDATE(), 'SCRIPT');
IF NOT EXISTS (SELECT 1 FROM Param_Rubriques WHERE Nom_Controle = 'Typ_Mouvement_Outillage' AND Valeur = 'R')
    INSERT INTO Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Typ, Dat_Crea, Created_By) VALUES ('Typ_Mouvement_Outillage', 'R', 'Retrait', 2, 'U', GETDATE(), 'SCRIPT');
GO

/* -------------------------------------------------------------------------- */
/* 4. Zooms                                                                    */
/* -------------------------------------------------------------------------- */
DELETE FROM Controle_Def_Zoom WHERE Num_Zoom IN ('MS210', 'MS211', 'MS212', 'MS213');
GO
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS210', 'RH_Outillage', 'Cod_Outillage',
        'Lib_Outillage as [Désignation], Typ_Outillage as [Type], Num_Serie as [N° Série], Qte_Initial as [Qté Initiale]',
        'Cod_Outillage <> ''''', 1, 2, 'Asc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS211', 'RH_Outillage_Dispo', 'Cod_Outillage',
        'Lib_Outillage as [Désignation], Typ_Outillage as [Type], Num_Serie as [N° Série], Qte_Disponible as [Qté Disponible]',
        'Qte_Disponible > 0', 1, 2, 'Asc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS212', 'RH_Outillage_Agent', 'Cod_Outillage',
        'Lib_Outillage as [Désignation], Typ_Outillage as [Type], Num_Serie as [N° Série], Qte_Detenus as [Qté détenue]',
        'Qte_Detenus > 0', 1, 2, 'Asc', 'false');
INSERT INTO Controle_Def_Zoom (Num_Zoom, Table_Ref, Index_Table, Description, Condition, Order_By, Search_By, Order_By_Sens, Protege)
VALUES ('MS213', 'RH_Outillage_Mouvement', 'Num_Mouvement',
        'case Typ_Mouvement when ''A'' then ''Affectation'' else ''Retrait'' end as [Mouvement], Matricule, Dat_Mouvement as [Date], Statut',
        'Num_Mouvement <> ''''', 1, 1, 'Desc', 'false');
GO

/* -------------------------------------------------------------------------- */
/* 5. Définition des écrans et de leurs boutons                                */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran WHERE Name_Ecran = 'RH_Outillage')
    INSERT INTO Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
    VALUES ('RH_Outillage', 'RH_Outillage', 'Cod_Outillage_txt', 'MS210', 'Cod_Outillage', 'false', 'false', 'false', GETDATE(), 'SCRIPT');

IF NOT EXISTS (SELECT 1 FROM Controle_Def_Ecran WHERE Name_Ecran = 'RH_Outillage_Mouvement')
    INSERT INTO Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By)
    VALUES ('RH_Outillage_Mouvement', 'RH_Outillage_Mouvement', 'Num_Mouvement_txt', 'MS213', 'Num_Mouvement', 'false', 'false', 'false', GETDATE(), 'SCRIPT');
GO

DELETE FROM Controle_Def_Ecran_Button WHERE Name_Ecran IN ('RH_Outillage', 'RH_Outillage_Mouvement');
GO
-- Fiche référentiel Outillage / Matériel
-- NB : Typ_Security='SC' sur les boutons sensibles (Save/Del/Valide), vide sinon (convention Note_Frais / RH_Discipline)
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage', 'New_D',   'Nouveau',    'Nouveau',     'btn_add',       25, 25, 1, '');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage', 'Save_D',  'Enregistrer','Enregistrer', 'btn_save',      25, 25, 2, 'SC');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage', 'Del_D',   'Supprimer',  'Deleting',    'btn_delete',    25, 25, 3, 'SC');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage', 'First_D', 'Premier',    'Div_First',   'btn_div_first', 25, 25, 4, '');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage', 'Back_D',  'Précédent',  'Div_Back',    'btn_div_back',  25, 25, 5, '');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage', 'Next_D',  'Suivant',    'Div_Next',    'btn_div_next',  25, 25, 6, '');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage', 'Last_D',  'Dernier',    'Div_Last',    'btn_div_last',  25, 25, 7, '');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage', 'Request_D', 'Rafraîchir la liste', 'Requesting', 'btn_request', 25, 25, 8, '');
-- Fiche de gestion des outillages (affectation / retrait)
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage_Mouvement', 'New_D',    'Nouveau',    'Nouveau',     'btn_add',      25, 25, 1, '');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage_Mouvement', 'Save_D',   'Enregistrer','Enregistrer', 'btn_save',     25, 25, 2, 'SC');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage_Mouvement', 'Del_D',    'Supprimer',  'Deleting',    'btn_delete',   25, 25, 3, 'SC');
INSERT INTO Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, Lib_Button, ProcName, Img, Width, Height, Rang, Typ_Security) VALUES ('RH_Outillage_Mouvement', 'Valide_D', 'Valider',    'Valider',     'btn_validate', 25, 25, 4, 'SC');
GO

/* -------------------------------------------------------------------------- */
/* 5bis. Sécurité avancée des boutons (miroir de la Génération globale)        */
/*    Permet la gestion des droits et le verrouillage multi-utilisateurs       */
/*    (boutons désactivés si l'élément est en cours de modification)           */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='RH_Outillage' AND Name_Controle='Save_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('RH_Outillage', 'Save_D', 'Enregistrer', 'STD_Btn', 'SC', 1, 'Enregistrer', 'S', 1526879);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='RH_Outillage' AND Name_Controle='Del_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('RH_Outillage', 'Del_D', 'Supprimer', 'STD_Btn', 'SC', 1, 'Supprimer', 'S', 1526879);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='RH_Outillage_Mouvement' AND Name_Controle='Save_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('RH_Outillage_Mouvement', 'Save_D', 'Enregistrer', 'STD_Btn', 'SC', 1, 'Enregistrer', 'S', 1526879);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='RH_Outillage_Mouvement' AND Name_Controle='Del_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('RH_Outillage_Mouvement', 'Del_D', 'Supprimer', 'STD_Btn', 'SC', 1, 'Supprimer', 'S', 1526879);
IF NOT EXISTS (SELECT 1 FROM Controle_Menu_Avance WHERE Name_Ecran='RH_Outillage_Mouvement' AND Name_Controle='Valide_D')
    INSERT INTO Controle_Menu_Avance (Name_Ecran, Name_Controle, Text_Controle, Typ_Controle, Typ_Security, Gere_Security, InfoBulle, Source, Flag_Maj)
    VALUES ('RH_Outillage_Mouvement', 'Valide_D', 'Valider', 'STD_Btn', 'SC', 1, 'Valider', 'S', 1526879);
GO

/* -------------------------------------------------------------------------- */
/* 6. Workflow : déclaration du type de document                               */
/*    Le circuit de signataires se paramètre ensuite via Workflow_Signatures   */
/*    (Typ_Signature et Actif sont des colonnes de Workflow_Signatures)        */
/*    NB : Typ_Document est limité à 2 caractères                              */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Param_Workflow_Typ_Document WHERE Typ_Document = 'OT')
    INSERT INTO Param_Workflow_Typ_Document
        (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe)
    VALUES
        ('OT', 'Mouvement outillage / matériel', 'RH_Outillage_Mouvement', 'Num_Mouvement', 'false', 'RH_Outillage_Mouvement', 'Num_Mouvement_txt', 'Matricule', -1);
GO

/* -------------------------------------------------------------------------- */
/* 7. Menu : dossier dédié "Gestion des outillages et matériels"               */
/*    au même niveau que "Gestion des notes de frais" (Gestion administrative) */
/*    NB : alternativement, passer par Admin_TreeView + Génération globale.    */
/* -------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Controle_TreeView WHERE Name_Ecran='FDR1_20267291200000')
    INSERT INTO Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Tag, SMenu_Name, Rang, Protege, Flag_Maj, Created_By, Dat_Crea)
    VALUES ('FDR1_20267291200000', 'Gestion des outillages et matériels', 'FDR', 'FDR1_20197231657389', 'FDR', NULL, 8, 1, 63505, 'SCRIPT', GETDATE());
IF NOT EXISTS (SELECT 1 FROM Controle_Menu WHERE Name_Ecran='FDR1_20267291200000')
    INSERT INTO Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Image2, Rang, Ges_Sec, Menu_Parent, Flag_Maj, Protege, mobile, deskTop, web)
    VALUES ('FDR1_20267291200000', 'Gestion des outillages et matériels', 'FDR', 'FDR', NULL, 8, NULL, NULL, 63505, 1, NULL, NULL, NULL);

IF NOT EXISTS (SELECT 1 FROM Controle_TreeView WHERE Name_Ecran='RH_Outillage_Mouvement')
    INSERT INTO Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Tag, SMenu_Name, Rang, Protege, Flag_Maj, Created_By, Dat_Crea)
    VALUES ('RH_Outillage_Mouvement', 'Gestion des Outillages / Matériels', 'ECR', 'FDR1_20267291200000', 'Form', NULL, 0, 1, 1526879, 'SCRIPT', GETDATE());
IF NOT EXISTS (SELECT 1 FROM Controle_Menu WHERE Name_Ecran='RH_Outillage_Mouvement')
    INSERT INTO Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Image2, Rang, Ges_Sec, Menu_Parent, Flag_Maj, Protege, mobile, deskTop, web)
    VALUES ('RH_Outillage_Mouvement', 'Gestion des Outillages / Matériels', 'ECR', 'ECR', NULL, 0, NULL, NULL, 1526879, 1, NULL, NULL, NULL);

IF NOT EXISTS (SELECT 1 FROM Controle_TreeView WHERE Name_Ecran='RH_Outillage')
    INSERT INTO Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Tag, SMenu_Name, Rang, Protege, Flag_Maj, Created_By, Dat_Crea)
    VALUES ('RH_Outillage', 'Outillage / Matériel', 'ECR', 'FDR1_20267291200000', 'Form', NULL, 1, 1, 1526879, 'SCRIPT', GETDATE());
IF NOT EXISTS (SELECT 1 FROM Controle_Menu WHERE Name_Ecran='RH_Outillage')
    INSERT INTO Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Image2, Rang, Ges_Sec, Menu_Parent, Flag_Maj, Protege, mobile, deskTop, web)
    VALUES ('RH_Outillage', 'Outillage / Matériel', 'ECR', 'ECR', NULL, 1, NULL, NULL, 1526879, 1, NULL, NULL, NULL);
GO
