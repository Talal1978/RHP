<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ecran_Container
    Inherits System.Windows.Forms.Form

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
        Me.pnl_sideBarL = New System.Windows.Forms.Panel()
        Me.pnl_Content = New System.Windows.Forms.Panel()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.LH = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Maximize_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Maximize_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_sideBarL
        '
        Me.pnl_sideBarL.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnl_sideBarL.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_sideBarL.Location = New System.Drawing.Point(847, 39)
        Me.pnl_sideBarL.Name = "pnl_sideBarL"
        Me.pnl_sideBarL.Size = New System.Drawing.Size(50, 508)
        Me.pnl_sideBarL.TabIndex = 2
        '
        'pnl_Content
        '
        Me.pnl_Content.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnl_Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Content.Location = New System.Drawing.Point(2, 39)
        Me.pnl_Content.Name = "pnl_Content"
        Me.pnl_Content.Size = New System.Drawing.Size(845, 508)
        Me.pnl_Content.TabIndex = 6
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(3, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(819, 31)
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LH
        '
        Me.LH.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.LH.Dock = System.Windows.Forms.DockStyle.Top
        Me.LH.Location = New System.Drawing.Point(2, 38)
        Me.LH.Name = "LH"
        Me.LH.Size = New System.Drawing.Size(895, 1)
        Me.LH.TabIndex = 0
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ent_pnl.ColumnCount = 3
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.ent_pnl.Controls.Add(Me.Titre_lbl, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Maximize_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 2, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(895, 36)
        Me.ent_pnl.TabIndex = 0
        '
        'Maximize_pb
        '
        Me.Maximize_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Maximize_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Maximize_pb.Image = Global.RHP.My.Resources.Resources.btn_maximize
        Me.Maximize_pb.Location = New System.Drawing.Point(828, 3)
        Me.Maximize_pb.Name = "Maximize_pb"
        Me.Maximize_pb.Size = New System.Drawing.Size(29, 30)
        Me.Maximize_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Maximize_pb.TabIndex = 34
        Me.Maximize_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(863, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(29, 30)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 34
        Me.Close_pb.TabStop = False
        '
        'Ecran_Container
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(899, 549)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnl_Content)
        Me.Controls.Add(Me.pnl_sideBarL)
        Me.Controls.Add(Me.LH)
        Me.Controls.Add(Me.ent_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Ecran_Container"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Maximize_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnl_sideBarL As Panel
    Friend WithEvents pnl_Content As Panel
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents LH As Label
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Maximize_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
End Class
