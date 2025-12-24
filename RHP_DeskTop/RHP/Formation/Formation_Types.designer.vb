<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formation_Types
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
        Me.components = New System.ComponentModel.Container()
        Me.CntScripts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Lib_Domaine_Comepence_txt = New RHP.ud_TextBox()
        Me.Domaine_Comepence_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Grd = New RHP.ud_Grd()
        Me.RowId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Formation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Genre_Formation = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.CntScripts.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CntScripts
        '
        Me.CntScripts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupprimerToolStripMenuItem})
        Me.CntScripts.Name = "CntScripts"
        Me.CntScripts.Size = New System.Drawing.Size(130, 26)
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.supprimerligne
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        Me.SupprimerToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SupprimerToolStripMenuItem.Text = "Supprimer"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "                             "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Lib_Domaine_Comepence_txt)
        Me.GroupBox2.Controls.Add(Me.Domaine_Comepence_txt)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(885, 42)
        Me.GroupBox2.TabIndex = 218
        Me.GroupBox2.TabStop = False
        '
        'Lib_Domaine_Comepence_txt
        '
        Me.Lib_Domaine_Comepence_txt.BackColor = System.Drawing.Color.White
        Me.Lib_Domaine_Comepence_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Domaine_Comepence_txt.Location = New System.Drawing.Point(310, 13)
        Me.Lib_Domaine_Comepence_txt.MaxLength = 50
        Me.Lib_Domaine_Comepence_txt.Multiline = False
        Me.Lib_Domaine_Comepence_txt.Name = "Lib_Domaine_Comepence_txt"
        Me.Lib_Domaine_Comepence_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Domaine_Comepence_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Domaine_Comepence_txt.ReadOnly = False
        Me.Lib_Domaine_Comepence_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Domaine_Comepence_txt.SelectionStart = 0
        Me.Lib_Domaine_Comepence_txt.Size = New System.Drawing.Size(344, 21)
        Me.Lib_Domaine_Comepence_txt.TabIndex = 204
        Me.Lib_Domaine_Comepence_txt.Tag = ""
        Me.Lib_Domaine_Comepence_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Domaine_Comepence_txt.UseSystemPasswordChar = False
        '
        'Domaine_Comepence_txt
        '
        Me.Domaine_Comepence_txt.BackColor = System.Drawing.SystemColors.Control
        Me.Domaine_Comepence_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Domaine_Comepence_txt.Location = New System.Drawing.Point(163, 13)
        Me.Domaine_Comepence_txt.MaxLength = 50
        Me.Domaine_Comepence_txt.Multiline = False
        Me.Domaine_Comepence_txt.Name = "Domaine_Comepence_txt"
        Me.Domaine_Comepence_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Domaine_Comepence_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Domaine_Comepence_txt.ReadOnly = True
        Me.Domaine_Comepence_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Domaine_Comepence_txt.SelectionStart = 0
        Me.Domaine_Comepence_txt.Size = New System.Drawing.Size(141, 21)
        Me.Domaine_Comepence_txt.TabIndex = 203
        Me.Domaine_Comepence_txt.Tag = ""
        Me.Domaine_Comepence_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Domaine_Comepence_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(3, 15)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(157, 16)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "Domaines de compétences"
        '
        'Grd
        Me.Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd.ColumnHeadersHeight = 30
        Me.Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowId, Me.Typ_Formation, Me.Genre_Formation})
        Me.Grd.ContextMenuStrip = Me.CntScripts
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.EnableHeadersVisualStyles = False
        Me.Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd.Location = New System.Drawing.Point(0, 42)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grd.Size = New System.Drawing.Size(885, 408)
        Me.Grd.TabIndex = 219
        '
        'RowId
        '
        Me.RowId.HeaderText = "RowId"
        Me.RowId.Name = "RowId"
        Me.RowId.Visible = False
        Me.RowId.Width = 63
        '
        'Typ_Formation
        '
        Me.Typ_Formation.HeaderText = "Type de formation"
        Me.Typ_Formation.MaxInputLength = 499
        Me.Typ_Formation.MinimumWidth = 250
        Me.Typ_Formation.Name = "Typ_Formation"
        Me.Typ_Formation.Width = 250
        '
        'Genre_Formation
        '
        Me.Genre_Formation.HeaderText = "Genre de formation"
        Me.Genre_Formation.MinimumWidth = 200
        Me.Genre_Formation.Name = "Genre_Formation"
        Me.Genre_Formation.Width = 200
        '
        'Formation_Types
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(885, 450)
        Me.Controls.Add(Me.Grd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Formation_Types"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage des types de formations"
        Me.CntScripts.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CntScripts As ContextMenuStrip
    Friend WithEvents SupprimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Lib_Domaine_Comepence_txt As ud_TextBox
    Friend WithEvents Domaine_Comepence_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Grd As ud_Grd
    Friend WithEvents RowId As DataGridViewTextBoxColumn
    Friend WithEvents Typ_Formation As DataGridViewTextBoxColumn
    Friend WithEvents Genre_Formation As DataGridViewComboBoxColumn
End Class
