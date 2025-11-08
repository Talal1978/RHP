<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Param_Abonnement
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

    'REMARQUE : la Requête suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Abonnement_Text = New RHP.ud_TextBox()
        Me.Cod_Abonnement_Text = New RHP.ud_TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Heure_Abonnement_Mtxt = New RHP.TimeTxt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Dimanche_Check = New RHP.ud_CheckBox()
        Me.Samedi_Check = New RHP.ud_CheckBox()
        Me.Vendredi_Check = New RHP.ud_CheckBox()
        Me.Jeudi_Check = New RHP.ud_CheckBox()
        Me.Mercredi_Check = New RHP.ud_CheckBox()
        Me.Mardi_Check = New RHP.ud_CheckBox()
        Me.Lundi_Check = New RHP.ud_CheckBox()
        Me.Typ_Frequence_Combo = New RHP.ud_ComboBox()
        Me.Frequence = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Deb_Application_Text = New RHP.ud_TextBox()
        Me.Dat_Fin_Application_Text = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Lib_Typ_Pie_Abonnement = New RHP.ud_TextBox()
        Me.Typ_Pie_Abonnement = New RHP.ud_TextBox()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Source_lb = New System.Windows.Forms.Label()
        Me.Ref_Abonnement = New RHP.ud_TextBox()
        Me.Source_Abonnement = New RHP.ud_ComboBox()
        Me.Lib_Ref_Abonnement = New RHP.ud_TextBox()
        Me.Actif_Check = New RHP.ud_CheckBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Abonnement_Grd = New System.Windows.Forms.DataGridView()
        Me.Personnal_pnl.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Frequence, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.Abonnement_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(18, 28)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(100, 19)
        Me.LinkLabel4.TabIndex = 0
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = ""
        Me.LinkLabel4.Text = "Abonnement"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Abonnement_Text
        '
        Me.Lib_Abonnement_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Abonnement_Text.ContextMenuStrip = Nothing
        Me.Lib_Abonnement_Text.Location = New System.Drawing.Point(274, 24)
        Me.Lib_Abonnement_Text.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Lib_Abonnement_Text.MaxLength = 100
        Me.Lib_Abonnement_Text.Multiline = False
        Me.Lib_Abonnement_Text.Name = "Lib_Abonnement_Text"
        Me.Lib_Abonnement_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Abonnement_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Abonnement_Text.ReadOnly = False
        Me.Lib_Abonnement_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Abonnement_Text.SelectionStart = 0
        Me.Lib_Abonnement_Text.Size = New System.Drawing.Size(758, 26)
        Me.Lib_Abonnement_Text.TabIndex = 1
        Me.Lib_Abonnement_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Abonnement_Text.UseSystemPasswordChar = False
        '
        'Cod_Abonnement_Text
        '
        Me.Cod_Abonnement_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Abonnement_Text.ContextMenuStrip = Nothing
        Me.Cod_Abonnement_Text.Location = New System.Drawing.Point(121, 24)
        Me.Cod_Abonnement_Text.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Cod_Abonnement_Text.MaxLength = 32767
        Me.Cod_Abonnement_Text.Multiline = False
        Me.Cod_Abonnement_Text.Name = "Cod_Abonnement_Text"
        Me.Cod_Abonnement_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Abonnement_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Abonnement_Text.ReadOnly = True
        Me.Cod_Abonnement_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Abonnement_Text.SelectionStart = 0
        Me.Cod_Abonnement_Text.Size = New System.Drawing.Size(145, 26)
        Me.Cod_Abonnement_Text.TabIndex = 96
        Me.Cod_Abonnement_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Abonnement_Text.UseSystemPasswordChar = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1128, 796)
        Me.TabControl1.TabIndex = 216
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1120, 764)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Abonnement"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Heure_Abonnement_Mtxt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Dimanche_Check)
        Me.GroupBox1.Controls.Add(Me.Samedi_Check)
        Me.GroupBox1.Controls.Add(Me.Vendredi_Check)
        Me.GroupBox1.Controls.Add(Me.Jeudi_Check)
        Me.GroupBox1.Controls.Add(Me.Mercredi_Check)
        Me.GroupBox1.Controls.Add(Me.Mardi_Check)
        Me.GroupBox1.Controls.Add(Me.Lundi_Check)
        Me.GroupBox1.Controls.Add(Me.Typ_Frequence_Combo)
        Me.GroupBox1.Controls.Add(Me.Frequence)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LinkLabel3)
        Me.GroupBox1.Controls.Add(Me.Dat_Deb_Application_Text)
        Me.GroupBox1.Controls.Add(Me.Dat_Fin_Application_Text)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 159)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1112, 149)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Heure_Abonnement_Mtxt
        '
        Me.Heure_Abonnement_Mtxt.Location = New System.Drawing.Point(545, 25)
        Me.Heure_Abonnement_Mtxt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Heure_Abonnement_Mtxt.Mask = "00:00"
        Me.Heure_Abonnement_Mtxt.Name = "Heure_Abonnement_Mtxt"
        Me.Heure_Abonnement_Mtxt.Size = New System.Drawing.Size(44, 24)
        Me.Heure_Abonnement_Mtxt.TabIndex = 228
        Me.Heure_Abonnement_Mtxt.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(451, 28)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 19)
        Me.Label4.TabIndex = 212
        Me.Label4.Text = "à partir de :"
        '
        'Dimanche_Check
        '
        Me.Dimanche_Check.AutoSize = True
        Me.Dimanche_Check.Checked = True
        Me.Dimanche_Check.Location = New System.Drawing.Point(766, 72)
        Me.Dimanche_Check.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Dimanche_Check.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Dimanche_Check.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Dimanche_Check.Name = "Dimanche_Check"
        Me.Dimanche_Check.Size = New System.Drawing.Size(125, 25)
        Me.Dimanche_Check.TabIndex = 208
        Me.Dimanche_Check.Text = "Dimanche"
        '
        'Samedi_Check
        '
        Me.Samedi_Check.AutoSize = True
        Me.Samedi_Check.Checked = True
        Me.Samedi_Check.Location = New System.Drawing.Point(658, 101)
        Me.Samedi_Check.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Samedi_Check.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Samedi_Check.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Samedi_Check.Name = "Samedi_Check"
        Me.Samedi_Check.Size = New System.Drawing.Size(125, 25)
        Me.Samedi_Check.TabIndex = 208
        Me.Samedi_Check.Text = "Samedi"
        '
        'Vendredi_Check
        '
        Me.Vendredi_Check.AutoSize = True
        Me.Vendredi_Check.Checked = True
        Me.Vendredi_Check.Location = New System.Drawing.Point(658, 72)
        Me.Vendredi_Check.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Vendredi_Check.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Vendredi_Check.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Vendredi_Check.Name = "Vendredi_Check"
        Me.Vendredi_Check.Size = New System.Drawing.Size(125, 25)
        Me.Vendredi_Check.TabIndex = 208
        Me.Vendredi_Check.Text = "Vendredi"
        '
        'Jeudi_Check
        '
        Me.Jeudi_Check.AutoSize = True
        Me.Jeudi_Check.Checked = True
        Me.Jeudi_Check.Location = New System.Drawing.Point(554, 101)
        Me.Jeudi_Check.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Jeudi_Check.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Jeudi_Check.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Jeudi_Check.Name = "Jeudi_Check"
        Me.Jeudi_Check.Size = New System.Drawing.Size(125, 25)
        Me.Jeudi_Check.TabIndex = 208
        Me.Jeudi_Check.Text = "Jeudi"
        '
        'Mercredi_Check
        '
        Me.Mercredi_Check.AutoSize = True
        Me.Mercredi_Check.Checked = True
        Me.Mercredi_Check.Location = New System.Drawing.Point(554, 72)
        Me.Mercredi_Check.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Mercredi_Check.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Mercredi_Check.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Mercredi_Check.Name = "Mercredi_Check"
        Me.Mercredi_Check.Size = New System.Drawing.Size(125, 25)
        Me.Mercredi_Check.TabIndex = 208
        Me.Mercredi_Check.Text = "Mercredi"
        '
        'Mardi_Check
        '
        Me.Mardi_Check.AutoSize = True
        Me.Mardi_Check.Checked = True
        Me.Mardi_Check.Location = New System.Drawing.Point(455, 101)
        Me.Mardi_Check.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Mardi_Check.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Mardi_Check.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Mardi_Check.Name = "Mardi_Check"
        Me.Mardi_Check.Size = New System.Drawing.Size(125, 25)
        Me.Mardi_Check.TabIndex = 208
        Me.Mardi_Check.Text = "Mardi"
        '
        'Lundi_Check
        '
        Me.Lundi_Check.AutoSize = True
        Me.Lundi_Check.Checked = True
        Me.Lundi_Check.Location = New System.Drawing.Point(455, 72)
        Me.Lundi_Check.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Lundi_Check.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Lundi_Check.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Lundi_Check.Name = "Lundi_Check"
        Me.Lundi_Check.Size = New System.Drawing.Size(125, 25)
        Me.Lundi_Check.TabIndex = 208
        Me.Lundi_Check.Text = "Lundi"
        '
        'Typ_Frequence_Combo
        '
        Me.Typ_Frequence_Combo.DataSource = Nothing
        Me.Typ_Frequence_Combo.DisplayMember = ""
        Me.Typ_Frequence_Combo.DroppedDown = False
        Me.Typ_Frequence_Combo.Location = New System.Drawing.Point(261, 24)
        Me.Typ_Frequence_Combo.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Typ_Frequence_Combo.Name = "Typ_Frequence_Combo"
        Me.Typ_Frequence_Combo.SelectedIndex = -1
        Me.Typ_Frequence_Combo.SelectedItem = Nothing
        Me.Typ_Frequence_Combo.SelectedValue = Nothing
        Me.Typ_Frequence_Combo.Size = New System.Drawing.Size(151, 30)
        Me.Typ_Frequence_Combo.TabIndex = 207
        Me.Typ_Frequence_Combo.ValueMember = ""
        '
        'Frequence
        '
        Me.Frequence.Location = New System.Drawing.Point(161, 22)
        Me.Frequence.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Frequence.Name = "Frequence"
        Me.Frequence.Size = New System.Drawing.Size(96, 24)
        Me.Frequence.TabIndex = 206
        Me.Frequence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Frequence.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 19)
        Me.Label3.TabIndex = 205
        Me.Label3.Text = "Appliquer tous (es) les "
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(39, 105)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(66, 19)
        Me.LinkLabel3.TabIndex = 203
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = ""
        Me.LinkLabel3.Text = "Date Fin"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Dat_Deb_Application_Text
        '
        Me.Dat_Deb_Application_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Deb_Application_Text.ContextMenuStrip = Nothing
        Me.Dat_Deb_Application_Text.Enabled = False
        Me.Dat_Deb_Application_Text.Location = New System.Drawing.Point(115, 70)
        Me.Dat_Deb_Application_Text.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Dat_Deb_Application_Text.MaxLength = 32767
        Me.Dat_Deb_Application_Text.Multiline = False
        Me.Dat_Deb_Application_Text.Name = "Dat_Deb_Application_Text"
        Me.Dat_Deb_Application_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Deb_Application_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Deb_Application_Text.ReadOnly = False
        Me.Dat_Deb_Application_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Deb_Application_Text.SelectionStart = 0
        Me.Dat_Deb_Application_Text.Size = New System.Drawing.Size(182, 26)
        Me.Dat_Deb_Application_Text.TabIndex = 204
        Me.Dat_Deb_Application_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Deb_Application_Text.UseSystemPasswordChar = False
        '
        'Dat_Fin_Application_Text
        '
        Me.Dat_Fin_Application_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Fin_Application_Text.ContextMenuStrip = Nothing
        Me.Dat_Fin_Application_Text.Enabled = False
        Me.Dat_Fin_Application_Text.Location = New System.Drawing.Point(115, 101)
        Me.Dat_Fin_Application_Text.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Dat_Fin_Application_Text.MaxLength = 32767
        Me.Dat_Fin_Application_Text.Multiline = False
        Me.Dat_Fin_Application_Text.Name = "Dat_Fin_Application_Text"
        Me.Dat_Fin_Application_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Fin_Application_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Fin_Application_Text.ReadOnly = False
        Me.Dat_Fin_Application_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Fin_Application_Text.SelectionStart = 0
        Me.Dat_Fin_Application_Text.Size = New System.Drawing.Size(182, 26)
        Me.Dat_Fin_Application_Text.TabIndex = 204
        Me.Dat_Fin_Application_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Fin_Application_Text.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(18, 74)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(90, 19)
        Me.LinkLabel2.TabIndex = 201
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = ""
        Me.LinkLabel2.Text = "Date Début"
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Lib_Abonnement_Text)
        Me.GroupBox2.Controls.Add(Me.Lib_Typ_Pie_Abonnement)
        Me.GroupBox2.Controls.Add(Me.LinkLabel4)
        Me.GroupBox2.Controls.Add(Me.Typ_Pie_Abonnement)
        Me.GroupBox2.Controls.Add(Me.Cod_Abonnement_Text)
        Me.GroupBox2.Controls.Add(Me.LinkLabel6)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.Source_lb)
        Me.GroupBox2.Controls.Add(Me.Ref_Abonnement)
        Me.GroupBox2.Controls.Add(Me.Source_Abonnement)
        Me.GroupBox2.Controls.Add(Me.Lib_Ref_Abonnement)
        Me.GroupBox2.Controls.Add(Me.Actif_Check)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1112, 155)
        Me.GroupBox2.TabIndex = 10006
        Me.GroupBox2.TabStop = False
        '
        'Lib_Typ_Pie_Abonnement
        '
        Me.Lib_Typ_Pie_Abonnement.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Typ_Pie_Abonnement.ContextMenuStrip = Nothing
        Me.Lib_Typ_Pie_Abonnement.Location = New System.Drawing.Point(274, 122)
        Me.Lib_Typ_Pie_Abonnement.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Lib_Typ_Pie_Abonnement.MaxLength = 100
        Me.Lib_Typ_Pie_Abonnement.Multiline = False
        Me.Lib_Typ_Pie_Abonnement.Name = "Lib_Typ_Pie_Abonnement"
        Me.Lib_Typ_Pie_Abonnement.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Typ_Pie_Abonnement.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Typ_Pie_Abonnement.ReadOnly = True
        Me.Lib_Typ_Pie_Abonnement.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Typ_Pie_Abonnement.SelectionStart = 0
        Me.Lib_Typ_Pie_Abonnement.Size = New System.Drawing.Size(758, 26)
        Me.Lib_Typ_Pie_Abonnement.TabIndex = 10004
        Me.Lib_Typ_Pie_Abonnement.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Typ_Pie_Abonnement.UseSystemPasswordChar = False
        '
        'Typ_Pie_Abonnement
        '
        Me.Typ_Pie_Abonnement.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Typ_Pie_Abonnement.ContextMenuStrip = Nothing
        Me.Typ_Pie_Abonnement.Location = New System.Drawing.Point(121, 122)
        Me.Typ_Pie_Abonnement.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Typ_Pie_Abonnement.MaxLength = 32767
        Me.Typ_Pie_Abonnement.Multiline = False
        Me.Typ_Pie_Abonnement.Name = "Typ_Pie_Abonnement"
        Me.Typ_Pie_Abonnement.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Typ_Pie_Abonnement.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Typ_Pie_Abonnement.ReadOnly = True
        Me.Typ_Pie_Abonnement.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Typ_Pie_Abonnement.SelectionStart = 0
        Me.Typ_Pie_Abonnement.Size = New System.Drawing.Size(145, 26)
        Me.Typ_Pie_Abonnement.TabIndex = 10005
        Me.Typ_Pie_Abonnement.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Typ_Pie_Abonnement.UseSystemPasswordChar = False
        '
        'LinkLabel6
        '
        Me.LinkLabel6.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.Location = New System.Drawing.Point(34, 126)
        Me.LinkLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(83, 19)
        Me.LinkLabel6.TabIndex = 10003
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Tag = ""
        Me.LinkLabel6.Text = "Type Pièce"
        Me.LinkLabel6.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(39, 94)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(80, 19)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Reférence"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Source_lb
        '
        Me.Source_lb.AutoSize = True
        Me.Source_lb.Location = New System.Drawing.Point(61, 60)
        Me.Source_lb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Source_lb.Name = "Source_lb"
        Me.Source_lb.Size = New System.Drawing.Size(56, 19)
        Me.Source_lb.TabIndex = 10002
        Me.Source_lb.Text = "Source"
        '
        'Ref_Abonnement
        '
        Me.Ref_Abonnement.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ref_Abonnement.ContextMenuStrip = Nothing
        Me.Ref_Abonnement.Location = New System.Drawing.Point(121, 90)
        Me.Ref_Abonnement.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Ref_Abonnement.MaxLength = 32767
        Me.Ref_Abonnement.Multiline = False
        Me.Ref_Abonnement.Name = "Ref_Abonnement"
        Me.Ref_Abonnement.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ref_Abonnement.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ref_Abonnement.ReadOnly = True
        Me.Ref_Abonnement.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ref_Abonnement.SelectionStart = 0
        Me.Ref_Abonnement.Size = New System.Drawing.Size(145, 26)
        Me.Ref_Abonnement.TabIndex = 96
        Me.Ref_Abonnement.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ref_Abonnement.UseSystemPasswordChar = False
        '
        'Source_Abonnement
        '
        Me.Source_Abonnement.DataSource = Nothing
        Me.Source_Abonnement.DisplayMember = ""
        Me.Source_Abonnement.DroppedDown = False
        Me.Source_Abonnement.Location = New System.Drawing.Point(121, 56)
        Me.Source_Abonnement.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Source_Abonnement.Name = "Source_Abonnement"
        Me.Source_Abonnement.SelectedIndex = -1
        Me.Source_Abonnement.SelectedItem = Nothing
        Me.Source_Abonnement.SelectedValue = Nothing
        Me.Source_Abonnement.Size = New System.Drawing.Size(261, 30)
        Me.Source_Abonnement.TabIndex = 10001
        Me.Source_Abonnement.ValueMember = ""
        '
        'Lib_Ref_Abonnement
        '
        Me.Lib_Ref_Abonnement.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Ref_Abonnement.ContextMenuStrip = Nothing
        Me.Lib_Ref_Abonnement.Location = New System.Drawing.Point(274, 90)
        Me.Lib_Ref_Abonnement.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Lib_Ref_Abonnement.MaxLength = 100
        Me.Lib_Ref_Abonnement.Multiline = False
        Me.Lib_Ref_Abonnement.Name = "Lib_Ref_Abonnement"
        Me.Lib_Ref_Abonnement.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Ref_Abonnement.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Ref_Abonnement.ReadOnly = True
        Me.Lib_Ref_Abonnement.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Ref_Abonnement.SelectionStart = 0
        Me.Lib_Ref_Abonnement.Size = New System.Drawing.Size(758, 26)
        Me.Lib_Ref_Abonnement.TabIndex = 1
        Me.Lib_Ref_Abonnement.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Ref_Abonnement.UseSystemPasswordChar = False
        '
        'Actif_Check
        '
        Me.Actif_Check.AutoSize = True
        Me.Actif_Check.Checked = True
        Me.Actif_Check.Location = New System.Drawing.Point(1039, 26)
        Me.Actif_Check.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Actif_Check.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Actif_Check.MinimumSize = New System.Drawing.Size(125, 25)
        Me.Actif_Check.Name = "Actif_Check"
        Me.Actif_Check.Size = New System.Drawing.Size(125, 25)
        Me.Actif_Check.TabIndex = 216
        Me.Actif_Check.Text = "Actif"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.Abonnement_Grd)
        Me.TabPage5.Location = New System.Drawing.Point(4, 28)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage5.Size = New System.Drawing.Size(1120, 764)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Rapport d'Exécution"
        '
        'Abonnement_Grd
        '
        Me.Abonnement_Grd.AllowUserToDeleteRows = False
        Me.Abonnement_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Abonnement_Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Abonnement_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Abonnement_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Abonnement_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Abonnement_Grd.EnableHeadersVisualStyles = False
        Me.Abonnement_Grd.Location = New System.Drawing.Point(4, 4)
        Me.Abonnement_Grd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Abonnement_Grd.Name = "Abonnement_Grd"
        Me.Abonnement_Grd.ReadOnly = True
        Me.Abonnement_Grd.RowHeadersWidth = 51
        Me.Abonnement_Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Abonnement_Grd.Size = New System.Drawing.Size(1112, 756)
        Me.Abonnement_Grd.TabIndex = 213
        '
        'Param_Abonnement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1128, 796)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Param_Abonnement"
        Me.Tag = "ECR"
        Me.Text = "Gestion des abonnements"
        Me.Personnal_pnl.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Frequence, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.Abonnement_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents Lib_Abonnement_Text As ud_TextBox
    Friend WithEvents Cod_Abonnement_Text As ud_TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Actif_Check As ud_CheckBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Typ_Frequence_Combo As ud_ComboBox
    Friend WithEvents Frequence As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents Dat_Fin_Application_Text As ud_TextBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Dimanche_Check As ud_CheckBox
    Friend WithEvents Samedi_Check As ud_CheckBox
    Friend WithEvents Vendredi_Check As ud_CheckBox
    Friend WithEvents Jeudi_Check As ud_CheckBox
    Friend WithEvents Mercredi_Check As ud_CheckBox
    Friend WithEvents Mardi_Check As ud_CheckBox
    Friend WithEvents Lundi_Check As ud_CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Dat_Deb_Application_Text As ud_TextBox
    Friend WithEvents Abonnement_Grd As System.Windows.Forms.DataGridView
    Friend WithEvents Source_lb As System.Windows.Forms.Label
    Friend WithEvents Source_Abonnement As ud_ComboBox
    Friend WithEvents Lib_Ref_Abonnement As ud_TextBox
    Friend WithEvents Ref_Abonnement As ud_TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Lib_Typ_Pie_Abonnement As ud_TextBox
    Friend WithEvents Typ_Pie_Abonnement As ud_TextBox
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Friend WithEvents Heure_Abonnement_Mtxt As TimeTxt
    Friend WithEvents GroupBox2 As GroupBox
End Class
