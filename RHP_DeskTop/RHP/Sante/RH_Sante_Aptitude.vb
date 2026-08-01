Public Class RH_Sante_Aptitude
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Valide_D As ud_btn
    Dim Rectif_D As ud_btn
    Dim statutDoc As String = ""
    Public ReadOnly Property AllowUploadInReadOnly As Boolean
        Get
            Return True
        End Get
    End Property

    Sub Chargement()
        If Save_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Valide_D = dictButtons("Valide_D")
            If dictButtons.ContainsKey("Rectif_D") Then Rectif_D = dictButtons("Rectif_D")
        End If
        If Statut_Aptitude_cbo.Items.Count = 0 Then Statut_Aptitude_cbo.fromRubrique("Statut_Aptitude")
    End Sub

    Private Sub RH_Sante_Aptitude_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("CLINIQUE", Me.Name) Then
            ShowMessageBox("Accès réservé au service médical.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Aptitude_txt.Text) Then Dat_Aptitude_txt.Text = Now.ToShortDateString
    End Sub

    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        Dim canModify As Boolean = True
        statutDoc = ""
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT * FROM RH_Sante_Aptitude where Num_Aptitude='" & Num_Aptitude_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        With Tbl
            If .Rows.Count > 0 Then
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                Num_Visite_txt.Text = IsNull(.Rows(0)("Num_Visite"), "")
                Dat_Aptitude_txt.Text = IsNull(.Rows(0)("Dat_Aptitude"), "")
                Cod_Medecin_txt.Text = IsNull(.Rows(0)("Cod_Medecin"), "")
                Statut_Aptitude_cbo.SelectedValue = IsNull(.Rows(0)("Statut_Aptitude"), "")
                Reserves_txt.Text = IsNull(.Rows(0)("Reserves"), "")
                Restrictions_Poste_txt.Text = IsNull(.Rows(0)("Restrictions_Poste"), "")
                Amenagements_txt.Text = IsNull(.Rows(0)("Amenagements"), "")
                Dat_Effet_txt.Text = IsNull(.Rows(0)("Dat_Effet"), "")
                Dat_Fin_txt.Text = IsNull(.Rows(0)("Dat_Fin"), "")
                Version_txt.Text = IsNull(.Rows(0)("Version"), "1").ToString()
                Num_Aptitude_Prec_txt.Text = IsNull(.Rows(0)("Num_Aptitude_Prec"), "")
                Motif_Version_txt.Text = IsNull(.Rows(0)("Motif_Version"), "")
                Publie_RH_chk.Checked = IsNull(.Rows(0)("Publie_RH"), False)
                statutDoc = IsNull(.Rows(0)("Statut"), "")
                With pb_Valide
                    .Tag = ""
                    .Image = My.Resources.valide01
                    Select Case statutDoc
                        Case "VA" : .Visible = True
                        Case "SG" : .Tag = "SG" : .Visible = True
                        Case "RJ" : .Image = My.Resources.refuse : .Tag = "RJ" : .Visible = True
                    End Select
                End With
                If "VA;SG".Split(";").Contains(statutDoc) Then canModify = False
                Sante_Audit("LECT", "RH_Sante_Aptitude", Num_Aptitude_txt.Text, Matricule_txt.Text)
            End If
        End With
        Verrouiller(Not canModify)
        Save_D.Enabled = canModify
        Del_D.Enabled = canModify
        Valide_D.Enabled = canModify
        If Rectif_D IsNot Nothing Then Rectif_D.Enabled = Not canModify
    End Sub

    Sub Verrouiller(verrou As Boolean)
        Matricule_.Enabled = Not verrou
        Num_Visite_txt.ReadOnly = verrou
        Dat_Aptitude_txt.ReadOnly = verrou
        Cod_Medecin_txt.ReadOnly = verrou
        Statut_Aptitude_cbo.Enabled = Not verrou
        Reserves_txt.ReadOnly = verrou
        Restrictions_Poste_txt.ReadOnly = verrou
        Amenagements_txt.ReadOnly = verrou
        Dat_Effet_txt.ReadOnly = verrou
        Dat_Fin_txt.ReadOnly = verrou
        Motif_Version_txt.ReadOnly = verrou
        Num_Aptitude_Prec_txt.ReadOnly = verrou
        Publie_RH_chk.Enabled = Not verrou
    End Sub

    Function Controles() As savingResult
        If Matricule_txt.Text = "" Then Return New savingResult With {.result = False, .message = "Matricule non renseigné"}
        If Statut_Aptitude_cbo.SelectedIndex < 0 Then Return New savingResult With {.result = False, .message = "Statut d'aptitude non renseigné"}
        If Num_Aptitude_Prec_txt.Text <> "" And Motif_Version_txt.Text.Trim = "" Then
            Return New savingResult With {.result = False, .message = "Le motif de la nouvelle version est obligatoire"}
        End If
        If EstDate(Dat_Effet_txt.Text) And EstDate(Dat_Fin_txt.Text) Then
            If CDate(Dat_Fin_txt.Text) < CDate(Dat_Effet_txt.Text) Then
                Return New savingResult With {.result = False, .message = "La fin de validité ne peut pas précéder la date d'effet"}
            End If
        End If
        Return New savingResult With {.result = True, .message = ""}
    End Function

    Function Saving(statut As String) As savingResult
        Dim ctl = Controles()
        If Not ctl.result Then Return ctl
        If Sante_VerrouCndp() Then
            Sante_Audit("AUTH_KO", "RH_Sante_Aptitude", Num_Aptitude_txt.Text, Matricule_txt.Text, False, "Verrou CNDP actif")
            Return New savingResult With {.result = False, .message = "Traitement bloqué : autorisation CNDP non renseignée (paramètres)"}
        End If

        Dim numApt As String = Num_Aptitude_txt.Text
        Dim estCreation As Boolean = (numApt = "")
        Dim version As Integer = 1
        If estCreation Then
            If Num_Aptitude_Prec_txt.Text <> "" Then
                version = CInt(IsNull(Sante_Scalar("select isnull(max(Version),0)+1 from RH_Sante_Aptitude where Matricule=? and id_Societe=?",
                                      {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
                                       {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}}), 1))
            End If
            numApt = Sante_NouveauNumero("FA", "RH_Sante_Aptitude", "Num_Aptitude", "Dat_Aptitude")
        Else
            Dim st = Sante_Scalar("select Statut from RH_Sante_Aptitude where Num_Aptitude=? and id_Societe=?",
                                  {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, numApt},
                                   {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}})
            If "VA;SG".Split(";").Contains(IsNull(st, "")) Then
                Return New savingResult With {.result = False, .message = "Fiche validée : créez une nouvelle version (rectification motivée)"}
            End If
            version = CInt(IsNull(Version_txt.Text, "1"))
        End If

        Dim ok As Boolean
        If estCreation Then
            Dim pi As Object(,) = {
                {"p1", ADODB.DataTypeEnum.adVarWChar, 20, numApt},
                {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                {"p3", ADODB.DataTypeEnum.adVarWChar, 20, Num_Visite_txt.Text},
                {"p4", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
                {"p5", ADODB.DataTypeEnum.adDate, 0, CDate(Dat_Aptitude_txt.Text)},
                {"p6", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Medecin_txt.Text},
                {"p7", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_Aptitude_cbo.SelectedValue, "")},
                {"p8", ADODB.DataTypeEnum.adVarWChar, 500, Reserves_txt.Text},
                {"p9", ADODB.DataTypeEnum.adVarWChar, 500, Restrictions_Poste_txt.Text},
                {"p10", ADODB.DataTypeEnum.adVarWChar, 500, Amenagements_txt.Text},
                {"p11", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Effet_txt.Text), CDate(Dat_Effet_txt.Text), DirectCast(DBNull.Value, Object))},
                {"p12", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Fin_txt.Text), CDate(Dat_Fin_txt.Text), DirectCast(DBNull.Value, Object))},
                {"p13", ADODB.DataTypeEnum.adInteger, 0, version},
                {"p14", ADODB.DataTypeEnum.adVarWChar, 20, Num_Aptitude_Prec_txt.Text},
                {"p15", ADODB.DataTypeEnum.adVarWChar, 250, Motif_Version_txt.Text},
                {"p16", ADODB.DataTypeEnum.adVarWChar, 1, IIf(Publie_RH_chk.Checked, "1", "0")},
                {"p17", ADODB.DataTypeEnum.adVarWChar, 3, statut},
                {"p18", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}}
            ok = Sante_Execute(
                "insert into RH_Sante_Aptitude (Num_Aptitude, id_Societe, Num_Visite, Matricule, Dat_Aptitude, Cod_Medecin, Statut_Aptitude, " &
                "Reserves, Restrictions_Poste, Amenagements, Dat_Effet, Dat_Fin, Version, Num_Aptitude_Prec, Motif_Version, Publie_RH, Statut, Dat_Crea, Created_By) " &
                "values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,getdate(),?)", pi)
        Else
            Dim pu As Object(,) = {
                {"p1", ADODB.DataTypeEnum.adVarWChar, 20, Num_Visite_txt.Text},
                {"p2", ADODB.DataTypeEnum.adDate, 0, CDate(Dat_Aptitude_txt.Text)},
                {"p3", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Medecin_txt.Text},
                {"p4", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_Aptitude_cbo.SelectedValue, "")},
                {"p5", ADODB.DataTypeEnum.adVarWChar, 500, Reserves_txt.Text},
                {"p6", ADODB.DataTypeEnum.adVarWChar, 500, Restrictions_Poste_txt.Text},
                {"p7", ADODB.DataTypeEnum.adVarWChar, 500, Amenagements_txt.Text},
                {"p8", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Effet_txt.Text), CDate(Dat_Effet_txt.Text), DirectCast(DBNull.Value, Object))},
                {"p9", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Fin_txt.Text), CDate(Dat_Fin_txt.Text), DirectCast(DBNull.Value, Object))},
                {"p10", ADODB.DataTypeEnum.adVarWChar, 1, IIf(Publie_RH_chk.Checked, "1", "0")},
                {"p11", ADODB.DataTypeEnum.adVarWChar, 3, statut},
                {"p12", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                {"p13", ADODB.DataTypeEnum.adVarWChar, 20, numApt},
                {"p14", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}}
            ok = Sante_Execute(
                "update RH_Sante_Aptitude set Num_Visite=?, Dat_Aptitude=?, Cod_Medecin=?, Statut_Aptitude=?, Reserves=?, " &
                "Restrictions_Poste=?, Amenagements=?, Dat_Effet=?, Dat_Fin=?, Publie_RH=?, Statut=?, Dat_Modif=getdate(), Modified_By=? " &
                "where Num_Aptitude=? and id_Societe=?", pu)
        End If
        If Not ok Then Return New savingResult With {.result = False, .message = "Erreur d'enregistrement"}

        Sante_Audit(IIf(estCreation, "CREA", "MODI"), "RH_Sante_Aptitude", numApt, Matricule_txt.Text)
        If Num_Aptitude_txt.Text = "" Then Num_Aptitude_txt.Text = numApt Else Request()
        Return New savingResult With {.result = True, .message = "Enregistré avec succès"}
    End Function

    Sub Enregistrer()
        Dim rsl As savingResult = Saving("")
        If IsNull(rsl.message, "") <> "" Then ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub

    Function Valider()
        If ShowMessageBox("Valider cette fiche d'aptitude ? Elle ne sera plus modifiable (toute correction passera par une nouvelle version).", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving("VA")
        If rs.result Then Request()
        If IsNull(rs.message, "") <> "" Then ShowMessageBox(rs.message, "Validation", MessageBoxButtons.OK, IIf(rs.result, msgIcon.Information, msgIcon.Stop))
        Return rs.result
    End Function

    ''' <summary>Nouvelle version (rectification) d'une fiche validee.</summary>
    Sub NouvelleVersion()
        If Num_Aptitude_txt.Text = "" Or Not "VA;SG".Split(";").Contains(statutDoc) Then
            ShowMessageBox("La nouvelle version s'applique à une fiche validée.", "Version", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        Dim prec As String = Num_Aptitude_txt.Text
        Dim mat As String = Matricule_txt.Text
        Reset_Form(Me)
        Verrouiller(False)
        Save_D.Enabled = True : Del_D.Enabled = True : Valide_D.Enabled = True
        Matricule_txt.Text = mat
        Num_Aptitude_Prec_txt.Text = prec
        Dat_Aptitude_txt.Text = Now.ToShortDateString
        Version_txt.Text = "(nouvelle)"
        Motif_Version_txt.Text = ""
        statutDoc = ""
    End Sub

    Sub Deleting()
        If "VA;SG".Split(";").Contains(statutDoc) Then
            ShowMessageBox("Impossible de supprimer une fiche validée.", "Stop", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ShowMessageBox("Supprimer cette fiche d'aptitude ?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('RH_Sante_Aptitude','Num_Aptitude','" & Num_Aptitude_txt.Text & "', " & IsNull(theUser.id_User, 0) & ", convert(nvarchar(20),getdate(),120))")
        CnExecuting("delete from RH_Sante_Aptitude where Num_Aptitude='" & Num_Aptitude_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Sante_Audit("SUPP", "RH_Sante_Aptitude", Num_Aptitude_txt.Text, Matricule_txt.Text)
        Reset_Form(Me)
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        Verrouiller(False)
        Save_D.Enabled = True : Del_D.Enabled = True : Valide_D.Enabled = True
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        Dat_Aptitude_txt.Text = Now.ToShortDateString
        Version_txt.Text = "1"
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_Aptitude_txt.Text <> "" AndAlso "VA;SG".Split(";").Contains(statutDoc) Then Return
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS301", Num_Aptitude_txt, Me)
    End Sub

    Private Sub Visite_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Visite_Link.LinkClicked
        If Num_Visite_txt.ReadOnly Then Return
        Appel_Zoom1("MS300", Num_Visite_txt, Me)
    End Sub

    Private Sub Dat_Aptitude_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Aptitude_Link.LinkClicked
        If Dat_Aptitude_txt.ReadOnly Then Return
        Appel_Calender(Dat_Aptitude_txt, Me)
    End Sub

    Private Sub Cod_Medecin_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Medecin_Link.LinkClicked
        If Cod_Medecin_txt.ReadOnly Then Return
        Appel_Zoom1("MS306", Cod_Medecin_txt, Me)
    End Sub

    Private Sub Cod_Medecin_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Medecin_txt.TextChanged
        Nom_Medecin_txt.Text = FindLibelle("Nom + ' ' + isnull(Prenom,'')", "Cod_Intervenant", Cod_Medecin_txt.Text, "Param_Sante_Intervenant")
    End Sub

    Private Sub Effet_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Effet_Link.LinkClicked
        If Dat_Effet_txt.ReadOnly Then Return
        Appel_Calender(Dat_Effet_txt, Me)
    End Sub

    Private Sub Fin_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Fin_Link.LinkClicked
        If Dat_Fin_txt.ReadOnly Then Return
        Appel_Calender(Dat_Fin_txt, Me)
    End Sub

    Private Sub Prec_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Prec_Link.LinkClicked
        If Num_Aptitude_Prec_txt.ReadOnly Then Return
        Appel_Zoom1("MS301", Num_Aptitude_Prec_txt, Me)
    End Sub

    Private Sub Num_Aptitude_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Aptitude_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_Aptitude_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_Aptitude_txt.Text)
            Code = Num_Aptitude_txt.Text
        End If
    End Sub

    Private Sub RH_Sante_Aptitude_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
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
