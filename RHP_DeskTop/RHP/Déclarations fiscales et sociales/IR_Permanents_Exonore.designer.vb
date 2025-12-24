Imports System.ComponentModel
Imports System.Runtime.CompilerServices

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IR_Permanents_Exonore
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grd = New RHP.ud_Grd()
        Me.Clef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Matricule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.refNatureElementExonere = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.montantExonere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contenu_Grp = New System.Windows.Forms.GroupBox()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Contenu_Grp.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grd
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Clef, Me.Matricule, Me.refNatureElementExonere, Me.montantExonere})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd.DefaultCellStyle = DataGridViewCellStyle6
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.EnableHeadersVisualStyles = False
        Me.Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd.Location = New System.Drawing.Point(3, 16)
        Me.Grd.Name = "Grd"
        Me.Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grd.Size = New System.Drawing.Size(961, 661)
        Me.Grd.TabIndex = 0
        '
        'Clef
        '
        Me.Clef.HeaderText = "Clef"
        Me.Clef.Name = "Clef"
        Me.Clef.Visible = False
        '
        'Matricule
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Matricule.DefaultCellStyle = DataGridViewCellStyle3
        Me.Matricule.HeaderText = "Matricule"
        Me.Matricule.MaxInputLength = 100
        Me.Matricule.Name = "Matricule"
        '
        'refNatureElementExonere
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.refNatureElementExonere.DefaultCellStyle = DataGridViewCellStyle4
        Me.refNatureElementExonere.HeaderText = "Nature Element Exonere"
        Me.refNatureElementExonere.Name = "refNatureElementExonere"
        Me.refNatureElementExonere.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.refNatureElementExonere.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.refNatureElementExonere.Width = 350
        '
        'montantExonere
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.montantExonere.DefaultCellStyle = DataGridViewCellStyle5
        Me.montantExonere.HeaderText = "Montant Exonere"
        Me.montantExonere.Name = "montantExonere"
        Me.montantExonere.Width = 200
        '
        'Contenu_Grp
        '
        Me.Contenu_Grp.Controls.Add(Me.Grd)
        Me.Contenu_Grp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Contenu_Grp.Location = New System.Drawing.Point(0, 0)
        Me.Contenu_Grp.Name = "Contenu_Grp"
        Me.Contenu_Grp.Size = New System.Drawing.Size(967, 680)
        Me.Contenu_Grp.TabIndex = 1
        Me.Contenu_Grp.TabStop = False
        Me.Contenu_Grp.Text = "Année de la déclaration : "
        '
        'IR_Permanents_Exonore
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(967, 680)
        Me.Controls.Add(Me.Contenu_Grp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IR_Permanents_Exonore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Eléments exonérés du personnel permanent"
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Contenu_Grp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grd As ud_Grd
    Friend WithEvents Clef As DataGridViewTextBoxColumn
    Friend WithEvents Matricule As DataGridViewTextBoxColumn
    Friend WithEvents refNatureElementExonere As DataGridViewComboBoxColumn
    Friend WithEvents montantExonere As DataGridViewTextBoxColumn
    Friend WithEvents Contenu_Grp As GroupBox
End Class
