<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Messagerie
    Inherits Ecran

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Mail_Addr_Text = New RHP.ud_TextBox()
        Me.CheminNet = New System.Windows.Forms.Label()
        Me.Pwd_Mail_Text = New RHP.ud_TextBox()
        Me.Nom_Prenom_Text = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Smtp_Mail_Text = New RHP.ud_TextBox()
        Me.Ssl_Actif = New RHP.ud_CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Port_Mail = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Mail_From_Text = New RHP.ud_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Test_Mail_Text = New RHP.ud_TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.TestMail_pb = New System.Windows.Forms.PictureBox()
        Me.Del_pb = New System.Windows.Forms.PictureBox()
        Me.New_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Port_Mail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestMail_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Del_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Mail_Addr_Text
        '
        Me.Mail_Addr_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Mail_Addr_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Mail_Addr_Text.Location = New System.Drawing.Point(222, 4)
        Me.Mail_Addr_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Mail_Addr_Text.MaxLength = 32767
        Me.Mail_Addr_Text.Multiline = False
        Me.Mail_Addr_Text.Name = "Mail_Addr_Text"
        Me.Mail_Addr_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Mail_Addr_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Mail_Addr_Text.ReadOnly = False
        Me.Mail_Addr_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mail_Addr_Text.SelectionStart = 0
        Me.Mail_Addr_Text.Size = New System.Drawing.Size(336, 21)
        Me.Mail_Addr_Text.TabIndex = 2
        Me.Mail_Addr_Text.Tag = " "
        Me.Mail_Addr_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Mail_Addr_Text.UseSystemPasswordChar = False
        '
        'CheminNet
        '
        Me.CheminNet.AutoSize = True
        Me.CheminNet.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.CheminNet.Location = New System.Drawing.Point(6, 8)
        Me.CheminNet.Name = "CheminNet"
        Me.CheminNet.Size = New System.Drawing.Size(209, 16)
        Me.CheminNet.TabIndex = 3
        Me.CheminNet.Text = "Adresse Messagerie d'Authentification"
        '
        'Pwd_Mail_Text
        '
        Me.Pwd_Mail_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Pwd_Mail_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Pwd_Mail_Text.Location = New System.Drawing.Point(222, 28)
        Me.Pwd_Mail_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Pwd_Mail_Text.MaxLength = 32767
        Me.Pwd_Mail_Text.Multiline = False
        Me.Pwd_Mail_Text.Name = "Pwd_Mail_Text"
        Me.Pwd_Mail_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Pwd_Mail_Text.PasswordChar = "●"
        Me.Pwd_Mail_Text.ReadOnly = False
        Me.Pwd_Mail_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Pwd_Mail_Text.SelectionStart = 0
        Me.Pwd_Mail_Text.Size = New System.Drawing.Size(336, 21)
        Me.Pwd_Mail_Text.TabIndex = 4
        Me.Pwd_Mail_Text.Tag = " "
        Me.Pwd_Mail_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Pwd_Mail_Text.UseSystemPasswordChar = True
        '
        'Nom_Prenom_Text
        '
        Me.Nom_Prenom_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Prenom_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Prenom_Text.Location = New System.Drawing.Point(222, 124)
        Me.Nom_Prenom_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Prenom_Text.MaxLength = 32767
        Me.Nom_Prenom_Text.Multiline = False
        Me.Nom_Prenom_Text.Name = "Nom_Prenom_Text"
        Me.Nom_Prenom_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Prenom_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Prenom_Text.ReadOnly = False
        Me.Nom_Prenom_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Prenom_Text.SelectionStart = 0
        Me.Nom_Prenom_Text.Size = New System.Drawing.Size(336, 21)
        Me.Nom_Prenom_Text.TabIndex = 4
        Me.Nom_Prenom_Text.Tag = " "
        Me.Nom_Prenom_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Prenom_Text.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(124, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nom et Prénom"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(136, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Serveur Smtp"
        '
        'Smtp_Mail_Text
        '
        Me.Smtp_Mail_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Smtp_Mail_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Smtp_Mail_Text.Location = New System.Drawing.Point(222, 51)
        Me.Smtp_Mail_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Smtp_Mail_Text.MaxLength = 32767
        Me.Smtp_Mail_Text.Multiline = False
        Me.Smtp_Mail_Text.Name = "Smtp_Mail_Text"
        Me.Smtp_Mail_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Smtp_Mail_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Smtp_Mail_Text.ReadOnly = False
        Me.Smtp_Mail_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Smtp_Mail_Text.SelectionStart = 0
        Me.Smtp_Mail_Text.Size = New System.Drawing.Size(336, 21)
        Me.Smtp_Mail_Text.TabIndex = 6
        Me.Smtp_Mail_Text.Tag = " "
        Me.Smtp_Mail_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Smtp_Mail_Text.UseSystemPasswordChar = False
        '
        'Ssl_Actif
        '
        Me.Ssl_Actif.AutoSize = True
        Me.Ssl_Actif.Checked = True
        Me.Ssl_Actif.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ssl_Actif.Location = New System.Drawing.Point(441, 78)
        Me.Ssl_Actif.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Ssl_Actif.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Ssl_Actif.MinimumSize = New System.Drawing.Size(117, 25)
        Me.Ssl_Actif.Name = "Ssl_Actif"
        Me.Ssl_Actif.Size = New System.Drawing.Size(117, 25)
        Me.Ssl_Actif.TabIndex = 13
        Me.Ssl_Actif.Text = "Ssl Actif"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(37, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Mot de passe d'Authentification"
        '
        'Port_Mail
        '
        Me.Port_Mail.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Port_Mail.Location = New System.Drawing.Point(222, 75)
        Me.Port_Mail.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.Port_Mail.Name = "Port_Mail"
        Me.Port_Mail.Size = New System.Drawing.Size(77, 21)
        Me.Port_Mail.TabIndex = 38
        Me.Port_Mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(189, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 16)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Port"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(118, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Email Expéditeur"
        '
        'Mail_From_Text
        '
        Me.Mail_From_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Mail_From_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Mail_From_Text.Location = New System.Drawing.Point(222, 100)
        Me.Mail_From_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Mail_From_Text.MaxLength = 32767
        Me.Mail_From_Text.Multiline = False
        Me.Mail_From_Text.Name = "Mail_From_Text"
        Me.Mail_From_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Mail_From_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Mail_From_Text.ReadOnly = False
        Me.Mail_From_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mail_From_Text.SelectionStart = 0
        Me.Mail_From_Text.Size = New System.Drawing.Size(336, 21)
        Me.Mail_From_Text.TabIndex = 40
        Me.Mail_From_Text.Tag = " "
        Me.Mail_From_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Mail_From_Text.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(73, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 16)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Texte du Mail d'Envoi Test"
        '
        'Test_Mail_Text
        '
        Me.Test_Mail_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Test_Mail_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Test_Mail_Text.Location = New System.Drawing.Point(222, 149)
        Me.Test_Mail_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Test_Mail_Text.MaxLength = 32767
        Me.Test_Mail_Text.Multiline = True
        Me.Test_Mail_Text.Name = "Test_Mail_Text"
        Me.Test_Mail_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Test_Mail_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Test_Mail_Text.ReadOnly = False
        Me.Test_Mail_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Test_Mail_Text.SelectionStart = 0
        Me.Test_Mail_Text.Size = New System.Drawing.Size(336, 144)
        Me.Test_Mail_Text.TabIndex = 42
        Me.Test_Mail_Text.Tag = " "
        Me.Test_Mail_Text.Text = "Bonjour," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ceci est un mail de test, proventant de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RHP." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Test_Mail_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Test_Mail_Text.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Mail_Addr_Text)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.CheminNet)
        Me.Panel1.Controls.Add(Me.Test_Mail_Text)
        Me.Panel1.Controls.Add(Me.Pwd_Mail_Text)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Nom_Prenom_Text)
        Me.Panel1.Controls.Add(Me.Mail_From_Text)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Smtp_Mail_Text)
        Me.Panel1.Controls.Add(Me.Port_Mail)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Ssl_Actif)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(608, 301)
        Me.Panel1.TabIndex = 44
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 6
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.TestMail_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Del_pb, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.New_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 5, 0)
        Me.Personnal_pnl.Controls.Add(Me.Label7, 4, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(608, 35)
        Me.Personnal_pnl.TabIndex = 209
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(63, 3)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(24, 29)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Save_pb.TabIndex = 11
        Me.Save_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Save_pb, "Enregistrer")
        '
        'TestMail_pb
        '
        Me.TestMail_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TestMail_pb.Image = Global.RHP.My.Resources.Resources.btn_testCon
        Me.TestMail_pb.InitialImage = Nothing
        Me.TestMail_pb.Location = New System.Drawing.Point(33, 3)
        Me.TestMail_pb.Name = "TestMail_pb"
        Me.TestMail_pb.Size = New System.Drawing.Size(24, 29)
        Me.TestMail_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.TestMail_pb.TabIndex = 10
        Me.TestMail_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.TestMail_pb, "Tester la connection")
        '
        'Del_pb
        '
        Me.Del_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Del_pb.Image = Global.RHP.My.Resources.Resources.btn_delete
        Me.Del_pb.InitialImage = Nothing
        Me.Del_pb.Location = New System.Drawing.Point(93, 3)
        Me.Del_pb.Name = "Del_pb"
        Me.Del_pb.Size = New System.Drawing.Size(24, 29)
        Me.Del_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Del_pb.TabIndex = 4
        Me.Del_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Del_pb, "Supprimer")
        '
        'New_pb
        '
        Me.New_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.New_pb.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.New_pb.InitialImage = Nothing
        Me.New_pb.Location = New System.Drawing.Point(3, 3)
        Me.New_pb.Name = "New_pb"
        Me.New_pb.Size = New System.Drawing.Size(24, 29)
        Me.New_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.New_pb.TabIndex = 3
        Me.New_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.New_pb, "Nouveau")
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(581, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 29)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 8
        Me.Close_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Close_pb, "Fermer")
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(123, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(452, 35)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Paramétrages des éléments de messagerie"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Admin_Messagerie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(612, 340)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Admin_Messagerie"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.Tag = "ECR"
        Me.Text = "Paramétrages des éléments de messagerie"
        CType(Me.Port_Mail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestMail_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Del_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Mail_Addr_Text As ud_TextBox
    Friend WithEvents CheminNet As System.Windows.Forms.Label
    Friend WithEvents Pwd_Mail_Text As ud_TextBox
    Friend WithEvents Nom_Prenom_Text As ud_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Smtp_Mail_Text As ud_TextBox
    Friend WithEvents Ssl_Actif As ud_CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Port_Mail As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Mail_From_Text As ud_TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Test_Mail_Text As ud_TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents TestMail_pb As PictureBox
    Friend WithEvents Del_pb As PictureBox
    Friend WithEvents New_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
