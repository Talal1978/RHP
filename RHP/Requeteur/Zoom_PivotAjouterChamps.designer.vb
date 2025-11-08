<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_PivotAjouterChamps
    ' inherits Ecran

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.beExpression = New DevExpress.XtraEditors.ButtonEdit()
        Me.teBonusName = New DevExpress.XtraEditors.TextEdit()
        Me.labelInternalExpression = New System.Windows.Forms.Label()
        Me.labelBonusName = New System.Windows.Forms.Label()
        Me.toolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        CType(Me.beExpression.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teBonusName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'beExpression
        '
        Me.beExpression.Enabled = False
        Me.beExpression.Location = New System.Drawing.Point(125, 36)
        Me.beExpression.Name = "beExpression"
        '
        '
        '
        Me.beExpression.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.beExpression.Size = New System.Drawing.Size(174, 20)
        Me.beExpression.TabIndex = 18
        '
        'teBonusName
        '
        Me.teBonusName.EditValue = ""
        Me.teBonusName.Location = New System.Drawing.Point(125, 12)
        Me.teBonusName.Name = "teBonusName"
        Me.teBonusName.Size = New System.Drawing.Size(174, 20)
        Me.teBonusName.TabIndex = 17
        '
        'labelInternalExpression
        '
        Me.labelInternalExpression.Location = New System.Drawing.Point(22, 39)
        Me.labelInternalExpression.Margin = New System.Windows.Forms.Padding(4)
        Me.labelInternalExpression.Name = "labelInternalExpression"
        Me.labelInternalExpression.Size = New System.Drawing.Size(97, 13)
        Me.labelInternalExpression.TabIndex = 16
        Me.labelInternalExpression.Text = "Expression:"
        Me.labelInternalExpression.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelBonusName
        '
        Me.labelBonusName.Location = New System.Drawing.Point(25, 14)
        Me.labelBonusName.Margin = New System.Windows.Forms.Padding(4)
        Me.labelBonusName.Name = "labelBonusName"
        Me.labelBonusName.Size = New System.Drawing.Size(94, 17)
        Me.labelBonusName.TabIndex = 15
        Me.labelBonusName.Text = "Nom du champs:"
        Me.labelBonusName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'toolTipController1
        '
        Me.toolTipController1.Rounded = True
        Me.toolTipController1.ToolTipLocation = DevExpress.Utils.ToolTipLocation.RightCenter
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Save_ud)
        Me.Pnl.Controls.Add(Me.Annuler_ud)
        Me.Pnl.Controls.Add(Me.beExpression)
        Me.Pnl.Controls.Add(Me.teBonusName)
        Me.Pnl.Controls.Add(Me.labelInternalExpression)
        Me.Pnl.Controls.Add(Me.labelBonusName)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 33)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(373, 110)
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
        Me.Save_ud.Location = New System.Drawing.Point(267, 72)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(23, 25)
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
        Me.Annuler_ud.Location = New System.Drawing.Point(6, 72)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(23, 25)
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
        Me.Titre_lbl.Size = New System.Drawing.Size(373, 31)
        Me.Titre_lbl.TabIndex = 215
        Me.Titre_lbl.Text = "Ajouter un nouveau champs calculé"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Zoom_PivotAjouterChamps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(377, 145)
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.Titre_lbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Zoom_PivotAjouterChamps"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ajouter un nouveau champs calculé"
        CType(Me.beExpression.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teBonusName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private toolTipController1 As DevExpress.Utils.ToolTipController
    Private labelInternalExpression As Label
    Private labelBonusName As Label
    Private WithEvents teBonusName As DevExpress.XtraEditors.TextEdit
    Private WithEvents beExpression As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Pnl As Panel
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
End Class
