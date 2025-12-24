Public Class ud_CheckedListBox
    Inherits Panel
    Public Event ItemCheck As EventHandler
    Sub New()
        AutoScroll = True
        '   DoubleBuffered = True
    End Sub
    Public Function GetItemChecked(index As Integer) As Boolean
        If Controls.Count > index Then
            Return CType(Controls(index), ud_CheckBox).Checked
        End If
        Return False
    End Function
    Public Sub SetItemChecked(index As Integer, checked As Boolean)
        If Controls.Count > index Then
            CType(Controls(index), ud_CheckBox).Checked = checked
        End If
    End Sub
    Public Sub AddItem(item As Object, checked As Boolean, Optional itemText As String = "")
        Dim X, Y As Integer
        X = 5
        Y = 5
        If item.GetType = GetType(String) Then
            Dim itm As New ud_CheckBox
            With itm
                .Name = item
                .Text = If(itemText <> "", itemText, item)
                .Checked = checked
                AddHandler .CheckedChanged, Sub(sender As ud_CheckBox, e As Object)
                                                RaiseEvent ItemCheck(sender, e)
                                            End Sub
                .Location = New Point(X, Y + Controls.Count * .Height)
            End With
            Controls.Add(itm)
        ElseIf item.GetType = GetType(ud_CheckBox) Then
            With CType(item, ud_CheckBox)
                .Checked = checked
                .Location = New Point(X, Y + Controls.Count * .Height)
                AddHandler .CheckedChanged, Sub(sender As ud_CheckBox, e As Object)
                                                RaiseEvent ItemCheck(sender, e)
                                            End Sub
            End With
            Controls.Add(item)
        End If
    End Sub
    Public Sub ClearItems()
        Controls.Clear()
    End Sub

End Class
