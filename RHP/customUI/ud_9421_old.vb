Public Class ud_9421_old
    Dim ToolTip1 As New ToolTip
    Public Shadows Property Text As String
        Get
            Return lbl.Text
        End Get
        Set(value As String)
            lbl.Text = value
            lbl.Refresh()
            ToolTip1.SetToolTip(lbl, value)
        End Set
    End Property
    Public Property Child As Label
        Get
            If Pnl.Controls.Count = 0 Then
                Return Nothing
            Else
                Return Pnl.Controls(0)
            End If
        End Get
        Set(value As Label)
            If Pnl.Controls.Count = 0 Then
                Pnl.Controls.Add(value)
            Else
                Pnl.Controls.Add(value)
                For i = Pnl.Controls.Count - 1 To 0 Step -1
                    If Pnl.Controls(i) IsNot value Then
                        Pnl.Controls.RemoveAt(i)
                    End If
                Next
            End If
            With value
                .MinimumSize = New Size(20, 20)
                .Dock = DockStyle.Fill
                .BringToFront()
            End With
        End Set
    End Property
End Class
