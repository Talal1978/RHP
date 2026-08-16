<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_SP_Assistant_IA
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
    'le fichier .vb ne contient que la logique (conversation avec l'assistant
    'IA : questions sur l'aide / génération du JSON d'une page via le skill).
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Nouveau_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.main = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlModes = New System.Windows.Forms.TableLayoutPanel()
        Me.rdoAide = New System.Windows.Forms.RadioButton()
        Me.rdoGeneration = New System.Windows.Forms.RadioButton()
        Me.lblStatut = New System.Windows.Forms.Label()
        Me.txtChat = New System.Windows.Forms.RichTextBox()
        Me.pnlTelechargement = New System.Windows.Forms.Panel()
        Me.lblFichier = New System.Windows.Forms.Label()
        Me.lnkTelechargement = New System.Windows.Forms.LinkLabel()
        Me.lnkDossier = New System.Windows.Forms.LinkLabel()
        Me.pnlSaisie = New System.Windows.Forms.TableLayoutPanel()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Envoyer_pb = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ent_pnl.SuspendLayout()
        CType(Me.Nouveau_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.main.SuspendLayout()
        Me.pnlModes.SuspendLayout()
        Me.pnlTelechargement.SuspendLayout()
        Me.pnlSaisie.SuspendLayout()
        CType(Me.Envoyer_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ent_pnl.ColumnCount = 3
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.Controls.Add(Me.Zoom_lbl, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Nouveau_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 2, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(916, 45)
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
        Me.Zoom_lbl.Size = New System.Drawing.Size(820, 39)
        Me.Zoom_lbl.TabIndex = 0
        Me.Zoom_lbl.Text = "Assistant IA — Designer de pages portail"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Nouveau_pb
        '
        Me.Nouveau_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nouveau_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Nouveau_pb.Image = Global.RHP.My.Resources.Resources.btn_add
        Me.Nouveau_pb.Location = New System.Drawing.Point(832, 4)
        Me.Nouveau_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Nouveau_pb.Name = "Nouveau_pb"
        Me.Nouveau_pb.Size = New System.Drawing.Size(36, 37)
        Me.Nouveau_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Nouveau_pb.TabIndex = 1
        Me.Nouveau_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Nouveau_pb, "Nouvelle conversation")
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(876, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(36, 37)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 2
        Me.Close_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Close_pb, "Fermer")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.main)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 47)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(916, 591)
        Me.Panel1.TabIndex = 1
        '
        'main
        '
        Me.main.ColumnCount = 1
        Me.main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.main.Controls.Add(Me.pnlModes, 0, 0)
        Me.main.Controls.Add(Me.txtChat, 0, 1)
        Me.main.Controls.Add(Me.pnlTelechargement, 0, 2)
        Me.main.Controls.Add(Me.pnlSaisie, 0, 3)
        Me.main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.main.Location = New System.Drawing.Point(0, 0)
        Me.main.Name = "main"
        Me.main.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.main.RowCount = 4
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.main.Size = New System.Drawing.Size(916, 591)
        Me.main.TabIndex = 0
        '
        'pnlModes
        '
        Me.pnlModes.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlModes.ColumnCount = 3
        Me.pnlModes.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModes.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModes.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlModes.Controls.Add(Me.rdoAide, 0, 0)
        Me.pnlModes.Controls.Add(Me.rdoGeneration, 1, 0)
        Me.pnlModes.Controls.Add(Me.lblStatut, 2, 0)
        Me.pnlModes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlModes.Location = New System.Drawing.Point(13, 11)
        Me.pnlModes.Name = "pnlModes"
        Me.pnlModes.RowCount = 1
        Me.pnlModes.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlModes.Size = New System.Drawing.Size(890, 28)
        Me.pnlModes.TabIndex = 0
        '
        'rdoAide
        '
        Me.rdoAide.AutoSize = True
        Me.rdoAide.Checked = True
        Me.rdoAide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoAide.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.rdoAide.Location = New System.Drawing.Point(3, 3)
        Me.rdoAide.Name = "rdoAide"
        Me.rdoAide.Size = New System.Drawing.Size(595, 22)
        Me.rdoAide.TabIndex = 0
        Me.rdoAide.TabStop = True
        Me.rdoAide.Text = "Aide — questions sur la création de pages (formules, paramètres, sources métier…)" &
    ""
        Me.rdoAide.UseVisualStyleBackColor = True
        '
        'rdoGeneration
        '
        Me.rdoGeneration.AutoSize = True
        Me.rdoGeneration.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoGeneration.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.rdoGeneration.Location = New System.Drawing.Point(604, 3)
        Me.rdoGeneration.Name = "rdoGeneration"
        Me.rdoGeneration.Size = New System.Drawing.Size(353, 22)
        Me.rdoGeneration.TabIndex = 1
        Me.rdoGeneration.Text = "Génération — créer le fichier JSON d'une page"
        Me.rdoGeneration.UseVisualStyleBackColor = True
        '
        'lblStatut
        '
        Me.lblStatut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatut.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblStatut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblStatut.Location = New System.Drawing.Point(963, 0)
        Me.lblStatut.Name = "lblStatut"
        Me.lblStatut.Size = New System.Drawing.Size(1, 28)
        Me.lblStatut.TabIndex = 2
        Me.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChat
        '
        Me.txtChat.BackColor = System.Drawing.Color.White
        Me.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChat.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.txtChat.Location = New System.Drawing.Point(13, 45)
        Me.txtChat.Name = "txtChat"
        Me.txtChat.ReadOnly = True
        Me.txtChat.Size = New System.Drawing.Size(890, 443)
        Me.txtChat.TabIndex = 1
        Me.txtChat.Text = ""
        '
        'pnlTelechargement
        '
        Me.pnlTelechargement.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.pnlTelechargement.Controls.Add(Me.lblFichier)
        Me.pnlTelechargement.Controls.Add(Me.lnkTelechargement)
        Me.pnlTelechargement.Controls.Add(Me.lnkDossier)
        Me.pnlTelechargement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTelechargement.Location = New System.Drawing.Point(13, 494)
        Me.pnlTelechargement.Name = "pnlTelechargement"
        Me.pnlTelechargement.Size = New System.Drawing.Size(890, 24)
        Me.pnlTelechargement.TabIndex = 2
        Me.pnlTelechargement.Visible = False
        '
        'lblFichier
        '
        Me.lblFichier.AutoSize = True
        Me.lblFichier.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblFichier.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblFichier.Location = New System.Drawing.Point(8, 3)
        Me.lblFichier.Name = "lblFichier"
        Me.lblFichier.Size = New System.Drawing.Size(154, 19)
        Me.lblFichier.TabIndex = 0
        Me.lblFichier.Text = "Fichier JSON généré :"
        '
        'lnkTelechargement
        '
        Me.lnkTelechargement.AutoSize = True
        Me.lnkTelechargement.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lnkTelechargement.LinkColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lnkTelechargement.Location = New System.Drawing.Point(143, 3)
        Me.lnkTelechargement.Name = "lnkTelechargement"
        Me.lnkTelechargement.Size = New System.Drawing.Size(126, 17)
        Me.lnkTelechargement.TabIndex = 1
        Me.lnkTelechargement.TabStop = True
        Me.lnkTelechargement.Text = "RHP_Page_....json"
        Me.ToolTip1.SetToolTip(Me.lnkTelechargement, "Télécharger le fichier (choisir l'emplacement sur ce poste)")
        '
        'lnkDossier
        '
        Me.lnkDossier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDossier.AutoSize = True
        Me.lnkDossier.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lnkDossier.LinkColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lnkDossier.Location = New System.Drawing.Point(772, 3)
        Me.lnkDossier.Name = "lnkDossier"
        Me.lnkDossier.Size = New System.Drawing.Size(114, 19)
        Me.lnkDossier.TabIndex = 2
        Me.lnkDossier.TabStop = True
        Me.lnkDossier.Text = "Ouvrir le dossier"
        '
        'pnlSaisie
        '
        Me.pnlSaisie.ColumnCount = 2
        Me.pnlSaisie.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlSaisie.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.pnlSaisie.Controls.Add(Me.txtMessage, 0, 0)
        Me.pnlSaisie.Controls.Add(Me.Envoyer_pb, 1, 0)
        Me.pnlSaisie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSaisie.Location = New System.Drawing.Point(13, 524)
        Me.pnlSaisie.Name = "pnlSaisie"
        Me.pnlSaisie.RowCount = 1
        Me.pnlSaisie.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlSaisie.Size = New System.Drawing.Size(890, 56)
        Me.pnlSaisie.TabIndex = 3
        '
        'txtMessage
        '
        Me.txtMessage.AcceptsReturn = True
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessage.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.txtMessage.Location = New System.Drawing.Point(3, 3)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(840, 50)
        Me.txtMessage.TabIndex = 0
        '
        'Envoyer_pb
        '
        Me.Envoyer_pb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Envoyer_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Envoyer_pb.Image = Global.RHP.My.Resources.Resources.btn_div_next
        Me.Envoyer_pb.Location = New System.Drawing.Point(850, 9)
        Me.Envoyer_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Envoyer_pb.Name = "Envoyer_pb"
        Me.Envoyer_pb.Size = New System.Drawing.Size(36, 37)
        Me.Envoyer_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Envoyer_pb.TabIndex = 1
        Me.Envoyer_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Envoyer_pb, "Envoyer (Entrée — Maj+Entrée : saut de ligne)")
        '
        'Zoom_SP_Assistant_IA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(920, 640)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ent_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_SP_Assistant_IA"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assistant IA — Designer de pages portail"
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Nouveau_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.main.ResumeLayout(False)
        Me.pnlModes.ResumeLayout(False)
        Me.pnlModes.PerformLayout()
        Me.pnlTelechargement.ResumeLayout(False)
        Me.pnlTelechargement.PerformLayout()
        Me.pnlSaisie.ResumeLayout(False)
        Me.pnlSaisie.PerformLayout()
        CType(Me.Envoyer_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Nouveau_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents main As TableLayoutPanel
    Friend WithEvents pnlModes As TableLayoutPanel
    Friend WithEvents rdoAide As RadioButton
    Friend WithEvents rdoGeneration As RadioButton
    Friend WithEvents lblStatut As Label
    Friend WithEvents txtChat As RichTextBox
    Friend WithEvents pnlTelechargement As Panel
    Friend WithEvents lblFichier As Label
    Friend WithEvents lnkTelechargement As LinkLabel
    Friend WithEvents lnkDossier As LinkLabel
    Friend WithEvents pnlSaisie As TableLayoutPanel
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents Envoyer_pb As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
