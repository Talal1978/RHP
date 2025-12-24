Public Class Zoom_Signataire_Relation
    Friend frm As New Workflow_Signatures
    Friend lig As Integer = 0
    Private Sub Zoom_Signataire_Relation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT Syntaxe, Intitule, ToolTip
FROM     Param_Workflow_Fonctions
ORDER BY Rang ")
        With Tbl
            lvFonctions.Items.Clear()
            For i = 0 To .Rows.Count - 1
                Dim itm As New ListViewItem
                itm.Name = .Rows(i)("Syntaxe")
                itm.Text = .Rows(i)("ToolTip")
                itm.SubItems.Add(.Rows(i)("Intitule"))
                lvFonctions.Items.Add(itm)
            Next
        End With
        Dim TblRef As String = "'" & frm.table_Ref_txt.Text & "'"
        Dim NumLig As String = frm.Grd_ReglesSignatures.Item(frm.Num_Ligne.Index, lig).Value
        Dim rg As New System.Text.RegularExpressions.Regex("\W+")
        With frm.Grd_Tbl
            For i = 0 To .RowCount - 2
                If IsNull(.Item(frm.Num_Lig_Tbl.Index, i).Value, "") = NumLig Then
                    If Not rg.IsMatch(IsNull(.Item(frm.Table_Liee.Index, i).Value, "")) Then
                        TblRef &= ",'" & .Item(frm.Table_Liee.Index, i).Value & "'"
                    End If
                End If
            Next
        End With
        '  MsgBox("select TABLE_NAME+'.'+COLUMN_NAME as Champs from INFORMATION_SCHEMA .COLUMNS where TABLE_NAME in (" & TblRef & ") order by TABLE_NAME,ORDINAL_POSITION ")
        Tbl = DATA_READER_GRD("select TABLE_NAME+'.'+COLUMN_NAME as Champs from INFORMATION_SCHEMA .COLUMNS where TABLE_NAME in (" & TblRef & ") order by TABLE_NAME,COLUMN_NAME ")
        With Tbl
            lvChamps.Items.Clear()
            For i = 0 To .Rows.Count - 1
                Dim itm As New ListViewItem
                itm.Name = .Rows(i)("Champs")
                itm.Text = .Rows(i)("Champs")
                lvChamps.Items.Add(itm)
            Next
        End With
        Sigantaire_formulas_txt.Text = frm.Sigantaire_formulas_txt.Text
    End Sub
    Private Sub lv_DoubleClick(sender As Object, e As EventArgs) Handles lvFonctions.DoubleClick, lvChamps.DoubleClick
        With sender
            If .SelectedItems.Count = 0 Then Return
            Dim currentPosition As Integer = Sigantaire_formulas_txt.SelectionStart
            Dim currentText As String = Sigantaire_formulas_txt.Text
            Dim txtToInsert As String = IsNull(.SelectedItems(0).Name & "; ", "")
            Sigantaire_formulas_txt.Text = currentText.Insert(currentPosition, txtToInsert)
            Sigantaire_formulas_txt.SelectionStart = currentPosition + txtToInsert.Length + 1
        End With
    End Sub
    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        If Sigantaire_formulas_txt.Text <> IsNull(frm.Sigantaire_formulas_txt.Text, "") And IsNull(frm.Sigantaire_formulas_txt.Text, "").Trim() <> "" Then
            If ShowMessageBox("Voulez-vous appliquer les modifications?", "Configurateur", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
        End If
        frm.Sigantaire_formulas_txt.Text = Sigantaire_formulas_txt.Text
        Me.Close()
    End Sub
End Class