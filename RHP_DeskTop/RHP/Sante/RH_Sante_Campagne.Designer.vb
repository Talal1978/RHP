<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Campagne
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
        Me.Grd_Convocations = New RHP.ud_Grd()
        Me.Matricule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dat_Convocation = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Heure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Statut_Convocation = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Dat_Envoi = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Num_Visite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Commentaire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Cod_Campagne_txt = New RHP.ud_TextBox()
        Me.Lib_Campagne_lbl = New System.Windows.Forms.Label()
        Me.Lib_Campagne_txt = New RHP.ud_TextBox()
        Me.Typ_Visite_lbl = New System.Windows.Forms.Label()
        Me.Typ_Visite_cbo = New RHP.ud_ComboBox()
        Me.Dat_Deb_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Deb_txt = New RHP.ud_TextBox()
        Me.Dat_Fin_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Fin_txt = New RHP.ud_TextBox()
        Me.Cod_Medecin_Link = New System.Windows.Forms.LinkLabel()
        Me.Cod_Medecin_txt = New RHP.ud_TextBox()
        Me.Nom_Medecin_txt = New RHP.ud_TextBox()
        Me.Lieu_lbl = New System.Windows.Forms.Label()
        Me.Lieu_txt = New RHP.ud_TextBox()
        Me.Statut_lbl = New System.Windows.Forms.Label()
        Me.Statut_cbo = New RHP.ud_ComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Convocations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grd_Convocations)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1428, 714)
        Me.Panel1.TabIndex = 3
        '
        'Grd_Convocations
        '
        Me.Grd_Convocations.AfficherLesEntetesLignes = True
        Me.Grd_Convocations.AlternerLesLignes = False
        Me.Grd_Convocations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Convocations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Convocations.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Convocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Convocations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Matricule, Me.Dat_Convocation, Me.Heure, Me.Statut_Convocation, Me.Dat_Envoi, Me.Num_Visite, Me.Commentaire})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Convocations.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Convocations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Convocations.EnableHeadersVisualStyles = False
        Me.Grd_Convocations.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Convocations.Location = New System.Drawing.Point(0, 190)
        Me.Grd_Convocations.Name = "Grd_Convocations"
        Me.Grd_Convocations.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Convocations.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Convocations.RowHeadersWidth = 51
        Me.Grd_Convocations.Size = New System.Drawing.Size(1428, 524)
        Me.Grd_Convocations.TabIndex = 0
        '
        'Matricule
        '
        Me.Matricule.HeaderText = "Matricule"
        Me.Matricule.MinimumWidth = 6
        Me.Matricule.Name = "Matricule"
        Me.Matricule.ReadOnly = True
        Me.Matricule.Width = 120
        '
        'Dat_Convocation
        '
        '
        '
        '
        Me.Dat_Convocation.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat_Convocation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Convocation.HeaderText = "Convocation"
        Me.Dat_Convocation.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Dat_Convocation.MinimumWidth = 6
        '
        '
        '
        Me.Dat_Convocation.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Convocation.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat_Convocation.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat_Convocation.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat_Convocation.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Convocation.MonthCalendar.DisplayMonth = New Date(2026, 1, 1, 0, 0, 0, 0)
        Me.Dat_Convocation.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat_Convocation.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Convocation.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat_Convocation.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Convocation.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat_Convocation.Name = "Dat_Convocation"
        Me.Dat_Convocation.Width = 130
        '
        'Heure
        '
        Me.Heure.HeaderText = "Heure"
        Me.Heure.MinimumWidth = 6
        Me.Heure.Name = "Heure"
        Me.Heure.Width = 80
        '
        'Statut_Convocation
        '
        Me.Statut_Convocation.HeaderText = "Statut"
        Me.Statut_Convocation.MinimumWidth = 6
        Me.Statut_Convocation.Name = "Statut_Convocation"
        Me.Statut_Convocation.Width = 140
        '
        'Dat_Envoi
        '
        '
        '
        '
        Me.Dat_Envoi.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat_Envoi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Envoi.HeaderText = "Envoyée le"
        Me.Dat_Envoi.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Dat_Envoi.MinimumWidth = 6
        '
        '
        '
        Me.Dat_Envoi.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Envoi.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat_Envoi.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat_Envoi.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat_Envoi.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Envoi.MonthCalendar.DisplayMonth = New Date(2026, 1, 1, 0, 0, 0, 0)
        Me.Dat_Envoi.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat_Envoi.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Envoi.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat_Envoi.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Envoi.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat_Envoi.Name = "Dat_Envoi"
        Me.Dat_Envoi.ReadOnly = True
        Me.Dat_Envoi.Width = 130
        '
        'Num_Visite
        '
        Me.Num_Visite.HeaderText = "Visite réalisée"
        Me.Num_Visite.MinimumWidth = 6
        Me.Num_Visite.Name = "Num_Visite"
        Me.Num_Visite.ReadOnly = True
        Me.Num_Visite.Width = 150
        '
        'Commentaire
        '
        Me.Commentaire.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Commentaire.HeaderText = "Commentaire"
        Me.Commentaire.MinimumWidth = 6
        Me.Commentaire.Name = "Commentaire"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Cod_Campagne_txt)
        Me.GroupBox2.Controls.Add(Me.Lib_Campagne_lbl)
        Me.GroupBox2.Controls.Add(Me.Lib_Campagne_txt)
        Me.GroupBox2.Controls.Add(Me.Typ_Visite_lbl)
        Me.GroupBox2.Controls.Add(Me.Typ_Visite_cbo)
        Me.GroupBox2.Controls.Add(Me.Dat_Deb_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Deb_txt)
        Me.GroupBox2.Controls.Add(Me.Dat_Fin_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Fin_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Medecin_Link)
        Me.GroupBox2.Controls.Add(Me.Cod_Medecin_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Medecin_txt)
        Me.GroupBox2.Controls.Add(Me.Lieu_lbl)
        Me.GroupBox2.Controls.Add(Me.Lieu_txt)
        Me.GroupBox2.Controls.Add(Me.Statut_lbl)
        Me.GroupBox2.Controls.Add(Me.Statut_cbo)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 190)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Campagne de visites médicales"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(105, 45)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(103, 19)
        Me.LinkLabel3.TabIndex = 251
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SN"
        Me.LinkLabel3.Text = "Cod_Campagne"
        '
        'Cod_Campagne_txt
        '
        Me.Cod_Campagne_txt.AccessibleDescription = "A"
        Me.Cod_Campagne_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Campagne_txt.ContextMenuStrip = Nothing
        Me.Cod_Campagne_txt.Location = New System.Drawing.Point(220, 43)
        Me.Cod_Campagne_txt.Name = "Cod_Campagne_txt"
        Me.Cod_Campagne_txt.ReadOnly = True
        Me.Cod_Campagne_txt.Size = New System.Drawing.Size(146, 26)
        Me.Cod_Campagne_txt.TabIndex = 250
        Me.Cod_Campagne_txt.TabStop = False
        '
        'Lib_Campagne_lbl
        '
        Me.Lib_Campagne_lbl.AutoSize = True
        Me.Lib_Campagne_lbl.Location = New System.Drawing.Point(115, 80)
        Me.Lib_Campagne_lbl.Name = "Lib_Campagne_lbl"
        Me.Lib_Campagne_lbl.Size = New System.Drawing.Size(101, 19)
        Me.Lib_Campagne_lbl.TabIndex = 3
        Me.Lib_Campagne_lbl.Text = "Libellé campagne"
        '
        'Lib_Campagne_txt
        '
        Me.Lib_Campagne_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Campagne_txt.ContextMenuStrip = Nothing
        Me.Lib_Campagne_txt.Location = New System.Drawing.Point(220, 78)
        Me.Lib_Campagne_txt.Name = "Lib_Campagne_txt"
        Me.Lib_Campagne_txt.Size = New System.Drawing.Size(500, 26)
        Me.Lib_Campagne_txt.TabIndex = 4
        '
        'Typ_Visite_lbl
        '
        Me.Typ_Visite_lbl.AutoSize = True
        Me.Typ_Visite_lbl.Location = New System.Drawing.Point(125, 114)
        Me.Typ_Visite_lbl.Name = "Typ_Visite_lbl"
        Me.Typ_Visite_lbl.Size = New System.Drawing.Size(91, 19)
        Me.Typ_Visite_lbl.TabIndex = 5
        Me.Typ_Visite_lbl.Text = "Type de visite"
        '
        'Typ_Visite_cbo
        '
        Me.Typ_Visite_cbo.DataSource = Nothing
        Me.Typ_Visite_cbo.DisplayMember = ""
        Me.Typ_Visite_cbo.DroppedDown = False
        Me.Typ_Visite_cbo.Location = New System.Drawing.Point(220, 110)
        Me.Typ_Visite_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Visite_cbo.Name = "Typ_Visite_cbo"
        Me.Typ_Visite_cbo.SelectedIndex = -1
        Me.Typ_Visite_cbo.SelectedItem = Nothing
        Me.Typ_Visite_cbo.SelectedValue = Nothing
        Me.Typ_Visite_cbo.Size = New System.Drawing.Size(250, 26)
        Me.Typ_Visite_cbo.TabIndex = 6
        Me.Typ_Visite_cbo.ValueMember = ""
        '
        'Dat_Deb_Link
        '
        Me.Dat_Deb_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Deb_Link.AutoSize = True
        Me.Dat_Deb_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Deb_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Deb_Link.Location = New System.Drawing.Point(500, 114)
        Me.Dat_Deb_Link.Name = "Dat_Deb_Link"
        Me.Dat_Deb_Link.Size = New System.Drawing.Size(26, 19)
        Me.Dat_Deb_Link.TabIndex = 7
        Me.Dat_Deb_Link.TabStop = True
        Me.Dat_Deb_Link.Tag = "SC"
        Me.Dat_Deb_Link.Text = "Du"
        '
        'Dat_Deb_txt
        '
        Me.Dat_Deb_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Deb_txt.ContextMenuStrip = Nothing
        Me.Dat_Deb_txt.Location = New System.Drawing.Point(535, 110)
        Me.Dat_Deb_txt.Name = "Dat_Deb_txt"
        Me.Dat_Deb_txt.ReadOnly = True
        Me.Dat_Deb_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Deb_txt.TabIndex = 8
        Me.Dat_Deb_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Dat_Fin_Link
        '
        Me.Dat_Fin_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Fin_Link.AutoSize = True
        Me.Dat_Fin_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Fin_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Fin_Link.Location = New System.Drawing.Point(640, 114)
        Me.Dat_Fin_Link.Name = "Dat_Fin_Link"
        Me.Dat_Fin_Link.Size = New System.Drawing.Size(24, 19)
        Me.Dat_Fin_Link.TabIndex = 9
        Me.Dat_Fin_Link.TabStop = True
        Me.Dat_Fin_Link.Tag = "SC"
        Me.Dat_Fin_Link.Text = "Au"
        '
        'Dat_Fin_txt
        '
        Me.Dat_Fin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Fin_txt.ContextMenuStrip = Nothing
        Me.Dat_Fin_txt.Location = New System.Drawing.Point(670, 110)
        Me.Dat_Fin_txt.Name = "Dat_Fin_txt"
        Me.Dat_Fin_txt.ReadOnly = True
        Me.Dat_Fin_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Fin_txt.TabIndex = 10
        Me.Dat_Fin_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.Cod_Medecin_Link.TabIndex = 11
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
        Me.Cod_Medecin_txt.TabIndex = 12
        '
        'Nom_Medecin_txt
        '
        Me.Nom_Medecin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Medecin_txt.ContextMenuStrip = Nothing
        Me.Nom_Medecin_txt.Location = New System.Drawing.Point(330, 144)
        Me.Nom_Medecin_txt.Name = "Nom_Medecin_txt"
        Me.Nom_Medecin_txt.ReadOnly = True
        Me.Nom_Medecin_txt.Size = New System.Drawing.Size(300, 26)
        Me.Nom_Medecin_txt.TabIndex = 13
        '
        'Lieu_lbl
        '
        Me.Lieu_lbl.AutoSize = True
        Me.Lieu_lbl.Location = New System.Drawing.Point(660, 148)
        Me.Lieu_lbl.Name = "Lieu_lbl"
        Me.Lieu_lbl.Size = New System.Drawing.Size(36, 19)
        Me.Lieu_lbl.TabIndex = 14
        Me.Lieu_lbl.Text = "Lieu"
        '
        'Lieu_txt
        '
        Me.Lieu_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lieu_txt.ContextMenuStrip = Nothing
        Me.Lieu_txt.Location = New System.Drawing.Point(710, 144)
        Me.Lieu_txt.Name = "Lieu_txt"
        Me.Lieu_txt.Size = New System.Drawing.Size(300, 26)
        Me.Lieu_txt.TabIndex = 15
        '
        'Statut_lbl
        '
        Me.Statut_lbl.AutoSize = True
        Me.Statut_lbl.Location = New System.Drawing.Point(1050, 148)
        Me.Statut_lbl.Name = "Statut_lbl"
        Me.Statut_lbl.Size = New System.Drawing.Size(50, 19)
        Me.Statut_lbl.TabIndex = 16
        Me.Statut_lbl.Text = "Statut"
        '
        'Statut_cbo
        '
        Me.Statut_cbo.DataSource = Nothing
        Me.Statut_cbo.DisplayMember = ""
        Me.Statut_cbo.DroppedDown = False
        Me.Statut_cbo.Location = New System.Drawing.Point(1110, 144)
        Me.Statut_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Statut_cbo.Name = "Statut_cbo"
        Me.Statut_cbo.SelectedIndex = -1
        Me.Statut_cbo.SelectedItem = Nothing
        Me.Statut_cbo.SelectedValue = Nothing
        Me.Statut_cbo.Size = New System.Drawing.Size(200, 26)
        Me.Statut_cbo.TabIndex = 17
        Me.Statut_cbo.ValueMember = ""
        '
        'RH_Sante_Campagne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Campagne"
        Me.Tag = "ECR"
        Me.Text = "Campagnes et convocations"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Convocations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grd_Convocations As ud_Grd
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Cod_Campagne_txt As ud_TextBox
    Friend WithEvents Lib_Campagne_lbl As Label
    Friend WithEvents Lib_Campagne_txt As ud_TextBox
    Friend WithEvents Typ_Visite_lbl As Label
    Friend WithEvents Typ_Visite_cbo As ud_ComboBox
    Friend WithEvents Dat_Deb_Link As LinkLabel
    Friend WithEvents Dat_Deb_txt As ud_TextBox
    Friend WithEvents Dat_Fin_Link As LinkLabel
    Friend WithEvents Dat_Fin_txt As ud_TextBox
    Friend WithEvents Cod_Medecin_Link As LinkLabel
    Friend WithEvents Cod_Medecin_txt As ud_TextBox
    Friend WithEvents Nom_Medecin_txt As ud_TextBox
    Friend WithEvents Lieu_lbl As Label
    Friend WithEvents Lieu_txt As ud_TextBox
    Friend WithEvents Statut_lbl As Label
    Friend WithEvents Statut_cbo As ud_ComboBox
    Friend WithEvents Matricule As DataGridViewTextBoxColumn
    Friend WithEvents Dat_Convocation As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Heure As DataGridViewTextBoxColumn
    Friend WithEvents Statut_Convocation As DataGridViewComboBoxColumn
    Friend WithEvents Dat_Envoi As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Num_Visite As DataGridViewTextBoxColumn
    Friend WithEvents Commentaire As DataGridViewTextBoxColumn
End Class
