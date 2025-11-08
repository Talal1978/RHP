Imports System.Text.RegularExpressions
Public Class Zoom_Rubrique_Relation
    Friend Relation_txt As New ud_TextBox
    Private Sub New_D_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub Tx_pb_Click(sender As ud_button, e As EventArgs) Handles pb_Egal.Click, pb_Parentese2.Click, pb_Parentese1.Click, pb_Division.Click, pb_Fois.Click, Tx_pb.Click, Nb_pb.Click, Base_pb.Click, pb_Plus.Click, pb_Moins.Click
        pb_clik(sender)
    End Sub
    Sub pb_clik(sender As ud_button)
        With Zone_txt
            Dim SelPos As Integer = Zone_txt.SelectionStart
            Dim ValeurNode As String = " " & sender.Tag & " "
            .Text = Zone_txt.Text.Insert(SelPos, ValeurNode)
            .Select()
            .SelectionStart = SelPos + ValeurNode.Length
            MiseEnForme()
        End With
    End Sub
    Sub MiseEnForme()
        Dim selPos As Integer = Zone_txt.SelectionStart
        With Zone_txt
            .SelectionStart = 0
            .SelectionLength = Zone_txt.Text.Length
            .SelectionColor = Color.Black
            .SelectionStart = selPos
            .SelectionLength = 0
            .Text.Replace(",", ".")
        End With
        Dim rg As New Regex("(\b(Tx)\b|\b(Nb)\b|\b(Base)\b)", RegexOptions.IgnoreCase)
        With Zone_txt
            For Each c As Match In rg.Matches(.Text)
                .Select(c.Index, c.Length)
                .SelectionColor = Color.Blue
            Next
            .SelectionStart = selPos
            .SelectionColor = Color.Black
            .SelectionLength = 0
        End With
    End Sub

    Private Sub Save_D_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Relation_txt.Text = Zone_txt.Text
        Me.Close()
    End Sub
End Class