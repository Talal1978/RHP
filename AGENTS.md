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
- **Pages SP_ — propagation au changement `Copier_Vers` (instruction
  permanente)** : la métadonnée `Controle_Designer_Champ.Copier_Vers`
  (migration `RHP_Portail/rhpBE/sql/SP_Designer/008_SP_Designer_Copier_Vers.sql`)
  porte, sur un champ d'**entête**, le `Cod_Champ` du champ cible recevant sa
  valeur à chaque changement **si la cible est vide ou inférieure à la
  nouvelle valeur** (comparaison intelligente : nombres, puis dates, puis
  texte — ex. `Dat_Deb_Conge.Copier_Vers='Dat_Fin_Conge'` : une date de fin
  vide ou antérieure à la nouvelle date de début prend la date de début). La
  cible **reste ensuite modifiable** (confort de saisie, jamais un verrou) ;
  une valeur source vidée ne propage rien ; un seul niveau (pas de cascade) ;
  la cible propagée déclenche le recalcul de ses dépendants (`CALCULE`).
  Verrous (Saving `SP_Page_Designer.vb` + import JSON
  `Module_SP_Page_Json.Valider`, format **1.1**) : source et cible sur `ENT`,
  cible existante, distincte de la source, **saisissable** (`Etat='S'` ;
  jamais `CALCULE`/`SOURCE`/`GED` ni liée à une colonne technique), pas de
  référence mutuelle directe ; la casse exacte du code cible est normalisée à
  l'enregistrement (le portail résout par `Cod_Champ`). Côté portail :
  `propagerCopie` (`Pages/Dynamic/dynamicEngine.ts`), appelée dans
  `stateChange` de `DynamicPage.tsx` — confort client uniquement, jamais
  rejoué côté serveur au save.
- **Pages SP_ — champs liés aux colonnes système (instruction permanente)** :
  un champ peut être lié à toute colonne technique **affichable** de sa table
  (`Dat_Crea`, `Created_By`, `Dat_Modif`, `Modified_By`, `Statut`,
  `id_Societe`), sur l'entête comme sur les détails, pour décider de
  l'afficher ou non (`Etat` / `Visible_Grille`) — exceptions : `Num_Doc`
  (verrou conventionnel ci-dessus), `RV` (binaire rowversion) et `RowId`
  (identifiant interne de ligne, toujours masqué dans les grilles du
  portail) : liaisons bloquées (Saving + import JSON) et exclues des listes
  proposées. La valeur étant gérée par le serveur (jamais persistée par
  `enregistrerDocument`), le champ est **toujours en lecture seule** : état
  `S` forcé à `R` (Saving + import), libellé convivial (« Créé le »...) et
  type `DATETIME` proposés à la liaison, et garde-fou côté portail
  (`COLONNES_TECHNIQUES` dans `dynamicEngine.ts` — `DynamicField` et
  `colonnesGrille` forcent la lecture seule même pour les configurations
  antérieures restées en `S` ; `Dat_Crea`/`Dat_Modif` gardent leur format
  date dans les grilles via `TYP_SQL_TECHNIQUES` de `DynamicPage.tsx`).
