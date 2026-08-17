/* ============================================================================
   Requêteur — pages de consultation du portail (Param_Query exposées)
   ----------------------------------------------------------------------------
   Une requête du requêteur desktop (Param_Query) devient une PAGE DE
   CONSULTATION du portail quand Param_Query_Widget.estPortail='true'
   (migration sql/Requeteur/001_Param_Query_Page_Portail.sql) : entrée directe
   du menu (SPQ_<Cod_Query>, sans page liste), critères saisis par l'agent,
   grille de résultats en lecture seule — actions inline 'Interroger' /
   'Nouveau' (pas de FAB).
   Sécurité (mêmes règles que les widgets du tableau de bord) :
   - exposition et droit Controle_Droit re-vérifiés à CHAQUE appel (profil '1'
     bypass, convention RHP) ;
   - garde-fou lecture seule rejoué à l'exécution ;
   - paramètres de contexte (@idSoc, @Matricule, ...) alimentés exclusivement
     par le JWT (liste blanche) — jamais par le client ;
   - seuls les critères déclarés (Param_Query_Criteres) et NON auto-alimentés
     sont acceptés depuis le client, typés par Typ_Critere (jamais de
     concaténation SQL) ; Default_Value (constante ou GV_*) pré-remplit.
   ============================================================================ */
import { Request, Response } from "express";
import sql from "mssql";
import { lireSql } from "../modules/module_sqlRW";
import {
  buildContextParams, GV_ALIASES, isReadOnlyQuery,
  sqlTypeFromCritere, parseDefaultValue, hasQueryRight,
} from "./dashboard_query_widgets";

const refus = (res: Response, message: string) =>
  res.send({ result: false, data: [], fields: [], sort: message, message });

function agentDepuis(req: Request) {
  const { Login, Matricule, id_Societe, codProfile, TeamLeader } = req.params;
  return {
    Login: String(Login ?? Matricule ?? ""),
    Matricule: String(Matricule ?? ""),
    id_Societe: String(id_Societe ?? ""),
    codProfile: String(codProfile ?? ""),
    TeamLeader: String(TeamLeader ?? ""),
  };
}

/** Exposition + droit d'accès à la page-requête (rejoué à chaque endpoint). */
async function pageRequete(codQuery: string, codProfile: string) {
  const rsl = await lireSql(
    `select q.Cod_Query, q.Nom_Query, q.Cod_Sql, isnull(w.Icone,'') as Icone
     from Param_Query q
     join Param_Query_Widget w on w.Cod_Query = q.Cod_Query and isnull(w.estPortail,'false')='true'
     where q.Cod_Query = @qry`,
    [{ param: "qry", sqlType: sql.NVarChar, valeur: codQuery }]
  );
  if (!rsl.result || !rsl.data?.length) return { erreur: "Page introuvable", page: null as any };
  // Droit : profil '1' bypass (convention RHP), sinon Controle_Droit actif
  if (codProfile !== "1" && !(await hasQueryRight(codProfile, codQuery))) {
    return { erreur: "Vous n'êtes pas autorisé à accéder à cette page.", page: null as any };
  }
  return { erreur: null as string | null, page: rsl.data[0] };
}

/** Critères déclarés de la requête (Param_Query_Criteres, ordre Rang). */
async function criteresDeclares(codQuery: string) {
  const rsl = await lireSql(
    `select Critere, Lib_Critere, Typ_Critere, Default_Value, Rang,
            Fonction_Critere, Table_Critere, Champs_01, Champs_02, Condition
     from Param_Query_Criteres where Cod_Query=@qry order by Rang`,
    [{ param: "qry", sqlType: sql.NVarChar, valeur: codQuery }]
  );
  return rsl.data ?? [];
}

/** Un critère est AUTO-ALIMENTÉ (jamais demandé à l'utilisateur) s'il fait
 *  partie de la liste blanche JWT, ou si sa Default_Value est un alias GV_*. */
function estAutoAlimente(critere: string, defaultValue: string, ctx: Record<string, unknown>) {
  const key = String(critere ?? "").toLowerCase();
  if (ctx[key]) return true;
  const gv = String(defaultValue ?? "").trim().toLowerCase();
  return gv.startsWith("gv_") && !!GV_ALIASES[gv] && !!ctx[GV_ALIASES[gv]];
}

/** Type de contrôle de saisie déduit de Typ_Critere (rendu client).
 *  La Fonction_Critere déclarée (même comportement que Param_Query_Saisi,
 *  desktop) prime : Calender => DATE, Boolean => CHECK ; Appel_Zoom (Menu
 *  Local) et Combo (Rubrique) sont rendus en liste de choix alimentée par
 *  sp_query_zoom (le client lit alors 'fonction', pas 'controle'). */
