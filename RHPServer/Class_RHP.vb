Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Class RHP
    Friend name As String = ""
    Friend db As String = ""
    Friend srv As String = ""
    Friend sqluser As String = ""
    Friend pw As String = ""
    Friend cntstr As String = ""
    Friend cn As New ADODB.Connection
    Friend TblSmtp As New DataTable
    Friend WithEvents BKG_Notif As New System.ComponentModel.BackgroundWorker
    Friend WithEvents BKG_Mailing As New System.ComponentModel.BackgroundWorker
    Friend WithEvents BKG_Param As New System.ComponentModel.BackgroundWorker
    Friend Busy_Notif As Boolean = False
    Friend Busy_Mailing As Boolean = False
    Friend Busy_Param As Boolean = False
    Dim ODBCRay1 As String = "RHP"
    Dim path As String = ""
    Dim pathImpression As String = ""
    Friend AbonnementActive As Boolean = False
    Private connectionLock As New Object()
    Sub BKG_Notif_Run(sender As Object, e As DoWorkEventArgs) Handles BKG_Notif.DoWork
        Try
            Busy_Notif = True

            ' Vérifier la santé de la connexion avant traitement
            If Not IsConnectionHealthy() Then
                WriteLog("Connexion défaillante - abandon notificationManager", name, True)
                Return
            End If

            Class_ServiceWatchdog.ReportNotificationActivity()
            notificationManager()
        Catch ex As Exception
            WriteLog("Erreur BKG_Notif: " & ex.Message, name, True)
        Finally
            Busy_Notif = False
        End Try
    End Sub
    Sub BKG_Notif_End(sender As Object, e As EventArgs) Handles BKG_Notif.RunWorkerCompleted
        Busy_Notif = False
    End Sub
    Sub BKG_Mailing_Run(sender As Object, e As DoWorkEventArgs) Handles BKG_Mailing.DoWork
        Try
            Busy_Mailing = True
            If Not IsConnectionHealthy() Then
                WriteLog("Connexion défaillante - abandon mailingManager", name, True)
                Return
            End If
            Class_ServiceWatchdog.ReportMailingActivity()  ' AJOUTÉ
            mailingManager()
        Catch ex As Exception
            WriteLog("Erreur BKG_Mailing: " & ex.Message, name, True)
        Finally
            Busy_Mailing = False
        End Try
    End Sub

    Sub BKG_Mailing_End(sender As Object, e As EventArgs) Handles BKG_Mailing.RunWorkerCompleted
        Busy_Mailing = False
    End Sub
    Sub BKG_Param_Run(sender As Object, e As DoWorkEventArgs) Handles BKG_Param.DoWork
        Busy_Param = True
        updateParam()
    End Sub
    Sub BKG_Param_End(sender As Object, e As EventArgs) Handles BKG_Param.RunWorkerCompleted
        Busy_Param = False
    End Sub
    Sub Intialisation()
        Try
            SyncLock connectionLock
                cn.ConnectionString = cntstr
                cn.ConnectionTimeout = 15  ' Réduire le timeout
                cn.CommandTimeout = 30     ' Réduire le timeout

                ' Tentative de connexion avec retry
                Dim retryCount As Integer = 0
                Dim maxRetries As Integer = 3

                Do While retryCount < maxRetries
                    Try
                        If cn.State = ADODB.ObjectStateEnum.adStateOpen Then cn.Close()
                        cn.Open()
                        Exit Do  ' Connexion réussie
                    Catch ex As Exception
                        retryCount += 1
                        If retryCount >= maxRetries Then
                            WriteLog($"Échec connexion après {maxRetries} tentatives: {ex.Message}", name, True)
                            Throw
                        End If
                        Threading.Thread.Sleep(1000 * retryCount)  ' Attente progressive
                    End Try
                Loop

                updateParam()
            End SyncLock
        Catch ex As Exception
            WriteLog("Erreur initialisation: " & ex.Message, name, True)
            Throw
        End Try
    End Sub
    Function IsConnectionHealthy() As Boolean
        Try
            SyncLock connectionLock
                If cn.State <> ADODB.ObjectStateEnum.adStateOpen Then Return False
                ' Test rapide de la connexion
                cn.Execute("SELECT 1")
                Return True
            End SyncLock
        Catch
            Return False
        End Try
    End Function
    Sub updateParam()
        TblSmtp = DATA_READER_GRD("select Top 1 * from Controle_Messagerie", cntstr)
        ODBCRay1 = findParam("ODBC_Ray1")
        path = findParam("Lecteur_Digital_Upload")
        pathImpression = findParam("Lecteur_Digital_Mod_Edition")
        AbonnementActive = (findParam("Activer_Abonnement") = "O")
    End Sub
    Function getNewSmtp() As System.Net.Mail.SmtpClient
        Dim smtpclient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
        If TblSmtp.Rows.Count > 0 Then
            If smtpclient.Host <> TblSmtp.Rows(0)("Smtp_Mail") Then
                smtpclient.Host = TblSmtp.Rows(0)("Smtp_Mail")
                smtpclient.Credentials = New Net.NetworkCredential(TblSmtp.Rows(0)("Mail_Addr"), Decrypt(TblSmtp.Rows(0)("Pwd_Mail")))
                smtpclient.Port = TblSmtp.Rows(0)("Port_Mail")
                smtpclient.EnableSsl = IsNull(TblSmtp.Rows(0)("Ssl_Actif"), False)
            End If
        Else
            WriteLog("Erreur 100 : Paramétrage smtp non fourni.", Me.name, True)
        End If
        Return smtpclient
    End Function
    Sub mailingManager()
        Dim CodSql As String = "Select * from Param_Abonnement where isnull(Actif,'False')='True' 
                                and isnull(Nullif(Dat_Fin_Application,''),'01/01/2050')>getdate() 
                               and (convert(datetime,Dat_Next)<=getdate()or Dat_Next is null) 
                               and (isnull(Statut,0)=0 or isnull(Machine_Name,'')='') 
                                and Source_Abonnement ='Mailing'
                                order by convert(datetime,Dat_Next)"
        Dim Tbl As DataTable = DATA_READER_GRD(CodSql, cntstr)
        WriteLog("Mailing Manager : nombre de compagnes mail : " & Tbl.Rows.Count, name, False)
        With Tbl
            For i = 0 To Tbl.Rows.Count - 1
                WriteLog("Abonnement : " & .Rows(i)("Cod_Abonnement") & " => " & .Rows(i)("Ref_Abonnement"), name, False)
                cn.Execute("update Param_Abonnement set Statut=1 where Cod_Abonnement='" & .Rows(i)("Cod_Abonnement") & "'")
                Dim DatExec As Date = Now
                Dim rapport As String = CompagneMailing(.Rows(i)("Ref_Abonnement"))
                Dim NextDat As Date = NextDateAbonnement(.Rows(i)("Cod_Abonnement"), cntstr)
                Dim ws As New ADODB.Recordset
                cn.Execute("Update Param_Abonnement set Dat_Next='" & NextDat & "',Statut=0  where Cod_Abonnement='" & .Rows(i)("Cod_Abonnement") & "'")
                ws.Open("SELECT  *  FROM Param_Abonnement_Rapport", cn, 2, 2)
                ws.AddNew()
                ws("Cod_Abonnement").Value = .Rows(i)("Cod_Abonnement")
                ws("Dat_Execution").Value = DatExec
                ws("Dat_Next").Value = NextDat
                ws("Rapport").Value = rapport
                ws("Execute_Par").Value = "Serveur"
                ws("Execute_Machine").Value = "Serveur"
                ws("Execute_IP").Value = "0.0.0.0"
                ws.Update()
                ws.Close()
                WriteLog("Abonnement : " & .Rows(i)("Cod_Abonnement") & " => " & .Rows(i)("Ref_Abonnement") & " (" & rapport & ")", name, False)
            Next
        End With


    End Sub
    Sub notificationManager()
        If Not IsConnectionHealthy() Then
            WriteLog("Connexion défaillante au début de notificationManager", Me.name, True)
            Return
        End If
        Dim oMail As New MailMessage
        Dim TblNotif As DataTable = DATA_READER_GRD("select * from Notifications where isnull(Actif,'false')='true'", cntstr)
        Dim nrw() As DataRow
        Dim Att As String = ""
        Dim Cc As String = ""
        Dim Cci As String = ""
        Dim corps As String = ""
        Dim titre As String = ""
        Dim dateDeb As String = ""
        Dim dateFin As String = ""
        Dim crReport As String = ""
        Dim TblPJ As New DataTable
        Dim crParam, crValeur, crAttach As New ArrayList
        Dim rg As New Regex("\b(\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\b")
        Dim rgIdUser As New System.Text.RegularExpressions.Regex(cn.Execute("SELECT '\\b(' + STRING_AGG(CAST(id_User AS VARCHAR), '|') + ')\\b' FROM Controle_Users WHERE id_User IS NOT NULL").Fields(0).Value)
        Dim FichierPJ As String = ""
        If Not IO.Directory.Exists("PDF") Then IO.Directory.CreateDirectory("PDF")
        Dim rnd As New Random
        Dim rowId As Integer = -1
        Try
            Dim takeSql As String =
