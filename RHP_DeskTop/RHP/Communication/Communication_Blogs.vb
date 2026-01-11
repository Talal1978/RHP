Imports System.Text.RegularExpressions
Imports System.IO

Public Class Communication_Blogs
    Implements IMessageFilter

    Private Const WM_KEYDOWN As Integer = &H100

    ' Controls are defined in Communication_Blogs.Designer.vb
    Sub ChargementCombo()
        If Categorie_Combo.Items.Count = 0 Then Categorie_Combo.fromRubrique("Categorie_Blog")
    End Sub
    Private Sub Communication_Blogs_Load(sender As Object, e As EventArgs) Handles Me.Load
        ChargementCombo()
        Application.AddMessageFilter(Me) ' Register Global Key Trap

        ' Initialize WebBrowser for Editing
        WebBrowser1.DocumentText = "<html><body></body></html>"
        WebBrowser1.ScriptErrorsSuppressed = True
        WebBrowser1.AllowWebBrowserDrop = False ' Fix for DRAGDROP_E_NOTREGISTERED
    End Sub

    Private Sub Communication_Blogs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.RemoveMessageFilter(Me) ' Cleanup
    End Sub

    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        If m.Msg = WM_KEYDOWN Then
            Dim key As Keys = CType(m.WParam.ToInt32(), Keys)
            If key = Keys.V AndAlso (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                ' Ctrl+V Detected
                ' Check if we are in a text field (Let default paste happen)
                If Titre_Blog_Text.ContainsFocus OrElse Tags_Text.ContainsFocus OrElse Num_Blog_txt.ContainsFocus OrElse Categorie_Combo.ContainsFocus Then
                    Return False
                End If

                ' Otherwise, assume Editor -> SmartPaste
                ' Use BeginInvoke to exit the Message Filter loop before calling OLE methods
                Me.BeginInvoke(Sub() SmartPaste())
                Return True ' Block standard paste
            End If
        End If
        Return False
    End Function

    Sub Request()
        ChargementCombo()
        Dim dt As DataTable = DATA_READER_GRD("SELECT * FROM Communication_Blogs WHERE Num_Blog='" & Num_Blog_txt.Text & "'")
        If dt.Rows.Count > 0 Then
            Titre_Blog_Text.Text = dt.Rows(0)("Titre_Blog").ToString()
            Categorie_Combo.SelectedValue = dt.Rows(0)("Categorie").ToString()
            Tags_Text.Text = dt.Rows(0)("Tags").ToString()
            Publier_chk.Checked = CBool(dt.Rows(0)("Publier"))
            Dim htmlContent As String = dt.Rows(0)("Contenus").ToString()
            If WebBrowser1.Document IsNot Nothing Then
                WebBrowser1.Document.OpenNew(True)
                WebBrowser1.Document.Write(htmlContent)
                WebBrowser1.Document.Body.SetAttribute("contentEditable", "true")
            Else
                WebBrowser1.DocumentText = htmlContent
            End If
        Else
            Titre_Blog_Text.Text = ""
            Categorie_Combo.SelectedIndex = -1
            Tags_Text.Text = ""
            Publier_chk.Checked = False
            WebBrowser1.DocumentText = ""
        End If
    End Sub

    Sub Nouveau()
        Num_Blog_txt.Text = ""
        Titre_Blog_Text.Text = ""
        Tags_Text.Text = ""

        WebBrowser1.Document.OpenNew(True)
        WebBrowser1.Document.Write("<html><body></body></html>")
        WebBrowser1.Document.Body.SetAttribute("contentEditable", "true")
        Categorie_Combo.SelectedIndex = -1
        Num_Blog_txt.ReadOnly = True ' Auto-generated
    End Sub

    Sub Saving()
        If Titre_Blog_Text.Text.Trim = "" Then
            ShowMessageBox("Le titre est obligatoire.")
            Exit Sub
        End If
        If Categorie_Combo.SelectedIndex = -1 Then
            ShowMessageBox("La catégorie est obligatoire.")
            Exit Sub
        End If
        Dim htmlContent As String = WebBrowser1.Document.Body.InnerHtml
        If htmlContent.Trim = "" Then
            ShowMessageBox("Aucun contenu à publier.")
            Exit Sub
        End If
        Dim numBlog As String = Num_Blog_txt.Text
        Dim categorie As String = If(Categorie_Combo.SelectedValue Is Nothing, "", Categorie_Combo.SelectedValue.ToString())

        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM Communication_Blogs WHERE Num_Blog='" & numBlog & "'", cn, 1, 3)

        If rs.EOF Then
            rs.AddNew()
            ' Generate New ID
            Dim seq As Integer = 1
            Dim dtMax As DataTable = DATA_READER_GRD("SELECT MAX(RIGHT(Num_Blog, 5)) as MaxSeq FROM Communication_Blogs WHERE Num_Blog LIKE 'BLG" & Year(Now) & "%'")
            If dtMax.Rows.Count > 0 AndAlso Not IsDBNull(dtMax.Rows(0)("MaxSeq")) Then
                seq = CInt(dtMax.Rows(0)("MaxSeq")) + 1
            End If
            numBlog = "BLG" & Year(Now) & Format(seq, "00000")
            rs("Num_Blog").Value = numBlog
            rs("Dat_Crea").Value = Now
            rs("Created_by").Value = theUser.Login
            rs("id_Societe").Value = Societe.id_Societe
        Else
            rs.Update()
        End If
        rs("Titre_Blog").Value = Titre_Blog_Text.Text
        rs("Categorie").Value = categorie
        rs("Tags").Value = Tags_Text.Text
        rs("Contenus").Value = htmlContent
        rs("Publier").Value = Publier_chk.Checked

        rs.Update()
        rs.Close()
        If Num_Blog_txt.Text = "" Then
            Num_Blog_txt.Text = numBlog
        Else
            Request()
        End If
        ShowMessageBox("Enregistré.")

    End Sub

    Sub Deleting()
        If Num_Blog_txt.Text = "" Then Exit Sub
        If MessageBoxRHP(594) = MsgBoxResult.Cancel Then Exit Sub ' Confirm delete

        CnExecuting("DELETE FROM Communication_Blogs WHERE Num_Blog='" & Num_Blog_txt.Text & "'")
        Request()
        Nouveau()
    End Sub
    ' Editor Helpers
    Private Sub ToggleCommand(command As String)
        WebBrowser1.Document.ExecCommand(command, False, Nothing)
    End Sub

    Private Sub TBtn_Bold_Click(sender As Object, e As EventArgs) Handles TBtn_Bold.Click
        ToggleCommand("Bold")
    End Sub

    Private Sub TBtn_Italic_Click(sender As Object, e As EventArgs) Handles TBtn_Italic.Click
        ToggleCommand("Italic")
    End Sub

    Private Sub TBtn_Underline_Click(sender As Object, e As EventArgs) Handles TBtn_Underline.Click
        ToggleCommand("Underline")
    End Sub

    Private Sub TBtn_Left_Click(sender As Object, e As EventArgs) Handles TBtn_Left.Click
        ToggleCommand("JustifyLeft")
    End Sub

    Private Sub TBtn_Center_Click(sender As Object, e As EventArgs) Handles TBtn_Center.Click
        ToggleCommand("JustifyCenter")
    End Sub

    Private Sub TBtn_Right_Click(sender As Object, e As EventArgs) Handles TBtn_Right.Click
        ToggleCommand("JustifyRight")
    End Sub

    Private Sub TBtn_UnorderedList_Click(sender As Object, e As EventArgs) Handles TBtn_UnorderedList.Click
        ToggleCommand("InsertUnorderedList")
    End Sub

    Private Sub TBtn_OrderedList_Click(sender As Object, e As EventArgs) Handles TBtn_OrderedList.Click
        ToggleCommand("InsertOrderedList")
    End Sub

    Private Sub TBtn_Color_Click(sender As Object, e As EventArgs) Handles TBtn_Color.Click
        Dim cd As New ColorDialog
        If cd.ShowDialog() = DialogResult.OK Then
            Dim colorHex As String = String.Format("#{0:X2}{1:X2}{2:X2}", cd.Color.R, cd.Color.G, cd.Color.B)
            WebBrowser1.Document.ExecCommand("ForeColor", False, colorHex)
        End If
    End Sub

    Private Sub TBtn_Link_Click(sender As Object, e As EventArgs) Handles TBtn_Link.Click
        Dim url As String = InputBox("Veuillez saisir l'URL du lien :", "Insérer un lien", "http://")
        If url <> "" Then
            WebBrowser1.Document.ExecCommand("CreateLink", False, url)
        End If
    End Sub

    Private Sub TBtn_Image_Click(sender As Object, e As EventArgs) Handles TBtn_Image.Click
        Try
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.AutoUpgradeEnabled = False ' Fix for DRAGDROP_E_NOTREGISTERED
            openFileDialog1.Filter = "Images|*.jpg;*.png;*.gif;*.bmp"
            If openFileDialog1.ShowDialog(Me) = DialogResult.OK Then
                Dim bytes As Byte() = System.IO.File.ReadAllBytes(openFileDialog1.FileName)
                Dim base64 As String = Convert.ToBase64String(bytes)
                Dim imgTag As String = "<img src=""data:image/png;base64," & base64 & """ style=""max-width:100%;"">"
                If WebBrowser1.Document IsNot Nothing Then
                    WebBrowser1.Document.ExecCommand("InsertHTML", False, imgTag)
                End If
            End If
        Catch ex As Exception
            ShowMessageBox("Erreur lors de l'insertion de l'image : " & ex.Message)
        End Try
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If WebBrowser1.Document IsNot Nothing Then
            WebBrowser1.Document.Body.SetAttribute("contentEditable", "true")
        End If
    End Sub

    Private Sub CompteGeneralLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CompteGeneralLink.LinkClicked
        Appel_Zoom1("MS037", Num_Blog_txt, Me)
    End Sub

    Private Sub Num_Blog_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Blog_txt.TextChanged
        Request()
    End Sub


    Private Sub SmartPaste()
        Try
            ' Priority 1: HTML Format (Microsoft Word, Browser copy, etc.)
            If Clipboard.ContainsText(TextDataFormat.Html) Then
                Dim htmlRaw As String = Clipboard.GetText(TextDataFormat.Html)
                Dim htmlFragment As String = ExtractHtmlFragment(htmlRaw)

                ' Process Local Images in HTML (convert to Base64)
                htmlFragment = ProcessLocalImages(htmlFragment)

                If WebBrowser1.Document IsNot Nothing Then
                    WebBrowser1.Focus()
                    Try
                        ' Use late-bound MSHTML to bypass ExecCommand DRAGDROP error
                        Dim doc As Object = WebBrowser1.Document.DomDocument
                        Dim sel As Object = doc.selection.createRange()
                        sel.pasteHTML(htmlFragment)
                    Catch htmlEx As Exception
                        ' Fallback
                        WebBrowser1.Document.ExecCommand("InsertHTML", False, htmlFragment)
                    End Try
                End If
                Exit Sub
            End If

            ' Priority 2: Image (Bitmap / Screenshot)
            If Clipboard.ContainsImage() Then
                Dim img As Image = Clipboard.GetImage()
                If img IsNot Nothing Then
                    InsertImageAsBase64(img)
                End If
                Exit Sub
            End If

            ' Priority 3: File Drop (Image File from Explorer)
            If Clipboard.ContainsFileDropList() Then
                Dim files As System.Collections.Specialized.StringCollection = Clipboard.GetFileDropList()
                If files.Count > 0 Then
                    Dim ext As String = System.IO.Path.GetExtension(files(0)).ToLower()
                    If {".jpg", ".jpeg", ".png", ".gif", ".bmp"}.Contains(ext) Then
                        Dim bytes As Byte() = System.IO.File.ReadAllBytes(files(0))
                        Using ms As New MemoryStream(bytes)
                            Dim img As Image = Image.FromStream(ms)
                            InsertImageAsBase64(img)
                        End Using
                    End If
                End If
                Exit Sub
            End If

            ' Priority 4: Plain Text fallback
            WebBrowser1.Document.ExecCommand("Paste", False, Nothing)

        Catch ex As Exception
            MsgBox("Erreur SmartPaste: " & ex.Message)
        End Try
    End Sub

    Private Function ExtractHtmlFragment(rawHtml As String) As String
        ' Robust extraction using markers instead of Byte Offsets (which fail in .NET String)

        ' 1. Try explicit CF_HTML comments (Word/Office standard)
        Dim startMarker As String = "<!--StartFragment-->"
        Dim endMarker As String = "<!--EndFragment-->"

        Dim startIdx As Integer = rawHtml.IndexOf(startMarker)
        Dim endIdx As Integer = rawHtml.IndexOf(endMarker)

        If startIdx > -1 AndAlso endIdx > startIdx Then
            Return rawHtml.Substring(startIdx + startMarker.Length, endIdx - (startIdx + startMarker.Length))
        End If

        ' 2. Fallback: Find StartHTML tag if present in header, or just look for <html
        ' The header usually contains "StartHTML:xxxx", but we ignore numbers.
        ' Let's look for the first HTML tag
        Dim htmlTagIdx As Integer = rawHtml.IndexOf("<html", StringComparison.OrdinalIgnoreCase)
        If htmlTagIdx > -1 Then
            Return rawHtml.Substring(htmlTagIdx)
        End If

        ' 3. Last resort: Return raw (might contain headers, but better than random junk)
        Return rawHtml
    End Function

    Private Function ProcessLocalImages(html As String) As String
        ' 1. Handle Word VML tags (<v:imagedata>) which don't support Data URIs in IE
        ' We must replace the entire valid VML tag with a standard <img src="data:...">
        Dim vmlPattern As String = "<v:imagedata[^>]+src=[""'](?<src>file://[^""']+|[a-zA-Z]:\\[^""']+)[""'][^>]*\/?>"
        Dim vmlMatches As MatchCollection = Regex.Matches(html, vmlPattern, RegexOptions.IgnoreCase)

        For Each m As Match In vmlMatches
            Dim fullTag As String = m.Value
            Dim src As String = m.Groups("src").Value
            Dim base64Img As String = LoadImageToBase64(src)
            If base64Img <> "" Then
                Dim newTag As String = "<img src=""" & base64Img & """ style=""max-width:100%"" />"
                html = html.Replace(fullTag, newTag)
            End If
        Next

        ' 2. Handle standard <img> tags with local paths (browser blocks these)
        ' We just replace the src value here because <img> supports Data URIs
        Dim imgPattern As String = "<img[^>]+src=[""'](?<src>file://[^""']+|[a-zA-Z]:\\[^""']+)[""'][^>]*>"
        Dim imgMatches As MatchCollection = Regex.Matches(html, imgPattern, RegexOptions.IgnoreCase)

        For Each m As Match In imgMatches
            Dim src As String = m.Groups("src").Value
            Dim base64Img As String = LoadImageToBase64(src)
            If base64Img <> "" Then
                ' Replace ONLY the src value to preserve other attributes if possible
                ' A safe way is to replace the exact substring 'src="old"' with 'src="new"'?
                ' Or just the URL string itself if unique. Given temp files, usually unique.
                html = html.Replace(src, base64Img)
            End If
        Next

        Return html
    End Function

    Private Function LoadImageToBase64(src As String) As String
        Try
            Dim localPath As String = src
            If src.StartsWith("file://") Then
                Try
                    Dim uri As New Uri(src)
                    localPath = uri.LocalPath
                Catch
                    localPath = src.Replace("file:///", "").Replace("/", "\")
                End Try
            End If

            localPath = localPath.Replace("/", "\")
            localPath = Uri.UnescapeDataString(localPath)

            If System.IO.File.Exists(localPath) Then
                Dim bytes As Byte() = System.IO.File.ReadAllBytes(localPath)
                Dim base64 As String = Convert.ToBase64String(bytes)
                Return "data:image/png;base64," & base64
            End If
        Catch
            ' Fail silently
        End Try
        Return ""
    End Function

    Private Sub InsertImageAsBase64(img As Image)
        Using ms As New MemoryStream()
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Dim base64 As String = Convert.ToBase64String(ms.ToArray())
            Dim imgTag As String = "<img src=""data:image/png;base64," & base64 & """ style=""max-width:100%;"">"
            If WebBrowser1.Document IsNot Nothing Then
                WebBrowser1.Document.ExecCommand("InsertHTML", False, imgTag)
            End If
        End Using
    End Sub
End Class
