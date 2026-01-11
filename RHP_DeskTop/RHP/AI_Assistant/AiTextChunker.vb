Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO

Public Class AiTextChunker

#Region "Configuration"
    Public Class ChunkConfig
        Public Property ChunkSize As Integer = 800
        Public Property ChunkOverlap As Integer = 150
        Public Property MinChunkSize As Integer = 100
        Public Property Strategy As ChunkStrategy = ChunkStrategy.Recursive
        Public Property PreserveStructure As Boolean = True
        Public Property IncludeMetadata As Boolean = True
        Public Property Language As String = "fr"
    End Class

    Public Enum ChunkStrategy
        FixedSize           ' Taille fixe (basique)
        Recursive           ' Récursif avec séparateurs hiérarchiques
        Semantic            ' Par phrases et paragraphes
        Document            ' Par structure de document (titres, sections)
        Hybrid              ' Combinaison intelligente
    End Enum

#End Region

#Region "Chunk Result"

    ''' <summary>
    ''' Résultat d'un chunk avec métadonnées enrichies
    ''' </summary>
    Public Class ChunkResult
        Public Property Id As String
        Public Property Text As String
        Public Property Index As Integer
        Public Property StartPosition As Integer
        Public Property EndPosition As Integer
        Public Property TokenCount As Integer
        Public Property Metadata As ChunkMetadata

        Public Sub New()
            Metadata = New ChunkMetadata()
        End Sub
    End Class

    Public Class ChunkMetadata
        Public Property Source As String
        Public Property Section As String
        Public Property Title As String
        Public Property PageNumber As Integer
        Public Property HasCodeBlock As Boolean
        Public Property HasTable As Boolean
        Public Property HasList As Boolean
        Public Property PreviousChunkId As String
        Public Property NextChunkId As String
        Public Property Keywords As List(Of String)

        Public Sub New()
            Keywords = New List(Of String)
        End Sub
    End Class

#End Region

#Region "Séparateurs hiérarchiques"

    ' Séparateurs ordonnés du plus large au plus fin
    Private Shared ReadOnly RecursiveSeparators As String() = {
            vbCrLf & vbCrLf & vbCrLf,   ' Triple saut de ligne (sections majeures)
            vbCrLf & vbCrLf,             ' Double saut (paragraphes)
            vbCrLf,                       ' Simple saut de ligne
            ". ",                         ' Fin de phrase avec point
            "! ",                         ' Fin de phrase exclamative
            "? ",                         ' Fin de phrase interrogative
            "; ",                         ' Point-virgule
            ", ",                         ' Virgule
            " "                           ' Espace (dernier recours)
        }

    ' Patterns pour détecter la structure
    Private Shared ReadOnly TitlePatterns As String() = {
            "^#{1,6}\s+.+$",                           ' Markdown headers
            "^[IVXLCDM]+\.\s+.+$",                     ' Numérotation romaine
            "^\d+\.\s+.+$",                            ' Numérotation décimale
            "^\d+\.\d+\.?\s+.+$",                      ' Sous-sections
            "^[A-Z][A-Z\s]{2,}$",                      ' TITRES EN MAJUSCULES
            "^(Article|Section|Chapitre|Partie)\s+\d+" ' Titres juridiques FR
        }

#End Region

#Region "Méthode principale"

    ''' <summary>
    ''' Point d'entrée principal pour chunker un texte
    ''' </summary>
    Public Shared Function ChunkText(text As String, Optional config As ChunkConfig = Nothing) As List(Of ChunkResult)
        If config Is Nothing Then config = New ChunkConfig()

        If String.IsNullOrWhiteSpace(text) Then
            Return New List(Of ChunkResult)
        End If

        ' Pré-traitement
        text = PreprocessText(text)

        ' Sélection de la stratégie
        Dim chunks As List(Of ChunkResult)

        Select Case config.Strategy
            Case ChunkStrategy.FixedSize
                chunks = ChunkFixedSize(text, config)

            Case ChunkStrategy.Recursive
                chunks = ChunkRecursive(text, config)

            Case ChunkStrategy.Semantic
                chunks = ChunkSemantic(text, config)

            Case ChunkStrategy.Document
                chunks = ChunkByDocument(text, config)

            Case ChunkStrategy.Hybrid
                chunks = ChunkHybrid(text, config)

            Case Else
                chunks = ChunkRecursive(text, config)
        End Select

        ' Post-traitement : ajout des liens entre chunks
        LinkChunks(chunks)

        Return chunks
    End Function

