Public Class GrdFilter
    Friend PrePaie_Grd As New DataGridView
    Dim TblCol As New DataTable
    Friend ModeleSaisieStr As String = ""
    Friend CodPlan As String = ""
    Dim TblFilter As New DataTable
    Sub MeMasquer()
        If PrePaie_Grd.ColumnCount = 0 Then Exit Sub
        Chargement()
        Dim strEM As String = ""
        With FilterList
            For i = 0 To .Controls.Count - 1
                If Not .GetItemChecked(i) Then
                    strEM &= IIf(strEM = "", "", ";") & .Controls(i).Name
                End If
            Next
            'If strEM <> "" Then
            '    Dim nrw() As DataRow = TblFilter.Select("Actif='True'")
            '    If nrw.Length > 0 Then
            '        ModeleSaisie_cbo.SelectedText = nrw(0)("Cod_Filtre")
            '    End If
            '    CType(PrePaie_Grd.FindForm, RH_Preparation_Paie).PrePaie.strEM = strEM.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            'End If
        End With
        With PrePaie_Grd
            For i = 0 To .Columns.Count - 1
                .Columns(i).Visible = Not strEM.Split(";").Contains(.Columns(i).Name)
            Next
        End With
        CnExecuting("update RH_Param_Plan_Paie_Filtre set Actif =case when Cod_Filtre='" & ModeleSaisie_cbo.Text.Replace("'", "''") & "' then 'true' else 'false' end where  id_Societe=" & Societe.id_Societe & " and Typ_Filtre='C' and Cod_Plan_Paie='" & CodPlan & "'")
        Me.Visible = False
        CType(PrePaie_Grd.FindForm, RH_Preparation_Paie).AppyFilter()
    End Sub
    Private Sub search_txt_TextChanged(sender As Object, e As EventArgs) Handles search_txt.TextChanged
        Dim TblF As DataView = TblCol.DefaultView
        TblF.RowFilter = "[itm] like '%" & search_txt.Text & "%'"
        With FilterList
            .Controls.Clear()
            With TblF.ToTable
                For i = 0 To .Rows.Count - 1
                    FilterList.AddItem(.Rows(i)("itm"), CBool(.Rows(i)("Chek")), .Rows(i)("txt"))
                Next
            End With
        End With
    End Sub
    Sub Chargement()
        TblFilter = DATA_READER_GRD("select * from RH_Param_Plan_Paie_Filtre where id_Societe='" & Societe.id_Societe & "' and Cod_Plan_Paie='" & CodPlan & "' and Typ_Filtre='C'")
    End Sub
    Private Sub GrdFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Chargement()
        Dim strMSActif As String = ""
        Dim lalistChamps As String = ""
        ModeleSaisie_cbo.Items.Add("Appliquer le plan")
        For i = 0 To TblFilter.Rows.Count - 1
            ModeleSaisie_cbo.Items.Add(TblFilter.Rows(i)("Cod_Filtre"))
            If IsNull(TblFilter.Rows(i)("Actif"), False) = True Then
                strMSActif = TblFilter.Rows(i)("Cod_Filtre")
                lalistChamps = IsNull(TblFilter.Rows(i)("Syntaxe"), "")
            End If
        Next
        If strMSActif <> "" Then
            ModeleSaisie_cbo.Text = strMSActif
            Dim listChamps() As String = lalistChamps.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            With FilterList
                For i = 0 To .Controls.Count - 1
                    .SetItemChecked(i, Not listChamps.Contains(PrePaie_Grd.Columns(i).Name))
                Next
            End With
        End If
        TblCol.Columns.Add("Chek")
        TblCol.Columns("Chek").ReadOnly = False
        TblCol.Columns("Chek").DataType = GetType(Double)
        TblCol.Columns.Add("itm")
        TblCol.Columns.Add("txt")
        With PrePaie_Grd
            For i = 0 To .Columns.Count - 1
                TblCol.Rows.Add(PrePaie_Grd.Columns(i).Visible, PrePaie_Grd.Columns(i).Name, PrePaie_Grd.Columns(i).HeaderText)
                FilterList.AddItem(PrePaie_Grd.Columns(i).Name, PrePaie_Grd.Columns(i).Visible, PrePaie_Grd.Columns(i).HeaderText.Replace(vbCrLf, " "))
            Next
        End With
    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        MeMasquer()
    End Sub
    Private Sub GrdFilter_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            If TblCol.Columns.Count <= 0 Then Return
            With PrePaie_Grd
                For i = 0 To .Columns.Count - 1
                    TblCol.Rows(i)("Chek") = PrePaie_Grd.Columns(i).Visible
                    FilterList.SetItemChecked(i, PrePaie_Grd.Columns(i).Visible)
                Next
            End With
        End If
    End Sub
    Private Sub Add_D_Click(sender As Object, e As EventArgs) Handles New_pb.Click
        NouveauModeleSaisie()
    End Sub
    Function NouveauModeleSaisie() As Boolean
        Dim MStr As String = InputBox("Veuillez saisir le nom du modèle de saisie", "Ajouter un modèle de saisie")
        If (MStr.Contains("'") Or MStr.Contains(Chr(34)) Or MStr.Contains("&")) Then
            ShowMessageBox("Evitez les caractères spéciaux", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End If
        With ModeleSaisie_cbo
            For i = 0 To .Items.Count - 1
                If .Items(i).ToString.Trim = MStr.Trim Then
                    ShowMessageBox("Ce nom de modèle de saisie existe déjà", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                    Return False
                End If
            Next
            .Items.Add(MStr.Trim)
            .SelectedIndex = .Items.IndexOf(MStr.Trim)
        End With
        Return True
    End Function
    Private Sub Save_D_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        '    Try
        If ModeleSaisie_cbo.SelectedIndex < 0 Then Return
        If ModeleSaisie_cbo.Text = "Appliquer le plan" Then Return
        Dim strm As String = ""
        With FilterList
            For i = 0 To .Controls.Count - 1
                If Not .GetItemChecked(i) Then strm &= IIf(strm = "", "", ";") & PrePaie_Grd.Columns(i).Name
            Next
        End With
        If ModeleSaisie_cbo.Text.Trim.Replace("'", "''") <> "Appliquer le plan" Then
            CnExecuting("update RH_Param_Plan_Paie_Filtre set Actif ='false' where  id_Societe=" & Societe.id_Societe & " and Typ_Filtre='C' and Cod_Plan_Paie='" & CodPlan & "'")
            Dim rs As New ADODB.Recordset
            rs.Open("select * from RH_Param_Plan_Paie_Filtre where Cod_Filtre='" & ModeleSaisie_cbo.Text.Trim.Replace("'", "''") & "'  
   and id_Societe=" & Societe.id_Societe & " and Typ_Filtre='C' and Cod_Plan_Paie='" & CodPlan & "'", cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("id_Societe").Value = Societe.id_Societe
                rs("Cod_Plan_Paie").Value = CodPlan
                rs("Cod_Filtre").Value = ModeleSaisie_cbo.Text.Trim

            Else
                rs.Update()
            End If
            rs("Typ_Filtre").Value = "C"
            rs("Syntaxe").Value = strm
            rs("Actif").Value = True
            rs.Update()
            rs.Close()
        End If
        Chargement()
        MeMasquer()
        '    Catch ex As Exception

        '     End Try
    End Sub
    Private Sub Del_D_Click(sender As Object, e As EventArgs) Handles Del_pb.Click
        If ModeleSaisie_cbo.SelectedIndex < 0 Then Return
        Dim CodFiltre As String = ModeleSaisie_cbo.Text.Trim.Replace("'", "''")
        If ShowMessageBox("Voulez-vous supprimer le modèle de saisie en cours?", "Supression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        Chargement()
        ModeleSaisie_cbo.Items.RemoveAt(ModeleSaisie_cbo.SelectedIndex)
        CnExecuting("delete from RH_Param_Plan_Paie_Filtre where Cod_Filtre='" & CodFiltre & "'
   and id_Societe=" & Societe.id_Societe & " and Typ_Filtre='C' and Cod_Plan_Paie='" & CodPlan & "'")
        Chargement()
        ModeleSaisie_cbo.SelectedIndex = -1
    End Sub

    Private Sub SelectAll_pbClick(sender As Object, e As EventArgs) Handles SelectAll_pb.Click
        With FilterList
            If .Controls.Count > 0 Then
                Dim obool As Boolean = .GetItemChecked(0)
                For i = 0 To .Controls.Count - 1
                    .SetItemChecked(i, Not obool)
                Next
            End If
        End With
    End Sub
    Private Sub FilterList_ItemCheck(sender As Object, e As EventArgs) Handles FilterList.ItemCheck
        Dim rw() As DataRow = TblCol.Select("itm='" & sender.Name.Replace("'", "''") & "'")
        If rw.Length > 0 Then
            rw(0)("Chek") = Not FilterList.GetItemChecked(FilterList.Controls.IndexOf(sender))
        End If
    End Sub
    Private Sub ModeleSaisie_cbo_TextChanged(sender As Object, e As EventArgs) Handles ModeleSaisie_cbo.TextChanged
        Chargement()
        ModeleSaisie_cbo.Refresh()
        Dim strMSActif As String = ModeleSaisie_cbo.Text
        Dim listChamps() As String
        If strMSActif = "Appliquer le plan" Then
            listChamps = CType(PrePaie_Grd.FindForm, RH_Preparation_Paie).PrePaie.strEM
        Else
            Dim nrw() As DataRow = TblFilter.Select("Cod_Filtre='" & strMSActif & "'")
            If nrw.Length = 0 Then Return
            listChamps = IsNull(nrw(0)("Syntaxe"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        End If
        With FilterList
            For i = 0 To .Controls.Count - 1
                .SetItemChecked(i, Not listChamps.Contains(PrePaie_Grd.Columns(i).Name))
            Next
        End With
    End Sub
End Class
