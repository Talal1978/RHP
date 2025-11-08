Public Class Admin_ChangePwd_Agent

    Private Sub Log_In_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Enter Then Entrer()
    End Sub
    Sub Entrer()
        Dim rgNum As New System.Text.RegularExpressions.Regex("[0-9]")
        Dim rgAlfa As New System.Text.RegularExpressions.Regex("[a-z]", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        Dim pwdLen As Object = FindParam("PWD_Longueur")
        If Not IsNumeric(pwdLen) Then pwdLen = 6

        If Old_Pwd_User_Text.Text = "" Then
            MessageBoxRHP(326)
            Old_Pwd_User_Text.Select()
            Old_Pwd_User_Text.SelectAll()
            Exit Sub
        ElseIf CnExecuting("Select PW from RH_Agent where Login='" & theUser.Login & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value <> Encrypt(Old_Pwd_User_Text.Text) Then
            MessageBoxRHP(327)
            Old_Pwd_User_Text.Select()
            Old_Pwd_User_Text.SelectAll()
            Exit Sub
        ElseIf LTrim(RTrim(Pwd1_Text.Text)) = "" Then
            MessageBoxRHP(328)
            Pwd1_Text.Select()
            Pwd1_Text.SelectAll()
            Exit Sub
        ElseIf Pwd1_Text.Text <> Pwd2_Text.Text And LTrim(RTrim(Pwd1_Text.Text)) <> "" Then
            MessageBoxRHP(329)
            Pwd1_Text.Select()
            Pwd1_Text.SelectAll()
            Exit Sub
        ElseIf Pwd1_Text.Text.Length < CInt(pwdLen) Then
            ShowMessageBox("Le mot de passe doit contenir au moins " & CInt(pwdLen) & " caractères.")
            Pwd1_Text.Select()
            Pwd1_Text.SelectAll()
            Exit Sub
        ElseIf (Not rgNum.IsMatch(Pwd1_Text.Text) Or Not rgAlfa.IsMatch(Pwd1_Text.Text)) And FindParam("PWD_AlphaNum") = "O" Then
            ShowMessageBox("Le mot de passe doit contenir des lettres et des chiffres")
            Pwd1_Text.Select()
            Pwd1_Text.SelectAll()
            Exit Sub
        ElseIf Pwd1_Text.Text.Trim = Old_Pwd_User_Text.Text.Trim Then
            ShowMessageBox("Le nouveau mot de passe est identique à l'ancien.")
            Pwd1_Text.Select()
            Pwd1_Text.SelectAll()
            Exit Sub
        Else
            CnExecuting("Update RH_Agent set PW='" & Encrypt(Pwd1_Text.Text) & "' where Login='" & theUser.Login & "' and id_Societe=" & Societe.id_Societe)
            MessageBoxRHP(330)
        End If
        Me.Close()
    End Sub
    Private Sub Refresh_D_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub

    Private Sub Save_D_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        Entrer()
    End Sub
    Private Sub Admin_ChangePwd_Load(sender As Object, e As EventArgs) Handles Me.Load
        If theUser.is_AD Then
            ShowMessageBox("Ce compte est géré en Active Directory. Pour changer son mot de passe contactez votre Administrateur", "Active Directory", MessageBoxButtons.OK, msgIcon.Stop)
            Me.Close()
        End If
    End Sub
End Class