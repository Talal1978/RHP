<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_SqlText
    Inherits Ecran

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
        Me.CTB_FAM_Art_Label = New System.Windows.Forms.Label()
        Me.ANA_FAM_Art_Label = New System.Windows.Forms.Label()
        Me.Sql_Text = New RHP.ud_TextBox()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CTB_FAM_Art_Label
        '
        Me.CTB_FAM_Art_Label.AutoSize = True
        Me.CTB_FAM_Art_Label.Location = New System.Drawing.Point(412, 170)
        Me.CTB_FAM_Art_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CTB_FAM_Art_Label.Name = "CTB_FAM_Art_Label"
        Me.CTB_FAM_Art_Label.Size = New System.Drawing.Size(0, 16)
        Me.CTB_FAM_Art_Label.TabIndex = 34
        '
        'ANA_FAM_Art_Label
        '
        Me.ANA_FAM_Art_Label.AutoSize = True
        Me.ANA_FAM_Art_Label.Location = New System.Drawing.Point(411, 208)
        Me.ANA_FAM_Art_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ANA_FAM_Art_Label.Name = "ANA_FAM_Art_Label"
        Me.ANA_FAM_Art_Label.Size = New System.Drawing.Size(0, 16)
        Me.ANA_FAM_Art_Label.TabIndex = 35
        '
        'Sql_Text
        '
        Me.Sql_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Sql_Text.ContextMenuStrip = Nothing
        Me.Sql_Text.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sql_Text.Location = New System.Drawing.Point(3, 46)
        Me.Sql_Text.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Sql_Text.MaxLength = 999999999
        Me.Sql_Text.Multiline = True
        Me.Sql_Text.Name = "Sql_Text"
        Me.Sql_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Sql_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Sql_Text.ReadOnly = True
        Me.Sql_Text.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Sql_Text.SelectionStart = 0
        Me.Sql_Text.Size = New System.Drawing.Size(746, 439)
        Me.Sql_Text.TabIndex = 211
        Me.Sql_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Sql_Text.UseSystemPasswordChar = False
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.Label1, 0, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(3, 2)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(746, 44)
        Me.Personnal_pnl.TabIndex = 212
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(710, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(32, 36)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 8
        Me.Close_pb.TabStop = False
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(698, 43)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Visualiser le texte de la requête"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Zoom_SqlText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(752, 487)
        Me.Controls.Add(Me.Sql_Text)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Controls.Add(Me.ANA_FAM_Art_Label)
        Me.Controls.Add(Me.CTB_FAM_Art_Label)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Zoom_SqlText"
        Me.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualiser le Texte Sql "
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CTB_FAM_Art_Label As System.Windows.Forms.Label
    Friend WithEvents ANA_FAM_Art_Label As System.Windows.Forms.Label
    Friend WithEvents Sql_Text As ud_TextBox
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Label1 As Label
End Class
