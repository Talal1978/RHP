import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";
export async function sousmettre_signature(
  Typ_Document: string,
  Valeur_Index: string,
  id_Societe: string,
  Matricule: string
) {
  await lireSql(
    `exec Sys_Workflow_Signature @typ_document,@id_Societe,@valeur_index, @matricule`,
    [
      { param: "typ_document", sqlType: NVarChar, valeur: Typ_Document },
      { param: "id_societe", sqlType: Int, valeur: id_Societe },
      { param: "valeur_index", sqlType: NVarChar, valeur: Valeur_Index },
      { param: "matricule", sqlType: NVarChar, valeur: Matricule },
    ]
  );
}
export async function get_signataires(req: Request, res: Response) {
  const { Typ_Document, Valeur_Index } = req.query;

  const { id_Societe } = req.params;
  const rsl = await lireSql(
    `select  Statut, Typ_Signature,Operande_Signature, Dans_Ordre, e.Num_Ligne, 
Signataire,isnull(a.Nom,u.Nom) as Nom, isnull(Decision,'') Decision, Dat_Signature , l.RowId, e.Statut , isnull(Commentaire,'')Commentaire 
from Signatures_Ent e left join Signatures_Lig l on e.Typ_Document=l.Typ_Document and e.id_Societe=l.id_Societe and e.Valeur_Index=l.Valeur_Index and e.Num_Ligne=l.Num_Ligne
outer apply (select ltrim(rtrim(isnull(Prenom_Agent,'')+' '+isnull(Nom_Agent,''))) as Nom from Rh_agent where Matricule=Signataire and id_Societe=e.id_Societe)a
outer apply (select ltrim(rtrim(isnull(Prenom_User,'')+' '+isnull(Nom_User,''))) as Nom from Controle_Users where Login_User=Signataire)u
where e.Typ_Document like @typ_document and e.id_Societe=@id_societe and e.Valeur_Index=@valeur_index 
order by RowId`,
    [
      { param: "typ_document", sqlType: NVarChar, valeur: Typ_Document },
      { param: "id_societe", sqlType: Int, valeur: id_Societe },
      { param: "valeur_index", sqlType: NVarChar, valeur: Valeur_Index },
    ]
  );
  return res.send(rsl);
}
export async function signer(req: Request, res: Response) {
  const { RowId, Commentaire, Decision } = req.body;
  const { id_Societe } = req.params;
  const rsl = await lireSql(
    `declare @Indx nvarchar(50), @TypDoc nvarchar(10)
    select top 1 @Indx=Valeur_Index, @TypDoc=Typ_Document from Signatures_Lig where RowId=@RowId
    update Signatures_Lig set Decision=@Decision, Dat_Signature=getdate(), Commentaire=@Commentaire where RowId=@RowId
    exec Sys_Workflow_Maj_Statut_Signature @TypDoc,@id_Societe,@Indx  
    select * from Signatures_Lig where RowId=@RowId`,
    [
      { param: "RowId", sqlType: Int, valeur: RowId },
      { param: "Decision", sqlType: NVarChar, valeur: Decision },
      { param: "Commentaire", sqlType: NVarChar, valeur: Commentaire },
      { param: "id_Societe", sqlType: Int, valeur: id_Societe },
    ]
  );

  res.send(rsl);
}
export async function get_parapheur(req: Request, res: Response) {
  const { id_Societe, Matricule } = req.params;
  const rsl =
    await lireSql(`select Intitule as 'Type de documents',Valeur_Index as Référence, case when Typ_Signature ='L' then 'Lignes' else 'Entête' end 'Type de signature',
  Operande_Signature as 'Opérande', t.Statut, Name_Ecran, Index_Ecran,Typ_Document from dbo.Sys_Parapheur_Signature('${Matricule}','${id_Societe}') s
  outer apply (select Membre as Statut from Param_Rubriques where Nom_Controle = 'Statut_Signature' and Valeur=s.Statut) t
  order by Intitule,Valeur_Index`);
  return res.send(rsl);
}
