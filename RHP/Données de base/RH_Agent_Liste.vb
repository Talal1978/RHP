Public Class RH_Agent_Liste
    Friend swhere As String = " id_Societe=" & Societe.id_Societe
    Dim VenTbl As New DataTable
    Sub ChargementCombo()
        If Typ_Contrat.Items.Count = 0 Then
            Typ_Contrat.fromRubrique()
            Typ_Contrat.SelectedIndex = -1
        End If
        If Typ_Periode.Items.Count = 0 Then
            Typ_Periode.fromRubrique()
            Typ_Periode.SelectedIndex = -1
        End If
        If Droit_A_LaPaie.Items.Count = 0 Then
            Droit_A_LaPaie.fromRubrique()
            Droit_A_LaPaie.SelectedIndex = -1
        End If
    End Sub
    Private Sub Ges_Pie_Clt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChargementCombo()
        Ges_Pie_Clt_GRD.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Code_Client_Facture.LinkClicked
        Appel_Zoom1("MS010", Cod_Entite_txt, Me)
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
    Private Sub Ges_Pie_Clt_GRD_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Ges_Pie_Clt_GRD.CellContentClick
        If e.RowIndex < 0 Then Return
        If Ges_Pie_Clt_GRD.RowCount = 0 Then Return
        If e.ColumnIndex = Ges_Pie_Clt_GRD.Columns("Matricule").Index Then
            Dim f As New RH_Agent
            With f
                newShowEcran(f)
                .Matricule_Text.Text = Ges_Pie_Clt_GRD.Item("Matricule", e.RowIndex).Value
            End With
        End If
    End Sub

    Sub Requesting()
        swhere = " id_Societe=" & Societe.id_Societe
        Cursor = Cursors.WaitCursor
        ChargementCombo()

        Dim Cod_Sql As String = ""

        If Dat_Debut.Text <> "" Then
            swhere = swhere & " and convert(datetime,Dat_Entree) >= '" & Dat_Debut.Text & "'"
        End If
        If Dat_Fin.Text <> "" Then
            swhere = swhere & " and convert(datetime,Dat_Entree) <= '" & Dat_Fin.Text & "'"
        End If
        If Typ_Contrat.SelectedIndex >= 0 Then
            swhere = swhere & " and isnull(Typ_Contrat,'') ='" & Typ_Contrat.SelectedValue & "'"
        End If
        If Typ_Periode.SelectedIndex >= 0 Then
            swhere = swhere & " and isnull(Typ_Periode,'') ='" & Typ_Periode.SelectedValue & "'"
        End If
        If Cod_Plan_Paie_Text.Text <> "" Then
            swhere = swhere & " and isnull(Plan_Paie,'') ='" & Cod_Plan_Paie_Text.Text & "'"
        End If
        If Droit_A_LaPaie.SelectedIndex >= 0 Then
            Select Case Droit_A_LaPaie.SelectedValue
                Case "0"
                    swhere = swhere & " and isnull(Droit_Paie,'false') ='false'"
                Case "1"
                    swhere = swhere & " and isnull(Droit_Paie,'false') ='true'"
            End Select
        End If
        If Cod_Entite_txt.Text.Trim <> "" Then
            swhere = swhere & " and isnull(Cod_Entite,'') ='" & Cod_Entite_txt.Text & "'"
        End If
        Cod_Sql = "SELECT  Matricule,isnull(Civilite,'M.') as Civilité, upper( Nom_Agent+ ' '+ Prenom_Agent) as Nom, 
                  dbo.FindRubrique('Nationalite', a.Nationalite)  Nationalité,Dat_Naissance as 'Date de naissance',round(datediff(month,Dat_Naissance, getdate())*1.0/12,2) as Age,  
                    Adresse, Ville,dbo.FindRubrique('Situation', a.Situation) Situation , dbo.FindRubrique('Typ_Agent', a.Typ_Agent) 'Type',Typ_Contrat Contrat, Plan_Paie as 'Plan', Dat_Entree as 'Date entrée', 
                    Droit_Paie as 'Droit à la paie', 
                    dbo.FindRubrique('Typ_Periode', Typ_Periode) as Périodicité, Lib_Poste Poste, Lib_Grade Grade, Lib_Entite as Entité, 
                    CNSS 
                    FROM RH_Agent a
                          outer apply (select Lib_Entite from Org_Entite where id_Societe=a.id_Societe and Cod_Entite=a.Cod_Entite)e
						  outer apply (select Lib_Grade from Org_Grade where id_Societe=a.id_Societe and Cod_Grade=a.Cod_Grade)g
						  outer apply (select Lib_Poste from Org_Poste where id_Societe=a.id_Societe and Cod_Poste=a.Cod_Poste)p
                          outer apply (select Ville   from Param_Ville where Cod_Ville=isnull(a.Cod_Ville,''))v  
                    where " & swhere & " Order by Matricule,[Nom]"
        Dim Tbl0 As DataTable = DATA_READER_GRD(Cod_Sql)
        With Ges_Pie_Clt_GRD
            .DataSource = Tbl0
            .Columns("Date entrée").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Ges_Pie_Clt_GRD.setFilter({ .Columns("Matricule").Index, .Columns("Nom").Index, .Columns("Poste").Index,
                                .Columns("Nationalité").Index, .Columns("Age").Index, .Columns("Ville").Index, .Columns("Situation").Index, .Columns("Type").Index, .Columns("Contrat").Index, .Columns("Plan").Index, .Columns("Grade").Index})

        End With
        Cursor = Cursors.Default
    End Sub


    Private Sub LinkLabel17_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Reset_Form(Me)
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Typ_Periode.SelectedIndex = -1
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Droit_A_LaPaie.SelectedIndex = -1
    End Sub

    Private Sub Plan_Paie__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Plan_Paie_.LinkClicked
        Appel_Zoom1("MS069", Cod_Plan_Paie_Text, Me)
    End Sub

    Private Sub Cod_Plan_Paie_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        Lib_Plan_Paie_Text.Text = FindLibelle("Lib_Plan_Paie", "Cod_Plan_Paie", Cod_Plan_Paie_Text.Text, "RH_Param_Plan_Paie")
    End Sub

    Private Sub Ges_Pie_Clt_GRD_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Ges_Pie_Clt_GRD.CellMouseMove
        With Ges_Pie_Clt_GRD
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then
                .Cursor = Cursors.Default
            ElseIf .Columns("Matricule").Index = e.ColumnIndex Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub

    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Typ_Contrat.SelectedIndex = -1
    End Sub
End Class