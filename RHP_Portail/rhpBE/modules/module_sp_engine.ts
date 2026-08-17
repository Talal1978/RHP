/* ============================================================================
   Module SP_ - Moteur d'exécution des pages dynamiques du portail
   ----------------------------------------------------------------------------
   Principes :
   - Aucune table/colonne n'est jamais choisie par le client : toute opération
     est résolue à partir des métadonnées PUBLIÉES chargées côté serveur.
   - Tous les identifiants SQL sont validés (regex + liste noire) et quotés.
   - Toutes les valeurs sont passées en paramètres typés (@p_*).
   - Validations et calculs sont DÉCLARATIFS (json), jamais de code libre.
   - Les enregistrements entête + détails sont TRANSACTIONNELS.
   ============================================================================ */
import sql from "mssql";
import { getPool, lireSql } from "./module_sqlRW";
import { getCache, setCache, invalidateCache } from "./module_cache";

/* -------------------------------------------------------------------------- */
/* 1. Types des métadonnées                                                   */
/* -------------------------------------------------------------------------- */
export type TSpPage = {
  Cod_Page: string;
  Cod_Document: string;
  Libelle: string;
  Libelle_Court: string;
  Nom_Page: string;
  Menu_Parent: string;
  Rang: number;
  Icone: string;
  Statut_Page: "BROUILLON" | "PUBLIE" | "DESACTIVE" | "ARCHIVE";
  Table_Ent: string;
  Typ_Document: string;
  Workflow_Actif: string;
  Cod_Modele_Edition: string;
  GED_Actif: string;
  GED_Categories: string;
  GED_Obligatoire: string;
  Act_Enregistrer: string;
  Act_Soumettre: string;
  Act_Imprimer: string;
  Act_Exporter: string;
  Figer_Statuts: string; // statuts figeant le document (CSV, defaut 'SG,RJ,SP,VA')
  Version_Page: number;
};
export type TSpTable = {
  Cod_Page: string;
  Cod_Table: string; // 'ENT' ou code du détail
  Nom_Physique: string;
  Role_Table: "ENT" | "DET";
  Libelle: string;
  Rang: number;
  Allow_Add: string;
  Allow_Edit: string;
  Allow_Delete: string;
  Allow_Duplicate: string;
  Tri_Defaut: string;
  Regle_Suppression: string;
  /** Détail VIRTUEL : code d'une source Controle_Designer_Source (Typ_Retour='TABLE')
   *  alimentant la grille en lecture seule - aucune table physique n'est lue
   *  ni écrite pour ce détail. */
  Source_Metier: string | null;
  /** json de mapping des paramètres de la source : {"Param":{"ref":"ColonneEntete"}} */
  Source_Mapping: string | null;
};
export type TSpColonne = {
  Cod_Page: string;
  Cod_Table: string;
  Nom_Colonne: string;
  Libelle: string;
  Typ_Sql: string;
  Longueur: number | null;
  Precision_Sql: number | null;
  Echelle_Sql: number | null;
  Nullable: string;
  Valeur_Defaut: string | null;
  estUnique: string;
  estPK: string;
  estIndexe: string;
  Technique: string;
  Rang: number;
};
export type TSpChamp = {
  Cod_Page: string;
  Cod_Champ: string;
  Cod_Table: string;
  Nom_Colonne: string | null; // null/vide : champ non stocké (affiché, ou calculé de pied de grille si rattaché à un détail)
  Libelle: string;
  Typ_Controle: string;
  Rang: number;
  Ligne: number | null;
  Colonne: number | null;
  Largeur: number | null;
  Valeur_Defaut: string | null;
  Aide: string | null;
  Obligatoire: string;
  Etat: "S" | "R" | "A" | "I";
  Rubrique: string | null;
  Num_Zoom: string | null;
  Zoom_Retour: string | null;
  Zoom_Condition: string | null; // condition du zoom avec placeholders "{Champ}" evalues dans le contexte
  Source_Metier: string | null;
  Formule: string | null;
  Persiste: string;
  Recalc_Save: string;
  Format_Affichage: string | null;
  Decimales: number | null;
  Regle_Visibilite: string | null;
  Regle_Activation: string | null;
  Visible_Grille: string;
  Rang_Grille: number;
  Largeur_Colonne: number | null;
  estCritere: string;
  Rang_Critere: number | null;
};
export type TSpValidation = {
  Cod_Page: string;
  Cod_Validation: string;
  Portee: "CHAMP" | "ENTETE" | "LIGNE" | "DETAIL" | "DOCUMENT";
  Cod_Table: string | null;
  Cod_Champ: string | null;
  Typ_Regle: string;
  Parametres: string | null;
  Condition_Regle: string | null;
  Message: string;
  Niveau: "I" | "W" | "B";
  Rang: number;
  Moment: string;
  Actif: string;
};
export type TSpMeta = {
  page: TSpPage;
  tables: TSpTable[];
  colonnes: TSpColonne[];
  champs: TSpChamp[];
  validations: TSpValidation[];
};
export type TSpErreur = {
  codValidation: string;
  portee: string;
  codTable: string;
  codChamp: string;
  ligne: number; // -1 = entête/document
  niveau: "I" | "W" | "B";
  message: string;
};

/* -------------------------------------------------------------------------- */
/* 2. Sécurité des identifiants SQL                                           */
/* -------------------------------------------------------------------------- */
const MOTS_RESERVES = new Set([
  "select", "insert", "update", "delete", "drop", "alter", "create", "exec",
  "execute", "union", "grant", "revoke", "truncate", "merge", "into", "from",
  "where", "table", "backup", "restore", "shutdown", "sysobjects", "xp_cmdshell",
]);
/** Validation stricte d'un identifiant SQL (table ou colonne). */
export function validerIdentifiant(nom: string): { ok: boolean; message?: string } {
  if (!nom || !/^[A-Za-z_][A-Za-z0-9_]{0,59}$/.test(nom)) {
    return { ok: false, message: `Identifiant SQL invalide : '${nom}'` };
  }
  if (MOTS_RESERVES.has(nom.toLowerCase())) {
    return { ok: false, message: `Identifiant réservé : '${nom}'` };
  }
  return { ok: true };
}
/** Quote un identifiant déjà validé (défense en profondeur). */
export function qn(nom: string): string {
  const v = validerIdentifiant(nom);
  if (!v.ok) throw new Error(v.message);
  return `[${nom.replace(/]/g, "]]")}]`;
}
/** Vérifie qu'un nom de table métier respecte le préfixe SP_. */
export function validerNomTableMetier(nom: string): { ok: boolean; message?: string } {
  const v = validerIdentifiant(nom);
  if (!v.ok) return v;
  if (!nom.startsWith("SP_")) {
    return { ok: false, message: `La table '${nom}' doit commencer par le préfixe SP_` };
  }
  return { ok: true };
}

/* -------------------------------------------------------------------------- */
/* 3. Typage SQL des valeurs                                                  */
/* -------------------------------------------------------------------------- */
export function sqlTypePour(col: TSpColonne): any {
  switch (col.Typ_Sql.toLowerCase()) {
    case "int": return sql.Int;
    case "bigint": return sql.BigInt;
    case "float": return sql.Float;
    case "decimal": return sql.Decimal(col.Precision_Sql ?? 18, col.Echelle_Sql ?? 2);
    case "bit": return sql.Bit;
    case "date": return sql.Date;
    case "datetime": return sql.DateTime;
    case "smalldatetime": return sql.SmallDateTime;
    case "nvarchar":
    default: {
      const len = !col.Longueur || col.Longueur <= 0 ? 4000 : Math.min(col.Longueur, 4000);
      return sql.NVarChar(len);
    }
  }
}
/** Conversion d'une valeur JSON vers le type de la colonne (null-safe). */
export function valeurPour(col: TSpColonne, val: any): any {
  if (val === undefined || val === null || val === "") {
    if (col.Typ_Sql.toLowerCase() === "nvarchar" && col.Nullable === "false") return "";
    return null;
  }
  switch (col.Typ_Sql.toLowerCase()) {
    case "int":
    case "bigint": {
      const n = parseInt(String(val), 10);
      return isNaN(n) ? null : n;
    }
    case "float":
    case "decimal": {
      const n = Number(String(val).replace(",", ".").replace(/\s/g, ""));
      return isNaN(n) ? null : n;
    }
    case "bit":
      return val === true || val === 1 || val === "1" || String(val).toLowerCase() === "true" ? 1 : 0;
    case "date":
    case "datetime":
    case "smalldatetime": {
      if (val instanceof Date) return isNaN(val.getTime()) ? null : val;
      const s = String(val).trim();
      // Canon « heure naïve » : la lecture d'horloge littérale est stockée telle quelle
      const d = versDate(s) ?? new Date(s);
      return isNaN(d.getTime()) ? null : d;
    }
    default:
      return String(val);
  }
}

