Public Class Zoom_GPEC_Domaines_Competence
    Friend domaines As New List(Of String)
    Dim oSize As New Size
    Dim oLoc As New Point
    Dim TblSource As New DataTable
    Dim dictionary As New Dictionary(Of String, Double)
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
        dictionary = stringToDictionary(String.Join(";", domaines))
        Dim swhere = String.Join(",", dictionary.Keys)
        Dim Cod_Sql As String = $" declare @str varchar(max),@idSoc int
 set @str= '{swhere}'
 set @idSoc={Societe.id_Societe}
  ;with Tbl (Competence, Intitule, Parent,Domaine ,Rang,Niveau)
 as (
 select Domaines_Competence, convert(varchar(max), char(149)+'  ' +Lib_Domaines_Competence), isnull(nullif(Parent,''),id_Societe) as Parent,Lib_Domaines_Competence,
 convert(nvarchar(1000),right('000'+convert(nvarchar(10),Rang),3)) as Rang , 0 as Niveau 
 from  GPEC_Domaines_Competence 
 where id_Societe=@idSoc  and isnull(Parent,'')=''
 union all
  select  c.Domaines_Competence, convert(varchar(max), Replicate('     ',Niveau+1)+' >  '+Lib_Domaines_Competence), c.Parent as Parent,t.Domaine,
  convert(nvarchar(1000),t.Rang+ right('000'+convert(nvarchar(50),c.Rang),3)),Niveau+1
 from  GPEC_Domaines_Competence c inner join Tbl t on isnull(c.Parent,'')= t.Competence
 where id_Societe=@idSoc )
select convert(bit,case when ','+@str+',' like '%,'+Competence+',%' then 1 else 0 end) as 'Check', Competence,Intitule as Compétence,Domaine,Niveau,Parent
from  Tbl
order by Rang"
        TblSource = DATA_READER_GRD(Cod_Sql)
        With Grd()
            If TblSource.Rows.Count > 50 Then
                .DataSource = TblSource.AsEnumerable.Take(50).CopyToDataTable
            Else
                .DataSource = TblSource
            End If
            .Columns("Check").HeaderText = "     "
            TblSource.Columns("Check").ReadOnly = False
            .Columns("Parent").Visible = False
            .Columns("Niveau").Visible = False
            .Columns("Competence").Visible = False
            .Columns("Compétence").MinimumWidth = 400
            .Columns("Compétence").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .AlternatingRowsDefaultCellStyle = Nothing
            Grd.setFilter({0, 1, 2, 3})
        End With
    End Sub
    Private Sub myDataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Grd.CellFormatting
        ' Check if we're formatting cells in the first column (index 0)
        With Grd
            If .Columns.Count = 0 Then Return
            If .Rows.Count = 0 Then Return
            If e.ColumnIndex = 2 Then
                Dim nrw() As DataRow = TblSource.Select($"[Parent]='{ .Item(1, e.RowIndex).Value}'")
                If IsNull(e.Value, "").StartsWith(Chr(149)) Then
                    e.CellStyle.Font = New Font("Century Gothic", 8.5!, FontStyle.Bold)
                    e.CellStyle.ForeColor = colorBase01
                ElseIf nrw.Length > 0 Then
                    e.CellStyle.Font = New Font("Century Gothic", 8.0!)
                    e.CellStyle.ForeColor = colorBase03
                ElseIf IsNull(e.Value, "").StartsWith("           >  ") Then
                    e.CellStyle.Font = New Font("Century Gothic", 8.0!)
                    e.CellStyle.ForeColor = Grd.DefaultCellStyle.ForeColor
                Else
                    e.CellStyle.ForeColor = Color.FromArgb(64, 64, 64)
                End If
            End If
        End With

    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub Confirm_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_pb.Click
        With Grd
            domaines.Clear()
            For i = 0 To .RowCount - 1
                Dim comp = IsNull(.Item("Competence", i).Value, "")
                If CBool(.Item(0, i).Value) And comp.Trim <> "" Then
                    If dictionary.ContainsKey(comp) Then
                        domaines.Add(comp & "$" & dictionary(comp))
                    Else
                        domaines.Add(comp & "$" & "1")
                    End If
                End If
            Next
        End With
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
        Request()
    End Sub
End Class