Public Class Zoom_QueryPrinter
    Friend Grd As DataGridView
    Friend QueryName As String
    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub


    Private Sub Zoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

    End Sub

    Private Sub Print_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Print_pb.Click
        SColonnes.Clear()
        With Zoom_Grd
            .EndEdit()
            If .RowCount = 0 Then Exit Sub
            For i = 0 To .RowCount - 1
                If .Item(0, i).Value = True Then
                    SColonnes.Add(.Item(2, i).Value)
                End If
            Next
        End With
        NbCrt = 0
        StartReport = False
        Dim dlg As New PrintPreviewDialog()
        dlg.Document = QueryPrinter(Grd, QueryName)
        dlg.WindowState = FormWindowState.Maximized
        dlg.ShowDialog()


    End Sub

    Private Sub Inverser_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAll_pb.Click
        For i = 0 To Zoom_Grd.RowCount - 1
            If Zoom_Grd.Item(0, i).Value = "False" Then
                Zoom_Grd.Item(0, i).Value = "True"
            Else
                Zoom_Grd.Item(0, i).Value = "False"
            End If
        Next
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class