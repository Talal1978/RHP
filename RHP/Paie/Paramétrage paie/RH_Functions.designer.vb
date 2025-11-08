<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Functions
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fonctions Système")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fonctions de calcul de la paie")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rubriques de la paie")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Abaques de paie")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fiche de renseignement de l'Agent")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Eléments de la préparation de la paie")
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabFunction = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Formule_Function_Text = New System.Windows.Forms.RichTextBox()
        Me.Resultat = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Function_Trv = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EvaluerLaValeurDeLaVariableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rechercher_txt = New RHP.ud_TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Sql_Text = New RHP.ud_TextBox()
        Me.Lib_Abr_Text = New RHP.ud_TextBox()
        Me.Lib_Abr_ = New System.Windows.Forms.Label()
        Me.Typ_Retour_ = New System.Windows.Forms.Label()
        Me.Cod_Function_Text = New RHP.ud_TextBox()
        Me.Typ_Param = New RHP.ud_ComboBox()
        Me.Function_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Function_Text = New RHP.ud_TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Fonction_Globale_chk = New RHP.ud_CheckBox()
        Me.estSysteme_chk = New RHP.ud_CheckBox()
        Me.Est_Pourcentage_chk = New RHP.ud_CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Nb_Decimal = New System.Windows.Forms.NumericUpDown()
        Me.Utilise_chk = New RHP.ud_CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabFunction.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Nb_Decimal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabFunction)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 148)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1215, 517)
        Me.TabControl1.TabIndex = 15
        '
        'TabFunction
        '
        Me.TabFunction.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabFunction.Controls.Add(Me.SplitContainer2)
        Me.TabFunction.Location = New System.Drawing.Point(4, 28)
        Me.TabFunction.Margin = New System.Windows.Forms.Padding(4)
        Me.TabFunction.Name = "TabFunction"
        Me.TabFunction.Padding = New System.Windows.Forms.Padding(4)
        Me.TabFunction.Size = New System.Drawing.Size(1207, 485)
        Me.TabFunction.TabIndex = 0
        Me.TabFunction.Text = "Syntaxe de la fonction"
        Me.TabFunction.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(4, 4)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Function_Trv)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Rechercher_txt)
        Me.SplitContainer2.Size = New System.Drawing.Size(1199, 477)
        Me.SplitContainer2.SplitterDistance = 667
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Formule_Function_Text)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Resultat)
        Me.SplitContainer3.Size = New System.Drawing.Size(667, 477)
        Me.SplitContainer3.SplitterDistance = 397
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 0
        '
        'Formule_Function_Text
        '
        Me.Formule_Function_Text.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Formule_Function_Text.Location = New System.Drawing.Point(0, 0)
        Me.Formule_Function_Text.Margin = New System.Windows.Forms.Padding(4)
        Me.Formule_Function_Text.Name = "Formule_Function_Text"
        Me.Formule_Function_Text.Size = New System.Drawing.Size(667, 397)
        Me.Formule_Function_Text.TabIndex = 14
        Me.Formule_Function_Text.Text = ""
        '
        'Resultat
        '
        Me.Resultat.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        '
        '
        '
        Me.Resultat.Border.Class = "TextBoxBorder"
        Me.Resultat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Resultat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Resultat.Location = New System.Drawing.Point(0, 0)
        Me.Resultat.Margin = New System.Windows.Forms.Padding(4)
        Me.Resultat.Multiline = True
        Me.Resultat.Name = "Resultat"
        Me.Resultat.ReadOnly = True
        Me.Resultat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Resultat.Size = New System.Drawing.Size(667, 75)
        Me.Resultat.TabIndex = 11
        '
        'Function_Trv
        '
        Me.Function_Trv.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Function_Trv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Function_Trv.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Function_Trv.Location = New System.Drawing.Point(0, 39)
        Me.Function_Trv.Margin = New System.Windows.Forms.Padding(4)
        Me.Function_Trv.Name = "Function_Trv"
        TreeNode1.Name = "FS"
        TreeNode1.Text = "Fonctions Système"
        TreeNode1.ToolTipText = "Fonctions Système"
        TreeNode2.Name = "FU"
        TreeNode2.Text = "Fonctions de calcul de la paie"
        TreeNode2.ToolTipText = "Fonctions de calcul de la paie"
        TreeNode3.Name = "RB"
        TreeNode3.Text = "Rubriques de la paie"
        TreeNode3.ToolTipText = "Rubriques de la paie"
        TreeNode4.Name = "AB"
        TreeNode4.Text = "Abaques de paie"
        TreeNode5.Name = "AG"
        TreeNode5.Text = "Fiche de renseignement de l'Agent"
        TreeNode5.ToolTipText = "Fiche de renseignement de l'Agent"
        TreeNode6.Name = "EP"
        TreeNode6.Text = "Eléments de la préparation de la paie"
        Me.Function_Trv.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Me.Function_Trv.Size = New System.Drawing.Size(527, 438)
        Me.Function_Trv.TabIndex = 8
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EvaluerLaValeurDeLaVariableToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(285, 30)
        '
        'EvaluerLaValeurDeLaVariableToolStripMenuItem
        '
        Me.EvaluerLaValeurDeLaVariableToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Achats
        Me.EvaluerLaValeurDeLaVariableToolStripMenuItem.Name = "EvaluerLaValeurDeLaVariableToolStripMenuItem"
        Me.EvaluerLaValeurDeLaVariableToolStripMenuItem.Size = New System.Drawing.Size(284, 26)
        Me.EvaluerLaValeurDeLaVariableToolStripMenuItem.Text = "Evaluer la valeur de la variable"
        '
        'Rechercher_txt
        '
        Me.Rechercher_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Rechercher_txt.ContextMenuStrip = Nothing
        Me.Rechercher_txt.Dock = System.Windows.Forms.DockStyle.Top
        Me.Rechercher_txt.Location = New System.Drawing.Point(0, 0)
        Me.Rechercher_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Rechercher_txt.MaxLength = 32767
        Me.Rechercher_txt.Multiline = False
        Me.Rechercher_txt.Name = "Rechercher_txt"
        Me.Rechercher_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Rechercher_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Rechercher_txt.ReadOnly = False
        Me.Rechercher_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Rechercher_txt.SelectionStart = 0
        Me.Rechercher_txt.Size = New System.Drawing.Size(527, 39)
        Me.Rechercher_txt.TabIndex = 10
        Me.Rechercher_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Rechercher_txt.UseSystemPasswordChar = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Sql_Text)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Size = New System.Drawing.Size(1207, 485)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Compilation"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Sql_Text
        '
        Me.Sql_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Sql_Text.ContextMenuStrip = Nothing
        Me.Sql_Text.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sql_Text.Location = New System.Drawing.Point(4, 4)
        Me.Sql_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Sql_Text.MaxLength = 32767
        Me.Sql_Text.Multiline = True
        Me.Sql_Text.Name = "Sql_Text"
        Me.Sql_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Sql_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Sql_Text.ReadOnly = True
        Me.Sql_Text.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Sql_Text.SelectionStart = 0
        Me.Sql_Text.Size = New System.Drawing.Size(1199, 477)
        Me.Sql_Text.TabIndex = 1
        Me.Sql_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Sql_Text.UseSystemPasswordChar = False
        '
        'Lib_Abr_Text
        '
        Me.Lib_Abr_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Abr_Text.ContextMenuStrip = Nothing
        Me.Lib_Abr_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Abr_Text.Location = New System.Drawing.Point(210, 46)
        Me.Lib_Abr_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Abr_Text.MaxLength = 50
        Me.Lib_Abr_Text.Multiline = False
        Me.Lib_Abr_Text.Name = "Lib_Abr_Text"
        Me.Lib_Abr_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Abr_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Abr_Text.ReadOnly = False
        Me.Lib_Abr_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Abr_Text.SelectionStart = 0
        Me.Lib_Abr_Text.Size = New System.Drawing.Size(229, 26)
        Me.Lib_Abr_Text.TabIndex = 219
        Me.Lib_Abr_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Abr_Text.UseSystemPasswordChar = False
        '
        'Lib_Abr_
        '
        Me.Lib_Abr_.AutoSize = True
        Me.Lib_Abr_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Abr_.Location = New System.Drawing.Point(116, 49)
        Me.Lib_Abr_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lib_Abr_.Name = "Lib_Abr_"
        Me.Lib_Abr_.Size = New System.Drawing.Size(88, 19)
        Me.Lib_Abr_.TabIndex = 218
        Me.Lib_Abr_.Text = "Abréviation"
        '
        'Typ_Retour_
        '
        Me.Typ_Retour_.AutoSize = True
        Me.Typ_Retour_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Retour_.Location = New System.Drawing.Point(162, 86)
        Me.Typ_Retour_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Typ_Retour_.Name = "Typ_Retour_"
        Me.Typ_Retour_.Size = New System.Drawing.Size(41, 19)
        Me.Typ_Retour_.TabIndex = 218
        Me.Typ_Retour_.Text = "Type"
        '
        'Cod_Function_Text
        '
        Me.Cod_Function_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Function_Text.ContextMenuStrip = Nothing
        Me.Cod_Function_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Function_Text.Location = New System.Drawing.Point(75, 18)
        Me.Cod_Function_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Function_Text.MaxLength = 50
        Me.Cod_Function_Text.Multiline = False
        Me.Cod_Function_Text.Name = "Cod_Function_Text"
        Me.Cod_Function_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Function_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Function_Text.ReadOnly = True
        Me.Cod_Function_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Function_Text.SelectionStart = 0
        Me.Cod_Function_Text.Size = New System.Drawing.Size(231, 26)
        Me.Cod_Function_Text.TabIndex = 15
        Me.Cod_Function_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Function_Text.UseSystemPasswordChar = False
        '
        'Typ_Param
        '
        Me.Typ_Param.DataSource = Nothing
        Me.Typ_Param.DisplayMember = ""
        Me.Typ_Param.DroppedDown = False
        Me.Typ_Param.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Param.Location = New System.Drawing.Point(210, 82)
        Me.Typ_Param.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Typ_Param.Name = "Typ_Param"
        Me.Typ_Param.SelectedIndex = -1
        Me.Typ_Param.SelectedItem = Nothing
        Me.Typ_Param.SelectedValue = Nothing
        Me.Typ_Param.Size = New System.Drawing.Size(151, 30)
        Me.Typ_Param.TabIndex = 14
        Me.Typ_Param.ValueMember = ""
        '
        'Function_
        '
        Me.Function_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Function_.AutoSize = True
        Me.Function_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Function_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Function_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Function_.Location = New System.Drawing.Point(2, 20)
        Me.Function_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Function_.Name = "Function_"
        Me.Function_.Size = New System.Drawing.Size(69, 19)
        Me.Function_.TabIndex = 13
        Me.Function_.TabStop = True
        Me.Function_.Text = "Fonction"
        '
        'Lib_Function_Text
        '
        Me.Lib_Function_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Function_Text.ContextMenuStrip = Nothing
        Me.Lib_Function_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Function_Text.Location = New System.Drawing.Point(314, 18)
        Me.Lib_Function_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Function_Text.MaxLength = 32767
        Me.Lib_Function_Text.Multiline = True
        Me.Lib_Function_Text.Name = "Lib_Function_Text"
        Me.Lib_Function_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Function_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Function_Text.ReadOnly = False
        Me.Lib_Function_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Function_Text.SelectionStart = 0
        Me.Lib_Function_Text.Size = New System.Drawing.Size(808, 25)
        Me.Lib_Function_Text.TabIndex = 16
        Me.Lib_Function_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Function_Text.UseSystemPasswordChar = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Fonction_Globale_chk)
        Me.GroupBox2.Controls.Add(Me.estSysteme_chk)
        Me.GroupBox2.Controls.Add(Me.Est_Pourcentage_chk)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Nb_Decimal)
        Me.GroupBox2.Controls.Add(Me.Utilise_chk)
        Me.GroupBox2.Controls.Add(Me.Lib_Abr_Text)
        Me.GroupBox2.Controls.Add(Me.Typ_Retour_)
        Me.GroupBox2.Controls.Add(Me.Cod_Function_Text)
        Me.GroupBox2.Controls.Add(Me.Lib_Abr_)
        Me.GroupBox2.Controls.Add(Me.Function_)
        Me.GroupBox2.Controls.Add(Me.Typ_Param)
        Me.GroupBox2.Controls.Add(Me.Lib_Function_Text)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1215, 148)
        Me.GroupBox2.TabIndex = 220
        Me.GroupBox2.TabStop = False
        '
        'Fonction_Globale_chk
        '
        Me.Fonction_Globale_chk.AutoSize = True
        Me.Fonction_Globale_chk.Checked = True
        Me.Fonction_Globale_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Fonction_Globale_chk.Location = New System.Drawing.Point(446, 48)
        Me.Fonction_Globale_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Fonction_Globale_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Fonction_Globale_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Fonction_Globale_chk.Name = "Fonction_Globale_chk"
        Me.Fonction_Globale_chk.Size = New System.Drawing.Size(146, 31)
        Me.Fonction_Globale_chk.TabIndex = 233
        Me.Fonction_Globale_chk.Text = "Fonction globale"
        '
        'estSysteme_chk
        '
        Me.estSysteme_chk.AutoSize = True
        Me.estSysteme_chk.Checked = True
        Me.estSysteme_chk.Enabled = False
        Me.estSysteme_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.estSysteme_chk.Location = New System.Drawing.Point(642, 48)
        Me.estSysteme_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.estSysteme_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.estSysteme_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.estSysteme_chk.Name = "estSysteme_chk"
        Me.estSysteme_chk.Size = New System.Drawing.Size(147, 31)
        Me.estSysteme_chk.TabIndex = 232
        Me.estSysteme_chk.Text = "Fonction système"
        '
        'Est_Pourcentage_chk
        '
        Me.Est_Pourcentage_chk.AutoSize = True
        Me.Est_Pourcentage_chk.Checked = True
        Me.Est_Pourcentage_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Est_Pourcentage_chk.Location = New System.Drawing.Point(604, 80)
        Me.Est_Pourcentage_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Est_Pourcentage_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Est_Pourcentage_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Est_Pourcentage_chk.Name = "Est_Pourcentage_chk"
        Me.Est_Pourcentage_chk.Size = New System.Drawing.Size(192, 31)
        Me.Est_Pourcentage_chk.TabIndex = 230
        Me.Est_Pourcentage_chk.Text = "Fomat pourcentage ""%"""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(395, 86)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 19)
        Me.Label9.TabIndex = 229
        Me.Label9.Text = "Nb décimaux"
        '
        'Nb_Decimal
        '
        Me.Nb_Decimal.Location = New System.Drawing.Point(502, 84)
        Me.Nb_Decimal.Margin = New System.Windows.Forms.Padding(4)
        Me.Nb_Decimal.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.Nb_Decimal.Name = "Nb_Decimal"
        Me.Nb_Decimal.Size = New System.Drawing.Size(94, 22)
        Me.Nb_Decimal.TabIndex = 228
        Me.Nb_Decimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Utilise_chk
        '
        Me.Utilise_chk.AutoSize = True
        Me.Utilise_chk.Checked = True
        Me.Utilise_chk.Enabled = False
        Me.Utilise_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Utilise_chk.Location = New System.Drawing.Point(810, 50)
        Me.Utilise_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Utilise_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Utilise_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Utilise_chk.Name = "Utilise_chk"
        Me.Utilise_chk.Size = New System.Drawing.Size(146, 31)
        Me.Utilise_chk.TabIndex = 223
        Me.Utilise_chk.Text = "Utilisée"
        '
        'RH_Functions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1215, 665)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RH_Functions"
        Me.Tag = "ECR"
        Me.Text = "Fonctions de calcul de la paie"
        Me.TabControl1.ResumeLayout(False)
        Me.TabFunction.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Nb_Decimal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Function_Trv As System.Windows.Forms.TreeView
    Friend WithEvents Lib_Function_Text As ud_TextBox
    Friend WithEvents Cod_Function_Text As ud_TextBox
    Friend WithEvents Typ_Param As ud_ComboBox
    Friend WithEvents Function_ As System.Windows.Forms.LinkLabel
    Friend WithEvents Formule_Function_Text As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Typ_Retour_ As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabFunction As System.Windows.Forms.TabPage
    Friend WithEvents Sql_Text As ud_TextBox
    Friend WithEvents Resultat As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Lib_Abr_Text As ud_TextBox
    Friend WithEvents Lib_Abr_ As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Utilise_chk As ud_CheckBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EvaluerLaValeurDeLaVariableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label9 As Label
    Friend WithEvents Nb_Decimal As NumericUpDown
    Friend WithEvents Est_Pourcentage_chk As ud_CheckBox
    Friend WithEvents estSysteme_chk As ud_CheckBox
    Friend WithEvents Fonction_Globale_chk As ud_CheckBox
    Friend WithEvents Rechercher_txt As ud_TextBox
End Class
