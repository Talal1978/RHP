Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

''' <summary>
''' Assistant d'alimentation d'une GRILLE VIRTUELLE (table de détail dont la
''' colonne 'Source métier' est renseignée dans le SP_Page_Designer) : pour
''' chaque paramètre déclaré de la source, l'utilisateur choisit comment il est
''' alimenté — un champ de l'entête du document ou une constante — et le mapping
''' json attendu par le moteur (SP_Page_Table.Source_Mapping :
''' {"Paramètre":{"ref":"ChampEntete"} | {"const":"valeur"}}) est généré
''' automatiquement - aucune saisie de code.
''' Interface : Zoom_SP_MappingSource.Designer.vb (convention permanente : tout
''' le code de design est dans le .Designer.vb ; ce fichier ne contient que la
''' logique - lecture des paramètres, génération du json, événements, résultat).
''' </summary>
Public Class Zoom_SP_MappingSource

    '---------------- Résultat (lu par l'appelant après DialogResult.OK) ----------------
    Public Mapping As String = ""

    Private _enMaj As Boolean = False          ' true pendant le chargement initial
    Private _uiPrete As Boolean = False        ' true une fois l'interface construite
    Private _modeAvance As Boolean = False     ' true si le mapping existant n'est pas représentable

    Private Const MODE_CHAMP As String = "Champ de l'entête"
    Private Const MODE_CONSTANTE As String = "Constante"
    Private Const MODE_AUCUN As String = "(non alimenté)"

    ''' <summary>Crée l'assistant. codTable / codSource : contexte (titre) ;
    ''' paramsJson : paramètres déclarés de la source (SP_Page_Source.Parametres) ;
    ''' champsEnt : colonnes de l'entête proposées (métier déclarées + techniques) ;
    ''' mappingExistant : contenu actuel de Source_Mapping ("" si aucun).</summary>
    Public Sub New(codTable As String, codSource As String, paramsJson As String, champsEnt As List(Of String), mappingExistant As String)
        InitializeComponent()
        Zoom_lbl.Text = "Alimentation de la grille '" & codTable & "' — source '" & codSource & "'"
        Dim colChamp = DirectCast(grdMap.Columns("colMapChamp"), DataGridViewComboBoxColumn)
        For Each c In champsEnt
            If c.Trim <> "" AndAlso Not colChamp.Items.Contains(c) Then colChamp.Items.Add(c)
        Next
        _uiPrete = True
        Charger(paramsJson, mappingExistant)
        Regenerer()
    End Sub

    '---------------- Chargement ----------------

    ''' <summary>Le mapping existant n'est pas représentable par la grille : bascule
    ''' en mode avancé (json conservé, corrigible tel quel).</summary>
    Private Sub BasculerModeAvance(json As String)
        _modeAvance = True
        grdMap.Visible = False
        pnlAvance.Visible = True
        txtAvance.Text = json
    End Sub

    ''' <summary>Alimente la grille : une ligne par paramètre déclaré de la source,
    ''' initialisée depuis le mapping existant (ou par homonymie paramètre ↔ champ
    ''' de l'entête pour une première configuration).</summary>
    Private Sub Charger(paramsJson As String, mappingExistant As String)
        Dim params As New List(Of JObject)
        Dim src As String = IsNull(paramsJson, "").Trim
        If src <> "" Then
            Try
                For Each t In CType(JToken.Parse(src), JArray)
                    Dim o = TryCast(t, JObject)
                    If o IsNot Nothing AndAlso o("Nom") IsNot Nothing Then params.Add(o)
                Next
            Catch
                params = New List(Of JObject)   ' paramètres illisibles : grille vide
            End Try
        End If
        Dim j As JObject = Nothing
        Dim mj As String = IsNull(mappingExistant, "").Trim
        If mj <> "" Then
            Try
                j = CType(JToken.Parse(mj), JObject)
            Catch
                j = Nothing
            End Try
            If j Is Nothing Then
                BasculerModeAvance(mj)
                Return
            End If
            ' Non représentable si une clé n'est pas un paramètre déclaré ou si une
            ' valeur n'est pas de la forme {"ref":...} / {"const":...}
            Dim noms As New List(Of String)
            For Each o In params : noms.Add(o("Nom").ToString()) : Next
            For Each p As JProperty In j.Properties()
                Dim d = TryCast(p.Value, JObject)
                If Not noms.Contains(p.Name, StringComparer.OrdinalIgnoreCase) OrElse
                   d Is Nothing OrElse (d("ref") Is Nothing AndAlso d("const") Is Nothing) Then
                    BasculerModeAvance(mj)
                    Return
                End If
            Next
        End If
        _enMaj = True
        Dim colChamp = DirectCast(grdMap.Columns("colMapChamp"), DataGridViewComboBoxColumn)
        For Each o In params
            Dim nom As String = o("Nom").ToString()
            Dim ob As Boolean = False
            If o("Obligatoire") IsNot Nothing Then
                Dim v As String = o("Obligatoire").ToString()
                ob = v.Equals("true", StringComparison.OrdinalIgnoreCase) OrElse v = "1"
            End If
            Dim mode As String = MODE_AUCUN
            Dim champ As String = ""
            Dim constante As String = ""
            Dim d As JObject = Nothing
            If j IsNot Nothing AndAlso j(nom) IsNot Nothing Then d = TryCast(j(nom), JObject)
            If d IsNot Nothing AndAlso d("ref") IsNot Nothing Then
                mode = MODE_CHAMP : champ = d("ref").ToString()
            ElseIf d IsNot Nothing AndAlso d("const") IsNot Nothing Then
                mode = MODE_CONSTANTE : constante = d("const").ToString()
            Else
                ' Pré-remplissage par homonymie : un champ de l'entête porte le nom du paramètre
                For Each it In colChamp.Items
                    If it.ToString().Equals(nom, StringComparison.OrdinalIgnoreCase) Then
                        mode = MODE_CHAMP : champ = it.ToString()
                        Exit For
                    End If
                Next
            End If
            If champ <> "" AndAlso Not colChamp.Items.Contains(champ) Then colChamp.Items.Add(champ)
            Dim idx As Integer = grdMap.Rows.Add(nom, ob, mode, champ, constante)
            MajEtatLigne(idx)
        Next
        _enMaj = False
    End Sub

    '---------------- Génération du json ----------------

    ''' <summary>Active la cellule 'Champ' ou 'Constante' selon le mode choisi.</summary>
    Private Sub MajEtatLigne(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= grdMap.Rows.Count Then Return
        Dim lig As DataGridViewRow = grdMap.Rows(rowIndex)
        Dim mode As String = IsNull(lig.Cells("colMapMode").Value, MODE_AUCUN)
        Dim styleAuto As New DataGridViewCellStyle With {.BackColor = Color.FromArgb(240, 243, 245), .ForeColor = Color.FromArgb(90, 90, 90)}
        With lig.Cells("colMapChamp")
            .ReadOnly = (mode <> MODE_CHAMP)
            .Style = If(mode <> MODE_CHAMP, styleAuto, New DataGridViewCellStyle())
        End With
        With lig.Cells("colMapConstante")
            .ReadOnly = (mode <> MODE_CONSTANTE)
            .Style = If(mode <> MODE_CONSTANTE, styleAuto, New DataGridViewCellStyle())
        End With
    End Sub

    Private Function ConstruireJson() As String
        If _modeAvance Then Return txtAvance.Text.Trim
        Dim o As New JObject()
        For Each r As DataGridViewRow In grdMap.Rows
            If r.IsNewRow Then Continue For
            Dim nom As String = IsNull(r.Cells("colMapParam").Value, "").Trim
            If nom = "" Then Continue For
            Dim mode As String = IsNull(r.Cells("colMapMode").Value, MODE_AUCUN)
            If mode = MODE_CHAMP Then
                Dim champ As String = IsNull(r.Cells("colMapChamp").Value, "").Trim
                If champ <> "" Then
                    Dim d As New JObject()
                    d("ref") = champ
                    o(nom) = d
                End If
            ElseIf mode = MODE_CONSTANTE Then
                Dim d As New JObject()
                d("const") = IsNull(r.Cells("colMapConstante").Value, "")
                o(nom) = d
            End If
        Next
        If Not o.Properties().Any() Then Return ""
        Return o.ToString(Formatting.None)
    End Function

    Private Sub Regenerer()
        If _enMaj OrElse Not _uiPrete Then Return
        Try
            txtJson.Text = ConstruireJson()
        Catch
        End Try
    End Sub

    '---------------- Événements ----------------

    Private Sub grdMap_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles grdMap.CurrentCellDirtyStateChanged
        ' Valide immédiatement les listes (sinon la valeur reste en cours d'édition)
        If grdMap.IsCurrentCellDirty Then grdMap.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub grdMap_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdMap.CellValueChanged
        If Not _uiPrete OrElse _enMaj Then Return
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso grdMap.Columns(e.ColumnIndex).Name = "colMapMode" Then
            MajEtatLigne(e.RowIndex)
        End If
        Regenerer()
    End Sub

    ''' <summary>Une valeur hors liste (données anciennes) ne doit pas interrompre l'assistant.</summary>
    Private Sub grdMap_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles grdMap.DataError
        e.ThrowException = False
    End Sub

    Private Sub txtAvance_TextChanged(sender As Object, e As EventArgs) Handles txtAvance.TextChanged
        If Not _uiPrete Then Return
        Regenerer()
    End Sub

    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Dim erreurs As New List(Of String)
        If _modeAvance Then
            Dim src As String = txtAvance.Text.Trim
            If src <> "" Then
                Try
                    Dim j = CType(JToken.Parse(src), JObject)
                    For Each p As JProperty In j.Properties()
                        Dim d = TryCast(p.Value, JObject)
                        If d Is Nothing OrElse (d("ref") Is Nothing AndAlso d("const") Is Nothing) Then
                            erreurs.Add("'" & p.Name & "' : forme attendue {""ref"":""Champ""} ou {""const"":""valeur""}.")
                        End If
                    Next
                Catch
                    erreurs.Add("Le json du mode avancé est invalide (objet attendu).")
                End Try
            End If
        Else
            For Each r As DataGridViewRow In grdMap.Rows
                If r.IsNewRow Then Continue For
                Dim nom As String = IsNull(r.Cells("colMapParam").Value, "").Trim
                If nom = "" Then Continue For
                Dim mode As String = IsNull(r.Cells("colMapMode").Value, MODE_AUCUN)
                Dim ob As Boolean = False
                Try : ob = CBool(r.Cells("colMapObligatoire").Value) : Catch : ob = False : End Try
                If mode = MODE_CHAMP AndAlso IsNull(r.Cells("colMapChamp").Value, "").Trim = "" Then
                    erreurs.Add("'" & nom & "' : choisissez le champ de l'entête (ou changez le mode d'alimentation).")
                ElseIf mode = MODE_CONSTANTE AndAlso IsNull(r.Cells("colMapConstante").Value, "") = "" Then
                    erreurs.Add("'" & nom & "' : constante vide — saisissez une valeur ou passez en '" & MODE_AUCUN & "'.")
                ElseIf mode = MODE_AUCUN AndAlso ob Then
                    erreurs.Add("'" & nom & "' est un paramètre obligatoire de la source : il doit être alimenté.")
                End If
            Next
        End If
        If erreurs.Count > 0 Then
            ShowMessageBox("Corrigez les points suivants :" & vbCrLf & " - " & String.Join(vbCrLf & " - ", erreurs),
                           "Assistant de mapping", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        Me.Mapping = ConstruireJson()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Zoom_SP_MappingSource_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

End Class
