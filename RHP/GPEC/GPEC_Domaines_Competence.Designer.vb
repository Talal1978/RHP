<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GPEC_Domaines_Competence
    Inherits Ecran

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GPEC_Domaines_Competence))
        Me.Adv = New DevComponents.AdvTree.AdvTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.nSoc = New DevComponents.AdvTree.Node()
        Me.oCnt_Org = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AjouterUneEntitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModifierLentitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupprimerLentitéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Header = New System.Windows.Forms.TableLayoutPanel()
        Me.Search_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Search_pb = New System.Windows.Forms.PictureBox()
        Me.Search_txt = New RHP.ud_TextBox()
        Me.Descriptif_rtb = New RHP.ud_RichTextBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Adv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Adv.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Adv.ImageList = Me.imgList
        Me.Adv.Location = New System.Drawing.Point(0, 45)
        Me.Adv.Name = "Adv"
        Me.Adv.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.nSoc})
        Me.Adv.NodesConnector = Me.NodeConnector1
        Me.Adv.NodeSpacing = 8
        Me.Adv.NodeStyle = Me.ElementStyle1
        Me.Adv.PathSeparator = ";"
        Me.Adv.Size = New System.Drawing.Size(421, 405)
        Me.Adv.Styles.Add(Me.ElementStyle1)
        Me.Adv.TabIndex = 9
        Me.Adv.Text = "AdvTree1"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Organisation"
        Me.ColumnHeader1.Width.Absolute = 600
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "trv_societe.png")
        Me.imgList.Images.SetKeyName(1, "btn_folder_small.png")
        Me.imgList.Images.SetKeyName(2, "btn_circle.png")
        '
        'nSoc
        '
        Me.nSoc.ContextMenu = Me.oCnt_Org
        Me.nSoc.Expanded = True
        Me.nSoc.ImageIndex = 0
        Me.nSoc.Name = "nSoc"
        Me.nSoc.Text = "Node1"
        '
        'oCnt_Org
        '
        Me.oCnt_Org.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.oCnt_Org.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AjouterUneEntitéToolStripMenuItem, Me.ModifierLentitéToolStripMenuItem, Me.RenomerToolStripMenuItem, Me.SupprimerLentitéToolStripMenuItem})
        Me.oCnt_Org.Name = "oCnt_Org"
        Me.oCnt_Org.Size = New System.Drawing.Size(134, 108)
        '
        'AjouterUneEntitéToolStripMenuItem
        '
        Me.AjouterUneEntitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.insert
        Me.AjouterUneEntitéToolStripMenuItem.Name = "AjouterUneEntitéToolStripMenuItem"
        Me.AjouterUneEntitéToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.AjouterUneEntitéToolStripMenuItem.Text = "Ajouter"
        '
        'ModifierLentitéToolStripMenuItem
        '
        Me.ModifierLentitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Modifier
        Me.ModifierLentitéToolStripMenuItem.Name = "ModifierLentitéToolStripMenuItem"
        Me.ModifierLentitéToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.ModifierLentitéToolStripMenuItem.Text = "Modifier"
        '
        'RenomerToolStripMenuItem
        '
        Me.RenomerToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.OF_Replanifie
        Me.RenomerToolStripMenuItem.Name = "RenomerToolStripMenuItem"
        Me.RenomerToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.RenomerToolStripMenuItem.Text = "Renomer"
        '
        'SupprimerLentitéToolStripMenuItem
        '
        Me.SupprimerLentitéToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.supprimerligne
        Me.SupprimerLentitéToolStripMenuItem.Name = "SupprimerLentitéToolStripMenuItem"
        Me.SupprimerLentitéToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.SupprimerLentitéToolStripMenuItem.Text = "Supprimer"
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
        'Header
        '
        Me.Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Header.ColumnCount = 1
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Header.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Header.Controls.Add(Me.Search_pnl, 0, 0)
        Me.Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header.Location = New System.Drawing.Point(0, 0)
        Me.Header.Name = "Header"
        Me.Header.RowCount = 1
        Me.Header.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Header.Size = New System.Drawing.Size(800, 45)
        Me.Header.TabIndex = 10
        '
        'Search_pnl
        '
        Me.Search_pnl.BackColor = System.Drawing.Color.White
        Me.Search_pnl.ColumnCount = 2
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.Search_pnl.Controls.Add(Me.Search_pb, 1, 0)
        Me.Search_pnl.Controls.Add(Me.Search_txt, 0, 0)
        Me.Search_pnl.Location = New System.Drawing.Point(3, 5)
        Me.Search_pnl.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.Search_pnl.Name = "Search_pnl"
        Me.Search_pnl.RowCount = 1
        Me.Search_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Search_pnl.Size = New System.Drawing.Size(294, 35)
        Me.Search_pnl.TabIndex = 1
        '
        'Search_pb
        '
        Me.Search_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Search_pb.Image = Global.RHP.My.Resources.Resources.btn_search
        Me.Search_pb.Location = New System.Drawing.Point(262, 3)
        Me.Search_pb.Name = "Search_pb"
        Me.Search_pb.Size = New System.Drawing.Size(29, 29)
        Me.Search_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Search_pb.TabIndex = 4
        Me.Search_pb.TabStop = False
        Me.Search_pb.Tag = "false"
        '
        'Search_txt
        '
        Me.Search_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Search_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Search_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Search_txt.Location = New System.Drawing.Point(6, 6)
        Me.Search_txt.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Search_txt.MaxLength = 32767
        Me.Search_txt.Multiline = False
        Me.Search_txt.Name = "Search_txt"
        Me.Search_txt.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Search_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Search_txt.ReadOnly = False
        Me.Search_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Search_txt.SelectionStart = 0
        Me.Search_txt.Size = New System.Drawing.Size(247, 23)
        Me.Search_txt.TabIndex = 2
        Me.Search_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Search_txt.UseSystemPasswordChar = False
        '
        'Descriptif_rtb
        '
        Me.Descriptif_rtb.Dock = System.Windows.Forms.DockStyle.Right
        Me.Descriptif_rtb.Location = New System.Drawing.Point(421, 45)
        Me.Descriptif_rtb.Name = "Descriptif_rtb"
        Me.Descriptif_rtb.Size = New System.Drawing.Size(379, 405)
        Me.Descriptif_rtb.TabIndex = 1
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(418, 45)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 405)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'GPEC_Domaines_Competence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Adv)
        Me.Controls.Add(Me.Descriptif_rtb)
        Me.Controls.Add(Me.Header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GPEC_Domaines_Competence"
        Me.Tag = "ECR"
        Me.Text = "Référentiel des compétences"
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.oCnt_Org.ResumeLayout(False)
        Me.Header.ResumeLayout(False)
        Me.Search_pnl.ResumeLayout(False)
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Adv As DevComponents.AdvTree.AdvTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents nSoc As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents imgList As ImageList
    Friend WithEvents oCnt_Org As ContextMenuStrip
    Friend WithEvents AjouterUneEntitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModifierLentitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RenomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupprimerLentitéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Header As TableLayoutPanel
    Friend WithEvents Search_pnl As TableLayoutPanel
    Friend WithEvents Search_pb As PictureBox
    Friend WithEvents Search_txt As ud_TextBox
    Friend WithEvents Descriptif_rtb As ud_RichTextBox
    Friend WithEvents Splitter1 As Splitter
End Class
