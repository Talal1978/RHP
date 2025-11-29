Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.CompilerServices

Public Class Mailing_Dest_Import
    Dim oPoint As New ArrayList
    Friend oChamps As New ArrayList
    Friend TblCol As New DataTable
    Dim TblBalance As New DataTable
    Dim oPnl As Panel() = New Panel(30) {}
    Dim olbl As Label() = New Label(30) {}
    Dim lblcdr As New Label
    Friend SrcForm As New Mailing_Destinataires
    Dim MouseOn As Boolean = True
    Dim ColorObligatoire As Color = Color.FromArgb(128, 128, 255)
    Dim ColorOption As Color = Color.FromArgb(255, 255, 192)

    Dim objExcel As OfficeOpenXml.ExcelPackage

    Private Sub Ctb_Ech_Releve_Import_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TblCol = DATA_READER_GRD("select * from Param_ModeleImportation where Cod_Modele='ImportDestinataire'")
        For i = 0 To 30
            oPnl(i) = New Panel
            oPnl(i).Size = New Size(150, 20)
            oPnl(i).BringToFront()
            olbl(i) = New Label
            olbl(i).Dock = DockStyle.Fill
            olbl(i).TextAlign = ContentAlignment.MiddleCenter
            oPnl(i).Controls.Add(olbl(i))
            AddHandler olbl(i).MouseLeave, AddressOf Lbl_MouseLeave
            AddHandler olbl(i).MouseMove, AddressOf Lbl_MouseMove
        Next
        Request()
    End Sub
    Sub Initialisation()
        For i = 0 To 30
            If Me.Controls.Contains(oPnl(i)) Then Me.Controls.Remove(oPnl(i))
            olbl(i).Tag = ""
            olbl(i).Name = ""
        Next
        oPoint.Clear()
        oChamps.Clear()
        With Grille
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.BackColor = Color.AliceBlue
                .Columns(i).Name = i
                .Columns(i).HeaderText = .Columns(i).Tag
            Next
        End With
    End Sub
    Sub Request()
        Initialisation()
        Dim oX As Integer = 800
        Dim oY As Integer = 96
        Dim oTTip As New System.Windows.Forms.ToolTip
        With TblCol
            For i = 0 To .Rows.Count - 1
                oPnl(i).Location = New Point(oX, oY)
                oPnl(i).Visible = True
                oPnl(i).BringToFront()
                Me.Controls.Add(oPnl(i))
                oPoint.Add(oPnl(i).Location)
                olbl(i).Visible = True
                olbl(i).Text = .Rows(i).Item("Lib_colonne")
                oTTip.SetToolTip(olbl(i), .Rows(i).Item("Lib_colonne"))
                olbl(i).Tag = .Rows(i).Item("Colonne")
                olbl(i).BackColor = IIf(.Rows(i).Item("Obligatoire") = True, ColorObligatoire, ColorOption)
                oChamps.Add(olbl(i).Tag)
                If (i Mod 11 = 0) And i > 0 Then
                    oX += olbl(i).Width + 5
                    oY = 96
                Else
                    oY += 22
                End If
            Next
        End With

    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try

            Request()
            Grille.Columns.Clear()

            Dim conn As OleDbConnection
            Dim dta As OleDbDataAdapter
            Dim dts As DataSet
            Dim excel As String
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.AutoUpgradeEnabled = False
            OpenFileDialog.InitialDirectory = importPath
            Dim FichierExp As String = ""
            OpenFileDialog.Filter = "Fichiers Excel (*.xlsx)|*.xlsx|Fichiers XLS (*.xls)|*xls"

            If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then
                importPath = System.IO.Path.GetFullPath(OpenFileDialog.FileName)
                Dim fi As New FileInfo(OpenFileDialog.FileName)
                Dim FileName As String = OpenFileDialog.FileName
                excel = fi.FullName
                txtFichier.Text = excel
                Dim length As Integer = FileName.Split(".").Length
                Dim ConnString As String = ""
                Dim Extention = FileName.Split(".")(length - 1)
                Dim overExcel As String = GetExcelVersion()
                If overExcel = "0" Then
                    ShowMessageBox("Excel n'est pas installé sur votre machine")
                    Return
                End If
                If Extention.ToUpper = "XLS" Then
                    ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excel & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
                ElseIf Extention.ToUpper = "XLSX" Then
                    ConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excel & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
                Else
                    ShowMessageBox("Le fichier n'est pas de type Excel")
                    Exit Sub
                End If

                Dim oSheet As ArrayList = getExcelSheetsName(excel)
                If oSheet.Count = 0 Then
                    ShowMessageBox("Le fichier n'est pas de type Excel valide")
                    Exit Sub
                End If
                Dim strFeuille As String = oSheet(0)
                conn = New OleDbConnection(ConnString)
                dta = New OleDbDataAdapter("Select * From [" & strFeuille & "$]", conn)
                dts = New DataSet
                dta.Fill(dts, "[" & strFeuille & "$]")
                conn.Close()
                TblBalance = dts.Tables(0)

                With TblBalance
                    If .Columns.Count = 0 Or .Rows.Count = 0 Then
                        ShowMessageBox("La première feuille de votre fichier Excel ne contient pas de balance")
                        Exit Sub
                    End If


                End With
                Me.Cursor = Cursors.WaitCursor
                With Grille
                    .Columns.Clear()
                    .DataSource = TblBalance
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    Dim C As Integer = TblBalance.Columns.Count - 1
                    Dim L As Integer = .RowCount - 1
                    For i = 0 To TblBalance.Columns.Count - 1
                        .Columns(i).HeaderCell.Style.BackColor = Color.AliceBlue
                        .Columns(i).Tag = .Columns(i).Name
                        .Columns(i).MinimumWidth = 100
                        If TblBalance.Columns(i).DataType.ToString.Contains("Double") Then
                            .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                        End If
                    Next
                    .RefreshEdit()
                    Dim nbVide As Integer = 0
                    For i = L To 0 Step -1
                        nbVide = 0
                        For Each oCel As DataGridViewCell In .Rows(i).Cells
                            If IsNull(oCel.Value, "") = "" Then nbVide += 1
                        Next
                        If nbVide = C + 1 And Not .Rows(i).IsNewRow Then
                            .Rows.RemoveAt(i)
                        Else
                            .Rows(i).HeaderCell.Value = CStr(i + 1)
                        End If
                    Next
                End With
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            ShowMessageBox(ex.Message)
            Me.Cursor = Cursors.Default
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

    Private Sub Lbl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oX As Integer = oPnl(oChamps.IndexOf(sender.tag)).Location.X + Math.Ceiling(oPnl(oChamps.IndexOf(sender.tag)).Width / 2)
        Dim oY As Integer = oPnl(oChamps.IndexOf(sender.tag)).Location.Y
        Dim gX As Integer = 0
        With Grille
            'délimiter au curseur à la zone de Grille
            If oX < Grille.Left Or oX > .Left + .Width Then Exit Sub
            If oY < Grille.Top Or oY > .Top + .Height Then Exit Sub
            'corriger le curseur par la valeur du scroll
            oX += .HorizontalScrollingOffset
            gX = .Left
            For i = 0 To .ColumnCount - 1
                If oX > gX And oX < gX + .Columns(i).Width Then
                    .Columns(i).Name = sender.tag
                    .Columns(sender.tag).HeaderCell.Style.BackColor = sender.BackColor
                    .Columns(sender.tag).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(sender.tag).HeaderText = sender.Text
                    sender.Visible = False
                    sender.parent.visible = False
                    Exit For
                Else
                    gX = gX + .Columns(i).Width + 1
                End If
            Next
            For j = 0 To oChamps.Count - 1
                If Not .Columns.Contains(olbl(j).Tag) Then
                    olbl(j).Visible = True
                    oPnl(j).Visible = True
                    oPnl(j).Location = oPoint(j)
                End If
            Next
        End With
        Exit Sub
    End Sub
    <DllImport("user32", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)>
    Public Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32", EntryPoint:="SendMessageA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)>
    Public Shared Function SendMessage(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lParam As String) As Integer
    End Function
    Private Sub Lbl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim Indx As Integer = oChamps.IndexOf(sender.tag)
        If Grille.ColumnCount <> 0 AndAlso Grille.RowCount > 0 Then
            Dim handle As Integer = CInt(oPnl(Indx).Handle)
            If ((handle <> 0) AndAlso (Grille.ColumnCount >= 2)) Then
                ReleaseCapture()
                SendMessage(handle, &HA1, 2, Conversions.ToString(CLng(0)))
            End If
        End If
    End Sub

    Sub Enregistrer()
        Saving()
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
    End Sub
    Function GetExcelVersion() As String
        Dim excel As Object = Nothing
        Dim ver As String = "0"
        Dim build As Integer
        Try
            excel = CreateObject("Excel.Application")
            ver = excel.Version
            build = excel.Build
        Catch ex As Exception
            ver = "0"
        End Try
        Return ver
    End Function
    Sub Saving()
        Try

            Dim oDat As Date = CnExecuting("select getdate()").Fields(0).Value
            Me.Cursor = Cursors.WaitCursor
            Dim rs As New ADODB.Recordset

            Dim orw() As DataRow = TblCol.Select("[Obligatoire]='true'")
            For i = 0 To orw.Length - 1
                If Not Grille.Columns.Contains(orw(i).Item("Colonne")) Then
                    MessageBoxRHP(1028, orw(i).Item("Lib_Colonne"))
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Next


            With Grille

                For i = 0 To .RowCount - 2
                    .Rows(i).Selected = False
                    If estEmail(.Item("Email", i).Value) = False Then
                        ShowMessageBox("Format email invalide : " & i + 1)
                        .Rows(i).Selected = True
                        .FirstDisplayedCell = .Item("Email", i)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next

                'Début d'importation
                Dim C2, C3, C4, C5, C6, C7, C8, C9 As Object
                Dim xrw() As DataRow = Nothing
                With SrcForm
                    For i = 0 To Grille.RowCount - 2


                        If Grille.Columns.Contains("Civilite") Then
                            C2 = IsNull(Grille.Item("Civilite", i).Value, "")
                        Else
                            C2 = ""
                        End If
                        If Grille.Columns.Contains("Nom") Then
                            C3 = IsNull(Grille.Item("Nom", i).Value, "")
                        Else
                            C3 = ""
                        End If
                        If Grille.Columns.Contains("Prenom") Then
                            C4 = IsNull(Grille.Item("Prenom", i).Value, "")
                        Else
                            C4 = ""
                        End If
                        If Grille.Columns.Contains("Email") Then
                            C5 = IsNull(Grille.Item("Email", i).Value, "")
                        Else
                            C5 = ""
                        End If
                        If Grille.Columns.Contains("Typ_Tiers") Then
                            C6 = IsNull(Grille.Item("Typ_Tiers", i).Value, "")
                        Else
                            C6 = ""
                        End If
                        If Grille.Columns.Contains("Cod_Tiers") Then
                            C7 = IsNull(Grille.Item("Cod_Tiers", i).Value, "")
                        Else
                            C7 = ""
                        End If
                        If Grille.Columns.Contains("Nom_Tiers") Then
                            C8 = IsNull(Grille.Item("Nom_Tiers", i).Value, "")
                        Else
                            C8 = ""
                        End If
                        If Grille.Columns.Contains("Fonction") Then
                            C9 = IsNull(Grille.Item("Fonction", i).Value, "")
                        Else
                            C9 = ""
                        End If

                        .Grd_Destinataire.Rows.Add(C2, C3, C4, C5, C6, C7, C8, C9)
                    Next


                End With
            End With

            Me.Cursor = Cursors.Default
            ShowMessageBox("Importation réussie")

            Me.Close()

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ShowMessageBox("Echec")
            ShowMessageBox(ex.Message)
        End Try
    End Sub
End Class