import { Request, Response } from "express";
import { controleInjection, lireSql } from "./module_sqlRW";
import { Tbl_Controle_Def_Zoom } from "./module_initialisation";
import { IsNull } from "./module_general";
export const getZoomApi = async (req: Request, res: Response) => {
  let { numZoom, condition, valeurs } = req.body;
  if (controleInjection(condition).result === false) {
    res.send({ result: false, data: ["Expression interdite"] });
    return;
  }
  if (controleInjection(numZoom).result === false) {
    res.send({ result: false, data: ["Expression interdite"] });
    return;
  }
  if (controleInjection(valeurs).result === false) {
    res.send({ result: false, data: ["Expression interdite"] });
    return;
  }
  const oRow = Tbl_Controle_Def_Zoom.filter((z) => z.numZoom === numZoom);
  if (oRow.length === 0) return;
  let sqlStr = oRow[0].sqlStr;
  sqlStr = sqlStr.replace(
    /@@@condition/gi,
    IsNull(condition, "") != "" ? condition : ""
  );
  for (let i: number = 0; i < valeurs?.length || 0; i++) {
    let rg = new RegExp(`\{${i}\}`, "gi");
    sqlStr = sqlStr.replace(rg, valeurs[i]?.trim());
  }

  const rsl = await lireSql(sqlStr);
  return res.send(rsl);
};

/** Retourne le libellé d'une valeur de zoom : la 2e colonne de la déclaration
 *  du zoom dans Controle_Def_Zoom (1ère colonne = Code, 2e = libellé).
 *  Réutilise la requête du zoom en y injectant le filtre sur l'expression du
 *  code (l'alias Code n'est pas utilisable dans le WHERE). */
export const getZoomLibelleApi = async (req: Request, res: Response) => {
  const { numZoom, valeur, valeurs } = req.body;
  if (controleInjection(numZoom).result === false) {
    return res.send("");
  }
  if (controleInjection(valeur).result === false) {
    return res.send("");
  }
  const val = String(IsNull(valeur, "")).trim();
  if (val === "") return res.send("");
  const oRow = Tbl_Controle_Def_Zoom.filter((z) => z.numZoom === numZoom);
  if (oRow.length === 0) return res.send("");
  let sqlStr = oRow[0].sqlStr;
  sqlStr = sqlStr.replace(
    /@@@condition/gi,
    `and (${oRow[0].codExp} = '${val.replace(/'/g, "''")}')`
  );
  for (let i: number = 0; i < valeurs?.length || 0; i++) {
    let rg = new RegExp(`\{${i}\}`, "gi");
    sqlStr = sqlStr.replace(rg, valeurs[i]?.trim());
  }
  const rsl = await lireSql(sqlStr);
  const libelle =
    rsl && rsl.result && rsl.data.length > 0
      ? Object.values(rsl.data[0])[1]
      : "";
  return res.send(String(libelle ?? ""));
};
