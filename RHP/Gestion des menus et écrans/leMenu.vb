Public Class leMenu
    Dim _currentEcran As Ecran = Nothing

    Public Property currentEcran As Ecran
        Get
            Return _currentEcran
        End Get
        Set(value As Ecran)
            If value IsNot _currentEcran Then
                _currentEcran = value
                If _currentEcran IsNot Nothing Then
                    _currentEcran.setButtons()
                    Navigator_ud.Path(_currentEcran.Name)
                Else
                    pnl_sideBarL.Controls.Clear()
                    Navigator_ud.Path("")
                End If
            End If
        End Set
    End Property
    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargementMenuSociete()
        Search_txt.innerTextBox.ForeColor = colorBase01
    End Sub
    Sub ChargementMenuSociete()
        Srv_lbl.Text = Split(Split(connectionString, ";")(1), "=")(1).ToUpper
        Db_lbl.Text = DB & " (" & Societe.id_Societe & ")"
        Usr_lbl.Text = theUser.Login
        newShowEcran(Menu_Societes)

        With System_pb
            .Enabled = (Tbl_Controle_Droit_Mnu.Select("Name_Ecran='4' and Visible='true'").Length > 0)
            If Not .Enabled Then .Image = ConvertToTargetColor(.Image, False)
        End With
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, pbchangePwd.Click
        Dim f As New Admin_ChangePwd
        f.ShowDialog()

    End Sub
    Private Sub pbModeAgent_Click(sender As Object, e As EventArgs) Handles pbModeAgent.Click, modeAgent_lbl.Click
        Usr = Tbl_User.Select($"isTheUSer ='true' and Origine='Agent' and Pwd_User='{theUser.Pwd_User}'")
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
            theUser.is_AD = CBool(Usr(0)("TeamLeader"))
            Dim rs41 As New ADODB.Recordset
            rs41.Open("select * from Controle_Users_Process", cn, 2, 2)
            rs41.AddNew()
            rs41("Login_User").Value = theUser.Login
            rs41("Interface").Value = "Portail"
            rs41("Nom_User").Value = theUser.Nom
            rs41("hostname").Value = My.Computer.Name
            rs41("Process_Id").Value = System.Diagnostics.Process.GetCurrentProcess().Id
            rs41("Dat").Value = Now
            rs41.Update()
            rs41.Close()
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
                .Text = Me.Text
                .Show()
                Me.Hide()
            End With
        Else
            If Login Is Nothing OrElse Login.IsDisposed Then
                Login = New Login()
            End If

            With Login
                ' .TopLevel = True
                '  .TopMost = True
                .Visible = True
                .Opacity = 1
                .Default_Interface_switch.Value = True
                .Show()
            End With
            Me.Hide()
        End If
    End Sub
    Private Sub Déconnexion_Click(sender As Object, e As EventArgs) Handles Déconnexion.Click, pblogout.Click
        If ShowMessageBox("Etes-vous sûr de vouloir vous déconnecter?", "Déconnexion", MessageBoxButtons.OKCancel, msgIcon.Question) = MsgBoxResult.Cancel Then Return
        ClearSecureRememberMe()
        Me.Close()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, pbParapheur.Click
        Dim f As New Agent_Parapheur
        newShowEcran(f, True)
    End Sub
    Private Sub Personnel_pb_Click(sender As Object, e As EventArgs) Handles Personnel_pb.Click
        If Personnal_pnl.Visible Then Return
        Dim oTmr As New Timer
        Dim nbCollapsing = 0
        Dim buttonScreenLocation = getPositionToScreen(Personnel_pb, Me)
        Dim menuX = buttonScreenLocation.X - Personnal_pnl.Width + Personnel_pb.Width + 5
        Dim menuY = buttonScreenLocation.Y + Personnel_pb.Height

        Dim maxHeight = 134
        With Personnal_pnl
            .Location = New Point(menuX, menuY)
            .Height = 1
            .Visible = True
            .BringToFront()
        End With
        With oTmr
            .Start()
            .Interval = 3
            AddHandler .Tick, Sub()
                                  If Personnal_pnl.Height < maxHeight Then
                                      Personnal_pnl.Height += 10
                                  ElseIf nbCollapsing < 150 Then
                                      nbCollapsing += 1
                                  Else
                                      .Stop()
                                      .Dispose()
                                      Personnel_pb_Collapse()
                                  End If
                              End Sub
        End With
    End Sub
    Private Sub Personnel_pb_Collapse()
        If Not Personnal_pnl.Visible Then Return
        Dim oTmr As New Timer
        Dim maxHeight = 134
        With oTmr
            .Start()
            .Interval = 3
            AddHandler .Tick, Sub()
                                  If Personnal_pnl.Height > 10 Then
                                      Personnal_pnl.Height -= 10
                                  Else
                                      Personnal_pnl.Visible = False
                                      .Stop()
                                      .Dispose()
                                  End If
                              End Sub
        End With
    End Sub
    Private Sub Personnal_pnl_Leave(sender As Object, e As EventArgs) Handles Personnal_pnl.Leave
        Personnel_pb_Collapse()
    End Sub
