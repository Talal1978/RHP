<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AI_KnowledgeBase
    Inherits Ecran

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Ud_Panel1 = New RHP.ud_Panel()
        Me.Grd_Docs = New RHP.ud_Grd()
        Me.Col_File = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Chunk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel_Actions = New System.Windows.Forms.Panel()
        Me.Tester_EmbeddingConn_btn = New RHP.ud_button()
        Me.Lbl_Status = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Ud_Panel1.SuspendLayout()
        CType(Me.Grd_Docs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Actions.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ud_Panel1
        '
        Me.Ud_Panel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Ud_Panel1.BorderSize = 2
        Me.Ud_Panel1.Controls.Add(Me.Grd_Docs)
        Me.Ud_Panel1.Controls.Add(Me.Panel_Actions)
        Me.Ud_Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ud_Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Ud_Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Ud_Panel1.Name = "Ud_Panel1"
        Me.Ud_Panel1.Size = New System.Drawing.Size(1191, 554)
        Me.Ud_Panel1.TabIndex = 0
        '
        'Grd_Docs
        '
        Me.Grd_Docs.AfficherLesEntetesLignes = True
        Me.Grd_Docs.AllowUserToAddRows = False
        Me.Grd_Docs.AlternerLesLignes = False
        Me.Grd_Docs.BackgroundColor = System.Drawing.Color.White
        Me.Grd_Docs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Docs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Docs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Docs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Docs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_File, Me.Col_Status, Me.Col_Chunk})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Docs.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Docs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Docs.EnableHeadersVisualStyles = False
        Me.Grd_Docs.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Grd_Docs.Location = New System.Drawing.Point(0, 115)
        Me.Grd_Docs.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Docs.Name = "Grd_Docs"
        Me.Grd_Docs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Docs.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Docs.RowHeadersWidth = 51
        Me.Grd_Docs.Size = New System.Drawing.Size(1191, 439)
        Me.Grd_Docs.TabIndex = 1
        Me.Grd_Docs.Tag = "ECR"
        '
        'Col_File
        '
        Me.Col_File.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Col_File.HeaderText = "Dossier / Fichier"
        Me.Col_File.MinimumWidth = 6
        Me.Col_File.Name = "Col_File"
        '
        'Col_Status
        '
        Me.Col_Status.HeaderText = "Statut"
        Me.Col_Status.MinimumWidth = 6
        Me.Col_Status.Name = "Col_Status"
        Me.Col_Status.Width = 125
        '
        'Col_Chunk
        '
        Me.Col_Chunk.HeaderText = "Segments"
        Me.Col_Chunk.MinimumWidth = 6
        Me.Col_Chunk.Name = "Col_Chunk"
        Me.Col_Chunk.Width = 125
        '
        'Panel_Actions
        '
        Me.Panel_Actions.Controls.Add(Me.Tester_EmbeddingConn_btn)
        Me.Panel_Actions.Controls.Add(Me.Lbl_Status)
        Me.Panel_Actions.Controls.Add(Me.ProgressBar1)
        Me.Panel_Actions.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Actions.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Actions.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel_Actions.Name = "Panel_Actions"
        Me.Panel_Actions.Size = New System.Drawing.Size(1191, 115)
        Me.Panel_Actions.TabIndex = 2
        '
        'Tester_EmbeddingConn_btn
        '
        Me.Tester_EmbeddingConn_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Tester_EmbeddingConn_btn.bgColor = System.Drawing.Color.White
        Me.Tester_EmbeddingConn_btn.Border = RHP.ud_button.BorderStyle.All
        Me.Tester_EmbeddingConn_btn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Tester_EmbeddingConn_btn.BorderSize = 2
        Me.Tester_EmbeddingConn_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tester_EmbeddingConn_btn.Image = Global.RHP.My.Resources.Resources.btn_testCon
        Me.Tester_EmbeddingConn_btn.isDefault = False
        Me.Tester_EmbeddingConn_btn.Location = New System.Drawing.Point(16, 10)
        Me.Tester_EmbeddingConn_btn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tester_EmbeddingConn_btn.MinimumSize = New System.Drawing.Size(27, 25)
        Me.Tester_EmbeddingConn_btn.Name = "Tester_EmbeddingConn_btn"
        Me.Tester_EmbeddingConn_btn.Padding = New System.Windows.Forms.Padding(2)
        Me.Tester_EmbeddingConn_btn.Size = New System.Drawing.Size(180, 32)
        Me.Tester_EmbeddingConn_btn.TabIndex = 4
        Me.Tester_EmbeddingConn_btn.Text = "Tester l'embedding"
        '
        'Lbl_Status
        '
        Me.Lbl_Status.AutoSize = True
        Me.Lbl_Status.Location = New System.Drawing.Point(19, 65)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(16, 16)
        Me.Lbl_Status.TabIndex = 3
        Me.Lbl_Status.Text = "   "
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 85)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1037, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'AI_KnowledgeBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 554)
        Me.Controls.Add(Me.Ud_Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AI_KnowledgeBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Gestion de la Base de Connaissance IA"
        Me.Ud_Panel1.ResumeLayout(False)
        CType(Me.Grd_Docs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Actions.ResumeLayout(False)
        Me.Panel_Actions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Ud_Panel1 As RHP.ud_Panel
    Friend WithEvents Grd_Docs As RHP.ud_Grd
    Friend WithEvents Col_File As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Chunk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel_Actions As System.Windows.Forms.Panel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Lbl_Status As Label
    Friend WithEvents Tester_EmbeddingConn_btn As ud_button
End Class
