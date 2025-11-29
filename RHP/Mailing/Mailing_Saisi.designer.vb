<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mailing_Saisi
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Parametres_Grd = New RHP.ud_Grd()
        Me.Parametre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Parametre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.entpnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.sendMail_pb = New System.Windows.Forms.PictureBox()
        Me.Lib_Mailing_txt = New RHP.ud_TextBox()
        Me.Cod_Mailing_txt = New RHP.ud_TextBox()
        Me.results_grp = New System.Windows.Forms.GroupBox()
        Me.Results_txt = New System.Windows.Forms.TextBox()
        CType(Me.Parametres_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.entpnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sendMail_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.results_grp.SuspendLayout()
        Me.SuspendLayout()
        '
        'Parametres_Grd
        '
        Me.Parametres_Grd.AfficherLesEntetesLignes = True
        Me.Parametres_Grd.AllowUserToAddRows = False
        Me.Parametres_Grd.AlternerLesLignes = False
        Me.Parametres_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Parametres_Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Parametres_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Parametres_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Parametres_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Parametres_Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Parametre, Me.Lib_Parametre, Me.Valeur, Me.Type})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Parametres_Grd.DefaultCellStyle = DataGridViewCellStyle5
        Me.Parametres_Grd.Dock = System.Windows.Forms.DockStyle.Top
        Me.Parametres_Grd.EnableHeadersVisualStyles = False
        Me.Parametres_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Parametres_Grd.Location = New System.Drawing.Point(2, 40)
        Me.Parametres_Grd.Margin = New System.Windows.Forms.Padding(4)
        Me.Parametres_Grd.Name = "Parametres_Grd"
        Me.Parametres_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Parametres_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Parametres_Grd.RowHeadersVisible = False
        Me.Parametres_Grd.RowHeadersWidth = 51
        Me.Parametres_Grd.Size = New System.Drawing.Size(847, 218)
        Me.Parametres_Grd.TabIndex = 81
        '
        'Parametre
        '
        Me.Parametre.HeaderText = "Code paramètre"
        Me.Parametre.MinimumWidth = 200
        Me.Parametre.Name = "Parametre"
        Me.Parametre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Parametre.Visible = False
        Me.Parametre.Width = 200
        '
        'Lib_Parametre
        '
        Me.Lib_Parametre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Lib_Parametre.HeaderText = "Paramètre"
        Me.Lib_Parametre.MinimumWidth = 6
        Me.Lib_Parametre.Name = "Lib_Parametre"
        Me.Lib_Parametre.ReadOnly = True
        Me.Lib_Parametre.Width = 119
        '
        'Valeur
        '
        Me.Valeur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.MinimumWidth = 400
        Me.Valeur.Name = "Valeur"
        Me.Valeur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Valeur.Width = 400
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.MinimumWidth = 6
        Me.Type.Name = "Type"
        Me.Type.Visible = False
        Me.Type.Width = 125
        '
        'entpnl
        '
        Me.entpnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.entpnl.ColumnCount = 4
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 312.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.entpnl.Controls.Add(Me.Close_pb, 3, 0)
        Me.entpnl.Controls.Add(Me.sendMail_pb, 2, 0)
        Me.entpnl.Controls.Add(Me.Lib_Mailing_txt, 1, 0)
        Me.entpnl.Controls.Add(Me.Cod_Mailing_txt, 0, 0)
        Me.entpnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.entpnl.Location = New System.Drawing.Point(2, 2)
        Me.entpnl.Margin = New System.Windows.Forms.Padding(4)
        Me.entpnl.Name = "entpnl"
        Me.entpnl.RowCount = 1
        Me.entpnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entpnl.Size = New System.Drawing.Size(847, 38)
        Me.entpnl.TabIndex = 84
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(813, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(30, 25)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 11
        Me.Close_pb.TabStop = False
        '
        'sendMail_pb
        '
        Me.sendMail_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.sendMail_pb.Image = Global.RHP.My.Resources.Resources.btn_mail_w
        Me.sendMail_pb.InitialImage = Nothing
        Me.sendMail_pb.Location = New System.Drawing.Point(775, 4)
        Me.sendMail_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.sendMail_pb.Name = "sendMail_pb"
        Me.sendMail_pb.Size = New System.Drawing.Size(30, 25)
        Me.sendMail_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.sendMail_pb.TabIndex = 11
        Me.sendMail_pb.TabStop = False
        '
        'Lib_Mailing_txt
        '
        Me.Lib_Mailing_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Mailing_txt.ContextMenuStrip = Nothing
        Me.Lib_Mailing_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lib_Mailing_txt.Location = New System.Drawing.Point(316, 5)
        Me.Lib_Mailing_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Lib_Mailing_txt.MaxLength = 32767
        Me.Lib_Mailing_txt.Multiline = False
        Me.Lib_Mailing_txt.Name = "Lib_Mailing_txt"
        Me.Lib_Mailing_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Mailing_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Mailing_txt.ReadOnly = True
        Me.Lib_Mailing_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Mailing_txt.SelectionStart = 0
        Me.Lib_Mailing_txt.Size = New System.Drawing.Size(451, 28)
        Me.Lib_Mailing_txt.TabIndex = 12
        Me.Lib_Mailing_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Mailing_txt.UseSystemPasswordChar = False
        '
        'Cod_Mailing_txt
        '
        Me.Cod_Mailing_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Mailing_txt.ContextMenuStrip = Nothing
        Me.Cod_Mailing_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cod_Mailing_txt.Location = New System.Drawing.Point(4, 6)
        Me.Cod_Mailing_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Cod_Mailing_txt.MaxLength = 32767
        Me.Cod_Mailing_txt.Multiline = False
        Me.Cod_Mailing_txt.Name = "Cod_Mailing_txt"
        Me.Cod_Mailing_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Mailing_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Mailing_txt.ReadOnly = True
        Me.Cod_Mailing_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Mailing_txt.SelectionStart = 0
        Me.Cod_Mailing_txt.Size = New System.Drawing.Size(304, 26)
        Me.Cod_Mailing_txt.TabIndex = 12
        Me.Cod_Mailing_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Mailing_txt.UseSystemPasswordChar = False
        '
        'results_grp
        '
        Me.results_grp.Controls.Add(Me.Results_txt)
        Me.results_grp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.results_grp.Location = New System.Drawing.Point(2, 258)
        Me.results_grp.Name = "results_grp"
        Me.results_grp.Size = New System.Drawing.Size(847, 391)
        Me.results_grp.TabIndex = 86
        Me.results_grp.TabStop = False
        Me.results_grp.Text = "Mails envoyés"
        '
        'Results_txt
        '
        Me.Results_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Results_txt.Location = New System.Drawing.Point(3, 20)
        Me.Results_txt.Multiline = True
        Me.Results_txt.Name = "Results_txt"
        Me.Results_txt.ReadOnly = True
        Me.Results_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Results_txt.Size = New System.Drawing.Size(841, 368)
        Me.Results_txt.TabIndex = 0
        '
        'Mailing_Saisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(851, 651)
        Me.Controls.Add(Me.results_grp)
        Me.Controls.Add(Me.Parametres_Grd)
        Me.Controls.Add(Me.entpnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Mailing_Saisi"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.Tag = ""
        CType(Me.Parametres_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.entpnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sendMail_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.results_grp.ResumeLayout(False)
        Me.results_grp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Parametres_Grd As ud_Grd
    Friend WithEvents entpnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents sendMail_pb As PictureBox
    Friend WithEvents Lib_Mailing_txt As ud_TextBox
    Friend WithEvents Cod_Mailing_txt As ud_TextBox
    Friend WithEvents Parametre As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Parametre As DataGridViewTextBoxColumn
    Friend WithEvents Valeur As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents results_grp As GroupBox
    Friend WithEvents Results_txt As TextBox
End Class
