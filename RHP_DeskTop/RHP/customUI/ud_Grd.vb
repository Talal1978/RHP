Public Class ud_Grd
    Inherits DataGridView
    Friend WithEvents ZoneFiltertxt As New TextBox
    Dim prefiltre As Boolean = False
    Friend ModeFiltreActive As Boolean = False
    Friend FiltreStr As String = ""
    Friend dataSourceOrigine As New DataTable
    Dim _AlternerLesLignes As Boolean = False
    Dim _AfficherLesEntetesLignes As Boolean = True
    Dim colHeaderStyle, rowHeaderStyle, cellStyle, cellAlterStyle As New System.Windows.Forms.DataGridViewCellStyle
    Public Property AlternerLesLignes As Boolean
        Get
            Return _AlternerLesLignes
        End Get
        Set(value As Boolean)
            If value Then
                Me.AlternatingRowsDefaultCellStyle = cellAlterStyle
            Else
                Me.AlternatingRowsDefaultCellStyle = Nothing
            End If
        End Set
    End Property
    Public Property AfficherLesEntetesLignes As Boolean
        Get
            Return _AfficherLesEntetesLignes
        End Get
        Set(value As Boolean)
            Me.RowHeadersVisible = value
            Me.Invalidate()
        End Set
    End Property
    Class filterArgs
        Friend image As Image
        Friend filter As String
        Friend width As Integer
    End Class
    Friend dicCol As New Dictionary(Of Integer, filterArgs)
    Sub New()
        Me.SuspendLayout()
        Me.DoubleBuffered = True

        With colHeaderStyle
            .BackColor = Color.FromArgb(56, 153, 185)
            .Font = RHPdefaultFont
            .ForeColor = System.Drawing.Color.White
            .SelectionBackColor = Color.FromArgb(56, 153, 185)
            .SelectionForeColor = Color.White
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .WrapMode = DataGridViewTriState.True
            .Padding = New Padding(5, 5, 5, 5)
            Me.ColumnHeadersDefaultCellStyle = colHeaderStyle
        End With
        With rowHeaderStyle
            .BackColor = Color.FromArgb(169, 210, 224)
            Me.RowHeadersDefaultCellStyle = rowHeaderStyle
        End With
        With cellStyle
            .Font = RHPdefaultFont
            .SelectionBackColor = colorBase02
            .SelectionForeColor = System.Drawing.SystemColors.HighlightText
            Me.DefaultCellStyle = cellStyle
        End With
        With cellAlterStyle
            .BackColor = Color.FromArgb(219, 235, 240)
        End With
        With Me
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .GridColor = Color.FromArgb(179, 216, 228)
            .BorderStyle = BorderStyle.None
            .EnableHeadersVisualStyles = False
            .DoubleBuffered = True
            .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        End With
        Me.ResumeLayout(True)
    End Sub
    Private Sub dataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Me.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso TypeOf Me.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
            e.PaintBackground(e.ClipBounds, True)

            Dim checkboxSize As Integer = 12 ' size of the checkbox
            Dim pt As New Point(e.CellBounds.Left + (e.CellBounds.Width - checkboxSize) / 2, e.CellBounds.Top + (e.CellBounds.Height - checkboxSize) / 2)

            Dim isChecked As Boolean = False
            If e.Value IsNot Nothing AndAlso Boolean.TryParse(e.Value.ToString(), isChecked) AndAlso isChecked Then
                ' Draw checked state
                e.Graphics.FillRectangle(New SolidBrush(colorBase01), pt.X, pt.Y, checkboxSize, checkboxSize) ' Change Brushes.Green to your desired color
                '   e.Graphics.DrawRectangle(Pens.Black, pt.X, pt.Y, checkboxSize, checkboxSize)
                e.Graphics.DrawLine(New Pen(Color.White, 2), CInt(pt.X + 2), CInt(pt.Y + checkboxSize / 2), CInt(pt.X + checkboxSize / 2), pt.Y + checkboxSize - 2)
                e.Graphics.DrawLine(New Pen(Color.White, 2), CInt(pt.X + checkboxSize / 2), pt.Y + checkboxSize - 2, pt.X + checkboxSize - 2, pt.Y + 2)
            Else
                ' Draw unchecked state
                ' e.Graphics.FillRectangle(Brushes.Red, pt.X, pt.Y, checkboxSize, checkboxSize) ' Change Brushes.Red to your desired color
                e.Graphics.DrawRectangle(New Pen(colorBase01, 2), pt.X, pt.Y, checkboxSize, checkboxSize)
            End If

            e.Handled = True
        ElseIf e.RowIndex >= 0 AndAlso e.ColumnIndex = -1 And Me.RowHeadersVisible Then

            e.PaintBackground(e.ClipBounds, True)
            e.Graphics.DrawString(CStr(e.RowIndex + 1), DefaultFont, New SolidBrush(colorBase01), e.CellBounds.Left + 5, e.CellBounds.Top + 5)
            e.Handled = True
        End If
    End Sub

    Sub setFilter(Indx() As Integer)
        Me.SuspendLayout()
        dicCol.Clear()
        If dataSourceOrigine Is Nothing Or dataSourceOrigine?.Columns.Count = 0 Then dataSourceOrigine = DataSource
        For Each nd In Indx
            If Not dicCol.ContainsKey(nd) Then dicCol.Add(nd, New filterArgs With {.image = My.Resources.btn_search_w, .filter = "", .width = If(Me.Columns.Count > 0, Me.Columns(nd).Width, 100) + 25})
        Next
        If Not prefiltre Then
            Dim oMnu As New ToolStripMenuItem
            With oMnu
                .Name = "oMnu"
                .Text = "Filtre avancé"
                .Image = My.Resources.Filtrer
                AddHandler .Click, AddressOf FiltreAvance
            End With
            If Me.ContextMenuStrip IsNot Nothing Then
                If Me.ContextMenuStrip.Items("oMnu") Is Nothing Then Me.ContextMenuStrip.Items.Insert(0, oMnu)
            Else
                Dim oCntx As New ContextMenuStrip
                oCntx.Items.Add(oMnu)
                Me.ContextMenuStrip = oCntx
            End If
            'Ajouter le texte de saisie du filtre
            With ZoneFiltertxt
                .Text = ""
                .Visible = False
                AddHandler .LostFocus, AddressOf txt_txtMasque
                AddHandler .PreviewKeyDown, AddressOf txt_PreviewKeyDown
                .BringToFront()
            End With

            With Me
                .Controls.Add(ZoneFiltertxt)
                AddHandler .CellMouseMove, AddressOf Grd_CellMouseMove
                AddHandler .CellPainting, AddressOf Grd_CellPainting
                AddHandler .ColumnHeaderMouseClick, AddressOf Grd_ColumnHeaderMouseClick
                AddHandler .Scroll, AddressOf Grd_Scroll
            End With
            prefiltre = True
        End If
        '   Me.Invalidate()
        Me.ResumeLayout(True)
    End Sub
    Private Sub txt_txtMasque(sender, e)
        txtMasque()
    End Sub
    Private Sub txt_PreviewKeyDown(sender As TextBox, e As PreviewKeyDownEventArgs)
        Dim a As Object = e.KeyCode
        If sender.Visible Then
            Select Case e.KeyData
                Case Keys.Enter, Keys.Tab
                    txtMasque()
            End Select
        End If
    End Sub
    Sub Fit()
        If Columns.Count = 0 Then Return
        For Each col As DataGridViewColumn In Me.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        Me.Columns(Me.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub ud_Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Me.DataError

    End Sub
    Sub checkCell(oCell As DataGridViewCell)
        Dim r = oCell.RowIndex
        If Me.AllowUserToAddRows And r = Me.Rows.Count - 1 Then
            Me.Rows.Add()
            Me.CurrentCell = Me.Item(oCell.ColumnIndex, r)
        End If
        Me.Item(oCell.ColumnIndex, r).Value = Not CBool(IsNull(Me.Item(oCell.ColumnIndex, r).Value, False))
    End Sub
    Private Sub ud_Grd_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Me.CellMouseClick
        If e.ColumnIndex < 0 Then Return
        If e.RowIndex = -1 And dicCol.ContainsKey(e.ColumnIndex) Then
            Me.Columns(e.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Dim w = Me.Columns(e.ColumnIndex).Width
            If e.X > Me.Columns(e.ColumnIndex).Width - 30 Then
                sender.Columns(e.ColumnIndex).SortMode = DataGridViewColumnSortMode.NotSortable
            Else
                sender.Columns(e.ColumnIndex).SortMode = DataGridViewColumnSortMode.Automatic
            End If
            Me.Columns(e.ColumnIndex).Width = w
        Else
            If Me.Columns.Count = 0 Then Return
            If TypeOf Me.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn And e.RowIndex >= 0 And Not Me.ReadOnly Then
                checkCell(Me.CurrentCell)
            End If
        End If
    End Sub
    Private Sub Grd_Scroll(sender As ud_Grd, e As Object)
        If ZoneFiltertxt.Visible Then
            txtMasque()
        End If
    End Sub
    Private Sub Grd_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs)
        If e.RowIndex = -1 And e.ColumnIndex > -1 Then
            Dim rct As Rectangle = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
            If e.X <= rct.Width And e.X >= rct.Width - 25 Then
                sender.Cursor = Cursors.Hand
            Else
                sender.Cursor = Cursors.Default
            End If
        End If
    End Sub
    Private Sub Grd_CellPainting(sender As ud_Grd, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex = -1 And e.ColumnIndex >= 0 Then
            If dicCol.ContainsKey(e.ColumnIndex) Then

                ' Let DataGridView paint the cell with all its parts except SelectionBackground
                e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.SelectionBackground)

                ' Now overlay the filter icon
                Dim rtg As New Rectangle(New Point(e.CellBounds.Right - 25, e.CellBounds.Top + (e.CellBounds.Height - 16) / 2), New Size(12, 12))
                e.Graphics.DrawImage(dicCol(e.ColumnIndex).image, rtg)

                ' Since we've handled the painting now, set Handled to true
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Grd_ColumnHeaderMouseClick(sender As ud_Grd, e As DataGridViewCellMouseEventArgs)
        If e.RowIndex = -1 And e.ColumnIndex > -1 Then
            If sender.Cursor = Cursors.Hand And dicCol.ContainsKey(e.ColumnIndex) Then
                Dim rtg As Rectangle = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                With ZoneFiltertxt
                    .Tag = e.ColumnIndex
                    .Location = New Point(rtg.X, rtg.Y + (rtg.Height - .Height) / 2)
                    .Visible = True
                    .Text = dicCol(e.ColumnIndex).filter
                    .Width = rtg.Width - 25
                    .Height = rtg.Height - 2
                    .BringToFront()
                    .Select()
                    .Focus()
                End With
            End If
        End If
    End Sub
    Private Sub ud_Grd_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Me.RowsRemoved
        Me.Invalidate()
    End Sub
#Region "Filtre"

    Private Sub txtMasque()
        '   Return
        ZoneFiltertxt.Visible = False
        If CStr(ZoneFiltertxt.Tag) = "" Then Return
        If Not IsNumeric(ZoneFiltertxt.Tag) Then Return
        If ZoneFiltertxt.Text.Trim <> "" Then
            dicCol(ZoneFiltertxt.Tag).image = My.Resources.btn_filter_w
        Else
            dicCol(ZoneFiltertxt.Tag).image = My.Resources.btn_search_w
        End If
        dicCol(ZoneFiltertxt.Tag).filter = ZoneFiltertxt.Text.Trim
        ZoneFiltertxt.Tag = ""
        Me.Refresh()
        Filtering()
        Me.Focus()
        If Me.RowCount > 0 Then
            Me.Item(0, 0).Selected = True
        End If
    End Sub
    Sub Filtering()
        '.Tag = {Colimg, Col, ColFilterFormule, txt, "", DataTbl}
        Dim FilterStr As String = ""
        Dim colName As String = ""
        Dim oFiltre As String = ""
        Dim Dtr As New DataTable
        Dtr = dataSourceOrigine
        If Dtr Is Nothing Then Return
        If Me.ColumnCount = 0 Then Return
        For i = 0 To ColumnCount - 1
            With Columns(i).HeaderCell.Style
                .ForeColor = Color.White
                .SelectionBackColor = Color.FromArgb(56, 153, 185)
                .SelectionForeColor = Color.White
            End With
        Next
        With Dtr
            For Each nd In dicCol.Keys
                FilterStr = ""
                If .Columns.Count > nd Then
                    'Réinitialiser la variable FilterStr et ColName
                    colName = .Columns(nd).ColumnName
                    If .Columns(colName).DataType.ToString.ToUpper.Contains("DOUBLE") Or .Columns(colName).DataType.ToString.ToUpper.Contains("INT") Then
                        Dim oValeur As String = dicCol(nd).filter.Trim.Replace(">=", "").Replace("> =", "").Replace(">", "").Replace("<=", "").Replace("< =", "").Replace("<", "").Replace("=", "").Trim.Replace(".", ",")

                        If IsNumeric(oValeur) Then
                            If dicCol(nd).filter.Trim.StartsWith(">") Or dicCol(nd).filter.Trim.StartsWith("<") Or dicCol(nd).filter.Trim.StartsWith("=") Then
                                FilterStr = "[" & colName & "] " & dicCol(nd).filter.Trim.Replace(",", ".")
                            Else
                                FilterStr = "[" & colName & "] " & " =" & dicCol(nd).filter.Trim.Replace(",", ".")
                            End If
                        End If
                    ElseIf .Columns(colName).DataType.ToString.ToUpper.Contains("DATETIME") Then
                        Dim oValeur As String = dicCol(nd).filter.Trim.Replace(">=", "").Replace("> =", "").Replace(">", "").Replace("<=", "").Replace("< =", "").Replace("<", "").Replace("=", "").Trim
                        If EstDate(oValeur) Then
                            If dicCol(nd).filter.Trim.StartsWith(">") Or dicCol(nd).filter.Trim.StartsWith("<") Or dicCol(nd).filter.Trim.StartsWith("=") Then
                                FilterStr = "[" & colName & "] " & dicCol(nd).filter.Replace(oValeur, "").Trim & "'" & oValeur & "'"
                            Else
                                FilterStr = "[" & colName & "] " & " =" & "'" & oValeur & "'"
                            End If
                        End If
                    ElseIf .Columns(colName).DataType.ToString.ToUpper.Contains("BOOLEAN") Then
                        Dim oValeur As String = ""
                        Select Case dicCol(nd).filter.Trim.ToUpper
                            Case "VRAI", "OUI", "TRUE", "1"
                                FilterStr = "[" & colName & "] " & " ='True'"
                            Case "FAUX", "NON", "FALSE", "0"
                                FilterStr = "[" & colName & "] " & " ='False'"
                        End Select
                    Else
                        Dim oValeur As String = dicCol(nd).filter.Trim.Replace(">=", "").Replace("> =", "").Replace(">", "").Replace("<=", "").Replace("< =", "").Replace("<", "").Replace("=", "").Trim
                        If oValeur <> "" Then
                            If dicCol(nd).filter.Trim.StartsWith(">") Or dicCol(nd).filter.Trim.StartsWith("<") Or dicCol(nd).filter.Trim.StartsWith("=") Then
                                FilterStr = "[" & colName & "] " & dicCol(nd).filter.Replace(oValeur, "").Trim & "'" & oValeur & "'"
                            Else
                                FilterStr = MultiLikeFilter(colName, oValeur)
                            End If
                        End If
                    End If
                    If FilterStr.Trim <> "" Then
                        oFiltre &= IIf(oFiltre = "", "", " and ") & FilterStr
                        With Columns(nd).HeaderCell.Style
                            .ForeColor = Color.Red
                            .SelectionBackColor = Color.FromArgb(56, 153, 185)
                            .SelectionForeColor = Color.Red
                        End With
                    End If
                End If
            Next
        End With

        Try
            If oFiltre <> "" Then
                Dtr.DefaultView.RowFilter = oFiltre
                ModeFiltreActive = True
                FiltreStr = oFiltre
            Else
                Dtr.DefaultView.RowFilter = "1=1"
                ModeFiltreActive = False
                FiltreStr = ""
            End If
            Me.DataSource = Dtr
        Catch ex As Exception
            ShowMessageBox("Erreur condition de filtre : " & vbCrLf & oFiltre)
            Return
        End Try

    End Sub
    Function MultiLikeFilter(oColName As String, oValeur As String) As String
        oValeur = oValeur.Replace("%", "*").Trim
        Dim rsl As String = ""
        If Not oValeur.Contains("*") Then
            rsl = "[" & oColName & "] like '%" & oValeur.Trim & "%'"
        Else
            Dim str() As String = oValeur.Split("*")

            For i = 0 To str.Length - 1
                If i = 0 Then
                    If str(i).Trim = "" Then
                        '  rsl = "[" & oColName & "] like '%"
                    Else
                        rsl = "[" & oColName & "] " & IIf(str(i).Contains("!"), "NOT", "") & " like '" & str(i).Replace("!", "").Trim & "%'"
                    End If
                ElseIf i < str.Length - 1 Then
                    If str(i).Trim <> "" Then rsl &= IIf(rsl <> "", " and ", "") & " [" & oColName & "] " & IIf(str(i).Contains("!"), "NOT", "") & " like '%" & str(i).Replace("!", "").Trim & "%'"

                ElseIf i = str.Length - 1 Then
                    If str(i).Trim = "" Then
                        '  rsl &= "%'"
                    Else
                        rsl &= IIf(rsl <> "", " and ", "") & " [" & oColName & "] " & IIf(str(i).Contains("!"), "NOT", "") & " like '%" & str(i).Replace("!", "").Trim & "'"
                    End If

                End If
            Next
        End If
        '    Dim sw As New IO.StreamWriter("TraceMTM.txt", True)
        '  sw.WriteLine(oValeur & " => : " & rsl)
        '   sw.Close()

        Return rsl
    End Function
    Sub FiltreAvance(sender As Object, e As EventArgs)
        'Dim grd As New DataGridView
        'grd = sender.getcurrentparent.sourcecontrol
        'grd.DataSource = grd.Tag(5)
        Dim f As New Zoom_FiltreAvance
        With f
            .Grd = Me
            .oMnu = sender
            newShowEcran(f, True)
        End With
    End Sub
    Private Sub ud_Grd_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If Me.Rows.Count = 0 Then Return
        If [ReadOnly] Then Return
        If CurrentCell Is Nothing Then Return
        If e.KeyData = Keys.Space Then
            If TypeOf Columns(CurrentCell.ColumnIndex) Is DataGridViewCheckBoxColumn Then
                checkCell(Me.CurrentCell)
            End If
        End If
    End Sub
#End Region
End Class
