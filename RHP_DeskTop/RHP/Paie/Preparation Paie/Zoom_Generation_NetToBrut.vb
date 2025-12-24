Imports System.ComponentModel
Public Class Zoom_Generation_NetToBrut
    Friend PrePaie As New PayRollEngine
    Friend Tmr As New Timer
    Friend evABrutifier, evBrutifiee, evSalNet As String
    Friend WithEvents BKG_NetToBrut As New BackgroundWorker
    Dim SalNetCible As Double = 0
    Dim PrimeABrutifier As Double = 0
    Dim tolerance As Double = 0.5
    Dim SalN As Double = 0
    Private Sub Zoom_PBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Tmr
            .Interval = 5
            .Start()
            AddHandler .Tick, AddressOf Actualiser
        End With
        With BKG_NetToBrut
            .WorkerSupportsCancellation = True
            If Not .IsBusy Then .RunWorkerAsync()
        End With
    End Sub
    Sub Actualiser()
        Etape.Text = EtapeStr
        Etape.Refresh()
    End Sub
    Private Sub BKG_NetToBrut_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_NetToBrut.DoWork
        Dim oldEcart As Double = 0
        Dim str As String = ""
        Dim nbTentative As Integer = 0
        With PrePaie.TblPrePaie
            For i = 0 To .Rows.Count - 1
                If Not BKG_NetToBrut.CancellationPending Then
                    str = (i + 1) & "/" & .Rows.Count & " - " & .Rows(i)("Matricule") & ", Prime à brutifier : " & FormatNumber(.Rows(i)(evABrutifier), 2)
                    EtapeStr = str
                    .Rows(i)(evBrutifiee) = 0
                    PrePaie.CalculPaie(.Rows(i)("Matricule"), False)
                    PrimeABrutifier = .Rows(i)(evABrutifier)
                    SalNetCible = .Rows(i)(evABrutifier) + .Rows(i)(evSalNet)
                    oldEcart = PrimeABrutifier
                    If Math.Abs(PrimeABrutifier) > 0 Then
                        nbTentative = 0
                        Do While Math.Abs(PrimeABrutifier) > Math.Abs(tolerance) And Math.Abs(oldEcart) * 1.0001 > Math.Abs(PrimeABrutifier) And (Math.Sign(oldEcart) = Math.Sign(PrimeABrutifier) Or Math.Round(PrimeABrutifier, 2) = 0) And Not BKG_NetToBrut.CancellationPending And nbTentative <= 100
                            EtapeStr = str & ", reliquat : " & PrimeABrutifier
                            .Rows(i)(evBrutifiee) += PrimeABrutifier
                            PrePaie.CalculPaie(.Rows(i)("Matricule"), False)
                            oldEcart = PrimeABrutifier
                            PrimeABrutifier = SalNetCible - Math.Round(CDbl(.Rows(i)(evSalNet)), 2)
                            nbTentative += 1
                        Loop
                    End If
                Else
                    e.Cancel = True
                    Exit Sub
                End If
            Next
        End With
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        If ShowMessageBox("Etes-vous sûr de vouloir terminer le traitement?", "Terminer", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        With BKG_NetToBrut
            .WorkerSupportsCancellation = True
            .CancelAsync()
        End With
        Me.Close()
    End Sub
    Private Sub BKG_NetToBrut_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_NetToBrut.RunWorkerCompleted
        Me.Close()
    End Sub
End Class