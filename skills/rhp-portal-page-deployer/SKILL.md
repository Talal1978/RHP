---
name: rhp-portal-page-deployer
description: >
  Transforme une description fonctionnelle precise d'une page portail RHP en un
  fichier JSON importable dans le Designer de pages RHP (SP_Page_Designer,
  bouton 'Importer JSON', format RHP_PAGE_DESIGNER 1.0) : structure SQL logique,
  champs, validations, sources metier, rattachement a une section du menu.
  L'ecriture en base reste assuree par le Designer lui-meme (Enregistrer puis
  Publier) — le skill ne produit aucun script SQL. A utiliser quand on demande
  la creation ou la mise a jour d'une page du Designer de pages portail RHP
  (module SP_), ou la generation du JSON d'import correspondant.
---

# RHP Portal Page Deployer (JSON import)

## 1. Purpose

Generate a **production-ready JSON import file** that creates or updates a
portal page in the **RHP Portal Page Designer module (SP_)**, loadable via the
**"Importer JSON"** button of the Desktop screen `SP_Page_Designer` (format
`RHP_PAGE_DESIGNER` 1.0 — exact contract: `references/json-import-format.md`).

Fundamental principle (mirrored from the product): the JSON describes the full
page configuration **EXCEPT permissions**; importing it only fills the
Designer's controls and grids — **nothing is written to the database at load
time**. The actual write remains the user's action through the Designer:
**"Enregistrer"** (`Saving`: full checks, single transaction, non-destructive
DDL generation/migration via `Module_SP_DDL`), then **"Publier"**.

The skill **generates a file; it never touches a database**. Review, import
and publication remain human actions in the Designer.

## 2. Trigger conditions

Use this skill when the user asks to:
- create a new RHP portal page from a functional description;
- update an existing SP_ page (only with explicit update authorization);
- produce or review an SP_ page configuration file for the Designer.

Do NOT use it for: disabling/unpublishing a page (use the Designer's
"Désactiver" button), hardcoded (non-SP_) portal screens, desktop WinForms
screens, dashboard widgets, surveys, or any schema change outside the SP_
module.

## 3. Required context and reference files

| File | Load when |
|---|---|
| `references/json-import-format.md` | **Always first** — exact output contract (DTOs, import validation rules, import/save semantics, never-imported features) |
| `references/schema-mapping.md` | Verified concept→object mapping + conventions |
| `references/sp-metadata-model.md` | Metadata columns, DDL rules applied by `Saving`, publication preconditions |
| `references/formules-calculees.md` | Any `calculated` field, `EXPR` validation or aggregate — AST, 43 whitelisted ops, GV_* variables, dependency cycles |
| `references/comportement-page.md` | Field states, the 13 validation types with exact `Parametres` json, scopes/levels/moments, document lifecycle, detail-grid flags, rights & FAB actions, list criteria |
| `references/sources-metier.md` | Any `data_sources` entry, `source` field, virtual detail grid, `SOURCE` validation — catalog, read-only guard, parameters, the 3 usages |
| `references/environment-discovery.md` | Dependencies uncertain / new environment (section codes, zooms, rubriques, sources, profiles, print model) |
| `templates/input-template.yaml` | Building or completing an input |
| `templates/page-template.json` | Generating the output file |
| `references/testing-acceptance-checklist.md` | Finalizing the package (manifest section) |
| `examples/` | Worked inputs/outputs |

Repository ground truth (read-only): `RHP_DeskTop\RHP\Portail\Module_SP_Page_Json.vb`
(the import/export contract itself), `SP_Page_Designer.vb` (`ImporterJson`,
`AppliquerImport`, `Saving`, `Publier`), `Module_SP_DDL.vb`,
`Zoom_SP_Nouvelle_Section.vb`, `Zoom_SP_Assistant_Formule.vb`,
`Zoom_SP_Assistant_Validation.vb`, `Zoom_SP_Assistant_ParamSource.vb`,
`Zoom_SP_MappingSource.vb`, `Zoom_SP_SqlSource.vb`,
`RHP_Portail\rhpBE\sql\SP_Designer\*.sql` (001 metadata, 002 FKM oracle, 003
critères, 005 Total_Grille removal, 006 évolutions SP4),
`RHP_Portail\rhpBE\modules\module_sp_engine.ts`, `controlers\sp_document.ts`,
`RHP_Portail\rhpfe\src\Pages\Dynamic\*.tsx/ts`.

