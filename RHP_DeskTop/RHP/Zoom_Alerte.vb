Public Class Zoom_Alerte
    Private Sub Bouton_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub AlertText_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlertText.Click
        Me.Close()
    End Sub

    Private Sub Zoom_Alerte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Alertstr = ""
        'CnExecuting("update Workflow_Msg_To set Alert='O' where id_To='" & theUser.id_User & "'")
        'CnExecuting("update Workflow_Msg_Cc set Alert='O' where Id_To_Cc='" & theUser.id_User & "'")
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Enter
                Me.Close()
            Case Keys.Escape
                Me.Close()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class