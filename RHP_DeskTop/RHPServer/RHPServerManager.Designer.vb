<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RHPServerManager
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RHPServerManager))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Grd_Notif = New System.Windows.Forms.DataGridView()
        Me.Grd_Abn = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Conn_lst = New System.Windows.Forms.ListView()
        Me.Connexions = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.conn_imgs = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Chk_Notif = New System.Windows.Forms.CheckBox()
        Me.chk_Mailing = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Grd_Log = New System.Windows.Forms.DataGridView()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OuvrirRHPServerManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Grd_Notif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grd_Abn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.Grd_Log, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1228, 687)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grd_Notif)
        Me.TabPage1.Controls.Add(Me.Grd_Abn)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1220, 658)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configuration"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Grd_Notif
        '
        Me.Grd_Notif.AllowUserToAddRows = False
        Me.Grd_Notif.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Grd_Notif.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.Grd_Notif.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Notif.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Notif.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Grd_Notif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Notif.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Notif.Location = New System.Drawing.Point(264, 335)
        Me.Grd_Notif.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Notif.Name = "Grd_Notif"
        Me.Grd_Notif.ReadOnly = True
        Me.Grd_Notif.RowHeadersWidth = 51
        Me.Grd_Notif.Size = New System.Drawing.Size(952, 319)
        Me.Grd_Notif.TabIndex = 3
        '
        'Grd_Abn
        '
        Me.Grd_Abn.AllowUserToAddRows = False
        Me.Grd_Abn.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Grd_Abn.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.Grd_Abn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Abn.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Abn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Grd_Abn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Abn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grd_Abn.Location = New System.Drawing.Point(264, 4)
        Me.Grd_Abn.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Abn.Name = "Grd_Abn"
        Me.Grd_Abn.ReadOnly = True
        Me.Grd_Abn.RowHeadersWidth = 51
        Me.Grd_Abn.Size = New System.Drawing.Size(952, 331)
        Me.Grd_Abn.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Conn_lst)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(260, 650)
        Me.Panel1.TabIndex = 1
        '
        'Conn_lst
        '
        Me.Conn_lst.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Connexions})
        Me.Conn_lst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Conn_lst.FullRowSelect = True
        Me.Conn_lst.GridLines = True
        Me.Conn_lst.HideSelection = False
        Me.Conn_lst.LargeImageList = Me.conn_imgs
        Me.Conn_lst.Location = New System.Drawing.Point(0, 90)
        Me.Conn_lst.Margin = New System.Windows.Forms.Padding(4)
        Me.Conn_lst.MultiSelect = False
        Me.Conn_lst.Name = "Conn_lst"
        Me.Conn_lst.Size = New System.Drawing.Size(260, 560)
        Me.Conn_lst.SmallImageList = Me.conn_imgs
        Me.Conn_lst.TabIndex = 1
        Me.Conn_lst.UseCompatibleStateImageBehavior = False
        Me.Conn_lst.View = System.Windows.Forms.View.Details
        '
        'Connexions
        '
        Me.Connexions.Width = 300
        '
        'conn_imgs
        '
        Me.conn_imgs.ImageStream = CType(resources.GetObject("conn_imgs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.conn_imgs.TransparentColor = System.Drawing.Color.Transparent
        Me.conn_imgs.Images.SetKeyName(0, "Alert_info.png")
        Me.conn_imgs.Images.SetKeyName(1, "erreur.png")
        Me.conn_imgs.Images.SetKeyName(2, "success.gif")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Chk_Notif)
        Me.GroupBox1.Controls.Add(Me.chk_Mailing)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(260, 90)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Chk_Notif
        '
        Me.Chk_Notif.AutoSize = True
        Me.Chk_Notif.Checked = True
        Me.Chk_Notif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Notif.Location = New System.Drawing.Point(20, 23)
        Me.Chk_Notif.Margin = New System.Windows.Forms.Padding(4)
        Me.Chk_Notif.Name = "Chk_Notif"
        Me.Chk_Notif.Size = New System.Drawing.Size(164, 20)
        Me.Chk_Notif.TabIndex = 0
        Me.Chk_Notif.Text = "Activer les notifications"
        Me.Chk_Notif.UseVisualStyleBackColor = True
        '
        'chk_Mailing
        '
        Me.chk_Mailing.AutoSize = True
        Me.chk_Mailing.Checked = True
        Me.chk_Mailing.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Mailing.Location = New System.Drawing.Point(20, 52)
        Me.chk_Mailing.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_Mailing.Name = "chk_Mailing"
        Me.chk_Mailing.Size = New System.Drawing.Size(147, 20)
        Me.chk_Mailing.TabIndex = 0
        Me.chk_Mailing.Text = "Activier les mailings"
        Me.chk_Mailing.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Grd_Log)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1220, 658)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Log"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Grd_Log
        '
        Me.Grd_Log.AllowUserToAddRows = False
        Me.Grd_Log.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Grd_Log.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.Grd_Log.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Log.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Log.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.Grd_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Log.Location = New System.Drawing.Point(4, 4)
        Me.Grd_Log.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Log.Name = "Grd_Log"
        Me.Grd_Log.ReadOnly = True
        Me.Grd_Log.RowHeadersWidth = 51
        Me.Grd_Log.Size = New System.Drawing.Size(1212, 650)
        Me.Grd_Log.TabIndex = 4
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipText = "RHP Server Manager"
        Me.NotifyIcon1.BalloonTipTitle = "RHP Server Manager"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "RHP Server Manager"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirRHPServerManagerToolStripMenuItem, Me.QuitterToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(263, 56)
        '
        'OuvrirRHPServerManagerToolStripMenuItem
        '
        Me.OuvrirRHPServerManagerToolStripMenuItem.Image = CType(resources.GetObject("OuvrirRHPServerManagerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OuvrirRHPServerManagerToolStripMenuItem.Name = "OuvrirRHPServerManagerToolStripMenuItem"
        Me.OuvrirRHPServerManagerToolStripMenuItem.Size = New System.Drawing.Size(262, 26)
        Me.OuvrirRHPServerManagerToolStripMenuItem.Text = "Ouvrir RHP Server Manager"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Image = CType(resources.GetObject("QuitterToolStripMenuItem.Image"), System.Drawing.Image)
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(262, 26)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'RHPServerManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 687)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RHPServerManager"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RHP Server Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Grd_Notif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grd_Abn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Grd_Log, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents OuvrirRHPServerManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Conn_lst As ListView
    Friend WithEvents Chk_Notif As CheckBox
    Friend WithEvents chk_Mailing As CheckBox
    Friend WithEvents Grd_Notif As DataGridView
    Friend WithEvents Grd_Abn As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Grd_Log As DataGridView
    Friend WithEvents conn_imgs As ImageList
    Friend WithEvents Connexions As ColumnHeader
End Class