## 4. Input contract

YAML or JSON. Natural-language requests must first be converted into this
structure and validated — never generate the JSON directly from prose.
Full annotated contract: `templates/input-template.yaml`. Fixed skeleton:

- `request`: `operation` (**create|update** only — `disable` is not expressible
  via JSON), `environment`, `requested_by`, `change_reference`
  (`dry_run` accepted for compatibility, ignored: an import never writes by
  itself).
- `page`: `page_code` (→`Cod_Page`), `document_code` (→`Cod_Document`),
  `title` (→`Nom_Page`), `target_section_code` (→`Menu_Parent`),
  `display_order` (→`Rang`), `icon`, `layout_type` (hint only), `actions`,
  `print_model`, `attachments.enabled/required`, `workflow.enabled`, `enabled`
  (true ⇒ the manifest includes the manual "Publier" step), plus
  `create_section_if_missing` (⇒ manual pre-import step, never automated).
  `page_name`/`short_title` are manifest-only (the Designer persists
  `Libelle = Nom_Page`).
- `components`: fields/blocks. `component_type` ∈ whitelist
  (`text,memo,integer,decimal,money,date,datetime,checkbox,radio,combo,
  reference_list,zoom,calculated,source,attachments,detail_grid`) → verified
  `Typ_Controle` values. Layout = 12-col flow grid (`row/column/width/
  display_order` → `Ligne/Colonne/Largeur/Rang`). `calculated` formulas follow
  `references/formules-calculees.md`; a `detail_grid` with `data_source_code`
  is a **virtual detail** fed by a TABLE source (→`Source_Metier`/
  `Source_Mapping`, SP4 — see `references/sources-metier.md` §6).
- `page_validations` / component `validations`: → `validations[]`
  (13 verified `Typ_Regle` with exact `Parametres` json per type — see
  `references/comportement-page.md` §3).
- `data_sources`: → `businessSources[]` (read-only catalog, upserted by
  `Saving`; full parameter/execution model in `references/sources-metier.md`).
- `access_control`: `default_policy` deny|open_read → `Acces_Personnalise`
  (applied **at creation only**); `roles[].permissions` are **never in the
  file** — they become a manual step of the manifest (Habilitations tab).
  RHP has **no separate export right** — export maps to `Imprimer`.
- `deployment`: `update_if_exists` (explicit authorization to modify an
  existing page), `expected_schema_version` (SP1|SP2|SP3|SP4 — SP4 required
  for virtual detail grids).

**Keys with no JSON target are blocking errors, never silently dropped** —
full list in §6 and in `references/json-import-format.md` §8: `freeze_statuses`,
`zoom_condition`, `zoom_return`, `visibility_rule`/`activation_rule`,
`grid_total` (column dropped by migration 005 — use a footer calculated
field), `recalc_save: false`, `attachments.categories`, `operation: disable`.

## 5. Analysis workflow

1. **Restate** the request as the canonical input (fill `input-template.yaml`).
2. **Classify every fact**: `verified` (in repo sources) / `assumption`
   (reasonable default, listed in the manifest) / `missing` (blocks — see §6).
3. **Check the environment** via `references/environment-discovery.md`:
   schema level, section codes, zooms, rubriques, sources, profiles, print
   model, workflow proc. Without DB access, list the dependencies in the
   manifest as expected import warnings (the import itself re-checks them
   against the target base and reports them as *avertissements*).
4. **Validate**: run `scripts/validate_input.py <canonical.json>`
   (stdlib only; YAML must be converted to JSON first). All errors are blocking.
5. Only then generate the JSON (§7).

## 6. Blocking validation rules (STOP — no JSON output)

Hard stops (full list enforced by `validate_input.py`):
- `operation=disable` (not expressible via JSON — Designer "Désactiver"
  button); `operation=update` without `update_if_exists=true`.
