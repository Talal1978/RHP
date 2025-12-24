<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_RH_Preparation_Paie_Saisie
    Inherits Ecran

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EntPnl = New System.Windows.Forms.Panel()
        Me.Afficher_Rubriques_chk = New RHP.ud_CheckBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Bulletin_chk = New RHP.ud_RadioBox()
        Me.Mensuel_chk = New RHP.ud_RadioBox()
        Me.Cloture_Check = New RHP.ud_CheckBox()
        Me.pbPhoto = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Typ_Contrat_ = New System.Windows.Forms.Label()
        Me.Dat_Entree_txt = New RHP.ud_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Typ_Contrat_txt = New RHP.ud_TextBox()
        Me.Typ_Agent_txt = New RHP.ud_TextBox()
        Me.Typ_Periode_txt = New RHP.ud_TextBox()
        Me.Dat_Naissance_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Nom_txt = New RHP.ud_TextBox()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Recap_Pnl = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.EcartBrut_txt = New RHP.ud_TextBox()
        Me.BrutCalcule_txt = New RHP.ud_TextBox()
        Me.BrutBulletin_txt = New RHP.ud_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.EcartNet_txt = New RHP.ud_TextBox()
        Me.NetCalcul_txt = New RHP.ud_TextBox()
        Me.NetBulletin_txt = New RHP.ud_TextBox()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.MyGrd = New RHP.ud_Grd()
        Me.EntPnl.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Recap_Pnl.SuspendLayout()
        Me.Pnl.SuspendLayout()
        CType(Me.MyGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntPnl
        '
        Me.EntPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.EntPnl.Controls.Add(Me.Afficher_Rubriques_chk)
        Me.EntPnl.Controls.Add(Me.TableLayoutPanel2)
        Me.EntPnl.Controls.Add(Me.Cloture_Check)
        Me.EntPnl.Controls.Add(Me.pbPhoto)
        Me.EntPnl.Controls.Add(Me.Label4)
        Me.EntPnl.Controls.Add(Me.Label14)
        Me.EntPnl.Controls.Add(Me.Typ_Contrat_)
        Me.EntPnl.Controls.Add(Me.Dat_Entree_txt)
        Me.EntPnl.Controls.Add(Me.Label3)
        Me.EntPnl.Controls.Add(Me.Typ_Contrat_txt)
        Me.EntPnl.Controls.Add(Me.Typ_Agent_txt)
        Me.EntPnl.Controls.Add(Me.Typ_Periode_txt)
        Me.EntPnl.Controls.Add(Me.Dat_Naissance_txt)
        Me.EntPnl.Controls.Add(Me.Label2)
        Me.EntPnl.Controls.Add(Me.Nom_txt)
        Me.EntPnl.Controls.Add(Me.Matricule_txt)
        Me.EntPnl.Controls.Add(Me.Label1)
        Me.EntPnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.EntPnl.Location = New System.Drawing.Point(0, 0)
        Me.EntPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.EntPnl.Name = "EntPnl"
        Me.EntPnl.Size = New System.Drawing.Size(966, 191)
        Me.EntPnl.TabIndex = 8
        '
        'Afficher_Rubriques_chk
        '
        Me.Afficher_Rubriques_chk.AutoSize = True
        Me.Afficher_Rubriques_chk.Checked = False
        Me.Afficher_Rubriques_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Afficher_Rubriques_chk.Location = New System.Drawing.Point(108, 148)
        Me.Afficher_Rubriques_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Afficher_Rubriques_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Afficher_Rubriques_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Afficher_Rubriques_chk.Name = "Afficher_Rubriques_chk"
        Me.Afficher_Rubriques_chk.Size = New System.Drawing.Size(232, 31)
        Me.Afficher_Rubriques_chk.TabIndex = 233
        Me.Afficher_Rubriques_chk.Text = "Afficher le code des rubriques"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Bulletin_chk, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Mensuel_chk, 0, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(592, 21)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(172, 158)
        Me.TableLayoutPanel2.TabIndex = 232
        '
        'Bulletin_chk
        '
        Me.Bulletin_chk.AutoSize = True
        Me.Bulletin_chk.Checked = True
        Me.Bulletin_chk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Bulletin_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Bulletin_chk.Location = New System.Drawing.Point(4, 5)
        Me.Bulletin_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Bulletin_chk.MaximumSize = New System.Drawing.Size(0, 39)
        Me.Bulletin_chk.MinimumSize = New System.Drawing.Size(0, 39)
        Me.Bulletin_chk.Name = "Bulletin_chk"
        Me.Bulletin_chk.Size = New System.Drawing.Size(164, 39)
        Me.Bulletin_chk.TabIndex = 222
        Me.Bulletin_chk.Text = "Mode bulletin de paie"
        '
        'Mensuel_chk
        '
        Me.Mensuel_chk.AutoSize = True
        Me.Mensuel_chk.Checked = False
        Me.Mensuel_chk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Mensuel_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Mensuel_chk.Location = New System.Drawing.Point(4, 49)
        Me.Mensuel_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Mensuel_chk.MaximumSize = New System.Drawing.Size(0, 39)
        Me.Mensuel_chk.MinimumSize = New System.Drawing.Size(0, 39)
        Me.Mensuel_chk.Name = "Mensuel_chk"
        Me.Mensuel_chk.Size = New System.Drawing.Size(164, 39)
        Me.Mensuel_chk.TabIndex = 224
        Me.Mensuel_chk.Text = "Mode mensuel"
        '
        'Cloture_Check
        '
        Me.Cloture_Check.AutoSize = True
        Me.Cloture_Check.Checked = False
        Me.Cloture_Check.Enabled = False
        Me.Cloture_Check.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cloture_Check.Location = New System.Drawing.Point(108, 112)
        Me.Cloture_Check.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cloture_Check.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Cloture_Check.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Cloture_Check.Name = "Cloture_Check"
        Me.Cloture_Check.Size = New System.Drawing.Size(146, 31)
        Me.Cloture_Check.TabIndex = 230
        Me.Cloture_Check.Text = "Clôturée"
        '
        'pbPhoto
        '
        Me.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbPhoto.Location = New System.Drawing.Point(819, 11)
        Me.pbPhoto.Margin = New System.Windows.Forms.Padding(4)
        Me.pbPhoto.Name = "pbPhoto"
        Me.pbPhoto.Size = New System.Drawing.Size(132, 132)
        Me.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPhoto.TabIndex = 228
        Me.pbPhoto.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(16, 58)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 19)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "Type agent"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label14.Location = New System.Drawing.Point(6, 89)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 19)
        Me.Label14.TabIndex = 227
        Me.Label14.Text = "Type Période"
        '
        'Typ_Contrat_
        '
        Me.Typ_Contrat_.AutoSize = True
        Me.Typ_Contrat_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Contrat_.Location = New System.Drawing.Point(311, 58)
        Me.Typ_Contrat_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Typ_Contrat_.Name = "Typ_Contrat_"
        Me.Typ_Contrat_.Size = New System.Drawing.Size(98, 19)
        Me.Typ_Contrat_.TabIndex = 226
        Me.Typ_Contrat_.Text = "Type Contrat"
        '
        'Dat_Entree_txt
        '
        Me.Dat_Entree_txt.AccessibleDescription = "A"
        Me.Dat_Entree_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Entree_txt.ContextMenuStrip = Nothing
        Me.Dat_Entree_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Entree_txt.Location = New System.Drawing.Point(499, 85)
        Me.Dat_Entree_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dat_Entree_txt.MaxLength = 32767
        Me.Dat_Entree_txt.Multiline = False
        Me.Dat_Entree_txt.Name = "Dat_Entree_txt"
        Me.Dat_Entree_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Entree_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Entree_txt.ReadOnly = True
        Me.Dat_Entree_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Entree_txt.SelectionStart = 0
        Me.Dat_Entree_txt.Size = New System.Drawing.Size(86, 26)
        Me.Dat_Entree_txt.TabIndex = 206
        Me.Dat_Entree_txt.TabStop = False
        Me.Dat_Entree_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Entree_txt.UseSystemPasswordChar = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(402, 89)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 19)
        Me.Label3.TabIndex = 205
        Me.Label3.Text = "Date entrée"
        '
        'Typ_Contrat_txt
        '
        Me.Typ_Contrat_txt.AccessibleDescription = "A"
        Me.Typ_Contrat_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Typ_Contrat_txt.ContextMenuStrip = Nothing
        Me.Typ_Contrat_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Contrat_txt.Location = New System.Drawing.Point(415, 55)
        Me.Typ_Contrat_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Typ_Contrat_txt.MaxLength = 32767
        Me.Typ_Contrat_txt.Multiline = False
        Me.Typ_Contrat_txt.Name = "Typ_Contrat_txt"
        Me.Typ_Contrat_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Typ_Contrat_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Typ_Contrat_txt.ReadOnly = True
        Me.Typ_Contrat_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Typ_Contrat_txt.SelectionStart = 0
        Me.Typ_Contrat_txt.Size = New System.Drawing.Size(170, 26)
        Me.Typ_Contrat_txt.TabIndex = 206
        Me.Typ_Contrat_txt.TabStop = False
        Me.Typ_Contrat_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Typ_Contrat_txt.UseSystemPasswordChar = False
        '
        'Typ_Agent_txt
        '
        Me.Typ_Agent_txt.AccessibleDescription = "A"
        Me.Typ_Agent_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Typ_Agent_txt.ContextMenuStrip = Nothing
        Me.Typ_Agent_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Agent_txt.Location = New System.Drawing.Point(108, 54)
        Me.Typ_Agent_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Typ_Agent_txt.MaxLength = 32767
        Me.Typ_Agent_txt.Multiline = False
        Me.Typ_Agent_txt.Name = "Typ_Agent_txt"
        Me.Typ_Agent_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Typ_Agent_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Typ_Agent_txt.ReadOnly = True
        Me.Typ_Agent_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Typ_Agent_txt.SelectionStart = 0
        Me.Typ_Agent_txt.Size = New System.Drawing.Size(196, 26)
        Me.Typ_Agent_txt.TabIndex = 206
        Me.Typ_Agent_txt.TabStop = False
        Me.Typ_Agent_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Typ_Agent_txt.UseSystemPasswordChar = False
        '
        'Typ_Periode_txt
        '
        Me.Typ_Periode_txt.AccessibleDescription = "A"
        Me.Typ_Periode_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Typ_Periode_txt.ContextMenuStrip = Nothing
        Me.Typ_Periode_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Periode_txt.Location = New System.Drawing.Point(108, 85)
        Me.Typ_Periode_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Typ_Periode_txt.MaxLength = 32767
        Me.Typ_Periode_txt.Multiline = False
        Me.Typ_Periode_txt.Name = "Typ_Periode_txt"
        Me.Typ_Periode_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Typ_Periode_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Typ_Periode_txt.ReadOnly = True
        Me.Typ_Periode_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Typ_Periode_txt.SelectionStart = 0
        Me.Typ_Periode_txt.Size = New System.Drawing.Size(196, 26)
        Me.Typ_Periode_txt.TabIndex = 206
        Me.Typ_Periode_txt.TabStop = False
        Me.Typ_Periode_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Typ_Periode_txt.UseSystemPasswordChar = False
        '
        'Dat_Naissance_txt
        '
        Me.Dat_Naissance_txt.AccessibleDescription = "A"
        Me.Dat_Naissance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Naissance_txt.ContextMenuStrip = Nothing
        Me.Dat_Naissance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Naissance_txt.Location = New System.Drawing.Point(499, 114)
        Me.Dat_Naissance_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Dat_Naissance_txt.MaxLength = 32767
        Me.Dat_Naissance_txt.Multiline = False
        Me.Dat_Naissance_txt.Name = "Dat_Naissance_txt"
        Me.Dat_Naissance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Naissance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Naissance_txt.ReadOnly = True
        Me.Dat_Naissance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Naissance_txt.SelectionStart = 0
        Me.Dat_Naissance_txt.Size = New System.Drawing.Size(86, 26)
        Me.Dat_Naissance_txt.TabIndex = 206
        Me.Dat_Naissance_txt.TabStop = False
        Me.Dat_Naissance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Naissance_txt.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(450, 118)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 19)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "Né le"
        '
        'Nom_txt
        '
        Me.Nom_txt.AccessibleDescription = "A"
        Me.Nom_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_txt.ContextMenuStrip = Nothing
        Me.Nom_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_txt.Location = New System.Drawing.Point(240, 21)
        Me.Nom_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Nom_txt.MaxLength = 32767
        Me.Nom_txt.Multiline = False
        Me.Nom_txt.Name = "Nom_txt"
        Me.Nom_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_txt.ReadOnly = True
        Me.Nom_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_txt.SelectionStart = 0
        Me.Nom_txt.Size = New System.Drawing.Size(345, 26)
        Me.Nom_txt.TabIndex = 204
        Me.Nom_txt.TabStop = False
        Me.Nom_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_txt.UseSystemPasswordChar = False
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_txt.Location = New System.Drawing.Point(108, 21)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(130, 26)
        Me.Matricule_txt.TabIndex = 200
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(52, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 19)
        Me.Label1.TabIndex = 203
        Me.Label1.Text = "Agent"
        '
        'Recap_Pnl
        '
        Me.Recap_Pnl.Controls.Add(Me.Label8)
        Me.Recap_Pnl.Controls.Add(Me.Label9)
        Me.Recap_Pnl.Controls.Add(Me.Label10)
        Me.Recap_Pnl.Controls.Add(Me.EcartBrut_txt)
        Me.Recap_Pnl.Controls.Add(Me.BrutCalcule_txt)
        Me.Recap_Pnl.Controls.Add(Me.BrutBulletin_txt)
        Me.Recap_Pnl.Controls.Add(Me.Label7)
        Me.Recap_Pnl.Controls.Add(Me.Label6)
        Me.Recap_Pnl.Controls.Add(Me.Label5)
        Me.Recap_Pnl.Controls.Add(Me.EcartNet_txt)
        Me.Recap_Pnl.Controls.Add(Me.NetCalcul_txt)
        Me.Recap_Pnl.Controls.Add(Me.NetBulletin_txt)
        Me.Recap_Pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Recap_Pnl.Location = New System.Drawing.Point(0, 757)
        Me.Recap_Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Recap_Pnl.Name = "Recap_Pnl"
        Me.Recap_Pnl.Size = New System.Drawing.Size(966, 112)
        Me.Recap_Pnl.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(458, 71)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 19)
        Me.Label8.TabIndex = 233
        Me.Label8.Text = "Ecart"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(384, 41)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 19)
        Me.Label9.TabIndex = 234
        Me.Label9.Text = "Brut préparation"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(415, 11)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 19)
        Me.Label10.TabIndex = 235
        Me.Label10.Text = "Brut bulletin"
        '
        'EcartBrut_txt
        '
        Me.EcartBrut_txt.AccessibleDescription = "A"
        Me.EcartBrut_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.EcartBrut_txt.ContextMenuStrip = Nothing
        Me.EcartBrut_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.EcartBrut_txt.Location = New System.Drawing.Point(508, 69)
        Me.EcartBrut_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.EcartBrut_txt.MaxLength = 32767
        Me.EcartBrut_txt.Multiline = False
        Me.EcartBrut_txt.Name = "EcartBrut_txt"
        Me.EcartBrut_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.EcartBrut_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.EcartBrut_txt.ReadOnly = True
        Me.EcartBrut_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.EcartBrut_txt.SelectionStart = 0
        Me.EcartBrut_txt.Size = New System.Drawing.Size(170, 26)
        Me.EcartBrut_txt.TabIndex = 230
        Me.EcartBrut_txt.TabStop = False
        Me.EcartBrut_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EcartBrut_txt.UseSystemPasswordChar = False
        '
        'BrutCalcule_txt
        '
        Me.BrutCalcule_txt.AccessibleDescription = "A"
        Me.BrutCalcule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.BrutCalcule_txt.ContextMenuStrip = Nothing
        Me.BrutCalcule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BrutCalcule_txt.Location = New System.Drawing.Point(508, 38)
        Me.BrutCalcule_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BrutCalcule_txt.MaxLength = 32767
        Me.BrutCalcule_txt.Multiline = False
        Me.BrutCalcule_txt.Name = "BrutCalcule_txt"
        Me.BrutCalcule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.BrutCalcule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.BrutCalcule_txt.ReadOnly = True
        Me.BrutCalcule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.BrutCalcule_txt.SelectionStart = 0
        Me.BrutCalcule_txt.Size = New System.Drawing.Size(170, 26)
        Me.BrutCalcule_txt.TabIndex = 231
        Me.BrutCalcule_txt.TabStop = False
        Me.BrutCalcule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BrutCalcule_txt.UseSystemPasswordChar = False
        '
        'BrutBulletin_txt
        '
        Me.BrutBulletin_txt.AccessibleDescription = "A"
        Me.BrutBulletin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.BrutBulletin_txt.ContextMenuStrip = Nothing
        Me.BrutBulletin_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BrutBulletin_txt.Location = New System.Drawing.Point(508, 8)
        Me.BrutBulletin_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BrutBulletin_txt.MaxLength = 32767
        Me.BrutBulletin_txt.Multiline = False
        Me.BrutBulletin_txt.Name = "BrutBulletin_txt"
        Me.BrutBulletin_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.BrutBulletin_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.BrutBulletin_txt.ReadOnly = True
        Me.BrutBulletin_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.BrutBulletin_txt.SelectionStart = 0
        Me.BrutBulletin_txt.Size = New System.Drawing.Size(170, 26)
        Me.BrutBulletin_txt.TabIndex = 232
        Me.BrutBulletin_txt.TabStop = False
        Me.BrutBulletin_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BrutBulletin_txt.UseSystemPasswordChar = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(89, 71)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 19)
        Me.Label7.TabIndex = 229
        Me.Label7.Text = "Ecart"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(16, 41)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 19)
        Me.Label6.TabIndex = 229
        Me.Label6.Text = "Net préparation"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(48, 11)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 19)
        Me.Label5.TabIndex = 229
        Me.Label5.Text = "Net bulletin"
        '
        'EcartNet_txt
        '
        Me.EcartNet_txt.AccessibleDescription = "A"
        Me.EcartNet_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.EcartNet_txt.ContextMenuStrip = Nothing
        Me.EcartNet_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.EcartNet_txt.Location = New System.Drawing.Point(139, 69)
        Me.EcartNet_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.EcartNet_txt.MaxLength = 32767
        Me.EcartNet_txt.Multiline = False
        Me.EcartNet_txt.Name = "EcartNet_txt"
        Me.EcartNet_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.EcartNet_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.EcartNet_txt.ReadOnly = True
        Me.EcartNet_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.EcartNet_txt.SelectionStart = 0
        Me.EcartNet_txt.Size = New System.Drawing.Size(170, 26)
        Me.EcartNet_txt.TabIndex = 228
        Me.EcartNet_txt.TabStop = False
        Me.EcartNet_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EcartNet_txt.UseSystemPasswordChar = False
        '
        'NetCalcul_txt
        '
        Me.NetCalcul_txt.AccessibleDescription = "A"
        Me.NetCalcul_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.NetCalcul_txt.ContextMenuStrip = Nothing
        Me.NetCalcul_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.NetCalcul_txt.Location = New System.Drawing.Point(139, 38)
        Me.NetCalcul_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NetCalcul_txt.MaxLength = 32767
        Me.NetCalcul_txt.Multiline = False
        Me.NetCalcul_txt.Name = "NetCalcul_txt"
        Me.NetCalcul_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.NetCalcul_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.NetCalcul_txt.ReadOnly = True
        Me.NetCalcul_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.NetCalcul_txt.SelectionStart = 0
        Me.NetCalcul_txt.Size = New System.Drawing.Size(170, 26)
        Me.NetCalcul_txt.TabIndex = 228
        Me.NetCalcul_txt.TabStop = False
        Me.NetCalcul_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NetCalcul_txt.UseSystemPasswordChar = False
        '
        'NetBulletin_txt
        '
        Me.NetBulletin_txt.AccessibleDescription = "A"
        Me.NetBulletin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.NetBulletin_txt.ContextMenuStrip = Nothing
        Me.NetBulletin_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.NetBulletin_txt.Location = New System.Drawing.Point(139, 8)
        Me.NetBulletin_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NetBulletin_txt.MaxLength = 32767
        Me.NetBulletin_txt.Multiline = False
        Me.NetBulletin_txt.Name = "NetBulletin_txt"
        Me.NetBulletin_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.NetBulletin_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.NetBulletin_txt.ReadOnly = True
        Me.NetBulletin_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.NetBulletin_txt.SelectionStart = 0
        Me.NetBulletin_txt.Size = New System.Drawing.Size(170, 26)
        Me.NetBulletin_txt.TabIndex = 228
        Me.NetBulletin_txt.TabStop = False
        Me.NetBulletin_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NetBulletin_txt.UseSystemPasswordChar = False
        '
        'Pnl
        '
        Me.Pnl.Controls.Add(Me.MyGrd)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(0, 191)
        Me.Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(966, 566)
        Me.Pnl.TabIndex = 10
        '
        'MyGrd
        '
        Me.MyGrd.AfficherLesEntetesLignes = True
        Me.MyGrd.AllowUserToAddRows = False
        Me.MyGrd.AllowUserToDeleteRows = False
        Me.MyGrd.AlternerLesLignes = False
        Me.MyGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.MyGrd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.MyGrd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MyGrd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MyGrd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MyGrd.ColumnHeadersHeight = 30
        Me.MyGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MyGrd.DefaultCellStyle = DataGridViewCellStyle2
        Me.MyGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyGrd.EnableHeadersVisualStyles = False
        Me.MyGrd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.MyGrd.Location = New System.Drawing.Point(0, 0)
        Me.MyGrd.Margin = New System.Windows.Forms.Padding(4)
        Me.MyGrd.Name = "MyGrd"
        Me.MyGrd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.MyGrd.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.MyGrd.RowHeadersWidth = 51
        Me.MyGrd.Size = New System.Drawing.Size(966, 566)
        Me.MyGrd.TabIndex = 3
        '
        'Zoom_RH_Preparation_Paie_Saisie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(966, 869)
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.Recap_Pnl)
        Me.Controls.Add(Me.EntPnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_RH_Preparation_Paie_Saisie"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Fiche de préparation de la paie"
        Me.EntPnl.ResumeLayout(False)
        Me.EntPnl.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Recap_Pnl.ResumeLayout(False)
        Me.Recap_Pnl.PerformLayout()
        Me.Pnl.ResumeLayout(False)
        CType(Me.MyGrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EntPnl As Panel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Dat_Naissance_txt As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Nom_txt As ud_TextBox
    Friend WithEvents Bulletin_chk As ud_RadioBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Typ_Contrat_ As Label
    Friend WithEvents pbPhoto As PictureBox
    Friend WithEvents Dat_Entree_txt As ud_TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Typ_Contrat_txt As ud_TextBox
    Friend WithEvents Typ_Periode_txt As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Typ_Agent_txt As ud_TextBox
    Friend WithEvents Recap_Pnl As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents EcartBrut_txt As ud_TextBox
    Friend WithEvents BrutCalcule_txt As ud_TextBox
    Friend WithEvents BrutBulletin_txt As ud_TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents EcartNet_txt As ud_TextBox
    Friend WithEvents NetCalcul_txt As ud_TextBox
    Friend WithEvents NetBulletin_txt As ud_TextBox
    Friend WithEvents Cloture_Check As ud_CheckBox
    Friend WithEvents Pnl As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Mensuel_chk As ud_RadioBox
    Friend WithEvents MyGrd As ud_Grd
    Friend WithEvents Afficher_Rubriques_chk As ud_CheckBox
End Class
