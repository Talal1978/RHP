Imports System.Text.RegularExpressions

Module Module_Generateur_Survey
    Friend myVBS As New vsEngine
    Public rx_survey As New Regex("(?i)\bQ\s*\[\s*(?<N>\d+)\s*\](?:\s*\[\s*(?:(?<L>\d+)\s*(?:,|:)\s*)?(?<C>\d+)\s*\])?")
    Dim dicType As New Dictionary(Of String, Type) From {
        {"grille_cases", GetType(ud_grille_cases)},
        {"cocher", GetType(ud_grille_cases)},
        {"oui_non", GetType(ud_grille_cases)},
        {"vrai_faux", GetType(ud_grille_cases)},
        {"echelle", GetType(ud_grille_cases)},
        {"grille_choix", GetType(ud_grille_choix)},
        {"choix", GetType(ud_grille_choix)},
        {"grille_libre", GetType(ud_grille_libre)},
        {"paragraph", GetType(ud_paragraph)},
        {"date", GetType(ud_valeur_unique)},
        {"dateTime", GetType(ud_valeur_unique)},
        {"heure", GetType(ud_valeur_unique)},
        {"liste", GetType(ud_valeur_unique)},
        {"alpha", GetType(ud_valeur_unique)},
        {"entier", GetType(ud_valeur_unique)},
        {"numerique", GetType(ud_valeur_unique)}
    }
    Function Generate_QuestionnaireNew(CodSurvey As String, Pnl_Content As Panel, CodReply As Integer, Evalue As String, Evaluateur As String, Typ_Evaluation As String) As DataTable
        With Pnl_Content
            .SuspendLayout()
            .Padding = New Padding(2, 2, 2, 2)
            .Controls.Clear()
        End With

        myVBS = New vsEngine

        '    Dim Pnl_Content As New Panel
        Dim dictQ As New Dictionary(Of ud_pattern, Dictionary(Of String, String))
        myVBS.ExecuteStatement(TraitementCaractere($"Evalue = '{Evalue}'"))
        myVBS.ExecuteStatement(TraitementCaractere($"Evaluateur = '{Evaluateur}'"))
        myVBS.ExecuteStatement(TraitementCaractere($"Typ_Evaluation = '{Typ_Evaluation}'"))
        Dim Tbl_Question As DataTable = DATA_READER_GRD("select row_number () over(order by Rang asc) as NumQuestion, isnull(Typ_Reponse,'') as Typ_Reponse,RowId as Cod_Question, isnull(Question,'') as Question ,isnull(Sous_Question,'') as Sous_Question,
isnull(Reponses_Possibles,'') as Reponses_Possibles, isnull(Obligatoire,'false') as Obligatoire, 
isnull(AvecNote,'false') as AvecNote,isnull(Mode_Scoring,'na') as Mode_Scoring, isnull(Max_Score,0) as Max_Score, isnull(Func_Scoring,'') as Func_Scoring , isnull(Coef,1) as Coef, isnull(Obligatoire_Si,'') as Obligatoire_Si,
isnull(Erreur_Si,'') as Erreur_Si, isnull(Erreur_Msg,'') as Erreur_Msg
from Survey_Detail d
outer apply (select top 1 AvecNote from Survey s where s.Cod_Survey=d.Cod_Survey)q
where Cod_Survey='" & CodSurvey & "' and id_Societe=" & Societe.id_Societe & "
order by isnull(Rang,0) desc")
                                     Pnl_Content.Controls.Clear()
                                     Dim rw_function() = Tbl_Question.Select("Func_Scoring<>''")
                                     For i = 0 To rw_function.Length - 1
                                         Dim strFunc = $"Function Func_Survey_{rw_function(i)("Cod_Question")}(CurrentAnswer)
                Func_Survey_{rw_function(i)("Cod_Question")}={TraitementCaractere(rw_function(i)("Func_Scoring"))}
                End Function"
                                         myVBS.ExecuteStatement(strFunc)
                                     Next
        Dim Tbl_Reponse As DataTable = DATA_READER_GRD("SELECT Cod_Reply, Cod_Question, isnull(Num_Sous_Question,'0') as Num_Sous_Question, 
isnull(Reponses,'') as Reponses, isnull(Note,0) as Note, isnull(Coef,1) as Coef, isnull(Note_Totale,0) as Note_Totale
FROM Survey_Reply_Detail
where Cod_Reply=" & CodReply)
        With Tbl_Question
            For i = 0 To .Rows.Count - 1
                Try
                    Dim repDic As New Dictionary(Of String, String)
                    Dim nrw() As DataRow = Tbl_Reponse.Select("Cod_Reply=" & CodReply & " and Cod_Question=" & .Rows(i)("Cod_Question"))
                    Dim colonnes As String = .Rows(i)("Reponses_Possibles")
                    Dim lignes As String = .Rows(i)("Sous_Question")
                    Dim typReponseStr = .Rows(i)("Typ_Reponse")
                    For j = 0 To nrw.Length - 1
                        repDic.Add(CStr(nrw(j)("Num_Sous_Question")), nrw(j)("Reponses"))
                    Next
                    If Not dicType.ContainsKey(typReponseStr) Then
                        MsgBox("Type de réponse inconnu pour la question " & .Rows(i)("NumQuestion") & ": '" & typReponseStr & "'")
                        Continue For ' Passer à la question suivante
                    End If
                    Dim typeReponse As Type = CType(dicType(typReponseStr), Type)

                    Dim ud As Object = typeReponse.Assembly.CreateInstance(typeReponse.FullName)
                    If "RHP.ud_valeur_unique;RHP.ud_paragraph".Split(";").Contains(typeReponse.FullName) Or
           (lignes.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Length > 0 AndAlso
            colonnes.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Length > 0) Then
                        With ud
                            .Typ_Reponse = Tbl_Question.Rows(i)("Typ_Reponse")
                            .Obligatoire = Tbl_Question.Rows(i)("Obligatoire")
                            .repDic = repDic
                            .Name = Tbl_Question.Rows(i)("Cod_Question")
                            .Text = Tbl_Question.Rows(i)("Question")
                            .nbLig = lignes.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Length
                            .colonnes = colonnes
                            .lignes = lignes
                            .laquestion = Tbl_Question.Rows(i)("Question")
                            .numQuestion = Tbl_Question.Rows(i)("NumQuestion")
                            .avecNote = IsNull(Tbl_Question.Rows(i)("AvecNote"), False)
                            .modeScoring = IsNull(Tbl_Question.Rows(i)("Mode_Scoring"), "na")
                            .maxScore = IsNull(Tbl_Question.Rows(i)("Max_Score"), 0)
                            .coef = IsNull(Tbl_Question.Rows(i)("Coef"), 1)
                            .funcScoring = IsNull(Tbl_Question.Rows(i)("Func_Scoring"), "")
                            .codQuestion = Tbl_Question.Rows(i)("Cod_Question")
                            .noteManuelle = If(nrw.Length > 0, CDbl(IsNull(nrw(0)("Note"), 0)), 0)
                            .Chargement()
                            .Dock = DockStyle.Top
                        End With
                        Pnl_Content.Controls.Add(ud)
                        dictQ.Add(ud, ud.repDic)
                    End If

                Catch ex As Exception
                    MsgBox("ERREUR à la question " & .Rows(i)("NumQuestion") & vbCrLf &
               "Message: " & ex.Message & vbCrLf &
               "Type: " & ex.GetType().ToString() & vbCrLf &
               "StackTrace: " & ex.StackTrace)
                End Try
            Next
        End With
        Dim _pnl_top As New Panel
                                     With _pnl_top
                                         .Size = New Size(10, 5)
                                         .Location = New Point(0, 0)
                                         .Dock = DockStyle.Top
                                     End With
        With Pnl_Content
            .Controls.Add(_pnl_top)
            .Dock = DockStyle.Fill
            .AutoScroll = True
            '    Pnl.Controls.Add(Pnl_Content)
            Pnl_Content.Tag = dictQ
            If .Controls.Count > 0 Then .Controls(.Controls.Count - 1).Select()
            .ResumeLayout(True)
        End With

        Return Tbl_Question
    End Function

    Function survey_CheckObligatoire(Tbl_Question As DataTable, reponses As Dictionary(Of ud_pattern, Dictionary(Of String, String))) As ud_pattern
        Dim obgRw() = Tbl_Question.Select("Obligatoire_Si<>''")
        Dim obgFunct As MatchEvaluator = Function(m)
                                             Dim N As String = m.Groups("N").Value
                                             If IsNumeric(N) Then

                                                 Dim qst() = Tbl_Question.Select($"NumQuestion={N}")
                                                 If qst.Length = 0 Then Return m.Value
                                                 Dim maQst As String = qst(0)("Cod_Question")
                                                 Dim typRep As String = IsNull(qst(0)("Typ_Reponse"), "alpha")
                                                 Dim vari As String = ""
                                                 Dim dim_vari As String = ""

                                                 Dim reponse = reponses.Keys.FirstOrDefault(Function(c) c.Name = maQst)
                                                 If reponse Is Nothing Then Return m.Value
                                                 If m.Groups("C").Success Then
                                                     Dim C As String = m.Groups("C").Value
                                                     If IsNumeric(C) Then
                                                         If m.Groups("L").Success Then
                                                             Dim L As String = m.Groups("L").Value
                                                             If IsNumeric(L) Then
                                                                 vari = $"Qst6yrbi_{N}_{L}_{C}"
                                                                 dim_vari = $"Qst6yrbi_{N}_{L}_{C} = " & getValeur(reponse, C, L)
                                                             End If
                                                         Else
                                                             vari = $"Qst6yrbi_{N}_{C}"
                                                             dim_vari = $"Qst6yrbi_{N}_{C}= " & getValeur(reponse, C)
                                                         End If
                                                     End If
                                                 Else
                                                     vari = $"Qst6yrbi_{N}"
                                                     dim_vari = $"Qst6yrbi_{N}= " & getValeur(reponse)
                                                 End If
                                                 dim_vari = TraitementCaractere(dim_vari)
                                                 myVBS.ExecuteStatement(dim_vari)
                                                 Return vari
                                             Else
                                                 Return m.Value
                                             End If
                                         End Function
        For i = 0 To obgRw.Length - 1
            Dim codQuestion As String = obgRw(i)("Cod_Question")
            Dim strFunction As String = obgRw(i)("Obligatoire_Si")
            Dim currentQuestion = reponses.Keys.FirstOrDefault(Function(c) c.Name = codQuestion)
            If currentQuestion IsNot Nothing Then
                If estVide(currentQuestion) Then
                    Dim output As String = TraitementCaractere(rx_survey.Replace(strFunction, obgFunct))
                    If myVBS.Eval(output) Then Return currentQuestion
                End If
            End If
        Next
        Return Nothing
    End Function
    Function estVide(rep As ud_pattern) As Boolean
        If TypeOf rep Is ud_paragraph Then
            If CType(rep, ud_paragraph).repDic("0").Trim = "" Then Return True
        ElseIf TypeOf rep Is ud_valeur_unique Then
            If IsNull(CType(rep, ud_valeur_unique).repDic("0"), "").Trim = "" Then Return True
        ElseIf TypeOf rep Is ud_grille_choix Then
            With CType(rep, ud_grille_choix)
                Dim rspse As String = Gauche(String.Join("", Enumerable.Repeat("0;", (.Grd.ColumnCount - 1))), (.Grd.ColumnCount - 1) * 2 - 1)
                For j = 0 To .repDic.Count - 1
                    If IsNull(.repDic(CStr(j)), "").Trim = "" Then
                        Return True
                    ElseIf .repDic(CStr(j)).Trim = rspse Then
                        Return True
                    End If
                Next
            End With
        ElseIf TypeOf rep Is ud_grille_cases Then
            With CType(rep, ud_grille_cases)
                Dim rspse As String = Gauche(String.Join("", Enumerable.Repeat("0;", (.Grd.ColumnCount - 1))), (.Grd.ColumnCount - 1) * 2 - 1)
                For j = 0 To .repDic.Count - 1
                    If IsNull(.repDic(CStr(j)), "").Trim = "" Then
                        Return True
                    ElseIf .repDic(CStr(j)).Trim = rspse Then
                        Return True
                    End If
                Next
            End With
        ElseIf TypeOf rep Is ud_grille_libre Then
            With CType(rep, ud_grille_libre)
                Dim rspse As String = Gauche(String.Join("", Enumerable.Repeat("0;", (.Grd.ColumnCount - 1))), (.Grd.ColumnCount - 1) * 2 - 1)
                For j = 0 To .Grd.RowCount - 1
                    If IsNull(.repDic(CStr(j)), "").Trim = "" Then
                        Return True
                    ElseIf .repDic(CStr(j)).Trim = rspse Then
                        Return True
                    End If
                Next
            End With
        End If
        Return False
    End Function
    Function getValeur(rep As ud_pattern, Optional ByVal colonne As Integer = Nothing, Optional ByVal ligne As Integer = Nothing) As Object
        If TypeOf rep Is ud_paragraph Then
            Return "'" & CType(rep, ud_paragraph).repDic("0").Trim & "'"
        ElseIf TypeOf rep Is ud_valeur_unique Then
            Dim ctr = CType(rep, ud_valeur_unique)
            Return If(ctr.Typ_Reponse = "entier" OrElse ctr.Typ_Reponse = "numerique", ctr.repDic("0"), "'" & ctr.repDic("0") & "'")
        ElseIf TypeOf rep Is ud_grille_choix Then
            With CType(rep, ud_grille_choix)
                ligne = If(IsNull(ligne, 0) = 0, 1, ligne)
                If ligne <= .repDic.Count And IsNull(colonne, 0) > 0 Then
                    Dim laréponse() = .repDic(CStr(ligne - 1)).Split(";")
                    If colonne <= laréponse.Length Then
                        Return If(laréponse(colonne - 1) = "1", 1, 0)
                    End If
                End If
                Return 0
            End With
        ElseIf TypeOf rep Is ud_grille_cases Then
            With CType(rep, ud_grille_cases)
                ligne = IsNull(ligne, 0)
                If IsNull(ligne, 0) > 0 Then
                    If ligne < .repDic.Count And IsNull(colonne, 0) > 0 Then
                        Dim laréponse() = .repDic(CStr(ligne - 1)).Split(";")
                        If colonne <= laréponse.Length Then
                            Return If(laréponse(colonne - 1) = "1", 1, 0)
                        End If
                    End If
                ElseIf IsNull(colonne, 0) = 0 Then
                    Dim laréponse() = .repDic("0").Split(";")
                    If laréponse.Length > 0 Then
                        For c = 0 To laréponse.Length - 1
                            If laréponse(c) = "1" Then
                                Return c + 1
                            End If
                        Next
                    End If
                End If
                Return 0
            End With
        ElseIf TypeOf rep Is ud_grille_libre Then
            With CType(rep, ud_grille_libre)
                If IsNull(ligne, 0) > 0 And IsNull(colonne, 0) > 0 Then
                    If ligne < .Grd.RowCount And colonne < .Grd.ColumnCount Then
                        Return .Grd.Item(colonne - 1, ligne - 1).Tag
                    End If
                End If
            End With
        End If
        Return "''"
    End Function
End Module
