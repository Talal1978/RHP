<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Generation_NetToBrut
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
        Me.PBar = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Etape = New System.Windows.Forms.Label()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PBar
        '
        '
        '
        '
        Me.PBar.BackgroundStyle.Class = ""
        Me.PBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PBar.Location = New System.Drawing.Point(11, 59)
        Me.PBar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PBar.Name = "PBar"
        Me.PBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Me.PBar.Size = New System.Drawing.Size(486, 29)
        Me.PBar.TabIndex = 0
        Me.PBar.Text = "ProgressBarX1"
        '
        'Etape
        '
        Me.Etape.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Etape.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Etape.Location = New System.Drawing.Point(15, 24)
        Me.Etape.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Etape.Name = "Etape"
        Me.Etape.Size = New System.Drawing.Size(484, 32)
        Me.Etape.TabIndex = 1
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(2, 2)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(508, 39)
        Me.Titre_lbl.TabIndex = 250
        Me.Titre_lbl.Text = "Calcul Net à Brut"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Controls.Add(Me.Etape)
        Me.Panel1.Controls.Add(Me.PBar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 41)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(508, 141)
        Me.Panel1.TabIndex = 251
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
        Me.Annuler_ud.Location = New System.Drawing.Point(371, 92)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(29, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(125, 41)
        Me.Annuler_ud.TabIndex = 250
        Me.Annuler_ud.Text = "Terminer"
        '
        'Zoom_Generation_NetToBrut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(512, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Titre_lbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Zoom_Generation_NetToBrut"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Généraion du brut à partir du net"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PBar As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Etape As System.Windows.Forms.Label
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Annuler_ud As ud_button
End Class
