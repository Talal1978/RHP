<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ctb_Plan_Ana
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grd = New RHP.ud_Grd()
        Me.Lib_Axe_txt = New RHP.ud_TextBox()
        Me.Cod_Axe_txt = New RHP.ud_TextBox()
        Me.CompteGeneralLink = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grd
        '
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
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(56,36,36)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.EnableHeadersVisualStyles = False
        Me.Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd.Location = New System.Drawing.Point(0, 42)
        Me.Grd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd.Size = New System.Drawing.Size(876, 507)
        Me.Grd.TabIndex = 3
        '
        'Lib_Axe_txt
        '
        Me.Lib_Axe_txt.AccessibleDescription = "A"
        Me.Lib_Axe_txt.BackColor = System.Drawing.SystemColors.Window
        Me.Lib_Axe_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Axe_txt.Location = New System.Drawing.Point(274, 7)
        Me.Lib_Axe_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Axe_txt.MaxLength = 100
        Me.Lib_Axe_txt.Multiline = False
        Me.Lib_Axe_txt.Name = "Lib_Axe_txt"
        Me.Lib_Axe_txt.ReadOnly = False
        Me.Lib_Axe_txt.Size = New System.Drawing.Size(476, 21)
        Me.Lib_Axe_txt.TabIndex = 2
        Me.Lib_Axe_txt.Tag = "NC"
        Me.Lib_Axe_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Cod_Axe_txt
        '
        Me.Cod_Axe_txt.AccessibleDescription = ""
        Me.Cod_Axe_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Cod_Axe_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Axe_txt.Location = New System.Drawing.Point(98, 7)
        Me.Cod_Axe_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Axe_txt.MaxLength = 32767
        Me.Cod_Axe_txt.Multiline = False
        Me.Cod_Axe_txt.Name = "Cod_Axe_txt"
        Me.Cod_Axe_txt.ReadOnly = True
        Me.Cod_Axe_txt.Size = New System.Drawing.Size(172, 21)
        Me.Cod_Axe_txt.TabIndex = 1
        Me.Cod_Axe_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'CompteGeneralLink
        '
        Me.CompteGeneralLink.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.AutoSize = True
        Me.CompteGeneralLink.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.Location = New System.Drawing.Point(5, 9)
        Me.CompteGeneralLink.Name = "CompteGeneralLink"
        Me.CompteGeneralLink.Size = New System.Drawing.Size(90, 16)
        Me.CompteGeneralLink.TabIndex = 0
        Me.CompteGeneralLink.TabStop = True
        Me.CompteGeneralLink.Tag = ""
        Me.CompteGeneralLink.Text = "Axe analytique"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Lib_Axe_txt)
        Me.Panel1.Controls.Add(Me.CompteGeneralLink)
        Me.Panel1.Controls.Add(Me.Cod_Axe_txt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(876, 42)
        Me.Panel1.TabIndex = 4
        '
        'Ctb_Plan_Ana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(876, 549)
        Me.Controls.Add(Me.Grd)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Ctb_Plan_Ana"
        Me.Tag = "ECR"
        Me.Text = "Analytique"
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grd As ud_Grd
    Friend WithEvents Lib_Axe_txt As ud_TextBox
    Friend WithEvents Cod_Axe_txt As ud_TextBox
    Friend WithEvents CompteGeneralLink As LinkLabel
    Friend WithEvents Panel1 As Panel
End Class
