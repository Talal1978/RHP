Public Class RH_Sante_Visite_Liste
    Friend swhere As String = " id_Societe=" & Societe.id_Societe

    Sub ChargementCombo()
        If Typ_Visite_cbo.Items.Count = 0 Then
            Typ_Visite_cbo.fromRubrique("Typ_Visite")
            Typ_Visite_cbo.SelectedIndex = -1
        End If
        If Statut_Aptitude_cbo.Items.Count = 0 Then
            Statut_Aptitude_cbo.fromRubrique("Statut_Aptitude")
            Statut_Aptitude_cbo.SelectedIndex = -1
        End If
        If Statut_cbo.Items.Count = 0 Then
            Statut_cbo.fromRubrique("Statut_Signature")
            Statut_cbo.SelectedIndex = -1
        End If
    End Sub

    Private Sub RH_Sante_Visite_Liste_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Sante_CheckAccess("ADMIN", Me.Name) Then
            ShowMessageBox("Accès non autorisé.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
        Ges_Pie_Clt_GRD.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        ChargementCombo()
    End Sub

    Sub Requesting()
        swhere = " id_Societe=" & Societe.id_Societe & IIf(theUser.Typ_Role = "Agent" And theUser.Matricule <> Matricule_txt.Text, " and " & String.Format(filtreUser, {"r"}), "")
        Cursor = Cursors.WaitCursor
        ChargementCombo()
        ' Cloisonnement : sans fonction CLINIQUE, la conclusion medicale n'est pas exposee
        Dim avecClinique As Boolean = Sante_FonctionActive("SANTE_CLINIQUE")
        If Matricule_txt.Text <> "" Then
            swhere = swhere & " and v.Matricule ='" & Matricule_txt.Text & "' "
        End If
        If Cod_Entite_txt.Text <> "" And theUser.Matricule <> Matricule_txt.Text Then
            swhere = swhere & " and exists(select Matricule from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule and isnull(Cod_Entite,'') ='" & Cod_Entite_txt.Text & "')"
        End If
        If EstDate(Dat_Debut.Text) And EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and Dat_Visite between '" & Dat_Debut.Text & "' and '" & Dat_Fin.Text & "' "
        ElseIf EstDate(Dat_Debut.Text) Then
            swhere = swhere & " and Dat_Visite >= '" & Dat_Debut.Text & "'"
        ElseIf EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and Dat_Visite <= '" & Dat_Fin.Text & "'"
        End If
        If Typ_Visite_cbo.SelectedIndex >= 0 Then
            swhere = swhere & " and isnull(Typ_Visite,'') ='" & Typ_Visite_cbo.SelectedValue & "'"
        End If
        If Statut_Aptitude_cbo.SelectedIndex >= 0 Then
            swhere = swhere & " and isnull(Statut_Aptitude,'') ='" & Statut_Aptitude_cbo.SelectedValue & "'"
        End If
        If Statut_cbo.SelectedIndex >= 0 Then
            swhere = swhere & " and isnull(Statut,'') ='" & Statut_cbo.SelectedValue & "'"
        End If

        Dim Cod_Sql As String =
            " SELECT Num_Visite as 'N° visite', v.Matricule, Nom, Dat_Visite as 'Date visite', " &
            " dbo.FindRubrique('Typ_Visite',Typ_Visite) as 'Type', dbo.FindRubrique('Statut_Aptitude',Statut_Aptitude) as 'Aptitude', " &
            IIf(avecClinique, " Conclusion, ", " '', ") &
            " Restrictions, Dat_Prochaine_Visite as 'Prochaine visite', dbo.FindRubrique('Statut_Signature',Statut) as Statut, " &
            " isnull(Lib_Entite,'') as 'Entité' " &
            " FROM RH_Sante_Visite v " &
            " outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom, Cod_Entite from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r " &
            " outer apply (select Lib_Entite from Org_Entite where id_Societe=v.id_Societe and Cod_Entite=r.Cod_Entite) e " &
            " where " & swhere & " Order by Dat_Visite desc"

        Dim Tbl0 As DataTable = DATA_READER_GRD(Cod_Sql)
        With Ges_Pie_Clt_GRD
            .DataSource = Tbl0
            If .Columns.Contains("Date visite") Then .Columns("Date visite").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If Matricule_txt.Text <> "" Then
                .Columns("Matricule").Visible = False
                .Columns("Nom").Visible = False
            End If
            Ges_Pie_Clt_GRD.setFilter({ .Columns("Matricule").Index, .Columns("Nom").Index, .Columns("Date visite").Index, .Columns("Entité").Index})
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub Entite_Link_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Code_Client_Facture.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS010", Cod_Entite_txt, Me, filtreEntite)
            End If
        Else
            Appel_Zoom1("MS010", Cod_Entite_txt, Me)
        End If
    End Sub

    Private Sub Cod_Entite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_Debut, Me)
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Appel_Calender(Dat_Fin, Me)
    End Sub

    Private Sub Ges_Pie_Clt_GRD_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Ges_Pie_Clt_GRD.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        If Ges_Pie_Clt_GRD.RowCount = 0 Then Return

        If e.ColumnIndex = Ges_Pie_Clt_GRD.Columns("Matricule").Index Then
            Dim f As New RH_Sante_Dossier
            With f
                .Matricule_txt.Text = Ges_Pie_Clt_GRD.Item("Matricule", e.RowIndex).Value
                newShowEcran(f, True)
            End With
        ElseIf e.ColumnIndex = Ges_Pie_Clt_GRD.Columns("N° visite").Index Then
            Dim f As New RH_Sante_Visite
            With f
                .Matricule_txt.Text = Ges_Pie_Clt_GRD.Item("Matricule", e.RowIndex).Value
                .Num_Visite_txt.Text = Ges_Pie_Clt_GRD.Item("N° visite", e.RowIndex).Value
                newShowEcran(f, True)
            End With
        End If
    End Sub

    Private Sub Matricule_Link_Click(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Matricule_txt, Me)
        End If
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        Cod_Entite_txt.Text = FindLibelle("Cod_Entite", "Matricule", Matricule_txt.Text, "RH_Agent")
    End Sub

    Private Sub ClearTyp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ClearTyp.LinkClicked
        Typ_Visite_cbo.SelectedIndex = -1
    End Sub

    Private Sub ClearApt_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ClearApt.LinkClicked
        Statut_Aptitude_cbo.SelectedIndex = -1
    End Sub

    Private Sub ClearStatut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ClearStatut.LinkClicked
        Statut_cbo.SelectedIndex = -1
    End Sub

    Sub Nouveau()
        Dim f As New RH_Sante_Visite
        With f
            .Matricule_txt.Text = theUser.Matricule
            newShowEcran(f)
        End With
    End Sub

    Private Sub Ges_Pie_Clt_GRD_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Ges_Pie_Clt_GRD.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        With Ges_Pie_Clt_GRD
            If e.ColumnIndex = .Columns("Matricule").Index Or e.ColumnIndex = .Columns("N° visite").Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
End Class
