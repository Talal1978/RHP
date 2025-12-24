Imports System.ComponentModel
Public Class ud_RichTextBox
    Dim oCnt As New ContextMenuStrip
    Dim oMnu1, oMnu2, oMnu3 As New ToolStripMenuItem
    Public Shadows Event Validated As EventHandler
    Public ReadOnly Property richTxtbx() As RichTextBox
        Get
            Return rtb
        End Get
    End Property
    <Browsable(True),
 DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
 DefaultValue("")> ' Default value to ensure serialization when non-default
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return rtb.ReadOnly
        End Get
        Set(value As Boolean)
            rtb.ReadOnly = value
            Rtb_Menus.Enabled = Not value
        End Set
    End Property
    Sub insert(startindex As Integer, value As String)
        With rtb
            .SelectionStart = startindex
            .SelectionLength = 1
            .SelectedText = value
        End With
    End Sub
    Private Sub RichTextBoxEx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Load control   
        With oMnu1
            .Text = "Copier"
            .Image = My.Resources.Copier
            AddHandler .Click, AddressOf CopierContenu
        End With
        With oMnu2
            .Text = "Coller"
            .Image = My.Resources.paste
            AddHandler .Click, AddressOf CollerContenu
        End With
        With oMnu3
            .Text = "Sélectionner tout"
            .Image = My.Resources.selectAll
            AddHandler .Click, AddressOf SélectionnerTout
        End With
        oCnt.Items.AddRange({oMnu1, oMnu2, oMnu3})
        With rtb
            .MaxLength = 7900
            .ContextMenuStrip = oCnt
            .Focus()
        End With
    End Sub
    Sub CopierContenu()
        rtb.Copy()
    End Sub
    Sub CollerContenu()
        rtb.Paste()
    End Sub
    Sub SélectionnerTout()
        rtb.SelectAll()
    End Sub
    ' Handles when user chooses to delete in spell cehck
    Private Sub SpellChecker_DeletedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.SpellingEventArgs) Handles SpellChecker.DeletedWord
        'save existing selecting
        Dim start As Integer = rtb.SelectionStart
        Dim length As Integer = rtb.SelectionLength

        'select word for this event
        rtb.Select(e.TextIndex, e.Word.Length)

        'delete word
        rtb.SelectedText = ""

        If ((start + length) > rtb.Text.Length) Then
            length = 0
        End If

        'restore selection
        rtb.Select(start, length)

    End Sub

    ' Handles replacing a word from spell checking
    Private Sub SpellChecker_ReplacedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.ReplaceWordEventArgs) Handles SpellChecker.ReplacedWord
        'save existing selecting
        Dim start As Integer = rtb.SelectionStart
        Dim length As Integer = rtb.SelectionLength

        'select word for this event
        rtb.Select(e.TextIndex, e.Word.Length)

        'replace word
        rtb.SelectedText = e.ReplacementWord

        If ((start + length) > rtb.Text.Length) Then
            length = 0
        End If

        'restore selection
        rtb.Select(start, length)
    End Sub

    ' Update buttons when text is selected
    Private Sub rtb_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtb.SelectionChanged
        ' see which buttons should be checked or unchecked
        If rtb.SelectionFont Is Nothing Then Return
        BoldToolStripButton.Checked = rtb.SelectionFont.Bold
        UnderlineToolStripButton.Checked = rtb.SelectionFont.Underline
        LeftToolStripButton.Checked = IIf(rtb.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left, True, False)
        CenterToolStripButton.Checked = IIf(rtb.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center, True, False)
        RightToolStripButton.Checked = IIf(rtb.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right, True, False)
        BulletsToolStripButton.Checked = rtb.SelectionBullet

        'cmbFontName.Text = rtb.SelectionFont.Name
        'cmbFontSize.Text = rtb.SelectionFont.SizeInPoints

    End Sub

    Private Sub checkBullets()
        If rtb.SelectionBullet = True Then
            BulletsToolStripButton.Checked = True
        Else
            BulletsToolStripButton.Checked = False
        End If
    End Sub

    Private Sub FontToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripButton.Click
        If Fontdlg.ShowDialog() <> DialogResult.Cancel Then
            rtb.SelectionFont = FontDlg.Font
        End If
    End Sub

    Private Sub FontColorToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontColorToolStripButton.Click
        If Colordlg.ShowDialog() <> DialogResult.Cancel Then
            rtb.SelectionColor = ColorDlg.Color
        End If
    End Sub

    Private Sub BoldToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldToolStripButton.Click
        ' Switch Bold
        If rtb.SelectionFont Is Nothing Then Return
        Dim currentFont As System.Drawing.Font = rtb.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        If rtb.SelectionFont.Bold = True Then
            newFontStyle = currentFont.Style - Drawing.FontStyle.Bold
        Else
            newFontStyle = currentFont.Style + Drawing.FontStyle.Bold
        End If
        rtb.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        ' Check/Uncheck Bold button
        BoldToolStripButton.Checked = IIf(rtb.SelectionFont.Bold, True, False)
    End Sub

    Private Sub SpellcheckToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpellcheckToolStripButton.Click
        SpellChecker.Text = rtb.Text
        SpellChecker.SpellCheck()
    End Sub

    Private Sub UnderlineToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineToolStripButton.Click
        ' Switch Underline
        Dim currentFont As System.Drawing.Font = rtb.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        If rtb.SelectionFont.Underline = True Then
            newFontStyle = currentFont.Style - Drawing.FontStyle.Underline
        Else
            newFontStyle = currentFont.Style + Drawing.FontStyle.Underline
        End If
        rtb.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        ' Check/Uncheck Underline button
        UnderlineToolStripButton.Checked = IIf(rtb.SelectionFont.Underline, True, False)
    End Sub

    Private Sub LeftToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftToolStripButton.Click
        rtb.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub CenterToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterToolStripButton.Click
        rtb.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub RightToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightToolStripButton.Click
        rtb.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub BulletsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BulletsToolStripButton.Click
        rtb.SelectionBullet = Not rtb.SelectionBullet
        BulletsToolStripButton.Checked = rtb.SelectionBullet
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EnregistrerToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            CallByName(Me.FindForm, "Saving", CallType.Method)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        rtb.Copy()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles Ouvrir.Click
        Dim dlg As New OpenFileDialog
        ' Set filter options and filter index.
        dlg.Filter = "RTF Files (*.rtf)|*.rtf|All Files (*.*)|*.*"
        dlg.FilterIndex = 1
        dlg.Multiselect = False
        ' Call the ShowDialog method to show the dialog box.
        If dlg.ShowDialog() = DialogResult.OK Then
            ' Load the content of the file into the RichTextBox.
            rtb.LoadFile(dlg.FileName, RichTextBoxStreamType.RichText)
            rtb.Select()
        End If
    End Sub

    Private Sub PasteToolStripButton_Click(sender As Object, e As EventArgs) Handles PasteToolStripButton.Click
        rtb.Paste()
    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        rtb.Cut()
    End Sub

    Private Sub rtb_Validated(sender As Object, e As EventArgs) Handles rtb.Validated
        RaiseEvent Validated(sender, e)
    End Sub
End Class
