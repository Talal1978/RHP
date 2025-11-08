Imports System.Text.RegularExpressions
Module Module_Zoom
    Sub Appel_Zoom1(ByVal NumZoom As String, ByVal Zom_Object As Object, ByVal Zom_Form As Form, Optional ByVal Zom_Condition As String = "", Optional ByVal Zom_Parameters As String = "", Optional ByVal Zoom_Objet_Location As Object = Nothing)
        Try
            If CnExecuting("Select count(*) from Controle_Def_Zoom where Num_Zoom='" & NumZoom & "'").Fields(0).Value = 0 Then
                ShowMessageBox("Le Menu :" & NumZoom & " n'existe pas.")
                Exit Sub
            End If
            Zoom_Object = Zom_Object
            Zoom_Form = Zom_Form
            Zoom_Condition = Zom_Condition
            Zoom_Parameters = Zom_Parameters
            Zoom_OrderByG = ""
            Dim f As New Zoom
            f.NumZoom = NumZoom
            f.Loading()
            If Zoom_Objet_Location Is Nothing Then Zoom_Objet_Location = Zoom_Object
            ShowDialogToPosition(Zoom_Objet_Location, Zom_Form, f)
        Catch ex As Exception

        End Try
    End Sub
    Sub Appel_Zoom(ByVal Zom_Cod As String, ByVal Zom_Lib As String, ByVal Zom_Tbl As String, ByVal Zom_Where1 As String, ByVal Zom_Object As Object, ByVal Zom_Form As Form, Optional ByVal Zoom_Objet_Location As Object = Nothing)
        Try
            Zoom_Cod = Zom_Cod
            Zoom_Lib = Zom_Lib
            Zoom_Tbl = Zom_Tbl
            Zoom_Object = Zom_Object
            Zoom_Form = Zom_Form
            Zoom_Where1 = Zom_Where1
            Zoom_OrderByG = ""
            Dim f As New Zoom
            f.Loading()
            If Zoom_Objet_Location Is Nothing Then Zoom_Objet_Location = Zoom_Object
            ShowDialogToPosition(Zoom_Objet_Location, Zom_Form, f)
        Catch ex As Exception

        End Try
    End Sub
    Sub Appel_Zoom_Boolean(ByVal Zom_Object As Object, ByVal Zom_Form As Form, Optional ByVal TypCombo As String = "Boolean")
        Zoom_Object = Zom_Object
        Zoom_Form = Zom_Form
        Zoom_Combo.TypCombo = TypCombo
        Zoom_OrderByG = ""
        Dim f As New Zoom_Combo
        ShowDialogToPosition(Zom_Object, Zom_Form, f)
    End Sub
    Sub Appel_Calender(ByVal control As Object, ByVal frm As Form, Optional defaultDate As String = "")
        Zoom_Object = control
        Zoom_Form = frm
        Dim laDate As Date = Now.Date
        Dim fcal As New Zoom_Calender
        If EstDate(defaultDate) Then laDate = CDate(defaultDate)
        fcal.MonthCalendar1.SetDate(laDate)
        ShowDialogToPosition(control, frm, fcal)
    End Sub
    Sub Appel_Calender_Blocage(ByVal Zone_Text As Object, ByVal frm As Form, ByVal modul As String)
        Zoom_Object = Zone_Text
        Dim f As New Zoom_Calender_Blocage
        With f
            .modul = modul
            ShowDialogToPosition(Zone_Text, frm, f)
        End With
    End Sub
    Sub Appel_Rubrique(ByVal Rubrique As String, ByVal Zom_Object As Object, ByVal Zom_Form As Form, Optional ByVal Zom_Condition As String = "", Optional ByVal Zoom_Objet_Location As Object = Nothing)
        Zoom_Cod = "Valeur"
        Zoom_Lib = "Membre,Rang,Champs02"
        Zoom_Tbl = "Param_Rubriques"
        Zoom_Object = Zom_Object
        Zoom_Form = Zom_Form
        Zoom_Where1 = "Nom_Controle='" & Rubrique & "'" & IIf(Zom_Condition <> "", " and " & Zom_Condition, "")
        Zoom_OrderByG = "Rang"
        Dim f As New Zoom
        f.Zoom_lbl.Text = Rubrique
        f.Loading()
        If Zoom_Objet_Location Is Nothing Then Zoom_Objet_Location = Zoom_Object
        ShowDialogToPosition(Zoom_Objet_Location, Zom_Form, f)
        Try
            Dim obj As Object = GetControlByName("Lib_" & Zom_Object.name, Zom_Form)
            If obj IsNot Nothing Then
                If obj.GetType Is GetType(ud_TextBox) Then
                    obj.text = FindRubriques(Rubrique, Zom_Object.text)
                ElseIf obj.GetType Is GetType(TextBox) Then
                    obj.text = FindRubriques(Rubrique, Zom_Object.text)
                End If
            End If

        Catch ex As Exception

        End Try


    End Sub
    Function GetLibRubrique(Valeur As String, ByVal Rubrique As String) As String
        Return FindLibelle("Membre", "Valeur", Valeur & "' and Nom_Controle='" & Rubrique, "Param_Rubriques")
    End Function
    Function FilterRoleWhere(TblSelect As String) As String
        If theUser.Cod_Profile <> 1 Then
            With Tbl_Controle_Profile_Regles
                If .Rows.Count > 0 Then
                    Dim dict As New Dictionary(Of String, String)
                    Dim correspondanceDic As New Dictionary(Of String, String)
                    Dim rg, s_rg, rg0 As New Regex(".")
                    Dim nb As Integer = 0
                    For i = 0 To .Rows.Count - 1
                        nb = 0
                        dict.Clear()
                        'regex des table
                        rg = New Regex("\b(" & .Rows(i)("Table_Ref") & "(?![.]))\b")

                        'on extrait les tables utilisées avec des alias exemple : "select * from laTable a left join autreTable b on a.cod=b.id"
                        rg0 = New Regex(.Rows(i)("Table_Ref") & "(?<prf>\s+(?!(?:left|right|on|inner|where|outer|apply|group|order|having))\w+)", RegexOptions.IgnoreCase Or RegexOptions.Compiled)
                        For Each c As Match In rg0.Matches(TblSelect)
                            dict.Add("XXXXYZEXCFRFFVTH" & nb, rg.Replace(c.Value, "(select * from " & .Rows(i)("Table_Ref") & " where " & .Rows(i)("Regle") & ")"))
                            correspondanceDic.Add("XXXXYZEXCFRFFVTH" & nb, .Rows(i)("Table_Ref"))
                            s_rg = New Regex("\b(" & c.Value & ")\b", RegexOptions.IgnoreCase Or RegexOptions.Compiled)
                            TblSelect = s_rg.Replace(TblSelect, "XXXXYZEXCFRFFVTH" & nb)
                            nb += 1
                        Next
                        'on remplace la table dans l'expression tblSelect
                        For Each c As Match In rg.Matches(TblSelect)
                            dict.Add("XXtfvhXCFRFFVTH" & nb, rg.Replace(c.Value, "(select * from " & .Rows(i)("Table_Ref") & " where " & .Rows(i)("Regle") & ") as " & .Rows(i)("Table_Ref")))
                            correspondanceDic.Add("XXtfvhXCFRFFVTH" & nb, .Rows(i)("Table_Ref"))
                            s_rg = New Regex("\b(" & c.Value & ")\b", RegexOptions.IgnoreCase Or RegexOptions.Compiled)
                            TblSelect = s_rg.Replace(TblSelect, "XXtfvhXCFRFFVTH" & nb)
                            nb += 1
                        Next
                        'on remplace les tables avec alias par l'expression 
                        For Each b In dict
                            rg = New Regex("\b(" & b.Key & "(?![.]))\b")
                            TblSelect = rg.Replace(TblSelect, b.Value)
                        Next
                        For Each b In correspondanceDic
                            rg = New Regex("\b" & b.Key & "(?=[.])\b")
                            TblSelect = rg.Replace(TblSelect, b.Value)
                        Next
                    Next
                End If
            End With
        End If

        Return TblSelect
    End Function
End Module
