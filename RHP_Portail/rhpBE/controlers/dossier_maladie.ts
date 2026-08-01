import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { ecrireSql, lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";
export async function dossier_maladie_liste(req: Request, res: Response) {
  let { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;
  const { processId, ...theAgent } = req.params;
  const TblRef = "RH_Dossier_Maladie";
  const idSocNum = Number(theAgent?.id_Societe || "3068");
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }
  if (theAgent.TeamLeader) {
    // MatriculeWhere supprime car non utilise dans la requete de liste
  } else {
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
  let sqlStr = `SELECT TOP 50 Num_Dossier as 'N° demande', ${
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
where id_Societe=@p_id_Societe and Matricule like '%'+@Matricule and Dat_Dossier between @Dat_Du and @Dat_Au and isnull(Statut,'') like @p_Statut + '%' Order by [Date] desc`;
  const rsl = await lireSql(sqlStr, [
    { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
    { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "p_Statut", sqlType: NVarChar, valeur: Statut },
    { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
    { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
  ]);
  res.send(rsl);
}
export async function get_dossier_maladie(req: Request, res: Response) {
  const { Num_Dossier } = req.body;
  const { processId, ...theAgent } = req.params;
  const idSocNum = Number(theAgent.id_Societe || "3068");
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }
  let sqlStr = `SELECT Num_Dossier,Matricule,Dat_Dossier,Nom_Malade,Lien,Typ_Maladie,Medecin,Mnt_Engage,convert(nvarchar(10),Envoye_Le,103) Envoye_Le,
  convert(nvarchar(10),Rembourse_Le,103) Rembourse_Le,Mnt_Remboursement,Commentaire,Statut,Traite
  FROM RH_Dossier_Maladie where  Num_Dossier=@Num_Dossier and id_Societe=@p_id_Societe`;
  const rsl = await lireSql(sqlStr, [
    {
      param: "Num_Dossier",
      sqlType: NVarChar,
      valeur: Num_Dossier,
    },
    { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
  ]);
  return res.send(rsl);
}
export async function save_dossier_maladie(req: Request, res: Response) {
  const { entete: _entete } = req.body;
  const { id_Societe, Matricule } = req.params;
  const idSocNum = Number(id_Societe || "3068");
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }
  const idSocStr = String(idSocNum);
  let { Num_Dossier, ...entete } = _entete;
  if (!Num_Dossier || Num_Dossier === "") {
    const currentYear = new Date().getFullYear();
    const rsNum = await lireSql(
      `select 'DM'+convert(nvarchar(10),@p_id_Societe)+'-'+convert(nvarchar(4),@p_year)+right('000000'+convert(nvarchar(6),isnull(max(racine),0)+1),6) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from RH_Dossier_Maladie 
    outer apply(select RIGHT(Num_Dossier,6) as racine)n
    where id_Societe=@p_id_Societe and year(Dat_Dossier)=@p_year)f`,
      [
        { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
        { param: "p_year", sqlType: Int, valeur: currentYear },
      ]
    );
    Num_Dossier = rsNum?.data?.[0]?.racine;
  }
  const rsEnt = await ecrireSql({
    tableName: "RH_Dossier_Maladie",
    fields: { ...entete, Num_Dossier, id_Societe: idSocStr },
    joinFields: ["Num_Dossier", "id_Societe"],
    excludeFields: [],
    login: Matricule,
  });
  if (rsEnt.result) {
    if (entete.Statut === "SS")
      await sousmettre_signature("DM", Num_Dossier, idSocStr, Matricule);
  }
  return res.send(rsEnt);
}
export async function delete_dossier_maladie(req: Request, res: Response) {
  const { Num_Dossier } = req.body;
  const idSocNum = Number(req.params.id_Societe || "3068");
  if (isNaN(idSocNum) || idSocNum <= 0) {
    return res.send({ result: false, message: "id_Societe invalide" });
  }
  const rsl = await lireSql(
    `delete from RH_Dossier_Maladie where Num_Dossier=@Num_Dossier and id_Societe=@p_id_Societe`,
    [
      { param: "Num_Dossier", sqlType: NVarChar, valeur: Num_Dossier },
      { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
    ]
  );
  if (rsl.result) {
    return res.send({ result: true, data: Num_Dossier });
  } else return res.send({ result: false, data: rsl.sort });
}
