Public Class Zoom_Libre
    Friend ZoomObject As New Object
    Dim oSize As New Size
    Dim oLoc As New Point
    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Zoom_Libre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
        Me.Icon = leMenu.Icon
        Libre_GRD.ContextMenuStrip = AddContextMenu(False, True, False, False, False, False, False, False)
        oSize = Me.Size
        oLoc = Me.Location
        ent_pnl.BackColor = colorBase04
    End Sub
    Private Sub Zomm_Grd_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Libre_GRD.CellContentDoubleClick
        SELECTION_GRD("Click")
    End Sub
    Sub SELECTION_GRD(ByVal Tape As String)
        Dim e As Integer
        If Tape = "Click" Then
            e = Libre_GRD.CurrentRow.Index
        ElseIf Tape = "Clavier" Then
            e = Libre_GRD.CurrentRow.Index - 1
        End If
        On Error Resume Next
        If Libre_GRD.CurrentRow.Index < 0 Then Exit Sub
        If ZoomObject Is Nothing Then Return
        Select Case ZoomObject.GetType.Name
            Case "TextBox", "ud_TextBox"
                ZoomObject.Text = ""
                ZoomObject.Text = Libre_GRD.Item(0, e).Value
            Case "LinkLabel"
                ZoomObject.Text = ""
                ZoomObject.Text = Libre_GRD.Item(0, e).Value
            Case "ComboBox", "ud_ComboBox"
                ZoomObject.Selectedvalue = Libre_GRD.Item(0, e).Value
            Case "DataGridViewTextBoxCell"
                Dim c As Integer = CType(ZoomObject, DataGridViewTextBoxCell).ColumnIndex
                Dim r As Integer = CType(ZoomObject, DataGridViewTextBoxCell).RowIndex

                If r = CType(ZoomObject, DataGridViewTextBoxCell).DataGridView.RowCount - 1 Then
                    CType(ZoomObject, DataGridViewTextBoxCell).DataGridView.Rows.Add("")
                    CType(ZoomObject, DataGridViewTextBoxCell).DataGridView.Item(c, r).Value = Libre_GRD.Item(0, e).Value
                Else
                    ZoomObject.value = Libre_GRD.Item(0, e).Value
                End If

        End Select
        Me.Close()
    End Sub

    Sub Maximize_btn_Click(sender As Object, e As EventArgs) Handles Maximize_pb.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Size = oSize
            Me.Location = oLoc
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Escape
                Me.Close()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub Close_btn_Load(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
    Sub Erase_pb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Erase_pb.Click
        Select Case ZoomObject.GetType.Name
            Case "TextBox", "ud_TextBox"
                ZoomObject.Text = ""
            Case "LinkLabel"
                ZoomObject.Text = ""
            Case "ComboBox", "ud_ComboBox"
                ZoomObject.Selectedindex = -1
            Case "DataGridViewTextBoxCell"
                ZoomObject.value = ""
        End Select
        Me.Close()
    End Sub


End Class