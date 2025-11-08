Imports System.ComponentModel
Imports Microsoft.VisualBasic.Logging

Public Class RHPServerManager
    Public Structure prosConn
        Public estConnecte As Int16
        Public connString As String
    End Structure
    Friend WithEvents oTimer, connLoadingTimer As New Timer
    Friend dicRHP As New Dictionary(Of String, RHP)
    Friend dicConn As New Dictionary(Of String, prosConn)
    Friend WithEvents BKG_Conn As New System.ComponentModel.BackgroundWorker
    Dim BKG_Conn_isBusy As Boolean = False
    Dim fermetureForcee As Boolean = False
    Dim avancementStr As String = ""
    Private lastLogUpdate As DateTime = DateTime.MinValue
    Private isTimerProcessing As Boolean = False
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If fermetureForcee Then Return
        MasquerManager()
        e.Cancel = True
    End Sub
    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        fermetureForcee = True
        Me.Close()
        Application.Exit()
    End Sub
    Private Sub RHPServerManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon1.ContextMenuStrip = ContextMenuStrip1
        MasquerManager()
        With TblLog
            .Columns.Add("Date", GetType(DateTime))
            .Columns.Add("Connection")
            .Columns.Add("Commentaire")
        End With

        Dim path As String = "..\login\Login.ini"
        Dim k As Integer = 0
        If IO.File.Exists(path) Then
            Dim SR As New IO.StreamReader(path)
            Do Until SR.Peek = -1
                Dim str As String = Decrypt(SR.ReadLine)
                Dim ConnName As String = Split(Split(str, "@")(0), ":=")(1)
                Dim ConnString As String = Split(Split(str, "@")(1), ":=")(1)
                dicConn.Add(ConnName, New prosConn With {.connString = ConnString, .estConnecte = 0})
                Conn_lst.Items.Add(New ListViewItem With {.Text = ConnName, .Name = ConnName, .Tag = ConnString, .ImageIndex = 0})
            Loop
            SR.Close()
        Else
            MsgBox("Fichier Login.ini inexistent au chemin indiqué : '" & path & "'", True)
        End If
        With oTimer
            .Interval = 1000
            .Start()
        End With
        If Not BKG_Conn_isBusy Then BKG_Conn.RunWorkerAsync()
        Cursor = Cursors.WaitCursor
        With connLoadingTimer
            .Interval = 1000
            AddHandler .Tick, Sub()
                                  If BKG_Conn_isBusy Then
                                      Me.Text = avancementStr
                                      For Each itm As ListViewItem In Conn_lst.Items
                                          itm.ImageIndex = dicConn(itm.Name).estConnecte
                                      Next
                                  Else
                                      Me.Text = "RHP Server Manager"
                                      Cursor = Cursors.Default
                                      .Stop()
                                  End If

                              End Sub
            .Start()
        End With

    End Sub
    Dim isProcessing As Boolean = False
    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        If isTimerProcessing Then Return

        Try
            isTimerProcessing = True

            ' Traitement des connexions (inchangé)
            For Each elt In dicConn
                If elt.Value.estConnecte = 2 Then
                    Try
                        If dicRHP.ContainsKey(elt.Key) Then
                            With dicRHP(elt.Key)
                                If Not .Busy_Param AndAlso Not .BKG_Param.IsBusy Then
                                    .BKG_Param.RunWorkerAsync()
                                End If
                                If Not .Busy_Notif AndAlso Chk_Notif.Checked AndAlso Not .BKG_Notif.IsBusy Then
                                    .BKG_Notif.RunWorkerAsync()
                                End If
                                If Not .Busy_Mailing AndAlso chk_Mailing.Checked AndAlso Not .BKG_Mailing.IsBusy Then
                                    .BKG_Mailing.RunWorkerAsync()
                                End If
                            End With
                        End If
                    Catch ex As Exception
                        WriteLog("Erreur processing connection " & elt.Key & ": " & ex.Message, "Timer", True)
                    End Try
                End If
            Next

            ' CORRECTIF: Mise à jour des logs moins fréquente et plus sûre
            If DateTime.Now.Subtract(lastLogUpdate).TotalSeconds >= 2 Then
                lastLogUpdate = DateTime.Now
                UpdateLogDisplay()
            End If

            ' Nettoyage des fichiers (inchangé mais protégé)
            CleanupFiles()

        Catch ex As Exception
            WriteLog("Erreur critique timer: " & ex.Message, "Timer", True)
        Finally
            isTimerProcessing = False
        End Try
    End Sub
    Private Sub UpdateLogDisplay()
        Try
            ' Vérifier qu'on est sur l'onglet Log OU qu'on veut forcer la mise à jour
            If TabControl1.SelectedTab Is TabPage2 OrElse Conn_lst.SelectedItems.Count > 0 Then

                SyncLock Module_General.logLock  ' Même verrou que WriteLog
                    If TblLog IsNot Nothing AndAlso TblLog.Rows.Count > 0 Then
                        Dim selectedConnectionName As String = ""
                        If Conn_lst.SelectedItems.Count > 0 Then
                            selectedConnectionName = Conn_lst.SelectedItems(0).Name
                        End If

                        If Not String.IsNullOrEmpty(selectedConnectionName) Then
                            ' Créer une copie des données pour éviter les conflits
                            Dim filteredData As New DataTable()
                            filteredData.Columns.Add("Date", GetType(DateTime))
                            filteredData.Columns.Add("Connection", GetType(String))
                            filteredData.Columns.Add("Commentaire", GetType(String))

                            Dim count As Integer = 0
                            For Each row As DataRow In TblLog.Rows
                                If count >= 100 Then Exit For
                                If row("Connection").ToString() = selectedConnectionName Then
                                    filteredData.ImportRow(row)
                                    count += 1
                                End If
                            Next

                            ' Mise à jour thread-safe de la grille
                            If Me.InvokeRequired Then
                                Me.Invoke(Sub()
                                              Try
                                                  Grd_Log.DataSource = filteredData
                                                  FormatLogGrid()
                                              Catch
                                                  Grd_Log.DataSource = Nothing
                                              End Try
                                          End Sub)
                            Else
                                Grd_Log.DataSource = filteredData
                                FormatLogGrid()
                            End If
                        End If
                    End If
                End SyncLock
            End If
        Catch ex As Exception
            WriteLog($"Erreur UpdateLogDisplay: {ex.Message}", "Timer", True)
            Try
                Grd_Log.DataSource = Nothing
            Catch
                ' Ignorer si on ne peut pas vider la grille
            End Try
        End Try
    End Sub

    Private Sub FormatLogGrid()
        Try
            With Grd_Log
                If .Columns.Count >= 3 Then
                    .Columns("Date").Width = 150
                    .Columns("Connection").Width = 200
                    .Columns("Commentaire").AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill
                End If
            End With
        Catch
            ' Ignorer les erreurs de formatage
        End Try
    End Sub

    Private Sub CleanupFiles()
        Try
            For i = FileToDelete.Count - 1 To 0 Step -1
                Try
                    If IO.File.Exists(FileToDelete(i)) Then
                        IO.File.Delete(FileToDelete(i))
                        FileToDelete.RemoveAt(i)
                    End If
                Catch
                    ' Ignorer les erreurs de suppression individuelles
                End Try
            Next
        Catch
            ' Ignorer les erreurs globales de nettoyage
        End Try
    End Sub
    Sub ChargerConn()
        Dim k As Integer = 0
        Dim total As Integer = dicConn.Keys.Count

        ' Créer une liste des clés pour éviter la modification pendant l'itération
        Dim listeClés As New List(Of String)(dicConn.Keys)

        For Each clé As String In listeClés
            k += 1
            avancementStr = "Tentative de connexion : (" & clé & "), Avancement : " & k & "/" & total
            Dim vers As String = ""
            Dim leLog As String = ""
            Dim ocn As New ADODB.Connection
            Dim ConnString As String = dicConn(clé).connString
            Dim tempConn As prosConn = dicConn(clé)
            ocn.ConnectionString = ConnString

            Try
                ocn.ConnectionTimeout = 2
                ocn.Open()
                vers = ocn.Execute("select Valeur from Param_General where Cod_Param='Version'").Fields(0).Value
                If vers <> NumVersion Then Throw New System.Exception("Conflit de version : " & vers & " vs " & NumVersion)

                Dim ray As New RHP
                With ray
                    .name = clé
                    .srv = ConnString.Split(";")(1).Split("=")(1).Trim
                    .db = ConnString.Split(";")(2).Split("=")(1).Trim
                    .sqluser = ConnString.Split(";")(3).Split("=")(1).Trim
                    .pw = ConnString.Split(";")(4).Split("=")(1).Trim
                    .cntstr = ConnString
                End With
                ray.Intialisation()
                dicRHP.Add(clé, ray)
                tempConn.estConnecte = 2
                leLog = "Connexion réussie"

            Catch ex As Exception
                tempConn.estConnecte = 1
                leLog = ex.Message
            Finally
                ' Mise à jour en dehors du Try/Catch pour s'assurer qu'elle se fait toujours
                dicConn(clé) = tempConn
                Try
                    If ocn.State = ADODB.ObjectStateEnum.adStateOpen Then ocn.Close()
                Catch
                    ' Ignorer les erreurs de fermeture
                End Try
            End Try

            WriteLog("Chargement de l'instance RHP : " & vbCrLf & leLog, clé, True)
        Next
    End Sub
    Sub BKG_Notif_Run(sender As Object, e As DoWorkEventArgs) Handles BKG_Conn.DoWork
        Try
            BKG_Conn_isBusy = True
            ChargerConn()
        Catch ex As Exception
            WriteLog("Erreur BKG_Notif: " & ex.Message, Name, True)
        Finally
            BKG_Conn_isBusy = False
        End Try
    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        AfficherManager()
    End Sub
    Private Sub OuvrirRHPServerManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirRHPServerManagerToolStripMenuItem.Click
        AfficherManager()
    End Sub
    Sub MasquerManager()
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
    End Sub
    Sub AfficherManager()
        Me.Visible = True
        If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
        Me.Visible = True
        Me.Activate()
        Me.Visible = True

    End Sub
    Sub Request(Conn As String)
        Try
            ' Vérifications préalables
            If String.IsNullOrEmpty(Conn) Then Return
            If Not dicConn.ContainsKey(Conn) Then Return
            If dicConn(Conn).estConnecte <> 2 Then Return

            Dim SqlAbn As String = String.Format("select '{0}' as Connection,Source_Abonnement as [Source],'ABN-'+convert(nvarchar(10),Cod_Abonnement) as Code, Lib_Abonnement as Intitulé,  
Ref_Abonnement as Référence,Typ_Frequence as 'Type fréquence', Frequence as 'Fréquence', Dat_Next 'Exécution prochaine' 
from Param_Abonnement where Actif=1 and Typ_Pie_Abonnement='EML'", Conn)

            Dim SqlNotif As String = String.Format("select '{0}' as Connection,Cod_Notification as 'Code', Table_Ref as 'Table', Creation, Modification, Suppression, Destinataires,Interne, Externe, Agenda
 from Notifications where Actif=1", Conn)

            ' Vérification de santé avant les requêtes
            If Not dicRHP(Conn).IsConnectionHealthy() Then
                WriteLog($"Connexion {Conn} malsaine - abandon Request", "Request", True)
                Return
            End If

            ' Mise à jour des grilles avec gestion d'erreurs
            Try
                With Grd_Abn
                    .DataSource = DATA_READER_GRD(SqlAbn, dicConn(Conn).connString)
                End With
            Catch ex As Exception
                WriteLog($"Erreur chargement abonnements pour {Conn}: {ex.Message}", "Request", True)
                Grd_Abn.DataSource = Nothing
            End Try

            Try
                With Grd_Notif
                    .DataSource = DATA_READER_GRD(SqlNotif, dicConn(Conn).connString)
                End With
            Catch ex As Exception
                WriteLog($"Erreur chargement notifications pour {Conn}: {ex.Message}", "Request", True)
                Grd_Notif.DataSource = Nothing
            End Try

        Catch ex As Exception
            WriteLog($"Erreur Request pour {Conn}: {ex.Message}", "Request", True)
        End Try
    End Sub

    Private Sub Conn_lst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Conn_lst.SelectedIndexChanged
        With Conn_lst
            If .Items.Count = 0 Then Return
            If .SelectedItems.Count > 0 Then Request(.SelectedItems(0).Name)
        End With
    End Sub

    Private Sub BKG_Conn_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_Conn.RunWorkerCompleted
        BKG_Conn_isBusy = False
        For Each itm As ListViewItem In Conn_lst.Items
            itm.ImageIndex = dicConn(itm.Name).estConnecte
        Next
    End Sub
End Class