/* -------------------------------------------------------------------------- */
/* 4. Chargement des métadonnées (cache 60 s)                                 */
/* -------------------------------------------------------------------------- */
export function invaliderCachePage(codPage?: string) {
  invalidateCache(codPage ? `SPMETA_${codPage}` : "SPMETA_");
}
export async function chargerMetaPage(codPage: string): Promise<TSpMeta | null> {
  const cle = `SPMETA_${codPage}`;
  const cached = getCache<TSpMeta>(cle);
  if (cached) return cached;
  const vid = validerIdentifiant(codPage);
  if (!vid.ok) return null;
  const p = [{ param: "p_cp", sqlType: sql.NVarChar, valeur: codPage }];
  const [rPage, rTables, rCols, rChamps, rValids] = await Promise.all([
    lireSql(`select * from Controle_Designer where Cod_Page=@p_cp`, p),
    lireSql(`select * from Controle_Designer_Table where Cod_Page=@p_cp order by Rang`, p),
    lireSql(`select * from Controle_Designer_Colonne where Cod_Page=@p_cp order by Cod_Table, Rang`, p),
    lireSql(`select * from Controle_Designer_Champ where Cod_Page=@p_cp order by Cod_Table, Rang`, p),
    lireSql(`select * from Controle_Designer_Validation where Cod_Page=@p_cp and isnull(Actif,'true')='true' order by Rang`, p),
  ]);
  if (!rPage.result || rPage.data.length === 0) return null;
  const meta: TSpMeta = {
    page: rPage.data[0],
    tables: rTables.data ?? [],
    colonnes: rCols.data ?? [],
    champs: rChamps.data ?? [],
    validations: rValids.data ?? [],
  };
  // Cohérence minimale : les noms physiques doivent être des identifiants sûrs
  for (const t of meta.tables) {
    if (!validerNomTableMetier(t.Nom_Physique).ok) return null;
  }
  for (const c of meta.colonnes) {
    if (!validerIdentifiant(c.Nom_Colonne).ok) return null;
  }
  setCache(cle, meta, 60);
  return meta;
}

/* -------------------------------------------------------------------------- */
/* 5. Habilitations par action                                                */
/* -------------------------------------------------------------------------- */
export type TSpAction = "Consulter" | "Creer" | "Modifier" | "Supprimer" | "Valider" | "Imprimer" | "GED";
export async function verifierDroit(
  codPage: string, codProfile: string, action: TSpAction
): Promise<boolean> {
  if (String(codProfile) === "1") return true; // super-admin (convention RHP)
  // Accès non personnalisé : la consultation est ouverte à tous les profils,
  // y compris ceux créés après la publication de la page.
  const cond =
    action === "Consulter"
      ? `(isnull(p.Acces_Personnalise,'true')='false' or isnull(d.${qn(action)},'false')='true')`
      : `isnull(d.${qn(action)},'false')='true'`;
  const rsl = await lireSql(
    `select count(*) as nb
     from Controle_Designer p
     left join Controle_Designer_Droit d
       on d.Cod_Page = p.Cod_Page and d.Cod_Profile = @p_pr
     where p.Cod_Page = @p_cp and ${cond}`,
    [
      { param: "p_cp", sqlType: sql.NVarChar, valeur: codPage },
      { param: "p_pr", sqlType: sql.NVarChar, valeur: String(codProfile ?? "") },
    ]
  );
  return rsl.result && (rsl.data?.[0]?.nb ?? 0) > 0;
}

/* -------------------------------------------------------------------------- */
/* 6. Évaluateur déclaratif (conditions, expressions, formules)               */
/*    Format json strictement limité - AUCUN eval, AUCUN code libre.          */
/* -------------------------------------------------------------------------- */
export type TSpContexte = {
  entete: { [k: string]: any };
  details: { [codTable: string]: any[] };
};
const OPS_LOGIQUES = new Set(["AND", "OR", "NOT", "EQ", "NE", "GT", "GE", "LT", "LE",
  "IN", "EMPTY", "NOTEMPTY", "CONTIENT"]);
const OPS_CALCUL = new Set(["ADD", "SUB", "MUL", "DIVSAFE", "COND",
  "SUM", "AVG", "MIN", "MAX", "COUNT", "ROUND", "ABS", "REF", "CONST", "DATEDIFF",
  "LEFT", "RIGHT", "SUBSTRING", "INDEXOF", "LEN", "UPPER", "LOWER", "TRIM", "REPLACE", "CONCAT",
  "INT", "CEIL", "FLOOR", "DATEADD", "DATEPART", "DAYOFWEEK"]);

/** Variables globales GV_* utilisables dans les formules (date/heure du serveur).
 *  Aligné sur GlobalVar() du desktop ; les GV inconnues retournent null (0 en numérique). */
function variableGlobale(nom: string): any {
  const d = new Date();
  switch (nom.toUpperCase()) {
    case "GV_NOW": return d;
    case "GV_TODAY": return new Date(d.getFullYear(), d.getMonth(), d.getDate()); // jour sans l'heure
    case "GV_YEAR": return d.getFullYear();
    case "GV_MONTH": return d.getMonth() + 1;
    case "GV_DAY": return d.getDate();
    case "GV_DEBMOIS": return new Date(d.getFullYear(), d.getMonth(), 1);
    case "GV_FINMOIS": return new Date(d.getFullYear(), d.getMonth() + 1, 0);
    case "GV_DEBYEAR": return new Date(d.getFullYear(), 0, 1);
    default: return null;
  }
}

function operande(node: any, ctx: TSpContexte, ligne?: any): any {
  if (node === null || node === undefined) return null;
  if (typeof node !== "object") return node; // constante littérale
  if (node.ref !== undefined) {
    if (node.ref === "@result") return (ctx as any).__result;
    if (typeof node.ref === "string" && node.ref.startsWith("GV_")) return variableGlobale(node.ref);
    if (ligne && node.ref in ligne) return ligne[node.ref];
    return ctx.entete?.[node.ref];
  }
  if (node.const !== undefined) return node.const;
  if (node.op) return evaluer(node, ctx, ligne);
  return null;
}
function num(v: any): number {
  const n = Number(String(v ?? "").replace(",", "."));
  return isNaN(n) ? 0 : n;
}
/** Conversion stricte en date, canon « heure naïve » : la lecture d'horloge littérale
 *  fait foi, le fuseau est ignoré (les valeurs circulent en lectures d'horloge entre le
 *  portail, le fil JSON et la base). Retourne un instant UTC matérialisant cette lecture :
 *  Date -> ses composants LOCAUX ; chaîne ISO/FR -> ses composants littéraux.
 *  Tout le reste (nombres, autres chaînes) retourne null — on ne devine jamais une date. */
function versDate(v: any): Date | null {
  if (v instanceof Date) {
    if (isNaN(v.getTime())) return null;
    return new Date(Date.UTC(v.getFullYear(), v.getMonth(), v.getDate(),
      v.getHours(), v.getMinutes(), v.getSeconds()));
  }
  if (typeof v !== "string") return null;
  const s = v.trim();
  let m = /^(\d{4})-(\d{2})-(\d{2})(?:[T ](\d{2}):(\d{2})(?::(\d{2}))?)?/.exec(s);
  if (m) return new Date(Date.UTC(+m[1], +m[2] - 1, +m[3], +(m[4] ?? 0), +(m[5] ?? 0), +(m[6] ?? 0)));
  m = /^(\d{2})\/(\d{2})\/(\d{4})(?:[ T](\d{2}):(\d{2})(?::(\d{2}))?)?/.exec(s);
  if (m) return new Date(Date.UTC(+m[3], +m[2] - 1, +m[1], +(m[4] ?? 0), +(m[5] ?? 0), +(m[6] ?? 0)));
  return null;
}
/** Comparaison intelligente : numérique si possible, dates sinon, chaînes en dernier. */
function cmp(a: any, b: any): number {
  const na = Number(String(a ?? "").replace(",", "."));
  const nb = Number(String(b ?? "").replace(",", "."));
  const aNum = String(a ?? "").trim() !== "" && !isNaN(na);
  const bNum = String(b ?? "").trim() !== "" && !isNaN(nb);
  if (aNum && bNum) return na - nb;
  const da = versDate(a) ?? new Date(a);
  const db = versDate(b) ?? new Date(b);
  if (!isNaN(da.getTime()) && !isNaN(db.getTime())) return da.getTime() - db.getTime();
  return String(a ?? "").localeCompare(String(b ?? ""));
}
/** Conversion en texte pour les fonctions de chaînes, canon « heure naïve » :
 *  une date devient sa lecture d'horloge littérale "AAAA-MM-JJ HH:mm:ss"
 *  (identique côté client et côté serveur, quel que soit le fuseau). */
