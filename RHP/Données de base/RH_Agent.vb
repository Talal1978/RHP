Public Class RH_Agent
    Friend Code As String = ""
    Friend pic As New PictureBox
    Friend Cod_Simulation As String = ""
    Dim CltTbl As New DataTable
    Friend ModeSilent As Boolean = False
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim New_D As ud_btn
    Dim Import_D As ud_btn
    Dim canRate As Boolean = False
    Sub Chargement()
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Next_D = dictButtons("Next_D")
            Back_D = dictButtons("Back_D")
            Last_D = dictButtons("Last_D")
            First_D = dictButtons("First_D")
            New_D = dictButtons("New_D")
            Import_D = dictButtons("Import_D")
        End If
        If Civilite_Combo.Items.Count = 0 Then Civilite_Combo.fromRubrique()
        If Situation.Items.Count = 0 Then Situation.fromRubrique()
        If Mod_Paiement.Items.Count = 0 Then Combo_GRD(Mod_Paiement)
        If Banque.Items.Count = 0 Then Combo_GRD(Banque)
        If Typ_Agent.Items.Count = 0 Then Typ_Agent.fromRubrique()
        If Typ_Contrat.Items.Count = 0 Then Typ_Contrat.fromRubrique()
        If Typ_Periode.Items.Count = 0 Then Typ_Periode.fromRubrique()
        If Motif_Depart.Items.Count = 0 Then Motif_Depart.fromRubrique()
        If Cod_Pays_Text.Text = "" Then Cod_Pays_Text.Text = FindParam("Cod_Pays")
        If Nationalite_Text.Text = "" Then Nationalite_Text.Text = Cod_Pays_Text.Text
        If Niveau.Items.Count = 0 Then Combo_GRD(Niveau)
        If Typ_Param.Items.Count = 0 Then Combo_GRD(Typ_Param)
        If Lien_Parente.Items.Count = 0 Then Combo_GRD(Lien_Parente)
        If Typ_Valeur_Paiement.Items.Count = 0 Then Combo_GRD(Typ_Valeur_Paiement)
        If theUser.Typ_Role = "Agent" Then
            Save_D.Visible = False
            Del_D.Visible = False
            Next_D.Visible = False
            Back_D.Visible = False
            Last_D.Visible = False
            First_D.Visible = False
            New_D.Visible = False
            Import_D.Visible = False
            Elements_Paie.Visible = Not Societe.Masquer_Element_Paie_Agent
            If Matricule_Text.Text = "" Then Matricule_Text.Text = theUser.Matricule
        End If
        Dim _rw = Tbl_Function_Security.Select("Function_Sec='GPECRating'")
        If _rw.Length > 0 Then
            canRate = (CBool(_rw(0)("Visible")) Or theUser.Cod_Profile = 1)
        End If
    End Sub
    Private Sub Matricule__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS067", Matricule_Text, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            If Nom_Agent_Text.Text = "************" Then Nom_Agent_Text.Text = ""
            Appel_Zoom1("MS067", Matricule_Text, Me)
        End If

    End Sub
    Sub request()
        Cod_Simulation = ""
        Chargement()
        EB_Grd.Rows.Clear()
        Formations_GRD.Rows.Clear()
        Experiences_Grd.Rows.Clear()
        Famille_Grd.Rows.Clear()
        Grd_Bancarisation.Rows.Clear()
        Domaines_Competence_Pnl.Controls.Clear()
        Domaines_Competence_Pnl.Text = ""
        Dim SqlStr As String = "Select * from RH_Agent a
