Imports System.Drawing.Printing
Public Class Evaluation
    Friend CodSurvey As String = ""
    Friend CodReponse As Integer = -1
    Dim Tbl_Question As New DataTable
    Dim afficherLesNotes As Boolean = False
    Dim btn_Signature As New mybtn_Signature(Me, "Signer_D", "", "btn_sign")
    Dim Paie_Calculee As Boolean = False
#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        '    If ShowMessageBox("Etes-vous sûr de vouloir soumettre en signature?", "Signature", MessageBoxButtons.OKCancel, msgIcon.Question) = MsgBoxResult.Cancel Then Return New savingResult With {.result = True, .message = ""}
        Return Saving("SS")
    End Function
    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function
    Sub miseAjourBtnValidationSignature(statut As String)
        Dim gereWrkf As Boolean = estGereEnSignature("EV")
        Dim controlToRemove As Control = ent_pnl.GetControlFromPosition(1, 0)

        If gereWrkf Then
            If TypeOf controlToRemove IsNot mybtn_Signature Then
                Dim Dv As DataView = Tbl_Workflow_ParamDocuments.DefaultView
                Dv.RowFilter = "Typ_Document='EV' and isnull(Gere_Signature,'false')='true'"
                Dim Dt = Dv.ToTable
                If Dt.Rows.Count = 0 Then Return
                With btn_Signature
                    .Image = My.Resources.Resources.btn_sign
                    .Name = "Signer_D"
                    .tbl = Dt
                    .frm = Me
                    .Statut = statut
                    .valeurIndex = CodReponse
                    .Visible = (estGereEnSignature("EV") And (.valeurIndex <> ""))
                    .ToolTip = "Signatures"
                    .Size = New Size(.Width * 1.2, .Height * 1.2)
                    AddHandler .Click, AddressOf SubSignatures
                End With
                If controlToRemove IsNot Nothing Then
                    ent_pnl.Controls.Remove(controlToRemove)
                    controlToRemove.Dispose() ' Libérer les ressources
                End If
                ent_pnl.Controls.Add(btn_Signature, 1, 0)
            Else
                With CType(controlToRemove, mybtn_Signature)
                    .Statut = statut
                    .valeurIndex = CodReponse
                    .Visible = (estGereEnSignature("EV") And (.valeurIndex <> ""))
                    .Size = New Size(.Width * 1.2, .Height * 1.2)
                End With
            End If
        Else
            Valide_pb.Enabled = statut = ""
            Valide_pb.Image = If(statut = "", My.Resources.btn_unlock, My.Resources.btn_lock_w)
            If TypeOf controlToRemove IsNot PictureBox Then
                If controlToRemove IsNot Nothing Then
                    ent_pnl.Controls.Remove(controlToRemove)
                    controlToRemove.Dispose() ' Libérer les ressources
                End If
                ent_pnl.Controls.Add(Valide_pb, 1, 0)
            End If
        End If

    End Sub

