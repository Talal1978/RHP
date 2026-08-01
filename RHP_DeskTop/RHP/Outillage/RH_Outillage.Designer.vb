<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Outillage
    Inherits Ecran

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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grd_Outillage = New RHP.ud_Grd()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Qte_Dispo_txt = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Qte_Initial_txt = New RHP.ud_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Num_Serie_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Typ_Outillage_cmb = New RHP.ud_ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lib_Outillage_txt = New RHP.ud_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cod_Outillage_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Outillage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grd_Outillage)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1139, 608)
        Me.Panel1.TabIndex = 0
        '
        'Grd_Outillage
        '
        Me.Grd_Outillage.AfficherLesEntetesLignes = True
        Me.Grd_Outillage.AlternerLesLignes = False
        Me.Grd_Outillage.BackgroundColor = System.Drawing.Color.White
        Me.Grd_Outillage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Outillage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Outillage.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Outillage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Outillage.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Outillage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Outillage.EnableHeadersVisualStyles = False
        Me.Grd_Outillage.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Outillage.Location = New System.Drawing.Point(0, 175)
        Me.Grd_Outillage.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Outillage.Name = "Grd_Outillage"
        Me.Grd_Outillage.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Outillage.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Outillage.RowHeadersWidth = 51
        Me.Grd_Outillage.Size = New System.Drawing.Size(1139, 433)
        Me.Grd_Outillage.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Qte_Dispo_txt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Qte_Initial_txt)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Num_Serie_txt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Typ_Outillage_cmb)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Lib_Outillage_txt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Cod_Outillage_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1139, 175)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Outillage / Matériel"
        '
        'Qte_Dispo_txt
        '
        Me.Qte_Dispo_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Qte_Dispo_txt.ContextMenuStrip = Nothing
        Me.Qte_Dispo_txt.Location = New System.Drawing.Point(420, 119)
        Me.Qte_Dispo_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Qte_Dispo_txt.MaxLength = 20
        Me.Qte_Dispo_txt.Multiline = False
        Me.Qte_Dispo_txt.Name = "Qte_Dispo_txt"
        Me.Qte_Dispo_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Qte_Dispo_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Qte_Dispo_txt.ReadOnly = True
        Me.Qte_Dispo_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Qte_Dispo_txt.SelectionStart = 0
        Me.Qte_Dispo_txt.Size = New System.Drawing.Size(100, 26)
        Me.Qte_Dispo_txt.TabIndex = 260
        Me.Qte_Dispo_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Qte_Dispo_txt.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(273, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 19)
        Me.Label5.TabIndex = 261
        Me.Label5.Text = "Quantité disponible"
        '
        'Qte_Initial_txt
        '
        Me.Qte_Initial_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Qte_Initial_txt.ContextMenuStrip = Nothing
        Me.Qte_Initial_txt.Location = New System.Drawing.Point(134, 119)
        Me.Qte_Initial_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Qte_Initial_txt.MaxLength = 20
        Me.Qte_Initial_txt.Multiline = False
        Me.Qte_Initial_txt.Name = "Qte_Initial_txt"
        Me.Qte_Initial_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Qte_Initial_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Qte_Initial_txt.ReadOnly = False
        Me.Qte_Initial_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Qte_Initial_txt.SelectionStart = 0
        Me.Qte_Initial_txt.Size = New System.Drawing.Size(100, 26)
        Me.Qte_Initial_txt.TabIndex = 258
        Me.Qte_Initial_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Qte_Initial_txt.UseSystemPasswordChar = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 19)
        Me.Label3.TabIndex = 259
        Me.Label3.Text = "Quantité initiale"
        '
        'Num_Serie_txt
        '
        Me.Num_Serie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Serie_txt.ContextMenuStrip = Nothing
        Me.Num_Serie_txt.Location = New System.Drawing.Point(134, 90)
        Me.Num_Serie_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Num_Serie_txt.MaxLength = 50
        Me.Num_Serie_txt.Multiline = False
        Me.Num_Serie_txt.Name = "Num_Serie_txt"
        Me.Num_Serie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Serie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Serie_txt.ReadOnly = False
        Me.Num_Serie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Serie_txt.SelectionStart = 0
        Me.Num_Serie_txt.Size = New System.Drawing.Size(309, 26)
        Me.Num_Serie_txt.TabIndex = 256
        Me.Num_Serie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Serie_txt.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 19)
        Me.Label2.TabIndex = 257
        Me.Label2.Text = "N° de série"
        '
        'Typ_Outillage_cmb
        '
        Me.Typ_Outillage_cmb.DataSource = Nothing
        Me.Typ_Outillage_cmb.DisplayMember = ""
        Me.Typ_Outillage_cmb.DroppedDown = False
        Me.Typ_Outillage_cmb.Location = New System.Drawing.Point(134, 61)
        Me.Typ_Outillage_cmb.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Outillage_cmb.Name = "Typ_Outillage_cmb"
        Me.Typ_Outillage_cmb.SelectedIndex = -1
        Me.Typ_Outillage_cmb.SelectedItem = Nothing
        Me.Typ_Outillage_cmb.SelectedValue = Nothing
        Me.Typ_Outillage_cmb.Size = New System.Drawing.Size(309, 29)
        Me.Typ_Outillage_cmb.TabIndex = 254
        Me.Typ_Outillage_cmb.ValueMember = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(90, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 19)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Type"
        '
        'Lib_Outillage_txt
        '
        Me.Lib_Outillage_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Outillage_txt.ContextMenuStrip = Nothing
        Me.Lib_Outillage_txt.Location = New System.Drawing.Point(410, 26)
        Me.Lib_Outillage_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Outillage_txt.MaxLength = 150
        Me.Lib_Outillage_txt.Multiline = False
        Me.Lib_Outillage_txt.Name = "Lib_Outillage_txt"
        Me.Lib_Outillage_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Outillage_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Outillage_txt.ReadOnly = False
        Me.Lib_Outillage_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Outillage_txt.SelectionStart = 0
        Me.Lib_Outillage_txt.Size = New System.Drawing.Size(465, 26)
        Me.Lib_Outillage_txt.TabIndex = 252
        Me.Lib_Outillage_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Outillage_txt.UseSystemPasswordChar = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(316, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 19)
        Me.Label4.TabIndex = 253
        Me.Label4.Text = "Désignation"
        '
        'Cod_Outillage_txt
        '
        Me.Cod_Outillage_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Outillage_txt.ContextMenuStrip = Nothing
        Me.Cod_Outillage_txt.Location = New System.Drawing.Point(134, 26)
        Me.Cod_Outillage_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cod_Outillage_txt.MaxLength = 20
        Me.Cod_Outillage_txt.Multiline = False
        Me.Cod_Outillage_txt.Name = "Cod_Outillage_txt"
        Me.Cod_Outillage_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Outillage_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Outillage_txt.ReadOnly = False
        Me.Cod_Outillage_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Outillage_txt.SelectionStart = 0
        Me.Cod_Outillage_txt.Size = New System.Drawing.Size(158, 26)
        Me.Cod_Outillage_txt.TabIndex = 251
        Me.Cod_Outillage_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Outillage_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(82, 31)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(48, 19)
        Me.LinkLabel3.TabIndex = 250
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Code"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'RH_Outillage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1139, 608)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Outillage"
        Me.Tag = "ECR"
        Me.Text = "Outillage / Matériel"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Outillage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cod_Outillage_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Lib_Outillage_txt As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Typ_Outillage_cmb As ud_ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Num_Serie_txt As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Qte_Initial_txt As ud_TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Qte_Dispo_txt As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Grd_Outillage As ud_Grd
End Class