function txt(v: any): string {
  if (v === null || v === undefined) return "";
  if (v instanceof Date) {
    const d = versDate(v);
    if (!d) return "";
    const p = (x: number) => String(x).padStart(2, "0");
    return `${d.getUTCFullYear()}-${p(d.getUTCMonth() + 1)}-${p(d.getUTCDate())} ${p(d.getUTCHours())}:${p(d.getUTCMinutes())}:${p(d.getUTCSeconds())}`;
  }
  if (typeof v === "boolean") return v ? "true" : "false";
  return String(v);
}
/** Ajoute n unités à une date du canon UTC : S/MI/H/J en millisecondes ;
 *  MO/A par composants avec clamp au dernier jour du mois cible (comme SQL DATEADD). */
function ajouterDate(d: Date, n: number, unite: string): Date | null {
  switch (unite) {
    case "S": return new Date(d.getTime() + n * 1000);
    case "MI": return new Date(d.getTime() + n * 60000);
    case "H": return new Date(d.getTime() + n * 3600000);
    case "J": return new Date(d.getTime() + n * 86400000);
    case "MO":
    case "A": {
      const ni = Math.trunc(n) * (unite === "A" ? 12 : 1);
      const total = d.getUTCFullYear() * 12 + d.getUTCMonth() + ni;
      const y = Math.floor(total / 12);
      const m = total - y * 12;
      const dim = new Date(Date.UTC(y, m + 1, 0)).getUTCDate(); // nb de jours du mois cible
      return new Date(Date.UTC(y, m, Math.min(d.getUTCDate(), dim),
        d.getUTCHours(), d.getUTCMinutes(), d.getUTCSeconds()));
    }
    default: return null;
  }
}
/** Évalue un nœud déclaratif (condition OU expression numérique). */
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
      case "NOTEMPTY": {
        const v = operande(args[0], ctx, ligne);
        return !(v === null || v === undefined || String(v).trim() === "");
      }
      case "CONTIENT": {
        const v = String(operande(args[0], ctx, ligne) ?? "");
        return v.includes(String(operande(args[1], ctx, ligne) ?? ""));
      }
      default: return false;
    }
  }
  if (OPS_CALCUL.has(op)) {
    switch (op) {
      case "REF": return ctx.entete?.[node.colonne ?? ""];
      case "CONST": return node.valeur;
      case "ADD": return args.reduce((t, a) => t + num(operande(a, ctx, ligne)), 0);
      case "SUB": {
        // Soustraction de deux dates -> durée en secondes ; sinon arithmétique classique.
        const a = operande(args[0], ctx, ligne);
        const b = operande(args[1], ctx, ligne);
        const da = versDate(a);
        const db = versDate(b);
        if (da && db) return (da.getTime() - db.getTime()) / 1000;
        return num(a) - num(b);
      }
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
      /* ---- Fonctions texte (positions 1-based, convention tableur) ---- */
      case "LEFT": {
        const s = txt(operande(args[0], ctx, ligne));
        return s.slice(0, Math.min(Math.max(0, Math.trunc(num(operande(args[1], ctx, ligne)))), s.length));
      }
      case "RIGHT": {
        const s = txt(operande(args[0], ctx, ligne));
        const n = Math.min(Math.max(0, Math.trunc(num(operande(args[1], ctx, ligne)))), s.length);
        return s.slice(s.length - n);
      }
      case "SUBSTRING": {
        // STXT(texte; début; longueur?) : début 1-based ; sans longueur -> jusqu'à la fin
        const s = txt(operande(args[0], ctx, ligne));
        const d = Math.max(1, Math.trunc(num(operande(args[1], ctx, ligne))));
        if (args[2] === undefined) return s.slice(d - 1);
        const n = Math.max(0, Math.trunc(num(operande(args[2], ctx, ligne))));
        return s.slice(d - 1, d - 1 + n);
      }
      case "INDEXOF": {
        // POSITION(morceau; texte) : position 1-based ; 0 si absent
        const cherche = txt(operande(args[0], ctx, ligne));
        if (cherche === "") return 0;
        return txt(operande(args[1], ctx, ligne)).indexOf(cherche) + 1;
      }
      case "LEN": return txt(operande(args[0], ctx, ligne)).length;
      case "UPPER": return txt(operande(args[0], ctx, ligne)).toUpperCase();
      case "LOWER": return txt(operande(args[0], ctx, ligne)).toLowerCase();
      case "TRIM": return txt(operande(args[0], ctx, ligne)).trim();
      case "REPLACE": {
        const s = txt(operande(args[0], ctx, ligne));
        const ancien = txt(operande(args[1], ctx, ligne));
        return ancien === "" ? s : s.split(ancien).join(txt(operande(args[2], ctx, ligne)));
      }
      case "CONCAT": return args.map((a) => txt(operande(a, ctx, ligne))).join("");
      /* ---- Fonctions nombres ---- */
      case "INT": return Math.floor(num(operande(args[0], ctx, ligne))); // ENT tableur : vers -∞
      case "CEIL": return Math.ceil(num(operande(args[0], ctx, ligne)));
      case "FLOOR": return Math.floor(num(operande(args[0], ctx, ligne)));
      case "DATEDIFF": {
        // Durée args[0] - args[1] convertie dans l'unité demandée (S/MI/H/J, défaut J).
        // Dates invalides -> 0 (même philosophie que num() : jamais d'erreur bloquante).
        const da = versDate(operande(args[0], ctx, ligne));
        const db = versDate(operande(args[1], ctx, ligne));
        if (!da || !db) return 0;
        const ms = da.getTime() - db.getTime();
        switch (String(node.unite ?? "J").toUpperCase()) {
          case "S": return ms / 1000;
          case "MI": return ms / 60000;
          case "H": return ms / 3600000;
          default: return ms / 86400000; // "J"
        }
      }
      case "DATEADD": {
        // Date + n unités (S/MI/H/J/MO/A) ; date invalide -> null
        const d = versDate(operande(args[0], ctx, ligne));
        if (!d) return null;
        return ajouterDate(d, num(operande(args[1], ctx, ligne)),
          String(node.unite ?? "J").toUpperCase());
      }
      case "DATEPART": {
        // Partie d'une date en nombre ; date invalide -> 0
        const d = versDate(operande(args[0], ctx, ligne));
        if (!d) return 0;
        switch (String(node.partie ?? "J").toUpperCase()) {
          case "A": return d.getUTCFullYear();
          case "M": return d.getUTCMonth() + 1;
          case "J": return d.getUTCDate();
          case "H": return d.getUTCHours();
          case "MI": return d.getUTCMinutes();
          default: return d.getUTCSeconds(); // "S"
        }
      }
      case "DAYOFWEEK": {
        // Jour de la semaine : 1 = lundi … 7 = dimanche ; date invalide -> 0
        const d = versDate(operande(args[0], ctx, ligne));
        if (!d) return 0;
        return ((d.getUTCDay() + 6) % 7) + 1;
      }
      case "COND":
        return evaluer(args[0], ctx, ligne)
          ? operande(args[1], ctx, ligne)
          : operande(args[2], ctx, ligne);
      case "SUM":
      case "AVG":
      case "COUNT": {
        const lignes = ctx.details?.[node.table] ?? [];
        if (op === "COUNT") return lignes.length;
        const valeurs = lignes.map((l) => num(l?.[node.colonne]));
        if (valeurs.length === 0) return 0;
        if (op === "SUM") return valeurs.reduce((t, v) => t + v, 0);
        return valeurs.reduce((t, v) => t + v, 0) / valeurs.length;
      }
      case "MIN":
      case "MAX": {
        // Avec "table" : agrégat sur les lignes ; sans "table" : forme scalaire
        // (plus petite / plus grande des valeurs des arguments).
        const valeurs = node.table
          ? (ctx.details?.[node.table] ?? []).map((l) => num(l?.[node.colonne]))
          : args.map((a) => num(operande(a, ctx, ligne)));
        if (valeurs.length === 0) return 0;
        return op === "MIN" ? Math.min(...valeurs) : Math.max(...valeurs);
      }
      default: return null;
    }
  }
  throw new Error(`Opérateur déclaratif non autorisé : '${node.op}'`);
}
/** Valide qu'un json de formule/condition n'utilise que des opérateurs autorisés. */
export function validerExpression(node: any, profondeur = 0): { ok: boolean; message?: string } {
  if (profondeur > 20) return { ok: false, message: "Expression trop profonde (>20)" };
  if (node === null || typeof node !== "object") return { ok: true };
  if (Array.isArray(node)) {
    for (const n of node) {
      const r = validerExpression(n, profondeur + 1);
      if (!r.ok) return r;
    }
    return { ok: true };
  }
  if (node.op !== undefined) {
    const op = String(node.op).toUpperCase();
    if (!OPS_LOGIQUES.has(op) && !OPS_CALCUL.has(op)) {
      return { ok: false, message: `Opérateur non autorisé : '${node.op}'` };
    }
  }
  for (const k of Object.keys(node)) {
    const r = validerExpression(node[k], profondeur + 1);
    if (!r.ok) return r;
  }
  return { ok: true };
}