function controleCritere(typCritere: string, fonction = ""): "INT" | "DEC" | "DATE" | "DATETIME" | "CHECK" | "TEXT" {
  if (fonction === "Calender") return "DATE";
  if (fonction === "Boolean") return "CHECK";
  const t = String(typCritere ?? "").toLowerCase();
  if (t.startsWith("bit")) return "CHECK";
  if (t.startsWith("int") || t.startsWith("bigint") || t.startsWith("smallint") || t.startsWith("tinyint")) return "INT";
  if (t.startsWith("float") || t.startsWith("real") || t.startsWith("decimal") || t.startsWith("numeric") || t.startsWith("money")) return "DEC";
  if (t.includes("datetime") || t.includes("smalldatetime")) return "DATETIME";
  if (t.includes("date") || t.includes("time")) return "DATE";
  return "TEXT";
}

/* -------------------------------------------------------------------------- */
/* Métadonnées de la page : nom + critères à saisir                            */
/* -------------------------------------------------------------------------- */
export async function sp_query_meta(req: Request, res: Response) {
  const agent = agentDepuis(req);
  const codQuery = String(req.body?.codQuery ?? "");
  const { erreur, page } = await pageRequete(codQuery, agent.codProfile);
  if (erreur) return refus(res, erreur);

  const ctx = buildContextParams(agent);
  const criteres = (await criteresDeclares(codQuery))
    .filter((c: any) => !estAutoAlimente(String(c.Critere ?? ""), String(c.Default_Value ?? ""), ctx))
    .map((c: any) => {
      const fonction = String(c.Fonction_Critere ?? "").trim();
      return {
        nom: String(c.Critere ?? "").replace(/^@/, ""),
        libelle: String(c.Lib_Critere ?? "").trim() || String(c.Critere ?? "").replace(/^@/, ""),
        controle: controleCritere(String(c.Typ_Critere ?? ""), fonction),
        fonction, // '' / TextBox / Calender / Appel_Zoom / Combo / Boolean
        defaut: String(c.Default_Value ?? "").trim(),
        rang: Number(String(c.Rang ?? "").trim()) || 99,
      };
    })
    .sort((a: { rang: number }, b: { rang: number }) => a.rang - b.rang);
  return res.send({
    result: true,
    data: [{ nom: String(page.Nom_Query ?? codQuery), icone: String(page.Icone ?? ""), criteres }],
    fields: [],
    sort: "succès",
  });
}

/* -------------------------------------------------------------------------- */
/* Exécution : droit + garde-fou + paramètres typés (plafond 500 lignes)       */
/* -------------------------------------------------------------------------- */
export async function sp_query_exec(req: Request, res: Response) {
  const agent = agentDepuis(req);
  const codQuery = String(req.body?.codQuery ?? "");
  const { erreur, page } = await pageRequete(codQuery, agent.codProfile);
  if (erreur) return refus(res, erreur);

  const codSql = String(page.Cod_Sql ?? "");
  if (!codSql || !isReadOnlyQuery(codSql)) {
    return refus(res, "Requête non autorisée (écriture ou forme interdite)");
  }

  // Résolution des critères : contexte JWT > alias GV_* > valeur saisie >
  // Default_Value constante > NULL typé (la requête décide : @p is null or ...)
  const valeurs: { [k: string]: any } = req.body?.valeurs ?? {};
  const ctx = buildContextParams(agent);
  const params: { param: string; sqlType: any; valeur: any }[] = [];
  for (const c of await criteresDeclares(codQuery)) {
    const critere = String(c.Critere ?? "");
    if (!critere) continue;
    const paramName = critere.replace(/^@/, "");
    const ctxKey = critere.toLowerCase();
    const defVal = String(c.Default_Value ?? "").trim();
    const gvKey = defVal.toLowerCase();
    const sqlType = sqlTypeFromCritere(c.Typ_Critere);

    if (ctx[ctxKey]) {
      params.push({ param: paramName, ...ctx[ctxKey] });
    } else if (gvKey.startsWith("gv_") && GV_ALIASES[gvKey] && ctx[GV_ALIASES[gvKey]]) {
      params.push({ param: paramName, ...ctx[GV_ALIASES[gvKey]] });
    } else {
      const brut = valeurs[paramName];
      if (brut !== undefined && brut !== null && String(brut) !== "") {
        // Valeur saisie : typée par Typ_Critere, jamais concaténée
        if (sqlType === sql.Int) {
          params.push({ param: paramName, sqlType: sql.Int, valeur: parseInt(String(brut).replace(",", "."), 10) || 0 });
        } else if (sqlType === sql.Float) {
          params.push({ param: paramName, sqlType: sql.Float, valeur: parseFloat(String(brut).replace(",", ".")) || 0 });
        } else if (sqlType === sql.SmallDateTime) {
          const d = new Date(String(brut));
          params.push({ param: paramName, sqlType: sql.SmallDateTime, valeur: isNaN(d.getTime()) ? null : d });
        } else {
          params.push({ param: paramName, sqlType: sql.NVarChar, valeur: String(brut) });
        }
      } else if (defVal !== "" && !gvKey.startsWith("gv_")) {
        params.push({ param: paramName, sqlType, valeur: parseDefaultValue(c.Typ_Critere, defVal) });
      } else {
        params.push({ param: paramName, sqlType, valeur: null });
      }
    }
  }

  const rsl = await lireSql(codSql, params);
  if (!rsl.result) return refus(res, "Erreur d'exécution de la requête");
  // Plafond de sécurité sur le nombre de lignes (convention des widgets)
  const rows = (rsl.data ?? []).slice(0, 500);
  return res.send({ ...rsl, data: rows, tronque: (rsl.data ?? []).length > 500 });
}

