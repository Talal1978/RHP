Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms.Form

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_AddModele
    Inherits Ecran

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Url_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Provider_txt = New RHP.ud_TextBox()
        Me.modele_txt = New RHP.ud_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Typ_Modele_lbl = New System.Windows.Forms.Label()
        Me._Typ_Modele = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Supprimer_ud = New RHP.ud_button()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.DelModele_pb = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.Pnl.SuspendLayout()
        CType(Me.DelModele_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DelModele_pb)
        Me.GroupBox1.Controls.Add(Me.Url_txt)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Provider_txt)
        Me.GroupBox1.Controls.Add(Me.modele_txt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Typ_Modele_lbl)
        Me.GroupBox1.Controls.Add(Me._Typ_Modele)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(665, 174)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Url_txt
        '
        Me.Url_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Url_txt.ContextMenuStrip = Nothing
        Me.Url_txt.Location = New System.Drawing.Point(92, 126)
        Me.Url_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Url_txt.MaxLength = 32767
        Me.Url_txt.Multiline = False
        Me.Url_txt.Name = "Url_txt"
        Me.Url_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Url_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Url_txt.ReadOnly = False
        Me.Url_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Url_txt.SelectionStart = 0
        Me.Url_txt.Size = New System.Drawing.Size(566, 26)
        Me.Url_txt.TabIndex = 19
        Me.Url_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Url_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(22, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 20)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Url"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Provider_txt
        '
        Me.Provider_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Provider_txt.ContextMenuStrip = Nothing
        Me.Provider_txt.Location = New System.Drawing.Point(92, 23)
        Me.Provider_txt.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Provider_txt.MaxLength = 32767
        Me.Provider_txt.Multiline = False
        Me.Provider_txt.Name = "Provider_txt"
        Me.Provider_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Provider_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Provider_txt.ReadOnly = False
        Me.Provider_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Provider_txt.SelectionStart = 0
        Me.Provider_txt.Size = New System.Drawing.Size(566, 31)
        Me.Provider_txt.TabIndex = 17
        Me.Provider_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Provider_txt.UseSystemPasswordChar = False
        '
        'modele_txt
        '
        Me.modele_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.modele_txt.ContextMenuStrip = Nothing
        Me.modele_txt.Location = New System.Drawing.Point(92, 91)
        Me.modele_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.modele_txt.MaxLength = 32767
        Me.modele_txt.Multiline = False
        Me.modele_txt.Name = "modele_txt"
        Me.modele_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.modele_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.modele_txt.ReadOnly = False
        Me.modele_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.modele_txt.SelectionStart = 0
        Me.modele_txt.Size = New System.Drawing.Size(523, 26)
        Me.modele_txt.TabIndex = 16
        Me.modele_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.modele_txt.UseSystemPasswordChar = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(22, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 20)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Modèle"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Typ_Modele_lbl
        '
        Me.Typ_Modele_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Typ_Modele_lbl.Location = New System.Drawing.Point(88, 60)
        Me.Typ_Modele_lbl.Name = "Typ_Modele_lbl"
        Me.Typ_Modele_lbl.Size = New System.Drawing.Size(355, 22)
        Me.Typ_Modele_lbl.TabIndex = 13
        '
        '_Typ_Modele
        '
        Me._Typ_Modele.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me._Typ_Modele.Location = New System.Drawing.Point(36, 60)
        Me._Typ_Modele.Name = "_Typ_Modele"
        Me._Typ_Modele.Size = New System.Drawing.Size(49, 22)
        Me._Typ_Modele.TabIndex = 13
        Me._Typ_Modele.Text = "Type"
        Me._Typ_Modele.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(6, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 22)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Provider"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Supprimer_ud)
        Me.Pnl.Controls.Add(Me.Save_ud)
        Me.Pnl.Controls.Add(Me.Annuler_ud)
        Me.Pnl.Controls.Add(Me.GroupBox1)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 2)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Padding = New System.Windows.Forms.Padding(10)
        Me.Pnl.Size = New System.Drawing.Size(685, 260)
        Me.Pnl.TabIndex = 16
        '
        'Supprimer_ud
        '
        Me.Supprimer_ud.AutoSize = True
        Me.Supprimer_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Supprimer_ud.bgColor = System.Drawing.Color.White
        Me.Supprimer_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Supprimer_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Supprimer_ud.BorderSize = 2
        Me.Supprimer_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Supprimer_ud.Image = Global.RHP.My.Resources.Resources.btn_delete
        Me.Supprimer_ud.isDefault = False
        Me.Supprimer_ud.Location = New System.Drawing.Point(417, 217)
        Me.Supprimer_ud.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Supprimer_ud.MinimumSize = New System.Drawing.Size(27, 33)
        Me.Supprimer_ud.Name = "Supprimer_ud"
        Me.Supprimer_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Supprimer_ud.Size = New System.Drawing.Size(132, 33)
        Me.Supprimer_ud.TabIndex = 34
        Me.Supprimer_ud.Text = "Supprimer"
        '
        'Save_ud
        '
        Me.Save_ud.AutoSize = True
        Me.Save_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.bgColor = System.Drawing.Color.White
        Me.Save_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Save_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.BorderSize = 2
        Me.Save_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_ud.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_ud.isDefault = False
        Me.Save_ud.Location = New System.Drawing.Point(555, 217)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(120, 33)
        Me.Save_ud.TabIndex = 32
        Me.Save_ud.Text = "Enregistrer"
        '
        'Annuler_ud
        '
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.bgColor = System.Drawing.Color.White
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.isDefault = False
        Me.Annuler_ud.Location = New System.Drawing.Point(10, 217)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(111, 33)
        Me.Annuler_ud.TabIndex = 33
        Me.Annuler_ud.Text = "Annuler"
        '
        'DelModele_pb
        '
        Me.DelModele_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DelModele_pb.Image = Global.RHP.My.Resources.Resources.btn_delete
        Me.DelModele_pb.Location = New System.Drawing.Point(619, 88)
        Me.DelModele_pb.Margin = New System.Windows.Forms.Padding(0)
        Me.DelModele_pb.Name = "DelModele_pb"
        Me.DelModele_pb.Size = New System.Drawing.Size(41, 32)
        Me.DelModele_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.DelModele_pb.TabIndex = 207
        Me.DelModele_pb.TabStop = False
        '
        'Zoom_AddModele
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(689, 264)
        Me.ControlBox = False
        Me.Controls.Add(Me.Pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Zoom_AddModele"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajouter une periode"
        Me.GroupBox1.ResumeLayout(False)
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        CType(Me.DelModele_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub



    ' Fields
    Private Shared ENCList As List(Of WeakReference) = New List(Of WeakReference)
    '<AccessedThroughProperty("GroupBox1")>  
    Private WithEvents GroupBox1 As GroupBox
    '<AccessedThroughProperty("Label2")>  
    '<AccessedThroughProperty("Label3")>  
    Private WithEvents Label3 As Label
    '<AccessedThroughProperty("Label4")>  
    Private WithEvents Label4 As Label
    Friend WithEvents Pnl As Panel
    Friend WithEvents Save_ud As ud_button
    Friend WithEvents Annuler_ud As ud_button
    Friend WithEvents modele_txt As ud_TextBox
    Private WithEvents _Typ_Modele As Label
    Friend WithEvents Url_txt As ud_TextBox
    Private WithEvents Label1 As Label
    Friend WithEvents Provider_txt As ud_TextBox
    Friend WithEvents Supprimer_ud As ud_button
    Friend WithEvents DelModele_pb As PictureBox
    Friend WithEvents Typ_Modele_lbl As Label
End Class
