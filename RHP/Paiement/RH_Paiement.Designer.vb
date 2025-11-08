<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Paiement
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Traite_Check = New RHP.ud_CheckBox()
        Me.EntPnl = New System.Windows.Forms.Panel()
        Me.Cpt_Bnk_chk = New RHP.ud_CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Filtre_chk = New RHP.ud_CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.R_BNK1 = New RHP.ud_RadioBox()
        Me.R_BNK0 = New RHP.ud_RadioBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.R_RIB1 = New RHP.ud_RadioBox()
        Me.R_RIB0 = New RHP.ud_RadioBox()
        Me.Dat_Paiement = New System.Windows.Forms.DateTimePicker()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.R_Avance = New RHP.ud_RadioBox()
        Me.R_Paie = New RHP.ud_RadioBox()
        Me.Num_List_Avance_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Cod_Preparation_Text = New RHP.ud_TextBox()
        Me.Cod_Preparation_ = New System.Windows.Forms.LinkLabel()
        Me.Mod_Paiement = New RHP.ud_ComboBox()
        Me.Lib_Paiement_txt = New RHP.ud_TextBox()
        Me.Bank_txt = New RHP.ud_TextBox()
        Me.Cod_Caisse_Bank_Text = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Cod_Paiement_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Grd_Paiement = New RHP.ud_Grd()
        Me.EntPnl.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grd_Paiement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Traite_Check
        '
        Me.Traite_Check.AutoSize = True
        Me.Traite_Check.BackColor = System.Drawing.Color.Transparent
        Me.Traite_Check.Checked = False
        Me.Traite_Check.Enabled = False
        Me.Traite_Check.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Traite_Check.Location = New System.Drawing.Point(174, 82)
        Me.Traite_Check.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Traite_Check.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Traite_Check.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Traite_Check.Name = "Traite_Check"
        Me.Traite_Check.Size = New System.Drawing.Size(146, 31)
        Me.Traite_Check.TabIndex = 6
        Me.Traite_Check.Text = "Paiement servi"
        '
        'EntPnl
        '
        Me.EntPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.EntPnl.Controls.Add(Me.Traite_Check)
        Me.EntPnl.Controls.Add(Me.Cpt_Bnk_chk)
        Me.EntPnl.Controls.Add(Me.GroupBox2)
        Me.EntPnl.Controls.Add(Me.Dat_Paiement)
        Me.EntPnl.Controls.Add(Me.LinkLabel4)
        Me.EntPnl.Controls.Add(Me.GroupBox1)
        Me.EntPnl.Controls.Add(Me.Mod_Paiement)
        Me.EntPnl.Controls.Add(Me.Lib_Paiement_txt)
        Me.EntPnl.Controls.Add(Me.Bank_txt)
        Me.EntPnl.Controls.Add(Me.Cod_Caisse_Bank_Text)
        Me.EntPnl.Controls.Add(Me.LinkLabel2)
        Me.EntPnl.Controls.Add(Me.Cod_Paiement_txt)
        Me.EntPnl.Controls.Add(Me.LinkLabel1)
        Me.EntPnl.Controls.Add(Me.Label2)
        Me.EntPnl.Controls.Add(Me.Label5)
        Me.EntPnl.Controls.Add(Me.Label4)
        Me.EntPnl.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.EntPnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.EntPnl.Location = New System.Drawing.Point(0, 0)
        Me.EntPnl.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.EntPnl.Name = "EntPnl"
        Me.EntPnl.Size = New System.Drawing.Size(1171, 236)
        Me.EntPnl.TabIndex = 210
        '
        'Cpt_Bnk_chk
        '
        Me.Cpt_Bnk_chk.AutoSize = True
        Me.Cpt_Bnk_chk.BackColor = System.Drawing.Color.Transparent
        Me.Cpt_Bnk_chk.Checked = True
        Me.Cpt_Bnk_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cpt_Bnk_chk.Location = New System.Drawing.Point(602, 81)
        Me.Cpt_Bnk_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cpt_Bnk_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Cpt_Bnk_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Cpt_Bnk_chk.Name = "Cpt_Bnk_chk"
        Me.Cpt_Bnk_chk.Size = New System.Drawing.Size(232, 31)
        Me.Cpt_Bnk_chk.TabIndex = 248
        Me.Cpt_Bnk_chk.Text = "Compte bancaire obligatoire"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Filtre_chk)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(452, 106)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(570, 122)
        Me.GroupBox2.TabIndex = 247
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtre rapide"
        '
        'Filtre_chk
        '
        Me.Filtre_chk.AutoSize = True
        Me.Filtre_chk.BackColor = System.Drawing.Color.Transparent
        Me.Filtre_chk.Checked = True
        Me.Filtre_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Filtre_chk.Location = New System.Drawing.Point(415, 35)
        Me.Filtre_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Filtre_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Filtre_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Filtre_chk.Name = "Filtre_chk"
        Me.Filtre_chk.Size = New System.Drawing.Size(146, 31)
        Me.Filtre_chk.TabIndex = 10
        Me.Filtre_chk.Text = "Filtre appliqué"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.R_BNK1)
        Me.GroupBox4.Controls.Add(Me.R_BNK0)
        Me.GroupBox4.Location = New System.Drawing.Point(202, 15)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(202, 95)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        '
        'R_BNK1
        '
        Me.R_BNK1.AutoSize = True
        Me.R_BNK1.Checked = False
        Me.R_BNK1.Location = New System.Drawing.Point(8, 15)
        Me.R_BNK1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.R_BNK1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.R_BNK1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.R_BNK1.Name = "R_BNK1"
        Me.R_BNK1.Size = New System.Drawing.Size(176, 31)
        Me.R_BNK1.TabIndex = 8
        Me.R_BNK1.Text = "Banque renseignée"
        '
        'R_BNK0
        '
        Me.R_BNK0.AutoSize = True
        Me.R_BNK0.Checked = False
        Me.R_BNK0.Location = New System.Drawing.Point(8, 52)
        Me.R_BNK0.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.R_BNK0.MaximumSize = New System.Drawing.Size(0, 31)
        Me.R_BNK0.MinimumSize = New System.Drawing.Size(0, 31)
        Me.R_BNK0.Name = "R_BNK0"
        Me.R_BNK0.Size = New System.Drawing.Size(142, 31)
        Me.R_BNK0.TabIndex = 8
        Me.R_BNK0.Text = "Banque vide"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.R_RIB1)
        Me.GroupBox3.Controls.Add(Me.R_RIB0)
        Me.GroupBox3.Location = New System.Drawing.Point(22, 15)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(174, 95)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'R_RIB1
        '
        Me.R_RIB1.AutoSize = True
        Me.R_RIB1.Checked = False
        Me.R_RIB1.Location = New System.Drawing.Point(8, 15)
        Me.R_RIB1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.R_RIB1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.R_RIB1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.R_RIB1.Name = "R_RIB1"
        Me.R_RIB1.Size = New System.Drawing.Size(142, 31)
        Me.R_RIB1.TabIndex = 8
        Me.R_RIB1.Text = "RIB renseigné"
        '
        'R_RIB0
        '
        Me.R_RIB0.AutoSize = True
        Me.R_RIB0.Checked = False
        Me.R_RIB0.Location = New System.Drawing.Point(8, 52)
        Me.R_RIB0.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.R_RIB0.MaximumSize = New System.Drawing.Size(0, 31)
        Me.R_RIB0.MinimumSize = New System.Drawing.Size(0, 31)
        Me.R_RIB0.Name = "R_RIB0"
        Me.R_RIB0.Size = New System.Drawing.Size(142, 31)
        Me.R_RIB0.TabIndex = 8
        Me.R_RIB0.Text = "RIB vide"
        '
        'Dat_Paiement
        '
        Me.Dat_Paiement.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dat_Paiement.Location = New System.Drawing.Point(895, 49)
        Me.Dat_Paiement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dat_Paiement.Name = "Dat_Paiement"
        Me.Dat_Paiement.Size = New System.Drawing.Size(125, 24)
        Me.Dat_Paiement.TabIndex = 5
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4.Location = New System.Drawing.Point(854, 22)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(39, 19)
        Me.LinkLabel4.TabIndex = 246
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Plan"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.R_Avance)
        Me.GroupBox1.Controls.Add(Me.R_Paie)
        Me.GroupBox1.Controls.Add(Me.Num_List_Avance_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel3)
        Me.GroupBox1.Controls.Add(Me.Cod_Preparation_Text)
        Me.GroupBox1.Controls.Add(Me.Cod_Preparation_)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 106)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(430, 122)
        Me.GroupBox1.TabIndex = 245
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nature"
        '
        'R_Avance
        '
        Me.R_Avance.AutoSize = True
        Me.R_Avance.Checked = False
        Me.R_Avance.Location = New System.Drawing.Point(5, 68)
        Me.R_Avance.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.R_Avance.MaximumSize = New System.Drawing.Size(0, 31)
        Me.R_Avance.MinimumSize = New System.Drawing.Size(0, 31)
        Me.R_Avance.Name = "R_Avance"
        Me.R_Avance.Size = New System.Drawing.Size(142, 31)
        Me.R_Avance.TabIndex = 8
        Me.R_Avance.Text = "Avance"
        '
        'R_Paie
        '
        Me.R_Paie.AutoSize = True
        Me.R_Paie.Checked = False
        Me.R_Paie.Location = New System.Drawing.Point(5, 30)
        Me.R_Paie.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.R_Paie.MaximumSize = New System.Drawing.Size(0, 31)
        Me.R_Paie.MinimumSize = New System.Drawing.Size(0, 31)
        Me.R_Paie.Name = "R_Paie"
        Me.R_Paie.Size = New System.Drawing.Size(142, 31)
        Me.R_Paie.TabIndex = 7
        Me.R_Paie.Text = "Paie"
        '
        'Num_List_Avance_txt
        '
        Me.Num_List_Avance_txt.AccessibleDescription = "A"
        Me.Num_List_Avance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_List_Avance_txt.ContextMenuStrip = Nothing
        Me.Num_List_Avance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_List_Avance_txt.Location = New System.Drawing.Point(264, 66)
        Me.Num_List_Avance_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Num_List_Avance_txt.MaxLength = 32767
        Me.Num_List_Avance_txt.Multiline = False
        Me.Num_List_Avance_txt.Name = "Num_List_Avance_txt"
        Me.Num_List_Avance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_List_Avance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_List_Avance_txt.ReadOnly = True
        Me.Num_List_Avance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_List_Avance_txt.SelectionStart = 0
        Me.Num_List_Avance_txt.Size = New System.Drawing.Size(158, 26)
        Me.Num_List_Avance_txt.TabIndex = 10
        Me.Num_List_Avance_txt.TabStop = False
        Me.Num_List_Avance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_List_Avance_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(195, 69)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(63, 19)
        Me.LinkLabel3.TabIndex = 206
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = ""
        Me.LinkLabel3.Text = "Avance"
        '
        'Cod_Preparation_Text
        '
        Me.Cod_Preparation_Text.AccessibleDescription = "A"
        Me.Cod_Preparation_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Preparation_Text.ContextMenuStrip = Nothing
        Me.Cod_Preparation_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Preparation_Text.Location = New System.Drawing.Point(264, 31)
        Me.Cod_Preparation_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Preparation_Text.MaxLength = 32767
        Me.Cod_Preparation_Text.Multiline = False
        Me.Cod_Preparation_Text.Name = "Cod_Preparation_Text"
        Me.Cod_Preparation_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Preparation_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Preparation_Text.ReadOnly = True
        Me.Cod_Preparation_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Preparation_Text.SelectionStart = 0
        Me.Cod_Preparation_Text.Size = New System.Drawing.Size(158, 26)
        Me.Cod_Preparation_Text.TabIndex = 9
        Me.Cod_Preparation_Text.TabStop = False
        Me.Cod_Preparation_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Preparation_Text.UseSystemPasswordChar = False
        '
        'Cod_Preparation_
        '
        Me.Cod_Preparation_.AutoSize = True
        Me.Cod_Preparation_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Preparation_.LinkColor = System.Drawing.Color.Black
        Me.Cod_Preparation_.Location = New System.Drawing.Point(170, 35)
        Me.Cod_Preparation_.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Cod_Preparation_.Name = "Cod_Preparation_"
        Me.Cod_Preparation_.Size = New System.Drawing.Size(90, 19)
        Me.Cod_Preparation_.TabIndex = 206
        Me.Cod_Preparation_.TabStop = True
        Me.Cod_Preparation_.Tag = ""
        Me.Cod_Preparation_.Text = "Préparation"
        '
        'Mod_Paiement
        '
        Me.Mod_Paiement.DataSource = Nothing
        Me.Mod_Paiement.DisplayMember = ""
        Me.Mod_Paiement.DroppedDown = False
        Me.Mod_Paiement.Location = New System.Drawing.Point(602, 50)
        Me.Mod_Paiement.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Mod_Paiement.Name = "Mod_Paiement"
        Me.Mod_Paiement.SelectedIndex = -1
        Me.Mod_Paiement.SelectedItem = Nothing
        Me.Mod_Paiement.SelectedValue = Nothing
        Me.Mod_Paiement.Size = New System.Drawing.Size(239, 30)
        Me.Mod_Paiement.TabIndex = 3
        Me.Mod_Paiement.ValueMember = ""
        '
        'Lib_Paiement_txt
        '
        Me.Lib_Paiement_txt.AccessibleDescription = "A"
        Me.Lib_Paiement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Paiement_txt.ContextMenuStrip = Nothing
        Me.Lib_Paiement_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Paiement_txt.Location = New System.Drawing.Point(358, 18)
        Me.Lib_Paiement_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Lib_Paiement_txt.MaxLength = 150
        Me.Lib_Paiement_txt.Multiline = False
        Me.Lib_Paiement_txt.Name = "Lib_Paiement_txt"
        Me.Lib_Paiement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Paiement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Paiement_txt.ReadOnly = False
        Me.Lib_Paiement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Paiement_txt.SelectionStart = 0
        Me.Lib_Paiement_txt.Size = New System.Drawing.Size(484, 26)
        Me.Lib_Paiement_txt.TabIndex = 0
        Me.Lib_Paiement_txt.TabStop = False
        Me.Lib_Paiement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Paiement_txt.UseSystemPasswordChar = False
        '
        'Bank_txt
        '
        Me.Bank_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Bank_txt.ContextMenuStrip = Nothing
        Me.Bank_txt.Location = New System.Drawing.Point(424, 52)
        Me.Bank_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Bank_txt.MaxLength = 49
        Me.Bank_txt.Multiline = False
        Me.Bank_txt.Name = "Bank_txt"
        Me.Bank_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Bank_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Bank_txt.ReadOnly = True
        Me.Bank_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Bank_txt.SelectionStart = 0
        Me.Bank_txt.Size = New System.Drawing.Size(116, 26)
        Me.Bank_txt.TabIndex = 2
        Me.Bank_txt.Tag = ""
        Me.Bank_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Bank_txt.UseSystemPasswordChar = False
        '
        'Cod_Caisse_Bank_Text
        '
        Me.Cod_Caisse_Bank_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cod_Caisse_Bank_Text.ContextMenuStrip = Nothing
        Me.Cod_Caisse_Bank_Text.Location = New System.Drawing.Point(174, 50)
        Me.Cod_Caisse_Bank_Text.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Cod_Caisse_Bank_Text.MaxLength = 49
        Me.Cod_Caisse_Bank_Text.Multiline = False
        Me.Cod_Caisse_Bank_Text.Name = "Cod_Caisse_Bank_Text"
        Me.Cod_Caisse_Bank_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Caisse_Bank_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Caisse_Bank_Text.ReadOnly = True
        Me.Cod_Caisse_Bank_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Caisse_Bank_Text.SelectionStart = 0
        Me.Cod_Caisse_Bank_Text.Size = New System.Drawing.Size(176, 26)
        Me.Cod_Caisse_Bank_Text.TabIndex = 1
        Me.Cod_Caisse_Bank_Text.Tag = ""
        Me.Cod_Caisse_Bank_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Caisse_Bank_Text.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(109, 54)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(58, 19)
        Me.LinkLabel2.TabIndex = 242
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Origine"
        '
        'Cod_Paiement_txt
        '
        Me.Cod_Paiement_txt.AccessibleDescription = "A"
        Me.Cod_Paiement_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Paiement_txt.ContextMenuStrip = Nothing
        Me.Cod_Paiement_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Paiement_txt.Location = New System.Drawing.Point(174, 18)
        Me.Cod_Paiement_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Paiement_txt.MaxLength = 32767
        Me.Cod_Paiement_txt.Multiline = False
        Me.Cod_Paiement_txt.Name = "Cod_Paiement_txt"
        Me.Cod_Paiement_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Paiement_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Paiement_txt.ReadOnly = True
        Me.Cod_Paiement_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Paiement_txt.SelectionStart = 0
        Me.Cod_Paiement_txt.Size = New System.Drawing.Size(176, 26)
        Me.Cod_Paiement_txt.TabIndex = 11
        Me.Cod_Paiement_txt.TabStop = False
        Me.Cod_Paiement_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Paiement_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(52, 20)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(120, 19)
        Me.LinkLabel1.TabIndex = 235
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "N° de paiement"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(852, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 19)
        Me.Label2.TabIndex = 234
        Me.Label2.Text = "Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(545, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 19)
        Me.Label5.TabIndex = 234
        Me.Label5.Text = "Moyen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 56)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 234
        Me.Label4.Text = "Banque"
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(895, 18)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Plan_Paie_Text.MaxLength = 50
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(126, 26)
        Me.Cod_Plan_Paie_Text.TabIndex = 4
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Grd_Paiement
        '
        Me.Grd_Paiement.AfficherLesEntetesLignes = True
        Me.Grd_Paiement.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd_Paiement.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Paiement.AlternerLesLignes = False
        Me.Grd_Paiement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Paiement.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Paiement.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Paiement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Paiement.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Paiement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Paiement.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Paiement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Paiement.EnableHeadersVisualStyles = False
        Me.Grd_Paiement.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Paiement.Location = New System.Drawing.Point(0, 236)
        Me.Grd_Paiement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grd_Paiement.Name = "Grd_Paiement"
        Me.Grd_Paiement.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Paiement.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Paiement.RowHeadersWidth = 51
        Me.Grd_Paiement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grd_Paiement.Size = New System.Drawing.Size(1171, 700)
        Me.Grd_Paiement.TabIndex = 225
        '
        'RH_Paiement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1171, 936)
        Me.Controls.Add(Me.Grd_Paiement)
        Me.Controls.Add(Me.EntPnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "RH_Paiement"
        Me.Tag = "ECR"
        Me.Text = "Paiement des salaires et avances"
        Me.EntPnl.ResumeLayout(False)
        Me.EntPnl.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grd_Paiement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EntPnl As Panel
    Friend WithEvents Cod_Preparation_Text As ud_TextBox
    Friend WithEvents Cod_Preparation_ As LinkLabel
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Traite_Check As ud_CheckBox
    Friend WithEvents Cod_Paiement_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Bank_txt As ud_TextBox
    Friend WithEvents Cod_Caisse_Bank_Text As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Grd_Paiement As ud_Grd
    Friend WithEvents Label4 As Label
    Friend WithEvents Lib_Paiement_txt As ud_TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents R_Avance As ud_RadioBox
    Friend WithEvents R_Paie As ud_RadioBox
    Friend WithEvents Num_List_Avance_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Mod_Paiement As ud_ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Dat_Paiement As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents R_BNK1 As ud_RadioBox
    Friend WithEvents R_BNK0 As ud_RadioBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents R_RIB1 As ud_RadioBox
    Friend WithEvents R_RIB0 As ud_RadioBox
    Friend WithEvents Filtre_chk As ud_CheckBox
    Friend WithEvents Cpt_Bnk_chk As ud_CheckBox
End Class