- **Pages SP_ — actions Dupliquer / Supprimer d'un document (instruction
  permanente)** : les boutons **Dupliquer** et **Supprimer** d'une pièce SP_
  sont paramétrables **par page** dans le Designer (onglet « Conception de la
  page », cases `Act_Dupliquer_chk` / `Act_Supprimer_chk` → colonnes
  `Controle_Designer.Act_Dupliquer` / `Act_Supprimer`, migration
  `RHP_Portail/rhpBE/sql/SP_Designer/009_SP_Designer_Actions_Document.sql`,
  chargement/sauvegarde comme toute option `Act_*` ; export JSON format
  **1.2**). Sémantique des défauts : `Act_Dupliquer` est **opt-in**
  (`'false'` par défaut — une action nouvelle n'apparaît sur aucune page
  existante), `Act_Supprimer` est **opt-out** (`'true'` par défaut — la
  suppression existait avant l'option, pilotée par la seule habilitation ;
  la tester côté code = `!== 'false'`). Affichage portail : boutons
  **Dupliquer** / **Supprimer** placés à côté d'Interroger/Nouveau sur la page
  liste (`DynamicPage_Liste.tsx`) qui **activent un mode** — les icônes par
  ligne (copie / poubelle) n'apparaissent que dans ce mode et disparaissent
  après l'action, son annulation ou une ré-interrogation (même UX que les
  grilles de détail et leur bouton « Supprimer ») — rendues via la prop
  **`actionsLigne`** de `components/Grille/Grille.tsx` (actions génériques
  par ligne, `desactivee`/`couleur`/`titreDesactive` par action ; le handler
  reçoit la ligne et reste affiché sous filtrage, contrairement à l'ancienne
  prop `action` pilotée par `rowIndex`) — **et** entrées du FAB de
  `DynamicPage.tsx`, conditionnées à l'option **et** à l'habilitation du
  profil (**Creer** pour Dupliquer, **Supprimer** pour Supprimer — pas de
  nouvelle habilitation).
  **Dupliquer** (`POST /sp_duplicate_document` → `dupliquerDocument`,
  `module_sp_engine.ts`) crée en transaction une **nouvelle pièce brouillon** :
  numérotation standard (`nouveauNumero`), colonnes métier de l'entête et
  lignes des détails **physiques** copiées (`INSERT ... SELECT`, `RowId`
  IDENTITY régénéré), `Statut=''`, audit neuf ; détails virtuels non copiés
  (ré-exécutés sur la copie) ; tout statut est duplicable ; cloisonnement
  `Matricule` identique à la liste pour un non-TeamLeader ; le client ouvre
  la copie. **Supprimer** (`POST /sp_delete_document` → `supprimerDocument`)
  obéit à la **règle métier absolue** : une pièce dont le statut a **évolué**
  (`Statut` non vide et `<> 'NSS'` : soumise, signée, rejetée, validée...)
  n'est **jamais supprimable** — seuls les brouillons le sont (cette règle
  couvre `Figer_Statuts`, qui ne sert plus qu'au gel de la modification) ;
  côté client la liste grise l'icône via la colonne masquée **`Cod_Statut`**
  (statut brut ajouté au SELECT de `sp_document_liste`, `visible=false`) et le
  FAB est désactivé (`statutEvolutif` dans `DynamicPage.tsx`).
  **Exporter** : l'export Excel est **universel** — disponible sur TOUTES les
  pages liste SP_ sans rien activer (bouton **Exporter** de
  `DynamicPage_Liste.tsx` ; la colonne historique
  `Controle_Designer.Act_Exporter` et sa case « Action : Exporter » du
  Designer sont conservées pour compatibilité mais **ne sont plus
  consultées**). Le bouton produit un `.xlsx` de la liste **filtrée
  complète** — ré-interrogation serveur avec les mêmes critères en mode
  `exporter:true` (plafond 5000 lignes dans `sp_document_liste`), génération
  `xlsx` côté client (même pattern que `PortalQuery.tsx` : entêtes = libellés
  visibles de la grille, valeurs typées, dates jj/mm/aaaa, colonnes masquées
  exclues).
