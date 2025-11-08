Imports System.Text.RegularExpressions
Public Class vsEngine
    Private ReadOnly _VBS As MSScriptControl.ScriptControl
    Dim WithEvents Bgk As New System.ComponentModel.BackgroundWorker
    Friend withLog As Boolean = True
    Friend innerCodeStr As String
    Dim fileVbs = My.Application.Info.DirectoryPath & "\rsc\dbg_" & Societe.id_Societe & ".vbs"
    Sub New()
        innerCodeStr = ""
        _VBS = New MSScriptControl.ScriptControl With {.Language = "VBSCRIPT"}
        If IO.File.Exists(fileVbs) Then
            Try
                IO.File.Delete(fileVbs)
            Catch ex As Exception

            End Try
        End If
        Dim SqlStr As String = "select * from RH_Elements_Paie where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe & " order by Typ_Function, Typ_Retour"
        Dim TblRub As DataTable = DATA_READER_GRD(SqlStr)
        Dim TblAbaques = DATA_READER_GRD("select * from RH_Param_Abaques e left join RH_Param_Abaques_Detail d on e.Cod_Abaque=d.Cod_Abaque and e.id_Societe=d.id_Societe where isnull(nullif(e.id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe & " order by Typ_Retour")
        Dim StrVar As String = ""
        Dim nRows() As DataRow = TblRub.Select("Typ_Function not in ('FS','FU','FP')")
        With nRows
            For i = 0 To .Length - 1
                Select Case nRows(i)("Typ_Function")
                    Case "EC"
                        StrVar &= vbCrLf & "function " & nRows(i)("Cod_Function") & "()"
                        StrVar &= vbCrLf & nRows(i)("Cod_Function") & " = " & IsNull(nRows(i)("Formule_Function"), "") & vbCrLf & "End Function"
                    Case "CS", "EV", "AG", "EP", "EB"
                        StrVar &= vbCrLf & "dim " & nRows(i)("Cod_Function")
                        StrVar &= vbCrLf & nRows(i)("Cod_Function") & " = " & IIf(nRows(i)("Typ_Retour") <> "int" And nRows(i)("Typ_Retour") <> "float", """" & IsNull(nRows(i)("Formule_Function"), "") & """", IsNull(nRows(i)("Formule_Function"), "0"))
                    Case "EX"
                        StrVar &= vbCrLf & "dim V_" & nRows(i)("Cod_Function")
                        StrVar &= vbCrLf & "V_" & nRows(i)("Cod_Function") & " = " & IIf(nRows(i)("Typ_Retour") <> "int" And nRows(i)("Typ_Retour") <> "float", """", 0)
                        If nRows(i)("Typ_Function") = "EX" Then
                            StrVar &= vbCrLf & "function " & nRows(i)("Cod_Function") & "()"
                            StrVar &= vbCrLf & nRows(i)("Cod_Function") & " = " & (New Regex("\b(" & nRows(i)("Cod_Function") & ")\b", RegexOptions.IgnoreCase)).Replace(IsNull(nRows(i)("Formule_Function"), ""), "V_" & nRows(i)("Cod_Function")) & vbCrLf & "End Function"
                        End If
                End Select
            Next
        End With
        StrVar = StrVar.Trim()
        nRows = TblRub.Select("Typ_Function ='FU' and isnull(Formule_Function,'')<>''")
        Dim Rs0 As New Regex("return|=>", RegexOptions.IgnoreCase)
        Dim Rs1 As New Regex("(?<=\b(return)|(=>))\W*\b.+", RegexOptions.IgnoreCase)
        Dim mac As MatchCollection = Nothing
        Dim strFunction As String = ""
        Dim NameFunction As String = ""
        Dim TypRetour As String = ""
        With nRows
            For i = 0 To .Length - 1
                strFunction = IsNull(nRows(i)("Formule_Function"), "").Trim()
                If Rs1.IsMatch(strFunction) Then
                    NameFunction = IsNull(nRows(i)("Cod_Function"), "")
                    TypRetour = IsNull(nRows(i)("Typ_Retour"), "")
                    mac = Rs1.Matches(strFunction)
                    strFunction = Rs1.Replace(strFunction, " SiNull(" & mac(0).Value & ";" & GetValeurParDefaut(TypRetour) & " )")
                    strFunction = Rs0.Replace(strFunction, NameFunction & " = ").Trim
                    If Not String.IsNullOrWhiteSpace(strFunction) Then
                        strFunction = vbCrLf & "Function " & NameFunction & "()" & vbCrLf & strFunction & vbCrLf & "End Function"
                        StrVar &= vbCrLf & strFunction
                    End If
                End If
            Next
        End With
        nRows = TblRub.Select("Typ_Function in ('FS','FP') and isnull(Formule_Function,'')<>''")
        With nRows
            For i = 0 To .Length - 1
                strFunction = IsNull(nRows(i)("Formule_Function"), "").Trim()
                If Not String.IsNullOrWhiteSpace(strFunction) Then
                    StrVar = strFunction & vbCrLf & StrVar
                End If
            Next
        End With

        'cas des abaques
        nRows = TblRub.Select("Typ_Function ='AB'")
        Dim codAbaque = ""
        TypRetour = "nvarchar(max)"
        Dim arRw() As DataRow = Nothing
        Dim nbClef = 1
        Dim nbValeurs = 1
        Dim typDefaultVal As String = "C"
        Dim DefaultVal As String = ""
        With nRows
            For i = 0 To .Length - 1
                codAbaque = IsNull(nRows(i)("Cod_Function"), "").Trim()
                TypRetour = IsNull(nRows(i)("Typ_Retour"), "nvarchar(max)").Trim()
                arRw = TblAbaques.Select($"Cod_Abaque='{codAbaque}'")
                If arRw.Length > 0 Then
                    'créer l'objet abaque et ses éléments
                    strFunction = "Dim abq_" & codAbaque & vbCrLf & "Set abq_" & codAbaque & "= CreateObject(""Scripting.Dictionary"")"
                    For k = 0 To arRw.Length - 1
                        If k = 0 Then
                            nbClef = arRw(0)("Nb_Clefs")
                            nbValeurs = arRw(0)("Nb_Valeurs")
                            typDefaultVal = IsNull(arRw(0)("Typ_DefaultVal"), "C")
                            DefaultVal = IsNull(arRw(0)("DefaultVal"), "")
                        End If
                        Dim laClef As String = ""
                        Dim valeurs As String = ""
                        For c = 1 To nbClef
                            laClef &= If(laClef = "", "", "|") & arRw(k)($"Clef_{c:00}")
                        Next
                        laClef = """" & laClef & """"
                        For v = 1 To nbValeurs
                            If TypRetour = "float" OrElse TypRetour = "int" Then
                                valeurs &= If(valeurs = "", "", "; ") & arRw(k)($"Valeur_{v:00}").ToString.Replace(",", ".")
                            Else
                                valeurs &= If(valeurs = "", "", "; ") & """" & arRw(k)($"Valeur_{v:00}") & """"
                            End If
                        Next
                        If nbValeurs > 1 Then
                            valeurs = " Array(" & valeurs & ")"
                        End If
                        strFunction &= vbCrLf & "abq_" & codAbaque & $".Add {laClef}; {valeurs} "
                    Next
                    'créer une fonction qui retourne la valeur de l'abaque en fonction des paramètres
                    Dim paramsStr = ""
                    Dim clefs = ""
                    For p = 1 To nbClef
                        paramsStr &= If(paramsStr = "", "", "; ") & ($"param_{p}")
                        clefs &= If(clefs = "", "", " & ""|"" & ") & ($"param_{p}")
                    Next
                    strFunction &= vbCrLf & "Function " & codAbaque & $"({paramsStr}) "
                    strFunction &= vbCrLf & $"If abq_{codAbaque}.Exists({clefs}) Then"
                    strFunction &= vbCrLf & codAbaque & $"= abq_{codAbaque}({clefs}) "
                    strFunction &= vbCrLf & "Else "
                    If DefaultVal.Trim() <> "" Then
                        strFunction &= vbCrLf & codAbaque & $"= {DefaultVal}"
                        If TypRetour = "float" OrElse TypRetour = "int" Then
                            strFunction &= vbCrLf & $"if isnumeric(" & codAbaque & $")= false then
                            {codAbaque} = 0
                            end if"
                        End If
                    Else
                        strFunction &= vbCrLf & codAbaque & $"= {IIf(TypRetour = "float" OrElse TypRetour = "int", 0, """")}"
                    End If
                    strFunction &= vbCrLf & "End if"
                    strFunction &= vbCrLf & "End Function"
                    If Not String.IsNullOrWhiteSpace(strFunction) Then
                        StrVar = strFunction & vbCrLf & StrVar
                    End If
                End If

            Next
        End With
        If Not String.IsNullOrWhiteSpace(StrVar) Then
            StrVar = vbCrLf & StrVar & vbCrLf
            StrVar = TraitementCaractere(StrVar)
            '   fillLog(StrVar)
            ExecuteStatement(StrVar)
        End If

    End Sub
    Sub fillLog(strCode As String)
        Dim sw As New IO.StreamWriter(fileVbs, True)
        sw.WriteLine(strCode)
        sw.Close()
    End Sub
    Public Sub ExecuteStatement(strCode As String)
        If withLog Then
            fillLog(strCode)
        End If
        Try
            innerCodeStr &= vbCrLf & strCode
            _VBS.ExecuteStatement(strCode)

        Catch ex As Exception
            MsgBox("VB Script : Vérifiez le fichier log : rsc\dbg_" & Societe.id_Societe & ".vbs : " & vbCrLf & ex.Message)
        End Try

    End Sub
    Public Function Eval(strCode As String)
        Try
            Dim rsl = _VBS.Eval(strCode)
            Return rsl
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Erreur :" & strCode, MessageBoxButtons.OK, msgIcon.Stop)
            Return Nothing
        End Try
    End Function
    Public Sub setPlan(codPlanPaie As String)
        Dim StrVar As String = ""

        Dim TblPlan As DataTable = DATA_READER_GRD("select * from RH_Param_Plan_Paie where Cod_Plan_Paie='" & codPlanPaie & "' and id_Societe=" & Societe.id_Societe)
        If TblPlan.Rows.Count > 0 Then
            Dim TblRubPlan As DataTable = DATA_READER_GRD("select * from RH_Param_Plan_Paie_Rubriques where exists(select Column_Name from INFORMATION_SCHEMA.COLUMNS where Table_Name='RH_Param_Plan_Paie' and COLUMN_NAME=Rubrique)")
            Dim rub As String = ""
            Dim nomSysRbu As String = ""
            With TblRubPlan
                For i = 0 To .Rows.Count - 1
                    nomSysRbu = IsNull(.Rows(i)("Rubrique"), "").Trim()
                    If nomSysRbu <> "" Then
                        rub = IsNull(TblPlan.Rows(0)(.Rows(i)("Rubrique")), "").Trim()
                        If rub <> "" And rub <> nomSysRbu Then
                            StrVar &= vbCrLf & "Function " & nomSysRbu & "()
                  " & nomSysRbu & " = " & rub & "
                  End Function"
                            If CBool(IsNull(.Rows(i)("Cumulable"), False)) Then
                                StrVar &= vbCrLf & "Function Cumul_" & nomSysRbu & "()
                  Cumul_" & nomSysRbu & " = Cumul_" & rub & "
                  End Function"
                            End If
                        End If
                    End If

                Next
            End With
            If Not String.IsNullOrWhiteSpace(StrVar) Then
                StrVar = vbCrLf & StrVar & vbCrLf
                StrVar = TraitementCaractere(StrVar)
                Try
                    ExecuteStatement(StrVar)
                Catch ex As Exception
                    MsgBox("VB Script RechargerlesFonctionRH , Erreur : " & StrVar & vbCrLf & vbCrLf & ex.Message)
                End Try
            End If

        End If
    End Sub
    Sub AffectationEB(Matricule As String, Dat As Date)
        Try
            Dim TblAgent = DATA_READER_GRD($"select top 1 * from {sql_Sys_RH_Agent_AG} where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule & "'")
            Dim StrVar As String = ""
            For i = 0 To TblAgent.Columns.Count - 1
                Select Case TblAgent.Columns(i).DataType
                    Case System.Type.GetType("System.Decimal"), System.Type.GetType("System.Double"), System.Type.GetType("System.Int16"), System.Type.GetType("System.Int32"), System.Type.GetType("System.Int64"), System.Type.GetType("System.UInt16"), System.Type.GetType("System.UInt32"), System.Type.GetType("System.UInt64")
                        StrVar &= IIf(StrVar = "", "", vbCrLf) & " AffectVar " & TblAgent.Columns(i).ColumnName & ";" & IsNull(TblAgent.Rows(0)(i), 0)
                    Case Else
                        StrVar &= IIf(StrVar = "", "", vbCrLf) & " AffectVar " & TblAgent.Columns(i).ColumnName & ";""" & IsNull(TblAgent.Rows(0)(i), "") & """"
                End Select
            Next

            If Matricule <> "" Then
                Dim TblEB As DataTable = DATA_READER_GRD($"declare @idSoc int ={Societe.id_Societe}
select  'AffectVar '+ case when isnull(EX,0)=1 then 'V_' else  '' end +r.Cod_Rubrique+' ; '+ convert(nvarchar(50),isnull(Valeur,0)) as Affect 
from RH_Paie_Rubrique r 
outer apply(select Valeur from RH_Agent_Element_Paie a where Cod_Rubrique=r.Cod_Rubrique and a.id_Societe=isnull(nullif(r.id_Societe,-1),@idSoc) and Matricule='D0002')a
where (isnull(EB,0)=1 or isnull(EX,0)=1) and isnull(nullif(r.id_Societe,-1),@idSoc)=@idSoc
--union all
--select  r.Cod_Rubrique +'= EX_'+ r.Cod_Rubrique+'('+convert(nvarchar(50),isnull(Valeur,0))+')'  as Affect 
--from RH_Paie_Rubrique r 
--outer apply(select Valeur from RH_Agent_Element_Paie a where Cod_Rubrique=r.Cod_Rubrique and a.id_Societe=isnull(nullif(r.id_Societe,-1),@idSoc) and Matricule='D0002')a
--where isnull(EX,0)=1 and isnull(nullif(r.id_Societe,-1),@idSoc)=@idSoc")
                For i = 0 To TblEB.Rows.Count - 1
                    StrVar &= IIf(StrVar = "", "", vbCrLf) & IsNull(TblEB.Rows(i)("Affect"), "")
                Next
                Dim TblRubriqueCumulable As DataTable = DATA_READER_GRD("select * from dbo.Sys_RH_Paie_Calcul_Rubrique_Cumulable ('" & Dat.Year & "','" & Dat.Month & "','" & Societe.id_Societe & "','" & Matricule & "')")
                'Affectation des Rubriques cumulables
                Dim Crw() As DataRow = TblRubriqueCumulable.Select("Matricule='" & Matricule & "'")
                For i = 0 To Crw.Length - 1
                    StrVar &= IIf(StrVar = "", "", vbCrLf) & " AffectVar Cumul_" & Crw(i)("Cod_Rubrique") & ";" & IsNull(Crw(i)("Cumul"), 0)
                Next
            End If
            If Not String.IsNullOrWhiteSpace(StrVar) Then
                StrVar = vbCrLf & StrVar & vbCrLf
                StrVar = TraitementCaractere(StrVar)
            End If
            ExecuteStatement(StrVar)
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    Public Function CalculerFormule(Formule As String) As String
        Try
            If Formule = "" Then Return ""
            Dim Result As String = Eval(Formule)
            Return Result.ToString
        Catch ex As Exception
            Return "#ERR "
        End Try
    End Function

End Class
Public Module Module_VBSScript
    Dim rgtc As New Regex("\b(?<!\.)(?!0+(?:\.0+)?%)(?:\d|[1-9]\d|100)(?:(?<!100)\.\d+)?%")
    Function TraitementCaractere(str As String) As String
        Dim oval As String = ""
        For Each c As Match In rgtc.Matches(str)
            oval = c.Value
            If IsNumeric(oval.Replace("%", "").Replace(".", ",")) Then oval = CDbl(oval.Replace("%", "").Replace(".", ",")) / 100
            str = str.Replace(c.Value, oval)
        Next
        str = str.Replace(",", ".")
        str = str.Replace("''", """""")
        str = str.Replace("'", """")
        str = str.Replace(";", ",")
        str = str.Replace(Chr(39), Chr(34))
        str = str.Replace(Chr(160), "") 'Séparateur de milliers
        Return str
    End Function
    Public Function EstCaractèreConformeVBScript(Str As String) As Boolean
        Dim rg As New Regex("^[a-zA-Z]\w")
        If Str = "" Then
            Return True
        Else
            Return rg.IsMatch(Str)
        End If
    End Function
    Function ParDefaut(Expression As Object, typ As String) As Object
        If IsNull(Expression, "") = "" Then
            Select Case typ.ToUpper
                Case "INT", "FLOAT"
                    Return 0
                Case "BIT"
                    Return False
                Case "DATETIME", "SMALLDATETIME"
                    Return "01/01/1900"
                Case Else
                    Return ""
            End Select
        Else
            Return Expression
        End If
    End Function
    Function GetValeurParDefaut(typ As String) As Object
        Select Case typ.ToUpper
            Case "INT", "FLOAT"
                Return 0
            Case "BIT"
                Return False
            Case "DATETIME", "SMALLDATETIME"
                Return "01/01/1900"
            Case Else
                Return "''"
        End Select
    End Function
End Module

