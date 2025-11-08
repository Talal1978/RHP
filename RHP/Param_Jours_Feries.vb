Public Class Param_Jours_Feries
    Private Sub Refresh_D_Click(sender As Object, e As EventArgs)
        Request()
    End Sub
    Sub Request()
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT id_Jour, Lib_Jour as 'Fête', Dat as 'Date', Duree as 'Durée', Repete as 'Répéter', Hijir
FROM Param_Jours_Feries  order by Dat")
        With Grd_JoursFeries
            .DataSource = Tbl
            .Columns("id_Jour").Visible = False
            Tbl.Columns("Fête").ReadOnly = False
            Tbl.Columns("Date").ReadOnly = False
            Tbl.Columns("Durée").ReadOnly = False
            Tbl.Columns("Répéter").ReadOnly = False
            Tbl.Columns("Hijir").ReadOnly = False
            Tbl.Columns("id_Jour").AllowDBNull = True
            .Columns("Durée").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    Sub Saving()
        Try
            Dim rs As New ADODB.Recordset
            Dim rnd As New Random
            Dim flg As Integer = rnd.Next(50, 9854)
            With Grd_JoursFeries
                For i = 0 To .RowCount - 1
                    If ConvertNombre(.Item("Durée", i).Value) > 0 Then
                        rs.Open("select * from Param_Jours_Feries where convert(nvarchar(50),id_Jour)='" & IsNull(.Item("id_Jour", i).Value, "") & "'", cn, 2, 2)
                        If rs.EOF Then
                            rs.AddNew()
                        Else
                            rs.Update()
                        End If
                        rs("Lib_Jour").Value = .Item("Fête", i).Value
                        rs("Dat").Value = .Item("Date", i).Value
                        rs("Duree").Value = .Item("Durée", i).Value
                        rs("Repete").Value = .Item("Répéter", i).Value
                        rs("Hijir").Value = .Item("Hijir", i).Value
                        rs("Flg").Value = flg
                        rs.Update()
                        rs.Close()
                    End If
                Next
            End With
            CnExecuting("delete from Param_Jours_Feries where isnull(Flg,0) <> " & flg)

            Dim swhere As String = ""
            If ShowMessageBox("Voulez-vous appliquer les jours fériés sélectionnés à toutes les sociétés?", "Vérification", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.OK Then
                CnExecuting("insert into Param_Societe_Jours_Feries(   id_Societe, id_Jour, Lib_Jour, Dat, Duree, Repete, Hijir)
SELECT id_Societe,id_Jour, Lib_Jour, Dat, Duree, Repete, Hijir
FROM  Param_Jours_Feries p, Param_Societe s
where not exists(select id_Jour from Param_Societe_Jours_Feries f where f.Id_Societe=s.id_Societe and p.Id_Jour=f.id_Jour)")
            End If
            Request()
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub Param_Jours_Feries_Load(sender As Object, e As EventArgs) Handles Me.Load
        Request()
        Grd_JoursFeries.ContextMenuStrip = AddContextMenu(True, True, True, True, True, True, True, True)
    End Sub
    'Private Sub Grd_JoursFeries_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_JoursFeries.DataError
    '    Try

    '    Catch ex As Exception
    '        ShowMessageBox(ex.Message)
    '    End Try
    'End Sub
End Class