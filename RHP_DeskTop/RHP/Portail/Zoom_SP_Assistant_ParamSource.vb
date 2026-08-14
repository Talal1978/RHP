Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

''' <summary>
''' Assistant de déclaration des paramètres d'une source métier (grille Grd_Sources
''' du SP_Page_Designer) : l'utilisateur saisit les paramètres de la requête SQL dans
''' une grille simple (nom, type, obligatoire) et la syntaxe json attendue par le
''' moteur (colonne Parametres de SP_Page_Source : [{"Nom":"X","Typ":"nvarchar",
''' "Obligatoire":true}]) est générée automatiquement - aucune saisie de code.
''' Interface : Zoom_SP_Assistant_ParamSource.Designer.vb (convention permanente :
''' tout le code de design est dans le .Designer.vb ; ce fichier ne contient que la
''' logique — génération du json, contrôles de cohérence avec la requête SQL,
''' événements — et l'alimentation des données).
''' </summary>
Public Class Zoom_SP_Assistant_ParamSource

    '---------------- Résultat (lu par l'appelant après DialogResult.OK) ----------------
    Public Parametres As String = ""

    Private _enMaj As Boolean = False          ' true pendant le chargement initial
    Private _uiPrete As Boolean = False        ' true une fois l'interface construite
    Private _modeAvance As Boolean = False     ' true si le json existant n'est pas représentable
    Private _paramsSql As New List(Of String)  ' @xxx réellement utilisés par la requête (vide si SQL absent)

    ' Paramètres injectés automatiquement par le serveur quand ils ne sont pas
    ' déclarés (executerSource) : id_Societe toujours ; Login / Matricule /
    ' Cod_Profile uniquement s'ils ne sont pas déclarés — les déclarer permet de
    ' les alimenter depuis un champ de la page (ex. matricule d'un autre salarié).
    Private Shared ReadOnly PARAMS_AUTO As String() = {"id_Societe", "Login", "Matricule", "Cod_Profile"}

    ' Types proposés (libellé français -> code json) ; le moteur distingue int / nvarchar
    Private Shared ReadOnly TYPES_PARAM As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"Texte (nvarchar)", "nvarchar"}, {"Nombre entier (int)", "int"},
        {"Nombre décimal (decimal)", "decimal"}, {"Date (date)", "date"},
        {"Date et heure (datetime)", "datetime"}, {"Oui/Non (bit)", "bit"}}

    ' (Contrôles et disposition : Zoom_SP_Assistant_ParamSource.Designer.vb)

    ''' <summary>Crée l'assistant. jsonExistant = contenu actuel de la cellule
    ''' 'Paramètres (json)' de la source ("" pour une nouvelle source) ;
    ''' codeSql = requête SQL de la source : la liste déroulante des noms de
    ''' paramètres est alimentée par les @xxx qu'elle utilise, et la cohérence
    ''' déclaration ↔ requête est contrôlée à l'application.</summary>
    Public Sub New(jsonExistant As String, Optional codeSql As String = "")
        InitializeComponent()
        ' Domaine de la colonne 'Type' (source unique : TYPES_PARAM) et noms @xxx
        ' détectés dans la requête (proposés par la colonne 'Nom')
        For Each k In TYPES_PARAM.Keys : colParTyp.Items.Add(k) : Next
        _paramsSql = ExtraireParamsSql(codeSql)
        For Each p In _paramsSql
            If Not colParNom.Items.Contains(p) Then colParNom.Items.Add(p)
        Next
        _uiPrete = True
        ChargerJson(jsonExistant)
        Regenerer()
    End Sub

    '---------------- Chargement du json existant ----------------

    ''' <summary>Traduit un libellé de type en code json (ou le texte brut si inconnu).</summary>
    Private Function CodeType(label As String) As String
        Dim code As String = ""
        If TYPES_PARAM.TryGetValue(label, code) Then Return code
        Return label
    End Function
    ''' <summary>Traduit un code json en libellé de type (ou le texte brut si inconnu).</summary>
    Private Function LabelType(code As String) As String
        For Each kv In TYPES_PARAM
            If kv.Value.Equals(code, StringComparison.OrdinalIgnoreCase) Then Return kv.Key
        Next
        Return code
    End Function

    Private Sub ChargerJson(jsonExistant As String)
        Dim src As String = IsNull(jsonExistant, "").Trim
        If src = "" Then Return
        Dim arr As JArray = Nothing
        Try
            arr = CType(JToken.Parse(src), JArray)
        Catch
            arr = Nothing
        End Try
        Dim ok As Boolean = arr IsNot Nothing
        If ok Then
            For Each t In arr
                Dim o = TryCast(t, JObject)
                If o Is Nothing OrElse o("Nom") Is Nothing Then ok = False : Exit For
            Next
        End If
        If Not ok Then
            ' Forme non représentable : mode avancé (json conservé / corrigible tel quel)
            _modeAvance = True
            grdParams.Visible = False
            lblJsonAvance.Visible = True
            txtJsonAvance.Visible = True
            txtJsonAvance.Text = src
            Return
        End If
        _enMaj = True
        For Each t In arr
            Dim o = CType(t, JObject)
            Dim lbl As String = LabelType(IsNull(o("Typ"), "nvarchar").ToString())
            If Not colParTyp.Items.Contains(lbl) Then colParTyp.Items.Add(lbl)
            Dim ob As Boolean = False
            If o("Obligatoire") IsNot Nothing Then
                Dim v As String = o("Obligatoire").ToString()
                ob = v.Equals("true", StringComparison.OrdinalIgnoreCase) OrElse v = "1"
            End If
            Dim nomP As String = o("Nom").ToString()
            If Not colParNom.Items.Contains(nomP) Then colParNom.Items.Add(nomP)   ' valeur existante hors liste (données anciennes)
            grdParams.Rows.Add(nomP, lbl, ob)
        Next
        _enMaj = False
    End Sub

    '---------------- Génération du json ----------------

    ''' <summary>Lit les lignes de la grille. Les lignes vides sont ignorées ; les
    ''' lignes sans nom mais avec d'autres valeurs sont comptées dans incompletes.</summary>
    Private Function LireLignes(ByRef incompletes As Integer) As List(Of JObject)
        Dim lst As New List(Of JObject)
        incompletes = 0
        For Each r As DataGridViewRow In grdParams.Rows
            If r.IsNewRow Then Continue For
            Dim nom As String = IsNull(r.Cells("colParNom").Value, "").Trim
            Dim typ As String = IsNull(r.Cells("colParTyp").Value, "").Trim
            Dim ob As Boolean = False
            If r.Cells("colParObli").Value IsNot Nothing Then
                Try : ob = CBool(r.Cells("colParObli").Value) : Catch : ob = False : End Try
            End If
            If nom = "" AndAlso typ = "" Then Continue For
            If nom = "" Then
                incompletes += 1
                Continue For
            End If
            Dim o As New JObject()
            o("Nom") = nom
            o("Typ") = If(typ <> "", CodeType(typ), "nvarchar")
            o("Obligatoire") = ob
            lst.Add(o)
        Next
        Return lst
    End Function

    Private Function ConstruireJson() As String
        If _modeAvance Then Return txtJsonAvance.Text.Trim
        Dim incompletes As Integer
        Dim lst = LireLignes(incompletes)
        If lst.Count = 0 Then Return ""
        Dim arr As New JArray()
        For Each o In lst : arr.Add(o) : Next
        Return arr.ToString(Formatting.None)
    End Function

    Private Sub Regenerer()
        If _enMaj Then Return
        Try
            txtParamJson.Text = ConstruireJson()
        Catch
        End Try
    End Sub

    '---------------- Validation et application ----------------

    '---------------- Cohérence déclaration ↔ requête SQL ----------------

    ''' <summary>Noms des paramètres @xxx réellement utilisés par la requête (hors
    ''' commentaires, littéraux et variables système @@...). Ce contrôle est vital :
    ''' une faute de frappe sur un nom spécial (Matricule, Login, Cod_Profile)
    ''' rebascule silencieusement sur l'injection de l'identité de l'utilisateur
    ''' connecté, et un @xxx non déclaré fait échouer l'exécution.</summary>
    Private Shared Function ExtraireParamsSql(codeSql As String) As List(Of String)
        Dim lst As New List(Of String)
        Dim code As String = IsNull(codeSql, "")
        If code.Trim = "" Then Return lst
        code = Regex.Replace(code, "/\*.*?\*/", "", RegexOptions.Singleline)
        code = Regex.Replace(code, "--.*?(\n|$)", " ")
        code = Regex.Replace(code, "'(?:[^']|'')*'", "''")
        For Each m As Match In Regex.Matches(code, "(?<!@)@([A-Za-z_][A-Za-z0-9_]*)")
            Dim nom As String = m.Groups(1).Value
            If Not lst.Contains(nom, StringComparer.OrdinalIgnoreCase) Then lst.Add(nom)
        Next
        Return lst
    End Function

    ''' <summary>Contrôles croisés entre les paramètres déclarés et les @xxx de la
    ''' requête : erreurs bloquantes (déclaré absent de la requête = faute de frappe
    ''' probable ; utilisé non déclaré et non injectable = échec d'exécution) et
    ''' avertissements non bloquants (injection automatique de l'identité connectée).</summary>
    Private Sub ControlerCoherenceSql(nomsDeclares As List(Of String), erreurs As List(Of String), avertissements As List(Of String))
        If _paramsSql.Count = 0 Then Return   ' requête non écrite : rien à croiser
        For Each nom In nomsDeclares
            If Not _paramsSql.Contains(nom, StringComparer.OrdinalIgnoreCase) Then
                erreurs.Add("'" & nom & "' est déclaré mais '@" & nom & "' n'apparaît pas dans la requête SQL (faute de frappe ?).")
            End If
        Next
        For Each p In _paramsSql
            If nomsDeclares.Contains(p, StringComparer.OrdinalIgnoreCase) Then Continue For
            If PARAMS_AUTO.Contains(p, StringComparer.OrdinalIgnoreCase) Then
                avertissements.Add("'@" & p & "' n'est pas déclaré : il sera injecté automatiquement avec l'identité de l'utilisateur connecté." & vbCrLf &
                                   "    Pour l'alimenter depuis un champ de la page (ex. matricule d'un autre salarié), déclarez-le ici et mappez-le.")
            Else
                erreurs.Add("'@" & p & "' est utilisé dans la requête mais n'est pas déclaré : l'exécution échouerait (variable SQL non déclarée).")
            End If
        Next
    End Sub

    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Dim erreurs As New List(Of String)
        Dim avertissements As New List(Of String)
        If _modeAvance Then
            Dim src As String = txtJsonAvance.Text.Trim
            If src <> "" Then
                Try
                    JToken.Parse(src)
                Catch
                    erreurs.Add("Le json du mode avancé est invalide.")
                End Try
            End If
        Else
            Dim incompletes As Integer
            Dim lst = LireLignes(incompletes)
            If incompletes > 0 Then erreurs.Add("Certaines lignes n'ont pas de nom : complétez-les ou supprimez-les.")
            Dim vus As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            Dim noms As New List(Of String)
            For Each o In lst
                Dim nom As String = o("Nom").ToString()
                noms.Add(nom)
                Dim v = ValiderIdentifiantSql(nom)
                If v <> "" Then erreurs.Add(v.Replace("identifiant", "nom de paramètre"))
                If nom.Equals("id_Societe", StringComparison.OrdinalIgnoreCase) Then
                    erreurs.Add("'id_Societe' est injecté automatiquement par le serveur : ne le déclarez pas.")
                End If
                If Not vus.Add(nom) Then erreurs.Add("Paramètre en doublon : '" & nom & "'.")
            Next
            ' Cohérence avec la requête SQL (piège de l'injection automatique)
            ControlerCoherenceSql(noms, erreurs, avertissements)
        End If
        If erreurs.Count > 0 Then
            ShowMessageBox("Corrigez les points suivants :" & vbCrLf & " - " & String.Join(vbCrLf & " - ", erreurs),
                           "Assistant", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        If avertissements.Count > 0 Then
            ShowMessageBox(String.Join(vbCrLf, avertissements), "Assistant", MessageBoxButtons.OK, msgIcon.Information)
        End If
        Me.Parametres = ConstruireJson()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Zoom_SP_Assistant_ParamSource_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    '---------------- Événements : régénération automatique de l'aperçu ----------------

    Private Sub grdParams_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles grdParams.DefaultValuesNeeded
        e.Row.Cells("colParTyp").Value = "Texte (nvarchar)"
        e.Row.Cells("colParObli").Value = True
    End Sub

    Private Sub grdParams_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles grdParams.CurrentCellDirtyStateChanged
        ' Valide immédiatement les cases à cocher / listes (sinon la valeur reste en cours d'édition)
        If grdParams.IsCurrentCellDirty Then grdParams.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub grdParams_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdParams.CellValueChanged
        If Not _uiPrete Then Return
        Regenerer()
    End Sub

    Private Sub grdParams_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles grdParams.RowsRemoved
        If Not _uiPrete Then Return
        Regenerer()
    End Sub

    ''' <summary>Une valeur hors liste (données anciennes) ne doit pas interrompre l'assistant.</summary>
    Private Sub grdParams_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles grdParams.DataError
        e.ThrowException = False
    End Sub

    ''' <summary>La colonne 'Nom' est une liste déroulante ÉDITABLE : elle propose les
    ''' @xxx détectés dans la requête SQL, tout en laissant la saisie libre possible
    ''' (requête pas encore écrite, cas particuliers) — la cohérence est contrôlée
    ''' à l'application.</summary>
    Private Sub grdParams_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grdParams.EditingControlShowing
        Dim combo = TryCast(e.Control, ComboBox)
        If combo Is Nothing OrElse grdParams.CurrentCell Is Nothing Then Return
        If grdParams.Columns(grdParams.CurrentCell.ColumnIndex).Name = "colParNom" Then
            combo.DropDownStyle = ComboBoxStyle.DropDown
        End If
    End Sub

    Private Sub txtJsonAvance_TextChanged(sender As Object, e As EventArgs) Handles txtJsonAvance.TextChanged
        If Not _uiPrete Then Return
        Regenerer()
    End Sub

End Class
