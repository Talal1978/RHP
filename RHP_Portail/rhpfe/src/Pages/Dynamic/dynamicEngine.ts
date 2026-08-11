/* ============================================================================
   Module SP_ - Moteur déclaratif côté client (portail)
   ----------------------------------------------------------------------------
   Miroir de l'évaluateur serveur (module_sp_engine.ts) :
   - conditions / formules en json déclaratif (AUCUN eval, aucun code libre)
   - graphe de dépendances : recalcul ciblé + détection de cycles
   - validations par moment (confort utilisateur) - le serveur re-valide
     systématiquement à l'enregistrement.
   ============================================================================ */
import { TSpChamp, TSpContexte, TSpErreur, TSpMeta, TSpValidation } from "./Types";

const OPS_LOGIQUES = new Set(["AND", "OR", "NOT", "EQ", "NE", "GT", "GE", "LT", "LE",
  "IN", "EMPTY", "NOTEMPTY", "CONTIENT"]);
const OPS_CALCUL = new Set(["ADD", "SUB", "MUL", "DIVSAFE", "COND",
  "SUM", "AVG", "MIN", "MAX", "COUNT", "ROUND", "ABS", "REF", "CONST"]);

function num(v: any): number {
  const n = Number(String(v ?? "").replace(/\s/g, "").replace(",", "."));
  return isNaN(n) ? 0 : n;
}
/** Comparaison intelligente : numérique si possible, dates sinon, chaînes en dernier. */
function cmp(a: any, b: any): number {
  const na = Number(String(a ?? "").replace(",", "."));
  const nb = Number(String(b ?? "").replace(",", "."));
  const aNum = String(a ?? "").trim() !== "" && !isNaN(na);
  const bNum = String(b ?? "").trim() !== "" && !isNaN(nb);
  if (aNum && bNum) return na - nb;
  const da = a instanceof Date ? a : new Date(a);
  const db = b instanceof Date ? b : new Date(b);
  if (!isNaN(da.getTime()) && !isNaN(db.getTime())) return da.getTime() - db.getTime();
  return String(a ?? "").localeCompare(String(b ?? ""));
}
function operande(node: any, ctx: TSpContexte, ligne?: any): any {
  if (node === null || node === undefined) return null;
  if (typeof node !== "object") return node;
  if (node.ref !== undefined) {
    if (node.ref === "@result") return (ctx as any).__result;
    if (ligne && node.ref in ligne) return ligne[node.ref];
    return ctx.entete?.[node.ref];
  }
  if (node.const !== undefined) return node.const;
  if (node.op) return evaluer(node, ctx, ligne);
  return null;
}
/** Évalue un nœud déclaratif (condition ou expression numérique). */
export function evaluer(node: any, ctx: TSpContexte, ligne?: any): any {
  if (node === null || typeof node !== "object" || !node.op) return operande(node, ctx, ligne);
  const op = String(node.op).toUpperCase();
  const args: any[] = Array.isArray(node.args) ? node.args : [];
  if (OPS_LOGIQUES.has(op)) {
    switch (op) {
      case "AND": return args.every((a) => !!evaluer(a, ctx, ligne));
      case "OR": return args.some((a) => !!evaluer(a, ctx, ligne));
      case "NOT": return !evaluer(args[0], ctx, ligne);
      case "EQ": return operande(args[0], ctx, ligne) == operande(args[1], ctx, ligne);
      case "NE": return operande(args[0], ctx, ligne) != operande(args[1], ctx, ligne);
      case "GT": return cmp(operande(args[0], ctx, ligne), operande(args[1], ctx, ligne)) > 0;
      case "GE": return cmp(operande(args[0], ctx, ligne), operande(args[1], ctx, ligne)) >= 0;
      case "LT": return cmp(operande(args[0], ctx, ligne), operande(args[1], ctx, ligne)) < 0;
      case "LE": return cmp(operande(args[0], ctx, ligne), operande(args[1], ctx, ligne)) <= 0;
      case "IN": {
        const v = operande(args[0], ctx, ligne);
        return Array.isArray(args[1]) ? args[1].includes(v) : false;
      }
      case "EMPTY": {
        const v = operande(args[0], ctx, ligne);
        return v === null || v === undefined || String(v).trim() === "";
      }
      case "NOTEMPTY": return !evaluer({ op: "EMPTY", args }, ctx, ligne);
      case "CONTIENT":
        return String(operande(args[0], ctx, ligne) ?? "").includes(String(operande(args[1], ctx, ligne) ?? ""));
      default: return false;
    }
  }
  if (OPS_CALCUL.has(op)) {
    switch (op) {
      case "REF": return ctx.entete?.[node.colonne ?? ""];
      case "CONST": return node.valeur;
      case "ADD": return args.reduce((t, a) => t + num(operande(a, ctx, ligne)), 0);
      case "SUB": return num(operande(args[0], ctx, ligne)) - num(operande(args[1], ctx, ligne));
      case "MUL": return args.reduce((t, a) => t * num(operande(a, ctx, ligne)), 1);
      case "DIVSAFE": {
        const d = num(operande(args[1], ctx, ligne));
        return d === 0 ? 0 : num(operande(args[0], ctx, ligne)) / d;
      }
      case "ROUND": {
        const dec = args[1] !== undefined ? num(operande(args[1], ctx, ligne)) : 2;
        const f = Math.pow(10, dec);
        return Math.round(num(operande(args[0], ctx, ligne)) * f) / f;
      }
      case "ABS": return Math.abs(num(operande(args[0], ctx, ligne)));
      case "COND":
        return evaluer(args[0], ctx, ligne)
          ? operande(args[1], ctx, ligne)
          : operande(args[2], ctx, ligne);
      case "COUNT": return (ctx.details?.[node.table] ?? []).length;
      case "SUM":
      case "AVG":
      case "MIN":
      case "MAX": {
        const valeurs = (ctx.details?.[node.table] ?? []).map((l) => num(l?.[node.colonne]));
        if (valeurs.length === 0) return 0;
        if (op === "SUM") return valeurs.reduce((t, v) => t + v, 0);
        if (op === "AVG") return valeurs.reduce((t, v) => t + v, 0) / valeurs.length;
        if (op === "MIN") return Math.min(...valeurs);
        return Math.max(...valeurs);
      }
      default: return null;
    }
  }
  return null;
}

