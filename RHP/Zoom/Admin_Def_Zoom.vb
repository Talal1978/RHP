Imports System.Text.RegularExpressions
Public Class Admin_Def_Zoom
    Dim str As String = ""
    Friend Code As String = ""
    Dim Save_D As ud_btn
    Private Sub ArticleFiche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tbl_Controle_Def_Zoom = DATA_READER_GRD("select * from Controle_Def_Zoom")
        Order_By_Sens.fromRubrique("Order_By_Sens")
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
        End If
    End Sub
    Sub Requesting()
        Request()
    End Sub
    Sub Request()
        Try
            Grd.DataSource = Nothing
            Tbl_Controle_Def_Zoom = DATA_READER_GRD("select * from Controle_Def_Zoom")
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
            DroitAcces(Me, DroitModify_Fiche(Num_Zoom.Text, Me))
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Num_Zoom.Text)
                Code = Num_Zoom.Text
            End If
            Dim nrw() As DataRow = Tbl_Controle_Def_Zoom.Select("[Num_Zoom]='" & Num_Zoom.Text & "'")
            If nrw.Length > 0 Then
                Table_Ref.Text = IsNull(nrw(0).Item("Table_Ref"), "")
                Index_Table.Text = IsNull(nrw(0).Item("Index_Table"), "")
                Description.Text = IsNull(nrw(0).Item("Description"), "")
                Condition.Text = IsNull(nrw(0).Item("Condition"), "")
                Protege.Checked = IsNull(nrw(0).Item("Protege"), False)
                If IsNumeric(IsNull(nrw(0).Item("Order_By"), 1)) Then
                    Order_By.Value = IsNull(nrw(0).Item("Order_By"), 1)
                Else
                    Order_By.Value = 1
                End If
                If IsNumeric(IsNull(nrw(0).Item("Search_By"), 1)) Then
                    Search_By.Value = IsNull(nrw(0).Item("Search_By"), 1)
                Else
                    Search_By.Value = 1
                End If
                Request_Grd()

            End If
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Sub Request_Grd()
        Try
            If Num_Zoom.Text <> "" Then
                Dim NumZoom As String = Num_Zoom.Text
                Dim Zoom_Cod, Zoom_Lib, Zoom_Where1, ZoomSens, ZoomSearchBy As String
                Dim ColumnSearch As Integer = Search_By.Value
                Dim Zoom_Order As Integer = Order_By.Value
                Dim Cod_Sql As String = ""
                Dim TblZoomP As New DataTable
                Dim Zoom_Tbl As String = FilterRoleWhere(Table_Ref.Text)
                Zoom_Cod = Index_Table.Text
                Zoom_Lib = Description.Text
                Zoom_Where1 = Condition.Text
                Zoom_Order = Order_By.Value
                ZoomSens = Order_By_Sens.SelectedValue
                ZoomSearchBy = Search_By.Value
                ColumnSearch = CInt(ZoomSearchBy)
                If ContientIdSoc(Zoom_Tbl).Count > 0 Then
                    Zoom_Where1 &= IIf(Zoom_Where1 = "", "", " and ") & " isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe
                End If
                Cod_Sql = "Select Top " & nbLig.Value & " " & Zoom_Cod & " As Code," & Zoom_Lib & " " & IIf(Zoom_Lib = "", "'' as Description", "") & " FROM " & Zoom_Tbl & "  where " & Zoom_Where1 & IIf(CStr(Zoom_Order) <> "", " Order by " & Zoom_Order, "") & " " & ZoomSens
                If str = "" Then
                    Dim olist As New ArrayList
                    Dim rg As New Regex("\{[0-9]\}", RegexOptions.IgnoreCase)
                    For Each c As Match In rg.Matches(Cod_Sql)
                        If Not olist.Contains(c.Value) Then olist.Add(c.Value)
                    Next
                    For i = 0 To olist.Count - 1
                        str &= IIf(str = "", "", ",") & InputBox(olist(i))
                    Next
                    Cod_Sql = String.Format(Cod_Sql, str.Split(","))
                End If
                Dim rgx As New Regex("(?<=\W)GV_\w+", RegexOptions.IgnoreCase)
                For Each c As Match In rgx.Matches(Cod_Sql)
                    Cod_Sql = Cod_Sql.Replace(c.Value, "'" & GlobalVar(c.Value.Trim.ToString) & "'")
                Next
                rgx = New Regex(sql_injection, RegexOptions.IgnoreCase)
                If rgx.Matches(Cod_Sql).Count > 0 Then
                    ShowMessageBox("Votre requête contient des expressions interdites : " & rgx.Matches(Cod_Sql)(0).Value, "Vérification de zoom", MessageBoxButtons.OK, msgIcon.Error)
                    Return
                End If

                TblZoomP = DATA_READER_GRD(Cod_Sql)
                Grd.DataSource = TblZoomP
                If Not TblZoomP Is Nothing Then
                    Dim oIndx(TblZoomP.Columns.Count - 1) As Integer
                    For i = 0 To Grd.ColumnCount - 1
                        oIndx(i) = i
                    Next
                    Grd.setFilter(oIndx)
                    Order_By.Maximum = TblZoomP.Columns.Count
                    Search_By.Maximum = TblZoomP.Columns.Count
                End If
            End If
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    Sub Enregistrer()
        Try
            str = ""
            Request_Grd()
            If Grd.DataSource IsNot Nothing Then
                Dim rs, rs0 As New ADODB.Recordset
                Dim CodCl As String = Num_Zoom.Text
                rs.Open("select * from Controle_Def_Zoom where Num_Zoom='" & Num_Zoom.Text & "'", cn, 2, 2)
                If Not rs.EOF Then
                    rs.Update()
                    rs("Table_Ref").Value = Table_Ref.Text
                    rs("Index_Table").Value = Index_Table.Text
                    rs("Description").Value = Description.Text
                    rs("Condition").Value = Condition.Text
                    rs("Order_By").Value = Order_By.Value
                    rs("Search_By").Value = Search_By.Value
                    rs("Order_By_Sens").Value = Order_By_Sens.SelectedValue
                    rs("Protege").Value = Protege.Checked
                    rs.Update()

                End If
                rs.Close()
                Request()
                MessageBoxRHP(1)
            End If
        Catch ex As Exception

            MessageBoxRHP(2)
        End Try

    End Sub

    Private Sub Cod_Ville_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num_Zoom.TextChanged
        str = ""
        Request()

    End Sub

    Sub Div_First()
        If Tbl_Controle_Def_Zoom.Rows.Count = 0 Then Return
        Num_Zoom.Text = Tbl_Controle_Def_Zoom.Rows(0).Item("Num_Zoom")
    End Sub

    Sub Div_Last()
        If Tbl_Controle_Def_Zoom.Rows.Count = 0 Then Return
        Num_Zoom.Text = Tbl_Controle_Def_Zoom.Rows(Tbl_Controle_Def_Zoom.Rows.Count - 1).Item("Num_Zoom")
    End Sub

    Sub Div_Next()
        If Tbl_Controle_Def_Zoom.Rows.Count = 0 Then Return
        Dim nrw() As DataRow = Tbl_Controle_Def_Zoom.Select("[Num_Zoom]='" & Num_Zoom.Text & "'")
        If nrw.Length > 0 Then
            Dim nb As Integer = Tbl_Controle_Def_Zoom.Rows.IndexOf(nrw(0))
            If nb < Tbl_Controle_Def_Zoom.Rows.Count - 1 Then nb += 1
            Num_Zoom.Text = Tbl_Controle_Def_Zoom.Rows(nb).Item("Num_Zoom")
        End If
    End Sub

    Sub Div_Back()
        If Tbl_Controle_Def_Zoom.Rows.Count = 0 Then Return
        Dim nrw() As DataRow = Tbl_Controle_Def_Zoom.Select("[Num_Zoom]='" & Num_Zoom.Text & "'")
        If nrw.Length > 0 Then
            Dim nb As Integer = Tbl_Controle_Def_Zoom.Rows.IndexOf(nrw(0))
            If nb > 0 Then nb -= 1
            Num_Zoom.Text = Tbl_Controle_Def_Zoom.Rows(nb).Item("Num_Zoom")
        End If
    End Sub

    Private Sub LabelX2_Click_1(sender As Object, e As EventArgs) Handles LabelX2.Click
        Appel_Zoom("Num_Zoom", "Table_Ref", "Controle_Def_Zoom", "1=1", Num_Zoom, Me)
    End Sub

    Private Sub pbask_Click(sender As Object, e As EventArgs)
        Request_Grd()
    End Sub
    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd.DataError

    End Sub
    Private Sub Admin_Def_Zoom_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Num_Zoom.Text & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Nouveau()
        Reset_Form(Me, False)
    End Sub
End Class