Module PrintingQuery


    'Test d'impression

    Dim oStringFormat As StringFormat
    Dim oHeaderFormat As StringFormat
    Dim oNumberFormat As StringFormat
    Dim oStringFormatComboBox As StringFormat
    Dim oButtonX As DevComponents.DotNetBar.ButtonX
    Dim oCheckbox As CheckBox
    Dim oComboBox As ComboBox

    Dim nTotalWidth As Integer
    Dim nRowPos As Integer
    Dim NewPage As Boolean
    Dim nPageNo As Integer
    Dim TotPages As Integer
    Dim Header As String = ""
    Dim sUserName As String = ""
    Dim oGrd As DataGridView
    Public QueryCriteria As New ArrayList
    Public QueryCriteriaLibelle As New ArrayList
    Dim WLibCritere As Integer = 0
    Dim WCritere As Integer = 0
    Dim CumulHeight As Integer
    Friend nHeightCrt As Integer
    Friend NbCrt As Integer = 0
    Public SColonnes As New ArrayList
    Dim oReport As New Printing.PrintDocument
    Friend StartReport As Boolean = False

    Sub CallPrinting(ByVal Grd As DataGridView, ByVal QueryName As String)

        If MessageBoxRHP(548) = MsgBoxResult.Cancel Then
            SColonnes.Clear()
            For Each c As DataGridViewColumn In Grd.Columns
                SColonnes.Add(c.Index)
            Next
            NbCrt = 0
            StartReport = False
            Dim dlg As New PrintPreviewDialog()
            dlg.Document = QueryPrinter(Grd, QueryName)
            dlg.WindowState = FormWindowState.Maximized

            dlg.ShowDialog()

        Else
            With Zoom_QueryPrinter
                .Zoom_Grd.Rows.Clear()
                For Each c As DataGridViewColumn In Grd.Columns
                    .Zoom_Grd.Rows.Add("True", c.HeaderText, c.Index)
                    .Grd = Grd
                    .QueryName = QueryName
                Next
                .ShowDialog()
            End With
        End If


    End Sub

    Public Function QueryPrinter(ByVal Grd As DataGridView, ByVal QueryName As String) As Printing.PrintDocument

        oReport = New Printing.PrintDocument

        oStringFormat = New StringFormat
        oStringFormat.Alignment = StringAlignment.Near
        oStringFormat.LineAlignment = StringAlignment.Center
        oStringFormat.Trimming = StringTrimming.EllipsisCharacter

        oHeaderFormat = New StringFormat
        oHeaderFormat.Alignment = StringAlignment.Center
        oHeaderFormat.LineAlignment = StringAlignment.Center
        oHeaderFormat.Trimming = StringTrimming.EllipsisCharacter


        oNumberFormat = New StringFormat
        oNumberFormat.Alignment = StringAlignment.Far
        oNumberFormat.LineAlignment = StringAlignment.Center
        oNumberFormat.Trimming = StringTrimming.EllipsisCharacter

        oStringFormatComboBox = New StringFormat
        oStringFormatComboBox.LineAlignment = StringAlignment.Center
        oStringFormatComboBox.FormatFlags = StringFormatFlags.NoWrap
        oStringFormatComboBox.Trimming = StringTrimming.EllipsisCharacter

        Header = QueryName
        sUserName = GlobalVar("GV_USERNAME")
        oGrd = Grd

        TotPages = 0

        With oReport
            AddHandler .PrintPage, AddressOf PrintDocument1_PrintPage
            AddHandler .BeginPrint, AddressOf BeginPrinting
        End With

        Return oReport
    End Function

    Sub BeginPrinting()
        NbCrt = 0
        StartReport = False
        oButtonX = New DevComponents.DotNetBar.ButtonX
        oCheckbox = New CheckBox
        oComboBox = New ComboBox

        nTotalWidth = 0
        For Each oColumn As DataGridViewColumn In oGrd.Columns
            If SColonnes.Contains(oColumn.Index) Then
                nTotalWidth += oColumn.Width
            End If
        Next

        nPageNo = 1
        NewPage = True
        nRowPos = 0


        nHeightCrt = 11
        With oReport
            If nTotalWidth > .DefaultPageSettings.PaperSize.Width Then
                .DefaultPageSettings.Landscape = True
            Else
                .DefaultPageSettings.Landscape = False
            End If
            .DefaultPageSettings.Margins.Left = 40
            .DefaultPageSettings.Margins.Right = 40
        End With
    End Sub


    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Static oColumnLefts As New ArrayList
        Static oColumnWidths As New ArrayList
        Static oColumnTypes As New ArrayList
        Static oColumnIndex As New ArrayList
        Static oCrtHeight As New ArrayList
        Static nHeight As Integer
        Dim ToutesColonnesChargees As Boolean = False
        Dim nWidth, i, nRowsPerPage As Integer
        Dim nTop As Integer = e.MarginBounds.Top
        Dim nLeft As Integer = e.MarginBounds.Left
        Dim XCrt As Integer = 0



        ' Draw Header
        nTop = e.MarginBounds.Top - e.Graphics.MeasureString(Header, New Font("Arial", 12, FontStyle.Bold), e.MarginBounds.Width).Height - 13
        Dim WTtlCrt As Integer = e.Graphics.MeasureString(Header, New Font("Arial", 12, FontStyle.Bold), 2000).Width + 10
        Dim XTtlCrt As Integer = e.MarginBounds.Left + 10
        Dim HTtlCrt As Integer = e.Graphics.MeasureString(Header, New Font("Arial", 12, FontStyle.Bold), 2000).Height
        e.Graphics.DrawString(Header, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New RectangleF(XTtlCrt, nTop, WTtlCrt, HTtlCrt), oHeaderFormat)
        nHeightCrt = 2 * HTtlCrt


        ' Trait Sous le Nom de la Requête
        e.Graphics.DrawLine(Pens.Black, XTtlCrt, nTop + HTtlCrt + 2, e.MarginBounds.Right, nTop + HTtlCrt + 2)
        nTop += nHeightCrt

        If NbCrt < QueryCriteria.Count Then
            '' Impression des Critères
            'détermination du widh des Critère 
            nHeightCrt = Math.Max(e.Graphics.MeasureString(QueryCriteriaLibelle(0), New Font("Arial", 8, FontStyle.Bold), 1000).Height, e.Graphics.MeasureString(QueryCriteria(0), New Font("Arial", 8, FontStyle.Bold), 1000).Height)

            Dim WLibCritere As Integer = 0
            Dim WCritere As Integer = 0

            If QueryCriteria.Count > 0 And StartReport = False Then


                For i = 0 To QueryCriteria.Count - 1
                    WLibCritere = Math.Max(WLibCritere, e.Graphics.MeasureString(QueryCriteriaLibelle(i), New Font("Arial", 8), 1000).Width)
                    WCritere = Math.Max(WCritere, e.Graphics.MeasureString(QueryCriteria(i), New Font("Arial", 8), 1000).Width)
                Next




                WLibCritere += 10
                WCritere += 40


                'Libellé du Critère -ligne de Colonnes
                WTtlCrt = e.Graphics.MeasureString("Zone de Critères de la Requête", New Font("Arial", 10, FontStyle.Bold), 2000).Width + 10
                XTtlCrt = (e.MarginBounds.Width - WTtlCrt) / 2
                HTtlCrt = e.Graphics.MeasureString("Zone de Critères de la Requête", New Font("Arial", 10, FontStyle.Bold), 2000).Height
                e.Graphics.DrawString("Zone de Critères de la Requête", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, New RectangleF(XTtlCrt, nTop, WTtlCrt, HTtlCrt), oHeaderFormat)
                nHeightCrt = 2 * HTtlCrt

                XCrt = (e.MarginBounds.Width - (WLibCritere + WCritere)) / 2

                nTop += nHeightCrt


                'Déssiner l'Entete des critères
                nHeightCrt = Math.Max(e.Graphics.MeasureString(QueryCriteriaLibelle(0), New Font("Arial", 8, FontStyle.Bold), 1000).Height, e.Graphics.MeasureString(QueryCriteria(0), New Font("Arial", 8, FontStyle.Bold), 1000).Height)

                ' les lignes des critères

                Do While NbCrt <= QueryCriteria.Count - 1
                    nHeightCrt = Math.Max(e.Graphics.MeasureString(QueryCriteriaLibelle(NbCrt), New Font("Arial", 8, FontStyle.Bold), 1000).Height, e.Graphics.MeasureString(QueryCriteria(NbCrt), New Font("Arial", 8, FontStyle.Bold), 1000).Height)
                    nTop += nHeightCrt
                    ' nTop = e.MarginBounds.Top

                    If nTop <= e.MarginBounds.Height + e.MarginBounds.Top Then
                        'e.Graphics.DrawRectangle(Pens.Black, XCrt, nTop, WLibCritere, nHeightCrt)
                        'e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, nTop + nHeightCrt + 2, e.MarginBounds.Right, nTop + nHeightCrt + 2)
                        e.Graphics.DrawString(QueryCriteriaLibelle(NbCrt), New Font("Arial", 8, FontStyle.Bold), Brushes.Black, New RectangleF(e.MarginBounds.Left, nTop + 4, WLibCritere, nHeightCrt), oStringFormat)
                        e.Graphics.DrawString(":", New Font("Arial", 8, FontStyle.Bold), Brushes.Black, New RectangleF(e.MarginBounds.Left + WLibCritere + 5, nTop + 4, WLibCritere, nHeightCrt), oStringFormat)
                        'e.Graphics.DrawRectangle(Pens.Black, New Rectangle(XCrt + WLibCritere, nTop, WCritere, nHeightCrt))
                        e.Graphics.DrawString(QueryCriteria(NbCrt), New Font("Arial", 8, FontStyle.Bold), Brushes.Black, New RectangleF(e.MarginBounds.Left + WLibCritere + 15, nTop + 4, WCritere, nHeightCrt), oStringFormat)
                    Else
                        Exit Do
                    End If
                    NbCrt += 1
                Loop
            End If
            StartReport = True
            e.HasMorePages = True
            Exit Sub
        Else
            StartReport = True
            NewPage = True
            e.HasMorePages = False
            '  Exit Sub
        End If



        ''Edition de l'Etat
        If StartReport = False Then Exit Sub
        nLeft = e.MarginBounds.Left + 20
        If ToutesColonnesChargees = False Then
            For Each oColumn As DataGridViewColumn In oGrd.Columns
                If SColonnes.Contains(oColumn.Index) Then
                    If nLeft + CType(Math.Floor(oColumn.Width * e.MarginBounds.Width / nTotalWidth), Integer) - e.MarginBounds.Left - e.MarginBounds.Right <= e.MarginBounds.Width Then
                        nWidth = CType(Math.Floor(oColumn.Width * e.MarginBounds.Width / nTotalWidth), Integer)
                        nHeight = e.Graphics.MeasureString(oColumn.HeaderText, New Font("Arial", 8), nWidth).Height + 11
                        oColumnLefts.Add(nLeft)
                        oColumnWidths.Add(nWidth)
                        oColumnTypes.Add(oColumn.GetType)
                        oColumnIndex.Add(oColumn.Index)
                        nLeft += nWidth
                    End If
                End If
            Next

            ToutesColonnesChargees = True
        End If
        XCrt = (e.MarginBounds.Width - nLeft) / 2
        Do While nRowPos < oGrd.Rows.Count

            Dim oRow As DataGridViewRow = oGrd.Rows(nRowPos)

            If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then

                DrawFooter(e, nRowsPerPage)

                NewPage = True
                nPageNo += 1
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then



                    ' Draw Columns
                    nTop = e.MarginBounds.Top
                    i = 0
                    For Each oColumn As DataGridViewColumn In oGrd.Columns
                        If SColonnes.Contains(oColumn.Index) Then
                            If oColumnIndex.Contains(oColumn.Index) = True Then
                                e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(oColumnLefts(i) + XCrt, nTop, oColumnWidths(i), nHeight))
                                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i) + XCrt, nTop, oColumnWidths(i), nHeight))
                                e.Graphics.DrawString(oColumn.HeaderText, New Font("Arial", 8), New SolidBrush(oColumn.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + XCrt, nTop, oColumnWidths(i), nHeight), oHeaderFormat)
                                i += 1
                            End If
                        End If
                    Next
                    NewPage = False

                End If

                nTop += nHeight
                i = 0
                On Error Resume Next
                For Each oCell As DataGridViewCell In oRow.Cells
                    If SColonnes.Contains(oCell.ColumnIndex) Then
                        If oColumnIndex.Contains(oCell.ColumnIndex) = True Then
                            If oColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse oColumnTypes(i) Is GetType(DataGridViewLinkColumn) Then
                                If oCell.Value Is Nothing OrElse (IsNumeric(oCell.Value) = False And EstDate(oCell.Value) = False) Then
                                    e.Graphics.DrawString(oCell.Value.ToString, New Font("Arial", 8), New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + XCrt, nTop, oColumnWidths(i), nHeight), oStringFormat)
                                ElseIf EstDate(oCell.Value) = True Then
                                    e.Graphics.DrawString(oCell.Value, New Font("Arial", 8), New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + XCrt, nTop, oColumnWidths(i), nHeight), oNumberFormat)
                                ElseIf Math.Floor(CDbl(oCell.Value)) = oCell.Value Then
                                    e.Graphics.DrawString(FormatNumber(oCell.Value, 0), New Font("Arial", 8), New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + XCrt, nTop, oColumnWidths(i), nHeight), oNumberFormat)
                                Else
                                    e.Graphics.DrawString(FormatNumber(oCell.Value), New Font("Arial", 8), New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + XCrt, nTop, oColumnWidths(i), nHeight), oNumberFormat)
                                End If

                            ElseIf oColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then

                                oButtonX.Text = oCell.Value.ToString
                                oButtonX.Size = New Size(oColumnWidths(i), nHeight)
                                Dim oBitmap As New Bitmap(oButtonX.Width, oButtonX.Height)
                                oButtonX.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                                e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))

                            ElseIf oColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then
                                On Error Resume Next
                                oCheckbox.Size = New Size(14, 14)
                                oCheckbox.Checked = CType(oCell.Value, Boolean)
                                Dim oBitmap As New Bitmap(oColumnWidths(i), nHeight)
                                Dim oTempGraphics As Graphics = Graphics.FromImage(oBitmap)
                                oTempGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                                oCheckbox.DrawToBitmap(oBitmap, New Rectangle(CType((oBitmap.Width - oCheckbox.Width) / 2, Integer), CType((oBitmap.Height - oCheckbox.Height) / 2, Integer), oCheckbox.Width, oCheckbox.Height))
                                e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i) + XCrt, nTop))

                            ElseIf oColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then

                                oComboBox.Size = New Size(oColumnWidths(i), nHeight)
                                Dim oBitmap As New Bitmap(oComboBox.Width, oComboBox.Height)
                                oComboBox.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                                e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                                e.Graphics.DrawString(oCell.Value.ToString, New Font("Arial", 8), New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + 1, nTop, oColumnWidths(i) - 16, nHeight), oStringFormatComboBox)

                            ElseIf oColumnTypes(i) Is GetType(DataGridViewImageColumn) Then

                                Dim oCellSize As Rectangle = New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight)
                                Dim oImageSize As Size = CType(oCell.Value, Image).Size
                                e.Graphics.DrawImage(oCell.Value, New Rectangle(oColumnLefts(i) + CType(((oCellSize.Width - oImageSize.Width) / 2), Integer), nTop + CType(((oCellSize.Height - oImageSize.Height) / 2), Integer), CType(oCell.Value, Image).Width, CType(oCell.Value, Image).Height))

                            End If

                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i) + XCrt, nTop, oColumnWidths(i), nHeight))

                            i += 1
                        End If
                    End If
                Next

            End If

            nRowPos += 1
            nRowsPerPage += 1

        Loop

        DrawFooter(e, nRowsPerPage)

        e.HasMorePages = False
        oColumnIndex.Clear()
        oColumnLefts.Clear()
        oColumnTypes.Clear()
        oColumnWidths.Clear()

    End Sub

    Private Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Integer)
        If RowsPerPage = 0 Then RowsPerPage = 1
        If TotPages = 0 OrElse TotPages = 1 Then
            TotPages = Math.Ceiling(oGrd.Rows.Count / RowsPerPage)
        End If
        Dim sPageNo As String = "Page " & nPageNo.ToString & " sur " & TotPages

        ' Right Align - User Name
        ' e.Graphics.DrawString(sUserName, oGrd.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, oGrd.Font, e.MarginBounds.Width).Width), )
        Dim sUserNameWidth As Integer = e.Graphics.MeasureString(sUserName, New Font("Arial", 8), 1000).Width
        e.Graphics.DrawString(sUserName, New Font("Arial", 8), Brushes.Black, e.MarginBounds.Right - sUserNameWidth, e.MarginBounds.Top + e.MarginBounds.Height + 31)
        ' Left Align - Date/Time
        e.Graphics.DrawString(Now.ToLongDateString + " " + Now.ToShortTimeString, oGrd.Font, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + e.MarginBounds.Height + 31)

        ' Center  - Page No. Info
        e.Graphics.DrawString(sPageNo, oGrd.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, oGrd.Font, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + e.MarginBounds.Height + 31)

    End Sub




End Module