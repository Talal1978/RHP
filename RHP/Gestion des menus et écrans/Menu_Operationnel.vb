Public Class Menu_Operationnel
    Dim _switch As Boolean = True
    Dim dicBtn As New Dictionary(Of String, ud_btn)
    Dim noSocieteCreated As Boolean = False
    Dim _swhere As String = ""
    Dim moduls As New ArrayList
    Private Sub Menu_Operationnel_Load(sender As Object, e As EventArgs) Handles Me.Load
        moduls.Add(AdminPersonel_ud)
        moduls.Add(Organisation_ud)
        moduls.Add(Setting_ud)
        moduls.Add(System_ud)
        AdminPersonel_ud.Enabled = (Tbl_Controle_Droit_Mnu.Select("Name_Ecran='1' and Visible='true'").Length > 0) 'False 
        Organisation_ud.Enabled = (Tbl_Controle_Droit_Mnu.Select("Name_Ecran='2' and Visible='true'").Length > 0) 'False 
        Setting_ud.Enabled = (Tbl_Controle_Droit_Mnu.Select("Name_Ecran='3' and Visible='true'").Length > 0) 'False 
        System_ud.Enabled = (Tbl_Controle_Droit_Mnu.Select("Name_Ecran='4' and Visible='true'").Length > 0) 'False 
        If AdminPersonel_ud.Enabled Then
            selectingModule(AdminPersonel_ud)
        ElseIf Organisation_ud.Enabled Then
            selectingModule(Organisation_ud)
        ElseIf Setting_ud.Enabled Then
            selectingModule(Setting_ud)
        ElseIf System_ud.Enabled Then
            selectingModule(System_ud)
        End If
        getRecents()
    End Sub
    Sub getRecents()
        Plx_Recents.Controls.Clear()
        Plx_Frequents.Controls.Clear()
        Dim nb As Integer = 1
        Dim accesRapid() = IsNull(_localParams.recents, "").Split(";")
        Dim frequents = IsNull(_localParams.frequents, "").Split(";").GroupBy(Function(x) x).Select(Function(g) New With {.element = g.Key, .count = g.Count}).OrderByDescending(Function(y) y.count).ToArray
        For i = 0 To accesRapid.Length - 1
            If nb < 5 Then
                Dim nrw() = Tbl_Controle_Droit_Mnu.Select("Name_Ecran='" & accesRapid(i) & "' and Visible='true'")
                If (nrw.Length > 0) Then
                    Dim ud As New ud_CardItem
                    Dim obj As Object = My.Resources.ResourceManager.GetObject(If(nrw(0)("Image1").ToString.ToUpper.StartsWith("UD_"), nrw(0)("Image1"), "xxxxx"))
                    If obj Is Nothing Then
                        obj = My.Resources.ud_star
                    End If
                    With ud
                        .Name = nrw(0)("Name_Ecran")
                        .Titre = nrw(0)("Text_Ecran")
                        .Image = obj
                        .isSelected = False
                        .Location = New Point(3 + (nb - 1) * 177, 21)
                        Plx_Recents.Controls.Add(ud)
                        AddHandler .Click, Sub()
                                               openLink(nrw(0)("Name_Ecran"), nrw(0)("Text_Ecran"), nrw(0)("Typ_Ecran"))
                                           End Sub
                        nb += 1
                    End With
                End If
            End If
        Next
        nb = 1
        For i = 0 To frequents.Count - 1
            If nb < 5 Then
                Dim nrw() = Tbl_Controle_Droit_Mnu.Select("Name_Ecran='" & frequents(i).element & "' and Visible='true'")
                If (nrw.Length > 0) Then
                    Dim ud As New ud_CardItem
                    Dim obj As Object = My.Resources.ResourceManager.GetObject(If(nrw(0)("Image1").ToString.ToUpper.StartsWith("UD_"), nrw(0)("Image1"), "xxxxx"))
                    If obj Is Nothing Then
                        obj = My.Resources.ud_star
                    End If
                    With ud
                        .Name = nrw(0)("Name_Ecran")
                        .Titre = nrw(0)("Text_Ecran")
                        .Image = obj
                        .isSelected = False
                        .Location = New Point(3 + (nb - 1) * 177, 21)
                        Plx_Frequents.Controls.Add(ud)
                        AddHandler .Click, Sub()
                                               openLink(nrw(0)("Name_Ecran"), nrw(0)("Text_Ecran"), nrw(0)("Typ_Ecran"))
                                           End Sub
                        nb += 1
                    End With
                End If
            End If
        Next
    End Sub
    Private Sub AdminPersonel_ud_Click(sender As Object, e As EventArgs) Handles AdminPersonel_ud.Click, Organisation_ud.Click, Setting_ud.Click, System_ud.Click
        selectingModule(sender)
    End Sub
    Sub TreeviewMaj(nd As TreeNode)
        Dim nrw() As DataRow = Tbl_Controle_Droit_Mnu.Select("[Parent]='" & nd.Name & "'", "Rang Asc")
        For i = 0 To nrw.Length - 1
            Dim _nd As New TreeNode
            With _nd
                .Name = nrw(i)("Name_Ecran")
                .Text = nrw(i)("Text_Ecran")
                .Tag = nrw(i)("Typ_Ecran")
                Dim crw() As DataRow = Tbl_Controle_Droit_Mnu.Select("[Parent]='" & _nd.Name & "'", "Rang Asc")
                .ForeColor = If(crw.Length > 0, colorBase01, Trv.ForeColor)
                .ToolTipText = nrw(i)("Text_Ecran")
                .ImageIndex = 5 + Array.IndexOf("FDR;ECR;QRY;RPT".Split(";"), nrw(i)("Typ_Ecran"))
                .SelectedImageIndex = If(.ImageIndex = 6, 9, .ImageIndex)
                If crw.Length > 0 Then
                    TreeviewMaj(_nd)
                End If
            End With
            nd.Nodes.Add(_nd)

        Next
    End Sub
    Private Sub Trv_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles Trv.DrawNode
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
    Sub selectingModule(sender As ud_CardItem)
        If sender Is Nothing Then Return
        AdminPersonel_ud.isSelected = (sender Is AdminPersonel_ud)
        Organisation_ud.isSelected = (sender Is Organisation_ud)
        Setting_ud.isSelected = (sender Is Setting_ud)
        System_ud.isSelected = (sender Is System_ud)
        With Trv
            With .Nodes(0)
                .Nodes.Clear()
                .ImageIndex = moduls.IndexOf(sender)
                .SelectedImageIndex = .ImageIndex
                .Text = sender.Titre.ToString.Replace("&&", "&")
                .Name = CStr(moduls.IndexOf(sender) + 1)
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
            openLink(.SelectedNode.Name, .SelectedNode.Text, .SelectedNode.Tag)
        End With

    End Sub
    Private Sub FicheSociete_ud_Click(sender As Object, e As EventArgs)
        Dim f As New DB_Societe
        newShowEcran(f)
    End Sub

    Private Sub FicheSociete_ud_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub FicheAgent_ud_Click(sender As Object, e As EventArgs)
        Dim f As New RH_Agent
        newShowEcran(f)
    End Sub

    Private Sub Periode_ud_Click(sender As Object, e As EventArgs)
        Dim f As New Param_Periode_Paie
        With f
            newShowEcran(f)
        End With
    End Sub

    Private Sub Payroll_ud_Click(sender As Object, e As EventArgs)
        Dim f As New RH_Preparation_Paie
        With f
            newShowEcran(f)
        End With
    End Sub

    Private Sub Menu_Operationnel_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        getRecents()
    End Sub
End Class



