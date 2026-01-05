

Public Class Demande_Doc_Admin
    Inherits Ecran
    Dim Save_D As ud_btn
    Dim Accepter_D As ud_btn
    Dim Rejeter_D As ud_btn
    Sub ChargementCombo()
        ' This method can be used to load any additional combo boxes if needed
        If Etat_Traitement_cbo.Items.Count = 0 Then Etat_Traitement_cbo.fromRubrique("Etat_Traitement")
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
            Accepter_D = dictButtons("Accepter_D")
            Rejeter_D = dictButtons("Rejeter_D")
        End If
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Demande_Doc_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargementCombo()
    End Sub

    Private Sub Request()
        ChargementCombo()
        Dim strSql As String = "Select *,dbo.FindRubrique(N'Statut_Signature', Statut) AS Signature FROM RH_Demande_Doc_Admin WHERE Num_Demande = '" & Num_Demande_txt.Text & "' AND id_Societe = " & Societe.id_Societe
        Dim dt As DataTable = DATA_READER_GRD(strSql)

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            Num_Demande_txt.Text = row("Num_Demande").ToString()
            Matricule_txt.Text = row("Matricule").ToString()
            Dat_Demande_txt.Text = CDate(row("Dat_Demande")).ToShortDateString()
            Commentaire_txt.Text = row("Commentaire").ToString()
            Statut_txt.Text = row("Signature").ToString()
            Etat_Traitement_cbo.SelectedValue = row("Etat_Traitement").ToString()
            statut_.Visible = (IsNull(row("Statut").ToString(), "") <> "VA" And IsNull(row("Statut").ToString(), "") <> "SG")
            ' Load Agent Name
            Dim agentSql As String = "SELECT Nom_Agent + ' ' + Prenom_Agent FROM RH_Agent WHERE Matricule = '" & row("Matricule") & "' AND id_Societe = " & Societe.id_Societe
            Dim dtAgent As DataTable = DATA_READER_GRD(agentSql)
            If dtAgent.Rows.Count > 0 Then
                Nom_Agent_Text.Text = dtAgent.Rows(0)(0).ToString()
            End If
            If (IsNull(row("Statut").ToString(), "") <> "VA" And IsNull(row("Statut").ToString(), "") <> "SG") OrElse (IsNull(row("Etat_Traitement").ToString(), "") <> "") Then
                Save_D.Enabled = False
                Accepter_D.Enabled = False
                Rejeter_D.Enabled = False
            Else
                Save_D.Enabled = True
                Accepter_D.Enabled = True
                Rejeter_D.Enabled = True
            End If
            ' Load Details
            Charger_Details(row("Num_Demande").ToString())
        End If
    End Sub

    Private Sub Charger_Details(numDemande As String)
        Dim strSql As String = "SELECT RowId,dbo.findRubrique('Typ_Doc_Admin',Typ_Doc) as Typ_Doc,Nbr_Exemplaire,Dat_Du,Dat_Au,Etat,Commentaire FROM RH_Demande_Doc_Admin_Detail 
                                WHERE Num_Demande = '" & numDemande & "' AND id_Societe = " & Societe.id_Societe
        Dim dt As DataTable = DATA_READER_GRD(strSql)

        Grd_Docs.Rows.Clear()

        ' Initialize Combo Items
        Dim colEtat As DataGridViewComboBoxColumn = CType(Grd_Docs.Columns("Etat_Ligne"), DataGridViewComboBoxColumn)
        Combo_GRD(colEtat, "colEtat_Traitement")

        ' Prevent error if Etat_Ligne column doesn't match data
        ' Assuming the grid is unbound fundamentally but populated here
        For Each row As DataRow In dt.Rows
            Dim idx As Integer = Grd_Docs.Rows.Add()
            Grd_Docs.Rows(idx).Cells("Typ_Doc").Value = row("Typ_Doc")
            Grd_Docs.Rows(idx).Cells("Nbr_Exemplaire").Value = row("Nbr_Exemplaire")
            If Not IsDBNull(row("Dat_Du")) Then Grd_Docs.Rows(idx).Cells("Dat_Du").Value = CDate(row("Dat_Du")).ToShortDateString()
            If Not IsDBNull(row("Dat_Au")) Then Grd_Docs.Rows(idx).Cells("Dat_Au").Value = CDate(row("Dat_Au")).ToShortDateString()

            Grd_Docs.Rows(idx).Cells("Commentaire").Value = row("Commentaire")

            ' Determine Etat if exists, else default or empty
            If dt.Columns.Contains("Etat") AndAlso Not IsDBNull(row("Etat")) Then
                Grd_Docs.Rows(idx).Cells("Etat_Ligne").Value = row("Etat")
            Else
                Grd_Docs.Rows(idx).Cells("Etat_Ligne").Value = ""
            End If
            Grd_Docs.Rows(idx).Tag = row("RowId")
        Next
    End Sub
    Sub Saving()
        If ShowMessageBox("Êtes-vous sûre de vouloir enregistrer ?", "Confirmation", MessageBoxButtons.OKCancel, msgIcon.Warning) = MsgBoxResult.Cancel Then
            Return
        End If
        If Num_Demande_txt.Text = "" Then
            ShowMessageBox("Le numéro de la demande est manquant.", "Erreur", MessageBoxButtons.OK, msgIcon.Error)
            Exit Sub
        End If
        If Grd_Docs.Rows.Count = 0 Then
            ShowMessageBox("Aucun document n'est associé à cette demande.", "Erreur", MessageBoxButtons.OK, msgIcon.Error)
            Exit Sub
        End If
        Dim etatLigne As String = ""
        Dim etatDemande As String = IsNull(Etat_Traitement_cbo.SelectedValue, "")
        With Grd_Docs
            .EndEdit(True)
            For i = 0 To .Rows.Count - 1
                If .Rows(i).IsNewRow Then Continue For
                If IsNull(.Rows(i).Cells("Etat_Ligne").Value, "") = "" Then
                    ShowMessageBox("L'état du document '" & .Rows(i).Cells("Typ_Doc").Value.ToString() & "' n'est pas défini.", "Erreur", MessageBoxButtons.OK, msgIcon.Error)
                    Exit Sub
                End If
                Dim newEtatligne As String = ""
                newEtatligne = IsNull(.Rows(i).Cells("Etat_Ligne").Value, "")
                If i = 0 Then
                    etatLigne = newEtatligne
                    etatDemande = newEtatligne
                End If
                If etatLigne <> newEtatligne And etatLigne <> "" Then
                    etatDemande = "AccepteP"
                End If
            Next
            If etatDemande = "" Then Return
            Dim strSql As String = "UPDATE RH_Demande_Doc_Admin SET Etat_Traitement = '" & etatDemande & "', Dat_Traitement = GETDATE() WHERE Num_Demande = '" & Num_Demande_txt.Text & "' AND id_Societe = " & Societe.id_Societe
            CnExecuting(strSql)
            For i = 0 To .Rows.Count - 1
                Dim newEtatligne = If(.Rows(i).Cells("Etat_Ligne").Value IsNot Nothing, .Rows(i).Cells("Etat_Ligne").Value.ToString(), "")
                Dim strSql0 As String = "UPDATE RH_Demande_Doc_Admin_Detail SET Etat = '" & newEtatligne & "' WHERE Num_Demande = '" & Num_Demande_txt.Text & "' and RowId='" & .Rows(i).Tag & "' AND id_Societe = " & Societe.id_Societe
                CnExecuting(strSql0)
            Next
            Request()
        End With
    End Sub
    Sub Accepter()
        Update_Etat("Traite")
    End Sub

    Sub Rejeter()
        Update_Etat("Rejete")
    End Sub

    Private Sub Update_Etat(etatGlobal As String)
        If ShowMessageBox("Voulez-vous vraiment définir l'état de la demande à : " & FindRubriques("Etat_Traitement", etatGlobal) & " ?", "Confirmation", MessageBoxButtons.YesNo, msgIcon.Question) = DialogResult.Yes Then

            ' 1. Update Global Status
            Dim strSql As String = "UPDATE RH_Demande_Doc_Admin SET Etat_Traitement = '" & etatGlobal & "', Dat_Traitement = GETDATE() WHERE Num_Demande = '" & Num_Demande_txt.Text & "' AND id_Societe = " & Societe.id_Societe
            CnExecuting(strSql)

            ' 2. Update Details
            For Each row As DataGridViewRow In Grd_Docs.Rows
                If row.IsNewRow Then Continue For

                Dim etatLigne As String = ""
                If row.Cells("Etat_Ligne").Value IsNot Nothing Then etatLigne = row.Cells("Etat_Ligne").Value.ToString()

                If etatGlobal = "Rejetee" Then
                    etatLigne = "Rejete"
                    row.Cells("Etat_Ligne").Value = "Rejete"
                ElseIf etatGlobal = "Traitee" Then
                    If etatLigne = "" Then
                        etatLigne = "Accepte"
                        row.Cells("Etat_Ligne").Value = "Accepte"
                    End If
                End If

                ' Update Detail in DB
                Dim typDoc As String = ""
                If row.Cells("Typ_Doc").Value IsNot Nothing Then typDoc = row.Cells("Typ_Doc").Value.ToString()

                Dim sqlDetail As String = "UPDATE RH_Demande_Doc_Admin_Detail SET Etat = '" & etatLigne & "' WHERE Num_Demande = '" & Num_Demande_txt.Text & "' AND Typ_Doc = '" & typDoc & "' AND id_Societe = " & Societe.id_Societe
                CnExecuting(sqlDetail)
            Next

            Etat_Traitement_cbo.Text = etatGlobal
            ShowMessageBox("Traitement enregistré avec succès.", "Information", MessageBoxButtons.OK, msgIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS030", Num_Demande_txt, Me)
    End Sub

    Private Sub Num_Demande_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Demande_txt.TextChanged
        Request()
    End Sub
End Class
