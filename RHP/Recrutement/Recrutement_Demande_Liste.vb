Public Class Recrutement_Demande_Liste
    Friend swhere As String = " id_Societe=" & Societe.id_Societe
    Dim VenTbl As New DataTable
    Sub ChargementCombo()
        If Statut_Avance.Items.Count = 0 Then
            Statut_Avance.fromRubrique("Statut_Signature")
            Statut_Avance.SelectedIndex = -1
        End If
    End Sub
    Private Sub Ges_Pie_Clt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
        Grille.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
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
    Private Sub Ges_Pie_Clt_GRD_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grille.CellContentDoubleClick
        If e.RowIndex < 0 Then Return
        If Grille.RowCount = 0 Then Return
        If e.ColumnIndex = Grille.Columns("Matricule").Index Then
            Dim f As New RH_Agent
            With f
                .Matricule_Text.Text = Grille.Item("Matricule", e.RowIndex).Value
                newShowEcran(f, True)
            End With
        ElseIf e.ColumnIndex = Grille.Columns("N° demande").Index Then
            Dim f As New Recrutement_Demande
            With f
                .Matricule_txt.Text = Grille.Item("Matricule", e.RowIndex).Value
                .Num_DR_txt.Text = Grille.Item("N° demande", e.RowIndex).Value
                newShowEcran(f, True)
            End With
        End If
    End Sub
    Sub Requesting()
        swhere = " id_Societe=" & Societe.id_Societe & IIf(theUser.Typ_Role = "Agent" And theUser.Matricule <> Matricule_txt.Text, " and " & String.Format(filtreUser, {"r"}), "")
        Cursor = Cursors.WaitCursor
        ChargementCombo()
        Dim Cod_Sql As String = ""
        If Matricule_txt.Text <> "" Then
            swhere = swhere & " and Matricule  ='" & Matricule_txt.Text & "' "
        End If
        If Cod_Entite_txt.Text <> "" And (theUser.Matricule <> Matricule_txt.Text Or theUser.Typ_Role <> "Agent") Then
            swhere = swhere & " and exists(select Matricule from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule and isnull(Cod_Entite,'') ='" & Cod_Entite_txt.Text & "')"
        End If
        If EstDate(Dat_Debut.Text) And EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and  Dat_DR between '" & Dat_Debut.Text & "' and '" & Dat_Fin.Text & "' "
        ElseIf EstDate(Dat_Debut.Text) Then
            swhere = swhere & " and Dat_DR >= '" & Dat_Debut.Text & "'"
        ElseIf EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and Dat_DR <= '" & Dat_Fin.Text & "'"
        End If
        If Statut_Avance.SelectedIndex >= 0 Then
            swhere = swhere & " and isnull(Statut,'') ='" & Statut_Avance.SelectedValue & "'"
        End If
        Cod_Sql = "SELECT  Num_DR as 'N° demande', Matricule,Nom,dbo.FindRubrique('Statut_Signature',Statut) as Statut, Dat_DR as 'Date',Lib_DR as Intitulé, Lib_Entite as Entité,Titre_DR as Titre,  
isnull(Lib_Poste,'') as Poste,Lib_Grade as Grade, Nb_Personne as Nombre
FROM Recrutement_Demande v
outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom  from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
outer apply (select Lib_Entite from Org_Entite where id_Societe=v.id_Societe and Cod_Entite=v.Cod_Entite_DR) e
outer apply (select Lib_Poste from Org_Poste where id_Societe=v.id_Societe and Cod_Poste=Cod_Poste_DR) f
outer apply (select Lib_Grade from Org_Grade where id_Societe=v.id_Societe and Cod_Grade =Cod_Grade_DR) g 
where " & swhere & " Order by [Date] desc"
        Dim Tbl0 As DataTable = DATA_READER_GRD(Cod_Sql)
        With Grille
            .DataSource = Tbl0
            .Columns("Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If Matricule_txt.Text <> "" Then
                .Columns("Matricule").Visible = False
                .Columns("Nom").Visible = False
            End If
            Grille.setFilter({ .Columns("Matricule").Index, .Columns("Nom").Index, .Columns("Date").Index,
                                .Columns("Poste").Index, .Columns("Entité").Index, .Columns("Titre").Index, .Columns("Nombre").Index})

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
        Statut_Avance.SelectedIndex = -1
    End Sub
    Sub Nouveau()
        Dim f As New Recrutement_Demande
        With f
            .Matricule_txt.Text = theUser.Matricule
            newShowEcran(f)
        End With
    End Sub
    Private Sub Ges_Pie_Clt_GRD_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grille.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        With Grille
            If e.ColumnIndex = .Columns("Matricule").Index Or e.ColumnIndex = .Columns("N° demande").Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With

    End Sub
End Class