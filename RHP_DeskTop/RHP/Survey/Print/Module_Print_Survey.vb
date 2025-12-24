
Imports System.Drawing.Printing
Module Module_Print_Survey
    Dim formGraphics As System.Drawing.Graphics
    Friend WithEvents oReport As New Printing.PrintDocument
    Dim NumPage As Integer = 1
    Dim NouvellePage As Boolean = False
    Dim MaxH As Integer = 1122
    Dim MaxW As Integer = 793
    Dim FooterH As Integer = 80
    Dim oHeight As Integer = 0
    Dim ps As New PaperSize("A4", MaxW, MaxH)
    Dim Replies() As Integer = Nothing
    Dim Tbl As New DataTable
    Dim Tbl_Question, Tbl_Reponse As New DataTable
    Dim oFontStr As String = "Century Gothic"
    Dim Evaluateur As String = ""
    Dim Evalue As String = ""
    Dim QuestionTraitees As New ArrayList
    Sub Apercu(CodSurvey As String, CodReply() As Integer)
        If CodReply.Length = 0 Then Return
        Replies = CodReply
        Dim swhere As String = String.Join(",", Replies)
        If swhere = "" Then Return
        Dim CodSql As String = "select e.Cod_Reply , e.Cod_Survey , Evaluateur,Nom_Evaluateur,Poste_Evaluateur,Entite_Evaluateur,Grade_Evaluateur,
 Evalue,Nom_Evalue,Poste_Evalue,Entite_Evalue,Grade_Evalue,Ref_Evaluation as Cod_Evaluation,Lib_Evaluation, 
 Cod_Question, Question,Typ_Reponse,q.Sous_Question, Reponses_Possibles, Num_Sous_Question , Reponses  , qRang 
from Survey_Reply e left join Survey_Reply_Detail d on e.Cod_Reply =d.Cod_Reply
outer apply (select Nom as 'Nom_Evaluateur', Poste as 'Poste_Evaluateur', Entite as 'Entite_Evaluateur',Grade as 'Grade_Evaluateur' 
			from Sys_RH_Preparation_Paie_Agent p where id_Societe =e.id_Societe and Evaluateur =Matricule )h
outer apply (select Nom as 'Nom_Evalue', Poste as 'Poste_Evalue', Entite as 'Entite_Evalue',Grade as 'Grade_Evalue' 
			from Sys_RH_Preparation_Paie_Agent p where id_Societe =e.id_Societe and Evalue =Matricule )s
