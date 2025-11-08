<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Signataire_Tables
    inherits Ecran

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
        Me.Liaison_txt = New RHP.ud_TextBox()
        Me.Trv = New System.Windows.Forms.TreeView()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl.SuspendLayout()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Liaison_txt
        '
        Me.Liaison_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Liaison_txt.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Liaison_txt.Location = New System.Drawing.Point(0, 198)
        Me.Liaison_txt.MaxLength = 32767
        Me.Liaison_txt.Multiline = True
        Me.Liaison_txt.Name = "Liaison_txt"
        Me.Liaison_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Liaison_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Liaison_txt.ReadOnly = False
        Me.Liaison_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Liaison_txt.SelectionStart = 0
        Me.Liaison_txt.Size = New System.Drawing.Size(490, 73)
        Me.Liaison_txt.TabIndex = 214
        Me.Liaison_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Liaison_txt.UseSystemPasswordChar = False
        '
        'Trv
        '
        Me.Trv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Trv.Location = New System.Drawing.Point(0, 0)
        Me.Trv.Name = "Trv"
        Me.Trv.Size = New System.Drawing.Size(490, 198)
        Me.Trv.TabIndex = 216
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Trv)
        Me.Pnl.Controls.Add(Me.Liaison_txt)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 37)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(490, 271)
        Me.Pnl.TabIndex = 217
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.Label1, 0, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(490, 35)
        Me.Personnal_pnl.TabIndex = 219
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(463, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 29)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 8
        Me.Close_pb.TabStop = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(454, 35)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Conditions de laison des tables"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Zoom_Signataire_Tables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(494, 310)
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Signataire_Tables"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conditions de liaison des tables"
        Me.Pnl.ResumeLayout(False)
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Liaison_txt As ud_TextBox
    Friend WithEvents Trv As TreeView
    Friend WithEvents Pnl As Panel
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Label1 As Label
End Class
