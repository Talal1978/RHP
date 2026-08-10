-- Enregistrement de l'écran "Planning des congés" (RH_Conge_Planning)
-- dans la section "Gestion des congés" (FDR1_201910151010501)

-- 1) Arborescence du menu
if not exists (select 1 from Controle_TreeView where Name_Ecran = 'RH_Conge_Planning')
    insert into Controle_TreeView (Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Rang, Protege)
    values ('RH_Conge_Planning', N'Planning des congés', 'ECR', 'FDR1_201910151010501', 3, 0);

-- 2) Définition du menu (jointure interne avec Controle_TreeView dans le chargement)
if not exists (select 1 from Controle_Menu where Name_Ecran = 'RH_Conge_Planning')
    insert into Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1, Rang, Protege)
    values ('RH_Conge_Planning', N'Planning des congés', 'ECR', 'ECR', 3, 0);

-- 3) Droits : copie ceux de "Liste des demandes de congé"
insert into Controle_Droit (Cod_Profile, Name_Ecran, Visible, Actif, Consult, Modify, Delet)
select d.Cod_Profile, 'RH_Conge_Planning', d.Visible, d.Actif, d.Consult, d.Modify, d.Delet
from Controle_Droit d
where d.Name_Ecran = 'RH_Demande_Conge_Liste'
  and not exists (select 1 from Controle_Droit x
                  where x.Name_Ecran = 'RH_Conge_Planning' and x.Cod_Profile = d.Cod_Profile);

-- 4) Définition de l'écran
if not exists (select 1 from Controle_Def_Ecran where Name_Ecran = 'RH_Conge_Planning')
    insert into Controle_Def_Ecran (Name_Ecran, Modal)
    values ('RH_Conge_Planning', 0);

-- 5) Bouton "Interroger"
if not exists (select 1 from Controle_Def_Ecran_Button where Name_Ecran = 'RH_Conge_Planning' and Cod_Button = 'Request_D')
    insert into Controle_Def_Ecran_Button (Name_Ecran, Cod_Button, ProcName, Img, Lib_Button, Width, Height, Rang)
    values ('RH_Conge_Planning', 'Request_D', 'Requesting', 'btn_request', N'Interroger', 25, 25, 1);
