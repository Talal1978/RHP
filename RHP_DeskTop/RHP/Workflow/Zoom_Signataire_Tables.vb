
Public Class Zoom_Signataire_Tables
    Friend oCell As DataGridViewTextBoxCell
    Dim frm As New Workflow_Signatures
    Private Sub Zoom_Signataire_Relation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = oCell.DataGridView.FindForm
        Trv.Nodes.Add(New TreeNode With {.Name = frm.table_Ref_txt.Text, .Text = .Name})
        Dim rg As New System.Text.RegularExpressions.Regex("\W+")
        With frm.Grd_Tbl
            For i = 0 To oCell.RowIndex
                If Not rg.IsMatch(IsNull(.Item(frm.Table_Liee.Index, i).Value, "")) Then
                    Trv.Nodes.Add(New TreeNode With {.Name = frm.Grd_Tbl.Item(frm.Table_Liee.Index, i).Value, .Text = .Name})
                End If
            Next
        End With
        '  MsgBox("select TABLE_NAME+'.'+COLUMN_NAME as Champs from INFORMATION_SCHEMA .COLUMNS where TABLE_NAME in (" & TblRef & ") order by TABLE_NAME,ORDINAL_POSITION ")
        Dim Tbl As DataTable = DATA_READER_GRD("select TABLE_NAME,COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS")
        With Trv
            For Each n As TreeNode In .Nodes
                Dim nrw() As DataRow = Tbl.Select("TABLE_NAME='" & n.Name & "'", "COLUMN_NAME Asc")
                For i = 0 To nrw.Length - 1
                    n.Nodes.Add(New TreeNode With {.Name = n.Name & "." & nrw(i)("COLUMN_NAME"), .Text = nrw(i)("COLUMN_NAME")})
                Next
            Next
            ' .ExpandAll()
        End With
        Liaison_txt.Text = oCell.Value
    End Sub
    Private Sub Trv_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Trv.NodeMouseDoubleClick
        With Trv
            If .SelectedNode Is Nothing Then Return
            Dim currentPosition As Integer = Liaison_txt.SelectionStart
            Dim currentText As String = Liaison_txt.Text
            Dim txtToInsert As String = IsNull(.SelectedNode.Name, "")
            Liaison_txt.Text = currentText.Insert(currentPosition, txtToInsert)
            Liaison_txt.SelectionStart = currentPosition + txtToInsert.Length + 1
        End With
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        If IsNull(Liaison_txt.Text, "") <> IsNull(oCell.Value, "") And IsNull(oCell.Value, "").Trim <> "" Then
            If ShowMessageBox("Voulez-vous appliquer les modifications?", "Configurateur", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
        End If
        oCell.Value = Liaison_txt.Text
        Me.Close()
    End Sub
End Class