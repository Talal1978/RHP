<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Avancement
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Nouvelle_Entite_txt = New RHP.ud_TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Nouveau_Titre_txt = New RHP.ud_TextBox()
        Me.Nouveau_Grade_txt = New RHP.ud_TextBox()
        Me.Nouveau_Poste_txt = New RHP.ud_TextBox()
        Me.Lib_Nouvelle_Entite_txt = New RHP.ud_TextBox()
        Me.Lib_Nouveau_Poste_txt = New RHP.ud_TextBox()
        Me.Lib_Nouveau_Grade_txt = New RHP.ud_TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Ancienne_Entite_txt = New RHP.ud_TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Ancien_Titre_txt = New RHP.ud_TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Ancien_Grade_txt = New RHP.ud_TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Ancien_Poste_txt = New RHP.ud_TextBox()
        Me.Lib_Ancienne_Entite_txt = New RHP.ud_TextBox()
        Me.Lib_Ancien_Poste_txt = New RHP.ud_TextBox()
        Me.Lib_Ancien_Grade_txt = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Motif_txt = New RHP.ud_TextBox()
        Me.Observation_txt = New RHP.ud_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dat_Entree_txt = New RHP.ud_TextBox()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Avancement_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.Cod_Avancement_txt = New RHP.ud_TextBox()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Type_Avancement_cmb = New RHP.ud_ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Dat_Effet_txt = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Decision_txt = New RHP.ud_TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1139, 608)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Motif_txt)
        Me.GroupBox2.Controls.Add(Me.Observation_txt)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 178)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1139, 430)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Détail Avancement"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LinkLabel5)
        Me.GroupBox4.Controls.Add(Me.LinkLabel4)
        Me.GroupBox4.Controls.Add(Me.LinkLabel3)
        Me.GroupBox4.Controls.Add(Me.Nouvelle_Entite_txt)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Nouveau_Titre_txt)
        Me.GroupBox4.Controls.Add(Me.Nouveau_Grade_txt)
        Me.GroupBox4.Controls.Add(Me.Nouveau_Poste_txt)
        Me.GroupBox4.Controls.Add(Me.Lib_Nouvelle_Entite_txt)
        Me.GroupBox4.Controls.Add(Me.Lib_Nouveau_Poste_txt)
        Me.GroupBox4.Controls.Add(Me.Lib_Nouveau_Grade_txt)
        Me.GroupBox4.Location = New System.Drawing.Point(576, 30)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(551, 160)
        Me.GroupBox4.TabIndex = 267
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Nouvelle Situation"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.Location = New System.Drawing.Point(49, 123)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(48, 19)
        Me.LinkLabel5.TabIndex = 268
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Entité"
        Me.LinkLabel5.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(43, 60)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(54, 19)
        Me.LinkLabel4.TabIndex = 264
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Grade"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(52, 29)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(45, 19)
        Me.LinkLabel3.TabIndex = 267
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Poste"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Nouvelle_Entite_txt
        '
        Me.Nouvelle_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nouvelle_Entite_txt.ContextMenuStrip = Nothing
        Me.Nouvelle_Entite_txt.Location = New System.Drawing.Point(100, 119)
        Me.Nouvelle_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nouvelle_Entite_txt.MaxLength = 10
        Me.Nouvelle_Entite_txt.Multiline = False
        Me.Nouvelle_Entite_txt.Name = "Nouvelle_Entite_txt"
        Me.Nouvelle_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nouvelle_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nouvelle_Entite_txt.ReadOnly = True
        Me.Nouvelle_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nouvelle_Entite_txt.SelectionStart = 0
        Me.Nouvelle_Entite_txt.Size = New System.Drawing.Size(100, 26)
        Me.Nouvelle_Entite_txt.TabIndex = 262
        Me.Nouvelle_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nouvelle_Entite_txt.UseSystemPasswordChar = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(61, 91)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 19)
        Me.Label14.TabIndex = 261
        Me.Label14.Text = "Titre"
        '
        'Nouveau_Titre_txt
        '
        Me.Nouveau_Titre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nouveau_Titre_txt.ContextMenuStrip = Nothing
        Me.Nouveau_Titre_txt.Location = New System.Drawing.Point(100, 88)
        Me.Nouveau_Titre_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nouveau_Titre_txt.MaxLength = 100
        Me.Nouveau_Titre_txt.Multiline = False
        Me.Nouveau_Titre_txt.Name = "Nouveau_Titre_txt"
        Me.Nouveau_Titre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nouveau_Titre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nouveau_Titre_txt.ReadOnly = False
        Me.Nouveau_Titre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nouveau_Titre_txt.SelectionStart = 0
        Me.Nouveau_Titre_txt.Size = New System.Drawing.Size(435, 26)
        Me.Nouveau_Titre_txt.TabIndex = 260
        Me.Nouveau_Titre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nouveau_Titre_txt.UseSystemPasswordChar = False
        '
        'Nouveau_Grade_txt
        '
        Me.Nouveau_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nouveau_Grade_txt.ContextMenuStrip = Nothing
        Me.Nouveau_Grade_txt.Location = New System.Drawing.Point(100, 57)
        Me.Nouveau_Grade_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nouveau_Grade_txt.MaxLength = 10
        Me.Nouveau_Grade_txt.Multiline = False
        Me.Nouveau_Grade_txt.Name = "Nouveau_Grade_txt"
        Me.Nouveau_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nouveau_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nouveau_Grade_txt.ReadOnly = True
        Me.Nouveau_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nouveau_Grade_txt.SelectionStart = 0
        Me.Nouveau_Grade_txt.Size = New System.Drawing.Size(100, 26)
        Me.Nouveau_Grade_txt.TabIndex = 258
        Me.Nouveau_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nouveau_Grade_txt.UseSystemPasswordChar = False
        '
        'Nouveau_Poste_txt
        '
        Me.Nouveau_Poste_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nouveau_Poste_txt.ContextMenuStrip = Nothing
        Me.Nouveau_Poste_txt.Location = New System.Drawing.Point(100, 26)
        Me.Nouveau_Poste_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nouveau_Poste_txt.MaxLength = 10
        Me.Nouveau_Poste_txt.Multiline = False
        Me.Nouveau_Poste_txt.Name = "Nouveau_Poste_txt"
        Me.Nouveau_Poste_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nouveau_Poste_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nouveau_Poste_txt.ReadOnly = True
        Me.Nouveau_Poste_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nouveau_Poste_txt.SelectionStart = 0
        Me.Nouveau_Poste_txt.Size = New System.Drawing.Size(100, 26)
        Me.Nouveau_Poste_txt.TabIndex = 256
        Me.Nouveau_Poste_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nouveau_Poste_txt.UseSystemPasswordChar = False
        '
        'Lib_Nouvelle_Entite_txt
        '
        Me.Lib_Nouvelle_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Nouvelle_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Nouvelle_Entite_txt.Location = New System.Drawing.Point(208, 119)
        Me.Lib_Nouvelle_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Nouvelle_Entite_txt.MaxLength = 100
        Me.Lib_Nouvelle_Entite_txt.Multiline = False
        Me.Lib_Nouvelle_Entite_txt.Name = "Lib_Nouvelle_Entite_txt"
        Me.Lib_Nouvelle_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Nouvelle_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Nouvelle_Entite_txt.ReadOnly = True
        Me.Lib_Nouvelle_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Nouvelle_Entite_txt.SelectionStart = 0
        Me.Lib_Nouvelle_Entite_txt.Size = New System.Drawing.Size(327, 26)
        Me.Lib_Nouvelle_Entite_txt.TabIndex = 264
        Me.Lib_Nouvelle_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Nouvelle_Entite_txt.UseSystemPasswordChar = False
        '
        'Lib_Nouveau_Poste_txt
        '
        Me.Lib_Nouveau_Poste_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Nouveau_Poste_txt.ContextMenuStrip = Nothing
        Me.Lib_Nouveau_Poste_txt.Location = New System.Drawing.Point(208, 26)
        Me.Lib_Nouveau_Poste_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Nouveau_Poste_txt.MaxLength = 100
        Me.Lib_Nouveau_Poste_txt.Multiline = False
        Me.Lib_Nouveau_Poste_txt.Name = "Lib_Nouveau_Poste_txt"
        Me.Lib_Nouveau_Poste_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Nouveau_Poste_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Nouveau_Poste_txt.ReadOnly = True
        Me.Lib_Nouveau_Poste_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Nouveau_Poste_txt.SelectionStart = 0
        Me.Lib_Nouveau_Poste_txt.Size = New System.Drawing.Size(327, 26)
        Me.Lib_Nouveau_Poste_txt.TabIndex = 265
        Me.Lib_Nouveau_Poste_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Nouveau_Poste_txt.UseSystemPasswordChar = False
        '
        'Lib_Nouveau_Grade_txt
        '
        Me.Lib_Nouveau_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Nouveau_Grade_txt.ContextMenuStrip = Nothing
        Me.Lib_Nouveau_Grade_txt.Location = New System.Drawing.Point(208, 57)
        Me.Lib_Nouveau_Grade_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Nouveau_Grade_txt.MaxLength = 100
        Me.Lib_Nouveau_Grade_txt.Multiline = False
        Me.Lib_Nouveau_Grade_txt.Name = "Lib_Nouveau_Grade_txt"
        Me.Lib_Nouveau_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Nouveau_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Nouveau_Grade_txt.ReadOnly = True
        Me.Lib_Nouveau_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Nouveau_Grade_txt.SelectionStart = 0
        Me.Lib_Nouveau_Grade_txt.Size = New System.Drawing.Size(327, 26)
        Me.Lib_Nouveau_Grade_txt.TabIndex = 266
        Me.Lib_Nouveau_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Nouveau_Grade_txt.UseSystemPasswordChar = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Ancienne_Entite_txt)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Ancien_Titre_txt)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Ancien_Grade_txt)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Ancien_Poste_txt)
        Me.GroupBox3.Controls.Add(Me.Lib_Ancienne_Entite_txt)
        Me.GroupBox3.Controls.Add(Me.Lib_Ancien_Poste_txt)
        Me.GroupBox3.Controls.Add(Me.Lib_Ancien_Grade_txt)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(551, 160)
        Me.GroupBox3.TabIndex = 266
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ancienne Situation"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(50, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 19)
        Me.Label12.TabIndex = 263
        Me.Label12.Text = "Entité"
        '
        'Ancienne_Entite_txt
        '
        Me.Ancienne_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ancienne_Entite_txt.ContextMenuStrip = Nothing
        Me.Ancienne_Entite_txt.Location = New System.Drawing.Point(100, 119)
        Me.Ancienne_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ancienne_Entite_txt.MaxLength = 10
        Me.Ancienne_Entite_txt.Multiline = False
        Me.Ancienne_Entite_txt.Name = "Ancienne_Entite_txt"
        Me.Ancienne_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ancienne_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ancienne_Entite_txt.ReadOnly = True
        Me.Ancienne_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ancienne_Entite_txt.SelectionStart = 0
        Me.Ancienne_Entite_txt.Size = New System.Drawing.Size(100, 26)
        Me.Ancienne_Entite_txt.TabIndex = 262
        Me.Ancienne_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ancienne_Entite_txt.UseSystemPasswordChar = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(63, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 19)
        Me.Label11.TabIndex = 261
        Me.Label11.Text = "Titre"
        '
        'Ancien_Titre_txt
        '
        Me.Ancien_Titre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ancien_Titre_txt.ContextMenuStrip = Nothing
        Me.Ancien_Titre_txt.Location = New System.Drawing.Point(100, 88)
        Me.Ancien_Titre_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ancien_Titre_txt.MaxLength = 100
        Me.Ancien_Titre_txt.Multiline = False
        Me.Ancien_Titre_txt.Name = "Ancien_Titre_txt"
        Me.Ancien_Titre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ancien_Titre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ancien_Titre_txt.ReadOnly = True
        Me.Ancien_Titre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ancien_Titre_txt.SelectionStart = 0
        Me.Ancien_Titre_txt.Size = New System.Drawing.Size(435, 26)
        Me.Ancien_Titre_txt.TabIndex = 260
        Me.Ancien_Titre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ancien_Titre_txt.UseSystemPasswordChar = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(43, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 19)
        Me.Label10.TabIndex = 259
        Me.Label10.Text = "Grade"
        '
        'Ancien_Grade_txt
        '
        Me.Ancien_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ancien_Grade_txt.ContextMenuStrip = Nothing
        Me.Ancien_Grade_txt.Location = New System.Drawing.Point(100, 57)
        Me.Ancien_Grade_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ancien_Grade_txt.MaxLength = 10
        Me.Ancien_Grade_txt.Multiline = False
        Me.Ancien_Grade_txt.Name = "Ancien_Grade_txt"
        Me.Ancien_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ancien_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ancien_Grade_txt.ReadOnly = True
        Me.Ancien_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ancien_Grade_txt.SelectionStart = 0
        Me.Ancien_Grade_txt.Size = New System.Drawing.Size(100, 26)
        Me.Ancien_Grade_txt.TabIndex = 258
        Me.Ancien_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ancien_Grade_txt.UseSystemPasswordChar = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 19)
        Me.Label9.TabIndex = 257
        Me.Label9.Text = "Poste"
        '
        'Ancien_Poste_txt
        '
        Me.Ancien_Poste_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ancien_Poste_txt.ContextMenuStrip = Nothing
        Me.Ancien_Poste_txt.Location = New System.Drawing.Point(100, 26)
        Me.Ancien_Poste_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ancien_Poste_txt.MaxLength = 10
        Me.Ancien_Poste_txt.Multiline = False
        Me.Ancien_Poste_txt.Name = "Ancien_Poste_txt"
        Me.Ancien_Poste_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ancien_Poste_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ancien_Poste_txt.ReadOnly = True
        Me.Ancien_Poste_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ancien_Poste_txt.SelectionStart = 0
        Me.Ancien_Poste_txt.Size = New System.Drawing.Size(100, 26)
        Me.Ancien_Poste_txt.TabIndex = 256
        Me.Ancien_Poste_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ancien_Poste_txt.UseSystemPasswordChar = False
        '
        'Lib_Ancienne_Entite_txt
        '
        Me.Lib_Ancienne_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Ancienne_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Ancienne_Entite_txt.Location = New System.Drawing.Point(208, 119)
        Me.Lib_Ancienne_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Ancienne_Entite_txt.MaxLength = 100
        Me.Lib_Ancienne_Entite_txt.Multiline = False
        Me.Lib_Ancienne_Entite_txt.Name = "Lib_Ancienne_Entite_txt"
        Me.Lib_Ancienne_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Ancienne_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Ancienne_Entite_txt.ReadOnly = True
        Me.Lib_Ancienne_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Ancienne_Entite_txt.SelectionStart = 0
        Me.Lib_Ancienne_Entite_txt.Size = New System.Drawing.Size(327, 26)
        Me.Lib_Ancienne_Entite_txt.TabIndex = 264
        Me.Lib_Ancienne_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Ancienne_Entite_txt.UseSystemPasswordChar = False
        '
        'Lib_Ancien_Poste_txt
        '
        Me.Lib_Ancien_Poste_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Ancien_Poste_txt.ContextMenuStrip = Nothing
        Me.Lib_Ancien_Poste_txt.Location = New System.Drawing.Point(208, 26)
        Me.Lib_Ancien_Poste_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Ancien_Poste_txt.MaxLength = 100
        Me.Lib_Ancien_Poste_txt.Multiline = False
        Me.Lib_Ancien_Poste_txt.Name = "Lib_Ancien_Poste_txt"
        Me.Lib_Ancien_Poste_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Ancien_Poste_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Ancien_Poste_txt.ReadOnly = True
        Me.Lib_Ancien_Poste_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Ancien_Poste_txt.SelectionStart = 0
        Me.Lib_Ancien_Poste_txt.Size = New System.Drawing.Size(327, 26)
        Me.Lib_Ancien_Poste_txt.TabIndex = 265
        Me.Lib_Ancien_Poste_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Ancien_Poste_txt.UseSystemPasswordChar = False
        '
        'Lib_Ancien_Grade_txt
        '
        Me.Lib_Ancien_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Ancien_Grade_txt.ContextMenuStrip = Nothing
        Me.Lib_Ancien_Grade_txt.Location = New System.Drawing.Point(208, 57)
        Me.Lib_Ancien_Grade_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Ancien_Grade_txt.MaxLength = 100
        Me.Lib_Ancien_Grade_txt.Multiline = False
        Me.Lib_Ancien_Grade_txt.Name = "Lib_Ancien_Grade_txt"
        Me.Lib_Ancien_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Ancien_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Ancien_Grade_txt.ReadOnly = True
        Me.Lib_Ancien_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Ancien_Grade_txt.SelectionStart = 0
        Me.Lib_Ancien_Grade_txt.Size = New System.Drawing.Size(327, 26)
        Me.Lib_Ancien_Grade_txt.TabIndex = 266
        Me.Lib_Ancien_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Ancien_Grade_txt.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 19)
        Me.Label5.TabIndex = 265
        Me.Label5.Text = "Motif"
        '
        'Motif_txt
        '
        Me.Motif_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Motif_txt.ContextMenuStrip = Nothing
        Me.Motif_txt.Location = New System.Drawing.Point(112, 209)
        Me.Motif_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Motif_txt.MaxLength = 32767
        Me.Motif_txt.Multiline = True
        Me.Motif_txt.Name = "Motif_txt"
        Me.Motif_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Motif_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Motif_txt.ReadOnly = False
        Me.Motif_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Motif_txt.SelectionStart = 0
        Me.Motif_txt.Size = New System.Drawing.Size(997, 42)
        Me.Motif_txt.TabIndex = 263
        Me.Motif_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Motif_txt.UseSystemPasswordChar = False
        '
        'Observation_txt
        '
        Me.Observation_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Observation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Observation_txt.ContextMenuStrip = Nothing
        Me.Observation_txt.Location = New System.Drawing.Point(3, 281)
        Me.Observation_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Observation_txt.MaxLength = 32767
        Me.Observation_txt.Multiline = True
        Me.Observation_txt.Name = "Observation_txt"
        Me.Observation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Observation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Observation_txt.ReadOnly = False
        Me.Observation_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Observation_txt.SelectionStart = 0
        Me.Observation_txt.Size = New System.Drawing.Size(1133, 132)
        Me.Observation_txt.TabIndex = 1
        Me.Observation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Observation_txt.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 258)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Observation"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Dat_Entree_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel6)
        Me.GroupBox1.Controls.Add(Me.Lib_Avancement_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.pb_Valide)
        Me.GroupBox1.Controls.Add(Me.Cod_Avancement_txt)
        Me.GroupBox1.Controls.Add(Me.Matricule_txt)
        Me.GroupBox1.Controls.Add(Me.Matricule_)
        Me.GroupBox1.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox1.Controls.Add(Me.Type_Avancement_cmb)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Dat_Effet_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.Dat_Decision_txt)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1139, 178)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employé"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(667, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 19)
        Me.Label1.TabIndex = 266
        Me.Label1.Text = "Date d'entrée"
        '
        'Dat_Entree_txt
        '
        Me.Dat_Entree_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Entree_txt.ContextMenuStrip = Nothing
        Me.Dat_Entree_txt.Location = New System.Drawing.Point(775, 95)
        Me.Dat_Entree_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dat_Entree_txt.MaxLength = 10
        Me.Dat_Entree_txt.Multiline = False
        Me.Dat_Entree_txt.Name = "Dat_Entree_txt"
        Me.Dat_Entree_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Entree_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Entree_txt.ReadOnly = True
        Me.Dat_Entree_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Entree_txt.SelectionStart = 0
        Me.Dat_Entree_txt.Size = New System.Drawing.Size(100, 26)
        Me.Dat_Entree_txt.TabIndex = 265
        Me.Dat_Entree_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Entree_txt.UseSystemPasswordChar = False
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.Location = New System.Drawing.Point(40, 135)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(91, 19)
        Me.LinkLabel6.TabIndex = 264
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "Date d'effet"
        Me.LinkLabel6.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Avancement_txt
        '
        Me.Lib_Avancement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Avancement_txt.ContextMenuStrip = Nothing
        Me.Lib_Avancement_txt.Location = New System.Drawing.Point(296, 21)
        Me.Lib_Avancement_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Avancement_txt.MaxLength = 100
        Me.Lib_Avancement_txt.Multiline = False
        Me.Lib_Avancement_txt.Name = "Lib_Avancement_txt"
        Me.Lib_Avancement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Avancement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Avancement_txt.ReadOnly = False
        Me.Lib_Avancement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Avancement_txt.SelectionStart = 0
        Me.Lib_Avancement_txt.Size = New System.Drawing.Size(579, 31)
        Me.Lib_Avancement_txt.TabIndex = 263
        Me.Lib_Avancement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Avancement_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(83, 30)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(48, 19)
        Me.LinkLabel1.TabIndex = 262
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Code"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(894, 49)
        Me.pb_Valide.Margin = New System.Windows.Forms.Padding(4)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(78, 78)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Valide.TabIndex = 254
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'Cod_Avancement_txt
        '
        Me.Cod_Avancement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Avancement_txt.ContextMenuStrip = Nothing
        Me.Cod_Avancement_txt.Location = New System.Drawing.Point(134, 26)
        Me.Cod_Avancement_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Avancement_txt.MaxLength = 20
        Me.Cod_Avancement_txt.Multiline = False
        Me.Cod_Avancement_txt.Name = "Cod_Avancement_txt"
        Me.Cod_Avancement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Avancement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Avancement_txt.ReadOnly = True
        Me.Cod_Avancement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Avancement_txt.SelectionStart = 0
        Me.Cod_Avancement_txt.Size = New System.Drawing.Size(158, 26)
        Me.Cod_Avancement_txt.TabIndex = 251
        Me.Cod_Avancement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Avancement_txt.UseSystemPasswordChar = False
        '
        'Matricule_txt
        '
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(134, 61)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Matricule_txt.MaxLength = 20
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(158, 26)
        Me.Matricule_txt.TabIndex = 217
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Matricule_
        '
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(57, 65)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 216
        Me.Matricule_.TabStop = True
        Me.Matricule_.Text = "Matricule"
        Me.Matricule_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(296, 61)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Nom_Agent_Text.MaxLength = 100
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(579, 26)
        Me.Nom_Agent_Text.TabIndex = 218
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Type_Avancement_cmb
        '
        Me.Type_Avancement_cmb.DataSource = Nothing
        Me.Type_Avancement_cmb.DisplayMember = ""
        Me.Type_Avancement_cmb.DroppedDown = False
        Me.Type_Avancement_cmb.Location = New System.Drawing.Point(134, 95)
        Me.Type_Avancement_cmb.Margin = New System.Windows.Forms.Padding(4)
        Me.Type_Avancement_cmb.Name = "Type_Avancement_cmb"
        Me.Type_Avancement_cmb.SelectedIndex = -1
        Me.Type_Avancement_cmb.SelectedItem = Nothing
        Me.Type_Avancement_cmb.SelectedValue = Nothing
        Me.Type_Avancement_cmb.Size = New System.Drawing.Size(375, 29)
        Me.Type_Avancement_cmb.TabIndex = 261
        Me.Type_Avancement_cmb.ValueMember = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(89, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 19)
        Me.Label7.TabIndex = 260
        Me.Label7.Text = "Type"
        '
        'Dat_Effet_txt
        '
        Me.Dat_Effet_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Effet_txt.ContextMenuStrip = Nothing
        Me.Dat_Effet_txt.Location = New System.Drawing.Point(134, 131)
        Me.Dat_Effet_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Effet_txt.MaxLength = 10
        Me.Dat_Effet_txt.Multiline = False
        Me.Dat_Effet_txt.Name = "Dat_Effet_txt"
        Me.Dat_Effet_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Effet_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Effet_txt.ReadOnly = True
        Me.Dat_Effet_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Effet_txt.SelectionStart = 0
        Me.Dat_Effet_txt.Size = New System.Drawing.Size(100, 26)
        Me.Dat_Effet_txt.TabIndex = 258
        Me.Dat_Effet_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Effet_txt.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(302, 135)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(104, 19)
        Me.LinkLabel2.TabIndex = 259
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Date décision"
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dat_Decision_txt
        '
        Me.Dat_Decision_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Decision_txt.ContextMenuStrip = Nothing
        Me.Dat_Decision_txt.Location = New System.Drawing.Point(409, 131)
        Me.Dat_Decision_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Decision_txt.MaxLength = 10
        Me.Dat_Decision_txt.Multiline = False
        Me.Dat_Decision_txt.Name = "Dat_Decision_txt"
        Me.Dat_Decision_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Decision_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Decision_txt.ReadOnly = True
        Me.Dat_Decision_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Decision_txt.SelectionStart = 0
        Me.Dat_Decision_txt.Size = New System.Drawing.Size(100, 26)
        Me.Dat_Decision_txt.TabIndex = 256
        Me.Dat_Decision_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Decision_txt.UseSystemPasswordChar = False
        '
        'RH_Avancement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1139, 608)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Avancement"
        Me.Tag = "ECR"
        Me.Text = "Saisie Avancements et Promotions"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Dat_Decision_txt As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Dat_Effet_txt As ud_TextBox
    Friend WithEvents Type_Avancement_cmb As ud_ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Observation_txt As ud_TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Motif_txt As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Cod_Avancement_txt As ud_TextBox
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Nouvelle_Entite_txt As ud_TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Nouveau_Titre_txt As ud_TextBox
    Friend WithEvents Nouveau_Grade_txt As ud_TextBox
    Friend WithEvents Nouveau_Poste_txt As ud_TextBox
    Friend WithEvents Lib_Nouvelle_Entite_txt As ud_TextBox
    Friend WithEvents Lib_Nouveau_Poste_txt As ud_TextBox
    Friend WithEvents Lib_Nouveau_Grade_txt As ud_TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Ancienne_Entite_txt As ud_TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Ancien_Titre_txt As ud_TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Ancien_Grade_txt As ud_TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Ancien_Poste_txt As ud_TextBox
    Friend WithEvents Lib_Ancienne_Entite_txt As ud_TextBox
    Friend WithEvents Lib_Ancien_Poste_txt As ud_TextBox
    Friend WithEvents Lib_Ancien_Grade_txt As ud_TextBox
    Friend WithEvents Lib_Avancement_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Dat_Entree_txt As ud_TextBox
End Class
