<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_GED
    Inherits System.Windows.Forms.Form

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Zoom_GED))
        Me.Lv = New System.Windows.Forms.ListView()
        Me.FD_Alias = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.File_Path = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Dat_Crea = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Taille = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Name_Ecran = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Value_Index = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Created_By = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImgXL = New System.Windows.Forms.ImageList(Me.components)
        Me.ImgSL = New System.Windows.Forms.ImageList(Me.components)
        Me.ImgTrv = New System.Windows.Forms.ImageList(Me.components)
        Me.Trv = New DevComponents.AdvTree.AdvTree()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NouveauDossierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjouterUnFichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenommerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RafraichirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.nEcran = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Entete_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNB = New System.Windows.Forms.Label()
        Me.back_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Search_pb = New System.Windows.Forms.PictureBox()
        Me.Search_txt = New ud_TextBox()
        Me.Path_txt = New ud_TextBox()
        CType(Me.Trv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Entete_pnl.SuspendLayout()
        CType(Me.back_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lv
        '
        Me.Lv.AllowDrop = True
        Me.Lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FD_Alias, Me.File_Path, Me.Dat_Crea, Me.Taille, Me.Name_Ecran, Me.Value_Index, Me.Created_By})
        Me.Lv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lv.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lv.HideSelection = False
        Me.Lv.LargeImageList = Me.ImgXL
        Me.Lv.Location = New System.Drawing.Point(378, 32)
        Me.Lv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lv.Name = "Lv"
        Me.Lv.Size = New System.Drawing.Size(691, 585)
        Me.Lv.SmallImageList = Me.ImgSL
        Me.Lv.TabIndex = 1
        Me.Lv.UseCompatibleStateImageBehavior = False
        Me.Lv.View = System.Windows.Forms.View.Details
        '
        'FD_Alias
        '
        Me.FD_Alias.Text = "Nom de fichier"
        Me.FD_Alias.Width = 200
        '
        'File_Path
        '
        Me.File_Path.Text = "Emplacement"
        Me.File_Path.Width = 80
        '
        'Dat_Crea
        '
        Me.Dat_Crea.Text = "Date"
        Me.Dat_Crea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Crea.Width = 80
        '
        'Taille
        '
        Me.Taille.Text = "Taille"
        Me.Taille.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Name_Ecran
        '
        Me.Name_Ecran.Text = "Objet lié"
        Me.Name_Ecran.Width = 100
        '
        'Value_Index
        '
        Me.Value_Index.Text = "Référence"
        Me.Value_Index.Width = 100
        '
        'Created_By
        '
        Me.Created_By.Text = "Créé par"
        Me.Created_By.Width = 200
        '
        'ImgXL
        '
        Me.ImgXL.ImageStream = CType(resources.GetObject("ImgXL.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgXL.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgXL.Images.SetKeyName(0, "kisspng-emoji-file-folders-directory-computer-icons-txt-file-5acd8ad8c2a790.35100" &
        "68315234198647973.png")
        Me.ImgXL.Images.SetKeyName(1, "kisspng-emoji-file-folders-directory-computer-icons-txt-file-5acd8ad8c2a790.35100" &
        "68315234198647973.png")
        '
        'ImgSL
        '
        Me.ImgSL.ImageStream = CType(resources.GetObject("ImgSL.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgSL.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgSL.Images.SetKeyName(0, "kisspng-emoji-file-folders-directory-computer-icons-txt-file-5acd8ad8c2a790.35100" &
        "68315234198647973.png")
        Me.ImgSL.Images.SetKeyName(1, "kisspng-emoji-file-folders-directory-computer-icons-txt-file-5acd8ad8c2a790.35100" &
        "68315234198647973.png")
        '
        'ImgTrv
        '
        Me.ImgTrv.ImageStream = CType(resources.GetObject("ImgTrv.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgTrv.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgTrv.Images.SetKeyName(0, "fdr_1.png")
        Me.ImgTrv.Images.SetKeyName(1, "fdr_0.png")
        '
        'Trv
        '
        Me.Trv.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.Trv.AllowDrop = True
        Me.Trv.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.Trv.BackgroundStyle.Class = "TreeBorderKey"
        Me.Trv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Trv.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Trv.Dock = System.Windows.Forms.DockStyle.Left
        Me.Trv.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Trv.ImageList = Me.ImgTrv
        Me.Trv.Location = New System.Drawing.Point(2, 32)
        Me.Trv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Trv.Name = "Trv"
        Me.Trv.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.nEcran})
        Me.Trv.NodesConnector = Me.NodeConnector1
        Me.Trv.NodeStyle = Me.ElementStyle1
        Me.Trv.PathSeparator = ";"
        Me.Trv.Size = New System.Drawing.Size(376, 585)
        Me.Trv.Styles.Add(Me.ElementStyle1)
        Me.Trv.TabIndex = 3
        Me.Trv.Text = "AdvTree1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouveauDossierToolStripMenuItem, Me.AjouterUnFichierToolStripMenuItem, Me.OuvrirToolStripMenuItem, Me.RenommerToolStripMenuItem, Me.SupprimerToolStripMenuItem, Me.RafraichirToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(171, 160)
        '
        'NouveauDossierToolStripMenuItem
        '
        Me.NouveauDossierToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.fdr_0
        Me.NouveauDossierToolStripMenuItem.Name = "NouveauDossierToolStripMenuItem"
        Me.NouveauDossierToolStripMenuItem.Size = New System.Drawing.Size(170, 26)
        Me.NouveauDossierToolStripMenuItem.Text = "Nouveau dossier"
        '
        'AjouterUnFichierToolStripMenuItem
        '
        Me.AjouterUnFichierToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Roll_forward
        Me.AjouterUnFichierToolStripMenuItem.Name = "AjouterUnFichierToolStripMenuItem"
        Me.AjouterUnFichierToolStripMenuItem.Size = New System.Drawing.Size(170, 26)
        Me.AjouterUnFichierToolStripMenuItem.Text = "Ajouter un fichier"
        '
        'OuvrirToolStripMenuItem
        '
        Me.OuvrirToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.fdr_1
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        Me.OuvrirToolStripMenuItem.Size = New System.Drawing.Size(170, 26)
        Me.OuvrirToolStripMenuItem.Text = "Ouvrir"
        '
        'RenommerToolStripMenuItem
        '
        Me.RenommerToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Modifier
        Me.RenommerToolStripMenuItem.Name = "RenommerToolStripMenuItem"
        Me.RenommerToolStripMenuItem.Size = New System.Drawing.Size(170, 26)
        Me.RenommerToolStripMenuItem.Text = "Renommer"
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.supprimerligne
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(170, 26)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'RafraichirToolStripMenuItem
        '
        Me.RafraichirToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.Actualiser
        Me.RafraichirToolStripMenuItem.Name = "RafraichirToolStripMenuItem"
        Me.RafraichirToolStripMenuItem.Size = New System.Drawing.Size(170, 26)
        Me.RafraichirToolStripMenuItem.Text = "Rafraichir"
        '
        'nEcran
        '
        Me.nEcran.Expanded = True
        Me.nEcran.ImageIndex = 0
        Me.nEcran.Name = "nEcran"
        Me.nEcran.Text = "Node1"
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
        'Entete_pnl
        '
        Me.Entete_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Entete_pnl.ColumnCount = 6
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Entete_pnl.Controls.Add(Me.lblNB, 2, 0)
        Me.Entete_pnl.Controls.Add(Me.back_pb, 0, 0)
        Me.Entete_pnl.Controls.Add(Me.Close_pb, 5, 0)
        Me.Entete_pnl.Controls.Add(Me.Search_pb, 4, 0)
        Me.Entete_pnl.Controls.Add(Me.Search_txt, 3, 0)
        Me.Entete_pnl.Controls.Add(Me.Path_txt, 1, 0)
        Me.Entete_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Entete_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Entete_pnl.Name = "Entete_pnl"
        Me.Entete_pnl.RowCount = 1
        Me.Entete_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Entete_pnl.Size = New System.Drawing.Size(1067, 30)
        Me.Entete_pnl.TabIndex = 4
        '
        'lblNB
        '
        Me.lblNB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNB.ForeColor = System.Drawing.Color.White
        Me.lblNB.Location = New System.Drawing.Point(710, 0)
        Me.lblNB.Name = "lblNB"
        Me.lblNB.Size = New System.Drawing.Size(94, 30)
        Me.lblNB.TabIndex = 0
        Me.lblNB.Text = "0 élément"
        Me.lblNB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'back_pb
        '
        Me.back_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.back_pb.Image = Global.RHP.My.Resources.Resources.btn_div_back_w
        Me.back_pb.InitialImage = Nothing
        Me.back_pb.Location = New System.Drawing.Point(3, 3)
        Me.back_pb.Name = "back_pb"
        Me.back_pb.Size = New System.Drawing.Size(24, 24)
        Me.back_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.back_pb.TabIndex = 38
        Me.back_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(1040, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 24)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 35
        Me.Close_pb.TabStop = False
        '
        'Search_pb
        '
        Me.Search_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Search_pb.Image = Global.RHP.My.Resources.Resources.btn_search_w
        Me.Search_pb.InitialImage = Nothing
        Me.Search_pb.Location = New System.Drawing.Point(1010, 3)
        Me.Search_pb.Name = "Search_pb"
        Me.Search_pb.Size = New System.Drawing.Size(24, 24)
        Me.Search_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Search_pb.TabIndex = 35
        Me.Search_pb.TabStop = False
        '
        'Search_txt
        '
        Me.Search_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Search_txt.Location = New System.Drawing.Point(810, 3)
        Me.Search_txt.Multiline = True
        Me.Search_txt.Name = "Search_txt"
        Me.Search_txt.Size = New System.Drawing.Size(194, 24)
        Me.Search_txt.TabIndex = 36
        '
        'Path_txt
        '
        Me.Path_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Path_txt.Enabled = False
        Me.Path_txt.Location = New System.Drawing.Point(33, 3)
        Me.Path_txt.Multiline = True
        Me.Path_txt.Name = "Path_txt"
        Me.Path_txt.ReadOnly = True
        Me.Path_txt.Size = New System.Drawing.Size(671, 24)
        Me.Path_txt.TabIndex = 37
        '
        'Zoom_GED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1071, 619)
        Me.Controls.Add(Me.Lv)
        Me.Controls.Add(Me.Trv)
        Me.Controls.Add(Me.Entete_pnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Zoom_GED"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Zoom"
        CType(Me.Trv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Entete_pnl.ResumeLayout(False)
        Me.Entete_pnl.PerformLayout()
        CType(Me.back_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Search_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lv As System.Windows.Forms.ListView
    Friend WithEvents FD_Alias As System.Windows.Forms.ColumnHeader
    Friend WithEvents Dat_Crea As System.Windows.Forms.ColumnHeader
    Friend WithEvents Taille As System.Windows.Forms.ColumnHeader
    Friend WithEvents Name_Ecran As System.Windows.Forms.ColumnHeader
    Friend WithEvents Value_Index As System.Windows.Forms.ColumnHeader
    Friend WithEvents Created_By As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImgSL As ImageList
    Friend WithEvents ImgXL As ImageList
    Friend WithEvents ImgTrv As ImageList
    Friend WithEvents Trv As DevComponents.AdvTree.AdvTree
    Friend WithEvents nEcran As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents NouveauDossierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjouterUnFichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OuvrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RenommerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupprimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RafraichirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents File_Path As ColumnHeader
    Friend WithEvents Entete_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Search_pb As PictureBox
    Friend WithEvents Search_txt as ud_TextBox
    Friend WithEvents back_pb As PictureBox
    Friend WithEvents Path_txt as ud_TextBox
    Friend WithEvents lblNB As Label
End Class
