Public Class Org_Evolution_Carriere
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS067", Matricule_Text, Me)
    End Sub
    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_Text.TextChanged
        Nom_Agent_Text.Text = FindLibelle("upper(Nom_Agent+' ' +Prenom_Agent)", "Matricule", Matricule_Text.Text, "RH_Agent")
        Request()
    End Sub
    Sub Request()
        Dim SqlStr As String = "select convert(nvarchar(10), Dat,103) as 'Date',Titre, Cod_Poste as 'Code Poste',
                                Lib_Poste as 'Poste', Cod_Grade as 'Code Grade', Lib_Grade as Grade,
                                Cod_Entite as 'Code Entité', Lib_Entite as 'Entité', Affectation 
                                from dbo.Sys_Org_Evolution_Carriere ('" & Matricule_Text.Text & "'," & Societe.id_Societe & ")"
        With Ges_Pie_Clt_GRD
            .DataSource = DATA_READER_GRD(SqlStr)
        End With
        AfficherMasquerLesCode()
    End Sub

    Sub Requesting()
        If Matricule_Text.Text = "" Then
            ShowMessageBox("Sélectionnez un matricule", "Carrière", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Request()
    End Sub

    Private Sub Org_Evolution_Carriere_Load(sender As Object, e As EventArgs) Handles Me.Load
        With Ges_Pie_Clt_GRD
            .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        End With
    End Sub
    Sub AfficherMasquerLesCode()
        With Ges_Pie_Clt_GRD
            If .Columns.Count > 0 Then
                .Columns("Code Entité").Visible = AfficherCode_chk.Checked
                .Columns("Code Grade").Visible = AfficherCode_chk.Checked
                .Columns("Code Poste").Visible = AfficherCode_chk.Checked
            End If
        End With
    End Sub

    Private Sub AfficherCode_chk_CheckedChanged(sender As Object, e As EventArgs) Handles AfficherCode_chk.CheckedChanged
        AfficherMasquerLesCode()
    End Sub
End Class