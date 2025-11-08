Public Class Zoom_Typ_Graph
    Friend tbl As New DataTable
    Friend fArray As New ArrayList
    Private Sub Typ_Graphe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Typ_Graphe.SelectedIndexChanged
        If Typ_Graphe.SelectedIndex < 0 Then Return
        ChargerChart(Chart1, tbl, Typ_Graphe.SelectedIndex, Afficher_Graphe_Valeur.Checked, Afficher3D.Checked)
    End Sub
    Private Sub Afficher_Graphe_Valeur_CheckedChanged(sender As Object, e As EventArgs) Handles Afficher_Graphe_Valeur.CheckedChanged
        With Chart1
            For i As Integer = 0 To .Series.Count - 1
                .Series(i).IsValueShownAsLabel = Afficher_Graphe_Valeur.Checked
            Next
        End With
    End Sub
    Private Sub Zoom_Typ_Graph_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not tbl Is Nothing Then
            ChargerChart(Chart1, tbl, Typ_Graphe.SelectedIndex, Afficher_Graphe_Valeur.Checked, Afficher3D.Checked)
        End If
    End Sub
    Private Sub Zoom_Typ_Graph_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If fArray.Count >= 3 Then
            If Typ_Graphe.SelectedIndex >= 0 Then fArray(0) = Typ_Graphe.SelectedIndex
            fArray(1) = Afficher_Graphe_Valeur.Checked
            fArray(2) = Afficher3D.Checked
        End If
    End Sub
    Private Sub Afficher3D_CheckedChanged(sender As Object, e As EventArgs) Handles Afficher3D.CheckedChanged
        With Chart1
            If .ChartAreas.Count > 0 Then .ChartAreas(0).Area3DStyle.Enable3D = Afficher3D.Checked
        End With
    End Sub
End Class