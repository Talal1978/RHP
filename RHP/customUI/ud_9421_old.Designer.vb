<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ud_9421_old
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
        Me.Ud_Panel2 = New RHP.ud_Panel()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Ud_Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ud_Panel2
        '
        Me.Ud_Panel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel2.BorderSize = 2
        Me.Ud_Panel2.Controls.Add(Me.Pnl)
        Me.Ud_Panel2.Controls.Add(Me.lbl)
        Me.Ud_Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Panel2.Name = "Ud_Panel2"
        Me.Ud_Panel2.Padding = New System.Windows.Forms.Padding(2, 2, 3, 3)
        Me.Ud_Panel2.Size = New System.Drawing.Size(225, 150)
        Me.Ud_Panel2.TabIndex = 2
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(2, 2)
        Me.lbl.Margin = New System.Windows.Forms.Padding(0)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(220, 44)
        Me.lbl.TabIndex = 0
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.White
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 46)
        Me.Pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(220, 101)
        Me.Pnl.TabIndex = 1
        '
        'ud_9421
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Ud_Panel2)
        Me.Name = "ud_9421"
        Me.Size = New System.Drawing.Size(225, 150)
        Me.Ud_Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbl As Label
    Friend WithEvents Ud_Panel2 As ud_Panel
    Friend WithEvents Pnl As Panel
End Class
