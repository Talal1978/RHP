#!/usr/bin/env python3
"""
validate_input.py - RHP Portal Page Deployer (JSON import) input validator
(stdlib only).

Validates a CANONICAL JSON input (converted from the YAML contract) against
the blocking rules of the skill, mirroring the verified RHP constraints:
  - the product JSON importer itself (Module_SP_Page_Json.vb : Analyser /
    Valider / VerifierSourceVirtuelle - format RHP_PAGE_DESIGNER 1.0)
  - CK_SP_Page_Ident, UQ_SP_Page_Document, CK_SPChamp_Typ, CK_SPChamp_Etat,
    CK_SPValid_* , CK_SPSource_*  (001_SP_Designer_Metadata.sql)
  - identifier rules + reserved words (Module_SP_DDL.vb / module_sp_engine.ts)
  - read-only source guard, EXACT mirror (literals neutralized before the
    multi-statement check; sp_* blacklist case-sensitive)
    (module_sp_engine.ts:760-787)
  - full formula AST whitelist (43 ops), GV_* variables, DATEDIFF/DATEADD
    units, DATEPART parts, cycle detection (@result / GV_* excluded)
    (module_sp_engine.ts:307-312, 316-328, 581-677)
  - per-type validation Parametres shapes (Zoom_SP_Assistant_Validation.vb)
  - SP4 virtual detail grids (VerifierTableVirtuelle mirror)
  - NO-JSON-TARGET keys (freeze_statuses, zoom_condition, zoom_return,
    visibility/activation rules, grid_total, recalc_save:false,
    attachments.categories, operation:disable) => blocking, never silently
    dropped (references/json-import-format.md section 8)
  - publication preconditions (SP_Page_Designer.vb : Publier)

Usage:
    python validate_input.py input.json
Exit code 0 = OK (warnings allowed) ; 1 = blocking errors.
Output: JSON report on stdout {"status", "errors", "warnings", "summary"}.
"""
import json
import re
import sys

# ---------------------------------------------------------------- constants
IDENT_RE = re.compile(r"^[A-Za-z_][A-Za-z0-9_]{0,59}$")
RESERVED = {
    "select", "insert", "update", "delete", "drop", "alter", "create", "exec",
    "execute", "union", "grant", "revoke", "truncate", "merge", "into", "from",
    "where", "table", "backup", "restore", "shutdown", "sysobjects", "xp_cmdshell",
}

COMPONENT_TYPES = {  # input type -> RHP Typ_Controle (verified CK_SPChamp_Typ)
    "text": "TEXT", "memo": "MEMO", "integer": "INT", "decimal": "DEC",
    "money": "MNT", "date": "DATE", "datetime": "DATETIME", "checkbox": "CHECK",
    "radio": "RADIO", "combo": "COMBO", "reference_list": "RUBRIQUE",
    "zoom": "ZOOM", "calculated": "CALCULE", "source": "SOURCE",
    "attachments": "GED", "detail_grid": None,  # structural block
}
SQL_TYPES = {"nvarchar", "int", "bigint", "float", "decimal", "bit",
             "date", "datetime", "smalldatetime"}
# Physical column types must come from SQL_TYPES; source PARAMETER types use
# the engine's narrower list (input-template: nvarchar|int|decimal|date|datetime|bit)
PARAM_TYPES = {"nvarchar", "int", "decimal", "date", "datetime", "bit"}
VALID_TYPES = {"REQUIRED", "IN", "BETWEEN", "MIN", "MAX", "MINLEN", "MAXLEN",
               "REGEX", "COMPARE", "UNIQUE", "SOURCE", "EXPR", "NB_LIGNES"}
VALID_SCOPES = {"CHAMP", "ENTETE", "LIGNE", "DETAIL", "DOCUMENT"}
VALID_LEVELS = {"I", "W", "B"}
VALID_MOMENTS = {"SAISIE", "CHANGE", "AJOUT_LIGNE", "SAVE"}
# Full operator whitelists, mirror of OPS_LOGIQUES / OPS_CALCUL
# (module_sp_engine.ts:307-312 and dynamicEngine.ts:12-17)
LOGIC_OPS = {"AND", "OR", "NOT", "EQ", "NE", "GT", "GE", "LT", "LE",
             "IN", "EMPTY", "NOTEMPTY", "CONTIENT"}
CALC_OPS = {"ADD", "SUB", "MUL", "DIVSAFE", "COND", "SUM", "AVG", "MIN",
            "MAX", "COUNT", "ROUND", "ABS", "REF", "CONST", "DATEDIFF",
            "LEFT", "RIGHT", "SUBSTRING", "INDEXOF", "LEN", "UPPER", "LOWER",
            "TRIM", "REPLACE", "CONCAT", "INT", "CEIL", "FLOOR", "DATEADD",
            "DATEPART", "DAYOFWEEK"}
AGG_OPS = {"SUM", "AVG", "MIN", "MAX", "COUNT"}
# GV_* resolved by variableGlobale() (module_sp_engine.ts:316-328) - usable in
# formulas; never a recalculation dependency
GV_VARS = {"GV_NOW", "GV_YEAR", "GV_MONTH", "GV_DAY",
           "GV_DEBMOIS", "GV_FINMOIS", "GV_DEBYEAR"}
DATE_UNITS = {"S", "MI", "H", "J"}            # DATEDIFF (+DATEADD below)
DATEADD_UNITS = DATE_UNITS | {"MO", "A"}
DATE_PARTS = {"A", "M", "J", "H", "MI", "S"}  # DATEPART
# Technical ENT columns exposed to contexts (module_sp_engine.ts:1091-1093)
TECH_ENT_COLS = {"Num_Doc", "id_Societe", "Statut", "Dat_Crea", "Created_By",
                  "Dat_Modif", "Modified_By"}
