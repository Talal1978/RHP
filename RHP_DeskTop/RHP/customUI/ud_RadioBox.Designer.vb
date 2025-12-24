<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ud_RadioBox
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
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.rd_pb = New System.Windows.Forms.PictureBox()
        Me.txt_lbl = New System.Windows.Forms.Label()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.rd_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.AutoSize = True
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Controls.Add(Me.rd_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.txt_lbl, 1, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(107, 20)
        Me.Personnal_pnl.TabIndex = 0
        '
        'rd_pb
        '
        Me.rd_pb.BackColor = System.Drawing.Color.Transparent
        Me.rd_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rd_pb.Image = Global.RHP.My.Resources.Resources.chk_off
        Me.rd_pb.Location = New System.Drawing.Point(0, 0)
        Me.rd_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.rd_pb.Name = "rd_pb"
        Me.rd_pb.Size = New System.Drawing.Size(25, 20)
        Me.rd_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.rd_pb.TabIndex = 0
        Me.rd_pb.TabStop = False
        '
        'txt_lbl
        '
        Me.txt_lbl.AutoSize = True
        Me.txt_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.txt_lbl.Location = New System.Drawing.Point(25, 0)
        Me.txt_lbl.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_lbl.MaximumSize = New System.Drawing.Size(0, 19)
        Me.txt_lbl.MinimumSize = New System.Drawing.Size(82, 19)
        Me.txt_lbl.Name = "txt_lbl"
        Me.txt_lbl.Size = New System.Drawing.Size(82, 19)
        Me.txt_lbl.TabIndex = 1
        Me.txt_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ud_RadioBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.Personnal_pnl)
        Me.MaximumSize = New System.Drawing.Size(0, 20)
        Me.MinimumSize = New System.Drawing.Size(0, 20)
        Me.Name = "ud_RadioBox"
        Me.Size = New System.Drawing.Size(107, 20)
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Personnal_pnl.PerformLayout()
        CType(Me.rd_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents rd_pb As PictureBox
    Friend WithEvents txt_lbl As Label
End Class