- Missing/invalid `page_code` (`^[A-Za-z_][A-Za-z0-9_]{2,29}$`, not `Page*`),
  `document_code` (`^[A-Za-z][A-Za-z0-9]{1,9}$` — import regex), `title`,
  `target_section_code`.
- Unknown `component_type`; layout `width` outside 1..12; non-null `height`.
- `radio`/`reference_list` without `rubrique`; `zoom`/`combo` without `zoom`;
  `calculated` without `formula`; `source` without `data_source_code`;
  `attachments` field without `page.attachments.enabled`.
- **No-JSON-target keys with non-neutral values** (the import format cannot
  carry them — `references/json-import-format.md` §8): non-empty
  `freeze_statuses`, `zoom_condition`, `zoom_return`, any
  `visibility_rule`/`activation_rule`, non-empty `grid_total` (dropped column —
  emit a `Pied_*` footer calculated field instead), `recalc_save: false`,
  non-empty `attachments.categories`.
- A stored field with `column_name` explicitly empty (only
  `calculated`/`source` non-persisted and `attachments` may have no physical
  column); `persist: true` without a column name; a technical column name
  (`RowId`, `Num_Doc`, `id_Societe`, `Statut`, `Dat_Crea`, `Created_By`,
  `Dat_Modif`, `Modified_By`, `RV`) used as `column_name`.
- Formula AST: non-whitelisted op, unknown `ref` (GV_* accepted), unknown
  aggregate target, cycle between calculated fields (mirror of
  `DetecterCycle`).
- Virtual detail (`detail_grid` with `data_source_code`) with a source not
  `return_type: table`, with a mapping referencing non-header fields, or
  leaving a required source parameter unfed (mirror of
  `VerifierTableVirtuelle`, re-run by the import).
- Duplicate `component_code`, `(block,column)`, validation code, source code,
  role code.
- Data source failing the read-only guard (as re-run by the engine —
  `references/sources-metier.md` §2), declaring `@id_Societe`, or with
  write `allowed_operations`.
- `default_policy=deny` with no `view:true` role (page would be invisible —
  mirrors the RHP publication check).
- `actions.submit` without `workflow.enabled`; `actions.print` without
  `print_model`.
- Contradiction between discovery results and this skill's references.

Missing-info handling: output a **MISSING INFO** report (one line per item:
what is needed, why, which input key carries it) and stop.

## 7. JSON-generation workflow

Assemble `templates/page-template.json` in fixed section order (deterministic
output: same input ⇒ functionally equivalent JSON). Serialization: indented
json, **null properties omitted**, true json booleans, UTF-8 without BOM.

1. **Envelope**: `format="RHP_PAGE_DESIGNER"`, `version="1.0"`,
   `exportedAt`=generation date (`yyyy-MM-ddTHH:mm:ss`),
   `exportedBy`=`request.requested_by`. Omit `rhpVersion`.
2. **`page`**: `Cod_Page`, `Cod_Document`, `Nom_Page`=`title`, `Menu_Parent`,
   `Rang` (default 99), `Icone`, `Acces_Personnalise`
   (`deny`→true, `open_read`→false), `Workflow_Actif`, `Cod_Modele_Edition`,
   `GED_Actif`, `GED_Obligatoire`, `Act_Enregistrer/_Soumettre/_Imprimer/
   _Exporter` (defaults true/true/false/false). Omit `Statut_Page`/`Table_Ent`
   (indicative only, never re-imported / recomputed).
3. **`sqlStructure`**: the synthetic header table first —
   `{Cod_Table:"ENT", Role_Table:"ENT", Libelle:"Entête", Rang:0,
   Allow_Add/Edit/Delete/Duplicate:false, Regle_Suppression:"CASCADE"}` —
   then one table per `detail_grid` (`Rang`=`display_order`, flags from
   `allow_*`, `Tri_Defaut`=`default_sort`, `Regle_Suppression`; a **virtual**
   grid gets `Source_Metier`/`Source_Mapping` and forced `Allow_*:false`).
   Omit `Nom_Physique` (recomputed by the import).
