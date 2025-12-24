Imports System.Reflection
Imports System.Text.RegularExpressions
Public Class ud_grille_libre
    Dim colDic As New Dictionary(Of Integer, String)
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
        Grd.EditMode = DataGridViewEditMode.EditOnEnter
        Me.AutoSize = True
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        ResumeLayout(True)
    End Sub
    Overrides Sub Chargement()
        SuspendLayout()
        Num_Question_lbl.Text = numQuestion
        Dim rgxE As New Regex("\[[COEDNT]\]", RegexOptions.IgnoreCase)
        Dim col() As String = colonnes.Split(";")
        Dim oH As Integer = 0
        Dim oW As Integer = 0
        For i = 0 To col.Length - 1
            If col(i).Trim <> "" Then
                If rgxE.IsMatch(col(i).Trim) Then
                    For Each c As Match In rgxE.Matches(col(i).Trim)
                        Dim rep As New Object
                        Select Case c.Value
                            Case "[C]"
                                rep = New System.Windows.Forms.DataGridViewImageColumn
                                rep.DefaultCellStyle.NullValue = My.Resources.RadioButtonUnsel
                                rep.ReadOnly = True
                            Case "[O]"
                                rep = New System.Windows.Forms.DataGridViewCheckBoxColumn
                            Case "[E]"
                                rep = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
                                With rep
                                    .BackgroundStyle.Class = "DataGridViewNumericBorder"
                                    .BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                End With
                            Case "[D]"
                                rep = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
                                With rep
                                    .BackgroundStyle.Class = "DataGridViewDateTimeBorder"
                                    .BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                                    .Format = DevComponents.Editors.eDateTimePickerFormat.Custom
                                    .CustomFormat = "dd/MM/yyyy"
                                    .HeaderText = ""
                                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                End With
                            Case "[N]"
                                rep = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
                                With rep
                                    .BackgroundStyle.Class = "DataGridViewNumericBorder"
                                    .BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                    .Increment = 1.0R
                                End With
                            Case Else
                                rep = New System.Windows.Forms.DataGridViewTextBoxColumn
                                With CType(rep, System.Windows.Forms.DataGridViewTextBoxColumn)
                                    .MinimumWidth = 200
                                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                                    .MaxInputLength = 250
                                End With
                        End Select
                        With rep
                            .HeaderText = col(i).Trim.Replace(c.Value, "").Trim
                            .Name = "R" & i
                            .Width = 60
                        End With
                        Grd.Columns.Add(rep)
                        oW += rep.Width + 8
                        colDic.Add(Grd.ColumnCount - 1, c.Value)
                        Exit For
                    Next
                    DefaultRep &= " ;"
                End If
            End If
        Next
        oH = Grd.ColumnHeadersHeight
        For i = 0 To nbLig - 1
            Grd.Rows.Add("")
            If Not repDic.ContainsKey(CStr(i)) Then
                repDic.Add(CStr(i), DefaultRep)
            End If
            oH += Grd.Rows(i).Height + 8
        Next
        For i = 0 To nbLig - 1
            For j = 0 To Grd.ColumnCount - 1
                Select Case colDic(j)
                    Case "[C]"
                        Grd.Item(j, i).Tag = (repDic(CStr(i)).Split(";")(j).Trim = "1")
                        Grd.Item(j, i).Value = IIf(CBool(Grd.Item(j, i).Tag), My.Resources.RadioButtonSel, My.Resources.RadioButtonUnsel)
                    Case "[O]"
                        Grd.Item(j, i).Value = (repDic(CStr(i)).Split(";")(j).Trim = "1")
                        Grd.Item(j, i).Tag = Grd.Item(j, i).Value
                    Case "[E]"
                        Dim vl As Object = repDic(CStr(i)).Split(";")(j).Trim
                        Grd.Item(j, i).Value = (IIf(EstEntier(vl), ConvertEntier(vl), 0))
                        Grd.Item(j, i).Tag = Grd.Item(j, i).Value
                    Case "[D]"
                        Dim vl As Object = repDic(CStr(i)).Split(";")(j).Trim
                        Grd.Item(j, i).Value = (IIf(EstDate(vl), ConvertDate(vl), Nothing))
                        Grd.Item(j, i).Tag = Grd.Item(j, i).Value
                    Case "[N]"
                        Dim vl As Object = repDic(CStr(i)).Split(";")(j).Trim
                        Grd.Item(j, i).Value = (IIf(IsNumeric(vl), ConvertNombre(vl), 0))
                        Grd.Item(j, i).Tag = Grd.Item(j, i).Value
                    Case Else
                        Grd.Item(j, i).Value = repDic(CStr(i)).Split(";")(j).Trim
                        Grd.Item(j, i).Tag = Grd.Item(j, i).Value
                End Select
            Next
        Next
        laquestion_lbl.Text = laquestion & IIf(Obligatoire, " (*)", "")
        laquestion_lbl.Refresh()

        Grd.Height = oH + 10
        tblPnl.Height = oH + 90
        Me.Height = oH + 93
        If Grd.ColumnCount > 0 Then
            Grd.Columns(0).MinimumWidth = 400
        End If
        ResumeLayout(True)
        If modeScoring = "manuel" Then note_txt.Text = noteManuelle
        Saving()
    End Sub
    Private Sub Grd_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellClick
        With Grd()
            If .RowCount <= 0 Then Return
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim r As Integer = e.RowIndex
                Dim c As Integer = e.ColumnIndex
                If colDic(c) = "[C]" Then
                    Grd.Item(c, r).Tag = True
                    Grd.Item(c, r).Value = My.Resources.RadioButtonSel
                    For j = 0 To .ColumnCount - 1
                        If j <> c And colDic(j) = "[C]" Then
                            .Item(j, r).Value = My.Resources.RadioButtonUnsel
                            .Item(j, r).Tag = False
                        End If
                    Next
                End If
            End If
        End With

    End Sub

    Private Sub Grd_SelectionChanged(sender As Object, e As EventArgs) Handles Grd.SelectionChanged
        Grd.ClearSelection()
    End Sub
    Overrides Sub CalculNote()
        With Grd
            Dim laNote As Double = If(modeScoring = "manuel" And IsNumeric(note_txt.Text), CDbl(note_txt.Text), 0)
            Dim note_totale As Double = 0
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
        With Grd()
            Dim rep As String = ""
            For r = 0 To .RowCount - 1
                rep = ""
                For j = 0 To .ColumnCount - 1
                    If colDic(j) = "[C]" Then
                        rep &= IIf(CBool(IsNull(.Item(j, r).Tag, False)), 1, 0) & ";"
                    ElseIf colDic(j) = "[O]" Then
                        rep &= IIf(CBool(IsNull(.Item(j, r).Value, False)), 1, 0) & ";"
                    ElseIf colDic(j) = "[E]" Then
                        rep &= IIf(EstEntier(.Item(j, r).Value), CInt(ConvertEntier(.Item(j, r).Value)), 0) & ";"
                    ElseIf colDic(j) = "[N]" Then
                        rep &= IIf(IsNumeric(.Item(j, r).Value), CDbl(ConvertNombre(.Item(j, r).Value)), 0) & ";"
                    Else
                        rep &= IsNull(.Item(j, r).Value, "") & ";"
                    End If
                Next
                repDic(CStr(r)) = rep
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
    Private Function Canon(colMark As String, v As Object) As Object
        Select Case colMark
            Case "[E]" : Return If(EstEntier(v), ConvertEntier(v), 0)          ' Integer
            Case "[N]" : Return If(IsNumeric(v), CDbl(ConvertNombre(v)), 0D)    ' Double
            Case "[D]" : Return If(EstDate(v), ConvertDate(v), Nothing)         ' Date?
            Case "[O]" : Return If(v IsNot Nothing AndAlso TypeOf v Is Boolean, CBool(v), False)
            Case "[C]" : Return If(v IsNot Nothing AndAlso TypeOf v Is Boolean, CBool(v), False)
            Case Else : Return CStr(IsNull(v, ""))                              ' Texte
        End Select
    End Function

    Private Sub Grd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
    Handles Grd.CellValueChanged
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub
        Dim mark = colDic(e.ColumnIndex)
        If mark = "[C]" Then Exit Sub  ' géré par CellClick

        Dim v = Grd.Item(e.ColumnIndex, e.RowIndex).Value
        Grd.Item(e.ColumnIndex, e.RowIndex).Tag = Canon(mark, v)
        Saving()
    End Sub
    Private Sub Grd_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellLeave
        Grd.EndEdit(True)
    End Sub
    Private Sub Grd_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) _
    Handles Grd.CurrentCellDirtyStateChanged
        If Grd.IsCurrentCellDirty Then
            Grd.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Grd.EndEdit()
        End If
    End Sub

    ' Certaines cases à cocher déclenchent CellContentClick plutôt que DirtyState
    Private Sub Grd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles Grd.CellContentClick
        Grd.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Grd.EndEdit()
    End Sub

    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd.DataError

    End Sub
End Class
