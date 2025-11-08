<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_PanelWait
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblAvancement = New System.Windows.Forms.Label()
        Me.Progress_pnl = New System.Windows.Forms.Panel()
        Me.Progress_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'CircularProgress1
        '
        Me.CircularProgress1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.Class = ""
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CircularProgress1.Location = New System.Drawing.Point(0, 0)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.PieBorderDark = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CircularProgress1.Size = New System.Drawing.Size(187, 160)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 171
        '
        'lblProgress
        '
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProgress.Font = New System.Drawing.Font("Century Gothic", 24.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.lblProgress.Location = New System.Drawing.Point(0, 160)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(187, 43)
        Me.lblProgress.TabIndex = 172
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAvancement
        '
        Me.lblAvancement.AutoSize = True
        Me.lblAvancement.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblAvancement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblAvancement.Location = New System.Drawing.Point(39, 29)
        Me.lblAvancement.Name = "lblAvancement"
        Me.lblAvancement.Size = New System.Drawing.Size(0, 16)
        Me.lblAvancement.TabIndex = 170
        '
        'Progress_pnl
        '
        Me.Progress_pnl.Controls.Add(Me.lblProgress)
        Me.Progress_pnl.Controls.Add(Me.CircularProgress1)
        Me.Progress_pnl.Location = New System.Drawing.Point(272, 118)
        Me.Progress_pnl.Name = "Progress_pnl"
        Me.Progress_pnl.Size = New System.Drawing.Size(187, 203)
        Me.Progress_pnl.TabIndex = 173
        '
        'ud_PanelWait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Controls.Add(Me.Progress_pnl)
        Me.Controls.Add(Me.lblAvancement)
        Me.Name = "ud_PanelWait"
        Me.Size = New System.Drawing.Size(605, 380)
        Me.Progress_pnl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents lblProgress As Label
    Friend WithEvents lblAvancement As Label
    Friend WithEvents Progress_pnl As Panel
End Class
