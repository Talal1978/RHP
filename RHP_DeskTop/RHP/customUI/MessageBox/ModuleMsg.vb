Module ModuleMsg
    Enum msgIcon
        Information = 1
        [Error] = -2
        [Stop] = -1
        Warning = 0
        Question = 2
    End Enum
    Function ShowMessageBox(MsgTexte As String, Optional MsgTitre As String = "Message", Optional MsgButton As MessageBoxButtons = MessageBoxButtons.OK, Optional MsgIcon As msgIcon = msgIcon.Information, Optional msgDefaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button2) As MsgBoxResult
        Dim mg As New ud_MessageBox
        Dim rsl As New MsgBoxResult
        With mg
            .Titre_lbl.Text = MsgTitre
            .Msg_txt.Text = MsgTexte
            .Theme = MsgIcon
            Select Case MsgButton
                Case MessageBoxButtons.OKCancel
                    .btn_02_ud.Visible = False
                    With .btn_01_ud
                        .Visible = True
                        .Text = "Ok"
                        .Image = My.Resources.btn_ok
                        .isDefault = msgDefaultButton = MessageBoxDefaultButton.Button3
                        AddHandler .Click, Sub()
                                               mg.Close()
                                               rsl = MsgBoxResult.Ok
                                           End Sub
                    End With
                    With .btn_03_ud
                        .Visible = True
                        .Text = "Annuler"
                        .Image = My.Resources.btn_close
                        .isDefault = msgDefaultButton = MessageBoxDefaultButton.Button1
                        AddHandler .Click, Sub()
                                               mg.Close()
                                               rsl = MsgBoxResult.Cancel
                                           End Sub
                    End With
                Case MessageBoxButtons.YesNoCancel
                    With .btn_01_ud
                        .Visible = True
                        .Text = "Oui"
                        .Image = My.Resources.btn_yes
                        .isDefault = msgDefaultButton = MessageBoxDefaultButton.Button3
                        AddHandler .Click, Sub()
                                               mg.Close()
                                               rsl = MsgBoxResult.Yes
                                           End Sub
                    End With
                    With .btn_03_ud
                        .Visible = True
                        .Text = "Non"
                        .Image = My.Resources.btn_no
                        .isDefault = msgDefaultButton = MessageBoxDefaultButton.Button1
                        AddHandler .Click, Sub()
                                               mg.Close()
                                               rsl = MsgBoxResult.No
                                           End Sub
                    End With
                    With .btn_02_ud
                        .Visible = True
                        .Text = "Annuler"
                        .Image = My.Resources.btn_close
                        .isDefault = msgDefaultButton = MessageBoxDefaultButton.Button2
                        AddHandler .Click, Sub()
                                               mg.Close()
                                               rsl = MsgBoxResult.Cancel
                                           End Sub
                    End With
                Case MessageBoxButtons.YesNo
                    With .btn_01_ud
                        .Visible = True
                        .Text = "Oui"
                        .Image = My.Resources.btn_yes
                        .isDefault = msgDefaultButton = MessageBoxDefaultButton.Button3
                        AddHandler .Click, Sub()
                                               mg.Close()
                                               rsl = MsgBoxResult.Yes
                                           End Sub
                    End With
                    With .btn_03_ud
                        .Visible = True
                        .Text = "Non"
                        .Image = My.Resources.btn_no
                        .isDefault = msgDefaultButton = MessageBoxDefaultButton.Button1
                        AddHandler .Click, Sub()
                                               mg.Close()
                                               rsl = MsgBoxResult.No
                                           End Sub
                    End With
                    With .btn_02_ud
                        .Visible = False
                    End With
                Case Else
                    With .btn_01_ud
                        .Visible = False
                        .isDefault = False
                    End With
                    With .btn_03_ud
                        .Visible = False
                        .isDefault = False
                    End With
                    With .btn_02_ud
                        .Visible = True
                        .Text = "Ok"
                        .Image = My.Resources.btn_ok
                        .isDefault = True
                        AddHandler .Click, Sub()
                                               mg.Close()
                                               rsl = MsgBoxResult.Ok
                                           End Sub
                    End With
            End Select
            .BringToFront()
            .BringToFront()
            .BringToFront()
            .ShowDialog()
        End With

        Return rsl
    End Function
    Public Enum ChampType
        _Double
        _Entier
        _String
        _Date
    End Enum
    Function ShowInputBox(MsgTexte As String,
                       Optional MsgTitre As String = "Saisissez une valeur",
                       Optional Type As ChampType = ChampType._String,
                       Optional MsgIcon As msgIcon = msgIcon.Information,
                       Optional ByVal currentText As String = "") As Object

        Dim mg As New ud_InputBox
        Dim rsl As Object = Nothing

        With mg
            .Titre_lbl.Text = MsgTitre
            .Msg_txt.Text = MsgTexte
            .Theme = MsgIcon
            .Type = Type
            If currentText.Trim <> "" Then .inputBox_txt.Text = currentText
            .KeyPreview = True

            Dim submit As Action =
                Sub()
                    Select Case Type
                        Case ChampType._Double
                            If Not IsNumeric(.inputBox_txt.Text) Then ShowMessageBox("Veuillez saisir une valeur numérique", "Erreur valeur") : Exit Sub
                        Case ChampType._Entier
                            If Not IsNumeric(.inputBox_txt.Text) Then ShowMessageBox("Veuillez saisir une valeur numérique", "Erreur valeur") : Exit Sub
                            .inputBox_txt.Text = CInt(CDbl(.inputBox_txt.Text))
                        Case ChampType._Date
                            If Not EstDate(.inputBox_txt.Text) Then ShowMessageBox("Veuillez saisir une valeur de type date", "Erreur valeur") : Exit Sub
                    End Select
                    rsl = .inputBox_txt.Text
                    .DialogResult = DialogResult.OK
                    .Close()
                End Sub

            AddHandler .Ok_ud.Click, Sub() submit()

            ' Enter partout dans la boîte
            AddHandler .KeyDown,
                Sub(e As Object, k As KeyEventArgs)
                    If k.KeyCode = Keys.Enter Then k.SuppressKeyPress = True : submit()
                End Sub

            ' Enter dans la textbox (évite le "ding")
            AddHandler .inputBox_txt.KeyDown,
                Sub(e As Object, k As KeyEventArgs)
                    If k.KeyCode = Keys.Enter Then k.SuppressKeyPress = True : submit()
                End Sub

            ' Si Ok_ud est un Button (IButtonControl), Enter déclenchera aussi Click automatiquement
            Try : .AcceptButton = TryCast(.Ok_ud, IButtonControl) : Catch : End Try

            .ShowDialog()
        End With
        Return rsl
    End Function

End Module
