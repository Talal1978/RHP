<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ud_ComboBox
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
        Me.innerComboBox = New System.Windows.Forms.ComboBox()
        Me.LB_lbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'innerComboBox
        '
        Me.innerComboBox.BackColor = System.Drawing.Color.White
        Me.innerComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.innerComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.innerComboBox.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.innerComboBox.FormattingEnabled = True
        Me.innerComboBox.Location = New System.Drawing.Point(0, 0)
        Me.innerComboBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.innerComboBox.Name = "innerComboBox"
        Me.innerComboBox.Size = New System.Drawing.Size(328, 27)
        Me.innerComboBox.TabIndex = 2
        '
        'LB_lbl
        '
        Me.LB_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.LB_lbl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LB_lbl.Location = New System.Drawing.Point(0, 30)
        Me.LB_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LB_lbl.Name = "LB_lbl"
        Me.LB_lbl.Size = New System.Drawing.Size(328, 1)
        Me.LB_lbl.TabIndex = 3
        '
        'ud_ComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LB_lbl)
        Me.Controls.Add(Me.innerComboBox)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ud_ComboBox"
        Me.Size = New System.Drawing.Size(328, 31)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents innerComboBox As ComboBox
    Friend WithEvents LB_lbl As Label
End Class
