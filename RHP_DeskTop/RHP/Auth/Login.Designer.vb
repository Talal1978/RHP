<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Ud_Panel2 = New RHP.ud_Panel()
        Me.Connection_lb = New System.Windows.Forms.ListBox()
        Me.pn_log = New RHP.ud_Panel()
        Me.login_lbl = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pb_chk = New System.Windows.Forms.PictureBox()
        Me.pwdForgotten = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Ud_Panel4 = New RHP.ud_Panel()
        Me.Pwd_txt = New ud_TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Ud_Panel3 = New RHP.ud_Panel()
        Me.Login_txt = New ud_TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Ud_Panel1 = New RHP.ud_Panel()
        Me.Connection_lbl = New System.Windows.Forms.Label()
        Me.pb_cbo = New System.Windows.Forms.PictureBox()
        Me.p_1 = New System.Windows.Forms.PictureBox()
        Me.Close_D = New System.Windows.Forms.PictureBox()
        Me.NewConnection_D = New System.Windows.Forms.PictureBox()
        Me.Default_Interface_switch = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Ud_Panel2.SuspendLayout()
        Me.pn_log.SuspendLayout()
        CType(Me.pb_chk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ud_Panel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ud_Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ud_Panel1.SuspendLayout()
        CType(Me.pb_cbo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewConnection_D, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ud_Panel2
        '
        Me.Ud_Panel2.BackColor = System.Drawing.Color.White
        Me.Ud_Panel2.BackgroundImage = CType(resources.GetObject("Ud_Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Ud_Panel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel2.BorderSize = 2
        Me.Ud_Panel2.Controls.Add(Me.Default_Interface_switch)
        Me.Ud_Panel2.Controls.Add(Me.Connection_lb)
        Me.Ud_Panel2.Controls.Add(Me.pn_log)
        Me.Ud_Panel2.Controls.Add(Me.Version)
        Me.Ud_Panel2.Controls.Add(Me.Label3)
        Me.Ud_Panel2.Controls.Add(Me.pb_chk)
        Me.Ud_Panel2.Controls.Add(Me.pwdForgotten)
        Me.Ud_Panel2.Controls.Add(Me.PictureBox1)
        Me.Ud_Panel2.Controls.Add(Me.PictureBox4)
        Me.Ud_Panel2.Controls.Add(Me.Ud_Panel4)
        Me.Ud_Panel2.Controls.Add(Me.Ud_Panel3)
        Me.Ud_Panel2.Controls.Add(Me.Ud_Panel1)
        Me.Ud_Panel2.Controls.Add(Me.Close_D)
        Me.Ud_Panel2.Controls.Add(Me.NewConnection_D)
        Me.Ud_Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Ud_Panel2.Name = "Ud_Panel2"
        Me.Ud_Panel2.Size = New System.Drawing.Size(589, 844)
        Me.Ud_Panel2.TabIndex = 4
        '
        'Connection_lb
        '
        Me.Connection_lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Connection_lb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Connection_lb.FormattingEnabled = True
        Me.Connection_lb.ItemHeight = 24
        Me.Connection_lb.Location = New System.Drawing.Point(101, 388)
        Me.Connection_lb.Margin = New System.Windows.Forms.Padding(4)
        Me.Connection_lb.Name = "Connection_lb"
        Me.Connection_lb.Size = New System.Drawing.Size(447, 28)
        Me.Connection_lb.TabIndex = 14
        Me.Connection_lb.Visible = False
        '
        'pn_log
        '
        Me.pn_log.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pn_log.BorderSize = 2
        Me.pn_log.Controls.Add(Me.login_lbl)
        Me.pn_log.Location = New System.Drawing.Point(37, 705)
        Me.pn_log.Margin = New System.Windows.Forms.Padding(4)
        Me.pn_log.Name = "pn_log"
        Me.pn_log.Size = New System.Drawing.Size(513, 62)
        Me.pn_log.TabIndex = 13
        '
        'login_lbl
        '
        Me.login_lbl.BackColor = System.Drawing.Color.Transparent
        Me.login_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.login_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.login_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.login_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.login_lbl.Location = New System.Drawing.Point(0, 0)
        Me.login_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.login_lbl.Name = "login_lbl"
        Me.login_lbl.Size = New System.Drawing.Size(513, 62)
        Me.login_lbl.TabIndex = 8
        Me.login_lbl.Text = "Entrer"
        Me.login_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Version
        '
        Me.Version.AutoSize = True
        Me.Version.ForeColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.Version.Location = New System.Drawing.Point(207, 816)
        Me.Version.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(128, 16)
        Me.Version.TabIndex = 12
        Me.Version.Text = "Version :2023.000.02"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(92, 572)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Se souvenir de moi"
        '
        'pb_chk
        '
        Me.pb_chk.Location = New System.Drawing.Point(53, 564)
        Me.pb_chk.Margin = New System.Windows.Forms.Padding(4)
        Me.pb_chk.Name = "pb_chk"
        Me.pb_chk.Size = New System.Drawing.Size(33, 31)
        Me.pb_chk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_chk.TabIndex = 10
        Me.pb_chk.TabStop = False
        '
        'pwdForgotten
        '
        Me.pwdForgotten.AutoSize = True
        Me.pwdForgotten.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pwdForgotten.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pwdForgotten.Location = New System.Drawing.Point(403, 532)
        Me.pwdForgotten.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.pwdForgotten.Name = "pwdForgotten"
        Me.pwdForgotten.Size = New System.Drawing.Size(139, 16)
        Me.pwdForgotten.TabIndex = 9
        Me.pwdForgotten.Text = "Mot de passe oublié ?"
        Me.pwdForgotten.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(197, 50)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 138)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(61, 177)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(464, 122)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'Ud_Panel4
        '
        Me.Ud_Panel4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel4.BorderSize = 1
        Me.Ud_Panel4.Controls.Add(Me.Pwd_txt)
        Me.Ud_Panel4.Controls.Add(Me.PictureBox3)
        Me.Ud_Panel4.Location = New System.Drawing.Point(37, 466)
        Me.Ud_Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Ud_Panel4.Name = "Ud_Panel4"
        Me.Ud_Panel4.Size = New System.Drawing.Size(513, 62)
        Me.Ud_Panel4.TabIndex = 6
        '
        'Pwd_txt
        '
        Me.Pwd_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Pwd_txt.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pwd_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Pwd_txt.Location = New System.Drawing.Point(65, 14)
        Me.Pwd_txt.Margin = New System.Windows.Forms.Padding(4)
        Me.Pwd_txt.Name = "Pwd_txt"
        Me.Pwd_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Pwd_txt.Size = New System.Drawing.Size(443, 37)
        Me.Pwd_txt.TabIndex = 1
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(3, 2)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(61, 57)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Ud_Panel3
        '
        Me.Ud_Panel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel3.BorderSize = 1
        Me.Ud_Panel3.Controls.Add(Me.Login_txt)
        Me.Ud_Panel3.Controls.Add(Me.PictureBox2)
        Me.Ud_Panel3.Location = New System.Drawing.Point(37, 395)
        Me.Ud_Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Ud_Panel3.Name = "Ud_Panel3"
        Me.Ud_Panel3.Size = New System.Drawing.Size(513, 64)
        Me.Ud_Panel3.TabIndex = 5
        '
        'Login_txt
        '
        Me.Login_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Login_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Login_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Login_txt.Location = New System.Drawing.Point(65, 17)
        Me.Login_txt.Margin = New System.Windows.Forms.Padding(4)
        Me.Login_txt.Name = "Login_txt"
        Me.Login_txt.Size = New System.Drawing.Size(443, 27)
        Me.Login_txt.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 2)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(61, 57)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Ud_Panel1
        '
        Me.Ud_Panel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel1.BorderSize = 1
        Me.Ud_Panel1.Controls.Add(Me.Connection_lbl)
        Me.Ud_Panel1.Controls.Add(Me.pb_cbo)
        Me.Ud_Panel1.Controls.Add(Me.p_1)
        Me.Ud_Panel1.Location = New System.Drawing.Point(37, 326)
        Me.Ud_Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Ud_Panel1.Name = "Ud_Panel1"
        Me.Ud_Panel1.Size = New System.Drawing.Size(513, 62)
        Me.Ud_Panel1.TabIndex = 3
        '
        'Connection_lbl
        '
        Me.Connection_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Connection_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Connection_lbl.Location = New System.Drawing.Point(65, 4)
        Me.Connection_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Connection_lbl.Name = "Connection_lbl"
        Me.Connection_lbl.Size = New System.Drawing.Size(400, 52)
        Me.Connection_lbl.TabIndex = 4
        Me.Connection_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pb_cbo
        '
        Me.pb_cbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_cbo.Image = CType(resources.GetObject("pb_cbo.Image"), System.Drawing.Image)
        Me.pb_cbo.Location = New System.Drawing.Point(468, 2)
        Me.pb_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.pb_cbo.Name = "pb_cbo"
        Me.pb_cbo.Size = New System.Drawing.Size(41, 55)
        Me.pb_cbo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pb_cbo.TabIndex = 3
        Me.pb_cbo.TabStop = False
        '
        'p_1
        '
        Me.p_1.Image = CType(resources.GetObject("p_1.Image"), System.Drawing.Image)
        Me.p_1.Location = New System.Drawing.Point(3, 2)
        Me.p_1.Margin = New System.Windows.Forms.Padding(4)
        Me.p_1.Name = "p_1"
        Me.p_1.Size = New System.Drawing.Size(61, 57)
        Me.p_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.p_1.TabIndex = 0
        Me.p_1.TabStop = False
        '
        'Close_D
        '
        Me.Close_D.BackColor = System.Drawing.Color.Transparent
        Me.Close_D.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_D.Image = CType(resources.GetObject("Close_D.Image"), System.Drawing.Image)
        Me.Close_D.Location = New System.Drawing.Point(540, 15)
        Me.Close_D.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_D.Name = "Close_D"
        Me.Close_D.Size = New System.Drawing.Size(33, 31)
        Me.Close_D.TabIndex = 2
        Me.Close_D.TabStop = False
        '
        'NewConnection_D
        '
        Me.NewConnection_D.BackColor = System.Drawing.Color.Transparent
        Me.NewConnection_D.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NewConnection_D.Image = CType(resources.GetObject("NewConnection_D.Image"), System.Drawing.Image)
        Me.NewConnection_D.Location = New System.Drawing.Point(16, 15)
        Me.NewConnection_D.Margin = New System.Windows.Forms.Padding(4)
        Me.NewConnection_D.Name = "NewConnection_D"
        Me.NewConnection_D.Size = New System.Drawing.Size(33, 31)
        Me.NewConnection_D.TabIndex = 1
        Me.NewConnection_D.TabStop = False
        '
        'Default_Interface_switch
        '
        '
        '
        '
        Me.Default_Interface_switch.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Default_Interface_switch.BackgroundStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Default_Interface_switch.BackgroundStyle.Class = ""
        Me.Default_Interface_switch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Default_Interface_switch.BackgroundStyle.TextShadowColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Default_Interface_switch.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Default_Interface_switch.Location = New System.Drawing.Point(40, 617)
        Me.Default_Interface_switch.Name = "Default_Interface_switch"
        Me.Default_Interface_switch.OffText = "BackOffice"
        Me.Default_Interface_switch.OnText = "Portail"
        Me.Default_Interface_switch.Size = New System.Drawing.Size(154, 33)
        Me.Default_Interface_switch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Default_Interface_switch.SwitchWidth = 50
        Me.Default_Interface_switch.TabIndex = 15
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 844)
        Me.Controls.Add(Me.Ud_Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.Ud_Panel2.ResumeLayout(False)
        Me.Ud_Panel2.PerformLayout()
        Me.pn_log.ResumeLayout(False)
        CType(Me.pb_chk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ud_Panel4.ResumeLayout(False)
        Me.Ud_Panel4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ud_Panel3.ResumeLayout(False)
        Me.Ud_Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ud_Panel1.ResumeLayout(False)
        CType(Me.pb_cbo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewConnection_D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents NewConnection_D As PictureBox
    Friend WithEvents Close_D As PictureBox
    Friend WithEvents Ud_Panel2 As ud_Panel
    Friend WithEvents Ud_Panel1 As ud_Panel
    Friend WithEvents p_1 As PictureBox
    Friend WithEvents Ud_Panel3 As ud_Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Login_txt as ud_TextBox
    Friend WithEvents Ud_Panel4 As ud_Panel
    Friend WithEvents Pwd_txt as ud_TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents pb_chk As PictureBox
    Friend WithEvents pwdForgotten As Label
    Friend WithEvents login_lbl As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Version As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pn_log As ud_Panel
    Friend WithEvents Connection_lb As ListBox
    Friend WithEvents pb_cbo As PictureBox
    Friend WithEvents Connection_lbl As Label
    Friend WithEvents Default_Interface_switch As DevComponents.DotNetBar.Controls.SwitchButton
End Class
