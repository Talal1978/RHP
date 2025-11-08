Module Module_DragDrop
    Friend MouseDownLocation, oPointDepart, oChamps As New ArrayList
    Friend oPnl0 As Object
    Dim opnlPnt As New Point
    Friend obtn0 As New Label
    Sub AddEvent(oPnl As Object)
        Try
            oPnl0 = oPnl

            For Each c As Object In oPnl.Controls
                If TypeOf c Is Label Then
                    MouseDownLocation.Add(Nothing)
                    oPointDepart.Add(c.location)
                    oChamps.Add(c)
                    RemoveHandler CType(c, Label).MouseMove, AddressOf sender_MouseMove
                    RemoveHandler CType(c, Label).MouseLeave, AddressOf sender_MouseLeave
                    RemoveHandler CType(c, Label).MouseDown, AddressOf sender_MouseDown

                    RemoveHandler CType(c, Label).MouseMove, AddressOf sender_MouseMove
                    RemoveHandler CType(c, Label).MouseLeave, AddressOf sender_MouseLeave
                    RemoveHandler CType(c, Label).MouseDown, AddressOf sender_MouseDown

                    AddHandler CType(c, Label).MouseMove, AddressOf sender_MouseMove
                    AddHandler CType(c, Label).MouseLeave, AddressOf sender_MouseLeave
                    AddHandler CType(c, Label).MouseDown, AddressOf sender_MouseDown

                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub sender_MouseDown(sender As Object, e As MouseEventArgs)
        Try
            If e.Button = System.Windows.Forms.MouseButtons.Left Then
                MouseDownLocation(oChamps.IndexOf(sender)) = e.Location
                sender.BringToFront()
                obtn0 = sender
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub sender_MouseLeave(sender As Object, e As EventArgs)
        Try
            If obtn0 Is Nothing Then Return
            Dim opt As Point = PointLocation(sender.findform, sender, New Point(sender.location.x, sender.location.y))
            If opt.X > opnlPnt.X And
                opt.X < opnlPnt.X + oPnl0.Width And
               opt.Y > opnlPnt.Y And
              opt.Y < opnlPnt.Y + oPnl0.Height Then
                sender.Parent = oPnl0
                sender.Location = oPointDepart(oChamps.IndexOf(sender))

                obtn0 = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub sender_MouseMove(sender As Object, e As MouseEventArgs)
        Try
            If e.Button = System.Windows.Forms.MouseButtons.Left Then
                sender.Left = e.X + sender.Left - MouseDownLocation(oChamps.IndexOf(sender)).X
                sender.Top = e.Y + sender.Top - MouseDownLocation(oChamps.IndexOf(sender)).Y
                If (sender.Left < 0 Or
                    sender.Left + sender.Width > sender.Parent.Width Or
                    sender.Top < 0 Or
                    sender.Top + sender.Height > sender.Parent.Height) And TypeOf sender.parent IsNot Form _
                    Then
                    sender.Left += opnlPnt.X
                    sender.Top += opnlPnt.Y
                    sender.Parent = sender.findform
                    sender.BringToFront()
                End If

            End If
        Catch ex As Exception
            '    ShowMessageBox("Module Drag and Drop : MouseMove" & vbCrLf & ex.Message)
        End Try
    End Sub
End Module
