<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ud_CheckBox
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
        Me.Text_lbl = New System.Windows.Forms.Label()
        Me.check_pb = New System.Windows.Forms.PictureBox()
        CType(Me.check_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text_lbl
        '
        Me.Text_lbl.AutoSize = True
        Me.Text_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Text_lbl.Location = New System.Drawing.Point(16, 0)
        Me.Text_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Text_lbl.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Text_lbl.MinimumSize = New System.Drawing.Size(0, 25)
        Me.Text_lbl.Name = "Text_lbl"
        Me.Text_lbl.Size = New System.Drawing.Size(0, 25)
        Me.Text_lbl.TabIndex = 1
        Me.Text_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'check_pb
        '
        Me.check_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.check_pb.Image = Global.RHP.My.Resources.Resources.btn_check_off
        Me.check_pb.Location = New System.Drawing.Point(0, 5)
        Me.check_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.check_pb.Name = "check_pb"
        Me.check_pb.Size = New System.Drawing.Size(16, 15)
        Me.check_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.check_pb.TabIndex = 0
        Me.check_pb.TabStop = False
        '
        'ud_CheckBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.Text_lbl)
        Me.Controls.Add(Me.check_pb)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximumSize = New System.Drawing.Size(0, 25)
        Me.MinimumSize = New System.Drawing.Size(133, 25)
        Me.Name = "ud_CheckBox"
        Me.Size = New System.Drawing.Size(133, 25)
        CType(Me.check_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents check_pb As PictureBox
    Friend WithEvents Text_lbl As Label
End Class
