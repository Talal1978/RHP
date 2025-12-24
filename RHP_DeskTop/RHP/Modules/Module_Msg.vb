Module Module_Msg
    Function MessageBoxRHP(ByVal MsgNum As Integer, Optional ByVal oVariable As String = "") As MsgBoxResult
        Dim Rsl As New MsgBoxResult
        Dim autoClose As Integer = 0
        Dim CodSql As String = "select Top 1 * from Controle_MsgBox where Num_Msg=" & MsgNum & " and Cod_Langue='" & CodLangue & "'"
        Dim Tbl As DataTable = DATA_READER_GRD(CodSql)
        If Tbl.Rows.Count = 0 Then
            CodSql = "select Top 1 * from Controle_MsgBox where Num_Msg=" & MsgNum
            Tbl = DATA_READER_GRD(CodSql)
        End If
        If Tbl.Rows.Count = 0 Then Return Nothing
        Dim oTitre As String = Tbl.Rows(0).Item("Titre_Msg")
        Dim oTexte As String = Tbl.Rows(0).Item("Lib_Msg")
        Dim oVar As String() = IsNull(Tbl.Rows(0).Item("Variable"), "").ToString.Split(";")

        If oVariable <> "" And oVar.Length > 0 Then
            Dim oVal As String() = oVariable.Split(";")
            For i = 0 To oVal.Length - 1
                If oVal.Length > i Then
                    oTitre = oTitre.Replace(oVar(i), oVal(i))
                    oTexte = oTexte.Replace(oVar(i), oVal(i))
                End If
            Next
        End If

        Dim newTxt As String() = oTexte.Split("|")
        Dim newTxtStr As String = ""
        For i = 0 To newTxt.Length - 1
            newTxtStr &= IIf(newTxtStr = "", "", vbCrLf) & newTxt(i)
        Next

        oTexte = newTxtStr

        Dim img As Image = My.Resources.Alert_info
        Select Case Tbl.Rows(0).Item("Typ_Msg").ToString.ToUpper
            Case "ALERT_OK"
                Return ShowMessageBox(oTexte, MsgNum & " : " & oTitre, MessageBoxButtons.OK, msgIcon.Information)
            Case "ALERT_CRITICAL"
                Return ShowMessageBox(oTexte, MsgNum & " : " & oTitre, MessageBoxButtons.OK, msgIcon.Stop)
            Case "ALERT_ALERT"
                Return ShowMessageBox(oTexte, MsgNum & " : " & oTitre, MessageBoxButtons.OK, msgIcon.Error)
            Case "ALERT_INFO"
                Return ShowMessageBox(oTexte, MsgNum & " : " & oTitre, MessageBoxButtons.OK, msgIcon.Question)
            Case "OKCANCEL"
                Return ShowMessageBox(oTexte, MsgNum & " : " & oTitre, MessageBoxButtons.OKCancel, msgIcon.Information)
            Case "OKONLY"
                Return ShowMessageBox(oTexte, MsgNum & " : " & oTitre, MessageBoxButtons.OK, msgIcon.Stop)
            Case "YESNOCANCEL"
                Return ShowMessageBox(oTexte, MsgNum & " : " & oTitre, MessageBoxButtons.YesNoCancel, msgIcon.Warning)
        End Select
        'Si la taille du texte dépasse 100 caractère retour à okonly
        If oTexte.Length > 100 Then
            Return ShowMessageBox(oTexte, MsgNum & " : " & oTitre)
        End If
        Dim r As Rectangle = Screen.GetWorkingArea(If(theUser.Typ_Role = "Agent", Menu_Agent, leMenu))
        Dim oM As New Zoom_Alerte_Msg
        With oM
            .TitreMsg.Text = oTitre
            .TextMsg.Text = oTexte
            .reflectionImage1.Image = img
            .Location = New Point(r.Right - .Width, r.Bottom - .Height)
            .AlertAnimation = DevComponents.DotNetBar.eAlertAnimation.BottomToTop
            .AlertAnimationDuration = 300
            .MsgNum.Text = MsgNum
            If autoClose = 1 Then
                .AutoClose = True
                .AutoCloseTimeOut = 2
                .BringToFront()
                .BringToFront()
                .Show()
            Else
                .ShowDialog()
            End If
        End With
        Return Rsl
    End Function
    Function MessageBoxRHPText(ByVal MsgNum As Integer, Optional ByVal oVariable As String = "") As String
        Dim AutoClose As Integer = 0
        Dim CodSql As String = "select Top 1 * from Controle_MsgBox where Num_Msg=" & MsgNum & " and Cod_Langue='" & CodLangue & "'"
        Dim Tbl As DataTable = DATA_READER_GRD(CodSql)
        If Tbl.Rows.Count = 0 Then
            CodSql = "select Top 1 * from Controle_MsgBox where Num_Msg=" & MsgNum
            Tbl = DATA_READER_GRD(CodSql)
        End If
        If Tbl.Rows.Count = 0 Then Return Nothing
        Dim oTitre As String = Tbl.Rows(0).Item("Titre_Msg")
        Dim oTexte As String = Tbl.Rows(0).Item("Lib_Msg")
        Dim oVar As String() = IsNull(Tbl.Rows(0).Item("Variable"), "").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries)

        If oVariable <> "" And oVar.Length > 0 Then
            Dim oVal As String() = oVariable.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            For i = 0 To oVal.Length - 1
                If oVal.Length > i Then
                    oTitre = oTitre.Replace(oVar(i), oVal(i))
                    oTexte = oTexte.Replace(oVar(i), oVal(i))
                End If
            Next
        End If

        Dim newTxt As String() = oTexte.Split("|")
        Dim newTxtStr As String = ""
        For i = 0 To newTxt.Length - 1
            newTxtStr &= IIf(newTxtStr = "", "", vbCrLf) & newTxt(i)
        Next
        Return newTxtStr
    End Function
End Module
