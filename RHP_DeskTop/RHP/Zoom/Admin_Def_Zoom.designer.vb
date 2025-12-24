<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Def_Zoom
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Protege = New RHP.ud_CheckBox()
        Me.nbLig = New System.Windows.Forms.NumericUpDown()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Order_By_Sens = New RHP.ud_ComboBox()
        Me.Order_By = New System.Windows.Forms.NumericUpDown()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Condition = New RHP.ud_TextBox()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Search_By = New System.Windows.Forms.NumericUpDown()
        Me.Index_Table = New RHP.ud_TextBox()
        Me.Num_Zoom = New RHP.ud_TextBox()
        Me.Description = New RHP.ud_TextBox()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Table_Ref = New RHP.ud_TextBox()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Grd = New RHP.ud_Grd()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.nbLig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Order_By, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Search_By, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Protege
        '
        Me.Protege.AutoSize = True
        Me.Protege.Checked = True
        Me.Protege.Location = New System.Drawing.Point(724, 84)
        Me.Protege.MaximumSize = New System.Drawing.Size(0, 20)
        Me.Protege.MinimumSize = New System.Drawing.Size(100, 20)
        Me.Protege.Name = "Protege"
        Me.Protege.Size = New System.Drawing.Size(100, 20)
        Me.Protege.TabIndex = 8
        Me.Protege.Text = "Protégé"
        '
        'nbLig
        '
        Me.nbLig.Location = New System.Drawing.Point(773, 61)
        Me.nbLig.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.nbLig.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nbLig.Name = "nbLig"
        Me.nbLig.Size = New System.Drawing.Size(64, 21)
        Me.nbLig.TabIndex = 7
        Me.nbLig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbLig.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.Class = ""
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(598, 59)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(169, 23)
        Me.LabelX9.TabIndex = 26
        Me.LabelX9.Text = "Nombre de lignes à afficher  : "
        Me.LabelX9.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.Class = ""
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelX8.Location = New System.Drawing.Point(623, 14)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(73, 23)
        Me.LabelX8.TabIndex = 24
        Me.LabelX8.Text = "Sens de Tri :"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Order_By_Sens
        '
        Me.Order_By_Sens.DataSource = Nothing
        Me.Order_By_Sens.DisplayMember = ""
        Me.Order_By_Sens.DroppedDown = False
        Me.Order_By_Sens.Location = New System.Drawing.Point(702, 13)
        Me.Order_By_Sens.Name = "Order_By_Sens"
        Me.Order_By_Sens.SelectedIndex = -1
        Me.Order_By_Sens.SelectedItem = Nothing
        Me.Order_By_Sens.SelectedValue = Nothing
        Me.Order_By_Sens.Size = New System.Drawing.Size(135, 24)
        Me.Order_By_Sens.TabIndex = 4
        Me.Order_By_Sens.ValueMember = ""
        '
        'Order_By
        '
        Me.Order_By.Location = New System.Drawing.Point(558, 15)
        Me.Order_By.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.Order_By.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Order_By.Name = "Order_By"
        Me.Order_By.Size = New System.Drawing.Size(64, 21)
        Me.Order_By.TabIndex = 3
        Me.Order_By.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Order_By.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.Class = ""
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelX7.Location = New System.Drawing.Point(499, 12)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(53, 23)
        Me.LabelX7.TabIndex = 21
        Me.LabelX7.Text = "Trié par :"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Condition
        '
        Me.Condition.BackColor = System.Drawing.SystemColors.Window
        Me.Condition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Condition.Location = New System.Drawing.Point(102, 175)
        Me.Condition.MaxLength = 32767
        Me.Condition.Multiline = True
        Me.Condition.Name = "Condition"
        Me.Condition.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Condition.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Condition.ReadOnly = False
        Me.Condition.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Condition.SelectionStart = 0
        Me.Condition.Size = New System.Drawing.Size(735, 20)
        Me.Condition.TabIndex = 10
        Me.Condition.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Condition.UseSystemPasswordChar = False
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.Class = ""
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(31, 175)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(66, 20)
        Me.LabelX6.TabIndex = 18
        Me.LabelX6.Text = "Condition : "
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Search_By
        '
        Me.Search_By.Location = New System.Drawing.Point(773, 39)
        Me.Search_By.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.Search_By.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Search_By.Name = "Search_By"
        Me.Search_By.Size = New System.Drawing.Size(64, 21)
        Me.Search_By.TabIndex = 6
        Me.Search_By.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Search_By.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Index_Table
        '
        Me.Index_Table.BackColor = System.Drawing.SystemColors.Window
        Me.Index_Table.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Index_Table.Location = New System.Drawing.Point(324, 13)
        Me.Index_Table.MaxLength = 32767
        Me.Index_Table.Multiline = False
        Me.Index_Table.Name = "Index_Table"
        Me.Index_Table.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Index_Table.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Index_Table.ReadOnly = False
        Me.Index_Table.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Index_Table.SelectionStart = 0
        Me.Index_Table.Size = New System.Drawing.Size(170, 21)
        Me.Index_Table.TabIndex = 2
        Me.Index_Table.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Index_Table.UseSystemPasswordChar = False
        '
        'Num_Zoom
        '
        Me.Num_Zoom.BackColor = System.Drawing.SystemColors.Control
        Me.Num_Zoom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Zoom.Location = New System.Drawing.Point(102, 13)
        Me.Num_Zoom.MaxLength = 32767
        Me.Num_Zoom.Multiline = False
        Me.Num_Zoom.Name = "Num_Zoom"
        Me.Num_Zoom.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Zoom.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Zoom.ReadOnly = True
        Me.Num_Zoom.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Zoom.SelectionStart = 0
        Me.Num_Zoom.Size = New System.Drawing.Size(170, 21)
        Me.Num_Zoom.TabIndex = 1
        Me.Num_Zoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Zoom.UseSystemPasswordChar = False
        '
        'Description
        '
        Me.Description.BackColor = System.Drawing.SystemColors.Window
        Me.Description.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Description.Location = New System.Drawing.Point(102, 107)
        Me.Description.MaxLength = 32767
        Me.Description.Multiline = True
        Me.Description.Name = "Description"
        Me.Description.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Description.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Description.ReadOnly = False
        Me.Description.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Description.SelectionStart = 0
        Me.Description.Size = New System.Drawing.Size(735, 62)
        Me.Description.TabIndex = 9
        Me.Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Description.UseSystemPasswordChar = False
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.Class = ""
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(30, 106)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(66, 20)
        Me.LabelX5.TabIndex = 17
        Me.LabelX5.Text = "Sélection : "
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Table_Ref
        '
        Me.Table_Ref.BackColor = System.Drawing.SystemColors.Window
        Me.Table_Ref.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Table_Ref.Location = New System.Drawing.Point(102, 39)
        Me.Table_Ref.MaxLength = 32767
        Me.Table_Ref.Multiline = True
        Me.Table_Ref.Name = "Table_Ref"
        Me.Table_Ref.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Table_Ref.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Table_Ref.ReadOnly = False
        Me.Table_Ref.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Table_Ref.SelectionStart = 0
        Me.Table_Ref.Size = New System.Drawing.Size(490, 62)
        Me.Table_Ref.TabIndex = 5
        Me.Table_Ref.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Table_Ref.UseSystemPasswordChar = False
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(30, 38)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(66, 20)
        Me.LabelX3.TabIndex = 17
        Me.LabelX3.Text = "From : "
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelX1.Location = New System.Drawing.Point(275, 10)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(43, 23)
        Me.LabelX1.TabIndex = 17
        Me.LabelX1.Text = "Index :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelX2.Location = New System.Drawing.Point(31, 13)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(66, 23)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Zoom"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.Class = ""
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(598, 37)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(169, 23)
        Me.LabelX4.TabIndex = 17
        Me.LabelX4.Text = "Colonne de Recherche  : "
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Grd
        '
        Me.Grd.AllowUserToAddRows = False
        Me.Grd.AllowUserToDeleteRows = False
        Me.Grd.AllowUserToOrderColumns = True
        Me.Grd.AllowUserToResizeColumns = False
        Me.Grd.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.EnableHeadersVisualStyles = False
        Me.Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd.Location = New System.Drawing.Point(0, 206)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd.RowHeadersVisible = False
        Me.Grd.Size = New System.Drawing.Size(972, 291)
        Me.Grd.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Protege)
        Me.Panel1.Controls.Add(Me.Num_Zoom)
        Me.Panel1.Controls.Add(Me.nbLig)
        Me.Panel1.Controls.Add(Me.LabelX4)
        Me.Panel1.Controls.Add(Me.LabelX9)
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.LabelX8)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.Order_By_Sens)
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.Order_By)
        Me.Panel1.Controls.Add(Me.Table_Ref)
        Me.Panel1.Controls.Add(Me.LabelX7)
        Me.Panel1.Controls.Add(Me.LabelX5)
        Me.Panel1.Controls.Add(Me.Condition)
        Me.Panel1.Controls.Add(Me.Description)
        Me.Panel1.Controls.Add(Me.LabelX6)
        Me.Panel1.Controls.Add(Me.Index_Table)
        Me.Panel1.Controls.Add(Me.Search_By)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(972, 206)
        Me.Panel1.TabIndex = 2
        '
        'Admin_Def_Zoom
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(972, 497)
        Me.Controls.Add(Me.Grd)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "Admin_Def_Zoom"
        Me.Tag = "ECR"
        Me.Text = "Gestion des zooms des menus"
        CType(Me.nbLig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Order_By, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Search_By, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Order_By_Sens As ud_ComboBox
    Friend WithEvents Order_By As NumericUpDown
    Private WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Condition As ud_TextBox
    Private WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Search_By As NumericUpDown
    Friend WithEvents Index_Table As ud_TextBox
    Friend WithEvents Num_Zoom As ud_TextBox
    Friend WithEvents Description As ud_TextBox
    Private WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Table_Ref As ud_TextBox
    Private WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grd As ud_Grd
    Friend WithEvents nbLig As NumericUpDown
    Private WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Protege As ud_CheckBox
    Friend WithEvents Panel1 As Panel
End Class
