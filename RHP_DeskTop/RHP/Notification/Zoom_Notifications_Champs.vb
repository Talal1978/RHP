Public Class Zoom_Notifications_Champs
    Friend txtBox As New ud_TextBox
    Friend txtCell As DataGridViewCell = Nothing
    Friend dicTbl As New Dictionary(Of String, String)
    Friend dicCol As New Dictionary(Of String, String)
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
    Private Sub Trv_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Trv.NodeMouseDoubleClick
        If Not e.Node.Tag = "C" Then Return
        Dim lg As Integer = 0
        If txtBox IsNot Nothing Then
            lg = txtBox.SelectionStart
            txtBox.Text = txtBox.Text.Insert(lg, " {" & e.Node.Name & "} ")
            lg += e.Node.Name.Length + 4
            txtBox.SelectionStart = lg
        ElseIf txtCell IsNot Nothing Then
            Dim txt As New ud_TextBox
            txt.Text = txtCell.Value
            lg = txt.SelectionStart
            txt.Text = txt.Text.Insert(lg, " {" & e.Node.Name & "} ")
            lg += e.Node.Name.Length + 4
            txt.SelectionStart = lg
            txtCell.Value = txt.Text
            txtCell.DataGridView.EndEdit(True)
        End If
        Me.Close()
    End Sub
    Private Sub Zoom_Notifications_Champs_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each a In dicTbl
            Dim tnode As New TreeNode
            With tnode
                .Name = a.Key & "|" & a.Value
                .Text = a.Key & " (" & a.Value & ")"
                .Tag = "T"
                Dim lst = dicCol.Where(Function(x) x.Key.Split(".")(0) = a.Key).OrderBy(Function(x) x.Value).Select(Function(y) New With {.k = y.Key, .v = y.Value})
                For Each l In lst
                    Dim cnode As New TreeNode
                    With cnode
                        .Name = l.k
                        .Text = l.v
                        .Tag = "C"
                    End With
                    tnode.Nodes.Add(cnode)
                Next
            End With
            Trv.Nodes.Add(tnode)
        Next
    End Sub
End Class