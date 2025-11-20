Imports System.Text.RegularExpressions
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraCharts.Native
Imports DevExpress.XtraRichEdit.Model
Public Class RH_Param_Abaques

    Private Sub Cod_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Abaque_lbl.LinkClicked
        Appel_Zoom1("MS169", Cod_Abaque_txt, Me)
    End Sub

    Private Sub Nom_Controle_Text_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cod_Abaque_txt.Leave
        Cod_Abaque_txt.BackColor = Me.BackColor
        Cod_Abaque_txt.ReadOnly = True
    End Sub

    Private Sub Nom_Controle_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Abaque_txt.TextChanged
        Request()
    End Sub

    Sub Request()
        ChargementCombo()
        Dim Cod_Sql As String
        Cod_Sql = "select * from RH_Param_Abaques e left join  RH_Param_Abaques_Detail d on e.Cod_Abaque=d.Cod_Abaque and e.id_Societe=d.id_Societe where e.Cod_Abaque = '" & Cod_Abaque_txt.Text & "' and isnull(Nullif(e.id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe
        Dim Tbl = DATA_READER_GRD(Cod_Sql)
        Dim nbClef = 1
        Dim nbVals = 1
        abaque_GRD.Rows.Clear()
        With Tbl
            If .Rows.Count > 0 Then
                Lib_Abaque_txt.Text = IsNull(.Rows(0)("Lib_Abaque"), "")
                Typ_Retour.SelectedValue = IsNull(.Rows(0)("Typ_Retour"), "")
                DefaultVal_txt.Text = IsNull(.Rows(0)("DefaultVal"), "").Replace("""", "")
                fonction_rd.Checked = (IsNull(.Rows(0)("Typ_DefaultVal"), "C") = "F")
                Variable_Paie_chk.Checked = IsNull(.Rows(0)("Variable_Paie"), False)
                Constante_rd.Checked = Not fonction_rd.Checked
                nbClef = IsNull(.Rows(0)("Nb_Clefs"), 1)
                nbVals = IsNull(.Rows(0)("Nb_Valeurs"), 1)
                If IsNumeric(nbClef) Then
                    nbClef = Math.Max(Math.Min(CInt(nbClef), 4), 1)
                Else
                    nbClef = 1
                End If
                If IsNumeric(nbVals) Then
                    nbVals = Math.Max(Math.Min(CInt(nbVals), 4), 1)
                Else
                    nbVals = 1
                End If
                Global_chk.Checked = (IsNull(.Rows(0)("id_Societe"), Societe.id_Societe) = -1)
                Dim C1, C2, C3, C4, C5, C6, C7, C8, C9 As Object
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i).Item("Clef_01"), "")
                    C2 = IsNull(.Rows(i).Item("Clef_02"), "")
                    C3 = IsNull(.Rows(i).Item("Clef_03"), "")
                    C4 = IsNull(.Rows(i).Item("Clef_04"), "")
                    C5 = IsNull(.Rows(i).Item("Valeur_01"), "")
                    C6 = IsNull(.Rows(i).Item("Valeur_02"), "")
                    C7 = IsNull(.Rows(i).Item("Valeur_03"), "")
                    C8 = IsNull(.Rows(i).Item("Valeur_04"), "")
                    C9 = IsNull(.Rows(i).Item("Flag"), "")
                    abaque_GRD.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C9)
                Next
            Else
                Lib_Abaque_txt.Text = ""
                DefaultVal_txt.Text = ""
                Typ_Retour.SelectedItem = "nvarchar(max)"
                Global_chk.Checked = False
                Constante_rd.Checked = True
                fonction_rd.Checked = False
            End If
        End With
        Nb_Clefs.Value = nbClef
        Nb_Valeurs.Value = nbVals
        Clef_01.Visible = nbClef >= 1
        Clef_02.Visible = nbClef >= 2
        Clef_03.Visible = nbClef >= 3
        Clef_04.Visible = nbClef >= 4
        Valeur_01.Visible = nbVals >= 1
        Valeur_02.Visible = nbVals >= 2
        Valeur_03.Visible = nbVals >= 3
        Valeur_04.Visible = nbVals >= 4

        MiseEnformeGrd()
    End Sub
    Dim rg As New System.Text.RegularExpressions.Regex("\W")
    Function ControleCaracteresSpeciaux(ColIndex As Integer, rowIndex As Integer) As Boolean
        With abaque_GRD
            If .Columns(ColIndex).Visible Then
                If IsNull(.Item(ColIndex, rowIndex).Value, "").Trim = "" Then
                    ShowMessageBox("Valeur non renseignée.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    .Rows(rowIndex).Selected = True
                    .FirstDisplayedCell = .Item(ColIndex, rowIndex)
                    Return False
                End If
                'If rg.IsMatch(.Item(ColIndex, rowIndex).Value) Then
                '    ShowMessageBox("Evtitez les caractères spéciaux.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    .Rows(rowIndex).Selected = True
                '    .FirstDisplayedCell = .Item(ColIndex, rowIndex)
                '    Return False
                'End If

            Else
                .Item(ColIndex, rowIndex).Value = ""
            End If

        End With
        Return True
    End Function
    Function ControleValeurs(ColIndex As Integer, rowIndex As Integer) As Boolean
        With abaque_GRD
            If .Columns(ColIndex).Visible Then
                If "float;int".Split(";").Contains(Typ_Retour.SelectedValue) Then
                    If Not IsNumeric(.Item(ColIndex, rowIndex).Value) Then
                        ShowMessageBox("Valeur non numérique.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        .Rows(rowIndex).Selected = True
                        .FirstDisplayedCell = .Item(ColIndex, rowIndex)
                        Return False
                    ElseIf Typ_Retour.SelectedValue = "int" Then
                        If CDbl(.Item(ColIndex, rowIndex).Value) <> CInt(.Item(ColIndex, rowIndex).Value) Then
                            .Item(ColIndex, rowIndex).Value = CInt(.Item(ColIndex, rowIndex).Value)
                        End If
                    End If
                End If
            Else
                .Item(ColIndex, rowIndex).Value = Nothing
            End If

        End With
        Return True
    End Function
    Sub MiseEnformeGrd()
        With abaque_GRD
            ' Parcourir les colonnes Valeur_01 à Valeur_04
            For i As Integer = 1 To 4
                Dim colonneNom As String = "Valeur_" & i.ToString("00")

                ' Vérifier si la colonne existe dans le DataGridView
                If .Columns.Contains(colonneNom) Then
                    Dim colonne = .Columns(colonneNom)
                    ' Si le type est numérique (float, int, bigint, decimal, etc.)
                    If "float;int".Split(";"c).Contains(Typ_Retour.SelectedValue?.ToString()?.ToLower()) Then
                        ' Alignement à droite
                        colonne.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        ' Format avec séparateur de milliers
                        If Typ_Retour.SelectedValue?.ToString()?.ToLower() = "int" Then
                            ' Format entier avec séparateur de milliers
                            colonne.DefaultCellStyle.Format = "N0"
                        Else
                            ' Format décimal avec 2 décimales et séparateur de milliers
                            colonne.DefaultCellStyle.Format = "N2"
                        End If
                    Else
                        ' Alignement à gauche pour les autres types (texte, date, bit, etc.)
                        colonne.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        ' Retirer le format numérique
                        colonne.DefaultCellStyle.Format = String.Empty
                        ' Format spécifique pour les dates
                        If "date;datetime;smalldatetime".Split(";"c).Contains(Typ_Retour.SelectedValue?.ToString()?.ToLower()) Then
                            colonne.DefaultCellStyle.Format = "dd/MM/yyyy"
                        End If
                    End If
                End If
            Next

            ' Rafraîchir l'affichage
            .Refresh()
        End With
    End Sub
    Private Sub Saving()
        Dim rs As New ADODB.Recordset
        Dim flg As Integer = (New Random()).Next(999, 56531)
        Dim Cod_Sql As String
        Dim swhere As String = ""
        If Cod_Abaque_txt.Text.Trim = "" Then
            ShowMessageBox("Code abaque vide.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If
        If rg.IsMatch(Cod_Abaque_txt.Text) Then
            ShowMessageBox("Code abaque contenant des caractères non authorisés.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If
        If Lib_Abaque_txt.Text.Trim = "" Then
            ShowMessageBox("Intitulé abaque contenant vide.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If
        If Typ_Retour.SelectedIndex = -1 Then
            ShowMessageBox("Type retour non renseigné.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If
        If Not Global_chk.Checked Then
            If CnExecuting("select count(*) from RH_Elements_Paie where  (lower(ltrim(rtrim(Cod_Function)))=lower(ltrim(rtrim('" & Cod_Abaque_txt.Text & "')))) and Typ_Function!='AB'  and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ") = " & Societe.id_Societe).Fields(0).Value > 0 Then
                Cod_Abaque_txt.Select()
                ShowMessageBox("Code déjà utilisé par une autre rubrique locale ou globale dans une autre société.")
            End If
        Else
            If CnExecuting("select count(*) from RH_Elements_Paie where (lower(ltrim(rtrim(Cod_Function)))=lower(ltrim(rtrim('" & Cod_Abaque_txt.Text & "')))) and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")!=" & Societe.id_Societe).Fields(0).Value > 0 Then
                Cod_Abaque_txt.Select()
                ShowMessageBox("Code déjà utilisé par une autre rubrique locale ou globale dans une autre société.")
            End If
        End If
        If Not fonction_rd.Checked Then
            If DefaultVal_txt.Text.Trim() <> "" Then
                If Typ_Retour.SelectedValue = "float" OrElse Typ_Retour.SelectedValue = "int" Then
                    If Not IsNumeric(DefaultVal_txt.Text) Then
                        ShowMessageBox("Type de la valeur par défaut non numérique.", "Contrôle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                End If
            End If
        End If
        With abaque_GRD
            For i = 0 To .RowCount - 2
                If Not ControleCaracteresSpeciaux(Clef_01.Index, i) Then Return
                If Not ControleCaracteresSpeciaux(Clef_02.Index, i) Then Return
                If Not ControleCaracteresSpeciaux(Clef_03.Index, i) Then Return
                If Not ControleCaracteresSpeciaux(Clef_04.Index, i) Then Return
                If Not ControleValeurs(Valeur_01.Index, i) Then Return
                If Not ControleValeurs(Valeur_02.Index, i) Then Return
                If Not ControleValeurs(Valeur_03.Index, i) Then Return
                If Not ControleValeurs(Valeur_04.Index, i) Then Return
                If Nb_Clefs.Value = 1 Then
                    For j = i + 1 To .RowCount - 2
                        If .Item(Clef_01.Index, i).Value = IsNull(.Item(Clef_01.Index, j).Value, "").Trim Then
                            ShowMessageBox("La clef :" & .Item(Clef_01.Index, i).Value & " est en double")
                            .Rows(i).Selected = True
                            .Rows(j).Selected = True
                            .FirstDisplayedCell = .Item(Clef_01.Index, i)
                            Return
                        End If
                    Next
                ElseIf Nb_Clefs.Value = 2 Then
                    For j = i + 1 To .RowCount - 2
                        If .Item(Clef_01.Index, i).Value = IsNull(.Item(Clef_01.Index, j).Value, "").Trim And .Item(Clef_02.Index, i).Value = IsNull(.Item(Clef_02.Index, j).Value, "").Trim Then
                            ShowMessageBox("La clef :" & .Item(Clef_01.Index, i).Value & " - " & .Item(Clef_02.Index, i).Value & ", est en double")
                            .Rows(i).Selected = True
                            .Rows(j).Selected = True
                            .FirstDisplayedCell = .Item(Clef_01.Index, i)
                            Return
                        End If
                    Next
                ElseIf Nb_Clefs.Value = 3 Then
                    For j = i + 1 To .RowCount - 2
                        If .Item(Clef_01.Index, i).Value = IsNull(.Item(Clef_01.Index, j).Value, "").Trim And .Item(Clef_02.Index, i).Value = IsNull(.Item(Clef_02.Index, j).Value, "").Trim And .Item(Clef_03.Index, i).Value = IsNull(.Item(Clef_03.Index, j).Value, "").Trim Then
                            ShowMessageBox("La clef :" & .Item(Clef_01.Index, i).Value & " - " & .Item(Clef_02.Index, i).Value & " - " & .Item(Clef_03.Index, i).Value & ", est en double")
                            .Rows(i).Selected = True
                            .Rows(j).Selected = True
                            .FirstDisplayedCell = .Item(Clef_01.Index, i)
                            Return
                        End If
                    Next
                ElseIf Nb_Clefs.Value = 4 Then
                    For j = i + 1 To .RowCount - 2
                        If .Item(Clef_01.Index, i).Value = IsNull(.Item(Clef_01.Index, j).Value, "").Trim And .Item(Clef_02.Index, i).Value = IsNull(.Item(Clef_02.Index, j).Value, "").Trim And .Item(Clef_03.Index, i).Value = IsNull(.Item(Clef_03.Index, j).Value, "").Trim And .Item(Clef_04.Index, i).Value = IsNull(.Item(Clef_04.Index, j).Value, "").Trim Then
                            ShowMessageBox("La clef :" & .Item(Clef_01.Index, i).Value & " - " & .Item(Clef_02.Index, i).Value & " - " & .Item(Clef_03.Index, i).Value & " - " & .Item(Clef_04.Index, i).Value & ", est en double")
                            .Rows(i).Selected = True
                            .Rows(j).Selected = True
                            .FirstDisplayedCell = .Item(Clef_01.Index, i)
                            Return
                        End If
                    Next
                End If
            Next
            'enregistrer l'entête
            Cod_Sql = "select * from RH_Param_Abaques where Cod_Abaque='" & Cod_Abaque_txt.Text & "' 
                          and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe
            rs.Open(Cod_Sql, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Cod_Abaque").Value = Cod_Abaque_txt.Text
                rs("Created_By").Value = theUser.Login
                rs("Dat_Crea").Value = Now
            Else
                rs.Update()
            End If
            rs("id_Societe").Value = If(Global_chk.Checked, -1, Societe.id_Societe)
            rs("Lib_Abaque").Value = Lib_Abaque_txt.Text
            rs("Typ_DefaultVal").Value = If(fonction_rd.Checked, "F", "C")
            If Not fonction_rd.Checked And Not "float;int".Split(";").Contains(Typ_Retour.SelectedValue) Then
                rs("DefaultVal").Value = """" & DefaultVal_txt.Text & """"
            Else
                rs("DefaultVal").Value = DefaultVal_txt.Text
            End If
            rs("Typ_Retour").Value = Typ_Retour.SelectedValue
            rs("Nb_Clefs").Value = Nb_Clefs.Value
            rs("Nb_Valeurs").Value = Nb_Valeurs.Value
            rs("Variable_Paie").Value = Variable_Paie_chk.Checked
            rs("Modified_By").Value = theUser.Login
            rs("Dat_Modif").Value = Now
            rs.Update()
            rs.Close()
            'enregistrer le détail
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Clef_01.Index, i).Value, "").Trim <> "" Then
                    Cod_Sql = "select * from RH_Param_Abaques_Detail where Cod_Abaque='" & Cod_Abaque_txt.Text & "' 
                        and isnull(Clef_01,'')='" & .Item(Clef_01.Index, i).Value & "'
                        and isnull(Clef_02,'')='" & .Item(Clef_02.Index, i).Value & "'
                        and isnull(Clef_03,'')='" & .Item(Clef_03.Index, i).Value & "'
                        and isnull(Clef_04,'')='" & .Item(Clef_04.Index, i).Value & "'
                        and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe
                    rs.Open(Cod_Sql, cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Cod_Abaque").Value = Cod_Abaque_txt.Text
                        rs("Created_By").Value = theUser.Login
                        rs("Dat_Crea").Value = Now
                    Else
                        rs.Update()
                    End If
                    rs("id_Societe").Value = If(Global_chk.Checked, -1, Societe.id_Societe)
                    rs("Clef_01").Value = .Item(Clef_01.Index, i).Value
                    rs("Clef_02").Value = If(Clef_02.Visible, .Item(Clef_02.Index, i).Value, "")
                    rs("Clef_03").Value = If(Clef_03.Visible, .Item(Clef_03.Index, i).Value, "")
                    rs("Clef_04").Value = If(Clef_04.Visible, .Item(Clef_04.Index, i).Value, "")
                    rs("Valeur_01").Value = If(Valeur_01.Visible, .Item(Valeur_01.Index, i).Value, Nothing)
                    rs("Valeur_02").Value = If(Valeur_02.Visible, .Item(Valeur_02.Index, i).Value, Nothing)
                    rs("Valeur_03").Value = If(Valeur_03.Visible, .Item(Valeur_03.Index, i).Value, Nothing)
                    rs("Valeur_04").Value = If(Valeur_04.Visible, .Item(Valeur_04.Index, i).Value, Nothing)
                    rs("Flag").Value = flg
                    rs("Rang").Value = i + 1
                    rs("Modified_By").Value = theUser.Login
                    rs("Dat_Modif").Value = Now
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With
        CnExecuting("delete from RH_Param_Abaques_Detail where Cod_Abaque='" & Cod_Abaque_txt.Text & "' and isnull(Flag,0)!='" & flg & "' and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
        MessageBoxRHP(352)
        Request()
    End Sub

    Private Sub SuppressionDesLignesSélectionnéesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MessageBoxRHP(594) = MsgBoxResult.Cancel Then Exit Sub
        With abaque_GRD
            For Each c In .SelectedRows
                If c.index < .RowCount - 1 Then
                    If .Item("Typ", c.index).Value = "S" Then
                        MessageBoxRHP(595)
                        c.selected = False
                    Else
                        CnExecuting("delete from Param_Rubriques where Nom_controle='" & Cod_Abaque_txt.Text & "' and valeur='" & .Item("Valeur", c.index).Value & "'")
                        abaque_GRD.Rows.Remove(c)
                    End If
                Else
                    c.selected = False
                End If
            Next
        End With


    End Sub
    Sub CollerLeContenu()
        Dim clipboardText = Clipboard.GetText().Trim
        Dim tblClipBoardTmp As New DataTable
        Dim nbClefs As Integer = Nb_Clefs.Value
        Dim nbValeurs As Integer = Nb_Valeurs.Value

        ' Construction dynamique de la structure de la table
        With tblClipBoardTmp
            ' Ajout des colonnes de clefs (toujours en String)
            For i As Integer = 1 To nbClefs
                .Columns.Add($"Clef_{i:00}", System.Type.GetType("System.String"))
            Next

            ' Ajout des colonnes de valeurs selon le type de retour SQL
            For i As Integer = 1 To nbValeurs
                Select Case Typ_Retour.SelectedValue.ToLower()
                    Case "int"
                        .Columns.Add($"Valeur_{i:00}", System.Type.GetType("System.Int32"))
                    Case "float"
                        .Columns.Add($"Valeur_{i:00}", System.Type.GetType("System.Double"))
                    Case Else ' nvarchar(max) ou autres
                        .Columns.Add($"Valeur_{i:00}", System.Type.GetType("System.String"))
                End Select
            Next
        End With

        If clipboardText <> "" Then
            ' Divisez le texte en lignes
            Dim lines As String() = clipboardText.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
            Dim patternFloat = "(?<=\d)[\s.,](?=\d{3}(?:[\s.,]|$))"

            ' Traitement de chaque ligne
            For Each line As String In lines
                ' Divisez chaque ligne en colonnes (tabulation)
                Dim columns As String() = line.Split(vbTab)

                ' Vérifier si on a assez de colonnes
                If columns.Length >= nbClefs + nbValeurs Then
                    Dim newRow As DataRow = tblClipBoardTmp.NewRow()
                    Dim validRow As Boolean = True

                    ' Remplir les clefs
                    For i As Integer = 0 To nbClefs - 1
                        If columns(i).Trim() = "" Then
                            validRow = False
                            Exit For
                        End If
                        newRow(i) = columns(i).Trim()
                    Next

                    ' Remplir les valeurs si la ligne est valide
                    If validRow Then
                        For i As Integer = 0 To nbValeurs - 1
                            Dim colIndex As Integer = nbClefs + i
                            Dim valeurBrute As String = columns(colIndex).Trim()

                            Try
                                Select Case Typ_Retour.SelectedValue.ToLower()
                                    Case "int"
                                        ' Conversion en entier
                                        Dim valeurNettoyee As String = Regex.Replace(valeurBrute, patternFloat, "")
                                        valeurNettoyee = valeurNettoyee.Replace(",", "").Replace(".", "")

                                        Dim valeurInt As Integer
                                        If Integer.TryParse(valeurNettoyee, valeurInt) Then
                                            newRow(nbClefs + i) = valeurInt
                                        Else
                                            validRow = False
                                            Exit For
                                        End If
                                    Case "float"
                                        ' Conversion en double/float
                                        Dim valeurNettoyee As String = Regex.Replace(valeurBrute, patternFloat, "")
                                        valeurNettoyee = valeurNettoyee.Replace(".", ",")

                                        Dim valeurFloat As Double
                                        If Double.TryParse(valeurNettoyee, Globalization.NumberStyles.Float,
                                                      Globalization.CultureInfo.InvariantCulture, valeurFloat) Then
                                            newRow(nbClefs + i) = valeurFloat
                                        Else
                                            validRow = False
                                            Exit For
                                        End If
                                    Case Else ' nvarchar(max) ou autres types texte
                                        newRow(nbClefs + i) = valeurBrute
                                End Select

                            Catch ex As Exception
                                ' En cas d'erreur de conversion, marquer la ligne comme invalide
                                validRow = False
                                Exit For
                            End Try
                        Next
                    End If

                    ' Ajouter la ligne si elle est valide
                    If validRow Then
                        tblClipBoardTmp.Rows.Add(newRow)
                    End If
                End If
            Next

            ' Vérification et messages
            If tblClipBoardTmp.Rows.Count = 0 Then
                ShowMessageBox("Le presse-papiers ne contient pas de données valides.",
                          "Coller le contenu", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If

            Dim nbLignesTotal As Integer = lines.Length
            Dim nbLignesImportees As Integer = tblClipBoardTmp.Rows.Count
            Dim nbLignesRejetees As Integer = nbLignesTotal - nbLignesImportees

            If nbLignesRejetees > 0 Then
                ShowMessageBox($"{nbLignesImportees} ligne{If(nbLignesImportees > 1, "s importée", " importée")}s. " &
                          $"{nbLignesRejetees} ligne{If(nbLignesRejetees > 1, "s rejetée", " rejetée")}s (données invalides ou type incompatible).",
                          "Coller le contenu", MessageBoxButtons.OK, msgIcon.Warning)
            Else
                With tblClipBoardTmp
                    For i = 0 To .Rows.Count - 1
                        abaque_GRD.Rows.Add()
                        Dim nbLig = abaque_GRD.Rows.Count - 2
                        For j = 0 To .Columns.Count - 1
                            abaque_GRD.Item(If(j >= nbClefs, j + 3, j), nbLig).Value = .Rows(i)(j)
                        Next
                    Next
                End With
                ShowMessageBox($"{nbLignesImportees} ligne{If(nbLignesImportees > 1, "s importée", " importée")}s avec succès.",
                          "Coller le contenu", MessageBoxButtons.OK, msgIcon.Information)
            End If

            ' TODO: Insérer tblClipBoardTmp dans votre abaque finale
            ' Exemple : InsererDansAbaque(tblClipBoardTmp)

        Else
            ShowMessageBox("Le presse-papiers ne contient pas de données.",
                      "Coller le contenu", MessageBoxButtons.OK, msgIcon.Error)
        End If
    End Sub
    Sub ChargementCombo()
        If Typ_Retour.Items.Count = 0 Then
            Typ_Retour.fromRubrique("Typ_Param", "Valeur not in ('smalldatetime','bit')")
        End If
    End Sub
    Private Sub Param_Rubriques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChargementCombo()
        Dim menu_context_copy As New ContextMenuStrip
        Dim oMenu1, oMenu2 As New ToolStripMenuItem
        With oMenu1
            .Name = "collerLeContenu"
            .Text = "Coller le contenu depuis le presse papier"
            .Image = My.Resources.coller_presspapier
            AddHandler .Click, AddressOf CollerLeContenu
        End With
        With oMenu2
            .Text = "Exporter le Contenu vers Excel"
            .Image = My.Resources.icone_excel
            AddHandler .Click, AddressOf ToExcel
        End With
        menu_context_copy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {oMenu1, oMenu2})
        With abaque_GRD
            .ContextMenuStrip = menu_context_copy
        End With
    End Sub

    Private Sub Adding()
        Reset_Form(Me)
        Cod_Abaque_txt.ReadOnly = False
        Cod_Abaque_txt.BackColor = Color.White
        Cod_Abaque_txt.Select()

    End Sub
    Sub Nouveau()
        Adding()
    End Sub

    Sub Enregistrer()
        Saving()
    End Sub
    Private Sub Nb_Clefs_ValueChanged(sender As Object, e As EventArgs) Handles Nb_Clefs.ValueChanged
        Dim nbClef = Nb_Clefs.Value
        Clef_01.Visible = nbClef >= 1
        Clef_02.Visible = nbClef >= 2
        Clef_03.Visible = nbClef >= 3
        Clef_04.Visible = nbClef >= 4
    End Sub
    Private Sub Nb_Valeurs_ValueChanged(sender As Object, e As EventArgs) Handles Nb_Valeurs.ValueChanged
        Dim nbVals = Nb_Valeurs.Value
        Valeur_01.Visible = nbVals >= 1
        Valeur_02.Visible = nbVals >= 2
        Valeur_03.Visible = nbVals >= 3
        Valeur_04.Visible = nbVals >= 4
    End Sub

    Private Sub abaque_GRD_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles abaque_GRD.EditingControlShowing
        With abaque_GRD
            If {Valeur_01.Index, Valeur_02.Index, Valeur_02.Index, Valeur_04.Index}.Contains(.CurrentCell.ColumnIndex) Then
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With abaque_GRD
            If {Valeur_01.Index, Valeur_02.Index, Valeur_02.Index, Valeur_04.Index}.Contains(.CurrentCell.ColumnIndex) Then
                If Typ_Retour.SelectedValue = "float" Then
                    ControleSaisie(.CurrentCell, e, True, False, False, False, False)
                ElseIf Typ_Retour.SelectedValue = "int" Then
                    ControleSaisie(.CurrentCell, e, True, True, False, False, False)
                End If
            End If
        End With
    End Sub

    Private Sub Typ_Retour_DropDownClosed(sender As Object, e As EventArgs) Handles Typ_Retour.DropDownClosed
        MiseEnformeGrd()
    End Sub
    Dim myVBS As New vsEngine
    Sub CallEditeurFunction(ZoneTxt As ud_TextBox, Optional ByVal LecteureSeule As Boolean = False)
        If Cod_Abaque_txt.Text = "" Then
            Cod_Abaque_txt.Select()
            Exit Sub
        End If
        If Not EstCaractèreConformeVBScript(Cod_Abaque_txt.Text) Then
            ShowMessageBox("Le code contient des caractères spéciaux ou des accents", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
            Cod_Abaque_txt.Select()
            Exit Sub
        End If
        If Lib_Abaque_txt.Text = "" Then
            ShowMessageBox("Intitulé vide", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
            Lib_Abaque_txt.Select()
            Exit Sub
        End If
        If Typ_Retour.SelectedIndex = -1 Then
            ShowMessageBox("Type de retour vide", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
            Typ_Retour.DroppedDown = True
            Exit Sub
        End If
        Dim f As New Zoom_RH_Editeur_Formule
        With f
            .Save_pb.Visible = Not LecteureSeule
            .myVBS = myVBS
            .CodRubrique = Cod_Abaque_txt.Text
            .TypRetour = Typ_Retour.SelectedValue
            .otxt = ZoneTxt
            .formulafunction = ZoneTxt.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub callFunction_btn_Click(sender As Object, e As EventArgs) Handles callFunction_btn.Click
        CallEditeurFunction(DefaultVal_txt)
    End Sub

    Private Sub fonction_rd_CheckedChanged(sender As Object, e As EventArgs) Handles fonction_rd.CheckedChanged
        callFunction_btn.Visible = fonction_rd.Checked
        DefaultVal_txt.Width = If(fonction_rd.Checked, 602, 163)
    End Sub
End Class