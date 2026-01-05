<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Declaration_AT
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
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grd_Certificats = New RHP.ud_Grd()
        Me.Typ_Certificat = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Dat_Certificat = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Dat_Debut_Arret = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Dat_Fin_Arret = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Nbr_Jours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valide = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Heure_Accident = New System.Windows.Forms.DateTimePicker()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Accident_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Num_Declaration_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Heure_Accident_lbl = New System.Windows.Forms.Label()
        Me.Lieu_Accident_lbl = New System.Windows.Forms.Label()
        Me.Lieu_Accident_txt = New RHP.ud_TextBox()
        Me.Circonstances_lbl = New System.Windows.Forms.Label()
        Me.Circonstances_txt = New RHP.ud_TextBox()
        Me.Nature_Lesion_lbl = New System.Windows.Forms.Label()
        Me.Nature_Lesion_cbo = New RHP.ud_ComboBox()
        Me.Siege_Lesion_lbl = New System.Windows.Forms.Label()
        Me.Siege_Lesion_cbo = New RHP.ud_ComboBox()
        Me.Temoins_lbl = New System.Windows.Forms.Label()
        Me.Temoins_txt = New RHP.ud_TextBox()
        Me.Tiers_lbl = New System.Windows.Forms.Label()
        Me.Tiers_Responsable_txt = New RHP.ud_TextBox()
        Me.Assurance_lbl = New System.Windows.Forms.Label()
        Me.Num_Assurance_txt = New RHP.ud_TextBox()
        Me.Commentaire_lbl = New System.Windows.Forms.Label()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Certificats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grd_Certificats)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1428, 714)
        Me.Panel1.TabIndex = 3
        '
        'Grd_Certificats
        '
        Me.Grd_Certificats.AfficherLesEntetesLignes = True
        Me.Grd_Certificats.AlternerLesLignes = False
        Me.Grd_Certificats.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Certificats.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Certificats.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Certificats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Certificats.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Typ_Certificat, Me.Dat_Certificat, Me.Dat_Debut_Arret, Me.Dat_Fin_Arret, Me.Nbr_Jours, Me.Valide, Me.Comment})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Certificats.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Certificats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Certificats.EnableHeadersVisualStyles = False
        Me.Grd_Certificats.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Certificats.Location = New System.Drawing.Point(0, 395)
        Me.Grd_Certificats.Name = "Grd_Certificats"
        Me.Grd_Certificats.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Certificats.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Certificats.RowHeadersWidth = 51
        Me.Grd_Certificats.Size = New System.Drawing.Size(1428, 319)
        Me.Grd_Certificats.TabIndex = 0
        '
        'Typ_Certificat
        '
        Me.Typ_Certificat.HeaderText = "Type Certificat"
        Me.Typ_Certificat.MinimumWidth = 6
        Me.Typ_Certificat.Name = "Typ_Certificat"
        Me.Typ_Certificat.Width = 125
        '
        'Dat_Certificat
        '
        '
        '
        '
        Me.Dat_Certificat.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Dat_Certificat.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat_Certificat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Certificat.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.Dat_Certificat.HeaderText = "Date Certificat"
        Me.Dat_Certificat.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Dat_Certificat.MinimumWidth = 6
        '
        '
        '
        Me.Dat_Certificat.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Certificat.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat_Certificat.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat_Certificat.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat_Certificat.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Certificat.MonthCalendar.DisplayMonth = New Date(2026, 1, 1, 0, 0, 0, 0)
        Me.Dat_Certificat.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat_Certificat.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Certificat.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat_Certificat.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Certificat.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat_Certificat.Name = "Dat_Certificat"
        Me.Dat_Certificat.Width = 125
        '
        'Dat_Debut_Arret
        '
        '
        '
        '
        Me.Dat_Debut_Arret.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Dat_Debut_Arret.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat_Debut_Arret.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Debut_Arret.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.Dat_Debut_Arret.HeaderText = "Début Arrêt"
        Me.Dat_Debut_Arret.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Dat_Debut_Arret.MinimumWidth = 6
        '
        '
        '
        Me.Dat_Debut_Arret.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Debut_Arret.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat_Debut_Arret.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat_Debut_Arret.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat_Debut_Arret.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Debut_Arret.MonthCalendar.DisplayMonth = New Date(2026, 1, 1, 0, 0, 0, 0)
        Me.Dat_Debut_Arret.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat_Debut_Arret.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Debut_Arret.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat_Debut_Arret.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Debut_Arret.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat_Debut_Arret.Name = "Dat_Debut_Arret"
        Me.Dat_Debut_Arret.Width = 125
        '
        'Dat_Fin_Arret
        '
        '
        '
        '
        Me.Dat_Fin_Arret.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Dat_Fin_Arret.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat_Fin_Arret.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Fin_Arret.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.Dat_Fin_Arret.HeaderText = "Fin Arrêt"
        Me.Dat_Fin_Arret.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Dat_Fin_Arret.MinimumWidth = 6
        '
        '
        '
        Me.Dat_Fin_Arret.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Fin_Arret.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat_Fin_Arret.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat_Fin_Arret.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat_Fin_Arret.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Fin_Arret.MonthCalendar.DisplayMonth = New Date(2026, 1, 1, 0, 0, 0, 0)
        Me.Dat_Fin_Arret.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat_Fin_Arret.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Fin_Arret.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat_Fin_Arret.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Fin_Arret.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat_Fin_Arret.Name = "Dat_Fin_Arret"
        Me.Dat_Fin_Arret.Width = 125
        '
        'Nbr_Jours
        '
        Me.Nbr_Jours.HeaderText = "Nbr Jours"
        Me.Nbr_Jours.MinimumWidth = 6
        Me.Nbr_Jours.Name = "Nbr_Jours"
        Me.Nbr_Jours.Width = 125
        '
        'Valide
        '
        Me.Valide.HeaderText = "Validé"
        Me.Valide.MinimumWidth = 6
        Me.Valide.Name = "Valide"
        Me.Valide.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Valide.Width = 125
        '
        'Comment
        '
        Me.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Comment.HeaderText = "Commentaire"
        Me.Comment.MinimumWidth = 6
        Me.Comment.Name = "Comment"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Heure_Accident)
        Me.GroupBox2.Controls.Add(Me.LinkLabel4)
        Me.GroupBox2.Controls.Add(Me.Dat_Accident_txt)
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Num_Declaration_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Heure_Accident_lbl)
        Me.GroupBox2.Controls.Add(Me.Lieu_Accident_lbl)
        Me.GroupBox2.Controls.Add(Me.Lieu_Accident_txt)
        Me.GroupBox2.Controls.Add(Me.Circonstances_lbl)
        Me.GroupBox2.Controls.Add(Me.Circonstances_txt)
        Me.GroupBox2.Controls.Add(Me.Nature_Lesion_lbl)
        Me.GroupBox2.Controls.Add(Me.Nature_Lesion_cbo)
        Me.GroupBox2.Controls.Add(Me.Siege_Lesion_lbl)
        Me.GroupBox2.Controls.Add(Me.Siege_Lesion_cbo)
        Me.GroupBox2.Controls.Add(Me.Temoins_lbl)
        Me.GroupBox2.Controls.Add(Me.Temoins_txt)
        Me.GroupBox2.Controls.Add(Me.Tiers_lbl)
        Me.GroupBox2.Controls.Add(Me.Tiers_Responsable_txt)
        Me.GroupBox2.Controls.Add(Me.Assurance_lbl)
        Me.GroupBox2.Controls.Add(Me.Num_Assurance_txt)
        Me.GroupBox2.Controls.Add(Me.Commentaire_lbl)
        Me.GroupBox2.Controls.Add(Me.Commentaire_txt)
        Me.GroupBox2.Controls.Add(Me.pb_Valide)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 395)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fiche signalétique"
        '
        'Heure_Accident
        '
        Me.Heure_Accident.CustomFormat = "HH:MM"
        Me.Heure_Accident.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Heure_Accident.Location = New System.Drawing.Point(389, 116)
        Me.Heure_Accident.Name = "Heure_Accident"
        Me.Heure_Accident.ShowUpDown = True
        Me.Heure_Accident.Size = New System.Drawing.Size(73, 24)
        Me.Heure_Accident.TabIndex = 275
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(106, 114)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(110, 19)
        Me.LinkLabel4.TabIndex = 274
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Date Accident"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dat_Accident_txt
        '
        Me.Dat_Accident_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Accident_txt.ContextMenuStrip = Nothing
        Me.Dat_Accident_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Accident_txt.Location = New System.Drawing.Point(220, 110)
        Me.Dat_Accident_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dat_Accident_txt.MaxLength = 32767
        Me.Dat_Accident_txt.Multiline = False
        Me.Dat_Accident_txt.Name = "Dat_Accident_txt"
        Me.Dat_Accident_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Accident_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Accident_txt.ReadOnly = True
        Me.Dat_Accident_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Accident_txt.SelectionStart = 0
        Me.Dat_Accident_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Accident_txt.TabIndex = 273
        Me.Dat_Accident_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Accident_txt.UseSystemPasswordChar = False
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
        'Num_Declaration_txt
        '
        Me.Num_Declaration_txt.AccessibleDescription = "A"
        Me.Num_Declaration_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Declaration_txt.ContextMenuStrip = Nothing
        Me.Num_Declaration_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_Declaration_txt.Location = New System.Drawing.Point(220, 43)
        Me.Num_Declaration_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Num_Declaration_txt.MaxLength = 32767
        Me.Num_Declaration_txt.Multiline = False
        Me.Num_Declaration_txt.Name = "Num_Declaration_txt"
        Me.Num_Declaration_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Declaration_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Declaration_txt.ReadOnly = True
        Me.Num_Declaration_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Declaration_txt.SelectionStart = 0
        Me.Num_Declaration_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Declaration_txt.TabIndex = 250
        Me.Num_Declaration_txt.TabStop = False
        Me.Num_Declaration_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Declaration_txt.UseSystemPasswordChar = False
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
        Me.LinkLabel3.Size = New System.Drawing.Size(110, 19)
        Me.LinkLabel3.TabIndex = 251
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SN"
        Me.LinkLabel3.Text = "N° Déclaration"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Heure_Accident_lbl
        '
        Me.Heure_Accident_lbl.AutoSize = True
        Me.Heure_Accident_lbl.Location = New System.Drawing.Point(333, 116)
        Me.Heure_Accident_lbl.Name = "Heure_Accident_lbl"
        Me.Heure_Accident_lbl.Size = New System.Drawing.Size(50, 19)
        Me.Heure_Accident_lbl.TabIndex = 7
        Me.Heure_Accident_lbl.Text = "Heure"
        '
        'Lieu_Accident_lbl
        '
        Me.Lieu_Accident_lbl.AutoSize = True
        Me.Lieu_Accident_lbl.Location = New System.Drawing.Point(480, 117)
        Me.Lieu_Accident_lbl.Name = "Lieu_Accident_lbl"
        Me.Lieu_Accident_lbl.Size = New System.Drawing.Size(36, 19)
        Me.Lieu_Accident_lbl.TabIndex = 9
        Me.Lieu_Accident_lbl.Text = "Lieu"
        '
        'Lieu_Accident_txt
        '
        Me.Lieu_Accident_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lieu_Accident_txt.ContextMenuStrip = Nothing
        Me.Lieu_Accident_txt.Location = New System.Drawing.Point(521, 114)
        Me.Lieu_Accident_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Lieu_Accident_txt.MaxLength = 32767
        Me.Lieu_Accident_txt.Multiline = False
        Me.Lieu_Accident_txt.Name = "Lieu_Accident_txt"
        Me.Lieu_Accident_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lieu_Accident_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lieu_Accident_txt.ReadOnly = False
        Me.Lieu_Accident_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lieu_Accident_txt.SelectionStart = 0
        Me.Lieu_Accident_txt.Size = New System.Drawing.Size(389, 26)
        Me.Lieu_Accident_txt.TabIndex = 10
        Me.Lieu_Accident_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lieu_Accident_txt.UseSystemPasswordChar = False
        '
        'Circonstances_lbl
        '
        Me.Circonstances_lbl.AutoSize = True
        Me.Circonstances_lbl.Location = New System.Drawing.Point(111, 285)
        Me.Circonstances_lbl.Name = "Circonstances_lbl"
        Me.Circonstances_lbl.Size = New System.Drawing.Size(106, 19)
        Me.Circonstances_lbl.TabIndex = 11
        Me.Circonstances_lbl.Text = "Circonstances"
        '
        'Circonstances_txt
        '
        Me.Circonstances_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Circonstances_txt.ContextMenuStrip = Nothing
        Me.Circonstances_txt.Location = New System.Drawing.Point(220, 281)
        Me.Circonstances_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Circonstances_txt.MaxLength = 32767
        Me.Circonstances_txt.Multiline = True
        Me.Circonstances_txt.Name = "Circonstances_txt"
        Me.Circonstances_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Circonstances_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Circonstances_txt.ReadOnly = False
        Me.Circonstances_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Circonstances_txt.SelectionStart = 0
        Me.Circonstances_txt.Size = New System.Drawing.Size(690, 60)
        Me.Circonstances_txt.TabIndex = 12
        Me.Circonstances_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Circonstances_txt.UseSystemPasswordChar = False
        '
        'Nature_Lesion_lbl
        '
        Me.Nature_Lesion_lbl.AutoSize = True
        Me.Nature_Lesion_lbl.Location = New System.Drawing.Point(115, 150)
        Me.Nature_Lesion_lbl.Name = "Nature_Lesion_lbl"
        Me.Nature_Lesion_lbl.Size = New System.Drawing.Size(101, 19)
        Me.Nature_Lesion_lbl.TabIndex = 13
        Me.Nature_Lesion_lbl.Text = "Nature Lésion"
        '
        'Nature_Lesion_cbo
        '
        Me.Nature_Lesion_cbo.DataSource = Nothing
        Me.Nature_Lesion_cbo.DisplayMember = ""
        Me.Nature_Lesion_cbo.DroppedDown = False
        Me.Nature_Lesion_cbo.Location = New System.Drawing.Point(220, 147)
        Me.Nature_Lesion_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Nature_Lesion_cbo.Name = "Nature_Lesion_cbo"
        Me.Nature_Lesion_cbo.SelectedIndex = -1
        Me.Nature_Lesion_cbo.SelectedItem = Nothing
        Me.Nature_Lesion_cbo.SelectedValue = Nothing
        Me.Nature_Lesion_cbo.Size = New System.Drawing.Size(690, 26)
        Me.Nature_Lesion_cbo.TabIndex = 14
        Me.Nature_Lesion_cbo.ValueMember = ""
        '
        'Siege_Lesion_lbl
        '
        Me.Siege_Lesion_lbl.AutoSize = True
        Me.Siege_Lesion_lbl.Location = New System.Drawing.Point(125, 179)
        Me.Siege_Lesion_lbl.Name = "Siege_Lesion_lbl"
        Me.Siege_Lesion_lbl.Size = New System.Drawing.Size(91, 19)
        Me.Siege_Lesion_lbl.TabIndex = 15
        Me.Siege_Lesion_lbl.Text = "Siège Lésion"
        '
        'Siege_Lesion_cbo
        '
        Me.Siege_Lesion_cbo.DataSource = Nothing
        Me.Siege_Lesion_cbo.DisplayMember = ""
        Me.Siege_Lesion_cbo.DroppedDown = False
        Me.Siege_Lesion_cbo.Location = New System.Drawing.Point(220, 179)
        Me.Siege_Lesion_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Siege_Lesion_cbo.Name = "Siege_Lesion_cbo"
        Me.Siege_Lesion_cbo.SelectedIndex = -1
        Me.Siege_Lesion_cbo.SelectedItem = Nothing
        Me.Siege_Lesion_cbo.SelectedValue = Nothing
        Me.Siege_Lesion_cbo.Size = New System.Drawing.Size(353, 26)
        Me.Siege_Lesion_cbo.TabIndex = 16
        Me.Siege_Lesion_cbo.ValueMember = ""
        '
        'Temoins_lbl
        '
        Me.Temoins_lbl.AutoSize = True
        Me.Temoins_lbl.Location = New System.Drawing.Point(154, 216)
        Me.Temoins_lbl.Name = "Temoins_lbl"
        Me.Temoins_lbl.Size = New System.Drawing.Size(62, 19)
        Me.Temoins_lbl.TabIndex = 17
        Me.Temoins_lbl.Text = "Témoins"
        '
        'Temoins_txt
        '
        Me.Temoins_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Temoins_txt.ContextMenuStrip = Nothing
        Me.Temoins_txt.Location = New System.Drawing.Point(220, 213)
        Me.Temoins_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Temoins_txt.MaxLength = 32767
        Me.Temoins_txt.Multiline = False
        Me.Temoins_txt.Name = "Temoins_txt"
        Me.Temoins_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Temoins_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Temoins_txt.ReadOnly = False
        Me.Temoins_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Temoins_txt.SelectionStart = 0
        Me.Temoins_txt.Size = New System.Drawing.Size(690, 26)
        Me.Temoins_txt.TabIndex = 18
        Me.Temoins_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Temoins_txt.UseSystemPasswordChar = False
        '
        'Tiers_lbl
        '
        Me.Tiers_lbl.AutoSize = True
        Me.Tiers_lbl.Location = New System.Drawing.Point(140, 250)
        Me.Tiers_lbl.Name = "Tiers_lbl"
        Me.Tiers_lbl.Size = New System.Drawing.Size(76, 19)
        Me.Tiers_lbl.TabIndex = 19
        Me.Tiers_lbl.Text = "Tiers Resp."
        '
        'Tiers_Responsable_txt
        '
        Me.Tiers_Responsable_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Tiers_Responsable_txt.ContextMenuStrip = Nothing
        Me.Tiers_Responsable_txt.Location = New System.Drawing.Point(220, 247)
        Me.Tiers_Responsable_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tiers_Responsable_txt.MaxLength = 32767
        Me.Tiers_Responsable_txt.Multiline = False
        Me.Tiers_Responsable_txt.Name = "Tiers_Responsable_txt"
        Me.Tiers_Responsable_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Tiers_Responsable_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Tiers_Responsable_txt.ReadOnly = False
        Me.Tiers_Responsable_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Tiers_Responsable_txt.SelectionStart = 0
        Me.Tiers_Responsable_txt.Size = New System.Drawing.Size(690, 26)
        Me.Tiers_Responsable_txt.TabIndex = 20
        Me.Tiers_Responsable_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Tiers_Responsable_txt.UseSystemPasswordChar = False
        '
        'Assurance_lbl
        '
        Me.Assurance_lbl.AutoSize = True
        Me.Assurance_lbl.Location = New System.Drawing.Point(586, 182)
        Me.Assurance_lbl.Name = "Assurance_lbl"
        Me.Assurance_lbl.Size = New System.Drawing.Size(98, 19)
        Me.Assurance_lbl.TabIndex = 21
        Me.Assurance_lbl.Text = "N° Assurance"
        '
        'Num_Assurance_txt
        '
        Me.Num_Assurance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Assurance_txt.ContextMenuStrip = Nothing
        Me.Num_Assurance_txt.Location = New System.Drawing.Point(688, 179)
        Me.Num_Assurance_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Num_Assurance_txt.MaxLength = 32767
        Me.Num_Assurance_txt.Multiline = False
        Me.Num_Assurance_txt.Name = "Num_Assurance_txt"
        Me.Num_Assurance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Assurance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Assurance_txt.ReadOnly = True
        Me.Num_Assurance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Assurance_txt.SelectionStart = 0
        Me.Num_Assurance_txt.Size = New System.Drawing.Size(220, 26)
        Me.Num_Assurance_txt.TabIndex = 22
        Me.Num_Assurance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Assurance_txt.UseSystemPasswordChar = False
        '
        'Commentaire_lbl
        '
        Me.Commentaire_lbl.AutoSize = True
        Me.Commentaire_lbl.Location = New System.Drawing.Point(112, 351)
        Me.Commentaire_lbl.Name = "Commentaire_lbl"
        Me.Commentaire_lbl.Size = New System.Drawing.Size(104, 19)
        Me.Commentaire_lbl.TabIndex = 25
        Me.Commentaire_lbl.Text = "Commentaire"
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.ContextMenuStrip = Nothing
        Me.Commentaire_txt.Location = New System.Drawing.Point(220, 348)
        Me.Commentaire_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Commentaire_txt.MaxLength = 32767
        Me.Commentaire_txt.Multiline = False
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(690, 26)
        Me.Commentaire_txt.TabIndex = 26
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'pb_Valide
        '
        Me.pb_Valide.Location = New System.Drawing.Point(917, 23)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(122, 123)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_Valide.TabIndex = 27
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'RH_Declaration_AT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Declaration_AT"
        Me.Tag = "ECR"
        Me.Text = "Déclaration Accident de Travail"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Certificats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grd_Certificats As ud_Grd
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Heure_Accident_lbl As Label
    Friend WithEvents Lieu_Accident_lbl As Label
    Friend WithEvents Lieu_Accident_txt As ud_TextBox
    Friend WithEvents Circonstances_lbl As Label
    Friend WithEvents Circonstances_txt As ud_TextBox
    Friend WithEvents Nature_Lesion_lbl As Label
    Friend WithEvents Nature_Lesion_cbo As ud_ComboBox
    Friend WithEvents Siege_Lesion_lbl As Label
    Friend WithEvents Siege_Lesion_cbo As ud_ComboBox
    Friend WithEvents Temoins_lbl As Label
    Friend WithEvents Temoins_txt As ud_TextBox
    Friend WithEvents Tiers_lbl As Label
    Friend WithEvents Tiers_Responsable_txt As ud_TextBox
    Friend WithEvents Assurance_lbl As Label
    Friend WithEvents Num_Assurance_txt As ud_TextBox
    Friend WithEvents Commentaire_lbl As Label
    Friend WithEvents Commentaire_txt As ud_TextBox
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Num_Declaration_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Dat_Accident_txt As ud_TextBox
    Friend WithEvents Heure_Accident As DateTimePicker
    Friend WithEvents Typ_Certificat As DataGridViewComboBoxColumn
    Friend WithEvents Dat_Certificat As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Dat_Debut_Arret As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Dat_Fin_Arret As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Nbr_Jours As DataGridViewTextBoxColumn
    Friend WithEvents Valide As DataGridViewButtonColumn
    Friend WithEvents Comment As DataGridViewTextBoxColumn
End Class