/* -------------------------------------------------------------------------- */
/* 7. Graphe de dépendances des champs calculés                               */
/* -------------------------------------------------------------------------- */
/** Clé de stockage d'un champ dans le contexte : Nom_Colonne, sinon Cod_Champ
 *  (un champ calculé non persisté peut n'être rattaché à aucune colonne physique). */
export function cleChamp(c: { Nom_Colonne: string | null; Cod_Champ: string }): string {
  return c.Nom_Colonne || c.Cod_Champ;
}
function extraireDependances(node: any, acc: { refs: string[]; tables: string[]; aggs: { table: string; colonne: string }[] }) {
  if (node === null || typeof node !== "object") return;
  if (Array.isArray(node)) { node.forEach((n) => extraireDependances(n, acc)); return; }
  if (node.ref !== undefined && typeof node.ref === "string" && node.ref !== "@result"
    && !node.ref.startsWith("GV_")) { // les GV_* ne sont pas des champs : pas de dépendance
    acc.refs.push(node.ref);
  }
  if (["SUM", "AVG", "MIN", "MAX", "COUNT"].includes(String(node.op ?? "").toUpperCase()) && node.table) {
    acc.tables.push(String(node.table));
    if (node.colonne) acc.aggs.push({ table: String(node.table), colonne: String(node.colonne) });
  }
  Object.keys(node).forEach((k) => {
    if (k !== "ref") extraireDependances(node[k], acc);
  });
}
export type TSpGraphe = {
  ordre: TSpChamp[];                       // champs calculés en ordre topologique
  impactesParChamp: { [champ: string]: string[] };   // champ saisi -> calculés à rafraîchir
  impactesParTable: { [table: string]: string[] };   // table détail -> calculés à rafraîchir
  cycle: string | null;                    // description du cycle détecté
};
export function construireGraphe(meta: TSpMeta): TSpGraphe {
  const calcules = meta.champs.filter((c) => c.Typ_Controle === "CALCULE" && c.Formule);
  const parCle: Map<string, TSpChamp> = new Map(calcules.map((c) => [`${c.Cod_Table}|${cleChamp(c)}`, c]));
  const deps: { [cle: string]: string[] } = {};
  const impactesParChamp: { [k: string]: string[] } = {};
  const impactesParTable: { [k: string]: string[] } = {};
  for (const c of calcules) {
    const acc = { refs: [] as string[], tables: [] as string[], aggs: [] as { table: string; colonne: string }[] };
    try { extraireDependances(JSON.parse(c.Formule!), acc); } catch { /* formule ignorée */ }
    const set = new Set<string>();
    // Référence simple : champ calculé de la même table, sinon de l'entête
    for (const r of acc.refs) {
      if (parCle.has(`${c.Cod_Table}|${r}`)) set.add(`${c.Cod_Table}|${r}`);
      else if (parCle.has(`ENT|${r}`)) set.add(`ENT|${r}`);
      impactesParChamp[r] = [...new Set([...(impactesParChamp[r] ?? []), cleChamp(c)])];
    }
    // Agrégat : dépend du champ calculé de ligne alimentant la colonne agrégée
    for (const a of acc.aggs) {
      if (parCle.has(`${a.table}|${a.colonne}`)) set.add(`${a.table}|${a.colonne}`);
    }
    for (const t of acc.tables) {
      impactesParTable[t] = [...new Set([...(impactesParTable[t] ?? []), cleChamp(c)])];
    }
    set.delete(`${c.Cod_Table}|${cleChamp(c)}`); // pas d'auto-référence
    deps[`${c.Cod_Table}|${cleChamp(c)}`] = [...set];
  }
  // Tri topologique (DFS avec détection de cycle)
  const ordre: TSpChamp[] = [];
  const marques: { [k: string]: "temp" | "done" } = {};
  let cycle: string | null = null;
  const visiter = (cle: string, pile: string[]) => {
    if (marques[cle] === "done") return;
    if (marques[cle] === "temp") {
      cycle = [...pile, cle].join(" -> ");
      return;
    }
    marques[cle] = "temp";
    for (const d of deps[cle] ?? []) visiter(d, [...pile, cle]);
    marques[cle] = "done";
    const champ = parCle.get(cle);
    if (champ && !ordre.includes(champ)) ordre.push(champ);
  };
  [...parCle.keys()].forEach((k) => visiter(k, []));
  return { ordre, impactesParChamp, impactesParTable, cycle };
}
/** Recalcule les champs calculés (ordre topologique ; lignes puis entête selon dépendances). */
export function recalculer(meta: TSpMeta, ctx: TSpContexte, ligne?: any): { cycle: string | null } {
  const graphe = construireGraphe(meta);
  for (const champ of graphe.ordre) {
    try {
      const formule = JSON.parse(champ.Formule!);
      // Niveau document : champ d'entête, ou pied de grille (champ rattaché à un
      // détail mais sans colonne physique -> agrégat sur ses lignes, jamais stocké).
      if (champ.Cod_Table === "ENT" || !champ.Nom_Colonne) {
        ctx.entete[cleChamp(champ)] = evaluer(formule, ctx, ligne);
      } else {
        // Calcul de ligne : appliqué à chaque ligne du détail concerné
        for (const l of ctx.details?.[champ.Cod_Table] ?? []) {
          l[cleChamp(champ)] = evaluer(formule, ctx, l);
        }
      }
    } catch { /* formule invalide : ignorée, signalée à la publication */ }
  }
  return { cycle: graphe.cycle };
}

