Imports System.ComponentModel
Public Class Zoom_RH_Preparation_Paie_RegenrationEV
    '  Friend preparation_frm As New RH_Preparation_Paie
    Friend CodPlan As String = ""
    Friend DatDeb As Date = Now
    Friend DatFin As Date = Now
    Friend TblPrePaie As New DataTable
    Friend modeSaisiePaie As String = "Journal"
    Dim Tbl_EV As New DataTable
    Dim WithEvents BgW As New BackgroundWorker
    Dim listRub As New List(Of String)
    Sub chargement()
        If Not EstDate(DatDeb) OrElse Not EstDate(DatFin) OrElse CodPlan.Trim = "" Then Return
        Grille.Rows.Clear()
        Dim sqlStr = $"exec Sys_RH_Paie_EV_Modules_Annexes {Societe.id_Societe}, '{CodPlan}', '{DatDeb}', '{DatFin}',''"
        Tbl_EV = DATA_READER_GRD(sqlStr)
        Dim mntM, MntP As Double
        With Tbl_EV
            For Each c As DataColumn In Tbl_EV.Columns
                If c.ColumnName <> "Matricule" Then
                    Grille.Rows.Add("")
                    Grille.Item(Cod_Rubrique.Index, Grille.Rows.Count - 1).Value = c.ColumnName
                    mntM = Tbl_EV.Compute($"Sum([{c.ColumnName}])", "")
                    If modeSaisiePaie = "Journal" Then
                        MntP = If(TblPrePaie.Columns.Contains(c.ColumnName), TblPrePaie.Compute($"SUM([{c.ColumnName}])", ""), 0)
                    Else
                        MntP = If(TblPrePaie.Compute($"SUM(Valeur)", $"Cod_Rubrique='{c.ColumnName}'"), 0)
                    End If
                    Grille.Item(Mnt_Modules.Index, Grille.Rows.Count - 1).Value = mntM
                    Grille.Item(Mnt_Preparation.Index, Grille.Rows.Count - 1).Value = MntP
                    Grille.Item(Oui.Index, Grille.Rows.Count - 1).Value = mntM <> MntP
                    Grille.Item(Etat.Index, Grille.Rows.Count - 1).Value = If(mntM = MntP, My.Resources.Blank, My.Resources.orangebutton)
                End If
            Next
        End With
    End Sub
    Private Sub Zoom_RH_Preparation_Paie_RegenrationEV_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub Grille_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grille.CellMouseEnter
        If e.RowIndex < 0 Then Return
        If Grille.Rows.Count <= 0 Then Return
        If e.ColumnIndex = Oui.Index Then
            Grille.Cursor = Cursors.Hand
        Else
            Grille.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Grille_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grille.CellMouseClick
        If e.RowIndex < 0 Then Return
        If Grille.Rows.Count <= 0 Then Return
        If e.ColumnIndex <> Oui.Index Then Return

        With Grille
            If CDbl(.Item(Mnt_Modules.Index, e.RowIndex).Value) = CDbl(.Item(Mnt_Preparation.Index, e.RowIndex).Value) Then
                .Item(Oui.Index, e.RowIndex).Value = False
                Return
            End If
            .Item(Oui.Index, e.RowIndex).Value = Not CBool(.Item(Oui.Index, e.RowIndex).Value)
        End With
    End Sub

    Private Sub SelectAll_pb_Click(sender As Object, e As EventArgs) Handles SelectAll_pb.Click
        With Grille
            For i = 0 To .RowCount - 1
                If CDbl(.Item(Mnt_Modules.Index, i).Value) = CDbl(.Item(Mnt_Preparation.Index, i).Value) Then
                    .Item(Oui.Index, i).Value = False
                Else
                    .Item(Oui.Index, i).Value = True
                End If
            Next
        End With
    End Sub

    Private Sub Request_pb_Click(sender As Object, e As EventArgs) Handles Request_pb.Click
        chargement()
    End Sub

    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        If BgW.IsBusy Then Return
        Cursor = Cursors.WaitCursor
        BgW.RunWorkerAsync()
    End Sub
    Private Sub BgW_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgW.DoWork
        listRub = New List(Of String)
        With Grille
            For i = 0 To .RowCount - 1
                If CDbl(.Item(Mnt_Modules.Index, i).Value) = CDbl(.Item(Mnt_Preparation.Index, i).Value) Then
                    .Item(Oui.Index, i).Value = False
                End If
                If CBool(.Item(Oui.Index, i).Value) Then
                    listRub.Add(.Item(Cod_Rubrique.Index, i).Value)
                End If
            Next
        End With
        If listRub.Count = 0 Then
            ShowMessageBox("Aucun élément variable à importer.")
            Return
        End If
        Dim src As DataTable = Tbl_EV
        Dim dst As DataTable = TblPrePaie



        If modeSaisiePaie = "Journal" Then
            ' 1) Colonnes cibles réellement présentes
            Dim cols = listRub.Where(Function(c) dst.Columns.Contains(c)).ToArray()

            Dim rowByMat As New Dictionary(Of String, DataRow)(StringComparer.Ordinal)
            For Each r As DataRow In dst.Rows
                rowByMat(CStr(r("Matricule"))) = r
            Next
            ' 3) Copie
            For Each s In src.AsEnumerable()
                Dim key = CStr(s("Matricule"))
                Dim d As DataRow = Nothing
                If rowByMat.TryGetValue(key, d) Then
                    For Each c In cols
                        d(c) = s(c)
                    Next
                End If
            Next
        Else
            ' 1) Colonnes cibles réellement présentes
            Dim cols = listRub.Where(Function(c) dst.Select($"Cod_Rubrique='{c}'").Length > 0).ToArray()
            For Each rw As DataRow In src.Rows
                For Each c In cols
                    Dim drw() = dst.Select($"Matricule='{rw("Matricule")}' and Cod_Rubrique='{c}'")
                    If drw.Length > 0 Then drw(0)("Valeur") = rw(c)
                Next
            Next
        End If

    End Sub

    Private Sub BgW_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgW.RunWorkerCompleted
        Cursor = Cursors.Default
        chargement()
    End Sub

End Class