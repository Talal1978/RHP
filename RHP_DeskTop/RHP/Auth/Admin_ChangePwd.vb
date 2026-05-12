Public Class Admin_ChangePwd

    ' Codes paramètres (Param_General)
    Private Const PARAM_MIN_MAJ As String = "PWD_MinMaj"
    Private Const PARAM_MIN_MIN As String = "PWD_MinMin"
    Private Const PARAM_MIN_SPECIAL As String = "PWD_MinSpecial"
    Private Const PARAM_MIN_CHIFFRES As String = "PWD_MinChiffres"
    Private Const PARAM_LONGUEUR As String = "PWD_Longueur"

    ' Valeurs par défaut
    Private Const DEFAULT_LONGUEUR As Integer = 6

    ' Seuil minimal de force accepté (en %). En dessous = mot de passe faible refusé
    Private Const FORCE_MINIMALE As Integer = 50

    Private Sub Log_In_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Enter Then Entrer()
    End Sub


    Private Sub Canceling()
        Me.Close()
    End Sub

    ''' <summary>
    ''' Récupère un paramètre entier depuis Param_General avec valeur par défaut si non numérique.
    ''' </summary>
    Private Function GetParamInt(ByVal codParam As String, ByVal defaut As Integer) As Integer
        Dim val As Object = FindParam(codParam)
        If Not IsNumeric(val) Then Return defaut
        Return CInt(val)
    End Function

    ''' <summary>
    ''' Compte les caractères de chaque catégorie présents dans le mot de passe.
    ''' </summary>
    Private Sub CompterCategories(ByVal pwd As String,
                                  ByRef nbMaj As Integer,
                                  ByRef nbMin As Integer,
                                  ByRef nbNum As Integer,
                                  ByRef nbSpec As Integer)
        nbMaj = 0 : nbMin = 0 : nbNum = 0 : nbSpec = 0
        For Each c As Char In pwd
            If Char.IsUpper(c) Then
                nbMaj += 1
            ElseIf Char.IsLower(c) Then
                nbMin += 1
            ElseIf Char.IsDigit(c) Then
                nbNum += 1
            ElseIf Not Char.IsWhiteSpace(c) Then
                nbSpec += 1
            End If
        Next
    End Sub

    ''' <summary>
    ''' Calcule un score de force du mot de passe entre 0 et 100.
    ''' </summary>
    Private Function CalculerForce(ByVal pwd As String) As Integer
        If String.IsNullOrEmpty(pwd) Then Return 0

        Dim score As Integer = 0
        Dim nbMaj As Integer, nbMin As Integer, nbNum As Integer, nbSpec As Integer
        CompterCategories(pwd, nbMaj, nbMin, nbNum, nbSpec)

        ' Longueur
        If pwd.Length >= 6 Then score += 10
        If pwd.Length >= 8 Then score += 15
        If pwd.Length >= 12 Then score += 15
        If pwd.Length >= 16 Then score += 10

        ' Présence de catégories
        If nbMaj > 0 Then score += 12
        If nbMin > 0 Then score += 12
        If nbNum > 0 Then score += 13
        If nbSpec > 0 Then score += 13

        ' Bonus diversité
        Dim categories As Integer = 0
        If nbMaj > 0 Then categories += 1
        If nbMin > 0 Then categories += 1
        If nbNum > 0 Then categories += 1
        If nbSpec > 0 Then categories += 1
        If categories >= 3 Then score += 5
        If categories = 4 Then score += 5

        If score > 100 Then score = 100
        If score < 0 Then score = 0
        Return score
    End Function

    ''' <summary>
    ''' Met à jour la barre de progression et le libellé de force.
    ''' </summary>
    Private Sub MajForce()
        Dim pwd As String = Pwd1_Text.Text
        Dim score As Integer = CalculerForce(pwd)
        Strength_Bar.Value = score

        Dim libelle As String
        Dim couleur As System.Drawing.Color
        Select Case score
            Case Is < 30
                libelle = "Très faible"
                couleur = System.Drawing.Color.Red
            Case Is < 50
                libelle = "Faible"
                couleur = System.Drawing.Color.OrangeRed
            Case Is < 70
                libelle = "Moyen"
                couleur = System.Drawing.Color.Orange
            Case Is < 90
                libelle = "Fort"
                couleur = System.Drawing.Color.YellowGreen
            Case Else
                libelle = "Très fort"
                couleur = System.Drawing.Color.Green
        End Select
        Strength_Label.Text = libelle & " (" & score & "%)"
        Strength_Label.ForeColor = couleur
    End Sub

    ''' <summary>
    ''' Construit et affiche dans Rules_Label les règles à respecter, en marquant celles
    ''' satisfaites par le mot de passe en cours de saisie.
    ''' </summary>
    Private Sub MajRegles()
        Dim minMaj As Integer = GetParamInt(PARAM_MIN_MAJ, 0)
        Dim minMin As Integer = GetParamInt(PARAM_MIN_MIN, 0)
        Dim minSpec As Integer = GetParamInt(PARAM_MIN_SPECIAL, 0)
        Dim minChiffres As Integer = GetParamInt(PARAM_MIN_CHIFFRES, 0)
        Dim longueur As Integer = GetParamInt(PARAM_LONGUEUR, DEFAULT_LONGUEUR)

        Dim pwd As String = Pwd1_Text.Text
        Dim nbMaj As Integer, nbMin As Integer, nbNum As Integer, nbSpec As Integer
        CompterCategories(pwd, nbMaj, nbMin, nbNum, nbSpec)

        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine(Marqueur(pwd.Length >= longueur) & " Longueur minimale : " & longueur & " caractères")
        If minMaj > 0 Then sb.AppendLine(Marqueur(nbMaj >= minMaj) & " Majuscules : au moins " & minMaj)
        If minMin > 0 Then sb.AppendLine(Marqueur(nbMin >= minMin) & " Minuscules : au moins " & minMin)
        If minChiffres > 0 Then sb.AppendLine(Marqueur(nbNum >= minChiffres) & " Chiffres : au moins " & minChiffres)
        If minSpec > 0 Then sb.AppendLine(Marqueur(nbSpec >= minSpec) & " Caractères spéciaux : au moins " & minSpec)
        Rules_Label.Text = sb.ToString()
    End Sub

    Private Function Marqueur(ByVal ok As Boolean) As String
        If ok Then Return "[OK]"
        Return "[--]"
    End Function

    ''' <summary>
    ''' Vérifie que le mot de passe n'a pas déjà été utilisé (Pwd_User1..Pwd_User7).
    ''' </summary>
    Private Function MotDePasseDejaUtilise(ByVal pwdClair As String) As Boolean
        Dim pwdEncrypte As String = Encrypt(pwdClair)
        Dim sql As String = "Select isnull(Pwd_User1,'') as P1, isnull(Pwd_User2,'') as P2, " &
                            "isnull(Pwd_User3,'') as P3, isnull(Pwd_User4,'') as P4, " &
                            "isnull(Pwd_User5,'') as P5, isnull(Pwd_User6,'') as P6, " &
                            "isnull(Pwd_User7,'') as P7 " &
                            "from Controle_Users where id_User='" & theUser.id_User & "'"
        Dim rs As ADODB.Recordset = CnExecuting(sql)
        If rs Is Nothing OrElse rs.EOF Then Return False
        For i As Integer = 0 To rs.Fields.Count - 1
            If CStr(IsNull(rs.Fields(i).Value, "")) = pwdEncrypte Then Return True
        Next
        Return False
    End Function

    Sub Entrer()
        Dim minMaj As Integer = GetParamInt(PARAM_MIN_MAJ, 0)
        Dim minMin As Integer = GetParamInt(PARAM_MIN_MIN, 0)
        Dim minSpec As Integer = GetParamInt(PARAM_MIN_SPECIAL, 0)
        Dim minChiffres As Integer = GetParamInt(PARAM_MIN_CHIFFRES, 0)
        Dim longueur As Integer = GetParamInt(PARAM_LONGUEUR, DEFAULT_LONGUEUR)

        ' --- Champs obligatoires
        If Old_Pwd_User_Text.Text = "" Then
            MessageBoxRHP(326)
            Old_Pwd_User_Text.Select()
            Old_Pwd_User_Text.SelectAll()
            Exit Sub
        ElseIf CnExecuting("Select Pwd_User from Controle_Users where id_User='" & theUser.id_User & "'").Fields(0).Value <> Encrypt(Old_Pwd_User_Text.Text) Then
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
        End If

        Dim nouveau As String = Pwd1_Text.Text

        ' --- A. Respect des contraintes paramétrées
        Dim nbMaj As Integer, nbMin As Integer, nbNum As Integer, nbSpec As Integer
        CompterCategories(nouveau, nbMaj, nbMin, nbNum, nbSpec)

        If nouveau.Length < longueur Then
            ShowMessageBox("Le mot de passe doit contenir au moins " & longueur & " caractères.")
            Pwd1_Text.Select() : Pwd1_Text.SelectAll()
            Exit Sub
        End If
        If nbMaj < minMaj Then
            ShowMessageBox("Le mot de passe doit contenir au moins " & minMaj & " majuscule(s).")
            Pwd1_Text.Select() : Pwd1_Text.SelectAll()
            Exit Sub
        End If
        If nbMin < minMin Then
            ShowMessageBox("Le mot de passe doit contenir au moins " & minMin & " minuscule(s).")
            Pwd1_Text.Select() : Pwd1_Text.SelectAll()
            Exit Sub
        End If
        If nbNum < minChiffres Then
            ShowMessageBox("Le mot de passe doit contenir au moins " & minChiffres & " chiffre(s).")
            Pwd1_Text.Select() : Pwd1_Text.SelectAll()
            Exit Sub
        End If
        If nbSpec < minSpec Then
            ShowMessageBox("Le mot de passe doit contenir au moins " & minSpec & " caractère(s) spécial(aux).")
            Pwd1_Text.Select() : Pwd1_Text.SelectAll()
            Exit Sub
        End If

        ' Compatibilité avec l'option existante PWD_AlphaNum (lettres + chiffres)
        Dim rgNum As New System.Text.RegularExpressions.Regex("[0-9]")
        Dim rgAlfa As New System.Text.RegularExpressions.Regex("[a-z]", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        If (Not rgNum.IsMatch(nouveau) Or Not rgAlfa.IsMatch(nouveau)) And FindParam("PWD_AlphaNum") = "O" Then
            ShowMessageBox("Le mot de passe doit contenir des lettres et des chiffres")
            Pwd1_Text.Select() : Pwd1_Text.SelectAll()
            Exit Sub
        End If

        If nouveau.Trim = Old_Pwd_User_Text.Text.Trim Then
            ShowMessageBox("Le nouveau mot de passe est identique à l'ancien.")
            Pwd1_Text.Select() : Pwd1_Text.SelectAll()
            Exit Sub
        End If

        ' --- C. Refus des mots de passe faibles
        Dim force As Integer = CalculerForce(nouveau)
        If force < FORCE_MINIMALE Then
            ShowMessageBox("Le mot de passe est trop faible (force : " & force & "%). Veuillez en choisir un plus robuste.",
                           "Mot de passe faible", MessageBoxButtons.OK, msgIcon.Stop)
            Pwd1_Text.Select() : Pwd1_Text.SelectAll()
            Exit Sub
        End If

        ' --- D. Vérification de l'historique (Pwd_User1..Pwd_User7)
        If MotDePasseDejaUtilise(nouveau) Then
            ShowMessageBox("Ce mot de passe a déjà été utilisé. Veuillez en choisir un autre.",
                           "Historique des mots de passe", MessageBoxButtons.OK, msgIcon.Stop)
            Pwd1_Text.Select() : Pwd1_Text.SelectAll()
            Exit Sub
        End If

        ' --- E. Mise à jour avec décalage de l'historique
        ' Décalage atomique :
        '   Pwd_User7 <- Pwd_User6
        '   Pwd_User6 <- Pwd_User5
        '   ...
        '   Pwd_User2 <- Pwd_User1
        '   Pwd_User1 <- Pwd_User (ancien actif)
        '   Pwd_User  <- nouveau
        Dim pwdNouveauCrypte As String = Encrypt(nouveau)
        Dim sqlUpdate As String =
            "Update Controle_Users set " &
            " Pwd_User7 = Pwd_User6," &
            " Pwd_User6 = Pwd_User5," &
            " Pwd_User5 = Pwd_User4," &
            " Pwd_User4 = Pwd_User3," &
            " Pwd_User3 = Pwd_User2," &
            " Pwd_User2 = Pwd_User1," &
            " Pwd_User1 = Pwd_User," &
            " Pwd_User  = '" & pwdNouveauCrypte & "'," &
            " Dat_Maj_Pwd = getdate()" &
            " where id_User='" & theUser.id_User & "'"

        CnExecuting(sqlUpdate)
        MessageBoxRHP(330)

        Me.Close()
    End Sub

    Private Sub Save_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_ud.Click
        Entrer()
    End Sub

    Private Sub Cancel_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler_ud.Click
        Canceling()
    End Sub

    Private Sub Pwd1_Text_TextChanged(sender As Object, e As EventArgs) Handles Pwd1_Text.TextChanged
        MajForce()
        MajRegles()
    End Sub

    Private Sub Admin_ChangePwd_Load(sender As Object, e As EventArgs) Handles Me.Load
        If theUser.is_AD Then
            ShowMessageBox("Ce compte est géré en Active Directory. Pour changer son mot de passe contactez votre Administrateur", "Active Directory", MessageBoxButtons.OK, msgIcon.Stop)
            Me.Close()
            Return
        End If
        Strength_Bar.Value = 0
        Strength_Label.Text = "Force du mot de passe :"
        MajRegles()
    End Sub
End Class
