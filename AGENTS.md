# Conventions du projet RHP

## RHP_DeskTop (WinForms VB.NET)

- **Code de design des formulaires** : tout le code de design (déclaration et
  disposition des contrôles, `InitializeComponent`) doit être écrit dans le
  fichier `.Designer.vb` du formulaire (ex. `SP_Nouvelle_Section.Designer.vb`),
  jamais dans le fichier de logique `.vb`. Le fichier `.vb` ne contient que la
  logique (événements, accès données, validations).
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
