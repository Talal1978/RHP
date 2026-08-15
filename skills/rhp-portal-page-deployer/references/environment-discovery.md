# Environment Discovery & Verification Procedure

The repository fully documents the **SP_ module schema** (see
`schema-mapping.md`), but the DDL of several **socle (base) tables** is not in
the repo — they exist only in the `RHP` database. Before generating or running
a deployment, verify the target environment with the procedure below.

**Rule:** if a discovery result contradicts this reference, **STOP** — do not
generate SQL. Report the discrepancy as *missing/conflicting information*.

---

## 1. Schema levels (for `deployment.expected_schema_version`)

Derived from the official migration scripts:

| Level | Meaning | Assertions |
|---|---|---|
| `SP1` | Base metadata installed | Tables `SP_Page, SP_Page_Droit, SP_Page_Table, SP_Page_Colonne, SP_Page_Champ, SP_Page_Validation, SP_Page_Source, SP_Page_DDL_Log` exist |
| `SP2` | SP1 + migration 1.1.b/1.1.c | `SP_Page.Acces_Personnalise` exists; `SP_Page.Typ_Document` is `nvarchar(10)`; `Param_Workflow_Typ_Document.Typ_Document` is `nvarchar(10)` |
| `SP3` | SP2 + migration 003 | `SP_Page_Champ.estCritere` and `SP_Page_Champ.Rang_Critere` exist |
| `SP4` | SP3 + migrations 005/006 (current repo state) | `SP_Page.Figer_Statuts`, `SP_Page_Champ.Zoom_Condition`, `SP_Page_Champ.Total_Grille`, `SP_Page_Table.Source_Metier` and `SP_Page_Table.Source_Mapping` exist. Required when the input uses `freeze_statuses`, `zoom_condition`, `grid_total` or a virtual detail grid |

## 2. Parameterized discovery template

Run with sqlcmd (adapt `-S`/`-d`) or in SSMS. Every query is read-only.

```sql
:setvar CodPage "FRAIS_KM"
:setvar CodDocument "FKM"
/* -- A. SP_ schema level -------------------------------------------------- */
SELECT t.name AS table_name
FROM sys.tables t
WHERE t.name IN ('SP_Page','SP_Page_Droit','SP_Page_Table','SP_Page_Colonne',
                 'SP_Page_Champ','SP_Page_Validation','SP_Page_Source','SP_Page_DDL_Log')
ORDER BY t.name;                                    -- expect 8 rows  (SP1)

SELECT c.name AS column_name, c.max_length
FROM sys.columns c
WHERE c.object_id = OBJECT_ID('dbo.SP_Page')
  AND c.name IN ('Acces_Personnalise','Typ_Document');  -- Acces_Personnalise present (SP2)
                                                        -- Typ_Document max_length = 20 (nvarchar(10))

SELECT c.name FROM sys.columns c
WHERE c.object_id = OBJECT_ID('dbo.SP_Page_Champ')
  AND c.name IN ('estCritere','Rang_Critere');      -- expect 2 rows (SP3)

SELECT c.object_id, c.name FROM sys.columns c
WHERE (c.object_id = OBJECT_ID('dbo.SP_Page')       AND c.name = 'Figer_Statuts')
   OR (c.object_id = OBJECT_ID('dbo.SP_Page_Champ') AND c.name IN ('Zoom_Condition','Total_Grille'))
   OR (c.object_id = OBJECT_ID('dbo.SP_Page_Table') AND c.name IN ('Source_Metier','Source_Mapping'))
ORDER BY c.object_id, c.name;                     -- expect 5 rows (SP4)

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
SELECT Cod_Page, Statut_Page FROM dbo.SP_Page
WHERE Cod_Page = $(CodPage);                          -- page already exists?

SELECT Cod_Page FROM dbo.SP_Page
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
| SP4 columns missing while the input uses `freeze_statuses`, `zoom_condition`, `grid_total` or a virtual detail | **STOP.** Run `005_SP_Designer_Migration_Total_Grille.sql` + `006_SP_Designer_Evolutions.sql` first, or drop those features from the input and set `expected_schema_version: SP3`. |
| `Param_Rubriques` columns differ from §B | **STOP.** Report; the skill targets the verified shape only. |
| Section code absent from `SP_Menu_Portail` | Either pick an existing `Valeur`, or set `create_section_if_missing: true` (+ `new_section_label`). |
| Profile absent from `Controle_Profile` | **STOP** (or remove the role from `access_control.roles`). |
| `Cod_Document` already used by another page | **STOP.** Choose a new `document_code`. |
| Physical table name already exists and belongs to another page (`UQ_SP_Page_Table_Nom` would fail) | **STOP.** Rename via a new `document_code`. |
| `Sys_Workflow_Signature` missing while `workflow.enabled: true` | **STOP.** The workflow engine is not installed in this environment. |
| A source used by a virtual detail has `Typ_Retour<>'TABLE'` or is inactive | **STOP.** Fix the source (catalog) or the input (mirror of `VerifierTableVirtuelle`). |

## 4. Objects intentionally NOT verified here

- `Param_Ged` (GED storage): only touched at runtime by the portal; deployment
  only needs `Controle_Def_Ecran.PJ`.
- Frontend `menus.json`: static file; dynamic pages merge at runtime via
  `GET /api/sp_menu_portail`. No deployment action possible/needed.
