Public Class Zoom_Apropos_Lic
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quitter.Click
        Me.Close()
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Actualiser.MouseEnter, Quitter.MouseEnter
        Cursor = Cursors.Hand
    End Sub
    Private Sub Label1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Actualiser.MouseLeave, Quitter.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub Zoom_Apropos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Detail()
    End Sub

    Private Sub Label3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualiser.Click
        VerificationLicenceEtVersion()
        Detail()
    End Sub
    Sub Detail()
        Dim Str As String = "Numéro de version : " & NumVersion & vbCrLf
        Dim y As Integer = 48
        Dim x As Integer = 5
        Dim w As Integer = 200
        Dim s As Integer = 0
        Dim h As Integer = 22
        Dim totalW As Integer = 350
        With LicTbl
            For i = 0 To .Rows.Count - 1
                Dim lb, dt As New Label
                With lb
                    .AutoSize = False
                    .Size = New Size(w, h)
                    .TextAlign = ContentAlignment.MiddleLeft
                    .ForeColor = Color.FromArgb(56, 153, 185)
                    .Location = New Point(x, y)
                    .Text = LicTbl.Rows(i).Item("Libelle")
                End With
                With dt
                    .AutoSize = False
                    .Size = New Size(100, h)
                    .TextAlign = ContentAlignment.MiddleCenter
                    .ForeColor = Color.FromArgb(94, 185, 117)
                    .Location = New Point(x + w + 2, y)
                    Select Case LicTbl.Rows(i).Item("Option")
                        Case "Tranche_Effectif"
                            .Text = IIf(LicTbl.Rows(i).Item("Droit") = "-1", "illimité", "Moins de " & LicTbl.Rows(i).Item("Droit"))
                        Case Else
                            .Text = IIf(LicTbl.Rows(i).Item("Data") = "Bool", IIf(LicTbl.Rows(i).Item("Droit") = "1", "Oui", "Non"), LicTbl.Rows(i).Item("Droit"))
                    End Select
                    If IsNumeric(.Text) Then
                        .Font = New Font(Me.Font.Name, Me.Font.Size, FontStyle.Bold)
                    Else
                        .Font = New Font(Me.Font.Name, Me.Font.Size, FontStyle.Bold Or FontStyle.Underline Or FontStyle.Italic)
                    End If
                    .BringToFront()
                End With
                Pnl.Controls.Add(lb)
                Pnl.Controls.Add(dt)
                y += h + s
            Next
        End With
        Num_Licence_txt.Text = oKle.Replace("-", "")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ShowMessageBox(UriStr0 & "/lic_rhp.php?db=" & DB & "&usr=" & theUser.Login & "&soc=" & Societe.Denomination & "&ver=" & NumVersion & "&lic=" & oKle)
    End Sub
End Class