Public Class RH_Declaration_AT_Suivi
    Dim Save_D As ud_btn
    Dim Generer_D As ud_btn

    Sub Chargement()
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
            Generer_D = dictButtons("Generer_D")
        End If
        If Typ_Accident_cbo.Items.Count = 0 Then Typ_Accident_cbo.fromRubrique("Typ_Accident")
        If Grd_Echeances.Columns.Count > 0 AndAlso CType(Grd_Echeances.Columns("Statut_Etape"), DataGridViewComboBoxColumn).Items.Count = 0 Then
            Combo_GRD(CType(Grd_Echeances.Columns("Statut_Etape"), DataGridViewComboBoxColumn), "Statut_Etape_AT")
        End If
        If Grd_Transmissions.Columns.Count > 0 AndAlso CType(Grd_Transmissions.Columns("Mode_Transmission"), DataGridViewComboBoxColumn).Items.Count = 0 Then
            Combo_GRD(CType(Grd_Transmissions.Columns("Mode_Transmission"), DataGridViewComboBoxColumn), "Mode_Transmission")
        End If
        Grd_Echeances.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Transmissions.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Private Sub RH_Declaration_AT_Suivi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("ADMIN", Me.Name) Then
            ShowMessageBox("Accès non autorisé.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
    End Sub

    Sub Request()
        Chargement()
        Dim Tbl As DataTable = DATA_READER_GRD(
            "select Num_Declaration, Matricule, Dat_Accident, isnull(Typ_Accident,'TRAVAIL') as Typ_Accident, Statut, Cloture " &
            "from RH_Declaration_AT where Num_Declaration='" & Num_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count > 0 Then
            Matricule_txt.Text = IsNull(Tbl.Rows(0)("Matricule"), "")
            Dat_Accident_txt.Text = IsNull(Tbl.Rows(0)("Dat_Accident"), "")
            Typ_Accident_cbo.SelectedValue = IsNull(Tbl.Rows(0)("Typ_Accident"), "TRAVAIL")
            Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
            Sante_Audit("LECT", "RH_Declaration_AT_Suivi", Num_Declaration_txt.Text, Matricule_txt.Text)
        Else
            Matricule_txt.Text = "" : Dat_Accident_txt.Text = "" : Nom_Agent_Text.Text = ""
            Typ_Accident_cbo.SelectedIndex = -1
        End If
        RequestEcheances()
        RequestTransmissions()
    End Sub

    Sub RequestEcheances()
        Dim Tbl As DataTable = DATA_READER_GRD(
            "select Cod_Etape, Dat_Debut, Delai_Jours, Dat_Echeance, Statut_Etape, Dat_Realisation, Commentaire, RowId " &
            "from RH_Declaration_AT_Echeance where Num_Declaration='" & Num_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe & " order by Dat_Echeance")
        With Grd_Echeances
            .Rows.Clear()
            If .Columns.Count > 0 Then
                For i = 0 To Tbl.Rows.Count - 1
                    .Rows.Add(Tbl.Rows(i)("Cod_Etape"), Tbl.Rows(i)("Dat_Debut"), Tbl.Rows(i)("Delai_Jours"), Tbl.Rows(i)("Dat_Echeance"), Tbl.Rows(i)("Statut_Etape"), Tbl.Rows(i)("Dat_Realisation"), Tbl.Rows(i)("Commentaire"))
                    .Rows(i).Tag = Tbl.Rows(i)("RowId")
                    Dim retard As Boolean = IsNull(Tbl.Rows(i)("Statut_Etape"), "AFA") <> "FAI" AndAlso IsNull(Tbl.Rows(i)("Statut_Etape"), "AFA") <> "ANN" AndAlso IsDate(IsNull(Tbl.Rows(i)("Dat_Echeance"), "")) AndAlso CDate(Tbl.Rows(i)("Dat_Echeance")) < Now
                    If retard Then .Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                Next
            End If
        End With
    End Sub

    Sub RequestTransmissions()
        Dim Tbl As DataTable = DATA_READER_GRD(
            "select Cod_Destinataire, Dat_Transmission, Mode_Transmission, Reference, Commentaire, RowId " &
            "from RH_Declaration_AT_Transmission where Num_Declaration='" & Num_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe & " order by Dat_Transmission")
        With Grd_Transmissions
            .Rows.Clear()
            If .Columns.Count > 0 Then
                For i = 0 To Tbl.Rows.Count - 1
                    .Rows.Add(Tbl.Rows(i)("Cod_Destinataire"), Tbl.Rows(i)("Dat_Transmission"), Tbl.Rows(i)("Mode_Transmission"), Tbl.Rows(i)("Reference"), Tbl.Rows(i)("Commentaire"))
                    .Rows(i).Tag = Tbl.Rows(i)("RowId")
                Next
            End If
        End With
    End Sub

    Sub Enregistrer()
        If Num_Declaration_txt.Text = "" Then
            ShowMessageBox("Sélectionnez une déclaration AT.", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        ' Distinction travail / trajet / non reconnu
        If Typ_Accident_cbo.SelectedIndex >= 0 Then
            Sante_Execute(
                "update RH_Declaration_AT set Typ_Accident=?, Dat_Modif=getdate(), Modified_By=? where Num_Declaration=? and id_Societe=?",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, IsNull(Typ_Accident_cbo.SelectedValue, "TRAVAIL")},
                 {"p2", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 20, Num_Declaration_txt.Text},
                 {"p4", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}})
        End If
        ' Echeances (statut + realisation + commentaire ; annulation motivee)
        Grd_Echeances.EndEdit()
        For i = 0 To Grd_Echeances.RowCount - 1
            If Grd_Echeances.Rows(i).IsNewRow Then Continue For
            Dim tagId As String = IsNull(Grd_Echeances.Rows(i).Tag, "")
            If tagId = "" Then Continue For
            Dim st As String = IsNull(Grd_Echeances.Item("Statut_Etape", i).Value, "")
            If st = "ANN" And IsNull(Grd_Echeances.Item("Commentaire", i).Value, "").ToString().Trim() = "" Then
                ShowMessageBox("L'annulation de l'étape " & IsNull(Grd_Echeances.Item("Cod_Etape", i).Value, "") & " doit être motivée.", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            Sante_Execute(
                "update RH_Declaration_AT_Echeance set Statut_Etape=?, Dat_Realisation=?, Commentaire=?, Dat_Modif=getdate(), Modified_By=? where RowId=? and id_Societe=?",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 10, st},
                 {"p2", ADODB.DataTypeEnum.adDate, 0, If(IsDate(Grd_Echeances.Item("Dat_Realisation", i).Value), CDate(Grd_Echeances.Item("Dat_Realisation", i).Value), DirectCast(DBNull.Value, Object))},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 250, IsNull(Grd_Echeances.Item("Commentaire", i).Value, "")},
                 {"p4", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                 {"p5", ADODB.DataTypeEnum.adInteger, 0, CInt(tagId)},
                 {"p6", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}})
        Next
        ' Transmissions : delete + reinsertion
        Grd_Transmissions.EndEdit()
        CnExecuting("delete from RH_Declaration_AT_Transmission where Num_Declaration='" & Num_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        For i = 0 To Grd_Transmissions.RowCount - 1
            If Grd_Transmissions.Rows(i).IsNewRow Then Continue For
            Dim dest As String = IsNull(Grd_Transmissions.Item("Cod_Destinataire", i).Value, "")
            If dest = "" Then Continue For
            Sante_Execute(
                "insert into RH_Declaration_AT_Transmission (Num_Declaration, id_Societe, Cod_Destinataire, Dat_Transmission, Mode_Transmission, Reference, Commentaire, Dat_Crea, Created_By) " &
                "values (?, ?, ?, ?, ?, ?, ?, getdate(), ?)",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, Num_Declaration_txt.Text},
                 {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 20, dest},
                 {"p4", ADODB.DataTypeEnum.adDate, 0, If(IsDate(Grd_Transmissions.Item("Dat_Transmission", i).Value), CDate(Grd_Transmissions.Item("Dat_Transmission", i).Value), DirectCast(DBNull.Value, Object))},
                 {"p5", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Grd_Transmissions.Item("Mode_Transmission", i).Value, "")},
                 {"p6", ADODB.DataTypeEnum.adVarWChar, 100, IsNull(Grd_Transmissions.Item("Reference", i).Value, "")},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 250, IsNull(Grd_Transmissions.Item("Commentaire", i).Value, "")},
                 {"p8", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}})
        Next
        Sante_Audit("MODI", "RH_Declaration_AT_Suivi", Num_Declaration_txt.Text, Matricule_txt.Text)
        ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
        Request()
    End Sub

    Sub GenererEcheancier()
        If Num_Declaration_txt.Text = "" Then
            ShowMessageBox("Sélectionnez une déclaration AT.", "Générer", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        CnExecuting("exec Sys_Sante_AT_Generer_Echeances '" & Num_Declaration_txt.Text & "', " & Societe.id_Societe)
        Sante_Audit("CREA", "RH_Declaration_AT_Echeance", Num_Declaration_txt.Text, Matricule_txt.Text, True, "Génération échéancier")
        RequestEcheances()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("AT010", Num_Declaration_txt, Me)
    End Sub

    Private Sub Num_Declaration_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Declaration_txt.TextChanged
        Request()
    End Sub
End Class
