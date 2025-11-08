import { Request, Response } from "express";
import { controleInjection, lireSql } from "./module_sqlRW";
import { NVarChar } from "mssql";
export const getRubrique = async (req: Request, res: Response) => {
  const { rubrique } = req.body;
  if (controleInjection(rubrique)) {
    res.send({ result: false, data: ["Expression interdite"] });
    return;
  }
  const sqlStr = `select isnull(Valeur,'') as valeur,isnull(Membre,'') as membre 
    from Param_Rubriques where Nom_Controle=@rubrique
    order by Rang`;
  const rsl = await lireSql(sqlStr, [
    { param: "rubrique", sqlType: NVarChar, valeur: rubrique },
  ]);
  res.send(rsl);
  return;
};
export const listRubriques = async (req: Request, res: Response) => {
  const sqlStr = `select Nom_Controle rubrique,isnull(Valeur,'') as valeur,isnull(Membre,'') as membre, row_number() over(partition by Nom_Controle order by Rang, Membre) as rang 
  from Param_Rubriques`;
  const rsl = await lireSql(sqlStr, []);
  res.send(rsl.data);
  return;
};
