''' <summary>
''' Module transverse du domaine Sante (RHP_DeskTop).
''' Journal d'acces medical (append-only), controle des fonctions de securite
''' SANTE_CLINIQUE / SANTE_ADMIN / SANTE_AUDIT, verrou CNDP, execution SQL
''' parametree (ADODB.Command) pour les ecritures sur les tables cliniques.
''' </summary>
Module Module_Sante

    ''' <summary>Journal d'acces medical. Ne bloque jamais l'application.</summary>
    Sub Sante_Audit(action As String, objet As String, valeurIndex As String,
                    Optional matriculeConcerne As String = "",
                    Optional succes As Boolean = True,
                    Optional motif As String = "")
        Try
            Dim cmd As New ADODB.Command
            With cmd
                .ActiveConnection = cn
                .CommandType = ADODB.CommandTypeEnum.adCmdText
                .CommandText = "insert into RH_Sante_Audit_Acces " &
                    "(id_Societe, Login_User, id_User, Cod_Profile, Typ_Role, Action, Objet, Valeur_Index, Matricule_Concerne, Poste, IP, Succes, Motif) " &
                    "values (?,?,?,?,?,?,?,?,?,?,?,?,?)"
                .Parameters.Append(.CreateParameter("p1", ADODB.DataTypeEnum.adInteger, ADODB.ParameterDirectionEnum.adParamInput, , Societe.id_Societe))
                .Parameters.Append(.CreateParameter("p2", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 50, IsNull(theUser.Login, "")))
                .Parameters.Append(.CreateParameter("p3", ADODB.DataTypeEnum.adInteger, ADODB.ParameterDirectionEnum.adParamInput, , IsNull(theUser.id_User, -1)))
                .Parameters.Append(.CreateParameter("p4", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 10, CStr(IsNull(theUser.Cod_Profile, -1))))
                .Parameters.Append(.CreateParameter("p5", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 10, IsNull(theUser.Typ_Role, "")))
                .Parameters.Append(.CreateParameter("p6", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 10, Gauche(action, 10)))
                .Parameters.Append(.CreateParameter("p7", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 50, Gauche(objet, 50)))
                .Parameters.Append(.CreateParameter("p8", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 100, Gauche(valeurIndex, 100)))
                .Parameters.Append(.CreateParameter("p9", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 20, Gauche(matriculeConcerne, 20)))
                .Parameters.Append(.CreateParameter("p10", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 100, Gauche(IsNull(Environment.MachineName, ""), 100)))
                .Parameters.Append(.CreateParameter("p11", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 50, ""))
                .Parameters.Append(.CreateParameter("p12", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 1, IIf(succes, "1", "0")))
                .Parameters.Append(.CreateParameter("p13", ADODB.DataTypeEnum.adVarWChar, ADODB.ParameterDirectionEnum.adParamInput, 250, Gauche(motif, 250)))
                .Execute()
            End With
        Catch ex As Exception
            ' Le journal ne doit jamais interrompre le traitement metier
        End Try
    End Sub

    ''' <summary>Vrai si le profil courant detient la fonction de securite (SANTE_CLINIQUE/ADMIN/AUDIT).
    ''' Le controle s'applique y compris au profil 1 (pas de bypass pour les donnees de sante).</summary>
    Function Sante_FonctionActive(fonction As String) As Boolean
        Try
            If IsNull(theUser.Cod_Profile, 0) = 0 Then Return False
            Dim rs As ADODB.Recordset = CnExecuting(
                "select count(*) from Controle_Droit_Functions where Cod_Profile='" & theUser.Cod_Profile &
                "' and Function_Sec='" & fonction & "' and isnull(Actif,'false')='true'")
            Return CInt(rs.Fields(0).Value) > 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>Controle d'acces a un domaine sante ; journalise le refus.</summary>
    Function Sante_CheckAccess(domaine As String, objet As String) As Boolean
        Dim fonctions As String()
        Select Case domaine
            Case "CLINIQUE" : fonctions = {"SANTE_CLINIQUE"}
            Case "ADMIN" : fonctions = {"SANTE_ADMIN", "SANTE_CLINIQUE"}
            Case "AUDIT" : fonctions = {"SANTE_AUDIT"}
            Case Else : fonctions = {"SANTE_ADMIN"}
        End Select
        For Each f In fonctions
            If Sante_FonctionActive(f) Then Return True
        Next
        Sante_Audit("AUTH_KO", objet, "", "", False, "Fonction " & domaine & " non accordee")
        Return False
    End Function

    ''' <summary>Verrou de mise en production CNDP : vrai si le traitement doit etre bloque.</summary>
    Function Sante_VerrouCndp() As Boolean
        Try
            Dim rs As ADODB.Recordset = CnExecuting(
                "select dbo.Sys_Sante_Param('BLOCAGE_PROD_SANS_CNDP', " & Societe.id_Societe & ") as b, " &
                "isnull(dbo.Sys_Sante_Param('CNDP_NUM_AUTORISATION', " & Societe.id_Societe & "),'') as a")
            Return (IsNull(rs.Fields("b").Value, "") = "O" AndAlso Trim(IsNull(rs.Fields("a").Value, "")) = "")
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>Execution SQL parametree (anti-injection) pour les tables du module.
    ''' params : tableau de tableaux {nom, type ADODB.DataTypeEnum, taille (0 = non fournie, -1 = MAX), valeur}.</summary>
    Function Sante_Execute(sql As String, params As Object(,)) As Boolean
        Try
            Dim cmd As New ADODB.Command
            With cmd
                .ActiveConnection = cn
                .CommandType = ADODB.CommandTypeEnum.adCmdText
                .CommandText = sql
                For i = 0 To params.GetLength(0) - 1
                    Dim taille As Integer = CInt(params(i, 2))
                    Dim valeur As Object = params(i, 3)
                    If valeur Is DBNull.Value Then valeur = Nothing
                    If taille <> 0 Then
                        .Parameters.Append(.CreateParameter(CStr(params(i, 0)), CType(params(i, 1), ADODB.DataTypeEnum), ADODB.ParameterDirectionEnum.adParamInput, taille, valeur))
                    Else
                        .Parameters.Append(.CreateParameter(CStr(params(i, 0)), CType(params(i, 1), ADODB.DataTypeEnum), ADODB.ParameterDirectionEnum.adParamInput, , valeur))
                    End If
                Next
                .Execute()
            End With
            Return True
        Catch ex As Exception
            ErrorMsg(ex)
            Return False
        End Try
    End Function

    ''' <summary>Scalar SQL parametre (une valeur).</summary>
    Function Sante_Scalar(sql As String, params As Object(,)) As Object
        Dim cmd As New ADODB.Command
        With cmd
            .ActiveConnection = cn
            .CommandType = ADODB.CommandTypeEnum.adCmdText
            .CommandText = sql
            For i = 0 To params.GetLength(0) - 1
                Dim taille As Integer = CInt(params(i, 2))
                Dim valeur As Object = params(i, 3)
                If valeur Is DBNull.Value Then valeur = Nothing
                If taille <> 0 Then
                    .Parameters.Append(.CreateParameter(CStr(params(i, 0)), CType(params(i, 1), ADODB.DataTypeEnum), ADODB.ParameterDirectionEnum.adParamInput, taille, valeur))
                Else
                    .Parameters.Append(.CreateParameter(CStr(params(i, 0)), CType(params(i, 1), ADODB.DataTypeEnum), ADODB.ParameterDirectionEnum.adParamInput, , valeur))
                End If
            Next
            Dim rs As ADODB.Recordset = .Execute()
            If rs.EOF Then Return Nothing
            Return rs.Fields(0).Value
        End With
    End Function

    ''' <summary>Numerotation des documents sante : PREFIXE+idSoc+"-"+annee+seq(6).</summary>
    Function Sante_NouveauNumero(prefixe As String, tableName As String, colNum As String, colDate As String) As String
        Dim sql As String = "select isnull(max(racine),0) as racine from (" &
            "select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end) as racine from " & tableName &
            " outer apply(select RIGHT(" & colNum & ",6) as racine)n " &
            "where id_Societe=" & Societe.id_Societe & " and year(" & colDate & ")=year(getdate()))f"
        Dim rs As ADODB.Recordset = CnExecuting(sql)
        Return prefixe & Societe.id_Societe & "-" & Now.Year & Droite("000000" & CInt(rs.Fields(0).Value + 1), 6)
    End Function

    ''' <summary>Calcul de la prochaine echeance via la fonction du socle.</summary>
    Function Sante_CalculEcheance(matricule As String, datVisite As Date, ByRef codRegle As String) As Object
        codRegle = ""
        Dim rs As ADODB.Recordset = CnExecuting(
            "select Dat_Prochaine_Visite, Cod_Regle_Appliquee from dbo.Sys_Sante_Prochaine_Visite('" &
            matricule & "', " & Societe.id_Societe & ", '" & datVisite.ToString("yyyy-MM-dd") & "')")
        If rs.EOF Then Return Nothing
        codRegle = IsNull(rs.Fields("Cod_Regle_Appliquee").Value, "")
        Return rs.Fields("Dat_Prochaine_Visite").Value
    End Function

    ''' <summary>Libelle d'un parametre reglementaire (avec sa source) pour affichage.</summary>
    Function Sante_Param(codParam As String, Optional defaut As String = "") As String
        Return IsNull(Sante_Scalar("select dbo.Sys_Sante_Param('" & codParam & "', " & Societe.id_Societe & ")", New Object(-1, 3) {}), defaut).ToString()
    End Function
End Module
