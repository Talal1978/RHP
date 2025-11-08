<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_pathBar
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.DB_lbl = New System.Windows.Forms.Label()
        Me.Separateur_lbl = New System.Windows.Forms.Label()
        Me.pb_Back = New System.Windows.Forms.PictureBox()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.path_pnl = New System.Windows.Forms.Panel()
        Me.pb_Refresh = New System.Windows.Forms.PictureBox()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        CType(Me.pb_Back, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.pb_Refresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DB_lbl
        '
        Me.DB_lbl.AutoSize = True
        Me.DB_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DB_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DB_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DB_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.DB_lbl.Location = New System.Drawing.Point(73, 0)
        Me.DB_lbl.MaximumSize = New System.Drawing.Size(250, 0)
        Me.DB_lbl.MinimumSize = New System.Drawing.Size(25, 25)
        Me.DB_lbl.Name = "DB_lbl"
        Me.DB_lbl.Size = New System.Drawing.Size(60, 40)
        Me.SuperTooltip1.SetSuperTooltip(Me.DB_lbl, New DevComponents.DotNetBar.SuperTooltipInfo("Rh-P", "", "Société en cours", Global.RHP.My.Resources.Resources.btn_soc, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.DB_lbl.TabIndex = 0
        Me.DB_lbl.Text = "ConnDB"
        Me.DB_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Separateur_lbl
        '
        Me.Separateur_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Separateur_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Separateur_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Separateur_lbl.Location = New System.Drawing.Point(139, 0)
        Me.Separateur_lbl.Name = "Separateur_lbl"
        Me.Separateur_lbl.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Separateur_lbl.Size = New System.Drawing.Size(17, 40)
        Me.Separateur_lbl.TabIndex = 1
        Me.Separateur_lbl.Text = ">"
        Me.Separateur_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pb_Back
        '
        Me.pb_Back.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Back.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb_Back.Image = Global.RHP.My.Resources.Resources.btn_back
        Me.pb_Back.Location = New System.Drawing.Point(35, 0)
        Me.pb_Back.Margin = New System.Windows.Forms.Padding(0)
        Me.pb_Back.Name = "pb_Back"
        Me.pb_Back.Size = New System.Drawing.Size(35, 40)
        Me.pb_Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SuperTooltip1.SetSuperTooltip(Me.pb_Back, New DevComponents.DotNetBar.SuperTooltipInfo("Rh-P", "", "Précédent", Global.RHP.My.Resources.Resources.btn_back, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.pb_Back.TabIndex = 0
        Me.pb_Back.TabStop = False
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.ColumnCount = 5
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Controls.Add(Me.path_pnl, 4, 0)
        Me.Personnal_pnl.Controls.Add(Me.Separateur_lbl, 3, 0)
        Me.Personnal_pnl.Controls.Add(Me.DB_lbl, 2, 0)
        Me.Personnal_pnl.Controls.Add(Me.pb_Back, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.pb_Refresh, 0, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(1004, 40)
        Me.Personnal_pnl.TabIndex = 3
        '
        'path_pnl
        '
        Me.path_pnl.AutoSize = True
        Me.path_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.path_pnl.Location = New System.Drawing.Point(159, 0)
        Me.path_pnl.Margin = New System.Windows.Forms.Padding(0)
        Me.path_pnl.Name = "path_pnl"
        Me.path_pnl.Size = New System.Drawing.Size(845, 40)
        Me.path_pnl.TabIndex = 2
        '
        'pb_Refresh
        '
        Me.pb_Refresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Refresh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb_Refresh.Image = Global.RHP.My.Resources.Resources.btn_request
        Me.pb_Refresh.Location = New System.Drawing.Point(0, 0)
        Me.pb_Refresh.Margin = New System.Windows.Forms.Padding(0)
        Me.pb_Refresh.Name = "pb_Refresh"
        Me.pb_Refresh.Size = New System.Drawing.Size(35, 40)
        Me.pb_Refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SuperTooltip1.SetSuperTooltip(Me.pb_Refresh, New DevComponents.DotNetBar.SuperTooltipInfo("Rh-P", "", "Initialisation des paramètres", Global.RHP.My.Resources.Resources.btn_request, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.pb_Refresh.TabIndex = 2
        Me.pb_Refresh.TabStop = False
        '
        'ud_pathBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ud_pathBar"
        Me.Size = New System.Drawing.Size(1004, 40)
        CType(Me.pb_Back, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Personnal_pnl.PerformLayout()
        CType(Me.pb_Refresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DB_lbl As Label
    Friend WithEvents Separateur_lbl As Label
    Friend WithEvents pb_Back As PictureBox
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents path_pnl As Panel
    Friend WithEvents pb_Refresh As PictureBox
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
End Class
