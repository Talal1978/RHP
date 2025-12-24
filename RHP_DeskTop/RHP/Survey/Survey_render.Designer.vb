<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Survey_render
    inherits Ecran

    'Form overrides dispose to clean up the component list.
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
        Me.Lib_Survey_lbl = New System.Windows.Forms.Label()
        Me.Cod_Survey_lbl = New System.Windows.Forms.Label()
        Me.pnl_Content = New System.Windows.Forms.Panel()
        Me.Pnl_Left = New System.Windows.Forms.Panel()
        Me.pnl_Right = New System.Windows.Forms.Panel()
        Me.Preambule_rtb = New System.Windows.Forms.RichTextBox()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.Pnl_Bottom = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Lib_Survey_lbl
        '
        Me.Lib_Survey_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Lib_Survey_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lib_Survey_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lib_Survey_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Lib_Survey_lbl.Location = New System.Drawing.Point(27, 28)
        Me.Lib_Survey_lbl.Name = "Lib_Survey_lbl"
        Me.Lib_Survey_lbl.Size = New System.Drawing.Size(806, 29)
        Me.Lib_Survey_lbl.TabIndex = 0
        Me.Lib_Survey_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cod_Survey_lbl
        '
        Me.Cod_Survey_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Cod_Survey_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Cod_Survey_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cod_Survey_lbl.Location = New System.Drawing.Point(27, 57)
        Me.Cod_Survey_lbl.Name = "Cod_Survey_lbl"
        Me.Cod_Survey_lbl.Size = New System.Drawing.Size(806, 29)
        Me.Cod_Survey_lbl.TabIndex = 1
        Me.Cod_Survey_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnl_Content
        '
        Me.pnl_Content.AutoScroll = True
        Me.pnl_Content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Content.Location = New System.Drawing.Point(27, 236)
        Me.pnl_Content.Name = "pnl_Content"
        Me.pnl_Content.Size = New System.Drawing.Size(806, 382)
        Me.pnl_Content.TabIndex = 3
        '
        'Pnl_Left
        '
        Me.Pnl_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.Pnl_Left.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Left.Name = "Pnl_Left"
        Me.Pnl_Left.Size = New System.Drawing.Size(27, 646)
        Me.Pnl_Left.TabIndex = 0
        '
        'pnl_Right
        '
        Me.pnl_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(833, 0)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Size = New System.Drawing.Size(27, 646)
        Me.pnl_Right.TabIndex = 4
        '
        'Preambule_rtb
        '
        Me.Preambule_rtb.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Preambule_rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Preambule_rtb.Dock = System.Windows.Forms.DockStyle.Top
        Me.Preambule_rtb.Enabled = False
        Me.Preambule_rtb.Location = New System.Drawing.Point(27, 86)
        Me.Preambule_rtb.Name = "Preambule_rtb"
        Me.Preambule_rtb.ReadOnly = True
        Me.Preambule_rtb.Size = New System.Drawing.Size(806, 150)
        Me.Preambule_rtb.TabIndex = 0
        Me.Preambule_rtb.Text = ""
        '
        'pnl_Top
        '
        Me.pnl_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.ForeColor = System.Drawing.Color.Transparent
        Me.pnl_Top.Location = New System.Drawing.Point(27, 0)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(806, 28)
        Me.pnl_Top.TabIndex = 5
        '
        'Pnl_Bottom
        '
        Me.Pnl_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Bottom.Location = New System.Drawing.Point(27, 618)
        Me.Pnl_Bottom.Name = "Pnl_Bottom"
        Me.Pnl_Bottom.Size = New System.Drawing.Size(806, 28)
        Me.Pnl_Bottom.TabIndex = 6
        '
        'Survey_render
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(860, 646)
        Me.Controls.Add(Me.pnl_Content)
        Me.Controls.Add(Me.Pnl_Bottom)
        Me.Controls.Add(Me.Preambule_rtb)
        Me.Controls.Add(Me.Cod_Survey_lbl)
        Me.Controls.Add(Me.Lib_Survey_lbl)
        Me.Controls.Add(Me.pnl_Top)
        Me.Controls.Add(Me.pnl_Right)
        Me.Controls.Add(Me.Pnl_Left)
        Me.Name = "Survey_render"
        Me.Tag = "ECR"
        Me.Text = "Enquête"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lib_Survey_lbl As Label
    Friend WithEvents Cod_Survey_lbl As Label
    Friend WithEvents pnl_Content As Panel
    Friend WithEvents Pnl_Left As Panel
    Friend WithEvents pnl_Right As Panel
    Friend WithEvents Preambule_rtb As RichTextBox
    Friend WithEvents pnl_Top As Panel
    Friend WithEvents Pnl_Bottom As Panel
End Class
