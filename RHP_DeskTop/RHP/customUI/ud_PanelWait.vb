Public Class ud_PanelWait
    Private Sub PanelWait_Load(sender As Object, e As EventArgs) Handles Me.Load
        With Me
            .Dock = DockStyle.Fill
        End With
        With Progress_pnl
            .Top = Me.Parent.Height / 2 - .Height / 2
            .Left = Me.Parent.Width / 2 - .Width / 2
            .BringToFront()
        End With
        CircularProgress1.Show()
        '    Me.Controls.Add(lblProgress)

    End Sub
End Class
