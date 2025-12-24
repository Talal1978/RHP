Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO

Public Class IR_Import
    Friend WithEvents Grd As New ud_Grd
    Dim oPoint As New ArrayList
    Friend oChamps As New ArrayList
    Friend TblCol As DataTable
    Dim TblBalance As New DataTable
    Friend FermerApresImport = True
    Dim lblcdr As New Label
    Dim MouseOn As Boolean = True
    Dim oPb As New PictureBox
    Dim PnlWait As New ud_PanelWait
    Friend swhere As String = "  where Lib_Modele like 'IR%'  "
    Dim ConnString As String = ""
    Dim oAvancementStr As String = ""
    Dim oTableName As String = ""
    Dim NBError As Integer = 0
    Friend AnneePaie As String = ""
    Dim Save_D As ud_btn
    Dim Import_D As ud_btn
    Dim Request_D As ud_btn
    Dim New_D As ud_btn
    Dim Matches_D As ud_btn
    Dim Export_D As ud_btn

    Private Sub Zoom_frmGBalanceImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Combo_oModeleImport.Items.Count = 0 Then Combo_oModeleImport.FromSQL("select distinct Table_Name as Valeur,ltrim(right(Lib_Modele,len(Lib_Modele)-charindex('|',Lib_Modele,0))) as Membre from Param_ModeleImportation " & swhere & " order by Membre")
        If Combo_oModeleImport.Items.Count > 0 Then
            If Combo_oModeleImport.SelectedIndex < 0 Then Combo_oModeleImport.SelectedIndex = 0
        End If
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
            '   .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            '   .RowHeadersWidth = 30
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
        lblnb.Text = "0"
        With Grd
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.BackColor = Color.AliceBlue
                .Columns(i).Name = i
                .Columns(i).HeaderText = .Columns(i).Tag
            Next
        End With

        If Combo_oModeleImport.Items.Count = 0 Then Combo_oModeleImport.FromSQL("select distinct Table_Name as Valeur,ltrim(right(Lib_Modele,len(Lib_Modele)-charindex('|',Lib_Modele,0))) as Membre from Param_ModeleImportation " & swhere & " order by Membre")

    End Sub
    Sub Request()
        Initialisation()
        TblCol = DATA_READER_GRD("select * from Param_ModeleImportation where Table_Name='" & Combo_oModeleImport.SelectedValue & "' order by Rang")

        Dim oX As Integer = 20
        Dim oY As Integer = 96
        'Dim oTTip As New System.Windows.Forms.ToolTip
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
                    SuperTooltip1.SetSuperTooltip(obtn, New DevComponents.DotNetBar.SuperTooltipInfo(TblCol.Rows(i).Item("Colonne"), "", TblCol.Rows(i).Item("Lib_colonne"), Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Lemon))
                    pnlChamps.Controls.Add(obtn)
                    oPoint.Add(.Location)
                    AddHandler .MouseLeave, AddressOf Lbl_MouseLeave
                    AddHandler .MouseMove, AddressOf Lbl_MouseMove
                    oY += obtn.Height + 2
                End With
                oChamps.Add(obtn.Name)
            Next
        End With
        AddEvent(pnlChamps)
    End Sub
    Private Sub Importer_btn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Importer_btn.Click
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
            OpenFileDialog.Filter = "Fichiers Excel (*.xlsx)|*.xlsx"

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
        NBError = 0
        If Combo_oModeleImport.SelectedIndex < 0 Then Exit Sub
        If BKW_Import.IsBusy Then
            ShowMessageBox("Une opération d'import est encours, merci de patienter")
            Return
        End If
        oTableName = Combo_oModeleImport.SelectedValue
        AttendreProcess(True)
        BKW_Import.RunWorkerAsync()
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
    End Sub
    Sub ImporterFeuilleExcel()
        If ExcelSheets.Items.Count = 0 Or ExcelSheets.SelectedIndex = -1 Then
            ShowMessageBox("Aucune feuille excel sélectionnée.", "Alerte", MessageBoxButtons.OK, msgIcon.Warning)
            AttendreProcess(False)
            Return
        End If

        If SplitContainer1.Panel2.Controls.Contains(Grd) Then
            SplitContainer1.Panel2.Controls.Remove(Grd)
        End If
        Grd = New DataGridView
        MiseEnFormeGrd()

        AttendreProcess(True)
        strFeuille = ExcelSheets.SelectedItem
        BKW_ChargerFeuilleExcel.RunWorkerAsync()
    End Sub
    Sub AttendreProcess(Debut As Boolean)
        If Debut Then
            Save_D.Enabled = False
            Importer_btn.Enabled = False
            Combo_oModeleImport.Enabled = False
            Import_D.Enabled = False
            Request_D.Enabled = False
            ExcelSheets.Enabled = False
            oTimer.Start()
            With PnlWait
                SplitContainer1.Panel2.Controls.Add(PnlWait)
                .Visible = True
                .BringToFront()
            End With
        Else
            oTimer.Stop()
            Save_D.Enabled = True
            Importer_btn.Enabled = True
            Combo_oModeleImport.Enabled = True
            Import_D.Enabled = True
            Request_D.Enabled = True
            ExcelSheets.Enabled = True
            If SplitContainer1.Panel2.Controls.Contains(PnlWait) Then SplitContainer1.Panel2.Controls.Remove(PnlWait)
        End If

    End Sub
    Private Sub Grd_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs)
        lblnb.Text = Grd.RowCount - 1
    End Sub
    Private Sub Grd_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs)
        lblnb.Text = Grd.RowCount - 1
    End Sub
    Private Sub Grd_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        With Grd
            For Each c In pnlChamps.Controls
                If TypeOf c Is Label Then
                    If c.name = .Columns(e.ColumnIndex).Name Then
                        c.visible = True
                        .Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.AliceBlue
                        .Columns(e.ColumnIndex).HeaderText = Grd.Columns(c.name).tag
                        Exit For
                    End If
                End If
            Next
        End With
    End Sub
    Private Sub Combo_oModeleImport_DropDownClosed(sender As Object, e As EventArgs) Handles Combo_oModeleImport.DropDownClosed
        Request()
    End Sub
    Private Sub Close_D_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub Param_Import_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Save_D.Enabled = False Then e.Cancel = True
    End Sub
    Dim strFeuille As String = ""
    Dim conn As OleDbConnection
    Dim dta As OleDbDataAdapter
    Dim dts As DataSet
    Private Sub BKW_ChargerFeuilleExcel_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKW_ChargerFeuilleExcel.DoWork
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
                '   For i = .Columns.Count - 1 To 0 Step -1
                'nbVide = 0
                'For j = 0 To .Rows.Count - 1
                'If IsNull(.Rows(j).Item(i), "").Trim <> "" Then
                'Exit For
                'ElseIf IsNull(.Rows(j).Item(i), "").Trim = "" Then
                'nbVide += 1
                'ElseIf IsNumeric(IsNull(.Rows(j).Item(i), "0").Trim) Then
                'If Math.Round(CDbl(.Rows(j).Item(i)), 2) = 0 Then nbVide += 1
                'End If
                'Next
                ' If nbVide = .Rows.Count Then TblBalance.Columns.RemoveAt(i)
                '  Next
                With Grd
                    .DataSource = TblBalance
                End With
            End With
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Private Sub BKW_ChargerFeuilleExcel_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKW_ChargerFeuilleExcel.RunWorkerCompleted
        SplitContainer1.Panel2.Controls.Add(Grd)
        With Grd
            For i = 0 To .ColumnCount - 1
                .Columns(i).Tag = .Columns(i).Name
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(i).HeaderCell.Style.BackColor = Color.AliceBlue
            Next
        End With
        lblnb.Text = Grd.RowCount - 1
        AttendreProcess(False)
    End Sub
    Private Sub ExcelSheets_DropDownClosed(sender As Object, e As EventArgs) Handles ExcelSheets.DropDownClosed
        ImporterFeuilleExcel()
    End Sub
    Sub Saving()
        Importer()
    End Sub
    Private Sub BKW_Import_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKW_Import.DoWork
        If Grd.RowCount = 0 Then Return
        Dim TabContientAnneePaie As Integer = CnExecuting("Select count(*) from INFORMATION_SCHEMA.COLUMNS where COLUMN_NAME='Annee_Paie' and TABLE_NAME='" & oTableName & "'").Fields(0).Value
        Dim TabContientSociete As Integer = CnExecuting("Select count(*) from INFORMATION_SCHEMA.COLUMNS where COLUMN_NAME='id_Societe' and TABLE_NAME='" & oTableName & "'").Fields(0).Value
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
            If Grd.Columns.Contains(orw(i).Item("Colonne")) Then nb += 1
        Next
        If nb < orw.Length Then
            ShowMessageBox("Vous n'avez pas affecté tous les champs obligatoires")
            NBError = 1
            Exit Sub
        End If
        If CnExecuting("Select count(*) from where 1=1 " & oTableName & IIf(TabContientAnneePaie > 0, " and Annee_Paie='" & AnneePaie & "'", "") & IIf(TabContientSociete > 0, " and id_Societe='" & Societe.id_Societe & "'", "")).Fields(0).Value > 0 Then
            Dim rsl As MsgBoxResult = ShowMessageBox("La table " & oTableName & " contient déjà des données." & vbCrLf & "Voulez-vous l'écraser?" & vbCrLf & "Oui : Remplacer les enregistrements actuels par les nouveaux" & vbCrLf &
                                                            "Non : Insertion sans écraser les enregistrements actuels" & vbCrLf &
                                                            "Annuler : Abondonner", "RHP", MessageBoxButtons.YesNoCancel, msgIcon.Warning, MessageBoxDefaultButton.Button3)
            If rsl = DialogResult.Cancel Then
                NBError = 1
                Exit Sub
            ElseIf rsl = DialogResult.Yes Then
                CnExecuting("delete from where 1=1 " & oTableName & IIf(TabContientAnneePaie > 0, " and Annee_Paie='" & AnneePaie & "'", "") & IIf(TabContientSociete > 0, " and id_Societe='" & Societe.id_Societe & "'", ""))
            ElseIf rsl = DialogResult.No Then
                If TblCol.Select("[Cle]='True'").Length > 0 Then
                    ShowMessageBox("Insertion impossible, votre table contient déjà des enregistrements", "Insertion", MessageBoxButtons.OK, msgIcon.Error)
                    NBError = 1
                    Exit Sub
                End If
            End If
        End If
        With Grd
            nb = 0
            oAvancementStr = "Contrôle des données d'importation"
            'contrôle de type de donnée
            For j = 0 To .ColumnCount - 1
                If oChamps.Contains(.Columns(j).Name) Then
                    orw = TblCol.Select("Colonne='" & .Columns(j).Name & "'")
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
            Next

            If oTableName = "IR_Permanent_Exoneres" Then
                Dim TblElementExonere As DataTable = DATA_READER_GRD("select * from Param_IR_NatureElementExonere")
                For i = 0 To .RowCount - 2
                    .Rows(i).Selected = False
                    If TblElementExonere.Select("[Code]='" & .Item("refNatureElementExonere", i).Value & "'").Length = 0 Then
                        ShowMessageBox("Erreur nature element exonore")
                        .Rows(i).Selected = True
                        NBError = 1
                        Exit Sub
                    End If
                Next
            End If


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
            Dim rs As New ADODB.Recordset
            Dim owhare1 As String = IIf(TabContientAnneePaie <> "", " where Annee_Paie='" & AnneePaie & "'", " where 1=1")
            Dim owhare2 As String = ""
            Dim owhare3 As String = IIf(TabContientSociete > 0, " and id_Societe='" & Societe.id_Societe & "'", " and 1=1")
            For i = 0 To .RowCount - 2
                owhare2 = owhere
                argVal.Clear()
                If owhere <> "" Then
                    For n = 0 To arg.Count - 1
                        argVal.Add(.Item(arg(n), i).value)
                    Next
                    owhare2 = String.Format(owhare2, argVal.ToArray)
                End If
                If owhare2 = "" Then owhare2 = " and 1=2 "

                rs.Open("Select * from " & oTableName & owhare1 & owhare3 & owhare2, cn, 2, 2)
                If rs.EOF Then
                    rs.AddNew()
                Else
                    rs.Update()
                End If
                If TabContientAnneePaie > 0 Then rs("Annee_Paie").Value = AnneePaie
                If TabContientSociete > 0 Then rs("id_Societe").Value = Societe.id_Societe
                For j = 0 To oChamps.Count - 1
                    If .Columns.Contains(oChamps(j)) Then
                        orw = TblCol.Select("[Table_Name]='" & oTableName & "' and [Colonne]='" & oChamps(j) & "'")
                        rs(oChamps(j)).Value = IsNull(.Item(oChamps(j), i).Value, orw(0).Item("Valeur_Default"))
                    End If
                Next
                rs.Update()
                rs.Close()
                oAvancementStr = "Enregistrement : " & (i + 1) & "/" & .RowCount
            Next
        End With
    End Sub
    Private Sub BKW_Import_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKW_Import.RunWorkerCompleted
        AttendreProcess(False)
        If NBError = 0 Then
            If FermerApresImport Then
                Me.Close()
            Else
                Notification("Importation", "Données importées avec succès", 1, "OK")
            End If
        End If
    End Sub
    Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        With PnlWait
            .CircularProgress1.Value = IIf(.CircularProgress1.Value = 100, 0, .CircularProgress1.Value) + 10
            .lblAvancement.Text = oAvancementStr
            .lblAvancement.Refresh()
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
                                nb = Math.Max(GetSimilarity(c.name.toupper, .Columns(i).Tag.Trim.ToUpper), GetSimilarity(c.text.toupper, .Columns(i).Tag.Trim.ToUpper))
                                If nb > 0.4 Then
                                    TblMatches.Rows.Add(c.name, .Columns(i).Tag, nb)
                                End If
                            Next
                        End With
                    End If
                End If
            Next
            Dim nrw() As DataRow = Nothing
            With Grd
                For i = 0 To .ColumnCount - 1
                    nrw = TblMatches.Select("[Colonne]='" & IsNull(.Columns(i).Tag, "").Replace("'", "''") & "'", "Colonne Asc, Similar Desc")
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
            If Combo_oModeleImport.SelectedIndex = -1 Then Return
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
            Dim xlws As OfficeOpenXml.ExcelWorksheet = oWorkbook.Worksheets.Add(Combo_oModeleImport.SelectedValue.ToString.Substring(0, Math.Min(30, Combo_oModeleImport.SelectedValue.ToString.Length)))
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
End Class