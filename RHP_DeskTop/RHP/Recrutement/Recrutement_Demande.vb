Imports System.ComponentModel
Public Class Recrutement_Demande
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Valide_D As ud_btn
    Sub Chargement()
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Valide_D = dictButtons("Valide_D")
        End If
        If Niveau.Items.Count = 0 Then Niveau.fromRubrique()
        If Motif_DR.Items.Count = 0 Then Motif_DR.fromRubrique()
    End Sub
    Private Sub RH_Demande_Conge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_DR_txt.Text) Then Dat_DR_txt.Text = Now.ToShortDateString
    End Sub
    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        Dim canModify As Boolean = (Num_DR_txt.Text = "")
        Dim SqlStr As String = "SELECT   *
                            FROM Recrutement_Demande where  Num_DR='" & Num_DR_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        With Tbl
            If .Rows.Count > 0 Then
                Lib_DR_txt.Text = IsNull(.Rows(0)("Lib_DR"), "")
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                Titre_txt.Text = IsNull(.Rows(0)("Titre"), "")
                Cod_Poste_txt.text = IsNull(.Rows(0)("Cod_Poste"), "")
                Cod_Grade_txt.text = IsNull(.Rows(0)("Cod_Grade"), "")
                Cod_Entite_txt.Text = IsNull(.Rows(0)("Cod_Entite"), "")
                Titre_DR_txt.Text = IsNull(.Rows(0)("Titre_DR"), "")
                Cod_Poste_DR_txt.Text = IsNull(.Rows(0)("Cod_Poste_DR"), "")
                Cod_Grade_DR_txt.Text = IsNull(.Rows(0)("Cod_Grade_DR"), "")
                Cod_Entite_DR_txt.Text = IsNull(.Rows(0)("Cod_Entite_DR"), "")
                Dat_DR_txt.Text = IsNull(.Rows(0)("Dat_DR"), "")
                Rd_Duree_0.Checked = IsNull(.Rows(0)("Duree_Indeterminee"), False)
                Rd_Duree_1.Checked = Not Rd_Duree_0.Checked
                Duree_Du.Text = IsNull(.Rows(0)("Duree_Du"), "")
                Duree_Au.Text = IsNull(.Rows(0)("Duree_Au"), "")
                Nb_Personne.Value = IsNull(.Rows(0)("Nb_Personne"), "1")
                Buget_Salaire_txt.Text = IsNull(.Rows(0)("Buget_Salaire"), "0")
                Dim _sex = IsNull(.Rows(0)("Sexe"), "")
                Sexe_Homme_rd.Checked = (_sex = "H")
                Sexe_Femme_rd.Checked = (_sex = "F")
                Sexe_Indifferent_rd.Checked = (Not Sexe_Homme_rd.Checked And Not Sexe_Femme_rd.Checked)
                Rd_Age_1.Checked = IsNull(.Rows(0)("Age_Determine"), False)
                Rd_Age_0.Checked = Not Rd_Age_1.Checked
                Age_Du.Text = IsNull(.Rows(0)("Age_Du"), "18")
                Age_Au.Text = IsNull(.Rows(0)("Age_Au"), "59")
                Niveau.SelectedValue = IsNull(.Rows(0)("Niveau"), "B0")
                Etablissement_txt.text = IsNull(.Rows(0)("Etablissement"), "")
                Experience.Value = IsNull(.Rows(0)("Experience"), "0")
                Parcours_txt.Text = IsNull(.Rows(0)("Parcours"), "")
                Domaines_Competence_Pnl.Text = IsNull(.Rows(0)("Domaines_Competence"), "")
                Narratif_rtb.rtb.Rtf = IsNull(.Rows(0)("Narratif"), "")
                Motif_DR.SelectedValue = IsNull(.Rows(0)("Motif_DR"), "N")
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
                Dim laListe = IsNull(Domaines_Competence_Pnl.Text, "").Split(";").ToList()
                Domaines_Competence_Pnl.Controls.Clear()
                If laListe.Count > 0 Then
                    For Each c In laListe
                        If Not String.IsNullOrWhiteSpace(c) Then
                            If Domaines_Competence_Pnl.Controls.Find(c, True).Length = 0 Then
                                AddCompetence(c)
                            End If
                        End If
                    Next
                    RearrangeControls()
                End If
            Else
                Lib_DR_txt.Text = ""
                Matricule_txt.Text = theUser.Matricule
                Titre_DR_txt.Text = ""
                Cod_Poste_DR_txt.Text = ""
                Cod_Grade_DR_txt.Text = ""
                Dat_DR_txt.Text = Now.ToShortDateString
                Rd_Duree_0.Checked = True
                Rd_Duree_1.Checked = False
                Duree_Du.Text = ""
                Duree_Au.Text = ""
                Nb_Personne.Value = 1
                Buget_Salaire_txt.Text = 0
                Sexe_Homme_rd.Checked = False
                Sexe_Femme_rd.Checked = False
                Sexe_Indifferent_rd.Checked = True
                Rd_Age_0.Checked = True
                Rd_Age_1.Checked = False
                Age_Du.Text = 18
                Age_Au.Text = 59
                Niveau.SelectedValue = "B0"
                Etablissement_txt.Text = ""
                Experience.Value = 0
                Parcours_txt.Text = ""
                Domaines_Competence_Pnl.Text = ""
                Domaines_Competence_Pnl.Controls.Clear()
                Narratif_rtb.rtb.Text = ""
                Motif_DR.SelectedIndex = -1
            End If
            If canModify Then canModify = ((Matricule_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
            Save_D.Enabled = canModify
            Del_D.Enabled = canModify
            Valide_D.Enabled = canModify
        End With
        Buget_Salaire_txt.Enabled = Not pb_Valide.Visible
        TabControl1.SelectedIndex = 0
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_DR_txt.Text <> "" Then
            If Not ShowMessageBox("Vous ne pouvez pas modifier le matricule d'une demande créée." & vbCrLf & "Voulez-vous créer une nouvelle demande?", "Demande", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Return
            Else
                Nouveau()
                Return
            End If
        End If
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Matricule_txt, Me)
        End If
    End Sub
    Sub requestMatricule()
        Dim SqlStr As String = "Select * from RH_Agent a
outer apply(select top 1 * from RH_Conge where Matricule=a.Matricule and id_Societe=a.id_Societe order by Annee desc)c
where a.Matricule='" & Matricule_txt.Text & "' and a.id_Societe=" & Societe.id_Societe
        Dim CltTbl As DataTable = DATA_READER_GRD(SqlStr)
        If CltTbl.Rows.Count > 0 Then
            Nom_Agent_Text.Text = IsNull(CltTbl.Rows(0)("Nom_Agent"), "") & " " & IsNull(CltTbl.Rows(0)("Prenom_Agent"), "")
            Titre_txt.Text = IsNull(CltTbl.Rows(0)("Titre"), "")
            Cod_Poste_txt.Text = IsNull(CltTbl.Rows(0)("Cod_Poste"), "")
            Cod_Grade_txt.Text = IsNull(CltTbl.Rows(0)("Cod_Grade"), "")
            Cod_Entite_txt.Text = IsNull(CltTbl.Rows(0)("Cod_Entite"), "")
            Cod_Entite_DR_txt.Text = Cod_Entite_txt.Text
        ElseIf Matricule_txt.Text.Trim = "" Then
            Nom_Agent_Text.Text = ""
            Titre_txt.Text = ""
            Cod_Poste_txt.Text = ""
            Cod_Grade_txt.Text = ""
            Cod_Entite_txt.Text = ""
            Cod_Entite_DR_txt.Text = ""
        End If
    End Sub
    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        requestMatricule()
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS162", Num_DR_txt, Me, " Matricule = '" & theUser.Matricule & "'")
            End If
        Else
            Appel_Zoom1("MS162", Num_DR_txt, Me)
        End If
    End Sub
    Private Sub Num_DR_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_DR_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_DR_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_DR_txt.Text)
            Code = Num_DR_txt.Text
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
    Sub Saving()
        Dim rsl As savingResult = Saving("")
        If IsNull(rsl.message, "") <> "" Then ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub
    Function Saving(statut As String) As savingResult
        If Matricule_txt.Text = "" Then
            TabControl1.SelectedIndex = 0
            Return New savingResult With {.result = False, .message = "Matricule non renseigné"}
        End If
        If Cod_Entite_DR_txt.Text = "" Then
            TabControl1.SelectedIndex = 1
            Return New savingResult With {.result = False, .message = "Entité demandeuse non renseignée"}
        End If
        If Cod_Grade_DR_txt.Text = "" Then
            TabControl1.SelectedIndex = 1
            Return New savingResult With {.result = False, .message = "Grade demandé non renseigné"}
        End If
        If Rd_Duree_1.Checked Then
            If Not EstDate(Duree_Du.Text) Or Not EstDate(Duree_Au.Text) Then
                TabControl1.SelectedIndex = 1
                Return New savingResult With {.result = False, .message = "Durée du contrat de travail non renseignée."}
            Else
                If CDate(Duree_Au.Text) < CDate(Duree_Du.Text) Then
                    Return New savingResult With {.result = False, .message = "incohérence entre la date début et fin de la durée du contrat de travail."}
                End If
            End If
        End If
        Sexe_Indifferent_rd.Checked = Not Sexe_Femme_rd.Checked And Not Sexe_Homme_rd.Checked
        If Not IsNumeric(Age_Du.Text) Then Age_Du.Text = 18
        If Not IsNumeric(Age_Au.Text) Then Age_Du.Text = 59
        If Rd_Age_1.Checked Then
            If CDbl(Age_Du.Text) < 18 Or CDbl(Age_Au.Text) > 60 Then
                TabControl1.SelectedIndex = 1
                Return New savingResult With {.result = False, .message = "Age doit être compris entre 18 et 60 ans."}
            Else
                If CDbl(Age_Au.Text) < CDbl(Age_Du.Text) Then
                    Return New savingResult With {.result = False, .message = "incohérence de la fourchette d'âge."}
                End If
            End If
        End If
        Dim NumDR As String = Num_DR_txt.Text
        If NumDR = "" Then
            Dim Cp As New ADODB.Recordset
            Dim SqlStr As String = "select isnull(max(racine),0) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from Recrutement_Demande 
outer apply(select charindex('_',Num_DR,1)-1 aa)a
outer apply(select case when aa<0 then RIGHT(Num_DR,6) else RIGHT(left(Num_DR,aa),6) end as racine)n
where id_Societe=" & Societe.id_Societe & " and year(Dat_DR)=" & Now.Year & ")f"
            Cp = CnExecuting(SqlStr)
            NumDR = "DR" & Societe.id_Societe & "-" & Now.Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
        End If
        Dim oDat As Date = Now
        If Not EstDate(Dat_DR_txt.Text) Then Dat_DR_txt.Text = oDat.ToShortDateString
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Recrutement_Demande where Num_DR='" & NumDR & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Num_DR").Value = NumDR
            rs("id_Societe").Value = Societe.id_Societe
            rs("Matricule").Value = Matricule_txt.Text
            rs("Dat_Crea").Value = oDat
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()
        End If
        rs("Lib_DR").Value = Lib_DR_txt.Text
        rs("Matricule").Value = Matricule_txt.Text
        rs("Titre").Value = Titre_txt.Text
        rs("Cod_Poste").Value = Cod_Poste_txt.Text
        rs("Cod_Grade").Value = Cod_Grade_txt.Text
        rs("Cod_Entite").Value = Cod_Entite_txt.Text
        rs("Titre_DR").Value = Titre_DR_txt.Text
        rs("Cod_Poste_DR").Value = Cod_Poste_DR_txt.Text
        rs("Cod_Grade_DR").Value = Cod_Grade_DR_txt.Text
        rs("Cod_Entite_DR").Value = Cod_Entite_DR_txt.Text
        rs("Dat_DR").Value = Dat_DR_txt.Text
        rs("Duree_Indeterminee").Value = Rd_Duree_0.Checked
        If Rd_Duree_1.Checked Then
            rs("Duree_Du").Value = Duree_Du.Text
            rs("Duree_Au").Value = Duree_Au.Text
        Else
            rs("Duree_Du").Value = DBNull.Value
            rs("Duree_Au").Value = DBNull.Value
        End If
        rs("Nb_Personne").Value = Nb_Personne.Value
        rs("Buget_Salaire").Value = If(IsNumeric(Buget_Salaire_txt.Text), CDbl(Buget_Salaire_txt.Text), 0)
        rs("Sexe").Value = IIf(Sexe_Femme_rd.Checked, "F", IIf(Sexe_Homme_rd.Checked, "H", ""))
        rs("Age_Determine").Value = Rd_Age_1.Checked
        If Rd_Age_1.Checked Then
            rs("Age_Du").Value = Age_Du.Text
            rs("Age_Au").Value = Age_Au.Text
        Else
            rs("Age_Du").Value = 18
            rs("Age_Au").Value = 59
        End If
        rs("Motif_DR").Value = If(Motif_DR.SelectedIndex = -1, "N", Motif_DR.SelectedValue)
        rs("Niveau").Value = Niveau.SelectedValue
        rs("Etablissement").Value = Etablissement_txt.Text
        rs("Experience").Value = Experience.Value
        rs("Parcours").Value = Parcours_txt.Text
        rs("Domaines_Competence").Value = Domaines_Competence_Pnl.Text
        rs("Narratif").Value = Narratif_rtb.rtb.Rtf
        rs("Statut").Value = statut
        rs("Dat_Modif").Value = oDat
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()
        If Num_DR_txt.Text <> "" Then
            Request()
        Else
            Num_DR_txt.Text = NumDR
        End If
        Return New savingResult With {.result = True, .message = "Enregistré avec succès"}
    End Function
    Sub Deleting()
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette demande?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from Recrutement_Demande where Num_DR='" & Num_DR_txt.Text & "' and id_Societe=" & Societe.id_Societe _
      &
    " insert into  Mouchard_Suppression ( Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
