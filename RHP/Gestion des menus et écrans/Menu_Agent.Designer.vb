<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Menu_Agent
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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ma fiche")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ma fiche de poste")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Organigramme")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Demandes de congé")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Demande d'avance")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Demande de prêt")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Dossiers de maladie")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Note de frais")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mes demandes et documents", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Edition de bulletins de paie")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultations", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode10})
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("On m'évalue")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("J'évalue")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mes évaluations", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode13})
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Evaluer une formation", 8, 8)
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Formations", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode15})
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mon espace personnel", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode9, TreeNode11, TreeNode14, TreeNode16})
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Demandes de recrutement")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Entretien")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recrutement", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode18, TreeNode19})
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Agenda")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mon parapheur de signatures", 23, 23)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Modifier mon mot de passe", 21, 21)
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Désignation de suppléant", 22, 22)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_Agent))
        Me.Trv_MonEspace = New System.Windows.Forms.TreeView()
        Me.myImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.menuPnl = New System.Windows.Forms.Panel()
        Me.infoAccueil_lbl = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Personnel_pb = New System.Windows.Forms.PictureBox()
        Me.chemin_lbl = New System.Windows.Forms.Label()
        Me.pb_logo = New System.Windows.Forms.PictureBox()
        Me.Content_pnl = New System.Windows.Forms.Panel()
        Me.pnl_sideBarL = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Déconnexion = New System.Windows.Forms.Label()
        Me.pblogout = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbchangePwd = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbParapheur = New System.Windows.Forms.PictureBox()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Personnel_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Content_pnl.SuspendLayout()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.pblogout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbchangePwd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbParapheur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Trv_MonEspace
        '
        Me.Trv_MonEspace.Dock = System.Windows.Forms.DockStyle.Left
        Me.Trv_MonEspace.ImageIndex = 0
        Me.Trv_MonEspace.ImageList = Me.myImgList
        Me.Trv_MonEspace.ItemHeight = 23
        Me.Trv_MonEspace.Location = New System.Drawing.Point(0, 3)
        Me.Trv_MonEspace.Margin = New System.Windows.Forms.Padding(6)
        Me.Trv_MonEspace.Name = "Trv_MonEspace"
        TreeNode1.ImageIndex = 6
        TreeNode1.Name = "RH_Agent"
        TreeNode1.SelectedImageKey = "em_b.png"
        TreeNode1.Text = "Ma fiche"
        TreeNode2.ImageKey = "ECR.png"
        TreeNode2.Name = "Org_FichePoste"
        TreeNode2.SelectedImageKey = "ECR.png"
        TreeNode2.Text = "Ma fiche de poste"
        TreeNode3.ImageIndex = 14
        TreeNode3.Name = "Org_Organigramme"
        TreeNode3.SelectedImageKey = "Gantt.png"
        TreeNode3.Text = "Organigramme"
        TreeNode4.ImageIndex = 8
        TreeNode4.Name = "RH_Demande_Conge_Liste"
        TreeNode4.SelectedImageKey = "ECR.png"
        TreeNode4.Text = "Demandes de congé"
        TreeNode5.ImageKey = "ECR.png"
        TreeNode5.Name = "RH_Demande_Avance_Liste"
        TreeNode5.SelectedImageKey = "ECR.png"
        TreeNode5.Text = "Demande d'avance"
        TreeNode6.ImageKey = "ECR.png"
        TreeNode6.Name = "RH_Demande_Pret_Liste"
        TreeNode6.SelectedImageKey = "ECR.png"
        TreeNode6.Text = "Demande de prêt"
        TreeNode7.ImageKey = "ECR.png"
        TreeNode7.Name = "RH_Dossier_Maladie_Liste"
        TreeNode7.SelectedImageKey = "ECR.png"
        TreeNode7.Text = "Dossiers de maladie"
        TreeNode8.ImageKey = "ECR.png"
        TreeNode8.Name = "Note_Frais_Liste"
        TreeNode8.SelectedImageKey = "ECR.png"
        TreeNode8.Text = "Note de frais"
        TreeNode9.ImageIndex = 2
        TreeNode9.Name = "MesDemandes"
        TreeNode9.SelectedImageIndex = 2
        TreeNode9.Text = "Mes demandes et documents"
        TreeNode10.ImageKey = "Menu_Personnel.png"
        TreeNode10.Name = "RH_Bulletin_Liste"
        TreeNode10.SelectedImageKey = "Menu_Personnel.png"
        TreeNode10.Text = "Edition de bulletins de paie"
        TreeNode11.ImageIndex = 2
        TreeNode11.Name = "mesConsultations"
        TreeNode11.SelectedImageIndex = 2
        TreeNode11.Text = "Consultations"
        TreeNode12.ImageKey = "ECR.png"
        TreeNode12.Name = "onMeValue"
        TreeNode12.SelectedImageKey = "ECR.png"
        TreeNode12.Text = "On m'évalue"
        TreeNode13.ImageKey = "ECR.png"
        TreeNode13.Name = "JeValue"
        TreeNode13.SelectedImageKey = "ECR.png"
        TreeNode13.Text = "J'évalue"
        TreeNode14.ImageIndex = 2
        TreeNode14.Name = "mesEvaluations"
        TreeNode14.SelectedImageIndex = 2
        TreeNode14.Text = "Mes évaluations"
        TreeNode15.ImageIndex = 8
        TreeNode15.Name = "Formation_Evaluation"
        TreeNode15.SelectedImageIndex = 8
        TreeNode15.Text = "Evaluer une formation"
        TreeNode16.ImageIndex = 2
        TreeNode16.Name = "Formations"
        TreeNode16.SelectedImageIndex = 2
        TreeNode16.Text = "Formations"
        TreeNode17.Name = "MySpace"
        TreeNode17.Text = "Mon espace personnel"
        TreeNode18.ImageKey = "ECR.png"
        TreeNode18.Name = "Recrutement_Demande_Liste"
        TreeNode18.SelectedImageKey = "ECR.png"
        TreeNode18.Text = "Demandes de recrutement"
        TreeNode19.ImageKey = "ECR.png"
        TreeNode19.Name = "Entretien"
        TreeNode19.SelectedImageKey = "ECR.png"
        TreeNode19.Text = "Entretien"
        TreeNode20.ImageIndex = 2
        TreeNode20.Name = "Recrutement_fdr"
        TreeNode20.SelectedImageIndex = 2
        TreeNode20.Text = "Recrutement"
        TreeNode21.ImageKey = "calendar.png"
        TreeNode21.Name = "Agenda"
        TreeNode21.SelectedImageKey = "calendar.png"
        TreeNode21.Text = "Agenda"
        TreeNode22.ImageIndex = 23
        TreeNode22.Name = "Agent_Parapheur"
        TreeNode22.SelectedImageIndex = 23
        TreeNode22.Text = "Mon parapheur de signatures"
        TreeNode23.ImageIndex = 21
        TreeNode23.Name = "Admin_ChangePwd_Agent"
        TreeNode23.SelectedImageIndex = 21
        TreeNode23.Text = "Modifier mon mot de passe"
        TreeNode24.ImageIndex = 22
        TreeNode24.Name = "Agent_Suppleant"
        TreeNode24.SelectedImageIndex = 22
        TreeNode24.Text = "Désignation de suppléant"
        Me.Trv_MonEspace.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode17, TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode24})
        Me.Trv_MonEspace.SelectedImageIndex = 0
        Me.Trv_MonEspace.Size = New System.Drawing.Size(333, 670)
        Me.Trv_MonEspace.TabIndex = 7
        '
        'myImgList
        '
        Me.myImgList.ImageStream = CType(resources.GetObject("myImgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.myImgList.TransparentColor = System.Drawing.Color.Transparent
        Me.myImgList.Images.SetKeyName(0, "logo rhp 200x150.png")
        Me.myImgList.Images.SetKeyName(1, "Menu_Personnel.png")
        Me.myImgList.Images.SetKeyName(2, "fdr_1.png")
        Me.myImgList.Images.SetKeyName(3, "FILE.png")
        Me.myImgList.Images.SetKeyName(4, "ef_b.png")
        Me.myImgList.Images.SetKeyName(5, "ef_e.png")
        Me.myImgList.Images.SetKeyName(6, "em_b.png")
        Me.myImgList.Images.SetKeyName(7, "em_e.png")
        Me.myImgList.Images.SetKeyName(8, "ECR.png")
        Me.myImgList.Images.SetKeyName(9, "EXP.png")
        Me.myImgList.Images.SetKeyName(10, "right.png")
        Me.myImgList.Images.SetKeyName(11, "Favoris.png")
        Me.myImgList.Images.SetKeyName(12, "fdr_0.png")
        Me.myImgList.Images.SetKeyName(13, "fdr_1.png")
        Me.myImgList.Images.SetKeyName(14, "Gantt.png")
        Me.myImgList.Images.SetKeyName(15, "GED.png")
        Me.myImgList.Images.SetKeyName(16, "Grd_Filtree.png")
        Me.myImgList.Images.SetKeyName(17, "greenbutton.png")
        Me.myImgList.Images.SetKeyName(18, "Menu_Operationnel.png")
        Me.myImgList.Images.SetKeyName(19, "Partenaires.png")
        Me.myImgList.Images.SetKeyName(20, "recherche.png")
        Me.myImgList.Images.SetKeyName(21, "lock.png")
        Me.myImgList.Images.SetKeyName(22, "btn_insert.png")
        Me.myImgList.Images.SetKeyName(23, "btn_sign.png")
        Me.myImgList.Images.SetKeyName(24, "calendar.png")
        '
        'menuPnl
        '
        Me.menuPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.menuPnl.BackgroundImage = CType(resources.GetObject("menuPnl.BackgroundImage"), System.Drawing.Image)
        Me.menuPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.menuPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.menuPnl.Location = New System.Drawing.Point(333, 53)
        Me.menuPnl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.menuPnl.Name = "menuPnl"
        Me.menuPnl.Size = New System.Drawing.Size(1207, 620)
        Me.menuPnl.TabIndex = 10
        '
        'infoAccueil_lbl
        '
        Me.infoAccueil_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.infoAccueil_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.infoAccueil_lbl.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoAccueil_lbl.ForeColor = System.Drawing.Color.White
        Me.infoAccueil_lbl.Location = New System.Drawing.Point(0, 0)
        Me.infoAccueil_lbl.Margin = New System.Windows.Forms.Padding(0)
        Me.infoAccueil_lbl.Name = "infoAccueil_lbl"
        Me.infoAccueil_lbl.Padding = New System.Windows.Forms.Padding(10)
        Me.infoAccueil_lbl.Size = New System.Drawing.Size(333, 64)
        Me.infoAccueil_lbl.TabIndex = 9
        Me.infoAccueil_lbl.Text = "Bonjour M."
        Me.infoAccueil_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ent_pnl.ColumnCount = 4
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 333.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.ent_pnl.Controls.Add(Me.Personnel_pb, 2, 0)
        Me.ent_pnl.Controls.Add(Me.chemin_lbl, 0, 0)
        Me.ent_pnl.Controls.Add(Me.pb_logo, 3, 0)
        Me.ent_pnl.Controls.Add(Me.infoAccueil_lbl, 0, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(0, 0)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(1540, 64)
        Me.ent_pnl.TabIndex = 10
        '
        'Personnel_pb
        '
        Me.Personnel_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Personnel_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Personnel_pb.Image = Global.RHP.My.Resources.Resources.btn_personnel_w
        Me.Personnel_pb.Location = New System.Drawing.Point(1383, 3)
        Me.Personnel_pb.Name = "Personnel_pb"
        Me.Personnel_pb.Size = New System.Drawing.Size(74, 58)
        Me.Personnel_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Personnel_pb.TabIndex = 13
        Me.Personnel_pb.TabStop = False
        '
        'chemin_lbl
        '
        Me.chemin_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.chemin_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chemin_lbl.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chemin_lbl.ForeColor = System.Drawing.Color.White
        Me.chemin_lbl.Location = New System.Drawing.Point(333, 0)
        Me.chemin_lbl.Margin = New System.Windows.Forms.Padding(0)
        Me.chemin_lbl.Name = "chemin_lbl"
        Me.chemin_lbl.Size = New System.Drawing.Size(1047, 64)
        Me.chemin_lbl.TabIndex = 12
        Me.chemin_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_logo
        '
        Me.pb_logo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_logo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb_logo.Image = CType(resources.GetObject("pb_logo.Image"), System.Drawing.Image)
        Me.pb_logo.Location = New System.Drawing.Point(1463, 3)
        Me.pb_logo.Name = "pb_logo"
        Me.pb_logo.Size = New System.Drawing.Size(74, 58)
        Me.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pb_logo.TabIndex = 10
        Me.pb_logo.TabStop = False
        '
        'Content_pnl
        '
        Me.Content_pnl.Controls.Add(Me.menuPnl)
        Me.Content_pnl.Controls.Add(Me.pnl_sideBarL)
        Me.Content_pnl.Controls.Add(Me.Trv_MonEspace)
        Me.Content_pnl.Controls.Add(Me.Splitter1)
        Me.Content_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Content_pnl.Location = New System.Drawing.Point(0, 64)
        Me.Content_pnl.Name = "Content_pnl"
        Me.Content_pnl.Size = New System.Drawing.Size(1540, 673)
        Me.Content_pnl.TabIndex = 0
        '
        'pnl_sideBarL
        '
        Me.pnl_sideBarL.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.pnl_sideBarL.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_sideBarL.Location = New System.Drawing.Point(333, 3)
        Me.pnl_sideBarL.Name = "pnl_sideBarL"
        Me.pnl_sideBarL.Size = New System.Drawing.Size(1207, 50)
        Me.pnl_sideBarL.TabIndex = 2
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1540, 3)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.5!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.5!))
        Me.Personnal_pnl.Controls.Add(Me.Déconnexion, 1, 2)
        Me.Personnal_pnl.Controls.Add(Me.pblogout, 0, 2)
        Me.Personnal_pnl.Controls.Add(Me.Label2, 1, 1)
        Me.Personnal_pnl.Controls.Add(Me.pbchangePwd, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Label1, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.pbParapheur, 0, 1)
        Me.Personnal_pnl.Location = New System.Drawing.Point(1170, 65)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 3
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(291, 182)
        Me.Personnal_pnl.TabIndex = 1
        Me.Personnal_pnl.Visible = False
        '
        'Déconnexion
        '
        Me.Déconnexion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Déconnexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Déconnexion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Déconnexion.ForeColor = System.Drawing.Color.White
        Me.Déconnexion.Location = New System.Drawing.Point(56, 120)
        Me.Déconnexion.Name = "Déconnexion"
        Me.Déconnexion.Size = New System.Drawing.Size(232, 62)
        Me.Déconnexion.TabIndex = 4
        Me.Déconnexion.Text = "Déconnexion"
        Me.Déconnexion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pblogout
        '
        Me.pblogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pblogout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pblogout.Image = CType(resources.GetObject("pblogout.Image"), System.Drawing.Image)
        Me.pblogout.Location = New System.Drawing.Point(3, 123)
        Me.pblogout.Name = "pblogout"
        Me.pblogout.Size = New System.Drawing.Size(47, 56)
        Me.pblogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pblogout.TabIndex = 3
        Me.pblogout.TabStop = False
        '
        'Label2
        '
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(56, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 60)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Parapheur"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbchangePwd
        '
        Me.pbchangePwd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbchangePwd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbchangePwd.Image = CType(resources.GetObject("pbchangePwd.Image"), System.Drawing.Image)
        Me.pbchangePwd.Location = New System.Drawing.Point(3, 3)
        Me.pbchangePwd.Name = "pbchangePwd"
        Me.pbchangePwd.Size = New System.Drawing.Size(47, 54)
        Me.pbchangePwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbchangePwd.TabIndex = 0
        Me.pbchangePwd.TabStop = False
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(56, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 60)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Changer le mot de passe"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbParapheur
        '
        Me.pbParapheur.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbParapheur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbParapheur.Image = CType(resources.GetObject("pbParapheur.Image"), System.Drawing.Image)
        Me.pbParapheur.Location = New System.Drawing.Point(3, 63)
        Me.pbParapheur.Name = "pbParapheur"
        Me.pbParapheur.Size = New System.Drawing.Size(47, 54)
        Me.pbParapheur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbParapheur.TabIndex = 0
        Me.pbParapheur.TabStop = False
        '
        'Menu_Agent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1540, 737)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Controls.Add(Me.Content_pnl)
        Me.Controls.Add(Me.ent_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Menu_Agent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu agent"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Personnel_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Content_pnl.ResumeLayout(False)
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.pblogout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbchangePwd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbParapheur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Trv_MonEspace As TreeView
    Friend WithEvents myImgList As ImageList
    Friend WithEvents menuPnl As Panel
    Friend WithEvents infoAccueil_lbl As Label
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Content_pnl As Panel
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents pnl_sideBarL As Panel
    Friend WithEvents pb_logo As PictureBox
    Friend WithEvents chemin_lbl As Label
    Dim Agent_Parapheur As New System.Windows.Forms.TreeNode
    Friend WithEvents Personnel_pb As PictureBox
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Déconnexion As Label
    Friend WithEvents pblogout As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pbchangePwd As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pbParapheur As PictureBox
End Class
