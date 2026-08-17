<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin_Profil_Agent
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Entite_lbl = New System.Windows.Forms.LinkLabel()
        Me.Grd = New RHP.ud_Grd()
        Me.Matricule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom_Agent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prenom_Agent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Entite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Profile = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Lib_Entite_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Entite_txt)
        Me.GroupBox2.Controls.Add(Me.Entite_lbl)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(955, 46)
        Me.GroupBox2.TabIndex = 218
        Me.GroupBox2.TabStop = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.BackColor = System.Drawing.Color.White
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(221, 14)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(344, 26)
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
        Me.Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Matricule, Me.Nom_Agent, Me.Prenom_Agent, Me.Lib_Entite, Me.Cod_Profile})
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
        Me.Grd.Location = New System.Drawing.Point(0, 46)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd.RowHeadersWidth = 51
        Me.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grd.Size = New System.Drawing.Size(955, 640)
        Me.Grd.TabIndex = 219
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
        Me.Nom_Agent.MinimumWidth = 180
        Me.Nom_Agent.Name = "Nom_Agent"
        Me.Nom_Agent.ReadOnly = True
        Me.Nom_Agent.Width = 180
        '
        'Prenom_Agent
        '
        Me.Prenom_Agent.HeaderText = "Prénom"
        Me.Prenom_Agent.MinimumWidth = 180
        Me.Prenom_Agent.Name = "Prenom_Agent"
        Me.Prenom_Agent.ReadOnly = True
        Me.Prenom_Agent.Width = 180
        '
        'Lib_Entite
        '
        Me.Lib_Entite.HeaderText = "Entité"
        Me.Lib_Entite.MinimumWidth = 160
        Me.Lib_Entite.Name = "Lib_Entite"
        Me.Lib_Entite.ReadOnly = True
        Me.Lib_Entite.Width = 160
        '
        'Cod_Profile
        '
        Me.Cod_Profile.HeaderText = "Profil portail"
        Me.Cod_Profile.MinimumWidth = 220
        Me.Cod_Profile.Name = "Cod_Profile"
        Me.Cod_Profile.Width = 220
        '
        'Admin_Profil_Agent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(955, 686)
        Me.Controls.Add(Me.Grd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Admin_Profil_Agent"
        Me.Tag = "ECR"
        Me.Text = "Affectation des profils portail aux agents"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Entite_lbl As LinkLabel
    Friend WithEvents Grd As ud_Grd
    Friend WithEvents Matricule As DataGridViewTextBoxColumn
    Friend WithEvents Nom_Agent As DataGridViewTextBoxColumn
    Friend WithEvents Prenom_Agent As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Entite As DataGridViewTextBoxColumn
    Friend WithEvents Cod_Profile As DataGridViewComboBoxColumn
End Class