values ('Recrutement_Demande','Num_DR','" & Num_DR_txt.Text & "','" & theUser.id_User & "', getdate())")
        Reset_Form(Me)
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
    End Sub
    Private Sub RH_Demande_Conge_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Request()
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        Dat_DR_txt.Text = Now.ToShortDateString
    End Sub
    Private Sub Montant_DR_txt_Validating(sender As Object, e As CancelEventArgs) Handles Buget_Salaire_txt.Validating
        If Not IsNumeric(Buget_Salaire_txt.Text) Then
            e.Cancel = True
        End If
    End Sub
    Private Sub Montant_DR_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Buget_Salaire_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub
    Private Sub Montant_DR_txt_Leave(sender As Object, e As EventArgs) Handles Buget_Salaire_txt.Leave, Age_Au.Leave, Age_Au.Leave
        If Not IsNumeric(sender.Text) Then
            sender.Text = "0,00"
        End If
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_DR_txt, Me)
    End Sub
#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        Return Saving("SS")
    End Function
    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function
    Private Sub Cod_Poste_txt_Load(sender As Object, e As EventArgs) Handles Cod_Poste_txt.TextChanged
        Lib_Poste_Text.Text = FindLibelle("Lib_Poste", "Cod_Poste", Cod_Poste_txt.Text, "Org_Poste")
    End Sub

    Private Sub Cod_Grade_txt_Load(sender As Object, e As EventArgs) Handles Cod_Grade_txt.TextChanged
        Lib_Grade_Text.Text = FindLibelle("Lib_Grade", "Cod_Grade", Cod_Grade_txt.Text, "Org_Grade")
    End Sub

    Private Sub Cod_Entite_txt_Load(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub

    Private Sub Cod_Entite_DR_txt_Load(sender As Object, e As EventArgs) Handles Cod_Entite_DR_txt.TextChanged
        Lib_Entite_DR_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_DR_txt.Text, "Org_Entite")
    End Sub

    Private Sub Cod_Grade_DR_txt_Load(sender As Object, e As EventArgs) Handles Cod_Grade_DR_txt.TextChanged
        Lib_Grade_DR_txt.Text = FindLibelle("Lib_Grade", "Cod_Grade", Cod_Grade_DR_txt.Text, "Org_Grade")
    End Sub

    Private Sub Cod_Poste_DR_txt_Load(sender As Object, e As EventArgs) Handles Cod_Poste_DR_txt.TextChanged
        Lib_Poste_DR_txt.Text = FindLibelle("Lib_Poste", "Cod_Poste", Cod_Poste_DR_txt.Text, "Org_Poste")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Calender(Duree_Du, Me)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Calender(Duree_Au, Me)
    End Sub

    Private Sub Age_Au_KeyPress(sender As Object, e As EventArgs) Handles Age_Au.KeyPress, Age_Du.KeyPress
        ControleSaisie(sender, e, True, True, True, False, False)
    End Sub

    Private Sub Rd_Age_Determine_0_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Age_0.CheckedChanged, Rd_Age_1.CheckedChanged
        Age_pnl.Visible = Rd_Age_1.Checked

    End Sub
    Private Sub Age_pnl_VisibleChanged(sender As Object, e As EventArgs) Handles Age_pnl.VisibleChanged
        If Age_pnl.Visible Then
            If Not IsNumeric(Age_Du.Text) Then Age_Du.Text = 18
            If Not IsNumeric(Age_Au.Text) Then Age_Au.Text = 59
        End If
    End Sub

    Private Sub Rd_determinee_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Duree_1.CheckedChanged, Rd_Duree_0.CheckedChanged
        Duree_pnl.Visible = Rd_Duree_1.Checked
    End Sub
