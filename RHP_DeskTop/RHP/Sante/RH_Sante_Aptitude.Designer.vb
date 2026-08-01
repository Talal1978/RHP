<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Aptitude
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Num_Aptitude_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Visite_Link = New System.Windows.Forms.LinkLabel()
        Me.Num_Visite_txt = New RHP.ud_TextBox()
        Me.Dat_Aptitude_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Aptitude_txt = New RHP.ud_TextBox()
        Me.Cod_Medecin_Link = New System.Windows.Forms.LinkLabel()
        Me.Cod_Medecin_txt = New RHP.ud_TextBox()
        Me.Nom_Medecin_txt = New RHP.ud_TextBox()
        Me.Statut_Aptitude_lbl = New System.Windows.Forms.Label()
        Me.Statut_Aptitude_cbo = New RHP.ud_ComboBox()
        Me.Reserves_lbl = New System.Windows.Forms.Label()
        Me.Reserves_txt = New RHP.ud_TextBox()
        Me.Restrictions_Poste_lbl = New System.Windows.Forms.Label()
        Me.Restrictions_Poste_txt = New RHP.ud_TextBox()
        Me.Amenagements_lbl = New System.Windows.Forms.Label()
        Me.Amenagements_txt = New RHP.ud_TextBox()
        Me.Effet_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Effet_txt = New RHP.ud_TextBox()
        Me.Fin_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Fin_txt = New RHP.ud_TextBox()
        Me.Version_lbl = New System.Windows.Forms.Label()
        Me.Version_txt = New RHP.ud_TextBox()
        Me.Prec_Link = New System.Windows.Forms.LinkLabel()
        Me.Num_Aptitude_Prec_txt = New RHP.ud_TextBox()
        Me.Motif_Version_lbl = New System.Windows.Forms.Label()
        Me.Motif_Version_txt = New RHP.ud_TextBox()
        Me.Publie_RH_chk = New RHP.ud_CheckBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Num_Aptitude_txt)
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Visite_Link)
        Me.GroupBox2.Controls.Add(Me.Num_Visite_txt)
        Me.GroupBox2.Controls.Add(Me.Dat_Aptitude_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Aptitude_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Medecin_Link)
        Me.GroupBox2.Controls.Add(Me.Cod_Medecin_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Medecin_txt)
        Me.GroupBox2.Controls.Add(Me.Statut_Aptitude_lbl)
        Me.GroupBox2.Controls.Add(Me.Statut_Aptitude_cbo)
        Me.GroupBox2.Controls.Add(Me.Reserves_lbl)
        Me.GroupBox2.Controls.Add(Me.Reserves_txt)
        Me.GroupBox2.Controls.Add(Me.Restrictions_Poste_lbl)
        Me.GroupBox2.Controls.Add(Me.Restrictions_Poste_txt)
        Me.GroupBox2.Controls.Add(Me.Amenagements_lbl)
        Me.GroupBox2.Controls.Add(Me.Amenagements_txt)
        Me.GroupBox2.Controls.Add(Me.Effet_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Effet_txt)
        Me.GroupBox2.Controls.Add(Me.Fin_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Fin_txt)
        Me.GroupBox2.Controls.Add(Me.Version_lbl)
        Me.GroupBox2.Controls.Add(Me.Version_txt)
        Me.GroupBox2.Controls.Add(Me.Prec_Link)
        Me.GroupBox2.Controls.Add(Me.Num_Aptitude_Prec_txt)
        Me.GroupBox2.Controls.Add(Me.Motif_Version_lbl)
        Me.GroupBox2.Controls.Add(Me.Motif_Version_txt)
        Me.GroupBox2.Controls.Add(Me.Publie_RH_chk)
        Me.GroupBox2.Controls.Add(Me.pb_Valide)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 460)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fiche d'aptitude"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(105, 45)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(67, 19)
        Me.LinkLabel3.TabIndex = 251
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SN"
        Me.LinkLabel3.Text = "N° Fiche"
        '
        'Num_Aptitude_txt
        '
        Me.Num_Aptitude_txt.AccessibleDescription = "A"
        Me.Num_Aptitude_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Aptitude_txt.ContextMenuStrip = Nothing
        Me.Num_Aptitude_txt.Location = New System.Drawing.Point(220, 43)
        Me.Num_Aptitude_txt.Name = "Num_Aptitude_txt"
        Me.Num_Aptitude_txt.ReadOnly = True
        Me.Num_Aptitude_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Aptitude_txt.TabIndex = 250
        Me.Num_Aptitude_txt.TabStop = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(140, 80)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 252
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        '
        'Matricule_txt
        '
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(220, 78)
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.Size = New System.Drawing.Size(146, 26)
        Me.Matricule_txt.TabIndex = 1
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(374, 78)
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(420, 26)
        Me.Nom_Agent_Text.TabIndex = 2
        '
        'Visite_Link
        '
        Me.Visite_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Visite_Link.AutoSize = True
        Me.Visite_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Visite_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Visite_Link.Location = New System.Drawing.Point(105, 114)
        Me.Visite_Link.Name = "Visite_Link"
        Me.Visite_Link.Size = New System.Drawing.Size(89, 19)
        Me.Visite_Link.TabIndex = 274
        Me.Visite_Link.TabStop = True
        Me.Visite_Link.Tag = "SC"
        Me.Visite_Link.Text = "Visite source"
        '
        'Num_Visite_txt
        '
        Me.Num_Visite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Visite_txt.ContextMenuStrip = Nothing
        Me.Num_Visite_txt.Location = New System.Drawing.Point(220, 110)
        Me.Num_Visite_txt.Name = "Num_Visite_txt"
        Me.Num_Visite_txt.ReadOnly = True
        Me.Num_Visite_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Visite_txt.TabIndex = 273
        '
        'Dat_Aptitude_Link
        '
        Me.Dat_Aptitude_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Aptitude_Link.AutoSize = True
        Me.Dat_Aptitude_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Aptitude_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Aptitude_Link.Location = New System.Drawing.Point(380, 114)
        Me.Dat_Aptitude_Link.Name = "Dat_Aptitude_Link"
        Me.Dat_Aptitude_Link.Size = New System.Drawing.Size(39, 19)
        Me.Dat_Aptitude_Link.TabIndex = 275
        Me.Dat_Aptitude_Link.TabStop = True
        Me.Dat_Aptitude_Link.Tag = "SC"
        Me.Dat_Aptitude_Link.Text = "Date"
        '
        'Dat_Aptitude_txt
        '
        Me.Dat_Aptitude_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Aptitude_txt.ContextMenuStrip = Nothing
        Me.Dat_Aptitude_txt.Location = New System.Drawing.Point(430, 110)
        Me.Dat_Aptitude_txt.Name = "Dat_Aptitude_txt"
        Me.Dat_Aptitude_txt.ReadOnly = True
        Me.Dat_Aptitude_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Aptitude_txt.TabIndex = 276
        Me.Dat_Aptitude_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.Reserves_txt.Name = "Reserves_txt"
        Me.Reserves_txt.Size = New System.Drawing.Size(690, 26)
        Me.Reserves_txt.TabIndex = 17
        '
        'Restrictions_Poste_lbl
        '
        Me.Restrictions_Poste_lbl.AutoSize = True
        Me.Restrictions_Poste_lbl.Location = New System.Drawing.Point(100, 250)
        Me.Restrictions_Poste_lbl.Name = "Restrictions_Poste_lbl"
        Me.Restrictions_Poste_lbl.Size = New System.Drawing.Size(116, 19)
        Me.Restrictions_Poste_lbl.TabIndex = 18
        Me.Restrictions_Poste_lbl.Text = "Restrictions poste"
        '
        'Restrictions_Poste_txt
        '
        Me.Restrictions_Poste_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Restrictions_Poste_txt.ContextMenuStrip = Nothing
        Me.Restrictions_Poste_txt.Location = New System.Drawing.Point(220, 247)
        Me.Restrictions_Poste_txt.Name = "Restrictions_Poste_txt"
        Me.Restrictions_Poste_txt.Size = New System.Drawing.Size(690, 26)
        Me.Restrictions_Poste_txt.TabIndex = 19
        '
        'Amenagements_lbl
        '
        Me.Amenagements_lbl.AutoSize = True
        Me.Amenagements_lbl.Location = New System.Drawing.Point(100, 284)
        Me.Amenagements_lbl.Name = "Amenagements_lbl"
        Me.Amenagements_lbl.Size = New System.Drawing.Size(104, 19)
        Me.Amenagements_lbl.TabIndex = 20
        Me.Amenagements_lbl.Text = "Aménagements"
        '
        'Amenagements_txt
        '
        Me.Amenagements_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Amenagements_txt.ContextMenuStrip = Nothing
        Me.Amenagements_txt.Location = New System.Drawing.Point(220, 281)
        Me.Amenagements_txt.Name = "Amenagements_txt"
        Me.Amenagements_txt.Size = New System.Drawing.Size(690, 26)
        Me.Amenagements_txt.TabIndex = 21
        '
        'Effet_Link
        '
        Me.Effet_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Effet_Link.AutoSize = True
        Me.Effet_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Effet_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Effet_Link.Location = New System.Drawing.Point(150, 318)
        Me.Effet_Link.Name = "Effet_Link"
        Me.Effet_Link.Size = New System.Drawing.Size(37, 19)
        Me.Effet_Link.TabIndex = 22
        Me.Effet_Link.TabStop = True
        Me.Effet_Link.Tag = "SC"
        Me.Effet_Link.Text = "Effet"
        '
        'Dat_Effet_txt
        '
        Me.Dat_Effet_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Effet_txt.ContextMenuStrip = Nothing
        Me.Dat_Effet_txt.Location = New System.Drawing.Point(220, 314)
        Me.Dat_Effet_txt.Name = "Dat_Effet_txt"
        Me.Dat_Effet_txt.ReadOnly = True
        Me.Dat_Effet_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Effet_txt.TabIndex = 23
        Me.Dat_Effet_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Fin_Link
        '
        Me.Fin_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Fin_Link.AutoSize = True
        Me.Fin_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Fin_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Fin_Link.Location = New System.Drawing.Point(340, 318)
        Me.Fin_Link.Name = "Fin_Link"
        Me.Fin_Link.Size = New System.Drawing.Size(72, 19)
        Me.Fin_Link.TabIndex = 24
        Me.Fin_Link.TabStop = True
        Me.Fin_Link.Tag = "SC"
        Me.Fin_Link.Text = "Fin validité"
        '
        'Dat_Fin_txt
        '
        Me.Dat_Fin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Fin_txt.ContextMenuStrip = Nothing
        Me.Dat_Fin_txt.Location = New System.Drawing.Point(420, 314)
        Me.Dat_Fin_txt.Name = "Dat_Fin_txt"
        Me.Dat_Fin_txt.ReadOnly = True
        Me.Dat_Fin_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Fin_txt.TabIndex = 25
        Me.Dat_Fin_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Version_lbl
        '
        Me.Version_lbl.AutoSize = True
        Me.Version_lbl.Location = New System.Drawing.Point(540, 318)
        Me.Version_lbl.Name = "Version_lbl"
        Me.Version_lbl.Size = New System.Drawing.Size(51, 19)
        Me.Version_lbl.TabIndex = 26
        Me.Version_lbl.Text = "Version"
        '
        'Version_txt
        '
        Me.Version_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Version_txt.ContextMenuStrip = Nothing
        Me.Version_txt.Location = New System.Drawing.Point(600, 314)
        Me.Version_txt.Name = "Version_txt"
        Me.Version_txt.ReadOnly = True
        Me.Version_txt.Size = New System.Drawing.Size(80, 26)
        Me.Version_txt.TabIndex = 27
        Me.Version_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Prec_Link
        '
        Me.Prec_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Prec_Link.AutoSize = True
        Me.Prec_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Prec_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Prec_Link.Location = New System.Drawing.Point(80, 352)
        Me.Prec_Link.Name = "Prec_Link"
        Me.Prec_Link.Size = New System.Drawing.Size(136, 19)
        Me.Prec_Link.TabIndex = 28
        Me.Prec_Link.TabStop = True
        Me.Prec_Link.Tag = "SC"
        Me.Prec_Link.Text = "Version précédente"
        '
        'Num_Aptitude_Prec_txt
        '
        Me.Num_Aptitude_Prec_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Aptitude_Prec_txt.ContextMenuStrip = Nothing
        Me.Num_Aptitude_Prec_txt.Location = New System.Drawing.Point(220, 348)
        Me.Num_Aptitude_Prec_txt.Name = "Num_Aptitude_Prec_txt"
        Me.Num_Aptitude_Prec_txt.ReadOnly = True
        Me.Num_Aptitude_Prec_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Aptitude_Prec_txt.TabIndex = 29
        '
        'Motif_Version_lbl
        '
        Me.Motif_Version_lbl.AutoSize = True
        Me.Motif_Version_lbl.Location = New System.Drawing.Point(380, 352)
        Me.Motif_Version_lbl.Name = "Motif_Version_lbl"
        Me.Motif_Version_lbl.Size = New System.Drawing.Size(43, 19)
        Me.Motif_Version_lbl.TabIndex = 30
        Me.Motif_Version_lbl.Text = "Motif"
        '
        'Motif_Version_txt
        '
        Me.Motif_Version_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Motif_Version_txt.ContextMenuStrip = Nothing
        Me.Motif_Version_txt.Location = New System.Drawing.Point(480, 348)
        Me.Motif_Version_txt.Name = "Motif_Version_txt"
        Me.Motif_Version_txt.Size = New System.Drawing.Size(430, 26)
        Me.Motif_Version_txt.TabIndex = 31
        '
        'Publie_RH_chk
        '
        Me.Publie_RH_chk.Location = New System.Drawing.Point(220, 388)
        Me.Publie_RH_chk.Name = "Publie_RH_chk"
        Me.Publie_RH_chk.Size = New System.Drawing.Size(500, 26)
        Me.Publie_RH_chk.TabIndex = 32
        Me.Publie_RH_chk.Text = "Conclusion et restrictions publiables pour la RH (sans contenu clinique)"
        '
        'pb_Valide
        '
        Me.pb_Valide.Location = New System.Drawing.Point(1050, 23)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(122, 123)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_Valide.TabIndex = 33
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'RH_Sante_Aptitude
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Aptitude"
        Me.Tag = "ECR"
        Me.Text = "Fiche d'aptitude"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Num_Aptitude_txt As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Visite_Link As LinkLabel
    Friend WithEvents Num_Visite_txt As ud_TextBox
    Friend WithEvents Dat_Aptitude_Link As LinkLabel
    Friend WithEvents Dat_Aptitude_txt As ud_TextBox
    Friend WithEvents Cod_Medecin_Link As LinkLabel
    Friend WithEvents Cod_Medecin_txt As ud_TextBox
    Friend WithEvents Nom_Medecin_txt As ud_TextBox
    Friend WithEvents Statut_Aptitude_lbl As Label
    Friend WithEvents Statut_Aptitude_cbo As ud_ComboBox
    Friend WithEvents Reserves_lbl As Label
    Friend WithEvents Reserves_txt As ud_TextBox
    Friend WithEvents Restrictions_Poste_lbl As Label
    Friend WithEvents Restrictions_Poste_txt As ud_TextBox
    Friend WithEvents Amenagements_lbl As Label
    Friend WithEvents Amenagements_txt As ud_TextBox
    Friend WithEvents Effet_Link As LinkLabel
    Friend WithEvents Dat_Effet_txt As ud_TextBox
    Friend WithEvents Fin_Link As LinkLabel
    Friend WithEvents Dat_Fin_txt As ud_TextBox
    Friend WithEvents Version_lbl As Label
    Friend WithEvents Version_txt As ud_TextBox
    Friend WithEvents Prec_Link As LinkLabel
    Friend WithEvents Num_Aptitude_Prec_txt As ud_TextBox
    Friend WithEvents Motif_Version_lbl As Label
    Friend WithEvents Motif_Version_txt As ud_TextBox
    Friend WithEvents Publie_RH_chk As ud_CheckBox
    Friend WithEvents pb_Valide As PictureBox
End Class
