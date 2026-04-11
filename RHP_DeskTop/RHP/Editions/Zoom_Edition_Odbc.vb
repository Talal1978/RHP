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

    Private ts As ToolStrip
    Private cryRpt As ReportDocument

    Private Function FindCrystalParameterName(rpt As ReportDocument, inputName As String) As String
        If rpt Is Nothing OrElse rpt.DataDefinition Is Nothing OrElse rpt.DataDefinition.ParameterFields Is Nothing Then
            Return inputName
        End If

        For Each paramDef As ParameterFieldDefinition In rpt.DataDefinition.ParameterFields
            If String.Equals(paramDef.Name, inputName, StringComparison.OrdinalIgnoreCase) Then
                Return paramDef.Name
            End If
            If String.Equals(paramDef.ParameterFieldName, inputName, StringComparison.OrdinalIgnoreCase) Then
                Return paramDef.Name
            End If
        Next

        Return inputName
    End Function

    Private Function TrySetReportParameter(rpt As ReportDocument, inputName As String, inputValue As Object, ByRef errorMessage As String) As Boolean
        errorMessage = ""
        If rpt Is Nothing Then
            errorMessage = "Rapport non initialisé"
            Return False
        End If

        Dim resolvedName As String = FindCrystalParameterName(rpt, inputName)

        Try
            rpt.SetParameterValue(resolvedName, inputValue)
            Return True
        Catch ex As Exception
            errorMessage = "Paramètre '" & inputName & "' (résolu: '" & resolvedName & "') valeur='" & If(inputValue Is Nothing, "<NULL>", inputValue.ToString()) & "' : " & ex.Message
            Return False
        End Try
    End Function

    Private Sub Zoom_Edition_Odbc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim rg As New System.Text.RegularExpressions.Regex("\\([^\\]+)\.[^.]+$")
            Dim match As System.Text.RegularExpressions.Match = rg.Match(etat)
            Dim rptName As String = ""
            '  Dim withPassWord = False

            If match.Success Then
                rptName = match.Groups(1).Value
                '   withPassWord = FindLibelle("withPassword", "Cod_Report", rptName, "Param_Mod_Edition")
            End If

            Me.WindowState = FormWindowState.Maximized
            Cursor = Cursors.WaitCursor
            CrystalReportViewer1.Cursor = Cursors.WaitCursor

            Dim eml As New ToolStripButton

            With CrystalReportViewer1
                .DisplayGroupTree = DisplayTree
                .EnableRefresh = True
                .EnableDrillDown = True
                .ReuseParameterValuesOnRefresh = True

                If Gere_Wkf = "O" Then
                    If Pie_Valide = "O" Then
                        .ShowPrintButton = True
                        .ShowExportButton = True
                    Else
                        .ShowPrintButton = False
                        .ShowExportButton = False
                    End If
                Else
                    .ShowPrintButton = LegalVersion
                    .ShowExportButton = .ShowPrintButton
                End If

                .ShowCloseButton = True
                .ShowCopyButton = True
                .ShowGroupTreeButton = DisplayTree
                .ShowPageNavigateButtons = True
                .ShowRefreshButton = True
                .ShowTextSearchButton = True
                .ShowZoomButton = True
                .SelectionFormula = Nothing
                .ViewTimeSelectionFormula = Nothing

                .Refresh()
            End With

            If CrystalReportViewer1.Controls.Count > 4 Then
                ts = CType(CrystalReportViewer1.Controls(4), ToolStrip)

                With eml
                    .Image = My.Resources.msg0
                    .ToolTipText = "Envoyer par mail"
                    .Visible = CrystalReportViewer1.ShowPrintButton
                    AddHandler .Click, AddressOf Emailing
                End With

                If ts.Items.Count > 2 Then
                    ts.Items.Remove(ts.Items(2))
                End If
                ts.Items.Insert(2, eml)

                ts.Visible = CrystalReportViewer1.ShowPrintButton OrElse CrystalReportViewer1.ShowExportButton
                ts.Refresh()
            End If

            'If CBool(withPassWord) Then
            '    Dim fullFileName As String = ""
            '    If rptName <> "" Then
            '        fullFileName = rptName & "_" & (New Random).Next(10000, 99999) & ".pdf"
            '    End If

            '    Dim saveFileDialog As New SaveFileDialog()
            '    With saveFileDialog
            '        .InitialDirectory = importPath
            '        .Filter = "Fichiers PDF (*.pdf)|*.pdf|Tous les fichiers (*.*)|*.*"
            '        .FilterIndex = 1
            '        .RestoreDirectory = True
            '        .FileName = fullFileName
            '        .Title = "Enregistrer le rapport PDF protégé"
            '    End With

            '    If saveFileDialog.ShowDialog() = DialogResult.OK Then
            '        fullFileName = saveFileDialog.FileName
            '        RptExportingToPdf(fullFileName, True)
            '    Else
            '        Me.Close()
            '    End If
            'Else
            GeneratingReport()
            '   End If

            Cursor = Cursors.Default
            CrystalReportViewer1.Cursor = Cursors.Default

        Catch ex As Exception
            ShowMessageBox("Erreur lors du chargement : " & vbCrLf & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
            CrystalReportViewer1.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Aperçu_Odbc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If CrystalReportViewer1.ReportSource IsNot Nothing Then
                CType(CrystalReportViewer1.ReportSource, ReportDocument).Close()
                CrystalReportViewer1.ReportSource = Nothing
            End If

            If cryRpt IsNot Nothing Then
                cryRpt.Close()
                cryRpt.Dispose()
                cryRpt = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub GeneratingReport()
        Try
            Cursor = Cursors.WaitCursor
            CrystalReportViewer1.Cursor = Cursors.WaitCursor
            Dim ODBCRay1 As String = FindParam("ODBC_RHP")
            If String.IsNullOrEmpty(ODBCRay1) Then
                ShowMessageBox("ODBC non renseigné dans les paramètres généraux", "Erreur de configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Exit Sub
            End If
            cryRpt = New ReportDocument()
            Dim DataBaseName As String = DB.ToUpper
            With cryRpt
                .Load(etat)
                If .DataSourceConnections.Count > 0 Then
                    .DataSourceConnections(0).SetConnection(ODBCRay1, DataBaseName, False)
                    .DataSourceConnections(0).SetLogon(ConnectionSQL, PWDConnectionSQL)
                End If
                For Each table As CrystalDecisions.CrystalReports.Engine.Table In .Database.Tables
                    Dim logonInfo As New TableLogOnInfo()
                    logonInfo.ConnectionInfo.ServerName = ODBCRay1
                    logonInfo.ConnectionInfo.DatabaseName = DataBaseName
                    logonInfo.ConnectionInfo.UserID = ConnectionSQL
                    logonInfo.ConnectionInfo.Password = PWDConnectionSQL
                    table.ApplyLogOnInfo(logonInfo)
                Next
            End With

            ' *** MODIFICATION IMPORTANTE : Définir les paramètres AVANT d'assigner le ReportSource ***
            ' Passer les paramètres au rapport principal
            '   Dim strParam As String = ""
            Dim paramErrors As New List(Of String)
            For i As Integer = 0 To ParamList.Count - 1
                Dim err As String = ""
                Dim pname As String = ParamList(i).ToString()
                Dim pvalue As Object = ValList(i)
                If Not TrySetReportParameter(cryRpt, pname, pvalue, err) Then
                    paramErrors.Add(err)
                End If
            Next

            If paramErrors.Count > 0 Then
                Dim msg As String = "Les paramètres du rapport n'ont pas pu être appliqués." & vbCrLf & vbCrLf & String.Join(vbCrLf, paramErrors)
                ShowMessageBox(msg, "Erreur paramètres Crystal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Sub
            End If
            '   MsgBox(strParam)
            ' Passer les paramètres aux sous-rapports
            Try
                PasserParametresAuxSousRapports(cryRpt)
            Catch ex As Exception
                Debug.WriteLine("Erreur lors du passage des paramètres aux sous-rapports : " & ex.Message)
            End Try

            ' *** MAINTENANT on peut assigner le ReportSource ***
            CrystalReportViewer1.ReportSource = cryRpt

            If Not String.IsNullOrWhiteSpace(cryRpt.RecordSelectionFormula) Then
                CrystalReportViewer1.SelectionFormula = cryRpt.RecordSelectionFormula
            End If

            ' Ne PAS appeler RefreshReport ici car cela redemandera les paramètres
            ' CrystalReportViewer1.RefreshReport()

            Cursor = Cursors.Default
            CrystalReportViewer1.Cursor = Cursors.Default
        Catch ex As Exception
            ShowMessageBox("Erreur lors de la génération du rapport : " & vbCrLf & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub PasserParametresAuxSousRapports(rpt As ReportDocument)
        If rpt Is Nothing OrElse rpt.ReportDefinition Is Nothing Then Exit Sub

        Try
            For Each section As Section In rpt.ReportDefinition.Sections
                If section Is Nothing OrElse section.ReportObjects Is Nothing Then Continue For

                For Each reportObject As ReportObject In section.ReportObjects
                    If reportObject.Kind = ReportObjectKind.SubreportObject Then
                        Try
                            Dim subReport As SubreportObject = CType(reportObject, SubreportObject)
                            Dim subReportDoc As ReportDocument = subReport.OpenSubreport(subReport.SubreportName)

                            If subReportDoc IsNot Nothing AndAlso subReportDoc.DataDefinition IsNot Nothing Then
                                For i As Integer = 0 To ParamList.Count - 1
                                    Try
                                        Dim paramName As String = ParamList(i).ToString()
                                        Dim paramValue As Object = ValList(i)

                                        ' Vérifier si le paramètre existe dans le sous-rapport
                                        Dim paramExists As Boolean = False
                                        Dim resolvedName As String = paramName
                                        For Each paramDef As ParameterFieldDefinition In subReportDoc.DataDefinition.ParameterFields
                                            If String.Equals(paramDef.Name, paramName, StringComparison.OrdinalIgnoreCase) OrElse String.Equals(paramDef.ParameterFieldName, paramName, StringComparison.OrdinalIgnoreCase) Then
                                                paramExists = True
                                                resolvedName = paramDef.Name
                                                Exit For
                                            End If
                                        Next

                                        If paramExists Then
                                            subReportDoc.SetParameterValue(resolvedName, paramValue)
                                        End If
                                    Catch exParam As Exception
                                        Debug.WriteLine($"Impossible de passer le paramètre {ParamList(i)} au sous-rapport : {exParam.Message}")
                                    End Try
                                Next
                            End If
                        Catch exSub As Exception
                            Debug.WriteLine($"Erreur avec le sous-rapport : {exSub.Message}")
                        End Try
                    End If
                Next
            Next
        Catch ex As Exception
            Debug.WriteLine($"Erreur générale lors du traitement des sous-rapports : {ex.Message}")
        End Try
    End Sub

    Sub Emailing()
        Try
            If CrystalReportViewer1.ReportSource Is Nothing Then
                ShowMessageBox("Aucun rapport à envoyer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim rpt As ReportDocument = CType(CrystalReportViewer1.ReportSource, ReportDocument)

            Try
                System.IO.Directory.Delete("PDF", True)
            Catch ex As Exception

            End Try


            If Not System.IO.Directory.Exists("PDF") Then
                System.IO.Directory.CreateDirectory("PDF")
            End If

            Dim rnd As New Random
            Dim Filename As String = "PDF\" & rpt.Name & rnd.Next(0, 10000) & ".pdf"

            Dim exportOpts As New ExportOptions()
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

            Dim diskOpts As New DiskFileDestinationOptions()
            diskOpts.DiskFileName = Filename
            exportOpts.ExportDestinationOptions = diskOpts

            rpt.Export(exportOpts)

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

        Catch ex As Exception
            ShowMessageBox("Erreur lors de la préparation de l'email : " & vbCrLf & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub RptExportingToPdf(fullFileName As String, Optional ByVal withPassWord As Boolean = False)
        Try
            Dim exportRpt As New ReportDocument
            Dim ODBCRay1 As String = FindParam("ODBC_Ray1")

            If String.IsNullOrEmpty(ODBCRay1) Then
                ShowMessageBox("ODBC non renseigné dans les paramètres généraux", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim DataBaseName As String = DB.ToUpper

            With exportRpt
                .Load(etat)
                If .DataSourceConnections.Count > 0 Then
                    .DataSourceConnections(0).SetConnection(ODBCRay1, DataBaseName, False)
                    .DataSourceConnections(0).SetLogon(ConnectionSQL, PWDConnectionSQL)
                End If
            End With

            For i As Integer = 0 To ParamList.Count - 1
                exportRpt.SetParameterValue(ParamList(i).ToString(), ValList(i))
            Next

            Dim exportOptions As New ExportOptions()
            exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
            exportOptions.ExportDestinationType = ExportDestinationType.DiskFile

            Dim diskOpts As New DiskFileDestinationOptions()
            diskOpts.DiskFileName = fullFileName
            exportOptions.ExportDestinationOptions = diskOpts

            exportRpt.Export(exportOptions)

            If withPassWord Then
                Dim pwd As String = (New Random).Next(10000, 99999).ToString()
                Dim encryptedFile As String = fullFileName.Replace(".pdf", "") & "_protected.pdf"

                ShowMessageBox("Votre mot de passe : " & vbCrLf & vbCrLf & pwd, "Mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ApplyPasswordToPdf(fullFileName, encryptedFile, pwd)
            Else
                StartPrograme(fullFileName)
            End If

            exportRpt.Close()
            exportRpt.Dispose()

        Catch ex As Exception
            ShowMessageBox("Erreur lors de l'export PDF : " & vbCrLf & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Close()
        End Try
    End Sub

    Sub ApplyPasswordToPdf(inputFile As String, outputFile As String, userPassword As String)
        Try
            Dim document As PdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(inputFile, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Modify)

            With document.SecuritySettings
                .UserPassword = userPassword
                .OwnerPassword = userPassword
                .PermitAnnotations = False
                .PermitAssembleDocument = False
                .PermitExtractContent = False
                .PermitFormsFill = True
                .PermitFullQualityPrint = False
                .PermitModifyDocument = False
                .PermitPrint = True
            End With

            document.Save(outputFile)
            document.Close()

            System.IO.File.Delete(inputFile)

            StartPrograme(outputFile)

        Catch ex As Exception
            ShowMessageBox("Erreur lors de la protection du PDF : " & vbCrLf & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
