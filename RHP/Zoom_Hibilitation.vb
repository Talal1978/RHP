Public Class Zoom_Hibilitation
    Friend otxtDroits As ud_TextBox
    Dim oBool As Boolean = True
    Private Sub Zoom_Hibilitation_Dossier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Request()
        ToolTip1.SetToolTip(SelectAll_pb, "Sélectionner tout :")
    End Sub
    Sub Request()
        Dim strD As String = IsNull(otxtDroits.Text, "").Trim
        strD = IIf(strD = "", "1<>1", IIf(strD = "*", "1=1", "Login_User in ('" & strD.Replace(";", "','").Replace(" ", "") & "')"))
        Dim CodSql As String = "select Login_User,left(upper(isnull(Nom_User,'')+' '+isnull(Prenom_User,'')),25) as Nom, case when " & strD & " then 1 else 0 end as Habil  from Controle_Users where upper(Login_User)<>'ADMIN' and isnull(Actif,'false')='true' order by isnull(Nom_User,'')+' '+isnull(Prenom_User,'')"
        Dim TblHabil As DataTable = DATA_READER_GRD(CodSql)
        Dim x As Integer = 12
        Dim y As Integer = 12
        With TblHabil
            For i = 0 To .Rows.Count - 1
                Dim chb As New ud_CheckBox
                chb.Name = IsNull(.Rows(i).Item("Login_User"), "")
                chb.Text = IsNull(.Rows(i).Item("Nom"), "")
                chb.Checked = IsNull(.Rows(i).Item("Habil"), False)
                chb.AutoSize = True
                If i = 0 Then
                    x = 5
                ElseIf i Mod 15 = 0 Then
                    x += 213
                End If
                If i = 0 Then
                    y = 5
                ElseIf i Mod 15 = 0 Then
                    y = 5
                Else
                    y += 23
                End If
                chb.Location = New Point(x, y)
                Panel1.Controls.Add(chb)
            Next
        End With
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Dim strD As String = ""
        Dim nb As Integer = 0
        For Each c As Control In Panel1.Controls
            If c.GetType = GetType(ud_CheckBox) Then
                If CType(c, ud_CheckBox).Checked Then
                    strD &= IIf(strD = "", "", ";") & CType(c, ud_CheckBox).Name
                Else
                    nb = 1
                End If
            End If
        Next
        otxtDroits.Text = IIf(nb = 1, strD, "*")
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub SelectAll_pb_Click(sender As Object, e As EventArgs) Handles SelectAll_pb.Click

        With SelectAll_pb
            If oBool Then
                ToolTip1.SetToolTip(SelectAll_pb, "Sélectionner tout :")
            Else
                ToolTip1.SetToolTip(SelectAll_pb, "Désélectionner tout :")
            End If
            oBool = Not oBool
            For Each c In Panel1.Controls
                If c.GetType = GetType(ud_CheckBox) Then
                    CType(c, ud_CheckBox).Checked = oBool
                End If
            Next
            .Refresh()
        End With
    End Sub
End Class