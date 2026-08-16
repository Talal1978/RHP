Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

''' <summary>
''' Module SP_ - Import / Export JSON de la configuration d'une page du Designer
''' (SP_Page_Designer).
'''
''' PRINCIPE FONDAMENTAL
'''   L'export JSON représente l'état complet de la configuration fonctionnelle
'''   et technique d'une page, HORS HABILITATIONS (Controle_Designer_Droit et l'option
'''   'Acces_Personnalise' ne sont jamais écrites ni modifiées par l'import).
'''   L'import reconstruit cet état dans les CONTRÔLES ET GRILLES du Designer
'''   (Tbl_Tables / Tbl_Colonnes / Tbl_Champs / Tbl_Validations / Tbl_Sources) ;
'''   la sauvegarde en base reste assurée exclusivement par le mécanisme
'''   standard du Designer (Saving) — aucun INSERT/UPDATE/DELETE de
'''   configuration n'est exécuté au chargement du fichier.
'''
''' FORMAT (version 1.0) — exemple d'enveloppe :
''' {
'''   "format": "RHP_PAGE_DESIGNER",
'''   "version": "1.0",
'''   "exportedAt": "2026-08-15T14:30:00",
'''   "exportedBy": "LOGIN",
'''   "rhpVersion": "1.0.0.0",
'''   "page":       { "Cod_Page": "...", "Cod_Document": "...", ... },
'''   "sqlStructure": [ { "Cod_Table": "ENT", ..., "Colonnes": [ {...} ] } ],
'''   "businessSources": [ { "Cod_Source": "...", ... } ],   -- sources UTILISÉES par la page
'''   "components":      [ { "Cod_Champ": "...", ... } ],    -- champs (entête + colonnes de grilles)
'''   "validations":     [ { "Cod_Validation": "...", ... } ],
'''   "metadata": { "habilitations": "EXCLUES", compteurs... }
''' }
'''   - Les clés métier sont les NOMS TECHNIQUES du Designer (Cod_Page, Cod_Table,
'''     Cod_Champ...) : stables entre environnements, jamais de clés SQL internes.
'''   - Les booléens sont de vrais booléens json (true/false) ; l'import accepte
'''     aussi les chaînes "true"/"false" (convention historique RHP).
'''   - Les grilles de détail sont les tables de rôle DET de "sqlStructure"
'''     (leurs options d'édition = comportement ; leurs colonnes de grille sont
'''     les composants rattachés à la table) ; "behaviors" de la maquette est
'''     porté par les options Allow_* / Regle_Suppression des tables et Act_* /
'''     Workflow / GED de la page.
'''
''' ÉVOLUTIVITÉ : la version est contrôlée à l'import (majeure différente =
''' blocage ; mineure supérieure = avertissement, propriétés inconnues ignorées
''' par la désérialisation). Point d'extension de migration : MigrerSiNecessaire.
''' </summary>

#Region "DTO (indépendants de l'interface)"

''' <summary>Enveloppe du fichier d'export (format RHP_PAGE_DESIGNER).</summary>
Public Class SP_Page_Package
    <JsonProperty("format")> Public Property Format As String = ""
    <JsonProperty("version")> Public Property Version As String = ""
    <JsonProperty("exportedAt")> Public Property ExportedAt As String = ""
    <JsonProperty("exportedBy")> Public Property ExportedBy As String = ""
    <JsonProperty("rhpVersion")> Public Property RhpVersion As String = ""
    <JsonProperty("page")> Public Property Page As New SP_Page_EnteteDto
    <JsonProperty("sqlStructure")> Public Property SqlStructure As New List(Of SP_Page_TableDto)
    <JsonProperty("businessSources")> Public Property BusinessSources As New List(Of SP_Page_SourceDto)
    <JsonProperty("components")> Public Property Components As New List(Of SP_Page_ChampDto)
    <JsonProperty("validations")> Public Property Validations As New List(Of SP_Page_ValidationDto)
    <JsonProperty("metadata")> Public Property Metadata As New SP_Page_MetadataDto
End Class

''' <summary>Entête de la page (miroir des contrôles d'entête du Designer).
''' Statut_Page et Table_Ent sont exportés à titre indicatif (traçabilité) :
''' le statut n'est jamais réimporté (les transitions passent par Publier /
''' Désactiver) et le nom physique est recalculé depuis Cod_Document.</summary>
Public Class SP_Page_EnteteDto
    Public Property Cod_Page As String = ""
    Public Property Cod_Document As String = ""
    Public Property Nom_Page As String = ""
    Public Property Menu_Parent As String = ""
    Public Property Rang As Integer = 99
    Public Property Icone As String = ""
    Public Property Statut_Page As String = ""          ' indicatif (jamais réimporté)
    Public Property Table_Ent As String = ""            ' indicatif (recalculé à l'import)
    Public Property Acces_Personnalise As Boolean = False   ' indicatif : conservé en mise à jour, appliqué en création
    Public Property Workflow_Actif As Boolean = False
    Public Property Cod_Modele_Edition As String = ""
    Public Property GED_Actif As Boolean = False
    Public Property GED_Obligatoire As Boolean = False
    Public Property Act_Enregistrer As Boolean = True
    Public Property Act_Soumettre As Boolean = True
    Public Property Act_Imprimer As Boolean = False
    Public Property Act_Exporter As Boolean = False
End Class

''' <summary>Table de la page (ENT ou détail = grille). Une détail avec
''' Source_Metier renseignée est une GRILLE VIRTUELLE (aucune table physique).</summary>
Public Class SP_Page_TableDto
    Public Property Cod_Table As String = ""
    Public Property Nom_Physique As String = ""   ' indicatif : recalculé à l'import (dérivé du type document)
    Public Property Role_Table As String = "DET"
    Public Property Libelle As String = ""
    Public Property Rang As Integer = 1
    Public Property Allow_Add As Boolean = True
    Public Property Allow_Edit As Boolean = True
    Public Property Allow_Delete As Boolean = True
    Public Property Allow_Duplicate As Boolean = False
    Public Property Tri_Defaut As String = ""
    Public Property Regle_Suppression As String = "CASCADE"
    Public Property Source_Metier As String = ""
    Public Property Source_Mapping As String = ""
    <JsonProperty("colonnes")> Public Property Colonnes As New List(Of SP_Page_ColonneDto)
End Class

''' <summary>Colonne physique déclarée (structure SQL générée par le Designer).</summary>
Public Class SP_Page_ColonneDto
    Public Property Nom_Colonne As String = ""
    Public Property Libelle As String = ""
    Public Property Typ_Sql As String = "nvarchar"
    Public Property Longueur As Integer?
    Public Property Precision_Sql As Integer?
    Public Property Echelle_Sql As Integer?
    Public Property Nullable As Boolean = True
    Public Property Valeur_Defaut As String = ""
    Public Property estUnique As Boolean = False
    Public Property estIndexe As Boolean = False
    Public Property Rang As Integer = 1
End Class

''' <summary>Champ de la page (entête ou colonne d'une grille de détail).</summary>
Public Class SP_Page_ChampDto
    Public Property Cod_Champ As String = ""
    Public Property Cod_Table As String = ""       ' '' = champ d'affichage non rattaché
    Public Property Nom_Colonne As String = ""     ' '' = non stocké (calculé / affiché)
    Public Property Libelle As String = ""
    Public Property Typ_Controle As String = "TEXT"
    Public Property Rang As Integer = 1
    Public Property Ligne As Integer?
    Public Property Colonne As Integer?
    Public Property Largeur As Integer?
    Public Property Valeur_Defaut As String = ""
    Public Property Obligatoire As Boolean = False
    Public Property Etat As String = "S"
    Public Property Rubrique As String = ""
    Public Property Num_Zoom As String = ""
    Public Property Source_Metier As String = ""
    Public Property Formule As String = ""
    Public Property Persiste As Boolean = False
    Public Property Format_Affichage As String = ""
    Public Property Decimales As Integer?
    Public Property Visible_Grille As Boolean = True
    Public Property Rang_Grille As Integer = 1
    Public Property Largeur_Colonne As Integer?
    Public Property estCritere As Boolean = False
    Public Property Rang_Critere As Integer?
    Public Property Aide As String = ""
End Class

''' <summary>Source métier utilisée par la page (le catalogue Controle_Designer_Source est
''' global : à l'enregistrement, les sources sont fusionnées par Cod_Source —
''' upsert, jamais de suppression).</summary>
Public Class SP_Page_SourceDto
    Public Property Cod_Source As String = ""
    Public Property Libelle As String = ""
    Public Property Typ_Source As String = "SQL"
    Public Property Code_Sql As String = ""
    Public Property Parametres As String = ""      ' json [{Nom, Typ, Obligatoire}]
    Public Property Typ_Retour As String = "SCALAIRE"
    Public Property Cod_Profile As String = ""
    Public Property Actif As Boolean = True
End Class

''' <summary>Validation déclarative (comportement de la page).</summary>
Public Class SP_Page_ValidationDto
    Public Property Cod_Validation As String = ""
    Public Property Portee As String = "CHAMP"
    Public Property Cod_Table As String = ""
    Public Property Cod_Champ As String = ""
    Public Property Typ_Regle As String = "REQUIRED"
    Public Property Parametres As String = ""
    Public Property Condition_Regle As String = ""
    Public Property Message As String = ""
    Public Property Niveau As String = "B"
    Public Property Rang As Integer = 1
    Public Property Moment As String = "SAVE"
    Public Property Actif As Boolean = True
End Class

''' <summary>Métadonnées de traçabilité ; 'habilitations' rappelle explicitement
''' que les droits ne font pas partie du fichier.</summary>
Public Class SP_Page_MetadataDto
    <JsonProperty("habilitations")> Public Property Habilitations As String = "EXCLUES"
    <JsonProperty("nbTables")> Public Property NbTables As Integer = 0
    <JsonProperty("nbColonnes")> Public Property NbColonnes As Integer = 0
    <JsonProperty("nbChamps")> Public Property NbChamps As Integer = 0
    <JsonProperty("nbSources")> Public Property NbSources As Integer = 0
    <JsonProperty("nbValidations")> Public Property NbValidations As Integer = 0
End Class

#End Region

#Region "Export"

''' <summary>Construction du package d'export depuis l'état du Designer
''' (DataTables des grilles) ou depuis la base (référence de comparaison pour
''' la prévisualisation d'une mise à jour). Aucune habilitation n'est lue.</summary>
Public Class SP_Page_Json_Export

    ''' <summary>Sérialise le package en json indenté (les propriétés nulles sont omises).</summary>
    Public Shared Function Serialiser(pkg As SP_Page_Package) As String
        Dim st As New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore}
        Return JsonConvert.SerializeObject(pkg, Formatting.Indented, st)
    End Function

    ''' <summary>Construit le package depuis les grilles du Designer (état affiché,
    ''' y compris les saisies en cours validées — miroir de 'Dupliquer').
    ''' entete : DTO rempli par l'écran depuis ses contrôles.</summary>
    Public Shared Function ConstruirePackage(entete As SP_Page_EnteteDto,
                                             tblTables As DataTable, tblColonnes As DataTable,
                                             tblChamps As DataTable, tblValidations As DataTable,
                                             tblSources As DataTable) As SP_Page_Package
        Dim pkg As New SP_Page_Package With {
            .Format = SP_Page_Json_Import.FORMAT_ATTENDU,
            .Version = SP_Page_Json_Import.VERSION_COURANTE,
            .ExportedAt = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
            .ExportedBy = theUser.Login,
            .RhpVersion = My.Application.Info.Version.ToString(),
            .Page = entete
        }
        '---------------- Tables + colonnes (structure SQL logique) ----------------
        Dim tables As DataRow() = tblTables.Select("", "Rang")
        For Each rt As DataRow In tables
            Dim t As New SP_Page_TableDto With {
                .Cod_Table = IsNull(rt("Cod_Table"), "").Trim,
                .Nom_Physique = IsNull(rt("Nom_Physique"), "").Trim,
                .Role_Table = IsNull(rt("Role_Table"), "DET").Trim,
                .Libelle = IsNull(rt("Libelle"), ""),
                .Rang = LireEntier(rt, "Rang", 1),
                .Allow_Add = LireBool(rt, "Allow_Add", True),
                .Allow_Edit = LireBool(rt, "Allow_Edit", True),
                .Allow_Delete = LireBool(rt, "Allow_Delete", True),
                .Allow_Duplicate = LireBool(rt, "Allow_Duplicate", False),
                .Tri_Defaut = IsNull(rt("Tri_Defaut"), ""),
                .Regle_Suppression = IsNull(rt("Regle_Suppression"), "CASCADE").Trim,
                .Source_Metier = IsNull(rt("Source_Metier"), "").Trim,
                .Source_Mapping = IsNull(rt("Source_Mapping"), "").Trim
            }
            If t.Cod_Table = "" Then Continue For
            Dim cols As DataRow() = tblColonnes.Select("Cod_Table='" & t.Cod_Table.Replace("'", "''") & "'", "Rang")
            For Each rc As DataRow In cols
                t.Colonnes.Add(ColonneDepuisLigne(rc))
            Next
            pkg.SqlStructure.Add(t)
        Next
        '---------------- Champs (entête + colonnes de grilles) ----------------
        For Each rc As DataRow In tblChamps.Select("", "Cod_Table, Rang")
            Dim c As New SP_Page_ChampDto With {
                .Cod_Champ = IsNull(rc("Cod_Champ"), "").Trim,
                .Cod_Table = IsNull(rc("Cod_Table"), "").Trim,
                .Nom_Colonne = IsNull(rc("Nom_Colonne"), "").Trim,
                .Libelle = IsNull(rc("Libelle"), ""),
                .Typ_Controle = IsNull(rc("Typ_Controle"), "TEXT").Trim,
                .Rang = LireEntier(rc, "Rang", 1),
                .Ligne = LireEntierNul(rc, "Ligne"),
                .Colonne = LireEntierNul(rc, "Colonne"),
                .Largeur = LireEntierNul(rc, "Largeur"),
                .Valeur_Defaut = IsNull(rc("Valeur_Defaut"), ""),
                .Obligatoire = LireBool(rc, "Obligatoire", False),
                .Etat = IsNull(rc("Etat"), "S").Trim,
                .Rubrique = IsNull(rc("Rubrique"), "").Trim,
                .Num_Zoom = IsNull(rc("Num_Zoom"), "").Trim,
                .Source_Metier = IsNull(rc("Source_Metier"), "").Trim,
                .Formule = IsNull(rc("Formule"), ""),
                .Persiste = LireBool(rc, "Persiste", False),
                .Format_Affichage = IsNull(rc("Format_Affichage"), "").Trim,
                .Decimales = LireEntierNul(rc, "Decimales"),
                .Visible_Grille = LireBool(rc, "Visible_Grille", True),
                .Rang_Grille = LireEntier(rc, "Rang_Grille", 1),
                .Largeur_Colonne = LireEntierNul(rc, "Largeur_Colonne"),
                .estCritere = LireBool(rc, "estCritere", False),
                .Rang_Critere = LireEntierNul(rc, "Rang_Critere"),
                .Aide = IsNull(rc("Aide"), "")
            }
            If c.Cod_Champ = "" Then Continue For
            pkg.Components.Add(c)
        Next
        '---------------- Validations (comportement) ----------------
        For Each rv As DataRow In tblValidations.Select("", "Rang")
            Dim v As New SP_Page_ValidationDto With {
                .Cod_Validation = IsNull(rv("Cod_Validation"), "").Trim,
                .Portee = IsNull(rv("Portee"), "CHAMP").Trim,
                .Cod_Table = IsNull(rv("Cod_Table"), "").Trim,
                .Cod_Champ = IsNull(rv("Cod_Champ"), "").Trim,
                .Typ_Regle = IsNull(rv("Typ_Regle"), "REQUIRED").Trim,
                .Parametres = IsNull(rv("Parametres"), ""),
                .Condition_Regle = IsNull(rv("Condition_Regle"), ""),
                .Message = IsNull(rv("Message"), ""),
                .Niveau = IsNull(rv("Niveau"), "B").Trim,
                .Rang = LireEntier(rv, "Rang", 1),
                .Moment = IsNull(rv("Moment"), "SAVE").Trim,
                .Actif = LireBool(rv, "Actif", True)
            }
            If v.Cod_Validation = "" Then Continue For
            pkg.Validations.Add(v)
        Next
        '---------------- Sources métier UTILISÉES par la page ----------------
        ' (le catalogue est global : seules les sources référencées par une table
        '  virtuelle ou un champ sont exportées — miroir des dépendances réelles)
        Dim utilisees As New List(Of String)
        For Each t As SP_Page_TableDto In pkg.SqlStructure
            If t.Source_Metier <> "" AndAlso Not utilisees.Contains(t.Source_Metier) Then utilisees.Add(t.Source_Metier)
        Next
        For Each c As SP_Page_ChampDto In pkg.Components
            If c.Source_Metier <> "" AndAlso Not utilisees.Contains(c.Source_Metier) Then utilisees.Add(c.Source_Metier)
        Next
        For Each cs As String In utilisees
            Dim src As SP_Page_SourceDto = SourceDepuisGrille(tblSources, cs)
            If src Is Nothing Then src = SourceDepuisBase(cs)
            If src IsNot Nothing Then pkg.BusinessSources.Add(src)
        Next
        '---------------- Métadonnées ----------------
        Dim nbCol As Integer = 0
        For Each t As SP_Page_TableDto In pkg.SqlStructure
            nbCol += t.Colonnes.Count
        Next
        pkg.Metadata.NbTables = pkg.SqlStructure.Count
        pkg.Metadata.NbColonnes = nbCol
        pkg.Metadata.NbChamps = pkg.Components.Count
        pkg.Metadata.NbSources = pkg.BusinessSources.Count
        pkg.Metadata.NbValidations = pkg.Validations.Count
        Return pkg
    End Function

    ''' <summary>Construit le package depuis la BASE (référence de comparaison pour
    ''' la prévisualisation d'une mise à jour : le diff porte sur l'état enregistré,
    ''' pas sur d'éventuelles saisies en cours à l'écran). Nothing si la page
    ''' n'existe pas.</summary>
    Public Shared Function ConstruireDepuisBase(codPage As String) As SP_Page_Package
        Dim f As String = " where Cod_Page='" & codPage.Replace("'", "''") & "'"
        Dim tblPage As DataTable = DATA_READER_GRD("select * from Controle_Designer" & f)
        If tblPage.Rows.Count = 0 Then Return Nothing
        Dim rp As DataRow = tblPage.Rows(0)
        Dim entete As New SP_Page_EnteteDto With {
            .Cod_Page = IsNull(rp("Cod_Page"), "").Trim,
            .Cod_Document = IsNull(rp("Cod_Document"), "").Trim,
            .Nom_Page = IsNull(rp("Nom_Page"), ""),
            .Menu_Parent = IsNull(rp("Menu_Parent"), "").Trim,
            .Rang = LireEntier(rp, "Rang", 99),
            .Icone = IsNull(rp("Icone"), "").Trim,
            .Statut_Page = IsNull(rp("Statut_Page"), "").Trim,
            .Table_Ent = IsNull(rp("Table_Ent"), "").Trim,
            .Acces_Personnalise = (IsNull(rp("Acces_Personnalise"), "true") = "true"),
            .Workflow_Actif = (IsNull(rp("Workflow_Actif"), "false") = "true"),
            .Cod_Modele_Edition = IsNull(rp("Cod_Modele_Edition"), "").Trim,
            .GED_Actif = (IsNull(rp("GED_Actif"), "false") = "true"),
            .GED_Obligatoire = (IsNull(rp("GED_Obligatoire"), "false") = "true"),
            .Act_Enregistrer = (IsNull(rp("Act_Enregistrer"), "true") = "true"),
            .Act_Soumettre = (IsNull(rp("Act_Soumettre"), "true") = "true"),
            .Act_Imprimer = (IsNull(rp("Act_Imprimer"), "false") = "true"),
            .Act_Exporter = (IsNull(rp("Act_Exporter"), "false") = "true")
        }
        Dim tblTables As DataTable = DATA_READER_GRD("select Cod_Table, Nom_Physique, Role_Table, Libelle, Rang, Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Source_Metier, Source_Mapping from Controle_Designer_Table" & f)
        Dim tblColonnes As DataTable = DATA_READER_GRD("select Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur, Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Rang from Controle_Designer_Colonne" & f & " and isnull(Technique,'false')='false'")
        Dim tblChamps As DataTable = DATA_READER_GRD("select Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle, Rang, Ligne, Colonne, Largeur, Valeur_Defaut, Obligatoire, Etat, Rubrique, Num_Zoom, Source_Metier, Formule, Persiste, Format_Affichage, Decimales, Visible_Grille, Rang_Grille, Largeur_Colonne, estCritere, Rang_Critere, Aide from Controle_Designer_Champ" & f)
        Dim tblValidations As DataTable = DATA_READER_GRD("select Cod_Validation, Portee, Cod_Table, Cod_Champ, Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif from Controle_Designer_Validation" & f)
        ' Sources utilisées : résolues depuis la base (la grille est vide ici)
        Dim tblSources As DataTable = DATA_READER_GRD("select Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif from Controle_Designer_Source where 1=0")
        Return ConstruirePackage(entete, tblTables, tblColonnes, tblChamps, tblValidations, tblSources)
    End Function

    '---------------- Lectures de lignes (tolérantes) ----------------

    Private Shared Function ColonneDepuisLigne(rc As DataRow) As SP_Page_ColonneDto
        Return New SP_Page_ColonneDto With {
            .Nom_Colonne = IsNull(rc("Nom_Colonne"), "").Trim,
            .Libelle = IsNull(rc("Libelle"), ""),
            .Typ_Sql = LCase(IsNull(rc("Typ_Sql"), "nvarchar").Trim),
            .Longueur = LireEntierNul(rc, "Longueur"),
            .Precision_Sql = LireEntierNul(rc, "Precision_Sql"),
            .Echelle_Sql = LireEntierNul(rc, "Echelle_Sql"),
            .Nullable = LireBool(rc, "Nullable", True),
            .Valeur_Defaut = IsNull(rc("Valeur_Defaut"), ""),
            .estUnique = LireBool(rc, "estUnique", False),
            .estIndexe = LireBool(rc, "estIndexe", False),
            .Rang = LireEntier(rc, "Rang", 1)
        }
    End Function

    ''' <summary>Source lue dans la grille du catalogue (DataTable du Designer).</summary>
    Private Shared Function SourceDepuisGrille(tblSources As DataTable, codSource As String) As SP_Page_SourceDto
        If tblSources Is Nothing Then Return Nothing
        For Each r As DataRow In tblSources.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            If Not IsNull(r("Cod_Source"), "").Trim.Equals(codSource, StringComparison.OrdinalIgnoreCase) Then Continue For
            Return SourceDepuisLigne(r)
        Next
        Return Nothing
    End Function

    ''' <summary>Source lue en base (repli si absente de la grille).</summary>
    Private Shared Function SourceDepuisBase(codSource As String) As SP_Page_SourceDto
        Dim tbl As DataTable = DATA_READER_GRD("select Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif from Controle_Designer_Source where Cod_Source='" & codSource.Replace("'", "''") & "'")
        If tbl.Rows.Count = 0 Then Return Nothing
        Return SourceDepuisLigne(tbl.Rows(0))
    End Function

    Private Shared Function SourceDepuisLigne(r As DataRow) As SP_Page_SourceDto
        Return New SP_Page_SourceDto With {
            .Cod_Source = IsNull(r("Cod_Source"), "").Trim,
            .Libelle = IsNull(r("Libelle"), ""),
            .Typ_Source = IsNull(r("Typ_Source"), "SQL").Trim,
            .Code_Sql = IsNull(r("Code_Sql"), ""),
            .Parametres = IsNull(r("Parametres"), ""),
            .Typ_Retour = IsNull(r("Typ_Retour"), "SCALAIRE").Trim,
            .Cod_Profile = IsNull(r("Cod_Profile"), "").Trim,
            .Actif = LireBool(r, "Actif", True)
        }
    End Function

    Friend Shared Function LireBool(r As DataRow, col As String, defaut As Boolean) As Boolean
        If Not r.Table.Columns.Contains(col) OrElse IsDBNull(r(col)) Then Return defaut
        Return IsNull(r(col), If(defaut, "true", "false")).Trim.Equals("true", StringComparison.OrdinalIgnoreCase)
    End Function

    Friend Shared Function LireEntier(r As DataRow, col As String, defaut As Integer) As Integer
        Dim v As Integer? = LireEntierNul(r, col)
        Return If(v.HasValue, v.Value, defaut)
    End Function

    Friend Shared Function LireEntierNul(r As DataRow, col As String) As Integer?
        If Not r.Table.Columns.Contains(col) OrElse IsDBNull(r(col)) Then Return Nothing
        Dim n As Integer
        If Integer.TryParse(IsNull(r(col), "").Trim, n) Then Return n
        Return Nothing
    End Function

End Class

#End Region

#Region "Import (analyse + validation + alimentation des grilles)"

''' <summary>Résultat de l'analyse d'un fichier d'import : package reconstruit,
''' erreurs BLOQUANTES (le fichier n'est pas chargé) et avertissements
''' (dépendances à résoudre par l'utilisateur avant l'enregistrement).</summary>
Public Class SP_Page_ImportResultat
    Public Property Package As SP_Page_Package = Nothing
    Public ReadOnly Property Erreurs As New List(Of String)
    Public ReadOnly Property Avertissements As New List(Of String)
    ''' <summary>True si une erreur bloquante interdit le chargement dans le Designer.</summary>
    Public ReadOnly Property Bloquant As Boolean
        Get
            Return Erreurs.Count > 0
        End Get
    End Property
End Class

''' <summary>Service d'import : parsing, contrôle du format et de la version,
''' validation structurelle complète (références, domaines, doublons) et
''' résolution des dépendances de la base cible. L'alimentation des grilles du
''' Designer (RemplirTables) n'est jamais appelée en présence d'erreur
''' bloquante : l'état de l'écran reste alors strictement inchangé (atomicité).</summary>
Public Class SP_Page_Json_Import

    Public Const FORMAT_ATTENDU As String = "RHP_PAGE_DESIGNER"
    Public Const VERSION_COURANTE As String = "1.0"
    ''' <summary>Version MAJEURE supportée par cet importeur (une majeure
    ''' supérieure est bloquante ; une mineure supérieure est lue en mode
    ''' tolérant : les propriétés inconnues sont ignorées).</summary>
    Private Const VERSION_MAJEUR_SUPPORTEE As Integer = 1

    Private Shared Function SqlV(v As Object) As String
        Return "'" & IsNull(v, "").ToString().Replace("'", "''") & "'"
    End Function

    ''' <summary>SELECT d'existence sur la connexion globale (recordset fermé).</summary>
    Private Shared Function ExisteEnBase(sql As String) As Boolean
        Dim rs As ADODB.Recordset = CnExecuting(sql)
        Dim ok As Boolean = False
        If rs IsNot Nothing AndAlso rs.State = 1 Then
            ok = Not rs.EOF AndAlso CInt(IsNull(rs.Fields(0).Value, 0)) > 0
            rs.Close()
        End If
        Return ok
    End Function

    ''' <summary>Contrôle de longueur : miroir des tailles de colonnes SQL des
    ''' tables de métadonnées (001_SP_Designer_Metadata.sql). Sans lui, une valeur
    ''' trop longue passait la validation puis faisait échouer le chargement des
    ''' grilles sur le MaxLength du DataTable (erreur brute « Impossible de
    ''' définir la colonne … » — ex. Num_Zoom nvarchar(10)).</summary>
    Private Shared Sub VerifierLongueur(E As List(Of String), quoi As String, val As String, max As Integer)
        If val IsNot Nothing AndAlso val.Trim().Length > max Then
            E.Add(quoi & " : " & val.Trim().Length & " caractères, au-delà de la limite de " & max & " (taille de la colonne en base).")
        End If
    End Sub

    ''' <summary>Point d'extension de migration de format (1.0 -> 1.1...) :
    ''' transforme l'objet json d'une version antérieure avant désérialisation.
    ''' Aucune migration n'existe à ce jour (seule version : 1.0).</summary>
    Private Shared Function MigrerSiNecessaire(jobj As JObject, version As String) As JObject
        Return jobj
    End Function

    ''' <summary>
    ''' Analyse complète du fichier : parsing, signature, version, structure,
    ''' domaines, doublons, références internes et résolution des dépendances
    ''' de la base cible (par code fonctionnel / nom technique, jamais par id).
    ''' Ne touche JAMAIS l'écran ni la base en écriture.
    ''' </summary>
    Public Shared Function Analyser(json As String) As SP_Page_ImportResultat
        Dim res As New SP_Page_ImportResultat
        '---------------- 1. Parsing json ----------------
        Dim jobj As JObject = Nothing
        Try
            jobj = TryCast(JToken.Parse(json), JObject)
        Catch ex As Exception
            res.Erreurs.Add("Le fichier n'est pas un json valide : " & ex.Message)
            Return res
        End Try
        If jobj Is Nothing Then
            res.Erreurs.Add("Le fichier n'est pas un export de page RHP (objet json attendu).")
            Return res
        End If
        '---------------- 2. Signature / version ----------------
        Dim fmt As String = If(jobj("format") Is Nothing, "", jobj("format").ToString())
        If Not fmt.Equals(FORMAT_ATTENDU, StringComparison.OrdinalIgnoreCase) Then
            res.Erreurs.Add("Ce fichier n'est pas un export du Designer de pages RHP (format '" & fmt & "' — '" & FORMAT_ATTENDU & "' attendu).")
            Return res
        End If
        Dim ver As String = If(jobj("version") Is Nothing, "", jobj("version").ToString().Trim)
        Dim mVer As Match = Regex.Match(ver, "^(\d+)(\.(\d+))?$")
        If Not mVer.Success Then
            res.Erreurs.Add("La version du format est absente ou illisible ('" & ver & "').")
            Return res
        End If
        Dim majeur As Integer = CInt(mVer.Groups(1).Value)
        Dim mineur As Integer = If(mVer.Groups(3).Success, CInt(mVer.Groups(3).Value), 0)
        If majeur > VERSION_MAJEUR_SUPPORTEE Then
            res.Erreurs.Add("Version du format non supportée : " & ver & " (cet importeur lit les versions " & VERSION_MAJEUR_SUPPORTEE & ".x).")
            Return res
        End If
        If majeur = VERSION_MAJEUR_SUPPORTEE AndAlso mineur > CInt(Split(VERSION_COURANTE, ".")(1)) Then
            res.Avertissements.Add("Le fichier est au format " & ver & ", plus récent que la version " & VERSION_COURANTE &
                                   " de cet importeur : les éventuelles propriétés inconnues seront ignorées.")
        End If
        '---------------- 3. Désérialisation (après migration éventuelle) ----------------
        jobj = MigrerSiNecessaire(jobj, ver)
        Dim pkg As SP_Page_Package = Nothing
        Try
            ' NullValueHandling.Ignore : un "xxx": null explicite (fichier retouché
            ' à la main) n'écrase pas les valeurs par défaut des DTO (listes vides,
            ' chaînes "") — la validation travaille toujours sur des objets valides.
            Dim sz As JsonSerializer = JsonSerializer.Create(New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore})
            pkg = jobj.ToObject(Of SP_Page_Package)(sz)
        Catch ex As Exception
            res.Erreurs.Add("La structure du fichier ne correspond pas au format " & FORMAT_ATTENDU & " : " & ex.Message)
            Return res
        End Try
        If pkg Is Nothing OrElse pkg.Page Is Nothing Then
            res.Erreurs.Add("Le fichier ne contient pas de définition de page ('page' absent).")
            Return res
        End If
        ' Éléments null dans les listes (fichier retouché) : retirés avant validation
        pkg.SqlStructure.RemoveAll(Function(x) x Is Nothing)
        pkg.BusinessSources.RemoveAll(Function(x) x Is Nothing)
        pkg.Components.RemoveAll(Function(x) x Is Nothing)
        pkg.Validations.RemoveAll(Function(x) x Is Nothing)
        For Each t As SP_Page_TableDto In pkg.SqlStructure
            t.Colonnes.RemoveAll(Function(x) x Is Nothing)
        Next
        pkg.Format = fmt : pkg.Version = ver
        res.Package = pkg
        Valider(pkg, res)
        Return res
    End Function

    ''' <summary>Validation structurelle + résolution des dépendances (tous les
    ''' contrôles sont rejoués : un import validé passe les contrôles de Saving,
    ''' qui reste le dernier garde-fou à l'enregistrement).</summary>
    Private Shared Sub Valider(pkg As SP_Page_Package, res As SP_Page_ImportResultat)
        Dim E As List(Of String) = res.Erreurs
        Dim W As List(Of String) = res.Avertissements
        Dim p As SP_Page_EnteteDto = pkg.Page
        '---------------- Page ----------------
        If p.Cod_Page.Trim <> "" Then
            If Not Regex.IsMatch(p.Cod_Page.Trim, "^[A-Za-z_][A-Za-z0-9_]{2,29}$") OrElse p.Cod_Page.Trim.StartsWith("Page") Then
                E.Add("Code page invalide : '" & p.Cod_Page & "' (lettres/chiffres/_, 3 à 30 caractères, ne commence pas par 'Page').")
            End If
        End If
        If Not Regex.IsMatch(p.Cod_Document.Trim, "^[A-Za-z][A-Za-z0-9]{1,9}$") Then
            E.Add("Type document (Cod_Document) absent ou invalide : '" & p.Cod_Document & "' (2 à 10 caractères alphanumériques, commence par une lettre).")
        End If
        If p.Nom_Page.Trim = "" Then E.Add("Le nom de la page (Nom_Page) est obligatoire.")
        VerifierLongueur(E, "Nom de la page (Nom_Page)", p.Nom_Page, 60)
        VerifierLongueur(E, "Section du menu (Menu_Parent)", p.Menu_Parent, 60)
        VerifierLongueur(E, "Icône (Icone)", p.Icone, 50)
        VerifierLongueur(E, "Modèle d'édition (Cod_Modele_Edition)", p.Cod_Modele_Edition, 20)
        If p.Statut_Page.Trim <> "" AndAlso Not {"BROUILLON", "PUBLIE", "DESACTIVE", "ARCHIVE"}.Contains(p.Statut_Page.Trim) Then
            W.Add("Statut_Page '" & p.Statut_Page & "' inconnu : ignoré (le statut n'est jamais importé).")
        End If
        '---------------- Dépendances de la page (résolution par code fonctionnel) ----------------
        If p.Menu_Parent.Trim = "" Then
            W.Add("Section du menu portail (Menu_Parent) absente du fichier : à renseigner dans l'onglet 'Conception' avant l'enregistrement.")
        ElseIf Not ExisteEnBase("select count(*) from Param_Rubriques where Nom_Controle='SP_Menu_Portail' and Valeur=" & SqlV(p.Menu_Parent.Trim)) Then
            W.Add("Dépendance non résolue : la section de menu '" & p.Menu_Parent & "' n'existe pas dans cette base (rubrique SP_Menu_Portail)." & vbCrLf &
                  "   -> choisissez une section dans l'onglet 'Conception' avant l'enregistrement (l'enregistrement sera bloqué tant qu'elle est vide).")
        End If
        If p.Icone.Trim <> "" AndAlso Not ExisteEnBase("select count(*) from Param_Rubriques where Nom_Controle='SP_Menu_Icones' and Valeur=" & SqlV(p.Icone.Trim)) Then
            W.Add("Dépendance non résolue : l'icône '" & p.Icone & "' n'existe pas dans cette base (rubrique SP_Menu_Icones) : elle sera ignorée.")
        End If
        If p.Cod_Modele_Edition.Trim <> "" AndAlso Not ExisteEnBase("select count(*) from Param_Mod_Edition where Cod_Report=" & SqlV(p.Cod_Modele_Edition.Trim)) Then
            W.Add("Dépendance non résolue : le modèle d'édition '" & p.Cod_Modele_Edition & "' n'existe pas dans cette base (Param_Mod_Edition) : à corriger dans l'onglet 'Conception'.")
        End If
        '---------------- Tables ----------------
        Dim tablesVues As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim nbEnt As Integer = 0
        For Each t As SP_Page_TableDto In pkg.SqlStructure
            Dim ct As String = t.Cod_Table.Trim
            If ct = "" Then
                E.Add("Une table n'a pas de code (Cod_Table vide).")
                Continue For
            End If
            Dim v As String = ValiderIdentifiantSql(ct)
            If v <> "" Then E.Add(v)
            If Not tablesVues.Add(ct) Then E.Add("Table en doublon : '" & ct & "'.")
            If ct.Equals("ENT", StringComparison.OrdinalIgnoreCase) Then nbEnt += 1
            If t.Role_Table.Trim <> "ENT" AndAlso t.Role_Table.Trim <> "DET" Then
                E.Add("Rôle invalide ('" & t.Role_Table & "') pour la table '" & ct & "' : ENT ou DET attendu.")
            End If
            If ct.Equals("ENT", StringComparison.OrdinalIgnoreCase) AndAlso t.Role_Table.Trim <> "ENT" Then
                W.Add("Table '" & ct & "' : le rôle est forcé à ENT.")
            End If
            If t.Regle_Suppression.Trim <> "CASCADE" AndAlso t.Regle_Suppression.Trim <> "RESTRICT" Then
                E.Add("Règle de suppression invalide ('" & t.Regle_Suppression & "') pour la table '" & ct & "' : CASCADE ou RESTRICT attendu.")
            End If
            VerifierLongueur(E, "Code table", ct, 20)
            VerifierLongueur(E, "Libellé de la table '" & ct & "'", t.Libelle, 150)
            VerifierLongueur(E, "Tri par défaut de la table '" & ct & "'", t.Tri_Defaut, 200)
            '---------------- Grille virtuelle : source + mapping ----------------
            If t.Source_Metier.Trim <> "" Then
                If ct.Equals("ENT", StringComparison.OrdinalIgnoreCase) Then
                    E.Add("La table d'entête (ENT) ne peut pas être une grille virtuelle (Source_Metier renseignée).")
                Else
                    VerifierSourceVirtuelle(t, pkg, res)
                End If
            End If
        Next
        If pkg.SqlStructure.Count = 0 Then E.Add("Aucune table dans le fichier ('sqlStructure' vide).")
        If pkg.SqlStructure.Count > 0 AndAlso nbEnt <> 1 Then E.Add("Il doit y avoir exactement une table d'entête (Cod_Table = ENT) : " & nbEnt & " trouvée(s).")
        '---------------- Colonnes ----------------
        Dim colonnesTechniques As String() = {"RowId", "Num_Doc", "id_Societe", "Statut", "Dat_Crea", "Created_By", "Dat_Modif", "Modified_By", "RV"}
        Dim colonnesVues As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim colonnesParTable As New Dictionary(Of String, List(Of String))(StringComparer.OrdinalIgnoreCase)
        For Each t As SP_Page_TableDto In pkg.SqlStructure
            Dim ct As String = t.Cod_Table.Trim
            If ct = "" Then Continue For
            For Each c As SP_Page_ColonneDto In t.Colonnes
                Dim nc As String = c.Nom_Colonne.Trim
                If nc = "" Then
                    E.Add("La table '" & ct & "' contient une colonne sans nom.")
                    Continue For
                End If
                Dim v As String = ValiderIdentifiantSql(nc)
                If v <> "" Then E.Add(v)
                If colonnesTechniques.Contains(nc, StringComparer.OrdinalIgnoreCase) Then
                    E.Add("'" & ct & "." & nc & "' est une colonne technique (ajoutée automatiquement) : elle ne doit pas figurer dans le fichier.")
                End If
                If Not colonnesVues.Add(ct & "." & nc) Then E.Add("Colonne en doublon : '" & ct & "." & nc & "'.")
                If Not SP_Page_Designer.TYPES_SQL.Contains(LCase(c.Typ_Sql.Trim)) Then
                    E.Add("Type SQL invalide ('" & c.Typ_Sql & "') pour la colonne '" & ct & "." & nc & "'.")
                End If
                VerifierLongueur(E, "Nom de colonne", nc, 50)
                VerifierLongueur(E, "Libellé de la colonne '" & ct & "." & nc & "'", c.Libelle, 150)
                VerifierLongueur(E, "Valeur par défaut de la colonne '" & ct & "." & nc & "'", c.Valeur_Defaut, 200)
                If Not colonnesParTable.ContainsKey(ct) Then colonnesParTable(ct) = New List(Of String)
                If Not colonnesParTable(ct).Contains(nc) Then colonnesParTable(ct).Add(nc)
            Next
        Next
        For Each t As SP_Page_TableDto In pkg.SqlStructure
            Dim ct As String = t.Cod_Table.Trim
            If ct <> "" AndAlso tablesVues.Contains(ct) AndAlso t.Colonnes.Count = 0 Then
                E.Add("La table '" & ct & "' n'a aucune colonne déclarée.")
            End If
        Next
        '---------------- Champs ----------------
        Dim champsVus As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim colonnesAffectees As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each c As SP_Page_ChampDto In pkg.Components
            Dim cc As String = c.Cod_Champ.Trim
            If cc = "" Then
                E.Add("Un champ n'a pas de code (Cod_Champ vide).")
                Continue For
            End If
            If ValiderIdentifiantSql(cc) <> "" Then E.Add("Champ invalide : '" & cc & "'.")
            If Not champsVus.Add(cc) Then E.Add("Champ en doublon : '" & cc & "'.")
            VerifierLongueur(E, "Code champ", cc, 50)
            VerifierLongueur(E, "Libellé du champ '" & cc & "'", c.Libelle, 150)
            VerifierLongueur(E, "Valeur par défaut du champ '" & cc & "'", c.Valeur_Defaut, 200)
            VerifierLongueur(E, "Aide du champ '" & cc & "'", c.Aide, 300)
            VerifierLongueur(E, "Rubrique du champ '" & cc & "'", c.Rubrique, 60)
            VerifierLongueur(E, "N° de zoom du champ '" & cc & "'", c.Num_Zoom, 10)
            VerifierLongueur(E, "Source métier du champ '" & cc & "'", c.Source_Metier, 50)
            VerifierLongueur(E, "Format d'affichage du champ '" & cc & "'", c.Format_Affichage, 50)
            If Not SP_Page_Designer.TYPES_CONTROLE.Contains(c.Typ_Controle.Trim) Then
                E.Add("Type de contrôle invalide ('" & c.Typ_Controle & "') pour le champ '" & cc & "'.")
            End If
            Dim etat As String = c.Etat.Trim
            If etat = "" Then etat = "S"
            If Not SP_Page_Designer.ETATS.Contains(etat) Then
                E.Add("Etat invalide ('" & c.Etat & "') pour le champ '" & cc & "' (S/R/A/I attendu).")
            End If
            Dim ctCh As String = c.Cod_Table.Trim
            If ctCh <> "" AndAlso Not tablesVues.Contains(ctCh) Then
                E.Add("Le champ '" & cc & "' référence une table absente du fichier : '" & ctCh & "'.")
            End If
            Dim ncCh As String = c.Nom_Colonne.Trim
            If ncCh <> "" Then
                Dim ctEff As String = If(ctCh = "", "ENT", ctCh)
                Dim existePhysique As Boolean = colonnesParTable.ContainsKey(ctEff) AndAlso colonnesParTable(ctEff).Contains(ncCh)
                If Not existePhysique AndAlso tablesVues.Contains(ctEff) Then
                    existePhysique = SP_Page_Designer.ColonnesTechniquesTable(ctEff).Contains(ncCh, StringComparer.OrdinalIgnoreCase)
                End If
                If Not existePhysique Then
                    E.Add("Le champ '" & cc & "' est affecté à la colonne '" & ctEff & "." & ncCh & "', absente de la structure exportée.")
                ElseIf Not colonnesAffectees.Add(ctEff & "." & ncCh) Then
                    E.Add("Colonne affectée en double : '" & ctEff & "." & ncCh & "' est utilisée par plusieurs champs (dont '" & cc & "').")
                End If
            Else
                ' Miroir du verrou de Saving : un champ sans colonne ne peut produire
                ' une valeur que s'il est CALCULE / SOURCE (non persisté), GED, ou un
                ' affichage d'une colonne TECHNIQUE de l'entête — Cod_Champ = nom
                ' technique EXACT, casse comprise (convention « N° demande » :
                ' Cod_Champ = 'Num_Doc'). Tout autre champ sans colonne ne
                ' s'afficherait jamais (clé absente du contexte portail).
                Dim typCh As String = c.Typ_Controle.Trim
                Dim ctEff As String = If(ctCh = "", "ENT", ctCh)
                Dim affTechnique As Boolean = ctEff = "ENT" AndAlso
                                              SP_Page_Designer.ColonnesTechniquesTable("ENT").Contains(cc)
                If typCh <> "CALCULE" AndAlso typCh <> "SOURCE" AndAlso typCh <> "GED" AndAlso Not affTechnique Then
                    E.Add("Le champ '" & cc & "' n'est rattaché à aucune colonne : il ne s'affichera jamais. Seuls peuvent être sans colonne : les champs calculés ou source (non persistés), les champs GED, et l'affichage d'une colonne technique de l'entête (Cod_Champ = nom technique exact, ex. 'Num_Doc' pour le N° de demande).")
                End If
            End If
            ' Convention « N° de document » (miroir de Saving) : le champ
            ' Cod_Champ='Num_Doc' (casse exacte) est obligatoire sur l'entête —
            ' présence contrôlée après la boucle. Il ne peut être lié qu'à la
            ' colonne technique Num_Doc (ou à aucune — forme canonique), et
            ' réciproquement.
            If cc.Equals("Num_Doc", StringComparison.Ordinal) Then
                If ncCh <> "" AndAlso Not ncCh.Equals("Num_Doc", StringComparison.OrdinalIgnoreCase) Then
                    E.Add("Le champ 'Num_Doc' ne peut être lié qu'à la colonne technique Num_Doc (ou à aucune colonne — forme canonique).")
                End If
                If c.Etat.Trim = "S" Then
                    E.Add("Le champ 'Num_Doc' est toujours en lecture seule (Etat 'R' ou 'A') : sa valeur est attribuée par le serveur.")
                End If
            End If
            If ncCh.Equals("Num_Doc", StringComparison.OrdinalIgnoreCase) AndAlso Not cc.Equals("Num_Doc", StringComparison.Ordinal) Then
                E.Add("La colonne technique Num_Doc ne peut porter que le champ 'Num_Doc' (convention « N° de document ») : renommez le champ '" & cc & "'.")
            End If
            If c.Typ_Controle.Trim = "ZOOM" Then
                If c.Num_Zoom.Trim = "" Then
                    E.Add("Le champ '" & cc & "' est un Zoom : le numéro de zoom est obligatoire.")
                ElseIf Not ExisteEnBase("select count(*) from Controle_Def_Zoom where Num_Zoom=" & SqlV(c.Num_Zoom.Trim)) Then
                    W.Add("Dépendance non résolue : le zoom '" & c.Num_Zoom & "' du champ '" & cc & "' n'existe pas dans cette base (Controle_Def_Zoom) : à corriger avant publication.")
                End If
            End If
            If c.Typ_Controle.Trim = "RUBRIQUE" Then
                If c.Rubrique.Trim = "" Then
                    E.Add("Le champ '" & cc & "' est une rubrique : le nom de rubrique est obligatoire.")
                ElseIf Not ExisteEnBase("select count(*) from Param_Rubriques where Nom_Controle=" & SqlV(c.Rubrique.Trim)) Then
                    W.Add("Dépendance non résolue : la rubrique '" & c.Rubrique & "' du champ '" & cc & "' n'existe pas dans cette base (Param_Rubriques) : à corriger avant publication.")
                End If
            End If
            If c.Typ_Controle.Trim = "SOURCE" AndAlso c.Source_Metier.Trim = "" Then
                E.Add("Le champ '" & cc & "' est de type SOURCE : la source métier est obligatoire.")
            End If
            If c.Source_Metier.Trim <> "" AndAlso Not SourceResolvable(pkg, c.Source_Metier.Trim) Then
                E.Add("Le champ '" & cc & "' référence la source métier '" & c.Source_Metier & "', absente du fichier ET de cette base : la dépendance est indispensable.")
            End If
        Next
        ' Le champ d'affichage du N° de document est obligatoire par convention,
        ' au même titre que la table ENT (miroir de Saving) : Cod_Champ='Num_Doc'
        ' (casse exacte) sur l'entête, sans colonne physique ou lié à la colonne
        ' technique Num_Doc.
        If Not pkg.Components.Any(Function(c) c.Cod_Champ.Trim.Equals("Num_Doc", StringComparison.Ordinal) AndAlso
                                              (c.Cod_Table.Trim = "" OrElse c.Cod_Table.Trim = "ENT")) Then
            E.Add("Le champ 'Num_Doc' est obligatoire (convention des pages SP_, au même titre que la table ENT) : champ d'entête TEXT en lecture seule, sans colonne physique, pour l'affichage du N° de document attribué par le serveur.")
        End If
        '---------------- Validations ----------------
        Dim validationsVues As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each v As SP_Page_ValidationDto In pkg.Validations
            Dim cv As String = v.Cod_Validation.Trim
            If cv = "" Then
                E.Add("Une validation n'a pas de code (Cod_Validation vide).")
                Continue For
            End If
            If Not validationsVues.Add(cv) Then E.Add("Validation en doublon : '" & cv & "'.")
            If Not SP_Page_Designer.PORTEES.Contains(v.Portee.Trim) Then
                E.Add("Portée invalide ('" & v.Portee & "') pour la validation '" & cv & "'.")
            End If
            If Not SP_Page_Designer.TYPES_REGLE.Contains(v.Typ_Regle.Trim) Then
                E.Add("Type de règle invalide ('" & v.Typ_Regle & "') pour la validation '" & cv & "'.")
            End If
            If v.Niveau.Trim <> "" AndAlso Not SP_Page_Designer.NIVEAUX.Contains(v.Niveau.Trim) Then
                E.Add("Niveau invalide ('" & v.Niveau & "') pour la validation '" & cv & "' (I/W/B attendu).")
            End If
            If v.Moment.Trim <> "" AndAlso Not SP_Page_Designer.MOMENTS.Contains(v.Moment.Trim) Then
                E.Add("Moment invalide ('" & v.Moment & "') pour la validation '" & cv & "'.")
            End If
            If v.Message.Trim = "" Then E.Add("Message obligatoire pour la validation '" & cv & "'.")
            VerifierLongueur(E, "Code validation", cv, 50)
            VerifierLongueur(E, "Message de la validation '" & cv & "'", v.Message, 300)
            If v.Cod_Table.Trim <> "" AndAlso Not tablesVues.Contains(v.Cod_Table.Trim) Then
                E.Add("La validation '" & cv & "' référence une table absente du fichier : '" & v.Cod_Table & "'.")
            End If
            If v.Portee.Trim = "CHAMP" AndAlso v.Cod_Champ.Trim = "" Then
                E.Add("La validation '" & cv & "' a la portée CHAMP mais ne désigne aucun champ (Cod_Champ vide).")
            End If
            If v.Cod_Champ.Trim <> "" AndAlso Not champsVus.Contains(v.Cod_Champ.Trim) Then
                E.Add("La validation '" & cv & "' référence un champ absent du fichier : '" & v.Cod_Champ & "'.")
            End If
        Next
        '---------------- Sources métier ----------------
        Dim sourcesVues As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each s As SP_Page_SourceDto In pkg.BusinessSources
            Dim cs As String = s.Cod_Source.Trim
            If cs = "" Then
                E.Add("Une source métier n'a pas de code (Cod_Source vide).")
                Continue For
            End If
            If Not sourcesVues.Add(cs) Then E.Add("Source métier en doublon : '" & cs & "'.")
            If Not SP_Page_Designer.TYPES_SOURCE.Contains(s.Typ_Source.Trim) Then
                E.Add("Type de source invalide ('" & s.Typ_Source & "') pour la source '" & cs & "' (SQL/PROC attendu).")
            End If
            If s.Typ_Retour.Trim <> "" AndAlso Not SP_Page_Designer.TYPES_RETOUR.Contains(s.Typ_Retour.Trim) Then
                E.Add("Type de retour invalide ('" & s.Typ_Retour & "') pour la source '" & cs & "' (SCALAIRE/TABLE attendu).")
            End If
            If s.Libelle.Trim = "" Then E.Add("Libellé obligatoire pour la source '" & cs & "'.")
            If s.Code_Sql.Trim = "" Then E.Add("Requête / procédure (Code_Sql) obligatoire pour la source '" & cs & "'.")
            VerifierLongueur(E, "Code source", cs, 50)
            VerifierLongueur(E, "Libellé de la source '" & cs & "'", s.Libelle, 150)
            VerifierLongueur(E, "Profil de la source '" & cs & "'", s.Cod_Profile, 10)
            If s.Parametres.Trim <> "" Then
                Try
                    Dim jp As JToken = JToken.Parse(s.Parametres)
                    If Not (TypeOf jp Is JArray) Then Throw New InvalidCastException("liste attendue")
                Catch
                    E.Add("Source '" & cs & "' : paramètres illisibles (json liste attendu : [{""Nom"":...,""Typ"":...,""Obligatoire"":...}]).")
                End Try
            End If
            If s.Cod_Profile.Trim <> "" AndAlso Not ExisteEnBase("select count(*) from Controle_Profile where Cod_Profile=" & SqlV(s.Cod_Profile.Trim)) Then
                W.Add("Dépendance non résolue : le profil '" & s.Cod_Profile & "' requis par la source '" & cs & "' n'existe pas dans cette base (Controle_Profile) : la source restera limitée à ce profil tant qu'il n'est pas créé ou corrigé.")
            End If
        Next
    End Sub

    ''' <summary>La source est-elle résoluble : présente dans le fichier OU déjà
    ''' en base (catalogue global) ?</summary>
    Private Shared Function SourceResolvable(pkg As SP_Page_Package, codSource As String) As Boolean
        For Each s As SP_Page_SourceDto In pkg.BusinessSources
            If s.Cod_Source.Trim.Equals(codSource, StringComparison.OrdinalIgnoreCase) Then Return True
        Next
        Return ExisteEnBase("select count(*) from Controle_Designer_Source where Cod_Source=" & SqlV(codSource))
    End Function

    ''' <summary>Contrôles d'une grille virtuelle (miroir de VerifierTableVirtuelle
    ''' du Designer, appliqué au contenu du fichier) : source résoluble, active,
    ''' retour TABLE ; mapping json cohérent avec les paramètres déclarés et les
    ''' colonnes de l'entête.</summary>
    Private Shared Sub VerifierSourceVirtuelle(t As SP_Page_TableDto, pkg As SP_Page_Package, res As SP_Page_ImportResultat)
        Dim ct As String = t.Cod_Table.Trim
        Dim sm As String = t.Source_Metier.Trim
        ' Résolution : fichier d'abord, base ensuite (catalogue global)
        Dim typRetour As String = ""
        Dim paramsJson As String = ""
        Dim actif As String = "true"
        Dim trouve As Boolean = False
        For Each s As SP_Page_SourceDto In pkg.BusinessSources
            If s.Cod_Source.Trim.Equals(sm, StringComparison.OrdinalIgnoreCase) Then
                trouve = True
                typRetour = If(s.Typ_Retour.Trim = "", "SCALAIRE", s.Typ_Retour.Trim)
                paramsJson = s.Parametres
                actif = If(s.Actif, "true", "false")
                Exit For
            End If
        Next
        If Not trouve Then
            Dim tbl As DataTable = DATA_READER_GRD("select Typ_Retour, Parametres, Actif from Controle_Designer_Source where Cod_Source=" & SqlV(sm))
            If tbl.Rows.Count > 0 Then
                trouve = True
                typRetour = IsNull(tbl.Rows(0)("Typ_Retour"), "SCALAIRE").Trim
                paramsJson = IsNull(tbl.Rows(0)("Parametres"), "")
                actif = IsNull(tbl.Rows(0)("Actif"), "true")
            End If
        End If
        If Not trouve Then
            res.Erreurs.Add("Table '" & ct & "' : source métier '" & sm & "' absente du fichier ET de cette base : la dépendance est indispensable.")
            Return
        End If
        If actif <> "true" Then
            res.Erreurs.Add("Table '" & ct & "' : la source '" & sm & "' est inactive.")
        End If
        If Not typRetour.Equals("TABLE", StringComparison.OrdinalIgnoreCase) Then
            res.Erreurs.Add("Table '" & ct & "' : la source '" & sm & "' est de retour '" & typRetour & "' — une grille virtuelle exige une source de retour TABLE.")
        End If
        ' Paramètres déclarés de la source
        Dim declares As New List(Of String)
        Dim obligatoires As New List(Of String)
        If paramsJson.Trim <> "" Then
            Try
                For Each tk In CType(JToken.Parse(paramsJson), JArray)
                    Dim o = TryCast(tk, JObject)
                    If o Is Nothing OrElse o("Nom") Is Nothing Then Continue For
                    Dim np As String = o("Nom").ToString()
                    If Not declares.Contains(np) Then declares.Add(np)
                    Dim ob As String = If(o("Obligatoire") Is Nothing, "false", o("Obligatoire").ToString())
                    If ob.Equals("true", StringComparison.OrdinalIgnoreCase) OrElse ob = "1" Then obligatoires.Add(np)
                Next
            Catch
                res.Erreurs.Add("Table '" & ct & "' : les paramètres de la source '" & sm & "' ne sont pas lisibles (json attendu : [{""Nom"":...,""Typ"":...,""Obligatoire"":...}]).")
            End Try
        End If
        ' Mapping
        Dim mj As String = t.Source_Mapping.Trim
        Dim alimentes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        If mj <> "" Then
            Dim j As JObject = Nothing
            Try
                j = TryCast(JToken.Parse(mj), JObject)
            Catch
                j = Nothing
            End Try
            If j Is Nothing Then
                res.Erreurs.Add("Table '" & ct & "' : mapping invalide (json objet attendu : {""Paramètre"":{""ref"":""Champ""}}).")
            Else
                ' Colonnes de l'entête du fichier (+ techniques hors RV)
                Dim champsEnt As New List(Of String)
                For Each tt As SP_Page_TableDto In pkg.SqlStructure
                    If Not tt.Cod_Table.Trim.Equals("ENT", StringComparison.OrdinalIgnoreCase) Then Continue For
                    For Each col As SP_Page_ColonneDto In tt.Colonnes
                        If col.Nom_Colonne.Trim <> "" AndAlso Not champsEnt.Contains(col.Nom_Colonne.Trim) Then champsEnt.Add(col.Nom_Colonne.Trim)
                    Next
                Next
                For Each nc In SP_Page_Designer.ColonnesTechniquesTable("ENT")
                    If nc.Equals("RV", StringComparison.OrdinalIgnoreCase) Then Continue For
                    If Not champsEnt.Contains(nc) Then champsEnt.Add(nc)
                Next
                For Each prop As JProperty In j.Properties()
                    If Not declares.Contains(prop.Name, StringComparer.OrdinalIgnoreCase) Then
                        res.Erreurs.Add("Table '" & ct & "' : le mapping alimente '" & prop.Name & "', non déclaré dans les paramètres de la source '" & sm & "'.")
                        Continue For
                    End If
                    Dim d = TryCast(prop.Value, JObject)
                    Dim ref As String = If(d IsNot Nothing AndAlso d("ref") IsNot Nothing, d("ref").ToString().Trim, "")
                    Dim aConst As Boolean = (d IsNot Nothing AndAlso d("const") IsNot Nothing)
                    If ref = "" AndAlso Not aConst Then
                        res.Erreurs.Add("Table '" & ct & "' : le paramètre '" & prop.Name & "' n'est alimenté ni par un champ ni par une constante.")
                        Continue For
                    End If
                    If ref <> "" AndAlso Not champsEnt.Contains(ref, StringComparer.OrdinalIgnoreCase) Then
                        res.Erreurs.Add("Table '" & ct & "' : le paramètre '" & prop.Name & "' référence le champ d'entête '" & ref & "', absent de la structure exportée (table ENT).")
                        Continue For
                    End If
                    alimentes.Add(prop.Name)
                Next
            End If
        End If
        For Each pn In obligatoires
            If Not alimentes.Contains(pn) Then
                res.Erreurs.Add("Table '" & ct & "' : le paramètre obligatoire '" & pn & "' de la source '" & sm & "' n'est pas alimenté (mapping).")
            End If
        Next
    End Sub

    ''' <summary>Contrôles propres à une MISE À JOUR : le type document pilote les
    ''' noms physiques et le workflow — il est immuable dès que la page existe
    ''' (miroir du Designer : Cod_Document verrouillé après création).</summary>
    Public Shared Function ControlerCibleExistante(pkg As SP_Page_Package, codDocumentBase As String) As List(Of String)
        Dim erreurs As New List(Of String)
        If Not pkg.Page.Cod_Document.Trim.Equals(codDocumentBase.Trim, StringComparison.OrdinalIgnoreCase) Then
            erreurs.Add("Le type document du fichier ('" & pkg.Page.Cod_Document & "') diffère de celui de la page existante ('" & codDocumentBase & "')." & vbCrLf &
                        "Le type document est immuable après création (il pilote les noms physiques des tables et le workflow) :" & vbCrLf &
                        "cette mise à jour par import est impossible. Pour changer de type document, créez une nouvelle page.")
        End If
        Return erreurs
    End Function

    ''' <summary>
    ''' Alimente les DataTables du Designer depuis le package (appelé UNIQUEMENT
    ''' sans erreur bloquante, après Nouveau()/Request() : les DataTables sont
    ''' celles, fraîches, de l'écran). Synchronisation avec le contenu du fichier :
    ''' les collections de la page sont REMPLACÉES (clear + ajouts) — la purge et
    ''' la réécriture réelles en base relèvent de Saving() ; le catalogue des
    ''' sources, GLOBAL, est fusionné par Cod_Source (upsert, jamais de
    ''' suppression — miroir de Saving). Les habilitations (Tbl_Droits) ne sont
    ''' jamais passées à cette méthode.
    ''' </summary>
    Public Shared Sub RemplirTables(pkg As SP_Page_Package,
                                    tblTables As DataTable, tblColonnes As DataTable,
                                    tblChamps As DataTable, tblValidations As DataTable,
                                    tblSources As DataTable)
        '---------------- Tables + colonnes ----------------
        tblTables.Rows.Clear()
        tblColonnes.Rows.Clear()
        For Each t As SP_Page_TableDto In pkg.SqlStructure
            Dim r As DataRow = tblTables.NewRow()   ' déclenche les valeurs par défaut (TableNewRow)
            EcrireStr(r, "Cod_Table", t.Cod_Table.Trim.ToUpper())
            EcrireStr(r, "Nom_Physique", t.Nom_Physique)   ' recalculé par MajNomsPhysiques()
            EcrireStr(r, "Role_Table", If(t.Cod_Table.Trim.Equals("ENT", StringComparison.OrdinalIgnoreCase), "ENT", "DET"))
            EcrireStr(r, "Libelle", t.Libelle)
            EcrireEnt(r, "Rang", t.Rang)
            EcrireBool(r, "Allow_Add", t.Allow_Add)
            EcrireBool(r, "Allow_Edit", t.Allow_Edit)
            EcrireBool(r, "Allow_Delete", t.Allow_Delete)
            EcrireBool(r, "Allow_Duplicate", t.Allow_Duplicate)
            EcrireStr(r, "Tri_Defaut", t.Tri_Defaut)
            EcrireStr(r, "Regle_Suppression", If(t.Regle_Suppression.Trim = "", "CASCADE", t.Regle_Suppression.Trim))
            EcrireStr(r, "Source_Metier", t.Source_Metier.Trim)
            EcrireStr(r, "Source_Mapping", t.Source_Mapping)
            tblTables.Rows.Add(r)
            For Each c As SP_Page_ColonneDto In t.Colonnes
                Dim rc As DataRow = tblColonnes.NewRow()
                EcrireStr(rc, "Cod_Table", t.Cod_Table.Trim.ToUpper())
                EcrireStr(rc, "Nom_Colonne", c.Nom_Colonne.Trim)
                EcrireStr(rc, "Libelle", c.Libelle)
                EcrireStr(rc, "Typ_Sql", LCase(c.Typ_Sql.Trim))
                EcrireEntNul(rc, "Longueur", c.Longueur)
                EcrireEntNul(rc, "Precision_Sql", c.Precision_Sql)
                EcrireEntNul(rc, "Echelle_Sql", c.Echelle_Sql)
                EcrireBool(rc, "Nullable", c.Nullable)
                EcrireStr(rc, "Valeur_Defaut", c.Valeur_Defaut)
                EcrireBool(rc, "estUnique", c.estUnique)
                EcrireBool(rc, "estIndexe", c.estIndexe)
                EcrireEnt(rc, "Rang", c.Rang)
                tblColonnes.Rows.Add(rc)
            Next
        Next
        '---------------- Champs ----------------
        tblChamps.Rows.Clear()
        For Each c As SP_Page_ChampDto In pkg.Components
            Dim r As DataRow = tblChamps.NewRow()
            EcrireStr(r, "Cod_Champ", c.Cod_Champ.Trim)
            EcrireStr(r, "Cod_Table", c.Cod_Table.Trim.ToUpper())
            EcrireStr(r, "Nom_Colonne", c.Nom_Colonne.Trim)
            EcrireStr(r, "Libelle", c.Libelle)
            EcrireStr(r, "Typ_Controle", c.Typ_Controle.Trim)
            EcrireEnt(r, "Rang", c.Rang)
            EcrireEntNul(r, "Ligne", c.Ligne)
            EcrireEntNul(r, "Colonne", c.Colonne)
            EcrireEntNul(r, "Largeur", c.Largeur)
            EcrireStr(r, "Valeur_Defaut", c.Valeur_Defaut)
            EcrireBool(r, "Obligatoire", c.Obligatoire)
            ' Miroir de Saving : un champ calculé n'est jamais saisissable (A ou I)
            Dim etat As String = If(c.Etat.Trim = "", "S", c.Etat.Trim)
            If c.Typ_Controle.Trim = "CALCULE" AndAlso etat <> "A" AndAlso etat <> "I" Then etat = "A"
            EcrireStr(r, "Etat", etat)
            EcrireStr(r, "Rubrique", c.Rubrique.Trim)
            EcrireStr(r, "Num_Zoom", c.Num_Zoom.Trim)
            EcrireStr(r, "Source_Metier", c.Source_Metier.Trim)
            EcrireStr(r, "Formule", c.Formule)
            EcrireBool(r, "Persiste", c.Persiste)
            EcrireStr(r, "Format_Affichage", c.Format_Affichage.Trim)
            EcrireEntNul(r, "Decimales", c.Decimales)
            EcrireBool(r, "Visible_Grille", c.Visible_Grille)
            EcrireEnt(r, "Rang_Grille", c.Rang_Grille)
            EcrireEntNul(r, "Largeur_Colonne", c.Largeur_Colonne)
            EcrireBool(r, "estCritere", c.estCritere)
            EcrireEntNul(r, "Rang_Critere", c.Rang_Critere)
            EcrireStr(r, "Aide", c.Aide)
            tblChamps.Rows.Add(r)
        Next
        '---------------- Validations ----------------
        tblValidations.Rows.Clear()
        For Each v As SP_Page_ValidationDto In pkg.Validations
            Dim r As DataRow = tblValidations.NewRow()
            EcrireStr(r, "Cod_Validation", v.Cod_Validation.Trim)
            EcrireStr(r, "Portee", v.Portee.Trim)
            EcrireStr(r, "Cod_Table", v.Cod_Table.Trim.ToUpper())
            EcrireStr(r, "Cod_Champ", v.Cod_Champ.Trim)
            EcrireStr(r, "Typ_Regle", v.Typ_Regle.Trim)
            EcrireStr(r, "Parametres", v.Parametres)
            EcrireStr(r, "Condition_Regle", v.Condition_Regle)
            EcrireStr(r, "Message", v.Message)
            EcrireStr(r, "Niveau", If(v.Niveau.Trim = "", "B", v.Niveau.Trim))
            EcrireEnt(r, "Rang", v.Rang)
            EcrireStr(r, "Moment", If(v.Moment.Trim = "", "SAVE", v.Moment.Trim))
            EcrireBool(r, "Actif", v.Actif)
            tblValidations.Rows.Add(r)
        Next
        '---------------- Sources métier : UPSERT dans le catalogue global ----------------
        ' (jamais de suppression : une source absente du fichier peut servir à d'autres pages)
        For Each s As SP_Page_SourceDto In pkg.BusinessSources
            Dim cs As String = s.Cod_Source.Trim
            If cs = "" Then Continue For
            Dim r As DataRow = Nothing
            For Each ex As DataRow In tblSources.Rows
                If ex.RowState = DataRowState.Deleted Then Continue For
                If IsNull(ex("Cod_Source"), "").Trim.Equals(cs, StringComparison.OrdinalIgnoreCase) Then
                    r = ex : Exit For
                End If
            Next
            If r Is Nothing Then
                r = tblSources.NewRow()
                RemplirLigneSource(r, s)
                tblSources.Rows.Add(r)
            Else
                RemplirLigneSource(r, s)
            End If
        Next
    End Sub

    Private Shared Sub RemplirLigneSource(r As DataRow, s As SP_Page_SourceDto)
        EcrireStr(r, "Cod_Source", s.Cod_Source.Trim)
        EcrireStr(r, "Libelle", s.Libelle)
        EcrireStr(r, "Typ_Source", If(s.Typ_Source.Trim = "", "SQL", s.Typ_Source.Trim))
        EcrireStr(r, "Code_Sql", s.Code_Sql)
        EcrireStr(r, "Parametres", s.Parametres)
        EcrireStr(r, "Typ_Retour", If(s.Typ_Retour.Trim = "", "SCALAIRE", s.Typ_Retour.Trim))
        EcrireStr(r, "Cod_Profile", s.Cod_Profile.Trim)
        EcrireBool(r, "Actif", s.Actif)
    End Sub

    '---------------- Écritures de lignes (tolérantes au schéma) ----------------

    Private Shared Sub EcrireStr(r As DataRow, col As String, v As String)
        If Not r.Table.Columns.Contains(col) Then Return
        r(col) = If(v, "")
    End Sub

    Private Shared Sub EcrireBool(r As DataRow, col As String, v As Boolean)
        If Not r.Table.Columns.Contains(col) Then Return
        r(col) = If(v, "true", "false")
    End Sub

    Private Shared Sub EcrireEnt(r As DataRow, col As String, v As Integer)
        If Not r.Table.Columns.Contains(col) Then Return
        r(col) = v
    End Sub

    Private Shared Sub EcrireEntNul(r As DataRow, col As String, v As Integer?)
        If Not r.Table.Columns.Contains(col) Then Return
        If v.HasValue Then r(col) = v.Value Else r(col) = DBNull.Value
    End Sub

End Class

#End Region

#Region "Diff (prévisualisation création / mise à jour)"

''' <summary>Résultat de la comparaison fichier / page existante : compteurs par
''' collection et lignes de détail lisibles pour la prévisualisation.</summary>
Public Class SP_Page_DiffResultat
    Public ReadOnly Property Synthese As New List(Of String)   ' "Champs : 12 — 3 ajoutés, ..."
    Public ReadOnly Property Details As New List(Of String)    ' "+ Champ NOUVEAU", "- Colonne ENT.X"...
    Public Property NbAjouts As Integer = 0
    Public Property NbModifications As Integer = 0
    Public Property NbSuppressions As Integer = 0
    Public Property NbInchanges As Integer = 0
End Class

''' <summary>Comparaison de deux packages (fichier importé vs configuration en
''' base) : ajout / modification / suppression / inchangé par élément, clé =
''' code fonctionnel (Cod_Table, Cod_Table.Nom_Colonne, Cod_Champ, Cod_Validation,
''' Cod_Source). Le catalogue des sources n'est jamais compté en suppression
''' (catalogue global : upsert uniquement, miroir de Saving).</summary>
Public Class SP_Page_Json_Diff

    Private Shared Function CanonStr(v As String) As String
        Return If(v, "").Trim
    End Function
    Private Shared Function CanonBool(b As Boolean) As String
        Return If(b, "true", "false")
    End Function
    Private Shared Function CanonEntNul(v As Integer?) As String
        Return If(v.HasValue, v.Value.ToString(), "")
    End Function

    Private Shared Function EmpreinteEntete(p As SP_Page_EnteteDto) As String
        ' Statut_Page / Table_Ent / Acces_Personnalise exclus : non réimportés
        ' (statut géré par Publier/Désactiver ; habilitations préservées)
        Return String.Join("|", {CanonStr(p.Cod_Document), CanonStr(p.Nom_Page), CanonStr(p.Menu_Parent),
                                 p.Rang.ToString(), CanonStr(p.Icone), CanonBool(p.Workflow_Actif),
                                 CanonStr(p.Cod_Modele_Edition), CanonBool(p.GED_Actif), CanonBool(p.GED_Obligatoire),
                                 CanonBool(p.Act_Enregistrer), CanonBool(p.Act_Soumettre),
                                 CanonBool(p.Act_Imprimer), CanonBool(p.Act_Exporter)})
    End Function

    Private Shared Function EmpreinteTable(t As SP_Page_TableDto) As String
        Return String.Join("|", {CanonStr(t.Role_Table), CanonStr(t.Libelle), t.Rang.ToString(),
                                 CanonBool(t.Allow_Add), CanonBool(t.Allow_Edit), CanonBool(t.Allow_Delete),
                                 CanonBool(t.Allow_Duplicate), CanonStr(t.Tri_Defaut), CanonStr(t.Regle_Suppression),
                                 CanonStr(t.Source_Metier), CanonStr(t.Source_Mapping)})
    End Function

    Private Shared Function EmpreinteColonne(c As SP_Page_ColonneDto) As String
        Return String.Join("|", {CanonStr(c.Libelle), LCase(CanonStr(c.Typ_Sql)), CanonEntNul(c.Longueur),
                                 CanonEntNul(c.Precision_Sql), CanonEntNul(c.Echelle_Sql), CanonBool(c.Nullable),
                                 CanonStr(c.Valeur_Defaut), CanonBool(c.estUnique), CanonBool(c.estIndexe), c.Rang.ToString()})
    End Function

    Private Shared Function EmpreinteChamp(c As SP_Page_ChampDto) As String
        Return String.Join("|", {CanonStr(c.Cod_Table), CanonStr(c.Nom_Colonne), CanonStr(c.Libelle),
                                 CanonStr(c.Typ_Controle), c.Rang.ToString(), CanonEntNul(c.Ligne), CanonEntNul(c.Colonne),
                                 CanonEntNul(c.Largeur), CanonStr(c.Valeur_Defaut), CanonBool(c.Obligatoire),
                                 CanonStr(c.Etat), CanonStr(c.Rubrique), CanonStr(c.Num_Zoom), CanonStr(c.Source_Metier),
                                 CanonStr(c.Formule), CanonBool(c.Persiste), CanonStr(c.Format_Affichage),
                                 CanonEntNul(c.Decimales), CanonBool(c.Visible_Grille), c.Rang_Grille.ToString(),
                                 CanonEntNul(c.Largeur_Colonne), CanonBool(c.estCritere), CanonEntNul(c.Rang_Critere),
                                 CanonStr(c.Aide)})
    End Function

    Private Shared Function EmpreinteSource(s As SP_Page_SourceDto) As String
        Return String.Join("|", {CanonStr(s.Libelle), CanonStr(s.Typ_Source), CanonStr(s.Code_Sql),
                                 CanonStr(s.Parametres), CanonStr(s.Typ_Retour), CanonStr(s.Cod_Profile),
                                 CanonBool(s.Actif)})
    End Function

    Private Shared Function EmpreinteValidation(v As SP_Page_ValidationDto) As String
        Return String.Join("|", {CanonStr(v.Portee), CanonStr(v.Cod_Table), CanonStr(v.Cod_Champ),
                                 CanonStr(v.Typ_Regle), CanonStr(v.Parametres), CanonStr(v.Condition_Regle),
                                 CanonStr(v.Message), CanonStr(v.Niveau), v.Rang.ToString(), CanonStr(v.Moment),
                                 CanonBool(v.Actif)})
    End Function

    ''' <summary>Compare le fichier (nouveau) à la configuration actuelle (actuel,
    ''' Nothing = création : tout est 'à créer').</summary>
    Public Shared Function Comparer(nouveau As SP_Page_Package, actuel As SP_Page_Package) As SP_Page_DiffResultat
        Dim res As New SP_Page_DiffResultat
        '---------------- Entête ----------------
        If actuel IsNot Nothing AndAlso EmpreinteEntete(nouveau.Page) <> EmpreinteEntete(actuel.Page) Then
            res.Details.Add("~ Entête de la page (propriétés générales)")
        End If
        '---------------- Tables ----------------
        Dim ancienT As New Dictionary(Of String, SP_Page_TableDto)(StringComparer.OrdinalIgnoreCase)
        If actuel IsNot Nothing Then
            For Each t In actuel.SqlStructure
                If t.Cod_Table.Trim <> "" Then ancienT(t.Cod_Table.Trim) = t
            Next
        End If
        Dim ajT As Integer = 0, moT As Integer = 0, inT As Integer = 0
        Dim nouvT As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each t In nouveau.SqlStructure
            Dim k As String = t.Cod_Table.Trim
            If k = "" Then Continue For
            nouvT.Add(k)
            If Not ancienT.ContainsKey(k) Then
                ajT += 1 : res.Details.Add("+ Table " & k)
            ElseIf EmpreinteTable(t) <> EmpreinteTable(ancienT(k)) Then
                moT += 1 : res.Details.Add("~ Table " & k)
            Else
                inT += 1
            End If
        Next
        Dim suT As Integer = 0
        For Each k In ancienT.Keys
            If Not nouvT.Contains(k) Then suT += 1 : res.Details.Add("- Table " & k)
        Next
        res.Synthese.Add(LigneResume("Tables (grilles)", ancienT.Count, ajT, moT, suT, inT))
        '---------------- Colonnes ----------------
        Dim ancienC As New Dictionary(Of String, SP_Page_ColonneDto)(StringComparer.OrdinalIgnoreCase)
        If actuel IsNot Nothing Then
            For Each t In actuel.SqlStructure
                For Each c In t.Colonnes
                    Dim k As String = t.Cod_Table.Trim & "." & c.Nom_Colonne.Trim
                    If Not ancienC.ContainsKey(k) Then ancienC(k) = c
                Next
            Next
        End If
        Dim ajC As Integer = 0, moC As Integer = 0, inC As Integer = 0
        Dim nouvC As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each t In nouveau.SqlStructure
            For Each c In t.Colonnes
                Dim k As String = t.Cod_Table.Trim & "." & c.Nom_Colonne.Trim
                If c.Nom_Colonne.Trim = "" OrElse nouvC.Contains(k) Then Continue For
                nouvC.Add(k)
                If Not ancienC.ContainsKey(k) Then
                    ajC += 1 : res.Details.Add("+ Colonne " & k)
                ElseIf EmpreinteColonne(c) <> EmpreinteColonne(ancienC(k)) Then
                    moC += 1 : res.Details.Add("~ Colonne " & k)
                Else
                    inC += 1
                End If
            Next
        Next
        Dim suC As Integer = 0
        For Each k In ancienC.Keys
            If Not nouvC.Contains(k) Then suC += 1 : res.Details.Add("- Colonne " & k)
        Next
        res.Synthese.Add(LigneResume("Colonnes physiques", ancienC.Count, ajC, moC, suC, inC))
        '---------------- Champs ----------------
        Dim ancienCh As New Dictionary(Of String, SP_Page_ChampDto)(StringComparer.OrdinalIgnoreCase)
        If actuel IsNot Nothing Then
            For Each c In actuel.Components
                If c.Cod_Champ.Trim <> "" Then ancienCh(c.Cod_Champ.Trim) = c
            Next
        End If
        Dim ajCh As Integer = 0, moCh As Integer = 0, inCh As Integer = 0
        Dim nouvCh As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each c In nouveau.Components
            Dim k As String = c.Cod_Champ.Trim
            If k = "" Then Continue For
            nouvCh.Add(k)
            If Not ancienCh.ContainsKey(k) Then
                ajCh += 1 : res.Details.Add("+ Champ " & k)
            ElseIf EmpreinteChamp(c) <> EmpreinteChamp(ancienCh(k)) Then
                moCh += 1 : res.Details.Add("~ Champ " & k)
            Else
                inCh += 1
            End If
        Next
        Dim suCh As Integer = 0
        For Each k In ancienCh.Keys
            If Not nouvCh.Contains(k) Then suCh += 1 : res.Details.Add("- Champ " & k)
        Next
        res.Synthese.Add(LigneResume("Champs (entête + colonnes de grilles)", ancienCh.Count, ajCh, moCh, suCh, inCh))
        '---------------- Validations ----------------
        Dim ancienV As New Dictionary(Of String, SP_Page_ValidationDto)(StringComparer.OrdinalIgnoreCase)
        If actuel IsNot Nothing Then
            For Each v In actuel.Validations
                If v.Cod_Validation.Trim <> "" Then ancienV(v.Cod_Validation.Trim) = v
            Next
        End If
        Dim ajV As Integer = 0, moV As Integer = 0, inV As Integer = 0
        Dim nouvV As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each v In nouveau.Validations
            Dim k As String = v.Cod_Validation.Trim
            If k = "" Then Continue For
            nouvV.Add(k)
            If Not ancienV.ContainsKey(k) Then
                ajV += 1 : res.Details.Add("+ Validation " & k)
            ElseIf EmpreinteValidation(v) <> EmpreinteValidation(ancienV(k)) Then
                moV += 1 : res.Details.Add("~ Validation " & k)
            Else
                inV += 1
            End If
        Next
        Dim suV As Integer = 0
        For Each k In ancienV.Keys
            If Not nouvV.Contains(k) Then suV += 1 : res.Details.Add("- Validation " & k)
        Next
        res.Synthese.Add(LigneResume("Validations (comportement)", ancienV.Count, ajV, moV, suV, inV))
        '---------------- Sources métier (upsert : jamais de suppression) ----------------
        Dim ancienS As New Dictionary(Of String, SP_Page_SourceDto)(StringComparer.OrdinalIgnoreCase)
        If actuel IsNot Nothing Then
            For Each s In actuel.BusinessSources
                If s.Cod_Source.Trim <> "" Then ancienS(s.Cod_Source.Trim) = s
            Next
        End If
        Dim ajS As Integer = 0, moS As Integer = 0, inS As Integer = 0
        For Each s In nouveau.BusinessSources
            Dim k As String = s.Cod_Source.Trim
            If k = "" Then Continue For
            If Not ancienS.ContainsKey(k) Then
                ajS += 1 : res.Details.Add("+ Source métier " & k)
            ElseIf EmpreinteSource(s) <> EmpreinteSource(ancienS(k)) Then
                moS += 1 : res.Details.Add("~ Source métier " & k)
            Else
                inS += 1
            End If
        Next
        res.Synthese.Add("Sources métier (catalogue global, fusion sans suppression) : " & nouveau.BusinessSources.Count &
                         " utilisée(s)" & If(ajS + moS > 0, " — " & ajS & " à créer, " & moS & " à mettre à jour", " — inchangées"))
        '---------------- Totaux ----------------
        res.NbAjouts = ajT + ajC + ajCh + ajV + ajS
        res.NbModifications = moT + moC + moCh + moV + moS
        res.NbSuppressions = suT + suC + suCh + suV
        res.NbInchanges = inT + inC + inCh + inV + inS
        Return res
    End Function

    Private Shared Function LigneResume(libelle As String, nbAncien As Integer, aj As Integer, mo As Integer, su As Integer, inch As Integer) As String
        Dim total As Integer = nbAncien + aj
        Dim s As String = libelle & " : " & total
        If aj + mo + su + inch > 0 Then
            Dim parts As New List(Of String)
            If aj > 0 Then parts.Add(aj & " ajoutée(s)")
            If mo > 0 Then parts.Add(mo & " modifiée(s)")
            If su > 0 Then parts.Add(su & " supprimée(s)")
            parts.Add(inch & " inchangée(s)")
            s &= " — " & String.Join(", ", parts)
        End If
        Return s
    End Function

End Class

#End Region
