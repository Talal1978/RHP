<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Profile_Scripts
    inherits Ecran

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
        Me.Adv = New DevComponents.AdvTree.AdvTree()
        Me.oMenu = New DevComponents.AdvTree.ColumnHeader()
        Me.oVisible = New DevComponents.AdvTree.ColumnHeader()
        Me.oActif = New DevComponents.AdvTree.ColumnHeader()
        Me.Profile = New DevComponents.AdvTree.Node()
        Me.Ecran_nd = New DevComponents.AdvTree.Node()
        Me.Cell1 = New DevComponents.AdvTree.Cell()
        Me.Cell2 = New DevComponents.AdvTree.Cell()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.entete_pnl = New System.Windows.Forms.Panel()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.entete_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Adv.Columns.Add(Me.oMenu)
        Me.Adv.Columns.Add(Me.oVisible)
        Me.Adv.Columns.Add(Me.oActif)
        Me.Adv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Adv.Location = New System.Drawing.Point(2, 40)
        Me.Adv.Name = "Adv"
        Me.Adv.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Profile})
        Me.Adv.NodesConnector = Me.NodeConnector1
        Me.Adv.NodeStyle = Me.ElementStyle1
        Me.Adv.PathSeparator = ";"
        Me.Adv.Size = New System.Drawing.Size(527, 328)
        Me.Adv.Styles.Add(Me.ElementStyle1)
        Me.Adv.TabIndex = 1
        Me.Adv.Text = "Adv"
        '
        'oMenu
        '
        Me.oMenu.Name = "oMenu"
        Me.oMenu.Text = "Accès"
        Me.oMenu.Width.Relative = 82
        '
        'oVisible
        '
        Me.oVisible.Name = "oVisible"
        Me.oVisible.Text = "Visible"
        Me.oVisible.Width.Absolute = 40
        '
        'oActif
        '
        Me.oActif.Name = "oActif"
        Me.oActif.Text = "Actif"
        Me.oActif.Width.Absolute = 40
        '
        'Profile
        '
        Me.Profile.Expanded = True
        Me.Profile.Image = Global.RHP.My.Resources.Resources.RH
        Me.Profile.Name = "Profile"
        Me.Profile.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Ecran_nd})
        Me.Profile.Text = "Profile"
        '
        'Ecran_nd
        '
        Me.Ecran_nd.Cells.Add(Me.Cell1)
        Me.Ecran_nd.Cells.Add(Me.Cell2)
        Me.Ecran_nd.Expanded = True
        Me.Ecran_nd.Image = Global.RHP.My.Resources.Resources.script_small
        Me.Ecran_nd.Name = "Ecran_nd"
        Me.Ecran_nd.Text = "Ecran"
        '
        'Cell1
        '
        Me.Cell1.CheckBoxVisible = True
        Me.Cell1.Name = "Cell1"
        Me.Cell1.StyleMouseOver = Nothing
        '
        'Cell2
        '
        Me.Cell2.CheckBoxVisible = True
        Me.Cell2.Name = "Cell2"
        Me.Cell2.StyleMouseOver = Nothing
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
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(485, 38)
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.Text = "Gestion des accès par écran"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'entete_pnl
        '
        Me.entete_pnl.Controls.Add(Me.Titre_lbl)
        Me.entete_pnl.Controls.Add(Me.Close_pb)
        Me.entete_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.entete_pnl.Location = New System.Drawing.Point(2, 2)
        Me.entete_pnl.Name = "entete_pnl"
        Me.entete_pnl.Size = New System.Drawing.Size(527, 38)
        Me.entete_pnl.TabIndex = 34
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Dock = System.Windows.Forms.DockStyle.Right
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.Location = New System.Drawing.Point(485, 0)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(42, 38)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 34
        Me.Close_pb.TabStop = False
        '
        'Zoom_Profile_Scripts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(531, 370)
        Me.Controls.Add(Me.Adv)
        Me.Controls.Add(Me.entete_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Zoom_Profile_Scripts"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Accès par écran"
        CType(Me.Adv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.entete_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Adv As DevComponents.AdvTree.AdvTree
    Friend WithEvents oMenu As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents oVisible As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents oActif As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Profile As DevComponents.AdvTree.Node
    Friend WithEvents Ecran_nd As DevComponents.AdvTree.Node
    Friend WithEvents Cell1 As DevComponents.AdvTree.Cell
    Friend WithEvents Cell2 As DevComponents.AdvTree.Cell
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents entete_pnl As Panel
    Friend WithEvents Close_pb As PictureBox
End Class
