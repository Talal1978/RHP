<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Agent_Parapheur
    Inherits Ecran

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
        Me.Grd_Parapheur = New RHP.ud_Grd()
        Me.ParapheurCntx = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualiserLeParapheurToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExporterLeContenuVersExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Grd_Parapheur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ParapheurCntx.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grd_Parapheur
        '
        Me.Grd_Parapheur.AllowUserToAddRows = False
        Me.Grd_Parapheur.AllowUserToOrderColumns = True
        Me.Grd_Parapheur.AlternatingRowsDefaultCellStyle = Nothing
        Me.Grd_Parapheur.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Parapheur.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Parapheur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd_Parapheur.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Parapheur.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Parapheur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Parapheur.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Parapheur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Parapheur.EnableHeadersVisualStyles = False
        Me.Grd_Parapheur.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Parapheur.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Parapheur.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grd_Parapheur.MultiSelect = False
        Me.Grd_Parapheur.Name = "Grd_Parapheur"
        Me.Grd_Parapheur.ReadOnly = True
        Me.Grd_Parapheur.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Parapheur.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Parapheur.Size = New System.Drawing.Size(800, 450)
        Me.Grd_Parapheur.TabIndex = 5
        '
        'ParapheurCntx
        '
        Me.ParapheurCntx.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualiserLeParapheurToolStripMenuItem, Me.ExporterLeContenuVersExcelToolStripMenuItem})
        Me.ParapheurCntx.Name = "ContextMenuStrip2"
        Me.ParapheurCntx.Size = New System.Drawing.Size(232, 48)
        '
        'ActualiserLeParapheurToolStripMenuItem
        '
        Me.ActualiserLeParapheurToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.btn_refresh
        Me.ActualiserLeParapheurToolStripMenuItem.Name = "ActualiserLeParapheurToolStripMenuItem"
        Me.ActualiserLeParapheurToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ActualiserLeParapheurToolStripMenuItem.Text = "Actualiser le parapheur"
        '
        'ExporterLeContenuVersExcelToolStripMenuItem
        '
        Me.ExporterLeContenuVersExcelToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.icone_excel
        Me.ExporterLeContenuVersExcelToolStripMenuItem.Name = "ExporterLeContenuVersExcelToolStripMenuItem"
        Me.ExporterLeContenuVersExcelToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ExporterLeContenuVersExcelToolStripMenuItem.Text = "Exporter le contenu vers Excel"
        '
        'Agent_Parapheur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Grd_Parapheur)
        Me.Name = "Agent_Parapheur"
        Me.Text = "Agent_Parapheur"
        CType(Me.Grd_Parapheur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ParapheurCntx.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grd_Parapheur As ud_Grd
    Friend WithEvents ParapheurCntx As ContextMenuStrip
    Friend WithEvents ActualiserLeParapheurToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExporterLeContenuVersExcelToolStripMenuItem As ToolStripMenuItem
End Class
