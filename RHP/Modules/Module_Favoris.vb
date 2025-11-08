Imports DevComponents.AdvTree
Module Module_Favoris
    Dim oTable As New DataTable

    Dim Adv As AdvTree

    Sub RequestFavoris(ByVal Adv As TreeView)
        Try
            Dim CntScripts As ContextMenu = Adv.Tag
            Dim CodSql As String = ""
            CodSql = "exec Sys_Favoris '" & theUser.id_User & "'"
            oTable = DATA_READER_GRD(CodSql)
            Dim nRows() As DataRow
            nRows = oTable.Select("[Typ_Ecran]='MNU'", "Rang Asc")
            Adv.Nodes.Clear()
            For i = 0 To nRows.Length - 1
                Dim N As New TreeNode
                With N
                    .Name = nRows(i)("Name_Ecran")
                    .Text = nRows(i)("Text_Ecran")
                    .ImageIndex = MenuImageArray.IndexOf(nRows(i)("Image1"))
                    .Tag = {nRows(i)("Typ_Ecran"), 1, nRows(i)("Image1")}
                End With
                Adv.Nodes.Add(N)
                Dim mRows() As DataRow
                mRows = oTable.Select("[Parent]='" & N.Name & "'", "Rang Asc")
                For j = 0 To mRows.GetUpperBound(0)
                    Dim M As New TreeNode
                    With M
                        .Name = mRows(j)("Name_Ecran")
                        .Text = mRows(j)("Text_Ecran")
                        .ImageIndex = MenuImageArray.IndexOf(mRows(j)("Image1"))
                        .Tag = {mRows(j)("Typ_Ecran"), 2, mRows(j)("Image1")}
                        If mRows(j)("Typ_Ecran") <> "FDR" Then .ContextMenu = CntScripts
                    End With
                    N.Nodes.Add(M)
                    N.ExpandAll()
                    Dim oRows() As DataRow
                    oRows = oTable.Select("[Parent]='" & M.Name & "'")
                    For k = 0 To oRows.Length - 1
                        Dim O As New TreeNode
                        With O
                            .Name = oRows(k)("Name_Ecran")
                            .Text = oRows(k)("Text_Ecran")
                            .ImageIndex = MenuImageArray.IndexOf(oRows(k)("Image1"))
                            .Tag = {oRows(k)("Typ_Ecran"), 3, oRows(k)("Image1")}
                            If oRows(k)("Typ_Ecran") <> "FDR" Then .ContextMenu = CntScripts
                        End With
                        M.Nodes.Add(O)
                        M.ExpandAll()
                        Dim pRows() As DataRow
                        pRows = oTable.Select("[Parent]='" & O.Name & "'")
                        For h = 0 To pRows.Length - 1
                            Dim P As New TreeNode
                            With P
                                .Name = pRows(h)("Name_Ecran")
                                .Text = pRows(h)("Text_Ecran")
                                .ImageIndex = MenuImageArray.IndexOf(pRows(h)("Image1"))
                                .Tag = {pRows(h)("Typ_Ecran"), 4, pRows(h)("Image1")}
                                If pRows(h)("Typ_Ecran") <> "FDR" Then .ContextMenu = CntScripts
                            End With
                            O.Nodes.Add(P)
                            O.ExpandAll()
                        Next
                    Next
                Next
            Next
            Adv.ExpandAll()
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

End Module
