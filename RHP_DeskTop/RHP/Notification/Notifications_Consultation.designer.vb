<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Notifications_Consultation
    Inherits Ecran

    'Form rEmplace la méthode dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le concepteur Windows Form
    'Elle peut être modifiée à l'aide du concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SEL_CRT_GROUP = New System.Windows.Forms.GroupBox()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.All_chk = New ud_RadioBox()
        Me.NotNotified_chk = New ud_RadioBox()
        Me.Notified_chk = New ud_RadioBox()
        Me.Au_Notif = New System.Windows.Forms.LinkLabel()
        Me.Dat_Notif_Fin = New RHP.ud_TextBox()
        Me.Du_Notif = New System.Windows.Forms.LinkLabel()
        Me.Dat_Notif_Deb = New RHP.ud_TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Event_Fin_txt = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Event_Deb_txt = New RHP.ud_TextBox()
        Me.Table_Index_txt = New RHP.ud_TextBox()
        Me.LinkLabel15 = New System.Windows.Forms.LinkLabel()
        Me.Event_cbo = New ud_ComboBox()
        Me.Val_Index_txt = New RHP.ud_TextBox()
        Me.Table_Ref_txt = New RHP.ud_TextBox()
        Me.code_Client_Facture = New System.Windows.Forms.LinkLabel()
        Me.Grille = New RHP.ud_Grd()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New ud_button
        Me.ButtonX2 = New ud_button
        Me.SEL_CRT_GROUP.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SEL_CRT_GROUP
        '
        Me.SEL_CRT_GROUP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel6)
        Me.SEL_CRT_GROUP.Controls.Add(Me.GroupBox2)
        Me.SEL_CRT_GROUP.Controls.Add(Me.GroupBox1)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Table_Index_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel15)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Event_cbo)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Val_Index_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Table_Ref_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.code_Client_Facture)
        Me.SEL_CRT_GROUP.Dock = System.Windows.Forms.DockStyle.Top
        Me.SEL_CRT_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.SEL_CRT_GROUP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SEL_CRT_GROUP.Name = "SEL_CRT_GROUP"
        Me.SEL_CRT_GROUP.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SEL_CRT_GROUP.Size = New System.Drawing.Size(1629, 232)
        Me.SEL_CRT_GROUP.TabIndex = 0
        Me.SEL_CRT_GROUP.TabStop = False
        Me.SEL_CRT_GROUP.Tag = "Critères de sélection"
        Me.SEL_CRT_GROUP.Text = "Critères de sélection"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel6.Location = New System.Drawing.Point(32, 54)
        Me.LinkLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(95, 19)
        Me.LinkLabel6.TabIndex = 206
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Tag = "SC"
        Me.LinkLabel6.Text = "Valeur index"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.All_chk)
        Me.GroupBox2.Controls.Add(Me.NotNotified_chk)
        Me.GroupBox2.Controls.Add(Me.Notified_chk)
        Me.GroupBox2.Controls.Add(Me.Au_Notif)
        Me.GroupBox2.Controls.Add(Me.Dat_Notif_Fin)
        Me.GroupBox2.Controls.Add(Me.Du_Notif)
        Me.GroupBox2.Controls.Add(Me.Dat_Notif_Deb)
        Me.GroupBox2.Location = New System.Drawing.Point(235, 120)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(396, 105)
        Me.GroupBox2.TabIndex = 205
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Date notification"
        '
        'All_chk
        '
        Me.All_chk.AutoSize = True
        Me.All_chk.Checked = True
        Me.All_chk.Location = New System.Drawing.Point(8, 76)
        Me.All_chk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.All_chk.Name = "All_chk"
        Me.All_chk.Size = New System.Drawing.Size(58, 23)
        Me.All_chk.TabIndex = 203
        Me.All_chk.TabStop = True
        Me.All_chk.Text = "Tout"
        '
        'NotNotified_chk
        '
        Me.NotNotified_chk.AutoSize = True
        Me.NotNotified_chk.Location = New System.Drawing.Point(8, 49)
        Me.NotNotified_chk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NotNotified_chk.Name = "NotNotified_chk"
        Me.NotNotified_chk.Size = New System.Drawing.Size(104, 23)
        Me.NotNotified_chk.TabIndex = 203
        Me.NotNotified_chk.Text = "Non notifié"
        '
        'Notified_chk
        '
        Me.Notified_chk.AutoSize = True
        Me.Notified_chk.Location = New System.Drawing.Point(8, 22)
        Me.Notified_chk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Notified_chk.Name = "Notified_chk"
        Me.Notified_chk.Size = New System.Drawing.Size(73, 23)
        Me.Notified_chk.TabIndex = 203
        Me.Notified_chk.Text = "Notifié"
        '
        'Au_Notif
        '
        Me.Au_Notif.AutoSize = True
        Me.Au_Notif.LinkColor = System.Drawing.Color.Black
        Me.Au_Notif.Location = New System.Drawing.Point(188, 64)
        Me.Au_Notif.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Au_Notif.Name = "Au_Notif"
        Me.Au_Notif.Size = New System.Drawing.Size(27, 19)
        Me.Au_Notif.TabIndex = 201
        Me.Au_Notif.TabStop = True
        Me.Au_Notif.Tag = "Date début"
        Me.Au_Notif.Text = "Au"
        Me.Au_Notif.Visible = False
        '
        'Dat_Notif_Fin
        '
        Me.Dat_Notif_Fin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Notif_Fin.ContextMenuStrip = Nothing
        Me.Dat_Notif_Fin.Enabled = False
        Me.Dat_Notif_Fin.Location = New System.Drawing.Point(236, 60)
        Me.Dat_Notif_Fin.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Dat_Notif_Fin.MaxLength = 32767
        Me.Dat_Notif_Fin.Multiline = False
        Me.Dat_Notif_Fin.Name = "Dat_Notif_Fin"
        Me.Dat_Notif_Fin.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Notif_Fin.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Notif_Fin.ReadOnly = False
        Me.Dat_Notif_Fin.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Notif_Fin.SelectionStart = 0
        Me.Dat_Notif_Fin.Size = New System.Drawing.Size(131, 26)
        Me.Dat_Notif_Fin.TabIndex = 202
        Me.Dat_Notif_Fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Notif_Fin.UseSystemPasswordChar = False
        Me.Dat_Notif_Fin.Visible = False
        '
        'Du_Notif
        '
        Me.Du_Notif.AutoSize = True
        Me.Du_Notif.LinkColor = System.Drawing.Color.Black
        Me.Du_Notif.Location = New System.Drawing.Point(188, 34)
        Me.Du_Notif.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Du_Notif.Name = "Du_Notif"
        Me.Du_Notif.Size = New System.Drawing.Size(28, 19)
        Me.Du_Notif.TabIndex = 4
        Me.Du_Notif.TabStop = True
        Me.Du_Notif.Tag = "Date début"
        Me.Du_Notif.Text = "Du"
        Me.Du_Notif.Visible = False
        '
        'Dat_Notif_Deb
        '
        Me.Dat_Notif_Deb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Notif_Deb.ContextMenuStrip = Nothing
        Me.Dat_Notif_Deb.Enabled = False
        Me.Dat_Notif_Deb.Location = New System.Drawing.Point(236, 30)
        Me.Dat_Notif_Deb.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Dat_Notif_Deb.MaxLength = 32767
        Me.Dat_Notif_Deb.Multiline = False
        Me.Dat_Notif_Deb.Name = "Dat_Notif_Deb"
        Me.Dat_Notif_Deb.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Notif_Deb.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Notif_Deb.ReadOnly = False
        Me.Dat_Notif_Deb.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Notif_Deb.SelectionStart = 0
        Me.Dat_Notif_Deb.Size = New System.Drawing.Size(131, 26)
        Me.Dat_Notif_Deb.TabIndex = 200
        Me.Dat_Notif_Deb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Notif_Deb.UseSystemPasswordChar = False
        Me.Dat_Notif_Deb.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.Dat_Event_Fin_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel4)
        Me.GroupBox1.Controls.Add(Me.Dat_Event_Deb_txt)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 120)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(200, 105)
        Me.GroupBox1.TabIndex = 205
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date événement"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(8, 62)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(27, 19)
        Me.LinkLabel1.TabIndex = 201
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "Date début"
        Me.LinkLabel1.Text = "Au"
        '
        'Dat_Event_Fin_txt
        '
        Me.Dat_Event_Fin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Event_Fin_txt.ContextMenuStrip = Nothing
        Me.Dat_Event_Fin_txt.Enabled = False
        Me.Dat_Event_Fin_txt.Location = New System.Drawing.Point(56, 59)
        Me.Dat_Event_Fin_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Dat_Event_Fin_txt.MaxLength = 32767
        Me.Dat_Event_Fin_txt.Multiline = False
        Me.Dat_Event_Fin_txt.Name = "Dat_Event_Fin_txt"
        Me.Dat_Event_Fin_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Event_Fin_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Event_Fin_txt.ReadOnly = False
        Me.Dat_Event_Fin_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Event_Fin_txt.SelectionStart = 0
        Me.Dat_Event_Fin_txt.Size = New System.Drawing.Size(131, 26)
        Me.Dat_Event_Fin_txt.TabIndex = 202
        Me.Dat_Event_Fin_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Event_Fin_txt.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4.Location = New System.Drawing.Point(8, 32)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(28, 19)
        Me.LinkLabel4.TabIndex = 4
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "Date début"
        Me.LinkLabel4.Text = "Du"
        '
        'Dat_Event_Deb_txt
        '
        Me.Dat_Event_Deb_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Event_Deb_txt.ContextMenuStrip = Nothing
        Me.Dat_Event_Deb_txt.Enabled = False
        Me.Dat_Event_Deb_txt.Location = New System.Drawing.Point(56, 29)
        Me.Dat_Event_Deb_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Dat_Event_Deb_txt.MaxLength = 32767
        Me.Dat_Event_Deb_txt.Multiline = False
        Me.Dat_Event_Deb_txt.Name = "Dat_Event_Deb_txt"
        Me.Dat_Event_Deb_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Event_Deb_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Event_Deb_txt.ReadOnly = False
        Me.Dat_Event_Deb_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Event_Deb_txt.SelectionStart = 0
        Me.Dat_Event_Deb_txt.Size = New System.Drawing.Size(131, 26)
        Me.Dat_Event_Deb_txt.TabIndex = 200
        Me.Dat_Event_Deb_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Event_Deb_txt.UseSystemPasswordChar = False
        '
        'Table_Index_txt
        '
        Me.Table_Index_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Table_Index_txt.ContextMenuStrip = Nothing
        Me.Table_Index_txt.Enabled = False
        Me.Table_Index_txt.Location = New System.Drawing.Point(320, 20)
        Me.Table_Index_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Table_Index_txt.MaxLength = 32767
        Me.Table_Index_txt.Multiline = False
        Me.Table_Index_txt.Name = "Table_Index_txt"
        Me.Table_Index_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Table_Index_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Table_Index_txt.ReadOnly = False
        Me.Table_Index_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Table_Index_txt.SelectionStart = 0
        Me.Table_Index_txt.Size = New System.Drawing.Size(282, 26)
        Me.Table_Index_txt.TabIndex = 203
        Me.Table_Index_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Table_Index_txt.UseSystemPasswordChar = False
        '
        'LinkLabel15
        '
        Me.LinkLabel15.AutoSize = True
        Me.LinkLabel15.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel15.Location = New System.Drawing.Point(40, 88)
        Me.LinkLabel15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel15.Name = "LinkLabel15"
        Me.LinkLabel15.Size = New System.Drawing.Size(88, 19)
        Me.LinkLabel15.TabIndex = 9
        Me.LinkLabel15.TabStop = True
        Me.LinkLabel15.Tag = ""
        Me.LinkLabel15.Text = "Evénement"
        '
        'Event_cbo
        '
        Me.Event_cbo.Location = New System.Drawing.Point(134, 82)
        Me.Event_cbo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Event_cbo.Name = "Event_cbo"
        Me.Event_cbo.Size = New System.Drawing.Size(182, 27)
        Me.Event_cbo.TabIndex = 16
        '
        'Val_Index_txt
        '
        Me.Val_Index_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Val_Index_txt.ContextMenuStrip = Nothing
        Me.Val_Index_txt.Location = New System.Drawing.Point(134, 51)
        Me.Val_Index_txt.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Val_Index_txt.MaxLength = 32767
        Me.Val_Index_txt.Multiline = False
        Me.Val_Index_txt.Name = "Val_Index_txt"
        Me.Val_Index_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Val_Index_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Val_Index_txt.ReadOnly = False
        Me.Val_Index_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Val_Index_txt.SelectionStart = 0
        Me.Val_Index_txt.Size = New System.Drawing.Size(469, 26)
        Me.Val_Index_txt.TabIndex = 5
        Me.Val_Index_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Val_Index_txt.UseSystemPasswordChar = False
        '
        'Table_Ref_txt
        '
        Me.Table_Ref_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Table_Ref_txt.ContextMenuStrip = Nothing
        Me.Table_Ref_txt.Enabled = False
        Me.Table_Ref_txt.Location = New System.Drawing.Point(134, 20)
        Me.Table_Ref_txt.MaxLength = 32767
        Me.Table_Ref_txt.Name = "Table_Ref_txt"
        Me.Table_Ref_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Table_Ref_txt.ReadOnly = False
        Me.Table_Ref_txt.SelectionStart = 0
        Me.Table_Ref_txt.Size = New System.Drawing.Size(182, 26)
        Me.Table_Ref_txt.TabIndex = 200
        Me.Table_Ref_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'code_Client_Facture
        '
        Me.code_Client_Facture.AutoSize = True
        Me.code_Client_Facture.LinkColor = System.Drawing.Color.Black
        Me.code_Client_Facture.Location = New System.Drawing.Point(80, 24)
        Me.code_Client_Facture.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.code_Client_Facture.Name = "code_Client_Facture"
        Me.code_Client_Facture.Size = New System.Drawing.Size(46, 19)
        Me.code_Client_Facture.TabIndex = 0
        Me.code_Client_Facture.TabStop = True
        Me.code_Client_Facture.Tag = "SC"
        Me.code_Client_Facture.Text = "Table"
        '
        'Grille
        '
        Me.Grille.AfficherLesEntetesLignes = True
        Me.Grille.AllowUserToAddRows = False
        Me.Grille.AllowUserToOrderColumns = True
        Me.Grille.AlternerLesLignes = False
        Me.Grille.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grille.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grille.EnableHeadersVisualStyles = False
        Me.Grille.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grille.Location = New System.Drawing.Point(0, 232)
        Me.Grille.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grille.Name = "Grille"
        Me.Grille.ReadOnly = True
        Me.Grille.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grille.RowHeadersWidth = 51
        Me.Grille.Size = New System.Drawing.Size(1629, 564)
        Me.Grille.TabIndex = 2
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tableLayoutPanel1.ColumnCount = 2
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.ButtonX1, 0, 0)
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 1
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.tableLayoutPanel1.TabIndex = 0
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
        Me.ButtonX2.Location = New System.Drawing.Point(36, 3)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(28, 8)
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "Annuler"
        '
        'Notifications_Consultation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1629, 796)
        Me.Controls.Add(Me.Grille)
        Me.Controls.Add(Me.SEL_CRT_GROUP)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Notifications_Consultation"
        Me.Tag = "ECR"
        Me.Text = "Consultation des notifications"
        Me.SEL_CRT_GROUP.ResumeLayout(False)
        Me.SEL_CRT_GROUP.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SEL_CRT_GROUP As System.Windows.Forms.GroupBox
    Friend WithEvents Table_Ref_txt As ud_TextBox
    Friend WithEvents code_Client_Facture As System.Windows.Forms.LinkLabel
    Friend WithEvents Dat_Event_Deb_txt As ud_TextBox
    Friend WithEvents Event_cbo As ud_ComboBox
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel15 As System.Windows.Forms.LinkLabel
    Friend WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As ud_button
    Friend WithEvents ButtonX2 As ud_button
    Friend WithEvents Grille As ud_Grd
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Dat_Event_Fin_txt As ud_TextBox
    Friend WithEvents Table_Index_txt As ud_TextBox
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Au_Notif As LinkLabel
    Friend WithEvents Dat_Notif_Fin As ud_TextBox
    Friend WithEvents Du_Notif As LinkLabel
    Friend WithEvents Dat_Notif_Deb As ud_TextBox
    Friend WithEvents Val_Index_txt As ud_TextBox
    Friend WithEvents All_chk As ud_RadioBox
    Friend WithEvents NotNotified_chk As ud_RadioBox
    Friend WithEvents Notified_chk As ud_RadioBox
End Class
