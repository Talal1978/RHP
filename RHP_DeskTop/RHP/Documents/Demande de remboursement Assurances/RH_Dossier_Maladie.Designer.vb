<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Dossier_Maladie
    inherits Ecran

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
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.remboursement_Grp = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Mnt_Remboursement_txt = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.Pourcentage_txt = New RHP.ud_TextBox()
        Me.Rembourse_Le_txt = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Envoye_Le_txt = New RHP.ud_TextBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Num_Dossier_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Medecin_txt = New RHP.ud_TextBox()
        Me.Typ_Maladie_cbo = New RHP.ud_ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dat_Dossier_txt = New RHP.ud_TextBox()
        Me.Mnt_Engage_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rd_2 = New RHP.ud_RadioBox()
        Me.Lien_cbo = New RHP.ud_ComboBox()
        Me.Rd_1 = New RHP.ud_RadioBox()
        Me.Nom_Malade_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.remboursement_Grp.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(26, 53)
        Me.Matricule_.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(59, 16)
        Me.Matricule_.TabIndex = 207
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_txt.Location = New System.Drawing.Point(89, 50)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(141, 21)
        Me.Matricule_txt.TabIndex = 206
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(233, 50)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(369, 21)
        Me.Nom_Agent_Text.TabIndex = 208
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'remboursement_Grp
        '
        Me.remboursement_Grp.Controls.Add(Me.Label6)
        Me.remboursement_Grp.Controls.Add(Me.Mnt_Remboursement_txt)
        Me.remboursement_Grp.Controls.Add(Me.Label5)
        Me.remboursement_Grp.Controls.Add(Me.Label4)
        Me.remboursement_Grp.Controls.Add(Me.LinkLabel5)
        Me.remboursement_Grp.Controls.Add(Me.Pourcentage_txt)
        Me.remboursement_Grp.Controls.Add(Me.Rembourse_Le_txt)
        Me.remboursement_Grp.Controls.Add(Me.LinkLabel2)
        Me.remboursement_Grp.Controls.Add(Me.Envoye_Le_txt)
        Me.remboursement_Grp.Dock = System.Windows.Forms.DockStyle.Top
        Me.remboursement_Grp.Enabled = False
        Me.remboursement_Grp.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.remboursement_Grp.Location = New System.Drawing.Point(0, 372)
        Me.remboursement_Grp.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.remboursement_Grp.Name = "remboursement_Grp"
        Me.remboursement_Grp.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.remboursement_Grp.Size = New System.Drawing.Size(795, 69)
        Me.remboursement_Grp.TabIndex = 257
        Me.remboursement_Grp.TabStop = False
        Me.remboursement_Grp.Text = "Statut du dossier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(622, 45)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 16)
        Me.Label6.TabIndex = 280
        Me.Label6.Text = "%"
        '
        'Mnt_Remboursement_txt
        '
        Me.Mnt_Remboursement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Mnt_Remboursement_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Mnt_Remboursement_txt.Location = New System.Drawing.Point(524, 17)
        Me.Mnt_Remboursement_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Mnt_Remboursement_txt.MaxLength = 32767
        Me.Mnt_Remboursement_txt.Multiline = False
        Me.Mnt_Remboursement_txt.Name = "Mnt_Remboursement_txt"
        Me.Mnt_Remboursement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Mnt_Remboursement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Mnt_Remboursement_txt.ReadOnly = False
        Me.Mnt_Remboursement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mnt_Remboursement_txt.SelectionStart = 0
        Me.Mnt_Remboursement_txt.Size = New System.Drawing.Size(115, 21)
        Me.Mnt_Remboursement_txt.TabIndex = 279
        Me.Mnt_Remboursement_txt.Text = "0,00"
        Me.Mnt_Remboursement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Mnt_Remboursement_txt.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(415, 45)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 278
        Me.Label5.Text = "% remboursement"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(402, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 16)
        Me.Label4.TabIndex = 278
        Me.Label4.Text = "Montant  remboursé"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.LinkLabel5.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.Location = New System.Drawing.Point(106, 45)
        Me.LinkLabel5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(76, 16)
        Me.LinkLabel5.TabIndex = 277
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Tag = "SC"
        Me.LinkLabel5.Text = "Rembouré le"
        '
        'Pourcentage_txt
        '
        Me.Pourcentage_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Pourcentage_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Pourcentage_txt.Location = New System.Drawing.Point(524, 42)
        Me.Pourcentage_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Pourcentage_txt.MaxLength = 32767
        Me.Pourcentage_txt.Multiline = False
        Me.Pourcentage_txt.Name = "Pourcentage_txt"
        Me.Pourcentage_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Pourcentage_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Pourcentage_txt.ReadOnly = True
        Me.Pourcentage_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Pourcentage_txt.SelectionStart = 0
        Me.Pourcentage_txt.Size = New System.Drawing.Size(97, 21)
        Me.Pourcentage_txt.TabIndex = 276
        Me.Pourcentage_txt.Text = "0,00"
        Me.Pourcentage_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Pourcentage_txt.UseSystemPasswordChar = False
        '
        'Rembourse_Le_txt
        '
        Me.Rembourse_Le_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Rembourse_Le_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rembourse_Le_txt.Location = New System.Drawing.Point(185, 42)
        Me.Rembourse_Le_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Rembourse_Le_txt.MaxLength = 32767
        Me.Rembourse_Le_txt.Multiline = False
        Me.Rembourse_Le_txt.Name = "Rembourse_Le_txt"
        Me.Rembourse_Le_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Rembourse_Le_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Rembourse_Le_txt.ReadOnly = True
        Me.Rembourse_Le_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Rembourse_Le_txt.SelectionStart = 0
        Me.Rembourse_Le_txt.Size = New System.Drawing.Size(68, 21)
        Me.Rembourse_Le_txt.TabIndex = 276
        Me.Rembourse_Le_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Rembourse_Le_txt.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(119, 20)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(61, 16)
        Me.LinkLabel2.TabIndex = 275
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = "SC"
        Me.LinkLabel2.Text = "Envoyé le"
        '
        'Envoye_Le_txt
        '
        Me.Envoye_Le_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Envoye_Le_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Envoye_Le_txt.Location = New System.Drawing.Point(185, 17)
        Me.Envoye_Le_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Envoye_Le_txt.MaxLength = 32767
        Me.Envoye_Le_txt.Multiline = False
        Me.Envoye_Le_txt.Name = "Envoye_Le_txt"
        Me.Envoye_Le_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Envoye_Le_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Envoye_Le_txt.ReadOnly = True
        Me.Envoye_Le_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Envoye_Le_txt.SelectionStart = 0
        Me.Envoye_Le_txt.Size = New System.Drawing.Size(68, 21)
        Me.Envoye_Le_txt.TabIndex = 274
        Me.Envoye_Le_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Envoye_Le_txt.UseSystemPasswordChar = False
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(618, 11)
        Me.pb_Valide.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(62, 62)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Valide.TabIndex = 253
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Num_Dossier_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.pb_Valide)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(795, 78)
        Me.GroupBox2.TabIndex = 256
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fiche signalitique"
        '
        'Num_Dossier_txt
        '
        Me.Num_Dossier_txt.AccessibleDescription = "A"
        Me.Num_Dossier_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Dossier_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_Dossier_txt.Location = New System.Drawing.Point(89, 25)
        Me.Num_Dossier_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Num_Dossier_txt.MaxLength = 32767
        Me.Num_Dossier_txt.Multiline = False
        Me.Num_Dossier_txt.Name = "Num_Dossier_txt"
        Me.Num_Dossier_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Dossier_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Dossier_txt.ReadOnly = True
        Me.Num_Dossier_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Dossier_txt.SelectionStart = 0
        Me.Num_Dossier_txt.Size = New System.Drawing.Size(141, 21)
        Me.Num_Dossier_txt.TabIndex = 248
        Me.Num_Dossier_txt.TabStop = False
        Me.Num_Dossier_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Dossier_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(28, 27)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(58, 16)
        Me.LinkLabel3.TabIndex = 249
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SC"
        Me.LinkLabel3.Text = "N° dossier"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LinkLabel4)
        Me.GroupBox4.Controls.Add(Me.Medecin_txt)
        Me.GroupBox4.Controls.Add(Me.Typ_Maladie_cbo)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Dat_Dossier_txt)
        Me.GroupBox4.Controls.Add(Me.Mnt_Engage_txt)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 240)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(795, 132)
        Me.GroupBox4.TabIndex = 252
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Description du traitement"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(74, 92)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(73, 16)
        Me.LinkLabel4.TabIndex = 273
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Date dossier"
        '
        'Medecin_txt
        '
        Me.Medecin_txt.AccessibleDescription = "A"
        Me.Medecin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Medecin_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Medecin_txt.Location = New System.Drawing.Point(150, 65)
        Me.Medecin_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Medecin_txt.MaxLength = 32767
        Me.Medecin_txt.Multiline = False
        Me.Medecin_txt.Name = "Medecin_txt"
        Me.Medecin_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Medecin_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Medecin_txt.ReadOnly = False
        Me.Medecin_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Medecin_txt.SelectionStart = 0
        Me.Medecin_txt.Size = New System.Drawing.Size(489, 21)
        Me.Medecin_txt.TabIndex = 254
        Me.Medecin_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Medecin_txt.UseSystemPasswordChar = False
        '
        'Typ_Maladie_cbo
        '
        Me.Typ_Maladie_cbo.DataSource = Nothing
        Me.Typ_Maladie_cbo.DisplayMember = ""
        Me.Typ_Maladie_cbo.DroppedDown = False
        Me.Typ_Maladie_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Maladie_cbo.Location = New System.Drawing.Point(150, 37)
        Me.Typ_Maladie_cbo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Typ_Maladie_cbo.Name = "Typ_Maladie_cbo"
        Me.Typ_Maladie_cbo.SelectedIndex = -1
        Me.Typ_Maladie_cbo.SelectedItem = Nothing
        Me.Typ_Maladie_cbo.SelectedValue = Nothing
        Me.Typ_Maladie_cbo.Size = New System.Drawing.Size(489, 24)
        Me.Typ_Maladie_cbo.TabIndex = 252
        Me.Typ_Maladie_cbo.ValueMember = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(90, 67)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 251
        Me.Label3.Text = "Médecin"
        '
        'Dat_Dossier_txt
        '
        Me.Dat_Dossier_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Dossier_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Dossier_txt.Location = New System.Drawing.Point(150, 90)
        Me.Dat_Dossier_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Dat_Dossier_txt.MaxLength = 32767
        Me.Dat_Dossier_txt.Multiline = False
        Me.Dat_Dossier_txt.Name = "Dat_Dossier_txt"
        Me.Dat_Dossier_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Dossier_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Dossier_txt.ReadOnly = True
        Me.Dat_Dossier_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Dossier_txt.SelectionStart = 0
        Me.Dat_Dossier_txt.Size = New System.Drawing.Size(68, 21)
        Me.Dat_Dossier_txt.TabIndex = 251
        Me.Dat_Dossier_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Dossier_txt.UseSystemPasswordChar = False
        '
        'Mnt_Engage_txt
        '
        Me.Mnt_Engage_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Mnt_Engage_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Mnt_Engage_txt.Location = New System.Drawing.Point(524, 90)
        Me.Mnt_Engage_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Mnt_Engage_txt.MaxLength = 32767
        Me.Mnt_Engage_txt.Multiline = False
        Me.Mnt_Engage_txt.Name = "Mnt_Engage_txt"
        Me.Mnt_Engage_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Mnt_Engage_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Mnt_Engage_txt.ReadOnly = False
        Me.Mnt_Engage_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mnt_Engage_txt.SelectionStart = 0
        Me.Mnt_Engage_txt.Size = New System.Drawing.Size(114, 21)
        Me.Mnt_Engage_txt.TabIndex = 247
        Me.Mnt_Engage_txt.Text = "0,00"
        Me.Mnt_Engage_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Mnt_Engage_txt.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(45, 42)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 251
        Me.Label2.Text = "Type de maladie"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(414, 92)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 16)
        Me.Label17.TabIndex = 241
        Me.Label17.Text = "Montant  engagé"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rd_2)
        Me.GroupBox1.Controls.Add(Me.Lien_cbo)
        Me.GroupBox1.Controls.Add(Me.Rd_1)
        Me.GroupBox1.Controls.Add(Me.Nom_Malade_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 78)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(795, 162)
        Me.GroupBox1.TabIndex = 251
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fiche du malade"
        '
        'Rd_2
        '
        Me.Rd_2.AutoSize = True
        Me.Rd_2.Checked = False
        Me.Rd_2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Rd_2.Location = New System.Drawing.Point(21, 55)
        Me.Rd_2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Rd_2.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_2.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_2.Name = "Rd_2"
        Me.Rd_2.Size = New System.Drawing.Size(174, 31)
        Me.Rd_2.TabIndex = 0
        Me.Rd_2.Text = "Un membre de la famille"
        '
        'Lien_cbo
        '
        Me.Lien_cbo.DataSource = Nothing
        Me.Lien_cbo.DisplayMember = ""
        Me.Lien_cbo.DroppedDown = False
        Me.Lien_cbo.Enabled = False
        Me.Lien_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lien_cbo.Location = New System.Drawing.Point(233, 115)
        Me.Lien_cbo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Lien_cbo.Name = "Lien_cbo"
        Me.Lien_cbo.SelectedIndex = -1
        Me.Lien_cbo.SelectedItem = Nothing
        Me.Lien_cbo.SelectedValue = Nothing
        Me.Lien_cbo.Size = New System.Drawing.Size(159, 24)
        Me.Lien_cbo.TabIndex = 250
        Me.Lien_cbo.ValueMember = ""
        '
        'Rd_1
        '
        Me.Rd_1.AutoSize = True
        Me.Rd_1.Checked = True
        Me.Rd_1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Rd_1.Location = New System.Drawing.Point(21, 19)
        Me.Rd_1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Rd_1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_1.Name = "Rd_1"
        Me.Rd_1.Size = New System.Drawing.Size(134, 31)
        Me.Rd_1.TabIndex = 0
        Me.Rd_1.Text = "L'agent lui même"
        '
        'Nom_Malade_txt
        '
        Me.Nom_Malade_txt.AccessibleDescription = "A"
        Me.Nom_Malade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Malade_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Malade_txt.Location = New System.Drawing.Point(233, 86)
        Me.Nom_Malade_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Nom_Malade_txt.MaxLength = 32767
        Me.Nom_Malade_txt.Multiline = False
        Me.Nom_Malade_txt.Name = "Nom_Malade_txt"
        Me.Nom_Malade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Malade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Malade_txt.ReadOnly = False
        Me.Nom_Malade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Malade_txt.SelectionStart = 0
        Me.Nom_Malade_txt.Size = New System.Drawing.Size(369, 21)
        Me.Nom_Malade_txt.TabIndex = 208
        Me.Nom_Malade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Malade_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(178, 88)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(52, 16)
        Me.LinkLabel1.TabIndex = 207
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "SC"
        Me.LinkLabel1.Text = "Malade"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(136, 119)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Lien de parenté"
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Commentaire_txt.Location = New System.Drawing.Point(0, 441)
        Me.Commentaire_txt.MaxLength = 32767
        Me.Commentaire_txt.Multiline = True
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(795, 404)
        Me.Commentaire_txt.TabIndex = 258
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'RH_Dossier_Maladie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(795, 845)
        Me.Controls.Add(Me.Commentaire_txt)
        Me.Controls.Add(Me.remboursement_Grp)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "RH_Dossier_Maladie"
        Me.Tag = "ECR"
        Me.Text = "Dossier de maladie"
        Me.remboursement_Grp.ResumeLayout(False)
        Me.remboursement_Grp.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Mnt_Engage_txt As ud_TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Dat_Dossier_txt As ud_TextBox
    Friend WithEvents remboursement_Grp As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Num_Dossier_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Medecin_txt As ud_TextBox
    Friend WithEvents Typ_Maladie_cbo As ud_ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Rd_2 As ud_RadioBox
    Friend WithEvents Lien_cbo As ud_ComboBox
    Friend WithEvents Rd_1 As ud_RadioBox
    Friend WithEvents Nom_Malade_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Mnt_Remboursement_txt As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents Pourcentage_txt As ud_TextBox
    Friend WithEvents Rembourse_Le_txt As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Envoye_Le_txt As ud_TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Commentaire_txt As ud_TextBox
End Class
