# Environment Discovery & Verification Procedure

The repository fully documents the **SP_ module schema** (see
`schema-mapping.md`), but the DDL of several **socle (base) tables** is not in
the repo — they exist only in the `RHP` database. Before generating the JSON
import file, verify the target environment with the procedure below, so the
file imports **without warnings**.

Note: every dependency the file references (menu section, icon, zoom,
rubrique, business source, profile, print model) is **re-checked by the
product importer** against the target base and reported as an *avertissement*
in the preview (`Module_SP_Page_Json.Valider`) — the manifest must list the
expected ones. Discovery upstream avoids surprises.

**Rule:** if a discovery result contradicts this reference, **STOP** — do not
generate the JSON. Report the discrepancy as *missing/conflicting information*.

---

## 1. Schema levels (for `deployment.expected_schema_version`)

Derived from the official migration scripts:

| Level | Meaning | Assertions |
|---|---|---|
| `SP1` | Base metadata installed | Tables `Controle_Designer, Controle_Designer_Droit, Controle_Designer_Table, Controle_Designer_Colonne, Controle_Designer_Champ, Controle_Designer_Validation, Controle_Designer_Source, Controle_Designer_DDL_Log` exist |
| `SP2` | SP1 + migration 1.1.b/1.1.c | `Controle_Designer.Acces_Personnalise` exists; `Controle_Designer.Typ_Document` is `nvarchar(10)`; `Param_Workflow_Typ_Document.Typ_Document` is `nvarchar(10)` |
| `SP3` | SP2 + migration 003 | `Controle_Designer_Champ.estCritere` and `Controle_Designer_Champ.Rang_Critere` exist |
| `SP4` | SP3 + migrations 005/006 (current repo state) | `Controle_Designer.Figer_Statuts`, `Controle_Designer_Champ.Zoom_Condition`, `Controle_Designer_Table.Source_Metier` and `Controle_Designer_Table.Source_Mapping` exist (005 **drops** `Total_Grille`). Required when the input uses a **virtual detail grid** — the only SP4 feature the JSON format carries |

## 2. Parameterized discovery template

Run with sqlcmd (adapt `-S`/`-d`) or in SSMS. Every query is read-only.

```sql
:setvar CodPage "FRAIS_KM"
:setvar CodDocument "FKM"
/* -- A. SP_ schema level -------------------------------------------------- */
SELECT t.name AS table_name
FROM sys.tables t
WHERE t.name IN ('Controle_Designer','Controle_Designer_Droit','Controle_Designer_Table','Controle_Designer_Colonne',
                 'Controle_Designer_Champ','Controle_Designer_Validation','Controle_Designer_Source','Controle_Designer_DDL_Log')
ORDER BY t.name;                                    -- expect 8 rows  (SP1)

SELECT c.name AS column_name, c.max_length
FROM sys.columns c
WHERE c.object_id = OBJECT_ID('dbo.Controle_Designer')
  AND c.name IN ('Acces_Personnalise','Typ_Document');  -- Acces_Personnalise present (SP2)
                                                        -- Typ_Document max_length = 20 (nvarchar(10))

SELECT c.name FROM sys.columns c
WHERE c.object_id = OBJECT_ID('dbo.Controle_Designer_Champ')
  AND c.name IN ('estCritere','Rang_Critere');      -- expect 2 rows (SP3)

SELECT c.object_id, c.name FROM sys.columns c
WHERE (c.object_id = OBJECT_ID('dbo.Controle_Designer')       AND c.name = 'Figer_Statuts')
   OR (c.object_id = OBJECT_ID('dbo.Controle_Designer_Champ') AND c.name = 'Zoom_Condition')
   OR (c.object_id = OBJECT_ID('dbo.Controle_Designer_Table') AND c.name IN ('Source_Metier','Source_Mapping'))
ORDER BY c.object_id, c.name;                     -- expect 4 rows (SP4)
-- 005 drops Controle_Designer_Champ.Total_Grille : its PRESENCE means 005
-- was not applied (footer totals must then be migrated) - check separately :
SELECT COL_LENGTH('dbo.Controle_Designer_Champ','Total_Grille') AS Total_Grille_present;  -- expect NULL

/* -- B. Socle objects the deployment touches ------------------------------ */
SELECT t.name FROM sys.tables t
WHERE t.name IN ('Param_Rubriques','Controle_Def_Ecran','Controle_Def_Zoom',
                 'Controle_Profile','Controle_Users','Param_Mod_Edition',
                 'Param_Workflow_Typ_Document','Workflow_Signatures',
                 'Workflow_Signatures_Detail','Workflow_Signatures_Signataires')
ORDER BY t.name;

SELECT c.name FROM sys.columns c
WHERE c.object_id = OBJECT_ID('dbo.Param_Rubriques')
ORDER BY c.column_id;          -- expect Nom_Controle, Valeur, Membre, Rang, Typ, audit cols

SELECT c.name FROM sys.columns c
WHERE c.object_id = OBJECT_ID('dbo.Controle_Def_Ecran')
ORDER BY c.column_id;          -- expect Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom,
                               -- Index_Table, Modal, PJ, Info, audit cols

SELECT c.name FROM sys.columns c
WHERE c.object_id = OBJECT_ID('dbo.Param_Workflow_Typ_Document')
ORDER BY c.column_id;          -- expect Typ_Document, Intitule, Table_Ref, Table_Index,
                               -- Accepte_Detail, Name_Ecran, Index_Ecran,
                               -- Champs_Proprietaire, id_Societe

SELECT OBJECT_ID('dbo.Sys_Workflow_Signature', 'P') AS workflow_proc;   -- not null if workflow used

/* -- C. Object availability for THIS page --------------------------------- */
SELECT Cod_Page, Statut_Page FROM dbo.Controle_Designer
WHERE Cod_Page = $(CodPage);                          -- page already exists?

SELECT Cod_Page FROM dbo.Controle_Designer
WHERE Cod_Document = $(CodDocument);                  -- document code taken?

SELECT t.name FROM sys.tables t
WHERE t.name LIKE 'SP\_%' ESCAPE '\'
  AND t.name IN (/* physical names to create */);     -- name collisions?

/* -- D. Referenced objects ------------------------------------------------ */
SELECT Valeur, Membre FROM dbo.Param_Rubriques
WHERE Nom_Controle = 'SP_Menu_Portail'
ORDER BY Rang;                                        -- valid target sections

SELECT Cod_Profile FROM dbo.Controle_Profile          -- valid role_code values
WHERE /* adapt to actual Actif column discovered */ 1=1
ORDER BY 1;
```

