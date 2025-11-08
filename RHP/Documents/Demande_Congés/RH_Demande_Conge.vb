Public Class RH_Demande_Conge
    Dim dme As New CongeDemande
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Valide_D As ud_btn
    Dim modeRequest As Boolean = False
    Private Sub RH_Demande_Conge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
        If CnExecuting("Select count(*) from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
        End If
        Chargement()

    End Sub
    Sub Chargement()
        If Save_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Valide_D = dictButtons("Valide_D")
        End If
        If Dat_Deb_am_pm_cbo.Items.Count = 0 Then
            Dat_Deb_am_pm_cbo.fromRubrique("am_pm")
            Dat_Deb_am_pm_cbo.SelectedValue = "am"
        End If
        If Dat_Fin_am_pm_cbo.Items.Count = 0 Then
            Dat_Fin_am_pm_cbo.fromRubrique("am_pm")
            Dat_Fin_am_pm_cbo.SelectedValue = "pm"
        End If
        If Not EstDate(Dat_Deb_Conge_txt.Text) Then Dat_Deb_Conge_txt.Text = Now.ToShortDateString
        If Not EstDate(Dat_Fin_Conge_txt.Text) Then Dat_Fin_Conge_txt.Text = Now.ToShortDateString
        Typ_Conge_txt.Text = "CAD"
        dme.agt.Matricule = Matricule_txt.Text
        If theUser.Typ_Role = "Agent" Then
            If theUser.Matricule <> Matricule_txt.Text And Matricule_txt.Text = "" Then
                Save_D.Visible = False
                Del_D.Visible = False
            Else
                Save_D.Visible = True
                Del_D.Visible = True
            End If
        End If
    End Sub
    Sub Request()
        modeRequest = True
        Chargement()
        pb_Valide.Visible = False
        Grd_Conge_Detail.Rows.Clear()
        dme.ent.Num_Conge = Num_Conge_txt.Text
        dme.Request()
        dme.setCalcul = False
        With dme.ent
            Dat_Deb_Conge_txt.Text = .Dat_Deb_Conge
            Dat_Deb_am_pm_cbo.SelectedValue = .Dat_Deb_am_pm
            Dat_Fin_Conge_txt.Text = .Dat_Fin_Conge
            Dat_Fin_am_pm_cbo.SelectedValue = .Dat_Fin_am_pm
            Matricule_txt.Text = .Matricule
            Duree_Globale_txt.Text = .Duree_Globale
            Repos_Hebdomadaire_txt.Text = .Repos_Hebdomadaire
            Jours_Feries_txt.Text = .Jours_Feries
            Duree_Conge_txt.Text = .Duree_Conge
            Commentaire_txt.Text = .Commentaire
            Typ_Conge_txt.Text = .Typ_Conge
            Poste_Text.Text = .Cod_Poste
            Cod_Entite_txt.Text = .Cod_Grade
            Cod_Entite_txt.Text = .Cod_Entite
            Titre_txt.Text = .Titre
            Cod_Plan_Paie_Text.Text = .Cod_Plan_Paie
            dme.setCalcul = True
            modeRequest = False
            calcul()
        End With
        Dim canModify As Boolean = (Num_Conge_txt.Text = "")
        With pb_Valide
            .Tag = ""
            Select Case IsNull(dme.ent.Statut, "")
                Case "SG"
                    .Image = My.Resources.valide01
                    .Tag = "SG"
                Case "RJ"
                    .Image = My.Resources.refuse
                    .Tag = "RJ"
            End Select
            .Visible = ("VA;SG;RJ".Split(";").Contains(IsNull(dme.ent.Statut, "")))
        End With
        canModify = (IsNull(dme.ent.Statut, "") = "")
        If IsNull(dme.ent.Statut, "") <> "" Then
            Save_D.Enabled = False
            Del_D.Enabled = False
            Valide_D.Enabled = False
        End If
        If canModify Then canModify = ((Matricule_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
        Save_D.Enabled = canModify
        Del_D.Enabled = canModify
        Valide_D.Enabled = canModify
    End Sub
    Function Valider()
        If ShowMessageBox("Etes-vous sûr de vouloir valider cette demande?", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = dme.Saving("VA")
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_Conge_txt.Text <> "" Then
            If Not ShowMessageBox("Vous ne pouvez pas modifier le matricule d'un congé créé." & vbCrLf & "Voulez-vous créer une nouvelle demande?", "Demande de congé", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Return
            Else
                Nouveau()
                Return
            End If
        End If
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Matricule_txt, Me)
        End If

    End Sub
    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent+ ' '+Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        If Num_Conge_txt.Text <> "" Then Return
        calcul()
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS019", Num_Conge_txt, Me, " Matricule = '" & Matricule_txt.Text & "'")
            End If
        Else
            Appel_Zoom1("MS019", Num_Conge_txt, Me)
        End If
    End Sub
    Private Sub Num_Conge_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Conge_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_Conge_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_Conge_txt.Text)
            Code = Num_Conge_txt.Text
        End If
    End Sub
    Private Sub Cod_Plan_Paie_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        Lib_Plan_Paie_Text.Text = FindLibelle("Lib_Plan_Paie", "Cod_Plan_Paie", Cod_Plan_Paie_Text.Text, "RH_Param_Plan_Paie")
        dme.ent.Cod_Plan_Paie = Cod_Plan_Paie_Text.Text
        calcul()
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Calender(Dat_Deb_Conge_txt, Me)
        dme.ent.Dat_Deb_Conge = IsNull(Dat_Deb_Conge_txt.Text, Now.ToShortDateString)
        calcul()
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Calender(Dat_Fin_Conge_txt, Me)
        dme.ent.Dat_Fin_Conge = IsNull(Dat_Fin_Conge_txt.Text, Now.ToShortDateString)
        calcul()
    End Sub
    Sub Enregistrer()
        Dim sRsl = dme.Saving("")
        ShowMessageBox(sRsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(sRsl.result, msgIcon.Information, msgIcon.Stop))
        If sRsl.result Then
            Num_Conge_txt.Text = dme.ent.Num_Conge
        End If
    End Sub

    Private Sub Poste_Text_TextChanged(sender As Object, e As EventArgs) Handles Poste_Text.TextChanged
        Lib_Poste_Text.Text = FindLibelle("Lib_Poste", "Cod_Poste", Poste_Text.Text, "Org_Poste")
        Grade_Text.Text = FindLibelle("Cod_Grade", "Cod_Poste", Poste_Text.Text, "Org_Poste")
    End Sub
    Private Sub Grade_Text_TextChanged(sender As Object, e As EventArgs) Handles Grade_Text.TextChanged
        Lib_Grade_Text.Text = FindLibelle("Lib_Grade", "Cod_Grade", Grade_Text.Text, "Org_Grade")
    End Sub
    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub
    Sub Deleting()
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette demande?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Conge_Suivi where Num_Conge='" & Num_Conge_txt.Text & "' and id_Societe=" & Societe.id_Societe _
      &
    " insert into  Mouchard_Suppression ( Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
values ('RH_Conge_Suivi','Num_Conge','" & Num_Conge_txt.Text & "','" & theUser.id_User & "', getdate())")
        Reset_Form(Me)
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
    End Sub
    Private Sub RH_Demande_Conge_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Request()
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then
            Matricule_txt.Text = theUser.Matricule
        End If
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Zoom1("MS165", Typ_Conge_txt, Me)
    End Sub
    Private Sub Typ_Conge_txt_TextChanged(sender As Object, e As EventArgs) Handles Typ_Conge_txt.TextChanged
        dme.ent.Typ_Conge = Typ_Conge_txt.Text
        With dme.Tbl_RH_Conge_Type
            If .Rows.Count > 0 Then
                Lib_Typ_Conge_txt.Text = IsNull(.Rows(0)("Lib_Typ_Conge"), "")
                dureeParDefaut_txt.Text = IsNull(.Rows(0)("dureeParDefaut"), "1")
                If Not IsNumeric(dureeParDefaut_txt.Text) Then dureeParDefaut_txt.Text = "1"
            Else
                Lib_Typ_Conge_txt.Text = ""
                dureeParDefaut_txt.Text = "1"
            End If
        End With
        calcul()
    End Sub

    Private Sub Dat_Deb_am_pm_cbo_DropDownClosed(sender As Object, e As EventArgs) Handles Dat_Deb_am_pm_cbo.DropDownClosed
        dme.ent.Dat_Deb_am_pm = Dat_Deb_am_pm_cbo.SelectedValue
        calcul()
    End Sub
    Private Sub Dat_fin_am_pm_cbo_DropDownClosed(sender As Object, e As EventArgs) Handles Dat_Fin_am_pm_cbo.DropDownClosed
        dme.ent.Dat_Fin_am_pm = Dat_Fin_am_pm_cbo.SelectedValue
        calcul()
    End Sub
    Private Sub Dat_Deb_Conge_txt_TextChanged(sender As Object, e As EventArgs) Handles Dat_Deb_Conge_txt.TextChanged
        If Not EstDate(Dat_Deb_Conge_txt.Text) Then Dat_Deb_Conge_txt.Text = Now.ToShortDateString
        dme.ent.Dat_Deb_Conge = Dat_Deb_Conge_txt.Text
        If Num_Conge_txt.Text = "" Then
            If Not EstDate(Dat_Fin_Conge_txt.Text) Or Dat_Fin_Conge_txt.Text = Now.ToShortDateString Then
                Dat_Fin_Conge_txt.Text = CDate(Dat_Deb_Conge_txt.Text).AddDays(1)
            ElseIf CDate(Dat_Fin_Conge_txt.Text) < CDate(Dat_Deb_Conge_txt.Text) Then
                Dat_Fin_Conge_txt.Text = CDate(Dat_Deb_Conge_txt.Text).AddDays(1)
            ElseIf math.Abs(DateDiff(DateInterval.Day, CDate(Dat_Deb_Conge_txt.Text), CDate(Dat_Fin_Conge_txt.Text))) > 30 Then
                Dat_Fin_Conge_txt.Text = CDate(Dat_Deb_Conge_txt.Text).AddDays(1)
            End If
        End If
        calcul()
    End Sub
    Private Sub Dat_Fin_Conge_txt_TextChanged(sender As Object, e As EventArgs) Handles Dat_Fin_Conge_txt.TextChanged
        If Not EstDate(Dat_Fin_Conge_txt.Text) Then Dat_Fin_Conge_txt.Text = Now.ToShortDateString
        dme.ent.Dat_Fin_Conge = Dat_Fin_Conge_txt.Text
        calcul()
    End Sub
    Sub calcul()
        If modeRequest Then Return
        If Save_D Is Nothing Then Return
        If Not Save_D.Enabled Then Return
        With dme
            With .ent
                dme.agt.Matricule = Matricule_txt.Text
                dme.Calcul()
                Duree_Conge_txt.Text = .Duree_Conge
                Duree_Globale_txt.Text = .Duree_Globale
                Jours_Feries_txt.Text = .Jours_Feries
                Repos_Hebdomadaire_txt.Text = .Repos_Hebdomadaire
            End With
            Grd_Conge_Detail.Rows.Clear()
            For i = 0 To .lig.Count - 1
                Grd_Conge_Detail.Rows.Add(.lig(i).Dat_Deb.ToShortDateString, .lig(i).Dat_Fin.ToShortDateString, .lig(i).Duree_Globale, .lig(i).Repos_Hebdomadaire, .lig(i).Jours_Feries, .lig(i).Duree_Conge)
            Next
            Cod_Entite_txt.Text = dme.agt.Cod_Entite
            Cod_Plan_Paie_Text.Text = dme.agt.Cod_Plan_Paie
            Poste_Text.Text = dme.agt.Cod_Poste
            Grade_Text.Text = dme.agt.Cod_Grade
            JourPaie_txt.Text = dme.ent.JourPaie
            LastDatePaie_txt.Text = dme.ent.LastDatePaie
            Titre_txt.Text = dme.ent.Titre
            Conge_Annuel_txt.Text = FormatDeNombre(.agt.Conge_Annuel, 2)
            Acquis_Anciennete_txt.Text = FormatDeNombre(.agt.Acquis_Anciennete, 2)
            Droit_Conge_txt.Text = FormatDeNombre(.agt.Droit_Conge, 2)
            Reliquat_Anterieurs_txt.Text = FormatDeNombre(.agt.Reliquat_Anterieurs, 2)
            Conge_Pris_txt.Text = FormatDeNombre(.agt.Conge_Pris, 2)
            Solde_Conge_txt.Text = FormatDeNombre(.agt.Solde_Conge, 2)
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        calcul()
    End Sub
    Private Sub Grd_Conge_Detail_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Conge_Detail.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        With Grd_Conge_Detail
            If e.ColumnIndex = Jours_Feries.Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
    Private Sub Grd_Conge_Detail_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Conge_Detail.CellMouseClick
        With Grd_Conge_Detail
            Dim oStr As String = ""
            If e.ColumnIndex = Jours_Feries.Index Then
                If IsNull(.CurrentCell.Value, 0) > 0 And EstDate(Dat_Deb_Conge_txt.Text) Then
                    Dim TblJourFeries As DataTable = DATA_READER_GRD("select * from dbo.Sys_JourFeries ('" & Dat_Deb_Conge_txt.Text & "' , " & Societe.id_Societe & ")")
                    Dim frw() As DataRow = TblJourFeries.Select("DatDeb >= '" & CDate(.Item(Dat_Deb.Index, e.RowIndex).Value) & "' and DatDeb <='" & CDate(.Item(Dat_Fin.Index, e.RowIndex).Value) & "' and Duree>0")
                    If frw.Length > 0 Then
                        For f = 0 To frw.Length - 1
                            oStr &= vbCrLf & "   - " & frw(f)("Lib_Jour") & " : " & frw(f)("DatDeb") & " au " & frw(f)("DatFin") & " : " & frw(f)("Duree")
                        Next
                    End If
                End If
            End If
            If oStr <> "" Then
                ShowMessageBox("Détail des jours fériés : " & oStr, "Détail des jours fériés", MessageBoxButtons.OK, msgIcon.Information)
            End If
        End With
    End Sub
#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        Return dme.Saving("")
    End Function
    Function requestAfterSignature() As Boolean
        dme.Request()
        Request()
        Return True
    End Function
#End Region
End Class