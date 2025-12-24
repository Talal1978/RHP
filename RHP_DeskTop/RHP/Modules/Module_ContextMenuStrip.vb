Module Module_ContextMenuStrip

    Friend ClipBordGrd As New DataGridView

    Function AddContextMenu(ByVal Insertion As Boolean, ByVal ExpExcel As Boolean, ByVal CopierTout As Boolean, ByVal Copier As Boolean, ByVal Couper As Boolean, ByVal Coller As Boolean, ByVal Supprimer As Boolean, ByVal SupprimerTout As Boolean) As ContextMenuStrip
        Dim menu_context_copy As New ContextMenuStrip
        Dim oMenu1, oMenu2, oMenu3, oMenu4, oMenu5, oMenu6, oMenu7, oMenu9 As New ToolStripMenuItem

        With oMenu1
            .Text = "Copier"
            .Image = My.Resources.Copier
            AddHandler .Click, AddressOf menu_context_grd_Copier
            .Visible = Copier
        End With
        With oMenu2
            .Text = "Couper"
            .Image = My.Resources.Couper
            AddHandler .Click, AddressOf menu_context_grd_Couper
            .Visible = Couper
        End With
        With oMenu3
            .Text = "Coller"
            .Image = My.Resources.paste
            AddHandler .Click, AddressOf menu_context_grd_Coller
            .Visible = Coller
        End With

        With oMenu4
            .Text = "Copier le Contenu de la liste"
            .Image = My.Resources.Summary
            AddHandler .Click, AddressOf menu_context_grd
            .Visible = CopierTout
        End With

        With oMenu5
            .Text = "Exporter le Contenu vers Excel"
            .Image = My.Resources.icone_excel
            AddHandler .Click, AddressOf ToExcel
            .Visible = ExpExcel
        End With
        With oMenu6
            .Text = "Supprimer la (es) Ligne (s)"
            .Image = My.Resources.supprimerligne
            AddHandler .Click, AddressOf menu_context_grd_delSelection
            oMenu6.Visible = Supprimer
        End With
        With oMenu7
            .Text = "Supprimer Tout"
            .Image = My.Resources.supprimerttligne
            AddHandler .Click, AddressOf menu_context_grd_delall
            oMenu7.Visible = SupprimerTout
        End With
        With oMenu9
            .Text = "Insérer un Ligne"
            .Image = My.Resources.insert
            .Visible = Insertion
            AddHandler .Click, AddressOf InsertionLigne
        End With
        menu_context_copy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {oMenu1, oMenu2, oMenu3, oMenu4, oMenu9, oMenu5, oMenu6, oMenu7})

        Return menu_context_copy

    End Function
    Sub InsertionLigne(ByVal sender, ByVal e)

        Try
            Dim grd As DataGridView = sender.getcurrentparent.sourcecontrol

            With grd
                If .RowCount = 0 Then Exit Sub
                Dim Sindex As Integer = .CurrentRow.Index
                .Rows.InsertCopy(0, Sindex)
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Function FindIndex_Function(ByVal f As Object, ByVal Index As String, ByVal Index_Value As String) As String
        For Each c As Control In f.Controls
            If LTrim(RTrim(c.Name)).ToUpper = LTrim(RTrim(Index)).ToUpper Then
                Index_Value = c.Text
                Exit For
            ElseIf c.HasChildren = True Then
                Index_Value = FindIndex_Function(c, Index, Index_Value)
            End If
        Next
        Return Index_Value
    End Function


    Sub ToExcel(ByVal sender, ByVal e)
        Try
            Dim grd As New DataGridView
            grd = sender.getcurrentparent.sourcecontrol
            ExporterVersExcel(grd)
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub menu_context_grd(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim grd As Object
            grd = sender.getcurrentparent.sourcecontrol
            grd.SelectAll()
            grd.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            If grd.GetClipboardContent() Is Nothing Then Return
            Clipboard.SetDataObject(grd.GetClipboardContent())
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub menu_context_grd_delall(ByVal sender As Object, ByVal e As EventArgs)
        Try
            sender.getcurrentparent.sourcecontrol.SelectAll()
            For Each c As DataGridViewRow In sender.getcurrentparent.sourcecontrol.SelectedRows
                If sender.getcurrentparent.sourcecontrol.RowCount > 1 Then
                    sender.getcurrentparent.sourcecontrol.Rows.RemoveAT(0)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub menu_context_grd_delSelection(ByVal sender As Object, ByVal e As EventArgs)
        Try
            For Each c As DataGridViewRow In sender.getcurrentparent.sourcecontrol.SelectedRows
                sender.getcurrentparent.sourcecontrol.Rows.Remove(c)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub menu_context_grd_Copier(ByVal sender As Object, ByVal e As EventArgs)
        Try

            If ClipBordGrd.ColumnCount > 0 Then ClipBordGrd.Columns.Clear()
            ClipBordGrd.AllowUserToAddRows = False

            Dim grd As DataGridView
            grd = sender.getcurrentparent.sourcecontrol
            If grd.CurrentRow Is Nothing Then Return
            ClipBordGrd.Name = grd.Name

            For Each c As DataGridViewColumn In grd.Columns
                ClipBordGrd.Columns.Add(c.Name, c.Name)
            Next

            Dim Sindex As Integer = 0
            For i = 0 To grd.RowCount - 1
                If grd.Rows(i).Selected = True Then
                    ClipBordGrd.Rows.Add()
                    For j = 0 To grd.ColumnCount - 1
                        If grd.Columns(j).Visible = True Then
                            ClipBordGrd.Item(j, Sindex).Value = grd.Item(j, i).Value
                        End If
                    Next
                    Sindex += 1
                End If
            Next
            If Sindex = 0 Then
                ClipBordGrd.Rows.Add()
                For j = 0 To grd.ColumnCount - 1
                    ClipBordGrd.Item(j, 0).Value = grd.Item(j, grd.CurrentRow.Index).Value
                Next
            End If


            If ClipBordGrd.RowCount = 0 Then Exit Sub
            ClipBordGrd.SelectAll()
            ClipBordGrd.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            Clipboard.SetDataObject(ClipBordGrd.GetClipboardContent())
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub menu_context_grd_Couper(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If ClipBordGrd.ColumnCount > 0 Then ClipBordGrd.Columns.Clear()
            ClipBordGrd.AllowUserToAddRows = False

            Dim grd As DataGridView
            grd = sender.getcurrentparent.sourcecontrol
            If grd.CurrentRow Is Nothing Then Return
            ClipBordGrd.Name = grd.Name

            For Each c As DataGridViewColumn In grd.Columns
                ClipBordGrd.Columns.Add(c.Name, c.Name)
            Next

            Dim Sindex As Integer = 0
            For i = 0 To grd.RowCount - 1
                If grd.Rows(i).Selected = True Then
                    ClipBordGrd.Rows.Add()
                    For j = 0 To grd.ColumnCount - 1
                        If grd.Columns(j).Visible = True Then
                            ClipBordGrd.Item(j, Sindex).Value = grd.Item(j, i).Value
                        End If
                    Next
                    Sindex += 1
                End If
            Next
            If Sindex = 0 Then
                ClipBordGrd.Rows.Add()
                For j = 0 To grd.ColumnCount - 1
                    ClipBordGrd.Item(j, 0).Value = grd.Item(j, grd.CurrentRow.Index).Value
                Next
            End If
            If ClipBordGrd.RowCount = 0 Then Exit Sub
            ClipBordGrd.SelectAll()
            ClipBordGrd.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            Clipboard.SetDataObject(ClipBordGrd.GetClipboardContent())

            For Each oRow As DataGridViewRow In grd.Rows
                If oRow.Selected = True Then
                    grd.Rows.Remove(oRow)
                End If
            Next

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub menu_context_grd_Coller(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim grd As DataGridView
            grd = sender.getcurrentparent.sourcecontrol

            If grd.Name <> ClipBordGrd.Name Then Exit Sub
            If ClipBordGrd.RowCount = 0 Then Exit Sub
            Dim Sindex As Integer = 0
            Sindex = grd.CurrentRow.Index
            For i = 0 To ClipBordGrd.RowCount - 1
                grd.Rows.InsertCopy(0, Sindex)
                For j = 0 To grd.ColumnCount - 1
                    grd.Item(j, Sindex).Value = ClipBordGrd.Item(j, i).Value
                Next
                Sindex += 1
            Next

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
End Module
