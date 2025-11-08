Public Class Zoom_PBar
    Friend Tmr As New Timer

    Private Sub Zoom_PBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Tmr
            .Interval = 5
            .Start()
            AddHandler .Tick, AddressOf Actualiser
        End With
    End Sub
    Sub Actualiser()
        Etape.Text = EtapeStr
        Etape.Refresh()
    End Sub
End Class