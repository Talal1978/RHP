<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_PivotGridTopValue
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TopValue = New System.Windows.Forms.NumericUpDown()
        Me.TrierPar_cbo = New RHP.ud_ComboBox()
        Me.Tri_chk = New RHP.ud_CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SensTri_cbo = New RHP.ud_ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tout_chk = New RHP.ud_CheckBox()
        Me.AfficherAutres_chk = New RHP.ud_CheckBox()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        CType(Me.TopValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Séléctionner les top :"
        '
        'TopValue
        '
        Me.TopValue.Location = New System.Drawing.Point(137, 13)
        Me.TopValue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TopValue.Name = "TopValue"
        Me.TopValue.Size = New System.Drawing.Size(75, 21)
        Me.TopValue.TabIndex = 1
        Me.TopValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TrierPar_cbo
        '
        Me.TrierPar_cbo.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TrierPar_cbo.DataSource = Nothing
        Me.TrierPar_cbo.DisplayMember = ""
        Me.TrierPar_cbo.DroppedDown = False
        Me.TrierPar_cbo.Location = New System.Drawing.Point(75, 69)
        Me.TrierPar_cbo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TrierPar_cbo.Name = "TrierPar_cbo"
        Me.TrierPar_cbo.SelectedIndex = -1
        Me.TrierPar_cbo.SelectedItem = Nothing
        Me.TrierPar_cbo.SelectedValue = Nothing
        Me.TrierPar_cbo.Size = New System.Drawing.Size(313, 25)
        Me.TrierPar_cbo.TabIndex = 2
        Me.TrierPar_cbo.ValueMember = ""
        '
        'Tri_chk
        '
        Me.Tri_chk.AutoSize = True
        Me.Tri_chk.Checked = True
        Me.Tri_chk.Location = New System.Drawing.Point(75, 46)
        Me.Tri_chk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Tri_chk.MaximumSize = New System.Drawing.Size(0, 20)
        Me.Tri_chk.MinimumSize = New System.Drawing.Size(100, 20)
        Me.Tri_chk.Name = "Tri_chk"
        Me.Tri_chk.Size = New System.Drawing.Size(100, 20)
        Me.Tri_chk.TabIndex = 3
        Me.Tri_chk.Text = "Trier "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Trier par :"
        '
        'SensTri_cbo
        '
        Me.SensTri_cbo.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SensTri_cbo.DataSource = Nothing
        Me.SensTri_cbo.DisplayMember = ""
        Me.SensTri_cbo.DroppedDown = False
        Me.SensTri_cbo.Location = New System.Drawing.Point(258, 41)
        Me.SensTri_cbo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SensTri_cbo.Name = "SensTri_cbo"
        Me.SensTri_cbo.SelectedIndex = -1
        Me.SensTri_cbo.SelectedItem = Nothing
        Me.SensTri_cbo.SelectedValue = Nothing
        Me.SensTri_cbo.Size = New System.Drawing.Size(129, 25)
        Me.SensTri_cbo.TabIndex = 5
        Me.SensTri_cbo.ValueMember = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(181, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Sens du tri :"
        '
        'Tout_chk
        '
        Me.Tout_chk.AutoSize = True
        Me.Tout_chk.Checked = True
        Me.Tout_chk.Location = New System.Drawing.Point(291, 15)
        Me.Tout_chk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Tout_chk.MaximumSize = New System.Drawing.Size(0, 20)
        Me.Tout_chk.MinimumSize = New System.Drawing.Size(100, 20)
        Me.Tout_chk.Name = "Tout_chk"
        Me.Tout_chk.Size = New System.Drawing.Size(100, 20)
        Me.Tout_chk.TabIndex = 3
        Me.Tout_chk.Text = "Afficher tout :"
        '
        'AfficherAutres_chk
        '
        Me.AfficherAutres_chk.AutoSize = True
        Me.AfficherAutres_chk.Checked = True
        Me.AfficherAutres_chk.Location = New System.Drawing.Point(257, 101)
        Me.AfficherAutres_chk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AfficherAutres_chk.MaximumSize = New System.Drawing.Size(0, 20)
        Me.AfficherAutres_chk.MinimumSize = New System.Drawing.Size(100, 20)
        Me.AfficherAutres_chk.Name = "AfficherAutres_chk"
        Me.AfficherAutres_chk.Size = New System.Drawing.Size(129, 20)
        Me.AfficherAutres_chk.TabIndex = 3
        Me.AfficherAutres_chk.Text = "Afficher les autres? :"
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Save_ud)
        Me.Pnl.Controls.Add(Me.Annuler_ud)
        Me.Pnl.Controls.Add(Me.TopValue)
        Me.Pnl.Controls.Add(Me.Label1)
        Me.Pnl.Controls.Add(Me.Label3)
        Me.Pnl.Controls.Add(Me.SensTri_cbo)
        Me.Pnl.Controls.Add(Me.Label2)
        Me.Pnl.Controls.Add(Me.AfficherAutres_chk)
        Me.Pnl.Controls.Add(Me.TrierPar_cbo)
        Me.Pnl.Controls.Add(Me.Tout_chk)
        Me.Pnl.Controls.Add(Me.Tri_chk)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 33)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(412, 180)
        Me.Pnl.TabIndex = 214
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
        Me.Save_ud.Location = New System.Drawing.Point(305, 135)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(100, 33)
        Me.Save_ud.TabIndex = 214
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
        Me.Annuler_ud.Location = New System.Drawing.Point(7, 135)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(100, 33)
        Me.Annuler_ud.TabIndex = 215
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
        Me.Titre_lbl.Size = New System.Drawing.Size(412, 31)
        Me.Titre_lbl.TabIndex = 215
        Me.Titre_lbl.Text = "Afficher un nombre de lignes"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Zoom_PivotGridTopValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(416, 215)
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.Titre_lbl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Zoom_PivotGridTopValue"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Top valeurs"
        CType(Me.TopValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TopValue As NumericUpDown
    Friend WithEvents TrierPar_cbo As ud_ComboBox
    Friend WithEvents Tri_chk As ud_CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SensTri_cbo As ud_ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Tout_chk As ud_CheckBox
    Friend WithEvents AfficherAutres_chk As ud_CheckBox
    Friend WithEvents Pnl As Panel
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
End Class
