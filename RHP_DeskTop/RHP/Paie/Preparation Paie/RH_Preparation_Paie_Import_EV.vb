Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Imports DevComponents.DotNetBar.Controls
Public Class RH_Preparation_Paie_Import_EV
    Friend WithEvents Grd As New DataGridView
    Friend TblCol As New DataTable
    Dim TblAgent As New DataTable
    Dim oPb As New PictureBox
    Dim PnlWait As New ud_PanelWait
    Dim ConnString As String = ""
    Dim oAvancementStr As String = ""
    Dim NBError As Integer = 0
    Dim frm_RHAgent As New RH_Agent
    Dim TblRub As New DataTable
    Dim dicLbl As New Dictionary(Of String, Label)
    Friend frm_Paie As New RH_Preparation_Paie
    Dim nomsColonnesOrigines As New ArrayList
#Region "Partie Générique"
    Private Sub Zoom_frmGBalanceImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiseEnFormeGrd()
        Request()
        With oPb
            .Size = New Size(12, 7)
            .Image = My.Resources.Selector
            .Visible = False
            Me.Controls.Add(oPb)
        End With
    End Sub
    Sub MiseEnFormeGrd()
        With Grd
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.None
            .ContextMenuStrip = AddContextMenu(False, True, False, False, False, False, True, False)
            .EnableHeadersVisualStyles = False
            Dim omnu, omnu1 As New ToolStripMenuItem
            With omnu
                .Text = "Cette ligne est l'entête de la feuille"
                AddHandler .Click, AddressOf EstEntete
            End With
            With omnu1
                .Text = "Format nombre"
                AddHandler .Click, AddressOf EstNombre
            End With
            Grd.ContextMenuStrip.Items.Insert(0, omnu)
            Grd.ContextMenuStrip.Items.Insert(1, omnu1)
            AddHandler .ColumnHeaderMouseDoubleClick, AddressOf Grd_ColumnHeaderMouseDoubleClick
        End With
    End Sub
    Sub EstEntete()
        With Grd
            If .RowCount = 0 Then Return
            If .SelectedRows.Count = 0 Then
                ShowMessageBox("Veuillez sélectionner la ligne des entêtes")
                Return
            End If
            Dim r As Integer = .SelectedRows(0).Index
            For i = 0 To .ColumnCount - 1
                If IsNull(.Item(i, r).Value, "").Trim = "" Then
                    .Columns(i).HeaderText = "[Colonne " & i + 1 & "]"
                Else
                    .Columns(i).HeaderText = .Item(i, r).Value.trim
                End If
                .Columns(i).Name = .Columns(i).HeaderText
                nomsColonnesOrigines(i) = .Columns(i).HeaderText
            Next
            For i = r To 0 Step -1
                CType(.DataSource, DataTable).Rows.RemoveAt(i)
            Next
        End With
    End Sub
    Sub EstNombre()
        With Grd
            If .RowCount = 0 Then Return
            If .SelectedCells.Count = 0 Then
                ShowMessageBox("Veuillez sélectionner la colonne")
                Return
            End If
            Dim c As Integer = .SelectedCells(0).ColumnIndex
            If TblAgent.Columns(c).DataType.ToString.Contains("Double") Or TblAgent.Columns(c).DataType.ToString.Contains("Decimal") Then
                .Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(c).DefaultCellStyle.Format = "N2"
            End If
        End With
    End Sub
    Sub Initialisation()
        pnlChamps.Controls.Clear()
        dicLbl.Clear()
        With Grd
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.BackColor = Color.AliceBlue
                .Columns(i).Name = nomsColonnesOrigines(i)
                .Columns(i).HeaderText = nomsColonnesOrigines(i)
            Next
        End With
    End Sub
    Sub Request()
        Initialisation()
        PreparationTblCol()
        Dim Color20 As Color = Color.FromArgb(214, 68, 102)
        Dim Color2 As Color = Color.FromArgb(255, 199, 212)
        Dim Color200 As Color = Color.FromArgb(255, 148, 173)
        Dim Color1 As Color = colorBase04
        Dim Color10 As Color = colorBase01
        Dim Color100 As Color = Color.FromArgb(89, 180, 213)
        With TblCol
            For i = 0 To .Rows.Count - 1
                Dim obtn As New Label
                With obtn
                    .BorderStyle = BorderStyle.None
                    .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
                    .ForeColor = IIf(CBool(TblCol.Rows(i).Item("Obligatoire")), Color20, Color10)
                    .Location = New Point(-100, -100)
                    .Name = TblCol.Rows(i).Item("Colonne")
                    .AutoSize = True
                    .MinimumSize = New Size(80, 25)
                    .MaximumSize = New Size(200, 25)
                    .Text = TblCol.Rows(i).Item("Lib_colonne")
                    .Tag = IIf(CBool(TblCol.Rows(i).Item("Obligatoire")), {Color2, Color20, Color200}, {Color1, Color10, Color100})
                    .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    .Cursor = Cursors.Hand
                    SuperTooltip1.SetSuperTooltip(obtn, New DevComponents.DotNetBar.SuperTooltipInfo(TblCol.Rows(i).Item("Colonne"), "", TblCol.Rows(i).Item("Lib_colonne"), Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Lemon))
                    pnlChamps.Controls.Add(obtn)
                    dicLbl.Add(.Name, obtn)
                    AddHandler .MouseUp, AddressOf LblMouseUp
                    AddHandler .MouseMove, AddressOf Lbl_MouseMove
                    AddHandler .MouseDown, AddressOf Lbl_MouseDown
                    AddHandler .Paint, AddressOf LblBordure
                End With
            Next
        End With
        ReorganiserLbl()
    End Sub
    Sub LblBordure(sender As Label, e As PaintEventArgs)

        Dim Color1 As Color = sender.Tag(0)
        Dim Color2 As Color = sender.Tag(1)
        sender.BackColor = Color1
        ControlPaint.DrawBorder(e.Graphics, sender.DisplayRectangle, Color2, ButtonBorderStyle.Solid)
    End Sub
