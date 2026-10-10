Imports System.Drawing
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Threading.Tasks
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports Newtonsoft.Json.Linq

''' <summary>Formation extraite d'un CV (ligne de la grille Formations de la CVTheque).</summary>
Public Class CvFormation
    Public Property Annee As String = ""
    Public Property Diplome As String = ""
    Public Property Etablissement As String = ""
    Public Property Niveau As String = ""
    Public Property Commentaire As String = ""
End Class

''' <summary>Expérience professionnelle extraite d'un CV (grille Expériences de la CVTheque).</summary>
Public Class CvExperience
    Public Property Dat_Deb As String = ""
    Public Property Dat_Fin As String = ""
    Public Property Etablissement As String = ""   ' entreprise
    Public Property Poste As String = ""
    Public Property Commentaire As String = ""     ' missions principales
End Class

''' <summary>Données structurées extraites d'un CV par l'IA (import CVTheque) : identité,
''' coordonnées, formations, expériences, compétences et photo d'identité éventuelle.</summary>
Public Class CvImportData
    Public Property Nom As String = ""
    Public Property Prenom As String = ""
    Public Property Civilite As String = ""
    Public Property Sexe As String = ""
    Public Property Dat_Naissance As String = ""
    Public Property Lieu_Naissance As String = ""
    Public Property Nationalite As String = ""
    Public Property Adresse As String = ""
    Public Property Ville As String = ""
    Public Property CodePostal As String = ""
    Public Property Pays As String = ""
    Public Property Gsm As String = ""
    Public Property Fixe As String = ""
    Public Property Mail As String = ""
    Public Property CIN As String = ""
    Public Property Titre As String = ""
    Public Property Poste_Recherche As String = ""
    Public Property Situation As String = ""
    Public Property Profil_Resume As String = ""
    Public Property Formations As New List(Of CvFormation)
    Public Property Experiences As New List(Of CvExperience)
    Public Property Competences As New List(Of String)
    Public Property Photo As Bitmap = Nothing
    Public Property ModeExtraction As String = ""   ' 'Texte' ou 'Vision (OCR IA)'
End Class

''' <summary>
''' Moteur d'import de CV de la cvthèque (écran CVTheque) — lecture la plus précise possible :
'''   1. PDF natif / DOCX / TXT : extraction DIRECTE du texte (iTextSharp / RichEdit) = exacte
'''      à 100 %, puis structuration par le LLM (texte) — la photo est lue séparément sur la
'''      1ère page rendue en image (DevExpress.Pdf) ou extraite des images embarquées ;
'''   2. PDF scanné / image (JPG, PNG...) : OCR par le LLM MULTIMODAL (vision) — bien plus
'''      précis qu'un OCR classique (Tesseract) sur les mises en page complexes d'un CV —
'''      qui retourne en un seul appel les données structurées ET la zone de la photo
'''      (photo_box), croppée ensuite localement.
''' Le modèle utilisé est le modèle par défaut de Ai_Agent (écran AI_Modeles), comme tous
''' les consommateurs LLM de RHP.
''' </summary>
Module Module_CV_Import

    Private Const MAX_PAGES_VISION As Integer = 3     ' pages max envoyées en vision (coût)
    Private Const SEUIL_TEXTE_NATIF As Integer = 150  ' caractères alpha min pour un PDF "texte"

