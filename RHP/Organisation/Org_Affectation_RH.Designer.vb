<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Org_Affectation_RH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Org_Affectation_RH))
        Me.Adv = New DevComponents.AdvTree.AdvTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.nSoc = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.oCnt_RH = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DésignerEnTantQueResponableDeLEntitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsulterLaFicheDeLAgentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Adv_NonAffecte = New DevComponents.AdvTree.AdvTree()
        Me.ndSocNonAffecte = New DevComponents.AdvTree.Node()
        Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle4 = New DevComponents.DotNetBar.ElementStyle()
        Me.oCnt_Org = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AjouterUneEntitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModifierLentitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupprimerLentitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Header = New System.Windows.Forms.TableLayoutPanel()
        Me.Search_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Search_pb = New System.Windows.Forms.PictureBox()
        Me.Search_txt = New RHP.ud_TextBox()
        Me.OuvrirParNiveau_cbo = New RHP.ud_ComboBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.oCnt_RH.SuspendLayout()
        CType(Me.Adv_NonAffecte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.oCnt_Org.SuspendLayout()
        Me.Header.SuspendLayout()
        Me.Search_pnl.SuspendLayout()
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Adv.Columns.Add(Me.ColumnHeader1)
        Me.Adv.Columns.Add(Me.ColumnHeader2)
        Me.Adv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Adv.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Adv.ImageList = Me.imgList
        Me.Adv.Location = New System.Drawing.Point(0, 56)
        Me.Adv.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Adv.Name = "Adv"
        Me.Adv.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.nSoc})
        Me.Adv.NodesConnector = Me.NodeConnector1
        Me.Adv.NodeSpacing = 8
        Me.Adv.NodeStyle = Me.ElementStyle1
        Me.Adv.PathSeparator = ";"
        Me.Adv.Size = New System.Drawing.Size(836, 506)
        Me.Adv.Styles.Add(Me.ElementStyle1)
        Me.Adv.TabIndex = 8
        Me.Adv.Text = "AdvTree1"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Organisation"
        Me.ColumnHeader1.Width.Absolute = 600
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Type / Grade"
        Me.ColumnHeader2.Width.Absolute = 100
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "trv_societe.png")
        Me.imgList.Images.SetKeyName(1, "trv_entite.png")
        Me.imgList.Images.SetKeyName(2, "trv_leader.png")
        Me.imgList.Images.SetKeyName(3, "trv_agent.png")
        '
        'nSoc
        '
        Me.nSoc.ContextMenu = Me.oCnt_Org
        Me.nSoc.Expanded = True
        Me.nSoc.ImageIndex = 0
        Me.nSoc.Name = "nSoc"
        Me.nSoc.Text = "Node1"
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
        'oCnt_RH
        '
        Me.oCnt_RH.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.oCnt_RH.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DésignerEnTantQueResponableDeLEntitéToolStripMenuItem, Me.ConsulterLaFicheDeLAgentToolStripMenuItem})
        Me.oCnt_RH.Name = "ContextMenuStrip1"
        Me.oCnt_RH.Size = New System.Drawing.Size(369, 56)
        '
        'DésignerEnTantQueResponableDeLEntitéToolStripMenuItem
        '
        Me.DésignerEnTantQueResponableDeLEntitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Client
        Me.DésignerEnTantQueResponableDeLEntitéToolStripMenuItem.Name = "DésignerEnTantQueResponableDeLEntitéToolStripMenuItem"
        Me.DésignerEnTantQueResponableDeLEntitéToolStripMenuItem.Size = New System.Drawing.Size(368, 26)
        Me.DésignerEnTantQueResponableDeLEntitéToolStripMenuItem.Text = "Désigner en tant que responable de l'Entité"
        '
        'ConsulterLaFicheDeLAgentToolStripMenuItem
        '
        Me.ConsulterLaFicheDeLAgentToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Menu_Operationnel
        Me.ConsulterLaFicheDeLAgentToolStripMenuItem.Name = "ConsulterLaFicheDeLAgentToolStripMenuItem"
        Me.ConsulterLaFicheDeLAgentToolStripMenuItem.Size = New System.Drawing.Size(368, 26)
        Me.ConsulterLaFicheDeLAgentToolStripMenuItem.Text = "Consulter la fiche de l'Agent"
        '
        'Adv_NonAffecte
        '
        Me.Adv_NonAffecte.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.Adv_NonAffecte.AllowDrop = True
        Me.Adv_NonAffecte.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.Adv_NonAffecte.BackgroundStyle.Class = "TreeBorderKey"
        Me.Adv_NonAffecte.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Adv_NonAffecte.Dock = System.Windows.Forms.DockStyle.Right
        Me.Adv_NonAffecte.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Adv_NonAffecte.ImageList = Me.imgList
        Me.Adv_NonAffecte.Location = New System.Drawing.Point(836, 56)
        Me.Adv_NonAffecte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Adv_NonAffecte.Name = "Adv_NonAffecte"
        Me.Adv_NonAffecte.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.ndSocNonAffecte})
        Me.Adv_NonAffecte.NodesConnector = Me.NodeConnector2
        Me.Adv_NonAffecte.NodeSpacing = 10
        Me.Adv_NonAffecte.NodeStyle = Me.ElementStyle4
        Me.Adv_NonAffecte.PathSeparator = ";"
        Me.Adv_NonAffecte.Size = New System.Drawing.Size(414, 506)
        Me.Adv_NonAffecte.Styles.Add(Me.ElementStyle4)
        Me.Adv_NonAffecte.TabIndex = 0
        Me.Adv_NonAffecte.Text = "AdvTree1"
        '
        'ndSocNonAffecte
        '
        Me.ndSocNonAffecte.Expanded = True
        Me.ndSocNonAffecte.ImageIndex = 0
        Me.ndSocNonAffecte.Name = "ndSocNonAffecte"
        Me.ndSocNonAffecte.Text = "Agents non affectés"
        '
        'NodeConnector2
        '
        Me.NodeConnector2.LineColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'ElementStyle4
        '
        Me.ElementStyle4.Class = ""
        Me.ElementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.TextColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        '
        'oCnt_Org
        '
        Me.oCnt_Org.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.oCnt_Org.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AjouterUneEntitéToolStripMenuItem, Me.ModifierLentitéToolStripMenuItem, Me.RenomerToolStripMenuItem, Me.SupprimerLentitéToolStripMenuItem})
        Me.oCnt_Org.Name = "oCnt_Org"
        Me.oCnt_Org.Size = New System.Drawing.Size(202, 108)
        '
        'AjouterUneEntitéToolStripMenuItem
        '
        Me.AjouterUneEntitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.insert
        Me.AjouterUneEntitéToolStripMenuItem.Name = "AjouterUneEntitéToolStripMenuItem"
        Me.AjouterUneEntitéToolStripMenuItem.Size = New System.Drawing.Size(201, 26)
        Me.AjouterUneEntitéToolStripMenuItem.Text = "Ajouter une Entité"
        '
        'ModifierLentitéToolStripMenuItem
        '
        Me.ModifierLentitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Modifier
        Me.ModifierLentitéToolStripMenuItem.Name = "ModifierLentitéToolStripMenuItem"
        Me.ModifierLentitéToolStripMenuItem.Size = New System.Drawing.Size(201, 26)
        Me.ModifierLentitéToolStripMenuItem.Text = "Modifier l'entité"
        '
        'RenomerToolStripMenuItem
        '
        Me.RenomerToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.OF_Replanifie
        Me.RenomerToolStripMenuItem.Name = "RenomerToolStripMenuItem"
        Me.RenomerToolStripMenuItem.Size = New System.Drawing.Size(201, 26)
        Me.RenomerToolStripMenuItem.Text = "Renomer"
        '
        'SupprimerLentitéToolStripMenuItem
        '
        Me.SupprimerLentitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.supprimerligne
        Me.SupprimerLentitéToolStripMenuItem.Name = "SupprimerLentitéToolStripMenuItem"
        Me.SupprimerLentitéToolStripMenuItem.Size = New System.Drawing.Size(201, 26)
        Me.SupprimerLentitéToolStripMenuItem.Text = "Supprimer l'entité"
        '
        'Header
        '
        Me.Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Header.ColumnCount = 3
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 312.0!))
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Header.Controls.Add(Me.Search_pnl, 2, 0)
        Me.Header.Controls.Add(Me.OuvrirParNiveau_cbo, 0, 0)
        Me.Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header.Location = New System.Drawing.Point(0, 0)
        Me.Header.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Header.Name = "Header"
        Me.Header.RowCount = 1
        Me.Header.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Header.Size = New System.Drawing.Size(1250, 56)
        Me.Header.TabIndex = 1
        '
        'Search_pnl
        '
        Me.Search_pnl.BackColor = System.Drawing.Color.White
        Me.Search_pnl.ColumnCount = 2
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.Search_pnl.Controls.Add(Me.Search_pb, 1, 0)
        Me.Search_pnl.Controls.Add(Me.Search_txt, 0, 0)
        Me.Search_pnl.Location = New System.Drawing.Point(441, 6)
        Me.Search_pnl.Margin = New System.Windows.Forms.Padding(4, 6, 4, 0)
        Me.Search_pnl.Name = "Search_pnl"
        Me.Search_pnl.RowCount = 1
        Me.Search_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.Size = New System.Drawing.Size(368, 44)
        Me.Search_pnl.TabIndex = 1
        '
        'Search_pb
        '
        Me.Search_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Search_pb.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.Search_pb.Location = New System.Drawing.Point(328, 4)
        Me.Search_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Search_pb.Name = "Search_pb"
        Me.Search_pb.Size = New System.Drawing.Size(36, 36)
        Me.Search_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Search_pb.TabIndex = 4
        Me.Search_pb.TabStop = False
        Me.Search_pb.Tag = "false"
        '
        'Search_txt
        '
        Me.Search_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Search_txt.ContextMenuStrip = Nothing
        Me.Search_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Search_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Search_txt.Location = New System.Drawing.Point(8, 8)
        Me.Search_txt.Margin = New System.Windows.Forms.Padding(8, 8, 8, 8)
        Me.Search_txt.MaxLength = 32767
        Me.Search_txt.Multiline = False
        Me.Search_txt.Name = "Search_txt"
        Me.Search_txt.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Search_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Search_txt.ReadOnly = False
        Me.Search_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Search_txt.SelectionStart = 0
        Me.Search_txt.Size = New System.Drawing.Size(308, 28)
        Me.Search_txt.TabIndex = 2
        Me.Search_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Search_txt.UseSystemPasswordChar = False
        '
        'OuvrirParNiveau_cbo
        '
        Me.OuvrirParNiveau_cbo.DataSource = Nothing
        Me.OuvrirParNiveau_cbo.DisplayMember = ""
        Me.OuvrirParNiveau_cbo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OuvrirParNiveau_cbo.DroppedDown = False
        Me.OuvrirParNiveau_cbo.Location = New System.Drawing.Point(4, 14)
        Me.OuvrirParNiveau_cbo.Margin = New System.Windows.Forms.Padding(4, 14, 4, 5)
        Me.OuvrirParNiveau_cbo.Name = "OuvrirParNiveau_cbo"
        Me.OuvrirParNiveau_cbo.SelectedIndex = -1
        Me.OuvrirParNiveau_cbo.SelectedItem = Nothing
        Me.OuvrirParNiveau_cbo.SelectedValue = Nothing
        Me.OuvrirParNiveau_cbo.Size = New System.Drawing.Size(304, 37)
        Me.OuvrirParNiveau_cbo.TabIndex = 2
        Me.OuvrirParNiveau_cbo.ValueMember = ""
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(832, 56)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 506)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'Org_Affectation_RH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1250, 562)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Adv)
        Me.Controls.Add(Me.Adv_NonAffecte)
        Me.Controls.Add(Me.Header)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Org_Affectation_RH"
        Me.Tag = "ECR"
        Me.Text = "Affectation des ressources humaines"
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.oCnt_RH.ResumeLayout(False)
        CType(Me.Adv_NonAffecte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.oCnt_Org.ResumeLayout(False)
        Me.Header.ResumeLayout(False)
        Me.Search_pnl.ResumeLayout(False)
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Adv As DevComponents.AdvTree.AdvTree
    Friend WithEvents nSoc As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents oCnt_RH As ContextMenuStrip
    Friend WithEvents DésignerEnTantQueResponableDeLEntitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsulterLaFicheDeLAgentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Adv_NonAffecte As DevComponents.AdvTree.AdvTree
    Friend WithEvents ndSocNonAffecte As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle4 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents oCnt_Org As ContextMenuStrip
    Friend WithEvents RenomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjouterUneEntitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModifierLentitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupprimerLentitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents imgList As ImageList
    Friend WithEvents Header As TableLayoutPanel
    Friend WithEvents Search_pnl As TableLayoutPanel
    Friend WithEvents Search_pb As PictureBox
    Friend WithEvents Search_txt As ud_TextBox
    Friend WithEvents OuvrirParNiveau_cbo As ud_ComboBox
    Friend WithEvents Splitter1 As Splitter
End Class
