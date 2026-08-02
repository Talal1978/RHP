import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { Float, Int, NVarChar, SmallDateTime } from "mssql";

/**
 * Widgets déclarés dans Param_Query (requêteur desktop) exposés sur le portail.
 *
 * Sécurité / droits d'accès :
 * - Le catalogue est filtré par le profil du JWT via Controle_Droit (Actif) :
 *   un profil ne voit QUE les requêtes autorisées ("angle sécurité").
 * - L'exécution re-vérifie le droit (aucune confiance dans le client).
 * - Les paramètres (@Matricule, @idSoc, @CodEntite, ...) sont alimentés
 *   exclusivement depuis le JWT via une liste blanche, ou depuis Default_Value
 *   déclaré dans Param_Query_Criteres (convention GV_* incluse) — jamais depuis le client.
 * - Garde-fou SQL : seules les requêtes en lecture (select / with / exec Sys_*)
 *   à instruction unique sont exécutées.
 */

interface CtxParam {
  sqlType: any;
  valeur: any;
}

/** Liste blanche des paramètres de contexte, alimentés par le JWT uniquement. */
const buildContextParams = (theAgent: any): Record<string, CtxParam> => {
  const now = new Date();
  return {
    "@idsoc": { sqlType: Int, valeur: Number(theAgent?.id_Societe || 0) },
    "@matricule": { sqlType: NVarChar, valeur: theAgent?.Matricule || "" },
    "@codentite": { sqlType: NVarChar, valeur: theAgent?.Cod_Entite || "" },
    "@codposte": { sqlType: NVarChar, valeur: theAgent?.Cod_Poste || "" },
    "@login": { sqlType: NVarChar, valeur: theAgent?.Login || "" },
    "@iduser": { sqlType: NVarChar, valeur: String(theAgent?.id_User ?? "") },
    "@codprofile": { sqlType: NVarChar, valeur: String(theAgent?.codProfile ?? "") },
    "@teamleader": { sqlType: NVarChar, valeur: String(theAgent?.TeamLeader ?? "") },
    "@datjour": { sqlType: SmallDateTime, valeur: now },
    "@debmois": { sqlType: SmallDateTime, valeur: new Date(now.getFullYear(), now.getMonth(), 1) },
    "@finmois": { sqlType: SmallDateTime, valeur: new Date(now.getFullYear(), now.getMonth() + 1, 0) },
  };
};

/** Alias des variables globales du desktop (convention GV_*). */
const GV_ALIASES: Record<string, string> = {
  gv_idsoc: "@idsoc",
  gv_user: "@iduser",
  gv_login: "@login",
  gv_username: "@login",
  gv_now: "@datjour",
  gv_debmois: "@debmois",
  gv_finmois: "@finmois",
  gv_year: "@annee",
};

const stripStringLiterals = (sqlText: string) => sqlText.replace(/'(?:[^']|'')*'/g, "''");

/** Garde-fou : n'autorise que des lectures en une seule instruction. */
const isReadOnlyQuery = (sqlText: string): boolean => {
  const cleaned = stripStringLiterals(sqlText).trim();
  const isSelect = /^(select|with)\b/i.test(cleaned);
  const isSysExec = /^exec(ute)?\s+(dbo\.)?Sys_\w+/i.test(cleaned);
  if (!isSelect && !isSysExec) return false;
  if (/;\s*\S/.test(cleaned)) return false; // multi-instructions
  if (/\b(insert|update|delete|drop|alter|create|truncate|grant|revoke|merge|bulk|openrowset|opendatasource|xp_\w+|sp_\w+)\b/i.test(cleaned)) return false;
  return true;
};

const sqlTypeFromCritere = (typCritere: string) => {
  const t = String(typCritere || "").toLowerCase();
  if (t.startsWith("int") || t.startsWith("bigint") || t.startsWith("smallint") || t.startsWith("tinyint")) return Int;
  if (t.startsWith("float") || t.startsWith("real") || t.startsWith("decimal") || t.startsWith("numeric") || t.startsWith("money")) return Float;
  if (t.includes("date") || t.includes("time")) return SmallDateTime;
  return NVarChar;
};

