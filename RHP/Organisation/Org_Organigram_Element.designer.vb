<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Org_Organigram_Element
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.Expand_lbl = New System.Windows.Forms.Label()
        Me.Typ_Entite_lbl = New System.Windows.Forms.Label()
        Me.Entite_Org = New System.Windows.Forms.Label()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.content_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.content_pnl.SuspendLayout()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Expand_lbl
        '
        Me.Expand_lbl.AutoSize = True
        Me.Expand_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Expand_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Expand_lbl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Expand_lbl.Location = New System.Drawing.Point(3, 77)
        Me.Expand_lbl.Name = "Expand_lbl"
        Me.Expand_lbl.Size = New System.Drawing.Size(135, 13)
        Me.Expand_lbl.TabIndex = 2
        Me.Expand_lbl.Text = "[+]"
        Me.Expand_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Typ_Entite_lbl
        '
        Me.Typ_Entite_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Typ_Entite_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Typ_Entite_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.Typ_Entite_lbl.Location = New System.Drawing.Point(0, 56)
        Me.Typ_Entite_lbl.Margin = New System.Windows.Forms.Padding(0)
        Me.Typ_Entite_lbl.Name = "Typ_Entite_lbl"
        Me.Typ_Entite_lbl.Size = New System.Drawing.Size(141, 18)
        Me.Typ_Entite_lbl.TabIndex = 1
        Me.Typ_Entite_lbl.Tag = ""
        Me.Typ_Entite_lbl.Text = "Type entité"
        Me.Typ_Entite_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Entite_Org
        '
        Me.Entite_Org.AutoSize = True
        Me.Entite_Org.BackColor = System.Drawing.Color.Transparent
        Me.Entite_Org.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Entite_Org.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Entite_Org.Location = New System.Drawing.Point(0, 0)
        Me.Entite_Org.Margin = New System.Windows.Forms.Padding(0)
        Me.Entite_Org.Name = "Entite_Org"
        Me.Entite_Org.Size = New System.Drawing.Size(141, 56)
        Me.Entite_Org.TabIndex = 0
        Me.Entite_Org.Text = "Entité"
        Me.Entite_Org.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'content_pnl
        '
        Me.content_pnl.ColumnCount = 1
        Me.content_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.content_pnl.Controls.Add(Me.Expand_lbl, 0, 2)
        Me.content_pnl.Controls.Add(Me.Entite_Org, 0, 0)
        Me.content_pnl.Controls.Add(Me.Typ_Entite_lbl, 0, 1)
        Me.content_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.content_pnl.Location = New System.Drawing.Point(0, 0)
        Me.content_pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.content_pnl.Name = "content_pnl"
        Me.content_pnl.RowCount = 3
        Me.content_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.content_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.content_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.content_pnl.Size = New System.Drawing.Size(141, 90)
        Me.content_pnl.TabIndex = 3
        '
        'Pnl
        '
        Me.Pnl.Controls.Add(Me.content_pnl)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 2)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(141, 90)
        Me.Pnl.TabIndex = 4
        '
        'Org_Organigram_Element
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pnl)
        Me.Name = "Org_Organigram_Element"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(145, 94)
        Me.content_pnl.ResumeLayout(False)
        Me.content_pnl.PerformLayout()
        Me.Pnl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Expand_lbl As Label
    Friend WithEvents Entite_Org As Label
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Private WithEvents Typ_Entite_lbl As Label
    Friend WithEvents content_pnl As TableLayoutPanel
    Friend WithEvents Pnl As Panel
End Class
