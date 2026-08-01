Public Class RH_Sante_Vaccination
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
        If Grd_Vaccinations.Columns.Count > 0 AndAlso CType(Grd_Vaccinations.Columns("Typ_Vaccin"), DataGridViewComboBoxColumn).Items.Count = 0 Then
            Combo_GRD(CType(Grd_Vaccinations.Columns("Typ_Vaccin"), DataGridViewComboBoxColumn), "Typ_Vaccin")
        End If
    End Sub

    Private Sub RH_Sante_Vaccination_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("CLINIQUE", Me.Name) Then
            ShowMessageBox("Accès réservé au service médical.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        If Sante_Param("ACTIVER_VACCINATIONS", "N") <> "O" Then
            ShowMessageBox("Le suivi des vaccinations n'est pas activé (paramètres).", "Vaccinations", MessageBoxButtons.OK, msgIcon.Information)
        End If
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
    End Sub

    Sub Request()
        Chargement()
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        Dim Tbl As DataTable = DATA_READER_GRD(
            "select Typ_Vaccin, Dat_Vaccination, Dat_Rappel, Commentaire, RowId from RH_Sante_Vaccination " &
            "where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe & " order by Dat_Vaccination desc")
        With Grd_Vaccinations
            .Rows.Clear()
            If .Columns.Count > 0 Then
                For i = 0 To Tbl.Rows.Count - 1
                    .Rows.Add(Tbl.Rows(i)("Typ_Vaccin"), Tbl.Rows(i)("Dat_Vaccination"), Tbl.Rows(i)("Dat_Rappel"), Tbl.Rows(i)("Commentaire"))
                    .Rows(i).Tag = Tbl.Rows(i)("RowId")
                Next
            End If
        End With
        If Matricule_txt.Text <> "" Then Sante_Audit("LECT", "RH_Sante_Vaccination", Matricule_txt.Text, Matricule_txt.Text)
    End Sub

    Sub Enregistrer()
        If Matricule_txt.Text = "" Then
            ShowMessageBox("Matricule non renseigné", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Sante_Param("ACTIVER_VACCINATIONS", "N") <> "O" Then
            ShowMessageBox("Le suivi des vaccinations n'est pas activé (paramètres).", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Sante_VerrouCndp() Then
            Sante_Audit("AUTH_KO", "RH_Sante_Vaccination", Matricule_txt.Text, Matricule_txt.Text, False, "Verrou CNDP actif")
            ShowMessageBox("Traitement bloqué : autorisation CNDP non renseignée (paramètres)", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Grd_Vaccinations.EndEdit()
        ' Synchronisation simple (pattern socle) : suppression puis reinsertion des lignes
        CnExecuting("delete from RH_Sante_Vaccination where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        For i = 0 To Grd_Vaccinations.RowCount - 1
            If Grd_Vaccinations.Rows(i).IsNewRow Then Continue For
            Dim typ As String = IsNull(Grd_Vaccinations.Item("Typ_Vaccin", i).Value, "")
            If typ = "" Then Continue For
            Sante_Execute(
                "insert into RH_Sante_Vaccination (Matricule, id_Societe, Typ_Vaccin, Dat_Vaccination, Dat_Rappel, Commentaire, Dat_Crea, Created_By) " &
                "values (?, ?, ?, ?, ?, ?, getdate(), ?)",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, Matricule_txt.Text},
                 {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 20, typ},
                 {"p4", ADODB.DataTypeEnum.adDate, 0, If(IsDate(Grd_Vaccinations.Item("Dat_Vaccination", i).Value), CDate(Grd_Vaccinations.Item("Dat_Vaccination", i).Value), DirectCast(DBNull.Value, Object))},
                 {"p5", ADODB.DataTypeEnum.adDate, 0, If(IsDate(Grd_Vaccinations.Item("Dat_Rappel", i).Value), CDate(Grd_Vaccinations.Item("Dat_Rappel", i).Value), DirectCast(DBNull.Value, Object))},
                 {"p6", ADODB.DataTypeEnum.adVarWChar, 250, IsNull(Grd_Vaccinations.Item("Commentaire", i).Value, "")},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}})
        Next
        Sante_Audit("MODI", "RH_Sante_Vaccination", Matricule_txt.Text, Matricule_txt.Text)
        ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
        Request()
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        Request()
    End Sub

    Sub Deleting()
        If ShowMessageBox("Supprimer toutes les vaccinations de cet agent ?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Sante_Vaccination where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Sante_Audit("SUPP", "RH_Sante_Vaccination", Matricule_txt.Text, Matricule_txt.Text)
        Request()
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Request()
    End Sub
End Class
