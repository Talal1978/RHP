<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Param_Rubriques
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
        'Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        'Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        'Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        'Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBox_GRD = New RHP.ud_Grd()
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
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.ComboBox_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.Controls.Add(Me.ButtonX1, 0, 0)
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(200, 100)
        Me.Personnal_pnl.TabIndex = 0
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
        'ComboBox_GRD
        '
        Me.ComboBox_GRD.AllowUserToOrderColumns = True
        Me.ComboBox_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ComboBox_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ComboBox_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.ComboBox_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ComboBox_GRD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Valeur, Me.Membre, Me.Champs02, Me.Rang, Me.Typ, Me.Nom_Controle})
        Me.ComboBox_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox_GRD.EnableHeadersVisualStyles = False
        Me.ComboBox_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ComboBox_GRD.Location = New System.Drawing.Point(0, 36)
        Me.ComboBox_GRD.Name = "ComboBox_GRD"
        Me.ComboBox_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.ComboBox_GRD.Size = New System.Drawing.Size(902, 601)
        Me.ComboBox_GRD.TabIndex = 3
        '
        'Valeur
        '
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.Name = "Valeur"
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
        Me.Champs02.Name = "Champs02"
        '
        'Rang
        '
        Me.Rang.HeaderText = "Rang"
        Me.Rang.Name = "Rang"
        '
        'Typ
        '
        Me.Typ.HeaderText = "Type"
        Me.Typ.Name = "Typ"
        Me.Typ.ReadOnly = True
        '
        'Nom_Controle
        '
        Me.Nom_Controle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Nom_Controle.HeaderText = "Nom_Controle"
        Me.Nom_Controle.Name = "Nom_Controle"
        Me.Nom_Controle.Visible = False
        '
        'COD
        '
        Me.COD.AutoSize = True
        Me.COD.LinkColor = System.Drawing.Color.Black
        Me.COD.Location = New System.Drawing.Point(8, 9)
        Me.COD.Name = "COD"
        Me.COD.Size = New System.Drawing.Size(57, 16)
        Me.COD.TabIndex = 0
        Me.COD.TabStop = True
        Me.COD.Tag = ""
        Me.COD.Text = "Rubrique"
        '
        'Nom_Controle_Text
        '
        Me.Nom_Controle_Text.BackColor = System.Drawing.SystemColors.Control
        Me.Nom_Controle_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Controle_Text.Location = New System.Drawing.Point(68, 6)
        Me.Nom_Controle_Text.MaxLength = 32767
        Me.Nom_Controle_Text.Multiline = False
        Me.Nom_Controle_Text.Name = "Nom_Controle_Text"
        Me.Nom_Controle_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Controle_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Controle_Text.ReadOnly = True
        Me.Nom_Controle_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Controle_Text.SelectionStart = 0
        Me.Nom_Controle_Text.Size = New System.Drawing.Size(163, 21)
        Me.Nom_Controle_Text.TabIndex = 71
        Me.Nom_Controle_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Controle_Text.UseSystemPasswordChar = False
        '
        'Texte_Rubrique_Text
        '
        Me.Texte_Rubrique_Text.BackColor = System.Drawing.SystemColors.Window
        Me.Texte_Rubrique_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Texte_Rubrique_Text.Location = New System.Drawing.Point(237, 6)
        Me.Texte_Rubrique_Text.MaxLength = 50
        Me.Texte_Rubrique_Text.Multiline = False
        Me.Texte_Rubrique_Text.Name = "Texte_Rubrique_Text"
        Me.Texte_Rubrique_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Texte_Rubrique_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Texte_Rubrique_Text.ReadOnly = False
        Me.Texte_Rubrique_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Texte_Rubrique_Text.SelectionStart = 0
        Me.Texte_Rubrique_Text.Size = New System.Drawing.Size(319, 21)
        Me.Texte_Rubrique_Text.TabIndex = 72
        Me.Texte_Rubrique_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Texte_Rubrique_Text.UseSystemPasswordChar = False
        '
        'NoAddRows_chk
        '
        Me.NoAddRows_chk.AutoSize = True
        Me.NoAddRows_chk.Checked = True
        Me.NoAddRows_chk.Enabled = False
        Me.NoAddRows_chk.Location = New System.Drawing.Point(558, 8)
        Me.NoAddRows_chk.MaximumSize = New System.Drawing.Size(0, 20)
        Me.NoAddRows_chk.MinimumSize = New System.Drawing.Size(100, 20)
        Me.NoAddRows_chk.Name = "NoAddRows_chk"
        Me.NoAddRows_chk.Size = New System.Drawing.Size(152, 20)
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
        Me.Panel1.Size = New System.Drawing.Size(902, 36)
        Me.Panel1.TabIndex = 4
        '
        'Param_Rubriques
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(902, 637)
        Me.Controls.Add(Me.ComboBox_GRD)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Param_Rubriques"
        Me.Tag = "ECR"
        Me.Text = "Paramètrage rubriques"
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.ComboBox_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBox_GRD As ud_Grd
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
