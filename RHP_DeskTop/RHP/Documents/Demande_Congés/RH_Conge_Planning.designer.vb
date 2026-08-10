<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Conge_Planning
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Planning_Grd = New RHP.ud_Grd()
        Me.SEL_CRT_GROUP = New System.Windows.Forms.GroupBox()
        Me.Aujourdhui_lbl = New System.Windows.Forms.LinkLabel()
        Me.Mois_Suiv_pb = New System.Windows.Forms.PictureBox()
        Me.Mois_lbl = New System.Windows.Forms.Label()
        Me.Mois_Prec_pb = New System.Windows.Forms.PictureBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Entite_lbl = New System.Windows.Forms.LinkLabel()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Legend_pnl = New System.Windows.Forms.Panel()
        Me.Leg_Repos_lbl = New System.Windows.Forms.Label()
        Me.Leg_Repos_pnl = New System.Windows.Forms.Label()
        Me.Leg_Ferie_lbl = New System.Windows.Forms.Label()
        Me.Leg_Ferie_pnl = New System.Windows.Forms.Label()
        Me.Leg_CongeAttente_lbl = New System.Windows.Forms.Label()
        Me.Leg_CongeAttente_pnl = New System.Windows.Forms.Label()
        Me.Leg_CongeValide_lbl = New System.Windows.Forms.Label()
        Me.Leg_CongeValide_pnl = New System.Windows.Forms.Label()
        CType(Me.Planning_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SEL_CRT_GROUP.SuspendLayout()
        Me.Legend_pnl.SuspendLayout()
        CType(Me.Mois_Suiv_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mois_Prec_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Planning_Grd
        '
        Me.Planning_Grd.AfficherLesEntetesLignes = False
        Me.Planning_Grd.AllowUserToAddRows = False
        Me.Planning_Grd.AllowUserToDeleteRows = False
        Me.Planning_Grd.AllowUserToOrderColumns = False
        Me.Planning_Grd.AllowUserToResizeRows = False
        Me.Planning_Grd.AlternerLesLignes = False
        Me.Planning_Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.Planning_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Planning_Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Planning_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Planning_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Planning_Grd.DefaultCellStyle = DataGridViewCellStyle1
        Me.Planning_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Planning_Grd.EnableHeadersVisualStyles = False
        Me.Planning_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Planning_Grd.Location = New System.Drawing.Point(0, 100)
        Me.Planning_Grd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Planning_Grd.Name = "Planning_Grd"
        Me.Planning_Grd.ReadOnly = True
        Me.Planning_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Planning_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Planning_Grd.RowHeadersVisible = False
        Me.Planning_Grd.Size = New System.Drawing.Size(1520, 642)
        Me.Planning_Grd.TabIndex = 2
        '
        'SEL_CRT_GROUP
        '
        Me.SEL_CRT_GROUP.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SEL_CRT_GROUP.Controls.Add(Me.Aujourdhui_lbl)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Mois_Suiv_pb)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Mois_lbl)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Mois_Prec_pb)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Lib_Entite_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Cod_Entite_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Entite_lbl)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Nom_Agent_Text)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Matricule_txt)
        Me.SEL_CRT_GROUP.Controls.Add(Me.Matricule_)
        Me.SEL_CRT_GROUP.Dock = System.Windows.Forms.DockStyle.Top
        Me.SEL_CRT_GROUP.Location = New System.Drawing.Point(0, 0)
        Me.SEL_CRT_GROUP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SEL_CRT_GROUP.Name = "SEL_CRT_GROUP"
        Me.SEL_CRT_GROUP.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SEL_CRT_GROUP.Size = New System.Drawing.Size(1520, 100)
        Me.SEL_CRT_GROUP.TabIndex = 0
        Me.SEL_CRT_GROUP.TabStop = False
        Me.SEL_CRT_GROUP.Tag = ""
        Me.SEL_CRT_GROUP.Text = "Critères de sélection"
        '
        'Aujourdhui_lbl
        '
        Me.Aujourdhui_lbl.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Aujourdhui_lbl.AutoSize = True
        Me.Aujourdhui_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Aujourdhui_lbl.LinkColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Aujourdhui_lbl.Location = New System.Drawing.Point(960, 32)
        Me.Aujourdhui_lbl.Name = "Aujourdhui_lbl"
        Me.Aujourdhui_lbl.Size = New System.Drawing.Size(74, 19)
        Me.Aujourdhui_lbl.TabIndex = 9
        Me.Aujourdhui_lbl.TabStop = True
        Me.Aujourdhui_lbl.Text = "Aujourd'hui"
        '
        'Mois_Suiv_pb
        '
        Me.Mois_Suiv_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Mois_Suiv_pb.Image = Global.RHP.My.Resources.Resources.btn_div_next
        Me.Mois_Suiv_pb.Location = New System.Drawing.Point(925, 24)
        Me.Mois_Suiv_pb.Name = "Mois_Suiv_pb"
        Me.Mois_Suiv_pb.Size = New System.Drawing.Size(26, 30)
        Me.Mois_Suiv_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Mois_Suiv_pb.TabIndex = 8
        Me.Mois_Suiv_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Mois_Suiv_pb, "Mois suivant")
        '
        'Mois_lbl
        '
        Me.Mois_lbl.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Mois_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Mois_lbl.Location = New System.Drawing.Point(750, 28)
        Me.Mois_lbl.Name = "Mois_lbl"
        Me.Mois_lbl.Size = New System.Drawing.Size(170, 23)
        Me.Mois_lbl.TabIndex = 7
        Me.Mois_lbl.Text = "Mois"
        Me.Mois_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Mois_Prec_pb
        '
        Me.Mois_Prec_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Mois_Prec_pb.Image = Global.RHP.My.Resources.Resources.btn_div_back
        Me.Mois_Prec_pb.Location = New System.Drawing.Point(716, 24)
        Me.Mois_Prec_pb.Name = "Mois_Prec_pb"
        Me.Mois_Prec_pb.Size = New System.Drawing.Size(26, 30)
        Me.Mois_Prec_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Mois_Prec_pb.TabIndex = 6
        Me.Mois_Prec_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Mois_Prec_pb, "Mois précédent")
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.AccessibleDescription = "A"
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(222, 60)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Entite_txt.MaxLength = 32767
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(420, 21)
        Me.Lib_Entite_txt.TabIndex = 5
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(99, 60)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Entite_txt.MaxLength = 32767
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(121, 21)
        Me.Cod_Entite_txt.TabIndex = 4
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Entite_lbl
        '
        Me.Entite_lbl.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_lbl.AutoSize = True
        Me.Entite_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_lbl.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Entite_lbl.Location = New System.Drawing.Point(19, 61)
        Me.Entite_lbl.Name = "Entite_lbl"
        Me.Entite_lbl.Size = New System.Drawing.Size(48, 19)
        Me.Entite_lbl.TabIndex = 3
        Me.Entite_lbl.TabStop = True
        Me.Entite_lbl.Tag = ""
        Me.Entite_lbl.Text = "Entité"
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(222, 29)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(420, 21)
        Me.Nom_Agent_Text.TabIndex = 2
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(99, 29)
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
        Me.Matricule_txt.TabIndex = 1
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(19, 30)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 0
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = ""
        Me.Matricule_.Text = "Matricule"
        '
        'Legend_pnl
        '
        Me.Legend_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Legend_pnl.Controls.Add(Me.Leg_Repos_lbl)
        Me.Legend_pnl.Controls.Add(Me.Leg_Repos_pnl)
        Me.Legend_pnl.Controls.Add(Me.Leg_Ferie_lbl)
        Me.Legend_pnl.Controls.Add(Me.Leg_Ferie_pnl)
        Me.Legend_pnl.Controls.Add(Me.Leg_CongeAttente_lbl)
        Me.Legend_pnl.Controls.Add(Me.Leg_CongeAttente_pnl)
        Me.Legend_pnl.Controls.Add(Me.Leg_CongeValide_lbl)
        Me.Legend_pnl.Controls.Add(Me.Leg_CongeValide_pnl)
        Me.Legend_pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Legend_pnl.Location = New System.Drawing.Point(0, 742)
        Me.Legend_pnl.Name = "Legend_pnl"
        Me.Legend_pnl.Size = New System.Drawing.Size(1520, 42)
        Me.Legend_pnl.TabIndex = 3
        '
        'Leg_Repos_lbl
        '
        Me.Leg_Repos_lbl.AutoSize = True
        Me.Leg_Repos_lbl.Location = New System.Drawing.Point(1006, 12)
        Me.Leg_Repos_lbl.Name = "Leg_Repos_lbl"
        Me.Leg_Repos_lbl.Size = New System.Drawing.Size(128, 19)
        Me.Leg_Repos_lbl.TabIndex = 7
        Me.Leg_Repos_lbl.Text = "Repos hebdomadaire"
        '
        'Leg_Repos_pnl
        '
        Me.Leg_Repos_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Leg_Repos_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Leg_Repos_pnl.Location = New System.Drawing.Point(982, 12)
        Me.Leg_Repos_pnl.Name = "Leg_Repos_pnl"
        Me.Leg_Repos_pnl.Size = New System.Drawing.Size(18, 18)
        Me.Leg_Repos_pnl.TabIndex = 6
        '
        'Leg_Ferie_lbl
        '
        Me.Leg_Ferie_lbl.AutoSize = True
        Me.Leg_Ferie_lbl.Location = New System.Drawing.Point(788, 12)
        Me.Leg_Ferie_lbl.Name = "Leg_Ferie_lbl"
        Me.Leg_Ferie_lbl.Size = New System.Drawing.Size(63, 19)
        Me.Leg_Ferie_lbl.TabIndex = 5
        Me.Leg_Ferie_lbl.Text = "Jour férié"
        '
        'Leg_Ferie_pnl
        '
        Me.Leg_Ferie_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Leg_Ferie_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Leg_Ferie_pnl.Location = New System.Drawing.Point(764, 12)
        Me.Leg_Ferie_pnl.Name = "Leg_Ferie_pnl"
        Me.Leg_Ferie_pnl.Size = New System.Drawing.Size(18, 18)
        Me.Leg_Ferie_pnl.TabIndex = 4
        '
        'Leg_CongeAttente_lbl
        '
        Me.Leg_CongeAttente_lbl.AutoSize = True
        Me.Leg_CongeAttente_lbl.Location = New System.Drawing.Point(536, 12)
        Me.Leg_CongeAttente_lbl.Name = "Leg_CongeAttente_lbl"
        Me.Leg_CongeAttente_lbl.Size = New System.Drawing.Size(109, 19)
        Me.Leg_CongeAttente_lbl.TabIndex = 3
        Me.Leg_CongeAttente_lbl.Text = "Congé en attente"
        '
        'Leg_CongeAttente_pnl
        '
        Me.Leg_CongeAttente_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.Leg_CongeAttente_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Leg_CongeAttente_pnl.Location = New System.Drawing.Point(512, 12)
        Me.Leg_CongeAttente_pnl.Name = "Leg_CongeAttente_pnl"
        Me.Leg_CongeAttente_pnl.Size = New System.Drawing.Size(18, 18)
        Me.Leg_CongeAttente_pnl.TabIndex = 2
        '
        'Leg_CongeValide_lbl
        '
        Me.Leg_CongeValide_lbl.AutoSize = True
        Me.Leg_CongeValide_lbl.Location = New System.Drawing.Point(314, 12)
        Me.Leg_CongeValide_lbl.Name = "Leg_CongeValide_lbl"
        Me.Leg_CongeValide_lbl.Size = New System.Drawing.Size(89, 19)
        Me.Leg_CongeValide_lbl.TabIndex = 1
        Me.Leg_CongeValide_lbl.Text = "Congé validé"
        '
        'Leg_CongeValide_pnl
        '
        Me.Leg_CongeValide_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.Leg_CongeValide_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Leg_CongeValide_pnl.Location = New System.Drawing.Point(290, 12)
        Me.Leg_CongeValide_pnl.Name = "Leg_CongeValide_pnl"
        Me.Leg_CongeValide_pnl.Size = New System.Drawing.Size(18, 18)
        Me.Leg_CongeValide_pnl.TabIndex = 0
        '
        'RH_Conge_Planning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1520, 784)
        Me.Controls.Add(Me.Planning_Grd)
        Me.Controls.Add(Me.Legend_pnl)
        Me.Controls.Add(Me.SEL_CRT_GROUP)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "RH_Conge_Planning"
        Me.Tag = "ECR"
        Me.Text = "Planning des congés"
        CType(Me.Planning_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SEL_CRT_GROUP.ResumeLayout(False)
        Me.SEL_CRT_GROUP.PerformLayout()
        Me.Legend_pnl.ResumeLayout(False)
        Me.Legend_pnl.PerformLayout()
        CType(Me.Mois_Suiv_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mois_Prec_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Planning_Grd As ud_Grd
    Friend WithEvents SEL_CRT_GROUP As GroupBox
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Entite_lbl As LinkLabel
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Mois_Prec_pb As PictureBox
    Friend WithEvents Mois_lbl As Label
    Friend WithEvents Mois_Suiv_pb As PictureBox
    Friend WithEvents Aujourdhui_lbl As LinkLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Legend_pnl As Panel
    Friend WithEvents Leg_CongeValide_lbl As Label
    Friend WithEvents Leg_CongeValide_pnl As Label
    Friend WithEvents Leg_CongeAttente_lbl As Label
    Friend WithEvents Leg_CongeAttente_pnl As Label
    Friend WithEvents Leg_Ferie_lbl As Label
    Friend WithEvents Leg_Ferie_pnl As Label
    Friend WithEvents Leg_Repos_lbl As Label
    Friend WithEvents Leg_Repos_pnl As Label
End Class
