# Conventions du projet RHP

## Connexion SQL Server (instruction permanente)

- **Serveur** : `.\SQL2019`
- **Utilisateur** : `sa`
- **Mot de passe** : `123`
- **Base** : `RHP`

Ces identifiants sont à utiliser pour toute connexion à la base de données du
projet (tests, scripts, outils en ligne de commande, chaînes de connexion).

## Encodage des fichiers sources (instruction permanente)

- **Vérification permanente — aucun caractère français corrompu** : après TOUTE
  création ou modification de fichier, vérifier l'absence de caractères
  corrompus (caractère de remplacement U+FFFD, mojibake type `Ã©`, `Ã¨`...)
  dans les textes
  accentués, et que les accents français (é, è, ê, à, ç, —...) s'affichent
  correctement. Un fichier source doit être **uniformément encodé** : jamais de
  mélange UTF-8 / ANSI dans un même fichier.
- **Contexte** : la majorité des sources historiques de `RHP_DeskTop` (des
  milliers de `.vb`, notamment des `.Designer.vb`) est encodée en
  **Windows-1252 (ANSI)** ; les fichiers récents sont en **UTF-8** (avec ou
  sans BOM). Visual Studio et Roslyn détectent l'encodage **par fichier**
  (UTF-8 strict d'abord, sinon repli ANSI 1252) : les deux coexistent sans
  problème, mais éditer un fichier ANSI avec un outil qui réécrit en UTF-8
  produit un fichier mixte illisible (le caractère de remplacement U+FFFD à la
  place des accents, ex. `M` + U+FFFD + `moire` au lieu de `Mémoire`).
- **Contrôle systématique après édition** (fichiers modifiés) : décoder le
  fichier en UTF-8 strict et exiger 0 exception + 0 occurrence de U+FFFD, ou
  s'assurer qu'il est intégralement ANSI d'origine (pas de séquence UTF-8
  introduite). Ex. PowerShell :
  `[Text.UTF8Encoding]::new($false,$true).GetString([IO.File]::ReadAllBytes($f))`
  puis `.Contains([char]0xFFFD)`. Pour un écran, contrôler en outre
  visuellement les libellés accentués (designer ou exécution).
- **Réparation** : corriger les chaînes corrompues avec les bons caractères
  français et rendre le fichier uniforme (UTF-8 de bout en bout), puis
  recompiler et vérifier les libellés dans le binaire produit.

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
  `<DependentUpon>` dans le `.vbproj` **et `<SubType>Form</SubType>` sur
  l'entrée `<Compile>` du `.vb`** — sans ce `SubType`, Visual Studio ne
  reconnaît pas le formulaire et le Concepteur ne s'ouvre pas, ex. bug
  corrigé sur `AI_Modeles`). Le constructeur du `.vb` appelle
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

