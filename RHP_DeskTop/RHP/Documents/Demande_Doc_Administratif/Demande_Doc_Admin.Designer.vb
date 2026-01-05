<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Demande_Doc_Admin
    Inherits Ecran

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grd_Docs = New RHP.ud_Grd()
        Me.Typ_Doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nbr_Exemplaire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dat_Du = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dat_Au = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Commentaire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Etat_Ligne = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Etat_Traitement_cbo = New RHP.ud_ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Statut_txt = New RHP.ud_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Num_Demande_txt = New RHP.ud_TextBox()
        Me.Dat_Demande_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Matricule_txt = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Commentaire_txt = New RHP.ud_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Ud_Panel1 = New RHP.ud_Panel()
        Me.statut_ = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Docs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Ud_Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grd_Docs)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1333, 738)
        Me.Panel1.TabIndex = 0
        '
        'Grd_Docs
        '
        Me.Grd_Docs.AfficherLesEntetesLignes = True
        Me.Grd_Docs.AllowUserToAddRows = False
        Me.Grd_Docs.AllowUserToDeleteRows = False
        Me.Grd_Docs.AlternerLesLignes = False
        Me.Grd_Docs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Docs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Docs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Docs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Docs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Typ_Doc, Me.Nbr_Exemplaire, Me.Dat_Du, Me.Dat_Au, Me.Commentaire, Me.Etat_Ligne})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Docs.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Docs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Docs.EnableHeadersVisualStyles = False
        Me.Grd_Docs.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Docs.Location = New System.Drawing.Point(0, 246)
        Me.Grd_Docs.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Docs.Name = "Grd_Docs"
        Me.Grd_Docs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Grd_Docs.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Docs.RowHeadersWidth = 51
        Me.Grd_Docs.Size = New System.Drawing.Size(1333, 492)
        Me.Grd_Docs.TabIndex = 1
        '
        'Typ_Doc
        '
        Me.Typ_Doc.HeaderText = "Type Document"
        Me.Typ_Doc.MinimumWidth = 6
        Me.Typ_Doc.Name = "Typ_Doc"
        Me.Typ_Doc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Typ_Doc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Typ_Doc.Width = 200
        '
        'Nbr_Exemplaire
        '
        Me.Nbr_Exemplaire.HeaderText = "Nbr Ex."
        Me.Nbr_Exemplaire.MinimumWidth = 6
        Me.Nbr_Exemplaire.Name = "Nbr_Exemplaire"
        Me.Nbr_Exemplaire.ReadOnly = True
        Me.Nbr_Exemplaire.Width = 60
        '
        'Dat_Du
        '
        Me.Dat_Du.HeaderText = "Du"
        Me.Dat_Du.MinimumWidth = 6
        Me.Dat_Du.Name = "Dat_Du"
        Me.Dat_Du.ReadOnly = True
        Me.Dat_Du.Width = 125
        '
        'Dat_Au
        '
        Me.Dat_Au.HeaderText = "Au"
        Me.Dat_Au.MinimumWidth = 6
        Me.Dat_Au.Name = "Dat_Au"
        Me.Dat_Au.ReadOnly = True
        Me.Dat_Au.Width = 125
        '
        'Commentaire
        '
        Me.Commentaire.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Commentaire.HeaderText = "Commentaire"
        Me.Commentaire.MinimumWidth = 6
        Me.Commentaire.Name = "Commentaire"
        Me.Commentaire.ReadOnly = True
        '
        'Etat_Ligne
        '
        Me.Etat_Ligne.HeaderText = "Etat"
        Me.Etat_Ligne.MinimumWidth = 6
        Me.Etat_Ligne.Name = "Etat_Ligne"
        Me.Etat_Ligne.Width = 125
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.statut_)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.Etat_Traitement_cbo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Statut_txt)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Num_Demande_txt)
        Me.GroupBox2.Controls.Add(Me.Dat_Demande_txt)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Matricule_txt)
        Me.GroupBox2.Controls.Add(Me.Nom_Agent_Text)
        Me.GroupBox2.Controls.Add(Me.Commentaire_txt)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1333, 246)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fiche signalitique"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(32, 47)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(99, 19)
        Me.LinkLabel3.TabIndex = 250
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "SC"
        Me.LinkLabel3.Text = "N° demande"
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Etat_Traitement_cbo
        '
        Me.Etat_Traitement_cbo.DataSource = Nothing
        Me.Etat_Traitement_cbo.DisplayMember = ""
        Me.Etat_Traitement_cbo.DroppedDown = False
        Me.Etat_Traitement_cbo.Enabled = False
        Me.Etat_Traitement_cbo.Location = New System.Drawing.Point(800, 77)
        Me.Etat_Traitement_cbo.Margin = New System.Windows.Forms.Padding(5)
        Me.Etat_Traitement_cbo.Name = "Etat_Traitement_cbo"
        Me.Etat_Traitement_cbo.SelectedIndex = -1
        Me.Etat_Traitement_cbo.SelectedItem = Nothing
        Me.Etat_Traitement_cbo.SelectedValue = Nothing
        Me.Etat_Traitement_cbo.Size = New System.Drawing.Size(267, 32)
        Me.Etat_Traitement_cbo.TabIndex = 10
        Me.Etat_Traitement_cbo.ValueMember = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(667, 81)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 19)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Etat Traitement"
        '
        'Statut_txt
        '
        Me.Statut_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Statut_txt.ContextMenuStrip = Nothing
        Me.Statut_txt.Location = New System.Drawing.Point(800, 37)
        Me.Statut_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Statut_txt.MaxLength = 32767
        Me.Statut_txt.Multiline = False
        Me.Statut_txt.Name = "Statut_txt"
        Me.Statut_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Statut_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Statut_txt.ReadOnly = True
        Me.Statut_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Statut_txt.SelectionStart = 0
        Me.Statut_txt.Size = New System.Drawing.Size(267, 32)
        Me.Statut_txt.TabIndex = 8
        Me.Statut_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Statut_txt.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(667, 41)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 19)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Statut"
        '
        'Num_Demande_txt
        '
        Me.Num_Demande_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Demande_txt.ContextMenuStrip = Nothing
        Me.Num_Demande_txt.Location = New System.Drawing.Point(133, 37)
        Me.Num_Demande_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Num_Demande_txt.MaxLength = 32767
        Me.Num_Demande_txt.Multiline = False
        Me.Num_Demande_txt.Name = "Num_Demande_txt"
        Me.Num_Demande_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Demande_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Demande_txt.ReadOnly = True
        Me.Num_Demande_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Demande_txt.SelectionStart = 0
        Me.Num_Demande_txt.Size = New System.Drawing.Size(200, 32)
        Me.Num_Demande_txt.TabIndex = 0
        Me.Num_Demande_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Demande_txt.UseSystemPasswordChar = False
        '
        'Dat_Demande_txt
        '
        Me.Dat_Demande_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Demande_txt.ContextMenuStrip = Nothing
        Me.Dat_Demande_txt.Location = New System.Drawing.Point(467, 37)
        Me.Dat_Demande_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Dat_Demande_txt.MaxLength = 32767
        Me.Dat_Demande_txt.Multiline = False
        Me.Dat_Demande_txt.Name = "Dat_Demande_txt"
        Me.Dat_Demande_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Demande_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Demande_txt.ReadOnly = True
        Me.Dat_Demande_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Demande_txt.SelectionStart = 0
        Me.Dat_Demande_txt.Size = New System.Drawing.Size(133, 32)
        Me.Dat_Demande_txt.TabIndex = 1
        Me.Dat_Demande_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Demande_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 80)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Matricule"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(420, 45)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Date"
        '
        'Matricule_txt
        '
        Me.Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_txt.ContextMenuStrip = Nothing
        Me.Matricule_txt.Location = New System.Drawing.Point(133, 74)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Matricule_txt.MaxLength = 32767
        Me.Matricule_txt.Multiline = False
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_txt.SelectionStart = 0
        Me.Matricule_txt.Size = New System.Drawing.Size(133, 32)
        Me.Matricule_txt.TabIndex = 2
        Me.Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_txt.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.ContextMenuStrip = Nothing
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(280, 74)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(320, 32)
        Me.Nom_Agent_Text.TabIndex = 3
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Commentaire_txt
        '
        Me.Commentaire_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Commentaire_txt.ContextMenuStrip = Nothing
        Me.Commentaire_txt.Location = New System.Drawing.Point(133, 116)
        Me.Commentaire_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Commentaire_txt.MaxLength = 32767
        Me.Commentaire_txt.Multiline = True
        Me.Commentaire_txt.Name = "Commentaire_txt"
        Me.Commentaire_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Commentaire_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Commentaire_txt.ReadOnly = False
        Me.Commentaire_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Commentaire_txt.SelectionStart = 0
        Me.Commentaire_txt.Size = New System.Drawing.Size(933, 74)
        Me.Commentaire_txt.TabIndex = 4
        Me.Commentaire_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Commentaire_txt.UseSystemPasswordChar = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 119)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 19)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Commentaire"
        '
        'Ud_Panel1
        '
        Me.Ud_Panel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel1.BorderSize = 2
        Me.Ud_Panel1.Controls.Add(Me.Panel1)
        Me.Ud_Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Ud_Panel1.Name = "Ud_Panel1"
        Me.Ud_Panel1.Size = New System.Drawing.Size(1333, 738)
        Me.Ud_Panel1.TabIndex = 0
        '
        'statut_
        '
        Me.statut_.AutoSize = True
        Me.statut_.ForeColor = System.Drawing.Color.Red
        Me.statut_.Location = New System.Drawing.Point(129, 195)
        Me.statut_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.statut_.Name = "statut_"
        Me.statut_.Size = New System.Drawing.Size(302, 19)
        Me.statut_.TabIndex = 251
        Me.statut_.Text = "* Demande non encore totalement signée"
        Me.statut_.Visible = False
        '
        'Demande_Doc_Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1333, 738)
        Me.Controls.Add(Me.Ud_Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Demande_Doc_Admin"
        Me.Tag = "ECR"
        Me.Text = "Demande Document Administratif"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Docs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Ud_Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Grd_Docs As RHP.ud_Grd
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Num_Demande_txt As RHP.ud_TextBox
    Friend WithEvents Dat_Demande_txt As RHP.ud_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Matricule_txt As RHP.ud_TextBox
    Friend WithEvents Nom_Agent_Text As RHP.ud_TextBox
    Friend WithEvents Commentaire_txt As RHP.ud_TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Statut_txt As RHP.ud_TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Etat_Traitement_cbo As RHP.ud_ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Ud_Panel1 As RHP.ud_Panel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Typ_Doc As DataGridViewTextBoxColumn
    Friend WithEvents Nbr_Exemplaire As DataGridViewTextBoxColumn
    Friend WithEvents Dat_Du As DataGridViewTextBoxColumn
    Friend WithEvents Dat_Au As DataGridViewTextBoxColumn
    Friend WithEvents Commentaire As DataGridViewTextBoxColumn
    Friend WithEvents Etat_Ligne As DataGridViewComboBoxColumn
    Friend WithEvents statut_ As Label
End Class
