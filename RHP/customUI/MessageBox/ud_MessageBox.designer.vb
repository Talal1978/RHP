<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_MessageBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ud_MessageBox))
        Me.Msg_txt = New System.Windows.Forms.Label()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.tblPnl = New System.Windows.Forms.TableLayoutPanel()
        Me.pb_Msg = New System.Windows.Forms.PictureBox()
        Me.btn_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_03_ud = New RHP.ud_button()
        Me.btn_01_ud = New RHP.ud_button()
        Me.btn_02_ud = New RHP.ud_button()
        Me.tblPnl.SuspendLayout()
        CType(Me.pb_Msg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btn_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Msg_txt
        '
        Me.tblPnl.SetColumnSpan(Me.Msg_txt, 4)
        Me.Msg_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Msg_txt.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Msg_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Msg_txt.Location = New System.Drawing.Point(3, 34)
        Me.Msg_txt.Margin = New System.Windows.Forms.Padding(3)
        Me.Msg_txt.MaximumSize = New System.Drawing.Size(400, 0)
        Me.Msg_txt.MinimumSize = New System.Drawing.Size(0, 60)
        Me.Msg_txt.Name = "Msg_txt"
        Me.Msg_txt.Size = New System.Drawing.Size(377, 97)
        Me.Msg_txt.TabIndex = 234
        Me.Msg_txt.Text = "Le suppléant est un agent qui remplace le signataire en cas d'absence. "
        Me.Msg_txt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.tblPnl.SetColumnSpan(Me.Titre_lbl, 5)
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(0)
        Me.Titre_lbl.MinimumSize = New System.Drawing.Size(0, 31)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(490, 31)
        Me.Titre_lbl.TabIndex = 240
        Me.Titre_lbl.Text = "Message"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tblPnl
        '
        Me.tblPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.tblPnl.ColumnCount = 5
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblPnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.tblPnl.Controls.Add(Me.Msg_txt, 0, 1)
        Me.tblPnl.Controls.Add(Me.Titre_lbl, 0, 0)
        Me.tblPnl.Controls.Add(Me.pb_Msg, 4, 1)
        Me.tblPnl.Controls.Add(Me.btn_pnl, 0, 2)
        Me.tblPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPnl.Location = New System.Drawing.Point(2, 2)
        Me.tblPnl.Margin = New System.Windows.Forms.Padding(0)
        Me.tblPnl.Name = "tblPnl"
        Me.tblPnl.RowCount = 3
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.tblPnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblPnl.Size = New System.Drawing.Size(490, 180)
        Me.tblPnl.TabIndex = 241
        '
        'pb_Msg
        '
        Me.pb_Msg.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_Msg.Image = CType(resources.GetObject("pb_Msg.Image"), System.Drawing.Image)
        Me.pb_Msg.Location = New System.Drawing.Point(396, 42)
        Me.pb_Msg.Margin = New System.Windows.Forms.Padding(0)
        Me.pb_Msg.MaximumSize = New System.Drawing.Size(80, 80)
        Me.pb_Msg.MinimumSize = New System.Drawing.Size(80, 80)
        Me.pb_Msg.Name = "pb_Msg"
        Me.pb_Msg.Size = New System.Drawing.Size(80, 80)
        Me.pb_Msg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_Msg.TabIndex = 241
        Me.pb_Msg.TabStop = False
        '
        'btn_pnl
        '
        Me.btn_pnl.ColumnCount = 3
        Me.tblPnl.SetColumnSpan(Me.btn_pnl, 5)
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.btn_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.btn_pnl.Controls.Add(Me.btn_03_ud, 0, 0)
        Me.btn_pnl.Controls.Add(Me.btn_01_ud, 2, 0)
        Me.btn_pnl.Controls.Add(Me.btn_02_ud, 1, 0)
        Me.btn_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_pnl.Location = New System.Drawing.Point(0, 134)
        Me.btn_pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_pnl.Name = "btn_pnl"
        Me.btn_pnl.RowCount = 1
        Me.btn_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.btn_pnl.Size = New System.Drawing.Size(490, 46)
        Me.btn_pnl.TabIndex = 242
        '
        'btn_03_ud
        '
        Me.btn_03_ud.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_03_ud.AutoSize = True
        Me.btn_03_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btn_03_ud.Border = RHP.ud_button.BorderStyle.All
        Me.btn_03_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btn_03_ud.BorderSize = 2
        Me.btn_03_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_03_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.btn_03_ud.Image = Global.RHP.My.Resources.Resources.btn_no
        Me.btn_03_ud.isDefault = False
        Me.btn_03_ud.Location = New System.Drawing.Point(80, 6)
        Me.btn_03_ud.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_03_ud.MaximumSize = New System.Drawing.Size(100, 33)
        Me.btn_03_ud.MinimumSize = New System.Drawing.Size(100, 33)
        Me.btn_03_ud.Name = "btn_03_ud"
        Me.btn_03_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_03_ud.Size = New System.Drawing.Size(100, 33)
        Me.btn_03_ud.TabIndex = 239
        Me.btn_03_ud.Text = "Non"
        '
        'btn_01_ud
        '
        Me.btn_01_ud.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_01_ud.AutoSize = True
        Me.btn_01_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btn_01_ud.Border = RHP.ud_button.BorderStyle.All
        Me.btn_01_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btn_01_ud.BorderSize = 2
        Me.btn_01_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_01_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.btn_01_ud.Image = Global.RHP.My.Resources.Resources.btn_yes
        Me.btn_01_ud.isDefault = False
        Me.btn_01_ud.Location = New System.Drawing.Point(310, 6)
        Me.btn_01_ud.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_01_ud.MaximumSize = New System.Drawing.Size(100, 33)
        Me.btn_01_ud.MinimumSize = New System.Drawing.Size(100, 33)
        Me.btn_01_ud.Name = "btn_01_ud"
        Me.btn_01_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_01_ud.Size = New System.Drawing.Size(100, 33)
        Me.btn_01_ud.TabIndex = 239
        Me.btn_01_ud.Text = "Oui"
        '
        'btn_02_ud
        '
        Me.btn_02_ud.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_02_ud.AutoSize = True
        Me.btn_02_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btn_02_ud.Border = RHP.ud_button.BorderStyle.All
        Me.btn_02_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btn_02_ud.BorderSize = 2
        Me.btn_02_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_02_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.btn_02_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.btn_02_ud.isDefault = False
        Me.btn_02_ud.Location = New System.Drawing.Point(195, 6)
        Me.btn_02_ud.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_02_ud.MaximumSize = New System.Drawing.Size(100, 33)
        Me.btn_02_ud.MinimumSize = New System.Drawing.Size(100, 33)
        Me.btn_02_ud.Name = "btn_02_ud"
        Me.btn_02_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_02_ud.Size = New System.Drawing.Size(100, 33)
        Me.btn_02_ud.TabIndex = 240
        Me.btn_02_ud.Text = "Annuler"
        '
        'ud_MessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(494, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.tblPnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(360, 146)
        Me.Name = "ud_MessageBox"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Message"
        Me.tblPnl.ResumeLayout(False)
        CType(Me.pb_Msg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btn_pnl.ResumeLayout(False)
        Me.btn_pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Msg_txt As Label
    Friend WithEvents btn_01_ud As ud_button
    Friend WithEvents btn_03_ud As ud_button
    Friend WithEvents btn_02_ud As ud_button
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents tblPnl As TableLayoutPanel
    Friend WithEvents pb_Msg As PictureBox
    Friend WithEvents btn_pnl As TableLayoutPanel
End Class
