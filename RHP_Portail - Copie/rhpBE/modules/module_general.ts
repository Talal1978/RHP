import { Request, Response } from "express";
import { lireSql } from "./module_sqlRW";
import { TablesAvecIdSoc, TablesAvecMatricule } from "./module_initialisation";
import { NVarChar } from "mssql";
export const findParam = async (req: Request, res: Response) => {
  return res.send(await getParams());
};
export async function getParams() {
  let sqlStr = `declare @s varchar(max)
    select @s=isnull( @s+',','select ')+''''+Valeur+''' as '''+Cod_Param+'''' from Param_General
    exec (@s)`;
  let rslParamGeneral = await lireSql(sqlStr, []);
  return { ...rslParamGeneral.data[0] };
}
export async function getParam(codParam: string) {
  const rsl = await lireSql(
    "select top 1 Valeur from Param_General where Cod_Param=@codParam",
    [{ param: "codParam", sqlType: NVarChar, valeur: codParam }]
  );
  if (!rsl.result) return "";
  if (!Boolean(rsl.data)) return "";
  return rsl.data[0].Valeur;
}
export function IsNull(champs: any, retour: any) {
  return champs ?? retour;
}
export async function handleIdSoc(SqlStr: string, idSoc: string) {
  const rg = new RegExp(
    `(?<=FROM|JOIN)\\s+(?<table>\\w+)\\s+(?:AS\\s+)?(?<alias>(?!left|outer|right|on|inner|where|group|order|union|join|cross)\\w+\\s+)?`,
    "gmi"
  );
  let matches = [...SqlStr.matchAll(rg)];
  for (const match of matches) {
    const groups = match.groups as unknown as MatchGroups;
    if (groups && groups.table) {
      if (TablesAvecIdSoc.includes(groups.table.trim().toLowerCase())) {
        const srg = RegExp(`\\b${match[0]}\\b`, "gmi");
        SqlStr = SqlStr.replace(
          srg,
          ` (select * from ${
            groups.table
          } where id_Societe=${idSoc} or id_Societe=-1) as ${
            groups.alias || groups.table
          } `
        );
      }
    }
  }
  return SqlStr;
}
export async function TablesSQLWithIdSocOuMatricule(
  TblNameAvecId: typeof TablesAvecIdSoc | typeof TablesAvecMatricule,
  ExpressionSql: string,
  showDetail = false
): Promise<MatchGroups[]> {
  if (TblNameAvecId.includes(ExpressionSql.toLowerCase())) {
    return [{ table: ExpressionSql, alias: ExpressionSql }];
  } else {
    let rg =
      /(?<![,.\s,=,),(,+]|\bselect\b)((?<=FROM|JOIN|)\s+)?(?<table>\b((?!left|as|from|outer|right|on|inner|join|cross|where|apply|select|and|group|by)\w+)\b)\s+(?:AS\s+)?(?<alias>(?!left|outer|right|on|inner|join|cross|where|apply|from|and|group|by|as)\w+)?/gim;
    let match;
    let tabMatches: { table: string; alias: string }[] = [];
    while ((match = rg.exec(ExpressionSql)) !== null) {
      const groups = match.groups as unknown as MatchGroups;
      if (groups && groups.table) {
        const { table, alias } = groups;
        tabMatches.push({ table: table, alias: alias || table });
      }
    }
    return tabMatches;
  }
}
interface MatchGroups {
  table: string;
  alias?: string;
}
export function makeid(length: number) {
  var result = "";
  var characters =
    "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
  var charactersLength = characters.length;
  for (var i = 0; i < length; i++) {
    result += characters.charAt(Math.floor(Math.random() * charactersLength));
  }
  return result;
}