/* -------------------------------------------------------------------------- */
/* 8. Moteur de validations déclaratives                                      */
/* -------------------------------------------------------------------------- */
function paramsJson(txt: string | null): any {
  if (!txt) return {};
  try { return JSON.parse(txt); } catch { return {}; }
}
/** Exécute une source du catalogue sécurisé (jamais de SQL libre du client). */
export async function executerSource(
  codSource: string, mapping: { [p: string]: any },
  agent: { codProfile: string; id_Societe: string; Login?: string; Matricule?: string }
): Promise<{ ok: boolean; valeur?: any; data?: any[]; typRetour?: string; message?: string }> {
  const vid = validerIdentifiant(codSource);
  if (!vid.ok) return { ok: false, message: vid.message };
  const rsl = await lireSql(
    `select * from Controle_Designer_Source where Cod_Source=@p_cs and isnull(Actif,'true')='true'`,
    [{ param: "p_cs", sqlType: sql.NVarChar, valeur: codSource }]
  );
  if (!rsl.result || rsl.data.length === 0) return { ok: false, message: `Source '${codSource}' introuvable` };
  const src = rsl.data[0];
  if (src.Cod_Profile && String(agent.codProfile) !== "1" && src.Cod_Profile !== String(agent.codProfile)) {
    return { ok: false, message: `Source '${codSource}' non autorisée pour ce profil` };
  }
  const controle = estRequeteLectureSeule(String(src.Code_Sql ?? ""));
  if (!controle.ok) return { ok: false, message: controle.message };
  const declared: { Nom: string; Typ: string }[] = paramsJson(src.Parametres) instanceof Array
    ? paramsJson(src.Parametres) : [];
  // Une valeur Date est serialisee en ISO avant le binding NVarChar (le driver
  // rejette les objets Date sur NVarChar - le chemin HTTP/JSON les apporte
  // toujours en chaines, cet encodage couvre les appels internes).
  const valeurParam = (v: any) =>
    v instanceof Date ? (isNaN(v.getTime()) ? null : v.toISOString()) : (v ?? null);
  const params: { param: string; sqlType: any; valeur: any }[] = [
    { param: "id_Societe", sqlType: sql.Int, valeur: Number(agent.id_Societe) },
  ];
  for (const d of declared) {
    const vp = validerIdentifiant(String(d.Nom ?? ""));
    if (!vp.ok) return { ok: false, message: `Paramètre de source invalide : '${d.Nom}'` };
    params.push({
      param: String(d.Nom),
      sqlType: String(d.Typ ?? "").toLowerCase().startsWith("int") ? sql.Int : sql.NVarChar,
      valeur: valeurParam(mapping?.[d.Nom]),
    });
  }
  // Identité de l'utilisateur connecté injectée comme @id_Societe (jamais
  // declarable dans Parametres ; permet les regles d'appartenance).
  const declares = new Set(declared.map((d) => String(d.Nom ?? "").toLowerCase()));
  if (!declares.has("login")) params.push({ param: "Login", sqlType: sql.NVarChar, valeur: String(agent.Login ?? "") });
  if (!declares.has("matricule")) params.push({ param: "Matricule", sqlType: sql.NVarChar, valeur: String(agent.Matricule ?? "") });
  if (!declares.has("cod_profile")) params.push({ param: "Cod_Profile", sqlType: sql.NVarChar, valeur: String(agent.codProfile ?? "") });
  const r = await lireSql(String(src.Code_Sql), params);
  if (!r.result) return { ok: false, message: "Erreur d'exécution de la source" };
  const row = r.data?.[0];
  return {
    ok: true,
    valeur: row ? Object.values(row)[0] : null,
    data: r.data ?? [],
    typRetour: src.Typ_Retour,
  };
}
/** Garde-fou : une source ne peut être qu'une lecture (SELECT/WITH) ou une proc Sys_*. */
export function estRequeteLectureSeule(code: string): { ok: boolean; message?: string } {
  const cleaned = code
    .replace(/\/\*.*?\*\//gs, "")
    .replace(/--.*?(\n|$)/g, " ")
    .replace(/\s+/g, " ")
    .trim();
  // Les littéraux chaînes sont neutralisés AVANT le contrôle multi-instructions :
  // un ';' dans un littéral (ex. '1;1;1;1;1;1;0') n'est pas un separateur.
  const sansLitteraux = cleaned.replace(/'(?:[^']|'')*'/g, "''");
  if (/;.*\S/.test(sansLitteraux.replace(/;\s*$/, ""))) {
    return { ok: false, message: "Instruction multiple interdite" };
  }
  const debut = sansLitteraux.toLowerCase();
  if (!/^(select|with)\b/.test(debut) && !/^exec(ute)?\s+dbo\.sys_\w+/.test(debut)) {
    return { ok: false, message: "Seuls SELECT / WITH / EXEC dbo.Sys_* sont autorisés" };
  }
  const blackList =
    /\b(insert|update|delete|merge|drop|alter|create|truncate|grant|revoke|backup|restore|shutdown|kill|waitfor|openrowset|opendatasource|xp_\w+)\b/i;
  // sp_* (procédures système) : contrôle SENSIBLE à la casse — les tables
  // métier du module sont préfixées 'SP_' (majuscules) et restent lisibles ;
  // les procédures système sont en minuscules ('sp_executesql'...). De plus,
  // le garde d'entrée (select|with|exec dbo.Sys_*) empêche tout appel de proc.
  const blackListProcs = /\bsp_\w+\b/;
  if (blackList.test(sansLitteraux) || blackListProcs.test(sansLitteraux)) {
    return { ok: false, message: "Mots-clés SQL interdits dans la source" };
  }
  return { ok: true };
}
/** Exécute toutes les validations actives. Niveau B = bloquant. */
export async function executerValidations(
  meta: TSpMeta,
  ctx: TSpContexte,
  agent: { codProfile: string; id_Societe: string; Login?: string; Matricule?: string }
): Promise<{ erreurs: TSpErreur[]; avertissements: TSpErreur[] }> {
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
  const champParCode = (code: string | null) =>
    meta.champs.find((c) => c.Cod_Champ === code);

  for (const v of meta.validations.sort((a, b) => a.Rang - b.Rang)) {
    const p = paramsJson(v.Parametres);
    const codTable = v.Cod_Table ?? "ENT";
    const lignes = codTable === "ENT" ? [] : (ctx.details[codTable] ?? []);
    // Condition d'application de la règle
    const conditionOk = (ligne?: any): boolean => {
      if (!v.Condition_Regle) return true;
      try { return !!evaluer(JSON.parse(v.Condition_Regle), ctx, ligne); }
      catch { return true; }
    };
    const champ = champParCode(v.Cod_Champ);
    const valeurChamp = (ligne?: any) => {
      const nomCol = champ ? cleChamp(champ) : (v.Cod_Champ ?? "");
      return ligne ? ligne[nomCol] : ctx.entete[nomCol];
    };
    try {
      switch (v.Typ_Regle) {
        case "REQUIRED": {
          if (v.Portee === "LIGNE") {
            lignes.forEach((l, i) => {
              if (conditionOk(l)) {
                const val = valeurChamp(l);
                if (val === null || val === undefined || String(val).trim() === "") pousser(v, i);
              }
            });
          } else if (conditionOk()) {
            const val = valeurChamp();
            if (val === null || val === undefined || String(val).trim() === "") pousser(v, -1);
          }
          break;
        }
        case "IN": {
          const valeurs = p.valeurs ?? [];
          const tester = (val: any, i: number, l?: any) => {
            if (conditionOk(l) && val !== null && val !== undefined && String(val) !== "" && !valeurs.includes(val))
              pousser(v, i);
          };
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => tester(valeurChamp(l), i, l));
          else tester(valeurChamp(), -1);
          break;
        }
        case "MIN":
        case "MAX":
        case "BETWEEN": {
          const tester = (val: any, i: number, l?: any) => {
            if (!conditionOk(l) || val === null || val === undefined || String(val) === "") return;
            const n = num(val);
            const ko =
              (v.Typ_Regle === "MIN" && n < num(p.valeur)) ||
              (v.Typ_Regle === "MAX" && n > num(p.valeur)) ||
              (v.Typ_Regle === "BETWEEN" && (n < num(p.min) || n > num(p.max)));
            if (ko) pousser(v, i);
          };
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => tester(valeurChamp(l), i, l));
          else tester(valeurChamp(), -1);
          break;
        }
        case "MINLEN":
        case "MAXLEN": {
          const tester = (val: any, i: number, l?: any) => {
            if (!conditionOk(l) || val === null || val === undefined) return;
            const L = String(val).length;
            if ((v.Typ_Regle === "MINLEN" && L < num(p.valeur)) ||
                (v.Typ_Regle === "MAXLEN" && L > num(p.valeur))) pousser(v, i);
          };
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => tester(valeurChamp(l), i, l));
          else tester(valeurChamp(), -1);
          break;
        }
        case "REGEX": {
          let re: RegExp | null = null;
          try { re = new RegExp(String(p.pattern ?? "")); } catch { re = null; }
          if (!re) break;
          const tester = (val: any, i: number, l?: any) => {
            if (!conditionOk(l) || val === null || val === undefined || String(val) === "") return;
            if (!re!.test(String(val))) pousser(v, i);
          };
          if (v.Portee === "LIGNE") lignes.forEach((l, i) => tester(valeurChamp(l), i, l));
          else tester(valeurChamp(), -1);
          break;
        }
        case "COMPARE": {
          // { operateur: GT|GE|LT|LE|EQ|NE, autre: 'NomColonne' } ou { constante: x }
          const opMap: any = { GT: "GT", GE: "GE", LT: "LT", LE: "LE", EQ: "EQ", NE: "NE" };
          const op = opMap[String(p.operateur ?? "").toUpperCase()];
          if (!op) break;
          const autre = p.autre !== undefined ? { ref: p.autre } : { const: p.constante };
          const tester = (i: number, l?: any) => {
            if (!conditionOk(l)) return;
            const cond = { op, args: [{ ref: champ ? cleChamp(champ) : v.Cod_Champ }, autre] };
            if (!evaluer(cond, ctx, l)) pousser(v, i);
          };
          if (v.Portee === "LIGNE") lignes.forEach((_, i) => tester(i, lignes[i]));
          else tester(-1);
          break;
        }
        case "UNIQUE": {
          // Portée DETAIL : pas de doublon sur la combinaison de colonnes (en mémoire)
          const cols: string[] = p.colonnes ?? (v.Cod_Champ ? [champ ? cleChamp(champ) : v.Cod_Champ] : []);
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
          // Portée DETAIL : nombre de lignes min/max
          if (conditionOk()) {
            const nb = lignes.length;
            if ((p.min !== undefined && nb < num(p.min)) ||
                (p.max !== undefined && nb > num(p.max))) pousser(v, -1);
          }
          break;
        }
        case "EXPR": {
          // Expression booléenne déclarative (agrégats autorisés)
          if (!p.expr) break;
          if (v.Portee === "LIGNE") {
            lignes.forEach((l, i) => {
              if (conditionOk(l) && !evaluer(p.expr, ctx, l)) pousser(v, i);
            });
          } else if (conditionOk() && !evaluer(p.expr, ctx)) {
            pousser(v, -1);
          }
          break;
        }
        case "SOURCE": {
          // Contrôle par source métier autorisée. Résultat scalaire -> {"ref":"@result"}
          if (!conditionOk()) break;
          const mapping: { [k: string]: any } = {};
          for (const [nom, def] of Object.entries<any>(p.mapping ?? {})) {
            mapping[nom] = operande(def, ctx);
          }
          const r = await executerSource(String(p.source ?? ""), mapping, agent);
          if (!r.ok) { pousser(v, -1); break; }
          const ctx2: any = { ...ctx, __result: r.valeur };
          if (p.cond && !evaluer(p.cond, ctx2)) pousser(v, -1);
          break;
        }
        default:
          break;
      }
    } catch (e) {
      console.error(`[SP] Validation '${v.Cod_Validation}' en erreur:`, e);
      pousser(v, -1); // une règle en échec technique bloque par sécurité si niveau B
    }
  }
  return { erreurs, avertissements };
}

