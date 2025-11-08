<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formation
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
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Statut_Formation = New RHP.ud_ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.SuperTabControlPanel1 = New System.Windows.Forms.TabPage()
        Me.Grd_Domaines_Competences = New RHP.ud_Grd()
        Me.Domaine_Competence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Domaine_Competence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Formation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Typ_Formation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Msg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk = New RHP.ud_RadioBox()
        Me.Lib_Survey_txt = New RHP.ud_TextBox()
        Me.Cod_Survey_txt = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Rd_Nature_Formation_2 = New RHP.ud_RadioBox()
        Me.Rd_Nature_Formation_1 = New RHP.ud_RadioBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lieu_txt = New RHP.ud_TextBox()
        Me.Rd_Typ_Lieu_3 = New RHP.ud_RadioBox()
        Me.Rd_Typ_Lieu_2 = New RHP.ud_RadioBox()
        Me.Rd_Typ_Lieu_1 = New RHP.ud_RadioBox()
        Me.Lib_Cod_Formateur_txt = New RHP.ud_TextBox()
        Me.Cod_Formateur_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Cod_Cabinet_txt = New RHP.ud_TextBox()
        Me.Cod_Cabinet_txt = New RHP.ud_TextBox()
        Me.CodCabinet = New System.Windows.Forms.LinkLabel()
        Me.Dat_Au = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dat_Du = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Budget_txt = New RHP.ud_TextBox()
        Me.Formation_Planifiee_chk = New RHP.ud_CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Genre_Formation = New RHP.ud_ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuperTabControlPanel3 = New System.Windows.Forms.TabPage()
        Me.Contenu_rtb = New RHP.ud_RT()
        Me.SuperTabControlPanel2 = New System.Windows.Forms.TabPage()
        Me.Grd_Participants = New RHP.ud_Grd()
        Me.Matricule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Present = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Evaluation = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SuperTabControlPanel4 = New System.Windows.Forms.TabPage()
        Me.Grd_Organismes = New RHP.ud_Grd()
        Me.Organisme = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Montant = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Lib_Action_Formation_txt = New RHP.ud_TextBox()
        Me.Action_Formation_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Formation_txt = New RHP.ud_TextBox()
        Me.Cod_Formation_txt = New RHP.ud_TextBox()
        Me.Cod_Fou_LINK = New System.Windows.Forms.LinkLabel()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.Grd_Domaines_Competences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.Grd_Participants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.Grd_Organismes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Statut_Formation
        '
        Me.Statut_Formation.DataSource = Nothing
        Me.Statut_Formation.DisplayMember = ""
        Me.Statut_Formation.DroppedDown = False
        Me.Statut_Formation.Enabled = False
        Me.Statut_Formation.Location = New System.Drawing.Point(940, 15)
        Me.Statut_Formation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Statut_Formation.Name = "Statut_Formation"
        Me.Statut_Formation.SelectedIndex = -1
        Me.Statut_Formation.SelectedItem = Nothing
        Me.Statut_Formation.SelectedValue = Nothing
        Me.Statut_Formation.Size = New System.Drawing.Size(190, 32)
        Me.Statut_Formation.TabIndex = 16
        Me.Statut_Formation.ValueMember = ""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.TabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.TabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.TabControl1.Controls.Add(Me.SuperTabControlPanel4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 89)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1250, 643)
        Me.TabControl1.TabIndex = 210
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Grd_Domaines_Competences)
        Me.SuperTabControlPanel1.Controls.Add(Me.Pnl)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(4, 28)
        Me.SuperTabControlPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1242, 611)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.Text = "Descriptif de la formation"
        '
        'Grd_Domaines_Competences
        '
        Me.Grd_Domaines_Competences.AfficherLesEntetesLignes = True
        Me.Grd_Domaines_Competences.AlternerLesLignes = False
        Me.Grd_Domaines_Competences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Domaines_Competences.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Domaines_Competences.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd_Domaines_Competences.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Domaines_Competences.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Domaines_Competences.ColumnHeadersHeight = 30
        Me.Grd_Domaines_Competences.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Domaine_Competence, Me.Lib_Domaine_Competence, Me.Typ_Formation, Me.Lib_Typ_Formation, Me.RowId, Me.Msg})
        Me.Grd_Domaines_Competences.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Domaines_Competences.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Domaines_Competences.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Domaines_Competences.EnableHeadersVisualStyles = False
        Me.Grd_Domaines_Competences.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Domaines_Competences.Location = New System.Drawing.Point(0, 376)
        Me.Grd_Domaines_Competences.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Domaines_Competences.Name = "Grd_Domaines_Competences"
        Me.Grd_Domaines_Competences.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Domaines_Competences.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Domaines_Competences.RowHeadersWidth = 51
        Me.Grd_Domaines_Competences.Size = New System.Drawing.Size(1242, 235)
        Me.Grd_Domaines_Competences.TabIndex = 221
        '
        'Domaine_Competence
        '
        Me.Domaine_Competence.HeaderText = "Domaine_Competence"
        Me.Domaine_Competence.MinimumWidth = 6
        Me.Domaine_Competence.Name = "Domaine_Competence"
        Me.Domaine_Competence.ReadOnly = True
        Me.Domaine_Competence.Visible = False
        Me.Domaine_Competence.Width = 210
        '
        'Lib_Domaine_Competence
        '
        Me.Lib_Domaine_Competence.HeaderText = "Domaines de compétence"
        Me.Lib_Domaine_Competence.MinimumWidth = 6
        Me.Lib_Domaine_Competence.Name = "Lib_Domaine_Competence"
        Me.Lib_Domaine_Competence.ReadOnly = True
        Me.Lib_Domaine_Competence.Width = 233
        '
        'Typ_Formation
        '
        Me.Typ_Formation.HeaderText = "Typ_Formation"
        Me.Typ_Formation.MinimumWidth = 6
        Me.Typ_Formation.Name = "Typ_Formation"
        Me.Typ_Formation.ReadOnly = True
        Me.Typ_Formation.Visible = False
        Me.Typ_Formation.Width = 146
        '
        'Lib_Typ_Formation
        '
        Me.Lib_Typ_Formation.HeaderText = "Type de formation"
        Me.Lib_Typ_Formation.MaxInputLength = 499
        Me.Lib_Typ_Formation.MinimumWidth = 250
        Me.Lib_Typ_Formation.Name = "Lib_Typ_Formation"
        Me.Lib_Typ_Formation.ReadOnly = True
        Me.Lib_Typ_Formation.Width = 250
        '
        'RowId
        '
        Me.RowId.HeaderText = "RowId"
        Me.RowId.MinimumWidth = 6
        Me.RowId.Name = "RowId"
        Me.RowId.Visible = False
        Me.RowId.Width = 90
        '
        'Msg
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Msg.DefaultCellStyle = DataGridViewCellStyle2
        Me.Msg.HeaderText = "Message"
        Me.Msg.MinimumWidth = 6
        Me.Msg.Name = "Msg"
        Me.Msg.ReadOnly = True
        Me.Msg.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Msg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Msg.Width = 84
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Panel1)
        Me.Pnl.Controls.Add(Me.Statut_Formation)
        Me.Pnl.Controls.Add(Me.Lib_Survey_txt)
        Me.Pnl.Controls.Add(Me.Cod_Survey_txt)
        Me.Pnl.Controls.Add(Me.LinkLabel2)
        Me.Pnl.Controls.Add(Me.Rd_Nature_Formation_2)
        Me.Pnl.Controls.Add(Me.Rd_Nature_Formation_1)
        Me.Pnl.Controls.Add(Me.GroupBox1)
        Me.Pnl.Controls.Add(Me.Lib_Cod_Formateur_txt)
        Me.Pnl.Controls.Add(Me.Cod_Formateur_txt)
        Me.Pnl.Controls.Add(Me.LinkLabel3)
        Me.Pnl.Controls.Add(Me.Lib_Cod_Cabinet_txt)
        Me.Pnl.Controls.Add(Me.Cod_Cabinet_txt)
        Me.Pnl.Controls.Add(Me.CodCabinet)
        Me.Pnl.Controls.Add(Me.Dat_Au)
        Me.Pnl.Controls.Add(Me.Label5)
        Me.Pnl.Controls.Add(Me.Dat_Du)
        Me.Pnl.Controls.Add(Me.Label3)
        Me.Pnl.Controls.Add(Me.Budget_txt)
        Me.Pnl.Controls.Add(Me.Formation_Planifiee_chk)
        Me.Pnl.Controls.Add(Me.Label4)
        Me.Pnl.Controls.Add(Me.Genre_Formation)
        Me.Pnl.Controls.Add(Me.Label1)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl.Location = New System.Drawing.Point(0, 0)
        Me.Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(1242, 376)
        Me.Pnl.TabIndex = 0
        '
        'ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk
        '
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.AutoSize = True
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.Checked = False
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.Location = New System.Drawing.Point(42, 15)
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.MaximumSize = New System.Drawing.Size(0, 30)
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.MinimumSize = New System.Drawing.Size(0, 30)
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.Name = "ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk"
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.Size = New System.Drawing.Size(765, 30)
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.TabIndex = 209
        Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.Text = "Proposer uniquement les domaines de compétence por lesquels le cabinet ou formate" &
    "ur sont accrédités."
        '
        'Lib_Survey_txt
        '
        Me.Lib_Survey_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Survey_txt.ContextMenuStrip = Nothing
        Me.Lib_Survey_txt.Location = New System.Drawing.Point(366, 282)
        Me.Lib_Survey_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Lib_Survey_txt.MaxLength = 50
        Me.Lib_Survey_txt.Multiline = False
        Me.Lib_Survey_txt.Name = "Lib_Survey_txt"
        Me.Lib_Survey_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Survey_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Survey_txt.ReadOnly = True
        Me.Lib_Survey_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Survey_txt.SelectionStart = 0
        Me.Lib_Survey_txt.Size = New System.Drawing.Size(501, 26)
        Me.Lib_Survey_txt.TabIndex = 207
        Me.Lib_Survey_txt.Tag = ""
        Me.Lib_Survey_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Survey_txt.UseSystemPasswordChar = False
        '
        'Cod_Survey_txt
        '
        Me.Cod_Survey_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Survey_txt.ContextMenuStrip = Nothing
        Me.Cod_Survey_txt.Location = New System.Drawing.Point(182, 282)
        Me.Cod_Survey_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Cod_Survey_txt.MaxLength = 50
        Me.Cod_Survey_txt.Multiline = False
        Me.Cod_Survey_txt.Name = "Cod_Survey_txt"
        Me.Cod_Survey_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Survey_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Survey_txt.ReadOnly = True
        Me.Cod_Survey_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Survey_txt.SelectionStart = 0
        Me.Cod_Survey_txt.Size = New System.Drawing.Size(176, 26)
        Me.Cod_Survey_txt.TabIndex = 206
        Me.Cod_Survey_txt.Tag = ""
        Me.Cod_Survey_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Survey_txt.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(6, 285)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(176, 19)
        Me.LinkLabel2.TabIndex = 205
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = ""
        Me.LinkLabel2.Text = "Formulaire d'évaluation "
        '
        'Rd_Nature_Formation_2
        '
        Me.Rd_Nature_Formation_2.AutoSize = True
        Me.Rd_Nature_Formation_2.Checked = True
        Me.Rd_Nature_Formation_2.Location = New System.Drawing.Point(92, 55)
        Me.Rd_Nature_Formation_2.Margin = New System.Windows.Forms.Padding(5)
        Me.Rd_Nature_Formation_2.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Nature_Formation_2.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Nature_Formation_2.Name = "Rd_Nature_Formation_2"
        Me.Rd_Nature_Formation_2.Size = New System.Drawing.Size(168, 31)
        Me.Rd_Nature_Formation_2.TabIndex = 3
        Me.Rd_Nature_Formation_2.Text = "Formateur externe"
        '
        'Rd_Nature_Formation_1
        '
        Me.Rd_Nature_Formation_1.AutoSize = True
        Me.Rd_Nature_Formation_1.Checked = False
        Me.Rd_Nature_Formation_1.Location = New System.Drawing.Point(315, 55)
        Me.Rd_Nature_Formation_1.Margin = New System.Windows.Forms.Padding(5)
        Me.Rd_Nature_Formation_1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Nature_Formation_1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Nature_Formation_1.Name = "Rd_Nature_Formation_1"
        Me.Rd_Nature_Formation_1.Size = New System.Drawing.Size(164, 31)
        Me.Rd_Nature_Formation_1.TabIndex = 4
        Me.Rd_Nature_Formation_1.Text = "Formateur interne"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lieu_txt)
        Me.GroupBox1.Controls.Add(Me.Rd_Typ_Lieu_3)
        Me.GroupBox1.Controls.Add(Me.Rd_Typ_Lieu_2)
        Me.GroupBox1.Controls.Add(Me.Rd_Typ_Lieu_1)
        Me.GroupBox1.Location = New System.Drawing.Point(92, 162)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(775, 109)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lieu de la formation"
        '
        'Lieu_txt
        '
        Me.Lieu_txt.AccessibleName = ""
        Me.Lieu_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lieu_txt.ContextMenuStrip = Nothing
        Me.Lieu_txt.Location = New System.Drawing.Point(20, 74)
        Me.Lieu_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lieu_txt.MaxLength = 150
        Me.Lieu_txt.Multiline = False
        Me.Lieu_txt.Name = "Lieu_txt"
        Me.Lieu_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lieu_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lieu_txt.ReadOnly = False
        Me.Lieu_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lieu_txt.SelectionStart = 0
        Me.Lieu_txt.Size = New System.Drawing.Size(739, 26)
        Me.Lieu_txt.TabIndex = 2
        Me.Lieu_txt.Tag = "NC"
        Me.Lieu_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lieu_txt.UseSystemPasswordChar = False
        Me.Lieu_txt.Visible = False
        '
        'Rd_Typ_Lieu_3
        '
        Me.Rd_Typ_Lieu_3.AutoSize = True
        Me.Rd_Typ_Lieu_3.Checked = False
        Me.Rd_Typ_Lieu_3.Location = New System.Drawing.Point(552, 29)
        Me.Rd_Typ_Lieu_3.Margin = New System.Windows.Forms.Padding(5)
        Me.Rd_Typ_Lieu_3.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Typ_Lieu_3.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Typ_Lieu_3.Name = "Rd_Typ_Lieu_3"
        Me.Rd_Typ_Lieu_3.Size = New System.Drawing.Size(142, 31)
        Me.Rd_Typ_Lieu_3.TabIndex = 0
        Me.Rd_Typ_Lieu_3.Text = "Autre"
        '
        'Rd_Typ_Lieu_2
        '
        Me.Rd_Typ_Lieu_2.AutoSize = True
        Me.Rd_Typ_Lieu_2.Checked = False
        Me.Rd_Typ_Lieu_2.Location = New System.Drawing.Point(318, 29)
        Me.Rd_Typ_Lieu_2.Margin = New System.Windows.Forms.Padding(5)
        Me.Rd_Typ_Lieu_2.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Typ_Lieu_2.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Typ_Lieu_2.Name = "Rd_Typ_Lieu_2"
        Me.Rd_Typ_Lieu_2.Size = New System.Drawing.Size(152, 31)
        Me.Rd_Typ_Lieu_2.TabIndex = 0
        Me.Rd_Typ_Lieu_2.Text = "Chez le cabinet"
        '
        'Rd_Typ_Lieu_1
        '
        Me.Rd_Typ_Lieu_1.AutoSize = True
        Me.Rd_Typ_Lieu_1.Checked = True
        Me.Rd_Typ_Lieu_1.Location = New System.Drawing.Point(91, 29)
        Me.Rd_Typ_Lieu_1.Margin = New System.Windows.Forms.Padding(5)
        Me.Rd_Typ_Lieu_1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Typ_Lieu_1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Typ_Lieu_1.Name = "Rd_Typ_Lieu_1"
        Me.Rd_Typ_Lieu_1.Size = New System.Drawing.Size(142, 31)
        Me.Rd_Typ_Lieu_1.TabIndex = 0
        Me.Rd_Typ_Lieu_1.Text = "A l'entreprise"
        '
        'Lib_Cod_Formateur_txt
        '
        Me.Lib_Cod_Formateur_txt.AccessibleName = ""
        Me.Lib_Cod_Formateur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Cod_Formateur_txt.ContextMenuStrip = Nothing
        Me.Lib_Cod_Formateur_txt.Location = New System.Drawing.Point(285, 128)
        Me.Lib_Cod_Formateur_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Cod_Formateur_txt.MaxLength = 50
        Me.Lib_Cod_Formateur_txt.Multiline = False
        Me.Lib_Cod_Formateur_txt.Name = "Lib_Cod_Formateur_txt"
        Me.Lib_Cod_Formateur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Cod_Formateur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Cod_Formateur_txt.ReadOnly = True
        Me.Lib_Cod_Formateur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Cod_Formateur_txt.SelectionStart = 0
        Me.Lib_Cod_Formateur_txt.Size = New System.Drawing.Size(582, 26)
        Me.Lib_Cod_Formateur_txt.TabIndex = 12
        Me.Lib_Cod_Formateur_txt.Tag = "NC"
        Me.Lib_Cod_Formateur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Cod_Formateur_txt.UseSystemPasswordChar = False
        '
        'Cod_Formateur_txt
        '
        Me.Cod_Formateur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cod_Formateur_txt.ContextMenuStrip = Nothing
        Me.Cod_Formateur_txt.Location = New System.Drawing.Point(92, 128)
        Me.Cod_Formateur_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Formateur_txt.MaxLength = 20
        Me.Cod_Formateur_txt.Multiline = False
        Me.Cod_Formateur_txt.Name = "Cod_Formateur_txt"
        Me.Cod_Formateur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Formateur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Formateur_txt.ReadOnly = True
        Me.Cod_Formateur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Formateur_txt.SelectionStart = 0
        Me.Cod_Formateur_txt.Size = New System.Drawing.Size(189, 26)
        Me.Cod_Formateur_txt.TabIndex = 11
        Me.Cod_Formateur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Formateur_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(10, 131)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(79, 19)
        Me.LinkLabel3.TabIndex = 7
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Formateur"
        '
        'Lib_Cod_Cabinet_txt
        '
        Me.Lib_Cod_Cabinet_txt.AccessibleName = ""
        Me.Lib_Cod_Cabinet_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Cod_Cabinet_txt.ContextMenuStrip = Nothing
        Me.Lib_Cod_Cabinet_txt.Location = New System.Drawing.Point(285, 94)
        Me.Lib_Cod_Cabinet_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Cod_Cabinet_txt.MaxLength = 50
        Me.Lib_Cod_Cabinet_txt.Multiline = False
        Me.Lib_Cod_Cabinet_txt.Name = "Lib_Cod_Cabinet_txt"
        Me.Lib_Cod_Cabinet_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Cod_Cabinet_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Cod_Cabinet_txt.ReadOnly = True
        Me.Lib_Cod_Cabinet_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Cod_Cabinet_txt.SelectionStart = 0
        Me.Lib_Cod_Cabinet_txt.Size = New System.Drawing.Size(582, 26)
        Me.Lib_Cod_Cabinet_txt.TabIndex = 9
        Me.Lib_Cod_Cabinet_txt.Tag = "NC"
        Me.Lib_Cod_Cabinet_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Cod_Cabinet_txt.UseSystemPasswordChar = False
        '
        'Cod_Cabinet_txt
        '
        Me.Cod_Cabinet_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cod_Cabinet_txt.ContextMenuStrip = Nothing
        Me.Cod_Cabinet_txt.Location = New System.Drawing.Point(92, 94)
        Me.Cod_Cabinet_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Cabinet_txt.MaxLength = 20
        Me.Cod_Cabinet_txt.Multiline = False
        Me.Cod_Cabinet_txt.Name = "Cod_Cabinet_txt"
        Me.Cod_Cabinet_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Cabinet_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Cabinet_txt.ReadOnly = True
        Me.Cod_Cabinet_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Cabinet_txt.SelectionStart = 0
        Me.Cod_Cabinet_txt.Size = New System.Drawing.Size(189, 26)
        Me.Cod_Cabinet_txt.TabIndex = 8
        Me.Cod_Cabinet_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Cabinet_txt.UseSystemPasswordChar = False
        '
        'CodCabinet
        '
        Me.CodCabinet.AutoSize = True
        Me.CodCabinet.LinkColor = System.Drawing.Color.Black
        Me.CodCabinet.Location = New System.Drawing.Point(22, 96)
        Me.CodCabinet.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CodCabinet.Name = "CodCabinet"
        Me.CodCabinet.Size = New System.Drawing.Size(66, 19)
        Me.CodCabinet.TabIndex = 6
        Me.CodCabinet.TabStop = True
        Me.CodCabinet.Text = "Cabinet"
        '
        'Dat_Au
        '
        Me.Dat_Au.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.Dat_Au.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dat_Au.Location = New System.Drawing.Point(754, 60)
        Me.Dat_Au.Margin = New System.Windows.Forms.Padding(4)
        Me.Dat_Au.Name = "Dat_Au"
        Me.Dat_Au.Size = New System.Drawing.Size(159, 24)
        Me.Dat_Au.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(724, 64)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 19)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Au"
        '
        'Dat_Du
        '
        Me.Dat_Du.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.Dat_Du.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dat_Du.Location = New System.Drawing.Point(558, 60)
        Me.Dat_Du.Margin = New System.Windows.Forms.Padding(4)
        Me.Dat_Du.Name = "Dat_Du"
        Me.Dat_Du.Size = New System.Drawing.Size(158, 24)
        Me.Dat_Du.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(725, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Budget"
        '
        'Budget_txt
        '
        Me.Budget_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Budget_txt.ContextMenuStrip = Nothing
        Me.Budget_txt.Location = New System.Drawing.Point(789, 20)
        Me.Budget_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Budget_txt.MaxLength = 32767
        Me.Budget_txt.Multiline = False
        Me.Budget_txt.Name = "Budget_txt"
        Me.Budget_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Budget_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Budget_txt.ReadOnly = False
        Me.Budget_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Budget_txt.SelectionStart = 0
        Me.Budget_txt.Size = New System.Drawing.Size(125, 26)
        Me.Budget_txt.TabIndex = 3
        Me.Budget_txt.Text = "0,00"
        Me.Budget_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Budget_txt.UseSystemPasswordChar = False
        '
        'Formation_Planifiee_chk
        '
        Me.Formation_Planifiee_chk.AutoSize = True
        Me.Formation_Planifiee_chk.Checked = True
        Me.Formation_Planifiee_chk.Location = New System.Drawing.Point(468, 15)
        Me.Formation_Planifiee_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.Formation_Planifiee_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Formation_Planifiee_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Formation_Planifiee_chk.Name = "Formation_Planifiee_chk"
        Me.Formation_Planifiee_chk.Size = New System.Drawing.Size(162, 25)
        Me.Formation_Planifiee_chk.TabIndex = 2
        Me.Formation_Planifiee_chk.Text = "Formation planifiée"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(526, 64)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Du"
        '
        'Genre_Formation
        '
        Me.Genre_Formation.DataSource = Nothing
        Me.Genre_Formation.DisplayMember = ""
        Me.Genre_Formation.DroppedDown = False
        Me.Genre_Formation.Location = New System.Drawing.Point(92, 15)
        Me.Genre_Formation.Margin = New System.Windows.Forms.Padding(5)
        Me.Genre_Formation.Name = "Genre_Formation"
        Me.Genre_Formation.SelectedIndex = -1
        Me.Genre_Formation.SelectedItem = Nothing
        Me.Genre_Formation.SelectedValue = Nothing
        Me.Genre_Formation.Size = New System.Drawing.Size(356, 30)
        Me.Genre_Formation.TabIndex = 3
        Me.Genre_Formation.ValueMember = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Genre"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.Contenu_rtb)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(4, 28)
        Me.SuperTabControlPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(1242, 611)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.Text = "Contenu"
        '
        'Contenu_rtb
        '
        Me.Contenu_rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Contenu_rtb.Location = New System.Drawing.Point(0, 0)
        Me.Contenu_rtb.Margin = New System.Windows.Forms.Padding(205, 735, 205, 735)
        Me.Contenu_rtb.Name = "Contenu_rtb"
        Me.Contenu_rtb.Size = New System.Drawing.Size(1242, 611)
        Me.Contenu_rtb.TabIndex = 2
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Grd_Participants)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(4, 28)
        Me.SuperTabControlPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1242, 611)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.Text = "Participants"
        '
        'Grd_Participants
        '
        Me.Grd_Participants.AfficherLesEntetesLignes = True
        Me.Grd_Participants.AllowUserToAddRows = False
        Me.Grd_Participants.AlternerLesLignes = False
        Me.Grd_Participants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Participants.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Participants.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd_Participants.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Participants.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Grd_Participants.ColumnHeadersHeight = 30
        Me.Grd_Participants.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Matricule, Me.Nom, Me.Present, Me.Evaluation})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Participants.DefaultCellStyle = DataGridViewCellStyle6
        Me.Grd_Participants.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Participants.EnableHeadersVisualStyles = False
        Me.Grd_Participants.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Participants.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Participants.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Participants.Name = "Grd_Participants"
        Me.Grd_Participants.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Participants.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grd_Participants.RowHeadersWidth = 51
        Me.Grd_Participants.Size = New System.Drawing.Size(1242, 611)
        Me.Grd_Participants.TabIndex = 223
        '
        'Matricule
        '
        Me.Matricule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Matricule.HeaderText = "Matricule"
        Me.Matricule.MinimumWidth = 120
        Me.Matricule.Name = "Matricule"
        Me.Matricule.ReadOnly = True
        Me.Matricule.Width = 120
        '
        'Nom
        '
        Me.Nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Nom.HeaderText = "Nom"
        Me.Nom.MinimumWidth = 400
        Me.Nom.Name = "Nom"
        Me.Nom.ReadOnly = True
        Me.Nom.Width = 400
        '
        'Present
        '
        Me.Present.HeaderText = "Présence"
        Me.Present.MinimumWidth = 6
        Me.Present.Name = "Present"
        Me.Present.Width = 86
        '
        'Evaluation
        '
        Me.Evaluation.HeaderText = "Evaluation"
        Me.Evaluation.MinimumWidth = 6
        Me.Evaluation.Name = "Evaluation"
        Me.Evaluation.ReadOnly = True
        Me.Evaluation.Width = 98
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.Grd_Organismes)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(4, 28)
        Me.SuperTabControlPanel4.Margin = New System.Windows.Forms.Padding(4)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(1242, 611)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.Text = "Organisme de financement"
        '
        'Grd_Organismes
        '
        Me.Grd_Organismes.AfficherLesEntetesLignes = True
        Me.Grd_Organismes.AlternerLesLignes = False
        Me.Grd_Organismes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Organismes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Organismes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd_Organismes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Organismes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Grd_Organismes.ColumnHeadersHeight = 30
        Me.Grd_Organismes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Organisme, Me.Montant})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Organismes.DefaultCellStyle = DataGridViewCellStyle10
        Me.Grd_Organismes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Organismes.EnableHeadersVisualStyles = False
        Me.Grd_Organismes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Organismes.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Organismes.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Organismes.Name = "Grd_Organismes"
        Me.Grd_Organismes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Organismes.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.Grd_Organismes.RowHeadersWidth = 51
        Me.Grd_Organismes.Size = New System.Drawing.Size(1242, 611)
        Me.Grd_Organismes.TabIndex = 222
        '
        'Organisme
        '
        Me.Organisme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Organisme.HeaderText = "Organisme"
        Me.Organisme.MinimumWidth = 300
        Me.Organisme.Name = "Organisme"
        Me.Organisme.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Organisme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Organisme.Width = 300
        '
        'Montant
        '
        Me.Montant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        '
        '
        '
        Me.Montant.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Montant.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Montant.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Montant.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Montant.DefaultCellStyle = DataGridViewCellStyle9
        Me.Montant.HeaderText = "Financement"
        Me.Montant.Increment = 1.0R
        Me.Montant.MinimumWidth = 100
        Me.Montant.Name = "Montant"
        Me.Montant.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Montant.Width = 139
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Lib_Action_Formation_txt)
        Me.GroupBox7.Controls.Add(Me.Action_Formation_txt)
        Me.GroupBox7.Controls.Add(Me.LinkLabel1)
        Me.GroupBox7.Controls.Add(Me.Lib_Formation_txt)
        Me.GroupBox7.Controls.Add(Me.Cod_Formation_txt)
        Me.GroupBox7.Controls.Add(Me.Cod_Fou_LINK)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox7.Size = New System.Drawing.Size(1250, 89)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Tag = "NC"
        '
        'Lib_Action_Formation_txt
        '
        Me.Lib_Action_Formation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Lib_Action_Formation_txt.ContextMenuStrip = Nothing
        Me.Lib_Action_Formation_txt.Location = New System.Drawing.Point(331, 49)
        Me.Lib_Action_Formation_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Action_Formation_txt.MaxLength = 20
        Me.Lib_Action_Formation_txt.Multiline = False
        Me.Lib_Action_Formation_txt.Name = "Lib_Action_Formation_txt"
        Me.Lib_Action_Formation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Action_Formation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Action_Formation_txt.ReadOnly = True
        Me.Lib_Action_Formation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Action_Formation_txt.SelectionStart = 0
        Me.Lib_Action_Formation_txt.Size = New System.Drawing.Size(581, 26)
        Me.Lib_Action_Formation_txt.TabIndex = 8
        Me.Lib_Action_Formation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Action_Formation_txt.UseSystemPasswordChar = False
        '
        'Action_Formation_txt
        '
        Me.Action_Formation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Action_Formation_txt.ContextMenuStrip = Nothing
        Me.Action_Formation_txt.Location = New System.Drawing.Point(139, 49)
        Me.Action_Formation_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Action_Formation_txt.MaxLength = 20
        Me.Action_Formation_txt.Multiline = False
        Me.Action_Formation_txt.Name = "Action_Formation_txt"
        Me.Action_Formation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Action_Formation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Action_Formation_txt.ReadOnly = True
        Me.Action_Formation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Action_Formation_txt.SelectionStart = 0
        Me.Action_Formation_txt.Size = New System.Drawing.Size(188, 26)
        Me.Action_Formation_txt.TabIndex = 5
        Me.Action_Formation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Action_Formation_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(74, 51)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(61, 19)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Action :"
        '
        'Lib_Formation_txt
        '
        Me.Lib_Formation_txt.AccessibleName = ""
        Me.Lib_Formation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Formation_txt.ContextMenuStrip = Nothing
        Me.Lib_Formation_txt.Location = New System.Drawing.Point(331, 21)
        Me.Lib_Formation_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Formation_txt.MaxLength = 50
        Me.Lib_Formation_txt.Multiline = False
        Me.Lib_Formation_txt.Name = "Lib_Formation_txt"
        Me.Lib_Formation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Formation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Formation_txt.ReadOnly = False
        Me.Lib_Formation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Formation_txt.SelectionStart = 0
        Me.Lib_Formation_txt.Size = New System.Drawing.Size(581, 26)
        Me.Lib_Formation_txt.TabIndex = 1
        Me.Lib_Formation_txt.Tag = "NC"
        Me.Lib_Formation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Formation_txt.UseSystemPasswordChar = False
        '
        'Cod_Formation_txt
        '
        Me.Cod_Formation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cod_Formation_txt.ContextMenuStrip = Nothing
        Me.Cod_Formation_txt.Location = New System.Drawing.Point(139, 21)
        Me.Cod_Formation_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Formation_txt.MaxLength = 20
        Me.Cod_Formation_txt.Multiline = False
        Me.Cod_Formation_txt.Name = "Cod_Formation_txt"
        Me.Cod_Formation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Formation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Formation_txt.ReadOnly = True
        Me.Cod_Formation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Formation_txt.SelectionStart = 0
        Me.Cod_Formation_txt.Size = New System.Drawing.Size(188, 26)
        Me.Cod_Formation_txt.TabIndex = 0
        Me.Cod_Formation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Formation_txt.UseSystemPasswordChar = False
        '
        'Cod_Fou_LINK
        '
        Me.Cod_Fou_LINK.AutoSize = True
        Me.Cod_Fou_LINK.LinkColor = System.Drawing.Color.Black
        Me.Cod_Fou_LINK.Location = New System.Drawing.Point(50, 24)
        Me.Cod_Fou_LINK.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Cod_Fou_LINK.Name = "Cod_Fou_LINK"
        Me.Cod_Fou_LINK.Size = New System.Drawing.Size(86, 19)
        Me.Cod_Fou_LINK.TabIndex = 4
        Me.Cod_Fou_LINK.TabStop = True
        Me.Cod_Fou_LINK.Text = "Formation :"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk)
        Me.Panel1.Location = New System.Drawing.Point(50, 316)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(858, 57)
        Me.Panel1.TabIndex = 208
        '
        'Formation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1250, 732)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Formation"
        Me.Tag = "ECR"
        Me.Text = "Formation"
        Me.TabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.Grd_Domaines_Competences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.Grd_Participants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        CType(Me.Grd_Organismes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SuperTabControlPanel3 As TabPage
    Friend WithEvents SuperTabControlPanel2 As TabPage
    Friend WithEvents SuperTabControlPanel1 As TabPage
    Friend WithEvents Contenu_rtb As ud_RT
    Friend WithEvents Pnl As Panel
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Lib_Action_Formation_txt As ud_TextBox
    Friend WithEvents Action_Formation_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Lib_Formation_txt As ud_TextBox
    Friend WithEvents Cod_Formation_txt As ud_TextBox
    Friend WithEvents Cod_Fou_LINK As LinkLabel
    Friend WithEvents SuperTabControlPanel4 As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents Budget_txt As ud_TextBox
    Friend WithEvents Formation_Planifiee_chk As ud_CheckBox
    Friend WithEvents Genre_Formation As ud_ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Grd_Organismes As ud_Grd
    Friend WithEvents Dat_Au As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Dat_Du As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Grd_Domaines_Competences As ud_Grd
    Friend WithEvents Lib_Cod_Formateur_txt As ud_TextBox
    Friend WithEvents Cod_Formateur_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Lib_Cod_Cabinet_txt As ud_TextBox
    Friend WithEvents Cod_Cabinet_txt As ud_TextBox
    Friend WithEvents CodCabinet As LinkLabel
    Friend WithEvents Statut_Formation As ud_ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Lieu_txt As ud_TextBox
    Friend WithEvents Rd_Typ_Lieu_3 As ud_RadioBox
    Friend WithEvents Rd_Typ_Lieu_2 As ud_RadioBox
    Friend WithEvents Rd_Typ_Lieu_1 As ud_RadioBox
    Friend WithEvents Grd_Participants As ud_Grd
    Friend WithEvents Rd_Nature_Formation_2 As ud_RadioBox
    Friend WithEvents Rd_Nature_Formation_1 As ud_RadioBox
    Friend WithEvents Organisme As DataGridViewComboBoxColumn
    Friend WithEvents Montant As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Matricule As DataGridViewTextBoxColumn
    Friend WithEvents Nom As DataGridViewTextBoxColumn
    Friend WithEvents Present As DataGridViewCheckBoxColumn
    Friend WithEvents Evaluation As DataGridViewCheckBoxColumn
    Friend WithEvents Lib_Survey_txt As ud_TextBox
    Friend WithEvents Cod_Survey_txt As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents Domaine_Competence As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Domaine_Competence As DataGridViewTextBoxColumn
    Friend WithEvents Typ_Formation As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Typ_Formation As DataGridViewTextBoxColumn
    Friend WithEvents RowId As DataGridViewTextBoxColumn
    Friend WithEvents Msg As DataGridViewTextBoxColumn
    Friend WithEvents ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk As ud_RadioBox
    Friend WithEvents Panel1 As Panel
End Class
