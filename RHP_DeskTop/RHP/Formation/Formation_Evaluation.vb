Imports System.Drawing.Printing

Public Class Formation_Evaluation
    Friend CodSurvey As String = ""
    Friend CodReponse As Integer = -1
    Dim Tbl_Question As New DataTable
    Dim lb1, lb2, lb3, lb4 As New Label

    ' Variables pour la logique Evaluation
    Dim afficherLesNotes As Boolean = False
    Dim btn_Signature As New mybtn_Signature(Me, "Signer_D", "", "btn_sign")
    Dim Paie_Calculee As Boolean = False



    Private Sub Survey_render_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not EstDate(Dat_Survey_txt.Text) Then Dat_Survey_txt.Text = Now.ToShortDateString
        Matricule_txt.Text = theUser.Matricule
        Cod_Formation_txt.Text = CnExecuting("select isnull((select top 1 Cod_Formation from Formation where isnull(Statut_Formation,'')='Cloturee' and id_Societe=" & Societe.id_Societe & " and Cod_Formation in (select Cod_Formation from Formation_Participants where id_Societe=" & Societe.id_Societe & " and isnull(Present,'false')='true' and Matricule like '" & Matricule_txt.Text & "%')),'')").Fields(0).Value
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me, "Matricule in (select Matricule from Formation_Participants where id_Societe=" & Societe.id_Societe & " and isnull(Present,'false')='true' and Cod_Formation in (select Cod_Formation from Formation where Cod_Formation like '" & Cod_Formation_txt.Text & "%' and id_Societe=" & Societe.id_Societe & " and isnull(Statut_Formation,'')='Cloturee'))")
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent+' '+Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        Request()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS157", Cod_Formation_txt, Me, " isnull(Statut_Formation,'')='Cloturee' and Cod_Formation in (select Cod_Formation from Formation_Participants where id_Societe=" & Societe.id_Societe & " and isnull(Present,'false')='true' and Matricule like '" & Matricule_txt.Text & "%')", Matricule_txt.Text)
    End Sub

    Private Sub Cod_Formation_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Formation_txt.TextChanged
        Request()
    End Sub
    
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Survey_lbl.LinkClicked
        Appel_Calender(Dat_Survey_txt, Me)
    End Sub

    Dim Code As String
    Sub Request()
        Dim statut As String = ""
        Save_pb.Enabled = True
        Paie_Calculee = False

        ' Logique spécifique Formation
        Lib_Formation_txt.Text = FindLibelle("Lib_Formation", "Cod_Formation", Cod_Formation_txt.Text, "Formation")
        CodSurvey = FindLibelle("Cod_Survey", "Cod_Formation", Cod_Formation_txt.Text, "Formation")
        
        Lib_Survey_lbl.Text = CodSurvey & " : " & FindLibelle("Lib_Survey", "Cod_Survey", CodSurvey, "Survey").ToString.ToUpper
        
        ' Recherche de la réponse existante (Typ_Evalue='F' pour Formation)
        CodReponse = CnExecuting("select isnull((select Top 1 Cod_Reply from Survey_Reply where Cod_Survey='" & CodSurvey & "' and Evaluateur='" & Matricule_txt.Text & "' and Evalue='" & Cod_Formation_txt.Text & "' and id_Societe=" & Societe.id_Societe & "),-1)").Fields(0).Value
        
        Preambule_rtb.Rtf = FindLibelle("Preambule", "Cod_Survey", CodSurvey, "Survey")
        Dat_Survey_txt.Text = FindLibelle("Dat_Survey", "Cod_Reply", CodReponse, "Survey_Reply")
        Preambule_rtb.Visible = (Preambule_rtb.Text.Trim <> "")

        If CodSurvey <> "" Then
            ' "F" pour Formation
            Tbl_Question = Generate_QuestionnaireNew(CodSurvey, pnl_Content, CodReponse, Cod_Formation_txt.Text, Matricule_txt.Text, "F")
            Print_pb.Visible = True
        Else
            pnl_Content.Controls.Clear()
            Print_pb.Visible = False
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

        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)

        ' Vérifier les droits d'accès
        ' On utilise Cod_Formation comme Ref pour le droit
        DroitAcces(Me, DroitModify_Fiche(Cod_Formation_txt.Text & "_" & Matricule_txt.Text, Me))
        If (statut = "") Then
            Code = Cod_Formation_txt.Text & "_" & Matricule_txt.Text
            Check_Accessible(Me.Name, Code)
        End If
    End Sub

    Sub New_pb_Click(sender As Object, e As EventArgs) Handles New_pb.Click
        Reset_Form(Me)
        Matricule_txt.Text = theUser.Matricule
        Cod_Formation_txt.Text = CnExecuting("select isnull((select top 1 Cod_Formation from Formation where isnull(Statut_Formation,'')='Cloturee' and id_Societe=" & Societe.id_Societe & " and Cod_Formation in (select Cod_Formation from Formation_Participants where id_Societe=" & Societe.id_Societe & " and isnull(Present,'false')='true' and Matricule like '" & Matricule_txt.Text & "%')),'')").Fields(0).Value
        If Not EstDate(Dat_Survey_txt.Text) Then Dat_Survey_txt.Text = Now.ToShortDateString
        Request()
    End Sub

    Private Sub Cloture_pb_Click(sender As Object, e As EventArgs) Handles Cloture_pb.Click
        ' Validation
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
        ImprimerEvaluation(Cod_Formation_txt.Text, Matricule_txt.Text, Cod_Formation_txt.Text)
    End Sub

    Sub Recalcul()
        Dim dictQ As New Dictionary(Of ud_pattern, Dictionary(Of String, String))
        If pnl_Content.Tag Is Nothing Then Return
        dictQ = pnl_Content.Tag
        Dim note As Double = 0
        Dim coef As Double = 0
        
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
        If Cod_Formation_txt.Text = "" Then Return New savingResult With {.result = False, .message = "Code formation vide."}
        If Matricule_txt.Text = "" Then Return New savingResult With {.result = False, .message = "Matricule vide."}
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
        
        rs("Evaluateur").Value = Matricule_txt.Text
        rs("Typ_Evalue").Value = "F"
        rs("Evalue").Value = Cod_Formation_txt.Text
        ' rs("Ref_Evaluation").Value = Cod_Formation_txt.Text ' Optionnel, si nécessaire
        rs("Statut").Value = statut
        
        ' Sauvegarde des notes
        rs("Note").Value = IIf(note_txt.Text = "", 0, note_txt.Text)
        rs("Coef").Value = IIf(coef_txt.Text = "", 0, coef_txt.Text)
        rs("Note_Totale").Value = IIf(note_totale_txt.Text = "", 0, note_totale_txt.Text)
        
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

                    If nrw(0)("Sous_Question").ToString.Split({";"c}, StringSplitOptions.RemoveEmptyEntries).Length > 0 And IsNumeric(v.Key) Then
                        Dim sq As String = nrw(0)("Sous_Question").ToString
                        rs("Sous_Question").Value = sq.Split({";"c}, StringSplitOptions.RemoveEmptyEntries)(v.Key)
                        Reponse = ""
                        Select Case nrw(0)("Typ_Reponse")
                            Case "grille_cases", "cocher", "oui_non", "vrai_faux", "echelle", "grille_choix", "choix"
                                rsp = v.Key.Split({";"c}, StringSplitOptions.RemoveEmptyEntries)
                                For n = 0 To rsp.Length - 1
                                    If rsp(n).Trim = "1" Then
                                        Reponse &= IIf(Reponse = "", "", ";") & nrw(0)("Reponses_Possibles").ToString.Split({";"c}, StringSplitOptions.RemoveEmptyEntries)(n)
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

