Module Module_CheckMouvemente
    Public Function CheckMouvemente(ByVal Frm As Form, ByVal ValeurIndex As String) As String
        Dim NomTbl As String = ""
        Dim rs1001 As New ADODB.Recordset
        rs1001.Open("SELECT distinct Champs_Use,Table_Use FROM Controle_Def_Index_Ecran where Name_Ecran='" & Frm.Name & "' and Table_Ref<>Table_Use", cn, 3, 3)
        Do While Not rs1001.EOF
            If CnExecuting("Select count(*) from INFORMATION_SCHEMA.COLUMNS where TABLE_CATALOG='" & DB & "' and TABLE_NAME='" & rs1001("Table_Use").Value & "' and COLUMN_NAME='" & rs1001("Champs_Use").Value & "'").Fields(0).Value > 0 Then
                If CnExecuting("select count(" & rs1001("Champs_Use").Value & ") from " & rs1001("Table_Use").Value & " where " & rs1001("Champs_Use").Value & " ='" & ValeurIndex & "' " & IIf(ContientIdSoc(rs1001("Table_Use").Value).Count > 0, " and id_Societe=" & Societe.id_Societe, "")).Fields(0).Value > 0 Then
                    NomTbl = rs1001("Table_Use").Value
                    Exit Do
                End If
            End If
            rs1001.MoveNext()
        Loop
        rs1001.Close()
        Return NomTbl
    End Function

End Module