#Region "Navigation"
#End Region
#Region "Searching"
    Private Sub Search_txt_KeyUp(sender As Object, e As KeyEventArgs) Handles Search_txt.KeyUp
        If e.KeyCode = Keys.Enter Then
            Searching()
        End If
    End Sub
    Sub Searching()
        If pnl_PersonnalContent.Controls.Count = 0 Then
            newShowEcran(Menu_Societes)
        End If
        If currentEcran Is Nothing Then currentEcran = pnl_PersonnalContent.Controls(0)
        If currentEcran.Name = Menu_Societes.Name Then
            If IsNumeric(Search_txt.Text) Then
                CType(currentEcran, Menu_Societes).Generer_Societe(" (Den like '%" & Search_txt.Text & "%' or id_Societe = '" & Search_txt.Text & "')")
            Else
                CType(currentEcran, Menu_Societes).Generer_Societe(" (Den like '%" & Search_txt.Text & "%')")
            End If
        ElseIf currentEcran.Name = Menu_Operationnel.Name Then
            With CType(currentEcran, Menu_Operationnel)
                .Trv.Nodes(0).Nodes.Clear()
                'If nrw.Length = 0 Then
                '    .selectingModule(.seletedModule)
                'End If
            End With
            Dim nrw() As DataRow = Tbl_Controle_Droit_Mnu.Select(" (Text_Ecran like '%" & Search_txt.Text & "%' or Name_Ecran = '" & Search_txt.Text & "')")
            Dim sMenus As String = String.Join("','", nrw.Select(Function(x) x("Name_Ecran")).ToArray())
            If sMenus <> "" Then
                Dim trw() = Tbl_Controle_TreeView.Select("Name_Ecran in ('" & sMenus & "')")
                If trw.Length > 0 Then
                    Dim racines As String = String.Join("','", String.Join(";", trw.Select(Function(x) x("Racine")).ToArray()).Split({";"}, StringSplitOptions.RemoveEmptyEntries))
                    If racines <> "" Then
                        Dim rsl() = Tbl_Controle_Droit_Mnu.Select("Name_Ecran in ('" & racines & "')")
                        If rsl.Length > 0 Then
                            Dim TblResult As DataTable = rsl.CopyToDataTable
                            searchingTrv(CType(currentEcran, Menu_Operationnel).Trv.Nodes(0), TblResult, 5)
                            CType(currentEcran, Menu_Operationnel).Trv.Nodes(0).ExpandAll()
                        End If
                    End If

                End If
            End If
        ElseIf currentEcran.Name = Menu_System.Name Then
            With CType(currentEcran, Menu_System)
                .Trv.Nodes(0).Nodes.Clear()
            End With
            Dim nrw() As DataRow = Tbl_Controle_Droit_Mnu.Select(" (Text_Ecran like '%" & Search_txt.Text & "%' or Name_Ecran = '" & Search_txt.Text & "')")
            Dim sMenus As String = String.Join("','", nrw.Select(Function(x) x("Name_Ecran")).ToArray())
            If sMenus <> "" Then
                Dim trw() = Tbl_Controle_TreeView.Select("Name_Ecran in ('" & sMenus & "') and Racine like '4%'")
                If trw.Length > 0 Then
                    Dim racines As String = String.Join("','", String.Join(";", trw.Select(Function(x) x("Racine")).ToArray()).Split({";"}, StringSplitOptions.RemoveEmptyEntries))
                    If racines <> "" Then
                        Dim rsl() = Tbl_Controle_Droit_Mnu.Select("Name_Ecran in ('" & racines & "')")
                        If rsl.Length > 0 Then
                            Dim TblResult As DataTable = rsl.CopyToDataTable
                            searchingTrv(CType(currentEcran, Menu_System).Trv.Nodes(0), TblResult, 2)
                            CType(currentEcran, Menu_System).Trv.Nodes(0).ExpandAll()
                        End If
                    End If

                End If
            End If
        End If
        Search_pb.Image = If(Search_txt.Text = "", My.Resources.btn_search, ConvertToTargetColor(My.Resources.btn_search, True))
    End Sub
    Sub searchingTrv(nd As TreeNode, tblRsl As DataTable, imgInd As Integer)
        Dim nrw() As DataRow = tblRsl.Select("[Parent]='" & If(nd.Name = "Nd", "", nd.Name) & "'", "Rang Asc")
        For i = 0 To nrw.Length - 1
            Dim _nd As New TreeNode
            With _nd
                .Name = nrw(i)("Name_Ecran")
                .Text = nrw(i)("Text_Ecran")
                .Tag = nrw(i)("Typ_Ecran")
                Dim crw() As DataRow = tblRsl.Select("[Parent]='" & _nd.Name & "'", "Rang Asc")
                .ForeColor = If(crw.Length > 0, colorBase01, Color.Gray)
                .ToolTipText = nrw(i)("Text_Ecran")
                .ImageIndex = imgInd + Array.IndexOf("FDR;ECR;QRY;RPT".Split(";"), nrw(i)("Typ_Ecran"))
                .SelectedImageIndex = .ImageIndex
                If crw.Length > 0 Then
                    searchingTrv(_nd, tblRsl, imgInd)
                End If
            End With

            nd.Nodes.Add(_nd)
        Next
    End Sub
    Private Sub Search_pb_Click(sender As Object, e As EventArgs) Handles Search_pb.Click
        Searching()
    End Sub