#Region "Excel"
    Private Sub Importer_pb_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Importer_pb.Click
        Try
            AttendreProcess(True)
            If pnlChamps.Controls.Count = 0 Then
                Request()
            Else
                With Grd
                    For Each c In pnlChamps.Controls
                        If TypeOf c Is Label Then
                            c.visible = True
                        End If
                    Next
                End With
            End If
            ExcelSheets_cbo.Items.Clear()
            Grd.Columns.Clear()

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(FindParam("Langue_excel"))
            Dim OpenFileDialog As New OpenFileDialog
            Dim FichierExp As String = ""
            OpenFileDialog.InitialDirectory = importPath
            OpenFileDialog.Filter = "Fichiers Excel (*.xlsx; *.xlsm)|*.xlsx;*.xlsm"

            If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then

                Dim fi As New FileInfo(OpenFileDialog.FileName)
                Dim FileName As String = OpenFileDialog.FileName
                Dim length As Integer = FileName.Split(".").Length
                importPath = System.IO.Path.GetDirectoryName(FileName)
                Me.Extention = FileName.Split(".")(length - 1)
                Try
                    If Extention.ToUpper = "XLS" Then
                        ShowMessageBox("Seuls Excel 2007 et plus et autorisé")
                        AttendreProcess(False)
                        Return
                    ElseIf Extention.ToUpper = "XLSX" Or Extention.ToUpper = "XLSM" Then
                        ConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
                    End If
                Catch ex As Exception
                    ShowMessageBox("Le fichier n'est pas de type Excel")
                    AttendreProcess(False)
                    Exit Sub
                End Try

                Dim oSheet As ArrayList = getExcelSheetsName(FileName)
                If oSheet.Count = 0 Then
                    ShowMessageBox("Le fichier n'est pas de type Excel valide")
                    AttendreProcess(False)
                    Exit Sub
                End If
                ExcelSheets_cbo.Items.Clear()
                For i = 0 To oSheet.Count - 1
                    ExcelSheets_cbo.Items.Add(oSheet(i))
                Next
                ExcelSheets_cbo.SelectedIndex = 0
                ImporterFeuilleExcel()
            Else
                AttendreProcess(False)
            End If
        Catch ex As Exception
            ShowMessageBox(ex.Message)
            AttendreProcess(False)
        End Try
    End Sub
    Private Function getExcelSheetsName(ByVal Excelfilename As String) As ArrayList
        Dim objExcel As OfficeOpenXml.ExcelPackage = New OfficeOpenXml.ExcelPackage(New IO.FileInfo(Excelfilename))


        Dim SheetList As New ArrayList
        For Each objWorkSheets In objExcel.Workbook.Worksheets
            SheetList.Add(objWorkSheets.Name)
        Next

        Return SheetList
    End Function
