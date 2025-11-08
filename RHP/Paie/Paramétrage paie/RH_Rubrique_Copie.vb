Public Class RH_Rubrique_Copie
    Friend Code As String = ""
    ' Dim ArrRub, ArrTypFunc, ArrTypFuncColor As New ArrayList
    Dim TblFunction As New DataTable
    Dim dicColor As New Dictionary(Of String, ArrayList)
    Dim dicRub As New Dictionary(Of String, TreeNode)
    Dim dicErr As New Dictionary(Of TreeNode, String)
    Dim Img As New ImageList
    Private Sub RH_Parametrage_Plan_Paie_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Reset_Form(Me)
    End Sub
    Private Sub RH_Parametrage_Plan_Paie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If dicColor.Count = 0 Then dicColor = setGroupFunctionColor()
        MajTreeView()
        With Img
            .ColorDepth = ColorDepth.Depth32Bit
            .TransparentColor = Color.White
            .ImageSize = New Size(16, 16)
            .Images.Add(My.Resources.Blank)
            .Images.Add(My.Resources.success)
            .Images.Add(My.Resources.erreur)
        End With
        FunctionOri_Trv.ImageList = Img
        id_Societe_Des_txt.Text = Societe.id_Societe
    End Sub
    Sub MajTreeView()
        dicRub.Clear()
        FunctionOri_Trv.ExpandAll()
        Dim nRows() As DataRow
        Dim TblTitre As DataTable = DATA_READER_GRD("select Valeur,Membre from Param_Rubriques where Nom_Controle='Function' and  isnull( Valeur,'') not like 'FS%' and isnull(Valeur,'') not in ('FU_Cumul','EP_ElPaie')  order by Rang")
        TblFunction = DATA_READER_GRD("select Typ_Function,Cod_Function,Lib_Function,Lib_Abr ,Lib_Typ_Function,Groupe_Function,Typ_Retour
from dbo.RH_Elements_Paie e
outer apply(select Membre as Lib_Typ_Function from Param_Rubriques where Nom_Controle='Typ_Function' and Valeur=e.Typ_Function) f
where  Typ_Function not in('FS','RC','EP') and id_Societe=" & IsNull(id_Societe_Org_txt.Text, -999))
        With TblTitre
            FunctionOri_Trv.Nodes(0).Nodes.Clear()
            FunctionOri_Trv.Nodes(1).Nodes.Clear()
            FunctionOri_Trv.Nodes(2).Nodes.Clear()
            For i = 0 To .Rows.Count - 1
                Dim m As New TreeNode
                With m
                    .Name = TblTitre.Rows(i).Item("Valeur")
                    .Text = TblTitre.Rows(i).Item("Membre")
                    .ForeColor = dicColor(IsNull(.Name, ""))(0)
                    Select Case Gauche(.Name, 2)
                        Case "FU"
                            FunctionOri_Trv.Nodes(2).Nodes.Add(m)
                        Case "RB"
                            FunctionOri_Trv.Nodes(0).Nodes.Add(m)
                        Case "AG"
                            FunctionOri_Trv.Nodes(1).Nodes.Add(m)
                    End Select
                End With
                nRows = TblFunction.Select("[Groupe_Function]='" & TblTitre.Rows(i).Item("Valeur") & "' and Typ_Retour in ('int','float') ", "Lib_Function Asc")
                For j = 0 To nRows.Length - 1
                    Dim n As New TreeNode
                    With n
                        .Name = nRows(j).Item("Cod_Function")
                        .Text = .Name & " : " & nRows(j).Item("Lib_Function")
                        .Tag = "Var"
                        .ForeColor = Color.Gray
                        .SelectedImageIndex = .ImageIndex
                        dicRub.Add(.Name, n)
                    End With
                    m.Nodes.Add(n)
                Next
                m.ExpandAll()
            Next
        End With
        FunctionOri_Trv.ExpandAll()
    End Sub
    Sub UncheckTrv(Nd As TreeNode)
        Nd.Checked = False
        For Each a As TreeNode In Nd.Nodes
            UncheckTrv(a)
        Next
    End Sub
    Sub Enregistrer()
        If id_Societe_Des_txt.Text = "0" Then Return
        Saving()
    End Sub

    Sub Nouveau()
        id_Societe_Org_txt.ResetText()
        id_Societe_Des_txt.ResetText()
    End Sub

    Private Sub Id_Societe_Org_txt_TextChanged(sender As Object, e As EventArgs) Handles id_Societe_Org_txt.TextChanged
        Lib_Societe_Org_txt.Text = FindLibelle("Den", "id_Societe", id_Societe_Org_txt.Text, "Param_Societe")
        MajTreeView()
    End Sub
    Private Sub Id_Societe_Des_txt_TextChanged(sender As Object, e As EventArgs) Handles id_Societe_Des_txt.TextChanged
        Lib_Societe_Des_txt.Text = FindLibelle("Den", "id_Societe", id_Societe_Des_txt.Text, "Param_Societe")
        FunctionDes_Trv.Nodes(0).Nodes.Clear()
        FunctionDes_Trv.Nodes(1).Nodes.Clear()
        FunctionDes_Trv.Nodes(2).Nodes.Clear()
    End Sub

    Private Sub Cod_Plan_Paie__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Plan_Paie_.LinkClicked
        If id_Societe_Des_txt.Text = "0" Then Return
        Appel_Zoom1("MS014", id_Societe_Org_txt, Me, "id_Societe<>" & Societe.id_Societe)
    End Sub
    Function FindNodeByName(NdName As String, bN As TreeNode, Optional Trv As TreeView = Nothing) As TreeNode
        If Trv Is Nothing Then Trv = bN.TreeView
        For Each a As TreeNode In Trv.Nodes
            If a.Name.ToUpper.Trim = NdName.ToUpper.Trim Then
                bN = a
            ElseIf bN Is Nothing Then
                For Each nd As TreeNode In a.Nodes
                    If bN Is Nothing Then
                        bN = FindNodeByNameChild(nd, NdName, bN)
                    Else
                        Return bN
                        Exit Function
                    End If
                Next
            End If
        Next
        Return bN
    End Function
    Function FindNodeByNameChild(Nod As TreeNode, NdName As String, bn As TreeNode) As TreeNode
        If Not bn Is Nothing Then
            Return bn
            Exit Function
        End If
        If Nod.Name.ToUpper.Trim = NdName.ToUpper.Trim Then
            bn = Nod
        Else
            For Each nd As TreeNode In Nod.Nodes
                bn = FindNodeByNameChild(nd, NdName, bn)
            Next
        End If
        Return bn
    End Function
    Sub Saving()
        Try
            If id_Societe_Org_txt.Text.Trim = "" Then
                ShowMessageBox("Veuillez choisir la société origine", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            If id_Societe_Des_txt.Text.Trim = "" Then
                ShowMessageBox("Veuillez choisir la société destinataire", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            Dim nod, nodC, ndPar, nbPar0, ndParC As New TreeNode
            Dim SqlStr As String = ""
            Dim swhere As String = ""
            Dim dicDes As New Dictionary(Of String, TreeNode)
            Dim TblDes As New DataTable
            TblDes = DATA_READER_GRD("select * from RH_Elements_Paie where id_Societe=" & id_Societe_Des_txt.Text)
            For i = 0 To dicRub.Count - 1
                nod = dicRub.ElementAt(i).Value
                If nod.Checked Then
                    If Not nod.Parent Is Nothing Then
                        If FindNodeByName(nod.Name, Nothing, FunctionDes_Trv) Is Nothing Then
                            ndPar = nod.Parent
                            If FindNodeByName(ndPar.Name, Nothing, FunctionDes_Trv) Is Nothing Then
                                ndParC = FindNodeByName(ndPar.Name, Nothing, FunctionOri_Trv).Clone
                                ndParC.Nodes.Clear()
                                FindNodeByName(ndPar.Parent.Name, Nothing, FunctionDes_Trv).Nodes.Add(ndParC)
                            End If
                            nodC = nod.Clone
                            nodC.Nodes.Clear()
                            FindNodeByName(ndPar.Name, Nothing, FunctionDes_Trv).Nodes.Add(nodC)
                            swhere &= IIf(swhere = "", "", ";") & nod.Name
                            dicDes.Add(nodC.Name, nodC)
                        End If
                    End If
                End If
            Next
            If swhere = "" Then
                ShowMessageBox("Aucun élément à reproduire dans la société destinataire", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            SqlStr = "exec Sys_RH_Elements_Paie_Duplication " & id_Societe_Org_txt.Text & ", " & id_Societe_Des_txt.Text & ", '" & swhere & "'"
            CnExecuting(SqlStr)
            ' Régénration des éléments de la paie paie pour la societe destination
            SqlStr = "select * from RH_Elements_Paie where Cod_Function in ('" & swhere.Replace(";", "','") & "') and id_Societe=" & id_Societe_Des_txt.Text
            TblDes = DATA_READER_GRD(SqlStr)
            For i = 0 To dicDes.Count - 1
                nod = dicRub(dicDes.ElementAt(i).Key)
                nod.ImageIndex = IIf(TblDes.Select("Cod_Function='" & nod.Name & "'").Length > 0, 1, 2)
                nod.SelectedImageIndex = nod.ImageIndex
            Next

        Catch ex As Exception
            ShowMessageBox(ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)

        End Try
    End Sub
    Sub SelectTout()
        For Each c As TreeNode In FunctionOri_Trv.Nodes
            c.Checked = Not c.Checked
            CheckUncheck(c, c.Checked)
        Next
    End Sub
    Sub CheckUncheck(nd As TreeNode, obool As Boolean)
        For Each c As TreeNode In nd.Nodes
            c.Checked = obool
            CheckUncheck(c, obool)
        Next
    End Sub
    Private Sub Function_Trv_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FunctionOri_Trv.MouseMove
        Dim theNode As TreeNode = FunctionOri_Trv.GetNodeAt(e.X, e.Y)

        ' Check if mouse is paused over an actual node.
        If Not (theNode Is Nothing) Then
            ' Only update the ToolTip if tip needs to be changed.
            If (theNode.ToolTipText <> ToolTip1.GetToolTip(FunctionOri_Trv) And theNode.Tag IsNot Nothing) Then
                ToolTip1.SetToolTip(FunctionOri_Trv, theNode.ToolTipText)
            End If
        Else
            ' Mouse is not paused over a node. Therefore, clear the ToolTip.
            ToolTip1.SetToolTip(FunctionOri_Trv, "")
        End If
    End Sub
    Private Sub FunctionOri_Trv_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles FunctionOri_Trv.AfterCheck
        Dim nd As TreeNode = e.Node
        If nd Is Nothing Then Return
        Dim obool As Boolean = nd.Checked
        For Each c As TreeNode In nd.Nodes
            c.Checked = obool
            CheckUncheck(c, obool)
        Next
    End Sub
End Class