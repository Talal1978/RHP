Public Class Zoom_Chercher
    Friend Grd As New DataGridView
    Friend r As Integer = 0
    Friend c As Integer = 0
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_ud.Click
        Chercher()
    End Sub
    Sub Chercher()
        If txtRecherche.Text = "" Then Exit Sub
        If Grd.RowCount = 1 Then Exit Sub
        With Grd
            For Each c As DataGridViewCell In .SelectedCells
                c.Selected = False
            Next
            For i = r To .RowCount - 2
                For j = c To .ColumnCount - 1
                    If .Columns(j).Visible Then
                        If IsNull(.Item(j, i).Value, "").ToUpper.Contains(txtRecherche.Text.ToUpper) Then
                            .Item(j, i).Selected = True
                            .FirstDisplayedCell = .Item(j, i)
                            If j < .ColumnCount - 1 Then
                                c = j + 1
                                r = i
                            ElseIf i < .RowCount - 1 Then
                                c = 0
                                r = i + 1
                            End If
                            Exit Sub
                        End If
                    End If
                Next
                c = 0
                r = i
            Next
            If r = .RowCount - 2 And c = 0 Then
                ShowMessageBox("Fin de recherche", "RHPS")
                r = 0
                c = 0
                Exit Sub
            End If
        End With
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub

    Private Sub Zoom_Chercher_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        r = 0
        c = 0
        txtRecherche.Text = ""
    End Sub

    Private Sub txtRecherche_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecherche.KeyDown
        If e.KeyData = Keys.Enter Then
            Chercher()
        End If
    End Sub


    Private Sub txtRecherche_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecherche.TextChanged
        r = 0
        c = 0
    End Sub

    Private Sub Zoom_Chercher_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            Chercher()
        End If
    End Sub
End Class