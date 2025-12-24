Public Class ud_MenuContainer
    Inherits Panel
    Public Event ControlsOrderChanged(sender As Object, e As EventArgs)
    Private _previousControlCount As Integer = 0
    Private _previousControlOrder As New List(Of Control)
    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        MyBase.OnControlAdded(e)
        RaiseEvent ControlsOrderChanged(Me, EventArgs.Empty)
    End Sub
    Protected Overrides Sub OnControlRemoved(e As ControlEventArgs)
        MyBase.OnControlRemoved(e)
        RaiseEvent ControlsOrderChanged(Me, EventArgs.Empty)
    End Sub
    Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
        MyBase.OnLayout(levent)
        ' Check for control count change
        If Me.Controls.Count <> _previousControlCount Then
            _previousControlCount = Me.Controls.Count
            RaiseEvent ControlsOrderChanged(Me, EventArgs.Empty)
        End If

        ' Check for z-order change
        If Not Me.Controls.Cast(Of Control)().SequenceEqual(_previousControlOrder) Then
            _previousControlOrder = Me.Controls.Cast(Of Control)().ToList()
            RaiseEvent ControlsOrderChanged(Me, EventArgs.Empty)
        End If

        ' Check the AffectedProperty if needed
        If levent.AffectedProperty = "SomeProperty" Then
            ' Handle specific property change if necessary
        End If
    End Sub
    Private Sub ud_MenuContainer_ControlsOrderChanged(sender As Object, e As EventArgs) Handles Me.ControlsOrderChanged
        If Me.Parent.GetType Is GetType(leMenu) Then
            With CType(Me.Parent, leMenu)
                If Me.Controls.Count = 0 Then
                    newShowEcran(Menu_Societes)
                Else
                    .currentEcran = Me.Controls(0)
                End If

            End With
        End If
    End Sub
End Class
