<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Dossier_Maladie_Liste
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Ges_Pie_Clt_GRD = New RHP.ud_Grd()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Code_Client_Facture = New System.Windows.Forms.LinkLabel()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Dat_Debut = New RHP.ud_TextBox()
        Me.Dat_Fin = New RHP.ud_TextBox()
        Me.Statut_Avance = New RHP.ud_ComboBox()
        Me.LinkLabel15 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel12 = New System.Windows.Forms.LinkLabel()
        Me.SEL_CRT_GROUP = New System.Windows.Forms.GroupBox()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
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
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Ges_Pie_Clt_GRD.DefaultCellStyle = DataGridViewCellStyle2
        Me.Ges_Pie_Clt_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ges_Pie_Clt_GRD.EnableHeadersVisualStyles = False
        Me.Ges_Pie_Clt_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Ges_Pie_Clt_GRD.Location = New System.Drawing.Point(0, 140)
        Me.Ges_Pie_Clt_GRD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Ges_Pie_Clt_GRD.Name = "Ges_Pie_Clt_GRD"
        Me.Ges_Pie_Clt_GRD.ReadOnly = True
        Me.Ges_Pie_Clt_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ges_Pie_Clt_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Ges_Pie_Clt_GRD.RowHeadersWidth = 51
        Me.Ges_Pie_Clt_GRD.Size = New System.Drawing.Size(1520, 840)
        Me.Ges_Pie_Clt_GRD.TabIndex = 2
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX1.Location = New System.Drawing.Point(16, 38)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(67, 23)
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.Text = "OK"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Location = New System.Drawing.Point(36, 3)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(28, 8)
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "Annuler"
        '
        'Code_Client_Facture
        '
        Me.Code_Client_Facture.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Code_Client_Facture.AutoSize = True
        Me.Code_Client_Facture.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Code_Client_Facture.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Code_Client_Facture.Location = New System.Drawing.Point(263, 60)
        Me.Code_Client_Facture.Name = "Code_Client_Facture"
        Me.Code_Client_Facture.Size = New System.Drawing.Size(48, 19)
        Me.Code_Client_Facture.TabIndex = 0
        Me.Code_Client_Facture.TabStop = True
        Me.Code_Client_Facture.Tag = ""
        Me.Code_Client_Facture.Text = "Entité"
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(316, 58)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
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
        'Dat_Debut
        '
        Me.Dat_Debut.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Debut.ContextMenuStrip = Nothing
        Me.Dat_Debut.Location = New System.Drawing.Point(84, 94)
        Me.Dat_Debut.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Dat_Debut.MaxLength = 32767
        Me.Dat_Debut.Multiline = False
        Me.Dat_Debut.Name = "Dat_Debut"
        Me.Dat_Debut.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Debut.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Debut.ReadOnly = True
        Me.Dat_Debut.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Debut.SelectionStart = 0
        Me.Dat_Debut.Size = New System.Drawing.Size(170, 26)
        Me.Dat_Debut.TabIndex = 200
        Me.Dat_Debut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Debut.UseSystemPasswordChar = False
        '
        'Dat_Fin
        '
        Me.Dat_Fin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Fin.ContextMenuStrip = Nothing
        Me.Dat_Fin.Location = New System.Drawing.Point(316, 91)
        Me.Dat_Fin.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Dat_Fin.MaxLength = 32767
        Me.Dat_Fin.Multiline = False
        Me.Dat_Fin.Name = "Dat_Fin"
        Me.Dat_Fin.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Fin.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Fin.ReadOnly = True
        Me.Dat_Fin.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Fin.SelectionStart = 0
        Me.Dat_Fin.Size = New System.Drawing.Size(170, 26)
        Me.Dat_Fin.TabIndex = 200
        Me.Dat_Fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Fin.UseSystemPasswordChar = False
        '
        'Statut_Avance
        '
        Me.Statut_Avance.DataSource = Nothing
        Me.Statut_Avance.DisplayMember = ""
        Me.Statut_Avance.DroppedDown = False
        Me.Statut_Avance.Location = New System.Drawing.Point(84, 59)
        Me.Statut_Avance.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Statut_Avance.Name = "Statut_Avance"
        Me.Statut_Avance.SelectedIndex = -1
        Me.Statut_Avance.SelectedItem = Nothing
        Me.Statut_Avance.SelectedValue = Nothing
        Me.Statut_Avance.Size = New System.Drawing.Size(170, 30)
        Me.Statut_Avance.TabIndex = 16
        Me.Statut_Avance.ValueMember = ""
        '
        'LinkLabel15
        '
        Me.LinkLabel15.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel15.AutoSize = True
        Me.LinkLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel15.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel15.Location = New System.Drawing.Point(24, 62)
        Me.LinkLabel15.Name = "LinkLabel15"
        Me.LinkLabel15.Size = New System.Drawing.Size(50, 19)
        Me.LinkLabel15.TabIndex = 9
        Me.LinkLabel15.TabStop = True
        Me.LinkLabel15.Tag = ""
        Me.LinkLabel15.Text = "Statut"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(42, 96)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(28, 19)
        Me.LinkLabel4.TabIndex = 4
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = ""
        Me.LinkLabel4.Text = "Du"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.Location = New System.Drawing.Point(279, 95)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(27, 19)
        Me.LinkLabel6.TabIndex = 8
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Tag = ""
        Me.LinkLabel6.Text = "Au"
        '
        'LinkLabel12
        '
        Me.LinkLabel12.AutoSize = True
        Me.LinkLabel12.Location = New System.Drawing.Point(1125, 254)
        Me.LinkLabel12.Name = "LinkLabel12"
        Me.LinkLabel12.Size = New System.Drawing.Size(85, 19)
        Me.LinkLabel12.TabIndex = 28
        Me.LinkLabel12.TabStop = True
        Me.LinkLabel12.Tag = "Validé par:"
        Me.LinkLabel12.Text = "Validé par:"
        '
        'SEL_CRT_GROUP
        '
        Me.SEL_CRT_GROUP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SEL_CRT_GROUP.Controls.Add(Me.Matricule_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Lib_Entite_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Nom_Agent_Text)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Matricule_)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel12)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel6)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel4)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel15)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Statut_Avance)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Fin)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Debut)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Cod_Entite_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Code_Client_Facture)
        Me.SEL_CRT_GROUP.Dock = System.Windows.Forms.DockStyle.Top
        Me.SEL_CRT_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.SEL_CRT_GROUP.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SEL_CRT_GROUP.Name = "SEL_CRT_GROUP"
        Me.SEL_CRT_GROUP.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SEL_CRT_GROUP.Size = New System.Drawing.Size(1520, 140)
        Me.SEL_CRT_GROUP.TabIndex = 0
        Me.SEL_CRT_GROUP.TabStop = False
        Me.SEL_CRT_GROUP.Tag = ""
        Me.SEL_CRT_GROUP.Text = "Critères de sélection"
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(84, 22)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
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
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(492, 58)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Lib_Entite_txt.MaxLength = 32767
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(404, 26)
        Me.Lib_Entite_txt.TabIndex = 226
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(207, 22)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(689, 26)
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
        Me.Matricule_.Location = New System.Drawing.Point(6, 25)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 225
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        '
        'RH_Dossier_Maladie_Liste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1520, 980)
        Me.Controls.Add(Me.Ges_Pie_Clt_GRD)
        Me.Controls.Add(Me.SEL_CRT_GROUP)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "RH_Dossier_Maladie_Liste"
        Me.Tag = "ECR"
        Me.Text = "Liste des demandes de remboursement des dossiers de maladie"
        CType(Me.Ges_Pie_Clt_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SEL_CRT_GROUP.ResumeLayout(False)
        Me.SEL_CRT_GROUP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Ges_Pie_Clt_GRD As ud_Grd
    Friend WithEvents Code_Client_Facture As LinkLabel
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Dat_Debut As ud_TextBox
    Friend WithEvents Dat_Fin As ud_TextBox
    Friend WithEvents Statut_Avance As ud_ComboBox
    Friend WithEvents LinkLabel15 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents LinkLabel12 As LinkLabel
    Friend WithEvents SEL_CRT_GROUP As GroupBox
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Lib_Entite_txt As ud_TextBox
End Class
