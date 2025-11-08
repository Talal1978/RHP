<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Param_Audit
    Inherits Ecran

    'Form rEmplace la méthode dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            end If
        finally
            MyBase.Dispose(disposing)
        end Try
    end Sub

    'Requise par le concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le concepteur Windows Form
    'Elle peut être modifiée à l'aide du concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cod_Audit_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Index_Table_Text = New RHP.ud_TextBox()
        Me.table_Name_Text = New RHP.ud_TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Audit_Grd = New RHP.ud_Grd()
        Me.Audits_Espions_lbl = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Audit_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cod_Audit_txt)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Index_Table_Text)
        Me.GroupBox1.Controls.Add(Me.table_Name_Text)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Size = New System.Drawing.Size(1418, 173)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = ""
        '
        'Cod_Audit_txt
        '
        Me.Cod_Audit_txt.AutoSize = True
        Me.Cod_Audit_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Audit_txt.ContextMenuStrip = Nothing
        Me.Cod_Audit_txt.Enabled = False
        Me.Cod_Audit_txt.Location = New System.Drawing.Point(162, 42)
        Me.Cod_Audit_txt.Margin = New System.Windows.Forms.Padding(5)
        Me.Cod_Audit_txt.MaxLength = 10
        Me.Cod_Audit_txt.Multiline = False
        Me.Cod_Audit_txt.Name = "Cod_Audit_txt"
        Me.Cod_Audit_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Audit_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Audit_txt.ReadOnly = True
        Me.Cod_Audit_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Audit_txt.SelectionStart = 0
        Me.Cod_Audit_txt.Size = New System.Drawing.Size(389, 24)
        Me.Cod_Audit_txt.TabIndex = 209
        Me.Cod_Audit_txt.Tag = ""
        Me.Cod_Audit_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Audit_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(57, 45)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(102, 19)
        Me.LinkLabel1.TabIndex = 208
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Code d'audit"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Audits_Espions_lbl)
        Me.GroupBox2.Location = New System.Drawing.Point(573, 12)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox2.Size = New System.Drawing.Size(837, 151)
        Me.GroupBox2.TabIndex = 207
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Audits espions générés"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 112)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 19)
        Me.Label1.TabIndex = 205
        Me.Label1.Text = "Index de la table"
        '
        'Index_Table_Text
        '
        Me.Index_Table_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Index_Table_Text.ContextMenuStrip = Nothing
        Me.Index_Table_Text.Enabled = False
        Me.Index_Table_Text.Location = New System.Drawing.Point(162, 108)
        Me.Index_Table_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Index_Table_Text.MaxLength = 32767
        Me.Index_Table_Text.Multiline = False
        Me.Index_Table_Text.Name = "Index_Table_Text"
        Me.Index_Table_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Index_Table_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Index_Table_Text.ReadOnly = True
        Me.Index_Table_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Index_Table_Text.SelectionStart = 0
        Me.Index_Table_Text.Size = New System.Drawing.Size(389, 24)
        Me.Index_Table_Text.TabIndex = 203
        Me.Index_Table_Text.Tag = ""
        Me.Index_Table_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Index_Table_Text.UseSystemPasswordChar = False
        '
        'table_Name_Text
        '
        Me.table_Name_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.table_Name_Text.ContextMenuStrip = Nothing
        Me.table_Name_Text.Enabled = False
        Me.table_Name_Text.Location = New System.Drawing.Point(162, 76)
        Me.table_Name_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.table_Name_Text.MaxLength = 10
        Me.table_Name_Text.Multiline = False
        Me.table_Name_Text.Name = "table_Name_Text"
        Me.table_Name_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.table_Name_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.table_Name_Text.ReadOnly = True
        Me.table_Name_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.table_Name_Text.SelectionStart = 0
        Me.table_Name_Text.Size = New System.Drawing.Size(389, 24)
        Me.table_Name_Text.TabIndex = 204
        Me.table_Name_Text.Tag = ""
        Me.table_Name_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.table_Name_Text.UseSystemPasswordChar = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(60, 79)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(94, 19)
        Me.LinkLabel2.TabIndex = 201
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = ""
        Me.LinkLabel2.Text = "Table de réf."
        '
        '
        Me.Audit_Grd.AfficherLesEntetesLignes = True
        Me.Audit_Grd.AllowUserToAddRows = False
        Me.Audit_Grd.AllowUserToDeleteRows = False
        Me.Audit_Grd.AllowUserToResizeRows = False
        Me.Audit_Grd.AlternerLesLignes = False
        Me.Audit_Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Audit_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Audit_Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Audit_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Audit_Grd.ColumnHeadersHeight = 50
        Me.Audit_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Audit_Grd.EnableHeadersVisualStyles = False
        Me.Audit_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Audit_Grd.Location = New System.Drawing.Point(0, 173)
        Me.Audit_Grd.Margin = New System.Windows.Forms.Padding(5)
        Me.Audit_Grd.Name = "Audit_Grd"
        Me.Audit_Grd.ReadOnly = True
        Me.Audit_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Audit_Grd.RowHeadersWidth = 51
        Me.Audit_Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Audit_Grd.Size = New System.Drawing.Size(1418, 592)
        Me.Audit_Grd.TabIndex = 2
        '
        'Audits_Espions_lbl
        '
        Me.Audits_Espions_lbl.AutoSize = True
        Me.Audits_Espions_lbl.Location = New System.Drawing.Point(32, 30)
        Me.Audits_Espions_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Audits_Espions_lbl.Name = "Audits_Espions_lbl"
        Me.Audits_Espions_lbl.Size = New System.Drawing.Size(0, 19)
        Me.Audits_Espions_lbl.TabIndex = 207
        '
        'Param_Audit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1418, 765)
        Me.Controls.Add(Me.Audit_Grd)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Param_Audit"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage et configuration des audits espions"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Audit_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Index_Table_Text As ud_TextBox
    Friend WithEvents table_Name_Text As ud_TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Audit_Grd As ud_Grd
    Friend WithEvents Cod_Audit_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Audits_Espions_lbl As Label
End Class
