<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Parametrage_Declarations_Fiscales_Sociales
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
        Me.Grp_ED = New System.Windows.Forms.GroupBox()
        Me.Pnl_ED = New System.Windows.Forms.Panel()
        Me.entete_Grp = New System.Windows.Forms.GroupBox()
        Me.zoom_txt = New ud_TextBox()
        Me.Filtre_txt = New RHP.ud_TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SélectionnerUnChampsDeFiltreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Saisie_Libre_chk = New RHP.ud_CheckBox()
        Me.Cod_Declaration_txt = New RHP.ud_TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Lib_Declaration_txt = New RHP.ud_TextBox()
        Me.Grp_ED.SuspendLayout()
        Me.entete_Grp.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grp_ED
        '
        Me.Grp_ED.Controls.Add(Me.Pnl_ED)
        Me.Grp_ED.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grp_ED.Location = New System.Drawing.Point(0, 118)
        Me.Grp_ED.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grp_ED.Name = "Grp_ED"
        Me.Grp_ED.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grp_ED.Size = New System.Drawing.Size(999, 577)
        Me.Grp_ED.TabIndex = 0
        Me.Grp_ED.TabStop = False
        Me.Grp_ED.Text = "Eléments de la déclaration "
        '
        'Pnl_ED
        '
        Me.Pnl_ED.AutoScroll = True
        Me.Pnl_ED.BackColor = System.Drawing.Color.White
        Me.Pnl_ED.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_ED.Location = New System.Drawing.Point(3, 21)
        Me.Pnl_ED.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Pnl_ED.Name = "Pnl_ED"
        Me.Pnl_ED.Size = New System.Drawing.Size(993, 552)
        Me.Pnl_ED.TabIndex = 1
        '
        'entete_Grp
        '
        Me.entete_Grp.Controls.Add(Me.zoom_txt)
        Me.entete_Grp.Controls.Add(Me.Filtre_txt)
        Me.entete_Grp.Controls.Add(Me.Label1)
        Me.entete_Grp.Controls.Add(Me.Saisie_Libre_chk)
        Me.entete_Grp.Controls.Add(Me.Cod_Declaration_txt)
        Me.entete_Grp.Controls.Add(Me.LinkLabel1)
        Me.entete_Grp.Controls.Add(Me.Lib_Declaration_txt)
        Me.entete_Grp.Dock = System.Windows.Forms.DockStyle.Top
        Me.entete_Grp.Location = New System.Drawing.Point(0, 0)
        Me.entete_Grp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.entete_Grp.Name = "entete_Grp"
        Me.entete_Grp.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.entete_Grp.Size = New System.Drawing.Size(999, 118)
        Me.entete_Grp.TabIndex = 0
        Me.entete_Grp.TabStop = False
        '
        'zoom_txt
        '
        Me.zoom_txt.Location = New System.Drawing.Point(107, 44)
        Me.zoom_txt.Name = "zoom_txt"
        Me.zoom_txt.Size = New System.Drawing.Size(1, 24)
        Me.zoom_txt.TabIndex = 24
        Me.zoom_txt.Visible = False
        '
        'Filtre_txt
        '
        Me.Filtre_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Filtre_txt.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Filtre_txt.Location = New System.Drawing.Point(140, 44)
        Me.Filtre_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Filtre_txt.MaxLength = 32767
        Me.Filtre_txt.Multiline = True
        Me.Filtre_txt.Name = "Filtre_txt"
        Me.Filtre_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Filtre_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Filtre_txt.ReadOnly = False
        Me.Filtre_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Filtre_txt.SelectionStart = 0
        Me.Filtre_txt.Size = New System.Drawing.Size(563, 66)
        Me.Filtre_txt.TabIndex = 23
        Me.Filtre_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Filtre_txt.UseSystemPasswordChar = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SélectionnerUnChampsDeFiltreToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(296, 30)
        '
        'SélectionnerUnChampsDeFiltreToolStripMenuItem
        '
        Me.SélectionnerUnChampsDeFiltreToolStripMenuItem.Image = Global.RHP.My.Resources.Resources.btn_filter
        Me.SélectionnerUnChampsDeFiltreToolStripMenuItem.Name = "SélectionnerUnChampsDeFiltreToolStripMenuItem"
        Me.SélectionnerUnChampsDeFiltreToolStripMenuItem.Size = New System.Drawing.Size(295, 26)
        Me.SélectionnerUnChampsDeFiltreToolStripMenuItem.Text = "Sélectionner un champs de filtre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 19)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Expression de filtre"
        '
        'Saisie_Libre_chk
        '
        Me.Saisie_Libre_chk.AutoSize = True
        Me.Saisie_Libre_chk.Checked = True
        Me.Saisie_Libre_chk.Location = New System.Drawing.Point(718, 40)
        Me.Saisie_Libre_chk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Saisie_Libre_chk.MaximumSize = New System.Drawing.Size(0, 30)
        Me.Saisie_Libre_chk.MinimumSize = New System.Drawing.Size(100, 20)
        Me.Saisie_Libre_chk.Name = "Saisie_Libre_chk"
        Me.Saisie_Libre_chk.Size = New System.Drawing.Size(224, 30)
        Me.Saisie_Libre_chk.TabIndex = 21
        Me.Saisie_Libre_chk.Text = "Saisie libre de la déclaration"
        '
        'Cod_Declaration_txt
        '
        Me.Cod_Declaration_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Declaration_txt.ContextMenuStrip = Nothing
        Me.Cod_Declaration_txt.Location = New System.Drawing.Point(140, 15)
        Me.Cod_Declaration_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Declaration_txt.MaxLength = 10
        Me.Cod_Declaration_txt.Multiline = False
        Me.Cod_Declaration_txt.Name = "Cod_Declaration_txt"
        Me.Cod_Declaration_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Declaration_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Declaration_txt.ReadOnly = True
        Me.Cod_Declaration_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Declaration_txt.SelectionStart = 0
        Me.Cod_Declaration_txt.Size = New System.Drawing.Size(128, 21)
        Me.Cod_Declaration_txt.TabIndex = 18
        Me.Cod_Declaration_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Declaration_txt.UseSystemPasswordChar = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(43, 15)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(94, 19)
        Me.LinkLabel1.TabIndex = 20
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Déclaration "
        '
        'Lib_Declaration_txt
        '
        Me.Lib_Declaration_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Declaration_txt.ContextMenuStrip = Nothing
        Me.Lib_Declaration_txt.Location = New System.Drawing.Point(271, 15)
        Me.Lib_Declaration_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Declaration_txt.MaxLength = 32767
        Me.Lib_Declaration_txt.Multiline = False
        Me.Lib_Declaration_txt.Name = "Lib_Declaration_txt"
        Me.Lib_Declaration_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Declaration_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Declaration_txt.ReadOnly = True
        Me.Lib_Declaration_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Declaration_txt.SelectionStart = 0
        Me.Lib_Declaration_txt.Size = New System.Drawing.Size(623, 21)
        Me.Lib_Declaration_txt.TabIndex = 19
        Me.Lib_Declaration_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Declaration_txt.UseSystemPasswordChar = False
        '
        'RH_Parametrage_Declarations_Fiscales_Sociales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(999, 695)
        Me.Controls.Add(Me.Grp_ED)
        Me.Controls.Add(Me.entete_Grp)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "RH_Parametrage_Declarations_Fiscales_Sociales"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage des déclarations fiscales et sociales"
        Me.Grp_ED.ResumeLayout(False)
        Me.entete_Grp.ResumeLayout(False)
        Me.entete_Grp.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents entete_Grp As System.Windows.Forms.GroupBox
    Friend WithEvents Grp_ED As GroupBox
    Friend WithEvents Cod_Declaration_txt As ud_TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Lib_Declaration_txt As ud_TextBox
    Friend WithEvents Pnl_ED As Panel
    Friend WithEvents Saisie_Libre_chk As ud_CheckBox
    Friend WithEvents Filtre_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SélectionnerUnChampsDeFiltreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents zoom_txt as ud_TextBox
End Class
