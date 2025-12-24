Module Module_Acces_Security
    Friend ErrCalcul As String = ""
    Sub Show_form(ByVal q As Form)
        With q
            .TopLevel = False
            .TopMost = True
            .FormBorderStyle = FormBorderStyle.None
            .AutoScroll = True
            .Dock = DockStyle.Fill
        End With
    End Sub
    Sub Affectation(ByVal f As Form, ByVal NameControle As String, ByVal oValeur As String)
        Select Case True
            Case f.GetType Is GetType(Param_Query_Saisi)
                Dim qryFrm As Param_Query_Saisi = TryCast(f, Param_Query_Saisi)
                With qryFrm
                    Dim oGrd As ud_Grd = .Criteres_Grd
                    For i = 0 To oGrd.RowCount - 1
                        If IsNull(oGrd.Item(.Critere.Index, i).Value, "").ToUpper.Trim = NameControle.ToUpper.Trim Then
                            oGrd.Item(.Valeur.Index, i).Value = oValeur
                            Exit Sub
                        End If
                    Next
                End With

            Case f.GetType Is GetType(Param_Python_Saisi)
                Dim pytFrm As Param_Python_Saisi = TryCast(f, Param_Python_Saisi)
                With pytFrm
                    Dim oGrd As ud_Grd = .Arguments_Grd
                    For i = 0 To oGrd.RowCount - 1
                        If IsNull(oGrd.Item(.Argument.Index, i).Value, "").ToUpper.Trim = NameControle.ToUpper.Trim Then
                            oGrd.Item(.Valeur.Index, i).Value = oValeur
                            Exit Sub
                        End If
                    Next
                End With

            Case Else
                Dim c As Object = GetControlByName(NameControle, f)
                If c IsNot Nothing Then
                    If c.GetType.Name = "TextBox" Or c.GetType.Name = "ud_TextBox" Then
                        c.Text = oValeur
                    ElseIf c.GetType.Name = "ComboBox" Or c.GetType.Name = "ud_ComboBox" Then
                        c.SelectedValue = oValeur
                    End If
                End If
        End Select
    End Sub
    Public Function GetFormByName(ByVal FrmName As String) As Form
        Dim f As New Form
        f = CType(System.Activator.CreateInstance(System.Type.GetType("RHP." & FrmName)), Form)
        Return f
    End Function
    Public Function DroitModify_Fiche(ByVal Code As String, ByVal Ecran As Ecran) As Boolean
        Dim obtn = Ecran.GererAccessibilite()
        If CnExecuting("Select count(*) from Controle_Access where id_Societe='" & Societe.id_Societe & "' and  Name_Ecran='" & Ecran.Name & "' and value='" & Code & "'").Fields(0).Value > 0 Then
            Dim Taken_By_User As String = FindLibelle("Taken_By_User", "Name_Ecran+value", Ecran.Name & Code, "Controle_Access")
            Dim UserName As String = ""
            If estEmail(Taken_By_User) Then
                UserName = FindLibelle("Nom_User + ' ' + Prenom_User", "Mail", Taken_By_User, "Controle_Users")
            End If
            If UserName = "" And estEmail(Taken_By_User) Then
                UserName = FindLibelle("Nom_Agent + ' ' + Prenom_Agent", "Mail", Taken_By_User, "Rh_Agent")
            End If
            If UserName = "" Then
                UserName = FindLibelle("Nom_User + ' ' + Prenom_User", "id_User", Taken_By_User, "Controle_Users")
            End If
            With obtn
                .Visible = True
                .Text = "En cours de Modification par " & UserName
                .Refresh()
            End With
            Return False
        Else
            With obtn
                .Visible = False
                .Text = ""
                .Refresh()
            End With
        End If
        If CStr(theUser.Cod_Profile) = "1" Then
            Return True
        ElseIf FindLibelle("Actif", "Cod_Profile", theUser.Cod_Profile & "' and Name_Ecran='" & Ecran.Name, "Controle_Droit") <> "True" And theUser.Typ_Role <> "Agent" Then
            Return False
        Else
            Return True
        End If
    End Function
    Sub DroitAcces(ByVal f As Ecran, ByVal DroitModify As Boolean)
        Dim TypSecurity As String = ""
        Dim c As Object
        Dim nRows() As DataRow
        nRows = TblAccess.Select("[Name_Ecran]='" & f.Name & "' and Typ_Security in ('SC','NC')")
        With nRows
            For i = 0 To .Length - 1
                TypSecurity = nRows(i)("Typ_Security")
                c = GetControlByName(nRows(i)("Name_Controle"), f)
                If c IsNot Nothing Then
                    Select Case TypSecurity
                        Case "NC"
                            Enabling(c, DroitModify And Not Societe.Mis_Sml)
                        Case "SC"
                            If Not CBool(nRows(i)("Visible")) Then
                                c.visible = False
                            ElseIf Not CBool(nRows(i)("Actif")) Then
                                Enabling(c, False)
                                c.visible = True
                            ElseIf DroitModify Then
                                c.visible = True
                                Enabling(c, Not Societe.Mis_Sml)
                            Else
                                c.visible = True
                                Enabling(c, False)
                            End If
                    End Select
                ElseIf f.Parent IsNot Nothing Then
                    c = GetControlByName(nRows(i)("Name_Controle"), f)
                    If c IsNot Nothing Then
                        Select Case TypSecurity
                            Case "NC"
                                Enabling(c, DroitModify And Not Societe.Mis_Sml)
                            Case "SC"
                                If Not CBool(nRows(i)("Visible")) Then
                                    c.visible = False
                                ElseIf Not CBool(nRows(i)("Actif")) Then
                                    Enabling(c, False)
                                    c.visible = True
                                ElseIf DroitModify Then
                                    c.visible = True
                                    Enabling(c, Not Societe.Mis_Sml)
                                Else
                                    c.visible = True
                                    Enabling(c, False)
                                End If
                        End Select
                    End If
                End If
            Next
        End With
        Return
    End Sub
    Public Function GetControlByName(ByVal Name As String, ByVal CurrentForm As Ecran) As Object
        Dim Ctrl() = CurrentForm.Controls.Find(Name, True)
        If Ctrl.Length > 0 Then
            Return Ctrl(0)
        ElseIf CurrentForm.dictButtons.ContainsKey(name) Then
            Return CurrentForm.dictButtons(Name)
        Else
            Return Nothing
        End If
    End Function

    Sub SelectingContent(ByVal sender, ByVal e)
        CType(sender, TextBox).SelectAll()
    End Sub

    Sub Enabling(ByVal Objet As Object, ByVal Enabled As Boolean)
        If Objet Is Nothing Then Return
        With Objet
            Select Case Enabled
                Case True
                    If "TextBox;ud_TextBox".Split(";").Contains(Objet.GetType.Name) Then
                        .BackColor = System.Drawing.Color.White
                        .readonly = False
                    ElseIf Objet.GetType.Name = "RichTextBox" Then
                        .BackColor = System.Drawing.Color.White
                        .readonly = False
                    ElseIf "ComboBox;ud_ComboBox".Split(";").Contains(Objet.GetType.Name) Then
                        .BackColor = System.Drawing.Color.White
                        .enabled = True
                    ElseIf "DataGridView;ud_Grd".Split(";").Contains(Objet.GetType.Name) Then
                        .readonly = False
                    Else
                        .enabled = True
                    End If
                Case False
                    If "TextBox;ud_TextBox".Split(";").Contains(Objet.GetType.Name) Then
                        .BackColor = .findform.backcolor
                        .readonly = True
                    ElseIf Objet.GetType.Name = "RichTextBox" Then
                        .BackColor = .findform.backcolor
                        .readonly = True
                    ElseIf "ComboBox;ud_ComboBox".Split(";").Contains(Objet.GetType.Name) Then
                        .BackColor = .findform.backcolor
                        .enabled = False
                    ElseIf "DataGridView;ud_Grd".Split(";").Contains(Objet.GetType.Name) Then
                        .readonly = True
                    Else

                        .enabled = False
                    End If
            End Select
        End With
    End Sub
    Sub KeyPressForm(ByVal f As Ecran)
        Dim nRows() As DataRow
        Dim str As String = ""
        Try
            Dim InfoBulle = New System.Windows.Forms.ToolTip
            AddHandler f.KeyUp, AddressOf RefrechingF5
            Dim TypControle As String = ""
            nRows = TblAccess.Select("[Name_Ecran]='" & f.Name & "'")
            With nRows
                For i = 0 To .Length - 1
                    Dim c As Object = Nothing
                    TypControle = IsNull(nRows(i)("Typ_Controle"), "")
                    str = nRows(i)("Name_Controle")
                    If TypControle <> "" Then c = GetControlByName(str, f)

                    If Not c Is Nothing Then
                        If TypControle.GetType Is GetType(ud_TextBox) Then
                            AddHandler CType(c, TextBox).KeyUp, AddressOf KeyPressing
                            AddHandler CType(c, TextBox).DoubleClick, AddressOf SelectingContent
                        End If
                        Dim oRow() As DataRow
                        oRow = Tbl_Controle_Def_Label.Select("[Name_Ecran]='" & f.Name & "' and Name_Label='" & c.Name & "'")
                        If oRow.Length > 0 Then
                            If c.GetType.Name = "LinkLabel" Or c.GetType.Name = "Label" Then
                                Dim Txt As String = IsNull(oRow(0)("Alias_Label"), "")
                                Dim opt As Point = c.Location
                                Dim sz As Size = c.Size
                                If Txt.Trim <> "" Then
                                    c.Text = Txt
                                    c.location = New Point(opt.X + (sz.Width - c.width), opt.Y)
                                End If
                            End If
                        End If
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Ecran : " & f.Name & " Controle : " & str)
        End Try
    End Sub
    Sub RefrechingF5(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData <> Keys.F5 Then Exit Sub
        Dim oRow() As DataRow
        Dim f As Form = CType(sender.findform, Form)
        oRow = Tbl_Controle_Def_Ecran.Select("[Name_Ecran]='" & f.Name & "'")
        If oRow.Length = 0 Then Exit Sub
        Dim IndexName As String = IsNull(oRow(0)("Index_Ecran"), "")
        If IndexName <> "" Then
            Dim IndexControle As Object = SearchIndex(f, IndexName, Nothing)
            If IndexControle Is Nothing Then Exit Sub
            If Not TypeOf (IndexControle) Is TextBox Then Exit Sub
            Dim OldValue As String = CType(IndexControle, TextBox).Text
            CType(IndexControle, TextBox).ResetText()
            CType(IndexControle, TextBox).Text = OldValue
        End If
    End Sub
    Function SearchIndex(ByVal frm As Object, ByVal index_name As String, ByVal oIndex As Object)
        For Each c In frm.Controls
            If c.name.trim.toupper = index_name.Trim.ToUpper Then
                oIndex = c
            ElseIf c.HasChildren Then
                oIndex = SearchIndex(c, index_name, oIndex)
            End If
        Next
        Return oIndex
    End Function
    Sub KeyPressing(ByVal sender As Object, ByVal e As Object)
        If e.KeyData = Keys.F12 Then
            MessageBoxRHP(523, sender.name & ";" & sender.GetType.Name & ";" & sender.findform.name)
        End If
        If sender.GetType Is GetType(ud_TextBox) Then
            If e.KeyData = Keys.F9 Then
                Dim CodLien As String = CnExecuting("select isnull((select Top 1 Cod_Lien From Controle_Link where Name_Ecran='" & CType(sender, TextBox).FindForm.Name & "' and Name_Controle='" & CType(sender, TextBox).Name & "' ),'')").Fields(0).Value
                If CodLien = "" Then Exit Sub
                Dim Name_Ecran As String = FindLibelle("Link_To_Ecran", "Cod_Lien", CodLien, "Controle_Link")
                Dim Valeur_Index As String = CType(sender, TextBox).Text
                Dim Name_Index As String = FindLibelle("Name_Index", "Cod_Lien", CodLien, "Controle_Link")
                If Name_Ecran <> "" And Valeur_Index <> "" Then
                    Dim f As Form = CType(System.Activator.CreateInstance(System.Type.GetType("RHP." & Name_Ecran)), Form)
                    Findindex(f, Name_Index, Valeur_Index)
                    newShowEcran(f)
                End If
            End If
        End If
        If e.KeyData = Keys.F5 Then
            RefrechingF5(sender, e)
        End If
    End Sub
    Sub Findindex(ByVal frm As Object, ByVal index_name As String, ByVal Valeur_Index As String)
        Dim c As Object
        c = GetControlByName(index_name, frm)
        If Not c Is Nothing Then
            c.text = Valeur_Index
        End If
    End Sub
    Sub Check_Accessible(ByVal Ecran_Name As String, ByVal Value As String)
        '    CnExecuting("delete from Controle_Access where Process_Id not in (select hostprocess from sys.sysprocesses )")
        If Value <> "" And CnExecuting("Select count(*) from Controle_Access where Name_Ecran='" & Ecran_Name & "' and value='" & Value & "'").Fields(0).Value = 0 Then
            CnExecuting("insert into Controle_Access (Name_Ecran, Value,id_Societe, Taken_By_User, Taken_By_Machine, IP, Process_Id, Date_Deb) values ('" & Ecran_Name & "','" & Value & "'," & Societe.id_Societe & ",'" & theUser.id_User & "','" & My.Computer.Name & "','','" & ProcessId & "',getdate())")
        End If

    End Sub
    Sub ErrorMsg(ByVal ex As Exception)
        If ex.ToString.Contains("[DBNETLIB]") Then
            ShowMessageBox("Erruer Réseau : Vous n'êtes pas connecté.")
            FermetureForcee = "O"
            Application.Exit()
        Else
            SqlErreur = ""
            ShowMessageBox(ex.Message)
            '    ShowMessageBox(ex.ToString)

        End If

    End Sub
    Function CnExecuting(ByVal Str As String, Optional ShowSql As Boolean = False) As ADODB.Recordset
        Dim CEx As New ADODB.Recordset
        Dim strTime As Date = Nothing
        Try
            If cn.Execute("Select count(*) from sysobjects where name='Controle_Traitement'").Fields(0).Value > 0 Then
                If cn.Execute("Select count(*) from Controle_Traitement where Termine='N'").Fields(0).Value > 0 Then
                    MessageBoxRHP(518)
                    Application.Exit()
                End If
            End If
            strTime = Now
            If ShowSql Then MsgBox(Str)
            CEx = cn.Execute(Str)

        Catch ex As Exception
            'SqlErreur = Str
            ErrorMsg(ex)
        End Try

        Return CEx
    End Function
    Function CnTempExecuting(ByVal Str As String) As ADODB.Recordset
        Dim CEx As New ADODB.Recordset
        Dim CnTemp As New ADODB.Connection
        CnTemp.ConnectionString = connectionString
        CnTemp.Open()
        Try
            CEx = CnTemp.Execute(Str)
        Catch ex As Exception
            'SqlErreur = Str
            ErrorMsg(ex)
        End Try

        Return CEx
        CnTemp.Close()
    End Function
    Function TableDesModEdition(Optional fName As String = "") As DataTable
        Dim Sqlstr As String = ""
        If fName <> "" Then
            Sqlstr = "select Cod_Report as 'Rapport',Nom_Report as Libellé
from Param_Mod_Edition r 
where exists(select Cod_Report from Controle_Def_Ecran_Mod_Edition 
where Cod_Report=r.Cod_Report and Name_Ecran='" & fName & "') and (isnull(parSociete,'false')='false' or exists(select id_Societe from Param_Societe where id_Societe=" & Societe.id_Societe & " and isnull(Mod_Edition,'') like '%;'+r.Cod_Report+';%' ) )
                             order by  Nom_Report"
        Else
            Sqlstr = "select Cod_Report,Nom_Report 
from Param_Mod_Edition r 
where (isnull(parSociete,'false')='false' or exists(select id_Societe from Param_Societe where id_Societe=" & Societe.id_Societe & " and isnull(Mod_Edition,'') like '%;'+r.Cod_Report+';%' ) )
                             order by  Nom_Report"
        End If
        Return DATA_READER_GRD(Sqlstr)
    End Function
    Function EstModEditionAutorisePourLaSocieteEncours(CodReport As String, Optional fName As String = "") As Boolean
        Dim Tbl As DataTable = TableDesModEdition(fName)
        If Not Tbl Is Nothing Then
            If Tbl.Columns.Contains("Rapport") Then
                Return (Tbl.Select("Rapport='" & CodReport & "'").Length > 0)
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
End Module
