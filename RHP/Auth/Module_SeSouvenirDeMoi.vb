Imports System.Management
Imports System.Text.Json
Module Module_SeSouvenirDeMoi
    Public Structure SimpleRememberData
        Public SeSouvenir As Boolean
        Public UserLogin As String
        Public Default_Interface As Boolean
        Public Conn As String
        Public ProcessorId As String
        Public VolumeSerial As String
        Public CreatedDate As String
    End Structure
    Public Structure rememberedData
        Public UserLogin As String
        Public Conn As String
        Public Default_Interface As Boolean
        Public creaDat As Date
    End Structure
    Private Function GetProcessorId() As String
        Try
            Using searcher As New ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor")
                For Each obj As ManagementObject In searcher.Get()
                    Dim procId As Object = obj("ProcessorId")
                    If procId IsNot Nothing Then
                        Return procId.ToString().Trim()
                    End If
                Next
            End Using
        Catch ex As Exception
            ' Fallback : utiliser une autre propriété du processeur
            Try
                Using searcher As New ManagementObjectSearcher("SELECT Name, Manufacturer FROM Win32_Processor")
                    For Each obj As ManagementObject In searcher.Get()
                        Return obj("Manufacturer").ToString() & "-" & obj("Name").ToString()
                    Next
                End Using
            Catch
            End Try
        End Try
        Return ""
    End Function
    Private Function GetSystemDiskSerial() As String
        Try
            Using searcher As New ManagementObjectSearcher("SELECT VolumeSerialNumber FROM Win32_LogicalDisk WHERE DriveType = 3 AND DeviceID = 'C:'")
                For Each obj As ManagementObject In searcher.Get()
                    Dim serial As Object = obj("VolumeSerialNumber")
                    If serial IsNot Nothing Then
                        Return serial.ToString().Trim()
                    End If
                Next
            End Using
        Catch ex As Exception
            ' Fallback : utiliser les informations du disque physique
            Try
                Using searcher As New ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia WHERE Tag LIKE '%PHYSICALDRIVE0%'")
                    For Each obj As ManagementObject In searcher.Get()
                        Dim serial As Object = obj("SerialNumber")
                        If serial IsNot Nothing Then
                            Return serial.ToString().Trim().Replace(" ", "")
                        End If
                    Next
                End Using
            Catch
            End Try
        End Try
        Return ""
    End Function
    Sub SaveSecureRememberMe(strlogin As String, strConn As String, defaultInterface As Boolean)
        Try
            ' Supprimer l'ancien fichier s'il existe
            Dim filePath As String = My.Application.Info.DirectoryPath & "\login\SecureRemember.dat"
            If IO.File.Exists(filePath) Then
                IO.File.Delete(filePath)
            End If
            ' Créer le dossier si nécessaire
            If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\login") Then
                IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\login")
            End If

            ' Obtenir les identifiants hardware irremplaçables
            Dim processorId As String = GetProcessorId()
            Dim diskSerial As String = GetSystemDiskSerial()

            ' Vérifier qu'on a pu récupérer les infos
            If String.IsNullOrEmpty(processorId) OrElse String.IsNullOrEmpty(diskSerial) Then
                Return ' Échec de récupération des infos hardware
            End If

            ' Créer la structure de données
            Dim rememberData As New SimpleRememberData With {
            .SeSouvenir = True,
            .UserLogin = strlogin.Trim(),
            .Conn = strConn.Trim(),
            .Default_Interface = defaultInterface,
            .ProcessorId = processorId,
            .VolumeSerial = diskSerial,
            .CreatedDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        }
            Dim options As New JsonSerializerOptions()
            options.IncludeFields = True
            Dim jsonString As String = System.Text.Json.JsonSerializer.Serialize(rememberData, options)
            '    MsgBox(jsonString)
            Dim encryptedJson As String = Encrypt(jsonString)
            ' Sauvegarder le fichier chiffré
            If Not String.IsNullOrEmpty(encryptedJson) Then
                IO.File.WriteAllText(filePath, encryptedJson)
            End If

        Catch ex As Exception
            ' Gestion d'erreur silencieuse
            System.Diagnostics.Debug.WriteLine("Erreur SaveSecureRememberMe: " & ex.Message)
        End Try
    End Sub
    Function LoadSecureRememberMe() As rememberedData
        Try
            Dim filePath As String = My.Application.Info.DirectoryPath & "\login\SecureRemember.dat"

            ' Vérifier que le fichier existe
            If Not IO.File.Exists(filePath) Then
                Return New rememberedData With {.Conn = "", .UserLogin = "", .Default_Interface = False}
            End If

            ' Obtenir les identifiants hardware actuels
            Dim currentProcessorId As String = GetProcessorId()
            Dim currentDiskSerial As String = GetSystemDiskSerial()

            ' Vérifier qu'on peut récupérer les infos hardware
            If String.IsNullOrEmpty(currentProcessorId) OrElse String.IsNullOrEmpty(currentDiskSerial) Then
                Return New rememberedData With {.Conn = "", .UserLogin = "", .Default_Interface = False}
            End If

            ' Lire le fichier chiffré
            Dim encryptedData As String = IO.File.ReadAllText(filePath)

            ' Déchiffrer avec la clé hardware actuelle
            Dim decryptedJson As String = Decrypt(encryptedData)
            ' Si le déchiffrement échoue, supprimer le fichier
            If String.IsNullOrEmpty(decryptedJson) Then
                IO.File.Delete(filePath)
                Return New rememberedData With {.Conn = "", .UserLogin = "", .Default_Interface = False}
            End If

            ' Désérialiser le JSON
            Dim options As New JsonSerializerOptions()
            options.IncludeFields = True
            Dim rememberData As SimpleRememberData = System.Text.Json.JsonSerializer.Deserialize(Of SimpleRememberData)(decryptedJson, options)

            ' Valider les données
            If Not rememberData.SeSouvenir Then
                IO.File.Delete(filePath)
                Return New rememberedData With {.Conn = "", .UserLogin = "", .Default_Interface = False}
            End If

            ' Vérifier que les identifiants hardware correspondent
            If rememberData.ProcessorId <> currentProcessorId OrElse rememberData.VolumeSerial <> currentDiskSerial Then
                IO.File.Delete(filePath)
                Return New rememberedData With {.Conn = "", .UserLogin = "", .Default_Interface = False}
            End If

            ' Vérifier la date (optionnel : expirer après 30 jours)
            Try
                Dim createdDate As DateTime = DateTime.ParseExact(rememberData.CreatedDate, "dd/MM/yyyy HH:mm:ss", Nothing)
                If DateTime.Now.Subtract(createdDate).Days > 30 Then
                    IO.File.Delete(filePath)
                    Return New rememberedData With {.Conn = "", .UserLogin = "", .Default_Interface = False}
                End If
            Catch
                Return New rememberedData With {.Conn = "", .UserLogin = "", .Default_Interface = False}
            End Try

            ' Tout est OK, remplir les champs
            Return New rememberedData With {.Conn = rememberData.Conn, .Default_Interface = rememberData.Default_Interface, .UserLogin = rememberData.UserLogin, .creaDat = rememberData.CreatedDate}
        Catch ex As Exception
            ' En cas d'erreur, supprimer le fichier et retourner False
            Try
                Dim filePath As String = My.Application.Info.DirectoryPath & "\login\SecureRemember.dat"
                If IO.File.Exists(filePath) Then
                    IO.File.Delete(filePath)
                End If
            Catch
            End Try
            Return New rememberedData With {.Conn = "", .UserLogin = "", .Default_Interface = False}
        End Try
    End Function
    Sub ClearSecureRememberMe()
        Try
            Dim filePath As String = My.Application.Info.DirectoryPath & "\login\SecureRemember.dat"
            If IO.File.Exists(filePath) Then
                IO.File.Delete(filePath)
            End If
        Catch ex As Exception
            ' Erreur silencieuse
        End Try
    End Sub

End Module
