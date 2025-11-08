Imports DevComponents.AdvTree
Imports DevComponents.DotNetBar
Public Class Admin_Profile
    Dim NbNodes As Integer = 0
    Dim ElementStyle2, ElementStyle3 As New DevComponents.DotNetBar.ElementStyle()
    Dim oTable As New DataTable
    Friend Code As String = ""
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim New_D As ud_btn
    Dim Duplik_D As ud_btn
    Private Sub Cod_Profile_Label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Cod_Profile_Label.LinkClicked
        Appel_Zoom1("MS060", Cod_Profile_Text, Me)
        If Cod_Profile_Text.Text = "1" Then
            MessageBoxRHP(350)
            Cod_Profile_Text.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Cod_Profile_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Profile_Text.TextChanged
        Request()
    End Sub

    Sub Request()
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
        DroitAcces(Me, DroitModify_Fiche(Cod_Profile_Text.Text, Me))
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Profile_Text.Text)
            Code = Cod_Profile_Text.Text
        End If


        Lib_Profile_Text.Text = FindLibelle("Lib_Profile", "Cod_Profile", Cod_Profile_Text.Text, "Controle_Profile")
        Actif_Check.Checked = FindLibelle("Actif", "Cod_Profile", Cod_Profile_Text.Text, "Controle_Profile")
        LeProfil.Text = Lib_Profile_Text.Text
        If Cod_Profile_Text.Text = "1" Then
            Actif_Check.Enabled = False
        Else
            Actif_Check.Enabled = True
        End If

        RequestAccess()

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Cod_Profile_Text.Text = "" Then Exit Sub
        Appel_Zoom1("MS061", Cod_Profile_Target_Text, Me)
    End Sub

    Private Sub Cod_Profile_Target_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Profile_Target_Text.TextChanged
        Lib_Profile_Target_Text.Text = FindLibelle("Lib_Profile", "Cod_Profile", Cod_Profile_Target_Text.Text, "Controle_Profile")
    End Sub

    Sub RequestAccess()
        Try
            NbNodes = 1
            Dim CodSql As String = ""
            CodSql = "select isnull(Parent,'') as Parent,f.Name_Ecran,isnull(Text_Ecran,'') as Text_Ecran,isnull(Typ_Ecran,'') as Typ_Ecran,isnull(Image1,'') as Image1,isnull(o.Visible,'False') as Visible,isnull(o.Actif,'False') as Actif ,isnull(Rang,'0') as Rang ,0 as RowId
                       From Controle_Treeview f  
                       outer apply(select Image1 from Controle_Menu where Name_Ecran=f.Name_Ecran) m  
                       outer apply (select * from Controle_Droit where Name_Ecran=f.Name_Ecran  and Cod_Profile='" & Cod_Profile_Text.Text & "') o 
                       where (isnull(Parent,'')<>'' or  Typ_Ecran='MNU' or (isnull(Parent,'')='' and  Typ_Ecran='ECR'))
                       order by Rang"
            oTable = DATA_READER_GRD(CodSql)
            With oTable
                .Columns("RowId").ReadOnly = False
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
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = True
                    .Cells(2).CheckBoxVisible = True
                    .Cells(1).Checked = CBool(nRows(i)("Visible"))
                    .Cells(2).Checked = CBool(nRows(i)("Actif"))
                    .ImageIndex = MenuImageArray.IndexOf(nRows(i)("Image1"))
                    .Tag = {nRows(i)("Typ_Ecran"), Nothing, Nothing}
                    .Style = ElementStyle2
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
                        .Cells.Add(New Cell)
                        .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(1).CheckBoxVisible = True
                        .Cells(2).CheckBoxVisible = True
                        .Cells(1).Checked = CBool(mRows(j)("Visible"))
                        .Cells(2).Checked = CBool(mRows(j)("Actif"))
                        .ImageIndex = MenuImageArray.IndexOf(mRows(j)("Image1"))
                        .Tag = {mRows(j)("Typ_Ecran"), Nothing, Nothing}
                        If mRows(j)("Typ_Ecran") = "FDR" Then .Style = ElementStyle3
                        If mRows(j)("Typ_Ecran") = "ECR" Then
                            .ContextMenu = CntScripts
                        End If
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
                            .Cells.Add(New Cell)
                            .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                            .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                            .Cells(1).CheckBoxVisible = True
                            .Cells(2).CheckBoxVisible = True
                            .Cells(1).Checked = CBool(oRows(k)("Visible"))
                            .Cells(2).Checked = CBool(oRows(k)("Actif"))
                            .ImageIndex = MenuImageArray.IndexOf(oRows(k)("Image1"))
                            .Tag = {oRows(k)("Typ_Ecran"), Nothing, Nothing}
                            oRows(k)("RowId") = NbNodes
                            If oRows(k)("Typ_Ecran") = "ECR" Then
                                .ContextMenu = CntScripts
                            End If
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
                                .Cells.Add(New Cell)
                                .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                                .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                                .Cells(1).CheckBoxVisible = True
                                .Cells(2).CheckBoxVisible = True
                                .Cells(1).Checked = CBool(pRows(h)("Visible"))
                                .Cells(2).Checked = CBool(pRows(h)("Actif"))
                                .ImageIndex = MenuImageArray.IndexOf(pRows(h)("Image1"))
                                .Tag = {pRows(h)("Typ_Ecran"), Nothing, Nothing}
                                If pRows(h)("Typ_Ecran") = "ECR" Then
                                    .ContextMenu = CntScripts
                                End If
                                pRows(h)("RowId") = NbNodes
                            End With
                            O.Nodes.Add(P)
                            NbNodes += 1
                        Next
                    Next
                Next
            Next
            Dim rw() As DataRow
            rw = oTable.Select("[Parent]='' and Typ_Ecran='ECR'", "Rang Asc")
            If rw.Length > 0 Then
                Dim N As New Node
                With N
                    .Text = "Dossier générique"
                    .Cells.Add(New Cell)
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = True
                    .Cells(2).CheckBoxVisible = True
                    .Cells(1).Checked = False
                    .Cells(2).Checked = False
                    .ImageIndex = MenuImageArray.IndexOf("FDR")
                    .Tag = {"FDR", Nothing, Nothing}
                    .Style = ElementStyle3
                End With
                For j = 0 To rw.GetUpperBound(0)
                    Dim M As New Node
                    With M
                        .Name = rw(j)("Name_Ecran")
                        .Text = rw(j)("Text_Ecran")
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(1).CheckBoxVisible = True
                        .Cells(2).CheckBoxVisible = True
                        .Cells(1).Checked = CBool(rw(j)("Visible"))
                        .Cells(2).Checked = CBool(rw(j)("Actif"))
                        .ImageIndex = MenuImageArray.IndexOf(rw(j)("Image1"))
                        .Tag = {rw(j)("Typ_Ecran"), Nothing, Nothing}
                        .ContextMenu = CntScripts
                        rw(j)("RowId") = NbNodes
                    End With
                    N.Nodes.Add(M)
                Next
                Adv.Nodes.Add(N)
            End If

            RequestFunctions()
            With Tbl_Grd
                .Rows.Clear()
                Dim TblGrd As DataTable = DATA_READER_GRD("select * from Controle_Profile_Regles where Cod_Profile='" & Cod_Profile_Text.Text & "' order by Table_Ref")
                With TblGrd
                    For i = 0 To .Rows.Count - 1
                        Tbl_Grd.Rows.Add(IsNull(.Rows(i)("Table_Ref"), ""), IsNull(.Rows(i)("Regle"), ""))
                    Next
                End With
            End With
            TabControl1.SelectedIndex = 0
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try

    End Sub

    Sub RequestFunctions()
        LeProfil.Nodes.Clear()
        Dim CodSql As String = " select Function_Sec,isnull(Description,'') as Lib_Function ,isnull(Visible,'false') Visible,isnull(Actif,'false')Actif, d.RowId 
                                 from Controle_Menu_Functions f 
                                 outer apply (Select Visible,Actif,RowId from Controle_Droit_Functions 
                                 where f.Function_Sec=Function_Sec And Cod_Profile='" & Cod_Profile_Text.Text & "') d 
                                 where isnull(Function_Sec,'')<>'' order by isnull(Description,'')"
        Dim fTbl As DataTable = DATA_READER_GRD(CodSql)
        With fTbl
            For i = 0 To .Rows.Count - 1
                Dim wnd As New Node
                wnd.Name = .Rows(i).Item("Function_Sec")
                wnd.Text = .Rows(i).Item("Lib_Function")
                wnd.Cells.Add(New Cell)
                wnd.Cells.Add(New Cell)
                wnd.Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                wnd.Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                wnd.Cells(1).CheckBoxVisible = True
                wnd.Cells(2).CheckBoxVisible = True
                wnd.Cells(1).Checked = .Rows(i).Item("Visible")
                wnd.Cells(2).Checked = .Rows(i).Item("Actif")
                wnd.Image = My.Resources.btn_check_on
                LeProfil.Nodes.Add(wnd)
            Next
        End With

    End Sub

    Private Sub Adv_NodeClick(sender As Object, e As TreeNodeMouseEventArgs) Handles Adv.NodeClick
        If e.Node.SelectedCell Is Nothing Then Return
        Checking(e.Node, e.Node.Cells.IndexOf(e.Node.SelectedCell), e.Node.SelectedCell.Checked)

    End Sub
    Sub Checking(oNd As Node, Indx As Integer, obool As Boolean)
        For Each a As Node In oNd.Nodes
            a.Cells(Indx).Checked = obool
            If a.Nodes.Count > 0 Then
                Checking(a, Indx, obool)
            End If
        Next
    End Sub
    Function IsChecked(oNd As Node, Indx As Integer) As Boolean
        Dim nb As Integer = 0
        For i = 0 To oNd.Nodes.Count - 1
            If oNd.Nodes(i).Cells(Indx).Checked Then
                nb += 1
            End If
        Next
        Return (nb = oNd.Nodes.Count)
    End Function

    Private Sub Admin_Users_Menus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Next_D = dictButtons("Next_D")
        Back_D = dictButtons("Back_D")
        Last_D = dictButtons("Last_D")
        First_D = dictButtons("First_D")
        New_D = dictButtons("New_D")
        Duplik_D = dictButtons("Duplik_D")
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
        With OuvrirParNiveau_ud
            .Items.AddRange({"Que les Menus", "Que les Dossiers", "Tout"})
        End With
    End Sub
    Sub Saving()
        Try
            If Cod_Profile_Text.Text = "1" Then
                MessageBoxRHP(350)
                Exit Sub
            End If
            Dim rs, rs1 As New ADODB.Recordset
            If RTrim(LTrim(Lib_Profile_Text.Text)) = "" Then
                MessageBoxRHP(351)
                Exit Sub
            End If
            rs.Open("Select *  from Controle_Profile where Cod_Profile='" & Cod_Profile_Text.Text & "'", cn, 2, 2)
            If rs.EOF Then
                'Cas d'un nouvel Création
                rs.AddNew()
                rs("Created_By").Value = theUser.Login
                rs("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
            Else
                'Cas de MAJ
                rs.Update()
            End If
            rs("Lib_Profile").Value = Lib_Profile_Text.Text
            rs("Actif").Value = Actif_Check.Checked
            rs("Modified_By").Value = theUser.Login
            rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
            rs.Update()
            rs.Close()
            Dim CodProfil As Integer = 0
            If Cod_Profile_Text.Text = "" Then
                CodProfil = CnExecuting("select max(Cod_Profile)from Controle_Profile").Fields(0).Value
            Else
                CodProfil = Cod_Profile_Text.Text
            End If
            CnExecuting("Delete from Controle_Profile_Regles WHERE    Cod_Profile='" & CodProfil & "'")
            With Tbl_Grd
                rs1.Open(" select * from Controle_Profile_Regles", cn, 2, 2)
                For j = 0 To .RowCount - 1
                    If IsNull(.Item(Table_Ref.Index, j).Value, "") <> "" Then
                        rs1.AddNew()
                        rs1("Cod_Profile").Value = CodProfil
                        rs1("Table_Ref").Value = .Item(Table_Ref.Index, j).Value
                        rs1("Regle").Value = .Item(Regle.Index, j).Value
                        rs1.Update()
                    End If
                Next
                rs1.Close()
            End With
            CnExecuting("Delete from Controle_Droit where Cod_Profile='" & CodProfil & "'")
            For Each c As Node In Adv.Nodes
                SavingNodes(c, CodProfil)
            Next
            CnExecuting("Delete from Controle_Droit_Functions where Cod_Profile='" & CodProfil & "'")
            For Each c As Node In AdvFonction.Nodes(0).Nodes
                SavingFunctions(c, CodProfil)
            Next
            MessageBoxRHP(352)
            Cod_Profile_Text.Text = CodProfil
            Request()
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    Sub SavingNodes(ByVal oNode As Node, CodProfil As String)
        Dim rs As New ADODB.Recordset
        rs.Open("Select * from Controle_Droit", cn, 2, 2)
        rs.AddNew()
        rs("Name_Ecran").Value = oNode.Name
        rs("Cod_Profile").Value = Cod_Profile_Text.Text
        rs("Visible").Value = oNode.Cells(1).Checked
        rs("Actif").Value = oNode.Cells(2).Checked
        rs.Update()
        rs.Close()
        If oNode.Tag(0) = "ECR" Then
            If Not oNode.Tag(1) Is Nothing Then
                Dim oTbl As DataTable = oNode.Tag(1)
                With oTbl
                    For i = 0 To .Rows.Count - 1
                        rs.Open("Select * from Controle_Droit_Avance where Cod_Profile='" & CodProfil & "' and Name_Ecran='" & oNode.Name & "' and Name_Controle='" & .Rows(i).Item("Name_Controle") & "'", cn, 2, 2)
                        If rs.EOF Then
                            rs.AddNew()
                            rs("Name_Ecran").Value = oNode.Name
                            rs("Cod_Profile").Value = Cod_Profile_Text.Text
                            rs("Name_Controle").Value = .Rows(i).Item("Name_Controle")
                        Else
                            rs.Update()
                        End If
                        rs("Visible").Value = .Rows(i).Item("Visible")
                        rs("Actif").Value = .Rows(i).Item("Actif")
                        rs.Update()
                        rs.Close()
                    Next
                End With
            End If
        End If

        If oNode.Nodes.Count > 0 Then
            For Each c As Node In oNode.Nodes
                SavingNodes(c, CodProfil)
            Next
        End If
    End Sub
    Sub SavingFunctions(ByVal oNode As Node, CodProfil As String)
        Dim rs As New ADODB.Recordset
        rs.Open("Select * from Controle_Droit_Functions", cn, 2, 2)
        rs.AddNew()
        rs("Cod_Profile").Value = Cod_Profile_Text.Text
        rs("Function_Sec").Value = oNode.Name
        rs("Visible").Value = oNode.Cells(1).Checked
        rs("Actif").Value = oNode.Cells(2).Checked
        rs.Update()
        rs.Close()

    End Sub
    Private Sub Scripts_Click(sender As Object, e As EventArgs) Handles Scripts.Click
        Dim oNd As Node = Adv.SelectedNode
        Dim f As New Zoom_Profile_Scripts
        With f
            .oNod = oNd
            .CodProfile = Cod_Profile_Text.Text
            .Adv.Nodes(0).Name = .CodProfile
            .Adv.Nodes(0).Text = Lib_Profile_Text.Text
            .Adv.Nodes(0).Nodes(0).Name = oNd.Name
            .Adv.Nodes(0).Nodes(0).Text = oNd.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
    End Sub
#Region "Recherche"
    Dim rRow As DataRow()
    Dim rRang As Integer = -1
    Dim NbRsl As Integer = 0
    Dim cRsl As Integer = 0
    Private Sub OuvrirParNiveau_ud_DropDowClosed(sender As Object, e As EventArgs) Handles OuvrirParNiveau_ud.DropDownClosed
        Select Case OuvrirParNiveau_ud.SelectedIndex
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
    Private Sub Recherche_txt_ud_TextChanged(sender As Object, e As EventArgs) Handles Recherche_txt_ud.TextChanged
        rRang = -1
        NbRsl = 0
        cRsl = 0
        Rsl_Recherche.Text = ""
        Rsl_Recherche.Refresh()
    End Sub
    Sub Rechercher()
        If Recherche_txt_ud.Text = "" Then Return
        rRow = oTable.Select("(Name_Ecran like '%" & Recherche_txt_ud.Text & "%' or Text_Ecran like '%" & Recherche_txt_ud.Text & "%') and Rowid>" & rRang, "Rowid Asc")
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
    Private Sub Recherche_txt_ud_KeyUp(sender As Object, e As KeyEventArgs) Handles Recherche_txt_ud.KeyUp
        If e.KeyCode = Keys.Enter Then
            Rechercher()
        End If
    End Sub
#End Region
#Region "Duplication"
    Sub Dupliquer()
        If Cod_Profile_Text.Text = "" Then Exit Sub
        If Cod_Profile_Target_Text.Text = "" Then
            ShowMessageBox("Sélectionner un profile cible", "Duplication", MessageBoxButtons.OK, msgIcon.Stop)
            Appel_Zoom1("MS061", Cod_Profile_Target_Text, Me)
            Return
        End If
        Dim a As String = Cod_Profile_Target_Text.Text
        If CnExecuting("Select count(*) from Controle_Profile where Cod_Profile='" & a & "'").Fields(0).Value > 0 Then
            Dim nom As String = CnExecuting("Select Lib_Profile from Controle_Profile where Cod_Profile='" & a & "'").Fields(0).Value
            If MessageBoxRHP(4, nom) = MsgBoxResult.Cancel Then Exit Sub
            CnExecuting("delete from Controle_Droit where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from Controle_Droit_Avance where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            If a = "1" Then
                CnExecuting("insert into Controle_Droit (Name_Ecran,Cod_Profile,Visible,Actif,Consult,Modify,Delet) " &
                          " select Name_Ecran,'" & Cod_Profile_Text.Text & "','True','True','True','True','True'  from Controle_Menu")
                CnExecuting("insert into Controle_Droit_Avance (Name_Ecran,Cod_Profile,Name_Controle,Visible,Actif) " &
                          " select Name_Ecran,'" & Cod_Profile_Text.Text & "',Name_Controle,'True','True' from Controle_Menu_Avance")
            Else
                CnExecuting("insert into Controle_Droit (Name_Ecran,Cod_Profile,Visible,Actif,Consult,Modify,Delet) " &
                          " select Name_Ecran,'" & Cod_Profile_Text.Text & "',Visible,Actif,Consult,Modify,Delet  from Controle_Droit where Cod_Profile='" & a & "'")
                CnExecuting("insert into Controle_Droit_Avance (Name_Ecran,Cod_Profile,Name_Controle,Visible,Actif) " &
                          " select Name_Ecran,'" & Cod_Profile_Text.Text & "',Name_Controle,Visible,Actif from Controle_Droit_Avance where Cod_Profile='" & a & "'")
            End If
        Else
            MessageBoxRHP(353)
        End If
        Request()
    End Sub
#End Region
#Region "Diviseurs d'enregistrement"
    Sub Div_First()
        Try
            Reset()
            If Cod_Profile_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Profile_Text.Text & "'")
                End If


                Diviseur_First("Controle_Profile", "Cod_Profile", "Lib_Profile", Cod_Profile_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Div_Back()
        Try
            Reset()
            If Cod_Profile_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Profile_Text.Text & "'")
                End If


                Diviseur_Back("Controle_Profile", "Cod_Profile", "Lib_Profile", Cod_Profile_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Div_Next()
        Try
            If Cod_Profile_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Profile_Text.Text & "'")
                End If


                Diviseur_Next("Controle_Profile", "Cod_Profile", "Lib_Profile", Cod_Profile_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Deleting()
        Try
            If Cod_Profile_Text.Text = "" Then
                ShowMessageBox("Aucun profile à supprimer", "Suppression de profile", MessageBoxButtons.OK, msgIcon.Information)
                Return
            End If
            If CnExecuting("Select count(*) from Controle_Users where Cod_Profile='" & Cod_Profile_Text.Text & "'").Fields(0).Value > 0 Then
                ShowMessageBox("Ce profile est utilisé dans la table des utilisateurs", "Suppression de profile", MessageBoxButtons.OK, msgIcon.Information)
                Return
            End If
            If ShowMessageBox("Etes-vous sûr de vouloir supprimer ce profile?", "Suppression de profile", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then
                Return
            End If
            CnExecuting("delete from  Controle_Profile where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from  Controle_Profile_Regles where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from  Controle_Droit_Functions where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from  Controle_Droit where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from  Controle_Droit_Avance where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('Controle_Profile','Cod_Profile','" & Cod_Profile_Text.Text & "','" & theUser.id_User & "',getdate())")
            ShowMessageBox("Profile supprimé")
            Reseting()
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    Sub Div_Last()
        Try
            Reset()
            If Cod_Profile_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Profile_Text.Text & "'")
                End If

                Diviseur_Last("Controle_Profile", "Cod_Profile", "Lib_Profile", Cod_Profile_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

#End Region
#Region "Reseting"
    Sub Reseting()
        Cod_Profile_Text.Text = ""
        Adv.Nodes.Clear()
        TabControl1.SelectedIndex = 0
    End Sub
    Sub Nouveau()
        Reseting()
        Lib_Profile_Text.Select()
    End Sub
#End Region
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Enter
                Rechercher()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Search_pb_Click(sender As Object, e As EventArgs) Handles Search_pb.Click
        Rechercher()
    End Sub

    Private Sub Admin_Profile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
    End Sub
End Class