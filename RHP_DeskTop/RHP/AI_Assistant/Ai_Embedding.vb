Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports System.Threading.Tasks

''' <summary>
''' Service d'Embedding - Configuration depuis Base de Données
''' Table: Ai_Embedding_Modeles (Provider, Url, Modele)
''' </summary>
Public Class Ai_Embedding

#Region "Singleton"

    Private Shared _instance As Ai_Embedding
    Private Shared ReadOnly _lock As New Object()

    Public Shared ReadOnly Property Instance As Ai_Embedding
        Get
            If _instance Is Nothing Then
                SyncLock _lock
                    If _instance Is Nothing Then
                        _instance = New Ai_Embedding()
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property

    Private Sub New()
        Config = New EmbeddingConfig()
    End Sub

#End Region

#Region "Configuration"

    Public Class EmbeddingConfig
        Public Property Provider As String = ""
        Public Property Url As String = ""
        Public Property Modele As String = ""
        Public Property ApiKey As String = ""
        Public Property TimeoutSeconds As Integer = 30
        Public Property RetryCount As Integer = 3
        Public Property RetryDelayMs As Integer = 1000
    End Class

    Public Property Config As EmbeddingConfig

    ''' <summary>
    ''' Charger la configuration depuis la base de données
    ''' </summary>
    Public Sub LoadConfigFromDatabase(Optional modeleIndex As Integer = 0)
        Try
            Dim sql = "SELECT TOP (1) Provider, Url, Modele, ApiKey " &
                  "FROM Ai_Embedding_Modeles " &
                  $"WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe}) = {Societe.id_Societe}"

            Dim rs As ADODB.Recordset = CnExecuting(sql)

            If Not rs.EOF Then
                Config.Provider = IsNull(rs.Fields("Provider").Value, "").ToString()
                Config.Url = IsNull(rs.Fields("Url").Value, "").ToString()
                Config.ApiKey = IsNull(rs.Fields("ApiKey").Value, "").ToString()

                ' Récupérer le modèle selon l'index (séparés par |)
                Dim modeles = IsNull(rs.Fields("Modele").Value, "").ToString().Split("|"c)
                If modeleIndex < modeles.Length Then
                    Config.Modele = modeles(modeleIndex).Trim()
                Else
                    Config.Modele = modeles(0).Trim()
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine($"Erreur chargement config: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Obtenir la liste des modèles disponibles pour un provider
    ''' </summary>
    Public Shared Function GetModeles(provider As String) As String()
        Try
            Dim sql = $"SELECT Modele FROM Ai_Embedding_Modeles WHERE Provider = '{provider}'"
            Dim rs As ADODB.Recordset = CnExecuting(sql)

            If Not rs.EOF Then
                Dim modeles = IsNull(rs.Fields("Modele").Value, "").ToString()
                Return modeles.Split("|"c).Select(Function(m) m.Trim()).ToArray()
            End If
        Catch ex As Exception
            Debug.WriteLine($"Erreur: {ex.Message}")
        End Try

        Return New String() {}
    End Function

    ''' <summary>
    ''' Obtenir la liste des providers disponibles
    ''' </summary>
    Public Shared Function GetProviders() As List(Of String)
        Dim providers As New List(Of String)

        Try
            Dim sql = "SELECT Provider FROM Ai_Embedding_Modeles ORDER BY Provider"
            Dim rs As ADODB.Recordset = CnExecuting(sql)

            While Not rs.EOF
                providers.Add(IsNull(rs.Fields("Provider").Value, "").ToString())
                rs.MoveNext()
            End While
        Catch ex As Exception
            Debug.WriteLine($"Erreur: {ex.Message}")
        End Try

        Return providers
    End Function

#End Region

#Region "Méthode Principale"

    ''' <summary>
    ''' Obtenir un embedding pour un texte
    ''' </summary>
    Public Async Function GetEmbeddingAsync(text As String) As Task(Of Double())
        If String.IsNullOrWhiteSpace(text) Then Return New Double() {}
        If String.IsNullOrEmpty(Config.Provider) Then Return New Double() {}

        Dim retryCount As Integer = 0
        Dim lastError As Exception = Nothing
        Dim currentDelay As Integer = 0

        While retryCount < Config.RetryCount
            ' Attendre avant retry (si nécessaire)
            If currentDelay > 0 Then
                Await Task.Delay(currentDelay)
                currentDelay = 0
            End If

            Try
                Return Await CallEmbeddingApiAsync(text)

            Catch ex As System.Net.WebException
                lastError = ex

                ' Check for 429 Too Many Requests
                Dim is429 As Boolean = False
                If ex.Response IsNot Nothing Then
                    Dim httpResponse = TryCast(ex.Response, System.Net.HttpWebResponse)
                    If httpResponse IsNot Nothing AndAlso httpResponse.StatusCode = 429 Then ' TooManyRequests
                        is429 = True
                    End If
                End If

                If is429 Then
                    ' Exponential backoff for rate limits: 5s, 10s, 20s...
                    currentDelay = CInt(5000 * Math.Pow(2, retryCount))
                    Debug.WriteLine($"[{Config.Provider}] 429 Too Many Requests. Configured wait: {currentDelay}ms before retry {retryCount + 1}/{Config.RetryCount}")
                Else
                    ' Standard error handling
                    currentDelay = Config.RetryDelayMs
                End If
                retryCount += 1

            Catch ex As Exception
                lastError = ex
                currentDelay = Config.RetryDelayMs
                retryCount += 1
            End Try
        End While

        If lastError IsNot Nothing Then
            Throw lastError
        End If

        Return New Double() {}
    End Function

    ''' <summary>
    ''' Obtenir des embeddings en batch
    ''' </summary>
    Public Async Function GetEmbeddingsBatchAsync(texts As List(Of String), Optional batchSize As Integer = 10) As Task(Of List(Of Double()))
        Dim results As New List(Of Double())

        For i = 0 To texts.Count - 1 Step batchSize
            Dim batch = texts.Skip(i).Take(batchSize).ToList()
            Dim tasks = batch.Select(Function(t) GetEmbeddingAsync(t)).ToList()
            Dim batchResults = Await Task.WhenAll(tasks)
            results.AddRange(batchResults)
        Next

        Return results
    End Function

#End Region

#Region "Appel API Unifié"

    Private Async Function CallEmbeddingApiAsync(text As String) As Task(Of Double())
        Dim url = BuildUrl()
        Dim request = CreateWebRequest(url)

        ' Ajouter l'authentification selon le provider
        AddAuthentication(request)

        ' Construire le payload selon le provider
        Dim payload = BuildPayload(text)

        ' Envoyer la requête
        Dim dataBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload))
        request.ContentLength = dataBytes.Length

        Using stream = Await request.GetRequestStreamAsync()
            Await stream.WriteAsync(dataBytes, 0, dataBytes.Length)
        End Using

        ' Lire et parser la réponse
        Using response = Await request.GetResponseAsync()
            Using reader As New StreamReader(response.GetResponseStream())
                Dim jsonString = Await reader.ReadToEndAsync()
                Return ParseEmbeddingResponse(jsonString)
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Construire l'URL finale
    ''' </summary>
    Private Function BuildUrl() As String
        Dim url = Config.Url

        ' Remplacer les placeholders
        url = url.Replace("{MODEL}", Config.Modele)

        ' Ajouter la clé API dans l'URL pour Gemini
        If Config.Provider.ToUpper() = "GEMINI" Then
            url = $"{url}?key={Config.ApiKey}"
        End If

        Return url
    End Function

    ''' <summary>
    ''' Ajouter l'authentification à la requête
    ''' </summary>
    Private Sub AddAuthentication(request As System.Net.HttpWebRequest)
        If String.IsNullOrEmpty(Config.ApiKey) Then Return

        Select Case Config.Provider.ToUpper()
            Case "OPENAI", "MISTRAL", "COHERE", "VOYAGEAI", "HUGGINGFACE", "KIMI", "MOONSHOT"
                request.Headers.Add("Authorization", "Bearer " & Config.ApiKey)

            Case "AZUREOPENAI"
                request.Headers.Add("api-key", Config.ApiKey)

            Case "GEMINI"
                ' Clé dans l'URL, déjà gérée dans BuildUrl()

            Case "OLLAMA"
                ' Pas d'authentification requise

        End Select
    End Sub

    ''' <summary>
    ''' Construire le payload selon le provider
    ''' </summary>
    Private Function BuildPayload(text As String) As Object
        Select Case Config.Provider.ToUpper()
            Case "GEMINI"
                Return New With {
                    .content = New With {
                        .parts = New Object() {New With {.text = text}}
                    }
                }

            Case "OLLAMA"
                Return New With {
                    .model = Config.Modele,
                    .prompt = text
                }

            Case "COHERE"
                Return New With {
                    .texts = New String() {text},
                    .model = Config.Modele,
                    .input_type = "search_document"
                }

            Case "MISTRAL"
                Return New With {
                    .input = New String() {text},
                    .model = Config.Modele,
                    .encoding_format = "float"
                }

            Case Else ' OpenAI, Azure, VoyageAI, HuggingFace, etc.
                Return New With {
                    .input = text,
                    .model = Config.Modele
                }
        End Select
    End Function

    ''' <summary>
    ''' Parser la réponse selon le format du provider
    ''' </summary>
    Private Function ParseEmbeddingResponse(jsonString As String) As Double()
        Select Case Config.Provider.ToUpper()
            Case "GEMINI"
                Dim result = JsonConvert.DeserializeObject(Of GeminiResponse)(jsonString)
                Return result?.embedding?.values

            Case "OLLAMA"
                Dim result = JsonConvert.DeserializeObject(Of OllamaResponse)(jsonString)
                Return result?.embedding

            Case "COHERE"
                Dim result = JsonConvert.DeserializeObject(Of CohereResponse)(jsonString)
                Return result?.embeddings?(0)

            Case Else ' OpenAI, Azure, Mistral, VoyageAI, etc.
                Dim result = JsonConvert.DeserializeObject(Of OpenAIResponse)(jsonString)
                Return result?.data?(0)?.embedding
        End Select

        Return New Double() {}
    End Function

#End Region

#Region "Classes de Réponse (minimales)"

    Private Class OpenAIResponse
        Public Property data As List(Of EmbeddingData)
    End Class

    Private Class EmbeddingData
        Public Property embedding As Double()
    End Class

    Private Class GeminiResponse
        Public Property embedding As GeminiEmbedding
    End Class

    Private Class GeminiEmbedding
        Public Property values As Double()
    End Class

    Private Class OllamaResponse
        Public Property embedding As Double()
    End Class

    Private Class CohereResponse
        Public Property embeddings As List(Of Double())
    End Class

#End Region

#Region "Utilitaires HTTP"

    Private Function CreateWebRequest(url As String) As System.Net.HttpWebRequest
        Dim request = DirectCast(System.Net.WebRequest.Create(url), System.Net.HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Timeout = Config.TimeoutSeconds * 1000
        Return request
    End Function

#End Region

#Region "Validation et Test"

    ''' <summary>
    ''' Valider la configuration
    ''' </summary>
    Public Function ValidateConfig() As String
        If String.IsNullOrEmpty(Config.Provider) Then Return "Provider non configuré"
        If String.IsNullOrEmpty(Config.Url) Then Return "URL non configurée"
        If String.IsNullOrEmpty(Config.Modele) Then Return "Modèle non configuré"

        ' Vérifier si API Key requise
        Dim provider = Config.Provider.ToUpper()
        If provider <> "OLLAMA" AndAlso String.IsNullOrEmpty(Config.ApiKey) Then
            Return $"{Config.Provider}: API Key manquante"
        End If

        ' Tester la connexion Ollama
        If provider = "OLLAMA" Then
            Try
                Dim testUrl = Config.Url.Replace("/api/embeddings", "/api/tags")
                Dim request = System.Net.WebRequest.Create(testUrl)
                request.Method = "GET"
                request.Timeout = 5000
                Using response = request.GetResponse()
                End Using
            Catch
                Return $"Ollama: Service non accessible sur {Config.Url}"
            End Try
        End If

        Return ""
    End Function

    ''' <summary>
    ''' Tester la connexion au provider
    ''' </summary>
    Public Async Function TestConnectionAsync() As Task(Of TestResult)
        Dim result As New TestResult() With {
            .Provider = Config.Provider,
            .Modele = Config.Modele
        }

        Dim validationError = ValidateConfig()
        If Not String.IsNullOrEmpty(validationError) Then
            result.Success = False
            result.Message = validationError
            Return result
        End If

        Dim sw = Diagnostics.Stopwatch.StartNew()
        Try
            Dim embedding = Await GetEmbeddingAsync("Test de connexion")
            sw.Stop()

            If embedding IsNot Nothing AndAlso embedding.Length > 0 Then
                result.Success = True
                result.Dimension = embedding.Length
                result.LatencyMs = sw.ElapsedMilliseconds
                result.Message = $"OK - Dimension: {embedding.Length}, Latence: {sw.ElapsedMilliseconds}ms"
            Else
                result.Success = False
                result.Message = "Aucun embedding retourné"
            End If
        Catch ex As Exception
            sw.Stop()
            result.Success = False
            result.Message = ex.Message
            result.LatencyMs = sw.ElapsedMilliseconds
        End Try

        Return result
    End Function

    Public Class TestResult
        Public Property Success As Boolean
        Public Property Provider As String
        Public Property Modele As String
        Public Property Message As String
        Public Property Dimension As Integer
        Public Property LatencyMs As Long

        Public Overrides Function ToString() As String
            Return If(Success, "✅", "❌") & $" {Provider} ({Modele}): {Message}"
        End Function
    End Class

#End Region

End Class