<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Parametrage_Plan_Paie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RH_Parametrage_Plan_Paie))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fonctions système de la paie")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rubriques de la paie")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fiche de renseignement de l'Agent")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fonctions de calcul de la paie")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Eléments de la préparation de la paie")
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Plx = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.rubrique_search_txt = New RHP.ud_TextBox()
        Me.pb_Refresh = New System.Windows.Forms.PictureBox()
        Me.pb_View = New System.Windows.Forms.PictureBox()
        Me.Function_Trv = New System.Windows.Forms.TreeView()
        Me.TrvChecking = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rechercher_txt = New RHP.ud_TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Plan_Grp = New System.Windows.Forms.GroupBox()
        Me.pos_lbl = New System.Windows.Forms.Label()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Cod_Plan_Paie_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Modele_Bulletin_txt = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LastMoisPaie_txt = New RHP.ud_TextBox()
        Me.LastAnneePaie_txt = New RHP.ud_TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.JourPaie = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Grd_Rubriques = New RHP.ud_Grd()
        Me.Rubrique = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Rubrique = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Obligatoire = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Typ_Element = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Rafale_btn = New RHP.ud_button()
        Me.HideIfNoMandatory_chk = New RHP.ud_CheckBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Grd_Controles = New RHP.ud_Grd()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.New_pb = New System.Windows.Forms.PictureBox()
        Me.Del_pb = New System.Windows.Forms.PictureBox()
        Me.Controle_Pnl = New System.Windows.Forms.Panel()
        Me.id_Controle_txt = New RHP.ud_TextBox()
        Me.Bloquant_chk = New RHP.ud_CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Criticite_cbo = New RHP.ud_ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ErreurSi_txt = New RHP.ud_TextBox()
        Me.Msg_Erreur_txt = New RHP.ud_TextBox()
        Me.LinkLabel12 = New System.Windows.Forms.LinkLabel()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Refresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Plan_Grp.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.JourPaie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grd_Rubriques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Personnal_pnl.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.Grd_Controles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Del_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Controle_Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(4, 4)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Plx)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TableLayoutPanel4)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Function_Trv)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.SplitContainer2.Size = New System.Drawing.Size(1313, 564)
        Me.SplitContainer2.SplitterDistance = 781
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'Plx
        '
        Me.Plx.AutoScroll = True
        Me.Plx.BackColor = System.Drawing.Color.White
        Me.Plx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Plx.Location = New System.Drawing.Point(0, 52)
        Me.Plx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Plx.Name = "Plx"
        Me.Plx.Size = New System.Drawing.Size(781, 512)
        Me.Plx.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.PictureBox3, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.rubrique_search_txt, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.pb_Refresh, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.pb_View, 3, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(781, 52)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PictureBox3.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.PictureBox3.Location = New System.Drawing.Point(635, 4)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(42, 44)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SuperTooltip1.SetSuperTooltip(Me.PictureBox3, New DevComponents.DotNetBar.SuperTooltipInfo("RH-P", "", "Rechercher", CType(resources.GetObject("PictureBox3.SuperTooltip"), System.Drawing.Image), Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.PictureBox3.TabIndex = 1002
        Me.PictureBox3.TabStop = False
        '
        'rubrique_search_txt
        '
        Me.rubrique_search_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.rubrique_search_txt.ContextMenuStrip = Nothing
        Me.rubrique_search_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rubrique_search_txt.Location = New System.Drawing.Point(4, 2)
        Me.rubrique_search_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.rubrique_search_txt.MaxLength = 32767
        Me.rubrique_search_txt.Multiline = False
        Me.rubrique_search_txt.Name = "rubrique_search_txt"
        Me.rubrique_search_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.rubrique_search_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.rubrique_search_txt.ReadOnly = False
        Me.rubrique_search_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.rubrique_search_txt.SelectionStart = 0
        Me.rubrique_search_txt.Size = New System.Drawing.Size(623, 48)
        Me.rubrique_search_txt.TabIndex = 1001
        Me.rubrique_search_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.rubrique_search_txt.UseSystemPasswordChar = False
        '
        'pb_Refresh
        '
        Me.pb_Refresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pb_Refresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Refresh.Image = Global.RHP.My.Resources.Resources.btn_request
        Me.pb_Refresh.Location = New System.Drawing.Point(685, 4)
        Me.pb_Refresh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pb_Refresh.Name = "pb_Refresh"
        Me.pb_Refresh.Size = New System.Drawing.Size(42, 44)
        Me.pb_Refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SuperTooltip1.SetSuperTooltip(Me.pb_Refresh, New DevComponents.DotNetBar.SuperTooltipInfo("RH-P", "", "Raffraichir", CType(resources.GetObject("pb_Refresh.SuperTooltip"), System.Drawing.Image), Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.pb_Refresh.TabIndex = 0
        Me.pb_Refresh.TabStop = False
        '
        'pb_View
        '
        Me.pb_View.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pb_View.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_View.Image = Global.RHP.My.Resources.Resources.btn_design
        Me.pb_View.Location = New System.Drawing.Point(735, 4)
        Me.pb_View.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pb_View.Name = "pb_View"
        Me.pb_View.Size = New System.Drawing.Size(42, 44)
        Me.pb_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SuperTooltip1.SetSuperTooltip(Me.pb_View, New DevComponents.DotNetBar.SuperTooltipInfo("RH-P", "", "Aperçu du Plan", CType(resources.GetObject("pb_View.SuperTooltip"), System.Drawing.Image), Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.pb_View.TabIndex = 0
        Me.pb_View.TabStop = False
        '
        'Function_Trv
        '
        Me.Function_Trv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Function_Trv.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Function_Trv.ImageIndex = 0
        Me.Function_Trv.ImageList = Me.TrvChecking
        Me.Function_Trv.ItemHeight = 22
        Me.Function_Trv.Location = New System.Drawing.Point(0, 52)
        Me.Function_Trv.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Function_Trv.Name = "Function_Trv"
        TreeNode1.Name = "FS_Paie"
        TreeNode1.NodeFont = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode1.Text = "Fonctions système de la paie"
        TreeNode2.Name = "Nœud1"
        TreeNode2.NodeFont = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode2.Text = "Rubriques de la paie"
        TreeNode2.ToolTipText = "Rubriques de la paie"
        TreeNode3.Name = "Nœud2"
        TreeNode3.NodeFont = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode3.Text = "Fiche de renseignement de l'Agent"
        TreeNode3.ToolTipText = "Fiche de renseignement de l'Agent"
        TreeNode4.Name = "Nœud0"
        TreeNode4.NodeFont = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode4.Text = "Fonctions de calcul de la paie"
        TreeNode4.ToolTipText = "Fonctions de calcul de la paie"
        TreeNode5.Name = "EP"
        TreeNode5.NodeFont = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode5.Text = "Eléments de la préparation de la paie"
        Me.Function_Trv.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5})
        Me.Function_Trv.SelectedImageIndex = 0
        Me.Function_Trv.Size = New System.Drawing.Size(527, 512)
        Me.Function_Trv.TabIndex = 1000
        '
        'TrvChecking
        '
        Me.TrvChecking.ImageStream = CType(resources.GetObject("TrvChecking.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TrvChecking.TransparentColor = System.Drawing.Color.Transparent
        Me.TrvChecking.Images.SetKeyName(0, "Blank.JPG")
        Me.TrvChecking.Images.SetKeyName(1, "check_0.png")
        Me.TrvChecking.Images.SetKeyName(2, "check_1.png")
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Rechercher_txt, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.PictureBox2, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(527, 52)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Rechercher_txt
        '
        Me.Rechercher_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Rechercher_txt.ContextMenuStrip = Nothing
        Me.Rechercher_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Rechercher_txt.Location = New System.Drawing.Point(4, 2)
        Me.Rechercher_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Rechercher_txt.MaxLength = 32767
        Me.Rechercher_txt.Multiline = False
        Me.Rechercher_txt.Name = "Rechercher_txt"
        Me.Rechercher_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Rechercher_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Rechercher_txt.ReadOnly = False
        Me.Rechercher_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Rechercher_txt.SelectionStart = 0
        Me.Rechercher_txt.Size = New System.Drawing.Size(469, 48)
        Me.Rechercher_txt.TabIndex = 1001
        Me.Rechercher_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Rechercher_txt.UseSystemPasswordChar = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PictureBox2.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.PictureBox2.Location = New System.Drawing.Point(481, 4)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(42, 44)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SuperTooltip1.SetSuperTooltip(Me.PictureBox2, New DevComponents.DotNetBar.SuperTooltipInfo("RH-P", "", "Rechercher", CType(resources.GetObject("PictureBox2.SuperTooltip"), System.Drawing.Image), Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Plan_Grp
        '
        Me.Plan_Grp.Controls.Add(Me.pos_lbl)
        Me.Plan_Grp.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.Plan_Grp.Controls.Add(Me.Cod_Plan_Paie_)
        Me.Plan_Grp.Controls.Add(Me.Lib_Plan_Paie_Text)
        Me.Plan_Grp.Dock = System.Windows.Forms.DockStyle.Top
        Me.Plan_Grp.Location = New System.Drawing.Point(0, 0)
        Me.Plan_Grp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Plan_Grp.Name = "Plan_Grp"
        Me.Plan_Grp.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Plan_Grp.Size = New System.Drawing.Size(1329, 51)
        Me.Plan_Grp.TabIndex = 0
        Me.Plan_Grp.TabStop = False
        '
        'pos_lbl
        '
        Me.pos_lbl.AutoSize = True
        Me.pos_lbl.Location = New System.Drawing.Point(38, 55)
        Me.pos_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.pos_lbl.Name = "pos_lbl"
        Me.pos_lbl.Size = New System.Drawing.Size(37, 19)
        Me.pos_lbl.TabIndex = 22
        Me.pos_lbl.Text = "0 : 0"
        Me.pos_lbl.Visible = False
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(49, 15)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Plan_Paie_Text.MaxLength = 10
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = False
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(128, 26)
        Me.Cod_Plan_Paie_Text.TabIndex = 0
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Cod_Plan_Paie_
        '
        Me.Cod_Plan_Paie_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.AutoSize = True
        Me.Cod_Plan_Paie_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.Location = New System.Drawing.Point(10, 19)
        Me.Cod_Plan_Paie_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Cod_Plan_Paie_.Name = "Cod_Plan_Paie_"
        Me.Cod_Plan_Paie_.Size = New System.Drawing.Size(39, 19)
        Me.Cod_Plan_Paie_.TabIndex = 17
        Me.Cod_Plan_Paie_.TabStop = True
        Me.Cod_Plan_Paie_.Text = "Plan"
        Me.Cod_Plan_Paie_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Lib_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(179, 15)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Plan_Paie_Text.MaxLength = 32767
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = False
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(481, 26)
        Me.Lib_Plan_Paie_Text.TabIndex = 1
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Modele_Bulletin_txt)
        Me.GroupBox4.Controls.Add(Me.LinkLabel4)
        Me.GroupBox4.Controls.Add(Me.LastMoisPaie_txt)
        Me.GroupBox4.Controls.Add(Me.LastAnneePaie_txt)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.JourPaie)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(1313, 99)
        Me.GroupBox4.TabIndex = 108
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Date Calcul de paie"
        '
        'Modele_Bulletin_txt
        '
        Me.Modele_Bulletin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Modele_Bulletin_txt.ContextMenuStrip = Nothing
        Me.Modele_Bulletin_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Modele_Bulletin_txt.Location = New System.Drawing.Point(134, 58)
        Me.Modele_Bulletin_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Modele_Bulletin_txt.MaxLength = 32767
        Me.Modele_Bulletin_txt.Multiline = False
        Me.Modele_Bulletin_txt.Name = "Modele_Bulletin_txt"
        Me.Modele_Bulletin_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Modele_Bulletin_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Modele_Bulletin_txt.ReadOnly = True
        Me.Modele_Bulletin_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Modele_Bulletin_txt.SelectionStart = 0
        Me.Modele_Bulletin_txt.Size = New System.Drawing.Size(295, 26)
        Me.Modele_Bulletin_txt.TabIndex = 98
        Me.Modele_Bulletin_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Modele_Bulletin_txt.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(15, 61)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(117, 19)
        Me.LinkLabel4.TabIndex = 97
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = ""
        Me.LinkLabel4.Text = "Modèle bulletin"
        '
        'LastMoisPaie_txt
        '
        Me.LastMoisPaie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.LastMoisPaie_txt.ContextMenuStrip = Nothing
        Me.LastMoisPaie_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastMoisPaie_txt.Location = New System.Drawing.Point(385, 24)
        Me.LastMoisPaie_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LastMoisPaie_txt.MaxLength = 10
        Me.LastMoisPaie_txt.Multiline = False
        Me.LastMoisPaie_txt.Name = "LastMoisPaie_txt"
        Me.LastMoisPaie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LastMoisPaie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.LastMoisPaie_txt.ReadOnly = True
        Me.LastMoisPaie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.LastMoisPaie_txt.SelectionStart = 0
        Me.LastMoisPaie_txt.Size = New System.Drawing.Size(44, 26)
        Me.LastMoisPaie_txt.TabIndex = 26
        Me.LastMoisPaie_txt.Tag = "4"
        Me.LastMoisPaie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.LastMoisPaie_txt.UseSystemPasswordChar = False
        '
        'LastAnneePaie_txt
        '
        Me.LastAnneePaie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.LastAnneePaie_txt.ContextMenuStrip = Nothing
        Me.LastAnneePaie_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastAnneePaie_txt.Location = New System.Drawing.Point(299, 24)
        Me.LastAnneePaie_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LastAnneePaie_txt.MaxLength = 10
        Me.LastAnneePaie_txt.Multiline = False
        Me.LastAnneePaie_txt.Name = "LastAnneePaie_txt"
        Me.LastAnneePaie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LastAnneePaie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.LastAnneePaie_txt.ReadOnly = True
        Me.LastAnneePaie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.LastAnneePaie_txt.SelectionStart = 0
        Me.LastAnneePaie_txt.Size = New System.Drawing.Size(82, 26)
        Me.LastAnneePaie_txt.TabIndex = 25
        Me.LastAnneePaie_txt.Tag = "4"
        Me.LastAnneePaie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.LastAnneePaie_txt.UseSystemPasswordChar = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(200, 29)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(102, 19)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "Dernière paie"
        '
        'JourPaie
        '
        Me.JourPaie.Location = New System.Drawing.Point(134, 25)
        Me.JourPaie.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.JourPaie.Maximum = New Decimal(New Integer() {28, 0, 0, 0})
        Me.JourPaie.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.JourPaie.Name = "JourPaie"
        Me.JourPaie.Size = New System.Drawing.Size(64, 24)
        Me.JourPaie.TabIndex = 23
        Me.JourPaie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.JourPaie.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(40, 30)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 19)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "1er jour paie"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 51)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1329, 604)
        Me.TabControl1.TabIndex = 109
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.SplitContainer2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1321, 572)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configurateur"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1321, 572)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Paramétrage"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Grd_Rubriques)
        Me.GroupBox2.Controls.Add(Me.Personnal_pnl)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(4, 103)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1313, 465)
        Me.GroupBox2.TabIndex = 112
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Paramétrage des rubriques"
        '
        'Grd_Rubriques
        '
        Me.Grd_Rubriques.AfficherLesEntetesLignes = True
        Me.Grd_Rubriques.AllowUserToAddRows = False
        Me.Grd_Rubriques.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd_Rubriques.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Rubriques.AlternerLesLignes = False
        Me.Grd_Rubriques.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Rubriques.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Rubriques.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Rubriques.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Rubriques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Rubriques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rubrique, Me.Lib_Rubrique, Me.Valeur, Me.Obligatoire, Me.Typ_Element, Me.Edit})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Rubriques.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Rubriques.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Rubriques.EnableHeadersVisualStyles = False
        Me.Grd_Rubriques.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Rubriques.Location = New System.Drawing.Point(4, 81)
        Me.Grd_Rubriques.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grd_Rubriques.Name = "Grd_Rubriques"
        Me.Grd_Rubriques.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Rubriques.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Rubriques.RowHeadersWidth = 51
        Me.Grd_Rubriques.Size = New System.Drawing.Size(1305, 380)
        Me.Grd_Rubriques.TabIndex = 0
        '
        'Rubrique
        '
        Me.Rubrique.HeaderText = "Rubrique"
        Me.Rubrique.MinimumWidth = 6
        Me.Rubrique.Name = "Rubrique"
        Me.Rubrique.Visible = False
        Me.Rubrique.Width = 125
        '
        'Lib_Rubrique
        '
        Me.Lib_Rubrique.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Lib_Rubrique.HeaderText = "Rubrique"
        Me.Lib_Rubrique.MinimumWidth = 300
        Me.Lib_Rubrique.Name = "Lib_Rubrique"
        Me.Lib_Rubrique.ReadOnly = True
        Me.Lib_Rubrique.Width = 300
        '
        'Valeur
        '
        Me.Valeur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.MinimumWidth = 200
        Me.Valeur.Name = "Valeur"
        Me.Valeur.ReadOnly = True
        Me.Valeur.Width = 200
        '
        'Obligatoire
        '
        Me.Obligatoire.HeaderText = "Obligatoire"
        Me.Obligatoire.MinimumWidth = 6
        Me.Obligatoire.Name = "Obligatoire"
        Me.Obligatoire.Visible = False
        Me.Obligatoire.Width = 125
        '
        'Typ_Element
        '
        Me.Typ_Element.HeaderText = "Typ_Element"
        Me.Typ_Element.MinimumWidth = 6
        Me.Typ_Element.Name = "Typ_Element"
        Me.Typ_Element.ReadOnly = True
        Me.Typ_Element.Visible = False
        Me.Typ_Element.Width = 125
        '
        'Edit
        '
        Me.Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.Edit.HeaderText = ""
        Me.Edit.Image = CType(resources.GetObject("Edit.Image"), System.Drawing.Image)
        Me.Edit.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.Edit.MinimumWidth = 25
        Me.Edit.Name = "Edit"
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Edit.Text = Nothing
        Me.Edit.Width = 25
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Controls.Add(Me.Rafale_btn, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.HideIfNoMandatory_chk, 1, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(4, 21)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(1305, 60)
        Me.Personnal_pnl.TabIndex = 4
        '
        'Rafale_btn
        '
        Me.Rafale_btn.AutoSize = True
        Me.Rafale_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Rafale_btn.bgColor = System.Drawing.Color.White
        Me.Rafale_btn.Border = RHP.ud_button.BorderStyle.All
        Me.Rafale_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Rafale_btn.BorderSize = 2
        Me.Rafale_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Rafale_btn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Rafale_btn.Image = Global.RHP.My.Resources.Resources.btn_execute
        Me.Rafale_btn.isDefault = False
        Me.Rafale_btn.Location = New System.Drawing.Point(11, 11)
        Me.Rafale_btn.Margin = New System.Windows.Forms.Padding(11, 11, 11, 11)
        Me.Rafale_btn.MinimumSize = New System.Drawing.Size(29, 31)
        Me.Rafale_btn.Name = "Rafale_btn"
        Me.Rafale_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.Rafale_btn.Size = New System.Drawing.Size(166, 38)
        Me.Rafale_btn.TabIndex = 0
        Me.Rafale_btn.Text = "Auto-générer"
        Me.Rafale_btn.ToolTip = "Génération en rafale des rubriques"
        '
        'HideIfNoMandatory_chk
        '
        Me.HideIfNoMandatory_chk.AutoSize = True
        Me.HideIfNoMandatory_chk.Checked = True
        Me.HideIfNoMandatory_chk.Location = New System.Drawing.Point(200, 12)
        Me.HideIfNoMandatory_chk.Margin = New System.Windows.Forms.Padding(12, 12, 12, 12)
        Me.HideIfNoMandatory_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.HideIfNoMandatory_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.HideIfNoMandatory_chk.Name = "HideIfNoMandatory_chk"
        Me.HideIfNoMandatory_chk.Size = New System.Drawing.Size(210, 31)
        Me.HideIfNoMandatory_chk.TabIndex = 1
        Me.HideIfNoMandatory_chk.Text = "Masquer si non obligatoire"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Grd_Controles)
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage3.Controls.Add(Me.Controle_Pnl)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage3.Size = New System.Drawing.Size(1321, 572)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Règles de contrôle de la paie"
        '
        'Grd_Controles
        '
        Me.Grd_Controles.AfficherLesEntetesLignes = True
        Me.Grd_Controles.AllowUserToAddRows = False
        Me.Grd_Controles.AllowUserToDeleteRows = False
        Me.Grd_Controles.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd_Controles.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Grd_Controles.AlternerLesLignes = False
        Me.Grd_Controles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Grd_Controles.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Controles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Controles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Controles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grd_Controles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Controles.DefaultCellStyle = DataGridViewCellStyle7
        Me.Grd_Controles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Controles.EnableHeadersVisualStyles = False
        Me.Grd_Controles.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Controles.Location = New System.Drawing.Point(4, 204)
        Me.Grd_Controles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grd_Controles.MultiSelect = False
        Me.Grd_Controles.Name = "Grd_Controles"
        Me.Grd_Controles.ReadOnly = True
        Me.Grd_Controles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Controles.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Grd_Controles.RowHeadersWidth = 51
        Me.Grd_Controles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grd_Controles.Size = New System.Drawing.Size(1313, 364)
        Me.Grd_Controles.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Save_pb, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.New_pb, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Del_pb, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 162)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1313, 42)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(48, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(36, 34)
        Me.SuperTooltip1.SetSuperTooltip(Me.Save_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Règles de contrôle de la paie", "", "Enregistrer", Global.RHP.My.Resources.Resources.btn_save, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.Save_pb.TabIndex = 1
        Me.Save_pb.TabStop = False
        '
        'New_pb
        '
        Me.New_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.New_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.New_pb.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.New_pb.Location = New System.Drawing.Point(4, 4)
        Me.New_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.New_pb.Name = "New_pb"
        Me.New_pb.Size = New System.Drawing.Size(36, 34)
        Me.SuperTooltip1.SetSuperTooltip(Me.New_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Règles de contrôle de la paie", "", "Nouveau", Global.RHP.My.Resources.Resources.btn_add, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.New_pb.TabIndex = 0
        Me.New_pb.TabStop = False
        '
        'Del_pb
        '
        Me.Del_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Del_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Del_pb.Image = Global.RHP.My.Resources.Resources.btn_delete
        Me.Del_pb.Location = New System.Drawing.Point(92, 4)
        Me.Del_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Del_pb.Name = "Del_pb"
        Me.Del_pb.Size = New System.Drawing.Size(36, 34)
        Me.SuperTooltip1.SetSuperTooltip(Me.Del_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Règles de contrôle de la paie", "", "Supprimer", Global.RHP.My.Resources.Resources.btn_delete, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.Del_pb.TabIndex = 1
        Me.Del_pb.TabStop = False
        '
        'Controle_Pnl
        '
        Me.Controle_Pnl.Controls.Add(Me.id_Controle_txt)
        Me.Controle_Pnl.Controls.Add(Me.Bloquant_chk)
        Me.Controle_Pnl.Controls.Add(Me.Label3)
        Me.Controle_Pnl.Controls.Add(Me.Criticite_cbo)
        Me.Controle_Pnl.Controls.Add(Me.Label2)
        Me.Controle_Pnl.Controls.Add(Me.ErreurSi_txt)
        Me.Controle_Pnl.Controls.Add(Me.Msg_Erreur_txt)
        Me.Controle_Pnl.Controls.Add(Me.LinkLabel12)
        Me.Controle_Pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Controle_Pnl.Location = New System.Drawing.Point(4, 4)
        Me.Controle_Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Controle_Pnl.Name = "Controle_Pnl"
        Me.Controle_Pnl.Size = New System.Drawing.Size(1313, 158)
        Me.Controle_Pnl.TabIndex = 2
        '
        'id_Controle_txt
        '
        Me.id_Controle_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.id_Controle_txt.ContextMenuStrip = Nothing
        Me.id_Controle_txt.Location = New System.Drawing.Point(20, 8)
        Me.id_Controle_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.id_Controle_txt.MaxLength = 32767
        Me.id_Controle_txt.Multiline = False
        Me.id_Controle_txt.Name = "id_Controle_txt"
        Me.id_Controle_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.id_Controle_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.id_Controle_txt.ReadOnly = False
        Me.id_Controle_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.id_Controle_txt.SelectionStart = 0
        Me.id_Controle_txt.Size = New System.Drawing.Size(58, 26)
        Me.id_Controle_txt.TabIndex = 24
        Me.id_Controle_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.id_Controle_txt.UseSystemPasswordChar = False
        Me.id_Controle_txt.Visible = False
        '
        'Bloquant_chk
        '
        Me.Bloquant_chk.AutoSize = True
        Me.Bloquant_chk.Checked = True
        Me.Bloquant_chk.Location = New System.Drawing.Point(191, 32)
        Me.Bloquant_chk.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Bloquant_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Bloquant_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Bloquant_chk.Name = "Bloquant_chk"
        Me.Bloquant_chk.Size = New System.Drawing.Size(125, 25)
        Me.Bloquant_chk.TabIndex = 23
        Me.Bloquant_chk.Text = "Bloquant"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(324, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 19)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Criticité"
        '
        'Criticite_cbo
        '
        Me.Criticite_cbo.DataSource = Nothing
        Me.Criticite_cbo.DisplayMember = ""
        Me.Criticite_cbo.DroppedDown = False
        Me.Criticite_cbo.Location = New System.Drawing.Point(385, 31)
        Me.Criticite_cbo.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Criticite_cbo.Name = "Criticite_cbo"
        Me.Criticite_cbo.SelectedIndex = -1
        Me.Criticite_cbo.SelectedItem = Nothing
        Me.Criticite_cbo.SelectedValue = Nothing
        Me.Criticite_cbo.Size = New System.Drawing.Size(188, 30)
        Me.Criticite_cbo.TabIndex = 21
        Me.Criticite_cbo.ValueMember = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(584, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 19)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Message d'erreur :"
        '
        'ErreurSi_txt
        '
        Me.ErreurSi_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.ErreurSi_txt.ContextMenuStrip = Nothing
        Me.ErreurSi_txt.Location = New System.Drawing.Point(21, 65)
        Me.ErreurSi_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ErreurSi_txt.MaxLength = 32767
        Me.ErreurSi_txt.Multiline = True
        Me.ErreurSi_txt.Name = "ErreurSi_txt"
        Me.ErreurSi_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.ErreurSi_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ErreurSi_txt.ReadOnly = True
        Me.ErreurSi_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.ErreurSi_txt.SelectionStart = 0
        Me.ErreurSi_txt.Size = New System.Drawing.Size(551, 80)
        Me.ErreurSi_txt.TabIndex = 2
        Me.ErreurSi_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ErreurSi_txt.UseSystemPasswordChar = False
        '
        'Msg_Erreur_txt
        '
        Me.Msg_Erreur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Msg_Erreur_txt.ContextMenuStrip = Nothing
        Me.Msg_Erreur_txt.Location = New System.Drawing.Point(580, 31)
        Me.Msg_Erreur_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Msg_Erreur_txt.MaxLength = 32767
        Me.Msg_Erreur_txt.Multiline = True
        Me.Msg_Erreur_txt.Name = "Msg_Erreur_txt"
        Me.Msg_Erreur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Msg_Erreur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Msg_Erreur_txt.ReadOnly = False
        Me.Msg_Erreur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Msg_Erreur_txt.SelectionStart = 0
        Me.Msg_Erreur_txt.Size = New System.Drawing.Size(551, 114)
        Me.Msg_Erreur_txt.TabIndex = 19
        Me.Msg_Erreur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Msg_Erreur_txt.UseSystemPasswordChar = False
        '
        'LinkLabel12
        '
        Me.LinkLabel12.AutoSize = True
        Me.LinkLabel12.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel12.Location = New System.Drawing.Point(18, 44)
        Me.LinkLabel12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel12.Name = "LinkLabel12"
        Me.LinkLabel12.Size = New System.Drawing.Size(147, 19)
        Me.LinkLabel12.TabIndex = 18
        Me.LinkLabel12.TabStop = True
        Me.LinkLabel12.Text = "Formule de contrôle"
        '
        'RH_Parametrage_Plan_Paie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1329, 655)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Plan_Grp)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "RH_Parametrage_Plan_Paie"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage des plans de paie"
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Refresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Plan_Grp.ResumeLayout(False)
        Me.Plan_Grp.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.JourPaie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Grd_Rubriques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Personnal_pnl.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Grd_Controles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Del_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Controle_Pnl.ResumeLayout(False)
        Me.Controle_Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Plan_Grp As System.Windows.Forms.GroupBox
    Friend WithEvents Function_Trv As System.Windows.Forms.TreeView
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Cod_Plan_Paie_ As System.Windows.Forms.LinkLabel
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents pos_lbl As Label
    Friend WithEvents Plx As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label24 As Label
    Friend WithEvents JourPaie As NumericUpDown
    Friend WithEvents Label22 As Label
    Friend WithEvents LastAnneePaie_txt As ud_TextBox
    Friend WithEvents LastMoisPaie_txt As ud_TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Grd_Controles As ud_Grd
    Friend WithEvents ErreurSi_txt As ud_TextBox
    Friend WithEvents Bloquant_chk As ud_CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Criticite_cbo As ud_ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Msg_Erreur_txt As ud_TextBox
    Friend WithEvents LinkLabel12 As LinkLabel
    Friend WithEvents Controle_Pnl As Panel
    Friend WithEvents id_Controle_txt As ud_TextBox
    Friend WithEvents Grd_Rubriques As ud_Grd
    Friend WithEvents Modele_Bulletin_txt As ud_TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Rubrique As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Rubrique As DataGridViewTextBoxColumn
    Friend WithEvents Valeur As DataGridViewTextBoxColumn
    Friend WithEvents Obligatoire As DataGridViewCheckBoxColumn
    Friend WithEvents Typ_Element As DataGridViewTextBoxColumn
    Friend WithEvents Edit As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents Rechercher_txt As ud_TextBox
    Friend WithEvents TrvChecking As ImageList
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Rafale_btn As ud_button
    Friend WithEvents HideIfNoMandatory_chk As ud_CheckBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents New_pb As PictureBox
    Friend WithEvents Del_pb As PictureBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents rubrique_search_txt As ud_TextBox
    Friend WithEvents pb_Refresh As PictureBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents pb_View As PictureBox
End Class