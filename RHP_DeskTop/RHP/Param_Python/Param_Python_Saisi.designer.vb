<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Param_Python_Saisi
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Arguments_Grd = New RHP.ud_Grd()
        Me.Argument = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Argument = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fonction_Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Result_txt = New RHP.ud_TextBox()
        Me.DockSite2 = New DevComponents.DotNetBar.DockSite()
        Me.oPnl = New DevComponents.DotNetBar.PanelDockContainer()
        Me.pBar = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.entpnl = New System.Windows.Forms.TableLayoutPanel()
        Me.python_pb = New System.Windows.Forms.PictureBox()
        Me.Nom_Python_txt = New RHP.ud_TextBox()
        Me.Cod_Python_txt = New RHP.ud_TextBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Run_pb = New System.Windows.Forms.PictureBox()
        CType(Me.Arguments_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.entpnl.SuspendLayout()
        CType(Me.python_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Run_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(105, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Traitement :"
        '
        'Arguments_Grd
        '
        Me.Arguments_Grd.AfficherLesEntetesLignes = True
        Me.Arguments_Grd.AllowUserToAddRows = False
        Me.Arguments_Grd.AlternerLesLignes = False
        Me.Arguments_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Arguments_Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Arguments_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Arguments_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Arguments_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Arguments_Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Argument, Me.Lib_Argument, Me.Valeur, Me.Fonction_Critere, Me.Typ_Critere})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Arguments_Grd.DefaultCellStyle = DataGridViewCellStyle2
        Me.Arguments_Grd.Dock = System.Windows.Forms.DockStyle.Top
        Me.Arguments_Grd.EnableHeadersVisualStyles = False
        Me.Arguments_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Arguments_Grd.Location = New System.Drawing.Point(0, 38)
        Me.Arguments_Grd.Name = "Arguments_Grd"
        Me.Arguments_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Arguments_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Arguments_Grd.RowHeadersVisible = False
        Me.Arguments_Grd.RowHeadersWidth = 51
        Me.Arguments_Grd.Size = New System.Drawing.Size(1129, 242)
        Me.Arguments_Grd.TabIndex = 82
        '
        'Argument
        '
        Me.Argument.HeaderText = "Code Critère"
        Me.Argument.MinimumWidth = 200
        Me.Argument.Name = "Argument"
        Me.Argument.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Argument.Visible = False
        Me.Argument.Width = 200
        '
        'Lib_Argument
        '
        Me.Lib_Argument.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Lib_Argument.HeaderText = "Argument"
        Me.Lib_Argument.MinimumWidth = 6
        Me.Lib_Argument.Name = "Lib_Argument"
        Me.Lib_Argument.ReadOnly = True
        Me.Lib_Argument.Width = 114
        '
        'Valeur
        '
        Me.Valeur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.MinimumWidth = 400
        Me.Valeur.Name = "Valeur"
        Me.Valeur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Valeur.Width = 400
        '
        'Fonction_Critere
        '
        Me.Fonction_Critere.HeaderText = "Fonction_Critere"
        Me.Fonction_Critere.MinimumWidth = 6
        Me.Fonction_Critere.Name = "Fonction_Critere"
        Me.Fonction_Critere.Visible = False
        Me.Fonction_Critere.Width = 125
        '
        'Typ_Critere
        '
        Me.Typ_Critere.HeaderText = "Typ_Critere"
        Me.Typ_Critere.MinimumWidth = 6
        Me.Typ_Critere.Name = "Typ_Critere"
        Me.Typ_Critere.Visible = False
        Me.Typ_Critere.Width = 125
        '
        'Result_txt
        '
        Me.Result_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Result_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Result_txt.ContextMenuStrip = Nothing
        Me.Result_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Result_txt.Location = New System.Drawing.Point(0, 23)
        Me.Result_txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Result_txt.MaxLength = 32767
        Me.Result_txt.Multiline = True
        Me.Result_txt.Name = "Result_txt"
        Me.Result_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Result_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Result_txt.ReadOnly = True
        Me.Result_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Result_txt.SelectionStart = 0
        Me.Result_txt.Size = New System.Drawing.Size(1129, 403)
        Me.Result_txt.TabIndex = 80
        Me.Result_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Result_txt.UseSystemPasswordChar = False
        '
        'DockSite2
        '
        Me.DockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite2.Location = New System.Drawing.Point(662, 0)
        Me.DockSite2.Name = "DockSite2"
        Me.DockSite2.Size = New System.Drawing.Size(0, 437)
        Me.DockSite2.TabIndex = 5
        Me.DockSite2.TabStop = False
        '
        'oPnl
        '
        Me.oPnl.Location = New System.Drawing.Point(3, 23)
        Me.oPnl.Name = "oPnl"
        Me.oPnl.Size = New System.Drawing.Size(199, 443)
        Me.oPnl.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.oPnl.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.oPnl.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.oPnl.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.oPnl.Style.GradientAngle = 90
        Me.oPnl.TabIndex = 0
        '
        'pBar
        '
        Me.pBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pBar.Location = New System.Drawing.Point(0, 0)
        Me.pBar.MarqueeAnimationSpeed = 1
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(1129, 23)
        Me.pBar.Step = 1
        Me.pBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pBar.TabIndex = 83
        Me.pBar.Value = 50
        Me.pBar.Visible = False
        '
        'BackgroundWorker1
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Result_txt)
        Me.Panel1.Controls.Add(Me.pBar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 280)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1129, 426)
        Me.Panel1.TabIndex = 84
        '
        'entpnl
        '
        Me.entpnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.entpnl.ColumnCount = 5
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 312.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.entpnl.Controls.Add(Me.python_pb, 2, 0)
        Me.entpnl.Controls.Add(Me.Nom_Python_txt, 1, 0)
        Me.entpnl.Controls.Add(Me.Cod_Python_txt, 0, 0)
        Me.entpnl.Controls.Add(Me.Close_pb, 4, 0)
        Me.entpnl.Controls.Add(Me.Run_pb, 3, 0)
        Me.entpnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.entpnl.Location = New System.Drawing.Point(0, 0)
        Me.entpnl.Margin = New System.Windows.Forms.Padding(4)
        Me.entpnl.Name = "entpnl"
        Me.entpnl.RowCount = 1
        Me.entpnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entpnl.Size = New System.Drawing.Size(1129, 38)
        Me.entpnl.TabIndex = 86
        '
        'python_pb
        '
        Me.python_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.python_pb.Image = Global.RHP.My.Resources.Resources.btn_python_w
        Me.python_pb.InitialImage = Nothing
        Me.python_pb.Location = New System.Drawing.Point(1019, 4)
        Me.python_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.python_pb.Name = "python_pb"
        Me.python_pb.Size = New System.Drawing.Size(30, 25)
        Me.python_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.python_pb.TabIndex = 14
        Me.python_pb.TabStop = False
        '
        'Nom_Python_txt
        '
        Me.Nom_Python_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Python_txt.ContextMenuStrip = Nothing
        Me.Nom_Python_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Nom_Python_txt.Location = New System.Drawing.Point(316, 5)
        Me.Nom_Python_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_Python_txt.MaxLength = 32767
        Me.Nom_Python_txt.Multiline = False
        Me.Nom_Python_txt.Name = "Nom_Python_txt"
        Me.Nom_Python_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Python_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Python_txt.ReadOnly = True
        Me.Nom_Python_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Python_txt.SelectionStart = 0
        Me.Nom_Python_txt.Size = New System.Drawing.Size(695, 28)
        Me.Nom_Python_txt.TabIndex = 12
        Me.Nom_Python_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Python_txt.UseSystemPasswordChar = False
        '
        'Cod_Python_txt
        '
        Me.Cod_Python_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Python_txt.ContextMenuStrip = Nothing
        Me.Cod_Python_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cod_Python_txt.Location = New System.Drawing.Point(4, 6)
        Me.Cod_Python_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Cod_Python_txt.MaxLength = 32767
        Me.Cod_Python_txt.Multiline = False
        Me.Cod_Python_txt.Name = "Cod_Python_txt"
        Me.Cod_Python_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Python_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Python_txt.ReadOnly = True
        Me.Cod_Python_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Python_txt.SelectionStart = 0
        Me.Cod_Python_txt.Size = New System.Drawing.Size(304, 26)
        Me.Cod_Python_txt.TabIndex = 12
        Me.Cod_Python_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Python_txt.UseSystemPasswordChar = False
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(1095, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(30, 25)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 13
        Me.Close_pb.TabStop = False
        '
        'Run_pb
        '
        Me.Run_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Run_pb.Image = Global.RHP.My.Resources.Resources.btn_netToBrut_w
        Me.Run_pb.InitialImage = Nothing
        Me.Run_pb.Location = New System.Drawing.Point(1057, 4)
        Me.Run_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Run_pb.Name = "Run_pb"
        Me.Run_pb.Size = New System.Drawing.Size(30, 25)
        Me.Run_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Run_pb.TabIndex = 11
        Me.Run_pb.TabStop = False
        '
        'Param_Python_Saisi
        '
        Me.ClientSize = New System.Drawing.Size(1129, 706)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Arguments_Grd)
        Me.Controls.Add(Me.entpnl)
        Me.DoubleBuffered = True
        Me.Name = "Param_Python_Saisi"
        Me.Tag = ""
        CType(Me.Arguments_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.entpnl.ResumeLayout(False)
        CType(Me.python_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Run_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Arguments_Grd As ud_Grd
    Friend WithEvents DockSite2 As DevComponents.DotNetBar.DockSite
    Friend WithEvents oPnl As DevComponents.DotNetBar.PanelDockContainer
    Friend WithEvents Result_txt As ud_TextBox
    Friend WithEvents Argument As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Argument As DataGridViewTextBoxColumn
    Friend WithEvents Valeur As DataGridViewTextBoxColumn
    Friend WithEvents Fonction_Critere As DataGridViewTextBoxColumn
    Friend WithEvents Typ_Critere As DataGridViewTextBoxColumn
    Friend WithEvents pBar As ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents entpnl As TableLayoutPanel
    Friend WithEvents Run_pb As PictureBox
    Friend WithEvents Nom_Python_txt As ud_TextBox
    Friend WithEvents Cod_Python_txt As ud_TextBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents python_pb As PictureBox
End Class
