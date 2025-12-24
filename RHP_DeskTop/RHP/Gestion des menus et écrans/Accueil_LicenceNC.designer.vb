<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Accueil_LicenceNC
    Inherits Ecran

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Accueil_LicenceNC))
        Me.Register_pb = New System.Windows.Forms.PictureBox()
        Me.Register_lbl = New System.Windows.Forms.Label()
        Me.Register_pnl = New System.Windows.Forms.Panel()
        CType(Me.Register_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Register_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Register_pb
        '
        Me.Register_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Register_pb.Image = CType(resources.GetObject("Register_pb.Image"), System.Drawing.Image)
        Me.Register_pb.Location = New System.Drawing.Point(3, 3)
        Me.Register_pb.Name = "Register_pb"
        Me.Register_pb.Size = New System.Drawing.Size(278, 205)
        Me.Register_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Register_pb.TabIndex = 2
        Me.Register_pb.TabStop = False
        '
        'Register_lbl
        '
        Me.Register_lbl.AutoSize = True
        Me.Register_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Register_lbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Register_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Register_lbl.Location = New System.Drawing.Point(12, 211)
        Me.Register_lbl.Name = "Register_lbl"
        Me.Register_lbl.Size = New System.Drawing.Size(258, 24)
        Me.Register_lbl.TabIndex = 3
        Me.Register_lbl.Text = "Enregistrez votre licence"
        '
        'Register_pnl
        '
        Me.Register_pnl.Controls.Add(Me.Register_lbl)
        Me.Register_pnl.Controls.Add(Me.Register_pb)
        Me.Register_pnl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Register_pnl.Location = New System.Drawing.Point(365, 178)
        Me.Register_pnl.Name = "Register_pnl"
        Me.Register_pnl.Size = New System.Drawing.Size(283, 243)
        Me.Register_pnl.TabIndex = 4
        '
        'Accueil_LicenceNC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1117, 645)
        Me.Controls.Add(Me.Register_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Accueil_LicenceNC"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Register_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Register_pnl.ResumeLayout(False)
        Me.Register_pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Register_pb As PictureBox
    Friend WithEvents Register_lbl As Label
    Friend WithEvents Register_pnl As Panel
End Class
