Imports System.ComponentModel

Public Class Zoom_Simulation_Calculinverse
    Friend f As New RH_Simulation
    Dim SalB, SalN As Double
    Dim ecart As Double = 0
    Dim tolerance As Double = 0.001
    Private Sub Valeur_Cible_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Sal_Net_Cible_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub

    Private Sub Annuler_btn_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        If ShowMessageBox("Etes-vous sûr de vouloir terminer le traitement?", "Terminer", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        With Bgk
            .WorkerSupportsCancellation = True
            endCalcul = True
            .CancelAsync()
        End With
        Me.Close()
    End Sub
    Dim endCalcul As Boolean = False
    Dim nbTentative As Integer = 0
    Private Sub Bgk_DoWork(sender As Object, e As DoWorkEventArgs) Handles Bgk.DoWork
        Dim SalNetCible As Double = CDbl(Sal_Net_Cible_txt.Text)
        Dim SalNetActuel As Double = CDbl(SaLNetActuel_txt.Text)
        ecart = SalNetCible - SalNetActuel
        nbTentative = 0
        If Math.Abs(ecart) > 0 Then
            Do While Math.Abs(ecart) > Math.Abs(tolerance) And nbTentative < 150 And Not endCalcul
                f.TblSimulation.Select("Cod_Function='" & f.EBSalBaseRef & "'")(0)("Valeur") += ecart
                f.Invoke(Sub() f.Calcul(False))
                SalB = FormatNumber(f.TblSimulation.Select("Cod_Function='" & f.EBSalBaseRef & "'")(0)("Valeur"), 2)
                SalN = FormatNumber(Math.Round(CDbl(f.TblSimulation.Select("Cod_Function='" & f.ECSalNet & "'")(0)("Valeur")), 2), 2)
                ecart = SalNetCible - SalN
                If nbTentative > 10 Then
                    ecart = 0.1 * ecart
                End If
                nbTentative += 1
                Me.Invoke(Sub()
                              SaLNetActuel_txt.Text = FormatNumber(SalN, 2)
                              SLB_txt.Text = FormatNumber(SalB, 2)
                              nb.Text = nbTentative.ToString()
                              olog.Text = FormatNumber(ecart, 4)
                          End Sub)
            Loop
        End If
    End Sub
    Private Sub Bgk_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Bgk.RunWorkerCompleted
        Save_ud.Enabled = True
        Annuler_ud.Enabled = True
        f.MyGrd.Invalidate()
        endCalcul = False
        Me.Close()
    End Sub
    Private Sub Zoom_Simulation_Calculinverse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaLNetActuel_txt.Text = FormatNumber(f.TblSimulation.Select("Cod_Function='" & f.ECSalNet & "'")(0)("Valeur"), 2)
        SLB_txt.Text = FormatNumber(f.TblSimulation.Select("Cod_Function='" & f.EBSalBaseRef & "'")(0)("Valeur"), 2)
    End Sub
    Private Sub Sal_Net_Cible_txt_Leave(sender As Object, e As EventArgs) Handles Sal_Net_Cible_txt.Leave
        If IsNumeric(Sal_Net_Cible_txt.Text) Then Sal_Net_Cible_txt.Text = FormatNumber(CDbl(Sal_Net_Cible_txt.Text), 2)
    End Sub
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        If Not IsNumeric(Sal_Net_Cible_txt.Text) Then Sal_Net_Cible_txt.Text = 0
        If Not IsNumeric(SaLNetActuel_txt.Text) Then SaLNetActuel_txt.Text = 0
        endCalcul = False
        With Bgk
            .WorkerSupportsCancellation = True
            If Not .IsBusy Then .RunWorkerAsync()
        End With
    End Sub
End Class