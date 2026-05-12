Module Module_DPI
    Friend WithEvents otimer As New Timer
    Dim nb As Integer = 0
    <STAThread>
    Sub Main()
        Try
            If Environment.OSVersion.Version.Major >= 6 Then
                SetProcessDPIAware()
            End If
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Infinity_Main()
            With otimer
                .Interval = 1000
                .Start()
            End With
            System.Threading.Thread.Sleep(2000)
            Application.Run(New Login)
        Catch ex As Exception

        End Try

    End Sub
    Public Function ChargerLicence()
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\lic\WebLicence.ini") = False Then
            WebVersion = False
            Return False
        Else
            Dim sr As New IO.StreamReader(My.Application.Info.DirectoryPath & "\lic\WebLicence.ini", True)
            Dim line As String
            Dim i As Integer = 1

            line = sr.ReadLine()
            If line = "" Then Return False
            line = IsNull(Decrypt(line), "").Trim
            If line.EndsWith("|WEB$") Then
                WebVersion = True
                sr.Close()
                Return True
            Else
                WebVersion = False
                sr.Close()
                Return False
            End If
            sr.Close()
        End If
        Return True
    End Function
    Private Sub otimer_Tick(sender As Object, e As EventArgs) Handles otimer.Tick
        If Not Login_Demarrage.Visible Then Login_Demarrage.ShowDialog()
        nb += 1
        If nb > 1 Then
            otimer.Stop()
            Dim fadeOutTimer As New Timer()
            fadeOutTimer.Interval = 50 ' Adjust as needed
            AddHandler fadeOutTimer.Tick, Sub(sr, ev)
                                              Login_Demarrage.Opacity -= 0.1
                                              If Login_Demarrage.Opacity <= 0 Then
                                                  fadeOutTimer.Stop()
                                                  Login_Demarrage.Close()

                                              End If
                                          End Sub
            fadeOutTimer.Start()
            ' Login_Demarrage.Close()
        End If
    End Sub

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Function SetProcessDPIAware() As Boolean
    End Function
End Module
