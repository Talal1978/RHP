Imports System.ComponentModel
Public Class Note_Frais
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
        If Typ_Frais.Items.Count = 0 Then Combo_GRD(Typ_Frais)
    End Sub
    Private Sub RH_Demande_Conge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_NF_txt.Text) Then Dat_NF_txt.Text = Now.ToShortDateString
        If CnExecuting("Select count(*) from Controle_Access where Name_Ecran in ('RH_Preparation_Paie','RH_Cloture_Paie') and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            ShowMessageBox("Une préparation ou clôture de la paie est en cours. Réessayez plus tard.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        With Grd_Frais
            .DefaultCellStyle.SelectionBackColor = colorBase04
        End With
    End Sub
    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        Dim canModify As Boolean = (Num_NF_txt.Text = "")
        Dim SqlStr As String = "SELECT   *
                            FROM Rh_Note_Frais where  Num_NF='" & Num_NF_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        With Tbl
            If .Rows.Count > 0 Then
                Mnt_NF_txt.Text = IsNull(.Rows(0)("Mnt_NF"), "0,00")
                Mnt_NF_txt.Text = If(IsNumeric(Mnt_NF_txt.Text), FormatNumber(CDbl(Mnt_NF_txt.Text), 2), "0,00")
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")
                requestMatricule()
                Dat_NF_txt.Text = IsNull(.Rows(0)("Dat_NF"), "")
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
                Dat_NF_txt.Text = ""
                Commentaire_txt.Text = ""
            End If
            Dim TblNF = DATA_READER_GRD("select Typ_Frais, Base, Tx, Mnt, Comment, RowId
                                      from Rh_Note_Frais_Detail f 
                                      where Num_NF='" & Num_NF_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            With TblNF
                Grd_Frais.Rows.Clear()
                If Grd_Frais.Columns.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        Grd_Frais.Rows.Add(.Rows(i)("Typ_Frais"), .Rows(i)("Base"), .Rows(i)("Tx"), .Rows(i)("Mnt"), .Rows(i)("Comment"))
                        Grd_Frais.Rows(i).Tag = .Rows(i)("RowId")
                    Next
                End If
            End With
            If canModify Then canModify = ((Matricule_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
            Save_D.Enabled = canModify
            Del_D.Enabled = canModify
            Valide_D.Enabled = canModify
        End With
        Mnt_NF_txt.Enabled = Not pb_Valide.Visible
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_NF_txt.Text <> "" Then
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
            Poste_Text.Text = IsNull(CltTbl.Rows(0)("Cod_Poste"), "")
            Grade_Text.Text = IsNull(CltTbl.Rows(0)("Cod_Grade"), "")
            Cod_Entite_txt.Text = IsNull(CltTbl.Rows(0)("Cod_Entite"), "")
        ElseIf Matricule_txt.Text.Trim = "" Then
            Nom_Agent_Text.Text = ""
            Cod_Plan_Paie_Text.Text = ""
            Poste_Text.Text = ""
            Grade_Text.Text = ""
            Cod_Entite_txt.Text = ""
        End If
    End Sub
    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        If Num_NF_txt.Text <> "" Then Return
        requestMatricule()
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS091", Num_NF_txt, Me, " Matricule = '" & Matricule_txt.Text & "'")
            End If
        Else
            Appel_Zoom1("MS091", Num_NF_txt, Me)
        End If
    End Sub
    Private Sub Num_NF_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_NF_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_NF_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_NF_txt.Text)
            Code = Num_NF_txt.Text
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
                If Not IsNumeric(Mnt_NF_txt.Text) Then Mnt_NF_txt.Text = 0
                Lib_Plan_Paie_Text.Text = .Rows(0)("Lib_Plan_Paie")
                LastDatePaie_txt.Text = IsNull(.Rows(0)("Dat_Fin_Periode"), "")
                JourPaie_txt.Text = IsNull(.Rows(0)("JourPaie"), 1)
            Else
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

        If ConvertNombre(Mnt_NF_txt.Text) = 0 Then
            Return New savingResult With {.result = False, .message = "Aucun montant pour cette note de frais"}
        End If
        Dim numNF As String = Num_NF_txt.Text
        If numNF = "" Then
            Dim Cp As New ADODB.Recordset
            Dim SqlStr As String = "select isnull(max(racine),0) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from Rh_Note_Frais 
outer apply(select charindex('_',Num_NF,1)-1 aa)a
outer apply(select case when aa<0 then RIGHT(Num_NF,6) else RIGHT(left(Num_NF,aa),6) end as racine)n
where id_Societe=" & Societe.id_Societe & " and year(Dat_NF)=" & CDate(Dat_NF_txt.Text).Year & ")f"
            Cp = CnExecuting(SqlStr)
            numNF = "NF" & Societe.id_Societe & "-" & CDate(Dat_NF_txt.Text).Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
        End If
        Dim oDat As Date = Now
        If Not EstDate(Dat_NF_txt.Text) Then Dat_NF_txt.Text = oDat.ToShortDateString
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Rh_Note_Frais where Num_NF='" & numNF & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Num_NF").Value = numNF
            rs("id_Societe").Value = Societe.id_Societe
            rs("Matricule").Value = Matricule_txt.Text
            rs("Dat_Crea").Value = oDat
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()
        End If
        rs("Dat_NF").Value = Dat_NF_txt.Text
        rs("Mnt_NF").Value = Mnt_NF_txt.Text
        rs("Commentaire").Value = Commentaire_txt.Text
        rs("Statut").Value = statut
        rs("Dat_Modif").Value = oDat
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()

        With Grd_Frais
            Dim swhere = ""
            For i = 0 To .RowCount - 2
                If Not IsNull(.Rows(i).Tag, "") = "" Then
                    swhere &= IIf(swhere = "", "", ",") & .Rows(i).Tag
                End If
            Next
            If Not swhere.Trim = "" Then
                CnExecuting("delete from Rh_Note_Frais_Detail where Num_NF='" & numNF & "' and id_Societe='" & Societe.id_Societe & "' and RowId not in (" & swhere & ")")
            End If
            For i = 0 To .RowCount - 2
                If Not IsNull(.Item(Typ_Frais.Index, i).Value, "") = "" And Not CDbl(IsNull(.Item(Mnt.Index, i).Value, 0)) = 0 Then
                    rs.Open("select * from Rh_Note_Frais_Detail where Num_NF='" & numNF & "' and id_Societe='" & Societe.id_Societe & "'  and RowId ='" & IsNull(.Rows(i).Tag, "") & "'", cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Num_NF").Value = numNF
                        rs("id_Societe").Value = Societe.id_Societe
                    Else
                        rs.Update()
                    End If
                    rs("Typ_Frais").Value = IsNull(.Item(Typ_Frais.Index, i).Value, "")
                    rs("Base").Value = IsNull(.Item(Base.Index, i).Value, 0)
                    rs("Tx").Value = IsNull(.Item(Tx.Index, i).Value, 0)
                    rs("Mnt").Value = IsNull(.Item(Mnt.Index, i).Value, 0)
                    rs("Comment").Value = IsNull(.Item(Comment.Index, i).Value, "")
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With
        If Num_NF_txt.Text <> "" Then
            Request()
        Else
            Num_NF_txt.Text = numNF
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
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette note de frais?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from Rh_Note_Frais where Num_NF='" & Num_NF_txt.Text & "' and id_Societe=" & Societe.id_Societe _
      &
    " insert into  Mouchard_Suppression ( Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
values ('Rh_Note_Frais','Num_NF','" & Num_NF_txt.Text & "','" & theUser.id_User & "', getdate())")
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
        Dat_NF_txt.Text = Now.ToShortDateString
    End Sub
    Private Sub Mnt_NF_txt_Validating(sender As Object, e As CancelEventArgs)
        If Not IsNumeric(Mnt_NF_txt.Text) Then
            e.Cancel = True
        End If
    End Sub
    Private Sub Mnt_NF_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Mnt_NF_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub
    Private Sub Mnt_NF_txt_Leave(sender As Object, e As EventArgs)
        If Not IsNumeric(Mnt_NF_txt.Text) Then
            Mnt_NF_txt.Text = "0,00"
            Mnt_NF_txt.Text = FormatDeNombre(Mnt_NF_txt.Text, 2)
        End If
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_NF_txt, Me)
    End Sub
    Private Sub Grd_Frais_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Frais.CellValidated
        With Grd_Frais
            If e.ColumnIndex = Tx.Index Or e.ColumnIndex = Base.Index Then
                If IsNull(.Item(Typ_Frais.Index, e.RowIndex).Value, "") <> "" Then
                    If Not IsNumeric(.Item(Tx.Index, e.RowIndex).Value) Then .Item(Tx.Index, e.RowIndex).Value = 0
                    If Not IsNumeric(.Item(Base.Index, e.RowIndex).Value) Then .Item(Base.Index, e.RowIndex).Value = 0
                    .Item(Mnt.Index, e.RowIndex).Value = Math.Round(CDbl(.Item(Tx.Index, e.RowIndex).Value) * CDbl(.Item(Base.Index, e.RowIndex).Value), 2)
                    Calcul()
                End If
            End If
        End With

    End Sub
    Sub Calcul()
        Dim _mnt = 0
        With Grd_Frais
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Typ_Frais.Index, i).Value, "") <> "" Then
                    If Not IsNumeric(.Item(Tx.Index, i).Value) Then .Item(Tx.Index, i).Value = 0
                    If Not IsNumeric(.Item(Base.Index, i).Value) Then .Item(Base.Index, i).Value = 0
                    .Item(Mnt.Index, i).Value = Math.Round(CDbl(.Item(Tx.Index, i).Value) * CDbl(.Item(Base.Index, i).Value), 2)
                    _mnt += CDbl(.Item(Mnt.Index, i).Value)
                End If
            Next
        End With
        Mnt_NF_txt.Text = FormatNumber(_mnt, 2)
    End Sub
    Private Sub Grd_Frais_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Frais.ColumnHeaderMouseDoubleClick
        Calcul()

    End Sub
    Private Sub Grd_Frais_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grd_Frais.EditingControlShowing
        With Grd_Frais
            If .CurrentCell.ColumnIndex = Tx.Index Or .CurrentCell.ColumnIndex = Base.Index Then
                AddHandler e.Control.KeyPress, AddressOf checkCell
            Else
                RemoveHandler e.Control.KeyPress, AddressOf checkCell
                RemoveHandler e.Control.KeyPress, AddressOf checkCell
            End If
        End With
    End Sub
    Sub checkCell(sender, e)
        If Grd_Frais.CurrentCell.ColumnIndex = Tx.Index Or Grd_Frais.CurrentCell.ColumnIndex = Base.Index Then
            ControleSaisie(sender, e, True, False, True, False, False)
        End If

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