#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        Return Saving("SS")
    End Function

    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function

    Sub miseAjourBtnValidationSignature(statut As String)
        Dim typDoc As String = "EV"
        Dim gereWrkf As Boolean = estGereEnSignature(typDoc)
        Dim controlToRemove As Control = ent_pnl.GetControlFromPosition(3, 0)

        If gereWrkf Then
            If TypeOf controlToRemove IsNot mybtn_Signature Then
                Dim Dv As DataView = Tbl_Workflow_ParamDocuments.DefaultView
                Dv.RowFilter = "Typ_Document='" & typDoc & "' and isnull(Gere_Signature,'false')='true'"
                Dim Dt = Dv.ToTable
                If Dt.Rows.Count = 0 Then Return

                With btn_Signature
                    .Image = My.Resources.Resources.btn_sign
                    .Name = "Signer_D"
                    .tbl = Dt
                    .frm = Me
                    .Statut = statut
                    .valeurIndex = CodReponse
                    .Visible = (estGereEnSignature(typDoc) And (.valeurIndex <> ""))
                    .ToolTip = "Signatures"
                    .Size = New Size(.Width * 1.2, .Height * 1.2)
                    AddHandler .Click, AddressOf SubSignatures
                End With

                If controlToRemove IsNot Nothing Then
                    ent_pnl.Controls.Remove(controlToRemove)
                    controlToRemove.Dispose()
                End If
                ent_pnl.Controls.Add(btn_Signature, 3, 0)
            Else
                With CType(controlToRemove, mybtn_Signature)
                    .Statut = statut
                    .valeurIndex = CodReponse
                    .Visible = (estGereEnSignature(typDoc) And (.valeurIndex <> ""))
                    .Size = New Size(.Width * 1.2, .Height * 1.2)
                End With
            End If
        Else
            Cloture_pb.Enabled = statut = ""
            Cloture_pb.Image = If(statut = "", My.Resources.btn_unlock, My.Resources.btn_lock_w)

            If TypeOf controlToRemove IsNot PictureBox Then
                If controlToRemove IsNot Nothing Then
                    ent_pnl.Controls.Remove(controlToRemove)
                    controlToRemove.Dispose()
                End If
                ent_pnl.Controls.Add(Cloture_pb, 3, 0)
            End If
        End If
    End Sub
