Public Class Zoom_Preparation_Paie_Saisie_Add_Agent
    Friend PlanPaie As String = ""
    Friend swhere As String = ""
    Friend f_preparation As New RH_Preparation_Paie_Saisie
    Dim oSize As New Size
    Dim oLoc As New Point
    Dim TblSource As New DataTable
    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Zoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        oSize = Me.Size
        oLoc = Me.Location
        Request(True)
    End Sub
    Sub Request(Debut As Boolean)
        If Debut Then
            swhere = IIf(swhere = "", "", " and Matricule not in (" & swhere & ") ")
            Dim Cod_Sql As String = "select CONVERT(bit,'false') as 'Check', Matricule, Nom, Dat_Entree 'Date entrée' , 
                                Cod_Entite 'Entité', Cod_Grade as 'Grade', Typ_Agent as 'Type agent', Typ_Contrat as 'Type contrat'
                                from Sys_RH_Preparation_Paie_Agent a
                                where Droit_Paie='true' and id_Societe =" & Societe.id_Societe & " and Plan_Paie = '" & PlanPaie & "' " & swhere & "
                                and not exists(select Matricule from RH_Preparation_Paie_Detail d left join RH_Preparation_Paie e on e.Cod_Preparation=d.Cod_Preparation
                    where (('" & f_preparation.Dat_Deb_Periode_Text.Text & "' between Dat_Deb_Periode and Dat_Fin_Periode) or  ('" & f_preparation.Dat_Fin_Periode_Text.Text & "' between Dat_Deb_Periode and Dat_Fin_Periode) 
                    or (Dat_Deb_Periode between '" & f_preparation.Dat_Deb_Periode_Text.Text & "' and '" & f_preparation.Dat_Fin_Periode_Text.Text & "') or (Dat_Fin_Periode between '" & f_preparation.Dat_Deb_Periode_Text.Text & "' and '" & f_preparation.Dat_Fin_Periode_Text.Text & "')) and d.id_Societe=" & Societe.id_Societe & " and d.Matricule=a.Matricule)
                                order by Nom"
            TblSource = DATA_READER_GRD(Cod_Sql)
        End If
        With Grd

            If Debut Then
                If TblSource.Rows.Count > 50 Then
                    .DataSource = TblSource.AsEnumerable.Take(50).CopyToDataTable
                Else
                    .DataSource = TblSource
                End If
                .Columns("Check").HeaderText = ""
                TblSource.Columns("Check").ReadOnly = False
                Grd.setFilter({1, 2, 3, 4, 5, 6, 7})
            Else
                .DataSource = TblSource
                .Tag = If(
    TryCast(.Tag, Object())?.
        Take(5).
        Concat({TblSource}).
        ToArray(),
    {TblSource}
)
            End If

        End With
    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub Confirm_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_pb.Click
        With Grd
            For i = 0 To .RowCount - 1
                If CBool(IsNull(.Item("Check", i).Value, False)) = True Then
                    For Each _rb In f_preparation.TblEP.Rows
                        Dim _r = f_preparation.TblPrePaie.NewRow()
                        _r("Matricule") = .Item("Matricule", i).Value
                        _r("Nom") = .Item("Nom", i).Value
                        _r("Cod_Rubrique") = _rb("Cod_Rubrique")
                        _r("Valeur") = 0
                        f_preparation.TblPrePaie.Rows.Add(_r)
                        f_preparation.TblPrePaie.AcceptChanges()
                        f_preparation.setRubriqueModified(_rb("Cod_Rubrique"))
                    Next
                End If
            Next
        End With
        f_preparation.ChargerMatricules()

        Me.Close()
    End Sub
    Private Sub Normalize_D_Click(sender As Object, e As EventArgs) Handles Maximize_pb.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Size = oSize
            Me.Location = oLoc
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub Zoom_Grd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellContentClick
        With GRD()

            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 0 Then
                    .Item(0, e.RowIndex).Value = Not CBool(.Item(0, e.RowIndex).Value)
                End If
            End If
        End With
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles SelectAll_pb.Click
        With GRD()

            For i = 0 To .RowCount - 1
                .Item(0, i).Value = Not CBool(.Item(0, i).Value)
            Next
        End With
    End Sub
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles Request_pb.Click
        Request(False)
    End Sub
End Class