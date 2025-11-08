<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Entretien
    Inherits Ecran

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnl_Content = New System.Windows.Forms.Panel()
        Me.Pnl_Left = New System.Windows.Forms.Panel()
        Me.pnl_Right = New System.Windows.Forms.Panel()
        Me.Preambule_rtb = New System.Windows.Forms.RichTextBox()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.Cv_btn = New RHP.ud_button()
        Me.Interne_chk = New RHP.ud_CheckBox()
        Me.Ud_TextBox3 = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dat_Survey = New System.Windows.Forms.DateTimePicker()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Num_RC_txt = New RHP.ud_TextBox()
        Me.Lib_RC_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Evalue_txt = New RHP.ud_TextBox()
        Me.Nom_Evalue_txt = New RHP.ud_TextBox()
        Me.Evaluateur_txt = New RHP.ud_TextBox()
        Me.Nom_Evaluateur_txt = New RHP.ud_TextBox()
        Me.Pnl_Bottom = New System.Windows.Forms.Panel()
        Me.Lib_Survey_lbl = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Cloture_pb = New System.Windows.Forms.PictureBox()
        Me.lbl_lbl = New System.Windows.Forms.Label()
        Me.RC_btn = New RHP.ud_button()
        Me.pnl_Top.SuspendLayout()
        Me.ent_pnl.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cloture_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Content
        '
        Me.pnl_Content.AutoScroll = True
        Me.pnl_Content.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Content.Location = New System.Drawing.Point(33, 315)
        Me.pnl_Content.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnl_Content.Name = "pnl_Content"
        Me.pnl_Content.Size = New System.Drawing.Size(937, 466)
        Me.pnl_Content.TabIndex = 3
        '
        'Pnl_Left
        '
        Me.Pnl_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.Pnl_Left.Location = New System.Drawing.Point(2, 32)
        Me.Pnl_Left.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Pnl_Left.Name = "Pnl_Left"
        Me.Pnl_Left.Size = New System.Drawing.Size(31, 761)
        Me.Pnl_Left.TabIndex = 0
        '
        'pnl_Right
        '
        Me.pnl_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(970, 176)
        Me.pnl_Right.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Size = New System.Drawing.Size(31, 617)
        Me.pnl_Right.TabIndex = 4
        '
        'Preambule_rtb
        '
        Me.Preambule_rtb.BackColor = System.Drawing.Color.White
        Me.Preambule_rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Preambule_rtb.Dock = System.Windows.Forms.DockStyle.Top
        Me.Preambule_rtb.Enabled = False
        Me.Preambule_rtb.Location = New System.Drawing.Point(33, 204)
        Me.Preambule_rtb.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Preambule_rtb.Name = "Preambule_rtb"
        Me.Preambule_rtb.ReadOnly = True
        Me.Preambule_rtb.Size = New System.Drawing.Size(937, 111)
        Me.Preambule_rtb.TabIndex = 0
        Me.Preambule_rtb.Text = ""
        Me.Preambule_rtb.Visible = False
        '
        'pnl_Top
        '
        Me.pnl_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Top.Controls.Add(Me.RC_btn)
        Me.pnl_Top.Controls.Add(Me.Cv_btn)
        Me.pnl_Top.Controls.Add(Me.Interne_chk)
        Me.pnl_Top.Controls.Add(Me.Ud_TextBox3)
        Me.pnl_Top.Controls.Add(Me.Label2)
        Me.pnl_Top.Controls.Add(Me.Label1)
        Me.pnl_Top.Controls.Add(Me.Dat_Survey)
        Me.pnl_Top.Controls.Add(Me.LinkLabel2)
        Me.pnl_Top.Controls.Add(Me.Num_RC_txt)
        Me.pnl_Top.Controls.Add(Me.Lib_RC_txt)
        Me.pnl_Top.Controls.Add(Me.LinkLabel1)
        Me.pnl_Top.Controls.Add(Me.LinkLabel3)
        Me.pnl_Top.Controls.Add(Me.Evalue_txt)
        Me.pnl_Top.Controls.Add(Me.Nom_Evalue_txt)
        Me.pnl_Top.Controls.Add(Me.Evaluateur_txt)
        Me.pnl_Top.Controls.Add(Me.Nom_Evaluateur_txt)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(33, 32)
        Me.pnl_Top.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(968, 144)
        Me.pnl_Top.TabIndex = 5
        '
        'Cv_btn
        '
        Me.Cv_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Cv_btn.Border = RHP.ud_button.BorderStyle.None
        Me.Cv_btn.BorderColor = System.Drawing.Color.Empty
        Me.Cv_btn.BorderSize = 0
        Me.Cv_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cv_btn.Image = Global.RHP.My.Resources.Resources.btn_vue
        Me.Cv_btn.isDefault = False
        Me.Cv_btn.Location = New System.Drawing.Point(609, 57)
        Me.Cv_btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cv_btn.MinimumSize = New System.Drawing.Size(23, 23)
        Me.Cv_btn.Name = "Cv_btn"
        Me.Cv_btn.Size = New System.Drawing.Size(33, 25)
        Me.Cv_btn.TabIndex = 257
        Me.Cv_btn.ToolTip = "Voir CV"
        '
        'Interne_chk
        '
        Me.Interne_chk.AutoSize = True
        Me.Interne_chk.Checked = True
        Me.Interne_chk.Location = New System.Drawing.Point(94, 82)
        Me.Interne_chk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Interne_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Interne_chk.MinimumSize = New System.Drawing.Size(117, 25)
        Me.Interne_chk.Name = "Interne_chk"
        Me.Interne_chk.Size = New System.Drawing.Size(118, 25)
        Me.Interne_chk.TabIndex = 256
        Me.Interne_chk.Text = "Ressource interne"
        '
        'Ud_TextBox3
        '
        Me.Ud_TextBox3.AccessibleDescription = "A"
        Me.Ud_TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ud_TextBox3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ud_TextBox3.Location = New System.Drawing.Point(488, 107)
        Me.Ud_TextBox3.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Ud_TextBox3.MaxLength = 32767
        Me.Ud_TextBox3.Multiline = False
        Me.Ud_TextBox3.Name = "Ud_TextBox3"
        Me.Ud_TextBox3.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ud_TextBox3.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ud_TextBox3.ReadOnly = True
        Me.Ud_TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ud_TextBox3.SelectionStart = 0
        Me.Ud_TextBox3.Size = New System.Drawing.Size(121, 21)
        Me.Ud_TextBox3.TabIndex = 255
        Me.Ud_TextBox3.TabStop = False
        Me.Ud_TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ud_TextBox3.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(333, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 16)
        Me.Label2.TabIndex = 254
        Me.Label2.Text = "Date prévue de l'entretien"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 16)
        Me.Label1.TabIndex = 254
        Me.Label1.Text = "Date entretien"
        '
        'Dat_Survey
        '
        Me.Dat_Survey.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.Dat_Survey.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dat_Survey.Location = New System.Drawing.Point(94, 107)
        Me.Dat_Survey.Name = "Dat_Survey"
        Me.Dat_Survey.Size = New System.Drawing.Size(121, 21)
        Me.Dat_Survey.TabIndex = 253
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(3, 11)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(89, 16)
        Me.LinkLabel2.TabIndex = 252
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = "SC"
        Me.LinkLabel2.Text = "N° recrutement"
        '
        'Num_RC_txt
        '
        Me.Num_RC_txt.AccessibleDescription = "A"
        Me.Num_RC_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_RC_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_RC_txt.Location = New System.Drawing.Point(94, 8)
        Me.Num_RC_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Num_RC_txt.MaxLength = 32767
        Me.Num_RC_txt.Multiline = False
        Me.Num_RC_txt.Name = "Num_RC_txt"
        Me.Num_RC_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_RC_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_RC_txt.ReadOnly = True
        Me.Num_RC_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_RC_txt.SelectionStart = 0
        Me.Num_RC_txt.Size = New System.Drawing.Size(121, 21)
        Me.Num_RC_txt.TabIndex = 250
        Me.Num_RC_txt.TabStop = False
        Me.Num_RC_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_RC_txt.UseSystemPasswordChar = False
        '
        'Lib_RC_txt
        '
        Me.Lib_RC_txt.AccessibleDescription = "A"
        Me.Lib_RC_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_RC_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_RC_txt.Location = New System.Drawing.Point(217, 8)
        Me.Lib_RC_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_RC_txt.MaxLength = 32767
        Me.Lib_RC_txt.Multiline = False
        Me.Lib_RC_txt.Name = "Lib_RC_txt"
        Me.Lib_RC_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_RC_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_RC_txt.ReadOnly = True
        Me.Lib_RC_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_RC_txt.SelectionStart = 0
        Me.Lib_RC_txt.Size = New System.Drawing.Size(392, 21)
        Me.Lib_RC_txt.TabIndex = 251
        Me.Lib_RC_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_RC_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(14, 37)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(76, 16)
        Me.LinkLabel1.TabIndex = 213
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "SC"
        Me.LinkLabel1.Text = "L'évaluateur"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(44, 62)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(46, 16)
        Me.LinkLabel3.TabIndex = 213
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = ""
        Me.LinkLabel3.Text = "Recrue"
        '
        'Evalue_txt
        '
        Me.Evalue_txt.AccessibleDescription = "A"
        Me.Evalue_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Evalue_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Evalue_txt.Location = New System.Drawing.Point(94, 60)
        Me.Evalue_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Evalue_txt.MaxLength = 32767
        Me.Evalue_txt.Multiline = False
        Me.Evalue_txt.Name = "Evalue_txt"
        Me.Evalue_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Evalue_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Evalue_txt.ReadOnly = True
        Me.Evalue_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Evalue_txt.SelectionStart = 0
        Me.Evalue_txt.Size = New System.Drawing.Size(121, 21)
        Me.Evalue_txt.TabIndex = 209
        Me.Evalue_txt.TabStop = False
        Me.Evalue_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Evalue_txt.UseSystemPasswordChar = False
        '
        'Nom_Evalue_txt
        '
        Me.Nom_Evalue_txt.AccessibleDescription = "A"
        Me.Nom_Evalue_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Evalue_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Evalue_txt.Location = New System.Drawing.Point(217, 60)
        Me.Nom_Evalue_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Nom_Evalue_txt.MaxLength = 32767
        Me.Nom_Evalue_txt.Multiline = False
        Me.Nom_Evalue_txt.Name = "Nom_Evalue_txt"
        Me.Nom_Evalue_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Evalue_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Evalue_txt.ReadOnly = True
        Me.Nom_Evalue_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Evalue_txt.SelectionStart = 0
        Me.Nom_Evalue_txt.Size = New System.Drawing.Size(392, 21)
        Me.Nom_Evalue_txt.TabIndex = 211
        Me.Nom_Evalue_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Evalue_txt.UseSystemPasswordChar = False
        '
        'Evaluateur_txt
        '
        Me.Evaluateur_txt.AccessibleDescription = "A"
        Me.Evaluateur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Evaluateur_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Evaluateur_txt.Location = New System.Drawing.Point(94, 34)
        Me.Evaluateur_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Evaluateur_txt.MaxLength = 32767
        Me.Evaluateur_txt.Multiline = False
        Me.Evaluateur_txt.Name = "Evaluateur_txt"
        Me.Evaluateur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Evaluateur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Evaluateur_txt.ReadOnly = True
        Me.Evaluateur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Evaluateur_txt.SelectionStart = 0
        Me.Evaluateur_txt.Size = New System.Drawing.Size(121, 21)
        Me.Evaluateur_txt.TabIndex = 209
        Me.Evaluateur_txt.TabStop = False
        Me.Evaluateur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Evaluateur_txt.UseSystemPasswordChar = False
        '
        'Nom_Evaluateur_txt
        '
        Me.Nom_Evaluateur_txt.AccessibleDescription = "A"
        Me.Nom_Evaluateur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Evaluateur_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Evaluateur_txt.Location = New System.Drawing.Point(217, 34)
        Me.Nom_Evaluateur_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Nom_Evaluateur_txt.MaxLength = 32767
        Me.Nom_Evaluateur_txt.Multiline = False
        Me.Nom_Evaluateur_txt.Name = "Nom_Evaluateur_txt"
        Me.Nom_Evaluateur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Evaluateur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Evaluateur_txt.ReadOnly = True
        Me.Nom_Evaluateur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Evaluateur_txt.SelectionStart = 0
        Me.Nom_Evaluateur_txt.Size = New System.Drawing.Size(392, 21)
        Me.Nom_Evaluateur_txt.TabIndex = 211
        Me.Nom_Evaluateur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Evaluateur_txt.UseSystemPasswordChar = False
        '
        'Pnl_Bottom
        '
        Me.Pnl_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Bottom.Location = New System.Drawing.Point(33, 781)
        Me.Pnl_Bottom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Pnl_Bottom.Name = "Pnl_Bottom"
        Me.Pnl_Bottom.Size = New System.Drawing.Size(937, 12)
        Me.Pnl_Bottom.TabIndex = 6
        '
        'Lib_Survey_lbl
        '
        Me.Lib_Survey_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lib_Survey_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lib_Survey_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lib_Survey_lbl.Location = New System.Drawing.Point(33, 176)
        Me.Lib_Survey_lbl.Name = "Lib_Survey_lbl"
        Me.Lib_Survey_lbl.Size = New System.Drawing.Size(937, 28)
        Me.Lib_Survey_lbl.TabIndex = 0
        Me.Lib_Survey_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ent_pnl.ColumnCount = 6
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.ent_pnl.Controls.Add(Me.PictureBox1, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 5, 0)
        Me.ent_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Cloture_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.lbl_lbl, 4, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(999, 30)
        Me.ent_pnl.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.RHP.My.Resources.Resources.btn_printer
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(35, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(970, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(26, 24)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 11
        Me.Close_pb.TabStop = False
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(3, 3)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(26, 24)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Save_pb.TabIndex = 11
        Me.Save_pb.TabStop = False
        '
        'Cloture_pb
        '
        Me.Cloture_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cloture_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cloture_pb.Image = Global.RHP.My.Resources.Resources.btn_unlock
        Me.Cloture_pb.InitialImage = Nothing
        Me.Cloture_pb.Location = New System.Drawing.Point(67, 3)
        Me.Cloture_pb.Name = "Cloture_pb"
        Me.Cloture_pb.Size = New System.Drawing.Size(26, 24)
        Me.Cloture_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Cloture_pb.TabIndex = 11
        Me.Cloture_pb.TabStop = False
        '
        'lbl_lbl
        '
        Me.lbl_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lbl_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_lbl.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_lbl.Location = New System.Drawing.Point(131, 0)
        Me.lbl_lbl.Name = "lbl_lbl"
        Me.lbl_lbl.Size = New System.Drawing.Size(833, 30)
        Me.lbl_lbl.TabIndex = 12
        Me.lbl_lbl.Text = "Entretien"
        Me.lbl_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RC_btn
        '
        Me.RC_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.RC_btn.Border = RHP.ud_button.BorderStyle.None
        Me.RC_btn.BorderColor = System.Drawing.Color.Empty
        Me.RC_btn.BorderSize = 0
        Me.RC_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RC_btn.Image = Global.RHP.My.Resources.Resources.btn_vue
        Me.RC_btn.isDefault = False
        Me.RC_btn.Location = New System.Drawing.Point(609, 6)
        Me.RC_btn.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.RC_btn.MinimumSize = New System.Drawing.Size(27, 21)
        Me.RC_btn.Name = "RC_btn"
        Me.RC_btn.Size = New System.Drawing.Size(33, 25)
        Me.RC_btn.TabIndex = 258
        Me.RC_btn.ToolTip = "Détail du recrutement"
        '
        'Entretien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1003, 795)
        Me.Controls.Add(Me.pnl_Content)
        Me.Controls.Add(Me.Pnl_Bottom)
        Me.Controls.Add(Me.Preambule_rtb)
        Me.Controls.Add(Me.Lib_Survey_lbl)
        Me.Controls.Add(Me.pnl_Right)
        Me.Controls.Add(Me.pnl_Top)
        Me.Controls.Add(Me.Pnl_Left)
        Me.Controls.Add(Me.ent_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Entretien"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Tag = "ECR"
        Me.Text = "Entretien de recrutement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_Top.PerformLayout()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cloture_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Content As Panel
    Friend WithEvents Pnl_Left As Panel
    Friend WithEvents pnl_Right As Panel
    Friend WithEvents Preambule_rtb As RichTextBox
    Friend WithEvents pnl_Top As Panel
    Friend WithEvents Pnl_Bottom As Panel
    Friend WithEvents Evalue_txt As ud_TextBox
    Friend WithEvents Nom_Evalue_txt As ud_TextBox
    Friend WithEvents Evaluateur_txt As ud_TextBox
    Friend WithEvents Nom_Evaluateur_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Lib_Survey_lbl As Label
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Cloture_pb As PictureBox
    Friend WithEvents lbl_lbl As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Num_RC_txt As ud_TextBox
    Friend WithEvents Lib_RC_txt As ud_TextBox
    Friend WithEvents Ud_TextBox3 As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Dat_Survey As DateTimePicker
    Friend WithEvents Interne_chk As ud_CheckBox
    Friend WithEvents Cv_btn As ud_button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RC_btn As ud_button
End Class
