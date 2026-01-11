Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Imports Newtonsoft.Json
Imports System.Threading.Tasks
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports DevExpress.XtraRichEdit

''' <summary>
''' Service d'Ingestion de Documents pour RAG
''' Gère le chunking, l'extraction de texte et l'insertion en base
''' </summary>
Public Class IngestionService

#Region "Singleton Pattern"

    Private Shared _instance As IngestionService
    Private Shared ReadOnly _lock As New Object()

    ''' <summary>
    ''' Instance unique du service
    ''' </summary>
    Public Shared ReadOnly Property Instance As IngestionService
        Get
            If _instance Is Nothing Then
                SyncLock _lock
                    If _instance Is Nothing Then
                        _instance = New IngestionService()
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property

    Private Sub New()
        ChunkConfig = New AiTextChunker.ChunkConfig()
        IngestionConfig = New IngestionSettings()
    End Sub

#End Region

#Region "Énumérations"
    Public Enum IngestionStatus
        Pending
        Processing
        Completed
        Skipped
        Failed
    End Enum

#End Region

#Region "Configuration"

    ''' <summary>
    ''' Configuration de l'ingestion
    ''' </summary>
    Public Class IngestionSettings
        Public Property SupportedExtensions As String() = {".txt", ".pdf", ".md", ".docx", ".html", ".htm", ".json", ".csv"}
        Public Property SkipUnchangedFiles As Boolean = True
        Public Property DeleteOldChunksBeforeInsert As Boolean = True
        Public Property ConnectionString As String = ""
        Public Property TableName As String = "AI_KnowledgeBase"
        Public Property BatchInsertSize As Integer = 50
        Public Property UseTransaction As Boolean = True
    End Class

    ''' <summary>
    ''' Configuration du chunking
    ''' </summary>
    Public Property ChunkConfig As AiTextChunker.ChunkConfig

    ''' <summary>
    ''' Configuration de l'ingestion
    ''' </summary>
    Public Property IngestionConfig As IngestionSettings

#End Region

#Region "Modèles de données"

    ''' <summary>
    ''' Résultat d'ingestion d'un fichier
    ''' </summary>
    Public Class FileIngestionResult
        Public Property FileName As String
        Public Property FilePath As String
        Public Property Status As IngestionStatus
        Public Property ChunksCreated As Integer
        Public Property ErrorMessage As String
        Public Property ProcessingTimeMs As Long
    End Class

    ''' <summary>
    ''' Résultat global d'ingestion
    ''' </summary>
    Public Class IngestionResult
        Public Property TotalFiles As Integer
        Public Property ProcessedFiles As Integer
        Public Property SkippedFiles As Integer
        Public Property FailedFiles As Integer
        Public Property TotalChunks As Integer
        Public Property TotalProcessingTimeMs As Long
        Public Property FileResults As List(Of FileIngestionResult)
        Public Property Provider As String

        Public Sub New()
            FileResults = New List(Of FileIngestionResult)
        End Sub

        Public Overrides Function ToString() As String
            Return $"Ingestion terminée ({Provider}): {ProcessedFiles} traités, {SkippedFiles} ignorés, {FailedFiles} erreurs, {TotalChunks} chunks créés"
        End Function
    End Class

#End Region

