<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Alerte
    Inherits Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Zoom_Alerte))
        Me.AlertText = New DevComponents.DotNetBar.LabelX()
        Me.buttonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.MsgNum = New DevComponents.DotNetBar.LabelItem()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AlertText
        '
        Me.AlertText.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.AlertText.BackgroundStyle.Class = ""
        Me.AlertText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AlertText.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AlertText.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.AlertText.Location = New System.Drawing.Point(64, 34)
        Me.AlertText.Name = "AlertText"
        Me.AlertText.Size = New System.Drawing.Size(223, 99)
        Me.AlertText.TabIndex = 12
        Me.AlertText.Text = "..."
        Me.AlertText.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.AlertText.WordWrap = True
        '
        'buttonItem2
        '
        Me.buttonItem2.Image = CType(resources.GetObject("buttonItem2.Image"), System.Drawing.Image)
        Me.buttonItem2.Name = "buttonItem2"
        Me.buttonItem2.Text = "buttonItem2"
        '
        'buttonItem1
        '
        Me.buttonItem1.Image = CType(resources.GetObject("buttonItem1.Image"), System.Drawing.Image)
        Me.buttonItem1.Name = "buttonItem1"
        Me.buttonItem1.Text = "buttonItem1"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "buttonItem2"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.Image = CType(resources.GetObject("ButtonItem4.Image"), System.Drawing.Image)
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Text = "buttonItem1"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.Image = CType(resources.GetObject("ButtonItem5.Image"), System.Drawing.Image)
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Text = "buttonItem1"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.Image = CType(resources.GetObject("ButtonItem6.Image"), System.Drawing.Image)
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Text = "buttonItem2"
        '
        'MsgNum
        '
        Me.MsgNum.Name = "MsgNum"
        Me.MsgNum.Stretch = True
        Me.MsgNum.Text = "LabelItem1"
        Me.MsgNum.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(262, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(25, 25)
        Me.Close_pb.TabIndex = 15
        Me.Close_pb.TabStop = False
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.PictureBox1)
        Me.Pnl.Controls.Add(Me.Close_pb)
        Me.Pnl.Controls.Add(Me.AlertText)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 2)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Padding = New System.Windows.Forms.Padding(2)
        Me.Pnl.Size = New System.Drawing.Size(292, 140)
        Me.Pnl.TabIndex = 16
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.RHP.My.Resources.Resources.mail
        Me.PictureBox1.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(54, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'Zoom_Alerte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(296, 144)
        Me.Controls.Add(Me.Pnl)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Alerte"
        Me.Padding = New System.Windows.Forms.Padding(2)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AlertText As DevComponents.DotNetBar.LabelX
    Friend WithEvents buttonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents buttonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MsgNum As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Pnl As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
