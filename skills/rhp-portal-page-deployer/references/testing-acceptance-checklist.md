# Testing & Acceptance Checklist (JSON import mode)

Copy the relevant section into the generated `manifest.md` and check every box
before/after import. Any failed item is blocking for acceptance.

## 1. Pre-generation (input)

- [ ] Input validated by `scripts/validate_input.py` → `status: "ok"`.
- [ ] Every functional fact classified: verified / assumption / missing = none.
- [ ] `operation` and `deployment.update_if_exists` consistent with the target
      environment state (page exists or not).
- [ ] `change_reference` and `requested_by` filled (audit trail).
- [ ] No `[NO-JSON-TARGET]` key with a non-neutral value (validator enforces).

## 2. Generated file (before opening the Designer)

- [ ] `RHP_Page_<code>.json` parses; `format="RHP_PAGE_DESIGNER"`,
      `version="1.0"`.
- [ ] `metadata` counters match the actual collections
      (nbTables/nbColonnes/nbChamps/nbSources/nbValidations).
- [ ] `metadata.habilitations = "EXCLUES"` (no rights in the file — ever).
- [ ] Dependencies listed in the manifest (section, icon, zooms, rubriques,
      sources, profiles, print model, workflow proc) verified present in the
      target base, or listed as expected import warnings.
- [ ] If `create_section_if_missing=true`: the section has been created via
      `Zoom_SP_Nouvelle_Section` (or the rubriques screen).

## 3. Import in the Designer (no DB write at this stage)

- [ ] `SP_Page_Designer` → « Importer JSON » → the file passes analysis with
      **no blocking anomaly** (the screen stays unchanged otherwise).
- [ ] Preview shows the expected mode: NOUVELLE PAGE / MISE À JOUR
      (`Cod_Page`); for an update, the diff matches the intended changes and
      the mention « droits existants préservés » appears.
- [ ] Preview counters match the manifest (tables / colonnes / champs /
      sources / validations).
- [ ] Every preview warning is understood and assigned: fix in the Designer
      before saving, or explicitly accepted.
- [ ] « Valider » loads the configuration; visual review of the tabs
      (Conception, Structure, Champs, Validations, Sources).

## 4. Enregistrer (Saving — transaction + DDL)

- [ ] « Enregistré avec succès » without error; DDL messages reviewed
      (`Aperçu DDL` if needed).
- [ ] Business tables created/migrated: ENT (`Num_Doc, id_Societe, Statut,
      RV` + audit), DET (`RowId`), PKs, `FK_<det>_Ent`, indexes — **ADD only**,
      nothing dropped; no table for virtual details.
- [ ] `Controle_Designer_DDL_Log` contains the CREATE/MIGRATE success entry.
- [ ] Habilitations tab: roles of `access_control.roles` granted (creation —
      preserved on update); at least one `Consulter` if
      `Acces_Personnalise` (publication precondition).

## 5. Publication (if `page.enabled=true`)

- [ ] « Publier » succeeds (preconditions re-checked: columns, zooms,
      rubriques, sources, no calculated cycle, rights, `Menu_Parent`).
- [ ] `Statut_Page='PUBLIE'`, `Version_Page` incremented (update),
      `Dat_Publication` set.
- [ ] `Controle_Def_Ecran` row `SPP_<page_code>` with correct `Table_Ref`,
      `PJ` = `GED_Actif`.
- [ ] If workflow: `Param_Workflow_Typ_Document` row for the document code;
      signature circuit configured separately (`Workflow_Signatures`).

## 6. Portal acceptance (runtime smoke test)

- [ ] Re-login (menu cache) → `GET /api/sp_menu_portail` contains
      `SPPL_<page_code>` under the target section, for an authorized profile only.
- [ ] List page opens: `/myspace/SPPL_<page_code>/<titre>`; criteria render in
      `Rang_Critere` order; `Nouveau` enabled only with `Creer`.
- [ ] `POST /api/sp_page_meta` returns `droits` matching the granted roles.
- [ ] Document page: create → save (`sp_save_document`) ⇒ `Num_Doc` pattern
      `<doc><societe>-<yyyy><seq>`; blocking validations fire (level `B`).
- [ ] Calculated fields compute; grid footer totals render; zoom/rubrique/
      source fields resolve; virtual grids load read-only lines.
- [ ] If workflow: submit (`statut='SS'`) ⇒ signature circuit triggered.
- [ ] Row-level scoping: a non-TeamLeader, non-admin agent sees only own
      documents (when a `Matricule` column exists).

## 7. Rollback path

- [ ] Before « Enregistrer »: close without saving — nothing persisted.
- [ ] Draft saved by mistake: delete the `BROUILLON` page in the Designer
      (metadata only; business tables never dropped).
- [ ] Published page: « Désactiver » (leaves the portal, documents preserved).

## 8. Production extra (when `environment: production`)

- [ ] Database backup taken immediately before saving (RHP install rule).
- [ ] Change window + maintenance communication done.
- [ ] Import preview + manifest reviewed by a second person (4-eyes rule).
