<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ud_rubriqueLbl
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.visibility_pb = New System.Windows.Forms.PictureBox()
        Me.txt = New System.Windows.Forms.Label()
        Me.Rang_lbl = New System.Windows.Forms.Label()
        Me.Pnl.SuspendLayout()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.visibility_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.White
        Me.Pnl.Controls.Add(Me.Personnal_pnl)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(1, 1)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(229, 31)
        Me.Pnl.TabIndex = 0
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.ColumnCount = 3
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.Personnal_pnl.Controls.Add(Me.visibility_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.txt, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.Rang_lbl, 2, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(229, 31)
        Me.Personnal_pnl.TabIndex = 0
        '
        'visibility_pb
        '
        Me.visibility_pb.BackColor = System.Drawing.Color.Transparent
        Me.visibility_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.visibility_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.visibility_pb.Image = Global.RHP.My.Resources.Resources.eye1
        Me.visibility_pb.Location = New System.Drawing.Point(3, 3)
        Me.visibility_pb.Name = "visibility_pb"
        Me.visibility_pb.Size = New System.Drawing.Size(19, 25)
        Me.visibility_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.visibility_pb.TabIndex = 0
        Me.visibility_pb.TabStop = False
        '
        'txt
        '
        Me.txt.AutoSize = True
        Me.txt.BackColor = System.Drawing.Color.Transparent
        Me.txt.Cursor = System.Windows.Forms.Cursors.Default
        Me.txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt.Location = New System.Drawing.Point(28, 0)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(163, 31)
        Me.txt.TabIndex = 1
        Me.txt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Rang_lbl
        '
        Me.Rang_lbl.AutoSize = True
        Me.Rang_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Rang_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Rang_lbl.Location = New System.Drawing.Point(197, 0)
        Me.Rang_lbl.Name = "Rang_lbl"
        Me.Rang_lbl.Size = New System.Drawing.Size(29, 31)
        Me.Rang_lbl.TabIndex = 2
        Me.Rang_lbl.Text = "(01)"
        Me.Rang_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ud_rubriqueLbl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pnl)
        Me.DoubleBuffered = True
        Me.Name = "ud_rubriqueLbl"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.Size = New System.Drawing.Size(231, 33)
        Me.Pnl.ResumeLayout(False)
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Personnal_pnl.PerformLayout()
        CType(Me.visibility_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents visibility_pb As PictureBox
    Friend WithEvents txt As Label
    Friend WithEvents Pnl As Panel
    Friend WithEvents Rang_lbl As Label
End Class
