<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin_Profile
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.Lib_Profile_Text = New RHP.ud_TextBox()
        Me.GNR_FAM_GROUP = New System.Windows.Forms.GroupBox()
        Me.Actif_Check = New RHP.ud_CheckBox()
        Me.Cod_Profile_Target_Text = New RHP.ud_TextBox()
        Me.Lib_Profile_Target_Text = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Cod_Profile_Text = New RHP.ud_TextBox()
        Me.Cod_Profile_Label = New System.Windows.Forms.LinkLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Adv = New DevComponents.AdvTree.AdvTree()
        Me.oMenu = New DevComponents.AdvTree.ColumnHeader()
        Me.oVisible = New DevComponents.AdvTree.ColumnHeader()
        Me.oActif = New DevComponents.AdvTree.ColumnHeader()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Rsl_Recherche = New System.Windows.Forms.Label()
        Me.Search_pb = New System.Windows.Forms.PictureBox()
        Me.Recherche_txt_ud = New RHP.ud_TextBox()
        Me.OuvrirParNiveau_ud = New RHP.ud_ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Tbl_Grd = New RHP.ud_Grd()
        Me.Table_Ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Regle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.AdvFonction = New DevComponents.AdvTree.AdvTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.LeProfil = New DevComponents.AdvTree.Node()
        Me.Cell1 = New DevComponents.AdvTree.Cell()
        Me.Cell2 = New DevComponents.AdvTree.Cell()
        Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle4 = New DevComponents.DotNetBar.ElementStyle()
        Me.MNU = New DevComponents.Editors.ComboItem()
        Me.FDR = New DevComponents.Editors.ComboItem()
        Me.Ecr = New DevComponents.Editors.ComboItem()
        Me.CntScripts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Scripts = New System.Windows.Forms.ToolStripMenuItem()
        Me.GNR_FAM_GROUP.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.Tbl_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.AdvFonction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CntScripts.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lib_Profile_Text
        '
        Me.Lib_Profile_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Profile_Text.ContextMenuStrip = Nothing
        Me.Lib_Profile_Text.Location = New System.Drawing.Point(281, 14)
        Me.Lib_Profile_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Profile_Text.MaxLength = 32767
        Me.Lib_Profile_Text.Multiline = False
        Me.Lib_Profile_Text.Name = "Lib_Profile_Text"
        Me.Lib_Profile_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Profile_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Profile_Text.ReadOnly = False
        Me.Lib_Profile_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Profile_Text.SelectionStart = 0
        Me.Lib_Profile_Text.Size = New System.Drawing.Size(320, 26)
        Me.Lib_Profile_Text.TabIndex = 200
        Me.Lib_Profile_Text.Tag = ""
        Me.Lib_Profile_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Profile_Text.UseSystemPasswordChar = False
        '
        'GNR_FAM_GROUP
        '
        Me.GNR_FAM_GROUP.Controls.Add(Me.Actif_Check)
        Me.GNR_FAM_GROUP.Controls.Add(Me.Cod_Profile_Target_Text)
        Me.GNR_FAM_GROUP.Controls.Add(Me.Lib_Profile_Target_Text)
        Me.GNR_FAM_GROUP.Controls.Add(Me.LinkLabel1)
        Me.GNR_FAM_GROUP.Controls.Add(Me.Cod_Profile_Text)
        Me.GNR_FAM_GROUP.Controls.Add(Me.Lib_Profile_Text)
        Me.GNR_FAM_GROUP.Controls.Add(Me.Cod_Profile_Label)
        Me.GNR_FAM_GROUP.Dock = System.Windows.Forms.DockStyle.Top
        Me.GNR_FAM_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.GNR_FAM_GROUP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GNR_FAM_GROUP.Name = "GNR_FAM_GROUP"
        Me.GNR_FAM_GROUP.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GNR_FAM_GROUP.Size = New System.Drawing.Size(955, 72)
        Me.GNR_FAM_GROUP.TabIndex = 0
        Me.GNR_FAM_GROUP.TabStop = False
        '
        'Actif_Check
        '
        Me.Actif_Check.AutoSize = True
        Me.Actif_Check.Checked = True
        Me.Actif_Check.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Actif_Check.Location = New System.Drawing.Point(612, 16)
        Me.Actif_Check.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Actif_Check.MaximumSize = New System.Drawing.Size(0, 28)
        Me.Actif_Check.MinimumSize = New System.Drawing.Size(100, 28)
        Me.Actif_Check.Name = "Actif_Check"
        Me.Actif_Check.Size = New System.Drawing.Size(100, 28)
        Me.Actif_Check.TabIndex = 204
        Me.Actif_Check.Tag = "NC"
        Me.Actif_Check.Text = "Actif"
        '
        'Cod_Profile_Target_Text
        '
        Me.Cod_Profile_Target_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Profile_Target_Text.ContextMenuStrip = Nothing
        Me.Cod_Profile_Target_Text.Location = New System.Drawing.Point(141, 42)
        Me.Cod_Profile_Target_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Profile_Target_Text.MaxLength = 32767
        Me.Cod_Profile_Target_Text.Multiline = False
        Me.Cod_Profile_Target_Text.Name = "Cod_Profile_Target_Text"
        Me.Cod_Profile_Target_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Profile_Target_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Profile_Target_Text.ReadOnly = True
        Me.Cod_Profile_Target_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Profile_Target_Text.SelectionStart = 0
        Me.Cod_Profile_Target_Text.Size = New System.Drawing.Size(138, 26)
        Me.Cod_Profile_Target_Text.TabIndex = 200
        Me.Cod_Profile_Target_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Profile_Target_Text.UseSystemPasswordChar = False
        '
        'Lib_Profile_Target_Text
        '
        Me.Lib_Profile_Target_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Profile_Target_Text.ContextMenuStrip = Nothing
        Me.Lib_Profile_Target_Text.Location = New System.Drawing.Point(281, 42)
        Me.Lib_Profile_Target_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Profile_Target_Text.MaxLength = 32767
        Me.Lib_Profile_Target_Text.Multiline = False
        Me.Lib_Profile_Target_Text.Name = "Lib_Profile_Target_Text"
        Me.Lib_Profile_Target_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Profile_Target_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Profile_Target_Text.ReadOnly = True
        Me.Lib_Profile_Target_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Profile_Target_Text.SelectionStart = 0
        Me.Lib_Profile_Target_Text.Size = New System.Drawing.Size(320, 26)
        Me.Lib_Profile_Target_Text.TabIndex = 200
        Me.Lib_Profile_Target_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Profile_Target_Text.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(44, 42)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(87, 19)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Profile cible"
        '
        'Cod_Profile_Text
        '
        Me.Cod_Profile_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Profile_Text.ContextMenuStrip = Nothing
        Me.Cod_Profile_Text.Location = New System.Drawing.Point(141, 14)
        Me.Cod_Profile_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
        'Cod_Profile_Label
        '
        Me.Cod_Profile_Label.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Profile_Label.AutoSize = True
        Me.Cod_Profile_Label.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Profile_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Profile_Label.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Profile_Label.Location = New System.Drawing.Point(74, 14)
        Me.Cod_Profile_Label.Name = "Cod_Profile_Label"
        Me.Cod_Profile_Label.Size = New System.Drawing.Size(49, 19)
        Me.Cod_Profile_Label.TabIndex = 0
        Me.Cod_Profile_Label.TabStop = True
        Me.Cod_Profile_Label.Tag = ""
        Me.Cod_Profile_Label.Text = "Profile"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 72)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(955, 614)
        Me.TabControl1.TabIndex = 201
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Adv)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(947, 582)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Droits sur les menus"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Adv
        '
        Me.Adv.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.Adv.AllowDrop = True
        Me.Adv.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.Adv.BackgroundStyle.Class = "TreeBorderKey"
        Me.Adv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Adv.Columns.Add(Me.oMenu)
        Me.Adv.Columns.Add(Me.oVisible)
        Me.Adv.Columns.Add(Me.oActif)
        Me.Adv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Adv.Location = New System.Drawing.Point(3, 46)
        Me.Adv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Adv.Name = "Adv"
        Me.Adv.NodesConnector = Me.NodeConnector1
        Me.Adv.NodeStyle = Me.ElementStyle1
        Me.Adv.PathSeparator = ";"
        Me.Adv.Size = New System.Drawing.Size(941, 532)
        Me.Adv.Styles.Add(Me.ElementStyle1)
        Me.Adv.TabIndex = 0
        Me.Adv.Text = "Adv"
        '
        'oMenu
        '
        Me.oMenu.Name = "oMenu"
        Me.oMenu.Text = "Menu"
        Me.oMenu.Width.Relative = 90
        '
        'oVisible
        '
        Me.oVisible.Name = "oVisible"
        Me.oVisible.Text = "Visible"
        Me.oVisible.Width.Absolute = 45
        '
        'oActif
        '
        Me.oActif.Name = "oActif"
        Me.oActif.Text = "Actif"
        Me.oActif.Width.Absolute = 45
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'ElementStyle1
        '
        Me.ElementStyle1.Class = ""
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Rsl_Recherche)
        Me.Panel1.Controls.Add(Me.Search_pb)
        Me.Panel1.Controls.Add(Me.Recherche_txt_ud)
        Me.Panel1.Controls.Add(Me.OuvrirParNiveau_ud)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(941, 42)
        Me.Panel1.TabIndex = 1
        '
        'Rsl_Recherche
        '
        Me.Rsl_Recherche.AutoSize = True
        Me.Rsl_Recherche.Location = New System.Drawing.Point(519, 11)
        Me.Rsl_Recherche.Name = "Rsl_Recherche"
        Me.Rsl_Recherche.Size = New System.Drawing.Size(0, 19)
        Me.Rsl_Recherche.TabIndex = 6
        '
        'Search_pb
        '
        Me.Search_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Search_pb.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.Search_pb.Location = New System.Drawing.Point(476, 1)
        Me.Search_pb.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Search_pb.Name = "Search_pb"
        Me.Search_pb.Size = New System.Drawing.Size(32, 36)
        Me.Search_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Search_pb.TabIndex = 5
        Me.Search_pb.TabStop = False
        Me.Search_pb.Tag = "false"
        '
        'Recherche_txt_ud
        '
        Me.Recherche_txt_ud.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Recherche_txt_ud.ContextMenuStrip = Nothing
        Me.Recherche_txt_ud.Location = New System.Drawing.Point(254, 9)
        Me.Recherche_txt_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Recherche_txt_ud.MaxLength = 32767
        Me.Recherche_txt_ud.Multiline = False
        Me.Recherche_txt_ud.Name = "Recherche_txt_ud"
        Me.Recherche_txt_ud.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Recherche_txt_ud.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Recherche_txt_ud.ReadOnly = False
        Me.Recherche_txt_ud.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Recherche_txt_ud.SelectionStart = 0
        Me.Recherche_txt_ud.Size = New System.Drawing.Size(216, 28)
        Me.Recherche_txt_ud.TabIndex = 1
        Me.Recherche_txt_ud.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Recherche_txt_ud.UseSystemPasswordChar = False
        '
        'OuvrirParNiveau_ud
        '
        Me.OuvrirParNiveau_ud.DataSource = Nothing
        Me.OuvrirParNiveau_ud.DisplayMember = ""
        Me.OuvrirParNiveau_ud.DroppedDown = False
        Me.OuvrirParNiveau_ud.Location = New System.Drawing.Point(3, 5)
        Me.OuvrirParNiveau_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.OuvrirParNiveau_ud.Name = "OuvrirParNiveau_ud"
        Me.OuvrirParNiveau_ud.SelectedIndex = -1
        Me.OuvrirParNiveau_ud.SelectedItem = Nothing
        Me.OuvrirParNiveau_ud.SelectedValue = Nothing
        Me.OuvrirParNiveau_ud.Size = New System.Drawing.Size(246, 31)
        Me.OuvrirParNiveau_ud.TabIndex = 0
        Me.OuvrirParNiveau_ud.ValueMember = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Tbl_Grd)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Size = New System.Drawing.Size(947, 582)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Règles et limitations"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Tbl_Grd
        '
        Me.Tbl_Grd.AfficherLesEntetesLignes = True
        Me.Tbl_Grd.AllowUserToOrderColumns = True
        Me.Tbl_Grd.AlternerLesLignes = False
        Me.Tbl_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Tbl_Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Tbl_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tbl_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Tbl_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tbl_Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Table_Ref, Me.Regle})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Tbl_Grd.DefaultCellStyle = DataGridViewCellStyle2
        Me.Tbl_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tbl_Grd.EnableHeadersVisualStyles = False
        Me.Tbl_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Tbl_Grd.Location = New System.Drawing.Point(3, 4)
        Me.Tbl_Grd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Tbl_Grd.Name = "Tbl_Grd"
        Me.Tbl_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Tbl_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Tbl_Grd.RowHeadersWidth = 51
        Me.Tbl_Grd.Size = New System.Drawing.Size(941, 574)
        Me.Tbl_Grd.TabIndex = 210
        '
        'Table_Ref
        '
        Me.Table_Ref.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Table_Ref.HeaderText = "Table de Référence"
        Me.Table_Ref.MinimumWidth = 6
        Me.Table_Ref.Name = "Table_Ref"
        Me.Table_Ref.Width = 167
        '
        'Regle
        '
        Me.Regle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Regle.HeaderText = "Règle"
        Me.Regle.MinimumWidth = 200
        Me.Regle.Name = "Regle"
        Me.Regle.Width = 200
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.AdvFonction)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage3.Size = New System.Drawing.Size(947, 582)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Fonctions d'accès"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'AdvFonction
        '
        Me.AdvFonction.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.AdvFonction.AllowDrop = True
        Me.AdvFonction.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.AdvFonction.BackgroundStyle.Class = "TreeBorderKey"
        Me.AdvFonction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AdvFonction.Columns.Add(Me.ColumnHeader1)
        Me.AdvFonction.Columns.Add(Me.ColumnHeader2)
        Me.AdvFonction.Columns.Add(Me.ColumnHeader3)
        Me.AdvFonction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvFonction.Location = New System.Drawing.Point(3, 4)
        Me.AdvFonction.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AdvFonction.Name = "AdvFonction"
        Me.AdvFonction.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.LeProfil})
        Me.AdvFonction.NodesConnector = Me.NodeConnector2
        Me.AdvFonction.NodeStyle = Me.ElementStyle4
        Me.AdvFonction.PathSeparator = ";"
        Me.AdvFonction.Size = New System.Drawing.Size(941, 574)
        Me.AdvFonction.Styles.Add(Me.ElementStyle4)
        Me.AdvFonction.TabIndex = 1
        Me.AdvFonction.Text = "AdvTree1"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Menu"
        Me.ColumnHeader1.Width.Relative = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Visible"
        Me.ColumnHeader2.Width.Absolute = 40
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Actif"
        Me.ColumnHeader3.Width.Absolute = 40
        '
        'LeProfil
        '
        Me.LeProfil.Cells.Add(Me.Cell1)
        Me.LeProfil.Cells.Add(Me.Cell2)
        Me.LeProfil.Expanded = True
        Me.LeProfil.Image = Global.RHP.My.Resources.Resources.script_small
        Me.LeProfil.Name = "LeProfil"
        Me.LeProfil.Text = "LeProfil"
        '
        'Cell1
        '
        Me.Cell1.Name = "Cell1"
        Me.Cell1.StyleMouseOver = Nothing
        '
        'Cell2
        '
        Me.Cell2.Name = "Cell2"
        Me.Cell2.StyleMouseOver = Nothing
        '
        'NodeConnector2
        '
        Me.NodeConnector2.LineColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'ElementStyle4
        '
        Me.ElementStyle4.Class = ""
        Me.ElementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.TextColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'MNU
        '
        Me.MNU.Text = "Que les Menus"
        '
        'FDR
        '
        Me.FDR.Text = "Que les Dossiers"
        '
        'Ecr
        '
        Me.Ecr.Text = "Tout"
        '
        'CntScripts
        '
        Me.CntScripts.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CntScripts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Scripts})
        Me.CntScripts.Name = "CntScripts"
        Me.CntScripts.Size = New System.Drawing.Size(266, 30)
        '
        'Scripts
        '
        Me.Scripts.Image = Global.RHP.My.Resources.Resources.script_small
        Me.Scripts.Name = "Scripts"
        Me.Scripts.Size = New System.Drawing.Size(265, 26)
        Me.Scripts.Text = "Gestion des accès par écran"
        '
        'Admin_Profile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(955, 686)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GNR_FAM_GROUP)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Admin_Profile"
        Me.Tag = "ECR"
        Me.Text = "Gestion des profiles"
        Me.GNR_FAM_GROUP.ResumeLayout(False)
        Me.GNR_FAM_GROUP.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Tbl_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.AdvFonction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CntScripts.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lib_Profile_Text As ud_TextBox
    Friend WithEvents GNR_FAM_GROUP As System.Windows.Forms.GroupBox
    Friend WithEvents Cod_Profile_Label As System.Windows.Forms.LinkLabel
    Friend WithEvents Cod_Profile_Text As ud_TextBox
    Friend WithEvents Lib_Profile_Target_Text As ud_TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Cod_Profile_Target_Text As ud_TextBox
    Friend WithEvents Adv As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents oMenu As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents oVisible As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents oActif As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents MNU As DevComponents.Editors.ComboItem
    Friend WithEvents FDR As DevComponents.Editors.ComboItem
    Friend WithEvents Ecr As DevComponents.Editors.ComboItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Tbl_Grd As ud_Grd
    Friend WithEvents Table_Ref As DataGridViewTextBoxColumn
    Friend WithEvents Regle As DataGridViewTextBoxColumn
    Friend WithEvents Actif_Check As ud_CheckBox
    Friend WithEvents CntScripts As ContextMenuStrip
    Friend WithEvents Scripts As ToolStripMenuItem
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents AdvFonction As DevComponents.AdvTree.AdvTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle4 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents LeProfil As DevComponents.AdvTree.Node
    Friend WithEvents Cell1 As DevComponents.AdvTree.Cell
    Friend WithEvents Cell2 As DevComponents.AdvTree.Cell
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Recherche_txt_ud As ud_TextBox
    Friend WithEvents OuvrirParNiveau_ud As ud_ComboBox
    Friend WithEvents Search_pb As PictureBox
    Friend WithEvents Rsl_Recherche As Label
End Class
