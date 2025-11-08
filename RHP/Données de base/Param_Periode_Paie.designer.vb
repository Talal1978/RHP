Imports System.Runtime.CompilerServices
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Param_Periode_Paie
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
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Param_Periode_Paie))
        Me.Grille = New RHP.ud_Grd()
        Me.Annee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Periode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pre_Periode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Statut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActDu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActAu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreDu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreAu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Conge_Genere = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SelectedPeriode = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grille
        '
        Me.Grille.AllowUserToAddRows = False
        Me.Grille.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grille.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grille.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grille.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grille.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grille.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grille.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Annee, Me.Periode, Me.Pre_Periode, Me.Statut, Me.ActDu, Me.ActAu, Me.PreDu, Me.PreAu, Me.Conge_Genere, Me.SelectedPeriode})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(56,36,36)
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grille.DefaultCellStyle = DataGridViewCellStyle7
        Me.Grille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grille.EnableHeadersVisualStyles = False
        Me.Grille.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grille.Location = New System.Drawing.Point(0, 0)
        Me.Grille.MultiSelect = False
        Me.Grille.Name = "Grille"
        Me.Grille.ReadOnly = True
        Me.Grille.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grille.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Grille.RowHeadersVisible = False
        Me.Grille.Size = New System.Drawing.Size(813, 509)
        Me.Grille.TabIndex = 7
        '
        'Annee
        '
        Me.Annee.HeaderText = "Année"
        Me.Annee.Name = "Annee"
        Me.Annee.ReadOnly = True
        '
        'Periode
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Periode.DefaultCellStyle = DataGridViewCellStyle3
        Me.Periode.HeaderText = "Pèriode"
        Me.Periode.Name = "Periode"
        Me.Periode.ReadOnly = True
        Me.Periode.Width = 280
        '
        'Pre_Periode
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Pre_Periode.DefaultCellStyle = DataGridViewCellStyle4
        Me.Pre_Periode.HeaderText = "Pèriode Précédente"
        Me.Pre_Periode.Name = "Pre_Periode"
        Me.Pre_Periode.ReadOnly = True
        Me.Pre_Periode.Width = 280
        '
        'Statut
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Statut.DefaultCellStyle = DataGridViewCellStyle5
        Me.Statut.HeaderText = "Statut"
        Me.Statut.Name = "Statut"
        Me.Statut.ReadOnly = True
        Me.Statut.Width = 60
        '
        'ActDu
        '
        Me.ActDu.HeaderText = "ActDu"
        Me.ActDu.Name = "ActDu"
        Me.ActDu.ReadOnly = True
        Me.ActDu.Visible = False
        '
        'ActAu
        '
        Me.ActAu.HeaderText = "ActAu"
        Me.ActAu.Name = "ActAu"
        Me.ActAu.ReadOnly = True
        Me.ActAu.Visible = False
        '
        'PreDu
        '
        Me.PreDu.HeaderText = "PreDu"
        Me.PreDu.Name = "PreDu"
        Me.PreDu.ReadOnly = True
        Me.PreDu.Visible = False
        '
        'PreAu
        '
        Me.PreAu.HeaderText = "PreAu"
        Me.PreAu.Name = "PreAu"
        Me.PreAu.ReadOnly = True
        Me.PreAu.Visible = False
        '
        'Conge_Genere
        '
        Me.Conge_Genere.HeaderText = "Congés générés"
        Me.Conge_Genere.Name = "Conge_Genere"
        Me.Conge_Genere.ReadOnly = True
        '
        'SelectedPeriode
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.NullValue = CType(resources.GetObject("DataGridViewCellStyle6.NullValue"), Object)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.SelectedPeriode.DefaultCellStyle = DataGridViewCellStyle6
        Me.SelectedPeriode.HeaderText = ""
        Me.SelectedPeriode.MinimumWidth = 20
        Me.SelectedPeriode.Name = "SelectedPeriode"
        Me.SelectedPeriode.ReadOnly = True
        Me.SelectedPeriode.Width = 20
        '
        'Param_Periode_Paie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(813, 509)
        Me.Controls.Add(Me.Grille)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Param_Periode_Paie"
        Me.Tag = "ECR"
        Me.Text = "Périodes de paie"
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grille As ud_Grd
    Private Message As Byte
    Friend WithEvents Annee As DataGridViewTextBoxColumn
    Friend WithEvents Periode As DataGridViewTextBoxColumn
    Friend WithEvents Pre_Periode As DataGridViewTextBoxColumn
    Friend WithEvents Statut As DataGridViewTextBoxColumn
    Friend WithEvents ActDu As DataGridViewTextBoxColumn
    Friend WithEvents ActAu As DataGridViewTextBoxColumn
    Friend WithEvents PreDu As DataGridViewTextBoxColumn
    Friend WithEvents PreAu As DataGridViewTextBoxColumn
    Friend WithEvents Conge_Genere As DataGridViewCheckBoxColumn
    Friend WithEvents SelectedPeriode As DataGridViewImageColumn
End Class