- **Pages SP_ — options de la page liste : colonnes système et tri
  (instruction permanente)** : la grille principale de la page liste
  (`SPPL_<Cod_Page>`, `DynamicPage_Liste.tsx` ← `sp_document_liste`) est
  paramétrable **par page** dans le Designer (onglet « Conception de la page »,
  bloc « Page liste du portail (grille principale) » : cases `Aff_Dat_Crea_chk`
  / `Aff_Cree_Par_chk` et champ `Tri_Liste_txt` → colonnes
  `Controle_Designer.Aff_Dat_Crea` / `Aff_Cree_Par` / `Tri_Liste`, migration
  `RHP_Portail/rhpBE/sql/SP_Designer/010_SP_Designer_Liste_Options.sql` ;
  export JSON format **1.3**). Sémantique des défauts : `Aff_Dat_Crea` et
  `Aff_Cree_Par` sont **opt-out** (`'true'` par défaut — les colonnes « Créé le »
  et « Créé par » ont toujours été affichées ; les tester côté code =
  `!== 'false'`, colonne simplement absente du SELECT de `sp_document_liste`).
  `Tri_Liste` (nvarchar(200), `''` par défaut) porte les **colonnes de tri** de
  la liste, expression déclarative **au même format que `Tri_Defaut`** des
  grilles de détail : noms de colonnes séparés par des virgules, sens `asc`/
  `desc` optionnel (ex. `'Dat_Depart desc'` ou `'Dat_Depart desc, Ref_OM asc'`) ;
  vide = comportement historique (`t.[Dat_Crea] desc`, plus récents d'abord).
  Colonnes admises : physiques déclarées de l'**entête** et techniques
  `Num_Doc`, `Statut`, `Dat_Crea`, `Created_By`, `Dat_Modif`, `Modified_By`
  (jamais `id_Societe` — cloisonnée — ni `RV`/`RowId`). Garde-fous à trois
  niveaux : **Saving** du Designer (bloquant + normalisation casse exacte des
  noms déclarés et sens en minuscules), **import JSON** (`Valider`, mêmes
  règles), et côté serveur **`triListeDocuments`** (`module_sp_engine.ts`,
  miroir de `verifierTri` avec alias `t.` : toute colonne inconnue est ignorée
  silencieusement, repli `t.[Dat_Crea] desc`) — l'`ORDER BY` remplace le
  `t.[Dat_Crea] desc` historique dans `sp_document_liste`.
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

- **Kaspersky — faux positif PDM sur `RHP.exe`, déclencheur : l'appel
  licence `ray1.ma` (instruction permanente)** : Kaspersky Endpoint Security
  (poste géré par stratégie KSC — les exclusions définies en local sont
  **inopérantes**, écrasées par la stratégie) mettait en quarantaine
  `RHP.exe` (verdict comportemental `PDM:Trojan.Win32.Generic`) **~2 minutes
  après le login**. Le déclencheur est l'appel `WebClient` de vérification
  de licence (`Auth\Module_Licence.vb` → `VerificationLicenceEtVersion`,
  lancé depuis `Module_Initialisation`) vers **`ray1.ma`**, domaine classé
  « menace de perte de données » par la protection web de Kaspersky (les
  lancements hors login ne déclenchent rien — le processus reste à
  l'écran de connexion). Résolu le 04/10/2026 : URL remplacée par
  `https://ghali3.genious.net` **+ suppression de `lic\cle.cle`** — ce
  fichier (URL chiffrée) **prime sur `UriStr0`** dans le code : tant qu'il
  contenait l'ancienne URL `ray1.ma`, le changement de code restait sans
  effet. **À répercuter sur tout déploiement** : supprimer ou réécrire le
  `lic\cle.cle` contenant `ray1.ma` (ex. postes clients) après changement
  de l'URL de licence. RayOne appelle aussi `ray1.ma` (`raylic.php`) sans
  être tué — le traitement par Kaspersky dépend du contexte d'exécution,
  pas du seul domaine. **Ne jamais
  mettre de commande PowerShell dans le `PostBuildEvent` du `.vbproj`** :
  Kaspersky a mis le `RHP.vbproj` lui-même en quarantaine le 04/10/2026 pour
  ce motif (projet restauré depuis git — fichier suivi, dernière
  modification commitée : 18/09/2026). Mesures :
  - **Signature Authenticode** : certificat dev « RHP Dev Code Signing
    (Metafy.solutions) » dans `Cert:\CurrentUser\My` (à recréer si absent) —
    un éditeur stable malgré le hash qui change à chaque compilation.
    `RHP_DeskTop\Build\` contient le `.cer`,
    `Install_RHP_DevCodeSigning_Admin.cmd` (approbation machine, à exécuter
    **en administrateur** sur chaque poste de dev, sinon la signature reste
    « racine non approuvée ») et `Sign-RHP.ps1` (signature manuelle de
    `bin\Debug\RHP.exe` / `bin\Release\RHP.exe` — volontairement **hors**
    du `.vbproj`).
  - Contournement dev : **Ctrl+F5** (« Démarrer sans débogage »), puis si
    besoin *Déboguer → Attacher au processus*.
  - Correctif pérenne : exclusions de dossiers (`D:\Dev\RHP\`, `C:\RHP\`)
    + `RHP.exe` en **application approuvée** (« ne pas surveiller
    l'activité ») poussés **par la stratégie KSC**, et signalement du faux
    positif à Kaspersky (préciser « détecté seulement sous le débogueur
    Visual Studio »).
  - **Incident du 09/10/2026 — F5 « ne lance rien » et signature
    « désinfectée »** : symptôme visible = F5 compile, le processus RHP
    est chargé (présent dans Alt+Tab) mais sa fenêtre **ne s'affiche
    jamais**. Deux pièges de diagnostic : (1) l'action Kaspersky
    « Désinfecter ; supprimer si la désinfection est impossible »
    **retire la signature Authenticode** de `RHP.exe` en restaurant la
    version non signée **avec son timestamp d'origine** — un exe peut
    donc redevenir `NotSigned` sans recompilation (toujours revérifier
    `Get-AuthenticodeSignature` au moment du test) ; (2) la signature est
    ignorée tant que le `.cer` n'est pas dans Root + TrustedPublisher
    **machine** (statut « racine non approuvée »). Résolution sur le
    poste le 09/10/2026 : certificat installé au niveau machine +
    reconfiguration locale Kaspersky (Prévention des intrusions /
    Protection) — depuis, **F5 fonctionne même avec un build frais non
    signé** ; la signature post-build (`Sign-RHP.ps1`) reste recommandée
    mais n'est plus bloquante pour le debug sur ce poste.

## RHP_Portail (React/TypeScript)

- **Identité utilisateur — jamais dans un état global du serveur (instruction
  permanente)** : l'identité d'une session (`Matricule`, `id_Societe`,
  `Cod_Entite`, `TeamLeader`, `codProfile`...) provient **exclusivement du
  JWT**, décodé à chaque requête par le middleware `validate`
  (`rhpBE/modules/module_jwt.ts`) qui la dépose dans `req.params`. **Aucune
  variable de module du backend ne doit mémoriser l'identité d'un agent** :
  un état global par utilisateur est nécessairement écrasé à chaque login —
  toutes les sessions héritent alors de l'identité du dernier connecté (bug
  de gestion des sessions corrigé le 07/10/2026 : `initialisationGlobale`
  figeait `Matricule`/`id_Societe`/`Cod_Entite` du dernier connecté dans les
  SQL des zooms de `Tbl_Controle_Def_Zoom`, servis à tous par
  `getZoomApi`/`getZoomLibelleApi`). Désormais `Tbl_Controle_Def_Zoom`
  (`module_initialisation.ts`) n'est que le **catalogue brut** de
  `Controle_Def_Zoom` (numZoom, codExp, zoomLib, zoomTbl, where1, zoomOrder,
  zoomSens — jamais de SQL avec identité interpolée) et le SQL d'un zoom est
  **construit à la requête** (`construireSqlZoom` de `module_zoom.ts`) avec
  l'identité du JWT de l'appelant. Tout nouveau besoin de données
  utilisateur côté serveur suit la même règle : lecture dans `req.params`
  (jamais dans une globale alimentée au login). Même règle pour
  l'**assistant IA** (`controlers/ai_assistant.ts`) : configuration du
  modèle, embedding et base de connaissances sont cloisonnés **par société**
  dans la map `aiContexts` (`chargerContexteSociete`, chargement paresseux +
  déduplication des chargements concurrents) — jamais dans des globales
  rechargées au login (fuite de la base de connaissances entre sociétés,
  corrigée le 07/10/2026).
- **Impression des états Crystal (instruction permanente)** : la génération
  PDF (`POST /getreport`, `rhpBE/controlers/report.ts`) exécute
  **`tools/CRExport/crexport.exe`** (chemins relatifs à `process.cwd()` =
  `backend\` du service) avec le modèle `.rpt` désigné par
  `Param_General.Lecteur_Digital_Mod_Edition` et le DSN `ODBC_RHP`, sortie
  dans `backend\tmp\` (purée après envoi). **Le packaging de déploiement doit
  toujours embarquer `tools\CRExport\` et `backend\tmp\`** (`Build-RHP.ps1`,
  contrôle d'intégrité d'`Export-RHPPortail.ps1`) — leur absence était la
  cause historique de l'échec d'impression en version déployée. Prérequis
  serveur : **runtime SAP Crystal Reports pour .NET Framework 32 bits**
  (v13.0.x ; détecté via `...\SAP BusinessObjects Enterprise XI
  4.0\win32_x86\crpe32.dll`, avertissement non bloquant dans
  Install/Update) — `crexport.exe` est compilé **AnyCPU « 32 bits préféré »**
  (CorFlags `32BITPREF=1`) : même sur Windows 64 bits il s'exécute en
  processus **32 bits** (le runtime 64 bits seul est inutilisable) ; et **un
  DSN système 32 bits** (`HKLM\SOFTWARE\WOW6432Node\ODBC\ODBC.INI`) nommé
  comme `Param_General.ODBC_RHP` (défaut `RHP`, pilote « SQL Server »)
  pointant sur l'instance SQL du client — `crexport.exe` fait
  `DataSourceConnections(0).SetConnection(odbc, db, ...)` : un DSN
  **utilisateur** ou un DSN système **64 bits** est invisible pour le
  processus 32 bits et produit « Impossible de démarrer la connexion » /
  « Echec de la connexion à la base de données » dans le log alors que le
  Desktop fonctionne ; de même un **lecteur réseau mappé** (`R:\...`) dans
  `Lecteur_Digital_Mod_Edition` est invisible pour le service — renseigner le
  **chemin UNC**. Tout échec doit rester **diagnosticable** : message
  explicite renvoyé au client (HTTP 500 lu par `ReportViewer.tsx`) et trace
  `[REPORT]` dans `logs\service-err.log` — ne jamais retenter un
  `res.download` d'un PDF non produit.
- **Recherche clavier dans les zooms du portail (instruction permanente)** :
  tout panneau de zoom du portail (`TextZoom` — pages standards et champs
  `ZOOM` du SP Designer — et `ZoomCritere` des pages-requêtes) offre une
  **barre de recherche auto-focalisée** dès l'ouverture : la frappe filtre en
  direct, côté client, la colonne ciblée, sans aucun clic préalable. La
  colonne filtrée par défaut est celle de
  **`Controle_Def_Zoom.Search_By`** (int 1-based — même règle que le desktop
  `Zoom.vb` : `>1` → index-1, sinon 0 ; absent/non numérique → 2e colonne =
  libellé), lue au chargement dans le catalogue (`module_initialisation.ts`,
  clé `searchBy`) et renvoyée par `POST /zoom` (`module_zoom.ts` — champ
  `searchBy` de la réponse). **Cliquer sur un en-tête de colonne de la grille
  change la colonne ciblée** (soulignée si active, focus rendu à la zone de
  recherche) ; au clavier : **↑/↓** déplacent la ligne active (surlignée,
  ramenée à l'écran), **Entrée** sélectionne la ligne active (la 1ère par
  défaut), **Échap** ferme le panneau (remonte au `onKeyDown` du `.zoomMenu`).
  Implémentation : prop **`rechercheZoom`** de `components/Grille/Grille.tsx`
  (barre `.rechercheZoom`, compteur de résultats, état `colRecherche` exposé
  aux en-têtes via le contexte `cntx` ; filtrage des lignes **centralisé dans
  `Grille.tsx`** — filtres d'en-têtes + recherche zoom via le même
  `filterEngine` exporté de `GrilleHeaderCell.tsx`, jokers `*` compris —
  et non plus dupliqué dans chaque `GrilleHeaderCell`). Toute nouvelle
  utilisation de `Grille` dans un panneau de zoom doit passer
  `rechercheZoom={true}` ; ne jamais déplacer le filtrage hors de `Grille.tsx`.
- **Bouton d'actions flottant (FAB)** : les actions d'une page document du
  portail (Enregistrer, Nouveau, Supprimer, Imprimer, Soumettre pour
  signature, Pièces jointes...) s'affichent dans le FAB `FloatMenu`
  (`RHP_Portail/rhpfe/src/components/FloatMenu/FloatMenu.tsx`, `Fab` MUI).
  Mécanisme : la page alimente l'état `tbnMenu` du contexte `cntX` via
  `settbnMenu([...])` (déclaré dans `Menu/MenuMain.tsx`), et `Menu/Ecran.tsx`
  rend le FAB par `{tbnMenu.length > 0 && <FloatMenu btnMenus={tbnMenu} />}` ;
  positionnement fixe bas-droite dans `floatMenu.scss`
  (`$positionFloating` de `_variables.scss`).
- **Couleur danger — `--color-base-03` ≠ `colorBase03` (piège permanent)** :
  la variable CSS `--color-base-03` (`_variables.scss`) est un **gris-bleu
  pâle** `#dae7ec` (fond des chips / surlignages) alors que
  `colorBase.colorBase03` (`modules/module_general.ts`) est l'**orange danger**
  `#f05a0a` (icônes poubelle des grilles, accents destructifs). Un bouton
  `color="error"` ne doit **jamais** utiliser la variable CSS (texte blanc sur
  fond pâle = aspect « désactivé », bug du bouton Supprimer des grilles
  corrigé le 08/10/2026) : le composant `components/Bouton/Bouton.tsx` passe
  par la constante JS (`COULEUR_DANGER`). Pour tout accent destructif,
  utiliser `colorBase.colorBase03` (côté JS) — la variable CSS reste réservée
  aux fonds pâles.
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
- **Configuration du tableau de bord persistée en base (instruction
  permanente)** : la configuration des widgets du tableau de bord du portail
  (widgets + sections, hook `Pages/Dashboard/widgets/useDashboardWidgets.ts`)
  est persistée dans la table **`Portail_Dashboard_Config`** (migration
  `RHP_Portail/rhpBE/sql/Dashboard/001_Portail_Dashboard_Config.sql`) :
  `Typ_Config` `'U'` (personnelle : `Cle_Config` = Matricule, `id_Societe` =
  société de l'agent), `'P'` (modèle d'un profil : `Cle_Config` = Cod_Profile,
  `id_Societe` = -1), `'G'` (modèle global : `Cle_Config` = '*', -1).
  Résolution au chargement (backend `controlers/dashboard_config.ts`,
  endpoints `dashboard_config_get` / `dashboard_config_save` — identité
  exclusivement du JWT, jamais du corps) : **U > P > G** ; une configuration
  issue d'un modèle devient personnelle (ligne `'U'`) au premier
  enregistrement de l'utilisateur. Le localStorage
  (`MYSPACE_DASHBOARD_WIDGETS_V2`, `MYSPACE_DASHBOARD_WIDGET_SECTIONS_V1`)
  reste le cache immédiat et le repli hors-ligne ; à la première connexion
  sans configuration serveur, la configuration locale est **adoptée**
  (poussée en base) pour ne rien perdre des personnalisations antérieures.
  La **duplication** d'une configuration vers d'autres agents et la gestion
  des modèles P/G se font dans l'écran desktop **`Admin_Dashboard_Config`**
  (section « Gestion des utilisateurs et des accès » ; enregistrement :
  `RHP_DeskTop/RHP/Auth/Admin_Dashboard_Config_Menu.sql`) qui attaque la
  même table en SQL direct.
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
   **Pages self-service HORS sécurité (instruction permanente)** : les pages
   standards où l'agent ne consulte que ses propres données —
   `RH_Agent` (Fiche agent), `Org_Organigramme`, `Org_Poste` (Fiche de
   poste), `RH_Avancement_Timeline` (Chronologie de carrière),
   `RH_Bulletin_Liste` (bulletins de paie) — ne sont **jamais** soumises au
   contrôle de profil : toujours visibles au menu et accessibles, quel que
   soit le profil. Constante **`PAGES_HORS_SECURITE`** de
   `module_droits_portail.ts` (inclut aussi `PAGE_ACCUEIL_PORTAIL`) :
   `droitsPage` les court-circuite (`gardePage` les laisse toujours passer),
   `pagesMenuAutorisees` les force dans `pagesStandards` **ainsi que leurs
   sections parentes** (sinon une page forcée deviendrait orpheline dans le
   menu si la section était masquée). Elles ne sont **même pas affichées**
   dans l'onglet Portail d'`Admin_Profile` (constante `PagesHorsSecurite`,
   filtre SQL de `RequestPortail` + garde-fou dans `SavingPortailNodes`) et
   aucune ligne `Controle_Droit` `PRT_` ne doit les concerner — leurs
   éventuelles lignes anciennes sont purgées à l'enregistrement d'un profil
   (le `DELETE 'PRT_%'` précède la réinsertion des seuls nœuds de l'arbre).
   Le référentiel `Controle_Menu_Portail` les conserve (elles y servent à la
   visibilité du menu). Toute nouvelle page self-service du même type doit
   être ajoutée aux DEUX constantes (backend `PAGES_HORS_SECURITE` et
   desktop `PagesHorsSecurite`).
