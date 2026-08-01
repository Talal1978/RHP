<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Examen
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
        Me.Num_Examen_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Typ_Examen_lbl = New System.Windows.Forms.Label()
        Me.Typ_Examen_cbo = New RHP.ud_ComboBox()
        Me.Dat_Prescription_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Prescription_txt = New RHP.ud_TextBox()
        Me.Dat_Examen_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Examen_txt = New RHP.ud_TextBox()
        Me.Prescripteur_Link = New System.Windows.Forms.LinkLabel()
        Me.Cod_Medecin_Prescripteur_txt = New RHP.ud_TextBox()
        Me.Prestataire_Link = New System.Windows.Forms.LinkLabel()
        Me.Cod_Prestataire_txt = New RHP.ud_TextBox()
        Me.Motif_lbl = New System.Windows.Forms.Label()
        Me.Motif_txt = New RHP.ud_TextBox()
        Me.Statut_Examen_lbl = New System.Windows.Forms.Label()
        Me.Statut_Examen_cbo = New RHP.ud_ComboBox()
        Me.Dat_Resultat_Link = New System.Windows.Forms.LinkLabel()
        Me.Dat_Resultat_txt = New RHP.ud_TextBox()
        Me.Resultat_Resume_lbl = New System.Windows.Forms.Label()
        Me.Resultat_Resume_txt = New RHP.ud_TextBox()
        Me.Visibilite_lbl = New System.Windows.Forms.Label()
        Me.Visibilite_cbo = New RHP.ud_ComboBox()
        Me.FD_lbl = New System.Windows.Forms.Label()
        Me.FD_txt = New RHP.ud_TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Num_Examen_txt)
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Typ_Examen_lbl)
        Me.GroupBox2.Controls.Add(Me.Typ_Examen_cbo)
        Me.GroupBox2.Controls.Add(Me.Dat_Prescription_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Prescription_txt)
        Me.GroupBox2.Controls.Add(Me.Dat_Examen_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Examen_txt)
        Me.GroupBox2.Controls.Add(Me.Prescripteur_Link)
        Me.GroupBox2.Controls.Add(Me.Cod_Medecin_Prescripteur_txt)
        Me.GroupBox2.Controls.Add(Me.Prestataire_Link)
        Me.GroupBox2.Controls.Add(Me.Cod_Prestataire_txt)
        Me.GroupBox2.Controls.Add(Me.Motif_lbl)
        Me.GroupBox2.Controls.Add(Me.Motif_txt)
        Me.GroupBox2.Controls.Add(Me.Statut_Examen_lbl)
        Me.GroupBox2.Controls.Add(Me.Statut_Examen_cbo)
        Me.GroupBox2.Controls.Add(Me.Dat_Resultat_Link)
        Me.GroupBox2.Controls.Add(Me.Dat_Resultat_txt)
        Me.GroupBox2.Controls.Add(Me.Resultat_Resume_lbl)
        Me.GroupBox2.Controls.Add(Me.Resultat_Resume_txt)
        Me.GroupBox2.Controls.Add(Me.Visibilite_lbl)
        Me.GroupBox2.Controls.Add(Me.Visibilite_cbo)
        Me.GroupBox2.Controls.Add(Me.FD_lbl)
        Me.GroupBox2.Controls.Add(Me.FD_txt)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 460)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Examen complémentaire"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(105, 45)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(80, 19)
        Me.LinkLabel3.TabIndex = 251
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SN"
        Me.LinkLabel3.Text = "N° Examen"
        '
        'Num_Examen_txt
        '
        Me.Num_Examen_txt.AccessibleDescription = "A"
        Me.Num_Examen_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Examen_txt.ContextMenuStrip = Nothing
        Me.Num_Examen_txt.Location = New System.Drawing.Point(220, 43)
        Me.Num_Examen_txt.Name = "Num_Examen_txt"
        Me.Num_Examen_txt.ReadOnly = True
        Me.Num_Examen_txt.Size = New System.Drawing.Size(146, 26)
        Me.Num_Examen_txt.TabIndex = 250
        Me.Num_Examen_txt.TabStop = False
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
        'Typ_Examen_lbl
        '
        Me.Typ_Examen_lbl.AutoSize = True
        Me.Typ_Examen_lbl.Location = New System.Drawing.Point(130, 114)
        Me.Typ_Examen_lbl.Name = "Typ_Examen_lbl"
        Me.Typ_Examen_lbl.Size = New System.Drawing.Size(56, 19)
        Me.Typ_Examen_lbl.TabIndex = 14
        Me.Typ_Examen_lbl.Text = "Examen"
        '
        'Typ_Examen_cbo
        '
        Me.Typ_Examen_cbo.DataSource = Nothing
        Me.Typ_Examen_cbo.DisplayMember = ""
        Me.Typ_Examen_cbo.DroppedDown = False
        Me.Typ_Examen_cbo.Location = New System.Drawing.Point(220, 110)
        Me.Typ_Examen_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Examen_cbo.Name = "Typ_Examen_cbo"
        Me.Typ_Examen_cbo.SelectedIndex = -1
        Me.Typ_Examen_cbo.SelectedItem = Nothing
        Me.Typ_Examen_cbo.SelectedValue = Nothing
        Me.Typ_Examen_cbo.Size = New System.Drawing.Size(250, 26)
        Me.Typ_Examen_cbo.TabIndex = 15
        Me.Typ_Examen_cbo.ValueMember = ""
        '
        'Dat_Prescription_Link
        '
        Me.Dat_Prescription_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Prescription_Link.AutoSize = True
        Me.Dat_Prescription_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Prescription_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Prescription_Link.Location = New System.Drawing.Point(105, 148)
        Me.Dat_Prescription_Link.Name = "Dat_Prescription_Link"
        Me.Dat_Prescription_Link.Size = New System.Drawing.Size(85, 19)
        Me.Dat_Prescription_Link.TabIndex = 274
        Me.Dat_Prescription_Link.TabStop = True
        Me.Dat_Prescription_Link.Tag = "SC"
        Me.Dat_Prescription_Link.Text = "Prescrit le"
        '
        'Dat_Prescription_txt
        '
        Me.Dat_Prescription_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Prescription_txt.ContextMenuStrip = Nothing
        Me.Dat_Prescription_txt.Location = New System.Drawing.Point(220, 144)
        Me.Dat_Prescription_txt.Name = "Dat_Prescription_txt"
        Me.Dat_Prescription_txt.ReadOnly = True
        Me.Dat_Prescription_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Prescription_txt.TabIndex = 273
        Me.Dat_Prescription_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Dat_Examen_Link
        '
        Me.Dat_Examen_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Examen_Link.AutoSize = True
        Me.Dat_Examen_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Examen_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Examen_Link.Location = New System.Drawing.Point(340, 148)
        Me.Dat_Examen_Link.Name = "Dat_Examen_Link"
        Me.Dat_Examen_Link.Size = New System.Drawing.Size(65, 19)
        Me.Dat_Examen_Link.TabIndex = 275
        Me.Dat_Examen_Link.TabStop = True
        Me.Dat_Examen_Link.Tag = "SC"
        Me.Dat_Examen_Link.Text = "Réalisé le"
        '
        'Dat_Examen_txt
        '
        Me.Dat_Examen_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Examen_txt.ContextMenuStrip = Nothing
        Me.Dat_Examen_txt.Location = New System.Drawing.Point(420, 144)
        Me.Dat_Examen_txt.Name = "Dat_Examen_txt"
        Me.Dat_Examen_txt.ReadOnly = True
        Me.Dat_Examen_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Examen_txt.TabIndex = 276
        Me.Dat_Examen_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Prescripteur_Link
        '
        Me.Prescripteur_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Prescripteur_Link.AutoSize = True
        Me.Prescripteur_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Prescripteur_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Prescripteur_Link.Location = New System.Drawing.Point(105, 182)
        Me.Prescripteur_Link.Name = "Prescripteur_Link"
        Me.Prescripteur_Link.Size = New System.Drawing.Size(81, 19)
        Me.Prescripteur_Link.TabIndex = 9
        Me.Prescripteur_Link.TabStop = True
        Me.Prescripteur_Link.Tag = "SC"
        Me.Prescripteur_Link.Text = "Prescripteur"
        '
        'Cod_Medecin_Prescripteur_txt
        '
        Me.Cod_Medecin_Prescripteur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Medecin_Prescripteur_txt.ContextMenuStrip = Nothing
        Me.Cod_Medecin_Prescripteur_txt.Location = New System.Drawing.Point(220, 178)
        Me.Cod_Medecin_Prescripteur_txt.Name = "Cod_Medecin_Prescripteur_txt"
        Me.Cod_Medecin_Prescripteur_txt.ReadOnly = True
        Me.Cod_Medecin_Prescripteur_txt.Size = New System.Drawing.Size(100, 26)
        Me.Cod_Medecin_Prescripteur_txt.TabIndex = 10
        '
        'Prestataire_Link
        '
        Me.Prestataire_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Prestataire_Link.AutoSize = True
        Me.Prestataire_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Prestataire_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Prestataire_Link.Location = New System.Drawing.Point(340, 182)
        Me.Prestataire_Link.Name = "Prestataire_Link"
        Me.Prestataire_Link.Size = New System.Drawing.Size(72, 19)
        Me.Prestataire_Link.TabIndex = 11
        Me.Prestataire_Link.TabStop = True
        Me.Prestataire_Link.Tag = "SC"
        Me.Prestataire_Link.Text = "Prestataire"
        '
        'Cod_Prestataire_txt
        '
        Me.Cod_Prestataire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Prestataire_txt.ContextMenuStrip = Nothing
        Me.Cod_Prestataire_txt.Location = New System.Drawing.Point(420, 178)
        Me.Cod_Prestataire_txt.Name = "Cod_Prestataire_txt"
        Me.Cod_Prestataire_txt.ReadOnly = True
        Me.Cod_Prestataire_txt.Size = New System.Drawing.Size(100, 26)
        Me.Cod_Prestataire_txt.TabIndex = 12
        '
        'Motif_lbl
        '
        Me.Motif_lbl.AutoSize = True
        Me.Motif_lbl.Location = New System.Drawing.Point(150, 216)
        Me.Motif_lbl.Name = "Motif_lbl"
        Me.Motif_lbl.Size = New System.Drawing.Size(43, 19)
        Me.Motif_lbl.TabIndex = 16
        Me.Motif_lbl.Text = "Motif"
        '
        'Motif_txt
        '
        Me.Motif_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Motif_txt.ContextMenuStrip = Nothing
        Me.Motif_txt.Location = New System.Drawing.Point(220, 213)
        Me.Motif_txt.Name = "Motif_txt"
        Me.Motif_txt.Size = New System.Drawing.Size(690, 26)
        Me.Motif_txt.TabIndex = 17
        '
        'Statut_Examen_lbl
        '
        Me.Statut_Examen_lbl.AutoSize = True
        Me.Statut_Examen_lbl.Location = New System.Drawing.Point(135, 250)
        Me.Statut_Examen_lbl.Name = "Statut_Examen_lbl"
        Me.Statut_Examen_lbl.Size = New System.Drawing.Size(50, 19)
        Me.Statut_Examen_lbl.TabIndex = 18
        Me.Statut_Examen_lbl.Text = "Statut"
        '
        'Statut_Examen_cbo
        '
        Me.Statut_Examen_cbo.DataSource = Nothing
        Me.Statut_Examen_cbo.DisplayMember = ""
        Me.Statut_Examen_cbo.DroppedDown = False
        Me.Statut_Examen_cbo.Location = New System.Drawing.Point(220, 247)
        Me.Statut_Examen_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Statut_Examen_cbo.Name = "Statut_Examen_cbo"
        Me.Statut_Examen_cbo.SelectedIndex = -1
        Me.Statut_Examen_cbo.SelectedItem = Nothing
        Me.Statut_Examen_cbo.SelectedValue = Nothing
        Me.Statut_Examen_cbo.Size = New System.Drawing.Size(250, 26)
        Me.Statut_Examen_cbo.TabIndex = 19
        Me.Statut_Examen_cbo.ValueMember = ""
        '
        'Dat_Resultat_Link
        '
        Me.Dat_Resultat_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Resultat_Link.AutoSize = True
        Me.Dat_Resultat_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Resultat_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Resultat_Link.Location = New System.Drawing.Point(490, 250)
        Me.Dat_Resultat_Link.Name = "Dat_Resultat_Link"
        Me.Dat_Resultat_Link.Size = New System.Drawing.Size(75, 19)
        Me.Dat_Resultat_Link.TabIndex = 20
        Me.Dat_Resultat_Link.TabStop = True
        Me.Dat_Resultat_Link.Tag = "SC"
        Me.Dat_Resultat_Link.Text = "Résultat le"
        '
        'Dat_Resultat_txt
        '
        Me.Dat_Resultat_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Resultat_txt.ContextMenuStrip = Nothing
        Me.Dat_Resultat_txt.Location = New System.Drawing.Point(570, 247)
        Me.Dat_Resultat_txt.Name = "Dat_Resultat_txt"
        Me.Dat_Resultat_txt.ReadOnly = True
        Me.Dat_Resultat_txt.Size = New System.Drawing.Size(92, 26)
        Me.Dat_Resultat_txt.TabIndex = 21
        Me.Dat_Resultat_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Resultat_Resume_lbl
        '
        Me.Resultat_Resume_lbl.AutoSize = True
        Me.Resultat_Resume_lbl.Location = New System.Drawing.Point(80, 284)
        Me.Resultat_Resume_lbl.Name = "Resultat_Resume_lbl"
        Me.Resultat_Resume_lbl.Size = New System.Drawing.Size(136, 19)
        Me.Resultat_Resume_lbl.TabIndex = 22
        Me.Resultat_Resume_lbl.Text = "Résumé du résultat"
        '
        'Resultat_Resume_txt
        '
        Me.Resultat_Resume_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Resultat_Resume_txt.ContextMenuStrip = Nothing
        Me.Resultat_Resume_txt.Location = New System.Drawing.Point(220, 281)
        Me.Resultat_Resume_txt.Multiline = True
        Me.Resultat_Resume_txt.Name = "Resultat_Resume_txt"
        Me.Resultat_Resume_txt.Size = New System.Drawing.Size(690, 90)
        Me.Resultat_Resume_txt.TabIndex = 23
        '
        'Visibilite_lbl
        '
        Me.Visibilite_lbl.AutoSize = True
        Me.Visibilite_lbl.Location = New System.Drawing.Point(80, 388)
        Me.Visibilite_lbl.Name = "Visibilite_lbl"
        Me.Visibilite_lbl.Size = New System.Drawing.Size(136, 19)
        Me.Visibilite_lbl.TabIndex = 24
        Me.Visibilite_lbl.Text = "Visibilité du résultat"
        '
        'Visibilite_cbo
        '
        Me.Visibilite_cbo.DataSource = Nothing
        Me.Visibilite_cbo.DisplayMember = ""
        Me.Visibilite_cbo.DroppedDown = False
        Me.Visibilite_cbo.Location = New System.Drawing.Point(220, 384)
        Me.Visibilite_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Visibilite_cbo.Name = "Visibilite_cbo"
        Me.Visibilite_cbo.SelectedIndex = -1
        Me.Visibilite_cbo.SelectedItem = Nothing
        Me.Visibilite_cbo.SelectedValue = Nothing
        Me.Visibilite_cbo.Size = New System.Drawing.Size(300, 26)
        Me.Visibilite_cbo.TabIndex = 25
        Me.Visibilite_cbo.ValueMember = ""
        '
        'FD_lbl
        '
        Me.FD_lbl.AutoSize = True
        Me.FD_lbl.Location = New System.Drawing.Point(80, 422)
        Me.FD_lbl.Name = "FD_lbl"
        Me.FD_lbl.Size = New System.Drawing.Size(131, 19)
        Me.FD_lbl.TabIndex = 26
        Me.FD_lbl.Text = "Pièce (résultat scan)"
        '
        'FD_txt
        '
        Me.FD_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.FD_txt.ContextMenuStrip = Nothing
        Me.FD_txt.Location = New System.Drawing.Point(220, 418)
        Me.FD_txt.Name = "FD_txt"
        Me.FD_txt.ReadOnly = True
        Me.FD_txt.Size = New System.Drawing.Size(300, 26)
        Me.FD_txt.TabIndex = 27
        '
        'RH_Sante_Examen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Examen"
        Me.Tag = "ECR"
        Me.Text = "Examen complémentaire"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Num_Examen_txt As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Typ_Examen_lbl As Label
    Friend WithEvents Typ_Examen_cbo As ud_ComboBox
    Friend WithEvents Dat_Prescription_Link As LinkLabel
    Friend WithEvents Dat_Prescription_txt As ud_TextBox
    Friend WithEvents Dat_Examen_Link As LinkLabel
    Friend WithEvents Dat_Examen_txt As ud_TextBox
    Friend WithEvents Prescripteur_Link As LinkLabel
    Friend WithEvents Cod_Medecin_Prescripteur_txt As ud_TextBox
    Friend WithEvents Prestataire_Link As LinkLabel
    Friend WithEvents Cod_Prestataire_txt As ud_TextBox
    Friend WithEvents Motif_lbl As Label
    Friend WithEvents Motif_txt As ud_TextBox
    Friend WithEvents Statut_Examen_lbl As Label
    Friend WithEvents Statut_Examen_cbo As ud_ComboBox
    Friend WithEvents Dat_Resultat_Link As LinkLabel
    Friend WithEvents Dat_Resultat_txt As ud_TextBox
    Friend WithEvents Resultat_Resume_lbl As Label
    Friend WithEvents Resultat_Resume_txt As ud_TextBox
    Friend WithEvents Visibilite_lbl As Label
    Friend WithEvents Visibilite_cbo As ud_ComboBox
    Friend WithEvents FD_lbl As Label
    Friend WithEvents FD_txt As ud_TextBox
End Class
