<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_RubriquesPredefinies
    inherits Ecran

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
        Me.Select_All_chk = New RHP.ud_CheckBox()
        Me.lv = New System.Windows.Forms.ListView()
        Me.Nom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Intitule = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descriptif = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.RubriqueGlobal_chk = New RHP.ud_CheckBox()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Save_ud = New RHP.ud_button()
        Me.Personnal_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Select_All_chk
        '
        Me.Select_All_chk.AutoSize = True
        Me.Select_All_chk.Checked = True
        Me.Select_All_chk.Location = New System.Drawing.Point(314, 5)
        Me.Select_All_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.Select_All_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Select_All_chk.MinimumSize = New System.Drawing.Size(133, 25)
        Me.Select_All_chk.Name = "Select_All_chk"
        Me.Select_All_chk.Size = New System.Drawing.Size(133, 25)
        Me.Select_All_chk.TabIndex = 252
        Me.Select_All_chk.Text = "Sélection"
        '
        'lv
        '
        Me.lv.CheckBoxes = True
        Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Nom, Me.Intitule, Me.Descriptif})
        Me.lv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv.ForeColor = System.Drawing.Color.DimGray
        Me.lv.GridLines = True
        Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv.HideSelection = False
        Me.lv.Location = New System.Drawing.Point(3, 40)
        Me.lv.Margin = New System.Windows.Forms.Padding(4)
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(1242, 318)
        Me.lv.TabIndex = 1
        Me.lv.UseCompatibleStateImageBehavior = False
        Me.lv.View = System.Windows.Forms.View.Details
        '
        'Nom
        '
        Me.Nom.Text = "Nom"
        Me.Nom.Width = 150
        '
        'Intitule
        '
        Me.Intitule.Text = "Intitulé"
        Me.Intitule.Width = 300
        '
        'Descriptif
        '
        Me.Descriptif.Text = "Description"
        Me.Descriptif.Width = 900
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(3, 2)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(1242, 38)
        Me.Titre_lbl.TabIndex = 34
        Me.Titre_lbl.Text = "Ajouter des rubriques prédéfinies"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 3
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 309.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.Personnal_pnl.Controls.Add(Me.RubriqueGlobal_chk, 1, 1)
        Me.Personnal_pnl.Controls.Add(Me.Select_All_chk, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.Annuler_ud, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Save_ud, 2, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Personnal_pnl.Location = New System.Drawing.Point(3, 358)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 2
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(1242, 60)
        Me.Personnal_pnl.TabIndex = 35
        '
        'RubriqueGlobal_chk
        '
        Me.RubriqueGlobal_chk.AutoSize = True
        Me.RubriqueGlobal_chk.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.RubriqueGlobal_chk.Checked = True
        Me.RubriqueGlobal_chk.Location = New System.Drawing.Point(314, 35)
        Me.RubriqueGlobal_chk.Margin = New System.Windows.Forms.Padding(5)
        Me.RubriqueGlobal_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.RubriqueGlobal_chk.MinimumSize = New System.Drawing.Size(133, 25)
        Me.RubriqueGlobal_chk.Name = "RubriqueGlobal_chk"
        Me.RubriqueGlobal_chk.Size = New System.Drawing.Size(229, 25)
        Me.RubriqueGlobal_chk.TabIndex = 251
        Me.RubriqueGlobal_chk.Text = "Créer en tant que rubrique globale"
        '
        'Annuler_ud
        '
        Me.Annuler_ud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.bgColor = System.Drawing.Color.White
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.isDefault = False
        Me.Annuler_ud.Location = New System.Drawing.Point(13, 10)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(13, 10, 4, 10)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(133, 41)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Personnal_pnl.SetRowSpan(Me.Annuler_ud, 2)
        Me.Annuler_ud.Size = New System.Drawing.Size(133, 41)
        Me.Annuler_ud.TabIndex = 252
        Me.Annuler_ud.Text = "Annuler"
        '
        'Save_ud
        '
        Me.Save_ud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_ud.AutoSize = True
        Me.Save_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.bgColor = System.Drawing.Color.White
        Me.Save_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Save_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.BorderSize = 2
        Me.Save_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_ud.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_ud.isDefault = False
        Me.Save_ud.Location = New System.Drawing.Point(1096, 10)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(4, 10, 13, 10)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(133, 41)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Personnal_pnl.SetRowSpan(Me.Save_ud, 2)
        Me.Save_ud.Size = New System.Drawing.Size(133, 41)
        Me.Save_ud.TabIndex = 251
        Me.Save_ud.Text = "Enregistrer"
        '
        'Zoom_RubriquesPredefinies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1248, 420)
        Me.Controls.Add(Me.lv)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Controls.Add(Me.Titre_lbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_RubriquesPredefinies"
        Me.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajouter des rubriques prédéfinies"
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Personnal_pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lv As ListView
    Friend WithEvents Nom As ColumnHeader
    Friend WithEvents Intitule As ColumnHeader
    Friend WithEvents Descriptif As ColumnHeader
    Friend WithEvents Select_All_chk As ud_CheckBox
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents RubriqueGlobal_chk As ud_CheckBox
End Class