/* -------------------------------------------------------------------------- */
/* 9. Accès documentaire transactionnel                                       */
/* -------------------------------------------------------------------------- */
const COLS_TECHNIQUES_ENT = ["Num_Doc", "id_Societe", "Statut", "Dat_Crea", "Created_By", "Dat_Modif", "Modified_By"];
const COLS_TECHNIQUES_DET = ["RowId", "Num_Doc", "id_Societe", "Dat_Crea", "Created_By", "Dat_Modif", "Modified_By"];

export function colonnesMetier(meta: TSpMeta, codTable: string): TSpColonne[] {
  return meta.colonnes.filter(
    (c) => c.Cod_Table === codTable && c.Technique !== "true"
  );
}
function colonnesSelectEnt(meta: TSpMeta): string {
  const cols = colonnesMetier(meta, "ENT").map((c) => qn(c.Nom_Colonne));
  return [...COLS_TECHNIQUES_ENT.map(qn), ...cols, "convert(bigint, [RV]) as [RV]"].join(", ");
}
function colonnesSelectDet(meta: TSpMeta, codTable: string): string {
  const cols = colonnesMetier(meta, codTable).map((c) => qn(c.Nom_Colonne));
  return [...COLS_TECHNIQUES_DET.map(qn), ...cols].join(", ");
}
export function tableEnt(meta: TSpMeta): TSpTable {
  return meta.tables.find((t) => t.Role_Table === "ENT")!;
}
export function tablesDet(meta: TSpMeta): TSpTable[] {
  return meta.tables.filter((t) => t.Role_Table === "DET");
}
/** Génère le numéro de document : <CodDocument><idSoc>-<année><seq 6>. */
async function nouveauNumero(
  request: sql.Request, meta: TSpMeta, idSociete: number
): Promise<string> {
  const t = tableEnt(meta);
  const r = await request
    .input("p_idSoc", sql.Int, idSociete)
    .query(`select isnull(max(convert(int, right([Num_Doc], 6))), 0) + 1 as seq
            from ${qn(t.Nom_Physique)} with (updlock, holdlock)
            where [id_Societe] = @p_idSoc and year([Dat_Crea]) = year(getdate())`);
  const seq = r.recordset?.[0]?.seq ?? 1;
  return `${meta.page.Cod_Document}${idSociete}-${new Date().getFullYear()}${String(seq).padStart(6, "0")}`;
}
type TAgentCtx = { Login: string; Matricule: string; id_Societe: string; codProfile: string; TeamLeader?: string };

/** Chargement d'un document (entête + détails). */
export async function lireDocument(meta: TSpMeta, numDoc: string, agent: TAgentCtx) {
  const tEnt = tableEnt(meta);
  const idSoc = Number(agent.id_Societe);
  const rEnt = await lireSql(
    `select ${colonnesSelectEnt(meta)} from ${qn(tEnt.Nom_Physique)}
     where [Num_Doc]=@p_num and [id_Societe]=@p_idSoc`,
    [
      { param: "p_num", sqlType: sql.NVarChar, valeur: numDoc },
      { param: "p_idSoc", sqlType: sql.Int, valeur: idSoc },
    ]
  );
  if (!rEnt.result || rEnt.data.length === 0) {
    return { result: false, message: "Document introuvable" };
  }
  const details: { [codTable: string]: any[] } = {};
  for (const t of tablesDet(meta)) {
    if (t.Source_Metier) {
      // Détail virtuel : la grille est alimentée par la source métier
      // (mapping des paramètres sur l'entête lue), jamais par une table physique.
      try {
        const m = JSON.parse(t.Source_Mapping ?? "{}");
        const params: { [k: string]: any } = {};
        for (const [nomP, def] of Object.entries<any>(m)) {
          params[nomP] = def?.ref ? rEnt.data[0]?.[def.ref] : def?.const;
        }
        const rSrc = await executerSource(t.Source_Metier, params, agent);
        details[t.Cod_Table] = rSrc.ok
          ? (rSrc.data ?? []).map((l: any, i: number) => ({ ...l, RowId: i + 1 }))
          : [];
      } catch {
        details[t.Cod_Table] = [];
      }
      continue;
    }
    const tri = t.Tri_Defaut ? verifierTri(t.Tri_Defaut, meta, t.Cod_Table) : "[RowId] asc";
    const rDet = await lireSql(
      `select ${colonnesSelectDet(meta, t.Cod_Table)} from ${qn(t.Nom_Physique)}
       where [Num_Doc]=@p_num and [id_Societe]=@p_idSoc order by ${tri}`,
      [
        { param: "p_num", sqlType: sql.NVarChar, valeur: numDoc },
        { param: "p_idSoc", sqlType: sql.Int, valeur: idSoc },
      ]
    );
    details[t.Cod_Table] = rDet.data ?? [];
  }
  // Champs SOURCE d'entête NON persistés (aucune colonne physique, ex. Solde_Conge) :
  // résolus ici pour que le document arrive complet au client en un seul aller-retour
  // (sinon le champ reste vide le temps d'un second appel sp_exec_source — décalage
  // visible par rapport aux colonnes persistées). Miroir des détails virtuels ci-dessus.
  // En échec, le champ est laissé absent : le client le ré-exécutera si besoin.
  const champsSource = meta.champs.filter(
    (c) => c.Cod_Table === "ENT" && c.Typ_Controle === "SOURCE" && c.Formule && !c.Nom_Colonne
  );
  await Promise.all(champsSource.map(async (c) => {
    try {
      const f = JSON.parse(c.Formule!);
      const params: { [k: string]: any } = {};
      let incomplet = false;
      for (const [nomP, def] of Object.entries<any>(f?.mapping ?? {})) {
        const v = def?.ref ? rEnt.data[0]?.[def.ref] : def?.const;
        if (def?.ref && (v === null || v === undefined || v === "")) incomplet = true;
        params[nomP] = v;
      }
      if (incomplet || !f?.source) return;
      const rSrc = await executerSource(String(f.source), params, agent);
      if (rSrc.ok) rEnt.data[0][cleChamp(c)] = rSrc.valeur;
    } catch { /* source en échec : affichage repris côté client */ }
  }));
  return { result: true, entete: rEnt.data[0], details };
}
/** Sécurise une clause ORDER BY déclarée en métadonnées (noms de colonnes uniquement). */
function verifierTri(tri: string, meta: TSpMeta, codTable: string): string {
  const colonnesOk = new Set([
    ...COLS_TECHNIQUES_DET,
    ...colonnesMetier(meta, codTable).map((c) => c.Nom_Colonne),
  ]);
  const parts = String(tri).split(",").map((s) => s.trim()).filter(Boolean);
  const sur: string[] = [];
  for (const p of parts) {
    const m = /^([A-Za-z_][A-Za-z0-9_]*)(\s+(asc|desc))?$/i.exec(p);
    if (m && colonnesOk.has(m[1])) {
      sur.push(`${qn(m[1])} ${m[3]?.toLowerCase() === "desc" ? "desc" : "asc"}`);
    }
  }
  return sur.length > 0 ? sur.join(", ") : "[RowId] asc";
}

