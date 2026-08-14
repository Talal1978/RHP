<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_SP_Nouvelle_Section
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
    'Thème visuel : identique à Zoom_Org_Organigramme_Affectation (formulaire sans
    'bordure cadré colorBase01, bandeau titre, panel clair et contrôles ud_*).
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grd_Sections = New System.Windows.Forms.DataGridView()
        Me.Lbl_Nom = New System.Windows.Forms.Label()
        Me.txtLibelle = New RHP.ud_TextBox()
        Me.Lbl_Code = New System.Windows.Forms.Label()
        Me.txtCode = New RHP.ud_TextBox()
        Me.Lbl_Rang = New System.Windows.Forms.Label()
        Me.numRang = New System.Windows.Forms.NumericUpDown()
        Me.Lbl_Aide_Rang = New System.Windows.Forms.Label()
        Me.Lbl_Icone = New System.Windows.Forms.Label()
        Me.cmbIcone = New System.Windows.Forms.ComboBox()
        Me.picApercu = New System.Windows.Forms.PictureBox()
        Me.Lbl_Aide_Icone = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Supprimer_pb = New System.Windows.Forms.PictureBox()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Nouveau_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Sections, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picApercu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Supprimer_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nouveau_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Grd_Sections)
        Me.Panel1.Controls.Add(Me.Lbl_Nom)
        Me.Panel1.Controls.Add(Me.txtLibelle)
        Me.Panel1.Controls.Add(Me.Lbl_Code)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Controls.Add(Me.Lbl_Rang)
        Me.Panel1.Controls.Add(Me.numRang)
        Me.Panel1.Controls.Add(Me.Lbl_Aide_Rang)
        Me.Panel1.Controls.Add(Me.Lbl_Icone)
        Me.Panel1.Controls.Add(Me.cmbIcone)
        Me.Panel1.Controls.Add(Me.picApercu)
        Me.Panel1.Controls.Add(Me.Lbl_Aide_Icone)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 47)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(973, 409)
        Me.Panel1.TabIndex = 0
        '
        'Grd_Sections
        '
        Me.Grd_Sections.AllowUserToAddRows = False
        Me.Grd_Sections.AllowUserToDeleteRows = False
        Me.Grd_Sections.AllowUserToResizeRows = False
        Me.Grd_Sections.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Sections.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Sections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Sections.Dock = System.Windows.Forms.DockStyle.Left
        Me.Grd_Sections.EnableHeadersVisualStyles = False
        Me.Grd_Sections.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Sections.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Sections.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Sections.MultiSelect = False
        Me.Grd_Sections.Name = "Grd_Sections"
        Me.Grd_Sections.ReadOnly = True
        Me.Grd_Sections.RowHeadersVisible = False
        Me.Grd_Sections.RowHeadersWidth = 51
        Me.Grd_Sections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grd_Sections.Size = New System.Drawing.Size(466, 409)
        Me.Grd_Sections.TabIndex = 0
        '
        'Lbl_Nom
        '
        Me.Lbl_Nom.AutoSize = True
        Me.Lbl_Nom.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lbl_Nom.Location = New System.Drawing.Point(467, 29)
        Me.Lbl_Nom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Nom.Name = "Lbl_Nom"
        Me.Lbl_Nom.Size = New System.Drawing.Size(134, 19)
        Me.Lbl_Nom.TabIndex = 10
        Me.Lbl_Nom.Text = "Nom de la section"
        '
        'txtLibelle
        '
        Me.txtLibelle.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtLibelle.ContextMenuStrip = Nothing
        Me.txtLibelle.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.txtLibelle.Location = New System.Drawing.Point(605, 24)
        Me.txtLibelle.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLibelle.MaxLength = 32767
        Me.txtLibelle.Multiline = False
        Me.txtLibelle.Name = "txtLibelle"
        Me.txtLibelle.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtLibelle.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLibelle.ReadOnly = False
        Me.txtLibelle.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtLibelle.SelectionStart = 0
        Me.txtLibelle.Size = New System.Drawing.Size(352, 26)
        Me.txtLibelle.TabIndex = 1
        Me.txtLibelle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtLibelle.UseSystemPasswordChar = False
        '
        'Lbl_Code
        '
        Me.Lbl_Code.AutoSize = True
        Me.Lbl_Code.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lbl_Code.Location = New System.Drawing.Point(478, 61)
        Me.Lbl_Code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Code.Name = "Lbl_Code"
        Me.Lbl_Code.Size = New System.Drawing.Size(124, 19)
        Me.Lbl_Code.TabIndex = 11
        Me.Lbl_Code.Text = "Code technique"
        '
        'txtCode
        '
        Me.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtCode.ContextMenuStrip = Nothing
        Me.txtCode.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.txtCode.Location = New System.Drawing.Point(605, 56)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCode.MaxLength = 32767
        Me.txtCode.Multiline = False
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCode.ReadOnly = True
        Me.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCode.SelectionStart = 0
        Me.txtCode.Size = New System.Drawing.Size(352, 26)
        Me.txtCode.TabIndex = 2
        Me.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCode.UseSystemPasswordChar = False
        '
        'Lbl_Rang
        '
        Me.Lbl_Rang.AutoSize = True
        Me.Lbl_Rang.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lbl_Rang.Location = New System.Drawing.Point(474, 97)
        Me.Lbl_Rang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Rang.Name = "Lbl_Rang"
        Me.Lbl_Rang.Size = New System.Drawing.Size(130, 19)
        Me.Lbl_Rang.TabIndex = 13
        Me.Lbl_Rang.Text = "Rang d'affichage"
        '
        'numRang
        '
        Me.numRang.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.numRang.Location = New System.Drawing.Point(605, 92)
        Me.numRang.Margin = New System.Windows.Forms.Padding(4)
        Me.numRang.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numRang.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRang.Name = "numRang"
        Me.numRang.Size = New System.Drawing.Size(60, 24)
        Me.numRang.TabIndex = 3
        Me.numRang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numRang.Value = New Decimal(New Integer() {99, 0, 0, 0})
        '
        'Lbl_Aide_Rang
        '
        Me.Lbl_Aide_Rang.AutoSize = True
        Me.Lbl_Aide_Rang.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lbl_Aide_Rang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Aide_Rang.Location = New System.Drawing.Point(673, 97)
        Me.Lbl_Aide_Rang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Aide_Rang.Name = "Lbl_Aide_Rang"
        Me.Lbl_Aide_Rang.Size = New System.Drawing.Size(214, 19)
        Me.Lbl_Aide_Rang.TabIndex = 14
        Me.Lbl_Aide_Rang.Text = "ordre dans le menu du portail"
        '
        'Lbl_Icone
        '
        Me.Lbl_Icone.AutoSize = True
        Me.Lbl_Icone.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lbl_Icone.Location = New System.Drawing.Point(512, 141)
        Me.Lbl_Icone.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Icone.Name = "Lbl_Icone"
        Me.Lbl_Icone.Size = New System.Drawing.Size(87, 19)
        Me.Lbl_Icone.TabIndex = 15
        Me.Lbl_Icone.Text = "Icône (MUI)"
        '
        'cmbIcone
        '
        Me.cmbIcone.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbIcone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIcone.DropDownWidth = 300
        Me.cmbIcone.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.cmbIcone.ItemHeight = 22
        Me.cmbIcone.Location = New System.Drawing.Point(605, 136)
        Me.cmbIcone.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbIcone.Name = "cmbIcone"
        Me.cmbIcone.Size = New System.Drawing.Size(288, 28)
        Me.cmbIcone.TabIndex = 4
        '
        'picApercu
        '
        Me.picApercu.BackColor = System.Drawing.Color.White
        Me.picApercu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picApercu.Location = New System.Drawing.Point(901, 118)
        Me.picApercu.Margin = New System.Windows.Forms.Padding(4)
        Me.picApercu.Name = "picApercu"
        Me.picApercu.Size = New System.Drawing.Size(56, 56)
        Me.picApercu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picApercu.TabIndex = 16
        Me.picApercu.TabStop = False
        '
        'Lbl_Aide_Icone
        '
        Me.Lbl_Aide_Icone.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lbl_Aide_Icone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Aide_Icone.Location = New System.Drawing.Point(605, 178)
        Me.Lbl_Aide_Icone.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Aide_Icone.Name = "Lbl_Aide_Icone"
        Me.Lbl_Aide_Icone.Size = New System.Drawing.Size(312, 32)
        Me.Lbl_Aide_Icone.TabIndex = 17
        Me.Lbl_Aide_Icone.Text = "Icône affichée devant la section dans le menu latéral du portail."
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ent_pnl.ColumnCount = 6
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.Controls.Add(Me.Supprimer_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Zoom_lbl, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 5, 0)
        Me.ent_pnl.Controls.Add(Me.Nouveau_pb, 3, 0)
        Me.ent_pnl.Controls.Add(Me.Save_pb, 4, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(973, 45)
        Me.ent_pnl.TabIndex = 7
        '
        'Supprimer_pb
        '
        Me.Supprimer_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Supprimer_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Supprimer_pb.Image = Global.RHP.My.Resources.Resources.btn_delete
        Me.Supprimer_pb.Location = New System.Drawing.Point(757, 4)
        Me.Supprimer_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Supprimer_pb.Name = "Supprimer_pb"
        Me.Supprimer_pb.Size = New System.Drawing.Size(36, 37)
        Me.Supprimer_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Supprimer_pb.TabIndex = 35
        Me.Supprimer_pb.TabStop = False
        '
        'Zoom_lbl
        '
        Me.Zoom_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Zoom_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Zoom_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Zoom_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Zoom_lbl.Location = New System.Drawing.Point(4, 0)
        Me.Zoom_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Zoom_lbl.Name = "Zoom_lbl"
        Me.Zoom_lbl.Size = New System.Drawing.Size(745, 39)
        Me.Zoom_lbl.TabIndex = 33
        Me.Zoom_lbl.Text = "Gestion des sections du portail"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(933, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(36, 37)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 34
        Me.Close_pb.TabStop = False
        '
        'Nouveau_pb
        '
        Me.Nouveau_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nouveau_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Nouveau_pb.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.Nouveau_pb.Location = New System.Drawing.Point(845, 4)
        Me.Nouveau_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Nouveau_pb.Name = "Nouveau_pb"
        Me.Nouveau_pb.Size = New System.Drawing.Size(36, 37)
        Me.Nouveau_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Nouveau_pb.TabIndex = 34
        Me.Nouveau_pb.TabStop = False
        '
        'Save_pb
        '
        Me.Save_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(889, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(36, 37)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 36
        Me.Save_pb.TabStop = False
        '
        'Zoom_SP_Nouvelle_Section
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(977, 458)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ent_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_SP_Nouvelle_Section"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestion des sections du portail"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grd_Sections, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picApercu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Supprimer_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nouveau_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grd_Sections As DataGridView
    Friend WithEvents Lbl_Nom As Label
    Friend WithEvents txtLibelle As ud_TextBox
    Friend WithEvents Lbl_Code As Label
    Friend WithEvents txtCode As ud_TextBox
    Friend WithEvents Lbl_Rang As Label
    Friend WithEvents numRang As NumericUpDown
    Friend WithEvents Lbl_Aide_Rang As Label
    Friend WithEvents Lbl_Icone As Label
    Friend WithEvents cmbIcone As ComboBox
    Friend WithEvents picApercu As PictureBox
    Friend WithEvents Lbl_Aide_Icone As Label
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Supprimer_pb As PictureBox
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Nouveau_pb As PictureBox
End Class