#End Region
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Survey_lbl.LinkClicked
        Appel_Calender(Dat_Survey_txt, Me)
    End Sub
    Private Sub pb_MinMax_Click(sender As Object, e As EventArgs) Handles pb_MinMax.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
    Private Sub Evaluation_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not EstDate(Dat_Survey_txt.Text) Then Dat_Survey_txt.Text = Now.ToShortDateString
    End Sub
    Sub Request()
        Dim statut As String = ""
        Save_pb.Enabled = True
        Paie_Calculee = False
        CodSurvey = FindLibelle("Cod_Survey", "Cod_Evaluation", Cod_Evaluation_txt.Text, "Evaluation")
        Lib_Survey_lbl.Text = CodSurvey & " : " & FindLibelle("Lib_Survey", "Cod_Survey", CodSurvey, "Survey").ToString.ToUpper
        CodReponse = CnExecuting("select isnull((select Top 1 Cod_Reply from Survey_Reply where Cod_Survey='" & CodSurvey & "' and Evaluateur='" & Evaluateur_txt.Text & "' and Evalue='" & Evalue_txt.Text & "' and id_Societe=" & Societe.id_Societe & "),-1)").Fields(0).Value
        Cod_Reply_txt.Text = If(CodReponse > 0, CodReponse, "")
        Preambule_rtb.Rtf = FindLibelle("Preambule", "Cod_Survey", CodSurvey, "Survey")
        Dat_Survey_txt.Text = FindLibelle("Dat_Survey", "Cod_Reply", CodReponse, "Survey_Reply")
        Preambule_rtb.Visible = (Preambule_rtb.Text.Trim <> "")
        If CodSurvey <> "" Then
            Tbl_Question = Generate_QuestionnaireNew(CodSurvey, pnl_Content, CodReponse, Evalue_txt.Text, Evaluateur_txt.Text, "E")
        Else
            pnl_Content.Controls.Clear()
        End If
        afficherLesNotes = Tbl_Question.Select("AvecNote='true'").Length > 0
        If CodReponse > -1 Then
            statut = Module_Generateur_Survey.Statut_Survey
            Paie_Calcule = Module_Generateur_Survey.Paie_Calcule
            Save_pb.Visible = (statut = "")
        End If
        miseAjourBtnValidationSignature(statut)
        Recalcul()
        pnl_note.Visible = afficherLesNotes
        With pnl_Content
            Dim fisrtCtr = If(.Controls.Count > 0, .Controls(.Controls.Count - 1), Nothing)
            If fisrtCtr IsNot Nothing Then pnl_Content.ScrollControlIntoView(fisrtCtr)
        End With

    End Sub
    Private Sub Cloture_pb_Click(sender As Object, e As EventArgs) Handles Valide_pb.Click
        Dim resp As savingResult = Saving("VA")
        If resp.result Then
            Request()
        End If
    End Sub

    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Dim resp As savingResult = Saving("")
        If resp.result Then
            Request()
        End If
    End Sub

    Private Sub Print_D_Click(sender As Object, e As EventArgs) Handles Print_pb.Click
        ImprimerEvaluation(Cod_Evaluation_txt.Text, Evaluateur_txt.Text, Evalue_txt.Text)
    End Sub
    Sub Recalcul()
        Dim dictQ As New Dictionary(Of ud_pattern, Dictionary(Of String, String))
        dictQ = pnl_Content.Tag
        Dim note As Double = 0
        Dim coef As Double = 0
        Dim note_totale As Double = 0
        For Each c In dictQ
            Dim noteDic = c.Key.noteDic
            If noteDic IsNot Nothing AndAlso noteDic.Count > 0 Then
                note += noteDic("note")
                coef += noteDic("coef")
            End If
        Next
        If coef = 0 Then coef = 1
        note_txt.Text = Math.Round(note, 2)
        coef_txt.Text = Math.Round(coef, 2)
        note_totale_txt.Text = Math.Round(CDbl(note / coef), 2)
    End Sub
    Function Saving(statut As String) As savingResult
        If Paie_Calculee Then Return New savingResult With {.result = False, .message = "Cette évaluation concerne une paie déjà calculée."}
        If Cod_Evaluation_txt.Text = "" Then Return New savingResult With {.result = False, .message = "Code évaluation vide."}
        If Evalue_txt.Text = "" Then Return New savingResult With {.result = False, .message = "Evalué vide."}
        If CodSurvey = "" Then Return New savingResult With {.result = False, .message = "Code évaluation vide."}
        If pnl_Content.Tag Is Nothing Then Return New savingResult With {.result = False, .message = "Formulaire ne contenant pas de questions."}
        Dim Flg_Maj As Integer = (New Random).Next(1562, 86459)
        Dim dictQ As New Dictionary(Of ud_pattern, Dictionary(Of String, String))
        dictQ = pnl_Content.Tag
        Dim Arr As New ArrayList
        Dim nrw() As DataRow = Nothing
        For Each c In dictQ
            c.Key.BackColor = Color.WhiteSmoke
            CType(c.Key, Object).Saving()
            Arr.Add(c)
        Next

        '1-Vérification des champs obligatoires non condionnés
        For i = Arr.Count - 1 To 0 Step -1
            nrw = Tbl_Question.Select($"Cod_Question={Arr(i).key.Name} and Obligatoire='true' and Obligatoire_Si=''")
            If nrw.Length > 0 Then
                If estVide(Arr(i).key) Then
                    estErreur(Arr(i).key)
                    Return New savingResult With {.result = False, .message = "Des champs obligatoires ne sont pas renseignés."}
                End If
            End If
        Next
        '2- Vérification des champs obligatoires inconditionnels
        Dim QuestionObligatoireNonRenseignee = survey_CheckObligatoire(Tbl_Question, dictQ)
        If QuestionObligatoireNonRenseignee IsNot Nothing Then
            estErreur(QuestionObligatoireNonRenseignee)
            Return New savingResult With {.result = False, .message = "Des champs obligatoires ne sont pas renseignés."}
        End If
        '3- Vérification Erreur Si
        Dim checkErr As Module_Generateur_Survey.erreurSi = survey_ErreurSi(Tbl_Question, dictQ)
        If checkErr.err <> "" Then
            estErreur(checkErr.ud)
            Return New savingResult With {.result = False, .message = checkErr.err}
        End If

        Recalcul()

        Dim rs As New ADODB.Recordset
        rs.Open("select * from Survey_Reply where Cod_Reply=" & CodReponse, cn, 1, 3)
        If rs.EOF Then
            rs.AddNew()
            rs("id_Societe").Value = Societe.id_Societe
            rs("Cod_Survey").Value = CodSurvey
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()

        End If
        rs("Evaluateur").Value = Evaluateur_txt.Text
        rs("Typ_Evalue").Value = "E"
        rs("Evalue").Value = Evalue_txt.Text
        rs("Ref_Evaluation").Value = Cod_Evaluation_txt.Text
        rs("Statut").Value = statut
        rs("Note").Value = If(IsNumeric(note_txt.Text), CDbl(note_txt.Text), 0)
        rs("Coef").Value = If(IsNumeric(coef_txt.Text), CDbl(coef_txt.Text), 1)
        rs("Note_Totale").Value = If(IsNumeric(note_totale_txt.Text), CDbl(note_totale_txt.Text), 0)
        rs("Dat_Survey").Value = If(EstDate(Dat_Survey_txt.Text), Dat_Survey_txt.Text, Now.ToShortDateString)
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = theUser.Login
        rs("Flg_Maj").Value = Flg_Maj
        rs.Update()
        If CodReponse <= 0 Then CodReponse = rs("Cod_Reply").Value
        rs.Close()
        Dim nb As Integer = 0
        Dim Reponse As String = ""
        Dim rsp() As String = Nothing
        CnExecuting($"delete from Survey_Reply_Detail where Cod_Reply={CodReponse} and isnull(Flg_Maj,0)!={Flg_Maj}")
        For Each c In dictQ
            nrw = Tbl_Question.Select("Cod_Question=" & c.Key.Name)
            If nrw.Length > 0 Then
                For Each v In c.Value
                    rs.Open($"select * from Survey_Reply_Detail where Cod_Reply={CodReponse}", cn, 2, 2)
                    rs.AddNew()
                    rs("Cod_Reply").Value = CodReponse
                    rs("Cod_Question").Value = c.Key.Name
                    rs("Question").Value = nrw(0)("Question")
                    rs("Obligatoire").Value = c.Key.Obligatoire
                    rs("Typ_Reponse").Value = c.Key.Typ_Reponse
                    rs("Num_Sous_Question").Value = v.Key
                    rs("Reponses").Value = v.Value
                    If nrw(0)("Sous_Question").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Length > 0 And IsNumeric(v.Key) Then
                        Dim sq As String = nrw(0)("Sous_Question").ToString
                        rs("Sous_Question").Value = sq.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(v.Key)
                        Reponse = ""
                        Select Case nrw(0)("Typ_Reponse")
                            Case "grille_cases", "cocher", "oui_non", "vrai_faux", "echelle", "grille_choix", "choix"
                                rsp = v.Key.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                                For n = 0 To rsp.Length - 1
                                    If rsp(n).Trim = "1" Then
                                        Reponse &= IIf(Reponse = "", "", ";") & nrw(0)("Reponses_Possibles").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(n)
                                    End If
                                Next
                            Case Else
                                Reponse = v.Value
                        End Select
                        rs("Valeur_Reponse").Value = Reponse
                    End If
                    Dim noteDic = c.Key.noteDic
                    If noteDic IsNot Nothing AndAlso noteDic.Count > 0 Then
                        rs("Note").Value = noteDic("note")
                        rs("Coef").Value = noteDic("coef")
                        rs("Note_Totale").Value = noteDic("note_totale")
                    End If
                    rs("Rang").Value = nb
                    rs("Flg_Maj").Value = Flg_Maj
                    nb += 1
                    rs.Update()
                    rs.Close()
                Next
            End If
        Next
        Return New savingResult With {.result = True, .message = "Evaluation enregistrée avec succès."}
    End Function
    Sub estErreur(ud As ud_pattern)
        ud.Select()
        pnl_Content.ScrollControlIntoView(ud)
        ud.BackColor = Color.Red
    End Sub
