Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

''' <summary>Message de conversation avec un LLM (rôle : system / user / assistant).</summary>
Public Class AiChatMessage
    Public Property Role As String = "user"
    Public Property Content As String = ""
    Public Sub New()
    End Sub
    Public Sub New(role As String, content As String)
        Me.Role = role
        Me.Content = content
    End Sub
End Class

''' <summary>Modèle enregistré du catalogue LLM (table Ai_LLM_Modeles — alimentée par
''' l'écran AI_Modeles / Zoom_AddModele) : fournisseur, nom du modèle et gabarit
''' d'URL ({MODEL} substitué à l'envoi). Affiché 'PROVIDER / modèle' dans les listes.</summary>
Public Class Ai_ModeleEnregistre
    Public Property Provider As String = ""
    Public Property Modele As String = ""
    Public Property AiUrl As String = ""
    Public Overrides Function ToString() As String
        Return Provider & " / " & Modele
    End Function
End Class

''' <summary>Configuration LLM enregistrée (une ligne de la table Ai_Agent — écran
''' AI_Modeles, multi-modèles) : fournisseur, modèle, url, clé d'API, mémoire et
''' indicateur 'modèle par défaut' de sa portée (globale id_Societe=-1 ou société).</summary>
Public Class Ai_ConfigEnregistree
    Public Property Id As Integer = 0
    Public Property IdSociete As Integer = -1
    Public Property Provider As String = ""
    Public Property Modele As String = ""
    Public Property AiUrl As String = ""
    Public Property ApiKey As String = ""
    Public Property NbMsgMemory As Integer = 5
    Public Property ParDefaut As Boolean = False
    Public Overrides Function ToString() As String
        Return Provider & " / " & Modele
    End Function
End Class

''' <summary>
''' Client de conversation LLM de l'assistant IA de RHP (modèle par défaut de la
''' table Ai_Agent — écran AI_Modeles, multi-modèles). Miroir exact de
''' callAgentChat du backend portail (RHP_Portail\rhpBE\controlers\ai_assistant.ts) :
'''   - GEMINI       : contenus fusionnés par rôle (assistant->model, system->user),
'''                    clé d'API dans l'url (?key=...) ;
'''   - OLLAMA       : prompt unique concaténé (stream:false) ;
'''   - autres       : standard OpenAI (messages + Bearer ; AZUREOPENAI : en-tête api-key).
''' Partagé par les écrans qui discutent avec l'assistant (Zoom_SP_Assistant_IA...).
''' </summary>
Public Class Ai_ChatClient

    Public Property Provider As String = ""
    Public Property Modele As String = ""
    Public Property AiUrl As String = ""
    Public Property ApiKey As String = ""
    Public Property NbMsgMemory As Integer = 5

    ''' <summary>Charge la configuration de l'agent parmi les modèles enregistrés
    ''' (table Ai_Agent, multi-modèles — écran AI_Modeles) : le MODÈLE PAR DÉFAUT
    ''' (Par_Defaut='true') de la société courante prime sur le défaut global
    ''' (id_Societe=-1) ; à défaut, une configuration de la société prime sur la
    ''' globale. Retourne Nothing si l'assistant n'est pas configuré (provider/modèle/url).</summary>
    Public Shared Function ChargerConfig() As Ai_ChatClient
        Try
            Dim Tbl As DataTable = DATA_READER_GRD($"SELECT TOP 1 * FROM Ai_Agent
                                                    WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe}) = {Societe.id_Societe}
                                                    ORDER BY CASE WHEN ISNULL(Par_Defaut,'false')='true' THEN 0 ELSE 1 END,
                                                             CASE WHEN id_Societe = {Societe.id_Societe} THEN 0 ELSE 1 END")
            If Tbl.Rows.Count = 0 Then Return Nothing
            Dim Dr As DataRow = Tbl.Rows(0)
            Dim cfg As New Ai_ChatClient With {
                .Provider = IsNull(Dr("Provider"), "").Trim(),
                .Modele = IsNull(Dr("Modele"), "").Trim(),
                .AiUrl = IsNull(Dr("AiUrl"), "").Trim(),
                .ApiKey = IsNull(Dr("ApiKey"), "").Trim(),
                .NbMsgMemory = CInt(IsNull(Dr("Nb_Msg_Memory"), "5"))
            }
            If cfg.Provider = "" OrElse cfg.Modele = "" OrElse cfg.AiUrl = "" Then Return Nothing
            Return cfg
        Catch ex As Exception
            Debug.WriteLine("Erreur ChargerConfig (Ai_Agent) : " & ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>Liste des configurations enregistrées (table Ai_Agent, multi-modèles —
    ''' écran AI_Modeles) de la portée courante (société + globale), triées par priorité :
    ''' défaut de la société, défaut global, configurations de la société puis globales
    ''' (même ordre que ChargerConfig). Retourne une liste vide si rien n'est configuré.</summary>
    Public Shared Function ChargerConfigsEnregistrees() As List(Of Ai_ConfigEnregistree)
        Dim rsl As New List(Of Ai_ConfigEnregistree)
        Try
            Dim Tbl As DataTable = DATA_READER_GRD($"SELECT Id, id_Societe, Provider, Modele, aiUrl, ApiKey, nb_Msg_Memory, ISNULL(Par_Defaut,'false') AS Par_Defaut
                                                    FROM Ai_Agent
                                                    WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe}) = {Societe.id_Societe}
                                                    ORDER BY CASE WHEN ISNULL(Par_Defaut,'false')='true' THEN 0 ELSE 1 END,
                                                             CASE WHEN id_Societe = {Societe.id_Societe} THEN 0 ELSE 1 END,
                                                             Provider, Modele")
            For Each Dr As DataRow In Tbl.Rows
                rsl.Add(New Ai_ConfigEnregistree With {
                    .Id = CInt(IsNull(Dr("Id"), 0)),
                    .IdSociete = CInt(IsNull(Dr("id_Societe"), -1)),
                    .Provider = IsNull(Dr("Provider"), "").Trim(),
                    .Modele = IsNull(Dr("Modele"), "").Trim(),
                    .AiUrl = IsNull(Dr("aiUrl"), "").Trim(),
                    .ApiKey = IsNull(Dr("ApiKey"), "").Trim(),
                    .NbMsgMemory = CInt(IsNull(Dr("nb_Msg_Memory"), "5")),
                    .ParDefaut = (IsNull(Dr("Par_Defaut"), "false").ToString() = "true")
                })
            Next
        Catch ex As Exception
            Debug.WriteLine("Erreur ChargerConfigsEnregistrees (Ai_Agent) : " & ex.Message)
        End Try
        Return rsl
    End Function

    ''' <summary>Liste des modèles enregistrés du catalogue (table Ai_LLM_Modeles :
    ''' la colonne Modele est une liste de noms séparés par '|', l'URL est le gabarit
    ''' {MODEL} du fournisseur). Retourne une liste vide si le catalogue est absent.</summary>
    Public Shared Function ChargerModeles() As List(Of Ai_ModeleEnregistre)
        Dim rsl As New List(Of Ai_ModeleEnregistre)
        Try
            Dim Tbl As DataTable = DATA_READER_GRD("SELECT Provider, Modele, aiUrl FROM Ai_LLM_Modeles ORDER BY Provider, Modele")
            For Each Dr As DataRow In Tbl.Rows
                Dim provider As String = IsNull(Dr("Provider"), "").Trim()
                Dim url As String = IsNull(Dr("aiUrl"), "").Trim()
                For Each m As String In IsNull(Dr("Modele"), "").Split("|"c)
                    If m.Trim() <> "" Then
                        rsl.Add(New Ai_ModeleEnregistre With {.Provider = provider, .Modele = m.Trim(), .AiUrl = url})
                    End If
                Next
            Next
        Catch ex As Exception
            Debug.WriteLine("Erreur ChargerModeles (Ai_LLM_Modeles) : " & ex.Message)
        End Try
        Return rsl
    End Function

    ''' <summary>Envoie une conversation au LLM configuré et retourne le texte de la
    ''' réponse ("" si réponse vide). Lève une exception en cas d'erreur réseau / API,
    ''' enrichie du détail renvoyé par le fournisseur lorsqu'il est disponible.</summary>
    Public Async Function EnvoyerChatAsync(messages As List(Of AiChatMessage), Optional timeoutMs As Integer = 120000) As Task(Of String)
        Dim prov As String = Provider.ToUpperInvariant()
        Dim url As String = AiUrl.Replace("{MODEL}", Modele)
        Dim payload As JObject

        If prov = "GEMINI" Then
            ' Gemini ne connaît que 'user' et 'model' : system/assistant sont rabattus,
            ' et deux messages consécutifs de même rôle sont fusionnés.
            If Not url.Contains("key=") Then url &= "?key=" & ApiKey
            Dim contents As New JArray()
            For Each m As AiChatMessage In messages
                Dim role As String = If(m.Role = "assistant", "model", "user")
                Dim last As JObject = If(contents.Count > 0, TryCast(contents(contents.Count - 1), JObject), Nothing)
                If last IsNot Nothing AndAlso last("role").ToString() = role Then
                    last("parts")(0)("text") = last("parts")(0)("text").ToString() & vbCrLf & vbCrLf & m.Content
                Else
                    contents.Add(New JObject(New JProperty("role", role),
                                             New JProperty("parts", New JArray(New JObject(New JProperty("text", m.Content))))))
                End If
            Next
            payload = New JObject(New JProperty("contents", contents))
        ElseIf prov = "OLLAMA" Then
            Dim sb As New StringBuilder()
            For Each m As AiChatMessage In messages
                Dim qui As String = If(m.Role = "user", "User", If(m.Role = "system", "Instructions", "Assistant"))
                If sb.Length > 0 Then sb.Append(vbCrLf & vbCrLf)
                sb.Append(qui & ": " & m.Content)
            Next
            payload = New JObject(New JProperty("model", Modele),
                                  New JProperty("prompt", sb.ToString()),
                                  New JProperty("stream", False))
        Else
            ' Standard OpenAI (Mistral, Groq, Kimi, AzureOpenAI...)
            Dim arr As New JArray()
            For Each m As AiChatMessage In messages
                arr.Add(New JObject(New JProperty("role", m.Role), New JProperty("content", m.Content)))
            Next
            payload = New JObject(New JProperty("model", Modele), New JProperty("messages", arr))
        End If

        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Timeout = timeoutMs
        request.ReadWriteTimeout = timeoutMs
        If prov <> "GEMINI" AndAlso prov <> "OLLAMA" AndAlso ApiKey <> "" Then
            request.Headers.Add("Authorization", "Bearer " & ApiKey)
        End If
        If prov = "AZUREOPENAI" Then
            request.Headers.Add("api-key", ApiKey)
        End If

        Dim data As Byte() = Encoding.UTF8.GetBytes(payload.ToString(Formatting.None))
        request.ContentLength = data.Length
        Using stream = Await request.GetRequestStreamAsync()
            Await stream.WriteAsync(data, 0, data.Length)
        End Using

        Dim json As String = ""
        Try
            Using response = Await request.GetResponseAsync()
                Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                    json = Await reader.ReadToEndAsync()
                End Using
            End Using
        Catch wex As WebException
            Dim detail As String = ""
            If wex.Response IsNot Nothing Then
                Try
                    Using reader As New StreamReader(wex.Response.GetResponseStream(), Encoding.UTF8)
                        detail = reader.ReadToEnd()
                    End Using
                Catch
                End Try
            End If
            Throw New Exception("Appel du modèle IA en échec : " & wex.Message & If(detail <> "", vbCrLf & detail, ""))
        End Try

        Dim jobj As JObject = JObject.Parse(json)
        If prov = "GEMINI" Then
            Return IsNull(jobj.SelectToken("candidates[0].content.parts[0].text"), "")
        ElseIf prov = "OLLAMA" Then
            Return IsNull(jobj("response"), "")
        Else
            Return IsNull(jobj.SelectToken("choices[0].message.content"), "")
        End If
    End Function

    ''' <summary>Encode une image en JPEG base64 (qualité 85, dimension max 2000 px —
    ''' mêmes réglages que Scan_Piece_Identite.py : le LLM lit mieux les images agrandies
    ''' que les images trop petites, et au-delà de 2000 px le gain est nul).</summary>
    Private Shared Function EncoderImageJpegBase64(img As Image, Optional maxDim As Integer = 2000) As String
        Dim bmp As New Bitmap(img)
        Try
            Dim w As Integer = bmp.Width, h As Integer = bmp.Height
            Dim maxWH As Integer = Math.Max(w, h)
            Dim ratio As Double = 1.0
            If maxWH < 1400 Then
                ratio = 1400.0 / maxWH
            ElseIf maxWH > maxDim Then
                ratio = maxDim / maxWH
            End If
            If Math.Abs(ratio - 1.0) > 0.01 Then
                Dim resized As New Bitmap(CInt(w * ratio), CInt(h * ratio))
                Using g As Graphics = Graphics.FromImage(resized)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(bmp, 0, 0, resized.Width, resized.Height)
                End Using
                bmp.Dispose()
                bmp = resized
            End If
            Using ms As New MemoryStream()
                Dim codec As ImageCodecInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(Function(c) c.FormatID = ImageFormat.Jpeg.Guid)
                If codec IsNot Nothing Then
                    Using prms As New Imaging.EncoderParameters(1)
                        prms.Param(0) = New Imaging.EncoderParameter(Imaging.Encoder.Quality, 85L)
                        bmp.Save(ms, codec, prms)
                    End Using
                Else
                    bmp.Save(ms, ImageFormat.Jpeg)
                End If
                Return Convert.ToBase64String(ms.ToArray())
            End Using
        Finally
            bmp.Dispose()
        End Try
    End Function

    ''' <summary>Envoie un prompt accompagné d'images au LLM configuré (modèle MULTIMODAL
    ''' requis) et retourne le texte de la réponse ("" si vide). Miroir des appels vision de
    ''' Scan_Piece_Identite.py :
    '''   - GEMINI       : parts texte + inline_data (clé d'API dans l'url) ;
    '''   - ANTHROPIC    : content images base64 + texte (en-têtes x-api-key) ;
    '''   - OLLAMA       : message unique avec tableau 'images' (stream:false) ;
    '''   - autres       : standard OpenAI (content texte + image_url data: ; AZUREOPENAI :
    '''                    en-tête api-key).
    ''' Utilisé par l'import de CV (CVTheque) pour la lecture OCR des scans et l'extraction
    ''' de la photo d'identité. Lève une exception en cas d'erreur réseau / API.</summary>
    Public Async Function EnvoyerVisionAsync(prompt As String, images As List(Of Image), Optional timeoutMs As Integer = 120000) As Task(Of String)
        If images Is Nothing OrElse images.Count = 0 Then
            Return Await EnvoyerChatAsync(New List(Of AiChatMessage) From {New AiChatMessage("user", prompt)}, timeoutMs)
        End If
        Dim prov As String = Provider.ToUpperInvariant()
        Dim url As String = AiUrl.Replace("{MODEL}", Modele)
        Dim b64Images As List(Of String) = images.Select(Function(img) EncoderImageJpegBase64(img)).ToList()
        Dim payload As JObject

        If prov = "GEMINI" Then
            If Not url.Contains("key=") Then url &= "?key=" & ApiKey
            Dim parts As New JArray(New JObject(New JProperty("text", prompt)))
            For Each b64 As String In b64Images
                parts.Add(New JObject(New JProperty("inline_data",
                    New JObject(New JProperty("mime_type", "image/jpeg"), New JProperty("data", b64)))))
            Next
            payload = New JObject(New JProperty("contents", New JArray(New JObject(New JProperty("parts", parts)))))
        ElseIf prov = "ANTHROPIC" Then
            Dim content As New JArray()
            For Each b64 As String In b64Images
                content.Add(New JObject(New JProperty("type", "image"),
                    New JProperty("source", New JObject(New JProperty("type", "base64"),
                                                        New JProperty("media_type", "image/jpeg"),
                                                        New JProperty("data", b64)))))
            Next
            content.Add(New JObject(New JProperty("type", "text"), New JProperty("text", prompt)))
            payload = New JObject(New JProperty("model", Modele),
                                  New JProperty("max_tokens", 4096),
                                  New JProperty("messages", New JArray(New JObject(New JProperty("role", "user"),
                                                                                   New JProperty("content", content)))))
        ElseIf prov = "OLLAMA" Then
            payload = New JObject(New JProperty("model", Modele),
                                  New JProperty("stream", False),
                                  New JProperty("messages", New JArray(
                                      New JObject(New JProperty("role", "user"),
                                                  New JProperty("content", prompt),
                                                  New JProperty("images", New JArray(b64Images.Cast(Of Object)()))))))
        Else
            ' Standard OpenAI (Mistral, Groq, Kimi, AzureOpenAI...)
            Dim content As New JArray(New JObject(New JProperty("type", "text"), New JProperty("text", prompt)))
            For Each b64 As String In b64Images
                content.Add(New JObject(New JProperty("type", "image_url"),
                    New JProperty("image_url", New JObject(New JProperty("url", "data:image/jpeg;base64," & b64)))))
            Next
            payload = New JObject(New JProperty("model", Modele),
                                  New JProperty("messages", New JArray(New JObject(New JProperty("role", "user"),
                                                                                   New JProperty("content", content)))),
                                  New JProperty("temperature", 0))
        End If

        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Timeout = timeoutMs
        request.ReadWriteTimeout = timeoutMs
        If prov = "AZUREOPENAI" Then
            request.Headers.Add("api-key", ApiKey)
        ElseIf prov = "ANTHROPIC" Then
            request.Headers.Add("x-api-key", ApiKey)
            request.Headers.Add("anthropic-version", "2023-06-01")
        ElseIf prov <> "GEMINI" AndAlso prov <> "OLLAMA" AndAlso ApiKey <> "" Then
            request.Headers.Add("Authorization", "Bearer " & ApiKey)
        End If

        Dim data As Byte() = Encoding.UTF8.GetBytes(payload.ToString(Formatting.None))
        request.ContentLength = data.Length
        Using stream = Await request.GetRequestStreamAsync()
            Await stream.WriteAsync(data, 0, data.Length)
        End Using

        Dim json As String = ""
        Try
            Using response = Await request.GetResponseAsync()
                Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                    json = Await reader.ReadToEndAsync()
                End Using
            End Using
        Catch wex As WebException
            Dim detail As String = ""
            If wex.Response IsNot Nothing Then
                Try
                    Using reader As New StreamReader(wex.Response.GetResponseStream(), Encoding.UTF8)
                        detail = reader.ReadToEnd()
                    End Using
                Catch
                End Try
            End If
            Throw New Exception("Appel du modèle IA (vision) en échec : " & wex.Message & If(detail <> "", vbCrLf & detail, ""))
        End Try

        Dim jobj As JObject = JObject.Parse(json)
        If prov = "GEMINI" Then
            Return IsNull(jobj.SelectToken("candidates[0].content.parts[0].text"), "")
        ElseIf prov = "ANTHROPIC" Then
            Return IsNull(jobj.SelectToken("content[0].text"), "")
        ElseIf prov = "OLLAMA" Then
            Return IsNull(jobj.SelectToken("message.content"), "")
        Else
            Return IsNull(jobj.SelectToken("choices[0].message.content"), "")
        End If
    End Function

End Class
