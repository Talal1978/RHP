<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Licencing
    Inherits System.Windows.Forms.Form

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
        Me.Licence_Text = New System.Windows.Forms.Label()
        Me.txtS1 = New RHP.ud_TextBox()
        Me.txtS2 = New RHP.ud_TextBox()
        Me.txtS3 = New RHP.ud_TextBox()
        Me.txtS4 = New RHP.ud_TextBox()
        Me.otxt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbLic = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        CType(Me.pbLic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Licence_Text
        '
        Me.Licence_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Licence_Text.Location = New System.Drawing.Point(20, 55)
        Me.Licence_Text.Name = "Licence_Text"
        Me.Licence_Text.Size = New System.Drawing.Size(331, 24)
        Me.Licence_Text.TabIndex = 206
        Me.Licence_Text.Text = "Veuillez saisir votre N° de série :"
        '
        'txtS1
        '
        Me.txtS1.BackColor = System.Drawing.SystemColors.Window
        Me.txtS1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtS1.Location = New System.Drawing.Point(126, 110)
        Me.txtS1.MaxLength = 4
        Me.txtS1.Multiline = False
        Me.txtS1.Name = "txtS1"
        Me.txtS1.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtS1.ReadOnly = False
        Me.txtS1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtS1.SelectionStart = 0
        Me.txtS1.Size = New System.Drawing.Size(62, 21)
        Me.txtS1.TabIndex = 207
        Me.txtS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtS1.UseSystemPasswordChar = False
        '
        'txtS2
        '
        Me.txtS2.BackColor = System.Drawing.SystemColors.Window
        Me.txtS2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtS2.Location = New System.Drawing.Point(191, 110)
        Me.txtS2.MaxLength = 4
        Me.txtS2.Multiline = False
        Me.txtS2.Name = "txtS2"
        Me.txtS2.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtS2.ReadOnly = False
        Me.txtS2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtS2.SelectionStart = 0
        Me.txtS2.Size = New System.Drawing.Size(62, 21)
        Me.txtS2.TabIndex = 208
        Me.txtS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtS2.UseSystemPasswordChar = False
        '
        'txtS3
        '
        Me.txtS3.BackColor = System.Drawing.SystemColors.Window
        Me.txtS3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtS3.Location = New System.Drawing.Point(256, 110)
        Me.txtS3.MaxLength = 4
        Me.txtS3.Multiline = False
        Me.txtS3.Name = "txtS3"
        Me.txtS3.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtS3.ReadOnly = False
        Me.txtS3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtS3.SelectionStart = 0
        Me.txtS3.Size = New System.Drawing.Size(62, 21)
        Me.txtS3.TabIndex = 209
        Me.txtS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtS3.UseSystemPasswordChar = False
        '
        'txtS4
        '
        Me.txtS4.BackColor = System.Drawing.SystemColors.Window
        Me.txtS4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtS4.Location = New System.Drawing.Point(321, 110)
        Me.txtS4.MaxLength = 4
        Me.txtS4.Multiline = False
        Me.txtS4.Name = "txtS4"
        Me.txtS4.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtS4.ReadOnly = False
        Me.txtS4.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtS4.SelectionStart = 0
        Me.txtS4.Size = New System.Drawing.Size(62, 21)
        Me.txtS4.TabIndex = 210
        Me.txtS4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtS4.UseSystemPasswordChar = False
        '
        'otxt
        '
        Me.otxt.BackColor = System.Drawing.SystemColors.Control
        Me.otxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.otxt.Location = New System.Drawing.Point(126, 82)
        Me.otxt.MaxLength = 4
        Me.otxt.Multiline = False
        Me.otxt.Name = "otxt"
        Me.otxt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.otxt.ReadOnly = True
        Me.otxt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.otxt.SelectionStart = 0
        Me.otxt.Size = New System.Drawing.Size(283, 21)
        Me.otxt.TabIndex = 213
        Me.otxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.otxt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "Identifiant"
        '
        'pbLic
        '
        Me.pbLic.Location = New System.Drawing.Point(387, 110)
        Me.pbLic.Name = "pbLic"
        Me.pbLic.Size = New System.Drawing.Size(24, 22)
        Me.pbLic.TabIndex = 215
        Me.pbLic.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Titre_lbl)
        Me.Panel1.Controls.Add(Me.Save_ud)
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Controls.Add(Me.Licence_Text)
        Me.Panel1.Controls.Add(Me.pbLic)
        Me.Panel1.Controls.Add(Me.txtS1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtS2)
        Me.Panel1.Controls.Add(Me.otxt)
        Me.Panel1.Controls.Add(Me.txtS3)
        Me.Panel1.Controls.Add(Me.txtS4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(477, 192)
        Me.Panel1.TabIndex = 216
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(477, 31)
        Me.Titre_lbl.TabIndex = 218
        Me.Titre_lbl.Text = "Enregistrement"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Save_ud
        '
        Me.Save_ud.AutoSize = True
        Me.Save_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Save_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.BorderSize = 2
        Me.Save_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Save_ud.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_ud.Location = New System.Drawing.Point(356, 149)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(101, 33)
        Me.Save_ud.TabIndex = 216
        Me.Save_ud.Text = "Enregistrer"
        Me.Save_ud.ToolTip = ""
        '
        'Annuler_ud
        '
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.Location = New System.Drawing.Point(14, 149)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(101, 33)
        Me.Annuler_ud.TabIndex = 217
        Me.Annuler_ud.Text = "Annuler"
        Me.Annuler_ud.ToolTip = ""
        '
        'Zoom_Licencing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(481, 196)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Zoom_Licencing"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enregistrez votre licence"
        CType(Me.pbLic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Licence_Text As System.Windows.Forms.Label
    Friend WithEvents txtS1 As ud_TextBox
    Friend WithEvents txtS2 As ud_TextBox
    Friend WithEvents txtS3 As ud_TextBox
    Friend WithEvents txtS4 As ud_TextBox
    Friend WithEvents otxt As ud_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbLic As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Titre_lbl As Label
End Class
