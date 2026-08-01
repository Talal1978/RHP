<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Sante_Param
    Inherits Ecran

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CNDP_txt = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab_Reglement = New System.Windows.Forms.TabPage()
        Me.SplitContainer_R = New System.Windows.Forms.SplitContainer()
        Me.Grd_Reglement = New RHP.ud_Grd()
        Me.Grd_Surcharges = New RHP.ud_Grd()
        Me.Tab_Periodicites = New System.Windows.Forms.TabPage()
        Me.Grd_Periodicites = New RHP.ud_Grd()
        Me.Tab_Intervenants = New System.Windows.Forms.TabPage()
        Me.Grd_Intervenants = New RHP.ud_Grd()
        Me.Tab_Destinataires = New System.Windows.Forms.TabPage()
        Me.Grd_Destinataires = New RHP.ud_Grd()
        Me.Tab_Etapes = New System.Windows.Forms.TabPage()
        Me.Grd_Etapes = New RHP.ud_Grd()
        Me.Tab_Postes = New System.Windows.Forms.TabPage()
        Me.Grd_Postes = New RHP.ud_Grd()
        Me.TabControl1.SuspendLayout()
        Me.Tab_Reglement.SuspendLayout()
        CType(Me.SplitContainer_R, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_R.Panel1.SuspendLayout()
        Me.SplitContainer_R.Panel2.SuspendLayout()
        Me.SplitContainer_R.SuspendLayout()
        CType(Me.Grd_Reglement, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd_Surcharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Periodicites.SuspendLayout()
        CType(Me.Grd_Periodicites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Intervenants.SuspendLayout()
        CType(Me.Grd_Intervenants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Destinataires.SuspendLayout()
        CType(Me.Grd_Destinataires, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Etapes.SuspendLayout()
        CType(Me.Grd_Etapes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Postes.SuspendLayout()
        CType(Me.Grd_Postes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CNDP_txt
        '
        Me.CNDP_txt.Dock = System.Windows.Forms.DockStyle.Top
        Me.CNDP_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CNDP_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.CNDP_txt.Location = New System.Drawing.Point(0, 0)
        Me.CNDP_txt.Name = "CNDP_txt"
        Me.CNDP_txt.Padding = New System.Windows.Forms.Padding(10, 6, 0, 0)
        Me.CNDP_txt.Size = New System.Drawing.Size(1428, 32)
        Me.CNDP_txt.TabIndex = 0
        Me.CNDP_txt.Text = "Autorisation CNDP : ..."
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tab_Reglement)
        Me.TabControl1.Controls.Add(Me.Tab_Periodicites)
        Me.TabControl1.Controls.Add(Me.Tab_Intervenants)
        Me.TabControl1.Controls.Add(Me.Tab_Destinataires)
        Me.TabControl1.Controls.Add(Me.Tab_Etapes)
        Me.TabControl1.Controls.Add(Me.Tab_Postes)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1428, 682)
        Me.TabControl1.TabIndex = 1
        '
        'Tab_Reglement
        '
        Me.Tab_Reglement.Controls.Add(Me.SplitContainer_R)
        Me.Tab_Reglement.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Reglement.Name = "Tab_Reglement"
        Me.Tab_Reglement.Size = New System.Drawing.Size(1420, 650)
        Me.Tab_Reglement.TabIndex = 0
        Me.Tab_Reglement.Text = "Règles réglementaires"
        Me.Tab_Reglement.UseVisualStyleBackColor = True
        '
        'SplitContainer_R
        '
        Me.SplitContainer_R.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_R.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_R.Name = "SplitContainer_R"
        Me.SplitContainer_R.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_R.Panel1
        '
        Me.SplitContainer_R.Panel1.Controls.Add(Me.Grd_Reglement)
        '
        'SplitContainer_R.Panel2
        '
        Me.SplitContainer_R.Panel2.Controls.Add(Me.Grd_Surcharges)
        Me.SplitContainer_R.Size = New System.Drawing.Size(1420, 650)
        Me.SplitContainer_R.SplitterDistance = 400
        Me.SplitContainer_R.TabIndex = 0
        '
        'Grd_Reglement
        '
        Me.Grd_Reglement.AfficherLesEntetesLignes = True
        Me.Grd_Reglement.AlternerLesLignes = False
        Me.Grd_Reglement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Reglement.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Reglement.Name = "Grd_Reglement"
        Me.Grd_Reglement.ReadOnly = True
        Me.Grd_Reglement.Size = New System.Drawing.Size(1420, 400)
        Me.Grd_Reglement.TabIndex = 0
        '
        'Grd_Surcharges
        '
        Me.Grd_Surcharges.AfficherLesEntetesLignes = True
        Me.Grd_Surcharges.AlternerLesLignes = False
        Me.Grd_Surcharges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Surcharges.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Surcharges.Name = "Grd_Surcharges"
        Me.Grd_Surcharges.Size = New System.Drawing.Size(1420, 246)
        Me.Grd_Surcharges.TabIndex = 0
        '
        'Tab_Periodicites
        '
        Me.Tab_Periodicites.Controls.Add(Me.Grd_Periodicites)
        Me.Tab_Periodicites.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Periodicites.Name = "Tab_Periodicites"
        Me.Tab_Periodicites.Size = New System.Drawing.Size(1420, 650)
        Me.Tab_Periodicites.TabIndex = 1
        Me.Tab_Periodicites.Text = "Périodicités des visites"
        Me.Tab_Periodicites.UseVisualStyleBackColor = True
        '
        'Grd_Periodicites
        '
        Me.Grd_Periodicites.AfficherLesEntetesLignes = True
        Me.Grd_Periodicites.AlternerLesLignes = False
        Me.Grd_Periodicites.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Periodicites.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Periodicites.Name = "Grd_Periodicites"
        Me.Grd_Periodicites.Size = New System.Drawing.Size(1420, 650)
        Me.Grd_Periodicites.TabIndex = 0
        '
        'Tab_Intervenants
        '
        Me.Tab_Intervenants.Controls.Add(Me.Grd_Intervenants)
        Me.Tab_Intervenants.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Intervenants.Name = "Tab_Intervenants"
        Me.Tab_Intervenants.Size = New System.Drawing.Size(1420, 650)
        Me.Tab_Intervenants.TabIndex = 2
        Me.Tab_Intervenants.Text = "Intervenants (médecins, infirmiers, prestataires)"
        Me.Tab_Intervenants.UseVisualStyleBackColor = True
        '
        'Grd_Intervenants
        '
        Me.Grd_Intervenants.AfficherLesEntetesLignes = True
        Me.Grd_Intervenants.AlternerLesLignes = False
        Me.Grd_Intervenants.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Intervenants.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Intervenants.Name = "Grd_Intervenants"
        Me.Grd_Intervenants.Size = New System.Drawing.Size(1420, 650)
        Me.Grd_Intervenants.TabIndex = 0
        '
        'Tab_Destinataires
        '
        Me.Tab_Destinataires.Controls.Add(Me.Grd_Destinataires)
        Me.Tab_Destinataires.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Destinataires.Name = "Tab_Destinataires"
        Me.Tab_Destinataires.Size = New System.Drawing.Size(1420, 650)
        Me.Tab_Destinataires.TabIndex = 3
        Me.Tab_Destinataires.Text = "Destinataires AT"
        Me.Tab_Destinataires.UseVisualStyleBackColor = True
        '
        'Grd_Destinataires
        '
        Me.Grd_Destinataires.AfficherLesEntetesLignes = True
        Me.Grd_Destinataires.AlternerLesLignes = False
        Me.Grd_Destinataires.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Destinataires.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Destinataires.Name = "Grd_Destinataires"
        Me.Grd_Destinataires.Size = New System.Drawing.Size(1420, 650)
        Me.Grd_Destinataires.TabIndex = 0
        '
        'Tab_Etapes
        '
        Me.Tab_Etapes.Controls.Add(Me.Grd_Etapes)
        Me.Tab_Etapes.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Etapes.Name = "Tab_Etapes"
        Me.Tab_Etapes.Size = New System.Drawing.Size(1420, 650)
        Me.Tab_Etapes.TabIndex = 4
        Me.Tab_Etapes.Text = "Étapes réglementaires AT"
        Me.Tab_Etapes.UseVisualStyleBackColor = True
        '
        'Grd_Etapes
        '
        Me.Grd_Etapes.AfficherLesEntetesLignes = True
        Me.Grd_Etapes.AlternerLesLignes = False
        Me.Grd_Etapes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Etapes.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Etapes.Name = "Grd_Etapes"
        Me.Grd_Etapes.Size = New System.Drawing.Size(1420, 650)
        Me.Grd_Etapes.TabIndex = 0
        '
        'Tab_Postes
        '
        Me.Tab_Postes.Controls.Add(Me.Grd_Postes)
        Me.Tab_Postes.Location = New System.Drawing.Point(4, 28)
        Me.Tab_Postes.Name = "Tab_Postes"
        Me.Tab_Postes.Size = New System.Drawing.Size(1420, 650)
        Me.Tab_Postes.TabIndex = 5
        Me.Tab_Postes.Text = "Postes à risque"
        Me.Tab_Postes.UseVisualStyleBackColor = True
        '
        'Grd_Postes
        '
        Me.Grd_Postes.AfficherLesEntetesLignes = True
        Me.Grd_Postes.AlternerLesLignes = False
        Me.Grd_Postes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Postes.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Postes.Name = "Grd_Postes"
        Me.Grd_Postes.Size = New System.Drawing.Size(1420, 650)
        Me.Grd_Postes.TabIndex = 0
        '
        'RH_Sante_Param
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 714)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CNDP_txt)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "RH_Sante_Param"
        Me.Tag = "ECR"
        Me.Text = "Paramètres et référentiels santé"
        Me.TabControl1.ResumeLayout(False)
        Me.Tab_Reglement.ResumeLayout(False)
        Me.SplitContainer_R.Panel1.ResumeLayout(False)
        Me.SplitContainer_R.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_R, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_R.ResumeLayout(False)
        CType(Me.Grd_Reglement, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd_Surcharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Periodicites.ResumeLayout(False)
        CType(Me.Grd_Periodicites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Intervenants.ResumeLayout(False)
        CType(Me.Grd_Intervenants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Destinataires.ResumeLayout(False)
        CType(Me.Grd_Destinataires, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Etapes.ResumeLayout(False)
        CType(Me.Grd_Etapes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Postes.ResumeLayout(False)
        CType(Me.Grd_Postes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CNDP_txt As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Tab_Reglement As TabPage
    Friend WithEvents SplitContainer_R As SplitContainer
    Friend WithEvents Grd_Reglement As ud_Grd
    Friend WithEvents Grd_Surcharges As ud_Grd
    Friend WithEvents Tab_Periodicites As TabPage
    Friend WithEvents Grd_Periodicites As ud_Grd
    Friend WithEvents Tab_Intervenants As TabPage
    Friend WithEvents Grd_Intervenants As ud_Grd
    Friend WithEvents Tab_Destinataires As TabPage
    Friend WithEvents Grd_Destinataires As ud_Grd
    Friend WithEvents Tab_Etapes As TabPage
    Friend WithEvents Grd_Etapes As ud_Grd
    Friend WithEvents Tab_Postes As TabPage
    Friend WithEvents Grd_Postes As ud_Grd
End Class
