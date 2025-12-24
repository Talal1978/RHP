<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Param_Rubriques
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grille = New RHP.ud_Grd()
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Membre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Champs02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom_Controle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COD = New System.Windows.Forms.LinkLabel()
        Me.Nom_Controle_Text = New RHP.ud_TextBox()
        Me.Texte_Rubrique_Text = New RHP.ud_TextBox()
        Me.NoAddRows_chk = New RHP.ud_CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grille
        '
        Me.Grille.AfficherLesEntetesLignes = True
        Me.Grille.AllowUserToOrderColumns = True
        Me.Grille.AlternerLesLignes = False
        Me.Grille.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grille.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grille.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grille.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Valeur, Me.Membre, Me.Champs02, Me.Rang, Me.Typ, Me.Nom_Controle})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grille.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grille.EnableHeadersVisualStyles = False
        Me.Grille.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grille.Location = New System.Drawing.Point(0, 85)
        Me.Grille.Name = "Grille"
        Me.Grille.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grille.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grille.RowHeadersWidth = 51
        Me.Grille.Size = New System.Drawing.Size(1142, 552)
        Me.Grille.TabIndex = 3
        '
        'Valeur
        '
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.MinimumWidth = 6
        Me.Valeur.Name = "Valeur"
        Me.Valeur.Width = 125
        '
        'Membre
        '
        Me.Membre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Membre.HeaderText = "Membre"
        Me.Membre.MinimumWidth = 250
        Me.Membre.Name = "Membre"
        Me.Membre.Width = 250
        '
        'Champs02
        '
        Me.Champs02.HeaderText = "Champs 02"
        Me.Champs02.MaxInputLength = 50
        Me.Champs02.MinimumWidth = 6
        Me.Champs02.Name = "Champs02"
        Me.Champs02.Width = 125
        '
        'Rang
        '
        Me.Rang.HeaderText = "Rang"
        Me.Rang.MinimumWidth = 6
        Me.Rang.Name = "Rang"
        Me.Rang.Width = 125
        '
        'Typ
        '
        Me.Typ.HeaderText = "Type"
        Me.Typ.MinimumWidth = 6
        Me.Typ.Name = "Typ"
        Me.Typ.ReadOnly = True
        Me.Typ.Width = 125
        '
        'Nom_Controle
        '
        Me.Nom_Controle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Nom_Controle.HeaderText = "Nom_Controle"
        Me.Nom_Controle.MinimumWidth = 6
        Me.Nom_Controle.Name = "Nom_Controle"
        Me.Nom_Controle.Visible = False
        Me.Nom_Controle.Width = 125
        '
        'COD
        '
        Me.COD.AutoSize = True
        Me.COD.LinkColor = System.Drawing.Color.Black
        Me.COD.Location = New System.Drawing.Point(39, 16)
        Me.COD.Name = "COD"
        Me.COD.Size = New System.Drawing.Size(72, 19)
        Me.COD.TabIndex = 0
        Me.COD.TabStop = True
        Me.COD.Tag = ""
        Me.COD.Text = "Rubrique"
        '
        'Nom_Controle_Text
        '
        Me.Nom_Controle_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Controle_Text.ContextMenuStrip = Nothing
        Me.Nom_Controle_Text.Location = New System.Drawing.Point(118, 13)
        Me.Nom_Controle_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Nom_Controle_Text.MaxLength = 32767
        Me.Nom_Controle_Text.Multiline = False
        Me.Nom_Controle_Text.Name = "Nom_Controle_Text"
        Me.Nom_Controle_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Controle_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Controle_Text.ReadOnly = True
        Me.Nom_Controle_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Controle_Text.SelectionStart = 0
        Me.Nom_Controle_Text.Size = New System.Drawing.Size(310, 26)
        Me.Nom_Controle_Text.TabIndex = 71
        Me.Nom_Controle_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Controle_Text.UseSystemPasswordChar = False
        '
        'Texte_Rubrique_Text
        '
        Me.Texte_Rubrique_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Texte_Rubrique_Text.ContextMenuStrip = Nothing
        Me.Texte_Rubrique_Text.Location = New System.Drawing.Point(436, 13)
        Me.Texte_Rubrique_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Texte_Rubrique_Text.MaxLength = 50
        Me.Texte_Rubrique_Text.Multiline = False
        Me.Texte_Rubrique_Text.Name = "Texte_Rubrique_Text"
        Me.Texte_Rubrique_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Texte_Rubrique_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Texte_Rubrique_Text.ReadOnly = False
        Me.Texte_Rubrique_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Texte_Rubrique_Text.SelectionStart = 0
        Me.Texte_Rubrique_Text.Size = New System.Drawing.Size(662, 26)
        Me.Texte_Rubrique_Text.TabIndex = 72
        Me.Texte_Rubrique_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Texte_Rubrique_Text.UseSystemPasswordChar = False
        '
        'NoAddRows_chk
        '
        Me.NoAddRows_chk.AutoSize = True
        Me.NoAddRows_chk.Checked = True
        Me.NoAddRows_chk.Enabled = False
        Me.NoAddRows_chk.Location = New System.Drawing.Point(118, 47)
        Me.NoAddRows_chk.Margin = New System.Windows.Forms.Padding(4)
        Me.NoAddRows_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.NoAddRows_chk.MinimumSize = New System.Drawing.Size(100, 0)
        Me.NoAddRows_chk.Name = "NoAddRows_chk"
        Me.NoAddRows_chk.Size = New System.Drawing.Size(191, 25)
        Me.NoAddRows_chk.TabIndex = 73
        Me.NoAddRows_chk.Text = "Interdire l'ajout de ligne"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.NoAddRows_chk)
        Me.Panel1.Controls.Add(Me.Nom_Controle_Text)
        Me.Panel1.Controls.Add(Me.COD)
        Me.Panel1.Controls.Add(Me.Texte_Rubrique_Text)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1142, 85)
        Me.Panel1.TabIndex = 4
        '
        'Param_Rubriques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1142, 637)
        Me.Controls.Add(Me.Grille)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "Param_Rubriques"
        Me.Tag = "ECR"
        Me.Text = "Paramètrage rubriques"
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grille As ud_Grd
    Friend WithEvents COD As System.Windows.Forms.LinkLabel
    Friend WithEvents Nom_Controle_Text As ud_TextBox
    Friend WithEvents Texte_Rubrique_Text As ud_TextBox
    Friend WithEvents NoAddRows_chk As ud_CheckBox
    Friend WithEvents Valeur As DataGridViewTextBoxColumn
    Friend WithEvents Membre As DataGridViewTextBoxColumn
    Friend WithEvents Champs02 As DataGridViewTextBoxColumn
    Friend WithEvents Rang As DataGridViewTextBoxColumn
    Friend WithEvents Typ As DataGridViewTextBoxColumn
    Friend WithEvents Nom_Controle As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
End Class
