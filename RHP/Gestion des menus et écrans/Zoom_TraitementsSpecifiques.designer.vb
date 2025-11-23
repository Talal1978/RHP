<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_TraitementsSpecifiques
    Inherits System.Windows.Forms.Form

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Zoom_pnl = New System.Windows.Forms.Panel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Maximize_btn = New RHP.ud_button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Close_btn = New RHP.ud_button()
        Me.Zoom_Grd = New RHP.ud_Grd()
        Me.Zoom_pnl.SuspendLayout()
        CType(Me.Zoom_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Zoom_pnl
        '
        Me.Zoom_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Zoom_pnl.Controls.Add(Me.Zoom_lbl)
        Me.Zoom_pnl.Controls.Add(Me.Maximize_btn)
        Me.Zoom_pnl.Controls.Add(Me.Label1)
        Me.Zoom_pnl.Controls.Add(Me.Close_btn)
        Me.Zoom_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Zoom_pnl.Location = New System.Drawing.Point(1, 1)
        Me.Zoom_pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Zoom_pnl.Name = "Zoom_pnl"
        Me.Zoom_pnl.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        Me.Zoom_pnl.Size = New System.Drawing.Size(537, 31)
        Me.Zoom_pnl.TabIndex = 4
        '
        'Zoom_lbl
        '
        Me.Zoom_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Zoom_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Zoom_lbl.Font = New System.Drawing.Font("Century Gothic", 10.25!)
        Me.Zoom_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Zoom_lbl.Location = New System.Drawing.Point(0, 4)
        Me.Zoom_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Zoom_lbl.Name = "Zoom_lbl"
        Me.Zoom_lbl.Size = New System.Drawing.Size(463, 23)
        Me.Zoom_lbl.TabIndex = 2
        Me.Zoom_lbl.Text = "Traitements spécifiques"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Maximize_btn
        '
        Me.Maximize_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Maximize_btn.bgColor = System.Drawing.Color.White
        Me.Maximize_btn.Border = RHP.ud_button.BorderStyle.None
        Me.Maximize_btn.BorderColor = System.Drawing.Color.Empty
        Me.Maximize_btn.BorderSize = 0
        Me.Maximize_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Maximize_btn.Dock = System.Windows.Forms.DockStyle.Right
        Me.Maximize_btn.Image = Global.RHP.My.Resources.Resources.btn_maximize
        Me.Maximize_btn.isDefault = False
        Me.Maximize_btn.Location = New System.Drawing.Point(463, 4)
        Me.Maximize_btn.Margin = New System.Windows.Forms.Padding(4, 6, 0, 6)
        Me.Maximize_btn.MinimumSize = New System.Drawing.Size(34, 31)
        Me.Maximize_btn.Name = "Maximize_btn"
        Me.Maximize_btn.Size = New System.Drawing.Size(34, 31)
        Me.Maximize_btn.TabIndex = 0
        Me.Maximize_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Location = New System.Drawing.Point(497, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(6, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = " "
        '
        'Close_btn
        '
        Me.Close_btn.BackColor = System.Drawing.SystemColors.Control
        Me.Close_btn.bgColor = System.Drawing.Color.White
        Me.Close_btn.Border = RHP.ud_button.BorderStyle.None
        Me.Close_btn.BorderColor = System.Drawing.Color.Empty
        Me.Close_btn.BorderSize = 0
        Me.Close_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_btn.Dock = System.Windows.Forms.DockStyle.Right
        Me.Close_btn.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_btn.isDefault = False
        Me.Close_btn.Location = New System.Drawing.Point(503, 4)
        Me.Close_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Close_btn.MinimumSize = New System.Drawing.Size(34, 31)
        Me.Close_btn.Name = "Close_btn"
        Me.Close_btn.Size = New System.Drawing.Size(34, 31)
        Me.Close_btn.TabIndex = 0
        Me.Close_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Zoom_Grd
        '
        Me.Zoom_Grd.AfficherLesEntetesLignes = True
        Me.Zoom_Grd.AllowUserToAddRows = False
        Me.Zoom_Grd.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Zoom_Grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Zoom_Grd.AlternerLesLignes = False
        Me.Zoom_Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Zoom_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Zoom_Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Zoom_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Zoom_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Zoom_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Zoom_Grd.DefaultCellStyle = DataGridViewCellStyle3
        Me.Zoom_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Zoom_Grd.EnableHeadersVisualStyles = False
        Me.Zoom_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Zoom_Grd.Location = New System.Drawing.Point(1, 32)
        Me.Zoom_Grd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Zoom_Grd.MultiSelect = False
        Me.Zoom_Grd.Name = "Zoom_Grd"
        Me.Zoom_Grd.ReadOnly = True
        Me.Zoom_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Zoom_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Zoom_Grd.RowHeadersVisible = False
        Me.Zoom_Grd.RowHeadersWidth = 51
        Me.Zoom_Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Zoom_Grd.Size = New System.Drawing.Size(537, 222)
        Me.Zoom_Grd.TabIndex = 0
        '
        'Zoom_TraitementsSpecifiques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(539, 255)
        Me.Controls.Add(Me.Zoom_Grd)
        Me.Controls.Add(Me.Zoom_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Zoom_TraitementsSpecifiques"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traitements spécifiques"
        Me.Zoom_pnl.ResumeLayout(False)
        CType(Me.Zoom_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Zoom_pnl As Panel
    Friend WithEvents Close_btn As ud_button
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Maximize_btn As ud_button
    Friend WithEvents Label1 As Label
    Friend WithEvents Zoom_Grd As ud_Grd
End Class