# Technical columns NEVER declared in an import file - auto-added by the DDL
# (mirror of Module_SP_Page_Json.Valider : blocking if present in the file)
TECH_COLS_ALL = TECH_ENT_COLS | {"RowId", "RV"}
NO_CRITERIA_TYPES = {"calculated", "source", "attachments", "checkbox", "radio"}
# Types allowed to have NO physical column (explicitly empty column_name):
# unstored calculated/source fields (e.g. grid footers) and GED attachments
NO_COLUMN_TYPES = {"calculated", "source", "attachments"}
# Keys with no target in the JSON import format (json-import-format.md §8) -
# any non-neutral value is blocking, never silently dropped
NO_JSON_TARGET = {
    "zoom_return": "Zoom_Retour absent du format d'import",
    "zoom_condition": "Zoom_Condition absent du format d'import",
    "visibility_rule": "Regle_Visibilite absente du format d'import",
    "activation_rule": "Regle_Activation absente du format d'import",
}

errors, warnings = [], []


def err(path, msg):
    errors.append({"path": path, "message": msg})


def warn(path, msg):
    warnings.append({"path": path, "message": msg})


def is_ident(name):
    return bool(name) and bool(IDENT_RE.match(name)) and name.lower() not in RESERVED


def req_str(obj, key, path, maxlen=None):
    v = obj.get(key)
    if not isinstance(v, str) or not v.strip():
        err(f"{path}.{key}", "valeur requise (chaine non vide)")
        return ""
    if maxlen and len(v) > maxlen:
        err(f"{path}.{key}", f"longueur {len(v)} > {maxlen}")
    return v.strip()


# ---------------------------------------------------------------- formulas
def check_formula(node, path, block_cols, det_blocks, det_cols, depth=0,
                  allow_result=False):
    """Declarative AST only; whitelisted ops; refs/aggregates must resolve.

    block_cols: columns of the field's own block UNION header columns (engine
    resolution: current row first, then header). det_cols: block -> columns.
    allow_result: accept {"ref":"@result"} (SOURCE validation cond only).
    """
    if depth > 20:
        err(path, "formule trop profonde (> 20)")
        return
    if isinstance(node, list):  # literal array (e.g. IN second argument)
        for i, a in enumerate(node):
            if isinstance(a, (dict, list)):
                err(f"{path}[{i}]", "tableau litteral : constantes uniquement")
            elif not isinstance(a, (int, float, str, bool)):
                err(f"{path}[{i}]", "constante invalide dans le tableau")
        return
    if not isinstance(node, dict):
        if not isinstance(node, (int, float, str, bool)):
            err(path, "noeud de formule invalide (objet, tableau ou constante attendu)")
        return
    if "ref" in node:
        ref = node["ref"]
        if not isinstance(ref, str):
            err(f"{path}.ref", "ref invalide (chaine attendue)")
        elif ref == "@result":
            if not allow_result:
                err(f"{path}.ref", "@result reserve a la condition d'une validation SOURCE")
        elif ref.upper().startswith("GV_"):
            if ref.upper() not in GV_VARS:
                err(f"{path}.ref", f"variable globale inconnue : {ref!r} "
                                   f"(disponibles : {', '.join(sorted(GV_VARS))})")
        elif ref not in block_cols:
            err(f"{path}.ref", f"colonne inconnue dans ce bloc ou l'entete : {ref!r}")
        return
    if "const" in node:
        if not isinstance(node["const"], (int, float, str, bool)):
            err(f"{path}.const", "constante invalide")
        return
    op = node.get("op")
    if not isinstance(op, str) or op.upper() not in LOGIC_OPS | CALC_OPS:
        err(f"{path}.op", f"operateur non autorise : {op!r}")
        return
    op = op.upper()
    if op == "REF":  # alternate form {"op":"REF","colonne":"X"}
        col = node.get("colonne")
        if not isinstance(col, str) or col not in block_cols:
            err(f"{path}.colonne", f"REF : colonne inconnue : {col!r}")
        return
    if op == "CONST":  # alternate form {"op":"CONST","valeur":x}
        if "valeur" not in node:
            err(f"{path}.valeur", "CONST : cle 'valeur' requise")
        return
    if op in AGG_OPS and "table" in node:  # aggregate over a detail block
        tbl = node.get("table")
        if tbl not in det_blocks:
            err(f"{path}.table", f"bloc detail inconnu : {tbl!r}")
        elif node.get("colonne") and node["colonne"] not in det_cols.get(tbl, set()):
            err(f"{path}.colonne", f"colonne inconnue du bloc {tbl}: {node.get('colonne')!r}")
        return
    if op in ("DATEDIFF", "DATEADD"):
        unite = str(node.get("unite", "J")).upper()
        allowed = DATEADD_UNITS if op == "DATEADD" else DATE_UNITS
        if unite not in allowed:
            err(f"{path}.unite", f"{op} : unite {unite!r} hors de {sorted(allowed)}")
    if op == "DATEPART":
        partie = str(node.get("partie", "J")).upper()
        if partie not in DATE_PARTS:
            err(f"{path}.partie", f"DATEPART : partie {partie!r} hors de {sorted(DATE_PARTS)}")
    args = node.get("args")
    if not isinstance(args, list) or not args:
        err(f"{path}.args", f"operateur {op} : liste args requise")
        return
    for i, a in enumerate(args):
        check_formula(a, f"{path}.args[{i}]", block_cols, det_blocks, det_cols,
                      depth + 1, allow_result)


