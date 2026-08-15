# SP_ Metadata Model — Generation Reference

Distilled, verbatim-faithful reference for generating deployment SQL.
Primary sources: `RHP_Portail\rhpBE\sql\SP_Designer\001_SP_Designer_Metadata.sql`,
`002_SP_Designer_Exemple_FKM.sql`, `003_SP_Designer_Criteres.sql`,
`005_SP_Designer_Migration_Total_Grille.sql`, `006_SP_Designer_Evolutions.sql`
(SP4), `RHP_DeskTop\RHP\Portail\Module_SP_DDL.vb`, `SP_Page_Designer.vb`.

> Deep-dive companions (read before generating the corresponding parts):
> - `references/formules-calculees.md` — `Formule` AST, operators, GV_*,
>   dependency graph/cycles, recalc & persistence rules;
> - `references/comportement-page.md` — `Etat`, dynamic rules, the 13
>   validation types with exact `Parametres` json, moments/levels, document
>   lifecycle (`Figer_Statuts`, RV concurrency), detail flags, rights, list;
> - `references/sources-metier.md` — `SP_Page_Source` guard, parameters &
>   auto-injection, the 3 usages (SOURCE field, virtual detail, SOURCE
>   validation), zoom condition.

---

## 1. `dbo.SP_Page` — page / document type

| Column | Type | Null | Default | Notes |
|---|---|---|---|---|
| `Cod_Page` | nvarchar(30) | NO | — | PK. Immutable technical id. `CK_SP_Page_Ident`: matches `[A-Za-z_]…` and **not** `Page%` |
| `Cod_Document` | nvarchar(10) | NO | — | UNIQUE. Drives physical names + workflow code |
| `Libelle` | nvarchar(150) | NO | — | Full functional label |
| `Libelle_Court` | nvarchar(50) | YES | — | Short label |
| `Nom_Page` | nvarchar(60) | NO | — | Title displayed in the portal menu |
| `Menu_Parent` | nvarchar(60) | NO | — | `SP_Menu_Portail` rubrique value |
| `Rang` | int | NO | 99 | Order inside the menu section |
| `Icone` | nvarchar(50) | YES | — | MUI icon name (`MenuIcons`) |
| `Statut_Page` | nvarchar(10) | NO | `'BROUILLON'` | `BROUILLON/PUBLIE/DESACTIVE/ARCHIVE` |
| `Table_Ent` | nvarchar(60) | NO | — | `SP_<CodDocument>_Ent` |
| `Typ_Document` | nvarchar(10) | YES | — | Always = `Cod_Document` (post-migration 1.1.c) |
| `Workflow_Actif` | nvarchar(5) | NO | `'false'` | |
| `Cod_Modele_Edition` | nvarchar(20) | YES | — | `Param_Mod_Edition.Cod_Report` |
| `GED_Actif` | nvarchar(5) | NO | `'false'` | |
| `GED_Categories` | nvarchar(500) | YES | — | json categories |
| `GED_Obligatoire` | nvarchar(5) | NO | `'false'` | |
| `Act_Enregistrer` | nvarchar(5) | NO | `'true'` | |
| `Act_Soumettre` | nvarchar(5) | NO | `'true'` | Requires `Workflow_Actif='true'` to surface in UI |
| `Act_Imprimer` | nvarchar(5) | NO | `'false'` | Requires `Cod_Modele_Edition` |
| `Act_Exporter` | nvarchar(5) | NO | `'false'` | Not wired in current frontend (metadata only) |
| `Acces_Personnalise` | nvarchar(5) | NO | `'true'` | `'false'` = consultation open to every profile |
| `Figer_Statuts` | nvarchar(50) | NO | `'SG,RJ,SP,VA'` | **SP4** (006) — CSV of statuses freezing the document (e.g. `'SS,SG,RJ,SP,VA'` freezes on submit). **Not editable in the Desktop Designer**; its targeted `UPDATE` preserves it on re-save |
| `Version_Page` | int | NO | 1 | +1 at each publication |
| `DDL_Genere` | nvarchar(5) | NO | `'false'` | |
| `Dat_Publication` | datetime | YES | — | |
| audit | | | | `Dat_Crea, Created_By, Dat_Modif, Modified_By` |

