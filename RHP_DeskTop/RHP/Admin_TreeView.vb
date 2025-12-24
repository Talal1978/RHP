Imports System.ComponentModel
Imports DevComponents.AdvTree
Imports DevComponents.DotNetBar

Public Class Admin_TreeView
    Friend Code As String = ""
    Dim NbNodes As Integer = 0
    Dim ElementStyle2, ElementStyle3 As New DevComponents.DotNetBar.ElementStyle()
    Dim oTable As New DataTable
    Dim Save_D As ud_btn
    Private Sub Admin_TreeView_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Admin_TreeView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Save_D Is Nothing Then Save_D = dictButtons("Save_D")
        With Adv
            .ImageList = MenuImage
            .Styles.Add(ElementStyle2)
            .Styles.Add(ElementStyle3)
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
        Request()
    End Sub
    Sub Request()
        Try
            NbNodes = 1
            Dim CodSql As String = ""
            CodSql = "select isnull(Parent,'') as Parent,f.Name_Ecran,isnull(Text_Ecran,'') as Text_Ecran,
                       isnull(Typ_Ecran,'') as Typ_Ecran,isnull(Nullif(Image1,''), isnull(Typ_Ecran,'')) as Image1,isnull(f.Protege,'false') as Protege,
                       isnull(Rang,'0') as Rang ,0 as RowId
                       From Controle_Treeview f 
                       outer apply (select isnull(Image1,'') as Image1 
                       from Controle_Menu where Name_Ecran=f.Name_Ecran) e 
                       where (isnull(Parent,'')<>'' or  Typ_Ecran='MNU')
                       order by Rang"
            oTable = DATA_READER_GRD(CodSql)
            With oTable
                .Columns("RowId").ReadOnly = False
                .Columns("Rang").ReadOnly = False
                .Columns("Protege").ReadOnly = False
                .Columns("Text_Ecran").ReadOnly = False
                .Columns("Parent").ReadOnly = False
            End With
            Dim nRows() As DataRow
            nRows = oTable.Select("[Typ_Ecran]='MNU'", "Rang Asc")
            Adv.Nodes.Clear()
            For i = 0 To nRows.Length - 1
                Dim N As New Node
                With N
                    .Name = nRows(i)("Name_Ecran")
                    .Text = nRows(i)("Text_Ecran")
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = True
                    .Cells(1).Checked = CBool(nRows(i)("Protege"))
                    .ImageIndex = MenuImageArray.IndexOf(nRows(i)("Image1"))
                    .Tag = {nRows(i)("Typ_Ecran"), 1, nRows(i)("Image1")}
                    .Style = ElementStyle2
                    .ContextMenu = CntScripts
                    nRows(i)("RowId") = NbNodes
                End With
                Adv.Nodes.Add(N)
                NbNodes += 1
                Dim mRows() As DataRow
                mRows = oTable.Select("[Parent]='" & N.Name & "'", "Rang Asc")
                For j = 0 To mRows.GetUpperBound(0)
                    Dim M As New Node
                    With M
                        .Name = mRows(j)("Name_Ecran")
                        .Text = mRows(j)("Text_Ecran")
                        .Cells.Add(New Cell)
                        .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(1).CheckBoxVisible = True
                        .Cells(1).Checked = CBool(mRows(j)("Protege"))
                        .ImageIndex = MenuImageArray.IndexOf(mRows(j)("Image1"))
                        .Tag = {mRows(j)("Typ_Ecran"), 2, mRows(j)("Image1")}
                        If mRows(j)("Typ_Ecran") = "FDR" Then .Style = ElementStyle3
                        .ContextMenu = CntScripts

                        mRows(j)("RowId") = NbNodes
                    End With
                    N.Nodes.Add(M)
                    NbNodes += 1
                    Dim oRows() As DataRow
                    oRows = oTable.Select("[Parent]='" & M.Name & "'")
                    For k = 0 To oRows.Length - 1
                        Dim O As New Node
                        With O
                            .Name = oRows(k)("Name_Ecran")
                            .Text = oRows(k)("Text_Ecran")
                            .Cells.Add(New Cell)
                            .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                            .Cells(1).CheckBoxVisible = True
                            .Cells(1).Checked = CBool(oRows(k)("Protege"))
                            .ImageIndex = MenuImageArray.IndexOf(oRows(k)("Image1"))
                            .Tag = {oRows(k)("Typ_Ecran"), 3, oRows(k)("Image1")}
                            oRows(k)("RowId") = NbNodes
                            .ContextMenu = CntScripts

                        End With
                        M.Nodes.Add(O)
                        NbNodes += 1
                        Dim pRows() As DataRow
                        pRows = oTable.Select("[Parent]='" & O.Name & "'")
                        For h = 0 To pRows.Length - 1
                            Dim P As New Node
                            With P
                                .Name = pRows(h)("Name_Ecran")
                                .Text = pRows(h)("Text_Ecran")
                                .Cells.Add(New Cell)
                                .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                                .Cells(1).CheckBoxVisible = True
                                .Cells(1).Checked = CBool(pRows(h)("Protege"))
                                .ImageIndex = MenuImageArray.IndexOf(pRows(h)("Image1"))
                                .Tag = {pRows(h)("Typ_Ecran"), 4, pRows(h)("Image1")}
                                .ContextMenu = CntScripts
                                pRows(h)("RowId") = NbNodes
                            End With
                            O.Nodes.Add(P)
                            NbNodes += 1
                        Next
                    Next
                Next
            Next
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Sub Saving()
        Dim NameEcranStr As String = ""
        Try
            Cursor = Cursors.WaitCursor
            AdvToTable()
            Dim rnd As New Random
            Dim Flg As Integer = rnd.Next(904, 64000)
            Dim rs As New ADODB.Recordset
            With oTable
                For i = 0 To .Rows.Count - 1
                    'TreeView
                    NameEcranStr = .Rows(i).Item("Name_Ecran")
                    rs.Open("select * from Controle_TreeView where Name_Ecran='" & .Rows(i).Item("Name_Ecran") & "'", cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Name_Ecran").Value = .Rows(i).Item("Name_Ecran")
                        rs("Created_By").Value = theUser.Login
                        rs("Dat_Crea").Value = Now
                    Else
                        rs.Update()
                    End If
                    rs("Text_Ecran").Value = .Rows(i).Item("Text_Ecran")
                    rs("Typ_Ecran").Value = .Rows(i).Item("Typ_Ecran")
                    rs("Parent").Value = .Rows(i).Item("Parent")
                    rs("Tag").Value = .Rows(i).Item("Typ_Ecran")
                    rs("Protege").Value = .Rows(i).Item("Protege")
                    rs("Rang").Value = .Rows(i).Item("Rang")
                    rs("Flag_Maj").Value = Flg
                    rs("Modified_By").Value = theUser.Login
                    rs("Dat_Modif").Value = Now
                    rs.Update()
                    rs.Close()
                    'Controle_Menu
                    rs.Open("select * from Controle_Menu where Name_Ecran='" & .Rows(i).Item("Name_Ecran") & "'", cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Name_Ecran").Value = .Rows(i).Item("Name_Ecran")
                    Else
                        rs.Update()
                    End If
                    rs("Image1").Value = .Rows(i).Item("Image1")
                    rs("Text_Ecran").Value = .Rows(i).Item("Text_Ecran")
                    rs("Typ_Ecran").Value = .Rows(i).Item("Typ_Ecran")
                    rs("Protege").Value = .Rows(i).Item("Protege")
                    rs("Rang").Value = .Rows(i).Item("Rang")
                    rs("Flag_Maj").Value = Flg
                    rs.Update()
                    rs.Close()
                Next
            End With
            CnExecuting("delete from Controle_TreeView where isnull(Flag_Maj,'-1')<>" & Flg)
            CnExecuting("delete from Controle_Menu where Typ_Ecran='FDR' and isnull(Flag_Maj,'-1')<>" & Flg)
            CnExecuting("delete from Controle_Droit where isnull(Name_Ecran,'') not in (select Name_Ecran from Controle_Menu)")
            Request()
            '    Accueil.Actualisation_Click(Nothing, Nothing)
            Cursor = Cursors.Default
        Catch ex As Exception
            ShowMessageBox(NameEcranStr & vbCrLf & ex.Message)
            Cursor = Cursors.Default
        End Try
    End Sub
#Region "Recherche"
    Dim rRow As DataRow()
    Dim rRang As Integer = -1
    Dim NbRsl As Integer = 0
    Dim cRsl As Integer = 0
    Private Sub OuvrirParNiveau_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OuvrirParNiveau_cbo.SelectedIndexChanged
        Select Case OuvrirParNiveau_cbo.SelectedIndex
            Case 0
                For i = Adv.Nodes.Count - 1 To 0 Step -1
                    Adv.Nodes(i).Collapse()
                Next
            Case 1
                Adv.ExpandAll()
                For i = 0 To Adv.Nodes.Count - 1
                    For j = 0 To Adv.Nodes(i).Nodes.Count - 1
                        Adv.Nodes(i).Nodes(j).Collapse()
                    Next
                Next
            Case 2
                Adv.ExpandAll()
        End Select
    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles search_pb.Click
        Rechercher()
    End Sub
    Private Sub Recherche_txt_TextChanged(sender As Object, e As EventArgs) Handles Recherche_txt.TextChanged
        rRang = -1
        NbRsl = 0
        cRsl = 0
        Rsl_Recherche.Text = ""
        Rsl_Recherche.Refresh()
    End Sub
    Sub Rechercher()
        If Recherche_txt.Text = "" Then Return
        rRow = oTable.Select("(Name_Ecran like '%" & Recherche_txt.Text & "%' or Text_Ecran like '%" & Recherche_txt.Text & "%') and Rowid>" & rRang, "Rowid Asc")
        If rRow.Length = 0 Then
            ShowMessageBox("Aucun élément ne correspond à votre sélection")
            Return
        End If
        Adv.Select()
        If NbRsl = 0 Then
            NbRsl = rRow.Length
        End If
        For i = 0 To rRow.Length - 1
            If Adv.Nodes.Find(rRow(i).Item("Name_Ecran"), True).Length > 0 Then
                With Adv
                    .SelectedNode = Adv.FindNodeByName(rRow(i).Item("Name_Ecran"))
                End With
                rRang = rRow(i).Item("RowId")
                cRsl += 1
                Rsl_Recherche.Text = cRsl & "/" & NbRsl
                Rsl_Recherche.Refresh()
                Exit Sub
            End If
        Next
    End Sub



    Private Sub Recherche_txt_KeyUp(sender As Object, e As KeyEventArgs) Handles Recherche_txt.KeyUp
        If e.KeyCode = Keys.Enter Then
            Rechercher()
        End If
    End Sub
#End Region
#Region "Opérations sur les Nodes"
    Sub Renommer()
        Dim Nd As DevComponents.AdvTree.Node = Adv.SelectedNode
        If Not Nd Is Nothing Then
            Nd.Editable = True
            Nd.BeginEdit()
        End If
    End Sub
    Sub NodeAfterEdit(sender As Object, e As CellEditEventArgs) Handles Adv.AfterCellEdit
        e.Cell.Editable = False
        If Not (e.NewText Is Nothing) Then
            If e.NewText.Length = 0 Then
                e.Cancel = True
                ShowMessageBox("Appelation non valide")
                e.Cell.Parent.BeginEdit()
            Else
                Adv.SelectedNode.Cells(1).Checked = True
                Dim nrw() As DataRow = oTable.Select("[Name_Ecran]='" & Adv.SelectedNode.Name & "'")
                If nrw.Length > 0 Then nrw(0).Item("Text_Ecran") = e.NewText
            End If
        End If
    End Sub

    Private Sub CntScripts_Opening(sender As Object, e As CancelEventArgs) Handles CntScripts.Opening
        Select Case Adv.SelectedNode.Tag(0)
            Case "MNU"
                RenommerToolTip.Visible = False
                SupprimerToolStripMenuItem.Visible = False
                CréerUnDossierToolStripMenuItem.Visible = True
                AjouterUnNouvelÉlémentToolStripMenuItem.Visible = True
                OuvrirLélémentSélectionnéToolStripMenuItem.Visible = False
            Case "ECR"
                RenommerToolTip.Visible = False
                SupprimerToolStripMenuItem.Visible = False
                CréerUnDossierToolStripMenuItem.Visible = (CInt(Adv.SelectedNode.Tag(1)) <= 3)
                AjouterUnNouvelÉlémentToolStripMenuItem.Visible = True
                OuvrirLélémentSélectionnéToolStripMenuItem.Visible = True
            Case "FDR"
                RenommerToolTip.Visible = True
                SupprimerToolStripMenuItem.Visible = True
                CréerUnDossierToolStripMenuItem.Visible = (CInt(Adv.SelectedNode.Tag(1)) < 3)
                AjouterUnNouvelÉlémentToolStripMenuItem.Visible = True
            Case Else
                RenommerToolTip.Visible = True
                SupprimerToolStripMenuItem.Visible = True
                CréerUnDossierToolStripMenuItem.Visible = (CInt(Adv.SelectedNode.Tag(1)) <= 3)
                AjouterUnNouvelÉlémentToolStripMenuItem.Visible = True
                OuvrirLélémentSélectionnéToolStripMenuItem.Visible = True
        End Select


    End Sub

    Private Sub CréerUnDossierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréerUnDossierToolStripMenuItem.Click
        If Adv.SelectedNode Is Nothing Then Return
        Dim NnD, TnD As New Node
        TnD = Adv.SelectedNode
        With NnD
            .Name = "FDR" & theUser.id_User & "_" & Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Millisecond
            .Text = "Nouveau dossier"
            .Cells.Add(New Cell)
            .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
            .Cells(1).CheckBoxVisible = True
            .Cells(1).Checked = True
            .ImageIndex = MenuImageArray.IndexOf("FDR")
            .ContextMenu = CntScripts
            If TnD.Tag(0) = "FDR" Or TnD.Tag(0) = "MNU" Then
                TnD.Nodes.Add(NnD)
                .Tag = {"FDR", CInt(TnD.Tag(1)) + 1, "FDR"}
            Else
                TnD.Parent.Nodes.Add(NnD)
                .Tag = {"FDR", TnD.Tag(1), "FDR"}
            End If
        End With
        oTable.Rows.Add(NnD.Parent.Name, NnD.Name, NnD.Text, "FDR", "FDR", True, NnD.Index, NnD.Index)
        Adv.SelectedNode = NnD
        NnD.Editable = True
        NnD.BeginEdit()
    End Sub
    Private Sub RenommerToolTip_Click(sender As Object, e As EventArgs) Handles RenommerToolTip.Click
        Renommer()
    End Sub
    Private Sub OuvrirLélémentSélectionnéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirLélémentSélectionnéToolStripMenuItem.Click
        Dim NnD As Node = Adv.SelectedNode
        If NnD Is Nothing Then Return
        If NnD.Tag(0) = "SYS" Then
            Sys_GenerationGlobale.ShowDialog()
        End If
        openLink(NnD.Name, NnD.Text, NnD.Tag(0))
    End Sub
    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click
        Dim NnD As Node = Adv.SelectedNode
        If NnD Is Nothing Then Return
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer l'élément sélectionné?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        NnD.Parent.Nodes.Remove(NnD)
        AdvToTable()
    End Sub
    Private Sub PropriétésToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropriétésToolStripMenuItem.Click
        Dim NnD As Node = Adv.SelectedNode
        If NnD Is Nothing Then Return
        Dim PnD As Node = GetNodeModule(NnD)
        Dim Str As String = ""
        Str &= "<font face='Calibri' size='9'><b>Nom d'objet</b> : " & NnD.Name
        Str &= "</font><br/><font face='Calibri' size='9'><b>Intitulé</b> : " & NnD.Text
        Str &= "</font><br/><font face='Calibri' size='9'><b>Type</b> : " & NnD.Tag(0)
        Str &= "</font><br/><font face='Calibri' size='9'><b>Protégé</b> : " & IIf(NnD.Cells(1).Checked, "Oui", "Non")
        If PnD IsNot Nothing Then Str &= "</font><br/><font face='Calibri' size='9'><b>Module de Gestion</b> : " & PnD.Text
        Str &= "</font><br/><font face='Calibri' size='9'><b>Rang</b> : " & NnD.Index & "</font>"
        Str &= "<br/><font face='Calibri' size='9'><b>Icon</b> : " & NnD.Tag(2) & "</font>"
        ShowMessageBox(Str, "Propriétés", MessageBoxButtons.OK, msgIcon.Information)
    End Sub
    Sub AdvToTable()
        oTable.Rows.Clear()
        Dim NnD As New Node
        With Adv
            For i = 0 To .Nodes.Count - 1
                NnD = .Nodes(i)
                oTable.Rows.Add("", NnD.Name, NnD.Text, NnD.Tag(0), NnD.Tag(2), NnD.Cells(1).Checked, NnD.Index, oTable.Rows.Count + 1)
                If NnD.Nodes.Count > 0 Then
                    AdvToTable_Nodes(NnD)
                End If
            Next
        End With
    End Sub
    Sub AdvToTable_Nodes(ObjNode As Node)
        Dim NnD As New Node
        With ObjNode
            For i = 0 To .Nodes.Count - 1
                NnD = .Nodes(i)
                oTable.Rows.Add(NnD.Parent.Name, NnD.Name, NnD.Text, NnD.Tag(0), NnD.Tag(2), NnD.Cells(1).Checked, NnD.Index, oTable.Rows.Count + 1)
                If NnD.Nodes.Count > 0 Then
                    AdvToTable_Nodes(NnD)
                End If
            Next
        End With
    End Sub
#End Region
#Region "DragAndDrop"
    Private Sub Adv_AfterNodeDrop(sender As Object, e As TreeDragDropEventArgs) Handles Adv.AfterNodeDrop
        Dim nDestination As New Node
        If e.NewParentNode.Tag(0) = "FDR" Or e.NewParentNode.Tag(0) = "MNU" Then
            nDestination = e.NewParentNode
        Else
            nDestination = e.NewParentNode.Parent
        End If
        Dim k As Integer = 0
        If e.NewParentNode.Tag(0) = "FDR" Or e.NewParentNode.Tag(0) = "MNU" Then
            k = e.NewParentNode.Nodes.Count - 1
        Else
            k = e.NewParentNode.Index
        End If
        e.Node.Parent.Nodes.Remove(e.Node)
        nDestination.Nodes.Insert(k, e.Node)
        e.Node.Tag(1) = CInt(nDestination.Tag(1)) + 1
        e.Node.Cells(1).Checked = True

    End Sub

    Private Sub Adv_BeforeNodeDrop(sender As Object, e As TreeDragDropEventArgs) Handles Adv.BeforeNodeDrop
        If e.Node.Tag(0) = "MNU" Then
            ShowMessageBox("Impossible de déplacer un module")
            e.Cancel = True
        End If
        If e.Node.Tag(0) = "FDR" Then
            If CInt(e.NewParentNode.Tag(1)) = 3 And e.NewParentNode.Tag(0) = "FDR" Then
                ShowMessageBox("Impossible de déplacer un un dossier au 4ième Niveau")
                e.Cancel = True
            ElseIf CInt(e.NewParentNode.Tag(1)) >= 4 Then
                ShowMessageBox("Impossible de déplacer un un dossier au 4ième Niveau")
                e.Cancel = True
            End If
        End If
    End Sub
#End Region

    Function GetNodeModule(NnD As Node) As Node
        If NnD.Tag(0) = "MNU" Then
            Return NnD
        Else
            If NnD.Parent IsNot Nothing Then
                Return GetNodeModule(NnD.Parent)
            Else
                Return Nothing
            End If
        End If
    End Function

    Private Sub AjouterUnNouvelÉlémentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterUnNouvelÉlémentToolStripMenuItem.Click
        Dim otxt As New TextBox
        With otxt
            .Visible = False
            Adv.Controls.Add(otxt)
            .Location = New Point(Adv.SelectedNode.Bounds.X, Adv.SelectedNode.Bounds.Y)
            Appel_Zoom1("MS090", otxt, Me)
            Dim tTbl As DataTable = DATA_READER_GRD("Select * from Controle_Menu where Name_Ecran='" & .Text & "'")
            If tTbl.Rows.Count > 0 Then
                Dim NnD, TnD As New Node
                TnD = Adv.SelectedNode
                With NnD
                    .Name = tTbl.Rows(0).Item("Name_Ecran")
                    .Text = tTbl.Rows(0).Item("Text_Ecran")
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = True
                    .Cells(1).Checked = True
                    .ImageIndex = MenuImageArray.IndexOf(IsNull(tTbl.Rows(0).Item("Image1"), tTbl.Rows(0).Item("Typ_Ecran")))
                    .ContextMenu = CntScripts
                    If TnD.Tag(0) = "FDR" Or TnD.Tag(0) = "MNU" Then
                        TnD.Nodes.Add(NnD)
                        .Tag = {tTbl.Rows(0).Item("Typ_Ecran"), CInt(TnD.Tag(1)) + 1, IsNull(tTbl.Rows(0).Item("Image1"), tTbl.Rows(0).Item("Typ_Ecran"))}
                    Else
                        TnD.Parent.Nodes.Insert(TnD.Index, NnD)
                        .Tag = {tTbl.Rows(0).Item("Typ_Ecran"), TnD.Tag(1), IsNull(tTbl.Rows(0).Item("Image1"), tTbl.Rows(0).Item("Typ_Ecran"))}
                    End If
                End With
                oTable.Rows.Add(NnD.Parent.Name, NnD.Name, NnD.Text, tTbl.Rows(0).Item("Typ_Ecran"), IsNull(tTbl.Rows(0).Item("Image1"), tTbl.Rows(0).Item("Typ_Ecran")), True, NnD.Index, NnD.Index)
                Adv.SelectedNode = NnD
            End If
        End With
        otxt = Nothing
        Adv.Controls.Remove(otxt)
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Enter
                Rechercher()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class