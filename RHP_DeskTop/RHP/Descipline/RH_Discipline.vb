
Public Class RH_Discipline
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Valide_D As ud_btn
    Sub Chargement()
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Valide_D = dictButtons("Valide_D")
        End If
        ChargementCombo()
    End Sub
    Function Valider()
        If ShowMessageBox("Etes-vous sûr de vouloir valider cette demande?", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving("VA")
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS029", Cod_Sanction_txt, Me)
    End Sub
    Private Sub RH_Discipline_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()

        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Faute_txt.Text) Then Dat_Faute_txt.Text = Now.ToShortDateString
        If Not EstDate(Dat_Decision_txt.Text) Then Dat_Decision_txt.Text = Now.ToShortDateString
        miseAJourVisibiliteChamps()
    End Sub

    Sub ChargementCombo()
        If Typ_Sanction_cmb.Items.Count = 0 Then Typ_Sanction_cmb.fromRubrique("Sanctions")
        If Typ_Sanction_cmb.Items.Count > 0 And Cod_Sanction_txt.Text = "" Then
            Typ_Sanction_cmb.SelectedIndex = 0
        End If
    End Sub
    Sub miseAJourVisibiliteChamps()
        Pnl_Duree.Visible = Typ_Sanction_cmb.SelectedValue = "MAP"
        Pnl_Affectation.Visible = Typ_Sanction_cmb.SelectedValue = "Trsf"
    End Sub
    Private Sub Typ_Sanction_cmb_DropDownClosed(sender As Object, e As EventArgs) Handles Typ_Sanction_cmb.DropDownClosed
        miseAJourVisibiliteChamps()
    End Sub
    Sub Request()
        Chargement()

        Dim SqlStr As String = "SELECT * FROM RH_Discipline where Cod_Sanction='" & Cod_Sanction_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        Dim canModify As Boolean = (Cod_Sanction_txt.Text = "")
        With Tbl
            If .Rows.Count > 0 Then
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                Lib_Sanction_txt.Text = IsNull(.Rows(0)("Lib_Sanction"), "")
                requestMatricule()
                Dat_Faute_txt.Text = IsNull(.Rows(0)("Dat_Faute"), "")
                Dat_Decision_txt.Text = IsNull(.Rows(0)("Dat_Decision"), "")
                Typ_Sanction_cmb.SelectedValue = IsNull(.Rows(0)("Typ_Sanction"), "")
                Motif_txt.Text = IsNull(.Rows(0)("Motif"), "")
                Duree_Sanction.Value = IsNull(.Rows(0)("Duree_Sanction"), 1)
                Cod_Poste_Transfert_txt.Text = IsNull(.Rows(0)("Cod_Poste_Transfert"), "")
                Affectation_Transfert_txt.Text = IsNull(.Rows(0)("Affectation_Transfert"), "")
                miseAJourVisibiliteChamps()
                Observation_txt.Text = IsNull(.Rows(0)("Observation"), "")
                Ref_PV_txt.Text = IsNull(.Rows(0)("Ref_PV"), "")
                With pb_Valide
                    .Tag = ""
                    Select Case IsNull(Tbl.Rows(0)("Statut"), "")
                        Case "SG"
                            .Image = My.Resources.valide01
                            .Tag = "SG"
                        Case "RJ"
                            .Image = My.Resources.refuse
                            .Tag = "RJ"
                    End Select
                    .Visible = ("VA;SG;RJ".Split(";").Contains(IsNull(Tbl.Rows(0)("Statut"), "")))
                    If IsNull(Tbl.Rows(0)("Statut"), "") <> "" Then
                        Save_D.Enabled = False
                        Del_D.Enabled = False
                        Valide_D.Enabled = False
                        canModify = False
                    Else
                        canModify = True
                    End If
                End With
            Else
                Nouveau()
            End If
            If canModify Then canModify = ((Matricule_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
            Save_D.Enabled = canModify
            Del_D.Enabled = canModify
            Valide_D.Enabled = canModify
        End With
    End Sub

    Sub requestMatricule()
        Dim SqlStr As String = "Select * from RH_Agent a where a.Matricule='" & Matricule_txt.Text & "' and a.id_Societe=" & Societe.id_Societe
        Dim CltTbl As DataTable = DATA_READER_GRD(SqlStr)
        If CltTbl.Rows.Count > 0 Then
            Nom_Agent_Text.Text = IsNull(CltTbl.Rows(0)("Nom_Agent"), "") & " " & IsNull(CltTbl.Rows(0)("Prenom_Agent"), "")
            Poste_Text.Text = IsNull(CltTbl.Rows(0)("Cod_Poste"), "")
            Cod_Entite_txt.Text = IsNull(CltTbl.Rows(0)("Cod_Entite"), "")
            Dat_Entree_txt.Text = IsNull(CltTbl.Rows(0)("Dat_Entree"), "")
        ElseIf Matricule_txt.Text.Trim = "" Then
            Nom_Agent_Text.Text = ""
            Poste_Text.Text = ""
            Cod_Entite_txt.Text = ""
            Dat_Entree_txt.Text = ""
        End If
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        requestMatricule()
    End Sub

    Private Sub Poste_Text_TextChanged(sender As Object, e As EventArgs) Handles Poste_Text.TextChanged
        Lib_Poste_Text.Text = FindLibelle("Lib_Poste", "Cod_Poste", Poste_Text.Text, "Org_Poste")
    End Sub

    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        Typ_Sanction_cmb.SelectedIndex = 0
        Dat_Faute_txt.Text = Now.ToShortDateString
        Dat_Decision_txt.Text = Now.ToShortDateString
        miseAJourVisibiliteChamps()
        Lib_Sanction_txt.Select()
    End Sub

    Sub Enregistrer()
        Dim rsl As savingResult = Saving("")
        ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub

    Function Saving(statut As String) As savingResult
        Try
            If Matricule_txt.Text = "" Then
                Return New savingResult With {.result = False, .message = "Matricule non renseigné"}
            End If
            If Typ_Sanction_cmb.SelectedIndex < 0 Then
                Return New savingResult With {.result = False, .message = "Type de sanction non renseigné"}
            End If
            If Not EstDate(Dat_Faute_txt.Text) Then
                Return New savingResult With {.result = False, .message = "Date de la faute invalide"}
            End If
            If Not EstDate(Dat_Decision_txt.Text) Then
                Return New savingResult With {.result = False, .message = "La date de décision n'est pas valide."}
            End If
            If EstDate(Dat_Entree_txt.Text) Then
                If CDate(Dat_Entree_txt.Text) > CDate(Dat_Faute_txt.Text) OrElse CDate(Dat_Entree_txt.Text) > CDate(Dat_Decision_txt.Text) Then
                    Return New savingResult With {.result = False, .message = "La date d'effet et la date de décision ne peuvent pas être antérieures à la date d'entrée."}
                End If
            End If
            Dim CodSanction As String = Cod_Sanction_txt.Text
            If CodSanction = "" Then
                Dim Cp As New ADODB.Recordset
                Cp = CnExecuting("select isnull(max(convert(int,right(Cod_Sanction,6))),0) from RH_Discipline where id_Societe=" & Societe.id_Societe & " and year(Dat_Crea)=" & Now.Year)
                If Not Cp.EOF Then
                    CodSanction = "SD" & Societe.id_Societe & "-" & CDate(Dat_Decision_txt.Text).Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
                Else
                    CodSanction = "SD" & Societe.id_Societe & "-" & CDate(Dat_Decision_txt.Text).Year & "000001"
                End If
            End If
            Dim rs As New ADODB.Recordset
            rs.Open("select * from RH_Discipline where  Cod_Sanction='" & CodSanction & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)

            If rs.EOF Then
                rs.AddNew()
                rs("Cod_Sanction").Value = CodSanction
                rs("id_Societe").Value = Societe.id_Societe
                rs("Dat_Crea").Value = Now
                rs("Created_By").Value = theUser.Login
            Else
                rs.Update()
            End If
            rs("Lib_Sanction").Value = Lib_Sanction_txt.Text
            rs("Matricule").Value = Matricule_txt.Text
            rs("Dat_Faute").Value = Dat_Faute_txt.Text
            rs("Dat_Decision").Value = Dat_Decision_txt.Text
            rs("Typ_Sanction").Value = Typ_Sanction_cmb.SelectedValue
            If Typ_Sanction_cmb.SelectedValue = "MAP" Then
                rs("Duree_Sanction").Value = Math.Max(Duree_Sanction.Value, 1)
            Else
                rs("Duree_Sanction").Value = 0
            End If
            If Typ_Sanction_cmb.SelectedValue = "Trsf" Then
                rs("Cod_Poste_Transfert").Value = Cod_Poste_Transfert_txt.Text
                rs("Affectation_Transfert").Value = Affectation_Transfert_txt.Text
            End If
            rs("Motif").Value = Motif_txt.Text
            rs("Observation").Value = Observation_txt.Text
            rs("Ref_PV").Value = Ref_PV_txt.Text
            rs("Dat_Modif").Value = Now
            rs("Modified_By").Value = theUser.Login
            rs("Statut").Value = statut
            rs.Update()
            rs.Close()
            If Cod_Sanction_txt.Text = "" Then
                Cod_Sanction_txt.Text = CodSanction
            Else
                Request()
            End If
            Return New savingResult With {.result = True, .message = "Enregistré avec succès."}
        Catch ex As Exception
            Return New savingResult With {.result = False, .message = ex.Message}
        End Try
    End Function

    Sub Deleting()
        If Cod_Sanction_txt.Text = "" Then Return
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette sanction?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return

        CnExecuting("delete from RH_Discipline where Cod_Sanction=" & Cod_Sanction_txt.Text & " And id_Societe=" & Societe.id_Societe &
                    " insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('RH_Discipline','Cod_Sanction','" & Cod_Sanction_txt.Text & "','" & theUser.Login & "', getdate())")

        Nouveau()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Calender(Dat_Faute_txt, Me)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Calender(Dat_Decision_txt, Me)
    End Sub

    Private Sub Cod_Sanction_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Sanction_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Cod_Sanction_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Sanction_txt.Text)
            Code = Cod_Sanction_txt.Text
        End If
    End Sub
    Private Sub RH_Demande_Conge_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Zoom1("MS016", Cod_Poste_Transfert_txt, Me)
    End Sub
    Private Sub Cod_Poste_Transfert_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Poste_Transfert_txt.TextChanged
        Lib_Poste_Transfert_txt.Text = FindLibelle("Lib_Poste", "Cod_Poste", Cod_Poste_Transfert_txt.Text, "Org_Poste")
    End Sub
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Appel_Rubrique("Affectation_1", Affectation_Transfert_txt, Me)
    End Sub
    Private Sub Affectation_Transfert_txt_TextChanged(sender As Object, e As EventArgs) Handles Affectation_Transfert_txt.TextChanged
        Lib_Affectation_Transfert_txt.Text = FindRubriques("Affectation_1", Affectation_Transfert_txt.Text)
    End Sub
#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        Return Saving("SS")
    End Function
    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function
#End Region
End Class
