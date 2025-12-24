<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RH_Preparation_Paie_Saisie
    Inherits Ecran

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.EntPnl = New System.Windows.Forms.Panel()
        Me.refresh_btn = New RHP.ud_button()
        Me.Search_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Search_pb = New System.Windows.Forms.PictureBox()
        Me.Search_txt = New RHP.ud_TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.EV_chk = New RHP.ud_RadioBox()
        Me.EB_chk = New RHP.ud_RadioBox()
        Me.btn_ChargerEB = New RHP.ud_button()
        Me.Tout_Chk = New RHP.ud_RadioBox()
        Me.ModierPlan_btn = New RHP.ud_button()
        Me.Cod_Preparation_Text = New RHP.ud_TextBox()
        Me.Cod_Preparation_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Plan_Paie_ = New System.Windows.Forms.LinkLabel()
        Me.Dat_Deb_Periode_Text = New RHP.ud_TextBox()
        Me.Cloture_Check = New RHP.ud_CheckBox()
        Me.Dat_Deb_Periode_ = New System.Windows.Forms.LinkLabel()
        Me.Dat_Fin_Periode_Text = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.elementPaie_Pln = New System.Windows.Forms.Panel()
        Me.PrePaie_Grd = New RHP.ud_Grd()
        Me.Total_Pnl = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TotalRubrique_txt = New RHP.ud_TextBox()
        Me.parentPnl = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pnl_container = New System.Windows.Forms.Panel()
        Me.myTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.EntPnl.SuspendLayout()
        Me.Search_pnl.SuspendLayout()
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PrePaie_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Total_Pnl.SuspendLayout()
        Me.parentPnl.SuspendLayout()
        Me.pnl_container.SuspendLayout()
        Me.SuspendLayout()
        '
        'EntPnl
        '
        Me.EntPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.EntPnl.Controls.Add(Me.refresh_btn)
        Me.EntPnl.Controls.Add(Me.Search_pnl)
        Me.EntPnl.Controls.Add(Me.TableLayoutPanel2)
        Me.EntPnl.Controls.Add(Me.ModierPlan_btn)
        Me.EntPnl.Controls.Add(Me.Cod_Preparation_Text)
        Me.EntPnl.Controls.Add(Me.Cod_Preparation_)
        Me.EntPnl.Controls.Add(Me.Lib_Plan_Paie_Text)
        Me.EntPnl.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.EntPnl.Controls.Add(Me.Plan_Paie_)
        Me.EntPnl.Controls.Add(Me.Dat_Deb_Periode_Text)
        Me.EntPnl.Controls.Add(Me.Cloture_Check)
        Me.EntPnl.Controls.Add(Me.Dat_Deb_Periode_)
        Me.EntPnl.Controls.Add(Me.Dat_Fin_Periode_Text)
        Me.EntPnl.Controls.Add(Me.LinkLabel1)
        Me.EntPnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.EntPnl.Location = New System.Drawing.Point(0, 0)
        Me.EntPnl.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.EntPnl.Name = "EntPnl"
        Me.EntPnl.Size = New System.Drawing.Size(1279, 119)
        Me.EntPnl.TabIndex = 210
        '
        'refresh_btn
        '
        Me.refresh_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.refresh_btn.bgColor = System.Drawing.Color.White
        Me.refresh_btn.Border = RHP.ud_button.BorderStyle.None
        Me.refresh_btn.BorderColor = System.Drawing.Color.Empty
        Me.refresh_btn.BorderSize = 0
        Me.refresh_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.refresh_btn.Image = Global.RHP.My.Resources.Resources.btn_request
        Me.refresh_btn.isDefault = False
        Me.refresh_btn.Location = New System.Drawing.Point(1041, 16)
        Me.refresh_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.refresh_btn.MinimumSize = New System.Drawing.Size(31, 31)
        Me.refresh_btn.Name = "refresh_btn"
        Me.refresh_btn.Size = New System.Drawing.Size(36, 31)
        Me.refresh_btn.TabIndex = 237
        Me.refresh_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.refresh_btn.ToolTip = "Actualiser"
        '
        'Search_pnl
        '
        Me.Search_pnl.BackColor = System.Drawing.Color.White
        Me.Search_pnl.ColumnCount = 2
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.Search_pnl.Controls.Add(Me.Search_pb, 1, 0)
        Me.Search_pnl.Controls.Add(Me.Search_txt, 0, 0)
        Me.Search_pnl.Location = New System.Drawing.Point(781, 62)
        Me.Search_pnl.Margin = New System.Windows.Forms.Padding(4, 21, 4, 0)
        Me.Search_pnl.Name = "Search_pnl"
        Me.Search_pnl.RowCount = 1
        Me.Search_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.Size = New System.Drawing.Size(392, 43)
        Me.Search_pnl.TabIndex = 236
        '
        'Search_pb
        '
        Me.Search_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Search_pb.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.Search_pb.Location = New System.Drawing.Point(353, 7)
        Me.Search_pb.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Search_pb.Name = "Search_pb"
        Me.Search_pb.Size = New System.Drawing.Size(31, 28)
        Me.Search_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Search_pb.TabIndex = 4
        Me.Search_pb.TabStop = False
        Me.Search_pb.Tag = "false"
        '
        'Search_txt
        '
        Me.Search_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Search_txt.ContextMenuStrip = Nothing
        Me.Search_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Search_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Search_txt.Location = New System.Drawing.Point(8, 7)
        Me.Search_txt.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Search_txt.MaxLength = 32767
        Me.Search_txt.Multiline = False
        Me.Search_txt.Name = "Search_txt"
        Me.Search_txt.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Search_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Search_txt.ReadOnly = False
        Me.Search_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Search_txt.SelectionStart = 0
        Me.Search_txt.Size = New System.Drawing.Size(329, 29)
        Me.Search_txt.TabIndex = 2
        Me.Search_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Search_txt.UseSystemPasswordChar = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.EV_chk, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.EB_chk, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_ChargerEB, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Tout_Chk, 2, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(13, 60)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(701, 52)
        Me.TableLayoutPanel2.TabIndex = 235
        '
        'EV_chk
        '
        Me.EV_chk.AutoSize = True
        Me.EV_chk.Checked = True
        Me.EV_chk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EV_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.EV_chk.Location = New System.Drawing.Point(4, 5)
        Me.EV_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.EV_chk.MaximumSize = New System.Drawing.Size(0, 38)
        Me.EV_chk.MinimumSize = New System.Drawing.Size(0, 38)
        Me.EV_chk.Name = "EV_chk"
        Me.EV_chk.Size = New System.Drawing.Size(232, 38)
        Me.EV_chk.TabIndex = 222
        Me.EV_chk.Text = "Eléments variables"
        '
        'EB_chk
        '
        Me.EB_chk.AutoSize = True
        Me.EB_chk.Checked = False
        Me.EB_chk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EB_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.EB_chk.Location = New System.Drawing.Point(244, 5)
        Me.EB_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.EB_chk.MaximumSize = New System.Drawing.Size(0, 38)
        Me.EB_chk.MinimumSize = New System.Drawing.Size(0, 38)
        Me.EB_chk.Name = "EB_chk"
        Me.EB_chk.Size = New System.Drawing.Size(203, 38)
        Me.EB_chk.TabIndex = 223
        Me.EB_chk.Text = "Eléments de base"
        '
        'btn_ChargerEB
        '
        Me.btn_ChargerEB.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btn_ChargerEB.bgColor = System.Drawing.Color.White
        Me.btn_ChargerEB.Border = RHP.ud_button.BorderStyle.None
        Me.btn_ChargerEB.BorderColor = System.Drawing.Color.Empty
        Me.btn_ChargerEB.BorderSize = 0
        Me.btn_ChargerEB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ChargerEB.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_ChargerEB.Image = Global.RHP.My.Resources.Resources.btn_execute
        Me.btn_ChargerEB.isDefault = False
        Me.btn_ChargerEB.Location = New System.Drawing.Point(639, 5)
        Me.btn_ChargerEB.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_ChargerEB.MinimumSize = New System.Drawing.Size(27, 25)
        Me.btn_ChargerEB.Name = "btn_ChargerEB"
        Me.btn_ChargerEB.Size = New System.Drawing.Size(52, 42)
        Me.btn_ChargerEB.TabIndex = 223
        Me.btn_ChargerEB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_ChargerEB.ToolTip = "Charger les élements de base"
        '
        'Tout_Chk
        '
        Me.Tout_Chk.AutoSize = True
        Me.Tout_Chk.Checked = False
        Me.Tout_Chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Tout_Chk.Location = New System.Drawing.Point(455, 5)
        Me.Tout_Chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Tout_Chk.MaximumSize = New System.Drawing.Size(0, 38)
        Me.Tout_Chk.MinimumSize = New System.Drawing.Size(0, 38)
        Me.Tout_Chk.Name = "Tout_Chk"
        Me.Tout_Chk.Size = New System.Drawing.Size(142, 38)
        Me.Tout_Chk.TabIndex = 224
        Me.Tout_Chk.Text = "Tout"
        '
        'ModierPlan_btn
        '
        Me.ModierPlan_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ModierPlan_btn.bgColor = System.Drawing.Color.White
        Me.ModierPlan_btn.Border = RHP.ud_button.BorderStyle.None
        Me.ModierPlan_btn.BorderColor = System.Drawing.Color.Empty
        Me.ModierPlan_btn.BorderSize = 0
        Me.ModierPlan_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ModierPlan_btn.Image = Global.RHP.My.Resources.Resources.btn_edit_doc
        Me.ModierPlan_btn.isDefault = False
        Me.ModierPlan_btn.Location = New System.Drawing.Point(719, 18)
        Me.ModierPlan_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ModierPlan_btn.MinimumSize = New System.Drawing.Size(31, 31)
        Me.ModierPlan_btn.Name = "ModierPlan_btn"
        Me.ModierPlan_btn.Size = New System.Drawing.Size(36, 31)
        Me.ModierPlan_btn.TabIndex = 234
        Me.ModierPlan_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ModierPlan_btn.ToolTip = "Editer le plan de paie"
        '
        'Cod_Preparation_Text
        '
        Me.Cod_Preparation_Text.AccessibleDescription = "A"
        Me.Cod_Preparation_Text.AutoSize = True
        Me.Cod_Preparation_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Preparation_Text.ContextMenuStrip = Nothing
        Me.Cod_Preparation_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Preparation_Text.Location = New System.Drawing.Point(111, 21)
        Me.Cod_Preparation_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Preparation_Text.MaxLength = 32767
        Me.Cod_Preparation_Text.Multiline = False
        Me.Cod_Preparation_Text.Name = "Cod_Preparation_Text"
        Me.Cod_Preparation_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Preparation_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Preparation_Text.ReadOnly = True
        Me.Cod_Preparation_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Preparation_Text.SelectionStart = 0
        Me.Cod_Preparation_Text.Size = New System.Drawing.Size(133, 26)
        Me.Cod_Preparation_Text.TabIndex = 207
        Me.Cod_Preparation_Text.TabStop = False
        Me.Cod_Preparation_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Preparation_Text.UseSystemPasswordChar = False
        '
        'Cod_Preparation_
        '
        Me.Cod_Preparation_.AutoSize = True
        Me.Cod_Preparation_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Preparation_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Preparation_.Location = New System.Drawing.Point(9, 23)
        Me.Cod_Preparation_.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Cod_Preparation_.Name = "Cod_Preparation_"
        Me.Cod_Preparation_.Size = New System.Drawing.Size(90, 19)
        Me.Cod_Preparation_.TabIndex = 206
        Me.Cod_Preparation_.TabStop = True
        Me.Cod_Preparation_.Tag = ""
        Me.Cod_Preparation_.Text = "Préparation"
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.AutoSize = True
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Lib_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(433, 21)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Lib_Plan_Paie_Text.MaxLength = 50
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = True
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(281, 26)
        Me.Lib_Plan_Paie_Text.TabIndex = 219
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.AutoSize = True
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(317, 21)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Plan_Paie_Text.MaxLength = 50
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(111, 26)
        Me.Cod_Plan_Paie_Text.TabIndex = 220
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Plan_Paie_
        '
        Me.Plan_Paie_.AutoSize = True
        Me.Plan_Paie_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Plan_Paie_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Plan_Paie_.Location = New System.Drawing.Point(268, 23)
        Me.Plan_Paie_.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Plan_Paie_.Name = "Plan_Paie_"
        Me.Plan_Paie_.Size = New System.Drawing.Size(39, 19)
        Me.Plan_Paie_.TabIndex = 218
        Me.Plan_Paie_.TabStop = True
        Me.Plan_Paie_.Tag = "NC"
        Me.Plan_Paie_.Text = "Plan"
        '
        'Dat_Deb_Periode_Text
        '
        Me.Dat_Deb_Periode_Text.AutoSize = True
        Me.Dat_Deb_Periode_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Deb_Periode_Text.ContextMenuStrip = Nothing
        Me.Dat_Deb_Periode_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Deb_Periode_Text.Location = New System.Drawing.Point(799, 18)
        Me.Dat_Deb_Periode_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Dat_Deb_Periode_Text.MaxLength = 32767
        Me.Dat_Deb_Periode_Text.Multiline = False
        Me.Dat_Deb_Periode_Text.Name = "Dat_Deb_Periode_Text"
        Me.Dat_Deb_Periode_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Deb_Periode_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Deb_Periode_Text.ReadOnly = True
        Me.Dat_Deb_Periode_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Deb_Periode_Text.SelectionStart = 0
        Me.Dat_Deb_Periode_Text.Size = New System.Drawing.Size(95, 26)
        Me.Dat_Deb_Periode_Text.TabIndex = 225
        Me.Dat_Deb_Periode_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Deb_Periode_Text.UseSystemPasswordChar = False
        '
        'Cloture_Check
        '
        Me.Cloture_Check.AutoSize = True
        Me.Cloture_Check.Checked = False
        Me.Cloture_Check.Enabled = False
        Me.Cloture_Check.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cloture_Check.Location = New System.Drawing.Point(1109, 15)
        Me.Cloture_Check.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cloture_Check.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Cloture_Check.MinimumSize = New System.Drawing.Size(156, 31)
        Me.Cloture_Check.Name = "Cloture_Check"
        Me.Cloture_Check.Size = New System.Drawing.Size(156, 31)
        Me.Cloture_Check.TabIndex = 228
        Me.Cloture_Check.Text = "Clôturée"
        '
        'Dat_Deb_Periode_
        '
        Me.Dat_Deb_Periode_.AutoSize = True
        Me.Dat_Deb_Periode_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Deb_Periode_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Deb_Periode_.Location = New System.Drawing.Point(765, 22)
        Me.Dat_Deb_Periode_.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Dat_Deb_Periode_.Name = "Dat_Deb_Periode_"
        Me.Dat_Deb_Periode_.Size = New System.Drawing.Size(28, 19)
        Me.Dat_Deb_Periode_.TabIndex = 224
        Me.Dat_Deb_Periode_.TabStop = True
        Me.Dat_Deb_Periode_.Tag = "NC"
        Me.Dat_Deb_Periode_.Text = "Du"
        '
        'Dat_Fin_Periode_Text
        '
        Me.Dat_Fin_Periode_Text.AutoSize = True
        Me.Dat_Fin_Periode_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Fin_Periode_Text.ContextMenuStrip = Nothing
        Me.Dat_Fin_Periode_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Fin_Periode_Text.Location = New System.Drawing.Point(937, 18)
        Me.Dat_Fin_Periode_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Dat_Fin_Periode_Text.MaxLength = 50
        Me.Dat_Fin_Periode_Text.Multiline = False
        Me.Dat_Fin_Periode_Text.Name = "Dat_Fin_Periode_Text"
        Me.Dat_Fin_Periode_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Fin_Periode_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Fin_Periode_Text.ReadOnly = True
        Me.Dat_Fin_Periode_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Fin_Periode_Text.SelectionStart = 0
        Me.Dat_Fin_Periode_Text.Size = New System.Drawing.Size(95, 26)
        Me.Dat_Fin_Periode_Text.TabIndex = 232
        Me.Dat_Fin_Periode_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Fin_Periode_Text.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(905, 22)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(27, 19)
        Me.LinkLabel1.TabIndex = 233
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "NC"
        Me.LinkLabel1.Text = "Au"
        '
        'elementPaie_Pln
        '
        Me.elementPaie_Pln.AutoScroll = True
        Me.elementPaie_Pln.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.elementPaie_Pln.Dock = System.Windows.Forms.DockStyle.Fill
        Me.elementPaie_Pln.Location = New System.Drawing.Point(3, 2)
        Me.elementPaie_Pln.Margin = New System.Windows.Forms.Padding(4)
        Me.elementPaie_Pln.Name = "elementPaie_Pln"
        Me.elementPaie_Pln.Size = New System.Drawing.Size(1273, 167)
        Me.elementPaie_Pln.TabIndex = 211
        '
        'PrePaie_Grd
        '
        Me.PrePaie_Grd.AfficherLesEntetesLignes = True
        Me.PrePaie_Grd.AllowUserToAddRows = False
        Me.PrePaie_Grd.AllowUserToDeleteRows = False
        Me.PrePaie_Grd.AlternerLesLignes = False
        Me.PrePaie_Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.PrePaie_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PrePaie_Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PrePaie_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrePaie_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.PrePaie_Grd.ColumnHeadersHeight = 30
        Me.PrePaie_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PrePaie_Grd.DefaultCellStyle = DataGridViewCellStyle2
        Me.PrePaie_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrePaie_Grd.EnableHeadersVisualStyles = False
        Me.PrePaie_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.PrePaie_Grd.Location = New System.Drawing.Point(0, 294)
        Me.PrePaie_Grd.Margin = New System.Windows.Forms.Padding(4)
        Me.PrePaie_Grd.Name = "PrePaie_Grd"
        Me.PrePaie_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.PrePaie_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.PrePaie_Grd.RowHeadersWidth = 51
        Me.PrePaie_Grd.Size = New System.Drawing.Size(1279, 398)
        Me.PrePaie_Grd.TabIndex = 212
        '
        'Total_Pnl
        '
        Me.Total_Pnl.Controls.Add(Me.Label1)
        Me.Total_Pnl.Controls.Add(Me.TotalRubrique_txt)
        Me.Total_Pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Total_Pnl.Location = New System.Drawing.Point(0, 692)
        Me.Total_Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Total_Pnl.Name = "Total_Pnl"
        Me.Total_Pnl.Size = New System.Drawing.Size(1279, 39)
        Me.Total_Pnl.TabIndex = 213
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(67, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 16)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Total de la rubrique"
        '
        'TotalRubrique_txt
        '
        Me.TotalRubrique_txt.AutoSize = True
        Me.TotalRubrique_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TotalRubrique_txt.ContextMenuStrip = Nothing
        Me.TotalRubrique_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.TotalRubrique_txt.Location = New System.Drawing.Point(201, 6)
        Me.TotalRubrique_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TotalRubrique_txt.MaxLength = 50
        Me.TotalRubrique_txt.Multiline = False
        Me.TotalRubrique_txt.Name = "TotalRubrique_txt"
        Me.TotalRubrique_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.TotalRubrique_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.TotalRubrique_txt.ReadOnly = True
        Me.TotalRubrique_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TotalRubrique_txt.SelectionStart = 0
        Me.TotalRubrique_txt.Size = New System.Drawing.Size(264, 26)
        Me.TotalRubrique_txt.TabIndex = 236
        Me.TotalRubrique_txt.Text = "0,00"
        Me.TotalRubrique_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TotalRubrique_txt.UseSystemPasswordChar = False
        '
        'parentPnl
        '
        Me.parentPnl.Controls.Add(Me.PrePaie_Grd)
        Me.parentPnl.Controls.Add(Me.Total_Pnl)
        Me.parentPnl.Controls.Add(Me.Splitter1)
        Me.parentPnl.Controls.Add(Me.pnl_container)
        Me.parentPnl.Controls.Add(Me.EntPnl)
        Me.parentPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.parentPnl.Location = New System.Drawing.Point(0, 0)
        Me.parentPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.parentPnl.Name = "parentPnl"
        Me.parentPnl.Size = New System.Drawing.Size(1279, 731)
        Me.parentPnl.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 290)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(4)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1279, 4)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'pnl_container
        '
        Me.pnl_container.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_container.Controls.Add(Me.elementPaie_Pln)
        Me.pnl_container.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_container.Location = New System.Drawing.Point(0, 119)
        Me.pnl_container.Margin = New System.Windows.Forms.Padding(4)
        Me.pnl_container.Name = "pnl_container"
        Me.pnl_container.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnl_container.Size = New System.Drawing.Size(1279, 171)
        Me.pnl_container.TabIndex = 0
        '
        'myTimer
        '
        Me.myTimer.Enabled = True
        '
        'RH_Preparation_Paie_Saisie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1279, 731)
        Me.Controls.Add(Me.parentPnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RH_Preparation_Paie_Saisie"
        Me.Tag = "ECR"
        Me.Text = "Préparation de la paie (Mode classique)"
        Me.EntPnl.ResumeLayout(False)
        Me.EntPnl.PerformLayout()
        Me.Search_pnl.ResumeLayout(False)
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.PrePaie_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Total_Pnl.ResumeLayout(False)
        Me.Total_Pnl.PerformLayout()
        Me.parentPnl.ResumeLayout(False)
        Me.pnl_container.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents EntPnl As Panel
    Friend WithEvents ModierPlan_btn As ud_button
    Friend WithEvents Cod_Preparation_Text As ud_TextBox
    Friend WithEvents Cod_Preparation_ As LinkLabel
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Plan_Paie_ As LinkLabel
    Friend WithEvents Dat_Deb_Periode_Text As ud_TextBox
    Friend WithEvents Cloture_Check As ud_CheckBox
    Friend WithEvents Dat_Deb_Periode_ As LinkLabel
    Friend WithEvents Dat_Fin_Periode_Text As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents EV_chk As ud_RadioBox
    Friend WithEvents EB_chk As ud_RadioBox
    Friend WithEvents elementPaie_Pln As Panel
    Friend WithEvents PrePaie_Grd As ud_Grd
    Friend WithEvents Total_Pnl As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TotalRubrique_txt As ud_TextBox
    Friend WithEvents parentPnl As Panel
    Friend WithEvents Search_pnl As TableLayoutPanel
    Friend WithEvents Search_pb As PictureBox
    Friend WithEvents Search_txt As ud_TextBox
    Friend WithEvents pnl_container As Panel
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents myTimer As Timer
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btn_ChargerEB As ud_button
    Friend WithEvents Tout_Chk As ud_RadioBox
    Friend WithEvents refresh_btn As ud_button
End Class
