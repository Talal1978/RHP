Public Class IR_Permanents
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
        Dim rs As New ADODB.Recordset
        Dim swhere As String = ""
        'vérification des champs obligatoires
        With Grd
            For i = 0 To .RowCount - IIf(.AllowUserToAddRows, 2, 1)
                If Not IsNumeric(IsNull(.Item("mtBrutTraitementSalaire", i).Value, "").Trim) Then .Item("mtBrutTraitementSalaire", i).Value = 0
                If Not IsNumeric(IsNull(.Item("periodejours", i).Value, "").Trim) Then .Item("periodejours", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtExonere", i).Value, "").Trim) Then .Item("mtExonere", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtEcheances", i).Value, "").Trim) Then .Item("mtEcheances", i).Value = 0
                If Not IsNumeric(IsNull(.Item("nbrReductions", i).Value, "").Trim) Then .Item("nbrReductions", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtIndemnite", i).Value, "").Trim) Then .Item("mtIndemnite", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtAvantages", i).Value, "").Trim) Then .Item("mtAvantages", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtRevenuBrutImposable", i).Value, "").Trim) Then .Item("mtRevenuBrutImposable", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtFraisProfess", i).Value, "").Trim) Then .Item("mtFraisProfess", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtCotisationAssur", i).Value, "").Trim) Then .Item("mtCotisationAssur", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtAutresRetenues", i).Value, "").Trim) Then .Item("mtAutresRetenues", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtRevenuNetImposable", i).Value, "").Trim) Then .Item("mtRevenuNetImposable", i).Value = 0
                If Not IsNumeric(IsNull(.Item("mtTotalDeduction", i).Value, "").Trim) Then .Item("mtTotalDeduction", i).Value = 0
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
                rs("nom").Value = IsNull(.Item("Nom", i).Value, "")
                rs("prenom").Value = IsNull(.Item("prenom", i).Value, "")
                rs("adressePersonnelle").Value = IsNull(.Item("adressePersonnelle", i).Value, "")
                rs("numCNI").Value = IsNull(.Item("numCNI", i).Value, "")
                rs("numCE").Value = IsNull(.Item("numCE", i).Value, "")
                rs("numPPR").Value = IsNull(.Item("numPPR", i).Value, "")
                rs("numCNSS").Value = IsNull(.Item("numCNSS", i).Value, "")
                rs("ifu").Value = IsNull(.Item("ifu", i).Value, "")
                rs("mtBrutTraitementSalaire").Value = IsNull(.Item("mtBrutTraitementSalaire", i).Value, 0)
                rs("periodejours").Value = IsNull(.Item("periodejours", i).Value, 0)
                rs("mtExonere").Value = IsNull(.Item("mtExonere", i).Value, 0)
                rs("mtEcheances").Value = IsNull(.Item("mtEcheances", i).Value, 0)
                rs("nbrReductions").Value = IsNull(.Item("nbrReductions", i).Value, 0)
                rs("mtIndemnite").Value = IsNull(.Item("mtIndemnite", i).Value, 0)
                rs("mtAvantages").Value = IsNull(.Item("mtAvantages", i).Value, 0)
                rs("mtRevenuBrutImposable").Value = IsNull(.Item("mtRevenuBrutImposable", i).Value, 0)
                rs("mtFraisProfess").Value = IsNull(.Item("mtFraisProfess", i).Value, 0)
                rs("mtCotisationAssur").Value = IsNull(.Item("mtCotisationAssur", i).Value, 0)
                rs("mtAutresRetenues").Value = IsNull(.Item("mtAutresRetenues", i).Value, 0)
                rs("mtRevenuNetImposable").Value = IsNull(.Item("mtRevenuNetImposable", i).Value, 0)
                rs("mtTotalDeduction").Value = IsNull(.Item("mtTotalDeduction", i).Value, 0)
                rs("irPreleve").Value = IsNull(.Item("irPreleve", i).Value, 0)
                rs("numMatricule").Value = IsNull(.Item("numMatricule", i).Value, "")
                rs("datePermis").Value = .Item("datePermis", i).Value
                rs("dateAutorisation").Value = .Item("dateAutorisation", i).Value
                rs("refSituationFamiliale").Value = IsNull(.Item("refSituationFamiliale", i).Value, "")
                rs("refTaux").Value = IsNull(.Item("refTaux", i).Value, "")
                rs("salaireBaseAnnuel").Value = IsNull(.Item("salaireBaseAnnuel", i).Value, 0)
                rs.Update()
                rs.Close()
            Next
        End With
        Notification("Enregistrement", "Enregistré avec succès", 1, "OK")

    End Sub

    Private Sub frm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        With Grd
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
            Dim HStyle As New DataGridViewCellStyle
            With HStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .ForeColor = Color.Red
            End With
            Grd.DataSource = Nothing
            If _Annee(0) <= 0 Then Return
            Dim nRow() As DataRow = Nothing
            Dim CodSql As String = "select  numMatricule, nom, prenom, adressePersonnelle, numCNI, numCE, numPPR, numCNSS, ifu,periodejours,salaireBaseAnnuel,
                                 mtBrutTraitementSalaire,mtAvantages,mtIndemnite, mtExonere,isnull(mtBrutTraitementSalaire,0)+ isnull(mtAvantages,0)+ isnull(mtIndemnite,0)- isnull(mtExonere,0) as mtRevenuBrutImposable, 
                                mtFraisProfess,mtCotisationAssur, 
                                mtEcheances,  mtAutresRetenues,isnull(mtEcheances,0)+ isnull(mtFraisProfess,0)+ isnull(mtCotisationAssur,0)+ isnull(mtAutresRetenues,0) as mtTotalDeduction,
                                ((isnull(mtBrutTraitementSalaire,0)+ isnull(mtAvantages,0)+ isnull(mtIndemnite,0)+ isnull(mtExonere,0))-(isnull(mtEcheances,0)+ isnull(mtFraisProfess,0)+ isnull(mtCotisationAssur,0)+ isnull(mtAutresRetenues,0))) as  mtRevenuNetImposable
                                ,nbrReductions,isnull(mtReductions,0) as mtReductions,   irPreleve,                               
                                datePermis, dateAutorisation, refSituationFamiliale, refTaux, Clef
                                FROM IR_Permanents
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
                TblIR.Columns("mtTotalDeduction").Expression = "isnull(mtEcheances,0)+ isnull(mtFraisProfess,0)+ isnull(mtCotisationAssur,0)+ isnull(mtAutresRetenues,0)"
                TblIR.Columns("mtRevenuBrutImposable").Expression = "isnull(mtBrutTraitementSalaire,0)+ isnull(mtAvantages,0)+ isnull(mtIndemnite,0)-isnull(mtExonere,0)"
                TblIR.Columns("mtRevenuNetImposable").Expression = "isnull(mtRevenuBrutImposable,0)-isnull(mtTotalDeduction,0)"
                For i = 0 To .ColumnCount - 1
                    nRow = TblDefD.Select("Cod_Element='" & .Columns(i).Name & "'")
                    If nRow.Length > 0 Then .Columns(i).HeaderText = CStr(nRow(0)("Lib_Element"))
                    Select Case .Columns(i).Name
                        Case "mtBrutTraitementSalaire", "salaireBaseAnnuel", "periodejours", "mtExonere", "mtEcheances", "nbrReductions", "mtReductions", "mtIndemnite", "mtAvantages", "mtFraisProfess", "mtCotisationAssur", "mtAutresRetenues", "irPreleve"
                            .Columns(i).DefaultCellStyle = oStyle
                        Case "mtRevenuBrutImposable", "mtRevenuNetImposable", "mtTotalDeduction"
                            .Columns(i).DefaultCellStyle = oStyle
                            .Columns(i).HeaderCell.Style = HStyle

                        Case "Clef"
                            .Columns("Clef").Visible = False
                    End Select
                Next
                .ColumnHeadersHeight = 55
                .setFilter({0, 1, 2})
            End With
            Contenu_Grp.Text = titre & " " & _Annee(0)
            Cursor = Cursors.Default
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Sub Nouveau()
        Grd.FirstDisplayedCell = Grd.Item(1, Grd.Rows.Count - 2)
        Grd.Item(1, Grd.Rows.Count - 1).Selected = True
    End Sub
    Private Sub Grd_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Grd.EditingControlShowing
        Dim c As Integer = Grd.CurrentCell.ColumnIndex

        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        With Grd
            Select Case c
                Case .Columns("refTaux").Index, .Columns("ifu").Index, .Columns("numCNSS").Index,
                     .Columns("mtBrutTraitementSalaire").Index, .Columns("periodejours").Index, .Columns("mtExonere").Index, .Columns("mtEcheances").Index, .Columns("nbrReductions").Index,
                     .Columns("mtIndemnite").Index, .Columns("mtAvantages").Index, .Columns("mtRevenuBrutImposable").Index,
                     .Columns("mtFraisProfess").Index, .Columns("mtCotisationAssur").Index,
                     .Columns("mtAutresRetenues").Index, .Columns("mtRevenuNetImposable").Index,
                     .Columns("mtTotalDeduction").Index, .Columns("irPreleve").Index, .Columns("salaireBaseAnnuel").Index
                    AddHandler e.Control.KeyPress, AddressOf CheckCell
            End Select
        End With
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
        CnExecuting("Delete from IR_Permanents where id_Societe=" & Societe.id_Societe & " and Annee_Paie =" & _Annee(0))
        request()
    End Sub
    Sub Printing()
        Dim Rpt As String = FindParam("Lecteur_Digital_Mod_Edition") & "\IR_Permanent.rpt"
        If IO.File.Exists(Rpt) = False Then
            MessageBoxRHP(551, Text)
            Exit Sub
        End If
        Dim f As New Zoom_Edition_Odbc
        With f
            .etat = Rpt
            .ParamList.Add("idSoc")
            .ValList.Add(Societe.id_Societe)
            .ParamList.Add("AnneePaie")
            .ValList.Add(_Annee(0))
            .Show()
        End With
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
            If Not Grd.DataSource Is Nothing Then
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
    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd.DataError
        Try

        Catch ex As Exception
            ShowMessageBox(e.Exception.Message)
        End Try
    End Sub




End Class