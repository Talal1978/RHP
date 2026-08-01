
Public Class RH_Outillage_Mouvement
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
        If Typ_Mouvement_cmb.Items.Count = 0 Then Typ_Mouvement_cmb.fromRubrique("Typ_Mouvement_Outillage")
    End Sub
    Private Sub RH_Outillage_Mouvement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Mouvement_txt.Text) Then Dat_Mouvement_txt.Text = Now.ToShortDateString
        If Typ_Mouvement_cmb.SelectedIndex < 0 And Typ_Mouvement_cmb.Items.Count > 0 Then Typ_Mouvement_cmb.SelectedIndex = 0
        With Grd_Detail
            .DefaultCellStyle.SelectionBackColor = colorBase04
        End With
        miseAJourEnteteQte()
    End Sub
    Sub miseAJourEnteteQte()
        Qte_Dispo.HeaderText = IIf(Typ_Mouvement_cmb.SelectedValue = "R", "Qté détenue", "Qté disponible")
    End Sub
    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        Dim canModify As Boolean = (Num_Mouvement_txt.Text = "")
        Dim SqlStr As String = "SELECT * FROM RH_Outillage_Mouvement where Num_Mouvement='" & Num_Mouvement_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        With Tbl
            If .Rows.Count > 0 Then
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                requestMatricule()
                Dat_Mouvement_txt.Text = IsNull(.Rows(0)("Dat_Mouvement"), "")
                Typ_Mouvement_cmb.SelectedValue = IsNull(.Rows(0)("Typ_Mouvement"), "")
                Commentaire_txt.Text = IsNull(.Rows(0)("Commentaire"), "")
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
            ElseIf Num_Mouvement_txt.Text.Trim = "" Then
                Nouveau()
            End If
            ' Chargement du détail
            Dim TblDet As DataTable = DATA_READER_GRD("select d.Cod_Outillage, o.Lib_Outillage, o.Typ_Outillage, o.Num_Serie, " &
                                                      " case h.Typ_Mouvement when 'R' then agt.Qte_Detenus else disp.Qte_Disponible end as Qte_Ref, d.Qte, d.RowId " &
                                                      " from RH_Outillage_Mouvement_Detail d " &
                                                      " inner join RH_Outillage_Mouvement h on h.Num_Mouvement=d.Num_Mouvement and h.id_Societe=d.id_Societe " &
                                                      " left join RH_Outillage o on o.Cod_Outillage=d.Cod_Outillage and o.id_Societe=d.id_Societe " &
                                                      " left join RH_Outillage_Dispo disp on disp.Cod_Outillage=d.Cod_Outillage and disp.id_Societe=d.id_Societe " &
                                                      " left join RH_Outillage_Agent agt on agt.Cod_Outillage=d.Cod_Outillage and agt.id_Societe=d.id_Societe and agt.Matricule=h.Matricule " &
                                                      " where d.Num_Mouvement='" & Num_Mouvement_txt.Text & "' and d.id_Societe=" & Societe.id_Societe)
            With TblDet
                Grd_Detail.Rows.Clear()
                If Grd_Detail.Columns.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        Grd_Detail.Rows.Add(.Rows(i)("Cod_Outillage"), IsNull(.Rows(i)("Lib_Outillage"), ""), IsNull(.Rows(i)("Typ_Outillage"), ""), IsNull(.Rows(i)("Num_Serie"), ""), IsNull(.Rows(i)("Qte_Ref"), 0), .Rows(i)("Qte"))
                        Grd_Detail.Rows(i).Tag = .Rows(i)("RowId")
                    Next
                End If
            End With
            If canModify Then canModify = ((Matricule_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
            Save_D.Enabled = canModify
            Del_D.Enabled = canModify And Num_Mouvement_txt.Text <> ""
            Valide_D.Enabled = canModify
        End With
        miseAJourEnteteQte()
    End Sub
    Sub requestMatricule()
        Dim SqlStr As String = "Select * from RH_Agent a where a.Matricule='" & Matricule_txt.Text & "' and a.id_Societe=" & Societe.id_Societe
        Dim CltTbl As DataTable = DATA_READER_GRD(SqlStr)
        If CltTbl.Rows.Count > 0 Then
            Nom_Agent_Text.Text = IsNull(CltTbl.Rows(0)("Nom_Agent"), "") & " " & IsNull(CltTbl.Rows(0)("Prenom_Agent"), "")
            Poste_Text.Text = IsNull(CltTbl.Rows(0)("Cod_Poste"), "")
            Cod_Entite_txt.Text = IsNull(CltTbl.Rows(0)("Cod_Entite"), "")
        ElseIf Matricule_txt.Text.Trim = "" Then
            Nom_Agent_Text.Text = ""
            Poste_Text.Text = ""
            Cod_Entite_txt.Text = ""
        End If
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Grd_Detail.Rows.Clear()
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        Dat_Mouvement_txt.Text = Now.ToShortDateString
        If Typ_Mouvement_cmb.Items.Count > 0 Then Typ_Mouvement_cmb.SelectedIndex = 0
        pb_Valide.Visible = False
        miseAJourEnteteQte()
    End Sub
    Sub Enregistrer()
        Dim rsl As savingResult = Saving("")
        ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub
    Function QteReferenceHorsDocument(codOutillage As String) As Double
        ' Quantité disponible (affectation) ou détenue (retrait) en excluant les lignes déjà enregistrées du mouvement en cours
        Dim sqlStr As String = ""
        If Typ_Mouvement_cmb.SelectedValue = "R" Then
            sqlStr = "select isnull((select Qte_Detenus from RH_Outillage_Agent where Cod_Outillage='" & codOutillage & "' and Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe & "),0)" &
                     " + isnull((select sum(dd.Qte) from RH_Outillage_Mouvement_Detail dd inner join RH_Outillage_Mouvement hh on hh.Num_Mouvement=dd.Num_Mouvement and hh.id_Societe=dd.id_Societe " &
                     " where hh.Num_Mouvement='" & Num_Mouvement_txt.Text & "' and hh.Typ_Mouvement='R' and dd.Cod_Outillage='" & codOutillage & "' and dd.id_Societe=" & Societe.id_Societe & "),0)"
        Else
            sqlStr = "select isnull((select Qte_Disponible from RH_Outillage_Dispo where Cod_Outillage='" & codOutillage & "' and id_Societe=" & Societe.id_Societe & "),0)" &
                     " + isnull((select sum(dd.Qte) from RH_Outillage_Mouvement_Detail dd inner join RH_Outillage_Mouvement hh on hh.Num_Mouvement=dd.Num_Mouvement and hh.id_Societe=dd.id_Societe " &
                     " where hh.Num_Mouvement='" & Num_Mouvement_txt.Text & "' and hh.Typ_Mouvement='A' and dd.Cod_Outillage='" & codOutillage & "' and dd.id_Societe=" & Societe.id_Societe & "),0)"
        End If
        Dim rsl = CnExecuting(sqlStr)
        If rsl.EOF Then Return 0
        Return CDbl(IsNull(rsl.Fields(0).Value, 0))
    End Function
    Function Saving(statut As String) As savingResult
        Try
            If Matricule_txt.Text = "" Then
                Return New savingResult With {.result = False, .message = "Matricule non renseigné"}
            End If
            If Typ_Mouvement_cmb.SelectedIndex < 0 Then
                Return New savingResult With {.result = False, .message = "Type de mouvement non renseigné"}
            End If
            If Not EstDate(Dat_Mouvement_txt.Text) Then
                Return New savingResult With {.result = False, .message = "Date du mouvement invalide"}
            End If
            ' Regroupement des lignes par outillage
            Dim dictLignes As New Dictionary(Of String, Double)
            With Grd_Detail
                For i = 0 To .RowCount - 2
                    Dim cod As String = IsNull(.Item(Cod_Outillage.Index, i).Value, "")
                    If cod <> "" Then
                        If Not IsNumeric(.Item(Qte.Index, i).Value) OrElse CDbl(.Item(Qte.Index, i).Value) <= 0 Then
                            Return New savingResult With {.result = False, .message = "Quantité invalide pour l'outillage : " & cod}
                        End If
                        If dictLignes.ContainsKey(cod) Then
                            dictLignes(cod) += CDbl(.Item(Qte.Index, i).Value)
                        Else
                            dictLignes.Add(cod, CDbl(.Item(Qte.Index, i).Value))
                        End If
                    End If
                Next
            End With
            If dictLignes.Count = 0 Then
                Return New savingResult With {.result = False, .message = "Aucune ligne d'outillage/matériel saisie"}
            End If
            ' Contrôle des quantités
            For Each lig In dictLignes
                If Typ_Mouvement_cmb.SelectedValue = "R" Then
                    If lig.Value > QteReferenceHorsDocument(lig.Key) Then
                        Return New savingResult With {.result = False, .message = "Quantité retirée supérieure à la quantité détenue par l'agent pour : " & lig.Key}
                    End If
                Else
                    If lig.Value > QteReferenceHorsDocument(lig.Key) Then
                        Return New savingResult With {.result = False, .message = "Quantité affectée supérieure à la quantité disponible pour : " & lig.Key}
                    End If
                End If
            Next
            Dim NumMouvement As String = Num_Mouvement_txt.Text
            If NumMouvement = "" Then
                Dim Cp As New ADODB.Recordset
                Cp = CnExecuting("select isnull(max(convert(int,right(Num_Mouvement,6))),0) from RH_Outillage_Mouvement where id_Societe=" & Societe.id_Societe & " and year(Dat_Crea)=" & CDate(Dat_Mouvement_txt.Text).Year)
                NumMouvement = "OTM" & Societe.id_Societe & "-" & CDate(Dat_Mouvement_txt.Text).Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
            End If
            Dim rs As New ADODB.Recordset
            rs.Open("select * from RH_Outillage_Mouvement where Num_Mouvement='" & NumMouvement & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Num_Mouvement").Value = NumMouvement
                rs("id_Societe").Value = Societe.id_Societe
                rs("Dat_Crea").Value = Now
                rs("Created_By").Value = theUser.Login
            Else
                rs.Update()
            End If
            rs("Typ_Mouvement").Value = Typ_Mouvement_cmb.SelectedValue
            rs("Matricule").Value = Matricule_txt.Text
            rs("Dat_Mouvement").Value = Dat_Mouvement_txt.Text
            rs("Commentaire").Value = Commentaire_txt.Text
            rs("Dat_Modif").Value = Now
            rs("Modified_By").Value = theUser.Login
            rs("Statut").Value = statut
            rs.Update()
            rs.Close()
            ' Détail
            With Grd_Detail
                Dim swhere = ""
                For i = 0 To .RowCount - 2
                    If Not IsNull(.Rows(i).Tag, "") = "" Then
                        swhere &= IIf(swhere = "", "", ",") & .Rows(i).Tag
                    End If
                Next
                If swhere.Trim <> "" Then
                    CnExecuting("delete from RH_Outillage_Mouvement_Detail where Num_Mouvement='" & NumMouvement & "' and id_Societe=" & Societe.id_Societe & " and RowId not in (" & swhere & ")")
                Else
                    CnExecuting("delete from RH_Outillage_Mouvement_Detail where Num_Mouvement='" & NumMouvement & "' and id_Societe=" & Societe.id_Societe)
                End If
                For i = 0 To .RowCount - 2
                    If Not IsNull(.Item(Cod_Outillage.Index, i).Value, "") = "" And IsNumeric(.Item(Qte.Index, i).Value) Then
                        rs.Open("select * from RH_Outillage_Mouvement_Detail where Num_Mouvement='" & NumMouvement & "' and id_Societe=" & Societe.id_Societe & " and RowId='" & IsNull(.Rows(i).Tag, "") & "'", cn, 2, 2)
                        If rs.EOF Then
                            rs.AddNew()
                            rs("Num_Mouvement").Value = NumMouvement
                            rs("id_Societe").Value = Societe.id_Societe
                        Else
                            rs.Update()
                        End If
                        rs("Cod_Outillage").Value = IsNull(.Item(Cod_Outillage.Index, i).Value, "")
                        rs("Qte").Value = CDbl(.Item(Qte.Index, i).Value)
                        rs.Update()
                        rs.Close()
                    End If
                Next
            End With
            If Num_Mouvement_txt.Text = "" Then
                Num_Mouvement_txt.Text = NumMouvement
            Else
                Request()
            End If
            Return New savingResult With {.result = True, .message = "Enregistré avec succès."}
        Catch ex As Exception
            Return New savingResult With {.result = False, .message = ex.Message}
        End Try
    End Function
    Function Valider()
        If ShowMessageBox("Etes-vous sûr de vouloir valider ce mouvement?", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving("VA")
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function
    Sub Deleting()
        If Num_Mouvement_txt.Text = "" Then Return
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer ce mouvement?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Outillage_Mouvement_Detail where Num_Mouvement='" & Num_Mouvement_txt.Text & "' and id_Societe=" & Societe.id_Societe &
                    " delete from RH_Outillage_Mouvement where Num_Mouvement='" & Num_Mouvement_txt.Text & "' and id_Societe=" & Societe.id_Societe &
                    " insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('RH_Outillage_Mouvement','Num_Mouvement','" & Num_Mouvement_txt.Text & "','" & theUser.Login & "', getdate())")
        Nouveau()
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
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS213", Num_Mouvement_txt, Me)
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_Mouvement_txt.Text <> "" Then
            If Not ShowMessageBox("Vous ne pouvez pas modifier le matricule d'un mouvement créé." & vbCrLf & "Voulez-vous créer un nouveau mouvement?", "Mouvement", MessageBoxButtons.OKCancel) = DialogResult.OK Then
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
    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        If Num_Mouvement_txt.Text <> "" Then Return
        requestMatricule()
        If Typ_Mouvement_cmb.SelectedValue = "R" Then Grd_Detail.Rows.Clear()
    End Sub
    Private Sub Poste_Text_TextChanged(sender As Object, e As EventArgs) Handles Poste_Text.TextChanged
        Lib_Poste_Text.Text = FindLibelle("Lib_Poste", "Cod_Poste", Poste_Text.Text, "Org_Poste")
    End Sub
    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Calender(Dat_Mouvement_txt, Me)
    End Sub
    Private Sub Typ_Mouvement_cmb_DropDownClosed(sender As Object, e As EventArgs) Handles Typ_Mouvement_cmb.DropDownClosed
        miseAJourEnteteQte()
        If Num_Mouvement_txt.Text <> "" Then Return
        If Grd_Detail.RowCount > 1 Then
            If ShowMessageBox("Le changement du type de mouvement efface les lignes saisies. Continuer?", "Type de mouvement", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
            Grd_Detail.Rows.Clear()
        End If
    End Sub
    Private Sub Num_Mouvement_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Mouvement_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_Mouvement_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_Mouvement_txt.Text)
            Code = Num_Mouvement_txt.Text
        End If
    End Sub
    Private Sub RH_Outillage_Mouvement_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
#Region "Grille Détail"
    Private Sub Grd_Detail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Detail.CellDoubleClick
        If e.RowIndex < 0 Or e.ColumnIndex <> Cod_Outillage.Index Then Return
        If Not Save_D.Enabled Then Return
        If Typ_Mouvement_cmb.SelectedIndex < 0 Then
            ShowMessageBox("Sélectionnez d'abord le type de mouvement.", "Outillage", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Matricule_txt.Text.Trim = "" Then
            ShowMessageBox("Sélectionnez d'abord un agent.", "Outillage", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        With Grd_Detail
            Dim r As Integer = e.RowIndex
            ' Si la ligne double-cliquée est la ligne de nouvel enregistrement (placeholder),
            ' on insère une vraie ligne à sa place : une ligne remplie par code garde IsNewRow=True
            ' et serait ignorée par les boucles d'enregistrement (RowCount - 2)
            Dim inserted As Boolean = False
            If .Rows(r).IsNewRow Then
                .Rows.Insert(r, 1)
                inserted = True
            End If
            If Typ_Mouvement_cmb.SelectedValue = "R" Then
                Appel_Zoom1("MS212", .Item(Cod_Outillage.Index, r), Me, "Matricule='" & Matricule_txt.Text & "'")
            Else
                Appel_Zoom1("MS211", .Item(Cod_Outillage.Index, r), Me)
            End If
            Dim cod As String = IsNull(.Item(Cod_Outillage.Index, r).Value, "")
            If cod = "" AndAlso inserted Then
                ' Sélection annulée : on retire la ligne insérée
                .Rows.RemoveAt(r)
                Return
            End If
            remplirLigne(r, cod)
        End With
    End Sub
    Sub remplirLigne(r As Integer, cod As String)
        With Grd_Detail
            If cod = "" Then
                .Item(Lib_Outillage.Index, r).Value = ""
                .Item(Typ_Outillage.Index, r).Value = ""
                .Item(Num_Serie.Index, r).Value = ""
                .Item(Qte_Dispo.Index, r).Value = ""
                .Item(Qte.Index, r).Value = ""
                Return
            End If
            Dim sqlStr As String = ""
            If Typ_Mouvement_cmb.SelectedValue = "R" Then
                sqlStr = "select Cod_Outillage, Lib_Outillage, Typ_Outillage, Num_Serie, Qte_Detenus as Qte_Ref from RH_Outillage_Agent where Cod_Outillage='" & cod & "' and Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe
            Else
                sqlStr = "select Cod_Outillage, Lib_Outillage, Typ_Outillage, Num_Serie, Qte_Disponible as Qte_Ref from RH_Outillage_Dispo where Cod_Outillage='" & cod & "' and id_Societe=" & Societe.id_Societe
            End If
            Dim Tbl As DataTable = DATA_READER_GRD(sqlStr)
            If Tbl.Rows.Count > 0 Then
                .Item(Lib_Outillage.Index, r).Value = IsNull(Tbl.Rows(0)("Lib_Outillage"), "")
                .Item(Typ_Outillage.Index, r).Value = IsNull(Tbl.Rows(0)("Typ_Outillage"), "")
                .Item(Num_Serie.Index, r).Value = IsNull(Tbl.Rows(0)("Num_Serie"), "")
                .Item(Qte_Dispo.Index, r).Value = IsNull(Tbl.Rows(0)("Qte_Ref"), 0)
                ' Quantité par défaut : quantité détenue en cas de retrait, 1 en cas d'affectation
                If Typ_Mouvement_cmb.SelectedValue = "R" Then
                    .Item(Qte.Index, r).Value = IsNull(Tbl.Rows(0)("Qte_Ref"), 0)
                Else
                    .Item(Qte.Index, r).Value = 1
                End If
            Else
                .Item(Cod_Outillage.Index, r).Value = ""
                .Item(Lib_Outillage.Index, r).Value = ""
                .Item(Typ_Outillage.Index, r).Value = ""
                .Item(Num_Serie.Index, r).Value = ""
                .Item(Qte_Dispo.Index, r).Value = ""
                .Item(Qte.Index, r).Value = ""
            End If
        End With
    End Sub
    Private Sub Grd_Detail_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Detail.CellValidated
        With Grd_Detail
            If e.RowIndex < 0 Or e.ColumnIndex <> Qte.Index Then Return
            If IsNull(.Item(Cod_Outillage.Index, e.RowIndex).Value, "") = "" Then Return
            If Not IsNumeric(.Item(Qte.Index, e.RowIndex).Value) OrElse CDbl(.Item(Qte.Index, e.RowIndex).Value) <= 0 Then
                ShowMessageBox("La quantité doit être un nombre positif.", "Quantité", MessageBoxButtons.OK, msgIcon.Stop)
                .Item(Qte.Index, e.RowIndex).Value = ""
                Return
            End If
            If IsNumeric(.Item(Qte_Dispo.Index, e.RowIndex).Value) Then
                If CDbl(.Item(Qte.Index, e.RowIndex).Value) > CDbl(.Item(Qte_Dispo.Index, e.RowIndex).Value) Then
                    ShowMessageBox("La quantité ne peut pas dépasser " & .Item(Qte_Dispo.Index, e.RowIndex).Value & ".", "Quantité", MessageBoxButtons.OK, msgIcon.Stop)
                    .Item(Qte.Index, e.RowIndex).Value = .Item(Qte_Dispo.Index, e.RowIndex).Value
                End If
            End If
        End With
    End Sub
    Private Sub Grd_Detail_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grd_Detail.EditingControlShowing
        With Grd_Detail
            If .CurrentCell IsNot Nothing AndAlso .CurrentCell.ColumnIndex = Qte.Index Then
                AddHandler e.Control.KeyPress, AddressOf checkCell
            Else
                RemoveHandler e.Control.KeyPress, AddressOf checkCell
            End If
        End With
    End Sub
    Sub checkCell(sender, e)
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub
    Private Sub Grd_Detail_KeyDown(sender As Object, e As KeyEventArgs) Handles Grd_Detail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Not Save_D.Enabled Then Return
            If Grd_Detail.CurrentRow IsNot Nothing AndAlso Grd_Detail.CurrentRow.Index < Grd_Detail.RowCount - 1 Then
                If ShowMessageBox("Voulez-vous supprimer cette ligne?", "Suppression", MessageBoxButtons.YesNo, msgIcon.Question) = DialogResult.Yes Then
                    Grd_Detail.Rows.RemoveAt(Grd_Detail.CurrentRow.Index)
                End If
            End If
        End If
    End Sub
#End Region
End Class
