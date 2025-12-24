Imports System.Globalization
Imports System.Text.RegularExpressions
Module Module_Datetime
    Public Function GetNumeroSemaine(ByVal oDate As Date) As Integer
        Dim dfi = DateTimeFormatInfo.CurrentInfo
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
        Dim Jour As String = ""

        Select Case Dat.DayOfWeek
            Case 1
                Jour = "Lundi"
            Case 2
                Jour = "Mardi"
            Case 3
                Jour = "Mercredi"
            Case 4
                Jour = "Jeudi"
            Case 5
                Jour = "Vendredi"
            Case 6
                Jour = "Samedi"
            Case Else
                Jour = "Dimanche"
        End Select
        Return Jour
    End Function

    Public Function CheckDate(ByVal Dat As Date) As String
        Dim CheckDat As String = ""
        Dim datdebblocage As Date
        Dim datfinblocage As Date

        If CnExecuting("Select count(*) from Compta_Exercice WHERE Ouvert = 'True'").Fields(0).Value = 0 Then
            CheckDat = "Erreur : Aucun exercice ouvert"
            Return CheckDat
            Exit Function
        End If
        Dim datdebbloquageparametre As DateTime = Societe.DateDebPaie
        Dim datfinbloquageparametre As DateTime = Societe.DateFinPaie
        If EstDate(datdebbloquageparametre) Then
            If datdebblocage < datdebbloquageparametre Then
                datdebblocage = datdebbloquageparametre
            End If
        End If
        If EstDate(datfinbloquageparametre) Then
            If datfinblocage < datfinbloquageparametre Then
                datfinblocage = CDate(datfinbloquageparametre)
            End If
        End If
        If datdebblocage <= Droits.DatDebContrat Then
            datdebblocage = Droits.DatDebContrat
        End If
        If datfinblocage >= Droits.DatFinContrat Then
            datfinblocage = Droits.DatFinContrat
        End If
        If Dat < datdebblocage Or Dat > datfinblocage Then
            CheckDat = "Erreur : Date de Pièce hors date de Blocage définies entre " & datdebblocage & " et " & datfinblocage
            Return CheckDat
            Exit Function
        End If
        CheckDat = "OK"
        Return CheckDat
    End Function
    Public Function EstTime(ByVal Temps As String) As Boolean
        Dim rg As New Regex("(^[01]?[0-9]|^2[0-3]):[0-5][0-9]")
        Return rg.IsMatch(Temps)
    End Function
    Public Function TimeConverter(ByVal Temps) As String
        Dim Tps As String = ""
        If EstTime(Temps) Then
            If Temps = "" Then Temps = "00:00"
            If Temps = "00:00:00" Then Temps = Gauche(Temps, 5)
            Tps = Math.Round(CDbl(Split(Temps, ":")(0)) + CDbl(Split(Temps, ":")(1)) / 60, 2)
            If CDbl(Tps) = 0 Then Tps = 24
        ElseIf IsNumeric(Temps) Then
            Tps = CStr(Temps).Replace(".", ",")
            If Tps = "" Then
                Tps = "0"
            ElseIf CDbl(Tps) = 24 Then
                Tps = "00:00"
            Else
                Tps = Droite("00" & Math.Floor(CDbl(Tps)), 2) & ":" & Droite("00" & Math.Floor((CDbl(Tps) - Math.Floor(CDbl(Tps))) * 60), 2)
            End If
        End If

        Return Tps
    End Function

    Public Function NbJourDansMois(ByVal LeMois, ByVal LeAnnee)
        Select Case (LeMois)
            'Avril, Juin, Septembre, Novembre
            Case 4, 6, 9, 11
                NbJourDansMois = 30
                ' Février
            Case 2
                ' Si Divisible par 400 alors Bisextile
                If (LeAnnee Mod 4 = 0) And (LeAnnee Mod 100 <> 0) Or (LeAnnee Mod 400 = 0) Then
                    NbJourDansMois = 29
                Else
                    NbJourDansMois = 28
                End If
                ' Les autres mois
            Case Else
                NbJourDansMois = 31
        End Select
    End Function

    Public Function NextDateAbonnement(ByVal CodAbonnement As String, Optional ByVal Dat As Date = Nothing) As Date
        Dim CodSql As String = "Select Dat_Next,Dat_Mis_Application,Heure_Abonnement,Typ_Frequence,Frequence,Lundi,Mardi,Mercredi,Jeudi,Vendredi,Samedi,Dimanche from Param_Abonnement where Cod_Abonnement='" & CodAbonnement & "'"
        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD(CodSql)
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
