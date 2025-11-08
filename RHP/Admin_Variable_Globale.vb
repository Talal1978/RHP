Public Class Admin_Variable_Globale
    Private Sub Param_Pie_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Request()
    End Sub

    Private Sub Request_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Request()
    End Sub

    Sub Request()
        Dim Cod_Sql As String

        Cod_Sql = "SELECT  Nom_Var as 'Variable', Description  FROM Controle_Variable_Globale "
        Cod_Sql = Cod_Sql & " where Description like '%" & Description_Text.Text & "%'"
        GRD(Cod_Sql, Var_Grd)

        Dim oMenu As New ToolStripMenuItem
        With oMenu
            .Text = "Valeur Variable"
            AddHandler .Click, AddressOf ValeurVariable
        End With
        Var_Grd.ContextMenuStrip.Items.Insert(0, oMenu)

    End Sub
    Sub ValeurVariable()
        Try
            If Var_Grd.RowCount = 0 Then Exit Sub
            For i = 0 To Var_Grd.RowCount - 1
                If Var_Grd.Rows(i).Selected Then
                    ShowMessageBox(GlobalVar(IsNull(Var_Grd.Item(0, i).Value, "").Trim))
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Description_Text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Description_Text.KeyPress
        If e.KeyChar = "'" Then e.Handled = True

    End Sub
    Private Sub Description_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Description_Text.TextChanged
        Request()
    End Sub
End Class