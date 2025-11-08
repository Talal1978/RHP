Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports PdfSharp.Pdf
Public Class Zoom_Edition_Odbc
    Friend Pie_Valide, Gere_Wkf As Char
    Friend etat As String
    Friend DisplayTree As Boolean = True
    Friend ParamList As New ArrayList
    Friend ValList As New ArrayList
    Friend oMailSujet As String = ""
    Dim ts As New ToolStrip
    Private Sub Aperçu_Odbc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If CrystalReportViewer1.ReportSource IsNot Nothing Then CrystalReportViewer1.ReportSource.close()
        Catch ex As Exception

        End Try
    End Sub
    Sub GeneratingReport()
        Try
            Cursor = Cursors.WaitCursor
            CrystalReportViewer1.Cursor = Cursors.WaitCursor
            ' On Error GoTo cr_suite
            Dim cryRpt As New ReportDocument
            Dim ODBCRHP As String = FindParam("ODBC_RHP")
            If ODBCRHP = "" Then
                MsgBox("ODBC non renseigné dans les paramétres généraux")
                Exit Sub
            End If
            Dim DataBaseName As String = DB.ToUpper
            With cryRpt
                .Load(etat)
                .DataSourceConnections(0).SetConnection(ODBCRHP, DataBaseName, False)
                .DataSourceConnections(0).SetLogon(ConnectionSQL, PWDConnectionSQL)
            End With
            Dim paramFields As New ParameterFields()

            Dim i As Integer
            For i = 0 To ParamList.Count - 1
                Dim paramField As New ParameterField()
                Dim discreteVal As New ParameterDiscreteValue()
                paramField.ParameterFieldName = ParamList(i)
                discreteVal.Value = ValList(i)
                paramField.CurrentValues.Add(discreteVal)
                paramFields.Add(paramField)
            Next

            With CrystalReportViewer1
                .ParameterFieldInfo = paramFields
                .ReportSource = cryRpt
            End With
            Cursor = Cursors.Default
            CrystalReportViewer1.Cursor = Cursors.Default
            Exit Sub
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
        Me.Close()
    End Sub
    Private Sub Zoom_Edition_Odbc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim rg As New System.Text.RegularExpressions.Regex("\\([^\\]+)\.[^.]+$")
            Dim match As System.Text.RegularExpressions.Match = rg.Match(etat)
            Dim rptName As String = ""
            Dim withPassWord = False
            If match.Success Then
                rptName = match.Groups(1).Value
                withPassWord = FindLibelle("withPassword", "Cod_Report", rptName, "Param_Mod_Edition")
            End If
            CrystalReportViewer1.Cursor = Cursors.WaitCursor
            Cursor = Cursors.WaitCursor
            Dim eml As New ToolStripButton
            Me.WindowState = FormWindowState.Maximized
            With CrystalReportViewer1
                .Refresh()
                If Gere_Wkf = "O" Then
                    If Pie_Valide = "O" Then
                        .ShowPrintButton = True
                        .ShowExportButton = True
                        ts.Visible = True
                    Else
                        .ShowPrintButton = False
                        .ShowExportButton = False
                        ts.Visible = False
                    End If
                Else
                    .ShowPrintButton = Droits.EstAuthentic
                End If
                .DisplayGroupTree = DisplayTree
            End With
            ts = CType(CrystalReportViewer1.Controls(4), ToolStrip)
            With eml
                .Image = My.Resources.msg0
                .ToolTipText = "Envoyer par mail"
                .Visible = CrystalReportViewer1.ShowPrintButton
                AddHandler .Click, AddressOf Emailing
            End With
            ts.Items.Remove(ts.Items(2))
            ts.Items.Insert(2, eml)
            ts.Refresh()
            If CBool(withPassWord) Then
                Dim fullFileName As String = ""
                If rptName <> "" Then
                    fullFileName = rptName & "_" & (New Random).Next(10000, 99999) & ".pdf"
                End If
                Dim saveFileDialog As New SaveFileDialog()
                ' Set properties for the save file dialog
                saveFileDialog.InitialDirectory = importPath ' Optional: Set the initial directory
                saveFileDialog.Filter = "Pdf Files (*.pdf)|*.txt|All Files (*.*)|*.*" ' Optional: Filter for file types
                saveFileDialog.FilterIndex = 1 ' Optional: Set default filter
                saveFileDialog.RestoreDirectory = True ' Optional: Restore directory between uses
                If fullFileName <> "" Then saveFileDialog.FileName = fullFileName ' Set default file name
                ' Show the dialog and get the result
                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    ' Get the selected file path
                    fullFileName = saveFileDialog.FileName
                    RptExportingToPdf(fullFileName, True)
                    Me.Close()
                End If
            Else
                GeneratingReport()
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
        CrystalReportViewer1.Cursor = Cursors.Default
        Cursor = Cursors.Default
    End Sub
    Sub Emailing()
        Dim rpt As New ReportDocument
        rpt = CrystalReportViewer1.ReportSource
        On Error GoTo suite
        System.IO.Directory.Delete("PDF", True)
