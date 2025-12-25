Imports System.Drawing.Drawing2D

Public Class UC_Timeline_Item

    Public Property DateText As String
        Get
            Return lblDate.Text
        End Get
        Set(value As String)
            lblDate.Text = value
        End Set
    End Property

    Public Property JobTitle As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    Public Property Subtitle As String
        Get
            Return lblSubtitle.Text
        End Get
        Set(value As String)
            lblSubtitle.Text = value
        End Set
    End Property

    Public Property Mission As String
        Get
            Return lblMission.Text
        End Get
        Set(value As String)
            lblMission.Text = value
        End Set
    End Property
    Public Property Motif As String
        Get
            Return Motif_lbl.Text
        End Get
        Set(value As String)
            Motif_lbl.Text = value
        End Set
    End Property
    Public Property Tags As String
        Get
            Return lblTags.Text
        End Get
        Set(value As String)
            lblTags.Text = value
        End Set
    End Property

    Public Property Code As String
        Get
            Return lnkCode.Text
        End Get
        Set(value As String)
            lnkCode.Text = value
        End Set
    End Property

    Public Event CodeClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    Private Sub lnkCode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCode.LinkClicked
        RaiseEvent CodeClicked(Me, e)
    End Sub
    
    ' Position of the line center
    Private Const LineX As Integer = 100

    Private Sub UC_Timeline_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Rounded corners for the card
        Dim p As New GraphicsPath()
        Dim r As Rectangle = pnlCard.ClientRectangle
        Dim radius As Integer = 15
        p.AddArc(r.X, r.Y, radius, radius, 180, 90)
        p.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90)
        p.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90)
        p.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90)
        p.CloseFigure()
        pnlCard.Region = New Region(p)
        _lineH_lbl.BackColor = colorBase02
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        ' Colors from Module_Declaration_Var (hardcoded here to ensure availability if module not linked correctly, but matching values)
        Dim primaryColor As Color = Color.FromArgb(56, 153, 185) ' colorBase01
        Dim secondaryColor As Color = Color.FromArgb(94, 185, 117) ' colorBase02
        
        ' Draw Vertical Gradient Line
        Using brush As New LinearGradientBrush(New Point(LineX, 0), New Point(LineX, Me.Height), primaryColor, secondaryColor)
            Using pen As New Pen(brush, 4)
                g.DrawLine(pen, LineX, 0, LineX, Me.Height)
            End Using
        End Using

        ' Draw Dot
        Dim dotSize As Integer = 14
        Dim dotRect As New Rectangle(LineX - (dotSize / 2), 25, dotSize, dotSize)
        
        ' Glow effect (subtle for light theme)
        Using brush As New SolidBrush(Color.FromArgb(50, 56, 153, 185))
            g.FillEllipse(brush, dotRect.X - 4, dotRect.Y - 4, dotRect.Width + 8, dotRect.Height + 8)
        End Using

        ' Main Dot
        g.FillEllipse(Brushes.White, dotRect)
        Using pen As New Pen(primaryColor, 3)
            g.DrawEllipse(pen, dotRect)
        End Using
        
        ' Draw Card Border (Rectangle around pnlCard)
        Using pen As New Pen(Color.FromArgb(224, 221, 221), 1)
             Dim r As Rectangle = pnlCard.Bounds
             r.Inflate(1, 1)
             ' Simple rect for border visual or advanced path if needed
             ' For now rely on panel border or draw manual
        End Using

    End Sub

    ' Redraw on resize to keep lines correct
    Private Sub UC_Timeline_Item_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        _lineH_lbl.Width = Me.Width
        Me.Invalidate()
    End Sub

End Class
