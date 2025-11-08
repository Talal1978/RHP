<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Parametrage_Bulletin_Paie
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
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GrpD = New System.Windows.Forms.GroupBox()
        Me.PnlDetail = New System.Windows.Forms.Panel()
        Me.PnlContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RéinitialiserLePanelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrpP = New System.Windows.Forms.GroupBox()
        Me.PnlPlan = New System.Windows.Forms.Panel()
        Me.Plan_Grp = New System.Windows.Forms.GroupBox()
        Me.Search_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Search_pb = New System.Windows.Forms.PictureBox()
        Me.Search_txt = New RHP.ud_TextBox()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Cod_Plan_Paie_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Cntx = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditerLaRubriqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GrpD.SuspendLayout()
        Me.PnlContextMenu.SuspendLayout()
        Me.GrpP.SuspendLayout()
        Me.Plan_Grp.SuspendLayout()
        Me.Search_pnl.SuspendLayout()
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cntx.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 63)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GrpD)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GrpP)
        Me.SplitContainer2.Size = New System.Drawing.Size(969, 434)
        Me.SplitContainer2.SplitterDistance = 575
        Me.SplitContainer2.TabIndex = 0
        '
        'GrpD
        '
        Me.GrpD.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GrpD.Controls.Add(Me.PnlDetail)
        Me.GrpD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpD.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GrpD.Location = New System.Drawing.Point(0, 0)
        Me.GrpD.Name = "GrpD"
        Me.GrpD.Size = New System.Drawing.Size(575, 434)
        Me.GrpD.TabIndex = 28
        Me.GrpD.TabStop = False
        Me.GrpD.Text = "Eléments de détail"
        '
        'PnlDetail
        '
        Me.PnlDetail.AutoScroll = True
        Me.PnlDetail.BackColor = System.Drawing.Color.White
        Me.PnlDetail.ContextMenuStrip = Me.PnlContextMenu
        Me.PnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDetail.Location = New System.Drawing.Point(3, 17)
        Me.PnlDetail.Name = "PnlDetail"
        Me.PnlDetail.Size = New System.Drawing.Size(569, 414)
        Me.PnlDetail.TabIndex = 0
        '
        'PnlContextMenu
        '
        Me.PnlContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem, Me.RéinitialiserLePanelToolStripMenuItem})
        Me.PnlContextMenu.Name = "PnlContextMenu"
        Me.PnlContextMenu.Size = New System.Drawing.Size(274, 48)
        '
        'RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem
        '
        Me.RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Actualiser
        Me.RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem.Name = "RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem"
        Me.RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
        Me.RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem.Text = "Réorganiser les éléments de la section"
        '
        'RéinitialiserLePanelToolStripMenuItem
        '
        Me.RéinitialiserLePanelToolStripMenuItem.Image = Global.RHP.My.Resources.Resources._Erase
        Me.RéinitialiserLePanelToolStripMenuItem.Name = "RéinitialiserLePanelToolStripMenuItem"
        Me.RéinitialiserLePanelToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
        Me.RéinitialiserLePanelToolStripMenuItem.Text = "Réinitialiser la section"
        '
        'GrpP
        '
        Me.GrpP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GrpP.Controls.Add(Me.PnlPlan)
        Me.GrpP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpP.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GrpP.Location = New System.Drawing.Point(0, 0)
        Me.GrpP.Name = "GrpP"
        Me.GrpP.Size = New System.Drawing.Size(390, 434)
        Me.GrpP.TabIndex = 27
        Me.GrpP.TabStop = False
        Me.GrpP.Text = "Eléments du plan de paie non encore affectés"
        '
        'PnlPlan
        '
        Me.PnlPlan.AutoScroll = True
        Me.PnlPlan.BackColor = System.Drawing.Color.White
        Me.PnlPlan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlPlan.Location = New System.Drawing.Point(3, 17)
        Me.PnlPlan.Name = "PnlPlan"
        Me.PnlPlan.Size = New System.Drawing.Size(384, 414)
        Me.PnlPlan.TabIndex = 0
        '
        'Plan_Grp
        '
        Me.Plan_Grp.Controls.Add(Me.Search_pnl)
        Me.Plan_Grp.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.Plan_Grp.Controls.Add(Me.Cod_Plan_Paie_)
        Me.Plan_Grp.Controls.Add(Me.Lib_Plan_Paie_Text)
        Me.Plan_Grp.Dock = System.Windows.Forms.DockStyle.Top
        Me.Plan_Grp.Location = New System.Drawing.Point(0, 0)
        Me.Plan_Grp.Name = "Plan_Grp"
        Me.Plan_Grp.Size = New System.Drawing.Size(969, 63)
        Me.Plan_Grp.TabIndex = 0
        Me.Plan_Grp.TabStop = False
        '
        'Search_pnl
        '
        Me.Search_pnl.BackColor = System.Drawing.Color.White
        Me.Search_pnl.ColumnCount = 2
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.Search_pnl.Controls.Add(Me.Search_pb, 1, 0)
        Me.Search_pnl.Controls.Add(Me.Search_txt, 0, 0)
        Me.Search_pnl.Location = New System.Drawing.Point(600, 16)
        Me.Search_pnl.Margin = New System.Windows.Forms.Padding(3, 17, 3, 0)
        Me.Search_pnl.Name = "Search_pnl"
        Me.Search_pnl.RowCount = 1
        Me.Search_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.Size = New System.Drawing.Size(294, 35)
        Me.Search_pnl.TabIndex = 18
        '
        'Search_pb
        '
        Me.Search_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Search_pb.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.Search_pb.Location = New System.Drawing.Point(265, 6)
        Me.Search_pb.Margin = New System.Windows.Forms.Padding(6)
        Me.Search_pb.Name = "Search_pb"
        Me.Search_pb.Size = New System.Drawing.Size(23, 23)
        Me.Search_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Search_pb.TabIndex = 4
        Me.Search_pb.TabStop = False
        Me.Search_pb.Tag = "false"
        '
        'Search_txt
        '
        Me.Search_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Search_txt.ContextMenuStrip = Nothing
        Me.Search_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Search_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Search_txt.Location = New System.Drawing.Point(6, 6)
        Me.Search_txt.Margin = New System.Windows.Forms.Padding(6)
        Me.Search_txt.MaxLength = 32767
        Me.Search_txt.Multiline = False
        Me.Search_txt.Name = "Search_txt"
        Me.Search_txt.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Search_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Search_txt.ReadOnly = False
        Me.Search_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Search_txt.SelectionStart = 0
        Me.Search_txt.Size = New System.Drawing.Size(247, 23)
        Me.Search_txt.TabIndex = 2
        Me.Search_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Search_txt.UseSystemPasswordChar = False
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(42, 24)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Plan_Paie_Text.MaxLength = 10
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(102, 21)
        Me.Cod_Plan_Paie_Text.TabIndex = 0
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Cod_Plan_Paie_
        '
        Me.Cod_Plan_Paie_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.AutoSize = True
        Me.Cod_Plan_Paie_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.Location = New System.Drawing.Point(9, 28)
        Me.Cod_Plan_Paie_.Name = "Cod_Plan_Paie_"
        Me.Cod_Plan_Paie_.Size = New System.Drawing.Size(32, 16)
        Me.Cod_Plan_Paie_.TabIndex = 17
        Me.Cod_Plan_Paie_.TabStop = True
        Me.Cod_Plan_Paie_.Text = "Plan"
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Lib_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(147, 24)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Plan_Paie_Text.MaxLength = 32767
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = True
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(325, 21)
        Me.Lib_Plan_Paie_Text.TabIndex = 1
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Cntx
        '
        Me.Cntx.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditerLaRubriqueToolStripMenuItem})
        Me.Cntx.Name = "Cntx"
        Me.Cntx.Size = New System.Drawing.Size(206, 26)
        '
        'EditerLaRubriqueToolStripMenuItem
        '
        Me.EditerLaRubriqueToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Dollar
        Me.EditerLaRubriqueToolStripMenuItem.Name = "EditerLaRubriqueToolStripMenuItem"
        Me.EditerLaRubriqueToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.EditerLaRubriqueToolStripMenuItem.Text = "Editer la rubrique de paie"
        '
        'RH_Parametrage_Bulletin_Paie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(969, 497)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.Plan_Grp)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RH_Parametrage_Bulletin_Paie"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage des bulletins de paie"
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GrpD.ResumeLayout(False)
        Me.PnlContextMenu.ResumeLayout(False)
        Me.GrpP.ResumeLayout(False)
        Me.Plan_Grp.ResumeLayout(False)
        Me.Plan_Grp.PerformLayout()
        Me.Search_pnl.ResumeLayout(False)
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cntx.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Plan_Grp As System.Windows.Forms.GroupBox
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Cod_Plan_Paie_ As System.Windows.Forms.LinkLabel
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents GrpP As GroupBox
    Friend WithEvents PnlPlan As Panel
    Friend WithEvents GrpD As GroupBox
    Friend WithEvents PnlDetail As Panel
    Friend WithEvents Cntx As ContextMenuStrip
    Friend WithEvents EditerLaRubriqueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PnlContextMenu As ContextMenuStrip
    Friend WithEvents RéinitialiserLePanelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Search_pnl As TableLayoutPanel
    Friend WithEvents Search_pb As PictureBox
    Friend WithEvents Search_txt As ud_TextBox
End Class
