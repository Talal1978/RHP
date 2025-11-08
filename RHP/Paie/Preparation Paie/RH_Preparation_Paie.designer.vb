<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Preparation_Paie
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PrePaie_Grd = New RHP.ud_Grd()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Ent0 = New System.Windows.Forms.GroupBox()
        Me.AlternerLesLignes_chk = New RHP.ud_CheckBox()
        Me.rowHeaderVisible_chk = New RHP.ud_CheckBox()
        Me.withLog_chk = New RHP.ud_CheckBox()
        Me.HighLightResume_Chk = New RHP.ud_CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ShowEV_chk = New RHP.ud_CheckBox()
        Me.ShowGains_chk = New RHP.ud_CheckBox()
        Me.ShowCP_chk = New RHP.ud_CheckBox()
        Me.ShowRetenues_chk = New RHP.ud_CheckBox()
        Me.Controler_chk = New RHP.ud_CheckBox()
        Me.HighLightEV_Chk = New RHP.ud_CheckBox()
        Me.Lib_Preparation_Text = New RHP.ud_TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Grd_Controles = New RHP.ud_Grd()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Dat_Fin_Periode_Text = New RHP.ud_TextBox()
        Me.Cloture_Check = New RHP.ud_CheckBox()
        Me.Dat_Deb_Periode_Text = New RHP.ud_TextBox()
        Me.Dat_Deb_Periode_ = New System.Windows.Forms.LinkLabel()
        Me.Plan_Paie_ = New System.Windows.Forms.LinkLabel()
        Me.Cod_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Lib_Plan_Paie_Text = New RHP.ud_TextBox()
        Me.Cod_Preparation_ = New System.Windows.Forms.LinkLabel()
        Me.Cod_Preparation_Text = New RHP.ud_TextBox()
        Me.EntPnl = New System.Windows.Forms.Panel()
        Me.ModifierPlan_btn = New RHP.ud_button()
        CType(Me.PrePaie_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Ent0.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.Grd_Controles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EntPnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrePaie_Grd
        '
        Me.PrePaie_Grd.AfficherLesEntetesLignes = True
        Me.PrePaie_Grd.AllowUserToAddRows = False
        Me.PrePaie_Grd.AlternerLesLignes = False
        Me.PrePaie_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PrePaie_Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PrePaie_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrePaie_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.PrePaie_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PrePaie_Grd.DefaultCellStyle = DataGridViewCellStyle8
        Me.PrePaie_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrePaie_Grd.EnableHeadersVisualStyles = False
        Me.PrePaie_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.PrePaie_Grd.Location = New System.Drawing.Point(5, 6)
        Me.PrePaie_Grd.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.PrePaie_Grd.Name = "PrePaie_Grd"
        Me.PrePaie_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.PrePaie_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.PrePaie_Grd.RowHeadersVisible = False
        Me.PrePaie_Grd.RowHeadersWidth = 51
        Me.PrePaie_Grd.Size = New System.Drawing.Size(1296, 828)
        Me.PrePaie_Grd.TabIndex = 207
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 56)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1314, 872)
        Me.TabControl1.TabIndex = 208
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Ent0)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TabPage1.Size = New System.Drawing.Size(1306, 840)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Miscellaneous"
        '
        'Ent0
        '
        Me.Ent0.Controls.Add(Me.AlternerLesLignes_chk)
        Me.Ent0.Controls.Add(Me.rowHeaderVisible_chk)
        Me.Ent0.Controls.Add(Me.withLog_chk)
        Me.Ent0.Controls.Add(Me.HighLightResume_Chk)
        Me.Ent0.Controls.Add(Me.GroupBox1)
        Me.Ent0.Controls.Add(Me.Controler_chk)
        Me.Ent0.Controls.Add(Me.HighLightEV_Chk)
        Me.Ent0.Controls.Add(Me.Lib_Preparation_Text)
        Me.Ent0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ent0.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Ent0.Location = New System.Drawing.Point(5, 6)
        Me.Ent0.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Ent0.Name = "Ent0"
        Me.Ent0.Padding = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Ent0.Size = New System.Drawing.Size(1296, 828)
        Me.Ent0.TabIndex = 0
        Me.Ent0.TabStop = False
        Me.Ent0.Text = "Préparation de la Paie"
        '
        'AlternerLesLignes_chk
        '
        Me.AlternerLesLignes_chk.AutoSize = True
        Me.AlternerLesLignes_chk.Checked = False
        Me.AlternerLesLignes_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.AlternerLesLignes_chk.Location = New System.Drawing.Point(62, 300)
        Me.AlternerLesLignes_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.AlternerLesLignes_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.AlternerLesLignes_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.AlternerLesLignes_chk.Name = "AlternerLesLignes_chk"
        Me.AlternerLesLignes_chk.Size = New System.Drawing.Size(146, 31)
        Me.AlternerLesLignes_chk.TabIndex = 256
        Me.AlternerLesLignes_chk.Text = "Alterner les lignes"
        '
        'rowHeaderVisible_chk
        '
        Me.rowHeaderVisible_chk.AutoSize = True
        Me.rowHeaderVisible_chk.Checked = True
        Me.rowHeaderVisible_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.rowHeaderVisible_chk.Location = New System.Drawing.Point(62, 274)
        Me.rowHeaderVisible_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.rowHeaderVisible_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.rowHeaderVisible_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.rowHeaderVisible_chk.Name = "rowHeaderVisible_chk"
        Me.rowHeaderVisible_chk.Size = New System.Drawing.Size(206, 31)
        Me.rowHeaderVisible_chk.TabIndex = 256
        Me.rowHeaderVisible_chk.Text = "Afficher l'entête des lignes"
        '
        'withLog_chk
        '
        Me.withLog_chk.AutoSize = True
        Me.withLog_chk.Checked = False
        Me.withLog_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.withLog_chk.Location = New System.Drawing.Point(11, 509)
        Me.withLog_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.withLog_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.withLog_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.withLog_chk.Name = "withLog_chk"
        Me.withLog_chk.Size = New System.Drawing.Size(187, 31)
        Me.withLog_chk.TabIndex = 255
        Me.withLog_chk.Text = "Ecrire le log des calculs"
        '
        'HighLightResume_Chk
        '
        Me.HighLightResume_Chk.AutoSize = True
        Me.HighLightResume_Chk.Checked = True
        Me.HighLightResume_Chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.HighLightResume_Chk.Location = New System.Drawing.Point(62, 245)
        Me.HighLightResume_Chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.HighLightResume_Chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.HighLightResume_Chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.HighLightResume_Chk.Name = "HighLightResume_Chk"
        Me.HighLightResume_Chk.Size = New System.Drawing.Size(211, 31)
        Me.HighLightResume_Chk.TabIndex = 253
        Me.HighLightResume_Chk.Text = "Mettre les résumés en relief"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ShowEV_chk)
        Me.GroupBox1.Controls.Add(Me.ShowGains_chk)
        Me.GroupBox1.Controls.Add(Me.ShowCP_chk)
        Me.GroupBox1.Controls.Add(Me.ShowRetenues_chk)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 341)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(855, 158)
        Me.GroupBox1.TabIndex = 254
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Masquer tout sauf :"
        '
        'ShowEV_chk
        '
        Me.ShowEV_chk.AutoSize = True
        Me.ShowEV_chk.Checked = True
        Me.ShowEV_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ShowEV_chk.Location = New System.Drawing.Point(21, 28)
        Me.ShowEV_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ShowEV_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.ShowEV_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.ShowEV_chk.Name = "ShowEV_chk"
        Me.ShowEV_chk.Size = New System.Drawing.Size(181, 31)
        Me.ShowEV_chk.TabIndex = 253
        Me.ShowEV_chk.Text = "Les élements variables"
        '
        'ShowGains_chk
        '
        Me.ShowGains_chk.AutoSize = True
        Me.ShowGains_chk.Checked = True
        Me.ShowGains_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ShowGains_chk.Location = New System.Drawing.Point(21, 58)
        Me.ShowGains_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ShowGains_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.ShowGains_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.ShowGains_chk.Name = "ShowGains_chk"
        Me.ShowGains_chk.Size = New System.Drawing.Size(146, 31)
        Me.ShowGains_chk.TabIndex = 253
        Me.ShowGains_chk.Text = "Les gains"
        '
        'ShowCP_chk
        '
        Me.ShowCP_chk.AutoSize = True
        Me.ShowCP_chk.Checked = True
        Me.ShowCP_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ShowCP_chk.Location = New System.Drawing.Point(21, 119)
        Me.ShowCP_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ShowCP_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.ShowCP_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.ShowCP_chk.Name = "ShowCP_chk"
        Me.ShowCP_chk.Size = New System.Drawing.Size(186, 31)
        Me.ShowCP_chk.TabIndex = 253
        Me.ShowCP_chk.Text = "Les charges patronales"
        '
        'ShowRetenues_chk
        '
        Me.ShowRetenues_chk.AutoSize = True
        Me.ShowRetenues_chk.Checked = True
        Me.ShowRetenues_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ShowRetenues_chk.Location = New System.Drawing.Point(21, 88)
        Me.ShowRetenues_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ShowRetenues_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.ShowRetenues_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.ShowRetenues_chk.Name = "ShowRetenues_chk"
        Me.ShowRetenues_chk.Size = New System.Drawing.Size(146, 31)
        Me.ShowRetenues_chk.TabIndex = 253
        Me.ShowRetenues_chk.Text = "Les retenues"
        '
        'Controler_chk
        '
        Me.Controler_chk.AutoSize = True
        Me.Controler_chk.Checked = True
        Me.Controler_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Controler_chk.Location = New System.Drawing.Point(62, 194)
        Me.Controler_chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Controler_chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Controler_chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Controler_chk.Name = "Controler_chk"
        Me.Controler_chk.Size = New System.Drawing.Size(316, 31)
        Me.Controler_chk.TabIndex = 252
        Me.Controler_chk.Text = "Contrôler la cohérence de la préparation"
        '
        'HighLightEV_Chk
        '
        Me.HighLightEV_Chk.AutoSize = True
        Me.HighLightEV_Chk.Checked = True
        Me.HighLightEV_Chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.HighLightEV_Chk.Location = New System.Drawing.Point(62, 219)
        Me.HighLightEV_Chk.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.HighLightEV_Chk.MaximumSize = New System.Drawing.Size(0, 31)
        Me.HighLightEV_Chk.MinimumSize = New System.Drawing.Size(146, 31)
        Me.HighLightEV_Chk.Name = "HighLightEV_Chk"
        Me.HighLightEV_Chk.Size = New System.Drawing.Size(275, 31)
        Me.HighLightEV_Chk.TabIndex = 253
        Me.HighLightEV_Chk.Text = "Mettre les élements variales en relief"
        '
        'Lib_Preparation_Text
        '
        Me.Lib_Preparation_Text.AccessibleDescription = "A"
        Me.Lib_Preparation_Text.AutoSize = True
        Me.Lib_Preparation_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Preparation_Text.ContextMenuStrip = Nothing
        Me.Lib_Preparation_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Preparation_Text.Location = New System.Drawing.Point(10, 34)
        Me.Lib_Preparation_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Lib_Preparation_Text.MaxLength = 32767
        Me.Lib_Preparation_Text.Multiline = True
        Me.Lib_Preparation_Text.Name = "Lib_Preparation_Text"
        Me.Lib_Preparation_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Preparation_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Preparation_Text.ReadOnly = False
        Me.Lib_Preparation_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Preparation_Text.SelectionStart = 0
        Me.Lib_Preparation_Text.Size = New System.Drawing.Size(856, 148)
        Me.Lib_Preparation_Text.TabIndex = 208
        Me.Lib_Preparation_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Preparation_Text.UseSystemPasswordChar = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.PrePaie_Grd)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TabPage2.Size = New System.Drawing.Size(1306, 840)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Détail de la paie"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Grd_Controles)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TabPage3.Size = New System.Drawing.Size(1306, 840)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Contrôle de la paie"
        '
        'Grd_Controles
        '
        Me.Grd_Controles.AfficherLesEntetesLignes = True
        Me.Grd_Controles.AllowUserToAddRows = False
        Me.Grd_Controles.AllowUserToDeleteRows = False
        Me.Grd_Controles.AllowUserToOrderColumns = True
        Me.Grd_Controles.AlternerLesLignes = False
        Me.Grd_Controles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Controles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Grd_Controles.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Controles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Controles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Controles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Controles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Controles.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Controles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Controles.EnableHeadersVisualStyles = False
        Me.Grd_Controles.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Controles.Location = New System.Drawing.Point(5, 6)
        Me.Grd_Controles.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Grd_Controles.MultiSelect = False
        Me.Grd_Controles.Name = "Grd_Controles"
        Me.Grd_Controles.ReadOnly = True
        Me.Grd_Controles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Controles.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Controles.RowHeadersWidth = 51
        Me.Grd_Controles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grd_Controles.Size = New System.Drawing.Size(1296, 828)
        Me.Grd_Controles.TabIndex = 1
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(914, 25)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(27, 19)
        Me.LinkLabel1.TabIndex = 233
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "NC"
        Me.LinkLabel1.Text = "Au"
        '
        'Dat_Fin_Periode_Text
        '
        Me.Dat_Fin_Periode_Text.AutoSize = True
        Me.Dat_Fin_Periode_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Fin_Periode_Text.ContextMenuStrip = Nothing
        Me.Dat_Fin_Periode_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Fin_Periode_Text.Location = New System.Drawing.Point(944, 21)
        Me.Dat_Fin_Periode_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Dat_Fin_Periode_Text.MaxLength = 50
        Me.Dat_Fin_Periode_Text.Multiline = False
        Me.Dat_Fin_Periode_Text.Name = "Dat_Fin_Periode_Text"
        Me.Dat_Fin_Periode_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Fin_Periode_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Fin_Periode_Text.ReadOnly = True
        Me.Dat_Fin_Periode_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Fin_Periode_Text.SelectionStart = 0
        Me.Dat_Fin_Periode_Text.Size = New System.Drawing.Size(89, 26)
        Me.Dat_Fin_Periode_Text.TabIndex = 232
        Me.Dat_Fin_Periode_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Dat_Fin_Periode_Text.UseSystemPasswordChar = False
        '
        'Cloture_Check
        '
        Me.Cloture_Check.AutoSize = True
        Me.Cloture_Check.Checked = False
        Me.Cloture_Check.Enabled = False
        Me.Cloture_Check.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cloture_Check.Location = New System.Drawing.Point(1038, 24)
        Me.Cloture_Check.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cloture_Check.MaximumSize = New System.Drawing.Size(0, 31)
        Me.Cloture_Check.MinimumSize = New System.Drawing.Size(146, 31)
        Me.Cloture_Check.Name = "Cloture_Check"
        Me.Cloture_Check.Size = New System.Drawing.Size(146, 31)
        Me.Cloture_Check.TabIndex = 228
        Me.Cloture_Check.Text = "Clôturée"
        '
        'Dat_Deb_Periode_Text
        '
        Me.Dat_Deb_Periode_Text.AutoSize = True
        Me.Dat_Deb_Periode_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Dat_Deb_Periode_Text.ContextMenuStrip = Nothing
        Me.Dat_Deb_Periode_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Deb_Periode_Text.Location = New System.Drawing.Point(814, 21)
        Me.Dat_Deb_Periode_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Dat_Deb_Periode_Text.MaxLength = 32767
        Me.Dat_Deb_Periode_Text.Multiline = False
        Me.Dat_Deb_Periode_Text.Name = "Dat_Deb_Periode_Text"
        Me.Dat_Deb_Periode_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Dat_Deb_Periode_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Dat_Deb_Periode_Text.ReadOnly = True
        Me.Dat_Deb_Periode_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Dat_Deb_Periode_Text.SelectionStart = 0
        Me.Dat_Deb_Periode_Text.Size = New System.Drawing.Size(89, 26)
        Me.Dat_Deb_Periode_Text.TabIndex = 225
        Me.Dat_Deb_Periode_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dat_Deb_Periode_Text.UseSystemPasswordChar = False
        '
        'Dat_Deb_Periode_
        '
        Me.Dat_Deb_Periode_.AutoSize = True
        Me.Dat_Deb_Periode_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Dat_Deb_Periode_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Dat_Deb_Periode_.Location = New System.Drawing.Point(782, 25)
        Me.Dat_Deb_Periode_.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Dat_Deb_Periode_.Name = "Dat_Deb_Periode_"
        Me.Dat_Deb_Periode_.Size = New System.Drawing.Size(28, 19)
        Me.Dat_Deb_Periode_.TabIndex = 224
        Me.Dat_Deb_Periode_.TabStop = True
        Me.Dat_Deb_Periode_.Tag = "NC"
        Me.Dat_Deb_Periode_.Text = "Du"
        '
        'Plan_Paie_
        '
        Me.Plan_Paie_.AutoSize = True
        Me.Plan_Paie_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Plan_Paie_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Plan_Paie_.Location = New System.Drawing.Point(251, 24)
        Me.Plan_Paie_.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Plan_Paie_.Name = "Plan_Paie_"
        Me.Plan_Paie_.Size = New System.Drawing.Size(39, 19)
        Me.Plan_Paie_.TabIndex = 218
        Me.Plan_Paie_.TabStop = True
        Me.Plan_Paie_.Tag = "NC"
        Me.Plan_Paie_.Text = "Plan"
        '
        'Cod_Plan_Paie_Text
        '
        Me.Cod_Plan_Paie_Text.AutoSize = True
        Me.Cod_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Cod_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_Text.Location = New System.Drawing.Point(298, 21)
        Me.Cod_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Plan_Paie_Text.MaxLength = 50
        Me.Cod_Plan_Paie_Text.Multiline = False
        Me.Cod_Plan_Paie_Text.Name = "Cod_Plan_Paie_Text"
        Me.Cod_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_Paie_Text.ReadOnly = True
        Me.Cod_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_Paie_Text.SelectionStart = 0
        Me.Cod_Plan_Paie_Text.Size = New System.Drawing.Size(104, 26)
        Me.Cod_Plan_Paie_Text.TabIndex = 220
        Me.Cod_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.AutoSize = True
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.ContextMenuStrip = Nothing
        Me.Lib_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(406, 21)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Lib_Plan_Paie_Text.MaxLength = 50
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = True
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(264, 26)
        Me.Lib_Plan_Paie_Text.TabIndex = 219
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'Cod_Preparation_
        '
        Me.Cod_Preparation_.AutoSize = True
        Me.Cod_Preparation_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Preparation_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Preparation_.Location = New System.Drawing.Point(9, 24)
        Me.Cod_Preparation_.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Cod_Preparation_.Name = "Cod_Preparation_"
        Me.Cod_Preparation_.Size = New System.Drawing.Size(90, 19)
        Me.Cod_Preparation_.TabIndex = 206
        Me.Cod_Preparation_.TabStop = True
        Me.Cod_Preparation_.Tag = ""
        Me.Cod_Preparation_.Text = "Préparation"
        '
        'Cod_Preparation_Text
        '
        Me.Cod_Preparation_Text.AccessibleDescription = "A"
        Me.Cod_Preparation_Text.AutoSize = True
        Me.Cod_Preparation_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Preparation_Text.ContextMenuStrip = Nothing
        Me.Cod_Preparation_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Preparation_Text.Location = New System.Drawing.Point(104, 21)
        Me.Cod_Preparation_Text.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Cod_Preparation_Text.MaxLength = 32767
        Me.Cod_Preparation_Text.Multiline = False
        Me.Cod_Preparation_Text.Name = "Cod_Preparation_Text"
        Me.Cod_Preparation_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Preparation_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Preparation_Text.ReadOnly = True
        Me.Cod_Preparation_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Preparation_Text.SelectionStart = 0
        Me.Cod_Preparation_Text.Size = New System.Drawing.Size(125, 26)
        Me.Cod_Preparation_Text.TabIndex = 207
        Me.Cod_Preparation_Text.TabStop = False
        Me.Cod_Preparation_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Preparation_Text.UseSystemPasswordChar = False
        '
        'EntPnl
        '
        Me.EntPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.EntPnl.Controls.Add(Me.ModifierPlan_btn)
        Me.EntPnl.Controls.Add(Me.Cod_Preparation_Text)
        Me.EntPnl.Controls.Add(Me.Cod_Preparation_)
        Me.EntPnl.Controls.Add(Me.Lib_Plan_Paie_Text)
        Me.EntPnl.Controls.Add(Me.Cod_Plan_Paie_Text)
        Me.EntPnl.Controls.Add(Me.Plan_Paie_)
        Me.EntPnl.Controls.Add(Me.Dat_Deb_Periode_Text)
        Me.EntPnl.Controls.Add(Me.Cloture_Check)
        Me.EntPnl.Controls.Add(Me.Dat_Deb_Periode_)
        Me.EntPnl.Controls.Add(Me.Dat_Fin_Periode_Text)
        Me.EntPnl.Controls.Add(Me.LinkLabel1)
        Me.EntPnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.EntPnl.Location = New System.Drawing.Point(0, 0)
        Me.EntPnl.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.EntPnl.Name = "EntPnl"
        Me.EntPnl.Size = New System.Drawing.Size(1314, 56)
        Me.EntPnl.TabIndex = 209
        '
        'ModifierPlan_btn
        '
        Me.ModifierPlan_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ModifierPlan_btn.bgColor = System.Drawing.Color.White
        Me.ModifierPlan_btn.Border = RHP.ud_button.BorderStyle.None
        Me.ModifierPlan_btn.BorderColor = System.Drawing.Color.Empty
        Me.ModifierPlan_btn.BorderSize = 0
        Me.ModifierPlan_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ModifierPlan_btn.Image = Global.RHP.My.Resources.Resources.btn_edit_doc
        Me.ModifierPlan_btn.isDefault = False
        Me.ModifierPlan_btn.Location = New System.Drawing.Point(674, 19)
        Me.ModifierPlan_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ModifierPlan_btn.MinimumSize = New System.Drawing.Size(29, 31)
        Me.ModifierPlan_btn.Name = "ModifierPlan_btn"
        Me.ModifierPlan_btn.Size = New System.Drawing.Size(34, 31)
        Me.ModifierPlan_btn.TabIndex = 234
        Me.ModifierPlan_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ModifierPlan_btn.ToolTip = "Editer le plan de paie"
        '
        'RH_Preparation_Paie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1314, 928)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.EntPnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "RH_Preparation_Paie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Préparation de la paie (Mode journal)"
        CType(Me.PrePaie_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Ent0.ResumeLayout(False)
        Me.Ent0.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Grd_Controles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EntPnl.ResumeLayout(False)
        Me.EntPnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrePaie_Grd As New ud_Grd
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Ent0 As System.Windows.Forms.GroupBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Cod_Preparation_ As System.Windows.Forms.LinkLabel
    Friend WithEvents Cod_Preparation_Text As ud_TextBox
    Friend WithEvents Lib_Preparation_Text As ud_TextBox
    Friend WithEvents Plan_Paie_ As System.Windows.Forms.LinkLabel
    Friend WithEvents Cod_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Dat_Deb_Periode_ As System.Windows.Forms.LinkLabel
    Friend WithEvents Cloture_Check As ud_CheckBox
    Friend WithEvents Dat_Fin_Periode_Text As ud_TextBox
    Friend WithEvents Dat_Deb_Periode_Text As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents EntPnl As Panel
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Grd_Controles As ud_Grd
    Friend WithEvents Controler_chk As ud_CheckBox
    Friend WithEvents ShowEV_chk As ud_CheckBox
    Friend WithEvents HighLightEV_Chk As ud_CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ShowGains_chk As ud_CheckBox
    Friend WithEvents ShowCP_chk As ud_CheckBox
    Friend WithEvents ShowRetenues_chk As ud_CheckBox
    Friend WithEvents HighLightResume_Chk As ud_CheckBox
    Friend WithEvents ModifierPlan_btn As ud_button
    Friend WithEvents withLog_chk As ud_CheckBox
    Friend WithEvents rowHeaderVisible_chk As ud_CheckBox
    Friend WithEvents AlternerLesLignes_chk As ud_CheckBox
End Class
