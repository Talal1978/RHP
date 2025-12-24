<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Discipline
    Inherits Ecran

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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Pnl_Duree = New System.Windows.Forms.Panel()
        Me.Duree_Sanction = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl_Affectation = New System.Windows.Forms.Panel()
        Me.Lib_Poste_Transfert_txt = New RHP.ud_TextBox()
        Me.Cod_Poste_Transfert_txt = New RHP.ud_TextBox()
        Me.Affectation_Transfert_txt = New RHP.ud_TextBox()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Affectation_Transfert_txt = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Ref_PV_txt = New RHP.ud_TextBox()
        Me.Motif_txt = New RHP.ud_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Typ_Sanction_cmb = New RHP.ud_ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Decision_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Faute_txt = New RHP.ud_TextBox()
        Me.Observation_txt = New RHP.ud_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.Cod_Sanction_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Sanction_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lib_Poste_Text = New RHP.ud_TextBox()
        Me.Poste_Text = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dat_Entree_txt = New RHP.ud_TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Pnl_Duree.SuspendLayout()
        CType(Me.Duree_Sanction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Affectation.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1139, 608)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Pnl_Duree)
        Me.GroupBox2.Controls.Add(Me.Pnl_Affectation)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Ref_PV_txt)
        Me.GroupBox2.Controls.Add(Me.Motif_txt)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Typ_Sanction_cmb)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.LinkLabel2)
        Me.GroupBox2.Controls.Add(Me.Dat_Decision_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.Dat_Faute_txt)
        Me.GroupBox2.Controls.Add(Me.Observation_txt)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 184)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1139, 424)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Détail Sanction"
        '
        'Pnl_Duree
        '
        Me.Pnl_Duree.Controls.Add(Me.Duree_Sanction)
        Me.Pnl_Duree.Controls.Add(Me.Label1)
        Me.Pnl_Duree.Location = New System.Drawing.Point(555, 100)
        Me.Pnl_Duree.Name = "Pnl_Duree"
        Me.Pnl_Duree.Size = New System.Drawing.Size(381, 36)
        Me.Pnl_Duree.TabIndex = 273
        '
        'Duree_Sanction
        '
        Me.Duree_Sanction.Location = New System.Drawing.Point(218, 6)
        Me.Duree_Sanction.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.Duree_Sanction.Name = "Duree_Sanction"
        Me.Duree_Sanction.Size = New System.Drawing.Size(100, 24)
        Me.Duree_Sanction.TabIndex = 270
        Me.Duree_Sanction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Duree_Sanction.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 19)
        Me.Label1.TabIndex = 271
        Me.Label1.Text = "Durée de la sanction en jours"
        '
        'Pnl_Affectation
        '
        Me.Pnl_Affectation.Controls.Add(Me.Lib_Poste_Transfert_txt)
        Me.Pnl_Affectation.Controls.Add(Me.Cod_Poste_Transfert_txt)
        Me.Pnl_Affectation.Controls.Add(Me.Affectation_Transfert_txt)
        Me.Pnl_Affectation.Controls.Add(Me.LinkLabel5)
        Me.Pnl_Affectation.Controls.Add(Me.Lib_Affectation_Transfert_txt)
        Me.Pnl_Affectation.Controls.Add(Me.LinkLabel4)
        Me.Pnl_Affectation.Location = New System.Drawing.Point(25, 140)
        Me.Pnl_Affectation.Name = "Pnl_Affectation"
        Me.Pnl_Affectation.Size = New System.Drawing.Size(911, 71)
        Me.Pnl_Affectation.TabIndex = 272
        '
        'Lib_Poste_Transfert_txt
        '
        Me.Lib_Poste_Transfert_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Poste_Transfert_txt.ContextMenuStrip = Nothing
        Me.Lib_Poste_Transfert_txt.Location = New System.Drawing.Point(268, 5)
        Me.Lib_Poste_Transfert_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Poste_Transfert_txt.MaxLength = 100
        Me.Lib_Poste_Transfert_txt.Multiline = False
        Me.Lib_Poste_Transfert_txt.Name = "Lib_Poste_Transfert_txt"
        Me.Lib_Poste_Transfert_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_Transfert_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_Transfert_txt.ReadOnly = True
        Me.Lib_Poste_Transfert_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_Transfert_txt.SelectionStart = 0
        Me.Lib_Poste_Transfert_txt.Size = New System.Drawing.Size(579, 26)
        Me.Lib_Poste_Transfert_txt.TabIndex = 266
        Me.Lib_Poste_Transfert_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_Transfert_txt.UseSystemPasswordChar = False
        '
        'Cod_Poste_Transfert_txt
        '
        Me.Cod_Poste_Transfert_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Poste_Transfert_txt.ContextMenuStrip = Nothing
        Me.Cod_Poste_Transfert_txt.Location = New System.Drawing.Point(106, 5)
        Me.Cod_Poste_Transfert_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Poste_Transfert_txt.MaxLength = 10
        Me.Cod_Poste_Transfert_txt.Multiline = False
        Me.Cod_Poste_Transfert_txt.Name = "Cod_Poste_Transfert_txt"
        Me.Cod_Poste_Transfert_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Poste_Transfert_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Poste_Transfert_txt.ReadOnly = True
        Me.Cod_Poste_Transfert_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Poste_Transfert_txt.SelectionStart = 0
        Me.Cod_Poste_Transfert_txt.Size = New System.Drawing.Size(158, 26)
        Me.Cod_Poste_Transfert_txt.TabIndex = 267
        Me.Cod_Poste_Transfert_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Poste_Transfert_txt.UseSystemPasswordChar = False
        '
        'Affectation_Transfert_txt
        '
        Me.Affectation_Transfert_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Affectation_Transfert_txt.ContextMenuStrip = Nothing
        Me.Affectation_Transfert_txt.Location = New System.Drawing.Point(106, 37)
        Me.Affectation_Transfert_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Affectation_Transfert_txt.MaxLength = 10
        Me.Affectation_Transfert_txt.Multiline = False
        Me.Affectation_Transfert_txt.Name = "Affectation_Transfert_txt"
        Me.Affectation_Transfert_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Affectation_Transfert_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Affectation_Transfert_txt.ReadOnly = True
        Me.Affectation_Transfert_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Affectation_Transfert_txt.SelectionStart = 0
        Me.Affectation_Transfert_txt.Size = New System.Drawing.Size(158, 26)
        Me.Affectation_Transfert_txt.TabIndex = 267
        Me.Affectation_Transfert_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Affectation_Transfert_txt.UseSystemPasswordChar = False
        '
        'LinkLabel5
        '
        Me.LinkLabel5.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.Location = New System.Drawing.Point(18, 40)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(85, 19)
        Me.LinkLabel5.TabIndex = 269
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Affectation"
        Me.LinkLabel5.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Affectation_Transfert_txt
        '
        Me.Lib_Affectation_Transfert_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Affectation_Transfert_txt.ContextMenuStrip = Nothing
        Me.Lib_Affectation_Transfert_txt.Location = New System.Drawing.Point(268, 37)
        Me.Lib_Affectation_Transfert_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Lib_Affectation_Transfert_txt.MaxLength = 100
        Me.Lib_Affectation_Transfert_txt.Multiline = False
        Me.Lib_Affectation_Transfert_txt.Name = "Lib_Affectation_Transfert_txt"
        Me.Lib_Affectation_Transfert_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Affectation_Transfert_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Affectation_Transfert_txt.ReadOnly = True
        Me.Lib_Affectation_Transfert_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Affectation_Transfert_txt.SelectionStart = 0
        Me.Lib_Affectation_Transfert_txt.Size = New System.Drawing.Size(579, 26)
        Me.Lib_Affectation_Transfert_txt.TabIndex = 266
        Me.Lib_Affectation_Transfert_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Affectation_Transfert_txt.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(4, 8)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(99, 19)
        Me.LinkLabel4.TabIndex = 269
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Poste destiné"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(74, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 19)
        Me.Label5.TabIndex = 265
        Me.Label5.Text = "Réf. PV"
        '
        'Ref_PV_txt
        '
        Me.Ref_PV_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ref_PV_txt.ContextMenuStrip = Nothing
        Me.Ref_PV_txt.Location = New System.Drawing.Point(134, 72)
        Me.Ref_PV_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Ref_PV_txt.MaxLength = 100
        Me.Ref_PV_txt.Multiline = False
        Me.Ref_PV_txt.Name = "Ref_PV_txt"
        Me.Ref_PV_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ref_PV_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ref_PV_txt.ReadOnly = False
        Me.Ref_PV_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ref_PV_txt.SelectionStart = 0
        Me.Ref_PV_txt.Size = New System.Drawing.Size(244, 26)
        Me.Ref_PV_txt.TabIndex = 264
        Me.Ref_PV_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ref_PV_txt.UseSystemPasswordChar = False
        '
        'Motif_txt
        '
        Me.Motif_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Motif_txt.ContextMenuStrip = Nothing
        Me.Motif_txt.Location = New System.Drawing.Point(134, 24)
        Me.Motif_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Motif_txt.MaxLength = 32767
        Me.Motif_txt.Multiline = True
        Me.Motif_txt.Name = "Motif_txt"
        Me.Motif_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Motif_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Motif_txt.ReadOnly = False
        Me.Motif_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Motif_txt.SelectionStart = 0
        Me.Motif_txt.Size = New System.Drawing.Size(741, 42)
        Me.Motif_txt.TabIndex = 263
        Me.Motif_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Motif_txt.UseSystemPasswordChar = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(87, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 19)
        Me.Label8.TabIndex = 262
        Me.Label8.Text = "Motif"
        '
        'Typ_Sanction_cmb
        '
        Me.Typ_Sanction_cmb.DataSource = Nothing
        Me.Typ_Sanction_cmb.DisplayMember = ""
        Me.Typ_Sanction_cmb.DroppedDown = False
        Me.Typ_Sanction_cmb.Location = New System.Drawing.Point(134, 104)
        Me.Typ_Sanction_cmb.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Sanction_cmb.Name = "Typ_Sanction_cmb"
        Me.Typ_Sanction_cmb.SelectedIndex = -1
        Me.Typ_Sanction_cmb.SelectedItem = Nothing
        Me.Typ_Sanction_cmb.SelectedValue = Nothing
        Me.Typ_Sanction_cmb.Size = New System.Drawing.Size(309, 29)
        Me.Typ_Sanction_cmb.TabIndex = 261
        Me.Typ_Sanction_cmb.ValueMember = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 19)
        Me.Label7.TabIndex = 260
        Me.Label7.Text = "Type Sanction"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(668, 78)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(104, 19)
        Me.LinkLabel2.TabIndex = 259
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Date Décision"
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dat_Decision_txt
        '
        Me.Dat_Decision_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Decision_txt.ContextMenuStrip = Nothing
        Me.Dat_Decision_txt.Location = New System.Drawing.Point(775, 75)
        Me.Dat_Decision_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Decision_txt.MaxLength = 10
        Me.Dat_Decision_txt.Multiline = False
        Me.Dat_Decision_txt.Name = "Dat_Decision_txt"
        Me.Dat_Decision_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Decision_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Decision_txt.ReadOnly = True
        Me.Dat_Decision_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Decision_txt.SelectionStart = 0
        Me.Dat_Decision_txt.Size = New System.Drawing.Size(100, 26)
        Me.Dat_Decision_txt.TabIndex = 258
        Me.Dat_Decision_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Decision_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(442, 75)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(87, 19)
        Me.LinkLabel1.TabIndex = 257
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Date Faute"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dat_Faute_txt
        '
        Me.Dat_Faute_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Faute_txt.ContextMenuStrip = Nothing
        Me.Dat_Faute_txt.Location = New System.Drawing.Point(532, 72)
        Me.Dat_Faute_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Faute_txt.MaxLength = 10
        Me.Dat_Faute_txt.Multiline = False
        Me.Dat_Faute_txt.Name = "Dat_Faute_txt"
        Me.Dat_Faute_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Faute_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Faute_txt.ReadOnly = True
        Me.Dat_Faute_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Faute_txt.SelectionStart = 0
        Me.Dat_Faute_txt.Size = New System.Drawing.Size(100, 26)
        Me.Dat_Faute_txt.TabIndex = 256
        Me.Dat_Faute_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Faute_txt.UseSystemPasswordChar = False
        '
        'Observation_txt
        '
        Me.Observation_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Observation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Observation_txt.ContextMenuStrip = Nothing
        Me.Observation_txt.Location = New System.Drawing.Point(3, 235)
        Me.Observation_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Observation_txt.MaxLength = 32767
        Me.Observation_txt.Multiline = True
        Me.Observation_txt.Name = "Observation_txt"
        Me.Observation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Observation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Observation_txt.ReadOnly = False
        Me.Observation_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Observation_txt.SelectionStart = 0
        Me.Observation_txt.Size = New System.Drawing.Size(1133, 172)
        Me.Observation_txt.TabIndex = 1
        Me.Observation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Observation_txt.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Observations"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Dat_Entree_txt)
        Me.GroupBox1.Controls.Add(Me.pb_Valide)
        Me.GroupBox1.Controls.Add(Me.Cod_Sanction_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel3)
        Me.GroupBox1.Controls.Add(Me.Matricule_txt)
        Me.GroupBox1.Controls.Add(Me.Matricule_)
        Me.GroupBox1.Controls.Add(Me.Lib_Sanction_txt)
        Me.GroupBox1.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox1.Controls.Add(Me.Lib_Entite_txt)
        Me.GroupBox1.Controls.Add(Me.Cod_Entite_txt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Lib_Poste_Text)
        Me.GroupBox1.Controls.Add(Me.Poste_Text)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1139, 184)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employé"
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(894, 49)
        Me.pb_Valide.Margin = New System.Windows.Forms.Padding(4)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(78, 78)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Valide.TabIndex = 254
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'Cod_Sanction_txt
        '
        Me.Cod_Sanction_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Sanction_txt.ContextMenuStrip = Nothing
        Me.Cod_Sanction_txt.Location = New System.Drawing.Point(134, 26)
        Me.Cod_Sanction_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Sanction_txt.MaxLength = 20
        Me.Cod_Sanction_txt.Multiline = False
        Me.Cod_Sanction_txt.Name = "Cod_Sanction_txt"
        Me.Cod_Sanction_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Sanction_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Sanction_txt.ReadOnly = True
        Me.Cod_Sanction_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Sanction_txt.SelectionStart = 0
        Me.Cod_Sanction_txt.Size = New System.Drawing.Size(158, 31)
        Me.Cod_Sanction_txt.TabIndex = 251
        Me.Cod_Sanction_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Sanction_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(61, 31)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(70, 19)
        Me.LinkLabel3.TabIndex = 250
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Sanction"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Matricule_txt
        '
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(134, 61)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Matricule_txt.MaxLength = 20
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(158, 26)
        Me.Matricule_txt.TabIndex = 217
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(57, 64)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 216
        Me.Matricule_.TabStop = True
        Me.Matricule_.Text = "Matricule"
        Me.Matricule_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Sanction_txt
        '
        Me.Lib_Sanction_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Sanction_txt.ContextMenuStrip = Nothing
        Me.Lib_Sanction_txt.Location = New System.Drawing.Point(296, 26)
        Me.Lib_Sanction_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Sanction_txt.MaxLength = 200
        Me.Lib_Sanction_txt.Multiline = False
        Me.Lib_Sanction_txt.Name = "Lib_Sanction_txt"
        Me.Lib_Sanction_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Sanction_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Sanction_txt.ReadOnly = False
        Me.Lib_Sanction_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Sanction_txt.SelectionStart = 0
        Me.Lib_Sanction_txt.Size = New System.Drawing.Size(579, 31)
        Me.Lib_Sanction_txt.TabIndex = 218
        Me.Lib_Sanction_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Sanction_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(296, 61)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Nom_Agent_Text.MaxLength = 100
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(579, 26)
        Me.Nom_Agent_Text.TabIndex = 218
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(296, 119)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Lib_Entite_txt.MaxLength = 100
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(579, 26)
        Me.Lib_Entite_txt.TabIndex = 244
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(134, 119)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cod_Entite_txt.MaxLength = 10
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(158, 26)
        Me.Cod_Entite_txt.TabIndex = 245
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(83, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 19)
        Me.Label4.TabIndex = 246
        Me.Label4.Text = "Entité"
        '
        'Lib_Poste_Text
        '
        Me.Lib_Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Poste_Text.ContextMenuStrip = Nothing
        Me.Lib_Poste_Text.Location = New System.Drawing.Point(296, 90)
        Me.Lib_Poste_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Lib_Poste_Text.MaxLength = 100
        Me.Lib_Poste_Text.Multiline = False
        Me.Lib_Poste_Text.Name = "Lib_Poste_Text"
        Me.Lib_Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_Text.ReadOnly = True
        Me.Lib_Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_Text.SelectionStart = 0
        Me.Lib_Poste_Text.Size = New System.Drawing.Size(579, 26)
        Me.Lib_Poste_Text.TabIndex = 247
        Me.Lib_Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_Text.UseSystemPasswordChar = False
        '
        'Poste_Text
        '
        Me.Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Poste_Text.ContextMenuStrip = Nothing
        Me.Poste_Text.Location = New System.Drawing.Point(134, 90)
        Me.Poste_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Poste_Text.MaxLength = 10
        Me.Poste_Text.Multiline = False
        Me.Poste_Text.Name = "Poste_Text"
        Me.Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Poste_Text.ReadOnly = True
        Me.Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Poste_Text.SelectionStart = 0
        Me.Poste_Text.Size = New System.Drawing.Size(158, 26)
        Me.Poste_Text.TabIndex = 248
        Me.Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Poste_Text.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 19)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "Poste"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 19)
        Me.Label3.TabIndex = 268
        Me.Label3.Text = "Date d'entrée"
        '
        'Dat_Entree_txt
        '
        Me.Dat_Entree_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Entree_txt.ContextMenuStrip = Nothing
        Me.Dat_Entree_txt.Location = New System.Drawing.Point(134, 149)
        Me.Dat_Entree_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Dat_Entree_txt.MaxLength = 10
        Me.Dat_Entree_txt.Multiline = False
        Me.Dat_Entree_txt.Name = "Dat_Entree_txt"
        Me.Dat_Entree_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Entree_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Entree_txt.ReadOnly = True
        Me.Dat_Entree_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Entree_txt.SelectionStart = 0
        Me.Dat_Entree_txt.Size = New System.Drawing.Size(158, 26)
        Me.Dat_Entree_txt.TabIndex = 267
        Me.Dat_Entree_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Entree_txt.UseSystemPasswordChar = False
        '
        'RH_Discipline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1139, 608)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Discipline"
        Me.Tag = "ECR"
        Me.Text = "Saisie Mesure Disciplinaire"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Pnl_Duree.ResumeLayout(False)
        Me.Pnl_Duree.PerformLayout()
        CType(Me.Duree_Sanction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Affectation.ResumeLayout(False)
        Me.Pnl_Affectation.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Lib_Poste_Text As ud_TextBox
    Friend WithEvents Poste_Text As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Observation_txt As ud_TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Dat_Decision_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Dat_Faute_txt As ud_TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Typ_Sanction_cmb As ud_ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Motif_txt As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Ref_PV_txt As ud_TextBox
    Friend WithEvents Cod_Sanction_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Lib_Sanction_txt As ud_TextBox
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Lib_Affectation_Transfert_txt As ud_TextBox
    Friend WithEvents Lib_Poste_Transfert_txt As ud_TextBox
    Friend WithEvents Affectation_Transfert_txt As ud_TextBox
    Friend WithEvents Cod_Poste_Transfert_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Duree_Sanction As NumericUpDown
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Pnl_Duree As Panel
    Friend WithEvents Pnl_Affectation As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Dat_Entree_txt As ud_TextBox
End Class
