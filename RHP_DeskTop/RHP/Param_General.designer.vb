<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Param_General
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
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Liste des paramètres de configuration générale")
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Param_TreeView = New System.Windows.Forms.TreeView()
        Me.ParamLabel = New System.Windows.Forms.Label()
        Me.Param_GRD = New RHP.ud_Grd()
        Me.Cod_Param = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Libelle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Param_General = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mnu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Param_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.Controls.Add(Me.ButtonX1, 0, 0)
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(200, 100)
        Me.Personnal_pnl.TabIndex = 0
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX1.Location = New System.Drawing.Point(16, 38)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(67, 23)
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.Text = "OK"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Location = New System.Drawing.Point(36, 3)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(28, 8)
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "Annuler"
        '
        'Param_TreeView
        '
        Me.Param_TreeView.Dock = System.Windows.Forms.DockStyle.Left
        Me.Param_TreeView.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Param_TreeView.Location = New System.Drawing.Point(0, 0)
        Me.Param_TreeView.Name = "Param_TreeView"
        TreeNode2.Name = "Param"
        TreeNode2.Text = "Liste des paramètres de configuration générale"
        Me.Param_TreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.Param_TreeView.Size = New System.Drawing.Size(321, 541)
        Me.Param_TreeView.TabIndex = 5
        '
        'ParamLabel
        '
        Me.ParamLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ParamLabel.Location = New System.Drawing.Point(321, 0)
        Me.ParamLabel.Name = "ParamLabel"
        Me.ParamLabel.Size = New System.Drawing.Size(642, 25)
        Me.ParamLabel.TabIndex = 0
        Me.ParamLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Param_GRD
        '
        Me.Param_GRD.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Param_GRD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Param_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Param_GRD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Param_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Param_GRD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Param_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Param_GRD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Param, Me.Libelle, Me.Valeur, Me.Type, Me.Typ_Param_General, Me.Mnu})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Param_GRD.DefaultCellStyle = DataGridViewCellStyle7
        Me.Param_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Param_GRD.EnableHeadersVisualStyles = False
        Me.Param_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Param_GRD.Location = New System.Drawing.Point(321, 25)
        Me.Param_GRD.Name = "Param_GRD"
        Me.Param_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Param_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Param_GRD.RowHeadersVisible = False
        Me.Param_GRD.Size = New System.Drawing.Size(642, 516)
        Me.Param_GRD.TabIndex = 5
        '
        'Cod_Param
        '
        Me.Cod_Param.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Cod_Param.HeaderText = "Cod_Param"
        Me.Cod_Param.Name = "Cod_Param"
        Me.Cod_Param.ReadOnly = True
        Me.Cod_Param.Visible = False
        '
        'Libelle
        '
        Me.Libelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Libelle.HeaderText = "Paramètre"
        Me.Libelle.MinimumWidth = 200
        Me.Libelle.Name = "Libelle"
        Me.Libelle.ReadOnly = True
        Me.Libelle.Width = 200
        '
        'Valeur
        '
        Me.Valeur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.Name = "Valeur"
        Me.Valeur.Width = 66
        '
        'Type
        '
        Me.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Visible = False
        '
        'Typ_Param_General
        '
        Me.Typ_Param_General.HeaderText = "Typ_Param_General"
        Me.Typ_Param_General.Name = "Typ_Param_General"
        Me.Typ_Param_General.Visible = False
        Me.Typ_Param_General.Width = 5
        '
        'Mnu
        '
        Me.Mnu.HeaderText = "Menu"
        Me.Mnu.Name = "Mnu"
        Me.Mnu.Visible = False
        Me.Mnu.Width = 5
        '
        'Param_General
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(963, 541)
        Me.Controls.Add(Me.Param_GRD)
        Me.Controls.Add(Me.ParamLabel)
        Me.Controls.Add(Me.Param_TreeView)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "Param_General"
        Me.Tag = "ECR"
        Me.Text = "Paramètrage général"
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Param_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Param_TreeView As System.Windows.Forms.TreeView
    Friend WithEvents ParamLabel As System.Windows.Forms.Label
    Friend WithEvents Param_GRD As ud_Grd
    Friend WithEvents Cod_Param As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Libelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valeur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Typ_Param_General As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mnu As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
