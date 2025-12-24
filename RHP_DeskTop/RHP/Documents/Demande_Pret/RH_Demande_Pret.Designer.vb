<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Demande_Pret
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Mensualite_txt = New RHP.ud_TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Premiere_Echeance_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Duree_txt = New System.Windows.Forms.NumericUpDown()
        Me.Montant_Deamnde_Pret_txt = New RHP.ud_TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LastDatePaie_txt = New RHP.ud_TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Prets_Encours_txt = New RHP.ud_TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Reste_Salaire_txt = New RHP.ud_TextBox()
        Me.Dernier_Salaire_Net_txt = New RHP.ud_TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Num_Demande_Pret_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Demande_txt = New RHP.ud_TextBox()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Lib_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Grade_Text = New RHP.ud_TextBox()
        Me.Grade_Text = New RHP.ud_TextBox()
        Me.Lib_Poste_Text = New RHP.ud_TextBox()
        Me.Poste_Text = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Titre_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Duree_txt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Commentaire_txt)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1250, 732)
        Me.Panel1.TabIndex = 209
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.ContextMenuStrip = Nothing
        Me.Commentaire_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Commentaire_txt.Location = New System.Drawing.Point(0, 428)
        Me.Commentaire_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Commentaire_txt.MaxLength = 32767
        Me.Commentaire_txt.Multiline = True
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(1250, 304)
        Me.Commentaire_txt.TabIndex = 258
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Mensualite_txt)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Premiere_Echeance_txt)
        Me.GroupBox3.Controls.Add(Me.LinkLabel1)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Duree_txt)
        Me.GroupBox3.Controls.Add(Me.Montant_Deamnde_Pret_txt)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 300)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(1250, 128)
        Me.GroupBox3.TabIndex = 257
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Détail du prêt"
        '
        'Mensualite_txt
        '
        Me.Mensualite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Mensualite_txt.ContextMenuStrip = Nothing
        Me.Mensualite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Mensualite_txt.Location = New System.Drawing.Point(198, 56)
        Me.Mensualite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Mensualite_txt.MaxLength = 32767
        Me.Mensualite_txt.Multiline = False
        Me.Mensualite_txt.Name = "Mensualite_txt"
        Me.Mensualite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Mensualite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Mensualite_txt.ReadOnly = True
        Me.Mensualite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mensualite_txt.SelectionStart = 0
        Me.Mensualite_txt.Size = New System.Drawing.Size(124, 26)
        Me.Mensualite_txt.TabIndex = 263
        Me.Mensualite_txt.Text = "0,00"
        Me.Mensualite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Mensualite_txt.UseSystemPasswordChar = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(29, 60)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 19)
        Me.Label11.TabIndex = 262
        Me.Label11.Text = "Mensualité sans intérêt"
        '
        'Premiere_Echeance_txt
        '
        Me.Premiere_Echeance_txt.AccessibleDescription = "A"
        Me.Premiere_Echeance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Premiere_Echeance_txt.ContextMenuStrip = Nothing
        Me.Premiere_Echeance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Premiere_Echeance_txt.Location = New System.Drawing.Point(481, 58)
        Me.Premiere_Echeance_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Premiere_Echeance_txt.MaxLength = 32767
        Me.Premiere_Echeance_txt.Multiline = False
        Me.Premiere_Echeance_txt.Name = "Premiere_Echeance_txt"
        Me.Premiere_Echeance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Premiere_Echeance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Premiere_Echeance_txt.ReadOnly = True
        Me.Premiere_Echeance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Premiere_Echeance_txt.SelectionStart = 0
        Me.Premiere_Echeance_txt.Size = New System.Drawing.Size(85, 26)
        Me.Premiere_Echeance_txt.TabIndex = 260
        Me.Premiere_Echeance_txt.TabStop = False
        Me.Premiere_Echeance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Premiere_Echeance_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(376, 61)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(103, 19)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "SC"
        Me.LinkLabel1.Text = "1e échéance"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(376, 29)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 19)
        Me.Label10.TabIndex = 259
        Me.Label10.Text = "Durée en mois"
        '
        'Duree_txt
        '
        Me.Duree_txt.Location = New System.Drawing.Point(481, 25)
        Me.Duree_txt.Margin = New System.Windows.Forms.Padding(4)
        Me.Duree_txt.Maximum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.Duree_txt.Name = "Duree_txt"
        Me.Duree_txt.Size = New System.Drawing.Size(84, 24)
        Me.Duree_txt.TabIndex = 4
        Me.Duree_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Montant_Deamnde_Pret_txt
        '
        Me.Montant_Deamnde_Pret_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Montant_Deamnde_Pret_txt.ContextMenuStrip = Nothing
        Me.Montant_Deamnde_Pret_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Montant_Deamnde_Pret_txt.Location = New System.Drawing.Point(198, 22)
        Me.Montant_Deamnde_Pret_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Montant_Deamnde_Pret_txt.MaxLength = 32767
        Me.Montant_Deamnde_Pret_txt.Multiline = False
        Me.Montant_Deamnde_Pret_txt.Name = "Montant_Deamnde_Pret_txt"
        Me.Montant_Deamnde_Pret_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Montant_Deamnde_Pret_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Montant_Deamnde_Pret_txt.ReadOnly = False
        Me.Montant_Deamnde_Pret_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Montant_Deamnde_Pret_txt.SelectionStart = 0
        Me.Montant_Deamnde_Pret_txt.Size = New System.Drawing.Size(124, 26)
        Me.Montant_Deamnde_Pret_txt.TabIndex = 0
        Me.Montant_Deamnde_Pret_txt.Text = "0,00"
        Me.Montant_Deamnde_Pret_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Montant_Deamnde_Pret_txt.UseSystemPasswordChar = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label17.Location = New System.Drawing.Point(120, 25)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 19)
        Me.Label17.TabIndex = 241
        Me.Label17.Text = "Montant"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.LinkLabel4)
        Me.GroupBox2.Controls.Add(Me.Num_Demande_Pret_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Dat_Demande_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.GroupBox2.Controls.Add(Me.Lib_Plan_Paie_Text)
        Me.GroupBox2.Controls.Add(Me.pb_Valide)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Lib_Grade_Text)
        Me.GroupBox2.Controls.Add(Me.Grade_Text)
        Me.GroupBox2.Controls.Add(Me.Lib_Poste_Text)
        Me.GroupBox2.Controls.Add(Me.Poste_Text)
        Me.GroupBox2.Controls.Add(Me.Lib_Entite_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Entite_txt)
        Me.GroupBox2.Controls.Add(Me.Titre_txt)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1250, 300)
        Me.GroupBox2.TabIndex = 256
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fiche signalitique"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LastDatePaie_txt)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Prets_Encours_txt)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Reste_Salaire_txt)
        Me.GroupBox1.Controls.Add(Me.Dernier_Salaire_Net_txt)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Location = New System.Drawing.Point(528, 149)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(246, 139)
        Me.GroupBox1.TabIndex = 273
        Me.GroupBox1.TabStop = False
        '
        'LastDatePaie_txt
        '
        Me.LastDatePaie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.LastDatePaie_txt.ContextMenuStrip = Nothing
        Me.LastDatePaie_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LastDatePaie_txt.Location = New System.Drawing.Point(140, 15)
        Me.LastDatePaie_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LastDatePaie_txt.MaxLength = 10
        Me.LastDatePaie_txt.Multiline = False
        Me.LastDatePaie_txt.Name = "LastDatePaie_txt"
        Me.LastDatePaie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LastDatePaie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.LastDatePaie_txt.ReadOnly = True
        Me.LastDatePaie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.LastDatePaie_txt.SelectionStart = 0
        Me.LastDatePaie_txt.Size = New System.Drawing.Size(99, 26)
        Me.LastDatePaie_txt.TabIndex = 244
        Me.LastDatePaie_txt.Tag = "4"
        Me.LastDatePaie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.LastDatePaie_txt.UseSystemPasswordChar = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label19.Location = New System.Drawing.Point(8, 49)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(132, 19)
        Me.Label19.TabIndex = 242
        Me.Label19.Text = "Dernier salaire net"
        '
        'Prets_Encours_txt
        '
        Me.Prets_Encours_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Prets_Encours_txt.ContextMenuStrip = Nothing
        Me.Prets_Encours_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Prets_Encours_txt.Location = New System.Drawing.Point(140, 75)
        Me.Prets_Encours_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Prets_Encours_txt.MaxLength = 32767
        Me.Prets_Encours_txt.Multiline = False
        Me.Prets_Encours_txt.Name = "Prets_Encours_txt"
        Me.Prets_Encours_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Prets_Encours_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Prets_Encours_txt.ReadOnly = True
        Me.Prets_Encours_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Prets_Encours_txt.SelectionStart = 0
        Me.Prets_Encours_txt.Size = New System.Drawing.Size(99, 26)
        Me.Prets_Encours_txt.TabIndex = 255
        Me.Prets_Encours_txt.Text = "0,00"
        Me.Prets_Encours_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Prets_Encours_txt.UseSystemPasswordChar = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label20.Location = New System.Drawing.Point(90, 109)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 19)
        Me.Label20.TabIndex = 240
        Me.Label20.Text = "Reste"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label14.Location = New System.Drawing.Point(35, 79)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 19)
        Me.Label14.TabIndex = 254
        Me.Label14.Text = "Prêts en cours"
        '
        'Reste_Salaire_txt
        '
        Me.Reste_Salaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Reste_Salaire_txt.ContextMenuStrip = Nothing
        Me.Reste_Salaire_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Reste_Salaire_txt.Location = New System.Drawing.Point(140, 105)
        Me.Reste_Salaire_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Reste_Salaire_txt.MaxLength = 32767
        Me.Reste_Salaire_txt.Multiline = False
        Me.Reste_Salaire_txt.Name = "Reste_Salaire_txt"
        Me.Reste_Salaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Reste_Salaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Reste_Salaire_txt.ReadOnly = True
        Me.Reste_Salaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Reste_Salaire_txt.SelectionStart = 0
        Me.Reste_Salaire_txt.Size = New System.Drawing.Size(99, 26)
        Me.Reste_Salaire_txt.TabIndex = 246
        Me.Reste_Salaire_txt.Text = "0,00"
        Me.Reste_Salaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Reste_Salaire_txt.UseSystemPasswordChar = False
        '
        'Dernier_Salaire_Net_txt
        '
        Me.Dernier_Salaire_Net_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dernier_Salaire_Net_txt.ContextMenuStrip = Nothing
        Me.Dernier_Salaire_Net_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dernier_Salaire_Net_txt.Location = New System.Drawing.Point(140, 45)
        Me.Dernier_Salaire_Net_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dernier_Salaire_Net_txt.MaxLength = 32767
        Me.Dernier_Salaire_Net_txt.Multiline = False
        Me.Dernier_Salaire_Net_txt.Name = "Dernier_Salaire_Net_txt"
        Me.Dernier_Salaire_Net_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dernier_Salaire_Net_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dernier_Salaire_Net_txt.ReadOnly = True
        Me.Dernier_Salaire_Net_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dernier_Salaire_Net_txt.SelectionStart = 0
        Me.Dernier_Salaire_Net_txt.Size = New System.Drawing.Size(99, 26)
        Me.Dernier_Salaire_Net_txt.TabIndex = 248
        Me.Dernier_Salaire_Net_txt.Text = "0,00"
        Me.Dernier_Salaire_Net_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Dernier_Salaire_Net_txt.UseSystemPasswordChar = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label24.Location = New System.Drawing.Point(35, 19)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(102, 19)
        Me.Label24.TabIndex = 243
        Me.Label24.Text = "Dernière paie"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(429, 30)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(117, 19)
        Me.LinkLabel4.TabIndex = 272
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Date demande"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Num_Demande_Pret_txt
        '
        Me.Num_Demande_Pret_txt.AccessibleDescription = "A"
        Me.Num_Demande_Pret_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Demande_Pret_txt.ContextMenuStrip = Nothing
        Me.Num_Demande_Pret_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_Demande_Pret_txt.Location = New System.Drawing.Point(108, 26)
        Me.Num_Demande_Pret_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Num_Demande_Pret_txt.MaxLength = 32767
        Me.Num_Demande_Pret_txt.Multiline = False
        Me.Num_Demande_Pret_txt.Name = "Num_Demande_Pret_txt"
        Me.Num_Demande_Pret_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Demande_Pret_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Demande_Pret_txt.ReadOnly = True
        Me.Num_Demande_Pret_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Demande_Pret_txt.SelectionStart = 0
        Me.Num_Demande_Pret_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Demande_Pret_txt.TabIndex = 248
        Me.Num_Demande_Pret_txt.TabStop = False
        Me.Num_Demande_Pret_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Demande_Pret_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(5, 29)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(99, 19)
        Me.LinkLabel3.TabIndex = 249
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SC"
        Me.LinkLabel3.Text = "N° demande"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dat_Demande_txt
        '
        Me.Dat_Demande_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Demande_txt.ContextMenuStrip = Nothing
        Me.Dat_Demande_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Demande_txt.Location = New System.Drawing.Point(549, 26)
        Me.Dat_Demande_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dat_Demande_txt.MaxLength = 32767
        Me.Dat_Demande_txt.Multiline = False
        Me.Dat_Demande_txt.Name = "Dat_Demande_txt"
        Me.Dat_Demande_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Demande_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Demande_txt.ReadOnly = True
        Me.Dat_Demande_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Demande_txt.SelectionStart = 0
        Me.Dat_Demande_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Demande_txt.TabIndex = 251
        Me.Dat_Demande_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Demande_txt.UseSystemPasswordChar = False
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(108, 149)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Plan_Paie_Text.MaxLength = 6
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(98, 26)
        Me.Cod_Plan_Paie_Text.TabIndex = 242
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Lib_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(209, 149)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Plan_Paie_Text.MaxLength = 50
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = True
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(304, 26)
        Me.Lib_Plan_Paie_Text.TabIndex = 241
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(675, 62)
        Me.pb_Valide.Margin = New System.Windows.Forms.Padding(4)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(78, 78)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Valide.TabIndex = 253
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_txt.Location = New System.Drawing.Point(108, 58)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(146, 26)
        Me.Matricule_txt.TabIndex = 206
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(256, 58)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(385, 26)
        Me.Nom_Agent_Text.TabIndex = 208
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(29, 61)
        Me.Matricule_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 207
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        Me.Matricule_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Grade_Text
        '
        Me.Lib_Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_Text.ContextMenuStrip = Nothing
        Me.Lib_Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Grade_Text.Location = New System.Drawing.Point(209, 119)
        Me.Lib_Grade_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Grade_Text.MaxLength = 50
        Me.Lib_Grade_Text.Multiline = False
        Me.Lib_Grade_Text.Name = "Lib_Grade_Text"
        Me.Lib_Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_Text.ReadOnly = True
        Me.Lib_Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_Text.SelectionStart = 0
        Me.Lib_Grade_Text.Size = New System.Drawing.Size(432, 26)
        Me.Lib_Grade_Text.TabIndex = 231
        Me.Lib_Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_Text.UseSystemPasswordChar = False
        '
        'Grade_Text
        '
        Me.Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Grade_Text.ContextMenuStrip = Nothing
        Me.Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_Text.Location = New System.Drawing.Point(108, 119)
        Me.Grade_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Grade_Text.MaxLength = 6
        Me.Grade_Text.Multiline = False
        Me.Grade_Text.Name = "Grade_Text"
        Me.Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Grade_Text.ReadOnly = True
        Me.Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grade_Text.SelectionStart = 0
        Me.Grade_Text.Size = New System.Drawing.Size(98, 26)
        Me.Grade_Text.TabIndex = 232
        Me.Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Grade_Text.UseSystemPasswordChar = False
        '
        'Lib_Poste_Text
        '
        Me.Lib_Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Poste_Text.ContextMenuStrip = Nothing
        Me.Lib_Poste_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Poste_Text.Location = New System.Drawing.Point(209, 89)
        Me.Lib_Poste_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Poste_Text.MaxLength = 50
        Me.Lib_Poste_Text.Multiline = False
        Me.Lib_Poste_Text.Name = "Lib_Poste_Text"
        Me.Lib_Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_Text.ReadOnly = True
        Me.Lib_Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_Text.SelectionStart = 0
        Me.Lib_Poste_Text.Size = New System.Drawing.Size(432, 26)
        Me.Lib_Poste_Text.TabIndex = 228
        Me.Lib_Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_Text.UseSystemPasswordChar = False
        '
        'Poste_Text
        '
        Me.Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Poste_Text.ContextMenuStrip = Nothing
        Me.Poste_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Poste_Text.Location = New System.Drawing.Point(108, 89)
        Me.Poste_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Poste_Text.MaxLength = 6
        Me.Poste_Text.Multiline = False
        Me.Poste_Text.Name = "Poste_Text"
        Me.Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Poste_Text.ReadOnly = True
        Me.Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Poste_Text.SelectionStart = 0
        Me.Poste_Text.Size = New System.Drawing.Size(98, 26)
        Me.Poste_Text.TabIndex = 229
        Me.Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Poste_Text.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(209, 180)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(304, 26)
        Me.Lib_Entite_txt.TabIndex = 234
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(108, 180)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Entite_txt.MaxLength = 6
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(98, 26)
        Me.Cod_Entite_txt.TabIndex = 235
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Titre_txt
        '
        Me.Titre_txt.AccessibleDescription = "A"
        Me.Titre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Titre_txt.ContextMenuStrip = Nothing
        Me.Titre_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Titre_txt.Location = New System.Drawing.Point(108, 210)
        Me.Titre_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Titre_txt.MaxLength = 490
        Me.Titre_txt.Multiline = True
        Me.Titre_txt.Name = "Titre_txt"
        Me.Titre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Titre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Titre_txt.ReadOnly = True
        Me.Titre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Titre_txt.SelectionStart = 0
        Me.Titre_txt.Size = New System.Drawing.Size(404, 78)
        Me.Titre_txt.TabIndex = 236
        Me.Titre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Titre_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(68, 214)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 19)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Titre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(36, 94)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 19)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Poste"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(64, 152)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 19)
        Me.Label9.TabIndex = 239
        Me.Label9.Text = "Plan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(48, 122)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Grade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(55, 184)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 19)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Entité"
        '
        'RH_Demande_Pret
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1250, 732)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "RH_Demande_Pret"
        Me.Tag = "ECR"
        Me.Text = "Demande de prêt"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Duree_txt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Titre_txt As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Poste_Text As ud_TextBox
    Friend WithEvents Lib_Poste_Text As ud_TextBox
    Friend WithEvents Grade_Text As ud_TextBox
    Friend WithEvents Lib_Grade_Text As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Reste_Salaire_txt As ud_TextBox
    Friend WithEvents Montant_Deamnde_Pret_txt As ud_TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Dernier_Salaire_Net_txt As ud_TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Dat_Demande_txt As ud_TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents LastDatePaie_txt As ud_TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Num_Demande_Pret_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Mensualite_txt As ud_TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Premiere_Echeance_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label10 As Label
    Friend WithEvents Duree_txt As NumericUpDown
    Friend WithEvents Prets_Encours_txt As ud_TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Commentaire_txt As ud_TextBox
End Class
