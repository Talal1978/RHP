Public Class Zoom_NombreFormat
    Friend itsOk As Boolean = False

    Private Sub Ok_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        itsOk = True
        Me.Close()
    End Sub

    Private Sub Annuler_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        itsOk = False
        Me.Close()
    End Sub
End Class