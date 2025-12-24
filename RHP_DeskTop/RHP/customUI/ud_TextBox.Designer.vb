<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_TextBox
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
        Me.innerTextBox = New System.Windows.Forms.TextBox()
        Me.LB_lbl = New System.Windows.Forms.Label()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'innerTextBox
        '
        Me.innerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.innerTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerTextBox.Location = New System.Drawing.Point(0, 0)
        Me.innerTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.innerTextBox.Name = "innerTextBox"
        Me.innerTextBox.Size = New System.Drawing.Size(141, 13)
        Me.innerTextBox.TabIndex = 0
        '
        'LB_lbl
        '
        Me.LB_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.LB_lbl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LB_lbl.Location = New System.Drawing.Point(1, 21)
        Me.LB_lbl.Name = "LB_lbl"
        Me.LB_lbl.Size = New System.Drawing.Size(141, 1)
        Me.LB_lbl.TabIndex = 1
        '
        'Pnl
        '
        Me.Pnl.Controls.Add(Me.innerTextBox)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(1, 0)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(141, 21)
        Me.Pnl.TabIndex = 2
        '
        'ud_TextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.LB_lbl)
        Me.Name = "ud_TextBox"
        Me.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Size = New System.Drawing.Size(143, 22)
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents innerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LB_lbl As Label
    Friend WithEvents Pnl As Panel
End Class
