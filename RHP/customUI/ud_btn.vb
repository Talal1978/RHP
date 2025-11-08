Public Class ud_btn
    Public imgName As String
    Dim _tooltip As String = ""
    Dim _enabled As Boolean = True
    Dim _image As Image
    Dim myfrm As Form
    Dim myProcName As String = ""
    Public Shadows Event Click As EventHandler
    Public Shadows Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
            If _enabled Then
                Btn_pb.Image = _image
            Else
                Btn_pb.Image = ConvertToTargetColor(_image, False)
            End If
        End Set
    End Property
    Public Shadows Property Image As Image
        Get
            Return _image
        End Get
        Set(value As Image)
            _image = value
            If Enabled Then
                Btn_pb.Image = _image
            Else
                Btn_pb.Image = ConvertToTargetColor(_image, False)
            End If
        End Set
    End Property
    Public Shadows Property ToolTip As String
        Get
            Return _tooltip
        End Get
        Set(value As String)
            _tooltip = value
            bnt_toolTip.SetSuperTooltip(Btn_pb, New DevComponents.DotNetBar.SuperTooltipInfo(If(Me.ParentForm IsNot Nothing, Me.ParentForm.Text, "Rh-P"), "", value, Btn_pb.Image, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))

        End Set
    End Property
    Sub New(frm As Form, btnName As String, procName As String, _imgName As String)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        If _imgName = "" Or _imgName Is Nothing Then _imgName = "btn_add"
        If btnName = "" Or btnName Is Nothing Then btnName = "btnName"
        If procName = "" Or procName Is Nothing Then procName = ""
        If frm Is Nothing Then frm = leMenu
        imgName = _imgName
        Dim img As Image = My.Resources.ResourceManager.GetObject(imgName)
        If img IsNot Nothing Then
            Btn_pb.Image = img
            _image = img
        End If
        Cursor = Cursors.Hand
        ' Ajoutez une Initialisation quelconque après l'appel InitializeComponent().
        myfrm = frm
        Me.Name = btnName
        Me.myProcName = procName
    End Sub
    Private Sub ud_btn_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter, Btn_pb.MouseEnter
        If _enabled Then
            Btn_pb.Image = ConvertToTargetColor(_image, True)
        End If
    End Sub

    Private Sub ud_btn_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave, Btn_pb.MouseLeave
        If _enabled Then
            Btn_pb.Image = _image
        End If
    End Sub
    Private Sub Btn_pb_Click(sender As Object, e As EventArgs) Handles Btn_pb.Click
        RaiseEvent Click(Me, e)
    End Sub

    Private Sub ud_btn_Click(sender As Object, e As EventArgs) Handles Me.Click
        If Not Enabled Then Return
        If myProcName.Trim = "" Then Return
        Try
            CallByName(myfrm, myProcName, CallType.Method, Nothing)
        Catch ex As Exception

        End Try

    End Sub
End Class
