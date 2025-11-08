Imports System.ComponentModel
Public Class ud_CheckBox
    Public Event CheckedChanged As EventHandler
    Dim _checked As Boolean = True
    Dim _enabled As Boolean = True
    Public Event Cliquer As EventHandler
    <Browsable(True),
 DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
 DefaultValue("")> ' Default value to ensure serialization when non-default
    Public Overrides Property [Text] As String
        Get
            Return Text_lbl.Text
        End Get
        Set(value As String)
            Text_lbl.Text = value
            Text_lbl.Refresh()
        End Set
    End Property
    Public Shadows Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
            Dim img As Image = If(_checked, My.Resources.btn_check_on, My.Resources.btn_check_off)
            check_pb.Image = If(value, img, ConvertToTargetColor(img, False))
        End Set
    End Property
    Public Property Checked As Boolean
        Get
            Return _checked
        End Get
        Set(value As Boolean)
            _checked = value
            Dim img As Image = If(_checked, My.Resources.btn_check_on, My.Resources.btn_check_off)
            check_pb.Image = If(_enabled, img, ConvertToTargetColor(img, False))
            RaiseEvent CheckedChanged(Me, EventArgs.Empty)
        End Set
    End Property
    Private Sub check_pb_Click(sender As Object, e As EventArgs) Handles check_pb.Click, Me.Click
        If Not Enabled Then Return
        Checked = Not Checked
        RaiseEvent Cliquer(Me, EventArgs.Empty)
    End Sub
End Class
