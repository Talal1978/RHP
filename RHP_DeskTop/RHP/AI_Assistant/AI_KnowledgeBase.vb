Imports System.Threading.Tasks
Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Partial Public Class AI_KnowledgeBase
    Dim Importer_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Config_D As ud_btn
#Region "Variables"

    Private WithEvents _ingestionService As IngestionService = IngestionService.Instance
    Private _Ai_Embedding As Ai_Embedding = Ai_Embedding.Instance
    Private _isProcessing As Boolean = False

#End Region

#Region "Chargement"

    Private Sub Frm_AI_KnowledgeBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Request()
    End Sub

    Sub Chargement()
        If Provider_cbo.Items.Count = 0 Then
            Provider_cbo.FromSQL("SELECT distinct Modele, Provider from Ai_LLM_Modeles order by Provider")
        End If
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
            Importer_D = dictButtons("Importer_D")
            Del_D = dictButtons("Del_D")
            Config_D = dictButtons("Config_D")
            With Grd_Docs
                .DefaultCellStyle.SelectionBackColor = colorBase04
            End With
            ' Charger la configuration par défaut
            LoadEmbeddingConfig()
            ' Charger la liste des documents
        End If
    End Sub
    Sub Request()
        Chargement()
        Dim Tbl As DataTable = DATA_READER_GRD($"SELECT top 1 * FROM Ai_Agent WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe})={Societe.id_Societe} order by id_Societe")
        With Tbl
            If .Rows.Count > 0 Then
                Dim Dr As DataRow = .Rows(0)
                If Not IsDBNull(Dr("Provider")) Then
                    Provider_cbo.Text = Dr("Provider")
                End If
                If Not IsDBNull(Dr("Modele")) Then
                    Modele_cbo.Text = Dr("Modele")
                End If
                AiUrl_txt.Text = IsNull(Dr("AiUrl"), "")
                ApiKey_txt.Text = IsNull(Dr("ApiKey"), "")
                Instructions_txt.Text = IsNull(Dr("Instructions"), "")
                nb_Msg_Memory.Value = IsNull(Dr("Nb_Msg_Memory"), 5)
            Else
                Provider_cbo.SelectedIndex = -1
                Modele_cbo.SelectedIndex = -1
                AiUrl_txt.Text = ""
                ApiKey_txt.Text = ""
                Instructions_txt.Text = ""
                nb_Msg_Memory.Value = 5
            End If
        End With
        LoadList()
    End Sub
    Sub Saving()
        If Provider_cbo.SelectedIndex = -1 Then
            ShowMessageBox("Veuillez sélectionner un fournisseur.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If Modele_cbo.SelectedIndex = -1 Then
            ShowMessageBox("Veuillez sélectionner un modèle.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If AiUrl_txt.Text.Trim() = "" Then
            ShowMessageBox("Veuillez entrer l'URL de l'API.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If Instructions_txt.Text.Trim() = "" Then
            ShowMessageBox("Veuillez entrer l'instruction.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        Dim supprimerDonneeObsolete As Boolean = False


        Dim idSociete = If(Global_chk.Checked, -1, Societe.id_Societe)
        Dim provider = Provider_cbo.Text?.ToString().Replace("'", "''")
        Dim modele = Modele_cbo.Text?.ToString().Replace("'", "''")
        Dim aiUrl = AiUrl_txt.Text.Trim().Replace("'", "''")
        Dim apiKey = ApiKey_txt.Text.Trim().Replace("'", "''")
        Dim instructions = Instructions_txt.Text.Trim().Replace("'", "''")
        Dim sql = $"delete FROM Ai_Agent WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe})={Societe.id_Societe}
                    INSERT INTO Ai_Agent ( id_Societe, Provider, Modele, aiUrl, ApiKey, Instructions,nb_Msg_Memory)
                    VALUES ({idSociete}, '{provider}', '{modele}', '{aiUrl}', '{apiKey}','{instructions}', {IsNull(nb_Msg_Memory.Value, 5)})"

        CnExecuting(sql)
        ShowMessageBox("Configuration enregistrée avec succès.", "Succès", MessageBoxButtons.OK, msgIcon.Information)
    End Sub
    Private Sub Cbo_Provider_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Provider_cbo.SelectedIndexChanged
        Chargement()
        Modele_cbo.Items.Clear()
        If Provider_cbo.SelectedIndex = -1 Then Exit Sub
        Dim strModeles As String = Provider_cbo.SelectedValue
        For Each modele As String In strModeles.Split("|"c)
            Modele_cbo.Items.Add(modele.Trim())
        Next
        AiUrl_txt.Tag = FindLibelle("aiUrl", "Provider", Provider_cbo.Text, "Ai_LLM_Modeles")
    End Sub
    Private Sub Modele_cbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Modele_cbo.SelectedIndexChanged
        AiUrl_txt.Text = IsNull(AiUrl_txt.Tag, "").Replace("{MODEL}", Modele_cbo.Text)
    End Sub
    Private Sub LoadEmbeddingConfig()
        Try
            Dim sql = $"SELECT Provider, Modele, AiUrl, ApiKey FROM Ai_Embedding " &
                  $"WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe}) = {Societe.id_Societe}"

            Dim Tbl As DataTable = DATA_READER_GRD(sql)

            If Tbl.Rows.Count > 0 Then
                Dim Dr As DataRow = Tbl.Rows(0)

                'Embedding Config
                _Ai_Embedding.Config = New Ai_Embedding.EmbeddingConfig() With {
                .Provider = IsNull(Dr("Provider"), "").ToString(),
                .Url = IsNull(Dr("AiUrl"), "").ToString(),
                .Modele = IsNull(Dr("Modele"), "").ToString().Split("|"c)(0).Trim(),
                .ApiKey = IsNull(Dr("ApiKey"), "").ToString(),
                .TimeoutSeconds = 30,
                .RetryCount = 3
            }

                'Ingestion Config
                _ingestionService.ChunkConfig = New AiTextChunker.ChunkConfig() With {
                .ChunkSize = 800,
                .ChunkOverlap = 150,
                .MinChunkSize = 100,
                .Strategy = AiTextChunker.ChunkStrategy.Hybrid,
                .PreserveStructure = True,
                .IncludeMetadata = True
            }
            End If

        Catch ex As Exception
            Debug.WriteLine($"Erreur LoadEmbeddingConfig: {ex.Message}")
        End Try
    End Sub


    Private Sub LoadList()
        Grd_Docs.Rows.Clear()

        Try
            ' Charger depuis la base de données
            Dim sql = $"SELECT Source, COUNT(*) AS NbChunks, MAX(LastModified) AS LastModified  
                       FROM AI_KnowledgeBase where isnull(nullif(id_Societe,-1),{Societe.id_Societe})={Societe.id_Societe} GROUP BY Source ORDER BY Source"

            Dim rs As ADODB.Recordset = CnExecuting(sql)

            If rs.EOF Then
                Grd_Docs.Rows.Add("Aucune base trouvée", "Inactif", "0")
            Else
                While Not rs.EOF
                    Dim source = IsNull(rs.Fields("Source").Value, "").ToString()
                    Dim nbChunks = IsNull(rs.Fields("NbChunks").Value, 0).ToString()
                    Dim lastMod = IsNull(rs.Fields("LastModified").Value, "N/A").ToString()
                    Grd_Docs.Rows.Add(source, "Actif", nbChunks, lastMod)
                    rs.MoveNext()
                End While
            End If

        Catch ex As Exception
            ShowMessageBox("Erreur lors du chargement: " & ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
        End Try
    End Sub

#End Region

#Region "Boutons"

    Async Sub Btn_Importer_Click()
        ' Vérifier la configuration
        Dim configError = _Ai_Embedding.ValidateConfig()
        If Not String.IsNullOrEmpty(configError) Then
            ShowMessageBox("Configuration requise: " & configError, "Configuration", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If

        Using fbd As New FolderBrowserDialog()
            fbd.Description = "Sélectionner le dossier contenant les documents à ingérer"

            If fbd.ShowDialog() = DialogResult.OK Then
                Await LancerIngestion(fbd.SelectedPath)
            End If
        End Using
    End Sub

    Sub Btn_Configurer()
        Dim f As New Zoom_Ai_EmbeddingConfig
        f.ShowDialog()
    End Sub

    Async Sub Btn_TestConnexion_Click() Handles Tester_EmbeddingConn_btn.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim result = Await _Ai_Embedding.TestConnectionAsync()

            If result.Success Then
                ShowMessageBox(
                    $"Connexion réussie !" & vbCrLf &
                    $"Provider: {result.Provider}" & vbCrLf &
                    $"Dimension: {result.Dimension}" & vbCrLf &
                    $"Latence: {result.LatencyMs}ms",
                    "Test Connexion",
                    MessageBoxButtons.OK,
                    msgIcon.Information)
            Else
                ShowMessageBox(
                    $"Échec de connexion" & vbCrLf & result.Message,
                    "Test Connexion",
                    MessageBoxButtons.OK,
                    msgIcon.Stop)
            End If

        Catch ex As Exception
            ShowMessageBox("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Btn_Configurer_Click()
        ' Ouvrir le formulaire de configuration (à créer)
        ' Using frm As New Frm_EmbeddingConfig()
        '     frm.ShowDialog()
        '     LoadEmbeddingConfig()
        ' End Using

        ShowMessageBox("Configuration via le formulaire à implémenter", "Info", MessageBoxButtons.OK, msgIcon.Information)
    End Sub

    Sub Btn_Supprimer_Click()
        If Grd_Docs.CurrentRow Is Nothing Then Return

        Dim source = Grd_Docs.CurrentRow.Cells(0).Value?.ToString()
        If String.IsNullOrEmpty(source) OrElse source = "Aucune base trouvée" Then Return

        Dim confirm = ShowMessageBox(
            $"Supprimer '{source}' de la base de connaissances ?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            msgIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                CnExecuting($"DELETE FROM AI_KnowledgeBase WHERE Source = '{source.Replace("'", "''")}' and id_Societe={Societe.id_Societe}")
                ShowMessageBox("Document supprimé.", "Succès", MessageBoxButtons.OK, msgIcon.Information)
                LoadList()
            Catch ex As Exception
                ShowMessageBox("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
            End Try
        End If
    End Sub

#End Region
    Sub SetButtonsEnabled(enabling As Boolean)
        Save_D.Enabled = enabling
        Importer_D.Enabled = enabling
        Del_D.Enabled = enabling
        Tester_EmbeddingConn_btn.Enabled = enabling
        Config_D.Enabled = enabling
    End Sub
#Region "Ingestion"

    Private Async Function LancerIngestion(folderPath As String) As Task
        If _isProcessing Then
            ShowMessageBox("Une ingestion est déjà en cours.", "Info", MessageBoxButtons.OK, msgIcon.Information)
            Exit Function
        End If

        _isProcessing = True
        Cursor = Cursors.WaitCursor
        SetButtonsEnabled(False)

        Try
            ' Initialiser la barre de progression
            ProgressBar1.Value = 0
            ProgressBar1.Visible = True
            Lbl_Status.Text = "Démarrage de l'ingestion..."

            ' Attacher les événements
            AddHandler _ingestionService.ProgressChanged, AddressOf OnIngestionProgress
            AddHandler _ingestionService.DetailedProgress, AddressOf OnDetailedProgress

            ' Demander si on force la réindexation
            If ShowMessageBox("Voulez-vous forcer la réindexation de tous les fichiers (incluant ceux déjà à jour) ?", "Confirmation", MessageBoxButtons.YesNo, msgIcon.Question) = DialogResult.Yes Then
                _ingestionService.IngestionConfig.SkipUnchangedFiles = False
            Else
                _ingestionService.IngestionConfig.SkipUnchangedFiles = True
            End If

            ' Lancer l'ingestion
            Dim result = Await _ingestionService.IngestDirectoryAsync(folderPath, recursive:=True)

            ' Afficher le résultat
            Dim message = $"Ingestion terminée ({result.Provider})" & vbCrLf &
                      $"• Fichiers traités: {result.ProcessedFiles}" & vbCrLf &
                      $"• Fichiers ignorés: {result.SkippedFiles}" & vbCrLf &
                      $"• Erreurs: {result.FailedFiles}" & vbCrLf &
                      $"• Chunks créés: {result.TotalChunks}" & vbCrLf &
                      $"• Temps: {result.TotalProcessingTimeMs / 1000:F1}s"

            If result.SkippedFiles > 0 Then
                message &= vbCrLf & vbCrLf & "Fichiers ignorés :" & vbCrLf
                For Each skipped In result.FileResults.Where(Function(r) r.Status = IngestionService.IngestionStatus.Skipped).Take(5)
                    message &= $"- {skipped.FileName}: {skipped.ErrorMessage}" & vbCrLf
                Next
                If result.SkippedFiles > 5 Then message &= "... et " & (result.SkippedFiles - 5) & " autres."
            End If

            If result.FailedFiles > 0 Then
                message &= vbCrLf & vbCrLf & "Erreurs :" & vbCrLf
                For Each failed In result.FileResults.Where(Function(r) r.Status = IngestionService.IngestionStatus.Failed).Take(5)
                    message &= $"- {failed.FileName}: {failed.ErrorMessage}" & vbCrLf
                Next
                If result.FailedFiles > 5 Then message &= "... et " & (result.FailedFiles - 5) & " autres."
            End If

            ShowMessageBox(message, "Résultat", MessageBoxButtons.OK,
                      If(result.FailedFiles > 0, msgIcon.Warning, msgIcon.Information))

        Catch ex As Exception
            ShowMessageBox("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Stop)

        Finally
            ' Detach event handlers
            RemoveHandler _ingestionService.ProgressChanged, AddressOf OnIngestionProgress
            RemoveHandler _ingestionService.DetailedProgress, AddressOf OnDetailedProgress

            _isProcessing = False
            Cursor = Cursors.Default
            SetButtonsEnabled(True)
            ProgressBar1.Visible = False
            Lbl_Status.Text = ""
            LoadList()
        End Try
    End Function
    ''' <summary>
    ''' Gestionnaire de l'événement de progression
    ''' </summary>
    Private Sub OnIngestionProgress(current As Integer, total As Integer, result As IngestionService.FileIngestionResult)
        If InvokeRequired Then
            Invoke(Sub() OnIngestionProgress(current, total, result))
        Else
            ' Reset progress bar for next file
            ProgressBar1.Value = 0

            Dim status As String = ""
            Select Case result.Status
                Case IngestionService.IngestionStatus.Completed
                    status = "Traité"
                Case IngestionService.IngestionStatus.Skipped
                    status = "Ignoré"
                Case IngestionService.IngestionStatus.Failed
                    status = "Erreur"
            End Select

            Lbl_Status.Text = $"[{current}/{total}] {result.FileName} - {status}"

            ' Ajouter à la grille ou liste
            ' ... (code existant pour ajouter à la grille)
        End If
    End Sub

    Private Sub OnDetailedProgress(current As Integer, total As Integer, message As String)
        If InvokeRequired Then
            Invoke(Sub() OnDetailedProgress(current, total, message))
        Else
            If total > 0 Then
                ProgressBar1.Maximum = total
                ProgressBar1.Value = current
            Else
                ProgressBar1.Value = 0
            End If

            Lbl_Status.Text = message
            Lbl_Status.Refresh()
            ProgressBar1.Refresh()
            Application.DoEvents()
        End If
    End Sub
#End Region
    Private Async Sub TesterConn_pb_Click(sender As Object, e As EventArgs) Handles TesterConn_pb.Click
        ' Validation
        If Provider_cbo.SelectedIndex = -1 Then
            ShowMessageBox("Selectionnez un Provider", "Validation", MessageBoxButtons.OK, msgIcon.Warning)
            Exit Sub
        End If
        If Modele_cbo.SelectedIndex = -1 Then
            ShowMessageBox("Selectionnez un Modele", "Validation", MessageBoxButtons.OK, msgIcon.Warning)
            Exit Sub
        End If
        If AiUrl_txt.Text = "" Then
            ShowMessageBox("Saisissez l'Url", "Validation", MessageBoxButtons.OK, msgIcon.Warning)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            Dim provider = Provider_cbo.Text.ToUpper()
            Dim modele = Modele_cbo.Text
            Dim url = AiUrl_txt.Text.Replace("{MODEL}", modele)
            Dim apiKey = ApiKey_txt.Text.Trim()

            ' Special URL handling
            If provider = "GEMINI" AndAlso Not url.Contains("key=") Then
                url &= $"?key={apiKey}"
            End If

            ' Create Request
            Dim request = WebRequest.Create(url)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.Timeout = 10000 ' 10s timeout

            ' Auth Headers
            If provider <> "GEMINI" AndAlso provider <> "OLLAMA" AndAlso apiKey <> "" Then
                request.Headers.Add("Authorization", "Bearer " & apiKey)
            ElseIf provider = "AZUREOPENAI" Then
                request.Headers.Add("api-key", apiKey)
            End If

            ' Build Payload
            Dim payload As Object
            If provider = "GEMINI" Then
                payload = New With {
                    .contents = New Object() {
                        New With {
                            .parts = New Object() {
                                New With {.text = "Hello"}
                            }
                        }
                    }
                }
            ElseIf provider = "OLLAMA" Then
                payload = New With {
                    .model = modele,
                    .prompt = "Hello",
                    .stream = False
                }
            Else
                ' OpenAI Standard (Mistral, Groq, etc)
                payload = New With {
                    .model = modele,
                    .messages = New Object() {
                        New With {
                            .role = "user",
                            .content = "Hello"
                        }
                    }
                }
            End If

            ' Send Request
            Dim data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload))
            request.ContentLength = data.Length
            Using stream = Await request.GetRequestStreamAsync()
                Await stream.WriteAsync(data, 0, data.Length)
            End Using

            ' Get Response
            Using response = Await request.GetResponseAsync()
                Using reader = New StreamReader(response.GetResponseStream())
                    Dim result = Await reader.ReadToEndAsync()
                    ShowMessageBox($"Connexion Réussie!{vbCrLf}Réponse reçue du serveur.", "Succès", MessageBoxButtons.OK, msgIcon.Information)
                End Using
            End Using

        Catch ex As Exception
            Dim msg = ex.Message
            If TypeOf ex Is WebException Then
                Dim wex = CType(ex, WebException)
                If wex.Response IsNot Nothing Then
                    Using reader = New StreamReader(wex.Response.GetResponseStream())
                        msg &= vbCrLf & "Details: " & reader.ReadToEnd()
                    End Using
                End If
            End If
            ShowMessageBox("Erreur de connexion:" & vbCrLf & msg, "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AddModele_pb_Click(sender As Object, e As EventArgs) Handles AddModele_pb.Click
        Dim f As New Zoom_AddModele
        With f
            .Typ_Modele_lbl.Text = "LLM"
            .Provider_txt.Text = Provider_cbo.Text.Trim
            .modele_txt.Text = Modele_cbo.Text.Trim
            .Url_txt.Text = AiUrl_txt.Tag.Trim
            .frm01 = Me
            .ShowDialog()
        End With
    End Sub
End Class