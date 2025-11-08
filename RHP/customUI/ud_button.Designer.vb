<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_button
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
        Me.components = New System.ComponentModel.Container()
        Me.img_pb = New System.Windows.Forms.PictureBox()
        Me.bnt_toolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.txt_lbl = New System.Windows.Forms.Label()
        Me.tbl_pnl = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.img_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbl_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'img_pb
        '
        Me.img_pb.BackColor = System.Drawing.Color.Transparent
        Me.img_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.img_pb.Location = New System.Drawing.Point(3, 3)
        Me.img_pb.Name = "img_pb"
        Me.img_pb.Size = New System.Drawing.Size(25, 31)
        Me.img_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.img_pb.TabIndex = 0
        Me.img_pb.TabStop = False
        '
        'txt_lbl
        '
        Me.txt_lbl.AutoSize = True
        Me.txt_lbl.BackColor = System.Drawing.Color.Transparent
        Me.txt_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.txt_lbl.Location = New System.Drawing.Point(34, 0)
        Me.txt_lbl.Name = "txt_lbl"
        Me.txt_lbl.Size = New System.Drawing.Size(119, 37)
        Me.txt_lbl.TabIndex = 1
        Me.txt_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbl_pnl
        '
        Me.tbl_pnl.BackColor = System.Drawing.Color.White
        Me.tbl_pnl.ColumnCount = 2
        Me.tbl_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tbl_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tbl_pnl.Controls.Add(Me.txt_lbl, 0, 0)
        Me.tbl_pnl.Controls.Add(Me.img_pb, 0, 0)
        Me.tbl_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbl_pnl.Location = New System.Drawing.Point(1, 1)
        Me.tbl_pnl.Name = "tbl_pnl"
        Me.tbl_pnl.RowCount = 1
        Me.tbl_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbl_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.tbl_pnl.Size = New System.Drawing.Size(156, 37)
        Me.tbl_pnl.TabIndex = 2
        '
        'ud_button
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Controls.Add(Me.tbl_pnl)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Name = "ud_button"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.Size = New System.Drawing.Size(158, 39)
        CType(Me.img_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbl_pnl.ResumeLayout(False)
        Me.tbl_pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents img_pb As PictureBox
    Friend WithEvents bnt_toolTip As ToolTip
    Friend WithEvents txt_lbl As Label
    Friend WithEvents tbl_pnl As TableLayoutPanel
End Class
