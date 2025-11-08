<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Simulation_Calculinverse
    inherits Ecran

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.olog = New System.Windows.Forms.Label()
        Me.SLB_txt = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SaLNetActuel_txt = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Sal_Net_Cible_txt = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bgk = New System.ComponentModel.BackgroundWorker()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.nb = New System.Windows.Forms.Label()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Save_ud
        '
        Me.Save_ud.AutoSize = True
        Me.Save_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.bgColor = System.Drawing.Color.White
        Me.Save_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Save_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.BorderSize = 2
        Me.Save_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_ud.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_ud.isDefault = False
        Me.Save_ud.Location = New System.Drawing.Point(376, 97)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(115, 31)
        Me.Save_ud.TabIndex = 249
        Me.Save_ud.Text = "Enregistrer"
        '
        'Annuler_ud
        '
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.bgColor = System.Drawing.Color.White
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.isDefault = False
        Me.Annuler_ud.Location = New System.Drawing.Point(12, 97)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(100, 31)
        Me.Annuler_ud.TabIndex = 250
        Me.Annuler_ud.Text = "Annuler"
        '
        'olog
        '
        Me.olog.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.olog.Location = New System.Drawing.Point(391, 48)
        Me.olog.Name = "olog"
        Me.olog.Size = New System.Drawing.Size(100, 20)
        Me.olog.TabIndex = 244
        Me.olog.Text = "0.00"
        Me.olog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SLB_txt
        '
        '
        '
        '
        Me.SLB_txt.Border.Class = "TextBoxBorder"
        Me.SLB_txt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SLB_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.SLB_txt.Location = New System.Drawing.Point(124, 47)
        Me.SLB_txt.Name = "SLB_txt"
        Me.SLB_txt.ReadOnly = True
        Me.SLB_txt.Size = New System.Drawing.Size(100, 29)
        Me.SLB_txt.TabIndex = 241
        Me.SLB_txt.Text = "0,00"
        Me.SLB_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(3, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 19)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Salaire de base"
        '
        'SaLNetActuel_txt
        '
        '
        '
        '
        Me.SaLNetActuel_txt.Border.Class = "TextBoxBorder"
        Me.SaLNetActuel_txt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SaLNetActuel_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.SaLNetActuel_txt.Location = New System.Drawing.Point(124, 12)
        Me.SaLNetActuel_txt.Name = "SaLNetActuel_txt"
        Me.SaLNetActuel_txt.ReadOnly = True
        Me.SaLNetActuel_txt.Size = New System.Drawing.Size(100, 29)
        Me.SaLNetActuel_txt.TabIndex = 241
        Me.SaLNetActuel_txt.Text = "0,00"
        Me.SaLNetActuel_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(26, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 240
        Me.Label1.Text = "Net actuel "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(265, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 19)
        Me.Label3.TabIndex = 240
        Me.Label3.Text = "Salaire net cible"
        '
        'Sal_Net_Cible_txt
        '
        '
        '
        '
        Me.Sal_Net_Cible_txt.Border.Class = "TextBoxBorder"
        Me.Sal_Net_Cible_txt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sal_Net_Cible_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Sal_Net_Cible_txt.Location = New System.Drawing.Point(391, 12)
        Me.Sal_Net_Cible_txt.Name = "Sal_Net_Cible_txt"
        Me.Sal_Net_Cible_txt.Size = New System.Drawing.Size(100, 29)
        Me.Sal_Net_Cible_txt.TabIndex = 21
        Me.Sal_Net_Cible_txt.Text = "0,00"
        Me.Sal_Net_Cible_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Bgk
        '
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(2, 2)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(503, 31)
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.Text = "Calcul inversé"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.nb)
        Me.Pnl.Controls.Add(Me.Save_ud)
        Me.Pnl.Controls.Add(Me.Annuler_ud)
        Me.Pnl.Controls.Add(Me.olog)
        Me.Pnl.Controls.Add(Me.SLB_txt)
        Me.Pnl.Controls.Add(Me.Label4)
        Me.Pnl.Controls.Add(Me.SaLNetActuel_txt)
        Me.Pnl.Controls.Add(Me.Label1)
        Me.Pnl.Controls.Add(Me.Label3)
        Me.Pnl.Controls.Add(Me.Sal_Net_Cible_txt)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 33)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(503, 148)
        Me.Pnl.TabIndex = 249
        '
        'nb
        '
        Me.nb.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.nb.Location = New System.Drawing.Point(391, 72)
        Me.nb.Name = "nb"
        Me.nb.Size = New System.Drawing.Size(100, 20)
        Me.nb.TabIndex = 251
        Me.nb.Text = "0.00"
        Me.nb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Zoom_Simulation_Calculinverse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(507, 183)
        Me.ControlBox = False
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.Titre_lbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Simulation_Calculinverse"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Text = "Calcul inversé"
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Sal_Net_Cible_txt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As Label
    Friend WithEvents SaLNetActuel_txt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As Label
    Friend WithEvents Bgk As System.ComponentModel.BackgroundWorker
    Friend WithEvents SLB_txt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As Label
    Friend WithEvents olog As Label
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Pnl As Panel
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents nb As Label
End Class
