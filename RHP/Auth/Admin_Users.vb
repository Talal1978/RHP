Imports CrystalDecisions.Enterprise

Public Class Admin_Users
    Friend Code As String = ""
    Dim ParamTbl As New DataTable
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim New_D As ud_btn
    Dim Duplik_D As ud_btn
    Dim Reset_D As ud_btn
    Dim modeDuplication As Boolean = False
    Sub Chargement()
        If Typ_Role.Items.Count = 0 Then Typ_Role.fromRubrique()
        miseAjourDroitSociete("")
    End Sub
    Sub miseAjourDroitSociete(Login As String)
        Dim sqlStr = $"declare @login nvarchar(50)='{Login}'
select id_Societe, Den,isnull(Droits,'') Droits,convert(bit,case when ';'+Droits+';' like '%;'+@login+';%' or Droits ='*' then 'true' else 'false' end) as Visible from Param_Societe order by Prioritie desc"
        Dim Tbl = DATA_READER_GRD(sqlStr)
        With lv_Societes
            .Items.Clear()
            For i = 0 To Tbl.Rows.Count - 1
                Dim itm As New ListViewItem
                itm.Name = Tbl.Rows(i)("id_Societe")
                itm.Text = Tbl.Rows(i)("Den")
                itm.Tag = Tbl.Rows(i)("Droits")
                itm.Checked = (CBool(Tbl.Rows(i)("Visible")) Or (Login = "Admin"))
                .Items.Add(itm)
            Next
        End With
    End Sub
    Private Sub Login_User_Label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Login_User_Label.LinkClicked
        If id_User_Text.Text = "1" Then
            MessageBoxRHP(350)
            Exit Sub
        End If
        Chargement()

        Appel_Zoom1("MS061", Cod_Profile_Text, Me)
    End Sub
    Sub Requesting()
        Try
            Chargement()

            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
            If Not Login_User_Text.ReadOnly Then Enabling(Login_User_Text, False)
            If modeDuplication Then Return
            Typ_Role.SelectedIndex = -1
            Typ_Role.Enabled = True
            Login_User_Label.Enabled = True
            Cod_Profile_Text.Text = ""
            DroitAcces(Me, DroitModify_Fiche(id_User_Text.Text, Me))
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, id_User_Text.Text)
                Code = id_User_Text.Text
            End If
            Nom_User_Text.Text = FindLibelle("Nom_User", "Login_User", Login_User_Text.Text, "Controle_Users")
            Prenom_User_Text.Text = FindLibelle("Prenom_User", "Login_User", Login_User_Text.Text, "Controle_Users")
            id_User_Text.Text = FindLibelle("id_User", "Login_User", Login_User_Text.Text, "Controle_Users")
            Cod_Profile_Text.Text = FindLibelle("Cod_Profile", "Login_User", Login_User_Text.Text, "Controle_Users")
            Actif_Check.Checked = FindLibelle("Actif", "Login_User", Login_User_Text.Text, "Controle_Users")
            Mouvemente_Check.Checked = FindLibelle("Mouvemente", "Login_User", Login_User_Text.Text, "Controle_Users")
            Mail_Text.Text = FindLibelle("Mail", "Login_User", Login_User_Text.Text, "Controle_Users")
            is_AD_chk.Checked = FindLibelle("is_AD", "Login_User", Login_User_Text.Text, "Controle_Users")
            Typ_Role.SelectedValue = FindLibelle("Typ_Role", "Login_User", Login_User_Text.Text, "Controle_Users")
            If id_User_Text.Text = 1 Then
                Actif_Check.Enabled = False
            Else
                Actif_Check.Enabled = True
            End If


            RequestParam()

            If id_User_Text.Text = "1" Then
                Typ_Role.SelectedValue = "Admin"
                Typ_Role.Enabled = False
                Login_User_Label.Enabled = False
                Cod_Profile_Text.Text = 1
                miseAjourDroitSociete("Admin")
            Else
                miseAjourDroitSociete(Login_User_Text.Text)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub
    Function ApplyADInfo() As Boolean
        If Login_User_Text.Text.Trim = "" Then Return False
        If Not is_AD_chk.Checked Then Return False
        Dim userInfo As ADUserInfo = GetADUserInfo(Login_User_Text.Text.Trim)
        If Not userInfo.Exists Then
            ShowMessageBox("Ce compte n'existe pas.", "Active Directory")
            Return False
        End If
        Nom_User_Text.Text = userInfo.Surname
        Prenom_User_Text.Text = userInfo.GivenName
        Mail_Text.Text = userInfo.Email
        Actif_Check.Checked = userInfo.Enabled
        Return True
    End Function
    Function Saving() As savingResult
        If Cod_Profile_Text.Text = "" Or Cod_Profile_Text.Text = "0" Then
            Return New savingResult With {.result = False, .message = MessageBoxRHPText(362)}
        End If
        ModifierParamTbl()
        Dim rs, rs1 As New ADODB.Recordset
        If Typ_Role.SelectedIndex < 0 Then
            Return New savingResult With {.result = False, .message = "Type de rôle non renseigné"}
        End If
        If estEmail(Login_User_Text.Text) Then
            Return New savingResult With {.result = False, .message = "Le login ne doit pas être de format mail."}
        End If
        If RTrim(LTrim(Login_User_Text.Text)) = "" Or RTrim(LTrim(Nom_User_Text.Text)) = "" Or RTrim(LTrim(Prenom_User_Text.Text)) = "" Then
            Return New savingResult With {.result = False, .message = MessageBoxRHPText(363)}
        End If
        If Cod_Profile_Text.Text = "1" And Typ_Role.SelectedValue <> "Admin" Then
            Typ_Role.SelectedValue = "Admin"
        End If
        If Cod_Profile_Text.Text <> "1" And Typ_Role.SelectedValue = "Admin" Then
            Return New savingResult With {.result = False, .message = "Incohérence entre le type de rôle et le profil"}
        End If
        If Not estEmail(Mail_Text.Text) Then
            Return New savingResult With {.result = False, .message = "Veuillez fournir un mail valide."}
        End If
        If CnExecuting("select count(*) from Controle_Users where Login_User!='" & Login_User_Text.Text & "' and Nom_User+Prenom_User='" & Nom_User_Text.Text & Prenom_User_Text.Text & "'").Fields(0).Value > 0 Then
            Return New savingResult With {.result = False, .message = "Nom et prénom accordés à un autre login"}
        End If
        If is_AD_chk.Checked Then
            If ShowMessageBox("Voulez-vous appliquer les données récupérées de l'Active Directory?", "Active Directory", MessageBoxButtons.OKCancel, msgIcon.Question) = MsgBoxResult.Ok Then
                If Not ApplyADInfo() Then Return New savingResult With {.result = False, .message = "Erreur Active Directory."}
            End If
        End If

        rs.Open("select *  from Controle_Users where Login_User='" & Login_User_Text.Text & "'", cn, 1, 3)
        If rs.EOF Then
            'Cas d'un nouvel Création
            rs.AddNew()
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = Now
            rs("Login_User").Value = Login_User_Text.Text
            If Not is_AD_chk.Checked Then resetPassWord()
        Else
            'Cas de MAJ
            rs.Update()
        End If
        rs("Typ_Role").Value = Typ_Role.SelectedValue
        rs("Nom_User").Value = Nom_User_Text.Text
        rs("Prenom_User").Value = Prenom_User_Text.Text
        rs("Mail").Value = Mail_Text.Text
        rs("Actif").Value = Actif_Check.Checked
        rs("Cod_Profile").Value = Cod_Profile_Text.Text
        rs("is_AD").Value = is_AD_chk.Checked
        rs("Modified_By").Value = theUser.Login
        rs("Dat_Modif").Value = Now
        rs.Update()
        Dim idUSer As Integer = rs("id_User").Value
        rs.Close()

        SavingParams(idUSer)
        'mise à jours des droits pas 
        With lv_Societes
            For Each itm As ListViewItem In .Items
                If itm.Checked Then
                    If Not itm.Tag = "*" And Not (";" + itm.Tag.ToString.ToUpper + ";").Contains(";" + Login_User_Text.Text.ToUpper + ";") Then
                        CnExecuting($"update Param_Societe set Droits='{If(itm.Tag.ToString = "", "", itm.Tag.ToString + ";") + Login_User_Text.Text.ToUpper}'  where id_Societe={itm.Name}")
                    End If
                Else
                    If itm.Tag = "*" Then
                        Dim lesLogins As String = CnExecuting($"select isnull((select  string_agg(Login_User,';') as lesLogins from Controle_Users  where Login_User!='{Login_User_Text.Text }'),'') lesLogins").Fields(0).Value
                        CnExecuting($"update Param_Societe set Droits='{lesLogins}' where id_Societe={itm.Name}")
                    ElseIf (";" + itm.Tag.ToString.ToUpper + ";").Contains(";" + Login_User_Text.Text.ToUpper + ";") Then
                        Dim lst = itm.Tag.ToString.ToUpper.Split(";").ToList()
                        Dim newLst = String.Join(";", lst.Where(Function(x) x <> Login_User_Text.Text.ToUpper).ToList())
                        CnExecuting($"update Param_Societe set Droits='{newLst}' where id_Societe={itm.Name}")
                    End If
                End If
            Next
            If Menu_Societes IsNot Nothing Then
                If Not Menu_Societes.BKG.IsBusy Then
                    Menu_Societes.BKG.RunWorkerAsync()
                End If
            Else
                ChargerSociete()
            End If
        End With
        If CnExecuting("select count(Login_User)  from Controle_Users where isnull(Actif,'False')='True'").Fields(0).Value > CDbl(Droits.NbUsers) Then
            Return New savingResult With {.result = False, .message = MessageBoxRHPText(364, Droits.NbUsers)}
        End If
        modeDuplication = False
        Return New savingResult With {.result = True, .message = MessageBoxRHPText(352)}
    End Function
    Function resetPassWord() As Boolean
        Dim rnd As New Random
        Dim AryL As New ArrayList()
        Dim psw As String = ""
        AryL.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"})
        For i = 0 To 10
            psw &= AryL(rnd.Next(0, AryL.Count - 1))
        Next

        If EnvoiDeMail(Mail_Text.Text, "", "Génération de mot de passe", $"Bonjour {Nom_User_Text.Text } {Prenom_User_Text.Text }," & vbCrLf & $"L'administrateur de RHP a procédé la réinitialisation de votre mot de passe.{vbCrLf}Voici votre nouveau mot de passe : " & psw).envoye Then
            ShowMessageBox("Le nouveau mot de passe a été envoyé à l'adresse mail : " & Mail_Text.Text, "Changement de mot de passe", MessageBoxButtons.OK, msgIcon.Information)
            If theUser.Typ_Role = "Agent" Then
                CnExecuting("update Rh_Agent set PW='" & Encrypt(psw) & "', Dat_Modif=getdate() where isnull(Mail,'')='" & theUser.Login & "'")
            Else
                CnExecuting("update Controle_Users set Pwd_User='" & Encrypt(psw) & "', Dat_Modif=getdate()  where Login_User='" & theUser.Login & "'")
            End If
            Return True
        Else
            ShowMessageBox("Erreur de mail : impossible d'envoyer le mot de passe." & vbCrLf &
                                     Mail_Text.Text _
                                      & vbCrLf, "Changement de mot de passe", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
    End Function
    Private Sub Admin_Users_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If CnExecuting("select count(Login_User)  from Controle_Users where isnull(Actif,'False')='True'").Fields(0).Value > CDbl(Droits.NbUsers) Then
                MessageBoxRHP(364, Droits.NbUsers)
                e.Cancel = True
            End If

            If Save_D.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & id_User_Text.Text & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Dupliquer()
        modeDuplication = True
        With Login_User_Text
            .Text = ""
            .ReadOnly = False
            id_User_Text.ResetText()
            .Select()
        End With
    End Sub
#Region "Paramétres Généraux par Utilisateurs"
    Sub RequestParam()

        Param_GRD.Rows.Clear()

        ParamTbl = DATA_READER_GRD("SELECT Cod_Param, isnull(o.Valeur,f.Valeur) as Valeur, Anglet, Libelle, Type," &
                                   " Typ_Param_General, Menu, Flag_User FROM         Param_General f " &
                                   " outer apply " &
                                   " (select Valeur from Param_General_User where Cod_Param=f.Cod_Param and id_User='" & id_User_Text.Text & "') o " &
                                     " where isnull(Flag_User,'False')='True'")

        ParamTbl.Columns("Valeur").ReadOnly = False

        Dim ImgList As New ImageList
        Param_TreeView.ImageList = ImgList
        ImgList.Images.Add(New Bitmap(My.Resources.openning))
        Param_TreeView.Nodes("Param").Nodes.Clear()
        Dim Cod_Sql As String = "Select distinct Anglet,dbo.FindRubrique('Anglet_Param_General',Anglet) as Texte  from Param_General where isnull(Flag_User,'False')='True'"
        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                Dim N As New TreeNode
                N.Name = IsNull(.Rows(i).Item("Anglet"), "")
                N.Text = IsNull(.Rows(i).Item("Texte"), "")
                N.ImageIndex = 0
                Param_TreeView.Nodes("Param").Nodes.Add(N)
            Next
        End With
        Param_TreeView.ExpandAll()
        If Param_TreeView.Nodes("Param").Nodes.Count > 1 Then Param_TreeView.SelectedNode = Param_TreeView.Nodes("Param").Nodes("Ges_Ven")

        Request()

    End Sub
    Sub Request()

        ModifierParamTbl()

        Dim oAnglet As String = ""
        If Not Param_TreeView.SelectedNode Is Nothing Then
            oAnglet = Param_TreeView.SelectedNode.Name
            If Param_TreeView.SelectedNode.Name.Contains("Ges") Then
                ParamLabel.Text = "Paramètres Généraux \ " & Param_TreeView.SelectedNode.Text
                ParamLabel.Visible = True
            Else
                ParamLabel.Visible = False
            End If
        End If
        Param_GRD.Rows.Clear()
        With ParamTbl
            Dim C1, C2, C3, C4, C5, C6 As Object
            For i = 0 To .Rows.Count - 1
                If IsNull(.Rows(i).Item("Anglet"), "") = oAnglet Then
                    C1 = .Rows(i).Item("Cod_Param")
                    C2 = .Rows(i).Item("Libelle")
                    C3 = .Rows(i).Item("Valeur")
                    C4 = .Rows(i).Item("Type")
                    C5 = .Rows(i).Item("Typ_Param_General")
                    C6 = .Rows(i).Item("Menu")
                    Param_GRD.Rows.Add(C1, C2, C3, C4, C5, C6)
                End If
            Next
        End With
        With Param_GRD
            For i = 0 To .RowCount - 1
                If IsNull(.Item("Typ_Param_General", i).Value, "") = "Num" Then
                    .Item("Valeur", i).Style.Alignment = DataGridViewContentAlignment.TopRight
                    .Item("Valeur", i).Value = FormatNumber(IsNull(.Item("Valeur", i).Value.ToString.Replace(".", ","), "0"), 3)
                ElseIf IsNull(.Item("Typ_Param_General", i).Value, "") = "Ent" Then
                    .Item("Valeur", i).Style.Alignment = DataGridViewContentAlignment.TopRight
                    .Item("Valeur", i).Value = FormatNumber(IsNull(.Item("Valeur", i).Value, "0"), 0)
                ElseIf IsNull(.Item("Typ_Param_General", i).Value, "") = "Alpha" Then
                    .Item("Valeur", i).Style.Alignment = DataGridViewContentAlignment.TopLeft
                    .Item("Valeur", i).ReadOnly = False
                Else
                    .Item("Valeur", i).Style.Alignment = DataGridViewContentAlignment.TopLeft
                    .Item("Valeur", i).ReadOnly = True
                End If
            Next
        End With
    End Sub
    Private Sub SavingParams(idUser As Integer)
        Dim rs As New ADODB.Recordset
        Try
            CnExecuting("Delete from Param_General_User where id_User='" & idUser & "'")
            For i = 0 To ParamTbl.Rows.Count - 1
                rs.Open("Select * from Param_General_User where Cod_Param='" & ParamTbl.Rows(i).Item("Cod_Param") & "' and id_User='" & idUser & "'", cn, 2, 2)
                rs.AddNew()
                If IsNull(ParamTbl.Rows(i).Item("Typ_Param_General"), "") = "Ent" Or IsNull(ParamTbl.Rows(i).Item("Typ_Param_General"), "") = "Num" Then
                    rs("Valeur").Value = CDbl(IsNull(ParamTbl.Rows(i).Item("Valeur"), "0").Replace(".", ","))
                Else
                    rs("Valeur").Value = ParamTbl.Rows(i).Item("Valeur")
                End If
                rs("id_User").Value = idUser
                rs("Cod_Param").Value = ParamTbl.Rows(i).Item("Cod_Param")
                rs.Update()
                rs.Close()
            Next
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub
    Private Sub Param_TreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Param_TreeView.AfterSelect
        Request()
    End Sub

    Private Sub ModifierParamTbl()
        Dim oRow() As DataRow
        For i = 0 To Param_GRD.RowCount - 1

            oRow = ParamTbl.Select("[Cod_Param]='" & Param_GRD.Item("Cod_Param", i).Value & "'")

            oRow(0).Item("Valeur") = Param_GRD.Item("Valeur", i).Value

        Next
    End Sub


    Private Sub Param_GRD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Param_GRD.KeyUp
        With Param_GRD
            If .CurrentRow Is Nothing Then Exit Sub
            If e.KeyData = Keys.F6 Then
                If .Item("Typ_Param_General", .CurrentCell.RowIndex).Value = "Dat" Then
                    Appel_Calender(.CurrentCell, Me)
                ElseIf .Item("Typ_Param_General", .CurrentCell.RowIndex).Value = "Mnu" Then
                    Appel_Zoom1(.Item("Mnu", .CurrentCell.RowIndex).Value, .CurrentCell, Me)
                ElseIf .Item("Typ_Param_General", .CurrentCell.RowIndex).Value = "Rub" Then
                    Appel_Zoom("Valeur", "Membre", "Param_Rubriques", "Nom_Controle='" & .Item("Mnu", .CurrentCell.RowIndex).Value & "'", .CurrentCell, Me)
                ElseIf .Item("Typ_Param_General", .CurrentCell.RowIndex).Value = "File" Then
                    Dim OpenFileDialog As New OpenFileDialog
                    OpenFileDialog.InitialDirectory = importPath
                    OpenFileDialog.AutoUpgradeEnabled = False
                    OpenFileDialog.Filter = "Tous les fichiers (*.*)|*.*"
                    If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then
                        importPath = System.IO.Path.GetFullPath(OpenFileDialog.FileName)
                        Dim FileName As String = OpenFileDialog.FileName
                        .Item("Valeur", .CurrentRow.Index).Value = FileName
                    End If
                ElseIf .Item("Typ_Param_General", .CurrentCell.RowIndex).Value = "Path" Then
                    Dim oFolderBrowserDialog As New FolderBrowserDialog
                    oFolderBrowserDialog.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                    If (oFolderBrowserDialog.ShowDialog(Me) = DialogResult.OK) Then
                        Dim Path As String = oFolderBrowserDialog.SelectedPath
                        .Item("Valeur", .CurrentRow.Index).Value = Path
                    End If
                ElseIf .Item("Typ_Param_General", .CurrentCell.RowIndex).Value = "Ser" Then
                    Appel_Zoom("Num_Ser", "Typ_Pie", "Workflow_Pieces", "Typ_Pie='" & .Item(0, .CurrentRow.Index).Value & "' And Cod_Profile='" & theUser.Cod_Profile & "' and Etablir='True' and isnull(Typ_Pie,'')+isnull(Num_Ser,'') in " &
"( select  isnull(Typ_Pie,'')+isnull(Num_Ser,'') from Param_Num_Ser where convert(smalldatetime,isnull(NullIf(Dat_Deb,''),'01/01/2009'))<=getdate() " &
" and  convert(smalldatetime,isnull(NullIf(Dat_Fin,''),'01/01/2040'))>=getdate() )", .Item(2, .CurrentRow.Index), Me)


                End If
            End If
        End With
    End Sub

    Private Sub Param_Grd_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Param_GRD.EditingControlShowing
        With Param_GRD
            If .CurrentCell.ColumnIndex = Valeur.Index Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With Param_GRD
            If .Item("Typ_Param_General", .CurrentCell.RowIndex).Value = "Num" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, False, False, False, False)
            ElseIf .Item("Typ_Param_General", .CurrentCell.RowIndex).Value = "Ent" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, True, True, False, False)
            End If
        End With
    End Sub

