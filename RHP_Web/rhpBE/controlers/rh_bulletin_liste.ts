import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { lireSql } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime } from "mssql";
export const bulletin_liste = async (req: Request, res: Response) => {
  let { Matricule, Dat_Du, Dat_Au } = req.body;
  const { processId, ...theAgent } = req.params;
  const TblRef = "RH_Agent";
  let idSoc = theAgent?.id_Societe || "0000";
  let MatriculeWhere = "";
  if (theAgent.TeamLeader) {
    MatriculeWhere = `exists(select Matricule from Rh_Agent _agt where id_Societe=${theAgent.id_Societe} and _agt.Cod_Entite in (
          select  Cod_Entite from Sys_Org_Entite s where 
                      ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif('${theAgent.Cod_Entite}',''),'8787uhuhunjj')+';%' and id_Societe=_agt.id_Societe))`;
  } else {
    MatriculeWhere = `(${TblRef}.id_Societe=${theAgent.id_Societe} and ${TblRef}.Matricule='${theAgent.Matricule}')`;
    Matricule = theAgent.Matricule;
  }
  Dat_Du = estDate(Dat_Du)
    ? toSqlDateFormat(Dat_Du)
    : toSqlDateFormat(new Date(1900, 0, 1));
  Dat_Au = estDate(Dat_Au)
    ? toSqlDateFormat(Dat_Au)
    : toSqlDateFormat(new Date(2045, 11, 31));
  let sqlStr = `select  Cod_Preparation as Préparation, Annee_Paie as 'Année', Mois_Paie as 'Mois' 
from RH_Preparation_Paie e
where exists(select Matricule from RH_Preparation_Paie_Detail d where e.Cod_Preparation=d.Cod_Preparation and e.id_Societe=d.id_Societe and Matricule=@Matricule)
and isnull(Cloture,'false')='true'
and id_Societe=${idSoc}
and Dat_Deb_Periode between isnull(@Dat_Du,'01/01/2000') and isnull(@Dat_Au,'31/12/2050') Order by [Année],[Mois] desc`;
  const rsl = await lireSql(sqlStr, [
    { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
    { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
  ]);
  res.send(rsl);
};

export async function get_note_frais(req: Request, res: Response) {
  const { num_nf } = req.body;
  const { processId, ...theAgent } = req.params;
  let idSoc = theAgent.id_Societe || "3068";
  let sqlStr = `SELECT   *
    FROM Rh_Note_Frais where  Num_NF=@num_nf and id_Societe=${idSoc}`;
  const rsl = await lireSql(sqlStr, [
    { param: "num_nf", sqlType: NVarChar, valeur: num_nf },
  ]);
  if (rsl.result) {
    sqlStr = `select Typ_Frais, Base, Tx, Mnt, Comment, RowId
      from Rh_Note_Frais_Detail f 
      where Num_NF=@num_nf and id_Societe=${idSoc}`;
    const rslDetail = await lireSql(sqlStr, [
      { param: "num_nf", sqlType: NVarChar, valeur: num_nf },
    ]);
    if (rslDetail.result) {
      res.send({ result: true, entete: rsl.data[0], detail: rslDetail.data });
      return;
    } else {
      res.send({ result: true, entete: rsl.data[0], detail: [] });
      return;
    }
  } else {
    res.send({ result: false, entete: {}, detail: [], message: rsl.sort });
    return;
  }
}
