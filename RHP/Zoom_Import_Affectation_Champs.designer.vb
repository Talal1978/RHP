<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Import_Affectation_Champs
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
        Me.Ordre = New RHP.ud_RadioBox()
        Me.Nom = New RHP.ud_RadioBox()
        Me.SetParDefaut = New RHP.ud_CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ordre
        '
        Me.Ordre.AutoSize = True
        Me.Ordre.Checked = False
        Me.Ordre.Location = New System.Drawing.Point(85, 75)
        Me.Ordre.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Ordre.MinimumSize = New System.Drawing.Size(0, 25)
        Me.Ordre.Name = "Ordre"
        Me.Ordre.Size = New System.Drawing.Size(194, 25)
        Me.Ordre.TabIndex = 0
        Me.Ordre.Text = "Comparer par ordre des colonnes"
        '
        'Nom
        '
        Me.Nom.AutoSize = True
        Me.Nom.Checked = False
        Me.Nom.Location = New System.Drawing.Point(85, 47)
        Me.Nom.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Nom.MinimumSize = New System.Drawing.Size(0, 25)
        Me.Nom.Name = "Nom"
        Me.Nom.Size = New System.Drawing.Size(216, 25)
        Me.Nom.TabIndex = 0
        Me.Nom.Text = "Affecter par comparaison des champs"
        '
        'SetParDefaut
        '
        Me.SetParDefaut.AutoSize = True
        Me.SetParDefaut.Checked = True
        Me.SetParDefaut.Location = New System.Drawing.Point(8, 121)
        Me.SetParDefaut.MaximumSize = New System.Drawing.Size(0, 20)
        Me.SetParDefaut.MinimumSize = New System.Drawing.Size(100, 20)
        Me.SetParDefaut.Name = "SetParDefaut"
        Me.SetParDefaut.Size = New System.Drawing.Size(144, 20)
        Me.SetParDefaut.TabIndex = 1
        Me.SetParDefaut.Text = "Ne me redemander jamais"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Titre_lbl)
        Me.Panel1.Controls.Add(Me.Save_ud)
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Controls.Add(Me.Nom)
        Me.Panel1.Controls.Add(Me.Ordre)
        Me.Panel1.Controls.Add(Me.SetParDefaut)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(405, 196)
        Me.Panel1.TabIndex = 17
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(405, 31)
        Me.Titre_lbl.TabIndex = 34
        Me.Titre_lbl.Text = "Mode d'affectation automatique"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Save_ud.Location = New System.Drawing.Point(295, 155)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(23, 25)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(100, 33)
        Me.Save_ud.TabIndex = 32
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
        Me.Annuler_ud.Location = New System.Drawing.Point(8, 155)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(23, 25)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(100, 33)
        Me.Annuler_ud.TabIndex = 33
        Me.Annuler_ud.Text = "Annuler"
        '
        'Zoom_Import_Affectation_Champs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(409, 200)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Import_Affectation_Champs"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mode d'affectation automatique"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ordre As ud_RadioBox
    Friend WithEvents Nom As ud_RadioBox
    Friend WithEvents SetParDefaut As ud_CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Titre_lbl As Label
End Class