/* -------------------------------------------------------------------------- */
/* Liste de choix d'un critère (Fonction_Critere) — même comportement que      */
/* Param_Query_Saisi (desktop) :                                               */
/*   - 'Appel_Zoom' (« Menu Local », zoom long) : Code = Champs_01, Libelle =  */
/*     Champs_02, depuis Table_Critere filtrée par Condition ;                 */
/*   - 'Combo' (« Rubrique ») : Table_Critere = nom d'une rubrique             */
/*     (Param_Rubriques, Valeur/Membre).                                       */
/* Table, champs et condition proviennent EXCLUSIVEMENT de la déclaration      */
/* (Param_Query_Criteres), jamais du client ; la condition ne peut référencer  */
/* que des paramètres de contexte JWT (liste blanche), typés.                  */
/* -------------------------------------------------------------------------- */
const rgIdentifiant = /^[A-Za-z_][A-Za-z0-9_]*$/;

export async function sp_query_zoom(req: Request, res: Response) {
  const agent = agentDepuis(req);
  const codQuery = String(req.body?.codQuery ?? "");
  const critere = String(req.body?.critere ?? "");
  const { erreur } = await pageRequete(codQuery, agent.codProfile);
  if (erreur) return refus(res, erreur);

  const decl = (await criteresDeclares(codQuery)).find(
    (c: any) => String(c.Critere ?? "").toLowerCase() === critere.toLowerCase()
        || String(c.Critere ?? "").replace(/^@/, "").toLowerCase() === critere.toLowerCase()
  );
  if (!decl) return refus(res, "Critère introuvable");
  const fonction = String(decl.Fonction_Critere ?? "").trim();
  const ctx = buildContextParams(agent);

  // 'Combo' : liste issue d'une rubrique (Zoom_Combo desktop, TypCombo = rubrique)
  if (fonction === "Combo") {
    const rub = String(decl.Table_Critere ?? "").trim();
    if (rub === "") return refus(res, "Rubrique non déclarée");
    const rsl = await lireSql(
      `select top 500 Valeur as Code, Membre as Libelle
       from Param_Rubriques where Nom_Controle=@rub order by Rang, Membre`,
      [{ param: "rub", sqlType: sql.NVarChar, valeur: rub }]
    );
    if (!rsl.result) return refus(res, "Erreur de chargement de la liste");
    return res.send({ result: true, data: rsl.data ?? [], fields: [], sort: "succès" });
  }

  if (fonction !== "Appel_Zoom") return refus(res, "Ce critère n'est pas une liste de choix");

  // 'Appel_Zoom' : zoom long (Menu Local) — identifiants strictement validés
  const table = String(decl.Table_Critere ?? "").trim();
  const colCode = String(decl.Champs_01 ?? "").trim();
  const colLib = String(decl.Champs_02 ?? "").trim();
  if (!rgIdentifiant.test(table) || !rgIdentifiant.test(colCode) || (colLib !== "" && !rgIdentifiant.test(colLib))) {
    return refus(res, "Déclaration du zoom invalide");
  }
  const condition = String(decl.Condition ?? "").trim();
  const params: { param: string; sqlType: any; valeur: any }[] = [];
  if (condition !== "") {
    // Garde-fou : filtre déclaré par l'administrateur, mais on n'accepte qu'une
    // condition de lecture (pas de ';', aucun mot-clé d'écriture) et des
    // paramètres limités à la liste blanche JWT.
    if (!isReadOnlyQuery(`select 1 where ${condition}`)) {
      return refus(res, "Condition du zoom non autorisée");
    }
    for (const m of condition.match(/@[A-Za-z_][A-Za-z0-9_]*/g) ?? []) {
      const k = m.toLowerCase();
      if (!ctx[k]) return refus(res, `Paramètre non autorisé dans la condition : ${m}`);
      params.push({ param: m.substring(1), ...ctx[k] });
    }
  }
  const rsl = await lireSql(
    `select top 500 ${colCode} as Code, ${colLib !== "" ? `${colLib} as Libelle` : `${colCode} as Libelle`}
     from ${table}${condition !== "" ? ` where ${condition}` : ""}
     order by ${colLib !== "" ? colLib : colCode}`,
    params
  );
  if (!rsl.result) return refus(res, "Erreur de chargement de la liste");
  return res.send({ result: true, data: rsl.data ?? [], fields: [], sort: "succès" });
}
