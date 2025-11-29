Imports System.IO
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports iTextSharp.text.pdf
Module Module_Mailing
    Dim ODBCRHP As String = FindParam("ODBC_RHP")
    Dim path As String = FindParam("Lecteur_Digital_Upload")
    Dim pathImpression As String = FindParam("Lecteur_Digital_Mod_Edition")
    Public Sub CompagneMailing(ByVal CodMailing As String, Optional dicParametres As Dictionary(Of String, Object) = Nothing, Optional listSentMail As List(Of String) = Nothing)
        '   Try
        Dim cnLocal As New ADODB.Connection
        cnLocal.Open(connectionString) ' ta chaîne de connexion
        cnLocal.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cnLocal.Execute("delete from Mailing_Rapport where  Cod_Mailing='" & CodMailing & "'")
        Dim rs, rsq, rsqc, rsml, rstr As New ADODB.Recordset
        Dim SqlQuery As String = ""
        Dim HeaderStr As String = ""
        Dim FooterStr As String = ""
        Dim Sujet As String = ""
        Dim QueryHTML As String = ""
        Dim CodSqlTmp As String = ""
        Dim HeaderStrTmp As String = ""
        Dim FooterStrTmp As String = ""
        Dim SujetTmp As String = ""
        Dim HeaderVisible As Boolean = False
        Dim EntTableHTML As String = ""
        Dim Num As String = "0"
        Dim CodQuery As String = ""
        Dim crReport As String = ""
        Dim crParam, crValeur, crValeurTmp, crAttach, PJattach As New ArrayList
        Dim FichierPJ As String = ""
        Dim crPDFPath As String = path & "\PDF\" & CodMailing
        Dim rnd As New Random
        If Not IO.Directory.Exists(crPDFPath) Then IO.Directory.CreateDirectory(crPDFPath)
        rs.Open("select * from Mailing where Cod_Mailing='" & CodMailing & "'", cnLocal, 3, 3)
        If Not rs.EOF Then
            HeaderStr = IsNull(rs("Header_Mail").Value, "")
            FooterStr = IsNull(rs("Footer_Mail").Value, "")
            Sujet = IsNull(rs("Sujet_Mail").Value, "")
            CodQuery = IsNull(rs("Cod_Query").Value, "")
            crReport = IsNull(rs("Cod_Report").Value, "")
            Dim Report_with_Pw = CBool(IsNull(rs("Report_with_Pw").Value, False))
            Dim sql_Destinataires_rendred = IsNull(rs("sql_Destinataires_rendred").Value, "")
            'Charger les attachements
            Dim TblPJ As DataTable = DATA_READER_GRD("select Nom_Fichier,isnull(Extension,'') as Extension from Mailing_PJ where Cod_Mailing='" & CodMailing & "' order by Rang")
            With TblPJ
                For i = 0 To .Rows.Count - 1
                    FichierPJ = IsNull(.Rows(i)("Nom_Fichier") & .Rows(i)("Extension"), "")
                    If FichierPJ <> "" Then
                        FichierPJ = path & "\" & FichierPJ
                        If IO.File.Exists(FichierPJ) Then
                            PJattach.Add(FichierPJ)
                        End If
                    End If
                Next
            End With
            'Préparer les paramètre de Crystal Report
            crParam.Clear()
            crValeur.Clear()
            crValeurTmp.Clear()
            crAttach.Clear()
            If crReport.Trim <> "" Then
                TblPJ = GenererReport(CodMailing, crReport)
                With TblPJ
                    For i = 0 To .Rows.Count - 1
                        crParam.Add(.Rows(i)("Critere"))
                        crValeur.Add(.Rows(i)("Default_Value"))
                    Next
                End With
            End If
            'La compagne Mailing contient une requête
            If CodQuery.Trim <> "" Then
                HeaderVisible = IsNull(FindLibelle("HeaderVisible", "Cod_Query", rs("Cod_Query").Value, "Param_Query"), False)
                SqlQuery = GenererQuery(CodMailing, CodQuery)
            Else
                SqlQuery = ""
                HeaderVisible = False
            End If
            'Remplacer les paramètres du mailing par leur valeurs
            If dicParametres IsNot Nothing Then
                For Each c In dicParametres
                    Sujet = Sujet.Replace("@@@" & c.Key, IsNull(c.Value, ""))
                    HeaderStr = HeaderStr.Replace("@@@" & c.Key, IsNull(c.Value, ""))
                    FooterStr = FooterStr.Replace("@@@" & c.Key, IsNull(c.Value, ""))
                    sql_Destinataires_rendred = sql_Destinataires_rendred.Replace("@@@" & c.Key, IsNull(c.Value, ""))
                    If SqlQuery <> "" Then SqlQuery = SqlQuery.Replace("@@@" & c.Key, IsNull(c.Value, ""))
                    If crReport.Trim <> "" Then
                        For n = 0 To crValeur.Count - 1
                            crValeur(n) = crValeur(n).ToString.Replace("@@@" & c.Key, IsNull(c.Value, ""))
                        Next
                    End If
                Next
            End If

            'Remplacer les données des destinataires
            If sql_Destinataires_rendred.Trim = "" Then
                '1- Si Les destinataires proviennent d'une liste de destinataires:
                rsml.Open(GenererMailingList(rs("Mailing_List").Value), cnLocal, 3, 3)
            Else
                '2- Les destinataires proviennent d'une requette sql sql_Destinataires
                rsml.Open(sql_Destinataires_rendred, cnLocal, 3, 3)
            End If
            Dim k = 0
            Dim nb = rsml.RecordCount
            While Not rsml.EOF
                k += 1
                SujetTmp = Sujet
                HeaderStrTmp = HeaderStr
                FooterStrTmp = FooterStr
                CodSqlTmp = SqlQuery

                crValeurTmp.Clear()
                crAttach.Clear()
                For n = 0 To crValeur.Count - 1
                    crValeurTmp.Add(crValeur(n))
                Next
                For i = 0 To rsml.Fields.Count - 1
                    SujetTmp = SujetTmp.Replace("@@@" & rsml.Fields.Item(i).Name, IsNull(rsml(i).Value, ""))
                    HeaderStrTmp = HeaderStrTmp.Replace("@@@" & rsml.Fields.Item(i).Name, IsNull(rsml(i).Value, ""))
                    FooterStrTmp = FooterStrTmp.Replace("@@@" & rsml.Fields.Item(i).Name, IsNull(rsml(i).Value, ""))
                    If CodSqlTmp <> "" Then CodSqlTmp = CodSqlTmp.Replace("@@@" & rsml.Fields.Item(i).Name, IsNull(rsml(i).Value, ""))
                    If crReport.Trim <> "" Then
                        For n = 0 To crValeurTmp.Count - 1
                            crValeurTmp(n) = crValeurTmp(n).ToString.Replace("@@@" & rsml.Fields.Item(i).Name, IsNull(rsml(i).Value, ""))
                        Next
                    End If
                Next
                'Générer les états crystal report
                If crReport.Trim <> "" Then
                    FichierPJ = crPDFPath & "\" & rnd.Next(1000, 9999) & ".pdf"
                    Dim pwd As String = ""
                    If Report_with_Pw Then
                        pwd = (New Random).Next(100001, 999999)
                        SujetTmp = SujetTmp.Replace("@@@Pwd", CStr(pwd))
                        HeaderStrTmp = HeaderStrTmp.Replace("@@@Pwd", CStr(pwd))
                        FooterStrTmp = FooterStrTmp.Replace("@@@Pwd", CStr(pwd))
                    End If

                    RptExportingToPdf(crReport, crParam, crValeurTmp, FichierPJ, pwd)
                    If IO.File.Exists(FichierPJ) Then
                        crAttach.Add(FichierPJ)
                    End If
                    For i = 0 To PJattach.Count - 1
                        crAttach.Add(PJattach(i))
                    Next
                End If
                'Préparation du Corps du Mail
                'Encodage vers Html
                '  SujetTmp = EncodeToHtml(SujetTmp)
                HeaderStrTmp = EncodeToHtml(HeaderStrTmp)
                FooterStrTmp = EncodeToHtml(FooterStrTmp)

                ' Table de la requête
                If CodSqlTmp <> "" Then
                    Dim _cn1 As New OleDb.OleDbConnection
                    _cn1.ConnectionString = connectionString
                    Dim TblQuery As DataTable = DATA_READER_GRD(CodSqlTmp, False, _cn1)
                    With TblQuery
                        If .Rows.Count > 0 Then
                            QueryHTML = "<center><table >"
                            'Entete table html
                            If HeaderVisible = True And EntTableHTML = "" Then
                                EntTableHTML &= "<tr style='background-color:#999999;font-weight:bold'>"
                                For j = 0 To .Columns.Count - 1
                                    EntTableHTML &= "<td valign=""middle"" style=""padding:0 3px 0 3px;text-align:center;"">" & EncodeToHtml(.Columns(j).ColumnName) & "</td>"
                                Next
                                EntTableHTML &= "</tr>"
                            End If
                            QueryHTML &= EntTableHTML
                            'ligne table <tr> et <td>
                            For i = 0 To .Rows.Count - 1
                                QueryHTML &= "<tr>"
                                For k = 0 To .Columns.Count - 1
                                    If .Columns(k).DataType = System.Type.GetType("System.Decimal") Or .Columns(k).DataType = System.Type.GetType("System.Double") Then
                                        Num = CStr(FormatNumber(IsNull(.Rows(i)(k), 0), 2))
                                        Num = Num.Replace(Chr(160), "&nbsp;")
                                        QueryHTML &= "<td align='right' style=""padding:0 3px 0 3px;"">" & Num & "</td>"
                                    Else
                                        QueryHTML &= "<td style=""padding:0 3px 0 3px;"">" & EncodeToHtml(IsNull(.Rows(i)(k), "")) & "</td>"
                                    End If
                                Next
                                QueryHTML &= "</tr>"
                            Next
                            QueryHTML &= "</table></center>"
                        Else
                            QueryHTML = ""
                        End If
                    End With
                End If

                Dim Objet As String = "<body>" & HeaderStrTmp & "<BR/>" & QueryHTML & "<BR/>" & FooterStrTmp & "</body>"
                Objet = Objet.Replace("@@@espace", "<BR/>")
                If (CodQuery.Trim <> "" And QueryHTML <> "") Or (CodQuery.Trim = "" And QueryHTML = "") Then
                    Dim rsl_envoi As envoiMailResult = EnvoiDeMail(rsml("Email").Value, IsNull(rs("CC").Value, ""), SujetTmp, Objet, crAttach, IsNull(rs("ReplyTo").Value, ""), IsNull(rs("CCi").Value, ""))
                    CnExecuting("insert into Mailing_Rapport (Cod_Mailing, Email, Dat_Envoi, Envoye,Resultat) values ('" & CodMailing & "','" & rsml("Email").Value & "',getdate(),'" & rsl_envoi.envoye & "','" & rsl_envoi.result.Replace("'", "''") & "')  ")
                    If listSentMail IsNot Nothing Then listSentMail.Add($"{New String("0"c, Str(nb).Length - 1) & k}/{nb} : {rsml("Email").Value} ({If(rsl_envoi.envoye, "Succès", "Echèc : " & rsl_envoi.result)})")
                End If
                ' 3. Supprimer le fichier temporaire non sécurisé
                ' Il faut libérer le verrou sur les fichiers AVANT de quitter la fonction
                For Each attach As Attachment In oMail.Attachments
                    attach.Dispose() ' Ceci libère le fichier PDF
                Next
                oMail.Attachments.Clear() ' On vide la liste pour le prochain tour
                If System.IO.File.Exists(FichierPJ) Then
                    System.IO.File.Delete(FichierPJ)
                End If
                ' Dim sw As New IO.StreamWriter("D:\mailing[" & rsml("Email").Value & "].html", True)
                '   sw.Write(Objet)
                '  sw.Close()
                rsml.MoveNext()
            End While
            rsml.Close()
        End If
        rs.Close()

        '   Catch ex As Exception
        '   ErrorMsg(ex)
        '   End Try

    End Sub
    Function GenererReport(CodMailing As String, CodReport As String) As DataTable
        Dim SqlCrit As String = "Select Critere,isnull(Valeur,Default_Value) as Default_Value  from Param_Mod_Edition_Criteres q
            outer apply (select isnull(Valeur,'') as Valeur from Mailing_Critere where isnull(Typ_Query,'')='RPT' and Cod_Mailing='" & CodMailing & "' and Cod_Query=q.Cod_Report and Critere=q.Critere) m
            where Cod_Report ='" & CodReport & "' 
            order by rang"
        Dim TblCriteres As DataTable = DATA_READER_GRD(SqlCrit, False, New OleDb.OleDbConnection With {.ConnectionString = connectionString})
        With TblCriteres
            .Columns("Default_Value").ReadOnly = False
            For i = 0 To .Rows.Count - 1
                .Rows(i)("Default_Value") = GetDefaultValue(CodReport, .Rows(i)("Default_Value"), "RPT")
            Next
        End With
        Return TblCriteres
    End Function
    Function GenererQuery(CodMailing As String, CodQuery As String) As String
        Dim SqlCrit As String = "Select Critere,isnull(Valeur,Default_Value) as Default_Value  from Param_Query_Criteres q
            outer apply (select isnull(Valeur,'') as Valeur from Mailing_Critere where isnull(Typ_Query,'')='SQL' and Cod_Mailing='" & CodMailing & "' and Cod_Query=q.Cod_Query and Critere=q.Critere) m
            where Cod_Query ='" & CodQuery & "' 
            order by rang"
        Dim TblCriteres As DataTable = DATA_READER_GRD(SqlCrit, False, New OleDb.OleDbConnection With {.ConnectionString = connectionString})
        Dim oRelation As String = ""
        With TblCriteres
            For i = 0 To .Rows.Count - 1
                oRelation &= IIf(oRelation = "", "", "#") & "'" & GetDefaultValue(CodQuery, .Rows(i).Item("Default_Value")) & "'"
            Next
        End With
        Return Query_Converter(CodQuery, oRelation)
    End Function
    Function GenererMailingList(CodList As Integer) As String
        Dim Cod_Sql As String = ""
        Cod_Sql = "select Civilite, Nom, Prenom,Email, isnull(Membre,'') as 'Typ_Tiers', 
        isnull(Cod_Tiers,'') as Code, isnull(Nom_Tiers,'') as Tiers, isnull(Fonction,'') as Fonction,id_Destinataire
        from Mailing_Destinataire d
        outer apply (select Membre from Param_Rubriques where Nom_Controle like 'Typ_Tiers' and Valeur=isnull(Typ_Tiers,''))c
        where Liste like '%," & CodList & ",%' or Liste like '%," & CodList & "' or Liste like '" & CodList & ",%'
        order by isnull(Nom_Tiers,''), Nom, Prenom"
        Return Cod_Sql
    End Function
    Sub RptExportingToPdf(etat As String, ParamList As ArrayList, ValList As ArrayList, FileName As String, Optional MonMotDePasse As String = "")
        Dim cryRpt As New ReportDocument

        ' --- CORRECTION : Utiliser un nom temporaire pour la génération brute ---
        Dim TempFileName As String = FileName.Replace(".pdf", "_temp.pdf")

        If ODBCRHP = "" Then
            MsgBox("ODBC non renseigné dans les paramétres généraux")
            Exit Sub
        End If
        ' ... (Le reste du chargement Crystal Report reste identique lignes 52-53) ...
        Dim DataBaseName As String = DB.ToUpper
        etat = pathImpression & "\" & etat & ".rpt"
        With cryRpt
            .Load(etat)
            .DataSourceConnections(0).SetConnection(ODBCRHP, DataBaseName, False)
            .DataSourceConnections(0).SetLogon(ConnectionSQL, PWDConnectionSQL)
        End With
        For i = 0 To ParamList.Count - 1
            cryRpt.SetParameterValue(ParamList(i), ValList(i))
        Next

        Try
            ' 1. Exporter vers le fichier TEMPORAIRE d'abord
            CType(cryRpt, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, TempFileName)

            If MonMotDePasse.Trim <> "" Then
                ' 2. Sécuriser : Source = Temp, Destination = Final
                SecuriserPDF(TempFileName, FileName, MonMotDePasse)

                ' 3. Supprimer le fichier temporaire s'il existe encore
                If IO.File.Exists(TempFileName) Then
                    Try : IO.File.Delete(TempFileName) : Catch : End Try
                End If
            Else
                ' Si pas de mot de passe, on renomme simplement le temp en final
                If IO.File.Exists(FileName) Then IO.File.Delete(FileName)
                IO.File.Move(TempFileName, FileName)
            End If

        Catch ex As Exception
            MsgBox("Erreur lors de l'export: " & ex.Message)
        Finally
            cryRpt.Close()
            cryRpt.Dispose()
        End Try
    End Sub

    Sub SecuriserPDF(ByVal sourceFile As String, ByVal destFile As String, ByVal password As String)
        Dim reader As PdfReader = Nothing
        Dim fs As FileStream = Nothing
        Dim stamper As PdfStamper = Nothing
        Try
            ' 1. Ouverture du fichier source
            reader = New PdfReader(sourceFile)

            ' 2. Création du flux de sortie
            fs = New FileStream(destFile, FileMode.Create, FileAccess.Write, FileShare.None)
            stamper = New PdfStamper(reader, fs)

            ' 3. Cryptage
            Dim pwdBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(password)
            stamper.SetEncryption(pwdBytes, pwdBytes, PdfWriter.ALLOW_PRINTING, PdfWriter.ENCRYPTION_AES_128)

            stamper.Close()
            ' Note: stamper.Close() ferme généralement aussi le flux 'fs', mais on assure le coup dans le Finally

        Catch ex As Exception
            MsgBox("Erreur lors de la sécurisation du PDF: " & ex.Message)
        Finally
            ' 4. NETTOYAGE OBLIGATOIRE
            ' C'est ici qu'on libère le fichier pour de bon
            If stamper IsNot Nothing Then
                Try : stamper.Close() : Catch : End Try
            End If
            If fs IsNot Nothing Then
                Try : fs.Close() : fs.Dispose() : Catch : End Try
            End If
            If reader IsNot Nothing Then
                Try : reader.Close() : Catch : End Try ' Très important pour libérer le fichier source
            End If
        End Try
    End Sub
    Function EncodeToHtml(ByVal str) As String
        str = str.replace(Chr(34), "&quot;")
        str = str.replace("<", "&lt;")
        str = str.replace(">", "&gt;")
        str = str.replace("€", "&euro;")
        str = str.replace("‡", "&Dagger;")
        str = str.replace("‹", "&lt;")
        str = str.replace("›", "&gt;")
        str = str.replace("œ", "&oelig;")
        str = str.replace(Chr(16), "&nbsp;")
        str = str.replace("¢", "&cent;")
        str = str.replace("£", "&pound;")
        str = str.replace("¥", "&yen;")
        str = str.replace("¦", "&brvbar;")
        str = str.replace("§", "&sect;")
        str = str.replace("©", "&copy;")
        str = str.replace("«", "&laquo;")
        str = str.replace("®", "&reg;")
        str = str.replace("°", "&deg;")
        str = str.replace("±", "&plusmn;")
        str = str.replace("´", "&acute;")
        str = str.replace("µ", "&micro;")
        str = str.replace("»", "&raquo;")
        str = str.replace("¼", "&frac14;")
        str = str.replace("½", "&frac12;")
        str = str.replace("¾", "&frac34;")
        str = str.replace("À", "&Agrave;")
        str = str.replace("Á", "&Aacute;")
        str = str.replace("Â", "&Acirc;")
        str = str.replace("Ã", "&Atilde;")
        str = str.replace("Ä", "&Auml;")
        str = str.replace("Å", "&Aring;")
        str = str.replace("Æ", "&AElig;")
        str = str.replace("Ç", "&Ccedil;")
        str = str.replace("È", "&Egrave;")
        str = str.replace("É", "&Eacute;")
        str = str.replace("Ê", "&Ecirc;")
        str = str.replace("Ë", "&Euml;")
        str = str.replace("Ì", "&Igrave;")
        str = str.replace("Í", "&Iacute;")
        str = str.replace("Î", "&Icirc;")
        str = str.replace("Ï", "&Iuml;")
        str = str.replace("Ñ", "&Ntilde;")
        str = str.replace("Ò", "&Ograve;")
        str = str.replace("Ó", "&Oacute;")
        str = str.replace("Ô", "&Ocirc;")
        str = str.replace("Õ", "&Otilde;")
        str = str.replace("Ö", "&Ouml;")
        str = str.replace("×", "&times;")
        str = str.replace("Ø", "&Oslash;")
        str = str.replace("Ù", "&Ugrave;")
        str = str.replace("Ú", "&Uacute;")
        str = str.replace("Û", "&Ucirc;")
        str = str.replace("Ü", "&Uuml;")
        str = str.replace("ß", "&szlig;")
        str = str.replace("à", "&agrave;")
        str = str.replace("á", "&aacute;")
        str = str.replace("â", "&acirc;")
        str = str.replace("ã", "&atilde;")
        str = str.replace("ä", "&auml;")
        str = str.replace("å", "&aring;")
        str = str.replace("æ", "&aelig;")
        str = str.replace("ç", "&ccedil;")
        str = str.replace("è", "&egrave;")
        str = str.replace("é", "&eacute;")
        str = str.replace("ê", "&ecirc;")
        str = str.replace("ë", "&euml;")
        str = str.replace("ì", "&igrave;")
        str = str.replace("í", "&iacute;")
        str = str.replace("î", "&icirc;")
        str = str.replace("ï", "&iuml;")
        str = str.replace("ð", "&eth;")
        str = str.replace("ñ", "&ntilde;")
        str = str.replace("ò", "&ograve;")
        str = str.replace("ó", "&oacute;")
        str = str.replace("ô", "&ocirc;")
        str = str.replace("õ", "&otilde;")
        str = str.replace("ö", "&ouml;")
        str = str.replace("÷", "&divide;")
        str = str.replace("ø", "&oslash;")
        str = str.replace("ù", "&ugrave;")
        str = str.replace("ú", "&uacute;")
        str = str.replace("û", "&ucirc;")
        str = str.replace("ü", "&uuml;")


        'Saut de ligne
        str = str.replace(Chr(13), "<br/>")
        Return str
    End Function
    Public Structure envoiMailResult
        Public envoye As Boolean
        Public result As String
    End Structure

    Function EnvoiDeMail(ByVal ToAdress As String, ByVal CcAdress As String, ByVal Objet As String, ByVal Body As String, Optional Attachement As ArrayList = Nothing, Optional RepondreA As String = "", Optional CCiAdress As String = "") As envoiMailResult
        Try
            If oSmtpServer.Host Is Nothing Or IsNull(oSmtpServer.Port, "0") = "0" Then
                ShowMessageBox("Paramètres de messagerie non renseignées")
                Return New envoiMailResult With {.envoye = False, .result = "Paramètres de messagerie non renseignées"}
            End If
            oSmtpServer.Timeout = 30000
            ToAdress = ToAdress.Replace(",", ";")
            CcAdress = CcAdress.Replace(",", ";")
            CCiAdress = CCiAdress.Replace(",", ";")
            RepondreA = RepondreA.Replace(",", ";")
            Dim addr() As String = ToAdress.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            Dim Cc() As String = CcAdress.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            Dim Cci() As String = CCiAdress.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            Dim Rply() As String = RepondreA.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            oMail.To.Clear()
            oMail.CC.Clear()
            oMail.Bcc.Clear()
            oMail.ReplyToList.Clear()
            oMail.Attachments.Clear()
            If ToAdress.Trim <> "" Then
                For i = 0 To addr.Length - 1
                    oMail.To.Add(addr(i))
                Next
            End If
            If CcAdress.Trim <> "" Then
                For i = 0 To Cc.Length - 1
                    oMail.CC.Add(Cc(i))
                Next
            End If
            If CCiAdress.Trim <> "" Then
                For i = 0 To Cci.Length - 1
                    oMail.Bcc.Add(Cci(i))
                Next
            End If
            If RepondreA.Trim <> "" Then
                For i = 0 To Rply.Length - 1
                    oMail.ReplyToList.Add(Rply(i))
                Next
            End If
            oMail.Subject = Objet
            Body = Body.Replace(vbCrLf, "<br/>")
            Body = $"<html>{Body}</html>"
            oMail.Body = Body
            oMail.IsBodyHtml = True
            If Not Attachement Is Nothing Then
                For i = 0 To Attachement.Count - 1
                    oMail.Attachments.Add(New Attachment(Attachement(i)))
                Next
            End If
            oMail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            oSmtpServer.Send(oMail)
            Return New envoiMailResult With {.envoye = True, .result = "Envoyé avec succès"}
        Catch ex As Exception
            Return New envoiMailResult With {.envoye = False, .result = ex.Message}
        End Try
    End Function
End Module
