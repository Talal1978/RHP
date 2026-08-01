Public Class RH_Sante_Tableau_Bord

    Sub Chargement()
        Grd_Aptitudes.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Echeances.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Grd_Retards.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Private Sub RH_Sante_Tableau_Bord_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Dim seuil As Integer = CInt(Val(Sante_Param("SEUIL_AGREGAT_MIN", "5")))
        ' Agregats : les cellules sous le seuil sont masquees (anti-reidentification)
        Grd_Aptitudes.DataSource = DATA_READER_GRD(
            "select isnull(apt.Membre,'Sans visite') as 'Statut d''aptitude', v.Situation, " &
            " case when v.Effectif < " & seuil & " then '< " & seuil & "' else convert(nvarchar(10), v.Effectif) end as 'Effectif' " &
            " from RH_Sante_Vue_TB_Aptitudes v " &
            " outer apply (select Membre from Param_Rubriques where Nom_Controle='Statut_Aptitude' and Valeur=v.Statut_Aptitude) apt " &
            " where v.id_Societe=" & Societe.id_Societe)
        Seuil_txt.Text = "Agrégats masqués en dessous de " & seuil & " agents (paramètre SEUIL_AGREGAT_MIN)"

        ' Echeances de visites depassees ou proches (donnees medico-administratives, pas de clinique)
        Grd_Echeances.DataSource = DATA_READER_GRD(
            "select Matricule, Nom, Dat_Derniere_Visite as 'Dernière visite', Dat_Prochaine_Visite as 'Prochaine visite', " &
            " case Situation when 'ECHUE' then 'Échue' when 'PROCHE' then 'Proche (< 30 j)' when 'SANS_VISITE' then 'Sans visite' else Situation end as 'Situation' " &
            " from RH_Sante_Vue_Echeances where id_Societe=" & Societe.id_Societe & " and Situation in ('ECHUE','PROCHE','SANS_VISITE') " &
            " order by Dat_Prochaine_Visite")

        ' Alertes : etapes AT en retard + convocations non realisees + rappels vaccins
        Grd_Retards.DataSource = DATA_READER_GRD(
            "select 'Étape AT' as 'Alerte', e.Num_Declaration as 'Objet', e.Cod_Etape as 'Détail', e.Dat_Echeance as 'Échéance' " &
            "from RH_Declaration_AT_Echeance e where e.id_Societe=" & Societe.id_Societe & " and isnull(e.Statut_Etape,'AFA') in ('AFA','ENC') and e.Dat_Echeance < getdate() " &
            "union all " &
            "select 'Convocation non réalisée', c.Matricule, c.Cod_Campagne, c.Dat_Convocation " &
            "from RH_Sante_Convocation c where c.id_Societe=" & Societe.id_Societe & " and isnull(c.Statut_Convocation,'PRE') in ('PRE','ENV') and c.Dat_Convocation < getdate() " &
            "union all " &
            "select 'Rappel vaccin', v.Matricule, dbo.FindRubrique('Typ_Vaccin',v.Typ_Vaccin), v.Dat_Rappel " &
            "from RH_Sante_Vaccination v where v.id_Societe=" & Societe.id_Societe & " and v.Dat_Rappel is not null and v.Dat_Rappel < dateadd(day,30,getdate()) " &
            " order by 4")
        Sante_Audit("LECT", "RH_Sante_Tableau_Bord", "")
    End Sub

    Private Sub Refresh_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Refresh_Link.LinkClicked
        Requesting()
    End Sub

    Private Sub Grd_Echeances_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Echeances.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        If Not Sante_FonctionActive("SANTE_CLINIQUE") Then Return
        Dim f As New RH_Sante_Dossier
        With f
            .Matricule_txt.Text = IsNull(Grd_Echeances.Item("Matricule", e.RowIndex).Value, "")
            newShowEcran(f, True)
        End With
    End Sub
End Class
