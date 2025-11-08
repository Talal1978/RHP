<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_Org_Organigramme_ListeAgent
    inherits Ecran

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ListeAgentVues_cbo = New RHP.ud_ComboBox()
        Me.Rd_Autre = New RHP.ud_RadioBox()
        Me.Rd_Detail = New RHP.ud_RadioBox()
        Me.Rd_Grade = New RHP.ud_RadioBox()
        Me.Rd_Effect_Entite = New RHP.ud_RadioBox()
        Me.Ges_Pie_Clt_GRD = New RHP.ud_Grd()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Pnl = New System.Windows.Forms.Panel()
        CType(Me.Ges_Pie_Clt_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListeAgentVues_cbo
        '
        Me.ListeAgentVues_cbo.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ListeAgentVues_cbo.DataSource = Nothing
        Me.ListeAgentVues_cbo.DisplayMember = ""
        Me.ListeAgentVues_cbo.DroppedDown = False
        Me.ListeAgentVues_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ListeAgentVues_cbo.Location = New System.Drawing.Point(580, 9)
        Me.ListeAgentVues_cbo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListeAgentVues_cbo.Name = "ListeAgentVues_cbo"
        Me.ListeAgentVues_cbo.SelectedIndex = -1
        Me.ListeAgentVues_cbo.SelectedItem = Nothing
        Me.ListeAgentVues_cbo.SelectedValue = Nothing
        Me.ListeAgentVues_cbo.Size = New System.Drawing.Size(296, 24)
        Me.ListeAgentVues_cbo.TabIndex = 4
        Me.ListeAgentVues_cbo.ValueMember = ""
        '
        'Rd_Autre
        '
        Me.Rd_Autre.AutoSize = True
        Me.Rd_Autre.Checked = False
        Me.Rd_Autre.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_Autre.Location = New System.Drawing.Point(443, 6)
        Me.Rd_Autre.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rd_Autre.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Autre.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Autre.Name = "Rd_Autre"
        Me.Rd_Autre.Size = New System.Drawing.Size(131, 31)
        Me.Rd_Autre.TabIndex = 2
        Me.Rd_Autre.Text = "Autres vues"
        '
        'Rd_Detail
        '
        Me.Rd_Detail.AutoSize = True
        Me.Rd_Detail.Checked = False
        Me.Rd_Detail.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_Detail.Location = New System.Drawing.Point(304, 6)
        Me.Rd_Detail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rd_Detail.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Detail.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Detail.Name = "Rd_Detail"
        Me.Rd_Detail.Size = New System.Drawing.Size(131, 31)
        Me.Rd_Detail.TabIndex = 1
        Me.Rd_Detail.Text = "Effectif total"
        '
        'Rd_Grade
        '
        Me.Rd_Grade.AutoSize = True
        Me.Rd_Grade.Checked = False
        Me.Rd_Grade.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_Grade.Location = New System.Drawing.Point(158, 6)
        Me.Rd_Grade.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rd_Grade.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Grade.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Grade.Name = "Rd_Grade"
        Me.Rd_Grade.Size = New System.Drawing.Size(136, 31)
        Me.Rd_Grade.TabIndex = 1
        Me.Rd_Grade.Text = "Effectif par grade"
        '
        'Rd_Effect_Entite
        '
        Me.Rd_Effect_Entite.AutoSize = True
        Me.Rd_Effect_Entite.Checked = True
        Me.Rd_Effect_Entite.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rd_Effect_Entite.Location = New System.Drawing.Point(17, 6)
        Me.Rd_Effect_Entite.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rd_Effect_Entite.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Effect_Entite.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Rd_Effect_Entite.Name = "Rd_Effect_Entite"
        Me.Rd_Effect_Entite.Size = New System.Drawing.Size(133, 31)
        Me.Rd_Effect_Entite.TabIndex = 0
        Me.Rd_Effect_Entite.Text = "Effectif par Entité"
        '
        'Ges_Pie_Clt_GRD
        '
        Me.Ges_Pie_Clt_GRD.AllowUserToAddRows = False
        Me.Ges_Pie_Clt_GRD.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Ges_Pie_Clt_GRD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Ges_Pie_Clt_GRD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Ges_Pie_Clt_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Ges_Pie_Clt_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ges_Pie_Clt_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Ges_Pie_Clt_GRD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Ges_Pie_Clt_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Ges_Pie_Clt_GRD.DefaultCellStyle = DataGridViewCellStyle3
        Me.Ges_Pie_Clt_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ges_Pie_Clt_GRD.EnableHeadersVisualStyles = False
        Me.Ges_Pie_Clt_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Ges_Pie_Clt_GRD.Location = New System.Drawing.Point(2, 79)
        Me.Ges_Pie_Clt_GRD.Name = "Ges_Pie_Clt_GRD"
        Me.Ges_Pie_Clt_GRD.ReadOnly = True
        Me.Ges_Pie_Clt_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ges_Pie_Clt_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Ges_Pie_Clt_GRD.Size = New System.Drawing.Size(906, 369)
        Me.Ges_Pie_Clt_GRD.TabIndex = 3
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(3, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(865, 36)
        Me.Titre_lbl.TabIndex = 210
        Me.Titre_lbl.Text = "Ajouter une entité"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.Personnal_pnl.Controls.Add(Me.Titre_lbl, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 1, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(906, 36)
        Me.Personnal_pnl.TabIndex = 4
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(874, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(29, 30)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 35
        Me.Close_pb.TabStop = False
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.ListeAgentVues_cbo)
        Me.Pnl.Controls.Add(Me.Rd_Autre)
        Me.Pnl.Controls.Add(Me.Rd_Detail)
        Me.Pnl.Controls.Add(Me.Rd_Grade)
        Me.Pnl.Controls.Add(Me.Rd_Effect_Entite)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl.Location = New System.Drawing.Point(2, 38)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(906, 41)
        Me.Pnl.TabIndex = 4
        '
        'Zoom_Org_Organigramme_ListeAgent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(910, 450)
        Me.Controls.Add(Me.Ges_Pie_Clt_GRD)
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Org_Organigramme_ListeAgent"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liste des agents affectés à cette entité"
        CType(Me.Ges_Pie_Clt_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Rd_Detail As ud_RadioBox
    Friend WithEvents Rd_Grade As ud_RadioBox
    Friend WithEvents Rd_Effect_Entite As ud_RadioBox
    Friend WithEvents Rd_Autre As ud_RadioBox
    Friend WithEvents Ges_Pie_Clt_GRD As ud_Grd
    Friend WithEvents ListeAgentVues_cbo As ud_ComboBox
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Pnl As Panel
End Class
