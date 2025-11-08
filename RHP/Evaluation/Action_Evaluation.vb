Imports System.ComponentModel
Imports DevComponents.AdvTree
Public Class Action_Evaluation
    Friend Code As String = ""
    Dim TblEntite, TblAgent, TblEvaDetail, TblEva As New DataTable
    Dim _Right, _Center As New DevComponents.DotNetBar.ElementStyle
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Request_D As ud_btn
    Dim Del_D As ud_btn
    Dim Report_D As ud_btn
    Dim Annuler_D As ud_btn
    Dim Valide_D As ud_btn
    Sub masquerBtn()
        Annuler_D.Visible = False
        Report_D.Visible = False
        Save_D.Enabled = False
        Del_D.Enabled = False
        Valide_D.Visible = False
    End Sub
    Sub Chargement()
        If New_D Is Nothing Then
            If Me.Name = "" Then Me.Name = "Action_Evaluation"
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Request_D = dictButtons("Request_D")
            Del_D = dictButtons("Del_D")
            Report_D = dictButtons("Report_D")
            Annuler_D = dictButtons("Annuler_D")
            Valide_D = dictButtons("Valide_D")
        End If
        If Statut_Evaluation.Items.Count = 0 Then Statut_Evaluation.fromRubrique("Statut_Evaluation")
        If TblEntite.Columns.Count = 0 Then TblEntite = DATA_READER_GRD("select * from Sys_Organisation where id_Societe='" & Societe.id_Societe & "'")
        If TblAgent.Columns.Count = 0 Then TblAgent = DATA_READER_GRD("select Matricule,Nom, Cod_Grade , Grade, Poste,round(DATEDIFF (month,Dat_Entree,getdate())/12,2) as Anciennete, Titre, Cod_Entite,Racine 
from dbo.Sys_RH_Preparation_Paie_Agent a
outer apply (select isnull(Racine,'') Racine from  Sys_Organisation where id_Societe=a.id_Societe and Cod_Entite=a.Cod_Entite)o
where id_Societe ='" & Societe.id_Societe & "'")
        If TblEvaDetail.Columns.Count = 0 Then TblEvaDetail = DATA_READER_GRD("select Typ_Element, Cod_Element from Evaluation_Detail_Evalue where Cod_Evaluation='aq87645daduizgtnkb' and id_Societe=-1")
        If TblEva.Columns.Count = 0 Then TblEva = DATA_READER_GRD("select Evalue from Survey_Reply where id_Societe =-1 and isnull(Ref_Evaluation,'')='' and Cod_Survey ='' and Typ_Evalue ='X' and Evalue =''")
    End Sub
    Private Sub Cod_Survey_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Survey_txt.TextChanged
        Lib_Survey_txt.Text = FindLibelle("Lib_Survey", "Cod_Survey", Cod_Survey_txt.Text, "Survey")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS158", Cod_Evaluation_txt, Me)
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Evaluateur.LinkClicked
        Appel_Zoom1("MS018", Evaluateur_txt, Me)
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Evaluateur_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom", "Matricule", Evaluateur_txt.Text, "Sys_RH_Preparation_Paie_Agent")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS156", Cod_Survey_txt, Me, "isnull(Domaine,'')='E'")
    End Sub

    Private Sub ud_RadioBox2_CheckedChanged(sender As Object, e As EventArgs) Handles Rd2.CheckedChanged, Rd1.CheckedChanged
        If Not Rd2.Checked Then
            Evaluateur_txt.Text = ""
        End If
        Evaluateur.Enabled = (Rd2.Checked)
    End Sub

    Private Sub Evaluation_Action_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Right.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far
        _Center.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Nouveau()
    End Sub
    Private Sub Cod_Evaluation_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Evaluation_txt.TextChanged
        Request()
    End Sub
    Sub Request()
        Chargement()
        masquerBtn()
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
        DroitAcces(Me, DroitModify_Fiche(Cod_Evaluation_txt.Text, Me))

        Dim Tbl As DataTable = DATA_READER_GRD("select * from Evaluation where Cod_Evaluation='" & Cod_Evaluation_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        With Tbl
            If .Rows.Count > 0 Then
                Description_txt.Text = IsNull(.Rows(0)("Description"), "")
                Rd1.Checked = (IsNull(.Rows(0)("Type_Evaluateur"), 1) = 1)
                Rd2.Checked = (IsNull(.Rows(0)("Type_Evaluateur"), 1) = 2)
                Evaluateur_txt.Text = IsNull(.Rows(0)("Evaluateur"), "")
                Dat_Du.Value = IsNull(.Rows(0)("Dat_Du"), Now.ToShortDateString)
                Dat_Au.Value = IsNull(.Rows(0)("Dat_Au"), Now.ToShortDateString)
                Cod_Survey_txt.Text = IsNull(.Rows(0)("Cod_Survey"), "")
                Cod_Grade_txt.Text = IsNull(.Rows(0)("Cod_Grade"), "")
                Cod_Entite_txt.Text = IsNull(.Rows(0)("Cod_Entite"), "")
                Sous_Entite_chk.Checked = IsNull(.Rows(0)("Sous_Entite"), True)
                Statut_Evaluation.SelectedValue = IsNull(.Rows(0)("Statut_Evaluation"), "Planifiee")
            Else
                Reset_Form(Me)
            End If
            TblEvaDetail = DATA_READER_GRD("select Typ_Element, Cod_Element from Evaluation_Detail_Evalue where Cod_Evaluation='" & Cod_Evaluation_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            TblEva = DATA_READER_GRD("select Evalue from Survey_Reply where id_Societe =" & Societe.id_Societe & " and Cod_Survey ='" & Cod_Survey_txt.Text & "' and Typ_Evalue ='E' and isnull(Ref_Evaluation,'')='" & Cod_Evaluation_txt.Text & "' and Evalue in (select Cod_Element from Evaluation_Detail_Evalue where Typ_Evalue='E' and Cod_Evaluation='" & Cod_Evaluation_txt.Text & "' and id_Societe=" & Societe.id_Societe & ")")
        End With
        Request_D.Enabled = Save_D.Enabled
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Evaluation_txt.Text)
            Code = Cod_Evaluation_txt.Text
        End If
        Select Case Statut_Evaluation.SelectedValue
            Case "Planifiee"
                Report_D.Visible = False
                Annuler_D.Visible = False
                Valide_D.Visible = True
                Save_D.Enabled = True
                Del_D.Enabled = True
            Case "Refusee"
                Report_D.Visible = False
                Annuler_D.Visible = False
                Valide_D.Visible = False
                Save_D.Enabled = False
                Del_D.Enabled = False
            Case "Validee"
                Save_D.Enabled = False
                Del_D.Enabled = False
                Valide_D.Visible = False
                Report_D.Visible = True
                Annuler_D.Visible = True

            Case "Annulee"
                Report_D.Visible = False
                Annuler_D.Visible = False
                Valide_D.Visible = False
                Save_D.Enabled = False
                Del_D.Enabled = False
            Case "Encours"
                Annuler_D.Visible = False
                Report_D.Visible = False
                Valide_D.Visible = False
                Save_D.Enabled = False
                Del_D.Enabled = False
            Case "Cloturee"
                Annuler_D.Visible = False
                Report_D.Visible = False
                Valide_D.Visible = False
                Save_D.Enabled = False
                Del_D.Enabled = False
            Case "Reportee"
                Annuler_D.Visible = False
                Report_D.Visible = False
                Save_D.Enabled = False
                Del_D.Enabled = False
                Valide_D.Visible = True
        End Select
        RequestNode(Cod_Evaluation_txt.Text)
    End Sub
    Function Saving(statut As String) As Boolean
        If (statut = "" Or statut = "Planifiee") Then
            If ShowMessageBox("Etes-vous sûr de vouloir mettre à jour le statut de l'action d'évaluation à " & Statut_Evaluation.Text & "?", "Mise à jour de statut", MessageBoxButtons.YesNo, msgIcon.Warning) = MsgBoxResult.No Then Return False
        End If
        Dim rnd As New Random
        Dim flgMaj As Integer = rnd.Next(129, 996)
        If Description_txt.Text.Trim = "" Then
            ShowMessageBox("Renseignez une description", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            Description_txt.Select()
            Return False
        End If
        If Evaluateur_txt.Text.Trim = "" And Rd2.Checked Then
            ShowMessageBox("Renseignez l'évaluateur", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            Matricule__LinkClicked(Nothing, Nothing)
            Return False
        End If
        If Cod_Entite_txt.Text.Trim = "" Then
            ShowMessageBox("Renseignez l'entité à évaluer", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            LinkLabel2_LinkClicked(Nothing, Nothing)
            Return False
        End If
        If Cod_Survey_txt.Text.Trim = "" Then
            ShowMessageBox("Renseignez le modèle du formulaire d'évaluation", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            LinkLabel3_LinkClicked(Nothing, Nothing)
            Return False
        End If
        If Dat_Du.Value >= Dat_Au.Value Then
            ShowMessageBox("Incohérence date début et date fin", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End If
        If Statut_Evaluation.SelectedIndex = -1 Then
            Statut_Evaluation.SelectedValue = "Planifiee"
        End If
        Dim rs As New ADODB.Recordset
        If Cod_Evaluation_txt.Text = "" Then
            CnExecuting("exec Sys_Compteur 'Evaluation'," & Societe.id_Societe)
            Code = FindLibelle("Last_Code", "Fichier", "Evaluation", "Param_Compteur")
        Else
            Code = Cod_Evaluation_txt.Text
        End If
        Dim Cod_Sql As String = "select * from Evaluation where Cod_Evaluation='" & Code & "' and id_Societe=" & Societe.id_Societe
        rs.Open(Cod_Sql, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("id_Societe").Value = Societe.id_Societe
            rs("Cod_Evaluation").Value = Code
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = Now
        Else
            rs.Update()
        End If
        rs("Cod_Survey").Value = Cod_Survey_txt.Text
        rs("Cod_Grade").Value = Cod_Grade_txt.Text
        rs("Cod_Entite").Value = Cod_Entite_txt.Text
        rs("Sous_Entite").Value = Sous_Entite_chk.Checked
        rs("Description").Value = Description_txt.Text
        rs("Dat_Du").Value = Dat_Du.Value
        rs("Dat_Au").Value = Dat_Au.Value
        rs("Type_Evaluateur").Value = IIf(Rd2.Checked, 2, 1)
        rs("Evaluateur").Value = Evaluateur_txt.Text
        rs("Statut_Evaluation").Value = IsNull(statut, "Planifiee")
        If IsNull(statut, "Planifiee") <> "Planifiee" Then
            rs("Dat_" & statut).Value = Now
            rs(statut & "_Par").Value = theUser.Login
        End If
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()

        For Each n As Node In Adv.Nodes
            SavingNodes(Code, n, flgMaj)
        Next
        CnExecuting("delete from Evaluation_Detail_Evalue where Cod_Evaluation='" & Cod_Evaluation_txt.Text & "' and id_Societe=" & Societe.id_Societe & " and Flg_Maj<>" & flgMaj)
        If Cod_Evaluation_txt.Text = "" Then
            Cod_Evaluation_txt.Text = Code
        Else
            Request()
        End If
        Return True
    End Function
    Sub Reporter()
        Dim f As New Zoom_Evaluation_Reporter
        With f
            .frm = Me
            .Dat_Du.Value = Dat_Du.Value
            .Dat_Du.MinDate = Dat_Du.Value
            .Dat_Au.Value = Dat_Au.Value
            .Dat_Au.MinDate = Dat_Du.Value
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Statut_Evaluation.SelectedValue = "Reportee"
        Saving("Reportee")
    End Sub

    Sub Annuler()
        Statut_Evaluation.SelectedValue = "Annulee"
        Saving("Annulee")
    End Sub

    Sub Cloturer()
        Statut_Evaluation.SelectedValue = "Cloturee"
        Saving("Cloturee")
    End Sub
    Sub Valider()
        Statut_Evaluation.SelectedValue = "Validee"
        Saving("Validee")
    End Sub
    Private Sub Evaluation_Action_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled = True Then
                If Cod_Evaluation_txt.Text = "" Or CnExecuting("select count(*) from Evaluation where Cod_Evaluation='" & Cod_Evaluation_txt.Text & "' and id_Societe=" & Societe.IdentFisc).Fields(0).Value = 0 Then
                    Exit Sub
                End If
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Evaluation_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Deleting()
        Diviseur_delete("Evaluation", "Cod_Evalutaion", "Cod_Evaluation", Cod_Evaluation_txt, Me, True, True)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Zoom1("MS010", Cod_Entite_txt, Me)
    End Sub
    Sub Nouveau()
        Chargement()
        Reset_Form(Me)
        masquerBtn()
        Statut_Evaluation.SelectedValue = "Planifiee"
        Save_D.Enabled = True
        Dat_Du.Value = Now.ToShortDateString
        Dat_Au.Value = Now.ToShortDateString
        Description_txt.Select()
        Sous_Entite_chk.Checked = True
        Rd2.Checked = True
    End Sub

    Private Sub Grade__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Grade_.LinkClicked
        Appel_Zoom1("MS015", Cod_Grade_txt, Me)
    End Sub

    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
        Adv.Nodes.Clear()
        RequestNode(Cod_Evaluation_txt.Text)
    End Sub

    Private Sub Sous_Entite_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Sous_Entite_chk.CheckedChanged
        Adv.Nodes.Clear()
        RequestNode(Cod_Evaluation_txt.Text)
    End Sub

    Sub Actualiser()
        If Cod_Evaluation_txt.Text <> "" And Adv.Nodes.Count > 0 Then
            If ShowMessageBox("En cliquant vous allez réinitialiser la liste des évalués. Voulez-vous continuer?", "Rafraîchir", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        End If
        Adv.Nodes.Clear()
        RequestNode("")
    End Sub

    Sub Enregistrer()
        Statut_Evaluation.SelectedValue = "Planifiee"
        Saving("Planifiee")
    End Sub

    Private Sub SupprimerLactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerLactionToolStripMenuItem.Click
        With Adv
            If .Nodes.Count = 0 Then Return
            If .SelectedNode Is Nothing Then Return
            If ShowMessageBox("Etes-vous sûr de vouloir supprimer cet élément?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
            .SelectedNode.Parent.Nodes.Remove(.SelectedNode)
        End With
    End Sub

    Private Sub Cod_Grade_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Grade_txt.TextChanged
        Lib_Grade_txt.Text = FindLibelle("Lib_Grade", "Cod_Grade", Cod_Grade_txt.Text, "Org_Grade")
        RequestNode(Cod_Evaluation_txt.Text)
    End Sub
    Sub RequestNode(CodEvaluation As String)
        Chargement()
        Adv.Nodes.Clear()
        Dim EntiteGrade As String = ""
        Dim Dv As DataView = TblAgent.DefaultView
        Dv.RowFilter = "isnull(Racine,'')+';'+isnull(Cod_Entite,'')+';' like '%;" & Cod_Entite_txt.Text & ";%'  and isnull(Cod_Grade,'')='" & Cod_Grade_txt.Text & "'"
        With Dv.ToTable(True, "Racine", "Cod_Entite")
            For i = 0 To .Rows.Count - 1
                EntiteGrade &= IIf(IsNull(.Rows(i)("Racine"), "") = "", ";", .Rows(i)("Racine")) & IsNull(.Rows(i)("Cod_Entite"), "") & ";"
            Next
        End With
        ChargerTrv(CodEvaluation, Nothing, Cod_Entite_txt.Text, EntiteGrade)
    End Sub
    Sub ChargerTrv(CodEvaluation As String, oNd As Node, childNodeName As String, EntiteGrade As String)
        Chargement()
        Dim nrw() As DataRow = TblEntite.Select("Cod_Entite='" & childNodeName & "'")
        If nrw.Length > 0 And (CodEvaluation = "" Or (TblEvaDetail.Select("Cod_Element ='" & childNodeName & "'").Length > 0)) Then
            Dim Nod As New Node
            With Nod
                .DragDropEnabled = False
                .Text = nrw(0)("Lib_Entite")
                .Name = nrw(0)("Cod_Entite")
                .Tag = "Entite"
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells(1).Text = ""
                .Cells(2).Text = ""
                .Cells(3).Text = ""
                .Cells(4).Text = ""
                .Cells(5).Text = Nothing
                Dim aRw() As DataRow = TblAgent.Select("Cod_Entite='" & .Name & "'" & IIf(Cod_Grade_txt.Text <> "", " and Cod_Grade='" & Cod_Grade_txt.Text & "'", ""))
                For i = 0 To aRw.Length - 1
                    If (CodEvaluation = "" Or (TblEvaDetail.Select("Cod_Element ='" & aRw(i)("Matricule") & "'").Length > 0)) Then
                        Dim Ndf As New Node
                        With Ndf
                            .DragDropEnabled = False
                            .Text = aRw(i)("Matricule") & " : " & aRw(i)("Nom")
                            .Name = aRw(i)("Matricule")
                            .Tag = "Agent"
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells(1).Text = aRw(i)("Grade")
                            .Cells(2).Text = aRw(i)("Poste")
                            .Cells(3).Text = aRw(i)("Anciennete")
                            .Cells(4).Text = aRw(i)("Titre")
                            .Cells(5).Checked = (TblEva.Select("Evalue='" & .Name & "'").Length > 0)
                            .Cells(5).CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox
                            .Cells(5).CheckBoxVisible = True
                            .Cells(5).Enabled = False
                            .Cells(5).StyleNormal = _Center
                            .Cells(3).StyleNormal = _Right
                            .Image = My.Resources.fleche
                            .ContextMenu = CntM
                        End With
                        Nod.Nodes.Add(Ndf)
                    End If
                Next
                Nod.ContextMenu = CntM
                If oNd Is Nothing Then
                    Adv.Nodes.Add(Nod)
                    Adv.ExpandAll()
                Else
                    oNd.Nodes.Add(Nod)
                    oNd.ExpandAll()
                End If
                If Sous_Entite_chk.Checked Then
                    Dim vRw() As DataRow = TblEntite.Select("Entite_Parente='" & .Name & "' and Cod_Entite<>'" & .Name & "'")
                    If vRw.Length > 0 Then
                        For i = 0 To vRw.Length - 1
                            If EntiteGrade.Contains(";" + vRw(i)("Cod_Entite") & ";") Or EntiteGrade = "" Then
                                If (CodEvaluation = "" Or (TblEvaDetail.Select("Cod_Element ='" & vRw(i)("Cod_Entite") & "'").Length > 0)) Then
                                    ChargerTrv(CodEvaluation, Nod, vRw(i)("Cod_Entite"), EntiteGrade)
                                End If
                            End If
                        Next
                        .Image = My.Resources.fdr_1
                    Else
                        .Image = My.Resources.fdr_0
                    End If
                Else
                    .Image = My.Resources.fdr_0
                End If

            End With

        End If
    End Sub
    Sub SavingNodes(CodEvaluation As String, oNod As Node, FlgMag As Integer)
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Evaluation_Detail_Evalue where Cod_Evaluation='" & Cod_Evaluation_txt.Text & "' and Cod_Element='" & oNod.Name & "' and Typ_Element='" & oNod.Tag & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Cod_Evaluation").Value = CodEvaluation
            rs("id_Societe").Value = Societe.id_Societe
            rs("Typ_Element").Value = oNod.Tag
            rs("Cod_Element").Value = oNod.Name
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()
        End If
        rs("Flg_Maj").Value = FlgMag
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()
        For Each n In oNod.Nodes
            SavingNodes(CodEvaluation, n, FlgMag)
        Next
    End Sub
    Private Sub CntM_Opening(sender As Object, e As CancelEventArgs) Handles CntM.Opening
        SupprimerLactionToolStripMenuItem.Enabled = Save_D.Enabled
    End Sub
End Class