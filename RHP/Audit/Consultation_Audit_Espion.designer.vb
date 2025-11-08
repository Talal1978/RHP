<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Consultation_Audit_Espion
    Inherits Ecran

    'Form rEmplace la méthode dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            end If
        finally
            MyBase.Dispose(disposing)
        end Try
    end Sub

    'Requise par le concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le concepteur Windows Form
    'Elle peut être modifiée à l'aide du concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Nom_User_Text = New RHP.ud_TextBox()
        Me.User_Text = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Fin = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Dat_Deb = New System.Windows.Forms.DateTimePicker()
        Me.Cod_Audit_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DEL_chk = New RHP.ud_CheckBox()
        Me.INS_chk = New RHP.ud_CheckBox()
        Me.UPD_chk = New RHP.ud_CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Champs_Table_Text = New RHP.ud_TextBox()
        Me.table_Name_Text = New RHP.ud_TextBox()
        Me.Audit_Grd = New RHP.ud_Grd()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Audit_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Nom_User_Text)
        Me.GroupBox1.Controls.Add(Me.User_Text)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.LinkLabel4)
        Me.GroupBox1.Controls.Add(Me.Dat_Fin)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Dat_Deb)
        Me.GroupBox1.Controls.Add(Me.Cod_Audit_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Champs_Table_Text)
        Me.GroupBox1.Controls.Add(Me.table_Name_Text)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1418, 135)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = ""
        '
        'Nom_User_Text
        '
        Me.Nom_User_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_User_Text.ContextMenuStrip = Nothing
        Me.Nom_User_Text.Location = New System.Drawing.Point(995, 90)
        Me.Nom_User_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_User_Text.MaxLength = 10
        Me.Nom_User_Text.Multiline = False
        Me.Nom_User_Text.Name = "Nom_User_Text"
        Me.Nom_User_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_User_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_User_Text.ReadOnly = True
        Me.Nom_User_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_User_Text.SelectionStart = 0
        Me.Nom_User_Text.Size = New System.Drawing.Size(381, 26)
        Me.Nom_User_Text.TabIndex = 207
        Me.Nom_User_Text.Tag = ""
        Me.Nom_User_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_User_Text.UseSystemPasswordChar = False
        '
        'User_Text
        '
        Me.User_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.User_Text.ContextMenuStrip = Nothing
        Me.User_Text.Location = New System.Drawing.Point(865, 90)
        Me.User_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.User_Text.MaxLength = 10
        Me.User_Text.Multiline = False
        Me.User_Text.Name = "User_Text"
        Me.User_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.User_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.User_Text.ReadOnly = True
        Me.User_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.User_Text.SelectionStart = 0
        Me.User_Text.Size = New System.Drawing.Size(126, 26)
        Me.User_Text.TabIndex = 206
        Me.User_Text.Tag = ""
        Me.User_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.User_Text.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(30, 85)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(135, 19)
        Me.LinkLabel2.TabIndex = 249
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = ""
        Me.LinkLabel2.Text = "Champs à auditer"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4.Location = New System.Drawing.Point(780, 93)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(82, 19)
        Me.LinkLabel4.TabIndex = 205
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = ""
        Me.LinkLabel4.Text = "Utilisateur :"
        '
        'Dat_Fin
        '
        Me.Dat_Fin.Location = New System.Drawing.Point(866, 51)
        Me.Dat_Fin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dat_Fin.Name = "Dat_Fin"
        Me.Dat_Fin.Size = New System.Drawing.Size(235, 24)
        Me.Dat_Fin.TabIndex = 245
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(834, 55)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 19)
        Me.Label7.TabIndex = 247
        Me.Label7.Text = "au"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(834, 24)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 19)
        Me.Label8.TabIndex = 246
        Me.Label8.Text = "Du"
        '
        'Dat_Deb
        '
        Me.Dat_Deb.Location = New System.Drawing.Point(866, 21)
        Me.Dat_Deb.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dat_Deb.Name = "Dat_Deb"
        Me.Dat_Deb.Size = New System.Drawing.Size(235, 24)
        Me.Dat_Deb.TabIndex = 248
        '
        'Cod_Audit_txt
        '
        Me.Cod_Audit_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Audit_txt.ContextMenuStrip = Nothing
        Me.Cod_Audit_txt.Enabled = False
        Me.Cod_Audit_txt.Location = New System.Drawing.Point(166, 21)
        Me.Cod_Audit_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Audit_txt.MaxLength = 10
        Me.Cod_Audit_txt.Multiline = False
        Me.Cod_Audit_txt.Name = "Cod_Audit_txt"
        Me.Cod_Audit_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Audit_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Audit_txt.ReadOnly = True
        Me.Cod_Audit_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Audit_txt.SelectionStart = 0
        Me.Cod_Audit_txt.Size = New System.Drawing.Size(390, 26)
        Me.Cod_Audit_txt.TabIndex = 209
        Me.Cod_Audit_txt.Tag = ""
        Me.Cod_Audit_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Audit_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(60, 24)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(102, 19)
        Me.LinkLabel1.TabIndex = 208
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Code d'audit"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DEL_chk)
        Me.GroupBox2.Controls.Add(Me.INS_chk)
        Me.GroupBox2.Controls.Add(Me.UPD_chk)
        Me.GroupBox2.Location = New System.Drawing.Point(566, 11)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(200, 115)
        Me.GroupBox2.TabIndex = 207
        Me.GroupBox2.TabStop = False
        '
        'DEL_chk
        '
        Me.DEL_chk.AutoSize = True
        Me.DEL_chk.Checked = True
        Me.DEL_chk.Location = New System.Drawing.Point(18, 79)
        Me.DEL_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DEL_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.DEL_chk.MinimumSize = New System.Drawing.Size(166, 31)
        Me.DEL_chk.Name = "DEL_chk"
        Me.DEL_chk.Size = New System.Drawing.Size(166, 31)
        Me.DEL_chk.TabIndex = 0
        Me.DEL_chk.Text = "Suppression"
        '
        'INS_chk
        '
        Me.INS_chk.AutoSize = True
        Me.INS_chk.Checked = True
        Me.INS_chk.Location = New System.Drawing.Point(18, 49)
        Me.INS_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.INS_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.INS_chk.MinimumSize = New System.Drawing.Size(166, 31)
        Me.INS_chk.Name = "INS_chk"
        Me.INS_chk.Size = New System.Drawing.Size(166, 31)
        Me.INS_chk.TabIndex = 0
        Me.INS_chk.Text = "Ajout"
        '
        'UPD_chk
        '
        Me.UPD_chk.AutoSize = True
        Me.UPD_chk.Checked = True
        Me.UPD_chk.Location = New System.Drawing.Point(18, 19)
        Me.UPD_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UPD_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.UPD_chk.MinimumSize = New System.Drawing.Size(166, 31)
        Me.UPD_chk.Name = "UPD_chk"
        Me.UPD_chk.Size = New System.Drawing.Size(166, 31)
        Me.UPD_chk.TabIndex = 0
        Me.UPD_chk.Text = "Modification"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 19)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "Nom de la table"
        '
        'Champs_Table_Text
        '
        Me.Champs_Table_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Champs_Table_Text.ContextMenuStrip = Nothing
        Me.Champs_Table_Text.Enabled = False
        Me.Champs_Table_Text.Location = New System.Drawing.Point(166, 81)
        Me.Champs_Table_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Champs_Table_Text.MaxLength = 32767
        Me.Champs_Table_Text.Multiline = False
        Me.Champs_Table_Text.Name = "Champs_Table_Text"
        Me.Champs_Table_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Champs_Table_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Champs_Table_Text.ReadOnly = True
        Me.Champs_Table_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Champs_Table_Text.SelectionStart = 0
        Me.Champs_Table_Text.Size = New System.Drawing.Size(390, 26)
        Me.Champs_Table_Text.TabIndex = 203
        Me.Champs_Table_Text.Tag = ""
        Me.Champs_Table_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Champs_Table_Text.UseSystemPasswordChar = False
        '
        'table_Name_Text
        '
        Me.table_Name_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.table_Name_Text.ContextMenuStrip = Nothing
        Me.table_Name_Text.Enabled = False
        Me.table_Name_Text.Location = New System.Drawing.Point(166, 51)
        Me.table_Name_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.table_Name_Text.MaxLength = 10
        Me.table_Name_Text.Multiline = False
        Me.table_Name_Text.Name = "table_Name_Text"
        Me.table_Name_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.table_Name_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.table_Name_Text.ReadOnly = True
        Me.table_Name_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.table_Name_Text.SelectionStart = 0
        Me.table_Name_Text.Size = New System.Drawing.Size(390, 26)
        Me.table_Name_Text.TabIndex = 204
        Me.table_Name_Text.Tag = ""
        Me.table_Name_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.table_Name_Text.UseSystemPasswordChar = False
        '
        Me.Audit_Grd.AfficherLesEntetesLignes = True
        Me.Audit_Grd.AllowUserToAddRows = False
        Me.Audit_Grd.AllowUserToDeleteRows = False
        Me.Audit_Grd.AllowUserToResizeRows = False
        Me.Audit_Grd.AlternerLesLignes = False
        Me.Audit_Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Audit_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Audit_Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Audit_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Audit_Grd.ColumnHeadersHeight = 50
        Me.Audit_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Audit_Grd.EnableHeadersVisualStyles = False
        Me.Audit_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Audit_Grd.Location = New System.Drawing.Point(0, 135)
        Me.Audit_Grd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Audit_Grd.Name = "Audit_Grd"
        Me.Audit_Grd.ReadOnly = True
        Me.Audit_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Audit_Grd.RowHeadersWidth = 51
        Me.Audit_Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Audit_Grd.Size = New System.Drawing.Size(1418, 630)
        Me.Audit_Grd.TabIndex = 2
        '
        'Consultation_Audit_Espion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1418, 765)
        Me.Controls.Add(Me.Audit_Grd)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Consultation_Audit_Espion"
        Me.Tag = "ECR"
        Me.Text = "Consultation du journal d'audit"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Audit_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Champs_Table_Text As ud_TextBox
    Friend WithEvents table_Name_Text As ud_TextBox
    Friend WithEvents Audit_Grd As ud_Grd
    Friend WithEvents Cod_Audit_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DEL_chk As ud_CheckBox
    Friend WithEvents INS_chk As ud_CheckBox
    Friend WithEvents UPD_chk As ud_CheckBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Dat_Fin As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Dat_Deb As DateTimePicker
    Friend WithEvents Nom_User_Text As ud_TextBox
    Friend WithEvents User_Text As ud_TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
End Class
