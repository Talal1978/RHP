Public Class Zoom_Evaluation_Reporter
    Friend frm As New Action_Evaluation
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        If Dat_Du.Value >= Dat_Au.Value Then
            ShowMessageBox("Incohérence date début et date fin", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        frm.Dat_Au.Value = Dat_Au.Value
        frm.Dat_Du.Value = Dat_Du.Value
        Me.Close()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
End Class