<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RH_Param_Abaques
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.abaque_GRD = New RHP.ud_Grd()
        Me.Clef_01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clef_02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clef_03 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clef_04 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur_01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur_02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur_03 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur_04 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Flag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abaque_lbl = New System.Windows.Forms.LinkLabel()
        Me.Cod_Abaque_txt = New RHP.ud_TextBox()
        Me.Lib_Abaque_txt = New RHP.ud_TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Variable_Paie_chk = New RHP.ud_CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Constante_rd = New RHP.ud_RadioBox()
        Me.fonction_rd = New RHP.ud_RadioBox()
        Me.callFunction_btn = New RHP.ud_button()
        Me.DefaultVal_txt = New RHP.ud_TextBox()
        Me.Global_chk = New RHP.ud_CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nb_Valeurs = New System.Windows.Forms.NumericUpDown()
        Me.Nb_Clefs = New System.Windows.Forms.NumericUpDown()
        Me.Typ_Retour = New RHP.ud_ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DefaultVal_lbl = New System.Windows.Forms.Label()
        Me.Typ_Retour_ = New System.Windows.Forms.Label()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.abaque_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Nb_Valeurs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nb_Clefs, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'abaque_GRD
        '
        Me.abaque_GRD.AfficherLesEntetesLignes = True
        Me.abaque_GRD.AllowUserToOrderColumns = True
        Me.abaque_GRD.AlternerLesLignes = False
        Me.abaque_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.abaque_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.abaque_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.abaque_GRD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.abaque_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.abaque_GRD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Clef_01, Me.Clef_02, Me.Clef_03, Me.Clef_04, Me.Valeur_01, Me.Valeur_02, Me.Valeur_03, Me.Valeur_04, Me.Flag})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.abaque_GRD.DefaultCellStyle = DataGridViewCellStyle2
        Me.abaque_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.abaque_GRD.EnableHeadersVisualStyles = False
        Me.abaque_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.abaque_GRD.Location = New System.Drawing.Point(0, 220)
        Me.abaque_GRD.Name = "abaque_GRD"
        Me.abaque_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.abaque_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.abaque_GRD.RowHeadersWidth = 51
        Me.abaque_GRD.Size = New System.Drawing.Size(902, 519)
        Me.abaque_GRD.TabIndex = 3
        '
        'Clef_01
        '
        Me.Clef_01.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Clef_01.HeaderText = "Clef 1"
        Me.Clef_01.MinimumWidth = 6
        Me.Clef_01.Name = "Clef_01"
        Me.Clef_01.Width = 86
        '
        'Clef_02
        '
        Me.Clef_02.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Clef_02.HeaderText = "Clef 2"
        Me.Clef_02.MinimumWidth = 6
        Me.Clef_02.Name = "Clef_02"
        Me.Clef_02.Width = 86
        '
        'Clef_03
        '
        Me.Clef_03.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Clef_03.HeaderText = "Clef 3"
        Me.Clef_03.MinimumWidth = 6
        Me.Clef_03.Name = "Clef_03"
        Me.Clef_03.Width = 86
        '
        'Clef_04
        '
        Me.Clef_04.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Clef_04.HeaderText = "Clef 4"
        Me.Clef_04.MinimumWidth = 6
        Me.Clef_04.Name = "Clef_04"
        Me.Clef_04.Width = 86
        '
        'Valeur_01
        '
        Me.Valeur_01.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur_01.HeaderText = "Valeur 1"
        Me.Valeur_01.MinimumWidth = 6
        Me.Valeur_01.Name = "Valeur_01"
        Me.Valeur_01.Width = 103
        '
        'Valeur_02
        '
        Me.Valeur_02.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur_02.HeaderText = "Valeur 2"
        Me.Valeur_02.MinimumWidth = 6
        Me.Valeur_02.Name = "Valeur_02"
        Me.Valeur_02.Width = 103
        '
        'Valeur_03
        '
        Me.Valeur_03.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur_03.HeaderText = "Valeur 3"
        Me.Valeur_03.MinimumWidth = 6
        Me.Valeur_03.Name = "Valeur_03"
        Me.Valeur_03.Width = 103
        '
        'Valeur_04
        '
        Me.Valeur_04.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur_04.HeaderText = "Valeur 4"
        Me.Valeur_04.MinimumWidth = 6
        Me.Valeur_04.Name = "Valeur_04"
        Me.Valeur_04.Width = 103
        '
        'Flag
        '
        Me.Flag.HeaderText = "Flag"
        Me.Flag.MinimumWidth = 6
        Me.Flag.Name = "Flag"
        Me.Flag.Visible = False
        Me.Flag.Width = 125
        '
        'Abaque_lbl
        '
        Me.Abaque_lbl.AutoSize = True
        Me.Abaque_lbl.LinkColor = System.Drawing.Color.Black
        Me.Abaque_lbl.Location = New System.Drawing.Point(85, 25)
        Me.Abaque_lbl.Name = "Abaque_lbl"
        Me.Abaque_lbl.Size = New System.Drawing.Size(66, 19)
        Me.Abaque_lbl.TabIndex = 0
        Me.Abaque_lbl.TabStop = True
        Me.Abaque_lbl.Tag = ""
        Me.Abaque_lbl.Text = "Abaque"
        '
        'Cod_Abaque_txt
        '
        Me.Cod_Abaque_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Abaque_txt.ContextMenuStrip = Nothing
        Me.Cod_Abaque_txt.Location = New System.Drawing.Point(164, 25)
        Me.Cod_Abaque_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cod_Abaque_txt.MaxLength = 50
        Me.Cod_Abaque_txt.Multiline = False
        Me.Cod_Abaque_txt.Name = "Cod_Abaque_txt"
        Me.Cod_Abaque_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Abaque_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Abaque_txt.ReadOnly = True
        Me.Cod_Abaque_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Abaque_txt.SelectionStart = 0
        Me.Cod_Abaque_txt.Size = New System.Drawing.Size(163, 21)
        Me.Cod_Abaque_txt.TabIndex = 71
        Me.Cod_Abaque_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Abaque_txt.UseSystemPasswordChar = False
        '
        'Lib_Abaque_txt
        '
        Me.Lib_Abaque_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Abaque_txt.ContextMenuStrip = Nothing
        Me.Lib_Abaque_txt.Location = New System.Drawing.Point(333, 25)
        Me.Lib_Abaque_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Lib_Abaque_txt.MaxLength = 50
        Me.Lib_Abaque_txt.Multiline = False
        Me.Lib_Abaque_txt.Name = "Lib_Abaque_txt"
        Me.Lib_Abaque_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Abaque_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Abaque_txt.ReadOnly = False
        Me.Lib_Abaque_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Abaque_txt.SelectionStart = 0
        Me.Lib_Abaque_txt.Size = New System.Drawing.Size(410, 21)
        Me.Lib_Abaque_txt.TabIndex = 72
        Me.Lib_Abaque_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Abaque_txt.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Variable_Paie_chk)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.callFunction_btn)
        Me.Panel1.Controls.Add(Me.DefaultVal_txt)
        Me.Panel1.Controls.Add(Me.Global_chk)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Nb_Valeurs)
        Me.Panel1.Controls.Add(Me.Nb_Clefs)
        Me.Panel1.Controls.Add(Me.Typ_Retour)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.DefaultVal_lbl)
        Me.Panel1.Controls.Add(Me.Typ_Retour_)
        Me.Panel1.Controls.Add(Me.Cod_Abaque_txt)
        Me.Panel1.Controls.Add(Me.Abaque_lbl)
        Me.Panel1.Controls.Add(Me.Lib_Abaque_txt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(902, 220)
        Me.Panel1.TabIndex = 4
        '
        'Variable_Paie_chk
        '
        Me.Variable_Paie_chk.AutoSize = True
        Me.Variable_Paie_chk.Checked = False
        Me.Variable_Paie_chk.Location = New System.Drawing.Point(751, 49)
        Me.Variable_Paie_chk.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Variable_Paie_chk.MaximumSize = New System.Drawing.Size(0, 36)
        Me.Variable_Paie_chk.MinimumSize = New System.Drawing.Size(133, 36)
        Me.Variable_Paie_chk.Name = "Variable_Paie_chk"
        Me.Variable_Paie_chk.Size = New System.Drawing.Size(133, 36)
        Me.Variable_Paie_chk.TabIndex = 230
        Me.Variable_Paie_chk.Text = "Géré en paie"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Constante_rd)
        Me.Panel2.Controls.Add(Me.fonction_rd)
        Me.Panel2.Location = New System.Drawing.Point(187, 115)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(497, 45)
        Me.Panel2.TabIndex = 229
        '
        'Constante_rd
        '
        Me.Constante_rd.AutoSize = True
        Me.Constante_rd.Checked = True
        Me.Constante_rd.Location = New System.Drawing.Point(28, 7)
        Me.Constante_rd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Constante_rd.MaximumSize = New System.Drawing.Size(0, 30)
        Me.Constante_rd.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Constante_rd.Name = "Constante_rd"
        Me.Constante_rd.Size = New System.Drawing.Size(142, 30)
        Me.Constante_rd.TabIndex = 228
        Me.Constante_rd.Text = "Constante"
        '
        'fonction_rd
        '
        Me.fonction_rd.AutoSize = True
        Me.fonction_rd.Checked = False
        Me.fonction_rd.Location = New System.Drawing.Point(329, 7)
        Me.fonction_rd.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.fonction_rd.MaximumSize = New System.Drawing.Size(0, 36)
        Me.fonction_rd.MinimumSize = New System.Drawing.Size(0, 36)
        Me.fonction_rd.Name = "fonction_rd"
        Me.fonction_rd.Size = New System.Drawing.Size(142, 36)
        Me.fonction_rd.TabIndex = 228
        Me.fonction_rd.Text = "Fonction"
        '
        'callFunction_btn
        '
        Me.callFunction_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.callFunction_btn.bgColor = System.Drawing.Color.White
        Me.callFunction_btn.Border = RHP.ud_button.BorderStyle.None
        Me.callFunction_btn.BorderColor = System.Drawing.Color.Empty
        Me.callFunction_btn.BorderSize = 0
        Me.callFunction_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.callFunction_btn.Image = Global.RHP.My.Resources.Resources.btn_function
        Me.callFunction_btn.isDefault = False
        Me.callFunction_btn.Location = New System.Drawing.Point(774, 168)
        Me.callFunction_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.callFunction_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.callFunction_btn.Name = "callFunction_btn"
        Me.callFunction_btn.Size = New System.Drawing.Size(32, 32)
        Me.callFunction_btn.TabIndex = 227
        Me.callFunction_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.callFunction_btn.Visible = False
        '
        'DefaultVal_txt
        '
        Me.DefaultVal_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.DefaultVal_txt.ContextMenuStrip = Nothing
        Me.DefaultVal_txt.Location = New System.Drawing.Point(164, 175)
        Me.DefaultVal_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DefaultVal_txt.MaxLength = 50
        Me.DefaultVal_txt.Multiline = False
        Me.DefaultVal_txt.Name = "DefaultVal_txt"
        Me.DefaultVal_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.DefaultVal_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.DefaultVal_txt.ReadOnly = False
        Me.DefaultVal_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DefaultVal_txt.SelectionStart = 0
        Me.DefaultVal_txt.Size = New System.Drawing.Size(163, 21)
        Me.DefaultVal_txt.TabIndex = 226
        Me.DefaultVal_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.DefaultVal_txt.UseSystemPasswordChar = False
        '
        'Global_chk
        '
        Me.Global_chk.AutoSize = True
        Me.Global_chk.Checked = False
        Me.Global_chk.Location = New System.Drawing.Point(751, 16)
        Me.Global_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Global_chk.MaximumSize = New System.Drawing.Size(0, 30)
        Me.Global_chk.MinimumSize = New System.Drawing.Size(133, 30)
        Me.Global_chk.Name = "Global_chk"
        Me.Global_chk.Size = New System.Drawing.Size(133, 30)
        Me.Global_chk.TabIndex = 225
        Me.Global_chk.Text = "Global"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(552, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 19)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Nombre de valeurs"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(335, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 19)
        Me.Label1.TabIndex = 224
        Me.Label1.Text = "Nombre de Clefs"
        '
        'Nb_Valeurs
        '
        Me.Nb_Valeurs.Location = New System.Drawing.Point(698, 61)
        Me.Nb_Valeurs.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.Nb_Valeurs.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nb_Valeurs.Name = "Nb_Valeurs"
        Me.Nb_Valeurs.Size = New System.Drawing.Size(45, 24)
        Me.Nb_Valeurs.TabIndex = 223
        Me.Nb_Valeurs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Nb_Valeurs.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Nb_Clefs
        '
        Me.Nb_Clefs.Location = New System.Drawing.Point(465, 61)
        Me.Nb_Clefs.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.Nb_Clefs.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nb_Clefs.Name = "Nb_Clefs"
        Me.Nb_Clefs.Size = New System.Drawing.Size(45, 24)
        Me.Nb_Clefs.TabIndex = 223
        Me.Nb_Clefs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Nb_Clefs.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Typ_Retour
        '
        Me.Typ_Retour.DataSource = Nothing
        Me.Typ_Retour.DisplayMember = ""
        Me.Typ_Retour.DroppedDown = False
        Me.Typ_Retour.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Retour.Location = New System.Drawing.Point(164, 55)
        Me.Typ_Retour.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Typ_Retour.Name = "Typ_Retour"
        Me.Typ_Retour.SelectedIndex = -1
        Me.Typ_Retour.SelectedItem = Nothing
        Me.Typ_Retour.SelectedValue = Nothing
        Me.Typ_Retour.Size = New System.Drawing.Size(163, 30)
        Me.Typ_Retour.TabIndex = 221
        Me.Typ_Retour.ValueMember = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(13, 125)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 19)
        Me.Label4.TabIndex = 222
        Me.Label4.Text = "Type valeur par défaut"
        '
        'DefaultVal_lbl
        '
        Me.DefaultVal_lbl.AutoSize = True
        Me.DefaultVal_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.DefaultVal_lbl.Location = New System.Drawing.Point(26, 175)
        Me.DefaultVal_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DefaultVal_lbl.Name = "DefaultVal_lbl"
        Me.DefaultVal_lbl.Size = New System.Drawing.Size(132, 19)
        Me.DefaultVal_lbl.TabIndex = 222
        Me.DefaultVal_lbl.Text = "Valeur par défaut"
        '
        'Typ_Retour_
        '
        Me.Typ_Retour_.AutoSize = True
        Me.Typ_Retour_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Retour_.Location = New System.Drawing.Point(48, 60)
        Me.Typ_Retour_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Typ_Retour_.Name = "Typ_Retour_"
        Me.Typ_Retour_.Size = New System.Drawing.Size(112, 19)
        Me.Typ_Retour_.TabIndex = 222
        Me.Typ_Retour_.Text = "Type de retour "
        '
        'RH_Param_Abaques
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(902, 739)
        Me.Controls.Add(Me.abaque_GRD)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Param_Abaques"
        Me.Tag = "ECR"
        Me.Text = "Paramètrage des abaques de calcul de la paie"
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.abaque_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Nb_Valeurs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nb_Clefs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents abaque_GRD As ud_Grd
    Friend WithEvents Abaque_lbl As System.Windows.Forms.LinkLabel
    Friend WithEvents Cod_Abaque_txt As ud_TextBox
    Friend WithEvents Lib_Abaque_txt As ud_TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Typ_Retour As ud_ComboBox
    Friend WithEvents Typ_Retour_ As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Nb_Valeurs As NumericUpDown
    Friend WithEvents Nb_Clefs As NumericUpDown
    Friend WithEvents Global_chk As ud_CheckBox
    Friend WithEvents callFunction_btn As ud_button
    Friend WithEvents DefaultVal_txt As ud_TextBox
    Friend WithEvents DefaultVal_lbl As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Constante_rd As ud_RadioBox
    Friend WithEvents fonction_rd As ud_RadioBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Clef_01 As DataGridViewTextBoxColumn
    Friend WithEvents Clef_02 As DataGridViewTextBoxColumn
    Friend WithEvents Clef_03 As DataGridViewTextBoxColumn
    Friend WithEvents Clef_04 As DataGridViewTextBoxColumn
    Friend WithEvents Valeur_01 As DataGridViewTextBoxColumn
    Friend WithEvents Valeur_02 As DataGridViewTextBoxColumn
    Friend WithEvents Valeur_03 As DataGridViewTextBoxColumn
    Friend WithEvents Valeur_04 As DataGridViewTextBoxColumn
    Friend WithEvents Flag As DataGridViewTextBoxColumn
    Friend WithEvents Variable_Paie_chk As ud_CheckBox
End Class
