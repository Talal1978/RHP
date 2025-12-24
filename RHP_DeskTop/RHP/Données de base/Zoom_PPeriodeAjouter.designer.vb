Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms.Form

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_PPeriodeAjouter
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
    Private Shared Sub ENCAddToList(ByVal value As Object)
        Dim list As List(Of WeakReference) = Zoom_PPeriodeAjouter.ENCList
        SyncLock list
            If (Zoom_PPeriodeAjouter.ENCList.Count = Zoom_PPeriodeAjouter.ENCList.Capacity) Then
                Dim index As Integer = 0
                Dim num3 As Integer = (Zoom_PPeriodeAjouter.ENCList.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num3)
                    Dim reference As WeakReference = Zoom_PPeriodeAjouter.ENCList.Item(i)
                    If reference.IsAlive Then
                        If (i <> index) Then
                            Zoom_PPeriodeAjouter.ENCList.Item(index) = Zoom_PPeriodeAjouter.ENCList.Item(i)
                        End If
                        index += 1
                    End If
                    i += 1
                Loop
                Zoom_PPeriodeAjouter.ENCList.RemoveRange(index, (Zoom_PPeriodeAjouter.ENCList.Count - index))
                Zoom_PPeriodeAjouter.ENCList.Capacity = Zoom_PPeriodeAjouter.ENCList.Count
            End If
            Zoom_PPeriodeAjouter.ENCList.Add(New WeakReference(RuntimeHelpers.GetObjectValue(value)))
        End SyncLock
    End Sub
    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpAu = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDu = New System.Windows.Forms.DateTimePicker()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Save_ud = New RHP.ud_button()
        Me.Annuler_ud = New RHP.ud_button()
        Me.GroupBox1.SuspendLayout()
        Me.Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpAu)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpDu)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(462, 77)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(257, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 21)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Au"
        '
        'dtpAu
        '
        Me.dtpAu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAu.Location = New System.Drawing.Point(301, 25)
        Me.dtpAu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpAu.Name = "dtpAu"
        Me.dtpAu.Size = New System.Drawing.Size(108, 21)
        Me.dtpAu.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(22, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 22)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Du"
        '
        'dtpDu
        '
        Me.dtpDu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDu.Location = New System.Drawing.Point(68, 27)
        Me.dtpDu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDu.Name = "dtpDu"
        Me.dtpDu.Size = New System.Drawing.Size(109, 21)
        Me.dtpDu.TabIndex = 2
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Pnl.Controls.Add(Me.Save_ud)
        Me.Pnl.Controls.Add(Me.Annuler_ud)
        Me.Pnl.Controls.Add(Me.GroupBox1)
        Me.Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl.Location = New System.Drawing.Point(2, 2)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Padding = New System.Windows.Forms.Padding(10)
        Me.Pnl.Size = New System.Drawing.Size(482, 153)
        Me.Pnl.TabIndex = 16
        '
        'Save_ud
        '
        Me.Save_ud.AutoSize = True
        Me.Save_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Save_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Save_ud.BorderSize = 2
        Me.Save_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Save_ud.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_ud.Location = New System.Drawing.Point(361, 108)
        Me.Save_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Save_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Save_ud.Name = "Save_ud"
        Me.Save_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Save_ud.Size = New System.Drawing.Size(111, 33)
        Me.Save_ud.TabIndex = 32
        Me.Save_ud.Text = "Enregistrer"
        Me.Save_ud.ToolTip = ""
        '
        'Annuler_ud
        '
        Me.Annuler_ud.AutoSize = True
        Me.Annuler_ud.Border = RHP.ud_button.BorderStyle.All
        Me.Annuler_ud.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Annuler_ud.BorderSize = 2
        Me.Annuler_ud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Annuler_ud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Annuler_ud.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Annuler_ud.Location = New System.Drawing.Point(10, 108)
        Me.Annuler_ud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Annuler_ud.MinimumSize = New System.Drawing.Size(27, 31)
        Me.Annuler_ud.Name = "Annuler_ud"
        Me.Annuler_ud.Padding = New System.Windows.Forms.Padding(2)
        Me.Annuler_ud.Size = New System.Drawing.Size(111, 33)
        Me.Annuler_ud.TabIndex = 33
        Me.Annuler_ud.Text = "Annuler"
        Me.Annuler_ud.ToolTip = ""
        '
        'Zoom_PPeriodeAjouter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(486, 157)
        Me.ControlBox = False
        Me.Controls.Add(Me.Pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Zoom_PPeriodeAjouter"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajouter une periode"
        Me.GroupBox1.ResumeLayout(False)
        Me.Pnl.ResumeLayout(False)
        Me.Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub



    ' Fields
    Private Shared ENCList As List(Of WeakReference) = New List(Of WeakReference)
    '<AccessedThroughProperty("btEnregistrer")>  
    '<AccessedThroughProperty("cboEtat")>  
    '<AccessedThroughProperty("cboPeriodePrecedente")>  
    '<AccessedThroughProperty("dtpAu")>  
    Private WithEvents dtpAu As DateTimePicker
    '<AccessedThroughProperty("dtpDu")>  
    Private WithEvents dtpDu As DateTimePicker
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
End Class
