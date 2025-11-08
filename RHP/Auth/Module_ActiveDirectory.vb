Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement

Module Module_ActiveDirectory
    Public Structure ADUserInfo
        Public Exists As Boolean
        Public DisplayName As String
        Public Email As String
        Public SAMAccountName As String
        Public DistinguishedName As String
        Public Property GivenName As String ' Prénom
        Public Property Surname As String ' Nom de famille
        Public Property Description As String ' Titre/poste
        Public Enabled As Boolean
    End Structure
    Function AuthenticateWithActiveDirectory(username As String, password As String) As Boolean
        Try
            ' Méthode 1 : Utilisation de PrincipalContext (recommandée)
            Using context As New PrincipalContext(ContextType.Domain)
                Return context.ValidateCredentials(username, password)
            End Using
        Catch ex As Exception
            ' Si la méthode PrincipalContext échoue, essayer avec DirectoryEntry
            Try
                Return AuthenticateWithDirectoryEntry(username, password)
            Catch ex2 As Exception
                ' Log l'erreur si nécessaire
                System.Diagnostics.Debug.WriteLine("Erreur AD Auth: " & ex2.Message)
                Return False
            End Try
        End Try
    End Function
    Function AuthenticateWithDirectoryEntry(username As String, password As String) As Boolean
        Try
            ' Obtenir le domaine actuel
            Dim domain As String = Environment.UserDomainName

            ' Essayer avec différents formats de nom d'utilisateur
            Dim userFormats() As String = {
                username,
                domain & "\" & username,
                username & "@" & domain
            }

            For Each userFormat In userFormats
                Try
                    Using entry As New DirectoryEntry("LDAP://" & domain, userFormat, password)
                        ' Tenter d'accéder à une propriété pour valider les credentials
                        Dim name As Object = entry.NativeObject
                        Return True
                    End Using
                Catch
                    ' Continuer avec le format suivant
                    Continue For
                End Try
            Next

            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function GetADUserInfo(username As String) As ADUserInfo
        Dim userInfo As New ADUserInfo()

        Try
            Using context As New PrincipalContext(ContextType.Domain)
                Using user As UserPrincipal = UserPrincipal.FindByIdentity(context, username)
                    If user IsNot Nothing Then
                        userInfo.Exists = True
                        userInfo.DisplayName = If(String.IsNullOrEmpty(user.DisplayName), user.Name, user.DisplayName)
                        userInfo.Email = user.EmailAddress
                        userInfo.SAMAccountName = user.SamAccountName
                        userInfo.DistinguishedName = user.DistinguishedName
                        userInfo.Description = user.Description
                        userInfo.GivenName = user.GivenName
                        userInfo.Surname = user.Surname
                        userInfo.Enabled = If(user.Enabled.HasValue, user.Enabled.Value, False)
                    Else
                        userInfo.Exists = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' En cas d'erreur, utiliser DirectorySearcher
            Try
                userInfo = GetADUserInfoWithDirectorySearcher(username)
            Catch ex2 As Exception
                System.Diagnostics.Debug.WriteLine("Erreur récupération info AD: " & ex2.Message)
                userInfo.Exists = False
            End Try
        End Try

        Return userInfo
    End Function
    Function GetADUserInfoWithDirectorySearcher(username As String) As ADUserInfo
        Dim userInfo As New ADUserInfo()

        Try
            Using searcher As New DirectorySearcher()
                searcher.Filter = String.Format("(&(objectClass=user)(|(sAMAccountName={0})(userPrincipalName={0})))", username)
                searcher.PropertiesToLoad.AddRange({"displayName", "mail", "sAMAccountName", "distinguishedName", "userAccountControl"})

                Dim result As SearchResult = searcher.FindOne()
                If result IsNot Nothing Then
                    userInfo.Exists = True
                    userInfo.DisplayName = If(result.Properties("displayName").Count > 0, result.Properties("displayName")(0).ToString(), username)
                    userInfo.Email = If(result.Properties("mail").Count > 0, result.Properties("mail")(0).ToString(), "")
                    userInfo.SAMAccountName = If(result.Properties("sAMAccountName").Count > 0, result.Properties("sAMAccountName")(0).ToString(), username)
                    userInfo.DistinguishedName = If(result.Properties("distinguishedName").Count > 0, result.Properties("distinguishedName")(0).ToString(), "")
                    userInfo.Description = If(result.Properties("description").Count > 0, result.Properties("description")(0).ToString(), "")
                    userInfo.GivenName = If(result.Properties("givenName").Count > 0, result.Properties("givenName")(0).ToString(), "")
                    userInfo.Surname = If(result.Properties("sn").Count > 0, result.Properties("sn")(0).ToString(), "")
                    ' Vérifier si le compte est activé (userAccountControl & 2 = 0 signifie activé)
                    If result.Properties("userAccountControl").Count > 0 Then
                        Dim uac As Integer = CInt(result.Properties("userAccountControl")(0))
                        userInfo.Enabled = (uac And 2) = 0
                    End If
                Else
                    userInfo.Exists = False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Erreur DirectorySearcher: " & ex.Message)
            userInfo.Exists = False
        End Try

        Return userInfo
    End Function
End Module
