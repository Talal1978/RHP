<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Org_Organigramme_Affectation
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
        Me.Parent_txt = New RHP.ud_TextBox()
        Me.Lib_Parent_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_Text = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Typ_Entite_cbo = New RHP.ud_ComboBox()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Parent_txt
        '
        Me.Parent_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Parent_txt.ContextMenuStrip = Nothing
        Me.Parent_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Parent_txt.Location = New System.Drawing.Point(158, 24)
        Me.Parent_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Parent_txt.MaxLength = 32767
        Me.Parent_txt.Multiline = False
        Me.Parent_txt.Name = "Parent_txt"
        Me.Parent_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Parent_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Parent_txt.ReadOnly = True
        Me.Parent_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Parent_txt.SelectionStart = 0
        Me.Parent_txt.Size = New System.Drawing.Size(130, 26)
        Me.Parent_txt.TabIndex = 0
        Me.Parent_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Parent_txt.UseSystemPasswordChar = False
        '
        'Lib_Parent_txt
        '
        Me.Lib_Parent_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Parent_txt.ContextMenuStrip = Nothing
        Me.Lib_Parent_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Parent_txt.Location = New System.Drawing.Point(290, 24)
        Me.Lib_Parent_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Parent_txt.MaxLength = 32767
        Me.Lib_Parent_txt.Multiline = False
        Me.Lib_Parent_txt.Name = "Lib_Parent_txt"
        Me.Lib_Parent_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Parent_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Parent_txt.ReadOnly = True
        Me.Lib_Parent_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Parent_txt.SelectionStart = 0
        Me.Lib_Parent_txt.Size = New System.Drawing.Size(374, 26)
        Me.Lib_Parent_txt.TabIndex = 0
        Me.Lib_Parent_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Parent_txt.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(64, 92)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Type entité"
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(158, 56)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Entite_txt.MaxLength = 32767
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = False
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(130, 26)
        Me.Cod_Entite_txt.TabIndex = 2
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(290, 56)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Entite_txt.MaxLength = 32767
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = False
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(374, 26)
        Me.Lib_Entite_txt.TabIndex = 3
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(95, 60)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Entité"
        '
        'Matricule_
        '
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(72, 129)
        Me.Matricule_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 204
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = ""
        Me.Matricule_.Text = "Matricule"
        '
        'Matricule_Text
        '
        Me.Matricule_Text.AccessibleDescription = "A"
        Me.Matricule_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_Text.ContextMenuStrip = Nothing
        Me.Matricule_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_Text.Location = New System.Drawing.Point(158, 124)
        Me.Matricule_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Matricule_Text.MaxLength = 32767
        Me.Matricule_Text.Multiline = False
        Me.Matricule_Text.Name = "Matricule_Text"
        Me.Matricule_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_Text.ReadOnly = True
        Me.Matricule_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_Text.SelectionStart = 0
        Me.Matricule_Text.Size = New System.Drawing.Size(130, 26)
        Me.Matricule_Text.TabIndex = 5
        Me.Matricule_Text.TabStop = False
        Me.Matricule_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_Text.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(290, 124)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(374, 26)
        Me.Nom_Agent_Text.TabIndex = 205
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(11, 28)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(140, 19)
        Me.LinkLabel1.TabIndex = 204
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Entité hiérarchique"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Typ_Entite_cbo)
        Me.Panel1.Controls.Add(Me.Save_ud)
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Controls.Add(Me.Parent_txt)
        Me.Panel1.Controls.Add(Me.Lib_Parent_txt)
        Me.Panel1.Controls.Add(Me.Cod_Entite_txt)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Lib_Entite_txt)
        Me.Panel1.Controls.Add(Me.Matricule_)
        Me.Panel1.Controls.Add(Me.Matricule_Text)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Nom_Agent_Text)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 41)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(675, 245)
        Me.Panel1.TabIndex = 208
        '
        'Typ_Entite_cbo
        '
        Me.Typ_Entite_cbo.DataSource = Nothing
        Me.Typ_Entite_cbo.DisplayMember = ""
        Me.Typ_Entite_cbo.DroppedDown = False
        Me.Typ_Entite_cbo.Location = New System.Drawing.Point(158, 88)
        Me.Typ_Entite_cbo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Typ_Entite_cbo.Name = "Typ_Entite_cbo"
        Me.Typ_Entite_cbo.SelectedIndex = -1
        Me.Typ_Entite_cbo.SelectedItem = Nothing
        Me.Typ_Entite_cbo.SelectedValue = Nothing
        Me.Typ_Entite_cbo.Size = New System.Drawing.Size(506, 31)
        Me.Typ_Entite_cbo.TabIndex = 210
        Me.Typ_Entite_cbo.ValueMember = ""
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
        Me.Save_ud.Location = New System.Drawing.Point(539, 179)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(29, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(125, 41)
        Me.Save_ud.TabIndex = 208
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
        Me.Annuler_ud.Location = New System.Drawing.Point(18, 179)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(29, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(125, 41)
        Me.Annuler_ud.TabIndex = 209
        Me.Annuler_ud.Text = "Annuler"
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(2, 2)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(675, 39)
        Me.Titre_lbl.TabIndex = 209
        Me.Titre_lbl.Text = "Ajouter une entité"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Zoom_Org_Organigramme_Affectation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(679, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Titre_lbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_Org_Organigramme_Affectation"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajouter une entité"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Parent_txt As ud_TextBox
    Friend WithEvents Lib_Parent_txt As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_Text As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Typ_Entite_cbo As ud_ComboBox
End Class