/** Enregistrement transactionnel entête + détails + soumission workflow. */
export async function enregistrerDocument(
  meta: TSpMeta,
  enteteIn: any,
  detailsIn: { [codTable: string]: any[] },
  statutDemande: string | null,
  agent: TAgentCtx
): Promise<{ result: boolean; message?: string; numDoc?: string; data?: any[]; avertissements?: TSpErreur[] }> {
  const idSoc = Number(agent.id_Societe);
  const tEnt = tableEnt(meta);
  const dets = tablesDet(meta);
  const colsEnt = colonnesMetier(meta, "ENT");
  // Détails virtuels : grilles alimentées par une source (aucune table physique)
  const detsPhysiques = dets.filter((t) => !t.Source_Metier);
  const detsVirtuels = dets.filter((t) => t.Source_Metier);
  // Statuts figeant le document (paramétrable par page ; défaut convention RHP)
  const statutFiges = String(meta.page.Figer_Statuts ?? "SG,RJ,SP,VA")
    .split(",").map((s) => s.trim()).filter(Boolean);

  // 1. Nettoyage des entrées : seules les colonnes déclarées en métadonnées
  const entete: { [k: string]: any } = {};
  for (const c of colsEnt) entete[c.Nom_Colonne] = enteteIn?.[c.Nom_Colonne];
  // 1.b Colonnes techniques exposées aux validations et aux calculs (jamais
  // persistées via colsEnt) : permettent notamment l'exclusion du document
  // courant dans une règle (chevauchement...) et les règles sur le statut.
  entete.Num_Doc = String(enteteIn?.Num_Doc ?? "");
  entete.Statut = String(enteteIn?.Statut ?? "");
  entete.Created_By = String(enteteIn?.Created_By ?? "");
  const details: { [k: string]: any[] } = {};
  for (const t of detsPhysiques) {
    const cols = colonnesMetier(meta, t.Cod_Table);
    details[t.Cod_Table] = (detailsIn?.[t.Cod_Table] ?? []).map((l: any) => {
      const propre: { [k: string]: any } = {};
      for (const c of cols) propre[c.Nom_Colonne] = l?.[c.Nom_Colonne];
      propre.RowId = Number(l?.RowId) > 0 ? Number(l.RowId) : 0;
      return propre;
    });
  }

  // 1.c Ré-exécution serveur des champs SOURCE persistés (Recalc_Save) : la
  // valeur calculée côté client n'est jamais crue ; la source fait foi.
  for (const c of meta.champs.filter(
    (x) => x.Cod_Table === "ENT" && x.Typ_Controle === "SOURCE" && x.Formule
        && x.Nom_Colonne && (x.Recalc_Save ?? "true") === "true"
  )) {
    try {
      const f = JSON.parse(c.Formule!);
      const params: { [k: string]: any } = {};
      for (const [nomP, def] of Object.entries<any>(f?.mapping ?? {})) {
        params[nomP] = def?.ref ? entete?.[def.ref] : def?.const;
      }
      const r = await executerSource(String(f.source ?? ""), params, agent);
      if (!r.ok) {
        return { result: false, message: `Source '${f.source}' en échec : ${r.message ?? "erreur"}` };
      }
      entete[cleChamp(c)] = r.valeur;
    } catch (e: any) {
      return { result: false, message: `Champ source '${c.Cod_Champ}' en échec : ${e?.message ?? e}` };
    }
  }

  // 2. Recalcul serveur des champs calculés (valeurs critiques)
  const ctx: TSpContexte = { entete, details };
  const rRecalc = recalculer(meta, ctx);
  if (rRecalc.cycle) {
    return { result: false, message: `Référence circulaire dans les calculs : ${rRecalc.cycle}` };
  }

  // 2.b Détails virtuels : ré-exécution serveur de la source (mapping sur
  // l'entête recalculée) - les lignes vues par les validations sont celles
  // de la source, jamais celles postées par le client.
  for (const t of detsVirtuels) {
    try {
      const m = JSON.parse(t.Source_Mapping ?? "{}");
      const params: { [k: string]: any } = {};
      for (const [nomP, def] of Object.entries<any>(m)) {
        params[nomP] = def?.ref ? entete?.[def.ref] : def?.const;
      }
      const r = await executerSource(String(t.Source_Metier), params, agent);
      if (!r.ok) {
        return { result: false, message: `Source '${t.Source_Metier}' en échec : ${r.message ?? "erreur"}` };
      }
      details[t.Cod_Table] = (r.data ?? []).map((l: any, i: number) => ({ ...l, RowId: i + 1 }));
      ctx.details = details;
    } catch (e: any) {
      return { result: false, message: `Détail virtuel '${t.Cod_Table}' en échec : ${e?.message ?? e}` };
    }
  }

  // 3. Validations serveur (toujours, quel que soit le moment déclaré)
  const v = await executerValidations(meta, ctx, agent);
  if (v.erreurs.length > 0) {
    return {
      result: false,
      message: v.erreurs.map((e) =>
        e.ligne >= 0 ? `Ligne ${e.ligne + 1} : ${e.message}` : e.message
      ).join("\n"),
      avertissements: v.avertissements,
    };
  }

  // 4. Écriture transactionnelle
  const pool = await getPool();
  const transaction = new sql.Transaction(pool);
  const estSoumission = statutDemande === "SS" && meta.page.Workflow_Actif === "true";
  try {
    await transaction.begin();
    const req = new sql.Request(transaction);

    // 4a. Numérotation + RV pour contrôle de concurrence
    let numDoc = String(enteteIn?.Num_Doc ?? "").trim();
    let rvAttendu: any = null;
    const estCreation = numDoc === "";
    if (estCreation) {
      numDoc = await nouveauNumero(req, meta, idSoc);
    } else {
      const rRv = await new sql.Request(transaction)
        .input("p_num", sql.NVarChar, numDoc)
        .input("p_idSoc", sql.Int, idSoc)
        .query(`select convert(bigint, [RV]) as RV, isnull([Statut],'') as Statut
                from ${qn(tEnt.Nom_Physique)} where [Num_Doc]=@p_num and [id_Societe]=@p_idSoc`);
      if (!rRv.recordset || rRv.recordset.length === 0) {
        await transaction.rollback();
        return { result: false, message: "Document introuvable" };
      }
      if (statutFiges.includes(String(rRv.recordset[0].Statut))) {
        await transaction.rollback();
        return { result: false, message: "Document déjà traité. Modification impossible." };
      }
      rvAttendu = rRv.recordset[0].RV;
      // Contrôle de concurrence optimiste : la version lue par le client
      // (entete.RV, convertie en bigint) doit égaler la version courante.
      const rvClient = enteteIn?.RV;
      if (rvClient !== undefined && rvClient !== null && String(rvClient) !== ""
          && String(rvClient) !== String(rvAttendu)) {
        await transaction.rollback();
        return { result: false, message: "Document modifié par un autre utilisateur. Rechargez la page." };
      }
    }
    const statut = statutDemande === "SS" ? "SS" : String(enteteIn?.Statut ?? "");

    // 4b. INSERT / UPDATE entête (paramétré, identifiants quotés)
    const colSet = colsEnt;
    const rUps = new sql.Request(transaction);
    rUps.input("p_num", sql.NVarChar, numDoc);
    rUps.input("p_idSoc", sql.Int, idSoc);
    rUps.input("p_login", sql.NVarChar, agent.Login ?? agent.Matricule);
    rUps.input("p_statut", sql.NVarChar, statut);
    colSet.forEach((c, i) => rUps.input(`p_c${i}`, sqlTypePour(c), valeurPour(c, entete[c.Nom_Colonne])));
    if (estCreation) {
      const colsSql = colSet.map((c, i) => `${qn(c.Nom_Colonne)}`).join(", ");
      const valsSql = colSet.map((_, i) => `@p_c${i}`).join(", ");
      await rUps.query(
        `insert into ${qn(tEnt.Nom_Physique)}
           ([Num_Doc], [id_Societe], [Statut], ${colsSql ? colsSql + ", " : ""}[Dat_Crea], [Created_By], [Dat_Modif], [Modified_By])
         values (@p_num, @p_idSoc, @p_statut, ${valsSql ? valsSql + ", " : ""}getdate(), @p_login, getdate(), @p_login)`
      );
    } else {
      const setSql = colSet.map((c, i) => `${qn(c.Nom_Colonne)} = @p_c${i}`).join(", ");
      rUps.input("p_rv", sql.BigInt, rvAttendu);
      const rUpd = await rUps.query(
        `update ${qn(tEnt.Nom_Physique)}
         set ${setSql ? setSql + ", " : ""}[Statut]=@p_statut, [Dat_Modif]=getdate(), [Modified_By]=@p_login
         where [Num_Doc]=@p_num and [id_Societe]=@p_idSoc and [RV]=convert(binary(8), @p_rv)`
      );
      if ((rUpd.rowsAffected?.[0] ?? 0) === 0) {
        await transaction.rollback();
        return { result: false, message: "Document modifié par un autre utilisateur. Rechargez la page." };
      }
    }

    // 4c. Détails : upsert par RowId puis purge des lignes absentes
    //     (uniquement les détails PHYSIQUES - les détails virtuels sont
    //     alimentés par leur source et ne sont jamais écrits)
    for (const t of detsPhysiques) {
      const cols = colonnesMetier(meta, t.Cod_Table);
      const idsConserves: number[] = [];
      for (const ligne of details[t.Cod_Table]) {
        const rDet = new sql.Request(transaction);
        rDet.input("p_num", sql.NVarChar, numDoc);
        rDet.input("p_idSoc", sql.Int, idSoc);
        rDet.input("p_login", sql.NVarChar, agent.Login ?? agent.Matricule);
        cols.forEach((c, i) => rDet.input(`p_c${i}`, sqlTypePour(c), valeurPour(c, ligne[c.Nom_Colonne])));
        if (ligne.RowId > 0) {
          rDet.input("p_rowid", sql.Int, ligne.RowId);
          const setSql = cols.map((c, i) => `${qn(c.Nom_Colonne)} = @p_c${i}`).join(", ");
          const rUpdDet = await rDet.query(
            `update ${qn(t.Nom_Physique)}
             set ${setSql ? setSql + ", " : ""}[Dat_Modif]=getdate(), [Modified_By]=@p_login
             where [RowId]=@p_rowid and [Num_Doc]=@p_num and [id_Societe]=@p_idSoc`
          );
          if ((rUpdDet.rowsAffected?.[0] ?? 0) === 0) {
            await transaction.rollback();
            return { result: false, message: `Ligne ${ligne.RowId} introuvable dans ${t.Libelle ?? t.Cod_Table}. Rechargez la page.` };
          }
          idsConserves.push(ligne.RowId);
        } else {
          const colsSql = cols.map((c) => qn(c.Nom_Colonne)).join(", ");
          const valsSql = cols.map((_, i) => `@p_c${i}`).join(", ");
          const rIns = await rDet.query(
            `insert into ${qn(t.Nom_Physique)}
               ([Num_Doc], [id_Societe], ${colsSql ? colsSql + ", " : ""}[Dat_Crea], [Created_By], [Dat_Modif], [Modified_By])
             output inserted.[RowId]
             values (@p_num, @p_idSoc, ${valsSql ? valsSql + ", " : ""}getdate(), @p_login, getdate(), @p_login)`
          );
          idsConserves.push(rIns.recordset?.[0]?.RowId ?? 0);
        }
      }
      // Purge des lignes supprimées côté client
      const rPurge = new sql.Request(transaction);
      rPurge.input("p_num", sql.NVarChar, numDoc);
      rPurge.input("p_idSoc", sql.Int, idSoc);
      const inSql = idsConserves.length > 0
        ? idsConserves.map((_, i) => {
            rPurge.input(`p_k${i}`, sql.Int, idsConserves[i]);
            return `@p_k${i}`;
          }).join(", ")
        : "-1";
      await rPurge.query(
        `delete from ${qn(t.Nom_Physique)}
         where [Num_Doc]=@p_num and [id_Societe]=@p_idSoc and [RowId] not in (${inSql})`
      );
    }

    // 4d. Soumission au circuit de signature (même transaction)
    if (estSoumission) {
      const rWf = new sql.Request(transaction);
      await rWf
        .input("typ_document", sql.NVarChar, meta.page.Typ_Document)
        .input("id_societe", sql.Int, idSoc)
        .input("valeur_index", sql.NVarChar, numDoc)
        .input("matricule", sql.NVarChar, agent.Matricule)
        .query(`exec Sys_Workflow_Signature @typ_document, @id_societe, @valeur_index, @matricule`);
    }

    await transaction.commit();
    return {
      result: true,
      numDoc,
      data: [{ Num_Doc: numDoc }],
      avertissements: v.avertissements,
    };
  } catch (e: any) {
    try { await transaction.rollback(); } catch { /* déjà annulée */ }
    console.error("[SP] enregistrerDocument:", e);
    return { result: false, message: `Erreur d'enregistrement : ${e?.message ?? e}` };
  }
}

