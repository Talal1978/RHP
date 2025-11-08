<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Menu_Operationnel
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Menu opérationnel")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_Operationnel))
        Me.LHH = New System.Windows.Forms.Label()
        Me.LHF = New System.Windows.Forms.Label()
        Me.LHR = New System.Windows.Forms.Label()
        Me.Ud_Content = New RHP.ud_Panel()
        Me.Trv = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Recent_pb = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Plx_Recents = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Plx_Frequents = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.System_ud = New RHP.ud_CardItem()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Setting_ud = New RHP.ud_CardItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Organisation_ud = New RHP.ud_CardItem()
        Me.AdminPersonel_ud = New RHP.ud_CardItem()
        Me.Ud_Content.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Recent_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LHH
        '
        Me.LHH.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.LHH.Dock = System.Windows.Forms.DockStyle.Top
        Me.LHH.Location = New System.Drawing.Point(0, 0)
        Me.LHH.Name = "LHH"
        Me.LHH.Size = New System.Drawing.Size(1387, 1)
        Me.LHH.TabIndex = 0
        '
        'LHF
        '
        Me.LHF.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.LHF.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LHF.Location = New System.Drawing.Point(0, 599)
        Me.LHF.Name = "LHF"
        Me.LHF.Size = New System.Drawing.Size(1387, 1)
        Me.LHF.TabIndex = 1
        '
        'LHR
        '
        Me.LHR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.LHR.Dock = System.Windows.Forms.DockStyle.Right
        Me.LHR.Location = New System.Drawing.Point(1386, 1)
        Me.LHR.Name = "LHR"
        Me.LHR.Size = New System.Drawing.Size(1, 598)
        Me.LHR.TabIndex = 2
        '
        'Ud_Content
        '
        Me.Ud_Content.AutoScroll = True
        Me.Ud_Content.BorderColor = System.Drawing.Color.White
        Me.Ud_Content.BorderSize = 2
        Me.Ud_Content.Controls.Add(Me.Trv)
        Me.Ud_Content.Controls.Add(Me.Panel2)
        Me.Ud_Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Content.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Content.Name = "Ud_Content"
        Me.Ud_Content.Size = New System.Drawing.Size(1387, 600)
        Me.Ud_Content.TabIndex = 0
        '
        'Trv
        '
        Me.Trv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Trv.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
        Me.Trv.ForeColor = System.Drawing.Color.DimGray
        Me.Trv.ImageIndex = 0
        Me.Trv.ImageList = Me.ImageList1
        Me.Trv.ItemHeight = 30
        Me.Trv.Location = New System.Drawing.Point(729, 0)
        Me.Trv.Name = "Trv"
        TreeNode1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        TreeNode1.Name = "Nd"
        TreeNode1.Text = "Menu opérationnel"
        Me.Trv.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.Trv.SelectedImageIndex = 0
        Me.Trv.Size = New System.Drawing.Size(658, 600)
        Me.Trv.TabIndex = 11
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "btn_men.png")
        Me.ImageList1.Images.SetKeyName(1, "btn_orga.png")
        Me.ImageList1.Images.SetKeyName(2, "btn_settings.png")
        Me.ImageList1.Images.SetKeyName(3, "btn_gear.png")
        Me.ImageList1.Images.SetKeyName(4, "btn_autres.png")
        Me.ImageList1.Images.SetKeyName(5, "btn_fdr.png")
        Me.ImageList1.Images.SetKeyName(6, "btn_circle.png")
        Me.ImageList1.Images.SetKeyName(7, "btn_queries.png")
        Me.ImageList1.Images.SetKeyName(8, "btn_printing.png")
        Me.ImageList1.Images.SetKeyName(9, "btn_circle_on.png")
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Recent_pb)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Plx_Recents)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Plx_Frequents)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(729, 600)
        Me.Panel2.TabIndex = 12
        '
        'Recent_pb
        '
        Me.Recent_pb.Image = CType(resources.GetObject("Recent_pb.Image"), System.Drawing.Image)
        Me.Recent_pb.Location = New System.Drawing.Point(5, 212)
        Me.Recent_pb.Name = "Recent_pb"
        Me.Recent_pb.Size = New System.Drawing.Size(25, 25)
        Me.Recent_pb.TabIndex = 0
        Me.Recent_pb.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.RHP.My.Resources.Resources.ud_recents
        Me.PictureBox1.Location = New System.Drawing.Point(5, 386)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(34, 219)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Accès fréquents"
        '
        'Plx_Recents
        '
        Me.Plx_Recents.Location = New System.Drawing.Point(3, 405)
        Me.Plx_Recents.Name = "Plx_Recents"
        Me.Plx_Recents.Size = New System.Drawing.Size(726, 137)
        Me.Plx_Recents.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(34, 393)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Accès récents"
        '
        'Plx_Frequents
        '
        Me.Plx_Frequents.Location = New System.Drawing.Point(3, 235)
        Me.Plx_Frequents.Name = "Plx_Frequents"
        Me.Plx_Frequents.Size = New System.Drawing.Size(726, 134)
        Me.Plx_Frequents.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.System_ud)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.Setting_ud)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Organisation_ud)
        Me.Panel1.Controls.Add(Me.AdminPersonel_ud)
        Me.Panel1.Location = New System.Drawing.Point(3, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(726, 171)
        Me.Panel1.TabIndex = 10
        '
        'System_ud
        '
        Me.System_ud.Image = Global.RHP.My.Resources.Resources.ud_system
        Me.System_ud.isSelected = False
        Me.System_ud.Location = New System.Drawing.Point(534, 46)
        Me.System_ud.Name = "System_ud"
        Me.System_ud.Size = New System.Drawing.Size(166, 100)
        Me.System_ud.TabIndex = 3
        Me.System_ud.Titre = "Système"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'Setting_ud
        '
        Me.Setting_ud.Image = CType(resources.GetObject("Setting_ud.Image"), System.Drawing.Image)
        Me.Setting_ud.isSelected = False
        Me.Setting_ud.Location = New System.Drawing.Point(357, 46)
        Me.Setting_ud.Name = "Setting_ud"
        Me.Setting_ud.Size = New System.Drawing.Size(166, 100)
        Me.Setting_ud.TabIndex = 2
        Me.Setting_ud.Titre = "Paramétrages && imports"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(32, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Menus opérationnels"
        '
        'Organisation_ud
        '
        Me.Organisation_ud.Image = Global.RHP.My.Resources.Resources.ud_Organisation
        Me.Organisation_ud.isSelected = False
        Me.Organisation_ud.Location = New System.Drawing.Point(180, 46)
        Me.Organisation_ud.Name = "Organisation_ud"
        Me.Organisation_ud.Size = New System.Drawing.Size(166, 100)
        Me.Organisation_ud.TabIndex = 2
        Me.Organisation_ud.Titre = "Organisation && développement RH"
        '
        'AdminPersonel_ud
        '
        Me.AdminPersonel_ud.Image = CType(resources.GetObject("AdminPersonel_ud.Image"), System.Drawing.Image)
        Me.AdminPersonel_ud.isSelected = False
        Me.AdminPersonel_ud.Location = New System.Drawing.Point(3, 46)
        Me.AdminPersonel_ud.Name = "AdminPersonel_ud"
        Me.AdminPersonel_ud.Size = New System.Drawing.Size(166, 100)
        Me.AdminPersonel_ud.TabIndex = 2
        Me.AdminPersonel_ud.Titre = "Gestion administrative du personnel"
        '
        'Menu_Operationnel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1387, 600)
        Me.Controls.Add(Me.LHR)
        Me.Controls.Add(Me.LHF)
        Me.Controls.Add(Me.LHH)
        Me.Controls.Add(Me.Ud_Content)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Menu_Operationnel"
        Me.Text = "Menu_Browser"
        Me.Ud_Content.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Recent_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Ud_Content As ud_Panel
    Friend WithEvents LHH As Label
    Friend WithEvents LHF As Label
    Friend WithEvents LHR As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Recent_pb As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Plx_Frequents As Panel
    Friend WithEvents Setting_ud As ud_CardItem
    Friend WithEvents Organisation_ud As ud_CardItem
    Friend WithEvents AdminPersonel_ud As ud_CardItem
    Friend WithEvents Trv As TreeView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents System_ud As ud_CardItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Plx_Recents As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
End Class
