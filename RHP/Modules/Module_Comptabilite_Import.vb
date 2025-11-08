Module Module_Comptabilite_Import
    Function ImportComptable(Optional idImport As String = "") As ArrayList
        Dim RslArr As New ArrayList
        CnExecuting("exec Sys_Ctb_ImportComptable '" & idImport & "'")
        Return RslArr
    End Function
    Function LogImport(IdImport As String, PieceGroupe As Integer, Rsl As Boolean, Msg As String, PieceGenere As String) As ArrayList
        Dim RslArr As New ArrayList
        RslArr.Add(False)
        RslArr.Add(Msg)
        RslArr.Add(IdImport)
        RslArr.Add(IdImport)
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Compta_His_Gnr_Import_Log where Ref_Import='" & IdImport & "' and Piece_groupe='" & PieceGroupe & "'", cn, 2, 2)
        If Not rs.EOF Then
            rs.Update()
            rs("Message_Import").Value = Msg
            rs("Flag_Import").Value = Rsl
            rs("Num_Pie_Generee").Value = PieceGenere
            rs.Update()
        End If
        rs.Close()
        Return RslArr
    End Function
End Module
