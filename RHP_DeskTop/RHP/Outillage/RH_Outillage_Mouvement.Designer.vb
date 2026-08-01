<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Outillage_Mouvement
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grd_Detail = New RHP.ud_Grd()
        Me.Cod_Outillage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Outillage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Outillage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Num_Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qte_Dispo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Mouvement_txt = New RHP.ud_TextBox()
        Me.Typ_Mouvement_cmb = New RHP.ud_ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.Num_Mouvement_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lib_Poste_Text = New RHP.ud_TextBox()
        Me.Poste_Text = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Detail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grd_Detail)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1139, 608)
        Me.Panel1.TabIndex = 0
        '
        'Grd_Detail
        '
        Me.Grd_Detail.AfficherLesEntetesLignes = True
        Me.Grd_Detail.AlternerLesLignes = False
        Me.Grd_Detail.BackgroundColor = System.Drawing.Color.White
        Me.Grd_Detail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Detail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Detail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Detail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Outillage, Me.Lib_Outillage, Me.Typ_Outillage, Me.Num_Serie, Me.Qte_Dispo, Me.Qte})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Detail.DefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Detail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Detail.EnableHeadersVisualStyles = False
        Me.Grd_Detail.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Detail.Location = New System.Drawing.Point(0, 260)
        Me.Grd_Detail.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Detail.Name = "Grd_Detail"
        Me.Grd_Detail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Detail.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Grd_Detail.RowHeadersWidth = 51
        Me.Grd_Detail.Size = New System.Drawing.Size(1139, 348)
        Me.Grd_Detail.TabIndex = 2
        '
        'Cod_Outillage
        '
        Me.Cod_Outillage.HeaderText = "Code"
        Me.Cod_Outillage.MinimumWidth = 6
        Me.Cod_Outillage.Name = "Cod_Outillage"
        Me.Cod_Outillage.ReadOnly = True
        Me.Cod_Outillage.Width = 110
        '
        'Lib_Outillage
        '
        Me.Lib_Outillage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Lib_Outillage.HeaderText = "Désignation"
        Me.Lib_Outillage.MinimumWidth = 150
        Me.Lib_Outillage.Name = "Lib_Outillage"
        Me.Lib_Outillage.ReadOnly = True
        '
        'Typ_Outillage
        '
        Me.Typ_Outillage.HeaderText = "Type"
        Me.Typ_Outillage.MinimumWidth = 6
        Me.Typ_Outillage.Name = "Typ_Outillage"
        Me.Typ_Outillage.ReadOnly = True
        Me.Typ_Outillage.Width = 120
        '
        'Num_Serie
        '
        Me.Num_Serie.HeaderText = "N° Série"
        Me.Num_Serie.MinimumWidth = 6
        Me.Num_Serie.Name = "Num_Serie"
        Me.Num_Serie.ReadOnly = True
        Me.Num_Serie.Width = 140
        '
        'Qte_Dispo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Qte_Dispo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Qte_Dispo.HeaderText = "Qté disponible"
        Me.Qte_Dispo.MinimumWidth = 6
        Me.Qte_Dispo.Name = "Qte_Dispo"
        Me.Qte_Dispo.ReadOnly = True
        Me.Qte_Dispo.Width = 110
        '
        'Qte
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Qte.DefaultCellStyle = DataGridViewCellStyle3
        Me.Qte.HeaderText = "Quantité"
        Me.Qte.MinimumWidth = 6
        Me.Qte.Name = "Qte"
        Me.Qte.Width = 90
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Commentaire_txt)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.Dat_Mouvement_txt)
        Me.GroupBox2.Controls.Add(Me.Typ_Mouvement_cmb)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 160)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1139, 100)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Détail du mouvement"
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.ContextMenuStrip = Nothing
        Me.Commentaire_txt.Location = New System.Drawing.Point(144, 58)
        Me.Commentaire_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Commentaire_txt.MaxLength = 500
        Me.Commentaire_txt.Multiline = False
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(741, 26)
        Me.Commentaire_txt.TabIndex = 263
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 19)
        Me.Label8.TabIndex = 262
        Me.Label8.Text = "Commentaire"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(438, 28)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(43, 19)
        Me.LinkLabel1.TabIndex = 257
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Date"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dat_Mouvement_txt
        '
        Me.Dat_Mouvement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Mouvement_txt.ContextMenuStrip = Nothing
        Me.Dat_Mouvement_txt.Location = New System.Drawing.Point(485, 24)
        Me.Dat_Mouvement_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Mouvement_txt.MaxLength = 10
        Me.Dat_Mouvement_txt.Multiline = False
        Me.Dat_Mouvement_txt.Name = "Dat_Mouvement_txt"
        Me.Dat_Mouvement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Mouvement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Mouvement_txt.ReadOnly = True
        Me.Dat_Mouvement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Mouvement_txt.SelectionStart = 0
        Me.Dat_Mouvement_txt.Size = New System.Drawing.Size(100, 26)
        Me.Dat_Mouvement_txt.TabIndex = 256
        Me.Dat_Mouvement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Mouvement_txt.UseSystemPasswordChar = False
        '
        'Typ_Mouvement_cmb
        '
        Me.Typ_Mouvement_cmb.DataSource = Nothing
        Me.Typ_Mouvement_cmb.DisplayMember = ""
        Me.Typ_Mouvement_cmb.DroppedDown = False
        Me.Typ_Mouvement_cmb.Location = New System.Drawing.Point(144, 24)
        Me.Typ_Mouvement_cmb.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Mouvement_cmb.Name = "Typ_Mouvement_cmb"
        Me.Typ_Mouvement_cmb.SelectedIndex = -1
        Me.Typ_Mouvement_cmb.SelectedItem = Nothing
        Me.Typ_Mouvement_cmb.SelectedValue = Nothing
        Me.Typ_Mouvement_cmb.Size = New System.Drawing.Size(250, 29)
        Me.Typ_Mouvement_cmb.TabIndex = 261
        Me.Typ_Mouvement_cmb.ValueMember = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 19)
        Me.Label7.TabIndex = 260
        Me.Label7.Text = "Type mouvement"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pb_Valide)
        Me.GroupBox1.Controls.Add(Me.Num_Mouvement_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel3)
        Me.GroupBox1.Controls.Add(Me.Matricule_txt)
        Me.GroupBox1.Controls.Add(Me.Matricule_)
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
        Me.GroupBox1.Size = New System.Drawing.Size(1139, 160)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agent"
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
        'Num_Mouvement_txt
        '
        Me.Num_Mouvement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Mouvement_txt.ContextMenuStrip = Nothing
        Me.Num_Mouvement_txt.Location = New System.Drawing.Point(134, 26)
        Me.Num_Mouvement_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Num_Mouvement_txt.MaxLength = 20
        Me.Num_Mouvement_txt.Multiline = False
        Me.Num_Mouvement_txt.Name = "Num_Mouvement_txt"
        Me.Num_Mouvement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Mouvement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Mouvement_txt.ReadOnly = True
        Me.Num_Mouvement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Mouvement_txt.SelectionStart = 0
        Me.Num_Mouvement_txt.Size = New System.Drawing.Size(158, 26)
        Me.Num_Mouvement_txt.TabIndex = 251
        Me.Num_Mouvement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Mouvement_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(18, 29)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(113, 19)
        Me.LinkLabel3.TabIndex = 250
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "N° Mouvement"
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
        'RH_Outillage_Mouvement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1139, 608)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Outillage_Mouvement"
        Me.Tag = "ECR"
        Me.Text = "Gestion des Outillages / Matériels"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Detail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents Num_Mouvement_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Typ_Mouvement_cmb As ud_ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Dat_Mouvement_txt As ud_TextBox
    Friend WithEvents Commentaire_txt As ud_TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Grd_Detail As ud_Grd
    Friend WithEvents Cod_Outillage As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Outillage As DataGridViewTextBoxColumn
    Friend WithEvents Typ_Outillage As DataGridViewTextBoxColumn
    Friend WithEvents Num_Serie As DataGridViewTextBoxColumn
    Friend WithEvents Qte_Dispo As DataGridViewTextBoxColumn
    Friend WithEvents Qte As DataGridViewTextBoxColumn
End Class
