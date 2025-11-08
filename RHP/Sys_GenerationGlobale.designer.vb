<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sys_GenerationGlobale
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
        Me.ProgressBar1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Lbl1 = New System.Windows.Forms.Label()
        Me.Lbl = New System.Windows.Forms.Label()
        Me.Ud_button1 = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        '
        '
        '
        Me.ProgressBar1.BackgroundStyle.Class = ""
        Me.ProgressBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 86)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Me.ProgressBar1.Size = New System.Drawing.Size(527, 23)
        Me.ProgressBar1.Step = 50
        Me.ProgressBar1.TabIndex = 13
        Me.ProgressBar1.Text = "ProgressBarX1"
        Me.ProgressBar1.Visible = False
        '
        'Lbl1
        '
        Me.Lbl1.Location = New System.Drawing.Point(14, 10)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(522, 65)
        Me.Lbl1.TabIndex = 9
        Me.Lbl1.Text = "Cliquez sur exécuter pour lancer le traitement."
        '
        'Lbl
        '
        Me.Lbl.AutoSize = True
        Me.Lbl.Location = New System.Drawing.Point(33, 64)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(0, 13)
        Me.Lbl.TabIndex = 8
        '
        'Ud_button1
        '
        Me.Ud_button1.AutoSize = True
        Me.Ud_button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_button1.Border = RHP.ud_button.BorderStyle.All
        Me.Ud_button1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_button1.BorderSize = 2
        Me.Ud_button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ud_button1.Image = Global.RHP.My.Resources.Resources.btn_specifique
        Me.Ud_button1.Location = New System.Drawing.Point(436, 114)
        Me.Ud_button1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Ud_button1.Name = "Ud_button1"
        Me.Ud_button1.Padding = New System.Windows.Forms.Padding(2)
        Me.Ud_button1.Size = New System.Drawing.Size(101, 33)
        Me.Ud_button1.TabIndex = 14
        Me.Ud_button1.Text = "Exécuter"
        Me.Ud_button1.ToolTip = ""
        '
        'Annuler_ud
        '
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.Location = New System.Drawing.Point(9, 114)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(100, 33)
        Me.Annuler_ud.TabIndex = 14
        Me.Annuler_ud.Text = "Annuler"
        Me.Annuler_ud.ToolTip = ""
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Lbl1)
        Me.Panel1.Controls.Add(Me.Ud_button1)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(544, 153)
        Me.Panel1.TabIndex = 15
        '
        'Sys_GenerationGlobale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(548, 157)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Lbl)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Sys_GenerationGlobale"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Génération globale"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents Lbl As System.Windows.Forms.Label
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Ud_button1 As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Panel1 As Panel
End Class
