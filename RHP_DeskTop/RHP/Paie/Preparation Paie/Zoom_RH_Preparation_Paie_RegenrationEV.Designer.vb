<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_RH_Preparation_Paie_RegenrationEV
    Inherits Ecran

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.SelectAll_pb = New System.Windows.Forms.PictureBox()
        Me.Request_pb = New System.Windows.Forms.PictureBox()
        Me.Grille = New RHP.ud_Grd()
        Me.Oui = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cod_Rubrique = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mnt_Modules = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mnt_Preparation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Etat = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectAll_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Request_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ent_pnl.ColumnCount = 6
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.ent_pnl.Controls.Add(Me.Zoom_lbl, 3, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 5, 0)
        Me.ent_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.ent_pnl.Controls.Add(Me.SelectAll_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Request_pb, 2, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.Padding = New System.Windows.Forms.Padding(1)
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(1190, 50)
        Me.ent_pnl.TabIndex = 34
        '
        'Zoom_lbl
        '
        Me.Zoom_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Zoom_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Zoom_lbl.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Zoom_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Zoom_lbl.Location = New System.Drawing.Point(145, 1)
        Me.Zoom_lbl.Name = "Zoom_lbl"
        Me.Zoom_lbl.Size = New System.Drawing.Size(988, 48)
        Me.Zoom_lbl.TabIndex = 6
        Me.Zoom_lbl.Text = "Importer les éléments variables des modules annexes"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(1144, 1)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(45, 48)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 7
        Me.Close_pb.TabStop = False
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(1, 1)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(44, 48)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 7
        Me.Save_pb.TabStop = False
        '
        'SelectAll_pb
        '
        Me.SelectAll_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SelectAll_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SelectAll_pb.Image = Global.RHP.My.Resources.Resources.btn_selectAll
        Me.SelectAll_pb.Location = New System.Drawing.Point(45, 1)
        Me.SelectAll_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.SelectAll_pb.Name = "SelectAll_pb"
        Me.SelectAll_pb.Size = New System.Drawing.Size(47, 48)
        Me.SelectAll_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SelectAll_pb.TabIndex = 7
        Me.SelectAll_pb.TabStop = False
        '
        'Request_pb
        '
        Me.Request_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Request_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Request_pb.Image = Global.RHP.My.Resources.Resources.btn_request
        Me.Request_pb.Location = New System.Drawing.Point(92, 1)
        Me.Request_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.Request_pb.Name = "Request_pb"
        Me.Request_pb.Size = New System.Drawing.Size(50, 48)
        Me.Request_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Request_pb.TabIndex = 7
        Me.Request_pb.TabStop = False
        '
        'Grille
        '
        Me.Grille.AfficherLesEntetesLignes = True
        Me.Grille.AllowUserToAddRows = False
        Me.Grille.AllowUserToOrderColumns = True
        Me.Grille.AlternerLesLignes = False
        Me.Grille.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grille.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grille.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grille.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Oui, Me.Cod_Rubrique, Me.Mnt_Modules, Me.Mnt_Preparation, Me.Etat})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grille.DefaultCellStyle = DataGridViewCellStyle15
        Me.Grille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grille.EnableHeadersVisualStyles = False
        Me.Grille.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grille.Location = New System.Drawing.Point(2, 52)
        Me.Grille.Margin = New System.Windows.Forms.Padding(4)
        Me.Grille.Name = "Grille"
        Me.Grille.ReadOnly = True
        Me.Grille.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grille.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.Grille.RowHeadersVisible = False
        Me.Grille.RowHeadersWidth = 51
        Me.Grille.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grille.Size = New System.Drawing.Size(1190, 600)
        Me.Grille.TabIndex = 35
        '
        'Oui
        '
        Me.Oui.HeaderText = ""
        Me.Oui.MinimumWidth = 50
        Me.Oui.Name = "Oui"
        Me.Oui.ReadOnly = True
        Me.Oui.Width = 50
        '
        'Cod_Rubrique
        '
        Me.Cod_Rubrique.HeaderText = "Rubrique"
        Me.Cod_Rubrique.MinimumWidth = 200
        Me.Cod_Rubrique.Name = "Cod_Rubrique"
        Me.Cod_Rubrique.ReadOnly = True
        Me.Cod_Rubrique.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cod_Rubrique.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cod_Rubrique.Width = 200
        '
        'Mnt_Modules
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        Me.Mnt_Modules.DefaultCellStyle = DataGridViewCellStyle11
        Me.Mnt_Modules.HeaderText = "Montant du module"
        Me.Mnt_Modules.MinimumWidth = 6
        Me.Mnt_Modules.Name = "Mnt_Modules"
        Me.Mnt_Modules.ReadOnly = True
        Me.Mnt_Modules.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Mnt_Modules.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Mnt_Modules.Width = 125
        '
        'Mnt_Preparation
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        Me.Mnt_Preparation.DefaultCellStyle = DataGridViewCellStyle12
        Me.Mnt_Preparation.HeaderText = "Montant Préparation"
        Me.Mnt_Preparation.MinimumWidth = 6
        Me.Mnt_Preparation.Name = "Mnt_Preparation"
        Me.Mnt_Preparation.ReadOnly = True
        Me.Mnt_Preparation.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Mnt_Preparation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Mnt_Preparation.Width = 125
        '
        'Etat
        '
        Me.Etat.HeaderText = "Etat"
        Me.Etat.MinimumWidth = 50
        Me.Etat.Name = "Etat"
        Me.Etat.ReadOnly = True
        Me.Etat.Width = 50
        '
        'Zoom_RH_Preparation_Paie_RegenrationEV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1194, 654)
        Me.Controls.Add(Me.Grille)
        Me.Controls.Add(Me.ent_pnl)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_RH_Preparation_Paie_RegenrationEV"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Regenration des éléments variables"
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectAll_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Request_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents SelectAll_pb As PictureBox
    Friend WithEvents Request_pb As PictureBox
    Friend WithEvents Grille As ud_Grd
    Friend WithEvents Oui As DataGridViewCheckBoxColumn
    Friend WithEvents Cod_Rubrique As DataGridViewTextBoxColumn
    Friend WithEvents Mnt_Modules As DataGridViewTextBoxColumn
    Friend WithEvents Mnt_Preparation As DataGridViewTextBoxColumn
    Friend WithEvents Etat As DataGridViewImageColumn
End Class
