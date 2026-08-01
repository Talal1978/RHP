Public Class RH_Sante_Dossier
    Dim Code As String = ""
    Dim Save_D As ud_btn

    Sub Chargement()
        If Save_D Is Nothing AndAlso dictButtons.ContainsKey("Save_D") Then
            Save_D = dictButtons("Save_D")
        End If
        If Groupe_Sanguin_cbo.Items.Count = 0 Then Groupe_Sanguin_cbo.fromRubrique("Groupe_Sanguin")
        Grd_Visites.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Aptitudes.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Consultations.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Examens.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Vaccinations.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_MP.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_AT.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Private Sub RH_Sante_Dossier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("CLINIQUE", Me.Name) Then
            ShowMessageBox("Accès réservé au service médical.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
    End Sub

    Sub Request()
        Chargement()
        ' Entete agent
        Dim TblA As DataTable = DATA_READER_GRD(
            "select Nom_Agent + ' ' +Prenom_Agent as Nom, isnull(Cod_Poste,'') Cod_Poste, isnull(Cod_Entite,'') Cod_Entite, Dat_Naissance " &
            "from RH_Agent where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        If TblA.Rows.Count > 0 Then
            Nom_Agent_Text.Text = IsNull(TblA.Rows(0)("Nom"), "")
            Poste_txt.Text = FindLibelle("Lib_Poste", "Cod_Poste", IsNull(TblA.Rows(0)("Cod_Poste"), ""), "Org_Poste")
            Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", IsNull(TblA.Rows(0)("Cod_Entite"), ""), "Org_Entite")
            If IsDate(IsNull(TblA.Rows(0)("Dat_Naissance"), "")) Then
                Age_txt.Text = CInt(DateDiff(DateInterval.Year, CDate(TblA.Rows(0)("Dat_Naissance")), Now)).ToString() & " ans"
            Else
                Age_txt.Text = ""
            End If
        Else
            Nom_Agent_Text.Text = "" : Poste_txt.Text = "" : Entite_txt.Text = "" : Age_txt.Text = ""
        End If

        ' Dossier
        Dim Tbl As DataTable = DATA_READER_GRD(
            "select * from RH_Sante_Dossier where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count > 0 Then
            Groupe_Sanguin_cbo.SelectedValue = IsNull(Tbl.Rows(0)("Groupe_Sanguin"), "")
            Medecin_Traitant_txt.Text = IsNull(Tbl.Rows(0)("Medecin_Traitant"), "")
            Antecedents_txt.Text = IsNull(Tbl.Rows(0)("Antecedents"), "")
            Observations_txt.Text = IsNull(Tbl.Rows(0)("Observations"), "")
            Dat_Derniere_Visite_txt.Text = IsNull(Tbl.Rows(0)("Dat_Derniere_Visite"), "")
            Dat_Prochaine_Visite_txt.Text = IsNull(Tbl.Rows(0)("Dat_Prochaine_Visite"), "")
            Statut_Aptitude_txt.Text = FindRubriques("Statut_Aptitude", IsNull(Tbl.Rows(0)("Statut_Aptitude_Courant"), ""))
            Sante_Audit("LECT", "RH_Sante_Dossier", Matricule_txt.Text, Matricule_txt.Text)
        Else
            Groupe_Sanguin_cbo.SelectedIndex = -1
            Medecin_Traitant_txt.Text = "" : Antecedents_txt.Text = "" : Observations_txt.Text = ""
            Dat_Derniere_Visite_txt.Text = "" : Dat_Prochaine_Visite_txt.Text = "" : Statut_Aptitude_txt.Text = ""
        End If
        RequestGrilles()
    End Sub

    Sub RequestGrilles()
        If Matricule_txt.Text = "" Then Return
        Dim w As String = " Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Grd_Visites.DataSource = DATA_READER_GRD(
            "select Num_Visite as 'N° visite', Dat_Visite as 'Date', dbo.FindRubrique('Typ_Visite',Typ_Visite) as 'Type', " &
            "dbo.FindRubrique('Statut_Aptitude',Statut_Aptitude) as 'Aptitude', Dat_Prochaine_Visite as 'Prochaine visite', " &
            "dbo.FindRubrique('Statut_Signature',Statut) as Statut from RH_Sante_Visite where " & w & " order by Dat_Visite desc")
        Grd_Aptitudes.DataSource = DATA_READER_GRD(
            "select Num_Aptitude as 'N° fiche', Dat_Aptitude as 'Date', dbo.FindRubrique('Statut_Aptitude',Statut_Aptitude) as 'Aptitude', " &
            "Version, Dat_Effet as 'Effet', Dat_Fin as 'Fin validité', dbo.FindRubrique('Statut_Signature',Statut) as Statut " &
            "from RH_Sante_Aptitude where " & w & " order by Dat_Aptitude desc")
        Grd_Consultations.DataSource = DATA_READER_GRD(
            "select Num_Consultation as 'N°', Dat_Consultation as 'Date', dbo.FindRubrique('Typ_Acte_Infirmier',Typ_Acte) as 'Acte', " &
            "dbo.FindRubrique('Suite_Consultation',Suite) as 'Suite' from RH_Sante_Consultation where " & w & " order by Dat_Consultation desc")
        Grd_Examens.DataSource = DATA_READER_GRD(
            "select Num_Examen as 'N° examen', dbo.FindRubrique('Typ_Examen',Typ_Examen) as 'Examen', Dat_Examen as 'Date', " &
            "dbo.FindRubrique('Statut_Examen',Statut_Examen) as 'Statut', Dat_Resultat as 'Résultat le' " &
            "from RH_Sante_Examen where " & w & " order by Dat_Examen desc")
        Grd_Vaccinations.DataSource = DATA_READER_GRD(
            "select dbo.FindRubrique('Typ_Vaccin',Typ_Vaccin) as 'Vaccin', Dat_Vaccination as 'Date', Dat_Rappel as 'Rappel' " &
            "from RH_Sante_Vaccination where " & w & " order by Dat_Vaccination desc")
        Grd_MP.DataSource = DATA_READER_GRD(
            "select Num_MP as 'N° MP', Dat_Declaration as 'Déclarée le', Pathologie, " &
            "dbo.FindRubrique('Statut_Declaration_MP',Statut_Declaration) as 'Statut' from RH_Sante_Maladie_Pro where " & w & " order by Dat_Declaration desc")
        Grd_AT.DataSource = DATA_READER_GRD(
            "select Num_Declaration as 'N° déclaration', Dat_Accident as 'Date accident', isnull(Typ_Accident,'TRAVAIL') as 'Type', " &
            "Statut, case when isnull(Cloture,'false')='true' then 'Clôturé' else '' end as 'Clôture' " &
            "from RH_Declaration_AT where " & w & " order by Dat_Accident desc")
    End Sub

    Sub Enregistrer()
        If Matricule_txt.Text = "" Then
            ShowMessageBox("Matricule non renseigné", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Sante_VerrouCndp() Then
            Sante_Audit("AUTH_KO", "RH_Sante_Dossier", Matricule_txt.Text, Matricule_txt.Text, False, "Verrou CNDP actif")
            ShowMessageBox("Traitement bloqué : autorisation CNDP non renseignée (paramètres)", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim ok = Sante_Execute(
            "if exists(select Matricule from RH_Sante_Dossier where Matricule=? and id_Societe=?) " &
            "update RH_Sante_Dossier set Groupe_Sanguin=?, Medecin_Traitant=?, Antecedents=?, Observations=?, Dat_Modif=getdate(), Modified_By=? " &
            "where Matricule=? and id_Societe=? " &
            "else insert into RH_Sante_Dossier (Matricule, id_Societe, Groupe_Sanguin, Medecin_Traitant, Antecedents, Observations, Archive, Dat_Crea, Created_By) " &
            "values (?, ?, ?, ?, ?, ?, 0, getdate(), ?)",
            {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
             {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
             {"p3", ADODB.DataTypeEnum.adVarWChar, 5, IsNull(Groupe_Sanguin_cbo.SelectedValue, "")},
             {"p4", ADODB.DataTypeEnum.adVarWChar, 100, Medecin_Traitant_txt.Text},
             {"p5", ADODB.DataTypeEnum.adLongVarWChar, -1, Antecedents_txt.Text},
             {"p6", ADODB.DataTypeEnum.adLongVarWChar, -1, Observations_txt.Text},
             {"p7", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
             {"p8", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
             {"p9", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
             {"p10", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
             {"p11", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
             {"p12", ADODB.DataTypeEnum.adVarWChar, 5, IsNull(Groupe_Sanguin_cbo.SelectedValue, "")},
             {"p13", ADODB.DataTypeEnum.adVarWChar, 100, Medecin_Traitant_txt.Text},
             {"p14", ADODB.DataTypeEnum.adLongVarWChar, -1, Antecedents_txt.Text},
             {"p15", ADODB.DataTypeEnum.adLongVarWChar, -1, Observations_txt.Text},
             {"p16", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}})
        If ok Then
            Sante_Audit("MODI", "RH_Sante_Dossier", Matricule_txt.Text, Matricule_txt.Text)
            ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
        End If
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Request()
    End Sub

    Private Sub Grd_Visites_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Visites.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        Dim f As New RH_Sante_Visite
        With f
            .Matricule_txt.Text = Matricule_txt.Text
            .Num_Visite_txt.Text = IsNull(Grd_Visites.Item("N° visite", e.RowIndex).Value, "")
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Grd_Aptitudes_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Aptitudes.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        Dim f As New RH_Sante_Aptitude
        With f
            .Matricule_txt.Text = Matricule_txt.Text
            .Num_Aptitude_txt.Text = IsNull(Grd_Aptitudes.Item("N° fiche", e.RowIndex).Value, "")
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Grd_Consultations_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Consultations.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        Dim f As New RH_Sante_Consultation
        With f
            .Matricule_txt.Text = Matricule_txt.Text
            .Num_Consultation_txt.Text = IsNull(Grd_Consultations.Item("N°", e.RowIndex).Value, "")
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Grd_Examens_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Examens.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        Dim f As New RH_Sante_Examen
        With f
            .Matricule_txt.Text = Matricule_txt.Text
            .Num_Examen_txt.Text = IsNull(Grd_Examens.Item("N° examen", e.RowIndex).Value, "")
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Grd_MP_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_MP.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        Dim f As New RH_Sante_Maladie_Pro
        With f
            .Matricule_txt.Text = Matricule_txt.Text
            .Num_MP_txt.Text = IsNull(Grd_MP.Item("N° MP", e.RowIndex).Value, "")
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Grd_AT_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_AT.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        Dim f As New RH_Declaration_AT
        With f
            .Matricule_txt.Text = Matricule_txt.Text
            .Num_Declaration_txt.Text = IsNull(Grd_AT.Item("N° déclaration", e.RowIndex).Value, "")
            newShowEcran(f, True)
        End With
    End Sub
End Class
