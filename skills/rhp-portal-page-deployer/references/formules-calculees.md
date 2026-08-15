# Logique des formules (champs CALCULE) — Référence exhaustive

Tout ce qui suit est **vérifié** dans les sources du dépôt. Deux moteurs
**miroirs** exécutent les formules :

| Moteur | Fichier | Rôle |
|---|---|---|
| Serveur (Node/TS) | `RHP_Portail\rhpBE\modules\module_sp_engine.ts` (`evaluer` L.414-579, `recalculer` L.679-697) | **Fait foi.** Recalcule tout à la lecture (`sp_get_document`) et à l'enregistrement ; la valeur postée par le client n'est jamais crue. |
| Client (React/TS) | `RHP_Portail\rhpfe\src\Pages\Dynamic\dynamicEngine.ts` (`evaluer` L.116-273, `recalculer` L.347-397) | Confort temps réel (recalcul ciblé à chaque saisie). Même sémantique, ligne à ligne. |
| Assistant (design-time) | `RHP_DeskTop\RHP\Portail\Zoom_SP_Assistant_Formule.vb` | Parser français → json + évaluateur miroir VB (test avant enregistrement). |

Règle d'or : **aucun `eval`, aucun code libre**. Une formule est un arbre json
déclaratif, whitelisté à la génération (`validerExpression`,
`module_sp_engine.ts` L.581-602) et rejoué tel quel par les deux moteurs.

---

## 1. Format de l'arbre (AST json)

Stocké dans `SP_Page_Champ.Formule` (nvarchar(max)). Quatre formes de nœuds :

| Forme | Exemple | Évaluation (`operande`, L.330-342) |
|---|---|---|
| Référence | `{"ref":"Km"}` | Valeur du champ. **Dans une ligne de détail** : la colonne de la ligne courante si elle y existe, sinon l'entête. **Hors ligne** : l'entête (`ctx.entete[ref]`). Clé de stockage = `Nom_Colonne`, sinon `Cod_Champ` (`cleChamp`, L.609-611). |
| Référence spéciale | `{"ref":"@result"}` | Résultat scalaire de la source d'une règle `SOURCE` (validations uniquement — voir `sources-metier.md`). |
| Variable globale | `{"ref":"GV_NOW"}` | Résolue par `variableGlobale()` (§4). Préfixe `GV_` testé AVANT la ligne/entête. |
| Constante | `{"const":2}` ou littéral brut (`2`, `"texte"`, `true`) | Valeur telle quelle. Un nœud non-objet (nombre, chaîne) EST une constante. |
| Opération | `{"op":"MUL","args":[…]}` | `evaluer()` selon la whitelist (§5-§7). Certains ops portent des attributs hors `args` : `table`/`colonne` (agrégats), `unite` (DATEDIFF/DATEADD), `partie` (DATEPART). |

Exemple vérifié (`002_SP_Designer_Exemple_FKM.sql` L.62-63) — montant de ligne
`Km × Tx` arrondi à 2 décimales :

```json
{"op":"ROUND","args":[{"op":"MUL","args":[{"ref":"Km"},{"ref":"Tx"}]},{"const":2}]}
```

Contraintes structurelles :

- Profondeur maximale : **20 niveaux** (`validerExpression`, L.582 ; même borne
  dans le parser de l'assistant, `Zoom_SP_Assistant_Formule.vb` L.577).
- Opérateur inconnu ⇒ rejet à la validation serveur (`Opérateur déclaratif non
  autorisé`) ; à la publication, une formule invalide est ignorée au recalcul
  mais doit être signalée (précondition de publication, §9).
- **Auto-référence interdite** : une formule ne peut pas référencer le champ
  qu'elle calcule (retirée du graphe, L.656 ; refusée par l'assistant L.625-628).
- Une formule ne peut référencer que des champs **de la page** (même table ou
  entête) — la résolution `{"ref":"X"}` cherche d'abord dans la table courante,
  puis dans `ENT` (construction du graphe, L.644-646).

## 2. Conversions et comparaisons (sémantique exacte)

### 2.1 `num(v)` — coercition numérique (L.343-346)

`Number(String(v ?? "").replace(",", "."))` ; `NaN` ⇒ **0**. Jamais d'erreur :
une valeur non numérique, `null`, vide ou date vaut **0** dans tout calcul
arithmétique. (Client : retire aussi les espaces, `dynamicEngine.ts` L.35-38.)

### 2.2 `versDate(v)` — conversion stricte en date, canon « heure naïve »
(L.352-365)

La **lecture d'horloge littérale fait foi**, le fuseau est ignoré (les valeurs
circulent en lectures d'horloge entre portail, fil JSON et base) :

