Imports System.Reflection

Public Class ud_grille_choix
    Private Sub ud_grille_cases_Load(sender As Object, e As EventArgs) Handles Me.Load
        SuspendLayout()

        If avecNote And modeScoring <> "na" Then
            coef_txt.Text = Math.Round(coef, 2)
            If modeScoring <> "manuel" Then
                With note_txt
                    .ReadOnly = True
                    .TabStop = False
                    AddHandler .GotFocus, Sub() Me.ActiveControl = Nothing
                    .BackColor = Me.BackColor
                    .ForeColor = colorBase01
                End With
            Else
                With note_txt
                    .ReadOnly = False
                    .BackColor = System.Drawing.SystemColors.Control
                    .Font = New Font(.Font, FontStyle.Underline)
                    AddHandler .KeyPress, Sub(_sender As Object, _e As KeyPressEventArgs)
                                              ControleSaisie(_sender, _e, True, False, True, False, False)
                                              Saving()
                                          End Sub
                    AddHandler .Validated, Sub(_sender As Object, _e As EventArgs)
                                               If Not IsNumeric(.Text) Then .Text = 0
                                               If CDbl(.Text) > maxScore Then .Text = maxScore
                                               Saving()
                                           End Sub
                End With
            End If
        Else
            pnl_note.Visible = False
        End If
        Grd.EditMode = DataGridViewEditMode.EditProgrammatically
        Me.AutoSize = True
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        ResumeLayout(True)
    End Sub
    Overrides Sub Chargement()
        SuspendLayout()
        Num_Question_lbl.Text = numQuestion
        Dim col() As String = colonnes.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        Dim lig() As String = lignes.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        Dim oH As Integer = 0
        Dim oW As Integer = Grd.Columns(0).Width
        Dim nbCol As Integer = 0
        Dim maxWidth As Integer = 0
        For i = 0 To col.Length - 1
            If col(i).Trim <> "" Then
                Dim rep As New System.Windows.Forms.DataGridViewImageColumn
                With rep
                    .HeaderText = col(i).Trim
                    .Name = "R" & i
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .ReadOnly = True
                    .DefaultCellStyle.NullValue = My.Resources.btn_check_off
                End With
                Grd.Columns.Add(rep)
                maxWidth = Math.Max(rep.Width, maxWidth)
                oW += rep.Width + 8
            End If
        Next

        With Grd
            maxWidth = Math.Min(maxWidth, 60)
            If .ColumnCount > 1 Then
                For i = 1 To .ColumnCount - 1
                    .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Columns(i).Width = maxWidth
                Next
            End If
        End With
        oH = Grd.ColumnHeadersHeight
        nbCol = Grd.ColumnCount
        For i = 0 To lig.Length - 1
            If lig(i).Trim <> "" Then
                If Not repDic.ContainsKey(CStr(i)) Then
                    repDic.Add(CStr(i), Gauche(String.Join("", Enumerable.Repeat("0;", (nbCol - 1))), (nbCol - 1) * 2 - 1))
                End If
                Grd.Rows.Add("")
                Grd.Item(0, i).Value = lig(i) & IIf(Obligatoire And (laquestion.Trim = ""), " (*)", "")
                For j = 1 To Grd.ColumnCount - 1
                    Grd.Item(j, i).Value = IIf(repDic(CStr(i)).Split({";"}, StringSplitOptions.RemoveEmptyEntries)(j - 1).Trim = "1", My.Resources.btn_check_on, My.Resources.btn_check_off)
                    Grd.Item(j, i).Tag = (repDic(CStr(i)).Split({";"}, StringSplitOptions.RemoveEmptyEntries)(j - 1).Trim = "1")
                Next
                oH += Grd.Rows(i).Height + 8
            End If

        Next
        Grd.Columns(0).HeaderText = If(Typ_Reponse = "choix", "", laquestion & IIf(Obligatoire And (laquestion.Trim <> ""), " (*)", ""))

        Grd.Height = oH + 10
        tblPnl.Height = oH + 30
        Me.Height = oH + 30
        ResumeLayout(True)
        If modeScoring = "manuel" Then note_txt.Text = noteManuelle
        Saving()
    End Sub
    Private Sub Grd_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellClick
        With Grd
            If .RowCount <= 0 Then Return
            If e.RowIndex >= 0 And e.ColumnIndex >= 1 Then
                If .CurrentCell.Tag = False Then
                    .CurrentCell.Value = My.Resources.btn_check_on
                    .CurrentCell.Tag = True
                    .Item(0, e.RowIndex).Tag = e.ColumnIndex
                Else
                    .Item(e.ColumnIndex, e.RowIndex).Value = My.Resources.btn_check_off
                    .Item(e.ColumnIndex, e.RowIndex).Tag = False
                End If
            End If
            Saving()
        End With
    End Sub
    Private Sub Grd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellContentClick
        '  Certains clics sur l'image déclenchent CellContentClick plutôt que CellClick
        '  Grd_CellClick(sender, e)
    End Sub
    Overrides Sub CalculNote()
        With Grd
            Dim laNote As Double = 0
            Dim note_totale As Double = 0
            For i = 0 To .RowCount - 1
                For j = 1 To .ColumnCount - 1
                    If CBool(.Item(j, i).Tag) Then
                        laNote += j + 1
                        Exit For
                    End If
                Next
            Next
            laNote = Math.Round(laNote / Math.Max(1, .RowCount), 2)
            If funcScoring <> "" Then
                Dim noteFunc = Module_Generateur_Survey.myVBS.Eval($"Func_Survey_{codQuestion}({laNote})")
                If IsNumeric(noteFunc) Then laNote = Math.Round(CDbl(noteFunc), 2)
            End If
            note_txt.Text = laNote
            note_totale = Math.Round(If(IsNumeric(coef), coef * laNote, laNote), 2)
            note_totale_txt.Text = note_totale
            noteDic.Clear()
            noteDic.Add("note", laNote)
            noteDic.Add("coef", coef)
            noteDic.Add("note_totale", note_totale)
        End With
    End Sub
    Overrides Sub Saving()
        CalculNote()
        With Grd
            Dim rep As String = ""
            For i = 0 To .RowCount - 1
                rep = ""
                For j = 1 To .ColumnCount - 1
                    Dim sel As Boolean = False
                    If .Item(j, i).Tag IsNot Nothing AndAlso TypeOf .Item(j, i).Tag Is Boolean Then
                        sel = CBool(.Item(j, i).Tag)
                    End If
                    rep &= If(rep = "", "", ";") & If(sel, 1, 0)
                Next
                repDic(CStr(i)) = rep
            Next
            Dim frm = Me.FindForm()
            If frm IsNot Nothing Then
                ' Chercher une méthode Recalcul, publique ou Friend
                Dim m = frm.GetType().GetMethod("Recalcul",
                                                BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                If m IsNot Nothing Then
                    m.Invoke(frm, Nothing)
                End If
            End If
        End With
    End Sub
    Private Sub Grd_SelectionChanged(sender As Object, e As EventArgs) Handles Grd.SelectionChanged
        Grd.ClearSelection()
    End Sub
    Private Sub ud_grille_cases_Leave(sender As Object, e As EventArgs) Handles Me.Leave, Grd.Leave
        Saving()
    End Sub

    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd.DataError

    End Sub
End Class