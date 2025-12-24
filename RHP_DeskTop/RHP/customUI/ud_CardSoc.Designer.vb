<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ud_CardSoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ud_CardSoc))
        Me.Den_lbl = New System.Windows.Forms.Label()
        Me.idSoc_lbl = New System.Windows.Forms.Label()
        Me.Border_pnl = New RHP.ud_Panel()
        Me.pb_Selected = New System.Windows.Forms.PictureBox()
        Me.soc_pb = New System.Windows.Forms.PictureBox()
        Me.Border_pnl.SuspendLayout()
        CType(Me.pb_Selected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.soc_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Den_lbl
        '
        Me.Den_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Den_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Den_lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Den_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Den_lbl.Location = New System.Drawing.Point(3, 58)
        Me.Den_lbl.Name = "Den_lbl"
        Me.Den_lbl.Size = New System.Drawing.Size(158, 39)
        Me.Den_lbl.TabIndex = 2
        Me.Den_lbl.Text = "Denomination"
        Me.Den_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'idSoc_lbl
        '
        Me.idSoc_lbl.BackColor = System.Drawing.Color.Transparent
        Me.idSoc_lbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idSoc_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.idSoc_lbl.Location = New System.Drawing.Point(61, 19)
        Me.idSoc_lbl.Name = "idSoc_lbl"
        Me.idSoc_lbl.Size = New System.Drawing.Size(37, 24)
        Me.idSoc_lbl.TabIndex = 3
        Me.idSoc_lbl.Text = "idSoc"
        Me.idSoc_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Border_pnl
        '
        Me.Border_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Border_pnl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.Border_pnl.BorderSize = 0
        Me.Border_pnl.Controls.Add(Me.pb_Selected)
        Me.Border_pnl.Controls.Add(Me.idSoc_lbl)
        Me.Border_pnl.Controls.Add(Me.soc_pb)
        Me.Border_pnl.Controls.Add(Me.Den_lbl)
        Me.Border_pnl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Border_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Border_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Border_pnl.Name = "Border_pnl"
        Me.Border_pnl.Size = New System.Drawing.Size(166, 100)
        Me.Border_pnl.TabIndex = 4
        '
        'pb_Selected
        '
        Me.pb_Selected.BackColor = System.Drawing.Color.Transparent
        Me.pb_Selected.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Selected.Image = Global.RHP.My.Resources.Resources.btn_soc_selected
        Me.pb_Selected.Location = New System.Drawing.Point(137, 4)
        Me.pb_Selected.Name = "pb_Selected"
        Me.pb_Selected.Size = New System.Drawing.Size(25, 25)
        Me.pb_Selected.TabIndex = 4
        Me.pb_Selected.TabStop = False
        '
        'soc_pb
        '
        Me.soc_pb.BackColor = System.Drawing.Color.Transparent
        Me.soc_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.soc_pb.Image = CType(resources.GetObject("soc_pb.Image"), System.Drawing.Image)
        Me.soc_pb.Location = New System.Drawing.Point(51, 5)
        Me.soc_pb.Name = "soc_pb"
        Me.soc_pb.Size = New System.Drawing.Size(56, 52)
        Me.soc_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.soc_pb.TabIndex = 0
        Me.soc_pb.TabStop = False
        '
        'ud_CardSoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Border_pnl)
        Me.Name = "ud_CardSoc"
        Me.Size = New System.Drawing.Size(166, 100)
        Me.Border_pnl.ResumeLayout(False)
        CType(Me.pb_Selected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.soc_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents soc_pb As PictureBox
    Friend WithEvents Den_lbl As Label
    Friend WithEvents idSoc_lbl As Label
    Friend WithEvents Border_pnl As ud_Panel
    Friend WithEvents pb_Selected As PictureBox
End Class
