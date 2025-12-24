Public Class Zoom_Annee
    Dim Tbl As New DataTable
    Dim oSize As New Size
    Dim oLoc As New Point
    Friend _annnee As Integer()
    Private Sub Zoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tbl = DATA_READER_GRD("select Annee, 'Du ' + convert(nvarchar(10),Dat_Deb,103)+' au ' + convert(nvarchar(10),Dat_Fin,103) as 'Intitulé' from Param_Periode_Paie where id_Societe=" & Societe.id_Societe)
        With Zoom_Grd
            .DataSource = Tbl
            .setFilter({0, 1})
            .Fit()
        End With
        oSize = Me.Size
        oLoc = Me.Location
    End Sub
    Private Sub Zoom_Grd_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Zoom_Grd.CellDoubleClick
        If e.RowIndex >= 0 Then
            _annnee = {Zoom_Grd.Item("Annee", e.RowIndex).Value}
            Me.Close()
        End If
    End Sub

    Sub Maximize_btn_Click(sender As Object, e As EventArgs) Handles Maximize_btn.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Size = oSize
            Me.Location = oLoc
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Escape
                Me.Close()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub Close_btn_Load(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class