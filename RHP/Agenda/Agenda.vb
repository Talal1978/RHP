Imports DevComponents.DotNetBar.Schedule
Imports DevComponents.Schedule.Model
Public Class Agenda
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        Tout_chk.Visible = (theUser.Typ_Role <> "Agent")
    End Sub
    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Matricule_txt, Me)
        End If
    End Sub
    Private Sub Cod_Rep_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Matricule_txt.TextChanged
        Nom_Pilote_Text.Text = FindLibelle("Prenom_Agent+ ' ' + Nom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        Request()
    End Sub
    Public Structure Agenda_Evenement
        Public Evenement As String
        Public Code As String
        Public Statut As String
        Public Tiers As String
        Public Genre As String
        Public Nature As String
        Public Budget As Double
    End Structure
    Sub Request()
        Try

            Dim TblTo As DataTable = DATA_READER_GRD("exec Sys_Agenda '" & Matricule_txt.Text & "'," & Societe.id_Societe)
            CalendarView1.CalendarModel.Appointments.Clear()
            With TblTo
                For i = 0 To .Rows.Count - 1
                    Dim appointment As New Appointment()
                    Dim ag_ev As New Agenda_Evenement
                    With ag_ev
                        .Code = TblTo.Rows(i)("Code")
                        .Evenement = TblTo.Rows(i)("Evenement")
                        .Nature = TblTo.Rows(i)("Nature")
                        .Budget = TblTo.Rows(i)("Budget")
                        .Statut = TblTo.Rows(i)("Statut")
                        .Tiers = TblTo.Rows(i)("Tiers")
                    End With
                    With appointment
                        .Tag = ag_ev
                        .StartTime = CType(TblTo.Rows(i)("Dat_Du"), DateTime)
                        .EndTime = CType(TblTo.Rows(i)("Dat_Au"), DateTime)
                        .Subject = TblTo.Rows(i)("sujet")
                        .Description = TblTo.Rows(i)("Libelle").ToString.Replace("|", vbCrLf)
                        .Locked = True
                        Select Case TblTo.Rows(i)("Couleur")
                            Case "CategoryBlue"
                                appointment.CategoryColor = Appointment.CategoryBlue
                            Case "CategoryGreen"
                                appointment.CategoryColor = Appointment.CategoryGreen
                            Case "CategoryOrange"
                                appointment.CategoryColor = Appointment.CategoryOrange
                            Case "CategoryPurple"
                                appointment.CategoryColor = Appointment.CategoryPurple
                            Case "CategoryRed"
                                appointment.CategoryColor = Appointment.CategoryRed
                            Case "CategoryYellow"
                                appointment.CategoryColor = Appointment.CategoryYellow
                            Case Else
                                appointment.CategoryColor = Appointment.CategoryDefault
                        End Select
                        ' appointment.TimeMarkedAs = marker
                        appointment.Tooltip = TblTo.Rows(i)("tooltip").ToString.Replace("|", vbCrLf)
                    End With
                    CalendarView1.CalendarModel.Appointments.Add(appointment)
                Next
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CalendarView1_ItemClick(sender As Object, e As EventArgs) Handles CalendarView1.ItemDoubleClick
        If CalendarView1.SelectedAppointments.Count > 0 Then
            Dim app As Appointment = CalendarView1.SelectedAppointments(0).Appointment
            With app
                If .Tag IsNot Nothing Then
                    If .Tag.GetType = GetType(Agenda_Evenement) Then
                        Cursor = Cursors.WaitCursor
                        Select Case CType(.Tag, Agenda_Evenement).Evenement
                            Case "Formation"
                                Dim f As New Formation
                                newShowEcran(f)
                                f.Cod_Formation_txt.Text = CType(.Tag, Agenda_Evenement).Code
                            Case "RC_Evaluateur"
                                Dim f As New Recrutement
                                newShowEcran(f)
                                f.Num_RC_txt.Text = CType(.Tag, Agenda_Evenement).Code
                        End Select
                        Cursor = Cursors.Default
                    End If
                End If
            End With
        Else
            If CalendarView1.SelectedView = eCalendarView.Month Then
                CalendarView1.SelectedView = eCalendarView.Day
            End If
        End If
    End Sub

    Private Sub Tout_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Tout_chk.CheckedChanged
        If Tout_chk.Checked Then
            Matricule_txt.Text = "*"
            Nom_Pilote_Text.Text = Tout_chk.Text
        Else
            Matricule_txt.Text = ""
            Nom_Pilote_Text.Text = ""
        End If
    End Sub

    Private Sub Jour_lbl_Click(sender As Object, e As EventArgs) Handles Jour_lbl.Click
        CalendarView1.SelectedView = eCalendarView.Day
        CheckAgendaView(Jour_lbl)
    End Sub
    Private Sub semaine_lbl_Click(sender As Object, e As EventArgs) Handles Semaine_lbl.Click
        CalendarView1.SelectedView = eCalendarView.Week
        CheckAgendaView(Semaine_lbl)
    End Sub
    Private Sub Mois_lbl_Click(sender As Object, e As EventArgs) Handles Mois_lbl.Click
        CalendarView1.SelectedView = eCalendarView.Month
        CheckAgendaView(Mois_lbl)
    End Sub
    Private Sub TimeLine_lbl_Click(sender As Object, e As EventArgs) Handles TimeLine_lbl.Click
        CalendarView1.SelectedView = eCalendarView.TimeLine
        CheckAgendaView(TimeLine_lbl)
    End Sub
    Sub CheckAgendaView(btnStr As Label)
        With Mois_lbl
            If Mois_lbl Is btnStr Then
                .Font = New System.Drawing.Font("Century Gothic", 8.25!, FontStyle.Bold Or FontStyle.Underline)
                .ForeColor = System.Drawing.Color.FromArgb(240, 90, 10)
            Else
                .Font = New System.Drawing.Font("Century Gothic", 8.25!, FontStyle.Bold)
                .ForeColor = System.Drawing.Color.FromArgb(56, 153, 185)
            End If
        End With
        With Semaine_lbl
            If Semaine_lbl Is btnStr Then
                .Font = New System.Drawing.Font("Century Gothic", 8.25!, FontStyle.Bold Or FontStyle.Underline)
                .ForeColor = System.Drawing.Color.FromArgb(240, 90, 10)
            Else
                .Font = New System.Drawing.Font("Century Gothic", 8.25!, FontStyle.Bold)
                .ForeColor = System.Drawing.Color.FromArgb(56, 153, 185)
            End If
        End With
        With Jour_lbl
            If Jour_lbl Is btnStr Then
                .Font = New System.Drawing.Font("Century Gothic", 8.25!, FontStyle.Bold Or FontStyle.Underline)
                .ForeColor = System.Drawing.Color.FromArgb(240, 90, 10)
            Else
                .Font = New System.Drawing.Font("Century Gothic", 8.25!, FontStyle.Bold)
                .ForeColor = System.Drawing.Color.FromArgb(56, 153, 185)
            End If
        End With
        With TimeLine_lbl
            If TimeLine_lbl Is btnStr Then
                .Font = New System.Drawing.Font("Century Gothic", 8.25!, FontStyle.Bold Or FontStyle.Underline)
                .ForeColor = System.Drawing.Color.FromArgb(240, 90, 10)
            Else
                .Font = New System.Drawing.Font("Century Gothic", 8.25!, FontStyle.Bold)
                .ForeColor = System.Drawing.Color.FromArgb(56, 153, 185)
            End If
        End With

    End Sub
End Class
