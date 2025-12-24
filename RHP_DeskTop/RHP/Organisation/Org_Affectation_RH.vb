Imports DevComponents.AdvTree
Public Class Org_Affectation_RH
    Friend Tbl_Org_Entite, Tbl_Org_Typ_Entite As New DataTable
    Friend Tbl_RH_Agent As New DataTable
    Dim ElementStyle2, ElementStyle3 As New DevComponents.DotNetBar.ElementStyle()
    Friend oTable As New DataTable
    Friend nbRst As Integer = 0
    Friend dicRespEntite As New Dictionary(Of Node, Node)
    Private Sub OuvrirParNiveau_cbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OuvrirParNiveau_cbo.SelectedIndexChanged
        Adv.ExpandAll()
        Dim nrw() As DataRow = Tbl_Org_Entite.Select("Niveau_Hierarchique>=" & OuvrirParNiveau_cbo.SelectedIndex)
        With Adv
            For i = 0 To nrw.Length - 1
                Dim nd As Node = .FindNodeByName(nrw(i)("Cod_Entite"))
                If Not nd Is Nothing Then nd.CollapseAll()
            Next
        End With
    End Sub
    Sub Request()
        nSoc.Nodes.Clear()
        dicRespEntite.Clear()
        ndSocNonAffecte.Nodes.Clear()
        Tbl_Org_Typ_Entite = DATA_READER_GRD("SELECT Intitule, Niveau_Hierarchique,Typ_Entite FROM Org_Typ_Entite where Niveau_Hierarchique>=0
                                            ORDER BY Niveau_Hierarchique")
        Tbl_Org_Entite = DATA_READER_GRD("select Cod_Entite,Lib_Entite,e.Typ_Entite,Intitule,Niveau_Hierarchique, Attachement_Hierarchique,Responsable 
from Org_Entite e left join Org_Typ_Entite t on e.Typ_Entite=t.Typ_Entite where e.id_Societe=" & Societe.id_Societe & " order by Niveau_Hierarchique")
        Tbl_RH_Agent = DATA_READER_GRD("select Matricule, Nom_Agent+' '+Prenom_Agent as Nom_Agent, isnull(Sexe,'H') as Sexe,
a.Cod_Poste,isnull(Lib_Poste,'') as Lib_Poste, a.Cod_Grade,isnull(Lib_Grade,'') as Lib_Grade,isnull(g.Niveau,99) as Niveau,isnull(a.Cod_Entite,'') as Cod_Entite,isnull(Lib_Entite,'')as Lib_Entite, isnull(Titre,'') as Titre, convert(bit,case when Dat_Sortie is null then 1 else 0 end ) as enPoste
from RH_Agent a left join Org_Poste f on f.Cod_Poste=a.Cod_Poste and f.id_Societe=a.id_Societe
left join Org_Entite e on e.Cod_Entite=a.Cod_Entite and e.id_Societe=a.id_Societe 
left join Org_Grade g on g.Cod_Grade=a.Cod_Grade and g.id_Societe=a.id_Societe  where a.id_Societe=" & Societe.id_Societe _
& " order by a.Cod_Entite, Niveau, Nom_Agent")

        For Each col As DataColumn In Tbl_Org_Entite.Columns
            col.ReadOnly = False
        Next

        Dim nrw() As DataRow = Tbl_Org_Entite.Select("Attachement_Hierarchique='' or Attachement_Hierarchique is null")
        If nrw.Length > 0 Then
            GenererNodes(nrw(0)("Cod_Entite"), nSoc)
        End If
        nrw = Tbl_RH_Agent.Select("Cod_Entite='' and enPoste='true'")
        For i = 0 To nrw.Length - 1
            Dim hNd As New Node
            With hNd
                .Name = nrw(i)("Matricule")
                .Text = nrw(i)("Nom_Agent") & " (" & .Name & ")"
                .ImageIndex = 3
                .Tag = "RHA"
                .ContextMenu = oCnt_RH
                oTable.Rows.Add(.Name, .Text, nbRst)
                nbRst += 1
            End With
            ndSocNonAffecte.Nodes.Add(hNd)
        Next
        ndSocNonAffecte.Expand()
        nSoc.Expanded = True
    End Sub
    Dim owhere As String = ""
    Sub Saving()
        owhere = ""
        If ShowMessageBox("Voulez-vous enregistrez?", "Enregistrer", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
        CnExecuting("update Org_Entite set Responsable='' where id_Societe=" & Societe.id_Societe)
        For Each oNod As Node In nSoc.Nodes
            SavingNode(oNod)
        Next
        If owhere <> "" Then CnExecuting("delete from Org_Entite where Cod_Entite not in (" & owhere & ") and id_Societe=" & Societe.id_Societe)
        Dim swhere As String = ""
        For Each nD As Node In ndSocNonAffecte.Nodes
            swhere &= IIf(swhere = "", "", ",") & "'" & nD.Name & "'"
        Next
        If swhere <> "" Then
            CnExecuting("update RH_Agent set Cod_Entite='' where Matricule in (" & swhere & ") and id_Societe=" & Societe.id_Societe)
        End If
        Request()
    End Sub
    Sub SavingNode(oNod As Node)
        Dim rs As New ADODB.Recordset
        If IsNumeric(oNod.Tag) Then
            rs.Open("select * from Org_Entite where Cod_Entite='" & oNod.Name & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Cod_Entite").Value = oNod.Name
                rs("id_Societe").Value = Societe.id_Societe
            Else
                rs.Update()
            End If
            rs("Lib_Entite").Value = oNod.Text
            rs("Typ_Entite").Value = Tbl_Org_Typ_Entite.Select("Niveau_Hierarchique=" & oNod.Tag)(0)("Typ_Entite")
            If Not oNod.Parent Is nSoc Then
                rs("Attachement_Hierarchique").Value = oNod.Parent.Name
            End If
            rs.Update()
            rs.Close()
            owhere &= IIf(owhere = "", "", ",") & "'" & oNod.Name & "'"
        ElseIf IsNull(oNod.Tag, "") = "RHM" Then
            rs.Open("select * from Org_Entite where Cod_Entite='" & oNod.Parent.Name & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If Not rs.EOF Then
                rs.Update()
                rs("Responsable").Value = oNod.Name
                rs.Update()
            End If
            rs.Close()
            rs.Open("select * from Rh_Agent where Matricule='" & oNod.Name & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If Not rs.EOF Then
                rs.Update()
                rs("Cod_Entite").Value = oNod.Parent.Name
                rs.Update()
            End If
            rs.Close()
        ElseIf IsNull(oNod.Tag, "") = "RHA" Then
            rs.Open("select * from Rh_Agent where Matricule='" & oNod.Name & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If Not rs.EOF Then
                rs.Update()
                rs("Cod_Entite").Value = oNod.Parent.Name
                rs.Update()
            End If
            rs.Close()
        End If
        For Each nd As Node In oNod.Nodes
            SavingNode(nd)
        Next
    End Sub
    Private Sub Org_Affectation_RH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColumnHeader2.Width.Absolute = 150
        ColumnHeader1.Width.Absolute = Me.Width - ColumnHeader2.Width.Absolute
        With imgList
            .TransparentColor = Color.Transparent
            .ColorDepth = ColorDepth.Depth32Bit
        End With
        With oTable
            .Columns.Add("Code")
            .Columns.Add("Libelle")
            .Columns.Add("Rowid")
            .Columns("Rowid").DataType = GetType(Integer)
            nbRst = 0
        End With
        Request()
        With OuvrirParNiveau_cbo
            With Tbl_Org_Typ_Entite
                For i = 0 To .Rows.Count - 1
                    OuvrirParNiveau_cbo.Items.Add(.Rows(i)("Intitule"))
                Next
            End With
            If .Items.Count > 4 Then
                .SelectedIndex = 4
            End If
        End With
        With nSoc
            .Text = Societe.Denomination
        End With
        With ndSocNonAffecte
        End With
        With Adv
            .Styles.Add(ElementStyle2)
            .Styles.Add(ElementStyle3)
            .ImageList = imgList
        End With
        With Adv_NonAffecte
            .ImageList = imgList
        End With
        With ElementStyle2
            .BackColor = System.Drawing.Color.White
            .BackColor2 = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
            .BackColorGradientAngle = 90
            .BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderBottomWidth = 1
            .BorderColor = System.Drawing.Color.DarkGray
            .BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderLeftWidth = 1
            .BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderRightWidth = 1
            .BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderTopWidth = 1
            .Class = ""
            .CornerDiameter = 4
            .CornerType = DevComponents.DotNetBar.eCornerType.Square
            .Description = "Gray"
            .Name = "ElementStyle2"
            .PaddingBottom = 1
            .PaddingLeft = 1
            .PaddingRight = 1
            .PaddingTop = 1
            .TextColor = System.Drawing.Color.Black
        End With
        With ElementStyle3
            .BackColor = System.Drawing.Color.White
            .BackColor2 = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(230, Byte), Integer))
            .BackColorGradientAngle = 90
            .BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderBottomWidth = 1
            .BorderColor = System.Drawing.Color.DarkGray
            .BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderLeftWidth = 1
            .BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderRightWidth = 1
            .BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderTopWidth = 1
            .Class = ""
            .CornerDiameter = 3
            .CornerType = DevComponents.DotNetBar.eCornerType.Square
            .Description = "Gray"
            .Name = "ElementStyle3"
            .PaddingBottom = 1
            .PaddingLeft = 1
            .PaddingRight = 1
            .PaddingTop = 1
            .TextColor = System.Drawing.Color.Black
        End With
    End Sub
    Sub GenererNodes(NodName As String, NodParent As Node)
        ' insertion de l'unité
        Dim Hrw() As DataRow = Nothing
        Dim nrw() As DataRow = Tbl_Org_Entite.Select("Cod_Entite='" & NodName & "'")
        If nrw.Length > 0 Then
            Dim Nd As New Node
            With Nd
                .Name = NodName
                .Tag = nrw(0)("Niveau_Hierarchique")
                .Text = nrw(0)("Lib_Entite")
                .ImageIndex = 1
                .ContextMenu = oCnt_Org
                .Expanded = (nrw(0)("Niveau_Hierarchique") <= OuvrirParNiveau_cbo.SelectedIndex)
                oTable.Rows.Add(.Name, .Text, nbRst)
                nbRst += 1
                'inserer Responsable
                If IsNull(nrw(0)("Responsable"), "") <> "" Then
                    Hrw = Tbl_RH_Agent.Select("Matricule='" & nrw(0)("Responsable") & "'")
                    If Hrw.Length > 0 Then
                        Dim hNd As New Node
                        With hNd
                            .Name = Hrw(0)("Matricule")
                            .Text = Hrw(0)("Nom_Agent") & " (" & .Name & ")"
                            .Cells.Add(New Cell)
                            .Cells(1).Text = Hrw(0)("Lib_Grade")
                            .ImageIndex = 2
                            .Tag = "RHM"
                            .ContextMenu = oCnt_RH
                            oTable.Rows.Add(.Name, .Text, nbRst)
                            nbRst += 1
                        End With
                        Nd.Nodes.Add(hNd)
                        dicRespEntite.Add(Nd, hNd)
                    End If
                End If
                'insertion du personnel directement affecté
                Hrw = Tbl_RH_Agent.Select("Cod_Entite='" & nrw(0)("Cod_Entite") & "' and Matricule<>'" & nrw(0)("Responsable") & "'")
                For i = 0 To Hrw.Length - 1
                    Dim hNd As New Node
                    With hNd
                        .Name = Hrw(i)("Matricule")
                        .Text = Hrw(i)("Nom_Agent") & " (" & .Name & ")"
                        .Cells.Add(New Cell)
                        .Cells(1).Text = Hrw(0)("Lib_Grade")
                        .ImageIndex = 3
                        .Tag = "RHA"
                        .ContextMenu = oCnt_RH
                        oTable.Rows.Add(.Name, .Text, nbRst)
                        nbRst += 1
                    End With
                    Nd.Nodes.Add(hNd)
                Next
            End With
            NodParent.Nodes.Add(Nd)
            nrw = Tbl_Org_Entite.Select("Attachement_Hierarchique='" & NodName & "'")
            For i = 0 To nrw.Length - 1
                GenererNodes(nrw(i)("Cod_Entite"), Nd)
            Next
        End If
    End Sub
#Region "Recherche"
    Dim rRow As DataRow()
    Dim rRang As Integer = -1
    Dim NbRsl As Integer = 0
    Dim cRsl As Integer = 0
    Private Sub Rechercher_btn_Click(sender As Object, e As EventArgs) Handles Search_pb.Click
        Rechercher()
    End Sub
    Private Sub Search_txt_TextChanged(sender As Object, e As EventArgs) Handles Search_txt.TextChanged
        rRang = -1
        NbRsl = 0
        cRsl = 0
    End Sub
    Sub Requesting()
        Request()
        Adv.Refresh()
        Adv_NonAffecte.Refresh()
    End Sub
    Sub Rechercher()
        If Search_txt.Text = "" Then Return
        rRow = oTable.Select("(Code like '%" & Search_txt.Text & "%' or Libelle like '%" & Search_txt.Text & "%') and Rowid>" & rRang, "Rowid Asc")
        If rRow.Length = 0 Then
            ShowMessageBox("Aucun élément ne correspond à votre sélection")
            Return
        End If
        If nSoc.Nodes.Count > 0 Then
            For i = 0 To nSoc.Nodes(0).Nodes.Count - 1
                nSoc.Nodes(0).Nodes(i).CollapseAll()
            Next
        End If
        If NbRsl = 0 Then
            NbRsl = rRow.Length
        End If
        For i = 0 To rRow.Length - 1
            If Adv.Nodes.Find(rRow(i).Item("Code"), True).Length > 0 Then
                With Adv
                    .Select()
                    .SelectedNode = Adv.FindNodeByName(rRow(i).Item("Code"))
                End With
                rRang = rRow(i).Item("RowId")
                cRsl += 1
                Exit Sub
            ElseIf Adv_NonAffecte.Nodes.Find(rRow(i).Item("Code"), True).Length > 0 Then
                With Adv_NonAffecte
                    .Select()
                    .SelectedNode = Adv_NonAffecte.FindNodeByName(rRow(i).Item("Code"))
                End With
                rRang = rRow(i).Item("RowId")
                cRsl += 1
                Exit Sub
            End If
        Next
    End Sub
    Private Sub Search_txt_KeyUp(sender As Object, e As KeyEventArgs) Handles Search_txt.KeyUp
        If e.KeyCode = Keys.Enter Then
            Rechercher()
        End If
    End Sub
    Private Sub ConsulterLaFicheDeLAgentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsulterLaFicheDeLAgentToolStripMenuItem.Click
        Dim oNod As Node = CType(CType(ConsulterLaFicheDeLAgentToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        If Not IsNumeric(oNod.Tag) Then
            If Not IsNull(oNod.Tag, "") = "RHA" And Not IsNull(oNod.Tag, "") = "RHM" Then Return
            Dim f As New RH_Agent
            With f
                .StartPosition = FormStartPosition.CenterParent
                .Matricule_Text.Text = oNod.Name
                newShowEcran(f, True)
            End With
        End If
    End Sub
    Private Sub RenomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenomerToolStripMenuItem.Click
        Dim oNod As Node = CType(CType(RenomerToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        If IsNumeric(oNod.Tag) Then
            oNod.BeginEdit()
        End If
    End Sub
    Private Sub AjouterUneEntitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterUneEntitéToolStripMenuItem.Click
        '     Dim oNod As Node = CType(CType(AjouterUneEntitéToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        Dim oNod As Node = Adv.SelectedNode
        If oNod IsNot Nothing Then
            Dim f As New Zoom_Org_Organigramme_Affectation
            With f
                .frm = Me
                .pNode = oNod
                .oNode = Nothing
                newShowEcran(f, True)
            End With
        End If
    End Sub
    Sub Enregistrer()
        Saving()
    End Sub
    Private Sub ModifierLentitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModifierLentitéToolStripMenuItem.Click
        Dim oNod As Node = CType(CType(ModifierLentitéToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        If IsNumeric(oNod.Tag) Then
            Dim IndParent As Integer = -1
            Dim nrw() As DataRow = Tbl_Org_Entite.Select("Attachement_Hierarchique='" & oNod.Name & "'")
            Dim f As New Zoom_Org_Organigramme_Affectation
            With f
                .frm = Me
                .oNode = oNod
                If IsNumeric(IsNull(oNod.Parent.Tag, -1)) Then
                    .pNode = oNod.Parent
                    IndParent = IsNull(oNod.Parent.Tag, -1)
                End If
                .ChargerCombo()
                .Typ_Entite_cbo.SelectedIndex = CInt(oNod.Tag) - IndParent - 1
                .Typ_Entite_cbo.Enabled = (nrw.Length = 0)
                If dicRespEntite.ContainsKey(oNod) Then
                    .Matricule_Text.Text = dicRespEntite(oNod).Name
                End If
                newShowEcran(f, True)
            End With
        End If
    End Sub
    Private Sub SupprimerLentitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerLentitéToolStripMenuItem.Click
        Dim oNod As Node = CType(CType(SupprimerLentitéToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        If IsNumeric(oNod.Tag) Then
            If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette entité et ses sous-entités?", "Confirmation", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.OK Then
                Dim pNd As Node = oNod.Parent
                SupprimerEntite(oNod)
                pNd.Nodes.Remove(oNod)
            End If
        End If
    End Sub
    Sub SupprimerEntite(nod As Node)
        Dim NodName As String = ""
        For i = nod.Nodes.Count - 1 To 0 Step -1
            Dim nd As Node = nod.Nodes(i)
            If IsNumeric(nd.Tag) Then
                SupprimerEntite(nd)
                nod.Nodes.Remove(nd)
            Else
                NodName = nd.Name
                nod.Nodes.Remove(nd)
                If nSoc.Nodes.Find(NodName, True).Length = 0 Then
                    ndSocNonAffecte.Nodes.Add(nd)
                End If
            End If
        Next
    End Sub
    Private Sub DésignerEnTantQueResponableDeLEntitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DésignerEnTantQueResponableDeLEntitéToolStripMenuItem.Click
        Dim oNod As Node = CType(CType(DésignerEnTantQueResponableDeLEntitéToolStripMenuItem.Owner, ContextMenuStrip).SourceControl, AdvTree).SelectedNode
        If Not IsNumeric(oNod.Tag) Then
            If dicRespEntite.ContainsValue(oNod) Then Return
            If IsNull(oNod.Tag, "") = "RHM" Then Return
            If ShowMessageBox("Voulez-vous que M. " & oNod.Text & vbCrLf & " soit responsable de l'entité : " & vbCrLf &
                                 oNod.Parent.Name, "Nomination", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
            Dim nd As Node = oNod.Copy
            Dim pnd As Node = oNod.Parent
            pnd.Nodes.Remove(oNod)
            nd.ImageIndex = 2
            pnd.Nodes.Insert(0, nd)
            If dicRespEntite.ContainsKey(pnd) Then
                dicRespEntite(pnd).ImageIndex = 3
                dicRespEntite(pnd).Tag = "RHA"
                dicRespEntite.Remove(pnd)
            End If
            dicRespEntite.Add(pnd, nd)
            nd.Tag = "RHM"
        End If
    End Sub


#End Region
#Region "RegionDragNDrop"
    Private Sub Adv_BeforeNodeDrop(sender As Object, e As TreeDragDropEventArgs) Handles Adv.BeforeNodeDrop
        If IsNull(e.NewParentNode.Tag, "") = "RHM" Or IsNull(e.NewParentNode.Tag, "") = "RHA" Then
            ShowMessageBox("La destionation d'une affectation doit obligatoirement être une entité", "Affectation", MessageBoxButtons.OK, msgIcon.Stop)
            e.Cancel = True
            Return
        End If
        If e.NewParentNode Is nSoc Then
            e.Cancel = True
            Return
        End If
        If e.NewParentNode Is e.OldParentNode Then
            e.Cancel = True
            Return
        End If
        If e.NewParentNode.Nodes.Find(e.Node.Name, False).Count > 0 Then
            e.Cancel = True
            Return
        End If
        If IsNumeric(e.Node.Tag) Then
            If CInt(e.Node.Tag) <= CInt(e.NewParentNode.Tag) Then
                ShowMessageBox("La destionation d'une affectation doit obligatoirement de rang supérieur", "Affectation", MessageBoxButtons.OK, msgIcon.Stop)
                e.Cancel = True
                Return
            End If
        End If
        Dim nd As Node = e.Node
        e.Cancel = True
        If dicRespEntite.ContainsKey(e.NewParentNode) Then
            dicRespEntite.Remove(e.OldParentNode)
            If nd.Tag.ToString() = "RHM" Then nd.Tag = "RHA"
        End If
        If e.NewParentNode.Nodes.Count > 1 Then
            e.NewParentNode.Nodes.Insert(1, nd)
        Else
            e.NewParentNode.Nodes.Add(nd)
        End If
        If Not IsNumeric(nd.Tag) Then nd.Tag = "RHA"
        If dicRespEntite.ContainsValue(nd) Then
            For i = dicRespEntite.Count - 1 To 0 Step -1
                If dicRespEntite.Values(i) Is nd Then
                    dicRespEntite.Remove(dicRespEntite.Keys(i))
                End If
            Next
        End If
        e.Node.ImageIndex = If(IsNumeric(e.Node.Tag), 1, 3)
        If e.NewParentNode.Nodes.Count > 1 Then e.NewParentNode.ExpandAll()
    End Sub
    Private Sub Adv_NonAffecte_BeforeNodeDrop(sender As Object, e As TreeDragDropEventArgs) Handles Adv_NonAffecte.BeforeNodeDrop
        If IsNumeric(e.Node.Tag) Then
            ShowMessageBox("Vous ne pouvez pas déplacer une entité", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            e.Cancel = True
        End If
        If dicRespEntite.ContainsKey(e.Node) Then
            dicRespEntite.Remove(e.Node)
        End If
        If Not Adv_NonAffecte.FindNodeByName(e.Node.Name) Is Nothing Then
            Dim pnd As Node = e.Node.Parent
            pnd.Nodes.Remove(e.Node)
            e.Cancel = True
        End If
    End Sub
#End Region
End Class