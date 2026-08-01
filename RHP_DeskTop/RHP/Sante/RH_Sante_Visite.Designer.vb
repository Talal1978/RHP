<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Visite
    Inherits Ecran

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grd_Historique = New RHP.ud_Grd()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Num_Visite_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Dat_Visite_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Visite_txt = New RHP.ud_TextBox()
        Me.Typ_Visite_lbl = New System.Windows.Forms.Label()
        Me.Typ_Visite_cbo = New RHP.ud_ComboBox()
        Me.Cod_Medecin_Link = New System.Windows.Forms.LinkLabel()
        Me.Cod_Medecin_txt = New RHP.ud_TextBox()
        Me.Nom_Medecin_txt = New RHP.ud_TextBox()
        Me.Cod_Campagne_Link = New System.Windows.Forms.LinkLabel()
        Me.Cod_Campagne_txt = New RHP.ud_TextBox()
        Me.Statut_Aptitude_lbl = New System.Windows.Forms.Label()
        Me.Statut_Aptitude_cbo = New RHP.ud_ComboBox()
        Me.Reserves_lbl = New System.Windows.Forms.Label()
        Me.Reserves_txt = New RHP.ud_TextBox()
        Me.Restrictions_lbl = New System.Windows.Forms.Label()
        Me.Restrictions_txt = New RHP.ud_TextBox()
        Me.Conclusion_lbl = New System.Windows.Forms.Label()
        Me.Conclusion_txt = New RHP.ud_TextBox()
        Me.Prochaine_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Prochaine_Visite_txt = New RHP.ud_TextBox()
        Me.Recalcul_Btn = New RHP.ud_button()
        Me.Cod_Regle_lbl = New System.Windows.Forms.Label()
        Me.Cod_Regle_txt = New RHP.ud_TextBox()
        Me.Motif_Ajustement_lbl = New System.Windows.Forms.Label()
        Me.Motif_Ajustement_txt = New RHP.ud_TextBox()
        Me.Rectifie_Link = New System.Windows.Forms.LinkLabel()
        Me.Num_Visite_Rectifiee_txt = New RHP.ud_TextBox()
        Me.Motif_Rectification_lbl = New System.Windows.Forms.Label()
        Me.Motif_Rectification_txt = New RHP.ud_TextBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Historique, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grd_Historique)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1428, 714)
        Me.Panel1.TabIndex = 3
        '
        'Grd_Historique
        '
        Me.Grd_Historique.AfficherLesEntetesLignes = True
        Me.Grd_Historique.AlternerLesLignes = False
        Me.Grd_Historique.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Historique.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Historique.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Historique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Historique.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Historique.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Historique.EnableHeadersVisualStyles = False
        Me.Grd_Historique.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Historique.Location = New System.Drawing.Point(0, 460)
        Me.Grd_Historique.Name = "Grd_Historique"
        Me.Grd_Historique.ReadOnly = True
        Me.Grd_Historique.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Historique.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Historique.RowHeadersWidth = 51
        Me.Grd_Historique.Size = New System.Drawing.Size(1428, 254)
        Me.Grd_Historique.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Num_Visite_txt)
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Dat_Visite_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Visite_txt)
        Me.GroupBox2.Controls.Add(Me.Typ_Visite_lbl)
        Me.GroupBox2.Controls.Add(Me.Typ_Visite_cbo)
        Me.GroupBox2.Controls.Add(Me.Cod_Medecin_Link)
        Me.GroupBox2.Controls.Add(Me.Cod_Medecin_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Medecin_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Campagne_Link)
        Me.GroupBox2.Controls.Add(Me.Cod_Campagne_txt)
        Me.GroupBox2.Controls.Add(Me.Statut_Aptitude_lbl)
        Me.GroupBox2.Controls.Add(Me.Statut_Aptitude_cbo)
        Me.GroupBox2.Controls.Add(Me.Reserves_lbl)
        Me.GroupBox2.Controls.Add(Me.Reserves_txt)
        Me.GroupBox2.Controls.Add(Me.Restrictions_lbl)
        Me.GroupBox2.Controls.Add(Me.Restrictions_txt)
        Me.GroupBox2.Controls.Add(Me.Conclusion_lbl)
        Me.GroupBox2.Controls.Add(Me.Conclusion_txt)
        Me.GroupBox2.Controls.Add(Me.Prochaine_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Prochaine_Visite_txt)
        Me.GroupBox2.Controls.Add(Me.Recalcul_Btn)
        Me.GroupBox2.Controls.Add(Me.Cod_Regle_lbl)
        Me.GroupBox2.Controls.Add(Me.Cod_Regle_txt)
        Me.GroupBox2.Controls.Add(Me.Motif_Ajustement_lbl)
        Me.GroupBox2.Controls.Add(Me.Motif_Ajustement_txt)
        Me.GroupBox2.Controls.Add(Me.Rectifie_Link)
        Me.GroupBox2.Controls.Add(Me.Num_Visite_Rectifiee_txt)
        Me.GroupBox2.Controls.Add(Me.Motif_Rectification_lbl)
        Me.GroupBox2.Controls.Add(Me.Motif_Rectification_txt)
        Me.GroupBox2.Controls.Add(Me.pb_Valide)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 460)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Visite médicale"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(105, 45)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(68, 19)
        Me.LinkLabel3.TabIndex = 251
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SN"
        Me.LinkLabel3.Text = "N° Visite"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Num_Visite_txt
        '
        Me.Num_Visite_txt.AccessibleDescription = "A"
        Me.Num_Visite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Visite_txt.ContextMenuStrip = Nothing
        Me.Num_Visite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_Visite_txt.Location = New System.Drawing.Point(220, 43)
        Me.Num_Visite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Num_Visite_txt.MaxLength = 32767
        Me.Num_Visite_txt.Multiline = False
        Me.Num_Visite_txt.Name = "Num_Visite_txt"
        Me.Num_Visite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Visite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Visite_txt.ReadOnly = True
        Me.Num_Visite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Visite_txt.SelectionStart = 0
        Me.Num_Visite_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Visite_txt.TabIndex = 250
        Me.Num_Visite_txt.TabStop = False
        Me.Num_Visite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Visite_txt.UseSystemPasswordChar = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(140, 80)
        Me.Matricule_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 252
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        Me.Matricule_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Matricule_txt
        '
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(220, 78)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(146, 26)
        Me.Matricule_txt.TabIndex = 1
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(374, 78)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(536, 26)
        Me.Nom_Agent_Text.TabIndex = 2
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Dat_Visite_Link
        '
        Me.Dat_Visite_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Visite_Link.AutoSize = True
        Me.Dat_Visite_Link.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Visite_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Visite_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Visite_Link.Location = New System.Drawing.Point(106, 114)
        Me.Dat_Visite_Link.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Dat_Visite_Link.Name = "Dat_Visite_Link"
        Me.Dat_Visite_Link.Size = New System.Drawing.Size(80, 19)
        Me.Dat_Visite_Link.TabIndex = 274
        Me.Dat_Visite_Link.TabStop = True
        Me.Dat_Visite_Link.Tag = "SC"
        Me.Dat_Visite_Link.Text = "Date visite"
        Me.Dat_Visite_Link.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dat_Visite_txt
        '
        Me.Dat_Visite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Visite_txt.ContextMenuStrip = Nothing
        Me.Dat_Visite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Visite_txt.Location = New System.Drawing.Point(220, 110)
        Me.Dat_Visite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dat_Visite_txt.MaxLength = 32767
        Me.Dat_Visite_txt.Multiline = False
        Me.Dat_Visite_txt.Name = "Dat_Visite_txt"
        Me.Dat_Visite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Visite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Visite_txt.ReadOnly = True
        Me.Dat_Visite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Visite_txt.SelectionStart = 0
        Me.Dat_Visite_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Visite_txt.TabIndex = 273
        Me.Dat_Visite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Visite_txt.UseSystemPasswordChar = False
        '
        'Typ_Visite_lbl
        '
        Me.Typ_Visite_lbl.AutoSize = True
        Me.Typ_Visite_lbl.Location = New System.Drawing.Point(333, 116)
        Me.Typ_Visite_lbl.Name = "Typ_Visite_lbl"
        Me.Typ_Visite_lbl.Size = New System.Drawing.Size(91, 19)
        Me.Typ_Visite_lbl.TabIndex = 7
        Me.Typ_Visite_lbl.Text = "Type de visite"
        '
        'Typ_Visite_cbo
        '
        Me.Typ_Visite_cbo.DataSource = Nothing
        Me.Typ_Visite_cbo.DisplayMember = ""
        Me.Typ_Visite_cbo.DroppedDown = False
        Me.Typ_Visite_cbo.Location = New System.Drawing.Point(430, 110)
        Me.Typ_Visite_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Visite_cbo.Name = "Typ_Visite_cbo"
        Me.Typ_Visite_cbo.SelectedIndex = -1
        Me.Typ_Visite_cbo.SelectedItem = Nothing
        Me.Typ_Visite_cbo.SelectedValue = Nothing
        Me.Typ_Visite_cbo.Size = New System.Drawing.Size(250, 26)
        Me.Typ_Visite_cbo.TabIndex = 8
        Me.Typ_Visite_cbo.ValueMember = ""
        '
        'Cod_Medecin_Link
        '
        Me.Cod_Medecin_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Medecin_Link.AutoSize = True
        Me.Cod_Medecin_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Medecin_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Medecin_Link.Location = New System.Drawing.Point(140, 148)
        Me.Cod_Medecin_Link.Name = "Cod_Medecin_Link"
        Me.Cod_Medecin_Link.Size = New System.Drawing.Size(63, 19)
        Me.Cod_Medecin_Link.TabIndex = 9
        Me.Cod_Medecin_Link.TabStop = True
        Me.Cod_Medecin_Link.Tag = "SC"
        Me.Cod_Medecin_Link.Text = "Médecin"
        '
        'Cod_Medecin_txt
        '
        Me.Cod_Medecin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Medecin_txt.ContextMenuStrip = Nothing
        Me.Cod_Medecin_txt.Location = New System.Drawing.Point(220, 144)
        Me.Cod_Medecin_txt.Name = "Cod_Medecin_txt"
        Me.Cod_Medecin_txt.ReadOnly = True
        Me.Cod_Medecin_txt.Size = New System.Drawing.Size(100, 26)
        Me.Cod_Medecin_txt.TabIndex = 10
        '
        'Nom_Medecin_txt
        '
        Me.Nom_Medecin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Medecin_txt.ContextMenuStrip = Nothing
        Me.Nom_Medecin_txt.Location = New System.Drawing.Point(330, 144)
        Me.Nom_Medecin_txt.Name = "Nom_Medecin_txt"
        Me.Nom_Medecin_txt.ReadOnly = True
        Me.Nom_Medecin_txt.Size = New System.Drawing.Size(350, 26)
        Me.Nom_Medecin_txt.TabIndex = 11
        '
        'Cod_Campagne_Link
        '
        Me.Cod_Campagne_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Campagne_Link.AutoSize = True
        Me.Cod_Campagne_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Campagne_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Campagne_Link.Location = New System.Drawing.Point(700, 148)
        Me.Cod_Campagne_Link.Name = "Cod_Campagne_Link"
        Me.Cod_Campagne_Link.Size = New System.Drawing.Size(75, 19)
        Me.Cod_Campagne_Link.TabIndex = 12
        Me.Cod_Campagne_Link.TabStop = True
        Me.Cod_Campagne_Link.Tag = "SC"
        Me.Cod_Campagne_Link.Text = "Campagne"
        '
        'Cod_Campagne_txt
        '
        Me.Cod_Campagne_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Campagne_txt.ContextMenuStrip = Nothing
        Me.Cod_Campagne_txt.Location = New System.Drawing.Point(790, 144)
        Me.Cod_Campagne_txt.Name = "Cod_Campagne_txt"
        Me.Cod_Campagne_txt.ReadOnly = True
        Me.Cod_Campagne_txt.Size = New System.Drawing.Size(120, 26)
        Me.Cod_Campagne_txt.TabIndex = 13
        '
        'Statut_Aptitude_lbl
        '
        Me.Statut_Aptitude_lbl.AutoSize = True
        Me.Statut_Aptitude_lbl.Location = New System.Drawing.Point(118, 182)
        Me.Statut_Aptitude_lbl.Name = "Statut_Aptitude_lbl"
        Me.Statut_Aptitude_lbl.Size = New System.Drawing.Size(98, 19)
        Me.Statut_Aptitude_lbl.TabIndex = 14
        Me.Statut_Aptitude_lbl.Text = "Statut aptitude"
        '
        'Statut_Aptitude_cbo
        '
        Me.Statut_Aptitude_cbo.DataSource = Nothing
        Me.Statut_Aptitude_cbo.DisplayMember = ""
        Me.Statut_Aptitude_cbo.DroppedDown = False
        Me.Statut_Aptitude_cbo.Location = New System.Drawing.Point(220, 178)
        Me.Statut_Aptitude_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Statut_Aptitude_cbo.Name = "Statut_Aptitude_cbo"
        Me.Statut_Aptitude_cbo.SelectedIndex = -1
        Me.Statut_Aptitude_cbo.SelectedItem = Nothing
        Me.Statut_Aptitude_cbo.SelectedValue = Nothing
        Me.Statut_Aptitude_cbo.Size = New System.Drawing.Size(250, 26)
        Me.Statut_Aptitude_cbo.TabIndex = 15
        Me.Statut_Aptitude_cbo.ValueMember = ""
        '
        'Reserves_lbl
        '
        Me.Reserves_lbl.AutoSize = True
        Me.Reserves_lbl.Location = New System.Drawing.Point(150, 216)
        Me.Reserves_lbl.Name = "Reserves_lbl"
        Me.Reserves_lbl.Size = New System.Drawing.Size(66, 19)
        Me.Reserves_lbl.TabIndex = 16
        Me.Reserves_lbl.Text = "Réserves"
        '
        'Reserves_txt
        '
        Me.Reserves_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Reserves_txt.ContextMenuStrip = Nothing
        Me.Reserves_txt.Location = New System.Drawing.Point(220, 213)
        Me.Reserves_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Reserves_txt.MaxLength = 32767
        Me.Reserves_txt.Multiline = False
        Me.Reserves_txt.Name = "Reserves_txt"
        Me.Reserves_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Reserves_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Reserves_txt.ReadOnly = False
        Me.Reserves_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Reserves_txt.SelectionStart = 0
        Me.Reserves_txt.Size = New System.Drawing.Size(690, 26)
        Me.Reserves_txt.TabIndex = 17
        Me.Reserves_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Reserves_txt.UseSystemPasswordChar = False
        '
        'Restrictions_lbl
        '
        Me.Restrictions_lbl.AutoSize = True
        Me.Restrictions_lbl.Location = New System.Drawing.Point(128, 250)
        Me.Restrictions_lbl.Name = "Restrictions_lbl"
        Me.Restrictions_lbl.Size = New System.Drawing.Size(82, 19)
        Me.Restrictions_lbl.TabIndex = 18
        Me.Restrictions_lbl.Text = "Restrictions"
        '
        'Restrictions_txt
        '
        Me.Restrictions_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Restrictions_txt.ContextMenuStrip = Nothing
        Me.Restrictions_txt.Location = New System.Drawing.Point(220, 247)
        Me.Restrictions_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Restrictions_txt.MaxLength = 32767
        Me.Restrictions_txt.Multiline = False
        Me.Restrictions_txt.Name = "Restrictions_txt"
        Me.Restrictions_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Restrictions_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Restrictions_txt.ReadOnly = False
        Me.Restrictions_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Restrictions_txt.SelectionStart = 0
        Me.Restrictions_txt.Size = New System.Drawing.Size(690, 26)
        Me.Restrictions_txt.TabIndex = 19
        Me.Restrictions_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Restrictions_txt.UseSystemPasswordChar = False
        '
        'Conclusion_lbl
        '
        Me.Conclusion_lbl.AutoSize = True
        Me.Conclusion_lbl.Location = New System.Drawing.Point(135, 285)
        Me.Conclusion_lbl.Name = "Conclusion_lbl"
        Me.Conclusion_lbl.Size = New System.Drawing.Size(81, 19)
        Me.Conclusion_lbl.TabIndex = 20
        Me.Conclusion_lbl.Text = "Conclusion"
        '
        'Conclusion_txt
        '
        Me.Conclusion_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Conclusion_txt.ContextMenuStrip = Nothing
        Me.Conclusion_txt.Location = New System.Drawing.Point(220, 281)
        Me.Conclusion_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Conclusion_txt.MaxLength = 32767
        Me.Conclusion_txt.Multiline = True
        Me.Conclusion_txt.Name = "Conclusion_txt"
        Me.Conclusion_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Conclusion_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Conclusion_txt.ReadOnly = False
        Me.Conclusion_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Conclusion_txt.SelectionStart = 0
        Me.Conclusion_txt.Size = New System.Drawing.Size(690, 60)
        Me.Conclusion_txt.TabIndex = 21
        Me.Conclusion_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Conclusion_txt.UseSystemPasswordChar = False
        '
        'Prochaine_Link
        '
        Me.Prochaine_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Prochaine_Link.AutoSize = True
        Me.Prochaine_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Prochaine_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Prochaine_Link.Location = New System.Drawing.Point(100, 352)
        Me.Prochaine_Link.Name = "Prochaine_Link"
        Me.Prochaine_Link.Size = New System.Drawing.Size(110, 19)
        Me.Prochaine_Link.TabIndex = 22
        Me.Prochaine_Link.TabStop = True
        Me.Prochaine_Link.Tag = "SC"
        Me.Prochaine_Link.Text = "Prochaine visite"
        '
        'Dat_Prochaine_Visite_txt
        '
        Me.Dat_Prochaine_Visite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Prochaine_Visite_txt.ContextMenuStrip = Nothing
        Me.Dat_Prochaine_Visite_txt.Location = New System.Drawing.Point(220, 348)
        Me.Dat_Prochaine_Visite_txt.Name = "Dat_Prochaine_Visite_txt"
        Me.Dat_Prochaine_Visite_txt.ReadOnly = True
        Me.Dat_Prochaine_Visite_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Prochaine_Visite_txt.TabIndex = 23
        Me.Dat_Prochaine_Visite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Recalcul_Btn
        '
        Me.Recalcul_Btn.Location = New System.Drawing.Point(320, 348)
        Me.Recalcul_Btn.Name = "Recalcul_Btn"
        Me.Recalcul_Btn.Size = New System.Drawing.Size(90, 26)
        Me.Recalcul_Btn.TabIndex = 24
        Me.Recalcul_Btn.Text = "Recalculer"
        '
        'Cod_Regle_lbl
        '
        Me.Cod_Regle_lbl.AutoSize = True
        Me.Cod_Regle_lbl.Location = New System.Drawing.Point(420, 352)
        Me.Cod_Regle_lbl.Name = "Cod_Regle_lbl"
        Me.Cod_Regle_lbl.Size = New System.Drawing.Size(95, 19)
        Me.Cod_Regle_lbl.TabIndex = 25
        Me.Cod_Regle_lbl.Text = "Règle appliquée"
        '
        'Cod_Regle_txt
        '
        Me.Cod_Regle_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Regle_txt.ContextMenuStrip = Nothing
        Me.Cod_Regle_txt.Location = New System.Drawing.Point(520, 348)
        Me.Cod_Regle_txt.Name = "Cod_Regle_txt"
        Me.Cod_Regle_txt.ReadOnly = True
        Me.Cod_Regle_txt.Size = New System.Drawing.Size(120, 26)
        Me.Cod_Regle_txt.TabIndex = 26
        '
        'Motif_Ajustement_lbl
        '
        Me.Motif_Ajustement_lbl.AutoSize = True
        Me.Motif_Ajustement_lbl.Location = New System.Drawing.Point(100, 386)
        Me.Motif_Ajustement_lbl.Name = "Motif_Ajustement_lbl"
        Me.Motif_Ajustement_lbl.Size = New System.Drawing.Size(110, 19)
        Me.Motif_Ajustement_lbl.TabIndex = 27
        Me.Motif_Ajustement_lbl.Text = "Motif ajustement"
        '
        'Motif_Ajustement_txt
        '
        Me.Motif_Ajustement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Motif_Ajustement_txt.ContextMenuStrip = Nothing
        Me.Motif_Ajustement_txt.Location = New System.Drawing.Point(220, 382)
        Me.Motif_Ajustement_txt.Name = "Motif_Ajustement_txt"
        Me.Motif_Ajustement_txt.Size = New System.Drawing.Size(690, 26)
        Me.Motif_Ajustement_txt.TabIndex = 28
        '
        'Rectifie_Link
        '
        Me.Rectifie_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rectifie_Link.AutoSize = True
        Me.Rectifie_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rectifie_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rectifie_Link.Location = New System.Drawing.Point(88, 420)
        Me.Rectifie_Link.Name = "Rectifie_Link"
        Me.Rectifie_Link.Size = New System.Drawing.Size(122, 19)
        Me.Rectifie_Link.TabIndex = 29
        Me.Rectifie_Link.TabStop = True
        Me.Rectifie_Link.Tag = "SC"
        Me.Rectifie_Link.Text = "Rectifie la visite"
        '
        'Num_Visite_Rectifiee_txt
        '
        Me.Num_Visite_Rectifiee_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Visite_Rectifiee_txt.ContextMenuStrip = Nothing
        Me.Num_Visite_Rectifiee_txt.Location = New System.Drawing.Point(220, 416)
        Me.Num_Visite_Rectifiee_txt.Name = "Num_Visite_Rectifiee_txt"
        Me.Num_Visite_Rectifiee_txt.ReadOnly = True
        Me.Num_Visite_Rectifiee_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Visite_Rectifiee_txt.TabIndex = 30
        '
        'Motif_Rectification_lbl
        '
        Me.Motif_Rectification_lbl.AutoSize = True
        Me.Motif_Rectification_lbl.Location = New System.Drawing.Point(380, 420)
        Me.Motif_Rectification_lbl.Name = "Motif_Rectification_lbl"
        Me.Motif_Rectification_lbl.Size = New System.Drawing.Size(43, 19)
        Me.Motif_Rectification_lbl.TabIndex = 31
        Me.Motif_Rectification_lbl.Text = "Motif"
        '
        'Motif_Rectification_txt
        '
        Me.Motif_Rectification_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Motif_Rectification_txt.ContextMenuStrip = Nothing
        Me.Motif_Rectification_txt.Location = New System.Drawing.Point(480, 416)
        Me.Motif_Rectification_txt.Name = "Motif_Rectification_txt"
        Me.Motif_Rectification_txt.Size = New System.Drawing.Size(430, 26)
        Me.Motif_Rectification_txt.TabIndex = 32
        '
        'pb_Valide
        '
        Me.pb_Valide.Location = New System.Drawing.Point(1050, 23)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(122, 123)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_Valide.TabIndex = 27
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'RH_Sante_Visite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Visite"
        Me.Tag = "ECR"
        Me.Text = "Visite médicale"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Historique, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grd_Historique As ud_Grd
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Num_Visite_txt As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Dat_Visite_Link As LinkLabel
    Friend WithEvents Dat_Visite_txt As ud_TextBox
    Friend WithEvents Typ_Visite_lbl As Label
    Friend WithEvents Typ_Visite_cbo As ud_ComboBox
    Friend WithEvents Cod_Medecin_Link As LinkLabel
    Friend WithEvents Cod_Medecin_txt As ud_TextBox
    Friend WithEvents Nom_Medecin_txt As ud_TextBox
    Friend WithEvents Cod_Campagne_Link As LinkLabel
    Friend WithEvents Cod_Campagne_txt As ud_TextBox
    Friend WithEvents Statut_Aptitude_lbl As Label
    Friend WithEvents Statut_Aptitude_cbo As ud_ComboBox
    Friend WithEvents Reserves_lbl As Label
    Friend WithEvents Reserves_txt As ud_TextBox
    Friend WithEvents Restrictions_lbl As Label
    Friend WithEvents Restrictions_txt As ud_TextBox
    Friend WithEvents Conclusion_lbl As Label
    Friend WithEvents Conclusion_txt As ud_TextBox
    Friend WithEvents Prochaine_Link As LinkLabel
    Friend WithEvents Dat_Prochaine_Visite_txt As ud_TextBox
    Friend WithEvents Recalcul_Btn As ud_button
    Friend WithEvents Cod_Regle_lbl As Label
    Friend WithEvents Cod_Regle_txt As ud_TextBox
    Friend WithEvents Motif_Ajustement_lbl As Label
    Friend WithEvents Motif_Ajustement_txt As ud_TextBox
    Friend WithEvents Rectifie_Link As LinkLabel
    Friend WithEvents Num_Visite_Rectifiee_txt As ud_TextBox
    Friend WithEvents Motif_Rectification_lbl As Label
    Friend WithEvents Motif_Rectification_txt As ud_TextBox
    Friend WithEvents pb_Valide As PictureBox
End Class
