<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GPEC_RegistreProfils
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grille = New RHP.ud_Grd()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.lbl_lbl = New System.Windows.Forms.LinkLabel()
        Me.Competences_txt = New RHP.ud_TextBox()
        Me.SEL_CRT_GROUP = New System.Windows.Forms.GroupBox()
        Me.chk_externe = New RHP.ud_CheckBox()
        Me.chk_interne = New RHP.ud_CheckBox()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Personnal_pnl.SuspendLayout()
        Me.SEL_CRT_GROUP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grille
        '
        Me.Grille.AllowUserToAddRows = False
        Me.Grille.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grille.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grille.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grille.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grille.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grille.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grille.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grille.EnableHeadersVisualStyles = False
        Me.Grille.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grille.Location = New System.Drawing.Point(0, 113)
        Me.Grille.Name = "Grille"
        Me.Grille.ReadOnly = True
        Me.Grille.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grille.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grille.Size = New System.Drawing.Size(1028, 496)
        Me.Grille.TabIndex = 2
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
        'lbl_lbl
        '
        Me.lbl_lbl.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl_lbl.AutoSize = True
        Me.lbl_lbl.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lbl_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl_lbl.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl_lbl.Location = New System.Drawing.Point(12, 26)
        Me.lbl_lbl.Name = "lbl_lbl"
        Me.lbl_lbl.Size = New System.Drawing.Size(85, 16)
        Me.lbl_lbl.TabIndex = 0
        Me.lbl_lbl.TabStop = True
        Me.lbl_lbl.Tag = "SC"
        Me.lbl_lbl.Text = "Compétences"
        '
        'Competences_txt
        '
        Me.Competences_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Competences_txt.Location = New System.Drawing.Point(15, 45)
        Me.Competences_txt.MaxLength = 32767
        Me.Competences_txt.Multiline = True
        Me.Competences_txt.Name = "Competences_txt"
        Me.Competences_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Competences_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Competences_txt.ReadOnly = True
        Me.Competences_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Competences_txt.SelectionStart = 0
        Me.Competences_txt.Size = New System.Drawing.Size(587, 62)
        Me.Competences_txt.TabIndex = 200
        Me.Competences_txt.Tag = ""
        Me.Competences_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Competences_txt.UseSystemPasswordChar = False
        '
        'SEL_CRT_GROUP
        '
        Me.SEL_CRT_GROUP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SEL_CRT_GROUP.Controls.Add(Me.chk_externe)
        Me.SEL_CRT_GROUP.Controls.Add(Me.chk_interne)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Competences_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.lbl_lbl)
        Me.SEL_CRT_GROUP.Dock = System.Windows.Forms.DockStyle.Top
        Me.SEL_CRT_GROUP.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.SEL_CRT_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.SEL_CRT_GROUP.Name = "SEL_CRT_GROUP"
        Me.SEL_CRT_GROUP.Size = New System.Drawing.Size(1028, 113)
        Me.SEL_CRT_GROUP.TabIndex = 0
        Me.SEL_CRT_GROUP.TabStop = False
        Me.SEL_CRT_GROUP.Tag = "Critères de sélection"
        Me.SEL_CRT_GROUP.Text = "Critères de sélection"
        '
        'chk_externe
        '
        Me.chk_externe.AutoSize = True
        Me.chk_externe.Checked = True
        Me.chk_externe.Location = New System.Drawing.Point(619, 43)
        Me.chk_externe.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.chk_externe.MaximumSize = New System.Drawing.Size(0, 31)
        Me.chk_externe.MinimumSize = New System.Drawing.Size(136, 31)
        Me.chk_externe.Name = "chk_externe"
        Me.chk_externe.Size = New System.Drawing.Size(136, 31)
        Me.chk_externe.TabIndex = 201
        Me.chk_externe.Text = "Ressources externes"
        '
        'chk_interne
        '
        Me.chk_interne.AutoSize = True
        Me.chk_interne.Checked = True
        Me.chk_interne.Location = New System.Drawing.Point(619, 17)
        Me.chk_interne.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chk_interne.MaximumSize = New System.Drawing.Size(0, 25)
        Me.chk_interne.MinimumSize = New System.Drawing.Size(117, 25)
        Me.chk_interne.Name = "chk_interne"
        Me.chk_interne.Size = New System.Drawing.Size(126, 25)
        Me.chk_interne.TabIndex = 201
        Me.chk_interne.Text = "Ressources internes"
        '
        'GPEC_RegistreProfils
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 609)
        Me.Controls.Add(Me.Grille)
        Me.Controls.Add(Me.SEL_CRT_GROUP)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GPEC_RegistreProfils"
        Me.Tag = "ECR"
        Me.Text = "Registre des profiles"
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Personnal_pnl.ResumeLayout(False)
        Me.SEL_CRT_GROUP.ResumeLayout(False)
        Me.SEL_CRT_GROUP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Grille As ud_Grd
    Friend WithEvents lbl_lbl As LinkLabel
    Friend WithEvents Competences_txt As ud_TextBox
    Friend WithEvents SEL_CRT_GROUP As GroupBox
    Friend WithEvents chk_externe As ud_CheckBox
    Friend WithEvents chk_interne As ud_CheckBox
End Class
