Public Class RH_Avancement_Liste
    Friend swhere As String = " id_Societe=" & Societe.id_Societe

    Private Sub RH_Avancement_Liste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargementCombo()
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
        Avancement_GRD.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Sub ChargementCombo()
        Type_Avancement_cmb.fromRubrique("Avancement")
        If Type_Avancement_cmb.Items.Count > 0 Then
            Type_Avancement_cmb.SelectedIndex = 0
        End If
    End Sub

    Sub Requesting()
        swhere = " A.id_Societe=" & Societe.id_Societe & IIf(theUser.Typ_Role = "Agent" And theUser.Matricule <> Matricule_txt.Text, " and " & String.Format(filtreUser, {"r"}), "")
        Cursor = Cursors.WaitCursor
        
        If Matricule_txt.Text <> "" Then
            swhere = swhere & " and A.Matricule ='" & Matricule_txt.Text & "' "
        End If
        
        If EstDate(Dat_Debut.Text) And EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and A.Dat_Effet between '" & Dat_Debut.Text & "' and '" & Dat_Fin.Text & "' "
        ElseIf EstDate(Dat_Debut.Text) Then
            swhere = swhere & " and A.Dat_Effet >= '" & Dat_Debut.Text & "'"
        ElseIf EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and A.Dat_Effet <= '" & Dat_Fin.Text & "'"
        End If
        
        If Type_Avancement_cmb.SelectedIndex >= 0 Then
            swhere = swhere & " and A.Type_Avancement ='" & Type_Avancement_cmb.SelectedValue & "'"
        End If

        Dim Cod_Sql As String = "SELECT A.Cod_Avancement as Code, A.Matricule, P.Nom_Agent + ' ' + P.Prenom_Agent AS Nom, " &
                                "A.Dat_Effet as 'Date Effet', dbo.FindRubrique('Avancement', A.Type_Avancement) as 'Type Avanc.', " &
                                "A.Ancien_Poste, A.Nouveau_Poste, A.Statut " &
                                "FROM RH_Avancement A " &
                                "LEFT JOIN RH_Agent P ON A.Matricule = P.Matricule AND A.id_Societe = P.id_Societe " &
                                "WHERE " & swhere & " ORDER BY A.Dat_Effet DESC"

        GRD(Cod_Sql, Avancement_GRD)
        
        With Avancement_GRD
             .Columns("Date Effet").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
             .Columns("Statut").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub Avancement_GRD_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Avancement_GRD.CellDoubleClick
        If e.RowIndex < 0 Then Return
        If Avancement_GRD?.Rows.Count = 0 Then Return
        Dim f As New RH_Avancement
        f.Cod_Avancement_txt.Text = Avancement_GRD.Item("Code", e.RowIndex).Value
        f.Request()
        newShowEcran(f, True)
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' + Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
    End Sub

    Sub Nouveau()
        Dim f As New RH_Avancement
        f.Nouveau()
        newShowEcran(f)
    End Sub
    
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_Debut, Me)
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Appel_Calender(Dat_Fin, Me)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Type_Avancement_cmb.SelectedIndex = -1
    End Sub

    Private Sub Avancement_GRD_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Avancement_GRD.CellMouseMove
        If e.RowIndex < 0 Then Return
        With Avancement_GRD
            If .Rows.Count = 0 Then Return
            If e.ColumnIndex = 0 Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub

    Private Sub Avancement_GRD_MouseDown(sender As Object, e As MouseEventArgs) Handles Avancement_GRD.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim hti = Avancement_GRD.HitTest(e.X, e.Y)
            If hti.RowIndex >= 0 Then
                Avancement_GRD.ClearSelection()
                Avancement_GRD.Rows(hti.RowIndex).Selected = True
                
                Dim mnu As ContextMenuStrip = Avancement_GRD.ContextMenuStrip
                Dim item As ToolStripItem = mnu.Items.Add("Voir Timeline Carrière")
                AddHandler item.Click, AddressOf ShowTimeline
            End If
        End If
    End Sub

    Private Sub ShowTimeline(sender As Object, e As EventArgs)
        If Avancement_GRD.SelectedRows.Count = 0 Then Return
        Dim matricule As String = Avancement_GRD.SelectedRows(0).Cells("Matricule").Value.ToString()

        Dim f As New RH_Avancement_Timeline
        f.Matricule_txt.Text = matricule
        newShowEcran(f, True)
    End Sub
End Class