4. **`colonnes`** (inside each table): one entry per **stored** component of
   the block — every component except `calculated`/`source` with
   `persist:false`, except `attachments` (GED: never stored), and except an
   explicitly empty `column_name`. `Nom_Colonne`=`column_name`‖`component_code`,
   `Libelle`=`label`, `Typ_Sql`=`properties.sql_type` else the type default
   (`text`→nvarchar(50), `memo`→nvarchar(max ⇒ `Longueur:-1`),
   `integer`→int, `decimal`/`money`→decimal(18,2), `date`→date,
   `datetime`→datetime, `checkbox`→bit, `radio`/`reference_list`/`zoom`/`combo`
   →nvarchar(50), persisted `calculated`→decimal(18,2), persisted
   `source`→nvarchar(100) — explicit `sql_type` strongly recommended),
   `Longueur/Precision_Sql/Echelle_Sql` when relevant, `Nullable`
   (`properties.nullable`, default true), `Valeur_Defaut`, `estUnique`,
   `estIndexe`, `Rang`=order of the component within its block. A **virtual**
   detail declares its logical source columns the same way (the import
   requires ≥1 column per table; no DDL is generated for it).
5. **`components`**: one field per non-`detail_grid` component: `Cod_Champ`,
   `Cod_Table` (`ENT` or block code), `Nom_Colonne` (`""` when not stored),
   `Libelle`, `Typ_Controle` (whitelist mapping), `Rang`=`display_order`
   (default = list position), `Ligne`/`Colonne`/`Largeur` from layout
   (`Largeur` default from `layout_type`: standard 3, wide 6, compact 2),
   `Valeur_Defaut`, `Obligatoire`=`required`, `Etat` from
   `visible`/`editable` (`S`/`R`/`A`/`I`; a `CALCULE`/`SOURCE` never editable
   ⇒ `A` when visible, mirroring `Saving`), `Rubrique`, `Num_Zoom`,
   `Source_Metier` (=`data_source_code`), `Formule` (AST json for
   `calculated`; `{"source":…,"mapping":{…}}` for `source` — both must name
   the same source), `Persiste`, `Format_Affichage`, `Decimales`,
   `Visible_Grille`, `Rang_Grille`, `Largeur_Colonne`, `estCritere`,
   `Rang_Critere`, `Aide`.
6. **`validations`**: `page_validations` then component-level `validations`
   (implicit scope: `CHAMP` for ENT fields, `LIGNE` for grid children),
   `Rang` = global emission order, defaults `Niveau:"B"`, `Moment:"SAVE"`,
   `Actif:true`; `Parametres`/`Condition_Regle` serialized json.
7. **`businessSources`**: every `data_sources` entry **referenced** by the
   page (source field, virtual detail, `SOURCE` validation) — `Parametres`
   serialized `[{"Nom":…,"Typ":…,"Obligatoire":…}]`, defaults
   `Typ_Source:"SQL"`, `Typ_Retour:"SCALAIRE"`, `Actif:true`.
8. **`metadata`**: `habilitations:"EXCLUES"` + the 5 counters
   (`nbTables/nbColonnes/nbChamps/nbSources/nbValidations`).

Also generate the **manifest** (§8). Physical names are never written:
`Nom_Physique`/`Table_Ent` are recomputed by the Designer from
`Cod_Document`; the DDL itself is produced by `Saving` (`Module_SP_DDL`
format, `references/sp-metadata-model.md` §9) — never by the skill.

## 8. Output format

A directory `NNN_<page_code>/` (NNN = sequence or change ref) containing:

| File | Content |
|---|---|
| `input.yaml` (or `.json`) | The validated canonical input |
| `RHP_Page_<page_code>.json` | The importable file (RHP_PAGE_DESIGNER 1.0) |
| `manifest.md` | Facts/assumptions/missing-info classification; mapping decisions; **expected import warnings** (dependencies not verifiable offline); **manual post-import steps** (below); checklist from `references/testing-acceptance-checklist.md` |

Response to the user: package path + the classification summary + explicit
statement of anything the JSON cannot deploy (habilitations, section creation,
publication, workflow circuit…).

## 9. Security constraints (non-negotiable)

- Never invent tables/columns/procs/component types — verified objects only
  (`references/schema-mapping.md`, `references/json-import-format.md`).
