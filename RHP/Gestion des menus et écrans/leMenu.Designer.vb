<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class leMenu
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(leMenu))
        Me.pnl_sideBarL = New System.Windows.Forms.Panel()
        Me.pnl_header = New System.Windows.Forms.Panel()
        Me.Header = New System.Windows.Forms.TableLayoutPanel()
        Me.pb_logo = New System.Windows.Forms.PictureBox()
        Me.Search_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Search_pb = New System.Windows.Forms.PictureBox()
        Me.Search_txt = New RHP.ud_TextBox()
        Me.Navigator_ud = New RHP.ud_pathBar()
        Me.System_pb = New System.Windows.Forms.PictureBox()
        Me.Home_pb = New System.Windows.Forms.PictureBox()
        Me.Personnel_pb = New System.Windows.Forms.PictureBox()
        Me.LH = New System.Windows.Forms.Label()
        Me.pnl_Footer = New System.Windows.Forms.Panel()
        Me.Usr_lbl = New System.Windows.Forms.Label()
        Me.Usr_pb = New System.Windows.Forms.PictureBox()
        Me.Db_lbl = New System.Windows.Forms.Label()
        Me.DB_pb = New System.Windows.Forms.PictureBox()
        Me.Srv_lbl = New System.Windows.Forms.Label()
        Me.Srv_pb = New System.Windows.Forms.PictureBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.pbModeAgent = New System.Windows.Forms.PictureBox()
        Me.modeAgent_lbl = New System.Windows.Forms.Label()
        Me.Déconnexion = New System.Windows.Forms.Label()
        Me.pblogout = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbchangePwd = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbParapheur = New System.Windows.Forms.PictureBox()
        Me.pnl_PersonnalContent = New RHP.ud_MenuContainer()
        Me.pnl_header.SuspendLayout()
        Me.Header.SuspendLayout()
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Search_pnl.SuspendLayout()
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.System_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Home_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Personnel_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Footer.SuspendLayout()
        CType(Me.Usr_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Srv_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.pbModeAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pblogout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbchangePwd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbParapheur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_sideBarL
        '
        Me.pnl_sideBarL.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.pnl_sideBarL.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_sideBarL.Location = New System.Drawing.Point(1236, 86)
        Me.pnl_sideBarL.Margin = New System.Windows.Forms.Padding(4)
        Me.pnl_sideBarL.Name = "pnl_sideBarL"
        Me.pnl_sideBarL.Size = New System.Drawing.Size(67, 654)
        Me.pnl_sideBarL.TabIndex = 1
        '
        'pnl_header
        '
        Me.pnl_header.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pnl_header.Controls.Add(Me.Header)
        Me.pnl_header.Controls.Add(Me.LH)
        Me.pnl_header.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_header.Location = New System.Drawing.Point(0, 0)
        Me.pnl_header.Margin = New System.Windows.Forms.Padding(4)
        Me.pnl_header.Name = "pnl_header"
        Me.pnl_header.Size = New System.Drawing.Size(1303, 86)
        Me.pnl_header.TabIndex = 0
        '
        'Header
        '
        Me.Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Header.ColumnCount = 6
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.Header.Controls.Add(Me.pb_logo, 0, 0)
        Me.Header.Controls.Add(Me.Search_pnl, 2, 0)
        Me.Header.Controls.Add(Me.Navigator_ud, 1, 0)
        Me.Header.Controls.Add(Me.System_pb, 5, 0)
        Me.Header.Controls.Add(Me.Home_pb, 4, 0)
        Me.Header.Controls.Add(Me.Personnel_pb, 3, 0)
        Me.Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header.Location = New System.Drawing.Point(0, 0)
        Me.Header.Margin = New System.Windows.Forms.Padding(4)
        Me.Header.Name = "Header"
        Me.Header.RowCount = 1
        Me.Header.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Header.Size = New System.Drawing.Size(1303, 82)
        Me.Header.TabIndex = 0
        '
        'pb_logo
        '
        Me.pb_logo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_logo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb_logo.Image = CType(resources.GetObject("pb_logo.Image"), System.Drawing.Image)
        Me.pb_logo.Location = New System.Drawing.Point(4, 4)
        Me.pb_logo.Margin = New System.Windows.Forms.Padding(4)
        Me.pb_logo.Name = "pb_logo"
        Me.pb_logo.Size = New System.Drawing.Size(75, 74)
        Me.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pb_logo.TabIndex = 0
        Me.pb_logo.TabStop = False
        '
        'Search_pnl
        '
        Me.Search_pnl.BackColor = System.Drawing.Color.White
        Me.Search_pnl.ColumnCount = 2
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.Search_pnl.Controls.Add(Me.Search_pb, 1, 0)
        Me.Search_pnl.Controls.Add(Me.Search_txt, 0, 0)
        Me.Search_pnl.Location = New System.Drawing.Point(774, 21)
        Me.Search_pnl.Margin = New System.Windows.Forms.Padding(4, 21, 4, 0)
        Me.Search_pnl.Name = "Search_pnl"
        Me.Search_pnl.RowCount = 1
        Me.Search_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.Size = New System.Drawing.Size(392, 43)
        Me.Search_pnl.TabIndex = 1
        '
        'Search_pb
        '
        Me.Search_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Search_pb.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.Search_pb.Location = New System.Drawing.Point(349, 4)
        Me.Search_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Search_pb.Name = "Search_pb"
        Me.Search_pb.Size = New System.Drawing.Size(39, 35)
        Me.Search_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Search_pb.TabIndex = 4
        Me.Search_pb.TabStop = False
        Me.Search_pb.Tag = "false"
        '
        'Search_txt
        '
        Me.Search_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Search_txt.ContextMenuStrip = Nothing
        Me.Search_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Search_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
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
        'Navigator_ud
        '
        Me.Navigator_ud.BackColor = System.Drawing.Color.White
        Me.Navigator_ud.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Navigator_ud.Location = New System.Drawing.Point(87, 21)
        Me.Navigator_ud.Margin = New System.Windows.Forms.Padding(4, 21, 4, 18)
        Me.Navigator_ud.Name = "Navigator_ud"
        Me.Navigator_ud.Size = New System.Drawing.Size(679, 43)
        Me.Navigator_ud.TabIndex = 3
        '
        'System_pb
        '
        Me.System_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.System_pb.Image = CType(resources.GetObject("System_pb.Image"), System.Drawing.Image)
        Me.System_pb.Location = New System.Drawing.Point(1254, 27)
        Me.System_pb.Margin = New System.Windows.Forms.Padding(4, 27, 4, 4)
        Me.System_pb.Name = "System_pb"
        Me.System_pb.Size = New System.Drawing.Size(45, 37)
        Me.System_pb.TabIndex = 0
        Me.System_pb.TabStop = False
        '
        'Home_pb
        '
        Me.Home_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Home_pb.Image = CType(resources.GetObject("Home_pb.Image"), System.Drawing.Image)
        Me.Home_pb.Location = New System.Drawing.Point(1214, 27)
        Me.Home_pb.Margin = New System.Windows.Forms.Padding(4, 27, 4, 4)
        Me.Home_pb.Name = "Home_pb"
        Me.Home_pb.Size = New System.Drawing.Size(32, 31)
        Me.Home_pb.TabIndex = 1
        Me.Home_pb.TabStop = False
        '
        'Personnel_pb
        '
        Me.Personnel_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Personnel_pb.Image = Global.RHP.My.Resources.Resources.btn_personnel_w
        Me.Personnel_pb.Location = New System.Drawing.Point(1174, 27)
        Me.Personnel_pb.Margin = New System.Windows.Forms.Padding(4, 27, 4, 4)
        Me.Personnel_pb.Name = "Personnel_pb"
        Me.Personnel_pb.Size = New System.Drawing.Size(32, 31)
        Me.Personnel_pb.TabIndex = 1
        Me.Personnel_pb.TabStop = False
        '
        'LH
        '
        Me.LH.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.LH.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LH.Location = New System.Drawing.Point(0, 82)
        Me.LH.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LH.Name = "LH"
        Me.LH.Size = New System.Drawing.Size(1303, 4)
        Me.LH.TabIndex = 5
        '
        'pnl_Footer
        '
        Me.pnl_Footer.Controls.Add(Me.Usr_lbl)
        Me.pnl_Footer.Controls.Add(Me.Usr_pb)
        Me.pnl_Footer.Controls.Add(Me.Db_lbl)
        Me.pnl_Footer.Controls.Add(Me.DB_pb)
        Me.pnl_Footer.Controls.Add(Me.Srv_lbl)
        Me.pnl_Footer.Controls.Add(Me.Srv_pb)
        Me.pnl_Footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Footer.Location = New System.Drawing.Point(0, 740)
        Me.pnl_Footer.Margin = New System.Windows.Forms.Padding(4)
        Me.pnl_Footer.Name = "pnl_Footer"
        Me.pnl_Footer.Size = New System.Drawing.Size(1303, 38)
        Me.pnl_Footer.TabIndex = 4
        '
        'Usr_lbl
        '
        Me.Usr_lbl.AutoSize = True
        Me.Usr_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Usr_lbl.Location = New System.Drawing.Point(148, 11)
        Me.Usr_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Usr_lbl.Name = "Usr_lbl"
        Me.Usr_lbl.Size = New System.Drawing.Size(0, 16)
        Me.Usr_lbl.TabIndex = 6
        '
        'Usr_pb
        '
        Me.Usr_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Usr_pb.Image = CType(resources.GetObject("Usr_pb.Image"), System.Drawing.Image)
        Me.Usr_pb.Location = New System.Drawing.Point(107, 4)
        Me.Usr_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Usr_pb.Name = "Usr_pb"
        Me.Usr_pb.Size = New System.Drawing.Size(33, 31)
        Me.Usr_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Usr_pb.TabIndex = 5
        Me.Usr_pb.TabStop = False
        '
        'Db_lbl
        '
        Me.Db_lbl.AutoSize = True
        Me.Db_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Db_lbl.Location = New System.Drawing.Point(99, 11)
        Me.Db_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Db_lbl.Name = "Db_lbl"
        Me.Db_lbl.Size = New System.Drawing.Size(0, 16)
        Me.Db_lbl.TabIndex = 4
        '
        'DB_pb
        '
        Me.DB_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DB_pb.Image = CType(resources.GetObject("DB_pb.Image"), System.Drawing.Image)
        Me.DB_pb.Location = New System.Drawing.Point(57, 4)
        Me.DB_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.DB_pb.Name = "DB_pb"
        Me.DB_pb.Size = New System.Drawing.Size(33, 31)
        Me.DB_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DB_pb.TabIndex = 3
        Me.DB_pb.TabStop = False
        '
        'Srv_lbl
        '
        Me.Srv_lbl.AutoSize = True
        Me.Srv_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Srv_lbl.Location = New System.Drawing.Point(49, 11)
        Me.Srv_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Srv_lbl.Name = "Srv_lbl"
        Me.Srv_lbl.Size = New System.Drawing.Size(0, 16)
        Me.Srv_lbl.TabIndex = 2
        '
        'Srv_pb
        '
        Me.Srv_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Srv_pb.Image = CType(resources.GetObject("Srv_pb.Image"), System.Drawing.Image)
        Me.Srv_pb.Location = New System.Drawing.Point(8, 4)
        Me.Srv_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Srv_pb.Name = "Srv_pb"
        Me.Srv_pb.Size = New System.Drawing.Size(33, 31)
        Me.Srv_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Srv_pb.TabIndex = 1
        Me.Srv_pb.TabStop = False
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(1232, 86)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(4)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 654)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.5!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.5!))
        Me.Personnal_pnl.Controls.Add(Me.pbModeAgent, 0, 2)
        Me.Personnal_pnl.Controls.Add(Me.modeAgent_lbl, 1, 2)
        Me.Personnal_pnl.Controls.Add(Me.Déconnexion, 1, 3)
        Me.Personnal_pnl.Controls.Add(Me.pblogout, 0, 3)
        Me.Personnal_pnl.Controls.Add(Me.Label2, 1, 1)
        Me.Personnal_pnl.Controls.Add(Me.pbchangePwd, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Label1, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.pbParapheur, 0, 1)
        Me.Personnal_pnl.Location = New System.Drawing.Point(942, 65)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 4
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(291, 182)
        Me.Personnal_pnl.TabIndex = 0
        Me.Personnal_pnl.Visible = False
        '
        'pbModeAgent
        '
        Me.pbModeAgent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbModeAgent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbModeAgent.Image = Global.RHP.My.Resources.Resources.btn_mode_agent_w
        Me.pbModeAgent.Location = New System.Drawing.Point(3, 93)
        Me.pbModeAgent.Name = "pbModeAgent"
        Me.pbModeAgent.Size = New System.Drawing.Size(47, 39)
        Me.pbModeAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbModeAgent.TabIndex = 6
        Me.pbModeAgent.TabStop = False
        '
        'modeAgent_lbl
        '
        Me.modeAgent_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.modeAgent_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.modeAgent_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modeAgent_lbl.ForeColor = System.Drawing.Color.White
        Me.modeAgent_lbl.Location = New System.Drawing.Point(56, 90)
        Me.modeAgent_lbl.Name = "modeAgent_lbl"
        Me.modeAgent_lbl.Size = New System.Drawing.Size(232, 45)
        Me.modeAgent_lbl.TabIndex = 5
        Me.modeAgent_lbl.Text = "Mode Agent"
        Me.modeAgent_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Déconnexion
        '
        Me.Déconnexion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Déconnexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Déconnexion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Déconnexion.ForeColor = System.Drawing.Color.White
        Me.Déconnexion.Location = New System.Drawing.Point(56, 135)
        Me.Déconnexion.Name = "Déconnexion"
        Me.Déconnexion.Size = New System.Drawing.Size(232, 47)
        Me.Déconnexion.TabIndex = 4
        Me.Déconnexion.Text = "Déconnexion"
        Me.Déconnexion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pblogout
        '
        Me.pblogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pblogout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pblogout.Image = CType(resources.GetObject("pblogout.Image"), System.Drawing.Image)
        Me.pblogout.Location = New System.Drawing.Point(3, 138)
        Me.pblogout.Name = "pblogout"
        Me.pblogout.Size = New System.Drawing.Size(47, 41)
        Me.pblogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pblogout.TabIndex = 3
        Me.pblogout.TabStop = False
        '
        'Label2
        '
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(56, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 45)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Parapheur"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbchangePwd
        '
        Me.pbchangePwd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbchangePwd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbchangePwd.Image = CType(resources.GetObject("pbchangePwd.Image"), System.Drawing.Image)
        Me.pbchangePwd.Location = New System.Drawing.Point(3, 3)
        Me.pbchangePwd.Name = "pbchangePwd"
        Me.pbchangePwd.Size = New System.Drawing.Size(47, 39)
        Me.pbchangePwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbchangePwd.TabIndex = 0
        Me.pbchangePwd.TabStop = False
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(56, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 45)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Changer le mot de passe"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbParapheur
        '
        Me.pbParapheur.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbParapheur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbParapheur.Image = CType(resources.GetObject("pbParapheur.Image"), System.Drawing.Image)
        Me.pbParapheur.Location = New System.Drawing.Point(3, 48)
        Me.pbParapheur.Name = "pbParapheur"
        Me.pbParapheur.Size = New System.Drawing.Size(47, 39)
        Me.pbParapheur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbParapheur.TabIndex = 0
        Me.pbParapheur.TabStop = False
        '
        'pnl_PersonnalContent
        '
        Me.pnl_PersonnalContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_PersonnalContent.Location = New System.Drawing.Point(0, 86)
        Me.pnl_PersonnalContent.Margin = New System.Windows.Forms.Padding(4)
        Me.pnl_PersonnalContent.Name = "pnl_PersonnalContent"
        Me.pnl_PersonnalContent.Size = New System.Drawing.Size(1236, 654)
        Me.pnl_PersonnalContent.TabIndex = 5
        '
        'leMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1303, 778)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.pnl_PersonnalContent)
        Me.Controls.Add(Me.pnl_sideBarL)
        Me.Controls.Add(Me.pnl_header)
        Me.Controls.Add(Me.pnl_Footer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "leMenu"
        Me.Text = "Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_header.ResumeLayout(False)
        Me.Header.ResumeLayout(False)
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Search_pnl.ResumeLayout(False)
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.System_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Home_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Personnel_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Footer.ResumeLayout(False)
        Me.pnl_Footer.PerformLayout()
        CType(Me.Usr_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Srv_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.pbModeAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pblogout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbchangePwd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbParapheur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnl_header As Panel
    Friend WithEvents pnl_sideBarL As Panel
    Friend WithEvents pb_logo As PictureBox
    Friend WithEvents Home_pb As PictureBox
    Friend WithEvents System_pb As PictureBox
    Friend WithEvents Navigator_ud As ud_pathBar
    Friend WithEvents Search_pb As PictureBox
    Friend WithEvents Search_txt As ud_TextBox
    Friend WithEvents pnl_Footer As Panel
    Friend WithEvents Usr_lbl As Label
    Friend WithEvents Usr_pb As PictureBox
    Friend WithEvents Db_lbl As Label
    Friend WithEvents DB_pb As PictureBox
    Friend WithEvents Srv_lbl As Label
    Friend WithEvents Srv_pb As PictureBox
    Friend WithEvents pnl_PersonnalContent As ud_MenuContainer
    Friend WithEvents LH As Label
    Friend WithEvents Header As TableLayoutPanel
    Friend WithEvents Search_pnl As TableLayoutPanel
    Friend WithEvents Personnel_pb As PictureBox
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents pbchangePwd As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Déconnexion As Label
    Friend WithEvents pblogout As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pbParapheur As PictureBox
    Friend WithEvents modeAgent_lbl As Label
    Friend WithEvents pbModeAgent As PictureBox
End Class
