Module Module_Import_Donnees
    Friend TblImport As New DataTable

    Sub ImportDonnees(ByVal ModeleImport As String, ByVal TblName As String, ByVal FichierDonnees As String)
        TblImport.Columns.Clear()
        Dim oFields As String = ""
        Dim Tbl As New DataTable
        Dim rs As New ADODB.Recordset
        Try

            Tbl = DATA_READER_GRD("select Nom_Champs from Param_Modele_Import_Donnees where Cod_Impotation='" & ModeleImport & "'")
            With Tbl
                For i = 0 To .Rows.Count - 1
                    TblImport.Columns.Add(IsNull(.Rows(i).Item("Nom_Champs"), ""))
                    oFields = oFields & ","
                Next
            End With
            If TblImport.Columns.Count = 0 Then
                MessageBoxRHP(420)
                Exit Sub
            End If

            oFields = Microsoft.VisualBasic.Right(oFields, oFields.Length - 1)

            Dim str As String = ""
            Dim StrTbl() As String
            Dim k As Integer = 0
            Dim n As Integer = 0
            Dim sr As New IO.StreamReader(FichierDonnees)
            Do Until sr.Peek = -1
                str = sr.ReadLine.Trim
                StrTbl = str.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                k = StrTbl.Length
                If k <> TblImport.Columns.Count Then
                    MessageBoxRHP(419)
                    sr.Close()
                    GoTo Suite
                End If
                TblImport.Rows.Add("")
                For i = 0 To k - 1
                    TblImport.Rows(n).Item(i) = StrTbl(i)
                Next
                n += 1
            Loop
            sr.Close()

            With TblImport
                For i = 0 To .Rows.Count - 1
                    rs.Open("select * from " & TblName, cn, 2, 2)
                    rs.AddNew()
                    For j = 0 To .Columns.Count - 1
                        rs(.Columns(j).ColumnName).Value = .Rows(i).Item(j)
                    Next
                    rs.Update()
                    rs.Close()
                Next
            End With




suite:
            Exit Sub

        Catch ex As Exception
            ErrorMsg(ex)
            rs.Close()
        End Try

    End Sub
End Module
