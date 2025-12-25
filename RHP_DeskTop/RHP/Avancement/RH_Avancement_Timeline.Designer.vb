<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Avancement_Timeline
    Inherits Ecran

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.flpTimeline = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpTimeline
        '
        Me.flpTimeline.AutoScroll = True
        Me.flpTimeline.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.flpTimeline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpTimeline.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpTimeline.Location = New System.Drawing.Point(0, 98)
        Me.flpTimeline.Margin = New System.Windows.Forms.Padding(4)
        Me.flpTimeline.Name = "flpTimeline"
        Me.flpTimeline.Padding = New System.Windows.Forms.Padding(0, 25, 0, 0)
        Me.flpTimeline.Size = New System.Drawing.Size(1045, 592)
        Me.flpTimeline.TabIndex = 0
        Me.flpTimeline.WrapContents = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Matricule_txt)
        Me.pnlHeader.Controls.Add(Me.Matricule_)
        Me.pnlHeader.Controls.Add(Me.Nom_Agent_Text)
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1045, 98)
        Me.pnlHeader.TabIndex = 1
        '
        'Matricule_txt
        '
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(102, 61)
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
        Me.Matricule_txt.TabIndex = 220
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(38, 66)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(61, 16)
        Me.Matricule_.TabIndex = 219
        Me.Matricule_.TabStop = True
        Me.Matricule_.Text = "Matricule"
        Me.Matricule_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(264, 61)
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
        Me.Nom_Agent_Text.TabIndex = 221
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblHeader.Location = New System.Drawing.Point(32, 11)
        Me.lblHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(385, 46)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Parcours Professionnel"
        '
        'RH_Avancement_Timeline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 690)
        Me.Controls.Add(Me.flpTimeline)
        Me.Controls.Add(Me.pnlHeader)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RH_Avancement_Timeline"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Timeline Carrière"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpTimeline As FlowLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblHeader As Label
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Nom_Agent_Text As ud_TextBox
End Class
