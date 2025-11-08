<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Notifications_Champs_TableRef
    Inherits Ecran

    'Form rEmplace la méthode dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le concepteur Windows Form
    'Elle peut être modifiée à l'aide du concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.entete_pnl = New System.Windows.Forms.Panel()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.lv = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pb_Save = New System.Windows.Forms.PictureBox()
        Me.entete_pnl.SuspendLayout()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Save, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'entete_pnl
        '
        Me.entete_pnl.Controls.Add(Me.pb_Save)
        Me.entete_pnl.Controls.Add(Me.Titre_lbl)
        Me.entete_pnl.Controls.Add(Me.Close_pb)
        Me.entete_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.entete_pnl.Location = New System.Drawing.Point(2, 2)
        Me.entete_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.entete_pnl.Name = "entete_pnl"
        Me.entete_pnl.Size = New System.Drawing.Size(504, 48)
        Me.entete_pnl.TabIndex = 35
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(452, 48)
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.Text = "Sélectionnez un champs déclencheurs"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Dock = System.Windows.Forms.DockStyle.Right
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.Location = New System.Drawing.Point(452, 0)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(52, 48)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 34
        Me.Close_pb.TabStop = False
        '
        'lv
        '
        Me.lv.CheckBoxes = True
        Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv.HideSelection = False
        Me.lv.Location = New System.Drawing.Point(2, 50)
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(504, 428)
        Me.lv.TabIndex = 36
        Me.lv.UseCompatibleStateImageBehavior = False
        Me.lv.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Champs de la table de référence"
        Me.ColumnHeader1.Width = 300
        '
        'pb_Save
        '
        Me.pb_Save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Save.Dock = System.Windows.Forms.DockStyle.Right
        Me.pb_Save.Image = Global.RHP.My.Resources.Resources.btn_save_w
        Me.pb_Save.Location = New System.Drawing.Point(400, 0)
        Me.pb_Save.Margin = New System.Windows.Forms.Padding(4)
        Me.pb_Save.Name = "pb_Save"
        Me.pb_Save.Size = New System.Drawing.Size(52, 48)
        Me.pb_Save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pb_Save.TabIndex = 35
        Me.pb_Save.TabStop = False
        '
        'Zoom_Notifications_Champs_TableRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(508, 480)
        Me.Controls.Add(Me.lv)
        Me.Controls.Add(Me.entete_pnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Zoom_Notifications_Champs_TableRef"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Zoom"
        Me.entete_pnl.ResumeLayout(False)
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Save, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents entete_pnl As Panel
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents lv As ListView
    Friend WithEvents pb_Save As PictureBox
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