def formula_refs(node, acc):
    """Collect field refs (mirror of extraireDependances: @result and GV_*
    excluded - never recalculation dependencies)."""
    if isinstance(node, dict):
        if "ref" in node and isinstance(node["ref"], str):
            r = node["ref"]
            if r != "@result" and not r.upper().startswith("GV_"):
                acc.append(r)
        for v in node.values():
            formula_refs(v, acc)
    elif isinstance(node, list):
        for v in node:
            formula_refs(v, acc)


# ---------------------------------------------------------------- sources
def check_source_sql(code, path):
    """Exact mirror of estRequeteLectureSeule (module_sp_engine.ts:760-787):
    comments removed, string literals neutralized BEFORE the multi-statement
    check, start gate select|with|exec dbo.Sys_*, case-insensitive keyword
    blacklist, and sp_* blacklist tested CASE-SENSITIVELY (uppercase SP_
    business tables stay readable)."""
    cleaned = re.sub(r"/\*.*?\*/", "", code, flags=re.S)
    cleaned = re.sub(r"--.*?(\n|$)", " ", cleaned)
    cleaned = re.sub(r"\s+", " ", cleaned).strip()
    # string literals neutralized: a ';' inside a literal is not a separator
    sans_lit = re.sub(r"'(?:[^']|'')*'", "''", cleaned)
    if re.search(r";.*\S", re.sub(r";\s*$", "", sans_lit)):
        err(path, "instruction multiple interdite dans la source")
        return
    low = sans_lit.lower()
    if not re.match(r"^(select|with)\b", low) and not re.match(r"^exec(ute)?\s+dbo\.sys_\w+", low):
        err(path, "seuls SELECT / WITH / EXEC dbo.Sys_* sont autorises")
        return
    if re.search(r"\b(insert|update|delete|merge|drop|alter|create|truncate|grant|revoke|"
                 r"backup|restore|shutdown|kill|waitfor|openrowset|opendatasource|"
                 r"xp_\w+)\b", sans_lit, flags=re.I):
        err(path, "mots-cles SQL interdits dans la source")
        return
    if re.search(r"\bsp_\w+\b", sans_lit):  # case-sensitive on purpose (mirror)
        err(path, "procedures systeme sp_* interdites dans la source "
                  "(sensible a la casse : les tables SP_ majuscules restent lisibles)")


def check_source_mapping(mapping, path, header_cols, declared_params=None):
    """Mapping json of a SOURCE field / virtual detail / SOURCE validation:
    {"Param": {"ref":"HeaderCol"} | {"const":"…"}}. header_cols = header
    business columns + technical ENT columns (engine allows both).
    declared_params: optional list of the source's declared parameters (from
    the input catalog) to verify mandatory feeding."""
    if not isinstance(mapping, dict):
        err(path, "mapping attendu : objet {\"Param\":{\"ref\"|\"const\":…}}")
        return
    fed = set()
    for nom, defin in mapping.items():
        p = f"{path}.{nom}"
        if not is_ident(str(nom)):
            err(p, "nom de parametre invalide")
        if declared_params is not None and nom not in {d.get("name") for d in declared_params}:
            err(p, f"parametre {nom!r} non declare dans la source")
        if not isinstance(defin, dict) or ("ref" not in defin and "const" not in defin):
            err(p, 'alimentation attendue : {"ref":"ColonneEntete"} ou {"const":"…"}')
            continue
        if "ref" in defin:
            if defin["ref"] not in header_cols:
                err(f"{p}.ref", f"colonne d'entete inconnue : {defin['ref']!r}")
        fed.add(nom)
    if declared_params is not None:
        for d in declared_params:
            if d.get("required") and d["name"] not in fed:
                err(path, f"parametre obligatoire {d['name']!r} non alimente par le mapping")


