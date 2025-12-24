Module Module_LecteurDisques

    Public Function xIsDriveReady(ByVal DriveName As String) As Boolean
        'Vérifie Si un Lecteur Digital est ouvert notamment 'S:'
        Dim objFileSys As Object
        Dim objDrive As Object
        Dim strDrive As String

        On Error GoTo DriveError

        If Left(DriveName, 1) = "" Then
            strDrive = DriveName                    ' If it is a network path, then let it as it is.
        Else
            strDrive = Left(DriveName, 1) & ":"     ' Create the drive name, to be sure it is in the correct format. eg: "C:"
        End If
        objFileSys = CreateObject("Scripting.FileSystemObject")     ' Create the filesystem object
        objDrive = objFileSys.GetDrive(CStr(strDrive))
        If objFileSys.DriveExists(strDrive) Then                        ' Test if the drive exist
            xIsDriveReady = objDrive.IsReady                            ' Test if it is ready to be used
        Else
            xIsDriveReady = False
        End If
        Exit Function

DriveError:
        xIsDriveReady = False
    End Function


    Public Declare Function WNetAddConnection2 Lib "mpr.dll" Alias "WNetAddConnection2A" _
(ByRef lpNetResource As NETRESOURCE, ByVal lpPassword As String,
 ByVal lpUserName As String, ByVal dwFlags As Integer) As Integer

    Public Declare Function WNetCancelConnection2 Lib "mpr" Alias "WNetCancelConnection2A" _
       (ByVal lpName As String, ByVal dwFlags As Integer, ByVal fForce As Integer) As Integer

    Public Structure NETRESOURCE
        Public dwScope As Integer
        Public dwType As Integer
        Public dwDisplayType As Integer
        Public dwUsage As Integer
        Public lpLocalName As String
        Public lpRemoteName As String
        Public lpComment As String
        Public lpProvider As String
    End Structure
    Public DriveLetter As String = "S:"
    Public nr As New NETRESOURCE
    Public strUsername As String
    Public strPassword As String
    Public Const ForceDisconnect As Integer = 1
    Public Const RESOURCETYPE_DISK As Long = &H1
    Public Function MapDrive() As Boolean
        Dim result As Integer
        result = WNetAddConnection2(nr, strPassword, strUsername, 0)
        If result = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function UnMapDrive() As Boolean
        Dim rc As Integer
        rc = WNetCancelConnection2(nr.lpRemoteName, 0, ForceDisconnect)
        If rc = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