#End Region
    Private Sub Comptence_Pnl_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Domaines_Competence_Pnl.MouseDoubleClick
        Dim laListe = IsNull(Domaines_Competence_Pnl.Text, "").Split(";").ToList()
        Dim f As New Zoom_GPEC_Domaines_Competence
        With f
            .domaines = laListe
            .ShowDialog()
        End With
        Dim domList = stringToDictionary(String.Join(";"c, laListe)).Keys()
        For i = Domaines_Competence_Pnl.Controls.Count - 1 To 0 Step -1
            If Not domList.Contains(Domaines_Competence_Pnl.Controls(i).Name) Then
                Domaines_Competence_Pnl.Controls.RemoveAt(i)
            End If
        Next
        For Each c In laListe
            If Not String.IsNullOrWhiteSpace(c) Then
                If Domaines_Competence_Pnl.Controls.Find(c.Split("$")(0), True).Length = 0 Then
                    AddCompetence(c)
                End If
            End If
        Next
        RearrangeControls()
        Domaines_Competence_Pnl.Text = String.Join(";", laListe)
    End Sub
    Sub AddCompetence(competenceName As String)
        If String.IsNullOrWhiteSpace(competenceName) Then Return
        Dim nomCom As String = ""
        Dim note As Double = 1
        Dim _rw = competenceName.Split("$"c)
        nomCom = _rw(0)
        If _rw.Length > 1 Then
            If IsNumeric(_rw(1)) Then note = CDbl(_rw(1))
        End If
        Dim ud As New ud_Domaine_Competence
        With ud
            .canRate = True
            .Nom = nomCom
            .Rating = note
            Domaines_Competence_Pnl.Controls.Add(ud)
        End With
    End Sub
    Public Sub RearrangeControls()
        Dim x, y, sp As Integer
        sp = 5 ' Espace entre les contrôles
        x = sp
        y = sp

        Dim controlHeight As Integer = 0 ' Utilisé pour suivre la hauteur du dernier contrôle traité
        Domaines_Competence_Pnl.Text = ""
        For Each cnt As ud_Domaine_Competence In Domaines_Competence_Pnl.Controls
            If controlHeight = 0 Then
                controlHeight = cnt.Height ' Initialisez avec la hauteur du premier contrôle si non défini
            End If

            ' Calculez la nouvelle position x, y pour le contrôle actuel
            If x + cnt.Width + sp <= Domaines_Competence_Pnl.Width Then
                ' Assez d'espace pour placer ce contrôle à côté du précédent
                cnt.Location = New Point(x, y)
                x += cnt.Width + sp
            Else
                ' Pas assez d'espace, revenez au début et déplacez vers le bas
                x = sp
                y += controlHeight + sp
                cnt.Location = New Point(x, y)
                x += cnt.Width + sp
            End If
            Domaines_Competence_Pnl.Text &= If(String.IsNullOrWhiteSpace(Domaines_Competence_Pnl.Text), "", ";") & cnt.Name & "$" & cnt.Rating()
        Next
    End Sub
    Sub SuppressionDomaine(ud As ud_Domaine_Competence)
        Domaines_Competence_Pnl.Controls.Remove(ud)
        RearrangeControls()
    End Sub

    Private Sub Grade__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Grade_.LinkClicked
        Appel_Zoom1("MS015", Cod_Grade_DR_txt, Me)
    End Sub

    Private Sub Poste__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Poste_.LinkClicked
        Appel_Zoom1("MS016", Cod_Poste_DR_txt, Me, IIf(Cod_Grade_DR_txt.Text = "", "", "Cod_Grade='" & Cod_Grade_DR_txt.Text & "'"))
    End Sub

    Private Sub Entite__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Entite_.LinkClicked
        Appel_Zoom1("MS010", Cod_Entite_DR_txt, Me)
    End Sub
    Private Sub ChargerCompetencesPoste_btn_Enter(sender As Object, e As EventArgs) Handles ChargerCompetencesPoste_btn.MouseHover
        With ChargerCompetencesPoste_btn
            .Image = My.Resources.btn_execute_w
            .bgColor = Color.FromArgb(56, 153, 185)
            .ForeColor = Color.White
        End With
    End Sub

    Private Sub ChargerCompetencesPoste_btn_MouseLeave(sender As Object, e As EventArgs) Handles ChargerCompetencesPoste_btn.MouseLeave
        With ChargerCompetencesPoste_btn
            .Image = My.Resources.btn_execute
            .bgColor = Color.White
            .ForeColor = Color.FromArgb(56, 153, 185)
        End With
    End Sub
    Private Sub ChargerCompetencesPoste_btn_Click(sender As Object, e As EventArgs) Handles ChargerCompetencesPoste_btn.Click
        If Cod_Poste_DR_txt.Text = "" Then Return
        Dim CompetencesPoste As String = CnExecuting("select isnull((select top 1 Domaines_Competence from Org_Poste where Cod_Poste='" & Cod_Poste_DR_txt.Text & "' and id_Societe='" & Societe.id_Societe & "'),'')").Fields(0).Value
        If CompetencesPoste = "" Then Return
        Dim laListe = IsNull(Domaines_Competence_Pnl.Text, "").Split(";").ToList().Select(Function(x) x.Split("$")(0))
        Dim _pstComp = CompetencesPoste.Split(";").ToList().Select(Function(x) x.Split("$")(0)).Where(Function(y) Not laListe.Contains(y))
        If _pstComp.Count > 0 Then
            For Each c In _pstComp
                If Not String.IsNullOrWhiteSpace(c) Then
                    If Domaines_Competence_Pnl.Controls.Find(c, True).Length = 0 Then
                        AddCompetence(c & "$5")
                    End If
                End If
            Next
            RearrangeControls()
        End If
    End Sub
End Class