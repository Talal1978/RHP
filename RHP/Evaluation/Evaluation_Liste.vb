Public Class Evaluation_Liste
    Sub Chargement()
        If Statut_Evaluation.Items.Count = 0 Then
            Statut_Evaluation.fromRubrique("Statut_Evaluation")
            Statut_Evaluation.DataSource.rows.add("", "")
        End If
    End Sub
    Private Sub Evaluateur_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Evaluateur.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Evaluateur_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Evaluateur_txt, Me)
        End If
    End Sub

    Private Sub Evaluateur_txt_TextChanged(sender As Object, e As EventArgs) Handles Evaluateur_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom", "Matricule", Evaluateur_txt.Text, "Sys_RH_Preparation_Paie_Agent")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Evalue_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Evalue_txt, Me)
        End If
    End Sub

    Private Sub Evalue_txt_TextChanged(sender As Object, e As EventArgs) Handles Evalue_txt.TextChanged
        Nom_Evalue_txt.Text = FindLibelle("Nom", "Matricule", Evalue_txt.Text, "Sys_RH_Preparation_Paie_Agent")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS010", Cod_Entite_txt, Me, filtreEntite)
            End If
        Else
            Appel_Zoom1("MS010", Cod_Entite_txt, Me)
        End If
    End Sub

    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub

    Private Sub Grade__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Grade_.LinkClicked
        Appel_Zoom1("MS015", Cod_Grade_txt, Me)
    End Sub

    Private Sub Cod_Grade_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Grade_txt.TextChanged
        Lib_Grade_txt.Text = FindLibelle("Lib_Grade", "Cod_Grade", Cod_Grade_txt.Text, "Org_Grade")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Zoom1("MS158", Cod_Evaluation_txt, Me)
    End Sub

    Private Sub Cod_Evaluation_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Evaluation_txt.TextChanged
        Lib_Evaluation_txt.Text = FindLibelle("Description", "Cod_Evaluation", Cod_Evaluation_txt.Text, "Evaluation")
    End Sub

    Private Sub Evaluation_Liste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Statut_Evaluation.SelectedIndex = -1
        Chargement()
        If Evaluateur_txt.Text = "" And theUser.TeamLeader Then Evaluateur_txt.Text = theUser.Matricule
        If Evalue_txt.Text = "" And Not theUser.TeamLeader Then Evalue_txt.Text = theUser.Matricule
        Statut_Evaluation.SelectedIndex = -1
    End Sub

    Sub Requesting()
        Chargement()
        Dim swhere As String = " where id_Societe =" & Societe.id_Societe & " and (Dat_Du<='" & Dat_Au.Value & "' or Dat_Au>='" & Dat_Du.Value & "') "
        If Evaluateur_txt.Text <> "" Then swhere &= " and Cod_Evaluateur='" & Evaluateur_txt.Text & "'"
        If Evalue_txt.Text <> "" Then swhere &= " and Matricule='" & Evalue_txt.Text & "'"
        If Cod_Entite_txt.Text <> "" Then swhere &= " and isnull(Cod_Entite,'')='" & Cod_Entite_txt.Text & "'"
        If Cod_Grade_txt.Text <> "" Then swhere &= " and isnull(Cod_Grade,'')='" & Cod_Grade_txt.Text & "'"
        If Cod_Evaluation_txt.Text <> "" Then swhere &= " and isnull(Cod_Evaluation,'')='" & Cod_Evaluation_txt.Text & "'"
        If Statut_Evaluation.SelectedIndex > -1 And Statut_Evaluation.Text <> "" Then swhere &= " and isnull(Statut_Evaluation,'Planifiee')='" & Statut_Evaluation.SelectedValue & "'"
        If Rd1.Checked Then swhere &= " and nb = 0 "
        If Rd2.Checked Then swhere &= " and nb > 0 "
        swhere = "select Cod_Evaluation as 'Evaluation', Description,Cod_Evaluateur as 'Evaluateur', Nom_Evaluateur as 'Nom évaluateur',
Dat_Du as 'Du', Dat_Au as 'Au',Statut, Entite as Entité, Grade, Matricule, Nom, Poste,CONVERT(bit, case nb when 0 then 'false' else 'true' end) Evalue 
from Sys_Evaluation_Liste l
outer apply(select Membre as Statut from Param_Rubriques where Nom_Controle ='Statut_Evaluation' and Valeur=Statut_Evaluation)s
outer apply (select COUNT(*) as nb from Survey_Reply where id_Societe =l.id_Societe and Cod_Survey =l.Cod_Survey and ISNULL(Ref_Evaluation,'')=Cod_Evaluation and Typ_Evalue ='E' and Evalue =Matricule) v " & vbCrLf & swhere
        GRD(swhere, Grille)
        With Grille
            If Not .Columns.Contains("btn") Then
                Dim btn As New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
                With btn
                    .Width = 50
                    .Image = My.Resources.OF_Replanifie
                    .Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
                    .Name = "btn"
                    .HeaderText = ""
                End With
                .Columns.Insert(0, btn)
            End If
        End With
        Grille.setFilter({2, 11, 12, 4})
    End Sub
    Private Sub Dat_Du_ValueChanged(sender As Object, e As EventArgs) Handles Dat_Du.ValueChanged
        If Dat_Au.Value < Dat_Du.Value Then
            Dat_Au.Value = Dat_Du.Value.AddDays(7)
        End If
        Dat_Au.MinDate = Dat_Du.Value
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Statut_Evaluation.SelectedIndex = -1
    End Sub
    Private Sub Grille_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grille.CellClick
        With Grille
            If e.RowIndex < 0 Then Return
            If e.ColumnIndex < 0 Then Return
            If .RowCount <= 0 Then Return
            If Not .Columns.Contains("btn") Then Return
            If e.ColumnIndex = .Columns("btn").Index Then
                If IsNull(.Item("Statut", e.RowIndex).Value, "") <> "Validée" And IsNull(.Item("Statut", e.RowIndex).Value, "") <> "Clôturée" Then
                    ShowMessageBox("Action d'évaluation non encore validée.", "Lancement des évaluations", MessageBoxButtons.OK, msgIcon.Error)
                    Return
                End If

                Dim f As New Evaluation
                f.Cod_Evaluation_txt.Text = .Item("Evaluation", e.RowIndex).Value
                f.Lib_Evaluation_txt.Text = .Item("Description", e.RowIndex).Value
                f.Evaluateur_txt.Text = .Item("Evaluateur", e.RowIndex).Value
                f.Nom_Evaluateur_txt.Text = .Item("Nom évaluateur", e.RowIndex).Value
                f.Evalue_txt.Text = .Item("Matricule", e.RowIndex).Value
                f.Nom_Evalue_txt.Text = .Item("Nom", e.RowIndex).Value
                f.Request()
                If theUser.Login.ToUpper() <> "ADMIN" And theUser.Matricule <> f.Evaluateur_txt.Text Then
                    f.Save_pb.Enabled = False
                End If
                newShowEcran(f, True)
            End If
        End With
    End Sub
End Class