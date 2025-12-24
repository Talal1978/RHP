<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Wait
    Inherits System.Windows.Forms.Form

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
        Me.waiting_pb = New System.Windows.Forms.PictureBox()
        Me.waiting_pnl = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.waiting_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.waiting_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'waiting_pb
        '
        Me.waiting_pb.BackColor = System.Drawing.Color.Transparent
        Me.waiting_pb.Image = Global.RHP.My.Resources.Resources.Waiting
        Me.waiting_pb.Location = New System.Drawing.Point(0, 0)
        Me.waiting_pb.Name = "waiting_pb"
        Me.waiting_pb.Size = New System.Drawing.Size(394, 335)
        Me.waiting_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.waiting_pb.TabIndex = 0
        Me.waiting_pb.TabStop = False
        '
        'waiting_pnl
        '
        Me.waiting_pnl.Controls.Add(Me.Label2)
        Me.waiting_pnl.Controls.Add(Me.Label1)
        Me.waiting_pnl.Controls.Add(Me.waiting_pb)
        Me.waiting_pnl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.waiting_pnl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.waiting_pnl.Location = New System.Drawing.Point(469, 197)
        Me.waiting_pnl.Name = "waiting_pnl"
        Me.waiting_pnl.Size = New System.Drawing.Size(397, 438)
        Me.waiting_pnl.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(57, 399)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(289, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Merci de patienter"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(57, 368)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(289, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Chargement en cours..."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Wait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(993, 671)
        Me.Controls.Add(Me.waiting_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Wait"
        Me.Text = "Wait"
        CType(Me.waiting_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.waiting_pnl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents waiting_pb As PictureBox
    Friend WithEvents waiting_pnl As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
