Imports System.Text
Imports System.Text.RegularExpressions

''' <summary>
''' Écran modal de gestion des sections du menu portail (rubrique SP_Menu_Portail),
''' ouvert depuis le SP_Page_Designer (bouton '+' à côté de la liste des sections).
''' CRUD complet : la grille liste les sections existantes ; la zone de saisie permet
''' d'en créer (code technique généré automatiquement, sans accents ni espaces,
''' suffixé d'un numéro si nécessaire pour rester unique) ou d'en modifier une
''' existante (nom, rang d'affichage, icône MUI avec aperçu — le code, clé de la
''' section, est immuable). La suppression est réservée aux sections non standards
''' (Typ &lt;&gt; 'S') et refuse les sections encore utilisées par des pages.
''' L'icône est stockée dans la colonne libre Champs02 de Param_Rubriques : le
''' portail la renvoie aux sections du menu latéral (endpoint sp_menu_portail).
''' Thème visuel et layout : Zoom_SP_Nouvelle_Section.Designer.vb (thème de
''' référence des écrans exclusivement modaux — instruction permanente).
''' </summary>
Public Class Zoom_SP_Nouvelle_Section

    '---------------- Résultat (lu par l'appelant après fermeture) ----------------
    ''' <summary>Dernière section créée/modifiée : re-sélectionnée dans la liste de l'appelant.</summary>
    Public CodeSelectionne As String = ""
    ''' <summary>True si au moins une écriture (création / modification / suppression) a eu lieu.</summary>
    Public Modifie As Boolean = False

    ' C = création, M = modification (convention des écrans Zoom_*)
    Private ModeCreationModification As String = "C"
    Private _enChargement As Boolean = False   ' True pendant les (re)chargements : pas d'effets de bord

    ' Codes et libellés déjà utilisés (rechargés à chaque écriture : les contrôles
    ' d'unicité sont faits en mémoire, sans requête à chaque frappe)
    Private ReadOnly codesExistants As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
    Private ReadOnly libellesExistants As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
    Private Tbl_Sections As DataTable

    '---------------- Icônes MUI (liste illustrée + aperçu) ----------------
    Private materialFontFamily As FontFamily = Nothing
    Private ReadOnly iconesBmp As New Dictionary(Of String, Bitmap)

    Public Sub New()
        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        ' Initialisation après InitializeComponent()
        InitialiserColonnes()
        ChargerIcones()
        ChargerSections()
        Nouveau()
    End Sub

    Private Function SqlV(v As Object) As String
        Return "'" & IsNull(v, "").ToString().Replace("'", "''") & "'"
    End Function

    ''' <summary>Colonnes de la grille des sections (Typ cachée : pilote la possibilité
    ''' de suppression). Déclarées dans le code : à l'abri de la régénération du
    ''' Designer par Visual Studio. Les lectures des lignes passent par DataBoundItem
    ''' (DataRow), jamais par les noms de colonnes de la grille.</summary>
    Private Sub InitialiserColonnes()
        Grd_Sections.AutoGenerateColumns = False
        Grd_Sections.Columns.Clear()
        Grd_Sections.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Valeur", .HeaderText = "Code", .Name = "colValeur", .Width = 95})
        Grd_Sections.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Membre", .HeaderText = "Section", .Name = "colMembre", .Width = 165})
        Grd_Sections.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Rang", .HeaderText = "Rang", .Name = "colRang", .Width = 50})
        Grd_Sections.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Icone", .HeaderText = "Icône", .Name = "colIcone", .Width = 85})
        Grd_Sections.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Typ", .HeaderText = "Typ", .Name = "colTyp", .Visible = False, .Width = 5})
    End Sub

    ''' <summary>Ligne de section actuellement sélectionnée (Nothing si aucune).</summary>
    Private Function LigneCourante() As DataRow
        If Grd_Sections.SelectedRows.Count = 0 Then Return Nothing
        Dim drv = TryCast(Grd_Sections.SelectedRows(0).DataBoundItem, DataRowView)
        Return If(drv Is Nothing, Nothing, drv.Row)
    End Function

    '---------------- Chargement de la liste des sections ----------------

    ''' <summary>(Re)charge la grille des sections et les listes d'unicité,
    ''' puis re-sélectionne la section demandée.</summary>
    Private Sub ChargerSections(Optional reselect As String = "")
        _enChargement = True
        Tbl_Sections = DATA_READER_GRD("select Valeur, Membre, Rang, isnull(Champs02,'') as Icone, Typ from Param_Rubriques where Nom_Controle='SP_Menu_Portail' order by Rang, Membre")
        Grd_Sections.DataSource = Tbl_Sections
        codesExistants.Clear() : libellesExistants.Clear()
        For Each r As DataRow In Tbl_Sections.Rows
            Dim v As String = IsNull(r("Valeur"), "").Trim
            If v <> "" Then codesExistants.Add(v)
            Dim m As String = IsNull(r("Membre"), "").Trim
            If m <> "" Then libellesExistants.Add(m)
        Next
        _enChargement = False
        If reselect <> "" Then
            For Each gr As DataGridViewRow In Grd_Sections.Rows
                Dim drv = TryCast(gr.DataBoundItem, DataRowView)
                If drv IsNot Nothing AndAlso IsNull(drv.Row("Valeur"), "").Equals(reselect, StringComparison.OrdinalIgnoreCase) Then
                    gr.Selected = True
                    Grd_Sections.CurrentCell = gr.Cells(0)
                    Exit For
                End If
            Next
        End If
    End Sub

    ''' <summary>Prochain rang disponible (max + 1 des sections existantes).</summary>
    Private Function ProchainRang() As Integer
        Dim m As Integer = 0
        If Tbl_Sections IsNot Nothing Then
            For Each r As DataRow In Tbl_Sections.Rows
                Dim v As Integer = CInt(Val(IsNull(r("Rang"), "0").ToString()))
                If v > m Then m = v
            Next
        End If
        Return Math.Min(9998, m) + 1
    End Function

    '---------------- Mode création / modification ----------------

    ''' <summary>Passe en mode création : champs vides, code automatique, rang suivant.</summary>
    Private Sub Nouveau()
        _enChargement = True
        ModeCreationModification = "C"
        Grd_Sections.ClearSelection()
        txtLibelle.Text = ""
        txtCode.Text = ""
        numRang.Value = ProchainRang()
        If cmbIcone.Items.Count > 0 Then cmbIcone.SelectedIndex = 0   ' '' = aucune icône
        Supprimer_pb.Enabled = False
        _enChargement = False
        txtLibelle.Select()
    End Sub

    ''' <summary>Sélection d'une section dans la grille : charge ses valeurs en mode modification.</summary>
    Private Sub Grd_Sections_SelectionChanged(sender As Object, e As EventArgs) Handles Grd_Sections.SelectionChanged
        If _enChargement Then Return
        Dim r As DataRow = LigneCourante()
        If r Is Nothing Then Return
        _enChargement = True
        ModeCreationModification = "M"
        txtCode.Text = IsNull(r("Valeur"), "")
        txtLibelle.Text = IsNull(r("Membre"), "")
        Dim rg As Integer = CInt(Val(IsNull(r("Rang"), "99").ToString()))
        numRang.Value = Math.Max(numRang.Minimum, Math.Min(numRang.Maximum, rg))
        ChoisirIcone(IsNull(r("Icone"), ""))
        ' La suppression ne s'applique pas aux sections standards (Typ = 'S')
        Supprimer_pb.Enabled = (IsNull(r("Typ"), "U") <> "S")
        _enChargement = False
    End Sub

    '---------------- Code technique : génération automatique ----------------

    ''' <summary>Dérive un code technique du libellé saisi : PascalCase sans accents
    ''' ni caractères spéciaux (ex. 'Notes de frais' -> 'NotesDeFrais').</summary>
    Private Function CodeSectionDepuisLibelle(libelle As String) As String
        Dim norm As String = libelle.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder()
        Dim debutMot As Boolean = True
        For Each ch As Char In norm
            If Globalization.CharUnicodeInfo.GetUnicodeCategory(ch) = Globalization.UnicodeCategory.NonSpacingMark Then Continue For
            If Char.IsLetterOrDigit(ch) Then
                sb.Append(If(debutMot, Char.ToUpper(ch), ch))
                debutMot = False
            Else
                debutMot = True
            End If
        Next
        Dim code As String = sb.ToString()
        If code = "" Then code = "Section"
        If Char.IsDigit(code(0)) Then code = "S" & code
        Return code.Substring(0, Math.Min(30, code.Length))
    End Function

    ''' <summary>Garantit l'unicité du code généré : suffixe numérique si le code
    ''' de base est déjà attribué à une section existante.</summary>
    Private Function CodeUnique(codeBase As String) As String
        Dim c As String = codeBase
        Dim n As Integer = 1
        While codesExistants.Contains(c)
            n += 1
            Dim suffix As String = n.ToString()
            c = codeBase.Substring(0, Math.Min(codeBase.Length, 30 - suffix.Length)) & suffix
        End While
        Return c
    End Function

    ''' <summary>En création, le code technique suit le nom saisi (en modification,
    ''' le code est la clé de la section : immuable).</summary>
    Private Sub txtLibelle_TextChanged(sender As Object, e As EventArgs) Handles txtLibelle.TextChanged
        If _enChargement OrElse ModeCreationModification <> "C" Then Return
        Dim nomSaisi As String = txtLibelle.Text.Trim
        txtCode.Text = If(nomSaisi = "", "", CodeUnique(CodeSectionDepuisLibelle(nomSaisi)))
    End Sub

    '---------------- Icônes MUI (même rendu que la liste 'Icône' du Designer) ----------------

    ''' <summary>Charge la font Material Icons (rsc/fonts) pour l'illustration des icônes.</summary>
    Private Sub ChargerFontIcones()
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

    ''' <summary>Rend l'icône MUI en grand format pour l'aperçu (centrée).</summary>
    Private Function IconeBitmapGrand(nomMui As String) As Bitmap
        Dim bmp As New Bitmap(picApercu.Width, picApercu.Height)
        If materialFontFamily Is Nothing Then Return bmp
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(picApercu.BackColor)
            Using f As New Font(materialFontFamily, 26)
                TextRenderer.DrawText(g, PascalToSnake(nomMui), f,
                                      New Rectangle(0, 0, bmp.Width, bmp.Height), colorBase01,
                                      TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            End Using
        End Using
        Return bmp
    End Function

    ''' <summary>Remplit la liste des icônes (rubrique SP_Menu_Icones + illustration).</summary>
    Private Sub ChargerIcones()
        ChargerFontIcones()
        cmbIcone.Items.Clear()
        iconesBmp.Clear()
        cmbIcone.Items.Add("")
        Dim tbl As DataTable = DATA_READER_GRD("select Valeur from Param_Rubriques where Nom_Controle='SP_Menu_Icones' order by Rang")
        For Each r As DataRow In tbl.Rows
            Dim nom As String = IsNull(r("Valeur"), "")
            If nom = "" Then Continue For
            iconesBmp(nom) = IconeBitmap(nom)
            cmbIcone.Items.Add(nom)
        Next
    End Sub

    ''' <summary>Dessine chaque élément : icône MUI + nom (couleurs du thème).</summary>
    Private Sub cmbIcone_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbIcone.DrawItem
        If e.Index < 0 Then Return
        Dim nom As String = cmbIcone.Items(e.Index).ToString()
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

    ''' <summary>Aperçu grand format de l'icône sélectionnée.</summary>
    Private Sub cmbIcone_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIcone.SelectedIndexChanged
        Dim ancien As Image = picApercu.Image
        picApercu.Image = If(IconeChoisie() <> "", IconeBitmapGrand(IconeChoisie()), Nothing)
        If ancien IsNot Nothing Then ancien.Dispose()
    End Sub

    Private Function IconeChoisie() As String
        Return If(cmbIcone.SelectedIndex >= 0 AndAlso cmbIcone.SelectedItem IsNot Nothing, cmbIcone.SelectedItem.ToString(), "")
    End Function
    Private Sub ChoisirIcone(nom As String)
        For i As Integer = 0 To cmbIcone.Items.Count - 1
            If cmbIcone.Items(i).ToString() = nom Then cmbIcone.SelectedIndex = i : Return
        Next
        cmbIcone.SelectedIndex = -1
    End Sub

    '---------------- Écritures : création / modification / suppression ----------------

    ''' <summary>Un nom de section est-il déjà utilisé par une AUTRE section ?</summary>
    Private Function NomDejaPris(nom As String, saufCode As String) As Boolean
        If Tbl_Sections Is Nothing Then Return False
        For Each r As DataRow In Tbl_Sections.Rows
            If IsNull(r("Valeur"), "").Trim.Equals(saufCode, StringComparison.OrdinalIgnoreCase) Then Continue For
            If IsNull(r("Membre"), "").Trim.Equals(nom, StringComparison.OrdinalIgnoreCase) Then Return True
        Next
        Return False
    End Function

    Private Sub Nouveau_ud_Click(sender As Object, e As EventArgs) Handles Nouveau_pb.Click
        Nouveau()
    End Sub

    Private Sub Save_ud_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Dim nomSaisi As String = txtLibelle.Text.Trim
        If nomSaisi = "" Then
            ShowMessageBox("Le nom de la section est obligatoire.", "Section portail", MessageBoxButtons.OK, msgIcon.Warning)
            txtLibelle.Select()
            Return
        End If
        Dim cod As String = txtCode.Text.Trim
        If ModeCreationModification = "C" Then
            '---------------- Création ----------------
            If libellesExistants.Contains(nomSaisi) Then
                ShowMessageBox("Une section porte déjà le nom '" & nomSaisi & "'.", "Section portail", MessageBoxButtons.OK, msgIcon.Stop)
                txtLibelle.Select()
                Return
            End If
            If Not Regex.IsMatch(cod, "^[A-Za-z][A-Za-z0-9_]{1,29}$") Then
                ShowMessageBox("Code technique invalide : 2 à 30 caractères (lettres, chiffres, _), commençant par une lettre.",
                               "Section portail", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            Try
                CnExecuting("insert into Param_Rubriques (Nom_Controle, Valeur, Membre, Rang, Champs02, Typ, Dat_Crea, Created_By) values ('SP_Menu_Portail', " &
                            SqlV(cod) & ", " & SqlV(nomSaisi) & ", " & CInt(numRang.Value) & ", " & SqlV(IconeChoisie()) & ", 'U', getdate(), " & SqlV(theUser.Login) & ")")
            Catch ex As Exception
                ShowMessageBox("Erreur lors de la création de la section : " & ex.Message, "Section portail", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End Try
        Else
            '---------------- Modification (code = clé, immuable) ----------------
            If NomDejaPris(nomSaisi, cod) Then
                ShowMessageBox("Une autre section porte déjà le nom '" & nomSaisi & "'.", "Section portail", MessageBoxButtons.OK, msgIcon.Stop)
                txtLibelle.Select()
                Return
            End If
            Try
                CnExecuting("update Param_Rubriques set Membre=" & SqlV(nomSaisi) & ", Rang=" & CInt(numRang.Value) & ", Champs02=" & SqlV(IconeChoisie()) &
                            " where Nom_Controle='SP_Menu_Portail' and Valeur=" & SqlV(cod))
            Catch ex As Exception
                ShowMessageBox("Erreur lors de la modification de la section : " & ex.Message, "Section portail", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End Try
        End If
        Modifie = True
        CodeSelectionne = cod
        ChargerSections(cod)
    End Sub

    ''' <summary>Suppression de la section sélectionnée : jamais pour une section
    ''' standard (Typ = 'S', fournie avec l'application) ni si des pages y sont
    ''' encore rattachées.</summary>
    Private Sub Supprimer_ud_Click(sender As Object, e As EventArgs) Handles Supprimer_pb.Click
        Dim r As DataRow = LigneCourante()
        If r Is Nothing Then Return
        Dim cod As String = IsNull(r("Valeur"), "")
        Dim nom As String = IsNull(r("Membre"), "")
        If cod = "" Then Return
        If IsNull(r("Typ"), "U") = "S" Then
            ShowMessageBox("'" & nom & "' est une section standard : elle ne peut pas être supprimée.",
                           "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim nbPages As Integer = CInt(Val(IsNull(DATA_READER_GRD("select count(*) from SP_Page where Menu_Parent=" & SqlV(cod)).Rows(0)(0), "0").ToString()))
        If nbPages > 0 Then
            ShowMessageBox("La section '" & nom & "' est utilisée par " & nbPages & " page(s) : déplacez-les d'abord vers une autre section.",
                           "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ShowMessageBox("Supprimer la section '" & nom & "' ?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Question) <> MsgBoxResult.Ok Then Return
        Try
            CnExecuting("delete from Param_Rubriques where Nom_Controle='SP_Menu_Portail' and Valeur=" & SqlV(cod) & " and Typ<>'S'")
        Catch ex As Exception
            ShowMessageBox("Erreur lors de la suppression de la section : " & ex.Message, "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End Try
        Modifie = True
        CodeSelectionne = ""
        ChargerSections()
        Nouveau()
    End Sub

    Private Sub Annuler_ud_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    '---------------- Raccourcis clavier / focus initial ----------------

    ''' <summary>Entrée = enregistrer (hors liste déroulante ouverte), Échap = fermer.</summary>
    Private Sub Zoom_SP_Nouvelle_Section_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.SuppressKeyPress = True
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter AndAlso Not cmbIcone.DroppedDown AndAlso
               Not (TypeOf Me.ActiveControl Is DataGridView) Then
            e.SuppressKeyPress = True
            Save_ud_Click(Save_pb, EventArgs.Empty)
        End If
    End Sub

    ''' <summary>Focus initial sur le nom (Select de ud_TextBox : focus la zone interne).</summary>
    Private Sub Zoom_SP_Nouvelle_Section_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtLibelle.Select()
    End Sub

End Class
