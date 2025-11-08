<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ordre_Mission
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grd_Interesses = New RHP.ud_Grd()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnl_internationale = New System.Windows.Forms.Panel()
        Me.Pays_Destination_txt = New RHP.ud_TextBox()
        Me.Lib_Pays_Destination_txt = New RHP.ud_TextBox()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.pnl_nationale = New System.Windows.Forms.Panel()
        Me.modifyDistance_btn = New RHP.ud_button()
        Me.Ville_Depart_txt = New RHP.ud_TextBox()
        Me.Ville_Destination_txt = New RHP.ud_TextBox()
        Me.Lib_Ville_Destination_txt = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Ville_Depart_txt = New RHP.ud_TextBox()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.Distance_txt = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rd_internationale = New RHP.ud_RadioBox()
        Me.rd_nationale = New RHP.ud_RadioBox()
        Me.rd_local = New RHP.ud_RadioBox()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Dat_Au_txt = New RHP.ud_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Dat_Du_txt = New RHP.ud_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Objet_Mission_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Typ_Deplacement_cbo = New RHP.ud_ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nom_Donneur_txt = New RHP.ud_TextBox()
        Me.Donneur_Ordre_txt = New RHP.ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.Dat_OM_txt = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Num_OM_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Matricule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Poste = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Poste = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Grade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Grade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Entite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Entite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Interesses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnl_internationale.SuspendLayout()
        Me.pnl_nationale.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grd_Interesses)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1062, 875)
        Me.Panel1.TabIndex = 1
        '
        'Grd_Interesses
        '
        Me.Grd_Interesses.AfficherLesEntetesLignes = True
        Me.Grd_Interesses.AlternerLesLignes = False
        Me.Grd_Interesses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Interesses.BackgroundColor = System.Drawing.Color.White
        Me.Grd_Interesses.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Interesses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Interesses.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Interesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Interesses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Matricule, Me.Nom, Me.Cod_Poste, Me.Lib_Poste, Me.Cod_Grade, Me.Lib_Grade, Me.Cod_Entite, Me.Lib_Entite})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Interesses.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Interesses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Interesses.EnableHeadersVisualStyles = False
        Me.Grd_Interesses.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Interesses.Location = New System.Drawing.Point(0, 545)
        Me.Grd_Interesses.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Interesses.Name = "Grd_Interesses"
        Me.Grd_Interesses.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Interesses.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Interesses.RowHeadersWidth = 51
        Me.Grd_Interesses.Size = New System.Drawing.Size(1062, 330)
        Me.Grd_Interesses.TabIndex = 100
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnl_internationale)
        Me.GroupBox1.Controls.Add(Me.pnl_nationale)
        Me.GroupBox1.Controls.Add(Me.rd_internationale)
        Me.GroupBox1.Controls.Add(Me.rd_nationale)
        Me.GroupBox1.Controls.Add(Me.rd_local)
        Me.GroupBox1.Controls.Add(Me.Commentaire_txt)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Dat_Au_txt)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Dat_Du_txt)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Objet_Mission_txt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Typ_Deplacement_cbo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Nom_Donneur_txt)
        Me.GroupBox1.Controls.Add(Me.Donneur_Ordre_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel3)
        Me.GroupBox1.Controls.Add(Me.pb_Valide)
        Me.GroupBox1.Controls.Add(Me.Dat_OM_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.Num_OM_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1062, 545)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ordre de Mission"
        '
        'pnl_internationale
        '
        Me.pnl_internationale.Controls.Add(Me.Pays_Destination_txt)
        Me.pnl_internationale.Controls.Add(Me.Lib_Pays_Destination_txt)
        Me.pnl_internationale.Controls.Add(Me.LinkLabel6)
        Me.pnl_internationale.Location = New System.Drawing.Point(478, 152)
        Me.pnl_internationale.Name = "pnl_internationale"
        Me.pnl_internationale.Size = New System.Drawing.Size(489, 41)
        Me.pnl_internationale.TabIndex = 97
        '
        'Pays_Destination_txt
        '
        Me.Pays_Destination_txt.AccessibleDescription = "A"
        Me.Pays_Destination_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Pays_Destination_txt.ContextMenuStrip = Nothing
        Me.Pays_Destination_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Pays_Destination_txt.Location = New System.Drawing.Point(74, 5)
        Me.Pays_Destination_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Pays_Destination_txt.MaxLength = 100
        Me.Pays_Destination_txt.Multiline = False
        Me.Pays_Destination_txt.Name = "Pays_Destination_txt"
        Me.Pays_Destination_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Pays_Destination_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Pays_Destination_txt.ReadOnly = True
        Me.Pays_Destination_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Pays_Destination_txt.SelectionStart = 0
        Me.Pays_Destination_txt.Size = New System.Drawing.Size(80, 26)
        Me.Pays_Destination_txt.TabIndex = 96
        Me.Pays_Destination_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Pays_Destination_txt.UseSystemPasswordChar = False
        '
        'Lib_Pays_Destination_txt
        '
        Me.Lib_Pays_Destination_txt.AccessibleDescription = "A"
        Me.Lib_Pays_Destination_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Pays_Destination_txt.ContextMenuStrip = Nothing
        Me.Lib_Pays_Destination_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Pays_Destination_txt.Location = New System.Drawing.Point(156, 5)
        Me.Lib_Pays_Destination_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Pays_Destination_txt.MaxLength = 32767
        Me.Lib_Pays_Destination_txt.Multiline = False
        Me.Lib_Pays_Destination_txt.Name = "Lib_Pays_Destination_txt"
        Me.Lib_Pays_Destination_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Pays_Destination_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Pays_Destination_txt.ReadOnly = True
        Me.Lib_Pays_Destination_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Pays_Destination_txt.SelectionStart = 0
        Me.Lib_Pays_Destination_txt.Size = New System.Drawing.Size(250, 26)
        Me.Lib_Pays_Destination_txt.TabIndex = 97
        Me.Lib_Pays_Destination_txt.TabStop = False
        Me.Lib_Pays_Destination_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Pays_Destination_txt.UseSystemPasswordChar = False
        '
        'LinkLabel6
        '
        Me.LinkLabel6.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.Location = New System.Drawing.Point(29, 9)
        Me.LinkLabel6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(40, 19)
        Me.LinkLabel6.TabIndex = 95
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Tag = "SC"
        Me.LinkLabel6.Text = "Pays"
        Me.LinkLabel6.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'pnl_nationale
        '
        Me.pnl_nationale.Controls.Add(Me.modifyDistance_btn)
        Me.pnl_nationale.Controls.Add(Me.Ville_Depart_txt)
        Me.pnl_nationale.Controls.Add(Me.Ville_Destination_txt)
        Me.pnl_nationale.Controls.Add(Me.Lib_Ville_Destination_txt)
        Me.pnl_nationale.Controls.Add(Me.LinkLabel4)
        Me.pnl_nationale.Controls.Add(Me.Lib_Ville_Depart_txt)
        Me.pnl_nationale.Controls.Add(Me.LinkLabel5)
        Me.pnl_nationale.Controls.Add(Me.Distance_txt)
        Me.pnl_nationale.Controls.Add(Me.Label5)
        Me.pnl_nationale.Location = New System.Drawing.Point(9, 150)
        Me.pnl_nationale.Name = "pnl_nationale"
        Me.pnl_nationale.Size = New System.Drawing.Size(447, 98)
        Me.pnl_nationale.TabIndex = 96
        '
        'modifyDistance_btn
        '
        Me.modifyDistance_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.modifyDistance_btn.bgColor = System.Drawing.Color.White
        Me.modifyDistance_btn.Border = RHP.ud_button.BorderStyle.None
        Me.modifyDistance_btn.BorderColor = System.Drawing.Color.Empty
        Me.modifyDistance_btn.BorderSize = 0
        Me.modifyDistance_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.modifyDistance_btn.Image = Global.RHP.My.Resources.Resources.btn_edit_doc
        Me.modifyDistance_btn.isDefault = False
        Me.modifyDistance_btn.Location = New System.Drawing.Point(185, 65)
        Me.modifyDistance_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.modifyDistance_btn.MinimumSize = New System.Drawing.Size(27, 30)
        Me.modifyDistance_btn.Name = "modifyDistance_btn"
        Me.modifyDistance_btn.Size = New System.Drawing.Size(211, 30)
        Me.modifyDistance_btn.TabIndex = 98
        Me.modifyDistance_btn.Text = "Modifier les distances"
        '
        'Ville_Depart_txt
        '
        Me.Ville_Depart_txt.AccessibleDescription = "A"
        Me.Ville_Depart_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ville_Depart_txt.ContextMenuStrip = Nothing
        Me.Ville_Depart_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ville_Depart_txt.Location = New System.Drawing.Point(103, 5)
        Me.Ville_Depart_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Ville_Depart_txt.MaxLength = 100
        Me.Ville_Depart_txt.Multiline = False
        Me.Ville_Depart_txt.Name = "Ville_Depart_txt"
        Me.Ville_Depart_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ville_Depart_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ville_Depart_txt.ReadOnly = True
        Me.Ville_Depart_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ville_Depart_txt.SelectionStart = 0
        Me.Ville_Depart_txt.Size = New System.Drawing.Size(80, 26)
        Me.Ville_Depart_txt.TabIndex = 13
        Me.Ville_Depart_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ville_Depart_txt.UseSystemPasswordChar = False
        '
        'Ville_Destination_txt
        '
        Me.Ville_Destination_txt.AccessibleDescription = "A"
        Me.Ville_Destination_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ville_Destination_txt.ContextMenuStrip = Nothing
        Me.Ville_Destination_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ville_Destination_txt.Location = New System.Drawing.Point(102, 35)
        Me.Ville_Destination_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Ville_Destination_txt.MaxLength = 100
        Me.Ville_Destination_txt.Multiline = False
        Me.Ville_Destination_txt.Name = "Ville_Destination_txt"
        Me.Ville_Destination_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ville_Destination_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ville_Destination_txt.ReadOnly = True
        Me.Ville_Destination_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ville_Destination_txt.SelectionStart = 0
        Me.Ville_Destination_txt.Size = New System.Drawing.Size(80, 26)
        Me.Ville_Destination_txt.TabIndex = 15
        Me.Ville_Destination_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ville_Destination_txt.UseSystemPasswordChar = False
        '
        'Lib_Ville_Destination_txt
        '
        Me.Lib_Ville_Destination_txt.AccessibleDescription = "A"
        Me.Lib_Ville_Destination_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Ville_Destination_txt.ContextMenuStrip = Nothing
        Me.Lib_Ville_Destination_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Ville_Destination_txt.Location = New System.Drawing.Point(185, 35)
        Me.Lib_Ville_Destination_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Ville_Destination_txt.MaxLength = 32767
        Me.Lib_Ville_Destination_txt.Multiline = False
        Me.Lib_Ville_Destination_txt.Name = "Lib_Ville_Destination_txt"
        Me.Lib_Ville_Destination_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Ville_Destination_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Ville_Destination_txt.ReadOnly = True
        Me.Lib_Ville_Destination_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Ville_Destination_txt.SelectionStart = 0
        Me.Lib_Ville_Destination_txt.Size = New System.Drawing.Size(250, 26)
        Me.Lib_Ville_Destination_txt.TabIndex = 94
        Me.Lib_Ville_Destination_txt.TabStop = False
        Me.Lib_Ville_Destination_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Ville_Destination_txt.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(43, 9)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(57, 19)
        Me.LinkLabel4.TabIndex = 91
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Départ"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Ville_Depart_txt
        '
        Me.Lib_Ville_Depart_txt.AccessibleDescription = "A"
        Me.Lib_Ville_Depart_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Ville_Depart_txt.ContextMenuStrip = Nothing
        Me.Lib_Ville_Depart_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Ville_Depart_txt.Location = New System.Drawing.Point(185, 5)
        Me.Lib_Ville_Depart_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Ville_Depart_txt.MaxLength = 32767
        Me.Lib_Ville_Depart_txt.Multiline = False
        Me.Lib_Ville_Depart_txt.Name = "Lib_Ville_Depart_txt"
        Me.Lib_Ville_Depart_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Ville_Depart_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Ville_Depart_txt.ReadOnly = True
        Me.Lib_Ville_Depart_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Ville_Depart_txt.SelectionStart = 0
        Me.Lib_Ville_Depart_txt.Size = New System.Drawing.Size(250, 26)
        Me.Lib_Ville_Depart_txt.TabIndex = 94
        Me.Lib_Ville_Depart_txt.TabStop = False
        Me.Lib_Ville_Depart_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Ville_Depart_txt.UseSystemPasswordChar = False
        '
        'LinkLabel5
        '
        Me.LinkLabel5.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel5.Location = New System.Drawing.Point(13, 38)
        Me.LinkLabel5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(86, 19)
        Me.LinkLabel5.TabIndex = 92
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Tag = "SC"
        Me.LinkLabel5.Text = "Destination"
        Me.LinkLabel5.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Distance_txt
        '
        Me.Distance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Distance_txt.ContextMenuStrip = Nothing
        Me.Distance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Distance_txt.Location = New System.Drawing.Point(102, 66)
        Me.Distance_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Distance_txt.MaxLength = 10
        Me.Distance_txt.Multiline = False
        Me.Distance_txt.Name = "Distance_txt"
        Me.Distance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Distance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Distance_txt.ReadOnly = True
        Me.Distance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Distance_txt.SelectionStart = 0
        Me.Distance_txt.Size = New System.Drawing.Size(80, 26)
        Me.Distance_txt.TabIndex = 17
        Me.Distance_txt.Text = "0,00"
        Me.Distance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Distance_txt.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(-4, 68)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 19)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Distance (km)"
        '
        'rd_internationale
        '
        Me.rd_internationale.AutoSize = True
        Me.rd_internationale.Checked = False
        Me.rd_internationale.Location = New System.Drawing.Point(564, 112)
        Me.rd_internationale.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.rd_internationale.MaximumSize = New System.Drawing.Size(0, 43)
        Me.rd_internationale.MinimumSize = New System.Drawing.Size(0, 43)
        Me.rd_internationale.Name = "rd_internationale"
        Me.rd_internationale.Size = New System.Drawing.Size(190, 43)
        Me.rd_internationale.TabIndex = 93
        Me.rd_internationale.Text = "Mission internationale"
        '
        'rd_nationale
        '
        Me.rd_nationale.AutoSize = True
        Me.rd_nationale.Checked = True
        Me.rd_nationale.Location = New System.Drawing.Point(287, 112)
        Me.rd_nationale.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.rd_nationale.MaximumSize = New System.Drawing.Size(0, 36)
        Me.rd_nationale.MinimumSize = New System.Drawing.Size(0, 36)
        Me.rd_nationale.Name = "rd_nationale"
        Me.rd_nationale.Size = New System.Drawing.Size(160, 36)
        Me.rd_nationale.TabIndex = 93
        Me.rd_nationale.Text = "Mission nationale"
        '
        'rd_local
        '
        Me.rd_local.AutoSize = True
        Me.rd_local.Checked = False
        Me.rd_local.Location = New System.Drawing.Point(21, 112)
        Me.rd_local.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rd_local.MaximumSize = New System.Drawing.Size(0, 30)
        Me.rd_local.MinimumSize = New System.Drawing.Size(0, 30)
        Me.rd_local.Name = "rd_local"
        Me.rd_local.Size = New System.Drawing.Size(142, 30)
        Me.rd_local.TabIndex = 93
        Me.rd_local.Text = "Mission locale"
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.AccessibleDescription = "A"
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.ContextMenuStrip = Nothing
        Me.Commentaire_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Commentaire_txt.Location = New System.Drawing.Point(114, 418)
        Me.Commentaire_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Commentaire_txt.MaxLength = 500
        Me.Commentaire_txt.Multiline = True
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(588, 79)
        Me.Commentaire_txt.TabIndex = 24
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(7, 418)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 19)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Commentaire"
        '
        'Dat_Au_txt
        '
        Me.Dat_Au_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Au_txt.ContextMenuStrip = Nothing
        Me.Dat_Au_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Au_txt.Location = New System.Drawing.Point(307, 382)
        Me.Dat_Au_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Dat_Au_txt.MaxLength = 10
        Me.Dat_Au_txt.Multiline = False
        Me.Dat_Au_txt.Name = "Dat_Au_txt"
        Me.Dat_Au_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Au_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Au_txt.ReadOnly = True
        Me.Dat_Au_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Au_txt.SelectionStart = 0
        Me.Dat_Au_txt.Size = New System.Drawing.Size(125, 26)
        Me.Dat_Au_txt.TabIndex = 22
        Me.Dat_Au_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Au_txt.UseSystemPasswordChar = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(276, 385)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 17)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Au"
        '
        'Dat_Du_txt
        '
        Me.Dat_Du_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Du_txt.ContextMenuStrip = Nothing
        Me.Dat_Du_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Du_txt.Location = New System.Drawing.Point(114, 382)
        Me.Dat_Du_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Dat_Du_txt.MaxLength = 10
        Me.Dat_Du_txt.Multiline = False
        Me.Dat_Du_txt.Name = "Dat_Du_txt"
        Me.Dat_Du_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Du_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Du_txt.ReadOnly = True
        Me.Dat_Du_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Du_txt.SelectionStart = 0
        Me.Dat_Du_txt.Size = New System.Drawing.Size(125, 26)
        Me.Dat_Du_txt.TabIndex = 20
        Me.Dat_Du_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Du_txt.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(83, 385)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 17)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Du"
        '
        'Objet_Mission_txt
        '
        Me.Objet_Mission_txt.AccessibleDescription = "A"
        Me.Objet_Mission_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Objet_Mission_txt.ContextMenuStrip = Nothing
        Me.Objet_Mission_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Objet_Mission_txt.Location = New System.Drawing.Point(111, 301)
        Me.Objet_Mission_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Objet_Mission_txt.MaxLength = 500
        Me.Objet_Mission_txt.Multiline = True
        Me.Objet_Mission_txt.Name = "Objet_Mission_txt"
        Me.Objet_Mission_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Objet_Mission_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Objet_Mission_txt.ReadOnly = False
        Me.Objet_Mission_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Objet_Mission_txt.SelectionStart = 0
        Me.Objet_Mission_txt.Size = New System.Drawing.Size(588, 75)
        Me.Objet_Mission_txt.TabIndex = 11
        Me.Objet_Mission_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Objet_Mission_txt.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(5, 301)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 19)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Objet mission"
        '
        'Typ_Deplacement_cbo
        '
        Me.Typ_Deplacement_cbo.DataSource = Nothing
        Me.Typ_Deplacement_cbo.DisplayMember = ""
        Me.Typ_Deplacement_cbo.DroppedDown = False
        Me.Typ_Deplacement_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Deplacement_cbo.Location = New System.Drawing.Point(111, 260)
        Me.Typ_Deplacement_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Deplacement_cbo.Name = "Typ_Deplacement_cbo"
        Me.Typ_Deplacement_cbo.SelectedIndex = -1
        Me.Typ_Deplacement_cbo.SelectedItem = Nothing
        Me.Typ_Deplacement_cbo.SelectedValue = Nothing
        Me.Typ_Deplacement_cbo.Size = New System.Drawing.Size(345, 27)
        Me.Typ_Deplacement_cbo.TabIndex = 9
        Me.Typ_Deplacement_cbo.ValueMember = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(8, 264)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 19)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Type déplac."
        '
        'Nom_Donneur_txt
        '
        Me.Nom_Donneur_txt.AccessibleDescription = "A"
        Me.Nom_Donneur_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Donneur_txt.ContextMenuStrip = Nothing
        Me.Nom_Donneur_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Donneur_txt.Location = New System.Drawing.Point(272, 66)
        Me.Nom_Donneur_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Nom_Donneur_txt.MaxLength = 32767
        Me.Nom_Donneur_txt.Multiline = False
        Me.Nom_Donneur_txt.Name = "Nom_Donneur_txt"
        Me.Nom_Donneur_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Donneur_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Donneur_txt.ReadOnly = True
        Me.Nom_Donneur_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Donneur_txt.SelectionStart = 0
        Me.Nom_Donneur_txt.Size = New System.Drawing.Size(452, 26)
        Me.Nom_Donneur_txt.TabIndex = 7
        Me.Nom_Donneur_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Donneur_txt.UseSystemPasswordChar = False
        '
        'Donneur_Ordre_txt
        '
        Me.Donneur_Ordre_txt.AccessibleDescription = "A"
        Me.Donneur_Ordre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Donneur_Ordre_txt.ContextMenuStrip = Nothing
        Me.Donneur_Ordre_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Donneur_Ordre_txt.Location = New System.Drawing.Point(138, 66)
        Me.Donneur_Ordre_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Donneur_Ordre_txt.MaxLength = 32767
        Me.Donneur_Ordre_txt.Multiline = False
        Me.Donneur_Ordre_txt.Name = "Donneur_Ordre_txt"
        Me.Donneur_Ordre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Donneur_Ordre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Donneur_Ordre_txt.ReadOnly = True
        Me.Donneur_Ordre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Donneur_Ordre_txt.SelectionStart = 0
        Me.Donneur_Ordre_txt.Size = New System.Drawing.Size(130, 26)
        Me.Donneur_Ordre_txt.TabIndex = 6
        Me.Donneur_Ordre_txt.TabStop = False
        Me.Donneur_Ordre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Donneur_Ordre_txt.UseSystemPasswordChar = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(19, 69)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(108, 19)
        Me.LinkLabel3.TabIndex = 5
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SC"
        Me.LinkLabel3.Text = "Donneur ordre"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(938, 25)
        Me.pb_Valide.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(75, 75)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_Valide.TabIndex = 90
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'Dat_OM_txt
        '
        Me.Dat_OM_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_OM_txt.ContextMenuStrip = Nothing
        Me.Dat_OM_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_OM_txt.Location = New System.Drawing.Point(400, 29)
        Me.Dat_OM_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Dat_OM_txt.MaxLength = 32767
        Me.Dat_OM_txt.Multiline = False
        Me.Dat_OM_txt.Name = "Dat_OM_txt"
        Me.Dat_OM_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_OM_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_OM_txt.ReadOnly = True
        Me.Dat_OM_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_OM_txt.SelectionStart = 0
        Me.Dat_OM_txt.Size = New System.Drawing.Size(125, 26)
        Me.Dat_OM_txt.TabIndex = 4
        Me.Dat_OM_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_OM_txt.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(350, 31)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(43, 19)
        Me.LinkLabel2.TabIndex = 3
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = "SC"
        Me.LinkLabel2.Text = "Date"
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Num_OM_txt
        '
        Me.Num_OM_txt.AccessibleDescription = "A"
        Me.Num_OM_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_OM_txt.ContextMenuStrip = Nothing
        Me.Num_OM_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_OM_txt.Location = New System.Drawing.Point(138, 29)
        Me.Num_OM_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Num_OM_txt.MaxLength = 32767
        Me.Num_OM_txt.Multiline = False
        Me.Num_OM_txt.Name = "Num_OM_txt"
        Me.Num_OM_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_OM_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_OM_txt.ReadOnly = True
        Me.Num_OM_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_OM_txt.SelectionStart = 0
        Me.Num_OM_txt.Size = New System.Drawing.Size(175, 26)
        Me.Num_OM_txt.TabIndex = 2
        Me.Num_OM_txt.TabStop = False
        Me.Num_OM_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_OM_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(35, 31)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(78, 19)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "SC"
        Me.LinkLabel1.Text = "N° d'ordre"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Matricule
        '
        Me.Matricule.HeaderText = "Matricule"
        Me.Matricule.MinimumWidth = 6
        Me.Matricule.Name = "Matricule"
        Me.Matricule.ReadOnly = True
        Me.Matricule.Width = 112
        '
        'Nom
        '
        Me.Nom.HeaderText = "Nom complet"
        Me.Nom.MinimumWidth = 200
        Me.Nom.Name = "Nom"
        Me.Nom.ReadOnly = True
        Me.Nom.Width = 200
        '
        'Cod_Poste
        '
        Me.Cod_Poste.HeaderText = "Cod_Poste"
        Me.Cod_Poste.MinimumWidth = 6
        Me.Cod_Poste.Name = "Cod_Poste"
        Me.Cod_Poste.ReadOnly = True
        Me.Cod_Poste.Visible = False
        Me.Cod_Poste.Width = 120
        '
        'Lib_Poste
        '
        Me.Lib_Poste.HeaderText = "Poste"
        Me.Lib_Poste.MinimumWidth = 250
        Me.Lib_Poste.Name = "Lib_Poste"
        Me.Lib_Poste.ReadOnly = True
        Me.Lib_Poste.Width = 250
        '
        'Cod_Grade
        '
        Me.Cod_Grade.HeaderText = "Cod_Grade"
        Me.Cod_Grade.MinimumWidth = 6
        Me.Cod_Grade.Name = "Cod_Grade"
        Me.Cod_Grade.ReadOnly = True
        Me.Cod_Grade.Visible = False
        Me.Cod_Grade.Width = 129
        '
        'Lib_Grade
        '
        Me.Lib_Grade.HeaderText = "Grade"
        Me.Lib_Grade.MinimumWidth = 200
        Me.Lib_Grade.Name = "Lib_Grade"
        Me.Lib_Grade.ReadOnly = True
        Me.Lib_Grade.Width = 200
        '
        'Cod_Entite
        '
        Me.Cod_Entite.HeaderText = "Cod_Entite"
        Me.Cod_Entite.MinimumWidth = 6
        Me.Cod_Entite.Name = "Cod_Entite"
        Me.Cod_Entite.ReadOnly = True
        Me.Cod_Entite.Visible = False
        Me.Cod_Entite.Width = 123
        '
        'Lib_Entite
        '
        Me.Lib_Entite.HeaderText = "Entité"
        Me.Lib_Entite.MinimumWidth = 250
        Me.Lib_Entite.Name = "Lib_Entite"
        Me.Lib_Entite.ReadOnly = True
        Me.Lib_Entite.Width = 250
        '
        'Ordre_Mission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1062, 875)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "Ordre_Mission"
        Me.Tag = "ECR"
        Me.Text = "Ordre de Mission"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Interesses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnl_internationale.ResumeLayout(False)
        Me.pnl_internationale.PerformLayout()
        Me.pnl_nationale.ResumeLayout(False)
        Me.pnl_nationale.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Grd_Interesses As ud_Grd

    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Num_OM_txt As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Dat_OM_txt As ud_TextBox
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Donneur_Ordre_txt As ud_TextBox
    Friend WithEvents Nom_Donneur_txt As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Objet_Mission_txt As ud_TextBox
    Friend WithEvents Ville_Depart_txt As ud_TextBox
    Friend WithEvents Ville_Destination_txt As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Distance_txt As ud_TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Dat_Du_txt As ud_TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Dat_Au_txt As ud_TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Commentaire_txt As ud_TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents pnl_internationale As Panel
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents pnl_nationale As Panel
    Friend WithEvents Lib_Ville_Destination_txt As ud_TextBox
    Friend WithEvents Lib_Ville_Depart_txt As ud_TextBox
    Friend WithEvents rd_internationale As ud_RadioBox
    Friend WithEvents rd_nationale As ud_RadioBox
    Friend WithEvents rd_local As ud_RadioBox
    Friend WithEvents Typ_Deplacement_cbo As ud_ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Pays_Destination_txt As ud_TextBox
    Friend WithEvents Lib_Pays_Destination_txt As ud_TextBox
    Friend WithEvents modifyDistance_btn As ud_button
    Friend WithEvents Matricule As DataGridViewTextBoxColumn
    Friend WithEvents Nom As DataGridViewTextBoxColumn
    Friend WithEvents Cod_Poste As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Poste As DataGridViewTextBoxColumn
    Friend WithEvents Cod_Grade As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Grade As DataGridViewTextBoxColumn
    Friend WithEvents Cod_Entite As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Entite As DataGridViewTextBoxColumn
End Class