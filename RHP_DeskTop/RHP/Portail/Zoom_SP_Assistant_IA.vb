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
''' Aucune écriture en base : l'enregistrement reste l'action de l'utilisateur
''' dans le Designer ('Enregistrer' puis 'Publier').
''' Le LLM est celui de l'assistant IA de RHP (table Ai_Agent — Ai_ChatClient,
''' miroir de callAgentChat du backend portail).
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
        '---------------- Message d'accueil ----------------
        Dim accueil As New StringBuilder()
        accueil.Append("Bonjour ! Je suis l'assistant du Designer de pages portail, avec deux fonctions exclusives (choisissez en haut) :" & vbCrLf)
        accueil.Append("  • Aide — posez vos questions sur la création de pages : formules, paramètres, sources métier, validations, grilles virtuelles…" & vbCrLf)
        accueil.Append("  • Génération — décrivez la page voulue ; je produis le fichier JSON d'import sur VOTRE poste (lien de téléchargement)," & vbCrLf)
        accueil.Append("    à charger ensuite via le bouton 'Importer JSON' du Designer.")
        If _config Is Nothing Then
            accueil.Append(vbCrLf & vbCrLf & "⚠ L'assistant IA n'est pas configuré (table Ai_Agent) : ouvrez l'écran 'AI_KnowledgeBase' pour renseigner le fournisseur, le modèle et la clé d'API.")
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

    ''' <summary>(Ré)écrit le message provisoire de réflexion à la fin du chat.</summary>
    Private Sub RendreReflexion()
        If _reflexionDebut < 0 OrElse txtChat.IsDisposed Then Return
        txtChat.Select(_reflexionDebut, txtChat.TextLength - _reflexionDebut)
        txtChat.SelectedText = ""
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
        If _reflexionDebut >= 0 AndAlso Not txtChat.IsDisposed Then
            txtChat.Select(_reflexionDebut, txtChat.TextLength - _reflexionDebut)
            txtChat.SelectedText = ""
        End If
        _reflexionDebut = -1
    End Sub

    '---------------- Envoi d'un message ----------------

    Private Async Sub Envoyer()
        If _envoiEnCours Then Return
        Dim q As String = txtMessage.Text.Trim()
        If q = "" Then Return
        If _config Is Nothing Then
            ShowMessageBox("L'assistant IA n'est pas configuré (table Ai_Agent)." & vbCrLf &
                           "Ouvrez l'écran 'AI_KnowledgeBase' pour renseigner le fournisseur, le modèle et la clé d'API.",
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
        msgs.AddRange(_historique)
        msgs.Add(New AiChatMessage("user", q))
        Dim rep As String = Await _config.EnvoyerChatAsync(msgs)
        If rep.Trim() = "" Then rep = "Je n'ai reçu aucune réponse du modèle."
        AjouterMessageBot(rep)
        Memoriser(q, rep)
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
               "   json, propriétés null omises) — c'est le seul livrable ; tout le reste se dit dans le compte rendu." & vbCrLf &
               "Si la description est trop imprécise pour décider (codes, section cible, champs…), pose d'abord des questions" & vbCrLf &
               "de clarification SANS produire de bloc json."
    End Function

    ''' <summary>Contexte réel de la base cible (sections, zooms, rubriques, modèles,
    ''' profils, sources, pages existantes) — la 'découverte d'environnement' du skill,
    ''' faite ici directement en lecture dans la base.</summary>
    Private Function ContexteEnvironnement() As String
        Dim sb As New StringBuilder()
        sb.AppendLine("ENVIRONNEMENT RÉEL DE LA BASE CIBLE (lecture directe — ne pas inventer d'autres codes) :")
        AjouterListeEnv(sb, "Sections du menu portail (Menu_Parent : Valeur — Membre)",
                        "select Valeur, Membre from Param_Rubriques where Nom_Controle='SP_Menu_Portail' order by Rang, Membre", 60)
        AjouterListeEnv(sb, "Icônes de menu disponibles (rubrique SP_Menu_Icones)",
                        "select Valeur, Valeur from Param_Rubriques where Nom_Controle='SP_Menu_Icones' order by Rang", 60)
        AjouterListeEnv(sb, "Modèles d'édition (Cod_Modele_Edition)",
                        "select Cod_Report, Nom_Report from Param_Mod_Edition order by Cod_Report", 40)
        AjouterListeEnv(sb, "Profils (habilitations)",
                        "select Cod_Profile, Lib_Profile from Controle_Profile order by Cod_Profile", 40)
        AjouterListeEnv(sb, "Zooms référencés (Num_Zoom — table — description)",
                        "select top 150 Num_Zoom, Table_Ref + ' — ' + isnull(Description,'') from Controle_Def_Zoom order by Num_Zoom", 150)
        AjouterListeEnv(sb, "Sources métier déjà cataloguées (réutilisables)",
                        "select Cod_Source, Libelle + ' [' + Typ_Retour + ']' from Controle_Designer_Source order by Cod_Source", 60)
        AjouterListeEnv(sb, "Pages déjà définies dans le Designer",
                        "select Cod_Page, Nom_Page + ' (doc ' + Cod_Document + ')' from Controle_Designer order by Cod_Page", 80)
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

    Private Async Function GenererPage(q As String) As Task
        If _skill.Count = 0 Then
            AjouterMessageBot("Le skill de génération est introuvable (rsc\rhp-portal-page-deployer.zip) : vérifiez le déploiement de l'application.")
            Return
        End If
        Dim msgs As New List(Of AiChatMessage) From {
            New AiChatMessage("system", ConstruirePromptSystemeSkill())
        }
        msgs.AddRange(_historique)
        msgs.Add(New AiChatMessage("user", "Description fonctionnelle de la page à générer :" & vbCrLf & q & vbCrLf & vbCrLf & ContexteEnvironnement()))

        '---------------- Boucle agentique : lecture des fichiers du skill à la demande ----------------
        Dim rep As String = ""
        For i As Integer = 1 To 8
            rep = Await _config.EnvoyerChatAsync(msgs, 300000)
            Dim demandes As MatchCollection = Regex.Matches(rep, "#{2,}\s*FICHIER\s*#{2,}\s*([^\r\n#]+)", RegexOptions.IgnoreCase)
            If demandes.Count = 0 Then Exit For
            msgs.Add(New AiChatMessage("assistant", rep))
            Dim sb As New StringBuilder()
            For Each m As Match In demandes
                Dim chemin As String = m.Groups(1).Value.Trim().TrimStart("/"c).Replace("\"c, "/"c)
                Dim cle As String = _skill.Keys.FirstOrDefault(
                    Function(k) k.Equals(chemin, StringComparison.OrdinalIgnoreCase) OrElse
                                k.Equals(Regex.Replace(chemin, "^[^/]+/", ""), StringComparison.OrdinalIgnoreCase) OrElse
                                k.EndsWith("/" & chemin, StringComparison.OrdinalIgnoreCase))
                If cle IsNot Nothing Then
                    sb.AppendLine("----- " & cle & " -----")
                    sb.AppendLine(_skill(cle))
                    sb.AppendLine()
                Else
                    sb.AppendLine("Fichier inconnu : " & chemin & " — choisis parmi la liste fournie.")
                End If
            Next
            msgs.Add(New AiChatMessage("user", sb.ToString()))
            AfficherPhaseReflexion("lecture des références")
        Next

        '---------------- Extraction du JSON produit ----------------
        Dim json As String = ExtraireJson(rep)
        If json = "" Then
            ' Pas de JSON : clarifications / compte rendu textuel — affiché tel quel.
            AjouterMessageBot(If(rep.Trim() <> "", rep, "Je n'ai reçu aucune réponse du modèle."))
            Memoriser(q, rep)
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
            rep = Await _config.EnvoyerChatAsync(msgs, 300000)
            json = ExtraireJson(rep)
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
    ''' accolades comptées hors des chaînes, échappements gérés).</summary>
    Private Shared Function ExtraireJson(texte As String) As String
        If String.IsNullOrEmpty(texte) Then Return ""
        Dim debut As Integer = -1
        Dim m As Match = Regex.Match(texte, "```(?:json)?\s*", RegexOptions.IgnoreCase)
        If m.Success Then debut = texte.IndexOf("{"c, m.Index + m.Length)
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
        Return ""
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
