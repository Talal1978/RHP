Public Class Zoom_Org_Organigramme_ListeAgent
    Friend CodEntite As String = ""
    Private Sub Zoom_Org_Organigramme_ListeAgent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListeAgentVues_cbo.FromSQL("Select Valeur,Membre from Param_Rubriques where Nom_Controle='ListeEffectifVues' and Valeur not in ('V001','V002','V003')")
        Request("V002")
        Ges_Pie_Clt_GRD.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub
    Private Sub Rd_Grade_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Grade.CheckedChanged
        If Rd_Grade.Checked Then
            Request("V001")
        End If
    End Sub
    Private Sub Rd_Effect_Entite_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Effect_Entite.CheckedChanged
        If Rd_Effect_Entite.Checked Then
            Request("V002")
        End If
    End Sub

    Private Sub Rd_Detail_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Detail.CheckedChanged
        If Rd_Detail.Checked Then
            Request("V003")
        End If
    End Sub
    Private Sub ListeAgentVues_cbo_DropDownClosed(sender As Object, e As EventArgs) Handles ListeAgentVues_cbo.DropDownClosed
        If ListeAgentVues_cbo.SelectedIndex >= 0 Then
            Request(ListeAgentVues_cbo.SelectedValue)
        End If
    End Sub
    Sub Request(Vue As String)
        Cursor = Cursors.WaitCursor
        Dim oStyle As New DataGridViewCellStyle
        Dim Cod_Sql As String = "exec Sys_Organigramme_ListeEffectifVues " & Societe.id_Societe & ", '" & CodEntite & "','" & Vue & "'"
        With oStyle
            .Format = "N2"
            .Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
        Dim oIndx(Tbl.Columns.Count - 1) As Integer
        With Ges_Pie_Clt_GRD
            .DataSource = Tbl
            For i = 0 To Tbl.Columns.Count - 1
                If Tbl.Columns(i).DataType.ToString.Contains("Double") Then
                    .Columns(i).DefaultCellStyle = oStyle
                End If
                oIndx(i) = i
            Next
            Ges_Pie_Clt_GRD.setFilter(oIndx)
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class