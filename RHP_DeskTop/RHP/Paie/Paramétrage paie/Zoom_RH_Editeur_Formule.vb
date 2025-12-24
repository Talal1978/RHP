Imports System.Text.RegularExpressions
Public Class Zoom_RH_Editeur_Formule
    Friend myVBS As New vsEngine
    Friend xwhere As String = ""
    Friend CodRubrique As String = ""
    Friend TypRetour As String = ""
    Friend otxt As New ud_TextBox
    Friend formulafunction As String = ""
    Dim dicMaskedNodes As New Dictionary(Of TreeNode, TreeNode)
    Dim TblTrv As DataTable = DATA_READER_GRD("select * from RH_Elements_Paie where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe)
    Dim nRows() As DataRow
    Dim TblTitre As DataTable = DATA_READER_GRD("select Valeur,Membre from Param_Rubriques where Nom_Controle='Function' order by Rang")
    Sub FunctionTrvMAJ()
        Building_Sys_RH_Agent_AG()
        If TblTrv.Rows.Count = 0 Then TblTrv = DATA_READER_GRD("select * from RH_Elements_Paie where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe & xwhere & " order by  Cod_Function, Lib_Function")
        With TblTitre
            Function_Trv.Nodes(0).Nodes.Clear()
            Function_Trv.Nodes(1).Nodes.Clear()
            Function_Trv.Nodes(2).Nodes.Clear()
            Function_Trv.Nodes(3).Nodes.Clear()
            Function_Trv.Nodes(4).Nodes.Clear()
            Function_Trv.Nodes(5).Nodes.Clear()
            For i = 0 To .Rows.Count - 1
                Dim m As New TreeNode
                With m
                    .Name = TblTitre.Rows(i).Item("Valeur")
                    .Text = TblTitre.Rows(i).Item("Membre")
                    Function_Trv.Nodes(Gauche(.Name, 2)).Nodes.Add(m)
                End With

                nRows = TblTrv.Select("[Groupe_Function]='" & TblTitre.Rows(i).Item("Valeur") & "'", "Cod_Function, Lib_Function")
                For j = 0 To nRows.Length - 1
                    Dim n As New TreeNode
                    With n
                        .Name = nRows(j).Item("Cod_Function")
                        .ToolTipText = nRows(j).Item("Lib_Function")
                        .Text = nRows(j).Item("Cod_Function") & " : " & nRows(j).Item("Lib_Function")
                        .Tag = IIf("EP_ElPaie;AG_Agent".Split(";").Contains(TblTitre.Rows(i).Item("Valeur")), nRows(j).Item("Cod_Function"), IsNull(nRows(j).Item("Abr_Function"), nRows(j).Item("Cod_Function")))
                        .ForeColor = Color.Gray
                    End With
                    m.Nodes.Add(n)
                Next
            Next
        End With
        Function_Trv.Nodes(2).ExpandAll()
    End Sub
    Private Sub Function_Trv_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Function_Trv.MouseMove
        Dim theNode As TreeNode = Function_Trv.GetNodeAt(e.X, e.Y)

        ' Check if mouse is paused over an actual node.
        If Not (theNode Is Nothing) Then
            ' Only update the ToolTip if tip needs to be changed.
            If (theNode.ToolTipText <> ToolTip1.GetToolTip(Function_Trv) And theNode.Tag IsNot Nothing) Then
                ToolTip1.SetToolTip(Function_Trv, theNode.ToolTipText)
            End If
        Else
            ' Mouse is not paused over a node. Therefore, clear the ToolTip.
            ToolTip1.SetToolTip(Function_Trv, "")
        End If
    End Sub
    Private Sub Function_Trv_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Function_Trv.NodeMouseDoubleClick
        If CodRubrique = IsNull(Function_Trv.SelectedNode.Tag, "") Then
            MessageBoxRHP(691)
            Exit Sub
        End If
        With Formule_Function_Text
            .Select()
            Dim SelPos As Integer = Formule_Function_Text.SelectionStart
            Dim ValeurNode As String = " " & Function_Trv.SelectedNode.Tag & " "
            .Text = Formule_Function_Text.Text.Insert(SelPos, ValeurNode)
            .Select()
            .SelectionStart = SelPos + ValeurNode.Length
        End With
    End Sub
    Private Sub Formule_Function_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Formule_Function_Text.TextChanged
        Resultat.Text = ""
        Dim oRw() As DataRow = Nothing
        Dim rg As New Regex("\b(\w+)\b", RegexOptions.IgnoreCase)
        With Formule_Function_Text
            Dim selpos As Integer = .SelectionStart
            For Each c As Match In rg.Matches(.Text)
                .Select(c.Index, c.Length)
                oRw = TblTrv.Select("[Cod_Function] = '" & c.Value & "'")
                If oRw.Length > 0 Then
                    .SelectionColor = getFunctionColor(oRw(0).Item("Typ_Function"))
                Else
                    .SelectionColor = Color.Black
                End If
            Next
            .SelectionStart = selpos
            .SelectionLength = 0
        End With
    End Sub
    Private Sub Save_D_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        If TypRetour = "" Then
            ShowMessageBox("Type retour non renseigné", "Compilation", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Try
            Dim strFunction As String = TraitementCaractere(Formule_Function_Text.Text)
            Dim f As New Zoom_RH_Saisie_EV
            With f
                .myVBS = myVBS
                .silentMode = Societe.LeMatricule <> ""
                If .silentMode Then
                    .Save_D_Click(Nothing, Nothing)
                Else
                    .ShowDialog()
                End If
            End With
            Select Case TypRetour
                Case "bit"
                    Resultat.Text = CBool(myVBS.Eval(strFunction))
                Case "smalldatetime"
                    Resultat.Text = EstDate(myVBS.Eval(strFunction))
                Case "int"
                    Resultat.Text = CInt(myVBS.Eval(strFunction))
                Case "float"
                    Resultat.Text = CDbl(myVBS.Eval(strFunction))
                Case Else
                    Resultat.Text = myVBS.Eval(strFunction)
            End Select

            otxt.Text = Formule_Function_Text.Text
            Me.Close()
        Catch ex As Exception
suite:
            Resultat.Text = "#ERR : " & vbCrLf & ex.Message
            Formule_Function_Text.Select()
            Return
        End Try

    End Sub

    Private Sub Zoom_RH_Editeur_Formule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FunctionTrvMAJ()
        Formule_Function_Text.Text = formulafunction
        Function_Trv.ExpandAll()

    End Sub
    Private Sub Simuler_D_Click(sender As Object, e As EventArgs) Handles Simuler_pb.Click
        If TypRetour = "" Then
            ShowMessageBox("Type retour non renseigné")
            Return
        End If
        Dim f As New Zoom_RH_Saisie_EV
        With f
            .myVBS = myVBS
            .silentMode = Societe.LeMatricule <> ""
            If .silentMode Then
                .Save_D_Click(Nothing, Nothing)
            Else
                .ShowDialog()
            End If
        End With
        Dim strFunction As String = TraitementCaractere(Formule_Function_Text.Text)
        Try
            Resultat.Text = myVBS.Eval(strFunction)
        Catch ex As Exception
            Resultat.Text = ex.Message
        End Try
    End Sub
    Private Sub EvaluerLaValeurDeLaVariableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EvaluerLaValeurDeLaVariableToolStripMenuItem.Click
        With Function_Trv
            If .SelectedNode Is Nothing Then Return
            Dim elm As String = .SelectedNode.Name
            Dim oRw() As DataRow = TblTrv.Select("Cod_Function='" & elm & "'")
            If oRw.Length = 0 Then Return
            If IsNull(oRw(0)("Typ_Function"), "FS") = "FS" Then Return
            Dim f As New Zoom_RH_Saisie_EV
            With f
                .myVBS = myVBS
                .silentMode = Societe.LeMatricule <> ""
                If .silentMode Then
                    .Save_D_Click(Nothing, Nothing)
                Else
                    .ShowDialog()
                End If
            End With
            Try
                ShowMessageBox("La valeur de l'élément [" & .SelectedNode.Text & "] est : " & vbCrLf & myVBS.Eval(.SelectedNode.Name), "Evaluer une valeur", MessageBoxButtons.OK, msgIcon.Information)
            Catch ex As Exception
                ShowMessageBox(ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)
            End Try

        End With
    End Sub
    Private Sub Rechercher_txt_TextChanged(sender As Object, e As EventArgs) Handles Rechercher_txt.TextChanged
        Dim txt As String = Rechercher_txt.Text.Replace("'", "''").Trim()
        With TblTrv
            For i = 0 To .Rows.Count - 1
                Dim nd() As TreeNode = Function_Trv.Nodes.Find(.Rows(i)("Cod_Function"), True)
                If nd.Length > 0 Then
                    'masquer les nodes affiché ne répondant pas à la recherche
                    If TblTrv.Select("(Cod_Function='" & nd(0).Name & "') and (Cod_Function like '%" & txt & "%' or Lib_Function like '%" & txt & "%' or Abr_Function like '%" & txt & "%') ").Length = 0 Then
                        dicMaskedNodes.Add(nd(0), nd(0).Parent)
                        nd(0).Remove()
                    End If
                Else
                    'Afficher les nodes masqués répondant à la recherche
                    Dim nrw() As DataRow = TblTrv.Select("(Cod_Function='" & .Rows(i)("Cod_Function") & "') and (Cod_Function like '%" & txt & "%' or Lib_Function like '%" & txt & "%' or Abr_Function like '%" & txt & "%') ")
                    If nrw.Length > 0 Then
                        For Each n As TreeNode In dicMaskedNodes.Keys
                            If n.Name = nrw(0)("Cod_Function") Then
                                dicMaskedNodes(n).Nodes.Add(n)
                                dicMaskedNodes.Remove(n)
                                n.EnsureVisible()
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub Actualiser_D_Click(sender As Object, e As EventArgs) Handles Actualiser_pb.Click
        Building_Sys_RH_Agent_AG()
        If TypRetour = "" Then
            ShowMessageBox("Type retour non renseigné")
            Return
        End If
        Dim f As New Zoom_RH_Saisie_EV
        With f
            .myVBS = myVBS
            Societe.LeMatricule = ""
            .ShowDialog()
        End With
        Dim strFunction As String = TraitementCaractere(Formule_Function_Text.Text)
        Try
            Resultat.Text = myVBS.Eval(strFunction)
        Catch ex As Exception
            Resultat.Text = ex.Message
        End Try
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class