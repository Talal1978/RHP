<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Demande_Conge
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Dat_Deb_am_pm_cbo = New RHP.ud_ComboBox()
        Me.Dat_Fin_am_pm_cbo = New RHP.ud_ComboBox()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Duree_Conge_txt = New RHP.ud_TextBox()
        Me.Jours_Feries_txt = New RHP.ud_TextBox()
        Me.Repos_Hebdomadaire_txt = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Duree_Globale_txt = New RHP.ud_TextBox()
        Me.Dat_Fin_Conge_txt = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Deb_Conge_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Grd_Conge_Detail = New RHP.ud_Grd()
        Me.Dat_Deb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dat_Fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duree_Globale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Repos_Hebdomadaire = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Jours_Feries = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Duree_Conge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dureeParDefaut_txt = New RHP.ud_TextBox()
        Me.Typ_Conge_txt = New RHP.ud_TextBox()
        Me.Lib_Typ_Conge_txt = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.Conge_Pris_txt = New RHP.ud_TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Conge_Annuel_txt = New RHP.ud_TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Solde_Conge_txt = New RHP.ud_TextBox()
        Me.Reliquat_Anterieurs_txt = New RHP.ud_TextBox()
        Me.Droit_Conge_txt = New RHP.ud_TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Acquis_Anciennete_txt = New RHP.ud_TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Num_Conge_txt = New RHP.ud_TextBox()
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
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grd_Conge_Detail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(17, 25)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(59, 16)
        Me.Matricule_.TabIndex = 207
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SN"
        Me.Matricule_.Text = "Matricule"
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.Location = New System.Drawing.Point(79, 22)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(121, 21)
        Me.Matricule_txt.TabIndex = 206
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(203, 22)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(373, 21)
        Me.Nom_Agent_Text.TabIndex = 208
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1167, 554)
        Me.Panel1.TabIndex = 209
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 248)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grd_Conge_Detail)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1167, 306)
        Me.SplitContainer1.SplitterDistance = 527
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 259
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Dat_Deb_am_pm_cbo)
        Me.GroupBox1.Controls.Add(Me.Dat_Fin_am_pm_cbo)
        Me.GroupBox1.Controls.Add(Me.Commentaire_txt)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Duree_Conge_txt)
        Me.GroupBox1.Controls.Add(Me.Jours_Feries_txt)
        Me.GroupBox1.Controls.Add(Me.Repos_Hebdomadaire_txt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Duree_Globale_txt)
        Me.GroupBox1.Controls.Add(Me.Dat_Fin_Conge_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.Dat_Deb_Conge_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(527, 306)
        Me.GroupBox1.TabIndex = 255
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Détail de la demande"
        '
        'Dat_Deb_am_pm_cbo
        '
        Me.Dat_Deb_am_pm_cbo.DataSource = Nothing
        Me.Dat_Deb_am_pm_cbo.DisplayMember = ""
        Me.Dat_Deb_am_pm_cbo.DroppedDown = False
        Me.Dat_Deb_am_pm_cbo.Location = New System.Drawing.Point(163, 47)
        Me.Dat_Deb_am_pm_cbo.Name = "Dat_Deb_am_pm_cbo"
        Me.Dat_Deb_am_pm_cbo.SelectedIndex = -1
        Me.Dat_Deb_am_pm_cbo.SelectedItem = Nothing
        Me.Dat_Deb_am_pm_cbo.SelectedValue = Nothing
        Me.Dat_Deb_am_pm_cbo.Size = New System.Drawing.Size(121, 24)
        Me.Dat_Deb_am_pm_cbo.TabIndex = 259
        Me.Dat_Deb_am_pm_cbo.ValueMember = ""
        '
        'Dat_Fin_am_pm_cbo
        '
        Me.Dat_Fin_am_pm_cbo.DataSource = Nothing
        Me.Dat_Fin_am_pm_cbo.DisplayMember = ""
        Me.Dat_Fin_am_pm_cbo.DroppedDown = False
        Me.Dat_Fin_am_pm_cbo.Location = New System.Drawing.Point(163, 100)
        Me.Dat_Fin_am_pm_cbo.Name = "Dat_Fin_am_pm_cbo"
        Me.Dat_Fin_am_pm_cbo.SelectedIndex = -1
        Me.Dat_Fin_am_pm_cbo.SelectedItem = Nothing
        Me.Dat_Fin_am_pm_cbo.SelectedValue = Nothing
        Me.Dat_Fin_am_pm_cbo.Size = New System.Drawing.Size(121, 24)
        Me.Dat_Fin_am_pm_cbo.TabIndex = 250
        Me.Dat_Fin_am_pm_cbo.ValueMember = ""
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.AccessibleDescription = "A"
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.Location = New System.Drawing.Point(17, 164)
        Me.Commentaire_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Commentaire_txt.MaxLength = 490
        Me.Commentaire_txt.Multiline = True
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(496, 76)
        Me.Commentaire_txt.TabIndex = 258
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(292, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 16)
        Me.Label8.TabIndex = 257
        Me.Label8.Text = "à déduire du congé"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(346, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 16)
        Me.Label7.TabIndex = 257
        Me.Label7.Text = "Jours fériés"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(278, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 16)
        Me.Label6.TabIndex = 257
        Me.Label6.Text = "Repos hebdomadaires"
        '
        'Duree_Conge_txt
        '
        Me.Duree_Conge_txt.AccessibleDescription = "A"
        Me.Duree_Conge_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Duree_Conge_txt.Location = New System.Drawing.Point(412, 74)
        Me.Duree_Conge_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Duree_Conge_txt.MaxLength = 32767
        Me.Duree_Conge_txt.Multiline = False
        Me.Duree_Conge_txt.Name = "Duree_Conge_txt"
        Me.Duree_Conge_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Duree_Conge_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Duree_Conge_txt.ReadOnly = True
        Me.Duree_Conge_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Duree_Conge_txt.SelectionStart = 0
        Me.Duree_Conge_txt.Size = New System.Drawing.Size(102, 21)
        Me.Duree_Conge_txt.TabIndex = 256
        Me.Duree_Conge_txt.TabStop = False
        Me.Duree_Conge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Duree_Conge_txt.UseSystemPasswordChar = False
        '
        'Jours_Feries_txt
        '
        Me.Jours_Feries_txt.AccessibleDescription = "A"
        Me.Jours_Feries_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Jours_Feries_txt.Location = New System.Drawing.Point(412, 48)
        Me.Jours_Feries_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Jours_Feries_txt.MaxLength = 32767
        Me.Jours_Feries_txt.Multiline = False
        Me.Jours_Feries_txt.Name = "Jours_Feries_txt"
        Me.Jours_Feries_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Jours_Feries_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Jours_Feries_txt.ReadOnly = True
        Me.Jours_Feries_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Jours_Feries_txt.SelectionStart = 0
        Me.Jours_Feries_txt.Size = New System.Drawing.Size(102, 21)
        Me.Jours_Feries_txt.TabIndex = 256
        Me.Jours_Feries_txt.TabStop = False
        Me.Jours_Feries_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Jours_Feries_txt.UseSystemPasswordChar = False
        '
        'Repos_Hebdomadaire_txt
        '
        Me.Repos_Hebdomadaire_txt.AccessibleDescription = "A"
        Me.Repos_Hebdomadaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Repos_Hebdomadaire_txt.Location = New System.Drawing.Point(412, 23)
        Me.Repos_Hebdomadaire_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Repos_Hebdomadaire_txt.MaxLength = 32767
        Me.Repos_Hebdomadaire_txt.Multiline = False
        Me.Repos_Hebdomadaire_txt.Name = "Repos_Hebdomadaire_txt"
        Me.Repos_Hebdomadaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Repos_Hebdomadaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Repos_Hebdomadaire_txt.ReadOnly = True
        Me.Repos_Hebdomadaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Repos_Hebdomadaire_txt.SelectionStart = 0
        Me.Repos_Hebdomadaire_txt.Size = New System.Drawing.Size(102, 21)
        Me.Repos_Hebdomadaire_txt.TabIndex = 256
        Me.Repos_Hebdomadaire_txt.TabStop = False
        Me.Repos_Hebdomadaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Repos_Hebdomadaire_txt.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(120, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 255
        Me.Label5.Text = "Durée"
        '
        'Duree_Globale_txt
        '
        Me.Duree_Globale_txt.AccessibleDescription = "A"
        Me.Duree_Globale_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Duree_Globale_txt.Location = New System.Drawing.Point(163, 126)
        Me.Duree_Globale_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Duree_Globale_txt.MaxLength = 32767
        Me.Duree_Globale_txt.Multiline = False
        Me.Duree_Globale_txt.Name = "Duree_Globale_txt"
        Me.Duree_Globale_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Duree_Globale_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Duree_Globale_txt.ReadOnly = True
        Me.Duree_Globale_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Duree_Globale_txt.SelectionStart = 0
        Me.Duree_Globale_txt.Size = New System.Drawing.Size(102, 21)
        Me.Duree_Globale_txt.TabIndex = 253
        Me.Duree_Globale_txt.TabStop = False
        Me.Duree_Globale_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Duree_Globale_txt.UseSystemPasswordChar = False
        '
        'Dat_Fin_Conge_txt
        '
        Me.Dat_Fin_Conge_txt.AccessibleDescription = "A"
        Me.Dat_Fin_Conge_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Fin_Conge_txt.Location = New System.Drawing.Point(163, 75)
        Me.Dat_Fin_Conge_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dat_Fin_Conge_txt.MaxLength = 32767
        Me.Dat_Fin_Conge_txt.Multiline = False
        Me.Dat_Fin_Conge_txt.Name = "Dat_Fin_Conge_txt"
        Me.Dat_Fin_Conge_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Fin_Conge_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Fin_Conge_txt.ReadOnly = True
        Me.Dat_Fin_Conge_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Fin_Conge_txt.SelectionStart = 0
        Me.Dat_Fin_Conge_txt.Size = New System.Drawing.Size(102, 21)
        Me.Dat_Fin_Conge_txt.TabIndex = 253
        Me.Dat_Fin_Conge_txt.TabStop = False
        Me.Dat_Fin_Conge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Fin_Conge_txt.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(53, 78)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(106, 16)
        Me.LinkLabel2.TabIndex = 254
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = ""
        Me.LinkLabel2.Text = "Date fin de congé"
        '
        'Dat_Deb_Conge_txt
        '
        Me.Dat_Deb_Conge_txt.AccessibleDescription = "A"
        Me.Dat_Deb_Conge_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Deb_Conge_txt.Location = New System.Drawing.Point(163, 23)
        Me.Dat_Deb_Conge_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dat_Deb_Conge_txt.MaxLength = 32767
        Me.Dat_Deb_Conge_txt.Multiline = False
        Me.Dat_Deb_Conge_txt.Name = "Dat_Deb_Conge_txt"
        Me.Dat_Deb_Conge_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Deb_Conge_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Deb_Conge_txt.ReadOnly = True
        Me.Dat_Deb_Conge_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Deb_Conge_txt.SelectionStart = 0
        Me.Dat_Deb_Conge_txt.Size = New System.Drawing.Size(102, 21)
        Me.Dat_Deb_Conge_txt.TabIndex = 253
        Me.Dat_Deb_Conge_txt.TabStop = False
        Me.Dat_Deb_Conge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Deb_Conge_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(29, 25)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(131, 16)
        Me.LinkLabel1.TabIndex = 254
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Date départ en congé"
        '
        'Grd_Conge_Detail
        '
        Me.Grd_Conge_Detail.AfficherLesEntetesLignes = True
        Me.Grd_Conge_Detail.AllowUserToAddRows = False
        Me.Grd_Conge_Detail.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd_Conge_Detail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Conge_Detail.AlternerLesLignes = False
        Me.Grd_Conge_Detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Conge_Detail.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Conge_Detail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd_Conge_Detail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Conge_Detail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Conge_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Conge_Detail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dat_Deb, Me.Dat_Fin, Me.Duree_Globale, Me.Repos_Hebdomadaire, Me.Jours_Feries, Me.Duree_Conge})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Conge_Detail.DefaultCellStyle = DataGridViewCellStyle9
        Me.Grd_Conge_Detail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Conge_Detail.EnableHeadersVisualStyles = False
        Me.Grd_Conge_Detail.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Conge_Detail.Location = New System.Drawing.Point(0, 56)
        Me.Grd_Conge_Detail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grd_Conge_Detail.Name = "Grd_Conge_Detail"
        Me.Grd_Conge_Detail.ReadOnly = True
        Me.Grd_Conge_Detail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Conge_Detail.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Grd_Conge_Detail.Size = New System.Drawing.Size(635, 250)
        Me.Grd_Conge_Detail.TabIndex = 4
        '
        'Dat_Deb
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Dat_Deb.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dat_Deb.HeaderText = "Du"
        Me.Dat_Deb.Name = "Dat_Deb"
        Me.Dat_Deb.ReadOnly = True
        Me.Dat_Deb.Width = 57
        '
        'Dat_Fin
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Dat_Fin.DefaultCellStyle = DataGridViewCellStyle4
        Me.Dat_Fin.HeaderText = "Au"
        Me.Dat_Fin.Name = "Dat_Fin"
        Me.Dat_Fin.ReadOnly = True
        Me.Dat_Fin.Width = 56
        '
        'Duree_Globale
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Duree_Globale.DefaultCellStyle = DataGridViewCellStyle5
        Me.Duree_Globale.HeaderText = "Durée globale"
        Me.Duree_Globale.Name = "Duree_Globale"
        Me.Duree_Globale.ReadOnly = True
        Me.Duree_Globale.Width = 109
        '
        'Repos_Hebdomadaire
        '
        '
        '
        '
        Me.Repos_Hebdomadaire.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Repos_Hebdomadaire.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Repos_Hebdomadaire.DefaultCellStyle = DataGridViewCellStyle6
        Me.Repos_Hebdomadaire.HeaderText = "Repos hebdo"
        Me.Repos_Hebdomadaire.Increment = 1.0R
        Me.Repos_Hebdomadaire.MaxValue = 365.0R
        Me.Repos_Hebdomadaire.MinValue = 0R
        Me.Repos_Hebdomadaire.Name = "Repos_Hebdomadaire"
        Me.Repos_Hebdomadaire.ReadOnly = True
        Me.Repos_Hebdomadaire.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Repos_Hebdomadaire.Width = 106
        '
        'Jours_Feries
        '
        '
        '
        '
        Me.Jours_Feries.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Jours_Feries.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Jours_Feries.DefaultCellStyle = DataGridViewCellStyle7
        Me.Jours_Feries.HeaderText = "Jours Fériés"
        Me.Jours_Feries.Increment = 1.0R
        Me.Jours_Feries.MaxValue = 365.0R
        Me.Jours_Feries.MinValue = 0R
        Me.Jours_Feries.Name = "Jours_Feries"
        Me.Jours_Feries.ReadOnly = True
        Me.Jours_Feries.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Jours_Feries.Width = 92
        '
        'Duree_Conge
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Duree_Conge.DefaultCellStyle = DataGridViewCellStyle8
        Me.Duree_Conge.HeaderText = "Durée de congé"
        Me.Duree_Conge.Name = "Duree_Conge"
        Me.Duree_Conge.ReadOnly = True
        Me.Duree_Conge.Width = 120
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.dureeParDefaut_txt)
        Me.Panel2.Controls.Add(Me.Typ_Conge_txt)
        Me.Panel2.Controls.Add(Me.Lib_Typ_Conge_txt)
        Me.Panel2.Controls.Add(Me.LinkLabel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(635, 56)
        Me.Panel2.TabIndex = 255
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 257
        Me.Label10.Text = "Durée"
        '
        'dureeParDefaut_txt
        '
        Me.dureeParDefaut_txt.AccessibleDescription = "A"
        Me.dureeParDefaut_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.dureeParDefaut_txt.Location = New System.Drawing.Point(75, 31)
        Me.dureeParDefaut_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dureeParDefaut_txt.MaxLength = 32767
        Me.dureeParDefaut_txt.Multiline = False
        Me.dureeParDefaut_txt.Name = "dureeParDefaut_txt"
        Me.dureeParDefaut_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.dureeParDefaut_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.dureeParDefaut_txt.ReadOnly = True
        Me.dureeParDefaut_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dureeParDefaut_txt.SelectionStart = 0
        Me.dureeParDefaut_txt.Size = New System.Drawing.Size(121, 21)
        Me.dureeParDefaut_txt.TabIndex = 256
        Me.dureeParDefaut_txt.TabStop = False
        Me.dureeParDefaut_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dureeParDefaut_txt.UseSystemPasswordChar = False
        '
        'Typ_Conge_txt
        '
        Me.Typ_Conge_txt.AccessibleDescription = "A"
        Me.Typ_Conge_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Typ_Conge_txt.Location = New System.Drawing.Point(75, 8)
        Me.Typ_Conge_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Typ_Conge_txt.MaxLength = 32767
        Me.Typ_Conge_txt.Multiline = False
        Me.Typ_Conge_txt.Name = "Typ_Conge_txt"
        Me.Typ_Conge_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Typ_Conge_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Typ_Conge_txt.ReadOnly = True
        Me.Typ_Conge_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Typ_Conge_txt.SelectionStart = 0
        Me.Typ_Conge_txt.Size = New System.Drawing.Size(121, 21)
        Me.Typ_Conge_txt.TabIndex = 209
        Me.Typ_Conge_txt.TabStop = False
        Me.Typ_Conge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Typ_Conge_txt.UseSystemPasswordChar = False
        '
        'Lib_Typ_Conge_txt
        '
        Me.Lib_Typ_Conge_txt.AccessibleDescription = "A"
        Me.Lib_Typ_Conge_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Typ_Conge_txt.Location = New System.Drawing.Point(199, 8)
        Me.Lib_Typ_Conge_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Typ_Conge_txt.MaxLength = 32767
        Me.Lib_Typ_Conge_txt.Multiline = False
        Me.Lib_Typ_Conge_txt.Name = "Lib_Typ_Conge_txt"
        Me.Lib_Typ_Conge_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Typ_Conge_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Typ_Conge_txt.ReadOnly = False
        Me.Lib_Typ_Conge_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Typ_Conge_txt.SelectionStart = 0
        Me.Lib_Typ_Conge_txt.Size = New System.Drawing.Size(373, 21)
        Me.Lib_Typ_Conge_txt.TabIndex = 211
        Me.Lib_Typ_Conge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Typ_Conge_txt.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(38, 10)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(34, 16)
        Me.LinkLabel4.TabIndex = 210
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SN"
        Me.LinkLabel4.Text = "Type"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.pb_Valide)
        Me.GroupBox3.Controls.Add(Me.Conge_Pris_txt)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Conge_Annuel_txt)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Solde_Conge_txt)
        Me.GroupBox3.Controls.Add(Me.Reliquat_Anterieurs_txt)
        Me.GroupBox3.Controls.Add(Me.Droit_Conge_txt)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Acquis_Anciennete_txt)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 164)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(1167, 84)
        Me.GroupBox3.TabIndex = 257
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Récap droit au congé"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(841, 45)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 28)
        Me.Button1.TabIndex = 254
        Me.Button1.Text = "Recalcul"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(937, 7)
        Me.pb_Valide.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(72, 76)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pb_Valide.TabIndex = 253
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'Conge_Pris_txt
        '
        Me.Conge_Pris_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Conge_Pris_txt.Location = New System.Drawing.Point(721, 23)
        Me.Conge_Pris_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Conge_Pris_txt.MaxLength = 32767
        Me.Conge_Pris_txt.Multiline = False
        Me.Conge_Pris_txt.Name = "Conge_Pris_txt"
        Me.Conge_Pris_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Conge_Pris_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Conge_Pris_txt.ReadOnly = True
        Me.Conge_Pris_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Conge_Pris_txt.SelectionStart = 0
        Me.Conge_Pris_txt.Size = New System.Drawing.Size(116, 21)
        Me.Conge_Pris_txt.TabIndex = 248
        Me.Conge_Pris_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Conge_Pris_txt.UseSystemPasswordChar = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(45, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 16)
        Me.Label15.TabIndex = 245
        Me.Label15.Text = "Congé annuel"
        '
        'Conge_Annuel_txt
        '
        Me.Conge_Annuel_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Conge_Annuel_txt.Location = New System.Drawing.Point(134, 23)
        Me.Conge_Annuel_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Conge_Annuel_txt.MaxLength = 32767
        Me.Conge_Annuel_txt.Multiline = False
        Me.Conge_Annuel_txt.Name = "Conge_Annuel_txt"
        Me.Conge_Annuel_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Conge_Annuel_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Conge_Annuel_txt.ReadOnly = True
        Me.Conge_Annuel_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Conge_Annuel_txt.SelectionStart = 0
        Me.Conge_Annuel_txt.Size = New System.Drawing.Size(116, 21)
        Me.Conge_Annuel_txt.TabIndex = 251
        Me.Conge_Annuel_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Conge_Annuel_txt.UseSystemPasswordChar = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(307, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 16)
        Me.Label18.TabIndex = 244
        Me.Label18.Text = "Reliquat antérieurs"
        '
        'Solde_Conge_txt
        '
        Me.Solde_Conge_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Solde_Conge_txt.Location = New System.Drawing.Point(721, 50)
        Me.Solde_Conge_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Solde_Conge_txt.MaxLength = 32767
        Me.Solde_Conge_txt.Multiline = False
        Me.Solde_Conge_txt.Name = "Solde_Conge_txt"
        Me.Solde_Conge_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Solde_Conge_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Solde_Conge_txt.ReadOnly = True
        Me.Solde_Conge_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Solde_Conge_txt.SelectionStart = 0
        Me.Solde_Conge_txt.Size = New System.Drawing.Size(116, 21)
        Me.Solde_Conge_txt.TabIndex = 246
        Me.Solde_Conge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Solde_Conge_txt.UseSystemPasswordChar = False
        '
        'Reliquat_Anterieurs_txt
        '
        Me.Reliquat_Anterieurs_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Reliquat_Anterieurs_txt.Location = New System.Drawing.Point(418, 50)
        Me.Reliquat_Anterieurs_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Reliquat_Anterieurs_txt.MaxLength = 32767
        Me.Reliquat_Anterieurs_txt.Multiline = False
        Me.Reliquat_Anterieurs_txt.Name = "Reliquat_Anterieurs_txt"
        Me.Reliquat_Anterieurs_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Reliquat_Anterieurs_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Reliquat_Anterieurs_txt.ReadOnly = True
        Me.Reliquat_Anterieurs_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Reliquat_Anterieurs_txt.SelectionStart = 0
        Me.Reliquat_Anterieurs_txt.Size = New System.Drawing.Size(116, 21)
        Me.Reliquat_Anterieurs_txt.TabIndex = 250
        Me.Reliquat_Anterieurs_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Reliquat_Anterieurs_txt.UseSystemPasswordChar = False
        '
        'Droit_Conge_txt
        '
        Me.Droit_Conge_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Droit_Conge_txt.Location = New System.Drawing.Point(418, 23)
        Me.Droit_Conge_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Droit_Conge_txt.MaxLength = 32767
        Me.Droit_Conge_txt.Multiline = False
        Me.Droit_Conge_txt.Name = "Droit_Conge_txt"
        Me.Droit_Conge_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Droit_Conge_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Droit_Conge_txt.ReadOnly = True
        Me.Droit_Conge_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Droit_Conge_txt.SelectionStart = 0
        Me.Droit_Conge_txt.Size = New System.Drawing.Size(116, 21)
        Me.Droit_Conge_txt.TabIndex = 247
        Me.Droit_Conge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Droit_Conge_txt.UseSystemPasswordChar = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(23, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 16)
        Me.Label16.TabIndex = 243
        Me.Label16.Text = "Acquis ancienneté"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(624, 52)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(94, 16)
        Me.Label20.TabIndex = 240
        Me.Label20.Text = "Solde de congé"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(649, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 16)
        Me.Label19.TabIndex = 242
        Me.Label19.Text = "Congés pris"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(327, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 16)
        Me.Label17.TabIndex = 241
        Me.Label17.Text = "Droit au congé"
        '
        'Acquis_Anciennete_txt
        '
        Me.Acquis_Anciennete_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Acquis_Anciennete_txt.Location = New System.Drawing.Point(134, 50)
        Me.Acquis_Anciennete_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Acquis_Anciennete_txt.MaxLength = 32767
        Me.Acquis_Anciennete_txt.Multiline = False
        Me.Acquis_Anciennete_txt.Name = "Acquis_Anciennete_txt"
        Me.Acquis_Anciennete_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Acquis_Anciennete_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Acquis_Anciennete_txt.ReadOnly = True
        Me.Acquis_Anciennete_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Acquis_Anciennete_txt.SelectionStart = 0
        Me.Acquis_Anciennete_txt.Size = New System.Drawing.Size(116, 21)
        Me.Acquis_Anciennete_txt.TabIndex = 249
        Me.Acquis_Anciennete_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Acquis_Anciennete_txt.UseSystemPasswordChar = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Num_Conge_txt)
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1167, 164)
        Me.GroupBox2.TabIndex = 256
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fiche signalitique"
        '
        'Num_Conge_txt
        '
        Me.Num_Conge_txt.AccessibleDescription = "A"
        Me.Num_Conge_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Conge_txt.Location = New System.Drawing.Point(79, 47)
        Me.Num_Conge_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Num_Conge_txt.MaxLength = 32767
        Me.Num_Conge_txt.Multiline = False
        Me.Num_Conge_txt.Name = "Num_Conge_txt"
        Me.Num_Conge_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Conge_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Conge_txt.ReadOnly = True
        Me.Num_Conge_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Conge_txt.SelectionStart = 0
        Me.Num_Conge_txt.Size = New System.Drawing.Size(121, 21)
        Me.Num_Conge_txt.TabIndex = 248
        Me.Num_Conge_txt.TabStop = False
        Me.Num_Conge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Conge_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(12, 50)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(63, 16)
        Me.LinkLabel3.TabIndex = 249
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SN"
        Me.LinkLabel3.Text = "Demande"
        '
        'JourPaie_txt
        '
        Me.JourPaie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.JourPaie_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JourPaie_txt.Location = New System.Drawing.Point(779, 130)
        Me.JourPaie_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.JourPaie_txt.MaxLength = 10
        Me.JourPaie_txt.Multiline = False
        Me.JourPaie_txt.Name = "JourPaie_txt"
        Me.JourPaie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.JourPaie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.JourPaie_txt.ReadOnly = True
        Me.JourPaie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.JourPaie_txt.SelectionStart = 0
        Me.JourPaie_txt.Size = New System.Drawing.Size(40, 21)
        Me.JourPaie_txt.TabIndex = 247
        Me.JourPaie_txt.Tag = "4"
        Me.JourPaie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.JourPaie_txt.UseSystemPasswordChar = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(704, 135)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 16)
        Me.Label22.TabIndex = 246
        Me.Label22.Text = "1er jour paie"
        '
        'LastDatePaie_txt
        '
        Me.LastDatePaie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.LastDatePaie_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastDatePaie_txt.Location = New System.Drawing.Point(584, 130)
        Me.LastDatePaie_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LastDatePaie_txt.MaxLength = 10
        Me.LastDatePaie_txt.Multiline = False
        Me.LastDatePaie_txt.Name = "LastDatePaie_txt"
        Me.LastDatePaie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LastDatePaie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.LastDatePaie_txt.ReadOnly = True
        Me.LastDatePaie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.LastDatePaie_txt.SelectionStart = 0
        Me.LastDatePaie_txt.Size = New System.Drawing.Size(101, 21)
        Me.LastDatePaie_txt.TabIndex = 244
        Me.LastDatePaie_txt.Tag = "4"
        Me.LastDatePaie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.LastDatePaie_txt.UseSystemPasswordChar = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(478, 134)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(110, 16)
        Me.Label24.TabIndex = 243
        Me.Label24.Text = "Date dernière paie"
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(80, 130)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Plan_Paie_Text.MaxLength = 6
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(90, 21)
        Me.Cod_Plan_Paie_Text.TabIndex = 242
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(173, 130)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Plan_Paie_Text.MaxLength = 50
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = True
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(273, 21)
        Me.Lib_Plan_Paie_Text.TabIndex = 241
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Lib_Grade_Text
        '
        Me.Lib_Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_Text.Location = New System.Drawing.Point(173, 102)
        Me.Lib_Grade_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Grade_Text.MaxLength = 50
        Me.Lib_Grade_Text.Multiline = False
        Me.Lib_Grade_Text.Name = "Lib_Grade_Text"
        Me.Lib_Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_Text.ReadOnly = True
        Me.Lib_Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_Text.SelectionStart = 0
        Me.Lib_Grade_Text.Size = New System.Drawing.Size(403, 21)
        Me.Lib_Grade_Text.TabIndex = 231
        Me.Lib_Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_Text.UseSystemPasswordChar = False
        '
        'Grade_Text
        '
        Me.Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Grade_Text.Location = New System.Drawing.Point(80, 102)
        Me.Grade_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grade_Text.MaxLength = 6
        Me.Grade_Text.Multiline = False
        Me.Grade_Text.Name = "Grade_Text"
        Me.Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Grade_Text.ReadOnly = True
        Me.Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grade_Text.SelectionStart = 0
        Me.Grade_Text.Size = New System.Drawing.Size(90, 21)
        Me.Grade_Text.TabIndex = 232
        Me.Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Grade_Text.UseSystemPasswordChar = False
        '
        'Lib_Poste_Text
        '
        Me.Lib_Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Poste_Text.Location = New System.Drawing.Point(173, 75)
        Me.Lib_Poste_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Poste_Text.MaxLength = 50
        Me.Lib_Poste_Text.Multiline = False
        Me.Lib_Poste_Text.Name = "Lib_Poste_Text"
        Me.Lib_Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_Text.ReadOnly = True
        Me.Lib_Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_Text.SelectionStart = 0
        Me.Lib_Poste_Text.Size = New System.Drawing.Size(403, 21)
        Me.Lib_Poste_Text.TabIndex = 228
        Me.Lib_Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_Text.UseSystemPasswordChar = False
        '
        'Poste_Text
        '
        Me.Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Poste_Text.Location = New System.Drawing.Point(80, 75)
        Me.Poste_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Poste_Text.MaxLength = 6
        Me.Poste_Text.Multiline = False
        Me.Poste_Text.Name = "Poste_Text"
        Me.Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Poste_Text.ReadOnly = True
        Me.Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Poste_Text.SelectionStart = 0
        Me.Poste_Text.Size = New System.Drawing.Size(90, 21)
        Me.Poste_Text.TabIndex = 229
        Me.Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Poste_Text.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(710, 48)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(403, 21)
        Me.Lib_Entite_txt.TabIndex = 234
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(617, 48)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Entite_txt.MaxLength = 6
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(90, 21)
        Me.Cod_Entite_txt.TabIndex = 235
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Titre_txt
        '
        Me.Titre_txt.AccessibleDescription = "A"
        Me.Titre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Titre_txt.Location = New System.Drawing.Point(617, 75)
        Me.Titre_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Titre_txt.MaxLength = 490
        Me.Titre_txt.Multiline = True
        Me.Titre_txt.Name = "Titre_txt"
        Me.Titre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Titre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Titre_txt.ReadOnly = True
        Me.Titre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Titre_txt.SelectionStart = 0
        Me.Titre_txt.Size = New System.Drawing.Size(496, 51)
        Me.Titre_txt.TabIndex = 236
        Me.Titre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Titre_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(585, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 16)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Titre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Poste"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(42, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 239
        Me.Label9.Text = "Plan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Grade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(577, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 16)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Entité"
        '
        'RH_Demande_Conge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1167, 554)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "RH_Demande_Conge"
        Me.Tag = "ECR"
        Me.Text = "Demande de congé"
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grd_Conge_Detail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Panel1 As Panel
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
    Friend WithEvents Solde_Conge_txt As ud_TextBox
    Friend WithEvents Droit_Conge_txt As ud_TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Conge_Pris_txt As ud_TextBox
    Friend WithEvents Acquis_Anciennete_txt As ud_TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Reliquat_Anterieurs_txt As ud_TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Conge_Annuel_txt As ud_TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Duree_Conge_txt As ud_TextBox
    Friend WithEvents Jours_Feries_txt As ud_TextBox
    Friend WithEvents Repos_Hebdomadaire_txt As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Duree_Globale_txt As ud_TextBox
    Friend WithEvents Dat_Fin_Conge_txt As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Dat_Deb_Conge_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents LastDatePaie_txt As ud_TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents JourPaie_txt As ud_TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Num_Conge_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Commentaire_txt As ud_TextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Grd_Conge_Detail As ud_Grd
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents dureeParDefaut_txt As ud_TextBox
    Friend WithEvents Typ_Conge_txt As ud_TextBox
    Friend WithEvents Lib_Typ_Conge_txt As ud_TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Dat_Fin_am_pm_cbo As ud_ComboBox
    Friend WithEvents Dat_Deb_am_pm_cbo As ud_ComboBox
    Friend WithEvents Dat_Deb As DataGridViewTextBoxColumn
    Friend WithEvents Dat_Fin As DataGridViewTextBoxColumn
    Friend WithEvents Duree_Globale As DataGridViewTextBoxColumn
    Friend WithEvents Repos_Hebdomadaire As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Jours_Feries As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Duree_Conge As DataGridViewTextBoxColumn
End Class
