Public Class IR_Exoneres
    Dim titre As String = "Année de la déclaration : "
    Dim _Annee() As Integer = {-1}
    Dim SaisieLibre As Boolean = CnExecuting("select isnull((select top 1 isnull(Saisie_Libre,'false') from RH_Param_Declarations where id_Societe=" & Societe.id_Societe & " and Cod_Declaration='IR_Permanents'),'false')").Fields(0).Value
    Dim oCell As DataGridViewCell = Nothing
    Dim TblDefD As DataTable = DATA_READER_GRD("SELECT Cod_Element, Lib_Element, Typ_Data, Def_Valeur, Obligatoire, Rang, Flag
FROM         RH_Def_Declaration_Element
WHERE     (Cod_Declaration = 'IR_Permanents')
ORDER BY Rang")
    Sub Enregistrer()
        If EstCloturee = "C" Then
            ShowMessageBox("Période clôturée")
            Exit Sub
        End If
        If ShowMessageBox("Voulez-vous enregistrer?", "RHP", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then Exit Sub
        Cursor = Cursors.WaitCursor
        Try
            Dim rs As New ADODB.Recordset
            Dim swhere As String = ""
            'vérification des champs obligatoires
            With Grd
                For i = 0 To .RowCount - IIf(.AllowUserToAddRows, 2, 1)
                    If Not IsNumeric(IsNull(.Item("mtBrutTraitementSalaire", i).Value, "").Trim) Then .Item("mtBrutTraitementSalaire", i).Value = 0
                    If Not IsNumeric(IsNull(.Item("mtIndemniteArgentNature", i).Value, "").Trim) Then .Item("mtIndemniteArgentNature", i).Value = 0
                    If Not IsNumeric(IsNull(.Item("mtIndemniteFraisPro", i).Value, "").Trim) Then .Item("mtIndemniteFraisPro", i).Value = 0
                    If Not IsNumeric(IsNull(.Item("mtRevenuBrutImposable", i).Value, "").Trim) Then .Item("mtRevenuBrutImposable", i).Value = 0
                    If Not IsNumeric(IsNull(.Item("mtRetenuesOperees", i).Value, "").Trim) Then .Item("mtRetenuesOperees", i).Value = 0
                    If Not IsNumeric(IsNull(.Item("mtRevenuNetImposable", i).Value, "").Trim) Then .Item("mtRevenuNetImposable", i).Value = 0

                    If IsNull(.Item("Nom", i).Value, "").Trim = "" Or IsNull(.Item("prenom", i).Value, "").Trim = "" Then
                        ShowMessageBox("La Nom et prenom, sont obligatoires", "RHP")
                        .Rows(i).Selected = True
                        Exit Sub
                    End If
                    'Vérification des doublons
                    swhere &= IIf(swhere = "", "", ",") & IsNull(.Item("Clef", i).Value, -1)
                Next
                'Début d'enregistrement
                If swhere = "" Then
                    CnExecuting("delete from IR_Permanents where id_Societe=" & Societe.id_Societe & " and Annee_Paie=" & _Annee(0))
                Else
                    CnExecuting("delete from IR_Permanents where Clef not in (" & swhere & ") and id_Societe=" & Societe.id_Societe & " and Annee_Paie=" & _Annee(0))
                End If

                For i = 0 To .RowCount - IIf(.AllowUserToAddRows, 2, 1)
                    rs.Open("Select * from IR_Permanents where Clef='" & IsNull(.Item("Clef", i).Value, -1) & "' and id_Societe=" & Societe.id_Societe & " and Annee_Paie=" & _Annee(0), cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Annee_Paie").Value = _Annee(0)
                        rs("id_Societe").Value = Societe.id_Societe
                    Else
                        rs.Update()
                    End If
                    rs("nom").Value = IsNull(.Item("nom", i).Value, "")
                    rs("prenom").Value = IsNull(.Item("prenom", i).Value, "")
                    rs("adressePersonnelle").Value = IsNull(.Item("adressePersonnelle", i).Value, "")
                    rs("numCNI").Value = IsNull(.Item("numCNI", i).Value, "")
                    rs("numCE").Value = IsNull(.Item("numCE", i).Value, "")
                    rs("numCNSS").Value = IsNull(.Item("numCNSS", i).Value, "")
                    rs("ifu").Value = IsNull(.Item("ifu", i).Value, "")
                    rs("mtBrutTraitementSalaire").Value = IsNull(.Item("mtBrutTraitementSalaire", i).Value, 0)
                    rs("dateRecrutement").Value = IsNull(.Item("dateRecrutement", i).Value, "01/01/1900")
                    rs("mtIndemniteArgentNature").Value = IsNull(.Item("mtIndemniteArgentNature", i).Value, 0)
                    rs("mtIndemniteFraisPro").Value = IsNull(.Item("mtIndemniteFraisPro", i).Value, 0)
                    rs("mtRevenuBrutImposable").Value = IsNull(.Item("mtRevenuBrutImposable", i).Value, 0)
                    rs("mtRetenuesOperees").Value = IsNull(.Item("mtRetenuesOperees", i).Value, 0)
                    rs("mtRevenuNetImposable").Value = IsNull(.Item("mtRevenuNetImposable", i).Value, 0)
                    rs.Update()
                    rs.Close()
                Next
            End With
            Notification("Enregistrement", "Enregistré avec succès", 1, "OK")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Erreur")
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub frm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim TblAnnee As DataTable = DATA_READER_GRD("select Annee_Paie from RH_Preparation_Paie where  id_Societe=" & Societe.id_Societe & " group by Annee_Paie")
        With Grd
            .ContextMenuStrip = AddContextMenu(True, True, False, True, True, True, True, False)
            .AllowUserToAddRows = SaisieLibre
        End With
        If _Annee(0) = -1 Then _Annee = {CnExecuting("select isnull((select top 1 Annee from Param_Periode_Paie where id_Societe=" & Societe.id_Societe & " order by Annee desc),year(getdate()))").Fields(0).Value}
        request()
    End Sub
    Sub request()
        Try
            Cursor = Cursors.WaitCursor
            Dim Dat1 As DateTime = Now
            Dim oStyle As New DataGridViewCellStyle
            With oStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "N2"
            End With
            Grd.DataSource = Nothing
            If _Annee(0) <= 0 Then Return
            Dim nRow() As DataRow = Nothing
            Dim CodSql As String = "select nom, prenom, adressePersonnelle, numCNI, numCE, numCNSS, ifu, Periode, dateRecrutement, mtBrutTraitementSalaire, mtIndemniteArgentNature, 
                                     mtIndemniteFraisPro, mtRevenuBrutImposable, mtRetenuesOperees, mtRevenuNetImposable,Clef
                                    from IR_Exoneres
                                    where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & _Annee(0) & "'"
            Dim TblIR As DataTable = DATA_READER_GRD(CodSql)
            Dim Ind(TblIR.Columns.Count) As Integer
            With TblIR
                For i = 0 To .Columns.Count - 1
                    nRow = TblDefD.Select("Cod_Element='" & .Columns(i).ColumnName & "'")
                    If nRow.Length > 0 Then
                        .Columns(i).ReadOnly = IIf(SaisieLibre = True, False, (IsNull(nRow(0)("Flag"), "1") <> "2"))
                        Ind(i) = i
                    End If
                Next
            End With
            With Grd
                .DataSource = TblIR
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                For i = 0 To .ColumnCount - 1
                    nRow = TblDefD.Select("Cod_Element='" & .Columns(i).Name & "'")
                    If nRow.Length > 0 Then .Columns(i).HeaderText = CStr(nRow(0)("Lib_Element"))
                    Select Case .Columns(i).Name
                        Case "mtBrutTraitementSalaire", "mtIndemniteArgentNature", "mtIndemniteFraisPro", "mtRevenuBrutImposable", "mtRetenuesOperees", "mtRevenuNetImposable"
                            .Columns(i).DefaultCellStyle = oStyle
                        Case "Clef"
                            .Columns("Clef").Visible = False
                    End Select
                Next
                .ColumnHeadersHeight = 55
                .setFilter({0, 1})
                Contenu_Grp.Text = titre & " " & _Annee(0)
            End With
            Cursor = Cursors.Default
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Private Sub Grd_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim c As Integer = Grd.CurrentCell.ColumnIndex
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        Select Case c
            Case Grd.Columns("mtBrutTraitementSalaire").Index, Grd.Columns("mtIndemniteArgentNature").Index, Grd.Columns("mtIndemniteFraisPro").Index, Grd.Columns("mtRevenuBrutImposable").Index, Grd.Columns(" mtRetenuesOperees").Index, Grd.Columns("mtRevenuNetImposable").Index
                AddHandler e.Control.KeyPress, AddressOf CheckCell
        End Select
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Grd.CurrentRow Is Nothing Then Exit Sub
        Dim c As Integer = Grd.CurrentCell.ColumnIndex
        ControleSaisie(Grd.CurrentCell, e, True, False, True, False, False)
    End Sub
    Sub Deleting()
        If EstCloturee = "C" Then
            ShowMessageBox("Période clôturée")
            Exit Sub
        End If
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette liste?", "RHP", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Exit Sub
        CnExecuting("Delete from IR_Exoneres where id_Societe=" & Societe.id_Societe & " and Annee_Paie =" & _Annee(0))
        request()
    End Sub
    Sub Requesting()
        If SaisieLibre Then
            Dim f As New IR_Import
            With f
                .Combo_oModeleImport.SelectedValue = "IR_Permanents"
                .swhere = "  where Cod_Modele = 'IR_Permanents'  "
                newShowEcran(f, True)
            End With
        Else
            If Not Grd.DataSource Is Nothing Or Grd?.Columns.Count > 0 Then
                If ShowMessageBox("Etes-vous sûr de vouloir regénérer la déclaration?" & vbCrLf & "Attention : votre déclaration actuelle sera supprimée", "Regénération", MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Return
            End If
            If Not IsNumeric(_Annee(0)) Then
                ShowMessageBox("Sélectionnez l'année", "Regénération", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            CnExecuting("exec Sys_Declaration " & Societe.id_Societe & ",'IR_Permanents'," & _Annee(0) & ", ''")
        End If
        request()
    End Sub
    Sub Printing()
        Dim f As New Zoom_Edition_Odbc
        With f
            .etat = "00012.mtm"
            .ParamList.Add("Annee_Paie")
            .ValList.Add(_Annee(0))
            newShowEcran(f, True)
        End With
    End Sub
    Sub Actualiser()
        request()
    End Sub
    Sub selectAnnee()
        Dim f As New Zoom_Annee
        With f
            AddHandler .FormClosing, Sub()
                                         _Annee = ._annnee
                                     End Sub
            .ShowDialog()
            request()
        End With
    End Sub
End Class