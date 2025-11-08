<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_CardSoc_Small
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ud_CardSoc_Small))
        Me.Border_pnl = New RHP.ud_Panel()
        Me.soc_pb = New System.Windows.Forms.PictureBox()
        Me.Den_lbl = New System.Windows.Forms.Label()
        Me.Border_pnl.SuspendLayout()
        CType(Me.soc_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Border_pnl
        '
        Me.Border_pnl.BackColor = System.Drawing.Color.White
        Me.Border_pnl.BorderColor = System.Drawing.Color.White
        Me.Border_pnl.BorderSize = 1
        Me.Border_pnl.Controls.Add(Me.soc_pb)
        Me.Border_pnl.Controls.Add(Me.Den_lbl)
        Me.Border_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Border_pnl.Location = New System.Drawing.Point(0, 3)
        Me.Border_pnl.Name = "Border_pnl"
        Me.Border_pnl.Size = New System.Drawing.Size(350, 32)
        Me.Border_pnl.TabIndex = 4
        '
        'soc_pb
        '
        Me.soc_pb.BackColor = System.Drawing.Color.Transparent
        Me.soc_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.soc_pb.Image = CType(resources.GetObject("soc_pb.Image"), System.Drawing.Image)
        Me.soc_pb.Location = New System.Drawing.Point(6, 4)
        Me.soc_pb.Name = "soc_pb"
        Me.soc_pb.Size = New System.Drawing.Size(25, 25)
        Me.soc_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.soc_pb.TabIndex = 0
        Me.soc_pb.TabStop = False
        '
        'Den_lbl
        '
        Me.Den_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Den_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Den_lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Den_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Den_lbl.Location = New System.Drawing.Point(37, 3)
        Me.Den_lbl.Name = "Den_lbl"
        Me.Den_lbl.Size = New System.Drawing.Size(310, 28)
        Me.Den_lbl.TabIndex = 2
        Me.Den_lbl.Text = "Denomination"
        Me.Den_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ud_CardSoc_Small
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Border_pnl)
        Me.Name = "ud_CardSoc_Small"
        Me.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Size = New System.Drawing.Size(350, 38)
        Me.Border_pnl.ResumeLayout(False)
        CType(Me.soc_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents soc_pb As PictureBox
    Friend WithEvents Den_lbl As Label
    Friend WithEvents Border_pnl As ud_Panel
End Class
