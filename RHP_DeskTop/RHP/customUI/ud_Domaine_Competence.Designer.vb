<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ud_Domaine_Competence
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.layout_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Competence_lbl = New System.Windows.Forms.Label()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.rating_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.pbStar_01 = New System.Windows.Forms.PictureBox()
        Me.pbStar_02 = New System.Windows.Forms.PictureBox()
        Me.pbStar_03 = New System.Windows.Forms.PictureBox()
        Me.pbStar_05 = New System.Windows.Forms.PictureBox()
        Me.pbStar_04 = New System.Windows.Forms.PictureBox()
        Me.rating_lbl = New System.Windows.Forms.Label()
        Me.layout_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rating_pnl.SuspendLayout()
        CType(Me.pbStar_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStar_02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStar_03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStar_05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStar_04, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layout_pnl
        '
        Me.layout_pnl.AutoSize = True
        Me.layout_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.layout_pnl.ColumnCount = 2
        Me.layout_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layout_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.layout_pnl.Controls.Add(Me.Competence_lbl, 0, 0)
        Me.layout_pnl.Controls.Add(Me.Close_pb, 1, 0)
        Me.layout_pnl.Controls.Add(Me.rating_pnl, 0, 1)
        Me.layout_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layout_pnl.Location = New System.Drawing.Point(1, 1)
        Me.layout_pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.layout_pnl.Name = "layout_pnl"
        Me.layout_pnl.RowCount = 2
        Me.layout_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layout_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.layout_pnl.Size = New System.Drawing.Size(268, 38)
        Me.layout_pnl.TabIndex = 0
        '
        'Competence_lbl
        '
        Me.Competence_lbl.AutoSize = True
        Me.Competence_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Competence_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Competence_lbl.Location = New System.Drawing.Point(1, 1)
        Me.Competence_lbl.Margin = New System.Windows.Forms.Padding(1)
        Me.Competence_lbl.Name = "Competence_lbl"
        Me.Competence_lbl.Size = New System.Drawing.Size(236, 19)
        Me.Competence_lbl.TabIndex = 2
        Me.Competence_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Dock = System.Windows.Forms.DockStyle.Top
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(241, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 15)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 0
        Me.Close_pb.TabStop = False
        '
        'rating_pnl
        '
        Me.rating_pnl.ColumnCount = 6
        Me.layout_pnl.SetColumnSpan(Me.rating_pnl, 2)
        Me.rating_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rating_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.rating_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.rating_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.rating_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.rating_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.rating_pnl.Controls.Add(Me.pbStar_01, 1, 0)
        Me.rating_pnl.Controls.Add(Me.pbStar_02, 2, 0)
        Me.rating_pnl.Controls.Add(Me.pbStar_03, 3, 0)
        Me.rating_pnl.Controls.Add(Me.pbStar_05, 5, 0)
        Me.rating_pnl.Controls.Add(Me.pbStar_04, 4, 0)
        Me.rating_pnl.Controls.Add(Me.rating_lbl, 0, 0)
        Me.rating_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rating_pnl.Location = New System.Drawing.Point(0, 21)
        Me.rating_pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.rating_pnl.Name = "rating_pnl"
        Me.rating_pnl.RowCount = 1
        Me.rating_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rating_pnl.Size = New System.Drawing.Size(268, 17)
        Me.rating_pnl.TabIndex = 4
        '
        'pbStar_01
        '
        Me.pbStar_01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbStar_01.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbStar_01.Image = Global.RHP.My.Resources.Resources.star_0
        Me.pbStar_01.Location = New System.Drawing.Point(193, 3)
        Me.pbStar_01.Margin = New System.Windows.Forms.Padding(0)
        Me.pbStar_01.Name = "pbStar_01"
        Me.pbStar_01.Size = New System.Drawing.Size(15, 14)
        Me.pbStar_01.TabIndex = 3
        Me.pbStar_01.TabStop = False
        '
        'pbStar_02
        '
        Me.pbStar_02.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbStar_02.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbStar_02.Image = Global.RHP.My.Resources.Resources.star_0
        Me.pbStar_02.Location = New System.Drawing.Point(208, 3)
        Me.pbStar_02.Margin = New System.Windows.Forms.Padding(0)
        Me.pbStar_02.Name = "pbStar_02"
        Me.pbStar_02.Size = New System.Drawing.Size(15, 14)
        Me.pbStar_02.TabIndex = 3
        Me.pbStar_02.TabStop = False
        '
        'pbStar_03
        '
        Me.pbStar_03.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbStar_03.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbStar_03.Image = Global.RHP.My.Resources.Resources.star_0
        Me.pbStar_03.Location = New System.Drawing.Point(223, 3)
        Me.pbStar_03.Margin = New System.Windows.Forms.Padding(0)
        Me.pbStar_03.Name = "pbStar_03"
        Me.pbStar_03.Size = New System.Drawing.Size(15, 14)
        Me.pbStar_03.TabIndex = 3
        Me.pbStar_03.TabStop = False
        '
        'pbStar_05
        '
        Me.pbStar_05.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbStar_05.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbStar_05.Image = Global.RHP.My.Resources.Resources.star_0
        Me.pbStar_05.Location = New System.Drawing.Point(253, 3)
        Me.pbStar_05.Margin = New System.Windows.Forms.Padding(0)
        Me.pbStar_05.Name = "pbStar_05"
        Me.pbStar_05.Size = New System.Drawing.Size(15, 14)
        Me.pbStar_05.TabIndex = 3
        Me.pbStar_05.TabStop = False
        '
        'pbStar_04
        '
        Me.pbStar_04.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbStar_04.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbStar_04.Image = Global.RHP.My.Resources.Resources.star_0
        Me.pbStar_04.Location = New System.Drawing.Point(238, 3)
        Me.pbStar_04.Margin = New System.Windows.Forms.Padding(0)
        Me.pbStar_04.Name = "pbStar_04"
        Me.pbStar_04.Size = New System.Drawing.Size(15, 14)
        Me.pbStar_04.TabIndex = 3
        Me.pbStar_04.TabStop = False
        '
        'rating_lbl
        '
        Me.rating_lbl.AutoSize = True
        Me.rating_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rating_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rating_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.rating_lbl.Location = New System.Drawing.Point(0, 0)
        Me.rating_lbl.Margin = New System.Windows.Forms.Padding(0)
        Me.rating_lbl.Name = "rating_lbl"
        Me.rating_lbl.Size = New System.Drawing.Size(193, 17)
        Me.rating_lbl.TabIndex = 4
        Me.rating_lbl.Text = "0.5"
        Me.rating_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ud_Domaine_Competence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Controls.Add(Me.layout_pnl)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimumSize = New System.Drawing.Size(95, 0)
        Me.Name = "ud_Domaine_Competence"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.Size = New System.Drawing.Size(270, 40)
        Me.layout_pnl.ResumeLayout(False)
        Me.layout_pnl.PerformLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rating_pnl.ResumeLayout(False)
        Me.rating_pnl.PerformLayout()
        CType(Me.pbStar_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStar_02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStar_03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStar_05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStar_04, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents layout_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Competence_lbl As Label
    Friend WithEvents pbStar_04 As PictureBox
    Friend WithEvents rating_pnl As TableLayoutPanel
    Friend WithEvents pbStar_01 As PictureBox
    Friend WithEvents pbStar_02 As PictureBox
    Friend WithEvents pbStar_03 As PictureBox
    Friend WithEvents pbStar_05 As PictureBox
    Friend WithEvents rating_lbl As Label
End Class
