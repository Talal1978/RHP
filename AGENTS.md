# Conventions du projet RHP

## Connexion SQL Server (instruction permanente)

- **Serveur** : `.\SQL2019`
- **Utilisateur** : `sa`
- **Mot de passe** : `123`
- **Base** : `RHP`

Ces identifiants sont à utiliser pour toute connexion à la base de données du
projet (tests, scripts, outils en ligne de commande, chaînes de connexion).

## RHP_DeskTop (WinForms VB.NET)

- **Code de design des formulaires (instruction permanente)** : tout le code de
  design (déclaration et disposition des contrôles, `InitializeComponent`)
  doit être écrit dans le fichier `.Designer.vb` du formulaire (ex.
  `Zoom_SP_Nouvelle_Section.Designer.vb`), jamais dans le fichier de logique `.vb`.
  Le fichier `.vb` ne contient que la logique (événements, accès données,
  validations). Cette règle s'applique **y compris aux écrans construits
  entièrement par code** (sans Concepteur visuel Visual Studio) : la
  construction de l'interface est alors placée dans `InitializeComponent()`
  du `.Designer.vb` — référence : `Zoom_SP_SqlSource.Designer.vb`
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
- **Pages SP_ — champ `Num_Doc` obligatoire (instruction permanente)** : toute
  page du Designer de pages portail (`SP_Page_Designer`) comporte un champ
  d'entête `Cod_Champ = 'Num_Doc'` (**casse exacte**), `TEXT`, lecture seule
  (`Etat` `R`/`A`), **sans colonne physique** (`Nom_Colonne = ''`, ou lié à la
  colonne technique `Num_Doc`) — le portail lie `entete['Num_Doc']`, toujours
  retourné par le moteur (`lireDocument`). Verrouillé dans `Saving`
  (`SP_Page_Designer.vb`) et dans l'import JSON (`Module_SP_Page_Json.Valider`)
  au même titre que la table `ENT` : absence, mauvaise casse ou mauvaise
  liaison = erreur bloquante. Réciproquement, un champ sans colonne n'est
  légal que s'il est `CALCULE`/`SOURCE` non persisté, `GED`, ou l'affichage
  d'une colonne technique d'entête (Cod_Champ = nom technique exact) — tout
  autre champ non lié ne s'afficherait jamais (ex. bug `DemVisiteMed` :
  champ `'Num_Demande'` sans colonne, vide à vie).