#Region "Impression"
    Private WithEvents oReport As New PrintDocument
    Private obj As New ArrayList
    Private H_pos As Integer
    Private NumPage As Integer = 1
    Private oFontStr As String = "Segoe UI"  ' Police moderne

    ' Couleurs améliorées pour un design moderne
    Private ReadOnly HeaderBackgroundColor As Color = Color.FromArgb(41, 128, 185)  ' Bleu moderne
    Private ReadOnly HeaderTextColor As Color = Color.White
    Private ReadOnly SectionHeaderColor As Color = Color.FromArgb(236, 240, 241)  ' Gris très clair
    Private ReadOnly BorderColor As Color = Color.FromArgb(189, 195, 199)  ' Bordure subtile
    Private ReadOnly AlternateRowColor As Color = Color.FromArgb(250, 251, 252)  ' Alternance très légère
    Private ReadOnly QuestionBackgroundColor As Color = Color.FromArgb(245, 248, 250)  ' Fond question

    ' Marges et dimensions
    Private ReadOnly MarginLeft As Integer = 40
    Private ReadOnly MarginRight As Integer = 40
    Private ReadOnly MarginTop As Integer = 50
    Private ReadOnly MarginBottom As Integer = 50
    Private HeaderHeight As Integer = 105
    Private ReadOnly FooterHeight As Integer = 40
    Private ReadOnly SectionSpacing As Integer = 20  ' Espacement entre sections

    Private MaxW As Integer
    Private MaxH As Integer
    Private ContentWidth As Integer  ' Largeur disponible pour le contenu

    Sub ImprimerEvaluation(Cod_Evaluation As String, Evaluateur As String, Evalue As String)
        Try
            obj.Clear()
            NumPage = 1

            ' Configuration de l'impression
            With oReport
                .DocumentName = "Évaluation - " & Lib_Survey_lbl.Text
                RemoveHandler .PrintPage, AddressOf oReport_PrintPage
                AddHandler .PrintPage, AddressOf oReport_PrintPage

                ' Configuration page A4 Portrait
                .DefaultPageSettings.Landscape = False
                .DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
                .DefaultPageSettings.Margins = New Margins(MarginLeft, MarginRight, MarginTop, MarginBottom)
            End With

            ' Prévisualisation
            Using preview As New PrintPreviewDialog()
                preview.Document = oReport
                preview.WindowState = FormWindowState.Maximized
                preview.ShowDialog()
            End Using

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'impression : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub oReport_PrintPage(sender As Object, e As PrintPageEventArgs) Handles oReport.PrintPage
        MaxW = e.PageBounds.Width
        MaxH = e.PageBounds.Height
        ContentWidth = MaxW - MarginLeft - MarginRight

        Dim obr As New SolidBrush(Color.Black)
        Dim _frm As New StringFormat()
        Dim Ht As Integer = MarginTop

        ' Rendu de l'en-tête uniquement sur la première page
        If NumPage = 1 Then
            RenderHeader(e, obr, _frm)
            Ht = MarginTop + HeaderHeight + SectionSpacing
        Else
            Ht = MarginTop
        End If

        ' Collecte des contrôles à imprimer si première fois
        If obj.Count = 0 Then
            For Each ctrl As Control In pnl_Content.Controls.Cast(Of Control)().Reverse()
                If TypeOf ctrl Is ud_pattern Then
                    obj.Add(ctrl)   ' on n’exclut plus les questions vides
                End If
            Next
        End If

        ' Rendu des contrôles
        Dim startIndex As Integer = H_pos
        Dim hasMorePages As Boolean = False

        For i As Integer = startIndex To obj.Count - 1
            Dim ctrl As Control = CType(obj(i), Control)
            Dim rendered As Boolean = False

            ' Vérifier l'espace disponible avant de rendre
            Dim estimatedHeight As Integer = EstimateControlHeight(ctrl)
            If Ht + estimatedHeight > MaxH - FooterHeight - MarginBottom Then
                hasMorePages = True
                H_pos = i
                Exit For
            End If

            ' Rendre selon le type de contrôle
            Select Case True
                Case TypeOf ctrl Is ud_grille_libre
                    rendered = RenderGridLibreImproved(e, ctrl, Ht, obr, _frm)
                Case TypeOf ctrl Is ud_grille_choix
                    rendered = RenderGridChoixImproved(e, ctrl, Ht, obr, _frm)
                Case TypeOf ctrl Is ud_grille_cases
                    rendered = RenderGridCasesImproved(e, ctrl, Ht, obr, _frm)
                Case TypeOf ctrl Is ud_valeur_unique
                    rendered = RenderValeurUniqueImproved(e, ctrl, Ht, obr, _frm)
                Case TypeOf ctrl Is ud_paragraph
                    rendered = RenderParagraphImproved(e, ctrl, Ht, obr, _frm)
            End Select

            If Not rendered Then
                hasMorePages = True
                H_pos = i
                Exit For
            End If

            H_pos = i + 1
        Next

        ' Rendu du pied de page
        RenderFooterImproved(e, obr, _frm)

        ' Configuration pour pages suivantes
        e.HasMorePages = hasMorePages
        If hasMorePages Then
            NumPage += 1
        Else
            ' Réinitialisation pour une prochaine impression
            obj.Clear()
            H_pos = 0
            NumPage = 1
        End If
    End Sub

    ' Fonction pour vérifier si un contrôle est vide
    Private Function IsControlEmpty(ctrl As Control) As Boolean
        If TypeOf ctrl Is ud_grille_libre Then
            Dim grid As ud_grille_libre = CType(ctrl, ud_grille_libre)
            ' Vérifier si toutes les cellules sont vides
            For r As Integer = 0 To grid.Grd.RowCount - 1
                For c As Integer = 0 To grid.Grd.ColumnCount - 1
                    If grid.Grd.Item(c, r).Value IsNot Nothing AndAlso
                       grid.Grd.Item(c, r).Value.ToString().Trim() <> "" Then
                        Return False
                    End If
                Next
            Next
            Return True
        ElseIf TypeOf ctrl Is ud_valeur_unique Then
            Dim valeur As ud_valeur_unique = CType(ctrl, ud_valeur_unique)
            Return valeur.repDic Is Nothing OrElse
                   Not valeur.repDic.ContainsKey("0") OrElse
                   valeur.repDic("0").Trim() = ""
        ElseIf TypeOf ctrl Is ud_paragraph Then
            Dim para As ud_paragraph = CType(ctrl, ud_paragraph)
            Return para.repDic Is Nothing OrElse
                   Not para.repDic.ContainsKey("0") OrElse
                   para.repDic("0").Trim() = ""
        End If
        Return False
    End Function

    ' Estimer la hauteur d'un contrôle
    Private Function EstimateControlHeight(ctrl As Control) As Integer
        If TypeOf ctrl Is ud_grille_libre Then
            Dim grid As ud_grille_libre = CType(ctrl, ud_grille_libre)
            Return 35 + (grid.Grd.RowCount + 1) * 25 + SectionSpacing
        ElseIf TypeOf ctrl Is ud_grille_choix Then
            Dim grid As ud_grille_choix = CType(ctrl, ud_grille_choix)
            Return 35 + (grid.Grd.RowCount + 1) * 25 + SectionSpacing
        ElseIf TypeOf ctrl Is ud_grille_cases Then
            Dim grid As ud_grille_cases = CType(ctrl, ud_grille_cases)
            Return 35 + (grid.Grd.RowCount + 1) * 25 + SectionSpacing
        ElseIf TypeOf ctrl Is ud_valeur_unique Then
            Return 70 + SectionSpacing
        ElseIf TypeOf ctrl Is ud_paragraph Then
            Return 120 + SectionSpacing
        End If
        Return 100
    End Function

    ' Rendu de l'en-tête amélioré
    Private Sub RenderHeader(e As PrintPageEventArgs, obr As SolidBrush, _frm As StringFormat)

        ' Bandeau de titre
        Dim headerRect As New Rectangle(0, 0, MaxW, 60)
        Using gradientBrush As New Drawing2D.LinearGradientBrush(
        headerRect,
        HeaderBackgroundColor,
        Color.FromArgb(52, 152, 219),
        Drawing2D.LinearGradientMode.Horizontal
    )
            e.Graphics.FillRectangle(gradientBrush, headerRect)
        End Using

        ' Titre principal (libellé du questionnaire)
        _frm.Alignment = StringAlignment.Center
        _frm.LineAlignment = StringAlignment.Center
        Using titleFont As New Font(oFontStr, 14, FontStyle.Bold)
            e.Graphics.DrawString(Lib_Survey_lbl.Text.ToUpper() & vbCrLf & Dat_Survey_txt.Text, titleFont,
                              New SolidBrush(HeaderTextColor),
                              New Rectangle(0, 0, MaxW, 60), _frm)
        End Using

        ' === Bloc 3 lignes : Evaluateur / Evalué / Evaluation ===
        Dim headerFont As New Font(oFontStr, 9, FontStyle.Bold)
        Dim textFont As New Font(oFontStr, 8)
        Dim boxPen As New Pen(BorderColor, 0.5F)

        Dim startY As Integer = 70
        Dim boxHeight As Integer = 22
        Dim labelWidth As Integer = 90
        Dim codeWidth As Integer = 80
        Dim nameWidth As Integer = ContentWidth - labelWidth - codeWidth

        ' Ligne 1 : L'évaluateur
        e.Graphics.DrawString("L'évaluateur", headerFont, obr, MarginLeft, startY + 4)
        e.Graphics.DrawRectangle(boxPen,
                             MarginLeft + labelWidth,
                             startY,
                             codeWidth,
                             boxHeight)
        e.Graphics.DrawString(Evaluateur_txt.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + 3, startY + 2,
                                        codeWidth - 6, boxHeight - 4))
        e.Graphics.DrawRectangle(boxPen,
                             MarginLeft + labelWidth + codeWidth,
                             startY,
                             nameWidth,
                             boxHeight)
        e.Graphics.DrawString(Nom_Evaluateur_txt.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + codeWidth + 3, startY + 2,
                                        nameWidth - 6, boxHeight - 4))

        startY += boxHeight + 4

        ' Ligne 2 : Évalué
        e.Graphics.DrawString("Évalué", headerFont, obr, MarginLeft, startY + 4)
        e.Graphics.DrawRectangle(boxPen,
                             MarginLeft + labelWidth,
                             startY,
                             codeWidth,
                             boxHeight)
        e.Graphics.DrawString(Evalue_txt.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + 3, startY + 2,
                                        codeWidth - 6, boxHeight - 4))
        e.Graphics.DrawRectangle(boxPen,
                             MarginLeft + labelWidth + codeWidth,
                             startY,
                             nameWidth,
                             boxHeight)
        e.Graphics.DrawString(Nom_Evalue_txt.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + codeWidth + 3, startY + 2,
                                        nameWidth - 6, boxHeight - 4))

        startY += boxHeight + 4

        ' Ligne 3 : Évaluation
        e.Graphics.DrawString("Évaluation", headerFont, obr, MarginLeft, startY + 4)
        e.Graphics.DrawRectangle(boxPen,
                             MarginLeft + labelWidth,
                             startY,
                             codeWidth,
                             boxHeight)
        e.Graphics.DrawString(Cod_Evaluation_txt.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + 3, startY + 2,
                                        codeWidth - 6, boxHeight - 4))
        e.Graphics.DrawRectangle(boxPen,
                             MarginLeft + labelWidth + codeWidth,
                             startY,
                             nameWidth,
                             boxHeight)
        e.Graphics.DrawString(Lib_Survey_lbl.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + codeWidth + 3, startY + 2,
                                        nameWidth - 6, boxHeight - 4))
        If afficherLesNotes Then
            startY += boxHeight + 4
            ' Affichage des notes en ligne

            Dim accentPen As New SolidBrush(Color.White)
            ' Rectangle pour la ligne de notes
            Dim noteLineRect As New Rectangle(MarginLeft, startY, ContentWidth, boxHeight + 12)

            Dim noteTotal As Double = If(IsNumeric(note_txt.Text), CDbl(note_txt.Text), 0)
            Dim coef As Double = If(IsNumeric(coef_txt.Text), CDbl(coef_txt.Text), 0)
            Dim noteFinale As Double = If(IsNumeric(note_totale_txt.Text), CDbl(note_totale_txt.Text), 0)
            e.Graphics.FillRectangle(New SolidBrush(HeaderBackgroundColor), noteLineRect)
            startY += 6
            Dim noteStr = $"Note totale: {Math.Round(noteTotal, 2)}      Coefficient: {Math.Round(coef, 2)}      Note finale: {Math.Round(noteFinale, 2)}"
            Using lblFont As New Font(oFontStr, 12, FontStyle.Bold)
                Dim textSize As SizeF = e.Graphics.MeasureString(noteStr, lblFont)
                Dim startX As Integer = MarginLeft + (oReport.DefaultPageSettings.PaperSize.Width - textSize.Width) / 2
                e.Graphics.DrawString(noteStr, lblFont, accentPen, startX, startY)
            End Using
            HeaderHeight += SectionSpacing
        End If


    End Sub

    ' Dessiner une boîte d'information
    Private Sub DrawInfoBox(e As PrintPageEventArgs, label As String, value As String,
                           x As Integer, y As Integer, width As Integer,
                           obr As SolidBrush, _frm As StringFormat)
        ' Fond
        e.Graphics.FillRectangle(New SolidBrush(Color.White),
                                New Rectangle(x, y, width, 25))

        ' Bordure
        Using borderPen As New Pen(BorderColor, 1)
            e.Graphics.DrawRectangle(borderPen, New Rectangle(x, y, width, 25))
        End Using

        ' Label
        Using labelFont As New Font(oFontStr, 7, FontStyle.Regular)
            e.Graphics.DrawString(label, labelFont,
                                New SolidBrush(Color.Gray),
                                New Point(x + 5, y - 15))
        End Using

        ' Valeur
        _frm.Alignment = StringAlignment.Near
        _frm.LineAlignment = StringAlignment.Center
        Using valueFont As New Font(oFontStr, 8, FontStyle.Bold)
            e.Graphics.DrawString(value, valueFont, obr,
                                New Rectangle(x + 5, y, width - 10, 25), _frm)
        End Using
    End Sub

    ' Fonction améliorée pour rendre une grille libre
    ' Fonction améliorée pour rendre une grille (libre / choix / cases)
    Private Function RenderGridLibreImproved(e As PrintPageEventArgs, ctrl As Object,
                                        ByRef Ht As Integer, obr As SolidBrush,
                                        _frm As StringFormat) As Boolean
        If TypeOf ctrl IsNot ud_grille_libre AndAlso
       TypeOf ctrl IsNot ud_grille_cases AndAlso
       TypeOf ctrl IsNot ud_grille_choix Then Return False

        Dim grid = ctrl

        ' Récupérer les notes si disponibles
        Dim note As Double? = Nothing
        Dim coef As Double? = Nothing
        Dim noteTotale As Double? = Nothing

        If afficherLesNotes AndAlso grid.avecNote AndAlso grid.noteDic IsNot Nothing AndAlso grid.noteDic.Count > 0 Then
            note = CDbl(grid.noteDic("note"))
            coef = CDbl(grid.noteDic("coef"))
            noteTotale = CDbl(grid.noteDic("note_totale"))
        End If

        ' Rendu de la question
        RenderQuestionHeader(e, grid.numQuestion, grid.laquestion, Ht, obr, _frm)
        Ht += 35

        ' Colonnes non vides (on garde toujours la première pour les libellés)
        Dim nonEmptyColumns As New List(Of Integer)
        For c As Integer = 0 To grid.Grd.ColumnCount - 1
            Dim hasData As Boolean = False
            For r As Integer = 0 To grid.Grd.RowCount - 1
                If grid.Grd.Item(c, r).Value IsNot Nothing AndAlso
               grid.Grd.Item(c, r).Value.ToString().Trim() <> "" Then
                    hasData = True
                    Exit For
                End If
            Next
            If hasData OrElse c = 0 Then
                nonEmptyColumns.Add(c)
            End If
        Next

        If nonEmptyColumns.Count = 0 Then
            Ht += SectionSpacing
            Return True
        End If

        ' Largeurs dans la zone imprimable (marges respectées)
        Dim totalWidth As Integer = ContentWidth
        Dim colWidths As New Dictionary(Of Integer, Integer)
        Dim firstColIndex As Integer = nonEmptyColumns(0)   ' colonne de la question

        If nonEmptyColumns.Count = 1 Then
            colWidths(firstColIndex) = totalWidth
        Else
            ' ~40% pour la colonne question, le reste réparti sur les autres
            Dim firstColWidth As Integer = CInt(totalWidth * 0.4)
            Dim remainingWidth As Integer = totalWidth - firstColWidth
            Dim otherCount As Integer = nonEmptyColumns.Count - 1
            Dim baseOtherWidth As Integer = remainingWidth \ otherCount
            Dim extra As Integer = remainingWidth - baseOtherWidth * otherCount

            colWidths(firstColIndex) = firstColWidth
            For Each colIndex In nonEmptyColumns
                If colIndex = firstColIndex Then Continue For
                Dim w As Integer = baseOtherWidth
                If extra > 0 Then
                    w += 1
                    extra -= 1
                End If
                colWidths(colIndex) = w
            Next
        End If

        ' Rendu des en-têtes
        Dim currentX As Integer = MarginLeft
        Using headerFont As New Font(oFontStr, 7, FontStyle.Bold)
            For Each colIndex In nonEmptyColumns
                Dim colWidth As Integer = colWidths(colIndex)

                ' On NE colore PAS l'entête de la colonne de question
                If colIndex <> firstColIndex Then
                    e.Graphics.FillRectangle(New SolidBrush(SectionHeaderColor),
                                         New Rectangle(currentX, Ht, colWidth, 25))
                End If

                Using borderPen As New Pen(BorderColor, 0.5F)
                    e.Graphics.DrawRectangle(borderPen,
                                         New Rectangle(currentX, Ht, colWidth, 25))
                End Using

                _frm.Alignment = If(colIndex = firstColIndex,
                                StringAlignment.Near,
                                StringAlignment.Center)
                _frm.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(grid.Grd.Columns(colIndex).HeaderText,
                                  headerFont, obr,
                                  New Rectangle(currentX + 3, Ht, colWidth - 6, 25), _frm)

                currentX += colWidth
            Next
        End Using

        Ht += 25

        ' Rendu des lignes de données
        Using dataFont As New Font(oFontStr, 7)
            For r As Integer = 0 To grid.Grd.RowCount - 1
                currentX = MarginLeft

                ' alternance de lignes
                If r Mod 2 = 1 Then
                    e.Graphics.FillRectangle(New SolidBrush(AlternateRowColor),
                                         New Rectangle(MarginLeft, Ht, ContentWidth, 22))
                End If

                For Each colIndex In nonEmptyColumns
                    Dim colWidth As Integer = colWidths(colIndex)
                    Dim cellValue = grid.Grd.Item(colIndex, r).Value

                    Using borderPen As New Pen(BorderColor, 0.5F)
                        e.Graphics.DrawRectangle(borderPen,
                                             New Rectangle(currentX, Ht, colWidth, 22))
                    End Using

                    RenderCellContent(e, grid.Grd.Columns(colIndex), cellValue,
                                  grid.Grd.Item(colIndex, r).Tag,
                                  currentX, Ht, colWidth, 22,
                                  obr, dataFont, _frm)

                    currentX += colWidth
                Next

                Ht += 22
            Next
        End Using

        ' Afficher la ligne de notes en dessous si disponible
        If afficherLesNotes AndAlso grid.avecNote AndAlso note.HasValue Then
            RenderNoteLine(e, Ht, note, coef, noteTotale, obr)
        End If

        Ht += SectionSpacing
        Return True
    End Function


    ' Vérifier si une colonne contient des données
    Private Function ColumnHasData(grid As Object, colIndex As Integer) As Boolean
        For r As Integer = 0 To grid.Grd.RowCount - 1
            If grid.Grd.Item(colIndex, r).Value IsNot Nothing AndAlso
               grid.Grd.Item(colIndex, r).Value.ToString().Trim() <> "" Then
                Return True
            End If
        Next
        Return False
    End Function

    ' Rendu du contenu d'une cellule
    Private Sub RenderCellContent(e As PrintPageEventArgs, column As DataGridViewColumn,
                                 value As Object, tag As Object,
                                 x As Integer, y As Integer, w As Integer, h As Integer,
                                 obr As SolidBrush, font As Font, _frm As StringFormat)
        Dim contentX As Integer = x + 3
        Dim contentY As Integer = y + 3
        Dim contentW As Integer = w - 6
        Dim contentH As Integer = h - 6

        Select Case True
            Case TypeOf column Is DataGridViewImageColumn
                Dim isSelected As Boolean = GetBooleanValue(tag, False)
                Dim img As Image = If(isSelected, My.Resources.RadioButtonSel, My.Resources.RadioButtonUnsel)
                e.Graphics.DrawImage(img, New Rectangle(contentX + contentW \ 2 - 8,
                                                       contentY + contentH \ 2 - 8, 16, 16))

            Case TypeOf column Is DataGridViewCheckBoxColumn
                Dim isChecked As Boolean = GetBooleanValue(value, False)
                Dim img As Image = If(isChecked, My.Resources.check_1, My.Resources.check_0)
                e.Graphics.DrawImage(img, New Rectangle(contentX + contentW \ 2 - 8,
                                                       contentY + contentH \ 2 - 8, 16, 16))

            Case Else
                If value IsNot Nothing Then
                    _frm.Alignment = StringAlignment.Near
                    _frm.LineAlignment = StringAlignment.Center
                    e.Graphics.DrawString(value.ToString(), font, obr,
                                        New Rectangle(contentX, y, contentW, h), _frm)
                End If
        End Select
    End Sub

    ' 1 Rendu de l'en-tête de question
    Private Sub RenderQuestionHeader(e As PrintPageEventArgs, numQuestion As String,
                                    questionText As String, y As Integer,
                                    obr As SolidBrush, _frm As StringFormat)
        ' Fond de la question
        Dim questionRect As New Rectangle(MarginLeft, y, ContentWidth, 30)
        e.Graphics.FillRectangle(New SolidBrush(QuestionBackgroundColor), questionRect)

        ' Bordure gauche colorée pour marquer la question
        Using accentPen As New Pen(HeaderBackgroundColor, 3)
            e.Graphics.DrawLine(accentPen, MarginLeft, y, MarginLeft, y + 30)
        End Using

        ' Bordure complète
        Using borderPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawRectangle(borderPen, questionRect)
        End Using

        ' Texte de la question
        _frm.Alignment = StringAlignment.Near
        _frm.LineAlignment = StringAlignment.Center
        Using questionFont As New Font(oFontStr, 8, FontStyle.Bold)
            e.Graphics.DrawString(numQuestion & ". " & questionText, questionFont, obr,
                                New Rectangle(MarginLeft + 10, y, ContentWidth - 20, 30), _frm)
        End Using
    End Sub

    ' Fonction helper pour obtenir une valeur booléenne
    Private Function GetBooleanValue(value As Object, defaultValue As Boolean) As Boolean
        If value Is Nothing Then Return defaultValue
        If TypeOf value Is Boolean Then Return CBool(value)
        If TypeOf value Is String Then
            Dim strValue As String = value.ToString().ToLower()
            Return strValue = "true" OrElse strValue = "1" OrElse strValue = "oui" OrElse strValue = "yes"
        End If
        Return defaultValue
    End Function

    ' Rendu du pied de page amélioré
    Private Sub RenderFooterImproved(e As PrintPageEventArgs, obr As SolidBrush, _frm As StringFormat)
        Dim footerY As Integer = MaxH - FooterHeight

        ' Ligne de séparation
        Using separatorPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawLine(separatorPen, MarginLeft, footerY,
                              MaxW - MarginRight, footerY)
        End Using

        ' Contenu du pied de page
        Using footerFont As New Font(oFontStr, 7)
            ' Numéro de page au centre
            _frm.Alignment = StringAlignment.Center
            _frm.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString("Page " & NumPage, footerFont,
                                New SolidBrush(Color.Gray),
                                New Rectangle(MarginLeft, footerY + 5,
                                            ContentWidth, 20), _frm)

            ' Date et heure à droite
            _frm.Alignment = StringAlignment.Far
            e.Graphics.DrawString("Imprimé le " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                                footerFont, New SolidBrush(Color.Gray),
                                New Rectangle(MarginLeft, footerY + 5,
                                            ContentWidth, 20), _frm)
        End Using
    End Sub

    ' Méthodes similaires pour les autres types de contrôles
    Private Function RenderGridChoixImproved(e As PrintPageEventArgs, ctrl As Control,
                                            ByRef Ht As Integer, obr As SolidBrush,
                                            _frm As StringFormat) As Boolean
        ' Implémentation similaire à RenderGridLibreImproved
        ' avec adaptation pour ud_grille_choix
        Return RenderGridLibreImproved(e, ctrl, Ht, obr, _frm)
    End Function

    Private Function RenderGridCasesImproved(e As PrintPageEventArgs, ctrl As Control,
                                            ByRef Ht As Integer, obr As SolidBrush,
                                            _frm As StringFormat) As Boolean
        ' Implémentation similaire à RenderGridLibreImproved
        ' avec adaptation pour ud_grille_cases
        Return RenderGridLibreImproved(e, ctrl, Ht, obr, _frm)
    End Function

    Private Function RenderValeurUniqueImproved(e As PrintPageEventArgs, ctrl As Control,
                                           ByRef Ht As Integer, obr As SolidBrush,
                                           _frm As StringFormat) As Boolean
        Dim valeur As ud_valeur_unique = CType(ctrl, ud_valeur_unique)

        ' On affiche la question même sans réponse
        Dim txt As String = ""
        If valeur.repDic IsNot Nothing AndAlso valeur.repDic.ContainsKey("0") Then
            txt = valeur.repDic("0").Trim()
        End If

        ' Récupérer les notes si disponibles
        Dim note As Double? = Nothing
        Dim coef As Double? = Nothing
        Dim noteTotale As Double? = Nothing

        If afficherLesNotes AndAlso valeur.avecNote AndAlso valeur.noteDic IsNot Nothing AndAlso valeur.noteDic.Count > 0 Then
            note = CDbl(valeur.noteDic("note"))
            coef = CDbl(valeur.noteDic("coef"))
            noteTotale = CDbl(valeur.noteDic("note_totale"))
        End If

        ' 1) Rendu de la question (bandeau plein)
        RenderQuestionHeader(e, valeur.numQuestion, valeur.laquestion, Ht, obr, _frm)

        ' 2) Zone de réponse à droite sur la même ligne
        Const ValueBoxWidth As Integer = 200
        Const headerHeight As Integer = 30
        Dim totalRight As Integer = MarginLeft + ContentWidth
        Dim valueX As Integer = totalRight - ValueBoxWidth
        Dim valueRect As New Rectangle(valueX, Ht, ValueBoxWidth, headerHeight)

        ' Fond et bordure de la zone réponse
        e.Graphics.FillRectangle(New SolidBrush(Color.White), valueRect)
        Using borderPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawRectangle(borderPen, valueRect)
        End Using

        ' Texte de la réponse (peut être vide)
        _frm.Alignment = StringAlignment.Center
        _frm.LineAlignment = StringAlignment.Center
        Using valueFont As New Font(oFontStr, 8, FontStyle.Bold)
            e.Graphics.DrawString(txt, valueFont, obr, valueRect, _frm)
        End Using

        Ht += headerHeight

        ' 3) Afficher la ligne de notes en dessous si disponible
        If afficherLesNotes AndAlso valeur.avecNote AndAlso note.HasValue Then
            RenderNoteLine(e, Ht, note, coef, noteTotale, obr)
        End If

        Ht += SectionSpacing
        Return True
    End Function

    Private Function RenderParagraphImproved(e As PrintPageEventArgs, ctrl As Control,
                                         ByRef Ht As Integer, obr As SolidBrush,
                                         _frm As StringFormat) As Boolean
        Dim para As ud_paragraph = CType(ctrl, ud_paragraph)

        ' On affiche le paragraphe même sans texte
        Dim txt As String = ""
        If para.repDic IsNot Nothing AndAlso para.repDic.ContainsKey("0") Then
            txt = para.repDic("0").Trim()
        End If

        ' Récupérer les notes si disponibles
        Dim note As Double? = Nothing
        Dim coef As Double? = Nothing
        Dim noteTotale As Double? = Nothing

        If afficherLesNotes AndAlso para.avecNote AndAlso para.noteDic IsNot Nothing AndAlso para.noteDic.Count > 0 Then
            note = CDbl(para.noteDic("note"))
            coef = CDbl(para.noteDic("coef"))
            noteTotale = CDbl(para.noteDic("note_totale"))
        End If

        ' Rendu de la question
        RenderQuestionHeader(e, para.numQuestion, para.LaQuestion_lbl.Text, Ht, obr, _frm)
        Ht += 35

        ' Calcul de la hauteur nécessaire pour le texte
        Dim textSize As SizeF
        Using measureFont As New Font(oFontStr, 8)
            textSize = e.Graphics.MeasureString(txt, measureFont, ContentWidth - 10)
        End Using

        Dim textHeight As Integer = CInt(Math.Ceiling(textSize.Height)) + 10
        textHeight = Math.Max(textHeight, 60) ' hauteur mini

        ' Fond du paragraphe
        Dim paraRect As New Rectangle(MarginLeft, Ht, ContentWidth, textHeight)
        e.Graphics.FillRectangle(New SolidBrush(Color.White), paraRect)
        Using borderPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawRectangle(borderPen, paraRect)
        End Using

        ' Texte (peut être vide)
        _frm.Alignment = StringAlignment.Near
        _frm.LineAlignment = StringAlignment.Near
        _frm.FormatFlags = StringFormatFlags.LineLimit
        Using textFont As New Font(oFontStr, 8)
            e.Graphics.DrawString(txt, textFont, obr,
                              New RectangleF(MarginLeft + 5, Ht + 5,
                                             ContentWidth - 10, textHeight - 10), _frm)
        End Using

        Ht += textHeight

        ' Afficher la ligne de notes en dessous si disponible
        If afficherLesNotes AndAlso para.avecNote AndAlso note.HasValue Then
            RenderNoteLine(e, Ht, note, coef, noteTotale, obr)
        End If

        Ht += SectionSpacing
        Return True
    End Function

    Private Sub oReport_BeginPrint(sender As Object, e As PrintEventArgs) Handles oReport.BeginPrint
        obj.Clear()
        NumPage = 1
        H_pos = 0
    End Sub
    ''2 Rendu de l'en-tête de question (sans les notes)
    'Private Sub RenderQuestionHeader(e As PrintPageEventArgs,
    '                             numQuestion As String,
    '                             questionText As String,
    '                             y As Integer,
    '                             obr As SolidBrush,
    '                             _frm As StringFormat,
    '                             Optional note As Double? = Nothing,
    '                             Optional coef As Double? = Nothing,
    '                             Optional noteTotale As Double? = Nothing)

    '    Const QuestionHeight As Integer = 30

    '    ' Rectangle de la question (pleine largeur)
    '    Dim questionRect As New Rectangle(MarginLeft, y, ContentWidth, QuestionHeight)

    '    e.Graphics.FillRectangle(New SolidBrush(QuestionBackgroundColor), questionRect)

    '    ' Bordure gauche accentuée
    '    Using accentPen As New Pen(HeaderBackgroundColor, 3)
    '        e.Graphics.DrawLine(accentPen, MarginLeft, y, MarginLeft, y + QuestionHeight)
    '    End Using

    '    ' Bordure
    '    Using borderPen As New Pen(BorderColor, 0.5F)
    '        e.Graphics.DrawRectangle(borderPen, questionRect)
    '    End Using

    '    ' Texte de la question
    '    _frm.Alignment = StringAlignment.Near
    '    _frm.LineAlignment = StringAlignment.Center
    '    Using questionFont As New Font(oFontStr, 8, FontStyle.Bold)
    '        e.Graphics.DrawString(numQuestion & ". " & questionText, questionFont, obr,
    '                          New Rectangle(MarginLeft + 10, y,
    '                                        ContentWidth - 20,
    '                                        QuestionHeight), _frm)
    '    End Using
    'End Sub

    ' Fonction pour afficher la ligne de notes en dessous d'une question
    Private Sub RenderNoteLine(e As PrintPageEventArgs, ByRef y As Integer,
                              note As Double?, coef As Double?, noteTotale As Double?,
                              obr As SolidBrush)
        If Not (note.HasValue AndAlso coef.HasValue AndAlso noteTotale.HasValue) Then Return
        Dim accentPen As New SolidBrush(HeaderBackgroundColor)
        Const NoteLineHeight As Integer = 20

        ' Ligne de séparation horizontale
        Using separatorPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawLine(separatorPen, MarginLeft, y, MarginLeft + ContentWidth, y)
        End Using

        ' Rectangle pour la ligne de notes
        Dim noteLineRect As New Rectangle(MarginLeft, y, ContentWidth, NoteLineHeight)
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(250, 252, 255)), noteLineRect)


        Using borderPen As New Pen(BorderColor, 0.5F)
            ' Bordure du haut
            e.Graphics.DrawLine(borderPen, MarginLeft, y, MarginLeft + ContentWidth, y)
            ' Bordure gauche et droite
            e.Graphics.DrawLine(borderPen, MarginLeft, y, MarginLeft, y + NoteLineHeight)
            e.Graphics.DrawLine(borderPen, MarginLeft + ContentWidth, y, MarginLeft + ContentWidth, y + NoteLineHeight)
            ' Bordure du bas
            e.Graphics.DrawLine(borderPen, MarginLeft, y + NoteLineHeight, MarginLeft + ContentWidth, y + NoteLineHeight)
        End Using

        ' Affichage des notes en ligne
        Dim startX As Integer = MarginLeft + 480
        Dim textY As Integer = y + 5

        Using lblFont As New Font(oFontStr, 7, FontStyle.Regular)
            Using valFont As New Font(oFontStr, 7.5F, FontStyle.Bold)
                ' Note
                e.Graphics.DrawString("Note:", lblFont, accentPen, startX, textY)
                e.Graphics.DrawString(Math.Round(note.Value, 2).ToString(), valFont, obr, startX + 35, textY)

                ' Coef.
                startX += 90
                e.Graphics.DrawString("Coef.:", lblFont, accentPen, startX, textY)
                e.Graphics.DrawString(Math.Round(coef.Value, 2).ToString(), valFont, obr, startX + 35, textY)

                ' Total
                startX += 90
                e.Graphics.DrawString("Total:", lblFont, accentPen, startX, textY)
                e.Graphics.DrawString(Math.Round(noteTotale.Value, 2).ToString(), valFont, obr, startX + 35, textY)
            End Using
        End Using

        y += NoteLineHeight
    End Sub

#End Region
End Class