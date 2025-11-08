Imports System.ComponentModel
Public Class RH_Demande_Avance
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
    End Sub
    Private Sub RH_Demande_Conge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Demande_txt.Text) Then Dat_Demande_txt.Text = Now.ToShortDateString
        If CnExecuting("Select count(*) from Controle_Access where Name_Ecran in ('RH_Preparation_Paie','RH_Cloture_Paie') and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            ShowMessageBox("Une préparation ou clôture de la paie est en cours. Réessayez plus tard.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
    End Sub
    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        Dim canModify As Boolean = (Num_Avance_txt.Text = "")
        Dim SqlStr As String = "SELECT   *
                            FROM RH_Paie_Avance where  Num_Avance='" & Num_Avance_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        With Tbl
            If .Rows.Count > 0 Then
                Montant_Avance_txt.Text = IsNull(.Rows(0)("Montant_Avance"), "0,00")
                Montant_Avance_txt.Text = If(IsNumeric(Montant_Avance_txt.Text), FormatNumber(CDbl(Montant_Avance_txt.Text), 2), "0,00")
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                requestMatricule()
                Avances_Encours_txt.Text = CnExecuting("select isnull((select sum(isnull(Montant_Avance,0)-isnull(Reglement,0)) from RH_Paie_Avance where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe & " and Num_Avance<>'" & Num_Avance_txt.Text & "' having sum(isnull(Montant_Avance,0)-isnull(Reglement,0))>0),0) ").Fields(0).Value
                Dat_Demande_txt.Text = IsNull(.Rows(0)("Dat_Demande"), "")
                Reglement_txt.Text = IsNull(.Rows(0)("Reglement"), "")
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
                    canModify = (IsNull(Tbl.Rows(0)("Statut"), "") = "")
                    If IsNull(Tbl.Rows(0)("Statut"), "") <> "" Then
                        Save_D.Enabled = False
                        Del_D.Enabled = False
                        Valide_D.Enabled = False
                    End If
                End With
            Else
                Matricule_txt.Text = ""
                Avances_Encours_txt.Text = "0,00"
                Dat_Demande_txt.Text = ""
                Reglement_txt.Text = "0,00"
                Commentaire_txt.Text = ""
            End If
            If canModify Then canModify = ((Matricule_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
            Save_D.Enabled = canModify
            Del_D.Enabled = canModify
            Valide_D.Enabled = canModify
        End With
        Montant_Avance_txt.Enabled = Not pb_Valide.Visible
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_Avance_txt.Text <> "" Then
            If Not ShowMessageBox("Vous ne pouvez pas modifier le matricule d'une demande créée." & vbCrLf & "Voulez-vous créer une nouvelle demande?", "Demande", MessageBoxButtons.OKCancel) = DialogResult.OK Then
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
        ElseIf Matricule_txt.Text.Trim = "" Then
            Nom_Agent_Text.Text = ""
            Cod_Plan_Paie_Text.Text = ""
            Titre_txt.Text = ""
            Poste_Text.Text = ""
            Grade_Text.Text = ""
            Cod_Entite_txt.Text = ""
            Dernier_Salaire_Net_txt.Text = "0,00"
            Reste_Salaire_txt.Text = "0,00"
        End If
    End Sub
    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        If Num_Avance_txt.Text <> "" Then Return
        requestMatricule()
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS020", Num_Avance_txt, Me, " Matricule = '" & Matricule_txt.Text & "'")
            End If
        Else
            Appel_Zoom1("MS020", Num_Avance_txt, Me)
        End If
    End Sub
    Private Sub Num_Avance_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Avance_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_Avance_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_Avance_txt.Text)
            Code = Num_Avance_txt.Text
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
                If Not IsNumeric(Montant_Avance_txt.Text) Then Montant_Avance_txt.Text = 0
                Reste_Salaire_txt.Text = FormatDeNombre(Math.Max(CDbl(Dernier_Salaire_Net_txt.Text) - CDbl(Montant_Avance_txt.Text), 0), 2)
                Lib_Plan_Paie_Text.Text = .Rows(0)("Lib_Plan_Paie")
                LastDatePaie_txt.Text = IsNull(.Rows(0)("Dat_Fin_Periode"), "")
                JourPaie_txt.Text = IsNull(.Rows(0)("JourPaie"), 1)
            Else
                Dernier_Salaire_Net_txt.Text = "0,00"
                Reste_Salaire_txt.Text = "0,00"
                Lib_Plan_Paie_Text.Text = ""
                LastDatePaie_txt.Text = ""
                JourPaie_txt.Text = 1
            End If
        End With
    End Sub
    Function Valider()
        If ShowMessageBox("Etes-vous sûr de vouloir valider cette demande?", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving("VA")
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function
    Sub Saving()
        Dim rsl As savingResult = Saving("")
        If IsNull(rsl.message, "") <> "" Then ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub
    Function Saving(statut As String) As savingResult
        If CnExecuting("Select count(*) from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            Return New savingResult With {.result = False, .message = "Une préparation de la paie est en cours. Réessayez plus tard."}
        End If
        If Matricule_txt.Text = "" Then
            Return New savingResult With {.result = False, .message = "Matricule non renseigné"}
        End If
        If Cod_Plan_Paie_Text.Text = "" Then
            Return New savingResult With {.result = False, .message = "Plan non renseigné"}
        End If
        If Not EstDate(Dat_Demande_txt.Text) Then
            Return New savingResult With {.result = False, .message = "Date demande non renseignée"}
        End If
        If ConvertNombre(Montant_Avance_txt.Text) = 0 Then
            Return New savingResult With {.result = False, .message = "Aucun montant pour cette demande d'avance"}
        End If
        Dim NumAvance As String = Num_Avance_txt.Text
        If NumAvance = "" Then
            Dim Cp As New ADODB.Recordset
            Dim SqlStr As String = "select isnull(max(racine),0) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from RH_Paie_Avance 
outer apply(select charindex('_',Num_Avance,1)-1 aa)a
outer apply(select case when aa<0 then RIGHT(Num_Avance,6) else RIGHT(left(Num_Avance,aa),6) end as racine)n
where id_Societe=" & Societe.id_Societe & " and year(Dat_Demande)=" & CDate(Dat_Demande_txt.Text).Year & ")f"
            Cp = CnExecuting(SqlStr)
            NumAvance = "AV" & Societe.id_Societe & "-" & CDate(Dat_Demande_txt.Text).Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
        End If
        Dim oDat As Date = Now
        If Not EstDate(Dat_Demande_txt.Text) Then Dat_Demande_txt.Text = oDat.ToShortDateString
        Dim rs As New ADODB.Recordset
        rs.Open("select * from RH_Paie_Avance where Num_Avance='" & NumAvance & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Num_Avance").Value = NumAvance
            rs("id_Societe").Value = Societe.id_Societe
            rs("Matricule").Value = Matricule_txt.Text
            rs("Dat_Crea").Value = oDat
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()
        End If
        rs("Dat_Demande").Value = Dat_Demande_txt.Text
        rs("Montant_Avance").Value = Montant_Avance_txt.Text
        rs("Commentaire").Value = Commentaire_txt.Text
        rs("Statut").Value = statut
        rs("Dat_Modif").Value = oDat
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()
        If Num_Avance_txt.Text <> "" Then
            Request()
        Else
            Num_Avance_txt.Text = NumAvance
        End If
        Return New savingResult With {.result = True, .message = "Enregistré avec succès"}
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
        CnExecuting("delete from RH_Paie_Avance where Num_Avance='" & Num_Avance_txt.Text & "' and id_Societe=" & Societe.id_Societe _
      &
    " insert into  Mouchard_Suppression ( Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
values ('RH_Paie_Avance','Num_Avance','" & Num_Avance_txt.Text & "','" & theUser.id_User & "', getdate())")
        Reset_Form(Me)
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
    End Sub
    Private Sub RH_Demande_Conge_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Request()
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        Dat_Demande_txt.Text = Now.ToShortDateString
    End Sub
    Private Sub Montant_Avance_txt_Validating(sender As Object, e As CancelEventArgs) Handles Montant_Avance_txt.Validating
        If Not IsNumeric(Montant_Avance_txt.Text) Then
            e.Cancel = True
        End If
    End Sub
    Private Sub Montant_Avance_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Montant_Avance_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub
    Private Sub Montant_Avance_txt_Leave(sender As Object, e As EventArgs) Handles Montant_Avance_txt.Leave
        If Not IsNumeric(Montant_Avance_txt.Text) Then
            Montant_Avance_txt.Text = "0,00"
            Montant_Avance_txt.Text = FormatDeNombre(Montant_Avance_txt.Text, 2)
        End If

        Reste_Salaire_txt.Text = FormatDeNombre(Math.Max(0, CDbl(If(IsNumeric(Dernier_Salaire_Net_txt.Text), Dernier_Salaire_Net_txt.Text, 0)) - CDbl(Montant_Avance_txt.Text)), 2)
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_Demande_txt, Me)
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