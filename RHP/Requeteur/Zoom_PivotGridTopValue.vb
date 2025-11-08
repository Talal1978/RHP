Public Class Zoom_PivotGridTopValue
    Friend itsOk As Boolean = False
    Private Sub Zoom_PivotGridTopValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        If Not Tout_chk.Checked Then
            If Tri_chk.Checked Then
                If SensTri_cbo.SelectedIndex < 0 Then SensTri_cbo.SelectedIndex = 0
                If TrierPar_cbo.SelectedIndex < 0 Then
                    If TrierPar_cbo.Items.Count = 0 Then
                        ShowMessageBox("Aucun champs de données pour le tri", Me.Text, MessageBoxButtons.OK, msgIcon.Error)
                        Return
                    Else
                        ShowMessageBox("veuillez choisir un champs de tri", Me.Text, MessageBoxButtons.OK, msgIcon.Error)
                        TrierPar_cbo.DroppedDown = True
                        Return
                    End If
                End If
            End If
        End If
        itsOk = True
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        itsOk = False
        Me.Close()
    End Sub
End Class