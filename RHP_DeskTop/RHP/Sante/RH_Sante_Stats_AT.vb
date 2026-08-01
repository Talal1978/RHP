Public Class RH_Sante_Stats_AT
    Dim Save_D As ud_btn

    Sub Chargement()
        If Save_D Is Nothing AndAlso dictButtons.ContainsKey("Save_D") Then Save_D = dictButtons("Save_D")
        Grd_Stats.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Heures.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Private Sub RH_Sante_Stats_AT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("ADMIN", Me.Name) Then
            ShowMessageBox("Accès non autorisé.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        Annee_txt.Text = (Now.Year - 1).ToString()
        Requesting()
    End Sub

    Sub Requesting()
        Chargement()
        Dim an As String = If(Val(Annee_txt.Text) > 2000, CInt(Val(Annee_txt.Text)).ToString(), "")
        Grd_Stats.DataSource = DATA_READER_GRD(
            "select Annee as 'Année', Mois, Nb_Accidents as 'Accidents', Nb_Travail as 'Travail', Nb_Trajet as 'Trajet', " &
            "Nb_Avec_Arret as 'Avec arrêt', Jours_Arret as 'Jours d''arrêt', Heures_Travaillees as 'Heures', " &
            "Taux_Frequence as 'Taux fréquence', Taux_Gravite as 'Taux gravité' " &
            "from RH_Sante_Vue_Stats_AT where id_Societe=" & Societe.id_Societe & IIf(an <> "", " and Annee=" & an, "") & " order by Annee desc, Mois")
        Grd_Heures.DataSource = DATA_READER_GRD(
            "select Annee as 'Année', Mois, Heures, Source from RH_Sante_Heures_Travaillees where id_Societe=" & Societe.id_Societe & " order by Annee desc, Mois desc")
        ' Grille heures editable : on recharge en mode lignes
        Dim Tbl As DataTable = DATA_READER_GRD(
            "select Annee, Mois, Heures, Source from RH_Sante_Heures_Travaillees where id_Societe=" & Societe.id_Societe & " order by Annee desc, Mois desc")
        With Grd_Heures
            .DataSource = Nothing
            .Rows.Clear()
            If .Columns.Count > 0 Then
                For i = 0 To Tbl.Rows.Count - 1
                    .Rows.Add(Tbl.Rows(i)("Annee"), Tbl.Rows(i)("Mois"), Tbl.Rows(i)("Heures"), Tbl.Rows(i)("Source"))
                Next
            End If
        End With
        Formules_txt.Text = "Taux de fréquence = Nb AT avec arrêt × base (" & Sante_Param("TAUX_FREQ_BASE", "1000000") & ") / heures travaillées" &
            "  |  Taux de gravité = jours d'arrêt × base (" & Sante_Param("TAUX_GRAV_BASE", "1000") & ") / heures travaillées" &
            "  |  Heures : saisies ci-dessous (source " & Sante_Param("HEURES_TRAVAILLEES_SOURCE", "SAISIE") & ")"
    End Sub

    Sub Enregistrer()
        Grd_Heures.EndEdit()
        For i = 0 To Grd_Heures.RowCount - 1
            If Grd_Heures.Rows(i).IsNewRow Then Continue For
            Dim an As Integer = CInt(Val(IsNull(Grd_Heures.Item("Annee", i).Value, 0)))
            Dim mo As Integer = CInt(Val(IsNull(Grd_Heures.Item("Mois", i).Value, 0)))
            If an < 2000 Or mo < 1 Or mo > 12 Then Continue For
            Sante_Execute(
                "if exists(select Annee from RH_Sante_Heures_Travaillees where Annee=? and Mois=? and id_Societe=?) " &
                "update RH_Sante_Heures_Travaillees set Heures=?, Source=?, Dat_Modif=getdate(), Modified_By=? where Annee=? and Mois=? and id_Societe=? " &
                "else insert into RH_Sante_Heures_Travaillees (Annee, Mois, id_Societe, Heures, Source, Dat_Crea, Created_By) values (?, ?, ?, ?, ?, getdate(), ?)",
                {{"p1", ADODB.DataTypeEnum.adInteger, 0, an},
                 {"p2", ADODB.DataTypeEnum.adInteger, 0, mo},
                 {"p3", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                 {"p4", ADODB.DataTypeEnum.adDouble, 0, CDbl(Val(IsNull(Grd_Heures.Item("Heures", i).Value, 0)))},
                 {"p5", ADODB.DataTypeEnum.adVarWChar, 100, IsNull(Grd_Heures.Item("Source", i).Value, "SAISIE")},
                 {"p6", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                 {"p7", ADODB.DataTypeEnum.adInteger, 0, an},
                 {"p8", ADODB.DataTypeEnum.adInteger, 0, mo},
                 {"p9", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                 {"p10", ADODB.DataTypeEnum.adInteger, 0, an},
                 {"p11", ADODB.DataTypeEnum.adInteger, 0, mo},
                 {"p12", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                 {"p13", ADODB.DataTypeEnum.adDouble, 0, CDbl(Val(IsNull(Grd_Heures.Item("Heures", i).Value, 0)))},
                 {"p14", ADODB.DataTypeEnum.adVarWChar, 100, IsNull(Grd_Heures.Item("Source", i).Value, "SAISIE")},
                 {"p15", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}})
        Next
        Sante_Audit("MODI", "RH_Sante_Heures_Travaillees", Annee_txt.Text)
        ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
        Requesting()
    End Sub

    Private Sub Annee_txt_KeyUp(sender As Object, e As KeyEventArgs) Handles Annee_txt.KeyUp
        If e.KeyCode = Keys.Enter Then Requesting()
    End Sub

    Private Sub Refresh_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Refresh_Link.LinkClicked
        Requesting()
    End Sub
End Class
