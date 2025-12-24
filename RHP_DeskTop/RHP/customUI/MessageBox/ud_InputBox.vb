Public Class ud_InputBox
    Dim lesType
    Friend Type As ChampType
    Enum msgIcon
        Information = 1
        [Error] = -2
        [Stop] = -1
        Warning = 0
        Question = 2
    End Enum
    Dim _defaultTheme As msgIcon = msgIcon.Information
    Private Sub Msg_txt_Paint(sender As Object, e As PaintEventArgs)
        Dim sz = e.Graphics.MeasureString(Msg_txt.Text, Msg_txt.Font)
        If sz.Width < 370 Then
            Size = New Size(sz.Width + 90, Height)
        ElseIf (sz.Width / 370) * 20 > 90 Then
            Size = New Size(Width, (sz.Width / 370) * 20 + 31 + 46 + 5)
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                Me.Close()
            Case (Keys.Control Or Keys.C)
                ' Copier le texte du label dans le presse-papiers
                ' Remplacer 'NomDuLabel' par le nom réel de votre contrôle label
                Clipboard.SetText(Msg_txt.Text)
                Return True ' Indique que la touche a été traitée
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub Annuler_ud_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
    Private Sub inputBox_txt_KeyPress(sender As Object, e As EventArgs) Handles inputBox_txt.KeyPress
        Select Case Type
            Case ChampType._Double
                ControleSaisie(sender, e, True, True, True, False, False)
            Case ChampType._Entier
                ControleSaisie(sender, e, True, True, True, False, False)
        End Select
    End Sub

    Private Sub ud_InputBox_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case Type
            Case ChampType._Double, ChampType._Entier
                inputBox_txt.innerTextBox.TextAlign = HorizontalAlignment.Right
            Case ChampType._Date
                inputBox_txt.innerTextBox.TextAlign = HorizontalAlignment.Center
        End Select
        inputBox_txt.innerTextBox.Select()
    End Sub

    Public Property Theme As msgIcon
        Get
            Return _defaultTheme
        End Get
        Set(value As msgIcon)
            Dim col1 = colorBase04
            Dim col2 = colorBase01
            Select Case value
                Case msgIcon.Information
                    pb_Msg.Image = My.Resources.msgboxLogo
                Case msgIcon.Error
                    pb_Msg.Image = My.Resources.msgbox_error
                    col1 = Color.FromArgb(254, 178, 178)
                    col2 = Color.FromArgb(223, 64, 6)
                Case msgIcon.Stop
                    pb_Msg.Image = My.Resources.msgbox_stop
                    col1 = Color.FromArgb(254, 178, 178)
                    col2 = Color.FromArgb(223, 64, 6)
                Case msgIcon.Warning
                    pb_Msg.Image = My.Resources.msgbox_warning
                    col1 = Color.FromArgb(255, 219, 79)
                    col2 = Color.FromArgb(191, 112, 0)
                Case msgIcon.Question
                    pb_Msg.Image = My.Resources.msgbox_question
                Case Else
                    pb_Msg.Image = My.Resources.msgboxLogo
            End Select
            With Titre_lbl
                .BackColor = col1
                .ForeColor = col2
            End With
        End Set
    End Property

End Class