#Region "Ingestion Principale"

    ''' <summary>
    ''' Ingérer tous les fichiers d'un répertoire
    ''' </summary>
    Public Async Function IngestDirectoryAsync(folderPath As String, Optional recursive As Boolean = False) As Task(Of IngestionResult)
        Dim result As New IngestionResult()
        result.Provider = Ai_Embedding.Instance.Config.Provider.ToString()

        Dim sw = Diagnostics.Stopwatch.StartNew()

        ' Valider le service d'embedding
        Dim embeddingError = Ai_Embedding.Instance.ValidateConfig()
        If Not String.IsNullOrEmpty(embeddingError) Then
            result.FailedFiles = 1
            result.FileResults.Add(New FileIngestionResult() With {
                .Status = IngestionStatus.Failed,
                .ErrorMessage = embeddingError
            })
            Return result
        End If

        ' Charger l'index existant
        Dim existingFiles = LoadExistingFilesIndex()
        Dim searchOption As SearchOption = If(recursive, SearchOption.AllDirectories, SearchOption.TopDirectoryOnly)

        Dim files = Directory.GetFiles(folderPath, "*.*", searchOption).
                    Where(Function(f) IngestionConfig.SupportedExtensions.
                          Any(Function(ext) f.ToLower().EndsWith(ext))).ToList()

        result.TotalFiles = files.Count

        ' Traiter chaque fichier
        Dim fileIndex As Integer = 0
        For Each filePath In files
            fileIndex += 1
            Dim fileResult = Await IngestFileAsync(filePath, existingFiles, fileIndex, result.TotalFiles)
            result.FileResults.Add(fileResult)

            Select Case fileResult.Status
                Case IngestionStatus.Completed
                    result.ProcessedFiles += 1
                    result.TotalChunks += fileResult.ChunksCreated
                Case IngestionStatus.Skipped
                    result.SkippedFiles += 1
                Case IngestionStatus.Failed
                    result.FailedFiles += 1
            End Select

            ' Lever l'événement de progression
            RaiseEvent ProgressChanged(result.ProcessedFiles + result.SkippedFiles + result.FailedFiles, result.TotalFiles, fileResult)
        Next

        sw.Stop()
        result.TotalProcessingTimeMs = sw.ElapsedMilliseconds

        Return result
    End Function

    ''' <summary>
    ''' Ingérer un fichier unique
    ''' </summary>
    Public Async Function IngestFileAsync(filePath As String, Optional existingFiles As Dictionary(Of String, Date) = Nothing, Optional currentFileIndex As Integer = 0, Optional totalFiles As Integer = 0) As Task(Of FileIngestionResult)
        Dim result As New FileIngestionResult() With {
            .FilePath = filePath,
            .FileName = System.IO.Path.GetFileName(filePath)
        }

        Dim sw = Diagnostics.Stopwatch.StartNew()

        Try
            Dim fileInfo As New FileInfo(filePath)
            Dim lastMod = fileInfo.LastWriteTime

            ' Vérifier si fichier inchangé
            If existingFiles IsNot Nothing AndAlso IngestionConfig.SkipUnchangedFiles Then
                If existingFiles.ContainsKey(result.FileName) Then
                    If Math.Abs((existingFiles(result.FileName) - lastMod).TotalSeconds) < 1 Then
                        result.Status = IngestionStatus.Skipped
                        result.ErrorMessage = "Fichier inchangé (Date identique)"
                        sw.Stop()
                        result.ProcessingTimeMs = sw.ElapsedMilliseconds
                        Return result
                    End If
                End If
            End If

            ' Préparer le préfixe de message
            Dim progressPrefix = If(totalFiles > 0, $"[{result.FileName}] [{currentFileIndex}/{totalFiles}] ", $"[{result.FileName}] ")

            ' Extraire le texte
            RaiseEvent DetailedProgress(0, 0, $"{progressPrefix}Extraction du texte...")
            Dim rawText = ExtractText(filePath)
            If String.IsNullOrWhiteSpace(rawText) Then
                result.Status = IngestionStatus.Skipped
                result.ErrorMessage = "Contenu vide"
                sw.Stop()
                result.ProcessingTimeMs = sw.ElapsedMilliseconds
                Return result
            End If

            ' Chunking
            RaiseEvent DetailedProgress(0, 0, $"{progressPrefix}Découpage en chunks...")
            Dim chunks = AiTextChunker.ChunkText(rawText, ChunkConfig)
            If chunks.Count = 0 Then
                result.Status = IngestionStatus.Skipped
                result.ErrorMessage = "Aucun chunk généré"
                sw.Stop()
                result.ProcessingTimeMs = sw.ElapsedMilliseconds
                Return result
            End If

            ' Supprimer les anciens chunks
            If IngestionConfig.DeleteOldChunksBeforeInsert Then
                RaiseEvent DetailedProgress(0, 0, $"{progressPrefix}Nettoyage anciens chunks...")
                DeleteExistingChunks(result.FileName)
            End If

            ' Générer les embeddings et insérer
            Dim chunkIndex As Integer = 0
            For Each chunk In chunks
                chunkIndex += 1

                RaiseEvent DetailedProgress(chunkIndex, chunks.Count, $"{progressPrefix}Embedding chunk {chunkIndex}/{chunks.Count}...")
                Dim embedding = Await Ai_Embedding.Instance.GetEmbeddingAsync(chunk.Text)

                If embedding.Length > 0 Then
                    RaiseEvent DetailedProgress(chunkIndex, chunks.Count, $"{progressPrefix}Sauvegarde chunk {chunkIndex}/{chunks.Count}...")
                    InsertChunk(chunk, result.FileName, lastMod, embedding)
                    result.ChunksCreated += 1
                End If
            Next

            result.Status = IngestionStatus.Completed

        Catch ex As Exception
            result.Status = IngestionStatus.Failed
            result.ErrorMessage = ex.Message
        End Try

        sw.Stop()
        result.ProcessingTimeMs = sw.ElapsedMilliseconds

        Return result
    End Function

    ''' <summary>
    ''' Ingérer un texte directement (sans fichier)
    ''' </summary>
    Public Async Function IngestTextAsync(text As String, sourceName As String) As Task(Of FileIngestionResult)
        Dim result As New FileIngestionResult() With {
            .FileName = sourceName,
            .FilePath = ""
        }

        Dim sw = Diagnostics.Stopwatch.StartNew()

        Try
            If String.IsNullOrWhiteSpace(text) Then
                result.Status = IngestionStatus.Skipped
                result.ErrorMessage = "Contenu vide"
                Return result
            End If

            ' Chunking
            Dim chunks = AiTextChunker.ChunkText(text, ChunkConfig)

            ' Supprimer les anciens chunks
            If IngestionConfig.DeleteOldChunksBeforeInsert Then
                DeleteExistingChunks(sourceName)
            End If

            ' Générer les embeddings et insérer
            Dim chunkIndex As Integer = 0
            For Each chunk In chunks
                chunkIndex += 1
                RaiseEvent DetailedProgress(chunkIndex, chunks.Count, $"Traitement chunk {chunkIndex}/{chunks.Count}...")

                Dim embedding = Await Ai_Embedding.Instance.GetEmbeddingAsync(chunk.Text)
                If embedding.Length > 0 Then
                    InsertChunk(chunk, sourceName, DateTime.Now, embedding)
                    result.ChunksCreated += 1
                End If
            Next

            result.Status = IngestionStatus.Completed

        Catch ex As Exception
            result.Status = IngestionStatus.Failed
            result.ErrorMessage = ex.Message
        End Try

        sw.Stop()
        result.ProcessingTimeMs = sw.ElapsedMilliseconds

        Return result
    End Function

#End Region





#Region "Extraction de Texte"

    ''' <summary>
    ''' Extraire le texte d'un fichier
    ''' </summary>
    Public Function ExtractText(filePath As String) As String
        Dim ext = System.IO.Path.GetExtension(filePath).ToLower()

        Select Case ext
            Case ".txt", ".md"
                Return File.ReadAllText(filePath, Encoding.UTF8)

            Case ".html", ".htm"
                Return ExtractTextFromHtml(File.ReadAllText(filePath, Encoding.UTF8))

            Case ".json"
                Return ExtractTextFromJson(File.ReadAllText(filePath, Encoding.UTF8))

            Case ".csv"
                Return ExtractTextFromCsv(filePath)

            Case ".pdf"
                Return ExtractTextFromPdf(filePath)

            Case ".docx"
                Return ExtractTextFromDocx(filePath)

            Case Else
                Return ""
        End Select
    End Function

    Private Function ExtractTextFromHtml(html As String) As String
        ' Supprimer scripts et styles
        html = Regex.Replace(html, "<script[^>]*>[\s\S]*?</script>", "", RegexOptions.IgnoreCase)
        html = Regex.Replace(html, "<style[^>]*>[\s\S]*?</style>", "", RegexOptions.IgnoreCase)
        ' Supprimer les balises
        html = Regex.Replace(html, "<[^>]+>", " ")
        ' Décoder les entités HTML
        html = System.Net.WebUtility.HtmlDecode(html)
        ' Nettoyer les espaces
        html = Regex.Replace(html, "\s+", " ")
        Return html.Trim()
    End Function

    Private Function ExtractTextFromJson(json As String) As String
        Try
            Dim obj = JsonConvert.DeserializeObject(Of Object)(json)
            Return JsonConvert.SerializeObject(obj, Formatting.Indented)
        Catch
            Return json
        End Try
    End Function

    Private Function ExtractTextFromCsv(filePath As String) As String
        Dim sb As New StringBuilder()
        Dim lines = File.ReadAllLines(filePath, Encoding.UTF8)

        For Each line In lines
            sb.AppendLine(line.Replace(",", " | ").Replace(";", " | "))
        Next

        Return sb.ToString()
    End Function

    Private Function ExtractTextFromPdf(filePath As String) As String
        Try
            Dim text As New StringBuilder()
            Using reader As New PdfReader(filePath)
                For i As Integer = 1 To reader.NumberOfPages
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i))
                    text.Append(vbLf)
                Next
            End Using
            Return text.ToString()
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function ExtractTextFromDocx(filePath As String) As String
        Try
            Using server As New RichEditDocumentServer()
                server.LoadDocument(filePath)
                Return server.Text
            End Using
        Catch ex As Exception
            Return ""
        End Try
    End Function

