Public Class Param_General
    Dim ParamTbl As New DataTable
    Private Sub Param_General_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ParamTbl = DATA_READER_GRD("select * from Param_General")
        Dim ImgList As New ImageList
        Dim ImArray As New ArrayList


        Param_TreeView.ImageList = ImgList
        Param_TreeView.ItemHeight = 19
        With ImgList
            ' .ImageSize = New Size(19, 19)
            .TransparentColor = Color.Transparent
            .ColorDepth = ColorDepth.Depth32Bit
            .Images.Add(My.Resources.openning)
            .Images.Add(My.Resources.Parametrage)
            .Images.Add(My.Resources.RH)

        End With
        With ImArray
            .Add(" ")
            .Add("Ges_Param")
            .Add("Ges_RH")
        End With

        Param_TreeView.Nodes("Param").ImageIndex = 0
        Param_TreeView.Nodes("Param").SelectedImageIndex = 0

        Dim Cod_Sql As String = "Select distinct Membre,Valeur from Param_Rubriques where Nom_Controle='Anglet_Param_General'"
        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                Dim N As New TreeNode
                N.Text = IsNull(.Rows(i).Item("Membre"), "")
                N.Name = IsNull(.Rows(i).Item("Valeur"), "")
                N.ImageIndex = ImArray.IndexOf(IsNull(.Rows(i).Item("Valeur"), ""))
                N.SelectedImageIndex = N.ImageIndex
                Param_TreeView.Nodes("Param").Nodes.Add(N)
            Next
        End With
        Param_TreeView.ExpandAll()
        Param_TreeView.Nodes("Param").ExpandAll()
        If Param_TreeView.Nodes.Count > 1 Then Param_TreeView.SelectedNode = Param_TreeView.Nodes("Ges_Ven")
    End Sub

    Sub Request()

        ModifierParamTbl()



        Dim oAnglet As String = Param_TreeView.SelectedNode.Name
        If Param_TreeView.SelectedNode.Name.Contains("Ges") Then
            ParamLabel.Text = "Paramètres Généraux \ " & Param_TreeView.SelectedNode.Text
            ParamLabel.Visible = True
        Else
            ParamLabel.Visible = False
        End If

        Param_GRD.Rows.Clear()
        With ParamTbl
            Dim C1, C2, C3, C4, C5, C6 As Object
            For i = 0 To .Rows.Count - 1
                If IsNull(.Rows(i).Item("Anglet"), "") = oAnglet Then
                    C1 = .Rows(i).Item("Cod_Param")
                    C2 = .Rows(i).Item("Libelle")
                    C3 = .Rows(i).Item("Valeur")
                    C4 = .Rows(i).Item("Type")
                    C5 = .Rows(i).Item("Typ_Param_General")
                    C6 = .Rows(i).Item("Menu")
                    Param_GRD.Rows.Add(C1, C2, C3, C4, C5, C6)
                End If
            Next
        End With
        With Param_GRD

            For i = 0 To .RowCount - 1
                If IsNull(.Item("Typ_Param_General", i).Value, "") = "Num" Then
                    .Item("Valeur", i).Style.Alignment = DataGridViewContentAlignment.TopRight
                    .Item("Valeur", i).Value = FormatNumber(IsNull(.Item("Valeur", i).Value.ToString.Replace(".", ","), "0"), 3)
                ElseIf IsNull(.Item("Typ_Param_General", i).Value, "") = "Ent" Then
                    .Item("Valeur", i).Style.Alignment = DataGridViewContentAlignment.TopRight
                    .Item("Valeur", i).Value = FormatNumber(IsNull(.Item("Valeur", i).Value, "0"), 0)
                ElseIf IsNull(.Item("Typ_Param_General", i).Value, "") = "Alpha" Then
                    .Item("Valeur", i).Style.Alignment = DataGridViewContentAlignment.TopLeft
                    .Item("Valeur", i).ReadOnly = False
                Else
                    .Item("Valeur", i).Style.Alignment = DataGridViewContentAlignment.TopLeft
                    .Item("Valeur", i).ReadOnly = True
                End If

            Next

        End With


    End Sub

    Private Sub Saving()

        ModifierParamTbl()

        Dim rs As New ADODB.Recordset
        Try
            For i = 0 To ParamTbl.Rows.Count - 1
                rs.Open("Select * from Param_General where Cod_Param='" & ParamTbl.Rows(i).Item("Cod_Param") & "'", cn, 2, 2)
                rs.Update()
                If IsNull(ParamTbl.Rows(i).Item("Typ_Param_General"), "") = "Ent" Or IsNull(ParamTbl.Rows(i).Item("Typ_Param_General"), "") = "Num" Then
                    rs("Valeur").Value = CDbl(IsNull(ParamTbl.Rows(i).Item("Valeur"), "0").Replace(".", ","))
                Else
                    rs("Valeur").Value = ParamTbl.Rows(i).Item("Valeur")
                End If

                rs.Update()
                rs.Close()
            Next
            If ShowMessageBox("Voulez-vous appliquer ces paramètres à l'ensemble des utilisateurs?", "RHP", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                CnExecuting("delete from Param_General_User")
            End If

            Dim nbj As Object = FindParam("NbLigneListeTDB")
            If IsNumeric(nbj) Then
                NbLigneReportQuery = CInt(nbj)
            Else
                NbLigneReportQuery = 50
            End If
            MessageBoxRHP(1)
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub

    Private Sub Param_TreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Param_TreeView.AfterSelect
        Request()
    End Sub

    Private Sub Param_GRD_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Param_GRD.CellPainting
        If e.ColumnIndex <> Valeur.Index Or e.RowIndex < 0 Then Exit Sub
        Dim oX, oY As Integer
        oX = e.CellBounds.Location.X + e.CellBounds.Width - 16
        oY = (e.RowIndex + 1) * e.CellBounds.Height
        With Param_GRD
            If IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Dat" Then
                e.Graphics.DrawImage(My.Resources.calendrier, oX, oY)
                Param_GRD.Item(Valeur.Index, e.RowIndex).ReadOnly = True
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Mnu" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                Param_GRD.Item(Valeur.Index, e.RowIndex).ReadOnly = True
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Rub" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                Param_GRD.Item(Valeur.Index, e.RowIndex).ReadOnly = True
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "File" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                Param_GRD.Item(Valeur.Index, e.RowIndex).ReadOnly = True
            ElseIf IsNull(.Item("Typ_Param_General", e.RowIndex).Value, "") = "Boolean" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                Param_GRD.Item(Valeur.Index, e.RowIndex).ReadOnly = True
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Path" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                Param_GRD.Item(Valeur.Index, e.RowIndex).ReadOnly = True
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Ser" Then
                e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
                Param_GRD.Item(Valeur.Index, e.RowIndex).ReadOnly = True
            Else
                Param_GRD.Item(Valeur.Index, e.RowIndex).ReadOnly = False
            End If
        End With

    End Sub

    Private Sub ModifierParamTbl()
        Dim oRow() As DataRow
        For i = 0 To Param_GRD.RowCount - 1

            oRow = ParamTbl.Select("[Cod_Param]='" & Param_GRD.Item("Cod_Param", i).Value & "'")

            oRow(0).Item("Valeur") = Param_GRD.Item("Valeur", i).Value

        Next
    End Sub

    Private Sub Param_GRD_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Param_GRD.DoubleClick
        With Param_GRD
            Dim r, c As Integer
            r = .CurrentRow.Index
            c = .CurrentCell.ColumnIndex

            If c <> Valeur.Index Or r < 0 Then Exit Sub

            If IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Dat" Then
                Appel_Calender(.CurrentCell, Me)
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Mnu" Then
                Appel_Zoom1(.Item("Mnu", .CurrentCell.RowIndex).Value, .CurrentCell, Me)
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Rub" Then
                If IsNull(.Item("Type", .CurrentCell.RowIndex).Value, "") = "Boolean" Then
                    Appel_Zoom_Boolean(.CurrentCell, Me, .Item("Mnu", .CurrentCell.RowIndex).Value)
                Else
                    Appel_Zoom("Valeur", "Membre", "Param_Rubriques", "Nom_Controle='" & .Item("Mnu", .CurrentCell.RowIndex).Value & "'", .CurrentCell, Me)
                End If

            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "File" Then
                Dim OpenFileDialog As New OpenFileDialog
                OpenFileDialog.InitialDirectory = importPath
                OpenFileDialog.AutoUpgradeEnabled = False
                OpenFileDialog.Filter = "Tous les fichiers (*.*)|*.*"
                If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then
                    importPath = System.IO.Path.GetFullPath(OpenFileDialog.FileName)
                    Dim FileName As String = OpenFileDialog.FileName
                    .Item("Valeur", .CurrentRow.Index).Value = FileName
                End If
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Path" Then
                Dim oFolderBrowserDialog As New FolderBrowserDialog
                oFolderBrowserDialog.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                If (oFolderBrowserDialog.ShowDialog(Me) = DialogResult.OK) Then
                    Dim Path As String = oFolderBrowserDialog.SelectedPath
                    .Item("Valeur", .CurrentRow.Index).Value = Path
                End If
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Ser" Then
                Appel_Zoom("Num_Ser", "Typ_Pie", "Workflow_Pieces", "Typ_Pie='" & .Item(0, .CurrentRow.Index).Value & "' And Cod_Profile='" & theUser.Cod_Profile & "' and Etablir='True' and isnull(Typ_Pie,'')+isnull(Num_Ser,'') in " &
"( select  isnull(Typ_Pie,'')+isnull(Num_Ser,'') from Param_Num_Ser where convert(smalldatetime,isnull(NullIf(Dat_Deb,''),'01/01/2009'))<=getdate() " &
" and  convert(smalldatetime,isnull(NullIf(Dat_Fin,''),'01/01/2040'))>=getdate() )", .Item(2, .CurrentRow.Index), Me)

            End If
        End With
    End Sub
    Private Sub Param_Grd_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Param_GRD.EditingControlShowing
        With Param_GRD
            If .CurrentCell.ColumnIndex = Valeur.Index Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With Param_GRD
            If IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Num" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, False, False, False, False)
            ElseIf IsNull(.Item("Typ_Param_General", .CurrentCell.RowIndex).Value, "") = "Ent" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, True, True, False, False)
            End If
        End With
    End Sub

    Sub Enregistrer()
        Saving()
    End Sub
End Class