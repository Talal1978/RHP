<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin_TreeView
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
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Adv = New DevComponents.AdvTree.AdvTree()
        Me.oMenu = New DevComponents.AdvTree.ColumnHeader()
        Me.oProtege = New DevComponents.AdvTree.ColumnHeader()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.CntScripts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenommerToolTip = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirLélémentSélectionnéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CréerUnDossierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjouterUnNouvelÉlémentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropriétésToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.search_pb = New System.Windows.Forms.PictureBox()
        Me.Recherche_txt = New RHP.ud_TextBox()
        Me.OuvrirParNiveau_cbo = New RHP.ud_ComboBox()
        Me.Rsl_Recherche = New System.Windows.Forms.Label()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CntScripts.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.search_pb, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Adv
        '
        Me.Adv.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.Adv.AllowDrop = True
        Me.Adv.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.Adv.BackgroundStyle.Class = "TreeBorderKey"
        Me.Adv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Adv.Columns.Add(Me.oMenu)
        Me.Adv.Columns.Add(Me.oProtege)
        Me.Adv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Adv.Location = New System.Drawing.Point(0, 40)
        Me.Adv.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Adv.Name = "Adv"
        Me.Adv.NodesConnector = Me.NodeConnector1
        Me.Adv.NodeStyle = Me.ElementStyle1
        Me.Adv.PathSeparator = ";"
        Me.Adv.Size = New System.Drawing.Size(1128, 756)
        Me.Adv.Styles.Add(Me.ElementStyle1)
        Me.Adv.TabIndex = 1
        Me.Adv.Text = "Adv"
        '
        'oMenu
        '
        Me.oMenu.Name = "oMenu"
        Me.oMenu.Text = "Menu"
        Me.oMenu.Width.Relative = 95
        '
        'oProtege
        '
        Me.oProtege.Name = "oProtege"
        Me.oProtege.Text = "Protégé"
        Me.oProtege.Width.Absolute = 50
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'ElementStyle1
        '
        Me.ElementStyle1.Class = ""
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'CntScripts
        '
        Me.CntScripts.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CntScripts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenommerToolTip, Me.OuvrirLélémentSélectionnéToolStripMenuItem, Me.CréerUnDossierToolStripMenuItem, Me.AjouterUnNouvelÉlémentToolStripMenuItem, Me.SupprimerToolStripMenuItem, Me.PropriétésToolStripMenuItem})
        Me.CntScripts.Name = "CntScripts"
        Me.CntScripts.Size = New System.Drawing.Size(267, 160)
        '
        'RenommerToolTip
        '
        Me.RenommerToolTip.Image = Global.RHP.My.Resources.Resources.script_small
        Me.RenommerToolTip.Name = "RenommerToolTip"
        Me.RenommerToolTip.Size = New System.Drawing.Size(266, 26)
        Me.RenommerToolTip.Text = "Renommer"
        '
        'OuvrirLélémentSélectionnéToolStripMenuItem
        '
        Me.OuvrirLélémentSélectionnéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.openning
        Me.OuvrirLélémentSélectionnéToolStripMenuItem.Name = "OuvrirLélémentSélectionnéToolStripMenuItem"
        Me.OuvrirLélémentSélectionnéToolStripMenuItem.Size = New System.Drawing.Size(266, 26)
        Me.OuvrirLélémentSélectionnéToolStripMenuItem.Text = "Ouvrir l'élément sélectionné"
        '
        'CréerUnDossierToolStripMenuItem
        '
        Me.CréerUnDossierToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.fdr_1
        Me.CréerUnDossierToolStripMenuItem.Name = "CréerUnDossierToolStripMenuItem"
        Me.CréerUnDossierToolStripMenuItem.Size = New System.Drawing.Size(266, 26)
        Me.CréerUnDossierToolStripMenuItem.Text = "Créer un dossier"
        '
        'AjouterUnNouvelÉlémentToolStripMenuItem
        '
        Me.AjouterUnNouvelÉlémentToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.insert
        Me.AjouterUnNouvelÉlémentToolStripMenuItem.Name = "AjouterUnNouvelÉlémentToolStripMenuItem"
        Me.AjouterUnNouvelÉlémentToolStripMenuItem.Size = New System.Drawing.Size(266, 26)
        Me.AjouterUnNouvelÉlémentToolStripMenuItem.Text = "Ajouter un nouvel élément"
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.supprimerligne
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(266, 26)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'PropriétésToolStripMenuItem
        '
        Me.PropriétésToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.OTH
        Me.PropriétésToolStripMenuItem.Name = "PropriétésToolStripMenuItem"
        Me.PropriétésToolStripMenuItem.Size = New System.Drawing.Size(266, 26)
        Me.PropriétésToolStripMenuItem.Text = "Propriétés"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 594.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.search_pb, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Recherche_txt, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.OuvrirParNiveau_cbo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rsl_Recherche, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1128, 40)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'search_pb
        '
        Me.search_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.search_pb.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.search_pb.Location = New System.Drawing.Point(500, 4)
        Me.search_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.search_pb.Name = "search_pb"
        Me.search_pb.Size = New System.Drawing.Size(30, 32)
        Me.search_pb.TabIndex = 0
        Me.search_pb.TabStop = False
        '
        'Recherche_txt
        '
        Me.Recherche_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Recherche_txt.ContextMenuStrip = Nothing
        Me.Recherche_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Recherche_txt.Location = New System.Drawing.Point(250, 5)
        Me.Recherche_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Recherche_txt.MaxLength = 32767
        Me.Recherche_txt.Multiline = False
        Me.Recherche_txt.Name = "Recherche_txt"
        Me.Recherche_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Recherche_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Recherche_txt.ReadOnly = False
        Me.Recherche_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Recherche_txt.SelectionStart = 0
        Me.Recherche_txt.Size = New System.Drawing.Size(242, 30)
        Me.Recherche_txt.TabIndex = 1
        Me.Recherche_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Recherche_txt.UseSystemPasswordChar = False
        '
        'OuvrirParNiveau_cbo
        '
        Me.OuvrirParNiveau_cbo.DataSource = Nothing
        Me.OuvrirParNiveau_cbo.DisplayMember = ""
        Me.OuvrirParNiveau_cbo.DroppedDown = False
        Me.OuvrirParNiveau_cbo.Location = New System.Drawing.Point(4, 5)
        Me.OuvrirParNiveau_cbo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.OuvrirParNiveau_cbo.Name = "OuvrirParNiveau_cbo"
        Me.OuvrirParNiveau_cbo.SelectedIndex = -1
        Me.OuvrirParNiveau_cbo.SelectedItem = Nothing
        Me.OuvrirParNiveau_cbo.SelectedValue = Nothing
        Me.OuvrirParNiveau_cbo.Size = New System.Drawing.Size(238, 30)
        Me.OuvrirParNiveau_cbo.TabIndex = 2
        Me.OuvrirParNiveau_cbo.ValueMember = ""
        '
        'Rsl_Recherche
        '
        Me.Rsl_Recherche.AutoSize = True
        Me.Rsl_Recherche.Dock = System.Windows.Forms.DockStyle.Left
        Me.Rsl_Recherche.Location = New System.Drawing.Point(538, 0)
        Me.Rsl_Recherche.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Rsl_Recherche.Name = "Rsl_Recherche"
        Me.Rsl_Recherche.Size = New System.Drawing.Size(0, 40)
        Me.Rsl_Recherche.TabIndex = 3
        Me.Rsl_Recherche.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Admin_TreeView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1128, 796)
        Me.Controls.Add(Me.Adv)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Admin_TreeView"
        Me.Tag = "ECR"
        Me.Text = "Arborescence des menus"
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CntScripts.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.search_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Adv As DevComponents.AdvTree.AdvTree
    Friend WithEvents oMenu As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents CntScripts As ContextMenuStrip
    Friend WithEvents RenommerToolTip As ToolStripMenuItem
    Friend WithEvents CréerUnDossierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjouterUnNouvelÉlémentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupprimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents oVisible As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents oProtege As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents OuvrirLélémentSélectionnéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropriétésToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents search_pb As PictureBox
    Friend WithEvents Recherche_txt As ud_TextBox
    Friend WithEvents OuvrirParNiveau_cbo As ud_ComboBox
    Friend WithEvents Rsl_Recherche As Label
End Class
