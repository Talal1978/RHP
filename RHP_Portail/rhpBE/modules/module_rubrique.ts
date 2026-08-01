import { Request, Response } from "express";
import { controleInjection, lireSql } from "./module_sqlRW";
import { Int, NVarChar } from "mssql";
import { getCache, setCache } from "./module_cache";

export const getRubrique = async (req: Request, res: Response) => {
  let { rubrique, options } = req.query;
  const { id_Societe } = req.params;
  const idSoc = Number(id_Societe);
  if (isNaN(idSoc) || idSoc <= 0) return res.status(400).send({ result: false, message: "id_Societe invalide" });

  let sqlStr = "";
  if (typeof options === 'string') {
    let converted = options
      .replace(/\b(\w+)\s*:/g, '"$1":')
      .replace(/'([^']*)'/g, '"$1"');
    try {
      options = JSON.parse(converted);
    } catch (err) {
      options = {};
    }
  } else if (typeof options !== 'object' || options === null) {
    options = {};
  }
  rubrique = rubrique?.toString() ?? "";
  if (controleInjection(rubrique).result === false) {
    res.send({ result: false, data: [{ message: controleInjection(rubrique).message }] });
    return;
  }
  switch (rubrique) {
    case 'domaines_competences':
      sqlStr = `select Domaines_Competence as value, Lib_Domaines_Competence as label from GPEC_Domaines_Competence where id_Societe=@p_idSoc`;
      return res.send(await lireSql(sqlStr, [{ param: "p_idSoc", sqlType: Int, valeur: idSoc }]));
    case 'grade':
      sqlStr = `select Cod_Grade as value, Lib_Grade as label from Org_Grade where id_Societe=@p_idSoc`;
      return res.send(await lireSql(sqlStr, [{ param: "p_idSoc", sqlType: Int, valeur: idSoc }]));
    case 'postes':
      sqlStr = `select Cod_Poste as value, Lib_Poste as label from Org_Poste where id_Societe=@p_idSoc`;
      return res.send(await lireSql(sqlStr, [{ param: "p_idSoc", sqlType: Int, valeur: idSoc }]));
    default:
      sqlStr = `select coalesce(valeur,'') as value, coalesce(membre,'') as label 
from param_rubriques where Nom_Controle=@rubrique
order by Rang`;
      const rsl = await lireSql(sqlStr, [
        { param: "rubrique", sqlType: NVarChar, valeur: rubrique },
      ]);
      return res.send(rsl);
  }
};

export const listRubriques = async (req: Request, res: Response) => {
  const cached = getCache<any[]>("listRubriques");
  if (cached) {
    return res.send(cached);
  }
  const sqlStr = `select Nom_Controle rubrique,isnull(Valeur,'') as valeur,isnull(Membre,'') as membre, row_number() over(partition by Nom_Controle order by Rang, Membre) as rang 
  from Param_Rubriques`;
  const rsl = await lireSql(sqlStr, []);
  if (rsl.result && rsl.data) {
    setCache("listRubriques", rsl.data, 600); // 10 minutes
  }
  res.send(rsl.data);
  return;
};
