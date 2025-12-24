Imports System.ComponentModel

Public Class RH_Dossier_Maladie
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Remboursement_D As ud_btn
    Dim Valide_D As ud_btn
    Sub Chargement()
        If Not dictButtons.ContainsKey("New_D") Then Me.setButtons()
        If Lien_cbo.Items.Count = 0 Then Lien_cbo.fromRubrique("Lien_Parente")
        If Typ_Maladie_cbo.Items.Count = 0 Then Typ_Maladie_cbo.fromRubrique("Typ_Maladie")
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Valide_D = dictButtons("Valide_D")
            Remboursement_D = dictButtons("Remboursement_D")
        End If
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS022", Num_Dossier_txt, Me, " Matricule = '" & Matricule_txt.Text & "'")
            End If
        Else
            Appel_Zoom1("MS022", Num_Dossier_txt, Me)
        End If
    End Sub
    Private Sub RH_Demande_Conge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Dossier_txt.Text) Then Dat_Dossier_txt.Text = Now.ToShortDateString
    End Sub
    Private Sub Rd_1_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_1.CheckedChanged
        If Rd_1.Checked Then Lien_cbo.SelectedIndex = -1
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Appel_Zoom("Medecin", "Spécialité", "(select id_Societe,Medecin, dbo.findRubrique('Typ_Maladie',Typ_Maladie ) as 'Spécialité'
from RH_Dossier_Maladie
where isnull(Medecin,'')!='' and Typ_Maladie like '" & IsNull(Typ_Maladie_cbo.SelectedValue, "") & "%'
group by Medecin, Typ_Maladie,id_Societe) RH_Dossier_Maladie", "1=1", Medecin_txt, Me)
    End Sub
    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        remboursement_Grp.Enabled = False
        Dim SqlStr As String = "SELECT   *
                            FROM RH_Dossier_Maladie where  Num_Dossier='" & Num_Dossier_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        Dim canModify As Boolean = (Num_Dossier_txt.Text = "")
        With Tbl
            If .Rows.Count > 0 Then
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                Dat_Dossier_txt.Text = IsNull(.Rows(0)("Dat_Dossier"), "")
                Nom_Malade_txt.Text = IsNull(.Rows(0)("Nom_Malade"), "")
                Lien_cbo.SelectedValue = IsNull(.Rows(0)("Lien"), "")
                Typ_Maladie_cbo.SelectedValue = IsNull(.Rows(0)("Typ_Maladie"), "")
                Medecin_txt.Text = IsNull(.Rows(0)("Medecin"), "")
                Rd_2.Checked = IsNull(Lien_cbo.SelectedValue, "") <> ""
                Rd_1.Checked = Not Rd_2.Checked
                Mnt_Engage_txt.Text = IsNull(.Rows(0)("Mnt_Engage"), "0,00")
                Envoye_Le_txt.Text = IsNull(.Rows(0)("Envoye_Le"), "")
                Rembourse_Le_txt.Text = IsNull(.Rows(0)("Rembourse_Le"), "")
                Mnt_Remboursement_txt.Text = IsNull(.Rows(0)("Mnt_Remboursement"), "0,00")
                Commentaire_txt.Text = IsNull(.Rows(0)("Commentaire"), "")
                With pb_Valide
                    .Tag = ""
                    Select Case IsNull(Tbl.Rows(0)("Statut"), "")
                        Case "SG"
                            .Image = My.Resources.valide01
                            .Tag = "SG"
                        Case "RJ"
                            .Image = My.Resources.refuse
                            .Tag = "RJ"
                    End Select
                    .Visible = ("VA;SG;RJ".Split(";").Contains(IsNull(Tbl.Rows(0)("Statut"), "")))
                    canModify = (IsNull(Tbl.Rows(0)("Statut"), "") = "")
                    If IsNull(Tbl.Rows(0)("Statut"), "") <> "" Then
                        Save_D.Enabled = False
                        Del_D.Enabled = False
                        Valide_D.Enabled = False
                    End If
                End With
                Remboursement_D.Visible = "VA;SS;SP".Split(";").Contains(IsNull(Tbl.Rows(0)("Statut"), "")) And theUser.Typ_Role <> "Agent"
                With remboursement_Grp
                    .Enabled = "VA;SS;SP".Split(";").Contains(IsNull(Tbl.Rows(0)("Statut"), "")) And theUser.Typ_Role <> "Agent"
                End With
            Else
                Matricule_txt.Text = ""
                Dat_Dossier_txt.Text = ""
                Nom_Malade_txt.Text = ""
                Lien_cbo.SelectedIndex = -1
                Typ_Maladie_cbo.SelectedIndex = -1
                Medecin_txt.Text = ""
                Mnt_Engage_txt.Text = "0,00"
                Envoye_Le_txt.Text = ""
                Rembourse_Le_txt.Text = ""
                Mnt_Remboursement_txt.Text = "0,00"
                Commentaire_txt.Text = ""
                Rd_1.Checked = True
                Lien_cbo.SelectedIndex = -1
                Remboursement_D.Visible = False
                With remboursement_Grp
                    .Enabled = False
                End With
            End If

        End With
        If canModify Then canModify = ((Matricule_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
        Save_D.Enabled = canModify
        Del_D.Enabled = canModify
        Valide_D.Enabled = canModify
        If CDbl(Mnt_Engage_txt.Text) > 0 Then
            Pourcentage_txt.Text = Math.Round((CDbl(Mnt_Remboursement_txt.Text) / CDbl(Mnt_Engage_txt.Text)) * 100, 2)
        Else
            Pourcentage_txt.Text = 0
        End If
    End Sub
    Function Valider()
        If ShowMessageBox("Etes-vous sûr de vouloir valider cette demande?", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving("VA")
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_Dossier_txt.Text <> "" Then Return
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Matricule_txt, Me)
        End If
    End Sub
    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent+' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        Nom_Malade_txt.Text = ""
        Lien_cbo.SelectedIndex = -1
        Typ_Maladie_cbo.SelectedIndex = -1
    End Sub

    Private Sub Num_Dossier_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Dossier_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_Dossier_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_Dossier_txt.Text)
            Code = Num_Dossier_txt.Text
        End If
    End Sub
    Sub Enregistrer()
        Dim rsl As savingResult = Saving("")
        If IsNull(rsl.message, "") <> "" Then ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub
    Function Saving(statut As String) As savingResult
        Try
            If Matricule_txt.Text = "" Then
                Return New savingResult With {.result = False, .message = "Matricule non renseigné"}
            End If
            If Rd_2.Checked And Nom_Malade_txt.Text = "" Then
                Return New savingResult With {.result = False, .message = "Merci de renseigner le nom du malade"}
            End If
            If Not IsNumeric(Mnt_Engage_txt.Text) Then Mnt_Engage_txt.Text = "0,00"
            If Not IsNumeric(Mnt_Remboursement_txt.Text) Then Mnt_Remboursement_txt.Text = "0,00"
            If ConvertNombre(Mnt_Engage_txt.Text) = 0 Then
                ShowMessageBox("Aucun montant engagé n'est renseigné", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                Return New savingResult With {.result = False, .message = "Aucun montant engagé n'est renseigné"}
            End If

            Dim oDat As Date = Now
            If Not EstDate(Dat_Dossier_txt.Text) Then Dat_Dossier_txt.Text = oDat.ToShortDateString
            Dim NumDossier As String = Num_Dossier_txt.Text
            If NumDossier = "" Then
                Dim Cp As New ADODB.Recordset
                Cp = CnExecuting("select isnull(max(convert(int,right(Num_Dossier,6))),0) from RH_Dossier_Maladie where id_Societe=" & Societe.id_Societe & " and year(Dat_Dossier)=" & CDate(Dat_Dossier_txt.Text).Year)
                If Not Cp.EOF Then
                    NumDossier = "DM" & Societe.id_Societe & "-" & CDate(Dat_Dossier_txt.Text).Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
                Else
                    NumDossier = "DM" & Societe.id_Societe & "-" & CDate(Dat_Dossier_txt.Text).Year & "000001"
                End If
            End If
            Dim rs As New ADODB.Recordset
            rs.Open("select * from RH_Dossier_Maladie where Num_Dossier='" & NumDossier & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Num_Dossier").Value = NumDossier
                rs("id_Societe").Value = Societe.id_Societe
                rs("Matricule").Value = Matricule_txt.Text
                rs("Dat_Crea").Value = oDat
                rs("Created_By").Value = theUser.Login
            Else
                rs.Update()
            End If
            rs("Dat_Dossier").Value = Dat_Dossier_txt.Text
            rs("Nom_Malade").Value = IIf(Rd_1.Checked, "", Nom_Malade_txt.Text)
            rs("Lien").Value = IIf(Rd_1.Checked, "", Lien_cbo.SelectedValue)
            rs("Typ_Maladie").Value = Typ_Maladie_cbo.SelectedValue
            rs("Medecin").Value = Medecin_txt.Text
            rs("Mnt_Engage").Value = Mnt_Engage_txt.Text
            If EstDate(Envoye_Le_txt.Text) Then
                rs("Envoye_Le").Value = Envoye_Le_txt.Text
            Else
                rs("Envoye_Le").Value = Nothing
            End If
            If EstDate(Rembourse_Le_txt.Text) Then
                rs("Rembourse_Le").Value = Rembourse_Le_txt.Text
            Else
                rs("Rembourse_Le").Value = Nothing
            End If
            rs("Mnt_Remboursement").Value = Mnt_Remboursement_txt.Text
            rs("Commentaire").Value = Commentaire_txt.Text
            rs("Statut").Value = IIf(EstDate(Envoye_Le_txt.Text) And Not EstDate(Rembourse_Le_txt.Text) And statut = "A", "E", statut)
            rs("Dat_Modif").Value = oDat
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            If Num_Dossier_txt.Text <> "" Then
                Request()
            Else
                Num_Dossier_txt.Text = NumDossier
            End If
            Return New savingResult With {.result = True, .message = "Enregistré avec succès"}

        Catch ex As Exception
            Return New savingResult With {.result = False, .message = ex.Message}
        End Try
    End Function
    Sub DeclarerRemboursement()
        Dim rsl As savingResult = Remboursement()
        If rsl.message <> "" Then ShowMessageBox(rsl.message, "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
    End Sub
    Function Remboursement() As savingResult
        Try
            If Not EstDate(Envoye_Le_txt.Text) Then
                Return New savingResult With {.result = False, .message = "Date d'envoi non renseignée"}
            End If
            If CDate(Envoye_Le_txt.Text) > Now.Date Then
                Return New savingResult With {.result = False, .message = "Date d'envoi incohérente."}
            End If
            If ConvertNombre(Mnt_Remboursement_txt.Text) > 0 And Not EstDate(Rembourse_Le_txt.Text) Then
                Return New savingResult With {.result = False, .message = "Date de remboursement non renseignée"}
            End If
            If EstDate(Rembourse_Le_txt.Text) And ConvertNombre(Mnt_Remboursement_txt.Text) = 0 Then
                Return New savingResult With {.result = False, .message = "Montant de remboursement non renseigné"}
            End If
            If CDbl(Mnt_Engage_txt.Text) < CDbl(Mnt_Remboursement_txt.Text) Then
                Return New savingResult With {.result = False, .message = "Montant de remboursement incohérent avec le montant engagé."}
            End If
            If EstDate(Rembourse_Le_txt.Text) Then
                If CDate(Rembourse_Le_txt.Text) > Now.Date Then
                    Return New savingResult With {.result = False, .message = "Date remboursement incohérente : postérieure à la date en cours."}
                End If
                If CDate(Rembourse_Le_txt.Text) < CDate(Envoye_Le_txt.Text) Then
                    Return New savingResult With {.result = False, .message = "Date remboursement incohérente avec la date d'envoi."}
                End If
            End If
            Dim rs As New ADODB.Recordset
            rs.Open("select * from RH_Dossier_Maladie where Num_Dossier='" & Num_Dossier_txt.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                Return New savingResult With {.result = False, .message = ""}
            Else
                rs.Update()
            End If
            If EstDate(Envoye_Le_txt.Text) Then
                rs("Envoye_Le").Value = Envoye_Le_txt.Text
            Else
                rs("Envoye_Le").Value = Nothing
            End If
            If EstDate(Rembourse_Le_txt.Text) Then
                rs("Rembourse_Le").Value = Rembourse_Le_txt.Text
            Else
                rs("Rembourse_Le").Value = Nothing
            End If
            rs("Mnt_Remboursement").Value = Mnt_Remboursement_txt.Text
            rs("Commentaire").Value = Commentaire_txt.Text
            rs("Dat_Modif").Value = Now
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            Request()
            Return New savingResult With {.result = True, .message = ""}
        Catch ex As Exception
            Return New savingResult With {.result = False, .message = ex.Message}
        End Try
    End Function
    Sub Deleting()
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer ce dossier?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Dossier_Maladie where Num_Dossier='" & Num_Dossier_txt.Text & "' and id_Societe=" & Societe.id_Societe _
      &
    " insert into  Mouchard_Suppression ( Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
values ('RH_Dossier_Maladie','Num_Dossier','" & Num_Dossier_txt.Text & "','" & theUser.id_User & "', getdate())")
        Reset_Form(Me)
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
    End Sub
    Private Sub RH_Demande_Conge_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Dat_Dossier_txt.Text = Now.ToShortDateString
        Rd_1.Checked = True
        Lien_cbo.SelectedIndex = -1
        remboursement_Grp.Enabled = False
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
    End Sub

    Private Sub Mnt_Engage_txt_Validating(sender As Object, e As CancelEventArgs) Handles Mnt_Engage_txt.Validating, Mnt_Remboursement_txt.Validating
        If Not IsNumeric(sender.Text) Then
            e.Cancel = True
        End If
    End Sub
    Private Sub Mnt_Engage_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Mnt_Engage_txt.KeyPress, Mnt_Remboursement_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub

    Private Sub Mnt_Engage_txt_Leave(sender As Object, e As EventArgs) Handles Mnt_Engage_txt.Leave, Mnt_Remboursement_txt.Leave
        If Not IsNumeric(sender.Text) Then
            sender.Text = "0,00"
        End If
        sender.Text = FormatDeNombre(sender.Text, 2)
        If Not IsNumeric(Mnt_Engage_txt.Text) Then Mnt_Engage_txt.Text = "0,00"
        If Not IsNumeric(Mnt_Remboursement_txt.Text) Then Mnt_Remboursement_txt.Text = "0,00"
        If CDbl(Mnt_Engage_txt.Text) > 0 Then
            Pourcentage_txt.Text = Math.Round((CDbl(Mnt_Remboursement_txt.Text) / CDbl(Mnt_Engage_txt.Text)) * 100, 2)
        Else
            Pourcentage_txt.Text = 0
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_Dossier_txt, Me)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS023", Nom_Malade_txt, Me, "Matricule='" & Matricule_txt.Text & "'")
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Appel_Calender(Rembourse_Le_txt, Me)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Calender(Envoye_Le_txt, Me)
    End Sub
    Private Sub Nom_Malade_txt_TextChanged(sender As Object, e As EventArgs) Handles Nom_Malade_txt.TextChanged
        Lien_cbo.SelectedValue = FindLibelle("Lien_Parente", "Matricule='" & Matricule_txt.Text & "' and Nom_Prenom", Nom_Malade_txt.Text, "RH_Agent_Famille")
    End Sub
#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        Return Saving("SS")
    End Function
    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function
#End Region
End Class