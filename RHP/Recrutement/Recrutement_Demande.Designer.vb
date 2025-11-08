<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Recrutement_Demande
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
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Demandeur = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Titre_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Lib_Grade_Text = New RHP.ud_TextBox()
        Me.Cod_Poste_txt = New RHP.ud_TextBox()
        Me.Cod_Grade_txt = New RHP.ud_TextBox()
        Me.Lib_Poste_Text = New RHP.ud_TextBox()
        Me.DetailDemande = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Motif_DR = New RHP.ud_ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Age_pnl = New System.Windows.Forms.Panel()
        Me.Age_Au = New RHP.ud_TextBox()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.Age_Du = New RHP.ud_TextBox()
        Me.Rd_Age_1 = New RHP.ud_RadioBox()
        Me.Rd_Age_0 = New RHP.ud_RadioBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Sexe_Indifferent_rd = New RHP.ud_RadioBox()
        Me.Sexe_Femme_rd = New RHP.ud_RadioBox()
        Me.Sexe_Homme_rd = New RHP.ud_RadioBox()
        Me.Cod_Entite_DR_txt = New RHP.ud_TextBox()
        Me.Lib_Entite_DR_txt = New RHP.ud_TextBox()
        Me.Entite_ = New System.Windows.Forms.LinkLabel()
        Me.Nb_Personne = New System.Windows.Forms.NumericUpDown()
        Me.Duree_pnl = New System.Windows.Forms.Panel()
        Me.Duree_Au = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Duree_Du = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Rd_Duree_0 = New RHP.ud_RadioBox()
        Me.Rd_Duree_1 = New RHP.ud_RadioBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Titre_DR_txt = New RHP.ud_TextBox()
        Me.Cod_Poste_DR_txt = New RHP.ud_TextBox()
        Me.Grade_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Poste_DR_txt = New RHP.ud_TextBox()
        Me.Cod_Grade_DR_txt = New RHP.ud_TextBox()
        Me.Poste_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Grade_DR_txt = New RHP.ud_TextBox()
        Me.Buget_Salaire_txt = New RHP.ud_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CompetencesRequises = New System.Windows.Forms.TabPage()
        Me.Domaines_Competence_Pnl = New System.Windows.Forms.Panel()
        Me.ChargerCompetencesPoste_btn = New RHP.ud_button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Parcours_txt = New RHP.ud_TextBox()
        Me.Experience = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Etablissement_txt = New RHP.ud_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Niveau = New RHP.ud_ComboBox()
        Me.Narratif = New System.Windows.Forms.TabPage()
        Me.Narratif_rtb = New RHP.ud_RichTextBox()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Lib_DR_txt = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Num_DR_txt = New RHP.ud_TextBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.Dat_DR_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Demandeur.SuspendLayout()
        Me.DetailDemande.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Age_pnl.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Nb_Personne, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Duree_pnl.SuspendLayout()
        Me.CompetencesRequises.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.Experience, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.Narratif.SuspendLayout()
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
        Me.Matricule_.Location = New System.Drawing.Point(35, 31)
        Me.Matricule_.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
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
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_txt.Location = New System.Drawing.Point(112, 29)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(129, 26)
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
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(248, 29)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(452, 26)
        Me.Nom_Agent_Text.TabIndex = 208
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.Commentaire_txt)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(922, 936)
        Me.Panel1.TabIndex = 209
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Demandeur)
        Me.TabControl1.Controls.Add(Me.DetailDemande)
        Me.TabControl1.Controls.Add(Me.CompetencesRequises)
        Me.TabControl1.Controls.Add(Me.Narratif)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 135)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(922, 801)
        Me.TabControl1.TabIndex = 259
        '
        'Demandeur
        '
        Me.Demandeur.Controls.Add(Me.Nom_Agent_Text)
        Me.Demandeur.Controls.Add(Me.Label4)
        Me.Demandeur.Controls.Add(Me.Label3)
        Me.Demandeur.Controls.Add(Me.Label2)
        Me.Demandeur.Controls.Add(Me.Label1)
        Me.Demandeur.Controls.Add(Me.Matricule_txt)
        Me.Demandeur.Controls.Add(Me.Titre_txt)
        Me.Demandeur.Controls.Add(Me.Cod_Entite_txt)
        Me.Demandeur.Controls.Add(Me.Matricule_)
        Me.Demandeur.Controls.Add(Me.Lib_Entite_txt)
        Me.Demandeur.Controls.Add(Me.Lib_Grade_Text)
        Me.Demandeur.Controls.Add(Me.Cod_Poste_txt)
        Me.Demandeur.Controls.Add(Me.Cod_Grade_txt)
        Me.Demandeur.Controls.Add(Me.Lib_Poste_Text)
        Me.Demandeur.Location = New System.Drawing.Point(4, 28)
        Me.Demandeur.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Demandeur.Name = "Demandeur"
        Me.Demandeur.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Demandeur.Size = New System.Drawing.Size(914, 769)
        Me.Demandeur.TabIndex = 3
        Me.Demandeur.Text = "Demandeur"
        Me.Demandeur.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(61, 125)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 19)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Entité"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(54, 92)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Grade"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(41, 61)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 19)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Poste"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(71, 158)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 19)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Titre"
        '
        'Titre_txt
        '
        Me.Titre_txt.AccessibleDescription = "A"
        Me.Titre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Titre_txt.ContextMenuStrip = Nothing
        Me.Titre_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Titre_txt.Location = New System.Drawing.Point(112, 154)
        Me.Titre_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Titre_txt.MaxLength = 490
        Me.Titre_txt.Multiline = True
        Me.Titre_txt.Name = "Titre_txt"
        Me.Titre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Titre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Titre_txt.ReadOnly = True
        Me.Titre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Titre_txt.SelectionStart = 0
        Me.Titre_txt.Size = New System.Drawing.Size(588, 75)
        Me.Titre_txt.TabIndex = 236
        Me.Titre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Titre_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(112, 122)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Cod_Entite_txt.MaxLength = 6
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(129, 26)
        Me.Cod_Entite_txt.TabIndex = 235
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(248, 122)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(452, 26)
        Me.Lib_Entite_txt.TabIndex = 234
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Lib_Grade_Text
        '
        Me.Lib_Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_Text.ContextMenuStrip = Nothing
        Me.Lib_Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Grade_Text.Location = New System.Drawing.Point(248, 90)
        Me.Lib_Grade_Text.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Grade_Text.MaxLength = 50
        Me.Lib_Grade_Text.Multiline = False
        Me.Lib_Grade_Text.Name = "Lib_Grade_Text"
        Me.Lib_Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_Text.ReadOnly = True
        Me.Lib_Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_Text.SelectionStart = 0
        Me.Lib_Grade_Text.Size = New System.Drawing.Size(452, 26)
        Me.Lib_Grade_Text.TabIndex = 231
        Me.Lib_Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_Text.UseSystemPasswordChar = False
        '
        'Cod_Poste_txt
        '
        Me.Cod_Poste_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Poste_txt.ContextMenuStrip = Nothing
        Me.Cod_Poste_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Poste_txt.Location = New System.Drawing.Point(112, 59)
        Me.Cod_Poste_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Cod_Poste_txt.MaxLength = 6
        Me.Cod_Poste_txt.Multiline = False
        Me.Cod_Poste_txt.Name = "Cod_Poste_txt"
        Me.Cod_Poste_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Poste_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Poste_txt.ReadOnly = True
        Me.Cod_Poste_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Poste_txt.SelectionStart = 0
        Me.Cod_Poste_txt.Size = New System.Drawing.Size(129, 26)
        Me.Cod_Poste_txt.TabIndex = 229
        Me.Cod_Poste_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Poste_txt.UseSystemPasswordChar = False
        '
        'Cod_Grade_txt
        '
        Me.Cod_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Grade_txt.ContextMenuStrip = Nothing
        Me.Cod_Grade_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Grade_txt.Location = New System.Drawing.Point(112, 90)
        Me.Cod_Grade_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Cod_Grade_txt.MaxLength = 6
        Me.Cod_Grade_txt.Multiline = False
        Me.Cod_Grade_txt.Name = "Cod_Grade_txt"
        Me.Cod_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Grade_txt.ReadOnly = True
        Me.Cod_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Grade_txt.SelectionStart = 0
        Me.Cod_Grade_txt.Size = New System.Drawing.Size(129, 26)
        Me.Cod_Grade_txt.TabIndex = 232
        Me.Cod_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Grade_txt.UseSystemPasswordChar = False
        '
        'Lib_Poste_Text
        '
        Me.Lib_Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Poste_Text.ContextMenuStrip = Nothing
        Me.Lib_Poste_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Poste_Text.Location = New System.Drawing.Point(248, 59)
        Me.Lib_Poste_Text.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Poste_Text.MaxLength = 50
        Me.Lib_Poste_Text.Multiline = False
        Me.Lib_Poste_Text.Name = "Lib_Poste_Text"
        Me.Lib_Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_Text.ReadOnly = True
        Me.Lib_Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_Text.SelectionStart = 0
        Me.Lib_Poste_Text.Size = New System.Drawing.Size(452, 26)
        Me.Lib_Poste_Text.TabIndex = 228
        Me.Lib_Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_Text.UseSystemPasswordChar = False
        '
        'DetailDemande
        '
        Me.DetailDemande.Controls.Add(Me.GroupBox3)
        Me.DetailDemande.Location = New System.Drawing.Point(4, 28)
        Me.DetailDemande.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DetailDemande.Name = "DetailDemande"
        Me.DetailDemande.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DetailDemande.Size = New System.Drawing.Size(914, 769)
        Me.DetailDemande.TabIndex = 0
        Me.DetailDemande.Text = "Détail de la demande"
        Me.DetailDemande.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Motif_DR)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.Cod_Entite_DR_txt)
        Me.GroupBox3.Controls.Add(Me.Lib_Entite_DR_txt)
        Me.GroupBox3.Controls.Add(Me.Entite_)
        Me.GroupBox3.Controls.Add(Me.Nb_Personne)
        Me.GroupBox3.Controls.Add(Me.Duree_pnl)
        Me.GroupBox3.Controls.Add(Me.Rd_Duree_0)
        Me.GroupBox3.Controls.Add(Me.Rd_Duree_1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Titre_DR_txt)
        Me.GroupBox3.Controls.Add(Me.Cod_Poste_DR_txt)
        Me.GroupBox3.Controls.Add(Me.Grade_)
        Me.GroupBox3.Controls.Add(Me.Lib_Poste_DR_txt)
        Me.GroupBox3.Controls.Add(Me.Cod_Grade_DR_txt)
        Me.GroupBox3.Controls.Add(Me.Poste_)
        Me.GroupBox3.Controls.Add(Me.Lib_Grade_DR_txt)
        Me.GroupBox3.Controls.Add(Me.Buget_Salaire_txt)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(906, 761)
        Me.GroupBox3.TabIndex = 257
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Détail de la demande"
        '
        'Motif_DR
        '
        Me.Motif_DR.DataSource = Nothing
        Me.Motif_DR.DisplayMember = ""
        Me.Motif_DR.DroppedDown = False
        Me.Motif_DR.Location = New System.Drawing.Point(125, 572)
        Me.Motif_DR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Motif_DR.Name = "Motif_DR"
        Me.Motif_DR.SelectedIndex = -1
        Me.Motif_DR.SelectedItem = Nothing
        Me.Motif_DR.SelectedValue = Nothing
        Me.Motif_DR.Size = New System.Drawing.Size(308, 31)
        Me.Motif_DR.TabIndex = 281
        Me.Motif_DR.ValueMember = ""
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Age_pnl)
        Me.GroupBox4.Controls.Add(Me.Rd_Age_1)
        Me.GroupBox4.Controls.Add(Me.Rd_Age_0)
        Me.GroupBox4.Location = New System.Drawing.Point(129, 448)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(650, 116)
        Me.GroupBox4.TabIndex = 280
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Age"
        '
        'Age_pnl
        '
        Me.Age_pnl.Controls.Add(Me.Age_Au)
        Me.Age_pnl.Controls.Add(Me.LinkLabel5)
        Me.Age_pnl.Controls.Add(Me.Age_Du)
        Me.Age_pnl.Location = New System.Drawing.Point(109, 59)
        Me.Age_pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Age_pnl.Name = "Age_pnl"
        Me.Age_pnl.Size = New System.Drawing.Size(335, 38)
        Me.Age_pnl.TabIndex = 275
        Me.Age_pnl.Visible = False
        '
        'Age_Au
        '
        Me.Age_Au.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Age_Au.ContextMenuStrip = Nothing
        Me.Age_Au.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Age_Au.Location = New System.Drawing.Point(155, 10)
        Me.Age_Au.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Age_Au.MaxLength = 32767
        Me.Age_Au.Multiline = False
        Me.Age_Au.Name = "Age_Au"
        Me.Age_Au.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Age_Au.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Age_Au.ReadOnly = False
        Me.Age_Au.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Age_Au.SelectionStart = 0
        Me.Age_Au.Size = New System.Drawing.Size(104, 25)
        Me.Age_Au.TabIndex = 251
        Me.Age_Au.Text = "59"
        Me.Age_Au.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Age_Au.UseSystemPasswordChar = False
        '
        'LinkLabel5
        '
        Me.LinkLabel5.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.Location = New System.Drawing.Point(111, 11)
        Me.LinkLabel5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(22, 19)
        Me.LinkLabel5.TabIndex = 273
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Tag = "SC"
        Me.LinkLabel5.Text = "Et"
        Me.LinkLabel5.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Age_Du
        '
        Me.Age_Du.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Age_Du.ContextMenuStrip = Nothing
        Me.Age_Du.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Age_Du.Location = New System.Drawing.Point(2, 10)
        Me.Age_Du.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.Age_Du.MaxLength = 32767
        Me.Age_Du.Multiline = False
        Me.Age_Du.Name = "Age_Du"
        Me.Age_Du.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Age_Du.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Age_Du.ReadOnly = False
        Me.Age_Du.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Age_Du.SelectionStart = 0
        Me.Age_Du.Size = New System.Drawing.Size(104, 25)
        Me.Age_Du.TabIndex = 251
        Me.Age_Du.Text = "18"
        Me.Age_Du.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Age_Du.UseSystemPasswordChar = False
        '
        'Rd_Age_1
        '
        Me.Rd_Age_1.AutoSize = True
        Me.Rd_Age_1.Checked = False
        Me.Rd_Age_1.Location = New System.Drawing.Point(8, 65)
        Me.Rd_Age_1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Rd_Age_1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Age_1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Age_1.Name = "Rd_Age_1"
        Me.Rd_Age_1.Size = New System.Drawing.Size(142, 31)
        Me.Rd_Age_1.TabIndex = 1
        Me.Rd_Age_1.Text = "Entre"
        '
        'Rd_Age_0
        '
        Me.Rd_Age_0.AutoSize = True
        Me.Rd_Age_0.Checked = True
        Me.Rd_Age_0.Location = New System.Drawing.Point(8, 26)
        Me.Rd_Age_0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Rd_Age_0.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Age_0.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Age_0.Name = "Rd_Age_0"
        Me.Rd_Age_0.Size = New System.Drawing.Size(142, 31)
        Me.Rd_Age_0.TabIndex = 0
        Me.Rd_Age_0.Text = "Indifférent"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Sexe_Indifferent_rd)
        Me.GroupBox1.Controls.Add(Me.Sexe_Femme_rd)
        Me.GroupBox1.Controls.Add(Me.Sexe_Homme_rd)
        Me.GroupBox1.Location = New System.Drawing.Point(129, 362)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(648, 78)
        Me.GroupBox1.TabIndex = 279
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sexe"
        '
        'Sexe_Indifferent_rd
        '
        Me.Sexe_Indifferent_rd.AutoSize = True
        Me.Sexe_Indifferent_rd.Checked = True
        Me.Sexe_Indifferent_rd.Location = New System.Drawing.Point(452, 26)
        Me.Sexe_Indifferent_rd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Sexe_Indifferent_rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Sexe_Indifferent_rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Sexe_Indifferent_rd.Name = "Sexe_Indifferent_rd"
        Me.Sexe_Indifferent_rd.Size = New System.Drawing.Size(142, 31)
        Me.Sexe_Indifferent_rd.TabIndex = 2
        Me.Sexe_Indifferent_rd.Text = "Indifférent"
        '
        'Sexe_Femme_rd
        '
        Me.Sexe_Femme_rd.AutoSize = True
        Me.Sexe_Femme_rd.Checked = False
        Me.Sexe_Femme_rd.Location = New System.Drawing.Point(218, 26)
        Me.Sexe_Femme_rd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Sexe_Femme_rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Sexe_Femme_rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Sexe_Femme_rd.Name = "Sexe_Femme_rd"
        Me.Sexe_Femme_rd.Size = New System.Drawing.Size(142, 31)
        Me.Sexe_Femme_rd.TabIndex = 1
        Me.Sexe_Femme_rd.Text = "Femme"
        '
        'Sexe_Homme_rd
        '
        Me.Sexe_Homme_rd.AutoSize = True
        Me.Sexe_Homme_rd.Checked = False
        Me.Sexe_Homme_rd.Location = New System.Drawing.Point(8, 26)
        Me.Sexe_Homme_rd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Sexe_Homme_rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Sexe_Homme_rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Sexe_Homme_rd.Name = "Sexe_Homme_rd"
        Me.Sexe_Homme_rd.Size = New System.Drawing.Size(142, 31)
        Me.Sexe_Homme_rd.TabIndex = 0
        Me.Sexe_Homme_rd.Text = "Homme"
        '
        'Cod_Entite_DR_txt
        '
        Me.Cod_Entite_DR_txt.AutoSize = True
        Me.Cod_Entite_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_DR_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_DR_txt.Location = New System.Drawing.Point(125, 36)
        Me.Cod_Entite_DR_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Entite_DR_txt.MaxLength = 6
        Me.Cod_Entite_DR_txt.Multiline = False
        Me.Cod_Entite_DR_txt.Name = "Cod_Entite_DR_txt"
        Me.Cod_Entite_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_DR_txt.ReadOnly = True
        Me.Cod_Entite_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_DR_txt.SelectionStart = 0
        Me.Cod_Entite_DR_txt.Size = New System.Drawing.Size(114, 32)
        Me.Cod_Entite_DR_txt.TabIndex = 278
        Me.Cod_Entite_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_DR_txt.UseSystemPasswordChar = False
        '
        'Lib_Entite_DR_txt
        '
        Me.Lib_Entite_DR_txt.AutoSize = True
        Me.Lib_Entite_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_DR_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_DR_txt.Location = New System.Drawing.Point(242, 36)
        Me.Lib_Entite_DR_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Entite_DR_txt.MaxLength = 50
        Me.Lib_Entite_DR_txt.Multiline = False
        Me.Lib_Entite_DR_txt.Name = "Lib_Entite_DR_txt"
        Me.Lib_Entite_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_DR_txt.ReadOnly = True
        Me.Lib_Entite_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_DR_txt.SelectionStart = 0
        Me.Lib_Entite_DR_txt.Size = New System.Drawing.Size(536, 32)
        Me.Lib_Entite_DR_txt.TabIndex = 277
        Me.Lib_Entite_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_DR_txt.UseSystemPasswordChar = False
        '
        'Entite_
        '
        Me.Entite_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.AutoSize = True
        Me.Entite_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Entite_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.Location = New System.Drawing.Point(72, 44)
        Me.Entite_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Entite_.Name = "Entite_"
        Me.Entite_.Size = New System.Drawing.Size(48, 19)
        Me.Entite_.TabIndex = 276
        Me.Entite_.TabStop = True
        Me.Entite_.Tag = "NC"
        Me.Entite_.Text = "Entité"
        '
        'Nb_Personne
        '
        Me.Nb_Personne.Location = New System.Drawing.Point(129, 329)
        Me.Nb_Personne.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Nb_Personne.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nb_Personne.Name = "Nb_Personne"
        Me.Nb_Personne.Size = New System.Drawing.Size(110, 24)
        Me.Nb_Personne.TabIndex = 275
        Me.Nb_Personne.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Nb_Personne.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Duree_pnl
        '
        Me.Duree_pnl.Controls.Add(Me.Duree_Au)
        Me.Duree_pnl.Controls.Add(Me.LinkLabel2)
        Me.Duree_pnl.Controls.Add(Me.Duree_Du)
        Me.Duree_pnl.Controls.Add(Me.LinkLabel1)
        Me.Duree_pnl.Location = New System.Drawing.Point(389, 279)
        Me.Duree_pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Duree_pnl.Name = "Duree_pnl"
        Me.Duree_pnl.Size = New System.Drawing.Size(390, 38)
        Me.Duree_pnl.TabIndex = 274
        Me.Duree_pnl.Visible = False
        '
        'Duree_Au
        '
        Me.Duree_Au.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Duree_Au.ContextMenuStrip = Nothing
        Me.Duree_Au.Location = New System.Drawing.Point(284, 2)
        Me.Duree_Au.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Duree_Au.MaxLength = 32767
        Me.Duree_Au.Multiline = False
        Me.Duree_Au.Name = "Duree_Au"
        Me.Duree_Au.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Duree_Au.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Duree_Au.ReadOnly = True
        Me.Duree_Au.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Duree_Au.SelectionStart = 0
        Me.Duree_Au.Size = New System.Drawing.Size(104, 32)
        Me.Duree_Au.TabIndex = 251
        Me.Duree_Au.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Duree_Au.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(250, 9)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(27, 19)
        Me.LinkLabel2.TabIndex = 273
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = "SC"
        Me.LinkLabel2.Text = "Au"
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Duree_Du
        '
        Me.Duree_Du.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Duree_Du.ContextMenuStrip = Nothing
        Me.Duree_Du.Location = New System.Drawing.Point(80, 1)
        Me.Duree_Du.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.Duree_Du.MaxLength = 32767
        Me.Duree_Du.Multiline = False
        Me.Duree_Du.Name = "Duree_Du"
        Me.Duree_Du.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Duree_Du.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Duree_Du.ReadOnly = True
        Me.Duree_Du.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Duree_Du.SelectionStart = 0
        Me.Duree_Du.Size = New System.Drawing.Size(104, 32)
        Me.Duree_Du.TabIndex = 251
        Me.Duree_Du.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Duree_Du.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(46, 8)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(28, 19)
        Me.LinkLabel1.TabIndex = 273
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "SC"
        Me.LinkLabel1.Text = "Du"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Rd_Duree_0
        '
        Me.Rd_Duree_0.AutoSize = True
        Me.Rd_Duree_0.Checked = True
        Me.Rd_Duree_0.Location = New System.Drawing.Point(136, 245)
        Me.Rd_Duree_0.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Rd_Duree_0.MaximumSize = New System.Drawing.Size(0, 39)
        Me.Rd_Duree_0.MinimumSize = New System.Drawing.Size(0, 39)
        Me.Rd_Duree_0.Name = "Rd_Duree_0"
        Me.Rd_Duree_0.Size = New System.Drawing.Size(179, 39)
        Me.Rd_Duree_0.TabIndex = 259
        Me.Rd_Duree_0.Text = "Durée indeterminée"
        '
        'Rd_Duree_1
        '
        Me.Rd_Duree_1.AutoSize = True
        Me.Rd_Duree_1.Checked = False
        Me.Rd_Duree_1.Location = New System.Drawing.Point(136, 286)
        Me.Rd_Duree_1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Rd_Duree_1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Duree_1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Duree_1.Name = "Rd_Duree_1"
        Me.Rd_Duree_1.Size = New System.Drawing.Size(167, 31)
        Me.Rd_Duree_1.TabIndex = 259
        Me.Rd_Duree_1.Text = "Durée determinée"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(82, 158)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 19)
        Me.Label5.TabIndex = 258
        Me.Label5.Text = "Titre"
        '
        'Titre_DR_txt
        '
        Me.Titre_DR_txt.AccessibleDescription = "A"
        Me.Titre_DR_txt.AutoSize = True
        Me.Titre_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Titre_DR_txt.ContextMenuStrip = Nothing
        Me.Titre_DR_txt.Location = New System.Drawing.Point(125, 154)
        Me.Titre_DR_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Titre_DR_txt.MaxLength = 490
        Me.Titre_DR_txt.Multiline = True
        Me.Titre_DR_txt.Name = "Titre_DR_txt"
        Me.Titre_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Titre_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Titre_DR_txt.ReadOnly = False
        Me.Titre_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Titre_DR_txt.SelectionStart = 0
        Me.Titre_DR_txt.Size = New System.Drawing.Size(654, 80)
        Me.Titre_DR_txt.TabIndex = 253
        Me.Titre_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Titre_DR_txt.UseSystemPasswordChar = False
        '
        'Cod_Poste_DR_txt
        '
        Me.Cod_Poste_DR_txt.AutoSize = True
        Me.Cod_Poste_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Poste_DR_txt.ContextMenuStrip = Nothing
        Me.Cod_Poste_DR_txt.Location = New System.Drawing.Point(125, 112)
        Me.Cod_Poste_DR_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Poste_DR_txt.MaxLength = 6
        Me.Cod_Poste_DR_txt.Multiline = False
        Me.Cod_Poste_DR_txt.Name = "Cod_Poste_DR_txt"
        Me.Cod_Poste_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Poste_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Poste_DR_txt.ReadOnly = True
        Me.Cod_Poste_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Poste_DR_txt.SelectionStart = 0
        Me.Cod_Poste_DR_txt.Size = New System.Drawing.Size(114, 32)
        Me.Cod_Poste_DR_txt.TabIndex = 255
        Me.Cod_Poste_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Poste_DR_txt.UseSystemPasswordChar = False
        '
        'Grade_
        '
        Me.Grade_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.AutoSize = True
        Me.Grade_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Location = New System.Drawing.Point(66, 81)
        Me.Grade_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Grade_.Name = "Grade_"
        Me.Grade_.Size = New System.Drawing.Size(54, 19)
        Me.Grade_.TabIndex = 252
        Me.Grade_.TabStop = True
        Me.Grade_.Tag = "NC"
        Me.Grade_.Text = "Grade"
        '
        'Lib_Poste_DR_txt
        '
        Me.Lib_Poste_DR_txt.AutoSize = True
        Me.Lib_Poste_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Poste_DR_txt.ContextMenuStrip = Nothing
        Me.Lib_Poste_DR_txt.Location = New System.Drawing.Point(242, 112)
        Me.Lib_Poste_DR_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Poste_DR_txt.MaxLength = 50
        Me.Lib_Poste_DR_txt.Multiline = False
        Me.Lib_Poste_DR_txt.Name = "Lib_Poste_DR_txt"
        Me.Lib_Poste_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_DR_txt.ReadOnly = True
        Me.Lib_Poste_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_DR_txt.SelectionStart = 0
        Me.Lib_Poste_DR_txt.Size = New System.Drawing.Size(536, 32)
        Me.Lib_Poste_DR_txt.TabIndex = 254
        Me.Lib_Poste_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_DR_txt.UseSystemPasswordChar = False
        '
        'Cod_Grade_DR_txt
        '
        Me.Cod_Grade_DR_txt.AutoSize = True
        Me.Cod_Grade_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Grade_DR_txt.ContextMenuStrip = Nothing
        Me.Cod_Grade_DR_txt.Location = New System.Drawing.Point(125, 75)
        Me.Cod_Grade_DR_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Grade_DR_txt.MaxLength = 6
        Me.Cod_Grade_DR_txt.Multiline = False
        Me.Cod_Grade_DR_txt.Name = "Cod_Grade_DR_txt"
        Me.Cod_Grade_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Grade_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Grade_DR_txt.ReadOnly = True
        Me.Cod_Grade_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Grade_DR_txt.SelectionStart = 0
        Me.Cod_Grade_DR_txt.Size = New System.Drawing.Size(114, 32)
        Me.Cod_Grade_DR_txt.TabIndex = 257
        Me.Cod_Grade_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Grade_DR_txt.UseSystemPasswordChar = False
        '
        'Poste_
        '
        Me.Poste_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Poste_.AutoSize = True
        Me.Poste_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Poste_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Poste_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Poste_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Poste_.Location = New System.Drawing.Point(74, 118)
        Me.Poste_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Poste_.Name = "Poste_"
        Me.Poste_.Size = New System.Drawing.Size(45, 19)
        Me.Poste_.TabIndex = 251
        Me.Poste_.TabStop = True
        Me.Poste_.Tag = "NC"
        Me.Poste_.Text = "Poste"
        '
        'Lib_Grade_DR_txt
        '
        Me.Lib_Grade_DR_txt.AutoSize = True
        Me.Lib_Grade_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_DR_txt.ContextMenuStrip = Nothing
        Me.Lib_Grade_DR_txt.Location = New System.Drawing.Point(242, 75)
        Me.Lib_Grade_DR_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Grade_DR_txt.MaxLength = 50
        Me.Lib_Grade_DR_txt.Multiline = False
        Me.Lib_Grade_DR_txt.Name = "Lib_Grade_DR_txt"
        Me.Lib_Grade_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_DR_txt.ReadOnly = True
        Me.Lib_Grade_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_DR_txt.SelectionStart = 0
        Me.Lib_Grade_DR_txt.Size = New System.Drawing.Size(536, 32)
        Me.Lib_Grade_DR_txt.TabIndex = 256
        Me.Lib_Grade_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_DR_txt.UseSystemPasswordChar = False
        '
        'Buget_Salaire_txt
        '
        Me.Buget_Salaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Buget_Salaire_txt.ContextMenuStrip = Nothing
        Me.Buget_Salaire_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Buget_Salaire_txt.Location = New System.Drawing.Point(672, 331)
        Me.Buget_Salaire_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Buget_Salaire_txt.MaxLength = 32767
        Me.Buget_Salaire_txt.Multiline = False
        Me.Buget_Salaire_txt.Name = "Buget_Salaire_txt"
        Me.Buget_Salaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Buget_Salaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Buget_Salaire_txt.ReadOnly = False
        Me.Buget_Salaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Buget_Salaire_txt.SelectionStart = 0
        Me.Buget_Salaire_txt.Size = New System.Drawing.Size(106, 26)
        Me.Buget_Salaire_txt.TabIndex = 247
        Me.Buget_Salaire_txt.Text = "0,00"
        Me.Buget_Salaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Buget_Salaire_txt.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(444, 334)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(230, 19)
        Me.Label6.TabIndex = 241
        Me.Label6.Text = "Budget de salaire par personne "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(78, 578)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 19)
        Me.Label11.TabIndex = 241
        Me.Label11.Text = "Motif"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label17.Location = New System.Drawing.Point(58, 331)
        Me.Label17.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 19)
        Me.Label17.TabIndex = 241
        Me.Label17.Text = "Nombre"
        '
        'CompetencesRequises
        '
        Me.CompetencesRequises.Controls.Add(Me.Domaines_Competence_Pnl)
        Me.CompetencesRequises.Controls.Add(Me.ChargerCompetencesPoste_btn)
        Me.CompetencesRequises.Controls.Add(Me.GroupBox6)
        Me.CompetencesRequises.Controls.Add(Me.GroupBox5)
        Me.CompetencesRequises.Location = New System.Drawing.Point(4, 28)
        Me.CompetencesRequises.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CompetencesRequises.Name = "CompetencesRequises"
        Me.CompetencesRequises.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CompetencesRequises.Size = New System.Drawing.Size(914, 769)
        Me.CompetencesRequises.TabIndex = 1
        Me.CompetencesRequises.Text = "Compétences requises"
        Me.CompetencesRequises.UseVisualStyleBackColor = True
        '
        'Domaines_Competence_Pnl
        '
        Me.Domaines_Competence_Pnl.AutoScroll = True
        Me.Domaines_Competence_Pnl.BackColor = System.Drawing.Color.White
        Me.Domaines_Competence_Pnl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Domaines_Competence_Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Domaines_Competence_Pnl.Location = New System.Drawing.Point(4, 260)
        Me.Domaines_Competence_Pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.Domaines_Competence_Pnl.Name = "Domaines_Competence_Pnl"
        Me.Domaines_Competence_Pnl.Size = New System.Drawing.Size(906, 505)
        Me.Domaines_Competence_Pnl.TabIndex = 1
        '
        'ChargerCompetencesPoste_btn
        '
        Me.ChargerCompetencesPoste_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ChargerCompetencesPoste_btn.bgColor = System.Drawing.Color.White
        Me.ChargerCompetencesPoste_btn.Border = RHP.ud_button.BorderStyle.None
        Me.ChargerCompetencesPoste_btn.BorderColor = System.Drawing.Color.Empty
        Me.ChargerCompetencesPoste_btn.BorderSize = 0
        Me.ChargerCompetencesPoste_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChargerCompetencesPoste_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.ChargerCompetencesPoste_btn.Image = Global.RHP.My.Resources.Resources.btn_execute
        Me.ChargerCompetencesPoste_btn.isDefault = False
        Me.ChargerCompetencesPoste_btn.Location = New System.Drawing.Point(4, 221)
        Me.ChargerCompetencesPoste_btn.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.ChargerCompetencesPoste_btn.MinimumSize = New System.Drawing.Size(34, 39)
        Me.ChargerCompetencesPoste_btn.Name = "ChargerCompetencesPoste_btn"
        Me.ChargerCompetencesPoste_btn.Size = New System.Drawing.Size(906, 39)
        Me.ChargerCompetencesPoste_btn.TabIndex = 234
        Me.ChargerCompetencesPoste_btn.Text = "Charger les compétences requises pour ce poste"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Parcours_txt)
        Me.GroupBox6.Controls.Add(Me.Experience)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox6.Location = New System.Drawing.Point(4, 96)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(906, 125)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Exérience requise"
        '
        'Parcours_txt
        '
        Me.Parcours_txt.AccessibleDescription = "A"
        Me.Parcours_txt.AutoSize = True
        Me.Parcours_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Parcours_txt.ContextMenuStrip = Nothing
        Me.Parcours_txt.Location = New System.Drawing.Point(455, 28)
        Me.Parcours_txt.Margin = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.Parcours_txt.MaxLength = 490
        Me.Parcours_txt.Multiline = True
        Me.Parcours_txt.Name = "Parcours_txt"
        Me.Parcours_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Parcours_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Parcours_txt.ReadOnly = False
        Me.Parcours_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Parcours_txt.SelectionStart = 0
        Me.Parcours_txt.Size = New System.Drawing.Size(426, 85)
        Me.Parcours_txt.TabIndex = 260
        Me.Parcours_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Parcours_txt.UseSystemPasswordChar = False
        '
        'Experience
        '
        Me.Experience.Location = New System.Drawing.Point(181, 51)
        Me.Experience.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Experience.Name = "Experience"
        Me.Experience.Size = New System.Drawing.Size(110, 24)
        Me.Experience.TabIndex = 276
        Me.Experience.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(382, 54)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 19)
        Me.Label10.TabIndex = 259
        Me.Label10.Text = "Parcours"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(26, 54)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(163, 19)
        Me.Label9.TabIndex = 259
        Me.Label9.Text = "Années d'expériences "
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Etablissement_txt)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Niveau)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(906, 92)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Formation requise"
        '
        'Etablissement_txt
        '
        Me.Etablissement_txt.AccessibleDescription = "A"
        Me.Etablissement_txt.AutoSize = True
        Me.Etablissement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Etablissement_txt.ContextMenuStrip = Nothing
        Me.Etablissement_txt.Location = New System.Drawing.Point(456, 15)
        Me.Etablissement_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Etablissement_txt.MaxLength = 490
        Me.Etablissement_txt.Multiline = True
        Me.Etablissement_txt.Name = "Etablissement_txt"
        Me.Etablissement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Etablissement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Etablissement_txt.ReadOnly = False
        Me.Etablissement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Etablissement_txt.SelectionStart = 0
        Me.Etablissement_txt.Size = New System.Drawing.Size(426, 69)
        Me.Etablissement_txt.TabIndex = 260
        Me.Etablissement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Etablissement_txt.UseSystemPasswordChar = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(345, 41)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 19)
        Me.Label8.TabIndex = 259
        Me.Label8.Text = "Etablissements"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(26, 38)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 19)
        Me.Label7.TabIndex = 259
        Me.Label7.Text = "Niveau"
        '
        'Niveau
        '
        Me.Niveau.DataSource = Nothing
        Me.Niveau.DisplayMember = ""
        Me.Niveau.DroppedDown = False
        Me.Niveau.Location = New System.Drawing.Point(91, 34)
        Me.Niveau.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Niveau.Name = "Niveau"
        Me.Niveau.SelectedIndex = -1
        Me.Niveau.SelectedItem = Nothing
        Me.Niveau.SelectedValue = Nothing
        Me.Niveau.Size = New System.Drawing.Size(242, 32)
        Me.Niveau.TabIndex = 229
        Me.Niveau.Tag = "NC"
        Me.Niveau.ValueMember = ""
        '
        'Narratif
        '
        Me.Narratif.Controls.Add(Me.Narratif_rtb)
        Me.Narratif.Location = New System.Drawing.Point(4, 28)
        Me.Narratif.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Narratif.Name = "Narratif"
        Me.Narratif.Size = New System.Drawing.Size(914, 769)
        Me.Narratif.TabIndex = 2
        Me.Narratif.Text = "Narratif"
        Me.Narratif.UseVisualStyleBackColor = True
        '
        'Narratif_rtb
        '
        Me.Narratif_rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Narratif_rtb.Location = New System.Drawing.Point(0, 0)
        Me.Narratif_rtb.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Narratif_rtb.Name = "Narratif_rtb"
        Me.Narratif_rtb.ReadOnly = False
        Me.Narratif_rtb.Size = New System.Drawing.Size(914, 769)
        Me.Narratif_rtb.TabIndex = 0
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.ContextMenuStrip = Nothing
        Me.Commentaire_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Commentaire_txt.Location = New System.Drawing.Point(0, 135)
        Me.Commentaire_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Commentaire_txt.MaxLength = 32767
        Me.Commentaire_txt.Multiline = True
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(922, 801)
        Me.Commentaire_txt.TabIndex = 258
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Lib_DR_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel4)
        Me.GroupBox2.Controls.Add(Me.Num_DR_txt)
        Me.GroupBox2.Controls.Add(Me.pb_Valide)
        Me.GroupBox2.Controls.Add(Me.Dat_DR_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(922, 135)
        Me.GroupBox2.TabIndex = 256
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Demandeur"
        '
        'Lib_DR_txt
        '
        Me.Lib_DR_txt.AccessibleDescription = "A"
        Me.Lib_DR_txt.AutoSize = True
        Me.Lib_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_DR_txt.ContextMenuStrip = Nothing
        Me.Lib_DR_txt.Location = New System.Drawing.Point(15, 62)
        Me.Lib_DR_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Lib_DR_txt.MaxLength = 490
        Me.Lib_DR_txt.Multiline = True
        Me.Lib_DR_txt.Name = "Lib_DR_txt"
        Me.Lib_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_DR_txt.ReadOnly = False
        Me.Lib_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_DR_txt.SelectionStart = 0
        Me.Lib_DR_txt.Size = New System.Drawing.Size(710, 60)
        Me.Lib_DR_txt.TabIndex = 274
        Me.Lib_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_DR_txt.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(476, 29)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(157, 19)
        Me.LinkLabel4.TabIndex = 273
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Date de la demande"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Num_DR_txt
        '
        Me.Num_DR_txt.AccessibleDescription = "A"
        Me.Num_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_DR_txt.ContextMenuStrip = Nothing
        Me.Num_DR_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_DR_txt.Location = New System.Drawing.Point(138, 29)
        Me.Num_DR_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Num_DR_txt.MaxLength = 32767
        Me.Num_DR_txt.Multiline = False
        Me.Num_DR_txt.Name = "Num_DR_txt"
        Me.Num_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_DR_txt.ReadOnly = True
        Me.Num_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_DR_txt.SelectionStart = 0
        Me.Num_DR_txt.Size = New System.Drawing.Size(175, 26)
        Me.Num_DR_txt.TabIndex = 248
        Me.Num_DR_txt.TabStop = False
        Me.Num_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_DR_txt.UseSystemPasswordChar = False
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(805, 16)
        Me.pb_Valide.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(105, 106)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Valide.TabIndex = 253
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'Dat_DR_txt
        '
        Me.Dat_DR_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_DR_txt.ContextMenuStrip = Nothing
        Me.Dat_DR_txt.Location = New System.Drawing.Point(636, 25)
        Me.Dat_DR_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Dat_DR_txt.MaxLength = 32767
        Me.Dat_DR_txt.Multiline = False
        Me.Dat_DR_txt.Name = "Dat_DR_txt"
        Me.Dat_DR_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_DR_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_DR_txt.ReadOnly = True
        Me.Dat_DR_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_DR_txt.SelectionStart = 0
        Me.Dat_DR_txt.Size = New System.Drawing.Size(89, 26)
        Me.Dat_DR_txt.TabIndex = 251
        Me.Dat_DR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_DR_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(35, 31)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(99, 19)
        Me.LinkLabel3.TabIndex = 249
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SC"
        Me.LinkLabel3.Text = "N° demande"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Recrutement_Demande
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(922, 936)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "Recrutement_Demande"
        Me.Tag = "ECR"
        Me.Text = "Demande de recrutement"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.Demandeur.ResumeLayout(False)
        Me.Demandeur.PerformLayout()
        Me.DetailDemande.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Age_pnl.ResumeLayout(False)
        Me.Age_pnl.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Nb_Personne, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Duree_pnl.ResumeLayout(False)
        Me.Duree_pnl.PerformLayout()
        Me.CompetencesRequises.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.Experience, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Narratif.ResumeLayout(False)
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
    Friend WithEvents Cod_Poste_txt As ud_TextBox
    Friend WithEvents Lib_Poste_Text As ud_TextBox
    Friend WithEvents Cod_Grade_txt As ud_TextBox
    Friend WithEvents Lib_Grade_Text As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Buget_Salaire_txt As ud_TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Dat_DR_txt As ud_TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Num_DR_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Commentaire_txt As ud_TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents DetailDemande As TabPage
    Friend WithEvents CompetencesRequises As TabPage
    Friend WithEvents Narratif As TabPage
    Friend WithEvents Nb_Personne As NumericUpDown
    Friend WithEvents Duree_pnl As Panel
    Friend WithEvents Duree_Au As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Duree_Du As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Rd_Duree_0 As ud_RadioBox
    Friend WithEvents Rd_Duree_1 As ud_RadioBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Titre_DR_txt As ud_TextBox
    Friend WithEvents Cod_Poste_DR_txt As ud_TextBox
    Friend WithEvents Grade_ As LinkLabel
    Friend WithEvents Lib_Poste_DR_txt As ud_TextBox
    Friend WithEvents Cod_Grade_DR_txt As ud_TextBox
    Friend WithEvents Poste_ As LinkLabel
    Friend WithEvents Lib_Grade_DR_txt As ud_TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Sexe_Indifferent_rd As ud_RadioBox
    Friend WithEvents Sexe_Femme_rd As ud_RadioBox
    Friend WithEvents Sexe_Homme_rd As ud_RadioBox
    Friend WithEvents Cod_Entite_DR_txt As ud_TextBox
    Friend WithEvents Lib_Entite_DR_txt As ud_TextBox
    Friend WithEvents Entite_ As LinkLabel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Age_pnl As Panel
    Friend WithEvents Age_Au As ud_TextBox
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents Age_Du As ud_TextBox
    Friend WithEvents Rd_Age_1 As ud_RadioBox
    Friend WithEvents Rd_Age_0 As ud_RadioBox
    Friend WithEvents Domaines_Competence_Pnl As Panel
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Niveau As ud_ComboBox
    Friend WithEvents Parcours_txt As ud_TextBox
    Friend WithEvents Experience As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Etablissement_txt As ud_TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Narratif_rtb As ud_RichTextBox
    Friend WithEvents Demandeur As TabPage
    Friend WithEvents Lib_DR_txt As ud_TextBox
    Friend WithEvents Motif_DR As ud_ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ChargerCompetencesPoste_btn As ud_button
End Class
