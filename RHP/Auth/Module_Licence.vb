Module Module_Licence
    Public oKle As String = ""
    Public UriStr0 As String = "http://ray1.ma/apps"
    Dim UriStr As String = ""
    Function GetLiceIdent() As String
        Dim ostr As String = CnExecuting("declare @str varchar(max),@str2 varchar(max),@i int, @month int,@day int
select @day=day(createdate),  @month=month(createdate), @str2 ='',@i=0,@str = Reverse(CONVERT(nvarchar, createdate, 112) + 
    REPLACE(CONVERT(nvarchar, createdate, 114), ':', '')) FROM sys.syslogins  where upper(name) like '%AUTORIT%SYS%' or upper(name) like '%NT SERVICE%SQLWriter%'
set @day=case when @day<10 or @day>20 then 15 else @day end
while @i<=len(@str)
begin
set @str2 = @str2+convert(nvarchar(50),power(convert(bigint,substring(@str,@i+1,1)),@day))
set @i=@i+1
end
select substring(@str2,@month,32), @str2").Fields(0).Value
        Return ostr
    End Function
    Function getClef() As String

        Dim strId As String = GetLiceIdent()
        Dim strkey As String = ""
        Dim i, j As Integer
        i = 1
        j = strId.Length
        Do While i < j
            strkey &= IIf(i Mod 2 = 0, Mid(strId, i, 1), Mid(strId, j, 1))
            i += 1
            j -= 1
        Loop
        Return Mid(strkey, 9, 4) & Mid(strkey, 1, 4) & Mid(strkey, 13, 4) & Mid(strkey, 5, 4)


    End Function
    Function EstLicConforme(ByVal okey As String) As Boolean
        If okey = getClef() Then
            Return True
        Else
            Return False
        End If
    End Function
    Dim WithEvents BackgroundWorker1 As New System.ComponentModel.BackgroundWorker
    Dim onOff As Boolean = True
    ' Import necessary namespaces
    Sub VerificationLicenceEtVersion()
        If onOff Then
            onOff = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ' Initialize the ChromeDriver with headless mode.
        Dim sr As New System.Net.WebClient
        ChargerDroit()
        If oKle = "" Then oKle = CnExecuting("select isnull((select top 1 Licence from Controle_Certificat),'')").Fields(0).Value


        Dim responseSrv As String = ""
        Dim statut As Integer = 0

        Try
            If Not IO.Directory.Exists("lic") Then IO.Directory.CreateDirectory("lic")
            If IO.File.Exists("lic\cle.cle") Then
                Dim srd As New IO.StreamReader("lic\cle.cle")
                Dim uriTemp As String = IsNull(Decrypt(srd.ReadLine), "").Trim
                If uriTemp <> "" Then
                    UriStr0 = uriTemp
                    GoTo suite0
                End If
                srd.Close()
            End If

            UriStr = UriStr0
suite0:
            UriStr &= "/lic_rhp.php?db=" & DB & "&usr=" & theUser.Login & "&soc=" & Societe.Denomination & "&ver=" & NumVersion & "&lic=" & oKle
            Dim nbTentatives As Integer = 0
suite:
            ' Navigate to the URL in headless mode.
            responseSrv = sr.DownloadString(UriStr)
            responseSrv = responseSrv.Replace("</body>", "").Replace("</html>", "").Replace("<html>", "").Replace("<body>", "").Replace("<head>", "").Replace("</head>", "")
            ' Check for a valid license response.
            If responseSrv.Trim.Contains("Num_Licence~" & oKle) Then
                Dim rs As New ADODB.Recordset
                rs.Open("select * from Controle_Certificat", cn, 2, 2)
                If rs.EOF Then
                    rs.AddNew()
                Else
                    rs.Update()
                End If
                rs("Licence").Value = oKle
                rs("valic").Value = Encrypt(oKle & "$" & responseSrv.Trim)
                rs.Update()
                rs.Close()
            Else
                If nbTentatives > 2 Then
                    CnExecuting("truncate table Controle_Licencing")
                    Droits.EstAuthentic = False
                End If
                nbTentatives += 1
                GoTo suite
            End If
            ChargerDroit()
        Catch ex As Exception
            MsgBox("Error: " & vbCrLf & UriStr & ex.Message)
        Finally
            sr.Dispose() ' Ensure the driver quits to close the browser window.
        End Try

    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        onOff = True
    End Sub
    Sub ChargerDroit()
        Dim reponseEnregistree As String = Decrypt(CnExecuting("select isnull((select top 1 valic from Controle_Certificat),'')").Fields(0).Value)
        Try
            If reponseEnregistree <> "" Then
                Dim rep As String() = reponseEnregistree.Split("$")
                Droits.EstAuthentic = EstLicConforme(rep(0))

                Dim resp() As String = rep(1).Split("|")
                Dim nrw() As DataRow
                For i = 0 To resp.Length - 1
                    nrw = LicTbl.Select("[Option]='" & resp(i).Split("~")(0) & "'")
                    If nrw.Length > 0 Then
                        If nrw(0) IsNot Nothing Then nrw(0).Item("Droit") = IsNull(resp(i).Split("~")(1), "")
                    End If
                    Select Case resp(i).Split("~")(0)
                        Case "EstAuthentic"
                            If Droits.EstAuthentic Then Droits.EstAuthentic = IIf(nrw(0).Item("Droit") = "1", True, False)
                        Case "Dat_Deb_Contrat"
                            If IsDate(nrw(0).Item("Droit")) Then
                                Droits.DatDebContrat = nrw(0).Item("Droit")
                            Else
                                Droits.DatDebContrat = "01/01/1900"
                            End If
                        Case "Dat_Fin_Contrat"
                            If IsDate(nrw(0).Item("Droit")) Then
                                Droits.DatFinContrat = nrw(0).Item("Droit")
                            Else
                                Droits.DatFinContrat = "01/01/2900"
                            End If
                        Case "Nb_Societes"
                            Droits.NbMaxSoc = ConvertEntier(nrw(0).Item("Droit"))
                        Case "Nb_Users"
                            Droits.NbUsers = ConvertEntier(nrw(0).Item("Droit"))
                        Case "DamanCom"
                            Droits.DamanCom = ConvertBoolean(nrw(0).Item("Droit"))
                        Case "IR_9421"
                            Droits.IR_9421 = ConvertBoolean(nrw(0).Item("Droit"))
                        Case "GED"
                            Droits.GED = ConvertBoolean(nrw(0).Item("Droit"))
                        Case "ORG"
                            Droits.ORG = ConvertBoolean(nrw(0).Item("Droit"))
                        Case "ANA"
                            Droits.ANA = ConvertBoolean(nrw(0).Item("Droit"))
                        Case "WEB"
                            Droits.VersionWeb = ConvertBoolean(nrw(0).Item("Droit"))
                            If IO.File.Exists(My.Application.Info.DirectoryPath & "\lic\WebLicence.ini") Then IO.File.Delete(My.Application.Info.DirectoryPath & "\lic\WebLicence.ini")
                            If Droits.VersionWeb Then
                                Dim sr As New IO.StreamWriter(My.Application.Info.DirectoryPath & "\lic\WebLicence.ini", True)
                                sr.WriteLine(Encrypt(GetLiceIdent() & "|WEB$"))
                                sr.Close()
                            End If
                    End Select
                Next
            End If
        Catch ex As Exception
            '  ShowMessageBox("Chargement des droits :" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Structure lesDroits
        Public NbSocCree As Integer
        Public NbMaxSoc As Integer
        Public NbSocCreeBaseEncours As Integer
        Public DatDebContrat As Date
        Public DatFinContrat As Date
        Public Tranche_Effectif As Integer
        Public EstAuthentic As Boolean
        Public NbUsers As Integer
        Public DamanCom As Boolean
        Public IR_9421 As Boolean
        Public GED As Boolean
        Public ORG As Boolean
        Public ANA As Boolean
        Public VersionWeb As Boolean
    End Structure
    Public Droits As lesDroits
    Sub Droit_NbSociete()
        Try
            Dim nb = 1
reprendre:
            System.Threading.Thread.Sleep(2000)

            Dim nrw() As DataRow = LicTbl.Select("[Option]='Nb_Societes'")
            If (nrw.Length > 0) Then
                If nrw(0) Is Nothing Then GoTo reprendre
                If IsNumeric(nrw(0).Item("Droit")) Then
                        Droits.NbMaxSoc = ConvertEntier(nrw(0).Item("Droit"))
                        Droits.NbSocCree = 0
                    ElseIf nb < 10 Then
                        GoTo reprendre
                    Else
                        Droits.NbMaxSoc = 0
                        Droits.NbSocCree = 0
                    End If
                Else
                    Droits.NbMaxSoc = 0
                Droits.NbSocCree = 0
            End If

        Catch ex As Exception
            MsgBox("Licence : Nombre de societés: " & vbCrLf & ex.Message)
        End Try

        'Vérification des sociétés crées sur le serveur
        '  Dim TblSoc As DataTable = DATA_READER_GRD("Select  (Select count(*) from '+name+'.INFORMATION_SCHEMA.TABLES where Table_Name=''Param_Societe''),name from sys.databases where name not in ('master','tempdb','model','msdb')")
        ' Dim nb, nbSoc As Integer
        ' With TblSoc
        ' For i = 0 To .Rows.Count - 1
        ' nb = CnExecuting(.Rows(i).Item(0)).Fields(0).Value

        '        If nb > 0 Then
        ' Qry = " Select count(*) nb   from " & .Rows(i).Item(1) & ".dbo.Param_Societe"
        ' nbSoc = CnExecuting(Qry).Fields(0).Value
        '  Droits.NbSocCree = 5
        ' If .Rows(i).Item(1) = DB Then Droits.NbSocCreeBaseEncours = nbSoc
        ' nbSoc = 0
        ' End If
        ' Next
        ' End With

    End Sub
    Function Droit_TrancheEffectif() As Double
        Dim ca As Double = 0
        ca = CnExecuting("Select count(*) from RH_Agent where isnull(Droit_Paie,'false')='true'").Fields(0).Value
        Return ca
    End Function
End Module