const parseDefaultValue = (typCritere: string, defVal: string) => {
  const t = String(typCritere || "").toLowerCase();
  if (t.startsWith("int") || t.startsWith("bigint") || t.startsWith("smallint") || t.startsWith("tinyint")) return parseInt(defVal, 10) || 0;
  if (t.startsWith("float") || t.startsWith("real") || t.startsWith("decimal") || t.startsWith("numeric") || t.startsWith("money")) return parseFloat(defVal) || 0;
  if (t.includes("date") || t.includes("time")) {
    const dt = new Date(defVal);
    return isNaN(dt.getTime()) ? new Date() : dt;
  }
  return defVal;
};

const hasQueryRight = async (codProfile: string, codQuery: string): Promise<boolean> => {
  const rsl = await lireSql(
    `select count(*) as nb from Controle_Droit
     where Cod_Profile=@profil and Name_Ecran=@qry and isnull(Actif,'false')='true'`,
    [
      { param: "profil", sqlType: NVarChar, valeur: codProfile },
      { param: "qry", sqlType: NVarChar, valeur: codQuery },
    ]
  );
  return rsl.result && Number(rsl.data?.[0]?.nb) > 0;
};

/* ------------------------------------------------------------------ */
/* Catalogue : uniquement les requêtes-widget autorisées pour le profil */
/* ------------------------------------------------------------------ */
export const getDashboardQueryWidgetCatalog = async (req: Request, res: Response) => {
  const { processId, ...theAgent } = req.params;
  const codProfile = String(theAgent?.codProfile ?? "");
  const id_Societe = Number(theAgent?.id_Societe || 0);
  if (isNaN(id_Societe) || id_Societe <= 0) {
    return res.status(400).send({ result: false, message: "id_Societe invalide" });
  }
  if (!codProfile || codProfile === "-1" || codProfile === "undefined") {
    return res.send({ result: true, data: [] });
  }

  try {
    const rsl = await lireSql(
      `select q.Cod_Query as id, q.Nom_Query as title, lower(w.Widget_Type) as type,
              lower(isnull(w.Widget_ChartType,'')) as chartType,
              isnull(w.Icone,'') as icon, isnull(w.Couleur,'#1976d2') as color,
              isnull(w.DefaultSpan, 6) as defaultSpan, isnull(w.Description,'') as description
       from Param_Query q
       join Param_Query_Widget w on w.Cod_Query = q.Cod_Query and isnull(w.estWidget,'false')='true'
       where exists (select 1 from Controle_Droit d
                     where d.Cod_Profile=@profil and d.Name_Ecran=q.Cod_Query and isnull(d.Actif,'false')='true')
       order by q.Nom_Query`,
      [{ param: "profil", sqlType: NVarChar, valeur: codProfile }]
    );
    const data = (rsl.data || []).map((row: any) => ({
      ...row,
      chartType: row.chartType || undefined,
      sourceType: "query",
    }));
    return res.send({ result: true, data });
  } catch (error: any) {
    return res.send({ result: false, message: error.message });
  }
};

