# Sources métiers (`Controle_Designer_Source`) & paramètres — Référence exhaustive

Une **source métier** est une requête en lecture seule du catalogue sécurisé,
exécutée **uniquement côté serveur**, et consommée de trois façons : champ
`SOURCE` (valeur ramenée), **détail virtuel** (grille alimentée), règle de
validation `SOURCE`. Tout est vérifié dans le dépôt. Sources principales :
`RHP_Portail\rhpBE\modules\module_sp_engine.ts` (`executerSource` L.707-758,
`estRequeteLectureSeule` L.760-787),
`RHP_Portail\rhpBE\controlers\sp_document.ts` (`sp_exec_source` L.311-322),
`RHP_DeskTop\RHP\Portail\Zoom_SP_SqlSource.vb`,
`Zoom_SP_Assistant_ParamSource.vb`, `Zoom_SP_MappingSource.vb`,
`SP_Page_Designer.vb` (`VerifierTableVirtuelle` L.1176-1247).

---

## 1. Le catalogue `Controle_Designer_Source`

| Colonne | Rôle |
|---|---|
| `Cod_Source` (PK, ≤50) | Identifiant technique (identifiant SQL validé côté moteur). |
| `Libelle` | Libellé fonctionnel. |
| `Typ_Source` | `SQL` (requête) ou `PROC` (procédure `dbo.Sys_*`). Informatif : le garde-fou s'applique au texte dans les deux cas. |
| `Code_Sql` | Le texte de la requête / l'`EXEC`. **Jamais exposé au client** (`sp_page_meta` ne publie pas les requêtes). |
| `Parametres` | json `[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true}]` (§3). |
| `Typ_Retour` | `SCALAIRE` (défaut) ou `TABLE` (jeu de lignes — exigé pour un détail virtuel). |
| `Cod_Profile` | Profil requis ; `''` (défaut) = tous profils. Le profil `'1'` contourne (L.719-721). |
| `Actif` | `'false'` ⇒ source introuvable à l'exécution **et** publication bloquée pour tout champ/table qui la référence. |