#End Region
#Region "Drag et Drop"
    Dim P0 As New Point
    Sub Lbl_MouseDown(lbl As Label, e As MouseEventArgs)
        If P0 = Nothing Then
            P0 = New Point(e.X, e.Y)
            lbl.Parent = Me
            lbl.BringToFront()
        End If
    End Sub
    Private Sub Lbl_MouseMove(lbl As Label, e As MouseEventArgs)
        If Grd Is Nothing Then Return
        If Grd.ColumnCount = 0 Then Return
        If e.Button = System.Windows.Forms.MouseButtons.Left And P0 <> Nothing Then
            lbl.Location = New Point(e.X + lbl.Location.X - P0.X, e.Y + lbl.Location.Y - P0.Y)
            Dim Indx As Integer = LaColonneSelectionne(lbl)
            If Indx = -2 Then Return
            With Grd
                Dim Grdpt As Point = PointLocation(Me, Grd, New Point(Grd.Left, Grd.Top))
                Dim Colpt As Point = .GetCellDisplayRectangle(Indx, -1, True).Location
                'ne pas afficher le sélecteur en cas de colonne non affichée entièrement
                If Colpt.X + .Columns(Indx).Width <= .Width Then
                    Dim xX As Integer = Grdpt.X + Colpt.X + .Columns(Indx).Width / 2
                    oPb.BringToFront()
                    oPb.Location = New Point(xX - oPb.Width / 2, Grdpt.Y + 1)
                    oPb.BackColor = .Columns(Indx).HeaderCell.Style.BackColor
                    oPb.Visible = True
                Else
                    oPb.Visible = False
                End If

            End With
        End If
    End Sub
    Private Sub LblMouseUp(ByVal lbl As Label, ByVal e As System.EventArgs)
        Try
            If Grd Is Nothing Then Return
            If Grd.ColumnCount = 0 Then Return
            Dim Indx As Integer = LaColonneSelectionne(lbl)
            oPb.Visible = False
            If Indx = -2 Then
                lbl.Visible = True
                lbl.Parent = pnlChamps
            Else
                With Grd
                    .Columns(Indx).Name = lbl.Name
                    With .Columns(Indx).HeaderCell.Style
                        .BackColor = lbl.Tag(2)
                        .Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With
                    .Columns(Indx).HeaderText = lbl.Text
                    lbl.Visible = False
                End With
            End If
            P0 = Nothing
            ReorganiserLbl()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub ReorganiserLbl()
        Dim sp As Integer = 3
        Dim oX As Integer = sp
        Dim oY As Integer = sp
        For Each lbl As Label In dicLbl.Values
            If lbl.Visible Then
                lbl.Location = New Point(oX, oY)
                If oX + lbl.Width + sp < pnlChamps.Width - 30 Then
                    oX += lbl.Width + sp
                Else
                    oX = sp
                    oY += lbl.Height + sp
                End If
            End If
        Next
    End Sub
    Function LaColonneSelectionne(lbl As Label) As Integer
        Dim grdP As Point = PointLocation(Me, Grd, New Point(Grd.Left, Grd.Top))
        Dim butP As Point = PointLocation(Me, lbl, New Point(lbl.Left, lbl.Top))
        Dim oX As Integer = butP.X + Grd.RowHeadersWidth + CInt(lbl.Width / 2)
        Dim oY As Integer = butP.Y

        Dim gX As Integer = grdP.X + Grd.RowHeadersWidth
        Dim gY As Integer = grdP.Y

        With Grd
            'délimiter au curseur à la zone de Grille
            If oX < gX Or oX > gX + .Width Then Return -2
            If oY < gY Or oY > gY + .Height Then Return -2
            'corriger le curseur par la valeur du scroll
            oX += .HorizontalScrollingOffset
            For i = 0 To .ColumnCount - 1
                If oX > gX And oX < gX + .Columns(i).Width Then
                    Return i
                Else
                    gX = gX + .Columns(i).Width + 1
                End If
            Next
            Return -2
        End With
    End Function
