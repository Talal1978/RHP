Imports System.Text.RegularExpressions
Public Class Zoom_FiltreAvance
    Friend Grd As New ud_Grd
    Friend oMnu As New ToolStripMenuItem
    Dim Formule, FormuleRegStr As New ArrayList
    Dim rgFormule As New Regex("")
    Dim rgChamps As New Regex("")
    Private Sub Zoom_FiltreAvance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rgstr As String = ""
        With Grd
            For i = 0 To .ColumnCount - 1
                Dim oItm As New ListViewItem
                oItm.Text = .Columns(i).HeaderText
                oItm.Name = .Columns(i).Name
                oItm.Checked = False
                LvChamps.Items.Add(oItm)
                rgstr &= IIf(rgstr = "", "", "|") & "(\b(" & .Columns(i).Name & ")\b)"
            Next

            rgChamps = New Regex(rgstr, RegexOptions.IgnoreCase)
        End With


        rgstr = "(\b(Comme)\b)|(\b(Différent)\b)|(\b(Parmi)\b)|(\b(Pas)\b)|(\b(Ou)\b)|(\b(Et)\b)|[\=\<\>\(\)\+\-\\]|(\b(x)\b)"
        rgFormule = New Regex(rgstr, RegexOptions.IgnoreCase)
        For Each obj In btn_pnl.Controls
            If obj.GetType Is GetType(ud_button) Then
                AddHandler CType(obj, ud_button).Click, AddressOf btn_Formule
            End If
        Next
        Filtre_txt.Text = Grd.FiltreStr
    End Sub
    Private Sub Filtre_txt_TextChanged(sender As Object, e As EventArgs) Handles Filtre_txt.TextChanged
        With Filtre_txt
            Dim selPos As Integer = .SelectionStart
            .SelectionStart = 0
            .Select(1, .TextLength)
            .SelectionColor = Color.Black
            .SelectionStart = 0
            For Each c As Match In rgFormule.Matches(.Text)
                .Select(c.Index, c.Length)
                .SelectionColor = Color.Pink
            Next
            For Each c As Match In rgChamps.Matches(.Text)
                .Select(c.Index, c.Length)
                .SelectionColor = Color.Blue
            Next
            .Focus()
            .Select()
            .SelectionStart = selPos
            .SelectionLength = 0

        End With
    End Sub
    Private Sub LvChamps_MouseClick(sender As Object, e As MouseEventArgs) Handles LvChamps.MouseClick
        If LvChamps.SelectedItems.Count = 0 Then Return
        Dim itm As ListViewItem = LvChamps.SelectedItems(0)
        With Filtre_txt
            Dim SelPos As Integer = .SelectionStart
            Dim ValeurNode As String = " [" & itm.Name & "] "
            .Text = .Text.Insert(SelPos, ValeurNode)
            .Focus()
            .Focus()
            .Select()
            .SelectionStart = SelPos + ValeurNode.Length
            .SelectionLength = 0
        End With

    End Sub
    Private Sub Filter_pb_Click(sender As Object, e As EventArgs) Handles Filter_pb.Click
        For i = 0 To Grd.ColumnCount - 1
            Grd.Columns(i).HeaderCell.Style.ForeColor = Color.FromArgb(0, 0, 0)
        Next
        Dim rg As New Regex("")
        'Ajouter les formule autorisées
        Formule.Add("\*")
        Formule.Add("Comme")
        Formule.Add("Différent")
        Formule.Add("Parmi")
        Formule.Add("Pas")
        Formule.Add("Ou")
        Formule.Add("Et")
        Formule.Add("x")
        FormuleRegStr.Add("%")
        FormuleRegStr.Add("Like")
        FormuleRegStr.Add("Not Like")
        FormuleRegStr.Add("IN")
        FormuleRegStr.Add("Not")
        FormuleRegStr.Add("Or")
        FormuleRegStr.Add("and")
        FormuleRegStr.Add("*")
        Dim strFiltre As String = Filtre_txt.Text.Trim.Replace("""", "'")
        For i = 0 To Formule.Count - 1
            rg = New Regex("(\b(" & Formule(i) & ")\b)", RegexOptions.IgnoreCase)
            strFiltre = rg.Replace(strFiltre, FormuleRegStr(i))
        Next

        Grd.FiltreStr = Filtre_txt.Text.Trim
        Try
            If Grd.FiltreStr <> "" Then
                Grd.DataSource.DefaultView.RowFilter = strFiltre
                oMnu.Checked = True
            Else
                Grd.DataSource.DefaultView.RowFilter = "1=1"
                oMnu.Checked = False
            End If

            For Each ct As Match In rgChamps.Matches(Filtre_txt.Text)
                Grd.Columns(ct.Value).HeaderCell.Style.ForeColor = Color.Red
            Next

            Me.Close()
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Erreur Filtre", MessageBoxButtons.OK, msgIcon.Warning)
        End Try
    End Sub

    Private Sub New_pb_Click(sender As Object, e As EventArgs) Handles New_pb.Click
        Filtre_txt.ResetText()
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Sub btn_Formule(sender As Object, e As EventArgs)
        With Filtre_txt
            Dim SelPos As Integer = .SelectionStart
            Dim ValeurNode As String = " " & sender.tag.trim & " "
            .Text = .Text.Insert(SelPos, ValeurNode)
            .Focus()
            .Focus()
            .Select()
            .SelectionStart = SelPos + IIf(ValeurNode.EndsWith("*'"), ValeurNode.Length - 2, IIf(ValeurNode.EndsWith("'"), ValeurNode.Length - 1, ValeurNode.Length))
            .SelectionLength = 0
        End With
    End Sub

End Class