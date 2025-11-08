Public Class Agent_Suppleant
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS166", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}) & " or isnull(Suppleant,'')='" & theUser.Matricule & "'", Societe.id_Societe)
            Else
                Appel_Zoom1("MS166", Matricule_txt, Me, "Matricule='" & theUser.Matricule & "' or isnull(Suppleant,'')='" & theUser.Matricule & "'", Societe.id_Societe)
            End If
        Else
            Appel_Zoom1("MS166", Matricule_txt, Me, "", Societe.id_Societe)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS166", Suppleant_txt, Me, "Matricule<>'" & Matricule_txt.Text & "'", Societe.id_Societe)
    End Sub

    Private Sub Agent_Suppleant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
        If Designated_By_txt.Text = "" And theUser.Typ_Role = "Agent" Then Designated_By_txt.Text = theUser.Matricule
    End Sub

    Private Sub Save_ud_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        Dim rsl As savingResult = Saving()
        If rsl.message <> "" Then
            ShowMessageBox(rsl.message, "Désignation de suppléant", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
        End If
        If rsl.result Then Me.Close()
    End Sub
    Function Saving() As savingResult
        Cursor = Cursors.WaitCursor
        If Matricule_txt.Text = "" Then
            Cursor = Cursors.Default
            Return New savingResult With {.result = False, .message = "Signataire non renseigné"}
        End If
        If Suppleant_txt.Text = Matricule_txt.Text Then
            Cursor = Cursors.Default
            Return New savingResult With {.result = False, .message = "Suppléant doit être différent du matricule de l'agent signataire"}
        End If
        If Suppleant_txt.Text = "" Then
            CnExecuting("update RH_Agent set Suppleant='',Suppleant_Du=null,Suppleant_Au=null,submitAcceptation='false'    where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            setSuppleant()
            Cursor = Cursors.Default
            Return New savingResult With {.result = True, .message = "Enregistré avec succès"}
        End If
        If Not EstDate(Suppleant_Du_txt.Text) Then
            Cursor = Cursors.Default
            Return New savingResult With {.result = False, .message = "Renseignez une date début"}
        End If
        If Not EstDate(Suppleant_Au_txt.Text) Then
            Cursor = Cursors.Default
            Return New savingResult With {.result = False, .message = "Renseignez une date fin"}
        End If
        If CDate(Suppleant_Du_txt.Text) >= CDate(Suppleant_Au_txt.Text) Then
            Cursor = Cursors.Default
            Return New savingResult With {.result = False, .message = "Date début de procuration de délégation de signature postérieure à la date fin"}
        End If
        Designated_By_txt.Text = If(theUser.Typ_Role = "Agent", theUser.Matricule, theUser.Login)
        Dim rs As New ADODB.Recordset
        rs.Open("select * from RH_Agent where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        Dim TypAgent = "Agent"
        If Not rs.EOF Then
            rs.Update()
            rs("Suppleant").Value = Suppleant_txt.Text
            rs("Designated_By").Value = Designated_By_txt.Text
            rs("Suppleant_Du").Value = Suppleant_Du_txt.Text
            rs("Suppleant_Au").Value = Suppleant_Au_txt.Text
            rs("submitAcceptation").Value = submitAcceptation_chk.Checked
            If Not submitAcceptation_chk.Checked Then rs("Accepted").Value = True
            rs.Update()
        Else
            TypAgent = "BO"
        End If
        rs.Close()
        If TypAgent = "BO" Then
            rs.Open("select * from Controle_Users where Login='" & Matricule_txt.Text & "'", cn, 2, 2)
            If Not rs.EOF Then
                rs.Update()
                rs("Suppleant").Value = Suppleant_txt.Text
                rs("Designated_By").Value = Designated_By_txt.Text
                rs("Suppleant_Du").Value = Suppleant_Du_txt.Text
                rs("Suppleant_Au").Value = Suppleant_Au_txt.Text
                rs("submitAcceptation").Value = submitAcceptation_chk.Checked
                If Not submitAcceptation_chk.Checked Then rs("Accepted").Value = True
                rs.Update()
            End If
            rs.Close()
        End If
        If Not submitAcceptation_chk.Checked Then
            setSuppleant()
        End If
        If Notify_chk.Checked Then
            Dim textToSuppelant As String = "Bonjour " & Nom_Suppleant_txt.Text & vbCrLf & "Vous avez été désigné par " & Nom_Designated_By_txt.Text & " en tant que " & IIf(Designated_By_txt.Text = Matricule_txt.Text, " son suppléant.", " suppléant de " & Nom_Agent_Text.Text) & vbCrLf &
               IIf(submitAcceptation_chk.Checked, "Merci de bien vouloir vous connecter à RHP pour acception cette désignation.", "") & vbCrLf & "Merci pour votre habituelle collaboration."
            Dim mailSuppleant As String = FindLibelle("Mail", "Matricule", Suppleant_txt.Text, "Rh_Agent")
            If estEmail(mailSuppleant) Then
                If EnvoiDeMail(mailSuppleant, "", "Procuration de signature", textToSuppelant, Nothing, mailSuppleant, "") Then
                    CnExecuting("update Rh_Agent set Notified='true', Dat_Notif=getdate() where Matricule='" & Matricule_txt.Text & "'")
                End If
            End If
            If Designated_By_txt.Text <> Matricule_txt.Text Then
                Dim textToAgent As String = "Bonjour " & Nom_Agent_Text.Text & vbCrLf & Nom_Suppleant_txt.Text & " a été désigné par " & Nom_Designated_By_txt.Text & " en tant que votre suppléant." & vbCrLf &
               "Merci pour votre habituelle collaboration."
                Dim mailAgent As String = FindLibelle("Mail", "Matricule", Matricule_txt.Text, "Rh_Agent")
                If estEmail(mailAgent) Then
                    EnvoiDeMail(mailAgent, "", "Procuration de signature", textToAgent, Nothing, mailAgent, "")
                End If
            End If
        End If
        Cursor = Cursors.Default
        Return New savingResult With {.result = True, .message = "Enregistré avec succès"}
    End Function
    Function setSuppleant() As Boolean
        '        Dim sqlStr As String = "update Signatures_Lig set Signataire= '" & Suppleant_txt.Text & "', Signataire_Org='" & Matricule_txt.Text & "'
        'where isnull(Decision,'')='' and Signataire='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe & If(EstDate(Suppleant_Du_txt.Text), " and getdate()>='" & CDate(Suppleant_Du_txt.Text) & "'", "") & If(EstDate(Suppleant_Au_txt.Text), " and getdate()<='" & CDate(Suppleant_Au_txt.Text) & "'", "")
        '        If Suppleant_txt.Text = "" Then
        '            'Annulation de la procuration de signature
        '            sqlStr = "
        'update Rh_Agent set Designated_By='', Accepted='false', Notified='false' where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe & "
        'update Signatures_Lig set Signataire= '" & Matricule_txt.Text & "'
        ' where  isnull(Signataire,'')!=''  and isnull(Decision,'')='' and isnull(Signataire_Org,'')='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe
        '        End If

        Try
            CnExecuting("exec Sys_Workflow_Suppleant")
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Function Request() As Boolean
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        If Nom_Agent_Text.Text = "" Then
            Nom_Agent_Text.Text = FindLibelle("Nom_user + ' ' +Prenom_User", "Login_User", Matricule_txt.Text, "Controle_Users")
            Suppleant_txt.Text = FindLibelle("Suppleant", "Login_User", Matricule_txt.Text, "Controle_Users")
            Suppleant_Du_txt.Text = FindLibelle("Suppleant_Du", "Login_User", Matricule_txt.Text, "Controle_Users")
            Suppleant_Au_txt.Text = FindLibelle("Suppleant_Au", "Login_User", Matricule_txt.Text, "Controle_Users")
            Designated_By_txt.Text = IsNull(FindLibelle("Designated_By", "Login_User", Matricule_txt.Text, "Controle_Users"), theUser.Matricule)
            submitAcceptation_chk.Checked = FindLibelle("submitAcceptation", "Login_User", Matricule_txt.Text, "Controle_Users")
            Notified_chk.Checked = FindLibelle("Notified", "Login_User", Matricule_txt.Text, "Controle_Users")
            Accepted_chk.Checked = FindLibelle("Accepted", "Login_User", Matricule_txt.Text, "Controle_Users")
        Else
            Suppleant_txt.Text = FindLibelle("Suppleant", "Matricule", Matricule_txt.Text, "RH_Agent")
            Suppleant_Du_txt.Text = FindLibelle("Suppleant_Du", "Matricule", Matricule_txt.Text, "RH_Agent")
            Suppleant_Au_txt.Text = FindLibelle("Suppleant_Au", "Matricule", Matricule_txt.Text, "RH_Agent")
            Designated_By_txt.Text = IsNull(FindLibelle("Designated_By", "Matricule", Matricule_txt.Text, "RH_Agent"), theUser.Matricule)
            submitAcceptation_chk.Checked = FindLibelle("submitAcceptation", "Matricule", Matricule_txt.Text, "RH_Agent")
            Notified_chk.Checked = FindLibelle("Notified", "Matricule", Matricule_txt.Text, "RH_Agent")
            Accepted_chk.Checked = FindLibelle("Accepted", "Matricule", Matricule_txt.Text, "RH_Agent")

        End If

        Save_ud.Enabled = (Matricule_txt.Text <> "" And (Matricule_txt.Text = theUser.Matricule Or theUser.Typ_Role <> "Agent" Or Designated_By_txt.Text = theUser.Matricule))
        Accept_ud.Enabled = ((theUser.Matricule = Suppleant_txt.Text) And Matricule_txt.Text <> "" And Suppleant_txt.Text <> "" And Not Accepted_chk.Checked)
        Return True
    End Function
    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Request()
    End Sub

    Private Sub Suppleant_txt_TextChanged(sender As Object, e As EventArgs) Handles Suppleant_txt.TextChanged
        Nom_Suppleant_txt.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Suppleant_txt.Text, "RH_Agent")
        If Nom_Suppleant_txt.Text = "" Then
            FindLibelle("Nom_User + ' ' +Prenom_User", "Login_User", Suppleant_txt.Text, "Controle_Users")
            submitAcceptation_chk.Checked = False
            submitAcceptation_chk.Enabled = False
            Notify_chk.Checked = False
            Notify_chk.Enabled = False

        Else
            submitAcceptation_chk.Checked = True
            submitAcceptation_chk.Enabled = True
            Notify_chk.Checked = True
            Notify_chk.Enabled = True
        End If
        If Nom_Suppleant_txt.Text = "" Then
            Suppleant_Du_txt.ResetText()
            Suppleant_Au_txt.ResetText()
        End If
    End Sub
    Private Sub Designated_By_txt_TextChanged(sender As Object, e As EventArgs) Handles Designated_By_txt.TextChanged
        Nom_Designated_By_txt.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Designated_By_txt.Text, "RH_Agent")
        If Nom_Designated_By_txt.Text = "" Then
            Nom_Designated_By_txt.Text = FindLibelle("Nom_user + ' ' +Prenom_User", "Login_User", Designated_By_txt.Text, "Controle_Users")
        End If
    End Sub

    Private Sub Accept_D_Click(sender As Object, e As EventArgs) Handles Accept_ud.Click
        If ShowMessageBox("Etes-vous sûr de vouloir accepter?", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
        CnExecuting("update RH_Agent set Accepted='true' where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        setSuppleant()
        If Notify_chk.Checked Then
            Dim textToAgent As String = "Bonjour " & Nom_Agent_Text.Text & vbCrLf & Nom_Suppleant_txt.Text & " désigné(e) en tant que votre suppléant a accepté cette désignation."
            Dim mailAgent As String = FindLibelle("Mail", "Matricule", Matricule_txt.Text, "Rh_Agent")
            If estEmail(mailAgent) Then
                If EnvoiDeMail(mailAgent, "", "Procuration de signature", textToAgent, Nothing, mailAgent, "") Then
                    CnExecuting("update Rh_Agent set Notified='true', Dat_Notif=getdate() where Matricule='" & Matricule_txt.Text & "'")
                End If
            End If
            If Designated_By_txt.Text <> Matricule_txt.Text Then
                Dim textToDesignator As String = "Bonjour " & Nom_Designated_By_txt.Text & vbCrLf & Nom_Suppleant_txt.Text & " désigné(e) en tant que suppléant de " & Nom_Agent_Text.Text & " a accepté cette désignation."
                Dim mailDes As String = FindLibelle("Mail", "Matricule", Matricule_txt.Text, "Rh_Agent")
                If estEmail(mailDes) Then
                    EnvoiDeMail(mailDes, "", "Procuration de signature", textToDesignator, Nothing, mailDes, "")
                End If
            End If
        End If
        Request()
    End Sub

    Private Sub Annuler_ud_Load(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Suppleant_Du_txt, Me)
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Appel_Calender(Suppleant_Au_txt, Me)
    End Sub

    Private Sub Accept_ud_Load(sender As Object, e As EventArgs) Handles Accept_ud.Load

    End Sub
End Class