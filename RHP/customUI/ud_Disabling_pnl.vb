Public Class TransparentPanel
    Inherits Panel

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim bgColor As Color = Color.FromArgb(128, Me.BackColor) ' 50% opacity
        Using brush As New SolidBrush(bgColor)
            e.Graphics.FillRectangle(brush, Me.ClientRectangle)
        End Using
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        ' Do nothing here to prevent flickering
    End Sub

End Class

