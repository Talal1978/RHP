<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu_Societes
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
        Me.Ud_Content = New RHP.ud_Panel()
        Me.LHH = New System.Windows.Forms.Label()
        Me.LHF = New System.Windows.Forms.Label()
        Me.LHR = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Ud_Content
        '
        Me.Ud_Content.AutoScroll = True
        Me.Ud_Content.BorderColor = System.Drawing.Color.White
        Me.Ud_Content.BorderSize = 2
        Me.Ud_Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Content.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Content.Name = "Ud_Content"
        Me.Ud_Content.Size = New System.Drawing.Size(963, 579)
        Me.Ud_Content.TabIndex = 0
        '
        'LHH
        '
        Me.LHH.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.LHH.Dock = System.Windows.Forms.DockStyle.Top
        Me.LHH.Location = New System.Drawing.Point(0, 0)
        Me.LHH.Name = "LHH"
        Me.LHH.Size = New System.Drawing.Size(963, 1)
        Me.LHH.TabIndex = 0
        '
        'LHF
        '
        Me.LHF.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.LHF.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LHF.Location = New System.Drawing.Point(0, 578)
        Me.LHF.Name = "LHF"
        Me.LHF.Size = New System.Drawing.Size(963, 1)
        Me.LHF.TabIndex = 1
        '
        'LHR
        '
        Me.LHR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.LHR.Dock = System.Windows.Forms.DockStyle.Right
        Me.LHR.Location = New System.Drawing.Point(962, 1)
        Me.LHR.Name = "LHR"
        Me.LHR.Size = New System.Drawing.Size(1, 577)
        Me.LHR.TabIndex = 2
        '
        'Menu_Societes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(963, 579)
        Me.Controls.Add(Me.LHR)
        Me.Controls.Add(Me.LHF)
        Me.Controls.Add(Me.LHH)
        Me.Controls.Add(Me.Ud_Content)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Menu_Societes"
        Me.Text = "Menu_Societes"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Ud_Content As ud_Panel
    Friend WithEvents LHH As Label
    Friend WithEvents LHF As Label
    Friend WithEvents LHR As Label
End Class