- **Assistant IA — multi-modèles et modèle par défaut (instruction permanente)** :
  la configuration de l'assistant IA (table `Ai_Agent`) est gérée dans l'écran
  desktop dédié **`AI_Modeles`** (menu « Assistant AI » ; la base de
  connaissances `AI_KnowledgeBase` ne gère que l'**embedding** — import de
  documents, chunks, configuration `Ai_Embedding` ; la suppression d'une source
  y efface, après confirmation, **tous ses chunks** ; la liste des sources est
  chargée **en asynchrone** (connexion dédiée, jamais la `cn` partagée hors
  thread UI) avec un prédicat **SARGable** `(id_Societe = @soc OR id_Societe =
  -1 OR id_Societe IS NULL)` adossé à l'index `IX_AI_KnowledgeBase_Societe`
  (migration `RHP_Portail/rhpBE/sql/AI/004_AI_KnowledgeBase_Index_Chargement.sql`)
  — la forme `ISNULL(NULLIF(...))` imposait un scan de toute la table). Elle est
  **multi-modèles** : plusieurs
  configurations (fournisseur/modèle/url/clé API/mémoire) par portée (globale
  `id_Societe=-1` ou propre à la société — case « Paramétrage global »), une
  seule marquée **modèle par défaut** (`Par_Defaut='true'` — nvarchar
  'true'/'false', index filtré unique `UX_Ai_Agent_Par_Defaut`, clé technique
  `Id` ; migration `RHP_Portail/rhpBE/sql/AI/001_Ai_Agent_Multi_Modeles.sql`).
  L'écran liste les modèles dans la grille du haut (colonne « Par défaut » en
  case à cocher, triée par priorité) et édite le modèle sélectionné dans le
  formulaire (case « Modèle par défaut », boutons `Nouveau_pb` /
  `SupprimerModele_pb` — la suppression d'un défaut promeut le premier modèle
  restant de la portée). **L'instruction (onglet « Instruction ») est commune
  à tous les modèles** : répliquée sur toutes les lignes `Ai_Agent` à
  l'enregistrement et reprise de la base en mode « Nouveau » (jamais vidée).
  Le catalogue des modèles proposés par fournisseur (combo « Modèle ») vit
  dans `Ai_LLM_Modeles` (migration
  `RHP_Portail/rhpBE/sql/AI/003_Ai_LLM_Modeles_Catalogue.sql` — listes
  volontairement limitées aux modèles phares). **Tout consommateur du LLM
  choisit par défaut le
  modèle par défaut** avec le même ordre (jamais un `TOP 1` sans ce tri) :
  `ORDER BY CASE WHEN ISNULL(Par_Defaut,'false')='true' THEN 0 ELSE 1 END,
  CASE WHEN id_Societe = @soc THEN 0 ELSE 1 END` — le défaut de la société
  prime sur le défaut global, puis une configuration de la société prime sur
  la globale. Consommateurs : backend portail `controlers/ai_assistant.ts`
  (`initAiContext`), desktop `Ai_ChatClient.ChargerConfig` (dont
  `Zoom_SP_Assistant_IA`), script Python `Scan_Piece_Identite.py` (et son
  installeur `Install_SCAN_PIECE_ID.sql`). La table `Ai_Embedding`
  (configuration d'embedding, `Zoom_Ai_EmbeddingConfig`) n'est **pas**
  concernée : elle reste mono-configuration.

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
   réexportés de `controlers/dashboard_query_widgets.ts`) : droit **`Visible`**
   de `Controle_Droit` sur le `Cod_Query` — **pour les requêtes, seul
   `Visible` est pris en charge** (jamais `Actif` ; géré dans l'onglet
   **Sécurité** de `Param_Query` ou l'onglet **Portail** d'`Admin_Profile`,
   sans case `Actif` pour les nœuds requêtes ; profil `1` bypass), garde-fou lecture seule
  mono-instruction, paramètres de contexte
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
  l'écran `Admin_Profile`) > `-1` ; un profil inactif est ignoré. Le profil
  est embarqué dans le JWT ; il est **réévalué en base à chaque
  rafraîchissement du jeton** (`refreshToken` → `resoudreProfilPortail`,
  mêmes priorités, ligne agent ciblée par `Matricule` + `id_Societe`) :
  les changements de droits s'appliquent au plus tard à l'expiration du
  jeton d'accès en cours (15 min), sans déconnexion. Migration :
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
  **Sections, widgets et pages SP_ gérés dans l'onglet Portail
  d'`Admin_Profile`** : en plus des pages standards, l'onglet charge les
  **sections créées en base** (rubrique `SP_Menu_Portail` —
  `Zoom_SP_Nouvelle_Section` —, union avec `Controle_Menu_Portail` sans
  doublon ; droit `Visible` sur `PRT_<code section>`, appliqué aux sections
  dynamiques par `sp_menu_portail`, fail-open sans ligne pour le profil —
  **une section contenant au moins un élément accessible à tout le monde**
  (page SP_ publiée avec `Acces_Personnalise='false'`) **est toujours
  visible** : bypass dans la requête des sections de `sp_menu_portail`, case
  `Visible` cochée d'office dans l'arbre d'`Admin_Profile` et forcée à
  `True` à l'enregistrement (`SavingPortailNodes`), sinon la page ouverte
  serait inaccessible), les
  **requêtes exposées au portail** (`Param_Query_Widget` : pages-requêtes sous
  leur section ou « Pages racines », widgets sous le dossier virtuel « Widgets
  du tableau de bord », dont les cases cochent/décochent tous les widgets
   d'un coup, comme les sections) — enregistrées sous leur **`Cod_Query` SANS
   préfixe** (`Typ_Ecran='QRY'` dans l'arbre), le portail exigeant **`Visible`**
   sur `Name_Ecran = Cod_Query` (pour les requêtes, seul `Visible` est pris en
   charge — pas de case `Actif` sur les nœuds requêtes de l'arbre ; `Actif`
   est recopié = `Visible` à l'enregistrement)   — et les **pages SP_ publiées du Designer**
  (`Controle_Designer`, `Typ_Ecran='SPP'`, suffixe « (Designer) ») : la case
  **Visible** porte `Consulter` (`Controle_Designer_Droit` — pour ces pages,
  affichage au menu et accès ne font qu'un ; pas de case `Actif`), et le
  **menu contextuel** du nœud (« Habilitations de la page (Créer, Modifier,
  GED...) ») ouvre `Zoom_Profile_Droits_SP` — édition des **6 autres
  habilitations** (`Creer/Modifier/Supprimer/Valider/Imprimer/GED`), conservées dans
  le `Tag(2)` du nœud puis persistées avec le profil (`SavingPortailNodes`,
  upsert qui préserve les colonnes non portées) : **va et vient** avec
  l'onglet Habilitations de `SP_Page_Designer`, les deux écrans lisant et
  écrivant la même table. Une page en accès ouvert
  (`Acces_Personnalise='false'`) est affichée sans case, suffixe « (Designer —
  ouverte à tous) » — seule sa consultation est ouverte ; ses autres
  habilitations restent éditables via le menu contextuel. Les lectures de
  droits de l'onglet
  sont en `TOP 1` (une ligne `Controle_Droit` dupliquée ne doit pas dupliquer
  l'entrée dans l'arbre — déduplication des doublons exacts :
  `sql/Securite/002_Dedup_Controle_Droit.sql`). L'enregistrement d'un profil
  ne supprime de `Controle_Droit` que les lignes qu'il gère (arborescence
  desktop, `PRT_`, requêtes `Param_Query_Widget`) ; la purge
   d'`Admin_TreeView` épargne `PRT_` et les requêtes existantes, et l'onglet
   Sécurité de `Param_Query` ne met à jour que `Visible` — le droit d'accès
   des requêtes, portail et menu desktop — par upsert sans DELETE, appelé
   uniquement depuis `Saving()` (jamais au chargement/navigation, sinon les
   droits des requêtes parcourues seraient écrasés).
  **Page d'accueil toujours accessible** : `Dashboard` (cible de la route par
  défaut `/myspace`) ne peut être retirée à aucun profil — sinon le portail
  serait inaccessible (aucune page d'atterrissage). Bypass dans
  `module_droits_portail.ts` (`PAGE_ACCUEIL_PORTAIL`, forcée dans
  `droitsPage` et `pagesMenuAutorisees`) et ligne verrouillée cochée dans
  l'onglet Portail d'`Admin_Profile` (`VerrouillerAccueil`).
