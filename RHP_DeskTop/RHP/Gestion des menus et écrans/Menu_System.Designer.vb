<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Menu_System
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_System))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Menu opérationnel")
        Me.LHH = New System.Windows.Forms.Label()
        Me.LHF = New System.Windows.Forms.Label()
        Me.LHR = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Trv = New System.Windows.Forms.TreeView()
        Me.Ud_Content = New RHP.ud_Panel()
        Me.Ud_Content.SuspendLayout()
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
        Me.LHF.Location = New System.Drawing.Point(0, 543)
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
        Me.LHR.Size = New System.Drawing.Size(1, 542)
        Me.LHR.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "btn_specifique.png")
        Me.ImageList1.Images.SetKeyName(1, "autres.png")
        Me.ImageList1.Images.SetKeyName(2, "btn_fdr.png")
        Me.ImageList1.Images.SetKeyName(3, "btn_circle.png")
        Me.ImageList1.Images.SetKeyName(4, "query.png")
        Me.ImageList1.Images.SetKeyName(5, "printer.png")
        Me.ImageList1.Images.SetKeyName(6, "btn_fdr.png")
        Me.ImageList1.Images.SetKeyName(7, "btn_circle_on.png")
        '
        'Trv
        '
        Me.Trv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Trv.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
        Me.Trv.ForeColor = System.Drawing.Color.Gray
        Me.Trv.ImageIndex = 0
        Me.Trv.ImageList = Me.ImageList1
        Me.Trv.ItemHeight = 30
        Me.Trv.Location = New System.Drawing.Point(0, 0)
        Me.Trv.Name = "Trv"
        TreeNode1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        TreeNode1.Name = "Nd"
        TreeNode1.Text = "Menu opérationnel"
        Me.Trv.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.Trv.SelectedImageIndex = 0
        Me.Trv.Size = New System.Drawing.Size(1387, 544)
        Me.Trv.TabIndex = 11
        '
        'Ud_Content
        '
        Me.Ud_Content.AutoScroll = True
        Me.Ud_Content.BorderColor = System.Drawing.Color.White
        Me.Ud_Content.BorderSize = 2
        Me.Ud_Content.Controls.Add(Me.Trv)
        Me.Ud_Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Content.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Content.Name = "Ud_Content"
        Me.Ud_Content.Size = New System.Drawing.Size(1387, 544)
        Me.Ud_Content.TabIndex = 0
        '
        'Menu_System
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1387, 544)
        Me.Controls.Add(Me.LHR)
        Me.Controls.Add(Me.LHF)
        Me.Controls.Add(Me.LHH)
        Me.Controls.Add(Me.Ud_Content)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Menu_System"
        Me.Text = "Système"
        Me.Ud_Content.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LHH As Label
    Friend WithEvents LHF As Label
    Friend WithEvents LHR As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Trv As TreeView
    Friend WithEvents Ud_Content As ud_Panel
End Class
