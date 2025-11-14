<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Param_Python
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

    'REMARQUE : la Requête suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Grd_Arguments = New RHP.ud_Grd()
        Me.Argument = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Argument = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Param = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Fonction_Critere = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Table_Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Champs_01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Champs_02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Condition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Default_Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Text_Code_txt = New RHP.ud_TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Actif_chk = New RHP.ud_CheckBox()
        Me.Cod_Python_Text = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Typ_Python_Text = New RHP.ud_TextBox()
        Me.Nom_Python_Text = New RHP.ud_TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ud_withConn = New RHP.ud_CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.Grd_Arguments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonX1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX1.Location = New System.Drawing.Point(16, 38)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(67, 23)
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.Text = "OK"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Location = New System.Drawing.Point(36, 3)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(28, 8)
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "Annuler"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Grd_Arguments)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1091, 608)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Arguments"
        '
        'Grd_Arguments
        '
        Me.Grd_Arguments.AfficherLesEntetesLignes = True
        Me.Grd_Arguments.AllowUserToOrderColumns = True
        Me.Grd_Arguments.AlternerLesLignes = False
        Me.Grd_Arguments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Arguments.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Arguments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd_Arguments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Arguments.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Arguments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Arguments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Argument, Me.Lib_Argument, Me.Typ_Param, Me.Fonction_Critere, Me.Table_Critere, Me.Champs_01, Me.Champs_02, Me.Condition, Me.Default_Value, Me.Rang})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Arguments.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Arguments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Arguments.EnableHeadersVisualStyles = False
        Me.Grd_Arguments.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Arguments.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Grd_Arguments.Location = New System.Drawing.Point(3, 3)
        Me.Grd_Arguments.Name = "Grd_Arguments"
        Me.Grd_Arguments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Grd_Arguments.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Arguments.RowHeadersWidth = 51
        Me.Grd_Arguments.Size = New System.Drawing.Size(1085, 602)
        Me.Grd_Arguments.TabIndex = 7
        Me.Grd_Arguments.Tag = "NC"
        '
        'Argument
        '
        Me.Argument.FillWeight = 30.0!
        Me.Argument.HeaderText = "Arguments"
        Me.Argument.MinimumWidth = 100
        Me.Argument.Name = "Argument"
        Me.Argument.Width = 119
        '
        'Lib_Argument
        '
        Me.Lib_Argument.FillWeight = 50.0!
        Me.Lib_Argument.HeaderText = "Libellé"
        Me.Lib_Argument.MinimumWidth = 250
        Me.Lib_Argument.Name = "Lib_Argument"
        Me.Lib_Argument.Width = 250
        '
        'Typ_Param
        '
        Me.Typ_Param.FillWeight = 30.0!
        Me.Typ_Param.HeaderText = "Type"
        Me.Typ_Param.MinimumWidth = 100
        Me.Typ_Param.Name = "Typ_Param"
        Me.Typ_Param.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Typ_Param.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Fonction_Critere
        '
        Me.Fonction_Critere.FillWeight = 30.0!
        Me.Fonction_Critere.HeaderText = "Fonction"
        Me.Fonction_Critere.MinimumWidth = 100
        Me.Fonction_Critere.Name = "Fonction_Critere"
        Me.Fonction_Critere.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fonction_Critere.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Fonction_Critere.Width = 107
        '
        'Table_Critere
        '
        Me.Table_Critere.HeaderText = "Table"
        Me.Table_Critere.MinimumWidth = 100
        Me.Table_Critere.Name = "Table_Critere"
        '
        'Champs_01
        '
        Me.Champs_01.HeaderText = "Champs 01"
        Me.Champs_01.MinimumWidth = 100
        Me.Champs_01.Name = "Champs_01"
        Me.Champs_01.Width = 116
        '
        'Champs_02
        '
        Me.Champs_02.HeaderText = "Champs 02"
        Me.Champs_02.MinimumWidth = 100
        Me.Champs_02.Name = "Champs_02"
        Me.Champs_02.Width = 116
        '
        'Condition
        '
        Me.Condition.HeaderText = "Condition"
        Me.Condition.MinimumWidth = 100
        Me.Condition.Name = "Condition"
        Me.Condition.Width = 115
        '
        'Default_Value
        '
        Me.Default_Value.HeaderText = "Valeur par défaut"
        Me.Default_Value.MinimumWidth = 6
        Me.Default_Value.Name = "Default_Value"
        Me.Default_Value.Width = 156
        '
        'Rang
        '
        Me.Rang.HeaderText = "Rang"
        Me.Rang.MinimumWidth = 6
        Me.Rang.Name = "Rang"
        Me.Rang.Width = 84
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Text_Code_txt)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1091, 608)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Texte de la Requête"
        '
        'Text_Code_txt
        '
        Me.Text_Code_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Text_Code_txt.ContextMenuStrip = Nothing
        Me.Text_Code_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Text_Code_txt.Location = New System.Drawing.Point(3, 93)
        Me.Text_Code_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_Code_txt.MaxLength = 32767
        Me.Text_Code_txt.Multiline = True
        Me.Text_Code_txt.Name = "Text_Code_txt"
        Me.Text_Code_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Text_Code_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Text_Code_txt.ReadOnly = False
        Me.Text_Code_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Text_Code_txt.SelectionStart = 0
        Me.Text_Code_txt.Size = New System.Drawing.Size(1085, 512)
        Me.Text_Code_txt.TabIndex = 97
        Me.Text_Code_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Text_Code_txt.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.ud_withConn)
        Me.Panel1.Controls.Add(Me.Actif_chk)
        Me.Panel1.Controls.Add(Me.Cod_Python_Text)
        Me.Panel1.Controls.Add(Me.LinkLabel4)
        Me.Panel1.Controls.Add(Me.Typ_Python_Text)
        Me.Panel1.Controls.Add(Me.Nom_Python_Text)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1085, 90)
        Me.Panel1.TabIndex = 98
        '
        'Actif_chk
        '
        Me.Actif_chk.AutoSize = True
        Me.Actif_chk.Checked = True
        Me.Actif_chk.Location = New System.Drawing.Point(100, 52)
        Me.Actif_chk.Margin = New System.Windows.Forms.Padding(4)
        Me.Actif_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Actif_chk.MinimumSize = New System.Drawing.Size(133, 25)
        Me.Actif_chk.Name = "Actif_chk"
        Me.Actif_chk.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Actif_chk.Size = New System.Drawing.Size(133, 25)
        Me.Actif_chk.TabIndex = 223
        Me.Actif_chk.Text = "Actif"
        '
        'Cod_Python_Text
        '
        Me.Cod_Python_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Python_Text.ContextMenuStrip = Nothing
        Me.Cod_Python_Text.Location = New System.Drawing.Point(100, 19)
        Me.Cod_Python_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cod_Python_Text.MaxLength = 32767
        Me.Cod_Python_Text.Multiline = False
        Me.Cod_Python_Text.Name = "Cod_Python_Text"
        Me.Cod_Python_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Python_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Python_Text.ReadOnly = True
        Me.Cod_Python_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Python_Text.SelectionStart = 0
        Me.Cod_Python_Text.Size = New System.Drawing.Size(281, 26)
        Me.Cod_Python_Text.TabIndex = 96
        Me.Cod_Python_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Python_Text.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(25, 23)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(71, 16)
        Me.LinkLabel4.TabIndex = 0
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = ""
        Me.LinkLabel4.Text = "Traitement"
        '
        'Typ_Python_Text
        '
        Me.Typ_Python_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Typ_Python_Text.ContextMenuStrip = Nothing
        Me.Typ_Python_Text.Location = New System.Drawing.Point(788, 19)
        Me.Typ_Python_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Typ_Python_Text.MaxLength = 32767
        Me.Typ_Python_Text.Multiline = False
        Me.Typ_Python_Text.Name = "Typ_Python_Text"
        Me.Typ_Python_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Typ_Python_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Typ_Python_Text.ReadOnly = True
        Me.Typ_Python_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Typ_Python_Text.SelectionStart = 0
        Me.Typ_Python_Text.Size = New System.Drawing.Size(32, 26)
        Me.Typ_Python_Text.TabIndex = 219
        Me.Typ_Python_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Typ_Python_Text.UseSystemPasswordChar = False
        '
        'Nom_Python_Text
        '
        Me.Nom_Python_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Python_Text.ContextMenuStrip = Nothing
        Me.Nom_Python_Text.Location = New System.Drawing.Point(387, 19)
        Me.Nom_Python_Text.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Nom_Python_Text.MaxLength = 100
        Me.Nom_Python_Text.Multiline = False
        Me.Nom_Python_Text.Name = "Nom_Python_Text"
        Me.Nom_Python_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Python_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Python_Text.ReadOnly = False
        Me.Nom_Python_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Python_Text.SelectionStart = 0
        Me.Nom_Python_Text.Size = New System.Drawing.Size(395, 26)
        Me.Nom_Python_Text.TabIndex = 1
        Me.Nom_Python_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Python_Text.UseSystemPasswordChar = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1099, 637)
        Me.TabControl1.TabIndex = 216
        '
        'ud_withConn
        '
        Me.ud_withConn.AutoSize = True
        Me.ud_withConn.Checked = False
        Me.ud_withConn.Location = New System.Drawing.Point(500, 53)
        Me.ud_withConn.Margin = New System.Windows.Forms.Padding(4)
        Me.ud_withConn.MaximumSize = New System.Drawing.Size(0, 25)
        Me.ud_withConn.MinimumSize = New System.Drawing.Size(133, 25)
        Me.ud_withConn.Name = "ud_withConn"
        Me.ud_withConn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ud_withConn.Size = New System.Drawing.Size(320, 25)
        Me.ud_withConn.TabIndex = 223
        Me.ud_withConn.Text = "Inclure automatiquement la connection au serveur"
        '
        'Param_Python
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1099, 637)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Param_Python"
        Me.Tag = "ECR"
        Me.Text = "Compilateur python"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Grd_Arguments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Grd_Arguments As ud_Grd
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Text_Code_txt As ud_TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Actif_chk As ud_CheckBox
    Friend WithEvents Cod_Python_Text As ud_TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Typ_Python_Text As ud_TextBox
    Friend WithEvents Nom_Python_Text As ud_TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Argument As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Argument As DataGridViewTextBoxColumn
    Friend WithEvents Typ_Param As DataGridViewComboBoxColumn
    Friend WithEvents Fonction_Critere As DataGridViewComboBoxColumn
    Friend WithEvents Table_Critere As DataGridViewTextBoxColumn
    Friend WithEvents Champs_01 As DataGridViewTextBoxColumn
    Friend WithEvents Champs_02 As DataGridViewTextBoxColumn
    Friend WithEvents Condition As DataGridViewTextBoxColumn
    Friend WithEvents Default_Value As DataGridViewTextBoxColumn
    Friend WithEvents Rang As DataGridViewTextBoxColumn
    Friend WithEvents ud_withConn As ud_CheckBox
End Class
