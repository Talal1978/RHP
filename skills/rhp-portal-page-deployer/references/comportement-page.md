# Comportement d'une page SP_ — Référence exhaustive

Cycle de vie, états, règles dynamiques, validations, droits et liste — tout est
**vérifié** dans le dépôt. Sources principales :
`RHP_Portail\rhpfe\src\Pages\Dynamic\DynamicPage.tsx` (L.),
`RHP_Portail\rhpfe\src\Pages\Dynamic\dynamicEngine.ts` / `DynamicField.tsx`,
`RHP_Portail\rhpBE\modules\module_sp_engine.ts`,
`RHP_Portail\rhpBE\controlers\sp_document.ts`,
`RHP_DeskTop\RHP\Portail\SP_Page_Designer.vb` et
`Zoom_SP_Assistant_Validation.vb`.

---

## 1. États et règles dynamiques des champs

### 1.1 `Etat` (CK_SPChamp_Etat)

| Code | Signification | Effet client |
|---|---|---|
| `S` | Saisissable | Visible + modifiable (sauf règle d'activation / lecture seule globale). |
| `R` | Lecture seule | Visible, **jamais** modifiable (`champActif` retourne faux, `dynamicEngine.ts` L.547-551). |
| `A` | Affiché | Idem `R` — convention pour CALCULE/SOURCE. |
| `I` | Invisible | Jamais rendu (`champVisible` retourne faux, L.542-546). |

Les types `CALCULE` et `SOURCE` sont **toujours en lecture seule** à l'écran,
quel que soit `Etat` (`DynamicField.tsx` L.71).

### 1.2 `Regle_Visibilite` / `Regle_Activation` (json AST de condition)

Même langage déclaratif que les formules (opérateurs logiques uniquement en
pratique — voir `formules-calculees.md` §3), évalué **dans le contexte
document** (entête + lignes), ré-évalué à chaque saisie :

- `Regle_Visibilite` : `Etat<>'I'` ET règle vraie (ou absente) ⇒ champ rendu.
- `Regle_Activation` : `Etat='S'` ET règle vraie (ou absente) ⇒ champ
  modifiable. S'ajoute à la lecture seule globale du document (§5.4).
- **Exception d'évaluation ⇒ règle ignorée** (champ visible / actif) — une
  règle invalide ne verrouille jamais l'écran (L.545, 550).
- Exemple : n'afficher « Motif refus » que si `Etat = 'R'` ⇒
  `{"op":"EQ","args":[{"ref":"Etat"},{"const":"R"}]}`.
- S'appliquent aussi aux **pieds de grille** (`DynamicPage.tsx` L.645).

### 1.3 Aide et obligation

- `Aide` (≤300) ⇒ tooltip du contrôle.
- `Obligatoire='true'` ⇒ libellé suffixé de « * » (`libelleChamp`,
  `DynamicField.tsx` L.21-23) — mais **n'exécute aucun contrôle** : ajouter
  toujours une validation `REQUIRED` (§3) pour faire respecter l'obligation.

## 2. Comportements par type de contrôle (`DynamicField.tsx` L.80-167)

| Typ_Controle | Rendu | Particularités |
|---|---|---|
| `TEXT` / `MEMO` | TextBox (MEMO : 3 lignes) | — |
| `INT` | TextBox `type=integer` | — |
| `DEC` / `MNT` | TextBox `type=number` | `Decimales` pilote l'affichage en grille/pied |
| `DATE` / `DATETIME` | CalendarZoom (DATETIME : avec heure) | Effacement ⇒ `""` |
| `CHECK` | Case à cocher | Valeurs reconnues vraies : `true`, `1`, `"1"`, `"true"` ; défaut `false` si pas de `Valeur_Defaut` |
| `RADIO` | Groupe de boutons radio | Options = rubrique `Param_Rubriques` (obligatoire) ; valeur stockée = `Valeur` |
| `RUBRIQUE` | ComboBox sur rubrique | Idem : `Rubrique` obligatoire |
| `COMBO` | ComboBox sur zoom | `Num_Zoom` obligatoire ; `Zoom_Condition` filtrante (voir `sources-metier.md` §8) |
| `ZOOM` | TextZoom (saisie + zoom avec libellé) | `Num_Zoom` obligatoire ; `Zoom_Retour` json `{"ChampCible":"ColonneZoom"}` alimente d'autres champs au choix |
| `CALCULE` / `SOURCE` | TextBox readonly, valeur formatée | Jamais saisissables ; rendu via `Format_Affichage`/`Decimales` (`formules-calculees.md` §12.5) |
| `GED` | Bouton « Pièces jointes » | Ouvre la GED du document (exige document existant + droit GED) |

## 3. Validations déclaratives (`Controle_Designer_Validation`)

Moteur : serveur `executerValidations` (`module_sp_engine.ts` L.789-959) ;
client `validerClient` (`dynamicEngine.ts` L.407-540). **Le serveur rejoue
TOUTES les règles actives à l'enregistrement, quel que soit leur `Moment`**
(L.1155) — les moments ne pilotent que le confort client.

### 3.1 Les 13 types de règle et le json exact de `Parametres`

Formes vérifiées (assistant `Zoom_SP_Assistant_Validation.vb` L.409-489 +
moteur L.823-952) :

| Typ_Regle | `Parametres` json | Sémantique |
|---|---|---|
| `REQUIRED` | `NULL`/vide | KO si `null`/`undefined`/chaîne trimmée vide. |
| `IN` | `{"valeurs":[…]}` | KO si valeur non vide **∉** liste (comparaison stricte `includes` — l'assistant **double chaque nombre en nombre ET en texte**, ex. `["A",5,"5"]`, car la comparaison est stricte). |
| `MIN` / `MAX` | `{"valeur":N}` | KO si `num(valeur)` </> N (valeur vide ignorée). |
| `BETWEEN` | `{"min":A,"max":B}` | KO si hors [A,B] (valeur vide ignorée). |
| `MINLEN` / `MAXLEN` | `{"valeur":N}` | KO si `String(valeur).length` </> N (`null` ignoré). |
| `REGEX` | `{"pattern":"^…$"}` | KO si non vide et ne matche pas. Pattern invalide ⇒ règle **ignorée** (client) / blocante si B (serveur, exception). Presets de l'assistant : e-mail `^[^@\s]+@[^@\s]+\.[^@\s]+$`, tél. FR `^0\d{9}$`, CP `^\d{5}$`, chiffres `^\d+$`, lettres `^[A-Za-zÀ-ÿ\s'\-]+$`. |
| `COMPARE` | `{"operateur":"GT|GE|LT|LE|EQ|NE","autre":"NomColonne"}` **ou** `{"operateur":…,"constante":X}` | Compare la valeur du champ ciblé à un autre champ (via `{"ref"}`) ou à une constante, en réutilisant l'évaluateur (`cmp` intelligent). |
| `UNIQUE` | `{"colonnes":["C1","C2"]}` | Portée **DETAIL** : pas deux lignes avec la même combinaison (clé = valeurs jointes par `\|` ; ligne toute vide ignorée). Contrôle **en mémoire**, pas d'index SQL. |
| `NB_LIGNES` | `{"min":1}` et/ou `{"max":5}` | Portée **DETAIL** : nombre de lignes du détail dans [min,max]. |
| `EXPR` | `{"expr":{…AST…}}` | Expression booléenne déclarative (agrégats autorisés) devant être vraie ; portée LIGNE ⇒ évaluée par ligne, sinon au niveau document. |
| `SOURCE` | `{"source":"CodSource","mapping":{"P":{"ref":"Champ"}},"cond":{…AST…}}` | Exécute une source du catalogue ; KO si exécution en échec **ou** si `cond` fausse sur le résultat (référencé `{"ref":"@result"}`). **Serveur uniquement** — jamais jouée côté client (`dynamicEngine.ts` L.533). Voir `sources-metier.md` §7. |

### 3.2 `Condition_Regle` — condition d'application

AST de condition évaluée **avant** la règle ; absente ⇒ règle toujours
appliquée ; exception ⇒ règle appliquée (fail-open côté condition). Forme
produite par l'assistant (L.493-548) :

- Une ligne « Champ / Condition / Valeur » ⇒
  `{"op":"GE","args":[{"ref":"NomColonne"},5]}` (la valeur peut être
  `{"ref":"AutreColonne"}`).
- Opérateurs proposés : « est renseigné » `NOTEMPTY`, « est vide » `EMPTY`,
  « est égal à » `EQ`, « est différent de » `NE`, « est supérieur à » `GT`,
  « …ou égal à » `GE`/`LE`, « est inférieur à » `LT`, « contient » `CONTIENT`.
- Plusieurs lignes combinées en `AND` (« Toutes les conditions ») ou `OR`
  (« Au moins une »).
- Pour EXPR, la condition vit dans `Parametres.expr` (pas de `Condition_Regle`).

### 3.3 `Portee`, `Cod_Table`, `Cod_Champ`

| Portee | Cible | Effet |
|---|---|---|
| `CHAMP` | `Cod_Table='ENT'` + `Cod_Champ` | Test sur la valeur d'entête du champ. |
| `LIGNE` | `Cod_Table=<det>` + `Cod_Champ` | Test **pour chaque ligne** du détail (l'erreur remporte l'index de ligne : « Ligne n : … »). |
| `DETAIL` | `Cod_Table=<det>` | Règle sur l'ensemble des lignes (NB_LIGNES, UNIQUE). |
| `ENTETE` | `Cod_Table='ENT'` | Règle d'ensemble sur l'entête (EXPR sans agrégat…). |
| `DOCUMENT` | — | Règle globale (EXPR avec agrégats, cohérence entête/détails). |

Dérivation pratiquée par l'assistant : `NB_LIGNES`/`UNIQUE` ⇒ `DETAIL` ;
`EXPR` ⇒ `DOCUMENT` ; champ d'entête ⇒ `CHAMP` ; champ de détail ⇒ `LIGNE`.

### 3.4 `Niveau` et `Moment`

- `Niveau` : `B` = **bloquant** (défaut — empêche l'enregistrement) ;
  `W` = avertissement (confirmation « Voulez-vous continuer ? » au save client,
  remontés dans `avertissements` par le serveur) ; `I` = information simple.
  **Une règle en échec technique bloque par sécurité si niveau B** (serveur,
  L.953-956).
- `Moment` (rubrique `SP_Moment_Valid`) — filtre **client** uniquement
  (`dynamicEngine.ts` L.424-427) :
  - `SAISIE` : jouée à la saisie — jamais au SAVE client (exclue du filtre SAVE) ;
  - `CHANGE` : au changement d'un champ — **seules les règles ciblant le champ
    modifié** sont rejouées ;
  - `AJOUT_LIGNE` : à l'ajout d'une ligne de détail (un échec bloquant annule
    l'ajout, `DynamicPage.tsx` L.334-338) ;
  - `SAVE` : à l'enregistrement — rejoue **toutes les règles sauf SAISIE**.
- Le serveur ignore `Moment` : tout est rejoué à l'enregistrement. Les règles
  inactives (`Actif<>'true'`) ne sont jamais chargées (L.250).

## 4. Grilles de détail (`Controle_Designer_Table`)

### 4.1 Flags d'édition

| Flag | Défaut | Effet client (`DynamicPage.tsx` L.605-654) |
|---|---|---|
| `Allow_Add` | `'true'` | Bouton « Ajouter » (validations AJOUT_LIGNE avant insertion). |
| `Allow_Edit` | `'true'` | `'false'` ⇒ **toute la grille en lecture seule**. |
| `Allow_Delete` | `'true'` | Bouton « Supprimer » (arme le mode suppression, confirmation par ligne). |
| `Allow_Duplicate` | `'false'` | Bouton « Dupliquer » (copie la ligne sélectionnée avec `RowId=0` ⇒ ré-insérée). |
| `Tri_Defaut` | `''` | ORDER BY de lecture, ex. `'Dat_Jour asc'` — **noms de colonnes validés** (`verifierTri`, L.1050-1064 : identifiants déclarés uniquement, `asc`/`desc`, repli `[RowId] asc`). |
| `Regle_Suppression` | `CASCADE` | Voir §5.5. |

Dans la grille, une colonne est en lecture seule si : grille en lecture seule,
**ou** `Etat<>'S'`, **ou** champ `CALCULE`/`SOURCE` (L.385). Types de colonnes :
`Combo` (RUBRIQUE/COMBO), `Check` (CHECK), `Calendar` (DATE/DATETIME), `Text`
sinon ; `dataSource` = rubrique pour RUBRIQUE. **Un champ sans `Nom_Colonne`
n'est jamais une colonne de la grille** (c'est un pied de grille).

### 4.2 Détail VIRTUEL (SP4)

`Source_Metier` + `Source_Mapping` sur la table : grille **alimentée par une
source** `Typ_Retour='TABLE'`, en lecture seule forcée, sans table physique.
Comportement complet dans `sources-metier.md` §6.

## 5. Cycle de vie d'un document

### 5.1 Création et numérotation

- URL `/myspace/SPP_<Cod_Page>/<titre>/new` ; valeurs initiales = `Valeur_Defaut`
  des champs (§7) puis recalcul complet.
- `Num_Doc` attribué **par le serveur uniquement** au premier enregistrement :
  `<CodDocument><idSociete>-<aaaa><seq 6>`, séquence annuelle par société avec
  verrou (`updlock, holdlock`, L.987-998). Les scripts ne l'écrivent jamais.

### 5.2 Enregistrement (transaction unique, `enregistrerDocument` L.1067-1313)

Ordre exact : 1) nettoyage des entrées (seules les colonnes déclarées) ;
1.b) colonnes techniques exposées au contexte (`Num_Doc`, `Statut`,
`Created_By` — permettent p. ex. une règle de chevauchement qui s'exclut
elle-même) ; 1.c) **ré-exécution des champs SOURCE persistés** ; 2) **recalcul
serveur complet** (cycle ⇒ refus) ; 2.b) **ré-exécution des détails virtuels** ;
3) **validations serveur** (une erreur `B` ⇒ refus, message multi-lignes
« Ligne n : … ») ; 4) écriture : numérotation + contrôle de concurrence,
upsert entête, upsert lignes par `RowId` puis **purge des lignes absentes**,
soumission workflow éventuelle — le tout dans UNE transaction.

- **Concurrence optimiste** : `RV rowversion` — le client renvoie le RV lu ; le
  UPDATE pose `WHERE [RV]=@p_rv` ; 0 ligne affectée ⇒
  « Document modifié par un autre utilisateur. Rechargez la page. »
- **Verrou portail** (convention) : `check_accessible`/`release_accessible`
  sur `SPP_<Cod_Page>` — le bouton « Accessible » signale l'utilisateur tenant
  le document (`DynamicPage.tsx` L.194-199, 540).
- `statut='SS'` (soumission) ⇒ droit `Valider` requis + `Act_Soumettre='true'`
  + `Workflow_Actif='true'` ; le statut enregistré devient `SS` et
  `Sys_Workflow_Signature` est exécuté **dans la même transaction**.
- Une préparation de paie en cours (`is_paie_encours`) bloque l'enregistrement
  côté client (convention portail, L.433-437).

### 5.3 `Figer_Statuts` (SP4)

CSV de statuts figeant le document, défaut `'SG,RJ,SP,VA'` (signé, rejeté,
suspendu, validé). Un document dont le statut ∈ liste : **modification et
suppression refusées** (serveur L.1191-1194, 1336-1339 ; client `canSave`
L.421-424). Ex. `'SS,SG,RJ,SP,VA'` fige **dès la soumission** (comme les pages
standards). ⚠️ Non éditable dans le Designer desktop et **absent du format
d'import JSON** (`references/json-import-format.md` §8) — clé `freeze_statuses`
bloquée à la validation ; ne peut être posé que par UPDATE SQL ciblé.

### 5.4 Lecture seule globale (client)

`canSave` = verrou d'accès OK **ET** statut non figé **ET** droit (`Creer` si
nouveau, `Modifier` sinon). `canSave` faux ⇒ tout le document en lecture seule
(`readonlyGlobal`), boutons d'ajout/suppression de lignes désactivés.

### 5.5 Suppression (`supprimerDocument` L.1316-1371)

- Document figé ⇒ refus. Introuvable ⇒ refus.
- Pour chaque détail physique : `Regle_Suppression='RESTRICT'` ⇒ refus si des
  lignes existent (« Des lignes existent dans '<libellé>'… ») ; sinon DELETE
  des lignes (complète la FK `ON DELETE CASCADE` créée si `CASCADE`).
- Puis DELETE de l'entête. Transaction unique.
- Côté métadonnées (hors document) : une page **BROUILLON** seulement peut être
  supprimée structurellement, et **jamais si des documents existent**
  (`SP_Page_Designer.Deleting`) ; une page publiée se retire par
  `Statut_Page='DESACTIVE'`. Les tables `SP_*` ne sont **jamais** droppées.

## 6. Droits et actions de page

### 6.1 Droits par profil (`Controle_Designer_Droit`)

- Flags `'true'/'false'` : `Consulter, Creer, Modifier, Supprimer, Valider,
  Imprimer, GED`. Vérifiés à chaque endpoint (`metaPubliee`).
- Profil `'1'` = super-admin : **contourne tout** (convention RHP).
- `Acces_Personnalise='false'` ⇒ **consultation ouverte à tous les profils**
  (y compris futurs) ; les autres actions restent conditionnées aux droits.
- Contrôle de publication : `Acces_Personnalise='true'` sans aucun
  `Consulter='true'` ⇒ page invisible pour tous ⇒ **publication bloquée**.
- Action requise par endpoint : liste/lecture ⇒ `Consulter` ; enregistrement ⇒
  `Creer` (sans Num_Doc) / `Modifier` ; soumission ⇒ `Valider` ; suppression ⇒
  `Supprimer` ; validation à blanc ⇒ `Modifier` ; impression/GED ⇒ `Imprimer`/`GED`.

### 6.2 Actions de page (`Act_*`) et FAB

Le FAB `FloatMenu` est alimenté par `settbnMenu` (`DynamicPage.tsx` L.536-570) :

| Bouton FAB | Condition d'apparition | Comportement |
|---|---|---|
| Accessible | verrou détenu par un autre | Affiche le tenant du document |
| Enregistrer | `Act_Enregistrer='true'` | Save avec statut inchangé ; `disabled` si `canSave` faux |
| Nouveau | droit `Creer` | Abandon confirmé si modifications ; reset |
| Supprimer | droit `Supprimer` | Refus si figé ; confirmation ; retour à `new` |
| Imprimer | `Act_Imprimer='true'` **et** droit `Imprimer` | `Cod_Modele_Edition` renseigné ⇒ viewer Crystal (`/viewer`, param `NumDoc`) ; sinon **impression générique par les métadonnées** (`SpPrintDialog`) ; `disabled` sur nouveau |
| Soumettre pour signature | `Act_Soumettre='true'` **et** `Workflow_Actif='true'` **et** droit `Valider` | Statut `''`/`NSS` ⇒ confirmation puis save `'SS'` ; sinon ouvre le suivi des signatures. Libellé = rubrique `Statut_Signature` du statut courant |
| Pièces jointes | `GED_Actif='true'` **et** droit `GED` | GED sur `SPP_<Cod_Page>` / Num_Doc ; `disabled` sur nouveau |

`Act_Exporter` n'est câblé nulle part dans le frontend (métadonnée seule).

## 7. Valeurs par défaut (`Valeur_Defaut`)

Évaluées **au reset/nouveau** côté client (`valeurInitiale`, `DynamicPage.tsx`
L.35-53) :

| `Valeur_Defaut` | Valeur initiale |
|---|---|
| `GV_MATRICULE` | Matricule de l'agent connecté |
| `GV_NOW` | Date/heure du navigateur |
| `GV_LOGIN` | Login de l'agent connecté |
| constante numérique (INT/DEC/MNT) | nombre (`,` acceptée ; invalide ⇒ 0) |
| `true`/`1` (CHECK) | case cochée |
| autre chaîne | chaîne telle quelle |
| vide | `false` (CHECK) ou `""` |

Côté **DDL** (`Module_SP_DDL.DefautSQL`) : seul `GV_NOW` est reconnu ⇒
`DEFAULT (getdate())` ; sinon littéral numérique / bit (`1`,`true`) / chaîne
échappée ; `NOT NULL` sans défaut ⇒ `(0)` numériques/bit, `('')` sinon.

## 8. Liste des documents (`DynamicPage_Liste` + `sp_document_liste`)

- URL `/myspace/SPPL_<Cod_Page>/<titre>`. Colonnes : `N°`, `Statut`
  (**libellé rubrique `Statut_Signature`** via `dbo.FindRubrique`), champs
  d'entête `Visible_Grille='true'` triés par `Rang_Grille` (alias = `Libelle`),
  `Créé le`, `Créé par`. **Jointure agent automatique** : si une colonne
  `Matricule` existe, le nom de l'agent (`Nom_Agent + ' ' + Prenom_Agent` via
  `RH_Agent`) est inséré juste après (L.144-148, 216-219).
- **Critères** (`estCritere='true'`, triés par `Rang_Critere`) — filtres
  paramétrés et typés, jamais de SQL libre :
  - colonne **date** ⇒ plage `<col>__Du` / `<col>__Au` (`convert(date,…) >= / <=`) ;
    une date seule ⇒ égalité sur le jour ;
  - colonne **numérique** ⇒ égalité ; **texte** ⇒ `LIKE '%…%'` ;
  - un champ d'entête lié à la colonne technique **`Statut`** déclaré critère ⇒
    filtre préfixe `Statut LIKE '…%'` (L.160-163, 184-188).
- **Cloisonnement** : si la table a une colonne `Matricule` et que l'agent
  n'est ni `TeamLeader` ni profil `'1'`, il ne voit que **ses** documents
  (`t.Matricule=@p_mat`, L.210-213).
- Pagination `OFFSET/FETCH` (page/pageSize, max 200), tri `Dat_Crea desc`.

## 9. Impression

- `Act_Imprimer='true'` + `Cod_Modele_Edition` ⇒ rapport Crystal
  `Param_Mod_Edition.Cod_Report` avec paramètre `NumDoc`.
- `Act_Imprimer='true'` sans modèle ⇒ **impression générique** construite
  depuis les métadonnées (`SpPrintDialog`).
- `Act_Imprimer` sans `Cod_Modele_Edition` reste cohérent ; l'inverse
  (modèle sans action) est inutile. Le droit `Imprimer` filtre l'accès.

## 10. Checklist comportement pour le générateur

1. `Obligatoire='true'` ⇒ **toujours** accompagner d'une validation
   `REQUIRED` (même cible) — sinon l'obligation n'est qu'visuelle.
2. `Etat` cohérent avec l'usage : `A` pour CALCULE/SOURCE, `S` pour la saisie,
   `R` pour une donnée affichée non modifiable, `I` pour une donnée technique
   (ex. champ lié à `Statut` si on ne veut pas l'afficher).
3. Règles dynamiques (`Regle_Visibilite`/`Regle_Activation`) = AST de
   condition whitelisté (§1.2) ; rappeler au manifeste qu'elles sont
   ré-évaluées à chaque saisie et qu'une exception les neutralise.
4. Choisir `Moment` en connaissance : `SAVE` par défaut ; `CHANGE` pour le
   confort sur un champ ; rappeler que **le serveur rejoue tout** — le moment
   n'allège que le client.
5. `IN` : doubler les nombres en nombre+texte dans `valeurs` (comparaison
   stricte).
6. `Figer_Statuts` : inclure `SS` pour figer dès soumission ; laisser le
   défaut `'SG,RJ,SP,VA'` pour permettre la correction avant signature.
7. Détail : définir les 4 `Allow_*` selon le besoin ; `Tri_Defaut` avec des
   colonnes du bloc ; `Regle_Suppression='RESTRICT'` pour interdire la
   suppression d'un document qui a des lignes.
8. Droits : au moins un profil avec `Consulter` si `Acces_Personnalise='true'`
   (contrôle de publication) ; `Valider` inutile sans workflow ; `Imprimer`
   inutile sans `Act_Imprimer`.
9. Liste : marquer `estCritere` les champs de recherche usuels (dates ⇒ plages
   automatiques) ; penser au cloisonnement `Matricule` (automatique si la
   colonne existe) et au nom d'agent (automatique).
10. Actions FAB : `Act_Soumettre` exige `Workflow_Actif` ; `Act_Imprimer` avec
    modèle exige `Cod_Modele_Edition` ; vérifier après déploiement que le FAB
    s'affiche sur la page (vérification permanente du portail — AGENTS.md).
