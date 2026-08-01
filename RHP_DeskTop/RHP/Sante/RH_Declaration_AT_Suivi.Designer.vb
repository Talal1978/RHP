<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Declaration_AT_Suivi
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Num_Declaration_txt = New RHP.ud_TextBox()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Dat_Accident_lbl = New System.Windows.Forms.Label()
        Me.Dat_Accident_txt = New RHP.ud_TextBox()
        Me.Typ_Accident_lbl = New System.Windows.Forms.Label()
        Me.Typ_Accident_cbo = New RHP.ud_ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox_Echeances = New System.Windows.Forms.GroupBox()
        Me.Grd_Echeances = New RHP.ud_Grd()
        Me.Cod_Etape = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dat_Debut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Delai_Jours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dat_Echeance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Statut_Etape = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Dat_Realisation = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Commentaire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox_Transmissions = New System.Windows.Forms.GroupBox()
        Me.Grd_Transmissions = New RHP.ud_Grd()
        Me.Cod_Destinataire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dat_Transmission = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Mode_Transmission = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Reference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Commentaire_T = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox_Echeances.SuspendLayout()
        CType(Me.Grd_Echeances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_Transmissions.SuspendLayout()
        CType(Me.Grd_Transmissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Num_Declaration_txt)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Dat_Accident_lbl)
        Me.GroupBox2.Controls.Add(Me.Dat_Accident_txt)
        Me.GroupBox2.Controls.Add(Me.Typ_Accident_lbl)
        Me.GroupBox2.Controls.Add(Me.Typ_Accident_cbo)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 120)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Déclaration d'accident"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(105, 45)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(110, 19)
        Me.LinkLabel3.TabIndex = 251
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SN"
        Me.LinkLabel3.Text = "N° Déclaration"
        '
        'Num_Declaration_txt
        '
        Me.Num_Declaration_txt.AccessibleDescription = "A"
        Me.Num_Declaration_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Declaration_txt.ContextMenuStrip = Nothing
        Me.Num_Declaration_txt.Location = New System.Drawing.Point(220, 43)
        Me.Num_Declaration_txt.Name = "Num_Declaration_txt"
        Me.Num_Declaration_txt.ReadOnly = True
        Me.Num_Declaration_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Declaration_txt.TabIndex = 250
        Me.Num_Declaration_txt.TabStop = False
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
        'Dat_Accident_lbl
        '
        Me.Dat_Accident_lbl.AutoSize = True
        Me.Dat_Accident_lbl.Location = New System.Drawing.Point(400, 45)
        Me.Dat_Accident_lbl.Name = "Dat_Accident_lbl"
        Me.Dat_Accident_lbl.Size = New System.Drawing.Size(91, 19)
        Me.Dat_Accident_lbl.TabIndex = 3
        Me.Dat_Accident_lbl.Text = "Date accident"
        '
        'Dat_Accident_txt
        '
        Me.Dat_Accident_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Accident_txt.ContextMenuStrip = Nothing
        Me.Dat_Accident_txt.Location = New System.Drawing.Point(500, 43)
        Me.Dat_Accident_txt.Name = "Dat_Accident_txt"
        Me.Dat_Accident_txt.ReadOnly = True
        Me.Dat_Accident_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Accident_txt.TabIndex = 4
        Me.Dat_Accident_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Typ_Accident_lbl
        '
        Me.Typ_Accident_lbl.AutoSize = True
        Me.Typ_Accident_lbl.Location = New System.Drawing.Point(620, 45)
        Me.Typ_Accident_lbl.Name = "Typ_Accident_lbl"
        Me.Typ_Accident_lbl.Size = New System.Drawing.Size(103, 19)
        Me.Typ_Accident_lbl.TabIndex = 5
        Me.Typ_Accident_lbl.Text = "Type d'accident"
        '
        'Typ_Accident_cbo
        '
        Me.Typ_Accident_cbo.DataSource = Nothing
        Me.Typ_Accident_cbo.DisplayMember = ""
        Me.Typ_Accident_cbo.DroppedDown = False
        Me.Typ_Accident_cbo.Location = New System.Drawing.Point(730, 41)
        Me.Typ_Accident_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Accident_cbo.Name = "Typ_Accident_cbo"
        Me.Typ_Accident_cbo.SelectedIndex = -1
        Me.Typ_Accident_cbo.SelectedItem = Nothing
        Me.Typ_Accident_cbo.SelectedValue = Nothing
        Me.Typ_Accident_cbo.Size = New System.Drawing.Size(250, 26)
        Me.Typ_Accident_cbo.TabIndex = 6
        Me.Typ_Accident_cbo.ValueMember = ""
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 120)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox_Echeances)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox_Transmissions)
        Me.SplitContainer1.Size = New System.Drawing.Size(1428, 594)
        Me.SplitContainer1.SplitterDistance = 300
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox_Echeances
        '
        Me.GroupBox_Echeances.Controls.Add(Me.Grd_Echeances)
        Me.GroupBox_Echeances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Echeances.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Echeances.Name = "GroupBox_Echeances"
        Me.GroupBox_Echeances.Size = New System.Drawing.Size(1428, 300)
        Me.GroupBox_Echeances.TabIndex = 0
        Me.GroupBox_Echeances.TabStop = False
        Me.GroupBox_Echeances.Text = "Échéancier réglementaire (en rouge : en retard)"
        '
        'Grd_Echeances
        '
        Me.Grd_Echeances.AfficherLesEntetesLignes = True
        Me.Grd_Echeances.AlternerLesLignes = False
        Me.Grd_Echeances.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Echeances.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Echeances.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Echeances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Echeances.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Etape, Me.Dat_Debut, Me.Delai_Jours, Me.Dat_Echeance, Me.Statut_Etape, Me.Dat_Realisation, Me.Commentaire})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Echeances.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Echeances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Echeances.EnableHeadersVisualStyles = False
        Me.Grd_Echeances.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Echeances.Location = New System.Drawing.Point(3, 22)
        Me.Grd_Echeances.Name = "Grd_Echeances"
        Me.Grd_Echeances.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Echeances.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Echeances.RowHeadersWidth = 51
        Me.Grd_Echeances.Size = New System.Drawing.Size(1422, 275)
        Me.Grd_Echeances.TabIndex = 0
        '
        'Cod_Etape
        '
        Me.Cod_Etape.HeaderText = "Étape"
        Me.Cod_Etape.MinimumWidth = 6
        Me.Cod_Etape.Name = "Cod_Etape"
        Me.Cod_Etape.ReadOnly = True
        Me.Cod_Etape.Width = 160
        '
        'Dat_Debut
        '
        Me.Dat_Debut.HeaderText = "Départ"
        Me.Dat_Debut.MinimumWidth = 6
        Me.Dat_Debut.Name = "Dat_Debut"
        Me.Dat_Debut.ReadOnly = True
        Me.Dat_Debut.Width = 110
        '
        'Delai_Jours
        '
        Me.Delai_Jours.HeaderText = "Délai (j)"
        Me.Delai_Jours.MinimumWidth = 6
        Me.Delai_Jours.Name = "Delai_Jours"
        Me.Delai_Jours.ReadOnly = True
        Me.Delai_Jours.Width = 80
        '
        'Dat_Echeance
        '
        Me.Dat_Echeance.HeaderText = "Échéance"
        Me.Dat_Echeance.MinimumWidth = 6
        Me.Dat_Echeance.Name = "Dat_Echeance"
        Me.Dat_Echeance.ReadOnly = True
        Me.Dat_Echeance.Width = 110
        '
        'Statut_Etape
        '
        Me.Statut_Etape.HeaderText = "Statut"
        Me.Statut_Etape.MinimumWidth = 6
        Me.Statut_Etape.Name = "Statut_Etape"
        Me.Statut_Etape.Width = 120
        '
        'Dat_Realisation
        '
        '
        '
        '
        Me.Dat_Realisation.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat_Realisation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Realisation.HeaderText = "Réalisée le"
        Me.Dat_Realisation.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Dat_Realisation.MinimumWidth = 6
        '
        '
        '
        Me.Dat_Realisation.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Realisation.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat_Realisation.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat_Realisation.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat_Realisation.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Realisation.MonthCalendar.DisplayMonth = New Date(2026, 1, 1, 0, 0, 0, 0)
        Me.Dat_Realisation.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat_Realisation.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Realisation.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat_Realisation.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Realisation.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat_Realisation.Name = "Dat_Realisation"
        Me.Dat_Realisation.Width = 130
        '
        'Commentaire
        '
        Me.Commentaire.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Commentaire.HeaderText = "Commentaire"
        Me.Commentaire.MinimumWidth = 6
        Me.Commentaire.Name = "Commentaire"
        '
        'GroupBox_Transmissions
        '
        Me.GroupBox_Transmissions.Controls.Add(Me.Grd_Transmissions)
        Me.GroupBox_Transmissions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Transmissions.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Transmissions.Name = "GroupBox_Transmissions"
        Me.GroupBox_Transmissions.Size = New System.Drawing.Size(1428, 290)
        Me.GroupBox_Transmissions.TabIndex = 0
        Me.GroupBox_Transmissions.TabStop = False
        Me.GroupBox_Transmissions.Text = "Transmissions aux destinataires (assureur, autorité, CNSS...)"
        '
        'Grd_Transmissions
        '
        Me.Grd_Transmissions.AfficherLesEntetesLignes = True
        Me.Grd_Transmissions.AlternerLesLignes = False
        Me.Grd_Transmissions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Transmissions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd_Transmissions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Transmissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Transmissions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Destinataire, Me.Dat_Transmission, Me.Mode_Transmission, Me.Reference, Me.Commentaire_T})
        Me.Grd_Transmissions.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Transmissions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Transmissions.EnableHeadersVisualStyles = False
        Me.Grd_Transmissions.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Transmissions.Location = New System.Drawing.Point(3, 22)
        Me.Grd_Transmissions.Name = "Grd_Transmissions"
        Me.Grd_Transmissions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd_Transmissions.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Transmissions.RowHeadersWidth = 51
        Me.Grd_Transmissions.Size = New System.Drawing.Size(1422, 265)
        Me.Grd_Transmissions.TabIndex = 0
        '
        'Cod_Destinataire
        '
        Me.Cod_Destinataire.HeaderText = "Destinataire"
        Me.Cod_Destinataire.MinimumWidth = 6
        Me.Cod_Destinataire.Name = "Cod_Destinataire"
        Me.Cod_Destinataire.Width = 200
        '
        'Dat_Transmission
        '
        '
        '
        '
        Me.Dat_Transmission.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat_Transmission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Transmission.HeaderText = "Transmise le"
        Me.Dat_Transmission.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Dat_Transmission.MinimumWidth = 6
        '
        '
        '
        Me.Dat_Transmission.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Transmission.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat_Transmission.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat_Transmission.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat_Transmission.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Transmission.MonthCalendar.DisplayMonth = New Date(2026, 1, 1, 0, 0, 0, 0)
        Me.Dat_Transmission.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat_Transmission.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Transmission.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat_Transmission.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Transmission.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat_Transmission.Name = "Dat_Transmission"
        Me.Dat_Transmission.Width = 140
        '
        'Mode_Transmission
        '
        Me.Mode_Transmission.HeaderText = "Mode"
        Me.Mode_Transmission.MinimumWidth = 6
        Me.Mode_Transmission.Name = "Mode_Transmission"
        Me.Mode_Transmission.Width = 140
        '
        'Reference
        '
        Me.Reference.HeaderText = "Référence"
        Me.Reference.MinimumWidth = 6
        Me.Reference.Name = "Reference"
        Me.Reference.Width = 160
        '
        'Commentaire_T
        '
        Me.Commentaire_T.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Commentaire_T.HeaderText = "Commentaire"
        Me.Commentaire_T.MinimumWidth = 6
        Me.Commentaire_T.Name = "Commentaire_T"
        '
        'RH_Declaration_AT_Suivi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Declaration_AT_Suivi"
        Me.Tag = "ECR"
        Me.Text = "Suivi réglementaire des accidents du travail"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox_Echeances.ResumeLayout(False)
        CType(Me.Grd_Echeances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_Transmissions.ResumeLayout(False)
        CType(Me.Grd_Transmissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Num_Declaration_txt As ud_TextBox
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Dat_Accident_lbl As Label
    Friend WithEvents Dat_Accident_txt As ud_TextBox
    Friend WithEvents Typ_Accident_lbl As Label
    Friend WithEvents Typ_Accident_cbo As ud_ComboBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox_Echeances As GroupBox
    Friend WithEvents Grd_Echeances As ud_Grd
    Friend WithEvents GroupBox_Transmissions As GroupBox
    Friend WithEvents Grd_Transmissions As ud_Grd
    Friend WithEvents Cod_Etape As DataGridViewTextBoxColumn
    Friend WithEvents Dat_Debut As DataGridViewTextBoxColumn
    Friend WithEvents Delai_Jours As DataGridViewTextBoxColumn
    Friend WithEvents Dat_Echeance As DataGridViewTextBoxColumn
    Friend WithEvents Statut_Etape As DataGridViewComboBoxColumn
    Friend WithEvents Dat_Realisation As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Commentaire As DataGridViewTextBoxColumn
    Friend WithEvents Cod_Destinataire As DataGridViewTextBoxColumn
    Friend WithEvents Dat_Transmission As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Mode_Transmission As DataGridViewComboBoxColumn
    Friend WithEvents Reference As DataGridViewTextBoxColumn
    Friend WithEvents Commentaire_T As DataGridViewTextBoxColumn
End Class
