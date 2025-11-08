Imports System.ComponentModel
Public Class RH_Pret
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Request_D As ud_btn
    Dim Del_D As ud_btn
    Dim Valide_D As ud_btn
    Sub Chargement()
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Request_D = dictButtons("Request_D")
            Del_D = dictButtons("Del_D")
            Valide_D = dictButtons("Valide_D")
        End If
    End Sub
    Private Sub RH_Demande_Conge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        Premiere_Echeance_txt.Text = Now.AddDays(-Now.Day).AddMonths(1).AddDays(1).ToShortDateString
        If CnExecuting("Select count(*) from Controle_Access where Name_Ecran in ('RH_Preparation_Paie','RH_Cloture_Paie') and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            ShowMessageBox("Une préparation ou clôture de la paie est en cours. Réessayez plus tard.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        Rd_1.Checked = True
    End Sub
    Function Valider()
        If ShowMessageBox("Etes-vous sûr de vouloir valider ce prêt?", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving("VA")
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function
    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        Grd.Rows.Clear()
        Dim SqlStr As String = "SELECT   *
                            FROM RH_Pret where  Num_Pret='" & Num_Pret_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        Dim canModify As Boolean = (Num_Pret_txt.Text = "")
        With Tbl
            If .Rows.Count > 0 Then
                Montant_Pret_txt.Text = IsNull(.Rows(0)("Montant_Pret"), "0,00")
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                requestMatricule()
                Dat_Demande_txt.Text = IsNull(.Rows(0)("Dat_Demande"), "")
                Taux_txt.Text = IsNull(.Rows(0)("Taux"), "0,00")
                Duree.Text = IsNull(.Rows(0)("Duree"), "0,00")
                Taux_TVA_txt.Text = IsNull(.Rows(0)("Taux_TVA"), "0,00")
                Premiere_Echeance_txt.Text = IsNull(.Rows(0)("Premiere_Echeance"), "")
                Mensualite_txt.Text = IsNull(.Rows(0)("Mensualite"), "0,00")
                Reglement_txt.Text = IsNull(.Rows(0)("Reglement"), "0,00")
                Rd_1.Checked = (IsNull(.Rows(0)("Typ_Pret"), "") = "E")
                Rd_2.Checked = (IsNull(.Rows(0)("Typ_Pret"), "") = "I")
                Rd_3.Checked = (Not Rd_1.Checked And Not Rd_2.Checked)
                Organisme_txt.Text = IsNull(.Rows(0)("Organisme"), "")
                Num_Demande_Pret_txt.Text = IsNull(.Rows(0)("Num_Demande_Pret"), "")
                Assurance_txt.Text = IsNull(.Rows(0)("Assurance"), "0,00")
                Commentaire_txt.Text = IsNull(.Rows(0)("Commentaire"), "")
                Dim TblD As DataTable = DATA_READER_GRD("select * from RH_Pret_Detail where Num_Pret='" & Num_Pret_txt.Text & "' and id_Societe=" & Societe.id_Societe & " order by Echeance asc")
                Dim crd As Double = ConvertNombre(Montant_Pret_txt.Text)
                With TblD
                    For i = 0 To .Rows.Count - 1
                        Grd.Rows.Add(.Rows(i)("Echeance"), crd, .Rows(i)("Mensualite"), .Rows(i)("Interet"), .Rows(i)("Amortissement"), crd - ConvertNombre(.Rows(i)("Amortissement")))
                        crd = crd - ConvertNombre(.Rows(i)("Amortissement"))
                    Next
                End With
                With pb_Valide
                    .Tag = ""
                    Select Case IsNull(Tbl.Rows(0)("Statut"), "")
                        Case "SS"
                            .Image = My.Resources.valide01
                            .Tag = "SS"
                        Case "RJ"
                            .Image = My.Resources.refuse
                            .Tag = "RJ"
                    End Select
                    canModify = (IsNull(Tbl.Rows(0)("Statut"), "") = "")
                    .Visible = ("VA;SS;RJ".Split(";").Contains(IsNull(Tbl.Rows(0)("Statut"), "")))
                    If .Visible Then
                        Save_D.Enabled = False
                        Del_D.Enabled = False
                        Valide_D.Enabled = False
                        Request_D.Enabled = False
                    End If
                End With
            Else
                Matricule_txt.Text = ""
                Dat_Demande_txt.Text = ""
                Taux_txt.Text = "0,00"
                Duree.Text = "0,00"
                Taux_TVA_txt.Text = "0,00"
                Premiere_Echeance_txt.Text = ""
                Mensualite_txt.Text = "0,00"
                Reglement_txt.Text = "0,00"
                Rd_1.Checked = False
                Rd_2.Checked = False
                Rd_3.Checked = False
                Organisme_txt.Text = ""
                Assurance_txt.Text = "0,00"
                Commentaire_txt.Text = ""
            End If
        End With
        If canModify Then canModify = ((Matricule_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
        Save_D.Enabled = canModify
        Del_D.Enabled = canModify
        Valide_D.Enabled = canModify
        Request_D.Enabled = canModify
        Montant_Pret_txt.Enabled = Not pb_Valide.Visible
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_Pret_txt.Text <> "" Then Return
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub
    Sub requestMatricule()
        Dim SqlStr As String = "Select * from RH_Agent a
outer apply(select top 1 * from RH_Conge where Matricule=a.Matricule and id_Societe=a.id_Societe order by Annee desc)c
where a.Matricule='" & Matricule_txt.Text & "' and a.id_Societe=" & Societe.id_Societe
        Dim CltTbl As DataTable = DATA_READER_GRD(SqlStr)
        If CltTbl.Rows.Count > 0 Then
            Nom_Agent_Text.Text = IsNull(CltTbl.Rows(0)("Nom_Agent"), "") & " " & IsNull(CltTbl.Rows(0)("Prenom_Agent"), "")
            Cod_Plan_Paie_Text.Text = IsNull(CltTbl.Rows(0)("Plan_Paie"), "")
            Titre_txt.Text = IsNull(CltTbl.Rows(0)("Titre"), "")
            Poste_Text.Text = IsNull(CltTbl.Rows(0)("Cod_Poste"), "")
            Grade_Text.Text = IsNull(CltTbl.Rows(0)("Cod_Grade"), "")
            Cod_Entite_txt.Text = IsNull(CltTbl.Rows(0)("Cod_Entite"), "")
            Prets_Encours_txt.Text = CnExecuting("select dbo.Pret_En_Cours('" & Matricule_txt.Text & "'," & Societe.id_Societe & ",'" & Num_Pret_txt.Text & "') ").Fields(0).Value
        ElseIf Matricule_txt.Text.Trim = "" Then
            Nom_Agent_Text.Text = ""
            Cod_Plan_Paie_Text.Text = ""
            Titre_txt.Text = ""
            Poste_Text.Text = ""
            Grade_Text.Text = ""
            Cod_Entite_txt.Text = ""
            Prets_Encours_txt.Text = "0,00"
            Dernier_Salaire_Net_txt.Text = "0,00"
            Reste_Salaire_txt.Text = "0,00"
        End If
    End Sub
    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        If Num_Pret_txt.Text <> "" Then Return
        requestMatricule()
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS021", Num_Pret_txt, Me, " Matricule like '" & Matricule_txt.Text & "%'")
    End Sub
    Private Sub Num_Pret_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Pret_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_Pret_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_Pret_txt.Text)
            Code = Num_Pret_txt.Text
        End If
    End Sub
    Private Sub Cod_Plan_Paie_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        Dim SqlStr As String = "select isnull(Lib_Plan_Paie,'') as Lib_Plan_Paie,JourPaie ,Dat_Fin_Periode,isnull(SalNet,'') as SalNet, isnull(Dernier_Salaire_Net,0) as Dernier_Salaire_Net
from RH_Param_Plan_Paie p
outer apply (select Top 1  Dat_Fin_Periode from RH_Preparation_Paie 
where Cod_Plan_Paie=p.Cod_Plan_Paie and id_Societe=p.id_Societe 
order by Dat_Fin_Periode desc) pp
outer apply (select Top 1  Valeur as Dernier_Salaire_Net from RH_Preparation_Paie_Detail 
where Cod_Rubrique=isnull(SalNet,'') and id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_txt.Text & "' order by Annee_Paie Desc, Mois_Paie Desc) p2
where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        With Tbl
            If .Rows.Count > 0 Then
                Dernier_Salaire_Net_txt.Text = .Rows(0)("Dernier_Salaire_Net")
                If Not IsNumeric(Dernier_Salaire_Net_txt.Text) Then Dernier_Salaire_Net_txt.Text = 0
                If Not IsNumeric(Montant_Pret_txt.Text) Then Montant_Pret_txt.Text = 0
                Reste_Salaire_txt.Text = FormatDeNombre(Math.Max(CDbl(Dernier_Salaire_Net_txt.Text) - CDbl(Montant_Pret_txt.Text), 0), 2)
                Lib_Plan_Paie_Text.Text = .Rows(0)("Lib_Plan_Paie")
                LastDatePaie_txt.Text = IsNull(.Rows(0)("Dat_Fin_Periode"), "")
            Else
                Dernier_Salaire_Net_txt.Text = "0,00"
                Reste_Salaire_txt.Text = "0,00"
                Lib_Plan_Paie_Text.Text = ""
                LastDatePaie_txt.Text = ""
            End If
        End With
    End Sub
    Sub Enregistrer()
        Dim rsl As savingResult = Saving("")
        ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub
    Function Saving(statut As String) As savingResult
        Try
            If CnExecuting("Select count(*) from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
                Return New savingResult With {.message = "Une préparation de la paie est en cours. Réessayez plus tard.", .result = False}
            End If
            If Matricule_txt.Text = "" Then
                Return New savingResult With {.result = False, .message = "Matricule non renseigné"}
            End If
            If Cod_Plan_Paie_Text.Text = "" Then
                Return New savingResult With {.result = False, .message = "Plan non renseigné"}
            End If
            If ConvertNombre(Montant_Pret_txt.Text) = 0 Then
                Return New savingResult With {.result = False, .message = "Aucun montant pour cette demande de prêt"}
            End If
            If Grd.RowCount <= 1 Then
                Return New savingResult With {.result = False, .message = "Tableau d'amortissement non génére pour ce prêt"}
            End If
            If ConvertNombre(Grd.Item(Amortissement.Index, Grd.Rows.Count - 1).Value) <> 0 Then
                Return New savingResult With {.result = False, .message = "Le capital restant dû de la dernier ligne doit être 0."}
            End If
            If Not EstDate(Dat_Demande_txt.Text) Then Dat_Demande_txt.Text = Now.ToShortDateString
            If Rd_1.Checked Then
                If Societe.Obliger_Demande_Pret Then
                    If Num_Demande_Pret_txt.Text = "" Then
                        Return New savingResult With {.result = False, .message = "Demande de prêt non renseignée."}
                    End If
                End If
            End If
            Dim NumPret As String = Num_Pret_txt.Text
            If NumPret = "" Then
                Dim Cp As New ADODB.Recordset
                Cp = CnExecuting("select isnull(max(convert(int,right(Num_Pret,6))),0) from RH_Pret where id_Societe=" & Societe.id_Societe & " and year(Dat_Crea)=" & Now.Year)
                If Not Cp.EOF Then
                    NumPret = "PR" & Societe.id_Societe & "-" & Now.Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
                Else
                    NumPret = "PR" & Societe.id_Societe & "-" & Now.Year & "000001"
                End If
            End If
            Dim oDat As Date = Now
            Dim rs As New ADODB.Recordset
            If Not EstDate(Dat_Demande_txt.Text) Then Dat_Demande_txt.Text = oDat.ToShortDateString
            rs.Open("select * from RH_Pret where Num_Pret='" & NumPret & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Num_Pret").Value = NumPret
                rs("id_Societe").Value = Societe.id_Societe
                rs("Matricule").Value = Matricule_txt.Text
                rs("Dat_Crea").Value = oDat
                rs("Created_By").Value = theUser.Login
            Else
                rs.Update()
            End If
            rs("Dat_Demande").Value = Dat_Demande_txt.Text
            rs("Montant_Pret").Value = Montant_Pret_txt.Text
            rs("Taux").Value = Taux_txt.Text
            rs("Duree").Value = Duree.Text
            rs("Taux_TVA").Value = Taux_TVA_txt.Text
            rs("Premiere_Echeance").Value = Premiere_Echeance_txt.Text
            rs("Mensualite").Value = Mensualite_txt.Text
            rs("Typ_Pret").Value = IIf(Rd_1.Checked, "E", IIf(Rd_2.Checked, "I", "A"))
            rs("Organisme").Value = IIf(Rd_1.Checked, "", Organisme_txt.Text)
            rs("Assurance").Value = IIf(Rd_1.Checked, 0, Assurance_txt.Text)
            rs("Commentaire").Value = Commentaire_txt.Text
            rs("Statut").Value = statut
            rs("Num_Demande_Pret").Value = If(Rd_1.Checked, Num_Demande_Pret_txt.Text, "")
            rs("Dat_Modif").Value = oDat
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            CnExecuting("delete from RH_Pret_Detail where id_Societe=" & Societe.id_Societe & " and Num_Pret='" & Num_Pret_txt.Text & "'")
            With Grd
                rs.Open("select * from RH_Pret_Detail")
                For i = 0 To .RowCount - 1
                    If EstDate(.Item(Dat.Index, i).Value) Then
                        rs.AddNew()
                        rs("Num_Pret").Value = NumPret
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Echeance").Value = .Item(Dat.Index, i).Value
                        rs("Mensualite").Value = .Item(Mensualite.Index, i).Value
                        rs("Interet").Value = .Item(Interet.Index, i).Value
                        rs("Amortissement").Value = .Item(Amortissement.Index, i).Value
                        rs("Matricule").Value = Matricule_txt.Text
                        rs.Update()
                    End If
                Next
                rs.Close()
            End With

            If Num_Pret_txt.Text <> "" Then
                Request()
            Else
                Num_Pret_txt.Text = NumPret
            End If
            Return New savingResult With {.result = True, .message = "Enregistré avec succès."}
        Catch ex As Exception
            ShowMessageBox(ex.Message)
            Return New savingResult With {.result = False, .message = ex.Message}
        End Try
    End Function
    Private Sub Poste_Text_TextChanged(sender As Object, e As EventArgs) Handles Poste_Text.TextChanged
        Lib_Poste_Text.Text = FindLibelle("Lib_Poste", "Cod_Poste", Poste_Text.Text, "Org_Poste")
    End Sub
    Private Sub Grade_Text_TextChanged(sender As Object, e As EventArgs) Handles Grade_Text.TextChanged
        Lib_Grade_Text.Text = FindLibelle("Lib_Grade", "Cod_Grade", Grade_Text.Text, "Org_Grade")
    End Sub
    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub
    Sub Deleting()
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette demande?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Pret where Num_Pret='" & Num_Pret_txt.Text & "' and id_Societe=" & Societe.id_Societe _
      &
    " insert into  Mouchard_Suppression ( Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
values ('RH_Pret','Num_Pret','" & Num_Pret_txt.Text & "','" & theUser.id_User & "', getdate())")
        Reset_Form(Me)
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
    End Sub
    Private Sub RH_Demande_Conge_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Premiere_Echeance_txt.Text = Now.AddDays(-Now.Day).AddMonths(1).AddDays(1).ToShortDateString
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        Dat_Demande_txt.Text = Now.ToShortDateString
    End Sub

    Private Sub Montant_Pret_txt_Validating(sender As Object, e As CancelEventArgs) Handles Montant_Pret_txt.Validating, Taux_txt.Validating
        If Not IsNumeric(Montant_Pret_txt.Text) Then
            e.Cancel = True
        End If
    End Sub
    Private Sub Montant_Pret_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Montant_Pret_txt.KeyPress, Taux_txt.KeyPress, Taux_TVA_txt.KeyPress, Assurance_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub

    Private Sub Montant_Pret_txt_Leave(sender As Object, e As EventArgs) Handles Montant_Pret_txt.Leave, Taux_txt.Leave, Assurance_txt.Leave, Taux_TVA_txt.Leave
        If Not IsNumeric(sender.Text) Then
            sender.Text = "0,00"
        End If
        If sender Is Montant_Pret_txt Then
            Montant_Pret_txt.Text = FormatDeNombre(Montant_Pret_txt.Text, 2)
            Reste_Salaire_txt.Text = FormatDeNombre(Math.Max(0, CDbl(Dernier_Salaire_Net_txt.Text) - CDbl(Montant_Pret_txt.Text)), 2)
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Calender(Premiere_Echeance_txt, Me)
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles organisme_lbl.LinkClicked
        Appel_Rubrique("Banque", Organisme_txt, Me)
    End Sub

    Private Sub Organisme_txt_TextChanged(sender As Object, e As EventArgs) Handles Organisme_txt.TextChanged
        Lib_Organisme_txt.Text = FindRubriques("Banque", Organisme_txt.Text)
    End Sub

    Private Sub LabelItem4_Click(sender As Object, e As EventArgs)

    End Sub
    Sub Actualiser()
        Montant_Pret_txt.Text = ConvertNombre(Montant_Pret_txt.Text)
        Taux_TVA_txt.Text = ConvertNombre(Taux_TVA_txt.Text)
        Taux_txt.Text = ConvertNombre(Taux_txt.Text)
        Try
            If Not EstDate(Premiere_Echeance_txt.Text) Then Premiere_Echeance_txt.Text = Now.AddDays(-Now.Day).AddMonths(1)
            With Grd
                If .Rows.Count > 1 Then
                    If ShowMessageBox("Etes-vous sûr de vouloir regénérer le tableau d'amortissemnt du prêt?", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Return
                End If
                .Rows.Clear()
                Dim C1, C2, C3, C4, C5, C6 As Object
                Dim mens As Double = 0
                Dim Tbl As DataTable = DATA_READER_GRD("select * from dbo.Sys_Pret_Amortissement(" & Montant_Pret_txt.Text.Replace(",", ".") & ",
" & Duree.Value & "," & Taux_txt.Text.Replace(",", ".") & "," & Taux_TVA_txt.Text.Replace(",", ".") & ",'" & CDate(Premiere_Echeance_txt.Text).ToShortDateString & "')")
                With Tbl
                    For i = 0 To .Rows.Count - 1
                        C1 = .Rows(i)("Dat")
                        C2 = .Rows(i)("Capital")
                        C3 = .Rows(i)("Mensualite")
                        If mens = 0 Then mens = C3
                        C4 = .Rows(i)("Interet")
                        C5 = .Rows(i)("Amortissement")
                        C6 = .Rows(i)("CRD")
                        Grd.Rows.Add(C1, C2, C3, C4, C5, C6)
                    Next
                End With
                Mensualite_txt.Text = FormatNumber(mens, 2)
            End With
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_Demande_txt, Me)
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Num_Demande_Pret_lbl.LinkClicked
        Appel_Zoom1("MS159", Num_Demande_Pret_txt, Me, " Matricule = '" & Matricule_txt.Text & "' and isnull(Statut,'')='SG'")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Num_Demande_Pret_txt.TextChanged
        If Num_Pret_txt.Text = "" Then
            Dim tbl As DataTable = DATA_READER_GRD("select Montant_Pret,convert(nvarchar(10),Dat_Demande,103) as Dat_Demande, Nb_Echeance, Commentaire from RH_Pret_Demande where Num_Demande_Pret='" & Num_Demande_Pret_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            With tbl
                If .Rows.Count > 0 Then
                    Lib_Num_Demande_Pret_txt.Text = .Rows(0)("Dat_Demande")
                    Montant_Pret_txt.Text = FormatNumber(CDbl(.Rows(0)("Montant_Pret")), 2)
                    Duree.Value = CDbl(.Rows(0)("Nb_Echeance"))
                    Commentaire_txt.Text = .Rows(0)("Commentaire")
                    Rd_1.Checked = True
                Else
                    Lib_Num_Demande_Pret_txt.Text = ""
                    Montant_Pret_txt.Text = 0
                    Duree.Value = 0
                    Commentaire_txt.Text = ""
                    Rd_1.Checked = False
                End If
            End With
        Else
            Lib_Num_Demande_Pret_txt.Text = FindLibelle("convert(nvarchar(10),Dat_Demande,103) as Dat_Demande", "Num_Demande_Pret", Num_Demande_Pret_txt.Text, "RH_Pret_Demande")
        End If
    End Sub
    Private Sub Rd_1_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_1.CheckedChanged, Rd_2.CheckedChanged, Rd_3.CheckedChanged
        organisme_lbl.Visible = Not Rd_1.Checked
        Organisme_txt.Visible = organisme_lbl.Visible
        Lib_Organisme_txt.Visible = organisme_lbl.Visible
        Num_Demande_Pret_txt.Visible = Rd_1.Checked
        Lib_Num_Demande_Pret_txt.Visible = Rd_1.Checked
        Num_Demande_Pret_lbl.Visible = Rd_1.Checked
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