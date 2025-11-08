<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ud_btn
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
        Me.components = New System.ComponentModel.Container()
        Me.Btn_pb = New System.Windows.Forms.PictureBox()
        Me.bnt_toolTip = New DevComponents.DotNetBar.SuperTooltip
        CType(Me.Btn_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_pb
        '
        Me.Btn_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Btn_pb.Location = New System.Drawing.Point(0, 0)
        Me.Btn_pb.Name = "Btn_pb"
        Me.Btn_pb.Size = New System.Drawing.Size(25, 25)
        Me.Btn_pb.TabIndex = 0
        Me.Btn_pb.TabStop = False
        '
        'ud_btn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Btn_pb)
        Me.Name = "ud_btn"
        Me.Size = New System.Drawing.Size(25, 25)
        CType(Me.Btn_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_pb As PictureBox
    Friend WithEvents bnt_toolTip As DevComponents.DotNetBar.SuperTooltip
End Class
