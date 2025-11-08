Public Class Zoom_Calender

    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Calender_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Zoom_Calender_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
        Dim oDate As Date = Now
        Select Case Zoom_Object.GetType.Name
            Case "TextBox", "ud_TextBox"
                If EstDate(Zoom_Object.Text) Then oDate = CDate(Zoom_Object.Text)
            Case "DataGridViewTextBoxCell"
                If EstDate(Zoom_Object.value) Then oDate = CDate(Zoom_Object.value)
        End Select
        With MonthCalendar1
            .SetDate(oDate)
        End With


    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub Annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Effacer_pb.Click
        Me.Close()
        Select Case Zoom_Object.GetType.Name
            Case "TextBox", "ud_TextBox"
                Zoom_Object.Text = ""
            Case "DataGridViewTextBoxCell"
                Zoom_Object.value = ""
        End Select
    End Sub

    Private Sub MonthCalendarAdv1_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateSelected

        Select Case Zoom_Object.GetType.Name
            Case "TextBox", "ud_TextBox"
                Zoom_Object.Text = FormatDateTime(MonthCalendar1.SelectionStart, DateFormat.ShortDate)
            Case "DataGridViewTextBoxCell"
                Zoom_Object.value = FormatDateTime(MonthCalendar1.SelectionStart, DateFormat.ShortDate)
        End Select
        Me.Close()
    End Sub


End Class