#End Region

#Region "Stratégie 1 : Récursive (Recommandée)"

    ''' <summary>
    ''' Chunking récursif style LangChain - Divise hiérarchiquement
    ''' </summary>
    Private Shared Function ChunkRecursive(text As String, config As ChunkConfig) As List(Of ChunkResult)
        Dim results As New List(Of ChunkResult)
        Dim rawChunks = SplitRecursively(text, RecursiveSeparators, config.ChunkSize, config.ChunkOverlap)

        Dim index As Integer = 0
        Dim position As Integer = 0

        For Each chunk In rawChunks
            If chunk.Length >= config.MinChunkSize Then
                Dim result As New ChunkResult() With {
                        .Id = Guid.NewGuid().ToString("N").Substring(0, 12),
                        .Text = chunk.Trim(),
                        .Index = index,
                        .StartPosition = position,
                        .EndPosition = position + chunk.Length,
                        .TokenCount = EstimateTokens(chunk)
                    }

                ' Extraction des métadonnées
                If config.IncludeMetadata Then
                    result.Metadata = ExtractMetadata(chunk, text, position)
                End If

                results.Add(result)
                index += 1
            End If
            position += chunk.Length
        Next

        Return results
    End Function

    ''' <summary>
    ''' Division récursive avec séparateurs hiérarchiques
    ''' </summary>
    Private Shared Function SplitRecursively(text As String,
                                                  separators As String(),
                                                  chunkSize As Integer,
                                                  overlap As Integer) As List(Of String)
        Dim results As New List(Of String)

        ' Cas de base : texte assez petit
        If text.Length <= chunkSize Then
            results.Add(text)
            Return results
        End If

        ' Trouver le meilleur séparateur disponible dans le texte
        Dim bestSeparator As String = Nothing
        For Each sep In separators
            If text.Contains(sep) Then
                bestSeparator = sep
                Exit For
            End If
        Next

        ' Si aucun séparateur trouvé, couper au chunkSize
        If bestSeparator Is Nothing Then
            Return SplitWithOverlap(text, chunkSize, overlap)
        End If

        ' Diviser par le séparateur trouvé
        Dim parts = text.Split({bestSeparator}, StringSplitOptions.None)
        Dim currentChunk As New StringBuilder()

        For Each part In parts
            Dim potentialChunk = If(currentChunk.Length > 0,
                                        currentChunk.ToString() & bestSeparator & part,
                                        part)

            If potentialChunk.Length <= chunkSize Then
                If currentChunk.Length > 0 Then
                    currentChunk.Append(bestSeparator)
                End If
                currentChunk.Append(part)
            Else
                ' Sauvegarder le chunk actuel s'il existe
                If currentChunk.Length > 0 Then
                    results.Add(currentChunk.ToString())
                End If

                ' Si la partie est trop grande, récurser avec le prochain séparateur
                If part.Length > chunkSize Then
                    Dim nextSeparators = separators.Skip(Array.IndexOf(separators, bestSeparator) + 1).ToArray()
                    If nextSeparators.Length > 0 Then
                        results.AddRange(SplitRecursively(part, nextSeparators, chunkSize, overlap))
                    Else
                        results.AddRange(SplitWithOverlap(part, chunkSize, overlap))
                    End If
                    currentChunk.Clear()
                Else
                    currentChunk.Clear()
                    currentChunk.Append(part)
                End If
            End If
        Next

        ' Ajouter le dernier chunk
        If currentChunk.Length > 0 Then
            results.Add(currentChunk.ToString())
        End If

        ' Appliquer l'overlap
        Return ApplyOverlap(results, overlap)
    End Function

#End Region

