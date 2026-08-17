<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Profile_Droits_SP
    Inherits Ecran

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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    'Thème visuel : identique à Zoom_SP_Nouvelle_Section (formulaire sans
    'bordure cadré colorBase01, bandeau titre, panel clair et contrôles ud_*).
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Chk_Creer = New RHP.ud_CheckBox()
        Me.Chk_Modifier = New RHP.ud_CheckBox()
        Me.Chk_Supprimer = New RHP.ud_CheckBox()
        Me.Chk_Valider = New RHP.ud_CheckBox()
        Me.Chk_Imprimer = New RHP.ud_CheckBox()
        Me.Chk_GED = New RHP.ud_CheckBox()
        Me.Lbl_Aide = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Chk_Creer)
        Me.Panel1.Controls.Add(Me.Chk_Modifier)
        Me.Panel1.Controls.Add(Me.Chk_Supprimer)
        Me.Panel1.Controls.Add(Me.Chk_Valider)
        Me.Panel1.Controls.Add(Me.Chk_Imprimer)
        Me.Panel1.Controls.Add(Me.Chk_GED)
        Me.Panel1.Controls.Add(Me.Lbl_Aide)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 47)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(556, 291)
        Me.Panel1.TabIndex = 0
        '
        'Chk_Creer
        '
        Me.Chk_Creer.Checked = False
        Me.Chk_Creer.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Chk_Creer.Location = New System.Drawing.Point(24, 24)
        Me.Chk_Creer.Margin = New System.Windows.Forms.Padding(4)
        Me.Chk_Creer.Name = "Chk_Creer"
        Me.Chk_Creer.TabIndex = 1
        Me.Chk_Creer.Text = "Créer / Nouveau"
        '
        'Chk_Modifier
        '
        Me.Chk_Modifier.Checked = False
        Me.Chk_Modifier.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Chk_Modifier.Location = New System.Drawing.Point(24, 56)
        Me.Chk_Modifier.Margin = New System.Windows.Forms.Padding(4)
        Me.Chk_Modifier.Name = "Chk_Modifier"
        Me.Chk_Modifier.TabIndex = 2
        Me.Chk_Modifier.Text = "Modifier"
        '
        'Chk_Supprimer
        '
        Me.Chk_Supprimer.Checked = False
        Me.Chk_Supprimer.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Chk_Supprimer.Location = New System.Drawing.Point(24, 88)
        Me.Chk_Supprimer.Margin = New System.Windows.Forms.Padding(4)
        Me.Chk_Supprimer.Name = "Chk_Supprimer"
        Me.Chk_Supprimer.TabIndex = 3
        Me.Chk_Supprimer.Text = "Supprimer"
        '
        'Chk_Valider
        '
        Me.Chk_Valider.Checked = False
        Me.Chk_Valider.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Chk_Valider.Location = New System.Drawing.Point(24, 120)
        Me.Chk_Valider.Margin = New System.Windows.Forms.Padding(4)
        Me.Chk_Valider.Name = "Chk_Valider"
        Me.Chk_Valider.TabIndex = 4
        Me.Chk_Valider.Text = "Valider (workflow de signature)"
        '
        'Chk_Imprimer
        '
        Me.Chk_Imprimer.Checked = False
        Me.Chk_Imprimer.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Chk_Imprimer.Location = New System.Drawing.Point(24, 152)
        Me.Chk_Imprimer.Margin = New System.Windows.Forms.Padding(4)
        Me.Chk_Imprimer.Name = "Chk_Imprimer"
        Me.Chk_Imprimer.TabIndex = 5
        Me.Chk_Imprimer.Text = "Imprimer"
        '
        'Chk_GED
        '
        Me.Chk_GED.Checked = False
        Me.Chk_GED.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Chk_GED.Location = New System.Drawing.Point(24, 184)
        Me.Chk_GED.Margin = New System.Windows.Forms.Padding(4)
        Me.Chk_GED.Name = "Chk_GED"
        Me.Chk_GED.TabIndex = 6
        Me.Chk_GED.Text = "GED (pièces jointes)"
        '
        'Lbl_Aide
        '
        Me.Lbl_Aide.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lbl_Aide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Aide.Location = New System.Drawing.Point(20, 222)
        Me.Lbl_Aide.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Aide.Name = "Lbl_Aide"
        Me.Lbl_Aide.Size = New System.Drawing.Size(512, 60)
        Me.Lbl_Aide.TabIndex = 7
        Me.Lbl_Aide.Text = "La visibilité de la page (Consulter) se gère par la case Visible de l'onglet Portail."
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ent_pnl.ColumnCount = 3
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.Controls.Add(Me.Zoom_lbl, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Save_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 2, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(556, 45)
        Me.ent_pnl.TabIndex = 7
        '
        'Zoom_lbl
        '
        Me.Zoom_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Zoom_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Zoom_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Zoom_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Zoom_lbl.Location = New System.Drawing.Point(4, 0)
        Me.Zoom_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Zoom_lbl.Name = "Zoom_lbl"
        Me.Zoom_lbl.Size = New System.Drawing.Size(452, 39)
        Me.Zoom_lbl.TabIndex = 33
        Me.Zoom_lbl.Text = "Habilitations de la page"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Save_pb
        '
        Me.Save_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(472, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(36, 37)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 36
        Me.Save_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(516, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(36, 37)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 34
        Me.Close_pb.TabStop = False
        '
        'Zoom_Profile_Droits_SP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(560, 340)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ent_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_Profile_Droits_SP"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Habilitations de la page"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Chk_Creer As ud_CheckBox
    Friend WithEvents Chk_Modifier As ud_CheckBox
    Friend WithEvents Chk_Supprimer As ud_CheckBox
    Friend WithEvents Chk_Valider As ud_CheckBox
    Friend WithEvents Chk_Imprimer As ud_CheckBox
    Friend WithEvents Chk_GED As ud_CheckBox
    Friend WithEvents Lbl_Aide As Label
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
End Class
