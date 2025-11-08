<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_RH_Preparation_Paie_RegenrationEV
    Inherits Ecran

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
        Me.chk_fraisMedicaux = New RHP.ud_CheckBox()
        Me.chk_Avances = New RHP.ud_CheckBox()
        Me.chk_interet = New RHP.ud_CheckBox()
        Me.Chk_prets = New RHP.ud_CheckBox()
        Me.chk_conge = New RHP.ud_CheckBox()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Save_ud = New RHP.ud_button()
        Me.chk_NF = New RHP.ud_CheckBox()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'chk_fraisMedicaux
        '
        Me.chk_fraisMedicaux.AutoSize = True
        Me.chk_fraisMedicaux.BackColor = System.Drawing.Color.Transparent
        Me.chk_fraisMedicaux.Checked = True
        Me.chk_fraisMedicaux.Location = New System.Drawing.Point(151, 46)
        Me.chk_fraisMedicaux.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chk_fraisMedicaux.MaximumSize = New System.Drawing.Size(0, 20)
        Me.chk_fraisMedicaux.MinimumSize = New System.Drawing.Size(100, 20)
        Me.chk_fraisMedicaux.Name = "chk_fraisMedicaux"
        Me.chk_fraisMedicaux.Size = New System.Drawing.Size(189, 20)
        Me.chk_fraisMedicaux.TabIndex = 0
        Me.chk_fraisMedicaux.Text = "Remboursement des frais médicaux"
        '
        'chk_Avances
        '
        Me.chk_Avances.AutoSize = True
        Me.chk_Avances.BackColor = System.Drawing.Color.Transparent
        Me.chk_Avances.Checked = True
        Me.chk_Avances.Location = New System.Drawing.Point(12, 75)
        Me.chk_Avances.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chk_Avances.MaximumSize = New System.Drawing.Size(0, 20)
        Me.chk_Avances.MinimumSize = New System.Drawing.Size(100, 20)
        Me.chk_Avances.Name = "chk_Avances"
        Me.chk_Avances.Size = New System.Drawing.Size(100, 20)
        Me.chk_Avances.TabIndex = 0
        Me.chk_Avances.Text = "Avances"
        '
        'chk_interet
        '
        Me.chk_interet.AutoSize = True
        Me.chk_interet.BackColor = System.Drawing.Color.Transparent
        Me.chk_interet.Checked = True
        Me.chk_interet.Location = New System.Drawing.Point(151, 17)
        Me.chk_interet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chk_interet.MaximumSize = New System.Drawing.Size(0, 20)
        Me.chk_interet.MinimumSize = New System.Drawing.Size(100, 20)
        Me.chk_interet.Name = "chk_interet"
        Me.chk_interet.Size = New System.Drawing.Size(100, 20)
        Me.chk_interet.TabIndex = 0
        Me.chk_interet.Text = "Intérêts"
        '
        'Chk_prets
        '
        Me.Chk_prets.AutoSize = True
        Me.Chk_prets.BackColor = System.Drawing.Color.Transparent
        Me.Chk_prets.Checked = True
        Me.Chk_prets.Location = New System.Drawing.Point(12, 46)
        Me.Chk_prets.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chk_prets.MaximumSize = New System.Drawing.Size(0, 20)
        Me.Chk_prets.MinimumSize = New System.Drawing.Size(100, 20)
        Me.Chk_prets.Name = "Chk_prets"
        Me.Chk_prets.Size = New System.Drawing.Size(100, 20)
        Me.Chk_prets.TabIndex = 0
        Me.Chk_prets.Text = "Prêts"
        '
        'chk_conge
        '
        Me.chk_conge.AutoSize = True
        Me.chk_conge.BackColor = System.Drawing.Color.Transparent
        Me.chk_conge.Checked = True
        Me.chk_conge.Location = New System.Drawing.Point(12, 17)
        Me.chk_conge.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chk_conge.MaximumSize = New System.Drawing.Size(0, 20)
        Me.chk_conge.MinimumSize = New System.Drawing.Size(100, 20)
        Me.chk_conge.Name = "chk_conge"
        Me.chk_conge.Size = New System.Drawing.Size(100, 20)
        Me.chk_conge.TabIndex = 0
        Me.chk_conge.Text = "Congés"
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(2, 2)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(386, 31)
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.Text = "Importer les éléments variables des modules annexes"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Save_ud)
        Me.Panel2.Controls.Add(Me.chk_conge)
        Me.Panel2.Controls.Add(Me.Chk_prets)
        Me.Panel2.Controls.Add(Me.chk_NF)
        Me.Panel2.Controls.Add(Me.chk_fraisMedicaux)
        Me.Panel2.Controls.Add(Me.chk_interet)
        Me.Panel2.Controls.Add(Me.chk_Avances)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(2, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(386, 157)
        Me.Panel2.TabIndex = 1
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
        Me.Save_ud.isDefault = False
        Me.Save_ud.Location = New System.Drawing.Point(281, 119)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(23, 25)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(100, 33)
        Me.Save_ud.TabIndex = 31
        Me.Save_ud.Text = "Enregistrer"
        '
        'chk_NF
        '
        Me.chk_NF.AutoSize = True
        Me.chk_NF.BackColor = System.Drawing.Color.Transparent
        Me.chk_NF.Checked = True
        Me.chk_NF.Location = New System.Drawing.Point(151, 75)
        Me.chk_NF.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chk_NF.MaximumSize = New System.Drawing.Size(0, 20)
        Me.chk_NF.MinimumSize = New System.Drawing.Size(100, 20)
        Me.chk_NF.Name = "chk_NF"
        Me.chk_NF.Size = New System.Drawing.Size(189, 20)
        Me.chk_NF.TabIndex = 0
        Me.chk_NF.Text = "Notes de frais"
        '
        'Zoom_RH_Preparation_Paie_RegenrationEV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(390, 192)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Titre_lbl)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_RH_Preparation_Paie_RegenrationEV"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Regenration des éléments variables"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chk_fraisMedicaux As ud_CheckBox
    Friend WithEvents chk_Avances As ud_CheckBox
    Friend WithEvents chk_interet As ud_CheckBox
    Friend WithEvents Chk_prets As ud_CheckBox
    Friend WithEvents chk_conge As ud_CheckBox
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents chk_NF As ud_CheckBox
End Class