#Region "Stratégie 2 : Sémantique"

    ''' <summary>
    ''' Chunking par unités sémantiques (phrases et paragraphes)
    ''' </summary>
    Private Shared Function ChunkSemantic(text As String, config As ChunkConfig) As List(Of ChunkResult)
        Dim results As New List(Of ChunkResult)
        Dim sentences = ExtractSentences(text)

        Dim currentChunk As New StringBuilder()
        Dim chunkStart As Integer = 0
        Dim index As Integer = 0
        Dim position As Integer = 0

        For Each sentence In sentences
            ' Si ajouter cette phrase dépasse la limite
            If currentChunk.Length + sentence.Length > config.ChunkSize AndAlso currentChunk.Length > 0 Then
                ' Créer le chunk
                Dim result As New ChunkResult() With {
                        .Id = Guid.NewGuid().ToString("N").Substring(0, 12),
                        .Text = currentChunk.ToString().Trim(),
                        .Index = index,
                        .StartPosition = chunkStart,
                        .EndPosition = position,
                        .TokenCount = EstimateTokens(currentChunk.ToString())
                    }

                If config.IncludeMetadata Then
                    result.Metadata = ExtractMetadata(currentChunk.ToString(), text, chunkStart)
                End If

                results.Add(result)
                index += 1

                ' Overlap : reprendre les dernières phrases
                Dim overlapText = GetOverlapFromEnd(currentChunk.ToString(), config.ChunkOverlap)
                currentChunk.Clear()
                currentChunk.Append(overlapText)
                chunkStart = position - overlapText.Length
            End If

            currentChunk.Append(sentence)
            If Not sentence.EndsWith(" ") Then currentChunk.Append(" ")
            position += sentence.Length + 1
        Next

        ' Dernier chunk
        If currentChunk.Length >= config.MinChunkSize Then
            Dim result As New ChunkResult() With {
                    .Id = Guid.NewGuid().ToString("N").Substring(0, 12),
                    .Text = currentChunk.ToString().Trim(),
                    .Index = index,
                    .StartPosition = chunkStart,
                    .EndPosition = position,
                    .TokenCount = EstimateTokens(currentChunk.ToString())
                }

            If config.IncludeMetadata Then
                result.Metadata = ExtractMetadata(currentChunk.ToString(), text, chunkStart)
            End If

            results.Add(result)
        End If

        Return results
    End Function

    ''' <summary>
    ''' Extraction intelligente des phrases
    ''' </summary>
    Private Shared Function ExtractSentences(text As String) As List(Of String)
        ' Pattern pour découper en phrases tout en gérant les abréviations courantes
        Dim abbreviations = "(M\.|Mme\.|Dr\.|Prof\.|etc\.|ex\.|cf\.|vol\.|p\.|pp\.)"

        ' Remplacer temporairement les abréviations
        Dim processed = Regex.Replace(text, abbreviations, Function(m) m.Value.Replace(".", "§"))

        ' Découper par phrases
        Dim pattern = "(?<=[.!?])\s+(?=[A-ZÀ-Ü])"
        Dim sentences = Regex.Split(processed, pattern).ToList()

        ' Restaurer les abréviations
        Return sentences.Select(Function(s) s.Replace("§", ".")).
                             Where(Function(s) Not String.IsNullOrWhiteSpace(s)).
                             ToList()
    End Function

#End Region

