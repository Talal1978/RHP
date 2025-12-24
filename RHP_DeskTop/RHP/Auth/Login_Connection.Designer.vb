<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login_Connection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login_Connection))
        Me.Ud_Panel2 = New RHP.ud_Panel()
        Me.DB_lb = New System.Windows.Forms.ListBox()
        Me.Ud_Panel6 = New RHP.ud_Panel()
        Me.Db_txt = New ud_TextBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Ud_Panel5 = New RHP.ud_Panel()
        Me.Pwd_txt = New ud_TextBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Connection_lb = New System.Windows.Forms.ListBox()
        Me.pn_log = New RHP.ud_Panel()
        Me.login_lbl = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Ud_Panel4 = New RHP.ud_Panel()
        Me.User_txt = New ud_TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Ud_Panel3 = New RHP.ud_Panel()
        Me.Srv_txt = New ud_TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Ud_Panel1 = New RHP.ud_Panel()
        Me.Conn_txt = New ud_TextBox()
        Me.pb_cbo = New System.Windows.Forms.PictureBox()
        Me.p_1 = New System.Windows.Forms.PictureBox()
        Me.Close_D = New System.Windows.Forms.PictureBox()
        Me.Ud_Panel2.SuspendLayout()
        Me.Ud_Panel6.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ud_Panel5.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pn_log.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ud_Panel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ud_Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ud_Panel1.SuspendLayout()
        CType(Me.pb_cbo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_D, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ud_Panel2
        '
        Me.Ud_Panel2.BackColor = System.Drawing.Color.White
        Me.Ud_Panel2.BackgroundImage = CType(resources.GetObject("Ud_Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Ud_Panel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel2.BorderSize = 2
        Me.Ud_Panel2.Controls.Add(Me.DB_lb)
        Me.Ud_Panel2.Controls.Add(Me.Ud_Panel6)
        Me.Ud_Panel2.Controls.Add(Me.Ud_Panel5)
        Me.Ud_Panel2.Controls.Add(Me.Connection_lb)
        Me.Ud_Panel2.Controls.Add(Me.pn_log)
        Me.Ud_Panel2.Controls.Add(Me.Version)
        Me.Ud_Panel2.Controls.Add(Me.PictureBox1)
        Me.Ud_Panel2.Controls.Add(Me.Ud_Panel4)
        Me.Ud_Panel2.Controls.Add(Me.Ud_Panel3)
        Me.Ud_Panel2.Controls.Add(Me.Ud_Panel1)
        Me.Ud_Panel2.Controls.Add(Me.Close_D)
        Me.Ud_Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Panel2.Name = "Ud_Panel2"
        Me.Ud_Panel2.Size = New System.Drawing.Size(442, 686)
        Me.Ud_Panel2.TabIndex = 4
        '
        'DB_lb
        '
        Me.DB_lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DB_lb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.DB_lb.FormattingEnabled = True
        Me.DB_lb.ItemHeight = 18
        Me.DB_lb.Location = New System.Drawing.Point(75, 485)
        Me.DB_lb.Name = "DB_lb"
        Me.DB_lb.Size = New System.Drawing.Size(337, 4)
        Me.DB_lb.TabIndex = 16
        Me.DB_lb.Visible = False
        '
        'Ud_Panel6
        '
        Me.Ud_Panel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel6.BorderSize = 1
        Me.Ud_Panel6.Controls.Add(Me.Db_txt)
        Me.Ud_Panel6.Controls.Add(Me.PictureBox5)
        Me.Ud_Panel6.Location = New System.Drawing.Point(28, 435)
        Me.Ud_Panel6.Name = "Ud_Panel6"
        Me.Ud_Panel6.Size = New System.Drawing.Size(385, 50)
        Me.Ud_Panel6.TabIndex = 4
        '
        'Db_txt
        '
        Me.Db_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Db_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Db_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Db_txt.Location = New System.Drawing.Point(50, 12)
        Me.Db_txt.Name = "Db_txt"
        Me.Db_txt.Size = New System.Drawing.Size(332, 22)
        Me.Db_txt.TabIndex = 3
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(45, 45)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 0
        Me.PictureBox5.TabStop = False
        '
        'Ud_Panel5
        '
        Me.Ud_Panel5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel5.BorderSize = 1
        Me.Ud_Panel5.Controls.Add(Me.Pwd_txt)
        Me.Ud_Panel5.Controls.Add(Me.PictureBox4)
        Me.Ud_Panel5.Location = New System.Drawing.Point(28, 379)
        Me.Ud_Panel5.Name = "Ud_Panel5"
        Me.Ud_Panel5.Size = New System.Drawing.Size(385, 50)
        Me.Ud_Panel5.TabIndex = 3
        '
        'Pwd_txt
        '
        Me.Pwd_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Pwd_txt.Font = New System.Drawing.Font("Calibri", 18.0!)
        Me.Pwd_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Pwd_txt.Location = New System.Drawing.Point(50, 14)
        Me.Pwd_txt.Name = "Pwd_txt"
        Me.Pwd_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Pwd_txt.Size = New System.Drawing.Size(332, 30)
        Me.Pwd_txt.TabIndex = 4
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(45, 45)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'Connection_lb
        '
        Me.Connection_lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Connection_lb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Connection_lb.FormattingEnabled = True
        Me.Connection_lb.ItemHeight = 18
        Me.Connection_lb.Location = New System.Drawing.Point(76, 261)
        Me.Connection_lb.Name = "Connection_lb"
        Me.Connection_lb.Size = New System.Drawing.Size(336, 4)
        Me.Connection_lb.TabIndex = 14
        Me.Connection_lb.Visible = False
        '
        'pn_log
        '
        Me.pn_log.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pn_log.BorderSize = 2
        Me.pn_log.Controls.Add(Me.login_lbl)
        Me.pn_log.Location = New System.Drawing.Point(28, 556)
        Me.pn_log.Name = "pn_log"
        Me.pn_log.Size = New System.Drawing.Size(385, 50)
        Me.pn_log.TabIndex = 13
        '
        'login_lbl
        '
        Me.login_lbl.BackColor = System.Drawing.Color.Transparent
        Me.login_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.login_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.login_lbl.Font = New System.Drawing.Font("Roboto", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.login_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.login_lbl.Location = New System.Drawing.Point(0, 0)
        Me.login_lbl.Name = "login_lbl"
        Me.login_lbl.Size = New System.Drawing.Size(385, 50)
        Me.login_lbl.TabIndex = 5
        Me.login_lbl.Text = "Enregistrer"
        Me.login_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Version
        '
        Me.Version.AutoSize = True
        Me.Version.ForeColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.Version.Location = New System.Drawing.Point(163, 663)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(108, 13)
        Me.Version.TabIndex = 12
        Me.Version.Text = "Version :2023.000.02"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(148, 41)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 112)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Ud_Panel4
        '
        Me.Ud_Panel4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel4.BorderSize = 1
        Me.Ud_Panel4.Controls.Add(Me.User_txt)
        Me.Ud_Panel4.Controls.Add(Me.PictureBox3)
        Me.Ud_Panel4.Location = New System.Drawing.Point(28, 323)
        Me.Ud_Panel4.Name = "Ud_Panel4"
        Me.Ud_Panel4.Size = New System.Drawing.Size(385, 50)
        Me.Ud_Panel4.TabIndex = 2
        '
        'User_txt
        '
        Me.User_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.User_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.User_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.User_txt.Location = New System.Drawing.Point(49, 11)
        Me.User_txt.Name = "User_txt"
        Me.User_txt.Size = New System.Drawing.Size(332, 22)
        Me.User_txt.TabIndex = 2
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(45, 45)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Ud_Panel3
        '
        Me.Ud_Panel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel3.BorderSize = 1
        Me.Ud_Panel3.Controls.Add(Me.Srv_txt)
        Me.Ud_Panel3.Controls.Add(Me.PictureBox2)
        Me.Ud_Panel3.Location = New System.Drawing.Point(28, 267)
        Me.Ud_Panel3.Name = "Ud_Panel3"
        Me.Ud_Panel3.Size = New System.Drawing.Size(385, 50)
        Me.Ud_Panel3.TabIndex = 1
        '
        'Srv_txt
        '
        Me.Srv_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Srv_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Srv_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Srv_txt.Location = New System.Drawing.Point(49, 14)
        Me.Srv_txt.Name = "Srv_txt"
        Me.Srv_txt.Size = New System.Drawing.Size(332, 22)
        Me.Srv_txt.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(45, 45)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Ud_Panel1
        '
        Me.Ud_Panel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel1.BorderSize = 1
        Me.Ud_Panel1.Controls.Add(Me.Conn_txt)
        Me.Ud_Panel1.Controls.Add(Me.pb_cbo)
        Me.Ud_Panel1.Controls.Add(Me.p_1)
        Me.Ud_Panel1.Location = New System.Drawing.Point(28, 211)
        Me.Ud_Panel1.Name = "Ud_Panel1"
        Me.Ud_Panel1.Size = New System.Drawing.Size(385, 50)
        Me.Ud_Panel1.TabIndex = 0
        '
        'Conn_txt
        '
        Me.Conn_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Conn_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Conn_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Conn_txt.Location = New System.Drawing.Point(48, 14)
        Me.Conn_txt.Name = "Conn_txt"
        Me.Conn_txt.Size = New System.Drawing.Size(302, 22)
        Me.Conn_txt.TabIndex = 0
        '
        'pb_cbo
        '
        Me.pb_cbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_cbo.Image = CType(resources.GetObject("pb_cbo.Image"), System.Drawing.Image)
        Me.pb_cbo.Location = New System.Drawing.Point(351, 2)
        Me.pb_cbo.Name = "pb_cbo"
        Me.pb_cbo.Size = New System.Drawing.Size(31, 45)
        Me.pb_cbo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pb_cbo.TabIndex = 3
        Me.pb_cbo.TabStop = False
        '
        'p_1
        '
        Me.p_1.Image = CType(resources.GetObject("p_1.Image"), System.Drawing.Image)
        Me.p_1.Location = New System.Drawing.Point(2, 2)
        Me.p_1.Name = "p_1"
        Me.p_1.Size = New System.Drawing.Size(45, 45)
        Me.p_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.p_1.TabIndex = 0
        Me.p_1.TabStop = False
        '
        'Close_D
        '
        Me.Close_D.BackColor = System.Drawing.Color.Transparent
        Me.Close_D.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_D.Image = CType(resources.GetObject("Close_D.Image"), System.Drawing.Image)
        Me.Close_D.Location = New System.Drawing.Point(405, 12)
        Me.Close_D.Name = "Close_D"
        Me.Close_D.Size = New System.Drawing.Size(25, 25)
        Me.Close_D.TabIndex = 2
        Me.Close_D.TabStop = False
        '
        'Login_Connection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 686)
        Me.Controls.Add(Me.Ud_Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login_Connection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connexion"
        Me.Ud_Panel2.ResumeLayout(False)
        Me.Ud_Panel2.PerformLayout()
        Me.Ud_Panel6.ResumeLayout(False)
        Me.Ud_Panel6.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ud_Panel5.ResumeLayout(False)
        Me.Ud_Panel5.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pn_log.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ud_Panel4.ResumeLayout(False)
        Me.Ud_Panel4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ud_Panel3.ResumeLayout(False)
        Me.Ud_Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ud_Panel1.ResumeLayout(False)
        Me.Ud_Panel1.PerformLayout()
        CType(Me.pb_cbo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Close_D As PictureBox
    Friend WithEvents Ud_Panel2 As ud_Panel
    Friend WithEvents Ud_Panel1 As ud_Panel
    Friend WithEvents p_1 As PictureBox
    Friend WithEvents Ud_Panel3 As ud_Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Srv_txt as ud_TextBox
    Friend WithEvents Ud_Panel4 As ud_Panel
    Friend WithEvents User_txt as ud_TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents login_lbl As Label
    Friend WithEvents Version As Label
    Friend WithEvents pn_log As ud_Panel
    Friend WithEvents pb_cbo As PictureBox
    Friend WithEvents Connection_lb As ListBox
    Friend WithEvents Ud_Panel6 As ud_Panel
    Friend WithEvents Pwd_txt as ud_TextBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Ud_Panel5 As ud_Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Conn_txt as ud_TextBox
    Friend WithEvents DB_lb As ListBox
    Friend WithEvents Db_txt as ud_TextBox
End Class
