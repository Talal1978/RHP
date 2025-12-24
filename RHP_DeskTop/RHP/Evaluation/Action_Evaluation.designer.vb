<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Action_Evaluation
    Inherits Ecran
    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Statut_Evaluation = New RHP.ud_ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Dat_Au = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dat_Du = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Evaluateur_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Evaluateur = New System.Windows.Forms.LinkLabel()
        Me.Rd2 = New RHP.ud_RadioBox()
        Me.Rd1 = New RHP.ud_RadioBox()
        Me.Lib_Survey_txt = New RHP.ud_TextBox()
        Me.Cod_Survey_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Description_txt = New RHP.ud_TextBox()
        Me.Cod_Evaluation_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Adv = New DevComponents.AdvTree.AdvTree()
        Me.Entite = New DevComponents.AdvTree.ColumnHeader()
        Me.Grade = New DevComponents.AdvTree.ColumnHeader()
        Me.Poste = New DevComponents.AdvTree.ColumnHeader()
        Me.Anciennete = New DevComponents.AdvTree.ColumnHeader()
        Me.Titre = New DevComponents.AdvTree.ColumnHeader()
        Me.Evalue = New DevComponents.AdvTree.ColumnHeader()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.CntM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SupprimerLactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sous_Entite_chk = New RHP.ud_CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Grade_ = New System.Windows.Forms.LinkLabel()
        Me.Cod_Grade_txt = New RHP.ud_TextBox()
        Me.Lib_Grade_txt = New RHP.ud_TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CntM.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "                             "
        '
        'Statut_Evaluation
        '
        Me.Statut_Evaluation.DataSource = Nothing
        Me.Statut_Evaluation.DisplayMember = ""
        Me.Statut_Evaluation.DroppedDown = False
        Me.Statut_Evaluation.Enabled = False
        Me.Statut_Evaluation.Location = New System.Drawing.Point(1036, 12)
        Me.Statut_Evaluation.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Statut_Evaluation.Name = "Statut_Evaluation"
        Me.Statut_Evaluation.SelectedIndex = -1
        Me.Statut_Evaluation.SelectedItem = Nothing
        Me.Statut_Evaluation.SelectedValue = Nothing
        Me.Statut_Evaluation.Size = New System.Drawing.Size(151, 31)
        Me.Statut_Evaluation.TabIndex = 0
        Me.Statut_Evaluation.ValueMember = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Statut_Evaluation)
        Me.GroupBox2.Controls.Add(Me.Dat_Au)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Dat_Du)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.Lib_Survey_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Survey_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Description_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Evaluation_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1392, 161)
        Me.GroupBox2.TabIndex = 218
        Me.GroupBox2.TabStop = False
        '
        'Dat_Au
        '
        Me.Dat_Au.CustomFormat = "dd/MM/yyyy"
        Me.Dat_Au.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dat_Au.Location = New System.Drawing.Point(252, 119)
        Me.Dat_Au.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Au.Name = "Dat_Au"
        Me.Dat_Au.Size = New System.Drawing.Size(120, 24)
        Me.Dat_Au.TabIndex = 214
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(222, 122)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 19)
        Me.Label5.TabIndex = 215
        Me.Label5.Text = "Au"
        '
        'Dat_Du
        '
        Me.Dat_Du.CustomFormat = "dd/MM/yyyy"
        Me.Dat_Du.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dat_Du.Location = New System.Drawing.Point(94, 119)
        Me.Dat_Du.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Du.Name = "Dat_Du"
        Me.Dat_Du.Size = New System.Drawing.Size(119, 24)
        Me.Dat_Du.TabIndex = 213
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 122)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 19)
        Me.Label4.TabIndex = 212
        Me.Label4.Text = "Du"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Evaluateur_txt)
        Me.GroupBox1.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox1.Controls.Add(Me.Evaluateur)
        Me.GroupBox1.Controls.Add(Me.Rd2)
        Me.GroupBox1.Controls.Add(Me.Rd1)
        Me.GroupBox1.Location = New System.Drawing.Point(62, 50)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1125, 60)
        Me.GroupBox1.TabIndex = 211
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Evaluateur"
        '
        'Evaluateur_txt
        '
        Me.Evaluateur_txt.AccessibleDescription = "A"
        Me.Evaluateur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Evaluateur_txt.ContextMenuStrip = Nothing
        Me.Evaluateur_txt.Location = New System.Drawing.Point(400, 22)
        Me.Evaluateur_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Evaluateur_txt.MaxLength = 32767
        Me.Evaluateur_txt.Multiline = False
        Me.Evaluateur_txt.Name = "Evaluateur_txt"
        Me.Evaluateur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Evaluateur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Evaluateur_txt.ReadOnly = True
        Me.Evaluateur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Evaluateur_txt.SelectionStart = 0
        Me.Evaluateur_txt.Size = New System.Drawing.Size(176, 26)
        Me.Evaluateur_txt.TabIndex = 209
        Me.Evaluateur_txt.TabStop = False
        Me.Evaluateur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Evaluateur_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(584, 22)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(534, 26)
        Me.Nom_Agent_Text.TabIndex = 211
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Evaluateur
        '
        Me.Evaluateur.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Evaluateur.AutoSize = True
        Me.Evaluateur.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Evaluateur.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Evaluateur.Location = New System.Drawing.Point(309, 25)
        Me.Evaluateur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Evaluateur.Name = "Evaluateur"
        Me.Evaluateur.Size = New System.Drawing.Size(84, 19)
        Me.Evaluateur.TabIndex = 210
        Me.Evaluateur.TabStop = True
        Me.Evaluateur.Tag = "SC"
        Me.Evaluateur.Text = "Evaluateur"
        '
        'Rd2
        '
        Me.Rd2.AutoSize = True
        Me.Rd2.Checked = False
        Me.Rd2.Location = New System.Drawing.Point(268, 21)
        Me.Rd2.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Rd2.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Rd2.MinimumSize = New System.Drawing.Size(0, 25)
        Me.Rd2.Name = "Rd2"
        Me.Rd2.Size = New System.Drawing.Size(142, 25)
        Me.Rd2.TabIndex = 0
        '
        'Rd1
        '
        Me.Rd1.AutoSize = True
        Me.Rd1.Checked = False
        Me.Rd1.Location = New System.Drawing.Point(8, 21)
        Me.Rd1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Rd1.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Rd1.MinimumSize = New System.Drawing.Size(0, 25)
        Me.Rd1.Name = "Rd1"
        Me.Rd1.Size = New System.Drawing.Size(242, 25)
        Me.Rd1.TabIndex = 0
        Me.Rd1.Text = "Supérieur hiérarchique direct"
        '
        'Lib_Survey_txt
        '
        Me.Lib_Survey_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Survey_txt.ContextMenuStrip = Nothing
        Me.Lib_Survey_txt.Location = New System.Drawing.Point(646, 119)
        Me.Lib_Survey_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Lib_Survey_txt.MaxLength = 50
        Me.Lib_Survey_txt.Multiline = False
        Me.Lib_Survey_txt.Name = "Lib_Survey_txt"
        Me.Lib_Survey_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Survey_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Survey_txt.ReadOnly = True
        Me.Lib_Survey_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Survey_txt.SelectionStart = 0
        Me.Lib_Survey_txt.Size = New System.Drawing.Size(534, 26)
        Me.Lib_Survey_txt.TabIndex = 210
        Me.Lib_Survey_txt.Tag = ""
        Me.Lib_Survey_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Survey_txt.UseSystemPasswordChar = False
        '
        'Cod_Survey_txt
        '
        Me.Cod_Survey_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Survey_txt.ContextMenuStrip = Nothing
        Me.Cod_Survey_txt.Location = New System.Drawing.Point(462, 119)
        Me.Cod_Survey_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Cod_Survey_txt.MaxLength = 50
        Me.Cod_Survey_txt.Multiline = False
        Me.Cod_Survey_txt.Name = "Cod_Survey_txt"
        Me.Cod_Survey_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Survey_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Survey_txt.ReadOnly = True
        Me.Cod_Survey_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Survey_txt.SelectionStart = 0
        Me.Cod_Survey_txt.Size = New System.Drawing.Size(176, 26)
        Me.Cod_Survey_txt.TabIndex = 209
        Me.Cod_Survey_txt.Tag = ""
        Me.Cod_Survey_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Survey_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(380, 122)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(80, 19)
        Me.LinkLabel3.TabIndex = 208
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = ""
        Me.LinkLabel3.Text = "Formulaire"
        '
        'Description_txt
        '
        Me.Description_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Description_txt.ContextMenuStrip = Nothing
        Me.Description_txt.Location = New System.Drawing.Point(369, 18)
        Me.Description_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Description_txt.MaxLength = 50
        Me.Description_txt.Multiline = False
        Me.Description_txt.Name = "Description_txt"
        Me.Description_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Description_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Description_txt.ReadOnly = False
        Me.Description_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Description_txt.SelectionStart = 0
        Me.Description_txt.Size = New System.Drawing.Size(660, 26)
        Me.Description_txt.TabIndex = 204
        Me.Description_txt.Tag = ""
        Me.Description_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Description_txt.UseSystemPasswordChar = False
        '
        'Cod_Evaluation_txt
        '
        Me.Cod_Evaluation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Evaluation_txt.ContextMenuStrip = Nothing
        Me.Cod_Evaluation_txt.Location = New System.Drawing.Point(188, 18)
        Me.Cod_Evaluation_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Cod_Evaluation_txt.MaxLength = 50
        Me.Cod_Evaluation_txt.Multiline = False
        Me.Cod_Evaluation_txt.Name = "Cod_Evaluation_txt"
        Me.Cod_Evaluation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Evaluation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Evaluation_txt.ReadOnly = True
        Me.Cod_Evaluation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Evaluation_txt.SelectionStart = 0
        Me.Cod_Evaluation_txt.Size = New System.Drawing.Size(176, 26)
        Me.Cod_Evaluation_txt.TabIndex = 203
        Me.Cod_Evaluation_txt.Tag = ""
        Me.Cod_Evaluation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Evaluation_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(40, 20)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(145, 19)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Action d'évaluation"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(5, 29)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(118, 19)
        Me.LinkLabel2.TabIndex = 220
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = ""
        Me.LinkLabel2.Text = "Entité à évaluer"
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(306, 26)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Entite_txt.MaxLength = 32767
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(374, 26)
        Me.Lib_Entite_txt.TabIndex = 218
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(126, 26)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Entite_txt.MaxLength = 32767
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(176, 26)
        Me.Cod_Entite_txt.TabIndex = 219
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Adv
        '
        Me.Adv.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.Adv.AllowDrop = True
        Me.Adv.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.Adv.BackgroundStyle.Class = "TreeBorderKey"
        Me.Adv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Adv.CheckBoxImageChecked = Global.RHP.My.Resources.Resources.RadioButtonSel
        Me.Adv.CheckBoxImageUnChecked = Global.RHP.My.Resources.Resources.RadioButtonUnsel
        Me.Adv.Columns.Add(Me.Entite)
        Me.Adv.Columns.Add(Me.Grade)
        Me.Adv.Columns.Add(Me.Poste)
        Me.Adv.Columns.Add(Me.Anciennete)
        Me.Adv.Columns.Add(Me.Titre)
        Me.Adv.Columns.Add(Me.Evalue)
        Me.Adv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Adv.Location = New System.Drawing.Point(0, 259)
        Me.Adv.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Adv.Name = "Adv"
        Me.Adv.NodesConnector = Me.NodeConnector1
        Me.Adv.NodeStyle = Me.ElementStyle1
        Me.Adv.PathSeparator = ";"
        Me.Adv.Size = New System.Drawing.Size(1392, 357)
        Me.Adv.Styles.Add(Me.ElementStyle1)
        Me.Adv.TabIndex = 206
        Me.Adv.Text = "AdvTree1"
        '
        'Entite
        '
        Me.Entite.Name = "Entite"
        Me.Entite.Text = "Population à évaluer"
        Me.Entite.Width.Absolute = 400
        '
        'Grade
        '
        Me.Grade.Editable = False
        Me.Grade.Name = "Grade"
        Me.Grade.Text = "Grade"
        Me.Grade.Width.Absolute = 150
        '
        'Poste
        '
        Me.Poste.Editable = False
        Me.Poste.Name = "Poste"
        Me.Poste.Text = "Poste"
        Me.Poste.Width.Absolute = 150
        '
        'Anciennete
        '
        Me.Anciennete.Editable = False
        Me.Anciennete.Name = "Anciennete"
        Me.Anciennete.Text = "Ancienneté"
        Me.Anciennete.Width.Absolute = 65
        '
        'Titre
        '
        Me.Titre.Editable = False
        Me.Titre.Name = "Titre"
        Me.Titre.Text = "Titre"
        Me.Titre.Width.Absolute = 150
        '
        'Evalue
        '
        Me.Evalue.Name = "Evalue"
        Me.Evalue.Text = "Evalué"
        Me.Evalue.Width.Absolute = 45
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'ElementStyle1
        '
        Me.ElementStyle1.Class = ""
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Participants"
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Organisme de financement"
        '
        'CntM
        '
        Me.CntM.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CntM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupprimerLactionToolStripMenuItem})
        Me.CntM.Name = "CntM"
        Me.CntM.Size = New System.Drawing.Size(152, 30)
        '
        'SupprimerLactionToolStripMenuItem
        '
        Me.SupprimerLactionToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.supprimerligne
        Me.SupprimerLactionToolStripMenuItem.Name = "SupprimerLactionToolStripMenuItem"
        Me.SupprimerLactionToolStripMenuItem.Size = New System.Drawing.Size(151, 26)
        Me.SupprimerLactionToolStripMenuItem.Text = "Supprimer"
        '
        'Sous_Entite_chk
        '
        Me.Sous_Entite_chk.AutoSize = True
        Me.Sous_Entite_chk.Checked = True
        Me.Sous_Entite_chk.Location = New System.Drawing.Point(688, 30)
        Me.Sous_Entite_chk.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Sous_Entite_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Sous_Entite_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Sous_Entite_chk.Name = "Sous_Entite_chk"
        Me.Sous_Entite_chk.Size = New System.Drawing.Size(251, 25)
        Me.Sous_Entite_chk.TabIndex = 221
        Me.Sous_Entite_chk.Text = "Est ses sous-entités dépendantes"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Grade_)
        Me.GroupBox3.Controls.Add(Me.Cod_Grade_txt)
        Me.GroupBox3.Controls.Add(Me.Lib_Grade_txt)
        Me.GroupBox3.Controls.Add(Me.Lib_Entite_txt)
        Me.GroupBox3.Controls.Add(Me.Sous_Entite_chk)
        Me.GroupBox3.Controls.Add(Me.Cod_Entite_txt)
        Me.GroupBox3.Controls.Add(Me.LinkLabel2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 161)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(1392, 98)
        Me.GroupBox3.TabIndex = 222
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "A évaluer"
        '
        'Grade_
        '
        Me.Grade_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.AutoSize = True
        Me.Grade_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grade_.Location = New System.Drawing.Point(66, 62)
        Me.Grade_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Grade_.Name = "Grade_"
        Me.Grade_.Size = New System.Drawing.Size(54, 19)
        Me.Grade_.TabIndex = 223
        Me.Grade_.TabStop = True
        Me.Grade_.Tag = "NC"
        Me.Grade_.Text = "Grade"
        '
        'Cod_Grade_txt
        '
        Me.Cod_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Grade_txt.ContextMenuStrip = Nothing
        Me.Cod_Grade_txt.Location = New System.Drawing.Point(126, 59)
        Me.Cod_Grade_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Cod_Grade_txt.MaxLength = 6
        Me.Cod_Grade_txt.Multiline = False
        Me.Cod_Grade_txt.Name = "Cod_Grade_txt"
        Me.Cod_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Grade_txt.ReadOnly = True
        Me.Cod_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Grade_txt.SelectionStart = 0
        Me.Cod_Grade_txt.Size = New System.Drawing.Size(176, 26)
        Me.Cod_Grade_txt.TabIndex = 225
        Me.Cod_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Grade_txt.UseSystemPasswordChar = False
        '
        'Lib_Grade_txt
        '
        Me.Lib_Grade_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_txt.ContextMenuStrip = Nothing
        Me.Lib_Grade_txt.Location = New System.Drawing.Point(306, 59)
        Me.Lib_Grade_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Lib_Grade_txt.MaxLength = 50
        Me.Lib_Grade_txt.Multiline = False
        Me.Lib_Grade_txt.Name = "Lib_Grade_txt"
        Me.Lib_Grade_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_txt.ReadOnly = True
        Me.Lib_Grade_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_txt.SelectionStart = 0
        Me.Lib_Grade_txt.Size = New System.Drawing.Size(374, 26)
        Me.Lib_Grade_txt.TabIndex = 224
        Me.Lib_Grade_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_txt.UseSystemPasswordChar = False
        '
        'Action_Evaluation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1392, 616)
        Me.Controls.Add(Me.Adv)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Action_Evaluation"
        Me.Tag = "ECR"
        Me.Text = "Actions d'évaluation"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CntM.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Description_txt As ud_TextBox
    Friend WithEvents Cod_Evaluation_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Adv As DevComponents.AdvTree.AdvTree
    Friend WithEvents Entite As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Grade As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Poste As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Titre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Anciennete As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents CntM As ContextMenuStrip
    Friend WithEvents SupprimerLactionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Lib_Survey_txt As ud_TextBox
    Friend WithEvents Cod_Survey_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Rd2 As ud_RadioBox
    Friend WithEvents Rd1 As ud_RadioBox
    Friend WithEvents Evaluateur_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Evaluateur As LinkLabel
    Friend WithEvents Dat_Au As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Dat_Du As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Evalue As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Sous_Entite_chk As ud_CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Grade_ As LinkLabel
    Friend WithEvents Cod_Grade_txt As ud_TextBox
    Friend WithEvents Lib_Grade_txt As ud_TextBox
    Friend WithEvents Statut_Evaluation As ud_ComboBox
End Class
