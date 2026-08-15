# Format d'import JSON du Designer de pages (RHP_PAGE_DESIGNER 1.0)

Référence exacte du fichier que le skill doit produire. Miroir **verbatim-fidèle**
de `RHP_DeskTop\RHP\Portail\Module_SP_Page_Json.vb` (DTO, validation, remplissage)
et de `SP_Page_Designer.vb` (`ImporterJson`, `AppliquerImport`, `Saving`).

> PRINCIPE FONDAMENTAL (rappel du code) : le fichier représente l'état complet de
> la configuration d'une page, **HORS HABILITATIONS**. L'import recharge les
> CONTRÔLES ET GRILLES du Designer — **aucune écriture en base au chargement**.
> L'écriture reste assurée exclusivement par « Enregistrer » (`Saving` :
> contrôles standards + transaction + génération/migration DDL non destructive).

---

## 1. Enveloppe

```json
{
  "format": "RHP_PAGE_DESIGNER",
  "version": "1.0",
  "exportedAt": "2026-08-15T14:30:00",
  "exportedBy": "LOGIN",
  "rhpVersion": "1.0.0.0",
  "page":       { ... },
  "sqlStructure": [ ... ],
  "businessSources": [ ... ],
  "components": [ ... ],
  "validations": [ ... ],
  "metadata": { "habilitations": "EXCLUES", "nbTables": 0, "nbColonnes": 0,
                "nbChamps": 0, "nbSources": 0, "nbValidations": 0 }
}
```

- `format` : valeur exacte `RHP_PAGE_DESIGNER` (comparaison insensible à la
  casse ; toute autre valeur = **bloquant**).
- `version` : `MAJEUR.MINEUR`. Majeur `> 1` = **bloquant** ; mineur supérieur à
  celui de l'importeur = avertissement (propriétés inconnues ignorées).
  Le générateur émet toujours `"1.0"`.
- `exportedAt` : `yyyy-MM-ddTHH:mm:ss` (affiché dans l'aperçu d'import).
- `exportedBy` : login (affiché dans l'aperçu + la trace d'import).
- `rhpVersion` : **facultatif** — version de l'application Desktop à l'export ;
  le générateur l'omet (il ne la connaît pas ; affichage seulement).
- Sérialisation : json **indenté**, propriétés `null` **omises**
  (`NullValueHandling.Ignore`), UTF-8 **sans BOM**
  (`New UTF8Encoding(False)` dans `ExporterJson`).
- Booléens : vrais booléens json (`true`/`false`). L'import accepte aussi les
  chaînes `"true"/"false"`, mais le générateur n'émet que des booléens.
- Clés métier = **noms techniques** (`Cod_Page`, `Cod_Table`, `Cod_Champ`…) :
  stables entre environnements, jamais de clés SQL internes.

## 2. `page` — entête (miroir des contrôles d'entête du Designer)

