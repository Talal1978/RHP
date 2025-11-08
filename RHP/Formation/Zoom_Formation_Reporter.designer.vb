<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Formation_Reporter
    Inherits System.Windows.Forms.Form

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
        Me.Dat_Au = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dat_Du = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dat_Au
        '
        Me.Dat_Au.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.Dat_Au.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dat_Au.Location = New System.Drawing.Point(263, 32)
        Me.Dat_Au.Name = "Dat_Au"
        Me.Dat_Au.Size = New System.Drawing.Size(128, 21)
        Me.Dat_Au.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(239, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Du"
        '
        'Dat_Du
        '
        Me.Dat_Du.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.Dat_Du.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dat_Du.Location = New System.Drawing.Point(106, 32)
        Me.Dat_Du.Name = "Dat_Du"
        Me.Dat_Du.Size = New System.Drawing.Size(127, 21)
        Me.Dat_Du.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Du"
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(2, 2)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(467, 31)
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.Text = "Reporter une formation"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Save_ud)
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Controls.Add(Me.Dat_Du)
        Me.Panel1.Controls.Add(Me.Dat_Au)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 131)
        Me.Panel1.TabIndex = 34
        '
        'Save_ud
        '
        Me.Save_ud.AutoSize = True
        Me.Save_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Save_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.BorderSize = 2
        Me.Save_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Save_ud.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_ud.Location = New System.Drawing.Point(343, 84)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(111, 33)
        Me.Save_ud.TabIndex = 32
        Me.Save_ud.Text = "Enregistrer"
        Me.Save_ud.ToolTip = ""
        '
        'Annuler_ud
        '
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.Location = New System.Drawing.Point(10, 84)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(111, 33)
        Me.Annuler_ud.TabIndex = 33
        Me.Annuler_ud.Text = "Annuler"
        Me.Annuler_ud.ToolTip = ""
        '
        'Zoom_Formation_Reporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(471, 166)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Titre_lbl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Formation_Reporter"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporter une formation"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dat_Au As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Dat_Du As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
End Class