suite:
        If Not System.IO.Directory.Exists("PDF") Then System.IO.Directory.CreateDirectory("PDF")
        Dim rnd As New Random
        Dim Filename As String = "PDF\" & rpt.Name & rnd.Next(0, 10000) & ".pdf"
        rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Filename)
        With Zoom_Mail
            Dim oEmails As String = ""
            .To_Text.Text = .ExtraireEmailValid(oEmails)
            .Object_Text.Text = oMailSujet
            .StartPosition = FormStartPosition.CenterScreen
            .PJ_List.Items.Clear()
            .PJList.Clear()
            .PJList.Add(Filename)
            .ShowDialog()
        End With

    End Sub

    Sub RptExportingToPdf(fullFileName As String, Optional ByVal withPassWord As Boolean = False)
        Dim cryRpt As New ReportDocument
        Dim ODBCRHP As String = FindParam("ODBC_RHP")
        If ODBCRHP = "" Then
            MsgBox("ODBC non renseigné dans les paramétres généraux")
            Exit Sub
        End If
        Dim DataBaseName As String = DB.ToUpper

        With cryRpt
            .Load(etat)
            .DataSourceConnections(0).SetConnection(ODBCRHP, DataBaseName, False)
            .DataSourceConnections(0).SetLogon(ConnectionSQL, PWDConnectionSQL)
        End With

        For i = 0 To ParamList.Count - 1
            cryRpt.SetParameterValue(ParamList(i), ValList(i))
        Next
        CType(cryRpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, fullFileName)
        If withPassWord Then
            Dim pwd As String = (New Random).Next(10000, 99999)
            Dim encryptedFile = fullFileName.Replace(".pdf", "") & "_protected.pdf"
            ShowMessageBox("Votre mot de passe : " & vbCrLf & pwd, "Mot de passe : " & fullFileName, MessageBoxButtons.OK)
            ApplyPasswordToPdf(fullFileName, encryptedFile, pwd)
        Else
            StartPrograme(fullFileName)
        End If
        Me.Close()
    End Sub
    Sub ApplyPasswordToPdf(inputFile As String, outputFile As String, userPassword As String)
        ' Open the existing PDF
        Dim document As PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(inputFile, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Modify)

        ' Set the security settings for the PDF
        document.SecuritySettings.UserPassword = userPassword
        document.SecuritySettings.OwnerPassword = userPassword

        ' Set permissions for the PDF (This version of PdfSharp doesn't allow detailed permission control)
        '   document.SecuritySettings.PermitAccessibilityExtractContent = False ' Disable extracting content
        document.SecuritySettings.PermitAnnotations = False ' Disable annotations
        document.SecuritySettings.PermitAssembleDocument = False ' Disable assembling the document
        document.SecuritySettings.PermitExtractContent = False ' Disable content copying
        document.SecuritySettings.PermitFormsFill = True ' Allow filling forms
        document.SecuritySettings.PermitFullQualityPrint = False ' Disable high-quality printing
        document.SecuritySettings.PermitModifyDocument = False ' Disable modifying the document
        document.SecuritySettings.PermitPrint = True ' Allow printing
        System.IO.File.Delete(inputFile)
        ' Save the new password-protected PDF
        document.Save(outputFile)
        StartPrograme(outputFile)
    End Sub
End Class