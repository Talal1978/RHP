Imports System.Text.RegularExpressions

''' <summary>
''' Zoom d'édition de la requête SQL d'une source métier (colonne 'Requête SQL'
''' de la grille Grd_Sources du SP_Page_Designer, en lecture seule) : la requête
''' s'édite ici dans un éditeur multi-lignes avec CONTRÔLE D'INJECTION en temps
''' réel — miroir exact du garde-fou serveur (estRequeteLectureSeule du moteur
''' SP_ du portail, qui rejoue le même contrôle à l'exécution) :
'''   - une seule instruction (';' interdits hors littéraux) ;
'''   - lecture seule : SELECT / WITH, ou EXEC dbo.Sys_* (procédures métier) ;
'''   - mots-clés de modification / d'administration interdits (insert, update,
'''     delete, drop, xp_*, openrowset...) ;
'''   - procédures système sp_* interdites (contrôle sensible à la casse : les
'''     tables métier SP_ restent lisibles).
''' Interface : SP_Zoom_SqlSource.Designer.vb (convention permanente : tout le
''' code de design est dans le .Designer.vb ; ce fichier ne contient que la
''' logique — contrôle d'injection, événements, résultat).
''' </summary>
Public Class SP_Zoom_SqlSource

    '---------------- Résultat (lu par l'appelant après DialogResult.OK) ----------------
    Public CodeSql As String = ""

    ''' <summary>Crée le zoom. codSource = code de la source (contexte du titre) ;
    ''' codeSqlExistant = contenu actuel de la cellule 'Requête SQL'.</summary>
    Public Sub New(codSource As String, codeSqlExistant As String)
        InitializeComponent()
        titre.Text = "  Édition de la requête SQL — source '" & codSource & "'"
        txtSql.Text = IsNull(codeSqlExistant, "")
        txtSql.Select(0, 0)
        Verifier()
    End Sub

    '---------------- Contrôle d'injection (miroir de estRequeteLectureSeule, moteur SP_ portail) ----------------

    ''' <summary>Retourne "" si la requête est admise, sinon le message du contrôle en échec.
    ''' Une requête vide est admise (la source est alors simplement inerte).</summary>
    Private Shared Function ControleLectureSeule(code As String) As String
        Dim cleaned As String = IsNull(code, "")
        cleaned = Regex.Replace(cleaned, "/\*.*?\*/", "", RegexOptions.Singleline)
        cleaned = Regex.Replace(cleaned, "--.*?(\n|$)", " ")
        cleaned = Regex.Replace(cleaned, "\s+", " ").Trim()
        If cleaned = "" Then Return ""
        ' Les littéraux chaînes sont neutralisés AVANT le contrôle multi-instructions :
        ' un ';' dans un littéral (ex. '1;1;1') n'est pas un séparateur.
        Dim sansLitteraux As String = Regex.Replace(cleaned, "'(?:[^']|'')*'", "''")
        If Regex.IsMatch(Regex.Replace(sansLitteraux, ";\s*$", ""), ";.*\S") Then
            Return "Instruction multiple interdite."
        End If
        Dim debut As String = sansLitteraux.ToLower()
        If Not Regex.IsMatch(debut, "^(select|with)\b") AndAlso Not Regex.IsMatch(debut, "^exec(ute)?\s+dbo\.sys_\w+") Then
            Return "Seuls SELECT / WITH / EXEC dbo.Sys_* sont autorisés."
        End If
        If Regex.IsMatch(sansLitteraux, "\b(insert|update|delete|merge|drop|alter|create|truncate|grant|revoke|backup|restore|shutdown|kill|waitfor|openrowset|opendatasource|xp_\w+)\b", RegexOptions.IgnoreCase) Then
            Return "Mots-clés SQL interdits dans la source (modification / administration)."
        End If
        ' sp_* (procédures système) : contrôle SENSIBLE à la casse — les tables métier
        ' du module sont préfixées 'SP_' (majuscules) et restent lisibles.
        If Regex.IsMatch(sansLitteraux, "\bsp_\w+\b") Then
            Return "Procédures système 'sp_*' interdites dans la source."
        End If
        Return ""
    End Function

    ''' <summary>Met à jour l'indicateur de contrôle sous l'éditeur (vert = admise).</summary>
    Private Sub Verifier()
        Dim msg As String = ControleLectureSeule(txtSql.Text)
        If msg = "" Then
            lblControle.ForeColor = Color.FromArgb(46, 125, 50)
            lblControle.Text = "Requête conforme au contrôle d'injection."
        Else
            lblControle.ForeColor = Color.FromArgb(198, 40, 40)
            lblControle.Text = msg
        End If
    End Sub

    '---------------- Événements ----------------

    Private Sub txtSql_TextChanged(sender As Object, e As EventArgs) Handles txtSql.TextChanged
        Verifier()
    End Sub

    Private Sub btnAppliquer_Click(sender As Object, e As EventArgs) Handles btnAppliquer.Click
        Dim msg As String = ControleLectureSeule(txtSql.Text)
        If msg <> "" Then
            ShowMessageBox("La requête ne passe pas le contrôle d'injection :" & vbCrLf & msg,
                           "Contrôle d'injection", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Me.CodeSql = txtSql.Text.Trim()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SP_Zoom_SqlSource_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

End Class
