<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Rubrique_Copie
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rubriques de la paie")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fiche de renseignement de l'Agent")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fonctions de calcul de la paie")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rubriques de la paie")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fiche de renseignement de l'Agent")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fonctions de calcul de la paie")
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FunctionOri_Trv = New System.Windows.Forms.TreeView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FunctionDes_Trv = New System.Windows.Forms.TreeView()
        Me.Plan_Grp = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.id_Societe_Des_txt = New RHP.ud_TextBox()
        Me.Lib_Societe_Des_txt = New RHP.ud_TextBox()
        Me.pos_lbl = New System.Windows.Forms.Label()
        Me.id_Societe_Org_txt = New RHP.ud_TextBox()
        Me.Cod_Plan_Paie_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Societe_Org_txt = New RHP.ud_TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Plan_Grp.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 41)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Size = New System.Drawing.Size(936, 562)
        Me.SplitContainer2.SplitterDistance = 480
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.FunctionOri_Trv)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(480, 562)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Société origine"
        '
        'FunctionOri_Trv
        '
        Me.FunctionOri_Trv.CheckBoxes = True
        Me.FunctionOri_Trv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FunctionOri_Trv.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FunctionOri_Trv.Location = New System.Drawing.Point(3, 17)
        Me.FunctionOri_Trv.Name = "FunctionOri_Trv"
        TreeNode1.Name = "Nœud1"
        TreeNode1.Text = "Rubriques de la paie"
        TreeNode1.ToolTipText = "Rubriques de la paie"
        TreeNode2.Name = "Nœud2"
        TreeNode2.Text = "Fiche de renseignement de l'Agent"
        TreeNode2.ToolTipText = "Fiche de renseignement de l'Agent"
        TreeNode3.Name = "Nœud0"
        TreeNode3.Text = "Fonctions de calcul de la paie"
        TreeNode3.ToolTipText = "Fonctions de calcul de la paie"
        Me.FunctionOri_Trv.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Me.FunctionOri_Trv.Size = New System.Drawing.Size(474, 542)
        Me.FunctionOri_Trv.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.FunctionDes_Trv)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(452, 562)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Société de destination"
        '
        'FunctionDes_Trv
        '
        Me.FunctionDes_Trv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FunctionDes_Trv.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FunctionDes_Trv.Location = New System.Drawing.Point(3, 17)
        Me.FunctionDes_Trv.Name = "FunctionDes_Trv"
        TreeNode4.Name = "Nœud1"
        TreeNode4.Text = "Rubriques de la paie"
        TreeNode4.ToolTipText = "Rubriques de la paie"
        TreeNode5.Name = "Nœud2"
        TreeNode5.Text = "Fiche de renseignement de l'Agent"
        TreeNode5.ToolTipText = "Fiche de renseignement de l'Agent"
        TreeNode6.Name = "Nœud0"
        TreeNode6.Text = "Fonctions de calcul de la paie"
        TreeNode6.ToolTipText = "Fonctions de calcul de la paie"
        Me.FunctionDes_Trv.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5, TreeNode6})
        Me.FunctionDes_Trv.Size = New System.Drawing.Size(446, 542)
        Me.FunctionDes_Trv.TabIndex = 0
        '
        'Plan_Grp
        '
        Me.Plan_Grp.Controls.Add(Me.Label1)
        Me.Plan_Grp.Controls.Add(Me.id_Societe_Des_txt)
        Me.Plan_Grp.Controls.Add(Me.Lib_Societe_Des_txt)
        Me.Plan_Grp.Controls.Add(Me.pos_lbl)
        Me.Plan_Grp.Controls.Add(Me.id_Societe_Org_txt)
        Me.Plan_Grp.Controls.Add(Me.Cod_Plan_Paie_)
        Me.Plan_Grp.Controls.Add(Me.Lib_Societe_Org_txt)
        Me.Plan_Grp.Dock = System.Windows.Forms.DockStyle.Top
        Me.Plan_Grp.Location = New System.Drawing.Point(0, 0)
        Me.Plan_Grp.Name = "Plan_Grp"
        Me.Plan_Grp.Size = New System.Drawing.Size(936, 41)
        Me.Plan_Grp.TabIndex = 0
        Me.Plan_Grp.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(340, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Vers"
        '
        'id_Societe_Des_txt
        '
        Me.id_Societe_Des_txt.BackColor = System.Drawing.SystemColors.Control
        Me.id_Societe_Des_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.id_Societe_Des_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.id_Societe_Des_txt.Location = New System.Drawing.Point(369, 13)
        Me.id_Societe_Des_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.id_Societe_Des_txt.MaxLength = 10
        Me.id_Societe_Des_txt.Multiline = False
        Me.id_Societe_Des_txt.Name = "id_Societe_Des_txt"
        Me.id_Societe_Des_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.id_Societe_Des_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.id_Societe_Des_txt.ReadOnly = True
        Me.id_Societe_Des_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.id_Societe_Des_txt.SelectionStart = 0
        Me.id_Societe_Des_txt.Size = New System.Drawing.Size(36, 21)
        Me.id_Societe_Des_txt.TabIndex = 24
        Me.id_Societe_Des_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.id_Societe_Des_txt.UseSystemPasswordChar = False
        '
        'Lib_Societe_Des_txt
        '
        Me.Lib_Societe_Des_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Societe_Des_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Societe_Des_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Societe_Des_txt.Location = New System.Drawing.Point(409, 13)
        Me.Lib_Societe_Des_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Societe_Des_txt.MaxLength = 32767
        Me.Lib_Societe_Des_txt.Multiline = False
        Me.Lib_Societe_Des_txt.Name = "Lib_Societe_Des_txt"
        Me.Lib_Societe_Des_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Societe_Des_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Societe_Des_txt.ReadOnly = True
        Me.Lib_Societe_Des_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Societe_Des_txt.SelectionStart = 0
        Me.Lib_Societe_Des_txt.Size = New System.Drawing.Size(248, 21)
        Me.Lib_Societe_Des_txt.TabIndex = 25
        Me.Lib_Societe_Des_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Societe_Des_txt.UseSystemPasswordChar = False
        '
        'pos_lbl
        '
        Me.pos_lbl.AutoSize = True
        Me.pos_lbl.Location = New System.Drawing.Point(30, 44)
        Me.pos_lbl.Name = "pos_lbl"
        Me.pos_lbl.Size = New System.Drawing.Size(29, 16)
        Me.pos_lbl.TabIndex = 22
        Me.pos_lbl.Text = "0 : 0"
        Me.pos_lbl.Visible = False
        '
        'id_Societe_Org_txt
        '
        Me.id_Societe_Org_txt.BackColor = System.Drawing.SystemColors.Control
        Me.id_Societe_Org_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.id_Societe_Org_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.id_Societe_Org_txt.Location = New System.Drawing.Point(39, 12)
        Me.id_Societe_Org_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.id_Societe_Org_txt.MaxLength = 10
        Me.id_Societe_Org_txt.Multiline = False
        Me.id_Societe_Org_txt.Name = "id_Societe_Org_txt"
        Me.id_Societe_Org_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.id_Societe_Org_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.id_Societe_Org_txt.ReadOnly = True
        Me.id_Societe_Org_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.id_Societe_Org_txt.SelectionStart = 0
        Me.id_Societe_Org_txt.Size = New System.Drawing.Size(37, 21)
        Me.id_Societe_Org_txt.TabIndex = 0
        Me.id_Societe_Org_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.id_Societe_Org_txt.UseSystemPasswordChar = False
        '
        'Cod_Plan_Paie_
        '
        Me.Cod_Plan_Paie_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.AutoSize = True
        Me.Cod_Plan_Paie_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.Location = New System.Drawing.Point(15, 16)
        Me.Cod_Plan_Paie_.Name = "Cod_Plan_Paie_"
        Me.Cod_Plan_Paie_.Size = New System.Drawing.Size(23, 16)
        Me.Cod_Plan_Paie_.TabIndex = 17
        Me.Cod_Plan_Paie_.TabStop = True
        Me.Cod_Plan_Paie_.Text = "De"
        '
        'Lib_Societe_Org_txt
        '
        Me.Lib_Societe_Org_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Societe_Org_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Societe_Org_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Societe_Org_txt.Location = New System.Drawing.Point(78, 12)
        Me.Lib_Societe_Org_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Societe_Org_txt.MaxLength = 32767
        Me.Lib_Societe_Org_txt.Multiline = False
        Me.Lib_Societe_Org_txt.Name = "Lib_Societe_Org_txt"
        Me.Lib_Societe_Org_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Societe_Org_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Societe_Org_txt.ReadOnly = True
        Me.Lib_Societe_Org_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Societe_Org_txt.SelectionStart = 0
        Me.Lib_Societe_Org_txt.Size = New System.Drawing.Size(251, 21)
        Me.Lib_Societe_Org_txt.TabIndex = 1
        Me.Lib_Societe_Org_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Societe_Org_txt.UseSystemPasswordChar = False
        '
        'RH_Rubrique_Copie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(936, 603)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.Plan_Grp)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RH_Rubrique_Copie"
        Me.Tag = "ECR"
        Me.Text = "Reproduire les rubriques de paie depuis une autre société"
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Plan_Grp.ResumeLayout(False)
        Me.Plan_Grp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Plan_Grp As System.Windows.Forms.GroupBox
    Friend WithEvents FunctionOri_Trv As System.Windows.Forms.TreeView
    Friend WithEvents id_Societe_Org_txt As ud_TextBox
    Friend WithEvents Cod_Plan_Paie_ As System.Windows.Forms.LinkLabel
    Friend WithEvents Lib_Societe_Org_txt As ud_TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pos_lbl As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents FunctionDes_Trv As TreeView
    Friend WithEvents id_Societe_Des_txt As ud_TextBox
    Friend WithEvents Lib_Societe_Des_txt As ud_TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label1 As Label
End Class
