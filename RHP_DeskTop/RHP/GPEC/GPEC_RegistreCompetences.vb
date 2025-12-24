Public Class GPEC_RegistreProfils

    Sub Requesting()
        Dim Cod_Sql = $"select Ressource,Matricule, Nom, Lib_Competence as 'Compétences',Sexe, Age as Âge, Commentaire, Dat_Candidature as 'Date candidature', 
Canal, Statut, Last_Formation as 'Dernière formation', Last_Experience as 'Dernière expérience' 
from dbo.Sys_GPEC_RegistreProfils('{Competences_txt.Tag}',{Societe.id_Societe},'{chk_interne.Checked}','{chk_externe.Checked}')"

        Dim Tbl0 As DataTable = DATA_READER_GRD(Cod_Sql)
        With Grille
            .DataSource = Tbl0
            .Columns("Date candidature").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Grille.setFilter({ .Columns("Matricule").Index, .Columns("Nom").Index, .Columns("Sexe").Index, .Columns("Compétences").Index, .Columns("Âge").Index, .Columns("Date candidature").Index,
                                .Columns("Canal").Index, .Columns("Statut").Index, .Columns("Dernière formation").Index, .Columns("Dernière expérience").Index})
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub Code_Client_Facture_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbl_lbl.LinkClicked

        Dim f As New Zoom_GPEC_Domaines_Competence
        Dim laListe = IsNull(Competences_txt.Tag, "").Split(";").ToList()
        Dim Tbl = DATA_READER_GRD($"select Domaines_Competence,Lib_Domaines_Competence from GPEC_Domaines_Competence where id_Societe={Societe.id_Societe}")
        With f
            .domaines = laListe
            .ShowDialog()
        End With
        With Competences_txt
            .Tag = ""
            .Text = ""
        End With
        For Each c In laListe
            Dim p = c.Split("$")(0)
            If Not String.IsNullOrWhiteSpace(p) Then
                Dim nrw() = Tbl.Select($"Domaines_Competence='{p}'")
                If nrw.Length > 0 Then
                    With Competences_txt
                        .Tag &= IIf(.Tag = "", "", ";") + p
                        .Text &= IIf(.Text = "", "", ";") + nrw(0)("Lib_Domaines_Competence")
                    End With
                End If
            End If
        Next
    End Sub

    Private Sub Grille_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grille.CellDoubleClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Or Grille.Rows.Count = 0 Then Return
        With Grille
            If e.ColumnIndex = .Columns("Matricule").Index Then
                If .Item("Ressource", e.RowIndex).Value = "Interne" Then
                    Dim f As New RH_Agent
                    With f
                        .Matricule_Text.Text = Grille.Item("Matricule", e.RowIndex).Value
                        newShowEcran(f, True)
                    End With
                ElseIf .Item("Ressource", e.RowIndex).Value = "Externe" Then
                    Dim f As New CVTheque
                    With f
                        .Matricule_Text.Text = Grille.Item("Matricule", e.RowIndex).Value
                        newShowEcran(f, True)
                    End With
                End If
            End If
        End With
    End Sub

    Private Sub Grille_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grille.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        With Grille
            If .DataSource Is Nothing Then Return
            If e.ColumnIndex = .Columns("Matricule").Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With

    End Sub
End Class