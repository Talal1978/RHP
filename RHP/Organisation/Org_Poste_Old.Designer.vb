<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Org_Poste_Old
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Poste_Grd = New RHP.ud_Grd()
        Me.Cod_Poste = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Poste = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Grade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Grade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Pnl_Jobdescription = New System.Windows.Forms.Panel()
        Me.Ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Menu_pb = New System.Windows.Forms.PictureBox()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Domaines_Competence_Pnl = New System.Windows.Forms.Panel()
        CType(Me.Poste_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Jobdescription.SuspendLayout()
        Me.Ent_pnl.SuspendLayout()
        CType(Me.Menu_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Poste_Grd
        '
        Me.Poste_Grd.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Poste_Grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Poste_Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Poste_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Poste_Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Poste_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Poste_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Poste_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Poste_Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Poste, Me.Lib_Poste, Me.Cod_Grade, Me.Lib_Grade})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Poste_Grd.DefaultCellStyle = DataGridViewCellStyle7
        Me.Poste_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Poste_Grd.EnableHeadersVisualStyles = False
        Me.Poste_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Poste_Grd.Location = New System.Drawing.Point(0, 0)
        Me.Poste_Grd.Name = "Poste_Grd"
        Me.Poste_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Poste_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Poste_Grd.Size = New System.Drawing.Size(1314, 458)
        Me.Poste_Grd.TabIndex = 3
        '
        'Cod_Poste
        '
        Me.Cod_Poste.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Cod_Poste.HeaderText = "Code"
        Me.Cod_Poste.MaxInputLength = 50
        Me.Cod_Poste.MinimumWidth = 150
        Me.Cod_Poste.Name = "Cod_Poste"
        Me.Cod_Poste.Width = 150
        '
        'Lib_Poste
        '
        Me.Lib_Poste.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Lib_Poste.HeaderText = "Intitulé du poste"
        Me.Lib_Poste.MaxInputLength = 150
        Me.Lib_Poste.MinimumWidth = 250
        Me.Lib_Poste.Name = "Lib_Poste"
        Me.Lib_Poste.Width = 250
        '
        'Cod_Grade
        '
        Me.Cod_Grade.HeaderText = "Code Grade"
        Me.Cod_Grade.Name = "Cod_Grade"
        Me.Cod_Grade.ReadOnly = True
        Me.Cod_Grade.Visible = False
        Me.Cod_Grade.Width = 112
        '
        'Lib_Grade
        '
        Me.Lib_Grade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Lib_Grade.HeaderText = "Grade"
        Me.Lib_Grade.MinimumWidth = 100
        Me.Lib_Grade.Name = "Lib_Grade"
        Me.Lib_Grade.ReadOnly = True
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(1311, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 458)
        Me.Splitter1.TabIndex = 4
        Me.Splitter1.TabStop = False
        '
        'Pnl_Jobdescription
        '
        Me.Pnl_Jobdescription.Controls.Add(Me.Ent_pnl)
        Me.Pnl_Jobdescription.Dock = System.Windows.Forms.DockStyle.Right
        Me.Pnl_Jobdescription.Location = New System.Drawing.Point(1314, 0)
        Me.Pnl_Jobdescription.Name = "Pnl_Jobdescription"
        Me.Pnl_Jobdescription.Size = New System.Drawing.Size(37, 600)
        Me.Pnl_Jobdescription.TabIndex = 5
        '
        'Ent_pnl
        '
        Me.Ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Ent_pnl.ColumnCount = 1
        Me.Ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Ent_pnl.Controls.Add(Me.Menu_pb, 0, 0)
        Me.Ent_pnl.Controls.Add(Me.Titre_lbl, 0, 1)
        Me.Ent_pnl.Dock = System.Windows.Forms.DockStyle.Right
        Me.Ent_pnl.Location = New System.Drawing.Point(1, 0)
        Me.Ent_pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.Ent_pnl.Name = "Ent_pnl"
        Me.Ent_pnl.RowCount = 1
        Me.Ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.Ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Ent_pnl.Size = New System.Drawing.Size(36, 600)
        Me.Ent_pnl.TabIndex = 0
        '
        'Menu_pb
        '
        Me.Menu_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Menu_pb.Image = Global.RHP.My.Resources.Resources.btn_menu
        Me.Menu_pb.Location = New System.Drawing.Point(3, 3)
        Me.Menu_pb.Name = "Menu_pb"
        Me.Menu_pb.Size = New System.Drawing.Size(30, 30)
        Me.Menu_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Menu_pb.TabIndex = 1
        Me.Menu_pb.TabStop = False
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(3, 36)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(30, 564)
        Me.Titre_lbl.TabIndex = 0
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Domaines_Competence_Pnl
        '
        Me.Domaines_Competence_Pnl.AutoScroll = True
        Me.Domaines_Competence_Pnl.BackColor = System.Drawing.Color.Transparent
        Me.Domaines_Competence_Pnl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Domaines_Competence_Pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Domaines_Competence_Pnl.Location = New System.Drawing.Point(0, 458)
        Me.Domaines_Competence_Pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.Domaines_Competence_Pnl.Name = "Domaines_Competence_Pnl"
        Me.Domaines_Competence_Pnl.Size = New System.Drawing.Size(1314, 142)
        Me.Domaines_Competence_Pnl.TabIndex = 6
        '
        'Org_Poste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1351, 600)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Poste_Grd)
        Me.Controls.Add(Me.Domaines_Competence_Pnl)
        Me.Controls.Add(Me.Pnl_Jobdescription)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "Org_Poste"
        Me.Tag = "ECR"
        Me.Text = "Détail des Postes"
        CType(Me.Poste_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Jobdescription.ResumeLayout(False)
        Me.Ent_pnl.ResumeLayout(False)
        CType(Me.Menu_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Poste_Grd As ud_Grd
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Cod_Poste As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Poste As DataGridViewTextBoxColumn
    Friend WithEvents Cod_Grade As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Grade As DataGridViewTextBoxColumn
    Friend WithEvents Pnl_Jobdescription As Panel
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Ent_pnl As TableLayoutPanel
    Friend WithEvents Menu_pb As PictureBox
    Friend WithEvents Domaines_Competence_Pnl As Panel
End Class
