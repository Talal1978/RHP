Imports System.Net
Module Module_Internet
    Function EstConnecteReseau(Optional ByVal UrlStr As String = "https://google.com") As Boolean
        Dim oUrl As System.Uri = New Uri(UrlStr)
        Return My.Computer.Network.Ping(oUrl)
    End Function
    Public Function estConnecte(ByVal url As String) As Boolean
        Try
            Using client As New WebClient()
                Using stream = client.OpenRead(url)
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

End Module
