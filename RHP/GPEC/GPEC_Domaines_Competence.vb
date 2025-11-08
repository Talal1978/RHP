Imports DevComponents.AdvTree
Public Class GPEC_Domaines_Competence
    Dim flg As Integer
    Dim rnd As New Random
    Dim DC_Tbl As New DataTable
    Private Sub GPEC_Domaines_Competence_Load(sender As Object, e As EventArgs) Handles Me.Load
        nSoc.Text = Societe.Denomination
        nSoc.Name = Societe.id_Societe
        Requesting()
    End Sub
    Sub getDC(parentName As String)
        Dim nrw() = DC_Tbl.Select("[Parent]='" & parentName & "'", "Rang")
        Dim oNod As Node = Adv.FindNodeByName(parentName)
        If oNod Is Nothing Then Return
        For Each r In nrw
            Dim _Nd As New Node
            With _Nd
                .Name = r("Domaines_Competence")
                .Text = r("Lib_Domaines_Competence")
                .Tag = r("Descriptif")
                .ContextMenu = oCnt_Org
                .ImageIndex = 2
            End With
            oNod.Nodes.Add(_Nd)
            oNod.ImageIndex = 1
            getDC(r("Domaines_Competence"))
        Next
        oNod.ExpandAll()
    End Sub
    Private Sub AjouterUneEntitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterUneEntitéToolStripMenuItem.Click
        Dim oNod As Node = CType(CType(AjouterUneEntitéToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        Dim _Nd As New Node
        With _Nd
            .Name = rnd.Next(195323540, 846522870)
            .Text = "Nouveau domaine de compétence"
            .ContextMenu = oCnt_Org
            .ImageIndex = 2
        End With
        oNod.Nodes.Add(_Nd)
        oNod.ImageIndex = 1
        _Nd.BeginEdit()
    End Sub
    Private Sub ModifierLentitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModifierLentitéToolStripMenuItem.Click
        Dim oNod As Node = CType(CType(AjouterUneEntitéToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        oNod.BeginEdit()
    End Sub
    Private Sub RenomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenomerToolStripMenuItem.Click
        Dim oNod As Node = CType(CType(AjouterUneEntitéToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        oNod.BeginEdit(oNod.Text)
    End Sub
    Private Sub SupprimerLentitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerLentitéToolStripMenuItem.Click
        Dim oNod As Node = CType(CType(AjouterUneEntitéToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        If oNod Is Nothing Or oNod Is nSoc Then Return
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer ce domaine de compétence?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = MsgBoxResult.Cancel Then Return
        Dim strNd = getDetailDomaineCompetence(oNod, "")
        ' MsgBox(strNd)
    End Sub
    Function getDetailDomaineCompetence(nd As Node, strNd As String) As String
        strNd &= IIf(strNd = "", "", ",") & "'" & nd.Name & "'"
        If nd.Nodes.Count > 0 Then
            For Each n As Node In nd.Nodes
                strNd = getDetailDomaineCompetence(n, strNd)
            Next
        End If
        Return strNd
    End Function
#Region "RegionDragNDrop"
    Private Sub Adv_BeforeNodeDrop(sender As Object, e As TreeDragDropEventArgs) Handles Adv.BeforeNodeDrop
        If e.NewParentNode Is e.OldParentNode Then
            e.Cancel = True
            Return
        End If
        If e.NewParentNode.Nodes.Find(e.Node.Name, False).Count > 0 Then
            e.Cancel = True
            Return
        End If
        Dim nd As Node = e.Node
        e.Cancel = True
        If e.NewParentNode.Nodes.Count > 1 Then
            e.NewParentNode.Nodes.Insert(1, nd)
        Else
            e.NewParentNode.Nodes.Add(nd)
        End If
        e.NewParentNode.ImageIndex = 1
    End Sub
#End Region
    Sub Saving()
        Try
            flg = rnd.Next(1620, 98500)
            saveNode(nSoc)
            CnExecuting("delete from GPEC_Domaines_Competence where Flag_Maj!='" & flg & "' and id_Societe=" & Societe.id_Societe)
            ShowMessageBox("Enregistré avec succès", "Enregistrer")
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
        End Try
    End Sub
    Sub saveNode(nd As Node)
        If nd IsNot nSoc Then
            Dim rs As New ADODB.Recordset
            rs.Open("select * from GPEC_Domaines_Competence where Domaines_Competence='" & nd.Name & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Domaines_Competence").Value = nd.Name
                rs("id_Societe").Value = Societe.id_Societe
                rs("Dat_Crea").Value = Now
                rs("Created_By").Value = theUser.Login
            Else
                rs.Update()
            End If
            rs("Lib_Domaines_Competence").Value = nd.Text
            rs("Parent").Value = If(nd.Parent IsNot nSoc, nd.Parent.Name, "")
            rs("Descriptif").Value = nd.Tag
            rs("Rang").Value = nd.Index
            rs("Dat_Modif").Value = Now
            rs("Modified_By").Value = theUser.Login
            rs("Flag_Maj").Value = flg
            rs.Update()
            rs.Close()
        End If
        For Each n As Node In nd.Nodes
            saveNode(n)
        Next
    End Sub
    Sub Requesting()
        nSoc.Nodes.Clear()
        DC_Tbl = DATA_READER_GRD("select Domaines_Competence, Lib_Domaines_Competence, convert(nvarchar(50),isnull(nullif(Parent,''),id_Societe)) as Parent, isnull(Descriptif,'') Descriptif,Rang  from  GPEC_Domaines_Competence where id_Societe=" & Societe.id_Societe & " order by isnull(nullif(Parent,''),id_Societe),Rang")
        getDC(Societe.id_Societe)
        Descriptif_rtb.rtb.Text = ""
    End Sub
    Private Sub Adv_NodeDoubleClick(sender As Object, e As TreeNodeMouseEventArgs) Handles Adv.NodeClick
        If IsNull(e.Node.Tag, "") <> "" Then
            Descriptif_rtb.rtb.Rtf = e.Node.Tag
        Else
            Descriptif_rtb.rtb.Text = ""
        End If
    End Sub

    Private Sub Descriptif_rtb_Validated(sender As Object, e As EventArgs) Handles Descriptif_rtb.Validated
        With Adv
            If .SelectedNode IsNot Nothing Then .SelectedNode.Tag = Descriptif_rtb.rtb.Rtf
        End With
    End Sub

    Private Sub Search_txt_TextChanged(sender As Object, e As EventArgs) Handles Search_txt.TextChanged
        If Not filtering(nSoc) Then
            Search_txt.ForeColor = Color.Red
        Else
            Search_txt.ForeColor = Color.Black
        End If

    End Sub
    Function filtering(Nd As Node) As Boolean
        Dim isVisible As Boolean = False
        ' Vérifie si le texte du node contient le texte de recherche (case insensitive)
        If (Nd.Text.ToUpper.Contains(Search_txt.Text.Trim.ToUpper) Or String.IsNullOrWhiteSpace(Search_txt.Text.Trim)) And Nd IsNot nSoc Then
            isVisible = True
            setVisible(Nd)
        Else
            ' Parcourez les nodes enfants
            For Each childNd As Node In Nd.Nodes
                If filtering(childNd) Then
                    isVisible = True ' Au moins un enfant est visible
                End If
            Next
        End If
        If isVisible Then
            Nd.Visible = True
        ElseIf Nd Is nSoc Then
            Nd.Visible = True
        Else
            Nd.Visible = False
        End If
        ' Mettez à jour la couleur de la boîte de recherche pour indiquer si une correspondance a été trouvée
        Return isVisible
    End Function
    Sub setVisible(Nd As Node)
        Nd.Visible = True
        For Each childNd As Node In Nd.Nodes
            setVisible(childNd)
        Next
    End Sub
    Dim textNodeBefore As String = ""
    Private Sub Adv_AfterCellEditComplete(sender As Object, e As CellEditEventArgs) Handles Adv.AfterCellEditComplete
        If e.NewText.Contains(";") Then
            ShowMessageBox("Le point virgule est un caractère interdit.", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            e.Cell.Text = textNodeBefore
        End If
    End Sub

    Private Sub Adv_BeforeCellEdit(sender As Object, e As CellEditEventArgs) Handles Adv.BeforeCellEdit
        textNodeBefore = e.Cell.Text
    End Sub
End Class