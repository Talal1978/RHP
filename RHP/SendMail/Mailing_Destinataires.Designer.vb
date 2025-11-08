<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mailing_Destinataires
    inherits Ecran

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grd_Destinataire = New RHP.ud_Grd()
        Me.Civilite = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prenom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Tiers = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Cod_Tiers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tiers = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Fonction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_Destinataire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Grd_Destinataire, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grd_Destinataire
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Grd_Destinataire.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Destinataire.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Destinataire.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Destinataire.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Destinataire.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Destinataire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Destinataire.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Civilite, Me.Nom, Me.Prenom, Me.Email, Me.Typ_Tiers, Me.Cod_Tiers, Me.Tiers, Me.Fonction, Me.id_Destinataire})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Destinataire.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Destinataire.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Destinataire.EnableHeadersVisualStyles = False
        Me.Grd_Destinataire.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grd_Destinataire.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Destinataire.Name = "Grd_Destinataire"
        Me.Grd_Destinataire.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Destinataire.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grd_Destinataire.Size = New System.Drawing.Size(885, 545)
        Me.Grd_Destinataire.TabIndex = 84
        '
        'Civilite
        '
        Me.Civilite.HeaderText = "Civilité"
        Me.Civilite.Name = "Civilite"
        Me.Civilite.Width = 80
        '
        'Nom
        '
        Me.Nom.HeaderText = "Nom"
        Me.Nom.Name = "Nom"
        Me.Nom.Width = 150
        '
        'Prenom
        '
        Me.Prenom.HeaderText = "Prenom"
        Me.Prenom.Name = "Prenom"
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.Width = 150
        '
        'Typ_Tiers
        '
        Me.Typ_Tiers.HeaderText = "Type Tiers"
        Me.Typ_Tiers.Name = "Typ_Tiers"
        Me.Typ_Tiers.Width = 80
        '
        'Cod_Tiers
        '
        Me.Cod_Tiers.HeaderText = "Code"
        Me.Cod_Tiers.Name = "Cod_Tiers"
        Me.Cod_Tiers.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cod_Tiers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Tiers
        '
        Me.Tiers.HeaderText = "Tiers"
        Me.Tiers.Name = "Tiers"
        Me.Tiers.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tiers.Width = 150
        '
        'Fonction
        '
        Me.Fonction.HeaderText = "Fonction"
        Me.Fonction.Name = "Fonction"
        Me.Fonction.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fonction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Fonction.Width = 150
        '
        'id_Destinataire
        '
        Me.id_Destinataire.HeaderText = "id_Destinataire"
        Me.id_Destinataire.Name = "id_Destinataire"
        Me.id_Destinataire.Visible = False
        '
        'Mailing_Destinataires
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(885, 545)
        Me.Controls.Add(Me.Grd_Destinataire)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "Mailing_Destinataires"
        Me.Tag = "ECR"
        Me.Text = "Liste des destinataires"
        CType(Me.Grd_Destinataire, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grd_Destinataire As ud_Grd
    Friend WithEvents Civilite As DataGridViewComboBoxColumn
    Friend WithEvents Nom As DataGridViewTextBoxColumn
    Friend WithEvents Prenom As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Typ_Tiers As DataGridViewComboBoxColumn
    Friend WithEvents Cod_Tiers As DataGridViewTextBoxColumn
    Friend WithEvents Tiers As DataGridViewLinkColumn
    Friend WithEvents Fonction As DataGridViewTextBoxColumn
    Friend WithEvents id_Destinataire As DataGridViewTextBoxColumn
End Class
