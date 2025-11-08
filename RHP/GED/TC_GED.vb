Public Class TC_GED
    Dim ValeurCompteur As String = ""
    Friend NameEcran As String = ""
    Friend IndexEcran As String = ""
    Friend valeurIndex As String = ""
    Dim imageList1 As New ImageList()
    Dim lvwColumnSorter As New ListViewColumnSorter()
    Dim TblFiles As DataTable = DATA_READER_GRD("select *  from Param_GED where id_Societe=" & Societe.id_Societe)
    Private Sub Lv_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles oList.ColumnClick
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
        oList.Sort()
    End Sub
    Sub Request()
        oList.BeginUpdate()
        Dim oFiltre As String = " (not (isnull(Cacher,'') ='*'  or  isnull(Cacher,'') = '" & theUser.id_User & "' 
            or   isnull(Cacher,'') like '" & theUser.id_User & ";%' or isnull(Cacher,'') like '%;" & theUser.id_User & "' or isnull(Cacher,'') like '%;" & theUser.id_User & ";%') or Created_By='" & theUser.id_User & "')"
        Dim Cod_Sql As String = "select *  from Param_GED where id_Societe=" & Societe.id_Societe & " 
         and FD_Alias like '%" & FD_Alias_Text.Text & "%' and isnull(Zone_Index,'') like '%" & Zone_Index_Text.Text & "%' and " & oFiltre
        oList.Items.Clear()
        Dim Tbl As New DataTable
        Dim Fichier As String = ""
        Dim iconForFile As Icon = SystemIcons.WinLogo
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                Fichier = IsNull(.Rows(i).Item("File_Path"), "")
                If IO.File.Exists(Fichier) Then
                    Dim fi As IO.FileInfo = New IO.FileInfo(Fichier)
                    Dim oItm As New ListViewItem
                    oItm.Name = .Rows(i).Item("FD_id")
                    oItm.Text = IsNull(.Rows(i).Item("FD_Alias"), "")
                    oItm.Tag = IsNull(.Rows(i).Item("File_Path"), "")
                    If Not (imageList1.Images.ContainsKey(fi.Extension)) Then
                        ' If not, add the image to the image list.
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
                        imageList1.Images.Add(fi.Extension, iconForFile)
                    End If
                    oItm.ImageKey = fi.Extension
                    oItm.SubItems.Add(getDigitalPath(oItm.Name, ""))
                    oItm.SubItems.Add(FormatDateTime(CDate(IsNull(.Rows(i).Item("Dat_Crea"), "01/01/1900")), DateFormat.ShortDate))
                    oItm.SubItems.Add(IIf(fi.Length > 1073741824, Math.Round(fi.Length / 1073741824, 2) & "Go", IIf(fi.Length > 1048576, Math.Round(fi.Length / 1048576) & "Mo", IIf(fi.Length > 1024, Math.Round(fi.Length / 1024) & "Ko", fi.Length & "o"))))
                    oItm.SubItems.Add(FindLibelle("Text_Ecran", "Name_Ecran", IsNull(.Rows(i).Item("Name_Ecran"), ""), "Controle_Menu"))
                    oItm.SubItems.Add(IsNull(.Rows(i).Item("Value_Index"), ""))
                    oItm.SubItems.Add(FindLibelle("Nom_User + ' ' + Prenom_User", "id_User", IsNull(.Rows(i).Item("Created_By"), ""), "Controle_Users"))
                    oList.Items.Add(oItm)
                End If
            Next
        End With
        oList.EndUpdate()
    End Sub
    Function getDigitalPath(FileId As String, dPath As String) As String
        Dim nrw() As DataRow = TblFiles.Select("FD_id='" & FileId & "'")
        If nrw.Length > 0 Then
            If IsNull(nrw(0)("Parent_Dir"), "") <> "" Then
                Dim pId As String = nrw(0)("Parent_Dir")
                nrw = TblFiles.Select("FD_id='" & pId & "'")
                If nrw.Length > 0 Then
                    dPath = nrw(0)("FD_Alias") & IIf(dPath = "", "", "\" & dPath)
                    Return getDigitalPath(pId, dPath)
                Else
                    Return dPath
                End If
            Else
                Return dPath
            End If
        Else
            Return dPath
        End If
    End Function
    Sub Initialisation()
        FD_Alias_Text.Text = ""
        Zone_Index_Text.Text = ""
        oList.Items.Clear()
    End Sub
    Sub Nouveau()
        Initialisation()
    End Sub
    Sub Searching()
        Request()
    End Sub

    Private Sub TC_GED_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With imageList1
            .ColorDepth = ColorDepth.Depth32Bit
            .TransparentColor = Color.Transparent
        End With
        oList.SmallImageList = imageList1
        oList.ListViewItemSorter = lvwColumnSorter
    End Sub

    Private Sub oList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles oList.DoubleClick
        Try
            If oList.SelectedItems.Count > 0 Then
                StartPrograme(oList.SelectedItems(0).Tag)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
End Class