#End Region

#Region "Base de données"

    ''' <summary>
    ''' Charger l'index des fichiers existants
    ''' </summary>
    Private Function LoadExistingFilesIndex() As Dictionary(Of String, Date)
        Dim existingFiles As New Dictionary(Of String, Date)

        Try
            Dim sql = $"SELECT DISTINCT Source, MAX(LastModified) AS LastModified FROM {IngestionConfig.TableName} WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe}) = {Societe.id_Societe} GROUP BY Source"
            Dim rs As ADODB.Recordset = CnExecuting(sql)

            While Not rs.EOF
                Dim src = IsNull(rs.Fields("Source").Value, "").ToString()
                Dim dat = CDate(IsNull(rs.Fields("LastModified").Value, Date.MinValue))
                If Not existingFiles.ContainsKey(src) Then
                    existingFiles.Add(src, dat)
                End If
                rs.MoveNext()
            End While
        Catch ex As Exception
            Debug.WriteLine($"Erreur chargement index: {ex.Message}")
        End Try

        Return existingFiles
    End Function

    ''' <summary>
    ''' Supprimer les chunks existants d'un fichier
    ''' </summary>
    Private Sub DeleteExistingChunks(source As String)
        Try
            Dim sql = $"DELETE FROM {IngestionConfig.TableName} WHERE Source = '{SqlEscape(source)}' AND ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe}) = {Societe.id_Societe}"
            CnExecuting(sql)
        Catch ex As Exception
            Debug.WriteLine($"Erreur suppression chunks: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Insérer un chunk en base
    ''' </summary>
    Private Sub InsertChunk(chunk As AiTextChunker.ChunkResult, source As String, lastMod As Date, embedding As Double())
        Dim embJson = JsonConvert.SerializeObject(embedding)
        Dim keywords = String.Join(",", chunk.Metadata.Keywords.Take(10))

        Dim sql = $"INSERT INTO {IngestionConfig.TableName} " &
                  "(Id, id_Societe, Source, ChunkIndex, TextChunk, Embedding, LastModified, Section, Keywords, TokenCount, HasCodeBlock, HasTable, Provider_Used, Modele_Used) " &
                  "VALUES (" &
                  $"'{chunk.Id}', " &
                  $"{Societe.id_Societe}, " &
                  $"'{SqlEscape(source)}', " &
                  $"{chunk.Index}, " &
                  $"'{SqlEscape(chunk.Text)}', " &
                  $"'{embJson}', " &
                  $"'{lastMod:yyyyMMdd HH:mm:ss}', " &
                  $"'{SqlEscape(chunk.Metadata.Section)}', " &
                  $"'{SqlEscape(keywords)}', " &
                  $"{chunk.TokenCount}, " &
                  $"{If(chunk.Metadata.HasCodeBlock, 1, 0)}, " &
                  $"{If(chunk.Metadata.HasTable, 1, 0)}, " &
                  $"'{SqlEscape(Ai_Embedding.Instance.Config.Provider)}', " &
                  $"'{SqlEscape(Ai_Embedding.Instance.Config.Modele)}')"

        CnExecuting(sql)
    End Sub

    Private Function SqlEscape(str As String) As String
        If String.IsNullOrEmpty(str) Then Return ""
        Return str.Replace("'", "''")
    End Function

#End Region

#Region "Événements"

    ''' <summary>
    ''' Événement de progression
    ''' </summary>
    Public Event ProgressChanged(current As Integer, total As Integer, fileResult As FileIngestionResult)
    Public Event DetailedProgress(current As Integer, total As Integer, message As String)

#End Region

End Class