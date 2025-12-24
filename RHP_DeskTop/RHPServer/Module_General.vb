Imports System.Data.OleDb
Module Module_General
    Friend ReadOnly logLock As New Object()
    Function DATA_READER_GRD(ByVal Cod_Sql As String, conString As String) As DataTable
        Dim cn1 As New OleDb.OleDbConnection
        Dim CMD As OleDbCommand = Nothing
        Try
            cn1.ConnectionString = conString
            CMD = cn1.CreateCommand()
            CMD.CommandText = Cod_Sql
            CMD.CommandTimeout = 60  ' AJOUTÉ: timeout de 60 secondes
            cn1.Open()

            Dim monreader As OleDbDataReader = CMD.ExecuteReader()
            Dim dtr As New DataTable("Table")
            dtr.Load(monreader)
            Return dtr

        Catch ex As Exception
            WriteLog("Erreur SQL: " & Cod_Sql & vbCrLf & ex.Message, "DATA_READER", True)
            Return Nothing
        Finally
            ' AJOUTÉ: Fermeture garantie
            If CMD IsNot Nothing Then CMD.Dispose()
            If cn1 IsNot Nothing AndAlso cn1.State = ConnectionState.Open Then
                cn1.Close()
            End If
        End Try
    End Function
    Public Function IsNull(ByVal Champs As Object, ByVal Valeur As String) As String
        If Champs Is Nothing Then
            Return Valeur
        ElseIf Champs.GetType.Name.Contains("Bitmap") Then
            Return Nothing
        ElseIf IsDBNull(Champs) Then
            Return Valeur
        ElseIf CStr(Champs).Trim = "" Then
            Return Valeur
        Else
            Return Champs
        End If
    End Function
    Function WriteLog(str As String, Optional ConnName As String = "", Optional SaveLog As Boolean = True)
        Try
            SyncLock logLock  ' Protection thread-safe
                Dim str0 As String = ""
                If ConnName <> "" Then
                    str0 = ConnName & " : " & Now & vbCrLf & str
                Else
                    str0 = Now & vbCrLf & str
                End If

                If SaveLog Then
                    If Not IO.Directory.Exists("LOG") Then IO.Directory.CreateDirectory("LOG")
                    Dim fichier As String = "LOG\" & Now.Day & Now.Month & Now.Year & ".log"
                    If Not IO.File.Exists(fichier) Then IO.File.Create(fichier).Close()
                    Dim sw As New IO.StreamWriter(fichier, True)
                    sw.WriteLine(str0)
                    sw.Close()
                End If

                ' Limiter la taille des logs en mémoire
                If TblLog.Rows.Count > 1000 Then
                    For i = TblLog.Rows.Count - 1 To 500 Step -1
                        TblLog.Rows.RemoveAt(i)
                    Next
                End If

                Dim drw As DataRow = TblLog.NewRow
                drw.ItemArray = {Now, ConnName, str}
                TblLog.Rows.InsertAt(drw, 0)
            End SyncLock
        Catch ex As Exception
            ' Éviter la récursion infinie
            Debug.WriteLine("Erreur WriteLog: " & ex.Message)
        End Try
        Return True
    End Function
    Public Function estEmail(str As String) As Boolean
        Dim estValide As Boolean = False
        If IsNull(str, "").Trim = "" Then Return False
        Dim rg As New System.Text.RegularExpressions.Regex("^\b(\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\b$")
        Return rg.IsMatch(str)
    End Function
    Public Function GetNumeroSemaine(ByVal oDate As Date) As Integer
        Dim dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo
        Dim calendar = dfi.Calendar

        ' using Thursday because I can.
        Return calendar.GetWeekOfYear(oDate, dfi.CalendarWeekRule, DayOfWeek.Monday)
    End Function
    Public Function GetPremierJourSemaine(ByVal weekNumber As Integer, ByVal year As Integer) As Date
        Dim startDate As New DateTime(year, 1, 1)
        Dim weekDate As DateTime = DateAdd(DateInterval.WeekOfYear, weekNumber - 1, startDate)
        Return DateAdd(DateInterval.Day, (-weekDate.DayOfWeek) + 1, weekDate)
    End Function
    Public Function GetMois(ByVal mois As Integer) As String
        Dim oMois As String = ""
        Select Case mois
            Case 1
                oMois = "Janvier"
            Case 2
                oMois = "Février"
            Case 3
                oMois = "Mars"
            Case 4
                oMois = "Avril"
            Case 5
                oMois = "Mai"
            Case 6
                oMois = "Juin"
            Case 7
                oMois = "Juillet"
            Case 8
                oMois = "Août"
            Case 9
                oMois = "Septembre"
            Case 10
                oMois = "Octobre"
            Case 11
                oMois = "Novembre"
            Case 12
                oMois = "Décembre"
        End Select
        Return oMois
    End Function
    Public Function GetJour(ByVal Dat As Date) As String
        Dim jour As String = ""

        Select Case Dat.DayOfWeek
            Case 1
                jour = "Lundi"
            Case 2
                jour = "Mardi"
            Case 3
                jour = "Mercredi"
            Case 4
                jour = "Jeudi"
            Case 5
                jour = "Vendredi"
            Case 6
                jour = "Samedi"
            Case Else
                jour = "Dimanche"
        End Select
        Return jour
    End Function
    Public Function NextDateAbonnement(ByVal CodAbonnement As String, cntStr As String, Optional ByVal Dat As Date = Nothing) As Date
        Dim CodSql As String = "Select Dat_Next,Dat_Mis_Application,Heure_Abonnement,Typ_Frequence,Frequence,Lundi,Mardi,Mercredi,Jeudi,Vendredi,Samedi,Dimanche from Param_Abonnement where Cod_Abonnement='" & CodAbonnement & "'"
        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD(CodSql, cntStr)
        With Tbl
            If .Rows.Count > 0 Then
                If Dat = Nothing Then
                    Dat = IsNull(.Rows(0).Item("Dat_Next"), CDate(.Rows(0).Item("Dat_Mis_Application") & " " & .Rows(0).Item("Heure_Abonnement")))
                End If
                While Dat <= Now
                    Select Case .Rows(0).Item("Typ_Frequence")
                        Case "Year"
                            Dat = Dat.AddYears(CInt(.Rows(0).Item("Frequence")))
                        Case "Month"
                            Dat = Dat.AddMonths(CInt(.Rows(0).Item("Frequence")))
                        Case "Hour"
                            Dat = Dat.AddHours(CInt(.Rows(0).Item("Frequence")))
                        Case "Minute"
                            Dat = Dat.AddMinutes(CInt(.Rows(0).Item("Frequence")))
                        Case "Second"
                            Dat = Dat.AddSeconds(CInt(.Rows(0).Item("Frequence")))
                        Case Else
                            Dat = Dat.AddDays(CInt(.Rows(0).Item("Frequence")))
                    End Select

                End While

                If IsNull(.Rows(0).Item(GetJour(Dat)), False) = False Then
                    For i = 0 To 7
                        If IsNull(.Rows(0).Item(GetJour(Dat)), False) = False Then
                            Dat = Dat.AddDays(1)
                        Else
                            Exit For
                        End If
                    Next
                End If

                If IsNull(.Rows(0).Item(GetJour(Dat)), False) = False Then
                    Dat = .Rows(0).Item("Dat_Fin_Application")
                End If
            End If
            Return Dat
        End With

    End Function
End Module
