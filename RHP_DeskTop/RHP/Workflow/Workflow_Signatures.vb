Imports System.Text.RegularExpressions
Public Class Workflow_Signatures
    Dim Save_D As ud_btn
    Friend NumLigne As Integer = -999
    Dim rg_exp_interdite As New Regex(sql_injection, RegexOptions.IgnoreCase)
    Dim rgFormulasStr As String = ""
    Friend _tblFormulas As DataTable = DATA_READER_GRD("SELECT Cod_Formule, Intitule, Syntaxe, Regex, Rang FROM Param_Workflow_Fonctions order by Rang")
    Friend rgFormulas As New Regex("", RegexOptions.IgnoreCase)
    Sub Chargement()
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
        End If
        If Typ_Signature.Items.Count = 0 Then Typ_Signature.fromRubrique()
        If Operande_Signature.Items.Count = 0 Then Combo_GRD(Operande_Signature)
        If rgFormulasStr = "" Then
            With _tblFormulas
                For i = 0 To .Rows.Count - 1
                    rgFormulasStr &= IIf(rgFormulasStr = "", "", "|") & .Rows(i)("Regex")
                Next
            End With
            rgFormulasStr = "(?<!dbo.)(" & rgFormulasStr & ")(?<!idSociete\))"
            rgFormulas = New Regex(rgFormulasStr)
        End If
    End Sub
    Private Sub Param_Num_Ser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not CBool(LicenceJson.WorkFlow) Then
        '    ShowMessageBox("Le module 'Workflow'  n'est pas activé pour votre licence.", "Licence", MessageBoxButtons.OK, msgIcon.Stop)
        '    Me.Close()
        '    Return
        'End If
        Chargement()
        Dim menu_context_copy As New ContextMenuStrip
        Dim oMenu2 As New ToolStripMenuItem
        With oMenu2
            .Text = "Afficher le Traitement"
            AddHandler .Click, AddressOf ShowTraitementLigne
        End With
        menu_context_copy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {oMenu2})
        Grd_ReglesSignatures.ContextMenuStrip = menu_context_copy
        Me.BackColor = Typ_Document_Text.BackColor
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS160", Typ_Document_Text, Me)
    End Sub
    Sub ShowTraitementLigne()
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Workflow_Signatures_Detail where  Typ_Document='" & Typ_Document_Text.Text & "' and Num_Ligne='" & NumLigne & "'")
        If Tbl.Rows.Count = 0 Then
            MessageBoxRHP(567)
            Exit Sub
        End If
        Dim f As New Zoom_SqlText
        With f
            .Sql_Text.Text = IsNull(Tbl.Rows(0)("Traitement"), "")
            .ShowDialog()
        End With
    End Sub
    Private Sub Typ_Document_Text_TextChanged(sender As Object, e As EventArgs) Handles Typ_Document_Text.TextChanged
        Request()
    End Sub
    Sub Request()
        Chargement()
        Dim Tbl As DataTable = DATA_READER_GRD("select s.Typ_Document,Intitule , s.Table_Ref,Typ_Signature , s.Table_Index , Accepte_Detail , Name_Ecran , isnull(Actif,1) as Actif, Signataire_Defaut from Param_Workflow_Typ_Document s 
outer apply(select * from Workflow_Signatures where Typ_Document=s.Typ_Document and id_Societe=" & Societe.id_Societe & ")p
where  s.Typ_Document='" & Typ_Document_Text.Text & "' and isnull(nullif(s.id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)

        With Tbl
            If .Rows.Count > 0 Then
                Lib_Typ_Document_Text.Text = IsNull(.Rows(0)("Intitule"), "")
                If IsNull(.Rows(0)("Accepte_Detail"), False) Then
                    Typ_Signature.SelectedValue = IsNull(.Rows(0)("Typ_Signature"), "E")
                    Typ_Signature.Enabled = True
                Else
                    Typ_Signature.SelectedValue = "E"
                    Typ_Signature.Enabled = False
                End If
                table_Ref_txt.Text = IsNull(.Rows(0)("Table_Ref"), "")
                table_Index_txt.Text = IsNull(.Rows(0)("Table_Index"), "")
                Actif_Check.Checked = IsNull(.Rows(0)("Actif"), False)
                Signataire_Defaut_txt.Text = IsNull(.Rows(0)("Signataire_Defaut"), "")
            Else
                Lib_Typ_Document_Text.Text = ""
                Typ_Signature.SelectedValue = "E"
                Typ_Signature.Enabled = False
                table_Ref_txt.Text = ""
                table_Index_txt.Text = ""
                Actif_Check.Checked = False
                Signataire_Defaut_txt.Text = ""
            End If
        End With
        RequestLig()
        RequestSignataires()
        RequestTbl()
        ChargementGrd(NumLigne)
    End Sub
    Sub RequestSignataires()
        Dim Cod_Sql As String = "SELECT *
                                 FROM Workflow_Signatures_Signataires s
                                 outer apply(select ltrim(rtrim(isnull(Nom_Agent,'')+' '+isnull(Prenom_Agent,''))) as Nom from Rh_Agent where Matricule=Signataire and id_Societe=s.id_Societe)n
                                 WHERE    Typ_Document='" & Typ_Document_Text.Text & "' and id_Societe=" & Societe.id_Societe & " order by RowId"
        Grd_Signataires.Rows.Clear()
        Dim C1, C2, C3 As Object
        Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Signataire"), "")
                C2 = IsNull(.Rows(i).Item("Nom"), "")
                C3 = .Rows(i).Item("Num_Ligne")
                Grd_Signataires.Rows.Add(C1, C2, C3)
            Next
        End With

    End Sub
    Sub RequestLig()
        Dim Cod_Sql As String = "SELECT *
                                 FROM Workflow_Signatures_Detail
                                 WHERE    Typ_Document='" & Typ_Document_Text.Text & "'  and id_Societe=" & Societe.id_Societe & " order by Num_Ligne"
        Grd_ReglesSignatures.Rows.Clear()
        Dim C1, C2, C3, C4, C5, C6, C7, C8 As Object
        Dim Tbl_Lignes As DataTable = DATA_READER_GRD(Cod_Sql)
        With Tbl_Lignes
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Num_Ligne"), "")
                C2 = IsNull(.Rows(i).Item("Lib_Ligne"), "")
                C3 = IsNull(.Rows(i).Item("Operande_Signature"), "ET")
                C4 = IsNull(.Rows(i).Item("Dans_Ordre"), False)
                C8 = IsNull(.Rows(i).Item("RegrouperSignataires"), True)
                C5 = IsNull(.Rows(i).Item("Condition"), "")
                C6 = IsNull(.Rows(i).Item("Typ_Liste"), "")
                C7 = IsNull(.Rows(i).Item("Query_Sigantaire"), "")
                Grd_ReglesSignatures.Rows.Add(C1, C2, C3, C4, C8, C5, C6, C7)
            Next
        End With
        NumLigne = Grd_ReglesSignatures.Item(Num_Ligne.Index, 0).Value
    End Sub
    Sub RequestTbl()
        Dim Cod_Sql As String = "SELECT * 
                                 FROM Workflow_Signatures_Tables  
                                 WHERE Typ_Document='" & Typ_Document_Text.Text & "'  and id_Societe=" & Societe.id_Societe & " order by RowId"
        Dim oTbl As DataTable = DATA_READER_GRD(Cod_Sql)
        Grd_Tbl.Rows.Clear()
        With oTbl
            For i = 0 To .Rows.Count - 1
                Grd_Tbl.Rows.Add(IsNull(.Rows(i).Item("Table_Liee"), ""), IsNull(.Rows(i).Item("Liaison"), ""), IsNull(.Rows(i).Item("Num_Ligne"), 0))
            Next
        End With
    End Sub
    Sub ChargementGrd(ByVal NumLig As Integer)
        NumLigne = NumLig
        'charegement tables de from :
        With Grd_Tbl
            For i = 0 To .RowCount - 1
                If Not .Rows(i).IsNewRow Then .Rows(i).Visible = (CInt(IsNull(.Item(Num_Lig_Tbl.Index, i).Value, 0)) = NumLig)
            Next
        End With
        Dim ind As Integer = -1
        With Grd_ReglesSignatures
            For i = 0 To .Rows.Count - 1
                If .Item(Num_Ligne.Index, i).Value = NumLig Then
                    ind = i
                    Exit For
                End If
            Next
            If ind < 0 Then Return
            'charegement champs détail :
            Select Case IsNull(.Item(Typ_Liste.Index, ind).Value, "")
                Case "F"
                    Rd_Query.Checked = True
                    With Grd_Signataires
                        .Visible = False
                    End With
                    With Sigantaire_formulas_txt
                        .Visible = True
                        .Text = IsNull(Grd_ReglesSignatures.Item(Query_Sigantaire.Index, ind).Value, "")
                        .SelectAll()
                    End With
                Case Else
                    Rd_List.Checked = True
                    With Grd_Signataires
                        .Visible = True
                        For i = 0 To .RowCount - 1
                            If Not .Rows(i).IsNewRow Then .Rows(i).Visible = (CInt(IsNull(.Item(Num_Lig_Signataires.Index, i).Value, 0)) = NumLig)
                        Next
                    End With
                    With Sigantaire_formulas_txt
                        .Visible = False
                    End With
            End Select
        End With
    End Sub
    Private Sub Lig_Grd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles Grd_ReglesSignatures.CellValidating
        If e.ColumnIndex = Num_Ligne.Index Then
            If e.RowIndex = Grd_ReglesSignatures.RowCount - 1 Then Exit Sub
            If Not IsNumeric(e.FormattedValue) Then
                e.Cancel = True
                Exit Sub
            End If
            If e.FormattedValue <= 0 Then
                e.Cancel = True
                Exit Sub
            End If
            With Grd_ReglesSignatures
                If IsNull(.Item(Operande_Signature.Index, e.RowIndex).Value, "ET") = "OU" Then
                    .Item(Dans_Ordre.Index, e.RowIndex).Value = False
                    .Item(Dans_Ordre.Index, e.RowIndex).ReadOnly = True
                Else
                    .Item(Dans_Ordre.Index, e.RowIndex).ReadOnly = False
                End If
                For i = 0 To .RowCount - 1
                    If IsNull(CStr(.Item(Lib_Ligne.Index, i).Value), "") <> "" And CStr(.Item(Num_Ligne.Index, i).Value) = CStr(e.FormattedValue) And CStr(i) <> CStr(e.RowIndex) Then
                        MessageBoxRHP(568)
                        e.Cancel = True
                        Exit Sub
                    End If
                Next
            End With
            NumLigne = e.FormattedValue
            ChargementGrd(NumLigne)
        End If
    End Sub

    Private Sub Lig_Grd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grd_ReglesSignatures.DoubleClick
        With Grd_ReglesSignatures
            Dim r As Integer = .CurrentRow.Index
            If CStr(.Item(Num_Ligne.Index, r).Value) <> "" Then
                NumLigne = .Item(Num_Ligne.Index, r).Value
                ChargementGrd(NumLigne)
            End If
        End With
    End Sub
    Private Sub Adding()
        Initialisation()
        LinkLabel1_LinkClicked(Nothing, Nothing)
    End Sub
    Sub Initialisation()
        Grd_Tbl.Rows.Clear()
        Grd_Signataires.Rows.Clear()
        Grd_ReglesSignatures.Rows.Clear()
        Reset_Form(Panel1)
        Reset_Form(Panel2)
        NumLigne = -999
        Actif_Check.Checked = True
    End Sub
    Private Sub Tbl_Grd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grd_Tbl.KeyUp
        If e.KeyData = Keys.F6 Then
            If Grd_Tbl.CurrentCell.ColumnIndex = Table_Liee.Index Then
                Appel_Zoom("name", "name", "sysobjects", "xtype='U'", Grd_Tbl.CurrentCell, Me)
            End If
        End If
    End Sub

    Function Saving() As Boolean
        If Typ_Document_Text.Text = "" Then Return False
        Dim rs As New ADODB.Recordset
        Dim swhere As String = ""
        Dim nrw() As DataRow = Nothing
        Dim oFrom As String = " from " & table_Ref_txt.Text
        Dim oWhere As String = ""
        Dim QuerySignataire As String = ""
        Dim Tbl_Sigantaires, Tbl_Tables As New DataTable
        If Signataire_Defaut_txt.Text.Trim = "" Then
            ShowMessageBox("Le signataire par défaut n'est pas renseigné", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End If
        With Tbl_Sigantaires
            .Columns.Add("Num_Ligne")
            .Columns.Add("Signataire")
            .Columns("Num_Ligne").DataType = GetType(Integer)
        End With
        With Tbl_Tables
            .Columns.Add("Num_Ligne")
            .Columns.Add("Table_Liee")
            .Columns.Add("Liaison")
            .Columns("Num_Ligne").DataType = GetType(Integer)
        End With
        With Grd_Signataires
            .EndEdit(True)
            For i = 0 To .RowCount - 1
                If IsNull(.Item(Signataire.Index, i).Value, "").Trim <> "" Then
                    Tbl_Sigantaires.Rows.Add(.Item(Num_Lig_Signataires.Index, i).Value, .Item(Signataire.Index, i).Value)
                End If
            Next
        End With
        With Grd_Tbl
            .EndEdit(True)
            For i = 0 To .RowCount - 1
                If IsNull(.Item(Table_Liee.Index, i).Value, "").Trim <> "" And IsNull(.Item(Liaison.Index, i).Value, "").Trim <> "" Then
                    Tbl_Tables.Rows.Add(.Item(Num_Lig_Tbl.Index, i).Value, .Item(Table_Liee.Index, i).Value, .Item(Liaison.Index, i).Value)
                End If
            Next
        End With
        With Grd_ReglesSignatures
            .EndEdit(True)
            For i = 0 To .RowCount - 2
                If Not IsNumeric(IsNull(.Item(Num_Ligne.Index, i).Value, "")) Then
                    ShowMessageBox("Le Numéro de la règle de signature doit être numérique positif absolu.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                    .Rows(i).Selected = True
                    Return False
                End If
                If CDbl(.Item(Num_Ligne.Index, i).Value) <= 0 Then
                    ShowMessageBox("Doublons interdits", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                    ShowMessageBox("Le Numéro de la règle de signature doit être numérique positif absolu.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                    .Rows(i).Selected = True
                    Return False
                End If
                oFrom = " from " & table_Ref_txt.Text
                oWhere = ""
                For k = i + 1 To .RowCount - 2
                    If .Item(Num_Ligne.Index, i).Value = .Item(Num_Ligne.Index, k).Value And IsNull(.Item(Num_Ligne.Index, k).Value, "") <> "" Then
                        ShowMessageBox("Doublons interdits", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                        .Rows(i).Selected = True
                        .Rows(k).Selected = True
                        Return False
                    End If
                Next
                If Not ligneCompiler(i) Then Return False
            Next

        End With
        If Typ_Signature.SelectedIndex = -1 Then
            Typ_Signature.SelectedValue = "E"
        End If
        rs.Open(" select * from Workflow_Signatures where  Typ_Document='" & Typ_Document_Text.Text & "'  and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Typ_Document").Value = Typ_Document_Text.Text
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = Now
            rs("id_Societe").Value = Societe.id_Societe
        Else
            rs.Update()
        End If
        rs("Typ_Signature").Value = Typ_Signature.SelectedValue
        rs("Table_Ref").Value = table_Ref_txt.Text
        rs("Table_Index").Value = table_Index_txt.Text
        rs("Actif").Value = Actif_Check.Checked
        rs("Signataire_Defaut").Value = Signataire_Defaut_txt.Text
        rs("Modified_By").Value = theUser.Login
        rs("Dat_Modif").Value = Now
        rs.Update()
        rs.Close()
        Dim rsl = CompilationdesLignes(Tbl_Sigantaires, Tbl_Tables)
        If rsl Then
            ShowMessageBox("Enregistré avec succès", "RH-P", MessageBoxButtons.OK)
        End If
        Return rsl
    End Function
    Function ligneCompiler(indLig As Integer) As Boolean
        With Grd_ReglesSignatures
            Dim NumLig As String = .Item(Num_Ligne.Index, indLig).Value
            Dim oFrom As String = " from " & table_Ref_txt.Text
            Dim oWhere As String = " where " & table_Ref_txt.Text & ".id_Societe='@@@idSoc' "
            Dim QuerySignataire As String = IsNull(.Item(Query_Sigantaire.Index, indLig).Value, "").Trim
            If Not IsNull(.Item(Typ_Liste.Index, indLig).Value, "") = "L" Then .Item(Typ_Liste.Index, indLig).Value = "F"
            If .Item(Typ_Liste.Index, indLig).Value = "L" Then
                Dim auCun As Boolean = True
                With Grd_Signataires
                    For i = 0 To .RowCount - 1
                        If IsNull(.Item(Signataire.Index, i).Value, "") <> "" And IsNull(.Item(Num_Lig_Signataires.Index, i).Value, "") = NumLig Then
                            auCun = False
                            Exit For
                        End If
                    Next
                End With
                If auCun Then
                    ShowMessageBox("Aucun signataire n'est renseigné pour la ligne : " & NumLig, "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                    .Rows(indLig).Selected = True
                    Return False
                End If
            ElseIf QuerySignataire = "" Then
                ShowMessageBox("Aucun signataire n'est renseigné pour la ligne : " & NumLig, "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                .Rows(indLig).Selected = True
                Return False
            End If

            If table_Index_txt.Text <> "" Then
                oWhere &= " and  " & table_Index_txt.Text & "='@@@Index' "
            End If
            If CStr(IsNull(.Item(Condition_Lig.Index, indLig).Value, "")).Trim <> "" Then
                oWhere &= " and " & CStr(.Item("Condition_Lig", indLig).Value).Trim.Replace("""", "'")
            End If
            With Grd_Tbl
                For j = 0 To .RowCount - 1
                    If IsNull(.Item(Num_Lig_Tbl.Index, j).Value, "") = NumLig And IsNull(.Item(Table_Liee.Index, j).Value, "") <> "" Then
                        oFrom = oFrom & " Left join " & .Item(Table_Liee.Index, j).Value & " on " & .Item(Liaison.Index, j).Value & vbCrLf
                    End If
                Next
            End With
            Dim tesTor As String = QuerySignataire.Replace("""", "'")
            If IsNull(.Item(Typ_Liste.Index, indLig).Value, "") = "F" Then
                If rgFormulas.IsMatch(QuerySignataire) Then
                    Dim previousString As String = ""
                    While previousString <> tesTor
                        previousString = tesTor
                        tesTor = Regex.Replace(tesTor, rgFormulasStr, Function(match) "dbo." & match.Value.Substring(0, match.Value.Length - 1) & ", " & table_Ref_txt.Text & ".id_Societe)")
                    End While
                End If
            End If
            If rg_exp_interdite.IsMatch(tesTor) Then
                ShowMessageBox("L'interprétation des instructions SQL génère des expressions interdites : (eval, exec, update...) " & .Item(Num_Ligne.Index, indLig).Value, "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                .Rows(indLig).Selected = True
                Return False
            ElseIf QuerySignataire <> "" Then
                Try
                    ' Dim _testTor() As String = tesTor.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                    'tesTor = ""
                    'For i = 0 To _testTor.Length - 1
                    '    tesTor &= IIf(tesTor = "", "", ", ") & _testTor(i) & " as Signataire_" & Droite("00" & i + 1, 2)
                    'Next
                    Dim tbl As DataTable = DATA_READER_GRD(("select top 1 " & String.Join(",", tesTor.Split({";"}, StringSplitOptions.RemoveEmptyEntries)) & oFrom & oWhere).Replace("='@@@Index'", " is null ").Replace("@@@idSoc", Societe.id_Societe))
                    If tbl IsNot Nothing Then
                        If tbl.Columns.Count = 0 Then
                            ShowMessageBox("La requête de génération des signataires doit renvoyer au moins une colonne corespondant aux matricules des signataires." & .Item(Num_Ligne.Index, indLig).Value, "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                            MsgBox(("select top 1 " & tesTor & oFrom & oWhere).Replace("='@@@Index'", " is null ").Replace("@@@idSoc", Societe.id_Societe))
                            .Rows(indLig).Selected = True
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    ShowMessageBox("Erreur compilation ligne : " & .Item(Num_Ligne.Index, indLig).Value & vbCrLf & ("select top 1 " & tesTor & oFrom & oWhere).Replace("='@@@Index'", " is null ").Replace("='@@@Index'", " is null ").Replace("@@@idSoc", Societe.id_Societe) & vbCrLf & ex.Message)
                    Return False
                End Try
            End If

            oFrom = "Select count(*) " & vbCrLf & oFrom & vbCrLf & oWhere
            Try
                CnExecuting(oFrom.Replace("='@@@Index'", " is null ").Replace("@@@idSoc", Societe.id_Societe))
            Catch ex As Exception
                ShowMessageBox("Erreur compilation ligne : " & .Item(Num_Ligne.Index, indLig).Value & vbCrLf & oFrom.Replace("='@@@Index'", " is null ").Replace("@@@idSoc", Societe.id_Societe) & vbCrLf & ex.Message)
                Return False
            End Try
            .Item(Query_Sigantaire.Index, indLig).Value = QuerySignataire
            .Rows(indLig).Tag = {IsNull(.Item("Condition_Lig", indLig).Value, "").Trim, oFrom, tesTor}
            Return True
        End With
    End Function
    Function CompilationdesLignes(Tbl_Sigantaires As DataTable, Tbl_Tables As DataTable) As Boolean
        Try
            CnExecuting("Delete from Workflow_Signatures_Detail WHERE Typ_Document='" & Typ_Document_Text.Text & "'  and id_Societe=" & Societe.id_Societe)
            CnExecuting("Delete from Workflow_Signatures_Tables WHERE Typ_Document='" & Typ_Document_Text.Text & "'  and id_Societe=" & Societe.id_Societe)
            CnExecuting("Delete from Workflow_Signatures_Signataires WHERE Typ_Document='" & Typ_Document_Text.Text & "'  and id_Societe=" & Societe.id_Societe)
            Dim rs, rs1 As New ADODB.Recordset
            Dim NumLig As Integer = -1
            Dim nrw() As DataRow = Nothing
            With Grd_ReglesSignatures
                .EndEdit()
                rs.Open("select * from Workflow_Signatures_Detail", cn, 2, 2)
                For i = 0 To .RowCount - 2
                    NumLig = .Item(Num_Ligne.Index, i).Value
                    rs.AddNew()
                    rs("Typ_Document").Value = Typ_Document_Text.Text
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Num_Ligne").Value = NumLig
                    rs("Lib_Ligne").Value = .Item("Lib_Ligne", i).Value
                    rs("Operande_Signature").Value = .Item("Operande_Signature", i).Value
                    rs("Dans_Ordre").Value = .Item(Dans_Ordre.Index, i).Value
                    rs("Condition").Value = IsNull(.Rows(i).Tag(0), "")
                    rs("Traitement").Value = .Rows(i).Tag(1)
                    rs("Typ_Liste").Value = .Item(Typ_Liste.Index, i).Value
                    rs("Sql_Signataires").Value = .Rows(i).Tag(2)
                    rs("Query_Sigantaire").Value = .Item(Query_Sigantaire.Index, i).Value
                    rs("RegrouperSignataires").Value = .Item(RegrouperSignataires.Index, i).Value
                    rs.Update()
                    nrw = Tbl_Sigantaires.Select("Num_Ligne=" & NumLig)
                    rs1.Open("select * from Workflow_Signatures_Signataires", cn, 2, 2)
                    For j = 0 To nrw.Length - 1
                        If IsNull(nrw(j)("Signataire"), "") <> "" Then
                            rs1.AddNew()
                            rs1("Typ_Document").Value = Typ_Document_Text.Text
                            rs1("id_Societe").Value = Societe.id_Societe
                            rs1("Num_Ligne").Value = NumLig
                            rs1("Signataire").Value = nrw(j)("Signataire")
                            rs1.Update()
                        End If
                    Next
                    rs1.Close()
                    nrw = Tbl_Tables.Select("Num_Ligne=" & NumLig)

                    rs1.Open("select * from Workflow_Signatures_Tables", cn, 2, 2)
                    For j = 0 To nrw.Length - 1
                        If IsNull(nrw(j)("Table_Liee"), "") <> "" And IsNull(nrw(j)("Liaison"), "").Trim <> "" Then
                            rs1.AddNew()
                            rs1("Typ_Document").Value = Typ_Document_Text.Text
                            rs1("Num_Ligne").Value = NumLig
                            rs1("id_Societe").Value = Societe.id_Societe
                            rs1("Num_Ligne").Value = NumLig
                            rs1("Table_Ref").Value = table_Ref_txt.Text
                            rs1("Table_Index").Value = table_Index_txt.Text
                            rs1("Table_Liee").Value = nrw(j)("Table_Liee")
                            rs1("Liaison").Value = nrw(j)("Liaison").trim

                            rs1.Update()
                        End If
                    Next
                    rs1.Close()
                Next
                rs.Close()
            End With
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Private Sub Supprimer()
        If MessageBoxRHP(541, "Règle de signature : " & Typ_Document_Text.Text) = MsgBoxResult.Cancel Then Return
        NumLigne = 999999
        Grd_Tbl.Rows.Clear()
        Grd_Signataires.Rows.Clear()
        Grd_ReglesSignatures.Rows.Clear()
        NumLigne = -999
        Diviseur_delete("Workflow_Signatures", "Typ_Document", "Typ_Document", Typ_Document_Text, Me, False)
    End Sub
    Sub Nouveau()
        Adding()
    End Sub
    Sub Deleting()
        Supprimer()
    End Sub
    Sub Enregistrer()
        Me.Cursor = Cursors.WaitCursor
        If Saving() Then
            Request()
            InitialisationWorfRulesSignature()
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Lig_Grd_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grd_ReglesSignatures.RowEnter
        If Not IsNumeric(IsNull(Grd_ReglesSignatures.Item(Num_Ligne.Index, e.RowIndex).Value, "")) Then Exit Sub
        NumLigne = Grd_ReglesSignatures.Item(Num_Ligne.Index, e.RowIndex).Value
        ChargementGrd(NumLigne)
    End Sub
    Private Sub Grd_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grd_Signataires.CellValidated, Grd_Tbl.CellValidated
        'Enregistrer dans les Datatables le contenu des grilles
        If NumLigne <= 0 And Typ_Document_Text.Text <> "" Then
            ShowMessageBox("Veuillez sélectionner la ligne")
            Grd_ReglesSignatures.Item(Num_Ligne.Index, 0).Selected = True
            Grd_ReglesSignatures.Select()
            CType(sender, DataGridView).Item(e.ColumnIndex, e.RowIndex).Value = ""
            Exit Sub
        End If
        With Grd_Tbl
            If sender.name = Grd_Tbl.Name Then
                If IsNull(.Item(Num_Lig_Tbl.Index, e.RowIndex).Value, "") = "" And IsNull(.Item(Table_Liee.Index, e.RowIndex).Value, "") <> "" Then .Item(Num_Lig_Tbl.Index, e.RowIndex).Value = NumLigne
            End If
        End With
        With Grd_Signataires
            If sender.name = .Name Then
                If IsNull(.Item(Num_Lig_Signataires.Index, e.RowIndex).Value, "") = "" And IsNull(.Item(Signataire.Index, e.RowIndex).Value, "") <> "" Then .Item(Num_Lig_Signataires.Index, e.RowIndex).Value = NumLigne
            End If
        End With

    End Sub
#Region "Diviseurs"
    Sub Div_Next()
        Try
            If Typ_Document_Text.Text <> "" Then
                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Typ_Document_Text.Text & "'")
                End If
                Diviseur_Next("Param_Workflow_Typ_Document", "Typ_Document", "Typ_Document", Typ_Document_Text)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Div_Back()
        Try
            If Typ_Document_Text.Text <> "" Then
                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Typ_Document_Text.Text & "'")
                End If
                Diviseur_Back("Param_Workflow_Typ_Document", "Typ_Document", "Typ_Document", Typ_Document_Text)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Div_First()
        Try
            If Typ_Document_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Typ_Document_Text.Text & "'")
                End If


                Diviseur_First("Param_Workflow_Typ_Document", "Typ_Document", "Typ_Document", Typ_Document_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Div_Last()
        Try
            If Typ_Document_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Typ_Document_Text.Text & "'")
                End If


                Diviseur_Last("Param_Workflow_Typ_Document", "Typ_Document", "Typ_Document", Typ_Document_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Private Sub Grd_Signataires_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Signataires.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        If e.ColumnIndex = Signataire.Index Then
            Grd_Signataires.Cursor = Cursors.Hand
        Else
            Grd_Signataires.Cursor = Cursors.Default
        End If
    End Sub
#End Region
    Private Sub Grd_Signataires_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Signataires.CellDoubleClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return
        With Grd_Signataires
            If e.ColumnIndex = Signataire.Index Then
                Dim r As Integer = e.RowIndex
                Dim c As Integer = e.ColumnIndex
                If .Rows(r).IsNewRow Then .Rows.Insert(.RowCount - 1, "")
                Appel_Zoom1("MS166", .Item(c, r), Me, "", Societe.id_Societe)
                If .Item(c, r).Value <> "" Then
                    .Item(Nom.Index, r).Value = FindLibelle("ltrim(rtrim(isnull(Nom_User,'')+' ' + isnull(Prenom_User,'')))", "Login_User", .Item(c, r).Value, "Controle_Users")
                    .Item(Num_Lig_Signataires.Index, r).Value = NumLigne
                End If
            End If
        End With
    End Sub

    Private Sub Rd_List_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_List.CheckedChanged
        With Grd_Signataires
            .Visible = Rd_List.Checked
            pnlSignataire.Visible = Not .Visible
            Sigantaire_formulas_txt.Visible = pnlSignataire.Visible
            plusieursSignataires_lbl.Visible = Rd_Query.Checked
        End With
        With Grd_ReglesSignatures
            If Rd_List.Checked Then
                For i = 0 To .RowCount - 1
                    If NumLigne = .Item(Num_Ligne.Index, i).Value Then
                        .Item(Typ_Liste.Index, i).Value = "L"
                        Exit For
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub Rd_Query_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Query.CheckedChanged
        With pnlSignataire
            .Visible = Rd_Query.Checked
            Sigantaire_formulas_txt.Visible = Rd_Query.Checked
            plusieursSignataires_lbl.Visible = Rd_Query.Checked
            Grd_Signataires.Visible = Not .Visible
        End With
        With Grd_ReglesSignatures
            If Rd_Query.Checked Then
                For i = 0 To .RowCount - 1
                    If NumLigne = .Item(Num_Ligne.Index, i).Value Then
                        .Item(Typ_Liste.Index, i).Value = "F"
                        Sigantaire_formulas_txt.Text = .Item(Query_Sigantaire.Index, i).Value
                        Exit For
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub pbFormule_Click(sender As Object, e As EventArgs) Handles pbFormule.Click
        If Grd_ReglesSignatures.CurrentRow Is Nothing Then Return
        Dim f As New Zoom_Signataire_Relation
        With f
            .frm = Me
            .lig = Grd_ReglesSignatures.CurrentRow.Index
            .ShowDialog()
        End With
    End Sub
    Private Sub Grd_ReglesSignatures_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_ReglesSignatures.CellMouseDoubleClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return
        If e.ColumnIndex = Condition_Lig.Index Then
            Dim f As New Zoom_Signataire_Condition
            With f
                .frm = Me
                .lig = e.RowIndex
                .ShowDialog()
            End With
        End If

    End Sub
    Private Sub Grd_ReglesSignatures_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_ReglesSignatures.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        Grd_ReglesSignatures.Cursor = If(e.ColumnIndex = Condition_Lig.Index, Cursors.Hand, Cursors.Default)
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS166", Signataire_Defaut_txt, Me, "", Societe.id_Societe)
    End Sub

    Private Sub Signataire_Defaut_txt_TextChanged(sender As Object, e As EventArgs) Handles Signataire_Defaut_txt.TextChanged
        Nom_Signataire_Defaut_txt.Text = FindLibelle("Nom_Agent+ ' '+Prenom_Agent", "Matricule", Signataire_Defaut_txt.Text, "RH_Agent")
        If Nom_Signataire_Defaut_txt.Text = "" Then FindLibelle("Nom_User+ ' '+Prenom_User", "Login_User", Signataire_Defaut_txt.Text, "Controle_Users")
    End Sub
    Private Sub Grd_Tbl_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Tbl.CellMouseDoubleClick
        With Grd_Tbl
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return
            If table_Ref_txt.Text = "" Then Return
            Dim r As Integer = e.RowIndex
            Dim oldValue As String = IsNull(.Item(Table_Liee.Index, r).Value, "")
            Dim newValue As String = ""
            If e.ColumnIndex = Table_Liee.Index Then
                Dim txt As New TextBox
                With txt
                    .Location = Grd_Tbl.GetCellDisplayRectangle(Table_Liee.Index, r, True).Location
                    .Width = 0
                    .Height = 0
                    Grd_Tbl.Controls.Add(txt)
                End With
                Appel_Zoom("name", "name", "sys.objects", "type in ('U','V')", txt, Me)
                newValue = IsNull(txt.Text, "")
                .Controls.Remove(txt)
                If newValue <> oldValue Then
                    Dim liaisonStr As String = ""
                    Dim tbl As DataTable = DATA_READER_GRD("select s.COLUMN_NAME  from INFORMATION_SCHEMA.COLUMNS  s where TABLE_NAME in ('" & table_Ref_txt.Text & "','" & newValue & "')
and exists(select * from [INFORMATION_SCHEMA].[CONSTRAINT_COLUMN_USAGE] u where  u.COLUMN_NAME= s.COLUMN_NAME and u.TABLE_NAME in ('" & table_Ref_txt.Text & "','" & newValue & "'))
group by Column_Name
having count(*)>1")
                    For i = 0 To tbl.Rows.Count - 1
                        liaisonStr &= IIf(liaisonStr = "", "", " and ") & table_Ref_txt.Text & "." & tbl.Rows(i)("COLUMN_NAME") & " = " & newValue & "." & tbl.Rows(i)("COLUMN_NAME")
                    Next
                    If r = Grd_Tbl.RowCount - 1 And newValue <> "" Then
                        .Rows.Add()
                    End If
                    .Item(Table_Liee.Index, r).Value = newValue
                    .Item(Liaison.Index, r).Value = liaisonStr
                End If

            ElseIf e.ColumnIndex = Liaison.Index And IsNull(.Item(Table_Liee.Index, r).Value, "") <> "" Then
                Dim f As New Zoom_Signataire_Tables
                With f
                    .oCell = Grd_Tbl.CurrentCell
                    .ShowDialog()
                End With
            End If

        End With

    End Sub

    Private Sub RegrouperSignataires_chk_CheckedChanged(sender As Object, e As EventArgs)
        With Grd_ReglesSignatures
            Dim ind As Integer = -1
            For i = 0 To .Rows.Count - 1
                If IsNull(.Item(Num_Ligne.Index, i).Value, "0") = NumLigne Then
                    ind = i
                    Exit For
                End If
            Next
            If ind < 0 Then Return
        End With
    End Sub

    Private Sub Sigantaire_formulas_txt_TextChanged(sender As Object, e As EventArgs) Handles Sigantaire_formulas_txt.TextChanged
        If Rd_Query.Checked Or Not Rd_List.Checked Then
            Dim ind As Integer = -1
            With Grd_ReglesSignatures
                For i = 0 To .Rows.Count - 1
                    If IsNull(.Item(Num_Ligne.Index, i).Value, "0") = NumLigne Then
                        ind = i
                        Exit For
                    End If
                Next
                If ind < 0 Then Return
                .Item(Typ_Liste.Index, ind).Value = "F"
                .Item(Query_Sigantaire.Index, ind).Value = Sigantaire_formulas_txt.Text
            End With
        End If
    End Sub
End Class