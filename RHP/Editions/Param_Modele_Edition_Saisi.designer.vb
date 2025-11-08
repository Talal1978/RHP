<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Param_Modele_Edition_Saisi
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Criteres_Grd = New RHP.ud_Grd()
        Me.Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.entpnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Imprimer_pb = New System.Windows.Forms.PictureBox()
        Me.Nom_Report_txt = New RHP.ud_TextBox()
        Me.Cod_Report_txt = New RHP.ud_TextBox()
        CType(Me.Criteres_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.entpnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imprimer_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Criteres_Grd
        '
        Me.Criteres_Grd.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Criteres_Grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Criteres_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Criteres_Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Criteres_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Criteres_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Criteres_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Criteres_Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Critere, Me.Lib_Critere, Me.Valeur, Me.Type})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Criteres_Grd.DefaultCellStyle = DataGridViewCellStyle7
        Me.Criteres_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Criteres_Grd.EnableHeadersVisualStyles = False
        Me.Criteres_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Criteres_Grd.Location = New System.Drawing.Point(2, 32)
        Me.Criteres_Grd.Name = "Criteres_Grd"
        Me.Criteres_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Criteres_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Criteres_Grd.RowHeadersVisible = False
        Me.Criteres_Grd.Size = New System.Drawing.Size(677, 487)
        Me.Criteres_Grd.TabIndex = 81
        '
        'Critere
        '
        Me.Critere.HeaderText = "Code Critère"
        Me.Critere.MinimumWidth = 200
        Me.Critere.Name = "Critere"
        Me.Critere.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Critere.Visible = False
        Me.Critere.Width = 200
        '
        'Lib_Critere
        '
        Me.Lib_Critere.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Lib_Critere.HeaderText = "Critère"
        Me.Lib_Critere.Name = "Lib_Critere"
        Me.Lib_Critere.ReadOnly = True
        Me.Lib_Critere.Width = 77
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
        Me.Type.Name = "Type"
        Me.Type.Visible = False
        '
        'entpnl
        '
        Me.entpnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.entpnl.ColumnCount = 4
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.entpnl.Controls.Add(Me.Close_pb, 3, 0)
        Me.entpnl.Controls.Add(Me.Imprimer_pb, 2, 0)
        Me.entpnl.Controls.Add(Me.Nom_Report_txt, 1, 0)
        Me.entpnl.Controls.Add(Me.Cod_Report_txt, 0, 0)
        Me.entpnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.entpnl.Location = New System.Drawing.Point(2, 2)
        Me.entpnl.Name = "entpnl"
        Me.entpnl.RowCount = 1
        Me.entpnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entpnl.Size = New System.Drawing.Size(677, 30)
        Me.entpnl.TabIndex = 84
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(650, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 20)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 11
        Me.Close_pb.TabStop = False
        '
        'Imprimer_pb
        '
        Me.Imprimer_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Imprimer_pb.Image = Global.RHP.My.Resources.Resources.btn_printer_w
        Me.Imprimer_pb.InitialImage = Nothing
        Me.Imprimer_pb.Location = New System.Drawing.Point(620, 3)
        Me.Imprimer_pb.Name = "Imprimer_pb"
        Me.Imprimer_pb.Size = New System.Drawing.Size(24, 20)
        Me.Imprimer_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Imprimer_pb.TabIndex = 11
        Me.Imprimer_pb.TabStop = False
        '
        'Nom_Report_txt
        '
        Me.Nom_Report_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Report_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Nom_Report_txt.Location = New System.Drawing.Point(253, 4)
        Me.Nom_Report_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Report_txt.MaxLength = 32767
        Me.Nom_Report_txt.Multiline = False
        Me.Nom_Report_txt.Name = "Nom_Report_txt"
        Me.Nom_Report_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Report_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Report_txt.ReadOnly = True
        Me.Nom_Report_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Report_txt.SelectionStart = 0
        Me.Nom_Report_txt.Size = New System.Drawing.Size(361, 22)
        Me.Nom_Report_txt.TabIndex = 12
        Me.Nom_Report_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Report_txt.UseSystemPasswordChar = False
        '
        'Cod_Report_txt
        '
        Me.Cod_Report_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Report_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cod_Report_txt.Location = New System.Drawing.Point(3, 5)
        Me.Cod_Report_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cod_Report_txt.MaxLength = 32767
        Me.Cod_Report_txt.Multiline = False
        Me.Cod_Report_txt.Name = "Cod_Report_txt"
        Me.Cod_Report_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Report_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Report_txt.ReadOnly = True
        Me.Cod_Report_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Report_txt.SelectionStart = 0
        Me.Cod_Report_txt.Size = New System.Drawing.Size(244, 20)
        Me.Cod_Report_txt.TabIndex = 12
        Me.Cod_Report_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Report_txt.UseSystemPasswordChar = False
        '
        'Param_Modele_Edition_Saisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(681, 521)
        Me.Controls.Add(Me.Criteres_Grd)
        Me.Controls.Add(Me.entpnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Param_Modele_Edition_Saisi"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.Tag = ""
        CType(Me.Criteres_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.entpnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imprimer_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Criteres_Grd As ud_Grd
    Friend WithEvents Critere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lib_Critere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valeur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents entpnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Imprimer_pb As PictureBox
    Friend WithEvents Nom_Report_txt As ud_TextBox
    Friend WithEvents Cod_Report_txt As ud_TextBox
End Class
