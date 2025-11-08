<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Org_Evolution_Carriere
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
        Me.AfficherCode_chk = New RHP.ud_CheckBox()
        Me.Matricule_ = New System.Windows.Forms.LinkLabel()
        Me.Matricule_Text = New RHP.ud_TextBox()
        Me.Nom_Agent_Text = New RHP.ud_TextBox()
        Me.Ges_Pie_Clt_GRD = New RHP.ud_Grd()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.Ges_Pie_Clt_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AfficherCode_chk
        '
        Me.AfficherCode_chk.AutoSize = True
        Me.AfficherCode_chk.Checked = True
        Me.AfficherCode_chk.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.AfficherCode_chk.Location = New System.Drawing.Point(81, 41)
        Me.AfficherCode_chk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AfficherCode_chk.MaximumSize = New System.Drawing.Size(0, 25)
        Me.AfficherCode_chk.MinimumSize = New System.Drawing.Size(117, 25)
        Me.AfficherCode_chk.Name = "AfficherCode_chk"
        Me.AfficherCode_chk.Size = New System.Drawing.Size(117, 25)
        Me.AfficherCode_chk.TabIndex = 209
        Me.AfficherCode_chk.Text = "Afficher les codes"
        '
        'Matricule_
        '
        Me.Matricule_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.AutoSize = True
        Me.Matricule_.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Matricule_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Matricule_.Location = New System.Drawing.Point(11, 20)
        Me.Matricule_.Name = "Matricule_"
        Me.Matricule_.Size = New System.Drawing.Size(59, 16)
        Me.Matricule_.TabIndex = 207
        Me.Matricule_.TabStop = True
        Me.Matricule_.Tag = ""
        Me.Matricule_.Text = "Matricule"
        '
        'Matricule_Text
        '
        Me.Matricule_Text.AccessibleDescription = "A"
        Me.Matricule_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Matricule_Text.Location = New System.Drawing.Point(80, 17)
        Me.Matricule_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Matricule_Text.MaxLength = 32767
        Me.Matricule_Text.Multiline = False
        Me.Matricule_Text.Name = "Matricule_Text"
        Me.Matricule_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Matricule_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Matricule_Text.ReadOnly = True
        Me.Matricule_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Matricule_Text.SelectionStart = 0
        Me.Matricule_Text.Size = New System.Drawing.Size(121, 21)
        Me.Matricule_Text.TabIndex = 206
        Me.Matricule_Text.TabStop = False
        Me.Matricule_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Matricule_Text.UseSystemPasswordChar = False
        '
        'Nom_Agent_Text
        '
        Me.Nom_Agent_Text.AccessibleDescription = "A"
        Me.Nom_Agent_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Agent_Text.Location = New System.Drawing.Point(204, 17)
        Me.Nom_Agent_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Agent_Text.MaxLength = 32767
        Me.Nom_Agent_Text.Multiline = False
        Me.Nom_Agent_Text.Name = "Nom_Agent_Text"
        Me.Nom_Agent_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Agent_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Agent_Text.ReadOnly = True
        Me.Nom_Agent_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Agent_Text.SelectionStart = 0
        Me.Nom_Agent_Text.Size = New System.Drawing.Size(565, 21)
        Me.Nom_Agent_Text.TabIndex = 208
        Me.Nom_Agent_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Agent_Text.UseSystemPasswordChar = False
        '
        'Ges_Pie_Clt_GRD
        '
        Me.Ges_Pie_Clt_GRD.AllowUserToAddRows = False
        Me.Ges_Pie_Clt_GRD.AllowUserToDeleteRows = False
        Me.Ges_Pie_Clt_GRD.AllowUserToOrderColumns = True
        Me.Ges_Pie_Clt_GRD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Ges_Pie_Clt_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Ges_Pie_Clt_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ges_Pie_Clt_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Ges_Pie_Clt_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Ges_Pie_Clt_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ges_Pie_Clt_GRD.EnableHeadersVisualStyles = False
        Me.Ges_Pie_Clt_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Ges_Pie_Clt_GRD.Location = New System.Drawing.Point(0, 75)
        Me.Ges_Pie_Clt_GRD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Ges_Pie_Clt_GRD.Name = "Ges_Pie_Clt_GRD"
        Me.Ges_Pie_Clt_GRD.ReadOnly = True
        Me.Ges_Pie_Clt_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Ges_Pie_Clt_GRD.Size = New System.Drawing.Size(811, 479)
        Me.Ges_Pie_Clt_GRD.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.AfficherCode_chk)
        Me.Panel1.Controls.Add(Me.Nom_Agent_Text)
        Me.Panel1.Controls.Add(Me.Matricule_)
        Me.Panel1.Controls.Add(Me.Matricule_Text)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(811, 75)
        Me.Panel1.TabIndex = 4
        '
        'Org_Evolution_Carriere
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(811, 554)
        Me.Controls.Add(Me.Ges_Pie_Clt_GRD)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Org_Evolution_Carriere"
        Me.Tag = "ECR"
        Me.Text = "Evolution de carrière"
        CType(Me.Ges_Pie_Clt_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Matricule_ As LinkLabel
    Friend WithEvents Matricule_Text As ud_TextBox
    Friend WithEvents Nom_Agent_Text As ud_TextBox
    Friend WithEvents Ges_Pie_Clt_GRD As ud_Grd
    Friend WithEvents AfficherCode_chk As ud_CheckBox
    Friend WithEvents Panel1 As Panel
End Class
