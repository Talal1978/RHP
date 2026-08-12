# Conventions du projet RHP

## RHP_DeskTop (WinForms VB.NET)

- **Code de design des formulaires** : tout le code de design (déclaration et
  disposition des contrôles, `InitializeComponent`) doit être écrit dans le
  fichier `.Designer.vb` du formulaire (ex. `SP_Nouvelle_Section.Designer.vb`),
  jamais dans le fichier de logique `.vb`. Le fichier `.vb` ne contient que la
  logique (événements, accès données, validations).
- Thème visuel des écrans modaux : suivre `Zoom_Org_Organigramme_Affectation`
  (formulaire sans bordure cadré `colorBase01`, bandeau titre, panel clair,
  contrôles `ud_TextBox` / `ud_ComboBox` / `ud_button`).
