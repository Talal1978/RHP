<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Timeline_Item
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblDate = New System.Windows.Forms.Label()
        Me.pnlCard = New System.Windows.Forms.Panel()
        Me.lnkCode = New System.Windows.Forms.LinkLabel()
        Me.lblTags = New System.Windows.Forms.Label()
        Me.lblMission = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Motif_lbl = New System.Windows.Forms.Label()
        Me._lineH_lbl = New System.Windows.Forms.Label()
        Me.pnlCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblDate.Location = New System.Drawing.Point(17, 27)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(95, 20)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "15 Jan 2024"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlCard
        '
        Me.pnlCard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.Controls.Add(Me._lineH_lbl)
        Me.pnlCard.Controls.Add(Me.Motif_lbl)
        Me.pnlCard.Controls.Add(Me.lnkCode)
        Me.pnlCard.Controls.Add(Me.lblTags)
        Me.pnlCard.Controls.Add(Me.lblMission)
        Me.pnlCard.Controls.Add(Me.lblSubtitle)
        Me.pnlCard.Controls.Add(Me.lblTitle)
        Me.pnlCard.Location = New System.Drawing.Point(160, 12)
        Me.pnlCard.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Padding = New System.Windows.Forms.Padding(20, 18, 20, 18)
        Me.pnlCard.Size = New System.Drawing.Size(613, 187)
        Me.pnlCard.TabIndex = 1
        '
        'lnkCode
        '
        Me.lnkCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkCode.AutoSize = True
        Me.lnkCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkCode.LinkColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lnkCode.Location = New System.Drawing.Point(24, 167)
        Me.lnkCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lnkCode.Name = "lnkCode"
        Me.lnkCode.Size = New System.Drawing.Size(64, 16)
        Me.lnkCode.TabIndex = 4
        Me.lnkCode.TabStop = True
        Me.lnkCode.Text = "AV-00001"
        Me.lnkCode.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTags
        '
        Me.lblTags.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTags.AutoSize = True
        Me.lblTags.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTags.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblTags.Location = New System.Drawing.Point(21, 112)
        Me.lblTags.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTags.Name = "lblTags"
        Me.lblTags.Size = New System.Drawing.Size(43, 19)
        Me.lblTags.TabIndex = 3
        Me.lblTags.Text = "#Tags"
        '
        'lblMission
        '
        Me.lblMission.AutoSize = True
        Me.lblMission.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMission.ForeColor = System.Drawing.Color.Gray
        Me.lblMission.Location = New System.Drawing.Point(20, 74)
        Me.lblMission.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMission.Name = "lblMission"
        Me.lblMission.Size = New System.Drawing.Size(57, 20)
        Me.lblMission.TabIndex = 2
        Me.lblMission.Text = "Mission"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(20, 47)
        Me.lblSubtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(153, 23)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Grade - Deptname"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(219, 28)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Directeur Commercial"
        '
        'Motif_lbl
        '
        Me.Motif_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Motif_lbl.AutoSize = True
        Me.Motif_lbl.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Motif_lbl.ForeColor = System.Drawing.Color.Gray
        Me.Motif_lbl.Location = New System.Drawing.Point(21, 141)
        Me.Motif_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Motif_lbl.Name = "Motif_lbl"
        Me.Motif_lbl.Size = New System.Drawing.Size(42, 19)
        Me.Motif_lbl.TabIndex = 5
        Me.Motif_lbl.Text = "Motif"
        '
        '_lineH_lbl
        '
        Me._lineH_lbl.BackColor = System.Drawing.Color.Gray
        Me._lineH_lbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me._lineH_lbl.Location = New System.Drawing.Point(6, 103)
        Me._lineH_lbl.Name = "_lineH_lbl"
        Me._lineH_lbl.Size = New System.Drawing.Size(1000, 1)
        Me._lineH_lbl.TabIndex = 6
        '
        'UC_Timeline_Item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pnlCard)
        Me.Controls.Add(Me.lblDate)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UC_Timeline_Item"
        Me.Size = New System.Drawing.Size(800, 212)
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDate As Label
    Friend WithEvents pnlCard As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblMission As Label
    Friend WithEvents lblTags As Label
    Friend WithEvents lnkCode As LinkLabel
    Friend WithEvents Motif_lbl As Label
    Friend WithEvents _lineH_lbl As Label
End Class