#End Region
    Private Sub Annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualiser_pb.Click
        Request()
    End Sub

    Private Sub New_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles New_pb.Click
        Reset_Form(Me)
    End Sub
    Sub ImporterFeuilleExcel()
        If BKW_ChargerFeuilleExcel.IsBusy Then Return
        If ExcelSheets_cbo.Items.Count = 0 Or ExcelSheets_cbo.SelectedIndex = -1 Then
            ShowMessageBox("Aucune feuille excel sélectionnée.", "Alerte", MessageBoxButtons.OK, msgIcon.Warning)
            AttendreProcess(False)
            Return
        End If
        For Each c In dicLbl.Values
            c.Visible = True
        Next
        If SplitContainer1.Panel2.Controls.Contains(Grd) Then
            SplitContainer1.Panel2.Controls.Remove(Grd)
        End If
        Grd = New DataGridView
        MiseEnFormeGrd()

        AttendreProcess(True)
        strFeuille = ExcelSheets_cbo.SelectedItem
        BKW_ChargerFeuilleExcel.RunWorkerAsync()
        ExcelSheets_cbo.Enabled = False
    End Sub
    Sub AttendreProcess(Debut As Boolean)
        If Debut Then
            Save_pb.Enabled = False
            Importer_pb.Enabled = False
            Actualiser_pb.Enabled = False
            ExcelSheets_cbo.Enabled = False
            oTimer.Start()
            With PnlWait
                SplitContainer1.Panel2.Controls.Add(PnlWait)
                .Visible = True
                .BringToFront()
            End With
        Else
            oTimer.Stop()
            Save_pb.Enabled = True
            Importer_pb.Enabled = True
            Actualiser_pb.Enabled = True
            ExcelSheets_cbo.Enabled = True
            If SplitContainer1.Panel2.Controls.Contains(PnlWait) Then SplitContainer1.Panel2.Controls.Remove(PnlWait)
        End If

    End Sub
    Private Sub Grd_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        With Grd
            If dicLbl.ContainsKey(.Columns(e.ColumnIndex).Name) Then
                dicLbl(.Columns(e.ColumnIndex).Name).Parent = pnlChamps
                dicLbl(.Columns(e.ColumnIndex).Name).Visible = True
                .Columns(e.ColumnIndex).HeaderText = nomsColonnesOrigines(e.ColumnIndex)
                .Columns(e.ColumnIndex).Name = nomsColonnesOrigines(e.ColumnIndex)
                .Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.AliceBlue
            End If
        End With
        ReorganiserLbl()
    End Sub
    Private Sub Close_D_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
    Private Sub Param_Import_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If BKW_Import.IsBusy Then e.Cancel = True
        If BKW_ChargerFeuilleExcel.IsBusy Then e.Cancel = True
    End Sub
    Dim strFeuille As String = ""
    Private Sub BKW_ChargerFeuilleExcel_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKW_ChargerFeuilleExcel.DoWork
        Try
            If ConnString = "" Then
                ShowMessageBox("Erreur chemin excel.", "Alerte", MessageBoxButtons.OK, msgIcon.Warning)
                Return
            End If
            Dim conn As New OleDbConnection(ConnString)
            Dim dta As New OleDbDataAdapter("Select * From [" & strFeuille & "$]", conn)
            Dim dts As New DataSet
            ' System.Threading.Thread.Sleep(1000)
            dta.Fill(dts, "[" & strFeuille & "$]")
            conn.Close()
            TblAgent = dts.Tables(0)
            Dim nbVide As Integer = 0
            With TblAgent
                If .Columns.Count = 0 Or .Rows.Count = 0 Then
                    ShowMessageBox("Votre feuille Excel ne contient pas de données")
                    Exit Sub
                End If
                'supprimer les lignes vides
                For i = .Rows.Count - 1 To 0 Step -1
                    nbVide = 0
                    For Each itm As Object In .Rows(i).ItemArray
                        If IsNull(itm, "").Trim <> "" Then
                            Exit For
                        ElseIf IsNull(itm, "").Trim = "" Then
                            nbVide += 1
                        ElseIf IsNumeric(IsNull(itm, "0").Trim) Then
                            If Math.Round(CDbl(itm), 2) = 0 Then nbVide += 1
                        End If
                    Next
                    If nbVide = .Columns.Count Then TblAgent.Rows.RemoveAt(i)
                Next
                With Grd
                    .DataSource = TblAgent
                End With
            End With
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Private Sub BKW_ChargerFeuilleExcel_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKW_ChargerFeuilleExcel.RunWorkerCompleted
        SplitContainer1.Panel2.Controls.Add(Grd)
        nomsColonnesOrigines.Clear()
        With Grd
            For i = 0 To .ColumnCount - 1
                nomsColonnesOrigines.Add(.Columns(i).Name)
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(i).HeaderCell.Style.BackColor = Color.AliceBlue
            Next
        End With
        AttendreProcess(False)
        ExcelSheets_cbo.Enabled = True
    End Sub
    Private Sub ExcelSheets_DropDownClosed(sender As Object, e As EventArgs) Handles ExcelSheets_cbo.SelectedIndexChanged
        ImporterFeuilleExcel()
    End Sub
    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        With PnlWait
            .CircularProgress1.Value = IIf(.CircularProgress1.Value = 100, 0, .CircularProgress1.Value) + 10
            .lblAvancement.Text = oAvancementStr
            .lblAvancement.Refresh()
        End With
    End Sub
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles Affect_pb.Click
        If Grd.ColumnCount = 0 Then Return
        If FindParam("SetParDefaut") <> "O" Then
            Zoom_Import_Affectation_Champs.ShowDialog()
        Else
            GModeAffectationImport = FindParam("AffectationAuto")
        End If
        AffectationAuto(GModeAffectationImport)
    End Sub
    Sub AffectationAuto(Typ As String)
        If Grd.ColumnCount = 0 Then Return
        If Typ = "N" Then
            Dim nb As Single = 0
            Dim TblMatches As New DataTable
            With TblMatches
                .Columns.Add("Champs")
                .Columns.Add("Colonne")
                .Columns.Add("Similar")
            End With
            For Each c In pnlChamps.Controls
                If TypeOf c Is Label Then
                    If c.visible Then
                        With Grd
                            For i = 0 To .ColumnCount - 1
                                nb = Math.Max(GetSimilarity(c.name.toupper, nomsColonnesOrigines(i).Trim.ToUpper), GetSimilarity(c.text.toupper, nomsColonnesOrigines(i).Trim.ToUpper))
                                If nb > 0.4 Then
                                    TblMatches.Rows.Add(c.name, nomsColonnesOrigines(i), nb)
                                End If
                            Next
                        End With
                    End If
                End If
            Next
            Dim nrw() As DataRow = Nothing
            With Grd
                For i = 0 To .ColumnCount - 1
                    nrw = TblMatches.Select("[Colonne]='" & IsNull(nomsColonnesOrigines(i), "").Replace("'", "''") & "'", "Colonne Asc, Similar Desc")
                    If nrw.Length > 0 Then
                        For Each c In pnlChamps.Controls
                            If TypeOf c Is Label Then
                                If c.name = nrw(0).Item("Champs") Then
                                    .Columns(i).HeaderCell.Style.BackColor = CType(c, Label).Tag(2)
                                    .Columns(i).HeaderText = CType(c, Label).Text
                                    .Columns(i).Name = CType(c, Label).Name
                                    c.visible = False
                                    Exit For
                                End If
                            End If

                        Next
                    End If
                Next
            End With
        ElseIf Typ = "O" Then
            Dim i As Integer = -1
            For Each c In pnlChamps.Controls
                i = pnlChamps.Controls.IndexOf(c)
                With Grd
                    If i < .ColumnCount Then
                        .Columns(i).HeaderCell.Style.BackColor = CType(c, Label).Tag(2)
                        .Columns(i).HeaderText = CType(c, Label).Text
                        .Columns(i).Name = CType(c, Label).Name
                        c.visible = False
                    End If
                End With
            Next
        End If

    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles Modele_pb.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim ornd As New Random
            Dim nbCol As Integer = 0
            Dim nbLig As Integer = 51
            Dim ColorEnt, ColorEntF As Color
            ColorEntF = System.Drawing.Color.FromArgb(255, 255, 255)
            ColorEnt = System.Drawing.Color.FromArgb(31, 73, 125)
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
            Dim xlws As OfficeOpenXml.ExcelWorksheet = oWorkbook.Worksheets.Add("RH_Agent")
            For Each c In pnlChamps.Controls
                If TypeOf c Is Label Then
                    nbCol += 1
                    For i = 1 To nbLig
                        If i = 1 Then
                            xlws.Cells(i, nbCol).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                            xlws.Cells(i, nbCol).Style.Fill.BackgroundColor.SetColor(CType(c, Label).BackColor)
                            xlws.Cells(i, nbCol).Value = CType(c, Label).Text
                        End If
                        xlws.Cells(i, nbCol).Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin)
                    Next
                End If
            Next

            With xlws.Cells(xlws.Cells(1, 1).Address & ":" & xlws.Cells(1, nbCol).Address)
                .Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid

                .Style.Font.Bold = True
                .Style.Font.Color.SetColor(ColorEntF)
            End With
            With xlws.Cells(xlws.Cells(1, 1).Address & ":" & xlws.Cells(nbLig, nbCol).Address)
                .Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin)
                .Style.Border.Diagonal.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                .AutoFitColumns()
            End With

            '----------------------------------------------------------------------
            Cursor = Cursors.Default

            oExcel.Save()
            StartPrograme(tempfile.FullName)
        Catch ex As Exception
            Cursor = Cursors.Default
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Importer()
    End Sub
