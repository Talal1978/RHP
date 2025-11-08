<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formation_Evaluation
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
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Cod_Formation_txt = New RHP.ud_TextBox()
        Me.Lib_Formation_txt = New RHP.ud_TextBox()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Pnl_Bottom = New System.Windows.Forms.Panel()
        Me.Lib_Survey_lbl = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_lbl = New System.Windows.Forms.Label()
        Me.Print_pb = New System.Windows.Forms.PictureBox()
        Me.Cloture_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.New_pb = New System.Windows.Forms.PictureBox()
        Me.pnl_Top.SuspendLayout()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Print_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cloture_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Content
        '
        Me.pnl_Content.AutoScroll = True
        Me.pnl_Content.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Content.Location = New System.Drawing.Point(29, 208)
        Me.pnl_Content.Name = "pnl_Content"
        Me.pnl_Content.Size = New System.Drawing.Size(802, 426)
        Me.pnl_Content.TabIndex = 3
        '
        'Pnl_Left
        '
        Me.Pnl_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.Pnl_Left.Location = New System.Drawing.Point(2, 32)
        Me.Pnl_Left.Name = "Pnl_Left"
        Me.Pnl_Left.Size = New System.Drawing.Size(27, 612)
        Me.Pnl_Left.TabIndex = 0
        '
        'pnl_Right
        '
        Me.pnl_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(831, 95)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Size = New System.Drawing.Size(27, 549)
        Me.pnl_Right.TabIndex = 4
        '
        'Preambule_rtb
        '
        Me.Preambule_rtb.BackColor = System.Drawing.Color.White
        Me.Preambule_rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Preambule_rtb.Dock = System.Windows.Forms.DockStyle.Top
        Me.Preambule_rtb.Enabled = False
        Me.Preambule_rtb.Location = New System.Drawing.Point(29, 118)
        Me.Preambule_rtb.Name = "Preambule_rtb"
        Me.Preambule_rtb.ReadOnly = True
        Me.Preambule_rtb.Size = New System.Drawing.Size(802, 90)
        Me.Preambule_rtb.TabIndex = 0
        Me.Preambule_rtb.Text = ""
        Me.Preambule_rtb.Visible = False
        '
        'pnl_Top
        '
        Me.pnl_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Top.Controls.Add(Me.LinkLabel1)
        Me.pnl_Top.Controls.Add(Me.LinkLabel3)
        Me.pnl_Top.Controls.Add(Me.Cod_Formation_txt)
        Me.pnl_Top.Controls.Add(Me.Lib_Formation_txt)
        Me.pnl_Top.Controls.Add(Me.Matricule_txt)
        Me.pnl_Top.Controls.Add(Me.Nom_Agent_Text)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(29, 32)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(829, 63)
        Me.pnl_Top.TabIndex = 5
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(62, 13)
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
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(76, 37)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(61, 16)
        Me.LinkLabel3.TabIndex = 213
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = ""
        Me.LinkLabel3.Text = "Formation"
        '
        'Cod_Formation_txt
        '
        Me.Cod_Formation_txt.AccessibleDescription = "A"
        Me.Cod_Formation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Formation_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Formation_txt.Location = New System.Drawing.Point(141, 34)
        Me.Cod_Formation_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Cod_Formation_txt.MaxLength = 32767
        Me.Cod_Formation_txt.Multiline = False
        Me.Cod_Formation_txt.Name = "Cod_Formation_txt"
        Me.Cod_Formation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Formation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Formation_txt.ReadOnly = True
        Me.Cod_Formation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Formation_txt.SelectionStart = 0
        Me.Cod_Formation_txt.Size = New System.Drawing.Size(104, 21)
        Me.Cod_Formation_txt.TabIndex = 209
        Me.Cod_Formation_txt.TabStop = False
        Me.Cod_Formation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Formation_txt.UseSystemPasswordChar = False
        '
        'Lib_Formation_txt
        '
        Me.Lib_Formation_txt.AccessibleDescription = "A"
        Me.Lib_Formation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Formation_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Formation_txt.Location = New System.Drawing.Point(249, 34)
        Me.Lib_Formation_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Lib_Formation_txt.MaxLength = 32767
        Me.Lib_Formation_txt.Multiline = False
        Me.Lib_Formation_txt.Name = "Lib_Formation_txt"
        Me.Lib_Formation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Formation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Formation_txt.ReadOnly = False
        Me.Lib_Formation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Formation_txt.SelectionStart = 0
        Me.Lib_Formation_txt.Size = New System.Drawing.Size(362, 21)
        Me.Lib_Formation_txt.TabIndex = 211
        Me.Lib_Formation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Formation_txt.UseSystemPasswordChar = False
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_txt.Location = New System.Drawing.Point(141, 10)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(104, 21)
        Me.Matricule_txt.TabIndex = 209
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(249, 10)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = False
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(362, 21)
        Me.Nom_Agent_Text.TabIndex = 211
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Pnl_Bottom
        '
        Me.Pnl_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Bottom.Location = New System.Drawing.Point(29, 634)
        Me.Pnl_Bottom.Name = "Pnl_Bottom"
        Me.Pnl_Bottom.Size = New System.Drawing.Size(802, 10)
        Me.Pnl_Bottom.TabIndex = 6
        '
        'Lib_Survey_lbl
        '
        Me.Lib_Survey_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lib_Survey_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lib_Survey_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lib_Survey_lbl.Location = New System.Drawing.Point(29, 95)
        Me.Lib_Survey_lbl.Name = "Lib_Survey_lbl"
        Me.Lib_Survey_lbl.Size = New System.Drawing.Size(802, 23)
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
        Me.ent_pnl.Controls.Add(Me.lbl_lbl, 4, 0)
        Me.ent_pnl.Controls.Add(Me.Print_pb, 2, 0)
        Me.ent_pnl.Controls.Add(Me.Cloture_pb, 3, 0)
        Me.ent_pnl.Controls.Add(Me.Save_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.New_pb, 0, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(856, 30)
        Me.ent_pnl.TabIndex = 9
        '
        'lbl_lbl
        '
        Me.lbl_lbl.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_lbl.Location = New System.Drawing.Point(131, 0)
        Me.lbl_lbl.Name = "lbl_lbl"
        Me.lbl_lbl.Size = New System.Drawing.Size(650, 30)
        Me.lbl_lbl.TabIndex = 12
        Me.lbl_lbl.Text = "Evaluation de formation"
        Me.lbl_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Print_pb
        '
        Me.Print_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Print_pb.Image = Global.RHP.My.Resources.Resources.btn_printer
        Me.Print_pb.InitialImage = Nothing
        Me.Print_pb.Location = New System.Drawing.Point(67, 3)
        Me.Print_pb.Name = "Print_pb"
        Me.Print_pb.Size = New System.Drawing.Size(26, 24)
        Me.Print_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Print_pb.TabIndex = 11
        Me.Print_pb.TabStop = False
        Me.Print_pb.Visible = False
        '
        'Cloture_pb
        '
        Me.Cloture_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cloture_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cloture_pb.Image = Global.RHP.My.Resources.Resources.btn_unlock
        Me.Cloture_pb.InitialImage = Nothing
        Me.Cloture_pb.Location = New System.Drawing.Point(99, 3)
        Me.Cloture_pb.Name = "Cloture_pb"
        Me.Cloture_pb.Size = New System.Drawing.Size(26, 24)
        Me.Cloture_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Cloture_pb.TabIndex = 11
        Me.Cloture_pb.TabStop = False
        Me.Cloture_pb.Visible = False
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(35, 3)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(26, 24)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Save_pb.TabIndex = 11
        Me.Save_pb.TabStop = False
        '
        'New_pb
        '
        Me.New_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.New_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.New_pb.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.New_pb.InitialImage = Nothing
        Me.New_pb.Location = New System.Drawing.Point(3, 3)
        Me.New_pb.Name = "New_pb"
        Me.New_pb.Size = New System.Drawing.Size(26, 24)
        Me.New_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.New_pb.TabIndex = 11
        Me.New_pb.TabStop = False
        '
        'Formation_Evaluation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(860, 646)
        Me.Controls.Add(Me.pnl_Content)
        Me.Controls.Add(Me.Pnl_Bottom)
        Me.Controls.Add(Me.Preambule_rtb)
        Me.Controls.Add(Me.Lib_Survey_lbl)
        Me.Controls.Add(Me.pnl_Right)
        Me.Controls.Add(Me.pnl_Top)
        Me.Controls.Add(Me.Pnl_Left)
        Me.Controls.Add(Me.ent_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Formation_Evaluation"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Tag = "ECR"
        Me.Text = "Evaluation de formation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_Top.PerformLayout()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Print_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cloture_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Content As Panel
    Friend WithEvents Pnl_Left As Panel
    Friend WithEvents pnl_Right As Panel
    Friend WithEvents Preambule_rtb As RichTextBox
    Friend WithEvents pnl_Top As Panel
    Friend WithEvents Pnl_Bottom As Panel
    Friend WithEvents Cod_Formation_txt As ud_TextBox
    Friend WithEvents Lib_Formation_txt As ud_TextBox
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Lib_Survey_lbl As Label
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Cloture_pb As PictureBox
    Friend WithEvents Print_pb As PictureBox
    Friend WithEvents lbl_lbl As Label
    Friend WithEvents New_pb As PictureBox
End Class
