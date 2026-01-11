<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Ai_EmbeddingConfig
    Inherits Ecran

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
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.TesterConn_pb = New System.Windows.Forms.PictureBox()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Modele_cbo = New RHP.ud_ComboBox()
        Me.Global_chk = New RHP.ud_CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AiUrl_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ApiKey_txt = New RHP.ud_TextBox()
        Me.lblDen = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Provider_cbo = New RHP.ud_ComboBox()
        Me.AddModele_pb = New System.Windows.Forms.PictureBox()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TesterConn_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.AddModele_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ent_pnl.ColumnCount = 4
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 671.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.ent_pnl.Controls.Add(Me.TesterConn_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Zoom_lbl, 2, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 3, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(796, 32)
        Me.ent_pnl.TabIndex = 9
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(0, 0)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(40, 32)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 7
        Me.Save_pb.TabStop = False
        '
        'TesterConn_pb
        '
        Me.TesterConn_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TesterConn_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TesterConn_pb.Image = Global.RHP.My.Resources.Resources.btn_testCon
        Me.TesterConn_pb.Location = New System.Drawing.Point(40, 0)
        Me.TesterConn_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.TesterConn_pb.Name = "TesterConn_pb"
        Me.TesterConn_pb.Size = New System.Drawing.Size(41, 32)
        Me.TesterConn_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.TesterConn_pb.TabIndex = 7
        Me.TesterConn_pb.TabStop = False
        '
        'Zoom_lbl
        '
        Me.Zoom_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Zoom_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Zoom_lbl.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Zoom_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Zoom_lbl.Location = New System.Drawing.Point(84, 0)
        Me.Zoom_lbl.Name = "Zoom_lbl"
        Me.Zoom_lbl.Size = New System.Drawing.Size(665, 32)
        Me.Zoom_lbl.TabIndex = 6
        Me.Zoom_lbl.Text = "Configuration du service d'embedding"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(752, 0)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(44, 32)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 7
        Me.Close_pb.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.AddModele_pb)
        Me.Panel1.Controls.Add(Me.Modele_cbo)
        Me.Panel1.Controls.Add(Me.Global_chk)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.AiUrl_txt)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ApiKey_txt)
        Me.Panel1.Controls.Add(Me.lblDen)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Provider_cbo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 204)
        Me.Panel1.TabIndex = 10
        '
        'Modele_cbo
        '
        Me.Modele_cbo.DataSource = Nothing
        Me.Modele_cbo.DisplayMember = ""
        Me.Modele_cbo.DroppedDown = False
        Me.Modele_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Modele_cbo.Location = New System.Drawing.Point(136, 65)
        Me.Modele_cbo.Margin = New System.Windows.Forms.Padding(2)
        Me.Modele_cbo.Name = "Modele_cbo"
        Me.Modele_cbo.SelectedIndex = -1
        Me.Modele_cbo.SelectedItem = Nothing
        Me.Modele_cbo.SelectedValue = Nothing
        Me.Modele_cbo.Size = New System.Drawing.Size(576, 30)
        Me.Modele_cbo.TabIndex = 192
        Me.Modele_cbo.ValueMember = ""
        '
        'Global_chk
        '
        Me.Global_chk.AutoSize = True
        Me.Global_chk.Checked = True
        Me.Global_chk.Location = New System.Drawing.Point(136, 173)
        Me.Global_chk.Margin = New System.Windows.Forms.Padding(4)
        Me.Global_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.Global_chk.MinimumSize = New System.Drawing.Size(133, 25)
        Me.Global_chk.Name = "Global_chk"
        Me.Global_chk.Size = New System.Drawing.Size(147, 25)
        Me.Global_chk.TabIndex = 191
        Me.Global_chk.Text = "Paramétrage global"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(58, 67)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 19)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "Modèle"
        '
        'AiUrl_txt
        '
        Me.AiUrl_txt.AutoSize = True
        Me.AiUrl_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.AiUrl_txt.ContextMenuStrip = Nothing
        Me.AiUrl_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AiUrl_txt.Location = New System.Drawing.Point(136, 102)
        Me.AiUrl_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.AiUrl_txt.MaxLength = 300
        Me.AiUrl_txt.Multiline = False
        Me.AiUrl_txt.Name = "AiUrl_txt"
        Me.AiUrl_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.AiUrl_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.AiUrl_txt.ReadOnly = False
        Me.AiUrl_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.AiUrl_txt.SelectionStart = 0
        Me.AiUrl_txt.Size = New System.Drawing.Size(613, 26)
        Me.AiUrl_txt.TabIndex = 187
        Me.AiUrl_txt.Tag = "0"
        Me.AiUrl_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.AiUrl_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(95, 102)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 19)
        Me.Label1.TabIndex = 188
        Me.Label1.Text = "Url"
        '
        'ApiKey_txt
        '
        Me.ApiKey_txt.AutoSize = True
        Me.ApiKey_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.ApiKey_txt.ContextMenuStrip = Nothing
        Me.ApiKey_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApiKey_txt.Location = New System.Drawing.Point(136, 132)
        Me.ApiKey_txt.Margin = New System.Windows.Forms.Padding(2)
        Me.ApiKey_txt.MaxLength = 300
        Me.ApiKey_txt.Multiline = False
        Me.ApiKey_txt.Name = "ApiKey_txt"
        Me.ApiKey_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.ApiKey_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ApiKey_txt.ReadOnly = False
        Me.ApiKey_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.ApiKey_txt.SelectionStart = 0
        Me.ApiKey_txt.Size = New System.Drawing.Size(613, 26)
        Me.ApiKey_txt.TabIndex = 185
        Me.ApiKey_txt.Tag = "0"
        Me.ApiKey_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ApiKey_txt.UseSystemPasswordChar = False
        '
        'lblDen
        '
        Me.lblDen.AutoSize = True
        Me.lblDen.BackColor = System.Drawing.Color.Transparent
        Me.lblDen.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.lblDen.Location = New System.Drawing.Point(75, 135)
        Me.lblDen.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDen.Name = "lblDen"
        Me.lblDen.Size = New System.Drawing.Size(56, 19)
        Me.lblDen.TabIndex = 186
        Me.lblDen.Text = "Clé API"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(74, 36)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 19)
        Me.Label19.TabIndex = 184
        Me.Label19.Text = "Service"
        '
        'Provider_cbo
        '
        Me.Provider_cbo.DataSource = Nothing
        Me.Provider_cbo.DisplayMember = ""
        Me.Provider_cbo.DroppedDown = False
        Me.Provider_cbo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Provider_cbo.Location = New System.Drawing.Point(136, 31)
        Me.Provider_cbo.Margin = New System.Windows.Forms.Padding(2)
        Me.Provider_cbo.Name = "Provider_cbo"
        Me.Provider_cbo.SelectedIndex = -1
        Me.Provider_cbo.SelectedItem = Nothing
        Me.Provider_cbo.SelectedValue = Nothing
        Me.Provider_cbo.Size = New System.Drawing.Size(613, 30)
        Me.Provider_cbo.TabIndex = 183
        Me.Provider_cbo.ValueMember = ""
        '
        'AddModele_pb
        '
        Me.AddModele_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AddModele_pb.Image = Global.RHP.My.Resources.Resources.btn_edit_doc
        Me.AddModele_pb.Location = New System.Drawing.Point(714, 63)
        Me.AddModele_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.AddModele_pb.Name = "AddModele_pb"
        Me.AddModele_pb.Size = New System.Drawing.Size(41, 32)
        Me.AddModele_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.AddModele_pb.TabIndex = 208
        Me.AddModele_pb.TabStop = False
        '
        'Zoom_Ai_EmbeddingConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 240)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ent_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_Ai_EmbeddingConfig"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Zoom_Ai_EmbeddingConfig"
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TesterConn_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.AddModele_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents TesterConn_pb As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents Provider_cbo As ud_ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents AiUrl_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ApiKey_txt As ud_TextBox
    Friend WithEvents lblDen As Label
    Friend WithEvents Global_chk As ud_CheckBox
    Friend WithEvents Modele_cbo As ud_ComboBox
    Friend WithEvents AddModele_pb As PictureBox
End Class
