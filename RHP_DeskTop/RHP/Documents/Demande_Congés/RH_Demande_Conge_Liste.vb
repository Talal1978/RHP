Public Class RH_Demande_Conge_Liste
    Friend swhere As String = " id_Societe=" & Societe.id_Societe
    Dim VenTbl As New DataTable
    Sub ChargementCombo()
        If Statut_Conge.Items.Count = 0 Then
            Statut_Conge.fromRubrique("Statut_Signature")
            Statut_Conge.SelectedIndex = -1
        End If
    End Sub
    Private Sub Ges_Pie_Clt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
        Ges_Pie_Clt_GRD.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        ChargementCombo()
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Code_Client_Facture.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS010", Cod_Entite_txt, Me, filtreEntite)
            End If
        Else
            Appel_Zoom1("MS010", Cod_Entite_txt, Me)
        End If
    End Sub
    Private Sub Cod_Clt_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub
    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_Debut, Me)
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Appel_Calender(Dat_Fin, Me)
    End Sub
    Private Sub Ges_Pie_Clt_GRD_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Ges_Pie_Clt_GRD.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        If Ges_Pie_Clt_GRD.RowCount = 0 Then Return
        If e.ColumnIndex = Ges_Pie_Clt_GRD.Columns("Matricule").Index Then
            Dim f As New RH_Agent
            With f
                .Matricule_Text.Text = Ges_Pie_Clt_GRD.Item("Matricule", e.RowIndex).Value
                newShowEcran(f, True)
            End With
        ElseIf e.ColumnIndex = Ges_Pie_Clt_GRD.Columns("N° demande").Index Then
            Dim f As New RH_Demande_Conge
            With f
                .Num_Conge_txt.Text = Ges_Pie_Clt_GRD.Item("N° demande", e.RowIndex).Value
                newShowEcran(f, True)
            End With
        End If
    End Sub

    Sub Requesting()
        swhere = " id_Societe=" & Societe.id_Societe & IIf(theUser.Typ_Role = "Agent" And theUser.Matricule <> Matricule_txt.Text, " and " & String.Format(filtreUser, {"c"}), "")
        Cursor = Cursors.WaitCursor
        ChargementCombo()
        Dim Cod_Sql As String = ""
        If Matricule_txt.Text <> "" Then
            swhere = swhere & " and Matricule  ='" & Matricule_txt.Text & "' "
        End If

        If Cod_Entite_txt.Text <> "" And theUser.Matricule <> Matricule_txt.Text Then
            swhere = swhere & " and exists(select Matricule from RH_Agent where id_Societe=c.id_Societe and Matricule=c.Matricule and isnull(Cod_Entite,'') ='" & Cod_Entite_txt.Text & "')"
        End If
        If EstDate(Dat_Debut.Text) And EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and ( (Dat_Deb_Conge between '" & Dat_Debut.Text & "' and '" & Dat_Fin.Text & "') or (Dat_Fin_Conge between '" & Dat_Debut.Text & "' and '" & Dat_Fin.Text & "'))"
        ElseIf EstDate(Dat_Debut.Text) Then
            swhere = swhere & " and Dat_Fin_Conge >= '" & Dat_Debut.Text & "'"
        ElseIf EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and ((Dat_Deb_Conge <= '" & Dat_Fin.Text & "' and Dat_Fin_Conge>='" & Dat_Fin.Text & "') or Dat_Fin_Conge <= '" & Dat_Debut.Text & "')"
        End If
        If Statut_Conge.SelectedIndex >= 0 Then
            swhere = swhere & " and isnull(Statut,'') ='" & Statut_Conge.SelectedValue & "'"
        End If
        Cod_Sql = "  SELECT  Num_Conge 'N° demande', Matricule,Nom,dbo.FindRubrique('Statut_Signature',Statut) as Statut, Dat_Deb_Conge as 'Du', Dat_Fin_Conge as 'Au', 
Duree_Globale 'Durée totale', Repos_Hebdomadaire 'Repos hebdo.', 
Jours_Feries 'Jours fériés', Duree_Conge 'Congé',Entité, Commentaire

 from RH_Conge_Suivi c
 outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom from RH_Agent where id_Societe=c.id_Societe and Matricule=c.Matricule) r
 outer apply (select Lib_Entite as Entité from Org_Entite where id_Societe=c.id_Societe and Cod_Entite=c.Cod_Entite) o
where " & swhere & " Order by [Au] desc"
        Dim Tbl0 As DataTable = DATA_READER_GRD(Cod_Sql)
        With Ges_Pie_Clt_GRD
            .DataSource = Tbl0
            .Columns("Du").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Au").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Durée totale").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Repos hebdo.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Jours fériés").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Congé").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            If Matricule_txt.Text <> "" Then
                .Columns("Matricule").Visible = False
                .Columns("Nom").Visible = False
            End If
            Ges_Pie_Clt_GRD.setFilter({ .Columns("Matricule").Index, .Columns("Nom").Index, .Columns("Du").Index, .Columns("Au").Index,
                                .Columns("Durée totale").Index, .Columns("Congé").Index, .Columns("Jours fériés").Index, .Columns("Entité").Index})
        End With
        Cursor = Cursors.Default
    End Sub
    Private Sub LinkLabel17_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Reset_Form(Me)
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
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
    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Statut_Conge.SelectedIndex = -1
    End Sub
    Sub Nouveau()
        Dim f As New RH_Demande_Conge
        With f
            .Matricule_txt.Text = theUser.Matricule
            newShowEcran(f)
        End With
    End Sub

    Private Sub Ges_Pie_Clt_GRD_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Ges_Pie_Clt_GRD.CellMouseMove
        With Ges_Pie_Clt_GRD
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
                .Cursor = Cursors.Default
            ElseIf e.ColumnIndex = .Columns("N° demande").Index Or e.ColumnIndex = .Columns("Matricule").Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
End Class