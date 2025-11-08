<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Combo
    inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.oListBox = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'oListBox
        '
        Me.oListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.oListBox.FormattingEnabled = True
        Me.oListBox.Location = New System.Drawing.Point(0, 0)
        Me.oListBox.Name = "oListBox"
        Me.oListBox.Size = New System.Drawing.Size(203, 69)
        Me.oListBox.TabIndex = 0
        '
        'Zoom_Combo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.none
        Me.ClientSize = New System.Drawing.Size(203, 69)
        Me.Controls.Add(Me.oListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Combo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Zoom"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents oListBox As System.Windows.Forms.ListBox
End Class
