Public Class ud_Panel
    Inherits Panel

    Private _borderColor As Color = System.Drawing.Color.FromArgb(56, 153, 185)
    Private _borderSize As Integer = 2
    Public Property BorderColor() As Color
        Get
            Return _borderColor
        End Get
        Set(ByVal value As Color)
            _borderColor = value
            Me.Invalidate() ' Trigger a repaint to reflect the change
        End Set
    End Property
    Public Property BorderSize() As Integer
        Get
            Return _borderSize
        End Get
        Set(ByVal value As Integer)
            _borderSize = value
            Me.Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        ' Draw the border using BorderColor
        Using borderPen As New Pen(_borderColor, _borderSize)
            Dim adjustedWidth As Integer = Me.ClientSize.Width - _borderSize - 1
            Dim adjustedHeight As Integer = Me.ClientSize.Height - _borderSize - 1
            e.Graphics.DrawRectangle(borderPen, New Rectangle(1, 1, adjustedWidth, adjustedHeight))
        End Using
    End Sub
    Public Sub New()
        Me.DoubleBuffered = True
    End Sub
End Class