#End Region
#Region "Footer"
    Private Sub Srv_lbl_DockChanged(sender As Object, e As EventArgs) Handles Srv_lbl.SizeChanged
        Dim _delta As Integer = Srv_lbl.Width
        DB_pb.Location = New Point(DB_pb.Location.X + _delta, DB_pb.Location.Y)
        Db_lbl.Location = New Point(Db_lbl.Location.X + _delta, Db_lbl.Location.Y)
        Usr_pb.Location = New Point(Usr_pb.Location.X + _delta, Usr_pb.Location.Y)
        Usr_lbl.Location = New Point(Usr_lbl.Location.X + _delta, Usr_lbl.Location.Y)
    End Sub

    Private Sub Db_lbl_SizeChanged(sender As Object, e As EventArgs) Handles Db_lbl.SizeChanged
        Dim _delta As Integer = Db_lbl.Width
        Usr_pb.Location = New Point(Usr_pb.Location.X + _delta, Usr_pb.Location.Y)
        Usr_lbl.Location = New Point(Usr_lbl.Location.X + _delta, Usr_lbl.Location.Y)
    End Sub

    Private Sub Setting_pb_Click(sender As Object, e As EventArgs) Handles System_pb.Click
        For i = pnl_PersonnalContent.Controls.Count - 1 To 0 Step -1
            If Not pnl_PersonnalContent.Controls(i).GetType Is GetType(Menu_Societes) Then
                CType(pnl_PersonnalContent.Controls(i), Ecran).Close()
            End If
        Next
        If pnl_PersonnalContent.Controls.Count = 0 Then newShowEcran(Menu_Societes)
        If pnl_PersonnalContent.Controls(0) Is Menu_System Then
            Return
        ElseIf pnl_PersonnalContent.Controls.Contains(Menu_System) Then
            Menu_System.BringToFront()
            currentEcran = Menu_System
        Else
            newShowEcran(Menu_System)
        End If

    End Sub

    Private Sub Home_pb_Click(sender As Object, e As EventArgs) Handles Home_pb.Click
        For i = pnl_PersonnalContent.Controls.Count - 1 To 0 Step -1
            If Not pnl_PersonnalContent.Controls(i).GetType Is GetType(Menu_Societes) Then
                CType(pnl_PersonnalContent.Controls(i), Ecran).Close()
            End If
        Next
        If pnl_PersonnalContent.Controls.Count = 0 Then newShowEcran(Menu_Societes)
        If pnl_PersonnalContent.Controls(0) Is Menu_Societes Then
            Return
        ElseIf pnl_PersonnalContent.Controls.Contains(Menu_Societes) Then
            Menu_Societes.BringToFront()
            currentEcran = Menu_Societes
        Else
            newShowEcran(Menu_Societes)
        End If

    End Sub

    Private Sub pb_logo_Click(sender As Object, e As EventArgs) Handles pb_logo.Click
        Zoom_Apropos_Lic.ShowDialog()
    End Sub

    Private Sub leMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Application.Exit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub leMenu_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Wait.fadeTimer.Start()
    End Sub

    Private Sub leMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If ShowMessageBox("Voulez-vous vraiment quitter l'application ?", "Fermeture", MessageBoxButtons.YesNo, msgIcon.Question) = MsgBoxResult.No Then
                e.Cancel = True
                Return
            End If
        End If

        Quitter(Me)
    End Sub
#End Region
End Class