Gestion (Designer, grille `Grd_Sources`) : `Code_Sql` et `Parametres` ne sont
**jamais saisis au clavier** — le zoom SQL (`Zoom_SP_SqlSource`, contrôle
d'injection en temps réel) et l'assistant de paramètres les produisent ;
**upsert par `Cod_Source`, jamais de suppression** depuis une page (catalogue
partagé entre pages).

## 2. Garde-fou lecture seule `estRequeteLectureSeule` (L.760-787)

Rejoué **à chaque exécution** (et en temps réel dans le zoom desktop). Règles
exactes, dans l'ordre :

1. **Nettoyage** : retrait des commentaires `/* … */` et `-- …`, compaction des
   espaces.
2. **Neutralisation des littéraux** : `'…'` (doublés `''` gérés) remplacés par
   `''` **avant** le contrôle multi-instructions — un `;` dans un littéral
   (ex. `'1;1;1'`) n'est pas un séparateur.
3. **Mono-instruction** : un `;` suivi de contenu ⇒ rejet
   (`Instruction multiple interdite`) ; `;` final toléré.
4. **Début imposé** : `select` / `with` (insensible à la casse) **ou**
   `exec[ute] dbo.Sys_<proc>` — seules les procédures `Sys_*` du schéma `dbo`
   sont appelables.
5. **Blacklist** (insensible à la casse) : `insert update delete merge drop
   alter create truncate grant revoke backup restore shutdown kill waitfor
   openrowset opendatasource xp_*`.
6. **Blacklist `sp_*`** : `\bsp_\w+\b` en **sensible à la casse** — les tables
   métier préfixées `SP_` (majuscules) restent **lisibles** dans une source ;
   seules les procédures système `sp_…` (minuscules) sont visées. Le garde
   d'entrée (point 4) interdit de toute façon tout appel de procédure hors
   `Sys_*`.

Une requête vide est admise côté desktop (source inerte) mais refusée par le
contrat du skill (`reference` requise).

## 3. Paramètres d'une source

### 3.1 Déclaration (`Parametres` json)

`[{"Nom":"Matricule","Typ":"nvarchar","Obligatoire":true}]`
- `Nom` **sans le `@`** ; identifiant SQL valide ; unicité.
- `Typ` : `nvarchar` (défaut) | `int` | `decimal` | `date` | `datetime` |
  `bit` (libellés de l'assistant : Texte / Nombre entier / Nombre décimal /
  Date / Date et heure / Oui-Non).
- `Obligatoire` : booléen json. Un paramètre obligatoire non alimenté bloque
  l'enregistrement du mapping (designer) — à l'exécution, un paramètre non
  alimenté vaut `null`.

### 3.2 Paramètres auto-injectés par le serveur (L.731-748)

| Paramètre | Injection | Valeur |
|---|---|---|
| `@id_Societe` | **TOUJOURS** (type `Int`) | Société de l'agent connecté. **INTERDIT de le déclarer** dans `Parametres` (blocant : assistant L.232-234 + validateur du skill). |
| `@Login` | si **non déclaré** | Login de l'agent connecté. |
| `@Matricule` | si **non déclaré** | Matricule de l'agent connecté. |
| `@Cod_Profile` | si **non déclaré** | Profil de l'agent connecté. |

**Déclarer** `@Login`/`@Matricule`/`@Cod_Profile` permet de les alimenter
depuis un champ de la page (ex. matricule d'un *autre* salarié via le mapping)
au lieu de l'identité connectée. ⚠️ Une **faute de frappe** sur ces trois noms
(ex. `@Matricul`) rebascule silencieusement sur l'identité connectée — l'assistant
contrôle donc la cohérence `@xxx` déclarés ↔ `@xxx` utilisés dans la requête
(déclaré non utilisé ⇒ erreur ; utilisé non déclaré et non auto-injectable ⇒
erreur ; auto-injectable ⇒ avertissement).

### 3.3 Binding à l'exécution

- Typage : `Typ` commençant par `int` ⇒ `sql.Int`, sinon `sql.NVarChar` ;
  les valeurs `Date` internes sont sérialisées **ISO** avant binding (le chemin
  HTTP/JSON les amène déjà en chaînes).
- Ordre : `@id_Societe` d'abord, puis les paramètres déclarés (dans l'ordre du
  json), puis les auto-injectés manquants.
- Toutes les valeurs passent en **paramètres typés** — jamais de concaténation.

## 4. Exécution `executerSource` (L.707-758)

1. `Cod_Source` validé (identifiant) ; source **existante et active**.
2. Contrôle de **profil** : `Cod_Profile` non vide et ≠ profil de l'agent (et
   agent ≠ `'1'`) ⇒ refus « non autorisée pour ce profil ».
3. Garde lecture seule (§2) rejoué.
4. Binding (§3.3) puis exécution.
5. Retour : `valeur` = **première colonne de la première ligne** (usage
   SCALAIRE) ; `data` = toutes les lignes (usage TABLE) ; `typRetour`.
6. Erreur SQL ⇒ `{ok:false}` (l'appelant décide : champ source en échec au
   save ⇒ enregistrement refusé ; validation SOURCE ⇒ règle poussée ;
   détail virtuel ⇒ grille vide côté lecture client, **refus au save** serveur).

Endpoint client : `POST /api/sp_exec_source` `{codSource, params}` ⇒
`{result, data: [{valeur}] | lignes}` (`sp_document.ts` L.311-322).

## 5. Usage 1 — champ `SOURCE` (entête)

Un champ `Typ_Controle='SOURCE'` ramène une valeur calculée par la source :

