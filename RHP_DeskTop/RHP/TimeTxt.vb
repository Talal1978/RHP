Public Class TimeTxt
    Inherits MaskedTextBox
    Public Sub New()
        AddHandler Me.Validating, AddressOf CheckIfIsTime
    End Sub
    Sub CheckIfIsTime(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Me.Text = Me.Text.Replace(Me.PromptChar, "0")
        e.Cancel = Not EstTime(Me.Text)
    End Sub

End Class
