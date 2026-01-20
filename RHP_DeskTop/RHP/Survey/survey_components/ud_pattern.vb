Imports System.Text.RegularExpressions

Public Class ud_pattern
    Inherits UserControl
    Public laquestion As String = ""
    Public repDic As New Dictionary(Of String, String)
    Public Obligatoire As Boolean = False
    Public noteManuelle As Double = 0
    Public avecNote As Boolean = False
    Public maxScore As Double = 0
    Public modeScoring As String = "na"
    Public funcScoring As String = ""
    Public aggregationScoring As String = ""
    Public coef As Double = 1
    Public codQuestion As String = ""
    Public Typ_Reponse As String
    Public noteDic As New Dictionary(Of String, Double)
    Public colonnes As String = ""
    Public lignes As String = ""
    Public nbLig As Integer = 1
    Public DefaultRep As String = ""
    Public numQuestion As String = ""
    Public Overridable Sub Saving()

    End Sub
    Public Overridable Sub CalculNote()

    End Sub
    Public Overridable Sub Chargement()

    End Sub
    Public Overridable Function GetValeurFunction(numLigne As Int16) As Double
        Dim strFunction As String = Regex.Replace(funcScoring, Regex.Escape("CurrentAnswer"), CStr(getValeur(Me, -1, -1)), RegexOptions.IgnoreCase)
        Dim Resultat As Double = 0
        Dim output As String = ""
        Try
            Dim obgFunct As MatchEvaluator = Function(m)
                                                 Dim N As String = m.Groups("N").Value
                                                 If Not IsNumeric(N) Then
                                                     N = numQuestion
                                                 End If
                                                 Dim typRep As String = IsNull(Typ_Reponse, "alpha")
                                                 Dim vari As String = ""
                                                 Dim dim_vari As String = ""
                                                 Dim L As String = ""
                                                 If repDic Is Nothing Then Return m.Value
                                                 If m.Groups("C").Success Then
                                                     Dim C As String = m.Groups("C").Value
                                                     If IsNumeric(C) Then
                                                         If m.Groups("L").Success Then
                                                             L = m.Groups("L").Value.Trim()
                                                             If Not IsNumeric(L) Then
                                                                 L = numLigne
                                                             End If
                                                         Else
                                                             L = numLigne
                                                         End If
                                                         vari = $"Qst6yrbi_{N}_{L}_{C}"
                                                         dim_vari = $"Qst6yrbi_{N}_{L}_{C} = " & getValeur(Me, C, L)
                                                     End If
                                                 Else
                                                     vari = $"Qst6yrbi_{N}"
                                                     dim_vari = $"Qst6yrbi_{N}= " & getValeur(Me)
                                                 End If
                                                 dim_vari = TraitementCaractere(dim_vari)
                                                 myVBS.ExecuteStatement(dim_vari)
                                                 Return vari
                                             End Function
            output = TraitementCaractere(rx_survey.Replace(strFunction, obgFunct))

            Resultat = CDbl(myVBS.Eval(output))


        Catch ex As Exception
suite:
            ShowMessageBox("#ERR : " & vbCrLf & Resultat & vbCrLf & ex.Message & vbCrLf & output, "Erreur dans la fonction de calcul de la note", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Resultat
    End Function
End Class
