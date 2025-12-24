Public Class CVTheque
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
        End If
        If Civilite_Combo.Items.Count = 0 Then Civilite_Combo.fromRubrique()
        If Situation.Items.Count = 0 Then Situation.fromRubrique()
        If Typ_Agent.Items.Count = 0 Then Typ_Agent.fromRubrique()
        If Typ_Contrat.Items.Count = 0 Then Typ_Contrat.fromRubrique()
        If Typ_Periode.Items.Count = 0 Then Typ_Periode.fromRubrique()
        If Statut_Candidature.Items.Count = 0 Then Statut_Candidature.fromRubrique()
        If Canal_Candidature.Items.Count = 0 Then Canal_Candidature.fromRubrique()
        If Statut_Actuel.Items.Count = 0 Then Statut_Actuel.fromRubrique()
        If Cod_Pays_Text.Text = "" Then Cod_Pays_Text.Text = FindParam("Cod_Pays")
        If Nationalite_Text.Text = "" Then Nationalite_Text.Text = Cod_Pays_Text.Text
        If Niveau.Items.Count = 0 Then Combo_GRD(Niveau)

        If theUser.Typ_Role = "Agent" Then
            Save_D.Visible = False
            Del_D.Visible = False
            Next_D.Visible = False
            Back_D.Visible = False
            Last_D.Visible = False
            First_D.Visible = False
            New_D.Visible = False
            Parcours.Visible = Not Societe.Masquer_Element_Paie_Agent
            If Matricule_Text.Text = "" Then Matricule_Text.Text = theUser.Matricule
        End If
        Dim _rw = Tbl_Function_Security.Select("Function_Sec='GPECRating'")
        If _rw.Length > 0 Then
            canRate = (CBool(_rw(0)("Visible")) Or theUser.Cod_Profile = 1)
        End If
    End Sub
    Private Sub Matricule__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS161", Matricule_Text, Me)
    End Sub
    Sub request()
        Cod_Simulation = ""
        Chargement()
        Formations_GRD.Rows.Clear()
        Experiences_Grd.Rows.Clear()
        Domaines_Competence_Pnl.Controls.Clear()
        Domaines_Competence_Pnl.Text = ""
        Dim SqlStr As String = "Select * from CVtheque a
