Imports System.Drawing.Printing
Module Module_Print_Evalutaion
    Dim f As New Evaluation
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
    Dim obj As New ArrayList
    Sub OldImprimerEvaluation(CodEvaluation As String, Evaluateur As String, Evalue As String)
        NumPage = 1
        obj.Clear()
        f = New Evaluation
        Dim TblAgent As DataTable = DATA_READER_GRD("select * from Sys_RH_Preparation_Paie_Agent where Matricule in ('" & Evaluateur & "','" & Evalue & "') and id_Societe=" & Societe.id_Societe)
        eRw = TblAgent.Select("Matricule='" & Evaluateur & "'")
        mRw = TblAgent.Select("Matricule='" & Evalue & "'")
        f.Cod_Evaluation_txt.Text = CodEvaluation
        f.Lib_Evaluation_txt.Text = FindLibelle("Description", "Cod_Evaluation", CodEvaluation, "Evaluation")
        f.Evaluateur_txt.Text = Evaluateur
        f.Nom_Evaluateur_txt.Text = eRw(0)("Nom")
        f.Evalue_txt.Text = Evalue
        f.Nom_Evalue_txt.Text = mRw(0)("Nom")
        f.Request()
        f.Location = New Point(-1000, -1000)
        f.SendToBack()
        f.WindowState = FormWindowState.Normal
        f.Show()
        ps.PaperName = PaperKind.A4
        oReport.DefaultPageSettings.PaperSize = ps
        oReport = New Printing.PrintDocument
        oReport.DefaultPageSettings.PaperSize = New PaperSize("Custom2", 793, 1122)

        Dim dlg As New PrintPreviewDialog()
        dlg.WindowState = FormWindowState.Maximized
        AddHandler dlg.FormClosing, AddressOf fermer
        '  CType(dlg.Controls(1), ToolStrip).Items(0).Visible = False
        dlg.Document = oReport
        dlg.ShowDialog()
    End Sub
    Sub fermer()
        f.close
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
            e.Graphics.DrawString(f.Lib_Evaluation_txt.Text, New Font(oFontStr, 12), obr, New Rectangle(Wd, Ht + 20, MaxW - 2 * Wd, Hlig * 3), _frm)
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
        With f.pnl_Content
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
                                            '   
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
                                            '   
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
                                            '   
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
End Module