/* -------------------------------------------------------------------------- */
/* Graphe de dépendances des champs calculés                                  */
/* -------------------------------------------------------------------------- */
function extraireDependances(node: any, acc: { refs: string[]; tables: string[]; aggs: { table: string; colonne: string }[] }) {
  if (node === null || typeof node !== "object") return;
  if (Array.isArray(node)) { node.forEach((n) => extraireDependances(n, acc)); return; }
  if (typeof node.ref === "string" && node.ref !== "@result") acc.refs.push(node.ref);
  if (["SUM", "AVG", "MIN", "MAX", "COUNT"].includes(String(node.op ?? "").toUpperCase()) && node.table) {
    acc.tables.push(String(node.table));
    if (node.colonne) acc.aggs.push({ table: String(node.table), colonne: String(node.colonne) });
  }
  Object.keys(node).forEach((k) => { if (k !== "ref") extraireDependances(node[k], acc); });
}
export type TSpGraphe = {
  ordre: TSpChamp[];
  impactesParChamp: { [champ: string]: string[] };
  impactesParTable: { [table: string]: string[] };
  cycle: string | null;
};
export function construireGraphe(meta: TSpMeta): TSpGraphe {
  const calcules = meta.champs.filter((c) => c.Typ_Controle === "CALCULE" && c.Formule);
  const parCle: Map<string, TSpChamp> = new Map(calcules.map((c) => [`${c.Cod_Table}|${c.Nom_Colonne}`, c]));
  const deps: { [cle: string]: string[] } = {};
  const impactesParChamp: { [k: string]: string[] } = {};
  const impactesParTable: { [k: string]: string[] } = {};
  for (const c of calcules) {
    const acc = { refs: [] as string[], tables: [] as string[], aggs: [] as { table: string; colonne: string }[] };
    try { extraireDependances(JSON.parse(c.Formule!), acc); } catch { /* ignorée */ }
    const set = new Set<string>();
    // Référence simple : champ calculé de la même table, sinon de l'entête
    for (const r of acc.refs) {
      if (parCle.has(`${c.Cod_Table}|${r}`)) set.add(`${c.Cod_Table}|${r}`);
      else if (parCle.has(`ENT|${r}`)) set.add(`ENT|${r}`);
      impactesParChamp[r] = [...new Set([...(impactesParChamp[r] ?? []), c.Nom_Colonne])];
    }
    // Agrégat : dépend du champ calculé de ligne alimentant la colonne agrégée
    for (const a of acc.aggs) {
      if (parCle.has(`${a.table}|${a.colonne}`)) set.add(`${a.table}|${a.colonne}`);
    }
    for (const t of acc.tables) {
      impactesParTable[t] = [...new Set([...(impactesParTable[t] ?? []), c.Nom_Colonne])];
    }
    set.delete(`${c.Cod_Table}|${c.Nom_Colonne}`);
    deps[`${c.Cod_Table}|${c.Nom_Colonne}`] = [...set];
  }
  const ordre: TSpChamp[] = [];
  const marques: { [k: string]: "temp" | "done" } = {};
  let cycle: string | null = null;
  const visiter = (cle: string, pile: string[]) => {
    if (marques[cle] === "done") return;
    if (marques[cle] === "temp") { cycle = [...pile, cle].join(" -> "); return; }
    marques[cle] = "temp";
    for (const d of deps[cle] ?? []) visiter(d, [...pile, cle]);
    marques[cle] = "done";
    const champ = parCle.get(cle);
    if (champ && !ordre.includes(champ)) ordre.push(champ);
  };
  [...parCle.keys()].forEach((k) => visiter(k, []));
  return { ordre, impactesParChamp, impactesParTable, cycle };
}
/**
 * Recalcule uniquement les champs calculés impactés par un changement
 * (champ d'entête modifié ou lignes d'un détail modifiées).
 * Si ni champ ni table ne sont précisés, tout est recalculé (chargement).
 */
