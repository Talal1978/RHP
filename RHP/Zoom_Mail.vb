Imports System.Net.Mail
Imports System.Text.RegularExpressions
Public Class Zoom_Mail
    Friend PJList As New ArrayList
    Dim imageList1 As New ImageList()
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Envoyer_pb.Click
        If Not estEmail(Reply_To_Text.Text) Then
            ShowMessageBox("Veuillez renseigner le champs : [ Répondre à ]", "Vérification", MessageBoxButtons.OK)
            Return
        End If
        If Text_Text.Text.Trim = "" Then
            If ShowMessageBox("Votre mail est sans contenu. Voulez-vous continuer", "Vérification", MessageBoxButtons.OKCancel, msgIcon.Warning) = MsgBoxResult.Cancel Then
                Return
            End If
        End If
        If Object_Text.Text.Trim = "" Then
            If ShowMessageBox("L'objet de Votre mail est vide. Voulez-vous continuer", "Vérification", MessageBoxButtons.OKCancel, msgIcon.Warning) = MsgBoxResult.Cancel Then
                Return
            End If
        End If
        Me.Cursor = Cursors.WaitCursor
        MajSmtp()
        oMail.Attachments.Clear()
        oMail.To.Clear()
        oMail.CC.Clear()
        oMail.ReplyToList.Clear()
        Dim addr() As String = To_Text.Text.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        Try
            For i = 0 To addr.Length - 1
                If Not oMail.To.Contains(New MailAddress(CStr(addr(i)).Trim)) Then oMail.To.Add(CStr(addr(i)).Trim)
            Next
            If CC_Text.Text <> "" Then
                addr = CC_Text.Text.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                For i = 0 To addr.Length - 1
                    oMail.CC.Add(CStr(addr(i)).Trim)
                Next
            End If
            If CCi_Text.Text <> "" Then
                addr = CCi_Text.Text.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                For i = 0 To addr.Length - 1
                    oMail.Bcc.Add(CStr(addr(i)).Trim)
                Next
            End If
            If Reply_To_Text.Text <> "" Then
                oMail.ReplyToList.Add(New MailAddress(Reply_To_Text.Text))
            End If
            oMail.Subject = Object_Text.Text
            oMail.Body = "<BODY>" & EncodeToHtml(Text_Text.Text) & "</BODY>"
            oMail.Body = oMail.Body.Replace("@@@espace", "<BR/>")
            oMail.IsBodyHtml = True

            If PJ_List.Items.Count <> 0 Then
                For i = 0 To PJList.Count - 1
                    oMail.Attachments.Add(New Attachment(PJList(i)))
                Next
            End If
            oMail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            oMail.ReplyToList.Add(New MailAddress(Reply_To_Text.Text))
            oSmtpServer.Send(oMail)

            oMail.Attachments.Clear()
            oMail.To.Clear()
            oMail.CC.Clear()
            Me.Close()
        Catch ex As Exception
            MessageBoxRHP(183)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Zoom_Mail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PJ_List.SmallImageList = imageList1
            Dim ReplyTo As String = IsNull(theUser.Mail, FindLibelle("Mail", "id_User", theUser.id_User, "Controle_Users"))
            If ReplyTo.Trim = "" Then ReplyTo = FindLibelle("Mail", "1", 1, "Controle_Societe")
            If Reply_To_Text.Text = "" Then Reply_To_Text.Text = ReplyTo.Trim
            MajPJList()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Private Sub RemovePJ_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Try
            With PJ_List
                If .Items.Count = 0 Then Exit Sub
                For Each c In .CheckedIndices
                    .Items.Remove(c)
                Next
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Function EstEmailValid(str As String) As Boolean
        Dim estValide As Boolean = False
        Dim rg As New Regex("\b(\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\b")
        Return rg.IsMatch(str)
    End Function
    Function ExtraireEmailValid(str As String) As String
        Dim estValide As Boolean = False
        Dim lesemails As String = ""
        Dim rg As New Regex("\b(\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\b")
        For Each c As Match In rg.Matches(str)
            If Not lesemails.Contains(c.Value) Then lesemails &= IIf(lesemails = "", "", ";") & c.Value
        Next
        Return lesemails
    End Function

    Private Sub To_Text_Validated(sender As Object, e As System.EventArgs) Handles To_Text.Validated
        To_Text.Text = ExtraireEmailValid(To_Text.Text)
    End Sub

    Private Sub From_Text_Validated(sender As Object, e As System.EventArgs) Handles Reply_To_Text.Validated, CC_Text.Validated, To_Text.Validated
        If sender.text.trim = "" Then Return
        sender.Text = ExtraireEmailValid(sender.Text).Trim
        If sender.name = "Reply_To_Text" Then
            If sender.Text.trim <> "" Then sender.Text = sender.Text.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(0)
        End If
    End Sub
    Sub MajPJList()
        PJ_List.BeginUpdate()
        Dim Fichier As String = ""
        Dim iconForFile As Icon = SystemIcons.WinLogo
        With PJList
            PJ_List.Items.Clear()
            For i = 0 To .Count - 1
                Fichier = IsNull(PJList(i), "")
                If IO.File.Exists(Fichier) Then
                    Dim fi As IO.FileInfo = New IO.FileInfo(Fichier)
                    Dim oItm As New ListViewItem
                    oItm.Text = fi.Name
                    oItm.Name = fi.Name
                    oItm.Tag = Fichier
                    If Not (imageList1.Images.ContainsKey(fi.Extension)) Then
                        ' If not, add the image to the image list.
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
                        imageList1.Images.Add(fi.Extension, iconForFile)
                    End If
                    oItm.ImageKey = fi.Extension
                    If Not PJ_List.Items.Contains(oItm) Then PJ_List.Items.Add(oItm)
                End If
            Next
        End With
        PJ_List.EndUpdate()
    End Sub

    Private Sub PJ_List_Click(sender As Object, e As System.EventArgs) Handles PJ_List.DoubleClick
        Try
            If PJ_List.SelectedItems.Count > 0 Then
                StartPrograme(PJ_List.SelectedItems(0).Tag)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Private Sub PJ_List_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles PJ_List.KeyUp
        If e.KeyData = Keys.Delete Then
            For i = PJ_List.SelectedItems.Count - 1 To 0 Step -1
                PJList.Remove(PJ_List.SelectedItems(i).Tag)
                PJ_List.Items.Remove(PJ_List.SelectedItems(i))
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Attn_lbl.Click
        Dim otxt As New TextBox
        otxt.Visible = False
        otxt.Location = To_Text.Location
        Me.Controls.Add(otxt)
        Appel_Zoom("Email", "upper(Nom_Clt)+' : '+isnull(Prenom_Contact,'')+ ' '+isnull(Nom_Contact,'')", "Sys_Part_Tiers_Contact", "IsNull(Email,'')<>''", otxt, Me)
        To_Text.Text &= IIf(To_Text.Text.Trim = "", "", ";") & otxt.Text
        Me.Controls.Remove(otxt)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Cc_lbl.Click
        Dim otxt As New TextBox
        otxt.Visible = False
        otxt.Location = CC_Text.Location
        Me.Controls.Add(otxt)
        Appel_Zoom("Email", "upper(Nom_Clt)+' : '+isnull(Prenom_Contact,'')+ ' '+isnull(Nom_Contact,'')", "Sys_Part_Tiers_Contact", "IsNull(Email,'')<>''", otxt, Me)
        CC_Text.Text &= IIf(CC_Text.Text.Trim = "", "", ";") & otxt.Text
        Me.Controls.Remove(otxt)
    End Sub

    Private Sub PJ_pb_Click(sender As Object, e As EventArgs) Handles PJ_pb.Click
        OpenFileDialog1.AutoUpgradeEnabled = False
        OpenFileDialog1.InitialDirectory = importPath
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            importPath = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
            If Not PJList.Contains(OpenFileDialog1.FileName) Then
                PJList.Add(OpenFileDialog1.FileName)
                MajPJList()
            End If
        End If
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class