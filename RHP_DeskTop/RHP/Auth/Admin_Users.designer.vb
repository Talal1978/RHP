<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Users
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Liste des Paramètres de Configuration Générale")
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Nom_User_Text = New RHP.ud_TextBox()
        Me.GNR_FAM_GROUP = New System.Windows.Forms.GroupBox()
        Me.lv_Societes = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Login_User_Text = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Login_User_Label = New System.Windows.Forms.LinkLabel()
        Me.Typ_Role = New RHP.ud_ComboBox()
        Me.Nom_User_LABEL = New System.Windows.Forms.Label()
        Me.id_User_Text = New RHP.ud_TextBox()
        Me.Lib_Profile_Text = New RHP.ud_TextBox()
        Me.Prenom_User_Text = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Cod_Profile_Text = New RHP.ud_TextBox()
        Me.ANA_FAM_Art_Label = New System.Windows.Forms.Label()
        Me.Mouvemente_Check = New RHP.ud_CheckBox()
        Me.Mail_Text = New RHP.ud_TextBox()
        Me.Actif_Check = New RHP.ud_CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.is_AD_chk = New RHP.ud_CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Param_TreeView = New System.Windows.Forms.TreeView()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.ParamLabel = New System.Windows.Forms.Label()
        Me.Param_GRD = New RHP.ud_Grd()
        Me.Cod_Param = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Libelle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Param_General = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mnu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNR_FAM_GROUP.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.Param_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Nom_User_Text
        '
        Me.Nom_User_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Nom_User_Text.ContextMenuStrip = Nothing
        Me.Nom_User_Text.Location = New System.Drawing.Point(121, 45)
        Me.Nom_User_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Nom_User_Text.MaxLength = 32767
        Me.Nom_User_Text.Multiline = False
        Me.Nom_User_Text.Name = "Nom_User_Text"
        Me.Nom_User_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_User_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_User_Text.ReadOnly = False
        Me.Nom_User_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_User_Text.SelectionStart = 0
        Me.Nom_User_Text.Size = New System.Drawing.Size(250, 26)
        Me.Nom_User_Text.TabIndex = 1
        Me.Nom_User_Text.Tag = "NC"
        Me.Nom_User_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_User_Text.UseSystemPasswordChar = False
        '
        'GNR_FAM_GROUP
        '
        Me.GNR_FAM_GROUP.Controls.Add(Me.lv_Societes)
        Me.GNR_FAM_GROUP.Controls.Add(Me.Panel1)
        Me.GNR_FAM_GROUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GNR_FAM_GROUP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GNR_FAM_GROUP.Location = New System.Drawing.Point(4, 4)
        Me.GNR_FAM_GROUP.Margin = New System.Windows.Forms.Padding(4)
        Me.GNR_FAM_GROUP.Name = "GNR_FAM_GROUP"
        Me.GNR_FAM_GROUP.Padding = New System.Windows.Forms.Padding(4)
        Me.GNR_FAM_GROUP.Size = New System.Drawing.Size(1165, 721)
        Me.GNR_FAM_GROUP.TabIndex = 0
        Me.GNR_FAM_GROUP.TabStop = False
        Me.GNR_FAM_GROUP.Text = "Général"
        '
        'lv_Societes
        '
        Me.lv_Societes.CheckBoxes = True
        Me.lv_Societes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lv_Societes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_Societes.GridLines = True
        Me.lv_Societes.HideSelection = False
        Me.lv_Societes.Location = New System.Drawing.Point(4, 268)
        Me.lv_Societes.Name = "lv_Societes"
        Me.lv_Societes.Size = New System.Drawing.Size(1157, 449)
        Me.lv_Societes.TabIndex = 214
        Me.lv_Societes.UseCompatibleStateImageBehavior = False
        Me.lv_Societes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Société"
        Me.ColumnHeader1.Width = 300
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Login_User_Text)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Login_User_Label)
        Me.Panel1.Controls.Add(Me.Typ_Role)
        Me.Panel1.Controls.Add(Me.Nom_User_LABEL)
        Me.Panel1.Controls.Add(Me.id_User_Text)
        Me.Panel1.Controls.Add(Me.Nom_User_Text)
        Me.Panel1.Controls.Add(Me.Lib_Profile_Text)
        Me.Panel1.Controls.Add(Me.Prenom_User_Text)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.Cod_Profile_Text)
        Me.Panel1.Controls.Add(Me.ANA_FAM_Art_Label)
        Me.Panel1.Controls.Add(Me.Mouvemente_Check)
        Me.Panel1.Controls.Add(Me.Mail_Text)
        Me.Panel1.Controls.Add(Me.Actif_Check)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.is_AD_chk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(4, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1157, 247)
        Me.Panel1.TabIndex = 213
        '
        'Login_User_Text
        '
        Me.Login_User_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Login_User_Text.ContextMenuStrip = Nothing
        Me.Login_User_Text.Location = New System.Drawing.Point(121, 18)
        Me.Login_User_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Login_User_Text.MaxLength = 32767
        Me.Login_User_Text.Multiline = False
        Me.Login_User_Text.Name = "Login_User_Text"
        Me.Login_User_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Login_User_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Login_User_Text.ReadOnly = True
        Me.Login_User_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Login_User_Text.SelectionStart = 0
        Me.Login_User_Text.Size = New System.Drawing.Size(572, 26)
        Me.Login_User_Text.TabIndex = 0
        Me.Login_User_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Login_User_Text.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 143)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 19)
        Me.Label2.TabIndex = 212
        Me.Label2.Tag = "NC"
        Me.Label2.Text = "Type rôle"
        '
        'Login_User_Label
        '
        Me.Login_User_Label.AutoSize = True
        Me.Login_User_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Login_User_Label.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Login_User_Label.Location = New System.Drawing.Point(27, 110)
        Me.Login_User_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Login_User_Label.Name = "Login_User_Label"
        Me.Login_User_Label.Size = New System.Drawing.Size(92, 19)
        Me.Login_User_Label.TabIndex = 4
        Me.Login_User_Label.TabStop = True
        Me.Login_User_Label.Tag = ""
        Me.Login_User_Label.Text = "Code Profile"
        '
        'Typ_Role
        '
        Me.Typ_Role.DataSource = Nothing
        Me.Typ_Role.DisplayMember = ""
        Me.Typ_Role.DroppedDown = False
        Me.Typ_Role.Location = New System.Drawing.Point(121, 139)
        Me.Typ_Role.Margin = New System.Windows.Forms.Padding(5)
        Me.Typ_Role.Name = "Typ_Role"
        Me.Typ_Role.SelectedIndex = -1
        Me.Typ_Role.SelectedItem = Nothing
        Me.Typ_Role.SelectedValue = Nothing
        Me.Typ_Role.Size = New System.Drawing.Size(306, 30)
        Me.Typ_Role.TabIndex = 5
        Me.Typ_Role.ValueMember = ""
        '
        'Nom_User_LABEL
        '
        Me.Nom_User_LABEL.AutoSize = True
        Me.Nom_User_LABEL.Location = New System.Drawing.Point(20, 48)
        Me.Nom_User_LABEL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Nom_User_LABEL.Name = "Nom_User_LABEL"
        Me.Nom_User_LABEL.Size = New System.Drawing.Size(99, 19)
        Me.Nom_User_LABEL.TabIndex = 22
        Me.Nom_User_LABEL.Tag = "NC"
        Me.Nom_User_LABEL.Text = "Nom& prénom"
        '
        'id_User_Text
        '
        Me.id_User_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.id_User_Text.ContextMenuStrip = Nothing
        Me.id_User_Text.Location = New System.Drawing.Point(702, 18)
        Me.id_User_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.id_User_Text.MaxLength = 32767
        Me.id_User_Text.Multiline = False
        Me.id_User_Text.Name = "id_User_Text"
        Me.id_User_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.id_User_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.id_User_Text.ReadOnly = True
        Me.id_User_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.id_User_Text.SelectionStart = 0
        Me.id_User_Text.Size = New System.Drawing.Size(49, 26)
        Me.id_User_Text.TabIndex = 210
        Me.id_User_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.id_User_Text.UseSystemPasswordChar = False
        '
        'Lib_Profile_Text
        '
        Me.Lib_Profile_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Profile_Text.ContextMenuStrip = Nothing
        Me.Lib_Profile_Text.Location = New System.Drawing.Point(267, 108)
        Me.Lib_Profile_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Lib_Profile_Text.MaxLength = 32767
        Me.Lib_Profile_Text.Multiline = False
        Me.Lib_Profile_Text.Name = "Lib_Profile_Text"
        Me.Lib_Profile_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Profile_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Profile_Text.ReadOnly = True
        Me.Lib_Profile_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Profile_Text.SelectionStart = 0
        Me.Lib_Profile_Text.Size = New System.Drawing.Size(485, 26)
        Me.Lib_Profile_Text.TabIndex = 209
        Me.Lib_Profile_Text.Tag = ""
        Me.Lib_Profile_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Profile_Text.UseSystemPasswordChar = False
        '
        'Prenom_User_Text
        '
        Me.Prenom_User_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Prenom_User_Text.ContextMenuStrip = Nothing
        Me.Prenom_User_Text.Location = New System.Drawing.Point(374, 45)
        Me.Prenom_User_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Prenom_User_Text.MaxLength = 32767
        Me.Prenom_User_Text.Multiline = False
        Me.Prenom_User_Text.Name = "Prenom_User_Text"
        Me.Prenom_User_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Prenom_User_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Prenom_User_Text.ReadOnly = False
        Me.Prenom_User_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Prenom_User_Text.SelectionStart = 0
        Me.Prenom_User_Text.Size = New System.Drawing.Size(378, 26)
        Me.Prenom_User_Text.TabIndex = 2
        Me.Prenom_User_Text.Tag = "NC"
        Me.Prenom_User_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Prenom_User_Text.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(67, 20)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(49, 19)
        Me.LinkLabel2.TabIndex = 208
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = ""
        Me.LinkLabel2.Text = "Log In"
        '
        'Cod_Profile_Text
        '
        Me.Cod_Profile_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Profile_Text.ContextMenuStrip = Nothing
        Me.Cod_Profile_Text.Location = New System.Drawing.Point(121, 108)
        Me.Cod_Profile_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Cod_Profile_Text.MaxLength = 32767
        Me.Cod_Profile_Text.Multiline = False
        Me.Cod_Profile_Text.Name = "Cod_Profile_Text"
        Me.Cod_Profile_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Profile_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Profile_Text.ReadOnly = True
        Me.Cod_Profile_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Profile_Text.SelectionStart = 0
        Me.Cod_Profile_Text.Size = New System.Drawing.Size(138, 26)
        Me.Cod_Profile_Text.TabIndex = 200
        Me.Cod_Profile_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Profile_Text.UseSystemPasswordChar = False
        '
        'ANA_FAM_Art_Label
        '
        Me.ANA_FAM_Art_Label.AutoSize = True
        Me.ANA_FAM_Art_Label.Location = New System.Drawing.Point(371, 132)
        Me.ANA_FAM_Art_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ANA_FAM_Art_Label.Name = "ANA_FAM_Art_Label"
        Me.ANA_FAM_Art_Label.Size = New System.Drawing.Size(0, 19)
        Me.ANA_FAM_Art_Label.TabIndex = 35
        '
        'Mouvemente_Check
        '
        Me.Mouvemente_Check.AutoSize = True
        Me.Mouvemente_Check.Checked = True
        Me.Mouvemente_Check.Enabled = False
        Me.Mouvemente_Check.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mouvemente_Check.Location = New System.Drawing.Point(437, 139)
        Me.Mouvemente_Check.Margin = New System.Windows.Forms.Padding(5)
        Me.Mouvemente_Check.MaximumSize = New System.Drawing.Size(0, 28)
        Me.Mouvemente_Check.MinimumSize = New System.Drawing.Size(125, 28)
        Me.Mouvemente_Check.Name = "Mouvemente_Check"
        Me.Mouvemente_Check.Size = New System.Drawing.Size(125, 28)
        Me.Mouvemente_Check.TabIndex = 201
        Me.Mouvemente_Check.Text = "Mouvementé"
        '
        'Mail_Text
        '
        Me.Mail_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Mail_Text.ContextMenuStrip = Nothing
        Me.Mail_Text.Location = New System.Drawing.Point(121, 76)
        Me.Mail_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Mail_Text.MaxLength = 32767
        Me.Mail_Text.Multiline = False
        Me.Mail_Text.Name = "Mail_Text"
        Me.Mail_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Mail_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Mail_Text.ReadOnly = False
        Me.Mail_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mail_Text.SelectionStart = 0
        Me.Mail_Text.Size = New System.Drawing.Size(630, 26)
        Me.Mail_Text.TabIndex = 3
        Me.Mail_Text.Tag = "NC"
        Me.Mail_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Mail_Text.UseSystemPasswordChar = False
        '
        'Actif_Check
        '
        Me.Actif_Check.AutoSize = True
        Me.Actif_Check.Checked = True
        Me.Actif_Check.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Actif_Check.Location = New System.Drawing.Point(121, 208)
        Me.Actif_Check.Margin = New System.Windows.Forms.Padding(5)
        Me.Actif_Check.MaximumSize = New System.Drawing.Size(0, 28)
        Me.Actif_Check.MinimumSize = New System.Drawing.Size(125, 28)
        Me.Actif_Check.Name = "Actif_Check"
        Me.Actif_Check.Size = New System.Drawing.Size(125, 28)
        Me.Actif_Check.TabIndex = 202
        Me.Actif_Check.Tag = "NC"
        Me.Actif_Check.Text = "Actif"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 79)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 19)
        Me.Label1.TabIndex = 204
        Me.Label1.Tag = "NC"
        Me.Label1.Text = "Mail"
        '
        'is_AD_chk
        '
        Me.is_AD_chk.AutoSize = True
        Me.is_AD_chk.Checked = False
        Me.is_AD_chk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.is_AD_chk.Location = New System.Drawing.Point(121, 179)
        Me.is_AD_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.is_AD_chk.MaximumSize = New System.Drawing.Size(0, 28)
        Me.is_AD_chk.MinimumSize = New System.Drawing.Size(125, 28)
        Me.is_AD_chk.Name = "is_AD_chk"
        Me.is_AD_chk.Size = New System.Drawing.Size(250, 28)
        Me.is_AD_chk.TabIndex = 202
        Me.is_AD_chk.Tag = "NC"
        Me.is_AD_chk.Text = "Authentification par Active Directory"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1181, 761)
        Me.TabControl1.TabIndex = 210
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GNR_FAM_GROUP)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1173, 729)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Utilisateurs"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.SplitContainer1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Size = New System.Drawing.Size(1173, 729)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Paramètres"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 4)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2MinSize = 70
        Me.SplitContainer1.Size = New System.Drawing.Size(1165, 721)
        Me.SplitContainer1.SplitterDistance = 636
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Param_TreeView)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(1165, 636)
        Me.SplitContainer2.SplitterDistance = 386
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 6
        '
        'Param_TreeView
        '
        Me.Param_TreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Param_TreeView.Location = New System.Drawing.Point(0, 0)
        Me.Param_TreeView.Margin = New System.Windows.Forms.Padding(4)
        Me.Param_TreeView.Name = "Param_TreeView"
        TreeNode1.Name = "Param"
        TreeNode1.Text = "Liste des Paramètres de Configuration Générale"
        Me.Param_TreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.Param_TreeView.Size = New System.Drawing.Size(386, 636)
        Me.Param_TreeView.TabIndex = 5
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.ParamLabel)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Param_GRD)
        Me.SplitContainer3.Size = New System.Drawing.Size(774, 636)
        Me.SplitContainer3.SplitterDistance = 37
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 23
        '
        'ParamLabel
        '
        Me.ParamLabel.AutoSize = True
        Me.ParamLabel.Location = New System.Drawing.Point(19, 11)
        Me.ParamLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ParamLabel.Name = "ParamLabel"
        Me.ParamLabel.Size = New System.Drawing.Size(0, 19)
        Me.ParamLabel.TabIndex = 0
        '
        'Param_GRD
        '
        Me.Param_GRD.AfficherLesEntetesLignes = True
        Me.Param_GRD.AllowUserToAddRows = False
        Me.Param_GRD.AlternerLesLignes = False
        Me.Param_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Param_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Param_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Param_GRD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Param_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Param_GRD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Param, Me.Libelle, Me.Valeur, Me.Type, Me.Typ_Param_General, Me.Mnu})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Param_GRD.DefaultCellStyle = DataGridViewCellStyle2
        Me.Param_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Param_GRD.EnableHeadersVisualStyles = False
        Me.Param_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Param_GRD.Location = New System.Drawing.Point(0, 0)
        Me.Param_GRD.Margin = New System.Windows.Forms.Padding(4)
        Me.Param_GRD.Name = "Param_GRD"
        Me.Param_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Param_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Param_GRD.RowHeadersVisible = False
        Me.Param_GRD.RowHeadersWidth = 51
        Me.Param_GRD.Size = New System.Drawing.Size(774, 594)
        Me.Param_GRD.TabIndex = 4
        '
        'Cod_Param
        '
        Me.Cod_Param.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Cod_Param.HeaderText = "Cod_Param"
        Me.Cod_Param.MinimumWidth = 6
        Me.Cod_Param.Name = "Cod_Param"
        Me.Cod_Param.ReadOnly = True
        Me.Cod_Param.Visible = False
        Me.Cod_Param.Width = 125
        '
        'Libelle
        '
        Me.Libelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Libelle.HeaderText = "Paramètre"
        Me.Libelle.MinimumWidth = 6
        Me.Libelle.Name = "Libelle"
        Me.Libelle.ReadOnly = True
        Me.Libelle.Width = 119
        '
        'Valeur
        '
        Me.Valeur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.MinimumWidth = 6
        Me.Valeur.Name = "Valeur"
        Me.Valeur.Width = 91
        '
        'Type
        '
        Me.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Type.HeaderText = "Type"
        Me.Type.MinimumWidth = 6
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Visible = False
        Me.Type.Width = 125
        '
        'Typ_Param_General
        '
        Me.Typ_Param_General.HeaderText = "Typ_Param_General"
        Me.Typ_Param_General.MinimumWidth = 6
        Me.Typ_Param_General.Name = "Typ_Param_General"
        Me.Typ_Param_General.Visible = False
        Me.Typ_Param_General.Width = 125
        '
        'Mnu
        '
        Me.Mnu.HeaderText = "Menu"
        Me.Mnu.MinimumWidth = 6
        Me.Mnu.Name = "Mnu"
        Me.Mnu.Visible = False
        Me.Mnu.Width = 125
        '
        'Admin_Users
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1181, 761)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Admin_Users"
        Me.Tag = "ECR"
        Me.Text = "Gestion des utilisateurs"
        Me.GNR_FAM_GROUP.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.Param_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Nom_User_Text As ud_TextBox
    Friend WithEvents GNR_FAM_GROUP As System.Windows.Forms.GroupBox
    Friend WithEvents Nom_User_LABEL As System.Windows.Forms.Label
    Friend WithEvents Login_User_Label As System.Windows.Forms.LinkLabel
    Friend WithEvents ANA_FAM_Art_Label As System.Windows.Forms.Label
    Friend WithEvents Cod_Profile_Text As ud_TextBox
    Friend WithEvents Login_User_Text As ud_TextBox
    Friend WithEvents Prenom_User_Text As ud_TextBox
    Friend WithEvents Mouvemente_Check As ud_CheckBox
    Friend WithEvents Actif_Check As ud_CheckBox
    Friend WithEvents Mail_Text As ud_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Param_TreeView As System.Windows.Forms.TreeView
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents ParamLabel As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Lib_Profile_Text As ud_TextBox
    Friend WithEvents id_User_Text As ud_TextBox
    Friend WithEvents Cod_Param As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Libelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valeur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Typ_Param_General As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mnu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Typ_Role As ud_ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Param_GRD As ud_Grd
    Friend WithEvents is_AD_chk As ud_CheckBox
    Friend WithEvents lv_Societes As ListView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
