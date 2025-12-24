<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Cnss_Damancom_Agence
    Inherits Ecran

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Adresse_txt = New RHP.ud_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lib_Agence_txt = New RHP.ud_TextBox()
        Me.Agence_txt = New RHP.ud_TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Grd = New RHP.ud_Grd()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.Adresse_txt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lib_Agence_txt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Agence_txt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grd)
        Me.SplitContainer1.Size = New System.Drawing.Size(724, 460)
        Me.SplitContainer1.SplitterDistance = 116
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 51
        '
        'Adresse_txt
        '
        Me.Adresse_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Adresse_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Adresse_txt.Location = New System.Drawing.Point(72, 34)
        Me.Adresse_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Adresse_txt.MaxLength = 120
        Me.Adresse_txt.Multiline = True
        Me.Adresse_txt.Name = "Adresse_txt"
        Me.Adresse_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Adresse_txt.ReadOnly = False
        Me.Adresse_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Adresse_txt.SelectionStart = 0
        Me.Adresse_txt.Size = New System.Drawing.Size(641, 59)
        Me.Adresse_txt.TabIndex = 234
        Me.Adresse_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Adresse_txt.UseSystemPasswordChar = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(21, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 233
        Me.Label7.Text = "Adresse"
        '
        'Lib_Agence_txt
        '
        Me.Lib_Agence_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Lib_Agence_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Agence_txt.Location = New System.Drawing.Point(238, 7)
        Me.Lib_Agence_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Agence_txt.MaxLength = 32767
        Me.Lib_Agence_txt.Multiline = False
        Me.Lib_Agence_txt.Name = "Lib_Agence_txt"
        Me.Lib_Agence_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Agence_txt.ReadOnly = False
        Me.Lib_Agence_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Agence_txt.SelectionStart = 0
        Me.Lib_Agence_txt.Size = New System.Drawing.Size(475, 21)
        Me.Lib_Agence_txt.TabIndex = 232
        Me.Lib_Agence_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Agence_txt.UseSystemPasswordChar = False
        '
        'Agence_txt
        '
        Me.Agence_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Agence_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Agence_txt.Location = New System.Drawing.Point(72, 7)
        Me.Agence_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Agence_txt.MaxLength = 2
        Me.Agence_txt.Multiline = False
        Me.Agence_txt.Name = "Agence_txt"
        Me.Agence_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Agence_txt.ReadOnly = False
        Me.Agence_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Agence_txt.SelectionStart = 0
        Me.Agence_txt.Size = New System.Drawing.Size(158, 21)
        Me.Agence_txt.TabIndex = 231
        Me.Agence_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Agence_txt.UseSystemPasswordChar = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(18, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 16)
        Me.Label10.TabIndex = 230
        Me.Label10.Text = "Agence"
        '
        'Grd
        '
        Me.Grd.AllowUserToAddRows = False
        Me.Grd.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.EnableHeadersVisualStyles = False
        Me.Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd.Location = New System.Drawing.Point(0, 0)
        Me.Grd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd.RowHeadersVisible = False
        Me.Grd.Size = New System.Drawing.Size(724, 343)
        Me.Grd.TabIndex = 0
        '
        'Zoom_Cnss_Damancom_Agence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(724, 460)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Zoom_Cnss_Damancom_Agence"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Damancom : Agences CNSS"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Grd As ud_Grd
    Friend WithEvents Lib_Agence_txt As ud_TextBox
    Friend WithEvents Agence_txt As ud_TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Adresse_txt As ud_TextBox
    Friend WithEvents Label7 As Label
End Class
