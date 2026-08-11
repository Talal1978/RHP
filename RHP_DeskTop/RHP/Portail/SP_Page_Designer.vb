Imports System.Text
Imports System.Text.RegularExpressions

''' <summary>
''' Designer de pages portail (module SP_).
''' Onglet 1 : document, rattachement portail et structure SQL (tables/colonnes).
''' Onglet 2 : conception de la page (champs entête + grilles) et catalogue
'''            sécurisé des sources métier.
''' Onglet 3 : comportement (actions, édition, GED, workflow) et validations.
''' Onglet 4 : habilitations par profil (périmètre : toute la page).
''' L'enregistrement crée/migre les tables métier SP_ dans la même transaction
''' (aperçu DDL disponible via le bouton "Aperçu DDL", journal SP_Page_DDL_Log).
''' </summary>
Public Class SP_Page_Designer
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Exec_D As ud_btn
    Dim Publi_D As ud_btn

    Dim Tbl_Tables As DataTable
    Dim Tbl_Colonnes As DataTable
    Dim Tbl_Champs As DataTable
    Dim Tbl_Validations As DataTable
    Dim Tbl_Droits As DataTable
    Dim Tbl_Sources As DataTable

    Private Const SQL_TABLES = "select Cod_Table, Nom_Physique, Role_Table, Libelle, Rang, Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression from SP_Page_Table"
    Private Const SQL_COLONNES = "select Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur, Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Rang from SP_Page_Colonne where isnull(Technique,'false')='false'"
    Private Const SQL_CHAMPS = "select Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle, Rang, Ligne, Colonne, Largeur, Valeur_Defaut, Obligatoire, Etat, Rubrique, Num_Zoom, Source_Metier, Formule, Persiste, Format_Affichage, Decimales, Visible_Grille, Rang_Grille, Largeur_Colonne, Total_Grille, estCritere, Rang_Critere, Aide from SP_Page_Champ"
    Private Const SQL_VALIDATIONS = "select Cod_Validation, Portee, Cod_Table, Cod_Champ, Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif from SP_Page_Validation"
    Private Const SQL_SOURCES = "select Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif from SP_Page_Source"

    '---------------- Domaines prédéterminés (listes déroulantes des grilles) ----------------
    ' Source unique des valeurs autorisées : alimente les DataGridViewComboBoxColumn
    ' et les validations de Saving() (cohérence saisie/contrôle garantie).
    Private Shared ReadOnly TYPES_SQL As String() = {"nvarchar", "int", "bigint", "float", "decimal", "bit", "date", "datetime", "smalldatetime"}
    Private Shared ReadOnly TYPES_CONTROLE As String() = {"TEXT", "MEMO", "INT", "DEC", "MNT", "DATE", "DATETIME", "CHECK", "RADIO", "COMBO", "RUBRIQUE", "ZOOM", "CALCULE", "SOURCE", "GED"}
    Private Shared ReadOnly TYPES_REGLE As String() = {"REQUIRED", "IN", "BETWEEN", "MIN", "MAX", "MINLEN", "MAXLEN", "REGEX", "COMPARE", "UNIQUE", "SOURCE", "EXPR", "NB_LIGNES"}
    Private Shared ReadOnly PORTEES As String() = {"CHAMP", "ENTETE", "LIGNE", "DETAIL", "DOCUMENT"}
    Private Shared ReadOnly ETATS As String() = {"S", "R", "A", "I"}
    Private Shared ReadOnly NIVEAUX As String() = {"I", "W", "B"}
    Private Shared ReadOnly MOMENTS As String() = {"SAISIE", "CHANGE", "AJOUT_LIGNE", "SAVE"}
    Private Shared ReadOnly TOTAUX_GRILLE As String() = {"", "SUM", "AVG", "MIN", "MAX", "COUNT"}
    Private Shared ReadOnly TYPES_SOURCE As String() = {"SQL", "PROC"}
    Private Shared ReadOnly TYPES_RETOUR As String() = {"SCALAIRE", "TABLE"}

    ''' <summary>Habilitations : une ligne par profil déclaré (Controle_Profile),
    ''' complétée par les droits enregistrés de la page (LEFT JOIN ; tout à 'false'
    ''' si aucun droit enregistré). Les profils créés ultérieurement apparaissent
    ''' automatiquement à l'ouverture de la page.</summary>
    Private Function SqlDroits(codPage As String) As String
        Return "select p.Cod_Profile, p.Lib_Profile, " &
               "isnull(d.Consulter,'false') as Consulter, isnull(d.Creer,'false') as Creer, " &
               "isnull(d.Modifier,'false') as Modifier, isnull(d.Supprimer,'false') as Supprimer, " &
               "isnull(d.Valider,'false') as Valider, isnull(d.Imprimer,'false') as Imprimer, " &
               "isnull(d.GED,'false') as GED " &
               "from Controle_Profile p left join SP_Page_Droit d on d.Cod_Profile=p.Cod_Profile" &
               " and d.Cod_Page='" & codPage.Replace("'", "''") & "' order by p.Cod_Profile"
    End Function

    ''' <summary>Applique les options d'affichage du thème RHP (ud_Grd) aux grilles éditables.</summary>
    Sub StyliserGrilles()
        For Each g As ud_Grd In {Grd_Tables, Grd_Colonnes, Grd_Droits, Grd_Champs, Grd_Sources, Grd_Validations}
            g.AlternerLesLignes = True
            ' Tables et colonnes : en-têtes de lignes visibles (sélection d'une ligne
            ' par le row header pour la suppression contrôlée via la touche Suppr)
            g.AfficherLesEntetesLignes = (g Is Grd_Tables OrElse g Is Grd_Colonnes)
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Next
    End Sub

    '---------------- Icônes MUI (liste déroulante illustrée) ----------------
    Private materialFontFamily As FontFamily = Nothing
    Private ReadOnly iconesBmp As New Dictionary(Of String, Bitmap)

    ''' <summary>Charge la font Material Icons (rsc/fonts) pour l'illustration des icônes.</summary>
    Sub ChargerFontIcones()
        If materialFontFamily IsNot Nothing Then Return
        Dim chemin As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "rsc", "fonts", "MaterialIcons-Regular.ttf")
        If Not IO.File.Exists(chemin) Then Return
        Dim pfc As New Drawing.Text.PrivateFontCollection
        pfc.AddFontFile(chemin)
        If pfc.Families.Length > 0 Then materialFontFamily = pfc.Families(0)
    End Sub

    ''' <summary>Conversion PascalCase (MenuIcons.tsx) -> snake_case (ligature Material Icons).</summary>
    Private Function PascalToSnake(nom As String) As String
        Return Regex.Replace(nom, "(?<!^)([A-Z])", "_$1").ToLower()
    End Function

    ''' <summary>Rend l'icône MUI en bitmap pour la liste déroulante.</summary>
    Private Function IconeBitmap(nomMui As String) As Bitmap
        Dim bmp As New Bitmap(20, 20)
        If materialFontFamily Is Nothing Then Return bmp
        Using g As Graphics = Graphics.FromImage(bmp)
            Using f As New Font(materialFontFamily, 10)
                ' TextRenderer (Uniscribe) : applique les ligatures OpenType de la font Material Icons
                TextRenderer.DrawText(g, PascalToSnake(nomMui), f, New Point(0, 2), colorBase01)
            End Using
        End Using
        Return bmp
    End Function

    ''' <summary>Remplit la liste des icônes (rubrique SP_Menu_Icones + illustration).</summary>
    Sub ChargerIcones()
        ChargerFontIcones()
        Icone_cmb.Items.Clear()
        iconesBmp.Clear()
        Icone_cmb.Items.Add("")
        Dim tbl As DataTable = DATA_READER_GRD("select Valeur from Param_Rubriques where Nom_Controle='SP_Menu_Icones' order by Rang")
        For Each r As DataRow In tbl.Rows
            Dim nom As String = IsNull(r("Valeur"), "")
            If nom = "" Then Continue For
            iconesBmp(nom) = IconeBitmap(nom)
            Icone_cmb.Items.Add(nom)
        Next
    End Sub

    ''' <summary>Dessine chaque élément : icône MUI + nom (couleurs du thème).</summary>
    Private Sub Icone_cmb_DrawItem(sender As Object, e As DrawItemEventArgs) Handles Icone_cmb.DrawItem
        If e.Index < 0 Then Return
        Dim nom As String = Icone_cmb.Items(e.Index).ToString()
        Dim selectionne As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected
        Using b As New SolidBrush(If(selectionne, colorBase01, Color.White))
            e.Graphics.FillRectangle(b, e.Bounds)
        End Using
        If nom <> "" AndAlso iconesBmp.ContainsKey(nom) Then
            e.Graphics.DrawImage(iconesBmp(nom), e.Bounds.Left + 3, e.Bounds.Top + 2, 18, 18)
        End If
        Using tb As New SolidBrush(If(selectionne, Color.White, Color.Black))
            e.Graphics.DrawString(nom, e.Font, tb, e.Bounds.Left + 26, e.Bounds.Top + 4)
        End Using
    End Sub

    Private Function IconeChoisie() As String
        Return If(Icone_cmb.SelectedIndex >= 0 AndAlso Icone_cmb.SelectedItem IsNot Nothing, Icone_cmb.SelectedItem.ToString(), "")
    End Function
    Private Sub ChoisirIcone(nom As String)
        For i As Integer = 0 To Icone_cmb.Items.Count - 1
            If Icone_cmb.Items(i).ToString() = nom Then Icone_cmb.SelectedIndex = i : Return
        Next
        Icone_cmb.SelectedIndex = -1
    End Sub

    '---------------- Colonnes des grilles (types framework standard, ----------------
    ' déclarées dans le code : à l'abri de la régénération du Designer par VS)
    Private Function ColTxt(prop As String, header As String) As DataGridViewTextBoxColumn
        Return New DataGridViewTextBoxColumn With {.DataPropertyName = prop, .HeaderText = header, .Name = "col_" & prop}
    End Function
    Private Function ColChk(prop As String, header As String) As DataGridViewCheckBoxColumn
        Return New DataGridViewCheckBoxColumn With {.DataPropertyName = prop, .HeaderText = header, .Name = "col_" & prop, .TrueValue = "true", .FalseValue = "false"}
    End Function
    ''' <summary>Colonne liste déroulante (valeurs fermées ou alimentées dynamiquement).</summary>
    Private Function ColCombo(prop As String, header As String, ParamArray valeurs As String()) As DataGridViewComboBoxColumn
        Dim c As New DataGridViewComboBoxColumn With {.DataPropertyName = prop, .HeaderText = header, .Name = "col_" & prop}
        c.Items.AddRange(valeurs)
        Return c
    End Function
    ''' <summary>Style des cellules calculées automatiquement (grisées, non éditables).</summary>
    Private Function StyleCellAuto() As DataGridViewCellStyle
        Return New DataGridViewCellStyle With {.BackColor = Color.FromArgb(240, 243, 245), .ForeColor = Color.FromArgb(90, 90, 90)}
    End Function
    Private Sub DefinirColonnes(grd As DataGridView, cols As DataGridViewColumn())
        grd.AutoGenerateColumns = False
        grd.Columns.Clear()
        grd.Columns.AddRange(cols)
    End Sub

    ''' <summary>Déclare les colonnes des 6 grilles (entêtes français, booléens en cases à
    ''' cocher, domaines prédéterminés en listes déroulantes pour éviter les erreurs de saisie).</summary>
    Sub InitialiserColonnesGrilles()
        DefinirColonnes(Grd_Tables, New DataGridViewColumn() {
            ColTxt("Cod_Table", "Table"), ColTxt("Nom_Physique", "Nom physique"), ColTxt("Role_Table", "Rôle"),
            ColTxt("Libelle", "Libellé"), ColTxt("Rang", "Rang"),
            ColChk("Allow_Add", "Ajout"), ColChk("Allow_Edit", "Modif."), ColChk("Allow_Delete", "Suppr."), ColChk("Allow_Duplicate", "Dupliq."),
            ColTxt("Tri_Defaut", "Tri par défaut"), ColCombo("Regle_Suppression", "Règle suppression", "CASCADE", "RESTRICT")})
        ' Nom physique et rôle : calculés automatiquement (jamais saisis -> intégrité SQL garantie)
        Grd_Tables.Columns("col_Nom_Physique").ReadOnly = True
        Grd_Tables.Columns("col_Nom_Physique").DefaultCellStyle = StyleCellAuto()
        Grd_Tables.Columns("col_Role_Table").ReadOnly = True
        Grd_Tables.Columns("col_Role_Table").DefaultCellStyle = StyleCellAuto()
        DefinirColonnes(Grd_Colonnes, New DataGridViewColumn() {
            ColCombo("Cod_Table", "Table"), ColTxt("Nom_Colonne", "Colonne"), ColTxt("Libelle", "Libellé"),
            ColCombo("Typ_Sql", "Type SQL", TYPES_SQL), ColTxt("Longueur", "Longueur"), ColTxt("Precision_Sql", "Précision"), ColTxt("Echelle_Sql", "Échelle"),
            ColChk("Nullable", "Nullable"), ColTxt("Valeur_Defaut", "Valeur par défaut"),
            ColChk("estUnique", "Unique"), ColChk("estIndexe", "Indexée"), ColTxt("Rang", "Rang")})
        DefinirColonnes(Grd_Droits, New DataGridViewColumn() {
            ColTxt("Cod_Profile", "Profil"), ColTxt("Lib_Profile", "Libellé du profil"), ColChk("Consulter", "Consulter"), ColChk("Creer", "Créer"),
            ColChk("Modifier", "Modifier"), ColChk("Supprimer", "Supprimer"), ColChk("Valider", "Valider"),
            ColChk("Imprimer", "Imprimer"), ColChk("GED", "GED")})
        ' Les profils sont chargés automatiquement (Controle_Profile) : identification en
        ' lecture seule, aucune ligne à ajouter/supprimer manuellement.
        Grd_Droits.Columns("col_Cod_Profile").ReadOnly = True
        Grd_Droits.Columns("col_Cod_Profile").DefaultCellStyle = StyleCellAuto()
        Grd_Droits.Columns("col_Lib_Profile").ReadOnly = True
        Grd_Droits.Columns("col_Lib_Profile").DefaultCellStyle = StyleCellAuto()
        Grd_Droits.AllowUserToAddRows = False
        Grd_Droits.AllowUserToDeleteRows = False
        DefinirColonnes(Grd_Champs, New DataGridViewColumn() {
            ColTxt("Cod_Champ", "Champ"), ColCombo("Cod_Table", "Table"), ColTxt("Nom_Colonne", "Colonne"),
            ColTxt("Libelle", "Libellé"), ColCombo("Typ_Controle", "Type contrôle", TYPES_CONTROLE), ColTxt("Rang", "Rang"),
            ColTxt("Ligne", "Ligne"), ColTxt("Colonne", "Position"), ColTxt("Largeur", "Largeur"),
            ColTxt("Valeur_Defaut", "Valeur par défaut"), ColChk("Obligatoire", "Obligatoire"), ColCombo("Etat", "État", ETATS),
            ColTxt("Rubrique", "Rubrique"), ColTxt("Num_Zoom", "N° Zoom"), ColCombo("Source_Metier", "Source métier"),
            ColTxt("Formule", "Formule (json)"), ColChk("Persiste", "Persisté"), ColTxt("Format_Affichage", "Format"),
            ColTxt("Decimales", "Décimales"), ColChk("Visible_Grille", "Visible grille"), ColTxt("Rang_Grille", "Rang grille"),
            ColTxt("Largeur_Colonne", "Largeur col."), ColCombo("Total_Grille", "Total", TOTAUX_GRILLE),
            ColChk("estCritere", "Critère"), ColTxt("Rang_Critere", "Rang critère"), ColTxt("Aide", "Aide")})
        ' Rubrique et N° Zoom : jamais saisis au clavier, choisis via un zoom de sélection
        ' (double-clic sur la cellule) -> valeurs forcément existantes.
        Grd_Champs.Columns("col_Rubrique").ReadOnly = True
        Grd_Champs.Columns("col_Rubrique").DefaultCellStyle = StyleCellAuto()
        Grd_Champs.Columns("col_Num_Zoom").ReadOnly = True
        Grd_Champs.Columns("col_Num_Zoom").DefaultCellStyle = StyleCellAuto()
        DefinirColonnes(Grd_Validations, New DataGridViewColumn() {
            ColTxt("Cod_Validation", "Code"), ColCombo("Portee", "Portée", PORTEES), ColCombo("Cod_Table", "Table"),
            ColTxt("Cod_Champ", "Champ"), ColCombo("Typ_Regle", "Type de règle", TYPES_REGLE), ColTxt("Parametres", "Paramètres (json)"),
            ColTxt("Condition_Regle", "Condition (json)"), ColTxt("Message", "Message d'erreur"), ColCombo("Niveau", "Niveau", NIVEAUX),
            ColTxt("Rang", "Rang"), ColCombo("Moment", "Moment", MOMENTS), ColChk("Actif", "Active")})
        DefinirColonnes(Grd_Sources, New DataGridViewColumn() {
            ColTxt("Cod_Source", "Code source"), ColTxt("Libelle", "Libellé"), ColCombo("Typ_Source", "Type", TYPES_SOURCE),
            ColTxt("Code_Sql", "Requête SQL"), ColTxt("Parametres", "Paramètres (json)"), ColCombo("Typ_Retour", "Retour", TYPES_RETOUR),
            ColCombo("Cod_Profile", "Profil requis"), ColChk("Actif", "Active")})
    End Sub

    ''' <summary>Une valeur liée hors liste (données anciennes, profil supprimé...) ne doit
    ''' pas interrompre l'affichage des grilles : l'erreur de données est ignorée, la
    ''' cohérence est garantie par les validations de Saving().</summary>
    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) _
        Handles Grd_Tables.DataError, Grd_Colonnes.DataError, Grd_Droits.DataError,
                Grd_Champs.DataError, Grd_Validations.DataError, Grd_Sources.DataError
        e.ThrowException = False
    End Sub

    Sub Chargement()
        If Save_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Exec_D = dictButtons("Exec_D")
            Publi_D = dictButtons("Publi_D")
        End If
        If Menu_Parent_cmb.Items.Count = 0 Then Menu_Parent_cmb.fromRubrique("SP_Menu_Portail")
        If Statut_Page_cmb.Items.Count = 0 Then Statut_Page_cmb.fromRubrique("SP_Statut_Page")
        CreerSchemas()
        InitialiserColonnesGrilles()
        StyliserGrilles()
        ChargerIcones()
        BrancherMenuDroits()
        MajComboSources()
        MajComboProfilsSources()
        MajEtatColonneConsulter()
    End Sub

    ''' <summary>Relax les contraintes NOT NULL des DataTables mémoire : les grilles
    ''' doivent accepter des lignes incomplètes en cours de saisie. L'intégrité est
    ''' garantie par les validations de Saving() et les contraintes SQL Server.</summary>
    Sub AssouplirSchema(dt As DataTable)
        For Each c As DataColumn In dt.Columns
            c.AllowDBNull = True
        Next
    End Sub

    ''' <summary>Crée les DataTables (schémas vides) et les lie aux grilles.</summary>
    Sub CreerSchemas()
        Tbl_Tables = DATA_READER_GRD(SQL_TABLES & " where 1=0")
        Tbl_Colonnes = DATA_READER_GRD(SQL_COLONNES & " and 1=0")
        Tbl_Champs = DATA_READER_GRD(SQL_CHAMPS & " where 1=0")
        Tbl_Validations = DATA_READER_GRD(SQL_VALIDATIONS & " where 1=0")
        Tbl_Droits = DATA_READER_GRD(SqlDroits(""))   ' tous les profils, aucun droit coché
        Tbl_Sources = DATA_READER_GRD(SQL_SOURCES & " where 1=0")
        AssouplirSchema(Tbl_Tables) : AssouplirSchema(Tbl_Colonnes) : AssouplirSchema(Tbl_Champs)
        AssouplirSchema(Tbl_Validations) : AssouplirSchema(Tbl_Droits) : AssouplirSchema(Tbl_Sources)
        BrancherDefautsNouvellesLignes()
        Grd_Tables.DataSource = Tbl_Tables
        Grd_Colonnes.DataSource = Tbl_Colonnes
        Grd_Champs.DataSource = Tbl_Champs
        Grd_Validations.DataSource = Tbl_Validations
        Grd_Droits.DataSource = Tbl_Droits
        Grd_Sources.DataSource = Tbl_Sources
    End Sub

    Private Sub SP_Page_Designer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Chargement()
        Nouveau()
    End Sub
    Private Sub SP_Page_Designer_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Not (TypeOf Me.ActiveControl Is DataGridView) Then
            e.SuppressKeyPress = True
            If Save_D IsNot Nothing AndAlso Save_D.Enabled Then Enregistrer()
        End If
    End Sub

    ''' <summary>Zoom de sélection d'une page existante (logique standard Desktop :
    ''' le libellé du champ est le lien du zoom).</summary>
    Private Sub LabelCodPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LabelCodPage.LinkClicked
        Dim avant As String = Cod_Page_txt.Text
        Appel_Zoom("Cod_Page", "Nom_Page", "SP_Page", "1=1", Cod_Page_txt, Me)
        If Cod_Page_txt.Text.Trim <> "" AndAlso Cod_Page_txt.Text <> avant Then
            Cod_Page_txt.ReadOnly = True
            Cod_Document_txt.ReadOnly = True
            Request(Cod_Page_txt.Text.Trim)
        End If
    End Sub

    ''' <summary>Charge la configuration complète d'une page.</summary>
    Sub Request(Optional codPage As String = "")
        If codPage.Trim = "" Then Return
        Dim Tbl As DataTable = DATA_READER_GRD("select * from SP_Page where Cod_Page='" & codPage.Replace("'", "''") & "'")
        If Tbl.Rows.Count = 0 Then Return
        Dim r = Tbl.Rows(0)
        Cod_Page_txt.Text = IsNull(r("Cod_Page"), "")
        Cod_Page_txt.ReadOnly = True   ' identifiant immuable
        Cod_Document_txt.ReadOnly = True   ' pilote les noms physiques : immuable après création
        Cod_Document_txt.Text = IsNull(r("Cod_Document"), "")
        Nom_Page_txt.Text = IsNull(r("Nom_Page"), "")
        Menu_Parent_cmb.SelectedValue = IsNull(r("Menu_Parent"), "")
        Rang_txt.Value = CDec(Val(IsNull(r("Rang"), "99").ToString()))
        ChoisirIcone(IsNull(r("Icone"), ""))
        Statut_Page_cmb.SelectedValue = IsNull(r("Statut_Page"), "BROUILLON")
        Table_Ent_txt.Text = IsNull(r("Table_Ent"), "")
        Acces_Personnalise_chk.Checked = (IsNull(r("Acces_Personnalise"), "true") = "true")
        Workflow_Actif_chk.Checked = (IsNull(r("Workflow_Actif"), "false") = "true")
        Typ_Document_txt.Text = IsNull(r("Typ_Document"), "")
        Cod_Modele_Edition_txt.Text = IsNull(r("Cod_Modele_Edition"), "")
        GED_Actif_chk.Checked = (IsNull(r("GED_Actif"), "false") = "true")
        GED_Obligatoire_chk.Checked = (IsNull(r("GED_Obligatoire"), "false") = "true")
        Act_Enregistrer_chk.Checked = (IsNull(r("Act_Enregistrer"), "true") = "true")
        Act_Soumettre_chk.Checked = (IsNull(r("Act_Soumettre"), "true") = "true")
        Act_Imprimer_chk.Checked = (IsNull(r("Act_Imprimer"), "false") = "true")
        Act_Exporter_chk.Checked = (IsNull(r("Act_Exporter"), "false") = "true")
        Dim f As String = " where Cod_Page='" & codPage.Replace("'", "''") & "'"
        Tbl_Tables = DATA_READER_GRD(SQL_TABLES & f & " order by Rang")
        Tbl_Colonnes = DATA_READER_GRD(SQL_COLONNES.Replace("where isnull", "where Cod_Page='" & codPage.Replace("'", "''") & "' and isnull") & " order by Cod_Table, Rang")
        Tbl_Champs = DATA_READER_GRD(SQL_CHAMPS & f & " order by Cod_Table, Rang")
        Tbl_Validations = DATA_READER_GRD(SQL_VALIDATIONS & f & " order by Rang")
        Tbl_Droits = DATA_READER_GRD(SqlDroits(codPage))
        AssouplirSchema(Tbl_Tables) : AssouplirSchema(Tbl_Colonnes) : AssouplirSchema(Tbl_Champs)
        AssouplirSchema(Tbl_Validations) : AssouplirSchema(Tbl_Droits)
        BrancherDefautsNouvellesLignes(False)
        Grd_Tables.DataSource = Tbl_Tables
        MajCombosDependantes()   ' les listes doivent exister avant le binding des grilles
        Grd_Colonnes.DataSource = Tbl_Colonnes
        Grd_Champs.DataSource = Tbl_Champs
        Grd_Validations.DataSource = Tbl_Validations
        Grd_Droits.DataSource = Tbl_Droits
        MajComboSources()
        MajComboProfilsSources()
        MajEtatColonneConsulter()
        StyliserGrilles()
    End Sub

    ''' <summary>Génère le code page automatique : PG_&lt;yyyyMMdd&gt;_&lt;séquence sur 6 positions&gt;.
    ''' Format compatible avec l'identifiant strict (CK_SP_Page_Ident / validerIdentifiant) :
    ''' lettres, chiffres et '_' uniquement.</summary>
    Private Function GenererCodPage() As String
        Dim prefixe As String = "PG_" & DateTime.Now.ToString("yyyyMMdd") & "_"
        Dim likeEsc As String = prefixe.Replace("_", "[_]") & "[0-9][0-9][0-9][0-9][0-9][0-9]"
        Dim rsl = CnExecuting("select isnull(max(try_convert(int, right(Cod_Page,6))),0)+1 from SP_Page where Cod_Page like '" & likeEsc & "'")
        Return prefixe & CInt(rsl.Fields(0).Value).ToString("D6")
    End Function

    Sub Nouveau()
        Cod_Page_txt.ReadOnly = True   ' code généré automatiquement, immuable
        Cod_Document_txt.ReadOnly = False
        Cod_Page_txt.Text = GenererCodPage()
        Cod_Document_txt.Text = ""
        Nom_Page_txt.Text = ""
        Rang_txt.Value = 99
        Icone_cmb.SelectedIndex = -1
        Table_Ent_txt.Text = ""
        Statut_Page_cmb.SelectedValue = "BROUILLON"
        Acces_Personnalise_chk.Checked = False   ' par défaut : consultation ouverte à tous les profils
        Workflow_Actif_chk.Checked = False
        Typ_Document_txt.Text = ""
        Cod_Modele_Edition_txt.Text = ""
        GED_Actif_chk.Checked = False
        GED_Obligatoire_chk.Checked = False
        Act_Enregistrer_chk.Checked = True
        Act_Soumettre_chk.Checked = True
        Act_Imprimer_chk.Checked = False
        Act_Exporter_chk.Checked = False
        CreerSchemas()
        ' La table d'entête est toujours présente
        Dim r = Tbl_Tables.NewRow()
        r("Cod_Table") = "ENT" : r("Role_Table") = "ENT" : r("Rang") = 0
        r("Allow_Add") = "false" : r("Allow_Edit") = "false" : r("Allow_Delete") = "false" : r("Allow_Duplicate") = "false"
        r("Regle_Suppression") = "CASCADE"
        Tbl_Tables.Rows.Add(r)
        MajCombosDependantes()
        MajEtatColonneConsulter()
        Cod_Document_txt.Select()
    End Sub

    Private Sub Cod_Document_txt_Leave(sender As Object, e As EventArgs) Handles Cod_Document_txt.Leave
        MajNomsPhysiques()
    End Sub
    ''' <summary>Recalcule les noms physiques SP_&lt;Cod&gt;_Ent / _Det_&lt;Cod_Table&gt;
    ''' et le rôle (ENT/DET) : les deux sont entièrement dérivés du code document et
    ''' du code table, jamais saisis (contraintes CK_SPTable_Role / UQ nom respectées).</summary>
    Sub MajNomsPhysiques()
        Dim cod As String = Cod_Document_txt.Text.Trim
        If cod = "" Then Return
        Table_Ent_txt.Text = "SP_" & cod & "_Ent"
        For Each r As DataRow In Tbl_Tables.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            Dim ct As String = IsNull(r("Cod_Table"), "").Trim
            If ct = "" Then Continue For
            If ct.Equals("ENT", StringComparison.OrdinalIgnoreCase) Then
                r("Cod_Table") = "ENT"
                r("Nom_Physique") = "SP_" & cod & "_Ent"
                r("Role_Table") = "ENT"
            Else
                r("Nom_Physique") = "SP_" & cod & "_Det_" & ct
                r("Role_Table") = "DET"
            End If
        Next
    End Sub

    Sub Enregistrer()
        Dim rsl As savingResult = Saving()
        ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
        If rsl.result Then Request(Cod_Page_txt.Text.Trim)
    End Sub

    '---------------- Valeurs par défaut des nouvelles lignes ----------------
    ' (TableNewRow : couvre la saisie dans la grille ET les ajouts programmatiques)

    ''' <summary>Branche les valeurs par défaut des nouvelles lignes des grilles.
    ''' À re-brancher à chaque recréation des DataTables (CreerSchemas / Request).</summary>
    Sub BrancherDefautsNouvellesLignes(Optional inclureSources As Boolean = True)
        AddHandler Tbl_Tables.TableNewRow, AddressOf Tbl_Tables_TableNewRow
        AddHandler Tbl_Colonnes.TableNewRow, AddressOf Tbl_Colonnes_TableNewRow
        AddHandler Tbl_Champs.TableNewRow, AddressOf Tbl_Champs_TableNewRow
        AddHandler Tbl_Validations.TableNewRow, AddressOf Tbl_Validations_TableNewRow
        AddHandler Tbl_Droits.TableNewRow, AddressOf Tbl_Droits_TableNewRow
        If inclureSources Then AddHandler Tbl_Sources.TableNewRow, AddressOf Tbl_Sources_TableNewRow
    End Sub

    Private Sub Tbl_Tables_TableNewRow(sender As Object, e As DataTableNewRowEventArgs)
        With e.Row
            .Item("Role_Table") = "DET"
            .Item("Rang") = ProchainRang(Tbl_Tables, "Rang")
            .Item("Allow_Add") = "true" : .Item("Allow_Edit") = "true" : .Item("Allow_Delete") = "true"
            .Item("Allow_Duplicate") = "false"
            .Item("Regle_Suppression") = "CASCADE"
        End With
    End Sub

    Private Sub Tbl_Colonnes_TableNewRow(sender As Object, e As DataTableNewRowEventArgs)
        Dim dispo = CodTablesDisponibles()
        Dim defTable As String = If(dispo.Count > 0, dispo(0), "")
        With e.Row
            .Item("Cod_Table") = defTable
            .Item("Typ_Sql") = "nvarchar"
            .Item("Longueur") = 50
            .Item("Nullable") = "true"
            .Item("estUnique") = "false" : .Item("estIndexe") = "false"
            .Item("Rang") = ProchainRang(Tbl_Colonnes, "Rang", "Cod_Table", defTable)
        End With
    End Sub

    Private Sub Tbl_Champs_TableNewRow(sender As Object, e As DataTableNewRowEventArgs)
        With e.Row
            .Item("Cod_Table") = "ENT"
            .Item("Typ_Controle") = "TEXT"
            .Item("Rang") = ProchainRang(Tbl_Champs, "Rang")
            .Item("Obligatoire") = "false"
            .Item("Etat") = "S"
            .Item("Persiste") = "false"
            .Item("Visible_Grille") = "true"
            .Item("Rang_Grille") = ProchainRang(Tbl_Champs, "Rang_Grille")
            .Item("Total_Grille") = ""
            .Item("estCritere") = "false"
        End With
    End Sub

    Private Sub Tbl_Validations_TableNewRow(sender As Object, e As DataTableNewRowEventArgs)
        With e.Row
            .Item("Portee") = "CHAMP"
            .Item("Typ_Regle") = "REQUIRED"
            .Item("Niveau") = "B"
            .Item("Rang") = ProchainRang(Tbl_Validations, "Rang")
            .Item("Moment") = "SAVE"
            .Item("Actif") = "true"
        End With
    End Sub

    Private Sub Tbl_Droits_TableNewRow(sender As Object, e As DataTableNewRowEventArgs)
        With e.Row
            .Item("Consulter") = "true"
            .Item("Creer") = "false" : .Item("Modifier") = "false" : .Item("Supprimer") = "false"
            .Item("Valider") = "false" : .Item("Imprimer") = "false" : .Item("GED") = "false"
        End With
    End Sub

    Private Sub Tbl_Sources_TableNewRow(sender As Object, e As DataTableNewRowEventArgs)
        With e.Row
            .Item("Typ_Source") = "SQL"
            .Item("Typ_Retour") = "SCALAIRE"
            .Item("Cod_Profile") = ""
            .Item("Actif") = "true"
        End With
    End Sub

    ''' <summary>Prochain rang disponible dans une grille (max + 1, éventuellement filtré par table).</summary>
    Private Function ProchainRang(dt As DataTable, colRang As String, Optional colTable As String = "", Optional table As String = "") As Integer
        Dim m As Integer = 0
        If dt Is Nothing Then Return 1
        For Each r As DataRow In dt.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            If colTable <> "" AndAlso IsNull(r(colTable), "").ToString().Trim <> table Then Continue For
            Dim v As Integer = CInt(Val(IsNull(r(colRang), "0").ToString()))
            If v > m Then m = v
        Next
        Return m + 1
    End Function

    '---------------- Liste déroulante des tables (onglet Colonnes) ----------------

    ''' <summary>Codes des tables configurées (dans l'ordre de la grille, sans doublon).</summary>
    Private Function CodTablesDisponibles() As List(Of String)
        Dim lst As New List(Of String)
        If Tbl_Tables Is Nothing Then Return lst
        For Each r As DataRow In Tbl_Tables.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            Dim ct As String = IsNull(r("Cod_Table"), "").Trim
            If ct <> "" AndAlso Not lst.Contains(ct) Then lst.Add(ct)
        Next
        Return lst
    End Function

    ''' <summary>Remplace les éléments d'une liste déroulante si le contenu a changé
    ''' (évite de perturber la grille en cours d'édition).</summary>
    Private Sub MajItemsCombo(col As DataGridViewComboBoxColumn, valeurs As List(Of String))
        If col Is Nothing Then Return
        Dim actuels As New List(Of String)
        For Each it As Object In col.Items : actuels.Add(IsNull(it, "").ToString()) : Next
        If String.Join("|", actuels) = String.Join("|", valeurs) Then Return
        col.Items.Clear()
        For Each v As String In valeurs : col.Items.Add(v) : Next
    End Sub

    ''' <summary>Alimente les listes déroulantes 'Table' (colonnes, champs, validations)
    ''' avec les tables configurées dans l'onglet Tables.</summary>
    Private Sub MajCombosDependantes()
        Dim dispo = CodTablesDisponibles()
        MajItemsCombo(TryCast(Grd_Colonnes.Columns("col_Cod_Table"), DataGridViewComboBoxColumn), dispo)
        MajItemsCombo(TryCast(Grd_Champs.Columns("col_Cod_Table"), DataGridViewComboBoxColumn), dispo)
        ' Validations : la table est facultative ('' = règle globale / entête)
        Dim avecVide As New List(Of String) From {""}
        avecVide.AddRange(dispo)
        MajItemsCombo(TryCast(Grd_Validations.Columns("col_Cod_Table"), DataGridViewComboBoxColumn), avecVide)
    End Sub

    ''' <summary>Alimente la liste déroulante 'Source métier' des champs : catalogue en
    ''' base (sources actives) union les lignes en cours d'édition de la grille Sources.</summary>
    Private Sub MajComboSources()
        Dim dispo As New List(Of String) From {""}
        Dim tbl As DataTable = DATA_READER_GRD("select Cod_Source from SP_Page_Source where isnull(Actif,'true')='true' order by Cod_Source")
        For Each r As DataRow In tbl.Rows
            Dim cs As String = IsNull(r("Cod_Source"), "").Trim
            If cs <> "" AndAlso Not dispo.Contains(cs) Then dispo.Add(cs)
        Next
        If Tbl_Sources IsNot Nothing Then
            For Each r As DataRow In Tbl_Sources.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                Dim cs As String = IsNull(r("Cod_Source"), "").Trim
                If cs <> "" AndAlso Not dispo.Contains(cs) Then dispo.Add(cs)
            Next
        End If
        MajItemsCombo(TryCast(Grd_Champs.Columns("col_Source_Metier"), DataGridViewComboBoxColumn), dispo)
    End Sub

    ''' <summary>Alimente la liste déroulante 'Profil requis' du catalogue des sources
    ''' ('' = tous profils) avec les profils déclarés (Controle_Profile).</summary>
    Private Sub MajComboProfilsSources()
        Dim dispo As New List(Of String) From {""}
        Dim tbl As DataTable = DATA_READER_GRD("select Cod_Profile from Controle_Profile order by Cod_Profile")
        For Each r As DataRow In tbl.Rows
            Dim cp As String = IsNull(r("Cod_Profile"), "").Trim
            If cp <> "" AndAlso Not dispo.Contains(cp) Then dispo.Add(cp)
        Next
        MajItemsCombo(TryCast(Grd_Sources.Columns("col_Cod_Profile"), DataGridViewComboBoxColumn), dispo)
    End Sub

    Private Sub Grd_Sources_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Sources.CellEndEdit
        MajComboSources()
    End Sub

    Private Sub Grd_Sources_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Grd_Sources.RowsRemoved
        MajComboSources()
    End Sub

    ''' <summary>Après édition d'un code table : majuscules, régénération des noms
    ''' physiques (et du rôle) + mise à jour des listes déroulantes dépendantes.</summary>
    Private Sub Grd_Tables_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Tables.CellEndEdit
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If Grd_Tables.Columns(e.ColumnIndex).DataPropertyName <> "Cod_Table" Then Return
        Dim v As String = IsNull(Grd_Tables.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, "").Trim
        If v <> "" AndAlso v <> v.ToUpper() Then Grd_Tables.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = v.ToUpper()
        MajNomsPhysiques()
        MajCombosDependantes()
    End Sub

    Private Sub Grd_Tables_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Grd_Tables.RowsRemoved
        If Tbl_Tables Is Nothing Then Return
        MajNomsPhysiques()
        MajCombosDependantes()
    End Sub

    '---------------- Suppression contrôlée (sélection par l'en-tête de ligne + Suppr) ----------------

    ''' <summary>Suppression d'une table : interdite pour ENT, bloquée si des colonnes,
    ''' champs ou validations la référencent encore.</summary>
    Private Sub Grd_Tables_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles Grd_Tables.UserDeletingRow
        If e.Row Is Nothing OrElse e.Row.IsNewRow Then Return
        Dim ct As String = IsNull(e.Row.Cells("col_Cod_Table").Value, "").Trim
        If ct = "" Then Return
        If ct.Equals("ENT", StringComparison.OrdinalIgnoreCase) Then
            ShowMessageBox("La table d'entête (ENT) est obligatoire : elle ne peut pas être supprimée.", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            e.Cancel = True
            Return
        End If
        Dim nbColonnes As Integer = 0, nbChamps As Integer = 0, nbValidations As Integer = 0
        For Each r As DataRow In Tbl_Colonnes.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            If IsNull(r("Cod_Table"), "").Trim.Equals(ct, StringComparison.OrdinalIgnoreCase) Then nbColonnes += 1
        Next
        For Each r As DataRow In Tbl_Champs.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            If IsNull(r("Cod_Table"), "ENT").Trim.Equals(ct, StringComparison.OrdinalIgnoreCase) Then nbChamps += 1
        Next
        For Each r As DataRow In Tbl_Validations.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            If IsNull(r("Cod_Table"), "").Trim.Equals(ct, StringComparison.OrdinalIgnoreCase) Then nbValidations += 1
        Next
        If nbColonnes + nbChamps + nbValidations > 0 Then
            Dim details As New List(Of String)
            If nbColonnes > 0 Then details.Add(nbColonnes & " colonne(s)")
            If nbChamps > 0 Then details.Add(nbChamps & " champ(s)")
            If nbValidations > 0 Then details.Add(nbValidations & " validation(s)")
            ShowMessageBox("La table '" & ct & "' est référencée par " & String.Join(", ", details) & "." & vbCrLf &
                           "Supprimez d'abord ces éléments.", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    ''' <summary>Suppression d'une colonne physique : bloquée si des champs de la page
    ''' (onglet 'Conception de la page') l'utilisent encore.</summary>
    Private Sub Grd_Colonnes_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles Grd_Colonnes.UserDeletingRow
        If e.Row Is Nothing OrElse e.Row.IsNewRow Then Return
        Dim ct As String = IsNull(e.Row.Cells("col_Cod_Table").Value, "").Trim
        Dim nc As String = IsNull(e.Row.Cells("col_Nom_Colonne").Value, "").Trim
        If ct = "" OrElse nc = "" Then Return
        Dim champsLies As New List(Of String)
        For Each r As DataRow In Tbl_Champs.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            If IsNull(r("Cod_Table"), "ENT").Trim.Equals(ct, StringComparison.OrdinalIgnoreCase) AndAlso
               IsNull(r("Nom_Colonne"), "").Trim.Equals(nc, StringComparison.OrdinalIgnoreCase) Then
                Dim cc As String = IsNull(r("Cod_Champ"), "").Trim
                If cc <> "" AndAlso Not champsLies.Contains(cc) Then champsLies.Add(cc)
            End If
        Next
        If champsLies.Count > 0 Then
            ShowMessageBox("La colonne '" & ct & "." & nc & "' est utilisée par le(s) champ(s) : " & String.Join(", ", champsLies) & "." & vbCrLf &
                           "Supprimez d'abord ces champs (onglet 'Conception de la page').", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    '---------------- Habilitations par profil (onglet dédié, périmètre page) ----------------

    ''' <summary>Active/désactive la colonne 'Consulter' selon l'option 'Accès
    ''' personnalisé' : décochée, la consultation est ouverte à tous les profils
    ''' (y compris ceux créés ultérieurement) et la colonne est sans objet.</summary>
    Private Sub MajEtatColonneConsulter()
        If Grd_Droits Is Nothing OrElse Grd_Droits.Columns.Count = 0 Then Return
        Dim col As DataGridViewColumn = Grd_Droits.Columns("col_Consulter")
        If col Is Nothing Then Return
        Dim perso As Boolean = Acces_Personnalise_chk.Checked
        col.ReadOnly = Not perso
        col.DefaultCellStyle.BackColor = If(perso, Color.White, StyleCellAuto().BackColor)
    End Sub

    Private Sub Acces_Personnalise_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Acces_Personnalise_chk.CheckedChanged
        MajEtatColonneConsulter()
    End Sub

    ' Colonne d'habilitation ciblée par le clic droit (menu cocher/décocher pour tous)
    Private colDroitsCible As String = ""
    Private Const DROITS_COCHEABLES As String = "|Consulter|Creer|Modifier|Supprimer|Valider|Imprimer|GED|"

    ''' <summary>Menu contextuel de la grille des habilitations : appliquer une
    ''' habilitation à tous les profils en une fois.</summary>
    Private Sub BrancherMenuDroits()
        Dim menu As New ContextMenuStrip()
        menu.Items.Add("Cocher pour tous les profils", Nothing, AddressOf DroitsCocherPourTous)
        menu.Items.Add("Décocher pour tous les profils", Nothing, AddressOf DroitsCocherPourTous)
        AddHandler menu.Opening, AddressOf DroitsMenuOpening
        Grd_Droits.ContextMenuStrip = menu
    End Sub

    Private Sub Grd_Droits_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Droits.CellMouseDown
        If e.Button <> MouseButtons.Right OrElse e.ColumnIndex < 0 Then Return
        colDroitsCible = ""
        Dim prop As String = Grd_Droits.Columns(e.ColumnIndex).DataPropertyName
        If DROITS_COCHEABLES.Contains("|" & prop & "|") Then
            colDroitsCible = prop
            If e.RowIndex >= 0 Then Grd_Droits.CurrentCell = Grd_Droits.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub

    Private Sub DroitsMenuOpening(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim menu = DirectCast(sender, ContextMenuStrip)
        Dim actif As Boolean = colDroitsCible <> "" AndAlso (colDroitsCible <> "Consulter" OrElse Acces_Personnalise_chk.Checked)
        e.Cancel = Not actif
        If actif Then
            Dim entete As String = Grd_Droits.Columns("col_" & colDroitsCible).HeaderText
            menu.Items(0).Text = "Cocher '" & entete & "' pour tous les profils"
            menu.Items(1).Text = "Décocher '" & entete & "' pour tous les profils"
        End If
    End Sub

    Private Sub DroitsCocherPourTous(sender As Object, e As EventArgs)
        If colDroitsCible = "" Then Return
        Dim valeur As String = If(DirectCast(sender, ToolStripItem).Text.StartsWith("Décocher"), "false", "true")
        Grd_Droits.EndEdit()
        For Each r As DataRow In Tbl_Droits.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            r(colDroitsCible) = valeur
        Next
    End Sub

    ''' <summary>Valide immédiatement la case cochée/décochée (sinon la modification
    ''' resterait en cours d'édition au prochain clic).</summary>
    Private Sub Grd_Droits_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Droits.CellContentClick
        If e.ColumnIndex >= 0 AndAlso TypeOf Grd_Droits.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
            Grd_Droits.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    '---------------- Zooms de sélection (Rubrique / N° Zoom des champs) ----------------

    ''' <summary>Double-clic sur une cellule 'Rubrique' ou 'N° Zoom' (lecture seule) :
    ''' ouvre le zoom de sélection correspondant ; la valeur choisie est forcément valide.</summary>
    Private Sub Grd_Champs_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Champs.CellDoubleClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If Grd_Champs.Rows(e.RowIndex).IsNewRow Then Return
        Dim prop As String = Grd_Champs.Columns(e.ColumnIndex).DataPropertyName
        If prop = "Rubrique" Then
            OuvrirZoomCellule(Grd_Champs.Rows(e.RowIndex).Cells(e.ColumnIndex), "Sélection d'une rubrique",
                              "select Nom_Controle as [Rubrique], count(*) as [Nb valeurs] from Param_Rubriques group by Nom_Controle order by Nom_Controle")
        ElseIf prop = "Num_Zoom" Then
            OuvrirZoomCellule(Grd_Champs.Rows(e.RowIndex).Cells(e.ColumnIndex), "Sélection d'un zoom",
                              "select Num_Zoom as [N° Zoom], Description as [Description], Table_Ref as [Table référence] from Controle_Def_Zoom order by Num_Zoom")
        End If
    End Sub

    ''' <summary>Ouvre un Zoom_Libre dont la sélection (double-clic) alimente la cellule
    ''' cible (cas 'DataGridViewTextBoxCell' géré par Zoom_Libre ; bouton gomme = effacer).</summary>
    Private Sub OuvrirZoomCellule(cell As DataGridViewCell, titre As String, sql As String)
        Dim Z As New Zoom_Libre
        With Z
            .Text = titre
            .ZoomObject = cell
            .Libre_GRD.DataSource = DATA_READER_GRD(sql)
            .Libre_GRD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .Libre_GRD.ReadOnly = True
            .ShowDialog()
        End With
    End Sub

    '---------------- Garde : les tables avant les colonnes ----------------

    ''' <summary>Contrôles bloquants avant l'accès à l'onglet Colonnes : code document
    ''' renseigné, tables présentes, codes valides, ENT unique, pas de doublon.</summary>
    Private Function VerifierTablesAvantColonnes() As List(Of String)
        Dim pb As New List(Of String)
        If Cod_Document_txt.Text.Trim = "" Then
            pb.Add("Le code document est obligatoire : il pilote les noms physiques des tables.")
        End If
        Dim nb As Integer = 0, nbEnt As Integer = 0
        Dim vus As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        If Tbl_Tables IsNot Nothing Then
            For Each r As DataRow In Tbl_Tables.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                nb += 1
                Dim ct As String = IsNull(r("Cod_Table"), "").Trim
                If ct = "" Then
                    pb.Add("Une ligne de table n'a pas de code (colonne 'Table').")
                    Continue For
                End If
                Dim v = ValiderIdentifiantSql(ct)
                If v <> "" Then pb.Add(v)
                If Not vus.Add(ct) Then pb.Add("Table en doublon : '" & ct & "'.")
                If ct.Equals("ENT", StringComparison.OrdinalIgnoreCase) Then nbEnt += 1
            Next
        End If
        If nb = 0 Then pb.Add("Renseignez d'abord les tables (onglet 'Tables').")
        If nb > 0 AndAlso nbEnt <> 1 Then pb.Add("Il doit y avoir exactement une table d'entête (Cod_Table = ENT).")
        Return pb
    End Function

    ''' <summary>Bloque l'accès à l'onglet 'Colonnes physiques' tant que les tables
    ''' ne sont pas valablement renseignées, et alimente la liste des tables.</summary>
    Private Sub TabControl_Details_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl_Details.Selecting
        If e.TabPage IsNot Tab_Colonnes Then Return
        Grd_Tables.EndEdit()
        MajNomsPhysiques()
        Dim problemes = VerifierTablesAvantColonnes()
        If problemes.Count > 0 Then
            ShowMessageBox("Avant de saisir les colonnes, corrigez l'onglet 'Tables' :" & vbCrLf &
                           " - " & String.Join(vbCrLf & " - ", problemes),
                           "Tables", MessageBoxButtons.OK, msgIcon.Warning)
            e.Cancel = True
            Return
        End If
        MajCombosDependantes()
    End Sub

    Private Function SqlV(v As Object) As String
        Return "'" & IsNull(v, "").ToString().Replace("'", "''") & "'"
    End Function
    ''' <summary>Littéral numérique SQL : NULL si vide (évite les conversions '' -> int).</summary>
    Private Function SqlN(v As Object) As String
        Dim s As String = IsNull(v, "").ToString().Trim
        If s = "" Then Return "NULL"
        Dim d As Double
        If Double.TryParse(s.Replace(",", "."), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, d) Then
            Return d.ToString(Globalization.CultureInfo.InvariantCulture)
        End If
        Return "NULL"
    End Function
    Private Function B(valeur As Boolean) As String
        Return If(valeur, "true", "false")
    End Function

    Function Saving() As savingResult
        '---------------- Validations de saisie ----------------
        Dim codPage As String = Cod_Page_txt.Text.Trim
        Dim codDoc As String = Cod_Document_txt.Text.Trim
        If Not Regex.IsMatch(codPage, "^[A-Za-z_][A-Za-z0-9_]{2,29}$") OrElse codPage.StartsWith("Page") Then
            Return New savingResult With {.result = False, .message = "Code page invalide (lettres/chiffres/_, 3 à 30 caractères, ne commence pas par 'Page')."}
        End If
        If Not Regex.IsMatch(codDoc, "^[A-Za-z][A-Za-z0-9]{1,9}$") Then
            Return New savingResult With {.result = False, .message = "Code document invalide (2 à 10 caractères alphanumériques)."}
        End If
        If Nom_Page_txt.Text.Trim = "" Then
            Return New savingResult With {.result = False, .message = "Le nom de la page est obligatoire."}
        End If
        If IsNull(Menu_Parent_cmb.SelectedValue, "").ToString().Trim = "" Then
            Return New savingResult With {.result = False, .message = "Section du menu portail obligatoire."}
        End If
        If Workflow_Actif_chk.Checked AndAlso Not Regex.IsMatch(Typ_Document_txt.Text.Trim, "^[A-Za-z0-9]{2}$") Then
            Return New savingResult With {.result = False, .message = "Le type de document workflow doit faire 2 caractères."}
        End If
        MajNomsPhysiques()
        '---------------- Validations des grilles ----------------
        ' (domaines partagés avec les listes déroulantes des grilles)
        Dim nbEnt As Integer = 0
        Dim tablesVues As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim nomsPhysiques As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each r As DataRow In Tbl_Tables.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            Dim ct As String = IsNull(r("Cod_Table"), "").Trim
            If ValiderIdentifiantSql(ct) <> "" Then
                Return New savingResult With {.result = False, .message = "Cod_Table invalide : '" & ct & "'"}
            End If
            If Not tablesVues.Add(ct) Then
                Return New savingResult With {.result = False, .message = "Table en doublon : '" & ct & "' (les codes de table doivent être uniques)."}
            End If
            If ct.Equals("ENT", StringComparison.OrdinalIgnoreCase) Then nbEnt += 1
            Dim role As String = IsNull(r("Role_Table"), "").Trim
            If role <> "ENT" AndAlso role <> "DET" Then
                Return New savingResult With {.result = False, .message = "Rôle invalide ('" & role & "') pour la table '" & ct & "' : ENT ou DET attendu."}
            End If
            Dim regle As String = IsNull(r("Regle_Suppression"), "CASCADE").Trim
            If regle <> "CASCADE" AndAlso regle <> "RESTRICT" Then
                Return New savingResult With {.result = False, .message = "Règle de suppression invalide ('" & regle & "') pour la table '" & ct & "' : CASCADE ou RESTRICT attendu."}
            End If
            Dim np As String = IsNull(r("Nom_Physique"), "").Trim
            Dim v = ValiderNomTableMetier(np)
            If v <> "" Then Return New savingResult With {.result = False, .message = v}
            If Not nomsPhysiques.Add(np) Then
                Return New savingResult With {.result = False, .message = "Nom physique en doublon : '" & np & "'."}
            End If
            ' Le nom physique est globalement unique (UQ_SP_Page_Table_Nom)
            If CnExecuting("select count(*) from SP_Page_Table where Nom_Physique=" & SqlV(np) & " and Cod_Page<>" & SqlV(codPage)).Fields(0).Value > 0 Then
                Return New savingResult With {.result = False, .message = "Le nom physique '" & np & "' est déjà utilisé par une autre page."}
            End If
            ' Table physique orpheline : sa création échouerait et son rattachement serait risqué
            If TableExiste(np) AndAlso CnExecuting("select count(*) from SP_Page_Table where Nom_Physique=" & SqlV(np)).Fields(0).Value = 0 Then
                Return New savingResult With {.result = False, .message = "La table '" & np & "' existe déjà dans la base sans être rattachée à une page : choisissez un autre code document."}
            End If
        Next
        If nbEnt <> 1 Then
            Return New savingResult With {.result = False, .message = "Il doit y avoir exactement une table d'entête (Cod_Table = ENT)."}
        End If
        Dim colonnesTechniques As String() = {"RowId", "Num_Doc", "id_Societe", "Statut", "Dat_Crea", "Created_By", "Dat_Modif", "Modified_By", "RV"}
        Dim colonnesVues As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each r As DataRow In Tbl_Colonnes.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            Dim ct As String = IsNull(r("Cod_Table"), "").Trim
            Dim nc As String = IsNull(r("Nom_Colonne"), "").Trim
            If ct = "" OrElse Not tablesVues.Contains(ct) Then
                Return New savingResult With {.result = False, .message = "La colonne '" & nc & "' est rattachée à une table non configurée : '" & ct & "'."}
            End If
            Dim v = ValiderIdentifiantSql(nc)
            If v <> "" Then Return New savingResult With {.result = False, .message = v}
            If colonnesTechniques.Contains(nc, StringComparer.OrdinalIgnoreCase) Then
                Return New savingResult With {.result = False, .message = "'" & nc & "' est une colonne technique (ajoutée automatiquement) : retirez-la de la configuration."}
            End If
            If Not colonnesVues.Add(ct & "." & nc) Then
                Return New savingResult With {.result = False, .message = "Colonne en doublon : '" & ct & "." & nc & "'."}
            End If
            If Not TYPES_SQL.Contains(LCase(IsNull(r("Typ_Sql"), ""))) Then
                Return New savingResult With {.result = False, .message = "Type SQL invalide pour la colonne " & nc}
            End If
        Next
        ' Une table configurée sans aucune colonne déclarée est une erreur de
        ' conception : elle générerait une table métier vide (inutilisable).
        For Each r As DataRow In Tbl_Tables.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            Dim ctSansCol As String = IsNull(r("Cod_Table"), "").Trim
            If ctSansCol = "" Then Continue For
            Dim aColonne As Boolean = False
            For Each c As DataRow In Tbl_Colonnes.Rows
                If c.RowState = DataRowState.Deleted Then Continue For
                If IsNull(c("Cod_Table"), "").Trim.Equals(ctSansCol, StringComparison.OrdinalIgnoreCase) Then
                    aColonne = True : Exit For
                End If
            Next
            If Not aColonne Then
                Return New savingResult With {.result = False, .message = "La table '" & ctSansCol & "' n'a aucune colonne déclarée (onglet 'Colonnes physiques')."}
            End If
        Next
        Dim champsVus As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each r As DataRow In Tbl_Champs.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            Dim cc As String = IsNull(r("Cod_Champ"), "").Trim
            If ValiderIdentifiantSql(cc) <> "" OrElse ValiderIdentifiantSql(IsNull(r("Nom_Colonne"), "")) <> "" Then
                Return New savingResult With {.result = False, .message = "Champ invalide : " & cc}
            End If
            If Not champsVus.Add(cc) Then
                Return New savingResult With {.result = False, .message = "Champ en doublon : '" & cc & "'."}
            End If
            Dim ctCh As String = IsNull(r("Cod_Table"), "ENT").Trim
            If ctCh = "" Then ctCh = "ENT"
            If Not tablesVues.Contains(ctCh) Then
                Return New savingResult With {.result = False, .message = "Le champ '" & cc & "' référence une table non configurée : '" & ctCh & "'."}
            End If
            If Not TYPES_CONTROLE.Contains(IsNull(r("Typ_Controle"), "")) Then
                Return New savingResult With {.result = False, .message = "Type de contrôle invalide pour le champ " & cc}
            End If
            If IsNull(r("Typ_Controle"), "") = "ZOOM" AndAlso IsNull(r("Num_Zoom"), "").Trim = "" Then
                Return New savingResult With {.result = False, .message = "Le champ " & cc & " est un Zoom : le numéro de zoom est obligatoire."}
            End If
            If IsNull(r("Typ_Controle"), "") = "RUBRIQUE" AndAlso IsNull(r("Rubrique"), "").Trim = "" Then
                Return New savingResult With {.result = False, .message = "Le champ " & cc & " est une rubrique : le nom de rubrique est obligatoire."}
            End If
            If Not ETATS.Contains(IsNull(r("Etat"), "S")) Then
                Return New savingResult With {.result = False, .message = "Etat invalide (S/R/A/I) pour le champ " & cc}
            End If
        Next
        Dim validationsVues As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each r As DataRow In Tbl_Validations.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            Dim cv As String = IsNull(r("Cod_Validation"), "").Trim
            If Not PORTEES.Contains(IsNull(r("Portee"), "")) OrElse Not TYPES_REGLE.Contains(IsNull(r("Typ_Regle"), "")) Then
                Return New savingResult With {.result = False, .message = "Validation invalide : " & cv}
            End If
            If Not validationsVues.Add(cv) Then
                Return New savingResult With {.result = False, .message = "Validation en doublon : '" & cv & "'."}
            End If
            Dim ctV As String = IsNull(r("Cod_Table"), "").Trim
            If ctV <> "" AndAlso Not tablesVues.Contains(ctV) Then
                Return New savingResult With {.result = False, .message = "La validation '" & cv & "' référence une table non configurée : '" & ctV & "'."}
            End If
            If IsNull(r("Message"), "").Trim = "" Then
                Return New savingResult With {.result = False, .message = "Message obligatoire pour la validation " & cv}
            End If
        Next
        Dim profilsVus As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each r As DataRow In Tbl_Droits.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            Dim cp As String = IsNull(r("Cod_Profile"), "").Trim
            If cp = "" Then Continue For
            If Not profilsVus.Add(cp) Then
                Return New savingResult With {.result = False, .message = "Profil en doublon dans les habilitations : '" & cp & "'."}
            End If
        Next

        '---------------- Écriture transactionnelle ----------------
        Dim enTransaction As Boolean = False
        Try
            Grd_Tables.EndEdit() : Grd_Colonnes.EndEdit() : Grd_Champs.EndEdit()
            Grd_Validations.EndEdit() : Grd_Droits.EndEdit() : Grd_Sources.EndEdit()
            cn.BeginTrans()
            enTransaction = True
            ' 1. Entête de page : UPDATE si existant, INSERT sinon.
            '    (Jamais de DELETE : SP_Page_DDL_Log référence Cod_Page - audit préservé.)
            '    Cod_Document et Table_Ent sont immuables ; le statut publié est préservé
            '    (le DDL généré étant non destructif, la publication n'est pas invalidée).
            Dim existeDeja As Boolean = (CnExecuting("select count(*) from SP_Page where Cod_Page=" & SqlV(codPage)).Fields(0).Value > 0)
            If existeDeja Then
                CnExecuting("update SP_Page set Libelle=" & SqlV(Nom_Page_txt.Text.Trim) & "," &
                            " Nom_Page=" & SqlV(Nom_Page_txt.Text.Trim) & ", Menu_Parent=" & SqlV(Menu_Parent_cmb.SelectedValue) & ", Rang=" & CInt(Rang_txt.Value) & "," &
                            " Icone=" & SqlV(IconeChoisie()) & ", Typ_Document=" & SqlV(Typ_Document_txt.Text.Trim) & ", Workflow_Actif=" & SqlV(B(Workflow_Actif_chk.Checked)) & "," &
                            " Cod_Modele_Edition=" & SqlV(Cod_Modele_Edition_txt.Text.Trim) & ", GED_Actif=" & SqlV(B(GED_Actif_chk.Checked)) & ", GED_Obligatoire=" & SqlV(B(GED_Obligatoire_chk.Checked)) & "," &
                            " Act_Enregistrer=" & SqlV(B(Act_Enregistrer_chk.Checked)) & ", Act_Soumettre=" & SqlV(B(Act_Soumettre_chk.Checked)) & "," &
                            " Act_Imprimer=" & SqlV(B(Act_Imprimer_chk.Checked)) & ", Act_Exporter=" & SqlV(B(Act_Exporter_chk.Checked)) & "," &
                            " Acces_Personnalise=" & SqlV(B(Acces_Personnalise_chk.Checked)) & "," &
                            " DDL_Genere='true', Dat_Modif=getdate(), Modified_By=" & SqlV(theUser.Login) & " where Cod_Page=" & SqlV(codPage))
            Else
                CnExecuting("insert into SP_Page (Cod_Page, Cod_Document, Libelle, Nom_Page, Menu_Parent, Rang, Icone, Statut_Page, Table_Ent, " &
                            "Typ_Document, Workflow_Actif, Cod_Modele_Edition, GED_Actif, GED_Obligatoire, " &
                            "Act_Enregistrer, Act_Soumettre, Act_Imprimer, Act_Exporter, Acces_Personnalise, DDL_Genere, Dat_Crea, Created_By, Dat_Modif, Modified_By) values (" &
                            SqlV(codPage) & "," & SqlV(codDoc) & "," & SqlV(Nom_Page_txt.Text.Trim) & "," &
                            SqlV(Nom_Page_txt.Text.Trim) & "," & SqlV(Menu_Parent_cmb.SelectedValue) & "," & CInt(Rang_txt.Value) & "," & SqlV(IconeChoisie()) & "," &
                            "'BROUILLON'," & SqlV(Table_Ent_txt.Text) & "," &
                            SqlV(Typ_Document_txt.Text.Trim) & "," & SqlV(B(Workflow_Actif_chk.Checked)) & "," & SqlV(Cod_Modele_Edition_txt.Text.Trim) & "," &
                            SqlV(B(GED_Actif_chk.Checked)) & "," & SqlV(B(GED_Obligatoire_chk.Checked)) & "," &
                            SqlV(B(Act_Enregistrer_chk.Checked)) & "," & SqlV(B(Act_Soumettre_chk.Checked)) & "," &
                            SqlV(B(Act_Imprimer_chk.Checked)) & "," & SqlV(B(Act_Exporter_chk.Checked)) & "," & SqlV(B(Acces_Personnalise_chk.Checked)) & ",'true', getdate(), " & SqlV(theUser.Login) & ", getdate(), " & SqlV(theUser.Login) & ")")
            End If
            ' 2. Purge des lignes filles (ordre imposé par les FK : SP_Page_Colonne
            '    référence SP_Page_Table, donc colonnes AVANT tables)
            CnExecuting("delete from SP_Page_Colonne where Cod_Page=" & SqlV(codPage))
            CnExecuting("delete from SP_Page_Champ where Cod_Page=" & SqlV(codPage))
            CnExecuting("delete from SP_Page_Validation where Cod_Page=" & SqlV(codPage))
            CnExecuting("delete from SP_Page_Droit where Cod_Page=" & SqlV(codPage))
            CnExecuting("delete from SP_Page_Table where Cod_Page=" & SqlV(codPage))
            ' 3. Tables
            For Each r As DataRow In Tbl_Tables.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                CnExecuting("insert into SP_Page_Table (Cod_Page, Cod_Table, Nom_Physique, Role_Table, Libelle, Rang, Allow_Add, Allow_Edit, Allow_Delete, Allow_Duplicate, Tri_Defaut, Regle_Suppression, Dat_Crea, Created_By) values (" &
                            SqlV(codPage) & "," & SqlV(r("Cod_Table")) & "," & SqlV(r("Nom_Physique")) & "," & SqlV(IsNull(r("Role_Table"), "DET")) & "," &
                            SqlV(r("Libelle")) & "," & Val(IsNull(r("Rang"), "1") & "") & "," & SqlV(IsNull(r("Allow_Add"), "true")) & "," & SqlV(IsNull(r("Allow_Edit"), "true")) & "," &
                            SqlV(IsNull(r("Allow_Delete"), "true")) & "," & SqlV(IsNull(r("Allow_Duplicate"), "false")) & "," & SqlV(r("Tri_Defaut")) & "," &
                            SqlV(IsNull(r("Regle_Suppression"), "CASCADE")) & ", getdate(), " & SqlV(theUser.Login) & ")")
            Next
            ' 4. Colonnes
            For Each r As DataRow In Tbl_Colonnes.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                CnExecuting("insert into SP_Page_Colonne (Cod_Page, Cod_Table, Nom_Colonne, Libelle, Typ_Sql, Longueur, Precision_Sql, Echelle_Sql, Nullable, Valeur_Defaut, estUnique, estIndexe, Technique, Rang, Dat_Crea, Created_By) values (" &
                            SqlV(codPage) & "," & SqlV(r("Cod_Table")) & "," & SqlV(r("Nom_Colonne")) & "," & SqlV(r("Libelle")) & "," & SqlV(LCase(IsNull(r("Typ_Sql"), "nvarchar"))) & "," &
                            SqlN(r("Longueur")) & "," & SqlN(r("Precision_Sql")) & "," & SqlN(r("Echelle_Sql")) & "," & SqlV(IsNull(r("Nullable"), "true")) & "," &
                            SqlV(r("Valeur_Defaut")) & "," & SqlV(IsNull(r("estUnique"), "false")) & "," & SqlV(IsNull(r("estIndexe"), "false")) & ", 'false'," &
                            Val(IsNull(r("Rang"), "1") & "") & ", getdate(), " & SqlV(theUser.Login) & ")")
            Next
            ' 5. Champs
            For Each r As DataRow In Tbl_Champs.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                CnExecuting("insert into SP_Page_Champ (Cod_Page, Cod_Champ, Cod_Table, Nom_Colonne, Libelle, Typ_Controle, Rang, Ligne, Colonne, Largeur, Valeur_Defaut, Obligatoire, Etat, " &
                            "Rubrique, Num_Zoom, Source_Metier, Formule, Persiste, Format_Affichage, Decimales, Visible_Grille, Rang_Grille, Largeur_Colonne, Total_Grille, estCritere, Rang_Critere, Aide, Dat_Crea, Created_By) values (" &
                            SqlV(codPage) & "," & SqlV(r("Cod_Champ")) & "," & SqlV(IsNull(r("Cod_Table"), "ENT")) & "," & SqlV(r("Nom_Colonne")) & "," & SqlV(r("Libelle")) & "," &
                            SqlV(r("Typ_Controle")) & "," & Val(IsNull(r("Rang"), "1") & "") & "," & SqlN(r("Ligne")) & "," & SqlN(r("Colonne")) & "," & SqlN(r("Largeur")) & "," &
                            SqlV(r("Valeur_Defaut")) & "," & SqlV(IsNull(r("Obligatoire"), "false")) & "," & SqlV(IsNull(r("Etat"), "S")) & "," &
                            SqlV(r("Rubrique")) & "," & SqlV(r("Num_Zoom")) & "," & SqlV(r("Source_Metier")) & "," & SqlV(r("Formule")) & "," & SqlV(IsNull(r("Persiste"), "false")) & "," &
                            SqlV(r("Format_Affichage")) & "," & SqlN(r("Decimales")) & "," & SqlV(IsNull(r("Visible_Grille"), "true")) & "," & Val(IsNull(r("Rang_Grille"), "1") & "") & "," &
                            SqlN(r("Largeur_Colonne")) & "," & SqlV(IsNull(r("Total_Grille"), "")) & "," & SqlV(IsNull(r("estCritere"), "false")) & "," & SqlN(r("Rang_Critere")) & "," & SqlV(r("Aide")) & ", getdate(), " & SqlV(theUser.Login) & ")")
            Next
            ' 6. Validations
            For Each r As DataRow In Tbl_Validations.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                CnExecuting("insert into SP_Page_Validation (Cod_Page, Cod_Validation, Portee, Cod_Table, Cod_Champ, Typ_Regle, Parametres, Condition_Regle, Message, Niveau, Rang, Moment, Actif, Dat_Crea, Created_By) values (" &
                            SqlV(codPage) & "," & SqlV(r("Cod_Validation")) & "," & SqlV(r("Portee")) & "," & SqlV(r("Cod_Table")) & "," & SqlV(r("Cod_Champ")) & "," &
                            SqlV(r("Typ_Regle")) & "," & SqlV(r("Parametres")) & "," & SqlV(r("Condition_Regle")) & "," & SqlV(r("Message")) & "," &
                            SqlV(IsNull(r("Niveau"), "B")) & "," & Val(IsNull(r("Rang"), "1") & "") & "," & SqlV(IsNull(r("Moment"), "SAVE")) & "," &
                            SqlV(IsNull(r("Actif"), "true")) & ", getdate(), " & SqlV(theUser.Login) & ")")
            Next
            ' 7. Droits (tous les profils sont listés dans la grille ; seuls les
            '    profils ayant au moins une habilitation cochée sont enregistrés :
            '    l'absence de ligne équivaut à aucun droit)
            For Each r As DataRow In Tbl_Droits.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                If IsNull(r("Cod_Profile"), "").Trim = "" Then Continue For
                Dim aDroit As Boolean = False
                For Each a As String In {"Consulter", "Creer", "Modifier", "Supprimer", "Valider", "Imprimer", "GED"}
                    If IsNull(r(a), "false") = "true" Then aDroit = True : Exit For
                Next
                If Not aDroit Then Continue For
                CnExecuting("insert into SP_Page_Droit (Cod_Page, Cod_Profile, Consulter, Creer, Modifier, Supprimer, Valider, Imprimer, GED, Dat_Crea, Created_By) values (" &
                            SqlV(codPage) & "," & SqlV(r("Cod_Profile")) & "," & SqlV(IsNull(r("Consulter"), "false")) & "," & SqlV(IsNull(r("Creer"), "false")) & "," &
                            SqlV(IsNull(r("Modifier"), "false")) & "," & SqlV(IsNull(r("Supprimer"), "false")) & "," & SqlV(IsNull(r("Valider"), "false")) & "," &
                            SqlV(IsNull(r("Imprimer"), "false")) & "," & SqlV(IsNull(r("GED"), "false")) & ", getdate(), " & SqlV(theUser.Login) & ")")
            Next
            ' 8. Catalogue des sources (global) : upsert par Cod_Source, jamais de suppression
            For Each r As DataRow In Tbl_Sources.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                If IsNull(r("Cod_Source"), "").Trim = "" Then Continue For
                CnExecuting("delete from SP_Page_Source where Cod_Source=" & SqlV(r("Cod_Source")))
                CnExecuting("insert into SP_Page_Source (Cod_Source, Libelle, Typ_Source, Code_Sql, Parametres, Typ_Retour, Cod_Profile, Actif, Dat_Crea, Created_By) values (" &
                            SqlV(r("Cod_Source")) & "," & SqlV(r("Libelle")) & "," & SqlV(IsNull(r("Typ_Source"), "SQL")) & "," & SqlV(r("Code_Sql")) & "," &
                            SqlV(r("Parametres")) & "," & SqlV(IsNull(r("Typ_Retour"), "SCALAIRE")) & "," & SqlV(IsNull(r("Cod_Profile"), "")) & "," &
                            SqlV(IsNull(r("Actif"), "true")) & ", getdate(), " & SqlV(theUser.Login) & ")")
            Next
            ' 9. Génération / migration des tables métier SP_ (même transaction)
            '    NB : génération depuis les grilles en mémoire (Tbl_Tables/Tbl_Colonnes) :
            '    aucune relecture en base pendant la transaction (évite le blocage sur
            '    les verrous posés par cn sur SP_Page_Table/SP_Page_Colonne).
            Dim messages As New List(Of String)
            Dim erreurs As New List(Of String)
            Dim script As String = GenererScriptPage(codPage, messages, erreurs, Tbl_Tables, Tbl_Colonnes)
            If erreurs.Count > 0 Then
                cn.RollbackTrans() : enTransaction = False
                Return New savingResult With {.result = False, .message = "Erreurs de configuration SQL :" & vbCrLf & String.Join(vbCrLf, erreurs)}
            End If
            If script.Trim <> "" Then
                ExecuterScriptDansTransaction(codPage, If(TableExiste("SP_Page"), "MIGRATE", "CREATE"), script)
            End If
            cn.CommitTrans() : enTransaction = False
            Dim msg As String = "Enregistré avec succès."
            If messages.Count > 0 Then msg &= vbCrLf & String.Join(vbCrLf, messages)
            Return New savingResult With {.result = True, .message = msg}
        Catch ex As Exception
            If enTransaction Then
                Try : cn.RollbackTrans() : Catch : End Try
            End If
            JournaliserDDL(codPage, "MIGRATE", "", "false", ex.Message)
            Return New savingResult With {.result = False, .message = ex.Message}
        End Try
    End Function

    Sub Deleting()
        Dim codPage As String = Cod_Page_txt.Text.Trim
        If codPage = "" Then Return
        Dim statut As String = IsNull(FindLibelle("Statut_Page", "Cod_Page", codPage, "SP_Page"), "")
        If statut <> "BROUILLON" Then
            ShowMessageBox("Seule une page en brouillon peut être supprimée. Passez-la en 'Désactivé' pour la retirer du portail." & vbCrLf &
                           "Les tables métier SP_ ne sont jamais supprimées par ce module.", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ShowMessageBox("Supprimer la configuration de la page '" & codPage & "' ?" & vbCrLf &
                          "Les tables métier physiques SP_ (et leurs données) sont conservées.", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from SP_Page_Colonne where Cod_Page=" & SqlV(codPage) &
                    " delete from SP_Page_Champ where Cod_Page=" & SqlV(codPage) &
                    " delete from SP_Page_Validation where Cod_Page=" & SqlV(codPage) &
                    " delete from SP_Page_Droit where Cod_Page=" & SqlV(codPage) &
                    " delete from SP_Page_Table where Cod_Page=" & SqlV(codPage) &
                    " delete from SP_Page_DDL_Log where Cod_Page=" & SqlV(codPage) &
                    " delete from SP_Page where Cod_Page=" & SqlV(codPage))
        Nouveau()
    End Sub

    ''' <summary>Aperçu du script DDL (généré depuis les grilles, aucune exécution).</summary>
    Sub ApercuDDL()
        Dim codPage As String = Cod_Page_txt.Text.Trim
        If codPage = "" Then Return
        MajNomsPhysiques()
        Dim messages As New List(Of String)
        Dim erreurs As New List(Of String)
        Dim script As String = GenererScriptPage(codPage, messages, erreurs, Tbl_Tables, Tbl_Colonnes)
        If erreurs.Count > 0 Then
            ShowMessageBox("Erreurs : " & vbCrLf & String.Join(vbCrLf, erreurs), "Aperçu DDL", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If script.Trim = "" AndAlso messages.Count = 0 Then
            script = "(Structure à jour : aucun changement DDL nécessaire.)"
        End If
        Dim Tbl As New DataTable
        Tbl.Columns.Add("Script / Messages")
        For Each m As String In messages : Tbl.Rows.Add("-- " & m) : Next
        For Each ligne As String In script.Split({vbCrLf}, StringSplitOptions.None)
            Tbl.Rows.Add(ligne.TrimEnd())
        Next
        Dim Z As New Zoom_Libre
        With Z
            .Text = "Aperçu DDL - " & codPage & " (non exécuté)"
            .Libre_GRD.DataSource = Tbl
            .Libre_GRD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .Libre_GRD.ReadOnly = True
            .ShowDialog()
        End With
    End Sub

    ''' <summary>
    ''' Publication contrôlée : contrôles de cohérence puis passage en PUBLIE.
    ''' Si la page est déjà publiée, propose la désactivation.
    ''' </summary>
    Sub Publier()
        Dim codPage As String = Cod_Page_txt.Text.Trim
        If codPage = "" Then Return
        Dim Tbl As DataTable = DATA_READER_GRD("select * from SP_Page where Cod_Page=" & SqlV(codPage))
        If Tbl.Rows.Count = 0 Then
            ShowMessageBox("Enregistrez la page avant de la publier.", "Publier", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        Dim statut As String = IsNull(Tbl.Rows(0)("Statut_Page"), "BROUILLON")
        If statut = "PUBLIE" Then
            If ShowMessageBox("La page est publiée. Voulez-vous la désactiver ?" & vbCrLf &
                              "Elle disparaîtra du portail (les documents saisis sont conservés).",
                              "Désactiver", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.OK Then
                CnExecuting("update SP_Page set Statut_Page='DESACTIVE', Dat_Modif=getdate(), Modified_By=" & SqlV(theUser.Login) & " where Cod_Page=" & SqlV(codPage))
                ShowMessageBox("Page désactivée.", "Publier", MessageBoxButtons.OK, msgIcon.Information)
                Request(codPage)
            End If
            Return
        End If
        '---------------- Contrôles de cohérence ----------------
        Dim erreurs As New List(Of String)
        ' 1. Existence des tables et colonnes physiques
        Dim tblT As DataTable = DATA_READER_GRD("select * from SP_Page_Table where Cod_Page=" & SqlV(codPage))
        For Each r As DataRow In tblT.Rows
            Dim np As String = IsNull(r("Nom_Physique"), "")
            If Not TableExiste(np) Then
                erreurs.Add("Table physique inexistante : " & np & " (enregistrez la page pour générer le DDL)")
                Continue For
            End If
            Dim existantes = ColonnesExistantes(np)
            Dim tblC As DataTable = DATA_READER_GRD("select Nom_Colonne from SP_Page_Colonne where Cod_Page=" & SqlV(codPage) & " and Cod_Table=" & SqlV(r("Cod_Table")) & " and isnull(Technique,'false')='false'")
            For Each rc As DataRow In tblC.Rows
                If Not existantes.Contains(IsNull(rc("Nom_Colonne"), "")) Then
                    erreurs.Add("Colonne " & np & ".[" & IsNull(rc("Nom_Colonne"), "") & "] inexistante en base")
                End If
            Next
        Next
        ' 2. Validité des champs : table/colonne existantes, zooms, rubriques, sources
        Dim tblCh As DataTable = DATA_READER_GRD("select * from SP_Page_Champ where Cod_Page=" & SqlV(codPage))
        For Each rc As DataRow In tblCh.Rows
            Dim ct As String = IsNull(rc("Cod_Table"), "ENT")
            If tblT.Select("Cod_Table='" & ct.Replace("'", "''") & "'").Length = 0 Then
                erreurs.Add("Champ " & IsNull(rc("Cod_Champ"), "") & " : table '" & ct & "' non configurée")
            End If
            If IsNull(rc("Num_Zoom"), "") <> "" AndAlso
               CnExecuting("select count(*) from Controle_Def_Zoom where Num_Zoom=" & SqlV(rc("Num_Zoom"))).Fields(0).Value = 0 Then
                erreurs.Add("Champ " & IsNull(rc("Cod_Champ"), "") & " : zoom '" & IsNull(rc("Num_Zoom"), "") & "' inexistant")
            End If
            If IsNull(rc("Rubrique"), "") <> "" AndAlso
               CnExecuting("select count(*) from Param_Rubriques where Nom_Controle=" & SqlV(rc("Rubrique"))).Fields(0).Value = 0 Then
                erreurs.Add("Champ " & IsNull(rc("Cod_Champ"), "") & " : rubrique '" & IsNull(rc("Rubrique"), "") & "' inexistante")
            End If
            If IsNull(rc("Source_Metier"), "") <> "" AndAlso
               CnExecuting("select count(*) from SP_Page_Source where Cod_Source=" & SqlV(rc("Source_Metier")) & " and isnull(Actif,'true')='true'").Fields(0).Value = 0 Then
                erreurs.Add("Champ " & IsNull(rc("Cod_Champ"), "") & " : source '" & IsNull(rc("Source_Metier"), "") & "' inexistante ou inactive")
            End If
        Next
        ' 3. Dépendance circulaire entre champs calculés
        Dim cycle As String = DetecterCycle(tblCh)
        If cycle <> "" Then erreurs.Add("Référence circulaire dans les calculs : " & cycle)
        ' 4. Habilitations présentes (sauf si la consultation est ouverte à tous :
        '    option 'Accès personnalisé' décochée)
        If IsNull(Tbl.Rows(0)("Acces_Personnalise"), "true") = "true" AndAlso
           CnExecuting("select count(*) from SP_Page_Droit where Cod_Page=" & SqlV(codPage) & " and isnull(Consulter,'false')='true'").Fields(0).Value = 0 Then
            erreurs.Add("Aucun profil n'a le droit 'Consulter' : la page serait invisible pour tous." & vbCrLf &
                        "(Onglet 'Habilitations par profil' : cochez 'Consulter' pour au moins un profil, ou décochez l'option 'Accès personnalisé'.)")
        End If
        ' 5. Menu déclaré
        If IsNull(Tbl.Rows(0)("Menu_Parent"), "") = "" Then erreurs.Add("Section du menu portail non renseignée.")
        ' 6. Workflow
        If IsNull(Tbl.Rows(0)("Workflow_Actif"), "false") = "true" AndAlso IsNull(Tbl.Rows(0)("Typ_Document"), "").Trim = "" Then
            erreurs.Add("Workflow actif mais type de document non renseigné.")
        End If
        If erreurs.Count > 0 Then
            ShowMessageBox("Publication impossible : " & vbCrLf & " - " & String.Join(vbCrLf & " - ", erreurs), "Publier", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        '---------------- Publication ----------------
        CnExecuting("update SP_Page set Statut_Page='PUBLIE', Dat_Publication=getdate(), Version_Page=isnull(Version_Page,1)+1, Dat_Modif=getdate(), Modified_By=" & SqlV(theUser.Login) & " where Cod_Page=" & SqlV(codPage))
        ' Enregistrement de l'écran portail (liaison GED : Name_Ecran + Value_Index)
        Dim nameEcran As String = "SPP_" & codPage
        Dim pj As String = If(IsNull(Tbl.Rows(0)("GED_Actif"), "false") = "true", "true", "false")
        If CnExecuting("select count(*) from Controle_Def_Ecran where Name_Ecran=" & SqlV(nameEcran)).Fields(0).Value = 0 Then
            CnExecuting("insert into Controle_Def_Ecran (Name_Ecran, Table_Ref, Index_Ecran, Num_Zoom, Index_Table, Modal, PJ, Info, Dat_Crea, Created_By) values (" &
                        SqlV(nameEcran) & "," & SqlV(Tbl.Rows(0)("Table_Ent")) & ",'Num_Doc','','Num_Doc','false'," & SqlV(pj) & ",'true', getdate(), " & SqlV(theUser.Login) & ")")
        Else
            CnExecuting("update Controle_Def_Ecran set Table_Ref=" & SqlV(Tbl.Rows(0)("Table_Ent")) & ", PJ=" & SqlV(pj) & " where Name_Ecran=" & SqlV(nameEcran))
        End If
        ' Déclaration du type de document au moteur de workflow existant
        If IsNull(Tbl.Rows(0)("Workflow_Actif"), "false") = "true" Then
            Dim typDoc As String = IsNull(Tbl.Rows(0)("Typ_Document"), "").Trim
            If CnExecuting("select count(*) from Param_Workflow_Typ_Document where Typ_Document=" & SqlV(typDoc)).Fields(0).Value = 0 Then
                CnExecuting("insert into Param_Workflow_Typ_Document (Typ_Document, Intitule, Table_Ref, Table_Index, Accepte_Detail, Name_Ecran, Index_Ecran, Champs_Proprietaire, id_Societe) values (" &
                            SqlV(typDoc) & "," & SqlV(Tbl.Rows(0)("Libelle")) & "," & SqlV(Tbl.Rows(0)("Table_Ent")) & ",'Num_Doc','false'," & SqlV(nameEcran) & ",'Num_Doc','Created_By', -1)")
            Else
                CnExecuting("update Param_Workflow_Typ_Document set Intitule=" & SqlV(Tbl.Rows(0)("Libelle")) & ", Table_Ref=" & SqlV(Tbl.Rows(0)("Table_Ent")) &
                            ", Name_Ecran=" & SqlV(nameEcran) & " where Typ_Document=" & SqlV(typDoc))
            End If
        End If
        ShowMessageBox("Page publiée avec succès." & vbCrLf & "Elle apparaît dans le portail à la section '" &
                       FindLibelle("Membre", "Valeur", IsNull(Tbl.Rows(0)("Menu_Parent"), ""), "Param_Rubriques") & "' (rang " & IsNull(Tbl.Rows(0)("Rang"), "99") & ").",
                       "Publier", MessageBoxButtons.OK, msgIcon.Information)
        Request(codPage)
    End Sub

    ''' <summary>
    ''' Détecte les références circulaires entre champs calculés
    ''' (graphe des {"ref":"X"} des formules, parcours DFS).
    ''' </summary>
    Private Function DetecterCycle(tblCh As DataTable) As String
        Dim deps As New Dictionary(Of String, List(Of String))
        Dim regexRef As New Regex("""ref""\s*:\s*""(?<r>\w+)""")
        For Each r As DataRow In tblCh.Rows
            If IsNull(r("Typ_Controle"), "") <> "CALCULE" Then Continue For
            Dim nom As String = IsNull(r("Nom_Colonne"), "")
            Dim lst As New List(Of String)
            For Each m As Match In regexRef.Matches(IsNull(r("Formule"), ""))
                lst.Add(m.Groups("r").Value)
            Next
            deps(nom) = lst
        Next
        Dim etat As New Dictionary(Of String, Integer) ' 0=absent 1=en cours 2=fait
        Dim cycle As String = ""
        Dim visiter As Action(Of String, List(Of String))
        visiter = Sub(nom As String, pile As List(Of String))
                      If cycle <> "" Then Return
                      If etat.ContainsKey(nom) AndAlso etat(nom) = 2 Then Return
                      If etat.ContainsKey(nom) AndAlso etat(nom) = 1 Then
                          cycle = String.Join(" -> ", pile) & " -> " & nom
                          Return
                      End If
                      etat(nom) = 1
                      If deps.ContainsKey(nom) Then
                          For Each d In deps(nom)
                              If deps.ContainsKey(d) Then visiter(d, New List(Of String)(pile) From {nom})
                              If cycle <> "" Then Return
                          Next
                      End If
                      etat(nom) = 2
                  End Sub
        For Each nom In deps.Keys
            visiter(nom, New List(Of String))
            If cycle <> "" Then Return cycle
        Next
        Return ""
    End Function
End Class
