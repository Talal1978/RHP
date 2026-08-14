<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SP_Zoom_SqlSource
    Inherits Form

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
    'Thème visuel des écrans modaux RHP (cadre colorBase01, bandeau titre,
    'panel clair, contrôles ud_button) — mêmes règles que
    'Zoom_Org_Organigramme_Affectation. Toute l'apparence est ici ; le fichier
    '.vb ne contient que la logique (contrôle d'injection, événements).
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.titre = New System.Windows.Forms.Label()
        Me.aide = New System.Windows.Forms.Label()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.lblControle = New System.Windows.Forms.Label()
        Me.btnAppliquer = New RHP.ud_button()
        Me.btnAnnuler = New RHP.ud_button()
        Me.SuspendLayout()
        '
        'SP_Zoom_SqlSource (cadre colorBase01 sans bordure)
        '
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Text = "Édition de la requête SQL"
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ClientSize = New System.Drawing.Size(780, 480)
        Me.ShowInTaskbar = False
        Me.KeyPreview = True
        Me.BackColor = colorBase01
        Me.Padding = New System.Windows.Forms.Padding(2)
        '
        'titre (bandeau colorBase01, texte posé par le constructeur)
        '
        Me.titre.Dock = System.Windows.Forms.DockStyle.Top
        Me.titre.Height = 39
        Me.titre.BackColor = colorBase01
        Me.titre.ForeColor = System.Drawing.Color.White
        Me.titre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.titre.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.titre.Text = "  Édition de la requête SQL"
        Me.Controls.Add(Me.titre)
        '
        'fond (panel clair)
        '
        Dim fond As New System.Windows.Forms.Panel()
        fond.Dock = System.Windows.Forms.DockStyle.Fill
        fond.BackColor = System.Drawing.Color.White
        Me.Controls.Add(fond)
        fond.BringToFront()
        '
        'main (grille de disposition : aide / éditeur / contrôle / boutons)
        '
        Dim main As New System.Windows.Forms.TableLayoutPanel()
        main.Dock = System.Windows.Forms.DockStyle.Fill
        main.ColumnCount = 1
        main.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        fond.Controls.Add(main)
        '
        'aide
        '
        Me.aide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aide.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110)
        Me.aide.Text = "Lecture seule uniquement : SELECT / WITH ou EXEC dbo.Sys_*. Une seule instruction. " &
                       "Les paramètres @xxx se déclarent dans la colonne 'Paramètres' ; @id_Societe est injecté automatiquement par le serveur."
        main.Controls.Add(Me.aide, 0, 0)
        '
        'txtSql (éditeur SQL multi-lignes)
        '
        Me.txtSql.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSql.Multiline = True
        Me.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSql.WordWrap = False
        Me.txtSql.AcceptsReturn = True
        Me.txtSql.AcceptsTab = True
        Me.txtSql.Font = New System.Drawing.Font("Consolas", 9.0!)
        main.Controls.Add(Me.txtSql, 0, 1)
        '
        'lblControle (indicateur de conformité sous l'éditeur)
        '
        Me.lblControle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblControle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        main.Controls.Add(Me.lblControle, 0, 2)
        '
        'Boutons (Appliquer / Annuler)
        '
        Dim pnlBoutons As New System.Windows.Forms.FlowLayoutPanel()
        pnlBoutons.Dock = System.Windows.Forms.DockStyle.Fill
        pnlBoutons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(125, 34)
        Me.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnnuler.bgColor = System.Drawing.Color.White
        Me.btnAnnuler.Border = RHP.ud_button.BorderStyle.All
        Me.btnAnnuler.BorderColor = colorBase01
        Me.btnAnnuler.BorderSize = 2
        Me.btnAnnuler.Image = My.Resources.Resources.btn_close
        Me.btnAppliquer.Text = "Appliquer"
        Me.btnAppliquer.Size = New System.Drawing.Size(150, 34)
        Me.btnAppliquer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAppliquer.bgColor = System.Drawing.Color.White
        Me.btnAppliquer.Border = RHP.ud_button.BorderStyle.All
        Me.btnAppliquer.BorderColor = colorBase01
        Me.btnAppliquer.BorderSize = 2
        Me.btnAppliquer.Image = My.Resources.Resources.btn_save
        pnlBoutons.Controls.Add(Me.btnAnnuler)
        pnlBoutons.Controls.Add(Me.btnAppliquer)
        main.Controls.Add(pnlBoutons, 0, 3)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents titre As Label
    Friend WithEvents aide As Label
    Friend WithEvents txtSql As TextBox
    Friend WithEvents lblControle As Label
    Friend WithEvents btnAppliquer As ud_button
    Friend WithEvents btnAnnuler As ud_button
End Class
