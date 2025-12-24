<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ctb_Compta_Caisse_Banque
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Swift_Text = New ud_TextBox()
        Me.Mouvemente_Check = New ud_CheckBox()
        Me.Mis_Sml_Check = New ud_CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lib_Typ_Caisse_Bank_Text = New ud_TextBox()
        Me.Typ_Caisse_Bank_Text = New ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Bank_txt = New ud_TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Cod_Caisse_Bank_Text = New ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Addresse_Text = New ud_TextBox()
        Me.Compte_Bancaire_Text = New ud_TextBox()
        Me.Lib_Bank_txt = New ud_TextBox()
        Me.Rib_Text = New ud_TextBox()
        Me.Lib_Caisse_Bank_Text = New ud_TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Swift_Text)
        Me.GroupBox1.Controls.Add(Me.Mouvemente_Check)
        Me.GroupBox1.Controls.Add(Me.Mis_Sml_Check)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Lib_Typ_Caisse_Bank_Text)
        Me.GroupBox1.Controls.Add(Me.Typ_Caisse_Bank_Text)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.Bank_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel3)
        Me.GroupBox1.Controls.Add(Me.Cod_Caisse_Bank_Text)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.Addresse_Text)
        Me.GroupBox1.Controls.Add(Me.Compte_Bancaire_Text)
        Me.GroupBox1.Controls.Add(Me.Lib_Bank_txt)
        Me.GroupBox1.Controls.Add(Me.Rib_Text)
        Me.GroupBox1.Controls.Add(Me.Lib_Caisse_Bank_Text)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(972, 524)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Caisses et Banques"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(131, 218)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 16)
        Me.Label9.TabIndex = 207
        Me.Label9.Text = "Swift"
        '
        'Swift_Text
        '
        Me.Swift_Text.Location = New System.Drawing.Point(167, 215)
        Me.Swift_Text.MaxLength = 24
        Me.Swift_Text.Name = "Swift_Text"
        Me.Swift_Text.Size = New System.Drawing.Size(142, 21)
        Me.Swift_Text.TabIndex = 7
        Me.Swift_Text.Tag = ""
        '
        'Mouvemente_Check
        '
        Me.Mouvemente_Check.AutoSize = True
        Me.Mouvemente_Check.Enabled = False
        Me.Mouvemente_Check.Location = New System.Drawing.Point(167, 267)
        Me.Mouvemente_Check.Name = "Mouvemente_Check"
        Me.Mouvemente_Check.Size = New System.Drawing.Size(102, 20)
        Me.Mouvemente_Check.TabIndex = 201
        Me.Mouvemente_Check.Text = "Mouvementé"
        '
        'Mis_Sml_Check
        '
        Me.Mis_Sml_Check.AutoSize = True
        Me.Mis_Sml_Check.Location = New System.Drawing.Point(167, 240)
        Me.Mis_Sml_Check.Name = "Mis_Sml_Check"
        Me.Mis_Sml_Check.Size = New System.Drawing.Size(108, 20)
        Me.Mis_Sml_Check.TabIndex = 7
        Me.Mis_Sml_Check.Text = "Mis en Sommeil"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(108, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Addresse"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(78, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 16)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "N° de Compte"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(140, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "RIB"
        '
        'Lib_Typ_Caisse_Bank_Text
        '
        Me.Lib_Typ_Caisse_Bank_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lib_Typ_Caisse_Bank_Text.Enabled = False
        Me.Lib_Typ_Caisse_Bank_Text.Location = New System.Drawing.Point(260, 101)
        Me.Lib_Typ_Caisse_Bank_Text.MaxLength = 10
        Me.Lib_Typ_Caisse_Bank_Text.Name = "Lib_Typ_Caisse_Bank_Text"
        Me.Lib_Typ_Caisse_Bank_Text.Size = New System.Drawing.Size(338, 21)
        Me.Lib_Typ_Caisse_Bank_Text.TabIndex = 200
        Me.Lib_Typ_Caisse_Bank_Text.Tag = ""
        '
        'Typ_Caisse_Bank_Text
        '
        Me.Typ_Caisse_Bank_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Typ_Caisse_Bank_Text.Enabled = False
        Me.Typ_Caisse_Bank_Text.Location = New System.Drawing.Point(167, 101)
        Me.Typ_Caisse_Bank_Text.MaxLength = 10
        Me.Typ_Caisse_Bank_Text.Name = "Typ_Caisse_Bank_Text"
        Me.Typ_Caisse_Bank_Text.Size = New System.Drawing.Size(90, 21)
        Me.Typ_Caisse_Bank_Text.TabIndex = 200
        Me.Typ_Caisse_Bank_Text.Tag = ""
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(30, 104)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(134, 16)
        Me.LinkLabel2.TabIndex = 3
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Type Banque ou Caisse"
        '
        'Bank_txt
        '
        Me.Bank_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Bank_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Bank_txt.Location = New System.Drawing.Point(167, 78)
        Me.Bank_txt.MaxLength = 49
        Me.Bank_txt.Name = "Bank_txt"
        Me.Bank_txt.ReadOnly = True
        Me.Bank_txt.Size = New System.Drawing.Size(141, 21)
        Me.Bank_txt.TabIndex = 300
        Me.Bank_txt.Tag = ""
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(112, 81)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(51, 16)
        Me.LinkLabel3.TabIndex = 2
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Banque"
        '
        'Cod_Caisse_Bank_Text
        '
        Me.Cod_Caisse_Bank_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Cod_Caisse_Bank_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Cod_Caisse_Bank_Text.Location = New System.Drawing.Point(167, 56)
        Me.Cod_Caisse_Bank_Text.MaxLength = 49
        Me.Cod_Caisse_Bank_Text.Name = "Cod_Caisse_Bank_Text"
        Me.Cod_Caisse_Bank_Text.ReadOnly = True
        Me.Cod_Caisse_Bank_Text.Size = New System.Drawing.Size(141, 21)
        Me.Cod_Caisse_Bank_Text.TabIndex = 0
        Me.Cod_Caisse_Bank_Text.Tag = ""
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(22, 59)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(139, 16)
        Me.LinkLabel1.TabIndex = 100
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Code Banque ou Caisse"
        '
        'Addresse_Text
        '
        Me.Addresse_Text.Location = New System.Drawing.Point(167, 173)
        Me.Addresse_Text.MaxLength = 1000
        Me.Addresse_Text.Multiline = True
        Me.Addresse_Text.Name = "Addresse_Text"
        Me.Addresse_Text.Size = New System.Drawing.Size(431, 38)
        Me.Addresse_Text.TabIndex = 6
        Me.Addresse_Text.Tag = ""
        '
        'Compte_Bancaire_Text
        '
        Me.Compte_Bancaire_Text.Location = New System.Drawing.Point(167, 148)
        Me.Compte_Bancaire_Text.MaxLength = 24
        Me.Compte_Bancaire_Text.Name = "Compte_Bancaire_Text"
        Me.Compte_Bancaire_Text.Size = New System.Drawing.Size(431, 21)
        Me.Compte_Bancaire_Text.TabIndex = 5
        Me.Compte_Bancaire_Text.Tag = ""
        '
        'Lib_Bank_txt
        '
        Me.Lib_Bank_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lib_Bank_txt.Location = New System.Drawing.Point(314, 78)
        Me.Lib_Bank_txt.MaxLength = 500
        Me.Lib_Bank_txt.Name = "Lib_Bank_txt"
        Me.Lib_Bank_txt.ReadOnly = True
        Me.Lib_Bank_txt.Size = New System.Drawing.Size(283, 21)
        Me.Lib_Bank_txt.TabIndex = 1000
        Me.Lib_Bank_txt.Tag = ""
        '
        'Rib_Text
        '
        Me.Rib_Text.Location = New System.Drawing.Point(167, 125)
        Me.Rib_Text.MaxLength = 24
        Me.Rib_Text.Name = "Rib_Text"
        Me.Rib_Text.Size = New System.Drawing.Size(431, 21)
        Me.Rib_Text.TabIndex = 4
        Me.Rib_Text.Tag = ""
        '
        'Lib_Caisse_Bank_Text
        '
        Me.Lib_Caisse_Bank_Text.Location = New System.Drawing.Point(314, 56)
        Me.Lib_Caisse_Bank_Text.MaxLength = 500
        Me.Lib_Caisse_Bank_Text.Name = "Lib_Caisse_Bank_Text"
        Me.Lib_Caisse_Bank_Text.Size = New System.Drawing.Size(283, 21)
        Me.Lib_Caisse_Bank_Text.TabIndex = 1
        Me.Lib_Caisse_Bank_Text.Tag = ""
        '
        'Ctb_Compta_Caisse_Banque
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(972, 524)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Ctb_Compta_Caisse_Banque"
        Me.Tag = "ECR"
        Me.Text = "Caisses et banques"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cod_Caisse_Bank_Text As ud_TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Lib_Caisse_Bank_Text As ud_TextBox
    Friend WithEvents Lib_Typ_Caisse_Bank_Text As ud_TextBox
    Friend WithEvents Typ_Caisse_Bank_Text As ud_TextBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Rib_Text As ud_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Addresse_Text As ud_TextBox
    Friend WithEvents Mis_Sml_Check As ud_CheckBox
    Friend WithEvents Mouvemente_Check As ud_CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Compte_Bancaire_Text As ud_TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Swift_Text As ud_TextBox
    Friend WithEvents Bank_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Lib_Bank_txt As ud_TextBox
End Class
