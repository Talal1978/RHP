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
        Me.Ud_button1 = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lbl = New System.Windows.Forms.Label()
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
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 106)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Me.ProgressBar1.Size = New System.Drawing.Size(703, 28)
        Me.ProgressBar1.Step = 50
        Me.ProgressBar1.TabIndex = 13
        Me.ProgressBar1.Text = "ProgressBarX1"
        Me.ProgressBar1.Visible = False
        '
        'Lbl1
        '
        Me.Lbl1.Location = New System.Drawing.Point(19, 12)
        Me.Lbl1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(696, 35)
        Me.Lbl1.TabIndex = 9
        Me.Lbl1.Text = "Cliquez sur exécuter pour lancer le traitement."
        '
        'Ud_button1
        '
        Me.Ud_button1.AutoSize = True
        Me.Ud_button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_button1.bgColor = System.Drawing.Color.White
        Me.Ud_button1.Border = RHP.ud_button.BorderStyle.All
        Me.Ud_button1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_button1.BorderSize = 2
        Me.Ud_button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ud_button1.Image = Global.RHP.My.Resources.Resources.btn_specifique
        Me.Ud_button1.isDefault = False
        Me.Ud_button1.Location = New System.Drawing.Point(581, 140)
        Me.Ud_button1.Margin = New System.Windows.Forms.Padding(5)
        Me.Ud_button1.MinimumSize = New System.Drawing.Size(27, 25)
        Me.Ud_button1.Name = "Ud_button1"
        Me.Ud_button1.Padding = New System.Windows.Forms.Padding(2)
        Me.Ud_button1.Size = New System.Drawing.Size(135, 41)
        Me.Ud_button1.TabIndex = 14
        Me.Ud_button1.Text = "Exécuter"
        '
        'Annuler_ud
        '
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.bgColor = System.Drawing.Color.White
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.isDefault = False
        Me.Annuler_ud.Location = New System.Drawing.Point(12, 140)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(27, 25)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(133, 41)
        Me.Annuler_ud.TabIndex = 14
        Me.Annuler_ud.Text = "Annuler"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Lbl)
        Me.Panel1.Controls.Add(Me.Lbl1)
        Me.Panel1.Controls.Add(Me.Ud_button1)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 189)
        Me.Panel1.TabIndex = 15
        '
        'Lbl
        '
        Me.Lbl.Location = New System.Drawing.Point(13, 61)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(703, 41)
        Me.Lbl.TabIndex = 15
        '
        'Sys_GenerationGlobale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(731, 193)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Sys_GenerationGlobale"
        Me.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Génération globale"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Ud_button1 As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Lbl As Label
End Class
