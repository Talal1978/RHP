<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Consultation_Liste
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
        Me.ClearTyp = New System.Windows.Forms.LinkLabel()
        Me.Typ_Acte_cbo = New RHP.ud_ComboBox()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Fin = New RHP.ud_TextBox()
        Me.Dat_Debut = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Code_Client_Facture = New System.Windows.Forms.LinkLabel()
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
        Me.Ges_Pie_Clt_GRD.Location = New System.Drawing.Point(0, 158)
        Me.Ges_Pie_Clt_GRD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Ges_Pie_Clt_GRD.Name = "Ges_Pie_Clt_GRD"
        Me.Ges_Pie_Clt_GRD.ReadOnly = True
        Me.Ges_Pie_Clt_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ges_Pie_Clt_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Ges_Pie_Clt_GRD.RowHeadersWidth = 51
        Me.Ges_Pie_Clt_GRD.Size = New System.Drawing.Size(1520, 626)
        Me.Ges_Pie_Clt_GRD.TabIndex = 2
        '
        'SEL_CRT_GROUP
        '
        Me.SEL_CRT_GROUP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SEL_CRT_GROUP.Controls.Add(Me.ClearTyp)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Typ_Acte_cbo)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Matricule_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Lib_Entite_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Nom_Agent_Text)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Matricule_)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel6)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel4)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Fin)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Debut)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Cod_Entite_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Code_Client_Facture)
        Me.SEL_CRT_GROUP.Dock = System.Windows.Forms.DockStyle.Top
        Me.SEL_CRT_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.SEL_CRT_GROUP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SEL_CRT_GROUP.Name = "SEL_CRT_GROUP"
        Me.SEL_CRT_GROUP.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SEL_CRT_GROUP.Size = New System.Drawing.Size(1520, 158)
        Me.SEL_CRT_GROUP.TabIndex = 0
        Me.SEL_CRT_GROUP.TabStop = False
        Me.SEL_CRT_GROUP.Tag = ""
        Me.SEL_CRT_GROUP.Text = "Critères de sélection"
        '
        'ClearTyp
        '
        Me.ClearTyp.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClearTyp.AutoSize = True
        Me.ClearTyp.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClearTyp.Location = New System.Drawing.Point(63, 79)
        Me.ClearTyp.Name = "ClearTyp"
        Me.ClearTyp.Size = New System.Drawing.Size(35, 19)
        Me.ClearTyp.TabIndex = 227
        Me.ClearTyp.TabStop = True
        Me.ClearTyp.Text = "Acte"
        '
        'Typ_Acte_cbo
        '
        Me.Typ_Acte_cbo.DataSource = Nothing
        Me.Typ_Acte_cbo.DisplayMember = ""
        Me.Typ_Acte_cbo.DroppedDown = False
        Me.Typ_Acte_cbo.Location = New System.Drawing.Point(117, 75)
        Me.Typ_Acte_cbo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Typ_Acte_cbo.Name = "Typ_Acte_cbo"
        Me.Typ_Acte_cbo.SelectedIndex = -1
        Me.Typ_Acte_cbo.SelectedItem = Nothing
        Me.Typ_Acte_cbo.SelectedValue = Nothing
        Me.Typ_Acte_cbo.Size = New System.Drawing.Size(170, 26)
        Me.Typ_Acte_cbo.TabIndex = 228
        Me.Typ_Acte_cbo.ValueMember = ""
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(117, 40)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(121, 26)
        Me.Matricule_txt.TabIndex = 224
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.AccessibleDescription = "A"
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(568, 74)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Entite_txt.MaxLength = 32767
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(415, 26)
        Me.Lib_Entite_txt.TabIndex = 226
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(240, 40)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(744, 26)
        Me.Nom_Agent_Text.TabIndex = 226
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(40, 43)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 225
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.Location = New System.Drawing.Point(366, 110)
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
        Me.LinkLabel4.Location = New System.Drawing.Point(86, 113)
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
        Me.Dat_Fin.Location = New System.Drawing.Point(392, 107)
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
        Me.Dat_Debut.Location = New System.Drawing.Point(117, 109)
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
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(392, 74)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Entite_txt.MaxLength = 32767
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(170, 26)
        Me.Cod_Entite_txt.TabIndex = 200
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Code_Client_Facture
        '
        Me.Code_Client_Facture.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Code_Client_Facture.AutoSize = True
        Me.Code_Client_Facture.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Code_Client_Facture.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Code_Client_Facture.Location = New System.Drawing.Point(340, 76)
        Me.Code_Client_Facture.Name = "Code_Client_Facture"
        Me.Code_Client_Facture.Size = New System.Drawing.Size(48, 19)
        Me.Code_Client_Facture.TabIndex = 0
        Me.Code_Client_Facture.TabStop = True
        Me.Code_Client_Facture.Tag = ""
        Me.Code_Client_Facture.Text = "Entité"
        '
        'RH_Sante_Consultation_Liste
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
        Me.Name = "RH_Sante_Consultation_Liste"
        Me.Tag = "ECR"
        Me.Text = "Infirmerie — consultations et soins"
        CType(Me.Ges_Pie_Clt_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SEL_CRT_GROUP.ResumeLayout(False)
        Me.SEL_CRT_GROUP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ges_Pie_Clt_GRD As ud_Grd
    Friend WithEvents SEL_CRT_GROUP As GroupBox
    Friend WithEvents ClearTyp As LinkLabel
    Friend WithEvents Typ_Acte_cbo As ud_ComboBox
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Dat_Fin As ud_TextBox
    Friend WithEvents Dat_Debut As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Code_Client_Facture As LinkLabel
End Class