export function recalculer(
  meta: TSpMeta,
  entete: { [k: string]: any },
  details: { [k: string]: any[] },
  champModifie?: string,
  tableModifiee?: string
): { entete: { [k: string]: any }; details: { [k: string]: any[] } } {
  const graphe = construireGraphe(meta);
  if (graphe.ordre.length === 0) return { entete, details };
  let cibles: Set<string>;
  if (!champModifie && !tableModifiee) {
    cibles = new Set(graphe.ordre.map((c) => c.Nom_Colonne));
  } else {
    // Fermeture transitive des champs impactés
    cibles = new Set<string>();
    const pile: string[] = [
      ...(champModifie ? graphe.impactesParChamp[champModifie] ?? [] : []),
      ...(tableModifiee ? graphe.impactesParTable[tableModifiee] ?? [] : []),
    ];
    while (pile.length > 0) {
      const c = pile.pop()!;
      if (cibles.has(c)) continue;
      cibles.add(c);
      pile.push(...(graphe.impactesParChamp[c] ?? []));
    }
  }
  if (cibles.size === 0) return { entete, details };
  const ctx: TSpContexte = { entete, details };
  const nouvelEntete = { ...entete };
  ctx.entete = nouvelEntete;
  for (const champ of graphe.ordre) {
    if (!cibles.has(champ.Nom_Colonne)) continue;
    try {
      const formule = JSON.parse(champ.Formule!);
      if (champ.Cod_Table === "ENT") {
        nouvelEntete[champ.Nom_Colonne] = evaluer(formule, ctx);
      } else {
        // Calcul de ligne : appliqué à chaque ligne du détail concerné
        const lignes = (details[champ.Cod_Table] ?? []).map((l) => ({
          ...l,
          [champ.Nom_Colonne]: evaluer(formule, ctx, l),
        }));
        details = { ...details, [champ.Cod_Table]: lignes };
        ctx.details = details;
      }
    } catch { /* formule invalide : signalée à la publication */ }
  }
  return { entete: nouvelEntete, details };
}