- **Écrans affichés exclusivement en modal : nommage et thème (instruction
  permanente)** : tout écran qui s'affiche exclusivement en modal porte un nom
  (classe et fichiers) commençant par `Zoom` (ex. `Zoom_SP_SqlSource`,
  `Zoom_SP_Nouvelle_Section`) et suit le thème de
  `Zoom_SP_Nouvelle_Section.Designer.vb` : classe héritant de `Ecran`,
  formulaire sans bordure cadré `colorBase01` (`FormBorderStyle.None`,
  `Padding = 2`, `ControlBox = False`, `ShowInTaskbar = False`,
  `StartPosition = CenterParent`, `KeyPreview = True`), bandeau titre
  `ent_pnl` (`TableLayoutPanel` docké haut, hauteur 45, fond gris
  240,240,240) contenant le titre `Zoom_lbl` (Century Gothic 9,75 gras,
  `colorBase01`, fond transparent) et les boutons d'action en `PictureBox`
  36×37 (`Save_pb`, `Close_pb`, `Nouveau_pb`, `Supprimer_pb`... — images
  `btn_save` / `btn_close` / `btn_add` / `btn_delete` de `My.Resources`,
  `Cursors.Hand`, `SizeMode.CenterImage`), et un panel de contenu clair
  docké `Fill` (fond 250,250,250) portant les contrôles `ud_TextBox` /
  `ud_ComboBox` / `ud_button`.

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
- **Pages de consultation par requête (requêteur `Param_Query` → portail,
  instruction permanente)** : une requête du requêteur desktop devient une
  page de consultation du portail via l'onglet « Widget portail » de
  `Param_Query`, bloc « Page de consultation (menu du portail) »
  (`estPortail` + `Menu_Parent` + `Rang`, stockés dans `Param_Query_Widget` —
  migration `RHP_Portail/rhpBE/sql/Requeteur/001_Param_Query_Page_Portail.sql`).
  Le backend l'expose dans le menu comme entrée **directe** `SPQ_<Cod_Query>`
  (`sp_menu_portail` dans `controlers/sp_document.ts`, sans page liste) ;
  `Menu/Ecran.tsx` route `SPQ_` vers `Pages/Requete/PortalQuery.tsx`
  (critères saisis via `sp_query_meta`, boutons inline **Interroger** /
  **Nouveau** / **Exporter** — export Excel `.xlsx` des résultats affichés,
  entêtes = libellés de la grille, dates jj/mm/aaaa, valeurs typées —,
  grille en lecture seule via `sp_query_exec`, plafond 500 lignes). Sécurité (mêmes règles que les widgets du tableau de bord, helpers
  réexportés de `controlers/dashboard_query_widgets.ts`) : droit `Actif` de
  `Controle_Droit` sur le `Cod_Query` (écran des profils ; profil `1`
  bypass), garde-fou lecture seule mono-instruction, paramètres de contexte
  (`@idSoc`, `@Matricule`, `@Login`...) alimentés **uniquement** par le JWT —
  ces critères-là ne sont jamais demandés ; pour filtrer sur un **autre**
  agent, nommer le paramètre autrement (ex. `@Mat`). `Default_Value`
  (constante ou `GV_*`) pré-remplit le critère.   **Modes de saisie des
  critères** : le portail respecte la `Fonction_Critere` déclarée dans
  `Param_Query`, comme l'écran d'exécution desktop `Param_Query_Saisi` —
  `TextBox`/vide = saisie libre, `Calender` = calendrier, `Boolean` = case à
  cocher, `Appel_Zoom` (« Menu Local », zoom long : `Table_Critere` +
  `Champs_01` code + `Champs_02` libellé + `Condition`) = **panneau zoom**
  (`Pages/Requete/ZoomCritere.tsx`, grille Code/Libellé — aspect repris de
  `TextZoom`), et seul `Combo` (« Rubrique » : `Table_Critere` = nom de la
  rubrique `Param_Rubriques`) = **liste déroulante** (`ComboBox`). Les deux
  listes sont alimentées par l'endpoint **`sp_query_zoom`**
  (retourne `Code`/`Libelle` ; table, champs et condition lus
  **exclusivement** depuis la déclaration `Param_Query_Criteres` — jamais du
  client —, identifiants strictement validés, `Condition` en lecture seule ne
  pouvant référencer que des paramètres JWT de la liste blanche).
  **Exception FAB** : les
  pages-requêtes n'ont **volontairement pas** de FAB — leurs actions sont
  inline (`PortalQuery.tsx` n'alimente jamais `tbnMenu`) ; la vérification
  permanente du FAB ci-dessus ne s'applique qu'aux pages document (SP_ et
  standards). Exemples de référence :
  `RHP_Portail/rhpBE/sql/Requeteur/002_Exemple_Page_Soldes_Conges.sql` et
  `003_Exemple_Page_Departs_Retraite.sql` (critères `Calender` +
  `Appel_Zoom`).
- **Profils portail des agents — droits par page (instruction permanente)** :
  un profil `Controle_Profile` est affecté à chaque agent via
  **`RH_Agent.Cod_Profile`** (int NULL ; fiche agent desktop, bloc
  « Paramétrage de l'authentification au portail », zoom MS061, ou écran
  d'affectation de masse `Auth/Admin_Profil_Agent` — grille agents × combo
  profils). Au login du portail (`controlers/authentication.ts`), le profil
  est résolu par priorité : `RH_Agent.Cod_Profile` > `Controle_Users`
  (par `Mail`, compatibilité) > **profil par défaut**
  (`Controle_Profile.Portail_Defaut = 'true'`, un seul — index filtré unique
  `UX_Controle_Profile_Portail_Defaut`, case « Profil portail par défaut » de
  l'écran `Admin_Profile`) > `-1` ; un profil inactif est ignoré. Migration :
  `RHP_Portail/rhpBE/sql/Securite/001_Profil_Portail_Agents.sql`.
  **Référentiel des pages standards** : table `Controle_Menu_Portail`
  (miroir de `rhpfe/public/menus.json` — à re-seeder si menus.json évolue) ;
  les droits sont dans `Controle_Droit` avec **`Name_Ecran = 'PRT_' + nom de
  la page`** (le préfixe `PRT_` isole les droits portail des écrans desktop
  de mêmes noms, ex. `Note_Frais_Liste`), `Visible` = affichage menu,
  `Actif` = accès page. **Règle par profil** : pas de ligne pour CE profil =
  page non contrôlée pour lui (déploiement progressif ; l'onglet **Portail**
  d'`Admin_Profile` écrit une ligne pour CHAQUE page à l'enregistrement) ;
  profil `'1'` = bypass. Application côté portail : helper
  `modules/module_droits_portail.ts` (`droitsPage`, `gardePage`) — garde
  `gardePage("<Page>")` posée sur chaque route métier des pages standards
  dans `root/root.ts` (après `validate` ; endpoints transverses — zoom,
  rubrique, workflow, GED, `getPoste`, `is_paie_encours`... — non gardés) ;
  `sp_menu_portail` renvoie en plus `pagesStandards` (pages visibles du
  profil) et `pagesControlees` (tout le référentiel), exploités par
  `modules/module_menus.ts` (`filtrerMenusStatiques` filtre `controleMenus`,
  sections devenues vides retirées ; `estPageAutorisee` = garde de route dans
  `Menu/Ecran.tsx`). `null` côté client = référentiel indisponible = aucun
  filtrage (fail-open ; la sécurité réelle est côté serveur). Toute nouvelle
  page standard du portail doit être ajoutée à `Controle_Menu_Portail` (seed)
  et ses endpoints protégés par `gardePage`. Enregistrement desktop de
  l'écran d'affectation : `RHP_DeskTop/RHP/Auth/Admin_Profil_Agent_Menu.sql`.
