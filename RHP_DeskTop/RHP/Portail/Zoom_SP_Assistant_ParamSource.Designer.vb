<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_SP_Assistant_ParamSource
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

    'REMARQUE : la procédure suivante construit toute l'interface de l'assistant
    '(convention permanente : tout le code de design est dans ce .Designer.vb ;
    'le fichier .vb ne contient que la logique — génération du json, contrôles de
    'cohérence avec la requête SQL, événements — et l'alimentation des données).
    'Disposition fixe, formulaire non redimensionnable.
    'Thème visuel des écrans exclusivement modaux (instruction permanente) :
    'identique à Zoom_SP_SqlSource — formulaire sans bordure cadré colorBase01,
    'bandeau titre gris clair (ent_pnl : Zoom_lbl + boutons icônes PictureBox),
    'panel de contenu clair.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.main = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAideIntro = New System.Windows.Forms.Label()
        Me.grpParams = New System.Windows.Forms.GroupBox()
        Me.grdParams = New System.Windows.Forms.DataGridView()
        Me.colParNom = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colParTyp = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colParObli = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblJsonAvance = New System.Windows.Forms.Label()
        Me.txtJsonAvance = New System.Windows.Forms.TextBox()
        Me.lblEx = New System.Windows.Forms.Label()
        Me.grpApercu = New System.Windows.Forms.GroupBox()
        Me.lblParamJson = New System.Windows.Forms.Label()
        Me.txtParamJson = New System.Windows.Forms.TextBox()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.main.SuspendLayout()
        Me.grpParams.SuspendLayout()
        CType(Me.grdParams, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpApercu.SuspendLayout()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.main)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 47)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(716, 438)
        Me.Panel1.TabIndex = 1
        '
        'main
        '
        Me.main.ColumnCount = 1
        Me.main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.main.Controls.Add(Me.lblAideIntro, 0, 0)
        Me.main.Controls.Add(Me.grpParams, 0, 1)
        Me.main.Controls.Add(Me.lblEx, 0, 2)
        Me.main.Controls.Add(Me.grpApercu, 0, 3)
        Me.main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.main.Location = New System.Drawing.Point(0, 0)
        Me.main.Name = "main"
        Me.main.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.main.Size = New System.Drawing.Size(716, 438)
        Me.main.TabIndex = 0
        '
        'lblAideIntro
        '
        Me.lblAideIntro.AutoSize = False
        Me.lblAideIntro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAideIntro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblAideIntro.Location = New System.Drawing.Point(0, 0)
        Me.lblAideIntro.Name = "lblAideIntro"
        Me.lblAideIntro.Size = New System.Drawing.Size(690, 78)
        Me.lblAideIntro.TabIndex = 1
        Me.lblAideIntro.Text = "Déclarez ici les paramètres de la requête SQL (ceux écrits @xxx dans la requête) :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "la syntaxe json de la colonne 'Paramètres' est générée automatiquement, aucun code à écrire." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "Le paramètre @id_Societe est injecté automatiquement par le serveur : ne le déclarez pas." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "La liste des noms propose les @xxx détectés dans la requête ; @Login / @Matricule / @Cod_Profile non déclarés" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "sont injectés avec l'identité de l'utilisateur connecté (déclarez-les pour les alimenter depuis la page)."
        '
        'grpParams
        '
        Me.grpParams.Controls.Add(Me.grdParams)
        Me.grpParams.Controls.Add(Me.lblJsonAvance)
        Me.grpParams.Controls.Add(Me.txtJsonAvance)
        Me.grpParams.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpParams.Location = New System.Drawing.Point(0, 0)
        Me.grpParams.Name = "grpParams"
        Me.grpParams.Size = New System.Drawing.Size(690, 234)
        Me.grpParams.TabIndex = 2
        Me.grpParams.TabStop = False
        Me.grpParams.Text = "Paramètres de la requête"
        '
        'grdParams
        '
        Me.grdParams.AllowUserToDeleteRows = True
        Me.grdParams.AutoGenerateColumns = False
        Me.grdParams.BackgroundColor = System.Drawing.Color.White
        Me.grdParams.ColumnHeadersDefaultCellStyle.BackColor = colorBase01
        Me.grdParams.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.grdParams.ColumnHeadersDefaultCellStyle.Font = Me.Font
        Me.grdParams.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colParNom, Me.colParTyp, Me.colParObli})
        Me.grdParams.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParams.EnableHeadersVisualStyles = False
        Me.grdParams.Location = New System.Drawing.Point(3, 19)
        Me.grdParams.Name = "grdParams"
        Me.grdParams.RowHeadersVisible = False
        Me.grdParams.TabIndex = 0
        '
        'colParNom
        '
        Me.colParNom.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.colParNom.HeaderText = "Nom (sans le @)"
        Me.colParNom.Name = "colParNom"
        Me.colParNom.Width = 240
        '
        'colParTyp
        '
        Me.colParTyp.HeaderText = "Type"
        Me.colParTyp.Name = "colParTyp"
        Me.colParTyp.Width = 200
        '
        'colParObli
        '
        Me.colParObli.HeaderText = "Obligatoire"
        Me.colParObli.Name = "colParObli"
        Me.colParObli.Width = 90
        '
        'lblJsonAvance
        '
        Me.lblJsonAvance.AutoSize = False
        Me.lblJsonAvance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblJsonAvance.Location = New System.Drawing.Point(10, 22)
        Me.lblJsonAvance.Name = "lblJsonAvance"
        Me.lblJsonAvance.Size = New System.Drawing.Size(650, 40)
        Me.lblJsonAvance.TabIndex = 1
        Me.lblJsonAvance.Text = "Le json existant n'est pas une liste de paramètres standard : il est conservé tel quel." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "Vous pouvez le corriger ci-dessous (mode avancé)."
        Me.lblJsonAvance.Visible = False
        '
        'txtJsonAvance
        '
        Me.txtJsonAvance.Location = New System.Drawing.Point(10, 64)
        Me.txtJsonAvance.Multiline = True
        Me.txtJsonAvance.Name = "txtJsonAvance"
        Me.txtJsonAvance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJsonAvance.Size = New System.Drawing.Size(650, 150)
        Me.txtJsonAvance.TabIndex = 2
        Me.txtJsonAvance.Visible = False
        '
        'lblEx
        '
        Me.lblEx.AutoSize = False
        Me.lblEx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEx.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblEx.Location = New System.Drawing.Point(0, 0)
        Me.lblEx.Name = "lblEx"
        Me.lblEx.Size = New System.Drawing.Size(690, 20)
        Me.lblEx.TabIndex = 3
        Me.lblEx.Text = "Exemple : pour la requête '... where Matricule = @Matricule', déclarez un paramètre 'Matricule'."
        '
        'grpApercu
        '
        Me.grpApercu.Controls.Add(Me.lblParamJson)
        Me.grpApercu.Controls.Add(Me.txtParamJson)
        Me.grpApercu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpApercu.Location = New System.Drawing.Point(0, 0)
        Me.grpApercu.Name = "grpApercu"
        Me.grpApercu.Size = New System.Drawing.Size(690, 60)
        Me.grpApercu.TabIndex = 4
        Me.grpApercu.TabStop = False
        Me.grpApercu.Text = "Aperçu de la syntaxe générée (automatique — rien à saisir)"
        '
        'txtParamJson
        '
        Me.txtParamJson.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtParamJson.Location = New System.Drawing.Point(140, 22)
        Me.txtParamJson.Name = "txtParamJson"
        Me.txtParamJson.ReadOnly = True
        Me.txtParamJson.Size = New System.Drawing.Size(530, 24)
        Me.txtParamJson.TabIndex = 0
        '
        'lblParamJson
        '
        Me.lblParamJson.AutoSize = False
        Me.lblParamJson.Location = New System.Drawing.Point(10, 24)
        Me.lblParamJson.Name = "lblParamJson"
        Me.lblParamJson.Size = New System.Drawing.Size(125, 20)
        Me.lblParamJson.Text = "Paramètres (json) :"
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ent_pnl.ColumnCount = 3
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.Controls.Add(Me.Zoom_lbl, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Save_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 2, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(716, 45)
        Me.ent_pnl.TabIndex = 0
        '
        'Zoom_lbl
        '
        Me.Zoom_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Zoom_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Zoom_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Zoom_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Zoom_lbl.Location = New System.Drawing.Point(4, 0)
        Me.Zoom_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Zoom_lbl.Name = "Zoom_lbl"
        Me.Zoom_lbl.Size = New System.Drawing.Size(620, 39)
        Me.Zoom_lbl.TabIndex = 0
        Me.Zoom_lbl.Text = "Assistant de paramètres de la source"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Save_pb
        '
        Me.Save_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(632, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(36, 37)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 1
        Me.Save_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Save_pb, "Appliquer")
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(676, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(36, 37)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 2
        Me.Close_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Close_pb, "Annuler")
        '
        'Zoom_SP_Assistant_ParamSource
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(720, 487)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ent_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Zoom_SP_Assistant_ParamSource"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assistant de paramètres de la source"
        Me.Panel1.ResumeLayout(False)
        Me.main.ResumeLayout(False)
        Me.grpParams.ResumeLayout(False)
        Me.grpParams.PerformLayout()
        CType(Me.grdParams, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpApercu.ResumeLayout(False)
        Me.grpApercu.PerformLayout()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents main As TableLayoutPanel
    Friend WithEvents lblAideIntro As Label
    Friend WithEvents grpParams As GroupBox
    Friend WithEvents grdParams As DataGridView
    Friend WithEvents colParNom As DataGridViewComboBoxColumn
    Friend WithEvents colParTyp As DataGridViewComboBoxColumn
    Friend WithEvents colParObli As DataGridViewCheckBoxColumn
    Friend WithEvents lblJsonAvance As Label
    Friend WithEvents txtJsonAvance As TextBox
    Friend WithEvents lblEx As Label
    Friend WithEvents grpApercu As GroupBox
    Friend WithEvents lblParamJson As Label
    Friend WithEvents txtParamJson As TextBox
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
