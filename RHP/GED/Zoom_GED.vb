Imports System.ComponentModel
Imports DevComponents.AdvTree

Public Class Zoom_GED
    Dim ValeurFD_id As String = ""
    Friend LecteureSeule As Boolean = False
    Friend NameEcran As String = ""
    Friend IndexEcran As String = ""
    Friend valeurIndex As String = ""
    Friend WithEvents oCotextM As New ContextMenuStrip
    Dim Lecteur_Digital_Upload As String = FindParam("Lecteur_Digital_Upload")
    Dim FdrParent As Long = 0
    Dim Tbl As New DataTable
    Dim lvwColumnSorter As New ListViewColumnSorter()
    Private Sub Lv_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles Lv.ColumnClick
        ' Determine if the clicked column is already the column that is ' being sorted.
        If (e.Column = lvwColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If
        ' Perform the sort with these new sort options.
        Me.Lv.Sort()
    End Sub
    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Zoom__Boolean_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Mnu1, Mnu2, Mnu3, Mnu0, Mnu4, Mnu41, Mnu42, Mnu43, Mnu44, Mnu5, Mnu6 As New ToolStripMenuItem
        With Mnu0
            .Text = "Ajouter un nouveau dossier"
            .Image = My.Resources.fdr_0
            .Enabled = Not LecteureSeule
            AddHandler .Click, AddressOf AddFdr
        End With
        With Mnu1
            .Text = "Ouvrir"
            .Image = My.Resources.fdr_1
            AddHandler .Click, AddressOf Ouvrir
        End With

        With Mnu2
            .Text = "Supprimer"
            .Enabled = Not LecteureSeule
            .Image = My.Resources.supprimerligne
            AddHandler .Click, AddressOf Supprimer
        End With
        With Mnu3
            .Enabled = Not LecteureSeule
            .Text = "Ajouer un fichier"
            .Image = My.Resources.Roll_forward
            AddHandler .Click, AddressOf AddFile
        End With
        With Mnu43
            .Text = "Detail"
            .Name = "DT"
            AddHandler .Click, AddressOf AffichageLV
        End With
        With Mnu42
            .Text = "Grande icônes"
            .Name = "GC"
            AddHandler .Click, AddressOf AffichageLV
        End With
        With Mnu41
            .Text = "Petite icônes"
            .Name = "PC"
            AddHandler .Click, AddressOf AffichageLV
        End With
        With Mnu44
            .Text = "Liste"
            .Name = "LS"
            AddHandler .Click, AddressOf AffichageLV
        End With
        With Mnu4
            .Text = "Mode affichage"
            .DropDownItems.AddRange({Mnu41, Mnu42, Mnu43, Mnu44})
        End With
        With Mnu5
            .Text = "Renommer"
            .Enabled = Not LecteureSeule
            .Image = My.Resources.Modifier
            AddHandler .Click, AddressOf Renommer
        End With
        With Mnu6
            .Text = "Droits et accès"
            .Image = My.Resources.lock
            AddHandler .Click, AddressOf DroitsetAcces
        End With
        oCotextM.Items.AddRange({Mnu0, Mnu3, Mnu4, Mnu1, Mnu2, Mnu5, Mnu6})
        With nEcran
            .Name = "0"
            .Tag = "D"

            Dim nrw() As DataRow = Tbl_Controle_Droit_Mnu.Select("Name_Ecran='" & NameEcran & "'")
            If nrw.Length > 0 Then
                .Text = nrw(0)("Text_Ecran") & "\" & valeurIndex
            Else
                .Text = NameEcran & "\" & valeurIndex
            End If
        End With
        Request()
        Trv.Nodes(0).Expand()
        With Lv
            .ContextMenuStrip = oCotextM
            .ListViewItemSorter = lvwColumnSorter
            .AllowDrop = Not LecteureSeule
        End With
        NouveauDossierToolStripMenuItem.Enabled = Not LecteureSeule
        AjouterUnFichierToolStripMenuItem.Enabled = Not LecteureSeule
        RenommerToolStripMenuItem.Enabled = Not LecteureSeule
        SupprimerToolStripMenuItem.Enabled = Not LecteureSeule

    End Sub
    Private Sub oCotextM_Opening(sender As Object, e As CancelEventArgs) Handles oCotextM.Opening
        If Lv.SelectedItems.Count = 0 Then Return
        Dim itm As ListViewItem = Lv.SelectedItems(0)
        If itm Is Nothing Then Return
        Dim nrw() As DataRow = DATA_READER_GRD("exec Sys_GED_Droits '" & itm.Name & "'").Select("id_USer=" & theUser.id_User)
        If nrw.Length = 0 Then Return
        With oCotextM
            .Items(0).Enabled = getDroit(FdrParent, "W") And Not LecteureSeule
            .Items(1).Enabled = .Items(0).Enabled
            .Items(3).Enabled = getDroit(itm.Name, "R")
            .Items(4).Enabled = getDroit(itm.Name, "W") And Not LecteureSeule
            .Items(5).Enabled = .Items(4).Enabled
            .Items(6).Enabled = .Items(4).Enabled
        End With
    End Sub
    Sub DroitsetAcces(sender As ToolStripMenuItem, e As EventArgs)
        Dim oPt As Point = Lv.PointToClient(sender.Owner.Location)
        If Lv.GetItemAt(oPt.X, oPt.Y) IsNot Nothing Then
            Dim f As New Zoom_GED_Properties
            With f
                .FDid = Lv.GetItemAt(oPt.X, oPt.Y).Name
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With
        End If
    End Sub
    Sub Renommer(sender As ToolStripMenuItem, e As EventArgs)
        If LecteureSeule Then Return
        Lv.LabelEdit = True
        Dim oPt As Point = Lv.PointToClient(sender.Owner.Location)
        Dim itm As ListViewItem = Lv.GetItemAt(oPt.X, oPt.Y)
        If itm IsNot Nothing Then
            If Not getDroit(itm.Name, "W") Then Return
            itm.BeginEdit()
        End If
    End Sub
    Sub AffichageLV(sender As ToolStripMenuItem, e As EventArgs)
        Select Case sender.Name
            Case "DT"
                Lv.View = View.Details
            Case "GC"
                Lv.View = View.LargeIcon
            Case "PC"
                Lv.View = View.SmallIcon
            Case "LS"
                Lv.View = View.List
        End Select
    End Sub
    Sub AddFdr()
        If LecteureSeule Then Return
        Dim rnd As Long = theUser.id_User & Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Millisecond
        Dim itm As New ListViewItem
        Dim oNo As New Node
        Dim nrw() As DataRow = Tbl.Select("FD_Alias like 'Nouveau dossier (%' and Parent_Dir=" & FdrParent)
        Dim strText As String = "Nouveau dossier" & IIf(nrw.Length > 0, " (" & nrw.Length & ")", "")
        With itm
            .Name = rnd
            .Text = strText
            .Tag = "D"
            .ImageIndex = 0
            Lv.Items.Add(itm)
            Lv.LabelEdit = True
            .BeginEdit()
        End With
        With oNo
            .Name = rnd
            .Text = strText
            .Tag = "D"
            .ImageIndex = 1
            If FdrParent = 0 Then
                Trv.Nodes(0).Nodes.Add(oNo)
            Else
                Trv.FindNodeByName(FdrParent).Nodes.Add(oNo)
            End If
        End With
        Dim rs As New ADODB.Recordset
        rs.Open("select  *  from Param_GED where FD_id='" & rnd & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Created_By").Value = theUser.id_User
            rs("Dat_Crea").Value = Now
            rs("FD_id").Value = rnd
            rs("id_Societe").Value = Societe.id_Societe
        Else
            rs.Update()
        End If
        rs("Typ").Value = "D"
        rs("Name_Ecran").Value = NameEcran
        rs("FD_Alias").Value = strText
        rs("Parent_Dir").Value = FdrParent
        rs("Index_Ecran").Value = IndexEcran
        rs("Value_Index").Value = valeurIndex
        rs("Modified_By").Value = theUser.id_User
        rs("Dat_Modif").Value = Now
        rs.Update()
        rs.Close()
        MAJ_Tbl()
    End Sub
    Function getDigitalPath(FileId As String) As String
        Return Trv.FindNodeByName(FileId).FullPath.Replace(";", "\")
    End Function
    Sub AddFile()
        If LecteureSeule Then Return
        Dim iconForFile As Icon = SystemIcons.WinLogo
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = importPath
        OpenFileDialog.AutoUpgradeEnabled = False
        OpenFileDialog.Filter = "Tous les fichiers (*.*)|*.*|Fichiers Word (*.doc)|*.doc|Fichiers Word (*.docx)|*.docx|Fichiers Excel 97 (*.xls)|*.xls|Fichiers Excel (*.xlsx)|*.xlsx|Fichiers Pdf (*.pdf)|*.pdf|Fichiers JPEG (*.jpg)|*.jpg|Fichiers bmp (*.bmp)|*.bmp|Texte (*.txt)|*.txt"

        If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then
            importPath = System.IO.Path.GetFullPath(OpenFileDialog.FileName)
            Dim FileName As String = OpenFileDialog.FileName
            AjouterFicher(FileName)
        End If
    End Sub
    Sub AjouterFicher(FileName)
        If LecteureSeule Then Return
        Try
            Dim Info As New IO.FileInfo(FileName)
            Dim nrw() As DataRow = Tbl.Select("FD_Alias='" & Info.Name & "' and Parent_Dir=" & FdrParent)
            Dim rnd As Long = 0
            Dim opath As String = ""
            If nrw.Length > 0 Then
                If ShowMessageBox("Voulez-vous écraser le fichier existant?", "RHP", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    opath = nrw(0)("File_Path")
                    rnd = nrw(0)("FD_id")
                Else
                    Return
                End If
            Else
                rnd = theUser.id_User & Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Millisecond
                opath = Lecteur_Digital_Upload & "\" & rnd & "_" & Info.Name
            End If
            IO.File.Copy(Info.FullName, opath)
            Dim rs As New ADODB.Recordset

            rs.Open("select  *  from Param_GED where FD_id='" & rnd & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Created_By").Value = theUser.id_User
                rs("Dat_Crea").Value = Now
                rs("FD_id").Value = rnd
                rs("id_Societe").Value = Societe.id_Societe
            Else
                rs.Update()
            End If
            rs("Typ").Value = "F"
            rs("Name_Ecran").Value = NameEcran
            rs("File_Path").Value = opath
            rs("FD_Alias").Value = Info.Name
            rs("Parent_Dir").Value = FdrParent
            rs("Index_Ecran").Value = IndexEcran
            rs("Value_Index").Value = valeurIndex
            rs("Modified_By").Value = theUser.id_User
            rs("Dat_Modif").Value = Now
            rs.Update()
            rs.Close()
            MAJ_Tbl()
            nrw = Tbl.Select("FD_id=" & rnd)
            If nrw.Length > 0 Then GenererItem(nrw(0))
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try

    End Sub
    Private Sub Supprimer()
        If LecteureSeule Then Return
        With Lv
            If .SelectedItems.Count = 0 Then Exit Sub
            Dim itm As ListViewItem = .SelectedItems(0)
            If Not getDroit(itm.Name, "W") Then Return
            Dim oNd As Node = Trv.FindNodeByName(itm.Name)
            Dim pNd As Node = Trv.FindNodeByName(FdrParent)
            If MessageBoxRHP(3, itm.Text) = MsgBoxResult.Ok Then
                Dim nrw() As DataRow = Tbl.Select("FD_id=" & itm.Name)
                If nrw.Length > 0 Then
                    If nrw(0)("Typ") = "F" Then
                        If IO.File.Exists(nrw(0)("File_Path")) Then
                            On Error GoTo non
                            IO.File.Delete(nrw(0)("File_Path"))
                        End If
                        CnExecuting("delete from Param_GED where FD_id='" & itm.Name & "'")
                    ElseIf nrw(0)("Typ") = "D" Then
                        Dim Tbl As DataTable = GetContenuDossier(itm.Name)
                        With Tbl
                            For i = 0 To .Rows.Count - 1
                                CnExecuting("delete from Param_GED where FD_id='" & Tbl.Rows(i)("FDid") & "'")
                                If Tbl.Rows(i)("FDType") = "F" Then
                                    If IO.File.Exists(Tbl.Rows(i)("FDPath")) Then
                                        On Error GoTo non
                                        IO.File.Delete(Tbl.Rows(i)("FDPath"))
                                    End If
                                End If
                            Next
                        End With
                    End If
                End If
non:
                .Items.Remove(itm)
                If pNd.Nodes.Contains(oNd) Then
                    pNd.Nodes.Remove(oNd)
                    FdrParent = pNd.Name
                End If
            End If
            MAJ_Tbl()
        End With
    End Sub
    Private Sub SupprimerNode(nD As Node)
        If LecteureSeule Then Return
        With Lv
            If nD Is Nothing Then Return
            If MessageBoxRHP(3, nD.Text) = MsgBoxResult.Ok Then
                Dim nrw() As DataRow = Tbl.Select("FD_id=" & nD.Name)
                If nrw.Length > 0 Then
                    Dim Tbl As DataTable = GetContenuDossier(nD.Name)
                    With Tbl
                        For i = 0 To .Rows.Count - 1
                            CnExecuting("delete from Param_GED where FD_id='" & Tbl.Rows(i)("FDid") & "'")
                            If Tbl.Rows(i)("FDType") = "F" Then
                                If IO.File.Exists(Tbl.Rows(i)("FDPath")) Then
                                    On Error GoTo non
                                    IO.File.Delete(Tbl.Rows(i)("FDPath"))
                                End If
                            End If
                        Next
                    End With
                End If
non:
                Dim pnd As Node = nD.Parent
                If Not pnd Is Nothing Then
                    pnd.Nodes.Remove(nD)
                    OuvrirNode(pnd)
                    FdrParent = pnd.Name
                End If
            End If
            MAJ_Tbl()
        End With
    End Sub
    Sub MAJ_Tbl()
        Dim oFiltre As String = " (not (isnull(Cacher,'') ='*'  or  isnull(Cacher,'') = '" & theUser.id_User & "' 
            or   isnull(Cacher,'') like '" & theUser.id_User & ";%' or isnull(Cacher,'') like '%;" & theUser.id_User & "' or isnull(Cacher,'') like '%;" & theUser.id_User & ";%') or Created_By='" & theUser.id_User & "')"
        Dim Cod_Sql As String = "select  FD_id, id_Societe, Name_Ecran, Typ, Index_Ecran, Value_Index, FD_Alias, File_Path, Digital_Path, isnull(Parent_Dir,0) as Parent_Dir, Zone_Index, Taille, Created_By, Dat_Crea, Modified_By, 
                      Dat_Modif
  from Param_GED where id_Societe=" & Societe.id_Societe & " and Name_Ecran='" & NameEcran & "' and Index_Ecran='" & IndexEcran & "' and Value_Index='" & valeurIndex & "' and " & oFiltre
        Tbl = DATA_READER_GRD(Cod_Sql)
    End Sub
    Sub Request()
        MAJ_Tbl()
        Lv.Items.Clear()
        nEcran.Nodes.Clear()
        Path_txt.Text = ""
        lblNB.Text = "     0 élément"
        lblNB.Refresh()
        Lv.BeginUpdate()
        Dim pRw() As DataRow = Tbl.Select("Parent_Dir=0")
        With pRw
            For i = 0 To .Length - 1
                GenererItem(pRw(i))
            Next
        End With
        Lv.EndUpdate()
    End Sub
    Sub GenererItem(nRw As DataRow, Optional GenererTrvNodes As Boolean = True)
        Dim oExtension As String = ""
        Dim oTaille As Long = 0
        Dim Existe As Boolean = True
        Dim Fichier As String = ""
        If IsNull(nRw("Typ"), "F") = "F" Then
            Fichier = IsNull(nRw("File_Path"), "")
            If IO.File.Exists(Fichier) Then
                Dim fi As IO.FileInfo = New IO.FileInfo(Fichier)
                If Not (ImgSL.Images.ContainsKey(fi.Extension)) Then
                    Dim iconForFile As Icon = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
                    ImgSL.Images.Add(fi.Extension, iconForFile)
                    ImgXL.Images.Add(fi.Extension, iconForFile)
                    ImgTrv.Images.Add(fi.Extension, iconForFile)
                End If
                oExtension = fi.Extension
                oTaille = fi.Length
            Else
                Existe = False
            End If
        End If

        If Existe Then
            If GenererTrvNodes And IsNull(nRw("Typ"), "F") = "D" Then
                'TreeView
                Dim oNo, pNd As New Node
                Dim vRw() As DataRow = Tbl.Select("Parent_Dir=" & nRw("FD_id"))
                With oNo
                    .Name = IsNull(nRw("FD_id"), "")
                    .Text = IsNull(nRw("FD_Alias"), "")
                    .ImageIndex = IIf(FdrParent = nRw("Parent_Dir"), 0, 1)
                    .Tag = "D"
                    pNd = Trv.FindNodeByName(nRw("Parent_Dir"))
                    If Not pNd Is Nothing Then
                        pNd.Nodes.Add(oNo)
                    End If
                    If getDroit(oNo.Name, "R") Then
                        For i = 0 To vRw.Length - 1
                            GenererItem(vRw(i))
                        Next
                    End If
                End With
            End If
            'Liste view
            If FdrParent = nRw("Parent_Dir") Then
                Dim oItm As New ListViewItem
                If IsNull(nRw("Typ"), "F") = "F" Then
                    oItm.Name = IsNull(nRw("FD_id"), "")
                    oItm.Text = IsNull(nRw("FD_Alias"), "")
                    oItm.ImageKey = oExtension
                    oItm.Tag = "F"
                    oItm.SubItems.Add(getDigitalPath(FdrParent))
                    oItm.SubItems.Add(FormatDateTime(CDate(IsNull(nRw("Dat_Crea"), "01/01/1900")), DateFormat.ShortDate))
                    oItm.SubItems.Add(IIf(oTaille > 1073741824, Math.Round(oTaille / 1073741824, 2) & "Go", IIf(oTaille > 1048576, Math.Round(oTaille / 1048576) & "Mo", IIf(oTaille > 1024, Math.Round(oTaille / 1024) & "Ko", oTaille & "o"))))
                    oItm.SubItems.Add(FindLibelle("Text_Ecran", "Name_Ecran", IsNull(nRw("Name_Ecran"), ""), "Controle_Menu"))
                    oItm.SubItems.Add(IsNull(nRw("Value_Index"), ""))
                    oItm.SubItems.Add(FindLibelle("Nom_User + ' ' + Prenom_User", "id_User", IsNull(nRw("Created_By"), ""), "Controle_Users"))
                Else
                    oItm.Name = IsNull(nRw("FD_id"), "")
                    oItm.Text = IsNull(nRw("FD_Alias"), "")
                    oItm.ImageIndex = 1
                    oItm.Tag = "D"
                End If
                Lv.Items.Add(oItm)
            End If
        End If
    End Sub
    Private Sub oList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lv.DoubleClick
        Ouvrir()
    End Sub
    Private Sub Trv_NodeClick(sender As Object, e As TreeNodeMouseEventArgs) Handles Trv.NodeClick
        OuvrirNode(e.Node)
    End Sub
    Sub OuvrirNode(nD As Node)
        Try
            If Not getDroit(nD.Name, "R") Then Return
            If nD.Tag = "D" Then
                If FdrParent <> 0 Then
                    Dim oNo As Node = Trv.FindNodeByName(FdrParent)
                    If Not oNo Is Nothing Then
                        If Not nD.FullPath.Contains(oNo.FullPath) Then
                            oNo.ImageIndex = 1
                            oNo.Collapse()
                        End If
                    End If
                End If
                FdrParent = nD.Name
                nD.ImageIndex = 0
                nD.Expand()
                Path_txt.Text = getDigitalPath(FdrParent)
                Lv.Items.Clear()
                Dim pRw() As DataRow = Tbl.Select("Parent_Dir=" & FdrParent)
                With pRw
                    For i = 0 To .Length - 1
                        GenererItem(pRw(i), False)
                    Next
                End With
            End If

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Ouvrir()
        Try
            If Lv.SelectedItems.Count > 0 Then
                Dim itm As ListViewItem = Lv.SelectedItems(0)
                If Not getDroit(itm.Name, "R") Then Return
                If itm.Tag = "D" Then
                    If FdrParent <> 0 Then
                        Dim oNo As Node = Trv.FindNodeByName(FdrParent)

                        oNo.ImageIndex = 1
                    End If
                    FdrParent = itm.Name
                    Dim nNo As Node = Trv.FindNodeByName(FdrParent)
                    nNo.ImageIndex = 0
                    nNo.Expand()
                    Path_txt.Text = getDigitalPath(FdrParent)
                    Lv.Items.Clear()
                    Dim pRw() As DataRow = Tbl.Select("Parent_Dir=" & FdrParent)
                    With pRw
                        For i = 0 To .Length - 1
                            GenererItem(pRw(i), False)
                        Next
                    End With
                Else
                    Dim pRw() As DataRow = Tbl.Select("FD_id=" & itm.Name)
                    If pRw.Length > 0 Then
                        StartPrograme(pRw(0)("File_Path"))
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Back_D_Click(sender As Object, e As EventArgs) Handles back_pb.Click
        If FdrParent = 0 Then Return
        Dim pRw() As DataRow = Tbl.Select("FD_id=" & FdrParent)
        If pRw.Length = 0 Then Return
        Dim oNo As Node = Trv.FindNodeByName(FdrParent)
        oNo.ImageIndex = 1
        oNo.Collapse()
        FdrParent = pRw(0)("Parent_Dir")
        Dim nNo As Node = Trv.FindNodeByName(FdrParent)
        nNo.ImageIndex = 0
        nNo.Expand()
        Path_txt.Text = getDigitalPath(FdrParent)
        Lv.Items.Clear()
        pRw = Tbl.Select("Parent_Dir=" & FdrParent)
        With pRw
            For i = 0 To .Length - 1
                GenererItem(pRw(i), False)
            Next
        End With
    End Sub
    Private Sub oList_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles Lv.AfterLabelEdit
        If IsNull(e.Label, "").Trim = "" Then
            e.CancelEdit = True
            Lv.LabelEdit = False
            Return
        End If
        Dim nrw() As DataRow = Tbl.Select("FD_Alias='" & e.Label.Replace("'", "''") & "' and Parent_Dir=" & FdrParent)
        If nrw.Length >= 1 Then
            ShowMessageBox("Nom déjà utilisé", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
            e.CancelEdit = True
            Lv.LabelEdit = False
            Return
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select  *  from Param_GED where FD_id='" & Lv.Items(e.Item).Name & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If Not rs.EOF Then
            rs.Update()
            rs("FD_Alias").Value = e.Label
            rs("Modified_By").Value = theUser.id_User
            rs("Dat_Modif").Value = Now
            rs.Update()
        End If
        rs.Close()
        MAJ_Tbl()
        Dim nD As Node = Trv.FindNodeByName(Lv.Items(e.Item).Name)
        If Not nD Is Nothing Then
            nD.Text = e.Label
        End If
        Lv.LabelEdit = False
    End Sub
    Private Sub OuvrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirToolStripMenuItem.Click
        If Trv.SelectedNode Is Nothing Then Return
        OuvrirNode(Trv.SelectedNode)
    End Sub

    Private Sub RafraichirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RafraichirToolStripMenuItem.Click
        Request()
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click
        SupprimerNode(Trv.SelectedNode)
    End Sub
    Function GetContenuDossier(idDossier As String) As DataTable
        Dim SqlStr As String = "with Tbl (FDid, FDName, FDType, FDPath)
as 
(select FD_id, FD_Alias, Typ,isnull(File_Path,'')
from Param_GED where isnull(Typ,'F')='D' and FD_id='" & idDossier & "'
union all
select FD_id, FD_Alias, Typ,isnull(File_Path,'')
from Param_GED a inner join Tbl t on isnull(a.Parent_Dir,0)=t.FDid)
select * from Tbl"
        Return DATA_READER_GRD(SqlStr)
    End Function

    Private Sub NouveauDossierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NouveauDossierToolStripMenuItem.Click
        If LecteureSeule Then Return
        Try
            Dim rnd As Long = theUser.id_User & Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Millisecond
            Dim itm As New ListViewItem
            Dim pNd, oNo As New Node
            Dim nrw() As DataRow = Tbl.Select("FD_Alias like 'Nouveau dossier (%' and Parent_Dir=" & FdrParent)
            Dim strText As String = "Nouveau dossier" & IIf(nrw.Length > 0, " (" & nrw.Length & ")", "")
            With itm
                .Name = rnd
                .Text = strText
                .Tag = "D"
                .ImageIndex = 0
                Lv.Items.Add(itm)
            End With
            With pNd
                If Trv.SelectedNode Is Nothing Then
                    pNd = Trv.Nodes(0)
                Else
                    pNd = Trv.SelectedNode
                End If
            End With
            With oNo
                .Name = rnd
                .Text = strText
                .Tag = "D"
                .ImageIndex = 1
                pNd.Nodes.Add(oNo)
                .BeginEdit()
            End With
            Dim rs As New ADODB.Recordset
            rs.Open("select  *  from Param_GED where FD_id='" & rnd & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Created_By").Value = theUser.id_User
                rs("Dat_Crea").Value = Now
                rs("FD_id").Value = rnd
                rs("id_Societe").Value = Societe.id_Societe
            Else
                rs.Update()
            End If
            rs("Typ").Value = "D"
            rs("Name_Ecran").Value = NameEcran
            rs("FD_Alias").Value = strText
            rs("Parent_Dir").Value = FdrParent
            rs("Index_Ecran").Value = IndexEcran
            rs("Value_Index").Value = valeurIndex
            rs("Modified_By").Value = theUser.id_User
            rs("Dat_Modif").Value = Now
            rs.Update()
            rs.Close()
            MAJ_Tbl()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RenommerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenommerToolStripMenuItem.Click
        If LecteureSeule Then Return
        Trv.SelectedNode.BeginEdit()
    End Sub

    Private Sub Trv_AfterCellEdit(sender As Object, e As CellEditEventArgs) Handles Trv.AfterCellEdit
        If LecteureSeule Then Return
        If IsNull(e.NewText, "").Trim = "" Then
            e.Cancel = True
            Return
        End If
        Dim ndName As String = e.Cell.Parent.Name
        Dim nrw() As DataRow = Tbl.Select("FD_Alias='" & e.NewText.Replace("'", "''") & "' and Parent_Dir=" & FdrParent)
        If nrw.Length >= 1 Then
            ShowMessageBox("Nom déjà utilisé", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
            e.Cancel = True
            Return
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select  *  from Param_GED where FD_id='" & ndName & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If Not rs.EOF Then
            rs.Update()
            rs("FD_Alias").Value = e.NewText
            rs("Modified_By").Value = theUser.id_User
            rs("Dat_Modif").Value = Now
            rs.Update()
        End If
        rs.Close()
        MAJ_Tbl()
        Dim nD As ListViewItem = getItmByName(ndName)
        If Not nD Is Nothing Then
            nD.Text = e.NewText
        End If
    End Sub
    Function getItmByName(itmName As String) As ListViewItem
        Dim itm As New ListViewItem
        With Lv
            For i = 0 To .Items.Count - 1
                If .Items(i).Name = itmName Then
                    itm = .Items(i)
                    Exit For
                End If
            Next
        End With
        Return itm
    End Function
    Private Sub AjouterUnFichierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterUnFichierToolStripMenuItem.Click
        If LecteureSeule Then Return
        AddFile()
    End Sub
    Private Sub Trv_AfterNodeDrop(sender As Object, e As TreeDragDropEventArgs) Handles Trv.AfterNodeDrop
        If LecteureSeule Then Return
        If e.Node Is Nothing Then Return
        Dim rs As New ADODB.Recordset
        rs.Open("select  *  from Param_GED where FD_id='" & e.Node.Name & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Created_By").Value = theUser.id_User
            rs("Dat_Crea").Value = Now
            rs("FD_id").Value = e.Node.Name
            rs("id_Societe").Value = Societe.id_Societe
        Else
            rs.Update()
        End If
        rs("Typ").Value = "D"
        rs("Name_Ecran").Value = NameEcran
        rs("FD_Alias").Value = e.Node.Text
        rs("Parent_Dir").Value = e.Node.Parent.Name
        rs("Index_Ecran").Value = IndexEcran
        rs("Value_Index").Value = valeurIndex
        rs("Modified_By").Value = theUser.id_User
        rs("Dat_Modif").Value = Now
        rs.Update()
        rs.Close()
        MAJ_Tbl()
    End Sub
#Region "Drag"
    Private Sub Lv_DragEnter(sender As Object, e As DragEventArgs) Handles Lv.DragEnter
        If LecteureSeule Then Return
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub Lv_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles Lv.ItemDrag
        If LecteureSeule Then Return
        Try
            Lv.DoDragDrop(Lv.SelectedItems, DragDropEffects.Move)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Lv_DragDrop(sender As Object, e As DragEventArgs) Handles Lv.DragDrop
        If LecteureSeule Then Return
        Try
            If Not getDroit(FdrParent, "W") Then
                ShowMessageBox("Vous n'avez pas le droit d'écriture sur ce dossier", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If

            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
                For Each path In files
                    AjouterFicher(path)
                Next
            ElseIf Lv.SelectedItems.Count > 0 Then
                Dim oPt As Point = Lv.PointToClient(Cursor.Position)
                Dim itm As ListViewItem = Lv.GetItemAt(oPt.X, oPt.Y)
                If Not itm Is Nothing Then
                    Dim pNd As Node = Trv.FindNodeByName(itm.Name)
                    If itm.Tag = "D" Then
                        Dim rs As New ADODB.Recordset
                        For i = Lv.SelectedItems.Count - 1 To 0 Step -1
                            rs.Open("select  *  from Param_GED where FD_id='" & Lv.SelectedItems(i).Name & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
                            If Not rs.EOF Then
                                rs.Update()
                                rs("Parent_Dir").Value = itm.Name
                                rs("Modified_By").Value = theUser.id_User
                                rs("Dat_Modif").Value = Now
                                rs.Update()
                                pNd.Nodes.Add(Trv.FindNodeByName(Lv.SelectedItems(i).Name))
                                Lv.Items.Remove(Lv.SelectedItems(i))
                            End If
                            rs.Close()
                        Next
                        MAJ_Tbl()

                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
    Function getDroit(Fichier, TypDroit) As Boolean
        Dim rsl As Boolean = False
        Dim nrw() As DataRow = DATA_READER_GRD("exec Sys_GED_Droits '" & Fichier & "'").Select("id_USer=" & theUser.id_User)
        Select Case TypDroit
            Case "C"
                If nrw.Length = 0 Then
                    rsl = True
                Else
                    rsl = ConvertBoolean(nrw(0)("Cacher"))
                End If
            Case "R"
                If nrw.Length = 0 Then
                    rsl = False
                Else
                    rsl = ConvertBoolean(nrw(0)("Lecture"))
                End If
            Case "W"
                If nrw.Length = 0 Then
                    rsl = False
                Else
                    rsl = ConvertBoolean(nrw(0)("Ecriture"))
                End If
        End Select
        Return rsl
    End Function
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
        Try
            If Trv.SelectedNode Is Nothing Then Return
            Dim nd As Node = Trv.SelectedNode
            Dim nrw() As DataRow = DATA_READER_GRD("exec Sys_GED_Droits '" & nd.Name & "'").Select("id_USer=" & theUser.id_User)
            If nrw.Length = 0 Then Return
            With ContextMenuStrip1
                .Items(0).Enabled = getDroit(If(nd.Parent IsNot Nothing, nd.Parent.Name, ""), "W") And Not LecteureSeule
                .Items(1).Enabled = .Items(0).Enabled
                .Items(2).Enabled = ConvertBoolean(nrw(0)("Lecture"))
                .Items(3).Enabled = ConvertBoolean(nrw(0)("Ecriture")) And Not LecteureSeule
                .Items(4).Enabled = .Items(3).Enabled
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class