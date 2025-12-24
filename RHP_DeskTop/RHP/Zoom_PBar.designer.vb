<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_PBar
    Inherits Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.PBar = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Etape = New System.Windows.Forms.Label()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'PBar
        '
        '
        '
        '
        Me.PBar.BackgroundStyle.Class = ""
        Me.PBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PBar.Location = New System.Drawing.Point(7, 50)
        Me.PBar.Name = "PBar"
        Me.PBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Me.PBar.Size = New System.Drawing.Size(392, 23)
        Me.PBar.TabIndex = 0
        Me.PBar.Text = "ProgressBarX1"
        '
        'Etape
        '
        Me.Etape.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Etape.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Etape.Location = New System.Drawing.Point(10, 10)
        Me.Etape.Name = "Etape"
        Me.Etape.Size = New System.Drawing.Size(387, 34)
        Me.Etape.TabIndex = 1
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Etape)
        Me.Pnl.Controls.Add(Me.PBar)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 2)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(407, 80)
        Me.Pnl.TabIndex = 2
        '
        'Zoom_PBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(411, 84)
        Me.ControlBox = False
        Me.Controls.Add(Me.Pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_PBar"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Etat d'avancement"
        Me.Pnl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PBar As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Etape As System.Windows.Forms.Label
    Friend WithEvents Pnl As Panel
End Class
