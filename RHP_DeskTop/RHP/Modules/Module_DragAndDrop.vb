Module Module_DragAndDrop
    Private mMouseDown As Boolean = False

    Sub DragDroping(ByVal C As Control)

        With C
            AddHandler .MouseUp, AddressOf MouseUpEv
            AddHandler .MouseDown, AddressOf MouseDownEv
            AddHandler .MouseMove, AddressOf MouseMoveEv
            AddHandler .MouseLeave, AddressOf MouseLeaveEv
        End With

    End Sub

    Private Sub MouseMoveEv(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If Math.Abs(e.X) < 15 And Math.Abs(e.Y) < 15 Then
            sender.findform.Cursor = Cursors.SizeAll
            If Not mMouseDown Then Exit Sub
            sender.Location = New Point(sender.Left + e.X, sender.Top + e.Y)
        ElseIf Math.Abs(e.X) < 15 And Math.Abs(e.Y) >= 15 Then
            sender.findform.Cursor = Cursors.SizeWE
            If Not mMouseDown Then Exit Sub
            sender.SetBounds(sender.Left + e.X, sender.Top, sender.Width - e.X, sender.Height)
        Else
            sender.findform.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub MouseDownEv(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            mMouseDown = True
        End If
    End Sub


    Private Sub MouseUpEv(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        mMouseDown = False
        sender.findform.Cursor = Cursors.Default
    End Sub
    Private Sub MouseLeaveEv(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.findform.Cursor = Cursors.Default
    End Sub
End Module
