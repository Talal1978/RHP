Imports System.ComponentModel
Public Class ud_button
    Dim _tooltip As String = ""
    Dim _enabled As Boolean = True
    Dim _img As Image
    Dim _borders As BorderStyle
    Dim _BorderSize As Integer = 0
    Dim _borderColor As Color
    Dim _txtforeColor As Color
    Dim _isDefault As Boolean = False
    <Browsable(True),
 DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
 DefaultValue("")>
    Public Shadows Property Text As String
        Get
            Return txt_lbl.Text
        End Get
        Set(value As String)
            txt_lbl.Text = value
        End Set
    End Property
    <Browsable(True),
 DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
 DefaultValue(System.Drawing.ContentAlignment.MiddleLeft)>
    Public Property TextAlign As System.Drawing.ContentAlignment
        Get
            Return txt_lbl.TextAlign
        End Get
        Set(value As System.Drawing.ContentAlignment)
            txt_lbl.TextAlign = value
        End Set
    End Property
    Public Shadows Property BorderSize As Integer
        Get
            Return _BorderSize
        End Get
        Set(value As Integer)
            _BorderSize = value
            setBorders()
        End Set
    End Property
    Public Property bgColor As Color
        Get
            Return tbl_pnl.BackColor
        End Get
        Set(value As Color)
            tbl_pnl.BackColor = value
        End Set
    End Property
    Public Shadows Property ForeColor As Color
        Get
            Return txt_lbl.ForeColor
        End Get
        Set(value As Color)
            txt_lbl.ForeColor = value
        End Set
    End Property
    Public Shadows Enum BorderStyle
        None
        Top
        Right
        Bottom
        left
        All
    End Enum

    Public Shadows Event Click As EventHandler
    Public Shadows Event MouseEnter As EventHandler
    Public Shadows Event MouseLeave As EventHandler
    Public Shadows Property Border As BorderStyle
        Get
            Return _borders
        End Get
        Set(value As BorderStyle)
            _borders = value
            setBorders()
        End Set
    End Property
    Public Shadows Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.BackColor = If(_enabled, _borderColor, Color.FromArgb(56, 46, 46))
            setBorders()
        End Set
    End Property
    Sub setBorders()
        Select Case Border
            Case BorderStyle.None
                Me.Padding = New Padding(0)
            Case BorderStyle.Bottom
                Me.Padding = New Padding(0, 0, 0, _BorderSize)
            Case BorderStyle.Top
                Me.Padding = New Padding(0, _BorderSize, 0, 0)
            Case BorderStyle.left
                Me.Padding = New Padding(_BorderSize, 0, 0, 0)
            Case BorderStyle.Right
                Me.Padding = New Padding(0, 0, _BorderSize, 0)
            Case BorderStyle.All
                Me.Padding = New Padding(_BorderSize)
        End Select
        If img_pb.Image Is Nothing Then
            With tbl_pnl.ColumnStyles(0)
                .SizeType = SizeType.Absolute
                .Width = 0
            End With
            With tbl_pnl.ColumnStyles(1)
                .SizeType = SizeType.Absolute
                .Width = Me.Width - 2
            End With
            txt_lbl.TextAlign = ContentAlignment.MiddleCenter
        ElseIf String.IsNullOrEmpty(txt_lbl.Text) Then
            With tbl_pnl.ColumnStyles(0)
                .SizeType = SizeType.Absolute
                .Width = Me.Width - 2
            End With
            With tbl_pnl.ColumnStyles(1)
                .SizeType = SizeType.Absolute
                .Width = 0.0F
            End With
            Dim wH = Math.Min(Me.Width - Me.Padding.Left - Me.Padding.Right - 2, Me.Height - Me.Padding.Top - Me.Padding.Bottom - 2) - 2
            Dim imgSize = New Size(wH, wH)
            With img_pb
                .Size = imgSize
                .SizeMode = PictureBoxSizeMode.Zoom
                .Location = New Point((Height - wH) / 2, (Height - wH) / 2)
            End With
        Else
            With tbl_pnl.ColumnStyles(0)
                .SizeType = SizeType.Absolute
                .Width = 30.0F
            End With
            With tbl_pnl.ColumnStyles(1)
                .SizeType = SizeType.Absolute
                .Width = 70.0F
            End With
            Dim wH = Math.Min(Width * 0.3 - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom) - 1
            Dim imgSize = New Size(wH, wH)
            With img_pb
                .Size = imgSize
                .SizeMode = PictureBoxSizeMode.Zoom
                .Location = New Point((Height - wH) / 2, (Height - wH) / 2)
            End With
            txt_lbl.TextAlign = ContentAlignment.MiddleLeft
        End If
    End Sub
    Public Shadows Property isDefault As Boolean
        Get
            Return _isDefault
        End Get
        Set(value As Boolean)
            _isDefault = value
            If Not value Then
                txt_lbl.ForeColor = colorBase01
                BackColor = colorBase01
            Else
                onMouseOn()
            End If
            img_pb.Cursor = Cursor
            txt_lbl.Cursor = Cursor
        End Set
    End Property
    Public Shadows Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
            img_pb.Image = If(value, _img, ConvertToTargetColor(_img, False))
            If value Then
                txt_lbl.ForeColor = colorBase01
                BackColor = colorBase01
                Cursor = Cursors.Hand
            Else
                txt_lbl.ForeColor = Color.FromArgb(146, 146, 146)
                BackColor = Color.FromArgb(146, 146, 146)
                Cursor = Cursors.Default
            End If
            img_pb.Cursor = Cursor
            txt_lbl.Cursor = Cursor
        End Set
    End Property
    <Browsable(True),
 DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
 DefaultValue("")>
    Public Shadows Property ToolTip As String
        Get
            Return _tooltip
        End Get
        Set(value As String)
            _tooltip = value
            bnt_toolTip.SetToolTip(img_pb, value)
        End Set
    End Property
    Public Shadows Property Image As Image
        Get
            Return img_pb.Image
        End Get
        Set(value As Image)
            _img = value
            If Enabled Then
                img_pb.Image = value
            Else
                img_pb.Image = ConvertToTargetColor(value, False)
            End If
            setBorders()
        End Set
    End Property
    Private Sub ud_btn_Click(sender As Object, e As EventArgs) Handles img_pb.Click, txt_lbl.Click
        If Not _enabled Then
            Return
        End If
        RaiseEvent Click(Me, e)
    End Sub
    Sub New()
        Me.SuspendLayout()
        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        ' Ajoutez une Initialisation quelconque après l'appel InitializeComponent().

        Me.BackColor = If(Me.ParentForm IsNot Nothing, Me.ParentForm.BackColor, DefaultBackColor)
        _txtforeColor = txt_lbl.ForeColor
        With Me
            txt_lbl.Cursor = .Cursor
            Me.Cursor = .Cursor
            img_pb.Cursor = .Cursor
        End With
        setBorders()
        Me.ResumeLayout(True)
    End Sub
    Sub onMouseOn()
        img_pb.Image = ConvertToTargetColor(_img, True, Color.White)
        Me.BackColor = colorBase01
        txt_lbl.ForeColor = Color.White
        tbl_pnl.BackColor = colorBase01
    End Sub
    Private Sub ud_button_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        setBorders()
    End Sub
    Private Sub ud_btn_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        If _enabled Then
            onMouseOn()
        End If
    End Sub

    Private Sub ud_btn_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        If _enabled Then
            img_pb.Image = _img
            Me.BackColor = _borderColor
            txt_lbl.ForeColor = colorBase01
            tbl_pnl.BackColor = Color.FromArgb(250, 250, 250)
        End If
    End Sub
    Private Sub _MouseEnter(sender As Object, e As EventArgs) Handles txt_lbl.MouseEnter, img_pb.MouseEnter
        RaiseEvent MouseEnter(Me, e)
    End Sub

    Private Sub _MouseLeave(sender As Object, e As EventArgs) Handles txt_lbl.MouseLeave, img_pb.MouseLeave
        RaiseEvent MouseLeave(Me, e)
    End Sub
    Private Sub txt_lbl_TextChanged(sender As Object, e As EventArgs) Handles txt_lbl.TextChanged
        setBorders()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        If Not _enabled Then
            Return
        End If
        MyBase.OnClick(e)
    End Sub

End Class