- `Date` ⇒ ses composants **locaux** rematérialisés en instant UTC ;
- chaîne **ISO** `aaaa-mm-jj[Thh:mm[:ss]]` ou `aaaa-mm-jj hh:mm[:ss]` ⇒
  composants littéraux ;
- chaîne **FR** `jj/mm/aaaa[ hh:mm[:ss]]` ⇒ composants littéraux ;
- **tout le reste (nombres, autres chaînes) ⇒ `null`** — on ne devine jamais
  une date.

### 2.3 `txt(v)` — conversion en texte (L.381-391)

- `null`/`undefined` ⇒ `""` ; booléen ⇒ `"true"`/`"false"` ;
- date ⇒ lecture littérale `"aaaa-mm-jj hh:mm:ss"` (identique client/serveur) ;
- sinon `String(v)`.

### 2.4 `cmp(a,b)` — comparaison intelligente (L.367-377)

Ordre de tentative : **numérique** si les deux sont numériques (virgule
acceptée) → **dates** si les deux convertissent → **chaînes** (`localeCompare`)
en dernier. S'applique à `GT/GE/LT/LE`.

### 2.5 Vérité (`!!evaluer(...)`)

Utilisée par `AND/OR/NOT/COND` et les conditions : `null`, `""`, `0`, `false`
sont faux ; tout le reste est vrai (y compris une date).

## 3. Opérateurs logiques (13) — `OPS_LOGIQUES` (L.307-308)

| Op | Args | Sémantique |
|---|---|---|
| `AND` | n | Vrai si TOUS les args sont vrais. |
| `OR` | n | Vrai si AU MOINS un arg est vrai. |
| `NOT` | 1 | Négation. |
| `EQ` / `NE` | 2 | Égalité / différence **lâche** (`==` JS : `"5"` égale `5`). |
| `GT` / `GE` / `LT` / `LE` | 2 | Via `cmp()` (§2.4). |
| `IN` | 2 | `args[0] ∈ args[1]` ; `args[1]` doit être un **tableau json littéral** (ex. `{"op":"IN","args":[{"ref":"Etat"},["A","B"]]}`), comparaison stricte (`includes`). |
| `EMPTY` | 1 | `null`, `undefined` ou chaîne trimmée vide. |
| `NOTEMPTY` | 1 | Inverse de `EMPTY`. |
| `CONTIENT` | 2 | `String(args[0]).includes(String(args[1]))` (sensible à la casse). |

## 4. Variables globales `GV_*` — `variableGlobale()` (L.316-328)

Exactement **7 variables**, résolues à l'horloge du serveur (client : horloge
du navigateur) ; alignées sur `GlobalVar()` du desktop. Inconnue ⇒ `null`
(0 en numérique). Les `GV_*` ne créent **jamais** de dépendance de recalcul.

| Variable | Valeur |
|---|---|
| `GV_NOW` | Date et heure du moment |
| `GV_YEAR` | Année en cours (ex. 2026) |
| `GV_MONTH` | Mois en cours (1-12) |
| `GV_DAY` | Jour du mois en cours (1-31) |
| `GV_DEBMOIS` | 1er jour du mois en cours |
| `GV_FINMOIS` | Dernier jour du mois en cours |
| `GV_DEBYEAR` | 1er janvier de l'année en cours |

