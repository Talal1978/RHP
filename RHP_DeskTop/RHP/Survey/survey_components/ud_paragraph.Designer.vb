<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_paragraph
    Inherits ud_pattern

    'UserControl overrides dispose to clean up the component list.
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
        Me.LaQuestion_lbl = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Line = New System.Windows.Forms.Label()
        Me.Txt = New RHP.ud_TextBox()
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
        Me.numQuestion_pnl = New System.Windows.Forms.Panel()
        Me.Num_Question_lbl = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnl_note.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.numQuestion_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'LaQuestion_lbl
        '
        Me.LaQuestion_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LaQuestion_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaQuestion_lbl.Location = New System.Drawing.Point(73, 0)
        Me.LaQuestion_lbl.Margin = New System.Windows.Forms.Padding(20, 0, 3, 0)
        Me.LaQuestion_lbl.Name = "LaQuestion_lbl"
        Me.LaQuestion_lbl.Size = New System.Drawing.Size(523, 56)
        Me.LaQuestion_lbl.TabIndex = 0
        Me.LaQuestion_lbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LaQuestion_lbl, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Line, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pnl_note, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.numQuestion_pnl, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.13953!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.86047!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(799, 177)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'Line
        '
        Me.Line.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TableLayoutPanel1.SetColumnSpan(Me.Line, 3)
        Me.Line.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Line.Location = New System.Drawing.Point(10, 176)
        Me.Line.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Line.Name = "Line"
        Me.Line.Size = New System.Drawing.Size(779, 1)
        Me.Line.TabIndex = 6
        '
        'Txt
        '
        Me.Txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Txt.ContextMenuStrip = Nothing
        Me.Txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Txt.Location = New System.Drawing.Point(73, 60)
        Me.Txt.Margin = New System.Windows.Forms.Padding(20, 4, 4, 4)
        Me.Txt.MaxLength = 32767
        Me.Txt.Multiline = True
        Me.Txt.Name = "Txt"
        Me.Txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Txt.ReadOnly = False
        Me.Txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Txt.SelectionStart = 0
        Me.Txt.Size = New System.Drawing.Size(522, 104)
        Me.Txt.TabIndex = 5
        Me.Txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Txt.UseSystemPasswordChar = False
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
        Me.pnl_note.Location = New System.Drawing.Point(602, 3)
        Me.pnl_note.MaximumSize = New System.Drawing.Size(194, 111)
        Me.pnl_note.MinimumSize = New System.Drawing.Size(194, 111)
        Me.pnl_note.Name = "pnl_note"
        Me.pnl_note.RowCount = 3
        Me.TableLayoutPanel1.SetRowSpan(Me.pnl_note, 2)
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.45055!))
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.54945!))
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.pnl_note.Size = New System.Drawing.Size(194, 111)
        Me.pnl_note.TabIndex = 7
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.note_totale_txt, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 78)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(188, 30)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'note_totale_txt
        '
        Me.note_totale_txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.note_totale_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.note_totale_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.note_totale_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.note_totale_txt.Location = New System.Drawing.Point(109, 3)
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
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 30)
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
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 40)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(188, 32)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'coef_txt
        '
        Me.coef_txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.coef_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.coef_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.coef_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.coef_txt.Location = New System.Drawing.Point(109, 3)
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
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 32)
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(188, 31)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'note_txt
        '
        Me.note_txt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.note_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.note_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.note_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.note_txt.Location = New System.Drawing.Point(109, 3)
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
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Note"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numQuestion_pnl
        '
        Me.numQuestion_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.numQuestion_pnl.Controls.Add(Me.Num_Question_lbl)
        Me.numQuestion_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numQuestion_pnl.Location = New System.Drawing.Point(3, 3)
        Me.numQuestion_pnl.Name = "numQuestion_pnl"
        Me.numQuestion_pnl.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.TableLayoutPanel1.SetRowSpan(Me.numQuestion_pnl, 2)
        Me.numQuestion_pnl.Size = New System.Drawing.Size(47, 162)
        Me.numQuestion_pnl.TabIndex = 9
        '
        'Num_Question_lbl
        '
        Me.Num_Question_lbl.BackColor = System.Drawing.Color.White
        Me.Num_Question_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Num_Question_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Num_Question_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Num_Question_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Num_Question_lbl.Name = "Num_Question_lbl"
        Me.Num_Question_lbl.Size = New System.Drawing.Size(45, 162)
        Me.Num_Question_lbl.TabIndex = 0
        Me.Num_Question_lbl.Text = "0"
        Me.Num_Question_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ud_paragraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Name = "ud_paragraph"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(803, 181)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.pnl_note.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.numQuestion_pnl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LaQuestion_lbl As Label
    Friend WithEvents Txt As ud_TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Line As Label
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
    Friend WithEvents numQuestion_pnl As Panel
    Friend WithEvents Num_Question_lbl As Label
End Class
