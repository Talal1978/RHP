Public Class Login_Connection
    Dim seSouvenir As Boolean = False
    Friend frmLogin As New Login
    Dim rg As New System.Text.RegularExpressions.Regex("[^\W]+", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    Private Sub Close_D_Click(sender As Object, e As EventArgs) Handles Close_D.Click
        Dim fadeInTimer As New Timer()
        fadeInTimer.Interval = 50 ' Adjust as needed
        AddHandler fadeInTimer.Tick, Sub(senderO, eO)
                                         Me.Opacity -= 0.1
                                         If Me.Opacity <= 0 Then
                                             fadeInTimer.Stop()
                                             Me.Close()
                                         End If
                                     End Sub
        fadeInTimer.Start()
    End Sub
    Private Sub pb_cbo_Click(sender As Object, e As EventArgs) Handles pb_cbo.Click
        Connection_lb.Visible = Not Connection_lb.Visible
        If Conn_txt.Text.Trim <> "" Then
            frmLogin.connDic.Remove(Conn_txt.Text)
            If frmLogin.connDic.Count > 0 Then
                Conn_txt.Text = frmLogin.connDic.Keys(0)
            Else
                IO.File.Delete(My.Application.Info.DirectoryPath & "\login\Login.ini")
                Reset_Form(Me)
            End If
        End If
    End Sub
    Private Sub Connection_lb_Click(sender As Object, e As EventArgs) Handles Connection_lb.Click
        If Connection_lb.SelectedItems.Count > 0 Then
            Conn_txt.Text = Connection_lb.SelectedItem
            Connection_lb.Visible = False
        End If
    End Sub
    Private Sub login_lbl_Click(sender As Object, e As EventArgs) Handles login_lbl.Click
        Saving()
        ShowLogIn()
    End Sub
    Sub Saving()
        If Conn_txt.Text = "" Then
            ShowMessageBox("Veuillez choisir un nom de connection")
            Conn_txt.Select()
            Return
        End If
        If Srv_txt.Text = "" Then
            ShowMessageBox("Serveur Sql non renseigné")
            Return
        End If

        If User_txt.Text = "" Or Pwd_txt.Text = "" Then
            ShowMessageBox("Identificateur Serveur Sql non renseigné")
            Return
        End If

        If User_txt.Text.Contains("@") Or Db_txt.Text.Contains("@") _
        Or Srv_txt.Text.Contains("@") Or Conn_txt.Text.Contains("@") Then
            ShowMessageBox("Evitez d'utiliser le caractère '@'")
            Return
        End If

        Try
            Dim cn1 As New ADODB.Connection
            cn1.ConnectionString = "Provider=SQLOLEDB;data source=" & Srv_txt.Text & ";initial catalog=master;user id=" & User_txt.Text & ";Password=" & Pwd_txt.Text
            cn1.Open()
            Dim Nb As Integer = cn1.Execute("Select count(*) from sysdatabases where name='" & Db_txt.Text & "'").Fields(0).Value
            cn1.Close()
            If Nb = 0 Then
                ShowMessageBox("Erreur base de données")
                Return
            End If
        Catch ex As Exception
            ShowMessageBox("Eléments de connection erronés")
            Return
        End Try
        If frmLogin.connDic.ContainsKey(Conn_txt.Text) Then
            frmLogin.connDic(Conn_txt.Text) = New Login.connS With {
                 .srv = Srv_txt.Text, .db = Db_txt.Text, .usr = User_txt.Text, .pwd = Pwd_txt.Text, .connStr = "Provider=SQLOLEDB;data source=" & .srv & ";initial catalog=" & .db & "; 
                user id=" & .usr & ";Password=" & .pwd
            }
        Else
            frmLogin.connDic.Add(Conn_txt.Text, New Login.connS With {
                .srv = Srv_txt.Text, .db = Db_txt.Text, .usr = User_txt.Text, .pwd = Pwd_txt.Text, .connStr = "Provider=SQLOLEDB;data source=" & .srv & ";initial catalog=" & .db & "; 
                user id=" & .usr & ";Password=" & .pwd
           })
        End If
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\login\Login.ini") Then IO.File.Delete(My.Application.Info.DirectoryPath & "\login\Login.ini")

        Dim cnstr As String = ""
        Dim sw As New IO.StreamWriter("login\Login.ini", True)
        For Each c In frmLogin.connDic
            sw.WriteLine(Encrypt("db:=" & c.Key & "@connectionstring:=" & c.Value.connStr))
        Next
        sw.Close()
    End Sub
    Sub ShowLogIn()
        With frmLogin
            With .Connection_lb
                .Items.Clear()
                For Each c In frmLogin.connDic
                    .Items.Add(c.Key)
                Next
                .Size = New Size(.Width, 25 * If(.Items.Count = 0, 1, .Items.Count))
            End With
            .Show()
        End With
        Me.Opacity = 0
        Dim fadeInTimer As New Timer()
        fadeInTimer.Interval = 50 ' Adjust as needed
        AddHandler fadeInTimer.Tick, Sub(senderO, eO)
                                         Me.Opacity -= 0.1
                                         If Me.Opacity <= 0 Then
                                             fadeInTimer.Stop()
                                             Me.Close()
                                         End If
                                     End Sub
        fadeInTimer.Start()
    End Sub
    Private Sub DB_lb_Click(sender As Object, e As EventArgs) Handles DB_lb.Click
        If DB_lb.SelectedItems.Count > 0 Then
            Db_txt.Text = DB_lb.SelectedItem
            DB_lb.Visible = False
        End If
    End Sub
    Private Sub Login_Connection_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 0
        Dim fadeInTimer As New Timer()
        fadeInTimer.Interval = 50 ' Adjust as needed
        AddHandler fadeInTimer.Tick, Sub(senderO, eO)
                                         Me.Opacity += 0.1
                                         If Me.Opacity >= 1 Then
                                             fadeInTimer.Stop()
                                         End If
                                     End Sub
        fadeInTimer.Start()
    End Sub
    Private Sub Name_Conn_Text_Leave(sender As Object, e As EventArgs) Handles Conn_txt.Leave
        If Me.ActiveControl IsNot Connection_lb Then
            Connection_lb.Visible = False
        End If
    End Sub

    Private Sub Conn_txt_KeyUp(sender As Object, e As KeyEventArgs) Handles Conn_txt.KeyUp
        If e.KeyCode = Keys.Down Then
            If Connection_lb.Visible Then
                If Connection_lb.Items.Count > 0 Then
                    Connection_lb.SelectedItem = Connection_lb.Items(0)
                    Me.ActiveControl = Connection_lb
                End If
            End If
        End If
    End Sub
    Private Sub Db_txt_Leave(sender As Object, e As EventArgs) Handles Db_txt.Leave
        If Me.ActiveControl IsNot DB_lb Then
            DB_lb.Visible = False
        End If
    End Sub
    Private Sub Db_txt_KeyUp(sender As Object, e As KeyEventArgs) Handles Db_txt.KeyUp
        If e.KeyCode = Keys.Down Then
            If DB_lb.Visible Then
                If DB_lb.Items.Count > 0 Then
                    DB_lb.SelectedItem = DB_lb.Items(0)
                    Me.ActiveControl = DB_lb
                End If
            End If
        End If
    End Sub

    Private Sub Connection_lb_KeyUp(sender As Object, e As KeyEventArgs) Handles Connection_lb.KeyUp
        With Connection_lb
            If e.KeyCode = Keys.Enter Then
                If .SelectedItems.Count > 0 Then
                    Conn_txt.Text = .SelectedItem
                    .Visible = False
                End If
            End If
        End With
    End Sub
    Private Sub DB_lb_KeyUp(sender As Object, e As KeyEventArgs) Handles DB_lb.KeyUp
        With DB_lb
            If e.KeyCode = Keys.Enter Then
                If .SelectedItems.Count > 0 Then
                    Db_txt.Text = .SelectedItem
                    .Visible = False
                End If
            End If
        End With
    End Sub
    Private Sub Conn_txt_TextChanged(sender As Object, e As EventArgs) Handles Conn_txt.TextChanged
        If frmLogin.connDic.ContainsKey(Conn_txt.Text) Then
            Srv_txt.Text = frmLogin.connDic(Conn_txt.Text).srv
            User_txt.Text = frmLogin.connDic(Conn_txt.Text).usr
            Pwd_txt.Text = frmLogin.connDic(Conn_txt.Text).pwd
            Db_txt.Text = frmLogin.connDic(Conn_txt.Text).db
        Else
            Srv_txt.Text = ""
            User_txt.Text = ""
            Pwd_txt.Text = ""
            Db_txt.Text = ""
        End If
        If Me.ActiveControl Is Conn_txt Then
            With Connection_lb
                ' .Visible = True
                .Items.Clear()
                For Each c In frmLogin.connDic
                    If c.Key.ToLower.Contains(Conn_txt.Text.ToLower) Or Conn_txt.Text.Trim = "" Then
                        .Items.Add(c.Key)
                        .Size = New Size(.Width, .Items.Count * 25)
                    End If
                Next
                .Visible = .Items.Count > 0
            End With
        Else
            Connection_lb.Visible = False
        End If
    End Sub

    Private Sub Db_txt_TextChanged(sender As Object, e As EventArgs) Handles Db_txt.TextChanged
        If Me.ActiveControl Is Db_txt Then
            Dim oCn As New OleDb.OleDbConnection
            Dim xcnStr As String = "Provider=SQLOLEDB;data source=" & Srv_txt.Text & ";initial catalog=master;user id=" & User_txt.Text & ";Password=" & Pwd_txt.Text
            With oCn
                Try
                    .ConnectionString = xcnStr
                    .Open()
                Catch ex As Exception
                    Return
                End Try
            End With
            Dim TblConnection As New DataTable
            Dim CMD As OleDb.OleDbCommand = oCn.CreateCommand()
            With CMD
                .CommandText = "select top 8 name from sysdatabases where dbid>4 and name like '%" & Db_txt.Text.Replace("'", "''") & "%' order by name"
                .CommandTimeout = 0
                Dim monreader As OleDb.OleDbDataReader = .ExecuteReader()
                TblConnection.Load(monreader)
            End With
            With DB_lb
                .Items.Clear()
                For i = 0 To TblConnection.Rows.Count - 1
                    .Items.Add(TblConnection.Rows(i)("name"))
                Next
                .Size = New Size(.Width, .Items.Count * 25)
                .Visible = .Items.Count > 0
            End With
        Else
            DB_lb.Visible = False
        End If
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
End Class