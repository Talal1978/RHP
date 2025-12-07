import sql from "mssql";
import { VGLOBALES } from "./module_initialisation";
import { TColonneCollection } from "../src/types";
import { estDate, formatDateFR, toSqlDateFormat } from "./module_format";
export async function lireSql(
  sqlStr: string,
  params: {
    param: string;
    sqlType: any;
    valeur: any;
  }[] = [],
  afficherSql = false
) {
  const db = VGLOBALES.SQL_DB || "RHPS";
  // Parse server and instance if present (e.g. "localhost\SQL2019")
  const serverParts = VGLOBALES.SQL_SERVER.split("\\");
  const server = serverParts[0] === "." ? "localhost" : serverParts[0];
  const instanceName = serverParts.length > 1 ? serverParts[1] : undefined;

  const config = {
    user: VGLOBALES.SQL_USER,
    password: VGLOBALES.SQL_PASSWORD,
    server: server,
    database: db,
    options: {
      encrypt: false, // Use true for Azure, false for local dev usually
      trustServerCertificate: true,
      instanceName: instanceName,
    },
  };
  const pool = new sql.ConnectionPool(config as any);
  try {
    const poolConnect = await pool.connect();
    if (afficherSql)
      // Gestionnaire pour capturer les messages SQL (PRINT, RAISERROR)
      poolConnect.on("infoMessage", (info) => {
        console.log("Message du Print - SQL: ", info.message); // Affiche les messages dans la console
      });
    const request = poolConnect.request();
    params.forEach((p) => request.input(p.param, p.sqlType, p.valeur));
    if (/\B\'(?<d>\d{2})\/(?<m>\d{2})\/(?<y>\d{4})\'\B/.test(sqlStr)) {
      //traitement des dates au format yyyy-mm-dd:
      let match;
      while (
        (match = /\B\'(?<d>\d{2})\/(?<m>\d{2})\/(?<y>\d{4})\'\B/.exec(
          sqlStr
        )) !== null
      ) {
        const lematch: string = `'${match.groups?.y}-${match.groups?.m}-${match.groups?.d}'`;
        sqlStr = sqlStr.split(match[0]).join(lematch);
      }
    }
    const result = await request.query(sqlStr);
    const fields: TColonneCollection = {};
    if (result?.recordset?.columns) {
      Object.entries(result.recordset.columns).forEach(([champs, valeur]) => {
        fields[champs] = {
          dataType: String(valeur.type)
            .replace("sql.", "")
            .split(" ")[0]
            .toLowerCase()
            .trim(),
          readOnly: true,
          visible: true,
          headerText: champs,
        };
      });
    }

    const data = result?.recordset?.length > 0 ? result.recordset : [];

    return {
      result: true,
      data: data as any,
      fields: fields,
      sort: "succès",
    };
  } catch (err) {
    return { result: false, data: [], fields: [], sort: err };
  } finally {
    pool.close();
  }
}
export const ecrireSql = async (args: {
  tableName: string;
  fields: { [key: string]: any };
  joinFields: string[];
  excludeFields?: string[];
  login: string;
}) => {
  const db = VGLOBALES.SQL_DB || "RHPS";
  let { tableName, fields, joinFields, excludeFields = [], login } = args;
  excludeFields.push("created_by");
  excludeFields.push("dat_crea");
  excludeFields.push("modified_by");
  excludeFields.push("dat_modif");
  joinFields = joinFields.map((t) => t.toLocaleLowerCase());
  excludeFields = excludeFields.map((t) => t.toLocaleLowerCase());
  let newfields: { [key: string]: any } = {};
  for (let obj in fields) {
    newfields[obj.toLowerCase()] = fields[obj];
  }
  fields = newfields;
  let str0 = `${Object.values(fields).map(
    (k) =>
      "'" +
      (estDate(k) ? formatDateFR(k) : k || "")
        ?.toString()
        .replace(/\'/g, "''") +
      "'"
  )}`;
  let str1 = `${Object.keys(fields).map((k) => k)}`;
  let str2 = `${Object.keys(fields)
    .filter((t) => !excludeFields.includes(t))
    .map((k) => k)}`;
  let str3 = `${Object.keys(fields)
    .filter((t) => !excludeFields.includes(t))
    .map((k) => "tbl." + k + " = src." + k)}`;
  let str4 = `${Object.keys(fields)
    .filter((t) => !excludeFields.includes(t))
    .map((k) => "src." + k)}`;
  let str5 = `${Object.keys(fields)
    .filter((t) => !excludeFields.includes(t))
    .map((k) => {
      return (
        k +
        "='" +
        (estDate(fields[k]) ? formatDateFR(fields[k]) : fields[k] || "")
          ?.toString()
          .replace(/\'/g, "''") +
        "'"
      );
    })
    .join(" and ")}`;
  let str = `MERGE INTO ${tableName} AS tbl
    USING (VALUES (${str0})) AS src (${str1})
    ON ${joinFields.map((k) => "tbl." + k + "=src." + k).join(" and ")}
    WHEN MATCHED THEN
        UPDATE SET ${str3},Dat_Modif=getdate(), Modified_By='${login}'
    WHEN NOT MATCHED THEN
        INSERT (${str2},Created_By,Dat_Crea)
        VALUES (${str4},'${login}',getdate());
   select top 1 * from ${tableName} where ${str5}`;
  let rsl = await lireSql(str, []);

  return rsl;
};
export const controleInjection = (champs: string) => {
  return /\b(eval)\b|\b(set)\b|\b(alter)\b|\b(create)\b|\b(drop)\b|\b(update)\b|\b(delete)\b|\b(truncate)\b/gi.test(
    champs
  );
};
