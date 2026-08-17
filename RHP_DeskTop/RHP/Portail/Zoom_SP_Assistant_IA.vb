Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

''' <summary>
''' Assistant IA du Designer de pages portail (bouton 'Assistant IA' de
''' SP_Page_Designer). Zone de conversation avec le bot, à DEUX FONCTIONNALITÉS
''' EXCLUSIVES (boutons radio) :
'''   1. Aide — le bot lit le guide intégré (rsc\aide\Aide_SP_Page_Designer.html,
'''      découpé en sections, extraits les plus pertinents envoyés au LLM) et
'''      répond aux questions sur la création de pages (formules, paramètres,
'''      sources métier...). Hors sujet => réponse déclinée sans appel au LLM.
'''   2. Génération — le bot charge le skill rhp-portal-page-deployer
'''      (rsc\rhp-portal-page-deployer.zip, déployé avec l'application) et, à
'''      partir de la description fonctionnelle de l'utilisateur, génère le
'''      fichier .json d'import (format RHP_PAGE_DESIGNER 1.0) SUR LE POSTE DE
'''      L'UTILISATEUR (jamais sur le serveur) : le lien de téléchargement sous
'''      la zone de chat permet de l'enregistrer où l'on veut, puis de le
'''      charger via le bouton 'Importer JSON' du Designer.
''' Le JSON généré est systématiquement validé par l'importeur du produit
''' (SP_Page_Json_Import.Analyser — mêmes contrôles bloquants que l'import) ;
''' en cas d'erreur, une tentative de correction est demandée au modèle.
''' Si le modèle refuse pour dépassement de sa fenêtre de contexte, la conversation
''' est reconstruite en mode réduit (historique supprimé, environnement et références
''' tronquées) SANS perdre la progression de la boucle, jusqu'à 2 niveaux de réduction.
''' Aucune écriture en base : l'enregistrement reste l'action de l'utilisateur
''' dans le Designer ('Enregistrer' puis 'Publier').
''' Le LLM est le modèle par défaut de l'assistant IA de RHP (table Ai_Agent,
''' multi-modèles — Ai_ChatClient, miroir de callAgentChat du backend portail) ;
''' l'utilisateur peut basculer à tout moment sur un autre modèle enregistré du
''' catalogue (table Ai_LLM_Modeles — liste déroulante 'Modèle' en haut ; clé d'API
''' et mémoire de la configuration par défaut conservées, choix valable pour la session).
''' Interface : Zoom_SP_Assistant_IA.Designer.vb (convention permanente : tout
''' le code de design est dans le .Designer.vb ; ce fichier ne contient que la
''' logique — conversation, recherche dans l'aide, génération via le skill).
''' </summary>
Public Class Zoom_SP_Assistant_IA

    '---------------- État ----------------
    Private _config As Ai_ChatClient
    Private ReadOnly _historique As New List(Of AiChatMessage)
    Private _envoiEnCours As Boolean = False
    Private _statutConfig As String = ""

    ''' <summary>Section du guide d'aide (titre + texte brut) utilisée pour la recherche.</summary>
    Private Class SectionAide
        Public Titre As String = ""
        Public Texte As String = ""
        Public TexteNormalise As String = ""
        Public TitreNormalise As String = ""
    End Class
    Private ReadOnly _sectionsAide As New List(Of SectionAide)

    ''' <summary>Contenu du skill (chemin dans le zip -> contenu texte), chargé en mémoire.</summary>
    Private ReadOnly _skill As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

    ''' <summary>Dernier fichier JSON généré sur le poste (zone de téléchargement).</summary>
    Private _fichierGenere As String = ""

    ''' <summary>Niveau de réduction du contexte de génération après une erreur de
    ''' limite de tokens du modèle (0 = complet, 1 = réduit, 2 = minimal).</summary>
    Private _niveauReduction As Integer = 0

    Private Shared ReadOnly MOTS_VIDES As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "le", "la", "les", "de", "des", "du", "un", "une", "et", "ou", "a", "au", "aux", "en",
        "dans", "sur", "sous", "pour", "par", "avec", "sans", "vers", "chez", "est", "sont",
        "etre", "avoir", "fait", "faire", "je", "tu", "il", "elle", "on", "nous", "vous", "ils",
        "elles", "mon", "ma", "mes", "ton", "ta", "tes", "son", "sa", "ses", "leur", "leurs",
        "ce", "cet", "cette", "ces", "qui", "que", "quoi", "dont", "quand", "comment",
        "pourquoi", "quel", "quelle", "quels", "quelles", "plus", "moins", "tres", "se", "ne",
        "pas", "d", "j", "l", "n", "s", "t", "c", "m", "y", "ca", "etc", "peut", "peux", "veux",
        "voudrais", "souhaite", "creer", "cree", "creer", "fais", "moi", "stp", "svp"}

    Public Sub New()
        InitializeComponent()
    End Sub

    '---------------- Chargement ----------------

    Private Sub Zoom_SP_Assistant_IA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _config = Ai_ChatClient.ChargerConfig()
        ChargerAide()
        ChargerSkill()
        If _config Is Nothing Then
            _statutConfig = "IA non configurée"
            txtMessage.Enabled = False
            Envoyer_pb.Enabled = False
        Else
            _statutConfig = _config.Provider & " / " & _config.Modele
        End If
        lblStatut.Text = _statutConfig
        ChargerModeles()
        '---------------- Message d'accueil ----------------
        Dim accueil As New StringBuilder()
        accueil.Append("Bonjour ! Je suis l'assistant du Designer de pages portail, avec deux fonctions exclusives (choisissez en haut) :" & vbCrLf)
        accueil.Append("  • Aide — posez vos questions sur la création de pages : formules, paramètres, sources métier, validations, grilles virtuelles…" & vbCrLf)
        accueil.Append("  • Génération — décrivez la page voulue ; je produis le fichier JSON d'import sur VOTRE poste (lien de téléchargement)," & vbCrLf)
        accueil.Append("    à charger ensuite via le bouton 'Importer JSON' du Designer.")
        If _config Is Nothing Then
            accueil.Append(vbCrLf & vbCrLf & "⚠ L'assistant IA n'est pas configuré (table Ai_Agent) : ouvrez l'écran 'AI_Modeles' pour renseigner le fournisseur, le modèle et la clé d'API.")
        End If
        If _sectionsAide.Count = 0 Then
            accueil.Append(vbCrLf & "⚠ Fichier d'aide introuvable (rsc\aide\Aide_SP_Page_Designer.html) : le mode Aide est indisponible.")
        End If
        If _skill.Count = 0 Then
            accueil.Append(vbCrLf & "⚠ Skill de génération introuvable (rsc\rhp-portal-page-deployer.zip) : le mode Génération est indisponible.")
        End If
        AjouterMessageBot(accueil.ToString())
        txtMessage.Focus()
    End Sub

    ''' <summary>Charge le guide HTML intégré et le découpe en sections (titres h2 ;
    ''' les longues sections sont re-découpées en morceaux d'environ 4000 caractères).</summary>
    Private Sub ChargerAide()
        Try
            Dim chemin As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "rsc", "aide", "Aide_SP_Page_Designer.html")
            If Not File.Exists(chemin) Then Return
            Dim html As String = File.ReadAllText(chemin, Encoding.UTF8)
            Dim matches = Regex.Matches(html, "<h2[^>]*>(.*?)</h2>", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
            If matches.Count = 0 Then
                AjouterSectionAide("Aide du Designer de pages", NettoyerHtml(html))
                Return
            End If
            ' Avant le premier h2 : introduction (titre h1 + présentation)
            If matches(0).Index > 0 Then
                AjouterSectionAide("Introduction", NettoyerHtml(html.Substring(0, matches(0).Index)))
            End If
            For i As Integer = 0 To matches.Count - 1
                Dim debut As Integer = matches(i).Index + matches(i).Length
                Dim fin As Integer = If(i < matches.Count - 1, matches(i + 1).Index, html.Length)
                AjouterSectionAide(NettoyerHtml(matches(i).Groups(1).Value), NettoyerHtml(html.Substring(debut, fin - debut)))
            Next
        Catch ex As Exception
            Debug.WriteLine("Erreur ChargerAide : " & ex.Message)
        End Try
    End Sub

    ''' <summary>Ajoute une section d'aide (découpée en morceaux si trop longue).</summary>
    Private Sub AjouterSectionAide(titre As String, texte As String)
        titre = titre.Trim()
        texte = Regex.Replace(texte, "[ \t]+", " ").Trim()
        If texte = "" Then Return
        Const TAILLE_MAX As Integer = 4000
        If texte.Length <= TAILLE_MAX Then
            Dim s As New SectionAide With {.Titre = titre, .Texte = texte}
            s.TexteNormalise = Normaliser(texte)
            s.TitreNormalise = Normaliser(titre)
            _sectionsAide.Add(s)
            Return
        End If
        ' Découpe sur les sauts de ligne, en paquets d'environ TAILLE_MAX caractères
        Dim lignes As String() = texte.Split({vbLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim sb As New StringBuilder()
        Dim partie As Integer = 1
        For Each lig As String In lignes
            If sb.Length + lig.Length > TAILLE_MAX AndAlso sb.Length > 0 Then
                Dim s As New SectionAide With {.Titre = titre & " (" & partie & ")", .Texte = sb.ToString()}
                s.TexteNormalise = Normaliser(s.Texte)
                s.TitreNormalise = Normaliser(s.Titre)
                _sectionsAide.Add(s)
                sb.Clear()
                partie += 1
            End If
            sb.AppendLine(lig)
        Next
        If sb.Length > 0 Then
            Dim s As New SectionAide With {.Titre = titre & " (" & partie & ")", .Texte = sb.ToString()}
            s.TexteNormalise = Normaliser(s.Texte)
            s.TitreNormalise = Normaliser(s.Titre)
            _sectionsAide.Add(s)
        End If
    End Sub

    ''' <summary>HTML -> texte brut lisible (blocs = sauts de ligne, entités décodées).</summary>
    Private Shared Function NettoyerHtml(html As String) As String
        Dim t As String = Regex.Replace(html, "<script[^>]*>[\s\S]*?</script>", " ", RegexOptions.IgnoreCase)
        t = Regex.Replace(t, "<style[^>]*>[\s\S]*?</style>", " ", RegexOptions.IgnoreCase)
        t = Regex.Replace(t, "</(p|li|h1|h2|h3|h4|tr|table|ul|ol|div|section)>", vbLf, RegexOptions.IgnoreCase)
        t = Regex.Replace(t, "<br[^>]*>", vbLf, RegexOptions.IgnoreCase)
        t = Regex.Replace(t, "<li[^>]*>", "• ", RegexOptions.IgnoreCase)
        t = Regex.Replace(t, "<[^>]+>", " ")
        t = Net.WebUtility.HtmlDecode(t)
        t = Regex.Replace(t, "[ \t]+", " ")
        t = Regex.Replace(t, " ?\r?\n ?", vbLf)
        t = Regex.Replace(t, "(" & vbLf & "){3,}", vbLf & vbLf)
        Return t.Trim()
    End Function

    ''' <summary>Charge le contenu texte du skill (zip) en mémoire : SKILL.md,
    ''' références, gabarits et exemples — servi au LLM à la demande (###FICHIER###).</summary>
    Private Sub ChargerSkill()
        Try
            Dim chemin As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "rsc", "rhp-portal-page-deployer.zip")
            If Not File.Exists(chemin) Then Return
            Using archive As New ZipArchive(File.OpenRead(chemin), ZipArchiveMode.Read)
                For Each entree As ZipArchiveEntry In archive.Entries
                    If entree.Length = 0 Then Continue For
                    Dim ext As String = IO.Path.GetExtension(entree.FullName).ToLowerInvariant()
                    If ext <> ".md" AndAlso ext <> ".json" AndAlso ext <> ".yaml" AndAlso ext <> ".yml" Then Continue For
                    Using reader As New StreamReader(entree.Open(), Encoding.UTF8)
                        _skill(entree.FullName) = reader.ReadToEnd()
                    End Using
                Next
            End Using
        Catch ex As Exception
            Debug.WriteLine("Erreur ChargerSkill : " & ex.Message)
        End Try
    End Sub

    '---------------- Choix du modèle (catalogue Ai_LLM_Modeles) ----------------

    ''' <summary>True pendant l'alimentation de la liste des modèles (empêche
    ''' cboModele_SelectedIndexChanged de basculer le modèle sur la présélection).</summary>
    Private _chargementModeles As Boolean = False

    ''' <summary>Alimente la liste des modèles enregistrés (catalogue Ai_LLM_Modeles,
    ''' écran AI_Modeles) et présélectionne le modèle par défaut (Ai_Agent —
    ''' ChargerConfig) — ajouté en tête de liste s'il ne figure pas au catalogue.</summary>
    Private Sub ChargerModeles()
        _chargementModeles = True
        Try
            cboModele.Items.Clear()
            cboModele.Enabled = False
            If _config Is Nothing Then Return
            Dim modeles As List(Of Ai_ModeleEnregistre) = Ai_ChatClient.ChargerModeles()
            Dim idx As Integer = modeles.FindIndex(
                Function(m) String.Equals(m.Provider, _config.Provider, StringComparison.OrdinalIgnoreCase) AndAlso
                            String.Equals(m.Modele, _config.Modele, StringComparison.OrdinalIgnoreCase))
            If idx < 0 Then
                modeles.Insert(0, New Ai_ModeleEnregistre With {.Provider = _config.Provider, .Modele = _config.Modele, .AiUrl = _config.AiUrl})
                idx = 0
            End If
            For Each m As Ai_ModeleEnregistre In modeles
                cboModele.Items.Add(m)
            Next
            cboModele.SelectedIndex = idx
            cboModele.Enabled = True
        Finally
            _chargementModeles = False
        End Try
    End Sub

    ''' <summary>Changement de modèle : l'assistant utilise désormais le modèle choisi
    ''' (fournisseur et gabarit d'URL du catalogue ; clé d'API et mémoire de la
    ''' configuration par défaut Ai_Agent conservées). Choix valable pour cette conversation.</summary>
    Private Sub cboModele_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModele.SelectedIndexChanged
        If _chargementModeles OrElse _config Is Nothing Then Return
        Dim m As Ai_ModeleEnregistre = TryCast(cboModele.SelectedItem, Ai_ModeleEnregistre)
        If m Is Nothing Then Return
        _config.Provider = m.Provider
        _config.Modele = m.Modele
        _config.AiUrl = m.AiUrl   ' gabarit {MODEL} : substitué à l'envoi (EnvoyerChatAsync)
        _statutConfig = _config.Provider & " / " & _config.Modele
        lblStatut.Text = _statutConfig
    End Sub

    '---------------- Affichage de la conversation ----------------

    Private Sub AjouterTexte(texte As String, police As Font, couleur As Color)
        txtChat.SelectionStart = txtChat.TextLength
        txtChat.SelectionFont = police
        txtChat.SelectionColor = couleur
        txtChat.AppendText(texte)
    End Sub

    Private Sub AjouterMessage(qui As String, texte As String, couleurQui As Color)
        AjouterTexte(qui & " — ", New Font("Century Gothic", 8.25!, FontStyle.Bold), couleurQui)
        AjouterTexte(texte.Trim() & vbCrLf & vbCrLf, New Font("Century Gothic", 8.25!, FontStyle.Regular), Color.FromArgb(40, 40, 40))
        txtChat.SelectionStart = txtChat.TextLength
        txtChat.ScrollToCaret()
    End Sub

    Private Sub AjouterMessageUtilisateur(texte As String)
        AjouterMessage("Vous", texte, Color.FromArgb(86, 86, 86))
    End Sub

    Private Sub AjouterMessageBot(texte As String)
        SupprimerReflexion()
        AjouterMessage("Assistant", texte, colorBase01)
    End Sub

    '---------------- Indicateur de réflexion ----------------
    ' Message provisoire animé affiché dans le chat pendant l'appel au modèle
    ' (« Assistant — réflexion en cours… ») ; retiré dès l'affichage de la vraie
    ' réponse (SupprimerReflexion, appelée par AjouterMessageBot).
    Private _reflexionDebut As Integer = -1
    Private _reflexionTimer As System.Windows.Forms.Timer
    Private _reflexionTicks As Integer = 0
    Private _reflexionPhase As String = ""
    Private ReadOnly _policeReflexionTitre As New Font("Century Gothic", 8.25!, FontStyle.Bold)
    Private ReadOnly _policeReflexion As New Font("Century Gothic", 8.25!, FontStyle.Italic)

    ''' <summary>Affiche dans le chat que l'assistant réfléchit (points animés par timer).</summary>
    Private Sub AfficherReflexion()
        SupprimerReflexion()
        _reflexionDebut = txtChat.TextLength
        _reflexionPhase = ""
        _reflexionTicks = 0
        lblStatut.Text = "L'assistant écrit…"
        RendreReflexion()
        _reflexionTimer = New System.Windows.Forms.Timer() With {.Interval = 500}
        AddHandler _reflexionTimer.Tick, AddressOf ReflexionTimer_Tick
        _reflexionTimer.Start()
    End Sub

    Private Sub ReflexionTimer_Tick(sender As Object, e As EventArgs)
        _reflexionTicks += 1
        RendreReflexion()
    End Sub

    ''' <summary>Supprime la fin du chat à partir d'une position (le RichTextBox étant
    ''' ReadOnly, la suppression exige une bascule temporaire de ReadOnly).</summary>
    Private Sub SupprimerFinChat(debut As Integer)
        If debut < 0 OrElse txtChat.IsDisposed Then Return
        txtChat.ReadOnly = False
        txtChat.Select(debut, txtChat.TextLength - debut)
        txtChat.SelectedText = ""
        txtChat.ReadOnly = True
    End Sub

    ''' <summary>(Ré)écrit le message provisoire de réflexion à la fin du chat.</summary>
    Private Sub RendreReflexion()
        If _reflexionDebut < 0 OrElse txtChat.IsDisposed Then Return
        SupprimerFinChat(_reflexionDebut)
        AjouterTexte("Assistant", _policeReflexionTitre, colorBase01)
        AjouterTexte(" — réflexion en cours" & If(_reflexionPhase = "", "", " (" & _reflexionPhase & ")") & " " &
                     New String("."c, _reflexionTicks Mod 4), _policeReflexion, Color.FromArgb(120, 120, 120))
        txtChat.SelectionStart = txtChat.TextLength
        txtChat.ScrollToCaret()
    End Sub

    ''' <summary>Met à jour la phase en cours (lecture des références, correction du
    ''' JSON…), dans le message de réflexion comme dans le libellé de statut.</summary>
    Private Sub AfficherPhaseReflexion(phase As String)
        lblStatut.Text = "L'assistant écrit…" & If(phase = "", "", " (" & phase & ")")
        _reflexionPhase = phase
        RendreReflexion()
    End Sub

    ''' <summary>Retire le message provisoire de réflexion et arrête son animation.</summary>
    Private Sub SupprimerReflexion()
        If _reflexionTimer IsNot Nothing Then
            RemoveHandler _reflexionTimer.Tick, AddressOf ReflexionTimer_Tick
            _reflexionTimer.Stop()
            _reflexionTimer.Dispose()
            _reflexionTimer = Nothing
        End If
        SupprimerFinChat(_reflexionDebut)
        _reflexionDebut = -1
    End Sub

    '---------------- Envoi d'un message ----------------

    Private Async Sub Envoyer()
        If _envoiEnCours Then Return
        Dim q As String = txtMessage.Text.Trim()
        If q = "" Then Return
        If _config Is Nothing Then
            ShowMessageBox("L'assistant IA n'est pas configuré (table Ai_Agent)." & vbCrLf &
                           "Ouvrez l'écran 'AI_Modeles' pour renseigner le fournisseur, le modèle et la clé d'API.",
                           "Assistant IA", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        _envoiEnCours = True
        txtMessage.Enabled = False
        Envoyer_pb.Enabled = False
        AjouterMessageUtilisateur(q)
        txtMessage.Clear()
        AfficherReflexion()
        Try
            If rdoGeneration.Checked Then
                Await GenererPage(q)
            Else
                Await RepondreAide(q)
            End If
        Catch ex As Exception
            AjouterMessageBot("Erreur : " & ex.Message)
        Finally
            SupprimerReflexion()
            _envoiEnCours = False
            txtMessage.Enabled = True
            Envoyer_pb.Enabled = True
            lblStatut.Text = _statutConfig
            txtMessage.Focus()
        End Try
    End Sub

    '---------------- Mode 1 : questions sur l'aide ----------------

    ''' <summary>Minuscules sans accents (comparaison de mots-clés).</summary>
    Private Shared Function Normaliser(s As String) As String
        Dim sb As New StringBuilder()
        For Each ch As Char In s.Normalize(NormalizationForm.FormD)
            If Globalization.CharUnicodeInfo.GetUnicodeCategory(ch) <> Globalization.UnicodeCategory.NonSpacingMark Then
                sb.Append(Char.ToLowerInvariant(ch))
            End If
        Next
        Return sb.ToString()
    End Function

    ''' <summary>Mots significatifs de la question (normalisés, hors mots vides).</summary>
    Private Shared Function MotsCles(texte As String) As List(Of String)
        Dim rsl As New List(Of String)
        For Each m As Match In Regex.Matches(Normaliser(texte), "[a-z0-9_]+")
            Dim mot As String = m.Value
            If mot.Length > 1 AndAlso Not MOTS_VIDES.Contains(mot) AndAlso Not rsl.Contains(mot) Then rsl.Add(mot)
        Next
        Return rsl
    End Function

    ''' <summary>Sections de l'aide les plus pertinentes pour la question
    ''' (score = mots-clés trouvés, titre comptant double).</summary>
    Private Function RechercherAide(question As String, nbMax As Integer) As List(Of SectionAide)
        Dim mots As List(Of String) = MotsCles(question)
        If mots.Count = 0 Then Return New List(Of SectionAide)
        Dim scores As New Dictionary(Of SectionAide, Integer)
        For Each s As SectionAide In _sectionsAide
            Dim score As Integer = 0
            For Each mot As String In mots
                If s.TitreNormalise.Contains(mot) Then score += 2
                If s.TexteNormalise.Contains(mot) Then score += 1
            Next
            If score > 0 Then scores.Add(s, score)
        Next
        Return scores.OrderByDescending(Function(kv) kv.Value).Take(nbMax).Select(Function(kv) kv.Key).ToList()
    End Function

    Private Async Function RepondreAide(q As String) As Task
        If _sectionsAide.Count = 0 Then
            AjouterMessageBot("Le fichier d'aide n'est pas disponible (rsc\aide\Aide_SP_Page_Designer.html) : je ne peux pas répondre aux questions pour le moment.")
            Return
        End If
        Dim extraits As List(Of SectionAide) = RechercherAide(q, 5)
        If extraits.Count = 0 Then
            Dim rubriques As String = String.Join(vbCrLf, _sectionsAide.Where(Function(s) Not s.Titre.Contains("(")).Select(Function(s) "  • " & s.Titre).Take(22))
            AjouterMessageBot("Je ne trouve rien dans l'aide qui corresponde à cette question." & vbCrLf &
                              "Rubriques couvertes par le guide :" & vbCrLf & rubriques)
            Return
        End If
        Dim msgs As List(Of AiChatMessage) = ConstruireMessagesAide(q, extraits, True)
        Dim rep As String = Nothing
        Dim reessayerReduit As Boolean = False
        Try
            rep = Await _config.EnvoyerChatAsync(msgs)
        Catch ex As Exception
            If Not EstErreurLimiteTokens(ex) Then Throw
            reessayerReduit = True
        End Try
        If reessayerReduit Then
            ' Limite de tokens du modèle atteinte : réessaie sans l'historique, avec 2 extraits
            AfficherPhaseReflexion("contexte réduit — limite de tokens du modèle")
            msgs = ConstruireMessagesAide(q, extraits.Take(2).ToList(), False)
            rep = Await _config.EnvoyerChatAsync(msgs)
        End If
        If rep.Trim() = "" Then rep = "Je n'ai reçu aucune réponse du modèle."
        AjouterMessageBot(rep)
        Memoriser(q, rep)
    End Function

    ''' <summary>Construit la conversation du mode Aide : prompt système appuyé sur les
    ''' extraits du guide + historique (optionnel) + question.</summary>
    Private Function ConstruireMessagesAide(q As String, extraits As List(Of SectionAide), avecHistorique As Boolean) As List(Of AiChatMessage)
        Dim ctx As New StringBuilder()
        For Each s As SectionAide In extraits
            ctx.Append("[Extrait — " & s.Titre & "]" & vbCrLf & s.Texte & vbCrLf & vbCrLf)
        Next
        Dim sys As String =
            "Tu es l'assistant d'aide du Designer de pages portail RHP (écran SP_Page_Designer de RHP_DeskTop)." & vbCrLf &
            "Règles :" & vbCrLf &
            "- Réponds en français, de façon concise et structurée (listes, **gras**)." & vbCrLf &
            "- Appuie-toi UNIQUEMENT sur les extraits de l'aide officielle fournis ci-dessous ; n'invente ni syntaxe, ni règle, ni écran." & vbCrLf &
            "- Si la réponse ne s'y trouve pas, dis-le clairement et indique la rubrique du guide à consulter." & vbCrLf &
            "- Ta mission se limite à expliquer la création de pages (formules, paramètres, sources métier, validations, habilitations, publication…)." & vbCrLf & vbCrLf &
            ctx.ToString()
        Dim msgs As New List(Of AiChatMessage) From {New AiChatMessage("system", sys)}
        If avecHistorique Then msgs.AddRange(_historique)
        msgs.Add(New AiChatMessage("user", q))
        Return msgs
    End Function

    '---------------- Mode 2 : génération du JSON d'une page ----------------

    ''' <summary>Prompt système du mode génération : le skill complet + protocole de
    ''' lecture des fichiers de référence (###FICHIER###) + contrat de sortie (bloc json).</summary>
    Private Function ConstruirePromptSystemeSkill() As String
        Dim skillMd As String = ""
        For Each k As String In _skill.Keys
            If k.EndsWith("/SKILL.md", StringComparison.OrdinalIgnoreCase) OrElse k.Equals("SKILL.md", StringComparison.OrdinalIgnoreCase) Then
                skillMd = _skill(k)
                Exit For
            End If
        Next
        Dim fichiers As New StringBuilder()
        For Each k As String In _skill.Keys.OrderBy(Function(x) x)
            Dim court As String = Regex.Replace(k, "^[^/]+/", "")   ' retire le préfixe racine du zip
            fichiers.Append("- " & court & vbCrLf)
        Next
        Return "Tu es le générateur de pages portail RHP intégré au Designer de pages (SP_Page_Designer, RHP_DeskTop)." & vbCrLf &
               "Tu appliques STRICTEMENT le skill ci-dessous pour transformer la description fonctionnelle de l'utilisateur" & vbCrLf &
               " en UN fichier JSON d'import (format RHP_PAGE_DESIGNER 1.0), importable via le bouton 'Importer JSON' du Designer." & vbCrLf &
               "La date du jour est " & DateTime.Now.ToString("yyyy-MM-dd") & " (pour exportedAt). L'utilisateur est '" & theUser.Login & "' (pour exportedBy)." & vbCrLf & vbCrLf &
               "==================== DÉBUT DU SKILL ====================" & vbCrLf &
               skillMd & vbCrLf &
               "===================== FIN DU SKILL =====================" & vbCrLf & vbCrLf &
               "FICHIERS DE RÉFÉRENCE DU SKILL (contenus fournis à la demande) :" & vbCrLf &
               fichiers.ToString() & vbCrLf &
               "Pour obtenir le contenu d'un fichier, réponds UNIQUEMENT par des lignes :" & vbCrLf &
               "###FICHIER### <chemin affiché ci-dessus>" & vbCrLf &
               "(une ligne par fichier ; tu recevras les contenus, puis tu continueras — demande au minimum" & vbCrLf &
               " references/json-import-format.md, et les autres références selon les besoins de la page)." & vbCrLf & vbCrLf &
               "QUAND TU DISPOSES DE TOUT LE CONTEXTE :" & vbCrLf &
               "1. Rédige le compte rendu concis prévu par le skill (mode création/mise à jour, faits vérifiés / hypothèses /" & vbCrLf &
               "   informations manquantes, avertissements d'import attendus, étapes manuelles post-import)." & vbCrLf &
               "2. Termine ta réponse par UN SEUL bloc ```json ... ``` contenant le fichier complet (UTF-8, vrais booléens" & vbCrLf &
               "   json, propriétés null omises), rédigé en format COMPACT (sans indentation ni sauts de ligne superflus)" & vbCrLf &
               "   pour limiter la taille de sortie — c'est le seul livrable ; tout le reste se dit dans le compte rendu." & vbCrLf &
               "Si la description est trop imprécise pour décider (codes, section cible, champs…), pose d'abord des questions" & vbCrLf &
               "de clarification SANS produire de bloc json."
    End Function

    ''' <summary>Contexte réel de la base cible (sections, zooms, rubriques, modèles,
    ''' profils, sources, pages existantes) — la 'découverte d'environnement' du skill,
    ''' faite ici directement en lecture dans la base. Le paramètre niveau réduit les
    ''' listes quand le modèle refuse pour limite de tokens (0 = complet, 1 = réduit,
    ''' 2 = minimal).</summary>
    Private Function ContexteEnvironnement(niveau As Integer) As String
        Dim d As Integer = If(niveau = 0, 1, If(niveau = 1, 3, 6))   ' diviseur des tailles de listes
        Dim sb As New StringBuilder()
        sb.AppendLine("ENVIRONNEMENT RÉEL DE LA BASE CIBLE (lecture directe — ne pas inventer d'autres codes) :")
        AjouterListeEnv(sb, "Sections du menu portail (Menu_Parent : Valeur — Membre)",
                        "select Valeur, Membre from Param_Rubriques where Nom_Controle='SP_Menu_Portail' order by Rang, Membre", 60 \ d)
        AjouterListeEnv(sb, "Icônes de menu disponibles (rubrique SP_Menu_Icones)",
                        "select Valeur, Valeur from Param_Rubriques where Nom_Controle='SP_Menu_Icones' order by Rang", 60 \ d)
        AjouterListeEnv(sb, "Modèles d'édition (Cod_Modele_Edition)",
                        "select Cod_Report, Nom_Report from Param_Mod_Edition order by Cod_Report", 40 \ d)
        AjouterListeEnv(sb, "Profils (habilitations)",
                        "select Cod_Profile, Lib_Profile from Controle_Profile order by Cod_Profile", 40 \ d)
        AjouterListeEnv(sb, "Zooms référencés (Num_Zoom — table — description)",
                        "select top 150 Num_Zoom, Table_Ref + ' — ' + isnull(Description,'') from Controle_Def_Zoom order by Num_Zoom", 150 \ d)
        AjouterListeEnv(sb, "Sources métier déjà cataloguées (réutilisables)",
                        "select Cod_Source, Libelle + ' [' + Typ_Retour + ']' from Controle_Designer_Source order by Cod_Source", 60 \ d)
        AjouterListeEnv(sb, "Pages déjà définies dans le Designer",
                        "select Cod_Page, Nom_Page + ' (doc ' + Cod_Document + ')' from Controle_Designer order by Cod_Page", 80 \ d)
        Return sb.ToString()
    End Function

    ''' <summary>Ajoute une liste 'code : libellé' lue en base au contexte d'environnement
    ''' (tolérante : une table absente ou une erreur n'interrompt pas la génération).</summary>
    Private Sub AjouterListeEnv(sb As StringBuilder, titre As String, sql As String, max As Integer)
        Try
            Dim tbl As DataTable = DATA_READER_GRD(sql)
            If tbl.Rows.Count = 0 Then Return
            sb.AppendLine(titre & " :")
            Dim n As Integer = 0
            For Each r As DataRow In tbl.Rows
                n += 1
                If n > max Then sb.AppendLine("  …") : Exit For
                sb.AppendLine("  • " & IsNull(r(0), "") & " : " & IsNull(r(1), ""))
            Next
        Catch ex As Exception
            Debug.WriteLine("ContexteEnvironnement (" & titre & ") : " & ex.Message)
        End Try
    End Sub

    ''' <summary>Résultat d'un envoi de génération (la conversation peut avoir été
    ''' reconstruite en mode réduit — voir EnvoyerGenerationAsync).</summary>
    Private Class EnvoiGen
        Public Messages As List(Of AiChatMessage)
        Public Reponse As String = ""
    End Class

    ''' <summary>Construit la conversation de génération au niveau de réduction courant :
    ''' prompt système (skill) + historique (niveau 0 uniquement) + description et
    ''' environnement (listes réduites aux niveaux 1 et 2).</summary>
    Private Function ConstruireMessagesGeneration(q As String) As List(Of AiChatMessage)
        Dim msgs As New List(Of AiChatMessage) From {
            New AiChatMessage("system", ConstruirePromptSystemeSkill())
        }
        If _niveauReduction = 0 Then msgs.AddRange(_historique)
        msgs.Add(New AiChatMessage("user", "Description fonctionnelle de la page à générer :" & vbCrLf & q & vbCrLf & vbCrLf & ContexteEnvironnement(_niveauReduction)))
        Return msgs
    End Function

    ''' <summary>Envoie la conversation de génération au modèle. Si celui-ci refuse pour
    ''' dépassement de sa limite de tokens, la conversation est reconstruite en mode
    ''' réduit SANS perdre la progression (historique supprimé, environnement réduit,
    ''' références déjà servies tronquées) puis renvoyée — jusqu'à 2 réductions ;
    ''' au-delà, une erreur explicite est levée.</summary>
    Private Async Function EnvoyerGenerationAsync(msgs As List(Of AiChatMessage), q As String) As Task(Of EnvoiGen)
        While True
            Try
                Dim rep As String = Await _config.EnvoyerChatAsync(msgs, 300000)
                Return New EnvoiGen With {.Messages = msgs, .Reponse = rep}
            Catch ex As Exception
                If Not EstErreurLimiteTokens(ex) Then Throw
                If _niveauReduction >= 2 Then
                    Throw New Exception("La demande dépasse la capacité du modèle configuré (" & _config.Provider & " / " & _config.Modele & "), même en contexte réduit." & vbCrLf &
                                        "Raccourcissez la description, ou choisissez un modèle avec une fenêtre de contexte plus grande (liste 'Modèle' en haut — catalogue de l'écran AI_Modeles).")
                End If
                AfficherPhaseReflexion("contexte réduit — limite de tokens du modèle")
                msgs = ReduireMessagesGeneration(msgs, q)
            End Try
        End While
    End Function

    ''' <summary>Reconstruit la conversation au niveau de réduction supérieur en
    ''' CONSERVANT la progression de la boucle agentique : le prompt système (skill)
    ''' et les échanges de la boucle sont gardés ; seuls l'historique est supprimé,
    ''' l'environnement réduit et les références déjà servies tronquées.</summary>
    Private Function ReduireMessagesGeneration(msgs As List(Of AiChatMessage), q As String) As List(Of AiChatMessage)
        _niveauReduction += 1
        Dim rsl As New List(Of AiChatMessage)
        rsl.Add(msgs(0))   ' prompt système (skill) inchangé
        rsl.Add(New AiChatMessage("user", "Description fonctionnelle de la page à générer :" & vbCrLf & q & vbCrLf & vbCrLf & ContexteEnvironnement(_niveauReduction)))
        ' Echanges de la boucle (après la description) : gardés, références tronquées
        Dim debutBoucle As Integer = -1
        For i As Integer = 1 To msgs.Count - 1
            If msgs(i).Role = "user" AndAlso msgs(i).Content.StartsWith("Description fonctionnelle de la page à générer") Then
                debutBoucle = i + 1
                Exit For
            End If
        Next
        If debutBoucle > 0 Then
            For i As Integer = debutBoucle To msgs.Count - 1
                Dim m As AiChatMessage = msgs(i)
                If m.Role = "user" AndAlso m.Content.Contains("-----") Then
                    rsl.Add(New AiChatMessage("user", TronquerReferences(m.Content, PlafondReference())))
                Else
                    rsl.Add(m)
                End If
            Next
        End If
        Return rsl
    End Function

    ''' <summary>Plafond de taille (caractères) d'un fichier de référence servi ou
    ''' conservé au niveau de réduction courant (0 = illimité).</summary>
    Private Function PlafondReference() As Integer
        Return If(_niveauReduction = 0, 0, If(_niveauReduction = 1, 20000, 8000))
    End Function

    ''' <summary>Contenu d'un fichier du skill servi au modèle, tronqué en mode réduit
    ''' pour rester sous sa limite de tokens.</summary>
    Private Function ContenuFichierSkill(cle As String) As String
        Dim contenu As String = _skill(cle)
        Dim plafond As Integer = PlafondReference()
        If plafond > 0 AndAlso contenu.Length > plafond Then
            contenu = contenu.Substring(0, plafond) & vbCrLf & "[… contenu tronqué — limite de tokens du modèle …]"
        End If
        Return contenu
    End Function

    ''' <summary>Tronque le contenu de chaque bloc '----- fichier -----' d'un message de
    ''' références déjà servi (réduction de contexte sans casser le protocole ###FICHIER###).</summary>
    Private Shared Function TronquerReferences(contenu As String, plafond As Integer) As String
        Dim lignes As String() = contenu.Split({vbLf}, StringSplitOptions.None)
        Dim sb As New StringBuilder()
        Dim bloc As Integer = -1        ' longueur cumulée du bloc courant (-1 = hors bloc)
        Dim tronque As Boolean = False  ' bloc courant déjà tronqué : la suite est ignorée
        For Each lig As String In lignes
            If lig.StartsWith("----- ") AndAlso lig.TrimEnd().EndsWith("-----") Then
                bloc = 0
                tronque = False
                sb.AppendLine(lig)
            ElseIf bloc >= 0 AndAlso Not tronque Then
                If bloc + lig.Length <= plafond Then
                    sb.AppendLine(lig)
                    bloc += lig.Length
                Else
                    sb.AppendLine("[… contenu tronqué — limite de tokens du modèle …]")
                    tronque = True
                End If
            ElseIf bloc < 0 Then
                sb.AppendLine(lig)
            End If
        Next
        Return sb.ToString().TrimEnd()
    End Function

    ''' <summary>L'erreur vient-elle d'un dépassement de la fenêtre de contexte du modèle ?
    ''' (libellés des principaux fournisseurs : Kimi/Moonshot « token limit », OpenAI et
    ''' Azure « maximum context length », Mistral « prompt is too long », Gemini « exceeds
    ''' the maximum number of tokens », Groq « request too large »…).</summary>
    Private Shared Function EstErreurLimiteTokens(ex As Exception) As Boolean
        Dim m As String = If(ex.Message, "").ToLowerInvariant()
        Return m.Contains("token limit") OrElse
               m.Contains("context length") OrElse
               m.Contains("context_length") OrElse
               m.Contains("maximum context") OrElse
               m.Contains("too many tokens") OrElse
               m.Contains("prompt is too long") OrElse
               m.Contains("reduce the length") OrElse
               m.Contains("exceeds the maximum number of tokens") OrElse
               m.Contains("request too large") OrElse
               m.Contains("payload size exceeds")
    End Function

    Private Async Function GenererPage(q As String) As Task
        If _skill.Count = 0 Then
            AjouterMessageBot("Le skill de génération est introuvable (rsc\rhp-portal-page-deployer.zip) : vérifiez le déploiement de l'application.")
            Return
        End If
        _niveauReduction = 0
        Dim msgs As List(Of AiChatMessage) = ConstruireMessagesGeneration(q)

        '---------------- Boucle agentique : lecture des fichiers du skill à la demande ----------------
        Dim rep As String = ""
        Dim servis As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)   ' fichiers déjà fournis
        Dim i As Integer = 0
        While i < 14
            i += 1
            Dim envoi As EnvoiGen = Await EnvoyerGenerationAsync(msgs, q)
            msgs = envoi.Messages
            rep = envoi.Reponse
            Dim demandes As MatchCollection = Regex.Matches(rep, "#{2,}\s*FICHIER\s*#{2,}\s*([^\r\n#]+)", RegexOptions.IgnoreCase)
            If demandes.Count = 0 Then Exit While
            msgs.Add(New AiChatMessage("assistant", rep))
            If servis.Count >= 10 Then
                ' Anti-boucle : assez de références servies — le modèle doit maintenant produire.
                msgs.Add(New AiChatMessage("user", "Tu as déjà reçu les références essentielles du skill. Ne demande plus de fichier :" & vbCrLf &
                                           "rédige maintenant le compte rendu prévu, puis termine par le bloc ```json ... ``` complet."))
                AfficherPhaseReflexion("rédaction du JSON")
                Continue While
            End If
            Dim sb As New StringBuilder()
            For Each m As Match In demandes
                Dim chemin As String = m.Groups(1).Value.Trim().TrimStart("/"c).Replace("\"c, "/"c)
                Dim cle As String = _skill.Keys.FirstOrDefault(
                    Function(k) k.Equals(chemin, StringComparison.OrdinalIgnoreCase) OrElse
                                k.Equals(Regex.Replace(chemin, "^[^/]+/", ""), StringComparison.OrdinalIgnoreCase) OrElse
                                k.EndsWith("/" & chemin, StringComparison.OrdinalIgnoreCase))
                If cle IsNot Nothing Then
                    sb.AppendLine("----- " & cle & " -----")
                    If servis.Contains(cle) Then
                        sb.AppendLine("[déjà fourni ci-dessus — ne le redemande pas]")
                    Else
                        servis.Add(cle)
                        sb.AppendLine(ContenuFichierSkill(cle))
                    End If
                    sb.AppendLine()
                Else
                    sb.AppendLine("Fichier inconnu : " & chemin & " — choisis parmi la liste fournie.")
                End If
            Next
            msgs.Add(New AiChatMessage("user", sb.ToString()))
            AfficherPhaseReflexion("lecture des références")
        End While

        '---------------- Extraction du JSON produit (reprise si réponse coupée) ----------------
        Dim ext As Tuple(Of String, Boolean) = Await CompleterJsonTronqueAsync(msgs, q, rep)
        Dim json As String = ext.Item1
        If json = "" Then
            If ext.Item2 Then
                ' Réponse coupée par la limite de sortie du modèle, jamais complétée
                AjouterMessageBot("Le modèle n'a pas réussi à produire le fichier JSON complet : sa réponse est tronquée par sa limite de sortie." & vbCrLf &
                                  "Simplifiez la page demandée (moins de champs), ou choisissez un modèle avec une plus grande limite de sortie (liste 'Modèle' en haut — catalogue de l'écran AI_Modeles).")
                Memoriser(q, "Génération impossible : json tronqué (limite de sortie du modèle).")
            Else
                ' Pas de JSON : clarifications / compte rendu textuel — affiché tel quel.
                AjouterMessageBot(If(rep.Trim() <> "", rep, "Je n'ai reçu aucune réponse du modèle."))
                Memoriser(q, rep)
            End If
            Return
        End If

        '---------------- Validation par l'importeur du produit (aucune écriture) ----------------
        Dim res As SP_Page_ImportResultat = SP_Page_Json_Import.Analyser(json)
        If res.Bloquant Then
            ' Une tentative de correction : les erreurs bloquantes sont renvoyées au modèle.
            msgs.Add(New AiChatMessage("assistant", rep))
            msgs.Add(New AiChatMessage("user",
                "Le JSON généré ne passe pas la validation de l'importeur du Designer :" & vbCrLf &
                " - " & String.Join(vbCrLf & " - ", res.Erreurs) & vbCrLf &
                "Corrige TOUTES ces anomalies et renvoie UNIQUEMENT le bloc ```json ... ``` corrigé complet."))
            AfficherPhaseReflexion("correction du JSON")
            Dim envoi As EnvoiGen = Await EnvoyerGenerationAsync(msgs, q)
            msgs = envoi.Messages
            rep = envoi.Reponse
            Dim ext2 As Tuple(Of String, Boolean) = Await CompleterJsonTronqueAsync(msgs, q, rep)
            json = ext2.Item1
            If json <> "" Then res = SP_Page_Json_Import.Analyser(json)
        End If
        If json = "" OrElse res.Bloquant Then
            Dim detail As String = If(json = "", "le modèle n'a pas renvoyé de JSON corrigé.",
                                      "anomalies bloquantes restantes :" & vbCrLf & " - " & String.Join(vbCrLf & " - ", res.Erreurs))
            AjouterMessageBot("La génération n'a pas abouti à un fichier importable (" & detail & vbCrLf &
                              "Précisez votre description et réessayez.")
            Memoriser(q, "Génération impossible : " & detail)
            Return
        End If

        '---------------- Écriture du fichier SUR LE POSTE UTILISATEUR ----------------
        Dim pkg As SP_Page_Package = res.Package
        Dim codPage As String = pkg.Page.Cod_Page.Trim()
        If codPage = "" Then codPage = "Nouvelle"
        Dim dossier As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RHP", "Pages_Generees")
        Directory.CreateDirectory(dossier)
        _fichierGenere = IO.Path.Combine(dossier, "RHP_Page_" & codPage & ".json")
        File.WriteAllText(_fichierGenere, json, New UTF8Encoding(False))
        lnkTelechargement.Text = IO.Path.GetFileName(_fichierGenere)
        pnlTelechargement.Visible = True

        '---------------- Compte rendu ----------------
        Dim pageExiste As Boolean = ExistePage(codPage)
        Dim nbColonnes As Integer = 0
        For Each t As SP_Page_TableDto In pkg.SqlStructure
            nbColonnes += t.Colonnes.Count
        Next
        Dim texteHorsJson As String = Regex.Replace(rep, "```(?:json)?[\s\S]*$", "", RegexOptions.IgnoreCase).Trim()
        Dim compteRendu As New StringBuilder()
        If texteHorsJson <> "" Then compteRendu.Append(texteHorsJson & vbCrLf & vbCrLf)
        compteRendu.Append("✅ Fichier JSON généré sur ce poste : " & IO.Path.GetFileName(_fichierGenere) &
                      " (" & If(pageExiste, "mise à jour de la page existante '" & codPage & "'", "nouvelle page") & ")" & vbCrLf)
        compteRendu.Append("Contenu : " & pkg.SqlStructure.Count & " table(s), " & nbColonnes & " colonne(s), " &
                      pkg.Components.Count & " champ(s), " & pkg.BusinessSources.Count & " source(s) métier, " &
                      pkg.Validations.Count & " validation(s)." & vbCrLf)
        If _niveauReduction > 0 Then
            compteRendu.Append("⚠ La limite de tokens du modèle a été atteinte : génération faite en contexte réduit" &
                          " (historique et listes d'environnement tronqués) — vérifiez le résultat à l'import." & vbCrLf)
        End If
        If res.Avertissements.Count > 0 Then
            compteRendu.Append("Avertissements à prévoir à l'import :" & vbCrLf & " - " &
                          String.Join(vbCrLf & " - ", res.Avertissements.Take(10)) & vbCrLf)
        End If
        compteRendu.Append(vbCrLf & "Pour déployer la page : cliquez le lien de téléchargement sous la zone de chat pour enregistrer" &
                      " le fichier où vous voulez, puis dans le Designer : 'Importer JSON' → sélectionnez-le → 'Valider' →" &
                      " corrigez les avertissements → 'Enregistrer' → onglet Habilitations → 'Publier'.")
        AjouterMessageBot(compteRendu.ToString())
        Memoriser(q, compteRendu.ToString())
    End Function

    ''' <summary>Extrait le premier objet json équilibré du texte (bloc ```json privilégié ;
    ''' accolades comptées hors des chaînes, échappements gérés). Si un bloc json est amorcé
    ''' mais jamais refermé (réponse coupée par la limite de sortie du modèle), retourne ""
    ''' et positionne estTronque à True.</summary>
    Private Shared Function ExtraireJson(texte As String, Optional ByRef estTronque As Boolean = False) As String
        estTronque = False
        If String.IsNullOrEmpty(texte) Then Return ""
        Dim debut As Integer = -1
        Dim m As Match = Regex.Match(texte, "```(?:json)?\s*", RegexOptions.IgnoreCase)
        If m.Success Then
            debut = texte.IndexOf("{"c, m.Index + m.Length)
            If debut < 0 Then
                ' Balise ```json amorcée mais jamais suivie d'un objet : réponse coupée
                estTronque = True
                Return ""
            End If
        End If
        If debut < 0 Then debut = texte.IndexOf("{"c)
        If debut < 0 Then Return ""
        Dim prof As Integer = 0
        Dim dansChaine As Boolean = False
        Dim echap As Boolean = False
        For i As Integer = debut To texte.Length - 1
            Dim ch As Char = texte(i)
            If dansChaine Then
                If echap Then
                    echap = False
                ElseIf ch = "\"c Then
                    echap = True
                ElseIf ch = """"c Then
                    dansChaine = False
                End If
            Else
                If ch = """"c Then
                    dansChaine = True
                ElseIf ch = "{"c Then
                    prof += 1
                ElseIf ch = "}"c Then
                    prof -= 1
                    If prof = 0 Then Return texte.Substring(debut, i - debut + 1)
                End If
            End If
        Next
        ' Fin du texte sans refermer l'objet : réponse coupée par la limite de sortie
        estTronque = True
        Return ""
    End Function

    ''' <summary>Demande au modèle la suite d'une réponse dont le json a été coupé par sa
    ''' limite de sortie (jusqu'à 3 reprises, concaténées sans saut de ligne — le json peut
    ''' être coupé en plein jeton). Retourne (json complet ou "", True si réponse tronquée).</summary>
    Private Async Function CompleterJsonTronqueAsync(msgs As List(Of AiChatMessage), q As String, rep As String) As Task(Of Tuple(Of String, Boolean))
        Dim complet As String = rep
        Dim tronque As Boolean = False
        Dim json As String = ExtraireJson(complet, tronque)
        If Not tronque Then Return Tuple.Create(json, False)
        Dim nbSuites As Integer = 0
        While tronque AndAlso nbSuites < 3
            nbSuites += 1
            msgs.Add(New AiChatMessage("assistant", rep))
            msgs.Add(New AiChatMessage("user",
                "Ta réponse a été coupée par la limite de sortie du modèle : le bloc json est incomplet." & vbCrLf &
                "Reprends EXACTEMENT au caractère où tu t'es arrêté, sans rien répéter, sans commentaire" & vbCrLf &
                "ni balise markdown — uniquement la suite brute du json (garde-le COMPACT, sans indentation)."))
            AfficherPhaseReflexion("suite du JSON (" & nbSuites & ")")
            Dim envoi As EnvoiGen = Await EnvoyerGenerationAsync(msgs, q)
            msgs.Clear()
            msgs.AddRange(envoi.Messages)   ' conserve la conversation (éventuellement réduite)
            rep = envoi.Reponse
            Dim suite As String = Regex.Replace(rep.TrimStart(), "^```(?:json)?\s*", "", RegexOptions.IgnoreCase)
            If suite = "" Then Exit While
            complet &= suite
            json = ExtraireJson(complet, tronque)
        End While
        Return Tuple.Create(json, True)
    End Function

    ''' <summary>La page existe-t-elle déjà en base (mode mise à jour à l'import) ?</summary>
    Private Shared Function ExistePage(codPage As String) As Boolean
        Try
            Dim rs As ADODB.Recordset = CnExecuting("select count(*) from Controle_Designer where Cod_Page='" & codPage.Replace("'", "''") & "'")
            Return rs IsNot Nothing AndAlso Not rs.EOF AndAlso CInt(IsNull(rs.Fields(0).Value, "0")) > 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>Mémorise l'échange (borné à Nb_Msg_Memory échanges, comme l'assistant portail).</summary>
    Private Sub Memoriser(question As String, reponse As String)
        If reponse.Trim() <> "" Then
            _historique.Add(New AiChatMessage("user", question))
            _historique.Add(New AiChatMessage("assistant", reponse))
        End If
        Dim max As Integer = Math.Max(1, If(_config IsNot Nothing, _config.NbMsgMemory, 5)) * 2
        While _historique.Count > max
            _historique.RemoveAt(0)
        End While
    End Sub

    '---------------- Événements ----------------

    Private Sub Envoyer_pb_Click(sender As Object, e As EventArgs) Handles Envoyer_pb.Click
        Envoyer()
    End Sub

    Private Sub txtMessage_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMessage.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Not e.Shift Then
            e.SuppressKeyPress = True
            Envoyer()
        End If
    End Sub

    ''' <summary>Nouvelle conversation : réinitialise la zone de chat, l'historique et le téléchargement.</summary>
    Private Sub Nouveau_pb_Click(sender As Object, e As EventArgs) Handles Nouveau_pb.Click
        If _envoiEnCours Then Return
        _historique.Clear()
        txtChat.Clear()
        pnlTelechargement.Visible = False
        _fichierGenere = ""
        AjouterMessageBot("Nouvelle conversation. Choisissez le mode (Aide / Génération) puis écrivez votre message.")
        txtMessage.Focus()
    End Sub

    ''' <summary>Lien de téléchargement : copie le fichier généré à l'emplacement choisi
    ''' par l'utilisateur (Téléchargements proposé par défaut), puis l'y sélectionne.</summary>
    Private Sub lnkTelechargement_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTelechargement.LinkClicked
        If _fichierGenere = "" OrElse Not File.Exists(_fichierGenere) Then Return
        Try
            Dim dlg As New SaveFileDialog()
            dlg.Title = "Télécharger le fichier JSON généré"
            dlg.Filter = "Fichiers JSON (*.json)|*.json"
            dlg.FileName = IO.Path.GetFileName(_fichierGenere)
            Dim tele As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads")
            If Directory.Exists(tele) Then dlg.InitialDirectory = tele
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return
            File.Copy(_fichierGenere, dlg.FileName, True)
            AjouterMessageBot("Fichier téléchargé : " & dlg.FileName & vbCrLf &
                              "Dans le Designer : bouton 'Importer JSON' → sélectionnez ce fichier.")
            Process.Start(New ProcessStartInfo("explorer.exe", "/select,""" & dlg.FileName & """") With {.UseShellExecute = True})
        Catch ex As Exception
            ShowMessageBox("Téléchargement impossible : " & ex.Message, "Assistant IA", MessageBoxButtons.OK, msgIcon.Stop)
        End Try
    End Sub

    ''' <summary>Ouvre l'explorateur sur le fichier généré (zone de préparation locale).</summary>
    Private Sub lnkDossier_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDossier.LinkClicked
        If _fichierGenere = "" OrElse Not File.Exists(_fichierGenere) Then Return
        Try
            Process.Start(New ProcessStartInfo("explorer.exe", "/select,""" & _fichierGenere & """") With {.UseShellExecute = True})
        Catch ex As Exception
            ShowMessageBox("Impossible d'ouvrir le dossier : " & ex.Message, "Assistant IA", MessageBoxButtons.OK, msgIcon.Stop)
        End Try
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Zoom_SP_Assistant_IA_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    ''' <summary>Fermeture : arrête l'animation de réflexion et libère ses ressources.</summary>
    Private Sub Zoom_SP_Assistant_IA_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        SupprimerReflexion()
        _policeReflexionTitre.Dispose()
        _policeReflexion.Dispose()
    End Sub

End Class
