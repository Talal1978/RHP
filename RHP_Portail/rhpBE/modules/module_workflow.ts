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
export async function has_signature_rule(req: Request, res: Response) {
  const { Typ_Document } = req.query;
  const { id_Societe } = req.params;
  const idSocNum = Number(id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }
  // Même prédicat que l'application desktop (Module_Workflow) :
  // règle active = ligne Workflow_Signatures avec isnull(Actif,'false')='true'
  const rsl = await lireSql(
    `select case when exists(
        select 1 from Workflow_Signatures
        where Typ_Document=@typ_document and id_Societe=@id_societe and isnull(Actif,'false')='true'
     ) then 1 else 0 end as hasRule`,
    [
      { param: "typ_document", sqlType: NVarChar, valeur: String(Typ_Document ?? "") },
      { param: "id_societe", sqlType: Int, valeur: idSocNum },
    ]
  );
  return res.send({ result: rsl.result, hasRule: rsl.result === true && rsl.data?.[0]?.hasRule === 1 });
}
export async function get_signataires(req: Request, res: Response) {  const { Typ_Document, Valeur_Index } = req.query;

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

  // Contrôle métier : une évaluation (Typ_Document 'EV') ne peut pas être signée
  // si aucune réponse n'est enregistrée en base (Survey_Reply_Detail vide ou
  // en-tête inexistant). Valeur_Index est reconstruit comme côté front :
  // Cod_Evaluation + '_' + Evalue + '_' + Evaluateur.
  if (Decision === "SG") {
    const check = await lireSql(
      `declare @Indx nvarchar(200), @TypDoc nvarchar(10)
       select top 1 @Indx=Valeur_Index, @TypDoc=Typ_Document from Signatures_Lig where RowId=@RowId
       select @TypDoc as Typ_Document,
         (select top 1 (select count(*) from Survey_Reply_Detail d where d.Cod_Reply = r.Cod_Reply)
          from Survey_Reply r
          where r.id_Societe = @id_Societe and r.Typ_Evalue = 'E'
            and @Indx = r.Ref_Evaluation + '_' + r.Evalue + '_' + r.Evaluateur) as NbReponses`,
      [
        { param: "RowId", sqlType: Int, valeur: RowId },
        { param: "id_Societe", sqlType: Int, valeur: id_Societe },
      ]
    );
    const doc = check.data?.[0];
    if (check.result && doc?.Typ_Document === "EV" && !(Number(doc?.NbReponses) > 0)) {
      const msg = "Aucune réponse n'est enregistrée pour cette évaluation. Signature impossible.";
      return res.send({ result: false, data: [msg], message: msg });
    }
  }

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
  Operande_Signature as 'Opérande', t.Statut, Name_Ecran, Index_Ecran,Typ_Document from dbo.Sys_Parapheur_Signature(@p_Matricule,@p_id_Societe) s
  outer apply (select Membre as Statut from Param_Rubriques where Nom_Controle = 'Statut_Signature' and Valeur=s.Statut) t
  order by Intitule,Valeur_Index`,
    [
      { param: "p_Matricule", sqlType: NVarChar, valeur: Matricule },
      { param: "p_id_Societe", sqlType: Int, valeur: id_Societe },
    ]);
  return res.send(rsl);
}
