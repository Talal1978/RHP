<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_CV_Competences
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grd = New RHP.ud_Grd()
        Me.colCompetenceCV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEquivalents = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodesEquivalents = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCreer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDomaine = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.info_lbl = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grd
        '
        Me.Grd.AfficherLesEntetesLignes = True
        Me.Grd.AllowUserToAddRows = False
        Me.Grd.AllowUserToDeleteRows = False
        Me.Grd.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd.AlternerLesLignes = False
        Me.Grd.AutoGenerateColumns = False
        Me.Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCompetenceCV, Me.colEquivalents, Me.colCodesEquivalents, Me.colCreer, Me.colDomaine})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.EnableHeadersVisualStyles = False
        Me.Grd.GridColor = System.Drawing.Color.White
        Me.Grd.Location = New System.Drawing.Point(2, 62)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd.RowHeadersVisible = False
        Me.Grd.RowHeadersWidth = 51
        Me.Grd.Size = New System.Drawing.Size(1146, 456)
        Me.Grd.TabIndex = 2
        '
        'colCompetenceCV
        '
        Me.colCompetenceCV.DataPropertyName = "CompetenceCV"
        Me.colCompetenceCV.FillWeight = 25.0!
        Me.colCompetenceCV.HeaderText = "Compétence détectée dans le CV"
        Me.colCompetenceCV.Name = "colCompetenceCV"
        Me.colCompetenceCV.ReadOnly = True
        Me.colCompetenceCV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colEquivalents
        '
        Me.colEquivalents.DataPropertyName = "Equivalents"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.colEquivalents.DefaultCellStyle = DataGridViewCellStyle5
        Me.colEquivalents.FillWeight = 35.0!
        Me.colEquivalents.HeaderText = "Équivalents GPEC (cliquer pour sélectionner)"
        Me.colEquivalents.Name = "colEquivalents"
        Me.colEquivalents.ReadOnly = True
        Me.colEquivalents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colEquivalents.ToolTipText = "Cliquer pour choisir une ou plusieurs compétences équivalentes du référentiel GPEC"
        '
        'colCodesEquivalents
        '
        Me.colCodesEquivalents.DataPropertyName = "CodesEquivalents"
        Me.colCodesEquivalents.HeaderText = "CodesEquivalents"
        Me.colCodesEquivalents.Name = "colCodesEquivalents"
        Me.colCodesEquivalents.Visible = False
        '
        'colCreer
        '
        Me.colCreer.DataPropertyName = "Creer"
        Me.colCreer.FillWeight = 10.0!
        Me.colCreer.HeaderText = "Créer dans la GPEC"
        Me.colCreer.Name = "colCreer"
        '
        'colDomaine
        '
        Me.colDomaine.DataPropertyName = "DomaineParent"
        Me.colDomaine.FillWeight = 30.0!
        Me.colDomaine.HeaderText = "Domaine parent (si création)"
        Me.colDomaine.Name = "colDomaine"
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ent_pnl.ColumnCount = 4
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.ent_pnl.Controls.Add(Me.Zoom_lbl, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 3, 0)
        Me.ent_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(1146, 32)
        Me.ent_pnl.TabIndex = 0
        '
        'Zoom_lbl
        '
        Me.Zoom_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Zoom_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Zoom_lbl.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Zoom_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Zoom_lbl.Location = New System.Drawing.Point(33, 0)
        Me.Zoom_lbl.Name = "Zoom_lbl"
        Me.Zoom_lbl.Size = New System.Drawing.Size(1080, 32)
        Me.Zoom_lbl.TabIndex = 0
        Me.Zoom_lbl.Text = "Compétences du CV absentes du référentiel GPEC"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(1146, 0)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(30, 32)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 1
        Me.Close_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Close_pb, "Fermer sans appliquer")
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(0, 0)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(30, 32)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 0
        Me.Save_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Save_pb, "Valider les correspondances")
        '
        'info_lbl
        '
        Me.info_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.info_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.info_lbl.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.info_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.info_lbl.Location = New System.Drawing.Point(2, 34)
        Me.info_lbl.Name = "info_lbl"
        Me.info_lbl.Size = New System.Drawing.Size(1146, 28)
        Me.info_lbl.TabIndex = 1
        Me.info_lbl.Text = "Pour chaque compétence : cliquez sur la colonne « Équivalents GPEC » pour l'associer à une ou plusieurs compétences du référentiel, ou cochez « Créer » et choisissez le domaine auquel l'ajouter."
        Me.info_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Zoom_CV_Competences
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1150, 520)
        Me.Controls.Add(Me.Grd)
        Me.Controls.Add(Me.info_lbl)
        Me.Controls.Add(Me.ent_pnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Zoom_CV_Competences"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Correspondance des compétences avec la GPEC"
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grd As ud_Grd
    Friend WithEvents colCompetenceCV As DataGridViewTextBoxColumn
    Friend WithEvents colEquivalents As DataGridViewTextBoxColumn
    Friend WithEvents colCodesEquivalents As DataGridViewTextBoxColumn
    Friend WithEvents colCreer As DataGridViewCheckBoxColumn
    Friend WithEvents colDomaine As DataGridViewComboBoxColumn
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents info_lbl As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
