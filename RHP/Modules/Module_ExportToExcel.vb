Module Module_ExportToExcel
    Public EtapeStr As String
    Friend XGrd As DataGridView
    Public ColonneExcel As New System.Data.DataTable
    '   Public ExportExcelEncours As Boolean = False

    Sub ExporterVersExcel(ByVal Grd As DataGridView)

        '  La méthode RunWorkerAsync() du BackgroundWorker déclenche le thread d'arrière plan.
        XGrd = Grd
        Dim BgExportExcel As New System.ComponentModel.BackgroundWorker
        With BgExportExcel
            AddHandler .DoWork, AddressOf BgExportExcel_DoWork
            AddHandler .RunWorkerCompleted, AddressOf BgExportExcel_RunWorkerCompleted
            .RunWorkerAsync()
        End With


        Zoom_PBar.ShowDialog()

    End Sub
    'La procédure DoWork contient le code effectué en arrière plan.

    Sub BgExportExcel_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            EtapeStr = "Début de préparation"
            Dim ornd As New Random
            Try
                If IO.Directory.Exists("TMP") Then
                    For Each _file As String In IO.Directory.GetFiles("TMP")
                        IO.File.Delete(_file)
                    Next
                End If
            Catch ex As Exception

            End Try
            If Not IO.Directory.Exists("TMP") Then IO.Directory.CreateDirectory("TMP")
            Dim path As String = ("TMP\temp" & ornd.Next(100, 15000) & ".xlsx")
            Dim tempfile As New IO.FileInfo(path)
            Dim oExcel As New OfficeOpenXml.ExcelPackage(tempfile)

            Dim oWorkbook As OfficeOpenXml.ExcelWorkbook = oExcel.Workbook
            Dim xlws As OfficeOpenXml.ExcelWorksheet = oWorkbook.Worksheets.Add("Requête")
            Dim Col As New ArrayList
            Dim Colformat As New ArrayList
            Dim bn As Integer = 0
            Dim TblSource As System.Data.DataTable = Nothing
            If Not XGrd.DataSource Is Nothing Then
                If XGrd.DataSource.GetType.Name = "DataTable" Then
                    TblSource = XGrd.DataSource
                ElseIf XGrd.DataSource.GetType.Name = "DataView" Then
                    TblSource = CType(XGrd.DataSource, DataView).ToTable
                End If
            End If
            'Filtrer les colonnes visibles uniquement et les format de colonnes de Excel
            For j As Integer = 0 To XGrd.ColumnCount - 1
                If XGrd.Columns(j).Visible Then
                    Col.Add(XGrd.Columns(j).Name)
                    'Stocker les formats de colonnes dans ColFormat
                    If Not TblSource Is Nothing Then
                        If TblSource.Columns.Contains(XGrd.Columns(j).Name) Then
                            If TblSource.Columns(XGrd.Columns(j).Name).DataType.ToString.Contains("Double") Then
                                Colformat.Add("float")
                            ElseIf TblSource.Columns(XGrd.Columns(j).Name).DataType.ToString.Contains("Int") Then
                                Colformat.Add("int")
                            ElseIf TblSource.Columns(XGrd.Columns(j).Name).DataType.ToString.Contains("Date") Then
                                Colformat.Add("date")
                            ElseIf TblSource.Columns(XGrd.Columns(j).Name).DataType.ToString.Contains("Boolean") Then
                                Colformat.Add("Boolean")
                            ElseIf TblSource.Columns(XGrd.Columns(j).Name).DataType.ToString.Contains("Bitmap") Then
                                Colformat.Add("Image")
                            Else
                                Colformat.Add("String")
                            End If
                        Else
                            Colformat.Add("String")
                        End If
                    Else
                        If IsNull(XGrd.Columns(j).Tag, "") = "float" Then
                            Colformat.Add("float")
                        ElseIf IsNull(XGrd.Columns(j).Tag, "") = "int" Then
                            Colformat.Add("int")
                        ElseIf IsNull(XGrd.Columns(j).Tag, "") = "date" Then
                            Colformat.Add("date")
                        ElseIf IsNull(XGrd.Columns(j).Tag, "") = "Boolean" Then
                            Colformat.Add("Boolean")
                        Else
                            Colformat.Add("String")
                        End If
                    End If
                End If
            Next
            '----------------------------------------------
