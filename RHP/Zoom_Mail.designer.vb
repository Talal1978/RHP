<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Mail
    Inherits Ecran

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.To_Text = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Object_Text = New RHP.ud_TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Text_Text = New RHP.ud_TextBox()
        Me.PJ_List = New System.Windows.Forms.ListView()
        Me.CC_Text = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Reply_To_Text = New RHP.ud_TextBox()
        Me.From_Lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CCi_Text = New RHP.ud_TextBox()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Envoyer_pb = New System.Windows.Forms.PictureBox()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Ud_Panel1 = New RHP.ud_Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PJ_pb = New System.Windows.Forms.PictureBox()
        Me.Cc_lbl = New System.Windows.Forms.Label()
        Me.Attn_lbl = New System.Windows.Forms.Label()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Envoyer_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl.SuspendLayout()
        Me.Ud_Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PJ_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'To_Text
        '
        Me.To_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.To_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_Text.Location = New System.Drawing.Point(87, 30)
        Me.To_Text.MaxLength = 32767
        Me.To_Text.Multiline = False
        Me.To_Text.Name = "To_Text"
        Me.To_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.To_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.To_Text.ReadOnly = False
        Me.To_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.To_Text.SelectionStart = 0
        Me.To_Text.Size = New System.Drawing.Size(687, 20)
        Me.To_Text.TabIndex = 0
        Me.To_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.To_Text.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(51, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "De "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(45, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Objet"
        '
        'Object_Text
        '
        Me.Object_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Object_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Object_Text.Location = New System.Drawing.Point(87, 99)
        Me.Object_Text.MaxLength = 32767
        Me.Object_Text.Multiline = False
        Me.Object_Text.Name = "Object_Text"
        Me.Object_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Object_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Object_Text.ReadOnly = False
        Me.Object_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Object_Text.SelectionStart = 0
        Me.Object_Text.Size = New System.Drawing.Size(687, 20)
        Me.Object_Text.TabIndex = 4
        Me.Object_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Object_Text.UseSystemPasswordChar = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Text_Text
        '
        Me.Text_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Text_Text.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Text_Text.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Text.Location = New System.Drawing.Point(3, 3)
        Me.Text_Text.MaxLength = 32767
        Me.Text_Text.Multiline = True
        Me.Text_Text.Name = "Text_Text"
        Me.Text_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Text_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Text_Text.ReadOnly = False
        Me.Text_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Text_Text.SelectionStart = 0
        Me.Text_Text.Size = New System.Drawing.Size(776, 281)
        Me.Text_Text.TabIndex = 207
        Me.Text_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Text_Text.UseSystemPasswordChar = False
        '
        'PJ_List
        '
        Me.PJ_List.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PJ_List.HideSelection = False
        Me.PJ_List.Location = New System.Drawing.Point(3, 3)
        Me.PJ_List.Name = "PJ_List"
        Me.PJ_List.Size = New System.Drawing.Size(746, 80)
        Me.PJ_List.TabIndex = 208
        Me.PJ_List.UseCompatibleStateImageBehavior = False
        Me.PJ_List.View = System.Windows.Forms.View.SmallIcon
        '
        'CC_Text
        '
        Me.CC_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CC_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CC_Text.Location = New System.Drawing.Point(87, 53)
        Me.CC_Text.MaxLength = 32767
        Me.CC_Text.Multiline = False
        Me.CC_Text.Name = "CC_Text"
        Me.CC_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.CC_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CC_Text.ReadOnly = False
        Me.CC_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.CC_Text.SelectionStart = 0
        Me.CC_Text.Size = New System.Drawing.Size(687, 20)
        Me.CC_Text.TabIndex = 209
        Me.CC_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CC_Text.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(9, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 212
        Me.Label5.Text = "Répondre à"
        '
        'Reply_To_Text
        '
        Me.Reply_To_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Reply_To_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reply_To_Text.Location = New System.Drawing.Point(87, 76)
        Me.Reply_To_Text.MaxLength = 32767
        Me.Reply_To_Text.Multiline = False
        Me.Reply_To_Text.Name = "Reply_To_Text"
        Me.Reply_To_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Reply_To_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Reply_To_Text.ReadOnly = False
        Me.Reply_To_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Reply_To_Text.SelectionStart = 0
        Me.Reply_To_Text.Size = New System.Drawing.Size(265, 20)
        Me.Reply_To_Text.TabIndex = 211
        Me.Reply_To_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Reply_To_Text.UseSystemPasswordChar = False
        '
        'From_Lbl
        '
        Me.From_Lbl.AutoSize = True
        Me.From_Lbl.Location = New System.Drawing.Point(91, 10)
        Me.From_Lbl.Name = "From_Lbl"
        Me.From_Lbl.Size = New System.Drawing.Size(0, 13)
        Me.From_Lbl.TabIndex = 213
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(353, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 217
        Me.Label1.Text = "CCi"
        '
        'CCi_Text
        '
        Me.CCi_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CCi_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CCi_Text.Location = New System.Drawing.Point(383, 76)
        Me.CCi_Text.MaxLength = 32767
        Me.CCi_Text.Multiline = False
        Me.CCi_Text.Name = "CCi_Text"
        Me.CCi_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.CCi_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CCi_Text.ReadOnly = False
        Me.CCi_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.CCi_Text.SelectionStart = 0
        Me.CCi_Text.Size = New System.Drawing.Size(391, 20)
        Me.CCi_Text.TabIndex = 216
        Me.CCi_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CCi_Text.UseSystemPasswordChar = False
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 3
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 2, 0)
        Me.Personnal_pnl.Controls.Add(Me.Label4, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.Envoyer_pb, 0, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(782, 35)
        Me.Personnal_pnl.TabIndex = 218
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(755, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 29)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 8
        Me.Close_pb.TabStop = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(38, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(711, 35)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Envoi de mail"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Envoyer_pb
        '
        Me.Envoyer_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Envoyer_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Envoyer_pb.Image = Global.RHP.My.Resources.Resources.btn_mail
        Me.Envoyer_pb.InitialImage = Nothing
        Me.Envoyer_pb.Location = New System.Drawing.Point(3, 3)
        Me.Envoyer_pb.Name = "Envoyer_pb"
        Me.Envoyer_pb.Size = New System.Drawing.Size(29, 29)
        Me.Envoyer_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Envoyer_pb.TabIndex = 8
        Me.Envoyer_pb.TabStop = False
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Ud_Panel1)
        Me.Pnl.Controls.Add(Me.TableLayoutPanel2)
        Me.Pnl.Controls.Add(Me.Label1)
        Me.Pnl.Controls.Add(Me.CCi_Text)
        Me.Pnl.Controls.Add(Me.From_Lbl)
        Me.Pnl.Controls.Add(Me.Cc_lbl)
        Me.Pnl.Controls.Add(Me.Attn_lbl)
        Me.Pnl.Controls.Add(Me.Label5)
        Me.Pnl.Controls.Add(Me.Reply_To_Text)
        Me.Pnl.Controls.Add(Me.CC_Text)
        Me.Pnl.Controls.Add(Me.Label3)
        Me.Pnl.Controls.Add(Me.Object_Text)
        Me.Pnl.Controls.Add(Me.Label2)
        Me.Pnl.Controls.Add(Me.To_Text)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Pnl.Location = New System.Drawing.Point(2, 37)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(782, 504)
        Me.Pnl.TabIndex = 219
        '
        'Ud_Panel1
        '
        Me.Ud_Panel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel1.BorderSize = 2
        Me.Ud_Panel1.Controls.Add(Me.Text_Text)
        Me.Ud_Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Ud_Panel1.Location = New System.Drawing.Point(0, 131)
        Me.Ud_Panel1.Name = "Ud_Panel1"
        Me.Ud_Panel1.Padding = New System.Windows.Forms.Padding(3)
        Me.Ud_Panel1.Size = New System.Drawing.Size(782, 287)
        Me.Ud_Panel1.TabIndex = 219
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PJ_pb, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PJ_List, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 418)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(782, 86)
        Me.TableLayoutPanel2.TabIndex = 218
        '
        'PJ_pb
        '
        Me.PJ_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PJ_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PJ_pb.Image = Global.RHP.My.Resources.Resources.btn_clip
        Me.PJ_pb.InitialImage = Nothing
        Me.PJ_pb.Location = New System.Drawing.Point(755, 3)
        Me.PJ_pb.Name = "PJ_pb"
        Me.PJ_pb.Size = New System.Drawing.Size(24, 80)
        Me.PJ_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PJ_pb.TabIndex = 209
        Me.PJ_pb.TabStop = False
        '
        'Cc_lbl
        '
        Me.Cc_lbl.AutoSize = True
        Me.Cc_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cc_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cc_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Cc_lbl.Location = New System.Drawing.Point(57, 60)
        Me.Cc_lbl.Name = "Cc_lbl"
        Me.Cc_lbl.Size = New System.Drawing.Size(26, 13)
        Me.Cc_lbl.TabIndex = 212
        Me.Cc_lbl.Text = "Cc "
        '
        'Attn_lbl
        '
        Me.Attn_lbl.AutoSize = True
        Me.Attn_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Attn_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Attn_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Attn_lbl.Location = New System.Drawing.Point(49, 32)
        Me.Attn_lbl.Name = "Attn_lbl"
        Me.Attn_lbl.Size = New System.Drawing.Size(34, 13)
        Me.Attn_lbl.TabIndex = 212
        Me.Attn_lbl.Text = "Attn "
        '
        'Zoom_Mail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(786, 543)
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Mail"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envoyer un Mail :"
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Envoyer_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        Me.Ud_Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PJ_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents To_Text As ud_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Object_Text As ud_TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Text_Text As ud_TextBox
    Friend WithEvents PJ_List As System.Windows.Forms.ListView
    Friend WithEvents CC_Text As ud_TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Reply_To_Text As ud_TextBox
    Friend WithEvents From_Lbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CCi_Text As ud_TextBox
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Pnl As Panel
    Friend WithEvents Envoyer_pb As PictureBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents PJ_pb As PictureBox
    Friend WithEvents Attn_lbl As Label
    Friend WithEvents Cc_lbl As Label
    Friend WithEvents Ud_Panel1 As ud_Panel
End Class
