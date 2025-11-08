Public Class ud_rubriqueLbl
    Dim _visibility As Boolean = True
    Dim _typFunction As String = ""
    Dim _codeCouleur As String = ""
    Dim _rang As Integer = 1
    Dim _size As Size = Nothing
    Dim _location As Point = Nothing
    Public Shadows Event Click As EventHandler
    Public Shadows Event MouseDown As EventHandler
    Public Shadows Event MouseMove As EventHandler
    Public Shadows Event MouseUp As EventHandler
    Public canMove As Boolean = True
    Public Property Visibility As Boolean
        Get
            Return _visibility
        End Get
        Set(value As Boolean)
            _visibility = value
            visibility_pb.Image = IIf(_visibility, My.Resources.eye1, My.Resources.eye)
        End Set
    End Property
    Public Property Rang As Integer
        Get
            Return _rang
        End Get
        Set(value As Integer)
            _rang = value
            Rang_lbl.Text = "(" & Droite(("00" & _rang), 2) & ")"
            Rang_lbl.Refresh()
        End Set
    End Property
    Private Sub visibility_pb_DoubleClick(sender As Object, e As EventArgs) Handles visibility_pb.Click
        Visibility = Not Visibility
    End Sub
    Private Sub txt_Click(sender As Object, e As EventArgs) Handles txt.Click
        RaiseEvent Click(Me, e)
    End Sub
    Private Sub txt_MouseDown(sender As Object, e As MouseEventArgs) Handles txt.MouseDown, visibility_pb.MouseDown
        Cursor.Current = Cursors.NoMove2D
        RaiseEvent MouseDown(Me, e)
        If Not canMove Then Return
        If _location <> Nothing Then Rescale(False)
    End Sub
    Private Sub visibility_pb_MouseMove(sender As Object, e As MouseEventArgs) Handles visibility_pb.MouseMove, txt.MouseMove
        RaiseEvent MouseMove(Me, e)
    End Sub
    Private Sub visibility_pb_MouseUp(sender As Object, e As MouseEventArgs) Handles visibility_pb.MouseUp, txt.MouseUp
        RaiseEvent MouseUp(Me, e)
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub ud_rubriqueLbl_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _codeCouleur = "" Then _codeCouleur = colorBase01.R & ";" & colorBase01.G & ";" & colorBase01.B
    End Sub
    Public Shadows Property Text As String
        Get
            Return txt.Text
        End Get
        Set(value As String)
            txt.Text = value
            txt.Refresh()
        End Set
    End Property
    Public Property Typ_Function As String
        Get
            Return _typFunction
        End Get
        Set(value As String)
            _typFunction = value
        End Set
    End Property
    Public Property CodCouleur As String
        Get
            Return _codeCouleur
        End Get
        Set(value As String)
            Dim couleurs() = value.Split(";")
            If couleurs.Length = 3 Then
                _codeCouleur = value
                Dim R = CInt(couleurs(0))
                Dim G = CInt(couleurs(1))
                Dim B = CInt(couleurs(2))
                BackColor = Color.FromArgb(R, G, B)
                Personnal_pnl.BackColor = Color.FromArgb(50, R, G, B)
            Else
                BackColor = colorBase01
                Personnal_pnl.BackColor = Color.FromArgb(20, colorBase01.R, colorBase01.G, colorBase01.B)
            End If
        End Set
    End Property
    Sub Rescale(onOff As Boolean, Optional oSize As Int16 = 4)
        If Not canMove Then Return
        If onOff Then
            _size = Size
            _location = Me.Location
            Size = New Size(_size.Width + oSize, _size.Height + oSize)
            Location = New Point(_location.X - oSize / 2, _location.Y - oSize / 2)
            Personnal_pnl.BackColor = Color.FromArgb(70, Personnal_pnl.BackColor.R, Personnal_pnl.BackColor.G, Personnal_pnl.BackColor.B)
        Else
            If _location <> Nothing And _size <> Nothing Then
                Personnal_pnl.BackColor = Color.FromArgb(20, Personnal_pnl.BackColor.R, Personnal_pnl.BackColor.G, Personnal_pnl.BackColor.B)
                Size = _size
                Location = _location
                _location = Nothing
                _size = Nothing
            End If
        End If
    End Sub

    Private Sub txt_MouseEnter(sender As Object, e As EventArgs) Handles txt.MouseEnter
        Rescale(True)
    End Sub

    Private Sub visibility_pb_MouseLeave(sender As Object, e As EventArgs) Handles txt.MouseLeave
        If _location <> Nothing Then Rescale(False)
    End Sub

    Private Sub txt_MouseWheel(sender As Object, e As MouseEventArgs) Handles txt.MouseWheel
        If _location <> Nothing Then Rescale(False)
    End Sub
End Class
