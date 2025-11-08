<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Parametrage_Declarations_Fiscales_Sociales_Old
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
        Me.Grp_ED = New System.Windows.Forms.GroupBox()
        Me.Pnl_ED = New System.Windows.Forms.Panel()
        Me.GrpP = New System.Windows.Forms.GroupBox()
        Me.PnlPlan = New System.Windows.Forms.Panel()
        Me.Plan_Grp = New System.Windows.Forms.GroupBox()
        Me.Saisie_Libre_chk = New RHP.ud_CheckBox()
        Me.Cod_Plan_Paie_ = New System.Windows.Forms.LinkLabel()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Cod_Declaration_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Declaration_txt = New RHP.ud_TextBox()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Grp_ED.SuspendLayout()
        Me.GrpP.SuspendLayout()
        Me.Plan_Grp.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 81)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Grp_ED)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GrpP)
        Me.SplitContainer2.Size = New System.Drawing.Size(999, 614)
        Me.SplitContainer2.SplitterDistance = 592
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'Grp_ED
        '
        Me.Grp_ED.Controls.Add(Me.Pnl_ED)
        Me.Grp_ED.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grp_ED.Location = New System.Drawing.Point(0, 0)
        Me.Grp_ED.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grp_ED.Name = "Grp_ED"
        Me.Grp_ED.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grp_ED.Size = New System.Drawing.Size(592, 614)
        Me.Grp_ED.TabIndex = 0
        Me.Grp_ED.TabStop = False
        Me.Grp_ED.Text = "Eléments de la déclaration "
        '
        'Pnl_ED
        '
        Me.Pnl_ED.AutoScroll = True
        Me.Pnl_ED.BackColor = System.Drawing.Color.White
        Me.Pnl_ED.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_ED.Location = New System.Drawing.Point(3, 18)
        Me.Pnl_ED.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Pnl_ED.Name = "Pnl_ED"
        Me.Pnl_ED.Size = New System.Drawing.Size(586, 592)
        Me.Pnl_ED.TabIndex = 1
        '
        'GrpP
        '
        Me.GrpP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GrpP.Controls.Add(Me.PnlPlan)
        Me.GrpP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpP.Location = New System.Drawing.Point(0, 0)
        Me.GrpP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpP.Name = "GrpP"
        Me.GrpP.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpP.Size = New System.Drawing.Size(402, 614)
        Me.GrpP.TabIndex = 27
        Me.GrpP.TabStop = False
        Me.GrpP.Text = "Eléments du plan de paie non encore affectés"
        '
        'PnlPlan
        '
        Me.PnlPlan.AutoScroll = True
        Me.PnlPlan.BackColor = System.Drawing.Color.White
        Me.PnlPlan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlPlan.Location = New System.Drawing.Point(3, 18)
        Me.PnlPlan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PnlPlan.Name = "PnlPlan"
        Me.PnlPlan.Size = New System.Drawing.Size(396, 592)
        Me.PnlPlan.TabIndex = 0
        '
        'Plan_Grp
        '
        Me.Plan_Grp.Controls.Add(Me.Saisie_Libre_chk)
        Me.Plan_Grp.Controls.Add(Me.Cod_Plan_Paie_)
        Me.Plan_Grp.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.Plan_Grp.Controls.Add(Me.Cod_Declaration_txt)
        Me.Plan_Grp.Controls.Add(Me.LinkLabel1)
        Me.Plan_Grp.Controls.Add(Me.Lib_Declaration_txt)
        Me.Plan_Grp.Dock = System.Windows.Forms.DockStyle.Top
        Me.Plan_Grp.Location = New System.Drawing.Point(0, 0)
        Me.Plan_Grp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Plan_Grp.Name = "Plan_Grp"
        Me.Plan_Grp.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Plan_Grp.Size = New System.Drawing.Size(999, 81)
        Me.Plan_Grp.TabIndex = 0
        Me.Plan_Grp.TabStop = False
        '
        'Saisie_Libre_chk
        '
        Me.Saisie_Libre_chk.AutoSize = True
        Me.Saisie_Libre_chk.Checked = True
        Me.Saisie_Libre_chk.Location = New System.Drawing.Point(622, 44)
        Me.Saisie_Libre_chk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Saisie_Libre_chk.MaximumSize = New System.Drawing.Size(0, 20)
        Me.Saisie_Libre_chk.MinimumSize = New System.Drawing.Size(100, 20)
        Me.Saisie_Libre_chk.Name = "Saisie_Libre_chk"
        Me.Saisie_Libre_chk.Size = New System.Drawing.Size(176, 20)
        Me.Saisie_Libre_chk.TabIndex = 21
        Me.Saisie_Libre_chk.Text = "Saisie libre de la déclaration"
        '
        'Cod_Plan_Paie_
        '
        Me.Cod_Plan_Paie_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.AutoSize = True
        Me.Cod_Plan_Paie_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.Location = New System.Drawing.Point(71, 44)
        Me.Cod_Plan_Paie_.Name = "Cod_Plan_Paie_"
        Me.Cod_Plan_Paie_.Size = New System.Drawing.Size(32, 16)
        Me.Cod_Plan_Paie_.TabIndex = 17
        Me.Cod_Plan_Paie_.TabStop = True
        Me.Cod_Plan_Paie_.Text = "Plan"
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.BackColor = System.Drawing.SystemColors.Control
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(107, 42)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Plan_Paie_Text.MaxLength = 10
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(507, 21)
        Me.Cod_Plan_Paie_Text.TabIndex = 0
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Cod_Declaration_txt
        '
        Me.Cod_Declaration_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Cod_Declaration_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Declaration_txt.Location = New System.Drawing.Point(107, 15)
        Me.Cod_Declaration_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Declaration_txt.MaxLength = 10
        Me.Cod_Declaration_txt.Multiline = False
        Me.Cod_Declaration_txt.Name = "Cod_Declaration_txt"
        Me.Cod_Declaration_txt.ReadOnly = True
        Me.Cod_Declaration_txt.Size = New System.Drawing.Size(128, 21)
        Me.Cod_Declaration_txt.TabIndex = 18
        Me.Cod_Declaration_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(29, 17)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(74, 16)
        Me.LinkLabel1.TabIndex = 20
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Déclaration "
        '
        'Lib_Declaration_txt
        '
        Me.Lib_Declaration_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Declaration_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Declaration_txt.Location = New System.Drawing.Point(238, 15)
        Me.Lib_Declaration_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Declaration_txt.MaxLength = 32767
        Me.Lib_Declaration_txt.Multiline = False
        Me.Lib_Declaration_txt.Name = "Lib_Declaration_txt"
        Me.Lib_Declaration_txt.ReadOnly = True
        Me.Lib_Declaration_txt.Size = New System.Drawing.Size(623, 21)
        Me.Lib_Declaration_txt.TabIndex = 19
        Me.Lib_Declaration_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'RH_Parametrage_Declarations_Fiscales_Sociales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(999, 695)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.Plan_Grp)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "RH_Parametrage_Declarations_Fiscales_Sociales"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage des déclarations fiscales et sociales"
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Grp_ED.ResumeLayout(False)
        Me.GrpP.ResumeLayout(False)
        Me.Plan_Grp.ResumeLayout(False)
        Me.Plan_Grp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Plan_Grp As System.Windows.Forms.GroupBox
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Cod_Plan_Paie_ As System.Windows.Forms.LinkLabel
    Friend WithEvents GrpP As GroupBox
    Friend WithEvents PnlPlan As Panel
    Friend WithEvents Grp_ED As GroupBox
    Friend WithEvents Cod_Declaration_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Lib_Declaration_txt As ud_TextBox
    Friend WithEvents Pnl_ED As Panel
    Friend WithEvents Saisie_Libre_chk As ud_CheckBox
End Class
