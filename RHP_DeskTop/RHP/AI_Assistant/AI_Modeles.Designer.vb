<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AI_Modeles
    Inherits Ecran

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_Fiche = New System.Windows.Forms.TabPage()
        Me.Panel_Fiche = New System.Windows.Forms.Panel()
        Me.Nouveau_pb = New System.Windows.Forms.PictureBox()
        Me.SupprimerModele_pb = New System.Windows.Forms.PictureBox()
        Me.Defaut_chk = New RHP.ud_CheckBox()
        Me.AddModele_pb = New System.Windows.Forms.PictureBox()
        Me.TesterConn_pb = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nb_Msg_Memory = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Modele_cbo = New RHP.ud_ComboBox()
        Me.Global_chk = New RHP.ud_CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AiUrl_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ApiKey_txt = New RHP.ud_TextBox()
        Me.lblDen = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Provider_cbo = New RHP.ud_ComboBox()
        Me.Grd_Modeles = New RHP.ud_Grd()
        Me.Grd_Modeles_Defaut = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Grd_Modeles_Provider = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grd_Modeles_Modele = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grd_Modeles_Url = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grd_Modeles_Portee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lbl_Modeles = New System.Windows.Forms.Label()
        Me.TabPage_Instruction = New System.Windows.Forms.TabPage()
        Me.Instructions_txt = New RHP.ud_TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_Fiche.SuspendLayout()
        Me.Panel_Fiche.SuspendLayout()
        CType(Me.Nouveau_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SupprimerModele_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddModele_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TesterConn_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nb_Msg_Memory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd_Modeles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_Instruction.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_Fiche)
        Me.TabControl1.Controls.Add(Me.TabPage_Instruction)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1191, 554)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage_Fiche
        '
        Me.TabPage_Fiche.Controls.Add(Me.Panel_Fiche)
        Me.TabPage_Fiche.Controls.Add(Me.Grd_Modeles)
        Me.TabPage_Fiche.Controls.Add(Me.Lbl_Modeles)
        Me.TabPage_Fiche.Location = New System.Drawing.Point(4, 25)
        Me.TabPage_Fiche.Name = "TabPage_Fiche"
        Me.TabPage_Fiche.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Fiche.Size = New System.Drawing.Size(1183, 525)
        Me.TabPage_Fiche.TabIndex = 0
        Me.TabPage_Fiche.Text = "Fiche AI Agent "
        Me.TabPage_Fiche.UseVisualStyleBackColor = True
        '
        'Panel_Fiche
        '
        Me.Panel_Fiche.Controls.Add(Me.Nouveau_pb)
        Me.Panel_Fiche.Controls.Add(Me.SupprimerModele_pb)
        Me.Panel_Fiche.Controls.Add(Me.Defaut_chk)
        Me.Panel_Fiche.Controls.Add(Me.AddModele_pb)
        Me.Panel_Fiche.Controls.Add(Me.TesterConn_pb)
        Me.Panel_Fiche.Controls.Add(Me.Label4)
        Me.Panel_Fiche.Controls.Add(Me.nb_Msg_Memory)
        Me.Panel_Fiche.Controls.Add(Me.Label3)
        Me.Panel_Fiche.Controls.Add(Me.Modele_cbo)
        Me.Panel_Fiche.Controls.Add(Me.Global_chk)
        Me.Panel_Fiche.Controls.Add(Me.Label2)
        Me.Panel_Fiche.Controls.Add(Me.AiUrl_txt)
        Me.Panel_Fiche.Controls.Add(Me.Label1)
        Me.Panel_Fiche.Controls.Add(Me.ApiKey_txt)
        Me.Panel_Fiche.Controls.Add(Me.lblDen)
        Me.Panel_Fiche.Controls.Add(Me.Label19)
        Me.Panel_Fiche.Controls.Add(Me.Provider_cbo)
        Me.Panel_Fiche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Fiche.Location = New System.Drawing.Point(3, 158)
        Me.Panel_Fiche.Name = "Panel_Fiche"
        Me.Panel_Fiche.Size = New System.Drawing.Size(1177, 364)
        Me.Panel_Fiche.TabIndex = 0
        '
        'Nouveau_pb
        '
        Me.Nouveau_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Nouveau_pb.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.Nouveau_pb.Location = New System.Drawing.Point(770, 60)
        Me.Nouveau_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.Nouveau_pb.Name = "Nouveau_pb"
        Me.Nouveau_pb.Size = New System.Drawing.Size(41, 32)
        Me.Nouveau_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Nouveau_pb.TabIndex = 208
        Me.Nouveau_pb.TabStop = False
        '
        'SupprimerModele_pb
        '
        Me.SupprimerModele_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SupprimerModele_pb.Image = Global.RHP.My.Resources.Resources.btn_delete
        Me.SupprimerModele_pb.Location = New System.Drawing.Point(770, 95)
        Me.SupprimerModele_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.SupprimerModele_pb.Name = "SupprimerModele_pb"
        Me.SupprimerModele_pb.Size = New System.Drawing.Size(41, 32)
        Me.SupprimerModele_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SupprimerModele_pb.TabIndex = 209
        Me.SupprimerModele_pb.TabStop = False
        '
        'Defaut_chk
        '
        Me.Defaut_chk.AutoSize = True
        Me.Defaut_chk.Location = New System.Drawing.Point(108, 265)
        Me.Defaut_chk.Margin = New System.Windows.Forms.Padding(4)
        Me.Defaut_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Defaut_chk.MinimumSize = New System.Drawing.Size(133, 25)
        Me.Defaut_chk.Name = "Defaut_chk"
        Me.Defaut_chk.Size = New System.Drawing.Size(148, 25)
        Me.Defaut_chk.TabIndex = 207
        Me.Defaut_chk.Text = "Modèle par défaut"
        '
        'AddModele_pb
        '
        Me.AddModele_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AddModele_pb.Image = Global.RHP.My.Resources.Resources.btn_edit_doc
        Me.AddModele_pb.Location = New System.Drawing.Point(723, 60)
        Me.AddModele_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.AddModele_pb.Name = "AddModele_pb"
        Me.AddModele_pb.Size = New System.Drawing.Size(41, 32)
        Me.AddModele_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.AddModele_pb.TabIndex = 206
        Me.AddModele_pb.TabStop = False
        '
        'TesterConn_pb
        '
        Me.TesterConn_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TesterConn_pb.Image = Global.RHP.My.Resources.Resources.btn_testCon
        Me.TesterConn_pb.Location = New System.Drawing.Point(723, 95)
        Me.TesterConn_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.TesterConn_pb.Name = "TesterConn_pb"
        Me.TesterConn_pb.Size = New System.Drawing.Size(41, 32)
        Me.TesterConn_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.TesterConn_pb.TabIndex = 205
        Me.TesterConn_pb.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(204, 163)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 16)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "(Messages)"
        '
        'nb_Msg_Memory
        '
        Me.nb_Msg_Memory.Location = New System.Drawing.Point(109, 162)
        Me.nb_Msg_Memory.Name = "nb_Msg_Memory"
        Me.nb_Msg_Memory.Size = New System.Drawing.Size(91, 22)
        Me.nb_Msg_Memory.TabIndex = 203
        Me.nb_Msg_Memory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(35, 162)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 19)
        Me.Label3.TabIndex = 202
        Me.Label3.Text = "Mémoire"
        '
        'Modele_cbo
        '
        Me.Modele_cbo.DataSource = Nothing
        Me.Modele_cbo.DisplayMember = ""
        Me.Modele_cbo.DroppedDown = False
        Me.Modele_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Modele_cbo.Location = New System.Drawing.Point(108, 63)
        Me.Modele_cbo.Margin = New System.Windows.Forms.Padding(2)
        Me.Modele_cbo.Name = "Modele_cbo"
        Me.Modele_cbo.SelectedIndex = -1
        Me.Modele_cbo.SelectedItem = Nothing
        Me.Modele_cbo.SelectedValue = Nothing
        Me.Modele_cbo.Size = New System.Drawing.Size(613, 30)
        Me.Modele_cbo.TabIndex = 201
        Me.Modele_cbo.ValueMember = ""
        '
        'Global_chk
        '
        Me.Global_chk.AutoSize = True
        Me.Global_chk.Checked = True
        Me.Global_chk.Location = New System.Drawing.Point(108, 232)
        Me.Global_chk.Margin = New System.Windows.Forms.Padding(4)
        Me.Global_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Global_chk.MinimumSize = New System.Drawing.Size(133, 25)
        Me.Global_chk.Name = "Global_chk"
        Me.Global_chk.Size = New System.Drawing.Size(147, 25)
        Me.Global_chk.TabIndex = 200
        Me.Global_chk.Text = "Paramétrage global"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(42, 68)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 19)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Modèle"
        '
        'AiUrl_txt
        '
        Me.AiUrl_txt.AutoSize = True
        Me.AiUrl_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.AiUrl_txt.ContextMenuStrip = Nothing
        Me.AiUrl_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AiUrl_txt.Location = New System.Drawing.Point(108, 100)
        Me.AiUrl_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.AiUrl_txt.MaxLength = 300
        Me.AiUrl_txt.Multiline = False
        Me.AiUrl_txt.Name = "AiUrl_txt"
        Me.AiUrl_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.AiUrl_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.AiUrl_txt.ReadOnly = False
        Me.AiUrl_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.AiUrl_txt.SelectionStart = 0
        Me.AiUrl_txt.Size = New System.Drawing.Size(613, 26)
        Me.AiUrl_txt.TabIndex = 197
        Me.AiUrl_txt.Tag = "0"
        Me.AiUrl_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.AiUrl_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(78, 103)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 19)
        Me.Label1.TabIndex = 198
        Me.Label1.Text = "Url"
        '
        'ApiKey_txt
        '
        Me.ApiKey_txt.AutoSize = True
        Me.ApiKey_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.ApiKey_txt.ContextMenuStrip = Nothing
        Me.ApiKey_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApiKey_txt.Location = New System.Drawing.Point(108, 130)
        Me.ApiKey_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.ApiKey_txt.MaxLength = 300
        Me.ApiKey_txt.Multiline = False
        Me.ApiKey_txt.Name = "ApiKey_txt"
        Me.ApiKey_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.ApiKey_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ApiKey_txt.ReadOnly = False
        Me.ApiKey_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.ApiKey_txt.SelectionStart = 0
        Me.ApiKey_txt.Size = New System.Drawing.Size(613, 26)
        Me.ApiKey_txt.TabIndex = 195
        Me.ApiKey_txt.Tag = "0"
        Me.ApiKey_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ApiKey_txt.UseSystemPasswordChar = False
        '
        'lblDen
        '
        Me.lblDen.AutoSize = True
        Me.lblDen.BackColor = System.Drawing.Color.Transparent
        Me.lblDen.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.lblDen.Location = New System.Drawing.Point(47, 133)
        Me.lblDen.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDen.Name = "lblDen"
        Me.lblDen.Size = New System.Drawing.Size(56, 19)
        Me.lblDen.TabIndex = 196
        Me.lblDen.Text = "Clé API"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(46, 34)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 19)
        Me.Label19.TabIndex = 194
        Me.Label19.Text = "Service"
        '
        'Provider_cbo
        '
        Me.Provider_cbo.DataSource = Nothing
        Me.Provider_cbo.DisplayMember = ""
        Me.Provider_cbo.DroppedDown = False
        Me.Provider_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Provider_cbo.Location = New System.Drawing.Point(108, 29)
        Me.Provider_cbo.Margin = New System.Windows.Forms.Padding(2)
        Me.Provider_cbo.Name = "Provider_cbo"
        Me.Provider_cbo.SelectedIndex = -1
        Me.Provider_cbo.SelectedItem = Nothing
        Me.Provider_cbo.SelectedValue = Nothing
        Me.Provider_cbo.Size = New System.Drawing.Size(613, 30)
        Me.Provider_cbo.TabIndex = 193
        Me.Provider_cbo.ValueMember = ""
        '
        'Grd_Modeles
        '
        Me.Grd_Modeles.AfficherLesEntetesLignes = False
        Me.Grd_Modeles.AllowUserToAddRows = False
        Me.Grd_Modeles.AllowUserToDeleteRows = False
        Me.Grd_Modeles.AlternerLesLignes = False
        Me.Grd_Modeles.AutoGenerateColumns = False
        Me.Grd_Modeles.BackgroundColor = System.Drawing.Color.White
        Me.Grd_Modeles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Modeles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Modeles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Modeles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Modeles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Grd_Modeles_Defaut, Me.Grd_Modeles_Provider, Me.Grd_Modeles_Modele, Me.Grd_Modeles_Url, Me.Grd_Modeles_Portee})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Modeles.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Modeles.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grd_Modeles.EnableHeadersVisualStyles = False
        Me.Grd_Modeles.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Modeles.Location = New System.Drawing.Point(3, 28)
        Me.Grd_Modeles.MultiSelect = False
        Me.Grd_Modeles.Name = "Grd_Modeles"
        Me.Grd_Modeles.ReadOnly = True
        Me.Grd_Modeles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Modeles.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Modeles.RowHeadersWidth = 51
        Me.Grd_Modeles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grd_Modeles.Size = New System.Drawing.Size(1177, 130)
        Me.Grd_Modeles.TabIndex = 2
        '
        'Grd_Modeles_Defaut
        '
        Me.Grd_Modeles_Defaut.DataPropertyName = "Par_Defaut"
        Me.Grd_Modeles_Defaut.FalseValue = "false"
        Me.Grd_Modeles_Defaut.HeaderText = "Par défaut"
        Me.Grd_Modeles_Defaut.MinimumWidth = 6
        Me.Grd_Modeles_Defaut.Name = "Grd_Modeles_Defaut"
        Me.Grd_Modeles_Defaut.ReadOnly = True
        Me.Grd_Modeles_Defaut.TrueValue = "true"
        Me.Grd_Modeles_Defaut.Width = 75
        '
        'Grd_Modeles_Provider
        '
        Me.Grd_Modeles_Provider.DataPropertyName = "Provider"
        Me.Grd_Modeles_Provider.HeaderText = "Service"
        Me.Grd_Modeles_Provider.MinimumWidth = 6
        Me.Grd_Modeles_Provider.Name = "Grd_Modeles_Provider"
        Me.Grd_Modeles_Provider.ReadOnly = True
        Me.Grd_Modeles_Provider.Width = 110
        '
        'Grd_Modeles_Modele
        '
        Me.Grd_Modeles_Modele.DataPropertyName = "Modele"
        Me.Grd_Modeles_Modele.HeaderText = "Modèle"
        Me.Grd_Modeles_Modele.MinimumWidth = 6
        Me.Grd_Modeles_Modele.Name = "Grd_Modeles_Modele"
        Me.Grd_Modeles_Modele.ReadOnly = True
        Me.Grd_Modeles_Modele.Width = 220
        '
        'Grd_Modeles_Url
        '
        Me.Grd_Modeles_Url.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Grd_Modeles_Url.DataPropertyName = "aiUrl"
        Me.Grd_Modeles_Url.HeaderText = "Url"
        Me.Grd_Modeles_Url.MinimumWidth = 6
        Me.Grd_Modeles_Url.Name = "Grd_Modeles_Url"
        Me.Grd_Modeles_Url.ReadOnly = True
        '
        'Grd_Modeles_Portee
        '
        Me.Grd_Modeles_Portee.DataPropertyName = "Portee"
        Me.Grd_Modeles_Portee.HeaderText = "Portée"
        Me.Grd_Modeles_Portee.MinimumWidth = 6
        Me.Grd_Modeles_Portee.Name = "Grd_Modeles_Portee"
        Me.Grd_Modeles_Portee.ReadOnly = True
        Me.Grd_Modeles_Portee.Width = 90
        '
        'Lbl_Modeles
        '
        Me.Lbl_Modeles.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lbl_Modeles.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Modeles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Lbl_Modeles.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Modeles.Name = "Lbl_Modeles"
        Me.Lbl_Modeles.Padding = New System.Windows.Forms.Padding(5, 3, 0, 0)
        Me.Lbl_Modeles.Size = New System.Drawing.Size(1177, 25)
        Me.Lbl_Modeles.TabIndex = 1
        Me.Lbl_Modeles.Text = "Modèles enregistrés — l'assistant IA (portail, desktop, scripts) utilise le modèle coché 'Par défaut'."
        '
        'TabPage_Instruction
        '
        Me.TabPage_Instruction.Controls.Add(Me.Instructions_txt)
        Me.TabPage_Instruction.Location = New System.Drawing.Point(4, 25)
        Me.TabPage_Instruction.Name = "TabPage_Instruction"
        Me.TabPage_Instruction.Size = New System.Drawing.Size(1183, 525)
        Me.TabPage_Instruction.TabIndex = 1
        Me.TabPage_Instruction.Text = "Instruction"
        Me.TabPage_Instruction.UseVisualStyleBackColor = True
        '
        'Instructions_txt
        '
        Me.Instructions_txt.AutoSize = True
        Me.Instructions_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Instructions_txt.ContextMenuStrip = Nothing
        Me.Instructions_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Instructions_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Instructions_txt.Location = New System.Drawing.Point(0, 0)
        Me.Instructions_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.Instructions_txt.MaxLength = 5000000
        Me.Instructions_txt.Multiline = True
        Me.Instructions_txt.Name = "Instructions_txt"
        Me.Instructions_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Instructions_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Instructions_txt.ReadOnly = False
        Me.Instructions_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Instructions_txt.SelectionStart = 0
        Me.Instructions_txt.Size = New System.Drawing.Size(1183, 525)
        Me.Instructions_txt.TabIndex = 198
        Me.Instructions_txt.Tag = "0"
        Me.Instructions_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Instructions_txt.UseSystemPasswordChar = False
        '
        'AI_Modeles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 554)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AI_Modeles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Gestion des Modèles IA (LLM)"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_Fiche.ResumeLayout(False)
        Me.Panel_Fiche.ResumeLayout(False)
        Me.Panel_Fiche.PerformLayout()
        CType(Me.Nouveau_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SupprimerModele_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddModele_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TesterConn_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nb_Msg_Memory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd_Modeles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_Instruction.ResumeLayout(False)
        Me.TabPage_Instruction.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage_Fiche As TabPage
    Friend WithEvents TabPage_Instruction As TabPage
    Friend WithEvents Panel_Fiche As Panel
    Friend WithEvents Nouveau_pb As PictureBox
    Friend WithEvents SupprimerModele_pb As PictureBox
    Friend WithEvents Defaut_chk As ud_CheckBox
    Friend WithEvents AddModele_pb As PictureBox
    Friend WithEvents TesterConn_pb As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents nb_Msg_Memory As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Modele_cbo As ud_ComboBox
    Friend WithEvents Global_chk As ud_CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents AiUrl_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ApiKey_txt As ud_TextBox
    Friend WithEvents lblDen As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Provider_cbo As ud_ComboBox
    Friend WithEvents Grd_Modeles As RHP.ud_Grd
    Friend WithEvents Grd_Modeles_Defaut As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Grd_Modeles_Provider As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grd_Modeles_Modele As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grd_Modeles_Url As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grd_Modeles_Portee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lbl_Modeles As Label
    Friend WithEvents Instructions_txt As ud_TextBox
End Class
