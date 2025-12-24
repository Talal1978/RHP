<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RH_Cloture_Paie
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Rh_GRD = New RHP.ud_Grd()
        Me.BKG_Conge = New System.ComponentModel.BackgroundWorker()
        Me.Grp = New System.Windows.Forms.GroupBox()
        CType(Me.Rh_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp.SuspendLayout()
        Me.SuspendLayout()
        '
        'Rh_GRD
        '
        Me.Rh_GRD.AllowUserToAddRows = False
        Me.Rh_GRD.AllowUserToDeleteRows = False
        Me.Rh_GRD.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Rh_GRD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Rh_GRD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Rh_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Rh_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Rh_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Rh_GRD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Rh_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Rh_GRD.DefaultCellStyle = DataGridViewCellStyle3
        Me.Rh_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Rh_GRD.EnableHeadersVisualStyles = False
        Me.Rh_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Rh_GRD.Location = New System.Drawing.Point(3, 17)
        Me.Rh_GRD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rh_GRD.Name = "Rh_GRD"
        Me.Rh_GRD.ReadOnly = True
        Me.Rh_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Rh_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Rh_GRD.Size = New System.Drawing.Size(979, 570)
        Me.Rh_GRD.TabIndex = 3
        '
        'BKG_Conge
        '
        '
        'Grp
        '
        Me.Grp.Controls.Add(Me.Rh_GRD)
        Me.Grp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grp.Location = New System.Drawing.Point(0, 0)
        Me.Grp.Name = "Grp"
        Me.Grp.Size = New System.Drawing.Size(985, 590)
        Me.Grp.TabIndex = 4
        Me.Grp.TabStop = False
        Me.Grp.Text = "Clôture de la paie de l'annéee : "
        '
        'RH_Cloture_Paie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(985, 590)
        Me.Controls.Add(Me.Grp)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "RH_Cloture_Paie"
        Me.Tag = "ECR"
        Me.Text = "Clôture de la paie"
        CType(Me.Rh_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Rh_GRD As ud_Grd
    Friend WithEvents BKG_Conge As System.ComponentModel.BackgroundWorker
    Friend WithEvents Grp As GroupBox
End Class
