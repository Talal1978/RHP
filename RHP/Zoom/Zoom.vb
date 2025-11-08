Imports System.Text.RegularExpressions
Public Class Zoom
    Dim oRow As Integer = 0
    Dim TblZoomP As New DataTable
    Dim ColumnSearch As Integer = 1
    Friend NumZoom As String = ""
    Dim Zoom_Order As String = ""
    Dim ZoomSens As String = ""
    Dim MenuTitre As String = ""
    Dim oSize As New Size
    Dim oLoc As New Point
    Private Sub Zoom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Zoom_Grd.ColumnCount = 0 Then Return
        If Zoom_Grd.SelectedCells.Count > 0 Then ColumnSearch = Zoom_Grd.SelectedCells(0).ColumnIndex
        Select Case CStr(e.KeyChar).ToUpper
            Case "0" To "9"
                AddingText(ColumnSearch, CStr(e.KeyChar))
            Case "a" To "z"
                AddingText(ColumnSearch, CStr(e.KeyChar))
            Case "A" To "Z"
                AddingText(ColumnSearch, CStr(e.KeyChar))
            Case "*"
                AddingText(ColumnSearch, CStr(e.KeyChar))
        End Select
    End Sub
    Sub AddingText(Colonne As Integer, str As String)
        With Zoom_Grd
            If Colonne >= 0 And Colonne < .ColumnCount And Not Zoom_Grd.ZoneFiltertxt.Visible Then
                Dim rtg As Rectangle = .GetCellDisplayRectangle(Colonne, -1, False)
                With Zoom_Grd.ZoneFiltertxt
                    .Tag = Colonne
                    .Visible = True
                    .Location = New Point(rtg.X, rtg.Y + (rtg.Height - .Height) / 2)
                    .Width = rtg.Width - 25
                    .Height = rtg.Height - 2
                    .BringToFront()
                    .Focus()
                    .Text = str
                    .SelectionStart = .TextLength
                End With
            End If
        End With
    End Sub
    Private Sub Zoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Zoom_Grd
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            Dim minWidth As Integer = 100
            Dim totWidth As Integer = minWidth
            If .SelectedCells.Count > 0 And .RowCount > 0 Then
                .Item(ColumnSearch, 0).Selected = True
            End If
            For i = 0 To .ColumnCount - 1
                .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                minWidth = .Columns(i).Width + 22
                .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Columns(i).Width = minWidth
                .Columns(i).MinimumWidth = minWidth
                totWidth += minWidth
            Next
            Me.Size = New Size(Math.Min(totWidth, 0.8 * leMenu.Width), Me.Height)
            If Me.Width + Me.Location.X > leMenu.Width Then
                Me.Location = New Point(leMenu.Width - Me.Width - 5, Me.Location.Y)
            End If
            oSize = Me.Size
            oLoc = Me.Location
            .Fit()
        End With
        CenterControlInParent(Zoom_Text, True, True)
        ent_pnl.BackColor = colorBase04
    End Sub
    Sub Loading()
        Try
            Me.KeyPreview = True
            Dim Cod_Sql As String = ""
            If NumZoom = "" Then
                MenuTitre = Zoom_lbl.Text
                Zoom_Lib &= " as Intitulé "
                Zoom_Order = Zoom_OrderByG
            Else
                MenuTitre = NumZoom
                Dim oRow() As DataRow
                oRow = Tbl_Controle_Def_Zoom.Select("[Num_Zoom]='" & NumZoom & "'")
                Zoom_Cod = IsNull(oRow(0)("Index_Table"), "")
                Zoom_Lib = IsNull(oRow(0)("Description"), "")
                Zoom_Tbl = IsNull(oRow(0)("Table_Ref"), "")
                Zoom_Where1 = IsNull(oRow(0)("Condition"), "")
                Zoom_Order = IsNull(oRow(0)("Order_By"), "")
                ZoomSens = IsNull(oRow(0)("Order_By_Sens"), "Asc")
                Zoom_Where1 &= IIf(Zoom_Condition <> "", " and " & Zoom_Condition, "")
                If IsNumeric(oRow(0)("Search_By")) Then
                    ColumnSearch = IIf(CInt(oRow(0)("Search_By")) > 1, CInt(oRow(0)("Search_By")) - 1, 0)
                Else
                    ColumnSearch = 1
                End If

            End If
            Zoom_lbl.Text = MenuTitre
            Dim olist = ContientIdSoc(Zoom_Tbl)
            If olist.Count > 0 Then
                Dim idSocWhere = ""
                If olist.Count > 0 Then
                    idSocWhere = $" ({olist(0)}.id_Societe={Societe.id_Societe} or {olist(0)}.id_Societe=-1)"
                End If
                Zoom_Where1 &= IIf(idSocWhere = "", "", $" and ({idSocWhere})")
            End If
            ' Zoom_Tbl = FilterRoleWhere(Zoom_Tbl)
            Cod_Sql = "select distinct " & Zoom_Cod & " as Code," & Zoom_Lib & " FROM " & Zoom_Tbl & " where " & Zoom_Where1 & IIf(Zoom_Order <> "", " Order by " & Zoom_Order, "") & " " & ZoomSens
            '  If NumZoom = "MS067" Then MsgBox(Cod_Sql)
            If IsNull(Zoom_Parameters, "") <> "" Then
                Cod_Sql = String.Format(Cod_Sql, Zoom_Parameters.Split(","))
            End If
            Dim rgx As New Regex("(?<=\W)GV_\w+", RegexOptions.IgnoreCase)
            For Each c As Match In rgx.Matches(Cod_Sql)
                Cod_Sql = Cod_Sql.Replace(c.Value, "'" & GlobalVar(c.Value.Trim.ToString) & "'")
            Next

            rgx = New Regex(sql_injection, RegexOptions.IgnoreCase)
            If rgx.Matches(Cod_Sql).Count > 0 Then
                ShowMessageBox("Votre requête contient des expressions interdites : " & rgx.Matches(Cod_Sql)(0).Value, "Vérification de zoom", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
            '  If NumZoom = "MS067" Then MsgBox(Cod_Sql)
            TblZoomP = ChargerGrille(Cod_Sql)
            If TblZoomP Is Nothing Then Return
            Dim Col As Integer = TblZoomP.Columns.Count - 1
            Dim oWidth As Integer = 0
            Dim oIndx(TblZoomP.Columns.Count - 1) As Integer
            With Zoom_Grd
                .ContextMenuStrip = AddContextMenu(False, True, True, True, False, False, False, False)
                If TblZoomP.Rows.Count > 100 Then
                    .DataSource = TblZoomP.AsEnumerable.Take(50).CopyToDataTable
                Else
                    .DataSource = TblZoomP
                End If

                For i = 0 To Col
                    If TblZoomP.Columns(i).DataType.ToString.Contains("Double") Then
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(i).DefaultCellStyle.Format = "N2"
                    ElseIf TblZoomP.Columns(i).DataType.ToString.Contains("Date") Then
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End If
                    oIndx(i) = i
                Next

                With Zoom_Grd
                    .dataSourceOrigine = TblZoomP
                    .setFilter(oIndx)
                End With
                For i = 0 To Col
                    oWidth += .Columns(i).Width + 1
                Next
                AddHandler .PreviewKeyDown, AddressOf EnterClicking
                If .ColumnCount > 0 And .RowCount > 0 And ColumnSearch >= 0 And ColumnSearch < .ColumnCount Then
                    .Item(ColumnSearch, 0).Selected = True
                End If
                Me.Width = Math.Min(oWidth + 20, 500)
                ' Ajouter l'événement textchanged au text de sélection
                AddHandler .ZoneFiltertxt.TextChanged, AddressOf txt_TextChanged
            End With
            Zoom_Grd.HorizontalScrollingOffset = 0 '.SetScrollState(0, True)
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Erreur zoom", MessageBoxButtons.OK, msgIcon.Error)
        End Try
    End Sub
    Sub txt_TextChanged(sender As Object, e As EventArgs)

        If sender.Visible Then
            With Zoom_Grd
                .dicCol(sender.Tag).filter = sender.Text.Trim
                .Filtering()
            End With
            Zoom_lbl.Text = MenuTitre & " (" & Zoom_Grd.RowCount & ")"
        End If

    End Sub
    Sub EnterClicking(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        Select Case sender.Name
            Case "Zoom_Grd"
                If e.KeyData = Keys.Enter And Zoom_Grd.SelectedCells.Count > 0 And Zoom_Grd.Focused Then
                    SELECTION_GRD()
                End If
        End Select

    End Sub

    Private Sub Zoom_Grd_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Zoom_Grd.CellDoubleClick
        If e.RowIndex >= 0 Then SELECTION_GRD()
    End Sub

    Sub SELECTION_GRD()
        Try
            With Zoom_Grd
                If .SelectedCells.Count = 0 Then Exit Sub
                Dim oRow As Integer = .SelectedCells(0).RowIndex
                If oRow < 0 Then Exit Sub
                Select Case Zoom_Object.GetType.Name
                    Case "TextBox", "ud_TextBox"
                        Zoom_Object.Text = ""
                        Zoom_Object.Text = .Item(0, oRow).Value
                    Case "LinkLabel"
                        Zoom_Object.Text = ""
                        Zoom_Object.Text = .Item(0, oRow).Value
                    Case "ComboBox", "ud_ComboBox"
                        Zoom_Object.Selectedvalue = .Item(0, oRow).Value
                    Case "DataGridViewTextBoxCell", "DataGridViewComboBoxCell"
                        Zoom_Object.value = .Item(0, oRow).Value
                End Select
                Me.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Erase_pb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Erase_pb.Click
        Select Case Zoom_Object.GetType.Name
            Case "TextBox", "ud_TextBox"
                Zoom_Object.Text = ""
            Case "LinkLabel"
                Zoom_Object.Text = ""
            Case "ComboBox", "ud_ComboBox"
                Zoom_Object.Selectedindex = -1
            Case "DataGridViewTextBoxCell"
                Zoom_Object.value = ""
        End Select
        Me.Close()
    End Sub
    Sub Maximize_pb_Click(sender As Object, e As EventArgs) Handles Maximize_pb.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Size = oSize
            Me.Location = oLoc
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Escape
                Me.Close()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub Close_pb_Load(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class