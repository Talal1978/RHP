Imports System.ComponentModel

Public Class ud_RadioBox
    Dim _checked As Boolean = False
    Public Event CheckedChanged As EventHandler

    Public Property Checked As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            If _checked <> value Then
                _checked = value
                Dim img = If(value, My.Resources.chk_on, My.Resources.chk_off)
                rd_pb.Image = If(Enabled, img, ConvertToTargetColor(img, False))
                If value Then
                    If Me.Parent IsNot Nothing Then
                        For Each c As ud_RadioBox In Me.Parent.Controls.OfType(Of ud_RadioBox)
                            If c IsNot Me Then
                                c.Checked = False
                            End If
                        Next
                    End If
                End If
                RaiseEvent CheckedChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property
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

    Private Sub Ud_RadioBox_Click(sender As Object, e As EventArgs) Handles Me.Click, txt_lbl.Click, rd_pb.Click
        If Not Enabled Then Return
        Checked = Not Checked
    End Sub
End Class
