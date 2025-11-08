<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Survey_Editeur_Formule
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fonctions Système")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Abaques de paie")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("La réponse")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("L'évalué")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("L'évaluateur")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Type évaluation")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Réponses", New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Me.Formule_Function_Text = New System.Windows.Forms.RichTextBox()
        Me.Resultat = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Function_Trv = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EvaluerLaValeurDeLaVariableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rechercher_txt = New RHP.ud_TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Entete_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Simuler_pb = New System.Windows.Forms.PictureBox()
        Me.Actualiser_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Trv_pnl = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Entete_pnl.SuspendLayout()
        CType(Me.Simuler_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Actualiser_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Trv_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Formule_Function_Text
        '
        Me.Formule_Function_Text.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Formule_Function_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Formule_Function_Text.Location = New System.Drawing.Point(2, 58)
        Me.Formule_Function_Text.Margin = New System.Windows.Forms.Padding(4)
        Me.Formule_Function_Text.Name = "Formule_Function_Text"
        Me.Formule_Function_Text.Size = New System.Drawing.Size(705, 410)
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
        Me.Resultat.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Resultat.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Resultat.Location = New System.Drawing.Point(2, 468)
        Me.Resultat.Margin = New System.Windows.Forms.Padding(4)
        Me.Resultat.Multiline = True
        Me.Resultat.Name = "Resultat"
        Me.Resultat.ReadOnly = True
        Me.Resultat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Resultat.Size = New System.Drawing.Size(705, 92)
        Me.Resultat.TabIndex = 11
        '
        'Function_Trv
        '
        Me.Function_Trv.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Function_Trv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Function_Trv.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Function_Trv.ItemHeight = 22
        Me.Function_Trv.Location = New System.Drawing.Point(0, 26)
        Me.Function_Trv.Margin = New System.Windows.Forms.Padding(4)
        Me.Function_Trv.Name = "Function_Trv"
        TreeNode1.Name = "FS"
        TreeNode1.Text = "Fonctions Système"
        TreeNode1.ToolTipText = "Fonctions Système"
        TreeNode2.Name = "AB"
        TreeNode2.Text = "Abaques de paie"
        TreeNode2.ToolTipText = "Abaques de paie"
        TreeNode3.Name = "CurrentAnswer"
        TreeNode3.Tag = "CurrentAnswer"
        TreeNode3.Text = "La réponse"
        TreeNode4.Name = "Evalue"
        TreeNode4.Tag = "Evalue"
        TreeNode4.Text = "L'évalué"
        TreeNode5.Name = "Evaluateur"
        TreeNode5.Tag = "Evaluateur"
        TreeNode5.Text = "L'évaluateur"
        TreeNode6.Name = "Typ_Evaluation"
        TreeNode6.Tag = "Typ_Evaluation"
        TreeNode6.Text = "Type évaluation"
        TreeNode7.Name = "RSP"
        TreeNode7.Text = "Réponses"
        Me.Function_Trv.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode7})
        Me.Function_Trv.Size = New System.Drawing.Size(302, 476)
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
        Me.Rechercher_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Rechercher_txt.MaxLength = 32767
        Me.Rechercher_txt.Multiline = False
        Me.Rechercher_txt.Name = "Rechercher_txt"
        Me.Rechercher_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Rechercher_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Rechercher_txt.ReadOnly = False
        Me.Rechercher_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Rechercher_txt.SelectionStart = 0
        Me.Rechercher_txt.Size = New System.Drawing.Size(302, 26)
        Me.Rechercher_txt.TabIndex = 9
        Me.Rechercher_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Rechercher_txt.UseSystemPasswordChar = False
        '
        'Entete_pnl
        '
        Me.Entete_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Entete_pnl.ColumnCount = 5
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.Entete_pnl.Controls.Add(Me.Titre_lbl, 3, 0)
        Me.Entete_pnl.Controls.Add(Me.Simuler_pb, 2, 0)
        Me.Entete_pnl.Controls.Add(Me.Actualiser_pb, 1, 0)
        Me.Entete_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.Entete_pnl.Controls.Add(Me.Close_pb, 4, 0)
        Me.Entete_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Entete_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Entete_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Entete_pnl.Name = "Entete_pnl"
        Me.Entete_pnl.Padding = New System.Windows.Forms.Padding(2)
        Me.Entete_pnl.RowCount = 1
        Me.Entete_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Entete_pnl.Size = New System.Drawing.Size(1011, 56)
        Me.Entete_pnl.TabIndex = 15
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(120, 2)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(847, 39)
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.Text = "Editeur de formule"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Simuler_pb
        '
        Me.Simuler_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Simuler_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Simuler_pb.Image = Global.RHP.My.Resources.Resources.btn_netToBrut_w
        Me.Simuler_pb.InitialImage = Nothing
        Me.Simuler_pb.Location = New System.Drawing.Point(82, 6)
        Me.Simuler_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Simuler_pb.Name = "Simuler_pb"
        Me.Simuler_pb.Size = New System.Drawing.Size(30, 44)
        Me.Simuler_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Simuler_pb.TabIndex = 2
        Me.Simuler_pb.TabStop = False
        '
        'Actualiser_pb
        '
        Me.Actualiser_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Actualiser_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Actualiser_pb.Image = Global.RHP.My.Resources.Resources.btn_request_w
        Me.Actualiser_pb.InitialImage = Nothing
        Me.Actualiser_pb.Location = New System.Drawing.Point(44, 6)
        Me.Actualiser_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Actualiser_pb.Name = "Actualiser_pb"
        Me.Actualiser_pb.Size = New System.Drawing.Size(30, 44)
        Me.Actualiser_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Actualiser_pb.TabIndex = 1
        Me.Actualiser_pb.TabStop = False
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save_w
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(6, 6)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(30, 44)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Save_pb.TabIndex = 0
        Me.Save_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(975, 6)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(30, 44)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 3
        Me.Close_pb.TabStop = False
        '
        'Trv_pnl
        '
        Me.Trv_pnl.Controls.Add(Me.Function_Trv)
        Me.Trv_pnl.Controls.Add(Me.Rechercher_txt)
        Me.Trv_pnl.Dock = System.Windows.Forms.DockStyle.Right
        Me.Trv_pnl.Location = New System.Drawing.Point(711, 58)
        Me.Trv_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Trv_pnl.Name = "Trv_pnl"
        Me.Trv_pnl.Size = New System.Drawing.Size(302, 502)
        Me.Trv_pnl.TabIndex = 10
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(707, 58)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(4)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 502)
        Me.Splitter1.TabIndex = 10
        Me.Splitter1.TabStop = False
        '
        'Zoom_Survey_Editeur_Formule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1015, 562)
        Me.Controls.Add(Me.Formule_Function_Text)
        Me.Controls.Add(Me.Resultat)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Trv_pnl)
        Me.Controls.Add(Me.Entete_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_Survey_Editeur_Formule"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Zoom Editeur de Formule"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Entete_pnl.ResumeLayout(False)
        CType(Me.Simuler_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Actualiser_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Trv_pnl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Formule_Function_Text As RichTextBox
    Friend WithEvents Resultat As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Function_Trv As TreeView
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EvaluerLaValeurDeLaVariableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Rechercher_txt As ud_TextBox
    Friend WithEvents Entete_pnl As TableLayoutPanel
    Friend WithEvents Trv_pnl As Panel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Simuler_pb As PictureBox
    Friend WithEvents Actualiser_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Titre_lbl As Label
End Class