⚠️ Ne pas confondre avec les variables de **valeur par défaut**
(`Valeur_Defaut` : `GV_MATRICULE`, `GV_NOW`, `GV_LOGIN` — voir
`comportement-page.md` §7) qui ne sont PAS utilisables dans les formules
(`GV_MATRICULE`/`GV_LOGIN` n'existent pas dans `variableGlobale()`).

## 5. Opérateurs de calcul — arithmétique et condition (`OPS_CALCUL`, L.309-312)

| Op | Args / attributs | Sémantique exacte |
|---|---|---|
| `ADD` | n args | Somme des `num(args)`. |
| `SUB` | 2 args | **Deux dates ⇒ durée en SECONDES** (`(da-db)/1000`) ; sinon `num(a)-num(b)`. |
| `MUL` | n args | Produit des `num(args)`. |
| `DIVSAFE` | 2 args | `num(a)/num(b)` ; **diviseur 0 ⇒ 0** (jamais d'erreur). C'est la division produite par l'assistant pour `/`. |
| `ROUND` | 1-2 args | Arrondi `Math.round` JS (**la moitié part vers +∞**, PAS bancaire) ; décimales = `args[1]`, défaut **2**. |
| `ABS` | 1 | Valeur absolue. |
| `INT` | 1 | Partie entière **vers −∞** (`Math.floor` — ENT tableur). |
| `CEIL` / `FLOOR` | 1 | Entier supérieur / inférieur. |
| `MIN` / `MAX` | **Forme scalaire** : n args, sans `table` | Plus petite / plus grande des `num(args)` (0 si aucun arg). |
| `COND` | 3 args | `SI(cond; alors; sinon)` : `args[0]` vrai ⇒ `args[1]`, sinon `args[2]`. |
| `REF` | attr `colonne` | `ctx.entete[colonne]` (forme alternative à `{"ref":…}`). |
| `CONST` | attr `valeur` | Constante (forme alternative). |

## 6. Opérateurs de calcul — texte (positions **1-based**, convention tableur)

| Op | Français (assistant) | Args | Sémantique |
|---|---|---|---|
| `LEFT` | `GAUCHE(texte; n)` | 2 | n premiers caractères de `txt(a)` (borné 0..longueur). |
| `RIGHT` | `DROITE(texte; n)` | 2 | n derniers caractères. |
| `SUBSTRING` | `STXT(texte; début; longueur?)` | 2-3 | Début **1-based** (min 1) ; sans longueur ⇒ jusqu'à la fin. |
| `INDEXOF` | `POSITION(morceau; texte)` | 2 | Position 1-based du morceau ; **0 si absent** ou morceau vide. |
| `LEN` | `LONGUEUR(texte)` | 1 | Nombre de caractères. |
| `UPPER` / `LOWER` | `MAJUSCULE` / `MINUSCULE` | 1 | Casse. |
| `TRIM` | `SUPPRESPACE(texte)` | 1 | Espaces de début/fin retirés. |
| `REPLACE` | `REMPLACE(texte; ancien; nouveau)` | 3 | Remplacement global ; ancien vide ⇒ texte inchangé. |
| `CONCAT` | `CONCAT(t1; t2; …)` | n | Assemblage des `txt(args)` (une date devient `"aaaa-mm-jj hh:mm:ss"`). |

## 7. Opérateurs de calcul — dates

Toutes les dates passent par `versDate()` (§2.2) : **date invalide ⇒ 0** pour
les fonctions à résultat numérique, **⇒ null** pour `DATEADD`.

| Op | Français | Args / attributs | Sémantique |
|---|---|---|---|
| `DATEDIFF` | `DUREE(fin; début; unité)` | 2 args + `unite` : `S`/`MI`/`H`/`J` (défaut `J`) | Durée **fin − début** convertie : S = ms/1000, MI = /60000, H = /3600000, J = /86400000. Résultat **fractionnaire** (pas de troncature). |
| `DATEADD` | `AJOUTDATE(date; n; unité)` | 2 args + `unite` : `S`/`MI`/`H`/`J`/`MO`/`A` (défaut `J`) | Ajoute n unités. S/MI/H/J en millisecondes ; **MO/A par composants avec clamp au dernier jour du mois cible** (31/01 + 1 MO ⇒ 28/02), comme SQL `DATEADD`. |
| `DATEPART` | `PARTDATE(date; partie)` | 1 arg + `partie` : `A`/`M`/`J`/`H`/`MI`/`S` (défaut `J`) | Extrait un nombre : année, mois (1-12), jour du mois, heure (0-23), minute, seconde. |
| `DAYOFWEEK` | `JOURSEM(date)` | 1 | Jour de semaine : **1 = lundi … 7 = dimanche**. |

Raccourcis de l'assistant : `ANNEE(d)` = `DATEPART` partie `A` ; `MOIS(d)` = `M` ;
`JOUR(d)` = `J`.

## 8. Agrégats de tableau (`SUM AVG MIN MAX COUNT` + attributs `table`/`colonne`)

Forme : `{"op":"SUM","table":"LIGNES","colonne":"Mnt"}` — évaluée sur
`ctx.details[table]` (L.555-574) :

| Op | Sémantique |
|---|---|
| `COUNT` | **Nombre de lignes** du détail (`colonne` facultative, ignorée). |
| `SUM` / `AVG` | Somme / moyenne des `num(ligne[colonne])` ; **0 si aucune ligne**. |
| `MIN` / `MAX` | Min / max des `num(ligne[colonne])` ; 0 si aucune ligne. **Avec `table`**, ce sont des agrégats ; **sans `table`**, la forme scalaire (§5). |

- `table` = `Cod_Table` d'un bloc de détail (jamais `ENT` — refusé par
  l'assistant L.916-918) ; `colonne` = `Nom_Colonne` du champ agrégé (clé de
  stockage, donc un **champ calculé de ligne peut alimenter un agrégat** —
  c'est le cas FKM : `Total = SUM(LIGNES.Mnt)` où `Mnt` est lui-même CALCULE).
- Un agrégat crée une dépendance **sur la table** (recalcul déclenché à tout
  changement de lignes) et, si la colonne agrégée est un calculé de ligne, une
  dépendance **sur ce champ** (ordre topologique, L.650-652).
- Les agrégats ne sont PAS des refs : `DetecterCycle` (designer) et le graphe
  ne les suivent pas comme dépendances de champs.

## 9. Graphe de dépendances, ordre d'évaluation, cycles

`construireGraphe()` (serveur L.633-677, client L.301-341) :

1. **Champs concernés** : `Typ_Controle='CALCULE'` avec `Formule` non vide.
   Clé : `<Cod_Table>|<cleChamp>`.
2. **Dépendances** (`extraireDependances`, L.612-626) : toutes les `{"ref":"X"}`
   sauf `@result` et `GV_*` ; chaque agrégat ajoute une dépendance de table et,
   si `table|colonne` est un calculé de ligne, une dépendance de champ. Une
   `ref` est liée au calculé **de même table**, sinon à celui de l'**entête**.
   L'auto-référence est retirée.
3. **Tri topologique** DFS : `ordre` = calculés dans un ordre où chaque champ
   est évalué **après** ses dépendances (FKM : `L_Mnt` avant `Total`).
4. **Cycle** : revisite d'un nœud « en cours » ⇒ chaîne `A -> B -> A`.
   Conséquences :
   - publication **bloquée** (`SP_Page_Designer.Publier`, message
     `Référence circulaire dans les calculs : A -> B -> A`) ;
   - enregistrement **refusé** par le serveur (même message, L.1131) ;
   - client : alerte unique « Configuration » au chargement de la page
     (`DynamicPage.tsx` L.216-222).
   - `DetecterCycle` du designer (L.2352-2392) = même algo sur les `{"ref":"X"}`
     extraits du json (regex), mêmes exclusions.

## 10. Niveaux de calcul et moments de recalcul

### 10.1 Trois niveaux (`recalculer`, serveur L.679-697 / client L.347-397)

| Niveau | Condition | Évaluation | Stockage |
|---|---|---|---|
| **Entête** | `Cod_Table='ENT'` | Une fois, dans le contexte document | `ctx.entete[clé]` ; persisté si `Persiste='true'` + colonne physique |
| **Ligne** | `Cod_Table=<det>` **et** `Nom_Colonne` non vide | **Pour chaque ligne** du détail (`ligne` = contexte de ligne ; les `ref` lisent d'abord la ligne puis l'entête) | colonne de la ligne si persistée |
| **Pied de grille** | `Cod_Table=<det>` **et** `Nom_Colonne` vide | Une fois, au niveau document (la formule porte l'agrégat) | **jamais stocké** ; affiché sous la grille (`DynamicPage.tsx` L.645-649) |

Un champ calculé **sans colonne physique rattachée à ENT** est aussi évalué au
niveau document. Règle de persistance : `Persiste='true'` **exige** une colonne
physique (contrôle `Saving` du designer) ; non persisté ⇒ aucune colonne, la
valeur se dérive à chaque affichage.

### 10.2 Déclencheurs

| Moment | Qui | Étendue |
|---|---|---|
| Chargement / nouveau document | client | Recalcul **complet** (les non persistés ne sont jamais stockés). Le serveur recalcule aussi dans `sp_get_document`. |
| Saisie d'un champ d'entête | client | Recalcul **ciblé** : fermeture transitive des calculés impactés (`impactesParChamp`). |
| Édition d'une cellule de détail | client | Ciblé : `impactesParChamp[colonne]` ∪ `impactesParTable[table]`. |
| Ajout / suppression / duplication de ligne | client | Ciblé sur la table. |
| Résolution d'un champ SOURCE | client | Cascade **SOURCE → CALCULE** : les calculés référençant le champ source sont recalculés (`DynamicPage.tsx` L.249-257). |
| Refresh d'un détail virtuel | client | Ciblé sur la table. |
| **Enregistrement** | **serveur** | Recalcul **complet** avant validations et écriture (la valeur client n'est jamais crue ; `enregistrerDocument` L.1127-1131). |

`Recalc_Save` (défaut `'true'`) n'a d'effet que pour les champs **SOURCE**
persistés (ré-exécution de la source au save) — voir `sources-metier.md` §5.
Pour un CALCULE, le recalcul serveur au save est systématique et inconditionnel.

## 11. Langage français de l'assistant (design-time)

L'assistant (`Zoom_SP_Assistant_Formule.vb`) convertit un texte convivial en
l'AST json — **seul json est stocké**. À connaître pour relire une formule
existante ou préparer les exemples du manifeste :

- **Syntaxe** : arguments séparés par `;` (la `,` est refusée — séparateur
  décimal uniquement, L.426) ; chaînes entre guillemets doubles ; opérateurs
  `+ - * /` et parenthèses ; comparaisons `= <> > >= < <=` (non chaînables) ;
  logique `ET` / `OU` / `NON` (priorité : `NON` > `ET` > `OU` ; comparaisons >
  `+ -` > `* /` ; `-x` unaire = `MUL(-1,x)`, replié en constante si numérique).
- `/` produit **`DIVSAFE`** (jamais d'erreur de division).
- **Correspondances fonctions** (L.81-99) : `ARRONDI→ROUND`, `ABS→ABS`,
  `SI→COND`, `VIDE→EMPTY`, `REMPLI→NOTEMPTY`, `GAUCHE→LEFT`, `DROITE→RIGHT`,
  `STXT→SUBSTRING`, `POSITION→INDEXOF`, `LONGUEUR→LEN`, `MAJUSCULE→UPPER`,
  `MINUSCULE→LOWER`, `SUPPRESPACE→TRIM`, `REMPLACE→REPLACE`, `CONCAT→CONCAT`,
  `CONTIENT→CONTIENT`, `DUREE→DATEDIFF`, `AJOUTDATE→DATEADD`,
  `PARTDATE→DATEPART`, `ANNEE/MOIS/JOUR→DATEPART(A/M/J)`, `JOURSEM→DAYOFWEEK`,
  `ENT→INT`, `PLAFOND→CEIL`, `PLANCHER→FLOOR` ; agrégats `SOMME→SUM`,
  `MOYENNE→AVG`, `MIN/MAX` (1 colonne de tableau ⇒ agrégat ; ≥2 args ⇒ scalaire),
  `NB→COUNT` (`NB()` sans argument accepté si un seul tableau de détail).
- Unités/parties acceptées en toutes lettres : `SECONDE(S)→S`, `MINUTE(S)→MI`,
  `HEURE(S)→H`, `JOUR(S)→J`, `MOIS→MO`, `AN/ANS/ANNEE(S)→A` ; parties
  `A/M/J/H/MI/S` avec mêmes synonymes (L.797-805, 836-846, 885-895).
- Seuls les **champs connus de la page** (Cod_Champ ou Nom_Colonne), les **GV_\***
  connues et les fonctions whitelistées sont acceptés — toute autre entrée est
  une erreur localisée (aucune injection possible, L.623-643).
- Une formule existante hors périmètre de l'assistant est **conservée telle
  quelle** (mode « non représentable », L.144-148).

## 12. Ce que le générateur SQL doit garantir (checklist formules)

1. `Formule` = json AST whitelisté (§1), profondeur ≤ 20 ; `{"ref":"X"}` =
   `Nom_Colonne` (ou `Cod_Champ` si sans colonne) **d'un champ de la page**,
   même table ou ENT ; `table`/`colonne` d'agrégat = bloc détail + colonne connus.
2. Un `CALCULE` est typiquement `Etat='A'` (affiché) — toujours en lecture
   seule côté client quelle que soit `Etat` (`DynamicField.tsx` L.71).
3. `Persiste='true'` ⇒ déclarer la colonne physique (type cohérent avec le
   résultat : `decimal(18,2)` pour un montant, `nvarchar` pour du texte…) ;
   `Persiste='false'` ⇒ **aucune** colonne. Un pied de grille est
   `Cod_Table=<det>`, `Nom_Colonne=''`, `Persiste='false'`, `Visible_Grille`
   libre (le rendu est hors grille).
4. Vérifier l'**absence de cycle** (miroir §9) — bloquant.
5. `Format_Affichage` ∈ `''|MNT|NUM|PCT|DAT|DTM` et `Decimales` pilotent le
   rendu (`valeurAffichee`, `DynamicField.tsx` L.27-54 : MNT = monétaire FR,
   NUM = nombre à `Decimales` décimales, PCT = pourcentage `0,15 → 15 %`,
   DAT/DTM = date / date+heure FR ; à défaut `Decimales` puis texte brut).
6. Ne jamais écrire la **valeur** d'un calculé dans le script : le serveur
   recalcule. Le DDL ne crée que la colonne (avec son défaut `DF_` si NOT NULL).
7. Rappel sémantique à faire figurer au manifeste si la formule utilise des
   dates : canon « heure naïve » (§2.2) — les durées sont en lectures
   d'horloge, sans fuseau.
