Module Module_Timer_Abonnement
    Dim WithEvents BackG As New System.ComponentModel.BackgroundWorker
    Friend CodeAbonnement As Integer = -1
    Sub ExecuterAbonnement()
        If BackG.IsBusy Then Return
        If CodeAbonnement > 0 Then Return
        Dim CodSql As String = "select isnull((Select top 1 Cod_Abonnement from Param_Abonnement where isnull(Actif,'False')='True' and isnull(Nullif(Dat_Fin_Application,''),'01/01/2050')>getdate() and (convert(datetime,Dat_Next)<=getdate()or Dat_Next is null) and (isnull(Statut,0)=0 or isnull(Machine_Name,'')='')),-1)"
        If CodeAbonnement <= -1 Then Return
        CodeAbonnement = CnExecuting(CodSql).Fields(0).Value
        BackG.RunWorkerAsync()

    End Sub
    Sub bckGroundDoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackG.DoWork
        Try
            QueryExecuting(CodeAbonnement)
        Catch ex As Exception
        End Try
    End Sub
    Sub QueryExecuting(ByVal CodAbonnement As Integer)
        Try
            Dim cnAbn As New ADODB.Connection
            cnAbn.ConnectionString = connectionString
            cnAbn.CommandTimeout = 0
            cnAbn.Open()
            Dim rs As New ADODB.Recordset
            rs.Open("select * from Param_Abonnement  where Cod_Abonnement='" & CodAbonnement & "'", cnAbn, 2, 2)
            Dim sourceAbn As String = ""
            Dim RefAbn As String = ""
            If Not rs.EOF Then
                rs.Update()
                sourceAbn = rs("Source_Abonnement").Value
                RefAbn = rs("Ref_Abonnement").Value
                rs("Machine_Name").Value = My.Computer.Name
                rs("Statut").Value = 1
                rs("Process_Id").Value = ProcessId
                rs.Update()
            End If
            rs.Close()

            Dim Rapport As String = "OK"
            Dim DatExecut As Date = Now
            Dim NextDat As Date = NextDateAbonnement(CodAbonnement)
            Try
                Select Case sourceAbn
                    Case "Mailing"
                        CompagneMailing(RefAbn)
                    Case "Param_Query"
                        Dim f As New Param_Query_Saisi
                        With f
                            .Name = RefAbn
                            .Query_Generator(.Name, "")
                            .Request()
                            .Close()
                        End With
                    Case Else
                        Rapport = sourceAbn & " <=> " & RefAbn
                End Select
            Catch ex As Exception
                Rapport = ex.Message
            End Try
            cnAbn.Execute("Update Param_Abonnement set Dat_Next='" & NextDat & "',Statut=0  where Cod_Abonnement='" & CodAbonnement & "'")
            rs.Open("SELECT  *  FROM Param_Abonnement_Rapport", cnAbn, 2, 2)
            rs.AddNew()
            rs("Cod_Abonnement").Value = CodAbonnement
            rs("Dat_Execution").Value = DatExecut
            rs("Dat_Next").Value = NextDat
            rs("Rapport").Value = Rapport
            rs("Execute_Par").Value = GlobalVar("GV_USERNAME")
            rs("Execute_Machine").Value = GlobalVar("GV_NOMMACHINE")
            rs("Execute_IP").Value = GlobalVar("GV_IP")
            rs.Update()
            rs.Close()
            cnAbn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bckGroundRunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackG.RunWorkerCompleted
        CodeAbonnement = -1
    End Sub
End Module
