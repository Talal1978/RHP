Public Enum eAlertAnimation
    BottomToTop
    TopToBottom
    RightToLeft
    LeftToRight
End Enum
Public Class Zoom_Alerte_Msg
    Public AlertAnimation As eAlertAnimation = eAlertAnimation.BottomToTop
    Public AlertAnimationDuration As Integer = 10
    Public AutoClose As Boolean = True
    Public AutoCloseTimeOut As Integer = 2
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Enter
                Me.Close()
            Case Keys.Escape
                Me.Close()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
    Private Sub Zoom_Alerte_Msg_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Yy As Integer = My.Computer.Screen.Bounds.Height + 1
        Dim Xx As Integer = My.Computer.Screen.Bounds.Width - Me.Width - 2
        Dim h As Integer = 0
        Location = New Point(Xx, Yy)
        Dim tmr As New Timer
        Dim echelle As Integer = 5
        AlertAnimationDuration = 5000
        With tmr
            .Interval = (1 / echelle) * AlertAnimationDuration
            AddHandler .Tick, Sub()
                                  If h >= Height Then
                                      Location = New Point(Location.X, Yy)
                                      Yy -= echelle
                                      h += echelle
                                  Else
                                      .Stop()
                                      If AutoClose Then
                                          Threading.Thread.Sleep(AutoCloseTimeOut * 1000)
                                          Me.Close()
                                      End If
                                  End If
                              End Sub
            .Start()
        End With
    End Sub


End Class