Public Class Notifications_Consultation
    Sub Request()
        If Event_cbo.Items.Count = 0 Then Event_cbo.fromRubrique("Notif_event")
        Dim swhere As String = " where 1=1"
        Dim CosSql As String = "select Cod_Notification as 'Notification', Table_Ref as 'Table', Index_Table as 'Index', Val_Index as 'Valeur', Event as 'Evénement',
Dat_Event as 'Date', Notified as Notifié, Dat_Notif as 'Notifié le', Result as Résultat
from Notification_Events"
        If Event_cbo.Text <> "" Then
            swhere = swhere & " and isnull([Event],'') = '" & Event_cbo.SelectedValue & "'"
        End If
        If Table_Ref_txt.Text <> "" Then swhere &= " and Table_Ref='" & Table_Ref_txt.Text & "'"
        If Not All_chk.Checked Then swhere &= " and isnull(Notified,'false')='" & Notified_chk.Checked & "'"
        If Notified_chk.Checked And EstDate(Dat_Notif_Deb.Text) Then swhere &= " and isnull(Dat_Notified,'31/12/2099')>='" & CDate(Dat_Notif_Deb.Text).ToShortDateString & "'"
        If Notified_chk.Checked And EstDate(Dat_Notif_Deb.Text) Then swhere &= " and isnull(Dat_Notified,'31/12/2099')<='" & CDate(Dat_Notif_Fin.Text).ToShortDateString & "'"
        If Val_Index_txt.Text <> "" Then swhere &= " and isnull(Val_Index,'') like '" & Val_Index_txt.Text.Replace("'", "''").Replace("*", "%") & "'"
        CosSql &= swhere & vbCrLf & "Order by Dat_Event desc, Dat_Notif desc"

        Dim Tbl0 As DataTable = ChargerGrille(CosSql)
        With Grille
            .DataSource = Tbl0
            .Columns("Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Notifié le").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .setFilter({ .Columns("Résultat").Index, .Columns("Notification").Index, .Columns("Table").Index, .Columns("Valeur").Index, .Columns("Evénement").Index})

        End With

    End Sub

    Private Sub LinkLabel15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Event_cbo.SelectedIndex = -1
    End Sub
    Private Sub code_Client_Facture_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles code_Client_Facture.LinkClicked
        Appel_Zoom("Table_Ref", "Table_Ref", "Notifications", "1=1", Table_Ref_txt, Me)
    End Sub

    Private Sub Table_Ref_txt_TextChanged(sender As Object, e As EventArgs) Handles Table_Ref_txt.TextChanged
        Table_Index_txt.Text = findLibelle("Table_Index", "Table_Ref", Table_Ref_txt.Text, "Notifications")
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Appel_Zoom("Val_Index", "Table_Ref", "Notification_Events", "Table_Ref='" & Table_Ref_txt.Text & "'", Val_Index_txt, Me)
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked, LinkLabel1.LinkClicked, Du_Notif.LinkClicked, Au_Notif.LinkClicked
        Appel_Calender(sender, Me)
    End Sub

    Sub Requesting()
        Request()
    End Sub

    Private Sub Notifications_Consultation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Event_cbo.Items.Count = 0 Then Event_cbo.fromRubrique("Notif_event")
        Grille.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    End Sub
    Private Sub Notified_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Notified_chk.CheckedChanged
        Dat_Notif_Deb.Visible = Notified_chk.Checked
        Dat_Notif_Fin.Visible = Notified_chk.Checked
        Du_Notif.Visible = Notified_chk.Checked
        Au_Notif.Visible = Notified_chk.Checked
        If Not Notified_chk.Checked Then
            Dat_Notif_Deb.ResetText()
            Dat_Notif_Fin.ResetText()
        End If

    End Sub
End Class