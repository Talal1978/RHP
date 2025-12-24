<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Rubrique_Relation
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
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.btn_Devision = New DevComponents.DotNetBar.ButtonX()
        Me.btn_Fois = New DevComponents.DotNetBar.ButtonX()
        Me.btn_Egal = New DevComponents.DotNetBar.ButtonX()
        Me.btn_Parentese2 = New DevComponents.DotNetBar.ButtonX()
        Me.btn_Parentese1 = New DevComponents.DotNetBar.ButtonX()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Tx_pb = New RHP.ud_button()
        Me.Base_pb = New RHP.ud_button()
        Me.Nb_pb = New RHP.ud_button()
        Me.Zone_txt = New System.Windows.Forms.RichTextBox()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pb_Moins = New RHP.ud_button()
        Me.pb_Plus = New RHP.ud_button()
        Me.pb_Fois = New RHP.ud_button()
        Me.pb_Division = New RHP.ud_button()
        Me.pb_Parentese1 = New RHP.ud_button()
        Me.pb_Parentese2 = New RHP.ud_button()
        Me.pb_Egal = New RHP.ud_button()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Personnal_pnl.SuspendLayout()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(2, 32)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btn_Devision)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btn_Fois)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btn_Egal)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btn_Parentese2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btn_Parentese1)
        Me.SplitContainer2.Size = New System.Drawing.Size(558, 209)
        Me.SplitContainer2.SplitterDistance = 115
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 0
        '
        'btn_Devision
        '
        Me.btn_Devision.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_Devision.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Devision.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_Devision.Location = New System.Drawing.Point(191, 5)
        Me.btn_Devision.Name = "btn_Devision"
        Me.btn_Devision.Size = New System.Drawing.Size(45, 23)
        Me.btn_Devision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn_Devision.TabIndex = 17
        Me.btn_Devision.Tag = "/"
        Me.btn_Devision.Text = "/"
        '
        'btn_Fois
        '
        Me.btn_Fois.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_Fois.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Fois.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_Fois.Location = New System.Drawing.Point(140, 5)
        Me.btn_Fois.Name = "btn_Fois"
        Me.btn_Fois.Size = New System.Drawing.Size(45, 23)
        Me.btn_Fois.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn_Fois.TabIndex = 16
        Me.btn_Fois.Tag = "*"
        Me.btn_Fois.Text = "*"
        '
        'btn_Egal
        '
        Me.btn_Egal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_Egal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Egal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_Egal.Location = New System.Drawing.Point(342, 5)
        Me.btn_Egal.Name = "btn_Egal"
        Me.btn_Egal.Size = New System.Drawing.Size(45, 23)
        Me.btn_Egal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn_Egal.TabIndex = 7
        Me.btn_Egal.Tag = "= ''"
        Me.btn_Egal.Text = "="
        '
        'btn_Parentese2
        '
        Me.btn_Parentese2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_Parentese2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Parentese2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_Parentese2.Location = New System.Drawing.Point(293, 5)
        Me.btn_Parentese2.Name = "btn_Parentese2"
        Me.btn_Parentese2.Size = New System.Drawing.Size(45, 23)
        Me.btn_Parentese2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn_Parentese2.TabIndex = 5
        Me.btn_Parentese2.Tag = ")"
        Me.btn_Parentese2.Text = ")"
        '
        'btn_Parentese1
        '
        Me.btn_Parentese1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_Parentese1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Parentese1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_Parentese1.Location = New System.Drawing.Point(242, 5)
        Me.btn_Parentese1.Name = "btn_Parentese1"
        Me.btn_Parentese1.Size = New System.Drawing.Size(45, 23)
        Me.btn_Parentese1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn_Parentese1.TabIndex = 4
        Me.btn_Parentese1.Tag = "("
        Me.btn_Parentese1.Text = "("
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Personnal_pnl.ColumnCount = 1
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Controls.Add(Me.Tx_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Base_pb, 0, 1)
        Me.Personnal_pnl.Controls.Add(Me.Nb_pb, 0, 2)
        Me.Personnal_pnl.Location = New System.Drawing.Point(353, 20)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(3, 20, 3, 20)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 3
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(206, 134)
        Me.Personnal_pnl.TabIndex = 1
        '
        'Tx_pb
        '
        Me.Tx_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tx_pb.AutoSize = True
        Me.Tx_pb.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Tx_pb.Border = RHP.ud_button.BorderStyle.All
        Me.Tx_pb.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Tx_pb.BorderSize = 2
        Me.Tx_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tx_pb.Image = Nothing
        Me.Tx_pb.Location = New System.Drawing.Point(10, 8)
        Me.Tx_pb.Margin = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.Tx_pb.MinimumSize = New System.Drawing.Size(100, 25)
        Me.Tx_pb.Name = "Tx_pb"
        Me.Tx_pb.Padding = New System.Windows.Forms.Padding(2)
        Me.Tx_pb.Size = New System.Drawing.Size(186, 28)
        Me.Tx_pb.TabIndex = 0
        Me.Tx_pb.Tag = "Tx"
        Me.Tx_pb.Text = "Taux"
        Me.Tx_pb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Base_pb
        '
        Me.Base_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Base_pb.AutoSize = True
        Me.Base_pb.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Base_pb.Border = RHP.ud_button.BorderStyle.All
        Me.Base_pb.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Base_pb.BorderSize = 2
        Me.Base_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Base_pb.Image = Nothing
        Me.Base_pb.Location = New System.Drawing.Point(10, 52)
        Me.Base_pb.Margin = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.Base_pb.MinimumSize = New System.Drawing.Size(100, 25)
        Me.Base_pb.Name = "Base_pb"
        Me.Base_pb.Padding = New System.Windows.Forms.Padding(2)
        Me.Base_pb.Size = New System.Drawing.Size(186, 28)
        Me.Base_pb.TabIndex = 0
        Me.Base_pb.Tag = "Base"
        Me.Base_pb.Text = "Base"
        Me.Base_pb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Nb_pb
        '
        Me.Nb_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nb_pb.AutoSize = True
        Me.Nb_pb.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Nb_pb.Border = RHP.ud_button.BorderStyle.All
        Me.Nb_pb.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Nb_pb.BorderSize = 2
        Me.Nb_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Nb_pb.Image = Nothing
        Me.Nb_pb.Location = New System.Drawing.Point(10, 96)
        Me.Nb_pb.Margin = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.Nb_pb.MinimumSize = New System.Drawing.Size(100, 25)
        Me.Nb_pb.Name = "Nb_pb"
        Me.Nb_pb.Padding = New System.Windows.Forms.Padding(2)
        Me.Nb_pb.Size = New System.Drawing.Size(186, 30)
        Me.Nb_pb.TabIndex = 0
        Me.Nb_pb.Tag = "Nb"
        Me.Nb_pb.Text = "Nombre"
        Me.Nb_pb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Zone_txt
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Zone_txt, 7)
        Me.Zone_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Zone_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Zone_txt.Location = New System.Drawing.Point(3, 3)
        Me.Zone_txt.Name = "Zone_txt"
        Me.Zone_txt.Size = New System.Drawing.Size(344, 168)
        Me.Zone_txt.TabIndex = 0
        Me.Zone_txt.Text = ""
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ent_pnl.ColumnCount = 2
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ent_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 1, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(558, 30)
        Me.ent_pnl.TabIndex = 1
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save_w
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(3, 3)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(24, 24)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Save_pb.TabIndex = 5
        Me.Save_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(531, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 24)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 4
        Me.Close_pb.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Zone_txt, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pb_Moins, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.pb_Plus, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.pb_Fois, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.pb_Division, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.pb_Parentese1, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.pb_Parentese2, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.pb_Egal, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Personnal_pnl, 7, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 32)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(558, 209)
        Me.TableLayoutPanel2.TabIndex = 18
        '
        'pb_Moins
        '
        Me.pb_Moins.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Moins.AutoSize = True
        Me.pb_Moins.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Moins.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Moins.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Moins.BorderSize = 2
        Me.pb_Moins.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Moins.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Moins.Image = Nothing
        Me.pb_Moins.Location = New System.Drawing.Point(60, 176)
        Me.pb_Moins.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Moins.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Moins.Name = "pb_Moins"
        Me.pb_Moins.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Moins.Size = New System.Drawing.Size(30, 30)
        Me.pb_Moins.TabIndex = 2
        Me.pb_Moins.TabStop = False
        Me.pb_Moins.Tag = "-"
        Me.pb_Moins.Text = "-"
        Me.pb_Moins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Plus
        '
        Me.pb_Plus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Plus.AutoSize = True
        Me.pb_Plus.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Plus.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Plus.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Plus.BorderSize = 2
        Me.pb_Plus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Plus.Image = Nothing
        Me.pb_Plus.Location = New System.Drawing.Point(10, 176)
        Me.pb_Plus.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Plus.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Plus.Name = "pb_Plus"
        Me.pb_Plus.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Plus.Size = New System.Drawing.Size(30, 30)
        Me.pb_Plus.TabIndex = 2
        Me.pb_Plus.TabStop = False
        Me.pb_Plus.Tag = "+"
        Me.pb_Plus.Text = "+"
        Me.pb_Plus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Fois
        '
        Me.pb_Fois.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Fois.AutoSize = True
        Me.pb_Fois.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Fois.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Fois.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Fois.BorderSize = 2
        Me.pb_Fois.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Fois.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Fois.Image = Nothing
        Me.pb_Fois.Location = New System.Drawing.Point(110, 176)
        Me.pb_Fois.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Fois.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Fois.Name = "pb_Fois"
        Me.pb_Fois.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Fois.Size = New System.Drawing.Size(30, 30)
        Me.pb_Fois.TabIndex = 2
        Me.pb_Fois.TabStop = False
        Me.pb_Fois.Tag = "*"
        Me.pb_Fois.Text = "*"
        Me.pb_Fois.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Division
        '
        Me.pb_Division.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Division.AutoSize = True
        Me.pb_Division.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Division.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Division.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Division.BorderSize = 2
        Me.pb_Division.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Division.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Division.Image = Nothing
        Me.pb_Division.Location = New System.Drawing.Point(160, 176)
        Me.pb_Division.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Division.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Division.Name = "pb_Division"
        Me.pb_Division.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Division.Size = New System.Drawing.Size(30, 30)
        Me.pb_Division.TabIndex = 2
        Me.pb_Division.TabStop = False
        Me.pb_Division.Tag = "/"
        Me.pb_Division.Text = "/"
        Me.pb_Division.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Parentese1
        '
        Me.pb_Parentese1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Parentese1.AutoSize = True
        Me.pb_Parentese1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parentese1.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Parentese1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parentese1.BorderSize = 2
        Me.pb_Parentese1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Parentese1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Parentese1.Image = Nothing
        Me.pb_Parentese1.Location = New System.Drawing.Point(210, 176)
        Me.pb_Parentese1.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Parentese1.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Parentese1.Name = "pb_Parentese1"
        Me.pb_Parentese1.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Parentese1.Size = New System.Drawing.Size(30, 30)
        Me.pb_Parentese1.TabIndex = 2
        Me.pb_Parentese1.TabStop = False
        Me.pb_Parentese1.Tag = "("
        Me.pb_Parentese1.Text = "("
        Me.pb_Parentese1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Parentese2
        '
        Me.pb_Parentese2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Parentese2.AutoSize = True
        Me.pb_Parentese2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parentese2.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Parentese2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Parentese2.BorderSize = 2
        Me.pb_Parentese2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Parentese2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Parentese2.Image = Nothing
        Me.pb_Parentese2.Location = New System.Drawing.Point(260, 176)
        Me.pb_Parentese2.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Parentese2.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Parentese2.Name = "pb_Parentese2"
        Me.pb_Parentese2.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Parentese2.Size = New System.Drawing.Size(30, 30)
        Me.pb_Parentese2.TabIndex = 2
        Me.pb_Parentese2.TabStop = False
        Me.pb_Parentese2.Tag = ")"
        Me.pb_Parentese2.Text = ")"
        Me.pb_Parentese2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Egal
        '
        Me.pb_Egal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Egal.AutoSize = True
        Me.pb_Egal.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Egal.Border = RHP.ud_button.BorderStyle.All
        Me.pb_Egal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pb_Egal.BorderSize = 2
        Me.pb_Egal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Egal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pb_Egal.Image = Nothing
        Me.pb_Egal.Location = New System.Drawing.Point(310, 176)
        Me.pb_Egal.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Egal.MinimumSize = New System.Drawing.Size(30, 30)
        Me.pb_Egal.Name = "pb_Egal"
        Me.pb_Egal.Padding = New System.Windows.Forms.Padding(2)
        Me.pb_Egal.Size = New System.Drawing.Size(30, 30)
        Me.pb_Egal.TabIndex = 2
        Me.pb_Egal.TabStop = False
        Me.pb_Egal.Tag = "="
        Me.pb_Egal.Text = "="
        Me.pb_Egal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Zoom_Rubrique_Relation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(562, 243)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.ent_pnl)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Rubrique_Relation"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtre Avancé"
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Personnal_pnl.PerformLayout()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Zone_txt As RichTextBox
    Friend WithEvents btn_Egal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btn_Parentese2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btn_Parentese1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btn_Devision As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btn_Fois As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Tx_pb As ud_button
    Friend WithEvents Base_pb As ud_button
    Friend WithEvents Nb_pb As ud_button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pb_Plus As ud_button
    Friend WithEvents pb_Moins As ud_button
    Friend WithEvents pb_Fois As ud_button
    Friend WithEvents pb_Division As ud_button
    Friend WithEvents pb_Parentese1 As ud_button
    Friend WithEvents pb_Parentese2 As ud_button
    Friend WithEvents pb_Egal As ud_button
End Class
