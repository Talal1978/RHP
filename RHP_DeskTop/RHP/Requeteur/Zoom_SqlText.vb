Public Class Zoom_SqlText

    Private Sub Sql_Text_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sql_Text.DoubleClick
        With Sql_Text
            .Select()
            .SelectAll()
        End With
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class