Imports System.Drawing.Printing
Public Class Entretien
    Friend CodSurvey As String = ""
    Friend CodReponse As Integer = -1
    Dim Tbl_Question As New DataTable
    Dim lb1, lb2, lb3, lb4 As New Label
    Dim TblCandidats As New DataTable
    Dim TblEvaluateurs As New DataTable

    ' Variables pour la logique commune Evaluation / Formation_Evaluation
    Dim afficherLesNotes As Boolean = False
    Dim btn_Signature As New mybtn_Signature(Me, "Signer_D", "", "btn_sign")
    Dim Paie_Calculee As Boolean = False

#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        Return Saving("SS")
    End Function

    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function

    Sub miseAjourBtnValidationSignature(statut As String)
        Dim typDoc As String = "RC"
        Dim gereWrkf As Boolean = estGereEnSignature(typDoc)
        Dim controlToRemove As Control = ent_pnl.GetControlFromPosition(1, 0)

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
                    .Visible = (estGereEnSignature(typDoc) And CodReponse > 0)
                    .ToolTip = "Signatures"
                    .Size = New Size(.Width * 1.2, .Height * 1.2)
                    AddHandler .Click, AddressOf SubSignatures
                End With

                If controlToRemove IsNot Nothing Then
                    ent_pnl.Controls.Remove(controlToRemove)
                    controlToRemove.Dispose()
                End If
                ent_pnl.Controls.Add(btn_Signature, 1, 0)
            Else
                With CType(controlToRemove, mybtn_Signature)
                    .Statut = statut
                    .valeurIndex = CodReponse
                    .Visible = (estGereEnSignature(typDoc) And CodReponse > 0)
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
                ent_pnl.Controls.Add(Cloture_pb, 1, 0)
            End If
        End If
    End Sub
