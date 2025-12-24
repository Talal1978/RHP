Public Class RH_Discipline_Liste
    Friend swhere As String = " id_Societe=" & Societe.id_Societe

    Private Sub RH_Discipline_Liste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargementCombo()
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
        Discipline_GRD.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub

    Sub ChargementCombo()
        Typ_Sanction_cmb.fromRubrique("Sanctions")
        If Typ_Sanction_cmb.Items.Count > 0 Then
            Typ_Sanction_cmb.SelectedIndex = 0
        End If
    End Sub

    Sub Requesting()
        swhere = " d.id_Societe=" & Societe.id_Societe & IIf(theUser.Typ_Role = "Agent" And theUser.Matricule <> Matricule_txt.Text, " and " & String.Format(filtreUser, {"r"}), "")
        Cursor = Cursors.WaitCursor

        If Matricule_txt.Text <> "" Then
            swhere = swhere & " and d.Matricule ='" & Matricule_txt.Text & "' "
        End If

        If EstDate(Dat_Debut.Text) And EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and d.Dat_Faute between '" & Dat_Debut.Text & "' and '" & Dat_Fin.Text & "' "
        ElseIf EstDate(Dat_Debut.Text) Then
            swhere = swhere & " and d.Dat_Faute >= '" & Dat_Debut.Text & "'"
        ElseIf EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and d.Dat_Faute <= '" & Dat_Fin.Text & "'"
        End If

        If Typ_Sanction_cmb.SelectedIndex >= 0 Then
            swhere = swhere & " and d.Typ_Sanction ='" & Typ_Sanction_cmb.SelectedValue & "'"
        End If

        Dim Cod_Sql As String = "SELECT Cod_Sanction as Code, Lib_Sanction as Intitulé, d.Matricule, a.Nom_Agent + ' ' + a.Prenom_Agent as Nom, d.Dat_Faute as 'Date faute', d.Dat_Decision as 'Date décision', dbo.FindRubrique('Sanctions',d.Typ_Sanction) as Type, d.Motif " &
                                "FROM RH_Discipline d " &
                                "LEFT JOIN RH_Agent a ON d.Matricule = a.Matricule AND d.id_Societe = a.id_Societe " &
                                "WHERE " & swhere & " ORDER BY d.Dat_Faute DESC"
        GRD(Cod_Sql, Discipline_GRD)
        With Discipline_GRD
            .Columns("Date faute").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Date décision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub Discipline_GRD_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Discipline_GRD.CellDoubleClick
        If e.RowIndex < 0 Then Return
        If Discipline_GRD?.Rows.Count = 0 Then Return
        Dim f As New RH_Discipline
        f.Cod_Sanction_txt.Text = Discipline_GRD.Item("Code", e.RowIndex).Value
        f.Request()
        newShowEcran(f, True)
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
    End Sub

    Sub Nouveau()
        Dim f As New RH_Discipline
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
        Typ_Sanction_cmb.SelectedIndex = -1
    End Sub
    Private Sub Discipline_GRD_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Discipline_GRD.CellMouseMove
        If e.RowIndex < 0 Then Return
        With Discipline_GRD
            If .Rows.Count = 0 Then Return
            If e.ColumnIndex = 0 Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
End Class