# ---------------------------------------------------------------- validations
def check_validation(v, path, blocks, fields_by_block, block_cols, grids,
                     src_index, header_cols):
    """Mirror of the engine rules (module_sp_engine.ts:823-952) and of the
    desktop assistant shapes (Zoom_SP_Assistant_Validation.vb:409-489)."""
    code = req_str(v, "code", path, 50)
    scope = v.get("scope")
    if scope not in VALID_SCOPES:
        err(f"{path}.scope", f"Portee invalide : {scope!r} (CK_SPValid_Portee)")
    vtype = v.get("type")
    if vtype not in VALID_TYPES:
        err(f"{path}.type", f"Typ_Regle invalide : {vtype!r} (CK_SPValid_Typ)")
    if not isinstance(v.get("message"), str) or not v.get("message", "").strip():
        err(f"{path}.message", "message requis")
    elif len(v["message"]) > 300:
        err(f"{path}.message", "longueur > 300")
    if v.get("level", "B") not in VALID_LEVELS:
        err(f"{path}.level", "Niveau invalide (I/W/B)")
    if v.get("moment", "SAVE") not in VALID_MOMENTS:
        err(f"{path}.moment", "Moment invalide (SAISIE/CHANGE/AJOUT_LIGNE/SAVE)")
    tb = v.get("target_block", "ENT")
    if tb not in blocks:
        err(f"{path}.target_block", f"bloc inconnu : {tb!r}")
    tf = v.get("target_field")
    if scope in ("CHAMP", "LIGNE"):
        if not tf:
            err(f"{path}.target_field", f"requis pour la portee {scope}")
        elif tf not in fields_by_block.get(tb, set()):
            err(f"{path}.target_field", f"champ {tf!r} absent du bloc {tb!r}")
    # refs resolvable from the rule context: its block + header
    ctx_cols = block_cols.get(tb, set()) | block_cols.get("ENT", set())

    p = v.get("parameters") or {}
    if not isinstance(p, dict):
        err(f"{path}.parameters", "objet json attendu")
        p = {}
    pp = f"{path}.parameters"
    if vtype == "IN":
        if not isinstance(p.get("valeurs"), list) or not p["valeurs"]:
            err(f"{pp}.valeurs", "IN attend {\"valeurs\":[…]} non vide "
                                "(doubler les nombres en nombre ET texte : comparaison stricte)")
    elif vtype in ("MIN", "MAX", "MINLEN", "MAXLEN"):
        if not isinstance(p.get("valeur"), (int, float)):
            err(f"{pp}.valeur", f"{vtype} attend {{\"valeur\":N}}")
    elif vtype == "BETWEEN":
        if not isinstance(p.get("min"), (int, float)) or not isinstance(p.get("max"), (int, float)):
            err(pp, 'BETWEEN attend {"min":A,"max":B}')
        elif p["min"] > p["max"]:
            err(pp, "BETWEEN : min > max")
    elif vtype == "REGEX":
        pat = p.get("pattern")
        if not isinstance(pat, str) or not pat:
            err(f"{pp}.pattern", 'REGEX attend {"pattern":"^…$"}')
        else:
            try:
                re.compile(pat)
            except re.error as ex:
                err(f"{pp}.pattern", f"regex non compilable : {ex}")
    elif vtype == "COMPARE":
        if str(p.get("operateur", "")).upper() not in ("GT", "GE", "LT", "LE", "EQ", "NE"):
            err(f"{pp}.operateur", "COMPARE : operateur GT|GE|LT|LE|EQ|NE requis")
        has_autre = "autre" in p
        has_const = "constante" in p
        if has_autre == has_const:
            err(pp, 'COMPARE : exactement une des cles "autre" (Nom_Colonne) ou "constante"')
        elif has_autre and p["autre"] not in ctx_cols:
            err(f"{pp}.autre", f"colonne inconnue : {p['autre']!r}")
    elif vtype == "UNIQUE":
        if not isinstance(p.get("colonnes"), list) or not p["colonnes"]:
            err(f"{pp}.colonnes", 'UNIQUE attend {"colonnes":["C1",…]}')
        if scope != "DETAIL":
            warn(f"{path}.scope", "UNIQUE s'applique normalement a la portee DETAIL")
    elif vtype == "NB_LIGNES":
        if "min" not in p and "max" not in p:
            err(pp, 'NB_LIGNES attend au moins une borne {"min":n} / {"max":n}')
        if scope != "DETAIL":
            warn(f"{path}.scope", "NB_LIGNES s'applique normalement a la portee DETAIL")
    elif vtype == "EXPR":
        if "expr" not in p:
            err(pp, 'EXPR attend {"expr": {...AST...}}')
        else:
            check_formula(p["expr"], f"{pp}.expr", ctx_cols, grids, block_cols)
    elif vtype == "SOURCE":
        if not isinstance(p.get("source"), str) or not p["source"].strip():
            err(f"{pp}.source", 'SOURCE attend {"source":"CodSource",…}')
        elif p["source"] not in src_index:
            warn(f"{pp}.source",
                 f"'{p['source']}' absent du input : doit exister dans Controle_Designer_Source "
                 f"(verifie par le preflight)")
        if "mapping" in p:
            check_source_mapping(p["mapping"], f"{pp}.mapping", header_cols,
                                 src_index.get(p.get("source")))
        if "cond" in p:
            check_formula(p["cond"], f"{pp}.cond", ctx_cols, grids, block_cols,
                          allow_result=True)
    # Condition_Regle : declarative condition AST (engine evaluates it first)
    cond = v.get("condition")
    if cond is not None:
        check_formula(cond, f"{path}.condition", ctx_cols, grids, block_cols)
    return code


