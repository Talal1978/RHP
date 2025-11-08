<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RH_Conge_Provision
    inherits Ecran

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EntPnl = New System.Windows.Forms.Panel()
        Me.Num_ProvConge_txt = New RHP.ud_TextBox()
        Me.Num_CongeProv_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Plan_Paie_txt = New RHP.ud_TextBox()
        Me.Cod_Plan_Paie_txt = New RHP.ud_TextBox()
        Me.Plan_Paie_ = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Periode_txt = New RHP.ud_TextBox()
        Me.Cloture_Check = New RHP.ud_CheckBox()
        Me.Grd_Conge = New RHP.ud_Grd()
        Me.EntPnl.SuspendLayout()
        CType(Me.Grd_Conge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntPnl
        '
        Me.EntPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.EntPnl.Controls.Add(Me.Num_ProvConge_txt)
        Me.EntPnl.Controls.Add(Me.Num_CongeProv_)
        Me.EntPnl.Controls.Add(Me.Lib_Plan_Paie_txt)
        Me.EntPnl.Controls.Add(Me.Cod_Plan_Paie_txt)
        Me.EntPnl.Controls.Add(Me.Plan_Paie_)
        Me.EntPnl.Controls.Add(Me.LinkLabel1)
        Me.EntPnl.Controls.Add(Me.Dat_Periode_txt)
        Me.EntPnl.Controls.Add(Me.Cloture_Check)
        Me.EntPnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.EntPnl.Location = New System.Drawing.Point(0, 0)
        Me.EntPnl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EntPnl.Name = "EntPnl"
        Me.EntPnl.Size = New System.Drawing.Size(932, 49)
        Me.EntPnl.TabIndex = 210
        '
        'Num_ProvConge_txt
        '
        Me.Num_ProvConge_txt.AccessibleDescription = "A"
        Me.Num_ProvConge_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Num_ProvConge_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_ProvConge_txt.Location = New System.Drawing.Point(125, 13)
        Me.Num_ProvConge_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Num_ProvConge_txt.MaxLength = 32767
        Me.Num_ProvConge_txt.Multiline = False
        Me.Num_ProvConge_txt.Name = "Num_ProvConge_txt"
        Me.Num_ProvConge_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_ProvConge_txt.ReadOnly = True
        Me.Num_ProvConge_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_ProvConge_txt.SelectionStart = 0
        Me.Num_ProvConge_txt.Size = New System.Drawing.Size(88, 21)
        Me.Num_ProvConge_txt.TabIndex = 207
        Me.Num_ProvConge_txt.TabStop = False
        Me.Num_ProvConge_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_ProvConge_txt.UseSystemPasswordChar = False
        '
        'Num_CongeProv_
        '
        Me.Num_CongeProv_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Num_CongeProv_.AutoSize = True
        Me.Num_CongeProv_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Num_CongeProv_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Num_CongeProv_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Num_CongeProv_.Location = New System.Drawing.Point(50, 15)
        Me.Num_CongeProv_.Name = "Num_CongeProv_"
        Me.Num_CongeProv_.Size = New System.Drawing.Size(71, 16)
        Me.Num_CongeProv_.TabIndex = 206
        Me.Num_CongeProv_.TabStop = True
        Me.Num_CongeProv_.Tag = ""
        Me.Num_CongeProv_.Text = "N° provision"
        '
        'Lib_Plan_Paie_txt
        '
        Me.Lib_Plan_Paie_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Lib_Plan_Paie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_txt.Location = New System.Drawing.Point(502, 13)
        Me.Lib_Plan_Paie_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Plan_Paie_txt.MaxLength = 50
        Me.Lib_Plan_Paie_txt.Multiline = False
        Me.Lib_Plan_Paie_txt.Name = "Lib_Plan_Paie_txt"
        Me.Lib_Plan_Paie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_txt.ReadOnly = True
        Me.Lib_Plan_Paie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_txt.SelectionStart = 0
        Me.Lib_Plan_Paie_txt.Size = New System.Drawing.Size(243, 21)
        Me.Lib_Plan_Paie_txt.TabIndex = 219
        Me.Lib_Plan_Paie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_txt.UseSystemPasswordChar = False
        '
        'Cod_Plan_Paie_txt
        '
        Me.Cod_Plan_Paie_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Cod_Plan_Paie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_txt.Location = New System.Drawing.Point(409, 13)
        Me.Cod_Plan_Paie_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Plan_Paie_txt.MaxLength = 50
        Me.Cod_Plan_Paie_txt.Multiline = False
        Me.Cod_Plan_Paie_txt.Name = "Cod_Plan_Paie_txt"
        Me.Cod_Plan_Paie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_txt.ReadOnly = True
        Me.Cod_Plan_Paie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_txt.SelectionStart = 0
        Me.Cod_Plan_Paie_txt.Size = New System.Drawing.Size(89, 21)
        Me.Cod_Plan_Paie_txt.TabIndex = 220
        Me.Cod_Plan_Paie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_txt.UseSystemPasswordChar = False
        '
        'Plan_Paie_
        '
        Me.Plan_Paie_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Plan_Paie_.AutoSize = True
        Me.Plan_Paie_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Plan_Paie_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Plan_Paie_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Plan_Paie_.Location = New System.Drawing.Point(373, 16)
        Me.Plan_Paie_.Name = "Plan_Paie_"
        Me.Plan_Paie_.Size = New System.Drawing.Size(32, 16)
        Me.Plan_Paie_.TabIndex = 218
        Me.Plan_Paie_.TabStop = True
        Me.Plan_Paie_.Tag = "NC"
        Me.Plan_Paie_.Text = "Plan"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(223, 16)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(28, 16)
        Me.LinkLabel1.TabIndex = 233
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "NC"
        Me.LinkLabel1.Text = "Au :"
        '
        'Dat_Periode_txt
        '
        Me.Dat_Periode_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Dat_Periode_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Periode_txt.Location = New System.Drawing.Point(255, 13)
        Me.Dat_Periode_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dat_Periode_txt.MaxLength = 50
        Me.Dat_Periode_txt.Multiline = False
        Me.Dat_Periode_txt.Name = "Dat_Periode_txt"
        Me.Dat_Periode_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Periode_txt.ReadOnly = True
        Me.Dat_Periode_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Periode_txt.SelectionStart = 0
        Me.Dat_Periode_txt.Size = New System.Drawing.Size(89, 21)
        Me.Dat_Periode_txt.TabIndex = 232
        Me.Dat_Periode_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Periode_txt.UseSystemPasswordChar = False
        '
        'Cloture_Check
        '
        Me.Cloture_Check.AutoSize = True
        Me.Cloture_Check.Checked = True
        Me.Cloture_Check.Enabled = False
        Me.Cloture_Check.Location = New System.Drawing.Point(753, 10)
        Me.Cloture_Check.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cloture_Check.MaximumSize = New System.Drawing.Size(0, 20)
        Me.Cloture_Check.MinimumSize = New System.Drawing.Size(100, 20)
        Me.Cloture_Check.Name = "Cloture_Check"
        Me.Cloture_Check.Size = New System.Drawing.Size(100, 20)
        Me.Cloture_Check.TabIndex = 228
        Me.Cloture_Check.Text = "Clôturée"
        '
        'Grd_Conge
        '
        Me.Grd_Conge.AllowUserToAddRows = False
        Me.Grd_Conge.AllowUserToDeleteRows = False
        Me.Grd_Conge.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd_Conge.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Conge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Conge.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Conge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd_Conge.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Conge.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Conge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Conge.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Conge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Conge.EnableHeadersVisualStyles = False
        Me.Grd_Conge.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Conge.Location = New System.Drawing.Point(0, 49)
        Me.Grd_Conge.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grd_Conge.Name = "Grd_Conge"
        Me.Grd_Conge.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Conge.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Conge.Size = New System.Drawing.Size(932, 469)
        Me.Grd_Conge.TabIndex = 211
        '
        'RH_Conge_Provision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(932, 518)
        Me.Controls.Add(Me.Grd_Conge)
        Me.Controls.Add(Me.EntPnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "RH_Conge_Provision"
        Me.Tag = "ECR"
        Me.Text = "Provision pour congés à payer"
        Me.EntPnl.ResumeLayout(False)
        Me.EntPnl.PerformLayout()
        CType(Me.Grd_Conge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EntPnl As Panel
    Friend WithEvents Num_ProvConge_txt As ud_TextBox
    Friend WithEvents Num_CongeProv_ As LinkLabel
    Friend WithEvents Lib_Plan_Paie_txt As ud_TextBox
    Friend WithEvents Cod_Plan_Paie_txt As ud_TextBox
    Friend WithEvents Plan_Paie_ As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Dat_Periode_txt As ud_TextBox
    Friend WithEvents Cloture_Check As ud_CheckBox
    Friend WithEvents Grd_Conge As ud_Grd
End Class
