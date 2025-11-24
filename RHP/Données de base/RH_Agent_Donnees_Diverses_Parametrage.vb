Public Class RH_Agent_Donnees_Diverses_Parametrage
    Sub Requesting()
        Dim rs As New ADODB.Recordset
        Try
            Dim C1, C2, C3, C4, C5, C6 As Object
            Notes_GRD.Rows.Clear()
            Dim Tbl As New DataTable
            Tbl = DATA_READER_GRD("select * from RH_Agent_Donnees_Diverses_Parametrage where id_Societe='" & Societe.id_Societe & "' order by Rang")
            With Tbl
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i).Item("Cod_Donnee"), "")
                    C2 = IsNull(.Rows(i).Item("Text_Donnee"), "")
                    C3 = IsNull(.Rows(i).Item("Typ_Donnee"), "")
                    C4 = IsNull(.Rows(i).Item("Menu_Donnee"), "")
                    C5 = IsNull(.Rows(i).Item("Variable_Paie"), "")
                    C6 = IsNull(.Rows(i).Item("Rang"), "")
                    Notes_GRD.Rows.Add(C1, C2, C3, C4, C5, C6)
                Next
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Saving()
        Dim swhere As String = ""
        Dim rg As New System.Text.RegularExpressions.Regex("\W")
        With Notes_GRD
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Cod_Donnee.Index, i).Value, "") <> "" Then
                    If rg.IsMatch(.Item(Cod_Donnee.Index, i).Value) Then
                        ShowMessageBox("Evitez les caractères spéciaux. Ligne : " & i + 1, "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
                        Return
                    End If
                    swhere &= IIf(swhere = "", "", ",") & "'" & .Item(Cod_Donnee.Index, i).Value & "'"
                End If
            Next
            If swhere <> "" Then
                CnExecuting("delete from RH_Agent_Donnees_Diverses_Parametrage where id_Societe='" & Societe.id_Societe & "' and Cod_Donnee not in (" & swhere & ")")
            Else
                CnExecuting("delete from RH_Agent_Donnees_Diverses_Parametrage where id_Societe='" & Societe.id_Societe & "'")
            End If
            CnExecuting("delete from RH_Elements_Paie where Typ_Function='AG' and id_Societe='" & Societe.id_Societe & "'")
            For i = 0 To .RowCount - 2
                Dim rs1, rs As New ADODB.Recordset
                If IsNull(.Item(1, i).Value, "") <> "" Then
                    rs1.Open("select * from RH_Agent_Donnees_Diverses_Parametrage  where id_Societe='" & Societe.id_Societe & "' and Cod_Donnee='" & .Item(Cod_Donnee.Index, i).Value & "'", cn, 2, 2)
                    If rs1.EOF Then
                        rs1.AddNew()
                        rs1("id_Societe").Value = Societe.id_Societe
                        rs1("Cod_Donnee").Value = .Item(Cod_Donnee.Index, i).Value
                    Else
                        rs1.Update()
                    End If
                    rs1("Text_Donnee").Value = .Item(Text_Donnee.Index, i).Value
                    rs1("Typ_Donnee").Value = .Item(Typ_Donnee.Index, i).Value
                    rs1("Menu_Donnee").Value = .Item(Menu_Donnee.Index, i).Value
                    rs1("Variable_Paie").Value = IsNull(.Item(Variable_Paie.Index, i).Value, False)
                    rs1("Rang").Value = .Item(Rang.Index, i).Value
                    rs1.Update()
                    rs1.Close()
                    If CBool(IsNull(.Item(Variable_Paie.Index, i).Value, False)) Then
                        Dim codFunction As String = "agt__" & .Item(Cod_Donnee.Index, i).Value.ToString().ToUpper()
                        rs.Open("select *  from RH_Elements_Paie where Cod_Function='" & codFunction & "' and id_Societe=" & Societe.id_Societe & "  and isnull(Proteger,'false')='false' ", cn, 2, 2)
                        If rs.EOF Then
                            rs.AddNew()
                            rs("Cod_Function").Value = codFunction
                            rs("id_Societe").Value = Societe.id_Societe
                            rs("estSysteme").Value = False
                        Else
                            rs.Update()
                        End If
                        rs("Typ_Function").Value = "AG"
                        rs("Lib_Function").Value = .Item(Text_Donnee.Index, i).Value
                        rs("Lib_Abr").Value = .Item(Text_Donnee.Index, i).Value
                        rs("Abr_Function").Value = codFunction
                        rs("Groupe_Function").Value = "AG_Agent"
                        rs("Formule_Function").Value = ""
                        rs("Regex").Value = $"\b({ codFunction})\b"
                        rs("Typ_Retour").Value = If(.Item(Typ_Donnee.Index, i).Value = "Dat", "smalldatetime", If(.Item(Typ_Donnee.Index, i).Value = "Ent", "int", If(.Item(Typ_Donnee.Index, i).Value = "Num", "float", "nvarchar(50)")))
                        rs("Nb_Decimal").Value = 2
                        rs("Est_Pourcentage").Value = False
                        rs.Update()
                        rs.Close()
                    End If
                End If
            Next

        End With
        Building_Sys_RH_Agent_AG()
        Requesting()
    End Sub

    Private Sub Admin_BlocNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Combo_GRD(Typ_Donnee)
        Requesting()
    End Sub

    Private Sub Notes_GRD_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Notes_GRD.CellMouseMove
        With Notes_GRD
            If e.ColumnIndex = Menu_Donnee.Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub

    Private Sub Notes_GRD_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Notes_GRD.CellMouseDoubleClick
        With Notes_GRD
            If .CurrentRow Is Nothing Then Exit Sub
            If .CurrentCell.ColumnIndex = Menu_Donnee.Index Then
                If .Item(Typ_Donnee.Index, .CurrentRow.Index).Value = "Mnu" Then
                    Appel_Zoom("Num_Zoom", "Table_Ref", "Controle_Def_Zoom", "1=1", .CurrentCell, Me)
                ElseIf .Item(Typ_Donnee.Index, .CurrentRow.Index).Value = "Rub" Then
                    Appel_Zoom("Nom_Controle", "Texte_Rubrique", "Param_Rubriques", "1=1", .CurrentCell, Me)
                End If
            End If
        End With
    End Sub
End Class