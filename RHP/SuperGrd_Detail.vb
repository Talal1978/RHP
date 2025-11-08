Imports DevComponents.DotNetBar.Controls
Public Class SuperGrd_Detail
    Inherits Panel
#Region "Variables"
    Friend childGrid As New List(Of DataGridViewX)
#End Region
#Region "Populate Childview"
    Friend Sub Add(ByVal tableName As DataTable)
        Dim newGrid As New DataGridViewX With {.Dock = DockStyle.Fill, .DataSource = New DataView(tableName)}
        Me.Controls.Add(newGrid)
        applyGridTheme(newGrid)
        setGridRowHeader(newGrid)
        AddHandler newGrid.RowPostPaint, AddressOf rowPostPaint_HeaderCount
        newGrid.Columns(0).Visible = False
        childGrid.Add(newGrid)
    End Sub
#End Region

End Class
