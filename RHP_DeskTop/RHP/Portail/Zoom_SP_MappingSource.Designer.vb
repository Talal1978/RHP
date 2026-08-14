<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_SP_MappingSource
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

    'REMARQUE : la procédure suivante construit toute l'interface du zoom.
    'Thème visuel des écrans exclusivement modaux (instruction permanente) :
    'identique à Zoom_SP_Nouvelle_Section — formulaire sans bordure cadré
    'colorBase01, bandeau titre gris clair (ent_pnl : Zoom_lbl + boutons
    'icônes PictureBox), panel de contenu clair. Toute l'apparence est ici ;
    'le fichier .vb ne contient que la logique (lecture des paramètres de la
    'source, génération du json de mapping, événements, résultat).
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.main = New System.Windows.Forms.TableLayoutPanel()
        Me.aide = New System.Windows.Forms.Label()
        Me.pnlGrille = New System.Windows.Forms.Panel()
        Me.grdMap = New System.Windows.Forms.DataGridView()
        Me.colMapParam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMapObligatoire = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colMapMode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colMapChamp = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colMapConstante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlAvance = New System.Windows.Forms.Panel()
        Me.txtAvance = New System.Windows.Forms.TextBox()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.pnlApercu = New System.Windows.Forms.Panel()
        Me.txtJson = New System.Windows.Forms.TextBox()
        Me.lblApercu = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.main.SuspendLayout()
        Me.pnlGrille.SuspendLayout()
        CType(Me.grdMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAvance.SuspendLayout()
        Me.pnlApercu.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(856, 471)
        Me.Panel1.TabIndex = 1
        '
        'main
        '
        Me.main.ColumnCount = 1
        Me.main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.main.Controls.Add(Me.aide, 0, 0)
        Me.main.Controls.Add(Me.pnlGrille, 0, 1)
        Me.main.Controls.Add(Me.pnlApercu, 0, 2)
        Me.main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.main.Location = New System.Drawing.Point(0, 0)
        Me.main.Name = "main"
        Me.main.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.main.Size = New System.Drawing.Size(856, 471)
        Me.main.TabIndex = 0
        '
        'aide
        '
        Me.aide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aide.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.aide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.aide.Location = New System.Drawing.Point(13, 8)
        Me.aide.Name = "aide"
        Me.aide.Size = New System.Drawing.Size(830, 66)
        Me.aide.TabIndex = 0
        Me.aide.Text = "Pour chaque paramètre déclaré de la source, choisissez comment il est alimenté : un champ de l'entête du document ou une constante." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "La grille est recalculée par la source à chaque changement d'un champ alimentant un paramètre (jamais stockée, lecture seule)." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "@id_Societe (et @Login / @Matricule / @Cod_Profile non déclarés) sont injectés automatiquement par le serveur."
        '
        'pnlGrille
        '
        Me.pnlGrille.Controls.Add(Me.grdMap)
        Me.pnlGrille.Controls.Add(Me.pnlAvance)
        Me.pnlGrille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrille.Location = New System.Drawing.Point(13, 77)
        Me.pnlGrille.Name = "pnlGrille"
        Me.pnlGrille.Size = New System.Drawing.Size(830, 343)
        Me.pnlGrille.TabIndex = 1
        '
        'grdMap
        '
        Me.grdMap.AllowUserToAddRows = False
        Me.grdMap.AllowUserToDeleteRows = False
        Me.grdMap.AutoGenerateColumns = False
        Me.grdMap.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdMap.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdMap.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMapParam, Me.colMapObligatoire, Me.colMapMode, Me.colMapChamp, Me.colMapConstante})
        Me.grdMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMap.EnableHeadersVisualStyles = False
        Me.grdMap.Location = New System.Drawing.Point(0, 0)
        Me.grdMap.Name = "grdMap"
        Me.grdMap.RowHeadersVisible = False
        Me.grdMap.Size = New System.Drawing.Size(830, 343)
        Me.grdMap.TabIndex = 0
        '
        'colMapParam
        '
        Me.colMapParam.HeaderText = "Paramètre de la source"
        Me.colMapParam.Name = "colMapParam"
        Me.colMapParam.ReadOnly = True
        Me.colMapParam.Width = 170
        '
        'colMapObligatoire
        '
        Me.colMapObligatoire.HeaderText = "Obligatoire"
        Me.colMapObligatoire.Name = "colMapObligatoire"
        Me.colMapObligatoire.ReadOnly = True
        Me.colMapObligatoire.Width = 80
        '
        'colMapMode
        '
        Me.colMapMode.HeaderText = "Alimenté par"
        Me.colMapMode.Items.AddRange(New Object() {"Champ de l'entête", "Constante", "(non alimenté)"})
        Me.colMapMode.Name = "colMapMode"
        Me.colMapMode.Width = 140
        '
        'colMapChamp
        '
        Me.colMapChamp.HeaderText = "Champ de l'entête"
        Me.colMapChamp.Name = "colMapChamp"
        Me.colMapChamp.Width = 220
        '
        'colMapConstante
        '
        Me.colMapConstante.HeaderText = "Constante"
        Me.colMapConstante.Name = "colMapConstante"
        Me.colMapConstante.Width = 200
        '
        'pnlAvance
        '
        Me.pnlAvance.Controls.Add(Me.txtAvance)
        Me.pnlAvance.Controls.Add(Me.lblAvance)
        Me.pnlAvance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAvance.Location = New System.Drawing.Point(0, 0)
        Me.pnlAvance.Name = "pnlAvance"
        Me.pnlAvance.Size = New System.Drawing.Size(830, 343)
        Me.pnlAvance.TabIndex = 1
        Me.pnlAvance.Visible = False
        '
        'txtAvance
        '
        Me.txtAvance.AcceptsReturn = True
        Me.txtAvance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAvance.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtAvance.Location = New System.Drawing.Point(0, 40)
        Me.txtAvance.Multiline = True
        Me.txtAvance.Name = "txtAvance"
        Me.txtAvance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAvance.Size = New System.Drawing.Size(830, 303)
        Me.txtAvance.TabIndex = 1
        Me.txtAvance.WordWrap = False
        '
        'lblAvance
        '
        Me.lblAvance.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAvance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblAvance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblAvance.Location = New System.Drawing.Point(0, 0)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(830, 40)
        Me.lblAvance.TabIndex = 0
        Me.lblAvance.Text = "Le mapping existant n'est pas représentable par l'assistant : il est conservé tel quel." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vous pouvez le corriger ci-dessous (mode avancé) : {""Paramètre"":{""ref"":""Champ""}} ou {""Paramètre"":{""const"":""valeur""}}."
        '
        'pnlApercu
        '
        Me.pnlApercu.Controls.Add(Me.txtJson)
        Me.pnlApercu.Controls.Add(Me.lblApercu)
        Me.pnlApercu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlApercu.Location = New System.Drawing.Point(13, 426)
        Me.pnlApercu.Name = "pnlApercu"
        Me.pnlApercu.Size = New System.Drawing.Size(830, 34)
        Me.pnlApercu.TabIndex = 2
        '
        'txtJson
        '
        Me.txtJson.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtJson.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtJson.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.txtJson.Location = New System.Drawing.Point(190, 0)
        Me.txtJson.Name = "txtJson"
        Me.txtJson.ReadOnly = True
        Me.txtJson.Size = New System.Drawing.Size(640, 24)
        Me.txtJson.TabIndex = 1
        '
        'lblApercu
        '
        Me.lblApercu.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblApercu.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblApercu.Location = New System.Drawing.Point(0, 0)
        Me.lblApercu.Name = "lblApercu"
        Me.lblApercu.Size = New System.Drawing.Size(190, 34)
        Me.lblApercu.TabIndex = 0
        Me.lblApercu.Text = "Mapping généré (automatique) :"
        Me.lblApercu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.ent_pnl.Size = New System.Drawing.Size(856, 45)
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
        Me.Zoom_lbl.Size = New System.Drawing.Size(760, 39)
        Me.Zoom_lbl.TabIndex = 0
        Me.Zoom_lbl.Text = "Alimentation de la grille virtuelle"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Save_pb
        '
        Me.Save_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(772, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(36, 37)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 1
        Me.Save_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(816, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(36, 37)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 2
        Me.Close_pb.TabStop = False
        '
        'Zoom_SP_MappingSource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(860, 520)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ent_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_SP_MappingSource"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Alimentation de la grille virtuelle"
        Me.Panel1.ResumeLayout(False)
        Me.main.ResumeLayout(False)
        Me.pnlGrille.ResumeLayout(False)
        CType(Me.grdMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAvance.ResumeLayout(False)
        Me.pnlAvance.PerformLayout()
        Me.pnlApercu.ResumeLayout(False)
        Me.pnlApercu.PerformLayout()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents main As TableLayoutPanel
    Friend WithEvents aide As Label
    Friend WithEvents pnlGrille As Panel
    Friend WithEvents grdMap As DataGridView
    Friend WithEvents colMapParam As DataGridViewTextBoxColumn
    Friend WithEvents colMapObligatoire As DataGridViewCheckBoxColumn
    Friend WithEvents colMapMode As DataGridViewComboBoxColumn
    Friend WithEvents colMapChamp As DataGridViewComboBoxColumn
    Friend WithEvents colMapConstante As DataGridViewTextBoxColumn
    Friend WithEvents pnlAvance As Panel
    Friend WithEvents txtAvance As TextBox
    Friend WithEvents lblAvance As Label
    Friend WithEvents pnlApercu As Panel
    Friend WithEvents txtJson As TextBox
    Friend WithEvents lblApercu As Label
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
End Class
