Public Class Zoom_RH_Preparation_Paie_RegenrationEV
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        Me.Close()
    End Sub
    Function getModules() As String
        Dim strChk As String = ""
        strChk &= IIf(chk_conge.Checked, "1", "0")
        strChk &= ";" & IIf(Chk_prets.Checked, "1", "0")
        strChk &= ";" & IIf(chk_Avances.Checked, "1", "0")
        strChk &= ";" & IIf(chk_interet.Checked, "1", "0")
        strChk &= ";" & IIf(chk_fraisMedicaux.Checked, "1", "0")
        strChk &= ";" & IIf(chk_NF.Checked, "1", "0")
        Return strChk
    End Function
End Class