#End Region

    Dim Code As String
    Sub Request()
        Dim statut As String = ""
        Save_pb.Enabled = True
        Paie_Calculee = False

        ' Logique spécifique Recrutement
        CodSurvey = FindLibelle("Formulaire", "Num_RC", Num_RC_txt.Text, "Recrutement")
        Lib_Survey_lbl.Text = CodSurvey & " : " & FindLibelle("Lib_Survey", "Cod_Survey", CodSurvey, "Survey").ToString.ToUpper

        CodReponse = CnExecuting("select isnull((select Top 1 Cod_Reply from Survey_Reply where Cod_Survey='" & CodSurvey & "' and Evaluateur='" & Evaluateur_txt.Text & "' and Evalue='" & Evalue_txt.Text & "' and id_Societe=" & Societe.id_Societe & "),-1)").Fields(0).Value
        Cod_Reply_txt.Text = If(CodReponse > 0, CodReponse, "")

        Preambule_rtb.Rtf = FindLibelle("Preambule", "Cod_Survey", CodSurvey, "Survey")
        If CodReponse > -1 Then
            Dim datRep As Object = CnExecuting($"select isnull(Dat_Survey, getdate()) from Survey_Reply where Cod_Reply={CodReponse} and id_Societe={Societe.id_Societe}").Fields(0).Value
            If IsDate(datRep) Then Dat_Survey.Value = CDate(datRep)
        Else
            Dat_Survey.Value = Now
        End If
        Preambule_rtb.Visible = (Preambule_rtb.Text.Trim <> "")

        If CodSurvey <> "" Then
            ' "R" pour Recrutement
            Tbl_Question = Generate_QuestionnaireNew(CodSurvey, pnl_Content, CodReponse, Evalue_txt.Text, Evaluateur_txt.Text, "R")
        Else
            pnl_Content.Controls.Clear()
        End If

        afficherLesNotes = Tbl_Question.Select("AvecNote='true'").Length > 0

        If CodReponse > -1 Then
            statut = Module_Generateur_Survey.Statut_Survey
            Paie_Calculee = Module_Generateur_Survey.Paie_Calcule
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
        DroitAcces(Me, DroitModify_Fiche(Num_RC_txt.Text & "_" & Evalue_txt.Text & "_" & Evaluateur_txt.Text, Me))
        If (statut = "") Then
            Code = Num_RC_txt.Text & "_" & Evalue_txt.Text & "_" & Evaluateur_txt.Text
            Check_Accessible(Me.Name, Code)
        End If
    End Sub

    Private Sub Cloture_pb_Click(sender As Object, e As EventArgs) Handles Cloture_pb.Click
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

    Private Sub Print_D_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ImprimerEvaluation(Num_RC_txt.Text, Evaluateur_txt.Text, Evalue_txt.Text)
    End Sub

    Sub Recalcul()
        Dim dictQ As New Dictionary(Of ud_pattern, Dictionary(Of String, String))
        If pnl_Content.Tag Is Nothing Then Return
        dictQ = pnl_Content.Tag
        Dim note_totale As Double = 0
        Dim coef As Double = 0

        ' Appliquer la logique de visibilité
        Module_Generateur_Survey.survey_CheckVisibility(Tbl_Question, dictQ)

        For Each c In dictQ
            Dim noteDic = c.Key.noteDic
            If noteDic IsNot Nothing AndAlso noteDic.Count > 0 Then
                If c.Key.avecNote And c.Key.modeScoring <> "na" AndAlso c.Key.Visible Then
                    note_totale += noteDic("note_totale")
                    coef += noteDic("coef")
                End If
            End If
        Next
        If coef = 0 Then coef = 1

        note_txt.Text = Math.Round(CDbl(note_totale / coef), 2)
        coef_txt.Text = Math.Round(coef, 2)
        note_totale_txt.Text = Math.Round(note_totale, 2)
    End Sub

    Function Saving(statut As String) As savingResult
        If Paie_Calculee Then Return New savingResult With {.result = False, .message = "Cet entretien concerne une paie déjà calculée."}
        If Num_RC_txt.Text = "" Then Return New savingResult With {.result = False, .message = "N° recrutement vide."}
        If Evalue_txt.Text = "" Then Return New savingResult With {.result = False, .message = "Recrue vide."}
        If CodSurvey = "" Then Return New savingResult With {.result = False, .message = "Formulaire d'entretien vide."}
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

        '1-Vérification des champs obligatoires non conditionnés
        For i = Arr.Count - 1 To 0 Step -1
            nrw = Tbl_Question.Select($"Cod_Question={Arr(i).key.Name} and Obligatoire='true' and Obligatoire_Si=''")
            If nrw.Length > 0 Then
                If estVide(Arr(i).key) Then
                    estErreur(Arr(i).key)
                    Return New savingResult With {.result = False, .message = "Des champs obligatoires ne sont pas renseignés."}
                End If
            End If
        Next

        '2- Vérification des champs obligatoires conditionnés
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
        rs("Typ_Evalue").Value = "R"
        rs("Evalue").Value = Evalue_txt.Text
        rs("Ref_Evaluation").Value = Num_RC_txt.Text
        rs("Statut").Value = statut
        rs("Note").Value = If(IsNumeric(note_txt.Text), CDbl(note_txt.Text), 0)
        rs("Coef").Value = If(IsNumeric(coef_txt.Text), CDbl(coef_txt.Text), 1)
        rs("Note_Totale").Value = If(IsNumeric(note_totale_txt.Text), CDbl(note_totale_txt.Text), 0)
        rs("Dat_Survey").Value = Dat_Survey.Value
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

        ' Spécifique métier Recrutement : mise à jour de la date de réalisation
        CnExecuting($"update Recrutement_Entretiens set Dat_Entretien_Realise=getdate() where Candidat='{Evalue_txt.Text}' and Evaluateur='{Evaluateur_txt.Text}' and Num_RC='{Num_RC_txt.Text}' and id_Societe={Societe.id_Societe}")

        Return New savingResult With {.result = True, .message = "Entretien enregistré avec succès."}
    End Function

    Sub estErreur(ud As ud_pattern)
        ud.Select()
        pnl_Content.ScrollControlIntoView(ud)
        ud.BackColor = Color.Red
    End Sub

