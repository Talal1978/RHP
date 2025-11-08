<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Org_Organigramme
    inherits Ecran
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
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.entPnl = New System.Windows.Forms.Panel()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Entite_ = New System.Windows.Forms.LinkLabel()
        Me.Rd_Entite = New RHP.ud_RadioBox()
        Me.Rd_Man = New RHP.ud_RadioBox()
        Me.Org_CMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AjouteUneEntitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModifierUneEntitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupprimerCetteEntitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnregistrerEnImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Org_pnl = New System.Windows.Forms.Panel()
        Me.Line_lbl = New System.Windows.Forms.Label()
        Me.entPnl.SuspendLayout()
        Me.Org_CMS.SuspendLayout()
        Me.SuspendLayout()
        '
        'entPnl
        '
        Me.entPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.entPnl.Controls.Add(Me.Cod_Entite_txt)
        Me.entPnl.Controls.Add(Me.Lib_Entite_txt)
        Me.entPnl.Controls.Add(Me.Entite_)
        Me.entPnl.Controls.Add(Me.Rd_Entite)
        Me.entPnl.Controls.Add(Me.Rd_Man)
        Me.entPnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.entPnl.Location = New System.Drawing.Point(0, 0)
        Me.entPnl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.entPnl.Name = "entPnl"
        Me.entPnl.Size = New System.Drawing.Size(1051, 43)
        Me.entPnl.TabIndex = 1
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(80, 11)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Entite_txt.MaxLength = 6
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(90, 21)
        Me.Cod_Entite_txt.TabIndex = 226
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(173, 11)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(429, 21)
        Me.Lib_Entite_txt.TabIndex = 225
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Entite_
        '
        Me.Entite_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.AutoSize = True
        Me.Entite_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Entite_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_.Location = New System.Drawing.Point(37, 14)
        Me.Entite_.Name = "Entite_"
        Me.Entite_.Size = New System.Drawing.Size(38, 16)
        Me.Entite_.TabIndex = 224
        Me.Entite_.TabStop = True
        Me.Entite_.Tag = "NC"
        Me.Entite_.Text = "Entité"
        Me.Entite_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Rd_Entite
        '
        Me.Rd_Entite.AutoSize = True
        Me.Rd_Entite.Checked = True
        Me.Rd_Entite.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_Entite.Location = New System.Drawing.Point(748, 6)
        Me.Rd_Entite.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rd_Entite.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Entite.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Entite.Name = "Rd_Entite"
        Me.Rd_Entite.Size = New System.Drawing.Size(131, 31)
        Me.Rd_Entite.TabIndex = 4
        Me.Rd_Entite.Text = "Organisationnel"
        '
        'Rd_Man
        '
        Me.Rd_Man.AutoSize = True
        Me.Rd_Man.Checked = False
        Me.Rd_Man.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_Man.Location = New System.Drawing.Point(624, 6)
        Me.Rd_Man.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rd_Man.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Man.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Man.Name = "Rd_Man"
        Me.Rd_Man.Size = New System.Drawing.Size(131, 31)
        Me.Rd_Man.TabIndex = 3
        Me.Rd_Man.Text = "Nominatif"
        '
        'Org_CMS
        '
        Me.Org_CMS.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Org_CMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AjouteUneEntitéToolStripMenuItem, Me.ModifierUneEntitéToolStripMenuItem, Me.AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem, Me.SupprimerCetteEntitéToolStripMenuItem, Me.EnregistrerEnImageToolStripMenuItem})
        Me.Org_CMS.Name = "Org_CMS"
        Me.Org_CMS.Size = New System.Drawing.Size(331, 134)
        '
        'AjouteUneEntitéToolStripMenuItem
        '
        Me.AjouteUneEntitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Modifier
        Me.AjouteUneEntitéToolStripMenuItem.Name = "AjouteUneEntitéToolStripMenuItem"
        Me.AjouteUneEntitéToolStripMenuItem.Size = New System.Drawing.Size(330, 26)
        Me.AjouteUneEntitéToolStripMenuItem.Text = "Ajouter  une entité"
        '
        'ModifierUneEntitéToolStripMenuItem
        '
        Me.ModifierUneEntitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Functionality_small
        Me.ModifierUneEntitéToolStripMenuItem.Name = "ModifierUneEntitéToolStripMenuItem"
        Me.ModifierUneEntitéToolStripMenuItem.Size = New System.Drawing.Size(330, 26)
        Me.ModifierUneEntitéToolStripMenuItem.Text = "Modifier une entité"
        '
        'AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem
        '
        Me.AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Partenaires
        Me.AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem.Name = "AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem"
        Me.AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem.Size = New System.Drawing.Size(330, 26)
        Me.AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem.Text = "Afficher la liste des agents affectés à cette entité"
        '
        'SupprimerCetteEntitéToolStripMenuItem
        '
        Me.SupprimerCetteEntitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.supprimerttligne
        Me.SupprimerCetteEntitéToolStripMenuItem.Name = "SupprimerCetteEntitéToolStripMenuItem"
        Me.SupprimerCetteEntitéToolStripMenuItem.Size = New System.Drawing.Size(330, 26)
        Me.SupprimerCetteEntitéToolStripMenuItem.Text = "Supprimer cette entité"
        '
        'EnregistrerEnImageToolStripMenuItem
        '
        Me.EnregistrerEnImageToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.camera
        Me.EnregistrerEnImageToolStripMenuItem.Name = "EnregistrerEnImageToolStripMenuItem"
        Me.EnregistrerEnImageToolStripMenuItem.Size = New System.Drawing.Size(330, 26)
        Me.EnregistrerEnImageToolStripMenuItem.Text = "Enregistrer en image"
        '
        'Org_pnl
        '
        Me.Org_pnl.AutoScroll = True
        Me.Org_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Org_pnl.Location = New System.Drawing.Point(0, 44)
        Me.Org_pnl.Name = "Org_pnl"
        Me.Org_pnl.Padding = New System.Windows.Forms.Padding(5, 20, 5, 5)
        Me.Org_pnl.Size = New System.Drawing.Size(1051, 660)
        Me.Org_pnl.TabIndex = 2
        '
        'Line_lbl
        '
        Me.Line_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Line_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Line_lbl.Location = New System.Drawing.Point(0, 43)
        Me.Line_lbl.Name = "Line_lbl"
        Me.Line_lbl.Size = New System.Drawing.Size(1051, 1)
        Me.Line_lbl.TabIndex = 0
        '
        'Org_Organigramme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1051, 704)
        Me.Controls.Add(Me.Org_pnl)
        Me.Controls.Add(Me.Line_lbl)
        Me.Controls.Add(Me.entPnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Org_Organigramme"
        Me.Tag = "ECR"
        Me.Text = "Organigramme"
        Me.entPnl.ResumeLayout(False)
        Me.entPnl.PerformLayout()
        Me.Org_CMS.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents entPnl As Panel
    Friend WithEvents Rd_Entite As ud_RadioBox
    Friend WithEvents Rd_Man As ud_RadioBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Entite_ As LinkLabel
    Friend WithEvents Org_CMS As ContextMenuStrip
    Friend WithEvents AjouteUneEntitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupprimerCetteEntitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnregistrerEnImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModifierUneEntitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Org_pnl As Panel
    Friend WithEvents Line_lbl As Label
End Class
