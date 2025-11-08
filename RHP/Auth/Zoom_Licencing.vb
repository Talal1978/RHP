Public Class Zoom_Licencing
    Private Sub adddoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Zoom_Licencing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = leMenu.Icon
        otxt.Text = GetLiceIdent()
        If oKle.Trim <> "" Then
            oKle = oKle.Replace("-", "")
            txtS1.Text = Mid(oKle, 1, 4)
            txtS2.Text = Mid(oKle, 5, 4)
            txtS3.Text = Mid(oKle, 9, 4)
            txtS4.Text = Mid(oKle, 13, 4)
        End If
    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_ud.Click
        Dim strKy As String = txtS1.Text & txtS2.Text & txtS3.Text & txtS4.Text
        If EstLicConforme(strKy) Then
            Dim rs As New ADODB.Recordset
            rs.Open("select * from Controle_Certificat", cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
            Else
                rs.Update()
            End If
            oKle = strKy
            rs("Licence").Value = strKy
            rs.Update()
            rs.Close()
            VerificationLicenceEtVersion()
            Me.Close()
        Else
            ShowMessageBox("N° de série non valide.", "Erreur d'authentification", MessageBoxButtons.OK, msgIcon.Error)
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Enter
                Me.Close()
            Case Keys.Escape
                Me.Close()
            Case (Keys.Control Or Keys.V)
                txtS1.Text = ""
                Dim str As String = Clipboard.GetText
                If str.Split("-").Length = 4 Then
                    txtS1.Text = str.Split("-")(0)
                    txtS2.Text = str.Split("-")(1)
                    txtS3.Text = str.Split("-")(2)
                    txtS4.Text = str.Split("-")(3)
                End If
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub txtS3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtS4.TextChanged, txtS2.TextChanged, txtS3.TextChanged, txtS1.TextChanged
        Dim strKy As String = txtS1.Text & txtS2.Text & txtS3.Text & txtS4.Text
        If EstLicConforme(strKy) Then
            pbLic.Image = My.Resources.success
        Else
            pbLic.Image = Nothing
        End If
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
End Class