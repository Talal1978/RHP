#!/usr/bin/env python3
"""
validate_input.py - RHP Portal Page Deployer input validator (stdlib only).

Validates a CANONICAL JSON input (converted from the YAML contract) against
the blocking rules of the skill, mirroring the verified RHP constraints:
  - CK_SP_Page_Ident, UQ_SP_Page_Document, CK_SPChamp_Typ, CK_SPChamp_Etat,
    CK_SPValid_* , CK_SPSource_*  (001_SP_Designer_Metadata.sql)
  - identifier rules + reserved words (Module_SP_DDL.vb / module_sp_engine.ts)
  - read-only source guard (module_sp_engine.ts:569-588)
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
GRID_TOTALS = {"", "SUM", "AVG", "MIN", "MAX", "COUNT"}
VALID_TYPES = {"REQUIRED", "IN", "BETWEEN", "MIN", "MAX", "MINLEN", "MAXLEN",
               "REGEX", "COMPARE", "UNIQUE", "SOURCE", "EXPR", "NB_LIGNES"}
VALID_SCOPES = {"CHAMP", "ENTETE", "LIGNE", "DETAIL", "DOCUMENT"}
VALID_LEVELS = {"I", "W", "B"}
VALID_MOMENTS = {"SAISIE", "CHANGE", "AJOUT_LIGNE", "SAVE"}
LOGIC_OPS = {"AND", "OR", "NOT", "EQ", "NE", "GT", "GE", "LT", "LE",
             "IN", "EMPTY", "NOTEMPTY", "CONTIENT"}
CALC_OPS = {"ADD", "SUB", "MUL", "DIVSAFE", "COND", "SUM", "AVG", "MIN",
            "MAX", "COUNT", "ROUND", "ABS", "REF", "CONST"}
AGG_OPS = {"SUM", "AVG", "MIN", "MAX", "COUNT"}
NO_CRITERIA_TYPES = {"calculated", "source", "attachments", "checkbox", "radio"}

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
def check_formula(node, path, block_cols, det_blocks, det_cols, depth=0):
    """Declarative AST only; whitelisted ops; refs/aggregates must resolve."""
    if depth > 20:
        err(path, "formule trop profonde (> 20)")
        return
    if not isinstance(node, dict):
        err(path, "noeud de formule invalide (objet attendu)")
        return
    if "ref" in node:
        if not isinstance(node["ref"], str) or node["ref"] not in block_cols:
            err(f"{path}.ref", f"colonne inconnue dans ce bloc : {node.get('ref')!r}")
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
    if op in AGG_OPS and "table" in node:  # aggregate over a detail block
        tbl = node.get("table")
        if tbl not in det_blocks:
            err(f"{path}.table", f"bloc detail inconnu : {tbl!r}")
        elif node.get("colonne") and node["colonne"] not in det_cols.get(tbl, set()):
            err(f"{path}.colonne", f"colonne inconnue du bloc {tbl}: {node.get('colonne')!r}")
        return
    args = node.get("args")
    if not isinstance(args, list) or not args:
        err(f"{path}.args", f"operateur {op} : liste args requise")
        return
    for i, a in enumerate(args):
        check_formula(a, f"{path}.args[{i}]", block_cols, det_blocks, det_cols, depth + 1)


def formula_refs(node, acc):
    if isinstance(node, dict):
        if "ref" in node and isinstance(node["ref"], str):
            acc.append(node["ref"])
        for v in node.values():
            formula_refs(v, acc)
    elif isinstance(node, list):
        for v in node:
            formula_refs(v, acc)


# ---------------------------------------------------------------- sources
def check_source_sql(code, path):
    """Mirror of estRequeteLectureSeule (module_sp_engine.ts:569-588)."""
    cleaned = re.sub(r"/\*.*?\*/", "", code, flags=re.S)
    cleaned = re.sub(r"--.*?(\n|$)", " ", cleaned)
    cleaned = re.sub(r"\s+", " ", cleaned).strip()
    if re.search(r";.*\S", re.sub(r";\s*$", "", cleaned)):
        err(path, "instruction multiple interdite dans la source")
        return
    low = cleaned.lower()
    if not re.match(r"^(select|with)\b", low) and not re.match(r"^exec(ute)?\s+dbo\.sys_\w+", low):
        err(path, "seuls SELECT / WITH / EXEC dbo.Sys_* sont autorises")
        return
    if re.search(r"\b(insert|update|delete|merge|drop|alter|create|truncate|grant|revoke|"
                 r"backup|restore|shutdown|kill|waitfor|openrowset|opendatasource|"
                 r"xp_\w+|sp_\w+)\b", cleaned, flags=re.I):
        err(path, "mots-cles SQL interdits dans la source")


# ---------------------------------------------------------------- validations
def check_validation(v, path, blocks, fields_by_block):
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
    if vtype == "EXPR":
        p = v.get("parameters") or {}
        if not isinstance(p, dict) or "expr" not in p:
            err(f"{path}.parameters", 'EXPR attend {"expr": {...}}')
    if vtype == "NB_LIGNES" and scope != "DETAIL":
        warn(f"{path}.scope", "NB_LIGNES s'applique normalement a la portee DETAIL")
    return code


# ---------------------------------------------------------------- main
def validate(spec):
    # ----- request
    rq = spec.get("request") or {}
    op = rq.get("operation")
    if op not in ("create", "update", "disable"):
        err("request.operation", "create | update | disable attendu")
    if rq.get("environment") not in ("development", "test", "production"):
        err("request.environment", "development | test | production attendu")
    if not isinstance(rq.get("dry_run"), bool):
        err("request.dry_run", "booleen requis (true recommande)")
    req_str(rq, "requested_by", "request", 50)
    req_str(rq, "change_reference", "request", 50)

    # ----- deployment
    dp = spec.get("deployment") or {}
    if not isinstance(dp.get("update_if_exists"), bool):
        err("deployment.update_if_exists", "booleen requis (autorisation explicite)")
    if dp.get("expected_schema_version") not in ("SP1", "SP2", "SP3"):
        err("deployment.expected_schema_version", "SP1 | SP2 | SP3 attendu")
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
        if not is_ident(code) or len(code) > 30:
            err("page.page_code", "identifiant SQL invalide ou reserve")
        if code.lower().startswith("page"):
            err("page.page_code", "ne doit pas commencer par 'Page' (CK_SP_Page_Ident)")
    dcode = req_str(pg, "document_code", "page", 10)
    if dcode and not re.match(r"^[A-Za-z0-9_]{1,10}$", dcode):
        err("page.document_code", "1..10 caracteres alphanumeriques/underscore")
    if dcode and code and dcode.lower().startswith("page"):
        err("page.document_code", "ne doit pas commencer par 'Page' (noms physiques SP_<doc>_...)")
    req_str(pg, "page_name", "page", 150)
    req_str(pg, "title", "page", 60)
    if pg.get("short_title") and len(pg["short_title"]) > 50:
        err("page.short_title", "longueur > 50")
    if pg.get("target_section_id") is not None:
        err("page.target_section_id", "[UNSUPPORTED] les sections n'ont pas d'id : target_section_code")
    section = req_str(pg, "target_section_code", "page", 60)
    if section and not re.match(r"^[A-Za-z0-9_]+$", section):
        err("page.target_section_code", "caracteres alphanumeriques/underscore uniquement")
    if pg.get("create_section_if_missing") and not pg.get("new_section_label"):
        err("page.new_section_label", "requis quand create_section_if_missing=true")
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

    act = pg.get("actions") or {}
    wf = pg.get("workflow") or {}
    att = pg.get("attachments") or {}
    if act.get("submit") and not wf.get("enabled"):
        err("page.actions.submit", "exige workflow.enabled=true (bouton Soumettre lie au workflow)")
    if act.get("print") and not pg.get("print_model"):
        err("page.actions.print", "exige page.print_model (Param_Mod_Edition.Cod_Report)")
    if att.get("categories") and not all(isinstance(c, str) for c in att.get("categories", [])):
        err("page.attachments.categories", "liste de chaines attendue")

    # ----- components
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
            block_cols.setdefault(tb, set()).add(c.get("column_name") or cc)

    if len(set(codes)) != len(codes):
        err("components", "component_code duplique")
    if len(grids) > 0 and not any(
            (c.get("target_block", "ENT") == "ENT") and c.get("component_type") != "detail_grid"
            for c in comps):
        warn("components", "aucun champ d'entete : page liste sans entete exploitable")

    col_pairs = set()
    for i, c in enumerate(comps):
        p = f"components[{i}]"
        ct = c.get("component_type")
        cc = c.get("component_code", "")
        props = c.get("properties") or {}
        tb = c.get("target_block", "ENT")

        if ct == "detail_grid":
            if props.get("delete_rule", "CASCADE") not in ("CASCADE", "RESTRICT"):
                err(f"{p}.properties.delete_rule", "CASCADE | RESTRICT attendu")
            continue
        if tb != "ENT" and tb not in grids:
            err(f"{p}.target_block", f"detail_grid inconnu : {tb!r}")

        col = c.get("column_name") or cc
        if col and not is_ident(col):
            err(f"{p}.column_name", "identifiant SQL invalide ou reserve")
        pair = (tb, col)
        if pair in col_pairs:
            err(f"{p}.column_name", f"colonne dupliquee dans le bloc {tb}: {col!r}")
        col_pairs.add(pair)

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
        if props.get("grid_total", "") not in GRID_TOTALS:
            err(f"{p}.properties.grid_total", "''|SUM|AVG|MIN|MAX|COUNT")
        if props.get("unique") and props.get("indexed"):
            warn(f"{p}.properties", "unique + indexed : l'index unique (UX_) prime")

        if ct in ("radio", "reference_list") and not props.get("rubrique"):
            err(f"{p}.properties.rubrique", f"requis pour {ct}")
        if ct in ("zoom", "combo") and not props.get("zoom"):
            err(f"{p}.properties.zoom", f"Num_Zoom requis pour {ct}")
        if ct == "attachments" and not att.get("enabled"):
            err(f"{p}.component_type", "champ GED sans page.attachments.enabled=true")
        if ct == "calculated":
            if not props.get("formula"):
                err(f"{p}.properties.formula", "formule requise pour calculated")
            else:
                check_formula(props["formula"], f"{p}.properties.formula",
                              block_cols.get(tb, set()), grids, block_cols)
        if ct == "source":
            if not c.get("data_source_code"):
                err(f"{p}.data_source_code", "requis pour source")
            f = props.get("formula")
            if f is not None and (not isinstance(f, dict) or "source" not in f):
                err(f"{p}.properties.formula", 'mapping source attendu : {"source":...,"mapping":{...}}')
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
        vcodes.append(check_validation(v, f"page_validations[{i}]", {"ENT", *grids}, block_fields))
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
                                           {"ENT", *grids}, block_fields))
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
                     f"SP_Page_Source (verifie par le preflight)")

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