outer apply(select top 1 * from RH_Conge where Matricule=a.Matricule and id_Societe=a.id_Societe order by Annee desc)c
where a.Matricule='" & Matricule_Text.Text & "' and a.id_Societe=" & Societe.id_Societe
        CltTbl = DATA_READER_GRD(SqlStr)
        If CltTbl.Rows.Count > 0 Then
            Nom_Text.Text = IsNull(CltTbl.Rows(0).Item("Nom"), "")
            Prenom_Text.Text = IsNull(CltTbl.Rows(0).Item("Prenom"), "")
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
            Dat_Candidature_txt.Text = IsNull(CltTbl.Rows(0).Item("Dat_Candidature"), "")
            Dat_Fin_Contrat_Text.Text = IsNull(CltTbl.Rows(0).Item("Dat_Fin_Contrat"), "")
            Typ_Periode.SelectedValue = IsNull(CltTbl.Rows(0).Item("Typ_Periode"), "")
            Commentaire_Text.Text = IsNull(CltTbl.Rows(0).Item("Commentaire"), "")
            Titre_txt.Text = IsNull(CltTbl.Rows(0).Item("Titre"), "")
            Poste_Text.Text = IsNull(CltTbl.Rows(0).Item("Cod_Poste"), "")
            Grade_Text.Text = IsNull(CltTbl.Rows(0).Item("Cod_Grade"), "")
            Nbr_Personne_A_Charge.Value = IsNull(CltTbl.Rows(0).Item("Nbr_Personne_A_Charge"), 0)
            CNSS_Text.Text = IsNull(CltTbl.Rows(0).Item("CNSS"), "")
            Organisme1_Text.Text = IsNull(CltTbl.Rows(0).Item("Organisme1"), "")
            Organisme2_Text.Text = IsNull(CltTbl.Rows(0).Item("Organisme2"), "")
            Organisme3_Text.Text = IsNull(CltTbl.Rows(0).Item("Organisme3"), "")
            Organisme4_Text.Text = IsNull(CltTbl.Rows(0).Item("Organisme4"), "")
            Domaines_Competence_Pnl.Text = IsNull(CltTbl.Rows(0).Item("Domaines_Competence"), "")
            Droit_Conge_Mensuel_txt.Text = IsNull(CltTbl.Rows(0)("Droit_Conge_Mensuel"), 0)
            Canal_Candidature.SelectedValue = IsNull(CltTbl.Rows(0).Item("Canal_Candidature"), "")
            Statut_Candidature.SelectedValue = IsNull(CltTbl.Rows(0).Item("Statut_Candidature"), "")
            Statut_Actuel.SelectedValue = IsNull(CltTbl.Rows(0).Item("Statut_Actuel"), "")
            'Afficher la photo
            Dim ImageData As Object = CnExecuting("select Photo from CVtheque where Matricule='" & Matricule_Text.Text & "'  and id_Societe=" & Societe.id_Societe).Fields(0).Value
            PictureBox1.Image = AffichagePhoto(ImageData)

            'Afficher CV
            Dim C2, C3, C4, C5, C6, C7, C8, C9, C10 As Object
            Dim oTbl As DataTable = DATA_READER_GRD("select * from CVtheque_CV where Matricule='" & Matricule_Text.Text & "'  and id_Societe=" & Societe.id_Societe)
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
        Dim notExists = CnExecuting($"select count(*) from RH_Agent where id_Societe={Societe.id_Societe} and isnull(nullif(Ref_Candidature,''),'9784654654687687oijoijoi')='{Matricule_Text.Text}'").Fields(0).Value = 0
        Save_D.Enabled = notExists
        Del_D.Enabled = notExists
        hired_pb.Visible = Not notExists
    End Sub

    Private Sub CVtheque_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub CVtheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If Nom_Text.Text = "************" Then Exit Sub
            request()
            DroitAcces(Me, IIf(theUser.Typ_Role = "Agent", False, DroitModify_Fiche(Matricule_Text.Text, Me)))
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
        Try
            If CnExecuting("Select count(*) from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
                MessageBoxRHP(687)
                With Save_D
                    .Enabled = False
                    .Tag = ""
                End With
            End If
            Dim ErrStr As String = ""
            If Nom_Text.Text.Contains("**") Or Prenom_Text.Text.Contains("**") Then
                Return New savingResult With {.message = MessageBoxRHPText(669), .result = False}
            End If
            If LTrim(Nom_Text.Text) = "" Or LTrim(Prenom_Text.Text) = "" Then
                Return New savingResult With {.message = MessageBoxRHPText(671), .result = False}
            End If
            If Civilite_Combo.SelectedIndex = -1 Then
                ErrStr = "La civitlité n'a pas été renseignée pour ce candidat."
                Civilite_Combo.SelectedValue = "Mr"
            End If
            If Not EstDate(Dat_Naissance_Text.Text) Then
                ErrStr = "Date de naissance obligatoire."
                Return New savingResult With {.message = ErrStr, .result = False}
            End If
            If Canal_Candidature.SelectedIndex = -1 Then
                ErrStr = "Canal de récéption de la candidature non renseigné."
                Canal_Candidature.SelectedValue = "spontanne"
            End If
            If Statut_Actuel.SelectedIndex = -1 Then
                ErrStr = "Canal de récéption de la candidature non renseigné."
                Statut_Actuel.SelectedValue = "rechercheActive"
            End If
            If Statut_Candidature.SelectedIndex = -1 Then
                Statut_Candidature.SelectedValue = "Active"
            End If
            If LTrim(Cod_Plan_Paie_Text.Text) <> "" And LTrim(Lib_Plan_Paie_Text.Text) = "" Then
                Return New savingResult With {.message = "Plan de paie erroné.", .result = False}
            End If
            If Not estEmail(Mail_Text.Text) And Mail_Text.Text.Trim <> "" Then
                ErrStr = "Erreur format de mail, il sera supprimé."
                Mail_Text.Text = ""
            End If
            Domaines_Competence_Pnl.Text = ""
            For Each cnt As ud_Domaine_Competence In Domaines_Competence_Pnl.Controls
                Domaines_Competence_Pnl.Text &= If(String.IsNullOrWhiteSpace(Domaines_Competence_Pnl.Text), "", ";") & cnt.Name & "$" & cnt.Rating()
            Next
            Dim rs As New ADODB.Recordset
            Dim Dat As Date = Now.Date
            Dim CompteurAuto As Boolean = Societe.Compteur_Auto
            Dim Cod_Sql As String = "select * from CVtheque where Matricule='" & Matricule_Text.Text & "' and isnull(Matricule,'')<>''  and id_Societe=" & Societe.id_Societe
            rs.Open(Cod_Sql, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                CnExecuting("exec Sys_Compteur 'CV'," & Societe.id_Societe)
                Code = FindLibelle("Last_Code", "Fichier", "CV", "Param_Compteur")
                rs("Matricule").Value = Code
                rs("id_Societe").Value = Societe.id_Societe
                rs("Created_By").Value = theUser.Login
                rs("Dat_Crea").Value = Dat
            Else
                rs.Update()
                Code = Matricule_Text.Text
            End If
            rs("Nom").Value = Nom_Text.Text
            rs("Prenom").Value = Prenom_Text.Text
            rs("Sexe").Value = IIf(Civilite_Combo.SelectedValue = "Mr", "H", "F")
            rs("CIN_Agent").Value = CIN_Agent_Text.Text
            rs("NumCE").Value = NumCE_txt.Text
            rs("NumPPR").Value = NumPPR_txt.Text
            rs("Nationalite").Value = Nationalite_Text.Text
            rs("Civilite").Value = Civilite_Combo.SelectedValue
            rs("Adresse").Value = Adresse_Text.Text
            rs("Cod_Ville").Value = Cod_Ville_Text.Text.Substring(0, 5)
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
            rs("Dat_Entree").Value = If(EstDate(Dat_Entree_Text.Text), Dat_Entree_Text.Text, DBNull.Value)
            rs("Dat_Candidature").Value = If(Not EstDate(Dat_Candidature_txt.Text), Now.ToShortDateString, Dat_Candidature_txt.Text)
            rs("Canal_Candidature").Value = Canal_Candidature.SelectedValue
            rs("Statut_Candidature").Value = Statut_Candidature.SelectedValue
            rs("Statut_Actuel").Value = Statut_Actuel.SelectedValue
            rs("Typ_Periode").Value = Typ_Periode.SelectedValue
            rs("Commentaire").Value = Commentaire_Text.Text
            rs("Titre").Value = Titre_txt.Text
            rs("Cod_Poste").Value = Poste_Text.Text
            rs("Cod_Grade").Value = Grade_Text.Text
            rs("Nbr_Personne_A_Charge").Value = Nbr_Personne_A_Charge.Value
            rs("CNSS").Value = CNSS_Text.Text
            rs("Organisme1").Value = Organisme1_Text.Text
            rs("Organisme2").Value = Organisme2_Text.Text
            rs("Organisme3").Value = Organisme3_Text.Text
            rs("Organisme4").Value = Organisme4_Text.Text
            rs("Domaines_Competence").Value = Domaines_Competence_Pnl.Text
            rs("Droit_Conge_Mensuel").Value = Droit_Conge_Mensuel_txt.Text
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
            CnExecuting("delete from CVtheque_CV where Matricule='" & Code & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from CVtheque_CV", cn, 2, 2)
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

            Matricule_Text.Text = Code
            If ErrStr <> "" Then
                Return New savingResult With {.message = ErrStr, .result = True}
            Else
                Return New savingResult With {.message = "Enregistré avec succès", .result = True}
            End If
        Catch ex As Exception
            Return New savingResult With {.message = ex.Message, .result = False}
        End Try
    End Function
    Sub Nouveau()
        Reset_Form(Me, False)
        PictureBox1.Image = Nothing
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
        Dat_Candidature_txt.Text = Now.ToShortDateString
        Statut_Actuel.SelectedValue = "enPoste"
        Statut_Candidature.SelectedValue = "active"
        Canal_Candidature.SelectedValue = "spontanne"
        TabControl1.SelectedIndex = 0
        Nom_Text.Select()
        hired_pb.Visible = False
    End Sub
    Sub Div_First()
        If Matricule_Text.Text <> "" Then
            Diviseur_First("CVtheque", "Matricule", "Matricule", Matricule_Text)
        End If
    End Sub
    Sub Div_Back()
        If Matricule_Text.Text <> "" Then
            Diviseur_Back("CVtheque", "Matricule", "Matricule", Matricule_Text)
        End If
    End Sub
    Sub Div_Next()
        If Matricule_Text.Text <> "" Then
            Diviseur_Next("CVtheque", "Matricule", "Matricule", Matricule_Text)
        End If
    End Sub
    Sub Div_Last()
        If Matricule_Text.Text <> "" Then
            Diviseur_Last("CVtheque", "Matricule", "Matricule", Matricule_Text)
        End If
    End Sub
    Sub Deleting()
        If Matricule_Text.Text = "" Then Exit Sub
        If ShowMessageBox("Etes vous sûr de vouloir supprimer ce Matricule?" & Matricule_Text.Text, "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        Dim StrDel As String = String.Format("select 'RH_Simulation' as Tbl,count(*) Nb from RH_Simulation where Matricule='{0}'", Matricule_Text.Text)
        Dim TblDel As DataTable = DATA_READER_GRD(StrDel)
        Dim nrw() As DataRow = TblDel.Select("Nb>0")
        If nrw.Length > 0 Then
            ShowMessageBox("Ce matricule est utilisé dans la table : " & nrw(0)("Tbl"), "Suppression", MessageBoxButtons.OKCancel, msgIcon.Stop)
            Return
        End If
        CnExecuting("delete from CVTheque where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_Text.Text & "'")
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

    Private Sub Experiences_Grd_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Experiences_Grd.CellMouseLeave
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
    Private Sub PaieContractuel_Grd_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        With pic
            .Visible = False
        End With
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Calender(Dat_Candidature_txt, Me, Now)
    End Sub

    Private Sub Matricule_Text_Load(sender As Object, e As EventArgs) Handles Matricule_Text.Load

    End Sub
End Class