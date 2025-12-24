Public Class Zoom_Notifications_Champs_TableRef
    Friend txtBox As New ud_TextBox
    Friend txtCell As DataGridViewCell = Nothing
    Friend dicCol As New Dictionary(Of String, String)
    Friend Table_Ref As String
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
    Private Sub Zoom_Notifications_Champs_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim lst = dicCol.Where(Function(x) x.Key.Split(".")(0) = Table_Ref).OrderBy(Function(x) x.Value).Select(Function(y) y.Value).ToList()
        For Each tb As String In lst
            Dim itm As New ListViewItem
            With itm
                .Name = tb
                .Text = tb
                .Checked = txtBox.Text.Trim.Split(";").Contains(tb)
            End With
            lv.Items.Add(itm)
        Next
    End Sub

    Private Sub pb_Save_Click(sender As Object, e As EventArgs) Handles pb_Save.Click
        Dim str As String = ""
        For Each itm As ListViewItem In lv.Items
            If itm.Checked Then
                str &= If(str = "", "", ";") & itm.Name
            End If
        Next
        txtBox.Text = str
        Me.Close()
    End Sub
End Class