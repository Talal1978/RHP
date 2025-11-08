Public Class Formation
    Friend Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Report_D As ud_btn
    Dim Annuler_D As ud_btn
    Dim Cloture_D As ud_btn
    Dim Add_Agent_D As ud_btn
    Dim Valide_D As ud_btn
    Private Sub Fiche_Fou_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled = True Then
                If Cod_Formation_txt.Text = "" Or CnExecuting("select count(*) from Formation where Cod_Formation='" & Cod_Formation_txt.Text & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
                    Exit Sub
                End If
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Formation_txt.Text & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Fiche_Fou_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Chargement()
    End Sub

    Sub Chargement()
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Report_D = dictButtons("Report_D")
            Annuler_D = dictButtons("Annuler_D")
            Cloture_D = dictButtons("Cloture_D")
            Add_Agent_D = dictButtons("Add_Agent_D")
            Valide_D = dictButtons("Valide_D")
        End If
        If Organisme.Items.Count = 0 Then Combo_GRD(Organisme)
        If Statut_Formation.Items.Count = 0 Then Statut_Formation.fromRubrique()
        If Genre_Formation.Items.Count = 0 Then Genre_Formation.fromRubrique()
        If theUser.Typ_Role = "Agent" Then
            Save_D.Visible = False
            Del_D.Visible = False
            New_D.Visible = False
            Report_D.Visible = False
            Annuler_D.Visible = False
            Cloture_D.Visible = False
            Add_Agent_D.Visible = False
            Valide_D.Visible = False
        End If
    End Sub

    Private Sub Cod_Fou_LINK_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Fou_LINK.LinkClicked
        Appel_Zoom1("MS152", Cod_Formation_txt, Me)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CodCabinet.LinkClicked
        Appel_Zoom1("MS150", Cod_Cabinet_txt, Me)
    End Sub

    Private Sub Cod_Formateur_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Formateur_txt.TextChanged
        If Rd_Nature_Formation_2.Checked Then
            Lib_Cod_Formateur_txt.Text = FindLibelle("isnull(Nom,'')+' '+isnull(Prenom,'')", "Cod_Formateur", Cod_Formateur_txt.Text, "Formation_Formateur")
        Else
            Lib_Cod_Formateur_txt.Text = FindLibelle("Nom", "Matricule", Cod_Formateur_txt.Text, "Sys_RH_Preparation_Paie_Agent")
        End If
    End Sub
    Dim ComptenceTypFormation As New DataTable
    Private Sub Cod_Cabinet_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Cabinet_txt.TextChanged
        Lib_Cod_Cabinet_txt.Text = FindLibelle("Raison_Sociale", "Cod_Cabinet", Cod_Cabinet_txt.Text, "Formation_Cabinet")
        Cod_Formateur_txt.Text = ""
        ComptenceTypFormation = DATA_READER_GRD("select Domaines_Competence, Typ_Formation from Formation_Cabinet_Domaines_Competences where id_Societe=" & Societe.id_Societe & " and Cod_Cabinet='" & Cod_Cabinet_txt.Text & "'")
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If Rd_Nature_Formation_2.Checked Then
            Appel_Zoom1("MS153", Cod_Formateur_txt, Me, "Cod_Cabinet='" & Cod_Cabinet_txt.Text & "'")
        Else
            Appel_Zoom1("MS155", Cod_Formateur_txt, Me)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS154", Action_Formation_txt, Me)
    End Sub

    Private Sub Action_Formation_txt_TextChanged(sender As Object, e As EventArgs) Handles Action_Formation_txt.TextChanged
        Lib_Action_Formation_txt.Text = FindLibelle("Lib_Action", "Cod_Action", Action_Formation_txt.Text, "Formation_Action_Formation")
    End Sub
    Private Sub Budget_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Budget_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub

    Private Sub Budget_txt_Leave(sender As Object, e As EventArgs) Handles Budget_txt.Leave
        If Not IsNumeric(sender.text) Then sender.text = "0,00"
    End Sub
    Sub Nouveau()
        Reset_Form(Me, False)
        Statut_Formation.SelectedValue = "Planifiee"
        Rd_Nature_Formation_2.Checked = True
        Formation_Planifiee_chk.Checked = True
        Budget_txt.Text = "0,00"
        Rd_Typ_Lieu_1.Checked = True
        TabControl1.SelectedIndex = 0
        Lib_Formation_txt.Select()
        Report_D.Visible = False
        Annuler_D.Visible = False
        Cloture_D.Visible = False
    End Sub

    Private Sub Rd_Typ_Lieu_3_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Typ_Lieu_3.CheckedChanged
        Lieu_txt.Visible = (Rd_Typ_Lieu_3.Checked)
    End Sub

    Private Sub Grd_Domaines_Competences_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Domaines_Competences.DataError

    End Sub
    Private Sub Grd_Participants_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Participants.DataError

    End Sub
    Private Sub Grd_Organismes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Organismes.DataError

    End Sub
    Private Sub Grd_Domaines_Competences_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Domaines_Competences.CellMouseDoubleClick
        Dim r As Integer = e.RowIndex
        Dim c As Integer = e.ColumnIndex
        If r < 0 Then Return
        If c < 0 Then Return
        Dim ocondition As String = ""
        With Grd_Domaines_Competences
            If r = .RowCount - 1 Then
                .Rows.Add("")
            End If
            Select Case e.ColumnIndex
                Case Lib_Domaine_Competence.Index
                    ocondition = IIf(Cod_Cabinet_txt.Text = "" Or Not ProposerUniquementDomainesCompetencesAccreditesDuCabinet_chk.Checked, "1=1", "exists(select Domaines_Competence from Formation_Cabinet_Domaines_Competences where id_Societe=GPEC_Domaines_Competence.id_Societe and Domaines_Competence=GPEC_Domaines_Competence.Domaines_Competence  and Cod_Cabinet = '" & Cod_Cabinet_txt.Text & "')")

                    Appel_Zoom1("MS149", .Item(Domaine_Competence.Index, r), Me, ocondition, "", .Item(c, r))
                    .Item(c, r).Value = FindLibelle("Lib_Domaines_Competence", "Domaines_Competence", .Item(Domaine_Competence.Index, r).Value, "GPEC_Domaines_Competence")
                    .Item(Typ_Formation.Index, r).Value = ""
                    .Item(Lib_Typ_Formation.Index, r).Value = ""
                Case Lib_Typ_Formation.Index
                    Appel_Zoom1("MS151", .Item(Typ_Formation.Index, r), Me, " Domaines_Competence ='" & IsNull(.Item(Domaine_Competence.Index, r).Value, "") & "' and id_Societe=" & Societe.id_Societe, "", .Item(c, r))
                    .Item(c, r).Value = FindLibelle("Typ_Formation", "RowId", .Item(Typ_Formation.Index, r).Value, "Formation_Typ_Formation")
            End Select
        End With
    End Sub

    Sub AddAgent()
        Dim swhere As String = ""
        With Grd_Participants
            For i = 0 To .RowCount - 1
                swhere &= IIf(swhere = "", "", ",") & "'" & .Item(Matricule.Index, i).Value & "'"
            Next
        End With
        Dim f As New Zoom_Add_Participant
        With f
            .swhere = swhere
            .frm = Me
            .ShowDialog()
        End With
    End Sub
    Sub Request()
        Try
            Annuler_D.Visible = True
            Report_D.Visible = True
            Cloture_D.Visible = True
            Save_D.Enabled = True
            Del_D.Enabled = True
            Add_Agent_D.Enabled = True
            Valide_D.Enabled = True
            Chargement()
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
            DroitAcces(Me, DroitModify_Fiche(Cod_Formation_txt.Text, Me))
            Dim laTbl As New DataTable
            laTbl = DATA_READER_GRD("Select * from Formation where Cod_Formation='" & Cod_Formation_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            If laTbl.Rows.Count > 0 Then
                Lib_Formation_txt.Text = IsNull(laTbl.Rows(0).Item("Lib_Formation"), "")
                Cod_Survey_txt.Text = IsNull(laTbl.Rows(0).Item("Cod_Survey"), "")
                Dat_Du.Value = IsNull(laTbl.Rows(0).Item("Dat_Du"), Now)
                Dat_Au.Value = IsNull(laTbl.Rows(0).Item("Dat_Au"), Now)
                Action_Formation_txt.Text = IsNull(laTbl.Rows(0).Item("Action_Formation"), "")
                Genre_Formation.SelectedValue = IsNull(laTbl.Rows(0).Item("Genre_Formation"), "")
                Rd_Nature_Formation_1.Checked = (IsNull(laTbl.Rows(0).Item("Nature_Formation"), "2") = "1")
                Rd_Nature_Formation_2.Checked = Not Rd_Nature_Formation_1.Checked
                Budget_txt.Text = IsNull(laTbl.Rows(0).Item("Budget"), "0,00")
                Cod_Cabinet_txt.Text = IsNull(laTbl.Rows(0).Item("Cod_Cabinet"), "")
                Cod_Formateur_txt.Text = IsNull(laTbl.Rows(0).Item("Cod_Formateur"), "")
                Rd_Typ_Lieu_1.Checked = (IsNull(laTbl.Rows(0).Item("Typ_Lieu"), "1") = "1")
                Rd_Typ_Lieu_2.Checked = (IsNull(laTbl.Rows(0).Item("Typ_Lieu"), "1") = "2")
                Rd_Typ_Lieu_3.Checked = (IsNull(laTbl.Rows(0).Item("Typ_Lieu"), "1") = "3")
                Lieu_txt.Text = IsNull(laTbl.Rows(0).Item("Lieu"), "")
                Lieu_txt.Visible = Rd_Typ_Lieu_3.Checked
                Statut_Formation.SelectedValue = IsNull(laTbl.Rows(0).Item("Statut_Formation"), "")
                Formation_Planifiee_chk.Checked = IsNull(laTbl.Rows(0).Item("Formation_Planifiee"), False)
                Contenu_rtb.Rtb.RtfText = IsNull(laTbl.Rows(0).Item("Contenu"), "")
                If IsNull(laTbl.Rows(0)("Statut"), "") <> "" Then
                    Save_D.Enabled = False
                    Del_D.Enabled = False
                    Valide_D.Enabled = False
                End If
                laTbl = DATA_READER_GRD("Select * from Formation_Financement where Cod_Formation='" & Cod_Formation_txt.Text & "' and id_Societe=" & Societe.id_Societe)
                With Grd_Organismes
                    .Rows.Clear()
                    With laTbl
                        Dim C1, C2 As Object
                        For i = 0 To .Rows.Count - 1
                            C1 = IsNull(.Rows(i)("Organisme"), "")
                            C2 = IsNull(.Rows(i)("Montant"), "0,00")
                            Grd_Organismes.Rows.Add(C1, C2)
                        Next
                    End With
                End With
                laTbl = DATA_READER_GRD("select isnull(d.Domaines_Competence,'') as Domaines_Competence , 
isnull(d.Lib_Domaines_Competence,'') as  Lib_Domaines_Competence,  
isnull(Cod_Formation ,'') as Cod_Formation, isnull(t.Lib_Typ_Formation,'') as Lib_Typ_Formation
from GPEC_Domaines_Competence d 
outer apply(select isnull(convert(nvarchar(50),RowId) ,'') as Cod_Formation, isnull(Typ_Formation,'') as Lib_Typ_Formation from
Formation_Typ_Formation where id_Societe =d.id_Societe and Domaines_Competence =d.Domaines_Competence 
and exists(select Domaines_Competence from Formation_Modules m 
	where id_Societe=d.id_Societe and m.Domaines_Competence=Domaines_Competence   
	and m.Typ_Formation =RowId  
	and m.Cod_Formation = '" & Cod_Formation_txt.Text & "')) t
where d.id_Societe =" & Societe.id_Societe & "
and exists(select Domaines_Competence from Formation_Modules m where id_Societe=d.id_Societe and m.Domaines_Competence=d.Domaines_Competence   and m.Cod_Formation ='" & Cod_Formation_txt.Text & "')
order by isnull(d.Lib_Domaines_Competence,''),case when isnull(Lib_Typ_Formation,'') ='' then 'zzzzz' else isnull(Lib_Typ_Formation,'') end ")
                With Grd_Domaines_Competences
                    .Rows.Clear()
                    With laTbl
                        Dim C1, C2, C3, C4 As Object
                        For i = 0 To .Rows.Count - 1
                            C1 = .Rows(i)("Domaines_Competence")
                            C2 = .Rows(i)("Lib_Domaines_Competence")
                            C3 = .Rows(i)("Cod_Formation")
                            C4 = .Rows(i)("Lib_Typ_Formation")
                            Grd_Domaines_Competences.Rows.Add(C1, C2, C3, C4)
                            checkCompetence(i)
                        Next
                    End With
                End With
                laTbl = DATA_READER_GRD("select Matricule, Nom, isnull(Present,'false') as Present , case when Cod_Reply IS null then 'false' else 'True' end as Evalue
from Formation_Participants p
outer apply(select ltrim(rtrim(ISNULL(Nom_Agent ,'')+' '+ISNULL(Prenom_Agent,''))) as Nom from RH_Agent where Matricule =p.Matricule and id_Societe =p.id_Societe)a
outer apply(select Cod_Reply from Survey_Reply where Evalue=Cod_Formation and id_Societe=p.id_Societe and Evaluateur=p.Matricule )s
where Cod_Formation='" & Cod_Formation_txt.Text & "' and id_Societe=" & Societe.id_Societe & " order by Nom ")
                With Grd_Participants
                    .Rows.Clear()
                    With laTbl
                        Dim C1, C2, C3, C4 As Object
                        For i = 0 To .Rows.Count - 1
                            C1 = .Rows(i)("Matricule")
                            C2 = .Rows(i)("Nom")
                            C3 = .Rows(i)("Present")
                            C4 = .Rows(i)("Evalue")
                            Grd_Participants.Rows.Add(C1, C2, C3, C4)
                        Next
                    End With
                End With
            Else
                Reset_Form(Me, False)
            End If

            FormationExterne()
            Select Case Statut_Formation.SelectedValue
                Case "Planifiee"
                    Report_D.Visible = False
                    Annuler_D.Visible = False
                    Cloture_D.Visible = False

                Case "Refusee"
                    Report_D.Visible = False
                    Annuler_D.Visible = False
                    Cloture_D.Visible = False
                    Save_D.Enabled = False
                    Del_D.Enabled = False
                    Add_Agent_D.Enabled = False
                Case "Validee"
                    Save_D.Enabled = False
                    Del_D.Enabled = False
                    Add_Agent_D.Enabled = False
                Case "Annulee"
                    Report_D.Visible = False
                    Annuler_D.Visible = False
                    Cloture_D.Visible = False
                    Save_D.Enabled = False
                    Del_D.Enabled = False
                    Add_Agent_D.Enabled = False
                Case "Cloturee"
                    Annuler_D.Visible = False
                    Report_D.Visible = False
                    Cloture_D.Visible = False
                    Save_D.Enabled = False
                    Del_D.Enabled = False
                    Add_Agent_D.Enabled = False
                Case "Reportee"
                    Save_D.Enabled = False
                    Del_D.Enabled = False
                    Add_Agent_D.Enabled = False
            End Select
            Grd_Participants.Enabled = Save_D.Enabled
            Grd_Organismes.Enabled = Save_D.Enabled
            Grd_Domaines_Competences.Enabled = Save_D.Enabled
            Pnl.Enabled = Save_D.Enabled
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Cod_Formation_txt.Text)
                Code = Cod_Formation_txt.Text
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Function Valider()
        If ShowMessageBox("Etes-vous sûr de vouloir valider cette formation?", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving("VA")
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function
    Sub Enregistrer()
        Dim rsl As savingResult = Saving("")
        If IsNull(rsl.message, "") <> "" Then ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub
    Function Saving(statut As String) As savingResult
        Grd_Organismes.EndEdit(True)
        Grd_Domaines_Competences.EndEdit(True)
        Grd_Participants.EndEdit(True)
        If Lib_Formation_txt.Text.Trim = "" Then
            TabControl1.SelectedIndex = 0
            Return New savingResult With {.result = False, .message = "Renseignez un intitulé pour la formation"}
        End If
        If Dat_Du.Value >= Dat_Au.Value Then
            TabControl1.SelectedIndex = 0
            Return New savingResult With {.result = False, .message = "Incohérence date début et date fin"}
        End If
        If Grd_Domaines_Competences.RowCount = 1 Then
            TabControl1.SelectedIndex = 0
            Return New savingResult With {.result = False, .message = "Aucun module n'est renseigné"}
        End If
        If Grd_Participants.RowCount = 0 Then
            TabControl1.SelectedIndex = 0
            Return New savingResult With {.result = False, .message = "Aucun participant n'est renseigné"}
        End If
        If Statut_Formation.SelectedIndex = -1 Then
            Statut_Formation.SelectedValue = "Planifiee"
        End If
        Dim rs As New ADODB.Recordset
        If Cod_Formation_txt.Text = "" Then
            CnExecuting("exec Sys_Compteur 'Formation'," & Societe.id_Societe)
            Code = FindLibelle("Last_Code", "Fichier", "Formation", "Param_Compteur")
        Else
            Code = Cod_Formation_txt.Text
        End If
        Dim Cod_Sql As String = "select * from Formation where Cod_Formation='" & Code & "' and id_Societe=" & Societe.id_Societe
        rs.Open(Cod_Sql, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("id_Societe").Value = Societe.id_Societe
            rs("Cod_Formation").Value = Code
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = Now
        Else
            rs.Update()
        End If
        rs("Cod_Survey").Value = Cod_Survey_txt.Text
        rs("Lib_Formation").Value = Lib_Formation_txt.Text
        rs("Dat_Du").Value = Dat_Du.Value
        rs("Dat_Au").Value = Dat_Au.Value
        rs("Action_Formation").Value = Action_Formation_txt.Text
        rs("Genre_Formation").Value = Genre_Formation.SelectedValue
        rs("Nature_Formation").Value = IIf(Rd_Nature_Formation_1.Checked, 1, 2)
        rs("Budget").Value = Budget_txt.Text
        rs("Cod_Cabinet").Value = Cod_Cabinet_txt.Text
        rs("Cod_Formateur").Value = Cod_Formateur_txt.Text
        rs("Typ_Lieu").Value = IIf(Rd_Typ_Lieu_1.Checked, 1, IIf(Rd_Typ_Lieu_2.Checked, 2, 3))
        rs("Lieu").Value = IIf(Rd_Typ_Lieu_3.Checked, Lieu_txt.Text, "")
        rs("Formation_Planifiee").Value = Formation_Planifiee_chk.Checked
        rs("Statut").Value = statut
        If statut = "VA" Or statut = "SG" Then
            rs("Statut_Formation").Value = "Validee"
        Else
            rs("Statut_Formation").Value = IsNull(Statut_Formation.SelectedValue, "Planifiee")
        End If
        rs("Contenu").Value = Contenu_rtb.Rtb.RtfText
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()

        With Grd_Domaines_Competences
            CnExecuting("delete from Formation_Modules where Cod_Formation='" & Code & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from Formation_Modules where Cod_Formation='" & Code & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Domaine_Competence.Index, i).Value, "") <> "" Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Cod_Formation").Value = Code
                    rs("Domaines_Competence").Value = .Item(Domaine_Competence.Index, i).Value
                    If IsNull(.Item(Typ_Formation.Index, i).Value, "-1") <> "-1" Then rs("Typ_Formation").Value = .Item(Typ_Formation.Index, i).Value
                    rs.Update()
                End If
            Next
            rs.Close()
        End With
        With Grd_Organismes
            CnExecuting("delete from Formation_Financement where Cod_Formation='" & Code & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from Formation_Financement where Cod_Formation='" & Code & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Organisme.Index, i).Value, "") <> "" Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Cod_Formation").Value = Code
                    rs("Organisme").Value = .Item(Organisme.Index, i).Value
                    rs("Montant").Value = IsNull(.Item(Montant.Index, i).Value, "")
                    rs.Update()
                End If
            Next
            rs.Close()
        End With
        With Grd_Participants
            CnExecuting("delete from Formation_Participants where Cod_Formation='" & Code & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from Formation_Participants where Cod_Formation='" & Code & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            For i = 0 To .RowCount - 1
                If IsNull(.Item(Matricule.Index, i).Value, "") <> "" Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Cod_Formation").Value = Code
                    rs("Matricule").Value = .Item(Matricule.Index, i).Value
                    rs("Present").Value = IsNull(.Item(Present.Index, i).Value, False)
                    rs.Update()
                End If
            Next
            rs.Close()
        End With
        If Cod_Formation_txt.Text = "" Then
            Cod_Formation_txt.Text = Code
        Else
            Request()
        End If
        Return New savingResult With {.result = True, .message = "Enregistré avec succès"}
    End Function

    Private Sub Rd_Nature_Formation_2_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Nature_Formation_2.CheckedChanged
        FormationExterne()
    End Sub
    Sub FormationExterne()
        CodCabinet.Enabled = (Rd_Nature_Formation_2.Checked)
        Rd_Typ_Lieu_2.Enabled = (Rd_Nature_Formation_2.Checked)
        If Not Rd_Nature_Formation_2.Checked Then
            Cod_Cabinet_txt.Text = ""
            Rd_Typ_Lieu_2.Checked = False
        End If
    End Sub

    Private Sub Cod_Formation_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Formation_txt.TextChanged
        Request()
    End Sub
    Sub Reporter()
        If ShowMessageBox("Etes-vous sûr de vouloir reporter cette formation", "Annulation", MessageBoxButtons.OKCancel, msgIcon.Warning) = MsgBoxResult.Cancel Then Return
        Dim f As New Zoom_Formation_Reporter
        With f
            .frm = Me
            .Dat_Du.Value = Dat_Du.Value
            .Dat_Du.MinDate = Dat_Du.Value
            .Dat_Au.Value = Dat_Au.Value
            .Dat_Au.MinDate = Dat_Du.Value
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Statut_Formation.SelectedValue = "Reportee"

        updateStatutFormation()
    End Sub
    Sub updateStatutFormation()
        CnExecuting("update Formation set Statut_Formation='" & Statut_Formation.SelectedValue & "', Dat_" & Statut_Formation.SelectedValue & "=getdate(), " & Statut_Formation.SelectedValue & "_Par ='" & theUser.Login & "' where Cod_Formation='" & Cod_Formation_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Request()
    End Sub
    Sub Annuler()
        If ShowMessageBox("Etes-vous sûr de vouloir annuler cette formation", "Annulation", MessageBoxButtons.OKCancel, msgIcon.Warning) = MsgBoxResult.Cancel Then Return
        Statut_Formation.SelectedValue = "Annulee"
        updateStatutFormation()
    End Sub

    Sub Cloturer()
        If ShowMessageBox("Etes-vous sûr de vouloir clôturer cette formation", "Annulation", MessageBoxButtons.OKCancel, msgIcon.Warning) = MsgBoxResult.Cancel Then Return
        Statut_Formation.SelectedValue = "Cloturee"
        updateStatutFormation()
    End Sub

    Private Sub LinkLabel2_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Zoom1("MS156", Cod_Survey_txt, Me, "isnull(Domaine,'')='F'")
    End Sub

    Private Sub Cod_Survey_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Survey_txt.TextChanged
        Lib_Survey_txt.Text = FindLibelle("Lib_Survey", "Cod_Survey", Cod_Survey_txt.Text, "Survey")
    End Sub

    Private Sub Grd_Domaines_Competences_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Domaines_Competences.CellValidated
        checkCompetence(e.RowIndex)
    End Sub
    Sub checkCompetence(ind As Integer)
        With Grd_Domaines_Competences
            If IsNull(.Item(Typ_Formation.Index, ind).Value, "").Trim <> "" Then
                If ComptenceTypFormation.Select("isnull(Typ_Formation,'0')='" & .Item(Typ_Formation.Index, ind).Value & "'").Length = 0 Then
                    .Item(Msg.Index, ind).Style.ForeColor = Color.Red
                    .Item(Msg.Index, ind).Value = ChrW(&H26A0) & " : Type de formaion non renseigné pour ce cabinet."
                Else
                    .Item(Msg.Index, ind).Style.ForeColor = .Item(Typ_Formation.Index, ind).Style.ForeColor
                    .Item(Msg.Index, ind).Value = ""
                End If
            End If
        End With
    End Sub

    Private Sub Grd_Domaines_Competences_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Domaines_Competences.RowValidated
        checkCompetence(e.RowIndex)
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