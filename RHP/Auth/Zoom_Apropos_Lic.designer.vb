<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Apropos_Lic
    Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Zoom_Apropos_Lic))
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Num_Licence_txt = New RHP.ud_TextBox()
        Me.Actualiser = New System.Windows.Forms.Label()
        Me.Quitter = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Connecter = New System.Windows.Forms.Label()
        Me.Ref_Licence = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Pnl.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Label1)
        Me.Pnl.Controls.Add(Me.Label3)
        Me.Pnl.Controls.Add(Me.Titre_lbl)
        Me.Pnl.Controls.Add(Me.PictureBox2)
        Me.Pnl.Controls.Add(Me.Num_Licence_txt)
        Me.Pnl.Controls.Add(Me.Actualiser)
        Me.Pnl.Controls.Add(Me.Quitter)
        Me.Pnl.Controls.Add(Me.Label2)
        Me.Pnl.Controls.Add(Me.Connecter)
        Me.Pnl.Controls.Add(Me.Ref_Licence)
        Me.Pnl.Controls.Add(Me.PictureBox1)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Pnl.Location = New System.Drawing.Point(2, 2)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Padding = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.Pnl.Size = New System.Drawing.Size(554, 463)
        Me.Pnl.TabIndex = 0
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(3, 3)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(548, 31)
        Me.Titre_lbl.TabIndex = 35
        Me.Titre_lbl.Text = "A propos de votre RH-P"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(358, 210)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(190, 52)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 21
        Me.PictureBox2.TabStop = False
        '
        'Num_Licence_txt
        '
        Me.Num_Licence_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Licence_txt.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Num_Licence_txt.Font = New System.Drawing.Font("Montserrat", 16.0!)
        Me.Num_Licence_txt.Location = New System.Drawing.Point(3, 426)
        Me.Num_Licence_txt.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
        Me.Num_Licence_txt.MaxLength = 32767
        Me.Num_Licence_txt.Multiline = False
        Me.Num_Licence_txt.Name = "Num_Licence_txt"
        Me.Num_Licence_txt.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Num_Licence_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Licence_txt.ReadOnly = True
        Me.Num_Licence_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Licence_txt.SelectionStart = 0
        Me.Num_Licence_txt.Size = New System.Drawing.Size(548, 27)
        Me.Num_Licence_txt.TabIndex = 20
        Me.Num_Licence_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Num_Licence_txt.UseSystemPasswordChar = False
        '
        'Actualiser
        '
        Me.Actualiser.AutoSize = True
        Me.Actualiser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Actualiser.Location = New System.Drawing.Point(412, 46)
        Me.Actualiser.Name = "Actualiser"
        Me.Actualiser.Size = New System.Drawing.Size(53, 13)
        Me.Actualiser.TabIndex = 14
        Me.Actualiser.Text = "Actualiser"
        '
        'Quitter
        '
        Me.Quitter.AutoSize = True
        Me.Quitter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Quitter.Location = New System.Drawing.Point(512, 46)
        Me.Quitter.Name = "Quitter"
        Me.Quitter.Size = New System.Drawing.Size(38, 13)
        Me.Quitter.TabIndex = 10
        Me.Quitter.Text = "Quitter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(465, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(9, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "|"
        '
        'Connecter
        '
        Me.Connecter.AutoSize = True
        Me.Connecter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Connecter.Location = New System.Drawing.Point(457, 46)
        Me.Connecter.Name = "Connecter"
        Me.Connecter.Size = New System.Drawing.Size(0, 13)
        Me.Connecter.TabIndex = 8
        '
        'Ref_Licence
        '
        Me.Ref_Licence.AutoSize = True
        Me.Ref_Licence.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ref_Licence.Location = New System.Drawing.Point(10, 240)
        Me.Ref_Licence.Name = "Ref_Licence"
        Me.Ref_Licence.Size = New System.Drawing.Size(0, 13)
        Me.Ref_Licence.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(358, 99)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(190, 105)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(475, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Lien"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(503, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(9, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "|"
        '
        'Zoom_Apropos_Lic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(558, 467)
        Me.ControlBox = False
        Me.Controls.Add(Me.Pnl)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Zoom_Apropos_Lic"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Authentification"
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Ref_Licence As System.Windows.Forms.Label
    Friend WithEvents Quitter As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Connecter As System.Windows.Forms.Label
    Friend WithEvents Actualiser As System.Windows.Forms.Label
    Friend WithEvents Num_Licence_txt As ud_TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
