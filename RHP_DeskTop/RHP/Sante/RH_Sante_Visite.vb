Public Class RH_Sante_Visite
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Valide_D As ud_btn
    Dim statutDoc As String = ""
    Public ReadOnly Property AllowUploadInReadOnly As Boolean
        Get
            Return True
        End Get
    End Property

    Sub Chargement()
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Valide_D = dictButtons("Valide_D")
        End If
        If Typ_Visite_cbo.Items.Count = 0 Then Typ_Visite_cbo.fromRubrique("Typ_Visite")
        If Statut_Aptitude_cbo.Items.Count = 0 Then Statut_Aptitude_cbo.fromRubrique("Statut_Aptitude")
        Grd_Historique.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Private Sub RH_Sante_Visite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        ' Controle d'acces au domaine clinique (journalise si refus)
        If Not Sante_CheckAccess("CLINIQUE", Me.Name) Then
            ShowMessageBox("Accès réservé au service médical.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Visite_txt.Text) Then Dat_Visite_txt.Text = Now.ToShortDateString
    End Sub

    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        Dim canModify As Boolean = True
        statutDoc = ""
        Dim SqlStr As String = "SELECT * FROM RH_Sante_Visite where Num_Visite='" & Num_Visite_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        With Tbl
            If .Rows.Count > 0 Then
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                Dat_Visite_txt.Text = IsNull(.Rows(0)("Dat_Visite"), "")
                Typ_Visite_cbo.SelectedValue = IsNull(.Rows(0)("Typ_Visite"), "")
                Cod_Medecin_txt.Text = IsNull(.Rows(0)("Cod_Medecin"), "")
                Cod_Campagne_txt.Text = IsNull(.Rows(0)("Cod_Campagne"), "")
                Conclusion_txt.Text = IsNull(.Rows(0)("Conclusion"), "")
                Statut_Aptitude_cbo.SelectedValue = IsNull(.Rows(0)("Statut_Aptitude"), "")
                Reserves_txt.Text = IsNull(.Rows(0)("Reserves"), "")
                Restrictions_txt.Text = IsNull(.Rows(0)("Restrictions"), "")
                Dat_Prochaine_Visite_txt.Text = IsNull(.Rows(0)("Dat_Prochaine_Visite"), "")
                Motif_Ajustement_txt.Text = IsNull(.Rows(0)("Motif_Ajustement"), "")
                Num_Visite_Rectifiee_txt.Text = IsNull(.Rows(0)("Num_Visite_Rectifiee"), "")
                Motif_Rectification_txt.Text = IsNull(.Rows(0)("Motif_Rectification"), "")
                Cod_Regle_txt.Text = IsNull(.Rows(0)("Cod_Regle_Appliquee"), "")
                statutDoc = IsNull(.Rows(0)("Statut"), "")
                With pb_Valide
                    .Tag = ""
                    .Image = My.Resources.valide01
                    Select Case statutDoc
                        Case "VA"
                            .Visible = True
                        Case "SG"
                            .Image = My.Resources.valide01
                            .Tag = "SG"
                            .Visible = True
                        Case "RJ"
                            .Image = My.Resources.refuse
                            .Tag = "RJ"
                            .Visible = True
                    End Select
                End With
                If "VA;SG".Split(";").Contains(statutDoc) Then
                    canModify = False
                End If
                Sante_Audit("LECT", "RH_Sante_Visite", Num_Visite_txt.Text, Matricule_txt.Text)
            End If
        End With
        Verrouiller(Not canModify)
        Save_D.Enabled = canModify
        Del_D.Enabled = canModify
        Valide_D.Enabled = canModify
        RequestHistorique()
    End Sub

    Sub Verrouiller(verrou As Boolean)
        Matricule_.Enabled = Not verrou
        Dat_Visite_txt.ReadOnly = verrou
        Typ_Visite_cbo.Enabled = Not verrou
        Cod_Medecin_txt.ReadOnly = verrou
        Cod_Campagne_txt.ReadOnly = verrou
        Conclusion_txt.ReadOnly = verrou
        Statut_Aptitude_cbo.Enabled = Not verrou
        Reserves_txt.ReadOnly = verrou
        Restrictions_txt.ReadOnly = verrou
        Dat_Prochaine_Visite_txt.ReadOnly = verrou
        Motif_Ajustement_txt.ReadOnly = verrou
        Num_Visite_Rectifiee_txt.ReadOnly = verrou
        Motif_Rectification_txt.ReadOnly = verrou
        Recalcul_Btn.Enabled = Not verrou
    End Sub

    Sub RequestHistorique()
        If Matricule_txt.Text = "" Then Grd_Historique.DataSource = Nothing : Return
        Dim Cod_Sql As String =
            "select Num_Visite as 'N° visite', Dat_Visite as 'Date', dbo.FindRubrique('Typ_Visite',Typ_Visite) as 'Type', " &
            "dbo.FindRubrique('Statut_Aptitude',Statut_Aptitude) as 'Aptitude', Dat_Prochaine_Visite as 'Prochaine visite', " &
            "dbo.FindRubrique('Statut_Signature',Statut) as Statut, Num_Visite_Rectifiee as 'Rectifie' " &
            "from RH_Sante_Visite where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe &
            " order by Dat_Visite desc"
        Grd_Historique.DataSource = DATA_READER_GRD(Cod_Sql)
    End Sub

    Function Controles() As savingResult
        If Matricule_txt.Text = "" Then Return New savingResult With {.result = False, .message = "Matricule non renseigné"}
        If Not EstDate(Dat_Visite_txt.Text) Then Return New savingResult With {.result = False, .message = "Date de visite invalide"}
        If Typ_Visite_cbo.SelectedIndex < 0 Then Return New savingResult With {.result = False, .message = "Type de visite non renseigné"}
        If Num_Visite_Rectifiee_txt.Text <> "" And Motif_Rectification_txt.Text.Trim = "" Then
            Return New savingResult With {.result = False, .message = "Le motif de rectification est obligatoire"}
        End If
        Return New savingResult With {.result = True, .message = ""}
    End Function

    Function Saving(statut As String) As savingResult
        Dim ctl = Controles()
        If Not ctl.result Then Return ctl
        If Sante_VerrouCndp() Then
            Sante_Audit("AUTH_KO", "RH_Sante_Visite", Num_Visite_txt.Text, Matricule_txt.Text, False, "Verrou CNDP actif")
            Return New savingResult With {.result = False, .message = "Traitement bloqué : autorisation CNDP non renseignée (paramètres)"}
        End If

        Dim numVisite As String = Num_Visite_txt.Text
        Dim estCreation As Boolean = (numVisite = "")
        If estCreation Then
            numVisite = Sante_NouveauNumero("VM", "RH_Sante_Visite", "Num_Visite", "Dat_Visite")
        Else
            ' Une visite validee/signee n'est jamais modifiee
            Dim st = Sante_Scalar("select Statut from RH_Sante_Visite where Num_Visite=? and id_Societe=?",
                                  {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, numVisite},
                                   {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}})
            If "VA;SG".Split(";").Contains(IsNull(st, "")) Then
                Return New savingResult With {.result = False, .message = "Visite validée : toute correction doit passer par une visite de rectification"}
            End If
        End If

        ' Echeance : calcul automatique si absente ; ajustement manuel motive
        Dim datProchaine As Object = If(EstDate(Dat_Prochaine_Visite_txt.Text), CDate(Dat_Prochaine_Visite_txt.Text), DirectCast(DBNull.Value, Object))
        Dim codRegle As String = Cod_Regle_txt.Text
        If statut = "VA" Or statut = "SG" Then
            Dim calc As Object = Sante_CalculEcheance(Matricule_txt.Text, CDate(Dat_Visite_txt.Text), codRegle)
            If Not EstDate(Dat_Prochaine_Visite_txt.Text) Then
                datProchaine = If(calc Is Nothing, DirectCast(DBNull.Value, Object), calc)
            ElseIf calc IsNot Nothing AndAlso CDate(calc) <> CDate(Dat_Prochaine_Visite_txt.Text) Then
                If Motif_Ajustement_txt.Text.Trim = "" Then
                    Return New savingResult With {.result = False, .message = "L'ajustement de l'échéance calculée (" & CDate(calc).ToShortDateString & ") doit être justifié (motif)"}
                End If
            End If
        End If

        Dim ok As Boolean
        If estCreation Then
            ' Ordre : Num_Visite, id_Societe, Matricule, Dat_Visite, Typ_Visite, Cod_Medecin, Cod_Campagne,
            ' Conclusion, Statut_Aptitude, Reserves, Restrictions, Dat_Prochaine, Cod_Regle, Motif_Ajustement,
            ' Num_Visite_Rectifiee, Motif_Rectification, Statut, Created_By
            Dim pi As Object(,) = {
                {"p1", ADODB.DataTypeEnum.adVarWChar, 20, numVisite},
                {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                {"p3", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
                {"p4", ADODB.DataTypeEnum.adDate, 0, CDate(Dat_Visite_txt.Text)},
                {"p5", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Typ_Visite_cbo.SelectedValue, "")},
                {"p6", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Medecin_txt.Text},
                {"p7", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Campagne_txt.Text},
                {"p8", ADODB.DataTypeEnum.adLongVarWChar, -1, Conclusion_txt.Text},
                {"p9", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_Aptitude_cbo.SelectedValue, "")},
                {"p10", ADODB.DataTypeEnum.adVarWChar, 500, Reserves_txt.Text},
                {"p11", ADODB.DataTypeEnum.adVarWChar, 500, Restrictions_txt.Text},
                {"p12", ADODB.DataTypeEnum.adDate, 0, datProchaine},
                {"p13", ADODB.DataTypeEnum.adVarWChar, 20, codRegle},
                {"p14", ADODB.DataTypeEnum.adVarWChar, 250, Motif_Ajustement_txt.Text},
                {"p15", ADODB.DataTypeEnum.adVarWChar, 20, Num_Visite_Rectifiee_txt.Text},
                {"p16", ADODB.DataTypeEnum.adVarWChar, 250, Motif_Rectification_txt.Text},
                {"p17", ADODB.DataTypeEnum.adVarWChar, 3, statut},
                {"p18", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}}
            ok = Sante_Execute(
                "insert into RH_Sante_Visite (Num_Visite, id_Societe, Matricule, Dat_Visite, Typ_Visite, Cod_Medecin, Cod_Campagne, " &
                "Conclusion, Statut_Aptitude, Reserves, Restrictions, Dat_Prochaine_Visite, Cod_Regle_Appliquee, Motif_Ajustement, " &
                "Num_Visite_Rectifiee, Motif_Rectification, Statut, Dat_Crea, Created_By) " &
                "values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,getdate(),?)", pi)
        Else
            ' Ordre : Matricule, Dat_Visite, Typ_Visite, Cod_Medecin, Cod_Campagne, Conclusion, Statut_Aptitude,
            ' Reserves, Restrictions, Dat_Prochaine, Cod_Regle, Motif_Ajustement, Num_Visite_Rectifiee,
            ' Motif_Rectification, Statut, Modified_By, Num_Visite, id_Societe
            Dim pu As Object(,) = {
                {"p1", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
                {"p2", ADODB.DataTypeEnum.adDate, 0, CDate(Dat_Visite_txt.Text)},
                {"p3", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Typ_Visite_cbo.SelectedValue, "")},
                {"p4", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Medecin_txt.Text},
                {"p5", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Campagne_txt.Text},
                {"p6", ADODB.DataTypeEnum.adLongVarWChar, -1, Conclusion_txt.Text},
                {"p7", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_Aptitude_cbo.SelectedValue, "")},
                {"p8", ADODB.DataTypeEnum.adVarWChar, 500, Reserves_txt.Text},
                {"p9", ADODB.DataTypeEnum.adVarWChar, 500, Restrictions_txt.Text},
                {"p10", ADODB.DataTypeEnum.adDate, 0, datProchaine},
                {"p11", ADODB.DataTypeEnum.adVarWChar, 20, codRegle},
                {"p12", ADODB.DataTypeEnum.adVarWChar, 250, Motif_Ajustement_txt.Text},
                {"p13", ADODB.DataTypeEnum.adVarWChar, 20, Num_Visite_Rectifiee_txt.Text},
                {"p14", ADODB.DataTypeEnum.adVarWChar, 250, Motif_Rectification_txt.Text},
                {"p15", ADODB.DataTypeEnum.adVarWChar, 3, statut},
                {"p16", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                {"p17", ADODB.DataTypeEnum.adVarWChar, 20, numVisite},
                {"p18", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}}
            ok = Sante_Execute(
                "update RH_Sante_Visite set Matricule=?, Dat_Visite=?, Typ_Visite=?, Cod_Medecin=?, Cod_Campagne=?, " &
                "Conclusion=?, Statut_Aptitude=?, Reserves=?, Restrictions=?, Dat_Prochaine_Visite=?, Cod_Regle_Appliquee=?, " &
                "Motif_Ajustement=?, Num_Visite_Rectifiee=?, Motif_Rectification=?, Statut=?, Dat_Modif=getdate(), Modified_By=? " &
                "where Num_Visite=? and id_Societe=?", pu)
        End If
        If Not ok Then Return New savingResult With {.result = False, .message = "Erreur d'enregistrement"}

        If statut = "VA" Or statut = "SG" Then
            CnExecuting("exec Sys_Sante_Maj_Dossier '" & Matricule_txt.Text & "', " & Societe.id_Societe)
        End If
        Sante_Audit(IIf(estCreation, "CREA", "MODI"), "RH_Sante_Visite", numVisite, Matricule_txt.Text)
        If Num_Visite_txt.Text = "" Then Num_Visite_txt.Text = numVisite Else Request()
        Return New savingResult With {.result = True, .message = "Enregistré avec succès"}
    End Function

    Sub Enregistrer()
        Dim rsl As savingResult = Saving("")
        If IsNull(rsl.message, "") <> "" Then ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub

    Function Valider()
        If ShowMessageBox("Valider cette visite ? Elle deviendra historisée et ne sera plus modifiable.", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving("VA")
        If rs.result Then Request()
        If IsNull(rs.message, "") <> "" Then ShowMessageBox(rs.message, "Validation", MessageBoxButtons.OK, IIf(rs.result, msgIcon.Information, msgIcon.Stop))
        Return rs.result
    End Function

    Sub Deleting()
        If "VA;SG".Split(";").Contains(statutDoc) Then
            ShowMessageBox("Impossible de supprimer une visite validée.", "Stop", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ShowMessageBox("Supprimer cette visite ?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('RH_Sante_Visite','Num_Visite','" & Num_Visite_txt.Text & "', " & IsNull(theUser.id_User, 0) & ", convert(nvarchar(20),getdate(),120))")
        CnExecuting("delete from RH_Sante_Visite where Num_Visite='" & Num_Visite_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Sante_Audit("SUPP", "RH_Sante_Visite", Num_Visite_txt.Text, Matricule_txt.Text)
        Reset_Form(Me)
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        Verrouiller(False)
        Save_D.Enabled = True
        Del_D.Enabled = True
        Valide_D.Enabled = True
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        Dat_Visite_txt.Text = Now.ToShortDateString
        RequestHistorique()
    End Sub

    Private Sub Recalcul_Btn_Click(sender As Object, e As EventArgs) Handles Recalcul_Btn.Click
        If Matricule_txt.Text = "" Or Not EstDate(Dat_Visite_txt.Text) Then Return
        Dim codRegle As String = ""
        Dim calc = Sante_CalculEcheance(Matricule_txt.Text, CDate(Dat_Visite_txt.Text), codRegle)
        If calc IsNot Nothing Then
            Dat_Prochaine_Visite_txt.Text = CDate(calc).ToShortDateString
            Cod_Regle_txt.Text = codRegle
        Else
            ShowMessageBox("Aucune règle de périodicité applicable (paramétrage).", "Calcul", MessageBoxButtons.OK, msgIcon.Information)
        End If
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_Visite_txt.Text <> "" AndAlso "VA;SG".Split(";").Contains(statutDoc) Then Return
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        RequestHistorique()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS300", Num_Visite_txt, Me)
    End Sub

    Private Sub Dat_Visite_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Visite_Link.LinkClicked
        If Dat_Visite_txt.ReadOnly Then Return
        Appel_Calender(Dat_Visite_txt, Me)
    End Sub

    Private Sub Cod_Medecin_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Medecin_Link.LinkClicked
        If Cod_Medecin_txt.ReadOnly Then Return
        Appel_Zoom1("MS306", Cod_Medecin_txt, Me)
    End Sub

    Private Sub Cod_Medecin_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Medecin_txt.TextChanged
        Nom_Medecin_txt.Text = FindLibelle("Nom + ' ' + isnull(Prenom,'')", "Cod_Intervenant", Cod_Medecin_txt.Text, "Param_Sante_Intervenant")
    End Sub

    Private Sub Cod_Campagne_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Campagne_Link.LinkClicked
        If Cod_Campagne_txt.ReadOnly Then Return
        Appel_Zoom1("MS305", Cod_Campagne_txt, Me)
    End Sub

    Private Sub Rectifie_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Rectifie_Link.LinkClicked
        If Num_Visite_Rectifiee_txt.ReadOnly Then Return
        Appel_Zoom1("MS300", Num_Visite_Rectifiee_txt, Me)
    End Sub

    Private Sub Prochaine_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Prochaine_Link.LinkClicked
        If Dat_Prochaine_Visite_txt.ReadOnly Then Return
        Appel_Calender(Dat_Prochaine_Visite_txt, Me)
    End Sub

    Private Sub Num_Visite_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Visite_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_Visite_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_Visite_txt.Text)
            Code = Num_Visite_txt.Text
        End If
    End Sub

    Private Sub RH_Sante_Visite_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub

    Private Sub Grd_Historique_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Historique.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        Num_Visite_txt.Text = IsNull(Grd_Historique.Item("N° visite", e.RowIndex).Value, "")
    End Sub

#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        Return Saving("SG")
    End Function
    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function
#End Region
End Class
