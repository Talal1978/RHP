import { Request, Response } from "express";
import { IsNull, handleIdSoc } from "./module_general";
import { controleInjection, lireSql } from "./module_sqlRW";
import { NVarChar } from "mssql";
export async function findLibelle(
  champs: string,
  code: string,
  valeur: string,
  tblName: string,
  idSoc = ""
): Promise<any> {
  if (controleInjection(champs).result === false) return "";
  if (controleInjection(code).result === false) return "";
  if (controleInjection(tblName).result === false) return "";
  let CodSqlS = "";
  CodSqlS = `select top 1 ${champs} as libelle from ${tblName} where ${code}=@p_valeur`;
  CodSqlS = await handleIdSoc(CodSqlS, idSoc);
  const rsl = await lireSql(CodSqlS, [
    { param: "p_valeur", sqlType: NVarChar, valeur: String(IsNull(valeur, "")) },
  ]);
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
  // La route est derrière le middleware validate (module_jwt) : la société
  // vient du JWT de l'agent connecté, jamais d'une valeur codée en dur
  // (le défaut "3068" excluait les agents des autres sociétés — ex. RHP_FH2).
  const idSoc = IsNull(req.params.id_Societe, "-1");
  res.send(await findLibelle(champs, code, valeur, tblName, idSoc));
}