- `Source_Metier` = `Cod_Source` ; la **formule** porte le mapping :
  ```json
  {"source":"SRC_TX_KM","mapping":{"Annee":{"ref":"Annee"},"Societe":{"const":"1"}}}
  ```
  Chaque entrée du mapping est évaluée par `operande()` : `{"ref":"ColonneEntete"}`
  ou `{"const":"valeur"}` (constantes **toujours chaînes** depuis l'assistant).
- **Client** (`DynamicPage.tsx` L.224-261) : la source est (ré-)exécutée dès
  qu'une valeur mappée change (`depsSources`) ; la valeur reçue alimente le
  contexte puis **cascade SOURCE → CALCULE** (recalcul ciblé des calculés qui
  la référencent).
- **Serveur** (`enregistrerDocument` L.1105-1124) : pour un champ SOURCE
  d'entête **persisté** avec `Recalc_Save='true'` (défaut), la source est
  **ré-exécutée au save** et sa valeur fait foi (la valeur postée n'est jamais
  crue) ; échec ⇒ enregistrement refusé. `Recalc_Save='false'` ⇒ la valeur
  postée est persistée telle quelle (à n'utiliser que si la valeur peut
  légitimement figer).
- Rendu readonly + `Format_Affichage`/`Decimales` comme un CALCULE.
- Le Designer desktop n'a **pas d'assistant** pour le mapping d'un champ
  SOURCE (le json est saisi dans la grille ; l'assistant de mapping est
  réservé aux tables) — le générateur doit donc produire un json
  rigoureusement conforme.

## 6. Usage 2 — détail VIRTUEL (SP4)

`Controle_Designer_Table.Source_Metier` + `Source_Mapping` : une grille de détail
**sans table physique**, alimentée en lecture seule par une source TABLE.

- **Exigences** (`VerifierTableVirtuelle`, designer L.1176-1247 — rejouées à
  l'enregistrement et à la publication) :
  - réservé aux tables `Role_Table='DET'` (**jamais ENT** — l'entête est
    toujours physique) ;
  - source existante, **active**, **`Typ_Retour='TABLE'`** ;
  - `Source_Mapping` json objet `{"Param":{"ref":"ColonneEntete"}|{"const":"…"}}` ;
    chaque paramètre mappé est **déclaré** dans la source ; chaque `ref` existe
    parmi les **colonnes d'entête** (métier + techniques `Num_Doc, id_Societe,
    Statut, Dat_Crea, Created_By, Dat_Modif, Modified_By` — **RV exclu**) ;
    chaque paramètre **obligatoire** est alimenté ;
  - nom physique dérivé : `SP_<CodDocument>_Virt_<Cod_Table>` ; **aucune table
    n'est créée** (exclue du DDL) ; les `Allow_Add/Edit/Delete/Duplicate` sont
    forcés à `'false'` ;
  - si la page existait déjà avec une **table physique** pour ce détail,
    l'enregistrement est bloqué (le designer refuse la bascule).
- **Lecture** (`lireDocument` L.1018-1034) : mapping résolu sur l'entête lue,
  source exécutée, lignes reçues avec `RowId` synthétique 1..n ; échec ⇒
  grille vide.
- **Client** (`DynamicPage.tsx` L.263-299) : ré-exécution dès qu'une valeur
  mappée change ; recalcul ciblé des calculés impactés.
- **Enregistrement** : le client **ne poste jamais** les lignes d'un détail
  virtuel ; le serveur **ré-exécute la source** (mapping sur l'entête
  recalculée) **avant les validations** — les règles (NB_LIGNES, EXPR avec
  agrégats…) portent donc sur les lignes de la source, jamais sur des lignes
  client (L.1134-1153). Échec de la source ⇒ enregistrement refusé.
- Cas d'usage vérifié : découpe d'un congé par période de paie
  (`006_SP_Designer_Evolutions.sql` P2).

## 7. Usage 3 — validation `SOURCE`

Contrôle par source (`module_sp_engine.ts` L.937-949) :

```json
{"source":"SRC_SOLDE","mapping":{"Matricule":{"ref":"Matricule"}},
 "cond":{"op":"GE","args":[{"ref":"@result"},0]}}
```

- Exécutée **au save, côté serveur uniquement** (jamais au client).
- `mapping` : mêmes formes `ref`/`const`, évaluées dans le contexte document.
- Le résultat scalaire est injecté comme `{"ref":"@result"}` dans `cond` ;
  `cond` absente ⇒ seul l'échec d'exécution compte.
- Échec d'exécution ⇒ règle **poussée** (bloquante si `Niveau='B'`).
- L'assistant de validation ne gère pas ce type (« trop spécifique ») : json
  saisi directement — le générateur doit produire la forme exacte ci-dessus.

## 8. Zooms et listes (complément paramètres)

| Mécanisme | Colonnes | Détail |
|---|---|---|
| `RUBRIQUE` / `RADIO` | `Rubrique` | `Param_Rubriques.Nom_Controle` ; options `(Valeur, Membre)` triées par `Rang` ; existence vérifiée à la publication. |
| `ZOOM` / `COMBO` | `Num_Zoom` | `Controle_Def_Zoom` (socle) ; existence vérifiée à la publication. |
| Retour de zoom | `Zoom_Retour` | json `{"ChampCible":"ColonneZoom"}` : au choix, alimente d'autres champs. |
| **Condition de zoom (SP4)** | `Zoom_Condition` | Condition texte avec **placeholders `{Champ}`** remplacés par les valeurs courantes de l'**entête** (`DynamicField.tsx` L.76-78 : `{X}` → `ctx.entete[X]`, vide si absent). Ex. vérifié : `Matricule='{Matricule}'`. COMBO et ZOOM. ⚠️ Non éditable dans le Designer desktop et **absente du format d'import JSON** (`references/json-import-format.md` §8) — clé `zoom_condition` bloquée à la validation. |

## 9. Règles de génération pour le skill (checklist sources)

1. Toute source de l'`input` **référencée par la page** ⇒ `businessSources[]`
   du fichier (catalogue partagé : le `Saving` fusionne par `Cod_Source`,
   upsert, **jamais de suppression**) ; l'import re-vérifie existence +
   `Actif` + cohérence `Typ_Retour` avec l'usage (TABLE pour un détail
   virtuel) et signale les dépendances non résolues en avertissements.
2. `Code_Sql` doit passer le garde §2 **tel que le moteur le rejoue** :
   littéraux neutralisés avant le test multi-instructions ; `sp_*` interdit en
   minuscules mais `SP_` (tables métier) autorisé ; `EXEC dbo.Sys_*` seul
   appel de procédure.
3. `Parametres` : jamais `id_Societe` ; `Nom` sans `@`, identifiant valide ;
   sérialisation exacte `[{"Nom":…,"Typ":…,"Obligatoire":…}]` (toute autre
   forme = bloquant à l'import) ; documenter au manifeste les auto-injections
   (§3.2) et l'effet d'une déclaration `Login`/`Matricule`/`Cod_Profile`
   (alimentation par champ).
4. Champ SOURCE : `Formule` = `{"source", "mapping"}` avec `source` =
   `Source_Metier`/`data_source_code` ; `ref` = colonnes d'**entête** ;
   rappeler la ré-exécution serveur au save si persisté + `Recalc_Save='true'`.
5. Détail virtuel : vérifier §6 (TABLE, mapping complet des obligatoires,
   refs d'entête) ; `Allow_*` à `false` ; colonnes **logiques** déclarées
   (l'import exige ≥ 1 colonne par table) ; **aucune table physique** (le DDL
   du `Saving` l'ignore) ; nom physique `SP_<doc>_Virt_<table>`.
6. Validation SOURCE : forme §7 ; rappeler qu'elle est serveur-only et qu'un
   échec technique bloque si `B`.
7. `Zoom_Condition` : **[NO-JSON-TARGET]** absente du format d'import —
   `zoom_condition` est une erreur bloquante à la validation
   (`references/json-import-format.md` §8).