#End Region
    Sub Div_First()
        modeDuplication = False
        Try
            Reset()
            If Login_User_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Login_User_Text.Text & "'")
                End If


                Diviseur_First("Controle_Users", "Login_User", "Nom_User+ '  ' + Prenom_User", Login_User_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Div_Back()
        modeDuplication = False
        Try
            Reset()
            If Login_User_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Login_User_Text.Text & "'")
                End If


                Diviseur_Back("Controle_Users", "Login_User", "Nom_User+ '  ' + Prenom_User", Login_User_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Div_Next()
        modeDuplication = False
        Try
            If Login_User_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Login_User_Text.Text & "'")
                End If


                Diviseur_Next("Controle_Users", "Login_User", "Nom_User+ '  ' + Prenom_User", Login_User_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Div_Last()
        modeDuplication = False
        Try
            Reset()
            If Login_User_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Login_User_Text.Text & "'")
                End If

                Diviseur_Last("Controle_Users", "Login_User", "Nom_User+ '  ' + Prenom_User", Login_User_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Nouveau()
        If CnExecuting("select count(Login_User)  from Controle_Users where isnull(Actif,'False')='True'").Fields(0).Value > CDbl(Droits.NbUsers) Then
            MessageBoxRHP(364, Droits.NbUsers)
            Exit Sub
        End If
        Reset_Form(Me)
        Actif_Check.Checked = True
        Mouvemente_Check.Checked = False
        Login_User_Text.ReadOnly = False
        Login_User_Text.Select()
        modeDuplication = True
    End Sub

    Sub Deleting()
        If Login_User_Text.Text <> "" Then
            Diviseur_delete("Controle_Users", "id_User", "Nom_User+ '  ' + Prenom_User", id_User_Text, Me)
        End If
        modeDuplication = False
    End Sub
    Sub Enregister()
        Dim rsl As savingResult = Saving()
        If IsNull(rsl.message, "") <> "" Then ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
        If rsl.result Then Requesting()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Zoom1("MS003", Login_User_Text, Me)
        modeDuplication = False
        Requesting()
    End Sub

    Private Sub Cod_Profile_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Profile_Text.TextChanged
        Lib_Profile_Text.Text = FindLibelle("Lib_Profile", "Cod_Profile", Cod_Profile_Text.Text, "Controle_Profile")
        If Cod_Profile_Text.Text = "1" Then Typ_Role.SelectedValue = "Admin"
    End Sub

    Sub ResetPwd()
        If Login_User_Text.Text = "" Then Exit Sub
        If is_AD_chk.Checked Then
            ShowMessageBox("Ce compte est géré en Active Directory.", "Réinitialisation de mot de passe", MessageBoxButtons.OK)
            Return
        End If
        If MessageBoxRHP(10, Prenom_User_Text.Text & " " & Nom_User_Text.Text) = MsgBoxResult.Cancel Then Exit Sub
        resetPassWord()
    End Sub

    Sub Admin_Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Next_D = dictButtons("Next_D")
        Back_D = dictButtons("Back_D")
        Last_D = dictButtons("Last_D")
        First_D = dictButtons("First_D")
        New_D = dictButtons("New_D")
        Duplik_D = dictButtons("Duplik_D")
        Reset_D = dictButtons("Reset_D")
    End Sub

    Private Sub Login_User_Text_Leave(sender As Object, e As EventArgs) Handles Login_User_Text.Leave
        Dim rg As New System.Text.RegularExpressions.Regex("\W")
        If rg.IsMatch(Login_User_Text.Text) And Not estEmail(Login_User_Text.Text) Then
            MessageBoxRHP(51)
            Enabling(Login_User_Text, True)
            Login_User_Text.Select()
            Exit Sub
        End If
        Enabling(Login_User_Text, False)
        Requesting()
    End Sub
    Private Sub is_AD_chk_Click(sender As Object, e As EventArgs) Handles is_AD_chk.Cliquer
        If is_AD_chk.Checked Then
            Cursor = Cursors.WaitCursor
            If Not ApplyADInfo() Then is_AD_chk.Checked = False
            Cursor = Cursors.Default
        End If
    End Sub
End Class