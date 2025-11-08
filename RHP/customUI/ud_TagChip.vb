Imports System.Drawing.Drawing2D

Public Class ud_TagChip
    Inherits Control
    Public Event Removed As EventHandler

    '--- Texte
    Private _text As String = "#tag"
    Public Property TextTag As String
        Get
            Return _text : End Get
        Set(v As String)
            _text = v : Invalidate() : RecalcSize() : End Set
    End Property

    '--- Géométrie
    Public PadH As Integer = 10
    Public PadV As Integer = 4
    Public Gap As Integer = 8
    Public Corner As Integer = 12

    '--- Couleurs style "carte bleue" de l’exemple
    Private ReadOnly BorderColor As Color = Color.FromArgb(56, 153, 185)
    Private ReadOnly FillTop As Color = Color.FromArgb(232, 247, 253) ' bleu très clair (haut)
    Private ReadOnly FillBottom As Color = Color.FromArgb(213, 240, 251) ' un peu plus soutenu (bas)
    Private ReadOnly ShineTop As Color = Color.FromArgb(60, Color.White) ' reflet subtile

    '--- État
    Private pillPath As GraphicsPath
    Private closeRect As Rectangle
    Private closeHover As Boolean
    Private chipHover As Boolean

    Public Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                 ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        AutoSize = True
        Margin = New Padding(4)
        Font = New Font("Segoe UI", 9.0F)
        ForeColor = Color.FromArgb(32, 64, 82)
        RecalcSize()
    End Sub

    '--- Taille idéale = texte + “×” + paddings
    Public Overrides Function GetPreferredSize(proposedSize As Size) As Size
        Dim flags = TextFormatFlags.NoPadding Or TextFormatFlags.SingleLine
        Dim ts = TextRenderer.MeasureText(If(_text, ""), Font, Size.Empty, flags)
        Dim xs = TextRenderer.MeasureText("×", Font, Size.Empty, flags)
        Dim h = Math.Max(ts.Height, xs.Height) + 2 * PadV
        Dim w = PadH + ts.Width + Gap + xs.Width + PadH
        Return New Size(w, h)
    End Function

    Private Sub RecalcSize()
        Dim s = GetPreferredSize(Size.Empty)
        If Size <> s Then Size = s
    End Sub

    Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
        MyBase.OnLayout(levent)
        Dim xs = TextRenderer.MeasureText("×", Font, Size.Empty, TextFormatFlags.NoPadding Or TextFormatFlags.SingleLine)
        closeRect = New Rectangle(Width - PadH - xs.Width, (Height - xs.Height) \ 2, xs.Width, xs.Height)
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        RecalcSize()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim h = closeRect.Contains(e.Location)
        If h <> closeHover Then
            closeHover = h
            Cursor = If(h, Cursors.Hand, Cursors.Default)
            Invalidate(closeRect)
        End If
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        chipHover = True : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        chipHover = False : closeHover = False : Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Dim meArgs = TryCast(e, MouseEventArgs)
        If meArgs IsNot Nothing AndAlso closeRect.Contains(meArgs.Location) Then
            RaiseEvent Removed(Me, EventArgs.Empty)
        End If
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        pillPath?.Dispose()
        pillPath = RoundedRect(New Rectangle(0, 0, Math.Max(1, Width - 1), Math.Max(1, Height - 1)), Corner)
        Region = New Region(pillPath)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        g.CompositingQuality = CompositingQuality.HighQuality

        If pillPath Is Nothing Then
            pillPath = RoundedRect(New Rectangle(0, 0, Math.Max(1, Width - 1), Math.Max(1, Height - 1)), Corner)
        End If
        Dim r = New Rectangle(0, 0, Width - 1, Height - 1)

        ' 1) Ombre douce
        Using m As New Matrix(), sh As GraphicsPath = CType(pillPath.Clone(), GraphicsPath)
            m.Translate(0, 1) : sh.Transform(m)
            Using brSh As New SolidBrush(Color.FromArgb(22, Color.Black))
                g.FillPath(brSh, sh)
            End Using
        End Using

        ' 2) Remplissage bleu (comme la carte de l’exemple)
        Dim cTop = If(chipHover, Blend(FillTop, BorderColor, 0.05F), FillTop)
        Dim cBot = If(chipHover, Blend(FillBottom, BorderColor, 0.05F), FillBottom)
        Using lg As New LinearGradientBrush(r, cTop, cBot, 90.0F)
            g.FillPath(lg, pillPath)
        End Using

        ' 3) Contour externe bleu
        Using penOut As New Pen(If(chipHover, Blend(BorderColor, Color.Black, 0.08F), BorderColor), 1.6F)
            penOut.Alignment = PenAlignment.Inset
            g.DrawPath(penOut, pillPath)
        End Using

        ' 4) Liseré interne bleu clair (effet “chanfrein”)
        Using inner As GraphicsPath = RoundedRect(Rectangle.Inflate(r, -1, -1), Math.Max(1, Corner - 1)),
              penIn As New Pen(Color.FromArgb(120, BorderColor), 1.0F)
            penIn.Alignment = PenAlignment.Inset
            g.DrawPath(penIn, inner)
        End Using

        ' 5) Brillance haute discrète
        Dim topRect = New Rectangle(r.X + 1, r.Y + 1, r.Width - 2, r.Height \ 2)
        Using hi As New LinearGradientBrush(topRect, ShineTop, Color.FromArgb(0, Color.White), 90.0F),
              hiPath As GraphicsPath = RoundedRect(topRect, Math.Max(1, Corner - 2))
            g.FillPath(hi, hiPath)
        End Using

        ' 6) Texte
        Dim flags = TextFormatFlags.NoPadding Or TextFormatFlags.SingleLine
        TextRenderer.DrawText(g, _text, Font, New Point(PadH, (Height - Font.Height) \ 2), ForeColor, flags)

        ' 7) “×”
        Dim xCol = If(closeHover, Blend(BorderColor, Color.Black, 0.15F), Blend(BorderColor, Color.White, 0.15F))
        TextRenderer.DrawText(g, "×", Font, closeRect.Location, xCol, flags)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then pillPath?.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    '--- Utils
    Private Shared Function RoundedRect(r As Rectangle, radius As Integer) As GraphicsPath
        Dim gp As New GraphicsPath()
        If r.Width <= 0 OrElse r.Height <= 0 Then Return gp
        Dim d As Integer = Math.Min(radius * 2, Math.Min(r.Width, r.Height))
        If d <= 0 Then gp.AddRectangle(r) : Return gp
        Dim x = r.X, y = r.Y, w = r.Width, h = r.Height
        gp.AddArc(x, y, d, d, 180, 90)
        gp.AddArc(x + w - d, y, d, d, 270, 90)
        gp.AddArc(x + w - d, y + h - d, d, d, 0, 90)
        gp.AddArc(x, y + h - d, d, d, 90, 90)
        gp.CloseFigure()
        Return gp
    End Function

    Private Shared Function Blend(a As Color, b As Color, t As Single) As Color
        Dim u = 1.0F - t
        Return Color.FromArgb(
            CInt(a.A * u + b.A * t),
            CInt(a.R * u + b.R * t),
            CInt(a.G * u + b.G * t),
            CInt(a.B * u + b.B * t))
    End Function
End Class
