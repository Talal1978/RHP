Imports System.ComponentModel
Imports System.Runtime.CompilerServices

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DB_Societe
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtDen = New RHP.ud_TextBox()
        Me.lblDen = New System.Windows.Forms.Label()
        Me.cboFJ = New RHP.ud_ComboBox()
        Me.txtCNSS = New RHP.ud_TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTP = New RHP.ud_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRC = New RHP.ud_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIdentFisc = New RHP.ud_TextBox()
        Me.lblIdent = New System.Windows.Forms.Label()
        Me.txtActivite = New RHP.ud_TextBox()
        Me.lblActivite = New System.Windows.Forms.Label()
        Me.lblFj = New System.Windows.Forms.Label()
        Me.txtEmail = New RHP.ud_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFax = New RHP.ud_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTel = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCP = New RHP.ud_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAdresse = New RHP.ud_TextBox()
        Me.Adresse = New System.Windows.Forms.Label()
        Me.Grp3 = New System.Windows.Forms.GroupBox()
        Me.Cod_Pays_ = New System.Windows.Forms.LinkLabel()
        Me.Cod_Pays_Text = New RHP.ud_TextBox()
        Me.Lib_Pays_Text = New RHP.ud_TextBox()
        Me.Cod_Ville_ = New System.Windows.Forms.LinkLabel()
        Me.Cod_Ville_Text = New RHP.ud_TextBox()
        Me.Lib_Ville_Liv_Text = New RHP.ud_TextBox()
        Me.Grp2 = New System.Windows.Forms.GroupBox()
        Me.Cod_Commune_Combo = New RHP.ud_ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Cod_TFP_cbo = New RHP.ud_ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Capital_txt = New RHP.ud_TextBox()
        Me.Capital_lbl = New System.Windows.Forms.Label()
        Me.CNSS_Agence = New RHP.ud_ComboBox()
        Me.txtICE = New RHP.ud_TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Grp1 = New System.Windows.Forms.GroupBox()
        Me.Mis_Sml = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtGroupe = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.idScociete_txt = New RHP.ud_TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Prioritie = New System.Windows.Forms.NumericUpDown()
        Me.oPnl = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Dimanche_chk = New RHP.ud_CheckBox()
        Me.Samedi_chk = New RHP.ud_CheckBox()
        Me.Vendredi_chk = New RHP.ud_CheckBox()
        Me.Jeudi_chk = New RHP.ud_CheckBox()
        Me.Mercredi_chk = New RHP.ud_CheckBox()
        Me.Mardi_chk = New RHP.ud_CheckBox()
        Me.Lundi_chk = New RHP.ud_CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Sequence = New System.Windows.Forms.NumericUpDown()
        Me.Racine_text = New RHP.ud_TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Obliger_Demande_Pret_chk = New RHP.ud_CheckBox()
        Me.Masquer_Element_Paie_Agent_chk = New RHP.ud_CheckBox()
        Me.Compteur_Auto = New RHP.ud_CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDroits = New System.Windows.Forms.Button()
        Me.txtDroits = New RHP.ud_TextBox()
        Me.Grd_JoursFeries = New RHP.ud_Grd()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Grd_Soc = New RHP.ud_Grd()
        Me.DPI = New DevComponents.DotNetBar.ButtonItem()
        Me.Grp3.SuspendLayout()
        Me.Grp2.SuspendLayout()
        Me.Grp1.SuspendLayout()
        CType(Me.Prioritie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.oPnl.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Sequence, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grd_JoursFeries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.Grd_Soc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDen
        '
        Me.txtDen.AutoSize = True
        Me.txtDen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDen.ContextMenuStrip = Nothing
        Me.txtDen.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDen.Location = New System.Drawing.Point(120, 54)
        Me.txtDen.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDen.MaxLength = 300
        Me.txtDen.Multiline = False
        Me.txtDen.Name = "txtDen"
        Me.txtDen.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtDen.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDen.ReadOnly = False
        Me.txtDen.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDen.SelectionStart = 0
        Me.txtDen.Size = New System.Drawing.Size(308, 26)
        Me.txtDen.TabIndex = 0
        Me.txtDen.Tag = "0"
        Me.txtDen.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDen.UseSystemPasswordChar = False
        '
        'lblDen
        '
        Me.lblDen.AutoSize = True
        Me.lblDen.BackColor = System.Drawing.Color.Transparent
        Me.lblDen.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.lblDen.Location = New System.Drawing.Point(12, 56)
        Me.lblDen.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDen.Name = "lblDen"
        Me.lblDen.Size = New System.Drawing.Size(106, 19)
        Me.lblDen.TabIndex = 10
        Me.lblDen.Text = "Raison sociale"
        '
        'cboFJ
        '
        Me.cboFJ.BackColor = System.Drawing.Color.White
        Me.cboFJ.DataSource = Nothing
        Me.cboFJ.DisplayMember = ""
        Me.cboFJ.DroppedDown = False
        Me.cboFJ.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFJ.Location = New System.Drawing.Point(120, 84)
        Me.cboFJ.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFJ.Name = "cboFJ"
        Me.cboFJ.SelectedIndex = -1
        Me.cboFJ.SelectedItem = Nothing
        Me.cboFJ.SelectedValue = Nothing
        Me.cboFJ.Size = New System.Drawing.Size(308, 30)
        Me.cboFJ.TabIndex = 1
        Me.cboFJ.ValueMember = ""
        '
        'txtCNSS
        '
        Me.txtCNSS.AutoSize = True
        Me.txtCNSS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtCNSS.ContextMenuStrip = Nothing
        Me.txtCNSS.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCNSS.Location = New System.Drawing.Point(91, 80)
        Me.txtCNSS.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCNSS.MaxLength = 8
        Me.txtCNSS.Multiline = False
        Me.txtCNSS.Name = "txtCNSS"
        Me.txtCNSS.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtCNSS.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCNSS.ReadOnly = False
        Me.txtCNSS.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCNSS.SelectionStart = 0
        Me.txtCNSS.Size = New System.Drawing.Size(164, 26)
        Me.txtCNSS.TabIndex = 18
        Me.txtCNSS.Tag = "7"
        Me.txtCNSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCNSS.UseSystemPasswordChar = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 84)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 19)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "N° CNSS "
        '
        'txtTP
        '
        Me.txtTP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTP.AutoSize = True
        Me.txtTP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTP.ContextMenuStrip = Nothing
        Me.txtTP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTP.Location = New System.Drawing.Point(360, 50)
        Me.txtTP.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTP.MaxLength = 10
        Me.txtTP.Multiline = False
        Me.txtTP.Name = "txtTP"
        Me.txtTP.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtTP.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTP.ReadOnly = False
        Me.txtTP.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtTP.SelectionStart = 0
        Me.txtTP.Size = New System.Drawing.Size(148, 26)
        Me.txtTP.TabIndex = 17
        Me.txtTP.Tag = "6"
        Me.txtTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTP.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(330, 54)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 19)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "TP"
        '
        'txtRC
        '
        Me.txtRC.AutoSize = True
        Me.txtRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtRC.ContextMenuStrip = Nothing
        Me.txtRC.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRC.Location = New System.Drawing.Point(91, 50)
        Me.txtRC.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRC.MaxLength = 10
        Me.txtRC.Multiline = False
        Me.txtRC.Name = "txtRC"
        Me.txtRC.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtRC.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRC.ReadOnly = False
        Me.txtRC.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtRC.SelectionStart = 0
        Me.txtRC.Size = New System.Drawing.Size(164, 26)
        Me.txtRC.TabIndex = 16
        Me.txtRC.Tag = "5"
        Me.txtRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtRC.UseSystemPasswordChar = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(35, 54)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 19)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "N° RC "
        '
        'txtIdentFisc
        '
        Me.txtIdentFisc.AutoSize = True
        Me.txtIdentFisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtIdentFisc.ContextMenuStrip = Nothing
        Me.txtIdentFisc.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdentFisc.Location = New System.Drawing.Point(91, 20)
        Me.txtIdentFisc.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIdentFisc.MaxLength = 10
        Me.txtIdentFisc.Multiline = False
        Me.txtIdentFisc.Name = "txtIdentFisc"
        Me.txtIdentFisc.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtIdentFisc.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIdentFisc.ReadOnly = False
        Me.txtIdentFisc.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtIdentFisc.SelectionStart = 0
        Me.txtIdentFisc.Size = New System.Drawing.Size(164, 26)
        Me.txtIdentFisc.TabIndex = 14
        Me.txtIdentFisc.Tag = "4"
        Me.txtIdentFisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtIdentFisc.UseSystemPasswordChar = False
        '
        'lblIdent
        '
        Me.lblIdent.AutoSize = True
        Me.lblIdent.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdent.Location = New System.Drawing.Point(46, 24)
        Me.lblIdent.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblIdent.Name = "lblIdent"
        Me.lblIdent.Size = New System.Drawing.Size(43, 19)
        Me.lblIdent.TabIndex = 18
        Me.lblIdent.Text = "N° IF "
        '
        'txtActivite
        '
        Me.txtActivite.AutoSize = True
        Me.txtActivite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActivite.ContextMenuStrip = Nothing
        Me.txtActivite.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActivite.Location = New System.Drawing.Point(120, 118)
        Me.txtActivite.Margin = New System.Windows.Forms.Padding(2)
        Me.txtActivite.MaxLength = 50
        Me.txtActivite.Multiline = False
        Me.txtActivite.Name = "txtActivite"
        Me.txtActivite.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtActivite.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtActivite.ReadOnly = False
        Me.txtActivite.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtActivite.SelectionStart = 0
        Me.txtActivite.Size = New System.Drawing.Size(308, 26)
        Me.txtActivite.TabIndex = 2
        Me.txtActivite.Tag = ""
        Me.txtActivite.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtActivite.UseSystemPasswordChar = False
        '
        'lblActivite
        '
        Me.lblActivite.AutoSize = True
        Me.lblActivite.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivite.Location = New System.Drawing.Point(58, 120)
        Me.lblActivite.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblActivite.Name = "lblActivite"
        Me.lblActivite.Size = New System.Drawing.Size(60, 19)
        Me.lblActivite.TabIndex = 16
        Me.lblActivite.Text = "Activité"
        '
        'lblFj
        '
        Me.lblFj.AutoSize = True
        Me.lblFj.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFj.Location = New System.Drawing.Point(5, 88)
        Me.lblFj.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFj.Name = "lblFj"
        Me.lblFj.Size = New System.Drawing.Size(115, 19)
        Me.lblFj.TabIndex = 12
        Me.lblFj.Text = "Forme juridique"
        '
        'txtEmail
        '
        Me.txtEmail.AutoSize = True
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtEmail.ContextMenuStrip = Nothing
        Me.txtEmail.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(88, 289)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Multiline = False
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtEmail.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEmail.ReadOnly = False
        Me.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtEmail.SelectionStart = 0
        Me.txtEmail.Size = New System.Drawing.Size(520, 26)
        Me.txtEmail.TabIndex = 13
        Me.txtEmail.Tag = "13"
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtEmail.UseSystemPasswordChar = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 292)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 19)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "E-mail"
        '
        'txtFax
        '
        Me.txtFax.AutoSize = True
        Me.txtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtFax.ContextMenuStrip = Nothing
        Me.txtFax.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFax.Location = New System.Drawing.Point(88, 260)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFax.MaxLength = 20
        Me.txtFax.Multiline = False
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtFax.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFax.ReadOnly = False
        Me.txtFax.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtFax.SelectionStart = 0
        Me.txtFax.Size = New System.Drawing.Size(520, 26)
        Me.txtFax.TabIndex = 12
        Me.txtFax.Tag = "12"
        Me.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFax.UseSystemPasswordChar = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 262)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 19)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Fax"
        '
        'txtTel
        '
        Me.txtTel.AutoSize = True
        Me.txtTel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTel.ContextMenuStrip = Nothing
        Me.txtTel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTel.Location = New System.Drawing.Point(88, 231)
        Me.txtTel.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTel.MaxLength = 20
        Me.txtTel.Multiline = False
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtTel.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTel.ReadOnly = False
        Me.txtTel.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtTel.SelectionStart = 0
        Me.txtTel.Size = New System.Drawing.Size(520, 26)
        Me.txtTel.TabIndex = 11
        Me.txtTel.Tag = "11"
        Me.txtTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTel.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1, 235)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 19)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Téléphone"
        '
        'txtCP
        '
        Me.txtCP.AutoSize = True
        Me.txtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtCP.ContextMenuStrip = Nothing
        Me.txtCP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCP.Location = New System.Drawing.Point(88, 201)
        Me.txtCP.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCP.MaxLength = 10
        Me.txtCP.Multiline = False
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtCP.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCP.ReadOnly = False
        Me.txtCP.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCP.SelectionStart = 0
        Me.txtCP.Size = New System.Drawing.Size(168, 26)
        Me.txtCP.TabIndex = 10
        Me.txtCP.Tag = "9"
        Me.txtCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCP.UseSystemPasswordChar = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 205)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 19)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Code Postal"
        '
        'txtAdresse
        '
        Me.txtAdresse.AutoSize = True
        Me.txtAdresse.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtAdresse.ContextMenuStrip = Nothing
        Me.txtAdresse.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdresse.Location = New System.Drawing.Point(89, 19)
        Me.txtAdresse.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAdresse.MaxLength = 500
        Me.txtAdresse.Multiline = True
        Me.txtAdresse.Name = "txtAdresse"
        Me.txtAdresse.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtAdresse.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAdresse.ReadOnly = False
        Me.txtAdresse.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtAdresse.SelectionStart = 0
        Me.txtAdresse.Size = New System.Drawing.Size(520, 114)
        Me.txtAdresse.TabIndex = 7
        Me.txtAdresse.Tag = "8"
        Me.txtAdresse.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtAdresse.UseSystemPasswordChar = False
        '
        'Adresse
        '
        Me.Adresse.AutoSize = True
        Me.Adresse.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Adresse.Location = New System.Drawing.Point(21, 22)
        Me.Adresse.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Adresse.Name = "Adresse"
        Me.Adresse.Size = New System.Drawing.Size(64, 19)
        Me.Adresse.TabIndex = 24
        Me.Adresse.Text = "Adresse "
        '
        'Grp3
        '
        Me.Grp3.Controls.Add(Me.Cod_Pays_)
        Me.Grp3.Controls.Add(Me.Cod_Pays_Text)
        Me.Grp3.Controls.Add(Me.Lib_Pays_Text)
        Me.Grp3.Controls.Add(Me.Cod_Ville_)
        Me.Grp3.Controls.Add(Me.Cod_Ville_Text)
        Me.Grp3.Controls.Add(Me.Lib_Ville_Liv_Text)
        Me.Grp3.Controls.Add(Me.txtAdresse)
        Me.Grp3.Controls.Add(Me.txtEmail)
        Me.Grp3.Controls.Add(Me.Label3)
        Me.Grp3.Controls.Add(Me.Label4)
        Me.Grp3.Controls.Add(Me.txtFax)
        Me.Grp3.Controls.Add(Me.txtTel)
        Me.Grp3.Controls.Add(Me.Adresse)
        Me.Grp3.Controls.Add(Me.Label5)
        Me.Grp3.Controls.Add(Me.txtCP)
        Me.Grp3.Controls.Add(Me.Label8)
        Me.Grp3.Location = New System.Drawing.Point(7, 260)
        Me.Grp3.Margin = New System.Windows.Forms.Padding(2)
        Me.Grp3.Name = "Grp3"
        Me.Grp3.Padding = New System.Windows.Forms.Padding(2)
        Me.Grp3.Size = New System.Drawing.Size(629, 341)
        Me.Grp3.TabIndex = 101
        Me.Grp3.TabStop = False
        Me.Grp3.Text = "Adresse"
        '
        'Cod_Pays_
        '
        Me.Cod_Pays_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Pays_.AutoSize = True
        Me.Cod_Pays_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Pays_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Pays_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Pays_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Pays_.Location = New System.Drawing.Point(45, 140)
        Me.Cod_Pays_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Cod_Pays_.Name = "Cod_Pays_"
        Me.Cod_Pays_.Size = New System.Drawing.Size(40, 19)
        Me.Cod_Pays_.TabIndex = 8
        Me.Cod_Pays_.TabStop = True
        Me.Cod_Pays_.Tag = "NC"
        Me.Cod_Pays_.Text = "Pays"
        '
        'Cod_Pays_Text
        '
        Me.Cod_Pays_Text.AutoSize = True
        Me.Cod_Pays_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Pays_Text.ContextMenuStrip = Nothing
        Me.Cod_Pays_Text.Location = New System.Drawing.Point(90, 138)
        Me.Cod_Pays_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Cod_Pays_Text.MaxLength = 32767
        Me.Cod_Pays_Text.Multiline = False
        Me.Cod_Pays_Text.Name = "Cod_Pays_Text"
        Me.Cod_Pays_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Pays_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Pays_Text.ReadOnly = True
        Me.Cod_Pays_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Pays_Text.SelectionStart = 0
        Me.Cod_Pays_Text.Size = New System.Drawing.Size(98, 26)
        Me.Cod_Pays_Text.TabIndex = 220
        Me.Cod_Pays_Text.TabStop = False
        Me.Cod_Pays_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Pays_Text.UseSystemPasswordChar = False
        '
        'Lib_Pays_Text
        '
        Me.Lib_Pays_Text.AccessibleDescription = "A"
        Me.Lib_Pays_Text.AutoSize = True
        Me.Lib_Pays_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Pays_Text.ContextMenuStrip = Nothing
        Me.Lib_Pays_Text.Location = New System.Drawing.Point(190, 138)
        Me.Lib_Pays_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Lib_Pays_Text.MaxLength = 32767
        Me.Lib_Pays_Text.Multiline = False
        Me.Lib_Pays_Text.Name = "Lib_Pays_Text"
        Me.Lib_Pays_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Pays_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Pays_Text.ReadOnly = True
        Me.Lib_Pays_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Pays_Text.SelectionStart = 0
        Me.Lib_Pays_Text.Size = New System.Drawing.Size(418, 26)
        Me.Lib_Pays_Text.TabIndex = 219
        Me.Lib_Pays_Text.TabStop = False
        Me.Lib_Pays_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Pays_Text.UseSystemPasswordChar = False
        '
        'Cod_Ville_
        '
        Me.Cod_Ville_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Ville_.AutoSize = True
        Me.Cod_Ville_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Ville_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Ville_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Ville_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Ville_.Location = New System.Drawing.Point(51, 171)
        Me.Cod_Ville_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Cod_Ville_.Name = "Cod_Ville_"
        Me.Cod_Ville_.Size = New System.Drawing.Size(36, 19)
        Me.Cod_Ville_.TabIndex = 9
        Me.Cod_Ville_.TabStop = True
        Me.Cod_Ville_.Tag = "NC"
        Me.Cod_Ville_.Text = "Ville"
        '
        'Cod_Ville_Text
        '
        Me.Cod_Ville_Text.AutoSize = True
        Me.Cod_Ville_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Ville_Text.ContextMenuStrip = Nothing
        Me.Cod_Ville_Text.Location = New System.Drawing.Point(90, 169)
        Me.Cod_Ville_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Cod_Ville_Text.MaxLength = 6
        Me.Cod_Ville_Text.Multiline = False
        Me.Cod_Ville_Text.Name = "Cod_Ville_Text"
        Me.Cod_Ville_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Ville_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Ville_Text.ReadOnly = True
        Me.Cod_Ville_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Ville_Text.SelectionStart = 0
        Me.Cod_Ville_Text.Size = New System.Drawing.Size(98, 26)
        Me.Cod_Ville_Text.TabIndex = 217
        Me.Cod_Ville_Text.TabStop = False
        Me.Cod_Ville_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Ville_Text.UseSystemPasswordChar = False
        '
        'Lib_Ville_Liv_Text
        '
        Me.Lib_Ville_Liv_Text.AutoSize = True
        Me.Lib_Ville_Liv_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Ville_Liv_Text.ContextMenuStrip = Nothing
        Me.Lib_Ville_Liv_Text.Location = New System.Drawing.Point(190, 169)
        Me.Lib_Ville_Liv_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Lib_Ville_Liv_Text.MaxLength = 50
        Me.Lib_Ville_Liv_Text.Multiline = False
        Me.Lib_Ville_Liv_Text.Name = "Lib_Ville_Liv_Text"
        Me.Lib_Ville_Liv_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Ville_Liv_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Ville_Liv_Text.ReadOnly = True
        Me.Lib_Ville_Liv_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Ville_Liv_Text.SelectionStart = 0
        Me.Lib_Ville_Liv_Text.Size = New System.Drawing.Size(419, 26)
        Me.Lib_Ville_Liv_Text.TabIndex = 216
        Me.Lib_Ville_Liv_Text.TabStop = False
        Me.Lib_Ville_Liv_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Ville_Liv_Text.UseSystemPasswordChar = False
        '
        'Grp2
        '
        Me.Grp2.Controls.Add(Me.Cod_Commune_Combo)
        Me.Grp2.Controls.Add(Me.Label13)
        Me.Grp2.Controls.Add(Me.Cod_TFP_cbo)
        Me.Grp2.Controls.Add(Me.Label2)
        Me.Grp2.Controls.Add(Me.Label19)
        Me.Grp2.Controls.Add(Me.Capital_txt)
        Me.Grp2.Controls.Add(Me.Capital_lbl)
        Me.Grp2.Controls.Add(Me.CNSS_Agence)
        Me.Grp2.Controls.Add(Me.txtICE)
        Me.Grp2.Controls.Add(Me.Label16)
        Me.Grp2.Controls.Add(Me.txtIdentFisc)
        Me.Grp2.Controls.Add(Me.txtCNSS)
        Me.Grp2.Controls.Add(Me.txtTP)
        Me.Grp2.Controls.Add(Me.lblIdent)
        Me.Grp2.Controls.Add(Me.Label10)
        Me.Grp2.Controls.Add(Me.Label7)
        Me.Grp2.Controls.Add(Me.txtRC)
        Me.Grp2.Controls.Add(Me.Label6)
        Me.Grp2.Location = New System.Drawing.Point(459, 8)
        Me.Grp2.Margin = New System.Windows.Forms.Padding(2)
        Me.Grp2.Name = "Grp2"
        Me.Grp2.Padding = New System.Windows.Forms.Padding(2)
        Me.Grp2.Size = New System.Drawing.Size(552, 248)
        Me.Grp2.TabIndex = 101
        Me.Grp2.TabStop = False
        Me.Grp2.Text = "Références légales"
        '
        'Cod_Commune_Combo
        '
        Me.Cod_Commune_Combo.DataSource = Nothing
        Me.Cod_Commune_Combo.DisplayMember = ""
        Me.Cod_Commune_Combo.DroppedDown = False
        Me.Cod_Commune_Combo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cod_Commune_Combo.Location = New System.Drawing.Point(92, 190)
        Me.Cod_Commune_Combo.Margin = New System.Windows.Forms.Padding(4)
        Me.Cod_Commune_Combo.Name = "Cod_Commune_Combo"
        Me.Cod_Commune_Combo.SelectedIndex = -1
        Me.Cod_Commune_Combo.SelectedItem = Nothing
        Me.Cod_Commune_Combo.SelectedValue = Nothing
        Me.Cod_Commune_Combo.Size = New System.Drawing.Size(416, 27)
        Me.Cod_Commune_Combo.TabIndex = 186
        Me.Cod_Commune_Combo.ValueMember = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 194)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 19)
        Me.Label13.TabIndex = 185
        Me.Label13.Text = "Commune :"
        '
        'Cod_TFP_cbo
        '
        Me.Cod_TFP_cbo.DataSource = Nothing
        Me.Cod_TFP_cbo.DisplayMember = ""
        Me.Cod_TFP_cbo.DroppedDown = False
        Me.Cod_TFP_cbo.Location = New System.Drawing.Point(91, 150)
        Me.Cod_TFP_cbo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_TFP_cbo.Name = "Cod_TFP_cbo"
        Me.Cod_TFP_cbo.SelectedIndex = -1
        Me.Cod_TFP_cbo.SelectedItem = Nothing
        Me.Cod_TFP_cbo.SelectedValue = Nothing
        Me.Cod_TFP_cbo.Size = New System.Drawing.Size(416, 31)
        Me.Cod_TFP_cbo.TabIndex = 184
        Me.Cod_TFP_cbo.ValueMember = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 152)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 19)
        Me.Label2.TabIndex = 183
        Me.Label2.Text = "Tx frais prof."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(24, 116)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 19)
        Me.Label19.TabIndex = 182
        Me.Label19.Text = "Agence"
        '
        'Capital_txt
        '
        Me.Capital_txt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Capital_txt.AutoSize = True
        Me.Capital_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Capital_txt.ContextMenuStrip = Nothing
        Me.Capital_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Capital_txt.Location = New System.Drawing.Point(360, 80)
        Me.Capital_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.Capital_txt.MaxLength = 15
        Me.Capital_txt.Multiline = False
        Me.Capital_txt.Name = "Capital_txt"
        Me.Capital_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Capital_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Capital_txt.ReadOnly = False
        Me.Capital_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Capital_txt.SelectionStart = 0
        Me.Capital_txt.Size = New System.Drawing.Size(148, 26)
        Me.Capital_txt.TabIndex = 19
        Me.Capital_txt.Tag = "7"
        Me.Capital_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Capital_txt.UseSystemPasswordChar = False
        '
        'Capital_lbl
        '
        Me.Capital_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Capital_lbl.AutoSize = True
        Me.Capital_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Capital_lbl.Location = New System.Drawing.Point(295, 84)
        Me.Capital_lbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Capital_lbl.Name = "Capital_lbl"
        Me.Capital_lbl.Size = New System.Drawing.Size(61, 19)
        Me.Capital_lbl.TabIndex = 181
        Me.Capital_lbl.Text = "Capital"
        '
        'CNSS_Agence
        '
        Me.CNSS_Agence.DataSource = Nothing
        Me.CNSS_Agence.DisplayMember = ""
        Me.CNSS_Agence.DroppedDown = False
        Me.CNSS_Agence.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CNSS_Agence.Location = New System.Drawing.Point(91, 111)
        Me.CNSS_Agence.Margin = New System.Windows.Forms.Padding(2)
        Me.CNSS_Agence.Name = "CNSS_Agence"
        Me.CNSS_Agence.SelectedIndex = -1
        Me.CNSS_Agence.SelectedItem = Nothing
        Me.CNSS_Agence.SelectedValue = Nothing
        Me.CNSS_Agence.Size = New System.Drawing.Size(416, 30)
        Me.CNSS_Agence.TabIndex = 20
        Me.CNSS_Agence.ValueMember = ""
        '
        'txtICE
        '
        Me.txtICE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtICE.AutoSize = True
        Me.txtICE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtICE.ContextMenuStrip = Nothing
        Me.txtICE.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtICE.Location = New System.Drawing.Point(360, 20)
        Me.txtICE.Margin = New System.Windows.Forms.Padding(2)
        Me.txtICE.MaxLength = 15
        Me.txtICE.Multiline = False
        Me.txtICE.Name = "txtICE"
        Me.txtICE.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtICE.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtICE.ReadOnly = False
        Me.txtICE.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtICE.SelectionStart = 0
        Me.txtICE.Size = New System.Drawing.Size(148, 26)
        Me.txtICE.TabIndex = 15
        Me.txtICE.Tag = "7"
        Me.txtICE.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtICE.UseSystemPasswordChar = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(319, 22)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 19)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "ICE "
        '
        'Grp1
        '
        Me.Grp1.Controls.Add(Me.Mis_Sml)
        Me.Grp1.Controls.Add(Me.Label9)
        Me.Grp1.Controls.Add(Me.Label20)
        Me.Grp1.Controls.Add(Me.txtGroupe)
        Me.Grp1.Controls.Add(Me.Label1)
        Me.Grp1.Controls.Add(Me.idScociete_txt)
        Me.Grp1.Controls.Add(Me.txtDen)
        Me.Grp1.Controls.Add(Me.lblFj)
        Me.Grp1.Controls.Add(Me.Label23)
        Me.Grp1.Controls.Add(Me.Prioritie)
        Me.Grp1.Controls.Add(Me.lblDen)
        Me.Grp1.Controls.Add(Me.lblActivite)
        Me.Grp1.Controls.Add(Me.cboFJ)
        Me.Grp1.Controls.Add(Me.txtActivite)
        Me.Grp1.Location = New System.Drawing.Point(10, 6)
        Me.Grp1.Margin = New System.Windows.Forms.Padding(2)
        Me.Grp1.Name = "Grp1"
        Me.Grp1.Padding = New System.Windows.Forms.Padding(2)
        Me.Grp1.Size = New System.Drawing.Size(444, 250)
        Me.Grp1.TabIndex = 100
        Me.Grp1.TabStop = False
        Me.Grp1.Text = "Fiche d'identité"
        '
        'Mis_Sml
        '
        '
        '
        '
        Me.Mis_Sml.BackgroundStyle.Class = ""
        Me.Mis_Sml.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Mis_Sml.Location = New System.Drawing.Point(333, 196)
        Me.Mis_Sml.Name = "Mis_Sml"
        Me.Mis_Sml.OffBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Mis_Sml.OffText = "Active"
        Me.Mis_Sml.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Mis_Sml.OnBackColor = System.Drawing.Color.Silver
        Me.Mis_Sml.OnText = "Sommeil"
        Me.Mis_Sml.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Mis_Sml.Size = New System.Drawing.Size(91, 27)
        Me.Mis_Sml.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Mis_Sml.TabIndex = 47
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(152, 200)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(175, 19)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Société mise en sommeil"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(54, 150)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 19)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "Groupe"
        '
        'txtGroupe
        '
        Me.txtGroupe.AutoSize = True
        Me.txtGroupe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGroupe.ContextMenuStrip = Nothing
        Me.txtGroupe.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupe.Location = New System.Drawing.Point(120, 148)
        Me.txtGroupe.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGroupe.MaxLength = 200
        Me.txtGroupe.Multiline = False
        Me.txtGroupe.Name = "txtGroupe"
        Me.txtGroupe.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtGroupe.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtGroupe.ReadOnly = False
        Me.txtGroupe.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtGroupe.SelectionStart = 0
        Me.txtGroupe.Size = New System.Drawing.Size(308, 26)
        Me.txtGroupe.TabIndex = 6
        Me.txtGroupe.Tag = "3"
        Me.txtGroupe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtGroupe.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(282, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 19)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Priorité"
        '
        'idScociete_txt
        '
        Me.idScociete_txt.AutoSize = True
        Me.idScociete_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.idScociete_txt.ContextMenuStrip = Nothing
        Me.idScociete_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idScociete_txt.Location = New System.Drawing.Point(120, 24)
        Me.idScociete_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.idScociete_txt.MaxLength = 300
        Me.idScociete_txt.Multiline = False
        Me.idScociete_txt.Name = "idScociete_txt"
        Me.idScociete_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.idScociete_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.idScociete_txt.ReadOnly = True
        Me.idScociete_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.idScociete_txt.SelectionStart = 0
        Me.idScociete_txt.Size = New System.Drawing.Size(130, 26)
        Me.idScociete_txt.TabIndex = 0
        Me.idScociete_txt.Tag = "0"
        Me.idScociete_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.idScociete_txt.UseSystemPasswordChar = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(42, 28)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(75, 19)
        Me.Label23.TabIndex = 10
        Me.Label23.Text = "id société"
        '
        'Prioritie
        '
        Me.Prioritie.Location = New System.Drawing.Point(342, 25)
        Me.Prioritie.Margin = New System.Windows.Forms.Padding(2)
        Me.Prioritie.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.Prioritie.Name = "Prioritie"
        Me.Prioritie.Size = New System.Drawing.Size(82, 24)
        Me.Prioritie.TabIndex = 1
        Me.Prioritie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'oPnl
        '
        Me.oPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.oPnl.Controls.Add(Me.TabControl1)
        Me.oPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.oPnl.Location = New System.Drawing.Point(0, 0)
        Me.oPnl.Margin = New System.Windows.Forms.Padding(2)
        Me.oPnl.Name = "oPnl"
        Me.oPnl.Size = New System.Drawing.Size(1035, 661)
        Me.oPnl.TabIndex = 50
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1035, 661)
        Me.TabControl1.TabIndex = 21
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Grp1)
        Me.TabPage1.Controls.Add(Me.Grp2)
        Me.TabPage1.Controls.Add(Me.Grp3)
        Me.TabPage1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(1027, 629)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Fiche Société"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Panel1.Controls.Add(Me.pbLogo)
        Me.Panel1.Location = New System.Drawing.Point(640, 270)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(371, 331)
        Me.Panel1.TabIndex = 105
        '
        'pbLogo
        '
        Me.pbLogo.BackColor = System.Drawing.SystemColors.Control
        Me.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbLogo.Location = New System.Drawing.Point(1, 1)
        Me.pbLogo.Margin = New System.Windows.Forms.Padding(2)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(369, 329)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbLogo.TabIndex = 104
        Me.pbLogo.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(1027, 629)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Paramètres généraux"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grd_JoursFeries)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox6)
        Me.SplitContainer1.Size = New System.Drawing.Size(1023, 625)
        Me.SplitContainer1.SplitterDistance = 546
        Me.SplitContainer1.TabIndex = 108
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Dimanche_chk)
        Me.GroupBox5.Controls.Add(Me.Samedi_chk)
        Me.GroupBox5.Controls.Add(Me.Vendredi_chk)
        Me.GroupBox5.Controls.Add(Me.Jeudi_chk)
        Me.GroupBox5.Controls.Add(Me.Mercredi_chk)
        Me.GroupBox5.Controls.Add(Me.Mardi_chk)
        Me.GroupBox5.Controls.Add(Me.Lundi_chk)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(0, 315)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(546, 95)
        Me.GroupBox5.TabIndex = 116
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Jours ouvrables"
        '
        'Dimanche_chk
        '
        Me.Dimanche_chk.AutoSize = True
        Me.Dimanche_chk.Checked = True
        Me.Dimanche_chk.Location = New System.Drawing.Point(385, 31)
        Me.Dimanche_chk.Margin = New System.Windows.Forms.Padding(2)
        Me.Dimanche_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Dimanche_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Dimanche_chk.Name = "Dimanche_chk"
        Me.Dimanche_chk.Size = New System.Drawing.Size(125, 25)
        Me.Dimanche_chk.TabIndex = 120
        Me.Dimanche_chk.Text = "Dimanche"
        '
        'Samedi_chk
        '
        Me.Samedi_chk.AutoSize = True
        Me.Samedi_chk.Checked = True
        Me.Samedi_chk.Location = New System.Drawing.Point(271, 58)
        Me.Samedi_chk.Margin = New System.Windows.Forms.Padding(2)
        Me.Samedi_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Samedi_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Samedi_chk.Name = "Samedi_chk"
        Me.Samedi_chk.Size = New System.Drawing.Size(125, 25)
        Me.Samedi_chk.TabIndex = 119
        Me.Samedi_chk.Text = "Samedi"
        '
        'Vendredi_chk
        '
        Me.Vendredi_chk.AutoSize = True
        Me.Vendredi_chk.Checked = True
        Me.Vendredi_chk.Location = New System.Drawing.Point(271, 31)
        Me.Vendredi_chk.Margin = New System.Windows.Forms.Padding(2)
        Me.Vendredi_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Vendredi_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Vendredi_chk.Name = "Vendredi_chk"
        Me.Vendredi_chk.Size = New System.Drawing.Size(125, 25)
        Me.Vendredi_chk.TabIndex = 118
        Me.Vendredi_chk.Text = "Vendredi"
        '
        'Jeudi_chk
        '
        Me.Jeudi_chk.AutoSize = True
        Me.Jeudi_chk.Checked = True
        Me.Jeudi_chk.Location = New System.Drawing.Point(156, 58)
        Me.Jeudi_chk.Margin = New System.Windows.Forms.Padding(2)
        Me.Jeudi_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Jeudi_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Jeudi_chk.Name = "Jeudi_chk"
        Me.Jeudi_chk.Size = New System.Drawing.Size(125, 25)
        Me.Jeudi_chk.TabIndex = 117
        Me.Jeudi_chk.Text = "Jeudi"
        '
        'Mercredi_chk
        '
        Me.Mercredi_chk.AutoSize = True
        Me.Mercredi_chk.Checked = True
        Me.Mercredi_chk.Location = New System.Drawing.Point(156, 31)
        Me.Mercredi_chk.Margin = New System.Windows.Forms.Padding(2)
        Me.Mercredi_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Mercredi_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Mercredi_chk.Name = "Mercredi_chk"
        Me.Mercredi_chk.Size = New System.Drawing.Size(125, 25)
        Me.Mercredi_chk.TabIndex = 116
        Me.Mercredi_chk.Text = "Mercredi"
        '
        'Mardi_chk
        '
        Me.Mardi_chk.AutoSize = True
        Me.Mardi_chk.Checked = True
        Me.Mardi_chk.Location = New System.Drawing.Point(61, 58)
        Me.Mardi_chk.Margin = New System.Windows.Forms.Padding(2)
        Me.Mardi_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Mardi_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Mardi_chk.Name = "Mardi_chk"
        Me.Mardi_chk.Size = New System.Drawing.Size(125, 25)
        Me.Mardi_chk.TabIndex = 115
        Me.Mardi_chk.Text = "Mardi"
        '
        'Lundi_chk
        '
        Me.Lundi_chk.AutoSize = True
        Me.Lundi_chk.Checked = True
        Me.Lundi_chk.Location = New System.Drawing.Point(61, 31)
        Me.Lundi_chk.Margin = New System.Windows.Forms.Padding(2)
        Me.Lundi_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Lundi_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Lundi_chk.Name = "Lundi_chk"
        Me.Lundi_chk.Size = New System.Drawing.Size(125, 25)
        Me.Lundi_chk.TabIndex = 114
        Me.Lundi_chk.Text = "Lundi"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Sequence)
        Me.GroupBox3.Controls.Add(Me.Racine_text)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Obliger_Demande_Pret_chk)
        Me.GroupBox3.Controls.Add(Me.Masquer_Element_Paie_Agent_chk)
        Me.GroupBox3.Controls.Add(Me.Compteur_Auto)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 91)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(546, 224)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Paramétrage compteur de la fiche Agent"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(380, 45)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 19)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Séquence"
        '
        'Sequence
        '
        Me.Sequence.Location = New System.Drawing.Point(462, 42)
        Me.Sequence.Margin = New System.Windows.Forms.Padding(2)
        Me.Sequence.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.Sequence.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.Sequence.Name = "Sequence"
        Me.Sequence.Size = New System.Drawing.Size(56, 24)
        Me.Sequence.TabIndex = 21
        Me.Sequence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Sequence.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Racine_text
        '
        Me.Racine_text.AutoSize = True
        Me.Racine_text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Racine_text.ContextMenuStrip = Nothing
        Me.Racine_text.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Racine_text.Location = New System.Drawing.Point(310, 41)
        Me.Racine_text.Margin = New System.Windows.Forms.Padding(2)
        Me.Racine_text.MaxLength = 10
        Me.Racine_text.Multiline = False
        Me.Racine_text.Name = "Racine_text"
        Me.Racine_text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Racine_text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Racine_text.ReadOnly = False
        Me.Racine_text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Racine_text.SelectionStart = 0
        Me.Racine_text.Size = New System.Drawing.Size(62, 26)
        Me.Racine_text.TabIndex = 19
        Me.Racine_text.Tag = "4"
        Me.Racine_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Racine_text.UseSystemPasswordChar = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(244, 45)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 19)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Racine "
        '
        'Obliger_Demande_Pret_chk
        '
        Me.Obliger_Demande_Pret_chk.AutoSize = True
        Me.Obliger_Demande_Pret_chk.Checked = True
        Me.Obliger_Demande_Pret_chk.Location = New System.Drawing.Point(12, 101)
        Me.Obliger_Demande_Pret_chk.Margin = New System.Windows.Forms.Padding(2)
        Me.Obliger_Demande_Pret_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Obliger_Demande_Pret_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Obliger_Demande_Pret_chk.Name = "Obliger_Demande_Pret_chk"
        Me.Obliger_Demande_Pret_chk.Size = New System.Drawing.Size(304, 25)
        Me.Obliger_Demande_Pret_chk.TabIndex = 0
        Me.Obliger_Demande_Pret_chk.Text = "Demande préalable obligatoire au prêt"
        '
        'Masquer_Element_Paie_Agent_chk
        '
        Me.Masquer_Element_Paie_Agent_chk.AutoSize = True
        Me.Masquer_Element_Paie_Agent_chk.Checked = True
        Me.Masquer_Element_Paie_Agent_chk.Location = New System.Drawing.Point(12, 71)
        Me.Masquer_Element_Paie_Agent_chk.Margin = New System.Windows.Forms.Padding(2)
        Me.Masquer_Element_Paie_Agent_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Masquer_Element_Paie_Agent_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Masquer_Element_Paie_Agent_chk.Name = "Masquer_Element_Paie_Agent_chk"
        Me.Masquer_Element_Paie_Agent_chk.Size = New System.Drawing.Size(348, 25)
        Me.Masquer_Element_Paie_Agent_chk.TabIndex = 0
        Me.Masquer_Element_Paie_Agent_chk.Text = "Masquer les éléments de paie au profil ""Agent"""
        '
        'Compteur_Auto
        '
        Me.Compteur_Auto.AutoSize = True
        Me.Compteur_Auto.Checked = True
        Me.Compteur_Auto.Location = New System.Drawing.Point(12, 40)
        Me.Compteur_Auto.Margin = New System.Windows.Forms.Padding(2)
        Me.Compteur_Auto.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Compteur_Auto.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Compteur_Auto.Name = "Compteur_Auto"
        Me.Compteur_Auto.Size = New System.Drawing.Size(201, 25)
        Me.Compteur_Auto.TabIndex = 0
        Me.Compteur_Auto.Text = "Compteur des matricules"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDroits)
        Me.GroupBox2.Controls.Add(Me.txtDroits)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(546, 91)
        Me.GroupBox2.TabIndex = 105
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Droits d'accès"
        '
        'btnDroits
        '
        Me.btnDroits.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDroits.Location = New System.Drawing.Point(496, 19)
        Me.btnDroits.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDroits.Name = "btnDroits"
        Me.btnDroits.Size = New System.Drawing.Size(25, 26)
        Me.btnDroits.TabIndex = 34
        Me.btnDroits.Text = "---"
        Me.btnDroits.UseVisualStyleBackColor = True
        '
        'txtDroits
        '
        Me.txtDroits.AutoSize = True
        Me.txtDroits.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtDroits.ContextMenuStrip = Nothing
        Me.txtDroits.Enabled = False
        Me.txtDroits.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDroits.Location = New System.Drawing.Point(5, 19)
        Me.txtDroits.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDroits.MaxLength = 20
        Me.txtDroits.Multiline = False
        Me.txtDroits.Name = "txtDroits"
        Me.txtDroits.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtDroits.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDroits.ReadOnly = False
        Me.txtDroits.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDroits.SelectionStart = 0
        Me.txtDroits.Size = New System.Drawing.Size(488, 26)
        Me.txtDroits.TabIndex = 33
        Me.txtDroits.Tag = "12"
        Me.txtDroits.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDroits.UseSystemPasswordChar = False
        '
        'Grd_JoursFeries
        '
        Me.Grd_JoursFeries.AfficherLesEntetesLignes = True
        Me.Grd_JoursFeries.AllowUserToOrderColumns = True
        Me.Grd_JoursFeries.AlternerLesLignes = False
        Me.Grd_JoursFeries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_JoursFeries.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_JoursFeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd_JoursFeries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_JoursFeries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_JoursFeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_JoursFeries.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_JoursFeries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_JoursFeries.EnableHeadersVisualStyles = False
        Me.Grd_JoursFeries.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grd_JoursFeries.Location = New System.Drawing.Point(0, 286)
        Me.Grd_JoursFeries.Margin = New System.Windows.Forms.Padding(2)
        Me.Grd_JoursFeries.Name = "Grd_JoursFeries"
        Me.Grd_JoursFeries.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_JoursFeries.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_JoursFeries.RowHeadersWidth = 51
        Me.Grd_JoursFeries.Size = New System.Drawing.Size(473, 339)
        Me.Grd_JoursFeries.TabIndex = 3
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.Grd_Soc)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Size = New System.Drawing.Size(473, 286)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Modèles d'édition"
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Soc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Soc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Soc.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grd_Soc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Soc.EnableHeadersVisualStyles = False
        Me.Grd_Soc.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grd_Soc.Location = New System.Drawing.Point(2, 19)
        Me.Grd_Soc.Margin = New System.Windows.Forms.Padding(2)
        Me.Grd_Soc.Name = "Grd_Soc"
        Me.Grd_Soc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Soc.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grd_Soc.RowHeadersVisible = False
        Me.Grd_Soc.RowHeadersWidth = 51
        Me.Grd_Soc.Size = New System.Drawing.Size(469, 265)
        Me.Grd_Soc.TabIndex = 1
        '
        'DPI
        '
        Me.DPI.Name = "DPI"
        Me.DPI.Text = "DPI"
        '
        'DB_Societe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1035, 661)
        Me.Controls.Add(Me.oPnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DB_Societe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Renseignements de la société"
        Me.Grp3.ResumeLayout(False)
        Me.Grp3.PerformLayout()
        Me.Grp2.ResumeLayout(False)
        Me.Grp2.PerformLayout()
        Me.Grp1.ResumeLayout(False)
        Me.Grp1.PerformLayout()
        CType(Me.Prioritie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.oPnl.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Sequence, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Grd_JoursFeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.Grd_Soc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


    ' Fields
    Private WithEvents ENCList As List(Of WeakReference) = New List(Of WeakReference)

    Friend WithEvents Adresse As Label



    Friend WithEvents cboFJ As ud_ComboBox




    Friend WithEvents Label10 As Label


    Friend WithEvents Label3 As Label

    Friend WithEvents Label4 As Label

    Friend WithEvents Label5 As Label

    Friend WithEvents Label6 As Label

    Friend WithEvents Label7 As Label

    Friend WithEvents Label8 As Label


    Friend WithEvents lblActivite As Label

    Friend WithEvents lblDen As Label

    Friend WithEvents lblFj As Label

    Friend WithEvents lblIdent As Label

    Friend WithEvents FichierD As String
    Friend WithEvents FichierS As String
    Friend WithEvents Grp2 As System.Windows.Forms.GroupBox
    Friend WithEvents Grp1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grp3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Prioritie As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtICE As ud_TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents oPnl As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnDroits As Button
    Friend WithEvents CNSS_Agence As ud_ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Sequence As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents Compteur_Auto As ud_CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Grd_JoursFeries As ud_Grd
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Dimanche_chk As ud_CheckBox
    Friend WithEvents Samedi_chk As ud_CheckBox
    Friend WithEvents Vendredi_chk As ud_CheckBox
    Friend WithEvents Jeudi_chk As ud_CheckBox
    Friend WithEvents Mercredi_chk As ud_CheckBox
    Friend WithEvents Mardi_chk As ud_CheckBox
    Friend WithEvents Lundi_chk As ud_CheckBox
    Friend WithEvents Capital_lbl As Label
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Grd_Soc As ud_Grd
    Friend WithEvents DPI As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label19 As Label
    Friend WithEvents Cod_Ville_ As LinkLabel
    Friend WithEvents Cod_Pays_ As LinkLabel
    Friend WithEvents Masquer_Element_Paie_Agent_chk As ud_CheckBox
    Friend WithEvents Obliger_Demande_Pret_chk As ud_CheckBox
    Friend WithEvents txtActivite As ud_TextBox
    Friend WithEvents txtAdresse As ud_TextBox
    Friend WithEvents txtIdentFisc As ud_TextBox
    Friend WithEvents txtCNSS As ud_TextBox
    Friend WithEvents txtCP As ud_TextBox
    Friend WithEvents txtDen As ud_TextBox
    Friend WithEvents txtEmail As ud_TextBox
    Friend WithEvents txtFax As ud_TextBox
    Friend WithEvents txtRC As ud_TextBox
    Friend WithEvents txtTel As ud_TextBox
    Friend WithEvents txtTP As ud_TextBox
    Friend WithEvents txtDroits As ud_TextBox
    Friend WithEvents idScociete_txt As ud_TextBox
    Friend WithEvents txtGroupe As ud_TextBox
    Friend WithEvents Racine_text As ud_TextBox
    Friend WithEvents Capital_txt As ud_TextBox
    Friend WithEvents Cod_Ville_Text As ud_TextBox
    Friend WithEvents Lib_Ville_Liv_Text As ud_TextBox
    Friend WithEvents Cod_Pays_Text As ud_TextBox
    Friend WithEvents Lib_Pays_Text As ud_TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cod_TFP_cbo As ud_ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Cod_Commune_Combo As RHP.ud_ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Mis_Sml As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label9 As Label
End Class
