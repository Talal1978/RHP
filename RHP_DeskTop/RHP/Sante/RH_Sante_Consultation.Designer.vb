<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Consultation
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Num_Consultation_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Dat_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Consultation_txt = New RHP.ud_TextBox()
        Me.Intervenant_Link = New System.Windows.Forms.LinkLabel()
        Me.Cod_Intervenant_txt = New RHP.ud_TextBox()
        Me.Nom_Intervenant_txt = New RHP.ud_TextBox()
        Me.Typ_Acte_lbl = New System.Windows.Forms.Label()
        Me.Typ_Acte_cbo = New RHP.ud_ComboBox()
        Me.Motif_lbl = New System.Windows.Forms.Label()
        Me.Motif_txt = New RHP.ud_TextBox()
        Me.Observations_lbl = New System.Windows.Forms.Label()
        Me.Observations_txt = New RHP.ud_TextBox()
        Me.Suite_lbl = New System.Windows.Forms.Label()
        Me.Suite_cbo = New RHP.ud_ComboBox()
        Me.AT_Link = New System.Windows.Forms.LinkLabel()
        Me.Num_Declaration_AT_txt = New RHP.ud_TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Num_Consultation_txt)
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Dat_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Consultation_txt)
        Me.GroupBox2.Controls.Add(Me.Intervenant_Link)
        Me.GroupBox2.Controls.Add(Me.Cod_Intervenant_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Intervenant_txt)
        Me.GroupBox2.Controls.Add(Me.Typ_Acte_lbl)
        Me.GroupBox2.Controls.Add(Me.Typ_Acte_cbo)
        Me.GroupBox2.Controls.Add(Me.Motif_lbl)
        Me.GroupBox2.Controls.Add(Me.Motif_txt)
        Me.GroupBox2.Controls.Add(Me.Observations_lbl)
        Me.GroupBox2.Controls.Add(Me.Observations_txt)
        Me.GroupBox2.Controls.Add(Me.Suite_lbl)
        Me.GroupBox2.Controls.Add(Me.Suite_cbo)
        Me.GroupBox2.Controls.Add(Me.AT_Link)
        Me.GroupBox2.Controls.Add(Me.Num_Declaration_AT_txt)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 400)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consultation / Soin infirmier"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(80, 45)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(110, 19)
        Me.LinkLabel3.TabIndex = 251
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SN"
        Me.LinkLabel3.Text = "N° Consultation"
        '
        'Num_Consultation_txt
        '
        Me.Num_Consultation_txt.AccessibleDescription = "A"
        Me.Num_Consultation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Consultation_txt.ContextMenuStrip = Nothing
        Me.Num_Consultation_txt.Location = New System.Drawing.Point(220, 43)
        Me.Num_Consultation_txt.Name = "Num_Consultation_txt"
        Me.Num_Consultation_txt.ReadOnly = True
        Me.Num_Consultation_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Consultation_txt.TabIndex = 250
        Me.Num_Consultation_txt.TabStop = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(140, 80)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 252
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        '
        'Matricule_txt
        '
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(220, 78)
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.Size = New System.Drawing.Size(146, 26)
        Me.Matricule_txt.TabIndex = 1
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(374, 78)
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(420, 26)
        Me.Nom_Agent_Text.TabIndex = 2
        '
        'Dat_Link
        '
        Me.Dat_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Link.AutoSize = True
        Me.Dat_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Link.Location = New System.Drawing.Point(151, 114)
        Me.Dat_Link.Name = "Dat_Link"
        Me.Dat_Link.Size = New System.Drawing.Size(39, 19)
        Me.Dat_Link.TabIndex = 274
        Me.Dat_Link.TabStop = True
        Me.Dat_Link.Tag = "SC"
        Me.Dat_Link.Text = "Date"
        '
        'Dat_Consultation_txt
        '
        Me.Dat_Consultation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Consultation_txt.ContextMenuStrip = Nothing
        Me.Dat_Consultation_txt.Location = New System.Drawing.Point(220, 110)
        Me.Dat_Consultation_txt.Name = "Dat_Consultation_txt"
        Me.Dat_Consultation_txt.ReadOnly = True
        Me.Dat_Consultation_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Consultation_txt.TabIndex = 273
        Me.Dat_Consultation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Intervenant_Link
        '
        Me.Intervenant_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Intervenant_Link.AutoSize = True
        Me.Intervenant_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Intervenant_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Intervenant_Link.Location = New System.Drawing.Point(330, 114)
        Me.Intervenant_Link.Name = "Intervenant_Link"
        Me.Intervenant_Link.Size = New System.Drawing.Size(77, 19)
        Me.Intervenant_Link.TabIndex = 9
        Me.Intervenant_Link.TabStop = True
        Me.Intervenant_Link.Tag = "SC"
        Me.Intervenant_Link.Text = "Intervenant"
        '
        'Cod_Intervenant_txt
        '
        Me.Cod_Intervenant_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Intervenant_txt.ContextMenuStrip = Nothing
        Me.Cod_Intervenant_txt.Location = New System.Drawing.Point(420, 110)
        Me.Cod_Intervenant_txt.Name = "Cod_Intervenant_txt"
        Me.Cod_Intervenant_txt.ReadOnly = True
        Me.Cod_Intervenant_txt.Size = New System.Drawing.Size(100, 26)
        Me.Cod_Intervenant_txt.TabIndex = 10
        '
        'Nom_Intervenant_txt
        '
        Me.Nom_Intervenant_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Intervenant_txt.ContextMenuStrip = Nothing
        Me.Nom_Intervenant_txt.Location = New System.Drawing.Point(530, 110)
        Me.Nom_Intervenant_txt.Name = "Nom_Intervenant_txt"
        Me.Nom_Intervenant_txt.ReadOnly = True
        Me.Nom_Intervenant_txt.Size = New System.Drawing.Size(264, 26)
        Me.Nom_Intervenant_txt.TabIndex = 11
        '
        'Typ_Acte_lbl
        '
        Me.Typ_Acte_lbl.AutoSize = True
        Me.Typ_Acte_lbl.Location = New System.Drawing.Point(155, 148)
        Me.Typ_Acte_lbl.Name = "Typ_Acte_lbl"
        Me.Typ_Acte_lbl.Size = New System.Drawing.Size(35, 19)
        Me.Typ_Acte_lbl.TabIndex = 14
        Me.Typ_Acte_lbl.Text = "Acte"
        '
        'Typ_Acte_cbo
        '
        Me.Typ_Acte_cbo.DataSource = Nothing
        Me.Typ_Acte_cbo.DisplayMember = ""
        Me.Typ_Acte_cbo.DroppedDown = False
        Me.Typ_Acte_cbo.Location = New System.Drawing.Point(220, 144)
        Me.Typ_Acte_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Acte_cbo.Name = "Typ_Acte_cbo"
        Me.Typ_Acte_cbo.SelectedIndex = -1
        Me.Typ_Acte_cbo.SelectedItem = Nothing
        Me.Typ_Acte_cbo.SelectedValue = Nothing
        Me.Typ_Acte_cbo.Size = New System.Drawing.Size(250, 26)
        Me.Typ_Acte_cbo.TabIndex = 15
        Me.Typ_Acte_cbo.ValueMember = ""
        '
        'Motif_lbl
        '
        Me.Motif_lbl.AutoSize = True
        Me.Motif_lbl.Location = New System.Drawing.Point(150, 182)
        Me.Motif_lbl.Name = "Motif_lbl"
        Me.Motif_lbl.Size = New System.Drawing.Size(43, 19)
        Me.Motif_lbl.TabIndex = 16
        Me.Motif_lbl.Text = "Motif"
        '
        'Motif_txt
        '
        Me.Motif_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Motif_txt.ContextMenuStrip = Nothing
        Me.Motif_txt.Location = New System.Drawing.Point(220, 178)
        Me.Motif_txt.Name = "Motif_txt"
        Me.Motif_txt.Size = New System.Drawing.Size(690, 26)
        Me.Motif_txt.TabIndex = 17
        '
        'Observations_lbl
        '
        Me.Observations_lbl.AutoSize = True
        Me.Observations_lbl.Location = New System.Drawing.Point(100, 216)
        Me.Observations_lbl.Name = "Observations_lbl"
        Me.Observations_lbl.Size = New System.Drawing.Size(92, 19)
        Me.Observations_lbl.TabIndex = 18
        Me.Observations_lbl.Text = "Observations"
        '
        'Observations_txt
        '
        Me.Observations_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Observations_txt.ContextMenuStrip = Nothing
        Me.Observations_txt.Location = New System.Drawing.Point(220, 213)
        Me.Observations_txt.Multiline = True
        Me.Observations_txt.Name = "Observations_txt"
        Me.Observations_txt.Size = New System.Drawing.Size(690, 90)
        Me.Observations_txt.TabIndex = 19
        '
        'Suite_lbl
        '
        Me.Suite_lbl.AutoSize = True
        Me.Suite_lbl.Location = New System.Drawing.Point(150, 318)
        Me.Suite_lbl.Name = "Suite_lbl"
        Me.Suite_lbl.Size = New System.Drawing.Size(42, 19)
        Me.Suite_lbl.TabIndex = 20
        Me.Suite_lbl.Text = "Suite"
        '
        'Suite_cbo
        '
        Me.Suite_cbo.DataSource = Nothing
        Me.Suite_cbo.DisplayMember = ""
        Me.Suite_cbo.DroppedDown = False
        Me.Suite_cbo.Location = New System.Drawing.Point(220, 314)
        Me.Suite_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Suite_cbo.Name = "Suite_cbo"
        Me.Suite_cbo.SelectedIndex = -1
        Me.Suite_cbo.SelectedItem = Nothing
        Me.Suite_cbo.SelectedValue = Nothing
        Me.Suite_cbo.Size = New System.Drawing.Size(250, 26)
        Me.Suite_cbo.TabIndex = 21
        Me.Suite_cbo.ValueMember = ""
        '
        'AT_Link
        '
        Me.AT_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AT_Link.AutoSize = True
        Me.AT_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.AT_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AT_Link.Location = New System.Drawing.Point(100, 352)
        Me.AT_Link.Name = "AT_Link"
        Me.AT_Link.Size = New System.Drawing.Size(116, 19)
        Me.AT_Link.TabIndex = 22
        Me.AT_Link.TabStop = True
        Me.AT_Link.Tag = "SC"
        Me.AT_Link.Text = "Déclaration AT liée"
        '
        'Num_Declaration_AT_txt
        '
        Me.Num_Declaration_AT_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Declaration_AT_txt.ContextMenuStrip = Nothing
        Me.Num_Declaration_AT_txt.Location = New System.Drawing.Point(220, 348)
        Me.Num_Declaration_AT_txt.Name = "Num_Declaration_AT_txt"
        Me.Num_Declaration_AT_txt.ReadOnly = True
        Me.Num_Declaration_AT_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Declaration_AT_txt.TabIndex = 23
        '
        'RH_Sante_Consultation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Consultation"
        Me.Tag = "ECR"
        Me.Text = "Consultation / Soin infirmier"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Num_Consultation_txt As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Dat_Link As LinkLabel
    Friend WithEvents Dat_Consultation_txt As ud_TextBox
    Friend WithEvents Intervenant_Link As LinkLabel
    Friend WithEvents Cod_Intervenant_txt As ud_TextBox
    Friend WithEvents Nom_Intervenant_txt As ud_TextBox
    Friend WithEvents Typ_Acte_lbl As Label
    Friend WithEvents Typ_Acte_cbo As ud_ComboBox
    Friend WithEvents Motif_lbl As Label
    Friend WithEvents Motif_txt As ud_TextBox
    Friend WithEvents Observations_lbl As Label
    Friend WithEvents Observations_txt As ud_TextBox
    Friend WithEvents Suite_lbl As Label
    Friend WithEvents Suite_cbo As ud_ComboBox
    Friend WithEvents AT_Link As LinkLabel
    Friend WithEvents Num_Declaration_AT_txt As ud_TextBox
End Class
