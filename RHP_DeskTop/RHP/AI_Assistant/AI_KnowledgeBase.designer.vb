<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AI_KnowledgeBase
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
        Me.Ud_Panel1 = New RHP.ud_Panel()
        Me.Grd_Docs = New RHP.ud_Grd()
        Me.Col_File = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Chunk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel_Actions = New System.Windows.Forms.Panel()
        Me.Tester_EmbeddingConn_btn = New RHP.ud_button()
        Me.Lbl_Status = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
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
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Instructions_txt = New RHP.ud_TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Ud_Panel1.SuspendLayout()
        CType(Me.Grd_Docs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Actions.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.AddModele_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TesterConn_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nb_Msg_Memory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ud_Panel1
        '
        Me.Ud_Panel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel1.BorderSize = 2
        Me.Ud_Panel1.Controls.Add(Me.Grd_Docs)
        Me.Ud_Panel1.Controls.Add(Me.Panel_Actions)
        Me.Ud_Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Ud_Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Ud_Panel1.Name = "Ud_Panel1"
        Me.Ud_Panel1.Size = New System.Drawing.Size(1177, 519)
        Me.Ud_Panel1.TabIndex = 0
        '
        'Grd_Docs
        '
        Me.Grd_Docs.AfficherLesEntetesLignes = True
        Me.Grd_Docs.AllowUserToAddRows = False
        Me.Grd_Docs.AlternerLesLignes = False
        Me.Grd_Docs.BackgroundColor = System.Drawing.Color.White
        Me.Grd_Docs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Docs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Docs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Docs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Docs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_File, Me.Col_Status, Me.Col_Chunk})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Docs.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Docs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Docs.EnableHeadersVisualStyles = False
        Me.Grd_Docs.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Docs.Location = New System.Drawing.Point(0, 115)
        Me.Grd_Docs.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Docs.Name = "Grd_Docs"
        Me.Grd_Docs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Docs.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Docs.RowHeadersWidth = 51
        Me.Grd_Docs.Size = New System.Drawing.Size(1177, 404)
        Me.Grd_Docs.TabIndex = 1
        Me.Grd_Docs.Tag = "ECR"
        '
        'Col_File
        '
        Me.Col_File.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Col_File.HeaderText = "Dossier / Fichier"
        Me.Col_File.MinimumWidth = 6
        Me.Col_File.Name = "Col_File"
        '
        'Col_Status
        '
        Me.Col_Status.HeaderText = "Statut"
        Me.Col_Status.MinimumWidth = 6
        Me.Col_Status.Name = "Col_Status"
        Me.Col_Status.Width = 125
        '
        'Col_Chunk
        '
        Me.Col_Chunk.HeaderText = "Segments"
        Me.Col_Chunk.MinimumWidth = 6
        Me.Col_Chunk.Name = "Col_Chunk"
        Me.Col_Chunk.Width = 125
        '
        'Panel_Actions
        '
        Me.Panel_Actions.Controls.Add(Me.Tester_EmbeddingConn_btn)
        Me.Panel_Actions.Controls.Add(Me.Lbl_Status)
        Me.Panel_Actions.Controls.Add(Me.ProgressBar1)
        Me.Panel_Actions.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Actions.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Actions.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel_Actions.Name = "Panel_Actions"
        Me.Panel_Actions.Size = New System.Drawing.Size(1177, 115)
        Me.Panel_Actions.TabIndex = 2
        '
        'Tester_EmbeddingConn_btn
        '
        Me.Tester_EmbeddingConn_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Tester_EmbeddingConn_btn.bgColor = System.Drawing.Color.White
        Me.Tester_EmbeddingConn_btn.Border = RHP.ud_button.BorderStyle.All
        Me.Tester_EmbeddingConn_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Tester_EmbeddingConn_btn.BorderSize = 2
        Me.Tester_EmbeddingConn_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tester_EmbeddingConn_btn.Image = Global.RHP.My.Resources.Resources.btn_testCon
        Me.Tester_EmbeddingConn_btn.isDefault = False
        Me.Tester_EmbeddingConn_btn.Location = New System.Drawing.Point(16, 10)
        Me.Tester_EmbeddingConn_btn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tester_EmbeddingConn_btn.MinimumSize = New System.Drawing.Size(27, 25)
        Me.Tester_EmbeddingConn_btn.Name = "Tester_EmbeddingConn_btn"
        Me.Tester_EmbeddingConn_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.Tester_EmbeddingConn_btn.Size = New System.Drawing.Size(180, 32)
        Me.Tester_EmbeddingConn_btn.TabIndex = 4
        Me.Tester_EmbeddingConn_btn.Text = "Tester l'embedding"
        '
        'Lbl_Status
        '
        Me.Lbl_Status.AutoSize = True
        Me.Lbl_Status.Location = New System.Drawing.Point(19, 65)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(16, 16)
        Me.Lbl_Status.TabIndex = 3
        Me.Lbl_Status.Text = "   "
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 85)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1037, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1191, 554)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.AddModele_pb)
        Me.TabPage1.Controls.Add(Me.TesterConn_pb)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.nb_Msg_Memory)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Modele_cbo)
        Me.TabPage1.Controls.Add(Me.Global_chk)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.AiUrl_txt)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.ApiKey_txt)
        Me.TabPage1.Controls.Add(Me.lblDen)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Provider_cbo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1183, 525)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Fiche AI Agent "
        Me.TabPage1.UseVisualStyleBackColor = True
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
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Instructions_txt)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1183, 525)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Instruction"
        Me.TabPage3.UseVisualStyleBackColor = True
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
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Ud_Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1183, 525)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Base de connaissances"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'AI_KnowledgeBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 554)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AI_KnowledgeBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Gestion de la Base de Connaissance IA"
        Me.Ud_Panel1.ResumeLayout(False)
        CType(Me.Grd_Docs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Actions.ResumeLayout(False)
        Me.Panel_Actions.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.AddModele_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TesterConn_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nb_Msg_Memory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Ud_Panel1 As RHP.ud_Panel
    Friend WithEvents Grd_Docs As RHP.ud_Grd
    Friend WithEvents Col_File As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Chunk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel_Actions As System.Windows.Forms.Panel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Lbl_Status As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Modele_cbo As ud_ComboBox
    Friend WithEvents Global_chk As ud_CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents AiUrl_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ApiKey_txt As ud_TextBox
    Friend WithEvents lblDen As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Provider_cbo As ud_ComboBox
    Friend WithEvents Instructions_txt As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents nb_Msg_Memory As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Tester_EmbeddingConn_btn As ud_button
    Friend WithEvents TesterConn_pb As PictureBox
    Friend WithEvents AddModele_pb As PictureBox
End Class
