Public Class ud_CardSoc
    Dim _isSelected As Boolean = False
    Dim _Den As String = ""
    Dim _idSoc As Integer
    Public Property isSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(value As Boolean)
            _isSelected = value
            pb_Selected.Visible = _isSelected
        End Set
    End Property
    Public Property Den As String
        Get
            Return _Den
        End Get
        Set(value As String)
            _Den = value
            Den_lbl.Text = value
            Den_lbl.Refresh()
        End Set
    End Property
    Public Property idSoc As Integer
        Get
            Return _idSoc
        End Get
        Set(value As Integer)
            _idSoc = value
            idSoc_lbl.Text = value
            idSoc_lbl.Refresh()
            isSelected = (value = Societe.id_Societe)
        End Set
    End Property
    Public Property showBorder As Boolean
        Get
            Return Border_pnl.Visible
        End Get
        Set(value As Boolean)
            Border_pnl.Visible = value
        End Set
    End Property
    Public Property borderColor As Color
        Get
            Return Border_pnl.BorderColor
        End Get
        Set(value As Color)
            Border_pnl.BorderColor = value
        End Set
    End Property
    Public Property borderSize As Integer
        Get
            Return Border_pnl.BorderSize
        End Get
        Set(value As Integer)
            Border_pnl.BorderSize = value
        End Set
    End Property
    Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        Me.Border_pnl.BackColor = Color.FromArgb(10, 56, 153, 185)
        Me.borderSize = 1
        ' Ajoutez une Initialisation quelconque après l'appel InitializeComponent().

    End Sub
    Private Sub ud_CardSoc_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter, soc_pb.MouseEnter, idSoc_lbl.MouseEnter, Den_lbl.MouseEnter
        Me.borderColor = colorBase01
    End Sub
    Private Sub ud_CardSoc_Leave(sender As Object, e As EventArgs) Handles Me.MouseLeave, soc_pb.MouseLeave, idSoc_lbl.MouseLeave, Den_lbl.MouseLeave
        Me.borderColor = Color.FromArgb(234, 231, 231)
    End Sub
    Private Sub Border_pnl_DoubleClick(sender As Object, e As EventArgs) Handles Border_pnl.DoubleClick, pb_Selected.DoubleClick, soc_pb.DoubleClick, idSoc_lbl.DoubleClick, Den_lbl.DoubleClick
        OuvrirSociete(idSoc, True)
        isSelected = True
        newShowEcran(New Menu_Operationnel)
    End Sub

    Private Sub ud_CardSoc_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        isSelected = (idSoc = Societe.id_Societe)
        pb_Selected.Visible = _isSelected
    End Sub

    Private Sub soc_pb_Click(sender As Object, e As EventArgs) Handles soc_pb.Click, Border_pnl.Click, pb_Selected.Click, soc_pb.Click, idSoc_lbl.Click, Den_lbl.Click
        OuvrirSociete(idSoc, True)
        isSelected = True
    End Sub
End Class
