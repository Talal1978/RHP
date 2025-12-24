<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Compilateur
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.Resultat = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Formule_Function_Text = New System.Windows.Forms.RichTextBox()
        Me.Entete_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.FunctionAdd_pb = New System.Windows.Forms.PictureBox()
        Me.RubriqueAdd_pb = New System.Windows.Forms.PictureBox()
        Me.Back_pb = New System.Windows.Forms.PictureBox()
        Me.Simuler_pb = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Next_pb = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Entete_pnl.SuspendLayout()
        CType(Me.FunctionAdd_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RubriqueAdd_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Back_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Simuler_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Next_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Resultat
        '
        Me.Resultat.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        '
        '
        '
        Me.Resultat.Border.Class = "TextBoxBorder"
        Me.Resultat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Resultat.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Resultat.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Resultat.Location = New System.Drawing.Point(2, 273)
        Me.Resultat.Multiline = True
        Me.Resultat.Name = "Resultat"
        Me.Resultat.ReadOnly = True
        Me.Resultat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Resultat.Size = New System.Drawing.Size(718, 44)
        Me.Resultat.TabIndex = 12
        '
        'Formule_Function_Text
        '
        Me.Formule_Function_Text.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Formule_Function_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Formule_Function_Text.Location = New System.Drawing.Point(2, 47)
        Me.Formule_Function_Text.Name = "Formule_Function_Text"
        Me.Formule_Function_Text.Size = New System.Drawing.Size(718, 226)
        Me.Formule_Function_Text.TabIndex = 15
        Me.Formule_Function_Text.Text = ""
        '
        'Entete_pnl
        '
        Me.Entete_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Entete_pnl.ColumnCount = 7
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.Entete_pnl.Controls.Add(Me.FunctionAdd_pb, 1, 0)
        Me.Entete_pnl.Controls.Add(Me.Back_pb, 3, 0)
        Me.Entete_pnl.Controls.Add(Me.PictureBox1, 6, 0)
        Me.Entete_pnl.Controls.Add(Me.Titre_lbl, 5, 0)
        Me.Entete_pnl.Controls.Add(Me.Next_pb, 4, 0)
        Me.Entete_pnl.Controls.Add(Me.RubriqueAdd_pb, 1, 0)
        Me.Entete_pnl.Controls.Add(Me.Simuler_pb, 0, 0)
        Me.Entete_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Entete_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Entete_pnl.Name = "Entete_pnl"
        Me.Entete_pnl.Padding = New System.Windows.Forms.Padding(2)
        Me.Entete_pnl.RowCount = 1
        Me.Entete_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Entete_pnl.Size = New System.Drawing.Size(718, 45)
        Me.Entete_pnl.TabIndex = 16
        '
        'FunctionAdd_pb
        '
        Me.FunctionAdd_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FunctionAdd_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FunctionAdd_pb.Image = Global.RHP.My.Resources.Resources.btn_function
        Me.FunctionAdd_pb.InitialImage = Nothing
        Me.FunctionAdd_pb.Location = New System.Drawing.Point(37, 5)
        Me.FunctionAdd_pb.Name = "FunctionAdd_pb"
        Me.FunctionAdd_pb.Size = New System.Drawing.Size(26, 35)
        Me.FunctionAdd_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.FunctionAdd_pb.TabIndex = 1
        Me.FunctionAdd_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.FunctionAdd_pb, "Ajouter une fonction de paie")
        '
        'RubriqueAdd_pb
        '
        Me.RubriqueAdd_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RubriqueAdd_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RubriqueAdd_pb.Image = Global.RHP.My.Resources.Resources.btn_edit_doc
        Me.RubriqueAdd_pb.InitialImage = Nothing
        Me.RubriqueAdd_pb.Location = New System.Drawing.Point(69, 5)
        Me.RubriqueAdd_pb.Name = "RubriqueAdd_pb"
        Me.RubriqueAdd_pb.Size = New System.Drawing.Size(26, 35)
        Me.RubriqueAdd_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.RubriqueAdd_pb.TabIndex = 0
        Me.RubriqueAdd_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.RubriqueAdd_pb, "Ajouter une rubrique de la paie")
        '
        'Back_pb
        '
        Me.Back_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Back_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Back_pb.Image = Global.RHP.My.Resources.Resources.btn_div_back
        Me.Back_pb.InitialImage = Nothing
        Me.Back_pb.Location = New System.Drawing.Point(101, 5)
        Me.Back_pb.Name = "Back_pb"
        Me.Back_pb.Size = New System.Drawing.Size(26, 35)
        Me.Back_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Back_pb.TabIndex = 35
        Me.Back_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Back_pb, "Précédent")
        '
        'Simuler_pb
        '
        Me.Simuler_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Simuler_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Simuler_pb.Image = Global.RHP.My.Resources.Resources.btn_netToBrut
        Me.Simuler_pb.InitialImage = Nothing
        Me.Simuler_pb.Location = New System.Drawing.Point(5, 5)
        Me.Simuler_pb.Name = "Simuler_pb"
        Me.Simuler_pb.Size = New System.Drawing.Size(26, 35)
        Me.Simuler_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Simuler_pb.TabIndex = 2
        Me.Simuler_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Simuler_pb, "Simuler")
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(687, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Fermer")
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(165, 7)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(516, 31)
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.Text = "Compilateur de formule"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Next_pb
        '
        Me.Next_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Next_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Next_pb.Image = Global.RHP.My.Resources.Resources.btn_div_next
        Me.Next_pb.InitialImage = Nothing
        Me.Next_pb.Location = New System.Drawing.Point(133, 5)
        Me.Next_pb.Name = "Next_pb"
        Me.Next_pb.Size = New System.Drawing.Size(26, 35)
        Me.Next_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Next_pb.TabIndex = 36
        Me.Next_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Next_pb, "Suivant")
        '
        'Zoom_Compilateur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(722, 319)
        Me.Controls.Add(Me.Formule_Function_Text)
        Me.Controls.Add(Me.Entete_pnl)
        Me.Controls.Add(Me.Resultat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Compilateur"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compilateur de formules et rubriques de la paie"
        Me.Entete_pnl.ResumeLayout(False)
        CType(Me.FunctionAdd_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RubriqueAdd_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Back_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Simuler_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Next_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Resultat As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Formule_Function_Text As RichTextBox
    Friend WithEvents Entete_pnl As TableLayoutPanel
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Simuler_pb As PictureBox
    Friend WithEvents FunctionAdd_pb As PictureBox
    Friend WithEvents RubriqueAdd_pb As PictureBox
    Friend WithEvents Back_pb As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Next_pb As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
