<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Stats_AT
    Inherits Ecran

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Annee_lbl = New System.Windows.Forms.Label()
        Me.Annee_txt = New RHP.ud_TextBox()
        Me.Refresh_Link = New System.Windows.Forms.LinkLabel()
        Me.Formules_txt = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox_Stats = New System.Windows.Forms.GroupBox()
        Me.Grd_Stats = New RHP.ud_Grd()
        Me.GroupBox_Heures = New System.Windows.Forms.GroupBox()
        Me.Grd_Heures = New RHP.ud_Grd()
        Me.Annee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mois = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Heures = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Source = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox_Stats.SuspendLayout()
        CType(Me.Grd_Stats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_Heures.SuspendLayout()
        CType(Me.Grd_Heures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Annee_lbl)
        Me.GroupBox2.Controls.Add(Me.Annee_txt)
        Me.GroupBox2.Controls.Add(Me.Refresh_Link)
        Me.GroupBox2.Controls.Add(Me.Formules_txt)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 110)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Période"
        '
        'Annee_lbl
        '
        Me.Annee_lbl.AutoSize = True
        Me.Annee_lbl.Location = New System.Drawing.Point(140, 45)
        Me.Annee_lbl.Name = "Annee_lbl"
        Me.Annee_lbl.Size = New System.Drawing.Size(49, 19)
        Me.Annee_lbl.TabIndex = 0
        Me.Annee_lbl.Text = "Année"
        '
        'Annee_txt
        '
        Me.Annee_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Annee_txt.ContextMenuStrip = Nothing
        Me.Annee_txt.Location = New System.Drawing.Point(200, 43)
        Me.Annee_txt.Name = "Annee_txt"
        Me.Annee_txt.Size = New System.Drawing.Size(80, 26)
        Me.Annee_txt.TabIndex = 1
        Me.Annee_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Refresh_Link
        '
        Me.Refresh_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Refresh_Link.AutoSize = True
        Me.Refresh_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Refresh_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Refresh_Link.Location = New System.Drawing.Point(300, 45)
        Me.Refresh_Link.Name = "Refresh_Link"
        Me.Refresh_Link.Size = New System.Drawing.Size(71, 19)
        Me.Refresh_Link.TabIndex = 2
        Me.Refresh_Link.TabStop = True
        Me.Refresh_Link.Tag = ""
        Me.Refresh_Link.Text = "Interroger"
        '
        'Formules_txt
        '
        Me.Formules_txt.AutoSize = True
        Me.Formules_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Formules_txt.Location = New System.Drawing.Point(20, 80)
        Me.Formules_txt.Name = "Formules_txt"
        Me.Formules_txt.Size = New System.Drawing.Size(180, 19)
        Me.Formules_txt.TabIndex = 3
        Me.Formules_txt.Text = "Formules des taux (paramétrées)"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 110)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox_Stats)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox_Heures)
        Me.SplitContainer1.Size = New System.Drawing.Size(1428, 604)
        Me.SplitContainer1.SplitterDistance = 350
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox_Stats
        '
        Me.GroupBox_Stats.Controls.Add(Me.Grd_Stats)
        Me.GroupBox_Stats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Stats.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Stats.Name = "GroupBox_Stats"
        Me.GroupBox_Stats.Size = New System.Drawing.Size(1428, 350)
        Me.GroupBox_Stats.TabIndex = 0
        Me.GroupBox_Stats.TabStop = False
        Me.GroupBox_Stats.Text = "Statistiques mensuelles des accidents du travail"
        '
        'Grd_Stats
        '
        Me.Grd_Stats.AfficherLesEntetesLignes = True
        Me.Grd_Stats.AlternerLesLignes = False
        Me.Grd_Stats.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Stats.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Stats.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Stats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Stats.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Stats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Stats.EnableHeadersVisualStyles = False
        Me.Grd_Stats.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Stats.Location = New System.Drawing.Point(3, 22)
        Me.Grd_Stats.Name = "Grd_Stats"
        Me.Grd_Stats.ReadOnly = True
        Me.Grd_Stats.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Stats.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Stats.RowHeadersWidth = 51
        Me.Grd_Stats.Size = New System.Drawing.Size(1422, 325)
        Me.Grd_Stats.TabIndex = 0
        '
        'GroupBox_Heures
        '
        Me.GroupBox_Heures.Controls.Add(Me.Grd_Heures)
        Me.GroupBox_Heures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Heures.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Heures.Name = "GroupBox_Heures"
        Me.GroupBox_Heures.Size = New System.Drawing.Size(1428, 250)
        Me.GroupBox_Heures.TabIndex = 0
        Me.GroupBox_Heures.TabStop = False
        Me.GroupBox_Heures.Text = "Heures travaillées (dénominateur des taux — auditable)"
        '
        'Grd_Heures
        '
        Me.Grd_Heures.AfficherLesEntetesLignes = True
        Me.Grd_Heures.AlternerLesLignes = False
        Me.Grd_Heures.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Heures.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd_Heures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Heures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Heures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Annee, Me.Mois, Me.Heures, Me.Source})
        Me.Grd_Heures.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Heures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Heures.EnableHeadersVisualStyles = False
        Me.Grd_Heures.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Heures.Location = New System.Drawing.Point(3, 22)
        Me.Grd_Heures.Name = "Grd_Heures"
        Me.Grd_Heures.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd_Heures.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Heures.RowHeadersWidth = 51
        Me.Grd_Heures.Size = New System.Drawing.Size(1422, 225)
        Me.Grd_Heures.TabIndex = 0
        '
        'Annee
        '
        Me.Annee.HeaderText = "Année"
        Me.Annee.MinimumWidth = 6
        Me.Annee.Name = "Annee"
        Me.Annee.Width = 120
        '
        'Mois
        '
        Me.Mois.HeaderText = "Mois"
        Me.Mois.MinimumWidth = 6
        Me.Mois.Name = "Mois"
        Me.Mois.Width = 120
        '
        'Heures
        '
        Me.Heures.HeaderText = "Heures travaillées"
        Me.Heures.MinimumWidth = 6
        Me.Heures.Name = "Heures"
        Me.Heures.Width = 200
        '
        'Source
        '
        Me.Source.HeaderText = "Source"
        Me.Source.MinimumWidth = 6
        Me.Source.Name = "Source"
        Me.Source.Width = 200
        '
        'RH_Sante_Stats_AT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Stats_AT"
        Me.Tag = "ECR"
        Me.Text = "Statistiques des accidents du travail"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox_Stats.ResumeLayout(False)
        CType(Me.Grd_Stats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_Heures.ResumeLayout(False)
        CType(Me.Grd_Heures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Annee_lbl As Label
    Friend WithEvents Annee_txt As ud_TextBox
    Friend WithEvents Refresh_Link As LinkLabel
    Friend WithEvents Formules_txt As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox_Stats As GroupBox
    Friend WithEvents Grd_Stats As ud_Grd
    Friend WithEvents GroupBox_Heures As GroupBox
    Friend WithEvents Grd_Heures As ud_Grd
    Friend WithEvents Annee As DataGridViewTextBoxColumn
    Friend WithEvents Mois As DataGridViewTextBoxColumn
    Friend WithEvents Heures As DataGridViewTextBoxColumn
    Friend WithEvents Source As DataGridViewTextBoxColumn
End Class
