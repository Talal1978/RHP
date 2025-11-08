Imports System.Text.RegularExpressions
Imports DevComponents.DotNetBar
Imports ExcelLibrary.Office.Excel
Public Class Survey
    Friend Code As String = ""
    Dim Tbl_TypReponse As New DataTable
    Dim dictRg As New Dictionary(Of String, Regex)
    Dim rgx As New Regex("[\w\'\s\-\+%àéèêâôîïö\?\!\<\>\=.\(\)]+(\[[COEDNT]\])?", RegexOptions.IgnoreCase)
    Dim rgxE As New Regex("\[[COEDNT]\]", RegexOptions.IgnoreCase)
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim modeScoring As New DataTable
    Private Sub Ctb_Compta_Axe_Ana_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS156", Cod_Survey_txt, Me)
    End Sub
    Sub chargementCombo()
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
        End If
        If Typ_Reponse.Items.Count = 0 Then
            Combo_GRD_Linked(Typ_Reponse, "select Typ_Reponse, Lib_Typ_Reponse from Survey_Typ_Reponse order by Rang")
            modeScoring = DATA_READER_GRD("select Membre, Valeur from Param_Rubriques where Nom_Controle='Mode_Scoring' order by Rang")
        End If
        '  If Mode_Scoring.Items.Count = 0 Then Combo_GRD(Mode_Scoring)
        Tbl_TypReponse = DATA_READER_GRD("select * from Survey_Typ_Reponse order by Rang")
        If Domaine_cbo.Items.Count = 0 Then Domaine_cbo.fromRubrique("Domaine_Survey")
        dictRg.Clear()
        With Tbl_TypReponse
            For i = 0 To .Rows.Count - 1
                If IsNull(.Rows(i)("Regex"), "") <> "" Then
                    dictRg.Add(.Rows(i)("Typ_Reponse"), New Regex(.Rows(i)("Regex"), RegexOptions.IgnoreCase))
                End If
            Next
        End With
    End Sub
    Private Sub Formation_Typ_Formation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chargementCombo()
    End Sub
    Private Sub Request()
        Try
            ' Nettoyage ancien contrôle d’accès lié au code courant
            If Not String.IsNullOrEmpty(Code) Then
                CnExecuting("DELETE FROM Controle_Access WHERE Name_Ecran='" & Me.Name & "' AND Value='" & Code & "'")
            End If

            ' Droits par défaut
            Save_D.Enabled = True
            Del_D.Enabled = True

            ' Droits selon profil et écran
            DroitAcces(Me, DroitModify_Fiche(Cod_Survey_txt.Text, Me))
            If Save_D.Enabled Then
                Check_Accessible(Me.Name, Cod_Survey_txt.Text)
                Code = Cod_Survey_txt.Text
            End If

            ' S’il existe déjà des réponses → verrouiller la fiche
            Dim rs = CnExecuting("SELECT COUNT(*) FROM Survey_Reply WHERE Cod_Survey='" & Cod_Survey_txt.Text & "' AND id_Societe=" & Societe.id_Societe)
            If rs IsNot Nothing AndAlso Convert.ToInt32(rs.Fields(0).Value) > 0 Then
                Save_D.Enabled = False
                Del_D.Enabled = False
            End If

            ' Chargement combos + entête
            chargementCombo()
            Lib_Survey_txt.Text = Convert.ToString(FindLibelle("Lib_Survey", "Cod_Survey", Cod_Survey_txt.Text, "Survey"))
            Dim rt As String = Convert.ToString(FindLibelle("Preambule", "Cod_Survey", Cod_Survey_txt.Text, "Survey"))
            Preambule_rtb.rtb.Rtf = If(String.IsNullOrEmpty(rt), "{\rtf1\ansi}", rt)

            Dim dom = FindLibelle("Domaine", "Cod_Survey", Cod_Survey_txt.Text, "Survey")
            If dom IsNot Nothing AndAlso dom IsNot DBNull.Value Then Domaine_cbo.SelectedValue = dom

            Dim avecNoteVal = FindLibelle("AvecNote", "Cod_Survey", Cod_Survey_txt.Text, "Survey")
            AvecNote_chk.Checked = If(avecNoteVal Is Nothing OrElse avecNoteVal Is DBNull.Value, False, CBool(avecNoteVal))

            Cod_Rubrique_txt.Text = Convert.ToString(FindLibelle("Cod_Rubrique", "Cod_Survey", Cod_Survey_txt.Text, "Survey"))

            ' Détails questions
            Dim sql As String =
            "SELECT Row_number() over (ORDER BY ISNULL(Rang,0)) as NumQuestion,* FROM Survey_Detail " &
            "WHERE Cod_Survey='" & Cod_Survey_txt.Text & "' AND id_Societe=" & Societe.id_Societe
            Dim Tbl As DataTable = DATA_READER_GRD(sql)

            Grd.SuspendLayout()
            Try
                Grd.Rows.Clear()

                If Tbl IsNot Nothing Then
                    For i As Integer = 0 To Tbl.Rows.Count - 1
                        Dim r = Tbl.Rows(i)
                        Grd.Rows.Add("")
                        With Grd
                            .Item(Question.Index, i).Value = IsNull(r("Question"), 0)
                            .Item(Obligatoire.Index, i).Value = IsNull(r("Obligatoire"), False)
                            .Item(Obligatoire_Si.Index, i).Value = IsNull(r("Obligatoire_Si"), "")
                            .Item(Typ_Reponse.Index, i).Value = IsNull(r("Typ_Reponse"), "")
                            updatingModeScoringCell(.Item(Typ_Reponse.Index, i).Value, i)
                            .Item(Regex.Index, i).Value = IsNull(r("Regex"), "")
                            .Item(Structure_Reponse.Index, i).Value = IsNull(r("Structure_Reponse"), "")
                            .Item(Mode_Scoring.Index, i).Value = If(AvecNote_chk.Checked, IsNull(r("Mode_Scoring"), "na"), Nothing)
                            .Item(Max_Score.Index, i).Value = If(AvecNote_chk.Checked, IsNull(r("Max_Score"), 0), Nothing)
                            .Item(Func_Scoring.Index, i).Value = If(AvecNote_chk.Checked, IsNull(r("Func_Scoring"), ""), Nothing)
                            .Item(Coef.Index, i).Value = If(AvecNote_chk.Checked, IsNull(r("Coef"), 1), Nothing)
                            .Item(Coef.Index, i).Value = If(AvecNote_chk.Checked, IsNull(r("Coef"), 1), Nothing)
                            .Item(Erreur_Si.Index, i).Value = IsNull(r("Erreur_Si"), "")
                            .Item(Erreur_Msg.Index, i).Value = IsNull(r("Erreur_Msg"), "")
                            .Item(Rang.Index, i).Value = IsNull(r("NumQuestion"), 0)
                            .Item(RowId.Index, i).Value = IsNull(r("RowId"), 0)
                        End With
                    Next
                End If
            Finally
                Grd.ResumeLayout()
            End Try
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub


    Private Sub Domaines_Competence_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Survey_txt.TextChanged
        If Cod_Survey_txt.ReadOnly Then Request()
    End Sub

    Private Sub Grd_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles Grd.UserDeletingRow
        e.Cancel = e.Row.ReadOnly
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        Lib_Survey_txt.Select()
    End Sub
    Sub Enregistrer()
        If Lib_Survey_txt.Text = "" Then
            ShowMessageBox("Renseignez le libellé de l'enquête.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim nrw() As DataRow = Nothing
        Dim swhere As String = ""

        With Grd
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Question.Index, i).Value, "").Trim = "" Then
                    ShowMessageBox("Question vide.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
                    .FirstDisplayedCell = .Item(Question.Index, i)
                    Return
                End If
                If IsNull(.Item(Typ_Reponse.Index, i).Value, "").Trim = "" Then
                    ShowMessageBox("Type de réponse vide.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
                    .FirstDisplayedCell = .Item(Question.Index, i)
                    Return
                End If
                nrw = Tbl_TypReponse.Select("Typ_Reponse='" & .Item(Typ_Reponse.Index, i).Value & "'")
                If nrw.Length > 0 Then
                    .Item(Regex.Index, i).Value = IsNull(nrw(0)("Regex"), "")
                Else
                    .Item(Regex.Index, i).Value = ""
                End If
                If dictRg.ContainsKey(.Item(Typ_Reponse.Index, i).Value) Then
                    If Not dictRg(.Item(Typ_Reponse.Index, i).Value).IsMatch(IsNull(.Item(Structure_Reponse.Index, i).Value, "")) Then
                        ShowMessageBox("Erreur de structure réponse : " & vbCrLf & "La structure de réponse doit être de ce type : " &
                                        vbCrLf & Tbl_TypReponse.Select("Typ_Reponse='" & .Item(Typ_Reponse.Index, i).Value & "'")(0)("Exemple"), "Validation", MessageBoxButtons.OK, msgIcon.Stop)
                        .FirstDisplayedCell = .Item(Question.Index, i)
                        .Item(Question.Index, i).Selected = True
                        Return
                    End If
                End If
                If IsNull(.Item(RowId.Index, i).Value, "") <> "" Then swhere &= IIf(swhere = "", "", ",") & .Item(RowId.Index, i).Value
                If Not IsNumeric(.Item(Rang.Index, i).Value) Then
                    .Item(Rang.Index, i).Value = i
                End If
                If AvecNote_chk.Checked Then
                    If IsNull(.Item(Mode_Scoring.Index, i).Value, "").Trim = "" Then
                        ShowMessageBox("Mode scoring vide.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
                        .FirstDisplayedCell = .Item(Mode_Scoring.Index, i)
                        .Item(Mode_Scoring.Index, i).Selected = True
                        Return
                    End If
                    If IsNull(.Item(Max_Score.Index, i).Value, 0) > 0 And IsNull(.Item(Coef.Index, i).Value, 0) = 0 Then
                        ShowMessageBox("Coefficient nul.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
                        .FirstDisplayedCell = .Item(Coef.Index, i)
                        .Item(Coef.Index, i).Selected = True
                        Return
                    End If
                    If IsNull(.Item(Max_Score.Index, i).Value, 0) = 0 And Not "na;auto;func".Split(";").Contains(.Item(Mode_Scoring.Index, i).Value) And IsNull(.Item(Coef.Index, i).Value, 0) > 0 Then
                        ShowMessageBox("Maximum nul.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
                        .FirstDisplayedCell = .Item(Max_Score.Index, i)
                        .Item(Max_Score.Index, i).Selected = True
                        Return
                    End If
                    If IsNull(.Item(Func_Scoring.Index, i).Value, "").Trim = "" And .Item(Mode_Scoring.Index, i).Value = "func" Then
                        ShowMessageBox("Incohérence mode scoring et le texte de la fonction.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
                        .FirstDisplayedCell = .Item(Mode_Scoring.Index, i)
                        .Item(Mode_Scoring.Index, i).Selected = True
                        Return
                    ElseIf IsNull(.Item(Func_Scoring.Index, i).Value, "").Trim = "" And .Item(Mode_Scoring.Index, i).Value = "func" Then
                        ShowMessageBox("Syntaxe de la fonction vide.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
                        .FirstDisplayedCell = .Item(Func_Scoring.Index, i)
                        .Item(Func_Scoring.Index, i).Selected = True
                        Return
                    End If
                End If
            Next
        End With
        Dim leCode As String = Cod_Survey_txt.Text
        If leCode = "" Then
            CnExecuting("exec Sys_Compteur 'Survey'," & Societe.id_Societe)
            leCode = FindLibelle("Last_Code", "Fichier", "Survey", "Param_Compteur")
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Survey where Cod_Survey='" & leCode & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Cod_Survey").Value = leCode
            rs("id_Societe").Value = Societe.id_Societe
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()
        End If
        rs("Lib_Survey").Value = Lib_Survey_txt.Text
        rs("Preambule").Value = Preambule_rtb.rtb.Rtf
        rs("Domaine").Value = Domaine_cbo.SelectedValue
        rs("AvecNote").Value = AvecNote_chk.Checked
        rs("Cod_Rubrique").Value = Cod_Rubrique_txt.Text
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()
        With Grd
            If swhere <> "" Then
                CnExecuting("delete from Survey_Detail where Cod_Survey='" & leCode & "' and RowId not in (" & swhere & ") and id_Societe=" & Societe.id_Societe)
            End If
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Question.Index, i).Value, "") <> "" Then
                    rs.Open("select * from Survey_Detail where Cod_Survey='" & leCode & "' and id_Societe=" & Societe.id_Societe & " and RowId ='" & IsNull(.Item(RowId.Index, i).Value, 0) & "'")
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Cod_Survey").Value = leCode
                        rs("id_Societe").Value = Societe.id_Societe
                    Else
                        rs.Update()
                    End If
                    rs("Question").Value = .Item(Question.Index, i).Value
                    rs("Typ_Reponse").Value = .Item(Typ_Reponse.Index, i).Value
                    rs("Regex").Value = IsNull(.Item(Regex.Index, i).Value, "")
                    rs("Structure_Reponse").Value = IsNull(.Item(Structure_Reponse.Index, i).Value, "")
                    If AvecNote_chk.Checked Then
                        rs("Mode_Scoring").Value = IsNull(.Item(Mode_Scoring.Index, i).Value, "manuel")
                        If rs("Mode_Scoring").Value = "na" Then
                            rs("Max_Score").Value = Nothing
                            rs("Func_Scoring").Value = Nothing
                            rs("Coef").Value = Nothing
                        ElseIf rs("Mode_Scoring").Value = "func" Then
                            rs("Max_Score").Value = Nothing
                            rs("Func_Scoring").Value = .Item(Func_Scoring.Index, i).Value
                            rs("Coef").Value = IsNull(.Item(Coef.Index, i).Value, 1)
                        ElseIf rs("Mode_Scoring").Value = "auto" Then
                            rs("Max_Score").Value = Nothing
                            rs("Func_Scoring").Value = Nothing
                            rs("Coef").Value = IsNull(.Item(Coef.Index, i).Value, 1)
                        Else
                            rs("Max_Score").Value = IsNull(.Item(Max_Score.Index, i).Value, 1)
                            rs("Func_Scoring").Value = ""
                            rs("Coef").Value = IsNull(.Item(Coef.Index, i).Value, 1)
                        End If
                    Else
                        rs("Coef").Value = Nothing
                        rs("Mode_Scoring").Value = Nothing
                        rs("Max_Score").Value = Nothing
                    End If
                    rs("Rang").Value = .Item(Rang.Index, i).Value
                    rs("Obligatoire_Si").Value = .Item(Obligatoire_Si.Index, i).Value
                    If IsNull(rs("Obligatoire_Si").Value, "").Trim <> "" Then
                        rs("Obligatoire").Value = True
                    Else
                        rs("Obligatoire").Value = IsNull(.Item(Obligatoire.Index, i).Value, False)
                    End If
                    rs("Erreur_Si").Value = .Item(Erreur_Si.Index, i).Value
                    rs("Erreur_Msg").Value = .Item(Erreur_Msg.Index, i).Value
                    Select Case IsNull(.Item(Typ_Reponse.Index, i).Value, "")
                            Case "grille_cases", "grille_choix"
                                Dim colonnes As String = ""
                                Dim lignes As String = ""
                                For Each c As Match In dictRg(.Item(Typ_Reponse.Index, i).Value).Matches(IsNull(.Item(Structure_Reponse.Index, i).Value, ""))
                                    If c.Groups("Col").Value.Trim <> "" Then
                                        colonnes = c.Groups("Col").Value.Trim
                                        Exit For
                                    End If
                                Next
                                For Each c As Match In dictRg(.Item(Typ_Reponse.Index, i).Value).Matches(IsNull(.Item(Structure_Reponse.Index, i).Value, ""))
                                    If c.Groups("Lig").Value.Trim <> "" Then
                                        lignes = c.Groups("Lig").Value.Trim
                                        Exit For
                                    End If
                                Next
                                Dim str() As String = lignes.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                                lignes = ""
                                For n = 0 To str.Length - 1
                                    If str(n).Trim <> "" Then lignes &= IIf(lignes = "", "", ";") & str(n).Trim
                                Next
                                str = colonnes.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                                colonnes = ""
                                For n = 0 To str.Length - 1
                                    If str(n).Trim <> "" Then colonnes &= IIf(colonnes = "", "", ";") & str(n).Trim
                                Next
                                rs("Sous_Question").Value = lignes
                                rs("Reponses_Possibles").Value = colonnes
                            Case "grille_libre"
                                Dim colonnes As String = ""
                                Dim lignes As String = ""
                                Dim nbLig As Object = Nothing
                                For Each c As Match In dictRg(.Item(Typ_Reponse.Index, i).Value).Matches(IsNull(.Item(Structure_Reponse.Index, i).Value, ""))
                                    If c.Groups("Col").Value.Trim <> "" Then
                                        colonnes = c.Groups("Col").Value.Trim
                                        Exit For
                                    End If
                                Next
                                Dim str As String = colonnes
                                colonnes = ""
                                For Each c As Match In rgx.Matches(str)
                                    If c.Value.Trim <> "" Then
                                        If Not rgxE.IsMatch(c.Value.Trim) Then
                                            colonnes &= IIf(colonnes = "", "", ";") & c.Value.Trim & "[T]"
                                        Else
                                            colonnes &= IIf(colonnes = "", "", ";") & c.Value.Trim
                                        End If
                                    End If
                                Next
                                For Each c As Match In dictRg(.Item(Typ_Reponse.Index, i).Value).Matches(IsNull(.Item(Structure_Reponse.Index, i).Value, ""))
                                    If c.Groups("Lig").Value.Trim <> "" Then
                                        nbLig = c.Groups("Lig").Value.Trim
                                        Exit For
                                    End If
                                Next
                                str = ""
                                For k = 0 To IIf(IsNumeric(nbLig), ConvertEntier(nbLig), 1) - 1
                                    str &= IIf(str = "", "", ";") & k
                                Next
                                rs("Sous_Question").Value = str
                                rs("Reponses_Possibles").Value = colonnes
                            Case "cocher", "choix", "liste"
                                Dim colonnes As String = IsNull(.Item(Structure_Reponse.Index, i).Value, "")
                                Dim lignes As String = .Item(Question.Index, i).Value
                                Dim str() As String = colonnes.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                                colonnes = ""
                                For n = 0 To str.Length - 1
                                    If str(n).Trim <> "" Then colonnes &= IIf(colonnes = "", "", ";") & str(n).Trim
                                Next
                                rs("Sous_Question").Value = lignes
                                rs("Reponses_Possibles").Value = colonnes
                            Case "oui_non"
                                Dim colonnes As String = "Oui;Non"
                                Dim lignes As String = .Item(Question.Index, i).Value
                                rs("Sous_Question").Value = lignes
                                rs("Reponses_Possibles").Value = colonnes
                            Case "vrai_faux"
                                Dim colonnes As String = "Vrai;Faux"
                                Dim lignes As String = .Item(Question.Index, i).Value
                                rs("Sous_Question").Value = lignes
                                rs("Reponses_Possibles").Value = colonnes
                            Case "echelle"
                                Dim min_ As String = ""
                                Dim max_ As String = ""
                                Dim colonnes As String = ""
                                Dim lignes As String = .Item(Question.Index, i).Value
                                For Each c As Match In dictRg(.Item(Typ_Reponse.Index, i).Value).Matches(IsNull(.Item(Structure_Reponse.Index, i).Value, ""))
                                    If c.Groups("min").Value.Trim <> "" Then
                                        min_ = c.Groups("min").Value.Trim
                                        Exit For
                                    End If
                                Next
                                For Each c As Match In dictRg(.Item(Typ_Reponse.Index, i).Value).Matches(IsNull(.Item(Structure_Reponse.Index, i).Value, ""))
                                    If c.Groups("max").Value.Trim <> "" Then
                                        max_ = c.Groups("max").Value.Trim
                                        Exit For
                                    End If
                                Next
                                If IsNumeric(min_) And IsNumeric(max_) Then
                                    If CInt(min_) < CInt(max_) Then
                                        For k = CInt(min_) To CInt(max_)
                                            colonnes &= IIf(colonnes = "", "", ";") & k
                                        Next
                                    End If
                                End If
                                rs("Sous_Question").Value = lignes
                                rs("Reponses_Possibles").Value = colonnes
                            Case Else
                                Dim lignes As String = .Item(Question.Index, i).Value
                                rs("Sous_Question").Value = lignes
                                rs("Reponses_Possibles").Value = ""
                        End Select
                        rs.Update()
                        rs.Close()
                    End If
            Next
        End With
        If Cod_Survey_txt.Text = "" Then
            Cod_Survey_txt.Text = leCode
        Else
            Request()
        End If
        ShowMessageBox("Enregistré avec succès")
    End Sub
    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd.DataError

    End Sub
    Sub Deleting()
        If Cod_Survey_txt.Text = "" Then Return
        Return
        Diviseur_delete("GPEC_Domaines_Competence", "Domaines_Competence", "Domaines_Competence", Cod_Survey_txt, Me, True)
    End Sub

    Private Sub Grd_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellValidated
        If e.RowIndex < 0 Or e.RowIndex >= Grd.RowCount - 1 Then Return
        If e.ColumnIndex = Typ_Reponse.Index Then
            Dim typ As String = IsNull(Grd.Item(Typ_Reponse.Index, e.RowIndex).Value, "")
            Dim nrw() As DataRow = Tbl_TypReponse.Select("Typ_Reponse='" & typ & "'")
            Dim cell As DataGridViewComboBoxCell = TryCast(Grd.Rows(e.RowIndex).Cells("Mode_Scoring"), DataGridViewComboBoxCell)
            If nrw.Length > 0 Then
                Grd.Item(Regex.Index, e.RowIndex).Value = IsNull(nrw(0)("Regex"), "")
                Grd.Item(Structure_Reponse.Index, e.RowIndex).Value = IsNull(nrw(0)("Exemple"), "")
                If AvecNote_chk.Checked Then
                    updatingModeScoringCell(typ, e.RowIndex)
                End If
            Else
                Grd.Item(Regex.Index, e.RowIndex).Value = ""
                Grd.Item(Structure_Reponse.Index, e.RowIndex).Value = ""
                If AvecNote_chk.Checked Then
                    If cell Is Nothing Then Exit Sub
                    cell.DataSource = Nothing
                End If
            End If
        ElseIf e.ColumnIndex = Mode_Scoring.Index Then
            If IsNull(Grd.Item(Mode_Scoring.Index, e.RowIndex).Value, "") <> "func" Then
                Grd.Item(Func_Scoring.Index, e.RowIndex).Value = ""
            ElseIf "auto;func".Split(";").Contains(Grd.Item(Mode_Scoring.Index, e.RowIndex).Value) Then
                Grd.Item(Max_Score.Index, e.RowIndex).Value = 0
            End If
        End If
    End Sub

    Private Sub Grd_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd.CellMouseDoubleClick
        If e.ColumnIndex = Typ_Reponse.Index And Cursor = Cursors.Help Then
            Dim nrw() As DataRow = Tbl_TypReponse.Select("Typ_Reponse='" & IsNull(Grd.Item(Typ_Reponse.Index, e.RowIndex).Value, "") & "'")
            If nrw.Length > 0 Then
                ShowMessageBox("Exemple de structure de réponse : " & vbCrLf & nrw(0)("Exemple"), nrw(0)("Lib_Typ_Reponse"), MessageBoxButtons.OK, msgIcon.Information)
            End If
        ElseIf e.ColumnIndex = Func_Scoring.Index And Grd.Cursor = Cursors.Hand Then
            Dim f As New Zoom_Survey_Editeur_Formule
            With f
                .otxt = Grd.Item(Func_Scoring.Index, e.RowIndex)
                .formulafunction = IsNull(Grd.Item(Func_Scoring.Index, e.RowIndex).Value, "")
                .TypRetour = "float"
                .ShowDialog()
            End With
        ElseIf e.ColumnIndex = Erreur_Si.Index And Grd.Cursor = Cursors.Hand Then
            Dim f As New Zoom_Survey_Editeur_Formule
            With f
                .otxt = Grd.Item(Erreur_Si.Index, e.RowIndex)
                .formulafunction = IsNull(Grd.Item(Erreur_Si.Index, e.RowIndex).Value, "")
                .TypRetour = "bit"
                If f.Function_Trv.Nodes("RSP").Nodes.ContainsKey("CurrentAnswer") Then f.Function_Trv.Nodes("RSP").Nodes.RemoveByKey("CurrentAnswer")
                Dim nd As New TreeNode
                nd.Name = $"Q[{e.RowIndex + 1}]"
                nd.Text = $"La réponse"
                nd.Tag = nd.Name
                f.Function_Trv.Nodes("RSP").Nodes.Add(nd)
                .ShowDialog()
            End With
        ElseIf e.ColumnIndex = Obligatoire_Si.Index And Grd.Cursor = Cursors.Hand Then
            Dim f As New Zoom_Survey_Editeur_Formule
            With f
                .otxt = Grd.Item(Obligatoire_Si.Index, e.RowIndex)
                .formulafunction = IsNull(Grd.Item(Obligatoire_Si.Index, e.RowIndex).Value, "")
                .TypRetour = "bit"
                If f.Function_Trv.Nodes("RSP").Nodes.ContainsKey("CurrentAnswer") Then f.Function_Trv.Nodes("RSP").Nodes.RemoveByKey("CurrentAnswer")
                With Grd
                    For i = 0 To .RowCount - 2
                        If i <> e.RowIndex Then
                            Dim nd As New TreeNode
                            nd.Name = $"Q[{i + 1}]"
                            nd.Text = $"Question {String.Format("{0:D3}", i + 1)}"
                            nd.Tag = nd.Name
                            f.Function_Trv.Nodes("RSP").Nodes.Add(nd)
                        End If
                    Next
                End With
                .ShowDialog()
            End With
        End If
    End Sub

    Sub Appercu()
        Dim f As New Survey_render
        With f
            .CodSurvey = Cod_Survey_txt.Text
            newShowEcran(f, True)
        End With
    End Sub

    Sub getHelp()
        Dim f As New Zoom_Survey_Typ_Reponse_Help
        f.ShowDialog()
    End Sub

    Private Sub Rub__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Rub_.LinkClicked
        Appel_Zoom1("MS009", Cod_Rubrique_txt, Me, "isnull(EV,0)=1")
    End Sub

    Private Sub Cod_Rubrique_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Rubrique_txt.TextChanged
        Lib_Rubrique_txt.Text = FindLibelle("Lib_Rubrique", "Cod_Rubrique", Cod_Rubrique_txt.Text, "RH_Paie_Rubrique")
    End Sub

    Private Sub AvecNote_chk_CheckedChanged(sender As Object, e As EventArgs) Handles AvecNote_chk.CheckedChanged
        Rub_.Visible = AvecNote_chk.Checked
        Cod_Rubrique_txt.Visible = AvecNote_chk.Checked And Domaine_cbo.SelectedValue = "E"
        Lib_Rubrique_txt.Visible = AvecNote_chk.Checked And Domaine_cbo.SelectedValue = "E"
        Coef.Visible = AvecNote_chk.Checked
        Max_Score.Visible = AvecNote_chk.Checked
        Mode_Scoring.Visible = AvecNote_chk.Checked
        Func_Scoring.Visible = AvecNote_chk.Checked
    End Sub
    Private Function ModeScoringTable(modeScoresPossibles As String()) As DataTable
        Dim rows() As DataRow = modeScoring.Select($"Valeur in ('{String.Join("', '", modeScoresPossibles)}')")
        If rows Is Nothing OrElse rows.Length = 0 Then
            Return modeScoring.Clone() ' vide mais typé
        End If
        Return rows.CopyToDataTable()
    End Function
    Sub updatingModeScoringCell(typ As String, lig As Integer)
        Dim modeScoresPossibles() As String = IsNull(Tbl_TypReponse.Select($"Typ_Reponse='{typ}'")(0)("Mode_Scoring_Possible"), "manuel").Split(";")
        Dim cell As DataGridViewComboBoxCell = TryCast(Grd.Rows(lig).Cells("Mode_Scoring"), DataGridViewComboBoxCell)
        If cell Is Nothing Then Exit Sub
        'si la datasource actuelle est la même que celle à appliquer quitter sans rien faire
        If modeScoresPossibles.Contains(cell.Value) Then Return
        cell.DisplayMember = "Membre"   ' Doit correspondre à la colonne de votre DataTable
        cell.ValueMember = "Valeur"     ' Idem
        Dim src As DataTable = ModeScoringTable(modeScoresPossibles)
        cell.DataSource = src
    End Sub
    Private Sub Grd_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellEnter
        If e.RowIndex < 0 Or e.RowIndex >= Grd.RowCount - 1 Then Exit Sub
        Dim typ As String = IsNull(Grd.Item(Typ_Reponse.Index, e.RowIndex).Value, "")
        If e.ColumnIndex = Mode_Scoring.Index And AvecNote_chk.Checked Then
            updatingModeScoringCell(typ, e.RowIndex)
        End If
    End Sub

    Private Sub Grd_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd.CellMouseMove
        If e.RowIndex < 0 And e.RowIndex >= Grd.RowCount - 1 Then Return
        Try
            If e.ColumnIndex = Func_Scoring.Index And AvecNote_chk.Checked Then
                Grd.Cursor = If(IsNull(Grd.Item(Mode_Scoring.Index, e.RowIndex).Value, "") = "func", Cursors.Hand, Cursors.Default)
            ElseIf e.ColumnIndex = Obligatoire_Si.Index Or e.ColumnIndex = Erreur_Si.Index Then
                Grd.Cursor = Cursors.Hand
            Else
                Grd.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Grd.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub Grd_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.RowValidated
        If e.RowIndex = Grd.RowCount - 2 And IsNull(Grd.Item(Rang.Index, e.RowIndex).Value, 0) = 0 Then
            Grd.Item(Rang.Index, e.RowIndex).Value = Grd.RowCount - 1
        End If
    End Sub
End Class