<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Agent_Suppleant
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
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Suppleant_txt = New RHP.ud_TextBox()
        Me.Nom_Suppleant_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Notify_chk = New RHP.ud_CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.submitAcceptation_chk = New RHP.ud_CheckBox()
        Me.Designated_By_txt = New RHP.ud_TextBox()
        Me.Nom_Designated_By_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Accepted_chk = New RHP.ud_CheckBox()
        Me.Notified_chk = New RHP.ud_CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Suppleant_Au_txt = New RHP.ud_TextBox()
        Me.Suppleant_Du_txt = New RHP.ud_TextBox()
        Me.Accept_ud = New RHP.ud_button()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(114, 81)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(151, 26)
        Me.Matricule_txt.TabIndex = 227
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(268, 81)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = False
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(531, 26)
        Me.Nom_Agent_Text.TabIndex = 229
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(31, 84)
        Me.Matricule_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(78, 19)
        Me.Matricule_.TabIndex = 228
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Signataire"
        '
        'Suppleant_txt
        '
        Me.Suppleant_txt.AccessibleDescription = "A"
        Me.Suppleant_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Suppleant_txt.ContextMenuStrip = Nothing
        Me.Suppleant_txt.Location = New System.Drawing.Point(114, 112)
        Me.Suppleant_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Suppleant_txt.MaxLength = 32767
        Me.Suppleant_txt.Multiline = False
        Me.Suppleant_txt.Name = "Suppleant_txt"
        Me.Suppleant_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Suppleant_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Suppleant_txt.ReadOnly = True
        Me.Suppleant_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Suppleant_txt.SelectionStart = 0
        Me.Suppleant_txt.Size = New System.Drawing.Size(151, 26)
        Me.Suppleant_txt.TabIndex = 230
        Me.Suppleant_txt.TabStop = False
        Me.Suppleant_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Suppleant_txt.UseSystemPasswordChar = False
        '
        'Nom_Suppleant_txt
        '
        Me.Nom_Suppleant_txt.AccessibleDescription = "A"
        Me.Nom_Suppleant_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Suppleant_txt.ContextMenuStrip = Nothing
        Me.Nom_Suppleant_txt.Location = New System.Drawing.Point(268, 112)
        Me.Nom_Suppleant_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_Suppleant_txt.MaxLength = 32767
        Me.Nom_Suppleant_txt.Multiline = False
        Me.Nom_Suppleant_txt.Name = "Nom_Suppleant_txt"
        Me.Nom_Suppleant_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Suppleant_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Suppleant_txt.ReadOnly = False
        Me.Nom_Suppleant_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Suppleant_txt.SelectionStart = 0
        Me.Nom_Suppleant_txt.Size = New System.Drawing.Size(531, 26)
        Me.Nom_Suppleant_txt.TabIndex = 232
        Me.Nom_Suppleant_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Suppleant_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(28, 116)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(81, 19)
        Me.LinkLabel1.TabIndex = 231
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "SC"
        Me.LinkLabel1.Text = "Suppléant"
        '
        'Notify_chk
        '
        Me.Notify_chk.AutoSize = True
        Me.Notify_chk.Checked = True
        Me.Notify_chk.Location = New System.Drawing.Point(114, 174)
        Me.Notify_chk.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Notify_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Notify_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Notify_chk.Name = "Notify_chk"
        Me.Notify_chk.Size = New System.Drawing.Size(145, 25)
        Me.Notify_chk.TabIndex = 233
        Me.Notify_chk.Text = "Informer par mail"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(509, 19)
        Me.Label1.TabIndex = 234
        Me.Label1.Text = "Le suppléant est un agent qui remplace le signataire en cas d'absence. "
        '
        'submitAcceptation_chk
        '
        Me.submitAcceptation_chk.AutoSize = True
        Me.submitAcceptation_chk.Checked = True
        Me.submitAcceptation_chk.Location = New System.Drawing.Point(114, 146)
        Me.submitAcceptation_chk.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.submitAcceptation_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.submitAcceptation_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.submitAcceptation_chk.Name = "submitAcceptation_chk"
        Me.submitAcceptation_chk.Size = New System.Drawing.Size(303, 25)
        Me.submitAcceptation_chk.TabIndex = 233
        Me.submitAcceptation_chk.Text = "Soumettre à acceptation du signataire."
        '
        'Designated_By_txt
        '
        Me.Designated_By_txt.AccessibleDescription = "A"
        Me.Designated_By_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Designated_By_txt.ContextMenuStrip = Nothing
        Me.Designated_By_txt.Location = New System.Drawing.Point(114, 218)
        Me.Designated_By_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Designated_By_txt.MaxLength = 32767
        Me.Designated_By_txt.Multiline = False
        Me.Designated_By_txt.Name = "Designated_By_txt"
        Me.Designated_By_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Designated_By_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Designated_By_txt.ReadOnly = True
        Me.Designated_By_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Designated_By_txt.SelectionStart = 0
        Me.Designated_By_txt.Size = New System.Drawing.Size(151, 26)
        Me.Designated_By_txt.TabIndex = 235
        Me.Designated_By_txt.TabStop = False
        Me.Designated_By_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Designated_By_txt.UseSystemPasswordChar = False
        '
        'Nom_Designated_By_txt
        '
        Me.Nom_Designated_By_txt.AccessibleDescription = "A"
        Me.Nom_Designated_By_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Designated_By_txt.ContextMenuStrip = Nothing
        Me.Nom_Designated_By_txt.Location = New System.Drawing.Point(268, 218)
        Me.Nom_Designated_By_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_Designated_By_txt.MaxLength = 32767
        Me.Nom_Designated_By_txt.Multiline = False
        Me.Nom_Designated_By_txt.Name = "Nom_Designated_By_txt"
        Me.Nom_Designated_By_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Designated_By_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Designated_By_txt.ReadOnly = False
        Me.Nom_Designated_By_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Designated_By_txt.SelectionStart = 0
        Me.Nom_Designated_By_txt.Size = New System.Drawing.Size(531, 26)
        Me.Nom_Designated_By_txt.TabIndex = 237
        Me.Nom_Designated_By_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Designated_By_txt.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 220)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 19)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Désignés par"
        '
        'Accepted_chk
        '
        Me.Accepted_chk.AutoSize = True
        Me.Accepted_chk.Checked = True
        Me.Accepted_chk.Enabled = False
        Me.Accepted_chk.Location = New System.Drawing.Point(674, 146)
        Me.Accepted_chk.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Accepted_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Accepted_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Accepted_chk.Name = "Accepted_chk"
        Me.Accepted_chk.Size = New System.Drawing.Size(125, 25)
        Me.Accepted_chk.TabIndex = 233
        Me.Accepted_chk.Text = "Accepté"
        '
        'Notified_chk
        '
        Me.Notified_chk.AutoSize = True
        Me.Notified_chk.Checked = True
        Me.Notified_chk.Enabled = False
        Me.Notified_chk.Location = New System.Drawing.Point(674, 174)
        Me.Notified_chk.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Notified_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Notified_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Notified_chk.Name = "Notified_chk"
        Me.Notified_chk.Size = New System.Drawing.Size(125, 25)
        Me.Notified_chk.TabIndex = 233
        Me.Notified_chk.Text = "Notifié"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LinkLabel6)
        Me.Panel1.Controls.Add(Me.LinkLabel4)
        Me.Panel1.Controls.Add(Me.Suppleant_Au_txt)
        Me.Panel1.Controls.Add(Me.Suppleant_Du_txt)
        Me.Panel1.Controls.Add(Me.Accept_ud)
        Me.Panel1.Controls.Add(Me.Save_ud)
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Matricule_)
        Me.Panel1.Controls.Add(Me.Designated_By_txt)
        Me.Panel1.Controls.Add(Me.Nom_Agent_Text)
        Me.Panel1.Controls.Add(Me.Nom_Designated_By_txt)
        Me.Panel1.Controls.Add(Me.Matricule_txt)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Notified_chk)
        Me.Panel1.Controls.Add(Me.Nom_Suppleant_txt)
        Me.Panel1.Controls.Add(Me.Accepted_chk)
        Me.Panel1.Controls.Add(Me.Suppleant_txt)
        Me.Panel1.Controls.Add(Me.submitAcceptation_chk)
        Me.Panel1.Controls.Add(Me.Notify_chk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(824, 402)
        Me.Panel1.TabIndex = 239
        '
        'LinkLabel6
        '
        Me.LinkLabel6.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.Location = New System.Drawing.Point(308, 254)
        Me.LinkLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(27, 19)
        Me.LinkLabel6.TabIndex = 242
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Tag = ""
        Me.LinkLabel6.Text = "Au"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(81, 254)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(28, 19)
        Me.LinkLabel4.TabIndex = 241
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = ""
        Me.LinkLabel4.Text = "Du"
        '
        'Suppleant_Au_txt
        '
        Me.Suppleant_Au_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Suppleant_Au_txt.ContextMenuStrip = Nothing
        Me.Suppleant_Au_txt.Location = New System.Drawing.Point(339, 251)
        Me.Suppleant_Au_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Suppleant_Au_txt.MaxLength = 32767
        Me.Suppleant_Au_txt.Multiline = False
        Me.Suppleant_Au_txt.Name = "Suppleant_Au_txt"
        Me.Suppleant_Au_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Suppleant_Au_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Suppleant_Au_txt.ReadOnly = True
        Me.Suppleant_Au_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Suppleant_Au_txt.SelectionStart = 0
        Me.Suppleant_Au_txt.Size = New System.Drawing.Size(151, 26)
        Me.Suppleant_Au_txt.TabIndex = 243
        Me.Suppleant_Au_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Suppleant_Au_txt.UseSystemPasswordChar = False
        '
        'Suppleant_Du_txt
        '
        Me.Suppleant_Du_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Suppleant_Du_txt.ContextMenuStrip = Nothing
        Me.Suppleant_Du_txt.Location = New System.Drawing.Point(114, 251)
        Me.Suppleant_Du_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Suppleant_Du_txt.MaxLength = 32767
        Me.Suppleant_Du_txt.Multiline = False
        Me.Suppleant_Du_txt.Name = "Suppleant_Du_txt"
        Me.Suppleant_Du_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Suppleant_Du_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Suppleant_Du_txt.ReadOnly = True
        Me.Suppleant_Du_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Suppleant_Du_txt.SelectionStart = 0
        Me.Suppleant_Du_txt.Size = New System.Drawing.Size(151, 26)
        Me.Suppleant_Du_txt.TabIndex = 244
        Me.Suppleant_Du_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Suppleant_Du_txt.UseSystemPasswordChar = False
        '
        'Accept_ud
        '
        Me.Accept_ud.AutoSize = True
        Me.Accept_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Accept_ud.bgColor = System.Drawing.Color.White
        Me.Accept_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Accept_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Accept_ud.BorderSize = 2
        Me.Accept_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Accept_ud.Enabled = False
        Me.Accept_ud.Image = Global.RHP.My.Resources.Resources.btn_sign
        Me.Accept_ud.isDefault = False
        Me.Accept_ud.Location = New System.Drawing.Point(541, 338)
        Me.Accept_ud.Margin = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.Accept_ud.MinimumSize = New System.Drawing.Size(39, 39)
        Me.Accept_ud.Name = "Accept_ud"
        Me.Accept_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Accept_ud.Size = New System.Drawing.Size(125, 41)
        Me.Accept_ud.TabIndex = 239
        Me.Accept_ud.Text = "Accepter"
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
        Me.Save_ud.Enabled = False
        Me.Save_ud.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_ud.isDefault = False
        Me.Save_ud.Location = New System.Drawing.Point(674, 338)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(34, 39)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(125, 41)
        Me.Save_ud.TabIndex = 239
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
        Me.Annuler_ud.Location = New System.Drawing.Point(18, 338)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(34, 39)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(125, 41)
        Me.Annuler_ud.TabIndex = 240
        Me.Annuler_ud.Text = "Annuler"
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(2, 2)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(824, 39)
        Me.Titre_lbl.TabIndex = 240
        Me.Titre_lbl.Text = "Désigner un suppléant"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Agent_Suppleant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(828, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.Titre_lbl)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Agent_Suppleant"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Désigner un suppléant"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Suppleant_txt As ud_TextBox
    Friend WithEvents Nom_Suppleant_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Notify_chk As ud_CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents submitAcceptation_chk As ud_CheckBox
    Friend WithEvents Designated_By_txt As ud_TextBox
    Friend WithEvents Nom_Designated_By_txt As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Accepted_chk As ud_CheckBox
    Friend WithEvents Notified_chk As ud_CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Accept_ud As ud_button
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Suppleant_Au_txt As ud_TextBox
    Friend WithEvents Suppleant_Du_txt As ud_TextBox
End Class
