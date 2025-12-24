Public Class Admin_Superviseur
    Friend Code As String = ""
    Dim idProcessus As Integer
    Private Sub Loading(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Request()

    End Sub
    Sub Request()
        idProcessus = System.Diagnostics.Process.GetCurrentProcess().Id
        oProcess_lbl.Text = "Connectés au Serveur, Processus du Programme en cours : " & idProcessus
        oProcess_lbl.Refresh()
        Dim Cod_Sql1 As String = "SELECT     Name_Ecran AS 'Nom Ecran'," &
                       " (SELECT     Text_Ecran " &
     " FROM Controle_Menu " &
                         " WHERE      (Name_Ecran = f.Name_Ecran)) AS 'Titre Ecran', Value AS 'Valeur Ecran',Process_Id as 'Process Id', Taken_By_User AS 'Code Utilisateur'," &
                       " (SELECT     Nom_User" &
      " FROM Controle_Users WHERE      (id_User = f.Taken_By_User)) AS 'Nom Utilisateur', Taken_By_Machine AS 'Nom de la Machine', Date_Deb " &
" FROM         Controle_Access AS f "
        GRD(Cod_Sql1, Superviseur_Grd)

        Dim Cod_Sql2 As String = "select distinct rtrim(hostname) as 'Nom de la Machine',rtrim(hostprocess) as 'Id Processus', o.Utilisateur,rtrim(status) as 'Etat' from sys.sysprocesses f " &
        " Cross Apply (select Nom_User as Utilisateur from Controle_Users_Process where Process_Id=f.hostprocess) o " &
        " where rtrim(program_name)='RHP'"

        GRD(Cod_Sql2, Processes_Grd)

        Dim oMenu3 As New ToolStripMenuItem
        Dim oMenu4 As New ToolStripMenuItem
        With oMenu3
            .Text = "Mettre fin au Processus"
            AddHandler oMenu3.Click, AddressOf KillingProcesses
        End With
        Processes_Grd.ContextMenuStrip.Items.Insert(0, oMenu3)

        With oMenu4
            .Text = "Libérer l'écran"
            .Image = My.Resources.Functionality_small
            AddHandler oMenu4.Click, AddressOf MakeEcranFree
        End With
        Superviseur_Grd.ContextMenuStrip.Items.Insert(0, oMenu4)

    End Sub

    Sub KillingProcesses(ByVal sender, ByVal e)

        Try
            With CType(sender.getcurrentparent.sourcecontrol, DataGridView)
                If .CurrentRow Is Nothing Then Exit Sub
                If .CurrentRow.Index < 0 Then Exit Sub
                If .RowCount = 0 Then Exit Sub

                If .Item("Id Processus", .CurrentRow.Index).Value = idProcessus Then
                    MessageBoxRHP(356)
                    Exit Sub
                End If

                Dim user As String = IsNull(.Item("Utilisateur", .CurrentRow.Index).Value, "")
                If user <> "" Then
                    If MessageBoxRHP(5, user) = MsgBoxResult.Cancel Then Exit Sub
                Else
                    If MessageBoxRHP(6) = MsgBoxResult.Cancel Then Exit Sub
                End If

                CnExecuting("exec KillProcess " & .Item("Id Processus", .CurrentRow.Index).Value & ",'" & .Item("Nom de la Machine", .CurrentRow.Index).Value & "'")
                Request()

            End With

        Catch ex As Exception
            ErrorMsg(ex)
        End Try


        'Dim Name_Ecran, Valeur As String
        'With sender.getcurrentparent.sourcecontrol
        'Name_Ecran = .item("Nom Ecran", .currentrow.index).value
        'Valeur = .item("Valeur Ecran", .currentrow.index).value

        '        End With

        'Détecter l'Adresse IP 
        '       Dim ipEntry As IPHostEntry = Dns.GetHostEntry(Name_Ecran)
        '      Dim IpAddr As IPAddress() = ipEntry.AddressList
        '     Dim i As Integer = 0
        '    Do While i < IpAddr.Length

        'i += 1
        'Loop



        'ceci supprimera tous les processus de ce nom (voir exemple)
        ' Dim p() As Process
        'Dim r As Process
        'p = Process.GetProcessesByName(NomDuProcessus, Ip)
        'For Each r In p
        'r.CloseMainWindow()
        '  r.Kill()
        '  Next

        'Exemple()
        'KillProcessus("Excel", Ip)
        'KillProcessus fermera toutes les instances d'excel ouvertes
    End Sub

    Sub MakeEcranFree(ByVal sender, ByVal e)
        Try
            Dim Name_Ecran, Valeur As String
            With sender.getcurrentparent.sourcecontrol
                If .CurrentRow Is Nothing Then Exit Sub
                Name_Ecran = .item("Nom Ecran", .currentrow.index).value
                Valeur = .item("Valeur Ecran", .currentrow.index).value

            End With
            CnExecuting("delete from Controle_Access where Name_Ecran='" & Name_Ecran & "' and Value='" & Valeur & "'")
            Request()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

End Class