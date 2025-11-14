<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Calender
    inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.entete_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Effacer_pb = New System.Windows.Forms.PictureBox()
        Me.entete_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Effacer_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MonthCalendar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.MonthCalendar1.Location = New System.Drawing.Point(1, 27)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 8
        '
        'entete_pnl
        '
        Me.entete_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.entete_pnl.ColumnCount = 3
        Me.entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entete_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.entete_pnl.Controls.Add(Me.Close_pb, 2, 0)
        Me.entete_pnl.Controls.Add(Me.Effacer_pb, 0, 0)
        Me.entete_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.entete_pnl.Location = New System.Drawing.Point(1, 1)
        Me.entete_pnl.Name = "entete_pnl"
        Me.entete_pnl.RowCount = 1
        Me.entete_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entete_pnl.Size = New System.Drawing.Size(261, 26)
        Me.entete_pnl.TabIndex = 11
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(234, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 20)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 9
        Me.Close_pb.TabStop = False
        '
        'Effacer_pb
        '
        Me.Effacer_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Effacer_pb.Image = Global.RHP.My.Resources.Resources.btn_erase_w
        Me.Effacer_pb.InitialImage = Nothing
        Me.Effacer_pb.Location = New System.Drawing.Point(3, 3)
        Me.Effacer_pb.Name = "Effacer_pb"
        Me.Effacer_pb.Size = New System.Drawing.Size(24, 20)
        Me.Effacer_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Effacer_pb.TabIndex = 9
        Me.Effacer_pb.TabStop = False
        '
        'Zoom_Calender
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(263, 232)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.entete_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.Name = "Zoom_Calender"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Calendrier"
        Me.entete_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Effacer_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents entete_pnl As TableLayoutPanel
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Effacer_pb As PictureBox
End Class
