Public Class RH_Sante_Param
    Dim Save_D As ud_btn

    Sub Chargement()
        If Save_D Is Nothing Then Save_D = dictButtons("Save_D")
        Grd_Reglement.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Private Sub RH_Sante_Param_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("ADMIN", Me.Name) Then
            ShowMessageBox("Accès non autorisé.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        Requesting()
    End Sub

    Sub Requesting()
        Chargement()
        ' Valeurs effectives des parametres reglementaires (globales -1 + societe) avec leur source
        Grd_Reglement.DataSource = DATA_READER_GRD(
            "select Cod_Param as 'Paramètre', Lib_Param as 'Libellé', " &
            " isnull((select top 1 v.Valeur from Param_Sante_Reglement v where v.Cod_Param=p.Cod_Param and v.id_Societe=" & Societe.id_Societe & "), p.Valeur) as 'Valeur effective', " &
            " Source_Reglementaire as 'Source réglementaire', Version_Texte as 'Version texte' " &
            " from Param_Sante_Reglement p where p.id_Societe=-1 order by Cod_Param")
        ' Surcharges de la societe courante (editables)
        Grd_Surcharges.DataSource = DATA_READER_GRD(
            "select Cod_Param, Valeur, Dat_Deb_Effet, Dat_Fin_Effet from Param_Sante_Reglement where id_Societe=" & Societe.id_Societe)
        Grd_Periodicites.DataSource = DATA_READER_GRD(
            "select Cod_Regle, Lib_Regle, Critere, Valeur_Critere, Periodicite_Mois, Priorite, Dat_Deb_Effet, Dat_Fin_Effet, Source_Reglementaire, Actif " &
            "from Param_Sante_Periodicite where id_Societe=" & Societe.id_Societe)
        Grd_Intervenants.DataSource = DATA_READER_GRD(
            "select Cod_Intervenant, Nom, Prenom, Typ_Intervenant, Specialite, Num_Ordre, Tel, Mail, Actif " &
            "from Param_Sante_Intervenant where id_Societe=" & Societe.id_Societe)
        Grd_Destinataires.DataSource = DATA_READER_GRD(
            "select Cod_Destinataire, Lib_Destinataire, Typ_Destinataire, Delai_Jours, Point_Depart, Source_Reglementaire, Actif " &
            "from Param_Sante_Destinataire where id_Societe=" & Societe.id_Societe)
        Grd_Etapes.DataSource = DATA_READER_GRD(
            "select Cod_Etape, Lib_Etape, Rang, Cod_Destinataire, Delai_Jours, Point_Depart, Source_Reglementaire, Actif " &
            "from Param_Sante_Etape_AT where id_Societe=" & Societe.id_Societe)
        Grd_Postes.DataSource = DATA_READER_GRD(
            "select Cod_Poste, Niveau_Risque, Expositions, Cod_Regle from Param_Sante_Poste_Risque where id_Societe=" & Societe.id_Societe)
        CNDP_txt.Text = "Autorisation CNDP (09-08, données sensibles de santé) : " &
            IIf(Sante_Param("CNDP_NUM_AUTORISATION", "") = "", "NON RENSEIGNÉE" & IIf(Sante_Param("BLOCAGE_PROD_SANS_CNDP", "O") = "O", " — le traitement clinique est BLOQUÉ", ""), Sante_Param("CNDP_NUM_AUTORISATION", "") & " du " & Sante_Param("CNDP_DATE_AUTORISATION", "?"))
    End Sub

    Sub Enregistrer()
        ' Surcharges des parametres reglementaires de la societe
        SaveTable("Param_Sante_Reglement", CType(Grd_Surcharges.DataSource, DataTable),
                  {"Cod_Param", "Valeur", "Dat_Deb_Effet", "Dat_Fin_Effet"}, "Cod_Param")
        SaveTable("Param_Sante_Periodicite", CType(Grd_Periodicites.DataSource, DataTable),
                  {"Cod_Regle", "Lib_Regle", "Critere", "Valeur_Critere", "Periodicite_Mois", "Priorite", "Dat_Deb_Effet", "Dat_Fin_Effet", "Source_Reglementaire", "Actif"}, "Cod_Regle")
        SaveTable("Param_Sante_Intervenant", CType(Grd_Intervenants.DataSource, DataTable),
                  {"Cod_Intervenant", "Nom", "Prenom", "Typ_Intervenant", "Specialite", "Num_Ordre", "Tel", "Mail", "Actif"}, "Cod_Intervenant")
        SaveTable("Param_Sante_Destinataire", CType(Grd_Destinataires.DataSource, DataTable),
                  {"Cod_Destinataire", "Lib_Destinataire", "Typ_Destinataire", "Delai_Jours", "Point_Depart", "Source_Reglementaire", "Actif"}, "Cod_Destinataire")
        SaveTable("Param_Sante_Etape_AT", CType(Grd_Etapes.DataSource, DataTable),
                  {"Cod_Etape", "Lib_Etape", "Rang", "Cod_Destinataire", "Delai_Jours", "Point_Depart", "Source_Reglementaire", "Actif"}, "Cod_Etape")
        SaveTable("Param_Sante_Poste_Risque", CType(Grd_Postes.DataSource, DataTable),
                  {"Cod_Poste", "Niveau_Risque", "Expositions", "Cod_Regle"}, "Cod_Poste")
        Sante_Audit("MODI", "RH_Sante_Param", "")
        ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
        Requesting()
    End Sub

    ''' <summary>Synchronisation d'une table de referentiel : delete (societe courante) + reinsertion (pattern recordset socle).</summary>
    Sub SaveTable(tblName As String, dt As DataTable, cols As String(), keyCol As String)
        If dt Is Nothing Then Return
        For Each ch In cols
            If Not dt.Columns.Contains(ch) Then Return
        Next
        Dim hasActif As Boolean = cols.Contains("Actif")
        CnExecuting("delete from " & tblName & " where id_Societe=" & Societe.id_Societe)
        Dim rs As New ADODB.Recordset
        For Each row As DataRow In dt.Rows
            If row.RowState = DataRowState.Deleted Then Continue For
            If IsNull(row(keyCol), "").ToString().Trim() = "" Then Continue For
            rs.Open("select * from " & tblName & " where 1=0", cn, 2, 2)
            rs.AddNew()
            For Each ch In cols
                If ch = "Actif" Then
                    rs(ch).Value = IIf(IsNull(row(ch), "true").ToString().ToLower() = "true" Or IsNull(row(ch), "").ToString() = "1", "true", "false")
                ElseIf IsDBNull(row(ch)) OrElse IsNull(row(ch), Nothing) Is Nothing Then
                    rs(ch).Value = DBNull.Value
                Else
                    rs(ch).Value = row(ch)
                End If
            Next
            rs("id_Societe").Value = Societe.id_Societe
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
            rs.Update()
            rs.Close()
        Next
    End Sub
End Class
