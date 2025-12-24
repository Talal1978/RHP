<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Demande_Avance
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Dernier_Salaire_Net_txt = New RHP.ud_TextBox()
        Me.Dat_Demande_txt = New RHP.ud_TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Reste_Salaire_txt = New RHP.ud_TextBox()
        Me.Reglement_txt = New RHP.ud_TextBox()
        Me.Montant_Avance_txt = New RHP.ud_TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Avances_Encours_txt = New RHP.ud_TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Num_Avance_txt = New RHP.ud_TextBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.JourPaie_txt = New RHP.ud_TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.LastDatePaie_txt = New RHP.ud_TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Lib_Plan_Paie_Text = New RHP.ud_TextBox()
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
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(48, 49)
        Me.Matricule_.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(59, 16)
        Me.Matricule_.TabIndex = 207
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        Me.Matricule_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_txt.Location = New System.Drawing.Point(110, 47)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(104, 21)
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
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(218, 47)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = False
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(362, 21)
        Me.Nom_Agent_Text.TabIndex = 208
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Commentaire_txt)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(738, 749)
        Me.Panel1.TabIndex = 209
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Commentaire_txt.Location = New System.Drawing.Point(0, 407)
        Me.Commentaire_txt.MaxLength = 32767
        Me.Commentaire_txt.Multiline = True
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(738, 342)
        Me.Commentaire_txt.TabIndex = 258
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LinkLabel4)
        Me.GroupBox3.Controls.Add(Me.Dernier_Salaire_Net_txt)
        Me.GroupBox3.Controls.Add(Me.Dat_Demande_txt)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Reste_Salaire_txt)
        Me.GroupBox3.Controls.Add(Me.Reglement_txt)
        Me.GroupBox3.Controls.Add(Me.Montant_Avance_txt)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Avances_Encours_txt)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 256)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(738, 151)
        Me.GroupBox3.TabIndex = 257
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Détail de la demande"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(25, 30)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(124, 16)
        Me.LinkLabel4.TabIndex = 273
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Date de la demande"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dernier_Salaire_Net_txt
        '
        Me.Dernier_Salaire_Net_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dernier_Salaire_Net_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dernier_Salaire_Net_txt.Location = New System.Drawing.Point(571, 27)
        Me.Dernier_Salaire_Net_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Dernier_Salaire_Net_txt.MaxLength = 32767
        Me.Dernier_Salaire_Net_txt.Multiline = False
        Me.Dernier_Salaire_Net_txt.Name = "Dernier_Salaire_Net_txt"
        Me.Dernier_Salaire_Net_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dernier_Salaire_Net_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dernier_Salaire_Net_txt.ReadOnly = True
        Me.Dernier_Salaire_Net_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dernier_Salaire_Net_txt.SelectionStart = 0
        Me.Dernier_Salaire_Net_txt.Size = New System.Drawing.Size(71, 21)
        Me.Dernier_Salaire_Net_txt.TabIndex = 248
        Me.Dernier_Salaire_Net_txt.Text = "0,00"
        Me.Dernier_Salaire_Net_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Dernier_Salaire_Net_txt.UseSystemPasswordChar = False
        '
        'Dat_Demande_txt
        '
        Me.Dat_Demande_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Demande_txt.Location = New System.Drawing.Point(153, 27)
        Me.Dat_Demande_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Dat_Demande_txt.MaxLength = 32767
        Me.Dat_Demande_txt.Multiline = False
        Me.Dat_Demande_txt.Name = "Dat_Demande_txt"
        Me.Dat_Demande_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Demande_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Demande_txt.ReadOnly = True
        Me.Dat_Demande_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Demande_txt.SelectionStart = 0
        Me.Dat_Demande_txt.Size = New System.Drawing.Size(71, 21)
        Me.Dat_Demande_txt.TabIndex = 251
        Me.Dat_Demande_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Demande_txt.UseSystemPasswordChar = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label18.Location = New System.Drawing.Point(288, 54)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 16)
        Me.Label18.TabIndex = 244
        Me.Label18.Text = "Réglement"
        '
        'Reste_Salaire_txt
        '
        Me.Reste_Salaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Reste_Salaire_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Reste_Salaire_txt.Location = New System.Drawing.Point(571, 52)
        Me.Reste_Salaire_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Reste_Salaire_txt.MaxLength = 32767
        Me.Reste_Salaire_txt.Multiline = False
        Me.Reste_Salaire_txt.Name = "Reste_Salaire_txt"
        Me.Reste_Salaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Reste_Salaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Reste_Salaire_txt.ReadOnly = True
        Me.Reste_Salaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Reste_Salaire_txt.SelectionStart = 0
        Me.Reste_Salaire_txt.Size = New System.Drawing.Size(71, 21)
        Me.Reste_Salaire_txt.TabIndex = 246
        Me.Reste_Salaire_txt.Text = "0,00"
        Me.Reste_Salaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Reste_Salaire_txt.UseSystemPasswordChar = False
        '
        'Reglement_txt
        '
        Me.Reglement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Reglement_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Reglement_txt.Location = New System.Drawing.Point(358, 52)
        Me.Reglement_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Reglement_txt.MaxLength = 32767
        Me.Reglement_txt.Multiline = False
        Me.Reglement_txt.Name = "Reglement_txt"
        Me.Reglement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Reglement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Reglement_txt.ReadOnly = True
        Me.Reglement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Reglement_txt.SelectionStart = 0
        Me.Reglement_txt.Size = New System.Drawing.Size(71, 21)
        Me.Reglement_txt.TabIndex = 250
        Me.Reglement_txt.Text = "0,00"
        Me.Reglement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Reglement_txt.UseSystemPasswordChar = False
        '
        'Montant_Avance_txt
        '
        Me.Montant_Avance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Montant_Avance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Montant_Avance_txt.Location = New System.Drawing.Point(358, 27)
        Me.Montant_Avance_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Montant_Avance_txt.MaxLength = 32767
        Me.Montant_Avance_txt.Multiline = False
        Me.Montant_Avance_txt.Name = "Montant_Avance_txt"
        Me.Montant_Avance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Montant_Avance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Montant_Avance_txt.ReadOnly = False
        Me.Montant_Avance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Montant_Avance_txt.SelectionStart = 0
        Me.Montant_Avance_txt.Size = New System.Drawing.Size(71, 21)
        Me.Montant_Avance_txt.TabIndex = 247
        Me.Montant_Avance_txt.Text = "0,00"
        Me.Montant_Avance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Montant_Avance_txt.UseSystemPasswordChar = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label16.Location = New System.Drawing.Point(48, 54)
        Me.Label16.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 16)
        Me.Label16.TabIndex = 243
        Me.Label16.Text = "Avances encours"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label20.Location = New System.Drawing.Point(473, 54)
        Me.Label20.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(94, 16)
        Me.Label20.TabIndex = 240
        Me.Label20.Text = "Reste du Salaire"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label19.Location = New System.Drawing.Point(465, 30)
        Me.Label19.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 16)
        Me.Label19.TabIndex = 242
        Me.Label19.Text = "Dernier salaire net"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label17.Location = New System.Drawing.Point(228, 29)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(126, 16)
        Me.Label17.TabIndex = 241
        Me.Label17.Text = "Montant de l'avance"
        '
        'Avances_Encours_txt
        '
        Me.Avances_Encours_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Avances_Encours_txt.Location = New System.Drawing.Point(153, 52)
        Me.Avances_Encours_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Avances_Encours_txt.MaxLength = 32767
        Me.Avances_Encours_txt.Multiline = False
        Me.Avances_Encours_txt.Name = "Avances_Encours_txt"
        Me.Avances_Encours_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Avances_Encours_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Avances_Encours_txt.ReadOnly = True
        Me.Avances_Encours_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Avances_Encours_txt.SelectionStart = 0
        Me.Avances_Encours_txt.Size = New System.Drawing.Size(71, 21)
        Me.Avances_Encours_txt.TabIndex = 249
        Me.Avances_Encours_txt.Text = "0,00"
        Me.Avances_Encours_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Avances_Encours_txt.UseSystemPasswordChar = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Num_Avance_txt)
        Me.GroupBox2.Controls.Add(Me.pb_Valide)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.JourPaie_txt)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.LastDatePaie_txt)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.GroupBox2.Controls.Add(Me.Lib_Plan_Paie_Text)
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
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(738, 256)
        Me.GroupBox2.TabIndex = 256
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fiche signalitique"
        '
        'Num_Avance_txt
        '
        Me.Num_Avance_txt.AccessibleDescription = "A"
        Me.Num_Avance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Avance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_Avance_txt.Location = New System.Drawing.Point(110, 23)
        Me.Num_Avance_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Num_Avance_txt.MaxLength = 32767
        Me.Num_Avance_txt.Multiline = False
        Me.Num_Avance_txt.Name = "Num_Avance_txt"
        Me.Num_Avance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Avance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Avance_txt.ReadOnly = True
        Me.Num_Avance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Avance_txt.SelectionStart = 0
        Me.Num_Avance_txt.Size = New System.Drawing.Size(140, 21)
        Me.Num_Avance_txt.TabIndex = 248
        Me.Num_Avance_txt.TabStop = False
        Me.Num_Avance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Avance_txt.UseSystemPasswordChar = False
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(581, 146)
        Me.pb_Valide.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(84, 85)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Valide.TabIndex = 253
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(28, 25)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(78, 16)
        Me.LinkLabel3.TabIndex = 249
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SC"
        Me.LinkLabel3.Text = "N° demande"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'JourPaie_txt
        '
        Me.JourPaie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.JourPaie_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.JourPaie_txt.Location = New System.Drawing.Point(535, 22)
        Me.JourPaie_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.JourPaie_txt.MaxLength = 10
        Me.JourPaie_txt.Multiline = False
        Me.JourPaie_txt.Name = "JourPaie_txt"
        Me.JourPaie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.JourPaie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.JourPaie_txt.ReadOnly = True
        Me.JourPaie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.JourPaie_txt.SelectionStart = 0
        Me.JourPaie_txt.Size = New System.Drawing.Size(45, 21)
        Me.JourPaie_txt.TabIndex = 247
        Me.JourPaie_txt.Tag = "4"
        Me.JourPaie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.JourPaie_txt.UseSystemPasswordChar = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label22.Location = New System.Drawing.Point(461, 27)
        Me.Label22.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 16)
        Me.Label22.TabIndex = 246
        Me.Label22.Text = "1er jour paie"
        '
        'LastDatePaie_txt
        '
        Me.LastDatePaie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.LastDatePaie_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LastDatePaie_txt.Location = New System.Drawing.Point(339, 27)
        Me.LastDatePaie_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.LastDatePaie_txt.MaxLength = 10
        Me.LastDatePaie_txt.Multiline = False
        Me.LastDatePaie_txt.Name = "LastDatePaie_txt"
        Me.LastDatePaie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LastDatePaie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.LastDatePaie_txt.ReadOnly = True
        Me.LastDatePaie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.LastDatePaie_txt.SelectionStart = 0
        Me.LastDatePaie_txt.Size = New System.Drawing.Size(63, 21)
        Me.LastDatePaie_txt.TabIndex = 244
        Me.LastDatePaie_txt.Tag = "4"
        Me.LastDatePaie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LastDatePaie_txt.UseSystemPasswordChar = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label24.Location = New System.Drawing.Point(260, 31)
        Me.Label24.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 16)
        Me.Label24.TabIndex = 243
        Me.Label24.Text = "Dernière paie"
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(110, 121)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Cod_Plan_Paie_Text.MaxLength = 6
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(103, 21)
        Me.Cod_Plan_Paie_Text.TabIndex = 242
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(218, 121)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Lib_Plan_Paie_Text.MaxLength = 50
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = True
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(362, 21)
        Me.Lib_Plan_Paie_Text.TabIndex = 241
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Lib_Grade_Text
        '
        Me.Lib_Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Grade_Text.Location = New System.Drawing.Point(218, 96)
        Me.Lib_Grade_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Lib_Grade_Text.MaxLength = 50
        Me.Lib_Grade_Text.Multiline = False
        Me.Lib_Grade_Text.Name = "Lib_Grade_Text"
        Me.Lib_Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_Text.ReadOnly = True
        Me.Lib_Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_Text.SelectionStart = 0
        Me.Lib_Grade_Text.Size = New System.Drawing.Size(362, 21)
        Me.Lib_Grade_Text.TabIndex = 231
        Me.Lib_Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_Text.UseSystemPasswordChar = False
        '
        'Grade_Text
        '
        Me.Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_Text.Location = New System.Drawing.Point(110, 96)
        Me.Grade_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Grade_Text.MaxLength = 6
        Me.Grade_Text.Multiline = False
        Me.Grade_Text.Name = "Grade_Text"
        Me.Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Grade_Text.ReadOnly = True
        Me.Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grade_Text.SelectionStart = 0
        Me.Grade_Text.Size = New System.Drawing.Size(103, 21)
        Me.Grade_Text.TabIndex = 232
        Me.Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Grade_Text.UseSystemPasswordChar = False
        '
        'Lib_Poste_Text
        '
        Me.Lib_Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Poste_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Poste_Text.Location = New System.Drawing.Point(218, 71)
        Me.Lib_Poste_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Lib_Poste_Text.MaxLength = 50
        Me.Lib_Poste_Text.Multiline = False
        Me.Lib_Poste_Text.Name = "Lib_Poste_Text"
        Me.Lib_Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_Text.ReadOnly = True
        Me.Lib_Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_Text.SelectionStart = 0
        Me.Lib_Poste_Text.Size = New System.Drawing.Size(362, 21)
        Me.Lib_Poste_Text.TabIndex = 228
        Me.Lib_Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_Text.UseSystemPasswordChar = False
        '
        'Poste_Text
        '
        Me.Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Poste_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Poste_Text.Location = New System.Drawing.Point(110, 71)
        Me.Poste_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Poste_Text.MaxLength = 6
        Me.Poste_Text.Multiline = False
        Me.Poste_Text.Name = "Poste_Text"
        Me.Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Poste_Text.ReadOnly = True
        Me.Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Poste_Text.SelectionStart = 0
        Me.Poste_Text.Size = New System.Drawing.Size(103, 21)
        Me.Poste_Text.TabIndex = 229
        Me.Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Poste_Text.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(218, 146)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(362, 21)
        Me.Lib_Entite_txt.TabIndex = 234
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(110, 146)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Cod_Entite_txt.MaxLength = 6
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(103, 21)
        Me.Cod_Entite_txt.TabIndex = 235
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Titre_txt
        '
        Me.Titre_txt.AccessibleDescription = "A"
        Me.Titre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Titre_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Titre_txt.Location = New System.Drawing.Point(110, 171)
        Me.Titre_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Titre_txt.MaxLength = 490
        Me.Titre_txt.Multiline = True
        Me.Titre_txt.Name = "Titre_txt"
        Me.Titre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Titre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Titre_txt.ReadOnly = True
        Me.Titre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Titre_txt.SelectionStart = 0
        Me.Titre_txt.Size = New System.Drawing.Size(470, 60)
        Me.Titre_txt.TabIndex = 236
        Me.Titre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Titre_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(77, 174)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 16)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Titre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(53, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Poste"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(75, 123)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 239
        Me.Label9.Text = "Plan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(63, 98)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Grade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(69, 148)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 16)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Entité"
        '
        'RH_Demande_Avance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(738, 749)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "RH_Demande_Avance"
        Me.Tag = "ECR"
        Me.Text = "Demande d'avance sur salaire"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents Montant_Avance_txt As ud_TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Dernier_Salaire_Net_txt As ud_TextBox
    Friend WithEvents Avances_Encours_txt As ud_TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Reglement_txt As ud_TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Dat_Demande_txt As ud_TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents LastDatePaie_txt As ud_TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents JourPaie_txt As ud_TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Num_Avance_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Commentaire_txt As ud_TextBox
End Class