- The generated file must pass **every blocking rule of the product importer**
  (`Module_SP_Page_Json.Valider`) — the generator mirrors them and
  `validate_input.py` enforces them upstream.
- Identifiers only from validated input; reserved-word blacklist; technical
  columns never declared (auto-added by the DDL).
- Sources: single read-only statement (server guard mirrored at validation);
  never declare `@id_Societe`.
- Permissions are never automated: the file carries no rights
  (`metadata.habilitations="EXCLUES"`); existing rights are preserved on
  update; `Acces_Personnalise` applies at creation only.
- Never modify an existing page without `update_if_exists=true`
  (the import would switch to update mode — the authorization must be
  explicit upstream).
- Business data is never inserted; no secrets in files; `exportedBy` =
  `requested_by`.
- The skill writes **no SQL and touches no database** — ever.

## 10. Post-import manual steps (manifest section)

The JSON never performs these — list them explicitly in the manifest:
1. If `create_section_if_missing` and the section is absent: create it via
   `Zoom_SP_Nouvelle_Section` (or the rubriques screen) **before** saving.
2. `SP_Page_Designer` → "Importer JSON" → select the file → review the
   preview (mode create/update, diff, warnings) → "Valider".
3. Fix the warnings (missing menu section, zoom, rubrique, print model,
   profile…), review the loaded configuration.
4. "Enregistrer" (`Saving`: checks + transaction + non-destructive DDL).
5. Habilitations tab: grant the roles of `access_control.roles`
   (creation only — preserved on update).
6. If `page.enabled=true`: "Publier" (publication preconditions re-checked).
7. If `workflow.enabled`: configure the signature circuit
   (`Workflow_Signatures` screens — never generated).
8. Rejected-at-validation features (§6) have **no** post-import path via this
   skill; if one is truly required, it needs a targeted SQL UPDATE outside
   the Designer (document it as an explicit exception — `Figer_Statuts` and
   `GED_Categories` survive re-saves; `Zoom_Condition`/`Recalc_Save`/
   `Zoom_Retour`/`Regle_Visibilite`/`Regle_Activation` are reset by every
   `Saving`).

Rollback in JSON mode: before "Enregistrer" → just close without saving;
after save on a draft → delete the `BROUILLON` page in the Designer (metadata
only, business tables never dropped); after publication → "Désactiver".

## 11. Error handling

- Validation errors → stop, list all errors with input paths (no partial JSON).
- Discovery contradictions → stop, report discrepancy.
- The generated file is itself guarded by the product importer: any blocking
  anomaly leaves the Designer screen strictly unchanged (atomicity), and
  `Saving` re-runs every control inside a single transaction.

## 12. Examples and limitations

- `examples/01-frais-km/`: input that reproduces the repo's official
  `002_SP_Designer_Exemple_FKM.sql` page definition, plus the expected
  generated JSON (use both as oracle — the generated file must encode the
  same metadata).
- `examples/02-teletravail/`: complete worked package (input + generated JSON
  + manifest).

Known limitations:
- `operation: disable` is not expressible via JSON (Designer "Désactiver").
- Update mode is auto-detected by the importer (`Cod_Page` exists); the skill
  still requires the explicit `update_if_exists=true` authorization upstream.
- The workflow **signature circuit** (`Workflow_Signatures*`) is not generated;
  configure it post-publication (pattern: `004_FKM_Workflow_Signature.sql`).
- Menu section creation is manual (`Zoom_SP_Nouvelle_Section`).
- Features without a JSON target (`references/json-import-format.md` §8) are
  rejected at validation: `Figer_Statuts`, `Zoom_Condition`, `Zoom_Retour`,
  `Regle_Visibilite`/`Regle_Activation`, `Recalc_Save` (non-default),
  `GED_Categories`, `Total_Grille` (dropped by migration 005 — footer
  calculated field instead).
- Socle tables (`Controle_Profile`, `Controle_Def_Zoom`, …) have no DDL in the
  repo — referenced objects are asserted by discovery + import warnings.
- Layout is flow-based (12-col grid); there is no pixel/absolute positioning.
- `Act_Exporter` is metadata-only in the current frontend (verified).
- Frontend `menus.json`: nothing to do (dynamic merge at runtime).
