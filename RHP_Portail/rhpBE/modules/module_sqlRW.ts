import sql from "mssql";
import { VGLOBALES } from "./module_initialisation";
import { TColonneCollection } from "../src/types";
import { checkDateFormat, estDate, formatDateFR } from "./module_format";

let globalPool: sql.ConnectionPool | null = null;

export function getSqlConfig(): sql.config {
  const db = VGLOBALES.SQL_DB || "RHPS";
  const serverParts = VGLOBALES.SQL_SERVER.split("\\");
  const server = serverParts[0] === "." ? "localhost" : serverParts[0];
  const instanceName = serverParts.length > 1 ? serverParts[1] : undefined;

  return {
    user: VGLOBALES.SQL_USER,
    password: VGLOBALES.SQL_PASSWORD,
    server: server as any,
    database: db,
    options: {
      encrypt: false,
      trustServerCertificate: true,
      instanceName: instanceName,
    },
  };
}

export async function getPool(): Promise<sql.ConnectionPool> {
  if (!globalPool) {
    globalPool = new sql.ConnectionPool(getSqlConfig() as any);
    await globalPool.connect();
    console.log("[MSSQL] Pool connecté");
    globalPool.on("error", (err) => {
      console.error("[MSSQL] Pool error:", err);
      globalPool = null;
    });
  }
  if (!globalPool.connected) {
    await globalPool.connect();
  }
  return globalPool;
}

export async function closePool() {
  if (globalPool) {
    await globalPool.close();
    globalPool = null;
    console.log("[MSSQL] Pool fermé");
  }
}

export async function lireSql(
  sqlStr: string,
  params: {
    param: string;
    sqlType: any;
    valeur: any;
  }[] = [],
  afficherSql = false
) {
  try {
    const pool = await getPool();
    const request = pool.request();
    params.forEach((p) => request.input(p.param, p.sqlType, p.valeur));

    if (/\B\'(?<d>\d{2})\/(?<m>\d{2})\/(?<y>\d{4})\'\B/.test(sqlStr)) {
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

    if (afficherSql) console.log("[SQL]", sqlStr);

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
    console.error("[MSSQL] lireSql error:", err);
    if (params) {
      console.error("[MSSQL] Failed query:", sqlStr.substring(0, 300));
      console.error("[MSSQL] Params:", params.map(p => ({ param: p.param, type: p.sqlType?.name, valeur: p.valeur instanceof Date ? p.valeur.toISOString() : p.valeur })));
    }
    return { result: false, data: [], fields: [], sort: err };
  }
}

export const ecrireSql = async (args: {
  tableName: string;
  fields: { [key: string]: any };
  joinFields: string[];
  excludeFields?: string[];
  login: string;
}) => {
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

  const keys = Object.keys(fields);
  const insertableKeys = keys.filter((k) => !excludeFields.includes(k));

  const paramPrefix = "p_";
  const valParams = keys.map((k) => `@${paramPrefix}${k}`).join(", ");
  const colNames = keys.join(", ");
  const onClause = joinFields.map((k) => `tbl.${k} = src.${k}`).join(" and ");
  const updateSet = insertableKeys
    .map((k) => `tbl.${k} = src.${k}`)
    .concat(["Dat_Modif = GETDATE()", "Modified_By = @login"])
    .join(", ");
  const insertCols = insertableKeys.join(", ");
  const insertVals = insertableKeys.map((k) => `src.${k}`).join(", ");
  // Le SELECT final doit filtrer sur les clés (joinFields) uniquement :
  // comparer tous les champs échoue pour les dates smalldatetime (arrondies
  // à la minute alors que le paramètre DateTime contient les secondes).
  const whereClause = joinFields
    .map((k) => `${k} = @${paramPrefix}${k}`)
    .join(" and ");

  const mergeSql = `MERGE INTO ${tableName} AS tbl
    USING (VALUES (${valParams})) AS src (${colNames})
    ON ${onClause}
    WHEN MATCHED THEN
        UPDATE SET ${updateSet}
    WHEN NOT MATCHED THEN
        INSERT (${insertCols}, Created_By, Dat_Crea)
        VALUES (${insertVals}, @login, GETDATE());
    SELECT TOP 1 * FROM ${tableName} WHERE ${whereClause}`;

  const requestParams: { param: string; sqlType: any; valeur: any }[] = [];
  keys.forEach((k) => {
    let val = fields[k];
    let sqlType: any = sql.NVarChar;
    if (estDate(val)) {
      sqlType = sql.DateTime;
    } else {
      val = String(val ?? "");
    }
    requestParams.push({ param: `${paramPrefix}${k}`, sqlType, valeur: val });
  });
  requestParams.push({ param: "login", sqlType: sql.NVarChar, valeur: login });

  return await lireSql(mergeSql, requestParams);
};

export const controleInjection = (
  champs: string | undefined | null
): { result: boolean; sqlExpression?: string; message?: string } => {
  if (!champs) return { result: true, sqlExpression: "" };
  const cleaned = String(champs)
    .replace(/\/\*.*?\*\//gs, "")
    .replace(/--.*?(\n|$)/g, "")
    .replace(/\s+/g, " ");

  const blackList =
    /\b(eval|set|alter|create|drop|update|delete|truncate|grant|union|openrowset|opendatasource|execute|exec|bulk|backup|restore|shutdown|kill|waitfor|xp_\w+|sp_\w+|fn_\w+)\b/i;

  if (blackList.test(cleaned)) {
    return { result: false, message: "Champs contient des mots SQL interdits." };
  }

  return { result: true, sqlExpression: cleaned.trim() };
};
