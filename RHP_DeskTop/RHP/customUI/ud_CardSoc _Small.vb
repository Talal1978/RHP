Public Class ud_CardSoc_Small
    Dim _isSelected As Boolean = False
    Dim _Den As String = ""
    Dim _idSoc As Integer
    Public Property isSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(value As Boolean)
            _isSelected = value
            soc_pb.Image = IIf(_isSelected, My.Resources.btn_soc_selected, My.Resources.btn_folder_small)
        End Set
    End Property
    Public Property Den As String
        Get
            Return _Den
        End Get
        Set(value As String)
            _Den = value
            Den_lbl.Text = value & " (" & idSoc & ")"
            Den_lbl.Refresh()
        End Set
    End Property
    Public Property idSoc As Integer
        Get
            Return _idSoc
        End Get
        Set(value As Integer)
            _idSoc = value
            Den_lbl.Text = Den & " (" & value & ")"
            Den_lbl.Refresh()
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
        InitializeComponent()
    End Sub
    Private Sub ud_CardSoc_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter, soc_pb.MouseEnter, Den_lbl.MouseEnter, Border_pnl.MouseEnter
        Me.borderColor = colorBase01
        If Not isSelected Then soc_pb.Image = ConvertToTargetColor(My.Resources.btn_folder_small, True)
    End Sub
    Private Sub ud_CardSoc_Leave(sender As Object, e As EventArgs) Handles Me.MouseLeave, soc_pb.MouseLeave, Den_lbl.MouseLeave, Border_pnl.MouseLeave
        Me.borderColor = Color.Transparent
        If Not isSelected Then soc_pb.Image = My.Resources.btn_folder_small
    End Sub
    Private Sub Border_pnl_DoubleClick(sender As Object, e As EventArgs) Handles Border_pnl.DoubleClick, soc_pb.DoubleClick, Den_lbl.DoubleClick
        OuvrirSociete(idSoc, True)
        newShowEcran(New Menu_Operationnel)
    End Sub
End Class