/* -------------------------------------------------------------------------- */
/* Validations client (par moment)                                            */
/* -------------------------------------------------------------------------- */
function paramsJson(txt: string | null): any {
  if (!txt) return {};
  try { return JSON.parse(txt); } catch { return {}; }
}
/** Exécute les validations d'un moment donné. Retourne bloquants + avertissements. */
export function validerClient(
  meta: TSpMeta,
  ctx: TSpContexte,
  moment: "SAISIE" | "CHANGE" | "AJOUT_LIGNE" | "SAVE",
  champModifie?: string
): { erreurs: TSpErreur[]; avertissements: TSpErreur[] } {
  const erreurs: TSpErreur[] = [];
  const avertissements: TSpErreur[] = [];
  const pousser = (v: TSpValidation, ligne: number, codChamp = "") => {
    const e: TSpErreur = {
      codValidation: v.Cod_Validation, portee: v.Portee,
      codTable: v.Cod_Table ?? "ENT", codChamp: codChamp || (v.Cod_Champ ?? ""),
      ligne, niveau: v.Niveau, message: v.Message,
    };
    (v.Niveau === "B" ? erreurs : avertissements).push(e);
  };
  for (const v of meta.validations
    .filter((x) => x.Moment === moment || (moment === "SAVE" && x.Moment !== "SAISIE"))
    .sort((a, b) => a.Rang - b.Rang)) {
    // Au changement d'un champ, on ne rejoue que les règles qui le ciblent
    if (moment === "CHANGE" && champModifie && v.Cod_Champ && v.Cod_Champ !== champModifie) continue;
    const p = paramsJson(v.Parametres);
    const codTable = v.Cod_Table ?? "ENT";
    const lignes = codTable === "ENT" ? [] : (ctx.details[codTable] ?? []);
    const conditionOk = (ligne?: any): boolean => {
      if (!v.Condition_Regle) return true;
      try { return !!evaluer(JSON.parse(v.Condition_Regle), ctx, ligne); } catch { return true; }
    };
    const champ = meta.champs.find((c) => c.Cod_Champ === v.Cod_Champ);
    const nomCol = champ?.Nom_Colonne ?? v.Cod_Champ ?? "";
    const valeurChamp = (ligne?: any) => (ligne ? ligne[nomCol] : ctx.entete[nomCol]);
    try {
      switch (v.Typ_Regle) {
        case "REQUIRED": {
          const ko = (l?: any) => {
            const val = valeurChamp(l);
            return conditionOk(l) && (val === null || val === undefined || String(val).trim?.() === "");
          };
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => { if (ko(l)) pousser(v, i); });
          else if (ko()) pousser(v, -1);
          break;
        }
        case "IN": {
          const valeurs = p.valeurs ?? [];
          const ko = (l?: any) => {
            const val = valeurChamp(l);
            return conditionOk(l) && val !== null && val !== undefined && String(val) !== "" && !valeurs.includes(val);
          };
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => { if (ko(l)) pousser(v, i); });
          else if (ko()) pousser(v, -1);
          break;
        }
        case "MIN":
        case "MAX":
        case "BETWEEN": {
          const ko = (l?: any) => {
            const val = valeurChamp(l);
            if (!conditionOk(l) || val === null || val === undefined || String(val) === "") return false;
            const n = num(val);
            return (v.Typ_Regle === "MIN" && n < num(p.valeur)) ||
              (v.Typ_Regle === "MAX" && n > num(p.valeur)) ||
              (v.Typ_Regle === "BETWEEN" && (n < num(p.min) || n > num(p.max)));
          };
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => { if (ko(l)) pousser(v, i); });
          else if (ko()) pousser(v, -1);
          break;
        }
        case "MINLEN":
        case "MAXLEN": {
          const ko = (l?: any) => {
            const val = valeurChamp(l);
            if (!conditionOk(l) || val === null || val === undefined) return false;
            const L = String(val).length;
            return (v.Typ_Regle === "MINLEN" && L < num(p.valeur)) || (v.Typ_Regle === "MAXLEN" && L > num(p.valeur));
          };
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => { if (ko(l)) pousser(v, i); });
          else if (ko()) pousser(v, -1);
          break;
        }
        case "REGEX": {
          let re: RegExp | null = null;
          try { re = new RegExp(String(p.pattern ?? "")); } catch { re = null; }
          if (!re) break;
          const ko = (l?: any) => {
            const val = valeurChamp(l);
            return conditionOk(l) && val !== null && val !== undefined && String(val) !== "" && !re!.test(String(val));
          };
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => { if (ko(l)) pousser(v, i); });
          else if (ko()) pousser(v, -1);
          break;
        }
        case "COMPARE": {
          const autre = p.autre !== undefined ? { ref: p.autre } : { const: p.constante };
          const cond = { op: String(p.operateur ?? "EQ"), args: [{ ref: nomCol }, autre] };
          const ko = (l?: any) => conditionOk(l) && !evaluer(cond, ctx, l);
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => { if (ko(l)) pousser(v, i); });
          else if (ko()) pousser(v, -1);
          break;
        }
        case "UNIQUE": {
          const cols: string[] = p.colonnes ?? (nomCol ? [nomCol] : []);
          const vus = new Set<string>();
          lignes.forEach((l, i) => {
            if (!conditionOk(l)) return;
            const cle = cols.map((c) => String(l?.[c] ?? "")).join("|");
            if (cle.replace(/\|/g, "") === "") return;
            if (vus.has(cle)) pousser(v, i);
            vus.add(cle);
          });
          break;
        }
        case "NB_LIGNES": {
          if (conditionOk()) {
            const nb = lignes.length;
            if ((p.min !== undefined && nb < num(p.min)) || (p.max !== undefined && nb > num(p.max))) pousser(v, -1);
          }
          break;
        }
        case "EXPR": {
          if (!p.expr) break;
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => {
            if (conditionOk(l) && !evaluer(p.expr, ctx, l)) pousser(v, i);
          });
          else if (conditionOk() && !evaluer(p.expr, ctx)) pousser(v, -1);
          break;
        }
        // SOURCE : exécutée côté serveur uniquement (sécurité)
        default:
          break;
      }
    } catch { /* une règle invalide est ignorée côté client, bloquée côté serveur */ }
  }
  return { erreurs, avertissements };
}
/** Règle de visibilité / activation d'un champ (Etat + règle déclarative). */
export function champVisible(champ: TSpChamp, ctx: TSpContexte): boolean {
  if (champ.Etat === "I") return false;
  if (!champ.Regle_Visibilite) return true;
  try { return !!evaluer(JSON.parse(champ.Regle_Visibilite), ctx); } catch { return true; }
}
export function champActif(champ: TSpChamp, ctx: TSpContexte): boolean {
  if (champ.Etat === "R" || champ.Etat === "A") return false;
  if (!champ.Regle_Activation) return true;
  try { return !!evaluer(JSON.parse(champ.Regle_Activation), ctx); } catch { return true; }
}
