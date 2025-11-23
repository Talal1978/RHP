<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Simulation
    inherits Ecran

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MyGrd = New RHP.ud_Grd()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Pnl_Agent = New System.Windows.Forms.Panel()
        Me.estNouvelleRecrue_chk = New RHP.ud_CheckBox()
        Me.Civilite_ = New System.Windows.Forms.Label()
        Me.Civilite_Combo = New RHP.ud_ComboBox()
        Me.Dat_Entree_ = New System.Windows.Forms.LinkLabel()
        Me.OrganismesSociaux = New System.Windows.Forms.GroupBox()
        Me.Organisme4_Text = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Organisme3_Text = New RHP.ud_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Organisme2_Text = New RHP.ud_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Organisme1_Text = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CNSS_Text = New RHP.ud_TextBox()
        Me.CNSS_ = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Typ_Periode = New RHP.ud_ComboBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Typ_Contrat_ = New System.Windows.Forms.Label()
        Me.Matricule_Text = New RHP.ud_TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Typ_Contrat = New RHP.ud_ComboBox()
        Me.Typ_Agent = New RHP.ud_ComboBox()
        Me.Proprietaire_ = New System.Windows.Forms.Label()
        Me.Situation = New RHP.ud_ComboBox()
        Me.Dat_Naissance_Text = New RHP.ud_TextBox()
        Me.Dat_Naissance_ = New System.Windows.Forms.LinkLabel()
        Me.Dat_Entree_Text = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Entite_ = New System.Windows.Forms.LinkLabel()
        Me.Poste_Text = New RHP.ud_TextBox()
        Me.Grade_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Poste_Text = New RHP.ud_TextBox()
        Me.Grade_Text = New RHP.ud_TextBox()
        Me.Poste_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Grade_Text = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Titre_txt = New RHP.ud_TextBox()
        Me.Nbr_Personne_A_Charge = New System.Windows.Forms.NumericUpDown()
        Me.Nbr_Personne_A_Charge_ = New System.Windows.Forms.Label()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Prenom_Agent_Text = New RHP.ud_TextBox()
        Me.Nom_ = New System.Windows.Forms.Label()
        Me.Prenom_ = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.statut_lb = New System.Windows.Forms.Label()
        Me.Cod_Simulation_Text = New RHP.ud_TextBox()
        Me.considerCumuls_chk = New RHP.ud_CheckBox()
        Me.Plan_Paie_ = New System.Windows.Forms.LinkLabel()
        Me.DatSimulation = New System.Windows.Forms.DateTimePicker()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Lib_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Valide_Check = New RHP.ud_CheckBox()
        Me.Lib_Simulation_Text = New RHP.ud_TextBox()
        Me.Cod_Simulation_ = New System.Windows.Forms.LinkLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        CType(Me.MyGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Pnl_Agent.SuspendLayout()
        Me.OrganismesSociaux.SuspendLayout()
        CType(Me.Nbr_Personne_A_Charge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyGrd
        '
        Me.MyGrd.AfficherLesEntetesLignes = True
        Me.MyGrd.AllowUserToAddRows = False
        Me.MyGrd.AllowUserToDeleteRows = False
        Me.MyGrd.AlternerLesLignes = False
        Me.MyGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.MyGrd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.MyGrd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MyGrd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MyGrd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MyGrd.ColumnHeadersHeight = 30
        Me.MyGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MyGrd.DefaultCellStyle = DataGridViewCellStyle2
        Me.MyGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyGrd.EnableHeadersVisualStyles = False
        Me.MyGrd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.MyGrd.Location = New System.Drawing.Point(4, 4)
        Me.MyGrd.Margin = New System.Windows.Forms.Padding(4)
        Me.MyGrd.Name = "MyGrd"
        Me.MyGrd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.MyGrd.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.MyGrd.RowHeadersWidth = 52
        Me.MyGrd.Size = New System.Drawing.Size(1134, 600)
        Me.MyGrd.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Pnl_Agent)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1134, 600)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Pnl_Agent
        '
        Me.Pnl_Agent.Controls.Add(Me.estNouvelleRecrue_chk)
        Me.Pnl_Agent.Controls.Add(Me.Civilite_)
        Me.Pnl_Agent.Controls.Add(Me.Civilite_Combo)
        Me.Pnl_Agent.Controls.Add(Me.Dat_Entree_)
        Me.Pnl_Agent.Controls.Add(Me.OrganismesSociaux)
        Me.Pnl_Agent.Controls.Add(Me.Label14)
        Me.Pnl_Agent.Controls.Add(Me.Typ_Periode)
        Me.Pnl_Agent.Controls.Add(Me.Matricule_)
        Me.Pnl_Agent.Controls.Add(Me.Typ_Contrat_)
        Me.Pnl_Agent.Controls.Add(Me.Matricule_Text)
        Me.Pnl_Agent.Controls.Add(Me.Label13)
        Me.Pnl_Agent.Controls.Add(Me.Typ_Contrat)
        Me.Pnl_Agent.Controls.Add(Me.Typ_Agent)
        Me.Pnl_Agent.Controls.Add(Me.Proprietaire_)
        Me.Pnl_Agent.Controls.Add(Me.Situation)
        Me.Pnl_Agent.Controls.Add(Me.Dat_Naissance_Text)
        Me.Pnl_Agent.Controls.Add(Me.Dat_Naissance_)
        Me.Pnl_Agent.Controls.Add(Me.Dat_Entree_Text)
        Me.Pnl_Agent.Controls.Add(Me.Cod_Entite_txt)
        Me.Pnl_Agent.Controls.Add(Me.Lib_Entite_txt)
        Me.Pnl_Agent.Controls.Add(Me.Entite_)
        Me.Pnl_Agent.Controls.Add(Me.Poste_Text)
        Me.Pnl_Agent.Controls.Add(Me.Grade_)
        Me.Pnl_Agent.Controls.Add(Me.Lib_Poste_Text)
        Me.Pnl_Agent.Controls.Add(Me.Grade_Text)
        Me.Pnl_Agent.Controls.Add(Me.Poste_)
        Me.Pnl_Agent.Controls.Add(Me.Lib_Grade_Text)
        Me.Pnl_Agent.Controls.Add(Me.Label1)
        Me.Pnl_Agent.Controls.Add(Me.Titre_txt)
        Me.Pnl_Agent.Controls.Add(Me.Nbr_Personne_A_Charge)
        Me.Pnl_Agent.Controls.Add(Me.Nbr_Personne_A_Charge_)
        Me.Pnl_Agent.Controls.Add(Me.Nom_Agent_Text)
        Me.Pnl_Agent.Controls.Add(Me.Prenom_Agent_Text)
        Me.Pnl_Agent.Controls.Add(Me.Nom_)
        Me.Pnl_Agent.Controls.Add(Me.Prenom_)
        Me.Pnl_Agent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Agent.Location = New System.Drawing.Point(4, 140)
        Me.Pnl_Agent.Margin = New System.Windows.Forms.Padding(4)
        Me.Pnl_Agent.Name = "Pnl_Agent"
        Me.Pnl_Agent.Size = New System.Drawing.Size(1126, 456)
        Me.Pnl_Agent.TabIndex = 270
        '
        'estNouvelleRecrue_chk
        '
        Me.estNouvelleRecrue_chk.AutoSize = True
        Me.estNouvelleRecrue_chk.Checked = False
        Me.estNouvelleRecrue_chk.Location = New System.Drawing.Point(239, 5)
        Me.estNouvelleRecrue_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.estNouvelleRecrue_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.estNouvelleRecrue_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.estNouvelleRecrue_chk.Name = "estNouvelleRecrue_chk"
        Me.estNouvelleRecrue_chk.Size = New System.Drawing.Size(175, 31)
        Me.estNouvelleRecrue_chk.TabIndex = 268
        Me.estNouvelleRecrue_chk.Text = "Depuis la CVthèque?"
        '
        'Civilite_
        '
        Me.Civilite_.AutoSize = True
        Me.Civilite_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Civilite_.Location = New System.Drawing.Point(44, 75)
        Me.Civilite_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Civilite_.Name = "Civilite_"
        Me.Civilite_.Size = New System.Drawing.Size(54, 19)
        Me.Civilite_.TabIndex = 266
        Me.Civilite_.Text = "Civilité"
        '
        'Civilite_Combo
        '
        Me.Civilite_Combo.DataSource = Nothing
        Me.Civilite_Combo.DisplayMember = ""
        Me.Civilite_Combo.DroppedDown = False
        Me.Civilite_Combo.Location = New System.Drawing.Point(101, 71)
        Me.Civilite_Combo.Margin = New System.Windows.Forms.Padding(5)
        Me.Civilite_Combo.Name = "Civilite_Combo"
        Me.Civilite_Combo.SelectedIndex = -1
        Me.Civilite_Combo.SelectedItem = Nothing
        Me.Civilite_Combo.SelectedValue = Nothing
        Me.Civilite_Combo.Size = New System.Drawing.Size(251, 30)
        Me.Civilite_Combo.TabIndex = 267
        Me.Civilite_Combo.Tag = "NC"
        Me.Civilite_Combo.ValueMember = ""
        '
        'Dat_Entree_
        '
        Me.Dat_Entree_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Entree_.AutoSize = True
        Me.Dat_Entree_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Entree_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Entree_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Entree_.Location = New System.Drawing.Point(449, 105)
        Me.Dat_Entree_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Dat_Entree_.Name = "Dat_Entree_"
        Me.Dat_Entree_.Size = New System.Drawing.Size(96, 19)
        Me.Dat_Entree_.TabIndex = 252
        Me.Dat_Entree_.TabStop = True
        Me.Dat_Entree_.Tag = "NC"
        Me.Dat_Entree_.Text = "Date entrée "
        '
        'OrganismesSociaux
        '
        Me.OrganismesSociaux.Controls.Add(Me.Organisme4_Text)
        Me.OrganismesSociaux.Controls.Add(Me.Label5)
        Me.OrganismesSociaux.Controls.Add(Me.Organisme3_Text)
        Me.OrganismesSociaux.Controls.Add(Me.Label4)
        Me.OrganismesSociaux.Controls.Add(Me.Organisme2_Text)
        Me.OrganismesSociaux.Controls.Add(Me.Label3)
        Me.OrganismesSociaux.Controls.Add(Me.Organisme1_Text)
        Me.OrganismesSociaux.Controls.Add(Me.Label2)
        Me.OrganismesSociaux.Controls.Add(Me.CNSS_Text)
        Me.OrganismesSociaux.Controls.Add(Me.CNSS_)
        Me.OrganismesSociaux.Location = New System.Drawing.Point(679, 42)
        Me.OrganismesSociaux.Margin = New System.Windows.Forms.Padding(4)
        Me.OrganismesSociaux.Name = "OrganismesSociaux"
        Me.OrganismesSociaux.Padding = New System.Windows.Forms.Padding(4)
        Me.OrganismesSociaux.Size = New System.Drawing.Size(325, 184)
        Me.OrganismesSociaux.TabIndex = 255
        Me.OrganismesSociaux.TabStop = False
        Me.OrganismesSociaux.Text = "Affiliation aux Organismes Sociaux"
        '
        'Organisme4_Text
        '
        Me.Organisme4_Text.AccessibleDescription = "A"
        Me.Organisme4_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Organisme4_Text.ContextMenuStrip = Nothing
        Me.Organisme4_Text.Location = New System.Drawing.Point(102, 135)
        Me.Organisme4_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Organisme4_Text.MaxLength = 32767
        Me.Organisme4_Text.Multiline = False
        Me.Organisme4_Text.Name = "Organisme4_Text"
        Me.Organisme4_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Organisme4_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Organisme4_Text.ReadOnly = False
        Me.Organisme4_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Organisme4_Text.SelectionStart = 0
        Me.Organisme4_Text.Size = New System.Drawing.Size(201, 26)
        Me.Organisme4_Text.TabIndex = 23
        Me.Organisme4_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Organisme4_Text.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(9, 138)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 19)
        Me.Label5.TabIndex = 212
        Me.Label5.Text = "Organisme 4"
        '
        'Organisme3_Text
        '
        Me.Organisme3_Text.AccessibleDescription = "A"
        Me.Organisme3_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Organisme3_Text.ContextMenuStrip = Nothing
        Me.Organisme3_Text.Location = New System.Drawing.Point(102, 108)
        Me.Organisme3_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Organisme3_Text.MaxLength = 32767
        Me.Organisme3_Text.Multiline = False
        Me.Organisme3_Text.Name = "Organisme3_Text"
        Me.Organisme3_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Organisme3_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Organisme3_Text.ReadOnly = False
        Me.Organisme3_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Organisme3_Text.SelectionStart = 0
        Me.Organisme3_Text.Size = New System.Drawing.Size(201, 26)
        Me.Organisme3_Text.TabIndex = 22
        Me.Organisme3_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Organisme3_Text.UseSystemPasswordChar = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(9, 110)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 19)
        Me.Label4.TabIndex = 210
        Me.Label4.Text = "Organisme 3"
        '
        'Organisme2_Text
        '
        Me.Organisme2_Text.AccessibleDescription = "A"
        Me.Organisme2_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Organisme2_Text.ContextMenuStrip = Nothing
        Me.Organisme2_Text.Location = New System.Drawing.Point(102, 79)
        Me.Organisme2_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Organisme2_Text.MaxLength = 32767
        Me.Organisme2_Text.Multiline = False
        Me.Organisme2_Text.Name = "Organisme2_Text"
        Me.Organisme2_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Organisme2_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Organisme2_Text.ReadOnly = False
        Me.Organisme2_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Organisme2_Text.SelectionStart = 0
        Me.Organisme2_Text.Size = New System.Drawing.Size(201, 26)
        Me.Organisme2_Text.TabIndex = 21
        Me.Organisme2_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Organisme2_Text.UseSystemPasswordChar = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(9, 80)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 19)
        Me.Label3.TabIndex = 208
        Me.Label3.Text = "Organisme 2"
        '
        'Organisme1_Text
        '
        Me.Organisme1_Text.AccessibleDescription = "A"
        Me.Organisme1_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Organisme1_Text.ContextMenuStrip = Nothing
        Me.Organisme1_Text.Location = New System.Drawing.Point(102, 51)
        Me.Organisme1_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Organisme1_Text.MaxLength = 32767
        Me.Organisme1_Text.Multiline = False
        Me.Organisme1_Text.Name = "Organisme1_Text"
        Me.Organisme1_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Organisme1_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Organisme1_Text.ReadOnly = False
        Me.Organisme1_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Organisme1_Text.SelectionStart = 0
        Me.Organisme1_Text.Size = New System.Drawing.Size(201, 26)
        Me.Organisme1_Text.TabIndex = 20
        Me.Organisme1_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Organisme1_Text.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(56, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 19)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "CIMR"
        '
        'CNSS_Text
        '
        Me.CNSS_Text.AccessibleDescription = "A"
        Me.CNSS_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CNSS_Text.ContextMenuStrip = Nothing
        Me.CNSS_Text.Location = New System.Drawing.Point(102, 24)
        Me.CNSS_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.CNSS_Text.MaxLength = 32767
        Me.CNSS_Text.Multiline = False
        Me.CNSS_Text.Name = "CNSS_Text"
        Me.CNSS_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.CNSS_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CNSS_Text.ReadOnly = False
        Me.CNSS_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.CNSS_Text.SelectionStart = 0
        Me.CNSS_Text.Size = New System.Drawing.Size(201, 26)
        Me.CNSS_Text.TabIndex = 19
        Me.CNSS_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CNSS_Text.UseSystemPasswordChar = False
        '
        'CNSS_
        '
        Me.CNSS_.AutoSize = True
        Me.CNSS_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.CNSS_.Location = New System.Drawing.Point(56, 28)
        Me.CNSS_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CNSS_.Name = "CNSS_"
        Me.CNSS_.Size = New System.Drawing.Size(44, 19)
        Me.CNSS_.TabIndex = 206
        Me.CNSS_.Text = "CNSS"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 8.2!)
        Me.Label14.Location = New System.Drawing.Point(364, 172)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 19)
        Me.Label14.TabIndex = 265
        Me.Label14.Text = "Type Période"
        '
        'Typ_Periode
        '
        Me.Typ_Periode.DataSource = Nothing
        Me.Typ_Periode.DisplayMember = ""
        Me.Typ_Periode.DroppedDown = False
        Me.Typ_Periode.Location = New System.Drawing.Point(466, 168)
        Me.Typ_Periode.Margin = New System.Windows.Forms.Padding(5)
        Me.Typ_Periode.Name = "Typ_Periode"
        Me.Typ_Periode.SelectedIndex = -1
        Me.Typ_Periode.SelectedItem = Nothing
        Me.Typ_Periode.SelectedValue = Nothing
        Me.Typ_Periode.Size = New System.Drawing.Size(205, 30)
        Me.Typ_Periode.TabIndex = 262
        Me.Typ_Periode.Tag = "NC"
        Me.Typ_Periode.ValueMember = ""
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(22, 10)
        Me.Matricule_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 249
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = ""
        Me.Matricule_.Text = "Matricule"
        '
        'Typ_Contrat_
        '
        Me.Typ_Contrat_.AutoSize = True
        Me.Typ_Contrat_.Font = New System.Drawing.Font("Century Gothic", 8.2!)
        Me.Typ_Contrat_.Location = New System.Drawing.Point(364, 138)
        Me.Typ_Contrat_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Typ_Contrat_.Name = "Typ_Contrat_"
        Me.Typ_Contrat_.Size = New System.Drawing.Size(98, 19)
        Me.Typ_Contrat_.TabIndex = 263
        Me.Typ_Contrat_.Text = "Type Contrat"
        '
        'Matricule_Text
        '
        Me.Matricule_Text.AccessibleDescription = "A"
        Me.Matricule_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_Text.ContextMenuStrip = Nothing
        Me.Matricule_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_Text.Location = New System.Drawing.Point(101, 8)
        Me.Matricule_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Matricule_Text.MaxLength = 32767
        Me.Matricule_Text.Multiline = False
        Me.Matricule_Text.Name = "Matricule_Text"
        Me.Matricule_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_Text.ReadOnly = True
        Me.Matricule_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_Text.SelectionStart = 0
        Me.Matricule_Text.Size = New System.Drawing.Size(130, 26)
        Me.Matricule_Text.TabIndex = 250
        Me.Matricule_Text.TabStop = False
        Me.Matricule_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_Text.UseSystemPasswordChar = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 8.2!)
        Me.Label13.Location = New System.Drawing.Point(12, 172)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 19)
        Me.Label13.TabIndex = 264
        Me.Label13.Text = "Type Agent"
        '
        'Typ_Contrat
        '
        Me.Typ_Contrat.DataSource = Nothing
        Me.Typ_Contrat.DisplayMember = ""
        Me.Typ_Contrat.DroppedDown = False
        Me.Typ_Contrat.Location = New System.Drawing.Point(465, 131)
        Me.Typ_Contrat.Margin = New System.Windows.Forms.Padding(5)
        Me.Typ_Contrat.Name = "Typ_Contrat"
        Me.Typ_Contrat.SelectedIndex = -1
        Me.Typ_Contrat.SelectedItem = Nothing
        Me.Typ_Contrat.SelectedValue = Nothing
        Me.Typ_Contrat.Size = New System.Drawing.Size(206, 30)
        Me.Typ_Contrat.TabIndex = 261
        Me.Typ_Contrat.Tag = "NC"
        Me.Typ_Contrat.ValueMember = ""
        '
        'Typ_Agent
        '
        Me.Typ_Agent.DataSource = Nothing
        Me.Typ_Agent.DisplayMember = ""
        Me.Typ_Agent.DroppedDown = False
        Me.Typ_Agent.Location = New System.Drawing.Point(101, 168)
        Me.Typ_Agent.Margin = New System.Windows.Forms.Padding(5)
        Me.Typ_Agent.Name = "Typ_Agent"
        Me.Typ_Agent.SelectedIndex = -1
        Me.Typ_Agent.SelectedItem = Nothing
        Me.Typ_Agent.SelectedValue = Nothing
        Me.Typ_Agent.Size = New System.Drawing.Size(205, 30)
        Me.Typ_Agent.TabIndex = 260
        Me.Typ_Agent.Tag = "NC"
        Me.Typ_Agent.ValueMember = ""
        '
        'Proprietaire_
        '
        Me.Proprietaire_.AutoSize = True
        Me.Proprietaire_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Proprietaire_.Location = New System.Drawing.Point(29, 139)
        Me.Proprietaire_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Proprietaire_.Name = "Proprietaire_"
        Me.Proprietaire_.Size = New System.Drawing.Size(69, 19)
        Me.Proprietaire_.TabIndex = 258
        Me.Proprietaire_.Text = "Situation"
        '
        'Situation
        '
        Me.Situation.DataSource = Nothing
        Me.Situation.DisplayMember = ""
        Me.Situation.DroppedDown = False
        Me.Situation.Location = New System.Drawing.Point(101, 134)
        Me.Situation.Margin = New System.Windows.Forms.Padding(5)
        Me.Situation.Name = "Situation"
        Me.Situation.SelectedIndex = -1
        Me.Situation.SelectedItem = Nothing
        Me.Situation.SelectedValue = Nothing
        Me.Situation.Size = New System.Drawing.Size(226, 30)
        Me.Situation.TabIndex = 259
        Me.Situation.Tag = "NC"
        Me.Situation.ValueMember = ""
        '
        'Dat_Naissance_Text
        '
        Me.Dat_Naissance_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Naissance_Text.ContextMenuStrip = Nothing
        Me.Dat_Naissance_Text.Enabled = False
        Me.Dat_Naissance_Text.Location = New System.Drawing.Point(102, 105)
        Me.Dat_Naissance_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Dat_Naissance_Text.MaxLength = 32767
        Me.Dat_Naissance_Text.Multiline = False
        Me.Dat_Naissance_Text.Name = "Dat_Naissance_Text"
        Me.Dat_Naissance_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Naissance_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Naissance_Text.ReadOnly = False
        Me.Dat_Naissance_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Naissance_Text.SelectionStart = 0
        Me.Dat_Naissance_Text.Size = New System.Drawing.Size(130, 26)
        Me.Dat_Naissance_Text.TabIndex = 257
        Me.Dat_Naissance_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Naissance_Text.UseSystemPasswordChar = False
        '
        'Dat_Naissance_
        '
        Me.Dat_Naissance_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Naissance_.AutoSize = True
        Me.Dat_Naissance_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Naissance_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Naissance_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Naissance_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Naissance_.Location = New System.Drawing.Point(36, 108)
        Me.Dat_Naissance_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Dat_Naissance_.Name = "Dat_Naissance_"
        Me.Dat_Naissance_.Size = New System.Drawing.Size(63, 19)
        Me.Dat_Naissance_.TabIndex = 256
        Me.Dat_Naissance_.TabStop = True
        Me.Dat_Naissance_.Tag = "NC"
        Me.Dat_Naissance_.Text = "Né(e) le"
        '
        'Dat_Entree_Text
        '
        Me.Dat_Entree_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Entree_Text.ContextMenuStrip = Nothing
        Me.Dat_Entree_Text.Enabled = False
        Me.Dat_Entree_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Entree_Text.Location = New System.Drawing.Point(545, 101)
        Me.Dat_Entree_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dat_Entree_Text.MaxLength = 32767
        Me.Dat_Entree_Text.Multiline = False
        Me.Dat_Entree_Text.Name = "Dat_Entree_Text"
        Me.Dat_Entree_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Entree_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Entree_Text.ReadOnly = False
        Me.Dat_Entree_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Entree_Text.SelectionStart = 0
        Me.Dat_Entree_Text.Size = New System.Drawing.Size(128, 26)
        Me.Dat_Entree_Text.TabIndex = 253
        Me.Dat_Entree_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Entree_Text.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(102, 261)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Entite_txt.MaxLength = 6
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(98, 26)
        Me.Cod_Entite_txt.TabIndex = 242
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(202, 261)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(469, 26)
        Me.Lib_Entite_txt.TabIndex = 241
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Entite_
        '
        Me.Entite_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.AutoSize = True
        Me.Entite_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Entite_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.Location = New System.Drawing.Point(51, 265)
        Me.Entite_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Entite_.Name = "Entite_"
        Me.Entite_.Size = New System.Drawing.Size(48, 19)
        Me.Entite_.TabIndex = 236
        Me.Entite_.TabStop = True
        Me.Entite_.Tag = "NC"
        Me.Entite_.Text = "Entité"
        '
        'Poste_Text
        '
        Me.Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Poste_Text.ContextMenuStrip = Nothing
        Me.Poste_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Poste_Text.Location = New System.Drawing.Point(102, 231)
        Me.Poste_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Poste_Text.MaxLength = 6
        Me.Poste_Text.Multiline = False
        Me.Poste_Text.Name = "Poste_Text"
        Me.Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Poste_Text.ReadOnly = True
        Me.Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Poste_Text.SelectionStart = 0
        Me.Poste_Text.Size = New System.Drawing.Size(98, 26)
        Me.Poste_Text.TabIndex = 238
        Me.Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Poste_Text.UseSystemPasswordChar = False
        '
        'Grade_
        '
        Me.Grade_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.AutoSize = True
        Me.Grade_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Location = New System.Drawing.Point(42, 205)
        Me.Grade_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Grade_.Name = "Grade_"
        Me.Grade_.Size = New System.Drawing.Size(54, 19)
        Me.Grade_.TabIndex = 235
        Me.Grade_.TabStop = True
        Me.Grade_.Tag = "NC"
        Me.Grade_.Text = "Grade"
        '
        'Lib_Poste_Text
        '
        Me.Lib_Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Poste_Text.ContextMenuStrip = Nothing
        Me.Lib_Poste_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Poste_Text.Location = New System.Drawing.Point(202, 231)
        Me.Lib_Poste_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Poste_Text.MaxLength = 50
        Me.Lib_Poste_Text.Multiline = False
        Me.Lib_Poste_Text.Name = "Lib_Poste_Text"
        Me.Lib_Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_Text.ReadOnly = True
        Me.Lib_Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_Text.SelectionStart = 0
        Me.Lib_Poste_Text.Size = New System.Drawing.Size(469, 26)
        Me.Lib_Poste_Text.TabIndex = 237
        Me.Lib_Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_Text.UseSystemPasswordChar = False
        '
        'Grade_Text
        '
        Me.Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Grade_Text.ContextMenuStrip = Nothing
        Me.Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_Text.Location = New System.Drawing.Point(102, 201)
        Me.Grade_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Grade_Text.MaxLength = 6
        Me.Grade_Text.Multiline = False
        Me.Grade_Text.Name = "Grade_Text"
        Me.Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Grade_Text.ReadOnly = True
        Me.Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grade_Text.SelectionStart = 0
        Me.Grade_Text.Size = New System.Drawing.Size(98, 26)
        Me.Grade_Text.TabIndex = 240
        Me.Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Grade_Text.UseSystemPasswordChar = False
        '
        'Poste_
        '
        Me.Poste_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Poste_.AutoSize = True
        Me.Poste_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Poste_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Poste_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Poste_.Location = New System.Drawing.Point(31, 235)
        Me.Poste_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Poste_.Name = "Poste_"
        Me.Poste_.Size = New System.Drawing.Size(45, 19)
        Me.Poste_.TabIndex = 234
        Me.Poste_.TabStop = True
        Me.Poste_.Tag = "NC"
        Me.Poste_.Text = "Poste"
        '
        'Lib_Grade_Text
        '
        Me.Lib_Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_Text.ContextMenuStrip = Nothing
        Me.Lib_Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Grade_Text.Location = New System.Drawing.Point(202, 201)
        Me.Lib_Grade_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Grade_Text.MaxLength = 50
        Me.Lib_Grade_Text.Multiline = False
        Me.Lib_Grade_Text.Name = "Lib_Grade_Text"
        Me.Lib_Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_Text.ReadOnly = True
        Me.Lib_Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_Text.SelectionStart = 0
        Me.Lib_Grade_Text.Size = New System.Drawing.Size(469, 26)
        Me.Lib_Grade_Text.TabIndex = 239
        Me.Lib_Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_Text.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(61, 295)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 19)
        Me.Label1.TabIndex = 233
        Me.Label1.Text = "Titre"
        '
        'Titre_txt
        '
        Me.Titre_txt.AccessibleDescription = "A"
        Me.Titre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Titre_txt.ContextMenuStrip = Nothing
        Me.Titre_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Titre_txt.Location = New System.Drawing.Point(102, 291)
        Me.Titre_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Titre_txt.MaxLength = 490
        Me.Titre_txt.Multiline = True
        Me.Titre_txt.Name = "Titre_txt"
        Me.Titre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Titre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Titre_txt.ReadOnly = False
        Me.Titre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Titre_txt.SelectionStart = 0
        Me.Titre_txt.Size = New System.Drawing.Size(570, 51)
        Me.Titre_txt.TabIndex = 232
        Me.Titre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Titre_txt.UseSystemPasswordChar = False
        '
        'Nbr_Personne_A_Charge
        '
        Me.Nbr_Personne_A_Charge.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nbr_Personne_A_Charge.Location = New System.Drawing.Point(606, 72)
        Me.Nbr_Personne_A_Charge.Margin = New System.Windows.Forms.Padding(4)
        Me.Nbr_Personne_A_Charge.Name = "Nbr_Personne_A_Charge"
        Me.Nbr_Personne_A_Charge.ReadOnly = True
        Me.Nbr_Personne_A_Charge.Size = New System.Drawing.Size(65, 24)
        Me.Nbr_Personne_A_Charge.TabIndex = 230
        Me.Nbr_Personne_A_Charge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Nbr_Personne_A_Charge_
        '
        Me.Nbr_Personne_A_Charge_.AutoSize = True
        Me.Nbr_Personne_A_Charge_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nbr_Personne_A_Charge_.Location = New System.Drawing.Point(456, 75)
        Me.Nbr_Personne_A_Charge_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Nbr_Personne_A_Charge_.Name = "Nbr_Personne_A_Charge_"
        Me.Nbr_Personne_A_Charge_.Size = New System.Drawing.Size(149, 19)
        Me.Nbr_Personne_A_Charge_.TabIndex = 231
        Me.Nbr_Personne_A_Charge_.Text = "Personnes à charges"
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(101, 39)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = False
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(251, 26)
        Me.Nom_Agent_Text.TabIndex = 223
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Prenom_Agent_Text
        '
        Me.Prenom_Agent_Text.AccessibleDescription = "A"
        Me.Prenom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Prenom_Agent_Text.ContextMenuStrip = Nothing
        Me.Prenom_Agent_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Prenom_Agent_Text.Location = New System.Drawing.Point(425, 39)
        Me.Prenom_Agent_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Prenom_Agent_Text.MaxLength = 32767
        Me.Prenom_Agent_Text.Multiline = False
        Me.Prenom_Agent_Text.Name = "Prenom_Agent_Text"
        Me.Prenom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Prenom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Prenom_Agent_Text.ReadOnly = False
        Me.Prenom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Prenom_Agent_Text.SelectionStart = 0
        Me.Prenom_Agent_Text.Size = New System.Drawing.Size(246, 26)
        Me.Prenom_Agent_Text.TabIndex = 224
        Me.Prenom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Prenom_Agent_Text.UseSystemPasswordChar = False
        '
        'Nom_
        '
        Me.Nom_.AutoSize = True
        Me.Nom_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_.Location = New System.Drawing.Point(56, 42)
        Me.Nom_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Nom_.Name = "Nom_"
        Me.Nom_.Size = New System.Drawing.Size(41, 19)
        Me.Nom_.TabIndex = 226
        Me.Nom_.Text = "Nom"
        '
        'Prenom_
        '
        Me.Prenom_.AutoSize = True
        Me.Prenom_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Prenom_.Location = New System.Drawing.Point(358, 42)
        Me.Prenom_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Prenom_.Name = "Prenom_"
        Me.Prenom_.Size = New System.Drawing.Size(61, 19)
        Me.Prenom_.TabIndex = 227
        Me.Prenom_.Text = "Prenom"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.statut_lb)
        Me.Panel1.Controls.Add(Me.Cod_Simulation_Text)
        Me.Panel1.Controls.Add(Me.considerCumuls_chk)
        Me.Panel1.Controls.Add(Me.Plan_Paie_)
        Me.Panel1.Controls.Add(Me.DatSimulation)
        Me.Panel1.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.Panel1.Controls.Add(Me.Lib_Plan_Paie_Text)
        Me.Panel1.Controls.Add(Me.Valide_Check)
        Me.Panel1.Controls.Add(Me.Lib_Simulation_Text)
        Me.Panel1.Controls.Add(Me.Cod_Simulation_)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(4, 21)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1126, 119)
        Me.Panel1.TabIndex = 273
        '
        'statut_lb
        '
        Me.statut_lb.AutoSize = True
        Me.statut_lb.Location = New System.Drawing.Point(680, 25)
        Me.statut_lb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.statut_lb.Name = "statut_lb"
        Me.statut_lb.Size = New System.Drawing.Size(0, 19)
        Me.statut_lb.TabIndex = 273
        Me.statut_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cod_Simulation_Text
        '
        Me.Cod_Simulation_Text.AccessibleDescription = "A"
        Me.Cod_Simulation_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Simulation_Text.ContextMenuStrip = Nothing
        Me.Cod_Simulation_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Simulation_Text.Location = New System.Drawing.Point(102, 19)
        Me.Cod_Simulation_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Simulation_Text.MaxLength = 32767
        Me.Cod_Simulation_Text.Multiline = False
        Me.Cod_Simulation_Text.Name = "Cod_Simulation_Text"
        Me.Cod_Simulation_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Simulation_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Simulation_Text.ReadOnly = False
        Me.Cod_Simulation_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Simulation_Text.SelectionStart = 0
        Me.Cod_Simulation_Text.Size = New System.Drawing.Size(161, 26)
        Me.Cod_Simulation_Text.TabIndex = 247
        Me.Cod_Simulation_Text.TabStop = False
        Me.Cod_Simulation_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Simulation_Text.UseSystemPasswordChar = False
        '
        'considerCumuls_chk
        '
        Me.considerCumuls_chk.AutoSize = True
        Me.considerCumuls_chk.Checked = False
        Me.considerCumuls_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.considerCumuls_chk.Location = New System.Drawing.Point(102, 50)
        Me.considerCumuls_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.considerCumuls_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.considerCumuls_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.considerCumuls_chk.Name = "considerCumuls_chk"
        Me.considerCumuls_chk.Size = New System.Drawing.Size(274, 31)
        Me.considerCumuls_chk.TabIndex = 272
        Me.considerCumuls_chk.Text = "Tenir compte des cumuls de la paie"
        '
        'Plan_Paie_
        '
        Me.Plan_Paie_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Plan_Paie_.AutoSize = True
        Me.Plan_Paie_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Plan_Paie_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Plan_Paie_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Plan_Paie_.Location = New System.Drawing.Point(61, 84)
        Me.Plan_Paie_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Plan_Paie_.Name = "Plan_Paie_"
        Me.Plan_Paie_.Size = New System.Drawing.Size(39, 19)
        Me.Plan_Paie_.TabIndex = 243
        Me.Plan_Paie_.TabStop = True
        Me.Plan_Paie_.Tag = "NC"
        Me.Plan_Paie_.Text = "Plan"
        '
        'DatSimulation
        '
        Me.DatSimulation.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatSimulation.Location = New System.Drawing.Point(560, 48)
        Me.DatSimulation.Margin = New System.Windows.Forms.Padding(4)
        Me.DatSimulation.Name = "DatSimulation"
        Me.DatSimulation.Size = New System.Drawing.Size(112, 24)
        Me.DatSimulation.TabIndex = 271
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(102, 79)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Plan_Paie_Text.MaxLength = 50
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = False
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(98, 26)
        Me.Cod_Plan_Paie_Text.TabIndex = 245
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Lib_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(202, 79)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Plan_Paie_Text.MaxLength = 50
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = True
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(469, 26)
        Me.Lib_Plan_Paie_Text.TabIndex = 244
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Valide_Check
        '
        Me.Valide_Check.AutoSize = True
        Me.Valide_Check.Checked = True
        Me.Valide_Check.Enabled = False
        Me.Valide_Check.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Valide_Check.Location = New System.Drawing.Point(680, 46)
        Me.Valide_Check.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Valide_Check.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Valide_Check.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Valide_Check.Name = "Valide_Check"
        Me.Valide_Check.Size = New System.Drawing.Size(146, 31)
        Me.Valide_Check.TabIndex = 251
        Me.Valide_Check.Text = "Validé"
        Me.Valide_Check.Visible = False
        '
        'Lib_Simulation_Text
        '
        Me.Lib_Simulation_Text.AccessibleDescription = "A"
        Me.Lib_Simulation_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Simulation_Text.ContextMenuStrip = Nothing
        Me.Lib_Simulation_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Simulation_Text.Location = New System.Drawing.Point(271, 19)
        Me.Lib_Simulation_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Simulation_Text.MaxLength = 32767
        Me.Lib_Simulation_Text.Multiline = False
        Me.Lib_Simulation_Text.Name = "Lib_Simulation_Text"
        Me.Lib_Simulation_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Simulation_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Simulation_Text.ReadOnly = False
        Me.Lib_Simulation_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Simulation_Text.SelectionStart = 0
        Me.Lib_Simulation_Text.Size = New System.Drawing.Size(401, 26)
        Me.Lib_Simulation_Text.TabIndex = 248
        Me.Lib_Simulation_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Simulation_Text.UseSystemPasswordChar = False
        '
        'Cod_Simulation_
        '
        Me.Cod_Simulation_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Simulation_.AutoSize = True
        Me.Cod_Simulation_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Simulation_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Simulation_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Simulation_.Location = New System.Drawing.Point(29, 21)
        Me.Cod_Simulation_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Cod_Simulation_.Name = "Cod_Simulation_"
        Me.Cod_Simulation_.Size = New System.Drawing.Size(71, 19)
        Me.Cod_Simulation_.TabIndex = 246
        Me.Cod_Simulation_.TabStop = True
        Me.Cod_Simulation_.Tag = ""
        Me.Cod_Simulation_.Text = "Simlation"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1150, 640)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1142, 608)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Fiche"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.MyGrd)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1142, 608)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Détail de calcul de la simulation"
        '
        'RH_Simulation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1150, 640)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RH_Simulation"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Simulation de la paie"
        CType(Me.MyGrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Pnl_Agent.ResumeLayout(False)
        Me.Pnl_Agent.PerformLayout()
        Me.OrganismesSociaux.ResumeLayout(False)
        Me.OrganismesSociaux.PerformLayout()
        CType(Me.Nbr_Personne_A_Charge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyGrd As ud_Grd
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Prenom_Agent_Text As ud_TextBox
    Friend WithEvents Nom_ As Label
    Friend WithEvents Prenom_ As Label
    Friend WithEvents Nbr_Personne_A_Charge As NumericUpDown
    Friend WithEvents Nbr_Personne_A_Charge_ As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Titre_txt As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Entite_ As LinkLabel
    Friend WithEvents Poste_Text As ud_TextBox
    Friend WithEvents Grade_ As LinkLabel
    Friend WithEvents Lib_Poste_Text As ud_TextBox
    Friend WithEvents Grade_Text As ud_TextBox
    Friend WithEvents Poste_ As LinkLabel
    Friend WithEvents Lib_Grade_Text As ud_TextBox
    Friend WithEvents Plan_Paie_ As LinkLabel
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Cod_Simulation_ As LinkLabel
    Friend WithEvents Cod_Simulation_Text As ud_TextBox
    Friend WithEvents Lib_Simulation_Text As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_Text As ud_TextBox
    Friend WithEvents Valide_Check As ud_CheckBox
    Friend WithEvents Dat_Entree_Text As ud_TextBox
    Friend WithEvents Dat_Entree_ As LinkLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents OrganismesSociaux As GroupBox
    Friend WithEvents Organisme4_Text As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Organisme3_Text As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Organisme2_Text As ud_TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Organisme1_Text As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CNSS_Text As ud_TextBox
    Friend WithEvents CNSS_ As Label
    Friend WithEvents Dat_Naissance_Text As ud_TextBox
    Friend WithEvents Dat_Naissance_ As LinkLabel
    Friend WithEvents Proprietaire_ As Label
    Friend WithEvents Situation As ud_ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Typ_Periode As ud_ComboBox
    Friend WithEvents Typ_Contrat_ As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Typ_Contrat As ud_ComboBox
    Friend WithEvents Typ_Agent As ud_ComboBox
    Friend WithEvents Civilite_ As Label
    Friend WithEvents Civilite_Combo As ud_ComboBox
    Friend WithEvents Pnl_Agent As Panel
    Friend WithEvents DatSimulation As DateTimePicker
    Friend WithEvents considerCumuls_chk As ud_CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents statut_lb As Label
    Friend WithEvents estNouvelleRecrue_chk As ud_CheckBox
End Class
