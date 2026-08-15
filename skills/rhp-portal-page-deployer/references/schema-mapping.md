# RHP Schema Mapping — Portal Page Designer (module SP_)

Every row below is **verified** against the repository sources listed in
*Source/evidence* (path + line). Nothing on this page is hypothetical.

> Legend: **[V]** verified in source · **[I]** inferred (never used as a
> generation target) · **[NF]** not found in the repository.

## 1. Mapping table (functional concept → verified RHP object)

| Functional concept | Verified RHP object | Required columns | Relationships | Source/evidence |
|---|---|---|---|---|
| Page | `dbo.Controle_Designer` | `Cod_Page` (PK, nvarchar(30), `CK_SP_Page_Ident`: `LIKE '[A-Za-z_]%[A-Za-z0-9_]%' AND NOT LIKE 'Page%'`), `Cod_Document` (nvarchar(10), `UQ_SP_Page_Document`), `Libelle`, `Nom_Page`, `Menu_Parent`, `Table_Ent` | 1‑n → `Controle_Designer_Table`, `Controle_Designer_Champ`, `Controle_Designer_Validation`, `Controle_Designer_Droit`, `Controle_Designer_DDL_Log` (all FK on `Cod_Page`) | `RHP_Portail\rhpBE\sql\SP_Designer\001_SP_Designer_Metadata.sql:32-74` |
| Page lifecycle (de-facto feature flag) | `Controle_Designer.Statut_Page` | `CHECK IN ('BROUILLON','PUBLIE','DESACTIVE','ARCHIVE')`, default `'BROUILLON'`; `Version_Page`, `Dat_Publication` | Only `PUBLIE` pages are served by the API (`sp_document.ts:30-41`) | `001_SP_Designer_Metadata.sql:43,70`; `controlers\sp_document.ts:30-41` |
| Section (portal menu root) | `Param_Rubriques` rows with `Nom_Controle='SP_Menu_Portail'` | `Valeur` (= frontend `menus.json` root `name_ecran`), `Membre` (label), `Rang` | Served as `typ_ecran='MNU'` entries by `GET /api/sp_menu_portail` | `001_SP_Designer_Metadata.sql:409-425`; `controlers\sp_document.ts:46-97`; `SP_Page_Designer.vb:273,380-394` |
| Page→section link | `Controle_Designer.Menu_Parent` | `Menu_Parent nvarchar(60) NOT NULL` = `SP_Menu_Portail.Valeur`; `Controle_Designer.Rang` = order in section (default 99) | Dynamic menu entry `name_ecran='SPPL_'+Cod_Page`, `parent=Menu_Parent` | `001_SP_Designer_Metadata.sql:40-41`; `sp_document.ts:46-97` |
| Route / navigation | URL convention (no route table) | List: `/myspace/SPPL_<Cod_Page>/<titre>` · Document: `/myspace/SPP_<Cod_Page>/<titre>/<num?>` | React Router has a single param route `/myspace/:ecran/:titre/:num?`; prefixes dispatched in `Ecran.tsx` | `rhpfe\src\App.tsx:125-132`; `rhpfe\src\Menu\Ecran.tsx:93-102` |
| Component (UI field) | `dbo.Controle_Designer_Champ` | `Cod_Champ` (PK with `Cod_Page`), `Cod_Table`, `Nom_Colonne`, `Libelle`, `Typ_Controle`, `Etat`, `Obligatoire` | FK `FK_SPChamp_Page` → `Controle_Designer`; bound to a physical column of `Controle_Designer_Table` | `001_SP_Designer_Metadata.sql:207-261` |
| Component catalog (types) | Fixed check constraint (no catalog table) | `CK_SPChamp_Typ`: `TEXT, MEMO, INT, DEC, MNT, DATE, DATETIME, CHECK, RADIO, COMBO, RUBRIQUE, ZOOM, CALCULE, SOURCE, GED` | Mirrored in frontend `Pages\Dynamic\Types.ts:58-60` and `DynamicField.tsx:56-142` | `001_SP_Designer_Metadata.sql:257-259` |
| Component instance container (block) | `dbo.Controle_Designer_Table` | `Cod_Table` (PK with `Cod_Page`): `'ENT'` or detail code; `Nom_Physique` (`UQ_SP_Page_Table_Nom`); `Role_Table` `ENT/DET`; `Regle_Suppression` `CASCADE/RESTRICT` | FK `FK_SPTable_Page`; DET FK to ENT created as `FK_<NomPhysique>_Ent` | `001_SP_Designer_Metadata.sql:147-173`; `Module_SP_DDL.vb:302-310` |
| Layout / positioning | `Controle_Designer_Champ.Ligne/Colonne/Rang/Largeur` | `Largeur` 1..12 (default 3, MUI 12-col grid); sort = `Ligne, Colonne, Rang` — **flow layout, no absolute position** | Grid columns: `Visible_Grille`, `Rang_Grille`, `Largeur_Colonne`; footer totals = calculated `Pied_*` fields (`Total_Grille` dropped by 005); list criteria: `estCritere`, `Rang_Critere` | `001_SP_Designer_Metadata.sql:216-249`; `005_SP_Designer_Migration_Total_Grille.sql`; `DynamicPage.tsx:125-129,508-521`; `DynamicPage_Liste.tsx:46-59` |
| Physical column definition | `dbo.Controle_Designer_Colonne` | PK `(Cod_Page, Cod_Table, Nom_Colonne)`; `Typ_Sql` ∈ `nvarchar/int/bigint/float/decimal/bit/date/datetime/smalldatetime`; `Nullable`, `Valeur_Defaut`, `estUnique`, `estIndexe`, `Technique`, `Rang` | FK `FK_SPCol_Table` → `Controle_Designer_Table(Cod_Page, Cod_Table)` | `001_SP_Designer_Metadata.sql:177-203` |
| Data source (business source) | `dbo.Controle_Designer_Source` | `Cod_Source` (PK), `Typ_Source` `SQL/PROC`, `Code_Sql` (read-only whitelist), `Parametres` json `[{Nom,Typ,Obligatoire}]`, `Typ_Retour` `SCALAIRE/TABLE`, `Cod_Profile` (`''`=all), `Actif` | Bound to fields via `Controle_Designer_Champ.Source_Metier`; executed server-side only (`POST /api/sp_exec_source`) | `001_SP_Designer_Metadata.sql:297-316`; `module_sp_engine.ts:526-588` |
| Data source (reference list) | `Param_Rubriques` | `Nom_Controle, Valeur, Membre, Rang, Typ` | Bound via `Controle_Designer_Champ.Rubrique` | `modules\module_rubrique.ts:6-49` |
| Data source (zoom/lookup) | `Controle_Def_Zoom` (socle table, DDL not in repo) | `Num_Zoom` | Bound via `Controle_Designer_Champ.Num_Zoom` + `Zoom_Retour` json; existence checked at publication | `SP_Page_Designer.vb:1733-1736`; `modules\module_zoom.ts` |
| Validation rule | `dbo.Controle_Designer_Validation` | PK `(Cod_Page, Cod_Validation)`; `Portee` `CHAMP/ENTETE/LIGNE/DETAIL/DOCUMENT`; `Typ_Regle` 13 values; `Niveau` `I/W/B`; `Moment` `SAISIE/CHANGE/AJOUT_LIGNE/SAVE`; `Parametres`/`Condition_Regle` json | FK `FK_SPValid_Page`; enforced client + server (server authoritative) | `001_SP_Designer_Metadata.sql:265-293`; `module_sp_engine.ts:590-760`; `dynamicEngine.ts:269-366` |
| Permission (page level) | `dbo.Controle_Designer_Droit` | PK `(Cod_Page, Cod_Profile)`; flags `Consulter, Creer, Modifier, Supprimer, Valider, Imprimer, GED` (nvarchar `'true'/'false'`) | FK `FK_SPDroit_Page`; `Cod_Profile='1'` = super-admin bypass; `Controle_Designer.Acces_Personnalise='false'` opens read to all profiles | `001_SP_Designer_Metadata.sql:57-59,124-143`; `module_sp_engine.ts:267-290` |
| Role / profile / user (socle) | `Controle_Profile`, `Controle_Users` (DDL **[NF]** in repo; usage verified) | `Cod_Profile`; `Controle_Users.Mail`, `Cod_Profile`, `Typ_Role` | Profile resolved at login → JWT `codProfile`; checked on every `sp_*` endpoint | `controlers\authentication.ts:13-85`; `modules\module_jwt.ts`; `sante\setup_tests_api.ts:39-51` |
| Audit trail | 4 columns on every table + `Controle_Designer_DDL_Log` | `Dat_Crea, Created_By, Dat_Modif, Modified_By`; DDL log: `RowId IDENTITY PK, Cod_Page FK, Type_Operation CREATE/MIGRATE, Script_DDL, Resultat, Login_Exec, Date_Exec` | `Controle_Designer_DDL_Log` FK → `Controle_Designer`; **no metadata change-history table exists [V]** | `001_SP_Designer_Metadata.sql:319-334`; `Module_SP_DDL.vb:328-339` |
| Business storage (generated) | `SP_<CodDocument>_Ent` / `SP_<CodDocument>_Det_<CodTable>` | ENT: PK `(Num_Doc, id_Societe)`, `Statut`, `RV rowversion`, audit cols · DET: `RowId IDENTITY` PK, `Num_Doc, id_Societe`, audit cols | DET FK `FK_<Det>_Ent (Num_Doc,id_Societe)` `WITH NOCHECK`, `ON DELETE CASCADE` iff `Regle_Suppression='CASCADE'` | `002_SP_Designer_Exemple_FKM.sql:85-124`; `Module_SP_DDL.vb:73-92,227-235,302-310` |
| Screen registry (GED link) | `Controle_Def_Ecran` | `Name_Ecran='SPP_<Cod_Page>'`, `Table_Ref=<Table_Ent>`, `Index_Ecran='Num_Doc'`, `PJ` = GED flag | Written at publication; used by GED endpoint `/api/get_ged_docs` | `002_...sql:137-140`; `SP_Page_Designer.vb:1768-1776`; `controlers\ged.ts:4-43` |
| Workflow registration | `Param_Workflow_Typ_Document` | `Typ_Document = Cod_Document`, `Intitule=Libelle`, `Table_Ref`, `Table_Index='Num_Doc'`, `Name_Ecran='SPP_<Cod_Page>'`, `Champs_Proprietaire='Created_By'`, `id_Societe=-1` | Written at publication iff `Workflow_Actif='true'`; signature circuit seeded separately (`Workflow_Signatures*`) | `002_...sql:142-148`; `SP_Page_Designer.vb:1777-1789`; `004_FKM_Workflow_Signature.sql` |
| Feature flag / maintenance mode | **[NF]** none exists | — | De-facto mechanism = `Controle_Designer.Statut_Page` lifecycle (`BROUILLON`/`DESACTIVE` remove the page from the portal without deleting data) | verified absence across `rhpBE`, `rhpfe`, `RHP_DeskTop` |
| Page Designer CRUD API | **[NF]** none in the portal backend | — | Design-time = Desktop screen `SP_Page_Designer` + `Module_SP_DDL`; the portal only *renders* published metadata | grep-verified absence of `insert/update Controle_Designer` in `.ts` code |