## 2. `dbo.SP_Page_Droit` — rights per profile

PK `(Cod_Page, Cod_Profile)`; FK → `SP_Page`.
Flag columns (all nvarchar(5), default `'false'`):
`Consulter, Creer, Modifier, Supprimer, Valider, Imprimer, GED`.
Profile `'1'` bypasses all checks (RHP convention, `module_sp_engine.ts:271`).

## 3. `dbo.SP_Page_Table` — attached tables

PK `(Cod_Page, Cod_Table)`; `UQ` on `Nom_Physique`; FK → `SP_Page`.
- `Cod_Table`: `'ENT'` (header) or detail code (e.g. `'LIGNES'`).
- `Nom_Physique`: `SP_<CodDocument>_Ent` / `SP_<CodDocument>_Det_<CodTable>`.
- `Role_Table` ∈ `ENT|DET`; `Regle_Suppression` ∈ `CASCADE|RESTRICT`.
- Detail editing flags: `Allow_Add/Allow_Edit/Allow_Delete/Allow_Duplicate`
  (defaults `'true','true','true','false'`); `Tri_Defaut` e.g. `'Rang asc'`.
- **SP4** (006) — `Source_Metier` + `Source_Mapping` : a DET table may be
  *virtual* — fed read-only by a `SP_Page_Source` with `Typ_Retour='TABLE'`
  (params mapped from header fields). No physical table is created/read/written
  for it (virtual name `SP_<doc>_Virt_<Cod_Table>`); the server re-executes the
  source at save time before validations. Full contract:
  `references/sources-metier.md` §6. The Designer includes both columns in its
  DELETE+INSERT — virtual details survive Designer re-saves.

## 4. `dbo.SP_Page_Colonne` — physical columns

PK `(Cod_Page, Cod_Table, Nom_Colonne)`; FK → `SP_Page_Table(Cod_Page,Cod_Table)`.
`Typ_Sql` ∈ `nvarchar|int|bigint|float|decimal|bit|date|datetime|smalldatetime`;
`Longueur` (nvarchar, `-1`=max); `Precision_Sql`/`Echelle_Sql` (decimal);
`Nullable`, `Valeur_Defaut`, `estUnique`, `estIndexe`, `Technique`, `Rang`.

## 5. `dbo.SP_Page_Champ` — UI fields

PK `(Cod_Page, Cod_Champ)`; FK → `SP_Page`.
- `Typ_Controle` ∈ `TEXT,MEMO,INT,DEC,MNT,DATE,DATETIME,CHECK,RADIO,COMBO,RUBRIQUE,ZOOM,CALCULE,SOURCE,GED`.
- `Etat` ∈ `S` (saisissable) `R` (lecture seule) `A` (affiché) `I` (invisible).
- Header placement: `Rang`, `Ligne`, `Colonne`, `Largeur` (1..12, default 3 —
  flow layout on a 12-column grid; `Ligne/Colonne` only affect sort order).
- `Valeur_Defaut`: constant or variable `GV_MATRICULE`, `GV_NOW`, `GV_LOGIN`.
- `Rubrique` → `Param_Rubriques.Nom_Controle` (RUBRIQUE + RADIO).
- `Num_Zoom` + `Zoom_Retour` json `{"ChampCible":"ColonneZoom",…}` (ZOOM, COMBO).
- **SP4** (006) — `Zoom_Condition` : condition du zoom avec placeholders
  `{Champ}` évalués dans le contexte entête (ex. `Matricule='{Matricule}'`) —
  COMBO et ZOOM. **Not editable in the Desktop Designer** — a Designer re-save
  (DELETE+INSERT of `SP_Page_Champ` without this column) resets it to NULL;
  re-apply the deployment script afterwards.
