<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Note_Frais
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grd_Frais = New RHP.ud_Grd()
        Me.Typ_Frais = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Base = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mnt = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Avance_Deplament_chk = New RHP.ud_CheckBox()
        Me.Au_lbl = New System.Windows.Forms.Label()
        Me.Du_lbl = New System.Windows.Forms.Label()
        Me.Objet_Mission_txt = New RHP.ud_TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Dat_Au_txt = New RHP.ud_TextBox()
        Me.Dat_Du_txt = New RHP.ud_TextBox()
        Me.pnl_internationale = New System.Windows.Forms.Panel()
        Me.Pays_lbl = New System.Windows.Forms.Label()
        Me.Pays_Destination_txt = New RHP.ud_TextBox()
        Me.Lib_Pays_Destination_txt = New RHP.ud_TextBox()
        Me.pnl_nationale = New System.Windows.Forms.Panel()
        Me.Destination_lbl = New System.Windows.Forms.Label()
        Me.Depart_lbl = New System.Windows.Forms.Label()
        Me.Ville_Depart_txt = New RHP.ud_TextBox()
        Me.Ville_Destination_txt = New RHP.ud_TextBox()
        Me.Lib_Ville_Destination_txt = New RHP.ud_TextBox()
        Me.Lib_Ville_Depart_txt = New RHP.ud_TextBox()
        Me.Distance_txt = New RHP.ud_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.AllerRetour_chk = New RHP.ud_CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Moyen_Transport_cbo = New RHP.ud_ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Typ_Mission_cbo = New RHP.ud_ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Typ_Deplacement_cbo = New RHP.ud_ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dat_OM_txt = New RHP.ud_TextBox()
        Me.Num_OM_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Num_NF_txt = New RHP.ud_TextBox()
        Me.Dat_NF_txt = New RHP.ud_TextBox()
        Me.pb_Valide = New System.Windows.Forms.PictureBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Grade_Text = New RHP.ud_TextBox()
        Me.Grade_Text = New RHP.ud_TextBox()
        Me.Lib_Entite_txt = New RHP.ud_TextBox()
        Me.Cod_Entite_txt = New RHP.ud_TextBox()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Mnt_NF_txt = New RHP.ud_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Ud_Panel1 = New RHP.ud_Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Frais, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.pnl_internationale.SuspendLayout()
        Me.pnl_nationale.SuspendLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ud_Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(60, 61)
        Me.Matricule_.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(74, 19)
        Me.Matricule_.TabIndex = 207
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SC"
        Me.Matricule_.Text = "Matricule"
        Me.Matricule_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_txt.Location = New System.Drawing.Point(138, 59)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(130, 26)
        Me.Matricule_txt.TabIndex = 206
        Me.Matricule_txt.TabStop = False
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(272, 59)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(645, 26)
        Me.Nom_Agent_Text.TabIndex = 208
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grd_Frais)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1098, 881)
        Me.Panel1.TabIndex = 209
        '
        'Grd_Frais
        '
        Me.Grd_Frais.AfficherLesEntetesLignes = True
        Me.Grd_Frais.AlternerLesLignes = False
        Me.Grd_Frais.BackgroundColor = System.Drawing.Color.White
        Me.Grd_Frais.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Frais.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Frais.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Frais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Frais.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Typ_Frais, Me.Base, Me.Tx, Me.Mnt, Me.Comment})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Frais.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grd_Frais.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Frais.EnableHeadersVisualStyles = False
        Me.Grd_Frais.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Frais.Location = New System.Drawing.Point(0, 503)
        Me.Grd_Frais.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Frais.Name = "Grd_Frais"
        Me.Grd_Frais.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Frais.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grd_Frais.RowHeadersWidth = 51
        Me.Grd_Frais.Size = New System.Drawing.Size(1098, 378)
        Me.Grd_Frais.TabIndex = 258
        '
        'Typ_Frais
        '
        Me.Typ_Frais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Typ_Frais.HeaderText = "Nature des frais engagés"
        Me.Typ_Frais.MinimumWidth = 120
        Me.Typ_Frais.Name = "Typ_Frais"
        Me.Typ_Frais.Width = 121
        '
        'Base
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Base.DefaultCellStyle = DataGridViewCellStyle2
        Me.Base.HeaderText = "Base"
        Me.Base.MinimumWidth = 6
        Me.Base.Name = "Base"
        Me.Base.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Base.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Base.Width = 125
        '
        'Tx
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Tx.DefaultCellStyle = DataGridViewCellStyle3
        Me.Tx.HeaderText = "Taux"
        Me.Tx.MinimumWidth = 6
        Me.Tx.Name = "Tx"
        Me.Tx.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tx.Width = 125
        '
        'Mnt
        '
        '
        '
        '
        Me.Mnt.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Mnt.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Mnt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Mnt.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Mnt.DefaultCellStyle = DataGridViewCellStyle4
        Me.Mnt.HeaderText = "Montant"
        Me.Mnt.Increment = 1.0R
        Me.Mnt.MinimumWidth = 6
        Me.Mnt.Name = "Mnt"
        Me.Mnt.ReadOnly = True
        Me.Mnt.Width = 125
        '
        'Comment
        '
        Me.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Comment.HeaderText = "Commentaire"
        Me.Comment.MinimumWidth = 6
        Me.Comment.Name = "Comment"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Avance_Deplament_chk)
        Me.GroupBox2.Controls.Add(Me.Au_lbl)
        Me.GroupBox2.Controls.Add(Me.Du_lbl)
        Me.GroupBox2.Controls.Add(Me.Objet_Mission_txt)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Dat_Au_txt)
        Me.GroupBox2.Controls.Add(Me.Dat_Du_txt)
        Me.GroupBox2.Controls.Add(Me.pnl_internationale)
        Me.GroupBox2.Controls.Add(Me.pnl_nationale)
        Me.GroupBox2.Controls.Add(Me.AllerRetour_chk)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Moyen_Transport_cbo)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Typ_Mission_cbo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Typ_Deplacement_cbo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Dat_OM_txt)
        Me.GroupBox2.Controls.Add(Me.Num_OM_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.LinkLabel4)
        Me.GroupBox2.Controls.Add(Me.Num_NF_txt)
        Me.GroupBox2.Controls.Add(Me.Dat_NF_txt)
        Me.GroupBox2.Controls.Add(Me.pb_Valide)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Matricule_)
        Me.GroupBox2.Controls.Add(Me.Lib_Grade_Text)
        Me.GroupBox2.Controls.Add(Me.Grade_Text)
        Me.GroupBox2.Controls.Add(Me.Lib_Entite_txt)
        Me.GroupBox2.Controls.Add(Me.Cod_Entite_txt)
        Me.GroupBox2.Controls.Add(Me.Commentaire_txt)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(1098, 503)
        Me.GroupBox2.TabIndex = 256
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fiche signalitique"
        '
        'Avance_Deplament_chk
        '
        Me.Avance_Deplament_chk.AutoSize = True
        Me.Avance_Deplament_chk.Checked = False
        Me.Avance_Deplament_chk.Enabled = False
        Me.Avance_Deplament_chk.Location = New System.Drawing.Point(670, 439)
        Me.Avance_Deplament_chk.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.Avance_Deplament_chk.MaximumSize = New System.Drawing.Size(0, 43)
        Me.Avance_Deplament_chk.MinimumSize = New System.Drawing.Size(133, 43)
        Me.Avance_Deplament_chk.Name = "Avance_Deplament_chk"
        Me.Avance_Deplament_chk.Size = New System.Drawing.Size(304, 43)
        Me.Avance_Deplament_chk.TabIndex = 297
        Me.Avance_Deplament_chk.Text = "Accorder une avance sur déplacement"
        '
        'Au_lbl
        '
        Me.Au_lbl.AutoSize = True
        Me.Au_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Au_lbl.Location = New System.Drawing.Point(418, 406)
        Me.Au_lbl.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Au_lbl.Name = "Au_lbl"
        Me.Au_lbl.Size = New System.Drawing.Size(27, 19)
        Me.Au_lbl.TabIndex = 296
        Me.Au_lbl.Text = "Au"
        '
        'Du_lbl
        '
        Me.Du_lbl.AutoSize = True
        Me.Du_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Du_lbl.Location = New System.Drawing.Point(105, 406)
        Me.Du_lbl.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Du_lbl.Name = "Du_lbl"
        Me.Du_lbl.Size = New System.Drawing.Size(28, 19)
        Me.Du_lbl.TabIndex = 295
        Me.Du_lbl.Text = "Du"
        '
        'Objet_Mission_txt
        '
        Me.Objet_Mission_txt.AccessibleDescription = "A"
        Me.Objet_Mission_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Objet_Mission_txt.ContextMenuStrip = Nothing
        Me.Objet_Mission_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Objet_Mission_txt.Location = New System.Drawing.Point(137, 439)
        Me.Objet_Mission_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Objet_Mission_txt.MaxLength = 500
        Me.Objet_Mission_txt.Multiline = True
        Me.Objet_Mission_txt.Name = "Objet_Mission_txt"
        Me.Objet_Mission_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Objet_Mission_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Objet_Mission_txt.ReadOnly = False
        Me.Objet_Mission_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Objet_Mission_txt.SelectionStart = 0
        Me.Objet_Mission_txt.Size = New System.Drawing.Size(523, 54)
        Me.Objet_Mission_txt.TabIndex = 293
        Me.Objet_Mission_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Objet_Mission_txt.UseSystemPasswordChar = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(30, 439)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 19)
        Me.Label11.TabIndex = 292
        Me.Label11.Text = "Objet mission"
        '
        'Dat_Au_txt
        '
        Me.Dat_Au_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Au_txt.ContextMenuStrip = Nothing
        Me.Dat_Au_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Au_txt.Location = New System.Drawing.Point(447, 403)
        Me.Dat_Au_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Dat_Au_txt.MaxLength = 10
        Me.Dat_Au_txt.Multiline = False
        Me.Dat_Au_txt.Name = "Dat_Au_txt"
        Me.Dat_Au_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Au_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Au_txt.ReadOnly = True
        Me.Dat_Au_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Au_txt.SelectionStart = 0
        Me.Dat_Au_txt.Size = New System.Drawing.Size(213, 26)
        Me.Dat_Au_txt.TabIndex = 291
        Me.Dat_Au_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Au_txt.UseSystemPasswordChar = False
        '
        'Dat_Du_txt
        '
        Me.Dat_Du_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Du_txt.ContextMenuStrip = Nothing
        Me.Dat_Du_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Du_txt.Location = New System.Drawing.Point(136, 403)
        Me.Dat_Du_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Dat_Du_txt.MaxLength = 10
        Me.Dat_Du_txt.Multiline = False
        Me.Dat_Du_txt.Name = "Dat_Du_txt"
        Me.Dat_Du_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Du_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Du_txt.ReadOnly = True
        Me.Dat_Du_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Du_txt.SelectionStart = 0
        Me.Dat_Du_txt.Size = New System.Drawing.Size(213, 26)
        Me.Dat_Du_txt.TabIndex = 289
        Me.Dat_Du_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Du_txt.UseSystemPasswordChar = False
        '
        'pnl_internationale
        '
        Me.pnl_internationale.Controls.Add(Me.Pays_lbl)
        Me.pnl_internationale.Controls.Add(Me.Pays_Destination_txt)
        Me.pnl_internationale.Controls.Add(Me.Lib_Pays_Destination_txt)
        Me.pnl_internationale.Location = New System.Drawing.Point(490, 245)
        Me.pnl_internationale.Name = "pnl_internationale"
        Me.pnl_internationale.Size = New System.Drawing.Size(449, 41)
        Me.pnl_internationale.TabIndex = 287
        '
        'Pays_lbl
        '
        Me.Pays_lbl.AutoSize = True
        Me.Pays_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Pays_lbl.Location = New System.Drawing.Point(30, 9)
        Me.Pays_lbl.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Pays_lbl.Name = "Pays_lbl"
        Me.Pays_lbl.Size = New System.Drawing.Size(40, 19)
        Me.Pays_lbl.TabIndex = 294
        Me.Pays_lbl.Text = "Pays"
        '
        'Pays_Destination_txt
        '
        Me.Pays_Destination_txt.AccessibleDescription = "A"
        Me.Pays_Destination_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Pays_Destination_txt.ContextMenuStrip = Nothing
        Me.Pays_Destination_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Pays_Destination_txt.Location = New System.Drawing.Point(74, 5)
        Me.Pays_Destination_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Pays_Destination_txt.MaxLength = 100
        Me.Pays_Destination_txt.Multiline = False
        Me.Pays_Destination_txt.Name = "Pays_Destination_txt"
        Me.Pays_Destination_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Pays_Destination_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Pays_Destination_txt.ReadOnly = True
        Me.Pays_Destination_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Pays_Destination_txt.SelectionStart = 0
        Me.Pays_Destination_txt.Size = New System.Drawing.Size(80, 26)
        Me.Pays_Destination_txt.TabIndex = 96
        Me.Pays_Destination_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Pays_Destination_txt.UseSystemPasswordChar = False
        '
        'Lib_Pays_Destination_txt
        '
        Me.Lib_Pays_Destination_txt.AccessibleDescription = "A"
        Me.Lib_Pays_Destination_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Pays_Destination_txt.ContextMenuStrip = Nothing
        Me.Lib_Pays_Destination_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Pays_Destination_txt.Location = New System.Drawing.Point(156, 5)
        Me.Lib_Pays_Destination_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Pays_Destination_txt.MaxLength = 32767
        Me.Lib_Pays_Destination_txt.Multiline = False
        Me.Lib_Pays_Destination_txt.Name = "Lib_Pays_Destination_txt"
        Me.Lib_Pays_Destination_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Pays_Destination_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Pays_Destination_txt.ReadOnly = True
        Me.Lib_Pays_Destination_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Pays_Destination_txt.SelectionStart = 0
        Me.Lib_Pays_Destination_txt.Size = New System.Drawing.Size(267, 26)
        Me.Lib_Pays_Destination_txt.TabIndex = 97
        Me.Lib_Pays_Destination_txt.TabStop = False
        Me.Lib_Pays_Destination_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Pays_Destination_txt.UseSystemPasswordChar = False
        '
        'pnl_nationale
        '
        Me.pnl_nationale.Controls.Add(Me.Destination_lbl)
        Me.pnl_nationale.Controls.Add(Me.Depart_lbl)
        Me.pnl_nationale.Controls.Add(Me.Ville_Depart_txt)
        Me.pnl_nationale.Controls.Add(Me.Ville_Destination_txt)
        Me.pnl_nationale.Controls.Add(Me.Lib_Ville_Destination_txt)
        Me.pnl_nationale.Controls.Add(Me.Lib_Ville_Depart_txt)
        Me.pnl_nationale.Controls.Add(Me.Distance_txt)
        Me.pnl_nationale.Controls.Add(Me.Label8)
        Me.pnl_nationale.Location = New System.Drawing.Point(34, 292)
        Me.pnl_nationale.Name = "pnl_nationale"
        Me.pnl_nationale.Size = New System.Drawing.Size(906, 102)
        Me.pnl_nationale.TabIndex = 286
        '
        'Destination_lbl
        '
        Me.Destination_lbl.AutoSize = True
        Me.Destination_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Destination_lbl.Location = New System.Drawing.Point(13, 38)
        Me.Destination_lbl.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Destination_lbl.Name = "Destination_lbl"
        Me.Destination_lbl.Size = New System.Drawing.Size(86, 19)
        Me.Destination_lbl.TabIndex = 294
        Me.Destination_lbl.Text = "Destination"
        '
        'Depart_lbl
        '
        Me.Depart_lbl.AutoSize = True
        Me.Depart_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Depart_lbl.Location = New System.Drawing.Point(43, 9)
        Me.Depart_lbl.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Depart_lbl.Name = "Depart_lbl"
        Me.Depart_lbl.Size = New System.Drawing.Size(57, 19)
        Me.Depart_lbl.TabIndex = 294
        Me.Depart_lbl.Text = "Départ"
        '
        'Ville_Depart_txt
        '
        Me.Ville_Depart_txt.AccessibleDescription = "A"
        Me.Ville_Depart_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ville_Depart_txt.ContextMenuStrip = Nothing
        Me.Ville_Depart_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ville_Depart_txt.Location = New System.Drawing.Point(103, 5)
        Me.Ville_Depart_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Ville_Depart_txt.MaxLength = 100
        Me.Ville_Depart_txt.Multiline = False
        Me.Ville_Depart_txt.Name = "Ville_Depart_txt"
        Me.Ville_Depart_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ville_Depart_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ville_Depart_txt.ReadOnly = True
        Me.Ville_Depart_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ville_Depart_txt.SelectionStart = 0
        Me.Ville_Depart_txt.Size = New System.Drawing.Size(255, 26)
        Me.Ville_Depart_txt.TabIndex = 13
        Me.Ville_Depart_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ville_Depart_txt.UseSystemPasswordChar = False
        '
        'Ville_Destination_txt
        '
        Me.Ville_Destination_txt.AccessibleDescription = "A"
        Me.Ville_Destination_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Ville_Destination_txt.ContextMenuStrip = Nothing
        Me.Ville_Destination_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ville_Destination_txt.Location = New System.Drawing.Point(102, 35)
        Me.Ville_Destination_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Ville_Destination_txt.MaxLength = 100
        Me.Ville_Destination_txt.Multiline = False
        Me.Ville_Destination_txt.Name = "Ville_Destination_txt"
        Me.Ville_Destination_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Ville_Destination_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Ville_Destination_txt.ReadOnly = True
        Me.Ville_Destination_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Ville_Destination_txt.SelectionStart = 0
        Me.Ville_Destination_txt.Size = New System.Drawing.Size(255, 26)
        Me.Ville_Destination_txt.TabIndex = 15
        Me.Ville_Destination_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Ville_Destination_txt.UseSystemPasswordChar = False
        '
        'Lib_Ville_Destination_txt
        '
        Me.Lib_Ville_Destination_txt.AccessibleDescription = "A"
        Me.Lib_Ville_Destination_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Ville_Destination_txt.ContextMenuStrip = Nothing
        Me.Lib_Ville_Destination_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Ville_Destination_txt.Location = New System.Drawing.Point(361, 35)
        Me.Lib_Ville_Destination_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Ville_Destination_txt.MaxLength = 32767
        Me.Lib_Ville_Destination_txt.Multiline = False
        Me.Lib_Ville_Destination_txt.Name = "Lib_Ville_Destination_txt"
        Me.Lib_Ville_Destination_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Ville_Destination_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Ville_Destination_txt.ReadOnly = True
        Me.Lib_Ville_Destination_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Ville_Destination_txt.SelectionStart = 0
        Me.Lib_Ville_Destination_txt.Size = New System.Drawing.Size(518, 26)
        Me.Lib_Ville_Destination_txt.TabIndex = 94
        Me.Lib_Ville_Destination_txt.TabStop = False
        Me.Lib_Ville_Destination_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Ville_Destination_txt.UseSystemPasswordChar = False
        '
        'Lib_Ville_Depart_txt
        '
        Me.Lib_Ville_Depart_txt.AccessibleDescription = "A"
        Me.Lib_Ville_Depart_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Ville_Depart_txt.ContextMenuStrip = Nothing
        Me.Lib_Ville_Depart_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Ville_Depart_txt.Location = New System.Drawing.Point(361, 5)
        Me.Lib_Ville_Depart_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Ville_Depart_txt.MaxLength = 32767
        Me.Lib_Ville_Depart_txt.Multiline = False
        Me.Lib_Ville_Depart_txt.Name = "Lib_Ville_Depart_txt"
        Me.Lib_Ville_Depart_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Ville_Depart_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Ville_Depart_txt.ReadOnly = True
        Me.Lib_Ville_Depart_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Ville_Depart_txt.SelectionStart = 0
        Me.Lib_Ville_Depart_txt.Size = New System.Drawing.Size(518, 26)
        Me.Lib_Ville_Depart_txt.TabIndex = 94
        Me.Lib_Ville_Depart_txt.TabStop = False
        Me.Lib_Ville_Depart_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Ville_Depart_txt.UseSystemPasswordChar = False
        '
        'Distance_txt
        '
        Me.Distance_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Distance_txt.ContextMenuStrip = Nothing
        Me.Distance_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Distance_txt.Location = New System.Drawing.Point(612, 67)
        Me.Distance_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Distance_txt.MaxLength = 10
        Me.Distance_txt.Multiline = False
        Me.Distance_txt.Name = "Distance_txt"
        Me.Distance_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Distance_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Distance_txt.ReadOnly = True
        Me.Distance_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Distance_txt.SelectionStart = 0
        Me.Distance_txt.Size = New System.Drawing.Size(267, 26)
        Me.Distance_txt.TabIndex = 17
        Me.Distance_txt.Text = "0,00"
        Me.Distance_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Distance_txt.UseSystemPasswordChar = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(506, 69)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 19)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Distance (km)"
        '
        'AllerRetour_chk
        '
        Me.AllerRetour_chk.AutoSize = True
        Me.AllerRetour_chk.Checked = True
        Me.AllerRetour_chk.Enabled = False
        Me.AllerRetour_chk.Location = New System.Drawing.Point(670, 396)
        Me.AllerRetour_chk.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.AllerRetour_chk.MaximumSize = New System.Drawing.Size(0, 36)
        Me.AllerRetour_chk.MinimumSize = New System.Drawing.Size(133, 36)
        Me.AllerRetour_chk.Name = "AllerRetour_chk"
        Me.AllerRetour_chk.Size = New System.Drawing.Size(133, 36)
        Me.AllerRetour_chk.TabIndex = 285
        Me.AllerRetour_chk.Text = "Aller-retour"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(320, 216)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 19)
        Me.Label7.TabIndex = 284
        Me.Label7.Text = "Date OM"
        '
        'Moyen_Transport_cbo
        '
        Me.Moyen_Transport_cbo.DataSource = Nothing
        Me.Moyen_Transport_cbo.DisplayMember = ""
        Me.Moyen_Transport_cbo.DroppedDown = False
        Me.Moyen_Transport_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Moyen_Transport_cbo.Location = New System.Drawing.Point(681, 157)
        Me.Moyen_Transport_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Moyen_Transport_cbo.Name = "Moyen_Transport_cbo"
        Me.Moyen_Transport_cbo.SelectedIndex = -1
        Me.Moyen_Transport_cbo.SelectedItem = Nothing
        Me.Moyen_Transport_cbo.SelectedValue = Nothing
        Me.Moyen_Transport_cbo.Size = New System.Drawing.Size(232, 27)
        Me.Moyen_Transport_cbo.TabIndex = 283
        Me.Moyen_Transport_cbo.ValueMember = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(608, 160)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 19)
        Me.Label9.TabIndex = 282
        Me.Label9.Text = "Transport"
        '
        'Typ_Mission_cbo
        '
        Me.Typ_Mission_cbo.DataSource = Nothing
        Me.Typ_Mission_cbo.DisplayMember = ""
        Me.Typ_Mission_cbo.DroppedDown = False
        Me.Typ_Mission_cbo.Enabled = False
        Me.Typ_Mission_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Mission_cbo.Location = New System.Drawing.Point(587, 215)
        Me.Typ_Mission_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Mission_cbo.Name = "Typ_Mission_cbo"
        Me.Typ_Mission_cbo.SelectedIndex = -1
        Me.Typ_Mission_cbo.SelectedItem = Nothing
        Me.Typ_Mission_cbo.SelectedValue = Nothing
        Me.Typ_Mission_cbo.Size = New System.Drawing.Size(326, 27)
        Me.Typ_Mission_cbo.TabIndex = 283
        Me.Typ_Mission_cbo.ValueMember = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(526, 218)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 19)
        Me.Label6.TabIndex = 282
        Me.Label6.Text = "Mission"
        '
        'Typ_Deplacement_cbo
        '
        Me.Typ_Deplacement_cbo.DataSource = Nothing
        Me.Typ_Deplacement_cbo.DisplayMember = ""
        Me.Typ_Deplacement_cbo.DroppedDown = False
        Me.Typ_Deplacement_cbo.Enabled = False
        Me.Typ_Deplacement_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Typ_Deplacement_cbo.Location = New System.Drawing.Point(138, 251)
        Me.Typ_Deplacement_cbo.Margin = New System.Windows.Forms.Padding(4)
        Me.Typ_Deplacement_cbo.Name = "Typ_Deplacement_cbo"
        Me.Typ_Deplacement_cbo.SelectedIndex = -1
        Me.Typ_Deplacement_cbo.SelectedItem = Nothing
        Me.Typ_Deplacement_cbo.SelectedValue = Nothing
        Me.Typ_Deplacement_cbo.Size = New System.Drawing.Size(342, 27)
        Me.Typ_Deplacement_cbo.TabIndex = 281
        Me.Typ_Deplacement_cbo.ValueMember = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(34, 255)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 19)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "Type déplac."
        '
        'Dat_OM_txt
        '
        Me.Dat_OM_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_OM_txt.ContextMenuStrip = Nothing
        Me.Dat_OM_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_OM_txt.Location = New System.Drawing.Point(398, 213)
        Me.Dat_OM_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Dat_OM_txt.MaxLength = 32767
        Me.Dat_OM_txt.Multiline = False
        Me.Dat_OM_txt.Name = "Dat_OM_txt"
        Me.Dat_OM_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_OM_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_OM_txt.ReadOnly = True
        Me.Dat_OM_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_OM_txt.SelectionStart = 0
        Me.Dat_OM_txt.Size = New System.Drawing.Size(107, 26)
        Me.Dat_OM_txt.TabIndex = 279
        Me.Dat_OM_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_OM_txt.UseSystemPasswordChar = False
        '
        'Num_OM_txt
        '
        Me.Num_OM_txt.AccessibleDescription = "A"
        Me.Num_OM_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_OM_txt.ContextMenuStrip = Nothing
        Me.Num_OM_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_OM_txt.Location = New System.Drawing.Point(137, 213)
        Me.Num_OM_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Num_OM_txt.MaxLength = 32767
        Me.Num_OM_txt.Multiline = False
        Me.Num_OM_txt.Name = "Num_OM_txt"
        Me.Num_OM_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_OM_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_OM_txt.ReadOnly = True
        Me.Num_OM_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_OM_txt.SelectionStart = 0
        Me.Num_OM_txt.Size = New System.Drawing.Size(175, 26)
        Me.Num_OM_txt.TabIndex = 277
        Me.Num_OM_txt.TabStop = False
        Me.Num_OM_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_OM_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(11, 216)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(122, 19)
        Me.LinkLabel1.TabIndex = 276
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "SC"
        Me.LinkLabel1.Text = "Ordre de mission"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(471, 29)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(157, 19)
        Me.LinkLabel4.TabIndex = 273
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Tag = "SC"
        Me.LinkLabel4.Text = "Date de la demande"
        Me.LinkLabel4.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Num_NF_txt
        '
        Me.Num_NF_txt.AccessibleDescription = "A"
        Me.Num_NF_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_NF_txt.ContextMenuStrip = Nothing
        Me.Num_NF_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_NF_txt.Location = New System.Drawing.Point(138, 29)
        Me.Num_NF_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Num_NF_txt.MaxLength = 32767
        Me.Num_NF_txt.Multiline = False
        Me.Num_NF_txt.Name = "Num_NF_txt"
        Me.Num_NF_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_NF_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_NF_txt.ReadOnly = True
        Me.Num_NF_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_NF_txt.SelectionStart = 0
        Me.Num_NF_txt.Size = New System.Drawing.Size(175, 26)
        Me.Num_NF_txt.TabIndex = 248
        Me.Num_NF_txt.TabStop = False
        Me.Num_NF_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_NF_txt.UseSystemPasswordChar = False
        '
        'Dat_NF_txt
        '
        Me.Dat_NF_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_NF_txt.ContextMenuStrip = Nothing
        Me.Dat_NF_txt.Location = New System.Drawing.Point(631, 25)
        Me.Dat_NF_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Dat_NF_txt.MaxLength = 32767
        Me.Dat_NF_txt.Multiline = False
        Me.Dat_NF_txt.Name = "Dat_NF_txt"
        Me.Dat_NF_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_NF_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_NF_txt.ReadOnly = True
        Me.Dat_NF_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_NF_txt.SelectionStart = 0
        Me.Dat_NF_txt.Size = New System.Drawing.Size(286, 26)
        Me.Dat_NF_txt.TabIndex = 251
        Me.Dat_NF_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_NF_txt.UseSystemPasswordChar = False
        '
        'pb_Valide
        '
        Me.pb_Valide.Image = Global.RHP.My.Resources.Resources.valide01
        Me.pb_Valide.Location = New System.Drawing.Point(978, 14)
        Me.pb_Valide.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.pb_Valide.Name = "pb_Valide"
        Me.pb_Valide.Size = New System.Drawing.Size(105, 106)
        Me.pb_Valide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_Valide.TabIndex = 253
        Me.pb_Valide.TabStop = False
        Me.pb_Valide.Visible = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(21, 33)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(114, 19)
        Me.LinkLabel3.TabIndex = 249
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SC"
        Me.LinkLabel3.Text = "N° note de frais"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Grade_Text
        '
        Me.Lib_Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Grade_Text.ContextMenuStrip = Nothing
        Me.Lib_Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Grade_Text.Location = New System.Drawing.Point(272, 90)
        Me.Lib_Grade_Text.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Grade_Text.MaxLength = 50
        Me.Lib_Grade_Text.Multiline = False
        Me.Lib_Grade_Text.Name = "Lib_Grade_Text"
        Me.Lib_Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Grade_Text.ReadOnly = True
        Me.Lib_Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Grade_Text.SelectionStart = 0
        Me.Lib_Grade_Text.Size = New System.Drawing.Size(645, 26)
        Me.Lib_Grade_Text.TabIndex = 231
        Me.Lib_Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Grade_Text.UseSystemPasswordChar = False
        '
        'Grade_Text
        '
        Me.Grade_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Grade_Text.ContextMenuStrip = Nothing
        Me.Grade_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grade_Text.Location = New System.Drawing.Point(138, 90)
        Me.Grade_Text.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Grade_Text.MaxLength = 6
        Me.Grade_Text.Multiline = False
        Me.Grade_Text.Name = "Grade_Text"
        Me.Grade_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Grade_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Grade_Text.ReadOnly = True
        Me.Grade_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grade_Text.SelectionStart = 0
        Me.Grade_Text.Size = New System.Drawing.Size(129, 26)
        Me.Grade_Text.TabIndex = 232
        Me.Grade_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Grade_Text.UseSystemPasswordChar = False
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Entite_txt.ContextMenuStrip = Nothing
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(271, 122)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Multiline = False
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Entite_txt.SelectionStart = 0
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(645, 26)
        Me.Lib_Entite_txt.TabIndex = 234
        Me.Lib_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Entite_txt.UseSystemPasswordChar = False
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Entite_txt.ContextMenuStrip = Nothing
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(137, 122)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Cod_Entite_txt.MaxLength = 6
        Me.Cod_Entite_txt.Multiline = False
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Entite_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Entite_txt.SelectionStart = 0
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(129, 26)
        Me.Cod_Entite_txt.TabIndex = 235
        Me.Cod_Entite_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Entite_txt.UseSystemPasswordChar = False
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.AccessibleDescription = "A"
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.ContextMenuStrip = Nothing
        Me.Commentaire_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Commentaire_txt.Location = New System.Drawing.Point(137, 155)
        Me.Commentaire_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Commentaire_txt.MaxLength = 490
        Me.Commentaire_txt.Multiline = True
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(472, 51)
        Me.Commentaire_txt.TabIndex = 236
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(30, 155)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 19)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Commentaire"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(80, 93)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Grade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(85, 125)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 19)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Entité"
        '
        'Mnt_NF_txt
        '
        Me.Mnt_NF_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Mnt_NF_txt.ContextMenuStrip = Nothing
        Me.Mnt_NF_txt.Font = New System.Drawing.Font("Century Gothic", 11.0!)
        Me.Mnt_NF_txt.Location = New System.Drawing.Point(436, 15)
        Me.Mnt_NF_txt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Mnt_NF_txt.MaxLength = 10
        Me.Mnt_NF_txt.Multiline = False
        Me.Mnt_NF_txt.Name = "Mnt_NF_txt"
        Me.Mnt_NF_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Mnt_NF_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Mnt_NF_txt.ReadOnly = True
        Me.Mnt_NF_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mnt_NF_txt.SelectionStart = 0
        Me.Mnt_NF_txt.Size = New System.Drawing.Size(120, 26)
        Me.Mnt_NF_txt.TabIndex = 275
        Me.Mnt_NF_txt.Tag = "4"
        Me.Mnt_NF_txt.Text = "0,00"
        Me.Mnt_NF_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Mnt_NF_txt.UseSystemPasswordChar = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(298, 19)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 19)
        Me.Label5.TabIndex = 274
        Me.Label5.Text = "Total frais engagés"
        '
        'Ud_Panel1
        '
        Me.Ud_Panel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel1.BorderSize = 2
        Me.Ud_Panel1.Controls.Add(Me.Mnt_NF_txt)
        Me.Ud_Panel1.Controls.Add(Me.Label5)
        Me.Ud_Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Ud_Panel1.Location = New System.Drawing.Point(0, 881)
        Me.Ud_Panel1.Name = "Ud_Panel1"
        Me.Ud_Panel1.Size = New System.Drawing.Size(1098, 55)
        Me.Ud_Panel1.TabIndex = 294
        '
        'Note_Frais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1098, 936)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Ud_Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "Note_Frais"
        Me.Tag = "ECR"
        Me.Text = "Note de frais"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Frais, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnl_internationale.ResumeLayout(False)
        Me.pnl_internationale.PerformLayout()
        Me.pnl_nationale.ResumeLayout(False)
        Me.pnl_nationale.PerformLayout()
        CType(Me.pb_Valide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ud_Panel1.ResumeLayout(False)
        Me.Ud_Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Commentaire_txt As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Grade_Text As ud_TextBox
    Friend WithEvents Lib_Grade_Text As ud_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Dat_NF_txt As ud_TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Num_NF_txt As ud_TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents pb_Valide As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Grd_Frais As ud_Grd
    Friend WithEvents Mnt_NF_txt As ud_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Typ_Frais As DataGridViewComboBoxColumn
    Friend WithEvents Base As DataGridViewTextBoxColumn
    Friend WithEvents Tx As DataGridViewTextBoxColumn
    Friend WithEvents Mnt As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents Comment As DataGridViewTextBoxColumn
    Friend WithEvents Num_OM_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Dat_OM_txt As ud_TextBox
    Friend WithEvents Typ_Deplacement_cbo As ud_ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Typ_Mission_cbo As ud_ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents AllerRetour_chk As ud_CheckBox
    Friend WithEvents pnl_nationale As Panel
    Friend WithEvents Ville_Depart_txt As ud_TextBox
    Friend WithEvents Ville_Destination_txt As ud_TextBox
    Friend WithEvents Lib_Ville_Destination_txt As ud_TextBox
    Friend WithEvents Lib_Ville_Depart_txt As ud_TextBox
    Friend WithEvents Distance_txt As ud_TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents pnl_internationale As Panel
    Friend WithEvents Pays_Destination_txt As ud_TextBox
    Friend WithEvents Lib_Pays_Destination_txt As ud_TextBox
    Friend WithEvents Dat_Au_txt As ud_TextBox
    Friend WithEvents Dat_Du_txt As ud_TextBox
    Friend WithEvents Objet_Mission_txt As ud_TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Ud_Panel1 As ud_Panel
    Friend WithEvents Pays_lbl As Label
    Friend WithEvents Destination_lbl As Label
    Friend WithEvents Depart_lbl As Label
    Friend WithEvents Au_lbl As Label
    Friend WithEvents Du_lbl As Label
    Friend WithEvents Avance_Deplament_chk As ud_CheckBox
    Friend WithEvents Moyen_Transport_cbo As ud_ComboBox
    Friend WithEvents Label9 As Label
End Class