"WITH C AS (
  SELECT TOP (1) *
  FROM Notification_Events WITH (READPAST, ROWLOCK, UPDLOCK)
  WHERE ISNULL(Notified,'false')='false' and isnull(Cod_Notification,'')!=''
    AND (ISNULL(ProcessStarted,'false')='false'
         OR DATEDIFF(MINUTE, ISNULL(ProcessStartedAt,'19000101'), GETDATE()) > 15)
  ORDER BY CASE WHEN ISNULL(Result,'') = '' THEN 0 ELSE 1 END, ISNULL(ProcessStartedAt, '19000101'), RowId 
)
UPDATE C
   SET ProcessStarted = 1,
       ProcessStartedAt = GETDATE()
OUTPUT INSERTED.RowId, INSERTED.Cod_Notification, INSERTED.Val_Index;"

            If Not IsConnectionHealthy() Then
                WriteLog("Connexion défaillante avant requête SQL", Me.name, True)
                Return
            End If

            Dim taken As ADODB.Recordset = cn.Execute(takeSql)
            If taken.EOF Then
                WriteLog("Aucun événement à traiter", Me.name, False)
                Return
            End If

            rowId = CInt(taken.Fields("RowId").Value)
            Dim codNotif As String = CStr(taken.Fields("Cod_Notification").Value)
            Dim valIndex As String = CStr(taken.Fields("Val_Index").Value)
            WriteLog(codNotif & " (" & rowId & ")", Me.name, False)

            nrw = TblNotif.Select("Cod_Notification='" & codNotif.Replace("'", "''") & "'")
            If nrw.Length = 0 Then
                cn.Execute("UPDATE Notification_Events SET Result='Erreur 104: Référence de notification inexistente.', ProcessStarted=0 WHERE RowId=" & rowId)
                Return
            Else
                Dim SqlPattern = IsNull(nrw(0)("SqlPattern"), "").Replace("@@@ValIndex", valIndex)
                Dim TblTask As DataTable = DATA_READER_GRD(SqlPattern, cntstr)
                crReport = IIf(IsNull(nrw(0)("Externe"), False), IsNull(nrw(0)("Cod_Report"), ""), "").trim
                If crReport.Trim <> "" Then
                    TblPJ = GenererReport(nrw(0)("Cod_Notification"), crReport, "N")
                    With TblPJ
                        For i = 0 To .Rows.Count - 1
                            crParam.Add(.Rows(i)("Critere"))
                        Next
                    End With
                End If

                If TblTask IsNot Nothing Then
                    If TblTask.Rows.Count > 0 Then
                        With TblTask
                            For i = 0 To .Rows.Count - 1
                                Att = IsNull(nrw(0)("Destinataires"), "")
                                Cc = IsNull(nrw(0)("Cc"), "")
                                Cci = IsNull(nrw(0)("Cci"), "")
                                corps = IsNull(nrw(0)("Corps"), "")
                                titre = IsNull(nrw(0)("Objet"), "")
                                dateDeb = IsNull(nrw(0)("Dat_Deb"), Now)
                                dateFin = IsNull(nrw(0)("Dat_Fin"), DateAdd(DateInterval.Minute, 30, Now))
                                If crReport.Trim <> "" Then
                                    crAttach.Clear()
                                    crValeur.Clear()
                                    With TblPJ
                                        For k = 0 To .Rows.Count - 1
                                            crValeur.Add(.Rows(k)("Default_Value"))
                                        Next
                                    End With
                                End If
                                For j = 0 To TblTask.Columns.Count - 1
                                    Att = Att.Replace(.Columns(j).ColumnName, IsNull(.Rows(i)(j), ""))
                                    Cc = Cc.Replace(.Columns(j).ColumnName, IsNull(.Rows(i)(j), ""))
                                    Cci = Cci.Replace(.Columns(j).ColumnName, IsNull(.Rows(i)(j), ""))
                                    corps = corps.Replace(.Columns(j).ColumnName, IsNull(.Rows(i)(j), ""))
                                    titre = titre.Replace(.Columns(j).ColumnName, IsNull(.Rows(i)(j), ""))
                                    dateDeb = dateDeb.Replace(.Columns(j).ColumnName, IsNull(.Rows(i)(j), Now))
                                    dateFin = dateFin.Replace(.Columns(j).ColumnName, IsNull(.Rows(i)(j), Now.AddHours(1)))
                                    For k = 0 To crValeur.Count - 1
                                        crValeur(k) = crValeur(k).Replace(.Columns(j).ColumnName, IsNull(.Rows(i)(j), ""))
                                    Next
                                Next
                                If IsNull(nrw(0)("Externe"), False) Then
                                    If rg.IsMatch(Att) Then
                                        Dim str As String = ""
                                        For Each c As Match In rg.Matches(Att)
                                            str &= IIf(str = "", "", ";") & c.Value
                                        Next
                                        Att = str
                                        str = ""
                                        For Each c As Match In rg.Matches(Cc)
                                            str &= IIf(str = "", "", ";") & c.Value
                                        Next
                                        Cc = str
                                        str = ""
                                        For Each c As Match In rg.Matches(Cci)
                                            str &= IIf(str = "", "", ";") & c.Value
                                        Next
                                        Cci = str
                                        If IsNull(nrw(0)("Agenda"), False) Then
                                            If Not IsDate(dateDeb) Or Not IsDate(dateFin) Then
                                                cn.Execute("UPDATE Notification_Events " &
           "SET Result='Erreur 107: Erreur format datetime : " & vbCrLf & dateDeb & vbCrLf & dateFin & "', " &
           "     ProcessStarted=0 " &
           "WHERE RowId=" & rowId)
                                                Continue For
                                            End If
                                            dateDeb = CDate(dateDeb)
                                            dateFin = CDate(dateFin)
                                        End If
                                        'Générer les états crystal report
                                        If crReport.Trim <> "" Then
                                            FichierPJ = "PDF\" & rnd.Next(1000, 9999) & ".pdf"
                                            RptExportingToPdf(crReport, crParam, crValeur, FichierPJ)
                                            If IO.File.Exists(FichierPJ) Then
                                                crAttach.Add(FichierPJ)
                                            End If
                                        End If
                                        If envoiDeMail(getNewSmtp(), TblSmtp.Rows(0).Item("Mail_From"), Att, Cc, titre, corps, crAttach, "", Cci, IsNull(nrw(0)("Agenda"), False), CDate(IIf(IsNull(nrw(0)("Agenda"), False), dateDeb, Now)), CDate(IIf(IsNull(nrw(0)("Agenda"), False), dateFin, Now.AddMinutes(30)))) Then
                                            cn.Execute("UPDATE Notification_Events " &
           "SET Result='Succes: Notifié à " & Replace(Att, "'", "''") & "', " &
           "    Notified=1, Dat_Notif=GETDATE(), ProcessStarted=0 " &
           "WHERE RowId=" & rowId)
                                        Else
                                            cn.Execute("UPDATE Notification_Events " &
           "SET Result='Erreur 106: échec d''envoi de notification " & Replace(Att, "'", "''") & "', " &
           "    ProcessStarted=0 " &
           "WHERE RowId=" & rowId)
                                        End If
                                    Else
                                        cn.Execute("UPDATE Notification_Events " &
           "SET Result='Erreur 105: Le champs ''Destinataire'' ne comporte pas d''email valide : " & Replace(Att, "'", "''") & "', " &
           "    ProcessStarted=0 " &
           "WHERE RowId=" & rowId)
                                    End If
                                End If
                                If IsNull(nrw(0)("Interne"), False) Then
                                    Try
                                        Dim ws As New ADODB.Recordset
                                        ws.Open("select * from Workflow_Msg", cn, 1, 3)
                                        ws.AddNew()
                                        ws("Id_Sender").Value = "-1"
                                        ws("Objet").Value = titre
                                        ws("Dat_Msg").Value = Now
                                        ws("Message").Value = corps
                                        ws("Lien").Value = findLibelle("Name_Ecran", "Table_Ref", nrw(0)("Table_Ref"), "Controle_Def_Ecran") & "\" & valIndex
                                        ws("PJ").Value = ""
                                        ws("Supprime").Value = ""
                                        ws.Update()
                                        Dim idMsg As Integer = ws("Id_Msg").Value
                                        ws.Close()
                                        For Each c As System.Text.RegularExpressions.Match In rgIdUser.Matches(Att)
                                            cn.Execute("insert into Workflow_Msg_To (Id_Msg, Id_To,Lu) values ('" & idMsg & "','" & c.Value & "','N')")
                                        Next
                                        For Each c As System.Text.RegularExpressions.Match In rgIdUser.Matches(Cc)
                                            cn.Execute("insert into Workflow_Msg_To (Id_Msg, Id_To,Lu) values ('" & idMsg & "','" & c.Value & "','N')")
                                        Next
                                        For Each c As System.Text.RegularExpressions.Match In rgIdUser.Matches(Cci)
                                            cn.Execute("insert into Workflow_Msg_To (Id_Msg, Id_To,Lu) values ('" & idMsg & "','" & c.Value & "','N')")
                                        Next
                                        cn.Execute("UPDATE Notification_Events " &
           "SET Result='Succes: Notifié à " & Replace(Att, "'", "''") & "', " &
           "    Notified=1, Dat_Notif=GETDATE(), ProcessStarted=0 " &
           "WHERE RowId=" & rowId)
                                    Catch ex As Exception
                                        cn.Execute("UPDATE Notification_Events " &
           "SET Result='Erreur 109: échec d'envoi de notification interne." & vbCrLf & ex.Message.Replace("'", "''") & "', ProcessStarted=0 WHERE RowId=" & rowId)

                                    End Try
                                End If
                            Next
                        End With
                    Else
                        cn.Execute("UPDATE Notification_Events " &
           "SET Result='Erreur 101: Conditions non applicables : résultat Sql pattern = " & Replace(vbCrLf & SqlPattern, "'", "''") & "', " &
           "    ProcessStarted=0 " &
           "WHERE RowId=" & rowId)
                    End If
                Else
                    cn.Execute("UPDATE Notification_Events " &
           "SET Result='Erreur 102:  Sql_Pattern de la table [Notifications].', " &
           "    ProcessStarted=0 " &
           "WHERE RowId=" & rowId)
                End If
            End If
        Catch ex As Exception
            WriteLog("Erreur notificationManager: " & ex.Message, Me.name, True)
            Try
                WriteLog("Erreur notificationManager: " & ex.Message, Me.name, True)
                cn.Execute("UPDATE Notification_Events SET Result='Erreur système: " & Replace(ex.Message, "'", "''") & "', ProcessStarted=0 WHERE RowId=" & rowId)
            Catch
                ' Si on ne peut pas mettre à jour le recordset, on log seulement
            End Try
        End Try
    End Sub
    Function CompagneMailing(ByVal CodMailing As String) As String
        Try
            Dim cn As New ADODB.Connection
            cn.ConnectionString = cntstr
            cn.ConnectionTimeout = 0
            cn.CommandTimeout = 0
            cn.Open()
            cn.Execute("delete from mailing_Rapport where  Cod_Mailing='" & CodMailing & "'")

            Dim rs, rsq, rsqc, rsml, rstr As New ADODB.Recordset
            Dim SqlQuery As String = ""
            Dim HeaderStr As String = ""
            Dim FooterStr As String = ""
            Dim Sujet As String = ""
            Dim QueryHTML As String = ""
            Dim CodSqlTmp As String = ""
            Dim HeaderStrTmp As String = ""
            Dim FooterStrTmp As String = ""
            Dim SujetTmp As String = ""
            Dim HeaderVisible As Boolean = False
            Dim entTableHTML As String = ""
            Dim Num As String = "0"
            Dim CodQuery As String = ""
            Dim crReport As String = ""
            Dim crParam, crValeur, crValeurTmp, crAttach, PJattach As New ArrayList
            Dim FichierPJ As String = ""
            If Not IO.Directory.Exists("PDF") Then IO.Directory.CreateDirectory("PDF")
            Dim rnd As New Random

            rs.Open("select * from mailing where Cod_Mailing='" & CodMailing & "'", cn, 3, 3)
            If Not rs.EOF Then
                HeaderStr = IsNull(rs("Header_Mail").Value, "")
                FooterStr = IsNull(rs("Footer_Mail").Value, "")
                Sujet = IsNull(rs("Sujet_Mail").Value, "")
                CodQuery = IsNull(rs("Cod_Query").Value, "")
                crReport = IsNull(rs("Cod_Report").Value, "")
                'Charger les attachements
                Dim TblPJ As DataTable = DATA_READER_GRD("select Nom_Fichier,isnull(Extension,'') as Extension from mailing_PJ where Cod_Mailing='" & CodMailing & "' order by Rang", cntstr)
                With TblPJ
                    For i = 0 To .Rows.Count - 1
                        FichierPJ = IsNull(.Rows(i)("Nom_Fichier") & .Rows(i)("Extension"), "")
                        If FichierPJ <> "" Then
                            FichierPJ = "PJ\" & FichierPJ
                            If IO.File.Exists(FichierPJ) Then
                                PJattach.Add(FichierPJ)
                            End If
                        End If
                    Next
                End With
                'Préparer les paramètre de Crystal report
                crParam.Clear()
                crValeur.Clear()
                crValeurTmp.Clear()
                crAttach.Clear()
                If crReport.Trim <> "" Then
                    TblPJ = GenererReport(CodMailing, crReport)
                    With TblPJ
                        For i = 0 To .Rows.Count - 1
                            crParam.Add(.Rows(i)("Critere"))
                            crValeur.Add(.Rows(i)("Default_Value"))
                        Next
                    End With
                End If
                'La compagne mailing contient une requête
                If CodQuery.Trim <> "" Then
                    HeaderVisible = IsNull(findLibelle("HeaderVisible", "Cod_Query", rs("Cod_Query").Value, "Param_Query"), False)
                    SqlQuery = GenererQuery(CodMailing, CodQuery)
                Else
                    SqlQuery = ""
                    HeaderVisible = False
                End If

                rsml.Open(GenererMailingList(rs("Mailing_List").Value), cn, 3, 3)
                While Not rsml.EOF

                    SujetTmp = Sujet
                    HeaderStrTmp = HeaderStr
                    FooterStrTmp = FooterStr
                    CodSqlTmp = SqlQuery
                    crValeurTmp.Clear()
                    crAttach.Clear()
                    For n = 0 To crValeur.Count - 1
                        crValeurTmp.Add(crValeur(n))
                    Next
                    For i = 0 To rsml.Fields.Count - 1
                        Dim rg As New System.Text.RegularExpressions.Regex("@@@" & rsml.Fields.Item(i).Name, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                        SujetTmp = rg.Replace(SujetTmp, IsNull(rsml(i).Value, ""))
                        HeaderStrTmp = rg.Replace(HeaderStrTmp, IsNull(rsml(i).Value, ""))
                        FooterStrTmp = rg.Replace(FooterStrTmp, IsNull(rsml(i).Value, ""))
                        If CodSqlTmp <> "" Then CodSqlTmp = rg.Replace(CodSqlTmp, IsNull(rsml(i).Value, ""))
                        If crReport.Trim <> "" Then
                            For n = 0 To crValeurTmp.Count - 1
                                crValeurTmp(n) = rg.Replace(crValeurTmp(n).ToString, IsNull(rsml(i).Value, ""))
                            Next
                        End If
                    Next
                    'Générer les états crystal report
                    If crReport.Trim <> "" Then

                        FichierPJ = "PDF\" & rnd.Next(1000, 9999) & ".pdf"

                        RptExportingToPdf(crReport, crParam, crValeurTmp, FichierPJ)

                        If IO.File.Exists(FichierPJ) Then
                            crAttach.Add(FichierPJ)
                        End If

                        For i = 0 To PJattach.Count - 1
                            crAttach.Add(PJattach(i))
                        Next

                    End If
                    'Préparation du Corps du mail
                    'Encodage vers Html
                    '  SujetTmp = encodeToHtml(SujetTmp)

                    HeaderStrTmp = encodeToHtml(HeaderStrTmp)

                    FooterStrTmp = encodeToHtml(FooterStrTmp)

                    ' table de la requête

                    If CodSqlTmp <> "" Then

                        Dim TblQuery As DataTable = DATA_READER_GRD(CodSqlTmp, cntstr)
                        With TblQuery
                            If .Rows.Count > 0 Then
                                QueryHTML = "<center><table >"
                                'Entete table html
                                If HeaderVisible = True And entTableHTML = "" Then
                                    entTableHTML &= "<tr style='background-color:#999999;font-weight:bold'>"
                                    For j = 0 To .Columns.Count - 1
                                        entTableHTML &= "<td valign=""middle"" style=""padding:0 3px 0 3px;text-align:center;"">" & encodeToHtml(.Columns(j).ColumnName) & "</td>"
                                    Next
                                    entTableHTML &= "</tr>"
                                End If
                                QueryHTML &= entTableHTML
                                'ligne table <tr> et <td>
                                For i = 0 To .Rows.Count - 1
                                    QueryHTML &= "<tr>"
                                    For k = 0 To .Columns.Count - 1
                                        If .Columns(k).DataType = System.Type.GetType("System.Decimal") Or .Columns(k).DataType = System.Type.GetType("System.Double") Then
                                            Num = CStr(FormatNumber(IsNull(.Rows(i)(k), 0), 2)) ' .Replace(Chr(160), "&nbsp;")
                                            QueryHTML &= "<td align='right' style=""padding:0 3px 0 3px;"">" & Num & "</td>"
                                        Else
                                            QueryHTML &= "<td style=""padding:0 3px 0 3px;"">" & encodeToHtml(IsNull(.Rows(i)(k), "")) & "</td>"
                                        End If
                                    Next
                                    QueryHTML &= "</tr>"
                                Next
                                QueryHTML &= "</table></center>"
                            Else
                                QueryHTML = ""
                            End If
                        End With
                    End If

                    Dim Objet As String = "<body>" & HeaderStrTmp & "<BR/>" & QueryHTML & "<BR/>" & FooterStrTmp & "</body>"
                    Objet = Objet.Replace("@@@espace", "<BR/>")
                    If (CodQuery.Trim <> "" And QueryHTML <> "") Or (CodQuery.Trim = "" And QueryHTML = "") Then
                        Dim envoye As Integer = envoiDeMail(getNewSmtp(), TblSmtp.Rows(0).Item("Mail_From"), rsml("Email").Value, IsNull(rs("CC").Value, ""), SujetTmp, Objet, crAttach, IsNull(rs("ReplyTo").Value, ""), IsNull(rs("CCi").Value, ""))

                        cn.Execute("insert into mailing_Rapport (Cod_Mailing, id_Destinataire, Dat_Envoi, envoye) values ('" & CodMailing & "','" & rsml("id_Destinataire").Value & "',getdate(),'" & envoye & "')  ")
                    End If
                    ' Dim sw As New IO.StreamWriter("D:\mailing[" & rsml("Email").Value & "].html", True)
                    '   sw.Write(Objet)
                    '  sw.Close()
                    rsml.MoveNext()
                End While
                rsml.Close()
            End If
            rs.Close()
            Return "Succès"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Function findLibelle(ByVal LibelleToFind As String, ByVal oCode As String, ByVal Valeur_Code As String, ByVal oTbl As String, Optional ByVal AfficherSql As Boolean = False) As Object
        Dim Resultat As Object
        Dim _str As String = "select " & LibelleToFind & " From " & oTbl & " where " & oCode & "='" & Valeur_Code & "'"
        Dim fDataTbl As DataTable = DATA_READER_GRD(_str, cntstr)
        Dim oDefault As String = ""
        If fDataTbl.Columns.Count > 0 Then
            If fDataTbl.Columns(0).DataType.ToString.Contains("Int") Then
                oDefault = 0
            ElseIf fDataTbl.Columns(0).DataType.ToString.Contains("Bool") Then
                oDefault = False
            ElseIf fDataTbl.Columns(0).DataType.ToString.Contains("Double") Then
                oDefault = 0
            End If
        End If
        If fDataTbl.Rows.Count > 0 Then
            Resultat = IsNull(fDataTbl.Rows(0).Item(0), oDefault)
        Else
            Resultat = oDefault
        End If
        Return Resultat
    End Function
    Public Function findParam(ByVal Valeur As String) As Object
        Dim Rslt As Object = Nothing
        Dim Tbl As DataTable = DATA_READER_GRD("select Cod_Param, Valeur,isnull(Type,'') as type
from Param_General 
where Cod_Param='" & Valeur & "'", cntstr)
        If Tbl.Rows.Count > 0 Then
            Rslt = Tbl.Rows(0).Item("Valeur")
            Select Case Tbl.Rows(0).Item("Type")
                Case "Boolean__"
                    Return CBool(IIf(IsNull(Rslt, "") = "O", True, False))
                Case "Calender"
                    If Not IsDate(Rslt) Then
                        Rslt = "01/01/1900 00:00"
                    End If
                    Return CDate(Rslt)
                Case "Ent", "Entier"
                    If Not IsNumeric(Rslt) Then
                        Rslt = 0
                    End If
                    Return CInt(Rslt)
                Case "Numeric", "Double"
                    If Not IsNumeric(Rslt) Then
                        Rslt = 0
                    End If
                    Return CDbl(Rslt)
                Case Else
                    Return CStr(IsNull(Rslt, ""))
            End Select
        End If
        If Left(IsNull(Rslt, ""), 3) = "GV_" Then
            Return GlobalVar(Rslt)
        End If
        Return Rslt
    End Function
    Function GlobalVar(ByVal GV As String) As String
        Dim GVVal As String = ""
        Select Case GV.ToUpper.Trim
            Case "GV_USER"
                GVVal = -1
            Case "GV_LOGIN"
                GVVal = "RHP"
            Case "GV_PROFIL"
                GVVal = 1
            Case "GV_USERNAME"
                GVVal = "RHP"
            Case "GV_USERSERVICE"
                GVVal = "RHP"
            Case "GV_CONN"
                GVVal = cntstr
            Case "GV_DB"
                GVVal = db
            Case "GV_DATDEBEXERCICE"
                GVVal = Nothing  'DatDebExercice
            Case "GV_DATSTOCKINITIAL"
                GVVal = Nothing  'DatStockInitial
            Case "GV_DATFINEXERCICE"
                GVVal = Nothing  'DatFinExercice
            Case "GV_NOW"
                GVVal = FormatDateTime(Now.Date, DateFormat.ShortDate)
            Case "GV_DEBMOIS"
                GVVal = "01/" & IIf(CStr(Now.Date.Month).Length < 2, "0" & CStr(Now.Date.Month), CStr(Now.Date.Month)) & "/" & CStr(Now.Date.Year)
            Case "GV_FINMOIS"
                GVVal = CStr(DateTime.DaysInMonth(Now.Date.Year, Now.Date.Month)) & "/" & IIf(CStr(Now.Date.Month).Length < 2, "0" & CStr(Now.Date.Month), CStr(Now.Date.Month)) & "/" & CStr(Now.Date.Year)
            Case "GV_YEAR"
                GVVal = Now.Year
            Case "GV_MONTH"
                GVVal = Now.Month
            Case "GV_DAY"
                GVVal = Now.Day
            Case "GV_NOMMACHINE"
                GVVal = "RHP"
            Case "GV_IP"
                GVVal = "RHP"
            Case "GV_PROCESSID"
                GVVal = 0
            Case "GV_NUMVERSION"
                GVVal = NumVersion
            Case "GV_DEBYEAR"
                GVVal = "01/01/" & Now.Year
            Case "GV_URL"
                GVVal = ""
        End Select
        Return GVVal
    End Function
    Function GenererMailingList(CodList As Integer) As String
        Dim Cod_Sql As String = ""
        Cod_Sql = "select Civilite, Nom, Prenom,Email, isnull(Membre,'') as 'Typ_Tiers', 
        isnull(Cod_Tiers,'') as Code, isnull(Nom_Tiers,'') as Tiers, isnull(Fonction,'') as Fonction,id_Destinataire
        from mailing_Destinataire d
        outer apply (select Membre from Param_Rubriques where Nom_Controle like 'Typ_Tiers' and Valeur=isnull(Typ_Tiers,''))c
        where liste like '%," & CodList & ",%' or liste like '%," & CodList & "' or liste like '" & CodList & ",%'
        order by isnull(Nom_Tiers,''), Nom, Prenom"
        Return Cod_Sql
    End Function
    Function Query_Converter(ByVal CodQuery As String, ByVal Variables As String) As String
        On Error Resume Next
        Dim qConn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim Declaration As String = ""
        Dim affectation As String = ""
        Dim CodSql As String = ""
        qConn.ConnectionString = cntstr
        qConn.Open()
        rs.Open("Select * from Param_Query_Criteres where Cod_Query='" & CodQuery & "' order by Rang asc", qConn, 3, 3)
        Do While Not rs.EOF
            Declaration = Declaration & "Declare " & rs("Critere").Value & " " & rs("Typ_Critere").Value & vbCrLf
            rs.MoveNext()
        Loop
        rs.Close()
        Dim k As Integer = 0
        rs.Open("Select * from Param_Query_Criteres where Cod_Query='" & CodQuery & "' order by Rang asc", qConn, 3, 3)
        Do While Not rs.EOF
            affectation = affectation & "set " & rs("Critere").Value & " = " & Split(Variables, "#")(k) & vbCrLf
            k += 1
            rs.MoveNext()
        Loop
        rs.Close()
        CodSql = Declaration & affectation & findLibelle("Cod_Sql", "Cod_Query", CodQuery, "Param_Query")
        qConn.Close()
        Return CodSql
    End Function
    Function GetDefaultValue(ByVal CodQuery As String, ByVal Relation As String, Optional Typ As String = "SQL") As String
        Dim Variable As New ArrayList
        Dim ValeurVariable As New ArrayList
        Dim Indx, TblX As String
        If Typ = "RPT" Then
            Indx = "Cod_Report"
            TblX = "Param_Mod_Edition_Criteres"
        Else
            Indx = "Cod_Query"
            TblX = "Param_Query_Criteres"
        End If
        Dim TblCriteres As DataTable = DATA_READER_GRD("select Critere,Default_Value, Default_Value as Valeur from " & TblX & " where " & Indx & "='" & CodQuery & "'", cntstr)
        TblCriteres.Columns("Valeur").ReadOnly = False
        Try
            ' Chargement des variables de critères et leurs valeurs
            If Microsoft.VisualBasic.Left(Relation, 1) = Chr(34) Then
                Relation = Relation.Replace(Chr(34), "")
            End If
            If Microsoft.VisualBasic.Left(Relation, 1) = "{" Then
                Relation = Relation.Replace("{", "").Replace("}", "")
                '   If Relation.Contains("#") Then
                '  Dim Tbl As String() = Relation.Split("#")
                '  For j = 1 To Tbl.Length - 1 Step 2
                '  Variable.Add("#" & Tbl(j).Split(" ")(0))
                '   ValeurVariable.Add(Sql_Grd.Item(CInt(Tbl(j).Split(" ")(0)), Sql_Grd.CurrentRow.Index).Value)
                ' Next
                '  end If
                If Relation.Contains("@") Then
                    With TblCriteres
                        For j = 0 To .Rows.Count - 1
                            If Relation.ToUpper.Contains(CStr(.Rows(j).Item("Critere").ToUpper)) Then
                                Variable.Add(.Rows(j).Item("Critere").ToUpper)
                                ValeurVariable.Add(.Rows(j).Item("Valeur").ToUpper)
                            End If
                        Next
                    End With
                End If
                For j = 0 To Variable.Count - 1
                    If Relation.ToUpper.Contains(CStr(Variable(j).toupper)) Then
                        Relation = Relation.Replace(Variable(j), "'" & ValeurVariable(j) & "'")
                    End If
                Next
                Relation = IsNull(cn.Execute(Relation).Fields(0).Value, "")
                'Cas des Variables globales
            ElseIf Relation.ToString.Trim.ToUpper.Contains("GV_") Then
                Relation = GlobalVar(Relation.Trim.ToString)
            End If
        Catch ex As Exception
            WriteLog(ex.Message, name, True)
        End Try
        Return Relation
    End Function
    Function GenererQuery(CodMailing As String, CodQuery As String) As String
        Dim SqlCrit As String = "Select Critere,isnull(Valeur,Default_Value) as Default_Value  from Param_Query_Criteres q
            outer apply (select isnull(Valeur,'') as Valeur from mailing_Critere where isnull(Typ_Query,'')='SQL' and Cod_Mailing='" & CodMailing & "' and Cod_Query=q.Cod_Query and Critere=q.Critere) m
            where Cod_Query ='" & CodQuery & "' 
            order by rang"
        Dim TblCriteres As DataTable = DATA_READER_GRD(SqlCrit, cntstr)
        Dim oRelation As String = ""
        With TblCriteres
            For i = 0 To .Rows.Count - 1
                oRelation &= IIf(oRelation = "", "", "#") & "'" & GetDefaultValue(CodQuery, .Rows(i).Item("Default_Value")) & "'"
            Next
        End With
        Return Query_Converter(CodQuery, oRelation)
    End Function
    Function GenererReport(CodMailing As String, CodReport As String, Optional TypSource As String = "M") As DataTable
        Dim SqlCrit As String = "Select Critere,isnull(Valeur,Default_Value) as Default_Value  from Param_Mod_Edition_Criteres q
            outer apply (select isnull(Valeur,'') as Valeur from " & IIf(TypSource = "N", "Notifications", "Mailing") & "_Critere where isnull(Typ_Query,'')='RPT' and Cod_" & IIf(TypSource = "N", "Notification", "Mailing") & "='" & CodMailing & "' and Cod_Query=q.Cod_Report and Critere=q.Critere) m
            where Cod_Report ='" & CodReport & "' 
            order by rang"
        Dim TblCriteres As DataTable = DATA_READER_GRD(SqlCrit, cntstr)
        With TblCriteres
            .Columns("Default_Value").ReadOnly = False
            For i = 0 To .Rows.Count - 1
                .Rows(i)("Default_Value") = GetDefaultValue(CodReport, .Rows(i)("Default_Value"), "RPT")
            Next
        End With
        Return TblCriteres
    End Function
    Sub RptExportingToPdf(etat As String, ParamList As ArrayList, ValList As ArrayList, FileName As String)
        Try

            Dim cryRpt As New ReportDocument
            If ODBCRay1 = "" Then
                WriteLog("ODBC non renseigné dans les paramétres généraux", name, True)
                Exit Sub
            End If

            Dim DataBaseName As String = db.ToUpper
            etat = pathImpression & "\" & etat & ".rpt"

            With cryRpt
                .Load(etat)
                .DataSourceConnections(0).SetConnection(ODBCRay1, DataBaseName, False)
                .DataSourceConnections(0).SetLogon(sqluser, pw)
            End With
            For i = 0 To ParamList.Count - 1
                cryRpt.SetParameterValue(ParamList(i), ValList(i))
            Next
            cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)
        Catch ex As Exception
            WriteLog(ex.Message)
        End Try

    End Sub
End Class
