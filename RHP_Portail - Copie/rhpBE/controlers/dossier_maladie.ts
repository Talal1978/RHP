import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { ecrireSql, lireSql } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";
export async function dossier_maladie_liste(req: Request, res: Response) {
  let { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;
  const { processId, ...theAgent } = req.params;
  const TblRef = "RH_Dossier_Maladie";
  let idSoc = theAgent?.id_Societe || "3068";
  let MatriculeWhere = "";
  if (theAgent.TeamLeader) {
    MatriculeWhere = `exists(select Matricule from Rh_Agent _agt where id_Societe=${theAgent.id_Societe} and _agt.Cod_Entite in (
        select  Cod_Entite from Sys_Org_Entite s where 
                    ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif('${theAgent.Cod_Entite}',''),'8787uhuhunjj')+';%' and id_Societe=_agt.id_Societe))`;
  } else {
    MatriculeWhere = `(${TblRef}.id_Societe=${theAgent.id_Societe} and ${TblRef}.Matricule='${theAgent.Matricule}')`;
    Matricule = theAgent.Matricule;
    Cod_Entite = theAgent.Cod_Entite;
  }
  Dat_Du = estDate(Dat_Du)
    ? toSqlDateFormat(Dat_Du)
    : toSqlDateFormat(new Date(1900, 0, 1));
  Dat_Au = estDate(Dat_Au)
    ? toSqlDateFormat(Dat_Au)
    : toSqlDateFormat(new Date(2045, 11, 31));
  Statut = Statut || "";
  let sqlStr = `SELECT  Num_Dossier as 'N° demande', ${
    Matricule === theAgent.Matricule ? "Matricule,Nom, " : ""
  }Nom_Malade as 'Patient',dbo.FindRubrique('Statut_Signature',Statut) as Statut, Dat_Dossier as 'Date', Mnt_Engage as 'Montant engagé',Envoye_Le as 'Date envoi',
Mnt_Remboursement 'Remboursement', Rembourse_Le 'Date remboursement', 
Traite as 'Traité' ${
    Cod_Entite === theAgent.Cod_Entite
      ? ""
      : ", isnull(Lib_Entite,'') as 'Entité'"
  }
FROM RH_Dossier_Maladie v
 outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom, Cod_Entite from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
  outer apply (select Lib_Entite from Org_Entite where id_Societe=v.id_Societe and Cod_Entite=r.Cod_Entite) e
where id_Societe='${idSoc}' and Matricule like '%'+@Matricule and Dat_Dossier between @Dat_Du and @Dat_Au and isnull(Statut,'') like '${Statut}%' Order by [Date] desc`;
  const rsl = await lireSql(sqlStr, [
    { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "Statut", sqlType: NVarChar, valeur: Statut },
    { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
    { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
  ]);
  res.send(rsl);
}
export async function get_dossier_maladie(req: Request, res: Response) {
  const { Num_Dossier } = req.body;
  const { processId, ...theAgent } = req.params;
  let idSoc = theAgent.id_Societe || "3068";
  let sqlStr = `SELECT Num_Dossier,Matricule,Dat_Dossier,Nom_Malade,Lien,Typ_Maladie,Medecin,Mnt_Engage,convert(nvarchar(10),Envoye_Le,103) Envoye_Le,
  convert(nvarchar(10),Rembourse_Le,103) Rembourse_Le,Mnt_Remboursement,Commentaire,Statut,Traite
  FROM RH_Dossier_Maladie where  Num_Dossier=@Num_Dossier and id_Societe=${idSoc}`;
  const rsl = await lireSql(sqlStr, [
    {
      param: "Num_Dossier",
      sqlType: NVarChar,
      valeur: Num_Dossier,
    },
  ]);
  return res.send(rsl);
}
export async function save_dossier_maladie(req: Request, res: Response) {
  const { entete: _entete } = req.body;
  const { id_Societe, Matricule } = req.params;
  let { Num_Dossier, ...entete } = _entete;
  if (!Num_Dossier || Num_Dossier === "") {
    const rsNum = await lireSql(
      `select 'DM${id_Societe}-${new Date().getFullYear()}'+right('000000'+convert(nvarchar(6),isnull(max(racine),0)+1),6) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from RH_Dossier_Maladie 
    outer apply(select RIGHT(Num_Dossier,6) as racine)n
    where id_Societe=${id_Societe} and year(Dat_Dossier)=${new Date().getFullYear()})f`,
      []
    );
    Num_Dossier = rsNum?.data?.[0]?.racine;
  }
  const rsEnt = await ecrireSql({
    tableName: "RH_Dossier_Maladie",
    fields: { ...entete, Num_Dossier, id_Societe },
    joinFields: ["Num_Dossier", "id_Societe"],
    excludeFields: [],
    login: Matricule,
  });
  if (rsEnt.result) {
    if (entete.Statut === "SS")
      await sousmettre_signature("DM", Num_Dossier, id_Societe, Matricule);
    return res.send(rsEnt);
  }
}
export async function delete_dossier_maladie(req: Request, res: Response) {
  const { Num_Dossier } = req.body;
  const rsl = await lireSql(
    `delete from RH_Dossier_Maladie where Num_Dossier=@Num_Dossier and id_Societe='${req.params.id_Societe}'`,
    [{ param: "Num_Dossier", sqlType: NVarChar, valeur: Num_Dossier }]
  );
  if (rsl.result) {
    return res.send({ result: true, data: Num_Dossier });
  } else return res.send({ result: false, data: rsl.sort });
}
