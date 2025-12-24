<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_InputBox
    Inherits Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ud_InputBox))
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.tblPnl = New System.Windows.Forms.TableLayoutPanel()
        Me.pb_Msg = New System.Windows.Forms.PictureBox()
        Me.btn_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Msg_txt = New System.Windows.Forms.Label()
        Me.Annuler_ud = New RHP.ud_button()
        Me.Ok_ud = New RHP.ud_button()
        Me.inputBox_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tblPnl.SuspendLayout()
        CType(Me.pb_Msg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btn_pnl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.tblPnl.SetColumnSpan(Me.Titre_lbl, 2)
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(0)
        Me.Titre_lbl.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(490, 31)
        Me.Titre_lbl.TabIndex = 240
        Me.Titre_lbl.Text = "Message"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tblPnl
        '
        Me.tblPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tblPnl.ColumnCount = 2
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 396.0!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblPnl.Controls.Add(Me.Titre_lbl, 0, 0)
        Me.tblPnl.Controls.Add(Me.pb_Msg, 1, 1)
        Me.tblPnl.Controls.Add(Me.btn_pnl, 0, 2)
        Me.tblPnl.Controls.Add(Me.Panel1, 0, 1)
        Me.tblPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPnl.Location = New System.Drawing.Point(2, 2)
        Me.tblPnl.Margin = New System.Windows.Forms.Padding(0)
        Me.tblPnl.Name = "tblPnl"
        Me.tblPnl.RowCount = 3
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.tblPnl.Size = New System.Drawing.Size(490, 180)
        Me.tblPnl.TabIndex = 241
        '
        'pb_Msg
        '
        Me.pb_Msg.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Msg.Image = CType(resources.GetObject("pb_Msg.Image"), System.Drawing.Image)
        Me.pb_Msg.Location = New System.Drawing.Point(403, 41)
        Me.pb_Msg.Margin = New System.Windows.Forms.Padding(0)
        Me.pb_Msg.MaximumSize = New System.Drawing.Size(80, 80)
        Me.pb_Msg.MinimumSize = New System.Drawing.Size(80, 80)
        Me.pb_Msg.Name = "pb_Msg"
        Me.pb_Msg.Size = New System.Drawing.Size(80, 80)
        Me.pb_Msg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_Msg.TabIndex = 241
        Me.pb_Msg.TabStop = False
        '
        'btn_pnl
        '
        Me.btn_pnl.ColumnCount = 3
        Me.tblPnl.SetColumnSpan(Me.btn_pnl, 2)
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.btn_pnl.Controls.Add(Me.Annuler_ud, 0, 0)
        Me.btn_pnl.Controls.Add(Me.Ok_ud, 2, 0)
        Me.btn_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_pnl.Location = New System.Drawing.Point(0, 131)
        Me.btn_pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_pnl.Name = "btn_pnl"
        Me.btn_pnl.RowCount = 1
        Me.btn_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.btn_pnl.Size = New System.Drawing.Size(490, 49)
        Me.btn_pnl.TabIndex = 242
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Msg_txt)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.inputBox_txt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 94)
        Me.Panel1.TabIndex = 243
        '
        'Msg_txt
        '
        Me.Msg_txt.BackColor = System.Drawing.Color.White
        Me.Msg_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Msg_txt.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Msg_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Msg_txt.Location = New System.Drawing.Point(0, 0)
        Me.Msg_txt.Margin = New System.Windows.Forms.Padding(3, 3, 3, 50)
        Me.Msg_txt.MaximumSize = New System.Drawing.Size(400, 0)
        Me.Msg_txt.Name = "Msg_txt"
        Me.Msg_txt.Size = New System.Drawing.Size(390, 58)
        Me.Msg_txt.TabIndex = 235
        '
        'Annuler_ud
        '
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.bgColor = System.Drawing.Color.White
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.isDefault = False
        Me.Annuler_ud.Location = New System.Drawing.Point(5, 5)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(5)
        Me.Annuler_ud.MaximumSize = New System.Drawing.Size(100, 33)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(100, 33)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(100, 33)
        Me.Annuler_ud.TabIndex = 240
        Me.Annuler_ud.Text = "Annuler"
        '
        'Ok_ud
        '
        Me.Ok_ud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ok_ud.AutoSize = True
        Me.Ok_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ok_ud.bgColor = System.Drawing.Color.White
        Me.Ok_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Ok_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ok_ud.BorderSize = 2
        Me.Ok_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ok_ud.Image = Global.RHP.My.Resources.Resources.btn_yes
        Me.Ok_ud.isDefault = False
        Me.Ok_ud.Location = New System.Drawing.Point(385, 5)
        Me.Ok_ud.Margin = New System.Windows.Forms.Padding(5)
        Me.Ok_ud.MaximumSize = New System.Drawing.Size(100, 33)
        Me.Ok_ud.MinimumSize = New System.Drawing.Size(100, 33)
        Me.Ok_ud.Name = "Ok_ud"
        Me.Ok_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Ok_ud.Size = New System.Drawing.Size(100, 33)
        Me.Ok_ud.TabIndex = 239
        Me.Ok_ud.Text = "OK"
        '
        'inputBox_txt
        '
        Me.inputBox_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.inputBox_txt.ContextMenuStrip = Nothing
        Me.inputBox_txt.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.inputBox_txt.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputBox_txt.Location = New System.Drawing.Point(0, 60)
        Me.inputBox_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.inputBox_txt.MaxLength = 32767
        Me.inputBox_txt.Multiline = False
        Me.inputBox_txt.Name = "inputBox_txt"
        Me.inputBox_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.inputBox_txt.ReadOnly = False
        Me.inputBox_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.inputBox_txt.SelectionStart = 0
        Me.inputBox_txt.Size = New System.Drawing.Size(390, 34)
        Me.inputBox_txt.TabIndex = 241
        Me.inputBox_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.inputBox_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 58)
        Me.Label1.MaximumSize = New System.Drawing.Size(0, 2)
        Me.Label1.MinimumSize = New System.Drawing.Size(5, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 2)
        Me.Label1.TabIndex = 242
        '
        'ud_InputBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(494, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.tblPnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(360, 146)
        Me.Name = "ud_InputBox"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Message"
        Me.tblPnl.ResumeLayout(False)
        CType(Me.pb_Msg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btn_pnl.ResumeLayout(False)
        Me.btn_pnl.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ok_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents tblPnl As TableLayoutPanel
    Friend WithEvents pb_Msg As PictureBox
    Friend WithEvents btn_pnl As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Msg_txt As Label
    Friend WithEvents inputBox_txt As ud_TextBox
    Friend WithEvents Label1 As Label
End Class