# ---------------------------------------------------------------- main
def validate(spec):
    # ----- request
    rq = spec.get("request") or {}
    op = rq.get("operation")
    if op == "disable":
        err("request.operation",
            "disable n'est pas exprimable via l'import JSON : utiliser le bouton "
            "'Desactiver' du Designer (Statut_Page n'est jamais reimporte)")
    elif op not in ("create", "update"):
        err("request.operation", "create | update attendu")
    if rq.get("environment") not in ("development", "test", "production"):
        err("request.environment", "development | test | production attendu")
    if rq.get("dry_run") is not None and not isinstance(rq.get("dry_run"), bool):
        err("request.dry_run", "booleen attendu (accepte mais ignore : un import "
                               "n'ecrit jamais avant 'Enregistrer')")
    req_str(rq, "requested_by", "request", 50)
    req_str(rq, "change_reference", "request", 50)

    # ----- deployment
    dp = spec.get("deployment") or {}
    if not isinstance(dp.get("update_if_exists"), bool):
        err("deployment.update_if_exists", "booleen requis (autorisation explicite)")
    if dp.get("expected_schema_version") not in ("SP1", "SP2", "SP3", "SP4"):
        err("deployment.expected_schema_version", "SP1 | SP2 | SP3 | SP4 attendu "
            "(SP4 = etat actuel du depot, exige pour les details virtuels : "
            "Controle_Designer_Table.Source_Metier/_Mapping - migration 006)")
    if dp.get("use_feature_flag") not in (False, None):
        err("deployment.use_feature_flag",
            "mecanisme de feature flag INEXISTANT dans RHP (verifie) : utiliser page.enabled")
    if dp.get("feature_flag_code"):
        err("deployment.feature_flag_code", "doit rester vide (pas de feature flag RHP)")
    if op == "update" and dp.get("update_if_exists") is not True:
        err("deployment.update_if_exists",
            "operation=update exige update_if_exists: true (double confirmation)")

    # ----- page
    pg = spec.get("page") or {}
    code = req_str(pg, "page_code", "page", 30)
    if code:
        if not re.match(r"^[A-Za-z_][A-Za-z0-9_]{2,29}$", code):
            err("page.page_code", "regex import : ^[A-Za-z_][A-Za-z0-9_]{2,29}$ "
                                  "(3 a 30 caracteres)")
        if code.lower().startswith("page"):
            err("page.page_code", "ne doit pas commencer par 'Page' (CK_SP_Page_Ident)")
        if code.lower() in RESERVED:
            err("page.page_code", "identifiant reserve")
    dcode = req_str(pg, "document_code", "page", 10)
    if dcode and not re.match(r"^[A-Za-z][A-Za-z0-9]{1,9}$", dcode):
        err("page.document_code", "regex import : ^[A-Za-z][A-Za-z0-9]{1,9}$ "
                                  "(lettre puis alphanumerique, PAS de underscore)")
    if dcode and code and dcode.lower().startswith("page"):
        err("page.document_code", "ne doit pas commencer par 'Page' (noms physiques SP_<doc>_...)")
    req_str(pg, "page_name", "page", 150)
    req_str(pg, "title", "page", 60)
    if pg.get("short_title"):
        if len(pg["short_title"]) > 50:
            err("page.short_title", "longueur > 50")
        warn("page.short_title", "non persiste en mode JSON (pas de Libelle_Court "
                                 "dans le format ; Libelle = Nom_Page au Saving) - manifest seulement")
    if pg.get("target_section_id") is not None:
        err("page.target_section_id", "[UNSUPPORTED] les sections n'ont pas d'id : target_section_code")
    section = req_str(pg, "target_section_code", "page", 60)
    if section and not re.match(r"^[A-Za-z0-9_]+$", section):
        err("page.target_section_code", "caracteres alphanumeriques/underscore uniquement")
    if pg.get("create_section_if_missing"):
        if not pg.get("new_section_label"):
            err("page.new_section_label", "requis quand create_section_if_missing=true")
        warn("page.create_section_if_missing",
             "jamais automatise (l'import ne cree pas de rubrique) : creer la section "
             "via Zoom_SP_Nouvelle_Section AVANT l'enregistrement - etape du manifest")
    route = pg.get("route") or ""
    if route:
        ok = route.startswith(f"/myspace/SPPL_{code}") or route.startswith(f"/myspace/SPP_{code}")
        if not ok:
            err("page.route", f"les routes RHP sont conventionnelles : /myspace/SPPL_{code}/... "
                              f"ou /myspace/SPP_{code}/...")
    if pg.get("layout_type", "standard") not in ("standard", "wide", "compact"):
        err("page.layout_type", "standard | wide | compact")
    if pg.get("display_order") is not None and not isinstance(pg["display_order"], int):
        err("page.display_order", "entier attendu")
    if not isinstance(pg.get("enabled", True), bool):
        err("page.enabled", "booleen attendu")
    fs = pg.get("freeze_statuses")
    if fs is not None and str(fs).strip():
        err("page.freeze_statuses",
            "[NO-JSON-TARGET] Figer_Statuts ne figure pas dans le format d'import "
            "(json-import-format.md section 8) : laisser vide")

    act = pg.get("actions") or {}
    wf = pg.get("workflow") or {}
    att = pg.get("attachments") or {}
    if act.get("submit") and not wf.get("enabled"):
        err("page.actions.submit", "exige workflow.enabled=true (bouton Soumettre lie au workflow)")
    if act.get("print") and not pg.get("print_model"):
        err("page.actions.print", "exige page.print_model (Param_Mod_Edition.Cod_Report)")
    if att.get("categories"):
        err("page.attachments.categories",
            "[NO-JSON-TARGET] GED_Categories ne figure pas dans le format d'import "
            ": laisser [] (categories a poser par UPDATE SQL cible si indispensables)")

    # ----- data sources pre-scan (full checks further below): index for
    # mapping / return-type cross-checks in components and validations
    src_index = {}   # data_source_code -> declared parameters (list)
    src_return = {}  # data_source_code -> return_type
    for s in spec.get("data_sources") or []:
        if isinstance(s, dict) and s.get("data_source_code"):
            src_index[s["data_source_code"]] = s.get("parameters") or []
            src_return[s["data_source_code"]] = s.get("return_type", "scalar")

    # ----- components
    def phys_col(c):
        """Colonne physique du composant ('' = non stocke).
        calculated/source : stocke ssi persist=true (pattern officiel Pied_Mnt :
        non persiste => Nom_Colonne=''). attachments (GED) : jamais stocke.
        Autres types : column_name explicitement '' => non stocke (interdit,
        signale plus loin) ; absent => defaut component_code."""
        ct = c.get("component_type")
        props = c.get("properties") or {}
        if ct in ("calculated", "source", "attachments"):
            if ct == "attachments" or not props.get("persist"):
                return ""
        raw = c.get("column_name")
        if raw is not None and str(raw).strip() == "":
            return ""
        return str(raw).strip() if raw is not None else c.get("component_code", "")

    comps = spec.get("components") or []
    if op in ("create", "update") and not comps:
        err("components", "au moins un composant requis")
    codes, grids, block_fields, block_cols = [], {}, {}, {}
    for i, c in enumerate(comps):
        p = f"components[{i}]"
        cc = req_str(c, "component_code", p, 50)
        if cc and not is_ident(cc):
            err(f"{p}.component_code", "identifiant SQL invalide ou reserve")
        codes.append(cc)
        ct = c.get("component_type")
        if ct not in COMPONENT_TYPES:
            err(f"{p}.component_type", f"type inconnu : {ct!r} (whitelist du contrat)")
        req_str(c, "label", p, 150)
        tb = c.get("target_block", "ENT")
        if ct == "detail_grid":
            grids[cc] = c
        else:
            block_fields.setdefault(tb, set()).add(cc)
            col0 = phys_col(c)
            if col0:  # champs non stockes : aucune colonne physique
                block_cols.setdefault(tb, set()).add(col0)

    if len(set(codes)) != len(codes):
        err("components", "component_code duplique")
    if len(grids) > 0 and not any(
            (c.get("target_block", "ENT") == "ENT") and c.get("component_type") != "detail_grid"
            for c in comps):
        warn("components", "aucun champ d'entete : page liste sans entete exploitable")

    col_pairs = set()
    header_cols = block_cols.get("ENT", set()) | TECH_ENT_COLS
    for i, c in enumerate(comps):
        p = f"components[{i}]"
        ct = c.get("component_type")
        cc = c.get("component_code", "")
        props = c.get("properties") or {}
        tb = c.get("target_block", "ENT")

        if ct == "detail_grid":
            if props.get("delete_rule", "CASCADE") not in ("CASCADE", "RESTRICT"):
                err(f"{p}.properties.delete_rule", "CASCADE | RESTRICT attendu")
            vsrc = props.get("data_source_code")
            if vsrc:  # virtual detail grid (SP4: Source_Metier + Source_Mapping)
                if dp.get("expected_schema_version") in ("SP1", "SP2", "SP3"):
                    err(f"{p}.properties.data_source_code",
                        "detail virtuel : exige le niveau de schema SP4 "
                        "(Controle_Designer_Table.Source_Metier/_Mapping - migration 006)")
                if vsrc in src_return and src_return[vsrc] != "table":
                    err(f"{p}.properties.data_source_code",
                        f"la source {vsrc!r} est return_type={src_return[vsrc]} : "
                        f"une grille virtuelle exige une source de retour TABLE "
                        f"(miroir VerifierTableVirtuelle)")
                elif vsrc not in src_index:
                    warn(f"{p}.properties.data_source_code",
                         f"'{vsrc}' absent du input : doit exister dans Controle_Designer_Source "
                         f"avec Typ_Retour='TABLE' (verifie par le preflight)")
                decl_params = src_index.get(vsrc)
                if not props.get("source_mapping"):
                    if decl_params:
                        err(f"{p}.properties.source_mapping",
                            "detail virtuel : mapping des parametres de la source requis "
                            '{"Param":{"ref":"ColonneEntete"}}')
                    elif decl_params is None:
                        warn(f"{p}.properties.source_mapping",
                             "source hors input : le mapping doit alimenter tous ses "
                             "parametres obligatoires (re-verifie par l'import - "
                             "miroir VerifierSourceVirtuelle)")
                else:
                    check_source_mapping(props["source_mapping"],
                                         f"{p}.properties.source_mapping",
                                         header_cols, decl_params)
                for flg in ("allow_add", "allow_edit", "allow_delete", "allow_duplicate"):
                    if props.get(flg):
                        warn(f"{p}.properties.{flg}",
                             "grille virtuelle : le Designer force ce flag a false "
                             "(lecture seule, aucune table physique)")
            continue
        if tb != "ENT" and tb not in grids:
            err(f"{p}.target_block", f"detail_grid inconnu : {tb!r}")

        # ----- colonne physique (stocke / non stocke) -----
        col = phys_col(c)
        if col:
            if not is_ident(col):
                err(f"{p}.column_name", "identifiant SQL invalide ou reserve")
            if col in TECH_COLS_ALL:
                err(f"{p}.column_name",
                    f"'{col}' est une colonne technique (ajoutee automatiquement au "
                    f"DDL) : interdite dans la structure (miroir de l'import)")
            pair = (tb, col)
            if pair in col_pairs:
                err(f"{p}.column_name", f"colonne dupliquee dans le bloc {tb}: {col!r}")
            col_pairs.add(pair)
        else:
            if ct not in NO_COLUMN_TYPES:
                err(f"{p}.column_name",
                    f"column_name explicitement vide interdit pour {ct} : seuls "
                    f"calculated/source non persistes et attachments peuvent ne pas "
                    f"avoir de colonne physique")
            if props.get("persist"):
                err(f"{p}.properties.persist", "persist=true exige une colonne physique "
                                               "(column_name non vide)")
            if ct in ("calculated", "source") and not props.get("persist") \
                    and c.get("column_name"):
                warn(f"{p}.column_name",
                     "persist=false : aucune colonne physique ; column_name ignore")
        if ct == "attachments" and c.get("column_name"):
            warn(f"{p}.column_name", "un champ GED n'est jamais stocke : colonne ignoree")

        lay = c.get("layout") or {}
        if lay.get("height") is not None:
            err(f"{p}.layout.height", "[UNSUPPORTED] pas de hauteur dans le layout RHP (flux 12 colonnes)")
        if lay.get("width") is not None and not (1 <= lay["width"] <= 12):
            err(f"{p}.layout.width", "1..12 attendu (grille MUI)")

        st = props.get("sql_type")
        if st and st not in SQL_TYPES:
            err(f"{p}.properties.sql_type", f"type SQL invalide : {st!r}")
        if props.get("length") is not None and not (-1 <= props["length"] <= 4000):
            err(f"{p}.properties.length", "-1 (max) ou 1..4000")
        if props.get("precision") is not None and not (1 <= props["precision"] <= 38):
            err(f"{p}.properties.precision", "1..38")
        if (props.get("scale") is not None and props.get("precision") is not None
                and props["scale"] > props["precision"]):
            err(f"{p}.properties.scale", "scale > precision")
        if props.get("grid_total"):
            err(f"{p}.properties.grid_total",
                "[SUPPRIME] la colonne Total_Grille a ete supprimee par la migration 005 : "
                "utiliser un champ calcule de pied de grille (calculated + column_name:'' "
                "+ persist:false + formule {\"op\":\"SUM\",\"table\":...,\"colonne\":...})")
        if props.get("unique") and props.get("indexed"):
            warn(f"{p}.properties", "unique + indexed : l'index unique (UX_) prime")

        # ----- cles sans cible dans le format d'import (bloquant) -----
        for key, why in NO_JSON_TARGET.items():
            if props.get(key):
                err(f"{p}.properties.{key}",
                    f"[NO-JSON-TARGET] {why} (json-import-format.md section 8) : "
                    f"laisser la valeur neutre")
        if props.get("recalc_save") is False:
            err(f"{p}.properties.recalc_save",
                "[NO-JSON-TARGET] Recalc_Save absent du format d'import (defaut base "
                "'true') : laisser true")

        if ct in ("radio", "reference_list") and not props.get("rubrique"):
            err(f"{p}.properties.rubrique", f"requis pour {ct}")
        if ct in ("zoom", "combo"):
            if not props.get("zoom"):
                err(f"{p}.properties.zoom", f"Num_Zoom requis pour {ct}")
        if ct == "attachments" and not att.get("enabled"):
            err(f"{p}.component_type", "champ GED sans page.attachments.enabled=true")
        if ct == "calculated":
            if not props.get("formula"):
                err(f"{p}.properties.formula", "formule requise pour calculated")
            else:
                # engine resolution: row columns first, then header columns
                check_formula(props["formula"], f"{p}.properties.formula",
                              block_cols.get(tb, set()) | block_cols.get("ENT", set()),
                              grids, block_cols)
        if ct == "source":
            if not c.get("data_source_code"):
                err(f"{p}.data_source_code", "requis pour source")
            if tb != "ENT":
                warn(f"{p}.target_block",
                     "champ SOURCE hors entete : non re-execute par les moteurs "
                     "(client et save serveur ne traitent que Cod_Table='ENT')")
            f = props.get("formula")
            if f is not None:
                if not isinstance(f, dict) or "source" not in f:
                    err(f"{p}.properties.formula",
                        'mapping source attendu : {"source":...,"mapping":{...}}')
                else:
                    if c.get("data_source_code") and f["source"] != c["data_source_code"]:
                        warn(f"{p}.properties.formula.source",
                             f"'{f['source']}' != data_source_code "
                             f"'{c['data_source_code']}' : le moteur execute formula.source ; "
                             f"les deux doivent coincider")
                    if f["source"] not in src_index:
                        warn(f"{p}.properties.formula.source",
                             f"'{f['source']}' absent du input : doit exister dans "
                             f"Controle_Designer_Source (verifie par le preflight)")
                    if "mapping" in f:
                        check_source_mapping(f["mapping"], f"{p}.properties.formula.mapping",
                                             header_cols, src_index.get(f["source"]))
        if props.get("is_criteria"):
            if tb != "ENT":
                err(f"{p}.properties.is_criteria", "critere reserve aux champs ENT")
            if ct in NO_CRITERIA_TYPES:
                err(f"{p}.properties.is_criteria", f"type {ct} exclu des criteres (regle frontend)")
            if props.get("criteria_order") is None:
                err(f"{p}.properties.criteria_order", "requis quand is_criteria=true")
        if props.get("default_sort"):
            for tok in str(props["default_sort"]).split(","):
                name = tok.strip().split(" ")[0]
                if name and name not in block_cols.get(tb, set()):
                    err(f"{p}.properties.default_sort", f"colonne inconnue : {name!r}")

    # cycle detection between calculated fields (mirror of DetecterCycle)
    calc_deps = {}
    for c in comps:
        if c.get("component_type") == "calculated" and (c.get("properties") or {}).get("formula"):
            refs = []
            formula_refs(c["properties"]["formula"], refs)
            calc_deps[c.get("column_name") or c["component_code"]] = refs
    state = {}

    def visit(n, stack):
        if state.get(n) == 1:
            err("components", f"reference circulaire dans les calculs : {' -> '.join(stack + [n])}")
            return
        if state.get(n) == 2:
            return
        state[n] = 1
        for d in calc_deps.get(n, []):
            if d in calc_deps:
                visit(d, stack + [n])
        state[n] = 2

    for n in list(calc_deps):
        visit(n, [])

    # ----- validations
    vcodes = []
    for i, v in enumerate(spec.get("page_validations") or []):
        vcodes.append(check_validation(v, f"page_validations[{i}]", {"ENT", *grids},
                                       block_fields, block_cols, grids, src_index,
                                       header_cols))
    for i, c in enumerate(comps):
        if c.get("component_type") == "detail_grid":
            continue
        tb = c.get("target_block", "ENT")
        for j, v in enumerate(c.get("validations") or []):
            vv = dict(v)
            vv.setdefault("scope", "CHAMP" if tb == "ENT" else "LIGNE")
            vv.setdefault("target_block", tb)
            vv.setdefault("target_field", c.get("component_code"))
            vcodes.append(check_validation(vv, f"components[{i}].validations[{j}]",
                                           {"ENT", *grids}, block_fields, block_cols,
                                           grids, src_index, header_cols))
    if len(set(vcodes)) != len([c for c in vcodes if c]):
        err("validations", "code de validation duplique")

    # ----- data sources
    seen_src = []
    for i, s in enumerate(spec.get("data_sources") or []):
        p = f"data_sources[{i}]"
        sc = req_str(s, "data_source_code", p, 50)
        if sc and not is_ident(sc):
            err(f"{p}.data_source_code", "identifiant SQL invalide ou reserve")
        seen_src.append(sc)
        req_str(s, "label", p, 150)
        if s.get("source_type") not in ("sql", "proc"):
            err(f"{p}.source_type", "sql | proc attendu (Typ_Source SQL/PROC)")
        ref = s.get("reference")
        if not isinstance(ref, str) or not ref.strip():
            err(f"{p}.reference", "SQL ou nom de procedure requis")
        else:
            check_source_sql(ref, f"{p}.reference")
        if s.get("return_type", "scalar") not in ("scalar", "table"):
            err(f"{p}.return_type", "scalar | table attendu")
        ao = s.get("allowed_operations") or {}
        if ao.get("read") is not True or any(ao.get(k) for k in ("create", "update", "delete")):
            err(f"{p}.allowed_operations",
                "les sources RHP sont en lecture seule (garde-fou serveur) : read=true, autres=false")
        names = []
        for j, prm in enumerate(s.get("parameters") or []):
            pp = f"{p}.parameters[{j}]"
            nm = prm.get("name", "")
            if nm.lower() == "id_societe":
                err(f"{pp}.name", "id_Societe est injecte par le serveur : ne pas le declarer")
            if not is_ident(nm):
                err(f"{pp}.name", "nom de parametre invalide")
            ptyp = str(prm.get("type", "nvarchar")).lower()
            if ptyp not in PARAM_TYPES:
                err(f"{pp}.type", f"type de parametre invalide : {ptyp!r} "
                                  f"(nvarchar|int|decimal|date|datetime|bit)")
            names.append(nm)
        if len(set(names)) != len(names):
            err(f"{p}.parameters", "parametre duplique")
    if len(set(seen_src)) != len([s for s in seen_src if s]):
        err("data_sources", "data_source_code duplique")

    # fields referencing sources must resolve (input catalog or pre-existing)
    declared_src = set(seen_src)
    for i, c in enumerate(comps):
        if c.get("component_type") == "source" and c.get("data_source_code"):
            if c["data_source_code"] not in declared_src:
                warn(f"components[{i}].data_source_code",
                     f"'{c['data_source_code']}' absent du input : doit exister dans "
                     f"Controle_Designer_Source (verifie par le preflight)")

    # ----- access control
    ac = spec.get("access_control") or {}
    policy = ac.get("default_policy")
    if policy not in ("deny", "open_read"):
        err("access_control.default_policy", "deny | open_read attendu")
    roles = ac.get("roles") or []
    rcs = []
    for i, r in enumerate(roles):
        p = f"access_control.roles[{i}]"
        rc = req_str(r, "role_code", p, 10)
        rcs.append(rc)
        if rc == "1":
            warn(f"{p}.role_code", "profil '1' = super-admin : contourne tous les controles (convention RHP)")
        perms = r.get("permissions") or {}
        if perms.get("view") is not True:
            warn(f"{p}.permissions.view", "sans view=true le profil ne verra pas la page")
        for k in perms:
            if k not in ("view", "create", "update", "delete", "export", "submit", "attachments"):
                warn(f"{p}.permissions.{k}", "cle inconnue (ignoree)"
                                           " - actions RHP : Consulter/Creer/Modifier/Supprimer/Valider/Imprimer/GED")
        if perms.get("submit") and not wf.get("enabled"):
            err(f"{p}.permissions.submit", "droit Valider sans workflow.enabled=true")
        if perms.get("attachments") and not att.get("enabled"):
            err(f"{p}.permissions.attachments", "droit GED sans page.attachments.enabled=true")
    if policy == "deny" and not any((r.get("permissions") or {}).get("view") is True for r in roles):
        err("access_control.roles",
            "default_policy=deny exige au moins un role avec view=true "
            "(sinon la page serait invisible pour tous - controle de publication RHP)")
    if len(set(rcs)) != len([r for r in rcs if r]):
        err("access_control.roles", "role_code duplique")


def main():
    if len(sys.argv) != 2:
        print("usage: python validate_input.py <input.json>", file=sys.stderr)
        sys.exit(2)
    with open(sys.argv[1], "r", encoding="utf-8-sig") as f:
        spec = json.load(f)
    validate(spec)
    report = {
        "status": "errors" if errors else "ok",
        "errors": errors,
        "warnings": warnings,
        "summary": {
            "page_code": (spec.get("page") or {}).get("page_code"),
            "operation": (spec.get("request") or {}).get("operation"),
            "components": len(spec.get("components") or []),
            "blocking_errors": len(errors),
            "warnings": len(warnings),
        },
    }
    print(json.dumps(report, ensure_ascii=False, indent=2))
    sys.exit(1 if errors else 0)


if __name__ == "__main__":
    main()
