<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Vaccination
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
        Me.Grd_Vaccinations = New RHP.ud_Grd()
        Me.Typ_Vaccin = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Dat_Vaccination = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Dat_Rappel = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Commentaire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Vaccinations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grd_Vaccinations)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1428, 714)
        Me.Panel1.TabIndex = 3
        '
        'Grd_Vaccinations
        '
        Me.Grd_Vaccinations.AfficherLesEntetesLignes = True
        Me.Grd_Vaccinations.AlternerLesLignes = False
        Me.Grd_Vaccinations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Vaccinations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Vaccinations.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Vaccinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Vaccinations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Typ_Vaccin, Me.Dat_Vaccination, Me.Dat_Rappel, Me.Commentaire})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Vaccinations.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Vaccinations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Vaccinations.EnableHeadersVisualStyles = False
        Me.Grd_Vaccinations.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Vaccinations.Location = New System.Drawing.Point(0, 100)
        Me.Grd_Vaccinations.Name = "Grd_Vaccinations"
        Me.Grd_Vaccinations.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Vaccinations.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Vaccinations.RowHeadersWidth = 51
        Me.Grd_Vaccinations.Size = New System.Drawing.Size(1428, 614)
        Me.Grd_Vaccinations.TabIndex = 0
        '
        'Typ_Vaccin
        '
        Me.Typ_Vaccin.HeaderText = "Vaccin"
        Me.Typ_Vaccin.MinimumWidth = 6
        Me.Typ_Vaccin.Name = "Typ_Vaccin"
        Me.Typ_Vaccin.Width = 250
        '
        'Dat_Vaccination
        '
        '
        '
        '
        Me.Dat_Vaccination.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat_Vaccination.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Vaccination.HeaderText = "Date vaccination"
        Me.Dat_Vaccination.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Dat_Vaccination.MinimumWidth = 6
        '
        '
        '
        Me.Dat_Vaccination.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Vaccination.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat_Vaccination.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat_Vaccination.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat_Vaccination.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Vaccination.MonthCalendar.DisplayMonth = New Date(2026, 1, 1, 0, 0, 0, 0)
        Me.Dat_Vaccination.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat_Vaccination.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Vaccination.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat_Vaccination.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Vaccination.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat_Vaccination.Name = "Dat_Vaccination"
        Me.Dat_Vaccination.Width = 150
        '
        'Dat_Rappel
        '
        '
        '
        '
        Me.Dat_Rappel.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat_Rappel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Rappel.HeaderText = "Rappel"
        Me.Dat_Rappel.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.Dat_Rappel.MinimumWidth = 6
        '
        '
        '
        Me.Dat_Rappel.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Rappel.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat_Rappel.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat_Rappel.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat_Rappel.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Rappel.MonthCalendar.DisplayMonth = New Date(2026, 1, 1, 0, 0, 0, 0)
        Me.Dat_Rappel.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat_Rappel.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat_Rappel.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat_Rappel.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat_Rappel.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat_Rappel.Name = "Dat_Rappel"
        Me.Dat_Rappel.Width = 150
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
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 100)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agent"
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(140, 45)
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
        Me.Matricule_txt.Location = New System.Drawing.Point(220, 43)
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.Size = New System.Drawing.Size(146, 26)
        Me.Matricule_txt.TabIndex = 1
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(374, 43)
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(420, 26)
        Me.Nom_Agent_Text.TabIndex = 2
        '
        'RH_Sante_Vaccination
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Vaccination"
        Me.Tag = "ECR"
        Me.Text = "Vaccinations"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Vaccinations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grd_Vaccinations As ud_Grd
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Typ_Vaccin As DataGridViewComboBoxColumn
    Friend WithEvents Dat_Vaccination As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Dat_Rappel As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Commentaire As DataGridViewTextBoxColumn
End Class
