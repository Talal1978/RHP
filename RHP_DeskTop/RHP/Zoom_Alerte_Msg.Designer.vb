<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Alerte_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Zoom_Alerte_Msg))
        Me.TextMsg = New DevComponents.DotNetBar.LabelX()
        Me.buttonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.reflectionImage1 = New System.Windows.Forms.PictureBox()
        Me.MsgNum = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TitreMsg = New System.Windows.Forms.Label()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        CType(Me.reflectionImage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextMsg
        '
        Me.TextMsg.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.TextMsg.BackgroundStyle.Class = ""
        Me.TextMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextMsg.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.TextMsg.Location = New System.Drawing.Point(66, 41)
        Me.TextMsg.Name = "TextMsg"
        Me.TextMsg.Size = New System.Drawing.Size(215, 75)
        Me.TextMsg.TabIndex = 12
        Me.TextMsg.Text = "Using Balloon and other controls included with DotNetBar you can create great loo" &
    "king custom alerts."
        Me.TextMsg.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.TextMsg.WordWrap = True
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
        'reflectionImage1
        '
        Me.reflectionImage1.BackColor = System.Drawing.Color.Transparent
        Me.reflectionImage1.Image = CType(resources.GetObject("reflectionImage1.Image"), System.Drawing.Image)
        Me.reflectionImage1.Location = New System.Drawing.Point(3, 41)
        Me.reflectionImage1.Name = "reflectionImage1"
        Me.reflectionImage1.Size = New System.Drawing.Size(57, 50)
        Me.reflectionImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.reflectionImage1.TabIndex = 14
        Me.reflectionImage1.TabStop = False
        '
        'MsgNum
        '
        Me.MsgNum.AutoSize = True
        Me.MsgNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.MsgNum.Location = New System.Drawing.Point(248, 122)
        Me.MsgNum.Name = "MsgNum"
        Me.MsgNum.Size = New System.Drawing.Size(0, 13)
        Me.MsgNum.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TitreMsg)
        Me.Panel1.Controls.Add(Me.Close_pb)
        Me.Panel1.Controls.Add(Me.reflectionImage1)
        Me.Panel1.Controls.Add(Me.MsgNum)
        Me.Panel1.Controls.Add(Me.TextMsg)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(292, 140)
        Me.Panel1.TabIndex = 16
        '
        'TitreMsg
        '
        Me.TitreMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitreMsg.Location = New System.Drawing.Point(7, 5)
        Me.TitreMsg.Name = "TitreMsg"
        Me.TitreMsg.Size = New System.Drawing.Size(250, 33)
        Me.TitreMsg.TabIndex = 17
        Me.TitreMsg.Text = "Titre"
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(263, 4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(25, 25)
        Me.Close_pb.TabIndex = 16
        Me.Close_pb.TabStop = False
        '
        'Zoom_Alerte_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(296, 144)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Zoom_Alerte_Msg"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.TopMost = True
        CType(Me.reflectionImage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextMsg As DevComponents.DotNetBar.LabelX
    Friend WithEvents buttonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents buttonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents reflectionImage1 As PictureBox
    Friend WithEvents MsgNum As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents TitreMsg As Label
End Class
