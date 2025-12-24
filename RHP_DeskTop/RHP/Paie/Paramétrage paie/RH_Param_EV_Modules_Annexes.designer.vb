<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Param_EV_Modules_Annexes
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ev_GRD = New RHP.ud_Grd()
        Me.EV_lbl = New System.Windows.Forms.LinkLabel()
        Me.Cod_Rubrique_txt = New RHP.ud_TextBox()
        Me.Lib_EV_txt = New RHP.ud_TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Clause_Where_btn = New RHP.ud_button()
        Me.Table_Ref_btn = New RHP.ud_button()
        Me.Champs_Associe_btn = New RHP.ud_button()
        Me.Champs_Matricule_txt = New RHP.ud_TextBox()
        Me.Champs_Matricule_lbl = New System.Windows.Forms.LinkLabel()
        Me.estSysteme_chk = New RHP.ud_CheckBox()
        Me.Clause_Where_txt = New RHP.ud_TextBox()
        Me.Champs_Associe_lbl = New System.Windows.Forms.Label()
        Me.Clause_Where_lbl = New System.Windows.Forms.Label()
        Me.Adresse_ = New System.Windows.Forms.Label()
        Me.Actif_chk = New RHP.ud_CheckBox()
        Me.Global_chk = New RHP.ud_CheckBox()
        Me.Table_Ref_txt = New RHP.ud_TextBox()
        Me.Champs_Associe_txt = New RHP.ud_TextBox()
        Me.Cod_Rubrique = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_EV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Table_Ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estGlobale = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Actif = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.ev_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        'ev_GRD
        '
        Me.ev_GRD.AfficherLesEntetesLignes = True
        Me.ev_GRD.AllowUserToAddRows = False
        Me.ev_GRD.AllowUserToDeleteRows = False
        Me.ev_GRD.AllowUserToOrderColumns = True
        Me.ev_GRD.AlternerLesLignes = False
        Me.ev_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ev_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ev_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ev_GRD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ev_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ev_GRD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Rubrique, Me.Lib_EV, Me.Table_Ref, Me.estGlobale, Me.Actif})
        Me.ev_GRD.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ev_GRD.DefaultCellStyle = DataGridViewCellStyle2
        Me.ev_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ev_GRD.EnableHeadersVisualStyles = False
        Me.ev_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ev_GRD.Location = New System.Drawing.Point(0, 375)
        Me.ev_GRD.Name = "ev_GRD"
        Me.ev_GRD.ReadOnly = True
        Me.ev_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ev_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ev_GRD.RowHeadersWidth = 51
        Me.ev_GRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ev_GRD.Size = New System.Drawing.Size(973, 364)
        Me.ev_GRD.TabIndex = 3
        '
        'EV_lbl
        '
        Me.EV_lbl.AutoSize = True
        Me.EV_lbl.LinkColor = System.Drawing.Color.Black
        Me.EV_lbl.Location = New System.Drawing.Point(34, 22)
        Me.EV_lbl.Name = "EV_lbl"
        Me.EV_lbl.Size = New System.Drawing.Size(126, 19)
        Me.EV_lbl.TabIndex = 0
        Me.EV_lbl.TabStop = True
        Me.EV_lbl.Tag = ""
        Me.EV_lbl.Text = "Elément variable"
        '
        'Cod_Rubrique_txt
        '
        Me.Cod_Rubrique_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Rubrique_txt.ContextMenuStrip = Nothing
        Me.Cod_Rubrique_txt.Location = New System.Drawing.Point(164, 16)
        Me.Cod_Rubrique_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cod_Rubrique_txt.MaxLength = 50
        Me.Cod_Rubrique_txt.Multiline = False
        Me.Cod_Rubrique_txt.Name = "Cod_Rubrique_txt"
        Me.Cod_Rubrique_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Rubrique_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Rubrique_txt.ReadOnly = True
        Me.Cod_Rubrique_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Rubrique_txt.SelectionStart = 0
        Me.Cod_Rubrique_txt.Size = New System.Drawing.Size(186, 30)
        Me.Cod_Rubrique_txt.TabIndex = 71
        Me.Cod_Rubrique_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Rubrique_txt.UseSystemPasswordChar = False
        '
        'Lib_EV_txt
        '
        Me.Lib_EV_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_EV_txt.ContextMenuStrip = Nothing
        Me.Lib_EV_txt.Location = New System.Drawing.Point(358, 19)
        Me.Lib_EV_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Lib_EV_txt.MaxLength = 10000000
        Me.Lib_EV_txt.Multiline = False
        Me.Lib_EV_txt.Name = "Lib_EV_txt"
        Me.Lib_EV_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_EV_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_EV_txt.ReadOnly = False
        Me.Lib_EV_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_EV_txt.SelectionStart = 0
        Me.Lib_EV_txt.Size = New System.Drawing.Size(531, 27)
        Me.Lib_EV_txt.TabIndex = 72
        Me.Lib_EV_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_EV_txt.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Clause_Where_btn)
        Me.Panel1.Controls.Add(Me.Table_Ref_btn)
        Me.Panel1.Controls.Add(Me.Champs_Associe_btn)
        Me.Panel1.Controls.Add(Me.Champs_Matricule_txt)
        Me.Panel1.Controls.Add(Me.Champs_Matricule_lbl)
        Me.Panel1.Controls.Add(Me.estSysteme_chk)
        Me.Panel1.Controls.Add(Me.Clause_Where_txt)
        Me.Panel1.Controls.Add(Me.Champs_Associe_lbl)
        Me.Panel1.Controls.Add(Me.Clause_Where_lbl)
        Me.Panel1.Controls.Add(Me.Adresse_)
        Me.Panel1.Controls.Add(Me.Actif_chk)
        Me.Panel1.Controls.Add(Me.Global_chk)
        Me.Panel1.Controls.Add(Me.Cod_Rubrique_txt)
        Me.Panel1.Controls.Add(Me.EV_lbl)
        Me.Panel1.Controls.Add(Me.Table_Ref_txt)
        Me.Panel1.Controls.Add(Me.Champs_Associe_txt)
        Me.Panel1.Controls.Add(Me.Lib_EV_txt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(973, 375)
        Me.Panel1.TabIndex = 4
        '
        'Clause_Where_btn
        '
        Me.Clause_Where_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Clause_Where_btn.bgColor = System.Drawing.Color.White
        Me.Clause_Where_btn.Border = RHP.ud_button.BorderStyle.All
        Me.Clause_Where_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Clause_Where_btn.BorderSize = 2
        Me.Clause_Where_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Clause_Where_btn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Clause_Where_btn.Image = Nothing
        Me.Clause_Where_btn.isDefault = False
        Me.Clause_Where_btn.Location = New System.Drawing.Point(869, 143)
        Me.Clause_Where_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Clause_Where_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.Clause_Where_btn.Name = "Clause_Where_btn"
        Me.Clause_Where_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.Clause_Where_btn.Size = New System.Drawing.Size(40, 32)
        Me.Clause_Where_btn.TabIndex = 231
        Me.Clause_Where_btn.Text = "?"
        Me.Clause_Where_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Clause_Where_btn.ToolTip = "Insérer des variables préétablies"
        '
        'Table_Ref_btn
        '
        Me.Table_Ref_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Table_Ref_btn.bgColor = System.Drawing.Color.White
        Me.Table_Ref_btn.Border = RHP.ud_button.BorderStyle.All
        Me.Table_Ref_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Table_Ref_btn.BorderSize = 2
        Me.Table_Ref_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Table_Ref_btn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Table_Ref_btn.Image = Nothing
        Me.Table_Ref_btn.isDefault = False
        Me.Table_Ref_btn.Location = New System.Drawing.Point(869, 98)
        Me.Table_Ref_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Table_Ref_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.Table_Ref_btn.Name = "Table_Ref_btn"
        Me.Table_Ref_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.Table_Ref_btn.Size = New System.Drawing.Size(40, 32)
        Me.Table_Ref_btn.TabIndex = 231
        Me.Table_Ref_btn.Text = "?"
        Me.Table_Ref_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Table_Ref_btn.ToolTip = "Insérer des variables préétablies"
        '
        'Champs_Associe_btn
        '
        Me.Champs_Associe_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Champs_Associe_btn.bgColor = System.Drawing.Color.White
        Me.Champs_Associe_btn.Border = RHP.ud_button.BorderStyle.All
        Me.Champs_Associe_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Champs_Associe_btn.BorderSize = 2
        Me.Champs_Associe_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Champs_Associe_btn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Champs_Associe_btn.Image = Nothing
        Me.Champs_Associe_btn.isDefault = False
        Me.Champs_Associe_btn.Location = New System.Drawing.Point(869, 50)
        Me.Champs_Associe_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Champs_Associe_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.Champs_Associe_btn.Name = "Champs_Associe_btn"
        Me.Champs_Associe_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.Champs_Associe_btn.Size = New System.Drawing.Size(40, 32)
        Me.Champs_Associe_btn.TabIndex = 231
        Me.Champs_Associe_btn.Text = "?"
        Me.Champs_Associe_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Champs_Associe_btn.ToolTip = "Insérer des variables préétablies"
        '
        'Champs_Matricule_txt
        '
        Me.Champs_Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Champs_Matricule_txt.ContextMenuStrip = Nothing
        Me.Champs_Matricule_txt.Location = New System.Drawing.Point(164, 266)
        Me.Champs_Matricule_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Champs_Matricule_txt.MaxLength = 50
        Me.Champs_Matricule_txt.Multiline = False
        Me.Champs_Matricule_txt.Name = "Champs_Matricule_txt"
        Me.Champs_Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Champs_Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Champs_Matricule_txt.ReadOnly = True
        Me.Champs_Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Champs_Matricule_txt.SelectionStart = 0
        Me.Champs_Matricule_txt.Size = New System.Drawing.Size(186, 36)
        Me.Champs_Matricule_txt.TabIndex = 230
        Me.Champs_Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Champs_Matricule_txt.UseSystemPasswordChar = False
        '
        'Champs_Matricule_lbl
        '
        Me.Champs_Matricule_lbl.AutoSize = True
        Me.Champs_Matricule_lbl.LinkColor = System.Drawing.Color.Black
        Me.Champs_Matricule_lbl.Location = New System.Drawing.Point(26, 271)
        Me.Champs_Matricule_lbl.Name = "Champs_Matricule_lbl"
        Me.Champs_Matricule_lbl.Size = New System.Drawing.Size(136, 19)
        Me.Champs_Matricule_lbl.TabIndex = 229
        Me.Champs_Matricule_lbl.TabStop = True
        Me.Champs_Matricule_lbl.Tag = ""
        Me.Champs_Matricule_lbl.Text = "Champs matricule"
        '
        'estSysteme_chk
        '
        Me.estSysteme_chk.AutoSize = True
        Me.estSysteme_chk.Checked = False
        Me.estSysteme_chk.Location = New System.Drawing.Point(755, 326)
        Me.estSysteme_chk.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.estSysteme_chk.MaximumSize = New System.Drawing.Size(0, 36)
        Me.estSysteme_chk.MinimumSize = New System.Drawing.Size(133, 36)
        Me.estSysteme_chk.Name = "estSysteme_chk"
        Me.estSysteme_chk.Size = New System.Drawing.Size(133, 36)
        Me.estSysteme_chk.TabIndex = 228
        Me.estSysteme_chk.Text = "Système"
        '
        'Clause_Where_txt
        '
        Me.Clause_Where_txt.AutoSize = True
        Me.Clause_Where_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Clause_Where_txt.ContextMenuStrip = Nothing
        Me.Clause_Where_txt.Location = New System.Drawing.Point(164, 143)
        Me.Clause_Where_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Clause_Where_txt.MaxLength = 10000000
        Me.Clause_Where_txt.Multiline = True
        Me.Clause_Where_txt.Name = "Clause_Where_txt"
        Me.Clause_Where_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Clause_Where_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Clause_Where_txt.ReadOnly = False
        Me.Clause_Where_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Clause_Where_txt.SelectionStart = 0
        Me.Clause_Where_txt.Size = New System.Drawing.Size(697, 117)
        Me.Clause_Where_txt.TabIndex = 227
        Me.Clause_Where_txt.Tag = "NC"
        Me.Clause_Where_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Clause_Where_txt.UseSystemPasswordChar = False
        '
        'Champs_Associe_lbl
        '
        Me.Champs_Associe_lbl.AutoSize = True
        Me.Champs_Associe_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Champs_Associe_lbl.Location = New System.Drawing.Point(41, 59)
        Me.Champs_Associe_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Champs_Associe_lbl.Name = "Champs_Associe_lbl"
        Me.Champs_Associe_lbl.Size = New System.Drawing.Size(121, 19)
        Me.Champs_Associe_lbl.TabIndex = 226
        Me.Champs_Associe_lbl.Text = "Champs associé"
        '
        'Clause_Where_lbl
        '
        Me.Clause_Where_lbl.AutoSize = True
        Me.Clause_Where_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Clause_Where_lbl.Location = New System.Drawing.Point(120, 143)
        Me.Clause_Where_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Clause_Where_lbl.Name = "Clause_Where_lbl"
        Me.Clause_Where_lbl.Size = New System.Drawing.Size(40, 19)
        Me.Clause_Where_lbl.TabIndex = 226
        Me.Clause_Where_lbl.Text = "Filtre"
        '
        'Adresse_
        '
        Me.Adresse_.AutoSize = True
        Me.Adresse_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Adresse_.Location = New System.Drawing.Point(51, 98)
        Me.Adresse_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Adresse_.Name = "Adresse_"
        Me.Adresse_.Size = New System.Drawing.Size(109, 19)
        Me.Adresse_.TabIndex = 226
        Me.Adresse_.Text = "Table associée"
        '
        'Actif_chk
        '
        Me.Actif_chk.AutoSize = True
        Me.Actif_chk.Checked = True
        Me.Actif_chk.Location = New System.Drawing.Point(444, 326)
        Me.Actif_chk.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Actif_chk.MaximumSize = New System.Drawing.Size(0, 36)
        Me.Actif_chk.MinimumSize = New System.Drawing.Size(133, 36)
        Me.Actif_chk.Name = "Actif_chk"
        Me.Actif_chk.Size = New System.Drawing.Size(133, 36)
        Me.Actif_chk.TabIndex = 225
        Me.Actif_chk.Text = "Actif"
        '
        'Global_chk
        '
        Me.Global_chk.AutoSize = True
        Me.Global_chk.Checked = False
        Me.Global_chk.Location = New System.Drawing.Point(164, 326)
        Me.Global_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Global_chk.MaximumSize = New System.Drawing.Size(0, 30)
        Me.Global_chk.MinimumSize = New System.Drawing.Size(133, 30)
        Me.Global_chk.Name = "Global_chk"
        Me.Global_chk.Size = New System.Drawing.Size(133, 30)
        Me.Global_chk.TabIndex = 225
        Me.Global_chk.Text = "Global"
        '
        'Table_Ref_txt
        '
        Me.Table_Ref_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Table_Ref_txt.ContextMenuStrip = Nothing
        Me.Table_Ref_txt.Location = New System.Drawing.Point(164, 93)
        Me.Table_Ref_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Table_Ref_txt.MaxLength = 10000000
        Me.Table_Ref_txt.Multiline = False
        Me.Table_Ref_txt.Name = "Table_Ref_txt"
        Me.Table_Ref_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Table_Ref_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Table_Ref_txt.ReadOnly = False
        Me.Table_Ref_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Table_Ref_txt.SelectionStart = 0
        Me.Table_Ref_txt.Size = New System.Drawing.Size(697, 38)
        Me.Table_Ref_txt.TabIndex = 72
        Me.Table_Ref_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Table_Ref_txt.UseSystemPasswordChar = False
        '
        'Champs_Associe_txt
        '
        Me.Champs_Associe_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Champs_Associe_txt.ContextMenuStrip = Nothing
        Me.Champs_Associe_txt.Location = New System.Drawing.Point(164, 54)
        Me.Champs_Associe_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Champs_Associe_txt.MaxLength = 10000000
        Me.Champs_Associe_txt.Multiline = False
        Me.Champs_Associe_txt.Name = "Champs_Associe_txt"
        Me.Champs_Associe_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Champs_Associe_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Champs_Associe_txt.ReadOnly = False
        Me.Champs_Associe_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Champs_Associe_txt.SelectionStart = 0
        Me.Champs_Associe_txt.Size = New System.Drawing.Size(697, 32)
        Me.Champs_Associe_txt.TabIndex = 72
        Me.Champs_Associe_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Champs_Associe_txt.UseSystemPasswordChar = False
        '
        'Cod_Rubrique
        '
        Me.Cod_Rubrique.HeaderText = "Elément variable"
        Me.Cod_Rubrique.MinimumWidth = 200
        Me.Cod_Rubrique.Name = "Cod_Rubrique"
        Me.Cod_Rubrique.ReadOnly = True
        Me.Cod_Rubrique.Width = 200
        '
        'Lib_EV
        '
        Me.Lib_EV.HeaderText = "Libellé"
        Me.Lib_EV.MinimumWidth = 300
        Me.Lib_EV.Name = "Lib_EV"
        Me.Lib_EV.ReadOnly = True
        Me.Lib_EV.Width = 300
        '
        'Table_Ref
        '
        Me.Table_Ref.HeaderText = "Table"
        Me.Table_Ref.MinimumWidth = 200
        Me.Table_Ref.Name = "Table_Ref"
        Me.Table_Ref.ReadOnly = True
        Me.Table_Ref.Width = 200
        '
        'estGlobale
        '
        Me.estGlobale.HeaderText = "Globale"
        Me.estGlobale.MinimumWidth = 6
        Me.estGlobale.Name = "estGlobale"
        Me.estGlobale.ReadOnly = True
        Me.estGlobale.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.estGlobale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.estGlobale.Width = 125
        '
        'Actif
        '
        Me.Actif.HeaderText = "Actif"
        Me.Actif.MinimumWidth = 6
        Me.Actif.Name = "Actif"
        Me.Actif.ReadOnly = True
        Me.Actif.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Actif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Actif.Width = 125
        '
        'RH_Param_EV_Modules_Annexes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(973, 739)
        Me.Controls.Add(Me.ev_GRD)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Param_EV_Modules_Annexes"
        Me.Tag = "ECR"
        Me.Text = "Paramètrage des éléments variables provenant des modules annexes"
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.ev_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ev_GRD As ud_Grd
    Friend WithEvents EV_lbl As System.Windows.Forms.LinkLabel
    Friend WithEvents Cod_Rubrique_txt As ud_TextBox
    Friend WithEvents Lib_EV_txt As ud_TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Global_chk As ud_CheckBox
    Friend WithEvents Clause_Where_txt As ud_TextBox
    Friend WithEvents Adresse_ As Label
    Friend WithEvents Champs_Associe_txt As ud_TextBox
    Friend WithEvents Champs_Associe_lbl As Label
    Friend WithEvents Clause_Where_lbl As Label
    Friend WithEvents Table_Ref_txt As ud_TextBox
    Friend WithEvents estSysteme_chk As ud_CheckBox
    Friend WithEvents Actif_chk As ud_CheckBox
    Friend WithEvents Champs_Matricule_txt As ud_TextBox
    Friend WithEvents Champs_Matricule_lbl As LinkLabel
    Friend WithEvents Champs_Associe_btn As ud_button
    Friend WithEvents Clause_Where_btn As ud_button
    Friend WithEvents Table_Ref_btn As ud_button
    Friend WithEvents Cod_Rubrique As DataGridViewTextBoxColumn
    Friend WithEvents Lib_EV As DataGridViewTextBoxColumn
    Friend WithEvents Table_Ref As DataGridViewTextBoxColumn
    Friend WithEvents estGlobale As DataGridViewCheckBoxColumn
    Friend WithEvents Actif As DataGridViewCheckBoxColumn
End Class