- `Source_Metier` → `SP_Page_Source.Cod_Source` (SOURCE).
- `Formule` json déclaratif (CALCULE, and SOURCE mapping
  `{"source":"…","mapping":{"Param":{"ref":"Colonne"}}}`) — full AST and
  semantics: `references/formules-calculees.md`.
- `Persiste` (default `'false'`) — persisted calculated fields get a physical
  column; non-persisted ones do not. `Recalc_Save` default `'true'` — only
  meaningful for persisted ENT SOURCE fields (server re-execution at save);
  **not editable in the Desktop Designer** (same DELETE+INSERT reset caveat
  as `Zoom_Condition`).
- `Format_Affichage`, `Decimales`; dynamic rules `Regle_Visibilite`,
  `Regle_Activation` (json AST).
- Grid: `Visible_Grille`, `Rang_Grille`, `Largeur_Colonne` (em),
  `Total_Grille` ∈ `'',SUM,AVG,MIN,MAX,COUNT`.
- List criteria: `estCritere`, `Rang_Critere` (migration 003).

## 6. `dbo.SP_Page_Validation` — declarative validations

PK `(Cod_Page, Cod_Validation)`; FK → `SP_Page`.
`Portee` ∈ `CHAMP,ENTETE,LIGNE,DETAIL,DOCUMENT`;
`Typ_Regle` ∈ `REQUIRED,IN,BETWEEN,MIN,MAX,MINLEN,MAXLEN,REGEX,COMPARE,UNIQUE,SOURCE,EXPR,NB_LIGNES`;
`Niveau` ∈ `I,W,B` (default `B` = blocking); `Moment` ∈ `SAISIE,CHANGE,AJOUT_LIGNE,SAVE`
(default `SAVE`); `Parametres`/`Condition_Regle` json.
Verified json shapes (from `002_...sql:66-76`):
- `NB_LIGNES`: `{"min":1}` · `BETWEEN`: `{"min":0,"max":1000}`
- `EXPR`: `{"expr":{"op":"GE","args":[{"ref":"Total"},{"const":0}]}}`

## 7. `dbo.SP_Page_Source` — secured source catalog

PK `(Cod_Source)`; `Typ_Source` ∈ `SQL,PROC`; `Typ_Retour` ∈ `SCALAIRE,TABLE`
(default `SCALAIRE`); `Cod_Profile` default `''` (= all profiles); `Actif`.
Server-side guard `estRequeteLectureSeule` (`module_sp_engine.ts:569-588`):
single statement; must start with `select|with|exec dbo.Sys_*`; blacklist
`insert|update|delete|merge|drop|alter|create|truncate|grant|revoke|backup|
restore|shutdown|kill|waitfor|openrowset|opendatasource|xp_*|sp_*`.
`@id_Societe` is auto-injected by the server — **never declare it** in `Parametres`.

## 8. `dbo.SP_Page_DDL_Log` — DDL journal

`RowId int IDENTITY` PK; `Cod_Page` FK; `Type_Operation` `CREATE|MIGRATE`;
`Script_DDL`; `Resultat` `'true'/'false'`; `Message`; `Login_Exec`; `Date_Exec`.

---

## 9. Generated business tables (exact `Module_SP_DDL` format)

Technical columns — **ENT**:
```sql
[Num_Doc] nvarchar(30) NOT NULL,
[id_Societe] int NOT NULL,
[Statut] nvarchar(3) NULL CONSTRAINT [DF_<T>_Statut] DEFAULT (''),
[Dat_Crea] datetime NULL, [Created_By] nvarchar(50) NULL,
[Dat_Modif] datetime NULL, [Modified_By] nvarchar(50) NULL,
[RV] rowversion NOT NULL,
… CONSTRAINT [PK_<T>] PRIMARY KEY ([Num_Doc], [id_Societe])
```
**DET**: `[RowId] int IDENTITY(1,1) NOT NULL` first, `Num_Doc`, `id_Societe`,
4 audit columns (no `Statut`, no `RV`), PK on `[RowId]`.

