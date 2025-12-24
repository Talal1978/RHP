<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Org_Poste
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
        Me.Domaines_Competence_Pnl = New System.Windows.Forms.Panel()
        Me.Cod_Poste_txt = New RHP.ud_TextBox()
        Me.poste_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Poste_txt = New RHP.ud_TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Mission_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.DependanceHiera = New System.Windows.Forms.LinkLabel()
        Me.Dependance_fonctionnelle_txt = New RHP.ud_TextBox()
        Me.Dependance_Hierarchique_txt = New RHP.ud_TextBox()
        Me.Lib_Dependance_fonctionnelle_txt = New RHP.ud_TextBox()
        Me.Lib_Dependance_Hierarchique_txt = New RHP.ud_TextBox()
        Me.nb_Annees_Experience = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Proprietaire_ = New System.Windows.Forms.Label()
        Me.Background_Academique_cbo = New RHP.ud_ComboBox()
        Me.Grade_ = New System.Windows.Forms.LinkLabel()
        Me.Cod_Grade_txt = New RHP.ud_TextBox()
        Me.Lib_Grade_txt = New RHP.ud_TextBox()
        Me.Soft_Skills_Pnl = New System.Windows.Forms.Panel()
        Me.SoftSkills_Grp = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Ajouter_btn = New RHP.ud_button()
        Me.domainesCompetences_Grp = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.fiche = New System.Windows.Forms.TabPage()
        Me.tasks = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TachesAttributions_lv = New System.Windows.Forms.ListView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.task_down_btn = New RHP.ud_button()
        Me.task_del_btn = New RHP.ud_button()
        Me.task_up_btn = New RHP.ud_button()
        Me.task_edit_btn = New RHP.ud_button()
        Me.task_add_btn = New RHP.ud_button()
        Me.task_add_new_btn = New RHP.ud_button()
        Me.responsabilities = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Responsabilites_lv = New System.Windows.Forms.ListView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.resp_down_btn = New RHP.ud_button()
        Me.resp_del_btn = New RHP.ud_button()
        Me.resp_up_btn = New RHP.ud_button()
        Me.resp_edit_btn = New RHP.ud_button()
        Me.resp_add_btn = New RHP.ud_button()
        Me.resp_add_new_btn = New RHP.ud_button()
        Me.techicalSkills = New System.Windows.Forms.TabPage()
        Me.Panel1.SuspendLayout()
        CType(Me.nb_Annees_Experience, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SoftSkills_Grp.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.domainesCompetences_Grp.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.fiche.SuspendLayout()
        Me.tasks.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.responsabilities.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.techicalSkills.SuspendLayout()
        Me.SuspendLayout()
        '
        'Domaines_Competence_Pnl
        '
        Me.Domaines_Competence_Pnl.AutoScroll = True
        Me.Domaines_Competence_Pnl.BackColor = System.Drawing.Color.Transparent
        Me.Domaines_Competence_Pnl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Domaines_Competence_Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Domaines_Competence_Pnl.Location = New System.Drawing.Point(3, 20)
        Me.Domaines_Competence_Pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.Domaines_Competence_Pnl.Name = "Domaines_Competence_Pnl"
        Me.Domaines_Competence_Pnl.Size = New System.Drawing.Size(1669, 689)
        Me.Domaines_Competence_Pnl.TabIndex = 6
        '
        'Cod_Poste_txt
        '
        Me.Cod_Poste_txt.AccessibleDescription = "A"
        Me.Cod_Poste_txt.AutoSize = True
        Me.Cod_Poste_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Poste_txt.ContextMenuStrip = Nothing
        Me.Cod_Poste_txt.Location = New System.Drawing.Point(102, 41)
        Me.Cod_Poste_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Poste_txt.MaxLength = 32767
        Me.Cod_Poste_txt.Multiline = False
        Me.Cod_Poste_txt.Name = "Cod_Poste_txt"
        Me.Cod_Poste_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Poste_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Poste_txt.ReadOnly = True
        Me.Cod_Poste_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Poste_txt.SelectionStart = 0
        Me.Cod_Poste_txt.Size = New System.Drawing.Size(130, 31)
        Me.Cod_Poste_txt.TabIndex = 203
        Me.Cod_Poste_txt.TabStop = False
        Me.Cod_Poste_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Poste_txt.UseSystemPasswordChar = False
        '
        'poste_
        '
        Me.poste_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.poste_.AutoSize = True
        Me.poste_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.poste_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.poste_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.poste_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.poste_.Location = New System.Drawing.Point(48, 47)
        Me.poste_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.poste_.Name = "poste_"
        Me.poste_.Size = New System.Drawing.Size(45, 19)
        Me.poste_.TabIndex = 201
        Me.poste_.TabStop = True
        Me.poste_.Tag = ""
        Me.poste_.Text = "Poste"
        '
        'Lib_Poste_txt
        '
        Me.Lib_Poste_txt.AccessibleDescription = "A"
        Me.Lib_Poste_txt.AutoSize = True
        Me.Lib_Poste_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Lib_Poste_txt.ContextMenuStrip = Nothing
        Me.Lib_Poste_txt.Location = New System.Drawing.Point(242, 41)
        Me.Lib_Poste_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Lib_Poste_txt.MaxLength = 32767
        Me.Lib_Poste_txt.Multiline = False
        Me.Lib_Poste_txt.Name = "Lib_Poste_txt"
        Me.Lib_Poste_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_txt.ReadOnly = False
        Me.Lib_Poste_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_txt.SelectionStart = 0
        Me.Lib_Poste_txt.Size = New System.Drawing.Size(789, 31)
        Me.Lib_Poste_txt.TabIndex = 202
        Me.Lib_Poste_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_txt.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Mission_txt)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.DependanceHiera)
        Me.Panel1.Controls.Add(Me.Dependance_fonctionnelle_txt)
        Me.Panel1.Controls.Add(Me.Dependance_Hierarchique_txt)
        Me.Panel1.Controls.Add(Me.Lib_Dependance_fonctionnelle_txt)
        Me.Panel1.Controls.Add(Me.Lib_Dependance_Hierarchique_txt)
        Me.Panel1.Controls.Add(Me.nb_Annees_Experience)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Proprietaire_)
        Me.Panel1.Controls.Add(Me.Background_Academique_cbo)
        Me.Panel1.Controls.Add(Me.Grade_)
        Me.Panel1.Controls.Add(Me.Cod_Grade_txt)
        Me.Panel1.Controls.Add(Me.Lib_Grade_txt)
        Me.Panel1.Controls.Add(Me.Lib_Poste_txt)
        Me.Panel1.Controls.Add(Me.Cod_Poste_txt)
        Me.Panel1.Controls.Add(Me.poste_)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1675, 405)
        Me.Panel1.TabIndex = 204
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(112, 121)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 19)
        Me.Label2.TabIndex = 232
        Me.Label2.Text = "Mission du poste"
        '
        'Mission_txt
        '
        Me.Mission_txt.AccessibleDescription = "A"
        Me.Mission_txt.AutoSize = True
        Me.Mission_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Mission_txt.ContextMenuStrip = Nothing
        Me.Mission_txt.Location = New System.Drawing.Point(242, 121)
        Me.Mission_txt.Margin = New System.Windows.Forms.Padding(5, 7, 5, 7)
        Me.Mission_txt.MaxLength = 32767
        Me.Mission_txt.Multiline = True
        Me.Mission_txt.Name = "Mission_txt"
        Me.Mission_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Mission_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Mission_txt.ReadOnly = False
        Me.Mission_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mission_txt.SelectionStart = 0
        Me.Mission_txt.Size = New System.Drawing.Size(789, 120)
        Me.Mission_txt.TabIndex = 231
        Me.Mission_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Mission_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(34, 361)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(197, 19)
        Me.LinkLabel1.TabIndex = 229
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Dépendance fonctionnelle"
        '
        'DependanceHiera
        '
        Me.DependanceHiera.AutoSize = True
        Me.DependanceHiera.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DependanceHiera.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.DependanceHiera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DependanceHiera.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DependanceHiera.Location = New System.Drawing.Point(36, 325)
        Me.DependanceHiera.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DependanceHiera.Name = "DependanceHiera"
        Me.DependanceHiera.Size = New System.Drawing.Size(195, 19)
        Me.DependanceHiera.TabIndex = 229
        Me.DependanceHiera.TabStop = True
        Me.DependanceHiera.Tag = ""
        Me.DependanceHiera.Text = "Dépendance hiérarchique"
        '
        'Dependance_fonctionnelle_txt
        '
        Me.Dependance_fonctionnelle_txt.AccessibleDescription = "A"
        Me.Dependance_fonctionnelle_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dependance_fonctionnelle_txt.ContextMenuStrip = Nothing
        Me.Dependance_fonctionnelle_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dependance_fonctionnelle_txt.Location = New System.Drawing.Point(241, 354)
        Me.Dependance_fonctionnelle_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dependance_fonctionnelle_txt.MaxLength = 32767
        Me.Dependance_fonctionnelle_txt.Multiline = False
        Me.Dependance_fonctionnelle_txt.Name = "Dependance_fonctionnelle_txt"
        Me.Dependance_fonctionnelle_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dependance_fonctionnelle_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dependance_fonctionnelle_txt.ReadOnly = True
        Me.Dependance_fonctionnelle_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dependance_fonctionnelle_txt.SelectionStart = 0
        Me.Dependance_fonctionnelle_txt.Size = New System.Drawing.Size(130, 26)
        Me.Dependance_fonctionnelle_txt.TabIndex = 228
        Me.Dependance_fonctionnelle_txt.TabStop = False
        Me.Dependance_fonctionnelle_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dependance_fonctionnelle_txt.UseSystemPasswordChar = False
        '
        'Dependance_Hierarchique_txt
        '
        Me.Dependance_Hierarchique_txt.AccessibleDescription = "A"
        Me.Dependance_Hierarchique_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dependance_Hierarchique_txt.ContextMenuStrip = Nothing
        Me.Dependance_Hierarchique_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dependance_Hierarchique_txt.Location = New System.Drawing.Point(241, 318)
        Me.Dependance_Hierarchique_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dependance_Hierarchique_txt.MaxLength = 32767
        Me.Dependance_Hierarchique_txt.Multiline = False
        Me.Dependance_Hierarchique_txt.Name = "Dependance_Hierarchique_txt"
        Me.Dependance_Hierarchique_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dependance_Hierarchique_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dependance_Hierarchique_txt.ReadOnly = True
        Me.Dependance_Hierarchique_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dependance_Hierarchique_txt.SelectionStart = 0
        Me.Dependance_Hierarchique_txt.Size = New System.Drawing.Size(130, 26)
        Me.Dependance_Hierarchique_txt.TabIndex = 228
        Me.Dependance_Hierarchique_txt.TabStop = False
        Me.Dependance_Hierarchique_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dependance_Hierarchique_txt.UseSystemPasswordChar = False
        '
        'Lib_Dependance_fonctionnelle_txt
        '
        Me.Lib_Dependance_fonctionnelle_txt.AccessibleDescription = "A"
        Me.Lib_Dependance_fonctionnelle_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Dependance_fonctionnelle_txt.ContextMenuStrip = Nothing
        Me.Lib_Dependance_fonctionnelle_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Dependance_fonctionnelle_txt.Location = New System.Drawing.Point(373, 354)
        Me.Lib_Dependance_fonctionnelle_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Dependance_fonctionnelle_txt.MaxLength = 32767
        Me.Lib_Dependance_fonctionnelle_txt.Multiline = False
        Me.Lib_Dependance_fonctionnelle_txt.Name = "Lib_Dependance_fonctionnelle_txt"
        Me.Lib_Dependance_fonctionnelle_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Dependance_fonctionnelle_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Dependance_fonctionnelle_txt.ReadOnly = True
        Me.Lib_Dependance_fonctionnelle_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Dependance_fonctionnelle_txt.SelectionStart = 0
        Me.Lib_Dependance_fonctionnelle_txt.Size = New System.Drawing.Size(658, 26)
        Me.Lib_Dependance_fonctionnelle_txt.TabIndex = 230
        Me.Lib_Dependance_fonctionnelle_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Dependance_fonctionnelle_txt.UseSystemPasswordChar = False
        '
        'Lib_Dependance_Hierarchique_txt
        '
        Me.Lib_Dependance_Hierarchique_txt.AccessibleDescription = "A"
        Me.Lib_Dependance_Hierarchique_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Dependance_Hierarchique_txt.ContextMenuStrip = Nothing
        Me.Lib_Dependance_Hierarchique_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Dependance_Hierarchique_txt.Location = New System.Drawing.Point(373, 318)
        Me.Lib_Dependance_Hierarchique_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Dependance_Hierarchique_txt.MaxLength = 32767
        Me.Lib_Dependance_Hierarchique_txt.Multiline = False
        Me.Lib_Dependance_Hierarchique_txt.Name = "Lib_Dependance_Hierarchique_txt"
        Me.Lib_Dependance_Hierarchique_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Dependance_Hierarchique_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Dependance_Hierarchique_txt.ReadOnly = True
        Me.Lib_Dependance_Hierarchique_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Dependance_Hierarchique_txt.SelectionStart = 0
        Me.Lib_Dependance_Hierarchique_txt.Size = New System.Drawing.Size(658, 26)
        Me.Lib_Dependance_Hierarchique_txt.TabIndex = 230
        Me.Lib_Dependance_Hierarchique_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Dependance_Hierarchique_txt.UseSystemPasswordChar = False
        '
        'nb_Annees_Experience
        '
        Me.nb_Annees_Experience.Location = New System.Drawing.Point(241, 251)
        Me.nb_Annees_Experience.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nb_Annees_Experience.Name = "nb_Annees_Experience"
        Me.nb_Annees_Experience.Size = New System.Drawing.Size(80, 24)
        Me.nb_Annees_Experience.TabIndex = 227
        Me.nb_Annees_Experience.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(40, 253)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 19)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "Nb d'années d'expérience"
        '
        'Proprietaire_
        '
        Me.Proprietaire_.AutoSize = True
        Me.Proprietaire_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Proprietaire_.Location = New System.Drawing.Point(44, 287)
        Me.Proprietaire_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Proprietaire_.Name = "Proprietaire_"
        Me.Proprietaire_.Size = New System.Drawing.Size(189, 19)
        Me.Proprietaire_.TabIndex = 224
        Me.Proprietaire_.Text = "Background académique"
        '
        'Background_Academique_cbo
        '
        Me.Background_Academique_cbo.DataSource = Nothing
        Me.Background_Academique_cbo.DisplayMember = ""
        Me.Background_Academique_cbo.DroppedDown = False
        Me.Background_Academique_cbo.Location = New System.Drawing.Point(241, 280)
        Me.Background_Academique_cbo.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Background_Academique_cbo.Name = "Background_Academique_cbo"
        Me.Background_Academique_cbo.SelectedIndex = -1
        Me.Background_Academique_cbo.SelectedItem = Nothing
        Me.Background_Academique_cbo.SelectedValue = Nothing
        Me.Background_Academique_cbo.Size = New System.Drawing.Size(504, 31)
        Me.Background_Academique_cbo.TabIndex = 225
        Me.Background_Academique_cbo.Tag = "NC"
        Me.Background_Academique_cbo.ValueMember = ""
        '
        'Grade_
        '
        Me.Grade_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.AutoSize = True
        Me.Grade_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Location = New System.Drawing.Point(39, 85)
        Me.Grade_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Grade_.Name = "Grade_"
        Me.Grade_.Size = New System.Drawing.Size(54, 19)
        Me.Grade_.TabIndex = 221
        Me.Grade_.TabStop = True
        Me.Grade_.Tag = "NC"
        Me.Grade_.Text = "Grade"
        '
        'Cod_Grade_txt
        '
        Me.Cod_Grade_txt.AutoSize = True
        Me.Cod_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Grade_txt.ContextMenuStrip = Nothing
        Me.Cod_Grade_txt.Location = New System.Drawing.Point(101, 81)
        Me.Cod_Grade_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Grade_txt.MaxLength = 6
        Me.Cod_Grade_txt.Multiline = False
        Me.Cod_Grade_txt.Name = "Cod_Grade_txt"
        Me.Cod_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Grade_txt.ReadOnly = True
        Me.Cod_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Grade_txt.SelectionStart = 0
        Me.Cod_Grade_txt.Size = New System.Drawing.Size(131, 31)
        Me.Cod_Grade_txt.TabIndex = 223
        Me.Cod_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Grade_txt.UseSystemPasswordChar = False
        '
        'Lib_Grade_txt
        '
        Me.Lib_Grade_txt.AutoSize = True
        Me.Lib_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_txt.ContextMenuStrip = Nothing
        Me.Lib_Grade_txt.Location = New System.Drawing.Point(242, 81)
        Me.Lib_Grade_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Lib_Grade_txt.MaxLength = 50
        Me.Lib_Grade_txt.Multiline = False
        Me.Lib_Grade_txt.Name = "Lib_Grade_txt"
        Me.Lib_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_txt.ReadOnly = True
        Me.Lib_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_txt.SelectionStart = 0
        Me.Lib_Grade_txt.Size = New System.Drawing.Size(460, 31)
        Me.Lib_Grade_txt.TabIndex = 222
        Me.Lib_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_txt.UseSystemPasswordChar = False
        '
        'Soft_Skills_Pnl
        '
        Me.Soft_Skills_Pnl.AutoScroll = True
        Me.Soft_Skills_Pnl.BackColor = System.Drawing.Color.Transparent
        Me.Soft_Skills_Pnl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Soft_Skills_Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Soft_Skills_Pnl.Location = New System.Drawing.Point(3, 81)
        Me.Soft_Skills_Pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.Soft_Skills_Pnl.Name = "Soft_Skills_Pnl"
        Me.Soft_Skills_Pnl.Size = New System.Drawing.Size(1669, 223)
        Me.Soft_Skills_Pnl.TabIndex = 205
        '
        'SoftSkills_Grp
        '
        Me.SoftSkills_Grp.Controls.Add(Me.Soft_Skills_Pnl)
        Me.SoftSkills_Grp.Controls.Add(Me.Panel2)
        Me.SoftSkills_Grp.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SoftSkills_Grp.Location = New System.Drawing.Point(3, 408)
        Me.SoftSkills_Grp.Name = "SoftSkills_Grp"
        Me.SoftSkills_Grp.Size = New System.Drawing.Size(1675, 307)
        Me.SoftSkills_Grp.TabIndex = 231
        Me.SoftSkills_Grp.TabStop = False
        Me.SoftSkills_Grp.Text = "Soft skills"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Ajouter_btn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 20)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1669, 61)
        Me.Panel2.TabIndex = 0
        '
        'Ajouter_btn
        '
        Me.Ajouter_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ajouter_btn.bgColor = System.Drawing.Color.White
        Me.Ajouter_btn.Border = RHP.ud_button.BorderStyle.All
        Me.Ajouter_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ajouter_btn.BorderSize = 2
        Me.Ajouter_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ajouter_btn.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.Ajouter_btn.isDefault = False
        Me.Ajouter_btn.Location = New System.Drawing.Point(10, 13)
        Me.Ajouter_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ajouter_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.Ajouter_btn.Name = "Ajouter_btn"
        Me.Ajouter_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.Ajouter_btn.Size = New System.Drawing.Size(188, 43)
        Me.Ajouter_btn.TabIndex = 0
        Me.Ajouter_btn.Text = "Ajouter un soft skill"
        '
        'domainesCompetences_Grp
        '
        Me.domainesCompetences_Grp.Controls.Add(Me.Domaines_Competence_Pnl)
        Me.domainesCompetences_Grp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.domainesCompetences_Grp.Location = New System.Drawing.Point(3, 3)
        Me.domainesCompetences_Grp.Name = "domainesCompetences_Grp"
        Me.domainesCompetences_Grp.Size = New System.Drawing.Size(1675, 712)
        Me.domainesCompetences_Grp.TabIndex = 0
        Me.domainesCompetences_Grp.TabStop = False
        Me.domainesCompetences_Grp.Text = "Compétences requises"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.fiche)
        Me.TabControl1.Controls.Add(Me.tasks)
        Me.TabControl1.Controls.Add(Me.responsabilities)
        Me.TabControl1.Controls.Add(Me.techicalSkills)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1689, 750)
        Me.TabControl1.TabIndex = 233
        '
        'fiche
        '
        Me.fiche.Controls.Add(Me.Panel1)
        Me.fiche.Controls.Add(Me.SoftSkills_Grp)
        Me.fiche.Location = New System.Drawing.Point(4, 28)
        Me.fiche.Name = "fiche"
        Me.fiche.Padding = New System.Windows.Forms.Padding(3)
        Me.fiche.Size = New System.Drawing.Size(1681, 718)
        Me.fiche.TabIndex = 0
        Me.fiche.Text = "Fiche de poste"
        Me.fiche.UseVisualStyleBackColor = True
        '
        'tasks
        '
        Me.tasks.Controls.Add(Me.GroupBox1)
        Me.tasks.Location = New System.Drawing.Point(4, 28)
        Me.tasks.Name = "tasks"
        Me.tasks.Padding = New System.Windows.Forms.Padding(3)
        Me.tasks.Size = New System.Drawing.Size(1681, 718)
        Me.tasks.TabIndex = 1
        Me.tasks.Text = "Tâches & attributions"
        Me.tasks.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TachesAttributions_lv)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1675, 712)
        Me.GroupBox1.TabIndex = 232
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tâches et attributions du poste"
        '
        'TachesAttributions_lv
        '
        Me.TachesAttributions_lv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TachesAttributions_lv.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TachesAttributions_lv.FullRowSelect = True
        Me.TachesAttributions_lv.GridLines = True
        Me.TachesAttributions_lv.HideSelection = False
        Me.TachesAttributions_lv.Location = New System.Drawing.Point(3, 100)
        Me.TachesAttributions_lv.Name = "TachesAttributions_lv"
        Me.TachesAttributions_lv.Size = New System.Drawing.Size(1669, 609)
        Me.TachesAttributions_lv.TabIndex = 1
        Me.TachesAttributions_lv.UseCompatibleStateImageBehavior = False
        Me.TachesAttributions_lv.View = System.Windows.Forms.View.List
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.task_down_btn)
        Me.Panel4.Controls.Add(Me.task_del_btn)
        Me.Panel4.Controls.Add(Me.task_up_btn)
        Me.Panel4.Controls.Add(Me.task_edit_btn)
        Me.Panel4.Controls.Add(Me.task_add_btn)
        Me.Panel4.Controls.Add(Me.task_add_new_btn)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 20)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1669, 80)
        Me.Panel4.TabIndex = 0
        '
        'task_down_btn
        '
        Me.task_down_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_down_btn.bgColor = System.Drawing.Color.White
        Me.task_down_btn.Border = RHP.ud_button.BorderStyle.All
        Me.task_down_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_down_btn.BorderSize = 2
        Me.task_down_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.task_down_btn.Image = Global.RHP.My.Resources.Resources.btn_div_down
        Me.task_down_btn.isDefault = False
        Me.task_down_btn.Location = New System.Drawing.Point(466, 13)
        Me.task_down_btn.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.task_down_btn.MinimumSize = New System.Drawing.Size(27, 43)
        Me.task_down_btn.Name = "task_down_btn"
        Me.task_down_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.task_down_btn.Size = New System.Drawing.Size(56, 43)
        Me.task_down_btn.TabIndex = 2
        Me.task_down_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.task_down_btn.ToolTip = "Déplacer vers le bas"
        '
        'task_del_btn
        '
        Me.task_del_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_del_btn.bgColor = System.Drawing.Color.White
        Me.task_del_btn.Border = RHP.ud_button.BorderStyle.All
        Me.task_del_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_del_btn.BorderSize = 2
        Me.task_del_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.task_del_btn.Image = Global.RHP.My.Resources.Resources.btn_delete
        Me.task_del_btn.isDefault = False
        Me.task_del_btn.Location = New System.Drawing.Point(201, 13)
        Me.task_del_btn.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.task_del_btn.MinimumSize = New System.Drawing.Size(27, 43)
        Me.task_del_btn.Name = "task_del_btn"
        Me.task_del_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.task_del_btn.Size = New System.Drawing.Size(56, 43)
        Me.task_del_btn.TabIndex = 2
        Me.task_del_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.task_del_btn.ToolTip = "Supprimer une tâche ou attribution"
        '
        'task_up_btn
        '
        Me.task_up_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_up_btn.bgColor = System.Drawing.Color.White
        Me.task_up_btn.Border = RHP.ud_button.BorderStyle.All
        Me.task_up_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_up_btn.BorderSize = 2
        Me.task_up_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.task_up_btn.Image = Global.RHP.My.Resources.Resources.btn_div_up
        Me.task_up_btn.isDefault = False
        Me.task_up_btn.Location = New System.Drawing.Point(402, 13)
        Me.task_up_btn.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.task_up_btn.MinimumSize = New System.Drawing.Size(27, 36)
        Me.task_up_btn.Name = "task_up_btn"
        Me.task_up_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.task_up_btn.Size = New System.Drawing.Size(56, 43)
        Me.task_up_btn.TabIndex = 2
        Me.task_up_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.task_up_btn.ToolTip = "Déplacer vers le haut"
        '
        'task_edit_btn
        '
        Me.task_edit_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_edit_btn.bgColor = System.Drawing.Color.White
        Me.task_edit_btn.Border = RHP.ud_button.BorderStyle.All
        Me.task_edit_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_edit_btn.BorderSize = 2
        Me.task_edit_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.task_edit_btn.Image = Global.RHP.My.Resources.Resources.btn_edit_doc
        Me.task_edit_btn.isDefault = False
        Me.task_edit_btn.Location = New System.Drawing.Point(137, 13)
        Me.task_edit_btn.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.task_edit_btn.MinimumSize = New System.Drawing.Size(27, 36)
        Me.task_edit_btn.Name = "task_edit_btn"
        Me.task_edit_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.task_edit_btn.Size = New System.Drawing.Size(56, 43)
        Me.task_edit_btn.TabIndex = 1
        Me.task_edit_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.task_edit_btn.ToolTip = "Choisir parmi les attributions et tâches enregistrées"
        '
        'task_add_btn
        '
        Me.task_add_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_add_btn.bgColor = System.Drawing.Color.White
        Me.task_add_btn.Border = RHP.ud_button.BorderStyle.All
        Me.task_add_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_add_btn.BorderSize = 2
        Me.task_add_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.task_add_btn.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.task_add_btn.isDefault = False
        Me.task_add_btn.Location = New System.Drawing.Point(74, 13)
        Me.task_add_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.task_add_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.task_add_btn.Name = "task_add_btn"
        Me.task_add_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.task_add_btn.Size = New System.Drawing.Size(56, 43)
        Me.task_add_btn.TabIndex = 1
        Me.task_add_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.task_add_btn.ToolTip = "Choisir parmi les attributions et tâches enregistrées"
        '
        'task_add_new_btn
        '
        Me.task_add_new_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_add_new_btn.bgColor = System.Drawing.Color.White
        Me.task_add_new_btn.Border = RHP.ud_button.BorderStyle.All
        Me.task_add_new_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.task_add_new_btn.BorderSize = 2
        Me.task_add_new_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.task_add_new_btn.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.task_add_new_btn.isDefault = False
        Me.task_add_new_btn.Location = New System.Drawing.Point(10, 13)
        Me.task_add_new_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.task_add_new_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.task_add_new_btn.Name = "task_add_new_btn"
        Me.task_add_new_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.task_add_new_btn.Size = New System.Drawing.Size(56, 43)
        Me.task_add_new_btn.TabIndex = 0
        Me.task_add_new_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.task_add_new_btn.ToolTip = "Nouvelle tâche"
        '
        'responsabilities
        '
        Me.responsabilities.Controls.Add(Me.GroupBox2)
        Me.responsabilities.Location = New System.Drawing.Point(4, 28)
        Me.responsabilities.Name = "responsabilities"
        Me.responsabilities.Size = New System.Drawing.Size(1681, 718)
        Me.responsabilities.TabIndex = 2
        Me.responsabilities.Text = "Responsabilités"
        Me.responsabilities.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Responsabilites_lv)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1681, 718)
        Me.GroupBox2.TabIndex = 233
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reponsabilités"
        '
        'Responsabilites_lv
        '
        Me.Responsabilites_lv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Responsabilites_lv.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Responsabilites_lv.FullRowSelect = True
        Me.Responsabilites_lv.GridLines = True
        Me.Responsabilites_lv.HideSelection = False
        Me.Responsabilites_lv.Location = New System.Drawing.Point(3, 102)
        Me.Responsabilites_lv.Name = "Responsabilites_lv"
        Me.Responsabilites_lv.Size = New System.Drawing.Size(1675, 613)
        Me.Responsabilites_lv.TabIndex = 1
        Me.Responsabilites_lv.UseCompatibleStateImageBehavior = False
        Me.Responsabilites_lv.View = System.Windows.Forms.View.List
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.resp_down_btn)
        Me.Panel3.Controls.Add(Me.resp_del_btn)
        Me.Panel3.Controls.Add(Me.resp_up_btn)
        Me.Panel3.Controls.Add(Me.resp_edit_btn)
        Me.Panel3.Controls.Add(Me.resp_add_btn)
        Me.Panel3.Controls.Add(Me.resp_add_new_btn)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 20)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1675, 82)
        Me.Panel3.TabIndex = 0
        '
        'resp_down_btn
        '
        Me.resp_down_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_down_btn.bgColor = System.Drawing.Color.White
        Me.resp_down_btn.Border = RHP.ud_button.BorderStyle.All
        Me.resp_down_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_down_btn.BorderSize = 2
        Me.resp_down_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.resp_down_btn.Image = Global.RHP.My.Resources.Resources.btn_div_down
        Me.resp_down_btn.isDefault = False
        Me.resp_down_btn.Location = New System.Drawing.Point(466, 13)
        Me.resp_down_btn.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.resp_down_btn.MinimumSize = New System.Drawing.Size(27, 43)
        Me.resp_down_btn.Name = "resp_down_btn"
        Me.resp_down_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.resp_down_btn.Size = New System.Drawing.Size(56, 43)
        Me.resp_down_btn.TabIndex = 2
        Me.resp_down_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.resp_down_btn.ToolTip = "Déplacer vers le bas"
        '
        'resp_del_btn
        '
        Me.resp_del_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_del_btn.bgColor = System.Drawing.Color.White
        Me.resp_del_btn.Border = RHP.ud_button.BorderStyle.All
        Me.resp_del_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_del_btn.BorderSize = 2
        Me.resp_del_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.resp_del_btn.Image = Global.RHP.My.Resources.Resources.btn_delete
        Me.resp_del_btn.isDefault = False
        Me.resp_del_btn.Location = New System.Drawing.Point(201, 13)
        Me.resp_del_btn.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.resp_del_btn.MinimumSize = New System.Drawing.Size(27, 43)
        Me.resp_del_btn.Name = "resp_del_btn"
        Me.resp_del_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.resp_del_btn.Size = New System.Drawing.Size(56, 43)
        Me.resp_del_btn.TabIndex = 2
        Me.resp_del_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.resp_del_btn.ToolTip = "Supprimer une tâche ou attribution"
        '
        'resp_up_btn
        '
        Me.resp_up_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_up_btn.bgColor = System.Drawing.Color.White
        Me.resp_up_btn.Border = RHP.ud_button.BorderStyle.All
        Me.resp_up_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_up_btn.BorderSize = 2
        Me.resp_up_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.resp_up_btn.Image = Global.RHP.My.Resources.Resources.btn_div_up
        Me.resp_up_btn.isDefault = False
        Me.resp_up_btn.Location = New System.Drawing.Point(402, 13)
        Me.resp_up_btn.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.resp_up_btn.MinimumSize = New System.Drawing.Size(27, 36)
        Me.resp_up_btn.Name = "resp_up_btn"
        Me.resp_up_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.resp_up_btn.Size = New System.Drawing.Size(56, 43)
        Me.resp_up_btn.TabIndex = 2
        Me.resp_up_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.resp_up_btn.ToolTip = "Déplacer vers le haut"
        '
        'resp_edit_btn
        '
        Me.resp_edit_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_edit_btn.bgColor = System.Drawing.Color.White
        Me.resp_edit_btn.Border = RHP.ud_button.BorderStyle.All
        Me.resp_edit_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_edit_btn.BorderSize = 2
        Me.resp_edit_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.resp_edit_btn.Image = Global.RHP.My.Resources.Resources.btn_edit_doc
        Me.resp_edit_btn.isDefault = False
        Me.resp_edit_btn.Location = New System.Drawing.Point(137, 13)
        Me.resp_edit_btn.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.resp_edit_btn.MinimumSize = New System.Drawing.Size(27, 36)
        Me.resp_edit_btn.Name = "resp_edit_btn"
        Me.resp_edit_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.resp_edit_btn.Size = New System.Drawing.Size(56, 43)
        Me.resp_edit_btn.TabIndex = 1
        Me.resp_edit_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.resp_edit_btn.ToolTip = "Choisir parmi les attributions et tâches enregistrées"
        '
        'resp_add_btn
        '
        Me.resp_add_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_add_btn.bgColor = System.Drawing.Color.White
        Me.resp_add_btn.Border = RHP.ud_button.BorderStyle.All
        Me.resp_add_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_add_btn.BorderSize = 2
        Me.resp_add_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.resp_add_btn.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.resp_add_btn.isDefault = False
        Me.resp_add_btn.Location = New System.Drawing.Point(74, 13)
        Me.resp_add_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.resp_add_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.resp_add_btn.Name = "resp_add_btn"
        Me.resp_add_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.resp_add_btn.Size = New System.Drawing.Size(56, 43)
        Me.resp_add_btn.TabIndex = 1
        Me.resp_add_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.resp_add_btn.ToolTip = "Choisir parmi les attributions et tâches enregistrées"
        '
        'resp_add_new_btn
        '
        Me.resp_add_new_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_add_new_btn.bgColor = System.Drawing.Color.White
        Me.resp_add_new_btn.Border = RHP.ud_button.BorderStyle.All
        Me.resp_add_new_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.resp_add_new_btn.BorderSize = 2
        Me.resp_add_new_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.resp_add_new_btn.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.resp_add_new_btn.isDefault = False
        Me.resp_add_new_btn.Location = New System.Drawing.Point(10, 13)
        Me.resp_add_new_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.resp_add_new_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.resp_add_new_btn.Name = "resp_add_new_btn"
        Me.resp_add_new_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.resp_add_new_btn.Size = New System.Drawing.Size(56, 43)
        Me.resp_add_new_btn.TabIndex = 0
        Me.resp_add_new_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.resp_add_new_btn.ToolTip = "Nouvelle tâche"
        '
        'techicalSkills
        '
        Me.techicalSkills.Controls.Add(Me.domainesCompetences_Grp)
        Me.techicalSkills.Location = New System.Drawing.Point(4, 28)
        Me.techicalSkills.Name = "techicalSkills"
        Me.techicalSkills.Padding = New System.Windows.Forms.Padding(3)
        Me.techicalSkills.Size = New System.Drawing.Size(1681, 718)
        Me.techicalSkills.TabIndex = 3
        Me.techicalSkills.Text = "Compétences requises"
        Me.techicalSkills.UseVisualStyleBackColor = True
        '
        'Org_Poste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1689, 750)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Org_Poste"
        Me.Tag = "ECR"
        Me.Text = "Fiche de Postes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nb_Annees_Experience, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SoftSkills_Grp.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.domainesCompetences_Grp.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.fiche.ResumeLayout(False)
        Me.tasks.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.responsabilities.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.techicalSkills.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Domaines_Competence_Pnl As Panel
    Friend WithEvents Cod_Poste_txt As ud_TextBox
    Friend WithEvents poste_ As LinkLabel
    Friend WithEvents Lib_Poste_txt As ud_TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grade_ As LinkLabel
    Friend WithEvents Cod_Grade_txt As ud_TextBox
    Friend WithEvents Lib_Grade_txt As ud_TextBox
    Friend WithEvents Soft_Skills_Pnl As Panel
    Friend WithEvents Proprietaire_ As Label
    Friend WithEvents Background_Academique_cbo As ud_ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents nb_Annees_Experience As NumericUpDown
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents DependanceHiera As LinkLabel
    Friend WithEvents Dependance_fonctionnelle_txt As ud_TextBox
    Friend WithEvents Dependance_Hierarchique_txt As ud_TextBox
    Friend WithEvents Lib_Dependance_fonctionnelle_txt As ud_TextBox
    Friend WithEvents Lib_Dependance_Hierarchique_txt As ud_TextBox
    Friend WithEvents SoftSkills_Grp As GroupBox
    Friend WithEvents domainesCompetences_Grp As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Ajouter_btn As ud_button
    Friend WithEvents Label2 As Label
    Friend WithEvents Mission_txt As ud_TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents fiche As TabPage
    Friend WithEvents tasks As TabPage
    Friend WithEvents responsabilities As TabPage
    Friend WithEvents techicalSkills As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents task_add_new_btn As ud_button
    Friend WithEvents TachesAttributions_lv As ListView
    Friend WithEvents task_add_btn As ud_button
    Friend WithEvents task_down_btn As ud_button
    Friend WithEvents task_del_btn As ud_button
    Friend WithEvents task_up_btn As ud_button
    Friend WithEvents task_edit_btn As ud_button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Responsabilites_lv As ListView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents resp_down_btn As ud_button
    Friend WithEvents resp_del_btn As ud_button
    Friend WithEvents resp_up_btn As ud_button
    Friend WithEvents resp_edit_btn As ud_button
    Friend WithEvents resp_add_btn As ud_button
    Friend WithEvents resp_add_new_btn As ud_button
End Class
