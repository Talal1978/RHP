<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_grille_libre
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grd = New System.Windows.Forms.DataGridView()
        Me.laquestion_lbl = New System.Windows.Forms.Label()
        Me.tblPnl = New System.Windows.Forms.TableLayoutPanel()
        Me.numQuestion_pnl = New System.Windows.Forms.Panel()
        Me.Num_Question_lbl = New System.Windows.Forms.Label()
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
        Me.Line = New System.Windows.Forms.Label()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblPnl.SuspendLayout()
        Me.numQuestion_pnl.SuspendLayout()
        Me.pnl_note.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grd
        '
        Me.Grd.AllowUserToAddRows = False
        Me.Grd.AllowUserToDeleteRows = False
        Me.Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Grd.BackgroundColor = System.Drawing.Color.White
        Me.Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.Grd.Location = New System.Drawing.Point(73, 63)
        Me.Grd.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Grd.Name = "Grd"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd.RowHeadersVisible = False
        Me.Grd.RowHeadersWidth = 51
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Grd.Size = New System.Drawing.Size(523, 57)
        Me.Grd.TabIndex = 0
        '
        'laquestion_lbl
        '
        Me.laquestion_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laquestion_lbl.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laquestion_lbl.Location = New System.Drawing.Point(73, 0)
        Me.laquestion_lbl.Margin = New System.Windows.Forms.Padding(20, 0, 3, 0)
        Me.laquestion_lbl.Name = "laquestion_lbl"
        Me.laquestion_lbl.Size = New System.Drawing.Size(523, 60)
        Me.laquestion_lbl.TabIndex = 0
        Me.laquestion_lbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tblPnl
        '
        Me.tblPnl.AutoSize = True
        Me.tblPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tblPnl.BackColor = System.Drawing.Color.White
        Me.tblPnl.ColumnCount = 3
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.tblPnl.Controls.Add(Me.numQuestion_pnl, 0, 0)
        Me.tblPnl.Controls.Add(Me.pnl_note, 2, 0)
        Me.tblPnl.Controls.Add(Me.laquestion_lbl, 1, 0)
        Me.tblPnl.Controls.Add(Me.Grd, 1, 1)
        Me.tblPnl.Controls.Add(Me.Line, 0, 2)
        Me.tblPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPnl.Location = New System.Drawing.Point(2, 2)
        Me.tblPnl.Name = "tblPnl"
        Me.tblPnl.RowCount = 3
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblPnl.Size = New System.Drawing.Size(799, 131)
        Me.tblPnl.TabIndex = 10
        '
        'numQuestion_pnl
        '
        Me.numQuestion_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.numQuestion_pnl.Controls.Add(Me.Num_Question_lbl)
        Me.numQuestion_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numQuestion_pnl.Location = New System.Drawing.Point(3, 3)
        Me.numQuestion_pnl.Name = "numQuestion_pnl"
        Me.numQuestion_pnl.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.tblPnl.SetRowSpan(Me.numQuestion_pnl, 2)
        Me.numQuestion_pnl.Size = New System.Drawing.Size(47, 117)
        Me.numQuestion_pnl.TabIndex = 10
        '
        'Num_Question_lbl
        '
        Me.Num_Question_lbl.BackColor = System.Drawing.Color.White
        Me.Num_Question_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Num_Question_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Num_Question_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Num_Question_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Num_Question_lbl.Name = "Num_Question_lbl"
        Me.Num_Question_lbl.Size = New System.Drawing.Size(45, 117)
        Me.Num_Question_lbl.TabIndex = 0
        Me.Num_Question_lbl.Text = "0"
        Me.Num_Question_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnl_note
        '
        Me.pnl_note.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
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
        Me.tblPnl.SetRowSpan(Me.pnl_note, 2)
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.45055!))
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.54945!))
        Me.pnl_note.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.pnl_note.Size = New System.Drawing.Size(194, 111)
        Me.pnl_note.TabIndex = 2
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
        'Line
        '
        Me.Line.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.tblPnl.SetColumnSpan(Me.Line, 3)
        Me.Line.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Line.Location = New System.Drawing.Point(10, 130)
        Me.Line.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Line.Name = "Line"
        Me.Line.Size = New System.Drawing.Size(779, 1)
        Me.Line.TabIndex = 0
        '
        'ud_grille_libre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.tblPnl)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.MinimumSize = New System.Drawing.Size(0, 135)
        Me.Name = "ud_grille_libre"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(803, 135)
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblPnl.ResumeLayout(False)
        Me.tblPnl.PerformLayout()
        Me.numQuestion_pnl.ResumeLayout(False)
        Me.pnl_note.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents laquestion_lbl As Label
    Friend WithEvents tblPnl As TableLayoutPanel
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
    Public WithEvents Grd As DataGridView
End Class
