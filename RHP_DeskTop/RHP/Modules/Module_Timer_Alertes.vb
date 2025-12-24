Module Module_Timer_Alertes
    Dim WithEvents AlrBKW As New System.ComponentModel.BackgroundWorker
    Dim onOff As Boolean = True
    Public Alertstr As String = ""
    Sub CheckAlertes()
        If onOff Then
            onOff = False
            AlrBKW.RunWorkerAsync()
        End If
    End Sub
    Sub AlrBKW_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles AlrBKW.DoWork
        On Error GoTo suite
        If Not Application.OpenForms().OfType(Of Zoom_Alerte).Any Then
            Dim NbAlertes As Integer = CnTempExecuting("select isnull(dbo.NbNewMsg_NonAlertes('" & theUser.id_User & "'),0)").Fields(0).Value
            If NbAlertes > 0 Then
                Dim NbNonLus As Integer = CnTempExecuting("Select dbo.NbNewMsg('" & theUser.id_User & "')").Fields(0).Value
                If NbAlertes > 1 Then
                    Alertstr = "Vous avez reçu " & NbNonLus & " nouveaux messages,"
                    If NbNonLus > 1 Then
                        Alertstr &= vbCrLf & "dont " & NbNonLus & " messages non lus."
                    End If
                Else
                    Alertstr = "Vous avez reçu un nouveau message."
                End If
            End If
        End If
suite:
    End Sub

    Private Sub AlrBKW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles AlrBKW.RunWorkerCompleted
        onOff = True
    End Sub

End Module
