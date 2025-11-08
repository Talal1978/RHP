<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TC_GED
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
        Me.FD_Alias_Text = New RHP.ud_TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Zone_Index_Text = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.oList = New System.Windows.Forms.ListView()
        Me.FD_Alias = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.File_Path = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Dat_Crea = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Taille = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Name_Ecran = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Value_Index = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Created_By = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FD_Alias_Text
        '
        Me.FD_Alias_Text.BackColor = System.Drawing.Color.White
        Me.FD_Alias_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.FD_Alias_Text.Location = New System.Drawing.Point(152, 8)
        Me.FD_Alias_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.FD_Alias_Text.MaxLength = 50
        Me.FD_Alias_Text.Multiline = False
        Me.FD_Alias_Text.Name = "FD_Alias_Text"
        Me.FD_Alias_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.FD_Alias_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.FD_Alias_Text.ReadOnly = False
        Me.FD_Alias_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.FD_Alias_Text.SelectionStart = 0
        Me.FD_Alias_Text.Size = New System.Drawing.Size(303, 26)
        Me.FD_Alias_Text.TabIndex = 202
        Me.FD_Alias_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.FD_Alias_Text.UseSystemPasswordChar = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(21, 11)
        Me.Label22.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(111, 16)
        Me.Label22.TabIndex = 201
        Me.Label22.Tag = ""
        Me.Label22.Text = "Nom du Document"
        '
        'Zone_Index_Text
        '
        Me.Zone_Index_Text.BackColor = System.Drawing.Color.White
        Me.Zone_Index_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Zone_Index_Text.Location = New System.Drawing.Point(539, 8)
        Me.Zone_Index_Text.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Zone_Index_Text.MaxLength = 50
        Me.Zone_Index_Text.Multiline = False
        Me.Zone_Index_Text.Name = "Zone_Index_Text"
        Me.Zone_Index_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Zone_Index_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Zone_Index_Text.ReadOnly = False
        Me.Zone_Index_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Zone_Index_Text.SelectionStart = 0
        Me.Zone_Index_Text.Size = New System.Drawing.Size(527, 26)
        Me.Zone_Index_Text.TabIndex = 213
        Me.Zone_Index_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Zone_Index_Text.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(469, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 214
        Me.Label1.Tag = ""
        Me.Label1.Text = "mots clés"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.FD_Alias_Text)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label22)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Zone_Index_Text)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.oList)
        Me.SplitContainer1.Size = New System.Drawing.Size(1083, 735)
        Me.SplitContainer1.SplitterDistance = 45
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 215
        '
        'oList
        '
        Me.oList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FD_Alias, Me.File_Path, Me.Dat_Crea, Me.Taille, Me.Name_Ecran, Me.Value_Index, Me.Created_By})
        Me.oList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.oList.HideSelection = False
        Me.oList.Location = New System.Drawing.Point(0, 0)
        Me.oList.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.oList.Name = "oList"
        Me.oList.Size = New System.Drawing.Size(1083, 689)
        Me.oList.TabIndex = 0
        Me.oList.UseCompatibleStateImageBehavior = False
        Me.oList.View = System.Windows.Forms.View.Details
        '
        'FD_Alias
        '
        Me.FD_Alias.Text = "Nom de fichier"
        Me.FD_Alias.Width = 200
        '
        'File_Path
        '
        Me.File_Path.Text = "Emplacement"
        Me.File_Path.Width = 190
        '
        'Dat_Crea
        '
        Me.Dat_Crea.Text = "Date"
        Me.Dat_Crea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Crea.Width = 80
        '
        'Taille
        '
        Me.Taille.Text = "Taille"
        Me.Taille.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Name_Ecran
        '
        Me.Name_Ecran.Text = "Objet lié"
        Me.Name_Ecran.Width = 100
        '
        'Value_Index
        '
        Me.Value_Index.Text = "Référence"
        Me.Value_Index.Width = 100
        '
        'Created_By
        '
        Me.Created_By.Text = "Créé par"
        Me.Created_By.Width = 200
        '
        'TC_GED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1083, 735)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "TC_GED"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Gestion électronique de documents"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FD_Alias_Text As ud_TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Zone_Index_Text As ud_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents oList As System.Windows.Forms.ListView
    Friend WithEvents FD_Alias As System.Windows.Forms.ColumnHeader
    Friend WithEvents File_Path As System.Windows.Forms.ColumnHeader
    Friend WithEvents Dat_Crea As System.Windows.Forms.ColumnHeader
    Friend WithEvents Taille As System.Windows.Forms.ColumnHeader
    Friend WithEvents Name_Ecran As System.Windows.Forms.ColumnHeader
    Friend WithEvents Value_Index As System.Windows.Forms.ColumnHeader
    Friend WithEvents Created_By As System.Windows.Forms.ColumnHeader
End Class