outer apply(select Description as Lib_Evaluation from Evaluation where id_Societe = e.id_Societe and Cod_Evaluation=Ref_Evaluation)v
outer apply(select Sous_Question, Reponses_Possibles, Rang as qRang  from Survey_Detail  where id_Societe = e.id_Societe and Cod_Question =RowId)q
where e.Cod_Reply in (" & swhere & ") and Typ_Evalue ='E' and e.Cod_Survey='" & CodSurvey & "' and id_Societe=" & Societe.id_Societe
        Tbl = DATA_READER_GRD(CodSql)

        Dim Dv As DataView = Tbl.DefaultView.ToTable(True, "Cod_Survey", "Evaluateur", "Evalue", "Typ_Reponse", "Cod_Question", "Question", "Sous_Question", "Reponses_Possibles", "qRang").DefaultView
        Dv.Sort = "Evaluateur  ASC, Evalue  ASC, qRang ASC"
        Tbl_Question = Dv.ToTable
        Tbl_Reponse = Tbl.DefaultView.ToTable(True, "Cod_Reply", "Cod_Question", "Num_Sous_Question", "Reponses")
        ps.PaperName = PaperKind.A4
        oReport.DefaultPageSettings.PaperSize = ps
        oReport = New Printing.PrintDocument
        oReport.DefaultPageSettings.PaperSize = New PaperSize("Custom2", 793, 1122)
        Dim dlg As New PrintPreviewDialog()
        dlg.WindowState = FormWindowState.Maximized
        CType(dlg.Controls(1), ToolStrip).Items(0).Visible = False
        dlg.Document = oReport
        dlg.ShowDialog()

    End Sub

    Private Sub ImpressionDirecte(CodReply() As Integer)
        ps.PaperName = PaperKind.A4
        oReport.DefaultPageSettings.PaperSize = ps
        Dim PrintDialog1 As New PrintDialog()
        PrintDialog1.Document = oReport
        Dim result As DialogResult = PrintDialog1.ShowDialog

        If (result = DialogResult.OK) Then
            oReport.Print()
        End If
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles oReport.PrintPage
        Dim Ht As Integer = 10
        Dim Wd As Integer = 10
        Dim Hlig As Integer = 20
        Dim orw() As DataRow = Tbl.Select("Cod_Reply=" & Replies(0))
        If orw.Length = 0 Then Return
        Dim fin As Boolean = False

        Dim obr As New Drawing.SolidBrush(Color.Black)
        Dim open As New Pen(obr)
        Dim _frm As New StringFormat
        Dim ofontS As New FontStyle
        _frm.Alignment = StringAlignment.Center
        ofontS = FontStyle.Bold
        If Evaluateur <> orw(0)("Evaluateur") Or Evalue <> orw(0)("Evalue") Then
            QuestionTraitees.Clear()
            Evaluateur = orw(0)("Evaluateur")
            Evalue = orw(0)("Evalue")
            e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(Wd, Ht, MaxW - 2 * Wd, Hlig * 3))
            e.Graphics.DrawRectangle(open, New Rectangle(Wd, Ht, MaxW - 2 * Wd, Hlig * 3))
            e.Graphics.DrawString(orw(0)("Lib_Evaluation"), New Font(oFontStr, 12), obr, New Rectangle(Wd, Ht + 20, MaxW - 2 * Wd, Hlig * 3), _frm)
            Ht += Hlig * 3 + 5
            e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(Wd, Ht, MaxW - 2 * Wd, Hlig))
            e.Graphics.DrawRectangle(open, New Rectangle(Wd, Ht, MaxW - 2 * Wd, Hlig))
            e.Graphics.DrawString("1/ Fiche signalétique", New Font(oFontStr, 8), obr, New Point(Wd, Ht + 2))
            Ht += Hlig + 3
            e.Graphics.DrawRectangle(open, New Rectangle(Wd, Ht, MaxW - 2 * Wd, 5 * Hlig))
            e.Graphics.DrawLine(open, CInt(MaxW / 2), Ht, CInt(MaxW / 2), Ht + 5 * Hlig)
            e.Graphics.DrawString("Identificateur du Manager", New Font(oFontStr, 8, ofontS), obr, New Rectangle(Wd + 3, Ht + 3, (MaxW - 2 * Wd) / 2, Hlig))
            e.Graphics.DrawString("Identificateur du Collaborateur", New Font(oFontStr, 8, ofontS), obr, New Rectangle(MaxW / 2 + 3, Ht + 3, MaxW - 2 * Wd, Hlig))
            Ht += Hlig + 3
            e.Graphics.DrawString(orw(0)("Evaluateur") & " : " & orw(0)("Nom_Evaluateur"), New Font(oFontStr, 8), obr, New Rectangle(Wd + 3, Ht + 3, (MaxW - 2 * Wd) / 2, Hlig))
            e.Graphics.DrawString(orw(0)("Evalue") & " : " & orw(0)("Nom_Evalue"), New Font(oFontStr, 8), obr, New Rectangle(MaxW / 2 + 3, Ht + 3, MaxW - 2 * Wd, Hlig))
            Ht += Hlig + 3
            e.Graphics.DrawString(orw(0)("Entite_Evaluateur"), New Font(oFontStr, 8), obr, New Rectangle(Wd + 3, Ht + 3, (MaxW - 2 * Wd) / 2, Hlig))
            e.Graphics.DrawString(orw(0)("Entite_Evalue"), New Font(oFontStr, 8), obr, New Rectangle(MaxW / 2 + 3, Ht + 3, MaxW - 2 * Wd, Hlig))
            Ht += Hlig + 3
            e.Graphics.DrawString(orw(0)("Fonction_Evaluateur"), New Font(oFontStr, 8), obr, New Rectangle(Wd + 3, Ht + 3, (MaxW - 2 * Wd) / 2, Hlig))
            e.Graphics.DrawString(orw(0)("Fonction_Evalue"), New Font(oFontStr, 8), obr, New Rectangle(MaxW / 2 + 3, Ht + 3, MaxW - 2 * Wd, Hlig))
            Ht += Hlig + 3
        End If
        With Tbl_Question
            For i = 0 To .Rows.Count - 1
                If Not QuestionTraitees.Contains(.Rows(i)("Cod_Question")) Then
                    Dim colonnes As String = .Rows(i)("Reponses_Possibles")
                    Dim lignes As String = .Rows(i)("Sous_Question")
                    Dim repDic As New Dictionary(Of String, String)
                    Dim nrw() As DataRow = Tbl_Reponse.Select("Cod_Reply=" & Replies(0) & " and Cod_Question=" & .Rows(i)("Cod_Question"))
                    Dim x, y, h, w As Integer
                    Dim recF As New Rectangle
                    x = 0
                    y = 0
                    h = 0
                    w = 0

                    Select Case .Rows(i)("Typ_Reponse")
                        Case "grille_cases", "cocher", "oui_non", "vrai_faux", "echelle"
                            For j = 0 To nrw.Length - 1
                                repDic.Add(nrw(j)("Num_Sous_Question"), nrw(j)("Reponses"))
                            Next
                            If lignes.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Length > 0 And colonnes.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Length > 0 Then
                                Dim ud As New ud_grille_cases
                                With ud
                                    .repDic = repDic
                                    .Name = Tbl_Question.Rows(i)("Cod_Question")
                                    .Text = Tbl_Question.Rows(i)("Question")
                                    .lignes = lignes
                                    .colonnes = colonnes
                                    .laquestion = IIf(Tbl_Question.Rows(i)("Question") = lignes, "", Tbl_Question.Rows(i)("Question"))
                                    .Chargement()
                                    .Dock = DockStyle.Top
                                    If Ht + .Height < MaxH + FooterH Then
                                        For c = 0 To .Grd.ColumnCount - 1
                                            recF = .Grd.GetCellDisplayRectangle(c, -1, True)
                                            x = recF.Location.X + .Grd.Location.X + .Location.X
                                            y = recF.Location.Y + Ht + .Grd.Location.Y + .Location.Y
                                            h = recF.Height
                                            w = recF.Width
                                            e.Graphics.DrawString(.Grd.Columns(c).HeaderText, .Grd.Columns(c).DefaultCellStyle.Font, obr, New Rectangle(x, y, w, h))
                                            e.Graphics.DrawLine(open, New Point(x + w + 2, y), New Point(x + w + 2, y + h))
                                        Next
                                    End If
                                End With
                            End If
                    End Select
                End If
            Next
        End With





        Dim tmp As List(Of Integer) = Replies.ToList
        tmp.Remove(Replies(0))
        Replies = tmp.ToArray
        If Evaluateur <> orw(0)("Evaluateur") Or Evalue <> orw(0)("Evalue") Then
            e.HasMorePages = True
        ElseIf Replies.Length > 0 And fin Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub
    Private Sub oReport_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles oReport.QueryPageSettings
        With oReport
            If 1 = 2 Then
                e.PageSettings.Landscape = True
            Else
                e.PageSettings.Landscape = False
            End If

        End With

    End Sub
End Module
