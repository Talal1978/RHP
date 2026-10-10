''' <summary>Décision de l'utilisateur pour une compétence du CV absente du référentiel
''' GPEC : codes des compétences GPEC équivalentes choisies (sélection multiple) et/ou
''' création de la compétence sous un domaine donné.</summary>
Public Class CvCompetenceDecision
    Public Property CompetenceCV As String = ""
    Public Property Equivalents As New List(Of String)   ' codes GPEC choisis
    Public Property Creer As Boolean = False
    Public Property DomaineParent As String = ""          ' '' = à la racine
End Class

''' <summary>
''' Zoom modal de l'import de CV (CVTheque) : pour chaque compétence du CV non reconnue
''' dans le référentiel GPEC de la société, l'utilisateur peut
'''   - cliquer sur « Équivalents GPEC » : sélection MULTIPLE dans le zoom standard des
'''     domaines de compétence (Zoom_GPEC_Domaines_Competence) des compétences équivalentes ;
'''   - ou cocher « Créer dans la GPEC » en choisissant le domaine parent : la compétence
'''     est alors ajoutée au référentiel sous ce domaine (racine si non précisé).
''' Les deux choix sont exclusifs par ligne. Le résultat est lu dans Decisions (vide si
''' l'utilisateur ferme sans valider).
''' </summary>
Public Class Zoom_CV_Competences
    Friend Decisions As New List(Of CvCompetenceDecision)
    Private TblSource As New DataTable
    Private gpec As DataTable

    ''' <summary>Alimente la grille avec les compétences non matchées et le référentiel GPEC
    ''' (colonne Domaine : racine + tous les domaines/compétences existants).</summary>
    Sub Charger(competences As List(Of String), gpecRef As DataTable)
        gpec = gpecRef
        TblSource.Columns.Add("CompetenceCV", GetType(String))
        TblSource.Columns.Add("Equivalents", GetType(String))
        TblSource.Columns.Add("CodesEquivalents", GetType(String))
        TblSource.Columns.Add("Creer", GetType(Boolean))
        TblSource.Columns.Add("DomaineParent", GetType(String))
        For Each skill In competences
            TblSource.Rows.Add(skill, "", "", False, "")
        Next
        ' Domaines proposés à la création : racine + tout le référentiel (trié par libellé)
        Dim dtDomaines As New DataTable
        dtDomaines.Columns.Add("Code", GetType(String))
        dtDomaines.Columns.Add("Lib", GetType(String))
        dtDomaines.Rows.Add("", "(à la racine)")
        For Each r As DataRow In gpec.Select("", "Lib_Domaines_Competence")
            dtDomaines.Rows.Add(IsNull(r("Domaines_Competence"), ""),
                                If(IsNull(r("Parent"), "") = "", "", "   ") & IsNull(r("Lib_Domaines_Competence"), ""))
        Next
        With colDomaine
            .DataSource = dtDomaines
            .DisplayMember = "Lib"
            .ValueMember = "Code"
        End With
        Grd.DataSource = TblSource
    End Sub

    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub

    ''' <summary>Clic sur la case « Créer » : création et équivalence sont exclusifs —
    ''' cocher Créer vide les équivalents choisis.</summary>
    Private Sub Grd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellContentClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex <> colCreer.Index Then Return
        Grd.EndEdit()
        Dim creer As Boolean = CBool(IsNull(Grd.Item(e.ColumnIndex, e.RowIndex).Value, False))
        If creer Then
            Grd.Item(colCodesEquivalents.Index, e.RowIndex).Value = ""
            Grd.Item(colEquivalents.Index, e.RowIndex).Value = ""
        End If
    End Sub

    ''' <summary>Clic sur « Équivalents GPEC » (CellClick et non CellContentClick : la
    ''' cellule est vide au départ et CellContentClick ne se déclenche pas sans contenu) :
    ''' ouvre le zoom standard des domaines de compétence en sélection multiple, pré-coché
    ''' des équivalents déjà choisis.</summary>
    Private Sub Grd_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex <> colEquivalents.Index Then Return
        Dim codesActuels As String = IsNull(Grd.Item(colCodesEquivalents.Index, e.RowIndex).Value, "")
        Dim selection As New List(Of String)
        For Each c In codesActuels.Split(";"c)
            If c.Trim() <> "" Then selection.Add(c.Trim() & "$1")
        Next
        Dim f As New Zoom_GPEC_Domaines_Competence
        With f
            .domaines = selection
            .ShowDialog(Me)
        End With
        ' Retour : codes cochés au format 'code$note'
        Dim codes As New List(Of String)
        Dim libelles As New List(Of String)
        For Each d In f.domaines
            Dim code As String = d.Split("$"c)(0).Trim()
            If code <> "" AndAlso Not codes.Contains(code) Then
                codes.Add(code)
                Dim libelle As String = ""
                Dim nrw() As DataRow = gpec.Select("Domaines_Competence='" & code.Replace("'", "''") & "'")
                If nrw.Length > 0 Then libelle = IsNull(nrw(0)("Lib_Domaines_Competence"), "")
                libelles.Add(If(libelle <> "", libelle, code))
            End If
        Next
        Grd.Item(colCodesEquivalents.Index, e.RowIndex).Value = String.Join(";", codes)
        Grd.Item(colEquivalents.Index, e.RowIndex).Value = String.Join(" + ", libelles)
        If codes.Count > 0 Then Grd.Item(colCreer.Index, e.RowIndex).Value = False
    End Sub

    ''' <summary>Colonne en lecture seule cliquable : curseur main au survol.</summary>
    Private Sub Grd_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellMouseEnter
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = colEquivalents.Index Then
            Grd.Cursor = Cursors.Hand
        End If
    End Sub
    Private Sub Grd_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Grd.CellMouseLeave
        Grd.Cursor = Cursors.Default
    End Sub

    ''' <summary>Valider : construit les décisions (équivalents et/ou créations) puis ferme.</summary>
    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Grd.EndEdit()
        Decisions.Clear()
        For Each r As DataRow In TblSource.Rows
            Dim d As New CvCompetenceDecision With {
                .CompetenceCV = IsNull(r("CompetenceCV"), ""),
                .Creer = CBool(IsNull(r("Creer"), False)),
                .DomaineParent = IsNull(r("DomaineParent"), "")
            }
            For Each c In IsNull(r("CodesEquivalents"), "").Split(";"c)
                If c.Trim() <> "" Then d.Equivalents.Add(c.Trim())
            Next
            If d.Equivalents.Count > 0 OrElse d.Creer Then Decisions.Add(d)
        Next
        Me.Close()
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Decisions.Clear()
        Me.Close()
    End Sub
End Class