| Propriété | Type | Importée ? | Notes |
|---|---|---|---|
| `Cod_Page` | string | oui | `^[A-Za-z_][A-Za-z0-9_]{2,29}$`, ne commence **pas** par `Page`. Vide à l'import ⇒ code automatique (`Nouveau()`). Si la page existe ⇒ **mise à jour** ; sinon création sous ce code |
| `Cod_Document` | string | oui | `^[A-Za-z][A-Za-z0-9]{1,9}$` (lettre puis alphanumérique, **pas de underscore**). **Immuable** dès que la page existe (`ControlerCibleExistante` : bloquant si différent) |
| `Nom_Page` | string | oui | **Obligatoire.** Titre du menu portail ; au `Saving`, `Libelle = Nom_Page` (le Designer n'a qu'un seul libellé) |
| `Menu_Parent` | string | oui | Valeur de la rubrique `SP_Menu_Portail`. Vide ou absente de la base = **avertissement** (à renseigner/créer avant l'enregistrement) |
| `Rang` | int | oui | Ordre dans la section (défaut 99) |
| `Icone` | string | oui | Valeur de la rubrique `SP_Menu_Icones` ; inconnue = avertissement (ignorée) |
| `Statut_Page` | string | **non** | Indicatif uniquement — jamais réimporté (transitions via Publier/Désactiver). Le générateur l'omet |
| `Table_Ent` | string | **non** | Indicatif — recalculé depuis `Cod_Document` (`MajNomsPhysiques`). Le générateur l'omet |
| `Acces_Personnalise` | bool | partiel | **Création** : appliqué. **Mise à jour** : préservé (jamais réimporté). `false` = consultation ouverte à tous les profils |
| `Workflow_Actif` | bool | oui | Défaut `false` |
| `Cod_Modele_Edition` | string | oui | `Param_Mod_Edition.Cod_Report` ; absent de la base = avertissement |
| `GED_Actif` | bool | oui | |
| `GED_Obligatoire` | bool | oui | |
| `Act_Enregistrer` | bool | oui | Défaut `true` |
| `Act_Soumettre` | bool | oui | Défaut `true` |
| `Act_Imprimer` | bool | oui | Défaut `false` |
| `Act_Exporter` | bool | oui | Défaut `false` (métadonnée seulement dans le frontend actuel) |

**Jamais dans le DTO** (aucune cible à l'import) : `Libelle` / `Libelle_Court`
(le Designer écrit `Libelle = Nom_Page`), `GED_Categories`, `Figer_Statuts`.

## 3. `sqlStructure` — tables (ENT + grilles de détail) et colonnes physiques

`SP_Page_TableDto` :

| Propriété | Défaut | Notes |
|---|---|---|
| `Cod_Table` | — | **Obligatoire**, identifiant SQL validé, unique. `'ENT'` = entête (exactement **une**), sinon code du bloc détail (majuscules à l'import) |
| `Nom_Physique` | `""` | Indicatif — **recalculé** à l'import (`SP_<doc>_Ent`, `SP_<doc>_Det_<table>`). Le générateur l'omet |
| `Role_Table` | `"DET"` | `ENT` ou `DET` — sinon **bloquant**. La table `ENT` est forcée au rôle `ENT` (avertissement sinon) |
| `Libelle` | `""` | Libellé de la grille |
| `Rang` | 1 | ENT = 0 |
| `Allow_Add/Allow_Edit/Allow_Delete` | `true` | Flags d'édition de la grille |
| `Allow_Duplicate` | `false` | |
| `Tri_Defaut` | `""` | ex. `'Dat_Jour asc'` |
| `Regle_Suppression` | `"CASCADE"` | `CASCADE` ou `RESTRICT` — sinon **bloquant** |
| `Source_Metier` | `""` | Renseignée ⇒ **grille virtuelle** (aucune table physique). Interdite sur `ENT` (**bloquant**) |
| `Source_Mapping` | `""` | json objet `{"Paramètre":{"ref":"ChampEntete"}}` ou `{"const":"…"}` |
| `colonnes` | `[]` | **≥ 1 colonne obligatoire par table** (même virtuelle — colonnes logiques de la source) |

`SP_Page_ColonneDto` (dans `colonnes`) :

| Propriété | Défaut | Notes |
|---|---|---|
| `Nom_Colonne` | — | **Obligatoire**, identifiant SQL validé, unique par table. Les colonnes **techniques** sont interdites (**bloquant**) : `RowId, Num_Doc, id_Societe, Statut, Dat_Crea, Created_By, Dat_Modif, Modified_By, RV` (ajoutées automatiquement au DDL) |
| `Libelle` | `""` | |
| `Typ_Sql` | `"nvarchar"` | ∈ `nvarchar, int, bigint, float, decimal, bit, date, datetime, smalldatetime` — sinon **bloquant** |
| `Longueur` | null | nvarchar (`-1` = max) |
| `Precision_Sql` / `Echelle_Sql` | null | decimal |
| `Nullable` | `true` | `false` ⇒ le DDL génère un `DF_` automatiquement (`Module_SP_DDL`) |
| `Valeur_Defaut` | `""` | |
| `estUnique` | `false` | ⇒ `UX_<table>_<col>` |
| `estIndexe` | `false` | ⇒ `IX_<table>_<col>` |
| `Rang` | 1 | |

## 4. `components` — champs (entête + colonnes de grilles)

`SP_Page_ChampDto` :

| Propriété | Défaut | Notes |
|---|---|---|
| `Cod_Champ` | — | **Obligatoire**, identifiant SQL validé, unique |
| `Cod_Table` | `""` | `ENT` ou code d'un bloc détail déclaré ; `""` = champ d'affichage non rattaché. Référence inconnue = **bloquant** |
| `Nom_Colonne` | `""` | `""` = non stocké (calculé/affiché). Sinon **doit exister** dans les colonnes de sa table (ou colonnes techniques) et n'être affectée qu'**une fois** — sinon **bloquant** |
| `Libelle` | `""` | |
| `Typ_Controle` | `"TEXT"` | ∈ `TEXT, MEMO, INT, DEC, MNT, DATE, DATETIME, CHECK, RADIO, COMBO, RUBRIQUE, ZOOM, CALCULE, SOURCE, GED` — sinon **bloquant** |
| `Rang` | 1 | |
| `Ligne` / `Colonne` | null | Tri du flux (pas de position absolue) |
| `Largeur` | null | 1..12 (grille 12 colonnes) |
| `Valeur_Defaut` | `""` | Constante ou `GV_MATRICULE` / `GV_NOW` / `GV_LOGIN` |
| `Obligatoire` | `false` | Marqueur d'affichage — toujours doubler d'une validation `REQUIRED` |
| `Etat` | `"S"` | ∈ `S, R, A, I` — sinon **bloquant**. Miroir `Saving` : un `CALCULE` ni `A` ni `I` est forcé à `A` |
| `Rubrique` | `""` | **Obligatoire** si `RUBRIQUE` (et `RADIO`) ; absente de la base = avertissement |
| `Num_Zoom` | `""` | **Obligatoire** si `ZOOM` (et `COMBO`) ; absent de la base = avertissement |
| `Source_Metier` | `""` | **Obligatoire** si `SOURCE` ; doit être résoluble (fichier **ou** base) — sinon **bloquant** |
| `Formule` | `""` | json : AST déclaratif (`CALCULE`) ou mapping `{"source":…,"mapping":{…}}` (`SOURCE`) |
| `Persiste` | `false` | `CALCULE`/`SOURCE` persisté ⇒ colonne physique |
| `Format_Affichage` | `""` | `''`, `MNT`, `NUM`, `PCT`, `DAT`, `DTM` |
| `Decimales` | null | |
| `Visible_Grille` | `true` | |
| `Rang_Grille` | 1 | |
| `Largeur_Colonne` | null | em |
| `estCritere` | `false` | Critère de la page liste (champs ENT) |
| `Rang_Critere` | null | |
| `Aide` | `""` | |

**Jamais dans le DTO** : `Zoom_Retour`, `Zoom_Condition`, `Recalc_Save`,
`Regle_Visibilite`, `Regle_Activation`, `Total_Grille` (colonne **supprimée**
par la migration 005 — remplacée par un champ calculé de pied de grille,
cf. §7 « pied de grille »).

## 5. `businessSources` — sources métier utilisées par la page

`SP_Page_SourceDto` : `Cod_Source` (**obligatoire**, unique), `Libelle`
(**obligatoire**), `Typ_Source` ∈ `SQL, PROC` (défaut `SQL`), `Code_Sql`
(**obligatoire** — requête ou procédure), `Parametres` (json **liste**
`[{"Nom":…,"Typ":…,"Obligatoire":…}]` — toute autre forme = **bloquant**),
`Typ_Retour` ∈ `SCALAIRE, TABLE` (défaut `SCALAIRE`), `Cod_Profile` (`''` =
tous ; absent de la base = avertissement), `Actif` (défaut `true`).

- Catalogue **global** : au `Saving`, les sources sont **fusionnées** par
  `Cod_Source` (delete+insert du catalogue — upsert, jamais de suppression).
- Le générateur n'inclut que les sources **référencées** par la page (champ
  `SOURCE`, détail virtuel, validation `SOURCE`) — miroir de l'export.
- Grille virtuelle : la source doit être **active** et `Typ_Retour = TABLE`,
  ses paramètres **obligatoires tous alimentés** par le mapping, chaque
  `{"ref":"X"}` pointant une colonne de l'entête (ou technique hors `RV`) —
  miroir de `VerifierSourceVirtuelle` (**bloquant**).

## 6. `validations` — règles déclaratives

`SP_Page_ValidationDto` : `Cod_Validation` (**obligatoire**, unique), `Portee` ∈
`CHAMP, ENTETE, LIGNE, DETAIL, DOCUMENT` (défaut `CHAMP`), `Cod_Table`,
`Cod_Champ` (**obligatoire** si `Portee = CHAMP`), `Typ_Regle` ∈ les 13 types
(`SP_Page_Designer.TYPES_REGLE`), `Parametres` / `Condition_Regle` (json),
`Message` (**obligatoire**, ≤ 300), `Niveau` ∈ `I, W, B` (défaut `B`),
`Moment` ∈ `SAISIE, CHANGE, AJOUT_LIGNE, SAVE` (défaut `SAVE`), `Actif`
(défaut `true`), `Rang`. Toute référence (`Cod_Table`, `Cod_Champ`) absente du
fichier = **bloquant**.

## 7. Sémantique de l'import (ce qui se passe dans le Designer)

1. `Analyser` : parsing → signature/version → désérialisation → `Valider`
   (tous les contrôles ci-dessus + dépendances de la base cible). **Erreur
   bloquante ⇒ l'écran reste strictement inchangé.**
2. Mode : `Cod_Page` existant ⇒ **mise à jour** (`Cod_Document` immuable) ;
   sinon **création** (code du fichier conservé, ou automatique si vide).
3. **Prévisualisation** (`Zoom_SP_ImportApercu`) : compteurs, diff vs base
   (ajouts/modifications/suppressions par code fonctionnel ; les sources ne
   sont jamais comptées en suppression), avertissements. Au « Valider »
   seulement : `AppliquerImport`.
4. Application : **création** → `Nouveau()` + entête du fichier +
   `Acces_Personnalise` du fichier ; **mise à jour** → `Request()` (recharge
   l'état enregistré, **habilitations préservées**) + entête du fichier sauf
   statut/`Acces_Personnalise`. Puis `RemplirTables` : collections de la page
   **remplacées** (clear + ajouts) ; catalogue des sources **fusionné**
   (upsert) ; noms physiques **recalculés** depuis `Cod_Document`.
5. **« Enregistrer » (`Saving`)** : re-contrôles complets, transaction unique,
   `Controle_Designer` (insert/update — `Libelle = Nom_Page`), DELETE+INSERT
   des collections filles (droits inclus, **recharge de la grille
   Habilitations** — préservés en mise à jour), upsert des sources,
   **génération/migration DDL non destructive** (`Module_SP_DDL` : CREATE
   gardé, ALTER ADD seul, jamais de drop ; aucune table pour les détails
   virtuels), journal `Controle_Designer_DDL_Log`.
6. **« Publier »** (bouton dédié, manuel) : préconditions (colonnes existantes,
   zooms/rubriques/sources résolues, pas de cycle calculé, ≥ 1 droit Consulter
   si `Acces_Personnalise`, `Menu_Parent` non vide) puis `Statut_Page='PUBLIE'`
   + `Version_Page+1`, upsert `Controle_Def_Ecran` (`SPP_<code>`, `PJ` =
   `GED_Actif`), upsert `Param_Workflow_Typ_Document` (si `Workflow_Actif`).

Pied de grille (remplacement officiel de `Total_Grille`, migration 005) :
champ `CALCULE` rattaché au bloc détail avec `Nom_Colonne = ''`,
`Persiste = false`, formule agrégat `{"op":"SUM","table":"<bloc>","colonne":"<col>"}`,
`Visible_Grille = false`, `Format_Affichage = 'MNT'` (`'NUM'` pour `COUNT`) —
pattern `Pied_Mnt` de `002_SP_Designer_Exemple_FKM.sql:66-67`.

## 8. Ce que le format ne déploie JAMAIS (à documenter dans le manifest)

| Besoin | Pourquoi | Conduite |
|---|---|---|
| Habilitations (`Controle_Designer_Droit`) | Hors fichier par conception (`metadata.habilitations = "EXCLUES"`) | Onglet **Habilitations** du Designer après enregistrement (préservées en mise à jour) |
| `Figer_Statuts` | Absent du DTO et du Designer | UPDATE SQL ciblé post-enregistrement (survit aux re-saves : `Saving` ne le touche pas) |
| `Zoom_Condition`, `Recalc_Save` (≠ défaut `true`) | Absents du DTO ; le DELETE+INSERT de `Saving` les **réinitialise** | UPDATE SQL ciblé après **chaque** enregistrement |
| `Zoom_Retour`, `Regle_Visibilite`, `Regle_Activation` | Absents du DTO et du Designer | UPDATE SQL ciblé après chaque enregistrement |
| `GED_Categories` | Absent du DTO et du Designer | UPDATE SQL ciblé post-enregistrement |
| Section de menu absente | L'import ne crée pas de rubrique | Créer via `Zoom_SP_Nouvelle_Section` (ou écran des rubriques) **avant** l'enregistrement |
| Publication / désactivation | Transitions manuelles (`Publier` / `DESACTIVE`) | Boutons du Designer |
| Circuit de signatures workflow | Jamais généré (règle historique du module) | Écran `Workflow_Signatures` après publication |

Le skill **rejette** (erreur bloquante) toute clé d'input sans cible JSON
renseignée — jamais de perte silencieuse.
