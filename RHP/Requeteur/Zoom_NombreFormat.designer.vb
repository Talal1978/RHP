<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_NombreFormat
    inherits Ecran

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
        Me.nbDec = New System.Windows.Forms.NumericUpDown()
        Me.Sep_chk = New RHP.ud_CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        CType(Me.nbDec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'nbDec
        '
        Me.nbDec.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.nbDec.Location = New System.Drawing.Point(173, 51)
        Me.nbDec.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.nbDec.Name = "nbDec"
        Me.nbDec.Size = New System.Drawing.Size(35, 21)
        Me.nbDec.TabIndex = 0
        Me.nbDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Sep_chk
        '
        Me.Sep_chk.AutoSize = True
        Me.Sep_chk.Checked = True
        Me.Sep_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Sep_chk.Location = New System.Drawing.Point(213, 50)
        Me.Sep_chk.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Sep_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Sep_chk.MinimumSize = New System.Drawing.Size(117, 25)
        Me.Sep_chk.Name = "Sep_chk"
        Me.Sep_chk.Size = New System.Drawing.Size(143, 25)
        Me.Sep_chk.TabIndex = 1
        Me.Sep_chk.Text = "Séparateur des milliers"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(41, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nombre de décimaux"
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Save_ud)
        Me.Pnl.Controls.Add(Me.Annuler_ud)
        Me.Pnl.Controls.Add(Me.Label1)
        Me.Pnl.Controls.Add(Me.nbDec)
        Me.Pnl.Controls.Add(Me.Sep_chk)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 2)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(396, 134)
        Me.Pnl.TabIndex = 212
        '
        'Save_ud
        '
        Me.Save_ud.AutoSize = True
        Me.Save_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Save_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.BorderSize = 2
        Me.Save_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Save_ud.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_ud.Location = New System.Drawing.Point(290, 94)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(100, 33)
        Me.Save_ud.TabIndex = 212
        Me.Save_ud.Text = "Enregistrer"
        '
        'Annuler_ud
        '
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.Location = New System.Drawing.Point(5, 96)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(100, 33)
        Me.Annuler_ud.TabIndex = 213
        Me.Annuler_ud.Text = "Annuler"
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(2, 2)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(396, 31)
        Me.Titre_lbl.TabIndex = 213
        Me.Titre_lbl.Text = "Format de nombre"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Zoom_NombreFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(400, 138)
        Me.ControlBox = False
        Me.Controls.Add(Me.Titre_lbl)
        Me.Controls.Add(Me.Pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "Zoom_NombreFormat"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Format de nombre"
        CType(Me.nbDec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents nbDec As NumericUpDown
    Friend WithEvents Sep_chk As ud_CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Pnl As Panel
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
End Class
