import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { lireSql } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime, Int } from "mssql";
export const bulletin_liste = async (req: Request, res: Response) => {
  let { Matricule, Dat_Du, Dat_Au } = req.body;
  const { processId, ...theAgent } = req.params;
  const idSocNum = Number(theAgent?.id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    res.send({ result: false, message: "id_Societe invalide" });
    return;
  }
  if (!theAgent.TeamLeader) {
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
where exists(select Matricule from RH_Preparation_Paie_Detail d where e.Cod_Preparation=d.Cod_Preparation and e.id_Societe=d.id_Societe and Matricule=@p_Matricule)
and isnull(Cloture,'false')='true'
and id_Societe=@p_id_Societe
and Dat_Deb_Periode between isnull(@p_Dat_Du,'01/01/2000') and isnull(@p_Dat_Au,'31/12/2050') Order by [Année],[Mois] desc`;
  const rsl = await lireSql(sqlStr, [
    { param: "p_Matricule", sqlType: NVarChar, valeur: Matricule },
    { param: "p_Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
    { param: "p_Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
    { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
  ]);
  res.send(rsl);
};

export async function get_note_frais(req: Request, res: Response) {
  const { num_nf } = req.body;
  const { processId, ...theAgent } = req.params;
  const idSocNum = Number(theAgent.id_Societe);
  if (isNaN(idSocNum) || idSocNum <= 0) {
    res.send({ result: false, message: "id_Societe invalide" });
    return;
  }
  let sqlStr = `SELECT   *
    FROM Rh_Note_Frais where  Num_NF=@p_num_nf and id_Societe=@p_id_Societe`;
  const rsl = await lireSql(sqlStr, [
    { param: "p_num_nf", sqlType: NVarChar, valeur: num_nf },
    { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
  ]);
  if (rsl.result) {
    sqlStr = `select Typ_Frais, Base, Tx, Mnt, Comment, RowId
      from Rh_Note_Frais_Detail f 
      where Num_NF=@p_num_nf and id_Societe=@p_id_Societe`;
    const rslDetail = await lireSql(sqlStr, [
      { param: "p_num_nf", sqlType: NVarChar, valeur: num_nf },
      { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
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
