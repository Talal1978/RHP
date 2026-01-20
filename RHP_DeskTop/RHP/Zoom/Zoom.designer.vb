<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom
    Inherits Form

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
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Erase_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Maximize_pb = New System.Windows.Forms.PictureBox()
        Me.LH = New System.Windows.Forms.Label()
        Me.Zoom_Grd = New RHP.ud_Grd()
        Me.SelectAll_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Erase_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Maximize_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Zoom_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectAll_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ent_pnl.ColumnCount = 6
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.Controls.Add(Me.Save_pb, 2, 0)
        Me.ent_pnl.Controls.Add(Me.SelectAll_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Zoom_lbl, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 5, 0)
        Me.ent_pnl.Controls.Add(Me.Maximize_pb, 4, 0)
        Me.ent_pnl.Controls.Add(Me.Erase_pb, 3, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(1, 1)
        Me.ent_pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(537, 45)
        Me.ent_pnl.TabIndex = 6
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
        Me.Zoom_lbl.Size = New System.Drawing.Size(309, 39)
        Me.Zoom_lbl.TabIndex = 33
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Erase_pb
        '
        Me.Erase_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Erase_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Erase_pb.Image = Global.RHP.My.Resources.Resources.btn_erase
        Me.Erase_pb.Location = New System.Drawing.Point(409, 4)
        Me.Erase_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Erase_pb.Name = "Erase_pb"
        Me.Erase_pb.Size = New System.Drawing.Size(36, 37)
        Me.Erase_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Erase_pb.TabIndex = 34
        Me.Erase_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(497, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(36, 37)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 34
        Me.Close_pb.TabStop = False
        '
        'Maximize_pb
        '
        Me.Maximize_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Maximize_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Maximize_pb.Image = Global.RHP.My.Resources.Resources.btn_maximize
        Me.Maximize_pb.Location = New System.Drawing.Point(453, 4)
        Me.Maximize_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Maximize_pb.Name = "Maximize_pb"
        Me.Maximize_pb.Size = New System.Drawing.Size(36, 37)
        Me.Maximize_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Maximize_pb.TabIndex = 34
        Me.Maximize_pb.TabStop = False
        '
        'LH
        '
        Me.LH.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.LH.Dock = System.Windows.Forms.DockStyle.Top
        Me.LH.Location = New System.Drawing.Point(1, 46)
        Me.LH.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LH.Name = "LH"
        Me.LH.Size = New System.Drawing.Size(537, 1)
        Me.LH.TabIndex = 7
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
        Me.Zoom_Grd.Location = New System.Drawing.Point(1, 46)
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
        Me.Zoom_Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Zoom_Grd.Size = New System.Drawing.Size(537, 208)
        Me.Zoom_Grd.TabIndex = 0
        '
        'SelectAll_pb
        '
        Me.SelectAll_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectAll_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SelectAll_pb.Image = Global.RHP.My.Resources.Resources.btn_selectAll
        Me.SelectAll_pb.Location = New System.Drawing.Point(321, 4)
        Me.SelectAll_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.SelectAll_pb.Name = "SelectAll_pb"
        Me.SelectAll_pb.Size = New System.Drawing.Size(36, 37)
        Me.SelectAll_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SelectAll_pb.TabIndex = 35
        Me.SelectAll_pb.TabStop = False
        '
        'Save_pb
        '
        Me.Save_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(365, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(36, 37)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 36
        Me.Save_pb.TabStop = False
        '
        'Zoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(539, 255)
        Me.Controls.Add(Me.LH)
        Me.Controls.Add(Me.Zoom_Grd)
        Me.Controls.Add(Me.ent_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Zoom"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Zoom"
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Erase_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Maximize_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Zoom_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectAll_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Zoom_Grd As ud_Grd
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Maximize_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Erase_pb As PictureBox
    Friend WithEvents LH As Label
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents SelectAll_pb As PictureBox
End Class
