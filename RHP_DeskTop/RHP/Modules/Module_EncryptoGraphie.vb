Imports System.Security.Cryptography
Imports System.Text

Module Module_EncryptoGraphie
    ' Fixed parameters
    Private Const Password As String = "cH0uCh0ub@B@"
    Private Const SaltValue As String = "maraYliChaJoud"
    Private Const PasswordIterations As Integer = 1000 ' For example
    Private Const InitVector As String = "XXXXXXXXXXXXXXXX" ' Must be 16 bytes
    Private Const KeySize As Integer = 256 ' Key size in bits

    ' Helper function to create a key
    Function CreateKey() As Byte()
        Dim saltBytes As Byte() = Encoding.UTF8.GetBytes(SaltValue)
        Dim pdb As New Rfc2898DeriveBytes(Password, saltBytes, PasswordIterations)
        Return pdb.GetBytes(KeySize / 8)
    End Function

    ' Simplified Encrypt function
    Function Encrypt(textOrig As String) As String
        Dim initVectorBytes As Byte() = Encoding.UTF8.GetBytes(InitVector)
        Dim textBytes As Byte() = Encoding.UTF8.GetBytes(textOrig)
        Dim keyBytes As Byte() = CreateKey()

        Using encryptor As Aes = Aes.Create()
            encryptor.Mode = CipherMode.CBC
            encryptor.Padding = PaddingMode.PKCS7
            encryptor.Key = keyBytes
            encryptor.IV = initVectorBytes

            Using memStream As New IO.MemoryStream()
                Using cryptoStream As New CryptoStream(memStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cryptoStream.Write(textBytes, 0, textBytes.Length)
                    cryptoStream.FlushFinalBlock()
                    Return Convert.ToBase64String(memStream.ToArray())
                End Using
            End Using
        End Using
    End Function

    ' Simplified Decrypt function
    Function Decrypt(textCryp As String) As String
        Try
            Dim initVectorBytes As Byte() = Encoding.UTF8.GetBytes(InitVector)
            Dim textBytes As Byte() = Convert.FromBase64String(textCryp)
            Dim keyBytes As Byte() = CreateKey()

            Using decryptor As Aes = Aes.Create()
                decryptor.Mode = CipherMode.CBC
                decryptor.Padding = PaddingMode.PKCS7
                decryptor.Key = keyBytes
                decryptor.IV = initVectorBytes

                Using memStream As New IO.MemoryStream(textBytes)
                    Using cryptoStream As New CryptoStream(memStream, decryptor.CreateDecryptor(), CryptoStreamMode.Read)
                        Dim decryptedBytes As Byte() = New Byte(textBytes.Length - 1) {}
                        Dim bytesRead As Integer = cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length)
                        Return Encoding.UTF8.GetString(decryptedBytes, 0, bytesRead)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return Nothing ' Or handle the error as needed
        End Try
    End Function
End Module
