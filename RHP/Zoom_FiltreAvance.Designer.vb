<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_FiltreAvance
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
        Me.Filtre_txt = New System.Windows.Forms.RichTextBox()
        Me.LvChamps = New System.Windows.Forms.ListView()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.New_pb = New System.Windows.Forms.PictureBox()
        Me.Filter_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.pb_Comme = New RHP.ud_button()
        Me.pb_Egal = New RHP.ud_button()
        Me.pb_Devision = New RHP.ud_button()
        Me.pb_different = New RHP.ud_button()
        Me.pb_Fois = New RHP.ud_button()
        Me.pb_Moins = New RHP.ud_button()
        Me.pb_Parentese2 = New RHP.ud_button()
        Me.pb_Parentese1 = New RHP.ud_button()
        Me.pb_infEgal = New RHP.ud_button()
        Me.pb_SupEgal = New RHP.ud_button()
        Me.pb_Plus = New RHP.ud_button()
        Me.pb_PasEgal = New RHP.ud_button()
        Me.pb_Sup = New RHP.ud_button()
        Me.pb_inf = New RHP.ud_button()
        Me.pb_Parmi = New RHP.ud_button()
        Me.pb_PasParmi = New RHP.ud_button()
        Me.pb_Et = New RHP.ud_button()
        Me.pb_Ou = New RHP.ud_button()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Filter_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btn_pnl.SuspendLayout()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Filtre_txt
        '
        Me.Filtre_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Filtre_txt.Location = New System.Drawing.Point(0, 34)
        Me.Filtre_txt.Name = "Filtre_txt"
        Me.Filtre_txt.Size = New System.Drawing.Size(291, 163)
        Me.Filtre_txt.TabIndex = 0
        Me.Filtre_txt.Text = ""
        '
        'LvChamps
        '
        Me.LvChamps.Dock = System.Windows.Forms.DockStyle.Right
        Me.LvChamps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvChamps.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LvChamps.GridLines = True
        Me.LvChamps.HideSelection = False
        Me.LvChamps.Location = New System.Drawing.Point(291, 34)
        Me.LvChamps.Name = "LvChamps"
        Me.LvChamps.Size = New System.Drawing.Size(281, 286)
        Me.LvChamps.TabIndex = 0
        Me.LvChamps.UseCompatibleStateImageBehavior = False
        Me.LvChamps.View = System.Windows.Forms.View.List
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 4
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.Controls.Add(Me.New_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Filter_pb, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 3, 0)
        Me.Personnal_pnl.Controls.Add(Me.Label1, 2, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(572, 34)
        Me.Personnal_pnl.TabIndex = 209
        '
        'New_pb
        '
        Me.New_pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.New_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.New_pb.Image = Global.RHP.My.Resources.Resources.btn_add_w1
        Me.New_pb.InitialImage = Nothing
        Me.New_pb.Location = New System.Drawing.Point(3, 3)
        Me.New_pb.Name = "New_pb"
        Me.New_pb.Size = New System.Drawing.Size(24, 28)
        Me.New_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.New_pb.TabIndex = 5
        Me.New_pb.TabStop = False
        '
        'Filter_pb
        '
        Me.Filter_pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Filter_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Filter_pb.Image = Global.RHP.My.Resources.Resources.btn_filter_w
        Me.Filter_pb.InitialImage = Nothing
        Me.Filter_pb.Location = New System.Drawing.Point(33, 3)
        Me.Filter_pb.Name = "Filter_pb"
        Me.Filter_pb.Size = New System.Drawing.Size(24, 28)
        Me.Filter_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Filter_pb.TabIndex = 5
        Me.Filter_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(545, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 28)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 5
        Me.Close_pb.TabStop = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(63, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(476, 34)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Filtre avancé"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_pnl
        '
        Me.btn_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btn_pnl.ColumnCount = 9
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.btn_pnl.Controls.Add(Me.pb_Comme, 6, 0)
        Me.btn_pnl.Controls.Add(Me.pb_Egal, 7, 1)
        Me.btn_pnl.Controls.Add(Me.pb_Devision, 7, 2)
        Me.btn_pnl.Controls.Add(Me.pb_different, 6, 1)
        Me.btn_pnl.Controls.Add(Me.pb_Fois, 6, 2)
        Me.btn_pnl.Controls.Add(Me.pb_Moins, 5, 2)
        Me.btn_pnl.Controls.Add(Me.pb_Parentese2, 5, 1)
        Me.btn_pnl.Controls.Add(Me.pb_Parentese1, 5, 0)
        Me.btn_pnl.Controls.Add(Me.pb_infEgal, 4, 0)
        Me.btn_pnl.Controls.Add(Me.pb_SupEgal, 4, 1)
        Me.btn_pnl.Controls.Add(Me.pb_Plus, 4, 2)
        Me.btn_pnl.Controls.Add(Me.pb_PasEgal, 3, 2)
        Me.btn_pnl.Controls.Add(Me.pb_Sup, 3, 1)
        Me.btn_pnl.Controls.Add(Me.pb_inf, 3, 0)
        Me.btn_pnl.Controls.Add(Me.pb_Parmi, 1, 0)
        Me.btn_pnl.Controls.Add(Me.pb_PasParmi, 1, 1)
        Me.btn_pnl.Controls.Add(Me.pb_Et, 2, 2)
        Me.btn_pnl.Controls.Add(Me.pb_Ou, 1, 2)
        Me.btn_pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_pnl.Location = New System.Drawing.Point(0, 197)
        Me.btn_pnl.Name = "btn_pnl"
        Me.btn_pnl.RowCount = 3
        Me.btn_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.btn_pnl.Size = New System.Drawing.Size(291, 123)
        Me.btn_pnl.TabIndex = 210
        '
        'pb_Comme
        '
        Me.pb_Comme.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Comme.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Comme.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Comme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Comme.BorderSize = 2
        Me.btn_pnl.SetColumnSpan(Me.pb_Comme, 2)
        Me.pb_Comme.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Comme.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Comme.Image = Nothing
        Me.pb_Comme.Location = New System.Drawing.Point(210, 5)
        Me.pb_Comme.Margin = New System.Windows.Forms.Padding(1)
        Me.pb_Comme.MinimumSize = New System.Drawing.Size(18, 22)
        Me.pb_Comme.Name = "pb_Comme"
        Me.pb_Comme.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Comme.Size = New System.Drawing.Size(70, 30)
        Me.pb_Comme.TabIndex = 3
        Me.pb_Comme.TabStop = False
        Me.pb_Comme.Tag = "Comme '**'"
        Me.pb_Comme.Text = "Comme"
        Me.pb_Comme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Egal
        '
        Me.pb_Egal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Egal.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Egal.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Egal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Egal.BorderSize = 2
        Me.pb_Egal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Egal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Egal.Image = Nothing
        Me.pb_Egal.Location = New System.Drawing.Point(250, 45)
        Me.pb_Egal.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Egal.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Egal.Name = "pb_Egal"
        Me.pb_Egal.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Egal.Size = New System.Drawing.Size(30, 30)
        Me.pb_Egal.TabIndex = 11
        Me.pb_Egal.TabStop = False
        Me.pb_Egal.Tag = "= ''"
        Me.pb_Egal.Text = "="
        Me.pb_Egal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Devision
        '
        Me.pb_Devision.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Devision.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Devision.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Devision.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Devision.BorderSize = 2
        Me.pb_Devision.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Devision.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Devision.Image = Nothing
        Me.pb_Devision.Location = New System.Drawing.Point(250, 86)
        Me.pb_Devision.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Devision.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Devision.Name = "pb_Devision"
        Me.pb_Devision.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Devision.Size = New System.Drawing.Size(30, 30)
        Me.pb_Devision.TabIndex = 7
        Me.pb_Devision.TabStop = False
        Me.pb_Devision.Tag = "/"
        Me.pb_Devision.Text = "/"
        Me.pb_Devision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_different
        '
        Me.pb_different.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_different.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_different.Border = RHP.ud_button.BorderStyle.All
        Me.pb_different.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_different.BorderSize = 2
        Me.pb_different.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_different.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_different.Image = Nothing
        Me.pb_different.Location = New System.Drawing.Point(210, 45)
        Me.pb_different.Margin = New System.Windows.Forms.Padding(1)
        Me.pb_different.MinimumSize = New System.Drawing.Size(18, 22)
        Me.pb_different.Name = "pb_different"
        Me.pb_different.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_different.Size = New System.Drawing.Size(30, 30)
        Me.pb_different.TabIndex = 8
        Me.pb_different.TabStop = False
        Me.pb_different.Tag = "Différent '**'"
        Me.pb_different.Text = "#"
        Me.pb_different.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Fois
        '
        Me.pb_Fois.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Fois.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Fois.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Fois.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Fois.BorderSize = 2
        Me.pb_Fois.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Fois.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Fois.Image = Nothing
        Me.pb_Fois.Location = New System.Drawing.Point(210, 86)
        Me.pb_Fois.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Fois.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Fois.Name = "pb_Fois"
        Me.pb_Fois.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Fois.Size = New System.Drawing.Size(30, 30)
        Me.pb_Fois.TabIndex = 7
        Me.pb_Fois.TabStop = False
        Me.pb_Fois.Tag = "*"
        Me.pb_Fois.Text = "*"
        Me.pb_Fois.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Moins
        '
        Me.pb_Moins.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Moins.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Moins.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Moins.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Moins.BorderSize = 2
        Me.pb_Moins.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Moins.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Moins.Image = Nothing
        Me.pb_Moins.Location = New System.Drawing.Point(170, 86)
        Me.pb_Moins.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Moins.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Moins.Name = "pb_Moins"
        Me.pb_Moins.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Moins.Size = New System.Drawing.Size(30, 30)
        Me.pb_Moins.TabIndex = 7
        Me.pb_Moins.TabStop = False
        Me.pb_Moins.Tag = "-"
        Me.pb_Moins.Text = "-"
        Me.pb_Moins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Parentese2
        '
        Me.pb_Parentese2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Parentese2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parentese2.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Parentese2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parentese2.BorderSize = 2
        Me.pb_Parentese2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Parentese2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Parentese2.Image = Nothing
        Me.pb_Parentese2.Location = New System.Drawing.Point(170, 45)
        Me.pb_Parentese2.Margin = New System.Windows.Forms.Padding(1)
        Me.pb_Parentese2.MinimumSize = New System.Drawing.Size(18, 22)
        Me.pb_Parentese2.Name = "pb_Parentese2"
        Me.pb_Parentese2.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Parentese2.Size = New System.Drawing.Size(30, 30)
        Me.pb_Parentese2.TabIndex = 3
        Me.pb_Parentese2.TabStop = False
        Me.pb_Parentese2.Tag = ")"
        Me.pb_Parentese2.Text = ")"
        Me.pb_Parentese2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Parentese1
        '
        Me.pb_Parentese1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Parentese1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parentese1.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Parentese1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parentese1.BorderSize = 2
        Me.pb_Parentese1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Parentese1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Parentese1.Image = Nothing
        Me.pb_Parentese1.Location = New System.Drawing.Point(170, 5)
        Me.pb_Parentese1.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Parentese1.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Parentese1.Name = "pb_Parentese1"
        Me.pb_Parentese1.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Parentese1.Size = New System.Drawing.Size(30, 30)
        Me.pb_Parentese1.TabIndex = 3
        Me.pb_Parentese1.TabStop = False
        Me.pb_Parentese1.Tag = "("
        Me.pb_Parentese1.Text = "("
        Me.pb_Parentese1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_infEgal
        '
        Me.pb_infEgal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_infEgal.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_infEgal.Border = RHP.ud_button.BorderStyle.All
        Me.pb_infEgal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_infEgal.BorderSize = 2
        Me.pb_infEgal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_infEgal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_infEgal.Image = Nothing
        Me.pb_infEgal.Location = New System.Drawing.Point(130, 5)
        Me.pb_infEgal.Margin = New System.Windows.Forms.Padding(1)
        Me.pb_infEgal.MinimumSize = New System.Drawing.Size(18, 22)
        Me.pb_infEgal.Name = "pb_infEgal"
        Me.pb_infEgal.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_infEgal.Size = New System.Drawing.Size(30, 30)
        Me.pb_infEgal.TabIndex = 8
        Me.pb_infEgal.TabStop = False
        Me.pb_infEgal.Tag = "<= ''"
        Me.pb_infEgal.Text = "<="
        Me.pb_infEgal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_SupEgal
        '
        Me.pb_SupEgal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_SupEgal.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_SupEgal.Border = RHP.ud_button.BorderStyle.All
        Me.pb_SupEgal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_SupEgal.BorderSize = 2
        Me.pb_SupEgal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_SupEgal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_SupEgal.Image = Nothing
        Me.pb_SupEgal.Location = New System.Drawing.Point(130, 45)
        Me.pb_SupEgal.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_SupEgal.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_SupEgal.Name = "pb_SupEgal"
        Me.pb_SupEgal.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_SupEgal.Size = New System.Drawing.Size(30, 30)
        Me.pb_SupEgal.TabIndex = 8
        Me.pb_SupEgal.TabStop = False
        Me.pb_SupEgal.Tag = ">= ''"
        Me.pb_SupEgal.Text = ">="
        Me.pb_SupEgal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Plus
        '
        Me.pb_Plus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Plus.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Plus.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Plus.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Plus.BorderSize = 2
        Me.pb_Plus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Plus.Image = Nothing
        Me.pb_Plus.Location = New System.Drawing.Point(130, 86)
        Me.pb_Plus.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Plus.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Plus.Name = "pb_Plus"
        Me.pb_Plus.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Plus.Size = New System.Drawing.Size(30, 30)
        Me.pb_Plus.TabIndex = 4
        Me.pb_Plus.TabStop = False
        Me.pb_Plus.Tag = "+"
        Me.pb_Plus.Text = "+"
        Me.pb_Plus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_PasEgal
        '
        Me.pb_PasEgal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_PasEgal.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_PasEgal.Border = RHP.ud_button.BorderStyle.All
        Me.pb_PasEgal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_PasEgal.BorderSize = 2
        Me.pb_PasEgal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_PasEgal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_PasEgal.Image = Nothing
        Me.pb_PasEgal.Location = New System.Drawing.Point(90, 86)
        Me.pb_PasEgal.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_PasEgal.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_PasEgal.Name = "pb_PasEgal"
        Me.pb_PasEgal.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_PasEgal.Size = New System.Drawing.Size(30, 30)
        Me.pb_PasEgal.TabIndex = 7
        Me.pb_PasEgal.TabStop = False
        Me.pb_PasEgal.Tag = "<> ''"
        Me.pb_PasEgal.Text = "<>"
        Me.pb_PasEgal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Sup
        '
        Me.pb_Sup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Sup.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Sup.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Sup.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Sup.BorderSize = 2
        Me.pb_Sup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Sup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Sup.Image = Nothing
        Me.pb_Sup.Location = New System.Drawing.Point(90, 45)
        Me.pb_Sup.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Sup.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Sup.Name = "pb_Sup"
        Me.pb_Sup.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Sup.Size = New System.Drawing.Size(30, 30)
        Me.pb_Sup.TabIndex = 5
        Me.pb_Sup.TabStop = False
        Me.pb_Sup.Tag = "> ''"
        Me.pb_Sup.Text = ">"
        Me.pb_Sup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_inf
        '
        Me.pb_inf.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_inf.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_inf.Border = RHP.ud_button.BorderStyle.All
        Me.pb_inf.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_inf.BorderSize = 2
        Me.pb_inf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_inf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_inf.Image = Nothing
        Me.pb_inf.Location = New System.Drawing.Point(90, 5)
        Me.pb_inf.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_inf.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_inf.Name = "pb_inf"
        Me.pb_inf.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_inf.Size = New System.Drawing.Size(30, 30)
        Me.pb_inf.TabIndex = 6
        Me.pb_inf.TabStop = False
        Me.pb_inf.Tag = "< ''"
        Me.pb_inf.Text = "<"
        Me.pb_inf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Parmi
        '
        Me.pb_Parmi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Parmi.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parmi.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Parmi.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parmi.BorderSize = 2
        Me.btn_pnl.SetColumnSpan(Me.pb_Parmi, 2)
        Me.pb_Parmi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Parmi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Parmi.Image = Nothing
        Me.pb_Parmi.Location = New System.Drawing.Point(10, 5)
        Me.pb_Parmi.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Parmi.MinimumSize = New System.Drawing.Size(20, 20)
        Me.pb_Parmi.Name = "pb_Parmi"
        Me.pb_Parmi.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Parmi.Size = New System.Drawing.Size(70, 30)
        Me.pb_Parmi.TabIndex = 3
        Me.pb_Parmi.TabStop = False
        Me.pb_Parmi.Tag = "Parmi  ('','','')"
        Me.pb_Parmi.Text = "Parmi"
        Me.pb_Parmi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_PasParmi
        '
        Me.pb_PasParmi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_PasParmi.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_PasParmi.Border = RHP.ud_button.BorderStyle.All
        Me.pb_PasParmi.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_PasParmi.BorderSize = 2
        Me.btn_pnl.SetColumnSpan(Me.pb_PasParmi, 2)
        Me.pb_PasParmi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_PasParmi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_PasParmi.Image = Nothing
        Me.pb_PasParmi.Location = New System.Drawing.Point(10, 45)
        Me.pb_PasParmi.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_PasParmi.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_PasParmi.Name = "pb_PasParmi"
        Me.pb_PasParmi.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_PasParmi.Size = New System.Drawing.Size(70, 30)
        Me.pb_PasParmi.TabIndex = 3
        Me.pb_PasParmi.TabStop = False
        Me.pb_PasParmi.Tag = "Pas Parmi  ('','','')"
        Me.pb_PasParmi.Text = "Pas Parmi"
        Me.pb_PasParmi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Et
        '
        Me.pb_Et.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Et.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Et.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Et.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Et.BorderSize = 2
        Me.pb_Et.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Et.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Et.Image = Nothing
        Me.pb_Et.Location = New System.Drawing.Point(50, 86)
        Me.pb_Et.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Et.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Et.Name = "pb_Et"
        Me.pb_Et.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Et.Size = New System.Drawing.Size(30, 30)
        Me.pb_Et.TabIndex = 3
        Me.pb_Et.TabStop = False
        Me.pb_Et.Tag = "Et"
        Me.pb_Et.Text = "Et"
        Me.pb_Et.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Ou
        '
        Me.pb_Ou.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Ou.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Ou.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Ou.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Ou.BorderSize = 2
        Me.pb_Ou.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Ou.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Ou.Image = Nothing
        Me.pb_Ou.Location = New System.Drawing.Point(10, 86)
        Me.pb_Ou.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Ou.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Ou.Name = "pb_Ou"
        Me.pb_Ou.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Ou.Size = New System.Drawing.Size(30, 30)
        Me.pb_Ou.TabIndex = 3
        Me.pb_Ou.TabStop = False
        Me.pb_Ou.Tag = "Ou"
        Me.pb_Ou.Text = "Ou"
        Me.pb_Ou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pnl
        '
        Me.Pnl.Controls.Add(Me.Filtre_txt)
        Me.Pnl.Controls.Add(Me.btn_pnl)
        Me.Pnl.Controls.Add(Me.LvChamps)
        Me.Pnl.Controls.Add(Me.Personnal_pnl)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 2)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(572, 320)
        Me.Pnl.TabIndex = 211
        '
        'Zoom_FiltreAvance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(576, 324)
        Me.Controls.Add(Me.Pnl)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_FiltreAvance"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtre Avancé"
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Filter_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btn_pnl.ResumeLayout(False)
        Me.Pnl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Filtre_txt As RichTextBox
    Friend WithEvents LvChamps As ListView
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents New_pb As PictureBox
    Friend WithEvents Filter_pb As PictureBox
    Friend WithEvents btn_pnl As TableLayoutPanel
    Friend WithEvents pb_Comme As ud_button
    Friend WithEvents pb_Egal As ud_button
    Friend WithEvents pb_Devision As ud_button
    Friend WithEvents pb_different As ud_button
    Friend WithEvents pb_Fois As ud_button
    Friend WithEvents pb_Moins As ud_button
    Friend WithEvents pb_Parentese2 As ud_button
    Friend WithEvents pb_Parentese1 As ud_button
    Friend WithEvents pb_infEgal As ud_button
    Friend WithEvents pb_SupEgal As ud_button
    Friend WithEvents pb_Plus As ud_button
    Friend WithEvents pb_PasEgal As ud_button
    Friend WithEvents pb_Sup As ud_button
    Friend WithEvents pb_inf As ud_button
    Friend WithEvents pb_Parmi As ud_button
    Friend WithEvents pb_PasParmi As ud_button
    Friend WithEvents pb_Et As ud_button
    Friend WithEvents pb_Ou As ud_button
    Friend WithEvents Pnl As Panel
    Friend WithEvents Label1 As Label
End Class
