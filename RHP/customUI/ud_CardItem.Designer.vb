<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ud_CardItem
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.Ud_Pnl = New RHP.ud_Panel()
        Me.Img_pb = New System.Windows.Forms.PictureBox()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Ud_Pnl.SuspendLayout()
        CType(Me.Img_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ud_Pnl
        '
        Me.Ud_Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Ud_Pnl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.Ud_Pnl.BorderSize = 1
        Me.Ud_Pnl.Controls.Add(Me.Img_pb)
        Me.Ud_Pnl.Controls.Add(Me.Titre_lbl)
        Me.Ud_Pnl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ud_Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Pnl.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Pnl.Name = "Ud_Pnl"
        Me.Ud_Pnl.Size = New System.Drawing.Size(166, 100)
        Me.Ud_Pnl.TabIndex = 9
        '
        'Img_pb
        '
        Me.Img_pb.BackColor = System.Drawing.Color.Transparent
        Me.Img_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Img_pb.Location = New System.Drawing.Point(51, 5)
        Me.Img_pb.Name = "Img_pb"
        Me.Img_pb.Size = New System.Drawing.Size(56, 52)
        Me.Img_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Img_pb.TabIndex = 0
        Me.Img_pb.TabStop = False
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Titre_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Titre_lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(3, 60)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(158, 37)
        Me.Titre_lbl.TabIndex = 2
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ud_CardItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Ud_Pnl)
        Me.Name = "ud_CardItem"
        Me.Size = New System.Drawing.Size(166, 100)
        Me.Ud_Pnl.ResumeLayout(False)
        CType(Me.Img_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Ud_Pnl As ud_Panel
    Friend WithEvents Img_pb As PictureBox
    Friend WithEvents Titre_lbl As Label
End Class
