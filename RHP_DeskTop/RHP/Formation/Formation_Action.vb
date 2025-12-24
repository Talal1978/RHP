Imports System.ComponentModel
Imports DevComponents.AdvTree
Public Class Formation_Action
    Friend Code As String = ""
    Dim TblActions As New DataTable
    Dim _Right, _Center, _StatutRed, _StatutGreen, _StatutYellow As New DevComponents.DotNetBar.ElementStyle
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Request_D As ud_btn
    Private Sub Ctb_Compta_Axe_Ana_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS154", Cod_Action_txt, Me)
    End Sub
    Sub chargementCombo()
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Request_D = dictButtons("Request_D")
        End If
    End Sub
    Private Sub Formation_Typ_Formation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chargementCombo()
        _Right.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far
        _Center.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        With _StatutRed
            .TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
            .TextColor = Color.Red
        End With
        With _StatutGreen
            .TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
            .TextColor = Color.Green
        End With
        With _StatutYellow
            .TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
            .TextColor = Color.Yellow
        End With
    End Sub
    Sub Request()
        Try
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
            DroitAcces(Me, DroitModify_Fiche(Cod_Action_txt.Text, Me))
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Cod_Action_txt.Text)
                Code = Cod_Action_txt.Text
            End If
            chargementCombo()
            Lib_Action_txt.Text = FindLibelle("Lib_Action", "Cod_Action", Cod_Action_txt.Text, "Formation_Action_Formation")
            Action_Mere_txt.Text = FindLibelle("Action_Mere", "Cod_Action", Cod_Action_txt.Text, "Formation_Action_Formation")
            Contenu_rtb.Rtb.RtfText = FindLibelle("Contenu", "Cod_Action", Cod_Action_txt.Text, "Formation_Action_Formation")
            TblActions = DATA_READER_GRD("select Cod_Action,Lib_Action, isnull(Action_Mere,'') as Action_Mere from Formation_Action_Formation where id_Societe=" & Societe.id_Societe)
            Dim FirstAction As String = getFirstActionMere(Cod_Action_txt.Text)
            If FirstAction = "" Then FirstAction = Cod_Action_txt.Text

            Adv.Nodes.Clear()
            ChargerActionDeFormation(FirstAction, Nothing)
            Adv.ExpandAll()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Function getFirstActionMere(NumAction As String) As String
        Dim nrw() As DataRow = TblActions.Select("Cod_Action='" & NumAction & "'")
        If nrw.Length = 0 Then Return NumAction
        If nrw(0)("Action_Mere") = "" Then
            Return NumAction
        Else
            Return getFirstActionMere(nrw(0)("Action_Mere"))
        End If
    End Function
    Sub ChargerActionDeFormation(NumAction As String, oNd As Node)

        Dim nrw() As DataRow = TblActions.Select("Cod_Action='" & NumAction & "'")
        If nrw.Length > 0 Then
            Dim Nod As New Node
            With Nod
                .DragDropEnabled = False
                .Text = nrw(0)("Lib_Action")
                .Name = nrw(0)("Cod_Action")
                .Tag = "Action"
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells.Add(New Cell)
                .Cells(1).Text = ""
                .Cells(2).Text = ""
                .Cells(3).Text = ""
                .Cells(4).Text = ""
                .Cells(5).Text = ""
                .Cells(6).Text = Nothing
                .Cells(7).Text = Nothing
                Dim CodSql As String = "select Cod_Formation, Lib_Formation, convert(varchar, Dat_Du, 103) Dat_Du,
