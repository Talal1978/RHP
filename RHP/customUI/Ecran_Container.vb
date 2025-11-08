Public Class Ecran_Container
    Dim oSize As New Size
    Private Sub pnl_Content_ControlAdded(sender As Object, e As ControlEventArgs) Handles pnl_Content.ControlAdded
        If TypeOf e.Control Is Ecran Then
            With CType(e.Control, Ecran)
                AddHandler .FormClosed, Sub()
                                            Me.Close()
                                        End Sub
                Me.Size = New Size(.Width + Me.Width - pnl_Content.Width, .Height + Me.Height - pnl_Content.Height)
                oSize = Me.Size
                If Me.Text = "" Then
                    Titre_lbl.Text = .Text
                Else
                    Titre_lbl.Text = Me.Text
                End If
            End With
        End If
    End Sub
    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        If pnl_Content.Controls.Count > 0 Then
            Try
                CType(pnl_Content.Controls(0), Ecran).Close()
                If pnl_Content.Controls.Count = 0 Then
                    Me.Close()
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub Maximize_pb_Click(sender As Object, e As EventArgs) Handles Maximize_pb.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Size = oSize
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub Ecran_Container_Load(sender As Object, e As EventArgs) Handles Me.Load
        ent_pnl.BackColor = colorBase04
    End Sub
End Class