## 2. SQL Server target (what the Designer's Saving runs against)

- Portal backend connects to database **`RHP`** on instance **`.\SQL2019`** →
  target **SQL Server 2019** **[I]** (from instance name; no explicit version
  string exists in the repo — flagged).
- The skill writes **no SQL**: the DDL is produced and executed by the
  Designer's `Saving` (`Module_SP_DDL`) in a single transaction. This section
  documents what that mechanism applies.

## 3. Verified conventions (applied by Saving / the engines)

1. Booleans in metadata: `nvarchar(5)` `'true'/'false'` (`001_...sql:19`) —
   the JSON import file uses true json booleans, converted at load.
2. Audit columns `Dat_Crea/Created_By/Dat_Modif/Modified_By` everywhere;
   `Saving` stamps the connected login.
3. Identifiers: `^[A-Za-z_][A-Za-z0-9_]{0,59}$` + reserved-word blacklist;
   physical business tables MUST start with `SP_` (`Module_SP_DDL.vb:17-42`,
   `module_sp_engine.ts:138-170`).
4. `Cod_Page` may not start with `'Page'` (`CK_SP_Page_Ident`).
5. A `NOT NULL` business column always gets a `DF_<Table>_<Col>` default
   (`Module_SP_DDL.vb:106-112`).
6. Never drop a column automatically — removed metadata ⇒ warning, not DDL
   (`Module_SP_DDL.vb:261-271`).
7. FK naming `FK_<DetTable>_Ent`, index naming `IX_<Table>_<Col>` /
   `UX_<Table>_<Col>` (unique) (`Module_SP_DDL.vb:281-310`).
8. Document numbering: `<CodDocument><idSociete>-<yyyy><seq 6>` assigned
   server-side (`module_sp_engine.ts:788-799`) — no one inserts `Num_Doc`.
9. `Saving` = single transaction for metadata + DDL (`SP_Page_Designer.vb`).
10. Physical names are always **derived** (`SP_<CodDocument>_Ent`,
    `SP_<CodDocument>_Det_<CodTable>`) — the import recomputes them from
    `Cod_Document`; they are never read from the file.
