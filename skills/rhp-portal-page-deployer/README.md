# RHP Portal Page Deployer — Skill Package

Generate **safe, auditable, idempotent, reversible** SQL Server deployment
packages for portal pages of the RHP **Page Designer module (SP_)**, from a
precise functional description.

## Layout

```
rhp-portal-page-deployer/
├── SKILL.md                              # skill definition (start here)
├── README.md                             # this file
├── references/
│   ├── schema-mapping.md                 # verified concept -> RHP object mapping
│   ├── sp-metadata-model.md              # SP_Page* columns, DDL rules, publication
│   ├── formules-calculees.md             # formula logic: AST, 43 ops, GV_*, graph/cycles
│   ├── comportement-page.md              # states, dynamic rules, 13 validation types,
│   │                                     # lifecycle, rights, list behavior
│   ├── sources-metier.md                 # source catalog, read-only guard, parameters,
│   │                                     # 3 usages (SOURCE field / virtual grid / validation)
│   ├── environment-discovery.md          # discovery procedure + schema levels (SP1..SP4)
│   └── testing-acceptance-checklist.md   # test & acceptance checklist
├── templates/
│   ├── input-template.yaml               # annotated input contract
│   ├── deploy-template.sql               # deployment skeleton (placeholders {{...}})
│   ├── rollback-template.sql             # rollback skeleton
│   └── preflight-template.sql            # read-only pre-deployment checks
├── scripts/
│   └── validate_input.py                 # blocking-rule validator (stdlib only)
└── examples/
    ├── 01-frais-km-input.yaml            # reproduces the official FKM example
    └── 02-teletravail/                   # complete worked package
```

## Usage (with Claude)

1. Describe the page functionally (or drop a filled `input-template.yaml`).
2. Claude converts it to the canonical input, classifies facts
   (verified / assumption / missing) and validates it:
   ```bash
   python scripts/validate_input.py <canonical-input.json>
   ```
   Any `errors` entry is blocking: no SQL is produced.
3. Claude generates the package `NNN_<page_code>/`:
   `input.yaml`, `preflight.sql`, `deploy.sql`, `rollback.sql`, `manifest.md`.
4. A human reviews, runs `preflight.sql` (every `KO` is blocking), then runs
   `deploy.sql` — first with `@DryRun = 1` (default; full rollback), then with
   `@DryRun = 0` to actually deploy.
5. Verify with the checklist in `manifest.md`
   (`references/testing-acceptance-checklist.md`).

## Execution (DBA)

```bash
sqlcmd -S .\SQL2019 -d RHP -i preflight.sql -o preflight.out.txt
sqlcmd -S .\SQL2019 -d RHP -i deploy.sql    -o deploy.dryrun.out.txt   REM @DryRun=1
sqlcmd -S .\SQL2019 -d RHP -i deploy.sql    -o deploy.out.txt          REM @DryRun=0
```

## Guarantees

- **Safe**: identifier whitelist, read-only sources, no `DROP`/`TRUNCATE`/
  uncontrolled `DELETE`, single transaction with full rollback on error.
- **Auditable**: provenance header, `SP_Page_DDL_Log` entries, manifest with
  fact classification, pre/post verification output.
- **Idempotent**: every statement guarded; re-running converges to the same state.
- **Reversible**: `rollback.sql` (deactivation always; metadata removal guarded;
  business tables never dropped — official RHP rule).
- **Deterministic**: fixed section order, `Rang`-ordered inserts, derived
  physical names — same input ⇒ functionally equivalent SQL.

## Ground truth

Everything maps to verified repository objects only
(see `references/schema-mapping.md` for evidence paths/lines):
`RHP_Portail\rhpBE\sql\SP_Designer\001..006*.sql`,
`RHP_DeskTop\RHP\Portail\Module_SP_DDL.vb`, `SP_Page_Designer.vb` and the
`Zoom_SP_Assistant_*` / `Zoom_SP_SqlSource` / `Zoom_SP_MappingSource` screens,
`RHP_Portail\rhpBE\modules\module_sp_engine.ts`, `controlers\sp_document.ts`,
`RHP_Portail\rhpfe\src\Pages\Dynamic\*` (client engine mirror).
