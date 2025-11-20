<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Param_Ville
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Nom_Pay_Text = New RHP.ud_TextBox()
        Me.Cod_Pay_Text = New RHP.ud_TextBox()
        Me.Cod_Ville_Text = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Ville_Text = New RHP.ud_TextBox()
        Me.Grd_Villes = New RHP.ud_Grd()
        Me.Cod_Ville = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ville = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Distance_Km = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grd_Villes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.Nom_Pay_Text)
        Me.GroupBox1.Controls.Add(Me.Cod_Pay_Text)
        Me.GroupBox1.Controls.Add(Me.Cod_Ville_Text)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.Ville_Text)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1215, 111)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = ""
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(51, 63)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(36, 19)
        Me.LinkLabel2.TabIndex = 205
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Ville"
        '
        'Nom_Pay_Text
        '
        Me.Nom_Pay_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Pay_Text.ContextMenuStrip = Nothing
        Me.Nom_Pay_Text.Enabled = False
        Me.Nom_Pay_Text.Location = New System.Drawing.Point(206, 26)
        Me.Nom_Pay_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Nom_Pay_Text.MaxLength = 10
        Me.Nom_Pay_Text.Multiline = False
        Me.Nom_Pay_Text.Name = "Nom_Pay_Text"
        Me.Nom_Pay_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Pay_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Pay_Text.ReadOnly = False
        Me.Nom_Pay_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Pay_Text.SelectionStart = 0
        Me.Nom_Pay_Text.Size = New System.Drawing.Size(431, 26)
        Me.Nom_Pay_Text.TabIndex = 204
        Me.Nom_Pay_Text.Tag = ""
        Me.Nom_Pay_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Pay_Text.UseSystemPasswordChar = False
        '
        'Cod_Pay_Text
        '
        Me.Cod_Pay_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Pay_Text.ContextMenuStrip = Nothing
        Me.Cod_Pay_Text.Location = New System.Drawing.Point(89, 26)
        Me.Cod_Pay_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Cod_Pay_Text.MaxLength = 10
        Me.Cod_Pay_Text.Multiline = False
        Me.Cod_Pay_Text.Name = "Cod_Pay_Text"
        Me.Cod_Pay_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Pay_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Pay_Text.ReadOnly = True
        Me.Cod_Pay_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Pay_Text.SelectionStart = 0
        Me.Cod_Pay_Text.Size = New System.Drawing.Size(111, 26)
        Me.Cod_Pay_Text.TabIndex = 203
        Me.Cod_Pay_Text.Tag = ""
        Me.Cod_Pay_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Pay_Text.UseSystemPasswordChar = False
        '
        'Cod_Ville_Text
        '
        Me.Cod_Ville_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cod_Ville_Text.ContextMenuStrip = Nothing
        Me.Cod_Ville_Text.Location = New System.Drawing.Point(89, 59)
        Me.Cod_Ville_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Cod_Ville_Text.MaxLength = 10
        Me.Cod_Ville_Text.Multiline = False
        Me.Cod_Ville_Text.Name = "Cod_Ville_Text"
        Me.Cod_Ville_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Ville_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Ville_Text.ReadOnly = True
        Me.Cod_Ville_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Ville_Text.SelectionStart = 0
        Me.Cod_Ville_Text.Size = New System.Drawing.Size(111, 26)
        Me.Cod_Ville_Text.TabIndex = 200
        Me.Cod_Ville_Text.Tag = ""
        Me.Cod_Ville_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Ville_Text.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(46, 30)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(40, 19)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Pays"
        '
        'Ville_Text
        '
        Me.Ville_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Ville_Text.ContextMenuStrip = Nothing
        Me.Ville_Text.Location = New System.Drawing.Point(206, 59)
        Me.Ville_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Ville_Text.MaxLength = 50
        Me.Ville_Text.Multiline = False
        Me.Ville_Text.Name = "Ville_Text"
        Me.Ville_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ville_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ville_Text.ReadOnly = False
        Me.Ville_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ville_Text.SelectionStart = 0
        Me.Ville_Text.Size = New System.Drawing.Size(431, 26)
        Me.Ville_Text.TabIndex = 1
        Me.Ville_Text.Tag = ""
        Me.Ville_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ville_Text.UseSystemPasswordChar = False
        '
        'Grd_Villes
        '
        Me.Grd_Villes.AfficherLesEntetesLignes = True
        Me.Grd_Villes.AllowUserToAddRows = False
        Me.Grd_Villes.AllowUserToDeleteRows = False
        Me.Grd_Villes.AlternerLesLignes = False
        Me.Grd_Villes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Villes.BackgroundColor = System.Drawing.Color.White
        Me.Grd_Villes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Villes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Villes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Villes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Villes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Ville, Me.Ville, Me.Distance_Km})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Villes.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Villes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Villes.EnableHeadersVisualStyles = False
        Me.Grd_Villes.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Villes.Location = New System.Drawing.Point(0, 111)
        Me.Grd_Villes.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Villes.MinimumSize = New System.Drawing.Size(500, 0)
        Me.Grd_Villes.Name = "Grd_Villes"
        Me.Grd_Villes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Villes.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Villes.RowHeadersWidth = 51
        Me.Grd_Villes.Size = New System.Drawing.Size(1215, 510)
        Me.Grd_Villes.TabIndex = 101
        '
        'Cod_Ville
        '
        Me.Cod_Ville.HeaderText = "Code ville"
        Me.Cod_Ville.MinimumWidth = 6
        Me.Cod_Ville.Name = "Cod_Ville"
        Me.Cod_Ville.ReadOnly = True
        Me.Cod_Ville.Visible = False
        Me.Cod_Ville.Width = 116
        '
        'Ville
        '
        Me.Ville.HeaderText = "Ville"
        Me.Ville.MinimumWidth = 350
        Me.Ville.Name = "Ville"
        Me.Ville.ReadOnly = True
        Me.Ville.Width = 350
        '
        'Distance_Km
        '
        Me.Distance_Km.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        '
        '
        '
        Me.Distance_Km.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.Distance_Km.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Distance_Km.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Distance_Km.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.NullValue = "0"
        Me.Distance_Km.DefaultCellStyle = DataGridViewCellStyle2
        Me.Distance_Km.HeaderText = "Distance"
        Me.Distance_Km.Increment = 1.0R
        Me.Distance_Km.MinimumWidth = 6
        Me.Distance_Km.Name = "Distance_Km"
        Me.Distance_Km.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Distance_Km.Width = 107
        '
        'Param_Ville
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1215, 621)
        Me.Controls.Add(Me.Grd_Villes)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Param_Ville"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage des villes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grd_Villes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cod_Ville_Text As ud_TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Ville_Text As ud_TextBox
    Friend WithEvents Cod_Pay_Text As ud_TextBox
    Friend WithEvents Nom_Pay_Text As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Grd_Villes As ud_Grd
    Friend WithEvents Cod_Ville As DataGridViewTextBoxColumn
    Friend WithEvents Ville As DataGridViewTextBoxColumn
    Friend WithEvents Distance_Km As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
End Class