suite:
            bn = 0
            'Ecrire les entêtes
            For j As Integer = 0 To Col.Count - 1
                xlws.Cells(1, bn + 1).Value = XGrd.Columns(Col(j)).HeaderText
                'Dessiner les formats de colonnes sur Excel
                Select Case Colformat(j)
                    Case "float"
                        xlws.Column(j + 1).Style.Numberformat.Format = "#,##0.00"
                    Case ("int")
                        xlws.Column(j + 1).Style.Numberformat.Format = "#,##0"
                    Case "date"
                        xlws.Column(j + 1).Style.Numberformat.Format = "dd/mm/yyyy"
                End Select
                bn += 1
            Next
            '-------------------------------------------
            Dim ColorEnt, ColorLign, ColorEntF As Color
            Dim oStyle As New DataGridViewCellStyle
            ColorEnt = System.Drawing.Color.FromArgb(31, 73, 125)
            'ColorEnt = RGB(232, 232, 254)
            ColorLign = System.Drawing.Color.FromArgb(232, 232, 254)
            ColorEntF = System.Drawing.Color.FromArgb(255, 255, 255)
            'remplir des lignes
            For i = 0 To XGrd.RowCount - 1
                EtapeStr = "Ligne : " & (i + 1) & "/" & XGrd.RowCount
                '  If XGrd.Rows(i).Visible Then
                bn = 0
                For j As Integer = 0 To Col.Count - 1

                    Select Case Colformat(j)
                        Case "float"
                            xlws.Cells(i + 2, bn + 1).Value = CDbl(IIf(Not IsNumeric(XGrd.Item(Col(j), i).Value), 0, XGrd.Item(Col(j), i).Value))
                        Case "int"
                            xlws.Cells(i + 2, bn + 1).Value = CDbl(IIf(Not IsNumeric(XGrd.Item(Col(j), i).Value), 0, XGrd.Item(Col(j), i).Value))
                        Case "date"
                            xlws.Cells(i + 2, bn + 1).Value = XGrd.Item(Col(j), i).Value
                        Case Else
                            xlws.Cells(i + 2, bn + 1).Value = IsNull(XGrd.Item(Col(j), i).Value, "")
                    End Select
                    xlws.Cells(i + 2, bn + 1).Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin)
                    bn += 1

                    oStyle = XGrd.Item(Col(j), i).InheritedStyle
                    With xlws.Cells(xlws.Cells(i + 2, 1).Address & ":" & xlws.Cells(i + 2, Col.Count).Address).Style
                        .Font.Bold = oStyle.Font.Bold
                        .Font.Italic = oStyle.Font.Italic
                        .Font.UnderLine = oStyle.Font.Underline
                        '  .Font.FontStyle = oStyle.Font.FontFamily
                        .Font.Color.SetColor(System.Drawing.Color.FromArgb(oStyle.ForeColor.R, oStyle.ForeColor.G, oStyle.ForeColor.B))
                        .Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                        .Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(oStyle.BackColor.R, oStyle.BackColor.G, oStyle.BackColor.B))
                    End With
                Next
                '   End If
            Next
            EtapeStr = "Mise en forme"
            With xlws.Cells(xlws.Cells(1, 1).Address & ":" & xlws.Cells(1, Col.Count).Address).Style
                .Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                .Fill.BackgroundColor.SetColor(ColorEnt)
                .Font.Bold = True
                .Font.Color.SetColor(ColorEntF)
            End With
            With xlws.Cells(xlws.Cells(1, 1).Address & ":" & xlws.Cells(XGrd.RowCount + 1, Col.Count).Address)
                .Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin)
                .Style.Border.Diagonal.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                .AutoFitColumns()
            End With

            oExcel.Save()
            StartPrograme(tempfile.FullName)
            '----------------------------------------------------------------------




        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    'Quand le code d'arrière plan est terMiné la procédure RunWorkerCompleted est exécutée.

    Sub BgExportExcel_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ' ici, elle affiche un message indiquant de le thread d'arrière plan est terMiné.  
        EtapeStr = "Fin de traitement"
        Zoom_PBar.Close()
    End Sub

    Sub PreparationColonneExcel()
        Dim Tbl As New System.Data.DataTable
        Tbl.Columns.Add("Lettre")
        Tbl.Columns.Add("Rang")
        For i = 65 To 90
            Tbl.Rows.Add(Chr(i), 1)
            For j = 65 To 90
                Tbl.Rows.Add(Chr(i) & Chr(j), 2)
            Next
        Next
        Dim TblV As DataView = Tbl.DefaultView
        TblV.Sort = "Rang,Lettre"
        Tbl = TblV.ToTable
    End Sub
    Function GetColonneExcel(ColIndx As Integer) As String
        If ColIndx <= 702 Then
            Return ColonneExcel.Select("1=1")(ColIndx - 1).Item("Lettre")
        Else
            Return "A"
        End If
    End Function
End Module
