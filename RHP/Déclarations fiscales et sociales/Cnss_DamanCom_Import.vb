Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO

Public Class Cnss_DamanCom_Import
    Friend Annee As Integer = Now.Year
    Friend oPeriode As Integer = 1
    Friend frm As New Cnss_DamanCom
    Friend WithEvents Grd As New ud_Grd
    Dim oPoint As New ArrayList
    Friend oChamps As New ArrayList
    Friend TblCol As DataTable
    Dim TblBalance As New DataTable
    Dim objExcel As OfficeOpenXml.ExcelPackage
    Dim lblcdr As New Label
    Dim MouseOn As Boolean = True
    Dim oPb As New PictureBox
    Dim PnlWait As New ud_PanelWait
    Dim Save_D As ud_btn
    Dim Request_D As ud_btn
    Dim Import_D As ud_btn
    Dim New_D As ud_btn
    Dim Matches_D As ud_btn
    Dim Export_D As ud_btn

    Private Sub Zoom_frmGBalanceImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Request_D = dictButtons("Request_D")
        Import_D = dictButtons("Import_D")
        New_D = dictButtons("New_D")
        Matches_D = dictButtons("Matches_D")
        Export_D = dictButtons("Export_D")
        Combo_oModeleImport.FromSQL("select  Table_Name, Lib_Modele from  Param_ModeleImportation where Table_Name like 'Damancom_%' group by Table_Name, Lib_Modele order by Table_Name desc")
        Combo_oModeleImport.SelectedValue = "Damancom_Permanent"
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
                CType(.DataSource, DataTable).Columns(.Columns(i).Name).ColumnName = .Columns(i).HeaderText
                .Columns(i).Name = .Columns(i).HeaderText
                .Columns(i).Tag = .Columns(i).HeaderText
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
            If TblBalance.Columns(c).DataType.ToString.Contains("Double") Or TblBalance.Columns(c).DataType.ToString.Contains("Decimal") Then
                .Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(c).DefaultCellStyle.Format = "N2"
            End If
        End With
    End Sub
    Sub Initialisation()
        pnlChamps.Controls.Clear()
        oPoint.Clear()
        oChamps.Clear()
        With Grd
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.BackColor = Color.AliceBlue
                .Columns(i).Name = i
                .Columns(i).HeaderText = .Columns(i).Tag(0)
                .Columns(i).Tag(1) = ""
            Next
        End With
    End Sub
    Sub Request()

        Initialisation()

        TblCol = DATA_READER_GRD("select * from Param_ModeleImportation where Table_Name='" & Combo_oModeleImport.SelectedValue & "' order by Rang")

        Dim oX As Integer = 20
        Dim oY As Integer = 96
        Dim oTTip As New System.Windows.Forms.ToolTip
        With TblCol
            For i = 0 To .Rows.Count - 1
                Dim obtn As New Label
                With obtn
                    .BackColor = IIf(TblCol.Rows(i).Item("Obligatoire") = True, Color.FromArgb(128, 128, 255), Color.FromArgb(192, 192, 255))
                    .BorderStyle = BorderStyle.Fixed3D
                    .Font = New Font("Century Gothic", 9.0!, FontStyle.Bold, GraphicsUnit.Point, 0)
                    .ForeColor = Color.White
                    .Location = New Point(oX, oY)
                    .Name = TblCol.Rows(i).Item("Colonne")
                    .Size = New Size(200, 25)
                    .Text = TblCol.Rows(i).Item("Lib_colonne")
                    .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    .AutoSize = False
                    oTTip.SetToolTip(obtn, TblCol.Rows(i).Item("Lib_colonne"))
                    pnlChamps.Controls.Add(obtn)
                    oPoint.Add(.Location)
                    AddHandler .MouseLeave, AddressOf Lbl_MouseLeave
                    AddHandler .MouseMove, AddressOf Lbl_MouseMove
                    oY += obtn.Height + 2
                End With
                oChamps.Add(obtn)
            Next
        End With
        AddEvent(pnlChamps)
    End Sub
    Dim ConnString As String = ""
    Dim conn As OleDbConnection
    Dim dta As OleDbDataAdapter
    Dim dts As DataSet
    Sub btExplorer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Importer_btn.Click
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
            ExcelSheets.Items.Clear()
            Grd.Columns.Clear()
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(FindParam("Langue_excel"))
            Dim OpenFileDialog As New OpenFileDialog
            Dim FichierExp As String = ""
            OpenFileDialog.InitialDirectory = importPath
            OpenFileDialog.Filter = "Fichiers Excel (*.xlsx)|*.xlsx|Fichiers XLS (*.xls)|*xls"

            If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then

                Dim fi As New FileInfo(OpenFileDialog.FileName)
                Dim FileName As String = OpenFileDialog.FileName
                txtFichier.Text = fi.FullName
                Dim length As Integer = FileName.Split(".").Length
                importPath = System.IO.Path.GetDirectoryName(FileName)
                Dim Extention As String = FileName.Split(".")(length - 1)
                Try
                    If Extention.ToUpper = "XLS" Then
                        ShowMessageBox("Seuls Excel 2007 et plus et autorisé")
                        AttendreProcess(False)
                        Return
                    ElseIf Extention.ToUpper = "XLSX" Then
                        ConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & txtFichier.Text & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
                    End If
                Catch ex As Exception
                    ShowMessageBox("Le fichier n'est pas de type Excel")
                    AttendreProcess(False)
                    Exit Sub
                End Try
                Dim oSheet As ArrayList = getExcelSheetsName(txtFichier.Text)
                If oSheet.Count = 0 Then
                    ShowMessageBox("Le fichier n'est pas de type Excel valide")
                    AttendreProcess(False)
                    Exit Sub
                End If
                ExcelSheets.Items.Clear()
                For i = 0 To oSheet.Count - 1
                    ExcelSheets.Items.Add(oSheet(i))
                Next
                ExcelSheets.SelectedIndex = 0
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

    Private Sub Lbl_MouseMove(lbl As Object, e As MouseEventArgs)
        If Module_DragDrop.obtn0 IsNot lbl Then Return
        Dim Indx As Integer = LaColonneSelectionne(lbl)
        If Indx = -2 Then Return
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
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
    Private Sub Lbl_MouseLeave(ByVal lbl As Label, ByVal e As System.EventArgs)
        If Module_DragDrop.obtn0 IsNot lbl Then Return
        Dim Indx As Integer = LaColonneSelectionne(lbl)
        If Indx = -2 Then Return
        oPb.Visible = False
        With Grd
            If .Columns(Indx).HeaderCell.Style.BackColor <> Color.AliceBlue Then
                For Each c In pnlChamps.Controls
                    If TypeOf c Is Label Then
                        If c.name = .Columns(Indx).Name Then
                            c.visible = True
                            Exit For
                        End If
                    End If
                Next
            End If
            .Columns(Indx).Name = lbl.Name
            .Columns(Indx).Tag(1) = "X"
            With .Columns(Indx).HeaderCell.Style
                .BackColor = lbl.BackColor
                .Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
            .Columns(Indx).HeaderText = lbl.Text
            lbl.Visible = False
            lbl.Location = Module_DragDrop.oPointDepart(Module_DragDrop.oChamps.IndexOf(lbl))
        End With

    End Sub
    Function LaColonneSelectionne(lbl As Label) As Integer
        If Module_DragDrop.obtn0 IsNot lbl Then Return -2
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

    Sub Importer()
        If Grd.RowCount = 0 Then Return

        If (Combo_oModeleImport.SelectedValue = "Damancom_Permanent" And frm.Grd_Permanent.RowCount > 1 And EstDate(frm.Dat_Import_Permanent_txt.Text)) Then
            If ShowMessageBox("Votre déclaration contient déjà des enregistrements relatifs aux personnels permanents" & vbCrLf _
                              & "Si vous continuez vous perdez les infomations renseignées", "Import Personnel Permanent", MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Return
        End If
        If (Combo_oModeleImport.SelectedValue = "Damancom_Entrant" And frm.Grd_Entrants.RowCount > 1 And EstDate(frm.Dat_Import_Entrant_txt.Text)) Then
            If ShowMessageBox("Votre déclaration contient déjà des enregistrements relatifs aux nouveaux entrants" & vbCrLf _
                              & "Si vous continuez vous perdez les infomations renseignées", "Import Nouveaux Entrants", MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Return
        End If
        Dim orw() As DataRow = TblCol.Select("[Obligatoire]='True'")
        Dim nb As Integer = 0
        Dim oTyp As String = ""
        For i = 0 To orw.Length - 1
            If Grd.Columns.Contains(orw(i).Item("Colonne")) Then nb += 1
        Next
        If nb < orw.Length Then
            ShowMessageBox("Vous n'avez pas affecté tous les champs obligatoires")
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor

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
                            If IsNull(.Item(orw(i).Item("Colonne"), j).value, "") = IsNull(.Item(orw(i).Item("Colonne"), k).value, "") Then
                                .Item(orw(i).Item("Colonne"), j).Selected = True
                                .Item(orw(i).Item("Colonne"), k).Selected = True
                                ShowMessageBox("Doublons intérdits pour la colonne  : " & .Columns(orw(i).Item("Colonne")).HeaderText & ", lignes " & j + 1 & " et " & k + 1)
                                Exit Sub
                            End If
                        Next
                    Next
                End With
            Next
        End If

        Dim TblSituation As DataTable = DATA_READER_GRD("select Cod_Situation  from Param_DamanCom_Situation")
        Dim nrw() As DataRow = Nothing
        With Grd
            For i = 0 To .RowCount - 2
                .Rows(i).Selected = False
                For j = 0 To TblCol.Rows.Count - 1
                    If Grd.Columns.Contains(TblCol.Rows(j).Item("Colonne")) Then
                        Select Case TblCol.Rows(j).Item("Type_Data")
                            Case "bigint", "int", "float"
                                If Not IsNumeric(.Item(TblCol.Rows(j).Item("Colonne"), i).value) Then
                                    ShowMessageBox("Erreur format :[" & TblCol.Rows(j).Item("Type_Data") & "], Colonne : " & TblCol.Rows(j).Item("Lib_Colonne") & ", ligne : " & i + 1)
                                    Cursor = Cursors.Default
                                    .Rows(i).Selected = True
                                    .FirstDisplayedScrollingRowIndex = i
                                    Return
                                End If
                            Case "nvarchar"
                                If IsNull(.Item(TblCol.Rows(j).Item("Colonne"), i).value, "").Trim = "" And CBool(IsNull(TblCol.Rows(j).Item("Obligatoire"), False)) = True Then
                                    ShowMessageBox("La Colonne : " & TblCol.Rows(j).Item("Lib_Colonne") & " est obligatoire mais non renseignée, ligne : " & i + 1)
                                    Cursor = Cursors.Default
                                    .Rows(i).Selected = True
                                    .FirstDisplayedScrollingRowIndex = i
                                    Return
                                ElseIf IsNull(.Item(TblCol.Rows(j).Item("Colonne"), i).value, "").Trim.Length > CInt(IsNull(TblCol.Rows(j).Item("Taille"), 0)) Then
                                    ShowMessageBox("La taille de la Colonne : " & TblCol.Rows(j).Item("Lib_Colonne") & " doit être inférieure à " & CInt(IsNull(TblCol.Rows(j).Item("Taille"), 0)) & ", ligne : " & i + 1)
                                    Cursor = Cursors.Default
                                    .Rows(i).Selected = True
                                    .FirstDisplayedScrollingRowIndex = i
                                    Return
                                End If
                        End Select
                    End If
                Next
                If Combo_oModeleImport.SelectedValue = "Damancom_Permanent" Then
                    If .Columns.Contains("Situation") Then
                        If TblSituation.Select("[Cod_Situation]='" & IsNull(.Item("Situation", i).Value, "").Trim & "'").Length = 0 Then
                            ShowMessageBox("Erreur : La Situation : [" & IsNull(.Item("Situation", i).Value, "").Trim & "] n'est pas précréée")
                            Cursor = Cursors.Default
                            .Rows(i).Selected = True
                            .FirstDisplayedScrollingRowIndex = i
                            Return
                        End If
                    End If
                End If
            Next
            Dim k As Integer = -1
            If Combo_oModeleImport.SelectedValue = "Damancom_Permanent" Then
                For i = 0 To frm.Grd_Permanent.RowCount - 1
                    frm.Grd_Permanent.Item(frm.N_Enfants.Index, i).Value = 0
                    frm.Grd_Permanent.Item(frm.AF_A_Payer.Index, i).Value = 0
                    frm.Grd_Permanent.Item(frm.AF_A_Deduire.Index, i).Value = 0
                    frm.Grd_Permanent.Item(frm.AF_A_Reverser.Index, i).Value = 0
                    frm.Grd_Permanent.Item(frm.Jours_Declares.Index, i).Value = 0
                    frm.Grd_Permanent.Item(frm.Salaire_Reel.Index, i).Value = 0
                    frm.Grd_Permanent.Item(frm.Salaire_Plaf.Index, i).Value = 0
                    frm.Grd_Permanent.Item(frm.Situation.Index, i).Value = ""
                    frm.Grd_Permanent.Item(frm.ImportData.Index, i).Value = False
                Next
                frm.Dat_Import_Permanent_txt.Text = ""
                For i = 0 To .RowCount - 2
                    k = -1
                    For j = 0 To frm.Grd_Permanent.RowCount - 1
                        If CStr(.Item("Num_Assure", i).Value) = frm.Grd_Permanent.Item(frm.Num_Assure.Index, j).Value Then
                            k = j
                            Exit For
                        End If
                    Next
                    If k >= 0 Then
                        frm.Grd_Permanent.Item(frm.N_Enfants.Index, k).Value = IsNull(.Item("N_Enfants", i).Value, 0)
                        frm.Grd_Permanent.Item(frm.AF_A_Payer.Index, k).Value = IsNull(.Item("AF_A_Payer", i).Value, 0)
                        frm.Grd_Permanent.Item(frm.AF_A_Deduire.Index, k).Value = IsNull(.Item("AF_A_Deduire", i).Value, 0)
                        frm.Grd_Permanent.Item(frm.AF_A_Reverser.Index, k).Value = IsNull(.Item("AF_A_Reverser", i).Value, 0)
                        frm.Grd_Permanent.Item(frm.Jours_Declares.Index, k).Value = IsNull(.Item("Jours_Declares", i).Value, 0)
                        frm.Grd_Permanent.Item(frm.Salaire_Reel.Index, k).Value = IsNull(.Item("Salaire_Reel", i).Value, 0)
                        frm.Grd_Permanent.Item(frm.Salaire_Plaf.Index, k).Value = IsNull(.Item("Salaire_Plaf", i).Value, 0)
                        If .Columns.Contains("Situation") Then
                            frm.Grd_Permanent.Item(frm.Situation.Index, k).Value = IsNull(.Item("Situation", i).Value, "")
                        End If
                        frm.Grd_Permanent.Item(frm.ImportData.Index, k).Value = True
                    End If
                Next
                frm.Dat_Import_Permanent_txt.Text = Now
            ElseIf Combo_oModeleImport.SelectedValue = "Damancom_Entrant" Then
                frm.Grd_Entrants.Rows.Clear()
                Dim C2, C3, C4, C5, C6, C7, C8 As Object
                For i = 0 To .RowCount - 2
                    C2 = CStr(.Item("Num_Assure", i).Value)
                    C3 = .Item("Nom", i).Value
                    C4 = .Item("Prenom", i).Value
                    C5 = .Item("CIN", i).Value
                    C6 = FormatNumber(IsNull(.Item("Jours_Declares", i).Value, 0), 2)
                    C7 = FormatNumber(IsNull(.Item("Salaire_Reel", i).Value, 0), 2)
                    C8 = FormatNumber(IsNull(.Item("Salaire_Plaf", i).Value, 0))
                    frm.Grd_Entrants.Rows.Add(C2, C3, C4, C5, C6, C7, C8)
                Next
                frm.Dat_Import_Entrant_txt.Text = Now
            End If

        End With
        Me.Close()
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
    End Sub
    Sub Saving()
        If BKW_Import.IsBusy Then
            ShowMessageBox("Une opération d'import est encours, merci de patienter")
            Return
        End If
        Importer()
    End Sub
    Sub ImporterFeuilleExcel()
        If ExcelSheets.Items.Count = 0 Or ExcelSheets.SelectedIndex = -1 Then
            ShowMessageBox("Aucune feuille excel sélectionnée.", "Alerte", MessageBoxButtons.OK, msgIcon.Warning)
            AttendreProcess(False)
            Return
        End If
        If BKW_Import.IsBusy Then Return
        If ud_Pnl.Controls.Contains(Grd) Then
            ud_Pnl.Controls.Remove(Grd)
        End If
        Grd = New DataGridView
        MiseEnFormeGrd()

        AttendreProcess(True)
        strFeuille = ExcelSheets.SelectedItem
        BKW_Import.RunWorkerAsync()
    End Sub
    Sub AttendreProcess(Debut As Boolean)
        If Debut Then
            Cursor = Cursors.WaitCursor
            Save_D.Enabled = False
            Importer_btn.Enabled = False
            Import_D.Enabled = False
            Request_D.Enabled = False
            ExcelSheets.Enabled = False
            oTimer.Start()
            With PnlWait
                ud_Pnl.Controls.Add(PnlWait)
                .Visible = True
                .BringToFront()
            End With
        Else
            Cursor = Cursors.Default
            oTimer.Stop()
            Save_D.Enabled = True
            Importer_btn.Enabled = True
            Import_D.Enabled = True
            Request_D.Enabled = True
            ExcelSheets.Enabled = True
            If ud_Pnl.Controls.Contains(PnlWait) Then ud_Pnl.Controls.Remove(PnlWait)
        End If
    End Sub
    Dim strFeuille As String = ""
    Private Sub BKW_Import_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKW_Import.DoWork
        Try
            If ConnString = "" Then
                ShowMessageBox("Erreur chemin excel.", "Alerte", MessageBoxButtons.OK, msgIcon.Warning)
                Return
            End If

            conn = New OleDbConnection(ConnString)
            dta = New OleDbDataAdapter("Select * From [" & strFeuille & "$]", conn)
            dts = New DataSet
            System.Threading.Thread.Sleep(1000)
            dta.Fill(dts, "[" & strFeuille & "$]")
            conn.Close()
            TblBalance = dts.Tables(0)
            Dim nbVide As Integer = 0
            With TblBalance
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
                    If nbVide = .Columns.Count Then TblBalance.Rows.RemoveAt(i)
                Next
                'supprimer les colonnes vides
                For i = .Columns.Count - 1 To 0 Step -1
                    nbVide = 0
                    For j = 0 To .Rows.Count - 1
                        If IsNull(.Rows(j).Item(i), "").Trim <> "" Then
                            Exit For
                        ElseIf IsNull(.Rows(j).Item(i), "").Trim = "" Then
                            nbVide += 1
                        ElseIf IsNumeric(IsNull(.Rows(j).Item(i), "0").Trim) Then
                            If Math.Round(CDbl(.Rows(j).Item(i)), 2) = 0 Then nbVide += 1
                        End If
                    Next
                    If nbVide = .Rows.Count Then
                        TblBalance.Columns.RemoveAt(i)
                    Else
                        Exit For
                    End If
                Next
                With Grd
                    .DataSource = TblBalance
                End With
            End With
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub BKW_Import_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKW_Import.RunWorkerCompleted
        ud_Pnl.Controls.Add(Grd)
        With Grd
            For i = 0 To .ColumnCount - 1
                .Columns(i).Tag = { .Columns(i).Name, ""}
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(i).HeaderCell.Style.BackColor = Color.AliceBlue
            Next
        End With
        AttendreProcess(False)
    End Sub
    Private Sub ExcelSheets_DropDownClosed(sender As Object, e As EventArgs) Handles ExcelSheets.DropDownClosed
        ImporterFeuilleExcel()
    End Sub
    Private Sub Grd_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        With Grd
            For Each c In pnlChamps.Controls
                If TypeOf c Is Label Then
                    If c.text = .Columns(e.ColumnIndex).HeaderText Then
                        c.visible = True
                        .Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.AliceBlue
                        .Columns(e.ColumnIndex).HeaderText = Grd.Columns(e.ColumnIndex).Tag(0)
                        Grd.Columns(e.ColumnIndex).Tag(1) = ""
                        Exit For
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub Close_D_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub Tiers_Chk_CheckedChanged(sender As Object, e As EventArgs)
        Request()
    End Sub
    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        With PnlWait
            .CircularProgress1.Value = IIf(.CircularProgress1.Value = 100, 0, .CircularProgress1.Value) + 10
        End With
    End Sub
    Sub Matching()
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
                                nb = Math.Max(GetSimilarity(c.name.toupper, .Columns(i).Tag(0).Trim.ToUpper), GetSimilarity(c.text.toupper, .Columns(i).Tag(0).Trim.ToUpper))
                                If nb > 0.4 Then
                                    TblMatches.Rows.Add(c.name, .Columns(i).Tag(0), nb)
                                End If
                            Next
                        End With
                    End If
                End If
            Next
            Dim nrw() As DataRow = Nothing
            With Grd
                For i = 0 To .ColumnCount - 1
                    nrw = TblMatches.Select("[Colonne]='" & IsNull(.Columns(i).Tag(0), "").Replace("'", "''") & "'", "Colonne Asc, Similar Desc")
                    If nrw.Length > 0 Then
                        For Each c In pnlChamps.Controls
                            If TypeOf c Is Label Then
                                If c.name = nrw(0).Item("Champs") Then
                                    .Columns(i).HeaderCell.Style.BackColor = CType(c, Label).BackColor
                                    .Columns(i).HeaderText = CType(c, Label).Text
                                    .Columns(i).Name = CType(c, Label).Name
                                    c.visible = False

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
                        .Columns(i).HeaderCell.Style.BackColor = CType(c, Label).BackColor
                        .Columns(i).HeaderText = CType(c, Label).Text
                        .Columns(i).Name = CType(c, Label).Name
                        c.visible = False
                    End If
                End With
            Next
        End If

    End Sub

    Sub Exporting()
        Try
            Cursor = Cursors.WaitCursor
            Dim ornd As New Random
            Dim nbCol As Integer = 0
            Dim nbLig As Integer = 51
            Dim ColorEnt, ColorEntF As Color
            ColorEntF = System.Drawing.Color.FromArgb(255, 255, 255)
            ColorEnt = System.Drawing.Color.FromArgb(31, 73, 125)
            Try
                If IO.Directory.Exists(My.Application.Info.DirectoryPath & "\TMP") Then
                    For Each _file As String In IO.Directory.GetFiles(My.Application.Info.DirectoryPath & "\TMP")
                        IO.File.Delete(_file)
                    Next
                End If
            Catch ex As Exception

            End Try
            If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\TMP") Then IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\TMP")
            Dim path As String = (My.Application.Info.DirectoryPath & "\TMP\temp" & ornd.Next(100, 15000) & ".xlsx")
            Dim tempfile As New IO.FileInfo(path)
            Dim oExcel As New OfficeOpenXml.ExcelPackage(tempfile)

            Dim oWorkbook As OfficeOpenXml.ExcelWorkbook = oExcel.Workbook
            Dim xlws As OfficeOpenXml.ExcelWorksheet = oWorkbook.Worksheets.Add("Mod_Import")
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
    Private Sub Combo_oModeleImport_DropDownClosed(sender As Object, e As EventArgs) Handles Combo_oModeleImport.DropDownClosed
        Request()
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class