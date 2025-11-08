Public Class Org_Grade
    Friend Modifie As Boolean = False
    Dim TblGrade As New DataTable
    Private Sub Grd_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles Grd.CellValidating
        If e.RowIndex < 0 Then Return
        With Grd
            If e.ColumnIndex = .Columns("Code").Index Then
                If IsNull(e.FormattedValue, "") = "" And e.RowIndex < Grd.RowCount - 1 Then
                    e.Cancel = True
                End If

                Dim CodGrd As String = ""
                For i = 0 To .RowCount - 2
                    If i <> e.RowIndex Then
                        If IsNull(e.FormattedValue, "").Trim = IsNull(.Item("Code", i).Value, "").Trim Then
                            ShowMessageBox("Code grade déjà utilisé")
                            e.Cancel = True
                        End If
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub Grd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellValueChanged
        Modifie = True
    End Sub
    Private Sub Grd_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles Grd.UserDeletingRow
        With Grd
            Dim CodGrd As String = IsNull(.Item("Code", e.Row.Index).Value, "").Trim
            If CodGrd <> "" Then
                If CnExecuting("Select count(*) from Org_Poste where id_Societe=" & Societe.id_Societe & " and Cod_Grade='" & CodGrd & "'").Fields(0).Value > 0 Then
                    ShowMessageBox("Elément utilisé dans la table des Postes", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
                    e.Cancel = True
                    Return
                End If
            End If
        End With
        Modifie = True
    End Sub
    Private Sub Org_Grade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Requesting()
    End Sub
    Sub Requesting()
        TblGrade = DATA_READER_GRD("select Cod_Grade as Code, Lib_Grade as Grade from Org_Grade where id_Societe=" & Societe.id_Societe & " order by Niveau")
        With TblGrade
            .Columns("Code").ReadOnly = False
            .Columns("Grade").ReadOnly = False
        End With
        Grd.DataSource = TblGrade
        Grd.Columns("Grade").MinimumWidth = 350
        Modifie = False
    End Sub
    Sub ToUp()
        If Grd.SelectedCells.Count = 0 Then Return
        Dim r As Integer = Grd.SelectedCells(0).OwningRow.Index
        Dim rw As DataRow = TblGrade.NewRow
        rw(0) = Grd.Item("Code", r).Value
        rw(1) = Grd.Item("Grade", r).Value
        If r > 0 Then
            TblGrade.Rows.RemoveAt(r)
            TblGrade.Rows.InsertAt(rw, r - 1)
            Grd.ClearSelection()
            Grd.Rows(r - 1).Selected = True
            Modifie = True
        End If
    End Sub
    Sub ToDown()
        If Grd.SelectedCells.Count = 0 Then Return
        Dim r As Integer = Grd.SelectedCells(0).OwningRow.Index
        Dim rw As DataRow = TblGrade.NewRow
        rw(0) = Grd.Item("Code", r).Value
        rw(1) = Grd.Item("Grade", r).Value
        If r < Grd.RowCount - 2 Then
            TblGrade.Rows.RemoveAt(r)
            TblGrade.Rows.InsertAt(rw, r + 1)
            Grd.ClearSelection()
            Grd.Rows(r + 1).Selected = True
            Modifie = True
        End If
    End Sub
    Sub Saving()
        If Modifie = True Then
            If ShowMessageBox("Voulez-vous enregistrer les modifications?", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
            CnExecuting("delete from Org_Grade where id_Societe=" & Societe.id_Societe)
            Dim rs As New ADODB.Recordset
            rs.Open("select * from Org_Grade", cn, 2, 2)
            With Grd
                For i = 0 To .RowCount - 2
                    If IsNull(.Item("Code", i).Value, "").Trim <> "" Then
                        rs.AddNew()
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Cod_Grade").Value = IsNull(.Item("Code", i).Value, "").Trim
                        rs("Lib_Grade").Value = IsNull(.Item("Grade", i).Value, "").Trim
                        rs("Niveau").Value = i + 1
                        rs.Update()
                    End If
                Next
            End With
            rs.Close()
        End If
    End Sub
End Class