#Region "Impression"
    Dim eRw(), mRw() As DataRow
    Dim formGraphics As System.Drawing.Graphics
    Friend WithEvents oReport As New Printing.PrintDocument
    Dim NumPage As Integer = 1
    Dim NouvellePage As Boolean = False
    Dim MaxH As Integer = 1122
    Dim MaxW As Integer = 793
    Dim FooterH As Integer = 80
    Dim oHeight As Integer = 0
    Dim ps As New PaperSize("A4", MaxW, MaxH)
    Dim oFontStr As String = "Century Gothic"

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS163", Num_RC_txt, Me, " Matricule = '" & theUser.Matricule & "'")
            End If
        Else
            Appel_Zoom1("MS163", Num_RC_txt, Me)
        End If
    End Sub

    Dim obj As New ArrayList
    Sub ImprimerEvaluation(CodEvaluation As String, Evaluateur As String, Evalue As String)
        NumPage = 1
        obj.Clear()
        Dim TblAgent As DataTable = DATA_READER_GRD("select * from Sys_RH_Preparation_Paie_Agent where Matricule in ('" & Evaluateur & "','" & Evalue & "') and id_Societe=" & Societe.id_Societe)
        eRw = TblAgent.Select("Matricule='" & Evaluateur & "'")
        If Interne_chk.Checked Then
            mRw = TblAgent.Select("Matricule='" & Evalue & "'")
        Else
            mRw = DATA_READER_GRD("select Matricule, Nom+' ' +Prenom as Nom, isnull(Lib_Poste,'') as Poste,'' as Entite
from CVTheque c
outer apply (select Lib_Poste from Org_Poste where Cod_Poste=c.Cod_Poste and id_Societe=c.id_Societe)p").Select()
        End If

        ps.PaperName = PaperKind.A4
        oReport.DefaultPageSettings.PaperSize = ps
        oReport = New Printing.PrintDocument
        oReport.DefaultPageSettings.PaperSize = New PaperSize("Custom2", 793, 1122)

        Dim dlg As New PrintPreviewDialog()
        dlg.WindowState = FormWindowState.Maximized
        dlg.Document = oReport
        dlg.ShowDialog()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS067", Evaluateur_txt, Me, String.Format(filtreUser, {"RH_Agent"}) & $" and exists(select * from Recrutement_Evaluateurs where Num_RC='{Num_RC_txt.Text}' and Matricule=RH_Agent.Matricule)")
            End If
        Else
            Appel_Zoom1("MS067", Evaluateur_txt, Me, $" exists(select * from Recrutement_Evaluateurs where Num_RC='{Num_RC_txt.Text}' and Matricule=RH_Agent.Matricule)")
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles oReport.PrintPage
        Dim Ht As Integer = 20
        Dim Wd As Integer = 20
        Dim Hlig As Integer = 20
        Dim obr As New Drawing.SolidBrush(Color.Black)
        Dim open As New Pen(obr)
        Dim _frm As New StringFormat
        Dim ofontS As New FontStyle
        _frm.Alignment = StringAlignment.Center
        ofontS = FontStyle.Bold
        If NumPage = 1 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(Wd, Ht, MaxW - 2 * Wd, Hlig * 3))
            e.Graphics.DrawRectangle(open, New Rectangle(Wd, Ht, MaxW - 2 * Wd, Hlig * 3))
            e.Graphics.DrawString(Lib_RC_txt.Text, New Font(oFontStr, 12), obr, New Rectangle(Wd, Ht + 20, MaxW - 2 * Wd, Hlig * 3), _frm)
            Ht += Hlig * 3 + 5
            e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(Wd, Ht, MaxW - 2 * Wd, Hlig))
            e.Graphics.DrawRectangle(open, New Rectangle(Wd, Ht, MaxW - 2 * Wd, Hlig))
            e.Graphics.DrawString("1/ Fiche signalétique", New Font(oFontStr, 8), obr, New Point(Wd, Ht + 2))
            Ht += Hlig + 3
            e.Graphics.DrawRectangle(open, New Rectangle(Wd, Ht, MaxW - 2 * Wd, 5 * Hlig))
            e.Graphics.DrawLine(open, CInt(MaxW / 2), Ht, CInt(MaxW / 2), Ht + 5 * Hlig)
            e.Graphics.DrawString("Evaluateur", New Font(oFontStr, 8, ofontS), obr, New Rectangle(Wd + 3, Ht + 3, (MaxW - 2 * Wd) / 2, Hlig))
            e.Graphics.DrawString("Candidat", New Font(oFontStr, 8, ofontS), obr, New Rectangle(MaxW / 2 + 3, Ht + 3, MaxW - 2 * Wd, Hlig))
            Ht += Hlig + 3
            e.Graphics.DrawString(eRw(0)("Matricule") & " : " & eRw(0)("Nom"), New Font(oFontStr, 8), obr, New Rectangle(Wd + 3, Ht + 3, (MaxW - 2 * Wd) / 2, Hlig))
            e.Graphics.DrawString(mRw(0)("Matricule") & " : " & mRw(0)("Nom"), New Font(oFontStr, 8), obr, New Rectangle(MaxW / 2 + 3, Ht + 3, MaxW - 2 * Wd, Hlig))
            Ht += Hlig + 3
            e.Graphics.DrawString(eRw(0)("Entite"), New Font(oFontStr, 8), obr, New Rectangle(Wd + 3, Ht + 3, (MaxW - 2 * Wd) / 2, Hlig))
            e.Graphics.DrawString(mRw(0)("Entite"), New Font(oFontStr, 8), obr, New Rectangle(MaxW / 2 + 3, Ht + 3, MaxW - 2 * Wd, Hlig))
            Ht += Hlig + 3
            e.Graphics.DrawString(eRw(0)("Poste"), New Font(oFontStr, 8), obr, New Rectangle(Wd + 3, Ht + 3, (MaxW - 2 * Wd) / 2, Hlig))
            e.Graphics.DrawString(mRw(0)("Poste"), New Font(oFontStr, 8), obr, New Rectangle(MaxW / 2 + 3, Ht + 3, MaxW - 2 * Wd, Hlig))
            Ht += Hlig + 3
        End If
        With pnl_Content
            For q = .Controls.Count - 1 To 0 Step -1
                If Not obj.Contains(q) Then
                    Dim x, y, h, w As Integer
                    Dim recF As New Rectangle
                    x = 0
                    y = 0
                    h = 0
                    w = 0
                    Select Case .Controls(q).GetType.Name
                        Case "ud_grille_cases"
                            _frm.LineAlignment = StringAlignment.Center
                            open.Color = Color.LightGray
                            With CType(.Controls(q), ud_grille_cases)
                                If Ht + .Grd.Location.Y + .Grd.Height + 20 < MaxH - FooterH - 5 Then
                                    For c = 0 To .Grd.ColumnCount - 1
                                        recF = .Grd.GetCellDisplayRectangle(c, -1, True)
                                        x = Wd + recF.Location.X + .Grd.Location.X + .Location.X
                                        y = recF.Location.Y + Ht + .Grd.Location.Y
                                        h = recF.Height
                                        w = recF.Width
                                        If c = 0 Then
                                            _frm.Alignment = StringAlignment.Near
                                        Else
                                            _frm.Alignment = StringAlignment.Center
                                        End If
                                        e.Graphics.DrawString(.Grd.Columns(c).HeaderText, New Font(oFontStr, 7, ofontS), obr, New Rectangle(x, y, w, h), _frm)
                                        e.Graphics.DrawLine(open, New Point(x + w + 2, y), New Point(x + w + 2, y + h))
                                    Next
                                    For r = 0 To .Grd.RowCount - 1
                                        For c = 0 To .Grd.ColumnCount - 1
                                            recF = .Grd.GetCellDisplayRectangle(c, r, True)
                                            x = Wd + recF.Location.X + .Grd.Location.X + .Location.X
                                            y = recF.Location.Y + Ht + .Grd.Location.Y
                                            h = recF.Height
                                            w = recF.Width
                                            If c = 0 Then
                                                _frm.Alignment = StringAlignment.Near
                                                e.Graphics.DrawString(.Grd.Item(c, r).Value, New Font(oFontStr, 7), obr, New Rectangle(x, y, w, h), _frm)
                                            ElseIf IsNull(.Grd.Item(c, r).Tag, False) Then
                                                e.Graphics.DrawImage(My.Resources.RadioButtonSel, New Point(x + w / 2 - 10, y + h / 2 - 10))
                                            Else
                                                e.Graphics.DrawImage(My.Resources.RadioButtonUnsel, New Point(x + w / 2 - 10, y + h / 2 - 10))
                                            End If
                                            e.Graphics.DrawLine(open, New Point(Wd, Ht), New Point(MaxW - 2 * Wd, Ht))
                                        Next
                                    Next
                                    Ht += .Grd.Location.Y + .Grd.Height + 20
                                    e.Graphics.DrawLine(open, New Point(Wd, Ht), New Point(MaxW - 2 * Wd, Ht))
                                Else
                                    GoTo suite
                                End If
                            End With
                        Case "ud_grille_choix"
                            _frm.LineAlignment = StringAlignment.Center
                            open.Color = Color.LightGray
                            With CType(.Controls(q), ud_grille_choix)
                                If Ht + .Grd.Location.Y + .Grd.Height + 20 < MaxH - FooterH - 5 Then
                                    For c = 0 To .Grd.ColumnCount - 1
                                        recF = .Grd.GetCellDisplayRectangle(c, -1, True)
                                        x = Wd + recF.Location.X + .Grd.Location.X + .Location.X
                                        y = recF.Location.Y + Ht + .Grd.Location.Y
                                        h = recF.Height
                                        w = recF.Width
                                        If c = 0 Then
                                            _frm.Alignment = StringAlignment.Near
                                        Else
                                            _frm.Alignment = StringAlignment.Center
                                        End If
                                        e.Graphics.DrawString(.Grd.Columns(c).HeaderText, New Font(oFontStr, 7, ofontS), obr, New Rectangle(x, y, w, h), _frm)
                                        e.Graphics.DrawLine(open, New Point(x + w + 2, y), New Point(x + w + 2, y + h))
                                    Next
                                    For r = 0 To .Grd.RowCount - 1
                                        For c = 0 To .Grd.ColumnCount - 1
                                            recF = .Grd.GetCellDisplayRectangle(c, r, True)
                                            x = Wd + recF.Location.X + .Grd.Location.X + .Location.X
                                            y = recF.Location.Y + Ht + .Grd.Location.Y
                                            h = recF.Height
                                            w = recF.Width
                                            If c = 0 Then
                                                _frm.Alignment = StringAlignment.Near
                                                e.Graphics.DrawString(.Grd.Item(c, r).Value, New Font(oFontStr, 7), obr, New Rectangle(x, y, w, h), _frm)
                                            ElseIf IsNull(.Grd.Item(c, r).Value, False) Then
                                                e.Graphics.DrawImage(My.Resources.check_1, New Point(x + w / 2 - 10, y + h / 2 - 10))
                                            Else
                                                e.Graphics.DrawImage(My.Resources.check_0, New Point(x + w / 2 - 10, y + h / 2 - 10))
                                            End If
                                        Next
                                    Next
                                    Ht += .Grd.Location.Y + .Grd.Height + 20
                                    e.Graphics.DrawLine(open, New Point(Wd, Ht), New Point(MaxW - 2 * Wd, Ht))
                                Else
                                    GoTo suite
                                End If
                            End With
                        Case "ud_valeur_unique"
                            _frm.LineAlignment = StringAlignment.Center
                            open.Color = Color.LightGray
                            With CType(.Controls(q), ud_valeur_unique)
                                If Ht + .Grd.Location.Y + .Grd.Height + 20 < MaxH - FooterH - 5 Then
                                    For r = 0 To .Grd.RowCount - 1
                                        For c = 0 To .Grd.ColumnCount - 1
                                            recF = .Grd.GetCellDisplayRectangle(c, r, True)
                                            x = Wd + recF.Location.X + .Grd.Location.X + .Location.X
                                            y = recF.Location.Y + Ht + .Grd.Location.Y
                                            h = recF.Height
                                            w = recF.Width
                                            If c = 0 Then
                                                _frm.Alignment = StringAlignment.Near
                                                e.Graphics.DrawString(.Grd.Item(c, r).Value, New Font(oFontStr, 7, ofontS), obr, New Rectangle(x, y, w, h), _frm)
                                            Else
                                                obr.Color = Color.LightGray
                                                e.Graphics.FillRectangle(obr, New Rectangle(x, y, w, h))
                                                obr.Color = Color.Black
                                                e.Graphics.DrawString(.Grd.Item(c, r).Value, New Font(oFontStr, 7), obr, New Rectangle(x, y, w, h), _frm)
                                            End If

                                        Next
                                    Next
                                    Ht += .Grd.Location.Y + .Grd.Height + 20
                                    e.Graphics.DrawLine(open, New Point(Wd, Ht), New Point(MaxW - 2 * Wd, Ht))
                                Else
                                    GoTo suite
                                End If
                            End With
                        Case "ud_paragraph"
                            open.Color = Color.LightGray
                            With CType(.Controls(q), ud_paragraph)
                                If Ht + .Txt.Location.Y + .Txt.Height + 20 < MaxH - FooterH - 5 Then
                                    x = Wd + .LaQuestion_lbl.Location.X + .Location.X
                                    y = .LaQuestion_lbl.Location.Y + Ht
                                    h = .LaQuestion_lbl.Height
                                    w = .LaQuestion_lbl.Width
                                    e.Graphics.DrawString(.LaQuestion_lbl.Text, .LaQuestion_lbl.Font, obr, x, y)
                                    x = Wd + .Txt.Location.X + .Location.X
                                    y = .Txt.Location.Y + Ht
                                    h = .Txt.Height
                                    w = MaxW - 2 * Wd - .Txt.Location.X
                                    e.Graphics.DrawRectangle(open, New Rectangle(x, y, w, h))
                                    obr.Color = Color.Black
                                    e.Graphics.DrawString(.Txt.Text, New Font(oFontStr, 7), obr, New Rectangle(x, y, w, h))
                                    Ht += .Txt.Location.Y + .Txt.Height + 20
                                    e.Graphics.DrawLine(open, New Point(Wd, Ht), New Point(MaxW - 2 * Wd, Ht))
                                Else
                                    GoTo suite
                                End If
                            End With
                        Case "ud_grille_libre"
                            _frm.LineAlignment = StringAlignment.Center
                            open.Color = Color.LightGray
                            With CType(.Controls(q), ud_grille_libre)
                                If Ht + .Grd.Location.Y + .Grd.Height + 20 < MaxH - FooterH - 5 Then
                                    x = Wd + .laquestion_lbl.Location.X + .Location.X
                                    y = .laquestion_lbl.Location.Y + Ht
                                    h = .laquestion_lbl.Height
                                    w = .laquestion_lbl.Width
                                    e.Graphics.DrawString(.laquestion_lbl.Text, .laquestion_lbl.Font, obr, x, y)

                                    For c = 0 To .Grd.ColumnCount - 1
                                        recF = .Grd.GetCellDisplayRectangle(c, -1, True)
                                        x = Wd + recF.Location.X + .Grd.Location.X + .Location.X
                                        y = recF.Location.Y + Ht + .Grd.Location.Y
                                        h = recF.Height
                                        w = recF.Width
                                        If c = 0 Then
                                            _frm.Alignment = StringAlignment.Near
                                        Else
                                            _frm.Alignment = StringAlignment.Center
                                        End If
                                        e.Graphics.DrawString(.Grd.Columns(c).HeaderText, New Font(oFontStr, 7, ofontS), obr, New Rectangle(x, y, w, h), _frm)
                                        e.Graphics.DrawLine(open, New Point(x + w + 2, y), New Point(x + w + 2, y + h))
                                    Next
                                    For r = 0 To .Grd.RowCount - 1
                                        For c = 0 To .Grd.ColumnCount - 1
                                            recF = .Grd.GetCellDisplayRectangle(c, r, True)
                                            x = Wd + recF.Location.X + .Grd.Location.X + .Location.X + 2
                                            y = recF.Location.Y + Ht + .Grd.Location.Y + 2
                                            h = recF.Height - 4
                                            w = recF.Width - 4
                                            Select Case True
                                                Case .Grd.Columns(c).GetType Is GetType(System.Windows.Forms.DataGridViewImageColumn)
                                                    If IsNull(.Grd.Item(c, r).Tag, False) Then
                                                        e.Graphics.DrawImage(My.Resources.RadioButtonSel, New Point(x + w / 2 - 10, y + h / 2 - 10))
                                                    Else
                                                        e.Graphics.DrawImage(My.Resources.RadioButtonUnsel, New Point(x + w / 2 - 10, y + h / 2 - 10))
                                                    End If
                                                Case .Grd.Columns(c).GetType Is GetType(System.Windows.Forms.DataGridViewCheckBoxColumn)
                                                    If IsNull(.Grd.Item(c, r).Value, False) Then
                                                        e.Graphics.DrawImage(My.Resources.check_1, New Point(x + w / 2 - 10, y + h / 2 - 10))
                                                    Else
                                                        e.Graphics.DrawImage(My.Resources.check_0, New Point(x + w / 2 - 10, y + h / 2 - 10))
                                                    End If
                                                Case .Grd.Columns(c).GetType Is GetType(DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn)
                                                    _frm.Alignment = StringAlignment.Far
                                                    e.Graphics.DrawString(.Grd.Item(c, r).Value, New Font(oFontStr, 7), obr, New Rectangle(x, y, w, h), _frm)
                                                Case .Grd.Columns(c).GetType Is GetType(DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn)
                                                    _frm.Alignment = StringAlignment.Far
                                                    e.Graphics.DrawString(.Grd.Item(c, r).Value, New Font(oFontStr, 7), obr, New Rectangle(x, y, w, h), _frm)
                                                Case .Grd.Columns(c).GetType Is GetType(DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn)
                                                    _frm.Alignment = StringAlignment.Center
                                                    e.Graphics.DrawString(.Grd.Item(c, r).Value, New Font(oFontStr, 7), obr, New Rectangle(x, y, w, h), _frm)
                                                Case Else
                                                    _frm.Alignment = StringAlignment.Near
                                                    e.Graphics.DrawString(.Grd.Item(c, r).Value, New Font(oFontStr, 7), obr, New Rectangle(x, y, w, h), _frm)
                                            End Select
                                        Next
                                    Next
                                    Ht += .Grd.Location.Y + .Grd.Height + 20
                                    e.Graphics.DrawLine(open, New Point(Wd, Ht), New Point(MaxW - 2 * Wd, Ht))
                                Else
                                    GoTo suite
                                End If
                            End With
                    End Select
                    obj.Add(q)
                End If
            Next
            e.Graphics.DrawLine(open, New Point(Wd, MaxH - FooterH), New Point(MaxW - 2 * Wd, MaxH - FooterH))
            _frm.Alignment = StringAlignment.Center
            _frm.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(NumPage, New Font(oFontStr, 7), obr, New Rectangle(Wd, MaxH - FooterH + 7, MaxW - 2 * Wd, 10), _frm)
            e.HasMorePages = False
            Return
