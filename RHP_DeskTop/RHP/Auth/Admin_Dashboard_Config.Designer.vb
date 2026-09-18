<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin_Dashboard_Config
    Inherits Ecran

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Info_Config_lbl = New System.Windows.Forms.Label()
        Me.Nom_Source_txt = New RHP.ud_TextBox()
        Me.Matricule_Source_txt = New RHP.ud_TextBox()
        Me.Agent_lbl = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Modele_cmb = New RHP.ud_ComboBox()
        Me.Modele_lbl = New System.Windows.Forms.Label()
        Me.Ecraser_chk = New System.Windows.Forms.CheckBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Entite_lbl = New System.Windows.Forms.LinkLabel()
        Me.Grd = New RHP.ud_Grd()
        Me.Appliquer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Matricule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom_Agent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prenom_Agent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Entite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Profile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Config_Existante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Info_Config_lbl)
        Me.GroupBox2.Controls.Add(Me.Nom_Source_txt)
        Me.GroupBox2.Controls.Add(Me.Matricule_Source_txt)
        Me.GroupBox2.Controls.Add(Me.Agent_lbl)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1000, 78)
        Me.GroupBox2.TabIndex = 218
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuration source"
        '
        'Info_Config_lbl
        '
        Me.Info_Config_lbl.ForeColor = System.Drawing.Color.Gray
        Me.Info_Config_lbl.Location = New System.Drawing.Point(10, 50)
        Me.Info_Config_lbl.Name = "Info_Config_lbl"
        Me.Info_Config_lbl.Size = New System.Drawing.Size(980, 20)
        Me.Info_Config_lbl.TabIndex = 205
        Me.Info_Config_lbl.Text = "Sélectionnez l'agent dont vous souhaitez réutiliser la configuration du tableau de bord."
        '
        'Nom_Source_txt
        '
        Me.Nom_Source_txt.BackColor = System.Drawing.Color.White
        Me.Nom_Source_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Source_txt.ContextMenuStrip = Nothing
        Me.Nom_Source_txt.Location = New System.Drawing.Point(225, 18)
        Me.Nom_Source_txt.MaxLength = 50
        Me.Nom_Source_txt.Multiline = False
        Me.Nom_Source_txt.Name = "Nom_Source_txt"
        Me.Nom_Source_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Source_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Source_txt.ReadOnly = True
        Me.Nom_Source_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Source_txt.SelectionStart = 0
        Me.Nom_Source_txt.Size = New System.Drawing.Size(344, 26)
        Me.Nom_Source_txt.TabIndex = 204
        Me.Nom_Source_txt.Tag = ""
        Me.Nom_Source_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Source_txt.UseSystemPasswordChar = False
        '
        'Matricule_Source_txt
        '
        Me.Matricule_Source_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Matricule_Source_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_Source_txt.ContextMenuStrip = Nothing
        Me.Matricule_Source_txt.Location = New System.Drawing.Point(99, 18)
        Me.Matricule_Source_txt.MaxLength = 50
        Me.Matricule_Source_txt.Multiline = False
        Me.Matricule_Source_txt.Name = "Matricule_Source_txt"
        Me.Matricule_Source_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_Source_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_Source_txt.ReadOnly = True
        Me.Matricule_Source_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_Source_txt.SelectionStart = 0
        Me.Matricule_Source_txt.Size = New System.Drawing.Size(120, 26)
        Me.Matricule_Source_txt.TabIndex = 203
        Me.Matricule_Source_txt.Tag = ""
        Me.Matricule_Source_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_Source_txt.UseSystemPasswordChar = False
        '
        'Agent_lbl
        '
        Me.Agent_lbl.AutoSize = True
        Me.Agent_lbl.LinkColor = System.Drawing.Color.Black
        Me.Agent_lbl.Location = New System.Drawing.Point(10, 22)
        Me.Agent_lbl.Name = "Agent_lbl"
        Me.Agent_lbl.Size = New System.Drawing.Size(83, 19)
        Me.Agent_lbl.TabIndex = 0
        Me.Agent_lbl.TabStop = True
        Me.Agent_lbl.Tag = ""
        Me.Agent_lbl.Text = "Agent source"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Modele_cmb)
        Me.GroupBox1.Controls.Add(Me.Modele_lbl)
        Me.GroupBox1.Controls.Add(Me.Ecraser_chk)
        Me.GroupBox1.Controls.Add(Me.Lib_Entite_txt)
        Me.GroupBox1.Controls.Add(Me.Cod_Entite_txt)
        Me.GroupBox1.Controls.Add(Me.Entite_lbl)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1000, 50)
        Me.GroupBox1.TabIndex = 219
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agents cibles"
        '
        'Modele_cmb
        '
        Me.Modele_cmb.DataSource = Nothing
        Me.Modele_cmb.DisplayMember = ""
        Me.Modele_cmb.DroppedDown = False
        Me.Modele_cmb.Location = New System.Drawing.Point(770, 12)
        Me.Modele_cmb.Margin = New System.Windows.Forms.Padding(5)
        Me.Modele_cmb.Name = "Modele_cmb"
        Me.Modele_cmb.SelectedIndex = -1
        Me.Modele_cmb.SelectedItem = Nothing
        Me.Modele_cmb.SelectedValue = Nothing
        Me.Modele_cmb.Size = New System.Drawing.Size(220, 30)
        Me.Modele_cmb.TabIndex = 208
        Me.Modele_cmb.ValueMember = ""
        '
        'Modele_lbl
        '
        Me.Modele_lbl.AutoSize = True
        Me.Modele_lbl.Location = New System.Drawing.Point(660, 18)
        Me.Modele_lbl.Name = "Modele_lbl"
        Me.Modele_lbl.Size = New System.Drawing.Size(105, 19)
        Me.Modele_lbl.TabIndex = 207
        Me.Modele_lbl.Text = "Modèle par défaut"
        '
        'Ecraser_chk
        '
        Me.Ecraser_chk.AutoSize = True
        Me.Ecraser_chk.Location = New System.Drawing.Point(478, 17)
        Me.Ecraser_chk.Name = "Ecraser_chk"
        Me.Ecraser_chk.Size = New System.Drawing.Size(176, 23)
        Me.Ecraser_chk.TabIndex = 206
        Me.Ecraser_chk.Text = "Écraser les configurations existantes"
        Me.Ecraser_chk.UseVisualStyleBackColor = True
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.BackColor = System.Drawing.Color.White
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(216, 14)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(250, 26)
        Me.Lib_Entite_txt.TabIndex = 204
        Me.Lib_Entite_txt.Tag = ""
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(69, 14)
        Me.Cod_Entite_txt.MaxLength = 50
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(141, 26)
        Me.Cod_Entite_txt.TabIndex = 203
        Me.Cod_Entite_txt.Tag = ""
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Entite_lbl
        '
        Me.Entite_lbl.AutoSize = True
        Me.Entite_lbl.LinkColor = System.Drawing.Color.Black
        Me.Entite_lbl.Location = New System.Drawing.Point(10, 18)
        Me.Entite_lbl.Name = "Entite_lbl"
        Me.Entite_lbl.Size = New System.Drawing.Size(51, 19)
        Me.Entite_lbl.TabIndex = 0
        Me.Entite_lbl.TabStop = True
        Me.Entite_lbl.Tag = ""
        Me.Entite_lbl.Text = "Entité"
        '
        'Grd
        '
        Me.Grd.AfficherLesEntetesLignes = True
        Me.Grd.AllowUserToAddRows = False
        Me.Grd.AllowUserToDeleteRows = False
        Me.Grd.AllowUserToOrderColumns = True
        Me.Grd.AlternerLesLignes = False
        Me.Grd.AutoGenerateColumns = False
        Me.Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd.ColumnHeadersHeight = 30
        Me.Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Appliquer, Me.Matricule, Me.Nom_Agent, Me.Prenom_Agent, Me.Lib_Entite, Me.Lib_Profile, Me.Config_Existante})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.EnableHeadersVisualStyles = False
        Me.Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd.Location = New System.Drawing.Point(0, 128)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd.RowHeadersWidth = 51
        Me.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grd.Size = New System.Drawing.Size(1000, 572)
        Me.Grd.TabIndex = 220
        '
        'Appliquer
        '
        Me.Appliquer.HeaderText = "Appliquer"
        Me.Appliquer.MinimumWidth = 70
        Me.Appliquer.Name = "Appliquer"
        Me.Appliquer.Width = 70
        '
        'Matricule
        '
        Me.Matricule.HeaderText = "Matricule"
        Me.Matricule.MinimumWidth = 90
        Me.Matricule.Name = "Matricule"
        Me.Matricule.ReadOnly = True
        Me.Matricule.Width = 90
        '
        'Nom_Agent
        '
        Me.Nom_Agent.HeaderText = "Nom"
        Me.Nom_Agent.MinimumWidth = 170
        Me.Nom_Agent.Name = "Nom_Agent"
        Me.Nom_Agent.ReadOnly = True
        Me.Nom_Agent.Width = 170
        '
        'Prenom_Agent
        '
        Me.Prenom_Agent.HeaderText = "Prénom"
        Me.Prenom_Agent.MinimumWidth = 170
        Me.Prenom_Agent.Name = "Prenom_Agent"
        Me.Prenom_Agent.ReadOnly = True
        Me.Prenom_Agent.Width = 170
        '
        'Lib_Entite
        '
        Me.Lib_Entite.HeaderText = "Entité"
        Me.Lib_Entite.MinimumWidth = 150
        Me.Lib_Entite.Name = "Lib_Entite"
        Me.Lib_Entite.ReadOnly = True
        Me.Lib_Entite.Width = 150
        '
        'Lib_Profile
        '
        Me.Lib_Profile.HeaderText = "Profil portail"
        Me.Lib_Profile.MinimumWidth = 150
        Me.Lib_Profile.Name = "Lib_Profile"
        Me.Lib_Profile.ReadOnly = True
        Me.Lib_Profile.Width = 150
        '
        'Config_Existante
        '
        Me.Config_Existante.HeaderText = "Config existante"
        Me.Config_Existante.MinimumWidth = 110
        Me.Config_Existante.Name = "Config_Existante"
        Me.Config_Existante.ReadOnly = True
        Me.Config_Existante.Width = 110
        '
        'Admin_Dashboard_Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 700)
        Me.Controls.Add(Me.Grd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Admin_Dashboard_Config"
        Me.Tag = "ECR"
        Me.Text = "Configuration du tableau de bord du portail"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Info_Config_lbl As Label
    Friend WithEvents Nom_Source_txt As ud_TextBox
    Friend WithEvents Matricule_Source_txt As ud_TextBox
    Friend WithEvents Agent_lbl As LinkLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Modele_cmb As ud_ComboBox
    Friend WithEvents Modele_lbl As Label
    Friend WithEvents Ecraser_chk As CheckBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Entite_lbl As LinkLabel
    Friend WithEvents Grd As ud_Grd
    Friend WithEvents Appliquer As DataGridViewCheckBoxColumn
    Friend WithEvents Matricule As DataGridViewTextBoxColumn
    Friend WithEvents Nom_Agent As DataGridViewTextBoxColumn
    Friend WithEvents Prenom_Agent As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Entite As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Profile As DataGridViewTextBoxColumn
    Friend WithEvents Config_Existante As DataGridViewTextBoxColumn
End Class
