<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Evaluation_Liste
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grille = New RHP.ud_Grd()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.SEL_CRT_GROUP = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rd2 = New RHP.ud_RadioBox()
        Me.Rd1 = New RHP.ud_RadioBox()
        Me.Rd0 = New RHP.ud_RadioBox()
        Me.Cod_Evaluation_txt = New RHP.ud_TextBox()
        Me.Lib_Evaluation_txt = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Evalue_txt = New RHP.ud_TextBox()
        Me.Nom_Evalue_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Statut_Evaluation = New RHP.ud_ComboBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Evaluateur_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Evaluateur = New System.Windows.Forms.LinkLabel()
        Me.Dat_Au = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dat_Du = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Grade_ = New System.Windows.Forms.LinkLabel()
        Me.Cod_Grade_txt = New RHP.ud_TextBox()
        Me.Lib_Grade_txt = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Personnal_pnl.SuspendLayout()
        Me.SEL_CRT_GROUP.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grille
        '
        Me.Grille.AfficherLesEntetesLignes = True
        Me.Grille.AllowUserToAddRows = False
        Me.Grille.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grille.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grille.AlternerLesLignes = False
        Me.Grille.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grille.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grille.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grille.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grille.EnableHeadersVisualStyles = False
        Me.Grille.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grille.Location = New System.Drawing.Point(0, 232)
        Me.Grille.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grille.Name = "Grille"
        Me.Grille.ReadOnly = True
        Me.Grille.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grille.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grille.RowHeadersWidth = 51
        Me.Grille.Size = New System.Drawing.Size(1225, 529)
        Me.Grille.TabIndex = 2
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
        'SEL_CRT_GROUP
        '
        Me.SEL_CRT_GROUP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SEL_CRT_GROUP.Controls.Add(Me.GroupBox1)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Cod_Evaluation_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Lib_Evaluation_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel4)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Evalue_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Nom_Evalue_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel3)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Statut_Evaluation)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel1)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Evaluateur_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Nom_Agent_Text)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Evaluateur)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Au)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Label5)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Du)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Label4)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Grade_)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Cod_Grade_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Lib_Grade_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Lib_Entite_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Cod_Entite_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel2)
        Me.SEL_CRT_GROUP.Dock = System.Windows.Forms.DockStyle.Top
        Me.SEL_CRT_GROUP.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.SEL_CRT_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.SEL_CRT_GROUP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SEL_CRT_GROUP.Name = "SEL_CRT_GROUP"
        Me.SEL_CRT_GROUP.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SEL_CRT_GROUP.Size = New System.Drawing.Size(1225, 232)
        Me.SEL_CRT_GROUP.TabIndex = 0
        Me.SEL_CRT_GROUP.TabStop = False
        Me.SEL_CRT_GROUP.Tag = "Critères de sélection"
        Me.SEL_CRT_GROUP.Text = "Critères de sélection"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rd2)
        Me.GroupBox1.Controls.Add(Me.Rd1)
        Me.GroupBox1.Controls.Add(Me.Rd0)
        Me.GroupBox1.Location = New System.Drawing.Point(710, 36)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(228, 131)
        Me.GroupBox1.TabIndex = 248
        Me.GroupBox1.TabStop = False
        '
        'Rd2
        '
        Me.Rd2.AutoSize = True
        Me.Rd2.Checked = False
        Me.Rd2.Location = New System.Drawing.Point(15, 89)
        Me.Rd2.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Rd2.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd2.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd2.Name = "Rd2"
        Me.Rd2.Size = New System.Drawing.Size(150, 31)
        Me.Rd2.TabIndex = 247
        Me.Rd2.Text = "Que les évalués"
        '
        'Rd1
        '
        Me.Rd1.AutoSize = True
        Me.Rd1.Checked = False
        Me.Rd1.Location = New System.Drawing.Point(15, 59)
        Me.Rd1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Rd1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd1.Name = "Rd1"
        Me.Rd1.Size = New System.Drawing.Size(181, 31)
        Me.Rd1.TabIndex = 247
        Me.Rd1.Text = "Que les non évalués"
        '
        'Rd0
        '
        Me.Rd0.AutoSize = True
        Me.Rd0.Checked = True
        Me.Rd0.Location = New System.Drawing.Point(15, 29)
        Me.Rd0.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Rd0.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd0.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd0.Name = "Rd0"
        Me.Rd0.Size = New System.Drawing.Size(142, 31)
        Me.Rd0.TabIndex = 247
        Me.Rd0.Text = "Tout"
        '
        'Cod_Evaluation_txt
        '
        Me.Cod_Evaluation_txt.AccessibleDescription = "A"
        Me.Cod_Evaluation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Evaluation_txt.ContextMenuStrip = Nothing
        Me.Cod_Evaluation_txt.Location = New System.Drawing.Point(139, 182)
        Me.Cod_Evaluation_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Cod_Evaluation_txt.MaxLength = 32767
        Me.Cod_Evaluation_txt.Multiline = False
        Me.Cod_Evaluation_txt.Name = "Cod_Evaluation_txt"
        Me.Cod_Evaluation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Evaluation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Evaluation_txt.ReadOnly = True
        Me.Cod_Evaluation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Evaluation_txt.SelectionStart = 0
        Me.Cod_Evaluation_txt.Size = New System.Drawing.Size(130, 26)
        Me.Cod_Evaluation_txt.TabIndex = 244
        Me.Cod_Evaluation_txt.TabStop = False
        Me.Cod_Evaluation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Evaluation_txt.UseSystemPasswordChar = False
        '
        'Lib_Evaluation_txt
        '
        Me.Lib_Evaluation_txt.AccessibleDescription = "A"
        Me.Lib_Evaluation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Evaluation_txt.ContextMenuStrip = Nothing
        Me.Lib_Evaluation_txt.Location = New System.Drawing.Point(271, 182)
        Me.Lib_Evaluation_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Lib_Evaluation_txt.MaxLength = 32767
        Me.Lib_Evaluation_txt.Multiline = False
        Me.Lib_Evaluation_txt.Name = "Lib_Evaluation_txt"
        Me.Lib_Evaluation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Evaluation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Evaluation_txt.ReadOnly = False
        Me.Lib_Evaluation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Evaluation_txt.SelectionStart = 0
        Me.Lib_Evaluation_txt.Size = New System.Drawing.Size(421, 26)
        Me.Lib_Evaluation_txt.TabIndex = 246
        Me.Lib_Evaluation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Evaluation_txt.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(50, 186)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(83, 19)
        Me.LinkLabel4.TabIndex = 245
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Evaluation"
        '
        'Evalue_txt
        '
        Me.Evalue_txt.AccessibleDescription = "A"
        Me.Evalue_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Evalue_txt.ContextMenuStrip = Nothing
        Me.Evalue_txt.Location = New System.Drawing.Point(139, 56)
        Me.Evalue_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Evalue_txt.MaxLength = 32767
        Me.Evalue_txt.Multiline = False
        Me.Evalue_txt.Name = "Evalue_txt"
        Me.Evalue_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Evalue_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Evalue_txt.ReadOnly = True
        Me.Evalue_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Evalue_txt.SelectionStart = 0
        Me.Evalue_txt.Size = New System.Drawing.Size(130, 26)
        Me.Evalue_txt.TabIndex = 241
        Me.Evalue_txt.TabStop = False
        Me.Evalue_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Evalue_txt.UseSystemPasswordChar = False
        '
        'Nom_Evalue_txt
        '
        Me.Nom_Evalue_txt.AccessibleDescription = "A"
        Me.Nom_Evalue_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Evalue_txt.ContextMenuStrip = Nothing
        Me.Nom_Evalue_txt.Location = New System.Drawing.Point(271, 56)
        Me.Nom_Evalue_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Nom_Evalue_txt.MaxLength = 32767
        Me.Nom_Evalue_txt.Multiline = False
        Me.Nom_Evalue_txt.Name = "Nom_Evalue_txt"
        Me.Nom_Evalue_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Evalue_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Evalue_txt.ReadOnly = False
        Me.Nom_Evalue_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Evalue_txt.SelectionStart = 0
        Me.Nom_Evalue_txt.Size = New System.Drawing.Size(421, 26)
        Me.Nom_Evalue_txt.TabIndex = 243
        Me.Nom_Evalue_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Evalue_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(78, 60)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(56, 19)
        Me.LinkLabel3.TabIndex = 242
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = ""
        Me.LinkLabel3.Text = "Evalué"
        '
        'Statut_Evaluation
        '
        Me.Statut_Evaluation.DataSource = Nothing
        Me.Statut_Evaluation.DisplayMember = ""
        Me.Statut_Evaluation.DroppedDown = False
        Me.Statut_Evaluation.Location = New System.Drawing.Point(139, 148)
        Me.Statut_Evaluation.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Statut_Evaluation.Name = "Statut_Evaluation"
        Me.Statut_Evaluation.SelectedIndex = -1
        Me.Statut_Evaluation.SelectedItem = Nothing
        Me.Statut_Evaluation.SelectedValue = Nothing
        Me.Statut_Evaluation.Size = New System.Drawing.Size(202, 30)
        Me.Statut_Evaluation.TabIndex = 240
        Me.Statut_Evaluation.ValueMember = ""
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(65, 152)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(69, 19)
        Me.LinkLabel1.TabIndex = 239
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Situation"
        '
        'Evaluateur_txt
        '
        Me.Evaluateur_txt.AccessibleDescription = "A"
        Me.Evaluateur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Evaluateur_txt.ContextMenuStrip = Nothing
        Me.Evaluateur_txt.Location = New System.Drawing.Point(139, 26)
        Me.Evaluateur_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Evaluateur_txt.MaxLength = 32767
        Me.Evaluateur_txt.Multiline = False
        Me.Evaluateur_txt.Name = "Evaluateur_txt"
        Me.Evaluateur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Evaluateur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Evaluateur_txt.ReadOnly = True
        Me.Evaluateur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Evaluateur_txt.SelectionStart = 0
        Me.Evaluateur_txt.Size = New System.Drawing.Size(130, 26)
        Me.Evaluateur_txt.TabIndex = 236
        Me.Evaluateur_txt.TabStop = False
        Me.Evaluateur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Evaluateur_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(271, 26)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = False
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(421, 26)
        Me.Nom_Agent_Text.TabIndex = 238
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Evaluateur
        '
        Me.Evaluateur.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Evaluateur.AutoSize = True
        Me.Evaluateur.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Evaluateur.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Evaluateur.Location = New System.Drawing.Point(50, 29)
        Me.Evaluateur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Evaluateur.Name = "Evaluateur"
        Me.Evaluateur.Size = New System.Drawing.Size(84, 19)
        Me.Evaluateur.TabIndex = 237
        Me.Evaluateur.TabStop = True
        Me.Evaluateur.Tag = "SC"
        Me.Evaluateur.Text = "Evaluateur"
        '
        'Dat_Au
        '
        Me.Dat_Au.CustomFormat = "dd/MM/yyyy"
        Me.Dat_Au.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dat_Au.Location = New System.Drawing.Point(571, 148)
        Me.Dat_Au.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Au.Name = "Dat_Au"
        Me.Dat_Au.Size = New System.Drawing.Size(120, 24)
        Me.Dat_Au.TabIndex = 234
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(541, 151)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 19)
        Me.Label5.TabIndex = 235
        Me.Label5.Text = "Au"
        '
        'Dat_Du
        '
        Me.Dat_Du.CustomFormat = "dd/MM/yyyy"
        Me.Dat_Du.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dat_Du.Location = New System.Drawing.Point(412, 148)
        Me.Dat_Du.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Du.Name = "Dat_Du"
        Me.Dat_Du.Size = New System.Drawing.Size(119, 24)
        Me.Dat_Du.TabIndex = 233
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(381, 151)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 19)
        Me.Label4.TabIndex = 232
        Me.Label4.Text = "Du"
        '
        'Grade_
        '
        Me.Grade_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.AutoSize = True
        Me.Grade_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Location = New System.Drawing.Point(79, 120)
        Me.Grade_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Grade_.Name = "Grade_"
        Me.Grade_.Size = New System.Drawing.Size(54, 19)
        Me.Grade_.TabIndex = 229
        Me.Grade_.TabStop = True
        Me.Grade_.Tag = ""
        Me.Grade_.Text = "Grade"
        '
        'Cod_Grade_txt
        '
        Me.Cod_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Grade_txt.ContextMenuStrip = Nothing
        Me.Cod_Grade_txt.Location = New System.Drawing.Point(139, 116)
        Me.Cod_Grade_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Cod_Grade_txt.MaxLength = 6
        Me.Cod_Grade_txt.Multiline = False
        Me.Cod_Grade_txt.Name = "Cod_Grade_txt"
        Me.Cod_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Grade_txt.ReadOnly = True
        Me.Cod_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Grade_txt.SelectionStart = 0
        Me.Cod_Grade_txt.Size = New System.Drawing.Size(130, 26)
        Me.Cod_Grade_txt.TabIndex = 231
        Me.Cod_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Grade_txt.UseSystemPasswordChar = False
        '
        'Lib_Grade_txt
        '
        Me.Lib_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_txt.ContextMenuStrip = Nothing
        Me.Lib_Grade_txt.Location = New System.Drawing.Point(271, 116)
        Me.Lib_Grade_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Lib_Grade_txt.MaxLength = 50
        Me.Lib_Grade_txt.Multiline = False
        Me.Lib_Grade_txt.Name = "Lib_Grade_txt"
        Me.Lib_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_txt.ReadOnly = True
        Me.Lib_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_txt.SelectionStart = 0
        Me.Lib_Grade_txt.Size = New System.Drawing.Size(421, 26)
        Me.Lib_Grade_txt.TabIndex = 230
        Me.Lib_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_txt.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(271, 86)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Entite_txt.MaxLength = 32767
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(421, 26)
        Me.Lib_Entite_txt.TabIndex = 226
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(139, 86)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Entite_txt.MaxLength = 32767
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(130, 26)
        Me.Cod_Entite_txt.TabIndex = 227
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(18, 90)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(118, 19)
        Me.LinkLabel2.TabIndex = 228
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = ""
        Me.LinkLabel2.Text = "Entité à évaluer"
        '
        'Evaluation_Liste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1225, 761)
        Me.Controls.Add(Me.Grille)
        Me.Controls.Add(Me.SEL_CRT_GROUP)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Evaluation_Liste"
        Me.Tag = "ECR"
        Me.Text = "Liste des évaluations"
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Personnal_pnl.ResumeLayout(False)
        Me.SEL_CRT_GROUP.ResumeLayout(False)
        Me.SEL_CRT_GROUP.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Grille As ud_Grd
    Friend WithEvents SEL_CRT_GROUP As GroupBox
    Friend WithEvents Grade_ As LinkLabel
    Friend WithEvents Cod_Grade_txt As ud_TextBox
    Friend WithEvents Lib_Grade_txt As ud_TextBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Dat_Au As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Dat_Du As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Evaluateur_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Evaluateur As LinkLabel
    Friend WithEvents Statut_Evaluation As ud_ComboBox
    Friend WithEvents Cod_Evaluation_txt As ud_TextBox
    Friend WithEvents Lib_Evaluation_txt As ud_TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Evalue_txt As ud_TextBox
    Friend WithEvents Nom_Evalue_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Rd2 As ud_RadioBox
    Friend WithEvents Rd1 As ud_RadioBox
    Friend WithEvents Rd0 As ud_RadioBox
End Class
