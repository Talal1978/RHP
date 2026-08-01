<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Audit
    Inherits Ecran

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Ges_Pie_Clt_GRD = New RHP.ud_Grd()
        Me.SEL_CRT_GROUP = New System.Windows.Forms.GroupBox()
        Me.Login_lbl = New System.Windows.Forms.Label()
        Me.Login_txt = New RHP.ud_TextBox()
        Me.Login_Link = New System.Windows.Forms.LinkLabel()
        Me.Action_lbl = New System.Windows.Forms.Label()
        Me.Action_cbo = New System.Windows.Forms.ComboBox()
        Me.Objet_lbl = New System.Windows.Forms.Label()
        Me.Objet_txt = New RHP.ud_TextBox()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Fin = New RHP.ud_TextBox()
        Me.Dat_Debut = New RHP.ud_TextBox()
        CType(Me.Ges_Pie_Clt_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SEL_CRT_GROUP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ges_Pie_Clt_GRD
        '
        Me.Ges_Pie_Clt_GRD.AfficherLesEntetesLignes = True
        Me.Ges_Pie_Clt_GRD.AllowUserToAddRows = False
        Me.Ges_Pie_Clt_GRD.AllowUserToOrderColumns = True
        Me.Ges_Pie_Clt_GRD.AlternerLesLignes = False
        Me.Ges_Pie_Clt_GRD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Ges_Pie_Clt_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Ges_Pie_Clt_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ges_Pie_Clt_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Ges_Pie_Clt_GRD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Ges_Pie_Clt_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Ges_Pie_Clt_GRD.DefaultCellStyle = DataGridViewCellStyle2
        Me.Ges_Pie_Clt_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ges_Pie_Clt_GRD.EnableHeadersVisualStyles = False
        Me.Ges_Pie_Clt_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Ges_Pie_Clt_GRD.Location = New System.Drawing.Point(0, 120)
        Me.Ges_Pie_Clt_GRD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Ges_Pie_Clt_GRD.Name = "Ges_Pie_Clt_GRD"
        Me.Ges_Pie_Clt_GRD.ReadOnly = True
        Me.Ges_Pie_Clt_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ges_Pie_Clt_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Ges_Pie_Clt_GRD.RowHeadersWidth = 51
        Me.Ges_Pie_Clt_GRD.Size = New System.Drawing.Size(1520, 664)
        Me.Ges_Pie_Clt_GRD.TabIndex = 2
        '
        'SEL_CRT_GROUP
        '
        Me.SEL_CRT_GROUP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SEL_CRT_GROUP.Controls.Add(Me.Login_lbl)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Login_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Login_Link)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Action_lbl)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Action_cbo)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Objet_lbl)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Objet_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel6)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel4)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Fin)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Debut)
        Me.SEL_CRT_GROUP.Dock = System.Windows.Forms.DockStyle.Top
        Me.SEL_CRT_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.SEL_CRT_GROUP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SEL_CRT_GROUP.Name = "SEL_CRT_GROUP"
        Me.SEL_CRT_GROUP.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SEL_CRT_GROUP.Size = New System.Drawing.Size(1520, 120)
        Me.SEL_CRT_GROUP.TabIndex = 0
        Me.SEL_CRT_GROUP.TabStop = False
        Me.SEL_CRT_GROUP.Tag = ""
        Me.SEL_CRT_GROUP.Text = "Journal des accès aux données de santé (append-only)"
        '
        'Login_lbl
        '
        Me.Login_lbl.AutoSize = True
        Me.Login_lbl.Location = New System.Drawing.Point(30, 45)
        Me.Login_lbl.Name = "Login_lbl"
        Me.Login_lbl.Size = New System.Drawing.Size(69, 19)
        Me.Login_lbl.TabIndex = 0
        Me.Login_lbl.Text = "Utilisateur"
        '
        'Login_txt
        '
        Me.Login_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Login_txt.ContextMenuStrip = Nothing
        Me.Login_txt.Location = New System.Drawing.Point(105, 43)
        Me.Login_txt.Name = "Login_txt"
        Me.Login_txt.Size = New System.Drawing.Size(150, 26)
        Me.Login_txt.TabIndex = 1
        '
        'Login_Link
        '
        Me.Login_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Login_Link.AutoSize = True
        Me.Login_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Login_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Login_Link.Location = New System.Drawing.Point(265, 45)
        Me.Login_Link.Name = "Login_Link"
        Me.Login_Link.Size = New System.Drawing.Size(71, 19)
        Me.Login_Link.TabIndex = 2
        Me.Login_Link.TabStop = True
        Me.Login_Link.Tag = ""
        Me.Login_Link.Text = "Interroger"
        '
        'Action_lbl
        '
        Me.Action_lbl.AutoSize = True
        Me.Action_lbl.Location = New System.Drawing.Point(360, 45)
        Me.Action_lbl.Name = "Action_lbl"
        Me.Action_lbl.Size = New System.Drawing.Size(49, 19)
        Me.Action_lbl.TabIndex = 3
        Me.Action_lbl.Text = "Action"
        '
        'Action_cbo
        '
        Me.Action_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Action_cbo.Location = New System.Drawing.Point(415, 42)
        Me.Action_cbo.Name = "Action_cbo"
        Me.Action_cbo.Size = New System.Drawing.Size(120, 27)
        Me.Action_cbo.TabIndex = 4
        '
        'Objet_lbl
        '
        Me.Objet_lbl.AutoSize = True
        Me.Objet_lbl.Location = New System.Drawing.Point(560, 45)
        Me.Objet_lbl.Name = "Objet_lbl"
        Me.Objet_lbl.Size = New System.Drawing.Size(43, 19)
        Me.Objet_lbl.TabIndex = 5
        Me.Objet_lbl.Text = "Objet"
        '
        'Objet_txt
        '
        Me.Objet_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Objet_txt.ContextMenuStrip = Nothing
        Me.Objet_txt.Location = New System.Drawing.Point(610, 43)
        Me.Objet_txt.Name = "Objet_txt"
        Me.Objet_txt.Size = New System.Drawing.Size(180, 26)
        Me.Objet_txt.TabIndex = 6
        '
        'LinkLabel6
        '
        Me.LinkLabel6.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.Location = New System.Drawing.Point(1080, 45)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(27, 19)
        Me.LinkLabel6.TabIndex = 8
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Tag = ""
        Me.LinkLabel6.Text = "Au"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(900, 45)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(28, 19)
        Me.LinkLabel4.TabIndex = 4
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = ""
        Me.LinkLabel4.Text = "Du"
        '
        'Dat_Fin
        '
        Me.Dat_Fin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Fin.ContextMenuStrip = Nothing
        Me.Dat_Fin.Location = New System.Drawing.Point(1115, 42)
        Me.Dat_Fin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dat_Fin.MaxLength = 32767
        Me.Dat_Fin.Multiline = False
        Me.Dat_Fin.Name = "Dat_Fin"
        Me.Dat_Fin.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Fin.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Fin.ReadOnly = True
        Me.Dat_Fin.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Fin.SelectionStart = 0
        Me.Dat_Fin.Size = New System.Drawing.Size(121, 26)
        Me.Dat_Fin.TabIndex = 200
        Me.Dat_Fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Fin.UseSystemPasswordChar = False
        '
        'Dat_Debut
        '
        Me.Dat_Debut.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Debut.ContextMenuStrip = Nothing
        Me.Dat_Debut.Location = New System.Drawing.Point(940, 42)
        Me.Dat_Debut.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dat_Debut.MaxLength = 32767
        Me.Dat_Debut.Multiline = False
        Me.Dat_Debut.Name = "Dat_Debut"
        Me.Dat_Debut.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Debut.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Debut.ReadOnly = True
        Me.Dat_Debut.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Debut.SelectionStart = 0
        Me.Dat_Debut.Size = New System.Drawing.Size(121, 26)
        Me.Dat_Debut.TabIndex = 200
        Me.Dat_Debut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Debut.UseSystemPasswordChar = False
        '
        'RH_Sante_Audit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1520, 784)
        Me.Controls.Add(Me.Ges_Pie_Clt_GRD)
        Me.Controls.Add(Me.SEL_CRT_GROUP)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "RH_Sante_Audit"
        Me.Tag = "ECR"
        Me.Text = "Audit des accès aux données de santé"
        CType(Me.Ges_Pie_Clt_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SEL_CRT_GROUP.ResumeLayout(False)
        Me.SEL_CRT_GROUP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ges_Pie_Clt_GRD As ud_Grd
    Friend WithEvents SEL_CRT_GROUP As GroupBox
    Friend WithEvents Login_lbl As Label
    Friend WithEvents Login_txt As ud_TextBox
    Friend WithEvents Login_Link As LinkLabel
    Friend WithEvents Action_lbl As Label
    Friend WithEvents Action_cbo As ComboBox
    Friend WithEvents Objet_lbl As Label
    Friend WithEvents Objet_txt As ud_TextBox
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Dat_Fin As ud_TextBox
    Friend WithEvents Dat_Debut As ud_TextBox
End Class
