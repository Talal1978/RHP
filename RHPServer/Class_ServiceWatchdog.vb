Public Class Class_ServiceWatchdog
    Private Shared _lastNotificationActivity As DateTime = DateTime.Now
    Private Shared _lastMailingActivity As DateTime = DateTime.Now
    Private Const MAX_INACTIVITY_MINUTES As Integer = 15
    Public Shared Sub ReportNotificationActivity()
        _lastNotificationActivity = DateTime.Now
    End Sub

    Public Shared Sub ReportMailingActivity()
        _lastMailingActivity = DateTime.Now
    End Sub

    Public Shared Function IsNotificationStuck() As Boolean
        Return DateTime.Now.Subtract(_lastNotificationActivity).TotalMinutes > MAX_INACTIVITY_MINUTES
    End Function

    Public Shared Function IsMailingStuck() As Boolean
        Return DateTime.Now.Subtract(_lastMailingActivity).TotalMinutes > MAX_INACTIVITY_MINUTES
    End Function

    Public Shared Sub CheckHealth()
        If IsNotificationStuck() Then
            WriteLog("ALERTE: Service notifications bloqué depuis plus de 15 minutes", "Watchdog", True)
        End If
        If IsMailingStuck() Then
            WriteLog("ALERTE: Service mailing bloqué depuis plus de 15 minutes", "Watchdog", True)
        End If
    End Sub
End Class