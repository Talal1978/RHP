<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formation_Action
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
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Lib_Action_Mere_txt = New RHP.ud_TextBox()
        Me.Action_Mere_txt = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Action_txt = New RHP.ud_TextBox()
        Me.Cod_Action_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.SuperTabControlPanel1 = New System.Windows.Forms.TabPage()
        Me.Adv = New DevComponents.AdvTree.AdvTree()
        Me.Formation = New DevComponents.AdvTree.ColumnHeader()
        Me.Dat_Du = New DevComponents.AdvTree.ColumnHeader()
        Me.Dat_Au = New DevComponents.AdvTree.ColumnHeader()
        Me.Nature_Formation = New DevComponents.AdvTree.ColumnHeader()
        Me.Cabinet = New DevComponents.AdvTree.ColumnHeader()
        Me.Budget = New DevComponents.AdvTree.ColumnHeader()
        Me.Statut = New DevComponents.AdvTree.ColumnHeader()
        Me.Genre_Formation = New DevComponents.AdvTree.ColumnHeader()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.SuperTabControlPanel3 = New System.Windows.Forms.TabPage()
        Me.Contenu_rtb = New RHP.ud_RT()
        Me.CntM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenommerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjouterUneActionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjouterUneFormationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupprimerLactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.CntM.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "                             "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Lib_Action_Mere_txt)
        Me.GroupBox2.Controls.Add(Me.Action_Mere_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel2)
        Me.GroupBox2.Controls.Add(Me.Lib_Action_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Action_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(885, 69)
        Me.GroupBox2.TabIndex = 218
        Me.GroupBox2.TabStop = False
        '
        'Lib_Action_Mere_txt
        '
        Me.Lib_Action_Mere_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Action_Mere_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Lib_Action_Mere_txt.Location = New System.Drawing.Point(272, 36)
        Me.Lib_Action_Mere_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Action_Mere_txt.MaxLength = 20
        Me.Lib_Action_Mere_txt.Multiline = False
        Me.Lib_Action_Mere_txt.Name = "Lib_Action_Mere_txt"
        Me.Lib_Action_Mere_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Action_Mere_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Action_Mere_txt.ReadOnly = True
        Me.Lib_Action_Mere_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Action_Mere_txt.SelectionStart = 0
        Me.Lib_Action_Mere_txt.Size = New System.Drawing.Size(466, 21)
        Me.Lib_Action_Mere_txt.TabIndex = 207
        Me.Lib_Action_Mere_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Action_Mere_txt.UseSystemPasswordChar = False
        '
        'Action_Mere_txt
        '
        Me.Action_Mere_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Action_Mere_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Action_Mere_txt.Location = New System.Drawing.Point(125, 36)
        Me.Action_Mere_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Action_Mere_txt.MaxLength = 20
        Me.Action_Mere_txt.Multiline = False
        Me.Action_Mere_txt.Name = "Action_Mere_txt"
        Me.Action_Mere_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Action_Mere_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Action_Mere_txt.ReadOnly = True
        Me.Action_Mere_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Action_Mere_txt.SelectionStart = 0
        Me.Action_Mere_txt.Size = New System.Drawing.Size(141, 21)
        Me.Action_Mere_txt.TabIndex = 205
        Me.Action_Mere_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Action_Mere_txt.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(46, 39)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(75, 16)
        Me.LinkLabel2.TabIndex = 206
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Action mère "
        '
        'Lib_Action_txt
        '
        Me.Lib_Action_txt.BackColor = System.Drawing.Color.White
        Me.Lib_Action_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Action_txt.Location = New System.Drawing.Point(272, 13)
        Me.Lib_Action_txt.MaxLength = 50
        Me.Lib_Action_txt.Multiline = False
        Me.Lib_Action_txt.Name = "Lib_Action_txt"
        Me.Lib_Action_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Action_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Action_txt.ReadOnly = False
        Me.Lib_Action_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Action_txt.SelectionStart = 0
        Me.Lib_Action_txt.Size = New System.Drawing.Size(466, 21)
        Me.Lib_Action_txt.TabIndex = 204
        Me.Lib_Action_txt.Tag = ""
        Me.Lib_Action_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Action_txt.UseSystemPasswordChar = False
        '
        'Cod_Action_txt
        '
        Me.Cod_Action_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Cod_Action_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Action_txt.Location = New System.Drawing.Point(125, 13)
        Me.Cod_Action_txt.MaxLength = 50
        Me.Cod_Action_txt.Multiline = False
        Me.Cod_Action_txt.Name = "Cod_Action_txt"
        Me.Cod_Action_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Action_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Action_txt.ReadOnly = True
        Me.Cod_Action_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Action_txt.SelectionStart = 0
        Me.Cod_Action_txt.Size = New System.Drawing.Size(141, 21)
        Me.Cod_Action_txt.TabIndex = 203
        Me.Cod_Action_txt.Tag = ""
        Me.Cod_Action_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Action_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 16)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(114, 16)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Action de formation"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.TabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 69)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(885, 381)
        Me.TabControl1.TabIndex = 1
        Me.TabControl1.Text = "Participants"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Adv)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(4, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(877, 352)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.Text = "Participants"
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
        Me.Adv.Columns.Add(Me.Formation)
        Me.Adv.Columns.Add(Me.Dat_Du)
        Me.Adv.Columns.Add(Me.Dat_Au)
        Me.Adv.Columns.Add(Me.Nature_Formation)
        Me.Adv.Columns.Add(Me.Cabinet)
        Me.Adv.Columns.Add(Me.Budget)
        Me.Adv.Columns.Add(Me.Statut)
        Me.Adv.Columns.Add(Me.Genre_Formation)
        Me.Adv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Adv.Location = New System.Drawing.Point(0, 0)
        Me.Adv.Name = "Adv"
        Me.Adv.NodesConnector = Me.NodeConnector1
        Me.Adv.NodeStyle = Me.ElementStyle1
        Me.Adv.PathSeparator = ";"
        Me.Adv.Size = New System.Drawing.Size(877, 352)
        Me.Adv.Styles.Add(Me.ElementStyle1)
        Me.Adv.TabIndex = 206
        Me.Adv.Text = "AdvTree1"
        '
        'Formation
        '
        Me.Formation.Name = "Formation"
        Me.Formation.Text = "Formation"
        Me.Formation.Width.Absolute = 400
        '
        'Dat_Du
        '
        Me.Dat_Du.Editable = False
        Me.Dat_Du.Name = "Dat_Du"
        Me.Dat_Du.Text = "Du"
        Me.Dat_Du.Width.Absolute = 60
        '
        'Dat_Au
        '
        Me.Dat_Au.Editable = False
        Me.Dat_Au.Name = "Dat_Au"
        Me.Dat_Au.Text = "Au"
        Me.Dat_Au.Width.Absolute = 60
        '
        'Nature_Formation
        '
        Me.Nature_Formation.Editable = False
        Me.Nature_Formation.Name = "Nature_Formation"
        Me.Nature_Formation.Text = "Type"
        Me.Nature_Formation.Width.Absolute = 50
        '
        'Cabinet
        '
        Me.Cabinet.Editable = False
        Me.Cabinet.Name = "Cabinet"
        Me.Cabinet.Text = "Cabinet"
        Me.Cabinet.Width.Absolute = 120
        '
        'Budget
        '
        Me.Budget.Editable = False
        Me.Budget.Name = "Budget"
        Me.Budget.Text = "Budget"
        Me.Budget.Width.Absolute = 80
        '
        'Statut
        '
        Me.Statut.Editable = False
        Me.Statut.Name = "Statut"
        Me.Statut.Text = "Statut"
        Me.Statut.Width.Absolute = 50
        '
        'Genre_Formation
        '
        Me.Genre_Formation.Editable = False
        Me.Genre_Formation.Name = "Genre_Formation"
        Me.Genre_Formation.Text = "Genre"
        Me.Genre_Formation.Width.Absolute = 120
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
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.Contenu_rtb)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(4, 25)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(877, 323)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.Text = "Contenu"
        '
        'Contenu_rtb
        '
        Me.Contenu_rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Contenu_rtb.Location = New System.Drawing.Point(0, 0)
        Me.Contenu_rtb.Margin = New System.Windows.Forms.Padding(164, 588, 164, 588)
        Me.Contenu_rtb.Name = "Contenu_rtb"
        Me.Contenu_rtb.Size = New System.Drawing.Size(877, 323)
        Me.Contenu_rtb.TabIndex = 2
        '
        'CntM
        '
        Me.CntM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenommerToolStripMenuItem, Me.AjouterUneActionToolStripMenuItem, Me.AjouterUneFormationToolStripMenuItem, Me.SupprimerLactionToolStripMenuItem})
        Me.CntM.Name = "CntM"
        Me.CntM.Size = New System.Drawing.Size(193, 92)
        '
        'RenommerToolStripMenuItem
        '
        Me.RenommerToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.edit_6_xxl
        Me.RenommerToolStripMenuItem.Name = "RenommerToolStripMenuItem"
        Me.RenommerToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.RenommerToolStripMenuItem.Text = "Renommer"
        '
        'AjouterUneActionToolStripMenuItem
        '
        Me.AjouterUneActionToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.insert
        Me.AjouterUneActionToolStripMenuItem.Name = "AjouterUneActionToolStripMenuItem"
        Me.AjouterUneActionToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.AjouterUneActionToolStripMenuItem.Text = "Ajouter une action"
        '
        'AjouterUneFormationToolStripMenuItem
        '
        Me.AjouterUneFormationToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Modifier
        Me.AjouterUneFormationToolStripMenuItem.Name = "AjouterUneFormationToolStripMenuItem"
        Me.AjouterUneFormationToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.AjouterUneFormationToolStripMenuItem.Text = "Ajouter une formation"
        '
        'SupprimerLactionToolStripMenuItem
        '
        Me.SupprimerLactionToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.supprimerligne
        Me.SupprimerLactionToolStripMenuItem.Name = "SupprimerLactionToolStripMenuItem"
        Me.SupprimerLactionToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SupprimerLactionToolStripMenuItem.Text = "Supprimer l'action "
        '
        'Formation_Action
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(885, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Formation_Action"
        Me.Tag = "ECR"
        Me.Text = "Actions de formation"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.CntM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Lib_Action_txt As ud_TextBox
    Friend WithEvents Cod_Action_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SuperTabControlPanel1 As TabPage
    Friend WithEvents SuperTabControlPanel3 As TabPage
    Friend WithEvents Contenu_rtb As ud_RT
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Lib_Action_Mere_txt As ud_TextBox
    Friend WithEvents Action_Mere_txt As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Adv As DevComponents.AdvTree.AdvTree
    Friend WithEvents Formation As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Dat_Du As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Dat_Au As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Genre_Formation As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Nature_Formation As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Cabinet As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Statut As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Budget As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents CntM As ContextMenuStrip
    Friend WithEvents RenommerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjouterUneActionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjouterUneFormationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupprimerLactionToolStripMenuItem As ToolStripMenuItem
End Class
