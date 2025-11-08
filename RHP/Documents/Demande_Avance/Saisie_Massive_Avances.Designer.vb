<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Saisie_Massive_Avances
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EntPnl = New System.Windows.Forms.Panel()
        Me.Dat_Avance = New System.Windows.Forms.DateTimePicker()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Lib_List_Avance_txt = New RHP.ud_TextBox()
        Me.Num_List_Avance_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Grd_Avance = New RHP.ud_Grd()
        Me.EntPnl.SuspendLayout()
        CType(Me.Grd_Avance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntPnl
        '
        Me.EntPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.EntPnl.Controls.Add(Me.Dat_Avance)
        Me.EntPnl.Controls.Add(Me.LinkLabel4)
        Me.EntPnl.Controls.Add(Me.Label2)
        Me.EntPnl.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.EntPnl.Controls.Add(Me.Lib_List_Avance_txt)
        Me.EntPnl.Controls.Add(Me.Num_List_Avance_txt)
        Me.EntPnl.Controls.Add(Me.LinkLabel3)
        Me.EntPnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.EntPnl.Location = New System.Drawing.Point(0, 0)
        Me.EntPnl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EntPnl.Name = "EntPnl"
        Me.EntPnl.Size = New System.Drawing.Size(941, 121)
        Me.EntPnl.TabIndex = 210
        '
        'Dat_Avance
        '
        Me.Dat_Avance.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dat_Avance.Location = New System.Drawing.Point(145, 76)
        Me.Dat_Avance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dat_Avance.Name = "Dat_Avance"
        Me.Dat_Avance.Size = New System.Drawing.Size(146, 24)
        Me.Dat_Avance.TabIndex = 248
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4.Location = New System.Drawing.Point(96, 53)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(39, 19)
        Me.LinkLabel4.TabIndex = 250
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Plan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 19)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "Date avance"
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(145, 51)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Plan_Paie_Text.MaxLength = 50
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(146, 21)
        Me.Cod_Plan_Paie_Text.TabIndex = 247
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Lib_List_Avance_txt
        '
        Me.Lib_List_Avance_txt.AccessibleDescription = "A"
        Me.Lib_List_Avance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_List_Avance_txt.ContextMenuStrip = Nothing
        Me.Lib_List_Avance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_List_Avance_txt.Location = New System.Drawing.Point(295, 25)
        Me.Lib_List_Avance_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Lib_List_Avance_txt.MaxLength = 150
        Me.Lib_List_Avance_txt.Multiline = False
        Me.Lib_List_Avance_txt.Name = "Lib_List_Avance_txt"
        Me.Lib_List_Avance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_List_Avance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_List_Avance_txt.ReadOnly = False
        Me.Lib_List_Avance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_List_Avance_txt.SelectionStart = 0
        Me.Lib_List_Avance_txt.Size = New System.Drawing.Size(466, 21)
        Me.Lib_List_Avance_txt.TabIndex = 236
        Me.Lib_List_Avance_txt.TabStop = False
        Me.Lib_List_Avance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_List_Avance_txt.UseSystemPasswordChar = False
        '
        'Num_List_Avance_txt
        '
        Me.Num_List_Avance_txt.AccessibleDescription = "A"
        Me.Num_List_Avance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_List_Avance_txt.ContextMenuStrip = Nothing
        Me.Num_List_Avance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_List_Avance_txt.Location = New System.Drawing.Point(145, 25)
        Me.Num_List_Avance_txt.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Num_List_Avance_txt.MaxLength = 32767
        Me.Num_List_Avance_txt.Multiline = False
        Me.Num_List_Avance_txt.Name = "Num_List_Avance_txt"
        Me.Num_List_Avance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_List_Avance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_List_Avance_txt.ReadOnly = True
        Me.Num_List_Avance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_List_Avance_txt.SelectionStart = 0
        Me.Num_List_Avance_txt.Size = New System.Drawing.Size(146, 21)
        Me.Num_List_Avance_txt.TabIndex = 234
        Me.Num_List_Avance_txt.TabStop = False
        Me.Num_List_Avance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_List_Avance_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(72, 27)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(63, 19)
        Me.LinkLabel3.TabIndex = 235
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = ""
        Me.LinkLabel3.Text = "Avance"
        '
        'Grd_Avance
        '
        Me.Grd_Avance.AfficherLesEntetesLignes = True
        Me.Grd_Avance.AllowUserToAddRows = False
        Me.Grd_Avance.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd_Avance.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Avance.AlternerLesLignes = False
        Me.Grd_Avance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Avance.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Avance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd_Avance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Avance.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Avance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Avance.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Avance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Avance.EnableHeadersVisualStyles = False
        Me.Grd_Avance.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Avance.Location = New System.Drawing.Point(0, 121)
        Me.Grd_Avance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grd_Avance.Name = "Grd_Avance"
        Me.Grd_Avance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Avance.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Avance.RowHeadersWidth = 51
        Me.Grd_Avance.Size = New System.Drawing.Size(941, 555)
        Me.Grd_Avance.TabIndex = 211
        '
        'Saisie_Massive_Avances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(941, 676)
        Me.Controls.Add(Me.Grd_Avance)
        Me.Controls.Add(Me.EntPnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Saisie_Massive_Avances"
        Me.Tag = "ECR"
        Me.Text = "Saisie massive des avances"
        Me.EntPnl.ResumeLayout(False)
        Me.EntPnl.PerformLayout()
        CType(Me.Grd_Avance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EntPnl As Panel
    Friend WithEvents Grd_Avance As ud_Grd
    Friend WithEvents Num_List_Avance_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Lib_List_Avance_txt As ud_TextBox
    Friend WithEvents Dat_Avance As DateTimePicker
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
End Class
