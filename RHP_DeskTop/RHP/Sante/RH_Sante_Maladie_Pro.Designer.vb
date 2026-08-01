<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Maladie_Pro
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
        Me.Num_MP_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Dat_Declaration_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Declaration_txt = New RHP.ud_TextBox()
        Me.Dat_Constat_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Premier_Constat_txt = New RHP.ud_TextBox()
        Me.Pathologie_lbl = New System.Windows.Forms.Label()
        Me.Pathologie_txt = New RHP.ud_TextBox()
        Me.Tableau_MP_lbl = New System.Windows.Forms.Label()
        Me.Tableau_MP_txt = New RHP.ud_TextBox()
        Me.Organisme_lbl = New System.Windows.Forms.Label()
        Me.Organisme_txt = New RHP.ud_TextBox()
        Me.Num_Dossier_Org_lbl = New System.Windows.Forms.Label()
        Me.Num_Dossier_Org_txt = New RHP.ud_TextBox()
        Me.Statut_Declaration_lbl = New System.Windows.Forms.Label()
        Me.Statut_Declaration_cbo = New RHP.ud_ComboBox()
        Me.Commentaire_lbl = New System.Windows.Forms.Label()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Num_MP_txt)
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Dat_Declaration_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Declaration_txt)
        Me.GroupBox2.Controls.Add(Me.Dat_Constat_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Premier_Constat_txt)
        Me.GroupBox2.Controls.Add(Me.Pathologie_lbl)
        Me.GroupBox2.Controls.Add(Me.Pathologie_txt)
        Me.GroupBox2.Controls.Add(Me.Tableau_MP_lbl)
        Me.GroupBox2.Controls.Add(Me.Tableau_MP_txt)
        Me.GroupBox2.Controls.Add(Me.Organisme_lbl)
        Me.GroupBox2.Controls.Add(Me.Organisme_txt)
        Me.GroupBox2.Controls.Add(Me.Num_Dossier_Org_lbl)
        Me.GroupBox2.Controls.Add(Me.Num_Dossier_Org_txt)
        Me.GroupBox2.Controls.Add(Me.Statut_Declaration_lbl)
        Me.GroupBox2.Controls.Add(Me.Statut_Declaration_cbo)
        Me.GroupBox2.Controls.Add(Me.Commentaire_lbl)
        Me.GroupBox2.Controls.Add(Me.Commentaire_txt)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 390)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Maladie professionnelle"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(140, 45)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(52, 19)
        Me.LinkLabel3.TabIndex = 251
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SN"
        Me.LinkLabel3.Text = "N° MP"
        '
        'Num_MP_txt
        '
        Me.Num_MP_txt.AccessibleDescription = "A"
        Me.Num_MP_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_MP_txt.ContextMenuStrip = Nothing
        Me.Num_MP_txt.Location = New System.Drawing.Point(220, 43)
        Me.Num_MP_txt.Name = "Num_MP_txt"
        Me.Num_MP_txt.ReadOnly = True
        Me.Num_MP_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_MP_txt.TabIndex = 250
        Me.Num_MP_txt.TabStop = False
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
        'Dat_Declaration_Link
        '
        Me.Dat_Declaration_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Declaration_Link.AutoSize = True
        Me.Dat_Declaration_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Declaration_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Declaration_Link.Location = New System.Drawing.Point(110, 114)
        Me.Dat_Declaration_Link.Name = "Dat_Declaration_Link"
        Me.Dat_Declaration_Link.Size = New System.Drawing.Size(80, 19)
        Me.Dat_Declaration_Link.TabIndex = 274
        Me.Dat_Declaration_Link.TabStop = True
        Me.Dat_Declaration_Link.Tag = "SC"
        Me.Dat_Declaration_Link.Text = "Déclarée le"
        '
        'Dat_Declaration_txt
        '
        Me.Dat_Declaration_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Declaration_txt.ContextMenuStrip = Nothing
        Me.Dat_Declaration_txt.Location = New System.Drawing.Point(220, 110)
        Me.Dat_Declaration_txt.Name = "Dat_Declaration_txt"
        Me.Dat_Declaration_txt.ReadOnly = True
        Me.Dat_Declaration_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Declaration_txt.TabIndex = 273
        Me.Dat_Declaration_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Dat_Constat_Link
        '
        Me.Dat_Constat_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Constat_Link.AutoSize = True
        Me.Dat_Constat_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Constat_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Constat_Link.Location = New System.Drawing.Point(330, 114)
        Me.Dat_Constat_Link.Name = "Dat_Constat_Link"
        Me.Dat_Constat_Link.Size = New System.Drawing.Size(101, 19)
        Me.Dat_Constat_Link.TabIndex = 275
        Me.Dat_Constat_Link.TabStop = True
        Me.Dat_Constat_Link.Tag = "SC"
        Me.Dat_Constat_Link.Text = "1er constat le"
        '
        'Dat_Premier_Constat_txt
        '
        Me.Dat_Premier_Constat_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Premier_Constat_txt.ContextMenuStrip = Nothing
        Me.Dat_Premier_Constat_txt.Location = New System.Drawing.Point(440, 110)
        Me.Dat_Premier_Constat_txt.Name = "Dat_Premier_Constat_txt"
        Me.Dat_Premier_Constat_txt.ReadOnly = True
        Me.Dat_Premier_Constat_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Premier_Constat_txt.TabIndex = 276
        Me.Dat_Premier_Constat_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Pathologie_lbl
        '
        Me.Pathologie_lbl.AutoSize = True
        Me.Pathologie_lbl.Location = New System.Drawing.Point(115, 148)
        Me.Pathologie_lbl.Name = "Pathologie_lbl"
        Me.Pathologie_lbl.Size = New System.Drawing.Size(75, 19)
        Me.Pathologie_lbl.TabIndex = 14
        Me.Pathologie_lbl.Text = "Pathologie"
        '
        'Pathologie_txt
        '
        Me.Pathologie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Pathologie_txt.ContextMenuStrip = Nothing
        Me.Pathologie_txt.Location = New System.Drawing.Point(220, 144)
        Me.Pathologie_txt.Name = "Pathologie_txt"
        Me.Pathologie_txt.Size = New System.Drawing.Size(690, 26)
        Me.Pathologie_txt.TabIndex = 15
        '
        'Tableau_MP_lbl
        '
        Me.Tableau_MP_lbl.AutoSize = True
        Me.Tableau_MP_lbl.Location = New System.Drawing.Point(60, 182)
        Me.Tableau_MP_lbl.Name = "Tableau_MP_lbl"
        Me.Tableau_MP_lbl.Size = New System.Drawing.Size(156, 19)
        Me.Tableau_MP_lbl.TabIndex = 16
        Me.Tableau_MP_lbl.Text = "Tableau (référence légale)"
        '
        'Tableau_MP_txt
        '
        Me.Tableau_MP_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Tableau_MP_txt.ContextMenuStrip = Nothing
        Me.Tableau_MP_txt.Location = New System.Drawing.Point(220, 178)
        Me.Tableau_MP_txt.Name = "Tableau_MP_txt"
        Me.Tableau_MP_txt.Size = New System.Drawing.Size(250, 26)
        Me.Tableau_MP_txt.TabIndex = 17
        '
        'Organisme_lbl
        '
        Me.Organisme_lbl.AutoSize = True
        Me.Organisme_lbl.Location = New System.Drawing.Point(115, 216)
        Me.Organisme_lbl.Name = "Organisme_lbl"
        Me.Organisme_lbl.Size = New System.Drawing.Size(75, 19)
        Me.Organisme_lbl.TabIndex = 18
        Me.Organisme_lbl.Text = "Organisme"
        '
        'Organisme_txt
        '
        Me.Organisme_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Organisme_txt.ContextMenuStrip = Nothing
        Me.Organisme_txt.Location = New System.Drawing.Point(220, 213)
        Me.Organisme_txt.Name = "Organisme_txt"
        Me.Organisme_txt.Size = New System.Drawing.Size(400, 26)
        Me.Organisme_txt.TabIndex = 19
        '
        'Num_Dossier_Org_lbl
        '
        Me.Num_Dossier_Org_lbl.AutoSize = True
        Me.Num_Dossier_Org_lbl.Location = New System.Drawing.Point(80, 250)
        Me.Num_Dossier_Org_lbl.Name = "Num_Dossier_Org_lbl"
        Me.Num_Dossier_Org_lbl.Size = New System.Drawing.Size(136, 19)
        Me.Num_Dossier_Org_lbl.TabIndex = 20
        Me.Num_Dossier_Org_lbl.Text = "N° dossier organisme"
        '
        'Num_Dossier_Org_txt
        '
        Me.Num_Dossier_Org_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Dossier_Org_txt.ContextMenuStrip = Nothing
        Me.Num_Dossier_Org_txt.Location = New System.Drawing.Point(220, 247)
        Me.Num_Dossier_Org_txt.Name = "Num_Dossier_Org_txt"
        Me.Num_Dossier_Org_txt.Size = New System.Drawing.Size(250, 26)
        Me.Num_Dossier_Org_txt.TabIndex = 21
        '
        'Statut_Declaration_lbl
        '
        Me.Statut_Declaration_lbl.AutoSize = True
        Me.Statut_Declaration_lbl.Location = New System.Drawing.Point(90, 284)
        Me.Statut_Declaration_lbl.Name = "Statut_Declaration_lbl"
        Me.Statut_Declaration_lbl.Size = New System.Drawing.Size(126, 19)
        Me.Statut_Declaration_lbl.TabIndex = 22
        Me.Statut_Declaration_lbl.Text = "Statut déclaration"
        '
        'Statut_Declaration_cbo
        '
        Me.Statut_Declaration_cbo.DataSource = Nothing
        Me.Statut_Declaration_cbo.DisplayMember = ""
        Me.Statut_Declaration_cbo.DroppedDown = False
        Me.Statut_Declaration_cbo.Location = New System.Drawing.Point(220, 281)
        Me.Statut_Declaration_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Statut_Declaration_cbo.Name = "Statut_Declaration_cbo"
        Me.Statut_Declaration_cbo.SelectedIndex = -1
        Me.Statut_Declaration_cbo.SelectedItem = Nothing
        Me.Statut_Declaration_cbo.SelectedValue = Nothing
        Me.Statut_Declaration_cbo.Size = New System.Drawing.Size(250, 26)
        Me.Statut_Declaration_cbo.TabIndex = 23
        Me.Statut_Declaration_cbo.ValueMember = ""
        '
        'Commentaire_lbl
        '
        Me.Commentaire_lbl.AutoSize = True
        Me.Commentaire_lbl.Location = New System.Drawing.Point(90, 318)
        Me.Commentaire_lbl.Name = "Commentaire_lbl"
        Me.Commentaire_lbl.Size = New System.Drawing.Size(104, 19)
        Me.Commentaire_lbl.TabIndex = 24
        Me.Commentaire_lbl.Text = "Commentaire"
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.ContextMenuStrip = Nothing
        Me.Commentaire_txt.Location = New System.Drawing.Point(220, 314)
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Size = New System.Drawing.Size(690, 26)
        Me.Commentaire_txt.TabIndex = 25
        '
        'RH_Sante_Maladie_Pro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Maladie_Pro"
        Me.Tag = "ECR"
        Me.Text = "Maladie professionnelle"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Num_MP_txt As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Dat_Declaration_Link As LinkLabel
    Friend WithEvents Dat_Declaration_txt As ud_TextBox
    Friend WithEvents Dat_Constat_Link As LinkLabel
    Friend WithEvents Dat_Premier_Constat_txt As ud_TextBox
    Friend WithEvents Pathologie_lbl As Label
    Friend WithEvents Pathologie_txt As ud_TextBox
    Friend WithEvents Tableau_MP_lbl As Label
    Friend WithEvents Tableau_MP_txt As ud_TextBox
    Friend WithEvents Organisme_lbl As Label
    Friend WithEvents Organisme_txt As ud_TextBox
    Friend WithEvents Num_Dossier_Org_lbl As Label
    Friend WithEvents Num_Dossier_Org_txt As ud_TextBox
    Friend WithEvents Statut_Declaration_lbl As Label
    Friend WithEvents Statut_Declaration_cbo As ud_ComboBox
    Friend WithEvents Commentaire_lbl As Label
    Friend WithEvents Commentaire_txt As ud_TextBox
End Class
