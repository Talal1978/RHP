# RHP Portal Page Deployer — Skill Package (JSON import)

Generate, from a precise functional description, a **JSON file importable in
the RHP Page Designer** (`SP_Page_Designer` → « Importer JSON », format
`RHP_PAGE_DESIGNER` 1.0) for portal pages of the **Page Designer module
(SP_)**.

The skill writes **no SQL, never touches a database, and produces exactly one
file — the importable JSON** (no manifest, no input copy: token-efficient by
design; the reporting lives in the chat response): the import only fills the
Designer's grids, and the actual write remains a human action in the
Designer — « Enregistrer » (checks + transaction + non-destructive DDL),
then « Publier ».

## Layout

```
rhp-portal-page-deployer/
├── SKILL.md                              # skill definition (start here)
├── README.md                             # this file
├── references/
│   ├── json-import-format.md             # exact output contract (mirror of
│   │                                     # Module_SP_Page_Json.vb) + never-imported features
│   ├── schema-mapping.md                 # verified concept -> RHP object mapping
│   ├── sp-metadata-model.md              # Controle_Designer* columns, DDL rules of Saving,
│   │                                     # publication
│   ├── formules-calculees.md             # formula logic: AST, 43 ops, GV_*, graph/cycles
│   ├── comportement-page.md              # states, dynamic rules, 13 validation types,
│   │                                     # lifecycle, rights, list behavior
│   ├── sources-metier.md                 # source catalog, read-only guard, parameters,
│   │                                     # 3 usages (SOURCE field / virtual grid / validation)
│   ├── environment-discovery.md          # discovery procedure + schema levels (SP1..SP4)
│   └── testing-acceptance-checklist.md   # test & acceptance checklist (import mode)
├── templates/
│   ├── input-template.yaml               # annotated input contract
│   └── page-template.json                # annotated skeleton of the generated file
├── scripts/
│   └── validate_input.py                 # blocking-rule validator (stdlib only)
└── examples/
    ├── 01-frais-km/                      # input oracle of the official FKM page
    │   ├── input.yaml                    #   (contract illustration - never a
    │   │                                 #   deliverable) + the expected JSON
    │   └── RHP_Page_FRAIS_KM.json
    └── 02-teletravail/                   # complete worked example
        ├── input.yaml                    #   (contract illustration - never a
        │                                 #   deliverable)
        └── RHP_Page_TELETRAVAIL.json
```

## Usage (with Claude)

1. Describe the page functionally (or paste a filled `input-template.yaml`).
2. Claude converts it to the canonical input **in memory** (never persisted),
   classifies facts (verified / assumption / missing) and validates it:
   ```bash
   cat <canonical-input.json> | python scripts/validate_input.py -
   ```
   Any `errors` entry is blocking: no JSON is produced.
3. Claude generates **one single file**: `RHP_Page_<page_code>.json`, then
   answers in chat with the fact classification, the expected import warnings
   and the manual post-import steps.
4. A human reviews the response, then in the Desktop Designer:
   « Importer JSON » → preview (mode, diff, warnings) → « Valider » →
   « Enregistrer » → Habilitations tab → « Publier ».
5. Verify with `references/testing-acceptance-checklist.md`.

## Guarantees

- **Safe**: the generated file must pass every blocking rule of the product
  importer (mirrored by `validate_input.py`); a blocking anomaly leaves the
  Designer screen strictly unchanged; `Saving` runs in a single transaction.
- **Auditable**: fact classification and expected import warnings in the
  final response, import trace + `Controle_Designer_DDL_Log` written by the
  Designer itself.
- **Non-destructive**: metadata collections synchronized by the Designer;
  business DDL is ADD-only; business tables are never dropped.
- **Rights-safe**: permissions are never in the file
  (`metadata.habilitations="EXCLUES"`); existing rights preserved on update.
- **Deterministic**: fixed section order, derived physical names — same
  input ⇒ functionally equivalent JSON.

## Ground truth

Everything maps to verified repository objects only
(see `references/json-import-format.md` and `references/schema-mapping.md`
for evidence paths/lines):
`RHP_DeskTop\RHP\Portail\Module_SP_Page_Json.vb`, `SP_Page_Designer.vb`,
`Module_SP_DDL.vb`, the `Zoom_SP_*` screens,
`RHP_Portail\rhpBE\sql\SP_Designer\001..006*.sql`,
`RHP_Portail\rhpBE\modules\module_sp_engine.ts`, `controlers\sp_document.ts`,
`RHP_Portail\rhpfe\src\Pages\Dynamic\*` (client engine mirror).
