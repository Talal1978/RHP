Module Module_infinity
    Dim WithEvents oTimer As New Timer
    Friend virtualui As New Cybele.Thinfinity.VirtualUI()
    Sub Infinity_Main()
        virtualui.Start()
        ''// virtualui.ClientSettings.MouseMoveGestureAction = MouseMoveGestureAction.MM_ACTION_WHEEL
        Application.EnableVisualStyles()
        '  Application.SetCompatibleTextRenderingDefault(False)
        '  Application.Run(New Zoom_Demmarage_Screen)
    End Sub
    Sub StartPrograme(fullnameProgram As String)
        If virtualui.Active Then
            virtualui.DownloadFile(fullnameProgram)
        Else
            Process.Start(fullnameProgram)
        End If
    End Sub
End Module