convert(varchar, Dat_Au, 103) Dat_Au, 
isnull(g.Genre_Formation,'') as Genre_Formation, case when isnull(Nature_Formation,'2')='2' then 'Externe' else 'Interne' end Nature_Formation, Budget, 
s.Statut_Formation , isnull(Raison_Sociale,'') as Cabinet
from dbo.Formation f
outer apply (select Membre as Genre_Formation from Param_Rubriques where Nom_Controle ='Genre_Formation' and Valeur=Genre_Formation)g
outer apply (select Membre as Statut_Formation from Param_Rubriques where Nom_Controle ='Statut_Formation' and Valeur=Statut_Formation)s
outer apply (select Raison_Sociale from Formation_Cabinet  where Cod_Cabinet  =f.Cod_Cabinet and id_Societe =f.id_Societe )c
where isnull(Action_Formation,'') ='" & NumAction & "' and id_Societe =" & Societe.id_Societe
                Dim TblFormation As DataTable = DATA_READER_GRD(CodSql)
                For i = 0 To TblFormation.Rows.Count - 1
                    Dim Ndf As New Node
                    With Ndf
                        .DragDropEnabled = False
                        .Text = TblFormation.Rows(i)("Lib_Formation")
                        .Name = TblFormation.Rows(i)("Cod_Formation")
                        .Tag = "Formation"
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells(1).Text = TblFormation.Rows(i)("Dat_Du")
                        .Cells(2).Text = TblFormation.Rows(i)("Dat_Au")
                        .Cells(3).Text = TblFormation.Rows(i)("Nature_Formation")
                        .Cells(4).Text = TblFormation.Rows(i)("Cabinet")
                        .Cells(5).Text = FormatNumber(TblFormation.Rows(i)("Budget"), 2)
                        .Cells(6).Text = TblFormation.Rows(i)("Statut_Formation")
                        .Cells(7).Text = TblFormation.Rows(i)("Genre_Formation")
                        .Cells(5).StyleNormal = _Right
                        .Cells(1).StyleNormal = _Center
                        .Cells(2).StyleNormal = _Center
                        Select Case .Cells(6).Text
                            Case "Refusee"
                                .Cells(6).StyleNormal = _StatutRed
                            Case "Reportee"
                                .Cells(6).StyleNormal = _StatutYellow
                            Case "Cloturee"
                                .Cells(6).StyleNormal = _StatutGreen
                            Case Else
                                .Cells(6).StyleNormal = _Center
                        End Select
                        .Image = My.Resources.fleche
                    End With
                    Nod.Nodes.Add(Ndf)
                Next
                Nod.ContextMenu = CntM
                If oNd Is Nothing Then
                    Adv.Nodes.Add(Nod)
                Else
                    oNd.Nodes.Add(Nod)
                End If

                Dim vRw() As DataRow = TblActions.Select("Action_Mere='" & .Name & "' and Cod_Action<>'" & .Name & "'")
                If vRw.Length > 0 Then
                    For i = 0 To vRw.Length - 1
                        ChargerActionDeFormation(vRw(i)("Cod_Action"), Nod)
                    Next
                    .Image = My.Resources.fdr_1
                Else
                    .Image = My.Resources.fdr_0
                End If
            End With

        End If
    End Sub
    Private Sub Domaines_Competence_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Action_txt.TextChanged
        Request()
    End Sub

    Private Sub Grd_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs)
        e.Cancel = e.Row.ReadOnly
    End Sub

    Private Sub Domaines_Competence_txt_Leave(sender As Object, e As EventArgs) Handles Cod_Action_txt.Leave
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        Lib_Action_txt.Select()
    End Sub
    Sub Enregistrer()
        Dim dict As New Dictionary(Of String, Object)
        If Lib_Action_txt.Text.Trim <> "" Then
            dict.Add("Cod_Action", Cod_Action_txt.Text)
            dict.Add("Lib_Action", Lib_Action_txt.Text)
            dict.Add("Action_Mere", Action_Mere_txt.Text)
            SavingAction(dict)
        End If
        For Each nd As Node In Adv.Nodes
            If nd.Tag = "Action" Then
                savingNodes(nd)
            End If
        Next
        If Cod_Action_txt.Text = "" Then
            If dict.ContainsKey("Cod_Action") Then
                Cod_Action_txt.Text = dict("Cod_Action")
            End If
        Else
            Request()
        End If

    End Sub
    Sub savingNodes(Nd As Node)
        With Nd
            If .Tag = "Action" Then
                Dim dict As New Dictionary(Of String, Object)
                dict.Add("Cod_Action", IIf(.Name.StartsWith("NEW"), "", .Name))
                dict.Add("Lib_Action", .Text)
                If .Parent IsNot Nothing Then
                    dict.Add("Action_Mere", .Parent.Name)
                Else
                    dict.Add("Action_Mere", "")
                End If
                SavingAction(dict)
                If .Name.ToString.ToUpper.StartsWith("NEW") Then .Name = dict("Cod_Action")
                For Each nod As Node In Nd.Nodes
                    If nod.Tag = "Action" Then
                        savingNodes(nod)
                    End If
                Next
            End If
        End With
    End Sub
    Sub SavingAction(Action As Dictionary(Of String, Object))
        If Action("Cod_Action") = "" Then
            CnExecuting("exec Sys_Compteur 'Action_Formation'," & Societe.id_Societe)
            Action("Cod_Action") = FindLibelle("Last_Code", "Fichier", "Action_Formation", "Param_Compteur")
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Formation_Action_Formation where Cod_Action='" & Action("Cod_Action") & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Cod_Action").Value = Action("Cod_Action")
            rs("id_Societe").Value = Societe.id_Societe
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()
        End If
        rs("Lib_Action").Value = Action("Lib_Action")
        rs("Action_Mere").Value = Action("Action_Mere")
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()

    End Sub
    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)

    End Sub
    Sub Deleting()
        If Suppression(Cod_Action_txt.Text) Then Reset_Form(GroupBox2)
    End Sub
    Function Suppression(CodAction As String) As Boolean
        If CodAction = "" Then Return False
        If MessageBoxRHP(541, CodAction) = MsgBoxResult.Cancel Then Return False
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Formation where isnull(Action_Formation,'')='" & CodAction & "' and id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count > 0 Then
            ShowMessageBox("Cette action de formation est utilisée dans des formations", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End If
        Tbl = DATA_READER_GRD("select top 1 * from Formation_Action_Formation where isnull(Action_Mere,'')='" & CodAction & "' and id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count > 0 Then
            ShowMessageBox("Cette action de formation est utilisée comme action mère pour autres actions de formations", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End If
        Dim TblUse As String = CheckMouvemente(Me, CodAction)
        If TblUse <> "" Then
            MessageBoxRHP(542, TblUse)
            Return False
        End If
        If CnExecuting("Select count(*) from Formation_Action_Formation where Cod_Action = '" & CodAction & "'").Fields(0).Value > 0 Then
            CnExecuting("delete from Formation_Action_Formation where Cod_Action = '" & CodAction & "' and id_Societe=" & Societe.id_Societe)
            CnExecuting("insert into Mouchard_Suppression values ('Formation_Action_Formation','Cod_Action','" & Societe.id_Societe & " - " & CodAction & "','" & theUser.id_User & "',getdate())")
        Else
            MessageBoxRHP(543, CodAction)
            Return False
        End If
        Return True
    End Function
    Private Sub Action_Mere_txt_TextChanged(sender As Object, e As EventArgs) Handles Action_Mere_txt.TextChanged
        Lib_Action_Mere_txt.Text = FindLibelle("Lib_Action", "Cod_Action", Action_Mere_txt.Text, "Formation_Action_Formation")
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Zoom1("MS154", Action_Mere_txt, Me)
    End Sub

    Private Sub RenommerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenommerToolStripMenuItem.Click
        With Adv
            If Not .SelectedNode Is Nothing Then
                With .SelectedNode
                    If .Tag = "Action" Then
                        .Editable = True
                        .BeginEdit()
                    End If
                End With
            End If
        End With
    End Sub

    Private Sub AjouterUneActionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterUneActionToolStripMenuItem.Click
        With Adv
            If Not .SelectedNode Is Nothing Then
                With .SelectedNode
                    If .Tag = "Action" Then
                        Dim Nod As New Node
                        With Nod
                            .DragDropEnabled = False
                            .Text = "Nouvelle action"
                            .Name = "NEW" & Now
                            .Tag = "Action"
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells(1).Text = ""
                            .Cells(2).Text = ""
                            .Cells(3).Text = ""
                            .Cells(4).Text = ""
                            .Cells(5).Text = ""
                            .Cells(6).Text = Nothing
                            .Cells(7).Text = Nothing
                            .Image = My.Resources.fdr_0
                        End With
                        .Nodes.Add(Nod)
                        Nod.ContextMenu = CntM
                        Nod.Editable = True
                        Nod.BeginEdit()
                    End If
                End With
            End If
        End With
    End Sub

    Sub Actualiser()
        Request()
    End Sub

    Private Sub AjouterUneFormationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterUneFormationToolStripMenuItem.Click
        With Adv
            If Not .SelectedNode Is Nothing Then
                With .SelectedNode
                    If .Tag = "Action" Then
                        If TblActions.Select("Cod_Action='" & .Name & "'").Length = 0 Then
                            ShowMessageBox("Vous devez d'abord enregistrer l'action en cours", "Actions de formation", MessageBoxButtons.OK, msgIcon.Stop)
                            Return
                        End If
                        Dim f As New Formation
                        With f
                            .Action_Formation_txt.Text = Adv.SelectedNode.Name
                            .StartPosition = FormStartPosition.CenterScreen
                            newShowEcran(f, True)
                        End With
                    End If
                End With
            End If
        End With
    End Sub

    Private Sub Adv_NodeDoubleClick(sender As Object, e As TreeNodeMouseEventArgs) Handles Adv.NodeDoubleClick
        Select Case e.Node.Tag
            Case "Action"
                If e.Node.Name.StartsWith("NEW") Then Return
                Cod_Action_txt.Text = e.Node.Name
            Case "Formation"
                Dim f As New Formation
                With f
                    .Cod_Formation_txt.Text = e.Node.Name
                    newShowEcran(f)
                End With
        End Select
    End Sub

    Private Sub SupprimerLactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerLactionToolStripMenuItem.Click
        With Adv
            If Not .SelectedNode Is Nothing Then
                With .SelectedNode
                    If .Tag = "Action" Then
                        If ((.Nodes.Count = 0) And Del_D.Enabled) Then
                            If Suppression(.Name) Then
                                .Parent.Nodes.RemoveAt(.Index)
                            End If
                        End If
                    End If
                End With
            End If
        End With
    End Sub

    Private Sub CntM_Opening(sender As Object, e As CancelEventArgs) Handles CntM.Opening
        SupprimerLactionToolStripMenuItem.Enabled = False
        With Adv
            If Not .SelectedNode Is Nothing Then
                With .SelectedNode
                    If .Tag = "Action" Then
                        SupprimerLactionToolStripMenuItem.Enabled = ((.Nodes.Count = 0) And Del_D.Enabled)
                    End If
                End With
            End If
        End With
    End Sub
End Class