/** Suppression transactionnelle d'un document et de ses lignes. */
export async function supprimerDocument(
  meta: TSpMeta, numDoc: string, agent: TAgentCtx
): Promise<{ result: boolean; message?: string }> {
  const idSoc = Number(agent.id_Societe);
  const pool = await getPool();
  const transaction = new sql.Transaction(pool);
  const statutFiges = String(meta.page.Figer_Statuts ?? "SG,RJ,SP,VA")
    .split(",").map((s) => s.trim()).filter(Boolean);
  try {
    await transaction.begin();
    const rChk = new sql.Request(transaction);
    const chk = await rChk
      .input("p_num", sql.NVarChar, numDoc)
      .input("p_idSoc", sql.Int, idSoc)
      .query(`select isnull([Statut],'') as Statut from ${qn(tableEnt(meta).Nom_Physique)}
              where [Num_Doc]=@p_num and [id_Societe]=@p_idSoc`);
    if (!chk.recordset || chk.recordset.length === 0) {
      await transaction.rollback();
      return { result: false, message: "Document introuvable" };
    }
    if (statutFiges.includes(String(chk.recordset[0].Statut))) {
      await transaction.rollback();
      return { result: false, message: "Document traité. Suppression impossible." };
    }
    for (const t of tablesDet(meta).filter((x) => !x.Source_Metier)) {
      if (t.Regle_Suppression === "RESTRICT") {
        const rNb = new sql.Request(transaction);
        const nb = await rNb
          .input("p_num", sql.NVarChar, numDoc)
          .input("p_idSoc", sql.Int, idSoc)
          .query(`select count(*) as nb from ${qn(t.Nom_Physique)} where [Num_Doc]=@p_num and [id_Societe]=@p_idSoc`);
        if ((nb.recordset?.[0]?.nb ?? 0) > 0) {
          await transaction.rollback();
          return { result: false, message: `Des lignes existent dans '${t.Libelle ?? t.Cod_Table}'. Suppression interdite.` };
        }
      } else {
        const rDel = new sql.Request(transaction);
        await rDel
          .input("p_num", sql.NVarChar, numDoc)
          .input("p_idSoc", sql.Int, idSoc)
          .query(`delete from ${qn(t.Nom_Physique)} where [Num_Doc]=@p_num and [id_Societe]=@p_idSoc`);
      }
    }
    const rEnt = new sql.Request(transaction);
    await rEnt
      .input("p_num", sql.NVarChar, numDoc)
      .input("p_idSoc", sql.Int, idSoc)
      .query(`delete from ${qn(tableEnt(meta).Nom_Physique)} where [Num_Doc]=@p_num and [id_Societe]=@p_idSoc`);
    await transaction.commit();
    return { result: true };
  } catch (e: any) {
    try { await transaction.rollback(); } catch { /* déjà annulée */ }
    console.error("[SP] supprimerDocument:", e);
    return { result: false, message: `Erreur de suppression : ${e?.message ?? e}` };
  }
}
