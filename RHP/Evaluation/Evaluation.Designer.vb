<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Evaluation
    inherits Ecran

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
        Me.eval_tblpnl = New System.Windows.Forms.TableLayoutPanel()
        Me.pnl_note = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.note_totale_txt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.coef_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.note_txt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Eval_info = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Cod_Evaluation_txt = New RHP.ud_TextBox()
        Me.Nom_Evaluateur_txt = New RHP.ud_TextBox()
        Me.Lib_Evaluation_txt = New RHP.ud_TextBox()
        Me.Evaluateur_txt = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Nom_Evalue_txt = New RHP.ud_TextBox()
        Me.Evalue_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Pnl_Bottom = New System.Windows.Forms.Panel()
        Me.Lib_Survey_lbl = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Cloture_pb = New System.Windows.Forms.PictureBox()
        Me.Print_pb = New System.Windows.Forms.PictureBox()
        Me.lbl_lbl = New System.Windows.Forms.Label()
        Me.pnl_Top.SuspendLayout()
        Me.eval_tblpnl.SuspendLayout()
        Me.pnl_note.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Eval_info.SuspendLayout()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cloture_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Print_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Content
        '
        Me.pnl_Content.AutoScroll = True
        Me.pnl_Content.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Content.Location = New System.Drawing.Point(41, 339)
        Me.pnl_Content.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnl_Content.Name = "pnl_Content"
        Me.pnl_Content.Size = New System.Drawing.Size(1172, 489)
        Me.pnl_Content.TabIndex = 3
        '
        'Pnl_Left
        '
        Me.Pnl_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.Pnl_Left.Location = New System.Drawing.Point(2, 40)
        Me.Pnl_Left.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Pnl_Left.Name = "Pnl_Left"
        Me.Pnl_Left.Size = New System.Drawing.Size(39, 803)
        Me.Pnl_Left.TabIndex = 0
        '
        'pnl_Right
        '
        Me.pnl_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(1213, 165)
        Me.pnl_Right.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Size = New System.Drawing.Size(39, 678)
        Me.pnl_Right.TabIndex = 4
        '
        'Preambule_rtb
        '
        Me.Preambule_rtb.BackColor = System.Drawing.Color.White
        Me.Preambule_rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Preambule_rtb.Dock = System.Windows.Forms.DockStyle.Top
        Me.Preambule_rtb.Enabled = False
        Me.Preambule_rtb.Location = New System.Drawing.Point(41, 200)
        Me.Preambule_rtb.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Preambule_rtb.Name = "Preambule_rtb"
        Me.Preambule_rtb.ReadOnly = True
        Me.Preambule_rtb.Size = New System.Drawing.Size(1172, 139)
        Me.Preambule_rtb.TabIndex = 0
        Me.Preambule_rtb.Text = ""
        Me.Preambule_rtb.Visible = False
        '
        'pnl_Top
        '
        Me.pnl_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Top.Controls.Add(Me.eval_tblpnl)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(41, 40)
        Me.pnl_Top.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(1211, 125)
        Me.pnl_Top.TabIndex = 5
        '
        'eval_tblpnl
        '
        Me.eval_tblpnl.ColumnCount = 2
        Me.eval_tblpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.eval_tblpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.eval_tblpnl.Controls.Add(Me.pnl_note, 1, 0)
        Me.eval_tblpnl.Controls.Add(Me.Eval_info, 0, 0)
        Me.eval_tblpnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.eval_tblpnl.Location = New System.Drawing.Point(0, 0)
        Me.eval_tblpnl.Margin = New System.Windows.Forms.Padding(2)
        Me.eval_tblpnl.Name = "eval_tblpnl"
        Me.eval_tblpnl.RowCount = 1
        Me.eval_tblpnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.eval_tblpnl.Size = New System.Drawing.Size(1211, 125)
        Me.eval_tblpnl.TabIndex = 251
        '
        'pnl_note
        '
        Me.pnl_note.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_note.AutoSize = True
        Me.pnl_note.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnl_note.ColumnCount = 1
        Me.pnl_note.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnl_note.Controls.Add(Me.TableLayoutPanel4, 0, 2)
        Me.pnl_note.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.pnl_note.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.pnl_note.Location = New System.Drawing.Point(1013, 2)
        Me.pnl_note.Margin = New System.Windows.Forms.Padding(2)
        Me.pnl_note.MaximumSize = New System.Drawing.Size(194, 111)
        Me.pnl_note.MinimumSize = New System.Drawing.Size(194, 111)
        Me.pnl_note.Name = "pnl_note"
        Me.pnl_note.RowCount = 3
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.45055!))
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.54945!))
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnl_note.Size = New System.Drawing.Size(194, 111)
        Me.pnl_note.TabIndex = 251
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.note_totale_txt, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(2, 77)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(190, 32)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'note_totale_txt
        '
        Me.note_totale_txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.note_totale_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.note_totale_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.note_totale_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.note_totale_txt.Location = New System.Drawing.Point(110, 2)
        Me.note_totale_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.note_totale_txt.Name = "note_totale_txt"
        Me.note_totale_txt.Size = New System.Drawing.Size(64, 27)
        Me.note_totale_txt.TabIndex = 0
        Me.note_totale_txt.Text = "0"
        Me.note_totale_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(2, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 32)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Note totale"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.coef_txt, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 39)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(190, 34)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'coef_txt
        '
        Me.coef_txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.coef_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.coef_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.coef_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.coef_txt.Location = New System.Drawing.Point(110, 3)
        Me.coef_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.coef_txt.Name = "coef_txt"
        Me.coef_txt.Size = New System.Drawing.Size(64, 27)
        Me.coef_txt.TabIndex = 0
        Me.coef_txt.Text = "0"
        Me.coef_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(2, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 34)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Coef."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.note_txt, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(190, 33)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'note_txt
        '
        Me.note_txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.note_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.note_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.note_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.note_txt.Location = New System.Drawing.Point(110, 3)
        Me.note_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.note_txt.Name = "note_txt"
        Me.note_txt.Size = New System.Drawing.Size(64, 27)
        Me.note_txt.TabIndex = 0
        Me.note_txt.Text = "0"
        Me.note_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(2, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 33)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Note"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Eval_info
        '
        Me.Eval_info.Controls.Add(Me.LinkLabel1)
        Me.Eval_info.Controls.Add(Me.Cod_Evaluation_txt)
        Me.Eval_info.Controls.Add(Me.Nom_Evaluateur_txt)
        Me.Eval_info.Controls.Add(Me.Lib_Evaluation_txt)
        Me.Eval_info.Controls.Add(Me.Evaluateur_txt)
        Me.Eval_info.Controls.Add(Me.LinkLabel4)
        Me.Eval_info.Controls.Add(Me.Nom_Evalue_txt)
        Me.Eval_info.Controls.Add(Me.Evalue_txt)
        Me.Eval_info.Controls.Add(Me.LinkLabel3)
        Me.Eval_info.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Eval_info.Location = New System.Drawing.Point(2, 2)
        Me.Eval_info.Margin = New System.Windows.Forms.Padding(2)
        Me.Eval_info.Name = "Eval_info"
        Me.Eval_info.Size = New System.Drawing.Size(1007, 121)
        Me.Eval_info.TabIndex = 250
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(5, 10)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(94, 19)
        Me.LinkLabel1.TabIndex = 213
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "SC"
        Me.LinkLabel1.Text = "L'évaluateur"
        '
        'Cod_Evaluation_txt
        '
        Me.Cod_Evaluation_txt.AccessibleDescription = "A"
        Me.Cod_Evaluation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Evaluation_txt.ContextMenuStrip = Nothing
        Me.Cod_Evaluation_txt.Location = New System.Drawing.Point(105, 80)
        Me.Cod_Evaluation_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Evaluation_txt.MaxLength = 32767
        Me.Cod_Evaluation_txt.Multiline = False
        Me.Cod_Evaluation_txt.Name = "Cod_Evaluation_txt"
        Me.Cod_Evaluation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Evaluation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Evaluation_txt.ReadOnly = True
        Me.Cod_Evaluation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Evaluation_txt.SelectionStart = 0
        Me.Cod_Evaluation_txt.Size = New System.Drawing.Size(151, 26)
        Me.Cod_Evaluation_txt.TabIndex = 247
        Me.Cod_Evaluation_txt.TabStop = False
        Me.Cod_Evaluation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Evaluation_txt.UseSystemPasswordChar = False
        '
        'Nom_Evaluateur_txt
        '
        Me.Nom_Evaluateur_txt.AccessibleDescription = "A"
        Me.Nom_Evaluateur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Evaluateur_txt.ContextMenuStrip = Nothing
        Me.Nom_Evaluateur_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Evaluateur_txt.Location = New System.Drawing.Point(259, 8)
        Me.Nom_Evaluateur_txt.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.Nom_Evaluateur_txt.MaxLength = 32767
        Me.Nom_Evaluateur_txt.Multiline = False
        Me.Nom_Evaluateur_txt.Name = "Nom_Evaluateur_txt"
        Me.Nom_Evaluateur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Evaluateur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Evaluateur_txt.ReadOnly = False
        Me.Nom_Evaluateur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Evaluateur_txt.SelectionStart = 0
        Me.Nom_Evaluateur_txt.Size = New System.Drawing.Size(490, 26)
        Me.Nom_Evaluateur_txt.TabIndex = 211
        Me.Nom_Evaluateur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Evaluateur_txt.UseSystemPasswordChar = False
        '
        'Lib_Evaluation_txt
        '
        Me.Lib_Evaluation_txt.AccessibleDescription = "A"
        Me.Lib_Evaluation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Evaluation_txt.ContextMenuStrip = Nothing
        Me.Lib_Evaluation_txt.Location = New System.Drawing.Point(259, 80)
        Me.Lib_Evaluation_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Evaluation_txt.MaxLength = 32767
        Me.Lib_Evaluation_txt.Multiline = False
        Me.Lib_Evaluation_txt.Name = "Lib_Evaluation_txt"
        Me.Lib_Evaluation_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Evaluation_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Evaluation_txt.ReadOnly = False
        Me.Lib_Evaluation_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Evaluation_txt.SelectionStart = 0
        Me.Lib_Evaluation_txt.Size = New System.Drawing.Size(490, 26)
        Me.Lib_Evaluation_txt.TabIndex = 249
        Me.Lib_Evaluation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Evaluation_txt.UseSystemPasswordChar = False
        '
        'Evaluateur_txt
        '
        Me.Evaluateur_txt.AccessibleDescription = "A"
        Me.Evaluateur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Evaluateur_txt.ContextMenuStrip = Nothing
        Me.Evaluateur_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Evaluateur_txt.Location = New System.Drawing.Point(105, 8)
        Me.Evaluateur_txt.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.Evaluateur_txt.MaxLength = 32767
        Me.Evaluateur_txt.Multiline = False
        Me.Evaluateur_txt.Name = "Evaluateur_txt"
        Me.Evaluateur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Evaluateur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Evaluateur_txt.ReadOnly = True
        Me.Evaluateur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Evaluateur_txt.SelectionStart = 0
        Me.Evaluateur_txt.Size = New System.Drawing.Size(151, 26)
        Me.Evaluateur_txt.TabIndex = 209
        Me.Evaluateur_txt.TabStop = False
        Me.Evaluateur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Evaluateur_txt.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(18, 82)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(83, 19)
        Me.LinkLabel4.TabIndex = 248
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Evaluation"
        '
        'Nom_Evalue_txt
        '
        Me.Nom_Evalue_txt.AccessibleDescription = "A"
        Me.Nom_Evalue_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Evalue_txt.ContextMenuStrip = Nothing
        Me.Nom_Evalue_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Evalue_txt.Location = New System.Drawing.Point(259, 44)
        Me.Nom_Evalue_txt.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.Nom_Evalue_txt.MaxLength = 32767
        Me.Nom_Evalue_txt.Multiline = False
        Me.Nom_Evalue_txt.Name = "Nom_Evalue_txt"
        Me.Nom_Evalue_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Evalue_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Evalue_txt.ReadOnly = False
        Me.Nom_Evalue_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Evalue_txt.SelectionStart = 0
        Me.Nom_Evalue_txt.Size = New System.Drawing.Size(490, 26)
        Me.Nom_Evalue_txt.TabIndex = 211
        Me.Nom_Evalue_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Evalue_txt.UseSystemPasswordChar = False
        '
        'Evalue_txt
        '
        Me.Evalue_txt.AccessibleDescription = "A"
        Me.Evalue_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Evalue_txt.ContextMenuStrip = Nothing
        Me.Evalue_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Evalue_txt.Location = New System.Drawing.Point(105, 44)
        Me.Evalue_txt.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.Evalue_txt.MaxLength = 32767
        Me.Evalue_txt.Multiline = False
        Me.Evalue_txt.Name = "Evalue_txt"
        Me.Evalue_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Evalue_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Evalue_txt.ReadOnly = True
        Me.Evalue_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Evalue_txt.SelectionStart = 0
        Me.Evalue_txt.Size = New System.Drawing.Size(151, 26)
        Me.Evalue_txt.TabIndex = 209
        Me.Evalue_txt.TabStop = False
        Me.Evalue_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Evalue_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(42, 48)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(56, 19)
        Me.LinkLabel3.TabIndex = 213
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = ""
        Me.LinkLabel3.Text = "Evalué"
        '
        'Pnl_Bottom
        '
        Me.Pnl_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Bottom.Location = New System.Drawing.Point(41, 828)
        Me.Pnl_Bottom.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Pnl_Bottom.Name = "Pnl_Bottom"
        Me.Pnl_Bottom.Size = New System.Drawing.Size(1172, 15)
        Me.Pnl_Bottom.TabIndex = 6
        '
        'Lib_Survey_lbl
        '
        Me.Lib_Survey_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lib_Survey_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lib_Survey_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lib_Survey_lbl.Location = New System.Drawing.Point(41, 165)
        Me.Lib_Survey_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lib_Survey_lbl.Name = "Lib_Survey_lbl"
        Me.Lib_Survey_lbl.Size = New System.Drawing.Size(1172, 35)
        Me.Lib_Survey_lbl.TabIndex = 0
        Me.Lib_Survey_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ent_pnl.ColumnCount = 5
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.ent_pnl.Controls.Add(Me.Close_pb, 4, 0)
        Me.ent_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Cloture_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Print_pb, 2, 0)
        Me.ent_pnl.Controls.Add(Me.lbl_lbl, 3, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(1250, 38)
        Me.ent_pnl.TabIndex = 8
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(1214, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(32, 30)
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
        Me.Save_pb.Location = New System.Drawing.Point(4, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(32, 30)
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
        Me.Cloture_pb.Location = New System.Drawing.Point(44, 4)
        Me.Cloture_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Cloture_pb.Name = "Cloture_pb"
        Me.Cloture_pb.Size = New System.Drawing.Size(32, 30)
        Me.Cloture_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Cloture_pb.TabIndex = 11
        Me.Cloture_pb.TabStop = False
        '
        'Print_pb
        '
        Me.Print_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Print_pb.Image = Global.RHP.My.Resources.Resources.btn_printer
        Me.Print_pb.InitialImage = Nothing
        Me.Print_pb.Location = New System.Drawing.Point(84, 4)
        Me.Print_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Print_pb.Name = "Print_pb"
        Me.Print_pb.Size = New System.Drawing.Size(32, 30)
        Me.Print_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Print_pb.TabIndex = 11
        Me.Print_pb.TabStop = False
        '
        'lbl_lbl
        '
        Me.lbl_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lbl_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_lbl.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl_lbl.Location = New System.Drawing.Point(124, 0)
        Me.lbl_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_lbl.Name = "lbl_lbl"
        Me.lbl_lbl.Size = New System.Drawing.Size(1082, 38)
        Me.lbl_lbl.TabIndex = 12
        Me.lbl_lbl.Text = "Evaluation"
        Me.lbl_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Evaluation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1254, 845)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Evaluation"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Tag = "ECR"
        Me.Text = "Evaluation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_Top.ResumeLayout(False)
        Me.eval_tblpnl.ResumeLayout(False)
        Me.eval_tblpnl.PerformLayout()
        Me.pnl_note.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Eval_info.ResumeLayout(False)
        Me.Eval_info.PerformLayout()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cloture_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Print_pb, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Cod_Evaluation_txt As ud_TextBox
    Friend WithEvents Lib_Evaluation_txt As ud_TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Cloture_pb As PictureBox
    Friend WithEvents Print_pb As PictureBox
    Friend WithEvents lbl_lbl As Label
    Friend WithEvents eval_tblpnl As TableLayoutPanel
    Friend WithEvents Eval_info As Panel
    Friend WithEvents pnl_note As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents note_totale_txt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents coef_txt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents note_txt As TextBox
    Friend WithEvents Label1 As Label
End Class
