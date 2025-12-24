<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_FsRb
    Inherits System.Windows.Forms.Form

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
        Me.lv = New System.Windows.Forms.ListView()
        Me.Nom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Intitule = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descriptif = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Copy_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Save_ud = New RHP.ud_button()
        Me.Personnal_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'lv
        '
        Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Nom, Me.Intitule, Me.Descriptif})
        Me.lv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv.ForeColor = System.Drawing.Color.DimGray
        Me.lv.GridLines = True
        Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv.HideSelection = False
        Me.lv.Location = New System.Drawing.Point(3, 40)
        Me.lv.Margin = New System.Windows.Forms.Padding(4)
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(1242, 324)
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
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.Text = "Mise à jour prête pour des fonctions et rubriques système"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 3
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146.0!))
        Me.Personnal_pnl.Controls.Add(Me.Copy_ud, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.Annuler_ud, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Save_ud, 2, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Personnal_pnl.Location = New System.Drawing.Point(3, 364)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(1242, 54)
        Me.Personnal_pnl.TabIndex = 34
        '
        'Copy_ud
        '
        Me.Copy_ud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Copy_ud.AutoSize = True
        Me.Copy_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Copy_ud.bgColor = System.Drawing.Color.White
        Me.Copy_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Copy_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Copy_ud.BorderSize = 2
        Me.Copy_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Copy_ud.Image = Global.RHP.My.Resources.Resources.btn_copy
        Me.Copy_ud.isDefault = False
        Me.Copy_ud.Location = New System.Drawing.Point(950, 5)
        Me.Copy_ud.Margin = New System.Windows.Forms.Padding(4, 5, 13, 5)
        Me.Copy_ud.MinimumSize = New System.Drawing.Size(133, 41)
        Me.Copy_ud.Name = "Copy_ud"
        Me.Copy_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Copy_ud.Size = New System.Drawing.Size(133, 44)
        Me.Copy_ud.TabIndex = 253
        Me.Copy_ud.Text = "Copier"
        Me.Copy_ud.ToolTip = "Copier"
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
        Me.Annuler_ud.Location = New System.Drawing.Point(13, 5)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(13, 5, 4, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(133, 41)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(133, 44)
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
        Me.Save_ud.Location = New System.Drawing.Point(1100, 5)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(4, 5, 13, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(133, 41)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(133, 44)
        Me.Save_ud.TabIndex = 251
        Me.Save_ud.Text = "Enregistrer"
        '
        'Zoom_FsRb
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
        Me.Name = "Zoom_FsRb"
        Me.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mise à jour prête pour des fonctions et rubriques système"
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Personnal_pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lv As ListView
    Friend WithEvents Nom As ColumnHeader
    Friend WithEvents Intitule As ColumnHeader
    Friend WithEvents Descriptif As ColumnHeader
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Copy_ud As ud_button
End Class