## 3. What to do with the results

| Finding | Action |
|---|---|
| Fewer than 8 SP_ tables, or missing `Acces_Personnalise`/`estCritere` | **STOP.** Run `001_SP_Designer_Metadata.sql` (+ `003_SP_Designer_Criteres.sql`) first, or set `expected_schema_version` accordingly and regenerate. |
| SP4 columns missing while the input uses a virtual detail (`Source_Metier`/`Source_Mapping`) | **STOP.** Run `005_SP_Designer_Migration_Total_Grille.sql` + `006_SP_Designer_Evolutions.sql` first, or drop the feature from the input and set `expected_schema_version: SP3`. (`freeze_statuses`/`zoom_condition` are not importable at all — blocked at validation.) |
| `Param_Rubriques` columns differ from §B | **STOP.** Report; the skill targets the verified shape only. |
| Section code absent from `SP_Menu_Portail` | Either pick an existing `Valeur`, or set `create_section_if_missing: true` (+ `new_section_label`) — the section is then created **manually** via `Zoom_SP_Nouvelle_Section` before saving (manifest step; the import itself only warns). |
| Profile absent from `Controle_Profile` | **STOP** (or remove the role from `access_control.roles` — roles are granted manually in the Habilitations tab). |
| `Cod_Document` already used by another page | **STOP.** Choose a new `document_code` (the import blocks the update of a page whose `Cod_Document` differs). |
| Physical table name already exists and belongs to another page (`UQ_SP_Page_Table_Nom` would fail at `Saving`) | **STOP.** Rename via a new `document_code`. |
| `Sys_Workflow_Signature` missing while `workflow.enabled: true` | **STOP.** The workflow engine is not installed in this environment. |
| A source used by a virtual detail has `Typ_Retour<>'TABLE'` or is inactive | **STOP.** Fix the source (catalog) or the input (mirror of `VerifierTableVirtuelle` — re-run by the import). |

## 4. Objects intentionally NOT verified here

- `Param_Ged` (GED storage): only touched at runtime by the portal;
  publication only needs `Controle_Def_Ecran.PJ` (written by « Publier »).
- Frontend `menus.json`: static file; dynamic pages merge at runtime via
  `GET /api/sp_menu_portail`. No action possible/needed.
