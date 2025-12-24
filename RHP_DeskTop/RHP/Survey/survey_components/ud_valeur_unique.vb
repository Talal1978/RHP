Imports System.Reflection

Public Class ud_valeur_unique
    Private Sub ud_grille_cases_Load(sender As Object, e As EventArgs) Handles Me.Load
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
    End Sub
    Overrides Sub Chargement()
        RemoveHandler Grd.CellValueChanged, AddressOf Grd_CellValueChanged
        Me.SuspendLayout()
        Grd.SuspendLayout()

        Dim oH As Integer = 0
        Dim oW As Integer = 0
        Num_Question_lbl.Text = numQuestion
        Select Case Typ_Reponse
            Case "numerique"
                Dim col As New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
                With col
                    .BackgroundStyle.Class = "DataGridViewNumericBorder"
                    .BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Increment = 1.0R
                    .MinimumWidth = 100
                End With
                Grd.Columns.Add(col)
            Case "entier"
                Dim col As New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
                With col
                    .BackgroundStyle.Class = "DataGridViewNumericBorder"
                    .BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .MinimumWidth = 100
                End With
                Grd.Columns.Add(col)
            Case "dateTime"
                Dim col As New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
                With col
                    .BackgroundStyle.Class = "DataGridViewDateTimeBorder"
                    .BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                    .Format = DevComponents.Editors.eDateTimePickerFormat.Custom
                    .CustomFormat = "dd/MM/yyyy HH:mm"
                    .HeaderText = ""
                    .MinimumWidth = 150
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                Grd.Columns.Add(col)
            Case "date"
                Dim col As New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
                With col
                    .BackgroundStyle.Class = "DataGridViewDateTimeBorder"
                    .BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                    .Format = DevComponents.Editors.eDateTimePickerFormat.Custom
                    .CustomFormat = "dd/MM/yyyy"
                    .MinimumWidth = 70
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                Grd.Columns.Add(col)
            Case "heure"
                Dim col As New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
                With col
                    .BackgroundStyle.Class = "DataGridViewDateTimeBorder"
                    .BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
                    .Format = DevComponents.Editors.eDateTimePickerFormat.Custom
                    .CustomFormat = "HH:mm"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderText = ""
                    .MinimumWidth = 70
                End With
                Grd.Columns.Add(col)
            Case "alpha"
                Dim col As New DataGridViewTextBoxColumn
                With col
                    .MinimumWidth = 300
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    .Width = Me.Width - Grd.Columns(0).Width - 6
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    .MaxInputLength = 50
                End With
                Grd.Columns.Add(col)
            Case "liste"
                Dim cols() As String = colonnes.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                If cols.Length > 1 Then
                    Dim col As New DataGridViewComboBoxColumn
                    With col
                        .ValueType = GetType(String)
                        .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .MinimumWidth = 100
                        For Each v In cols
                            If v.Trim() <> "" Then .Items.Add(v.Trim())
                        Next
                    End With
                    Grd.Columns.Add(col)
                End If
        End Select
        If Not repDic.ContainsKey("0") Then
            repDic.Add("0", Nothing)
        End If
        Grd.Columns(0).HeaderText = ""
        Grd.Rows.Add("")
        Grd.Rows(0).Height = 30
        Grd.Item(0, 0).Value = laquestion & IIf(Obligatoire, " (*)", "")
        If Grd.ColumnCount > 1 Then
            Grd.Columns(1).DefaultCellStyle.BackColor = Color.WhiteSmoke
            Grd.Item(1, 0).Value = parsing(repDic("0"), Typ_Reponse)
            oW = Grd.Columns(0).Width + Grd.Columns(1).Width
        Else
            oW = Grd.Columns(0).Width
        End If
        oH = Grd.Columns(0).HeaderCell.Size.Height + Grd.Rows(0).Height
        Grd.ResumeLayout(True)  ' True pour forcer un layout immédiat
        Me.ResumeLayout(True)
        If modeScoring = "manuel" Then note_txt.Text = noteManuelle
        Saving()
        AddHandler Grd.CellValueChanged, AddressOf Grd_CellValueChanged

    End Sub
    Function parsing(valeur, Typ_reponse) As Object
        If Typ_reponse = "numerique" Then
            valeur = valeur.Replace(".", ",")
            If IsNumeric(valeur) Then
                Return CDbl(valeur)
            Else
                Return 0
            End If
        ElseIf Typ_reponse = "entier" Then
            valeur = valeur.Replace(".", ",")
            If IsNumeric(valeur) Then
                Return CInt(valeur)
            Else
                Return 0
            End If
        ElseIf Typ_reponse = "date" Then
            If EstDate(valeur) Then
                Return CDate(valeur)
            Else
                Return DBNull.Value
            End If
        Else
            Return valeur
        End If
    End Function
    Private Sub Grd_SelectionChanged(sender As Object, e As EventArgs) Handles Grd.SelectionChanged
        Grd.ClearSelection()
    End Sub
    Overrides Sub CalculNote()
        With Grd
            Dim laNote As Double = If(modeScoring = "manuel" And IsNumeric(note_txt.Text), note_txt.Text, 0)
            Dim note_totale As Double = 0
            Dim valeurParDefaut = If("entier;numerique".Split(";").Contains(Typ_Reponse), 0, "''")
            If funcScoring <> "" Then
                Dim noteFunc = Module_Generateur_Survey.myVBS.Eval($"Func_Survey_{codQuestion}(""{IsNull(Grd.Item(1, 0).Value, valeurParDefaut)}"")")
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
        Grd.Invalidate(True)
        If Grd.ColumnCount = 2 And Grd.RowCount = 1 Then
            repDic("0") = Grd.Item(1, 0).Value
        End If
        Dim frm = Me.FindForm()
        If frm IsNot Nothing Then
            ' Chercher une méthode Recalcul, publique ou Friend
            Dim m = frm.GetType().GetMethod("Recalcul",
                                            BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
            If m IsNot Nothing Then
                m.Invoke(frm, Nothing)
            End If
        End If
    End Sub
    Private Sub Grd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
    Handles Grd.CellValueChanged
        If e.RowIndex = 0 AndAlso e.ColumnIndex = 1 Then
            repDic("0") = CStr(Grd.Item(1, 0).Value)
        End If
        Saving()
    End Sub

    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd.DataError

    End Sub
    Private Sub Grd_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) _
    Handles Grd.CurrentCellDirtyStateChanged
        If Grd.IsCurrentCellDirty Then
            Grd.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Grd.EndEdit()
        End If
    End Sub
End Class
