<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Survey
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CntScripts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Lib_Rubrique_txt = New RHP.ud_TextBox()
        Me.Cod_Rubrique_txt = New RHP.ud_TextBox()
        Me.Rub_ = New System.Windows.Forms.LinkLabel()
        Me.AvecNote_chk = New RHP.ud_CheckBox()
        Me.Preambule_rtb = New RHP.ud_RichTextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Domaine_cbo = New RHP.ud_ComboBox()
        Me.utilise_chk = New RHP.ud_CheckBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Survey_txt = New RHP.ud_TextBox()
        Me.Cod_Survey_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Grd = New RHP.ud_Grd()
        Me.Rang = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.Question = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Reponse = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Regex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Structure_Reponse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mode_Scoring = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Max_Score = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Func_Scoring = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Coef = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Obligatoire = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Obligatoire_Si = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Erreur_Si = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Erreur_Msg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CntScripts.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CntScripts
        '
        Me.CntScripts.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CntScripts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupprimerToolStripMenuItem})
        Me.CntScripts.Name = "CntScripts"
        Me.CntScripts.Size = New System.Drawing.Size(152, 30)
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.supprimerligne
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(151, 26)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "                             "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Lib_Rubrique_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Rubrique_txt)
        Me.GroupBox2.Controls.Add(Me.Rub_)
        Me.GroupBox2.Controls.Add(Me.AvecNote_chk)
        Me.GroupBox2.Controls.Add(Me.Preambule_rtb)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Domaine_cbo)
        Me.GroupBox2.Controls.Add(Me.utilise_chk)
        Me.GroupBox2.Controls.Add(Me.LinkLabel2)
        Me.GroupBox2.Controls.Add(Me.Lib_Survey_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Survey_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1106, 291)
        Me.GroupBox2.TabIndex = 218
        Me.GroupBox2.TabStop = False
        '
        'Lib_Rubrique_txt
        '
        Me.Lib_Rubrique_txt.AccessibleDescription = "A"
        Me.Lib_Rubrique_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Rubrique_txt.ContextMenuStrip = Nothing
        Me.Lib_Rubrique_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Rubrique_txt.Location = New System.Drawing.Point(644, 260)
        Me.Lib_Rubrique_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Rubrique_txt.MaxLength = 32767
        Me.Lib_Rubrique_txt.Multiline = False
        Me.Lib_Rubrique_txt.Name = "Lib_Rubrique_txt"
        Me.Lib_Rubrique_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Rubrique_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Rubrique_txt.ReadOnly = True
        Me.Lib_Rubrique_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Rubrique_txt.SelectionStart = 0
        Me.Lib_Rubrique_txt.Size = New System.Drawing.Size(274, 26)
        Me.Lib_Rubrique_txt.TabIndex = 212
        Me.Lib_Rubrique_txt.TabStop = False
        Me.Lib_Rubrique_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Rubrique_txt.UseSystemPasswordChar = False
        '
        'Cod_Rubrique_txt
        '
        Me.Cod_Rubrique_txt.AccessibleDescription = "A"
        Me.Cod_Rubrique_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Rubrique_txt.ContextMenuStrip = Nothing
        Me.Cod_Rubrique_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Rubrique_txt.Location = New System.Drawing.Point(452, 259)
        Me.Cod_Rubrique_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Rubrique_txt.MaxLength = 32767
        Me.Cod_Rubrique_txt.Multiline = False
        Me.Cod_Rubrique_txt.Name = "Cod_Rubrique_txt"
        Me.Cod_Rubrique_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Rubrique_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Rubrique_txt.ReadOnly = True
        Me.Cod_Rubrique_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Rubrique_txt.SelectionStart = 0
        Me.Cod_Rubrique_txt.Size = New System.Drawing.Size(184, 26)
        Me.Cod_Rubrique_txt.TabIndex = 212
        Me.Cod_Rubrique_txt.TabStop = False
        Me.Cod_Rubrique_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Rubrique_txt.UseSystemPasswordChar = False
        '
        'Rub_
        '
        Me.Rub_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rub_.AutoSize = True
        Me.Rub_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rub_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rub_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rub_.Location = New System.Drawing.Point(264, 264)
        Me.Rub_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Rub_.Name = "Rub_"
        Me.Rub_.Size = New System.Drawing.Size(180, 19)
        Me.Rub_.TabIndex = 213
        Me.Rub_.TabStop = True
        Me.Rub_.Tag = ""
        Me.Rub_.Text = "Elément variable associé"
        '
        'AvecNote_chk
        '
        Me.AvecNote_chk.AutoSize = True
        Me.AvecNote_chk.Checked = False
        Me.AvecNote_chk.Location = New System.Drawing.Point(134, 258)
        Me.AvecNote_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.AvecNote_chk.MaximumSize = New System.Drawing.Size(0, 30)
        Me.AvecNote_chk.MinimumSize = New System.Drawing.Size(125, 30)
        Me.AvecNote_chk.Name = "AvecNote_chk"
        Me.AvecNote_chk.Size = New System.Drawing.Size(125, 30)
        Me.AvecNote_chk.TabIndex = 211
        Me.AvecNote_chk.Text = "Avec note"
        '
        'Preambule_rtb
        '
        Me.Preambule_rtb.Location = New System.Drawing.Point(134, 49)
        Me.Preambule_rtb.Margin = New System.Windows.Forms.Padding(5)
        Me.Preambule_rtb.Name = "Preambule_rtb"
        Me.Preambule_rtb.ReadOnly = False
        Me.Preambule_rtb.Size = New System.Drawing.Size(784, 170)
        Me.Preambule_rtb.TabIndex = 210
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(52, 229)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(76, 19)
        Me.LinkLabel3.TabIndex = 209
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = ""
        Me.LinkLabel3.Text = "Domaine "
        '
        'Domaine_cbo
        '
        Me.Domaine_cbo.DataSource = Nothing
        Me.Domaine_cbo.DisplayMember = ""
        Me.Domaine_cbo.DroppedDown = False
        Me.Domaine_cbo.Location = New System.Drawing.Point(134, 224)
        Me.Domaine_cbo.Margin = New System.Windows.Forms.Padding(5)
        Me.Domaine_cbo.Name = "Domaine_cbo"
        Me.Domaine_cbo.SelectedIndex = -1
        Me.Domaine_cbo.SelectedItem = Nothing
        Me.Domaine_cbo.SelectedValue = Nothing
        Me.Domaine_cbo.Size = New System.Drawing.Size(242, 30)
        Me.Domaine_cbo.TabIndex = 208
        Me.Domaine_cbo.ValueMember = ""
        '
        'utilise_chk
        '
        Me.utilise_chk.AutoSize = True
        Me.utilise_chk.Checked = True
        Me.utilise_chk.Enabled = False
        Me.utilise_chk.Location = New System.Drawing.Point(850, 226)
        Me.utilise_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.utilise_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.utilise_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.utilise_chk.Name = "utilise_chk"
        Me.utilise_chk.Size = New System.Drawing.Size(125, 25)
        Me.utilise_chk.TabIndex = 207
        Me.utilise_chk.Text = "Utilisé"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(44, 52)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(84, 19)
        Me.LinkLabel2.TabIndex = 206
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = ""
        Me.LinkLabel2.Text = "Préambule"
        '
        'Lib_Survey_txt
        '
        Me.Lib_Survey_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Survey_txt.ContextMenuStrip = Nothing
        Me.Lib_Survey_txt.Location = New System.Drawing.Point(318, 16)
        Me.Lib_Survey_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Lib_Survey_txt.MaxLength = 50
        Me.Lib_Survey_txt.Multiline = False
        Me.Lib_Survey_txt.Name = "Lib_Survey_txt"
        Me.Lib_Survey_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Survey_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Survey_txt.ReadOnly = False
        Me.Lib_Survey_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Survey_txt.SelectionStart = 0
        Me.Lib_Survey_txt.Size = New System.Drawing.Size(600, 26)
        Me.Lib_Survey_txt.TabIndex = 204
        Me.Lib_Survey_txt.Tag = ""
        Me.Lib_Survey_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Survey_txt.UseSystemPasswordChar = False
        '
        'Cod_Survey_txt
        '
        Me.Cod_Survey_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Survey_txt.ContextMenuStrip = Nothing
        Me.Cod_Survey_txt.Location = New System.Drawing.Point(134, 16)
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
        Me.Cod_Survey_txt.TabIndex = 203
        Me.Cod_Survey_txt.Tag = ""
        Me.Cod_Survey_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Survey_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(11, 19)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(120, 19)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Code formulaire"
        '
        'Grd
        '
        Me.Grd.AfficherLesEntetesLignes = True
        Me.Grd.AlternerLesLignes = False
        Me.Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd.ColumnHeadersHeight = 30
        Me.Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rang, Me.Question, Me.Typ_Reponse, Me.Regex, Me.Structure_Reponse, Me.Mode_Scoring, Me.Max_Score, Me.Func_Scoring, Me.Coef, Me.Obligatoire, Me.Obligatoire_Si, Me.Erreur_Si, Me.Erreur_Msg, Me.RowId})
        Me.Grd.ContextMenuStrip = Me.CntScripts
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd.DefaultCellStyle = DataGridViewCellStyle6
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.EnableHeadersVisualStyles = False
        Me.Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd.Location = New System.Drawing.Point(0, 291)
        Me.Grd.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grd.RowHeadersWidth = 51
        Me.Grd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Grd.Size = New System.Drawing.Size(1106, 271)
        Me.Grd.TabIndex = 219
        '
        'Rang
        '
        '
        '
        '
        Me.Rang.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Rang.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Rang.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rang.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Rang.DefaultCellStyle = DataGridViewCellStyle2
        Me.Rang.HeaderText = "N° question"
        Me.Rang.MinimumWidth = 6
        Me.Rang.Name = "Rang"
        Me.Rang.Width = 126
        '
        'Question
        '
        Me.Question.HeaderText = "Question"
        Me.Question.MaxInputLength = 499
        Me.Question.MinimumWidth = 250
        Me.Question.Name = "Question"
        Me.Question.Width = 250
        '
        'Typ_Reponse
        '
        Me.Typ_Reponse.HeaderText = "Type de réponse"
        Me.Typ_Reponse.MinimumWidth = 200
        Me.Typ_Reponse.Name = "Typ_Reponse"
        Me.Typ_Reponse.Width = 200
        '
        'Regex
        '
        Me.Regex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Regex.HeaderText = "Regex"
        Me.Regex.MaxInputLength = 4000
        Me.Regex.MinimumWidth = 100
        Me.Regex.Name = "Regex"
        Me.Regex.ReadOnly = True
        Me.Regex.Visible = False
        '
        'Structure_Reponse
        '
        Me.Structure_Reponse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Structure_Reponse.DefaultCellStyle = DataGridViewCellStyle3
        Me.Structure_Reponse.HeaderText = "Structure de réponse"
        Me.Structure_Reponse.MinimumWidth = 100
        Me.Structure_Reponse.Name = "Structure_Reponse"
        Me.Structure_Reponse.Width = 190
        '
        'Mode_Scoring
        '
        Me.Mode_Scoring.HeaderText = "Mode scoring"
        Me.Mode_Scoring.MinimumWidth = 6
        Me.Mode_Scoring.Name = "Mode_Scoring"
        Me.Mode_Scoring.Width = 117
        '
        'Max_Score
        '
        '
        '
        '
        Me.Max_Score.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Max_Score.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Max_Score.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Max_Score.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Max_Score.DefaultCellStyle = DataGridViewCellStyle4
        Me.Max_Score.HeaderText = "Maximum"
        Me.Max_Score.Increment = 1.0R
        Me.Max_Score.MinimumWidth = 6
        Me.Max_Score.MinValue = 0R
        Me.Max_Score.Name = "Max_Score"
        Me.Max_Score.Width = 115
        '
        'Func_Scoring
        '
        Me.Func_Scoring.HeaderText = "Fonction"
        Me.Func_Scoring.MinimumWidth = 6
        Me.Func_Scoring.Name = "Func_Scoring"
        Me.Func_Scoring.ReadOnly = True
        Me.Func_Scoring.Width = 107
        '
        'Coef
        '
        '
        '
        '
        Me.Coef.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Coef.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Coef.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Coef.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Coef.DefaultCellStyle = DataGridViewCellStyle5
        Me.Coef.HeaderText = "Coefficient"
        Me.Coef.Increment = 1.0R
        Me.Coef.MinimumWidth = 6
        Me.Coef.MinValue = 0R
        Me.Coef.Name = "Coef"
        Me.Coef.Width = 122
        '
        'Obligatoire
        '
        Me.Obligatoire.HeaderText = "Obligatoire"
        Me.Obligatoire.MinimumWidth = 6
        Me.Obligatoire.Name = "Obligatoire"
        Me.Obligatoire.Width = 101
        '
        'Obligatoire_Si
        '
        Me.Obligatoire_Si.HeaderText = "Obligatoire si :"
        Me.Obligatoire_Si.MinimumWidth = 6
        Me.Obligatoire_Si.Name = "Obligatoire_Si"
        Me.Obligatoire_Si.ReadOnly = True
        Me.Obligatoire_Si.Width = 144
        '
        'Erreur_Si
        '
        Me.Erreur_Si.HeaderText = "Erreur si"
        Me.Erreur_Si.MinimumWidth = 6
        Me.Erreur_Si.Name = "Erreur_Si"
        Me.Erreur_Si.ReadOnly = True
        Me.Erreur_Si.Width = 97
        '
        'Erreur_Msg
        '
        Me.Erreur_Msg.HeaderText = "Message Erreur"
        Me.Erreur_Msg.MinimumWidth = 6
        Me.Erreur_Msg.Name = "Erreur_Msg"
        Me.Erreur_Msg.Width = 149
        '
        'RowId
        '
        Me.RowId.HeaderText = "RowId"
        Me.RowId.MinimumWidth = 6
        Me.RowId.Name = "RowId"
        Me.RowId.Visible = False
        Me.RowId.Width = 90
        '
        'Survey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1106, 562)
        Me.Controls.Add(Me.Grd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Survey"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage formulaires d'enquête"
        Me.CntScripts.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CntScripts As ContextMenuStrip
    Friend WithEvents SupprimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Lib_Survey_txt As ud_TextBox
    Friend WithEvents Cod_Survey_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Grd As ud_Grd
    Friend WithEvents utilise_chk As ud_CheckBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Domaine_cbo As ud_ComboBox
    Friend WithEvents Preambule_rtb As ud_RichTextBox
    Friend WithEvents AvecNote_chk As ud_CheckBox
    Friend WithEvents Lib_Rubrique_txt As ud_TextBox
    Friend WithEvents Cod_Rubrique_txt As ud_TextBox
    Friend WithEvents Rub_ As LinkLabel
    Friend WithEvents Rang As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents Question As DataGridViewTextBoxColumn
    Friend WithEvents Typ_Reponse As DataGridViewComboBoxColumn
    Friend WithEvents Regex As DataGridViewTextBoxColumn
    Friend WithEvents Structure_Reponse As DataGridViewTextBoxColumn
    Friend WithEvents Mode_Scoring As DataGridViewComboBoxColumn
    Friend WithEvents Max_Score As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Func_Scoring As DataGridViewTextBoxColumn
    Friend WithEvents Coef As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Obligatoire As DataGridViewCheckBoxColumn
    Friend WithEvents Obligatoire_Si As DataGridViewTextBoxColumn
    Friend WithEvents Erreur_Si As DataGridViewTextBoxColumn
    Friend WithEvents Erreur_Msg As DataGridViewTextBoxColumn
    Friend WithEvents RowId As DataGridViewTextBoxColumn
End Class
