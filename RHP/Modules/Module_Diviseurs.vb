Module Module_Diviseurs
    Public Sub Diviseur_Next(ByVal Table As String, ByVal Champs As String, ByVal TRIE_PAR As String, ByVal Zone_Text As Object, Optional ByVal AvecRegle As Boolean = True)
        Try
            TRIE_PAR = Champs
            If CnExecuting("Select count(*) from " & Table & " where " & Champs & "='" & Zone_Text.Text & "'").Fields(0).Value = 0 Then
                Exit Sub
            End If
            If CnExecuting("Select count(*) from " & Table).Fields(0).Value = 0 Then
                Exit Sub
            End If
            Dim Cod_Sql As String = ""
            ' code sql pour ressortir le numéro de la ligne de l'enregistrement actuel
            Dim laRegl As String = ""
            Dim ZoomW As String = IIf(ContientIdSoc(Table).Count > 0, "isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe, "")
            If AvecRegle Then laRegl = FindLibelle("Regle", "Cod_Profile", theUser.Cod_Profile & "' and Table_Ref='" & Table, "Controle_Profile_Regles")
            ZoomW &= IIf(ZoomW = "", "", IIf(laRegl = "", "", " and ")) & laRegl
            If ZoomW <> "" Then Table = Table & " where " & ZoomW

            Cod_Sql = "select Top 1 num from " &
            "(SELECT " & Champs & ", ROW_NUMBER() OVER(ORDER BY " & TRIE_PAR & " asc) AS 'Num' FROM " & Table & ") r " &
            "where r." & Champs & "='" & Zone_Text.Text & "'"
            Dim rang As Integer = IsNull(CnExecuting("select isnull( (" & Cod_Sql & "),0)").Fields(0).Value, 0)
            'tester si l'enregistrement actuel n'est pas le dernier
            If rang < CnExecuting("Select count(*) from " & Table).Fields(0).Value Then
                'code sql pour ressortir l'enregistrement suivant num+1
                Dim Cod_Sql1 As String
                Cod_Sql1 = "select top 1 " & Champs & " from " &
               "(SELECT " & Champs & ", ROW_NUMBER() OVER(ORDER BY " & TRIE_PAR & " asc) AS 'Num' FROM " & Table & ") r " &
               "where r.num='" & rang + 1 & "'"
                Zone_Text.Text = CnExecuting(Cod_Sql1).Fields(0).Value

            Else
                MessageBoxRHP(539)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Public Sub Diviseur_Back(ByVal Table As String, ByVal Champs As String, ByVal TRIE_PAR As String, ByVal Zone_Text As Object, Optional ByVal AvecRegle As Boolean = True)
        Try
            TRIE_PAR = Champs
            If CnExecuting("Select count(*) from " & Table & " where " & Champs & "='" & Zone_Text.Text & "'").Fields(0).Value = 0 Then
                Exit Sub
            End If
            If CnExecuting("Select count(*) from " & Table).Fields(0).Value = 0 Then
                Exit Sub
            End If
            Dim Cod_Sql As String = ""

            Dim laRegl As String = ""
            Dim ZoomW As String = IIf(ContientIdSoc(Table).Count > 0, "isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe, "")
            If AvecRegle Then laRegl = FindLibelle("Regle", "Cod_Profile", theUser.Cod_Profile & "' and Table_Ref='" & Table, "Controle_Profile_Regles")
            ZoomW &= IIf(ZoomW = "", "", IIf(laRegl = "", "", " and ")) & laRegl
            If ZoomW <> "" Then Table = Table & " where " & ZoomW

            ' code sql pour ressortir le numéro de la ligne de l'enregistrement actuel
            Cod_Sql = "select top 1 num from " &
            "(SELECT " & Champs & ", ROW_NUMBER() OVER(ORDER BY " & TRIE_PAR & " asc) AS 'Num' FROM " & Table & ") r " &
            "where r." & Champs & "='" & Zone_Text.Text & "'"
            Dim rang As Integer = IsNull(CnExecuting("select isnull( (" & Cod_Sql & "),0)").Fields(0).Value, 0)
            'tester si l'enregistrement actuel n'est pas le premier
            If rang > 1 Then
                'code sql pour ressortir l'enregistrement suivant num+1
                Dim Cod_Sql1 As String
                Cod_Sql1 = "select top 1  " & Champs & " from " &
               "(SELECT " & Champs & ", ROW_NUMBER() OVER(ORDER BY " & TRIE_PAR & " asc) AS 'Num' FROM " & Table & ") r " &
               "where r.num='" & rang - 1 & "'"

                Zone_Text.Text = CnExecuting(Cod_Sql1).Fields(0).Value

            Else
                MessageBoxRHP(540)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Public Sub Diviseur_First(ByVal Table As String, ByVal Champs As String, ByVal TRIE_PAR As String, ByVal Zone_Text As Object, Optional ByVal AvecRegle As Boolean = True)
        '     Try
        TRIE_PAR = Champs
        If CnExecuting("Select count(*) from " & Table).Fields(0).Value = 0 Then
            Exit Sub
        End If
        Dim laRegl As String = ""
        Dim ZoomW As String = IIf(ContientIdSoc(Table).Count > 0, "isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe, "")
        If AvecRegle Then laRegl = FindLibelle("Regle", "Cod_Profile", theUser.Cod_Profile & "' and Table_Ref='" & Table, "Controle_Profile_Regles")
        ZoomW &= IIf(ZoomW = "", "", IIf(laRegl = "", "", " and ")) & laRegl
        If ZoomW <> "" Then Table = Table & " where " & ZoomW

        Dim Cod_Sql As String = ""
        Cod_Sql = "select  top 1 " & Champs & " from " &
           "(SELECT " & Champs & ", ROW_NUMBER() OVER(ORDER BY " & TRIE_PAR & " asc) AS 'Num' FROM " & Table & ") r " &
           "where r.num='" & 1 & "'"

        Zone_Text.Text = CnExecuting(Cod_Sql).Fields(0).Value

        '   Catch ex As Exception
        '    ErrorMsg(ex)
        '     End Try
    End Sub

    Public Sub Diviseur_Last(ByVal Table As String, ByVal Champs As String, ByVal TRIE_PAR As String, ByVal Zone_Text As Object, Optional ByVal AvecRegle As Boolean = True)
        Try
            TRIE_PAR = Champs
            Dim laRegl As String = ""
            Dim ZoomW As String = IIf(ContientIdSoc(Table).Count > 0, "isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe, "")
            If AvecRegle Then laRegl = FindLibelle("Regle", "Cod_Profile", theUser.Cod_Profile & "' and Table_Ref='" & Table, "Controle_Profile_Regles")
            ZoomW &= IIf(ZoomW = "", "", IIf(laRegl = "", "", " and ")) & laRegl
            If ZoomW <> "" Then Table = Table & " where " & ZoomW

            If CnExecuting("Select count(*) from " & Table).Fields(0).Value = 0 Then
                Exit Sub
            End If
            Dim last As Integer = CnExecuting("Select count(*) from " & Table).Fields(0).Value

            Dim Cod_Sql As String
            Cod_Sql = "select  top 1 " & Champs & " from " &
           "(SELECT " & Champs & ", ROW_NUMBER() OVER(ORDER BY " & TRIE_PAR & " asc) AS 'Num' FROM " & Table & ") r " &
           "where r.num='" & last & "'"

            Zone_Text.Text = CnExecuting(Cod_Sql).Fields(0).Value

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Public Function Diviseur_delete(ByVal Table As String, ByVal Champs As String, ByVal TRIE_PAR As String, ByVal Zone_Text As Object, ByVal frm As Object, Optional ByVal AvecConfirmation As Boolean = True, Optional viderEcran As Boolean = True) As Boolean
        Try
            If AvecConfirmation Then
                If MessageBoxRHP(541, Zone_Text.text) = MsgBoxResult.Cancel Then Return False
            End If
            Dim TblUse As String = CheckMouvemente(frm.findform, Zone_Text.text)
            If TblUse <> "" Then
                MessageBoxRHP(542, TblUse)
                Return False
            End If
            If CnExecuting("Select count(*) from " & Table & " where " & Champs & " = '" & Zone_Text.text & "'").Fields(0).Value >= 1 Then
                CnExecuting("delete from " & Table & " where " & Champs & " = '" & Zone_Text.text & "'" & IIf(ContientIdSoc(Table).Count > 0, " and id_Societe=" & Societe.id_Societe, ""))
                CnExecuting("insert into Mouchard_Suppression values ('" & Table & "','" & Champs.Replace("'", "") & "','" & Societe.id_Societe & " - " & Zone_Text.text & "','" & theUser.id_User & "',getdate())")
                If viderEcran Then Reset_Form(frm)
                Return True
            Else
                MessageBoxRHP(543, Zone_Text.text)
            End If

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
        Return False
    End Function


End Module
