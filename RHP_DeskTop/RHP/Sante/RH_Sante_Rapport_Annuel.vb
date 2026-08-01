Public Class RH_Sante_Rapport_Annuel
    Dim Controle_D As ud_btn
    Dim Valide_D As ud_btn

    Sub Chargement()
        If Controle_D Is Nothing Then
            Controle_D = dictButtons("Controle_D")
            Valide_D = dictButtons("Valide_D")
        End If
        Grd_Effectifs.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Visites.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_AT.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Anomalies.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Private Sub RH_Sante_Rapport_Annuel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("ADMIN", Me.Name) Then
            ShowMessageBox("Accès non autorisé.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        Annee_txt.Text = (Now.Year - 1).ToString()
        Requesting()
    End Sub

    Function Annee() As Integer
        Return CInt(Val(Annee_txt.Text))
    End Function

    Sub Requesting()
        Chargement()
        If Annee() < 2000 Then Return
        Dim an As String = Annee().ToString()
        ' Suivi (statut du rapport)
        Dim Tbl As DataTable = DATA_READER_GRD("select * from RH_Sante_Rapport_Annuel where Annee=" & an & " and id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count > 0 Then
            Statut_txt.Text = FindRubriques("Statut_Rapport_Annuel", IsNull(Tbl.Rows(0)("Statut"), "BROUILLON"))
        Else
            Statut_txt.Text = "Brouillon"
        End If
        ' Agregats (aucune donnee individuelle)
        Grd_Effectifs.DataSource = DATA_READER_GRD(
            "select isnull(Cod_Grade,'') as 'Catégorie', isnull(Sexe,'') as 'Sexe', count(*) as 'Effectif' " &
            "from RH_Agent where id_Societe=" & Societe.id_Societe & " group by Cod_Grade, Sexe order by Cod_Grade, Sexe")
        Grd_Visites.DataSource = DATA_READER_GRD(
            "select dbo.FindRubrique('Typ_Visite',Typ_Visite) as 'Type de visite', count(*) as 'Nombre' " &
            "from RH_Sante_Visite where id_Societe=" & Societe.id_Societe & " and year(Dat_Visite)=" & an & " and isnull(Statut,'') in ('VA','SG') " &
            "group by Typ_Visite")
        Grd_AT.DataSource = DATA_READER_GRD(
            "select isnull(Typ_Accident,'TRAVAIL') as 'Type', count(*) as 'Nombre', isnull(sum(j.Jours),0) as 'Jours d''arrêt' " &
            "from RH_Declaration_AT t " &
            "outer apply (select sum(d.Nbr_Jours) as Jours from RH_Declaration_AT_Detail d where d.Num_Declaration=t.Num_Declaration and d.id_Societe=t.id_Societe and isnull(d.Valide,'false')='true' and d.Dat_Debut_Arret is not null) j " &
            "where t.id_Societe=" & Societe.id_Societe & " and year(t.Dat_Accident)=" & an & " and isnull(t.Typ_Accident,'TRAVAIL')<>'NREC' " &
            "group by isnull(Typ_Accident,'TRAVAIL') " &
            "union all " &
            "select 'Maladies professionnelles ('+isnull(dbo.FindRubrique('Statut_Declaration_MP',Statut_Declaration),'')+')', count(*), 0 " &
            "from RH_Sante_Maladie_Pro where id_Societe=" & Societe.id_Societe & " and year(Dat_Declaration)=" & an & " group by Statut_Declaration")
        Sante_Audit("LECT", "RH_Sante_Rapport_Annuel", an)
    End Sub

    Sub ControlerDonnees()
        If Annee() < 2000 Then Return
        Dim an As String = Annee().ToString()
        Grd_Anomalies.DataSource = DATA_READER_GRD(
            "select 'Agent sans visite' as 'Anomalie', d.Matricule as 'Objet', '' as 'Détail' " &
            "from RH_Sante_Dossier d where d.id_Societe=" & Societe.id_Societe & " and isnull(d.Archive,'false')='false' and d.Dat_Derniere_Visite is null " &
            "union all " &
            "select 'Échéance dépassée', d.Matricule, convert(nvarchar(10), d.Dat_Prochaine_Visite, 103) " &
            "from RH_Sante_Dossier d where d.id_Societe=" & Societe.id_Societe & " and isnull(d.Archive,'false')='false' and d.Dat_Prochaine_Visite < datefromparts(" & an & ",12,31) " &
            "union all " &
            "select 'AT non clôturé', Num_Declaration, convert(nvarchar(10), Dat_Accident, 103) " &
            "from RH_Declaration_AT where id_Societe=" & Societe.id_Societe & " and year(Dat_Accident)=" & an & " and isnull(Cloture,'false')='false' " &
            "union all " &
            "select 'Visite validée sans aptitude', Num_Visite, Matricule " &
            "from RH_Sante_Visite where id_Societe=" & Societe.id_Societe & " and year(Dat_Visite)=" & an & " and isnull(Statut,'') in ('VA','SG') and isnull(Statut_Aptitude,'')=''")
        TabControl1.SelectedTab = Tab_Anomalies
        SaveStatut("CONTROLE")
    End Sub

    Sub Valider()
        If ShowMessageBox("Valider le rapport annuel " & Annee() & " ? La preuve de transmission sera exigée pour le statut Transmis.", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
        SaveStatut("VALIDE")
    End Sub

    Sub SaveStatut(statut As String)
        If Annee() < 2000 Then Return
        Dim fdPreuve As String = "null"
        If statut = "TRANSMIS" Then
            ShowMessageBox("Joignez la preuve de transmission via le bouton Pièces jointes, puis renseignez son identifiant.", "Transmis", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        Sante_Execute(
            "if exists(select Annee from RH_Sante_Rapport_Annuel where Annee=? and id_Societe=?) " &
            "update RH_Sante_Rapport_Annuel set Statut=?, Dat_Controle=case when ?='CONTROLE' then getdate() else Dat_Controle end, Dat_Validation=case when ?='VALIDE' then getdate() else Dat_Validation end, Dat_Modif=getdate(), Modified_By=? where Annee=? and id_Societe=? " &
            "else insert into RH_Sante_Rapport_Annuel (Annee, id_Societe, Statut, Dat_Controle, Dat_Validation, Version, Dat_Crea, Created_By) values (?, ?, ?, case when ?='CONTROLE' then getdate() else null end, case when ?='VALIDE' then getdate() else null end, 1, getdate(), ?)",
            {{"p1", ADODB.DataTypeEnum.adInteger, 0, Annee()},
             {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
             {"p3", ADODB.DataTypeEnum.adVarWChar, 10, statut},
             {"p4", ADODB.DataTypeEnum.adVarWChar, 10, statut},
             {"p5", ADODB.DataTypeEnum.adVarWChar, 10, statut},
             {"p6", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
             {"p7", ADODB.DataTypeEnum.adInteger, 0, Annee()},
             {"p8", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
             {"p9", ADODB.DataTypeEnum.adInteger, 0, Annee()},
             {"p10", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
             {"p11", ADODB.DataTypeEnum.adVarWChar, 10, statut},
             {"p12", ADODB.DataTypeEnum.adVarWChar, 10, statut},
             {"p13", ADODB.DataTypeEnum.adVarWChar, 10, statut},
             {"p14", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}})
        Sante_Audit("MODI", "RH_Sante_Rapport_Annuel", Annee().ToString(), "", True, "Statut=" & statut)
        Requesting()
    End Sub

    Private Sub Annee_txt_KeyUp(sender As Object, e As KeyEventArgs) Handles Annee_txt.KeyUp
        If e.KeyCode = Keys.Enter Then Requesting()
    End Sub

    Private Sub Refresh_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Refresh_Link.LinkClicked
        Requesting()
    End Sub
End Class
