Public Class Zoom_GED_Properties
    Friend FDid As String = ""
    Dim Tbl As New DataTable
    Private Sub Zoom_GED_Properties_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tbl = DATA_READER_GRD("exec Sys_GED_Droits '" & FDid & "'")
        With Grd
            .DataSource = Tbl
            .Columns("id_User").Visible = False
            Tbl.Columns("Ecriture").ReadOnly = False
            Tbl.Columns("Lecture").ReadOnly = False
            Tbl.Columns("Cacher").ReadOnly = False
            Grd.setFilter({ .Columns("Nom").Index})
        End With
    End Sub
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        If Grd.ModeFiltreActive Then
            ShowMessageBox("Veuillez défiltrer votre grille", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim R, W, C As String
        R = ""
        W = ""
        C = ""
        With Tbl
            Dim nrw() As DataRow = Tbl.Select("id_User=-1")
            If nrw.Length > 0 Then
                If nrw(0)("Cacher") = True Then
                    C = "*"
                    W = ""
                    R = ""
                    GoTo suite
                ElseIf nrw(0)("Ecriture") = True Then
                    W = "*"
                    R = "*"
                ElseIf nrw(0)("Lecture") = True Then
                    R = "*"
                End If
            End If
            For i = 0 To .Rows.Count - 1
                If IsNull(.Rows(i)("Cacher"), False) = True And C <> "*" And .Rows(i)("id_USer") <> -1 Then
                    C &= IIf(C = "", "", ";") & .Rows(i)("id_User")
                    W = ""
                    R = ""
                ElseIf IsNull(.Rows(i)("Ecriture"), False) = True And W <> "*" And .Rows(i)("id_USer") <> -1 Then
                    W &= IIf(W = "", "", ";") & .Rows(i)("id_User")
                    If R <> "*" Then R &= IIf(R = "", "", ";") & .Rows(i)("id_User")
                ElseIf IsNull(.Rows(i)("Lecture"), False) = True And R <> "*" And .Rows(i)("id_USer") <> -1 Then
                    R &= IIf(R = "", "", ";") & .Rows(i)("id_User")
                End If
            Next
        End With
suite:
        CnExecuting("update Param_GED set Ecriture='" & W & "', Lecture='" & R & "', Cacher='" & C & "' where FD_id='" & FDid & "'")
        Dim TblD As DataTable = DATA_READER_GRD("select * from Param_GED where isnull(Parent_Dir,'')='" & FDid & "'")
        If TblD.Rows.Count > 0 Then
            If ShowMessageBox("Voulez-vous appliquer ces règles à l'ensemble du contenu du dossier?", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.OK Then
                AppliquerDroit(FDid, R, W, C)
            End If
        End If
        Me.Close()
    End Sub
    Sub AppliquerDroit(FD As String, R As String, W As String, C As String)
        Dim TblD As DataTable = DATA_READER_GRD("select * from Param_GED where  isnull(Parent_Dir,'')='" & FD & "'")
        With TblD
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    CnExecuting("update Param_GED set Ecriture='" & W & "', Lecture='" & R & "', Cacher='" & C & "' where FD_id='" & .Rows(i)("FD_id") & "'")
                    If .Rows(i)("Typ") = "D" Then
                        AppliquerDroit(.Rows(i)("FD_id"), R, W, C)
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub Grd_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd.CellMouseClick
        With Grd
            Select Case e.ColumnIndex
                Case .Columns("Cacher").Index
                    .Item("Cacher", e.RowIndex).Value = Not .Item("Cacher", e.RowIndex).Value
                    If CBool(.Item("Cacher", e.RowIndex).Value) Then
                        .Item("Ecriture", e.RowIndex).Value = False
                        .Item("Lecture", e.RowIndex).Value = False
                    End If
                Case .Columns("Ecriture").Index
                    .Item("Ecriture", e.RowIndex).Value = Not .Item("Ecriture", e.RowIndex).Value
                    If CBool(.Item("Ecriture", e.RowIndex).Value) Then
                        .Item("Lecture", e.RowIndex).Value = True
                    End If
                Case .Columns("Lecture").Index
                    .Item("Lecture", e.RowIndex).Value = Not .Item("Lecture", e.RowIndex).Value
            End Select
        End With

    End Sub
    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
End Class