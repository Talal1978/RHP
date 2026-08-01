Public Class RH_Sante_Examen
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
        If Typ_Examen_cbo.Items.Count = 0 Then Typ_Examen_cbo.fromRubrique("Typ_Examen")
        If Statut_Examen_cbo.Items.Count = 0 Then Statut_Examen_cbo.fromRubrique("Statut_Examen")
        If Visibilite_cbo.Items.Count = 0 Then Visibilite_cbo.fromRubrique("Visibilite_Examen")
    End Sub

    Private Sub RH_Sante_Examen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT * FROM RH_Sante_Examen where Num_Examen='" & Num_Examen_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        With Tbl
            If .Rows.Count > 0 Then
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                Typ_Examen_cbo.SelectedValue = IsNull(.Rows(0)("Typ_Examen"), "")
                Dat_Prescription_txt.Text = IsNull(.Rows(0)("Dat_Prescription"), "")
                Dat_Examen_txt.Text = IsNull(.Rows(0)("Dat_Examen"), "")
                Cod_Medecin_Prescripteur_txt.Text = IsNull(.Rows(0)("Cod_Medecin_Prescripteur"), "")
                Cod_Prestataire_txt.Text = IsNull(.Rows(0)("Cod_Prestataire"), "")
                Statut_Examen_cbo.SelectedValue = IsNull(.Rows(0)("Statut_Examen"), "")
                Dat_Resultat_txt.Text = IsNull(.Rows(0)("Dat_Resultat"), "")
                Visibilite_cbo.SelectedValue = IsNull(.Rows(0)("Visibilite"), "MED")
                ' Cloisonnement fin : contenu reserve au medecin prescripteur
                Dim visible As Boolean = PeutVoirResultat(.Rows(0))
                If visible Then
                    Motif_txt.Text = IsNull(.Rows(0)("Motif"), "")
                    Resultat_Resume_txt.Text = IsNull(.Rows(0)("Resultat_Resume"), "")
                Else
                    Motif_txt.Text = "(réservé au médecin prescripteur)"
                    Resultat_Resume_txt.Text = ""
                    Sante_Audit("AUTH_KO", "RH_Sante_Examen", Num_Examen_txt.Text, Matricule_txt.Text, False, "Résultat réservé au médecin prescripteur")
                End If
                FD_txt.Text = If(IsNull(.Rows(0)("FD_Resultat"), Nothing) Is Nothing, "", "(pièce jointe au dossier)")
                Sante_Audit("LECT", "RH_Sante_Examen", Num_Examen_txt.Text, Matricule_txt.Text)
            End If
        End With
    End Sub

    Function PeutVoirResultat(row As DataRow) As Boolean
        If IsNull(row("Visibilite"), "MED") <> "AUT" Then Return True
        Dim mat As String = IsNull(theUser.Matricule, "")
        Return IsNull(row("Cod_Medecin_Prescripteur"), "") = mat Or IsNull(row("Created_By"), "") = mat Or IsNull(row("Created_By"), "") = theUser.Login
    End Function

    Sub Enregistrer()
        If Matricule_txt.Text = "" Then
            ShowMessageBox("Matricule non renseigné", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Sante_VerrouCndp() Then
            Sante_Audit("AUTH_KO", "RH_Sante_Examen", Num_Examen_txt.Text, Matricule_txt.Text, False, "Verrou CNDP actif")
            ShowMessageBox("Traitement bloqué : autorisation CNDP non renseignée (paramètres)", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim numEx As String = Num_Examen_txt.Text
        Dim estCreation As Boolean = (numEx = "")
        If estCreation Then numEx = Sante_NouveauNumero("EX", "RH_Sante_Examen", "Num_Examen", "Dat_Examen")

        ' Date limite de conservation si resultat et duree parametree
        Dim datLimite As Object = DirectCast(DBNull.Value, Object)
        If EstDate(Dat_Resultat_txt.Text) Then
            Dim ans As Integer = CInt(Val(Sante_Param("DUREE_CONSERVATION_EXAMEN_ANS", "0")))
            If ans > 0 Then datLimite = CDate(Dat_Resultat_txt.Text).AddYears(ans)
        End If

        Dim ok As Boolean
        If estCreation Then
            ok = Sante_Execute(
                "insert into RH_Sante_Examen (Num_Examen, id_Societe, Matricule, Typ_Examen, Dat_Prescription, Dat_Examen, Cod_Medecin_Prescripteur, Cod_Prestataire, Motif, Statut_Examen, Dat_Resultat, Resultat_Resume, Visibilite, Dat_Limite_Conservation, Statut, Dat_Crea, Created_By) " &
                "values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,'',getdate(),?)",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, numEx},
                 {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
                 {"p4", ADODB.DataTypeEnum.adVarWChar, 20, IsNull(Typ_Examen_cbo.SelectedValue, "")},
                 {"p5", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Prescription_txt.Text), CDate(Dat_Prescription_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p6", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Examen_txt.Text), CDate(Dat_Examen_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Medecin_Prescripteur_txt.Text},
                 {"p8", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Prestataire_txt.Text},
                 {"p9", ADODB.DataTypeEnum.adVarWChar, 500, Motif_txt.Text},
                 {"p10", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_Examen_cbo.SelectedValue, "")},
                 {"p11", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Resultat_txt.Text), CDate(Dat_Resultat_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p12", ADODB.DataTypeEnum.adLongVarWChar, -1, Resultat_Resume_txt.Text},
                 {"p13", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Visibilite_cbo.SelectedValue, "MED")},
                 {"p14", ADODB.DataTypeEnum.adDate, 0, datLimite},
                 {"p15", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}})
        Else
            ok = Sante_Execute(
                "update RH_Sante_Examen set Typ_Examen=?, Dat_Prescription=?, Dat_Examen=?, Cod_Medecin_Prescripteur=?, Cod_Prestataire=?, Motif=?, Statut_Examen=?, Dat_Resultat=?, Resultat_Resume=?, Visibilite=?, Dat_Limite_Conservation=isnull(?, Dat_Limite_Conservation), Dat_Modif=getdate(), Modified_By=? " &
                "where Num_Examen=? and id_Societe=?",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, IsNull(Typ_Examen_cbo.SelectedValue, "")},
                 {"p2", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Prescription_txt.Text), CDate(Dat_Prescription_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p3", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Examen_txt.Text), CDate(Dat_Examen_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p4", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Medecin_Prescripteur_txt.Text},
                 {"p5", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Prestataire_txt.Text},
                 {"p6", ADODB.DataTypeEnum.adVarWChar, 500, Motif_txt.Text},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_Examen_cbo.SelectedValue, "")},
                 {"p8", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Resultat_txt.Text), CDate(Dat_Resultat_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p9", ADODB.DataTypeEnum.adLongVarWChar, -1, Resultat_Resume_txt.Text},
                 {"p10", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Visibilite_cbo.SelectedValue, "MED")},
                 {"p11", ADODB.DataTypeEnum.adDate, 0, datLimite},
                 {"p12", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                 {"p13", ADODB.DataTypeEnum.adVarWChar, 20, numEx},
                 {"p14", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}})
        End If
        If ok Then
            Sante_Audit(IIf(estCreation, "CREA", "MODI"), "RH_Sante_Examen", numEx, Matricule_txt.Text)
            ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
            If Num_Examen_txt.Text = "" Then Num_Examen_txt.Text = numEx Else Request()
        End If
    End Sub

    Sub Deleting()
        If ShowMessageBox("Supprimer cet examen ?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('RH_Sante_Examen','Num_Examen','" & Num_Examen_txt.Text & "', " & IsNull(theUser.id_User, 0) & ", convert(nvarchar(20),getdate(),120))")
        CnExecuting("delete from RH_Sante_Examen where Num_Examen='" & Num_Examen_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Sante_Audit("SUPP", "RH_Sante_Examen", Num_Examen_txt.Text, Matricule_txt.Text)
        Reset_Form(Me)
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS303", Num_Examen_txt, Me)
    End Sub

    Private Sub Prescripteur_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Prescripteur_Link.LinkClicked
        Appel_Zoom1("MS306", Cod_Medecin_Prescripteur_txt, Me)
    End Sub

    Private Sub Prestataire_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Prestataire_Link.LinkClicked
        Appel_Zoom1("MS306", Cod_Prestataire_txt, Me)
    End Sub

    Private Sub Dat_Prescription_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Prescription_Link.LinkClicked
        Appel_Calender(Dat_Prescription_txt, Me)
    End Sub

    Private Sub Dat_Examen_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Examen_Link.LinkClicked
        Appel_Calender(Dat_Examen_txt, Me)
    End Sub

    Private Sub Dat_Resultat_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Resultat_Link.LinkClicked
        Appel_Calender(Dat_Resultat_txt, Me)
    End Sub

    Private Sub Num_Examen_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Examen_txt.TextChanged
        Request()
    End Sub
End Class
