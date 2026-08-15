---
name: rhp-portal-page-deployer
description: >
  Transforme une description fonctionnelle precise d'une page portail RHP en un
  package de deploiement SQL Server sur, auditable, idempotent et reversible
  (metadonnees SP_Page*, tables metier generees prefixees SP_ suffixees _Ent
  et _Det_, rattachement a une section du menu, habilitations, publication).
  A utiliser quand on demande la creation, la mise a jour ou la desactivation
  d'une page du Designer de pages portail RHP (module SP_), ou la generation
  du SQL de deploiement correspondant.
---

# RHP Portal Page Deployer

## 1. Purpose

Generate a production-ready SQL Server deployment package that creates a portal
page in the **RHP Portal Page Designer module (SP_)**, attaches it to a portal
menu section, configures its fields/validations/permissions, and makes it
operational on first deployment — strictly reusing the verified RHP mechanisms:
metadata tables `SP_Page*`, generated business tables `SP_<doc>_Ent/_Det_*`,
publication procedure of `SP_Page_Designer.Publier`, DDL rules of
`Module_SP_DDL`.

The skill **generates SQL; it never executes it**. Execution remains a DBA
action (sqlcmd/SSMS), after human review.

## 2. Trigger conditions

Use this skill when the user asks to:
- create/deploy a new RHP portal page from a functional description;
- update an existing SP_ page (only with explicit update authorization);
- disable/unpublish an SP_ page;
- produce or review SP_ deployment/rollback SQL.

Do NOT use it for: hardcoded (non-SP_) portal screens, desktop WinForms screens,
dashboard widgets, surveys, or any schema change outside the SP_ module.

## 3. Required context and reference files

| File | Load when |
|---|---|
| `references/schema-mapping.md` | Always first — verified concept→object mapping + conventions |
| `references/sp-metadata-model.md` | Before writing any SQL — exact columns, DDL format, publication procedure |
| `references/formules-calculees.md` | Any `calculated` field, `visibility_rule`/`activation_rule`, `EXPR` validation or aggregate — exhaustive formula logic: AST, 43 whitelisted ops with exact semantics, GV_* variables, dependency graph/cycles, recalc triggers, French assistant mapping |
| `references/comportement-page.md` | Any behavior question — field states, dynamic rules, the 13 validation types with exact `Parametres` json, scopes/levels/moments, document lifecycle (numbering, RV concurrency, `Figer_Statuts`), detail-grid flags, rights & FAB actions, list criteria |
| `references/sources-metier.md` | Any `data_sources` entry, `source` field, virtual detail grid, `SOURCE` validation, zoom condition — catalog, read-only guard (exact rules), parameter declaration/auto-injection, the 3 usages |
| `references/environment-discovery.md` | Schema uncertain / new environment / preflight design |
| `templates/input-template.yaml` | Building or completing an input |
| `templates/deploy-template.sql`, `rollback-template.sql`, `preflight-template.sql` | Generating the package |
| `references/testing-acceptance-checklist.md` | Finalizing the package (manifest section) |
| `examples/` | Worked inputs/outputs; `002_SP_Designer_Exemple_FKM.sql` in the repo is the oracle |

Repository ground truth (read-only): `RHP_Portail\rhpBE\sql\SP_Designer\*.sql`
(001 metadata, 002 FKM oracle, 003 critères, 004 workflow, 005 Total_Grille,
006 évolutions SP4), `RHP_DeskTop\RHP\Portail\Module_SP_DDL.vb`,
`SP_Page_Designer.vb`, `Zoom_SP_Assistant_Formule.vb`,
`Zoom_SP_Assistant_Validation.vb`, `Zoom_SP_Assistant_ParamSource.vb`,
`Zoom_SP_MappingSource.vb`, `Zoom_SP_SqlSource.vb`,
`RHP_Portail\rhpBE\modules\module_sp_engine.ts`, `controlers\sp_document.ts`,
`RHP_Portail\rhpfe\src\Pages\Dynamic\*.tsx/ts`.

## 4. Input contract

YAML or JSON. Natural-language requests must first be converted into this
structure and validated — never generate SQL directly from prose.
Full annotated contract: `templates/input-template.yaml`. Fixed skeleton:

- `request`: `operation` (create|update|disable), `environment`, `dry_run`,
  `requested_by`, `change_reference`.
