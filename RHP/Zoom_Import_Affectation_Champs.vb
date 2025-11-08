Public Class Zoom_Import_Affectation_Champs


    Private Sub Zoom_Import_Affectation_Champs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim str As String = FindParam("AffectationAuto")
        If str = "O" Then
            Ordre.Checked = True
        Else
            Nom.Checked = True
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        GModeAffectationImport = IIf(Nom.Checked, "N", "O")
        If SetParDefaut.Checked Then
            CnExecuting("Update Param_General set Valeur='" & IIf(Nom.Checked, "N", "O") & "' where Cod_Param='SetParDefaut'")
            CnExecuting("Update Param_General set Valeur='O' where Cod_Param='SetParDefaut'")
        End If
        Me.Close()
    End Sub

    Private Sub Annuler_ud_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
End Class