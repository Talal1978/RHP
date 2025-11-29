Imports System.Net.Mail
Public Class Login
    Public Structure connS
        Public connStr As String
        Public srv As String
        Public usr As String
        Public pwd As String
        Public db As String
    End Structure
    Friend connDic As New Dictionary(Of String, connS)
    Dim seSouvenir As Boolean = False
    Dim DatSeSouvenirMoi As Date = Now.Date
    Private Sub Log_In_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Enter Then login_lbl_Click(Nothing, Nothing)
    End Sub

    Sub InitialisationTblUser(loginStored As String, DirectAuthentification As Boolean)
        Tbl_User = DATA_READER_GRD("declare @lg nvarchar(50)
                                    set @lg='" & loginStored & "'
                                     select 'user' as Origine,-1 id_Societe,'' Matricule,id_User, ltrim(rtrim(isnull(Nom_User,'') + ' ' + isnull(Prenom_User,''))) as Nom,
 isnull(Cod_Entite,'') as Cod_Entite, isnull(Cod_Poste,'') as Cod_Poste,Login_User,
 isnull(Actif,'false') as User_Actif, Cod_Profile, isnull(p.Profile_Actif,'false') as Profile_Actif,isnull(Mail,'') as Mail,isnull(is_AD,'false') is_AD, 
 isnull(Pwd_User,'') Pwd_User,case when HashBytes('SHA1',upper(Login_User))=HashBytes('SHA1',upper(@lg)) and (isnull(is_AD,'false')='true' or '" & DirectAuthentification & "'='true' or Pwd_User='" & Encrypt(Pwd_txt.Text) & "') then 'true' else 'false' end as isTheUSer, isnull(Typ_Role,'Ops') as Typ_Role, Dat_Modif,convert(bit,'false') TeamLeader
 from Controle_Users u 
 outer apply (select Actif as Profile_Actif from Controle_Profile f where f.Cod_Profile=u.Cod_Profile) p
 where HashBytes('SHA1',upper(Login_User))=HashBytes('SHA1',upper(@lg))
 union all
 select top 1 'Agent' as Origine, id_Societe,Matricule, 0 as id_User, ltrim(rtrim(isnull(Nom_Agent,'') + ' ' + isnull(Prenom_Agent,''))) as Nom,isnull(Cod_Entite,'') as Cod_Entite, isnull(Cod_Poste,'') as Cod_Poste,Login,isnull(Droit_Paie,'false') as User_Actif, -1 as Cod_Profile, isnull(Droit_Paie,'false') as Profile_Actif ,  Mail,isnull(is_AD,'false') is_AD, 
isnull(PW,'') Pwd_User,
case when HashBytes('SHA1',upper(Login))=HashBytes('SHA1',upper(@lg)) and (isnull(is_AD,'false')='true' or '" & DirectAuthentification & "'='true' or PW='" & Encrypt(Pwd_txt.Text) & "') then 'true' else 'false' end as isTheUSer ,  'Agent' as Typ_Role, Dat_Modif,
convert(bit, case when estTeamLeader>0 then 'true' else 'false' end) as TeamLeader
from Rh_Agent a
outer apply (select count(*) as estTeamLeader from Sys_Org_Entite where Cod_Entite=isnull(a.Cod_Entite,'ui5465deu_è_è_çè') and Responsable=a.Matricule)o
where HashBytes('SHA1',upper(isnull(Login,'984iuiuhiuht65161')))=HashBytes('SHA1',upper(@lg) )")
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 0
        Dim fadeInTimer As New Timer()
        fadeInTimer.Interval = 50 ' Adjust as needed
        AddHandler fadeInTimer.Tick, Sub(senderO, eO)
                                         Me.Opacity += 0.05
                                         If Me.Opacity >= 1 Then
                                             fadeInTimer.Stop()
                                         End If
                                     End Sub
        fadeInTimer.Start()

        Version.Text = "Version : " & NumVersion
        Environment.GetCommandLineArgs(0) = NumVersion
        Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled

        '  If LegalVersion = False Then Me.Close()
        If Not IO.File.Exists(My.Application.Info.DirectoryPath & "\login\Login.ini") Then
            If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\login") Then IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\login")
            IO.File.Create(My.Application.Info.DirectoryPath & "\login\Login.ini").Close()
            Return
        End If
        Dim defaultInterfacePath As String = My.Application.Info.DirectoryPath & "\login\defaultInterface.dat"
        ' Vérifier que le fichier existe
        If IO.File.Exists(defaultInterfacePath) Then
            Dim defaultInterface As String = IO.File.ReadAllText(defaultInterfacePath)
            If defaultInterface.Trim = "BackOffice" Then
                Default_Interface_switch.Value = False
            Else
                Default_Interface_switch.Value = True
            End If
        End If
        Dim oDB As String = ""
        Dim SR As New IO.StreamReader(My.Application.Info.DirectoryPath & "\login\Login.ini")
        Do Until SR.Peek = -1
            Dim str As String = Decrypt(SR.ReadLine)
            Dim connStr As String = Split(Split(str, "@")(1), ":=")(1)
            connDic.Add(Split(Split(str, "@")(0), ":=")(1), New connS With {.connStr = connStr, .srv = Split(Split(connStr, ";")(1), "=")(1), .db = Split(Split(connStr, ";")(2), "=")(1), .usr = Split(Split(connStr, ";")(3), "=")(1), .pwd = Split(Split(connStr, ";")(4), "=")(1)})
            Connection_lb.Items.Add(Split(Split(str, "@")(0), ":=")(1))
        Loop
        SR.Close()
        'charger les éléments de RememberMe
        Dim storedData As rememberedData = LoadSecureRememberMe()
        '   MsgBox(storedData.Conn & " >> " & storedData.UserLogin & " >> " & storedData.creaDat)
        With Connection_lb
            .ForeColor = colorBase01
            .Size = New Size(.Width, 25 * If(.Items.Count = 0, 1, .Items.Count))
            If storedData.Conn.Trim <> "" Then
                Connection_lbl.Text = storedData.Conn.Trim
                If storedData.UserLogin.Trim <> "" Then
                    Login_txt.Text = storedData.UserLogin.Trim
                    DatSeSouvenirMoi = storedData.creaDat
                    Default_Interface_switch.Value = CBool(storedData.Default_Interface)
                    Entrer(storedData.UserLogin.Trim, True)
                End If
            End If
        End With
        With pb_chk
            seSouvenir = (storedData.UserLogin.Trim <> "" And CBool(storedData.Default_Interface) = Default_Interface_switch.Value)
            .Image = IIf(seSouvenir, My.Resources.chk_on, My.Resources.chk_off)
        End With

    End Sub
    Private Sub Close_D_Click(sender As Object, e As EventArgs) Handles Close_D.Click
        Environment.Exit(0)
        Me.Close()
    End Sub

    Private Sub login_lbl_Click(sender As Object, e As EventArgs) Handles login_lbl.Click
        Entrer(Login_txt.Text.Trim, False)
    End Sub

    Private Sub login_lbl_MouseEnter(sender As Object, e As EventArgs) Handles login_lbl.MouseEnter, pn_log.MouseEnter
        With login_lbl
            '   .BackColor = Color.Transparent
            .ForeColor = Color.White
        End With
        pn_log.BackColor = colorBase01
    End Sub

    Private Sub login_Lbl_MouseLeave(sender As Object, e As EventArgs) Handles login_lbl.MouseLeave, pn_log.MouseLeave
        With login_lbl
            '   .BackColor = colorBase01
            .ForeColor = colorBase01
        End With
        pn_log.BackColor = Color.Transparent
    End Sub
    Sub toggleSeSouvenirDeMoi()
        With pb_chk
            .Image = IIf(seSouvenir, My.Resources.chk_off, My.Resources.chk_on)
            seSouvenir = Not seSouvenir
        End With
    End Sub
    Private Sub pb_chk_Click(sender As Object, e As EventArgs) Handles pb_chk.Click
        toggleSeSouvenirDeMoi()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        toggleSeSouvenirDeMoi()
    End Sub

    Sub Entrer(loginStored As String, storedAuthentification As Boolean)
        If loginStored = "" Then Exit Sub
        If connDic.ContainsKey(Connection_lbl.Text) Then connectionString = connDic(Connection_lbl.Text).connStr
        Dim rs41 As New ADODB.Recordset
        '  Try
        If cn.State Then
            cn.Close()
        End If
        If cn1.State Then
            cn1.Close()
        End If
        cn.CommandTimeout = 0
        cn.ConnectionTimeout = 0
        cn.ConnectionString = connectionString
        cn.Open()
        cn1.ConnectionString = connectionString
        cn1.Open()

        'Vérification des dates
        If Now.ToShortDateString <> CDate(CnExecuting("select getdate()").Fields(0).Value).ToShortDateString Then
            ShowMessageBox("Date système différente de la date de votre serveur", "Vérification des dates", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        '' Stocker la Connection Sql (UID) et le Pw (PWD)
        Dim Str As String = connectionString

        ConnectionSQL = Split(Split(Str, ";")(3), "=")(1)
        PWDConnectionSQL = Split(Split(Str, ";")(4), "=")(1)
        DB = Split(Split(Str, ";")(2), "=")(1)
        Serveur = Split(Split(Str, ";")(1), "=")(1)
        theUser.Login = loginStored.Trim.Replace("'", "''").ToUpper
        ' ==================== NOUVELLE LOGIQUE D'AUTHENTIFICATION ====================
        Dim isAuthenticatedAD As Boolean = False
        Dim adUserInfo As ADUserInfo
        Dim Pwd_User As String = ""
        InitialisationTblUser(loginStored, storedAuthentification)
        Usr = Tbl_User.Select($"isTheUSer ='true' and Origine='{If(Default_Interface_switch.Value, "Agent", "user")}'")
        If Usr.Length > 0 Then
            theUser.Cod_Profile = Usr(0)("Cod_Profile")
            theUser.id_User = Usr(0)("id_User")
            theUser.Cod_Entite = Usr(0)("Cod_Entite")
            theUser.Cod_Poste = Usr(0)("Cod_Poste")
            theUser.Nom = Usr(0)("Nom").ToString()
            theUser.Typ_Role = Usr(0)("Typ_Role").ToString()
            theUser.Mail = Usr(0)("Mail").ToString()
            theUser.id_Societe = Usr(0)("id_Societe")
            theUser.Matricule = Usr(0)("Matricule")
            theUser.Login = Usr(0)("Login_User")
            theUser.TeamLeader = Usr(0)("TeamLeader")
            theUser.is_AD = CBool(IsNull(Usr(0)("is_AD"), False))
            theUser.Pwd_User = Usr(0)("Pwd_User")
            Pwd_User = Usr(0)("Pwd_User").ToString()
            'Controle de modification de fiche agent ultérieures
            If (storedAuthentification) Then
                If (DatSeSouvenirMoi <= CDate(Usr(0)("Dat_Modif"))) Then
                    seSouvenir = True
                    pb_chk.Image = My.Resources.btn_check_on
                    ClearSecureRememberMe()
                    Return
                End If
                If theUser.is_AD Then
                    isAuthenticatedAD = AuthenticateWithActiveDirectory(loginStored, Decrypt(Pwd_User))
                    If Not isAuthenticatedAD Then
                        ShowMessageBox("Echec d'authentification par l'Active Directory. Contactez votre administrateur.", "Authentification")
                        Exit Sub
                    End If
                End If
            End If
            If Usr(0)("User_Actif") = False Then
                MessageBoxRHP(514)
                Exit Sub
            End If
            If Usr(0)("Profile_Actif") = False Then
                MessageBoxRHP(515)
                Exit Sub
            End If

        Else
            ShowMessageBox("Les éléments d'authentification ne correspondent à aucun compte.", "Authentification")
            Dim usrNot = Tbl_User.Select($"Login_User='{Login_txt.Text}' and Origine='{If(Default_Interface_switch.Value, "Agent", "user")}' and isnull(is_AD,'false')='false' ")
            pwdForgotten.Visible = (usrNot.Length > 0)
            Exit Sub
        End If

        ' 1. Essayer l'authentification Active Directory d'abord (sauf pour les emails)
        If Not storedAuthentification Then
            If theUser.is_AD Then
                isAuthenticatedAD = AuthenticateWithActiveDirectory(loginStored, Pwd_txt.Text)
                If Not isAuthenticatedAD Then
                    ShowMessageBox("Echec d'authentification par l'Active Directory. Contactez votre administrateur.", "Authentification")
                    Exit Sub
                End If
                adUserInfo = GetADUserInfo(Login_txt.Text)
                If Not adUserInfo.Enabled Then
                    ShowMessageBox("Votre compte Active Directory est désactivé.", "Authentification", MessageBoxButtons.OK, msgIcon.Error)
                    Return
                End If
                If Tbl_User.Select($"Login_User='{Login_txt.Text}'").Length = 0 Then
                    ShowMessageBox("Authentification Active Directory réussie, mais votre compte n'est pas configuré dans l'application." & vbCrLf & "Veuillez contacter votre administrateur.", "Accès refusé", MessageBoxButtons.OK, msgIcon.Warning)
                    Return
                End If
                If Encrypt(Pwd_txt.Text) <> theUser.Pwd_User Then
                    If theUser.Typ_Role = "Agent" Then
                        CnExecuting($"update Rh_Agent set PW='{Encrypt(Pwd_txt.Text)}' where Login='{loginStored}' ")
                    Else
                        CnExecuting($"update Controle_Users set Pwd_User='{Encrypt(Pwd_txt.Text)}' where Login_User='{loginStored}'")
                    End If
                End If

            ElseIf Tbl_User.Select($"Login_User='{Login_txt.Text}' and Pwd_User='{Encrypt(Pwd_txt.Text)}'").Length = 0 Then
                ShowMessageBox("Echec d'authentification, Login ou mot de passe erronés." & vbCrLf & "Veuillez contacter votre administrateur.", "Accès refusé", MessageBoxButtons.OK, msgIcon.Warning)
                pwdForgotten.Visible = True
                Return
            End If
        End If

        Dim DatNow As Date = Now
        If DateDiff(DateInterval.Minute, DatNow, CnExecuting("select getdate()").Fields(0).Value) > 2 Then
            ShowMessageBox("la date et l'heure sur votre ordinateur sont différentes de celles du serveur", "Date Heure", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        If cn.Execute("Select count(*) from Controle_Traitement where Termine='N'").Fields(0).Value > 0 Then
            MessageBoxRHP(518)
            Me.Close()
        End If
        Dim VersionSrv As Integer = CInt(FindParam("Version").Replace(".", ""))
        If CInt(NumVersion.Replace(".", "")) <> VersionSrv Then
            ShowMessageBox("La version installée sur votre serveur est différente de votre version." & vbCrLf & "Veuillez contactez votre administrateur.")
            Return
        End If
        InitialisationGlobale()
        If oKle.Trim <> "" Then
            '2.Test Nombre de Licence Connectée en même temps
            If CnExecuting("select count(distinct hostprocess)  from sys.sysprocesses where rtrim(program_name)='RHP'").Fields(0).Value > CDbl(Droits.NbUsers) Then
                MessageBoxRHP(509, Droits.NbUsers)
                Exit Sub
            End If
            '2.Test Nombre des utilisateurs
            If theUser.Typ_Role <> "Agent" Then
                If Tbl_User.Select("User_Actif='True'").Length > Droits.NbUsers Then
                    MessageBoxRHP(364, Droits.NbUsers)
                    Exit Sub
                End If
            End If
            If DatNow <= Droits.DatDebContrat Then
                MessageBoxRHP(510)
                Exit Sub
            End If
            'Test Date fin:
            If DatNow >= Droits.DatFinContrat Then
                With Zoom_Licencing
                    .ShowDialog()
                End With
                Exit Sub
            End If

        Else
            Zoom_Licencing.ShowDialog()
            If oKle.Trim = "" Then
                Exit Sub
            End If
        End If
        CodDeviseLocal = CnExecuting("select isnull((select Top 1 Cod_Dev from Compta_Devise where isnull(Dev_Ref,'false')='true'),'')").Fields(0).Value
        rs41.Open("select * from Controle_Users_Process", cn, 2, 2)
        rs41.AddNew()
        rs41("Login_User").Value = theUser.Login
        rs41("Interface").Value = If(Default_Interface_switch.Value, "Portail", "BackOffice")
        rs41("Nom_User").Value = theUser.Nom
        rs41("hostname").Value = My.Computer.Name
        rs41("Process_Id").Value = System.Diagnostics.Process.GetCurrentProcess().Id
        rs41("Dat").Value = Now
        rs41("isConnected").Value = True
        rs41.Update()
        rs41.Close()
        ' Pour les utilisateurs authentifiés par AD, ne pas forcer le changement de mot de passe "azer"
        If Not isAuthenticatedAD AndAlso Pwd_txt.Text = "azer" Then
            ShowMessageBox("Vous devez modifier votre mot de passe.", "Contrôle de Mot de passe", MessageBoxButtons.OK, msgIcon.Warning)
            Dim f As New Admin_ChangePwd
            f.Old_Pwd_User_Text.Text = Pwd_txt.Text
            f.Pwd1_Text.Select()
            f.ShowDialog()
        End If
        CnExecuting("delete from Controle_Access where Process_Id not in (select hostprocess from sys.sysprocesses where isnumeric(hostprocess)=1)")
        If seSouvenir Then
            SaveSecureRememberMe(Login_txt.Text, Connection_lbl.Text, Default_Interface_switch.Value)
        End If

        If theUser.Typ_Role = "Agent" Then
            ChargerSociete("id_Societe = " & theUser.id_Societe)
            OuvrirSociete(theUser.id_Societe, False)

            Dim oRw() As DataRow = Tbl_Org_Entite.Select("Cod_Entite='" & theUser.Cod_Entite & "'")
            If oRw.Length > 0 Then
                theUser.RacineHierarchique = oRw(0)("Racine")
            Else
                theUser.RacineHierarchique = ""
            End If
            filtreUser = If(theUser.TeamLeader, "exists(
 select * from Sys_Org_Entite s where 
 ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif('" & theUser.Cod_Entite & "',''),'8787uhuhunjj')+';%' and id_Societe=" & Societe.id_Societe & " and {0}.Cod_Entite=s.Cod_Entite)", "{0}.Matricule=" & theUser.Matricule)
            filtreEntite = "exists(
 select * from Sys_Org_Entite s where 
 ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif('" & theUser.Cod_Entite & "',''),'8787uhuhunjj')+';%' and id_Societe=" & Societe.id_Societe & " and Org_Entite.Cod_Entite=s.Cod_Entite)"
            With Menu_Agent
                .AutoScaleMode = AutoScaleMode.Dpi
                .Icon = My.Resources.rhp
                .Text = "Rh-P \ " & Connection_lbl.Text
                Me.TopLevel = False
                Me.TopMost = False
                Me.Parent = Menu_Agent
                Me.Visible = False
                Me.Hide()
                .Show()
            End With
        Else
            theUser.Matricule = ""
            With Wait
                .AutoScaleMode = AutoScaleMode.Dpi
                .StartPosition = FormStartPosition.CenterScreen
                .WindowState = FormWindowState.Maximized
                Me.Owner = Wait
                .lg = Me
                .Show()
            End With

        End If

        Dim diffdate As Integer = DateDiff(DateInterval.Day, DatNow, Droits.DatFinContrat)
        If diffdate <= 30 Then
            MessageBoxRHP(516, 30)
        End If
        Exit Sub
    End Sub

    Private Sub pwdForgotten_Click(sender As Object, e As EventArgs) Handles pwdForgotten.Click
        If Not MajSmtp() Then Return
        If Login_txt.Text.Trim = "" Then
            ShowMessageBox("Veuillez renseigner votre login", "Mot de passe oublié", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Connection_lbl.Text.Trim = "" Then
            ShowMessageBox("Veuillez sélectionner une base", "Mot de passe oublié", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If cn.State Then
            cn.Close()
        End If
        cn.CommandTimeout = 0
        cn.ConnectionTimeout = 0
        cn.ConnectionString = connectionString
        cn.Open()
        Dim usrNot = Tbl_User.Select($"Login_User='{Login_txt.Text}' and Origine='{If(Default_Interface_switch.Value, "Agent", "user")}' and isnull(is_AD,'false')='false' ")
        If usrNot.Length = 0 Then
            ShowMessageBox("Aucun compte mail associé à ce compte", "Mot de passe oublié")
            Return
        End If
        Dim emailUser As String = usrNot(0)("Mail")

        Try
            If Not estEmail(emailUser) Then
                ShowMessageBox("Aucun mail valide n'est associé à ce compte. Contactez votre administrateur.", "Mot de passe oublié", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            Dim Messagerie As DataTable = DATA_READER_GRD("select * from Controle_Messagerie")
            If Messagerie.Rows.Count > 0 Then
                oMail.From = New MailAddress(Messagerie.Rows(0).Item("Mail_From"), "Admin-RHP", System.Text.Encoding.UTF8)
                oSmtpServer.Credentials = New Net.NetworkCredential(Messagerie.Rows(0).Item("Mail_Addr"), Decrypt(Messagerie.Rows(0).Item("Pwd_Mail")))
                oSmtpServer.Port = Messagerie.Rows(0).Item("Port_Mail")
                oSmtpServer.Host = Messagerie.Rows(0).Item("Smtp_Mail")
                oSmtpServer.EnableSsl = Messagerie.Rows(0).Item("Ssl_Actif")

                Dim rnd As New Random
                Dim AryL As New ArrayList()
                Dim psw As String = ""
                AryL.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"})
                For i = 0 To 10
                    psw &= AryL(rnd.Next(0, AryL.Count - 1))
                Next
                Dim pt_mail As String = ""
                If emailUser.IndexOf("@") > 4 Then
                    pt_mail = Gauche(emailUser, 1) & "......" & Droite(emailUser, emailUser.Length - emailUser.IndexOf("@"))
                End If
                If EnvoiDeMail(emailUser, emailUser, "Génération de mot de passe", "Bonjour" & vbCrLf & "Voici votre nouveau mot de passe : " & psw).envoye Then
                    ShowMessageBox("Votre nouveau mot de passe vous a été envoyé à votre adresse mail : " & pt_mail, "Changement de mot de passe", MessageBoxButtons.OK, msgIcon.Information)
                    If usrNot(0)("Origine") = "Agent" Then
                        CnExecuting("update Rh_Agent set PW='" & Encrypt(psw) & "', Dat_Modif=getdate() where isnull(Login,'')='" & theUser.Login & "'")
                    Else
                        CnExecuting("update Controle_Users set Pwd_User='" & Encrypt(psw) & "', Dat_Modif=getdate() where Login_User='" & theUser.Login & "'")
                    End If

                Else
                    ShowMessageBox("Erreur de mail :" & vbCrLf &
                                      pt_mail _
                                      & vbCrLf, "Changement de mot de passe", MessageBoxButtons.OK, msgIcon.Error)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pb_cbo_Click(sender As Object, e As EventArgs) Handles pb_cbo.Click, Connection_lbl.Click
        Connection_lb.Visible = Not Connection_lb.Visible
        If Connection_lb.Visible Then
            Connection_lb.BringToFront()
        End If
    End Sub

    Private Sub Connection_lb_Click(sender As Object, e As EventArgs) Handles Connection_lb.Click
        If Connection_lb.SelectedItems.Count > 0 Then
            Connection_lbl.Text = Connection_lb.SelectedItem
            Connection_lb.Visible = False
        End If
    End Sub

    Private Sub NewConnection_D_Click(sender As Object, e As EventArgs) Handles NewConnection_D.Click
        Dim f As New Login_Connection
        With f
            .frmLogin = Me
            .Conn_txt.Text = Connection_lbl.Text
            .ShowDialog()
        End With
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Enter
                Entrer(Login_txt.Text, False)
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Default_Interface_switch_Click(sender As Object, e As EventArgs) Handles Default_Interface_switch.Click
        Dim defaultInterfacePath As String = My.Application.Info.DirectoryPath & "\login\defaultInterface.dat"
        Dim itsOk As Boolean = False
        If IO.File.Exists(defaultInterfacePath) Then
            Try
                IO.File.Delete(defaultInterfacePath)
                itsOk = True
            Catch ex As Exception

            End Try
        Else
            itsOk = True
        End If
        If itsOk Then
            Dim sw As New IO.StreamWriter(defaultInterfacePath, True)
            sw.Write(If(Default_Interface_switch.Value, "BackOffice", "Portail"))
            sw.Close()
        End If

    End Sub
End Class