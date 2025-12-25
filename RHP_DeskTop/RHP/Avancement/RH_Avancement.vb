Class RH_Avancement
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

    Private Sub RH_Avancement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Effet_txt.Text) Then Dat_Effet_txt.Text = Now.ToShortDateString
        If Not EstDate(Dat_Decision_txt.Text) Then Dat_Decision_txt.Text = Now.ToShortDateString
    End Sub

    Sub ChargementCombo()
        ' Manual population for Type Avancement
        If Type_Avancement_cmb.Items.Count = 0 Then Type_Avancement_cmb.fromRubrique("Avancement")
        If Type_Avancement_cmb.Items.Count > 0 And Cod_Avancement_txt.Text = "" Then Type_Avancement_cmb.SelectedIndex = 0
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS032", Cod_Avancement_txt, Me)
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Chargement()

        Dat_Decision_txt.Text = Now.Date.ToString("dd/MM/yyyy")
        Dat_Effet_txt.Text = Now.Date.ToString("dd/MM/yyyy")
        Type_Avancement_cmb.SelectedIndex = 0

        pb_Valide.Visible = False
        pb_Valide.Tag = ""

        ' Unlock fields that might be locked by BloquerChamps

        Save_D.Enabled = True
        Del_D.Enabled = True
        Valide_D.Enabled = True
        Lib_Avancement_txt.Select()
    End Sub

    Sub Request()
        Chargement()
        Dim SqlStr As String = "SELECT * FROM RH_Avancement WHERE Cod_Avancement='" & Cod_Avancement_txt.Text & "' AND id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        Dim canModify As Boolean = (Cod_Avancement_txt.Text = "")

        With Tbl
            If .Rows.Count > 0 Then
                Dim row As DataRow = .Rows(0)
                Matricule_txt.Text = IsNull(row("Matricule"), "")
                requestMatricule() ' Renamed from ChargerInfoAgent
                Lib_Avancement_txt.Text = IsNull(row("Lib_Avancement"), "")
                Dat_Decision_txt.Text = IsNull(row("Dat_Decision"), "")
                Dat_Effet_txt.Text = IsNull(row("Dat_Effet"), "")
                Type_Avancement_cmb.SelectedValue = IsNull(row("Type_Avancement"), "")

                Ancien_Poste_txt.Text = IsNull(row("Ancien_Poste"), "")
                Ancien_Grade_txt.Text = IsNull(row("Ancien_Grade"), "")
                Ancien_Titre_txt.Text = IsNull(row("Ancien_Titre"), "")
                Ancienne_Entite_txt.Text = IsNull(row("Ancienne_Entite"), "")
                Nouveau_Poste_txt.Text = IsNull(row("Nouveau_Poste"), "")
                Nouveau_Grade_txt.Text = IsNull(row("Nouveau_Grade"), "")
                Nouveau_Titre_txt.Text = IsNull(row("Nouveau_Titre"), "")
                Nouvelle_Entite_txt.Text = IsNull(row("Nouvelle_Entite"), "")
                Motif_txt.Text = IsNull(row("Motif"), "")
                Observation_txt.Text = IsNull(row("Observation"), "")

                With pb_Valide
                    .Tag = ""
                    Select Case IsNull(row("Statut"), "")
                        Case "VA" ' Validé
                            .Image = My.Resources.valide01
                            .Tag = "VA"
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

                If Not canModify Then
                    Save_D.Enabled = False
                    Del_D.Enabled = False
                    Valide_D.Enabled = False
                End If

            Else
                Nouveau()
            End If

            If canModify Then canModify = ((Matricule_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
            Save_D.Enabled = canModify
            Del_D.Enabled = canModify
            Valide_D.Enabled = canModify
        End With
    End Sub
    Sub MajPosition()
        Dim Sql As String = "SELECT Nom_Agent, Prenom_Agent, Cod_Poste, Cod_Grade, Titre, Cod_Entite,Dat_Entree FROM RH_Agent WHERE Matricule='" & Matricule_txt.Text & "' AND id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(Sql)
        If Tbl.Rows.Count > 0 Then
            Ancien_Poste_txt.Text = IsNull(Tbl.Rows(0)("Cod_Poste"), "")
            Ancien_Grade_txt.Text = IsNull(Tbl.Rows(0)("Cod_Grade"), "")
            Ancien_Titre_txt.Text = IsNull(Tbl.Rows(0)("Titre"), "")
            Ancienne_Entite_txt.Text = IsNull(Tbl.Rows(0)("Cod_Entite"), "")
            Nouveau_Poste_txt.Text = IsNull(Tbl.Rows(0)("Cod_Poste"), "")
            Nouveau_Grade_txt.Text = IsNull(Tbl.Rows(0)("Cod_Grade"), "")
            Nouveau_Titre_txt.Text = IsNull(Tbl.Rows(0)("Titre"), "")
            Nouvelle_Entite_txt.Text = IsNull(Tbl.Rows(0)("Cod_Entite"), "")
        ElseIf Matricule_txt.Text.Trim = "" Then
            Ancien_Poste_txt.Text = ""
            Lib_Ancien_Poste_txt.Text = ""
            Ancien_Grade_txt.Text = ""
            Lib_Ancien_Grade_txt.Text = ""
            Ancien_Titre_txt.Text = ""
            Ancienne_Entite_txt.Text = ""
            Lib_Ancienne_Entite_txt.Text = ""
            Nouveau_Poste_txt.Text = ""
            Nouveau_Grade_txt.Text = ""
            Nouveau_Titre_txt.Text = ""
            Nouvelle_Entite_txt.Text = ""
        End If
    End Sub
    Sub requestMatricule()
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent+ ' ' + Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        Dat_Entree_txt.Text = FindLibelle("Dat_Entree", "Matricule", Matricule_txt.Text, "RH_Agent")
        If Cod_Avancement_txt.Text = "" Then
            MajPosition()
        End If
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
        MajPosition()
    End Sub

    Private Sub Matricule_txt_Validated(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        If Matricule_txt.Text <> "" Then
            requestMatricule()
        End If
    End Sub
    ' Also handle TextChanged/Validated to fetch Libelle if typed manually
    Private Sub Nouveau_Poste_txt_Validated(sender As Object, e As EventArgs) Handles Nouveau_Poste_txt.TextChanged
        Lib_Nouveau_Poste_txt.Text = FindLibelle("Lib_Poste", "Cod_Poste", Nouveau_Poste_txt.Text, "Org_Poste")
    End Sub

    Private Sub Nouveau_Grade_txt_Validated(sender As Object, e As EventArgs) Handles Nouveau_Grade_txt.TextChanged
        Lib_Nouveau_Grade_txt.Text = FindLibelle("Lib_Grade", "Cod_Grade", Nouveau_Grade_txt.Text, "Org_Grade")
    End Sub

    Private Sub Nouvelle_Entite_txt_Validated(sender As Object, e As EventArgs) Handles Nouvelle_Entite_txt.TextChanged
        Lib_Nouvelle_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Nouvelle_Entite_txt.Text, "Org_Entite")
    End Sub
    Private Sub Ancien_Poste_txt_Validated(sender As Object, e As EventArgs) Handles Ancien_Poste_txt.TextChanged
        Lib_Ancien_Poste_txt.Text = FindLibelle("Lib_Poste", "Cod_Poste", Ancien_Poste_txt.Text, "Org_Poste")
    End Sub

    Private Sub Ancien_Grade_txt_Validated(sender As Object, e As EventArgs) Handles Ancien_Grade_txt.TextChanged
        Lib_Ancien_Grade_txt.Text = FindLibelle("Lib_Grade", "Cod_Grade", Ancien_Grade_txt.Text, "Org_Grade")
    End Sub

    Private Sub Ancienne_Entite_txt_Validated(sender As Object, e As EventArgs) Handles Ancienne_Entite_txt.TextChanged
        Lib_Ancienne_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Ancienne_Entite_txt.Text, "Org_Entite")
    End Sub
    Sub Enregistrer()
        Dim rsl As savingResult = Saving("")
        ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub

    Function Saving(statut As String) As savingResult
        Try
            If Matricule_txt.Text = "" Then
                Return New savingResult With {.result = False, .message = "Veuillez sélectionner un agent."}
            End If

            If pb_Valide.Visible And statut <> "VA" Then
                Return New savingResult With {.result = False, .message = "Ce document est déjà validé, modification impossible."}
            End If
            If EstDate(Dat_Entree_txt.Text) Then
                If CDate(Dat_Entree_txt.Text) > CDate(Dat_Effet_txt.Text) OrElse CDate(Dat_Entree_txt.Text) > CDate(Dat_Decision_txt.Text) Then
                    Return New savingResult With {.result = False, .message = "La date d'effet et la date de décision ne peuvent pas être antérieures à la date d'entrée."}
                End If
            End If
            If Not EstDate(Dat_Decision_txt.Text) Then
                Return New savingResult With {.result = False, .message = "La date de décision n'est pas valide."}
            End If
            If Not EstDate(Dat_Effet_txt.Text) Then
                Return New savingResult With {.result = False, .message = "La date d'effet n'est pas valide."}
            End If
            If CnExecuting("select count(*) from RH_Avancement where Matricule='" & Matricule_txt.Text & "' and Cod_Avancement<>'" & Cod_Avancement_txt.Text & "' and isnull(Statut,'')='' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
                Return New savingResult With {.result = False, .message = "Un autre avancement existe déjà pour cet agent non encore validé."}
            End If
            If CnExecuting("select count(*) from RH_Avancement where Matricule='" & Matricule_txt.Text & "' and Cod_Avancement<>'" & Cod_Avancement_txt.Text & "' and Dat_Effet>'" & Dat_Effet_txt.Text & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
                Return New savingResult With {.result = False, .message = "Un autre avancement existe déjà pour cet agent postérieur à celui-ci."}
            End If
            If CnExecuting("select count(*) from Org_Poste where Cod_Poste='" & Nouveau_Poste_txt.Text & "' and Cod_Grade='" & Nouveau_Grade_txt.Text & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
                Return New savingResult With {.result = False, .message = "Incohérence entre le poste et le grade."}
            End If
            If Nouveau_Grade_txt.Text = Ancien_Grade_txt.Text And Nouveau_Poste_txt.Text = Ancien_Poste_txt.Text And Nouveau_Titre_txt.Text = Ancien_Titre_txt.Text And Nouvelle_Entite_txt.Text = Ancienne_Entite_txt.Text Then
                Return New savingResult With {.result = False, .message = "Aucun changement n'a été effectué sur la position de l'agent."}
            End If
            Dim rangAncienGrade As Integer = CInt(FindLibelle("Niveau", "Cod_Grade", Ancien_Grade_txt.Text, "Org_Grade"))
            Dim rangNouveauGrade As Integer = CInt(FindLibelle("Niveau", "Cod_Grade", Nouveau_Grade_txt.Text, "Org_Grade"))
            If rangAncienGrade <> 0 And rangNouveauGrade <> 0 Then
                If rangNouveauGrade > rangAncienGrade Then
                    Return New savingResult With {.result = False, .message = "Le nouveau grade ne peut pas être inférieur à l'ancien grade."}
                End If
            End If
            Dim CodAvancement As String = Cod_Avancement_txt.Text

            ' Code Generation if empty
            If CodAvancement = "" Then
                Dim Cp As New ADODB.Recordset
                Cp = CnExecuting("Select isnull(max(convert(int,right(Cod_Avancement,6))),0) from RH_Avancement where id_Societe=" & Societe.id_Societe & " And year(Dat_Crea)=" & Now.Year)
                If Not Cp.EOF Then
                    CodAvancement = "UG" & Societe.id_Societe & "-" & CDate(Dat_Decision_txt.Text).Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
                Else
                    CodAvancement = "UG" & Societe.id_Societe & "-" & CDate(Dat_Decision_txt.Text).Year & "000001"
                End If
            End If

            Dim rs As New ADODB.Recordset
            rs.Open("Select * from RH_Avancement where Cod_Avancement='" & CodAvancement & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)

            If rs.EOF Then
                rs.AddNew()
                rs("Cod_Avancement").Value = CodAvancement
                rs("id_Societe").Value = Societe.id_Societe
                rs("Dat_Crea").Value = Now
                rs("Created_By").Value = theUser.Login
                rs("Statut").Value = "NV"
            Else
                rs("Dat_Modif").Value = Now
                rs("Modified_By").Value = theUser.Login
            End If
            rs("Lib_Avancement").Value = Lib_Avancement_txt.Text
            rs("Matricule").Value = Matricule_txt.Text
            rs("Dat_Decision").Value = Dat_Decision_txt.Text
            rs("Dat_Effet").Value = Dat_Effet_txt.Text
            rs("Type_Avancement").Value = Type_Avancement_cmb.SelectedValue

            rs("Ancien_Poste").Value = Ancien_Poste_txt.Text
            rs("Nouveau_Poste").Value = Nouveau_Poste_txt.Text
            rs("Ancien_Grade").Value = Ancien_Grade_txt.Text
            rs("Nouveau_Grade").Value = Nouveau_Grade_txt.Text
            rs("Ancien_Titre").Value = Ancien_Titre_txt.Text
            rs("Nouveau_Titre").Value = Nouveau_Titre_txt.Text
            rs("Ancienne_Entite").Value = Ancienne_Entite_txt.Text
            rs("Nouvelle_Entite").Value = Nouvelle_Entite_txt.Text

            rs("Motif").Value = Motif_txt.Text
            rs("Observation").Value = Observation_txt.Text
            rs("Statut").Value = statut
            rs.Update()
            rs.Close()

            If Cod_Avancement_txt.Text = "" Then
                Cod_Avancement_txt.Text = CodAvancement
            Else
                Request()
            End If

            Return New savingResult With {.result = True, .message = "Enregistrement effectué avec succès."}

        Catch ex As Exception
            Return New savingResult With {.result = False, .message = "Erreur : " & ex.Message}
        End Try
    End Function

    Sub Deleting()
        If Cod_Avancement_txt.Text = "" Then Return
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cet avancement?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return

        CnExecuting("delete from RH_Avancement where Cod_Avancement='" & Cod_Avancement_txt.Text & "' And id_Societe=" & Societe.id_Societe &
                " insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('RH_Avancement','Cod_Avancement','" & Cod_Avancement_txt.Text & "','" & theUser.Login & "', getdate())")

        Nouveau()
    End Sub
    Private Sub Cod_Avancement_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Avancement_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Cod_Avancement_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Avancement_txt.Text)
            Code = Cod_Avancement_txt.Text
        End If
    End Sub

    Private Sub RH_Avancement_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub

    Function Valider()
        If MsgBox("Etes-vous sûr de vouloir valider cet avancement ? Cela mettra à jour la fiche agent.", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Return False
        Dim rs = Saving("VA")
        If rs.result Then
            Request()
        Else
            ShowMessageBox(rs.message, "Validation", MessageBoxButtons.OK, msgIcon.Error)
        End If
        Return rs.result
    End Function

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS016", Nouveau_Poste_txt, Me, IIf(Nouveau_Grade_txt.Text = "", "", "Cod_Grade='" & Nouveau_Grade_txt.Text & "'"))
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Zoom1("MS015", Nouveau_Grade_txt, Me)
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Appel_Zoom1("MS010", Lib_Nouvelle_Entite_txt, Me)
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Calender(Dat_Decision_txt, Me)
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Appel_Calender(Dat_Effet_txt, Me)
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
