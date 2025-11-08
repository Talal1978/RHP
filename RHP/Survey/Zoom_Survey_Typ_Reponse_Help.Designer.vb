<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Survey_Typ_Reponse_Help
    inherits Ecran

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Zoom_Survey_Typ_Reponse_Help))
        Me.Lv = New System.Windows.Forms.ListView()
        Me.Exemple_rtb = New System.Windows.Forms.RichTextBox()
        Me.rg_txt = New RHP.ud_TextBox()
        Me.Explication_rtb = New System.Windows.Forms.RichTextBox()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.Regex_lbl = New System.Windows.Forms.Label()
        Me.Explication_lbl = New System.Windows.Forms.Label()
        Me.Exemple_lbl = New System.Windows.Forms.Label()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.LH2 = New System.Windows.Forms.Label()
        Me.LH = New System.Windows.Forms.Label()
        Me.TypReponse_lbl = New System.Windows.Forms.Label()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl.SuspendLayout()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lv
        '
        Me.Lv.Dock = System.Windows.Forms.DockStyle.Left
        Me.Lv.HideSelection = False
        Me.Lv.Location = New System.Drawing.Point(0, 0)
        Me.Lv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lv.Name = "Lv"
        Me.Lv.Size = New System.Drawing.Size(303, 504)
        Me.Lv.TabIndex = 1
        Me.Lv.UseCompatibleStateImageBehavior = False
        Me.Lv.View = System.Windows.Forms.View.List
        '
        'Exemple_rtb
        '
        Me.Exemple_rtb.BackColor = System.Drawing.SystemColors.Window
        Me.Exemple_rtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Exemple_rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Exemple_rtb.Location = New System.Drawing.Point(303, 369)
        Me.Exemple_rtb.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Exemple_rtb.Name = "Exemple_rtb"
        Me.Exemple_rtb.Size = New System.Drawing.Size(482, 135)
        Me.Exemple_rtb.TabIndex = 2
        Me.Exemple_rtb.Text = ""
        '
        'rg_txt
        '
        Me.rg_txt.BackColor = System.Drawing.SystemColors.Window
        Me.rg_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.rg_txt.Dock = System.Windows.Forms.DockStyle.Top
        Me.rg_txt.Location = New System.Drawing.Point(303, 51)
        Me.rg_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rg_txt.MaxLength = 32767
        Me.rg_txt.Multiline = True
        Me.rg_txt.Name = "rg_txt"
        Me.rg_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.rg_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.rg_txt.ReadOnly = False
        Me.rg_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.rg_txt.SelectionStart = 0
        Me.rg_txt.Size = New System.Drawing.Size(482, 101)
        Me.rg_txt.TabIndex = 3
        Me.rg_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.rg_txt.UseSystemPasswordChar = False
        '
        'Explication_rtb
        '
        Me.Explication_rtb.BackColor = System.Drawing.SystemColors.Window
        Me.Explication_rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Explication_rtb.Dock = System.Windows.Forms.DockStyle.Top
        Me.Explication_rtb.Location = New System.Drawing.Point(303, 183)
        Me.Explication_rtb.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Explication_rtb.Name = "Explication_rtb"
        Me.Explication_rtb.Size = New System.Drawing.Size(482, 155)
        Me.Explication_rtb.TabIndex = 4
        Me.Explication_rtb.Text = ""
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "right.png")
        '
        'Regex_lbl
        '
        Me.Regex_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Regex_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Regex_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Regex_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Regex_lbl.Location = New System.Drawing.Point(303, 0)
        Me.Regex_lbl.MinimumSize = New System.Drawing.Size(0, 25)
        Me.Regex_lbl.Name = "Regex_lbl"
        Me.Regex_lbl.Size = New System.Drawing.Size(482, 30)
        Me.Regex_lbl.TabIndex = 0
        Me.Regex_lbl.Text = "Regex"
        Me.Regex_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Explication_lbl
        '
        Me.Explication_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Explication_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Explication_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Explication_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Explication_lbl.Location = New System.Drawing.Point(303, 152)
        Me.Explication_lbl.MinimumSize = New System.Drawing.Size(0, 25)
        Me.Explication_lbl.Name = "Explication_lbl"
        Me.Explication_lbl.Size = New System.Drawing.Size(482, 30)
        Me.Explication_lbl.TabIndex = 51
        Me.Explication_lbl.Text = "Explication"
        Me.Explication_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Exemple_lbl
        '
        Me.Exemple_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Exemple_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Exemple_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exemple_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Exemple_lbl.Location = New System.Drawing.Point(303, 338)
        Me.Exemple_lbl.MinimumSize = New System.Drawing.Size(0, 25)
        Me.Exemple_lbl.Name = "Exemple_lbl"
        Me.Exemple_lbl.Size = New System.Drawing.Size(482, 30)
        Me.Exemple_lbl.TabIndex = 52
        Me.Exemple_lbl.Text = "Exemple de démonstration"
        Me.Exemple_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pnl
        '
        Me.Pnl.Controls.Add(Me.Exemple_rtb)
        Me.Pnl.Controls.Add(Me.LH2)
        Me.Pnl.Controls.Add(Me.Exemple_lbl)
        Me.Pnl.Controls.Add(Me.Explication_rtb)
        Me.Pnl.Controls.Add(Me.LH)
        Me.Pnl.Controls.Add(Me.Explication_lbl)
        Me.Pnl.Controls.Add(Me.rg_txt)
        Me.Pnl.Controls.Add(Me.TypReponse_lbl)
        Me.Pnl.Controls.Add(Me.Regex_lbl)
        Me.Pnl.Controls.Add(Me.Lv)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 37)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(785, 504)
        Me.Pnl.TabIndex = 53
        '
        'LH2
        '
        Me.LH2.Dock = System.Windows.Forms.DockStyle.Top
        Me.LH2.Location = New System.Drawing.Point(303, 368)
        Me.LH2.Name = "LH2"
        Me.LH2.Size = New System.Drawing.Size(482, 1)
        Me.LH2.TabIndex = 54
        '
        'LH
        '
        Me.LH.Dock = System.Windows.Forms.DockStyle.Top
        Me.LH.Location = New System.Drawing.Point(303, 182)
        Me.LH.Name = "LH"
        Me.LH.Size = New System.Drawing.Size(482, 1)
        Me.LH.TabIndex = 53
        '
        'TypReponse_lbl
        '
        Me.TypReponse_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TypReponse_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.TypReponse_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TypReponse_lbl.Location = New System.Drawing.Point(303, 30)
        Me.TypReponse_lbl.Name = "TypReponse_lbl"
        Me.TypReponse_lbl.Size = New System.Drawing.Size(482, 21)
        Me.TypReponse_lbl.TabIndex = 55
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 3
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 2, 0)
        Me.Personnal_pnl.Controls.Add(Me.Label1, 1, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(785, 35)
        Me.Personnal_pnl.TabIndex = 213
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(3, 3)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(24, 29)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Save_pb.TabIndex = 10
        Me.Save_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(758, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 29)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 8
        Me.Close_pb.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(33, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(719, 35)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Aide sur les types de réponses"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Zoom_Survey_Typ_Reponse_Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(789, 543)
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Zoom_Survey_Typ_Reponse_Help"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aide sur les types de réponses"
        Me.Pnl.ResumeLayout(False)
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lv As ListView
    Friend WithEvents Exemple_rtb As RichTextBox
    Friend WithEvents rg_txt As ud_TextBox
    Friend WithEvents Explication_rtb As RichTextBox
    Friend WithEvents imgList As ImageList
    Friend WithEvents Regex_lbl As Label
    Friend WithEvents Explication_lbl As Label
    Friend WithEvents Exemple_lbl As Label
    Friend WithEvents Pnl As Panel
    Friend WithEvents LH2 As Label
    Friend WithEvents LH As Label
    Friend WithEvents TypReponse_lbl As Label
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
End Class
