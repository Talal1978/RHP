
Imports System.Text.RegularExpressions

Module Module_Declaration_Var
    Public cn As New ADODB.Connection
    Public cn1 As New OleDb.OleDbConnection
    Friend Zoom_Where1 As String
    Friend Zoom_Cod_Sql As String
    Friend Zoom_Cod As String
    Friend Zoom_Lib As String
    Friend Zoom_Tbl As String
    Friend Zoom_Object As Object
    Friend Zoom_OrderByG As String = ""
    Friend Zoom_Rub As String = ""
    Friend Zoom_Text As New TextBox
    Friend Zoom_Form As Form
    Friend Zoom_Condition As String = ""
    Friend Zoom_Parameters As String = ""
    Friend CouleurBack As Object
    Public PWDUser As String = ""
    Public LegalVersion As Boolean = True
    Public connectionString As String = ""
    Public ConnectionSQL As String = ""
    Public PWDConnectionSQL As String = ""
    Public NbDecimalVen As Integer = 2
    Public NbDecimalAch As Integer = 2
    Public NbDecimalStk As Integer = 2
    Public NbDecimalCtb As Integer = 2
    Public CheckStk As String = "O"
    Public NumVersion As String = "2025.100.00"
    Public FermetureForcee As String = "N"
    Public DefaultLogo As System.Drawing.Image
    Public DB As String = ""
    Public Serveur As String = ""
    Public Tbl_Param_General As New DataTable
    Public Tbl_Param_Rubriques As New DataTable
    Public VarTbl As New DataTable
    Public TblAccess As New DataTable
    Public Tbl_Controle_Def_Label As New DataTable
    Public Tbl_Controle_Def_Ecran As New DataTable
    Public Tbl_Controle_Def_Ecran_Button As New DataTable
    Public Tbl_Controle_Droit_Mnu As New DataTable
    Public Tbl_Controle_Def_Zoom As New DataTable
    Public Tbl_Actions As New DataTable
    Public Tbl_Taches As New DataTable
    Public Tbl_Rdv As New DataTable
    Public Tbl_DernierLus As New DataTable
    Public Tbl_Controle_Def_InformationsComplementaires As New DataTable
    Public Tbl_RH_Agent_Donnees_Diverses_Parametrage As New DataTable
    Public Tbl_Controle_TreeView As New DataTable
    Public Tbl_Param_Unite As New DataTable
    Public Tbl_Controle_Profile_Regles As New DataTable
    Public Tbl_Function_Security As New DataTable
    Public Tbl_User As New DataTable
    Public Usr() As DataRow
    Public SqlErreur As String
    Public MsgRsl As Microsoft.VisualBasic.MsgBoxResult
    Public FilterList As New ArrayList
    Public ActiverAbonnement As String = "N"
    Public ActiveTimer As String = "N"
    Public AbonnementTbl As DataTable
    Public MenuImage As New ImageList()
    Public MenuImageArray As New ArrayList()
    Public FormArray As New ArrayList
    Public GModeAffectationImport As String = ""
    Public ProcessId As Integer = System.Diagnostics.Process.GetCurrentProcess().Id
    Public CodDeviseLocal As String = ""
    Public CodLangue As String = ""
    Public Chart_Type As New ArrayList
    Public Chart_NbSeries As New ArrayList
    Public importPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop
    Public NbLigneReportQuery As Integer
    Public oFiltreSociete As String = ""
    Public InfoSoc As Integer = 0
    Public EstCloturee As String = ""
    Public TablesAvecIdSoc As New List(Of String)
    Public Tbl_EB As New DataTable
    '   Public dicDerniersAcces As New Dictionary(Of String, Object)
    Public WebVersion As Boolean = False
    Public colorBase01 As Color = Color.FromArgb(56, 153, 185)
    Public colorBase02 As Color = Color.FromArgb(94, 185, 117)
    Public colorBase03 As Color = Color.FromArgb(240, 90, 10)
    Public colorBase04 As Color = Color.FromArgb(208, 231, 239)
    Public RHPdefaultFont As Font = New System.Drawing.Font("Century Gothic", 8.25!)
    Public RHPdefaultForeColor As Color = Color.FromArgb(56, 36, 36)
    Public defaultBackColor As Color = Color.FromArgb(250, 250, 250)
    Public jsonFilePath As String = "db.json"
    Public jsonObject As New Newtonsoft.Json.Linq.JObject
    Public sql_injection As String = "\b(eval)\b|\b(set)\b|\b(alter)\b|\b(create)\b|\b(drop)\b|\b(update)\b|\b(delete)\b|\b(truncate)\b|\b(insert)\b|\b(exec)\b|\b(union)\b|\b(cast)\b|\b(join)\b|--|/\*|\*/|""|--"
    Public sql_Sys_RH_Agent_AG As String = ""

    'Public Function ControleInjectionSQL(query As String) As (Boolean, String)
    '    ' Liste blanche stricte
    '    Dim allowedPattern As String = "^[\s\w\.,\(\)\*=<>]+$"

    '    ' 1. Vérifier les caractères autorisés
    '    If Not Regex.IsMatch(query, allowedPattern) Then
    '        Return (False, "Caractères non autorisés détectés")
    '    End If

    '    ' 2. Bloquer les mots-clés dangereux (blacklist complémentaire)
    '    Dim dangerousKeywords As String() = {
    '    "INSERT", "UPDATE", "DELETE", "DROP", "CREATE", "ALTER",
    '    "EXEC", "EXECUTE", "TRUNCATE", "GRANT", "REVOKE",
    '    "UNION", "DECLARE", "CAST", "CONVERT", "SCRIPT",
    '    "XP_", "SP_", "OPENROWSET", "OPENDATASOURCE"
    '}

    '    For Each keyword In dangerousKeywords
    '        If Regex.IsMatch(query, "\b" & keyword & "\b", RegexOptions.IgnoreCase) Then
    '            Return (False, $"Mot-clé interdit détecté: {keyword}")
    '        End If
    '    Next

    '    ' 3. Vérifier la présence de SELECT (obligatoire)
    '    If Not Regex.IsMatch(query, "\bSELECT\b", RegexOptions.IgnoreCase) Then
    '        Return (False, "La requête doit commencer par SELECT")
    '    End If

    '    ' 4. Vérifier que seuls les mots-clés autorisés sont présents
    '    Dim allowedKeywords As String() = {
    '    "SELECT", "FROM", "WHERE", "LEFT", "RIGHT", "INNER",
    '    "CROSS", "JOIN", "APPLY", "AND", "OR", "ON", "AS",
    '    "ORDER", "BY", "GROUP", "HAVING", "DISTINCT", "TOP"
    '}

    '    Dim words As MatchCollection = Regex.Matches(query, "\b[a-zA-Z_][a-zA-Z0-9_]*\b")

    '    For Each word As Match In words
    '        Dim isAllowed As Boolean = False

    '        ' Vérifier si c'est un mot-clé autorisé
    '        For Each allowed In allowedKeywords
    '            If String.Equals(word.Value, allowed, StringComparison.OrdinalIgnoreCase) Then
    '                isAllowed = True
    '                Exit For
    '            End If
    '        Next

    '        ' Si ce n'est pas un mot-clé, on suppose que c'est un nom de colonne/table
    '        ' Vérifier qu'il suit les règles de nommage SQL standard
    '        If Not isAllowed Then
    '            If Not Regex.IsMatch(word.Value, "^[a-zA-Z_][a-zA-Z0-9_]*$") Then
    '                Return (False, $"Nom invalide: {word.Value}")
    '            End If
    '        End If
    '    Next

    '    Return (True, "Requête valide")
    'End Function

    Function GlobalVar(ByVal GV As String) As String
        Dim GVVal As String = ""
        Select Case GV.ToUpper.Trim
            Case "GV_USER"
                GVVal = theUser.id_User
            Case "GV_LOGIN"
                GVVal = theUser.Login
            Case "GV_USERNAME"
                GVVal = CnExecuting("select isnull((select ltrim(rtrim(isnull(Nom_User,'') + ' ' + isnull(Prenom_User,''))) from Controle_Users where id_User='" & theUser.id_User & "'),'')").Fields(0).Value
            Case "GV_CONN"
                GVVal = connectionString
            Case "GV_DB"
                GVVal = DB
            Case "GV_NOW"
                GVVal = FormatDateTime(Now.Date, DateFormat.ShortDate)
            Case "GV_DEBMOIS"
                GVVal = "01/" & IIf(CStr(Now.Date.Month).Length < 2, "0" & CStr(Now.Date.Month), CStr(Now.Date.Month)) & "/" & CStr(Now.Date.Year)
            Case "GV_FINMOIS"
                GVVal = CStr(DateTime.DaysInMonth(Now.Date.Year, Now.Date.Month)) & "/" & IIf(CStr(Now.Date.Month).Length < 2, "0" & CStr(Now.Date.Month), CStr(Now.Date.Month)) & "/" & CStr(Now.Date.Year)
            Case "GV_YEAR"
                GVVal = Now.Year
            Case "GV_MONTH"
                GVVal = Now.Month
            Case "GV_DAY"
                GVVal = Now.Day
            Case "GV_NOMMACHINE"
                GVVal = My.Computer.Name
            Case "GV_IP"
                GVVal = Net.Dns.GetHostEntry(My.Computer.Name).AddressList(0).ToString
            Case "GV_PROCESSID"
                GVVal = ProcessId
            Case "GV_NUMVERSION"
                GVVal = NumVersion
            Case "GV_DEBYEAR"
                GVVal = "01/01/" & Now.Year
            Case "GV_IDSOC"
                GVVal = Societe.id_Societe
        End Select
        Return GVVal
    End Function

End Module