- `page`: `page_code` (→`Cod_Page`), `document_code` (→`Cod_Document`),
  `page_name` (→`Libelle`), `title` (→`Nom_Page`), `target_section_code`
  (→`Menu_Parent`), `display_order` (→`Rang`), `enabled`, plus optional
  extensions `icon`, `layout_type`, `actions`, `print_model`, `attachments`,
  `workflow`, `create_section_if_missing`, `freeze_statuses` (→`Figer_Statuts`,
  SP4).
- `components`: fields/blocks. `component_type` ∈ whitelist
  (`text,memo,integer,decimal,money,date,datetime,checkbox,radio,combo,
  reference_list,zoom,calculated,source,attachments,detail_grid`) → verified
  `Typ_Controle` values. Layout = 12-col flow grid (`row/column/width/
  display_order` → `Ligne/Colonne/Largeur/Rang`); `height` unsupported.
  `calculated` formulas and `visibility_rule`/`activation_rule` follow
  `references/formules-calculees.md` (AST, whitelisted ops, GV_* variables);
  `zoom`/`combo` accept `zoom_condition` (→`Zoom_Condition`, SP4, `{Champ}`
  placeholders); a `detail_grid` with `data_source_code` is a **virtual
  detail** fed by a TABLE source (→`Source_Metier`/`Source_Mapping`, SP4 —
  see `references/sources-metier.md` §6).
- `page_validations` / component `validations`: → `SP_Page_Validation`
  (13 verified `Typ_Regle` with exact `Parametres` json per type — see
  `references/comportement-page.md` §3).
- `data_sources`: → `SP_Page_Source` (read-only catalog; `allowed_operations`
  write flags are forbidden — server-enforced; full parameter/execution model
  in `references/sources-metier.md`).
- `access_control`: `default_policy` deny|open_read → `Acces_Personnalise`;
  `roles[].permissions` view/create/update/delete/export(/submit/attachments)
  → `SP_Page_Droit` flags Consulter/Creer/Modifier/Supprimer/Imprimer
  (/Valider/GED). RHP has **no separate export right** — export maps to
  `Imprimer` (verified `SP_Page_Droit` columns).
- `deployment`: `update_if_exists`, `expected_schema_version` (SP1|SP2|SP3|SP4
  — SP4 = migration 006 : `Figer_Statuts`, `Zoom_Condition`,
  `SP_Page_Table.Source_Metier/_Mapping`; required when the input uses them),
  `use_feature_flag`/`feature_flag_code` **unsupported** (no such mechanism in
  RHP — verified absence; use `page.enabled` instead).

Contract keys with no RHP target (`target_section_id`, free-form `route`,
`layout.height`) must keep neutral values; non-neutral values are blocking
errors, never silently dropped.

## 5. Analysis workflow

1. **Restate** the request as the canonical input (fill `input-template.yaml`).
2. **Classify every fact**: `verified` (in repo sources) / `assumption`
   (reasonable default, listed in the manifest) / `missing` (blocks — see §6).
3. **Check the environment** via `references/environment-discovery.md`:
   schema level, section codes, zooms, rubriques, sources, profiles, print
   model, workflow proc. Without DB access, emit the preflight script and mark
   its results as mandatory before execution.
4. **Validate**: run `scripts/validate_input.py <canonical.json>`
   (stdlib only; YAML must be converted to JSON first). All errors are blocking.
5. Only then generate SQL (§7).

## 6. Blocking validation rules (STOP — no SQL output)

Hard stops (full list enforced by `validate_input.py`):
- Missing/invalid `page_code` (regex, not `Page*`, ≤30), `document_code`
  (1..10), `page_name`, `title`, `target_section_code`.
- `operation=create` while the page exists and `update_if_exists=false`;
  `operation=update` without `update_if_exists=true`; `update`/`disable` of a
  non-existent page.
- Unknown `component_type`; layout `width` outside 1..12; non-null `height`.
- `radio`/`reference_list` without `rubrique`; `zoom`/`combo` without `zoom`;
  `calculated` without `formula`; `source` without `data_source_code`;
  `attachments` field without `page.attachments.enabled`.
- Formula AST: non-whitelisted op (full 43-op whitelist of the engines —
  `references/formules-calculees.md` §3/§5-§8), unknown `ref` (GV_* accepted),
  unknown aggregate target, cycle between calculated fields (mirror of
  `DetecterCycle`).