outer apply(select top 1 * from RH_Conge where Matricule=a.Matricule and id_Societe=a.id_Societe order by Annee desc)c
where a.Matricule='" & Matricule_Text.Text & "' and a.id_Societe=" & Societe.id_Societe
        CltTbl = DATA_READER_GRD(SqlStr)
        If CltTbl.Rows.Count > 0 Then
            Nom_Agent_Text.Text = IsNull(CltTbl.Rows(0).Item("Nom_Agent"), "")
            Prenom_Agent_Text.Text = IsNull(CltTbl.Rows(0).Item("Prenom_Agent"), "")
            CIN_Agent_Text.Text = IsNull(CltTbl.Rows(0).Item("CIN_Agent"), "")
            NumCE_txt.Text = IsNull(CltTbl.Rows(0).Item("NumCE"), "")
            NumPPR_txt.Text = IsNull(CltTbl.Rows(0).Item("NumPPR"), "")
            Nationalite_Text.Text = IsNull(CltTbl.Rows(0).Item("Nationalite"), "")
            Civilite_Combo.SelectedValue = IsNull(CltTbl.Rows(0).Item("Civilite"), "")
            Adresse_Text.Text = IsNull(CltTbl.Rows(0).Item("Adresse"), "")
            Cod_Ville_Text.Text = IsNull(CltTbl.Rows(0).Item("Cod_Ville"), "")
            Cod_Pays_Text.Text = IsNull(CltTbl.Rows(0).Item("Cod_Pays"), "")
            Cod_Pst_Text.Text = IsNull(CltTbl.Rows(0).Item("Cod_Pst"), "")
            Fixe_Text.Text = IsNull(CltTbl.Rows(0).Item("Fixe"), "")
            Gsm_Text.Text = IsNull(CltTbl.Rows(0).Item("Gsm"), "")
            Mail_Text.Text = IsNull(CltTbl.Rows(0).Item("Mail"), "")
            Situation.SelectedValue = IsNull(CltTbl.Rows(0).Item("Situation"), "")
            Dat_Naissance_Text.Text = IsNull(CltTbl.Rows(0).Item("Dat_Naissance"), "")
            Lieu_Naissance_Text.Text = IsNull(CltTbl.Rows(0).Item("Lieu_Naissance"), "")
            Typ_Agent.SelectedValue = IsNull(CltTbl.Rows(0).Item("Typ_Agent"), "")
            Typ_Contrat.SelectedValue = IsNull(CltTbl.Rows(0).Item("Typ_Contrat"), "")
            Cod_Plan_Paie_Text.Text = IsNull(CltTbl.Rows(0).Item("Plan_Paie"), "")
            Dat_Entree_Text.Text = IsNull(CltTbl.Rows(0).Item("Dat_Entree"), "")
            Dat_Confirmation_Text.Text = IsNull(CltTbl.Rows(0).Item("Dat_Confirmation"), "")
            Dat_Sortie_Text.Text = IsNull(CltTbl.Rows(0).Item("Dat_Sortie"), "")
            Dat_Fin_Contrat_Text.Text = IsNull(CltTbl.Rows(0).Item("Dat_Fin_Contrat"), "")
            Droit_Paie.Checked = IsNull(CltTbl.Rows(0).Item("Droit_Paie"), "false")
            Typ_Periode.SelectedValue = IsNull(CltTbl.Rows(0).Item("Typ_Periode"), "")
            Motif_Depart.SelectedValue = IsNull(CltTbl.Rows(0).Item("Motif_Depart"), "")
            Commentaire_Text.Text = IsNull(CltTbl.Rows(0).Item("Commentaire"), "")
            Titre_txt.Text = IsNull(CltTbl.Rows(0).Item("Titre"), "")
            Poste_Text.Text = IsNull(CltTbl.Rows(0).Item("Cod_Poste"), "")
            Grade_Text.Text = IsNull(CltTbl.Rows(0).Item("Cod_Grade"), "")
            Cod_Entite_txt.Text = IsNull(CltTbl.Rows(0).Item("Cod_Entite"), "")
            Affectation_1_txt.Text = IsNull(CltTbl.Rows(0).Item("Affectation_1"), "")
            Affectation_2_txt.Text = IsNull(CltTbl.Rows(0).Item("Affectation_2"), "")
            Nbr_Personne_A_Charge.Value = IsNull(CltTbl.Rows(0).Item("Nbr_Personne_A_Charge"), 0)
            CNSS_Text.Text = IsNull(CltTbl.Rows(0).Item("CNSS"), "")
            Organisme1_Text.Text = IsNull(CltTbl.Rows(0).Item("Organisme1"), "")
            Identifiant01_txt.Text = IsNull(CltTbl.Rows(0).Item("Identifiant01"), "")
            Identifiant02_txt.Text = IsNull(CltTbl.Rows(0).Item("Identifiant02"), "")
            Identifiant03_txt.Text = IsNull(CltTbl.Rows(0).Item("Identifiant03"), "")
            Ref_Candidature_txt.Text = IsNull(CltTbl.Rows(0).Item("Ref_Candidature"), "")
            Domaines_Competence_Pnl.Text = IsNull(CltTbl.Rows(0).Item("Domaines_Competence"), "")
            Droit_Conge_Mensuel_txt.Text = IsNull(CltTbl.Rows(0)("Droit_Conge_Mensuel"), 0)
            Conge_Annuel_txt.Text = IsNull(CltTbl.Rows(0)("Conge_Annuel"), 0)
            Acquis_Anciennete_txt.Text = IsNull(CltTbl.Rows(0)("Acquis_Anciennete"), 0)
            Droit_Conge_txt.Text = IsNull(CltTbl.Rows(0)("Droit_Conge"), 0)
            Reliquat_Anterieurs_txt.Text = IsNull(CltTbl.Rows(0)("Reliquat_Anterieurs"), 0)
            Conge_Pris_txt.Text = IsNull(CltTbl.Rows(0)("Conge_Pris"), 0)
            Solde_Conge_txt.Text = IsNull(CltTbl.Rows(0)("Solde_Conge"), 0)
            Login_txt.Text = IsNull(CltTbl.Rows(0)("Login"), "")
            is_AD_chk.Checked = IsNull(CltTbl.Rows(0)("is_AD"), False)
            'Afficher la photo
            Dim ImageData As Object = CnExecuting("select Photo from RH_Agent where Matricule='" & Matricule_Text.Text & "'  and id_Societe=" & Societe.id_Societe).Fields(0).Value
            PictureBox1.Image = AffichagePhoto(ImageData)

            'Afficher CV
            Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 As Object
            Dim oTbl As DataTable = DATA_READER_GRD("select * from RH_Agent_CV where Matricule='" & Matricule_Text.Text & "'  and id_Societe=" & Societe.id_Societe)
            With oTbl
                For i = 0 To .Rows.Count - 1
                    C2 = .Rows(i)("Typ_CV")
                    C3 = CStr(IsNull(.Rows(i)("Annee"), ""))
                    C4 = .Rows(i)("Dat_Deb")
                    C5 = .Rows(i)("Dat_Fin")
                    C6 = IsNull(.Rows(i)("Poste"), "")
                    C7 = IsNull(.Rows(i)("Etablissement"), "")
                    C8 = IsNull(.Rows(i)("Diplome"), "")
                    C9 = IsNull(.Rows(i)("Niveau"), "")
                    C10 = IsNull(.Rows(i)("Commentaire"), "")
                    If C2 = "F" Then
                        Formations_GRD.Rows.Add(C3, C7, C8, C9, C10)
                    ElseIf C2 = "E" Then
                        Experiences_Grd.Rows.Add(C4, C5, C7, C6, C10)
                    End If
                Next
                Formations_GRD.Sort(Annee, System.ComponentModel.ListSortDirection.Descending)
                Experiences_Grd.Sort(Dat_Fin, System.ComponentModel.ListSortDirection.Descending)
            End With
            'Afficher famille
            oTbl = DATA_READER_GRD("select  Nom_Prenom, Lien_Parente, Dat_Naissance, Scolarise
 from RH_Agent_Famille where Matricule='" & Matricule_Text.Text & "'  and id_Societe=" & Societe.id_Societe)
            With oTbl
                For i = 0 To .Rows.Count - 1
                    C2 = .Rows(i).Item("Nom_Prenom")
                    C3 = IsNull(.Rows(i).Item("Lien_Parente"), "")
                    C4 = .Rows(i).Item("Dat_Naissance")
                    C5 = IsNull(.Rows(i).Item("Scolarise"), False)
                    Famille_Grd.Rows.Add(C2, C3, C4, C5)
                Next
            End With
            'Afficher les éléments de la paie
            oTbl = DATA_READER_GRD("select Cod_Rubrique,Lib_Rubrique,Typ_Retour,Valeur from RH_Agent_Element_Paie a outer apply (select Lib_Rubrique,Typ_Retour from RH_Paie_Rubrique where Cod_Rubrique=a.Cod_Rubrique and  isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe & ") o  where Matricule='" & Matricule_Text.Text & "' and id_Societe=" & Societe.id_Societe)
            Dim nbdec As Integer = 2
            With oTbl
                For i = 0 To .Rows.Count - 1
                    C2 = .Rows(i).Item("Cod_Rubrique")
                    C3 = IsNull(.Rows(i).Item("Lib_Rubrique"), "")
                    C4 = IsNull(.Rows(i).Item("Typ_Retour"), "")
                    If C4 = "float" Or C4 = "int" Then
                        C5 = FormatDeNombre(.Rows(i).Item("Valeur"))
                    Else
                        C5 = IsNull(.Rows(i).Item("Valeur"), "")
                    End If
                    EB_Grd.Rows.Add(C2, C3, C4, C5)
                Next
            End With
            'Bancarisation
            oTbl = DATA_READER_GRD("select * from RH_Agent_Paiement where Matricule='" & Matricule_Text.Text & "' and id_Societe=" & Societe.id_Societe)

            With oTbl
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i).Item("Mod_Paiement"), "")
                    C2 = IsNull(.Rows(i).Item("Banque"), "")
                    C3 = IsNull(.Rows(i).Item("Agence"), "")
                    C4 = IsNull(.Rows(i).Item("Compte_Bancaire"), "")
                    C5 = IsNull(.Rows(i).Item("RIB"), "")
                    C6 = IsNull(.Rows(i).Item("Typ_Valeur_Paiement"), "Prc")
                    C7 = FormatDeNombre(IsNull(.Rows(i).Item("Valeur"), IIf(C6 = "Prc", 100, 0)))
                    C8 = IsNull(.Rows(i).Item("Salaire_Domicilie"), False)
                    Grd_Bancarisation.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8)
                Next
            End With
            Dim laListe = IsNull(Domaines_Competence_Pnl.Text, "").Split(";").ToList()
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

        ElseIf Matricule_Text.Text.Trim = "" Then
            Reset_Form(Me)
        End If
        GRD("select Dat_Deb_Conge as 'Du', Dat_Fin_Conge as 'Au', Duree_Globale as 'Durée totale',
Repos_Hebdomadaire as 'Repos hebdo.', Jours_Feries as 'Jrs fériés', Duree_Conge as 'Consomé du congé'
from RH_Conge_Suivi where Matricule='" & Matricule_Text.Text & "' and id_Societe=" & Societe.id_Societe & " 
order by Dat_Deb_Conge desc", Grd_Conge)

    End Sub
    Private Sub is_AD_chk_Click(sender As Object, e As EventArgs) Handles is_AD_chk.Cliquer
        If is_AD_chk.Checked Then
            Cursor = Cursors.WaitCursor
            If Not ApplyADInfo() Then
                ShowMessageBox("Ce compte n'existe pas.", "Active Directory")
                is_AD_chk.Checked = False
            End If
            Cursor = Cursors.Default
        End If
    End Sub
    Function ApplyADInfo() As Boolean
        If Login_txt.Text.Trim = "" Then Return False
        If Not is_AD_chk.Checked Then Return False
        Dim userInfo As ADUserInfo = GetADUserInfo(Login_txt.Text.Trim)
        Return userInfo.Exists
    End Function
    Private Sub RH_Agent_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'  and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            End If
            If CnExecuting("Select count(*) from RH_Param_Plan_Paie where id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
                If ShowMessageBox("Cette société ne contient aucun plan de paie actif. Voulez-vous en créer un maintenant?", "Plan de paie", MessageBoxButtons.OKCancel, msgIcon.Information) = DialogResult.OK Then
                    Dim f As New RH_Parametrage_Plan_Paie
                    newShowEcran(f)
                End If
            End If

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub RH_Agent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Chargement()

        Dim Mnu1, Mnu2, Mnu3 As New ToolStripMenuItem
        Dim ContextMnu As New ContextMenuStrip
        With Mnu1
            .Text = "Charger une Image"
            AddHandler .Click, AddressOf ChargerImage
        End With
        With Mnu2
            .Text = "Supprimer l'Image"
            AddHandler .Click, AddressOf SupprimerImage
        End With
        With Mnu3
            .Text = "Copier l'Image"
            AddHandler .Click, AddressOf CopierImage
        End With
        With ContextMnu
            .Items.Insert(0, Mnu1)
            .Items.Insert(1, Mnu2)
            .Items.Insert(1, Mnu3)
        End With
        PictureBox1.ContextMenuStrip = ContextMnu
        With pic
            .BackColor = Color.Transparent
            .SizeMode = PictureBoxSizeMode.AutoSize
            Experiences_Grd.Controls.Add(pic)
            .Visible = False
        End With
    End Sub
    Sub ChargerImage()
        ChargerPhoto(PictureBox1)
    End Sub
    Sub SupprimerImage()
        PictureBox1.Image = Nothing
    End Sub
    Sub CopierImage()
        If Not PictureBox1.Image Is Nothing Then Clipboard.SetImage(PictureBox1.Image)
    End Sub
    Private Sub Cod_Ville__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Cod_Ville_.LinkClicked
        Appel_Zoom("Cod_Ville", "ville", "Param_Ville", "Cod_Pays ='" & Cod_Pays_Text.Text & "'", Cod_Ville_Text, Me)
    End Sub
    Private Sub Cod_Pays__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Cod_Pays_.LinkClicked
        Appel_Zoom1("MS024", Cod_Pays_Text, Me)
    End Sub
    Private Sub LinkLabel15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Appel_Zoom("Membre", "Membre", "Param_Rubriques", "Nom_Controle='Cod_Pst_Combo'", Cod_Pst_Text, Me)
    End Sub
    Private Sub Dat_Naissance__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Dat_Naissance_.LinkClicked
        Appel_Calender(Dat_Naissance_Text, Me, Now.AddYears(-20))
    End Sub
    Private Sub Lieu_Naissance__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Lieu_Naissance_.LinkClicked
        Appel_Zoom("Cod_Ville", "ville", "Param_Ville", "1=1", Lieu_Naissance_Text, Me)
    End Sub
    Private Sub Nationalite__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Nationalite_.LinkClicked
        Appel_Zoom("Valeur", "Membre", "Param_Rubriques", "Nom_Controle='Nationalite'", Nationalite_Text, Me)
    End Sub
    Private Sub Matricule_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Matricule_Text.TextChanged
        Try
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'  and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            End If
            If Nom_Agent_Text.Text = "************" Then Exit Sub
            DroitAcces(Me, IIf(theUser.Typ_Role = "Agent", False, DroitModify_Fiche(Matricule_Text.Text, Me)))
            request()
            RequestingBlocNotes()
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Matricule_Text.Text)
                Code = Matricule_Text.Text
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Cod_Pays_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Pays_Text.TextChanged
        Lib_Pays_Text.Text = FindLibelle("Pays", "Cod_Pays", Cod_Pays_Text.Text, "Param_Pays")
    End Sub
    Private Sub Lieu_Naissance_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lieu_Naissance_Text.TextChanged
        Lib_Lieu_Naissance_Text.Text = FindLibelle("Ville", "Cod_Ville", Lieu_Naissance_Text.Text, "Param_Ville")
    End Sub
    Private Sub Plan_Paie__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Plan_Paie_.LinkClicked
        Appel_Zoom1("MS069", Cod_Plan_Paie_Text, Me)
        Conge_Annuel_txt.Text = ConvertNombre(FindLibelle("NbJourCongeAcquis", "Cod_Plan_Paie", Cod_Plan_Paie_Text.Text, "RH_Param_Plan_Paie"))
    End Sub
    Private Sub Plan_Paie_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        Lib_Plan_Paie_Text.Text = FindLibelle("Lib_Plan_Paie", "Cod_Plan_Paie", Cod_Plan_Paie_Text.Text, "RH_Param_Plan_Paie")
    End Sub
    Private Sub Dat_Entree__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Dat_Entree_.LinkClicked
        Appel_Calender(Dat_Entree_Text, Me)
    End Sub
    Private Sub Dat_Fin_Contrat__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Dat_Fin_Contrat_.LinkClicked
        Appel_Calender(Dat_Fin_Contrat_Text, Me)
    End Sub
    Private Sub Dat_Confirmation__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Dat_Confirmation_.LinkClicked
        Appel_Calender(Dat_Confirmation_Text, Me)
    End Sub
    Private Sub Dat_Sortie__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Dat_Sortie_.LinkClicked
        Appel_Calender(Dat_Sortie_Text, Me)
    End Sub
    Private Sub Nationalite_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nationalite_Text.TextChanged
        Lib_Nationalite_Text.Text = FindRubriques("Nationalite", Nationalite_Text.Text)
    End Sub
    Private Sub Cod_Ville_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Ville_Text.TextChanged
        Lib_Ville_Liv_Text.Text = FindLibelle("Ville", "Cod_Ville", Cod_Ville_Text.Text, "Param_Ville")
    End Sub
    Sub Enregistrer()
        Dim rsl As savingResult = Saving()
        If Not ModeSilent Then
            ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
            If rsl.result Then Matricule_Text_TextChanged(Nothing, Nothing)
        End If
    End Sub
    Function Saving() As savingResult
        '   Try
        If CnExecuting("Select count(*) from Controle_Access where Name_Ecran='RH_Preparation_Paie' and Process_Id!='" & ProcessId & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
                MessageBoxRHP(687)
            End If
            Dim ErrStr As String = ""
            If Nom_Agent_Text.Text.Contains("**") Or Prenom_Agent_Text.Text.Contains("**") Then
                Return New savingResult With {.message = MessageBoxRHPText(669), .result = False}
            End If
            If LTrim(Matricule_Text.Text) = "" And Not Societe.Compteur_Auto Then
                Return New savingResult With {.message = MessageBoxRHPText(670), .result = False}
            End If
            If LTrim(Nom_Agent_Text.Text) = "" Or LTrim(Prenom_Agent_Text.Text) = "" Then
                Return New savingResult With {.message = MessageBoxRHPText(671), .result = False}
            End If
            If Civilite_Combo.SelectedIndex = -1 Then
                ErrStr = "La civitlité n'a pas été renseignée pour ce matricule."
                Civilite_Combo.SelectedValue = "Mr"
            End If
            If LTrim(Cod_Plan_Paie_Text.Text) = "" And Droit_Paie.Checked Then
                ErrStr = "Code Plan manquant. Le droit à la paie sera désactivé."
                Droit_Paie.Checked = False
            End If
            If LTrim(Cod_Plan_Paie_Text.Text) <> "" And LTrim(Lib_Plan_Paie_Text.Text) = "" Then
                Return New savingResult With {.message = "Plan de paie erroné.", .result = False}
            End If
            If LTrim(Cod_Plan_Paie_Text.Text) <> "" Then
                Dim strRub As String = ""
                With EB_Grd
                    For i = 0 To .RowCount - 2
                        If IsNull(.Item(Cod_Rubrique.Index, i).Value, "") <> "" Then
                            strRub &= IIf(strRub = "", "", ",") & "'" & .Item(Cod_Rubrique.Index, i).Value & "'"
                        End If
                    Next
                End With
                If strRub.Trim <> "" Then
                    Dim TblRub As DataTable = DATA_READER_GRD("select * from RH_Paie_Rubrique where isnull(nullif(id_societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe & " and Cod_Rubrique in (" & strRub & ") 
and not exists(select Cod_Plan_Paie from RH_Param_Plan_Paie where  ';'+isnull(Element_Paie,'')+';' like '%;'+Cod_Rubrique+';%' and id_Societe=" & Societe.id_Societe & " and Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "')")
                    If TblRub.Rows.Count > 0 Then
                        Return New savingResult With {.message = "Au moins un élément de la paie ne figure pas sur le plan choisi : [" & TblRub.Rows(0)("Cod_Rubrique") & "]", .result = False}
                    End If
                End If

            End If
            'Vérification des doublons
            If CnExecuting("select count(Matricule) from RH_Agent where id_Societe=" & Societe.id_Societe & " and ltrim(rtrim(Matricule))<>'" & Matricule_Text.Text.Trim & "'
                    and ltrim(rtrim(isnull(Nom_Agent,'')))='" & Nom_Agent_Text.Text.Trim.Replace("'", "''") & "' and  
                    ltrim(rtrim(isnull(Prenom_Agent,''))) ='" & Prenom_Agent_Text.Text.Trim.Replace("'", "''") & "' and isnull(Droit_Paie,'false')='" & Droit_Paie.Checked & "'
                    and not exists(select Matricule from Rh_Agent where id_Societe=" & Societe.id_Societe & " and ltrim(rtrim(Matricule))='" & Matricule_Text.Text.Trim & "')").Fields(0).Value > 0 And (Nom_Agent_Text.Text.Trim <> "" Or Prenom_Agent_Text.Text.Trim <> "") Then
                ErrStr = "Un autre agent porte le même nom et prénon"
            End If
            If Not estEmail(Mail_Text.Text) And Mail_Text.Text.Trim <> "" Then
                ErrStr = "Erreur format de mail, il sera supprimé."
                Mail_Text.Text = ""
            End If
            If estEmail(Mail_Text.Text) Then
                Dim Tbl As DataTable = DATA_READER_GRD("select top 1 id_Societe, (select Den from Param_Societe where id_Societe=a.id_Societe) as Societe, Matricule, Nom_Agent+' '+Prenom_Agent as Nom from RH_Agent a where isnull(Mail,'')='" & Mail_Text.Text & "' and (Matricule!='" & Matricule_Text.Text & "' or  id_Societe !=" & Societe.id_Societe & ")")
                If Tbl.Rows.Count > 0 Then
                    Return New savingResult With {.message = "Ce compte mail est déjà attribué à un autre agent : " & vbCrLf & Tbl.Rows(0)("Nom") & If(Tbl.Rows(0)("id_Societe") <> Societe.id_Societe, vbCrLf & "dans une autre société : " & vbCrLf & Tbl.Rows(0)("Societe"), ""), .result = False}
                End If
            End If
            If Login_txt.Text.Trim <> "" Then
                Dim Tbl As DataTable = DATA_READER_GRD("select top 1 id_Societe, (select Den from Param_Societe where id_Societe=a.id_Societe) as Societe, Matricule, Nom_Agent+' '+Prenom_Agent as Nom from RH_Agent a where isnull(Login,'')='" & Login_txt.Text & "' and (Matricule!='" & Matricule_Text.Text & "' or  id_Societe !=" & Societe.id_Societe & ")")
                If Tbl.Rows.Count > 0 Then
                    Return New savingResult With {.message = "Ce compte mail est déjà attribué à un autre agent : " & vbCrLf & Tbl.Rows(0)("Nom") & If(Tbl.Rows(0)("id_Societe") <> Societe.id_Societe, vbCrLf & "dans une autre société : " & vbCrLf & Tbl.Rows(0)("Societe"), ""), .result = False}
                End If
            End If
            'vérification des dates
            If Not EstDate(Dat_Naissance_Text.Text) Then
                Return New savingResult With {.message = MessageBoxRHPText(674), .result = False}
            End If
            If Not EstDate(Dat_Entree_Text.Text) Then
                Return New savingResult With {.message = MessageBoxRHPText(675), .result = False}
            ElseIf CDate(Dat_Naissance_Text.Text) >= CDate(Dat_Entree_Text.Text) Then
                Return New savingResult With {.message = MessageBoxRHPText(676), .result = False}
            End If
            If EstDate(Dat_Confirmation_Text.Text) Then
                If CDate(Dat_Confirmation_Text.Text) < CDate(Dat_Entree_Text.Text) Then
                    ErrStr = MessageBoxRHPText(677)
                End If
            End If
            If EstDate(Dat_Sortie_Text.Text) Then
                If CDate(Dat_Sortie_Text.Text) < CDate(Dat_Entree_Text.Text) Then
                    Return New savingResult With {.message = MessageBoxRHPText(678), .result = False}
                ElseIf EstDate(Dat_Confirmation_Text.Text) Then
                    If CDate(Dat_Sortie_Text.Text) < CDate(Dat_Confirmation_Text.Text) Then
                        Return New savingResult With {.message = MessageBoxRHPText(679), .result = False}
                    End If
                End If
                Droit_Paie.Checked = False
            End If
            If EstDate(Dat_Fin_Contrat_Text.Text) Then
                If CDate(Dat_Fin_Contrat_Text.Text) < CDate(Dat_Entree_Text.Text) Then
                    Return New savingResult With {.message = MessageBoxRHPText(681), .result = False}
                End If
            End If
            If Not IsNumeric(Droit_Conge_Mensuel_txt.Text) Then Droit_Conge_Mensuel_txt.Text = 0
            If Droit_Conge_Mensuel_txt.Text = 0 Then
                Return New savingResult With {.message = "Droit au congé par mois non renseigné.", .result = False}
            End If
            If is_AD_chk.Checked Then
                If Not ApplyADInfo() Then is_AD_chk.Checked = False
            End If
            With Grd_Bancarisation
                Dim tx As Double = 0
                Dim mnt As Double = -1
                .CurrentCell = .Item(0, 0)
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(Mod_Paiement.Index, i).Value, "") <> "" And IsNumeric(IsNull(.Item(Valeur_.Index, i).Value, 0)) Then
                        If IsNull(.Item(Typ_Valeur_Paiement.Index, i).Value, "Mnt") = "Prc" Then
                            tx += CDbl(.Item(Valeur_.Index, i).Value)
                        Else
                            mnt += CDbl(.Item(Valeur_.Index, i).Value)
                        End If
                    End If
                Next
                If tx <> 100 And tx > 0 Then
                    Return New savingResult With {.message = "Total pourcentage différent de 100%. " & tx, .result = False}
                ElseIf mnt = 0 Then
                    Return New savingResult With {.message = "Montant des paiements de salaire est null", .result = False}
                End If
            End With
            'Vérifier les doublons au niveaux des éléments de paie
            With EB_Grd
                For i = 0 To .RowCount - 1
                    '  For j = 0 To .RowCount - 1
                    '     If IsNull(.Item(0, i).Value, "") <> "" And IsNull(.Item(0, j).Value, "") <> "" Then
                    'If .Item(0, i).Value = .Item(0, j).Value And i <> j Then
                    'TabControl1.SelectedIndex = 4
                    '    Return New savingResult With {.message = MessageBoxRHPText(682, .Item(0, i).Value), .result = False}
                    '        End If
                    ' End If
                    'Next
                    Select Case .Item(Typ_Param.Index, i).Value
                        Case "float"
                            If Not IsNumeric(.Item(Valeur.Index, i).Value.ToString.Replace(".", ",")) Then

                                TabControl1.SelectedIndex = 4
                                Return New savingResult With {.message = MessageBoxRHPText(683, EB_Grd.Item(0, i).Value), .result = False}
                            End If
                        Case "int"
                            If Not IsNumeric(.Item(Valeur.Index, i).Value.ToString.Replace(".", ",")) Then
                                TabControl1.SelectedIndex = 4
                                Return New savingResult With {.message = MessageBoxRHPText(683, EB_Grd.Item(0, i).Value), .result = False}
                            Else
                                .Item(Valeur.Index, i).Value = Math.Floor(CDbl(.Item(Valeur.Index, i).Value.ToString.Replace(".", ",")))
                            End If
                        Case "bit"
                            If .Item(Valeur.Index, i).Value <> "1" And .Item(Valeur.Index, i).Value <> "0" Then
                                TabControl1.SelectedIndex = 4
                                Return New savingResult With {.message = MessageBoxRHPText(684, EB_Grd.Item(0, i).Value), .result = False}
                            End If
                        Case "smalldatetime"
                            If Not EstDate(.Item(Valeur.Index, i).Value) Then
                                TabControl1.SelectedIndex = 4
                                Return New savingResult With {.message = MessageBoxRHPText(683, EB_Grd.Item(0, i).Value), .result = False}
                            End If
                    End Select
                Next
            End With
            Domaines_Competence_Pnl.Text = ""
            For Each cnt As ud_Domaine_Competence In Domaines_Competence_Pnl.Controls
                Domaines_Competence_Pnl.Text &= If(String.IsNullOrWhiteSpace(Domaines_Competence_Pnl.Text), "", ";") & cnt.Name & "$" & cnt.Rating()
            Next

            Dim rs As New ADODB.Recordset
            Dim Dat As Date = Now.Date
            Dim CompteurAuto As Boolean = Societe.Compteur_Auto
            Dim Cod_Sql As String = "select * from RH_Agent where Matricule='" & Matricule_Text.Text & "' and isnull(Matricule,'')<>''  and id_Societe=" & Societe.id_Societe
            rs.Open(Cod_Sql, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                If CompteurAuto And Matricule_Text.Text.Trim = "" Then
                    CnExecuting("exec Sys_Compteur 'Agent'," & Societe.id_Societe)
                    Code = FindLibelle("Last_Code", "Fichier", "Agent", "Param_Compteur")
                ElseIf Matricule_Text.Text = "" And Not ModeSilent Then
Recommence:
                    Dim A As String = getMatricule()
                    If A <> "" Then
                        Code = A
                    Else
                        GoTo Recommence
                    End If
                Else
                    Code = Matricule_Text.Text
                End If
                rs("Matricule").Value = Code
                rs("id_Societe").Value = Societe.id_Societe
                rs("Created_By").Value = theUser.Login
                rs("Dat_Crea").Value = Dat
            Else
                rs.Update()
                Code = Matricule_Text.Text
            End If
            rs("Nom_Agent").Value = Nom_Agent_Text.Text
            rs("Prenom_Agent").Value = Prenom_Agent_Text.Text
            rs("Sexe").Value = IIf(Civilite_Combo.SelectedValue = "Mr", "H", "F")
            rs("CIN_Agent").Value = CIN_Agent_Text.Text
            rs("NumCE").Value = NumCE_txt.Text
            rs("NumPPR").Value = NumPPR_txt.Text
            rs("Nationalite").Value = Nationalite_Text.Text
            rs("Civilite").Value = Civilite_Combo.SelectedValue
            rs("Adresse").Value = Adresse_Text.Text
            rs("Cod_Ville").Value = Cod_Ville_Text.Text
            rs("Cod_Pays").Value = Cod_Pays_Text.Text
            rs("Cod_Pst").Value = Cod_Pst_Text.Text
            rs("Fixe").Value = Fixe_Text.Text
            rs("Gsm").Value = Gsm_Text.Text
            rs("Mail").Value = Mail_Text.Text
            rs("Situation").Value = Situation.SelectedValue
            rs("Dat_Naissance").Value = Dat_Naissance_Text.Text
            rs("Lieu_Naissance").Value = Lieu_Naissance_Text.Text
            rs("Typ_Agent").Value = Typ_Agent.SelectedValue
            rs("Typ_Contrat").Value = Typ_Contrat.SelectedValue
            rs("Plan_Paie").Value = Cod_Plan_Paie_Text.Text
            rs("Ref_Candidature").Value = Ref_Candidature_txt.Text
            rs("Dat_Entree").Value = Dat_Entree_Text.Text
            rs("Dat_Confirmation").Value = Dat_Confirmation_Text.Text
            If EstDate(Dat_Confirmation_Text.Text) Then
                rs("Dat_Confirmation").Value = Dat_Confirmation_Text.Text
            Else
                rs("Dat_Confirmation").Value = Nothing
            End If
            If EstDate(Dat_Sortie_Text.Text) Then
                rs("Dat_Sortie").Value = Dat_Sortie_Text.Text
            Else
                rs("Dat_Sortie").Value = Nothing
            End If
            If EstDate(Dat_Fin_Contrat_Text.Text) Then
                rs("Dat_Fin_Contrat").Value = Dat_Fin_Contrat_Text.Text
            Else
                rs("Dat_Fin_Contrat").Value = Nothing
            End If
            rs("Droit_Paie").Value = Droit_Paie.Checked
            rs("Typ_Periode").Value = Typ_Periode.SelectedValue
            rs("Motif_Depart").Value = Motif_Depart.SelectedValue
            rs("Commentaire").Value = Commentaire_Text.Text
            rs("Titre").Value = Titre_txt.Text
            rs("Cod_Poste").Value = Poste_Text.Text
            rs("Cod_Grade").Value = Grade_Text.Text
            rs("Cod_Entite").Value = Cod_Entite_txt.Text
            rs("Affectation_1").Value = Affectation_1_txt.Text
            rs("Affectation_2").Value = Affectation_2_txt.Text
            rs("Nbr_Personne_A_Charge").Value = Nbr_Personne_A_Charge.Value
            rs("CNSS").Value = CNSS_Text.Text
            rs("Organisme1").Value = Organisme1_Text.Text
            rs("Identifiant01").Value = Identifiant01_txt.Text
            rs("Identifiant02").Value = Identifiant02_txt.Text
            rs("Identifiant03").Value = Identifiant03_txt.Text
            rs("Ref_Candidature").Value = Ref_Candidature_txt.Text
            rs("Domaines_Competence").Value = Domaines_Competence_Pnl.Text
            rs("Droit_Conge_Mensuel").Value = Droit_Conge_Mensuel_txt.Text
            rs("Login").Value = Login_txt.Text.Trim
            rs("is_AD").Value = is_AD_chk.Checked
            rs("Dat_Modif").Value = Dat
            rs("Modified_By").Value = theUser.Login
            If Cod_Simulation <> "" Then
                rs("Cod_Simulation").Value = Cod_Simulation
                Cod_Simulation = ""
            End If

            'Enregistrer la nouvelle photo
            rs("Photo").Value = PhotoToByte(PictureBox1.Image)
            rs.Update()
            rs.Close()


            'Enregistrer le CV :
            CnExecuting("delete from RH_Agent_CV where Matricule='" & Code & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from RH_Agent_CV", cn, 2, 2)
            With Formations_GRD
                For i = 0 To .RowCount - 1
                    If .Item(0, i).Value <> "" Then
                        rs.AddNew()
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Matricule").Value = Code
                        rs("Typ_CV").Value = "F"
                        rs("Annee").Value = .Item(0, i).Value
                        rs("Diplome").Value = .Item(1, i).Value
                        rs("Etablissement").Value = .Item(2, i).Value
                        rs("Niveau").Value = .Item(3, i).Value
                        rs("Commentaire").Value = .Item(4, i).Value
                        rs.Update()
                    End If
                Next
            End With
            With Experiences_Grd
                For i = 0 To .RowCount - 1
                    If .Item(0, i).Value <> "" Then
                        rs.AddNew()
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Matricule").Value = Code
                        rs("Typ_CV").Value = "E"
                        rs("Dat_Deb").Value = .Item(0, i).Value
                        rs("Dat_Fin").Value = .Item(1, i).Value
                        rs("Etablissement").Value = .Item(2, i).Value
                        rs("Poste").Value = .Item(3, i).Value
                        rs("Commentaire").Value = .Item(4, i).Value
                        rs.Update()
                    End If
                Next
            End With
            rs.Close()
            'Enregistrer la famille :
            CnExecuting("delete from RH_Agent_Famille where Matricule='" & Code & "'  and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from RH_Agent_Famille", cn, 2, 2)
            With Famille_Grd
                For i = 0 To .RowCount - 1
                    If .Item(0, i).Value <> "" Then
                        rs.AddNew()
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Matricule").Value = Code
                        rs("Nom_Prenom").Value = .Item(0, i).Value
                        rs("Lien_Parente").Value = .Item(1, i).Value
                        rs("Dat_Naissance").Value = .Item(2, i).Value
                        rs("Scolarise").Value = .Item(3, i).Value
                        rs.Update()
                    End If
                Next
            End With
            rs.Close()
            With EB_Grd
                Dim rd As New Random
                Dim flg As Integer = rd.Next(100, 9050)

                Dim val As Double = 0
                For i = 0 To .RowCount - 1
                    val = ConvertNombre(Replace(.Item("Valeur", i).Value, ".", ","))
                    rs.Open("select * from RH_Agent_Element_Paie where Cod_Rubrique='" & IsNull(.Item(Cod_Rubrique.Index, i).Value, "") & "' and Matricule='" & Code & "'  and id_Societe=" & Societe.id_Societe, cn, 2, 2)
                    If .Item(Cod_Rubrique.Index, i).Value <> "" And val <> 0 Then
                        If rs.EOF Then
                            rs.AddNew()
                            rs("id_Societe").Value = Societe.id_Societe
                            rs("Matricule").Value = Code
                            rs("Cod_Rubrique").Value = .Item(Cod_Rubrique.Index, i).Value
                        Else
                            rs.Update()
                        End If
                        rs("Valeur").Value = val
                        rs("Flg").Value = flg
                        rs.Update()
                    End If
                    rs.Close()
                Next
                CnExecuting("delete from RH_Agent_Element_Paie where Matricule='" & Code & "' and isnull(Flg,0)<>" & flg & " and id_Societe=" & Societe.id_Societe)
            End With
            SavingNotes()
            'Recalcul de congé
            If Not IsNumeric(Reliquat_Anterieurs_txt.Text) Then Reliquat_Anterieurs_txt.Text = 0
            rs.Open("select * from RH_Conge where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_Text.Text & "'  and Annee=" & Now.Year, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("id_Societe").Value = Societe.id_Societe
                rs("Matricule").Value = Code
                rs("Annee").Value = Now.Year
                rs("Conge_Annuel").Value = 0
                rs("Acquis_Anciennete").Value = 0
                rs("Droit_Conge").Value = 0
                rs("Conge_Pris").Value = 0
                rs("Created_By").Value = theUser.Login
                rs("Dat_Crea").Value = Dat
            Else
                rs.Update()
            End If
            rs("Reliquat_Anterieurs").Value = CDbl(Reliquat_Anterieurs_txt.Text)
            rs("Solde_Conge").Value = CDbl(rs("Droit_Conge").Value) + CDbl(Reliquat_Anterieurs_txt.Text) - CDbl(rs("Conge_Pris").Value)
            rs("Dat_Modif").Value = Dat
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            'Bancarisation
            CnExecuting("delete from RH_Agent_Paiement where Matricule='" & Matricule_Text.Text & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from RH_Agent_Paiement where Matricule='" & Matricule_Text.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            With Grd_Bancarisation
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(RIB.Index, i).Value, "") <> "" Then
                        rs.AddNew()
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Matricule").Value = Code
                        rs("Mod_Paiement").Value = IsNull(.Item(Mod_Paiement.Index, i).Value, "VIRE")
                        rs("Banque").Value = .Item(Banque.Index, i).Value
                        rs("Agence").Value = .Item(Agence.Index, i).Value
                        rs("Compte_Bancaire").Value = .Item(Compte_Bancaire.Index, i).Value
                        rs("RIB").Value = .Item(RIB.Index, i).Value
                        rs("Salaire_Domicilie").Value = IsNull(.Item(Salaire_Domicilie.Index, i).Value, False)
                        rs("Typ_Valeur_Paiement").Value = IsNull(.Item(Typ_Valeur_Paiement.Index, i).Value, "Mnt")
                        rs("Valeur").Value = IsNull(.Item(Valeur_.Index, i).Value, 0)
                        rs.Update()
                    End If
                Next
            End With
            rs.Close()
            Matricule_Text.Text = Code
            If ErrStr <> "" Then
                Return New savingResult With {.message = ErrStr, .result = True}
            Else
                Return New savingResult With {.message = "Enregistré avec succès", .result = True}
            End If
        '   Catch ex As Exception
        '   Return New savingResult With {.message = ex.Message, .result = False}
        '    End Try
    End Function
    Function getMatricule() As String
        Dim A As String = InputBox("Saisissez le nouveau code", "Nouveau").ToUpper
        Dim rg As New System.Text.RegularExpressions.Regex("\W")
        If A.Trim = "" Then
            ShowMessageBox("Matricule vide, veuillez réessayer", "Matricule", MessageBoxButtons.OK, msgIcon.Error)
            Return ""
        ElseIf rg.IsMatch(A) Then
            MessageBoxRHP(51)
            Return ""
        ElseIf A.Length > 20 Then
            MessageBoxRHP(52, "20")
            Return ""
        End If
        If CnExecuting("Select count(*) from RH_Agent where MAtricule='" & A & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            ShowMessageBox("Matricule déjà attribué, veuillez réessayer", "Matricule", MessageBoxButtons.OK, msgIcon.Error)
            Return ""
        End If
        Return A.Trim.ToUpper
    End Function
    Sub Nouveau()
        Reset_Form(Me)
        Domaines_Competence_Pnl.Controls.Clear()
        Domaines_Competence_Pnl.ResetText()
        Cod_Pays_Text.Text = Societe.Cod_Pays
        Cod_Ville_Text.Text = Societe.Ville
        Dat_Naissance_Text.Text = Now.AddYears(-20).Date
        Lieu_Naissance_Text.Text = Societe.Ville
        Situation.SelectedValue = "C"
        Civilite_Combo.SelectedValue = "Mr"
        Nationalite_Text.Text = Cod_Pays_Text.Text
        Droit_Conge_Mensuel_txt.Text = 1.5
        Reliquat_Anterieurs_txt.Text = 0
        TabControl1.SelectedIndex = 0
        Select Case Societe.Compteur_Auto
            Case False
                Dim A As String = getMatricule()
                If A <> "" Then
                    Matricule_Text.Text = A
                    Code = Matricule_Text.Text
                Else
                    Return
                End If
            Case True
                Nom_Agent_Text.Select()
        End Select

    End Sub
    Sub Div_First()
        If Matricule_Text.Text <> "" Then
            Diviseur_First("RH_Agent", "Matricule", "Matricule", Matricule_Text)
        End If
    End Sub
    Sub Div_Back()
        If Matricule_Text.Text <> "" Then
            Diviseur_Back("RH_Agent", "Matricule", "Matricule", Matricule_Text)
        End If
    End Sub
    Sub Div_Next()
        If Matricule_Text.Text <> "" Then
            Diviseur_Next("RH_Agent", "Matricule", "Matricule", Matricule_Text)
        End If
    End Sub
    Sub Div_Last()
        If Matricule_Text.Text <> "" Then
            Diviseur_Last("RH_Agent", "Matricule", "Matricule", Matricule_Text)
        End If
    End Sub
    Sub Deleting()
        If Matricule_Text.Text = "" Then Exit Sub
        If ShowMessageBox("Etes vous sûr de vouloir supprimer ce Matricule?" & Matricule_Text.Text, "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        Dim StrDel As String = String.Format("select 'IR_Permanent_Exoneres' as Tbl,count(*) Nb from IR_Permanent_Exoneres where Matricule='{0}' union all 
select 'RH_Agent_Historique' as Tbl,count(*) from RH_Agent_Historique where Matricule='{0}' 
select 'RH_Conge_Provision_Detail' as Tbl,count(*) from RH_Conge_Provision_Detail where Matricule='{0}' union all 
select 'RH_Conge_Suivi' as Tbl,count(*) from RH_Conge_Suivi where Matricule='{0}' union all 
select 'RH_Conge_Suivi_Detail' as Tbl,count(*) from RH_Conge_Suivi_Detail where Matricule='{0}' union all 
select 'RH_Dossier_Maladie' as Tbl,count(*) from RH_Dossier_Maladie where Matricule='{0}' union all 
select 'RH_Paie_Avance' as Tbl,count(*) from RH_Paie_Avance where Matricule='{0}' union all 
select 'RH_Preparation_Paie_Analytique' as Tbl,count(*) from RH_Preparation_Paie_Analytique where Matricule='{0}' union all 
select 'RH_Preparation_Paie_Detail' as Tbl,count(*) from RH_Preparation_Paie_Detail where Matricule='{0}' union all 
select 'RH_Pret' as Tbl,count(*) from RH_Pret where Matricule='{0}' union all 
select 'RH_Pret_Detail' as Tbl,count(*) from RH_Pret_Detail where Matricule='{0}' union all 
select 'RH_Simulation' as Tbl,count(*) from RH_Simulation where Matricule='{0}'", Matricule_Text.Text)
        Dim TblDel As DataTable = DATA_READER_GRD(StrDel)
        Dim nrw() As DataRow = TblDel.Select("Nb>0")
        If nrw.Length > 0 Then
            ShowMessageBox("Ce matricule est utilisé dans la table : " & nrw(0)("Tbl"), "Suppression", MessageBoxButtons.OKCancel, msgIcon.Stop)
            Return
        End If
        CnExecuting("delete from RH_Agent where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_Text.Text & "'")
        CnExecuting("delete from RH_Agent_Donnees_Diverses where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_Text.Text & "'")
        CnExecuting("delete from RH_Agent_CV where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_Text.Text & "'")
        CnExecuting("delete from RH_Agent_Element_Paie where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_Text.Text & "'")
        CnExecuting("delete from RH_Agent_Famille where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_Text.Text & "'")
        ShowMessageBox("Le matricule " & Matricule_Text.Text & " a été supprimé avec succès ", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Stop)
        Reset_Form(Me)
    End Sub
    Private Sub Experiences_Grd_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Experiences_Grd.CellMouseEnter
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = Dat_Deb.Index Or e.ColumnIndex = Dat_Fin.Index Then
            Dim pt As New Point
            pt.X = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.X + sender.Item(e.ColumnIndex, e.RowIndex).Size.Width - pic.Width
            pt.Y = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.Y
            With pic
                .Parent = Experiences_Grd
                .Image = My.Resources.calendrier
                .Location = pt
                .Visible = True
            End With
        End If

    End Sub

    Private Sub Experiences_Grd_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Experiences_Grd.CellMouseLeave, Famille_Grd.CellMouseLeave
        With pic
            .Visible = False
        End With
    End Sub

    Private Sub Experiences_Grd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Experiences_Grd.DoubleClick
        If Experiences_Grd.CurrentRow Is Nothing Then Exit Sub

        Dim r As Integer = Experiences_Grd.CurrentRow.Index
        Dim c As Integer = Experiences_Grd.CurrentCell.ColumnIndex
        Select Case Experiences_Grd.CurrentCell.ColumnIndex
            Case Experiences_Grd.Columns.IndexOf(Dat_Deb), Experiences_Grd.Columns.IndexOf(Dat_Fin)
                Appel_Calender(Experiences_Grd.CurrentCell, Me)
        End Select


    End Sub

    Private Sub Famille_Grd_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Famille_Grd.CellMouseEnter
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = Dat_Naissance.Index Then
            Dim pt As New Point
            pt.X = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.X + sender.Item(e.ColumnIndex, e.RowIndex).Size.Width - pic.Width
            pt.Y = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.Y
            With pic
                .Parent = Famille_Grd
                .Image = My.Resources.calendrier
                .Location = pt
                .Visible = True
            End With
        End If
    End Sub

    Private Sub Famille_Grd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Famille_Grd.DoubleClick
        If Famille_Grd.CurrentRow Is Nothing Then Exit Sub

        Dim r As Integer = Famille_Grd.CurrentRow.Index
        Dim c As Integer = Famille_Grd.CurrentCell.ColumnIndex
        Select Case Famille_Grd.CurrentCell.ColumnIndex
            Case Famille_Grd.Columns.IndexOf(Dat_Naissance)
                Appel_Calender(Famille_Grd.CurrentCell, Me)
        End Select
    End Sub

    Private Sub PaieContractuel_Grd_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EB_Grd.CellMouseEnter
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = Cod_Rubrique.Index Then
            Dim pt As New Point
            pt.X = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.X + sender.Item(e.ColumnIndex, e.RowIndex).Size.Width - pic.Width
            pt.Y = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.Y
            With pic
                .Parent = EB_Grd
                .Image = My.Resources.MenuLocal
                .Location = pt
                .Visible = True
            End With
        End If
    End Sub

    Private Sub PaieContractuel_Grd_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EB_Grd.CellMouseLeave
        With pic
            .Visible = False
        End With
    End Sub

    Private Sub PaieContractuel_Grd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles EB_Grd.CellValidating
        If EB_Grd.CurrentCell.ColumnIndex <> Valeur.Index Then Exit Sub
        With EB_Grd
            Select Case .Item(Typ_Param.Index, .CurrentRow.Index).Value
                Case "float"
                    If Not IsNumeric(e.FormattedValue.ToString.Replace(".", ",")) Then e.Cancel = True
                    .Item(Typ_Param.Index, .CurrentRow.Index).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "int"
                    If IsNumeric(e.FormattedValue) Then
                        If Math.Floor(CDbl(e.FormattedValue)) <> CDbl(e.FormattedValue) Then
                            e.Cancel = True
                        End If
                    End If
                    .Item(Typ_Param.Index, .CurrentRow.Index).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "smalldatetime"
                    If Not EstDate(e.FormattedValue) Then e.Cancel = True
                    .Item(Typ_Param.Index, .CurrentRow.Index).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "bit"
                    If e.FormattedValue <> "1" And e.FormattedValue <> "0" Then e.Cancel = True
                Case Else
                    e.Cancel = False
                    .Item(Typ_Param.Index, .CurrentRow.Index).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End Select
        End With

    End Sub
    Private Sub PaieContractuel_Grd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EB_Grd.DoubleClick
        If EB_Grd.CurrentRow Is Nothing Then Exit Sub
        With EB_Grd
            Dim r As Integer = .CurrentRow.Index
            Dim c As Integer = .CurrentCell.ColumnIndex
            Select Case .CurrentCell.ColumnIndex
                Case Cod_Rubrique.Index
                    Appel_Zoom1("MS009", .Item(c, r), Me, "(isnull(EB,0)=1 or isnull(EX,0)=1)")
                    .Item(Typ_Param.Index, r).Value = FindLibelle("Typ_Retour", "Cod_Rubrique", .Item(c, r).Value, "RH_Paie_Rubrique")
                    .Item(Lib_Rubrique.Index, r).Value = FindLibelle("Lib_Rubrique", "Cod_Rubrique", .Item(c, r).Value, "RH_Paie_Rubrique")
                    .CurrentCell = .Item(Valeur.Index, r)
                    .BeginEdit(True)
            End Select
        End With
    End Sub
    Private Sub Entite__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Entite_.LinkClicked
        Appel_Zoom1("MS010", Cod_Entite_txt, Me)
    End Sub
    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub
    Private Sub Grade__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Grade_.LinkClicked
        Appel_Zoom1("MS015", Grade_Text, Me)
    End Sub
    Private Sub Grade_Text_TextChanged(sender As Object, e As EventArgs) Handles Grade_Text.TextChanged
        Lib_Grade_Text.Text = FindLibelle("Lib_Grade", "Cod_Grade", Grade_Text.Text, "Org_Grade")
    End Sub
    Private Sub Poste__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Poste_.LinkClicked
        Appel_Zoom1("MS016", Poste_Text, Me, IIf(Grade_Text.Text = "", "", "Cod_Grade='" & Grade_Text.Text & "'"))
    End Sub
    Private Sub Poste_Text_TextChanged(sender As Object, e As EventArgs) Handles Poste_Text.TextChanged
        Lib_Poste_Text.Text = FindLibelle("Lib_Poste", "Cod_Poste", Poste_Text.Text, "Org_Poste")
    End Sub
    Private Sub Conge_Annuel_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Conge_Annuel_txt.KeyPress, Acquis_Anciennete_txt.KeyPress, Droit_Conge_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub
#Region "BlockNote"
    Private Sub BlocNote_Grd_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles BlocNote_Grd.CellPainting
        With BlocNote_Grd
            If e.ColumnIndex <> .Columns("Valeur_Donnee").Index Or e.RowIndex < 0 Then Exit Sub
            Dim oX, oY As Integer
            oX = e.CellBounds.Location.X + e.CellBounds.Width - 16
            oY = (e.RowIndex + 1) * e.CellBounds.Height

            If IsNull(.Item("Typ_Donnee", e.RowIndex).Value, "") = "Dat" Then
                e.Graphics.DrawImage(My.Resources.calendrier, oX, oY)
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = True
                .Item("Valeur_Donnee", e.RowIndex).ReadOnly = True
                .Item("Valeur_Donnee", e.RowIndex).Style.Alignment = DataGridViewContentAlignment.TopLeft
            ElseIf IsNull(.Item("Typ_Donnee", e.RowIndex).Value, "") = "Mnu" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = True
                .Item("Valeur_Donnee", e.RowIndex).ReadOnly = True
                .Item("Valeur_Donnee", e.RowIndex).Style.Alignment = DataGridViewContentAlignment.TopLeft
            ElseIf IsNull(.Item("Typ_Donnee", e.RowIndex).Value, "") = "Rub" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = True
                .Item("Valeur_Donnee", e.RowIndex).ReadOnly = True
                .Item("Valeur_Donnee", e.RowIndex).Style.Alignment = DataGridViewContentAlignment.TopLeft
            ElseIf IsNull(.Item("Typ_Donnee", e.RowIndex).Value, "") = "File" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = True
            ElseIf IsNull(.Item("Typ_Donnee", e.RowIndex).Value, "") = "Boolean" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = True
            ElseIf IsNull(.Item("Typ_Donnee", e.RowIndex).Value, "") = "Path" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = True
            ElseIf IsNull(.Item("Typ_Donnee", e.RowIndex).Value, "") = "Ser" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = True
            ElseIf .Item("Typ_Donnee", e.RowIndex).Value = "Num" Then
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = False
                .Item("Valeur_Donnee", e.RowIndex).Style.Alignment = DataGridViewContentAlignment.TopRight
                .Item("Valeur_Donnee", e.RowIndex).Value = FormatNumber(IsNull(.Item("Valeur_Donnee", e.RowIndex).Value, "0"), 3)
            ElseIf .Item("Typ_Donnee", e.RowIndex).Value = "Ent" Then
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = False
                .Item("Valeur_Donnee", e.RowIndex).Style.Alignment = DataGridViewContentAlignment.TopRight
                .Item("Valeur_Donnee", e.RowIndex).Value = FormatNumber(IsNull(.Item("Valeur_Donnee", e.RowIndex).Value, "0"), 0)
            Else
                .Item("Valeur_Donnee", e.RowIndex).Style.Alignment = DataGridViewContentAlignment.TopLeft
                .Item(.Columns("Valeur_Donnee").Index, e.RowIndex).ReadOnly = False
            End If
        End With
    End Sub
    Private Sub BlocNote_Grd_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles BlocNote_Grd.EditingControlShowing
        Dim GrdX As ud_Grd = sender
        With GrdX
            e.Control.Tag = GrdX
            If .CurrentCell.ColumnIndex = .Columns("Valeur_Donnee").Index Then
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim GrdX As ud_Grd = CType(sender, DataGridViewTextBoxEditingControl).Tag
        With GrdX
            If .Item("Typ_Donnee", .CurrentCell.RowIndex).Value = "Num" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, False, False, False, False)
            ElseIf .Item("Typ_Donnee", .CurrentCell.RowIndex).Value = "Ent" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, True, False, False, False)
            End If

        End With
    End Sub
    Private Sub BlocNote_Grd_DoubleClick(sender As Object, e As EventArgs) Handles BlocNote_Grd.DoubleClick
        With BlocNote_Grd
            Dim r, c As Integer
            r = .CurrentRow.Index
            c = .CurrentCell.ColumnIndex
            If c <> .Columns("Valeur_Donnee").Index Or r < 0 Then Exit Sub
            If IsNull(.Item("Typ_Donnee", .CurrentCell.RowIndex).Value, "") = "Dat" Then
                Appel_Calender(.CurrentCell, .FindForm)
            ElseIf IsNull(.Item("Typ_Donnee", .CurrentCell.RowIndex).Value, "") = "Mnu" Then
                Appel_Zoom1(.Item("Menu_Donnee", .CurrentCell.RowIndex).Value, .CurrentCell, .FindForm)
            ElseIf IsNull(.Item("Typ_Donnee", .CurrentCell.RowIndex).Value, "") = "Rub" Then
                Appel_Zoom("Valeur", "Membre", "Param_Rubriques", "Nom_Controle='" & .Item("Menu_Donnee", .CurrentCell.RowIndex).Value & "'", .CurrentCell, .FindForm)
            ElseIf IsNull(.Item("Typ_Donnee", .CurrentCell.RowIndex).Value, "") = "Boolean" Then
                Appel_Zoom_Boolean(.CurrentCell, .FindForm, .Item("Menu_Donnee", .CurrentCell.RowIndex).Value)
            ElseIf IsNull(.Item("Typ_Donnee", .CurrentCell.RowIndex).Value, "") = "File" Then
                Dim OpenFileDialog As New OpenFileDialog
                OpenFileDialog.InitialDirectory = importPath
                OpenFileDialog.AutoUpgradeEnabled = False
                OpenFileDialog.Filter = "Tous les fichiers (*.*)|*.*"
                If (OpenFileDialog.ShowDialog(.FindForm) = System.Windows.Forms.DialogResult.OK) Then
                    importPath = System.IO.Path.GetFullPath(OpenFileDialog.FileName)
                    Dim FileName As String = OpenFileDialog.FileName
                    .Item("Valeur", .CurrentRow.Index).Value = FileName
                End If
            ElseIf IsNull(.Item("Typ_Donnee", .CurrentCell.RowIndex).Value, "") = "Path" Then
                Dim oFolderBrowserDialog As New FolderBrowserDialog
                oFolderBrowserDialog.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                If (oFolderBrowserDialog.ShowDialog(.FindForm) = System.Windows.Forms.DialogResult.OK) Then
                    Dim Path As String = oFolderBrowserDialog.SelectedPath
                    .Item("Valeur", .CurrentRow.Index).Value = Path
                End If
            End If
        End With
    End Sub
    Sub RequestingBlocNotes()
        With BlocNote_Grd
            .Rows.Clear()
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With

        Dim C1, C2, C3, C4, C5 As Object
        Dim Cod_Sql As String = "select Cod_Donnee,Text_Donnee, Valeur_Donnee as Valeur,Typ_Donnee,Menu_Donnee 
                                from RH_Agent_Donnees_Diverses_Parametrage  p
                                outer apply (select top 1  Valeur_Donnee from RH_Agent_Donnees_Diverses 
                                where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_Text.Text & "' 
                                and Cod_Donnee=p.Cod_Donnee) d where id_Societe=" & Societe.id_Societe & " 
                                order by Rang "
        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Cod_Donnee"), "")
                C2 = IsNull(.Rows(i).Item("Text_Donnee"), "")
                C3 = IsNull(.Rows(i).Item("Valeur"), "")
                C4 = IsNull(.Rows(i).Item("Typ_Donnee"), "")
                C5 = IsNull(.Rows(i).Item("Menu_Donnee"), "")
                BlocNote_Grd.Rows.Add(C1, C2, C3, C4, C5)
            Next
        End With
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Rubrique("Affectation_1", Affectation_1_txt, Me)
    End Sub
    Private Sub LinkLabel2_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Rubrique("Affectation_2", Affectation_2_txt, Me)
    End Sub

    Private Sub Affectation_1_txt_TextChanged(sender As Object, e As EventArgs) Handles Affectation_1_txt.TextChanged
        Lib_Affectation_1_txt.Text = FindRubriques("Affectation_1", Affectation_1_txt.Text)
    End Sub

    Private Sub Affectation_2_txt_TextChanged(sender As Object, e As EventArgs) Handles Affectation_2_txt.TextChanged
        Lib_Affectation_2_txt.Text = FindRubriques("Affectation_2", Affectation_2_txt.Text)
    End Sub

    Private Sub Recalcul_btn_Click(sender As Object, e As EventArgs) Handles Calcul_btn.Click
        CnExecuting("exec Sys_Conge_MajConge " & Societe.id_Societe)
        request()
    End Sub

    Sub SavingNotes()
        Dim rs As New ADODB.Recordset
        With BlocNote_Grd
            For i = 0 To .RowCount - 1
                If IsNull(.Item("Cod_Donnee", i).Value, "") <> "" Then
                    rs.Open("select * from RH_Agent_Donnees_Diverses where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_Text.Text & "' and Cod_Donnee='" & .Item("Cod_Donnee", i).Value & "'", cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Matricule").Value = Matricule_Text.Text
                        rs("Cod_Donnee").Value = .Item("Cod_Donnee", i).Value
                        rs("Text_Donnee").Value = .Item("Text_Donnee", i).Value
                    Else
                        rs.Update()
                    End If
                    Select Case .Item("Typ_Donnee", i).Value
                        Case "Num"
                            If Not IsNumeric(.Item("Valeur_Donnee", i).Value) Then .Item("Valeur_Donnee", i).Value = 0
                            rs("Valeur_Donnee").Value = CDbl(.Item("Valeur_Donnee", i).Value)
                        Case "Ent"
                            If Not IsNumeric(.Item("Valeur_Donnee", i).Value) Then .Item("Valeur_Donnee", i).Value = 0
                            rs("Valeur_Donnee").Value = Math.Floor(CDbl(.Item("Valeur_Donnee", i).Value))
                        Case Else
                            rs("Valeur_Donnee").Value = .Item("Valeur_Donnee", i).Value
                    End Select
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With
    End Sub

    Private Sub Droit_Conge_Mensuel_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Droit_Conge_Mensuel_txt.KeyPress, Reliquat_Anterieurs_txt.KeyPress
        ControleSaisie(sender, e, True, False, False, False, False)
    End Sub

    Sub Importer()
        Dim f As New RH_Agent_Import
        newShowEcran(f)
        If Matricule_Text.Text = "" Then
            Dim rs As ADODB.Recordset = CnExecuting("select Top 1 * from Rh_Agent where id_Societe = " & Societe.id_Societe)
            If Not rs.EOF Then
                Matricule_Text.Text = rs("Matricule").Value
            End If
        End If
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
            .canRate = canRate
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
        If Poste_Text.Text = "" Then Return
        Dim CompetencesPoste As String = CnExecuting("select isnull((select top 1 Domaines_Competence from Org_Poste where Cod_Poste='" & Poste_Text.Text & "' and id_Societe='" & Societe.id_Societe & "'),'')").Fields(0).Value
        If CompetencesPoste = "" Then Return
        Dim laListe = IsNull(Domaines_Competence_Pnl.Text, "").Split(";").ToList().Select(Function(x) x.Split("$")(0))
        Dim _pstComp = CompetencesPoste.Split(";").ToList().Select(Function(x) x.Split("$")(0)).Where(Function(y) Not laListe.Contains(y))
        If _pstComp.Count > 0 Then
            For Each c In _pstComp
                If Not String.IsNullOrWhiteSpace(c) Then
                    If Domaines_Competence_Pnl.Controls.Find(c, True).Length = 0 Then
                        AddCompetence(c & "$1")
                    End If
                End If
            Next
            RearrangeControls()
        End If
    End Sub
End Class