Public Class RH_Sante_Maladie_Pro
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn

    Sub Chargement()
        If Save_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
        End If
        If Statut_Declaration_cbo.Items.Count = 0 Then Statut_Declaration_cbo.fromRubrique("Statut_Declaration_MP")
    End Sub

    Private Sub RH_Sante_Maladie_Pro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("CLINIQUE", Me.Name) Then
            ShowMessageBox("Accès réservé au service médical.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Declaration_txt.Text) Then Dat_Declaration_txt.Text = Now.ToShortDateString
    End Sub

    Sub Request()
        Chargement()
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT * FROM RH_Sante_Maladie_Pro where Num_MP='" & Num_MP_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        With Tbl
            If .Rows.Count > 0 Then
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                Dat_Declaration_txt.Text = IsNull(.Rows(0)("Dat_Declaration"), "")
                Dat_Premier_Constat_txt.Text = IsNull(.Rows(0)("Dat_Premier_Constat"), "")
                Pathologie_txt.Text = IsNull(.Rows(0)("Pathologie"), "")
                Tableau_MP_txt.Text = IsNull(.Rows(0)("Tableau_MP"), "")
                Organisme_txt.Text = IsNull(.Rows(0)("Organisme"), "")
                Num_Dossier_Org_txt.Text = IsNull(.Rows(0)("Num_Dossier_Org"), "")
                Statut_Declaration_cbo.SelectedValue = IsNull(.Rows(0)("Statut_Declaration"), "")
                Commentaire_txt.Text = IsNull(.Rows(0)("Commentaire"), "")
                Sante_Audit("LECT", "RH_Sante_Maladie_Pro", Num_MP_txt.Text, Matricule_txt.Text)
            End If
        End With
    End Sub

    Sub Enregistrer()
        If Matricule_txt.Text = "" Then
            ShowMessageBox("Matricule non renseigné", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Pathologie_txt.Text.Trim = "" Then
            ShowMessageBox("Pathologie non renseignée", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Sante_VerrouCndp() Then
            Sante_Audit("AUTH_KO", "RH_Sante_Maladie_Pro", Num_MP_txt.Text, Matricule_txt.Text, False, "Verrou CNDP actif")
            ShowMessageBox("Traitement bloqué : autorisation CNDP non renseignée (paramètres)", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim numMP As String = Num_MP_txt.Text
        Dim estCreation As Boolean = (numMP = "")
        If estCreation Then numMP = Sante_NouveauNumero("MP", "RH_Sante_Maladie_Pro", "Num_MP", "Dat_Declaration")

        Dim ok As Boolean
        If estCreation Then
            ok = Sante_Execute(
                "insert into RH_Sante_Maladie_Pro (Num_MP, id_Societe, Matricule, Dat_Declaration, Dat_Premier_Constat, Pathologie, Tableau_MP, Organisme, Num_Dossier_Org, Statut_Declaration, Commentaire, Statut, Dat_Crea, Created_By) " &
                "values (?,?,?,?,?,?,?,?,?,?,?,'',getdate(),?)",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, numMP},
                 {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
                 {"p4", ADODB.DataTypeEnum.adDate, 0, CDate(Dat_Declaration_txt.Text)},
                 {"p5", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Premier_Constat_txt.Text), CDate(Dat_Premier_Constat_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p6", ADODB.DataTypeEnum.adVarWChar, 250, Pathologie_txt.Text},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 50, Tableau_MP_txt.Text},
                 {"p8", ADODB.DataTypeEnum.adVarWChar, 100, Organisme_txt.Text},
                 {"p9", ADODB.DataTypeEnum.adVarWChar, 50, Num_Dossier_Org_txt.Text},
                 {"p10", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_Declaration_cbo.SelectedValue, "")},
                 {"p11", ADODB.DataTypeEnum.adVarWChar, 500, Commentaire_txt.Text},
                 {"p12", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}})
        Else
            ok = Sante_Execute(
                "update RH_Sante_Maladie_Pro set Dat_Declaration=?, Dat_Premier_Constat=?, Pathologie=?, Tableau_MP=?, Organisme=?, Num_Dossier_Org=?, Statut_Declaration=?, Commentaire=?, Dat_Modif=getdate(), Modified_By=? " &
                "where Num_MP=? and id_Societe=?",
                {{"p1", ADODB.DataTypeEnum.adDate, 0, CDate(Dat_Declaration_txt.Text)},
                 {"p2", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Premier_Constat_txt.Text), CDate(Dat_Premier_Constat_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 250, Pathologie_txt.Text},
                 {"p4", ADODB.DataTypeEnum.adVarWChar, 50, Tableau_MP_txt.Text},
                 {"p5", ADODB.DataTypeEnum.adVarWChar, 100, Organisme_txt.Text},
                 {"p6", ADODB.DataTypeEnum.adVarWChar, 50, Num_Dossier_Org_txt.Text},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_Declaration_cbo.SelectedValue, "")},
                 {"p8", ADODB.DataTypeEnum.adVarWChar, 500, Commentaire_txt.Text},
                 {"p9", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                 {"p10", ADODB.DataTypeEnum.adVarWChar, 20, numMP},
                 {"p11", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}})
        End If
        If ok Then
            Sante_Audit(IIf(estCreation, "CREA", "MODI"), "RH_Sante_Maladie_Pro", numMP, Matricule_txt.Text)
            ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
            If Num_MP_txt.Text = "" Then Num_MP_txt.Text = numMP Else Request()
        End If
    End Sub

    Sub Deleting()
        If ShowMessageBox("Supprimer cette déclaration de maladie professionnelle ?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('RH_Sante_Maladie_Pro','Num_MP','" & Num_MP_txt.Text & "', " & IsNull(theUser.id_User, 0) & ", convert(nvarchar(20),getdate(),120))")
        CnExecuting("delete from RH_Sante_Maladie_Pro where Num_MP='" & Num_MP_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Sante_Audit("SUPP", "RH_Sante_Maladie_Pro", Num_MP_txt.Text, Matricule_txt.Text)
        Reset_Form(Me)
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        Dat_Declaration_txt.Text = Now.ToShortDateString
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS304", Num_MP_txt, Me)
    End Sub

    Private Sub Dat_Declaration_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Declaration_Link.LinkClicked
        Appel_Calender(Dat_Declaration_txt, Me)
    End Sub

    Private Sub Dat_Constat_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Constat_Link.LinkClicked
        Appel_Calender(Dat_Premier_Constat_txt, Me)
    End Sub

    Private Sub Num_MP_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_MP_txt.TextChanged
        Request()
    End Sub
End Class
