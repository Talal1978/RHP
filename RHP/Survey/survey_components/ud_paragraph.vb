Imports System.Reflection

Public Class ud_paragraph
    Private Sub ud_grille_cases_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SuspendLayout()
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
        With Txt
            .innerTextBox.BackColor = System.Drawing.SystemColors.Control
        End With
        Me.ResumeLayout()
    End Sub
    Private Sub ud_paragraph_Leave(sender As Object, e As EventArgs) Handles Me.Leave, Txt.Leave
        Saving()
    End Sub
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles Txt.TextChanged
        repDic("0") = Txt.Text
    End Sub
    Overrides Sub Chargement()
        Num_Question_lbl.Text = numQuestion
        LaQuestion_lbl.Text = laquestion & IIf(Obligatoire, " (*)", "")
        If Not repDic.ContainsKey("0") Then
            repDic.Add("0", Txt.Text)
        End If
        If modeScoring = "manuel" Then note_txt.Text = noteManuelle
        Txt.Text = repDic("0")
        Saving()
    End Sub
    Overrides Sub CalculNote()

        Dim laNote As Double = If(modeScoring = "manuel" And IsNumeric(note_txt.Text), note_txt.Text, 0)
        Dim note_totale As Double = 0
        note_totale = Math.Round(If(IsNumeric(coef), coef * laNote, laNote), 2)
        note_totale_txt.Text = note_totale
        noteDic.Clear()
        noteDic.Add("note", laNote)
        noteDic.Add("coef", coef)
        noteDic.Add("note_totale", note_totale)
    End Sub
    Overrides Sub Saving()
        CalculNote()
        repDic("0") = Txt.Text
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

End Class
