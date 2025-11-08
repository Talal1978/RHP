Imports DevComponents.AdvTree
Imports DevComponents.DotNetBar
Public Class Zoom_Profile_Scripts
    Dim Ecran As String = ""
    Friend CodProfile As String = ""
    Friend oNod As New Node
    Dim oTable As New DataTable
    Dim oMenuImageArray As New ImageList

    Private Sub Zoom_Profile_Scripts_Load(sender As Object, e As EventArgs) Handles Me.Load
        oMenuImageArray.Images.Add(My.Resources.fleche)
        Ecran = oNod.Name
        If oNod.Tag(1) Is Nothing Then
            Dim Cod_Sql1 As String = "SELECT     Name_Ecran, Text_controle, Name_Controle, 
       isnull((Select Visible from Controle_Droit_Avance where Cod_Profile='" & CodProfile &
      "' And name_controle=f.name_controle And Name_Ecran=f.Name_Ecran),'False') as Visible 
      , isnull((select Actif from Controle_Droit_Avance where Cod_Profile='" & CodProfile &
      "' and name_controle=f.name_controle  and Name_Ecran=f.Name_Ecran),'False') as  Actif 
       FROM    Controle_Menu_Avance f where isnull(Name_Ecran,'')='" & Ecran & "' and isnull(Typ_Security,'') in ('SN','SC','XX') and isnull(Name_Controle,'')<>''"
            oTable = DATA_READER_GRD(Cod_Sql1)
            With oTable
                .Columns("Visible").ReadOnly = False
                .Columns("Actif").ReadOnly = False
            End With
        Else
            oTable = oNod.Tag(1)
        End If
        With Adv
            Dim nRows() As DataRow
            nRows = oTable.Select("[Name_Ecran]='" & Ecran & "'")
            Adv.Nodes(0).Nodes(0).Nodes.Clear()
            For i = 0 To nRows.Length - 1
                Dim N As New Node
                With N
                    .Name = nRows(i)("Name_Controle")
                    .Text = IsNull(nRows(i)("Text_controle"), nRows(i)("Name_Controle"))
                    .Cells.Add(New Cell)
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = True
                    .Cells(2).CheckBoxVisible = True
                    .Cells(1).Checked = CBool(nRows(i)("Visible"))
                    .Cells(2).Checked = CBool(nRows(i)("Actif"))
                    .ImageIndex = 0
                End With
                Adv.Nodes(0).Nodes(0).Nodes.Add(N)
            Next
        End With
    End Sub
    Private Sub Zoom_Profile_Scripts_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim wNd As New Node
        With oTable
            For i = 0 To .Rows.Count - 1
                wNd = Adv.FindNodeByName(.Rows(i).Item("Name_Controle"))
                .Rows(i).Item("Visible") = wNd.Cells(1).Checked
                .Rows(i).Item("Actif") = wNd.Cells(2).Checked
            Next
        End With
        oNod.Tag(1) = oTable
    End Sub
    Private Sub Adv_NodeClick(sender As Object, e As TreeNodeMouseEventArgs) Handles Adv.NodeClick
        If e.Node.SelectedCell Is Nothing Then Return
        Dim Indx As Integer = e.Node.Cells.IndexOf(e.Node.SelectedCell)
        Dim oBool As Boolean = e.Node.SelectedCell.Checked
        If e.Node.Nodes.Count > 0 Then
            Checking(e.Node, Indx, oBool)
        ElseIf e.Node.Parent IsNot Nothing Then
            If e.Node.Parent.Cells.Count > 1 Then
                e.Node.Parent.Cells(Indx).Checked = IsChecked(e.Node.Parent, Indx)
            End If
        End If
    End Sub
    Sub Checking(oNd As Node, Indx As Integer, obool As Boolean)
        For Each a As Node In oNd.Nodes
            a.Cells(Indx).Checked = obool
            If a.Nodes.Count > 0 Then
                Checking(a, Indx, obool)
            End If
        Next
    End Sub
    Function IsChecked(oNd As Node, Indx As Integer) As Boolean
        Dim nb As Integer = 0
        For i = 0 To oNd.Nodes.Count - 1
            If oNd.Nodes(i).Cells(Indx).Checked Then
                nb += 1
            End If
        Next
        Return (nb = oNd.Nodes.Count)
    End Function

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class