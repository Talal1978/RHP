<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RH_Agent_Donnees_Diverses_Parametrage
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Notes_GRD = New RHP.ud_Grd()
        Me.Cod_Donnee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text_Donnee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Donnee = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Menu_Donnee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variable_Paie = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Rang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Notes_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Notes_GRD
        '
        Me.Notes_GRD.AfficherLesEntetesLignes = True
        Me.Notes_GRD.AlternerLesLignes = False
        Me.Notes_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Notes_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Notes_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Notes_GRD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Notes_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Notes_GRD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Donnee, Me.Text_Donnee, Me.Typ_Donnee, Me.Menu_Donnee, Me.Variable_Paie, Me.Rang})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Notes_GRD.DefaultCellStyle = DataGridViewCellStyle2
        Me.Notes_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Notes_GRD.EnableHeadersVisualStyles = False
        Me.Notes_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.Notes_GRD.Location = New System.Drawing.Point(0, 0)
        Me.Notes_GRD.Margin = New System.Windows.Forms.Padding(4)
        Me.Notes_GRD.Name = "Notes_GRD"
        Me.Notes_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Notes_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Notes_GRD.RowHeadersWidth = 51
        Me.Notes_GRD.Size = New System.Drawing.Size(1215, 621)
        Me.Notes_GRD.TabIndex = 3
        Me.Notes_GRD.Tag = "NC"
        '
        'Cod_Donnee
        '
        Me.Cod_Donnee.HeaderText = "Code"
        Me.Cod_Donnee.MaxInputLength = 50
        Me.Cod_Donnee.MinimumWidth = 6
        Me.Cod_Donnee.Name = "Cod_Donnee"
        Me.Cod_Donnee.Width = 125
        '
        'Text_Donnee
        '
        Me.Text_Donnee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Text_Donnee.HeaderText = "Texte Note"
        Me.Text_Donnee.MinimumWidth = 350
        Me.Text_Donnee.Name = "Text_Donnee"
        Me.Text_Donnee.Width = 350
        '
        'Typ_Donnee
        '
        Me.Typ_Donnee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Typ_Donnee.HeaderText = "Type Note"
        Me.Typ_Donnee.MinimumWidth = 6
        Me.Typ_Donnee.Name = "Typ_Donnee"
        Me.Typ_Donnee.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Typ_Donnee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Typ_Donnee.Width = 116
        '
        'Menu_Donnee
        '
        Me.Menu_Donnee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Menu_Donnee.HeaderText = "N° de Menu"
        Me.Menu_Donnee.MinimumWidth = 6
        Me.Menu_Donnee.Name = "Menu_Donnee"
        Me.Menu_Donnee.ReadOnly = True
        Me.Menu_Donnee.Width = 130
        '
        'Variable_Paie
        '
        Me.Variable_Paie.HeaderText = "Géré en paie"
        Me.Variable_Paie.MinimumWidth = 6
        Me.Variable_Paie.Name = "Variable_Paie"
        Me.Variable_Paie.Width = 125
        '
        'Rang
        '
        Me.Rang.HeaderText = "Rang"
        Me.Rang.MaxInputLength = 10
        Me.Rang.MinimumWidth = 6
        Me.Rang.Name = "Rang"
        Me.Rang.Width = 50
        '
        'RH_Agent_Donnees_Diverses_Parametrage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1215, 621)
        Me.Controls.Add(Me.Notes_GRD)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RH_Agent_Donnees_Diverses_Parametrage"
        Me.Tag = "ECR"
        Me.Text = "Définition des données diverses de l'agent"
        CType(Me.Notes_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Notes_GRD As ud_Grd
    Friend WithEvents Cod_Donnee As DataGridViewTextBoxColumn
    Friend WithEvents Text_Donnee As DataGridViewTextBoxColumn
    Friend WithEvents Typ_Donnee As DataGridViewComboBoxColumn
    Friend WithEvents Menu_Donnee As DataGridViewTextBoxColumn
    Friend WithEvents Variable_Paie As DataGridViewCheckBoxColumn
    Friend WithEvents Rang As DataGridViewTextBoxColumn
End Class