/* ------------------------------------------------------------------ */
/* Exécution : droit + garde-fou + paramètres contexte whitelistés      */
/* ------------------------------------------------------------------ */
export const execDashboardQueryWidget = async (req: Request, res: Response) => {
  const { processId, ...theAgent } = req.params;
  const codProfile = String(theAgent?.codProfile ?? "");
  const id_Societe = Number(theAgent?.id_Societe || 0);
  const widgetId = String(req.body?.widgetId || "");

  if (isNaN(id_Societe) || id_Societe <= 0) {
    return res.status(400).send({ result: false, message: "id_Societe invalide" });
  }

  try {
    // 1. Widget déclaré ?
    const wMeta = await lireSql(
      `select Cod_Query, lower(Widget_Type) as Widget_Type, lower(isnull(Widget_ChartType,'')) as Widget_ChartType
       from Param_Query_Widget where Cod_Query=@qry and isnull(estWidget,'false')='true'`,
      [{ param: "qry", sqlType: NVarChar, valeur: widgetId }]
    );
    if (!wMeta.result || !wMeta.data?.length) {
      return res.send({ result: false, message: "Widget non pris en charge" });
    }
    const meta = wMeta.data[0];

    // 2. Droit du profil (re-vérification à l'exécution)
    if (!codProfile || codProfile === "-1" || !(await hasQueryRight(codProfile, widgetId))) {
      return res.send({ result: false, message: "Accès non autorisé à ce widget" });
    }

    // 3. SQL déclaré + garde-fou
    const qSql = await lireSql(`select Cod_Sql from Param_Query where Cod_Query=@qry`, [
      { param: "qry", sqlType: NVarChar, valeur: widgetId },
    ]);
    const codSql = String(qSql.data?.[0]?.Cod_Sql || "");
    if (!codSql || !isReadOnlyQuery(codSql)) {
      return res.send({ result: false, message: "Requête non autorisée (écriture ou forme interdite)" });
    }

    // 4. Résolution des critères : contexte JWT > GV_* > Default_Value
    const crit = await lireSql(
      `select Critere, Typ_Critere, Default_Value from Param_Query_Criteres where Cod_Query=@qry order by Rang`,
      [{ param: "qry", sqlType: NVarChar, valeur: widgetId }]
    );
    const ctx = buildContextParams(theAgent);
    const params: { param: string; sqlType: any; valeur: any }[] = [];
    for (const c of crit.data || []) {
      const critere = String(c.Critere || ""); // ex: '@idSoc'
      if (!critere) continue;
      const paramName = critere.replace(/^@/, "");
      const ctxKey = critere.toLowerCase();
      const defVal = String(c.Default_Value ?? "").trim();
      const gvKey = defVal.toLowerCase();

      if (ctx[ctxKey]) {
        params.push({ param: paramName, ...ctx[ctxKey] });
      } else if (gvKey.startsWith("gv_") && GV_ALIASES[gvKey] && ctx[GV_ALIASES[gvKey]]) {
        params.push({ param: paramName, ...ctx[GV_ALIASES[gvKey]] });
      } else if (defVal !== "" && !gvKey.startsWith("gv_")) {
        params.push({ param: paramName, sqlType: sqlTypeFromCritere(c.Typ_Critere), valeur: parseDefaultValue(c.Typ_Critere, defVal) });
      } else {
        return res.send({ result: false, message: `Widget non exécutable sans saisie (paramètre ${critere})` });
      }
    }

    // 5. Exécution paramétrée
    const rsl = await lireSql(codSql, params);
    if (!rsl.result) {
      return res.send({ result: false, message: "Erreur d'exécution de la requête" });
    }

    // 6. Mise en forme selon le type de widget (convention du requêteur :
    //    1re colonne = libellé, colonnes suivantes = valeurs)
    const rows: any[] = rsl.data || [];
    const cols = rsl.fields && Object.keys(rsl.fields).length > 0
      ? Object.keys(rsl.fields)
      : rows[0]
        ? Object.keys(rows[0])
        : [];

    if (meta.Widget_Type === "kpi") {
      const first = rows[0] || {};
      return res.send({
        result: true,
        data: {
          value: cols.length ? first[cols[0]] ?? 0 : 0,
          label: cols.length > 1 ? String(first[cols[1]] ?? "") : "",
        },
      });
    }

    if (meta.Widget_Type === "chart") {
      const labelCol = cols[0] || "";
      const numericCols = cols
        .slice(1)
        .filter((c) => rows.every((r) => typeof r[c] === "number" || r[c] === null || r[c] === undefined));
      const seriesCols = numericCols.length > 0 ? numericCols : cols.slice(1, 2);
      return res.send({
        result: true,
        data: {
          labels: rows.map((r) => String(r[labelCol] ?? "")),
          series: seriesCols.map((c) => ({ label: c, data: rows.map((r) => Number(r[c]) || 0) })),
        },
      });
    }

    // table (plafond de sécurité sur le nombre de lignes)
    return res.send({
      result: true,
      data: {
        columns: cols.map((c) => ({ field: c, header: c })),
        rows: rows.slice(0, 500),
      },
    });
  } catch (error: any) {
    return res.send({ result: false, message: error.message });
  }
};
