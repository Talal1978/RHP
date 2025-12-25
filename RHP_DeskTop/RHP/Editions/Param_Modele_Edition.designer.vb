<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Param_Modele_Edition
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Criteres_Grd = New RHP.ud_Grd()
        Me.Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Critere = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Fonction_Critere = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Table_Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Champs_01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Champs_02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Condition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Default_Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Nom_Report_Text = New RHP.ud_TextBox()
        Me.Cod_Report_Text = New RHP.ud_TextBox()
        Me.ReportExists_Label = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.withPassword_chk = New RHP.ud_CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Typ_Modele_Edition_cbo = New RHP.ud_ComboBox()
        Me.parSociete_chk = New RHP.ud_CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Grd_Soc = New RHP.ud_Grd()
        Me.Portail_chk = New RHP.ud_CheckBox()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Criteres_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.Grd_Soc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.Controls.Add(Me.ButtonX1, 0, 0)
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(200, 100)
        Me.Personnal_pnl.TabIndex = 0
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX1.Location = New System.Drawing.Point(16, 38)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(67, 23)
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.Text = "OK"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Location = New System.Drawing.Point(36, 3)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(28, 8)
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "Annuler"
        '
        'Criteres_Grd
        '
        Me.Criteres_Grd.AfficherLesEntetesLignes = True
        Me.Criteres_Grd.AllowUserToOrderColumns = True
        Me.Criteres_Grd.AlternerLesLignes = False
        Me.Criteres_Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Criteres_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Criteres_Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Criteres_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Criteres_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Criteres_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Criteres_Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Critere, Me.Lib_Critere, Me.Typ_Critere, Me.Fonction_Critere, Me.Table_Critere, Me.Champs_01, Me.Champs_02, Me.Condition, Me.Default_Value, Me.Rang})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Criteres_Grd.DefaultCellStyle = DataGridViewCellStyle8
        Me.Criteres_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Criteres_Grd.EnableHeadersVisualStyles = False
        Me.Criteres_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Criteres_Grd.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Criteres_Grd.Location = New System.Drawing.Point(4, 4)
        Me.Criteres_Grd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Criteres_Grd.Name = "Criteres_Grd"
        Me.Criteres_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Criteres_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Criteres_Grd.RowHeadersWidth = 51
        Me.Criteres_Grd.Size = New System.Drawing.Size(1112, 565)
        Me.Criteres_Grd.TabIndex = 4
        Me.Criteres_Grd.Tag = "NC"
        '
        'Critere
        '
        Me.Critere.FillWeight = 30.0!
        Me.Critere.HeaderText = "Critère"
        Me.Critere.MinimumWidth = 100
        Me.Critere.Name = "Critere"
        Me.Critere.ReadOnly = True
        '
        'Lib_Critere
        '
        Me.Lib_Critere.FillWeight = 50.0!
        Me.Lib_Critere.HeaderText = "Libellé"
        Me.Lib_Critere.MinimumWidth = 250
        Me.Lib_Critere.Name = "Lib_Critere"
        Me.Lib_Critere.Width = 250
        '
        'Typ_Critere
        '
        Me.Typ_Critere.FillWeight = 30.0!
        Me.Typ_Critere.HeaderText = "Type"
        Me.Typ_Critere.MinimumWidth = 100
        Me.Typ_Critere.Name = "Typ_Critere"
        Me.Typ_Critere.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Typ_Critere.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Fonction_Critere
        '
        Me.Fonction_Critere.FillWeight = 30.0!
        Me.Fonction_Critere.HeaderText = "Fonction"
        Me.Fonction_Critere.MinimumWidth = 100
        Me.Fonction_Critere.Name = "Fonction_Critere"
        Me.Fonction_Critere.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fonction_Critere.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Fonction_Critere.Width = 107
        '
        'Table_Critere
        '
        Me.Table_Critere.HeaderText = "Table"
        Me.Table_Critere.MinimumWidth = 100
        Me.Table_Critere.Name = "Table_Critere"
        '
        'Champs_01
        '
        Me.Champs_01.HeaderText = "Champs 01"
        Me.Champs_01.MinimumWidth = 100
        Me.Champs_01.Name = "Champs_01"
        Me.Champs_01.Width = 116
        '
        'Champs_02
        '
        Me.Champs_02.HeaderText = "Champs 02"
        Me.Champs_02.MinimumWidth = 100
        Me.Champs_02.Name = "Champs_02"
        Me.Champs_02.Width = 116
        '
        'Condition
        '
        Me.Condition.HeaderText = "Condition"
        Me.Condition.MinimumWidth = 100
        Me.Condition.Name = "Condition"
        Me.Condition.Width = 115
        '
        'Default_Value
        '
        Me.Default_Value.HeaderText = "Valeur Par Défaut"
        Me.Default_Value.MinimumWidth = 6
        Me.Default_Value.Name = "Default_Value"
        Me.Default_Value.Width = 155
        '
        'Rang
        '
        Me.Rang.HeaderText = "Rang"
        Me.Rang.MinimumWidth = 6
        Me.Rang.Name = "Rang"
        Me.Rang.Width = 84
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(90, 25)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(127, 19)
        Me.LinkLabel4.TabIndex = 0
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = ""
        Me.LinkLabel4.Text = "Modèle d'édition"
        '
        'Nom_Report_Text
        '
        Me.Nom_Report_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Report_Text.ContextMenuStrip = Nothing
        Me.Nom_Report_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Report_Text.Location = New System.Drawing.Point(222, 51)
        Me.Nom_Report_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_Report_Text.MaxLength = 100
        Me.Nom_Report_Text.Multiline = True
        Me.Nom_Report_Text.Name = "Nom_Report_Text"
        Me.Nom_Report_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Report_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Report_Text.ReadOnly = False
        Me.Nom_Report_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Report_Text.SelectionStart = 0
        Me.Nom_Report_Text.Size = New System.Drawing.Size(529, 25)
        Me.Nom_Report_Text.TabIndex = 1
        Me.Nom_Report_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Report_Text.UseSystemPasswordChar = False
        '
        'Cod_Report_Text
        '
        Me.Cod_Report_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Report_Text.ContextMenuStrip = Nothing
        Me.Cod_Report_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Report_Text.Location = New System.Drawing.Point(222, 21)
        Me.Cod_Report_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Report_Text.MaxLength = 32767
        Me.Cod_Report_Text.Multiline = False
        Me.Cod_Report_Text.Name = "Cod_Report_Text"
        Me.Cod_Report_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Report_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Report_Text.ReadOnly = True
        Me.Cod_Report_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Report_Text.SelectionStart = 0
        Me.Cod_Report_Text.Size = New System.Drawing.Size(318, 26)
        Me.Cod_Report_Text.TabIndex = 96
        Me.Cod_Report_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Report_Text.UseSystemPasswordChar = False
        '
        'ReportExists_Label
        '
        Me.ReportExists_Label.AutoSize = True
        Me.ReportExists_Label.Font = New System.Drawing.Font("Century Gothic", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportExists_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ReportExists_Label.Location = New System.Drawing.Point(51, 52)
        Me.ReportExists_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ReportExists_Label.Name = "ReportExists_Label"
        Me.ReportExists_Label.Size = New System.Drawing.Size(173, 17)
        Me.ReportExists_Label.TabIndex = 109
        Me.ReportExists_Label.Text = "Ce modèle n'existe pas:"
        Me.ReportExists_Label.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Portail_chk)
        Me.Panel1.Controls.Add(Me.withPassword_chk)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Typ_Modele_Edition_cbo)
        Me.Panel1.Controls.Add(Me.parSociete_chk)
        Me.Panel1.Controls.Add(Me.Cod_Report_Text)
        Me.Panel1.Controls.Add(Me.ReportExists_Label)
        Me.Panel1.Controls.Add(Me.Nom_Report_Text)
        Me.Panel1.Controls.Add(Me.LinkLabel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1128, 156)
        Me.Panel1.TabIndex = 217
        '
        'withPassword_chk
        '
        Me.withPassword_chk.AutoSize = True
        Me.withPassword_chk.Checked = False
        Me.withPassword_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.withPassword_chk.Location = New System.Drawing.Point(222, 116)
        Me.withPassword_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.withPassword_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.withPassword_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.withPassword_chk.Name = "withPassword_chk"
        Me.withPassword_chk.Size = New System.Drawing.Size(304, 31)
        Me.withPassword_chk.TabIndex = 113
        Me.withPassword_chk.Text = "Protéger le document par mot de passe"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(126, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 19)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "Type édition"
        '
        'Typ_Modele_Edition_cbo
        '
        Me.Typ_Modele_Edition_cbo.DataSource = Nothing
        Me.Typ_Modele_Edition_cbo.DisplayMember = ""
        Me.Typ_Modele_Edition_cbo.DroppedDown = False
        Me.Typ_Modele_Edition_cbo.Location = New System.Drawing.Point(222, 80)
        Me.Typ_Modele_Edition_cbo.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Typ_Modele_Edition_cbo.Name = "Typ_Modele_Edition_cbo"
        Me.Typ_Modele_Edition_cbo.SelectedIndex = -1
        Me.Typ_Modele_Edition_cbo.SelectedItem = Nothing
        Me.Typ_Modele_Edition_cbo.SelectedValue = Nothing
        Me.Typ_Modele_Edition_cbo.Size = New System.Drawing.Size(188, 30)
        Me.Typ_Modele_Edition_cbo.TabIndex = 2
        Me.Typ_Modele_Edition_cbo.ValueMember = ""
        '
        'parSociete_chk
        '
        Me.parSociete_chk.AutoSize = True
        Me.parSociete_chk.Checked = True
        Me.parSociete_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.parSociete_chk.Location = New System.Drawing.Point(548, 116)
        Me.parSociete_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.parSociete_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.parSociete_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.parSociete_chk.Name = "parSociete_chk"
        Me.parSociete_chk.Size = New System.Drawing.Size(229, 31)
        Me.parSociete_chk.TabIndex = 110
        Me.parSociete_chk.Text = "Spécifique à chaque société"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 156)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1128, 605)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Criteres_Grd)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1120, 573)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Critères"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Grd_Soc)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1120, 597)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Sociétés"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Grd_Soc
        '
        Me.Grd_Soc.AfficherLesEntetesLignes = True
        Me.Grd_Soc.AllowUserToAddRows = False
        Me.Grd_Soc.AllowUserToDeleteRows = False
        Me.Grd_Soc.AlternerLesLignes = False
        Me.Grd_Soc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Soc.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Soc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Soc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Soc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Soc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Soc.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Soc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Soc.EnableHeadersVisualStyles = False
        Me.Grd_Soc.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Soc.Location = New System.Drawing.Point(4, 4)
        Me.Grd_Soc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grd_Soc.Name = "Grd_Soc"
        Me.Grd_Soc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Soc.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Soc.RowHeadersVisible = False
        Me.Grd_Soc.RowHeadersWidth = 51
        Me.Grd_Soc.Size = New System.Drawing.Size(1112, 589)
        Me.Grd_Soc.TabIndex = 0
        '
        'Portail_chk
        '
        Me.Portail_chk.AutoSize = True
        Me.Portail_chk.Checked = False
        Me.Portail_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Portail_chk.Location = New System.Drawing.Point(548, 85)
        Me.Portail_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Portail_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Portail_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Portail_chk.Name = "Portail_chk"
        Me.Portail_chk.Size = New System.Drawing.Size(304, 31)
        Me.Portail_chk.TabIndex = 114
        Me.Portail_chk.Text = "Ajouter au portail de l'agent"
        '
        'Param_Modele_Edition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1128, 761)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Param_Modele_Edition"
        Me.Tag = "ECR"
        Me.Text = "Gestion des modèles éditions et états"
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Criteres_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Grd_Soc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Criteres_Grd As ud_Grd
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents Nom_Report_Text As ud_TextBox
    Friend WithEvents Cod_Report_Text As ud_TextBox
    Friend WithEvents ReportExists_Label As System.Windows.Forms.Label
    Friend WithEvents Critere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lib_Critere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Typ_Critere As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Fonction_Critere As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Table_Critere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Champs_01 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Champs_02 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Condition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Default_Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents parSociete_chk As ud_CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Grd_Soc As ud_Grd
    Friend WithEvents Label3 As Label
    Friend WithEvents Typ_Modele_Edition_cbo As ud_ComboBox
    Friend WithEvents withPassword_chk As ud_CheckBox
    Friend WithEvents Portail_chk As ud_CheckBox
End Class
