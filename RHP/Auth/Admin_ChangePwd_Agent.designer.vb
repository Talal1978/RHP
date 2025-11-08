<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin_ChangePwd_Agent
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
        Me.Pwd2_Label = New System.Windows.Forms.Label()
        Me.Pwd1_Label = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Old_Pwd_User_Text = New RHP.ud_TextBox()
        Me.Pwd1_Text = New RHP.ud_TextBox()
        Me.Pwd2_Text = New RHP.ud_TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pwd2_Label
        '
        Me.Pwd2_Label.AutoSize = True
        Me.Pwd2_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Pwd2_Label.Location = New System.Drawing.Point(38, 134)
        Me.Pwd2_Label.Name = "Pwd2_Label"
        Me.Pwd2_Label.Size = New System.Drawing.Size(190, 19)
        Me.Pwd2_Label.TabIndex = 27
        Me.Pwd2_Label.Tag = "NC"
        Me.Pwd2_Label.Text = "Confirmer le  Mot de Passe"
        '
        'Pwd1_Label
        '
        Me.Pwd1_Label.AutoSize = True
        Me.Pwd1_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Pwd1_Label.Location = New System.Drawing.Point(61, 99)
        Me.Pwd1_Label.Name = "Pwd1_Label"
        Me.Pwd1_Label.Size = New System.Drawing.Size(168, 19)
        Me.Pwd1_Label.TabIndex = 28
        Me.Pwd1_Label.Tag = "NC"
        Me.Pwd1_Label.Text = "Nouveau Mot de Passe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(76, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 19)
        Me.Label1.TabIndex = 29
        Me.Label1.Tag = ""
        Me.Label1.Text = "Ancien Mot de Passe"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Titre_lbl)
        Me.Panel1.Controls.Add(Me.Save_ud)
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Controls.Add(Me.Old_Pwd_User_Text)
        Me.Panel1.Controls.Add(Me.Pwd1_Text)
        Me.Panel1.Controls.Add(Me.Pwd1_Label)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Pwd2_Label)
        Me.Panel1.Controls.Add(Me.Pwd2_Text)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(626, 232)
        Me.Panel1.TabIndex = 35
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(626, 39)
        Me.Titre_lbl.TabIndex = 32
        Me.Titre_lbl.Text = "Changer mon mot de passe"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Save_ud
        '
        Me.Save_ud.AutoSize = True
        Me.Save_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.bgColor = System.Drawing.Color.White
        Me.Save_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Save_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.BorderSize = 2
        Me.Save_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_ud.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_ud.isDefault = False
        Me.Save_ud.Location = New System.Drawing.Point(476, 171)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(23, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(138, 41)
        Me.Save_ud.TabIndex = 30
        Me.Save_ud.Text = "Enregistrer"
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
        Me.Annuler_ud.Location = New System.Drawing.Point(13, 171)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(23, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(138, 41)
        Me.Annuler_ud.TabIndex = 31
        Me.Annuler_ud.Text = "Annuler"
        '
        'Old_Pwd_User_Text
        '
        Me.Old_Pwd_User_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Old_Pwd_User_Text.ContextMenuStrip = Nothing
        Me.Old_Pwd_User_Text.Location = New System.Drawing.Point(261, 57)
        Me.Old_Pwd_User_Text.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Old_Pwd_User_Text.MaxLength = 32767
        Me.Old_Pwd_User_Text.Multiline = False
        Me.Old_Pwd_User_Text.Name = "Old_Pwd_User_Text"
        Me.Old_Pwd_User_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Old_Pwd_User_Text.PasswordChar = "*"
        Me.Old_Pwd_User_Text.ReadOnly = False
        Me.Old_Pwd_User_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Old_Pwd_User_Text.SelectionStart = 0
        Me.Old_Pwd_User_Text.Size = New System.Drawing.Size(330, 26)
        Me.Old_Pwd_User_Text.TabIndex = 0
        Me.Old_Pwd_User_Text.Tag = ""
        Me.Old_Pwd_User_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Old_Pwd_User_Text.UseSystemPasswordChar = False
        '
        'Pwd1_Text
        '
        Me.Pwd1_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Pwd1_Text.ContextMenuStrip = Nothing
        Me.Pwd1_Text.Location = New System.Drawing.Point(261, 94)
        Me.Pwd1_Text.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Pwd1_Text.MaxLength = 32767
        Me.Pwd1_Text.Multiline = False
        Me.Pwd1_Text.Name = "Pwd1_Text"
        Me.Pwd1_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Pwd1_Text.PasswordChar = "*"
        Me.Pwd1_Text.ReadOnly = False
        Me.Pwd1_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Pwd1_Text.SelectionStart = 0
        Me.Pwd1_Text.Size = New System.Drawing.Size(330, 26)
        Me.Pwd1_Text.TabIndex = 1
        Me.Pwd1_Text.Tag = ""
        Me.Pwd1_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Pwd1_Text.UseSystemPasswordChar = False
        '
        'Pwd2_Text
        '
        Me.Pwd2_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Pwd2_Text.ContextMenuStrip = Nothing
        Me.Pwd2_Text.Location = New System.Drawing.Point(261, 127)
        Me.Pwd2_Text.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Pwd2_Text.MaxLength = 32767
        Me.Pwd2_Text.Multiline = False
        Me.Pwd2_Text.Name = "Pwd2_Text"
        Me.Pwd2_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Pwd2_Text.PasswordChar = "*"
        Me.Pwd2_Text.ReadOnly = False
        Me.Pwd2_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Pwd2_Text.SelectionStart = 0
        Me.Pwd2_Text.Size = New System.Drawing.Size(330, 26)
        Me.Pwd2_Text.TabIndex = 2
        Me.Pwd2_Text.Tag = ""
        Me.Pwd2_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Pwd2_Text.UseSystemPasswordChar = False
        '
        'Admin_ChangePwd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(630, 236)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "Admin_ChangePwd_Agent"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.Text = "Changement de Mot de Passe"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pwd2_Text As ud_TextBox
    Friend WithEvents Pwd2_Label As System.Windows.Forms.Label
    Friend WithEvents Pwd1_Label As System.Windows.Forms.Label
    Friend WithEvents Pwd1_Text As ud_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Old_Pwd_User_Text As ud_TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Titre_lbl As Label
End Class
