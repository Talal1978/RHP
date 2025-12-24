<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_9421
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.components = New System.ComponentModel.Container()
        Me.Cod_Rubrique_txt = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChargerLesRubriquesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Ud_Panel2 = New RHP.ud_Panel()
        Me.Formule_Function_Text = New System.Windows.Forms.RichTextBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Aggregation_cbo = New RHP.ud_ComboBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Ud_Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cod_Rubrique_txt
        '
        Me.Cod_Rubrique_txt.Location = New System.Drawing.Point(0, 0)
        Me.Cod_Rubrique_txt.Name = "Cod_Rubrique_txt"
        Me.Cod_Rubrique_txt.Size = New System.Drawing.Size(1, 20)
        Me.Cod_Rubrique_txt.TabIndex = 17
        Me.Cod_Rubrique_txt.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChargerLesRubriquesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(240, 26)
        '
        'ChargerLesRubriquesToolStripMenuItem
        '
        Me.ChargerLesRubriquesToolStripMenuItem.Name = "ChargerLesRubriquesToolStripMenuItem"
        Me.ChargerLesRubriquesToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ChargerLesRubriquesToolStripMenuItem.Text = "Charger les rubriques de la paie"
        '
        'Ud_Panel2
        '
        Me.Ud_Panel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel2.BorderSize = 2
        Me.Ud_Panel2.Controls.Add(Me.Formule_Function_Text)
        Me.Ud_Panel2.Controls.Add(Me.lbl)
        Me.Ud_Panel2.Controls.Add(Me.Aggregation_cbo)
        Me.Ud_Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Panel2.Name = "Ud_Panel2"
        Me.Ud_Panel2.Padding = New System.Windows.Forms.Padding(2, 2, 3, 3)
        Me.Ud_Panel2.Size = New System.Drawing.Size(225, 150)
        Me.Ud_Panel2.TabIndex = 2
        '
        'Formule_Function_Text
        '
        Me.Formule_Function_Text.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Formule_Function_Text.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Formule_Function_Text.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Formule_Function_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Formule_Function_Text.Location = New System.Drawing.Point(2, 46)
        Me.Formule_Function_Text.Name = "Formule_Function_Text"
        Me.Formule_Function_Text.Size = New System.Drawing.Size(220, 76)
        Me.Formule_Function_Text.TabIndex = 16
        Me.Formule_Function_Text.Text = ""
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(2, 2)
        Me.lbl.Margin = New System.Windows.Forms.Padding(0)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(220, 44)
        Me.lbl.TabIndex = 0
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Aggregation_cbo
        '
        Me.Aggregation_cbo.DataSource = Nothing
        Me.Aggregation_cbo.DisplayMember = ""
        Me.Aggregation_cbo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Aggregation_cbo.DroppedDown = False
        Me.Aggregation_cbo.Location = New System.Drawing.Point(2, 122)
        Me.Aggregation_cbo.Name = "Aggregation_cbo"
        Me.Aggregation_cbo.SelectedIndex = -1
        Me.Aggregation_cbo.SelectedItem = Nothing
        Me.Aggregation_cbo.SelectedValue = Nothing
        Me.Aggregation_cbo.Size = New System.Drawing.Size(220, 25)
        Me.Aggregation_cbo.TabIndex = 17
        Me.Aggregation_cbo.ValueMember = ""
        '
        'ud_9421
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Ud_Panel2)
        Me.Controls.Add(Me.Cod_Rubrique_txt)
        Me.Name = "ud_9421"
        Me.Size = New System.Drawing.Size(225, 150)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Ud_Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl As Label
    Friend WithEvents Ud_Panel2 As ud_Panel
    Friend WithEvents Formule_Function_Text As RichTextBox
    Friend WithEvents Cod_Rubrique_txt As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ChargerLesRubriquesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Aggregation_cbo As ud_ComboBox
End Class
