Public Class Zoom_Survey_Typ_Reponse_Help
    Dim Tbl_TypReponse As New DataTable
    Dim TypReponse As String = ""
    Dim modeDebug As Boolean = (Debugger.IsAttached)
    Private Sub Lv_DoubleClick(sender As Object, e As EventArgs) Handles Lv.DoubleClick

        With Lv
            If .Items.Count = 0 Then Return
            If .SelectedItems.Count = 0 Then Return
            Dim nrw() As DataRow = Tbl_TypReponse.Select("Typ_Reponse='" & .SelectedItems(0).Name & "'")
            If nrw.Length = 0 Then Return
            TypReponse = .SelectedItems(0).Name

            rg_txt.Text = IsNull(nrw(0)("Regex"), "")
            Explication_rtb.Rtf = IsNull(nrw(0)("Explication"), "")
            Exemple_rtb.Text = IsNull(nrw(0)("Exemple"), "")
            TypReponse_lbl.Text = IsNull(nrw(0)("Lib_Typ_Reponse"), "")
            TypReponse_lbl.Refresh()
        End With
    End Sub

    Private Sub Zoom_Survey_Typ_Reponse_Help_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Save_pb.Visible = modeDebug
        Enabling(rg_txt, modeDebug)
        Enabling(Exemple_rtb, modeDebug)
        Enabling(Explication_rtb, modeDebug)
        Tbl_TypReponse = DATA_READER_GRD("select * from Survey_Typ_Reponse order by Rang")
        With Tbl_TypReponse
            For i = 0 To .Rows.Count - 1
                Dim itm As New ListViewItem
                itm.Name = .Rows(i)("Typ_Reponse")
                itm.Text = .Rows(i)("Lib_Typ_Reponse")
                itm.ImageIndex = 0
                Lv.Items.Add(itm)
            Next
        End With

    End Sub
    Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        If TypReponse = "" Then Return
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Survey_Typ_Reponse where Typ_Reponse='" & TypReponse & "'", cn, 2, 2)
        If Not rs.EOF Then
            rs.Update()
            rs("Regex").Value = rg_txt.Text
            rs("Explication").Value = Explication_rtb.Rtf
            rs("Exemple").Value = Exemple_rtb.Text
            rs.Update()
        End If
        rs.Close()
        initialiser()
    End Sub
    Sub initialiser()
        TypReponse = ""
        Tbl_TypReponse = DATA_READER_GRD("select * from Survey_Typ_Reponse order by Rang")
        rg_txt.Text = ""
        Explication_rtb.Rtf = ""
        Exemple_rtb.Text = ""
        TypReponse_lbl.Text = ""
        TypReponse_lbl.Refresh()
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class