Business column rules:
- Type translation (`SqlTypeDDL`): `decimal` → `decimal(p,s)` (default `18,2`,
  `s` clamped to `p`, `p` ≤ 38); `nvarchar` → `nvarchar(L)` (default 50,
  `-1` → `max`, clamp `1..4000`); other types verbatim.
- `NOT NULL` ⇒ mandatory default: `CONSTRAINT [DF_<T>_<C>] DEFAULT …`;
  empty default ⇒ `(0)` numerics/bit, `('')` else; `GV_NOW` ⇒ `(getdate())`.
- Migration of an existing table: **ADD only**, one `ALTER TABLE … ADD` per
  missing column; columns present in DB but absent from metadata ⇒ warning,
  never a drop.
- Index: `estIndexe='true'` ⇒ `IX_<T>_<C>`; `estUnique='true'` ⇒ `UX_<T>_<C> UNIQUE`.
- DET ⇒ FK: `ALTER TABLE dbo.[<Det>] WITH NOCHECK ADD CONSTRAINT [FK_<Det>_Ent]
  FOREIGN KEY ([Num_Doc],[id_Societe]) REFERENCES dbo.[<Ent>] ([Num_Doc],[id_Societe])`
  + `ON DELETE CASCADE` iff `Regle_Suppression='CASCADE'`.

## 10. Publication procedure (mirror of `SP_Page_Designer.Publier`)

Blocking preconditions:
1. Every `Nom_Physique` exists in DB; every configured non-technical column exists.
2. Every `Num_Zoom` exists in `Controle_Def_Zoom`; every `Rubrique` exists in
   `Param_Rubriques`; every `Source_Metier` exists and is active in `SP_Page_Source`.
3. No circular reference between CALCULE fields (`{"ref":…}` graph).
4. If `Acces_Personnalise='true'`: at least one `SP_Page_Droit` row with
   `Consulter='true'` (otherwise the page would be invisible to everyone).
5. `Menu_Parent` not empty.
6. `Workflow_Actif='true'` ⇒ `Cod_Document` not empty.

Publication writes:
```sql
UPDATE SP_Page SET Statut_Page='PUBLIE', Dat_Publication=GETDATE(),
       Version_Page=ISNULL(Version_Page,1)+1, Dat_Modif=GETDATE(), Modified_By=…
WHERE Cod_Page=@CP;                                    -- (002 guards: AND Statut_Page <> 'PUBLIE')
-- Screen registry (GED link):
INSERT/UPDATE Controle_Def_Ecran  Name_Ecran='SPP_<Cod_Page>', Table_Ref=<Table_Ent>,
       Index_Ecran='Num_Doc', Num_Zoom='', Index_Table='Num_Doc', Modal='false',
       PJ=('true' iff GED_Actif), Info='true'
-- Workflow registration (iff Workflow_Actif='true'):
INSERT/UPDATE Param_Workflow_Typ_Document  Typ_Document=<Cod_Document>, Intitule=<Libelle>,
       Table_Ref=<Table_Ent>, Table_Index='Num_Doc', Accepte_Detail='false',
       Name_Ecran='SPP_<Cod_Page>', Index_Ecran='Num_Doc',
       Champs_Proprietaire='Created_By', id_Societe=-1
```

## 11. Deletion semantics (mirror of `SP_Page_Designer.Deleting`)

- Only a `BROUILLON` page may be structurally deleted.
- Deletion removes metadata only, in FK-safe order: `SP_Page_Colonne`,
  `SP_Page_Champ`, `SP_Page_Validation`, `SP_Page_Droit`, `SP_Page_Table`,
  `SP_Page_DDL_Log`, then `SP_Page`.
- **Business tables `SP_*` and their data are NEVER dropped by the module.**
- A published page is retired via `Statut_Page='DESACTIVE'`
  (disappears from the portal; documents are preserved).
