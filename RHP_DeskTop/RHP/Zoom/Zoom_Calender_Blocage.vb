Public Class Zoom_Calender_Blocage
    Friend modul As String

    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub

    Private Sub MonthCalendar1_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        Dim datdebblocage As Date
        Dim datfinblocage As Date
        Dim datdebbloquageparametre As DateTime = Societe.DateDebPaie
        Dim datfinbloquageparametre As DateTime = Societe.DateFinPaie
        If Not EstDate(Societe.DateDebPaie) Then
            datdebbloquageparametre = "01/01/1905"
        End If
        If Not EstDate(Societe.DateFinPaie) Then
            datfinbloquageparametre = "01/01/2055"
        End If

        Dim Tbl As DataTable = DATA_READER_GRD("select min (Dat_Deb) as MinDat, Max(Dat_Fin) as MaxDat from Param_Periode_Paie where id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count > 0 Then
            datdebblocage = IsNull(Tbl.Rows(0)("MinDat"), datdebbloquageparametre)
            datfinblocage = IsNull(Tbl.Rows(0)("MaxDat"), datfinbloquageparametre)
        Else
            datdebblocage = datdebbloquageparametre
            datfinblocage = datfinbloquageparametre
        End If

        If EstDate(datdebbloquageparametre) Then
            If datdebblocage < datdebbloquageparametre Then
                datdebblocage = datdebbloquageparametre
            End If
        End If
        If EstDate(datfinbloquageparametre) Then
            If datfinblocage < datfinbloquageparametre Then
                datfinblocage = datfinbloquageparametre
            End If
        End If
        If datdebblocage <= CDate(Droits.DatDebContrat) Then
            datdebblocage = CDate(Droits.DatDebContrat)
        End If
        If datfinblocage >= CDate(Droits.DatFinContrat) Then
            datfinblocage = CDate(Droits.DatFinContrat)
        End If

ApplyDateBlocage:
        If e.Start.Date < datdebblocage Or e.Start.Date > datfinblocage Then
            MessageBoxRHP(207, datdebblocage & ";" & datfinblocage)
            Exit Sub
        End If
        Select Case Zoom_Object.GetType.Name
            Case "TextBox", "ud_TextBox"
                Zoom_Object.Text = FormatDateTime(e.Start.Date, DateFormat.ShortDate)
            Case "DataGridViewTextBoxCell"
                Zoom_Object.value = FormatDateTime(e.Start.Date, DateFormat.ShortDate)
        End Select
        Me.Close()
    End Sub


    Private Sub Calender_Blocage_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Zoom_Calender_Blocage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            '    .DisplayMonth = oDate
        End With

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

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class