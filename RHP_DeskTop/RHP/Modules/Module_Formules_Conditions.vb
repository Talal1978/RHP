Imports System.Text.RegularExpressions
Module Module_Formules_Conditions
    Public Function VerifierCondition(ByVal frm As Form, ByVal formule As String) As Object
        Dim rg As New Regex("(?i)((\b(?<!"")\w+(?!"")\b)(?<!(and|or|findparam|\b[0-9]+\b)))|(Findparam\(""\w+""\))", RegexOptions.IgnoreCase)
        For Each c As Match In rg.Matches(formule)
            formule = formule.Replace(c.Value, estControl(c.Value, frm))
        Next
        formule = formule.Trim.ToUpper
        Return EvaluationFormul(formule)
    End Function
    Function estControl(ByVal objName As String, ByVal Ecran As Form) As String
        If Microsoft.VisualBasic.Left(objName, 3).ToUpper = "GV_" Then
            Return GlobalVar(objName).Trim.ToUpper
        ElseIf Microsoft.VisualBasic.Left(objName, 9).ToUpper = "FINDPARAM" Then
            Return """" & FindParam(objName.ToUpper.Replace("FINDPARAM(""", "").Replace(""")", "")).Trim.ToUpper & """"
        Else
            Try
                Dim obj As Object = GetControlByName(objName, Ecran)
                If TypeOf obj Is TextBox Then
                    Return """" & CType(obj, TextBox).Text.Trim.ToUpper & """"
                ElseIf TypeOf obj Is ComboBox Then
                    Return """" & CType(obj, ComboBox).SelectedValue.Trim.ToUpper & """"
                ElseIf TypeOf obj Is NumericUpDown Then
                    Return """" & CType(obj, NumericUpDown).Value & """"
                ElseIf TypeOf obj Is DataGridViewCell Then
                    Return """" & obj.value & """"
                ElseIf TypeOf obj Is CheckBox Then
                    Return """" & CType(obj, CheckBox).Checked & """"
                ElseIf TypeOf obj Is ud_RadioBox Then
                    Return """" & CType(obj, ud_RadioBox).Checked & """"
                Else
                    Return objName
                End If
            Catch ex As Exception
                Return objName
            End Try
        End If


    End Function

    Function EvaluationFormul(ByVal oformule As String) As Object
        Dim SC As New MSScriptControl.ScriptControl
        Dim obj As Object = Nothing
        'SET LANGUAGE TO VBSCRIPT
        SC.Language = "VBSCRIPT"
        'ATTEMPT MATH
        Try
            obj = SC.Eval(oformule)
        Catch ex As Exception
            'SHOW THAT IT WAS INVALID
            obj = False
        End Try
        Return obj
    End Function
End Module
