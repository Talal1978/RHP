Imports System.Net.Mail
Public Class Admin_Messagerie
    Friend TestSmtpServer As New SmtpClient()
    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_pb.Click
        If Mail_Addr_Text.Text = "" Then
            MessageBoxRHP(345)
            Mail_Addr_Text.Select()
            Exit Sub
        End If
        If Nom_Prenom_Text.Text = "" Then
            MessageBoxRHP(345)
            Nom_Prenom_Text.Select()
            Exit Sub
        End If
        If Pwd_Mail_Text.Text = "" Then
            MessageBoxRHP(345)
            Pwd_Mail_Text.Select()
            Exit Sub
        End If
        If Smtp_Mail_Text.Text = "" Then
            MessageBoxRHP(345)
            Smtp_Mail_Text.Select()
            Exit Sub
        End If
        If Port_Mail.Value = 0 Then
            MessageBoxRHP(346)
            Exit Sub
        End If
        If Mail_From_Text.Text = "" Then
            MessageBoxRHP(345)
            Mail_From_Text.Select()
            Exit Sub
        End If
        'test des paramètres
        TestSmtpServer = oSmtpServer
        oMail.From = New MailAddress(Mail_From_Text.Text, Nom_Prenom_Text.Text, System.Text.Encoding.UTF8)
        oSmtpServer.Credentials = New Net.NetworkCredential(Mail_Addr_Text.Text, Pwd_Mail_Text.Text)
        oSmtpServer.Port = Port_Mail.Value
        oSmtpServer.Host = Smtp_Mail_Text.Text
        oSmtpServer.EnableSsl = Ssl_Actif.Checked
        If Not EnvoiDeMail(Mail_Addr_Text.Text, Mail_Addr_Text.Text, "Test Envoi de Mail", Test_Mail_Text.Text) Then
            MessageBoxRHP(347)
            oSmtpServer = TestSmtpServer
            Exit Sub
        End If
        CnExecuting("delete from Controle_Messagerie")
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Controle_Messagerie", cn, 2, 2)
        rs.AddNew()
        rs("Mail_Addr").Value = Mail_Addr_Text.Text
        rs("Nom_Prenom").Value = Nom_Prenom_Text.Text
        rs("Pwd_Mail").Value = Encrypt(Pwd_Mail_Text.Text)
        rs("Smtp_Mail").Value = Smtp_Mail_Text.Text
        rs("Port_Mail").Value = Port_Mail.Value
        rs("Ssl_Actif").Value = Ssl_Actif.Checked
        rs("Mail_From").Value = Mail_From_Text.Text
        rs.Update()
        rs.Close()
        MessageBoxRHP(1)
    End Sub

    Private Sub TestMail_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestMail_pb.Click
        EnvoiTest()
    End Sub
    Sub EnvoiTest()
        TestSmtpServer = oSmtpServer
        oMail.From = New MailAddress(Mail_From_Text.Text, Nom_Prenom_Text.Text, System.Text.Encoding.UTF8)
        oSmtpServer.Credentials = New Net.NetworkCredential(Mail_Addr_Text.Text, Pwd_Mail_Text.Text)
        oSmtpServer.Port = Port_Mail.Value
        oSmtpServer.Host = Smtp_Mail_Text.Text
        oSmtpServer.EnableSsl = Ssl_Actif.Checked
        If EnvoiDeMail(Mail_Addr_Text.Text, Mail_Addr_Text.Text, "Test Envoi de Mail", Test_Mail_Text.Text) Then
            MessageBoxRHP(348)
        Else
            MessageBoxRHP(349)
        End If
        oSmtpServer = TestSmtpServer
    End Sub

    Private Sub Admin_Messagerie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Requesting()
    End Sub
    Sub Requesting()
        Dim Messagerie As DataTable = DATA_READER_GRD("select * from Controle_Messagerie")
        If Messagerie.Rows.Count > 0 Then
            Mail_Addr_Text.Text = Messagerie.Rows(0).Item("Mail_Addr")
            Nom_Prenom_Text.Text = Messagerie.Rows(0).Item("Nom_Prenom")
            Pwd_Mail_Text.Text = Decrypt(Messagerie.Rows(0).Item("Pwd_Mail"))
            Smtp_Mail_Text.Text = Messagerie.Rows(0).Item("Smtp_Mail")
            Port_Mail.Value = Messagerie.Rows(0).Item("Port_Mail")
            Ssl_Actif.Checked = Messagerie.Rows(0).Item("Ssl_Actif")
            Mail_From_Text.Text = Messagerie.Rows(0).Item("Mail_From")
        End If
    End Sub

    Private Sub New_D_Click(sender As Object, e As EventArgs) Handles New_pb.Click
        Reset_Form(Me, False)
    End Sub
    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub Del_pb_Click(sender As Object, e As EventArgs) Handles Del_pb.Click
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer le paramétrage actuel de votre serveur SMTP?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from Controle_Messagerie")
        Reset_Form(Me, False)
    End Sub
End Class