- Virtual detail (`detail_grid` with `data_source_code`) on `ENT`, with a
  source not `return_type: table`, with a mapping referencing non-header
  fields, or leaving a required source parameter unfed (mirror of
  `VerifierTableVirtuelle`).
- `zoom_condition` placeholder `{X}` not matching a header field;
  `freeze_statuses` not a CSV of status codes.
- Duplicate `component_code`, `(block,column)`, validation code, source code,
  role code.
- Data source failing the read-only guard (as re-run by the engine —
  `references/sources-metier.md` §2), declaring `@id_Societe`, or with
  write `allowed_operations`.
- `default_policy=deny` with no `view:true` role (page would be invisible —
  mirrors the RHP publication check).
- `actions.submit` without `workflow.enabled`; `actions.print` without
  `print_model`; `submit`/`attachments` permissions inconsistent with the page.
- `use_feature_flag=true` or non-empty `feature_flag_code`.
- Contradiction between discovery results and this skill's references.

Missing-info handling: output a **MISSING INFO** report (one line per item:
what is needed, why, which input key carries it) and stop.

## 7. SQL-generation workflow

Assemble `templates/deploy-template.sql` in fixed section order (deterministic
output: same input + same repo state ⇒ functionally equivalent SQL):

1. Header (provenance: change reference, requester, environment, operation).
2. Parameters: `@DryRun` (from `request.dry_run`), `@CP`, `@CDoc`, `@Login`…
3. Preconditions: schema level + operation guards + referenced-object guards
   (`RAISERROR(16)` → CATCH → rollback).
4. Optional menu-section creation (`SP_Menu_Portail` rubrique insert, mirror of
   `SP_Page_Designer.vb:380-394`).
5. `SP_Page`: guarded INSERT (create) / mutable-columns UPDATE (authorized
   update). `Cod_Page`, `Cod_Document`, `Table_Ent` are immutable.
6. Child collections (`SP_Page_Table/_Colonne/_Champ/_Validation/_Droit`):
   official 002 pattern — `DELETE … WHERE Cod_Page=@CP` (controlled, page-scoped)
   then deterministic INSERTs ordered by `Rang`. ENT block first.
7. `SP_Page_Source`: INSERT-if-absent only (shared catalog, never overwritten).
8. Business DDL in exact `Module_SP_DDL` format
   (`references/sp-metadata-model.md` §9): guarded `CREATE TABLE` with technical
   columns, or `ALTER … ADD`-only migration; `IX_/UX_` indexes; `FK_<det>_Ent`
   `WITH NOCHECK` (+`ON DELETE CASCADE` iff `CASCADE`); **never** drop a column —
   emit `-- ATTENTION` comments instead. **No DDL for virtual details**
   (`Source_Metier` set — `SP_<doc>_Virt_<table>` is a logical name only).
   Log to `SP_Page_DDL_Log`.
9. Publication (only if `page.enabled=true`): precondition checks mirroring
   `Publier()` (including `VerifierTableVirtuelle` for virtual details and the
   calculated-field cycle check — `references/formules-calculees.md` §9), then
   `Statut_Page='PUBLIE'` + `Version_Page+1`, upsert
   `Controle_Def_Ecran` (`SPP_<code>`), upsert `Param_Workflow_Typ_Document`
   (iff workflow). `enabled=false` ⇒ stays `BROUILLON`, skip §9 with a note.
10. Final verification SELECTs; `COMMIT` or `ROLLBACK` per `@DryRun`; CATCH =
    rollback + guarded DDL-log + `THROW`.

Also generate: `rollback` (from `rollback-template.sql`) and `preflight`
(from `preflight-template.sql`), plus a **manifest** (§8).

Literal escaping: double single-quotes; unicode labels prefixed `N'…'`;
identifiers only from validated input; physical names **derived**
(`SP_<document_code>_Ent`, `SP_<document_code>_Det_<BLOCK>`) — never free-form.

## 8. Output format

A directory `NNN_<page_code>/` (NNN = sequence or change ref) containing:

| File | Content |
|---|---|
| `input.yaml` (or `.json`) | The validated canonical input |
| `preflight.sql` | Read-only pre-deployment checks (all KO = blocking) |
| `deploy.sql` | Idempotent deployment (dry-run flag at top) |
| `rollback.sql` | Reversible rollback (see §10) |
| `manifest.md` | Facts/assumptions/missing-info classification; mapping decisions; checklist from `references/testing-acceptance-checklist.md` |

