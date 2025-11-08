Public Class Menu_System
    Dim _switch As Boolean = True
    Dim dicBtn As New Dictionary(Of String, ud_btn)
    Dim noSocieteCreated As Boolean = False
    Dim _swhere As String = ""
    Sub TreeviewMaj(nd As TreeNode)
        Dim nrw() As DataRow = Tbl_Controle_Droit_Mnu.Select("[Parent]='" & nd.Name & "'", "Rang Asc")
        For i = 0 To nrw.Length - 1
            Dim _nd As New TreeNode
            With _nd
                .Name = nrw(i)("Name_Ecran")
                .Text = nrw(i)("Text_Ecran")
                .Tag = nrw(i)("Typ_Ecran")
                Dim crw() As DataRow = Tbl_Controle_Droit_Mnu.Select("[Parent]='" & _nd.Name & "'", "Rang Asc")
                .ForeColor = If(crw.Length > 0, colorBase01, Color.Gray)
                .ToolTipText = nrw(i)("Text_Ecran")
                .ImageIndex = 2 + Array.IndexOf("FDR;ECR;QRY;RPT".Split(";"), nrw(i)("Typ_Ecran"))
                .SelectedImageIndex = .ImageIndex
                If crw.Length > 0 Then
                    TreeviewMaj(_nd)
                End If
            End With
            nd.Nodes.Add(_nd)

        Next
    End Sub
    Private Sub Trv_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles Trv.DrawNode
        Dim maxW As Integer = 0
        Dim ndCadre As Rectangle = New Rectangle(e.Bounds.X, e.Bounds.Y, Trv.Width - e.Bounds.X - 10, e.Bounds.Height)
        Dim fontToUse As Font = If(e.Node.NodeFont IsNot Nothing, e.Node.NodeFont, e.Node.TreeView.Font)
        Dim ndText As Rectangle = New Rectangle(e.Bounds.X, e.Bounds.Top + (e.Bounds.Height - fontToUse.Height) / 2, e.Bounds.Width + 95, e.Bounds.Height - 6)
        If (e.State And TreeNodeStates.Selected) <> 0 Then
            ' Draw the background for selected node
            e.Graphics.FillRectangle(Brushes.LightBlue, ndCadre)
        Else
            ' Draw the background for other nodes
            e.Graphics.FillRectangle(Brushes.White, ndCadre)
        End If
        Dim br As New SolidBrush(e.Node.ForeColor)
        ' Draw node text
        e.Graphics.DrawString(e.Node.Text, fontToUse, br, ndText)

        ' Prevent default drawing
        e.DrawDefault = False
    End Sub
    Sub selectingModule()
        Dim nrw() As DataRow = Tbl_Controle_Droit_Mnu.Select("Name_Ecran='4'")
        Dim txt As String = If(nrw.Length > 0, nrw(0)("Text_Ecran"), "Système")
        With Trv
            With .Nodes(0)
                .Nodes.Clear()
                .ImageIndex = 0
                .SelectedImageIndex = .ImageIndex
                .Text = txt.Replace("&&", "&")
                .Name = "4"
                .ExpandAll()
            End With
            TreeviewMaj(.Nodes(0))
            .ExpandAll()
            .Nodes(0).EnsureVisible()
        End With

    End Sub
    Private Sub Trv_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Trv.MouseDoubleClick
        With Trv
            If .SelectedNode Is Nothing Then Return
            If .SelectedNode.Nodes.Count > 0 Then Return
            Select Case .SelectedNode.Tag
                Case "ECR"
                    Dim frm As Form = GetFormByName(.SelectedNode.Name)
                    If frm Is Nothing Then Return
                    newShowEcran(frm)
                Case "RPT"
                    Dim f As New Param_Modele_Edition_Saisi
                    f.Text = Text
                    f.Report_Generator(.SelectedNode.Name, .SelectedNode.Text)
                    newShowEcran(f)
                Case "QRY", "CHR", "TRT", "EXP"
                    Dim f As New Param_Query_Saisi
                    f.Text = Text
                    f.Query_Generator(.SelectedNode.Name, .SelectedNode.Text)
                    newShowEcran(f)
                Case "SYS"
                    Dim frm As Form = GetFormByName(.SelectedNode.Name)
                    If frm Is Nothing Then Return
                    frm.ShowDialog()
            End Select


        End With

    End Sub

    Private Sub Menu_System_Load(sender As Object, e As EventArgs) Handles Me.Load
        selectingModule()
    End Sub
End Class



