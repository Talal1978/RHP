Imports System.Net.Mail
Imports System.Text
Module Module_Envoi_Mail
    Function envoiDeMail(oSmtpServer As System.Net.Mail.SmtpClient, fromStr As String, ByVal ToAdress As String, ByVal CcAdress As String,
                           ByVal titre As String, ByVal corps As String, Optional Attachement As ArrayList = Nothing, Optional RepondreA As String = "",
                         Optional CCiAdress As String = "", Optional asAgenda As Boolean = False, Optional Deb As Date = Nothing, Optional Fin As Date = Nothing) As Boolean
        Try
            If oSmtpServer Is Nothing OrElse String.IsNullOrWhiteSpace(oSmtpServer.Host) OrElse oSmtpServer.Port = 0 Then
                WriteLog("Paramètres SMTP manquants", "SMTP", True)
                Return False
            End If

            ToAdress = ToAdress.Replace(",", ";")
            CcAdress = CcAdress.Replace(",", ";")
            CCiAdress = CCiAdress.Replace(",", ";")
            RepondreA = RepondreA.Replace(",", ";")
            Dim addr() As String = ToAdress.Split(";")
            Dim Cc() As String = CcAdress.Split(";")
            Dim Cci() As String = CCiAdress.Split(";")
            Dim Rply() As String = RepondreA.Split(";")

            Using oMail As New System.Net.Mail.MailMessage()
                oMail.IsBodyHtml = True
                For Each a In addr
                    If Not String.IsNullOrWhiteSpace(a) Then oMail.To.Add(a)
                Next
                For Each a In Cc
                    If Not String.IsNullOrWhiteSpace(a) Then oMail.CC.Add(a)
                Next
                For Each a In Cci
                    If Not String.IsNullOrWhiteSpace(a) Then oMail.Bcc.Add(a)
                Next
                For Each a In Rply
                    If Not String.IsNullOrWhiteSpace(a) Then oMail.ReplyToList.Add(a)
                Next

                oSmtpServer.Timeout = 20000  ' 20 s
                oMail.Subject = titre
                oMail.From = New MailAddress(fromStr, "RHP ERP", System.Text.Encoding.UTF8)
                If Not Attachement Is Nothing Then
                    For i = 0 To Attachement.Count - 1
                        oMail.Attachments.Add(New Attachment(Attachement(i)))
                    Next
                End If
                oMail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                If asAgenda Then
                    oMail.AlternateViews.Clear()
                    Dim str As StringBuilder = New StringBuilder()
                    str.AppendLine("BEGIN:VCALENDAR")
                    str.AppendLine("PRODID:-//Schedule a Meeting")
                    str.AppendLine("VERSION:2.0")
                    str.AppendLine("METHOD:REQUEST")
                    str.AppendLine("BEGIN:VEVENT")
                    str.AppendLine(String.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", Deb))
                    str.AppendLine(String.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.Now))
                    str.AppendLine(String.Format("DTEND:{0:yyyyMMddTHHmmssZ}", Fin))
                    ' str.AppendLine("LOCATION: " & Me.Location)
                    str.AppendLine(String.Format("UID:{0}", Guid.NewGuid()))
                    str.AppendLine(String.Format("DESCRIPTION:{0}", corps))
                    str.AppendLine(String.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", titre))
                    str.AppendLine(String.Format("SUMMARY:{0}", titre))
                    str.AppendLine(String.Format("ORGANIZER:MAILTO:{0}", oMail.From.Address))
                    For i = 0 To oMail.To.Count - 1
                        str.AppendLine(String.Format("ATTENDEE;CN=""{0}"";RSVP=TRUE:mailto:{1}", oMail.[To](i).DisplayName, oMail.[To](i).Address))
                    Next
                    str.AppendLine("BEGIN:VALARM")
                    str.AppendLine("TRIGGER:-PT15M")
                    str.AppendLine("ACTION:DISPLAY")
                    str.AppendLine("DESCRIPTION:Reminder")
                    str.AppendLine("END:VALARM")
                    str.AppendLine("END:VEVENT")
                    str.AppendLine("END:VCALENDAR")
                    Dim contype As System.Net.Mime.ContentType = New System.Net.Mime.ContentType("text/calendar")
                    contype.Parameters.Add("method", "REQUEST")
                    contype.Parameters.Add("name", "event.ics")
                    Dim avCal As AlternateView = AlternateView.CreateAlternateViewFromString(str.ToString(), contype)
                    oMail.AlternateViews.Add(avCal)
                Else
                    corps = corps.Replace(vbCrLf, "<BR>").Replace(vbCr, "<BR>").Replace(vbLf, "<BR>").Replace("\n", "<BR>").Replace(Chr(13), "<BR>")
                End If

                oMail.Body = corps
                oSmtpServer.Send(oMail)
            End Using
            For i = 0 To Attachement.Count - 1
                FileToDelete.Add(Attachement(i))
            Next
            Return True
        Catch ex As Exception
            WriteLog("Erreur 108: envoi message : " & vbCrLf & ex.Message)
            Return False
        End Try
    End Function
    Function convertToHTML(ByVal Box As RichTextBox) As String
        ' Takes a RichTextBox control and returns a
        ' simple HTML-formatted version of its contents
        Dim strHTML As String
        Dim strColour As String
        Dim blnBold As Boolean
        Dim blnItalic As Boolean
        Dim strFont As String
        Dim shtSize As Short
        Dim lngOriginalStart As Long
        Dim lngOriginalLength As Long
        Dim intCount As Integer
        ' If nothing in the box, exit
        If Box.Text.Length = 0 Then
            Return ""
            Exit Function
        End If
        ' Store original selections, then select first character
        lngOriginalStart = 0
        lngOriginalLength = Box.TextLength
        Box.Select(0, 1)
        ' Add HTML header
        strHTML = "<html>"
        ' Set up initial parameters
        strColour = Box.SelectionColor.ToKnownColor.ToString
        blnBold = Box.SelectionFont.Bold
        blnItalic = Box.SelectionFont.Italic
        strFont = Box.SelectionFont.FontFamily.Name
        shtSize = Box.SelectionFont.Size
        ' Include first 'style' parameters in the HTML
        strHTML += "<span style=""font-family: " & strFont &
          "; font-size: " & shtSize & "pt; color: " _
                          & strColour & """>"
        ' Include bold tag, if required
        If blnBold = True Then
            strHTML += "<b>"
        End If
        ' Include italic tag, if required
        If blnItalic = True Then
            strHTML += "<i>"
        End If
        ' finally, add our first character
        strHTML += Box.Text.Substring(0, 1)
        ' Loop around all remaining characters
        For intCount = 2 To Box.Text.Length
            ' Select current character
            Box.Select(intCount - 1, 1)
            ' If this is a line break, add HTML tag
            If Box.Text.Substring(intCount - 1, 1) =
                   Convert.ToChar(10) Then
                strHTML += "<br>"
            End If
            ' Check/implement any changes in style
            If Box.SelectionColor.ToKnownColor.ToString <>
               strColour Or Box.SelectionFont.FontFamily.Name _
               <> strFont Or Box.SelectionFont.Size <> shtSize _
               Then
                strHTML += "</span><span style=""font-family: " _
                  & Box.SelectionFont.FontFamily.Name &
                  "; font-size: " & Box.SelectionFont.Size &
                  "pt; color: " &
                  Box.SelectionColor.ToKnownColor.ToString & """>"
            End If
            ' Check for bold changes
            '   If Box.SelectionFont.Bold <> blnBold Then
            If Box.SelectionFont.Bold = False Then
                strHTML += "</b>"
            Else
                strHTML += "<b>"
            End If
            '   end If
            ' Check for italic changes
            If Box.SelectionFont.Italic <> blnItalic Then
                If Box.SelectionFont.Italic = False Then
                    strHTML += "</i>"
                Else
                    strHTML += "<i>"
                End If
            End If
            ' Add the actual character
            strHTML += Mid(Box.Text, intCount, 1)
            ' Update variables with current style
            strColour = Box.SelectionColor.ToKnownColor.ToString
            blnBold = Box.SelectionFont.Bold
            blnItalic = Box.SelectionFont.Italic
            strFont = Box.SelectionFont.FontFamily.Name
            shtSize = Box.SelectionFont.Size
        Next
        ' close off any open bold/italic tags
        If blnBold = True Then strHTML += ""
        If blnItalic = True Then strHTML += ""
        ' Terminate outstanding HTML tags
        strHTML += "</span></html>"
        ' Restore original RichTextBox selection
        Box.Select(lngOriginalStart, lngOriginalLength)
        ' Return HTML
        Return strHTML
    End Function
    Function encodeToHtml(ByVal str) As String
        str = str.replace(Chr(34), "&quot;")
        str = str.replace("<", "&lt;")
        str = str.replace(">", "&gt;")
        str = str.replace("€", "&euro;")
        str = str.replace("‡", "&Dagger;")
        str = str.replace("‹", "&lt;")
        str = str.replace("›", "&gt;")
        str = str.replace("œ", "&oelig;")
        str = str.replace(Chr(16), "&nbsp;")
        str = str.replace("¢", "&cent;")
        str = str.replace("£", "&pound;")
        str = str.replace("¥", "&yen;")
        str = str.replace("¦", "&brvbar;")
        str = str.replace("§", "&sect;")
        str = str.replace("©", "&copy;")
        str = str.replace("«", "&laquo;")
        str = str.replace("®", "&reg;")
        str = str.replace("°", "&deg;")
        str = str.replace("±", "&plusmn;")
        str = str.replace("´", "&acute;")
        str = str.replace("µ", "&micro;")
        str = str.replace("»", "&raquo;")
        str = str.replace("¼", "&frac14;")
        str = str.replace("½", "&frac12;")
        str = str.replace("¾", "&frac34;")
        str = str.replace("À", "&Agrave;")
        str = str.replace("Á", "&Aacute;")
        str = str.replace("Â", "&Acirc;")
        str = str.replace("Ã", "&Atilde;")
        str = str.replace("Ä", "&Auml;")
        str = str.replace("Å", "&Aring;")
        str = str.replace("Æ", "&AElig;")
        str = str.replace("Ç", "&Ccedil;")
        str = str.replace("È", "&Egrave;")
        str = str.replace("É", "&Eacute;")
        str = str.replace("Ê", "&Ecirc;")
        str = str.replace("Ë", "&Euml;")
        str = str.replace("Ì", "&Igrave;")
        str = str.replace("Í", "&Iacute;")
        str = str.replace("Î", "&Icirc;")
        str = str.replace("Ï", "&Iuml;")
        str = str.replace("Ñ", "&Ntilde;")
        str = str.replace("Ò", "&Ograve;")
        str = str.replace("Ó", "&Oacute;")
        str = str.replace("Ô", "&Ocirc;")
        str = str.replace("Õ", "&Otilde;")
        str = str.replace("Ö", "&Ouml;")
        str = str.replace("×", "&times;")
        str = str.replace("Ø", "&Oslash;")
        str = str.replace("Ù", "&Ugrave;")
        str = str.replace("Ú", "&Uacute;")
        str = str.replace("Û", "&Ucirc;")
        str = str.replace("Ü", "&Uuml;")
        str = str.replace("ß", "&szlig;")
        str = str.replace("à", "&agrave;")
        str = str.replace("á", "&aacute;")
        str = str.replace("â", "&acirc;")
        str = str.replace("ã", "&atilde;")
        str = str.replace("ä", "&auml;")
        str = str.replace("å", "&aring;")
        str = str.replace("æ", "&aelig;")
        str = str.replace("ç", "&ccedil;")
        str = str.replace("è", "&egrave;")
        str = str.replace("é", "&eacute;")
        str = str.replace("ê", "&ecirc;")
        str = str.replace("ë", "&euml;")
        str = str.replace("ì", "&igrave;")
        str = str.replace("í", "&iacute;")
        str = str.replace("î", "&icirc;")
        str = str.replace("ï", "&iuml;")
        str = str.replace("ð", "&eth;")
        str = str.replace("ñ", "&ntilde;")
        str = str.replace("ò", "&ograve;")
        str = str.replace("ó", "&oacute;")
        str = str.replace("ô", "&ocirc;")
        str = str.replace("õ", "&otilde;")
        str = str.replace("ö", "&ouml;")
        str = str.replace("÷", "&divide;")
        str = str.replace("ø", "&oslash;")
        str = str.replace("ù", "&ugrave;")
        str = str.replace("ú", "&uacute;")
        str = str.replace("û", "&ucirc;")
        str = str.replace("ü", "&uuml;")


        'Saut de ligne
        str = str.replace(Chr(13), "@@@espace")
        Return str
    End Function
End Module
