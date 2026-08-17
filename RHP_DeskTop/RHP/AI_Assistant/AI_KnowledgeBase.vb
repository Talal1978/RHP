Imports System.Threading.Tasks

''' <summary>
''' Gestion de la Base de Connaissance IA — procédé d'EMBEDDING uniquement :
''' import d'un dossier de documents, découpage en chunks et vectorisation
''' (table AI_KnowledgeBase, configuration Ai_Embedding via le zoom
''' Zoom_Ai_EmbeddingConfig). La gestion des modèles LLM (table Ai_Agent) est
''' isolée dans l'écran séparé AI_Modeles.
''' La suppression d'une source de la liste (bouton Del_D) supprime, après
''' confirmation, TOUS les chunks associés à cette source (toutes portées
''' visibles : globale + société courante).
''' </summary>
Partial Public Class AI_KnowledgeBase
    Dim Importer_D As ud_btn
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
        If Importer_D Is Nothing Then
            Importer_D = dictButtons("Importer_D")
            Del_D = dictButtons("Del_D")
            Config_D = dictButtons("Config_D")
            With Grd_Docs
                .DefaultCellStyle.SelectionBackColor = colorBase04
            End With
            ' Charger la configuration d'embedding
            LoadEmbeddingConfig()
        End If
    End Sub
    Sub Request()
        Chargement()
        ' Charger la liste des documents
        LoadList()
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

    ''' <summary>Supprime une source de la base de connaissances : après alerte de
    ''' confirmation (rappelant le nombre de chunks), TOUS les chunks associés à la
    ''' source sont supprimés (portées visibles : globale + société courante).</summary>
    Sub Btn_Supprimer_Click()
        If Grd_Docs.CurrentRow Is Nothing Then Return

        Dim source = Grd_Docs.CurrentRow.Cells(0).Value?.ToString()
        If String.IsNullOrEmpty(source) OrElse source = "Aucune base trouvée" Then Return

        Dim nbChunks As Integer = 0
        Integer.TryParse(IsNull(Grd_Docs.CurrentRow.Cells(2).Value, "0").ToString(), nbChunks)

        Dim confirm = ShowMessageBox(
            $"Supprimer '{source}' de la base de connaissances ?" & vbCrLf &
            $"Les {nbChunks} segment(s) (chunks) associés seront définitivement supprimés.",
            "Confirmation",
            MessageBoxButtons.YesNo,
            msgIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                CnExecuting($"DELETE FROM AI_KnowledgeBase WHERE Source = '{source.Replace("'", "''")}' AND ISNULL(NULLIF(id_Societe,-1), {Societe.id_Societe}) = {Societe.id_Societe}")
                ShowMessageBox("Document et segments associés supprimés.", "Succès", MessageBoxButtons.OK, msgIcon.Information)
                LoadList()
            Catch ex As Exception
                ShowMessageBox("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
            End Try
        End If
    End Sub

#End Region
    Sub SetButtonsEnabled(enabling As Boolean)
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
End Class
