<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Pret
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Grd = New RHP.ud_Grd()
        Me.Dat = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Capital = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Mensualite = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Interet = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Amortissement = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.CRD = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Num_Demande_Pret_lbl = New System.Windows.Forms.LinkLabel()
        Me.Lib_Num_Demande_Pret_txt = New RHP.ud_TextBox()
        Me.Num_Demande_Pret_txt = New RHP.ud_TextBox()
        Me.Reglement_txt = New RHP.ud_TextBox()
        Me.Reglement = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Assurance_txt = New RHP.ud_TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.organisme_lbl = New System.Windows.Forms.LinkLabel()
        Me.Lib_Organisme_txt = New RHP.ud_TextBox()
        Me.Organisme_txt = New RHP.ud_TextBox()
        Me.Rd_3 = New RHP.ud_RadioBox()
        Me.Rd_2 = New RHP.ud_RadioBox()
        Me.Rd_1 = New RHP.ud_RadioBox()
        Me.Mensualite_txt = New RHP.ud_TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Premiere_Echeance_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Duree = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Taux_TVA_txt = New RHP.ud_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Taux_txt = New RHP.ud_TextBox()
        Me.Montant_Pret_txt = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LastDatePaie_txt = New RHP.ud_TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Prets_Encours_txt = New RHP.ud_TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Reste_Salaire_txt = New RHP.ud_TextBox()
        Me.Dernier_Salaire_Net_txt = New RHP.ud_TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Num_Pret_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Demande_txt = New RHP.ud_TextBox()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Lib_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
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
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Duree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(23, 49)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(59, 16)
        Me.Matricule_.TabIndex = 207
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        Me.Matricule_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_txt.Location = New System.Drawing.Point(86, 46)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(104, 21)
        Me.Matricule_txt.TabIndex = 206
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.BackColor = System.Drawing.SystemColors.Window
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(193, 46)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = False
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(320, 21)
        Me.Nom_Agent_Text.TabIndex = 208
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 586)
        Me.Panel1.TabIndex = 209
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 291)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1000, 295)
        Me.TabControl1.TabIndex = 254
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grd)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(992, 266)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tab. Amortissement"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Grd
        '
        Me.Grd.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dat, Me.Capital, Me.Mensualite, Me.Interet, Me.Amortissement, Me.CRD})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd.DefaultCellStyle = DataGridViewCellStyle9
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.EnableHeadersVisualStyles = False
        Me.Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd.Location = New System.Drawing.Point(3, 3)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Grd.Size = New System.Drawing.Size(986, 260)
        Me.Grd.TabIndex = 3
        '
        'Dat
        '
        '
        '
        '
        Me.Dat.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Dat.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Dat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Dat.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dat.HeaderText = "Date"
        Me.Dat.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        '
        '
        '
        Me.Dat.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat.MonthCalendar.BackgroundStyle.Class = ""
        Me.Dat.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Dat.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.Dat.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat.MonthCalendar.DisplayMonth = New Date(2019, 12, 1, 0, 0, 0, 0)
        Me.Dat.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dat.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dat.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dat.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.Dat.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dat.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dat.Name = "Dat"
        '
        'Capital
        '
        '
        '
        '
        Me.Capital.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Capital.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Capital.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Capital.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Capital.DefaultCellStyle = DataGridViewCellStyle4
        Me.Capital.HeaderText = "Capital"
        Me.Capital.Increment = 1.0R
        Me.Capital.Name = "Capital"
        '
        'Mensualite
        '
        '
        '
        '
        Me.Mensualite.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Mensualite.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Mensualite.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Mensualite.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Mensualite.DefaultCellStyle = DataGridViewCellStyle5
        Me.Mensualite.HeaderText = "Mensualité"
        Me.Mensualite.Increment = 1.0R
        Me.Mensualite.Name = "Mensualite"
        '
        'Interet
        '
        '
        '
        '
        Me.Interet.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Interet.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Interet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Interet.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Interet.DefaultCellStyle = DataGridViewCellStyle6
        Me.Interet.HeaderText = "Intérêt TTC"
        Me.Interet.Increment = 1.0R
        Me.Interet.Name = "Interet"
        '
        'Amortissement
        '
        '
        '
        '
        Me.Amortissement.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Amortissement.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Amortissement.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Amortissement.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Amortissement.DefaultCellStyle = DataGridViewCellStyle7
        Me.Amortissement.HeaderText = "Amortissement"
        Me.Amortissement.Increment = 1.0R
        Me.Amortissement.Name = "Amortissement"
        '
        'CRD
        '
        '
        '
        '
        Me.CRD.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.CRD.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.CRD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CRD.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CRD.DefaultCellStyle = DataGridViewCellStyle8
        Me.CRD.HeaderText = "Capital restant dû"
        Me.CRD.Increment = 1.0R
        Me.CRD.Name = "CRD"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Commentaire_txt)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(992, 237)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Commentaire"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Commentaire_txt.Location = New System.Drawing.Point(3, 3)
        Me.Commentaire_txt.MaxLength = 32767
        Me.Commentaire_txt.Multiline = True
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(986, 231)
        Me.Commentaire_txt.TabIndex = 0
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Num_Demande_Pret_lbl)
        Me.GroupBox3.Controls.Add(Me.Lib_Num_Demande_Pret_txt)
        Me.GroupBox3.Controls.Add(Me.Num_Demande_Pret_txt)
        Me.GroupBox3.Controls.Add(Me.Reglement_txt)
        Me.GroupBox3.Controls.Add(Me.Reglement)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Assurance_txt)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.organisme_lbl)
        Me.GroupBox3.Controls.Add(Me.Lib_Organisme_txt)
        Me.GroupBox3.Controls.Add(Me.Organisme_txt)
        Me.GroupBox3.Controls.Add(Me.Rd_3)
        Me.GroupBox3.Controls.Add(Me.Rd_2)
        Me.GroupBox3.Controls.Add(Me.Rd_1)
        Me.GroupBox3.Controls.Add(Me.Mensualite_txt)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Premiere_Echeance_txt)
        Me.GroupBox3.Controls.Add(Me.LinkLabel1)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Duree)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Taux_TVA_txt)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Taux_txt)
        Me.GroupBox3.Controls.Add(Me.Montant_Pret_txt)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 178)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1000, 113)
        Me.GroupBox3.TabIndex = 257
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Détail du prêt"
        '
        'Num_Demande_Pret_lbl
        '
        Me.Num_Demande_Pret_lbl.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Num_Demande_Pret_lbl.AutoSize = True
        Me.Num_Demande_Pret_lbl.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Num_Demande_Pret_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_Demande_Pret_lbl.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Num_Demande_Pret_lbl.Location = New System.Drawing.Point(149, 30)
        Me.Num_Demande_Pret_lbl.Name = "Num_Demande_Pret_lbl"
        Me.Num_Demande_Pret_lbl.Size = New System.Drawing.Size(84, 16)
        Me.Num_Demande_Pret_lbl.TabIndex = 272
        Me.Num_Demande_Pret_lbl.TabStop = True
        Me.Num_Demande_Pret_lbl.Tag = ""
        Me.Num_Demande_Pret_lbl.Text = "N° demande :"
        Me.Num_Demande_Pret_lbl.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Num_Demande_Pret_txt
        '
        Me.Lib_Num_Demande_Pret_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Num_Demande_Pret_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Num_Demande_Pret_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Num_Demande_Pret_txt.Location = New System.Drawing.Point(353, 27)
        Me.Lib_Num_Demande_Pret_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Num_Demande_Pret_txt.MaxLength = 50
        Me.Lib_Num_Demande_Pret_txt.Multiline = False
        Me.Lib_Num_Demande_Pret_txt.Name = "Lib_Num_Demande_Pret_txt"
        Me.Lib_Num_Demande_Pret_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Num_Demande_Pret_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Num_Demande_Pret_txt.ReadOnly = True
        Me.Lib_Num_Demande_Pret_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Num_Demande_Pret_txt.SelectionStart = 0
        Me.Lib_Num_Demande_Pret_txt.Size = New System.Drawing.Size(243, 21)
        Me.Lib_Num_Demande_Pret_txt.TabIndex = 273
        Me.Lib_Num_Demande_Pret_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Num_Demande_Pret_txt.UseSystemPasswordChar = False
        '
        'Num_Demande_Pret_txt
        '
        Me.Num_Demande_Pret_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Num_Demande_Pret_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Demande_Pret_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_Demande_Pret_txt.Location = New System.Drawing.Point(237, 27)
        Me.Num_Demande_Pret_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Num_Demande_Pret_txt.MaxLength = 6
        Me.Num_Demande_Pret_txt.Multiline = False
        Me.Num_Demande_Pret_txt.Name = "Num_Demande_Pret_txt"
        Me.Num_Demande_Pret_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Demande_Pret_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Demande_Pret_txt.ReadOnly = True
        Me.Num_Demande_Pret_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Demande_Pret_txt.SelectionStart = 0
        Me.Num_Demande_Pret_txt.Size = New System.Drawing.Size(113, 21)
        Me.Num_Demande_Pret_txt.TabIndex = 274
        Me.Num_Demande_Pret_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Demande_Pret_txt.UseSystemPasswordChar = False
        '
        'Reglement_txt
        '
        Me.Reglement_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Reglement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Reglement_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Reglement_txt.Location = New System.Drawing.Point(528, 78)
        Me.Reglement_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Reglement_txt.MaxLength = 32767
        Me.Reglement_txt.Multiline = False
        Me.Reglement_txt.Name = "Reglement_txt"
        Me.Reglement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Reglement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Reglement_txt.ReadOnly = True
        Me.Reglement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Reglement_txt.SelectionStart = 0
        Me.Reglement_txt.Size = New System.Drawing.Size(68, 21)
        Me.Reglement_txt.TabIndex = 255
        Me.Reglement_txt.Text = "0,00"
        Me.Reglement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Reglement_txt.UseSystemPasswordChar = False
        '
        'Reglement
        '
        Me.Reglement.AutoSize = True
        Me.Reglement.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Reglement.Location = New System.Drawing.Point(457, 81)
        Me.Reglement.Name = "Reglement"
        Me.Reglement.Size = New System.Drawing.Size(66, 16)
        Me.Reglement.TabIndex = 254
        Me.Reglement.Text = "Réglement"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label13.Location = New System.Drawing.Point(333, 82)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 16)
        Me.Label13.TabIndex = 271
        Me.Label13.Text = "%"
        '
        'Assurance_txt
        '
        Me.Assurance_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Assurance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Assurance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Assurance_txt.Location = New System.Drawing.Point(272, 78)
        Me.Assurance_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Assurance_txt.MaxLength = 32767
        Me.Assurance_txt.Multiline = False
        Me.Assurance_txt.Name = "Assurance_txt"
        Me.Assurance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Assurance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Assurance_txt.ReadOnly = False
        Me.Assurance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Assurance_txt.SelectionStart = 0
        Me.Assurance_txt.Size = New System.Drawing.Size(56, 21)
        Me.Assurance_txt.TabIndex = 7
        Me.Assurance_txt.Text = "0,00"
        Me.Assurance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Assurance_txt.UseSystemPasswordChar = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label12.Location = New System.Drawing.Point(202, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 16)
        Me.Label12.TabIndex = 269
        Me.Label12.Text = "Assurances"
        '
        'organisme_lbl
        '
        Me.organisme_lbl.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.organisme_lbl.AutoSize = True
        Me.organisme_lbl.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.organisme_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.organisme_lbl.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.organisme_lbl.Location = New System.Drawing.Point(161, 53)
        Me.organisme_lbl.Name = "organisme_lbl"
        Me.organisme_lbl.Size = New System.Drawing.Size(72, 16)
        Me.organisme_lbl.TabIndex = 6
        Me.organisme_lbl.TabStop = True
        Me.organisme_lbl.Tag = ""
        Me.organisme_lbl.Text = "Organisme :"
        Me.organisme_lbl.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Organisme_txt
        '
        Me.Lib_Organisme_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Organisme_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Organisme_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Organisme_txt.Location = New System.Drawing.Point(353, 51)
        Me.Lib_Organisme_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Organisme_txt.MaxLength = 50
        Me.Lib_Organisme_txt.Multiline = False
        Me.Lib_Organisme_txt.Name = "Lib_Organisme_txt"
        Me.Lib_Organisme_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Organisme_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Organisme_txt.ReadOnly = True
        Me.Lib_Organisme_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Organisme_txt.SelectionStart = 0
        Me.Lib_Organisme_txt.Size = New System.Drawing.Size(243, 21)
        Me.Lib_Organisme_txt.TabIndex = 266
        Me.Lib_Organisme_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Organisme_txt.UseSystemPasswordChar = False
        '
        'Organisme_txt
        '
        Me.Organisme_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Organisme_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Organisme_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Organisme_txt.Location = New System.Drawing.Point(237, 51)
        Me.Organisme_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Organisme_txt.MaxLength = 6
        Me.Organisme_txt.Multiline = False
        Me.Organisme_txt.Name = "Organisme_txt"
        Me.Organisme_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Organisme_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Organisme_txt.ReadOnly = True
        Me.Organisme_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Organisme_txt.SelectionStart = 0
        Me.Organisme_txt.Size = New System.Drawing.Size(113, 21)
        Me.Organisme_txt.TabIndex = 267
        Me.Organisme_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Organisme_txt.UseSystemPasswordChar = False
        '
        'Rd_3
        '
        Me.Rd_3.AutoSize = True
        Me.Rd_3.Checked = False
        Me.Rd_3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_3.Location = New System.Drawing.Point(12, 75)
        Me.Rd_3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rd_3.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_3.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_3.Name = "Rd_3"
        Me.Rd_3.Size = New System.Drawing.Size(131, 31)
        Me.Rd_3.TabIndex = 265
        Me.Rd_3.Text = "Autres prêts"
        '
        'Rd_2
        '
        Me.Rd_2.AutoSize = True
        Me.Rd_2.Checked = False
        Me.Rd_2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_2.Location = New System.Drawing.Point(12, 47)
        Me.Rd_2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rd_2.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_2.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_2.Name = "Rd_2"
        Me.Rd_2.Size = New System.Drawing.Size(131, 31)
        Me.Rd_2.TabIndex = 265
        Me.Rd_2.Text = "Prêt immobilier"
        '
        'Rd_1
        '
        Me.Rd_1.AutoSize = True
        Me.Rd_1.Checked = False
        Me.Rd_1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_1.Location = New System.Drawing.Point(12, 20)
        Me.Rd_1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rd_1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_1.Name = "Rd_1"
        Me.Rd_1.Size = New System.Drawing.Size(131, 31)
        Me.Rd_1.TabIndex = 5
        Me.Rd_1.Text = "Prêt entreprise"
        '
        'Mensualite_txt
        '
        Me.Mensualite_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Mensualite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Mensualite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Mensualite_txt.Location = New System.Drawing.Point(883, 79)
        Me.Mensualite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Mensualite_txt.MaxLength = 32767
        Me.Mensualite_txt.Multiline = False
        Me.Mensualite_txt.Name = "Mensualite_txt"
        Me.Mensualite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Mensualite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Mensualite_txt.ReadOnly = True
        Me.Mensualite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mensualite_txt.SelectionStart = 0
        Me.Mensualite_txt.Size = New System.Drawing.Size(68, 21)
        Me.Mensualite_txt.TabIndex = 263
        Me.Mensualite_txt.Text = "0,00"
        Me.Mensualite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Mensualite_txt.UseSystemPasswordChar = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(816, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 16)
        Me.Label11.TabIndex = 262
        Me.Label11.Text = "Mensualité"
        '
        'Premiere_Echeance_txt
        '
        Me.Premiere_Echeance_txt.AccessibleDescription = "A"
        Me.Premiere_Echeance_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Premiere_Echeance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Premiere_Echeance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Premiere_Echeance_txt.Location = New System.Drawing.Point(883, 30)
        Me.Premiere_Echeance_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Premiere_Echeance_txt.MaxLength = 32767
        Me.Premiere_Echeance_txt.Multiline = False
        Me.Premiere_Echeance_txt.Name = "Premiere_Echeance_txt"
        Me.Premiere_Echeance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Premiere_Echeance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Premiere_Echeance_txt.ReadOnly = True
        Me.Premiere_Echeance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Premiere_Echeance_txt.SelectionStart = 0
        Me.Premiere_Echeance_txt.Size = New System.Drawing.Size(68, 21)
        Me.Premiere_Echeance_txt.TabIndex = 260
        Me.Premiere_Echeance_txt.TabStop = False
        Me.Premiere_Echeance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Premiere_Echeance_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(800, 32)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(81, 16)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "SC"
        Me.LinkLabel1.Text = "1e échéance"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(799, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 16)
        Me.Label10.TabIndex = 259
        Me.Label10.Text = "Durée en mois"
        '
        'Duree
        '
        Me.Duree.Location = New System.Drawing.Point(883, 57)
        Me.Duree.Maximum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.Duree.Name = "Duree"
        Me.Duree.Size = New System.Drawing.Size(67, 21)
        Me.Duree.TabIndex = 4
        Me.Duree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(767, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 16)
        Me.Label7.TabIndex = 257
        Me.Label7.Text = "%"
        '
        'Taux_TVA_txt
        '
        Me.Taux_TVA_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Taux_TVA_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Taux_TVA_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Taux_TVA_txt.Location = New System.Drawing.Point(709, 79)
        Me.Taux_TVA_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Taux_TVA_txt.MaxLength = 32767
        Me.Taux_TVA_txt.Multiline = False
        Me.Taux_TVA_txt.Name = "Taux_TVA_txt"
        Me.Taux_TVA_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Taux_TVA_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Taux_TVA_txt.ReadOnly = False
        Me.Taux_TVA_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Taux_TVA_txt.SelectionStart = 0
        Me.Taux_TVA_txt.Size = New System.Drawing.Size(56, 21)
        Me.Taux_TVA_txt.TabIndex = 2
        Me.Taux_TVA_txt.Text = "0,00"
        Me.Taux_TVA_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Taux_TVA_txt.UseSystemPasswordChar = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(676, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 16)
        Me.Label8.TabIndex = 255
        Me.Label8.Text = "TVA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(767, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 16)
        Me.Label6.TabIndex = 254
        Me.Label6.Text = "%"
        '
        'Taux_txt
        '
        Me.Taux_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Taux_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Taux_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Taux_txt.Location = New System.Drawing.Point(709, 54)
        Me.Taux_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Taux_txt.MaxLength = 32767
        Me.Taux_txt.Multiline = False
        Me.Taux_txt.Name = "Taux_txt"
        Me.Taux_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Taux_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Taux_txt.ReadOnly = False
        Me.Taux_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Taux_txt.SelectionStart = 0
        Me.Taux_txt.Size = New System.Drawing.Size(56, 21)
        Me.Taux_txt.TabIndex = 1
        Me.Taux_txt.Text = "0,00"
        Me.Taux_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Taux_txt.UseSystemPasswordChar = False
        '
        'Montant_Pret_txt
        '
        Me.Montant_Pret_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Montant_Pret_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Montant_Pret_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Montant_Pret_txt.Location = New System.Drawing.Point(709, 30)
        Me.Montant_Pret_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Montant_Pret_txt.MaxLength = 32767
        Me.Montant_Pret_txt.Multiline = False
        Me.Montant_Pret_txt.Name = "Montant_Pret_txt"
        Me.Montant_Pret_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Montant_Pret_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Montant_Pret_txt.ReadOnly = False
        Me.Montant_Pret_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Montant_Pret_txt.SelectionStart = 0
        Me.Montant_Pret_txt.Size = New System.Drawing.Size(73, 21)
        Me.Montant_Pret_txt.TabIndex = 0
        Me.Montant_Pret_txt.Text = "0,00"
        Me.Montant_Pret_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Montant_Pret_txt.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(672, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 16)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "Taux"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label17.Location = New System.Drawing.Point(649, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 16)
        Me.Label17.TabIndex = 241
        Me.Label17.Text = "Montant"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.LinkLabel4)
        Me.GroupBox2.Controls.Add(Me.Num_Pret_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Dat_Demande_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.GroupBox2.Controls.Add(Me.Lib_Plan_Paie_Text)
        Me.GroupBox2.Controls.Add(Me.pb_Valide)
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
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1000, 178)
        Me.GroupBox2.TabIndex = 256
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fiche signalitique"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LastDatePaie_txt)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Prets_Encours_txt)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Reste_Salaire_txt)
        Me.GroupBox1.Controls.Add(Me.Dernier_Salaire_Net_txt)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Location = New System.Drawing.Point(58, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(826, 47)
        Me.GroupBox1.TabIndex = 273
        Me.GroupBox1.TabStop = False
        '
        'LastDatePaie_txt
        '
        Me.LastDatePaie_txt.BackColor = System.Drawing.SystemColors.Control
        Me.LastDatePaie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.LastDatePaie_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LastDatePaie_txt.Location = New System.Drawing.Point(112, 12)
        Me.LastDatePaie_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LastDatePaie_txt.MaxLength = 10
        Me.LastDatePaie_txt.Multiline = False
        Me.LastDatePaie_txt.Name = "LastDatePaie_txt"
        Me.LastDatePaie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LastDatePaie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.LastDatePaie_txt.ReadOnly = True
        Me.LastDatePaie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.LastDatePaie_txt.SelectionStart = 0
        Me.LastDatePaie_txt.Size = New System.Drawing.Size(68, 21)
        Me.LastDatePaie_txt.TabIndex = 244
        Me.LastDatePaie_txt.Tag = "4"
        Me.LastDatePaie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.LastDatePaie_txt.UseSystemPasswordChar = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label19.Location = New System.Drawing.Point(189, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 16)
        Me.Label19.TabIndex = 242
        Me.Label19.Text = "Dernier salaire net"
        '
        'Prets_Encours_txt
        '
        Me.Prets_Encours_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Prets_Encours_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Prets_Encours_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Prets_Encours_txt.Location = New System.Drawing.Point(454, 12)
        Me.Prets_Encours_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Prets_Encours_txt.MaxLength = 32767
        Me.Prets_Encours_txt.Multiline = False
        Me.Prets_Encours_txt.Name = "Prets_Encours_txt"
        Me.Prets_Encours_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Prets_Encours_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Prets_Encours_txt.ReadOnly = True
        Me.Prets_Encours_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Prets_Encours_txt.SelectionStart = 0
        Me.Prets_Encours_txt.Size = New System.Drawing.Size(68, 21)
        Me.Prets_Encours_txt.TabIndex = 255
        Me.Prets_Encours_txt.Text = "0,00"
        Me.Prets_Encours_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Prets_Encours_txt.UseSystemPasswordChar = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label20.Location = New System.Drawing.Point(543, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 16)
        Me.Label20.TabIndex = 240
        Me.Label20.Text = "Reste"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label14.Location = New System.Drawing.Point(370, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 16)
        Me.Label14.TabIndex = 254
        Me.Label14.Text = "Prêts en cours"
        '
        'Reste_Salaire_txt
        '
        Me.Reste_Salaire_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Reste_Salaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Reste_Salaire_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Reste_Salaire_txt.Location = New System.Drawing.Point(583, 12)
        Me.Reste_Salaire_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Reste_Salaire_txt.MaxLength = 32767
        Me.Reste_Salaire_txt.Multiline = False
        Me.Reste_Salaire_txt.Name = "Reste_Salaire_txt"
        Me.Reste_Salaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Reste_Salaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Reste_Salaire_txt.ReadOnly = True
        Me.Reste_Salaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Reste_Salaire_txt.SelectionStart = 0
        Me.Reste_Salaire_txt.Size = New System.Drawing.Size(68, 21)
        Me.Reste_Salaire_txt.TabIndex = 246
        Me.Reste_Salaire_txt.Text = "0,00"
        Me.Reste_Salaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Reste_Salaire_txt.UseSystemPasswordChar = False
        '
        'Dernier_Salaire_Net_txt
        '
        Me.Dernier_Salaire_Net_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Dernier_Salaire_Net_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dernier_Salaire_Net_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dernier_Salaire_Net_txt.Location = New System.Drawing.Point(295, 12)
        Me.Dernier_Salaire_Net_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dernier_Salaire_Net_txt.MaxLength = 32767
        Me.Dernier_Salaire_Net_txt.Multiline = False
        Me.Dernier_Salaire_Net_txt.Name = "Dernier_Salaire_Net_txt"
        Me.Dernier_Salaire_Net_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dernier_Salaire_Net_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dernier_Salaire_Net_txt.ReadOnly = True
        Me.Dernier_Salaire_Net_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dernier_Salaire_Net_txt.SelectionStart = 0
        Me.Dernier_Salaire_Net_txt.Size = New System.Drawing.Size(68, 21)
        Me.Dernier_Salaire_Net_txt.TabIndex = 248
        Me.Dernier_Salaire_Net_txt.Text = "0,00"
        Me.Dernier_Salaire_Net_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Dernier_Salaire_Net_txt.UseSystemPasswordChar = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label24.Location = New System.Drawing.Point(28, 15)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 16)
        Me.Label24.TabIndex = 243
        Me.Label24.Text = "Dernière paie"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(196, 23)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(93, 16)
        Me.LinkLabel4.TabIndex = 272
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Date demande"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Num_Pret_txt
        '
        Me.Num_Pret_txt.AccessibleDescription = "A"
        Me.Num_Pret_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Num_Pret_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Pret_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_Pret_txt.Location = New System.Drawing.Point(86, 21)
        Me.Num_Pret_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Num_Pret_txt.MaxLength = 32767
        Me.Num_Pret_txt.Multiline = False
        Me.Num_Pret_txt.Name = "Num_Pret_txt"
        Me.Num_Pret_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Pret_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Pret_txt.ReadOnly = True
        Me.Num_Pret_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Pret_txt.SelectionStart = 0
        Me.Num_Pret_txt.Size = New System.Drawing.Size(104, 21)
        Me.Num_Pret_txt.TabIndex = 248
        Me.Num_Pret_txt.TabStop = False
        Me.Num_Pret_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Pret_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(32, 23)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(44, 16)
        Me.LinkLabel3.TabIndex = 249
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SC"
        Me.LinkLabel3.Text = "N° Prêt"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dat_Demande_txt
        '
        Me.Dat_Demande_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Dat_Demande_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Demande_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Demande_txt.Location = New System.Drawing.Point(292, 20)
        Me.Dat_Demande_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dat_Demande_txt.MaxLength = 32767
        Me.Dat_Demande_txt.Multiline = False
        Me.Dat_Demande_txt.Name = "Dat_Demande_txt"
        Me.Dat_Demande_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Demande_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Demande_txt.ReadOnly = True
        Me.Dat_Demande_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Demande_txt.SelectionStart = 0
        Me.Dat_Demande_txt.Size = New System.Drawing.Size(74, 21)
        Me.Dat_Demande_txt.TabIndex = 251
        Me.Dat_Demande_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Demande_txt.UseSystemPasswordChar = False
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.BackColor = System.Drawing.SystemColors.Control
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(560, 18)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Plan_Paie_Text.MaxLength = 6
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(78, 21)
        Me.Cod_Plan_Paie_Text.TabIndex = 242
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(641, 18)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Plan_Paie_Text.MaxLength = 50
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = True
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(243, 21)
        Me.Lib_Plan_Paie_Text.TabIndex = 241
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(913, 46)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(62, 62)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Valide.TabIndex = 253
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'Lib_Grade_Text
        '
        Me.Lib_Grade_Text.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Grade_Text.Location = New System.Drawing.Point(167, 95)
        Me.Lib_Grade_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Grade_Text.MaxLength = 50
        Me.Lib_Grade_Text.Multiline = False
        Me.Lib_Grade_Text.Name = "Lib_Grade_Text"
        Me.Lib_Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_Text.ReadOnly = True
        Me.Lib_Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_Text.SelectionStart = 0
        Me.Lib_Grade_Text.Size = New System.Drawing.Size(346, 21)
        Me.Lib_Grade_Text.TabIndex = 231
        Me.Lib_Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_Text.UseSystemPasswordChar = False
        '
        'Grade_Text
        '
        Me.Grade_Text.BackColor = System.Drawing.SystemColors.Control
        Me.Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_Text.Location = New System.Drawing.Point(86, 95)
        Me.Grade_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grade_Text.MaxLength = 6
        Me.Grade_Text.Multiline = False
        Me.Grade_Text.Name = "Grade_Text"
        Me.Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Grade_Text.ReadOnly = True
        Me.Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grade_Text.SelectionStart = 0
        Me.Grade_Text.Size = New System.Drawing.Size(78, 21)
        Me.Grade_Text.TabIndex = 232
        Me.Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Grade_Text.UseSystemPasswordChar = False
        '
        'Lib_Poste_Text
        '
        Me.Lib_Poste_Text.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Poste_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Poste_Text.Location = New System.Drawing.Point(167, 71)
        Me.Lib_Poste_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Poste_Text.MaxLength = 50
        Me.Lib_Poste_Text.Multiline = False
        Me.Lib_Poste_Text.Name = "Lib_Poste_Text"
        Me.Lib_Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Poste_Text.ReadOnly = True
        Me.Lib_Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Poste_Text.SelectionStart = 0
        Me.Lib_Poste_Text.Size = New System.Drawing.Size(346, 21)
        Me.Lib_Poste_Text.TabIndex = 228
        Me.Lib_Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Poste_Text.UseSystemPasswordChar = False
        '
        'Poste_Text
        '
        Me.Poste_Text.BackColor = System.Drawing.SystemColors.Control
        Me.Poste_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Poste_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Poste_Text.Location = New System.Drawing.Point(86, 71)
        Me.Poste_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Poste_Text.MaxLength = 6
        Me.Poste_Text.Multiline = False
        Me.Poste_Text.Name = "Poste_Text"
        Me.Poste_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Poste_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Poste_Text.ReadOnly = True
        Me.Poste_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Poste_Text.SelectionStart = 0
        Me.Poste_Text.Size = New System.Drawing.Size(78, 21)
        Me.Poste_Text.TabIndex = 229
        Me.Poste_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Poste_Text.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(641, 43)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(243, 21)
        Me.Lib_Entite_txt.TabIndex = 234
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(560, 43)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Entite_txt.MaxLength = 6
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(78, 21)
        Me.Cod_Entite_txt.TabIndex = 235
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Titre_txt
        '
        Me.Titre_txt.AccessibleDescription = "A"
        Me.Titre_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Titre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Titre_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Titre_txt.Location = New System.Drawing.Point(560, 67)
        Me.Titre_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Titre_txt.MaxLength = 490
        Me.Titre_txt.Multiline = True
        Me.Titre_txt.Name = "Titre_txt"
        Me.Titre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Titre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Titre_txt.ReadOnly = True
        Me.Titre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Titre_txt.SelectionStart = 0
        Me.Titre_txt.Size = New System.Drawing.Size(323, 49)
        Me.Titre_txt.TabIndex = 236
        Me.Titre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Titre_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(528, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 16)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Titre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(29, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Poste"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(525, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 239
        Me.Label9.Text = "Plan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(38, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Grade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(518, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 16)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Entité"
        '
        'RH_Pret
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 586)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RH_Pret"
        Me.Tag = "ECR"
        Me.Text = "Gestion des prêts"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Duree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
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
    Friend WithEvents Reste_Salaire_txt As ud_TextBox
    Friend WithEvents Montant_Pret_txt As ud_TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Dernier_Salaire_Net_txt As ud_TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Dat_Demande_txt As ud_TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents LastDatePaie_txt As ud_TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Num_Pret_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Mensualite_txt As ud_TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Premiere_Echeance_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label10 As Label
    Friend WithEvents Duree As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents Taux_TVA_txt As ud_TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Taux_txt As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents organisme_lbl As LinkLabel
    Friend WithEvents Lib_Organisme_txt As ud_TextBox
    Friend WithEvents Organisme_txt As ud_TextBox
    Friend WithEvents Rd_3 As ud_RadioBox
    Friend WithEvents Rd_2 As ud_RadioBox
    Friend WithEvents Rd_1 As ud_RadioBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Assurance_txt As ud_TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Prets_Encours_txt As ud_TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Reglement_txt As ud_TextBox
    Friend WithEvents Reglement As Label
    Friend WithEvents Grd As ud_Grd
    Friend WithEvents Dat As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Capital As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Mensualite As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Interet As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Amortissement As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents CRD As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Num_Demande_Pret_lbl As LinkLabel
    Friend WithEvents Lib_Num_Demande_Pret_txt As ud_TextBox
    Friend WithEvents Num_Demande_Pret_txt As ud_TextBox
    Friend WithEvents Commentaire_txt As ud_TextBox
End Class
