<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Ana
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cod_Preparation_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nom_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_ = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Cod_Preparation_txt)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Nom_txt)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Matricule_txt)
        Me.Panel1.Controls.Add(Me.Nom_)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 31)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(826, 39)
        Me.Panel1.TabIndex = 1
        '
        'Cod_Preparation_txt
        '
        Me.Cod_Preparation_txt.AccessibleDescription = "A"
        Me.Cod_Preparation_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Cod_Preparation_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Preparation_txt.Location = New System.Drawing.Point(616, 7)
        Me.Cod_Preparation_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Preparation_txt.MaxLength = 32767
        Me.Cod_Preparation_txt.Multiline = False
        Me.Cod_Preparation_txt.Name = "Cod_Preparation_txt"
        Me.Cod_Preparation_txt.ReadOnly = True
        Me.Cod_Preparation_txt.Size = New System.Drawing.Size(206, 21)
        Me.Cod_Preparation_txt.TabIndex = 205
        Me.Cod_Preparation_txt.TabStop = False
        Me.Cod_Preparation_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(541, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "Preparation"
        '
        'Nom_txt
        '
        Me.Nom_txt.AccessibleDescription = "A"
        Me.Nom_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Nom_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_txt.Location = New System.Drawing.Point(238, 7)
        Me.Nom_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_txt.MaxLength = 32767
        Me.Nom_txt.Multiline = False
        Me.Nom_txt.Name = "Nom_txt"
        Me.Nom_txt.ReadOnly = True
        Me.Nom_txt.Size = New System.Drawing.Size(284, 21)
        Me.Nom_txt.TabIndex = 205
        Me.Nom_txt.TabStop = False
        Me.Nom_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 16)
        Me.Label2.TabIndex = 204
        Me.Label2.Text = "Nom"
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.Location = New System.Drawing.Point(71, 7)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.Size = New System.Drawing.Size(121, 21)
        Me.Matricule_txt.TabIndex = 205
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Nom_
        '
        Me.Nom_.AutoSize = True
        Me.Nom_.Location = New System.Drawing.Point(6, 12)
        Me.Nom_.Name = "Nom_"
        Me.Nom_.Size = New System.Drawing.Size(59, 16)
        Me.Nom_.TabIndex = 204
        Me.Nom_.Text = "Matricule"
        '
        'TabControl1
        '
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 70)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(826, 434)
        Me.TabControl1.TabIndex = 2
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(826, 31)
        Me.Titre_lbl.TabIndex = 35
        Me.Titre_lbl.Text = "Ventilation analytique"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Zoom_Ana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(826, 504)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Titre_lbl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Zoom_Ana"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Affectation Analytique"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Nom_ As Label
    Friend WithEvents Cod_Preparation_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Nom_txt As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Titre_lbl As Label
End Class
