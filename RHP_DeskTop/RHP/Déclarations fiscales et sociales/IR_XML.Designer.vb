<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IR_XML
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Save_ud = New RHP.ud_button()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Select_Server_Label = New System.Windows.Forms.Label()
        Me.Annee_Paie_cbo = New RHP.ud_ComboBox()
        Me.openXml_chk = New RHP.ud_CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Annuler_ud)
        Me.Panel1.Controls.Add(Me.Save_ud)
        Me.Panel1.Controls.Add(Me.Titre_lbl)
        Me.Panel1.Controls.Add(Me.Select_Server_Label)
        Me.Panel1.Controls.Add(Me.Annee_Paie_cbo)
        Me.Panel1.Controls.Add(Me.openXml_chk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(690, 206)
        Me.Panel1.TabIndex = 27
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
        Me.Annuler_ud.Location = New System.Drawing.Point(17, 155)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(31, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(161, 41)
        Me.Annuler_ud.TabIndex = 32
        Me.Annuler_ud.Text = "Annuler"
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
        Me.Save_ud.Location = New System.Drawing.Point(513, 155)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(31, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(161, 41)
        Me.Save_ud.TabIndex = 31
        Me.Save_ud.Text = "Générer le XML"
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(690, 38)
        Me.Titre_lbl.TabIndex = 26
        Me.Titre_lbl.Text = "Génération du fichier XML de la déclaration de l'IR"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Select_Server_Label
        '
        Me.Select_Server_Label.AutoSize = True
        Me.Select_Server_Label.BackColor = System.Drawing.Color.Transparent
        Me.Select_Server_Label.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Select_Server_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Select_Server_Label.Location = New System.Drawing.Point(116, 68)
        Me.Select_Server_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Select_Server_Label.Name = "Select_Server_Label"
        Me.Select_Server_Label.Size = New System.Drawing.Size(61, 19)
        Me.Select_Server_Label.TabIndex = 21
        Me.Select_Server_Label.Text = "Période"
        '
        'Annee_Paie_cbo
        '
        Me.Annee_Paie_cbo.DataSource = Nothing
        Me.Annee_Paie_cbo.DisplayMember = ""
        Me.Annee_Paie_cbo.DroppedDown = False
        Me.Annee_Paie_cbo.Location = New System.Drawing.Point(185, 65)
        Me.Annee_Paie_cbo.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Annee_Paie_cbo.Name = "Annee_Paie_cbo"
        Me.Annee_Paie_cbo.SelectedIndex = -1
        Me.Annee_Paie_cbo.SelectedItem = Nothing
        Me.Annee_Paie_cbo.SelectedValue = Nothing
        Me.Annee_Paie_cbo.Size = New System.Drawing.Size(267, 25)
        Me.Annee_Paie_cbo.TabIndex = 25
        Me.Annee_Paie_cbo.ValueMember = ""
        '
        'openXml_chk
        '
        Me.openXml_chk.AutoSize = True
        Me.openXml_chk.Checked = True
        Me.openXml_chk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.openXml_chk.Location = New System.Drawing.Point(185, 97)
        Me.openXml_chk.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.openXml_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.openXml_chk.MinimumSize = New System.Drawing.Size(133, 25)
        Me.openXml_chk.Name = "openXml_chk"
        Me.openXml_chk.Size = New System.Drawing.Size(262, 25)
        Me.openXml_chk.TabIndex = 24
        Me.openXml_chk.Text = "Ouvrir le fichier XML après la génération"
        '
        'IR_XML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(696, 210)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "IR_XML"
        Me.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Génération du fichier XML de la déclaration de l'IR"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Select_Server_Label As Label
    Friend WithEvents openXml_chk As ud_CheckBox
    Friend WithEvents Annee_Paie_cbo As ud_ComboBox
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
End Class
