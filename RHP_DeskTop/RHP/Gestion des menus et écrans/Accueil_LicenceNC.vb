Public Class Accueil_LicenceNC

    Sub Registering(ByVal sender As Object, ByVal e As EventArgs) Handles Register_pnl.Click, Register_pb.Click, Register_lbl.Click
        Zoom_Licencing.ShowDialog()
    End Sub

    Private Sub Accueil_LicenceNC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Droits.EstAuthentic Then

        End If
    End Sub

    Private Sub Accueil_LicenceNC_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        CenterControlInParent(Register_pnl)
    End Sub
End Class