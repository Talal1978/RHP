Imports System.Text.RegularExpressions

Public Class RH_Param_EV_Modules_Annexes

    Private Sub Cod_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles EV_lbl.LinkClicked
        Appel_Zoom1("MS009", Cod_Rubrique_txt, Me, "isnull(EV,0)=1")
    End Sub
    Private Sub Nom_Controle_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Rubrique_txt.TextChanged
        Request()
    End Sub
    Sub Request()
        Dim Cod_Sql As String
        Cod_Sql = $"select *, convert(bit, case when id_Societe=-1 then 1 else 0 end) as estGlobale from  RH_Param_EV_Modules_Annexes where Cod_Rubrique='{Cod_Rubrique_txt.Text}' and isnull(nullif(id_Societe,-1),{Societe.id_Societe})={Societe.id_Societe}"
        Dim Tbl = DATA_READER_GRD(Cod_Sql)
        ev_GRD.Rows.Clear()
        With Tbl
            If .Rows.Count > 0 Then
                Lib_EV_txt.Text = IsNull(.Rows(0)("Lib_EV"), "")
                Global_chk.Checked = IsNull(.Rows(0)("id_Societe") = -1, FindLibelle("id_Societe", "Cod_Rubrique", Cod_Rubrique_txt.Text, "RH_Paie_Rubrique").ToString = "-1")
                Actif_chk.Checked = IsNull(.Rows(0)("Actif"), True)
                estSysteme_chk.Checked = IsNull(.Rows(0)("estSysteme"), False)
                Champs_Associe_txt.Text = IsNull(.Rows(0)("Champs_Associe"), "")
                Table_Ref_txt.Text = IsNull(.Rows(0)("Table_Ref"), "")
                Clause_Where_txt.Text = IsNull(.Rows(0)("Clause_Where"), "")
                Champs_Matricule_txt.Text = IsNull(.Rows(0)("Champs_Matricule"), "Matricule")
            Else
                Lib_EV_txt.Text = If(Cod_Rubrique_txt.Text <> "", FindLibelle("Abr_Rubrique", "Cod_Rubrique", Cod_Rubrique_txt.Text, "RH_Paie_Rubrique"), "")
                Global_chk.Checked = False
                Actif_chk.Checked = True
                estSysteme_chk.Checked = False
                Champs_Associe_txt.Text = ""
                Table_Ref_txt.Text = ""
                Clause_Where_txt.Text = ""
                Champs_Matricule_txt.Text = "Matricule"
            End If
        End With
        Cod_Sql = $"select Cod_Rubrique, Lib_EV, Table_Ref, convert(bit, case when id_Societe=-1 then 1 else 0 end) as estGlobale, isnull(Actif,'false') as Actif from  RH_Param_EV_Modules_Annexes where isnull(nullif(id_Societe,-1),{Societe.id_Societe})={Societe.id_Societe}"
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            Dim C1, C2, C3, C4, C5 As Object
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Cod_Rubrique"), "")
                C2 = IsNull(.Rows(i).Item("Lib_EV"), "")
                C3 = IsNull(.Rows(i).Item("Table_Ref"), "")
                C4 = IsNull(.Rows(i).Item("estGlobale"), False)
                C5 = IsNull(.Rows(i).Item("Actif"), False)
                ev_GRD.Rows.Add(C1, C2, C3, C4, C5)
            Next
        End With
    End Sub
    Function Saving() As Boolean
        Dim rs As New ADODB.Recordset
        Dim flg As Integer = (New Random()).Next(999, 56531)
        Dim Cod_Sql As String
        Dim swhere As String = ""
        If Cod_Rubrique_txt.Text.Trim = "" Then
            ShowMessageBox("Code rubrique vide.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        If Lib_EV_txt.Text.Trim = "" Then
            ShowMessageBox("Intitulé rubrique vide.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        If Table_Ref_txt.Text.Trim = "" OrElse Champs_Associe_txt.Text.Trim = "" OrElse Clause_Where_txt.Text.Trim = "" Then
            ShowMessageBox("Table, champs ou clause where est vide.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        If Champs_Matricule_txt.Text.Trim = "" Then
            ShowMessageBox("Champs Matricule associé est vide.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        Dim sqlStr = $"declare @CodPlan nvarchar(50) ='PL', @idSoc int = {Societe.id_Societe}, @DatDeb smalldatetime = getdate(), @DatFin smalldatetime = getdate() 
                      select sum(isnull({Cod_Rubrique_txt.Text},0)) as '{Cod_Rubrique_txt.Text}'
                      from Rh_Agent
                      outer apply (
                      select {Champs_Associe_txt.Text.Trim} as '{Cod_Rubrique_txt.Text}' from {Table_Ref_txt.Text.Trim} 
                      where {Clause_Where_txt.Text} and {Champs_Matricule_txt.Text}=Rh_Agent.Matricule) f
                      where id_Societe=@idSoc"

        Dim rg As New Regex(sql_injection, RegexOptions.IgnoreCase)
        If rg.IsMatch(sqlStr) Then
            ShowMessageBox("Votre expression contient des expressions intérdites", "Injection", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
        Dim TblTest = DATA_READER_GRD(sqlStr)
        If TblTest Is Nothing Then
            ShowMessageBox("La structure sql des éléments associés ne retourne pas de résultat", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        If TblTest.Columns.Count <> 1 Then
            ShowMessageBox("La structure sql des éléments associés doit retourner une seule colonne.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        Dim olist = ContientIdSoc(Table_Ref_txt.Text.Trim)
        If olist.Count > 0 Then
            rg = New Regex("\b(id_societe)\s*[=]", RegexOptions.IgnoreCase)
            If Not rg.IsMatch(Clause_Where_txt.Text.ToLower()) Then
                ShowMessageBox("Le filtre doit contenir une condition sur le champs ""id_Societe"".", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        End If
            Dim col As DataColumn = TblTest.Columns(0)

        ' Liste des types numériques
        Dim numericTypes As Type() = {
        GetType(Short), GetType(UShort),
        GetType(Integer), GetType(UInteger),
        GetType(Long), GetType(ULong),
        GetType(Single), GetType(Double), GetType(Decimal)
    }
        If Not numericTypes.Contains(col.DataType) Then
            ShowMessageBox("La colonne associée à l'élément variable doit retourner une valeur numérique." & vbCrLf & col.DataType.Name, "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        If Global_chk.Checked Then
            If CnExecuting($"select count(*) from RH_Paie_Rubrique where id_Societe=-1 and Cod_Rubrique='{Cod_Rubrique_txt.Text}'").Fields(0).Value = 0 Then
                ShowMessageBox("Pour que la propriété ""Globale"" soit cochée, il faut que la rubrique de l'élément variable soit déclarée globale aussi.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        End If
        With ev_GRD
            'enregistrer l'entête
            Cod_Sql = "select * from RH_Param_EV_Modules_Annexes where Cod_Rubrique='" & Cod_Rubrique_txt.Text & "' 
                          and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe
            rs.Open(Cod_Sql, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Cod_Rubrique").Value = Cod_Rubrique_txt.Text
                rs("Created_By").Value = theUser.Login
                rs("Dat_Crea").Value = Now
            Else
                rs.Update()
            End If
            rs("id_Societe").Value = If(Global_chk.Checked, -1, Societe.id_Societe)
            rs("Lib_EV").Value = Lib_EV_txt.Text
            rs("Champs_Associe").Value = Champs_Associe_txt.Text
            rs("Clause_Where").Value = Clause_Where_txt.Text
            rs("Table_Ref").Value = Table_Ref_txt.Text
            rs("Champs_Matricule").Value = Champs_Matricule_txt.Text
            rs("Actif").Value = Actif_chk.Checked
            rs("Modified_By").Value = theUser.Login
            rs("Dat_Modif").Value = Now
            rs.Update()
            rs.Close()
        End With
        MessageBoxRHP(352)
        Request()
        Return True
    End Function
    Private Sub Adding()
        Reset_Form(Me)
        Cod_Rubrique_txt.ReadOnly = False
        Cod_Rubrique_txt.BackColor = Color.White
        Cod_Rubrique_txt.Select()

    End Sub
    Sub Nouveau()
        Adding()
    End Sub

    Sub Enregistrer()
        If Saving() Then
            Reset_Form(Panel1)
            Actif_chk.Checked = True
        End If

    End Sub

    Private Sub Champs_Matricule_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Champs_Matricule_lbl.LinkClicked
        Dim rg As New Regex(sql_injection, RegexOptions.IgnoreCase)
        Dim sqlstr = Table_Ref_txt.Text.Trim
        sqlstr = sqlstr.Replace("@CodPlan", "'PL'")
        sqlstr = sqlstr.Replace("@idSoc", Societe.id_Societe)
        sqlstr = sqlstr.Replace("@DatDeb", "getdate()")
        sqlstr = sqlstr.Replace("@DatFin", "getdate()")
        sqlstr = "select * from " & sqlstr
        If rg.IsMatch(sqlstr) Then
            ShowMessageBox("Votre expression contient des expressions intérdites", "Injection", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        Dim Tbl As DataTable = DATA_READER_GRD(sqlstr)
        With Tbl
            If .Columns.Count = 0 Then Return
            Dim TblCol As New DataTable

            TblCol.Columns.Add("Colonne")
            TblCol.Columns.Add("Type")
            For i = 0 To .Columns.Count - 1
                TblCol.Rows.Add(.Columns(i).ColumnName, .Columns(i).DataType)
            Next
            Dim f As New Zoom_Libre
            With f
                .Libre_GRD.DataSource = TblCol
                .ZoomObject = Champs_Matricule_txt
                .ShowDialog()
            End With
        End With
    End Sub

    Private Sub ev_GRD_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ev_GRD.CellMouseMove
        With ev_GRD
            If .RowCount = 0 Then Return
            If e.RowIndex < 0 Then Return
            .Rows(e.RowIndex).DefaultCellStyle.BackColor = colorBase02
        End With
    End Sub

    Private Sub ev_GRD_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles ev_GRD.CellMouseLeave
        With ev_GRD
            If .RowCount = 0 Then Return
            If e.RowIndex < 0 Then Return
            .Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        End With
    End Sub

    Private Sub ev_GRD_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ev_GRD.CellMouseDoubleClick
        With ev_GRD
            If .RowCount = 0 Then Return
            If e.RowIndex < 0 Then Return
            Dim codRub = IsNull(.Item(Cod_Rubrique.Index, e.RowIndex).Value, "")
            If codRub = "" Then Return
            Cod_Rubrique_txt.Text = codRub
        End With
    End Sub
    Sub insertPreedefiniVar(champs As ud_TextBox)
        Dim osel As Integer = champs.SelectionStart
        Dim txt As New TextBox
        With txt
            .Size = New Size(0, 0)
            .Location = champs.Location
            Panel1.Controls.Add(txt)
        End With
        Appel_Rubrique("EV_Var_Predefinies", txt, Me)

        ' Correction : Insert retourne une nouvelle chaîne, il faut l'assigner
        champs.Text = champs.Text.Insert(osel, " " & txt.Text)

        ' Bonus : repositionner le curseur après l'insertion
        champs.innerTextBox.SelectionStart = osel + txt.Text.Length + 1
        champs.innerTextBox.SelectionLength = 0

        ' Ne pas oublier de nettoyer
        Panel1.Controls.Remove(txt)
        txt.Dispose()
    End Sub

    Private Sub Clause_Where_btn_Click(sender As Object, e As EventArgs) Handles Clause_Where_btn.Click
        insertPreedefiniVar(Clause_Where_txt)
    End Sub

    Private Sub Champs_Associe_btn_Click(sender As Object, e As EventArgs) Handles Champs_Associe_btn.Click
        insertPreedefiniVar(Champs_Associe_txt)
    End Sub

    Private Sub Table_Ref_btn_Click(sender As Object, e As EventArgs) Handles Table_Ref_btn.Click
        insertPreedefiniVar(Table_Ref_txt)
    End Sub
End Class