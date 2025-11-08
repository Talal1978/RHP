<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Bulletin_Liste
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Dat_Debut = New RHP.ud_TextBox()
        Me.Dat_Fin = New RHP.ud_TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel12 = New System.Windows.Forms.LinkLabel()
        Me.SEL_CRT_GROUP = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cod_Plan_Paie_txt = New RHP.ud_TextBox()
        Me.ReportExists_Label = New System.Windows.Forms.Label()
        Me.Modele_Bulletin_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Grille = New RHP.ud_Grd()
        Me.Personnal_pnl.SuspendLayout()
        Me.SEL_CRT_GROUP.SuspendLayout()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.Controls.Add(Me.ButtonX1, 0, 0)
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(200, 100)
        Me.Personnal_pnl.TabIndex = 0
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX1.Location = New System.Drawing.Point(16, 38)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(67, 23)
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.Text = "OK"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Location = New System.Drawing.Point(36, 3)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(28, 8)
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "Annuler"
        '
        'Dat_Debut
        '
        Me.Dat_Debut.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Debut.Enabled = False
        Me.Dat_Debut.Location = New System.Drawing.Point(402, 46)
        Me.Dat_Debut.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dat_Debut.MaxLength = 32767
        Me.Dat_Debut.Multiline = False
        Me.Dat_Debut.Name = "Dat_Debut"
        Me.Dat_Debut.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Debut.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Debut.ReadOnly = False
        Me.Dat_Debut.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Debut.SelectionStart = 0
        Me.Dat_Debut.Size = New System.Drawing.Size(86, 21)
        Me.Dat_Debut.TabIndex = 200
        Me.Dat_Debut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Debut.UseSystemPasswordChar = False
        '
        'Dat_Fin
        '
        Me.Dat_Fin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Fin.Enabled = False
        Me.Dat_Fin.Location = New System.Drawing.Point(520, 46)
        Me.Dat_Fin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Dat_Fin.MaxLength = 32767
        Me.Dat_Fin.Multiline = False
        Me.Dat_Fin.Name = "Dat_Fin"
        Me.Dat_Fin.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Fin.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Fin.ReadOnly = False
        Me.Dat_Fin.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Fin.SelectionStart = 0
        Me.Dat_Fin.Size = New System.Drawing.Size(86, 21)
        Me.Dat_Fin.TabIndex = 200
        Me.Dat_Fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Fin.UseSystemPasswordChar = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(375, 48)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(23, 16)
        Me.LinkLabel4.TabIndex = 4
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = ""
        Me.LinkLabel4.Text = "Du"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel6.Location = New System.Drawing.Point(494, 49)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(22, 16)
        Me.LinkLabel6.TabIndex = 8
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Tag = ""
        Me.LinkLabel6.Text = "Au"
        '
        'LinkLabel12
        '
        Me.LinkLabel12.AutoSize = True
        Me.LinkLabel12.Location = New System.Drawing.Point(1125, 203)
        Me.LinkLabel12.Name = "LinkLabel12"
        Me.LinkLabel12.Size = New System.Drawing.Size(67, 16)
        Me.LinkLabel12.TabIndex = 28
        Me.LinkLabel12.TabStop = True
        Me.LinkLabel12.Tag = "Validé par:"
        Me.LinkLabel12.Text = "Validé par:"
        '
        'SEL_CRT_GROUP
        '
        Me.SEL_CRT_GROUP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SEL_CRT_GROUP.Controls.Add(Me.Label1)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Cod_Plan_Paie_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.ReportExists_Label)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Modele_Bulletin_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel1)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Matricule_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Nom_Agent_Text)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Matricule_)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel12)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel6)
        Me.SEL_CRT_GROUP.Controls.Add(Me.LinkLabel4)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Fin)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Dat_Debut)
        Me.SEL_CRT_GROUP.Dock = System.Windows.Forms.DockStyle.Top
        Me.SEL_CRT_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.SEL_CRT_GROUP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SEL_CRT_GROUP.Name = "SEL_CRT_GROUP"
        Me.SEL_CRT_GROUP.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SEL_CRT_GROUP.Size = New System.Drawing.Size(1073, 105)
        Me.SEL_CRT_GROUP.TabIndex = 0
        Me.SEL_CRT_GROUP.TabStop = False
        Me.SEL_CRT_GROUP.Tag = ""
        Me.SEL_CRT_GROUP.Text = "Critères de sélection"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 231
        Me.Label1.Text = "Plan"
        '
        'Cod_Plan_Paie_txt
        '
        Me.Cod_Plan_Paie_txt.AccessibleDescription = "A"
        Me.Cod_Plan_Paie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_txt.Location = New System.Drawing.Point(114, 47)
        Me.Cod_Plan_Paie_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Plan_Paie_txt.MaxLength = 32767
        Me.Cod_Plan_Paie_txt.Multiline = False
        Me.Cod_Plan_Paie_txt.Name = "Cod_Plan_Paie_txt"
        Me.Cod_Plan_Paie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_txt.ReadOnly = True
        Me.Cod_Plan_Paie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_txt.SelectionStart = 0
        Me.Cod_Plan_Paie_txt.Size = New System.Drawing.Size(236, 21)
        Me.Cod_Plan_Paie_txt.TabIndex = 230
        Me.Cod_Plan_Paie_txt.TabStop = False
        Me.Cod_Plan_Paie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_txt.UseSystemPasswordChar = False
        '
        'ReportExists_Label
        '
        Me.ReportExists_Label.AutoSize = True
        Me.ReportExists_Label.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportExists_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ReportExists_Label.Location = New System.Drawing.Point(355, 75)
        Me.ReportExists_Label.Name = "ReportExists_Label"
        Me.ReportExists_Label.Size = New System.Drawing.Size(133, 15)
        Me.ReportExists_Label.TabIndex = 229
        Me.ReportExists_Label.Text = "Ce modèle n'existe pas."
        Me.ReportExists_Label.Visible = False
        '
        'Modele_Bulletin_txt
        '
        Me.Modele_Bulletin_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Modele_Bulletin_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Modele_Bulletin_txt.Location = New System.Drawing.Point(114, 72)
        Me.Modele_Bulletin_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Modele_Bulletin_txt.MaxLength = 32767
        Me.Modele_Bulletin_txt.Multiline = False
        Me.Modele_Bulletin_txt.Name = "Modele_Bulletin_txt"
        Me.Modele_Bulletin_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Modele_Bulletin_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Modele_Bulletin_txt.ReadOnly = True
        Me.Modele_Bulletin_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Modele_Bulletin_txt.SelectionStart = 0
        Me.Modele_Bulletin_txt.Size = New System.Drawing.Size(236, 21)
        Me.Modele_Bulletin_txt.TabIndex = 228
        Me.Modele_Bulletin_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Modele_Bulletin_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(19, 75)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(92, 16)
        Me.LinkLabel1.TabIndex = 227
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Modèle bulletin"
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.Location = New System.Drawing.Point(114, 22)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(121, 21)
        Me.Matricule_txt.TabIndex = 224
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(237, 22)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = False
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(370, 21)
        Me.Nom_Agent_Text.TabIndex = 226
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(51, 25)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(59, 16)
        Me.Matricule_.TabIndex = 225
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        '
        'Grille
        '
        Me.Grille.AllowUserToAddRows = False
        Me.Grille.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grille.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grille.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grille.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grille.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grille.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grille.EnableHeadersVisualStyles = False
        Me.Grille.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grille.Location = New System.Drawing.Point(0, 105)
        Me.Grille.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grille.Name = "Grille"
        Me.Grille.ReadOnly = True
        Me.Grille.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grille.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grille.Size = New System.Drawing.Size(1073, 679)
        Me.Grille.TabIndex = 2
        '
        'RH_Bulletin_Liste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 784)
        Me.Controls.Add(Me.Grille)
        Me.Controls.Add(Me.SEL_CRT_GROUP)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "RH_Bulletin_Liste"
        Me.Tag = "ECR"
        Me.Text = "Bulletin de paie"
        Me.Personnal_pnl.ResumeLayout(False)
        Me.SEL_CRT_GROUP.ResumeLayout(False)
        Me.SEL_CRT_GROUP.PerformLayout()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dat_Debut As ud_TextBox
    Friend WithEvents Dat_Fin As ud_TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents LinkLabel12 As LinkLabel
    Friend WithEvents SEL_CRT_GROUP As GroupBox
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Grille As ud_Grd
    Friend WithEvents Modele_Bulletin_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents ReportExists_Label As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Cod_Plan_Paie_txt As ud_TextBox
End Class