suite:
            e.Graphics.DrawLine(open, New Point(Wd, MaxH - FooterH), New Point(MaxW - 2 * Wd, MaxH - FooterH))
            _frm.Alignment = StringAlignment.Center
            _frm.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(NumPage, New Font(oFontStr, 7), obr, New Rectangle(Wd, MaxH - FooterH + 7, MaxW - 2 * Wd, 10), _frm)
            NumPage += 1
            Ht = 10
            e.HasMorePages = True
            Return
        End With
    End Sub
    Private Sub oReport_BeginPrint(sender As Object, e As PrintEventArgs) Handles oReport.BeginPrint
        obj.Clear()
        NumPage = 1
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS164", Evalue_txt, Me, $"Num_RC='{Num_RC_txt.Text}'")
    End Sub
    Private Sub Num_RC_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_RC_txt.TextChanged
        Lib_RC_txt.Text = FindLibelle("Lib_RC", "Num_RC", Num_RC_txt.Text, "Recrutement")
        TblCandidats = DATA_READER_GRD($"select * from Recrutement_Candidats where Num_RC='{Num_RC_txt.Text}'")
        TblEvaluateurs = DATA_READER_GRD($"select * from Recrutement_Evaluateurs where Num_RC='{Num_RC_txt.Text}'")
        If TblCandidats.Select($"Matricule='{Evalue_txt.Text}'").Length = 0 Then Evalue_txt.Text = ""
        If TblEvaluateurs.Select($"Matricule='{Evaluateur_txt.Text}'").Length = 0 Then Evaluateur_txt.Text = ""
        Request()
    End Sub

    Private Sub Cv_btn_Load(sender As Object, e As EventArgs) Handles Cv_btn.Load

    End Sub

    Private Sub Entretien_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dat_Survey.MaxDate = CDate(Now.AddDays(1).ToShortDateString)
    End Sub
    Private Sub Evaluateur_txt_TextChanged(sender As Object, e As EventArgs) Handles Evaluateur_txt.TextChanged
        Nom_Evaluateur_txt.Text = FindLibelle("Nom_Agent+' '+Prenom_Agent", "Matricule", Evaluateur_txt.Text, "RH_Agent")
        Request()
    End Sub

    Private Sub Evalue_txt_TextChanged(sender As Object, e As EventArgs) Handles Evalue_txt.TextChanged
        Dim nrw() = TblCandidats.Select($"Matricule='{Evalue_txt.Text}'")
        If nrw.Length = 0 Then
            Nom_Evalue_txt.Text = ""
            Interne_chk.Checked = False
        Else
            Interne_chk.Checked = IsNull(nrw(0)("Interne"), False)
            If Interne_chk.Checked Then
                Nom_Evalue_txt.Text = FindLibelle("Nom_Agent+' '+Prenom_Agent", "Matricule", Evalue_txt.Text, "RH_Agent")
                Cv_btn.Enabled = False
            Else
                Nom_Evalue_txt.Text = FindLibelle("Nom+' '+Prenom", "Matricule", Evalue_txt.Text, "CVtheque")
                Cv_btn.Enabled = True
            End If
        End If
        Request()
    End Sub

    Private Sub RC_btn_Click(sender As Object, e As EventArgs) Handles RC_btn.Click
        If Num_RC_txt.Text = "" Then Return
        Dim f As New Recrutement
        With f
            .Num_RC_txt.Text = Num_RC_txt.Text
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Cv_btn_Click(sender As Object, e As EventArgs) Handles Cv_btn.Click
        If Evalue_txt.Text = "" Then Return
        If Interne_chk.Checked Then Return
        Dim f As New CVTheque
        With f
            .Matricule_Text.Text = Evalue_txt.Text
            newShowEcran(f, True)
        End With
    End Sub

#End Region

    Private Sub Entretien_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
End Class
