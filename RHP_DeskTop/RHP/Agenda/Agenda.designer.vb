<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Agenda
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.TimeLine_lbl = New System.Windows.Forms.Label()
        Me.Mois_lbl = New System.Windows.Forms.Label()
        Me.Semaine_lbl = New System.Windows.Forms.Label()
        Me.Jour_lbl = New System.Windows.Forms.Label()
        Me.Tout_chk = New RHP.ud_CheckBox()
        Me.Nom_Pilote_Text = New RHP.ud_TextBox()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.CalendarView1 = New DevComponents.DotNetBar.Schedule.CalendarView()
        Me.DateNavigator1 = New DevComponents.DotNetBar.Schedule.DateNavigator()
        Me.GroupBox1.SuspendLayout()
        Me.Personnal_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Personnal_pnl)
        Me.GroupBox1.Controls.Add(Me.Tout_chk)
        Me.GroupBox1.Controls.Add(Me.Nom_Pilote_Text)
        Me.GroupBox1.Controls.Add(Me.Matricule_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(796, 86)
        Me.GroupBox1.TabIndex = 208
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "10"
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.ColumnCount = 5
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Controls.Add(Me.TimeLine_lbl, 3, 0)
        Me.Personnal_pnl.Controls.Add(Me.Mois_lbl, 2, 0)
        Me.Personnal_pnl.Controls.Add(Me.Semaine_lbl, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.Jour_lbl, 0, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Personnal_pnl.Location = New System.Drawing.Point(3, 58)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(790, 25)
        Me.Personnal_pnl.TabIndex = 209
        '
        'TimeLine_lbl
        '
        Me.TimeLine_lbl.AutoSize = True
        Me.TimeLine_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TimeLine_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TimeLine_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLine_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TimeLine_lbl.Location = New System.Drawing.Point(183, 0)
        Me.TimeLine_lbl.Name = "TimeLine_lbl"
        Me.TimeLine_lbl.Size = New System.Drawing.Size(54, 25)
        Me.TimeLine_lbl.TabIndex = 3
        Me.TimeLine_lbl.Text = "TimeLine"
        Me.TimeLine_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Mois_lbl
        '
        Me.Mois_lbl.AutoSize = True
        Me.Mois_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Mois_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Mois_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mois_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Mois_lbl.Location = New System.Drawing.Point(123, 0)
        Me.Mois_lbl.Name = "Mois_lbl"
        Me.Mois_lbl.Size = New System.Drawing.Size(54, 25)
        Me.Mois_lbl.TabIndex = 2
        Me.Mois_lbl.Text = "Mois"
        Me.Mois_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Semaine_lbl
        '
        Me.Semaine_lbl.AutoSize = True
        Me.Semaine_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Semaine_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Semaine_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Semaine_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Semaine_lbl.Location = New System.Drawing.Point(63, 0)
        Me.Semaine_lbl.Name = "Semaine_lbl"
        Me.Semaine_lbl.Size = New System.Drawing.Size(54, 25)
        Me.Semaine_lbl.TabIndex = 1
        Me.Semaine_lbl.Text = "Semaine"
        Me.Semaine_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Jour_lbl
        '
        Me.Jour_lbl.AutoSize = True
        Me.Jour_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Jour_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Jour_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Jour_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Jour_lbl.Location = New System.Drawing.Point(3, 0)
        Me.Jour_lbl.Name = "Jour_lbl"
        Me.Jour_lbl.Size = New System.Drawing.Size(54, 25)
        Me.Jour_lbl.TabIndex = 0
        Me.Jour_lbl.Text = "Jour"
        Me.Jour_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tout_chk
        '
        Me.Tout_chk.AutoSize = True
        Me.Tout_chk.Checked = True
        Me.Tout_chk.Location = New System.Drawing.Point(635, 17)
        Me.Tout_chk.MaximumSize = New System.Drawing.Size(0, 20)
        Me.Tout_chk.MinimumSize = New System.Drawing.Size(100, 20)
        Me.Tout_chk.Name = "Tout_chk"
        Me.Tout_chk.Size = New System.Drawing.Size(132, 20)
        Me.Tout_chk.TabIndex = 208
        Me.Tout_chk.Tag = "SC"
        Me.Tout_chk.Text = "Tous les participants"
        '
        'Nom_Pilote_Text
        '
        Me.Nom_Pilote_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Pilote_Text.Enabled = False
        Me.Nom_Pilote_Text.Location = New System.Drawing.Point(223, 19)
        Me.Nom_Pilote_Text.MaxLength = 10
        Me.Nom_Pilote_Text.Multiline = False
        Me.Nom_Pilote_Text.Name = "Nom_Pilote_Text"
        Me.Nom_Pilote_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Pilote_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Pilote_Text.ReadOnly = True
        Me.Nom_Pilote_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Pilote_Text.SelectionStart = 0
        Me.Nom_Pilote_Text.Size = New System.Drawing.Size(404, 21)
        Me.Nom_Pilote_Text.TabIndex = 207
        Me.Nom_Pilote_Text.Tag = "NC"
        Me.Nom_Pilote_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Pilote_Text.UseSystemPasswordChar = False
        '
        'Matricule_txt
        '
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.Enabled = False
        Me.Matricule_txt.Location = New System.Drawing.Point(107, 19)
        Me.Matricule_txt.MaxLength = 10
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(110, 21)
        Me.Matricule_txt.TabIndex = 206
        Me.Matricule_txt.Tag = ""
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4.Location = New System.Drawing.Point(43, 21)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(59, 16)
        Me.LinkLabel4.TabIndex = 205
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SN"
        Me.LinkLabel4.Text = "Matricule"
        '
        'CalendarView1
        '
        Me.CalendarView1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CalendarView1.BackgroundStyle.Class = ""
        Me.CalendarView1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CalendarView1.ContainerControlProcessDialogKey = True
        Me.CalendarView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CalendarView1.Is24HourFormat = True
        Me.CalendarView1.Location = New System.Drawing.Point(0, 116)
        Me.CalendarView1.Name = "CalendarView1"
        Me.CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Month
        Me.CalendarView1.Size = New System.Drawing.Size(796, 303)
        Me.CalendarView1.TabIndex = 209
        Me.CalendarView1.Text = "CalendarView1"
        Me.CalendarView1.TimeIndicator.BorderColor = System.Drawing.Color.Empty
        Me.CalendarView1.TimeIndicator.Tag = Nothing
        Me.CalendarView1.TimeSlotDuration = 30
        Me.CalendarView1.YearViewLinkView = DevComponents.DotNetBar.Schedule.eCalendarView.Month
        '
        'DateNavigator1
        '
        Me.DateNavigator1.CalendarView = Me.CalendarView1
        Me.DateNavigator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DateNavigator1.Location = New System.Drawing.Point(0, 86)
        Me.DateNavigator1.Name = "DateNavigator1"
        Me.DateNavigator1.Size = New System.Drawing.Size(796, 30)
        Me.DateNavigator1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.DateNavigator1.StyleMouseDown.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.TopRight
        Me.DateNavigator1.TabIndex = 210
        Me.DateNavigator1.Text = "DateNavigator1"
        '
        'Agenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(796, 419)
        Me.Controls.Add(Me.CalendarView1)
        Me.Controls.Add(Me.DateNavigator1)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "Agenda"
        Me.ShowIcon = False
        Me.Tag = "ECR"
        Me.Text = "Agenda"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Personnal_pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Nom_Pilote_Text As ud_TextBox
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CalendarView1 As DevComponents.DotNetBar.Schedule.CalendarView
    Friend WithEvents DateNavigator1 As DevComponents.DotNetBar.Schedule.DateNavigator
    Friend WithEvents Tout_chk As ud_CheckBox
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Jour_lbl As Label
    Friend WithEvents TimeLine_lbl As Label
    Friend WithEvents Mois_lbl As Label
    Friend WithEvents Semaine_lbl As Label
End Class
