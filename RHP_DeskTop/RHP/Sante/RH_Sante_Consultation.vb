Public Class RH_Sante_Consultation
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
        If Typ_Acte_cbo.Items.Count = 0 Then Typ_Acte_cbo.fromRubrique("Typ_Acte_Infirmier")
        If Suite_cbo.Items.Count = 0 Then Suite_cbo.fromRubrique("Suite_Consultation")
    End Sub

    Private Sub RH_Sante_Consultation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("CLINIQUE", Me.Name) Then
            ShowMessageBox("Accès réservé au service médical.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Consultation_txt.Text) Then Dat_Consultation_txt.Text = Now.ToShortDateString
    End Sub

    Sub Request()
        Chargement()
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT * FROM RH_Sante_Consultation where Num_Consultation='" & Num_Consultation_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        With Tbl
            If .Rows.Count > 0 Then
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                Dat_Consultation_txt.Text = IsNull(.Rows(0)("Dat_Consultation"), "")
                Cod_Intervenant_txt.Text = IsNull(.Rows(0)("Cod_Intervenant"), "")
                Typ_Acte_cbo.SelectedValue = IsNull(.Rows(0)("Typ_Acte"), "")
                Motif_txt.Text = IsNull(.Rows(0)("Motif"), "")
                Observations_txt.Text = IsNull(.Rows(0)("Observations"), "")
                Suite_cbo.SelectedValue = IsNull(.Rows(0)("Suite"), "")
                Num_Declaration_AT_txt.Text = IsNull(.Rows(0)("Num_Declaration_AT"), "")
                Sante_Audit("LECT", "RH_Sante_Consultation", Num_Consultation_txt.Text, Matricule_txt.Text)
            End If
        End With
    End Sub

    Sub Enregistrer()
        If Matricule_txt.Text = "" Then
            ShowMessageBox("Matricule non renseigné", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Not EstDate(Dat_Consultation_txt.Text) Then
            ShowMessageBox("Date de consultation invalide", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Sante_VerrouCndp() Then
            Sante_Audit("AUTH_KO", "RH_Sante_Consultation", Num_Consultation_txt.Text, Matricule_txt.Text, False, "Verrou CNDP actif")
            ShowMessageBox("Traitement bloqué : autorisation CNDP non renseignée (paramètres)", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim numCons As String = Num_Consultation_txt.Text
        Dim estCreation As Boolean = (numCons = "")
        If estCreation Then numCons = Sante_NouveauNumero("CS", "RH_Sante_Consultation", "Num_Consultation", "Dat_Consultation")

        Dim ok As Boolean
        If estCreation Then
            ok = Sante_Execute(
                "insert into RH_Sante_Consultation (Num_Consultation, id_Societe, Matricule, Dat_Consultation, Cod_Intervenant, Typ_Acte, Motif, Observations, Suite, Num_Declaration_AT, Statut, Dat_Crea, Created_By) " &
                "values (?,?,?,?,?,?,?,?,?,?,'',getdate(),?)",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, numCons},
                 {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
                 {"p4", ADODB.DataTypeEnum.adDate, 0, CDate(Dat_Consultation_txt.Text)},
                 {"p5", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Intervenant_txt.Text},
                 {"p6", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Typ_Acte_cbo.SelectedValue, "")},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 500, Motif_txt.Text},
                 {"p8", ADODB.DataTypeEnum.adLongVarWChar, -1, Observations_txt.Text},
                 {"p9", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Suite_cbo.SelectedValue, "")},
                 {"p10", ADODB.DataTypeEnum.adVarWChar, 20, Num_Declaration_AT_txt.Text},
                 {"p11", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}})
        Else
            ok = Sante_Execute(
                "update RH_Sante_Consultation set Dat_Consultation=?, Cod_Intervenant=?, Typ_Acte=?, Motif=?, Observations=?, Suite=?, Num_Declaration_AT=?, Dat_Modif=getdate(), Modified_By=? " &
                "where Num_Consultation=? and id_Societe=?",
                {{"p1", ADODB.DataTypeEnum.adDate, 0, CDate(Dat_Consultation_txt.Text)},
                 {"p2", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Intervenant_txt.Text},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Typ_Acte_cbo.SelectedValue, "")},
                 {"p4", ADODB.DataTypeEnum.adVarWChar, 500, Motif_txt.Text},
                 {"p5", ADODB.DataTypeEnum.adLongVarWChar, -1, Observations_txt.Text},
                 {"p6", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Suite_cbo.SelectedValue, "")},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 20, Num_Declaration_AT_txt.Text},
                 {"p8", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                 {"p9", ADODB.DataTypeEnum.adVarWChar, 20, numCons},
                 {"p10", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}})
        End If
        If ok Then
            Sante_Audit(IIf(estCreation, "CREA", "MODI"), "RH_Sante_Consultation", numCons, Matricule_txt.Text)
            ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
            If Num_Consultation_txt.Text = "" Then Num_Consultation_txt.Text = numCons Else Request()
        End If
    End Sub

    Sub Deleting()
        If ShowMessageBox("Supprimer cette consultation ?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('RH_Sante_Consultation','Num_Consultation','" & Num_Consultation_txt.Text & "', " & IsNull(theUser.id_User, 0) & ", convert(nvarchar(20),getdate(),120))")
        CnExecuting("delete from RH_Sante_Consultation where Num_Consultation='" & Num_Consultation_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Sante_Audit("SUPP", "RH_Sante_Consultation", Num_Consultation_txt.Text, Matricule_txt.Text)
        Reset_Form(Me)
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        Dat_Consultation_txt.Text = Now.ToShortDateString
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS302", Num_Consultation_txt, Me)
    End Sub

    Private Sub Dat_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Link.LinkClicked
        Appel_Calender(Dat_Consultation_txt, Me)
    End Sub

    Private Sub Intervenant_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Intervenant_Link.LinkClicked
        Appel_Zoom1("MS306", Cod_Intervenant_txt, Me)
    End Sub

    Private Sub Cod_Intervenant_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Intervenant_txt.TextChanged
        Nom_Intervenant_txt.Text = FindLibelle("Nom + ' ' + isnull(Prenom,'')", "Cod_Intervenant", Cod_Intervenant_txt.Text, "Param_Sante_Intervenant")
    End Sub

    Private Sub AT_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles AT_Link.LinkClicked
        Appel_Zoom1("AT010", Num_Declaration_AT_txt, Me)
    End Sub

    Private Sub Num_Consultation_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Consultation_txt.TextChanged
        Request()
    End Sub
End Class