#Region "Stratégie 3 : Par Structure de Document"

    ''' <summary>
    ''' Chunking basé sur la structure du document (titres, sections)
    ''' </summary>
    Private Shared Function ChunkByDocument(text As String, config As ChunkConfig) As List(Of ChunkResult)
        Dim results As New List(Of ChunkResult)
        Dim sections = ExtractSections(text)

        Dim index As Integer = 0

        For Each section In sections
            ' Si la section est trop grande, la subdiviser
            If section.Content.Length > config.ChunkSize Then
                Dim subConfig As New ChunkConfig() With {
                        .ChunkSize = config.ChunkSize,
                        .ChunkOverlap = config.ChunkOverlap,
                        .MinChunkSize = config.MinChunkSize,
                        .Strategy = ChunkStrategy.Semantic
                    }

                Dim subChunks = ChunkSemantic(section.Content, subConfig)

                For Each subChunk In subChunks
                    ' Préfixer avec le contexte de la section
                    If Not String.IsNullOrEmpty(section.Title) Then
                        subChunk.Text = $"[Section: {section.Title}]{vbCrLf}{subChunk.Text}"
                        subChunk.Metadata.Section = section.Title
                        subChunk.Metadata.Title = section.Title
                    End If
                    subChunk.Index = index
                    index += 1
                    results.Add(subChunk)
                Next
            Else
                Dim result As New ChunkResult() With {
                        .Id = Guid.NewGuid().ToString("N").Substring(0, 12),
                        .Text = If(Not String.IsNullOrEmpty(section.Title),
                                  $"[Section: {section.Title}]{vbCrLf}{section.Content}",
                                  section.Content),
                        .Index = index,
                        .TokenCount = EstimateTokens(section.Content)
                    }

                result.Metadata.Section = section.Title
                result.Metadata.Title = section.Title

                results.Add(result)
                index += 1
            End If
        Next

        Return results
    End Function

    Private Class DocumentSection
        Public Property Title As String
        Public Property Content As String
        Public Property Level As Integer
    End Class

    ''' <summary>
    ''' Extraction des sections du document
    ''' </summary>
    Private Shared Function ExtractSections(text As String) As List(Of DocumentSection)
        Dim sections As New List(Of DocumentSection)
        Dim lines = text.Split({vbCrLf, vbLf}, StringSplitOptions.None)

        Dim currentSection As New DocumentSection() With {
                .Title = "",
                .Content = "",
                .Level = 0
            }
        Dim contentBuilder As New StringBuilder()

        For Each line In lines
            Dim isTitle = False
            Dim titleLevel = 0

            ' Vérifier si c'est un titre
            For Each pattern In TitlePatterns
                If Regex.IsMatch(line.Trim(), pattern, RegexOptions.Multiline) Then
                    isTitle = True
                    ' Déterminer le niveau
                    If line.StartsWith("#") Then
                        titleLevel = line.TakeWhile(Function(c) c = "#"c).Count()
                    Else
                        titleLevel = 1
                    End If
                    Exit For
                End If
            Next

            If isTitle Then
                ' Sauvegarder la section précédente
                If contentBuilder.Length > 0 OrElse Not String.IsNullOrEmpty(currentSection.Title) Then
                    currentSection.Content = contentBuilder.ToString().Trim()
                    If Not String.IsNullOrWhiteSpace(currentSection.Content) Then
                        sections.Add(currentSection)
                    End If
                End If

                ' Nouvelle section
                currentSection = New DocumentSection() With {
                        .Title = Regex.Replace(line.Trim(), "^#+\s*", ""),
                        .Level = titleLevel
                    }
                contentBuilder.Clear()
            Else
                contentBuilder.AppendLine(line)
            End If
        Next

        ' Dernière section
        currentSection.Content = contentBuilder.ToString().Trim()
        If Not String.IsNullOrWhiteSpace(currentSection.Content) OrElse
               Not String.IsNullOrEmpty(currentSection.Title) Then
            sections.Add(currentSection)
        End If

        Return sections
    End Function

#End Region

#Region "Stratégie 4 : Hybride"

    ''' <summary>
    ''' Stratégie hybride : combine structure + sémantique + récursif
    ''' </summary>
    Private Shared Function ChunkHybrid(text As String, config As ChunkConfig) As List(Of ChunkResult)
        ' Étape 1 : Identifier les blocs spéciaux (code, tables, listes)
        Dim specialBlocks = ExtractSpecialBlocks(text)

        ' Étape 2 : Chunker par structure si des titres sont détectés
        Dim hasStructure = TitlePatterns.Any(Function(p) Regex.IsMatch(text, p, RegexOptions.Multiline))

        If hasStructure Then
            Return ChunkByDocument(text, config)
        End If

        ' Étape 3 : Sinon, utiliser récursif avec gestion des blocs spéciaux
        Dim results As New List(Of ChunkResult)
        Dim processedText = text

        ' Traiter les blocs spéciaux séparément
        For Each block In specialBlocks
            If block.Value.Length > config.MinChunkSize Then
                Dim blockChunk As New ChunkResult() With {
                        .Id = Guid.NewGuid().ToString("N").Substring(0, 12),
                        .Text = block.Value,
                        .TokenCount = EstimateTokens(block.Value)
                    }

                Select Case block.Key
                    Case "code"
                        blockChunk.Metadata.HasCodeBlock = True
                    Case "table"
                        blockChunk.Metadata.HasTable = True
                    Case "list"
                        blockChunk.Metadata.HasList = True
                End Select

                results.Add(blockChunk)

                ' Remplacer par un placeholder
                processedText = processedText.Replace(block.Value, $"[{block.Key.ToUpper()}_BLOCK]")
            End If
        Next

        ' Chunker le reste
        Dim textChunks = ChunkRecursive(processedText, config)
        results.AddRange(textChunks)

        ' Réordonner par position
        Return results.OrderBy(Function(c) c.Index).ToList()
    End Function

    ''' <summary>
    ''' Extraction des blocs spéciaux (code, tables, listes)
    ''' </summary>
    Private Shared Function ExtractSpecialBlocks(text As String) As Dictionary(Of String, String)
        Dim blocks As New Dictionary(Of String, String)

        ' Blocs de code (``` ... ```)
        Dim codePattern = "```[\s\S]*?```"
        For Each match As Match In Regex.Matches(text, codePattern)
            blocks($"code_{blocks.Count}") = match.Value
        Next

        ' Tables Markdown
        Dim tablePattern = "(\|[^\n]+\|\n)(\|[-:| ]+\|\n)(\|[^\n]+\|\n)+"
        For Each match As Match In Regex.Matches(text, tablePattern)
            blocks($"table_{blocks.Count}") = match.Value
        Next

        ' Listes (numérotées ou à puces)
        Dim listPattern = "(^[\s]*[-*•]\s+.+$\n?)+"
        For Each match As Match In Regex.Matches(text, listPattern, RegexOptions.Multiline)
            If match.Value.Split(vbLf).Length > 3 Then ' Au moins 3 items
                blocks($"list_{blocks.Count}") = match.Value
            End If
        Next

        Return blocks
    End Function

