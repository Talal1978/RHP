<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_SP_SqlSource
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
    'le fichier .vb ne contient que la logique (contrôle d'injection,
    'événements, résultat).
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Zoom_SP_SqlSource))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.main = New System.Windows.Forms.TableLayoutPanel()
        Me.aide = New System.Windows.Forms.Label()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.lblControle = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.main.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(780, 435)
        Me.Panel1.TabIndex = 1
        '
        'main
        '
        Me.main.ColumnCount = 1
        Me.main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.main.Controls.Add(Me.aide, 0, 0)
        Me.main.Controls.Add(Me.txtSql, 0, 1)
        Me.main.Controls.Add(Me.lblControle, 0, 2)
        Me.main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.main.Location = New System.Drawing.Point(0, 0)
        Me.main.Name = "main"
        Me.main.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.main.Size = New System.Drawing.Size(780, 435)
        Me.main.TabIndex = 0
        '
        'aide
        '
        Me.aide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aide.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.aide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.aide.Location = New System.Drawing.Point(13, 8)
        Me.aide.Name = "aide"
        Me.aide.Size = New System.Drawing.Size(754, 50)
        Me.aide.TabIndex = 0
        Me.aide.Text = resources.GetString("aide.Text")
        '
        'txtSql
        '
        Me.txtSql.AcceptsReturn = True
        Me.txtSql.AcceptsTab = True
        Me.txtSql.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSql.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtSql.Location = New System.Drawing.Point(13, 61)
        Me.txtSql.Multiline = True
        Me.txtSql.Name = "txtSql"
        Me.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSql.Size = New System.Drawing.Size(754, 341)
        Me.txtSql.TabIndex = 1
        '
        'lblControle
        '
        Me.lblControle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblControle.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblControle.Location = New System.Drawing.Point(13, 405)
        Me.lblControle.Name = "lblControle"
        Me.lblControle.Size = New System.Drawing.Size(754, 22)
        Me.lblControle.TabIndex = 2
        Me.lblControle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.ent_pnl.Size = New System.Drawing.Size(780, 45)
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
        Me.Zoom_lbl.Size = New System.Drawing.Size(684, 39)
        Me.Zoom_lbl.TabIndex = 0
        Me.Zoom_lbl.Text = "Édition de la requête SQL"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Save_pb
        '
        Me.Save_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(696, 4)
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
        Me.Close_pb.Location = New System.Drawing.Point(740, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(36, 37)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 2
        Me.Close_pb.TabStop = False
        '
        'Zoom_SP_SqlSource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 484)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ent_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_SP_SqlSource"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Édition de la requête SQL"
        Me.Panel1.ResumeLayout(False)
        Me.main.ResumeLayout(False)
        Me.main.PerformLayout()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents aide As Label
    Friend WithEvents txtSql As TextBox
    Friend WithEvents lblControle As Label
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents main As TableLayoutPanel
End Class
