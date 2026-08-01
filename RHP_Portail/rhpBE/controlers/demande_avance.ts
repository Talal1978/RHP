import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime, Int } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";

export async function demande_avance_liste(req: Request, res: Response) {
  let { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;
  if (controleInjection(Matricule).result === false) return res.send({ result: false, message: "Injection détectée dans Matricule" });
  if (controleInjection(Cod_Entite).result === false) return res.send({ result: false, message: "Injection détectée dans Entité" });
  if (controleInjection(Statut).result === false) return res.send({ result: false, message: "Injection détectée dans Statut" });

  const { processId, ...theAgent } = req.params;
  let idSocNum = Number(theAgent?.id_Societe || "3068");
  if (isNaN(idSocNum) || idSocNum <= 0) return res.send({ result: false, message: "id_Societe invalide" });

  if (!theAgent.TeamLeader) {
    Matricule = theAgent.Matricule;
    Cod_Entite = theAgent.Cod_Entite;
  }
  Dat_Du = estDate(Dat_Du)
    ? toSqlDateFormat(Dat_Du)
    : toSqlDateFormat(new Date(1900, 0, 1));
  Dat_Au = estDate(Dat_Au)
    ? toSqlDateFormat(Dat_Au)
    : toSqlDateFormat(new Date(2045, 11, 31));
  Statut = (Statut || "") + "%";
  let sqlStr = `SELECT TOP 50 case when isnull(Num_List_Avance,'')!='' then 'Saisie massive' else 'Demande' end as [Type],Num_Avance as 'N° demande', ${Matricule === theAgent.Matricule ? "Matricule,Nom, " : ""
    } dbo.FindRubrique('Statut_Signature',Statut) as Statut, Dat_Demande as 'Date', Montant_Avance as 'Montant demandé', Reglement 'Réglement', Commentaire, 
Traite as 'Traité', Paie_Calculee as 'Paie calculée',isnull(Num_List_Avance,'') as 'N° liste' 
   ${Cod_Entite === theAgent.Cod_Entite
      ? ""
      : ", isnull(Lib_Entite,'') as 'Entité'"
    }
  FROM RH_Paie_Avance v
   outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom, Cod_Entite from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
    outer apply (select Lib_Entite from Org_Entite where id_Societe=v.id_Societe and Cod_Entite=r.Cod_Entite) e
  where id_Societe=@p_idSoc and Matricule like '%'+@p_Matricule and Dat_Demande between @p_Dat_Du and @p_Dat_Au and isnull(Statut,'') like @p_Statut Order by [Date] desc`;
  const rsl = await lireSql(sqlStr, [
    { param: "p_idSoc", sqlType: Int, valeur: idSocNum },
    { param: "p_Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "p_Statut", sqlType: NVarChar, valeur: Statut },
    { param: "p_Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
    { param: "p_Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
  ]);
  res.send(rsl);
}

export async function get_mnt_avances_encours(req: Request, res: Response) {
  const { Matricule } = req.body;
  const { processId, ...theAgent } = req.params;
  let idSocNum = Number(theAgent.id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) return res.send({ result: false, message: "id_Societe invalide" });
  const sqlStr = `select isnull(mnt_avances_encours,0) as montant_avances_encours, isnull(DernierSalaire,0) as dernier_salaire from 
RH_Agent a 
outer apply (select SalNet,Avance from RH_Param_Plan_Paie where Cod_Plan_Paie=a.Plan_Paie and id_Societe=a.id_Societe ) p
outer apply (select sum(isnull(Montant_Avance,0)-isnull(Reglement,0)) as mnt_avances_encours from RH_Paie_Avance where id_Societe=a.id_Societe and Matricule=a.Matricule)v
outer apply (select top 1 Cod_Preparation as LastPaie from RH_Preparation_Paie_Detail where id_Societe=a.id_Societe and Matricule=a.Matricule order by Cod_Preparation desc)lp
outer apply (select sum(Valeur) as DernierSalaire
		from RH_Preparation_Paie_Detail where id_Societe=a.id_Societe and Matricule=a.Matricule and (Cod_Rubrique = isnull(p.SalNet,'') 
		or Cod_Rubrique=isnull(p.Avance,'')) and Cod_Preparation=LastPaie ) sn
where id_Societe=@p_idSoc and Matricule=@p_Matricule`;
  return res.send(await lireSql(sqlStr, [
    { param: "p_idSoc", sqlType: Int, valeur: idSocNum },
    { param: "p_Matricule", sqlType: NVarChar, valeur: Matricule },
  ]));
}

export async function get_demande_avance(req: Request, res: Response) {
  const { num_avance } = req.body;
  const { processId, ...theAgent } = req.params;
  let idSocNum = Number(theAgent.id_Societe || "3068");
  if (isNaN(idSocNum) || idSocNum <= 0) return res.send({ result: false, message: "id_Societe invalide" });
  let sqlStr = `SELECT   Num_Avance,
  Matricule,
  Dat_Demande,
  Montant_Avance,
  Dernier_Salaire,
  Commentaire,
  Statut FROM RH_Paie_Avance where  Num_Avance=@p_num_avance and id_Societe=@p_idSoc`;
  return res.send(
    await lireSql(sqlStr, [
      { param: "p_num_avance", sqlType: NVarChar, valeur: num_avance },
      { param: "p_idSoc", sqlType: Int, valeur: idSocNum },
    ])
  );
}

export async function save_demande_avance(req: Request, res: Response) {
  const { entete: _entete } = req.body;
  const { id_Societe, Matricule } = req.params;
  let idSocNum = Number(id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) return res.send({ result: false, message: "id_Societe invalide" });
  let { Num_Avance, ...entete } = _entete;
  const annee = new Date().getFullYear();
  if (!Num_Avance || Num_Avance === "") {
    const prefix = `AV${idSocNum}-${annee}`;
    const rsNum = await lireSql(
      `select @p_prefix+right('000000'+convert(nvarchar(6),isnull(max(racine),0)+1),6) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from RH_Paie_Avance 
    outer apply(select RIGHT(Num_Avance,6) as racine)n
    where id_Societe=@p_idSoc and year(Dat_Demande)=@p_annee)f`,
      [
        { param: "p_prefix", sqlType: NVarChar, valeur: prefix },
        { param: "p_idSoc", sqlType: Int, valeur: idSocNum },
        { param: "p_annee", sqlType: Int, valeur: annee },
      ]
    );
    Num_Avance = rsNum?.data?.[0]?.racine;
  }
  const rsEnt = await ecrireSql({
    tableName: "RH_Paie_Avance",
    fields: { ...entete, Num_Avance, id_Societe: String(idSocNum) },
    joinFields: ["Num_Avance", "id_Societe"],
    excludeFields: [],
    login: Matricule,
  });
  if (rsEnt.result) {
    if (entete.Statut === "SS")
      await sousmettre_signature("AV", Num_Avance, String(idSocNum), Matricule);
    return res.send(rsEnt);
  }
}

export async function delete_demande_avance(req: Request, res: Response) {
  const { Num_Avance } = req.body;
  const { id_Societe } = req.params;
  let idSocNum = Number(id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) return res.send({ result: false, message: "id_Societe invalide" });
  const rsl = await lireSql(
    `delete from RH_Paie_Avance where Num_Avance=@p_Num_Avance and id_Societe=@p_idSoc`,
    [
      { param: "p_Num_Avance", sqlType: NVarChar, valeur: Num_Avance },
      { param: "p_idSoc", sqlType: Int, valeur: idSocNum },
    ]
  );
  if (rsl.result) {
    return res.send({ result: true, data: Num_Avance });
  } else return res.send({ result: false, data: rsl.sort });
}
