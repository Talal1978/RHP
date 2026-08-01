<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Tableau_Bord
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
        Me.Refresh_Link = New System.Windows.Forms.LinkLabel()
        Me.Seuil_txt = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox_Apt = New System.Windows.Forms.GroupBox()
        Me.Grd_Aptitudes = New RHP.ud_Grd()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox_Ech = New System.Windows.Forms.GroupBox()
        Me.Grd_Echeances = New RHP.ud_Grd()
        Me.GroupBox_Ret = New System.Windows.Forms.GroupBox()
        Me.Grd_Retards = New RHP.ud_Grd()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox_Apt.SuspendLayout()
        CType(Me.Grd_Aptitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox_Ech.SuspendLayout()
        CType(Me.Grd_Echeances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_Ret.SuspendLayout()
        CType(Me.Grd_Retards, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Refresh_Link)
        Me.GroupBox2.Controls.Add(Me.Seuil_txt)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1428, 70)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tableau de bord santé au travail"
        '
        'Refresh_Link
        '
        Me.Refresh_Link.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Refresh_Link.AutoSize = True
        Me.Refresh_Link.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Refresh_Link.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Refresh_Link.Location = New System.Drawing.Point(30, 30)
        Me.Refresh_Link.Name = "Refresh_Link"
        Me.Refresh_Link.Size = New System.Drawing.Size(71, 19)
        Me.Refresh_Link.TabIndex = 2
        Me.Refresh_Link.TabStop = True
        Me.Refresh_Link.Tag = ""
        Me.Refresh_Link.Text = "Interroger"
        '
        'Seuil_txt
        '
        Me.Seuil_txt.AutoSize = True
        Me.Seuil_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Seuil_txt.Location = New System.Drawing.Point(140, 30)
        Me.Seuil_txt.Name = "Seuil_txt"
        Me.Seuil_txt.Size = New System.Drawing.Size(70, 19)
        Me.Seuil_txt.TabIndex = 3
        Me.Seuil_txt.Text = "Seuil : 5"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 70)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox_Apt)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1428, 644)
        Me.SplitContainer1.SplitterDistance = 470
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox_Apt
        '
        Me.GroupBox_Apt.Controls.Add(Me.Grd_Aptitudes)
        Me.GroupBox_Apt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Apt.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Apt.Name = "GroupBox_Apt"
        Me.GroupBox_Apt.Size = New System.Drawing.Size(470, 644)
        Me.GroupBox_Apt.TabIndex = 0
        Me.GroupBox_Apt.TabStop = False
        Me.GroupBox_Apt.Text = "Effectif par statut d'aptitude (agrégats)"
        '
        'Grd_Aptitudes
        '
        Me.Grd_Aptitudes.AfficherLesEntetesLignes = True
        Me.Grd_Aptitudes.AlternerLesLignes = False
        Me.Grd_Aptitudes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Aptitudes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Aptitudes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Aptitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Aptitudes.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Aptitudes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Aptitudes.EnableHeadersVisualStyles = False
        Me.Grd_Aptitudes.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Aptitudes.Location = New System.Drawing.Point(3, 22)
        Me.Grd_Aptitudes.Name = "Grd_Aptitudes"
        Me.Grd_Aptitudes.ReadOnly = True
        Me.Grd_Aptitudes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Aptitudes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Aptitudes.RowHeadersWidth = 51
        Me.Grd_Aptitudes.Size = New System.Drawing.Size(464, 619)
        Me.Grd_Aptitudes.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox_Ech)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox_Ret)
        Me.SplitContainer2.Size = New System.Drawing.Size(954, 644)
        Me.SplitContainer2.SplitterDistance = 320
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox_Ech
        '
        Me.GroupBox_Ech.Controls.Add(Me.Grd_Echeances)
        Me.GroupBox_Ech.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Ech.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Ech.Name = "GroupBox_Ech"
        Me.GroupBox_Ech.Size = New System.Drawing.Size(954, 320)
        Me.GroupBox_Ech.TabIndex = 0
        Me.GroupBox_Ech.TabStop = False
        Me.GroupBox_Ech.Text = "Visites échues, proches ou manquantes"
        '
        'Grd_Echeances
        '
        Me.Grd_Echeances.AfficherLesEntetesLignes = True
        Me.Grd_Echeances.AlternerLesLignes = False
        Me.Grd_Echeances.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Echeances.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd_Echeances.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Echeances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Echeances.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Echeances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Echeances.EnableHeadersVisualStyles = False
        Me.Grd_Echeances.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Echeances.Location = New System.Drawing.Point(3, 22)
        Me.Grd_Echeances.Name = "Grd_Echeances"
        Me.Grd_Echeances.ReadOnly = True
        Me.Grd_Echeances.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd_Echeances.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Echeances.RowHeadersWidth = 51
        Me.Grd_Echeances.Size = New System.Drawing.Size(948, 295)
        Me.Grd_Echeances.TabIndex = 0
        '
        'GroupBox_Ret
        '
        Me.GroupBox_Ret.Controls.Add(Me.Grd_Retards)
        Me.GroupBox_Ret.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Ret.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Ret.Name = "GroupBox_Ret"
        Me.GroupBox_Ret.Size = New System.Drawing.Size(954, 320)
        Me.GroupBox_Ret.TabIndex = 0
        Me.GroupBox_Ret.TabStop = False
        Me.GroupBox_Ret.Text = "Alertes et tâches en retard (AT, convocations, rappels)"
        '
        'Grd_Retards
        '
        Me.Grd_Retards.AfficherLesEntetesLignes = True
        Me.Grd_Retards.AlternerLesLignes = False
        Me.Grd_Retards.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Retards.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd_Retards.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Retards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Retards.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Retards.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Retards.EnableHeadersVisualStyles = False
        Me.Grd_Retards.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Retards.Location = New System.Drawing.Point(3, 22)
        Me.Grd_Retards.Name = "Grd_Retards"
        Me.Grd_Retards.ReadOnly = True
        Me.Grd_Retards.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd_Retards.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Retards.RowHeadersWidth = 51
        Me.Grd_Retards.Size = New System.Drawing.Size(948, 295)
        Me.Grd_Retards.TabIndex = 0
        '
        'RH_Sante_Tableau_Bord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Tableau_Bord"
        Me.Tag = "ECR"
        Me.Text = "Tableau de bord santé au travail"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox_Apt.ResumeLayout(False)
        CType(Me.Grd_Aptitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox_Ech.ResumeLayout(False)
        CType(Me.Grd_Echeances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_Ret.ResumeLayout(False)
        CType(Me.Grd_Retards, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Refresh_Link As LinkLabel
    Friend WithEvents Seuil_txt As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox_Apt As GroupBox
    Friend WithEvents Grd_Aptitudes As ud_Grd
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents GroupBox_Ech As GroupBox
    Friend WithEvents Grd_Echeances As ud_Grd
    Friend WithEvents GroupBox_Ret As GroupBox
    Friend WithEvents Grd_Retards As ud_Grd
End Class