#End Region

#Region "Stratégie 5 : Taille Fixe (Basique)"

    ''' <summary>
    ''' Chunking basique par taille fixe avec overlap
    ''' </summary>
    Private Shared Function ChunkFixedSize(text As String, config As ChunkConfig) As List(Of ChunkResult)
        Dim results As New List(Of ChunkResult)
        Dim chunks = SplitWithOverlap(text, config.ChunkSize, config.ChunkOverlap)

        Dim index As Integer = 0
        Dim position As Integer = 0

        For Each chunk In chunks
            If chunk.Length >= config.MinChunkSize Then
                results.Add(New ChunkResult() With {
                        .Id = Guid.NewGuid().ToString("N").Substring(0, 12),
                        .Text = chunk,
                        .Index = index,
                        .StartPosition = position,
                        .EndPosition = position + chunk.Length,
                        .TokenCount = EstimateTokens(chunk)
                    })
                index += 1
            End If
            position += config.ChunkSize - config.ChunkOverlap
        Next

        Return results
    End Function

#End Region

#Region "Utilitaires"

    ''' <summary>
    ''' Pré-traitement du texte
    ''' </summary>
    Private Shared Function PreprocessText(text As String) As String
        ' Normaliser les sauts de ligne
        text = text.Replace(vbCr & vbLf, vbLf).Replace(vbCr, vbLf).Replace(vbLf, vbCrLf)

        ' Supprimer les espaces multiples
        text = Regex.Replace(text, "[ \t]+", " ")

        ' Supprimer les lignes vides multiples (garder max 2)
        text = Regex.Replace(text, "(" & vbCrLf & "){3,}", vbCrLf & vbCrLf)

        ' Remplacer certains caractères spéciaux nuisibles
        text = text.Replace(Chr(0), "")

        Return text.Trim()
    End Function
    ''' <summary>
    ''' Division avec overlap aux frontières de mots OU de lignes
    ''' </summary>
    Private Shared Function SplitWithOverlap(text As String, chunkSize As Integer, overlap As Integer) As List(Of String)
        ' Validation : overlap ne peut pas dépasser 50% du chunk
        overlap = Math.Min(overlap, CInt(chunkSize * 0.5))

        Dim chunks As New List(Of String)
        Dim start As Integer = 0
        Dim minAdvance = chunkSize - overlap  ' Avancement minimum garanti

        While start < text.Length
            Dim remainingLength = text.Length - start

            ' Dernier morceau
            If remainingLength <= chunkSize Then
                Dim lastChunk = text.Substring(start).Trim()

                If lastChunk.Length < 50 AndAlso chunks.Count > 0 Then
                    ' Trop petit → fusionner avec précédent
                    chunks(chunks.Count - 1) &= " " & lastChunk
                ElseIf lastChunk.Length > 0 Then
                    chunks.Add(lastChunk)
                End If
                Exit While
            End If

            ' Chunk normal
            Dim chunk = text.Substring(start, chunkSize)
            Dim breakPoint = FindBestBreakPoint(chunk, chunkSize)

            If breakPoint > minAdvance Then
                ' Bon point de coupure trouvé
                chunk = chunk.Substring(0, breakPoint)
                chunks.Add(chunk.Trim())
                start += breakPoint - overlap
            Else
                ' Pas de bon point → couper au chunkSize, avancer de minAdvance
                chunks.Add(chunk.Trim())
                start += minAdvance
            End If
        End While

        Return chunks
    End Function

    ''' <summary>
    ''' Trouve le meilleur point de coupure (retour ligne > espace)
    ''' </summary>
    Private Shared Function FindBestBreakPoint(chunk As String, chunkSize As Integer) As Integer
        Dim minPosition = CInt(chunkSize * 0.7)

        ' Liste des séparateurs par ordre de préférence
        Dim separators = {
        (vbCrLf, 2),      ' Windows newline
        (vbLf, 1),        ' Unix newline  
        (vbCr, 1),        ' Old Mac newline
        (". ", 2),        ' Fin de phrase
        ("! ", 2),
        ("? ", 2),
        ("; ", 2),
        (" ", 1),         ' Espace simple
        (vbTab, 1)        ' Tabulation
    }

        For Each sep In separators
            Dim pos = chunk.LastIndexOf(sep.Item1)
            If pos > minPosition Then
                Return pos + sep.Item2
            End If
        Next

        Return -1
    End Function

    ''' <summary>
    ''' Appliquer l'overlap entre chunks
    ''' </summary>
    Private Shared Function ApplyOverlap(chunks As List(Of String), overlap As Integer) As List(Of String)
        If chunks.Count <= 1 OrElse overlap <= 0 Then Return chunks

        Dim result As New List(Of String)

        For i = 0 To chunks.Count - 1
            Dim chunk = chunks(i)

            ' Ajouter le contexte du chunk précédent
            If i > 0 Then
                Dim prevOverlap = GetOverlapFromEnd(chunks(i - 1), overlap)
                If Not chunk.StartsWith(prevOverlap) Then
                    chunk = prevOverlap & " " & chunk
                End If
            End If

            result.Add(chunk.Trim())
        Next

        Return result
    End Function

    ''' <summary>
    ''' Obtenir le texte d'overlap depuis la fin
    ''' </summary>
    Private Shared Function GetOverlapFromEnd(text As String, overlapSize As Integer) As String
        If text.Length <= overlapSize Then Return text

        Dim startIndex = text.Length - overlapSize
        ' Trouver le début d'une phrase ou d'un mot
        Dim sentenceStart = text.LastIndexOf(". ", startIndex)
        If sentenceStart > startIndex - 50 AndAlso sentenceStart > 0 Then
            Return text.Substring(sentenceStart + 2)
        End If

        Dim wordStart = text.IndexOf(" "c, startIndex)
        If wordStart > 0 Then
            Return text.Substring(wordStart + 1)
        End If

        Return text.Substring(startIndex)
    End Function

    ''' <summary>
    ''' Estimation du nombre de tokens (approximatif)
    ''' </summary>
    Private Shared Function EstimateTokens(text As String) As Integer
        ' Approximation : ~4 caractères par token en français
        Return CInt(Math.Ceiling(text.Length / 4.0))
    End Function

    ''' <summary>
    ''' Extraction des métadonnées d'un chunk
    ''' </summary>
    Private Shared Function ExtractMetadata(chunk As String, fullText As String, position As Integer) As ChunkMetadata
        Dim meta As New ChunkMetadata()

        ' Détecter les blocs de code
        meta.HasCodeBlock = Regex.IsMatch(chunk, "```|`[^`]+`")

        ' Détecter les tables
        meta.HasTable = Regex.IsMatch(chunk, "\|.+\|")

        ' Détecter les listes
        meta.HasList = Regex.IsMatch(chunk, "^\s*[-*•]\s+", RegexOptions.Multiline)

        ' Extraire les mots-clés (mots significatifs)
        meta.Keywords = ExtractKeywords(chunk, 5)

        ' Trouver le titre de section le plus proche
        meta.Section = FindNearestSectionTitle(fullText, position)

        Return meta
    End Function

    ''' <summary>
    ''' Extraction des mots-clés principaux
    ''' </summary>
    Private Shared Function ExtractKeywords(text As String, maxKeywords As Integer) As List(Of String)
        Dim stopWords = {"le", "la", "les", "un", "une", "des", "de", "du", "et", "ou", "à", "au", "aux",
                             "ce", "cette", "ces", "son", "sa", "ses", "leur", "leurs", "qui", "que", "quoi",
                             "dont", "où", "pour", "par", "sur", "dans", "avec", "sans", "est", "sont", "être",
                             "avoir", "fait", "faire", "peut", "doit", "the", "a", "an", "and", "or", "is", "are"}

        Dim words = Regex.Matches(text.ToLower(), "\b[a-zà-ÿ]{4,}\b") _
                             .Cast(Of Match)() _
                             .Select(Function(m) m.Value) _
                             .Where(Function(w) Not stopWords.Contains(w)) _
                             .GroupBy(Function(w) w) _
                             .OrderByDescending(Function(g) g.Count()) _
                             .Take(maxKeywords) _
                             .Select(Function(g) g.Key) _
                             .ToList()

        Return words
    End Function

    ''' <summary>
    ''' Trouver le titre de section le plus proche avant la position
    ''' </summary>
    Private Shared Function FindNearestSectionTitle(text As String, position As Integer) As String
        Dim textBefore = text.Substring(0, Math.Min(position, text.Length))
        Dim lines = textBefore.Split({vbCrLf, vbLf}, StringSplitOptions.None).Reverse()

        For Each line In lines
            For Each pattern In TitlePatterns
                If Regex.IsMatch(line.Trim(), pattern) Then
                    Return Regex.Replace(line.Trim(), "^#+\s*", "")
                End If
            Next
        Next

        Return ""
    End Function

    ''' <summary>
    ''' Lier les chunks entre eux (previous/next)
    ''' </summary>
    Private Shared Sub LinkChunks(chunks As List(Of ChunkResult))
        For i = 0 To chunks.Count - 1
            If i > 0 Then
                chunks(i).Metadata.PreviousChunkId = chunks(i - 1).Id
            End If
            If i < chunks.Count - 1 Then
                chunks(i).Metadata.NextChunkId = chunks(i + 1).Id
            End If
        Next
    End Sub

#End Region

#Region "API Simplifiée"

    ''' <summary>
    ''' Chunker un fichier directement
    ''' </summary>
    Public Shared Function ChunkFile(filePath As String, Optional config As ChunkConfig = Nothing) As List(Of ChunkResult)
        If Not File.Exists(filePath) Then
            Throw New FileNotFoundException("Fichier non trouvé", filePath)
        End If

        Dim text = File.ReadAllText(filePath, Encoding.UTF8)
        Dim results = ChunkText(text, config)

        ' Ajouter la source
        For Each chunk In results
            chunk.Metadata.Source = Path.GetFileName(filePath)
        Next

        Return results
    End Function

    ''' <summary>
    ''' Chunker avec paramètres par défaut optimisés pour RAG
    ''' </summary>
    Public Shared Function ChunkForRAG(text As String,
                                            Optional chunkSize As Integer = 800,
                                            Optional overlap As Integer = 150) As List(Of ChunkResult)
        Dim config As New ChunkConfig() With {
                .ChunkSize = chunkSize,
                .ChunkOverlap = overlap,
                .Strategy = ChunkStrategy.Hybrid,
                .PreserveStructure = True,
                .IncludeMetadata = True
            }

        Return ChunkText(text, config)
    End Function

    ''' <summary>
    ''' Export des chunks pour insertion en base
    ''' </summary>
    Public Shared Function ToDataTable(chunks As List(Of ChunkResult), source As String) As DataTable
        Dim dt As New DataTable("Chunks")
        dt.Columns.Add("Id", GetType(String))
        dt.Columns.Add("Source", GetType(String))
        dt.Columns.Add("ChunkIndex", GetType(Integer))
        dt.Columns.Add("TextChunk", GetType(String))
        dt.Columns.Add("TokenCount", GetType(Integer))
        dt.Columns.Add("Section", GetType(String))
        dt.Columns.Add("Keywords", GetType(String))
        dt.Columns.Add("HasCode", GetType(Boolean))
        dt.Columns.Add("HasTable", GetType(Boolean))

        For Each chunk In chunks
            dt.Rows.Add(
                    chunk.Id,
                    source,
                    chunk.Index,
                    chunk.Text,
                    chunk.TokenCount,
                    chunk.Metadata.Section,
                    String.Join(",", chunk.Metadata.Keywords),
                    chunk.Metadata.HasCodeBlock,
                    chunk.Metadata.HasTable
                )
        Next

        Return dt
    End Function

#End Region

End Class
