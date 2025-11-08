Public Class Menu_Agent
    Dim Tbl_Controle_Menu As DataTable = DATA_READER_GRD("select * from Controle_Menu where Typ_Ecran='ECR'")
    Private Sub Menu_Agent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Trv_MonEspace.Nodes(0).Text = Societe.Denomination
        Trv_MonEspace.ExpandAll()
        With infoAccueil_lbl
            .Text = "Bonjour " & theUser.Nom
            Dim fn = FindLibelle("Lib_Poste", "Cod_Poste", theUser.Cod_Poste, "Org_Poste")
            Dim et = FindLibelle("Lib_Entite", "Cod_Entite", theUser.Cod_Entite, "Org_Entite")
            .Text &= IIf(theUser.Matricule <> "", vbCrLf & theUser.Matricule & vbCrLf, "")
            .Text &= IIf(fn <> "", vbCrLf & fn & vbCrLf, "")
            .Text &= IIf(et <> "", vbCrLf & et & vbCrLf, "")
        End With
        Dim otm As New Timer
        Dim nbr As Long = 0
        Dim txt = "Mon parapheur de signatures"
        With otm
            .Interval = 5000
            AddHandler .Tick, Sub()
                                  nbr += 1
                                  Try
                                      Dim nb As Integer = CnExecuting("select count(*) from dbo.Sys_Parapheur_Signature('" & theUser.Matricule & "','" & Societe.id_Societe & "')").Fields(0).Value
                                      If nb > 0 Then
                                          With Agent_Parapheur
                                              .ForeColor = If(nbr Mod 2 = 1, Color.Red, Trv_MonEspace.ForeColor)
                                              txt = "Mon parapheur de signatures (" & nb & ")"
                                          End With
                                      Else
                                          With Agent_Parapheur
                                              .ForeColor = Trv_MonEspace.ForeColor
                                          End With
                                      End If
                                      If Agent_Parapheur.Text <> txt Then Agent_Parapheur.Text = txt
                                  Catch ex As Exception

                                  End Try
                              End Sub
            .Start()
        End With
    End Sub
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim tabControl As TabControl = CType(sender, TabControl)
        Dim tabPage As TabPage = tabControl.TabPages(e.Index)
        Dim tabText As String = tabPage.Text
        Dim stringSize As SizeF = e.Graphics.MeasureString(tabText, tabControl.Font)

        ' Définissez la position Y pour centrer le texte verticalement
        Dim yPos As Single = (e.Bounds.Height - stringSize.Height) / 2
        e.Graphics.DrawString(tabText, tabControl.Font, Brushes.Black, e.Bounds.Left, yPos)

        ' Si vous voulez dessiner un fond pour l'onglet
        e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds)
    End Sub
    Private Sub Trv_MonEspace_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Trv_MonEspace.NodeMouseDoubleClick
        If e.Node.Nodes.Count = 0 Then
            If "Admin_ChangePwd_Agent;".Split({";"}, StringSplitOptions.RemoveEmptyEntries).Contains(e.Node.Name) Then
                Dim frm = GetFormByName(e.Node.Name)
                newShowEcran(frm, True)
            ElseIf e.Node.Name = "onMeValue" Then
                Dim f As New Evaluation_Liste
                With f
                    newShowEcran(f, False)
                    .Evaluateur_txt.Text = ""
                    .Evalue_txt.Text = theUser.Matricule
                    .Requesting()
                End With
            ElseIf e.Node.Name = "JeValue" Then
                Dim f As New Evaluation_Liste
                With f
                    newShowEcran(f, False)
                    .Evalue_txt.Text = ""
                    .Evaluateur_txt.Text = theUser.Matricule
                    .Requesting()
                End With
            Else
                Dim frm = GetFormByName(e.Node.Name)
                newShowEcran(frm, False)
            End If
            chemin_lbl.Text = IIf(e.Node.Name = Agent_Parapheur.Name, "Mon parapheur de signatures", e.Node.Text)
            chemin_lbl.Refresh()
        End If
    End Sub

    Private Sub pb_Close_Click(sender As Object, e As EventArgs)
        If ShowMessageBox("Etes-vous sûr de vouloir quitter votre session?", "Quitter", MessageBoxButtons.OKCancel, msgIcon.Warning) = MsgBoxResult.Cancel Then Return
        Me.Close()
    End Sub
    Private Sub Déconnexion_Click(sender As Object, e As EventArgs) Handles Déconnexion.Click, pblogout.Click
        If ShowMessageBox("Etes-vous sûr de vouloir vous déconnecter?", "Déconnexion", MessageBoxButtons.OKCancel, msgIcon.Question) = MsgBoxResult.Cancel Then Return
        ClearSecureRememberMe()
        Me.Close()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, pbParapheur.Click
        Dim f As New Agent_Parapheur
        newShowEcran(f, False)
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, pbchangePwd.Click
        Dim f As New Admin_ChangePwd_Agent
        newShowEcran(f, True)
    End Sub
    Private Sub pdPeronnel_Click(sender As Object, e As EventArgs) Handles Personnel_pb.Click
        If Personnal_pnl.Visible Then Return
        Dim oTmr As New Timer
        Dim nbCollapsing = 0
        Dim buttonScreenLocation = getPositionToScreen(Personnel_pb, Me)
        Dim menuX = buttonScreenLocation.X - Personnal_pnl.Width + Personnel_pb.Width + 5
        Dim menuY = ent_pnl.Height + 2

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
    Private Sub leMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If ShowMessageBox("Voulez-vous vraiment quitter l'application ?", "Fermeture", MessageBoxButtons.YesNo, msgIcon.Question) = MsgBoxResult.No Then
                e.Cancel = True
                Return
            End If
        End If

        Quitter(Me)
    End Sub
End Class