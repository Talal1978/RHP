Public Class Zoom_Paiement_Add
    Friend f_Paiement As New RH_Paiement
    Dim oSize As New Size
    Dim oLoc As New Point
    Dim TblSource As New DataTable
    Friend PreparationVsAvance As String = "P"
    Dim Debut As Boolean = True
    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Zoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        oSize = Me.Size
        oLoc = Me.Location
        Request()
    End Sub
    Sub Request()
         Dim Cod_Sql As String =""
        If PreparationVsAvance = "P" Then
            Cod_Sql = $"declare @swhere nvarchar(max)='{f_Paiement.Cod_Preparation_Text.Text }'
select convert(bit, case when CodPaiement is null then 0 else 1 end) as 'Check',Cod_Preparation as Préparation,	Lib_Preparation as Intitulé,Dat_Deb_Periode as 'Début', Dat_Fin_Periode as 'Fin', isnull(Cloture,'false') as 'Clôturée', Annee_Paie as Année 
from RH_Preparation_Paie p
outer apply (select value as CodPaiement from string_split(@swhere,';') where Value=p.Cod_Preparation)v
where id_Societe={Societe.id_Societe}
order by Dat_Fin_Periode desc"
            TblSource = DATA_READER_GRD(Cod_Sql)
        ElseIf PreparationVsAvance = "A" Then
            Cod_Sql = $"declare @swhere nvarchar(max)='{f_Paiement.Cod_Preparation_Text.Text }'
select convert(bit, case when CodPaiement is null then 0 else 1 end) as 'Check',	Num_List_Avance as 'N° de liste des avances',	Lib_List_Avance Désignation, Dat_Avance as 'Date',Cloture as 'Clôturée'
from RH_Paie_Avance_Liste p
outer apply (select value as CodPaiement from string_split(@swhere,';') where Value=p.Num_List_Avance)v
where id_Societe={Societe.id_Societe}
order by Dat_Fin_Periode desc"
        End If
        If Cod_Sql = "" Then Return
        With Grd
            If TblSource.Rows.Count > 50 And Debut Then
                .DataSource = TblSource.AsEnumerable.Take(50).CopyToDataTable
            Else
                .DataSource = TblSource
            End If
            .Columns("Check").HeaderText = ""
            TblSource.Columns("Check").ReadOnly = False
            Grd.setFilter({1, 2, 3, 4})
        End With
    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub Confirm_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_pb.Click
        Dim swhere As String = ""
        With Grd
            For i = 0 To .RowCount - 1
                If CBool(IsNull(.Item("Check", i).Value, False)) = True Then
                    swhere &= IIf(swhere = "", "", ";") & .Item(1, i).Value
                End If
            Next
        End With
        If PreparationVsAvance = "P" Then
            f_Paiement.Cod_Preparation_Text.Text = swhere
        ElseIf PreparationVsAvance = "E" Then
            f_Paiement.Num_List_Avance_txt.Text = swhere
        End If
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
        With Grd()

            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 0 Then
                    .Item(0, e.RowIndex).Value = Not CBool(.Item(0, e.RowIndex).Value)
                End If
            End If
        End With
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles SelectAll_pb.Click
        With Grd()

            For i = 0 To .RowCount - 1
                .Item(0, i).Value = Not CBool(.Item(0, i).Value)
            Next
        End With
    End Sub
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles Request_pb.Click
        Debut = False
        Request()
    End Sub
End Class