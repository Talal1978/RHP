Public Class ud_CardItem
    Dim _image As Image
    Dim _enabled As Boolean = True
    Dim _text As String
    Dim _isSelected As Boolean = False
    Public Property isSelected As Boolean
        Get
            Return _isSelected And Enabled
        End Get
        Set(value As Boolean)
            _isSelected = value And Enabled
            If Not Enabled Then Return
            If _isSelected Then
                Img_pb.Image = ConvertToTargetColor(Image, True, Color.White)
                Titre_lbl.ForeColor = Color.White
                Ud_Pnl.BackColor = colorBase01
            Else
                Img_pb.Image = Image
                Titre_lbl.ForeColor = colorBase01
                Ud_Pnl.BackColor = Color.FromArgb(240, 240, 240)
            End If
        End Set
    End Property
    Public Property Image As Image
        Get
            Return _image
        End Get
        Set(value As Image)
            _image = value
            Img_pb.Image = value
        End Set
    End Property
    Public Shadows Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
            If value Then
                Img_pb.Image = Image
                Titre_lbl.ForeColor = colorBase01
            Else
                Img_pb.Image = ConvertToTargetColor(Image, False)
                Titre_lbl.ForeColor = Color.FromArgb(141, 141, 141)
            End If
        End Set
    End Property
    Public Property Titre As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
            Titre_lbl.Text = value
            Titre_lbl.Refresh()
        End Set
    End Property

    Private Sub ud_CardItem_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseEnter, Img_pb.MouseEnter, Titre_lbl.MouseEnter, Ud_Pnl.MouseEnter
        If Not Enabled Then Return
        If isSelected Then Return
        Ud_Pnl.BackColor = colorBase04
    End Sub

    Private Sub ud_CardItem_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave, Img_pb.MouseLeave, Titre_lbl.MouseLeave, Ud_Pnl.MouseLeave
        If Not Enabled Then Return
        If isSelected Then Return
        Ud_Pnl.BackColor = Color.FromArgb(240, 240, 240)
    End Sub
    Private Sub ChildControl_ForwardClick(sender As Object, e As EventArgs) Handles Img_pb.Click, Titre_lbl.Click, Ud_Pnl.Click
        ' Raise the UserControl's Click event
        Me.OnClick(e)
    End Sub

    Private Sub ud_CardItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        Ud_Pnl.BorderColor = colorBase01
    End Sub
End Class
