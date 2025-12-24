<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Parametrage_Rubrique_Paie
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
        Me.Grp1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Ud_Proteger = New RHP.ud_CheckBox()
        Me.Cod_Rubrique_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Rubrique_txt = New RHP.ud_TextBox()
        Me.estSysteme_chk = New RHP.ud_CheckBox()
        Me.Abr_Rubrique_txt = New RHP.ud_TextBox()
        Me.Rubrique_Globale_chk = New RHP.ud_CheckBox()
        Me.Typ_Retour = New RHP.ud_ComboBox()
        Me.Est_Pourcentage_chk = New RHP.ud_CheckBox()
        Me.Typ_Retour_ = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Utilise_chk = New RHP.ud_CheckBox()
        Me.Nb_Decimal = New System.Windows.Forms.NumericUpDown()
        Me.Cumulable_chk = New RHP.ud_CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Rub_ = New System.Windows.Forms.LinkLabel()
        Me.lblColor = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel12 = New System.Windows.Forms.LinkLabel()
        Me.Grp2 = New System.Windows.Forms.GroupBox()
        Me.Typ_Rubrique_Paie = New RHP.ud_ComboBox()
        Me.Groupe_lbl = New System.Windows.Forms.Label()
        Me.Grp_Categorie = New System.Windows.Forms.GroupBox()
        Me.Pnl_Categorie = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Gain_rd = New RHP.ud_RadioBox()
        Me.Retenue_rd = New RHP.ud_RadioBox()
        Me.Autre_Rd = New RHP.ud_RadioBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ud_RadioBox1 = New RHP.ud_RadioBox()
        Me.Salarial_rd = New RHP.ud_RadioBox()
        Me.Patronal_rd = New RHP.ud_RadioBox()
        Me.Imposable_Grp = New System.Windows.Forms.GroupBox()
        Me.Deductible_CNSS_chk = New RHP.ud_CheckBox()
        Me.Deductible_IR_chk = New RHP.ud_CheckBox()
        Me.Imposable_CNSS_chk = New RHP.ud_CheckBox()
        Me.Imposable_IR_chk = New RHP.ud_CheckBox()
        Me.NatureElementExonere = New System.Windows.Forms.LinkLabel()
        Me.Nature_Element_Exonere_txt = New RHP.ud_TextBox()
        Me.Lib_Nature_Element_Exonere_txt = New RHP.ud_TextBox()
        Me.element_calcul_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.detail_4_btn = New RHP.ud_button()
        Me.formule_4_btn = New RHP.ud_button()
        Me.detail_3_btn = New RHP.ud_button()
        Me.formule_3_btn = New RHP.ud_button()
        Me.detail_2_btn = New RHP.ud_button()
        Me.formule_2_btn = New RHP.ud_button()
        Me.detail_1_btn = New RHP.ud_button()
        Me.Base_txt = New RHP.ud_TextBox()
        Me.Relation_txt = New RHP.ud_TextBox()
        Me.Nb_lbl = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Nb_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tx_txt = New RHP.ud_TextBox()
        Me.formule_1_btn = New RHP.ud_button()
        Me.Grp3 = New System.Windows.Forms.GroupBox()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.EC_Rd = New RHP.ud_RadioBox()
        Me.EB_Rd = New RHP.ud_RadioBox()
        Me.CS_rd = New RHP.ud_RadioBox()
        Me.EX_Rd = New RHP.ud_RadioBox()
        Me.EV_Rd = New RHP.ud_RadioBox()
        Me.eleCalcul_pnl = New System.Windows.Forms.Panel()
        Me.estMajAuto_chk = New RHP.ud_CheckBox()
        Me.msg_lbl = New System.Windows.Forms.Label()
        Me.lb_Val = New System.Windows.Forms.Label()
        Me.Val_Defaut_txt = New RHP.ud_TextBox()
        Me.Grp5 = New System.Windows.Forms.GroupBox()
        Me.Ventilable_chk = New RHP.ud_CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Cpt_Credit_txt = New RHP.ud_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cpt_Debit_txt = New RHP.ud_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Grp4 = New System.Windows.Forms.GroupBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Commentaire = New RHP.ud_RichTextBox()
        Me.Grp1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Nb_Decimal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp2.SuspendLayout()
        Me.Grp_Categorie.SuspendLayout()
        Me.Pnl_Categorie.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Imposable_Grp.SuspendLayout()
        Me.element_calcul_pnl.SuspendLayout()
        Me.Grp3.SuspendLayout()
        Me.Personnal_pnl.SuspendLayout()
        Me.eleCalcul_pnl.SuspendLayout()
        Me.Grp5.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Grp4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grp1
        '
        Me.Grp1.Controls.Add(Me.Panel1)
        Me.Grp1.Controls.Add(Me.Label1)
        Me.Grp1.Controls.Add(Me.Rub_)
        Me.Grp1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grp1.Location = New System.Drawing.Point(0, 0)
        Me.Grp1.Margin = New System.Windows.Forms.Padding(4)
        Me.Grp1.Name = "Grp1"
        Me.Grp1.Padding = New System.Windows.Forms.Padding(4)
        Me.Grp1.Size = New System.Drawing.Size(1206, 126)
        Me.Grp1.TabIndex = 2
        Me.Grp1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Ud_Proteger)
        Me.Panel1.Controls.Add(Me.Cod_Rubrique_txt)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Lib_Rubrique_txt)
        Me.Panel1.Controls.Add(Me.estSysteme_chk)
        Me.Panel1.Controls.Add(Me.Abr_Rubrique_txt)
        Me.Panel1.Controls.Add(Me.Rubrique_Globale_chk)
        Me.Panel1.Controls.Add(Me.Typ_Retour)
        Me.Panel1.Controls.Add(Me.Est_Pourcentage_chk)
        Me.Panel1.Controls.Add(Me.Typ_Retour_)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Utilise_chk)
        Me.Panel1.Controls.Add(Me.Nb_Decimal)
        Me.Panel1.Controls.Add(Me.Cumulable_chk)
        Me.Panel1.Location = New System.Drawing.Point(99, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1092, 111)
        Me.Panel1.TabIndex = 233
        '
        'Ud_Proteger
        '
        Me.Ud_Proteger.AutoSize = True
        Me.Ud_Proteger.Checked = False
        Me.Ud_Proteger.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ud_Proteger.Location = New System.Drawing.Point(818, 70)
        Me.Ud_Proteger.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ud_Proteger.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Ud_Proteger.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Ud_Proteger.Name = "Ud_Proteger"
        Me.Ud_Proteger.Size = New System.Drawing.Size(146, 31)
        Me.Ud_Proteger.TabIndex = 233
        Me.Ud_Proteger.Tag = "SC"
        Me.Ud_Proteger.Text = "Protéger"
        '
        'Cod_Rubrique_txt
        '
        Me.Cod_Rubrique_txt.AccessibleDescription = "A"
        Me.Cod_Rubrique_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Rubrique_txt.ContextMenuStrip = Nothing
        Me.Cod_Rubrique_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Rubrique_txt.Location = New System.Drawing.Point(4, 10)
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
        Me.Cod_Rubrique_txt.TabIndex = 0
        Me.Cod_Rubrique_txt.TabStop = False
        Me.Cod_Rubrique_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Rubrique_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(838, 14)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(122, 19)
        Me.LinkLabel1.TabIndex = 232
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Rubrique utilisée"
        '
        'Lib_Rubrique_txt
        '
        Me.Lib_Rubrique_txt.AccessibleDescription = "A"
        Me.Lib_Rubrique_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Rubrique_txt.ContextMenuStrip = Nothing
        Me.Lib_Rubrique_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Rubrique_txt.Location = New System.Drawing.Point(190, 10)
        Me.Lib_Rubrique_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Rubrique_txt.MaxLength = 32767
        Me.Lib_Rubrique_txt.Multiline = False
        Me.Lib_Rubrique_txt.Name = "Lib_Rubrique_txt"
        Me.Lib_Rubrique_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Rubrique_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Rubrique_txt.ReadOnly = False
        Me.Lib_Rubrique_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Rubrique_txt.SelectionStart = 0
        Me.Lib_Rubrique_txt.Size = New System.Drawing.Size(620, 26)
        Me.Lib_Rubrique_txt.TabIndex = 1
        Me.Lib_Rubrique_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Rubrique_txt.UseSystemPasswordChar = False
        '
        'estSysteme_chk
        '
        Me.estSysteme_chk.AutoSize = True
        Me.estSysteme_chk.Checked = False
        Me.estSysteme_chk.Enabled = False
        Me.estSysteme_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.estSysteme_chk.Location = New System.Drawing.Point(818, 40)
        Me.estSysteme_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.estSysteme_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.estSysteme_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.estSysteme_chk.Name = "estSysteme_chk"
        Me.estSysteme_chk.Size = New System.Drawing.Size(150, 31)
        Me.estSysteme_chk.TabIndex = 231
        Me.estSysteme_chk.Text = "Rubrique système"
        '
        'Abr_Rubrique_txt
        '
        Me.Abr_Rubrique_txt.AccessibleDescription = "A"
        Me.Abr_Rubrique_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Abr_Rubrique_txt.ContextMenuStrip = Nothing
        Me.Abr_Rubrique_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Abr_Rubrique_txt.Location = New System.Drawing.Point(4, 39)
        Me.Abr_Rubrique_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Abr_Rubrique_txt.MaxLength = 50
        Me.Abr_Rubrique_txt.Multiline = False
        Me.Abr_Rubrique_txt.Name = "Abr_Rubrique_txt"
        Me.Abr_Rubrique_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Abr_Rubrique_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Abr_Rubrique_txt.ReadOnly = False
        Me.Abr_Rubrique_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Abr_Rubrique_txt.SelectionStart = 0
        Me.Abr_Rubrique_txt.Size = New System.Drawing.Size(231, 26)
        Me.Abr_Rubrique_txt.TabIndex = 2
        Me.Abr_Rubrique_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Abr_Rubrique_txt.UseSystemPasswordChar = False
        '
        'Rubrique_Globale_chk
        '
        Me.Rubrique_Globale_chk.AutoSize = True
        Me.Rubrique_Globale_chk.Checked = False
        Me.Rubrique_Globale_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rubrique_Globale_chk.Location = New System.Drawing.Point(658, 70)
        Me.Rubrique_Globale_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Rubrique_Globale_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rubrique_Globale_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Rubrique_Globale_chk.Name = "Rubrique_Globale_chk"
        Me.Rubrique_Globale_chk.Size = New System.Drawing.Size(149, 31)
        Me.Rubrique_Globale_chk.TabIndex = 230
        Me.Rubrique_Globale_chk.Text = "Rubrique globale"
        '
        'Typ_Retour
        '
        Me.Typ_Retour.DataSource = Nothing
        Me.Typ_Retour.DisplayMember = ""
        Me.Typ_Retour.DroppedDown = False
        Me.Typ_Retour.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Retour.Location = New System.Drawing.Point(358, 40)
        Me.Typ_Retour.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Typ_Retour.Name = "Typ_Retour"
        Me.Typ_Retour.SelectedIndex = -1
        Me.Typ_Retour.SelectedItem = Nothing
        Me.Typ_Retour.SelectedValue = Nothing
        Me.Typ_Retour.Size = New System.Drawing.Size(151, 30)
        Me.Typ_Retour.TabIndex = 3
        Me.Typ_Retour.ValueMember = ""
        '
        'Est_Pourcentage_chk
        '
        Me.Est_Pourcentage_chk.AutoSize = True
        Me.Est_Pourcentage_chk.Checked = False
        Me.Est_Pourcentage_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Est_Pourcentage_chk.Location = New System.Drawing.Point(352, 70)
        Me.Est_Pourcentage_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Est_Pourcentage_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Est_Pourcentage_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Est_Pourcentage_chk.Name = "Est_Pourcentage_chk"
        Me.Est_Pourcentage_chk.Size = New System.Drawing.Size(196, 31)
        Me.Est_Pourcentage_chk.TabIndex = 5
        Me.Est_Pourcentage_chk.Text = "Format pourcentage ""%"""
        '
        'Typ_Retour_
        '
        Me.Typ_Retour_.AutoSize = True
        Me.Typ_Retour_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Retour_.Location = New System.Drawing.Point(242, 45)
        Me.Typ_Retour_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Typ_Retour_.Name = "Typ_Retour_"
        Me.Typ_Retour_.Size = New System.Drawing.Size(112, 19)
        Me.Typ_Retour_.TabIndex = 220
        Me.Typ_Retour_.Text = "Type de retour "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(550, 44)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 19)
        Me.Label9.TabIndex = 227
        Me.Label9.Text = "Nb décimaux"
        '
        'Utilise_chk
        '
        Me.Utilise_chk.AutoSize = True
        Me.Utilise_chk.Checked = False
        Me.Utilise_chk.Enabled = False
        Me.Utilise_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Utilise_chk.Location = New System.Drawing.Point(818, 9)
        Me.Utilise_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Utilise_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Utilise_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Utilise_chk.Name = "Utilise_chk"
        Me.Utilise_chk.Size = New System.Drawing.Size(146, 31)
        Me.Utilise_chk.TabIndex = 222
        '
        'Nb_Decimal
        '
        Me.Nb_Decimal.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nb_Decimal.Location = New System.Drawing.Point(658, 41)
        Me.Nb_Decimal.Margin = New System.Windows.Forms.Padding(4)
        Me.Nb_Decimal.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.Nb_Decimal.Name = "Nb_Decimal"
        Me.Nb_Decimal.Size = New System.Drawing.Size(64, 24)
        Me.Nb_Decimal.TabIndex = 4
        Me.Nb_Decimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cumulable_chk
        '
        Me.Cumulable_chk.AutoSize = True
        Me.Cumulable_chk.Checked = False
        Me.Cumulable_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cumulable_chk.Location = New System.Drawing.Point(6, 70)
        Me.Cumulable_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cumulable_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Cumulable_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Cumulable_chk.Name = "Cumulable_chk"
        Me.Cumulable_chk.Size = New System.Drawing.Size(237, 31)
        Me.Cumulable_chk.TabIndex = 222
        Me.Cumulable_chk.Text = "Gérée le cumul de la rubrique"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(8, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 19)
        Me.Label1.TabIndex = 205
        Me.Label1.Text = "Abréviation"
        '
        'Rub_
        '
        Me.Rub_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rub_.AutoSize = True
        Me.Rub_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rub_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rub_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rub_.Location = New System.Drawing.Point(26, 29)
        Me.Rub_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Rub_.Name = "Rub_"
        Me.Rub_.Size = New System.Drawing.Size(72, 19)
        Me.Rub_.TabIndex = 0
        Me.Rub_.TabStop = True
        Me.Rub_.Tag = ""
        Me.Rub_.Text = "Rubrique"
        '
        'lblColor
        '
        Me.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblColor.Location = New System.Drawing.Point(106, 21)
        Me.lblColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(38, 31)
        Me.lblColor.TabIndex = 228
        '
        'LinkLabel12
        '
        Me.LinkLabel12.AutoSize = True
        Me.LinkLabel12.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel12.Location = New System.Drawing.Point(31, 26)
        Me.LinkLabel12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel12.Name = "LinkLabel12"
        Me.LinkLabel12.Size = New System.Drawing.Size(71, 19)
        Me.LinkLabel12.TabIndex = 229
        Me.LinkLabel12.TabStop = True
        Me.LinkLabel12.Tag = ""
        Me.LinkLabel12.Text = "Couleur :"
        '
        'Grp2
        '
        Me.Grp2.Controls.Add(Me.Typ_Rubrique_Paie)
        Me.Grp2.Controls.Add(Me.Groupe_lbl)
        Me.Grp2.Controls.Add(Me.Grp_Categorie)
        Me.Grp2.Controls.Add(Me.NatureElementExonere)
        Me.Grp2.Controls.Add(Me.Nature_Element_Exonere_txt)
        Me.Grp2.Controls.Add(Me.Lib_Nature_Element_Exonere_txt)
        Me.Grp2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grp2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grp2.Location = New System.Drawing.Point(4, 245)
        Me.Grp2.Margin = New System.Windows.Forms.Padding(4)
        Me.Grp2.Name = "Grp2"
        Me.Grp2.Padding = New System.Windows.Forms.Padding(4)
        Me.Grp2.Size = New System.Drawing.Size(1190, 359)
        Me.Grp2.TabIndex = 225
        Me.Grp2.TabStop = False
        Me.Grp2.Text = "Paramétrage"
        '
        'Typ_Rubrique_Paie
        '
        Me.Typ_Rubrique_Paie.DataSource = Nothing
        Me.Typ_Rubrique_Paie.DisplayMember = ""
        Me.Typ_Rubrique_Paie.DroppedDown = False
        Me.Typ_Rubrique_Paie.Location = New System.Drawing.Point(139, 250)
        Me.Typ_Rubrique_Paie.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Typ_Rubrique_Paie.Name = "Typ_Rubrique_Paie"
        Me.Typ_Rubrique_Paie.SelectedIndex = -1
        Me.Typ_Rubrique_Paie.SelectedItem = Nothing
        Me.Typ_Rubrique_Paie.SelectedValue = Nothing
        Me.Typ_Rubrique_Paie.Size = New System.Drawing.Size(605, 31)
        Me.Typ_Rubrique_Paie.TabIndex = 223
        Me.Typ_Rubrique_Paie.ValueMember = ""
        '
        'Groupe_lbl
        '
        Me.Groupe_lbl.AutoSize = True
        Me.Groupe_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Groupe_lbl.Location = New System.Drawing.Point(65, 254)
        Me.Groupe_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Groupe_lbl.Name = "Groupe_lbl"
        Me.Groupe_lbl.Size = New System.Drawing.Size(66, 19)
        Me.Groupe_lbl.TabIndex = 224
        Me.Groupe_lbl.Text = "Groupe "
        '
        'Grp_Categorie
        '
        Me.Grp_Categorie.Controls.Add(Me.Pnl_Categorie)
        Me.Grp_Categorie.Controls.Add(Me.Imposable_Grp)
        Me.Grp_Categorie.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grp_Categorie.Location = New System.Drawing.Point(4, 21)
        Me.Grp_Categorie.Margin = New System.Windows.Forms.Padding(4)
        Me.Grp_Categorie.Name = "Grp_Categorie"
        Me.Grp_Categorie.Padding = New System.Windows.Forms.Padding(4)
        Me.Grp_Categorie.Size = New System.Drawing.Size(1182, 206)
        Me.Grp_Categorie.TabIndex = 208
        Me.Grp_Categorie.TabStop = False
        Me.Grp_Categorie.Text = "Catégorie"
        '
        'Pnl_Categorie
        '
        Me.Pnl_Categorie.Controls.Add(Me.TableLayoutPanel2)
        Me.Pnl_Categorie.Controls.Add(Me.TableLayoutPanel3)
        Me.Pnl_Categorie.Location = New System.Drawing.Point(11, 25)
        Me.Pnl_Categorie.Margin = New System.Windows.Forms.Padding(4)
        Me.Pnl_Categorie.Name = "Pnl_Categorie"
        Me.Pnl_Categorie.Size = New System.Drawing.Size(520, 161)
        Me.Pnl_Categorie.TabIndex = 231
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Gain_rd, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Retenue_rd, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Autre_Rd, 0, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(28, 32)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(172, 98)
        Me.TableLayoutPanel2.TabIndex = 230
        '
        'Gain_rd
        '
        Me.Gain_rd.AutoSize = True
        Me.Gain_rd.Checked = True
        Me.Gain_rd.Location = New System.Drawing.Point(4, 2)
        Me.Gain_rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Gain_rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Gain_rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Gain_rd.Name = "Gain_rd"
        Me.Gain_rd.Size = New System.Drawing.Size(142, 31)
        Me.Gain_rd.TabIndex = 212
        Me.Gain_rd.Text = "Gain"
        '
        'Retenue_rd
        '
        Me.Retenue_rd.AutoSize = True
        Me.Retenue_rd.Checked = False
        Me.Retenue_rd.Location = New System.Drawing.Point(4, 33)
        Me.Retenue_rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Retenue_rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Retenue_rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Retenue_rd.Name = "Retenue_rd"
        Me.Retenue_rd.Size = New System.Drawing.Size(142, 31)
        Me.Retenue_rd.TabIndex = 7
        Me.Retenue_rd.Text = "Retenue"
        '
        'Autre_Rd
        '
        Me.Autre_Rd.AutoSize = True
        Me.Autre_Rd.Checked = False
        Me.Autre_Rd.Location = New System.Drawing.Point(4, 64)
        Me.Autre_Rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Autre_Rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Autre_Rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Autre_Rd.Name = "Autre_Rd"
        Me.Autre_Rd.Size = New System.Drawing.Size(142, 31)
        Me.Autre_Rd.TabIndex = 7
        Me.Autre_Rd.Text = "Autre"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ud_RadioBox1, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Salarial_rd, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Patronal_rd, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(214, 32)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(250, 98)
        Me.TableLayoutPanel3.TabIndex = 230
        '
        'ud_RadioBox1
        '
        Me.ud_RadioBox1.AutoSize = True
        Me.ud_RadioBox1.Checked = True
        Me.ud_RadioBox1.Location = New System.Drawing.Point(4, 64)
        Me.ud_RadioBox1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.ud_RadioBox1.MaximumSize = New System.Drawing.Size(0, 31)
        Me.ud_RadioBox1.MinimumSize = New System.Drawing.Size(0, 31)
        Me.ud_RadioBox1.Name = "ud_RadioBox1"
        Me.ud_RadioBox1.Size = New System.Drawing.Size(142, 31)
        Me.ud_RadioBox1.TabIndex = 13
        Me.ud_RadioBox1.Text = "Autre"
        '
        'Salarial_rd
        '
        Me.Salarial_rd.AutoSize = True
        Me.Salarial_rd.Checked = False
        Me.Salarial_rd.Location = New System.Drawing.Point(4, 2)
        Me.Salarial_rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Salarial_rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Salarial_rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Salarial_rd.Name = "Salarial_rd"
        Me.Salarial_rd.Size = New System.Drawing.Size(142, 31)
        Me.Salarial_rd.TabIndex = 12
        Me.Salarial_rd.Text = "Salariale"
        '
        'Patronal_rd
        '
        Me.Patronal_rd.AutoSize = True
        Me.Patronal_rd.Checked = False
        Me.Patronal_rd.Location = New System.Drawing.Point(4, 33)
        Me.Patronal_rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Patronal_rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Patronal_rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Patronal_rd.Name = "Patronal_rd"
        Me.Patronal_rd.Size = New System.Drawing.Size(142, 31)
        Me.Patronal_rd.TabIndex = 9
        Me.Patronal_rd.Text = "Patronale"
        '
        'Imposable_Grp
        '
        Me.Imposable_Grp.Controls.Add(Me.Deductible_CNSS_chk)
        Me.Imposable_Grp.Controls.Add(Me.Deductible_IR_chk)
        Me.Imposable_Grp.Controls.Add(Me.Imposable_CNSS_chk)
        Me.Imposable_Grp.Controls.Add(Me.Imposable_IR_chk)
        Me.Imposable_Grp.Location = New System.Drawing.Point(558, 15)
        Me.Imposable_Grp.Margin = New System.Windows.Forms.Padding(4)
        Me.Imposable_Grp.Name = "Imposable_Grp"
        Me.Imposable_Grp.Padding = New System.Windows.Forms.Padding(4)
        Me.Imposable_Grp.Size = New System.Drawing.Size(302, 176)
        Me.Imposable_Grp.TabIndex = 12
        Me.Imposable_Grp.TabStop = False
        '
        'Deductible_CNSS_chk
        '
        Me.Deductible_CNSS_chk.AutoSize = True
        Me.Deductible_CNSS_chk.Checked = False
        Me.Deductible_CNSS_chk.Location = New System.Drawing.Point(25, 120)
        Me.Deductible_CNSS_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.Deductible_CNSS_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Deductible_CNSS_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Deductible_CNSS_chk.Name = "Deductible_CNSS_chk"
        Me.Deductible_CNSS_chk.Size = New System.Drawing.Size(185, 25)
        Me.Deductible_CNSS_chk.TabIndex = 1
        Me.Deductible_CNSS_chk.Text = "Déductible de la CNSS"
        '
        'Deductible_IR_chk
        '
        Me.Deductible_IR_chk.AutoSize = True
        Me.Deductible_IR_chk.Checked = False
        Me.Deductible_IR_chk.Location = New System.Drawing.Point(25, 88)
        Me.Deductible_IR_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.Deductible_IR_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Deductible_IR_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Deductible_IR_chk.Name = "Deductible_IR_chk"
        Me.Deductible_IR_chk.Size = New System.Drawing.Size(151, 25)
        Me.Deductible_IR_chk.TabIndex = 2
        Me.Deductible_IR_chk.Text = "Déductible de l'IR"
        '
        'Imposable_CNSS_chk
        '
        Me.Imposable_CNSS_chk.AutoSize = True
        Me.Imposable_CNSS_chk.Checked = True
        Me.Imposable_CNSS_chk.Location = New System.Drawing.Point(25, 58)
        Me.Imposable_CNSS_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.Imposable_CNSS_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Imposable_CNSS_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Imposable_CNSS_chk.Name = "Imposable_CNSS_chk"
        Me.Imposable_CNSS_chk.Size = New System.Drawing.Size(171, 25)
        Me.Imposable_CNSS_chk.TabIndex = 0
        Me.Imposable_CNSS_chk.Text = "Imposable à la CNSS"
        '
        'Imposable_IR_chk
        '
        Me.Imposable_IR_chk.AutoSize = True
        Me.Imposable_IR_chk.Checked = True
        Me.Imposable_IR_chk.Location = New System.Drawing.Point(25, 25)
        Me.Imposable_IR_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.Imposable_IR_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Imposable_IR_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Imposable_IR_chk.Name = "Imposable_IR_chk"
        Me.Imposable_IR_chk.Size = New System.Drawing.Size(137, 25)
        Me.Imposable_IR_chk.TabIndex = 0
        Me.Imposable_IR_chk.Text = "Imposable à l'IR"
        '
        'NatureElementExonere
        '
        Me.NatureElementExonere.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NatureElementExonere.AutoSize = True
        Me.NatureElementExonere.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NatureElementExonere.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.NatureElementExonere.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NatureElementExonere.Location = New System.Drawing.Point(76, 291)
        Me.NatureElementExonere.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.NatureElementExonere.Name = "NatureElementExonere"
        Me.NatureElementExonere.Size = New System.Drawing.Size(56, 19)
        Me.NatureElementExonere.TabIndex = 229
        Me.NatureElementExonere.TabStop = True
        Me.NatureElementExonere.Tag = ""
        Me.NatureElementExonere.Text = "Nature"
        '
        'Nature_Element_Exonere_txt
        '
        Me.Nature_Element_Exonere_txt.AccessibleDescription = "A"
        Me.Nature_Element_Exonere_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nature_Element_Exonere_txt.ContextMenuStrip = Nothing
        Me.Nature_Element_Exonere_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nature_Element_Exonere_txt.Location = New System.Drawing.Point(139, 289)
        Me.Nature_Element_Exonere_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nature_Element_Exonere_txt.MaxLength = 32767
        Me.Nature_Element_Exonere_txt.Multiline = False
        Me.Nature_Element_Exonere_txt.Name = "Nature_Element_Exonere_txt"
        Me.Nature_Element_Exonere_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nature_Element_Exonere_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nature_Element_Exonere_txt.ReadOnly = True
        Me.Nature_Element_Exonere_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nature_Element_Exonere_txt.SelectionStart = 0
        Me.Nature_Element_Exonere_txt.Size = New System.Drawing.Size(184, 26)
        Me.Nature_Element_Exonere_txt.TabIndex = 227
        Me.Nature_Element_Exonere_txt.TabStop = False
        Me.Nature_Element_Exonere_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nature_Element_Exonere_txt.UseSystemPasswordChar = False
        '
        'Lib_Nature_Element_Exonere_txt
        '
        Me.Lib_Nature_Element_Exonere_txt.AccessibleDescription = "A"
        Me.Lib_Nature_Element_Exonere_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Nature_Element_Exonere_txt.ContextMenuStrip = Nothing
        Me.Lib_Nature_Element_Exonere_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Nature_Element_Exonere_txt.Location = New System.Drawing.Point(325, 289)
        Me.Lib_Nature_Element_Exonere_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Nature_Element_Exonere_txt.MaxLength = 32767
        Me.Lib_Nature_Element_Exonere_txt.Multiline = False
        Me.Lib_Nature_Element_Exonere_txt.Name = "Lib_Nature_Element_Exonere_txt"
        Me.Lib_Nature_Element_Exonere_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Nature_Element_Exonere_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Nature_Element_Exonere_txt.ReadOnly = True
        Me.Lib_Nature_Element_Exonere_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Nature_Element_Exonere_txt.SelectionStart = 0
        Me.Lib_Nature_Element_Exonere_txt.Size = New System.Drawing.Size(419, 26)
        Me.Lib_Nature_Element_Exonere_txt.TabIndex = 228
        Me.Lib_Nature_Element_Exonere_txt.TabStop = False
        Me.Lib_Nature_Element_Exonere_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Nature_Element_Exonere_txt.UseSystemPasswordChar = False
        '
        'element_calcul_pnl
        '
        Me.element_calcul_pnl.ColumnCount = 4
        Me.element_calcul_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88.0!))
        Me.element_calcul_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.element_calcul_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.element_calcul_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.element_calcul_pnl.Controls.Add(Me.detail_4_btn, 2, 3)
        Me.element_calcul_pnl.Controls.Add(Me.formule_4_btn, 3, 3)
        Me.element_calcul_pnl.Controls.Add(Me.detail_3_btn, 2, 2)
        Me.element_calcul_pnl.Controls.Add(Me.formule_3_btn, 3, 2)
        Me.element_calcul_pnl.Controls.Add(Me.detail_2_btn, 2, 1)
        Me.element_calcul_pnl.Controls.Add(Me.formule_2_btn, 3, 1)
        Me.element_calcul_pnl.Controls.Add(Me.detail_1_btn, 2, 0)
        Me.element_calcul_pnl.Controls.Add(Me.Base_txt, 1, 2)
        Me.element_calcul_pnl.Controls.Add(Me.Relation_txt, 1, 3)
        Me.element_calcul_pnl.Controls.Add(Me.Nb_lbl, 0, 1)
        Me.element_calcul_pnl.Controls.Add(Me.Label4, 0, 2)
        Me.element_calcul_pnl.Controls.Add(Me.Label5, 0, 3)
        Me.element_calcul_pnl.Controls.Add(Me.Nb_txt, 1, 1)
        Me.element_calcul_pnl.Controls.Add(Me.Label2, 0, 0)
        Me.element_calcul_pnl.Controls.Add(Me.Tx_txt, 1, 0)
        Me.element_calcul_pnl.Controls.Add(Me.formule_1_btn, 3, 0)
        Me.element_calcul_pnl.Location = New System.Drawing.Point(4, 4)
        Me.element_calcul_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.element_calcul_pnl.Name = "element_calcul_pnl"
        Me.element_calcul_pnl.RowCount = 4
        Me.element_calcul_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.element_calcul_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.element_calcul_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.element_calcul_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.element_calcul_pnl.Size = New System.Drawing.Size(360, 146)
        Me.element_calcul_pnl.TabIndex = 232
        '
        'detail_4_btn
        '
        Me.detail_4_btn.AutoSize = True
        Me.detail_4_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.detail_4_btn.bgColor = System.Drawing.Color.White
        Me.detail_4_btn.Border = RHP.ud_button.BorderStyle.None
        Me.detail_4_btn.BorderColor = System.Drawing.Color.Empty
        Me.detail_4_btn.BorderSize = 0
        Me.detail_4_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.detail_4_btn.Image = Global.RHP.My.Resources.Resources.btn_detail
        Me.detail_4_btn.isDefault = False
        Me.detail_4_btn.Location = New System.Drawing.Point(288, 120)
        Me.detail_4_btn.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.detail_4_btn.MinimumSize = New System.Drawing.Size(29, 29)
        Me.detail_4_btn.Name = "detail_4_btn"
        Me.detail_4_btn.Size = New System.Drawing.Size(29, 29)
        Me.detail_4_btn.TabIndex = 236
        Me.detail_4_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.detail_4_btn.ToolTip = "Détail"
        '
        'formule_4_btn
        '
        Me.formule_4_btn.AutoSize = True
        Me.formule_4_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.formule_4_btn.bgColor = System.Drawing.Color.White
        Me.formule_4_btn.Border = RHP.ud_button.BorderStyle.None
        Me.formule_4_btn.BorderColor = System.Drawing.Color.Empty
        Me.formule_4_btn.BorderSize = 0
        Me.formule_4_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.formule_4_btn.Image = Global.RHP.My.Resources.Resources.btn_function
        Me.formule_4_btn.isDefault = False
        Me.formule_4_btn.Location = New System.Drawing.Point(326, 122)
        Me.formule_4_btn.Margin = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.formule_4_btn.MinimumSize = New System.Drawing.Size(29, 29)
        Me.formule_4_btn.Name = "formule_4_btn"
        Me.formule_4_btn.Size = New System.Drawing.Size(29, 29)
        Me.formule_4_btn.TabIndex = 237
        Me.formule_4_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.formule_4_btn.ToolTip = "Formule"
        '
        'detail_3_btn
        '
        Me.detail_3_btn.AutoSize = True
        Me.detail_3_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.detail_3_btn.bgColor = System.Drawing.Color.White
        Me.detail_3_btn.Border = RHP.ud_button.BorderStyle.None
        Me.detail_3_btn.BorderColor = System.Drawing.Color.Empty
        Me.detail_3_btn.BorderSize = 0
        Me.detail_3_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.detail_3_btn.Image = Global.RHP.My.Resources.Resources.btn_detail
        Me.detail_3_btn.isDefault = False
        Me.detail_3_btn.Location = New System.Drawing.Point(288, 82)
        Me.detail_3_btn.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.detail_3_btn.MinimumSize = New System.Drawing.Size(29, 29)
        Me.detail_3_btn.Name = "detail_3_btn"
        Me.detail_3_btn.Size = New System.Drawing.Size(29, 29)
        Me.detail_3_btn.TabIndex = 234
        Me.detail_3_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.detail_3_btn.ToolTip = "Détail"
        '
        'formule_3_btn
        '
        Me.formule_3_btn.AutoSize = True
        Me.formule_3_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.formule_3_btn.bgColor = System.Drawing.Color.White
        Me.formule_3_btn.Border = RHP.ud_button.BorderStyle.None
        Me.formule_3_btn.BorderColor = System.Drawing.Color.Empty
        Me.formule_3_btn.BorderSize = 0
        Me.formule_3_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.formule_3_btn.Image = Global.RHP.My.Resources.Resources.btn_function
        Me.formule_3_btn.isDefault = False
        Me.formule_3_btn.Location = New System.Drawing.Point(326, 84)
        Me.formule_3_btn.Margin = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.formule_3_btn.MinimumSize = New System.Drawing.Size(29, 29)
        Me.formule_3_btn.Name = "formule_3_btn"
        Me.formule_3_btn.Size = New System.Drawing.Size(29, 29)
        Me.formule_3_btn.TabIndex = 235
        Me.formule_3_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.formule_3_btn.ToolTip = "Formule"
        '
        'detail_2_btn
        '
        Me.detail_2_btn.AutoSize = True
        Me.detail_2_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.detail_2_btn.bgColor = System.Drawing.Color.White
        Me.detail_2_btn.Border = RHP.ud_button.BorderStyle.None
        Me.detail_2_btn.BorderColor = System.Drawing.Color.Empty
        Me.detail_2_btn.BorderSize = 0
        Me.detail_2_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.detail_2_btn.Image = Global.RHP.My.Resources.Resources.btn_detail
        Me.detail_2_btn.isDefault = False
        Me.detail_2_btn.Location = New System.Drawing.Point(288, 44)
        Me.detail_2_btn.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.detail_2_btn.MinimumSize = New System.Drawing.Size(29, 29)
        Me.detail_2_btn.Name = "detail_2_btn"
        Me.detail_2_btn.Size = New System.Drawing.Size(29, 29)
        Me.detail_2_btn.TabIndex = 232
        Me.detail_2_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.detail_2_btn.ToolTip = "Détail"
        '
        'formule_2_btn
        '
        Me.formule_2_btn.AutoSize = True
        Me.formule_2_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.formule_2_btn.bgColor = System.Drawing.Color.White
        Me.formule_2_btn.Border = RHP.ud_button.BorderStyle.None
        Me.formule_2_btn.BorderColor = System.Drawing.Color.Empty
        Me.formule_2_btn.BorderSize = 0
        Me.formule_2_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.formule_2_btn.Image = Global.RHP.My.Resources.Resources.btn_function
        Me.formule_2_btn.isDefault = False
        Me.formule_2_btn.Location = New System.Drawing.Point(326, 46)
        Me.formule_2_btn.Margin = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.formule_2_btn.MinimumSize = New System.Drawing.Size(29, 29)
        Me.formule_2_btn.Name = "formule_2_btn"
        Me.formule_2_btn.Size = New System.Drawing.Size(29, 29)
        Me.formule_2_btn.TabIndex = 233
        Me.formule_2_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.formule_2_btn.ToolTip = "Formule"
        '
        'detail_1_btn
        '
        Me.detail_1_btn.AutoSize = True
        Me.detail_1_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.detail_1_btn.bgColor = System.Drawing.Color.White
        Me.detail_1_btn.Border = RHP.ud_button.BorderStyle.None
        Me.detail_1_btn.BorderColor = System.Drawing.Color.Empty
        Me.detail_1_btn.BorderSize = 0
        Me.detail_1_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.detail_1_btn.Image = Global.RHP.My.Resources.Resources.btn_detail
        Me.detail_1_btn.isDefault = False
        Me.detail_1_btn.Location = New System.Drawing.Point(288, 5)
        Me.detail_1_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.detail_1_btn.MinimumSize = New System.Drawing.Size(29, 29)
        Me.detail_1_btn.Name = "detail_1_btn"
        Me.detail_1_btn.Size = New System.Drawing.Size(29, 29)
        Me.detail_1_btn.TabIndex = 231
        Me.detail_1_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.detail_1_btn.ToolTip = "Détail"
        '
        'Base_txt
        '
        Me.Base_txt.AccessibleDescription = "A"
        Me.Base_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Base_txt.ContextMenuStrip = Nothing
        Me.Base_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Base_txt.Location = New System.Drawing.Point(92, 78)
        Me.Base_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Base_txt.MaxLength = 32767
        Me.Base_txt.Multiline = False
        Me.Base_txt.Name = "Base_txt"
        Me.Base_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Base_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Base_txt.ReadOnly = False
        Me.Base_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Base_txt.SelectionStart = 0
        Me.Base_txt.Size = New System.Drawing.Size(188, 34)
        Me.Base_txt.TabIndex = 206
        Me.Base_txt.TabStop = False
        Me.Base_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Base_txt.UseSystemPasswordChar = False
        '
        'Relation_txt
        '
        Me.Relation_txt.AccessibleDescription = "A"
        Me.Relation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Relation_txt.ContextMenuStrip = Nothing
        Me.Relation_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Relation_txt.Location = New System.Drawing.Point(92, 116)
        Me.Relation_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Relation_txt.MaxLength = 32767
        Me.Relation_txt.Multiline = False
        Me.Relation_txt.Name = "Relation_txt"
        Me.Relation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Relation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Relation_txt.ReadOnly = True
        Me.Relation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Relation_txt.SelectionStart = 0
        Me.Relation_txt.Size = New System.Drawing.Size(188, 34)
        Me.Relation_txt.TabIndex = 206
        Me.Relation_txt.TabStop = False
        Me.Relation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Relation_txt.UseSystemPasswordChar = False
        '
        'Nb_lbl
        '
        Me.Nb_lbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nb_lbl.AutoSize = True
        Me.Nb_lbl.Location = New System.Drawing.Point(20, 38)
        Me.Nb_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Nb_lbl.Name = "Nb_lbl"
        Me.Nb_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Nb_lbl.Size = New System.Drawing.Size(64, 38)
        Me.Nb_lbl.TabIndex = 205
        Me.Nb_lbl.Text = "Nombre"
        Me.Nb_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 76)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 38)
        Me.Label4.TabIndex = 205
        Me.Label4.Text = "Base"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 114)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 38)
        Me.Label5.TabIndex = 205
        Me.Label5.Text = "Relation"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Nb_txt
        '
        Me.Nb_txt.AccessibleDescription = "A"
        Me.Nb_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nb_txt.ContextMenuStrip = Nothing
        Me.Nb_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Nb_txt.Location = New System.Drawing.Point(92, 40)
        Me.Nb_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Nb_txt.MaxLength = 32767
        Me.Nb_txt.Multiline = False
        Me.Nb_txt.Name = "Nb_txt"
        Me.Nb_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nb_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nb_txt.ReadOnly = False
        Me.Nb_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nb_txt.SelectionStart = 0
        Me.Nb_txt.Size = New System.Drawing.Size(188, 34)
        Me.Nb_txt.TabIndex = 206
        Me.Nb_txt.TabStop = False
        Me.Nb_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nb_txt.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 38)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "Taux"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tx_txt
        '
        Me.Tx_txt.AccessibleDescription = "A"
        Me.Tx_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Tx_txt.ContextMenuStrip = Nothing
        Me.Tx_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tx_txt.Location = New System.Drawing.Point(92, 2)
        Me.Tx_txt.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Tx_txt.MaxLength = 32767
        Me.Tx_txt.Multiline = False
        Me.Tx_txt.Name = "Tx_txt"
        Me.Tx_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Tx_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Tx_txt.ReadOnly = False
        Me.Tx_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Tx_txt.SelectionStart = 0
        Me.Tx_txt.Size = New System.Drawing.Size(188, 34)
        Me.Tx_txt.TabIndex = 206
        Me.Tx_txt.TabStop = False
        Me.Tx_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Tx_txt.UseSystemPasswordChar = False
        '
        'formule_1_btn
        '
        Me.formule_1_btn.AutoSize = True
        Me.formule_1_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.formule_1_btn.bgColor = System.Drawing.Color.White
        Me.formule_1_btn.Border = RHP.ud_button.BorderStyle.None
        Me.formule_1_btn.BorderColor = System.Drawing.Color.Empty
        Me.formule_1_btn.BorderSize = 0
        Me.formule_1_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.formule_1_btn.Image = Global.RHP.My.Resources.Resources.btn_function
        Me.formule_1_btn.isDefault = False
        Me.formule_1_btn.Location = New System.Drawing.Point(326, 6)
        Me.formule_1_btn.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.formule_1_btn.MinimumSize = New System.Drawing.Size(29, 29)
        Me.formule_1_btn.Name = "formule_1_btn"
        Me.formule_1_btn.Size = New System.Drawing.Size(29, 29)
        Me.formule_1_btn.TabIndex = 231
        Me.formule_1_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.formule_1_btn.ToolTip = "Formule"
        '
        'Grp3
        '
        Me.Grp3.Controls.Add(Me.Personnal_pnl)
        Me.Grp3.Controls.Add(Me.eleCalcul_pnl)
        Me.Grp3.Controls.Add(Me.lb_Val)
        Me.Grp3.Controls.Add(Me.Val_Defaut_txt)
        Me.Grp3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grp3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grp3.Location = New System.Drawing.Point(4, 4)
        Me.Grp3.Margin = New System.Windows.Forms.Padding(4)
        Me.Grp3.Name = "Grp3"
        Me.Grp3.Padding = New System.Windows.Forms.Padding(4)
        Me.Grp3.Size = New System.Drawing.Size(1190, 241)
        Me.Grp3.TabIndex = 6
        Me.Grp3.TabStop = False
        Me.Grp3.Text = "Nature"
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.ColumnCount = 1
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.Personnal_pnl.Controls.Add(Me.EC_Rd, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.EB_Rd, 0, 1)
        Me.Personnal_pnl.Controls.Add(Me.CS_rd, 0, 4)
        Me.Personnal_pnl.Controls.Add(Me.EX_Rd, 0, 2)
        Me.Personnal_pnl.Controls.Add(Me.EV_Rd, 0, 3)
        Me.Personnal_pnl.Location = New System.Drawing.Point(8, 34)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 6
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(250, 191)
        Me.Personnal_pnl.TabIndex = 230
        '
        'EC_Rd
        '
        Me.EC_Rd.AutoSize = True
        Me.EC_Rd.Checked = True
        Me.EC_Rd.Location = New System.Drawing.Point(4, 2)
        Me.EC_Rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.EC_Rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.EC_Rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.EC_Rd.Name = "EC_Rd"
        Me.EC_Rd.Size = New System.Drawing.Size(154, 31)
        Me.EC_Rd.TabIndex = 5
        Me.EC_Rd.Text = "Elément calculé"
        '
        'EB_Rd
        '
        Me.EB_Rd.AutoSize = True
        Me.EB_Rd.Checked = False
        Me.EB_Rd.Location = New System.Drawing.Point(4, 33)
        Me.EB_Rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.EB_Rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.EB_Rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.EB_Rd.Name = "EB_Rd"
        Me.EB_Rd.Size = New System.Drawing.Size(159, 31)
        Me.EB_Rd.TabIndex = 6
        Me.EB_Rd.Text = "Elément de base"
        '
        'CS_rd
        '
        Me.CS_rd.AutoSize = True
        Me.CS_rd.Checked = False
        Me.CS_rd.Location = New System.Drawing.Point(4, 126)
        Me.CS_rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CS_rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.CS_rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.CS_rd.Name = "CS_rd"
        Me.CS_rd.Size = New System.Drawing.Size(190, 31)
        Me.CS_rd.TabIndex = 9
        Me.CS_rd.Text = "Constante de la paie"
        '
        'EX_Rd
        '
        Me.EX_Rd.AutoSize = True
        Me.EX_Rd.Checked = False
        Me.EX_Rd.Location = New System.Drawing.Point(4, 64)
        Me.EX_Rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.EX_Rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.EX_Rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.EX_Rd.Name = "EX_Rd"
        Me.EX_Rd.Size = New System.Drawing.Size(215, 31)
        Me.EX_Rd.TabIndex = 6
        Me.EX_Rd.Text = "Elément de base calculé"
        '
        'EV_Rd
        '
        Me.EV_Rd.AutoSize = True
        Me.EV_Rd.Checked = False
        Me.EV_Rd.Location = New System.Drawing.Point(4, 95)
        Me.EV_Rd.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.EV_Rd.MaximumSize = New System.Drawing.Size(0, 31)
        Me.EV_Rd.MinimumSize = New System.Drawing.Size(0, 31)
        Me.EV_Rd.Name = "EV_Rd"
        Me.EV_Rd.Size = New System.Drawing.Size(159, 31)
        Me.EV_Rd.TabIndex = 7
        Me.EV_Rd.Text = "Elément variable"
        '
        'eleCalcul_pnl
        '
        Me.eleCalcul_pnl.Controls.Add(Me.element_calcul_pnl)
        Me.eleCalcul_pnl.Controls.Add(Me.estMajAuto_chk)
        Me.eleCalcul_pnl.Controls.Add(Me.msg_lbl)
        Me.eleCalcul_pnl.Location = New System.Drawing.Point(669, 24)
        Me.eleCalcul_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.eleCalcul_pnl.Name = "eleCalcul_pnl"
        Me.eleCalcul_pnl.Size = New System.Drawing.Size(486, 218)
        Me.eleCalcul_pnl.TabIndex = 233
        '
        'estMajAuto_chk
        '
        Me.estMajAuto_chk.AutoSize = True
        Me.estMajAuto_chk.Checked = False
        Me.estMajAuto_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.estMajAuto_chk.Location = New System.Drawing.Point(89, 159)
        Me.estMajAuto_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.estMajAuto_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.estMajAuto_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.estMajAuto_chk.Name = "estMajAuto_chk"
        Me.estMajAuto_chk.Size = New System.Drawing.Size(198, 31)
        Me.estMajAuto_chk.TabIndex = 209
        Me.estMajAuto_chk.Text = "Mise à jour automatique"
        '
        'msg_lbl
        '
        Me.msg_lbl.AutoSize = True
        Me.msg_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msg_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.msg_lbl.Location = New System.Drawing.Point(85, 190)
        Me.msg_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.msg_lbl.Name = "msg_lbl"
        Me.msg_lbl.Size = New System.Drawing.Size(345, 17)
        Me.msg_lbl.TabIndex = 208
        Me.msg_lbl.Text = "Cette rubrique sera mise à jour automatiquement."
        Me.msg_lbl.Visible = False
        '
        'lb_Val
        '
        Me.lb_Val.AutoSize = True
        Me.lb_Val.Location = New System.Drawing.Point(288, 140)
        Me.lb_Val.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Val.Name = "lb_Val"
        Me.lb_Val.Size = New System.Drawing.Size(53, 19)
        Me.lb_Val.TabIndex = 207
        Me.lb_Val.Text = "Valeur"
        Me.lb_Val.Visible = False
        '
        'Val_Defaut_txt
        '
        Me.Val_Defaut_txt.AccessibleDescription = "A"
        Me.Val_Defaut_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Val_Defaut_txt.ContextMenuStrip = Nothing
        Me.Val_Defaut_txt.Location = New System.Drawing.Point(345, 136)
        Me.Val_Defaut_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Val_Defaut_txt.MaxLength = 50
        Me.Val_Defaut_txt.Multiline = False
        Me.Val_Defaut_txt.Name = "Val_Defaut_txt"
        Me.Val_Defaut_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Val_Defaut_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Val_Defaut_txt.ReadOnly = False
        Me.Val_Defaut_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Val_Defaut_txt.SelectionStart = 0
        Me.Val_Defaut_txt.Size = New System.Drawing.Size(231, 26)
        Me.Val_Defaut_txt.TabIndex = 8
        Me.Val_Defaut_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Val_Defaut_txt.UseSystemPasswordChar = False
        Me.Val_Defaut_txt.Visible = False
        '
        'Grp5
        '
        Me.Grp5.Controls.Add(Me.Ventilable_chk)
        Me.Grp5.Controls.Add(Me.Button5)
        Me.Grp5.Controls.Add(Me.Button6)
        Me.Grp5.Controls.Add(Me.Cpt_Credit_txt)
        Me.Grp5.Controls.Add(Me.Label6)
        Me.Grp5.Controls.Add(Me.Cpt_Debit_txt)
        Me.Grp5.Controls.Add(Me.Label7)
        Me.Grp5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grp5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grp5.Location = New System.Drawing.Point(4, 4)
        Me.Grp5.Margin = New System.Windows.Forms.Padding(4)
        Me.Grp5.Name = "Grp5"
        Me.Grp5.Padding = New System.Windows.Forms.Padding(4)
        Me.Grp5.Size = New System.Drawing.Size(1190, 124)
        Me.Grp5.TabIndex = 209
        Me.Grp5.TabStop = False
        Me.Grp5.Text = "Comptabilité"
        '
        'Ventilable_chk
        '
        Me.Ventilable_chk.AutoSize = True
        Me.Ventilable_chk.Checked = False
        Me.Ventilable_chk.Location = New System.Drawing.Point(106, 86)
        Me.Ventilable_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.Ventilable_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Ventilable_chk.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Ventilable_chk.Name = "Ventilable_chk"
        Me.Ventilable_chk.Size = New System.Drawing.Size(215, 25)
        Me.Ventilable_chk.TabIndex = 228
        Me.Ventilable_chk.Text = "Ventilable analytiquement"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(282, 54)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(35, 25)
        Me.Button5.TabIndex = 212
        Me.Button5.Text = "---"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(282, 25)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(35, 25)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "---"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Cpt_Credit_txt
        '
        Me.Cpt_Credit_txt.AccessibleDescription = "A"
        Me.Cpt_Credit_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cpt_Credit_txt.ContextMenuStrip = Nothing
        Me.Cpt_Credit_txt.Location = New System.Drawing.Point(106, 55)
        Me.Cpt_Credit_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Cpt_Credit_txt.MaxLength = 32767
        Me.Cpt_Credit_txt.Multiline = False
        Me.Cpt_Credit_txt.Name = "Cpt_Credit_txt"
        Me.Cpt_Credit_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cpt_Credit_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cpt_Credit_txt.ReadOnly = True
        Me.Cpt_Credit_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cpt_Credit_txt.SelectionStart = 0
        Me.Cpt_Credit_txt.Size = New System.Drawing.Size(172, 26)
        Me.Cpt_Credit_txt.TabIndex = 210
        Me.Cpt_Credit_txt.TabStop = False
        Me.Cpt_Credit_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cpt_Credit_txt.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 19)
        Me.Label6.TabIndex = 208
        Me.Label6.Text = "Crédit"
        '
        'Cpt_Debit_txt
        '
        Me.Cpt_Debit_txt.AccessibleDescription = "A"
        Me.Cpt_Debit_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cpt_Debit_txt.ContextMenuStrip = Nothing
        Me.Cpt_Debit_txt.Location = New System.Drawing.Point(106, 25)
        Me.Cpt_Debit_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Cpt_Debit_txt.MaxLength = 32767
        Me.Cpt_Debit_txt.Multiline = False
        Me.Cpt_Debit_txt.Name = "Cpt_Debit_txt"
        Me.Cpt_Debit_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cpt_Debit_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cpt_Debit_txt.ReadOnly = True
        Me.Cpt_Debit_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cpt_Debit_txt.SelectionStart = 0
        Me.Cpt_Debit_txt.Size = New System.Drawing.Size(172, 26)
        Me.Cpt_Debit_txt.TabIndex = 211
        Me.Cpt_Debit_txt.TabStop = False
        Me.Cpt_Debit_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cpt_Debit_txt.UseSystemPasswordChar = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(45, 28)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 19)
        Me.Label7.TabIndex = 209
        Me.Label7.Text = "Débit"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 126)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1206, 640)
        Me.TabControl1.TabIndex = 208
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Grp2)
        Me.TabPage1.Controls.Add(Me.Grp3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1198, 608)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Paramétrages"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Grp4)
        Me.TabPage3.Controls.Add(Me.Grp5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Size = New System.Drawing.Size(1198, 608)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Divers"
        '
        'Grp4
        '
        Me.Grp4.Controls.Add(Me.lblColor)
        Me.Grp4.Controls.Add(Me.LinkLabel12)
        Me.Grp4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grp4.Location = New System.Drawing.Point(4, 128)
        Me.Grp4.Margin = New System.Windows.Forms.Padding(4)
        Me.Grp4.Name = "Grp4"
        Me.Grp4.Padding = New System.Windows.Forms.Padding(4)
        Me.Grp4.Size = New System.Drawing.Size(1190, 101)
        Me.Grp4.TabIndex = 210
        Me.Grp4.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Commentaire)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1198, 608)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Narratif"
        '
        'Commentaire
        '
        Me.Commentaire.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Commentaire.Location = New System.Drawing.Point(4, 4)
        Me.Commentaire.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Commentaire.Name = "Commentaire"
        Me.Commentaire.ReadOnly = False
        Me.Commentaire.Size = New System.Drawing.Size(1190, 600)
        Me.Commentaire.TabIndex = 228
        '
        'RH_Parametrage_Rubrique_Paie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1206, 766)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Grp1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RH_Parametrage_Rubrique_Paie"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage des rubriques de la paie"
        Me.Grp1.ResumeLayout(False)
        Me.Grp1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Nb_Decimal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp2.ResumeLayout(False)
        Me.Grp2.PerformLayout()
        Me.Grp_Categorie.ResumeLayout(False)
        Me.Pnl_Categorie.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Imposable_Grp.ResumeLayout(False)
        Me.Imposable_Grp.PerformLayout()
        Me.element_calcul_pnl.ResumeLayout(False)
        Me.element_calcul_pnl.PerformLayout()
        Me.Grp3.ResumeLayout(False)
        Me.Grp3.PerformLayout()
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Personnal_pnl.PerformLayout()
        Me.eleCalcul_pnl.ResumeLayout(False)
        Me.eleCalcul_pnl.PerformLayout()
        Me.Grp5.ResumeLayout(False)
        Me.Grp5.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Grp4.ResumeLayout(False)
        Me.Grp4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grp1 As GroupBox
    Friend WithEvents Abr_Rubrique_txt As ud_TextBox
    Friend WithEvents Rub_ As LinkLabel
    Friend WithEvents Cod_Rubrique_txt As ud_TextBox
    Friend WithEvents Lib_Rubrique_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Private WithEvents Grp5 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Cpt_Credit_txt As ud_TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Cpt_Debit_txt As ud_TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Patronal_rd As ud_RadioBox
    Friend WithEvents Salarial_rd As ud_RadioBox
    Private WithEvents Grp_Categorie As GroupBox
    Friend WithEvents Retenue_rd As ud_RadioBox
    Friend WithEvents Gain_rd As ud_RadioBox
    Friend WithEvents Relation_txt As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Base_txt As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Nb_txt As ud_TextBox
    Friend WithEvents Nb_lbl As Label
    Friend WithEvents Tx_txt As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Typ_Retour_ As Label
    Friend WithEvents Typ_Retour As ud_ComboBox
    Private WithEvents Grp3 As GroupBox
    Friend WithEvents EB_Rd As ud_RadioBox
    Friend WithEvents EV_Rd As ud_RadioBox
    Friend WithEvents EC_Rd As ud_RadioBox
    Friend WithEvents Utilise_chk As ud_CheckBox
    Friend WithEvents lb_Val As Label
    Friend WithEvents Val_Defaut_txt As ud_TextBox
    Friend WithEvents Groupe_lbl As Label
    Friend WithEvents Typ_Rubrique_Paie As ud_ComboBox
    Friend WithEvents Grp2 As GroupBox
    Friend WithEvents CS_rd As ud_RadioBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Nb_Decimal As NumericUpDown
    Friend WithEvents Autre_Rd As ud_RadioBox
    Friend WithEvents Est_Pourcentage_chk As ud_CheckBox
    Friend WithEvents Cumulable_chk As ud_CheckBox
    Friend WithEvents Ventilable_chk As ud_CheckBox
    Friend WithEvents Commentaire As ud_RichTextBox
    Friend WithEvents NatureElementExonere As LinkLabel
    Friend WithEvents Lib_Nature_Element_Exonere_txt As ud_TextBox
    Friend WithEvents Nature_Element_Exonere_txt As ud_TextBox
    Friend WithEvents lblColor As LinkLabel
    Friend WithEvents LinkLabel12 As LinkLabel
    Friend WithEvents ud_RadioBox1 As ud_RadioBox
    Friend WithEvents Imposable_Grp As GroupBox
    Friend WithEvents Imposable_CNSS_chk As ud_CheckBox
    Friend WithEvents Imposable_IR_chk As ud_CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Deductible_CNSS_chk As ud_CheckBox
    Friend WithEvents Deductible_IR_chk As ud_CheckBox
    Friend WithEvents Rubrique_Globale_chk As ud_CheckBox
    Friend WithEvents estSysteme_chk As ud_CheckBox
    Friend WithEvents Grp4 As GroupBox
    Friend WithEvents msg_lbl As Label
    Friend WithEvents estMajAuto_chk As ud_CheckBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents eleCalcul_pnl As Panel
    Friend WithEvents EX_Rd As ud_RadioBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents detail_1_btn As ud_button
    Friend WithEvents element_calcul_pnl As TableLayoutPanel
    Friend WithEvents formule_1_btn As ud_button
    Friend WithEvents detail_4_btn As ud_button
    Friend WithEvents formule_4_btn As ud_button
    Friend WithEvents detail_3_btn As ud_button
    Friend WithEvents formule_3_btn As ud_button
    Friend WithEvents detail_2_btn As ud_button
    Friend WithEvents formule_2_btn As ud_button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Ud_Proteger As ud_CheckBox
    Friend WithEvents Pnl_Categorie As Panel
End Class
