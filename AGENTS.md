# Conventions du projet RHP

## RHP_DeskTop (WinForms VB.NET)

- **Code de design des formulaires (instruction permanente)** : tout le code de
  design (déclaration et disposition des contrôles, `InitializeComponent`)
  doit être écrit dans le fichier `.Designer.vb` du formulaire (ex.
  `SP_Nouvelle_Section.Designer.vb`), jamais dans le fichier de logique `.vb`.
  Le fichier `.vb` ne contient que la logique (événements, accès données,
  validations). Cette règle s'applique **y compris aux écrans construits
  entièrement par code** (sans Concepteur visuel Visual Studio) : la
  construction de l'interface est alors placée dans `InitializeComponent()`
  du `.Designer.vb` — référence : `SP_Zoom_SqlSource.Designer.vb`
  (déclarations de champs en bas, `Partial Class`, `Inherits` uniquement dans
  le `.Designer.vb`, `.resx` absent si inutile, entrée `<Compile>` avec
  `<DependentUpon>` dans le `.vbproj`). Le constructeur du `.vb` appelle
  `InitializeComponent()` puis n'affecte que des **données** (textes
  dynamiques, valeurs), jamais de disposition.
- **Colonnes des grilles** : comme tout autre contrôle, les colonnes des
  `DataGridView` / `ud_Grd` (y compris `DataGridViewComboBoxColumn`) sont
  déclarées dans le `.Designer.vb` — c'est la règle suivie par l'ensemble de
  RHP_DeskTop (43 écrans : `Note_Frais`, `Formation`, `Mailing_Destinataires`,
  `Workflow_Signatures`...). Seuls les éléments des listes déroulantes
  dynamiques sont alimentés dans le code au chargement (`Combo_GRD`,
  `Items.Add`...). Les lectures de lignes passent par `DataBoundItem`
  (`DataRow`), pas par les noms de colonnes de la grille.
- **Exception — colonnes déclarées dans le code** : uniquement lorsque le
  Designer est incapable de les exprimer, c.-à-d. des colonnes dont le nombre
  ou la structure dépend des données à l'exécution (planning : une colonne par
  jour/agent — `RH_Conge_Planning`, `Zoom_Planning_Entretien` ; résultats de
  requêtes libres et imports — `Param_Query`, `Saisie_Massive_Avances` ;
  composants d'enquête dynamiques — `ud_valeur_unique`).
- **Entêtes de colonnes littéraux (instruction permanente)** : le `HeaderText`
  d'une colonne de `ud_Grd` / `DataGridView` est toujours un libellé
  littéral en langage utilisateur (ex. « Type source », « Requête SQL »),
  jamais le nom technique de la donnée avec des underscores (`Typ_Source`,
  `Code_Sql`...). Les noms techniques restent dans `DataPropertyName` et
  `Name`, pas dans l'entête affiché. Ne jamais laisser une grille en
  `AutoGenerateColumns = True` (elle afficherait les noms bruts) : colonnes
  déclarées + `AutoGenerateColumns = False`.
- **Colonnes booléennes = cases à cocher (instruction permanente)** : toute
  colonne booléenne d'une grille (`Actif`, `Obligatoire`, `Allow_Add`...) est
  une `DataGridViewCheckBoxColumn`, jamais une colonne texte affichant
  « true »/« false ». Pour les données stockées en chaîne 'true'/'false',
  renseigner `TrueValue = "true"` et `FalseValue = "false"`.
- **Colonnes à valeurs prédéterminées = listes déroulantes (instruction
  permanente)** : toute colonne dont le domaine de valeurs est fermé
  (ex. `Typ_Source` ∈ SQL/PROC, `Typ_Retour` ∈ SCALAIRE/TABLE, `Typ_Sql`,
  `Etat`, `Portee`...) est une `DataGridViewComboBoxColumn`, jamais une
  saisie libre. Les éléments sont alimentés au chargement depuis une source
  unique (constantes partagées avec les validations ou rubrique
  `Param_Rubriques`), pas saisis à la main.
- **Colonnes ReadOnly cliquables = curseur main (instruction permanente)** :
  toute colonne en lecture seule d'une `ud_Grd` associée à un événement de
  clic (ouverture d'un zoom, d'un assistant...) signale l'interaction par
  `Cursors.Hand` au survol de la cellule (`CellMouseEnter`), un tooltip sur
  la colonne et un style de cellule lecture seule (fond grisé). Ex. :
  `Grd_Sources` (`Parametres`, `Code_Sql`) dans `SP_Page_Designer`.
- Thème visuel des écrans modaux : suivre `Zoom_Org_Organigramme_Affectation`
  (formulaire sans bordure cadré `colorBase01`, bandeau titre, panel clair,
  contrôles `ud_TextBox` / `ud_ComboBox` / `ud_button`).

## RHP_Portail (React/TypeScript)

- **Bouton d'actions flottant (FAB)** : les actions d'une page document du
  portail (Enregistrer, Nouveau, Supprimer, Imprimer, Soumettre pour
  signature, Pièces jointes...) s'affichent dans le FAB `FloatMenu`
  (`RHP_Portail/rhpfe/src/components/FloatMenu/FloatMenu.tsx`, `Fab` MUI).
  Mécanisme : la page alimente l'état `tbnMenu` du contexte `cntX` via
  `settbnMenu([...])` (déclaré dans `Menu/MenuMain.tsx`), et `Menu/Ecran.tsx`
  rend le FAB par `{tbnMenu.length > 0 && <FloatMenu btnMenus={tbnMenu} />}` ;
  positionnement fixe bas-droite dans `floatMenu.scss`
  (`$positionFloating` de `_variables.scss`).
- **Vérification permanente — le FAB ne doit jamais disparaître** : après
  TOUTE modification du portail touchant `MenuMain.tsx`, `Ecran.tsx`,
  `components/FloatMenu/`, `floatMenu.scss`, `_variables.scss` ou les appels
  `settbnMenu` d'une page, vérifier systématiquement, avant de considérer la
  tâche terminée, que le FAB est toujours présent et fonctionnel :
  1. la page modifiée appelle toujours `settbnMenu([...])` avec ses boutons
     (jamais vidé ou conditionné de sorte que `tbnMenu` reste `[]` en
     utilisation normale) ;
  2. `Ecran.tsx` conserve le rendu
     `{tbnMenu.length > 0 && <FloatMenu btnMenus={tbnMenu} />}` ;
  3. le FAB reste en `position: fixed` en bas à droite et au-dessus du
     contenu (`floatMenu.scss`) ;
  4. contrôle visuel sur au moins une page document (ex. `Note_Frais`) : le
     bouton rond s'affiche et son menu s'ouvre au clic.
  Une tâche sur le portail n'est pas terminée si le FAB a disparu des pages.
