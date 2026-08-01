Public Class RH_Sante_Audit
    Friend swhere As String = " id_Societe=" & Societe.id_Societe

    Private Sub RH_Sante_Audit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Sante_CheckAccess("AUDIT", Me.Name) Then
            ShowMessageBox("Accès réservé à l'auditeur habilité.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
        Ges_Pie_Clt_GRD.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        If Action_cbo.Items.Count = 0 Then
            Action_cbo.Items.AddRange(New String() {"", "LECT", "CREA", "MODI", "SUPP", "IMPR", "EXPO", "TELE", "AUTH_KO"})
            Action_cbo.SelectedIndex = 0
        End If
        Dat_Debut.Text = Now.AddDays(-30).ToShortDateString
        Dat_Fin.Text = Now.ToShortDateString
    End Sub

    Sub Requesting()
        swhere = " id_Societe=" & Societe.id_Societe
        Cursor = Cursors.WaitCursor
        If Login_txt.Text.Trim <> "" Then
            swhere = swhere & " and Login_User like '%'+'" & Login_txt.Text.Trim & "'+'%' "
        End If
        If Action_cbo.SelectedIndex > 0 Then
            swhere = swhere & " and Action ='" & Action_cbo.Text & "'"
        End If
        If Objet_txt.Text.Trim <> "" Then
            swhere = swhere & " and Objet like '%'+'" & Objet_txt.Text.Trim & "'+'%' "
        End If
        If EstDate(Dat_Debut.Text) Then
            swhere = swhere & " and Dat_Action >= '" & Dat_Debut.Text & "'"
        End If
        If EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and Dat_Action <= dateadd(day,1,'" & Dat_Fin.Text & "')"
        End If

        Dim Cod_Sql As String =
            " SELECT TOP 500 Dat_Action as 'Date', Login_User as 'Utilisateur', Cod_Profile as 'Profil', Typ_Role as 'Rôle', " &
            " Action, Objet, Valeur_Index as 'Objet (id)', Matricule_Concerne as 'Matricule', " &
            " case when isnull(Succes,'false')='true' then 'Succès' else 'Échec' end as 'Résultat', Motif, Poste, IP " &
            " FROM RH_Sante_Audit_Acces where " & swhere & " Order by Dat_Action desc"

        Ges_Pie_Clt_GRD.DataSource = DATA_READER_GRD(Cod_Sql)
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_Debut, Me)
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Appel_Calender(Dat_Fin, Me)
    End Sub

    Private Sub Login_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Login_Link.LinkClicked
        Requesting()
    End Sub

    Private Sub Action_cbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Action_cbo.SelectedIndexChanged
        Requesting()
    End Sub
End Class
