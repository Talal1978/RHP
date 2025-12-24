<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ctb_Plan_Ctb
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
        Me.Cpt_Gnr_Text = New RHP.ud_TextBox()
        Me.CompteGeneralLink = New System.Windows.Forms.LinkLabel()
        Me.Itt_Cpt_Text = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Typ_Cpt_Combo = New RHP.ud_ComboBox()
        Me.Cpt_Red_Text = New RHP.ud_TextBox()
        Me.Cpt_Redlink = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Typ_Clf_Combo = New RHP.ud_ComboBox()
        Me.Sen_Naturel_Combo = New RHP.ud_ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Nat_Cpt_Combo = New RHP.ud_ComboBox()
        Me.Cpt_Eco_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cpt_Budget_txt = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cpt_Gnr_Text
        '
        Me.Cpt_Gnr_Text.AccessibleDescription = ""
        Me.Cpt_Gnr_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cpt_Gnr_Text.ContextMenuStrip = Nothing
        Me.Cpt_Gnr_Text.Location = New System.Drawing.Point(184, 76)
        Me.Cpt_Gnr_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cpt_Gnr_Text.MaxLength = 32767
        Me.Cpt_Gnr_Text.Multiline = False
        Me.Cpt_Gnr_Text.Name = "Cpt_Gnr_Text"
        Me.Cpt_Gnr_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cpt_Gnr_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cpt_Gnr_Text.ReadOnly = True
        Me.Cpt_Gnr_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cpt_Gnr_Text.SelectionStart = 0
        Me.Cpt_Gnr_Text.Size = New System.Drawing.Size(213, 21)
        Me.Cpt_Gnr_Text.TabIndex = 1
        Me.Cpt_Gnr_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cpt_Gnr_Text.UseSystemPasswordChar = False
        '
        'CompteGeneralLink
        '
        Me.CompteGeneralLink.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.AutoSize = True
        Me.CompteGeneralLink.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.Location = New System.Drawing.Point(46, 78)
        Me.CompteGeneralLink.Name = "CompteGeneralLink"
        Me.CompteGeneralLink.Size = New System.Drawing.Size(126, 19)
        Me.CompteGeneralLink.TabIndex = 0
        Me.CompteGeneralLink.TabStop = True
        Me.CompteGeneralLink.Tag = ""
        Me.CompteGeneralLink.Text = "Compte Général"
        '
        'Itt_Cpt_Text
        '
        Me.Itt_Cpt_Text.AccessibleDescription = "A"
        Me.Itt_Cpt_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Itt_Cpt_Text.ContextMenuStrip = Nothing
        Me.Itt_Cpt_Text.Location = New System.Drawing.Point(184, 106)
        Me.Itt_Cpt_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Itt_Cpt_Text.MaxLength = 100
        Me.Itt_Cpt_Text.Multiline = True
        Me.Itt_Cpt_Text.Name = "Itt_Cpt_Text"
        Me.Itt_Cpt_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Itt_Cpt_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Itt_Cpt_Text.ReadOnly = False
        Me.Itt_Cpt_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Itt_Cpt_Text.SelectionStart = 0
        Me.Itt_Cpt_Text.Size = New System.Drawing.Size(569, 58)
        Me.Itt_Cpt_Text.TabIndex = 2
        Me.Itt_Cpt_Text.Tag = "NC"
        Me.Itt_Cpt_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Itt_Cpt_Text.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Intitulé de Compte"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(47, 172)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(125, 19)
        Me.Label36.TabIndex = 57
        Me.Label36.Tag = ""
        Me.Label36.Text = "Type de Compte"
        '
        'Typ_Cpt_Combo
        '
        Me.Typ_Cpt_Combo.DataSource = Nothing
        Me.Typ_Cpt_Combo.DisplayMember = ""
        Me.Typ_Cpt_Combo.DroppedDown = False
        Me.Typ_Cpt_Combo.Location = New System.Drawing.Point(184, 172)
        Me.Typ_Cpt_Combo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Typ_Cpt_Combo.Name = "Typ_Cpt_Combo"
        Me.Typ_Cpt_Combo.SelectedIndex = -1
        Me.Typ_Cpt_Combo.SelectedItem = Nothing
        Me.Typ_Cpt_Combo.SelectedValue = Nothing
        Me.Typ_Cpt_Combo.Size = New System.Drawing.Size(213, 24)
        Me.Typ_Cpt_Combo.TabIndex = 3
        Me.Typ_Cpt_Combo.ValueMember = ""
        '
        'Cpt_Red_Text
        '
        Me.Cpt_Red_Text.AccessibleDescription = ""
        Me.Cpt_Red_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cpt_Red_Text.ContextMenuStrip = Nothing
        Me.Cpt_Red_Text.Location = New System.Drawing.Point(184, 204)
        Me.Cpt_Red_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cpt_Red_Text.MaxLength = 5
        Me.Cpt_Red_Text.Multiline = False
        Me.Cpt_Red_Text.Name = "Cpt_Red_Text"
        Me.Cpt_Red_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cpt_Red_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cpt_Red_Text.ReadOnly = False
        Me.Cpt_Red_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cpt_Red_Text.SelectionStart = 0
        Me.Cpt_Red_Text.Size = New System.Drawing.Size(213, 21)
        Me.Cpt_Red_Text.TabIndex = 4
        Me.Cpt_Red_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cpt_Red_Text.UseSystemPasswordChar = False
        '
        'Cpt_Redlink
        '
        Me.Cpt_Redlink.AutoSize = True
        Me.Cpt_Redlink.Location = New System.Drawing.Point(65, 202)
        Me.Cpt_Redlink.Name = "Cpt_Redlink"
        Me.Cpt_Redlink.Size = New System.Drawing.Size(115, 19)
        Me.Cpt_Redlink.TabIndex = 57
        Me.Cpt_Redlink.Tag = ""
        Me.Cpt_Redlink.Text = "Compte Réduit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 307)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 19)
        Me.Label3.TabIndex = 60
        Me.Label3.Tag = ""
        Me.Label3.Text = "Type Collectif"
        '
        'Typ_Clf_Combo
        '
        Me.Typ_Clf_Combo.DataSource = Nothing
        Me.Typ_Clf_Combo.DisplayMember = ""
        Me.Typ_Clf_Combo.DroppedDown = False
        Me.Typ_Clf_Combo.Location = New System.Drawing.Point(184, 304)
        Me.Typ_Clf_Combo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Typ_Clf_Combo.Name = "Typ_Clf_Combo"
        Me.Typ_Clf_Combo.SelectedIndex = -1
        Me.Typ_Clf_Combo.SelectedItem = Nothing
        Me.Typ_Clf_Combo.SelectedValue = Nothing
        Me.Typ_Clf_Combo.Size = New System.Drawing.Size(213, 24)
        Me.Typ_Clf_Combo.TabIndex = 5
        Me.Typ_Clf_Combo.ValueMember = ""
        '
        'Sen_Naturel_Combo
        '
        Me.Sen_Naturel_Combo.DataSource = Nothing
        Me.Sen_Naturel_Combo.DisplayMember = ""
        Me.Sen_Naturel_Combo.DroppedDown = False
        Me.Sen_Naturel_Combo.Location = New System.Drawing.Point(184, 332)
        Me.Sen_Naturel_Combo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Sen_Naturel_Combo.Name = "Sen_Naturel_Combo"
        Me.Sen_Naturel_Combo.SelectedIndex = -1
        Me.Sen_Naturel_Combo.SelectedItem = Nothing
        Me.Sen_Naturel_Combo.SelectedValue = Nothing
        Me.Sen_Naturel_Combo.Size = New System.Drawing.Size(213, 24)
        Me.Sen_Naturel_Combo.TabIndex = 6
        Me.Sen_Naturel_Combo.ValueMember = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(86, 334)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 19)
        Me.Label4.TabIndex = 60
        Me.Label4.Tag = ""
        Me.Label4.Text = "Sens Naturel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cpt_Budget_txt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Cpt_Eco_txt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Nat_Cpt_Combo)
        Me.GroupBox1.Controls.Add(Me.Itt_Cpt_Text)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CompteGeneralLink)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Cpt_Gnr_Text)
        Me.GroupBox1.Controls.Add(Me.Sen_Naturel_Combo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Typ_Clf_Combo)
        Me.GroupBox1.Controls.Add(Me.Typ_Cpt_Combo)
        Me.GroupBox1.Controls.Add(Me.Cpt_Red_Text)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Cpt_Redlink)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1091, 684)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "SC"
        Me.GroupBox1.Text = "Compte Général"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 364)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 19)
        Me.Label7.TabIndex = 208
        Me.Label7.Tag = ""
        Me.Label7.Text = "Nature de Compte"
        '
        'Nat_Cpt_Combo
        '
        Me.Nat_Cpt_Combo.DataSource = Nothing
        Me.Nat_Cpt_Combo.DisplayMember = ""
        Me.Nat_Cpt_Combo.DroppedDown = False
        Me.Nat_Cpt_Combo.Location = New System.Drawing.Point(184, 362)
        Me.Nat_Cpt_Combo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nat_Cpt_Combo.Name = "Nat_Cpt_Combo"
        Me.Nat_Cpt_Combo.SelectedIndex = -1
        Me.Nat_Cpt_Combo.SelectedItem = Nothing
        Me.Nat_Cpt_Combo.SelectedValue = Nothing
        Me.Nat_Cpt_Combo.Size = New System.Drawing.Size(213, 24)
        Me.Nat_Cpt_Combo.TabIndex = 7
        Me.Nat_Cpt_Combo.ValueMember = ""
        '
        'Cpt_Eco_txt
        '
        Me.Cpt_Eco_txt.AccessibleDescription = ""
        Me.Cpt_Eco_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cpt_Eco_txt.ContextMenuStrip = Nothing
        Me.Cpt_Eco_txt.Location = New System.Drawing.Point(184, 234)
        Me.Cpt_Eco_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cpt_Eco_txt.MaxLength = 5
        Me.Cpt_Eco_txt.Multiline = False
        Me.Cpt_Eco_txt.Name = "Cpt_Eco_txt"
        Me.Cpt_Eco_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cpt_Eco_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cpt_Eco_txt.ReadOnly = False
        Me.Cpt_Eco_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cpt_Eco_txt.SelectionStart = 0
        Me.Cpt_Eco_txt.Size = New System.Drawing.Size(213, 25)
        Me.Cpt_Eco_txt.TabIndex = 209
        Me.Cpt_Eco_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cpt_Eco_txt.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 19)
        Me.Label2.TabIndex = 210
        Me.Label2.Tag = ""
        Me.Label2.Text = "Compte économique"
        '
        'Cpt_Budget_txt
        '
        Me.Cpt_Budget_txt.AccessibleDescription = ""
        Me.Cpt_Budget_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cpt_Budget_txt.ContextMenuStrip = Nothing
        Me.Cpt_Budget_txt.Location = New System.Drawing.Point(184, 267)
        Me.Cpt_Budget_txt.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Cpt_Budget_txt.MaxLength = 5
        Me.Cpt_Budget_txt.Multiline = False
        Me.Cpt_Budget_txt.Name = "Cpt_Budget_txt"
        Me.Cpt_Budget_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cpt_Budget_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cpt_Budget_txt.ReadOnly = False
        Me.Cpt_Budget_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cpt_Budget_txt.SelectionStart = 0
        Me.Cpt_Budget_txt.Size = New System.Drawing.Size(213, 30)
        Me.Cpt_Budget_txt.TabIndex = 211
        Me.Cpt_Budget_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cpt_Budget_txt.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 272)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 19)
        Me.Label5.TabIndex = 212
        Me.Label5.Tag = ""
        Me.Label5.Text = "Compte budétaire"
        '
        'Ctb_Plan_Ctb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1091, 684)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Ctb_Plan_Ctb"
        Me.Tag = "ECR"
        Me.Text = "Plan comptable"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cpt_Gnr_Text As ud_TextBox
    Friend WithEvents CompteGeneralLink As System.Windows.Forms.LinkLabel
    Friend WithEvents Itt_Cpt_Text As ud_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Typ_Cpt_Combo As ud_ComboBox
    Friend WithEvents Cpt_Red_Text As ud_TextBox
    Friend WithEvents Cpt_Redlink As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Typ_Clf_Combo As ud_ComboBox
    Friend WithEvents Sen_Naturel_Combo As ud_ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Nat_Cpt_Combo As ud_ComboBox
    Friend WithEvents Cpt_Eco_txt As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Cpt_Budget_txt As ud_TextBox
    Friend WithEvents Label5 As Label
End Class