Response to the user: package path + the classification summary + explicit
statement of anything not deployed automatically (e.g. workflow signature
circuit, frontend `menus.json` — nothing to do, dynamic merge).

## 9. Security constraints (non-negotiable)

- Never invent tables/columns/procs/routes/component types — verified objects
  only (`references/schema-mapping.md`).
- Never emit `DROP`, `TRUNCATE`, or uncontrolled `DELETE`. The only DELETEs
  allowed are page-scoped metadata deletes (`WHERE Cod_Page=@CP`) and, in
  rollback phase 2, the guarded registry cleanup.
- Never modify an existing page without `update_if_exists=true`.
- No dynamic SQL built from unvalidated identifiers; `SP_` prefix enforced on
  physical tables; reserved-word blacklist (both mirrored from RHP code).
- Business data is never inserted by generated scripts (`Num_Doc` numbering is
  server-side); no secrets in scripts; `Created_By` = `requested_by`.
- Single transaction, `XACT_ABORT ON`, full rollback on any error.
- Sources: single read-only statement (server guard mirrored at validation).

## 10. Rollback requirements

`rollback.sql` (mirrors `SP_Page_Designer.Deleting`/`Publier` semantics):
- Phase 1 (always safe): `PUBLIE` → `DESACTIVE` (page leaves the portal,
  documents preserved).
- Phase 2 (`@RemoveMetadata=1`, only if not published and no business rows):
  FK-safe metadata deletion (Colonne→Champ→Validation→Droit→Table→DDL_Log→
  Page), then registry rows `Controle_Def_Ecran`/`Param_Workflow_Typ_Document`
  created by the deployment, and the rubrique row if the deployment created it.
- **Business tables `SP_*` are never dropped** (official module rule).
- Update-rollback limitation (documented): restoring an *updated* page =
  re-running the previous version's deploy script (deterministic regeneration)
  or DB backup restore. Say so in the manifest.

## 11. Error handling

- Validation errors → stop, list all errors with input paths (no partial SQL).
- Discovery contradictions → stop, report discrepancy.
- Generated scripts self-guard: precondition failure ⇒ `RAISERROR` ⇒ catch-all
  rollback + `SP_Page_DDL_Log` failure entry (guarded by FK) + `THROW`.
- Dry-run (`@DryRun=1`) executes everything then rolls back — the script's own
  output SELECTs show the would-be state.

## 12. Examples and limitations

- `examples/01-frais-km-input.yaml`: input that reproduces the repo's official
  `002_SP_Designer_Exemple_FKM.sql` (use it as oracle).
- `examples/02-teletravail/`: complete worked package (input + deploy +
  rollback + preflight).

Known limitations:
- The workflow **signature circuit** (`Workflow_Signatures*`) is not generated;
  configure it post-deploy (pattern: `004_FKM_Workflow_Signature.sql`).
- No feature flags (no such RHP mechanism); use `Statut_Page`.
- Socle tables (`Controle_Profile`, `Controle_Def_Zoom`, …) have no DDL in the
  repo — their existence/shape is asserted by preflight, not by generation.
- Layout is flow-based (12-col grid); there is no pixel/absolute positioning.
- `Act_Exporter` is metadata-only in the current frontend (verified).
- `Figer_Statuts` / `Zoom_Condition` (SP4) and `Recalc_Save` (base 001) are
  **not editable in the Desktop Designer** (verified absence in
  `SP_Page_Designer.vb`) — deployment scripts write them directly. Caveat on
  Designer re-save (`Saving`): `SP_Page` is updated with a fixed column list
  (no `Figer_Statuts`) so it is **preserved**; but `SP_Page_Champ` is rebuilt
  by DELETE+INSERT **without `Zoom_Condition`/`Recalc_Save`** — a Designer
  re-save **resets them** (`NULL` / `'true'`): re-apply the deployment script
  afterwards. (`SP_Page_Table` DELETE+INSERT does include
  `Source_Metier/_Mapping`: virtual details survive Designer re-saves.)
- The Desktop Designer has no assistant for the mapping json of a SOURCE field
  (grid-typed only) — the generator must emit the exact
  `{"source":…,"mapping":{…}}` shape (`references/sources-metier.md` §5).
- Validation rules of type `SOURCE` are not covered by the Desktop assistant
  either — emit the exact json of `references/sources-metier.md` §7.
