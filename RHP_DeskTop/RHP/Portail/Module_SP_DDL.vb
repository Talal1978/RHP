Imports System.Text
Imports System.Text.RegularExpressions

''' <summary>
''' Module SP_ - Génération et exécution sécurisée du DDL des tables métier SP_.
''' Appelé à l'enregistrement d'une page dans le Designer (SP_Page_Designer) :
''' les tables métier sont créées/migrées dans la MÊME transaction ADODB que
''' l'enregistrement des métadonnées, avec journalisation dans Controle_Designer_DDL_Log.
''' Règles :
'''   - identifiants SQL validés (regex + liste noire) et systématiquement quotés ;
'''   - jamais de DROP silencieux : une colonne retirée des métadonnées produit
'''     un avertissement, pas une suppression ;
'''   - migration non destructive : ALTER ADD uniquement, élargissements sûrs.
''' </summary>
Public Module Module_SP_DDL

    Private ReadOnly MotsReserves As String() = {
        "select", "insert", "update", "delete", "drop", "alter", "create", "exec",
        "execute", "union", "grant", "revoke", "truncate", "merge", "into", "from",
        "where", "table", "backup", "restore", "shutdown", "sysobjects", "xp_cmdshell"
    }

    ''' <summary>Retourne "" si l'identifiant est valide, sinon le message d'erreur.</summary>
    Public Function ValiderIdentifiantSql(nom As String) As String
        If nom Is Nothing OrElse Not Regex.IsMatch(nom, "^[A-Za-z_][A-Za-z0-9_]{0,59}$") Then
            Return "Identifiant SQL invalide : '" & nom & "'"
        End If
        If MotsReserves.Contains(nom.ToLower()) Then
            Return "Identifiant réservé : '" & nom & "'"
        End If
        Return ""
    End Function

    ''' <summary>Retourne "" si le nom de table métier est valide (préfixe SP_ obligatoire).</summary>
    Public Function ValiderNomTableMetier(nom As String) As String
        Dim v = ValiderIdentifiantSql(nom)
        If v <> "" Then Return v
        If Not nom.StartsWith("SP_") Then
            Return "La table '" & nom & "' doit commencer par le préfixe SP_"
        End If
        Return ""
    End Function

    ''' <summary>Quote un identifiant déjà validé (défense en profondeur).</summary>
    Private Function Q(nom As String) As String
        Return "[" & nom.Replace("]", "]]" ) & "]"
    End Function

    ''' <summary>Traduit le type logique en DDL SQL Server.</summary>
    Public Function SqlTypeDDL(typSql As String, longueur As Object, precisionSql As Object, echelle As Object) As String
        Select Case LCase(IsNull(typSql, "nvarchar"))
            Case "int" : Return "int"
            Case "bigint" : Return "bigint"
            Case "float" : Return "float"
            Case "bit" : Return "bit"
            Case "date" : Return "date"
            Case "datetime" : Return "datetime"
            Case "smalldatetime" : Return "smalldatetime"
            Case "decimal"
                Dim p As Integer = Val(IsNull(precisionSql, "18") & "")
                Dim s As Integer = Val(IsNull(echelle, "2") & "")
                If p <= 0 OrElse p > 38 Then p = 18
                If s < 0 OrElse s > p Then s = 2
                Return "decimal(" & p & "," & s & ")"
            Case Else
                Dim L As Integer = Val(IsNull(longueur, "50") & "")
                If L = -1 Then Return "nvarchar(max)"
                If L <= 0 OrElse L > 4000 Then L = 50
                Return "nvarchar(" & L & ")"
        End Select
    End Function

    ''' <summary>Définition DDL des colonnes techniques obligatoires d'une table.</summary>
    Private Function ColonnesTechniques(roleTable As String, nomPhysique As String, regleSuppression As String) As List(Of String)
        Dim cols As New List(Of String)
        If roleTable = "DET" Then
            cols.Add("    [RowId] int IDENTITY(1,1) NOT NULL")
        End If
        cols.Add("    [Num_Doc] nvarchar(30) NOT NULL")
        cols.Add("    [id_Societe] int NOT NULL")
        If roleTable = "ENT" Then
            cols.Add("    [Statut] nvarchar(3) NULL CONSTRAINT [DF_" & nomPhysique & "_Statut] DEFAULT ('')")
        End If
        cols.Add("    [Dat_Crea] datetime NULL")
        cols.Add("    [Created_By] nvarchar(50) NULL")
        cols.Add("    [Dat_Modif] datetime NULL")
        cols.Add("    [Modified_By] nvarchar(50) NULL")
        If roleTable = "ENT" Then
            cols.Add("    [RV] rowversion NOT NULL")
        End If
        Return cols
    End Function

    ''' <summary>DDL d'une colonne métier configurée (ligne Controle_Designer_Colonne).</summary>
    Private Function ColonneDDL(r As DataRow, nomPhysique As String, ByRef erreurs As List(Of String)) As String
        Dim nomCol As String = IsNull(r("Nom_Colonne"), "")
        Dim v = ValiderIdentifiantSql(nomCol)
        If v <> "" Then
            erreurs.Add(v)
            Return ""
        End If
        Dim sb As New StringBuilder("    " & Q(nomCol) & " ")
        sb.Append(SqlTypeDDL(IsNull(r("Typ_Sql"), "nvarchar"), r("Longueur"), r("Precision_Sql"), r("Echelle_Sql")))
        Dim nullable As Boolean = (LCase(IsNull(r("Nullable"), "true")) = "true")
        Dim defaut As String = IsNull(r("Valeur_Defaut"), "")
        If nullable Then
            sb.Append(" NULL")
        Else
            sb.Append(" NOT NULL")
            ' Une colonne NOT NULL porte toujours une valeur par défaut (création/migration sûre)
            sb.Append(" CONSTRAINT [DF_" & nomPhysique & "_" & nomCol & "] DEFAULT " & DefautSQL(defaut, IsNull(r("Typ_Sql"), "nvarchar")))
        End If
        Return sb.ToString()
    End Function

    ''' <summary>Traduit une valeur par défaut déclarée en littéral SQL sûr.</summary>
    Private Function DefautSQL(defaut As String, typSql As String) As String
        If defaut Is Nothing OrElse defaut.Trim = "" Then
            Select Case LCase(typSql)
                Case "int", "bigint", "float", "decimal" : Return "(0)"
                Case "bit" : Return "(0)"
                Case Else : Return "('')"
            End Select
        End If
        Select Case UCase(defaut.Trim)
            Case "GV_NOW" : Return "(getdate())"
            Case Else
                Select Case LCase(typSql)
                    Case "int", "bigint", "float", "decimal"
                        Dim d As Double
                        If Double.TryParse(defaut.Replace(",", "."), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, d) Then
                            Return "(" & d.ToString(Globalization.CultureInfo.InvariantCulture) & ")"
                        End If
                        Return "(0)"
                    Case "bit"
                        Return If(defaut = "1" OrElse LCase(defaut) = "true", "(1)", "(0)")
                    Case Else
                        Return "('" & defaut.Replace("'", "''") & "')"
                End Select
        End Select
    End Function

    ''' <summary>La table existe-t-elle dans la base ?</summary>
    Public Function TableExiste(nomPhysique As String) As Boolean
        Dim rs = CnExecuting("select 1 from sys.tables where name = '" & nomPhysique.Replace("'", "''") & "'")
        Dim existe As Boolean = Not (rs Is Nothing OrElse rs.EOF)
        If rs IsNot Nothing AndAlso rs.State = 1 Then rs.Close()
        Return existe
    End Function

    ''' <summary>Noms des colonnes existantes d'une table (via sys.columns).</summary>
    Public Function ColonnesExistantes(nomPhysique As String) As List(Of String)
        Dim rsl As New List(Of String)
        Dim rs = CnExecuting("select c.name from sys.columns c where c.object_id = object_id('" & nomPhysique.Replace("'", "''") & "')")
        If rs IsNot Nothing Then
            While Not rs.EOF
                rsl.Add(IsNull(rs.Fields("name").Value, ""))
                rs.MoveNext()
            End While
            If rs.State = 1 Then rs.Close()
        End If
        Return rsl
    End Function

    Private Function IndexExiste(nomIndex As String, nomPhysique As String) As Boolean
        Dim rs = CnExecuting("select 1 from sys.indexes where name='" & nomIndex.Replace("'", "''") &
                             "' and object_id = object_id('" & nomPhysique.Replace("'", "''") & "')")
        Dim existe As Boolean = Not (rs Is Nothing OrElse rs.EOF)
        If rs IsNot Nothing AndAlso rs.State = 1 Then rs.Close()
        Return existe
    End Function

    ''' <summary>
    ''' Génère le script DDL complet d'une page (création + migration non destructive).
    ''' Retourne le script (lots séparés par GO). Les avertissements et erreurs sont
    ''' alimentés pour l'aperçu présenté avant exécution.
    ''' tblTables/tblCols : contenu des grilles (évite toute relecture en base pendant
    ''' la transaction d'enregistrement - sinon blocage sur les verrous posés par cn).
    ''' </summary>
    Public Function GenererScriptPage(codPage As String, ByRef messages As List(Of String), ByRef erreurs As List(Of String),
                                      Optional tblTables As DataTable = Nothing, Optional tblColsToutes As DataTable = Nothing) As String
        messages = If(messages, New List(Of String))
        erreurs = If(erreurs, New List(Of String))
        If tblTables Is Nothing Then
            tblTables = DATA_READER_GRD("select * from Controle_Designer_Table where Cod_Page='" & codPage.Replace("'", "''") & "' order by Rang")
        End If
        If tblColsToutes Is Nothing Then
            tblColsToutes = DATA_READER_GRD("select * from Controle_Designer_Colonne where Cod_Page='" & codPage.Replace("'", "''") &
                                            "' and isnull(Technique,'false')='false' order by Cod_Table, Rang")
        End If
        Dim script As New StringBuilder()
        Dim lignesTables As DataRow() = tblTables.Select("", "Rang")
        If lignesTables.Length = 0 Then
            erreurs.Add("Aucune table configurée pour la page '" & codPage & "'.")
            Return ""
        End If
        Dim nomTableEnt As String = ""
        For Each rt As DataRow In lignesTables
            If IsNull(rt("Role_Table"), "") = "ENT" Then nomTableEnt = IsNull(rt("Nom_Physique"), "")
        Next
        If nomTableEnt = "" Then erreurs.Add("La table d'entête (Role ENT) est introuvable dans la configuration.")

        For Each rt As DataRow In lignesTables
            Dim codTable As String = IsNull(rt("Cod_Table"), "")
            Dim nomPhysique As String = IsNull(rt("Nom_Physique"), "")
            Dim roleTable As String = IsNull(rt("Role_Table"), "ENT")
            Dim regleSuppr As String = IsNull(rt("Regle_Suppression"), "CASCADE")
            Dim v = ValiderNomTableMetier(nomPhysique)
            If v <> "" Then erreurs.Add(v) : Continue For

            ' Grille virtuelle (détail alimenté par une source métier de retour
            ' TABLE) : aucune table physique n'est créée ni migrée — la grille est
            ' recalculée par la source à l'exécution, jamais persistée.
            Dim srcMetier As String = If(tblTables.Columns.Contains("Source_Metier"), IsNull(rt("Source_Metier"), "").Trim, "")
            If srcMetier <> "" Then
                messages.Add("Grille virtuelle " & nomPhysique & " : alimentée par la source '" & srcMetier & "' (aucune table physique créée).")
                Continue For
            End If

            ' Colonnes de la table : filtrées depuis les grilles (pas de relecture base)
            Dim tblCols As DataRow() = tblColsToutes.Select("Cod_Table='" & codTable.Replace("'", "''") & "'", "Rang")
            Dim techniques As List(Of String) = ColonnesTechniques(roleTable, nomPhysique, regleSuppr)

            If Not TableExiste(nomPhysique) Then
                '---------------------- CRÉATION ----------------------
                messages.Add("Création de la table " & nomPhysique)
                script.AppendLine("/* --- Création " & nomPhysique & " --- */")
                script.AppendLine("IF OBJECT_ID('dbo." & nomPhysique & "', 'U') IS NULL")
                script.AppendLine("BEGIN")
                script.AppendLine("    CREATE TABLE dbo." & Q(nomPhysique) & " (")
                Dim toutes As New List(Of String)(techniques)
                For Each rc As DataRow In tblCols
                    Dim ligne = ColonneDDL(rc, nomPhysique, erreurs)
                    If ligne <> "" Then toutes.Add(ligne)
                Next
                If roleTable = "ENT" Then
                    toutes.Add("    CONSTRAINT [PK_" & nomPhysique & "] PRIMARY KEY ([Num_Doc], [id_Societe])")
                Else
                    toutes.Add("    CONSTRAINT [PK_" & nomPhysique & "] PRIMARY KEY ([RowId])")
                End If
                script.AppendLine(String.Join("," & vbCrLf, toutes))
                script.AppendLine("    );")
                script.AppendLine("END")
                script.AppendLine("GO")
            Else
                '---------------------- MIGRATION NON DESTRUCTIVE ----------------------
                Dim existantes As List(Of String) = ColonnesExistantes(nomPhysique)
                Dim ajouts As New List(Of String)
                Dim configurees As New List(Of String)
                ' Colonnes techniques manquantes (mise à niveau)
                For Each ct As String In techniques
                    Dim nomTech As String = Regex.Match(ct, "\[(\w+)\]").Groups(1).Value
                    If Not existantes.Contains(nomTech) Then
                        ajouts.Add("    ALTER TABLE dbo." & Q(nomPhysique) & " ADD " & ct.TrimStart())
                        messages.Add("Migration " & nomPhysique & " : ajout colonne technique " & nomTech)
                    End If
                Next
                For Each rc As DataRow In tblCols
                    Dim nomCol As String = IsNull(rc("Nom_Colonne"), "")
                    If ValiderIdentifiantSql(nomCol) <> "" Then Continue For
                    configurees.Add(nomCol)
                    If Not existantes.Contains(nomCol) Then
                        Dim ligne = ColonneDDL(rc, nomPhysique, erreurs)
                        If ligne <> "" Then
                            ajouts.Add("    ALTER TABLE dbo." & Q(nomPhysique) & " ADD " & ligne.TrimStart())
                            messages.Add("Migration " & nomPhysique & " : ajout colonne " & nomCol)
                        End If
                    End If
                Next
                ' Colonnes en base absentes des métadonnées : JAMAIS supprimées automatiquement
                Dim techniquesNoms As New List(Of String)
                For Each ct As String In techniques
                    techniquesNoms.Add(Regex.Match(ct, "\[(\w+)\]").Groups(1).Value)
                Next
                For Each colBase As String In existantes
                    If Not configurees.Contains(colBase) AndAlso Not techniquesNoms.Contains(colBase) Then
                        messages.Add("ATTENTION " & nomPhysique & " : la colonne [" & colBase & "] existe en base " &
                                     "mais n'est plus configurée. Elle n'est PAS supprimée (migration non destructive).")
                    End If
                Next
                If ajouts.Count > 0 Then
                    script.AppendLine("/* --- Migration " & nomPhysique & " --- */")
                    For Each a As String In ajouts
                        script.AppendLine(a)
                        script.AppendLine("GO")
                    Next
                End If
            End If

            '---------------------- Index et unicité ----------------------
            For Each rc As DataRow In tblCols
                Dim nomCol As String = IsNull(rc("Nom_Colonne"), "")
                If ValiderIdentifiantSql(nomCol) <> "" Then Continue For
                Dim nomIdx As String = "IX_" & nomPhysique & "_" & nomCol
                If LCase(IsNull(rc("estUnique"), "false")) = "true" Then
                    nomIdx = "UX_" & nomPhysique & "_" & nomCol
                    If Not IndexExiste(nomIdx, nomPhysique) Then
                        script.AppendLine("IF NOT EXISTS (select 1 from sys.indexes where name='" & nomIdx & "' and object_id=object_id('dbo." & nomPhysique & "'))")
                        script.AppendLine("    CREATE UNIQUE INDEX " & Q(nomIdx) & " ON dbo." & Q(nomPhysique) & " (" & Q(nomCol) & ")")
                        script.AppendLine("GO")
                    End If
                ElseIf LCase(IsNull(rc("estIndexe"), "false")) = "true" Then
                    If Not IndexExiste(nomIdx, nomPhysique) Then
                        script.AppendLine("IF NOT EXISTS (select 1 from sys.indexes where name='" & nomIdx & "' and object_id=object_id('dbo." & nomPhysique & "'))")
                        script.AppendLine("    CREATE INDEX " & Q(nomIdx) & " ON dbo." & Q(nomPhysique) & " (" & Q(nomCol) & ")")
                        script.AppendLine("GO")
                    End If
                End If
            Next

            '---------------------- Relation entête -> détail ----------------------
            If roleTable = "DET" AndAlso nomTableEnt <> "" Then
                Dim nomFk As String = "FK_" & nomPhysique & "_Ent"
                Dim onDelete As String = If(regleSuppr = "CASCADE", " ON DELETE CASCADE", "")
                script.AppendLine("IF NOT EXISTS (select 1 from sys.foreign_keys where name='" & nomFk & "')")
                script.AppendLine("    ALTER TABLE dbo." & Q(nomPhysique) & " WITH NOCHECK ADD CONSTRAINT " & Q(nomFk) &
                                  " FOREIGN KEY ([Num_Doc], [id_Societe]) REFERENCES dbo." & Q(nomTableEnt) & " ([Num_Doc], [id_Societe])" & onDelete)
                script.AppendLine("GO")
            End If
        Next
        Return script.ToString()
    End Function

    ''' <summary>
    ''' Exécute un script DDL dans la transaction ADODB ouverte sur cnTx (connexion
    ''' dédiée ouverte par l'appelant) et journalise dans Controle_Designer_DDL_Log.
    ''' L'appelant gère BeginTrans/Commit/Rollback.
    ''' NB : la connexion globale cn n'est JAMAIS utilisée ici : des recordsets
    ''' firehose peuvent y rester en attente (CnExecuting), ce qui fait échouer
    ''' BeginTrans (-2147168227 « dépassement de capacité ») ou exécuterait des
    ''' ordres sur une session implicite HORS transaction.
    ''' </summary>
    Public Sub ExecuterScriptDansTransaction(codPage As String, typeOperation As String, script As String, cnTx As ADODB.Connection)
        If script Is Nothing OrElse script.Trim = "" Then Return
        Dim batches = Regex.Split(script, "(?im)^\s*GO\s*$")
        For Each b As String In batches
            If b.Trim <> "" Then cnTx.Execute(b)
        Next
        JournaliserDDL(codPage, typeOperation, script, "true", "", cnTx)
    End Sub

    ''' <summary>Journalise un DDL exécuté (ou tenté) dans Controle_Designer_DDL_Log.
    ''' cnTx fourni : journalise dans la transaction de l'enregistrement ;
    ''' cnTx omis : journalise hors transaction (cas d'un échec, après rollback).</summary>
    Public Sub JournaliserDDL(codPage As String, typeOperation As String, script As String, resultat As String, message As String,
                              Optional cnTx As ADODB.Connection = Nothing)
        Try
            Dim sql As String = "insert into Controle_Designer_DDL_Log (Cod_Page, Type_Operation, Script_DDL, Resultat, Message, Login_Exec, Date_Exec) values ('" &
                        codPage.Replace("'", "''") & "','" & typeOperation.Replace("'", "''") & "','" &
                        IsNull(script, "").Replace("'", "''") & "','" & resultat & "','" &
                        IsNull(message, "").Replace("'", "''").Substring(0, Math.Min(3900, IsNull(message, "").Length)) & "','" &
                        theUser.Login.Replace("'", "''") & "', getdate())"
            If cnTx Is Nothing Then
                CnExecuting(sql)
            Else
                cnTx.Execute(sql)
            End If
        Catch
            ' La journalisation ne doit jamais masquer l'erreur principale
        End Try
    End Sub

End Module
