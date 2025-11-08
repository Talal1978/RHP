<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Org_FichePoste
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
        Me.header = New System.Windows.Forms.Panel()
        Me.Matricule_txt = New ud_TextBox()
        Me.Nom_Agent_Text = New ud_TextBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Grade_txt = New ud_TextBox()
        Me.Cod_Grade_txt = New ud_TextBox()
        Me.Lib_Poste_txt = New ud_TextBox()
        Me.Cod_Poste_txt = New ud_TextBox()
        Me.Lib_Entite_txt = New ud_TextBox()
        Me.Cod_Entite_txt = New ud_TextBox()
        Me.Titre_txt = New ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.JobDescription_rtb = New RHP.ud_RT()
        Me.header.SuspendLayout()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.Controls.Add(Me.Matricule_txt)
        Me.header.Controls.Add(Me.Nom_Agent_Text)
        Me.header.Controls.Add(Me.Matricule_)
        Me.header.Controls.Add(Me.Lib_Grade_txt)
        Me.header.Controls.Add(Me.Cod_Grade_txt)
        Me.header.Controls.Add(Me.Lib_Poste_txt)
        Me.header.Controls.Add(Me.Cod_Poste_txt)
        Me.header.Controls.Add(Me.Lib_Entite_txt)
        Me.header.Controls.Add(Me.Cod_Entite_txt)
        Me.header.Controls.Add(Me.Titre_txt)
        Me.header.Controls.Add(Me.Label1)
        Me.header.Controls.Add(Me.Label2)
        Me.header.Controls.Add(Me.Label3)
        Me.header.Controls.Add(Me.Label4)
        Me.header.Dock = System.Windows.Forms.DockStyle.Top
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1316, 92)
        Me.header.TabIndex = 0
        '
        'Matricule_txt
        '
        Me.Matricule_txt.AccessibleDescription = "A"
        Me.Matricule_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Matricule_txt.Location = New System.Drawing.Point(70, 13)
        Me.Matricule_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Matricule_txt.Name = "Matricule_txt"
        Me.Matricule_txt.ReadOnly = True
        Me.Matricule_txt.Size = New System.Drawing.Size(121, 20)
        Me.Matricule_txt.TabIndex = 251
        Me.Matricule_txt.TabStop = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(193, 13)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(373, 20)
        Me.Nom_Agent_Text.TabIndex = 253
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(17, 17)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(50, 13)
        Me.Matricule_.TabIndex = 252
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = "SN"
        Me.Matricule_.Text = "Matricule"
        '
        'Lib_Grade_txt
        '
        Me.Lib_Grade_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Lib_Grade_txt.Location = New System.Drawing.Point(193, 63)
        Me.Lib_Grade_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Grade_txt.MaxLength = 50
        Me.Lib_Grade_txt.Name = "Lib_Grade_txt"
        Me.Lib_Grade_txt.ReadOnly = True
        Me.Lib_Grade_txt.Size = New System.Drawing.Size(373, 20)
        Me.Lib_Grade_txt.TabIndex = 242
        '
        'Cod_Grade_txt
        '
        Me.Cod_Grade_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Cod_Grade_txt.Location = New System.Drawing.Point(70, 63)
        Me.Cod_Grade_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Grade_txt.MaxLength = 6
        Me.Cod_Grade_txt.Name = "Cod_Grade_txt"
        Me.Cod_Grade_txt.ReadOnly = True
        Me.Cod_Grade_txt.Size = New System.Drawing.Size(121, 20)
        Me.Cod_Grade_txt.TabIndex = 243
        '
        'Lib_Poste_txt
        '
        Me.Lib_Poste_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Lib_Poste_txt.Location = New System.Drawing.Point(193, 38)
        Me.Lib_Poste_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Poste_txt.MaxLength = 50
        Me.Lib_Poste_txt.Name = "Lib_Poste_txt"
        Me.Lib_Poste_txt.ReadOnly = True
        Me.Lib_Poste_txt.Size = New System.Drawing.Size(373, 20)
        Me.Lib_Poste_txt.TabIndex = 240
        '
        'Cod_Poste_txt
        '
        Me.Cod_Poste_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Cod_Poste_txt.Location = New System.Drawing.Point(70, 38)
        Me.Cod_Poste_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Poste_txt.MaxLength = 6
        Me.Cod_Poste_txt.Name = "Cod_Poste_txt"
        Me.Cod_Poste_txt.ReadOnly = True
        Me.Cod_Poste_txt.Size = New System.Drawing.Size(121, 20)
        Me.Cod_Poste_txt.TabIndex = 241
        '
        'Lib_Entite_txt
        '
        Me.Lib_Entite_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Lib_Entite_txt.Location = New System.Drawing.Point(709, 13)
        Me.Lib_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Entite_txt.MaxLength = 50
        Me.Lib_Entite_txt.Name = "Lib_Entite_txt"
        Me.Lib_Entite_txt.ReadOnly = True
        Me.Lib_Entite_txt.Size = New System.Drawing.Size(403, 20)
        Me.Lib_Entite_txt.TabIndex = 244
        '
        'Cod_Entite_txt
        '
        Me.Cod_Entite_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Cod_Entite_txt.Location = New System.Drawing.Point(616, 13)
        Me.Cod_Entite_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Entite_txt.MaxLength = 6
        Me.Cod_Entite_txt.Name = "Cod_Entite_txt"
        Me.Cod_Entite_txt.ReadOnly = True
        Me.Cod_Entite_txt.Size = New System.Drawing.Size(90, 20)
        Me.Cod_Entite_txt.TabIndex = 245
        '
        'Titre_txt
        '
        Me.Titre_txt.AccessibleDescription = "A"
        Me.Titre_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Titre_txt.Location = New System.Drawing.Point(616, 36)
        Me.Titre_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Titre_txt.MaxLength = 490
        Me.Titre_txt.Multiline = True
        Me.Titre_txt.Name = "Titre_txt"
        Me.Titre_txt.ReadOnly = True
        Me.Titre_txt.Size = New System.Drawing.Size(496, 47)
        Me.Titre_txt.TabIndex = 246
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(584, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 247
        Me.Label1.Text = "Titre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 248
        Me.Label2.Text = "Poste"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 249
        Me.Label3.Text = "Grade"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(579, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 250
        Me.Label4.Text = "Entité"
        '
        'JobDescription_rtb
        '
        Me.JobDescription_rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JobDescription_rtb.Location = New System.Drawing.Point(0, 92)
        Me.JobDescription_rtb.Margin = New System.Windows.Forms.Padding(4)
        Me.JobDescription_rtb.Name = "JobDescription_rtb"
        Me.JobDescription_rtb.Size = New System.Drawing.Size(1316, 488)
        Me.JobDescription_rtb.TabIndex = 1
        '
        'Org_FichePoste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1316, 580)
        Me.Controls.Add(Me.JobDescription_rtb)
        Me.Controls.Add(Me.header)
        Me.Name = "Org_FichePoste"
        Me.Tag = "ECR"
        Me.Text = "Fiche de poste"
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents header As Panel
    Friend WithEvents JobDescription_rtb As ud_RT
    Friend WithEvents Lib_Grade_txt As ud_TextBox
    Friend WithEvents Cod_Grade_txt As ud_TextBox
    Friend WithEvents Lib_Poste_txt As ud_TextBox
    Friend WithEvents Cod_Poste_txt As ud_TextBox
    Friend WithEvents Lib_Entite_txt As ud_TextBox
    Friend WithEvents Cod_Entite_txt As ud_TextBox
    Friend WithEvents Titre_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Matricule_txt As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Matricule_ As LinkLabel
End Class
