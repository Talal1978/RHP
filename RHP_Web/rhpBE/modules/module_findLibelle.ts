import { Request, Response } from "express";
import { IsNull, handleIdSoc } from "./module_general";
import { lireSql } from "./module_sqlRW";
export async function findLibelle(
  champs: string,
  code: string,
  valeur: string,
  tblName: string,
  idSoc = ""
): Promise<any> {
  let CodSqlS = "";
  CodSqlS = `select top 1 ${champs} as libelle from ${tblName} where ${code}='${valeur}'`;
  CodSqlS = await handleIdSoc(CodSqlS, idSoc);
  const rsl = await lireSql(CodSqlS, []);
  if (rsl && rsl.result && rsl.data.length > 0) {
    return rsl.data[0]["libelle"];
  } else {
    return "";
  }
}
export async function findLibelleApi(
  req: Request,
  res: Response
): Promise<any> {
  const { champs, code, valeur, tblName } = req.body;
  const idSoc = IsNull(req.params.id_Societe, "3068");
  res.send(await findLibelle(champs, code, valeur, tblName, idSoc));
}
