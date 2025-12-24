Imports System.ComponentModel
Imports System.Runtime.CompilerServices

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cnss_DamanCom
    inherits Ecran

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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Permanents = New System.Windows.Forms.TabPage()
        Me.Grd_Entrants = New RHP.ud_Grd()
        Me.Num_Assure_E = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom_E = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prenom_E = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Num_CIN_E = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nbr_Jours_E = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sal_Reel_E = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sal_Plaf_E = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entrants = New System.Windows.Forms.TabPage()
        Me.Grd_Permanent = New RHP.ud_Grd()
        Me.Num_Assure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prenom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.N_Enfants = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AF_A_Payer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AF_A_Deduire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AF_Net_A_Payer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AF_A_Reverser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jours_Declares = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salaire_Reel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salaire_Plaf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Situation = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ImportData = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Dat_Import_Entrant_txt = New RHP.ud_TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Lib_Agence_txt = New RHP.ud_TextBox()
        Me.Source_Preetabli_chk = New RHP.ud_CheckBox()
        Me.Date_Exig_txt = New RHP.ud_TextBox()
        Me.ExigibleLe_lbl = New System.Windows.Forms.Label()
        Me.Dat_Import_Permanent_txt = New RHP.ud_TextBox()
        Me.Dat_Import_Preetabli_txt = New RHP.ud_TextBox()
        Me.Date_Emission_txt = New RHP.ud_TextBox()
        Me.EmisLe_lbl = New System.Windows.Forms.Label()
        Me.Agence_txt = New RHP.ud_TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CP_txt = New RHP.ud_TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Ville_txt = New RHP.ud_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Adresse_txt = New RHP.ud_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Activite_txt = New RHP.ud_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Raison_Sociale_txt = New RHP.ud_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Periode_Cbo = New RHP.ud_ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Annee = New System.Windows.Forms.NumericUpDown()
        Me.Num_Affilie_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Identif_Transfert_Text = New RHP.ud_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbValide = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AddAgence_btn = New RHP.ud_button()
        Me.TabControl1.SuspendLayout()
        Me.Permanents.SuspendLayout()
        CType(Me.Grd_Entrants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Entrants.SuspendLayout()
        CType(Me.Grd_Permanent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Annee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbValide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Permanents)
        Me.TabControl1.Controls.Add(Me.Entrants)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 138)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1337, 588)
        Me.TabControl1.TabIndex = 2
        '
        'Permanents
        '
        Me.Permanents.Controls.Add(Me.Grd_Permanent)
        Me.Permanents.Location = New System.Drawing.Point(4, 25)
        Me.Permanents.Name = "Permanents"
        Me.Permanents.Padding = New System.Windows.Forms.Padding(3)
        Me.Permanents.Size = New System.Drawing.Size(1329, 559)
        Me.Permanents.TabIndex = 0
        Me.Permanents.Text = "Détail de la déclarations sociale"
        Me.Permanents.UseVisualStyleBackColor = True
        '
        'Grd_Entrants
        '
        Me.Grd_Entrants.AfficherLesEntetesLignes = True
        Me.Grd_Entrants.AllowUserToOrderColumns = True
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd_Entrants.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15
        Me.Grd_Entrants.AlternerLesLignes = False
        Me.Grd_Entrants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Entrants.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Entrants.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Entrants.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Entrants.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.Grd_Entrants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Entrants.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Num_Assure_E, Me.Nom_E, Me.Prenom_E, Me.Num_CIN_E, Me.Nbr_Jours_E, Me.Sal_Reel_E, Me.Sal_Plaf_E})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Entrants.DefaultCellStyle = DataGridViewCellStyle20
        Me.Grd_Entrants.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Entrants.EnableHeadersVisualStyles = False
        Me.Grd_Entrants.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Entrants.Location = New System.Drawing.Point(3, 3)
        Me.Grd_Entrants.Name = "Grd_Entrants"
        Me.Grd_Entrants.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Entrants.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.Grd_Entrants.Size = New System.Drawing.Size(1323, 553)
        Me.Grd_Entrants.TabIndex = 0
        Me.Grd_Entrants.Tag = ""
        '
        'Num_Assure_E
        '
        Me.Num_Assure_E.HeaderText = "N° Assuré"
        Me.Num_Assure_E.MaxInputLength = 9
        Me.Num_Assure_E.Name = "Num_Assure_E"
        Me.Num_Assure_E.Width = 89
        '
        'Nom_E
        '
        Me.Nom_E.HeaderText = "Nom"
        Me.Nom_E.MaxInputLength = 30
        Me.Nom_E.Name = "Nom_E"
        Me.Nom_E.Width = 67
        '
        'Prenom_E
        '
        Me.Prenom_E.HeaderText = "Prénom"
        Me.Prenom_E.MaxInputLength = 30
        Me.Prenom_E.Name = "Prenom_E"
        Me.Prenom_E.Width = 83
        '
        'Num_CIN_E
        '
        Me.Num_CIN_E.HeaderText = "N° CIN"
        Me.Num_CIN_E.MaxInputLength = 8
        Me.Num_CIN_E.Name = "Num_CIN_E"
        Me.Num_CIN_E.Width = 77
        '
        'Nbr_Jours_E
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Nbr_Jours_E.DefaultCellStyle = DataGridViewCellStyle17
        Me.Nbr_Jours_E.HeaderText = "Nbr Jours"
        Me.Nbr_Jours_E.MaxInputLength = 2
        Me.Nbr_Jours_E.Name = "Nbr_Jours_E"
        Me.Nbr_Jours_E.Width = 90
        '
        'Sal_Reel_E
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Sal_Reel_E.DefaultCellStyle = DataGridViewCellStyle18
        Me.Sal_Reel_E.HeaderText = "Salaire Réél"
        Me.Sal_Reel_E.MaxInputLength = 13
        Me.Sal_Reel_E.Name = "Sal_Reel_E"
        Me.Sal_Reel_E.Width = 104
        '
        'Sal_Plaf_E
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Sal_Plaf_E.DefaultCellStyle = DataGridViewCellStyle19
        Me.Sal_Plaf_E.HeaderText = "Salaire Plafonné"
        Me.Sal_Plaf_E.MaxInputLength = 9
        Me.Sal_Plaf_E.Name = "Sal_Plaf_E"
        Me.Sal_Plaf_E.Width = 129
        '
        'Entrants
        '
        Me.Entrants.Controls.Add(Me.Grd_Entrants)
        Me.Entrants.Location = New System.Drawing.Point(4, 25)
        Me.Entrants.Name = "Entrants"
        Me.Entrants.Padding = New System.Windows.Forms.Padding(3)
        Me.Entrants.Size = New System.Drawing.Size(1329, 559)
        Me.Entrants.TabIndex = 1
        Me.Entrants.Text = "Déclaration des entrants"
        Me.Entrants.UseVisualStyleBackColor = True
        '
        'Grd_Permanent
        '
        Me.Grd_Permanent.AfficherLesEntetesLignes = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd_Permanent.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Permanent.AlternerLesLignes = False
        Me.Grd_Permanent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Permanent.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Permanent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Permanent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Permanent.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Permanent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Permanent.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Num_Assure, Me.Nom, Me.Prenom, Me.N_Enfants, Me.AF_A_Payer, Me.AF_A_Deduire, Me.AF_Net_A_Payer, Me.AF_A_Reverser, Me.Jours_Declares, Me.Salaire_Reel, Me.Salaire_Plaf, Me.Situation, Me.ImportData})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Permanent.DefaultCellStyle = DataGridViewCellStyle13
        Me.Grd_Permanent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Permanent.EnableHeadersVisualStyles = False
        Me.Grd_Permanent.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Permanent.Location = New System.Drawing.Point(3, 3)
        Me.Grd_Permanent.Name = "Grd_Permanent"
        Me.Grd_Permanent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Permanent.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.Grd_Permanent.Size = New System.Drawing.Size(1323, 553)
        Me.Grd_Permanent.TabIndex = 14
        '
        'Num_Assure
        '
        Me.Num_Assure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Num_Assure.DefaultCellStyle = DataGridViewCellStyle3
        Me.Num_Assure.HeaderText = "Numéro d’immatriculation"
        Me.Num_Assure.MaxInputLength = 9
        Me.Num_Assure.MinimumWidth = 20
        Me.Num_Assure.Name = "Num_Assure"
        Me.Num_Assure.ReadOnly = True
        '
        'Nom
        '
        Me.Nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Nom.HeaderText = "Nom"
        Me.Nom.MaxInputLength = 30
        Me.Nom.MinimumWidth = 100
        Me.Nom.Name = "Nom"
        Me.Nom.ReadOnly = True
        '
        'Prenom
        '
        Me.Prenom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Prenom.HeaderText = "Prénom"
        Me.Prenom.MaxInputLength = 30
        Me.Prenom.MinimumWidth = 100
        Me.Prenom.Name = "Prenom"
        Me.Prenom.ReadOnly = True
        '
        'N_Enfants
        '
        Me.N_Enfants.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.N_Enfants.DefaultCellStyle = DataGridViewCellStyle4
        Me.N_Enfants.HeaderText = "Nbre enfants"
        Me.N_Enfants.MaxInputLength = 2
        Me.N_Enfants.Name = "N_Enfants"
        Me.N_Enfants.Width = 50
        '
        'AF_A_Payer
        '
        Me.AF_A_Payer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.AF_A_Payer.DefaultCellStyle = DataGridViewCellStyle5
        Me.AF_A_Payer.HeaderText = "Mt des allocations familiales"
        Me.AF_A_Payer.MaxInputLength = 7
        Me.AF_A_Payer.Name = "AF_A_Payer"
        '
        'AF_A_Deduire
        '
        Me.AF_A_Deduire.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.AF_A_Deduire.DefaultCellStyle = DataGridViewCellStyle6
        Me.AF_A_Deduire.HeaderText = "Mt des allocations familiales perçues"
        Me.AF_A_Deduire.MaxInputLength = 7
        Me.AF_A_Deduire.Name = "AF_A_Deduire"
        '
        'AF_Net_A_Payer
        '
        Me.AF_Net_A_Payer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.AF_Net_A_Payer.DefaultCellStyle = DataGridViewCellStyle7
        Me.AF_Net_A_Payer.HeaderText = "Mt net des allocations familiales à payer"
        Me.AF_Net_A_Payer.MaxInputLength = 7
        Me.AF_Net_A_Payer.Name = "AF_Net_A_Payer"
        '
        'AF_A_Reverser
        '
        Me.AF_A_Reverser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.AF_A_Reverser.DefaultCellStyle = DataGridViewCellStyle8
        Me.AF_A_Reverser.HeaderText = "Mt des allocations familiales à reverser"
        Me.AF_A_Reverser.MaxInputLength = 7
        Me.AF_A_Reverser.Name = "AF_A_Reverser"
        '
        'Jours_Declares
        '
        Me.Jours_Declares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Jours_Declares.DefaultCellStyle = DataGridViewCellStyle9
        Me.Jours_Declares.HeaderText = "jours déclarés"
        Me.Jours_Declares.MaxInputLength = 2
        Me.Jours_Declares.Name = "Jours_Declares"
        Me.Jours_Declares.Width = 50
        '
        'Salaire_Reel
        '
        Me.Salaire_Reel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Salaire_Reel.DefaultCellStyle = DataGridViewCellStyle10
        Me.Salaire_Reel.HeaderText = "Mt salaires réels déclarés"
        Me.Salaire_Reel.MaxInputLength = 14
        Me.Salaire_Reel.Name = "Salaire_Reel"
        Me.Salaire_Reel.ReadOnly = True
        '
        'Salaire_Plaf
        '
        Me.Salaire_Plaf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Salaire_Plaf.DefaultCellStyle = DataGridViewCellStyle11
        Me.Salaire_Plaf.HeaderText = "Mt des salaires déclarés plafonnés"
        Me.Salaire_Plaf.MaxInputLength = 10
        Me.Salaire_Plaf.Name = "Salaire_Plaf"
        Me.Salaire_Plaf.ReadOnly = True
        '
        'Situation
        '
        Me.Situation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Situation.DefaultCellStyle = DataGridViewCellStyle12
        Me.Situation.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Situation.HeaderText = "Situation"
        Me.Situation.Name = "Situation"
        Me.Situation.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Situation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Situation.Width = 89
        '
        'ImportData
        '
        Me.ImportData.HeaderText = "Données Existantes"
        Me.ImportData.Name = "ImportData"
        Me.ImportData.ReadOnly = True
        Me.ImportData.Width = 113
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(728, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 16)
        Me.Label11.TabIndex = 233
        Me.Label11.Text = "Entrants importés le"
        '
        'Dat_Import_Entrant_txt
        '
        Me.Dat_Import_Entrant_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Import_Entrant_txt.ContextMenuStrip = Nothing
        Me.Dat_Import_Entrant_txt.Location = New System.Drawing.Point(841, 54)
        Me.Dat_Import_Entrant_txt.MaxLength = 32767
        Me.Dat_Import_Entrant_txt.Multiline = False
        Me.Dat_Import_Entrant_txt.Name = "Dat_Import_Entrant_txt"
        Me.Dat_Import_Entrant_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Import_Entrant_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Import_Entrant_txt.ReadOnly = False
        Me.Dat_Import_Entrant_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Import_Entrant_txt.SelectionStart = 0
        Me.Dat_Import_Entrant_txt.Size = New System.Drawing.Size(127, 21)
        Me.Dat_Import_Entrant_txt.TabIndex = 232
        Me.Dat_Import_Entrant_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Import_Entrant_txt.UseSystemPasswordChar = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(723, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 16)
        Me.Label14.TabIndex = 231
        Me.Label14.Text = "Permanents importés"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(731, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 16)
        Me.Label13.TabIndex = 230
        Me.Label13.Text = "Préétabli importé le"
        '
        'Lib_Agence_txt
        '
        Me.Lib_Agence_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Agence_txt.ContextMenuStrip = Nothing
        Me.Lib_Agence_txt.Location = New System.Drawing.Point(659, 102)
        Me.Lib_Agence_txt.MaxLength = 32767
        Me.Lib_Agence_txt.Multiline = False
        Me.Lib_Agence_txt.Name = "Lib_Agence_txt"
        Me.Lib_Agence_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Agence_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Agence_txt.ReadOnly = False
        Me.Lib_Agence_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Agence_txt.SelectionStart = 0
        Me.Lib_Agence_txt.Size = New System.Drawing.Size(319, 21)
        Me.Lib_Agence_txt.TabIndex = 13
        Me.Lib_Agence_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Agence_txt.UseSystemPasswordChar = False
        '
        'Source_Preetabli_chk
        '
        Me.Source_Preetabli_chk.AutoSize = True
        Me.Source_Preetabli_chk.Checked = True
        Me.Source_Preetabli_chk.Enabled = False
        Me.Source_Preetabli_chk.Location = New System.Drawing.Point(564, 8)
        Me.Source_Preetabli_chk.MaximumSize = New System.Drawing.Size(0, 20)
        Me.Source_Preetabli_chk.MinimumSize = New System.Drawing.Size(100, 20)
        Me.Source_Preetabli_chk.Name = "Source_Preetabli_chk"
        Me.Source_Preetabli_chk.Size = New System.Drawing.Size(100, 20)
        Me.Source_Preetabli_chk.TabIndex = 228
        Me.Source_Preetabli_chk.Text = "Préétabli"
        '
        'Date_Exig_txt
        '
        Me.Date_Exig_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Date_Exig_txt.ContextMenuStrip = Nothing
        Me.Date_Exig_txt.Location = New System.Drawing.Point(880, 78)
        Me.Date_Exig_txt.MaxLength = 10
        Me.Date_Exig_txt.Multiline = False
        Me.Date_Exig_txt.Name = "Date_Exig_txt"
        Me.Date_Exig_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Date_Exig_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Date_Exig_txt.ReadOnly = False
        Me.Date_Exig_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Date_Exig_txt.SelectionStart = 0
        Me.Date_Exig_txt.Size = New System.Drawing.Size(88, 21)
        Me.Date_Exig_txt.TabIndex = 11
        Me.Date_Exig_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Date_Exig_txt.UseSystemPasswordChar = False
        '
        'ExigibleLe_lbl
        '
        Me.ExigibleLe_lbl.AutoSize = True
        Me.ExigibleLe_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExigibleLe_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExigibleLe_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ExigibleLe_lbl.Location = New System.Drawing.Point(830, 81)
        Me.ExigibleLe_lbl.Name = "ExigibleLe_lbl"
        Me.ExigibleLe_lbl.Size = New System.Drawing.Size(48, 16)
        Me.ExigibleLe_lbl.TabIndex = 226
        Me.ExigibleLe_lbl.Text = "Exigible"
        '
        'Dat_Import_Permanent_txt
        '
        Me.Dat_Import_Permanent_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Import_Permanent_txt.ContextMenuStrip = Nothing
        Me.Dat_Import_Permanent_txt.Location = New System.Drawing.Point(841, 31)
        Me.Dat_Import_Permanent_txt.MaxLength = 32767
        Me.Dat_Import_Permanent_txt.Multiline = False
        Me.Dat_Import_Permanent_txt.Name = "Dat_Import_Permanent_txt"
        Me.Dat_Import_Permanent_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Import_Permanent_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Import_Permanent_txt.ReadOnly = False
        Me.Dat_Import_Permanent_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Import_Permanent_txt.SelectionStart = 0
        Me.Dat_Import_Permanent_txt.Size = New System.Drawing.Size(127, 21)
        Me.Dat_Import_Permanent_txt.TabIndex = 225
        Me.Dat_Import_Permanent_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Import_Permanent_txt.UseSystemPasswordChar = False
        '
        'Dat_Import_Preetabli_txt
        '
        Me.Dat_Import_Preetabli_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Import_Preetabli_txt.ContextMenuStrip = Nothing
        Me.Dat_Import_Preetabli_txt.Location = New System.Drawing.Point(841, 7)
        Me.Dat_Import_Preetabli_txt.MaxLength = 32767
        Me.Dat_Import_Preetabli_txt.Multiline = False
        Me.Dat_Import_Preetabli_txt.Name = "Dat_Import_Preetabli_txt"
        Me.Dat_Import_Preetabli_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Import_Preetabli_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Import_Preetabli_txt.ReadOnly = False
        Me.Dat_Import_Preetabli_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Import_Preetabli_txt.SelectionStart = 0
        Me.Dat_Import_Preetabli_txt.Size = New System.Drawing.Size(127, 21)
        Me.Dat_Import_Preetabli_txt.TabIndex = 225
        Me.Dat_Import_Preetabli_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Import_Preetabli_txt.UseSystemPasswordChar = False
        '
        'Date_Emission_txt
        '
        Me.Date_Emission_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Date_Emission_txt.ContextMenuStrip = Nothing
        Me.Date_Emission_txt.Location = New System.Drawing.Point(719, 78)
        Me.Date_Emission_txt.MaxLength = 10
        Me.Date_Emission_txt.Multiline = False
        Me.Date_Emission_txt.Name = "Date_Emission_txt"
        Me.Date_Emission_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Date_Emission_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Date_Emission_txt.ReadOnly = False
        Me.Date_Emission_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Date_Emission_txt.SelectionStart = 0
        Me.Date_Emission_txt.Size = New System.Drawing.Size(88, 21)
        Me.Date_Emission_txt.TabIndex = 10
        Me.Date_Emission_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Date_Emission_txt.UseSystemPasswordChar = False
        '
        'EmisLe_lbl
        '
        Me.EmisLe_lbl.AutoSize = True
        Me.EmisLe_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EmisLe_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmisLe_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.EmisLe_lbl.Location = New System.Drawing.Point(661, 81)
        Me.EmisLe_lbl.Name = "EmisLe_lbl"
        Me.EmisLe_lbl.Size = New System.Drawing.Size(53, 16)
        Me.EmisLe_lbl.TabIndex = 224
        Me.EmisLe_lbl.Text = "Emission "
        '
        'Agence_txt
        '
        Me.Agence_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Agence_txt.ContextMenuStrip = Nothing
        Me.Agence_txt.Location = New System.Drawing.Point(505, 101)
        Me.Agence_txt.MaxLength = 2
        Me.Agence_txt.Multiline = False
        Me.Agence_txt.Name = "Agence_txt"
        Me.Agence_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Agence_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Agence_txt.ReadOnly = False
        Me.Agence_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Agence_txt.SelectionStart = 0
        Me.Agence_txt.Size = New System.Drawing.Size(148, 21)
        Me.Agence_txt.TabIndex = 9
        Me.Agence_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Agence_txt.UseSystemPasswordChar = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(457, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 16)
        Me.Label10.TabIndex = 222
        Me.Label10.Text = "Agence"
        '
        'CP_txt
        '
        Me.CP_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CP_txt.ContextMenuStrip = Nothing
        Me.CP_txt.Location = New System.Drawing.Point(505, 78)
        Me.CP_txt.MaxLength = 6
        Me.CP_txt.Multiline = False
        Me.CP_txt.Name = "CP_txt"
        Me.CP_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.CP_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CP_txt.ReadOnly = False
        Me.CP_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.CP_txt.SelectionStart = 0
        Me.CP_txt.Size = New System.Drawing.Size(148, 21)
        Me.CP_txt.TabIndex = 8
        Me.CP_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.CP_txt.UseSystemPasswordChar = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(482, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 16)
        Me.Label9.TabIndex = 220
        Me.Label9.Text = "CP"
        '
        'Ville_txt
        '
        Me.Ville_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ville_txt.ContextMenuStrip = Nothing
        Me.Ville_txt.Location = New System.Drawing.Point(505, 54)
        Me.Ville_txt.MaxLength = 20
        Me.Ville_txt.Multiline = False
        Me.Ville_txt.Name = "Ville_txt"
        Me.Ville_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ville_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ville_txt.ReadOnly = False
        Me.Ville_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ville_txt.SelectionStart = 0
        Me.Ville_txt.Size = New System.Drawing.Size(148, 21)
        Me.Ville_txt.TabIndex = 6
        Me.Ville_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ville_txt.UseSystemPasswordChar = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(473, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 16)
        Me.Label8.TabIndex = 218
        Me.Label8.Text = "Ville"
        '
        'Adresse_txt
        '
        Me.Adresse_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Adresse_txt.ContextMenuStrip = Nothing
        Me.Adresse_txt.Location = New System.Drawing.Point(99, 78)
        Me.Adresse_txt.MaxLength = 120
        Me.Adresse_txt.Multiline = True
        Me.Adresse_txt.Name = "Adresse_txt"
        Me.Adresse_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Adresse_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Adresse_txt.ReadOnly = False
        Me.Adresse_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Adresse_txt.SelectionStart = 0
        Me.Adresse_txt.Size = New System.Drawing.Size(355, 43)
        Me.Adresse_txt.TabIndex = 7
        Me.Adresse_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Adresse_txt.UseSystemPasswordChar = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(49, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 216
        Me.Label7.Text = "Adresse"
        '
        'Activite_txt
        '
        Me.Activite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Activite_txt.ContextMenuStrip = Nothing
        Me.Activite_txt.Location = New System.Drawing.Point(99, 54)
        Me.Activite_txt.MaxLength = 40
        Me.Activite_txt.Multiline = False
        Me.Activite_txt.Name = "Activite_txt"
        Me.Activite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Activite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Activite_txt.ReadOnly = False
        Me.Activite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Activite_txt.SelectionStart = 0
        Me.Activite_txt.Size = New System.Drawing.Size(355, 21)
        Me.Activite_txt.TabIndex = 5
        Me.Activite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Activite_txt.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(52, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 214
        Me.Label6.Text = "Activité"
        '
        'Raison_Sociale_txt
        '
        Me.Raison_Sociale_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Raison_Sociale_txt.ContextMenuStrip = Nothing
        Me.Raison_Sociale_txt.Location = New System.Drawing.Point(329, 30)
        Me.Raison_Sociale_txt.MaxLength = 40
        Me.Raison_Sociale_txt.Multiline = False
        Me.Raison_Sociale_txt.Name = "Raison_Sociale_txt"
        Me.Raison_Sociale_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Raison_Sociale_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Raison_Sociale_txt.ReadOnly = False
        Me.Raison_Sociale_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Raison_Sociale_txt.SelectionStart = 0
        Me.Raison_Sociale_txt.Size = New System.Drawing.Size(324, 21)
        Me.Raison_Sociale_txt.TabIndex = 4
        Me.Raison_Sociale_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Raison_Sociale_txt.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(233, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "Raison sociale"
        '
        'Periode_Cbo
        '
        Me.Periode_Cbo.DataSource = Nothing
        Me.Periode_Cbo.DisplayMember = ""
        Me.Periode_Cbo.DroppedDown = False
        Me.Periode_Cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Periode_Cbo.Location = New System.Drawing.Point(471, 5)
        Me.Periode_Cbo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Periode_Cbo.Name = "Periode_Cbo"
        Me.Periode_Cbo.SelectedIndex = -1
        Me.Periode_Cbo.SelectedItem = Nothing
        Me.Periode_Cbo.SelectedValue = Nothing
        Me.Periode_Cbo.Size = New System.Drawing.Size(84, 24)
        Me.Periode_Cbo.TabIndex = 1
        Me.Periode_Cbo.ValueMember = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(414, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 210
        Me.Label3.Text = "Période"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(232, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 16)
        Me.Label5.TabIndex = 209
        Me.Label5.Text = "Année"
        '
        'Annee
        '
        Me.Annee.Location = New System.Drawing.Point(282, 6)
        Me.Annee.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.Annee.Minimum = New Decimal(New Integer() {2014, 0, 0, 0})
        Me.Annee.Name = "Annee"
        Me.Annee.Size = New System.Drawing.Size(61, 21)
        Me.Annee.TabIndex = 208
        Me.Annee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Annee.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Num_Affilie_txt
        '
        Me.Num_Affilie_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Affilie_txt.ContextMenuStrip = Nothing
        Me.Num_Affilie_txt.Location = New System.Drawing.Point(99, 30)
        Me.Num_Affilie_txt.MaxLength = 7
        Me.Num_Affilie_txt.Multiline = False
        Me.Num_Affilie_txt.Name = "Num_Affilie_txt"
        Me.Num_Affilie_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Affilie_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Affilie_txt.ReadOnly = False
        Me.Num_Affilie_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Affilie_txt.SelectionStart = 0
        Me.Num_Affilie_txt.Size = New System.Drawing.Size(56, 21)
        Me.Num_Affilie_txt.TabIndex = 3
        Me.Num_Affilie_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Affilie_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(14, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "N° d’affiliation"
        '
        'Identif_Transfert_Text
        '
        Me.Identif_Transfert_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Identif_Transfert_Text.ContextMenuStrip = Nothing
        Me.Identif_Transfert_Text.Location = New System.Drawing.Point(99, 6)
        Me.Identif_Transfert_Text.MaxLength = 14
        Me.Identif_Transfert_Text.Multiline = False
        Me.Identif_Transfert_Text.Name = "Identif_Transfert_Text"
        Me.Identif_Transfert_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Identif_Transfert_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Identif_Transfert_Text.ReadOnly = False
        Me.Identif_Transfert_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Identif_Transfert_Text.SelectionStart = 0
        Me.Identif_Transfert_Text.Size = New System.Drawing.Size(97, 21)
        Me.Identif_Transfert_Text.TabIndex = 0
        Me.Identif_Transfert_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Identif_Transfert_Text.UseSystemPasswordChar = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(5, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 16)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "Identifiant CNSS"
        '
        'pbValide
        '
        Me.pbValide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pbValide.Location = New System.Drawing.Point(972, 9)
        Me.pbValide.Name = "pbValide"
        Me.pbValide.Size = New System.Drawing.Size(62, 62)
        Me.pbValide.TabIndex = 58
        Me.pbValide.TabStop = False
        Me.pbValide.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.AddAgence_btn)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Dat_Import_Entrant_txt)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Lib_Agence_txt)
        Me.Panel1.Controls.Add(Me.Source_Preetabli_chk)
        Me.Panel1.Controls.Add(Me.Date_Exig_txt)
        Me.Panel1.Controls.Add(Me.ExigibleLe_lbl)
        Me.Panel1.Controls.Add(Me.Dat_Import_Permanent_txt)
        Me.Panel1.Controls.Add(Me.Dat_Import_Preetabli_txt)
        Me.Panel1.Controls.Add(Me.Date_Emission_txt)
        Me.Panel1.Controls.Add(Me.EmisLe_lbl)
        Me.Panel1.Controls.Add(Me.Agence_txt)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.CP_txt)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Ville_txt)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Adresse_txt)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Activite_txt)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Raison_Sociale_txt)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Periode_Cbo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Annee)
        Me.Panel1.Controls.Add(Me.Num_Affilie_txt)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Identif_Transfert_Text)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.pbValide)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1337, 138)
        Me.Panel1.TabIndex = 15
        '
        'AddAgence_btn
        '
        Me.AddAgence_btn.AutoSize = True
        Me.AddAgence_btn.bgColor = System.Drawing.Color.White
        Me.AddAgence_btn.Border = RHP.ud_button.BorderStyle.None
        Me.AddAgence_btn.BorderColor = System.Drawing.Color.Empty
        Me.AddAgence_btn.BorderSize = 0
        Me.AddAgence_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AddAgence_btn.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.AddAgence_btn.isDefault = False
        Me.AddAgence_btn.Location = New System.Drawing.Point(984, 97)
        Me.AddAgence_btn.MinimumSize = New System.Drawing.Size(20, 20)
        Me.AddAgence_btn.Name = "AddAgence_btn"
        Me.AddAgence_btn.Size = New System.Drawing.Size(30, 30)
        Me.AddAgence_btn.TabIndex = 234
        Me.AddAgence_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AddAgence_btn.ToolTip = "Ajouter l'agence CNSS"
        '
        'Cnss_DamanCom
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1337, 726)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cnss_DamanCom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Télédéclaration et de télépaiement de la CNSS - DamanCom"
        Me.TabControl1.ResumeLayout(False)
        Me.Permanents.ResumeLayout(False)
        CType(Me.Grd_Entrants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Entrants.ResumeLayout(False)
        CType(Me.Grd_Permanent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Annee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbValide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FichierD As String
    Friend WithEvents FichierS As String
    Friend WithEvents Grd_Permanent As ud_Grd
    Friend WithEvents pbValide As System.Windows.Forms.PictureBox
    Friend WithEvents Grd_Entrants As ud_Grd
    Friend WithEvents Num_Assure_E As DataGridViewTextBoxColumn
    Friend WithEvents Nom_E As DataGridViewTextBoxColumn
    Friend WithEvents Prenom_E As DataGridViewTextBoxColumn
    Friend WithEvents Num_CIN_E As DataGridViewTextBoxColumn
    Friend WithEvents Nbr_Jours_E As DataGridViewTextBoxColumn
    Friend WithEvents Sal_Reel_E As DataGridViewTextBoxColumn
    Friend WithEvents Sal_Plaf_E As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Agence_txt As ud_TextBox
    Friend WithEvents Source_Preetabli_chk As ud_CheckBox
    Friend WithEvents Date_Exig_txt As ud_TextBox
    Friend WithEvents ExigibleLe_lbl As Label
    Friend WithEvents Date_Emission_txt As ud_TextBox
    Friend WithEvents EmisLe_lbl As Label
    Friend WithEvents Agence_txt As ud_TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CP_txt As ud_TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Ville_txt As ud_TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Adresse_txt As ud_TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Activite_txt As ud_TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Raison_Sociale_txt As ud_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Periode_Cbo As ud_ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Annee As NumericUpDown
    Friend WithEvents Num_Affilie_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Identif_Transfert_Text As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Dat_Import_Permanent_txt As ud_TextBox
    Friend WithEvents Dat_Import_Preetabli_txt As ud_TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Dat_Import_Entrant_txt As ud_TextBox
    Friend WithEvents Num_Assure As DataGridViewTextBoxColumn
    Friend WithEvents Nom As DataGridViewTextBoxColumn
    Friend WithEvents Prenom As DataGridViewTextBoxColumn
    Friend WithEvents N_Enfants As DataGridViewTextBoxColumn
    Friend WithEvents AF_A_Payer As DataGridViewTextBoxColumn
    Friend WithEvents AF_A_Deduire As DataGridViewTextBoxColumn
    Friend WithEvents AF_Net_A_Payer As DataGridViewTextBoxColumn
    Friend WithEvents AF_A_Reverser As DataGridViewTextBoxColumn
    Friend WithEvents Jours_Declares As DataGridViewTextBoxColumn
    Friend WithEvents Salaire_Reel As DataGridViewTextBoxColumn
    Friend WithEvents Salaire_Plaf As DataGridViewTextBoxColumn
    Friend WithEvents Situation As DataGridViewComboBoxColumn
    Friend WithEvents ImportData As DataGridViewCheckBoxColumn
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Permanents As TabPage
    Friend WithEvents Entrants As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents AddAgence_btn As ud_button
End Class