#End Region

#Region "Impression"
    Private WithEvents oReport As New PrintDocument
    Private obj As New ArrayList
    Private H_pos As Integer
    Private NumPage As Integer = 1
    Private oFontStr As String = "Segoe UI"

    ' Couleurs améliorées pour un design moderne (identique à Evaluation.vb)
    Private ReadOnly HeaderBackgroundColor As Color = Color.FromArgb(41, 128, 185)
    Private ReadOnly HeaderTextColor As Color = Color.White
    Private ReadOnly SectionHeaderColor As Color = Color.FromArgb(236, 240, 241)
    Private ReadOnly BorderColor As Color = Color.FromArgb(189, 195, 199)
    Private ReadOnly AlternateRowColor As Color = Color.FromArgb(250, 251, 252)
    Private ReadOnly QuestionBackgroundColor As Color = Color.FromArgb(245, 248, 250)

    ' Marges et dimensions
    Private ReadOnly MarginLeft As Integer = 40
    Private ReadOnly MarginRight As Integer = 40
    Private ReadOnly MarginTop As Integer = 50
    Private ReadOnly MarginBottom As Integer = 50
    Private HeaderHeight As Integer = 105
    Private ReadOnly FooterHeight As Integer = 40
    Private ReadOnly SectionSpacing As Integer = 20

    Private MaxW As Integer
    Private MaxH As Integer
    Private ContentWidth As Integer

    Sub ImprimerEvaluation(Cod_Evaluation As String, Evaluateur As String, Evalue As String)
        Try
            obj.Clear()
            NumPage = 1
            With oReport
                .DocumentName = "Évaluation - " & Lib_Survey_lbl.Text
                RemoveHandler .PrintPage, AddressOf oReport_PrintPage
                AddHandler .PrintPage, AddressOf oReport_PrintPage
                .DefaultPageSettings.Landscape = False
                .DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
                .DefaultPageSettings.Margins = New Margins(MarginLeft, MarginRight, MarginTop, MarginBottom)
            End With
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

        If NumPage = 1 Then
            RenderHeader(e, obr, _frm)
            Ht = MarginTop + HeaderHeight + SectionSpacing
        Else
            Ht = MarginTop
        End If

        If obj.Count = 0 Then
            For Each ctrl As Control In pnl_Content.Controls.Cast(Of Control)().Reverse()
                If TypeOf ctrl Is ud_pattern Then
                    obj.Add(ctrl)
                End If
            Next
        End If

        Dim startIndex As Integer = H_pos
        Dim hasMorePages As Boolean = False

        For i As Integer = startIndex To obj.Count - 1
            Dim ctrl As Control = CType(obj(i), Control)
            Dim rendered As Boolean = False
            Dim estimatedHeight As Integer = EstimateControlHeight(ctrl)

            If Ht + estimatedHeight > MaxH - FooterHeight - MarginBottom Then
                hasMorePages = True
                H_pos = i
                Exit For
            End If

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

        RenderFooterImproved(e, obr, _frm)
        e.HasMorePages = hasMorePages

        If hasMorePages Then
            NumPage += 1
        Else
            obj.Clear()
            H_pos = 0
            NumPage = 1
        End If
    End Sub

    Private Function IsControlEmpty(ctrl As Control) As Boolean
        If TypeOf ctrl Is ud_grille_libre Then
            Dim grid As ud_grille_libre = CType(ctrl, ud_grille_libre)
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

    Private Sub RenderHeader(e As PrintPageEventArgs, obr As SolidBrush, _frm As StringFormat)
        Dim headerRect As New Rectangle(0, 0, MaxW, 60)
        Using gradientBrush As New Drawing2D.LinearGradientBrush(
        headerRect, HeaderBackgroundColor, Color.FromArgb(52, 152, 219), Drawing2D.LinearGradientMode.Horizontal)
            e.Graphics.FillRectangle(gradientBrush, headerRect)
        End Using

        _frm.Alignment = StringAlignment.Center
        _frm.LineAlignment = StringAlignment.Center
        Using titleFont As New Font(oFontStr, 14, FontStyle.Bold)
            e.Graphics.DrawString(Lib_Survey_lbl.Text.ToUpper() & vbCrLf & Dat_Survey_txt.Text, titleFont,
                              New SolidBrush(HeaderTextColor),
                              New Rectangle(0, 0, MaxW, 60), _frm)
        End Using

        Dim headerFont As New Font(oFontStr, 9, FontStyle.Bold)
        Dim textFont As New Font(oFontStr, 8)
        Dim boxPen As New Pen(BorderColor, 0.5F)
        Dim startY As Integer = 70
        Dim boxHeight As Integer = 22
        Dim labelWidth As Integer = 90
        Dim codeWidth As Integer = 80
        Dim nameWidth As Integer = ContentWidth - labelWidth - codeWidth

        ' Ligne 1 : L'évaluateur (Utilisateur courant)
        e.Graphics.DrawString("L'évaluateur", headerFont, obr, MarginLeft, startY + 4)
        e.Graphics.DrawRectangle(boxPen, MarginLeft + labelWidth, startY, codeWidth, boxHeight)
        e.Graphics.DrawString(Matricule_txt.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + 3, startY + 2, codeWidth - 6, boxHeight - 4))
        e.Graphics.DrawRectangle(boxPen, MarginLeft + labelWidth + codeWidth, startY, nameWidth, boxHeight)
        e.Graphics.DrawString(Nom_Agent_Text.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + codeWidth + 3, startY + 2, nameWidth - 6, boxHeight - 4))
        startY += boxHeight + 4

        ' Ligne 2 : Évalué (La Formation)
        e.Graphics.DrawString("Formation", headerFont, obr, MarginLeft, startY + 4)
        e.Graphics.DrawRectangle(boxPen, MarginLeft + labelWidth, startY, codeWidth, boxHeight)
        e.Graphics.DrawString(Cod_Formation_txt.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + 3, startY + 2, codeWidth - 6, boxHeight - 4))
        e.Graphics.DrawRectangle(boxPen, MarginLeft + labelWidth + codeWidth, startY, nameWidth, boxHeight)
        e.Graphics.DrawString(Lib_Formation_txt.Text, textFont, obr,
                          New Rectangle(MarginLeft + labelWidth + codeWidth + 3, startY + 2, nameWidth - 6, boxHeight - 4))
        startY += boxHeight + 4

        ' Ligne 3: Evaluation Survey Libelle
        ' Dans Evaluation.vb c'est "Evaluation" -> Cod_Evaluation / Lib_Survey
        ' Ici on peut remettre CodSurvey
        e.Graphics.DrawString("Sondage", headerFont, obr, MarginLeft, startY + 4)
        e.Graphics.DrawRectangle(boxPen, MarginLeft + labelWidth, startY, codeWidth, boxHeight)
        e.Graphics.DrawString(CodSurvey, textFont, obr,
                           New Rectangle(MarginLeft + labelWidth + 3, startY + 2, codeWidth - 6, boxHeight - 4))
        ' On utilise le libellé de survey affiché
        Dim libSurveyOnly As String = If(Lib_Survey_lbl.Text.Contains(":"), Lib_Survey_lbl.Text.Split({":"c}, 2)(1).Trim(), Lib_Survey_lbl.Text)

        e.Graphics.DrawRectangle(boxPen, MarginLeft + labelWidth + codeWidth, startY, nameWidth, boxHeight)
        e.Graphics.DrawString(libSurveyOnly, textFont, obr,
                           New Rectangle(MarginLeft + labelWidth + codeWidth + 3, startY + 2, nameWidth - 6, boxHeight - 4))

        If afficherLesNotes Then
            startY += boxHeight + 4
            Dim accentPen As New SolidBrush(Color.White)
            Dim noteLineRect As New Rectangle(MarginLeft, startY, ContentWidth, boxHeight + 12)

            e.Graphics.FillRectangle(New SolidBrush(HeaderBackgroundColor), noteLineRect)
            startY += 6
            Dim noteStr = $"Note totale: {note_txt.Text}      Coefficient: {coef_txt.Text}      Note finale: {note_totale_txt.Text}"
            Using lblFont As New Font(oFontStr, 12, FontStyle.Bold)
                Dim textSize As SizeF = e.Graphics.MeasureString(noteStr, lblFont)
                Dim startX As Integer = MarginLeft + (oReport.DefaultPageSettings.PaperSize.Width - textSize.Width) / 2
                e.Graphics.DrawString(noteStr, lblFont, accentPen, startX, startY)
            End Using
            HeaderHeight += SectionSpacing + (boxHeight + 4)
        End If
    End Sub

    Private Sub DrawInfoBox(e As PrintPageEventArgs, label As String, value As String,
                           x As Integer, y As Integer, width As Integer,
                           obr As SolidBrush, _frm As StringFormat)
        e.Graphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(x, y, width, 25))
        Using borderPen As New Pen(BorderColor, 1)
            e.Graphics.DrawRectangle(borderPen, New Rectangle(x, y, width, 25))
        End Using
        Using labelFont As New Font(oFontStr, 7, FontStyle.Regular)
            e.Graphics.DrawString(label, labelFont, New SolidBrush(Color.Gray), New Point(x + 5, y - 15))
        End Using
        _frm.Alignment = StringAlignment.Near
        _frm.LineAlignment = StringAlignment.Center
        Using valueFont As New Font(oFontStr, 8, FontStyle.Bold)
            e.Graphics.DrawString(value, valueFont, obr, New Rectangle(x + 5, y, width - 10, 25), _frm)
        End Using
    End Sub

    Private Function RenderGridLibreImproved(e As PrintPageEventArgs, ctrl As Object,
                                        ByRef Ht As Integer, obr As SolidBrush,
                                        _frm As StringFormat) As Boolean
        If TypeOf ctrl IsNot ud_grille_libre AndAlso
       TypeOf ctrl IsNot ud_grille_cases AndAlso
       TypeOf ctrl IsNot ud_grille_choix Then Return False
        Dim grid = ctrl
        Dim note As Double? = Nothing
        Dim coef As Double? = Nothing
        Dim noteTotale As Double? = Nothing
        If afficherLesNotes AndAlso grid.avecNote AndAlso grid.noteDic IsNot Nothing AndAlso grid.noteDic.Count > 0 Then
            note = CDbl(grid.noteDic("note"))
            coef = CDbl(grid.noteDic("coef"))
            noteTotale = CDbl(grid.noteDic("note_totale"))
        End If
        RenderQuestionHeader(e, grid.numQuestion, grid.laquestion, Ht, obr, _frm)
        Ht += 35
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
        Dim totalWidth As Integer = ContentWidth
        Dim colWidths As New Dictionary(Of Integer, Integer)
        Dim firstColIndex As Integer = nonEmptyColumns(0)
        If nonEmptyColumns.Count = 1 Then
            colWidths(firstColIndex) = totalWidth
        Else
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
        Dim currentX As Integer = MarginLeft
        Using headerFont As New Font(oFontStr, 7, FontStyle.Bold)
            For Each colIndex In nonEmptyColumns
                Dim colWidth As Integer = colWidths(colIndex)
                If colIndex <> firstColIndex Then
                    e.Graphics.FillRectangle(New SolidBrush(SectionHeaderColor), New Rectangle(currentX, Ht, colWidth, 25))
                End If
                Using borderPen As New Pen(BorderColor, 0.5F)
                    e.Graphics.DrawRectangle(borderPen, New Rectangle(currentX, Ht, colWidth, 25))
                End Using
                _frm.Alignment = If(colIndex = firstColIndex, StringAlignment.Near, StringAlignment.Center)
                _frm.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(grid.Grd.Columns(colIndex).HeaderText, headerFont, obr,
                                  New Rectangle(currentX + 3, Ht, colWidth - 6, 25), _frm)
                currentX += colWidth
            Next
        End Using
        Ht += 25
        Using dataFont As New Font(oFontStr, 7)
            For r As Integer = 0 To grid.Grd.RowCount - 1
                currentX = MarginLeft
                If r Mod 2 = 1 Then
                    e.Graphics.FillRectangle(New SolidBrush(AlternateRowColor), New Rectangle(MarginLeft, Ht, ContentWidth, 22))
                End If
                For Each colIndex In nonEmptyColumns
                    Dim colWidth As Integer = colWidths(colIndex)
                    Dim cellValue = grid.Grd.Item(colIndex, r).Value
                    Using borderPen As New Pen(BorderColor, 0.5F)
                        e.Graphics.DrawRectangle(borderPen, New Rectangle(currentX, Ht, colWidth, 22))
                    End Using
                    RenderCellContent(e, grid.Grd.Columns(colIndex), cellValue, grid.Grd.Item(colIndex, r).Tag, currentX, Ht, colWidth, 22, obr, dataFont, _frm)
                    currentX += colWidth
                Next
                Ht += 22
            Next
        End Using
        If afficherLesNotes AndAlso grid.avecNote AndAlso note.HasValue Then
            ' Assumption: RenderNoteLine exists or I need to add it. 
            ' Evaluation.vb had RenderNoteLine but here it is missing in previous file view. 
            ' I will add RenderNoteLine to be safe.
            RenderNoteLine(e, Ht, note, coef, noteTotale, obr)
        End If
        Ht += SectionSpacing
        Return True
    End Function



    Private Function ColumnHasData(grid As Object, colIndex As Integer) As Boolean
        For r As Integer = 0 To grid.Grd.RowCount - 1
            If grid.Grd.Item(colIndex, r).Value IsNot Nothing AndAlso
               grid.Grd.Item(colIndex, r).Value.ToString().Trim() <> "" Then
                Return True
            End If
        Next
        Return False
    End Function

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
                e.Graphics.DrawImage(img, New Rectangle(contentX + contentW \ 2 - 8, contentY + contentH \ 2 - 8, 16, 16))
            Case TypeOf column Is DataGridViewCheckBoxColumn
                Dim isChecked As Boolean = GetBooleanValue(value, False)
                Dim img As Image = If(isChecked, My.Resources.check_1, My.Resources.check_0)
                e.Graphics.DrawImage(img, New Rectangle(contentX + contentW \ 2 - 8, contentY + contentH \ 2 - 8, 16, 16))
            Case Else
                If value IsNot Nothing Then
                    _frm.Alignment = StringAlignment.Near
                    _frm.LineAlignment = StringAlignment.Center
                    e.Graphics.DrawString(value.ToString(), font, obr, New Rectangle(contentX, y, contentW, h), _frm)
                End If
        End Select
    End Sub

    Private Sub RenderQuestionHeader(e As PrintPageEventArgs, numQuestion As String,
                                    questionText As String, y As Integer,
                                    obr As SolidBrush, _frm As StringFormat)
        Dim questionRect As New Rectangle(MarginLeft, y, ContentWidth, 30)
        e.Graphics.FillRectangle(New SolidBrush(QuestionBackgroundColor), questionRect)
        Using accentPen As New Pen(HeaderBackgroundColor, 3)
            e.Graphics.DrawLine(accentPen, MarginLeft, y, MarginLeft, y + 30)
        End Using
        Using borderPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawRectangle(borderPen, questionRect)
        End Using
        _frm.Alignment = StringAlignment.Near
        _frm.LineAlignment = StringAlignment.Center
        Using questionFont As New Font(oFontStr, 8, FontStyle.Bold)
            e.Graphics.DrawString(numQuestion & ". " & questionText, questionFont, obr,
                                New Rectangle(MarginLeft + 10, y, ContentWidth - 20, 30), _frm)
        End Using
    End Sub

    Private Function GetBooleanValue(value As Object, defaultValue As Boolean) As Boolean
        If value Is Nothing Then Return defaultValue
        If TypeOf value Is Boolean Then Return CBool(value)
        If TypeOf value Is String Then
            Dim strValue As String = value.ToString().ToLower()
            Return strValue = "true" OrElse strValue = "1" OrElse strValue = "oui" OrElse strValue = "yes"
        End If
        Return defaultValue
    End Function

    Private Sub RenderFooterImproved(e As PrintPageEventArgs, obr As SolidBrush, _frm As StringFormat)
        Dim footerY As Integer = MaxH - FooterHeight
        Using separatorPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawLine(separatorPen, MarginLeft, footerY, MaxW - MarginRight, footerY)
        End Using
        Using footerFont As New Font(oFontStr, 7)
            _frm.Alignment = StringAlignment.Center
            _frm.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString("Page " & NumPage, footerFont, New SolidBrush(Color.Gray),
                                New Rectangle(MarginLeft, footerY + 5, ContentWidth, 20), _frm)
            _frm.Alignment = StringAlignment.Far
            e.Graphics.DrawString("Imprimé le " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                                footerFont, New SolidBrush(Color.Gray),
                                New Rectangle(MarginLeft, footerY + 5, ContentWidth, 20), _frm)
        End Using
    End Sub

    Private Function RenderGridChoixImproved(e As PrintPageEventArgs, ctrl As Control,
                                            ByRef Ht As Integer, obr As SolidBrush,
                                            _frm As StringFormat) As Boolean
        Return RenderGridLibreImproved(e, ctrl, Ht, obr, _frm)
    End Function

    Private Function RenderGridCasesImproved(e As PrintPageEventArgs, ctrl As Control,
                                            ByRef Ht As Integer, obr As SolidBrush,
                                            _frm As StringFormat) As Boolean
        Return RenderGridLibreImproved(e, ctrl, Ht, obr, _frm)
    End Function

    Private Function RenderValeurUniqueImproved(e As PrintPageEventArgs, ctrl As Control,
                                           ByRef Ht As Integer, obr As SolidBrush,
                                           _frm As StringFormat) As Boolean
        Dim valeur As ud_valeur_unique = CType(ctrl, ud_valeur_unique)
        Dim txt As String = ""
        If valeur.repDic IsNot Nothing AndAlso valeur.repDic.ContainsKey("0") Then
            txt = valeur.repDic("0").Trim()
        End If
        Dim note As Double? = Nothing
        Dim coef As Double? = Nothing
        Dim noteTotale As Double? = Nothing
        If afficherLesNotes AndAlso valeur.avecNote AndAlso valeur.noteDic IsNot Nothing AndAlso valeur.noteDic.Count > 0 Then
            note = CDbl(valeur.noteDic("note"))
            coef = CDbl(valeur.noteDic("coef"))
            noteTotale = CDbl(valeur.noteDic("note_totale"))
        End If
        RenderQuestionHeader(e, valeur.numQuestion, valeur.laquestion, Ht, obr, _frm)
        Const ValueBoxWidth As Integer = 200
        Const headerHeight As Integer = 30
        Dim totalRight As Integer = MarginLeft + ContentWidth
        Dim valueX As Integer = totalRight - ValueBoxWidth
        Dim valueRect As New Rectangle(valueX, Ht, ValueBoxWidth, headerHeight)
        e.Graphics.FillRectangle(New SolidBrush(Color.White), valueRect)
        Using borderPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawRectangle(borderPen, valueRect)
        End Using
        _frm.Alignment = StringAlignment.Center
        _frm.LineAlignment = StringAlignment.Center
        Using valueFont As New Font(oFontStr, 8, FontStyle.Bold)
            e.Graphics.DrawString(txt, valueFont, obr, valueRect, _frm)
        End Using
        Ht += headerHeight
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
        Dim txt As String = ""
        If para.repDic IsNot Nothing AndAlso para.repDic.ContainsKey("0") Then
            txt = para.repDic("0").Trim()
        End If
        Dim note As Double? = Nothing
        Dim coef As Double? = Nothing
        Dim noteTotale As Double? = Nothing
        If afficherLesNotes AndAlso para.avecNote AndAlso para.noteDic IsNot Nothing AndAlso para.noteDic.Count > 0 Then
            note = CDbl(para.noteDic("note"))
            coef = CDbl(para.noteDic("coef"))
            noteTotale = CDbl(para.noteDic("note_totale"))
        End If
        RenderQuestionHeader(e, para.numQuestion, para.LaQuestion_lbl.Text, Ht, obr, _frm)
        Ht += 35
        Dim textSize As SizeF
        Using measureFont As New Font(oFontStr, 8)
            textSize = e.Graphics.MeasureString(txt, measureFont, ContentWidth - 10)
        End Using
        Dim textHeight As Integer = CInt(Math.Ceiling(textSize.Height)) + 10
        textHeight = Math.Max(textHeight, 60)
        Dim paraRect As New Rectangle(MarginLeft, Ht, ContentWidth, textHeight)
        e.Graphics.FillRectangle(New SolidBrush(Color.White), paraRect)
        Using borderPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawRectangle(borderPen, paraRect)
        End Using
        _frm.Alignment = StringAlignment.Near
        _frm.LineAlignment = StringAlignment.Near
        _frm.FormatFlags = StringFormatFlags.LineLimit
        Using textFont As New Font(oFontStr, 8)
            e.Graphics.DrawString(txt, textFont, obr,
                              New RectangleF(MarginLeft + 5, Ht + 5, ContentWidth - 10, textHeight - 10), _frm)
        End Using
        Ht += textHeight
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

    Private Sub RenderNoteLine(e As PrintPageEventArgs, ByRef y As Integer,
                              note As Double?, coef As Double?, noteTotale As Double?,
                              obr As SolidBrush)
        If Not (note.HasValue AndAlso coef.HasValue AndAlso noteTotale.HasValue) Then Return
        Dim accentPen As New SolidBrush(HeaderBackgroundColor)
        Const NoteLineHeight As Integer = 20
        Using separatorPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawLine(separatorPen, MarginLeft, y, MarginLeft + ContentWidth, y)
        End Using
        Dim noteLineRect As New Rectangle(MarginLeft, y, ContentWidth, NoteLineHeight)
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(250, 252, 255)), noteLineRect)
        Using borderPen As New Pen(BorderColor, 0.5F)
            e.Graphics.DrawLine(borderPen, MarginLeft, y, MarginLeft + ContentWidth, y)
            e.Graphics.DrawLine(borderPen, MarginLeft, y, MarginLeft, y + NoteLineHeight)
            e.Graphics.DrawLine(borderPen, MarginLeft + ContentWidth, y, MarginLeft + ContentWidth, y + NoteLineHeight)
            e.Graphics.DrawLine(borderPen, MarginLeft, y + NoteLineHeight, MarginLeft + ContentWidth, y + NoteLineHeight)
        End Using
        Dim startX As Integer = MarginLeft + 480
        Dim textY As Integer = y + 5
        Using lblFont As New Font(oFontStr, 7, FontStyle.Regular)
            Using valFont As New Font(oFontStr, 7.5F, FontStyle.Bold)
                e.Graphics.DrawString("Note:", lblFont, accentPen, startX, textY)
                e.Graphics.DrawString(Math.Round(note.Value, 2).ToString(), valFont, obr, startX + 35, textY)
                startX += 90
                e.Graphics.DrawString("Coef.:", lblFont, accentPen, startX, textY)
                e.Graphics.DrawString(Math.Round(coef.Value, 2).ToString(), valFont, obr, startX + 35, textY)
                startX += 90
                e.Graphics.DrawString("Total:", lblFont, accentPen, startX, textY)
                e.Graphics.DrawString(Math.Round(noteTotale.Value, 2).ToString(), valFont, obr, startX + 35, textY)
            End Using
        End Using
        y += NoteLineHeight
    End Sub
#End Region

    Private Sub Survey_Reply_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub

End Class