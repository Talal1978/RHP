<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Dossier
    Inherits Ecran

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Poste_lbl = New System.Windows.Forms.Label()
        Me.Poste_txt = New RHP.ud_TextBox()
        Me.Entite_lbl = New System.Windows.Forms.Label()
        Me.Entite_txt = New RHP.ud_TextBox()
        Me.Age_lbl = New System.Windows.Forms.Label()
        Me.Age_txt = New RHP.ud_TextBox()
        Me.Dat_Derniere_lbl = New System.Windows.Forms.Label()
        Me.Dat_Derniere_Visite_txt = New RHP.ud_TextBox()
        Me.Dat_Prochaine_lbl = New System.Windows.Forms.Label()
        Me.Dat_Prochaine_Visite_txt = New RHP.ud_TextBox()
        Me.Statut_Aptitude_lbl = New System.Windows.Forms.Label()
        Me.Statut_Aptitude_txt = New RHP.ud_TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab_Dossier = New System.Windows.Forms.TabPage()
        Me.Groupe_Sanguin_lbl = New System.Windows.Forms.Label()
        Me.Groupe_Sanguin_cbo = New RHP.ud_ComboBox()
        Me.Medecin_Traitant_lbl = New System.Windows.Forms.Label()
        Me.Medecin_Traitant_txt = New RHP.ud_TextBox()
        Me.Antecedents_lbl = New System.Windows.Forms.Label()
        Me.Antecedents_txt = New RHP.ud_TextBox()
        Me.Observations_lbl = New System.Windows.Forms.Label()
        Me.Observations_txt = New RHP.ud_TextBox()
        Me.Tab_Visites = New System.Windows.Forms.TabPage()
        Me.Grd_Visites = New RHP.ud_Grd()
        Me.Tab_Aptitudes = New System.Windows.Forms.TabPage()
        Me.Grd_Aptitudes = New RHP.ud_Grd()
        Me.Tab_Consultations = New System.Windows.Forms.TabPage()
        Me.Grd_Consultations = New RHP.ud_Grd()
        Me.Tab_Examens = New System.Windows.Forms.TabPage()
        Me.Grd_Examens = New RHP.ud_Grd()
        Me.Tab_Vaccinations = New System.Windows.Forms.TabPage()
        Me.Grd_Vaccinations = New RHP.ud_Grd()
        Me.Tab_MP = New System.Windows.Forms.TabPage()
        Me.Grd_MP = New RHP.ud_Grd()
        Me.Tab_AT = New System.Windows.Forms.TabPage()
        Me.Grd_AT = New RHP.ud_Grd()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Tab_Dossier.SuspendLayout()
        Me.Tab_Visites.SuspendLayout()
        Me.Tab_Aptitudes.SuspendLayout()
        Me.Tab_Consultations.SuspendLayout()
        Me.Tab_Examens.SuspendLayout()
        Me.Tab_Vaccinations.SuspendLayout()
        Me.Tab_MP.SuspendLayout()
        Me.Tab_AT.SuspendLayout()
        CType(Me.Grd_Visites, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd_Aptitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd_Consultations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd_Examens, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd_Vaccinations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd_MP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd_AT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Poste_lbl)
        Me.GroupBox2.Controls.Add(Me.Poste_txt)
        Me.GroupBox2.Controls.Add(Me.Entite_lbl)
        Me.GroupBox2.Controls.Add(Me.Entite_txt)
        Me.GroupBox2.Controls.Add(Me.Age_lbl)
        Me.GroupBox2.Controls.Add(Me.Age_txt)
        Me.GroupBox2.Controls.Add(Me.Dat_Derniere_lbl)
        Me.GroupBox2.Controls.Add(Me.Dat_Derniere_Visite_txt)
        Me.GroupBox2.Controls.Add(Me.Dat_Prochaine_lbl)
        Me.GroupBox2.Controls.Add(Me.Dat_Prochaine_Visite_txt)
        Me.GroupBox2.Controls.Add(Me.Statut_Aptitude_lbl)
        Me.GroupBox2.Controls.Add(Me.Statut_Aptitude_txt)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 120)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agent"
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(140, 45)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 252
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        '
        'Matricule_txt
        '
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(220, 43)
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.Size = New System.Drawing.Size(146, 26)
        Me.Matricule_txt.TabIndex = 1
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(374, 43)
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(420, 26)
        Me.Nom_Agent_Text.TabIndex = 2
        '
        'Poste_lbl
        '
        Me.Poste_lbl.AutoSize = True
        Me.Poste_lbl.Location = New System.Drawing.Point(175, 80)
        Me.Poste_lbl.Name = "Poste_lbl"
        Me.Poste_lbl.Size = New System.Drawing.Size(42, 19)
        Me.Poste_lbl.TabIndex = 3
        Me.Poste_lbl.Text = "Poste"
        '
        'Poste_txt
        '
        Me.Poste_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Poste_txt.ContextMenuStrip = Nothing
        Me.Poste_txt.Location = New System.Drawing.Point(220, 78)
        Me.Poste_txt.Name = "Poste_txt"
        Me.Poste_txt.ReadOnly = True
        Me.Poste_txt.Size = New System.Drawing.Size(250, 26)
        Me.Poste_txt.TabIndex = 4
        '
        'Entite_lbl
        '
        Me.Entite_lbl.AutoSize = True
        Me.Entite_lbl.Location = New System.Drawing.Point(490, 80)
        Me.Entite_lbl.Name = "Entite_lbl"
        Me.Entite_lbl.Size = New System.Drawing.Size(44, 19)
        Me.Entite_lbl.TabIndex = 5
        Me.Entite_lbl.Text = "Entité"
        '
        'Entite_txt
        '
        Me.Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Entite_txt.ContextMenuStrip = Nothing
        Me.Entite_txt.Location = New System.Drawing.Point(540, 78)
        Me.Entite_txt.Name = "Entite_txt"
        Me.Entite_txt.ReadOnly = True
        Me.Entite_txt.Size = New System.Drawing.Size(254, 26)
        Me.Entite_txt.TabIndex = 6
        '
        'Age_lbl
        '
        Me.Age_lbl.AutoSize = True
        Me.Age_lbl.Location = New System.Drawing.Point(810, 45)
        Me.Age_lbl.Name = "Age_lbl"
        Me.Age_lbl.Size = New System.Drawing.Size(33, 19)
        Me.Age_lbl.TabIndex = 7
        Me.Age_lbl.Text = "Âge"
        '
        'Age_txt
        '
        Me.Age_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Age_txt.ContextMenuStrip = Nothing
        Me.Age_txt.Location = New System.Drawing.Point(850, 43)
        Me.Age_txt.Name = "Age_txt"
        Me.Age_txt.ReadOnly = True
        Me.Age_txt.Size = New System.Drawing.Size(80, 26)
        Me.Age_txt.TabIndex = 8
        '
        'Dat_Derniere_lbl
        '
        Me.Dat_Derniere_lbl.AutoSize = True
        Me.Dat_Derniere_lbl.Location = New System.Drawing.Point(960, 45)
        Me.Dat_Derniere_lbl.Name = "Dat_Derniere_lbl"
        Me.Dat_Derniere_lbl.Size = New System.Drawing.Size(95, 19)
        Me.Dat_Derniere_lbl.TabIndex = 9
        Me.Dat_Derniere_lbl.Text = "Dernière visite"
        '
        'Dat_Derniere_Visite_txt
        '
        Me.Dat_Derniere_Visite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Derniere_Visite_txt.ContextMenuStrip = Nothing
        Me.Dat_Derniere_Visite_txt.Location = New System.Drawing.Point(1060, 43)
        Me.Dat_Derniere_Visite_txt.Name = "Dat_Derniere_Visite_txt"
        Me.Dat_Derniere_Visite_txt.ReadOnly = True
        Me.Dat_Derniere_Visite_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Derniere_Visite_txt.TabIndex = 10
        Me.Dat_Derniere_Visite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Dat_Prochaine_lbl
        '
        Me.Dat_Prochaine_lbl.AutoSize = True
        Me.Dat_Prochaine_lbl.Location = New System.Drawing.Point(1160, 45)
        Me.Dat_Prochaine_lbl.Name = "Dat_Prochaine_lbl"
        Me.Dat_Prochaine_lbl.Size = New System.Drawing.Size(102, 19)
        Me.Dat_Prochaine_lbl.TabIndex = 11
        Me.Dat_Prochaine_lbl.Text = "Prochaine visite"
        '
        'Dat_Prochaine_Visite_txt
        '
        Me.Dat_Prochaine_Visite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Prochaine_Visite_txt.ContextMenuStrip = Nothing
        Me.Dat_Prochaine_Visite_txt.Location = New System.Drawing.Point(1268, 43)
        Me.Dat_Prochaine_Visite_txt.Name = "Dat_Prochaine_Visite_txt"
        Me.Dat_Prochaine_Visite_txt.ReadOnly = True
        Me.Dat_Prochaine_Visite_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Prochaine_Visite_txt.TabIndex = 12
        Me.Dat_Prochaine_Visite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Statut_Aptitude_lbl
        '
        Me.Statut_Aptitude_lbl.AutoSize = True
        Me.Statut_Aptitude_lbl.Location = New System.Drawing.Point(810, 80)
        Me.Statut_Aptitude_lbl.Name = "Statut_Aptitude_lbl"
        Me.Statut_Aptitude_lbl.Size = New System.Drawing.Size(98, 19)
        Me.Statut_Aptitude_lbl.TabIndex = 13
        Me.Statut_Aptitude_lbl.Text = "Statut aptitude"
        '
        'Statut_Aptitude_txt
        '
        Me.Statut_Aptitude_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Statut_Aptitude_txt.ContextMenuStrip = Nothing
        Me.Statut_Aptitude_txt.Location = New System.Drawing.Point(915, 78)
        Me.Statut_Aptitude_txt.Name = "Statut_Aptitude_txt"
        Me.Statut_Aptitude_txt.ReadOnly = True
        Me.Statut_Aptitude_txt.Size = New System.Drawing.Size(237, 26)
        Me.Statut_Aptitude_txt.TabIndex = 14
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tab_Dossier)
        Me.TabControl1.Controls.Add(Me.Tab_Visites)
        Me.TabControl1.Controls.Add(Me.Tab_Aptitudes)
        Me.TabControl1.Controls.Add(Me.Tab_Consultations)
        Me.TabControl1.Controls.Add(Me.Tab_Examens)
        Me.TabControl1.Controls.Add(Me.Tab_Vaccinations)
        Me.TabControl1.Controls.Add(Me.Tab_MP)
        Me.TabControl1.Controls.Add(Me.Tab_AT)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 120)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1428, 594)
        Me.TabControl1.TabIndex = 1
        '
        'Tab_Dossier
        '
        Me.Tab_Dossier.Controls.Add(Me.Groupe_Sanguin_lbl)
        Me.Tab_Dossier.Controls.Add(Me.Groupe_Sanguin_cbo)
        Me.Tab_Dossier.Controls.Add(Me.Medecin_Traitant_lbl)
        Me.Tab_Dossier.Controls.Add(Me.Medecin_Traitant_txt)
        Me.Tab_Dossier.Controls.Add(Me.Antecedents_lbl)
        Me.Tab_Dossier.Controls.Add(Me.Antecedents_txt)
        Me.Tab_Dossier.Controls.Add(Me.Observations_lbl)
        Me.Tab_Dossier.Controls.Add(Me.Observations_txt)
        Me.Tab_Dossier.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Dossier.Name = "Tab_Dossier"
        Me.Tab_Dossier.Size = New System.Drawing.Size(1420, 562)
        Me.Tab_Dossier.TabIndex = 0
        Me.Tab_Dossier.Text = "Dossier médical"
        Me.Tab_Dossier.UseVisualStyleBackColor = True
        '
        'Groupe_Sanguin_lbl
        '
        Me.Groupe_Sanguin_lbl.AutoSize = True
        Me.Groupe_Sanguin_lbl.Location = New System.Drawing.Point(80, 45)
        Me.Groupe_Sanguin_lbl.Name = "Groupe_Sanguin_lbl"
        Me.Groupe_Sanguin_lbl.Size = New System.Drawing.Size(106, 19)
        Me.Groupe_Sanguin_lbl.TabIndex = 0
        Me.Groupe_Sanguin_lbl.Text = "Groupe sanguin"
        '
        'Groupe_Sanguin_cbo
        '
        Me.Groupe_Sanguin_cbo.DataSource = Nothing
        Me.Groupe_Sanguin_cbo.DisplayMember = ""
        Me.Groupe_Sanguin_cbo.DroppedDown = False
        Me.Groupe_Sanguin_cbo.Location = New System.Drawing.Point(200, 41)
        Me.Groupe_Sanguin_cbo.Name = "Groupe_Sanguin_cbo"
        Me.Groupe_Sanguin_cbo.SelectedIndex = -1
        Me.Groupe_Sanguin_cbo.SelectedItem = Nothing
        Me.Groupe_Sanguin_cbo.SelectedValue = Nothing
        Me.Groupe_Sanguin_cbo.Size = New System.Drawing.Size(100, 26)
        Me.Groupe_Sanguin_cbo.TabIndex = 1
        Me.Groupe_Sanguin_cbo.ValueMember = ""
        '
        'Medecin_Traitant_lbl
        '
        Me.Medecin_Traitant_lbl.AutoSize = True
        Me.Medecin_Traitant_lbl.Location = New System.Drawing.Point(80, 80)
        Me.Medecin_Traitant_lbl.Name = "Medecin_Traitant_lbl"
        Me.Medecin_Traitant_lbl.Size = New System.Drawing.Size(110, 19)
        Me.Medecin_Traitant_lbl.TabIndex = 2
        Me.Medecin_Traitant_lbl.Text = "Médecin traitant"
        '
        'Medecin_Traitant_txt
        '
        Me.Medecin_Traitant_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Medecin_Traitant_txt.ContextMenuStrip = Nothing
        Me.Medecin_Traitant_txt.Location = New System.Drawing.Point(200, 78)
        Me.Medecin_Traitant_txt.Name = "Medecin_Traitant_txt"
        Me.Medecin_Traitant_txt.Size = New System.Drawing.Size(400, 26)
        Me.Medecin_Traitant_txt.TabIndex = 3
        '
        'Antecedents_lbl
        '
        Me.Antecedents_lbl.AutoSize = True
        Me.Antecedents_lbl.Location = New System.Drawing.Point(80, 120)
        Me.Antecedents_lbl.Name = "Antecedents_lbl"
        Me.Antecedents_lbl.Size = New System.Drawing.Size(88, 19)
        Me.Antecedents_lbl.TabIndex = 4
        Me.Antecedents_lbl.Text = "Antécédents"
        '
        'Antecedents_txt
        '
        Me.Antecedents_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Antecedents_txt.ContextMenuStrip = Nothing
        Me.Antecedents_txt.Location = New System.Drawing.Point(200, 118)
        Me.Antecedents_txt.Multiline = True
        Me.Antecedents_txt.Name = "Antecedents_txt"
        Me.Antecedents_txt.Size = New System.Drawing.Size(690, 120)
        Me.Antecedents_txt.TabIndex = 5
        '
        'Observations_lbl
        '
        Me.Observations_lbl.AutoSize = True
        Me.Observations_lbl.Location = New System.Drawing.Point(80, 260)
        Me.Observations_lbl.Name = "Observations_lbl"
        Me.Observations_lbl.Size = New System.Drawing.Size(92, 19)
        Me.Observations_lbl.TabIndex = 6
        Me.Observations_lbl.Text = "Observations"
        '
        'Observations_txt
        '
        Me.Observations_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Observations_txt.ContextMenuStrip = Nothing
        Me.Observations_txt.Location = New System.Drawing.Point(200, 258)
        Me.Observations_txt.Multiline = True
        Me.Observations_txt.Name = "Observations_txt"
        Me.Observations_txt.Size = New System.Drawing.Size(690, 120)
        Me.Observations_txt.TabIndex = 7
        '
        'Tab_Visites
        '
        Me.Tab_Visites.Controls.Add(Me.Grd_Visites)
        Me.Tab_Visites.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Visites.Name = "Tab_Visites"
        Me.Tab_Visites.Size = New System.Drawing.Size(1420, 562)
        Me.Tab_Visites.TabIndex = 1
        Me.Tab_Visites.Text = "Visites médicales"
        Me.Tab_Visites.UseVisualStyleBackColor = True
        '
        'Grd_Visites
        '
        Me.Grd_Visites.AfficherLesEntetesLignes = True
        Me.Grd_Visites.AlternerLesLignes = False
        Me.Grd_Visites.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Visites.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Visites.Name = "Grd_Visites"
        Me.Grd_Visites.ReadOnly = True
        Me.Grd_Visites.Size = New System.Drawing.Size(1420, 562)
        Me.Grd_Visites.TabIndex = 0
        '
        'Tab_Aptitudes
        '
        Me.Tab_Aptitudes.Controls.Add(Me.Grd_Aptitudes)
        Me.Tab_Aptitudes.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Aptitudes.Name = "Tab_Aptitudes"
        Me.Tab_Aptitudes.Size = New System.Drawing.Size(1420, 562)
        Me.Tab_Aptitudes.TabIndex = 2
        Me.Tab_Aptitudes.Text = "Aptitudes"
        Me.Tab_Aptitudes.UseVisualStyleBackColor = True
        '
        'Grd_Aptitudes
        '
        Me.Grd_Aptitudes.AfficherLesEntetesLignes = True
        Me.Grd_Aptitudes.AlternerLesLignes = False
        Me.Grd_Aptitudes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Aptitudes.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Aptitudes.Name = "Grd_Aptitudes"
        Me.Grd_Aptitudes.ReadOnly = True
        Me.Grd_Aptitudes.Size = New System.Drawing.Size(1420, 562)
        Me.Grd_Aptitudes.TabIndex = 0
        '
        'Tab_Consultations
        '
        Me.Tab_Consultations.Controls.Add(Me.Grd_Consultations)
        Me.Tab_Consultations.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Consultations.Name = "Tab_Consultations"
        Me.Tab_Consultations.Size = New System.Drawing.Size(1420, 562)
        Me.Tab_Consultations.TabIndex = 3
        Me.Tab_Consultations.Text = "Consultations / Soins"
        Me.Tab_Consultations.UseVisualStyleBackColor = True
        '
        'Grd_Consultations
        '
        Me.Grd_Consultations.AfficherLesEntetesLignes = True
        Me.Grd_Consultations.AlternerLesLignes = False
        Me.Grd_Consultations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Consultations.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Consultations.Name = "Grd_Consultations"
        Me.Grd_Consultations.ReadOnly = True
        Me.Grd_Consultations.Size = New System.Drawing.Size(1420, 562)
        Me.Grd_Consultations.TabIndex = 0
        '
        'Tab_Examens
        '
        Me.Tab_Examens.Controls.Add(Me.Grd_Examens)
        Me.Tab_Examens.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Examens.Name = "Tab_Examens"
        Me.Tab_Examens.Size = New System.Drawing.Size(1420, 562)
        Me.Tab_Examens.TabIndex = 4
        Me.Tab_Examens.Text = "Examens"
        Me.Tab_Examens.UseVisualStyleBackColor = True
        '
        'Grd_Examens
        '
        Me.Grd_Examens.AfficherLesEntetesLignes = True
        Me.Grd_Examens.AlternerLesLignes = False
        Me.Grd_Examens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Examens.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Examens.Name = "Grd_Examens"
        Me.Grd_Examens.ReadOnly = True
        Me.Grd_Examens.Size = New System.Drawing.Size(1420, 562)
        Me.Grd_Examens.TabIndex = 0
        '
        'Tab_Vaccinations
        '
        Me.Tab_Vaccinations.Controls.Add(Me.Grd_Vaccinations)
        Me.Tab_Vaccinations.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Vaccinations.Name = "Tab_Vaccinations"
        Me.Tab_Vaccinations.Size = New System.Drawing.Size(1420, 562)
        Me.Tab_Vaccinations.TabIndex = 5
        Me.Tab_Vaccinations.Text = "Vaccinations"
        Me.Tab_Vaccinations.UseVisualStyleBackColor = True
        '
        'Grd_Vaccinations
        '
        Me.Grd_Vaccinations.AfficherLesEntetesLignes = True
        Me.Grd_Vaccinations.AlternerLesLignes = False
        Me.Grd_Vaccinations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Vaccinations.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Vaccinations.Name = "Grd_Vaccinations"
        Me.Grd_Vaccinations.ReadOnly = True
        Me.Grd_Vaccinations.Size = New System.Drawing.Size(1420, 562)
        Me.Grd_Vaccinations.TabIndex = 0
        '
        'Tab_MP
        '
        Me.Tab_MP.Controls.Add(Me.Grd_MP)
        Me.Tab_MP.Location = New System.Drawing.Point(4, 28)
        Me.Tab_MP.Name = "Tab_MP"
        Me.Tab_MP.Size = New System.Drawing.Size(1420, 562)
        Me.Tab_MP.TabIndex = 6
        Me.Tab_MP.Text = "Maladies professionnelles"
        Me.Tab_MP.UseVisualStyleBackColor = True
        '
        'Grd_MP
        '
        Me.Grd_MP.AfficherLesEntetesLignes = True
        Me.Grd_MP.AlternerLesLignes = False
        Me.Grd_MP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_MP.Location = New System.Drawing.Point(0, 0)
        Me.Grd_MP.Name = "Grd_MP"
        Me.Grd_MP.ReadOnly = True
        Me.Grd_MP.Size = New System.Drawing.Size(1420, 562)
        Me.Grd_MP.TabIndex = 0
        '
        'Tab_AT
        '
        Me.Tab_AT.Controls.Add(Me.Grd_AT)
        Me.Tab_AT.Location = New System.Drawing.Point(4, 28)
        Me.Tab_AT.Name = "Tab_AT"
        Me.Tab_AT.Size = New System.Drawing.Size(1420, 562)
        Me.Tab_AT.TabIndex = 7
        Me.Tab_AT.Text = "Accidents du travail"
        Me.Tab_AT.UseVisualStyleBackColor = True
        '
        'Grd_AT
        '
        Me.Grd_AT.AfficherLesEntetesLignes = True
        Me.Grd_AT.AlternerLesLignes = False
        Me.Grd_AT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_AT.Location = New System.Drawing.Point(0, 0)
        Me.Grd_AT.Name = "Grd_AT"
        Me.Grd_AT.ReadOnly = True
        Me.Grd_AT.Size = New System.Drawing.Size(1420, 562)
        Me.Grd_AT.TabIndex = 0
        '
        'RH_Sante_Dossier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Dossier"
        Me.Tag = "ECR"
        Me.Text = "Dossier santé au travail"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Tab_Dossier.ResumeLayout(False)
        Me.Tab_Dossier.PerformLayout()
        Me.Tab_Visites.ResumeLayout(False)
        Me.Tab_Aptitudes.ResumeLayout(False)
        Me.Tab_Consultations.ResumeLayout(False)
        Me.Tab_Examens.ResumeLayout(False)
        Me.Tab_Vaccinations.ResumeLayout(False)
        Me.Tab_MP.ResumeLayout(False)
        Me.Tab_AT.ResumeLayout(False)
        CType(Me.Grd_Visites, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd_Aptitudes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd_Consultations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd_Examens, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd_Vaccinations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd_MP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd_AT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Poste_lbl As Label
    Friend WithEvents Poste_txt As ud_TextBox
    Friend WithEvents Entite_lbl As Label
    Friend WithEvents Entite_txt As ud_TextBox
    Friend WithEvents Age_lbl As Label
    Friend WithEvents Age_txt As ud_TextBox
    Friend WithEvents Dat_Derniere_lbl As Label
    Friend WithEvents Dat_Derniere_Visite_txt As ud_TextBox
    Friend WithEvents Dat_Prochaine_lbl As Label
    Friend WithEvents Dat_Prochaine_Visite_txt As ud_TextBox
    Friend WithEvents Statut_Aptitude_lbl As Label
    Friend WithEvents Statut_Aptitude_txt As ud_TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Tab_Dossier As TabPage
    Friend WithEvents Groupe_Sanguin_lbl As Label
    Friend WithEvents Groupe_Sanguin_cbo As ud_ComboBox
    Friend WithEvents Medecin_Traitant_lbl As Label
    Friend WithEvents Medecin_Traitant_txt As ud_TextBox
    Friend WithEvents Antecedents_lbl As Label
    Friend WithEvents Antecedents_txt As ud_TextBox
    Friend WithEvents Observations_lbl As Label
    Friend WithEvents Observations_txt As ud_TextBox
    Friend WithEvents Tab_Visites As TabPage
    Friend WithEvents Grd_Visites As ud_Grd
    Friend WithEvents Tab_Aptitudes As TabPage
    Friend WithEvents Grd_Aptitudes As ud_Grd
    Friend WithEvents Tab_Consultations As TabPage
    Friend WithEvents Grd_Consultations As ud_Grd
    Friend WithEvents Tab_Examens As TabPage
    Friend WithEvents Grd_Examens As ud_Grd
    Friend WithEvents Tab_Vaccinations As TabPage
    Friend WithEvents Grd_Vaccinations As ud_Grd
    Friend WithEvents Tab_MP As TabPage
    Friend WithEvents Grd_MP As ud_Grd
    Friend WithEvents Tab_AT As TabPage
    Friend WithEvents Grd_AT As ud_Grd
End Class
