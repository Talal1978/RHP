Public Class Wait
    Friend WithEvents fadeTimer As New Timer
    Dim conn As String = ""
    Dim delais As Integer = 0
    Dim leMenuIsShown As Boolean = False
    Friend lg As New Login
    Private Sub Wait_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = Login.Connection_lbl.Text
        hidingLogin()
        CenterControlInParent(waiting_pnl)
        fadeTimer.Interval = 100

    End Sub
    Sub hidingLogin()
        Dim hidingTimer As New Timer()
        hidingTimer.Interval = 30 ' Adjust as needed
        AddHandler hidingTimer.Tick, Sub()
                                         delais += hidingTimer.Interval
                                         If lg.Opacity < 0 Then
                                             fadeTimer.Start()
                                         ElseIf lg.Opacity <= 0.2 And Not leMenuIsShown Then
                                             lg.Hide()
                                             hidingTimer.Stop()
                                             With leMenu
                                                 .Navigator_ud.DB_lbl.Text = lg.Connection_lbl.Text
                                                 .Navigator_ud.DB_lbl.Refresh()
                                                 .AutoScaleMode = AutoScaleMode.Dpi
                                                 .Icon = My.Resources.rhp
                                                 Me.Owner = leMenu
                                                 .Show()
                                             End With
                                             leMenuIsShown = True
                                         Else
                                             lg.Opacity -= 0.1
                                         End If
                                     End Sub
        hidingTimer.Start()
    End Sub
    Sub fadeTimer_Tick(sender As Object, e As EventArgs) Handles fadeTimer.Tick
        ' Decrease opacity
        Me.Opacity -= 0.05
        ' If opacity is 0 or negative, close the form
        If Me.Opacity <= 0 Then
            fadeTimer.Stop()
            Me.Hide()
        End If
    End Sub
End Class