#End Region
    Sub PreparationTblCol()
        TblCol.Rows.Clear()
        With TblCol.Columns
            .Clear()
            .Add("Colonne")
            .Add("Lib_colonne")
            .Add("Type_Data")
            .Add("Valeur_Default")
            .Add("Obligatoire")
            .Add("Cle")
        End With
        Dim C1, C2, C3, C4, C5, C6 As Object
        Dim nRw() As DataRow
        With frm_Paie.PrePaie_Grd
            For i = 0 To .ColumnCount - 1
                If IsNull(.Columns(i).Tag, "") = "EV" Then
                    nRw = frm_Paie.PrePaie.TblFunction.Select("Cod_Function='" & .Columns(i).Name & "'")
                    If nRw.Length > 0 Then
                        C1 = .Columns(i).Name
                        C2 = .Columns(i).HeaderText.Replace(Chr(13), " ").Replace(Chr(10), " ")
                        C3 = IsNull(nRw(0)("Typ_Retour"), "float")
                        C4 = IsNull(nRw(0)("Formule_Function"), 0)
                        C5 = False
                        C6 = False
                        TblCol.Rows.Add(C1, C2, C3, C4, C5, C6)
                    End If
                ElseIf .Columns(i).Name = "Matricule" Then
                    C1 = .Columns(i).Name
                    C2 = .Columns(i).HeaderText
                    C3 = "nvarchar(50)"
                    C4 = ""
                    C5 = True
                    C6 = True
                    TblCol.Rows.Add(C1, C2, C3, C4, C5, C6)
                End If
            Next
        End With

    End Sub
    Sub Importer()
        NBError = 0
        If BKW_Import.IsBusy Then
            ShowMessageBox("Une opération d'import est encours, merci de patienter")
            Return
        End If
        AttendreProcess(True)
        BKW_Import.RunWorkerAsync()
        frm_Paie.PrePaie.CalculAuto = False
    End Sub

    Private Sub BKW_Import_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKW_Import.DoWork
        If Grd.RowCount = 0 Then Return
        Dim ColName As String = ""
        Dim EVSel As New ArrayList
        '   Dim TabContientPeriode As Integer = CnExecuting("Select count(*) from INFORMATION_SCHEMA.COLUMNS where COLUMN_NAME='Periode' and TABLE_NAME='" & oTableName & "'").Fields(0).Value
        '    Dim TabContientSociete As Integer = CnExecuting("Select count(*) from INFORMATION_SCHEMA.COLUMNS where COLUMN_NAME='id_Societe' and TABLE_NAME='" & oTableName & "'").Fields(0).Value
        oAvancementStr = "Début de traitement"
        If EstCloturee = "C" Then
            ShowMessageBox("Période clôturée")
            NBError = 1
            Exit Sub
        End If

        Dim orw() As DataRow = TblCol.Select("[Obligatoire]='True'")
        Dim nb As Integer = 0
        Dim oTyp As String = ""
        For i = 0 To orw.Length - 1
            If Grd.Columns.Contains(orw(i).Item("Colonne")) And Not dicLbl(orw(i).Item("Colonne")).Visible Then nb += 1
        Next
        If nb < orw.Length Then
            ShowMessageBox("Vous n'avez pas affecté tous les champs obligatoires")
            NBError = 1
            Exit Sub
        End If

        With Grd
            nb = 0
            oAvancementStr = "Contrôle des données d'importation"
            'contrôle de type de donnée
            For j = 0 To .ColumnCount - 1
                ColName = .Columns(j).Name.Replace("'", "''")
                If dicLbl.ContainsKey(ColName) Then
                    If Not dicLbl(ColName).Visible Then
                        If ColName <> "Matricule" Then
                            EVSel.Add(ColName)
                        End If
                        orw = TblCol.Select("Colonne='" & ColName & "'")
                        oTyp = orw(0).Item("Type_Data")
                        For i = 0 To .RowCount - 2
                            oAvancementStr = "Contrôle des données d'importation, colonne : " & .Columns(j).HeaderText & ", ligne : " & i
                            Select Case oTyp
                                Case "datetime", "smalldatetime"
                                    If IsNull(.Item(j, i).Value, "") <> "" Then
                                        If Not IsDate(.Item(j, i).Value) Then
                                            nb = 1
                                            ShowMessageBox("La colonne [" & .Columns(j).HeaderText & "] doit être de type 'Date'")
                                            .Item(j, i).Style.ForeColor = Color.Red
                                            NBError = 1
                                            Exit Sub
                                        Else
                                            .Item(j, i).Value = CDate(.Item(j, i).Value)
                                        End If
                                    End If
                                Case "float"
                                    If IsNull(.Item(j, i).Value, "") <> "" Then
                                        If Not IsNumeric(.Item(j, i).Value) Then
                                            ShowMessageBox("La colonne [" & .Columns(j).HeaderText & "] doit être de type 'Numérique'")
                                            .Item(j, i).Style.ForeColor = Color.Red
                                            NBError = 1
                                            Exit Sub
                                        End If
                                    End If
                                Case "int", "smallint"
                                    If IsNull(.Item(j, i).Value, "") <> "" Then
                                        If IsNumeric(.Item(j, i).Value) Then
                                            If Math.Ceiling(CDbl(.Item(j, i).Value)) < CDbl(.Item(j, i).Value) Then
                                                ShowMessageBox("La colonne [" & .Columns(j).HeaderText & "] doit être de type 'Entier'")
                                                NBError = 1
                                                .Item(j, i).Style.ForeColor = Color.Red
                                                Exit Sub
                                            End If
                                        Else
                                            ShowMessageBox("La colonne [" & .Columns(j).HeaderText & "] doit être de type 'Entier'")
                                            .Item(j, i).Style.ForeColor = Color.Red
                                            '  .FirstDisplayedScrollingRowIndex = i
                                            NBError = 1
                                            Exit Sub
                                        End If
                                    End If
                            End Select
                        Next
                    End If
                End If
            Next
            oAvancementStr = "Vérification des doublons"
            'Vérification des doublons
            orw = TblCol.Select("[Cle]='True'")
            Dim owhere As String = ""
            Dim arg As New ArrayList
            Dim argVal As New ArrayList
            If orw.Length > 0 Then
                For i = 0 To orw.Length - 1
                    With Grd
                        For j = 0 To .RowCount - 2
                            For k = j + 1 To .RowCount - 1
                                oAvancementStr = "Vérification des doublons, colonne:" & .Columns(orw(i).Item("Colonne")).headertext & ", ligne :" & k
                                If IsNull(.Item(orw(i).Item("Colonne"), j).value, "") = IsNull(.Item(orw(i).Item("Colonne"), k).value, "") Then
                                    .Item(orw(i).Item("Colonne"), j).Selected = True
                                    .Item(orw(i).Item("Colonne"), k).Selected = True
                                    ShowMessageBox("Doublons intérdits pour la colonne  : " & .Columns(orw(i).Item("Colonne")).HeaderText & ", lignes " & j + 1 & " et " & k + 1)
                                    NBError = 1
                                    Exit Sub
                                End If
                            Next
                        Next
                    End With
                    owhere &= " and " & orw(i).Item("Colonne") & "='{" & i & "}' "
                    arg.Add(.Columns(orw(i).Item("Colonne")).index)
                Next
            End If
            oAvancementStr = "Enregistrements dans la Base de données"
            'Début d'Exportation
            Dim strRsl As String = ""
            Dim nRow() As DataRow = Nothing
            Dim oMatricule As String = ""
            For i = 0 To .RowCount - 2
                oMatricule = .Item("Matricule", i).Value
                nRow = frm_Paie.PrePaie.TblPrePaie.Select("Matricule='" & oMatricule & "'")
                If nRow.Length > 0 Then
                    For c = 0 To EVSel.Count - 1
                        nRow(0)(EVSel(c)) = IsNull(.Item(EVSel(c), i).value, 0)
                    Next
                End If
                oAvancementStr = "Ligne : " & (i + 1) & "/" & .RowCount
            Next
        End With
        With frm_Paie.PrePaie_Grd
            frm_Paie.PrePaie.CalculAuto = True
            For i = 0 To .RowCount - 1
                frm_Paie.PrePaie.CalculPaie(.Item("Matricule", i).Value, False)
                oAvancementStr = "Recalcul de la ligne : " & (i + 1) & "/" & .RowCount
            Next
        End With

    End Sub
    Sub AffectationEB(Colonne As String, NumLig As Integer)
        Dim nrw() As DataRow = TblCol.Select("Colonne='" & Colonne & "' and Table_Name='RH_Agent_Element_Paie'")
        If Grd.Columns.Contains(Colonne) And nrw.Length > 0 Then
            Dim TypRetour As String = IsNull(nrw(0)("Type_Data"), "float")
            Dim ValDefaut As String = IsNull(nrw(0)("Valeur_Default"), "0")
            Dim intitule As String = IsNull(nrw(0)("Lib_colonne"), Colonne)
            Select Case TypRetour.ToUpper
                Case "INT", "FLOAT"
                    ValDefaut = 0
                Case "BIT"
                    ValDefaut = False
                Case Else
                    ValDefaut = ""
            End Select

            frm_RHAgent.EB_Grd.Rows.Add(Colonne, intitule, TypRetour, IsNull(Grd.Item(Colonne, NumLig).Value, ValDefaut))

        End If
    End Sub
    Sub AffectationChamps(Colonne As String, NumLig As Integer)
        If Grd.Columns.Contains(Colonne) Then
            Dim leChampsStr As String = TblCol.Select("Colonne='" & Colonne & "'")(0)("Champs")
            Dim leChamps As Object = frm_RHAgent.Controls.Find(leChampsStr, True)(0)
            Dim ValDefaut As Object
            Select Case TblCol.Select("Colonne='" & Colonne & "'")(0)("Type_Data").ToString.ToUpper
                Case "INT", "FLOAT"
                    ValDefaut = 0
                Case "BIT"
                    ValDefaut = False
                Case Else
                    ValDefaut = ""
            End Select
            Select Case TblCol.Select("Colonne='" & Colonne & "'")(0)("Affect").ToString.ToUpper
                Case "CHECKED"
                    leChamps.Checked = IsNull(Grd.Item(Colonne, NumLig).Value, ValDefaut)
                Case "SELECTEDVALUE"
                    leChamps.SelectedValue = IsNull(Grd.Item(Colonne, NumLig).Value, ValDefaut)
                Case "VALUE"
                    leChamps.Value = IsNull(Grd.Item(Colonne, NumLig).Value, ValDefaut)
                Case Else
                    leChamps.text = IsNull(Grd.Item(Colonne, NumLig).Value, ValDefaut)
            End Select
        End If
    End Sub
    Private Sub GetResultat(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
        Dim bcx As DataGridViewLabelXColumn = TryCast(sender, DataGridViewLabelXColumn)
        If bcx IsNot Nothing Then
            If bcx.Text.Split("|")(0).Contains("-1") Then
                bcx.Image = My.Resources.erreur
                bcx.Text = "<font color=""red"">" & bcx.Text.Split("|")(1) & "</font>"
            ElseIf bcx.Text.Split("|")(0).Contains("0") Then
                bcx.Image = My.Resources.info
                bcx.Text = "<font color=""orange"">" & bcx.Text.Split("|")(1) & "</font>"
            ElseIf bcx.Text.Split("|")(0).Contains("1") Then
                bcx.Image = My.Resources.success
                bcx.Text = bcx.Text.Split("|")(1)
            Else
                bcx.Image = Nothing
                bcx.Text = ""
            End If
        End If
    End Sub
    Private Sub BKW_Import_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKW_Import.RunWorkerCompleted
        If NBError > 0 Then
            AttendreProcess(False)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ActualiserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualiserToolStripMenuItem.Click
        ReorganiserLbl()
    End Sub
End Class