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