#Region "Extraction du contenu du fichier"

    ''' <summary>Texte brut du fichier CV : PDF (iTextSharp), DOCX/DOC (RichEdit), TXT.
    ''' Retourne "" pour les images et les PDF scannés (pas de couche texte).</summary>
    Public Function ExtraireTexteFichier(filePath As String) As String
        Try
            Select Case IO.Path.GetExtension(filePath).ToLowerInvariant()
                Case ".pdf"
                    Dim sb As New StringBuilder()
                    Using reader As New PdfReader(filePath)
                        For i As Integer = 1 To reader.NumberOfPages
                            sb.Append(PdfTextExtractor.GetTextFromPage(reader, i))
                            sb.Append(vbLf)
                        Next
                    End Using
                    Return sb.ToString()
                Case ".docx", ".doc", ".rtf"
                    Using server As New DevExpress.XtraRichEdit.RichEditDocumentServer()
                        server.LoadDocument(filePath)
                        Return server.Text
                    End Using
                Case ".txt"
                    Return File.ReadAllText(filePath, Encoding.UTF8)
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Debug.WriteLine("ExtraireTexteFichier : " & ex.Message)
            Return ""
        End Try
    End Function

    ''' <summary>Rend les premières pages d'un PDF en images (bord le plus long ~2000 px)
    ''' pour l'OCR par vision et la recherche de la photo. La rasterisation est confiée au
    ''' Python embarqué de RHP (FindParam "chemin_python") avec PyMuPDF installé à la volée
    ''' — même pattern d'installation automatique que Scan_Piece_Identite (OpenCV).</summary>
    Public Function RendrePagesPdfEnImages(filePath As String, Optional maxPages As Integer = MAX_PAGES_VISION) As List(Of Bitmap)
        Dim pages As New List(Of Bitmap)
        Dim outDir As String = ""
        Try
            Dim rnd As New Random
            outDir = IO.Path.Combine(My.Application.Info.DirectoryPath, "TMP\cv_pages_" & rnd.Next(12000, 1569221)).Replace("\", "/")
            Dim src As String = filePath.Replace("\", "/")
            Dim py As String = "
import os, sys, subprocess
def import_fitz():
    try:
        import pymupdf
        return pymupdf
    except ImportError:
        try:
            import fitz
            return fitz
        except ImportError:
            print('Installation de PyMuPDF (rendu des pages du PDF)...', flush=True)
            subprocess.run([sys.executable, '-m', 'pip', 'install', 'pymupdf'], capture_output=True, timeout=600)
            import pymupdf
            return pymupdf
fitz = import_fitz()
doc = fitz.open(""" & Chr(34) & src & Chr(34) & """)
os.makedirs(""" & Chr(34) & outDir & Chr(34) & """, exist_ok=True)
nb = min(" & maxPages & ", doc.page_count)
for i in range(nb):
    page = doc.load_page(i)
    z = 2000.0 / max(page.rect.width, page.rect.height)
    pix = page.get_pixmap(matrix=fitz.Matrix(z, z))
    pix.save(""" & Chr(34) & outDir & Chr(34) & """ + '/page_%d.png' % (i + 1))
print('Pages rendues : %d' % nb, flush=True)
"
            Dim sb As New System.Text.StringBuilder
            executerCodePython(py, sb, False)
            Debug.WriteLine("RendrePagesPdfEnImages : " & sb.ToString())
            If IO.Directory.Exists(outDir) Then
                For Each png In IO.Directory.GetFiles(outDir, "page_*.png").OrderBy(Function(f) f)
                    Using fs As New IO.FileStream(png, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                        pages.Add(New Bitmap(Image.FromStream(fs)))
                    End Using
                Next
            End If
        Catch ex As Exception
            Debug.WriteLine("RendrePagesPdfEnImages : " & ex.Message)
        Finally
            Try
                If outDir <> "" AndAlso IO.Directory.Exists(outDir) Then IO.Directory.Delete(outDir, True)
            Catch
            End Try
        End Try
        Return pages
    End Function

    ''' <summary>Indique si le texte extrait est significatif (PDF natif) ou s'il s'agit
    ''' d'un scan (peu ou pas de couche texte) à traiter par OCR vision.</summary>
    Public Function EstTexteSignificatif(texte As String) As Boolean
        If String.IsNullOrWhiteSpace(texte) Then Return False
        Dim nbAlpha As Integer = texte.Count(Function(c) Char.IsLetter(c))
        Return nbAlpha >= SEUIL_TEXTE_NATIF
    End Function

#End Region

#Region "Analyse IA du CV"

    ''' <summary>Prompt d'extraction structurée d'un CV (texte ou vision). Si {PHOTO_RULE}
    ''' est renseigné (mode vision), le JSON comporte en plus la zone de la photo.</summary>
    Private ReadOnly PROMPT_BASE As String =
        "Tu lis le contenu d'un CV (curriculum vitae). Extrais les informations du candidat et réponds UNIQUEMENT avec un objet JSON (sans commentaire, sans markdown, sans balises) avec exactement ces clés :" & vbCrLf &
        "{""nom"":"""",""prenom"":"""",""civilite"":""Mr|Mme|Melle"",""sexe"":""H|F"",""date_naissance"":""JJ/MM/AAAA"",""lieu_naissance"":"""",""nationalite"":"""",""adresse"":"""",""ville"":"""",""code_postal"":"""",""pays"":"""",""gsm"":"""",""fixe"":"""",""mail"":"""",""cin"":"""",""titre"":"""",""poste_recherche"":"""",""situation_familiale"":""C|M|D|V"",""profil_resume"":"""",""formations"":[{""annee"":""2018"",""diplome"":"""",""etablissement"":"""",""niveau"":""""}],""experiences"":[{""date_debut"":""MM/AAAA"",""date_fin"":""MM/AAAA"",""poste"":"""",""entreprise"":"""",""missions"":""""}],""competences"":[""...""]{PHOTO_RULE}}" & vbCrLf &
        "Règles strictes :" & vbCrLf &
        "- REGLE D'OR : ne recopie QUE ce qui est clairement indiqué dans le CV. N'invente, ne déduis, ne complète JAMAIS une valeur. Toute valeur inconnue = chaîne vide." & vbCrLf &
        "- nom / prenom : nom de famille et prénom du candidat (en-tête du CV), pas ceux d'un référent." & vbCrLf &
        "- civilite : Mr si homme, Mme ou Melle si femme ; uniquement si elle est explicite ou évidente (prénom usuel), sinon vide." & vbCrLf &
        "- sexe : H ou F (même règle), sinon vide." & vbCrLf &
        "- date_naissance / lieu_naissance / cin / situation_familiale : uniquement si explicitement indiqués (C = célibataire, M = marié(e), D = divorcé(e), V = veuf(ve))." & vbCrLf &
        "- nationalite : telle qu'écrite (ex. Marocaine, Française). adresse : adresse postale telle qu'écrite ; ville : ville de résidence ; pays : pays de résidence ; code_postal si présent." & vbCrLf &
        "- gsm : téléphone portable ; fixe : téléphone fixe ; mail : adresse e-mail." & vbCrLf &
        "- titre : titre / headline du CV (ex. 'Ingénieur DevOps Senior') ; poste_recherche : poste visé s'il est indiqué." & vbCrLf &
        "- profil_resume : paragraphe de présentation / 'à propos' s'il existe (500 caractères max), sinon vide." & vbCrLf &
        "- formations : diplômes et formations, du plus récent au plus ancien (annee = année d'obtention sur 4 chiffres ; diplome = intitulé exact ; etablissement = école / université ; niveau = niveau type 'Bac+5' s'il est identifiable, sinon vide)." & vbCrLf &
        "- experiences : expériences professionnelles, de la plus récente à la plus ancienne (dates MM/AAAA ou JJ/MM/AAAA si précisées ; date_fin = '' si poste en cours ; poste = intitulé du poste ; entreprise = société ; missions = principales missions en une ligne)." & vbCrLf &
        "- competences : liste PLATE des compétences et skills du candidat (techniques ET transverses : gestion de projet, langues étrangères avec niveau, outils, méthodes...), termes COURTS de 1 à 4 mots chacun (ex. 'Gestion de projet', 'SQL Server', 'Management d'équipe', 'Anglais courant'). Jamais de phrases. 30 maximum."

    Private Const PHOTO_RULE_VISION As String =
        ",""photo_box"":[0,0,0,0]}" & vbCrLf &
        "- photo_box : coordonnées [x0, y0, x1, y1] de la PHOTO D'IDENTITÉ du candidat si le CV en comporte une (en pourcentage 0-100 de la largeur/hauteur de la 1ère page, sans inclure le reste du document). [0,0,0,0] s'il n'y a pas de photo."

    ''' <summary>Analyse complète d'un fichier CV : extraction (texte natif ou OCR vision),
    ''' structuration par le LLM, puis extraction de la photo d'identité.
    ''' log reçoit les étapes pour l'affichage utilisateur.</summary>
    Public Async Function AnalyserCVAsync(cfg As Ai_ChatClient, filePath As String, log As System.Text.StringBuilder) As Task(Of CvImportData)
        Dim data As New CvImportData()
        Dim ext As String = IO.Path.GetExtension(filePath).ToLowerInvariant()
        Dim estImage As Boolean = {".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff"}.Contains(ext)

        ' ---------- 1) Contenu : texte natif ou images ----------
        Dim texte As String = ""
        Dim images As New List(Of Bitmap)
        If estImage Then
            images.Add(New Bitmap(filePath))
        Else
            texte = Await Task.Run(Function() ExtraireTexteFichier(filePath))
            If Not EstTexteSignificatif(texte) Then
                If ext = ".pdf" Then
                    log.AppendLine("PDF sans couche texte (scan) : bascule sur l'OCR par IA multimodale...")
                    images = Await Task.Run(Function() RendrePagesPdfEnImages(filePath, MAX_PAGES_VISION))
                    texte = ""
                End If
            End If
        End If

        ' ---------- 2) Structuration par le LLM ----------
        Dim jsonBrut As String = ""
        Dim photoBox As Double() = Nothing
        If texte <> "" Then
            data.ModeExtraction = "Texte"
            log.AppendLine("Texte extrait du document (" & texte.Length & " caractères) : analyse par l'IA...")
            jsonBrut = Await cfg.EnvoyerChatAsync(New List(Of AiChatMessage) From {
                New AiChatMessage("user", PROMPT_BASE.Replace("{PHOTO_RULE}", "") & vbCrLf & vbCrLf & "CONTENU DU CV :" & vbCrLf & Tronquer(texte, 30000))})
        ElseIf images.Count > 0 Then
            data.ModeExtraction = "Vision (OCR IA)"
            log.AppendLine("Analyse OCR du document par l'IA multimodale (" & cfg.Provider & " / " & cfg.Modele & ")...")
            jsonBrut = Await cfg.EnvoyerVisionAsync(PROMPT_BASE.Replace("{PHOTO_RULE}", PHOTO_RULE_VISION), images.Cast(Of Image).ToList())
        Else
            log.AppendLine("Aucun contenu exploitable n'a pu être extrait de ce fichier.")
            Return data
        End If

        Dim raw As JObject = ExtraireJson(jsonBrut)
        If raw Is Nothing Then
            log.AppendLine("Réponse de l'IA inexploitable : aucune donnée structurée.")
            Return data
        End If
        RemplirDepuisJson(data, raw)
        log.AppendLine("Données du candidat extraites : " & data.Prenom & " " & data.Nom)

        ' ---------- 3) Photo d'identité ----------
        Try
            If data.ModeExtraction = "Vision (OCR IA)" Then
                photoBox = LirePhotoBox(raw)
                If photoBox IsNot Nothing AndAlso images.Count > 0 Then
                    data.Photo = CropperPhotoBox(images(0), photoBox)
                    If data.Photo IsNot Nothing Then log.AppendLine("Photo extraite via la zone identifiée par l'IA.")
                End If
                ' Même logique que RH_Agent : à défaut de la zone lue par l'IA, détection de visage
                If data.Photo Is Nothing AndAlso images.Count > 0 Then
                    data.Photo = Await Task.Run(Function() ExtrairePhotoVisage(images(0)))
                    If data.Photo IsNot Nothing Then log.AppendLine("Photo extraite par détection de visage (logique fiche agent).")
                End If
            Else
                ' PDF/DOCX texte : 1) zone lue par l'IA sur la page rendue ; 2) détection de
                ' visage OpenCV (même logique que RH_Agent / Scan_Piece_Identite) ;
                ' 3) images embarquées du document (best effort).
                Dim pageImages As List(Of Bitmap) = Nothing
                If ext = ".pdf" Then
                    pageImages = Await Task.Run(Function() RendrePagesPdfEnImages(filePath, 1))
                End If
                If pageImages IsNot Nothing AndAlso pageImages.Count > 0 Then
                    Try
                        Dim repPhoto As String = Await cfg.EnvoyerVisionAsync(
                            "Cette image est la 1ère page d'un CV. Si une PHOTO D'IDENTITÉ du candidat y figure, réponds UNIQUEMENT avec un objet JSON : {""photo_box"":[x0,y0,x1,y1]} (coordonnées en pourcentage 0-100 de la largeur/hauteur de l'image, sans inclure le reste du document). Sinon réponds {""photo_box"":[0,0,0,0]}.",
                            pageImages.Cast(Of Image).ToList())
                        photoBox = LirePhotoBox(ExtraireJson(repPhoto))
                        If photoBox IsNot Nothing Then
                            data.Photo = CropperPhotoBox(pageImages(0), photoBox)
                            If data.Photo IsNot Nothing Then log.AppendLine("Photo extraite via la zone identifiée par l'IA.")
                        End If
                    Catch exv As Exception
                        log.AppendLine("Lecture de la photo par l'IA impossible (modèle non multimodal ?) : détection de visage classique.")
                    End Try
                    If data.Photo Is Nothing Then
                        data.Photo = Await Task.Run(Function() ExtrairePhotoVisage(pageImages(0)))
                        If data.Photo IsNot Nothing Then log.AppendLine("Photo extraite par détection de visage (logique fiche agent).")
                    End If
                    For Each pg As Bitmap In pageImages : pg.Dispose() : Next
                End If
                If data.Photo Is Nothing Then
                    data.Photo = ExtraireImageEmbarquee(filePath)
                    If data.Photo IsNot Nothing Then log.AppendLine("Photo récupérée dans les images du document.")
                End If
            End If
        Catch exp As Exception
            log.AppendLine("Extraction de la photo impossible : " & exp.Message)
        Finally
            For Each img As Bitmap In images : img.Dispose() : Next
        End Try
        Return data
    End Function

    Private Function Tronquer(s As String, nb As Integer) As String
        If s Is Nothing OrElse s.Length <= nb Then Return s
        Return s.Substring(0, nb)
    End Function

    ''' <summary>Extrait le premier bloc JSON {...} d'une réponse LLM (miroir extract_json
    ''' de Scan_Piece_Identite.py) et le parse ; Nothing si inexploitable.</summary>
    Private Function ExtraireJson(txt As String) As JObject
        If String.IsNullOrWhiteSpace(txt) Then Return Nothing
        Dim m As Match = Regex.Match(txt, "\{.*\}", RegexOptions.Singleline)
        If Not m.Success Then Return Nothing
        Try
            Return JObject.Parse(m.Value)
        Catch
            Return Nothing
        End Try
    End Function

    ''' <summary>Normalise une clé JSON (minuscules, lettres uniquement) pour retrouver les
    ''' champs malgré les variantes inventées par le LLM (miroir norm_key).</summary>
    Private Function NormKey(k As String) As String
        Return Regex.Replace(k.ToLowerInvariant(), "[^a-z]", "")
    End Function

    Private Function LireChamp(raw As JObject, ParamArray cles() As String) As String
        For Each cle In cles
            For Each prop In raw.Properties()
                If NormKey(prop.Name) = cle Then
                    Dim v As String = If(prop.Value?.ToString(), "").Trim()
                    If v <> "" Then Return v
                End If
            Next
        Next
        Return ""
    End Function

    ''' <summary>Mappe le JSON de l'IA vers CvImportData (clés tolérantes aux variantes).</summary>
    Private Sub RemplirDepuisJson(data As CvImportData, raw As JObject)
        With data
            .Nom = LireChamp(raw, "nom", "name", "surname", "lastname", "nomdefamille")
            .Prenom = LireChamp(raw, "prenom", "firstname", "givenname", "givennames")
            .Civilite = LireChamp(raw, "civilite", "civility", "title", "titrehonorifique")
            .Sexe = LireChamp(raw, "sexe", "sex", "gender", "genre")
            .Dat_Naissance = ParserDateFr(LireChamp(raw, "datenaissance", "birthdate", "datedenaissance"))
            .Lieu_Naissance = LireChamp(raw, "lieunaissance", "placeofbirth", "lieudenaissance")
            .Nationalite = LireChamp(raw, "nationalite", "nationality")
            .Adresse = LireChamp(raw, "adresse", "address")
            .Ville = LireChamp(raw, "ville", "city", "localite")
            .CodePostal = LireChamp(raw, "codepostal", "postalcode", "zipcode", "cp")
            .Pays = LireChamp(raw, "pays", "country")
            .Gsm = LireChamp(raw, "gsm", "mobile", "portable", "telephone", "tel", "phone")
            .Fixe = LireChamp(raw, "fixe", "landline", "telephonefixe", "telfixe")
            .Mail = LireChamp(raw, "mail", "email", "emailaddress", "courriel")
            .CIN = LireChamp(raw, "cin", "numerocin", "numcin", "identitenationale", "carteidentite")
            .Titre = LireChamp(raw, "titre", "headline", "intitule", "titreprofil", "profil")
            .Poste_Recherche = LireChamp(raw, "posterecherche", "postevise", "objectif", "objectifprofessionnel")
            .Situation = LireChamp(raw, "situationfamiliale", "situation", "etatcivil", "maritalstatus")
            .Profil_Resume = LireChamp(raw, "profilresume", "resume", "apropos", "presentation", "summary", "profile")

            Dim formations As JArray = TryCast(raw("formations"), JArray)
            If formations IsNot Nothing Then
                For Each f As JObject In formations.OfType(Of JObject)()
                    Dim an As String = Regex.Match(LireChamp(f, "annee", "year", "anneeobtention", "dateobtention"), "(19|20)\d{2}").Value
                    .Formations.Add(New CvFormation With {
                        .Annee = an,
                        .Diplome = LireChamp(f, "diplome", "degree", "diploma", "intitule"),
                        .Etablissement = LireChamp(f, "etablissement", "ecole", "universite", "school", "university"),
                        .Niveau = LireChamp(f, "niveau", "level"),
                        .Commentaire = LireChamp(f, "commentaire", "mention", "comment")})
                Next
            End If
            Dim experiences As JArray = TryCast(raw("experiences"), JArray)
            If experiences IsNot Nothing Then
                For Each e As JObject In experiences.OfType(Of JObject)()
                    .Experiences.Add(New CvExperience With {
                        .Dat_Deb = ParserDateExperience(LireChamp(e, "datedebut", "startdate", "debut", "from")),
                        .Dat_Fin = ParserDateExperience(LireChamp(e, "datefin", "enddate", "fin", "to")),
                        .Poste = LireChamp(e, "poste", "position", "jobtitle", "intituleposte", "fonction"),
                        .Etablissement = LireChamp(e, "entreprise", "company", "societe", "employeur", "etablissement"),
                        .Commentaire = LireChamp(e, "missions", "mission", "description", "taches", "commentaire")})
                Next
            End If
            Dim competences As JArray = TryCast(raw("competences"), JArray)
            If competences IsNot Nothing Then
                For Each c As JToken In competences
                    Dim s As String = c.ToString().Trim()
                    If s <> "" AndAlso s.Length <= 60 AndAlso Not .Competences.Any(Function(x) Normaliser(x) = Normaliser(s)) Then
                        .Competences.Add(s)
                    End If
                Next
            End If
        End With
    End Sub

    ''' <summary>Zone photo retournée par l'IA ([x0,y0,x1,y1] en %) si elle est valide
    ''' (portrait, taille raisonnable — mêmes gardes-fous que Scan_Piece_Identite.py).</summary>
    Private Function LirePhotoBox(raw As JObject) As Double()
        If raw Is Nothing Then Return Nothing
        Dim arr As JArray = TryCast(raw("photo_box"), JArray)
        If arr Is Nothing OrElse arr.Count <> 4 Then Return Nothing
        Try
            Dim vals As Double() = arr.Select(Function(v) v.ToObject(Of Double)()).ToArray()
            Dim bw As Double = vals(2) - vals(0)
            Dim bh As Double = vals(3) - vals(1)
            If bw > 2 AndAlso bh > 2 AndAlso bh >= bw * 0.9 AndAlso bw <= 60 Then Return vals
        Catch
        End Try
        Return Nothing
    End Function

    ''' <summary>Croppe la photo dans l'image source selon la zone (en %) puis l'adapte au
    ''' cadre photo de la fiche (redimensionnement proportionnel sur fond clair).</summary>
    Private Function CropperPhotoBox(src As Bitmap, box As Double()) As Bitmap
        Try
            Dim W As Integer = src.Width, H As Integer = src.Height
            Dim x0 As Integer = Math.Max(0, CInt(W * box(0) / 100))
            Dim y0 As Integer = Math.Max(0, CInt(H * box(1) / 100))
            Dim x1 As Integer = Math.Min(W, CInt(W * box(2) / 100))
            Dim y1 As Integer = Math.Min(H, CInt(H * box(3) / 100))
            Dim cw As Integer = x1 - x0, ch As Integer = y1 - y0
            If cw < 30 OrElse ch < 30 Then Return Nothing
            ' marge portrait (comme extract_face_photo : au-dessus de la tête et sur les côtés)
            Dim mx As Integer = CInt(cw * 0.15)
            Dim my As Integer = CInt(ch * 0.12)
            x0 = Math.Max(0, x0 - mx) : x1 = Math.Min(W, x1 + mx)
            y0 = Math.Max(0, y0 - my) : y1 = Math.Min(H, y1 + my)
            Dim crop As New Bitmap(x1 - x0, y1 - y0)
            Using g As Graphics = Graphics.FromImage(crop)
                g.DrawImage(src, New Rectangle(0, 0, crop.Width, crop.Height), New Rectangle(x0, y0, x1 - x0, y1 - y0), GraphicsUnit.Pixel)
            End Using
            Return CadrerPhoto(crop)
        Catch
            Return Nothing
        End Try
    End Function

    ''' <summary>Adapte le portrait au cadre photo de la fiche candidat (333 x 252 px,
    ''' affichage CenterImage) : redimensionnement proportionnel puis centrage sur fond clair
    ''' (miroir de adapt_photo_frame de Scan_Piece_Identite.py).</summary>
    Public Function CadrerPhoto(img As Bitmap, Optional fw As Integer = 333, Optional fh As Integer = 252) As Bitmap
        If img Is Nothing Then Return Nothing
        Dim ratio As Double = Math.Min(fw / img.Width, fh / img.Height)
        Dim nw As Integer = Math.Max(1, CInt(img.Width * ratio))
        Dim nh As Integer = Math.Max(1, CInt(img.Height * ratio))
        Dim cadre As New Bitmap(fw, fh)
        Using g As Graphics = Graphics.FromImage(cadre)
            g.Clear(Color.FromArgb(245, 245, 245))
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, (fw - nw) \ 2, (fh - nh) \ 2, nw, nh)
        End Using
        Return cadre
    End Function

    ''' <summary>Détection de visage — même logique que la fiche agent (Scan_Piece_Identite /
    ''' extract_face_photo) : OpenCV du Python embarqué (installé à la volée), cascades
    ''' haar + lbp avec variante de contraste CLAHE, filtres de plausibilité (taille 3-50 %
    ''' de la largeur, ratio 0.6-1.7), visage le plus grand retenu, cadrage portrait avec
    ''' marges (0.40w latéral, 0.55h au-dessus, 0.50h en dessous) puis adapté au cadre photo.
    ''' Retourne Nothing si aucun visage plausible n'est détecté.</summary>
    Private Function ExtrairePhotoVisage(src As Bitmap) As Bitmap
        Dim tmpDir As String = ""
        Try
            Dim rnd As New Random
            tmpDir = IO.Path.Combine(My.Application.Info.DirectoryPath, "TMP\cv_face_" & rnd.Next(12000, 1569221)).Replace("\", "/")
            IO.Directory.CreateDirectory(tmpDir)
            Dim srcPath As String = tmpDir & "/src.png"
            Dim outPath As String = tmpDir & "/face.png"
            src.Save(srcPath, Imaging.ImageFormat.Png)
            Dim py As String = "
import sys, subprocess
def import_cv2():
    try:
        import cv2
        return cv2
    except ImportError:
        print('Installation de OpenCV (detection de visage)...', flush=True)
        subprocess.run([sys.executable, '-m', 'pip', 'install', 'opencv-python<5'], capture_output=True, timeout=600)
        import cv2
        return cv2
cv2 = import_cv2()
img = cv2.imread(""" & Chr(34) & srcPath & Chr(34) & """)
if img is None:
    print('IMAGE_ILLISIBLE', flush=True)
    raise SystemExit
def detect_faces(img):
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    variantes = [gray]
    try:
        clahe = cv2.createCLAHE(clipLimit=2.0, tileGridSize=(8, 8))
        variantes.append(clahe.apply(gray))
    except Exception:
        pass
    W = gray.shape[1]
    trouve = []
    for cas in ('haarcascade_frontalface_default.xml', 'haarcascade_frontalface_alt2.xml',
                'lbpcascade_frontalface_improved.xml', 'lbpcascade_frontalface.xml'):
        cascade = cv2.CascadeClassifier(cv2.data.haarcascades + cas)
        if cascade.empty():
            continue
        for g in variantes:
            faces = cascade.detectMultiScale(g, scaleFactor=1.08, minNeighbors=4, minSize=(25, 25))
            for (x, y, w, h) in faces:
                rw = w / W
                aspect = h / max(w, 1)
                if 0.03 <= rw <= 0.50 and 0.6 <= aspect <= 1.7:
                    trouve.append((x, y, w, h))
        if trouve:
            break
    return trouve
faces = detect_faces(img)
if not faces:
    print('VISAGE_ABSENT', flush=True)
    raise SystemExit
H, W = img.shape[:2]
(x, y, w, h) = max(faces, key=lambda f: f[2] * f[3])
mx = int(w * 0.40)
my_haut = int(h * 0.55)
my_bas = int(h * 0.50)
x0, y0 = max(0, x - mx), max(0, y - my_haut)
x1, y1 = min(W, x + w + mx), min(H, y + h + my_bas)
crop = img[y0:y1, x0:x1]
if crop.size:
    cv2.imwrite(""" & Chr(34) & outPath & Chr(34) & """, crop)
    print('VISAGE_TROUVE', flush=True)
else:
    print('VISAGE_ABSENT', flush=True)
"
            Dim sb As New System.Text.StringBuilder
            executerCodePython(py, sb, False)
            Debug.WriteLine("ExtrairePhotoVisage : " & sb.ToString())
            If IO.File.Exists(outPath) Then
                Dim crop As Bitmap = Nothing
                Using fs As New IO.FileStream(outPath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                    crop = New Bitmap(Image.FromStream(fs))
                End Using
                Dim cadre As Bitmap = CadrerPhoto(crop)
                crop.Dispose()
                Return cadre
            End If
            Return Nothing
        Catch ex As Exception
            Debug.WriteLine("ExtrairePhotoVisage : " & ex.Message)
            Return Nothing
        Finally
            Try
                If tmpDir <> "" AndAlso IO.Directory.Exists(tmpDir) Then IO.Directory.Delete(tmpDir, True)
            Catch
            End Try
        End Try
    End Function

    ''' <summary>Fallback photo : extrait la 1ère image embarquée « portrait » plausible du
    ''' document (images JPEG du PDF via iTextSharp, médias du DOCX via le conteneur zip).</summary>
    Private Function ExtraireImageEmbarquee(filePath As String) As Bitmap
        Try
            Dim ext As String = IO.Path.GetExtension(filePath).ToLowerInvariant()
            Dim candidates As New List(Of Bitmap)
            If ext = ".pdf" Then
                Using reader As New PdfReader(filePath)
                    Dim nbPages As Integer = Math.Min(2, reader.NumberOfPages)
                    For p As Integer = 1 To nbPages
                        Dim pg As PdfDictionary = reader.GetPageN(p)
                        Dim res As PdfDictionary = TryCast(PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES)), PdfDictionary)
                        If res Is Nothing Then Continue For
                        Dim xobj As PdfDictionary = TryCast(PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT)), PdfDictionary)
                        If xobj Is Nothing Then Continue For
                        For Each name As PdfName In xobj.Keys
                            Try
                                Dim dic As PdfDictionary = TryCast(PdfReader.GetPdfObject(xobj.Get(name)), PdfDictionary)
                                If dic Is Nothing OrElse Not PdfName.IMAGE.Equals(dic.GetAsName(PdfName.SUBTYPE)) Then Continue For
                                Dim stream As PRStream = TryCast(dic, PRStream)
                                If stream Is Nothing Then Continue For
                                ' DCTDecode = JPEG : directement lisible ; autres filtres ignorés
                                Dim filter As PdfObject = PdfReader.GetPdfObject(dic.Get(PdfName.FILTER))
                                If filter Is Nothing OrElse filter.ToString() <> PdfName.DCTDECODE.ToString() Then Continue For
                                Dim bytes As Byte() = PdfReader.GetStreamBytesRaw(stream)
                                Using ms As New MemoryStream(bytes)
                                    candidates.Add(New Bitmap(Image.FromStream(ms)))
                                End Using
                            Catch
                            End Try
                        Next
                    Next
                End Using
            ElseIf ext = ".docx" Then
                Using zip As ZipArchive = ZipFile.OpenRead(filePath)
                    For Each entry As ZipArchiveEntry In zip.Entries
                        If Not entry.FullName.StartsWith("word/media/", StringComparison.OrdinalIgnoreCase) Then Continue For
                        Try
                            Using s As Stream = entry.Open()
                                Using ms As New MemoryStream()
                                    s.CopyTo(ms)
                                    ms.Position = 0
                                    candidates.Add(New Bitmap(Image.FromStream(ms)))
                                End Using
                            End Using
                        Catch
                        End Try
                    Next
                End Using
            End If
            ' portrait plausible le plus grand (une photo d'identité est verticale)
            Dim best As Bitmap = candidates.
                Where(Function(b) b.Height >= b.Width AndAlso b.Width >= 60 AndAlso b.Height >= 60 AndAlso b.Height <= b.Width * 2).
                OrderByDescending(Function(b) b.Width * b.Height).FirstOrDefault()
            For Each b As Bitmap In candidates
                If b IsNot best Then b.Dispose()
            Next
            Return CadrerPhoto(best)
        Catch ex As Exception
            Debug.WriteLine("ExtraireImageEmbarquee : " & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

#Region "Correspondances référentiels RHP"

    ''' <summary>Majuscules sans accents ni espaces superflus (miroir norm_txt du script
    ''' Python) : base de toutes les correspondances (villes, pays, compétences GPEC).</summary>
    Public Function Normaliser(s As String) As String
        If String.IsNullOrWhiteSpace(s) Then Return ""
        Dim decomp As String = s.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder()
        For Each c As Char In decomp
            If CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark Then
                If Char.IsLetterOrDigit(c) Then sb.Append(Char.ToUpperInvariant(c)) Else sb.Append(" "c)
            End If
        Next
        Return Regex.Replace(sb.ToString(), "\s+", " ").Trim()
    End Function

    ''' <summary>Date 'JJ/MM/AAAA' (ou ISO) normalisée pour les champs date de l'écran ;
    ''' "" si non parsable.</summary>
    Public Function ParserDateFr(txt As String) As String
        If String.IsNullOrWhiteSpace(txt) Then Return ""
        txt = txt.Trim()
        Dim m As Match = Regex.Match(txt, "(\d{1,2})\D(\d{1,2})\D((?:19|20)\d{2})")
        If m.Success Then
            Dim d As DateTime
            If DateTime.TryParseExact($"{m.Groups(1).Value.PadLeft(2, "0"c)}/{m.Groups(2).Value.PadLeft(2, "0"c)}/{m.Groups(3).Value}",
                                      "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, d) Then
                Return d.ToString("dd/MM/yyyy")
            End If
        End If
        m = Regex.Match(txt, "((?:19|20)\d{2})-(\d{1,2})-(\d{1,2})")
        If m.Success Then
            Return $"{m.Groups(3).Value.PadLeft(2, "0"c)}/{m.Groups(2).Value.PadLeft(2, "0"c)}/{m.Groups(1).Value}"
        End If
        Return ""
    End Function

    ''' <summary>Date d'expérience : accepte en outre 'MM/AAAA' (complété au 1er du mois) et
    ''' 'AAAA' seul (1er janvier) ; retourne 'JJ/MM/AAAA' ou "".</summary>
    Public Function ParserDateExperience(txt As String) As String
        Dim d As String = ParserDateFr(txt)
        If d <> "" Then Return d
        If String.IsNullOrWhiteSpace(txt) Then Return ""
        Dim m As Match = Regex.Match(txt.Trim(), "^(\d{1,2})\D((?:19|20)\d{2})$")
        If m.Success Then Return "01/" & m.Groups(1).Value.PadLeft(2, "0"c) & "/" & m.Groups(2).Value
        m = Regex.Match(txt.Trim(), "^((?:19|20)\d{2})$")
        If m.Success Then Return "01/01/" & m.Groups(1).Value
        Return ""
    End Function

    ''' <summary>Cod_Pays (Param_Pays) correspondant à un libellé/code pays ; "" sinon
    ''' (miroir find_cod_pays : exact sur libellé, code ISO ou code, puis préfixe).</summary>
    Public Function TrouverCodPays(txt As String) As String
        Dim t As String = Normaliser(txt)
        If t = "" Then Return ""
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT Cod_Pays, Pays, Cod_ISO FROM Param_Pays")
        For Each r As DataRow In Tbl.Rows
            Dim p As String = Normaliser(IsNull(r("Pays"), ""))
            Dim i As String = Normaliser(IsNull(r("Cod_ISO"), ""))
            Dim c As String = Normaliser(IsNull(r("Cod_Pays"), ""))
            If t = p OrElse (i <> "" AndAlso t = i) OrElse t = c Then Return IsNull(r("Cod_Pays"), "")
        Next
        For Each r As DataRow In Tbl.Rows
            Dim p As String = Normaliser(IsNull(r("Pays"), ""))
            If p <> "" AndAlso (t.StartsWith(p) OrElse p.StartsWith(t)) Then Return IsNull(r("Cod_Pays"), "")
        Next
        Return ""
    End Function

    ''' <summary>Cod_Ville (Param_Ville) correspondant au texte dans le pays donné
    ''' (miroir find_cod_ville : exact > préfixe > ville contenue > texte contenu).</summary>
    Public Function TrouverCodVille(texte As String, codPays As String) As String
        Dim t As String = Normaliser(texte)
        If t = "" Then Return ""
        Dim where As String = If(codPays <> "", " WHERE Cod_Pays='" & codPays.Replace("'", "''") & "'", "")
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT Cod_Ville, Ville FROM Param_Ville" & where)
        If Tbl.Rows.Count = 0 AndAlso where <> "" Then
            Tbl = DATA_READER_GRD("SELECT Cod_Ville, Ville FROM Param_Ville")
        End If
        Dim best As String = "" : Dim bestScore As Integer = -1
        For Each r As DataRow In Tbl.Rows
            Dim v As String = Normaliser(IsNull(r("Ville"), ""))
            If v = "" Then Continue For
            Dim score As Integer = -1
            If t = v Then
                score = 1000
            ElseIf v.StartsWith(t) OrElse t.StartsWith(v) Then
                score = 500 + v.Length
            ElseIf t.Contains(v) Then
                score = 400 + v.Length
            ElseIf v.Contains(t) Then
                score = 100 + v.Length
            End If
            If score > bestScore Then
                best = IsNull(r("Cod_Ville"), "") : bestScore = score
            End If
        Next
        Return best
    End Function

    ''' <summary>Valeur d'une rubrique Param_Rubriques (Civilite, Situation, Nationalite...)
    ''' correspondant à un texte libre : exact sur Valeur/Membre, puis membre contenant le
    ''' texte (ou l'inverse). "" si introuvable.</summary>
    Public Function TrouverValeurRubrique(nomControle As String, txt As String) As String
        Dim t As String = Normaliser(txt)
        If t = "" Then Return ""
        Dim Tbl As DataTable = DATA_READER_GRD($"SELECT Valeur, Membre FROM Param_Rubriques WHERE Nom_Controle='{nomControle.Replace("'", "''")}' GROUP BY Valeur, Membre, Rang ORDER BY ISNULL(Rang, Membre)")
        For Each r As DataRow In Tbl.Rows
            If t = Normaliser(IsNull(r("Valeur"), "")) OrElse t = Normaliser(IsNull(r("Membre"), "")) Then
                Return IsNull(r("Valeur"), "")
            End If
        Next
        For Each r As DataRow In Tbl.Rows
            Dim m As String = Normaliser(IsNull(r("Membre"), ""))
            If m <> "" AndAlso t.Length >= 3 AndAlso (m.Contains(t) OrElse t.Contains(m)) Then
                Return IsNull(r("Valeur"), "")
            End If
        Next
        Return ""
    End Function

    ''' <summary>Civilite ('Mr'/'Mme'/'Melle') depuis la civilité ou le sexe extraits du CV.</summary>
    Public Function TrouverCivilite(civilite As String, sexe As String) As String
        Dim v As String = TrouverValeurRubrique("Civilite_Combo", civilite)
        If v <> "" Then Return v
        Select Case Normaliser(sexe)
            Case "H", "M", "HOMME", "MASCULIN" : Return "Mr"
            Case "F", "FEMME", "FEMININ" : Return "Mme"
        End Select
        Return ""
    End Function

    ''' <summary>Situation familiale (rubrique 'Situation') depuis le code C/M/D/V ou le
    ''' libellé extrait du CV ('Marié(e)', 'Célibataire'...).</summary>
    Public Function TrouverSituation(txt As String) As String
        Dim t As String = Normaliser(txt)
        If t = "" Then Return ""
        Select Case t
            Case "CELIBATAIRE", "SINGLE" : Return TrouverValeurRubrique("Situation", "Célibataire")
            Case "MARIE", "MARIEE", "MARIE E", "MARIED" : Return TrouverValeurRubrique("Situation", "Marié(e)")
            Case "DIVORCE", "DIVORCEE", "DIVORCED" : Return TrouverValeurRubrique("Situation", "Divorcé(e)")
            Case "VEUF", "VEUVE", "WIDOWED" : Return TrouverValeurRubrique("Situation", "Veuf(ve)")
            Case Else : Return TrouverValeurRubrique("Situation", txt)
        End Select
    End Function

    ''' <summary>Niveau d'études (rubrique 'Niveau' : B0, B-1, B2...B5, Mst, MBA, Dr, PhD)
    ''' depuis un texte libre ('Bac+5', 'Master', 'Doctorat'...).</summary>
    Public Function TrouverNiveau(txt As String) As String
        Dim t As String = Normaliser(txt)
        If t = "" Then Return ""
        Dim v As String = TrouverValeurRubrique("Niveau", txt)
        If v <> "" Then Return v
        Dim m As Match = Regex.Match(t, "BAC\s*\+?\s*(\d)")
        If m.Success Then v = TrouverValeurRubrique("Niveau", "B" & m.Groups(1).Value)
        If v = "" AndAlso m.Success Then v = TrouverValeurRubrique("Niveau", "Back +" & m.Groups(1).Value)
        If v = "" Then
            If t.Contains("DOCTOR") OrElse t.Contains("PHD") Then
                v = TrouverValeurRubrique("Niveau", "Doctorat")
            ElseIf t.Contains("MASTER") OrElse t.Contains("MASTERE") OrElse t.Contains("MST") Then
                v = TrouverValeurRubrique("Niveau", "Mastère")
            ElseIf t.Contains("MBA") Then
                v = TrouverValeurRubrique("Niveau", "MBA")
            ElseIf t.Contains("LICENCE") Then
                v = TrouverValeurRubrique("Niveau", "Bac+3")
            End If
        End If
        Return v
    End Function

#End Region

#Region "Correspondance des compétences avec la GPEC"

    ''' <summary>Référentiel GPEC complet de la société (domaines et compétences).</summary>
    Public Function ChargerReferentielGPEC() As DataTable
        Return DATA_READER_GRD("SELECT Domaines_Competence, Lib_Domaines_Competence, ISNULL(Parent,'') AS Parent FROM GPEC_Domaines_Competence WHERE id_Societe=" & Societe.id_Societe)
    End Function

    ''' <summary>Associe chaque compétence du CV au référentiel GPEC de la société :
    ''' correspondance exacte normalisée sur le libellé, puis préfixe (>= 4 caractères) en
    ''' privilégiant le libellé le plus proche en longueur. Retourne les codes GPEC matchés ;
    ''' nonMatchees reçoit les compétences du CV sans équivalent.</summary>
    Public Function MatcherCompetencesGPEC(competences As List(Of String), gpec As DataTable, ByRef nonMatchees As List(Of String)) As List(Of String)
        Dim matches As New List(Of String)
        nonMatchees = New List(Of String)
        Dim index As New Dictionary(Of String, String)   ' libellé normalisé -> code
        For Each r As DataRow In gpec.Rows
            Dim n As String = Normaliser(IsNull(r("Lib_Domaines_Competence"), ""))
            Dim c As String = IsNull(r("Domaines_Competence"), "")
            If n <> "" AndAlso c <> "" AndAlso Not index.ContainsKey(n) Then index.Add(n, c)
        Next
        For Each skill In competences
            Dim n As String = Normaliser(skill)
            If n = "" Then Continue For
            Dim code As String = ""
            If index.ContainsKey(n) Then
                code = index(n)
            Else
                ' correspondance souple : préfixe commun >= 4 caractères, libellé le plus court gagnant
                Dim candidats = index.Where(Function(kv) (kv.Key.StartsWith(n) OrElse n.StartsWith(kv.Key)) AndAlso Math.Min(kv.Key.Length, n.Length) >= 4).
                                      OrderBy(Function(kv) Math.Abs(kv.Key.Length - n.Length)).ToList()
                If candidats.Count > 0 Then code = candidats(0).Value
            End If
            If code <> "" Then
                If Not matches.Contains(code) Then matches.Add(code)
            Else
                nonMatchees.Add(skill)
            End If
        Next
        Return matches
    End Function

    ''' <summary>Crée une compétence dans le référentiel GPEC de la société sous le domaine
    ''' parent choisi (même convention de code que l'écran GPEC_Domaines_Competence :
    ''' identifiant numérique aléatoire) et retourne le code créé.</summary>
    Public Function CreerCompetenceGPEC(libelle As String, parentCode As String) As String
        Dim rnd As New Random
        Dim code As String = ""
        Do
            code = rnd.Next(195323540, 846522870).ToString()
        Loop While CnExecuting("SELECT COUNT(*) FROM GPEC_Domaines_Competence WHERE Domaines_Competence='" & code & "' AND id_Societe=" & Societe.id_Societe).Fields(0).Value > 0
        Dim rang As Integer = CInt(IsNull(CnExecuting("SELECT ISNULL(MAX(Rang),0)+1 FROM GPEC_Domaines_Competence WHERE ISNULL(Parent,'')='" & parentCode.Replace("'", "''") & "' AND id_Societe=" & Societe.id_Societe).Fields(0).Value, 1))
        CnExecuting($"INSERT INTO GPEC_Domaines_Competence (Domaines_Competence, id_Societe, Lib_Domaines_Competence, Parent, Rang, Dat_Crea, Created_By, Dat_Modif, Modified_By)
                      VALUES ('{code}', {Societe.id_Societe}, '{libelle.Replace("'", "''")}', '{parentCode.Replace("'", "''")}', {rang}, GETDATE(), '{theUser.Login.Replace("'", "''")}', GETDATE(), '{theUser.Login.Replace("'", "''")}')")
        Return code
    End Function

#End Region

End Module
