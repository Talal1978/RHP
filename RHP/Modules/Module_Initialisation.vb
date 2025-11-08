Imports System.Net.Mail
Module Module_Initialisation
    Public oMail As New MailMessage()
    Public oSmtpServer As New SmtpClient()
    Public LicTbl As New DataTable
    Sub InitialisationGlobale()
        Dim CodSql As String = ""
        'Chargement des Parametres Généraux
        Dim oVisible As String = IIf(theUser.Cod_Profile = 1 Or theUser.Typ_Role = "Agent", "'True'", "o.Visible")
        Dim oActif As String = IIf(theUser.Cod_Profile = 1 Or theUser.Typ_Role = "Agent", "'True'", "o.Actif")
        Dim mVisible As String = IIf(theUser.Cod_Profile = 1 Or theUser.Typ_Role = "Agent", "'True'", "m.Visible")
        Dim mActif As String = IIf(theUser.Cod_Profile = 1 Or theUser.Typ_Role = "Agent", "'True'", "m.Actif")

        Dim nbj As Object = FindParam("NbLigneListeTDB")
        If IsNumeric(nbj) Then
            NbLigneReportQuery = CInt(nbj)
        Else
            NbLigneReportQuery = 50
        End If

        CnExecuting("update Param_Abonnement set Statut=0 where Process_Id not in (select hostprocess from sys.sysprocesses)")
        Tbl_Controle_Profile_Regles = DATA_READER_GRD("select * from Controle_Profile_Regles 
                                                        where Cod_Profile=" & theUser.Cod_Profile & " and ltrim(rtrim(isnull(Table_Ref,'')))<>'' and ltrim(rtrim(isnull(Regle,'')))!=''
                                                        and Table_Ref in (select name from sys.sysobjects)")
        ' Chargement de Tables Globales
        Tbl_Controle_Def_Label = DATA_READER_GRD("select * from Controle_Def_Label where isnull(Alias_Label,'')<>''")
        Tbl_Controle_Def_Ecran = DATA_READER_GRD("select convert(bit,ContientSociete) as ContientSociete,Name_Ecran, Index_Ecran, Table_Ref, Index_Table, 
Num_Zoom, Description, Condition , isnull(Modal,'false') as Modal,isnull(PJ,'false') as PJ, isnull(Info,'false') as Info
from Controle_Def_Ecran d
outer apply (select count(name) as ContientSociete from sys.columns where object_name(object_id)=d.Table_Ref and name='id_Societe' )s")
        Tbl_Controle_Def_Ecran_Button = DATA_READER_GRD("select * from Controle_Def_Ecran_Button")
        CodSql = "select f.Typ_Ecran,f.Name_Ecran,f.Text_Ecran,Image1,Image2,f.Parent,convert(int,isnull(f.Rang,0)) as Rang,isnull(" & oVisible & ",'False') as Visible,isnull(" & oActif & ",'False') as Actif, isnull(v.Menu_Parent,'') as Menu_Parent  
                 from Controle_TreeView f inner join Controle_Menu v on f.Name_Ecran=v.Name_Ecran 
                outer apply 
                (select Actif,Visible from Controle_Droit where Cod_Profile='" & theUser.Cod_Profile & "' and Name_Ecran=f.Name_Ecran) o 
                 where isnull(" & oVisible & ",'False')='True' order by Rang Asc"
        Tbl_Controle_Droit_Mnu = DATA_READER_GRD(CodSql)
        Tbl_Controle_Def_Zoom = DATA_READER_GRD("select * from Controle_Def_Zoom")

        CodSql = "select f.Name_Ecran,v.Name_Controle, isnull(Typ_Security,'') as Typ_Security,Text_Controle,Typ_Controle,isnull(" & mVisible & ",'False') As Visible,isnull(" & mActif & ",'False') As Actif 
                               from Controle_Menu f left join Controle_Menu_Avance v  
                              On f.Name_Ecran=v.Name_Ecran  
                               outer apply  
                              (Select cast(case when isnull(d.Visible,'false')='false' then 'false' else  isnull(a.Visible,'false') end  as bit) Visible,cast(case when isnull(d.Actif,'false')='false' then 'false' else  isnull(a.Actif,'false') end  as bit) Actif from Controle_Droit d left join Controle_Droit_Avance a on d.Name_Ecran =a.Name_Ecran and d.Cod_Profile=a.Cod_Profile   where d.Name_Ecran=f.Name_Ecran And d.Cod_Profile='" & theUser.Cod_Profile & "' and Name_Controle=v.Name_Controle) m 
                              where Typ_Ecran In ('ECR','RPT','QRY','SUB') and isnull(v.Name_Controle,'')<>''"
        TblAccess = DATA_READER_GRD(CodSql)

        Tbl_Controle_TreeView = DATA_READER_GRD("with Tbl (Name_Ecran, Text_Ecran, Typ_Ecran,Parent, Racine, Niveau)
as
(select Name_Ecran, Text_Ecran, Typ_Ecran,isnull(Parent,'') as Parent, convert(varchar(max),Name_Ecran) Racine,1 Niveau 
	from Controle_TreeView where isnull(Parent,'')='' and Typ_Ecran='MNU'
	union all
select v.Name_Ecran, v.Text_Ecran, v.Typ_Ecran,isnull(v.Parent,''),convert(varchar(max),Racine + ';'+v.Name_Ecran) Racine,Tbl.Niveau+1 as Niveau 
	from Controle_TreeView v inner join Tbl on isnull(v.Parent,'')=Tbl.Name_Ecran
	)
select * from Tbl")

        CodSql = "select * from Controle_Def_InformationsComplementaires"
        Tbl_Controle_Def_InformationsComplementaires = DATA_READER_GRD(CodSql)

        CodSql = "select * from RH_Agent_Donnees_Diverses_Parametrage"
        Tbl_RH_Agent_Donnees_Diverses_Parametrage = DATA_READER_GRD(CodSql)
        ActiverAbonnement = FindParam("Activer_Abonnement")
        ActiveTimer = FindParam("ActiveTimer")

        TablesAvecIdSoc = CnExecuting("select isnull((select string_agg( lower(object_name(object_id)),';') as Table_Name from sys.columns where name = 'id_Societe' and object_name(object_id)<>'Param_Societe'),'')").Fields(0).Value.ToString.Split(";").ToList()

        Tbl_Function_Security = DATA_READER_GRD(" select Function_Sec,isnull(Description,'') as Lib_Function, ';'+isnull(Ecrans,'')+';' as Ecrans  ,isnull(Visible,'false') Visible,isnull(Actif,'false') Actif
from Controle_Menu_Functions f 
outer apply (Select top 1 Visible, Actif  from Controle_Droit_Functions 
where f.Function_Sec=Function_Sec And Cod_Profile='" & theUser.Cod_Profile & "') d 
where isnull(Function_Sec,'')<>''
order by isnull(Description,'')")


        'Building sql_Sys_RH_Agent_AG
        Building_Sys_RH_Agent_AG()

        'workflow
        InitialisationWorfRulesSignature()

        ' Détermination du nombre de décimal
        If CStr(FindParam("NbDecimalCtb")) <> "" Then
            NbDecimalCtb = FindParam("NbDecimalCtb")
        Else
            NbDecimalCtb = 2
        End If

        If FindParam("Cod_Langue") <> "" Then
            CodLangue = FindParam("Cod_Langue")
        Else
            CodLangue = "FRA"
        End If
        If theUser.Typ_Role <> "Agent" Then
            oFiltreSociete = " where (isnull(Droits,'*') ='*' or  isnull(Droits,'') = '" & Usr(0)("Login_User") & "' or   isnull(Droits,'') like '" & Usr(0)("Login_User") & ";%' or isnull(Droits,'') like '%;" & Usr(0)("Login_User") & "' 
 or isnull(Droits,'') like '%;" & Usr(0)("Login_User") & ";%' or '" & Usr(0)("Login_User").ToString.Trim.ToUpper & "'='ADMIN')"
        End If

        cn.Close()
        cn.ConnectionTimeout = 0
        cn.Open()
        'Lecteur Disk
        nr.lpRemoteName = FindLibelle("Srv_Path", "Lecteur", DriveLetter, "Controle_Config")
        nr.lpLocalName = Nothing
        strUsername = FindLibelle("strUsername", "Lecteur", DriveLetter, "Controle_Config")

        strPassword = Decrypt(FindLibelle("strPassword", "Lecteur", DriveLetter, "Controle_Config"))
        nr.dwType = RESOURCETYPE_DISK
        Dim idSo As Integer = CnExecuting("select isnull((select top 1 id_Societe from Param_Societe order by Prioritie desc),-1)").Fields(0).Value
        If idSo >= 0 Then
            '       Accueil_Detail.OuvrirSociete(idSo, True)
        End If
        If LicTbl.Columns.Count = 0 Then
            'Verification de la licence et de la version
            LicTbl.Columns.Add("Option")
            LicTbl.Columns.Add("Droit")
            LicTbl.Columns.Add("Libelle")
            LicTbl.Columns.Add("Data")
        End If
        LicTbl.Rows.Clear()
        LicTbl.Rows.Add("EstAuthentic", "0", "Version authentique", "Bool")
        LicTbl.Rows.Add("Dat_Deb_Contrat", "01/01/1900", "Début de maintenance", "Date")
        LicTbl.Rows.Add("Dat_Fin_Contrat", "01/01/2900", "Fin de maintenance", "Date")
        LicTbl.Rows.Add("Nb_Societes", "0", "Nombre de sociétés autorisées", "Int")
        LicTbl.Rows.Add("Nb_Users", "0", "Nombre d'utilisateurs", "Int")
        LicTbl.Rows.Add("Tranche_Effectif", "0", "Tranche des effectifs", "Int")
        LicTbl.Rows.Add("DamanCom", "0", "DamanCom", "Bool")
        LicTbl.Rows.Add("IR_9421", "0", "Simpl-IR", "Bool")
        LicTbl.Rows.Add("GED", "0", "Gestion électronique des documents (GED)", "Bool")
        LicTbl.Rows.Add("ORG", "0", "Organisation", "Bool")
        LicTbl.Rows.Add("ANA", "0", "Analytique", "Bool")
        LicTbl.Rows.Add("WEB", "0", "Version web", "Bool")
        oKle = CnExecuting("select isnull((select top 1 Licence from Controle_Certificat),'')").Fields(0).Value
        VerificationLicenceEtVersion()

        check_rhp_functions_system()
        MajSmtp()
        ChargerChartType()
        Droit_NbSociete()
        getLocalParams()
    End Sub
    Public Structure LocalParams
        Public recents As String
        Public frequents As String
        Public currentIdSoc As Integer
    End Structure
    Public _localParams As New LocalParams
    Sub Building_Sys_RH_Agent_AG()
        sql_Sys_RH_Agent_AG = CnExecuting("select isnull((select dbo.Sys_Rh_Agent_Generate_AG(" & Societe.id_Societe & ")),'')").Fields(0).Value
    End Sub
    Sub getLocalParams()
        Dim _jtoken As Newtonsoft.Json.Linq.JToken = Nothing
        If Not IO.File.Exists(jsonFilePath) Then
            Using fs = IO.File.Create(jsonFilePath)
            End Using
        End If


        If IO.File.Exists(jsonFilePath) Then
            Dim jsonData As String = IO.File.ReadAllText(jsonFilePath)
            If String.IsNullOrEmpty(jsonData) Then
                jsonData = "{
  """ & theUser.Login & """: {
    ""recents"": """",""frequents"": """",""currentIdSoc"":-1,
  }
}"
            End If
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonData)
            If jsonObject.TryGetValue(theUser.Login, _jtoken) Then
                With _localParams
                    .recents = IsNull(_jtoken.Value(Of String)("recents"), "")
                    .frequents = IsNull(_jtoken.Value(Of String)("frequents"), "")
                    .currentIdSoc = IsNull(_jtoken.Value(Of String)("currentIdSoc"), -1)
                End With
            End If
        End If
    End Sub
    Function MajSmtp() As Boolean
        Try
            Dim Messagerie As DataTable = DATA_READER_GRD("select * from Controle_Messagerie")
            If Messagerie.Rows.Count > 0 Then
                oMail.From = New MailAddress(Messagerie.Rows(0).Item("Mail_From"), GlobalVar("GV_USERNAME"), System.Text.Encoding.UTF8)
                oSmtpServer.Credentials = New Net.NetworkCredential(Messagerie.Rows(0).Item("Mail_Addr"), Decrypt(Messagerie.Rows(0).Item("Pwd_Mail")))
                oSmtpServer.Port = Messagerie.Rows(0).Item("Port_Mail")
                oSmtpServer.Host = Messagerie.Rows(0).Item("Smtp_Mail")
                oSmtpServer.EnableSsl = Messagerie.Rows(0).Item("Ssl_Actif")
                Return True
            End If
            Return False
        Catch ex As Exception
            ShowMessageBox(ex.Message)
            Return False
        End Try
        'Paramètres de messagerie

    End Function
    Sub ChargerChartType()
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Column)
        Chart_NbSeries.Add(999)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Area)
        Chart_NbSeries.Add(999)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Bar)
        Chart_NbSeries.Add(999)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Doughnut)
        Chart_NbSeries.Add(1)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Funnel)
        Chart_NbSeries.Add(1)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Line)
        Chart_NbSeries.Add(999)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Pie)
        Chart_NbSeries.Add(1)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Point)
        Chart_NbSeries.Add(999)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Pyramid)
        Chart_NbSeries.Add(1)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Radar)
        Chart_NbSeries.Add(1)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.Spline)
        Chart_NbSeries.Add(999)
        Chart_Type.Add(DataVisualization.Charting.SeriesChartType.StackedBar)
        Chart_NbSeries.Add(999)
    End Sub
End Module
