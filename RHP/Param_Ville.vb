Public Class Param_Ville
    Friend Code As String = ""
    Dim Save_D As ud_btn
    ' This is a test 2
    Private Sub Param_Ville_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Ville_Text.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Ville_Text.Text & "'")

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS024", Cod_Pay_Text, Me)
    End Sub

    Private Sub Cod_Ville_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Ville_Text.TextChanged
        Try
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
            DroitAcces(Me, DroitModify_Fiche(Cod_Ville_Text.Text, Me))
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Cod_Ville_Text.Text)
                Code = Cod_Ville_Text.Text
            End If
            Request()

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Request()
        Try
            Chargement()
            Grd_Villes.Rows.Clear()
            Ville_Text.Text = FindLibelle("Ville", "Cod_Ville", Cod_Ville_Text.Text, "Param_Ville")
            If Cod_Pay_Text.Text <> FindLibelle("Cod_Pays", "Cod_Ville", Cod_Ville_Text.Text, "Param_Ville") Then
                Cod_Pay_Text.Text = FindLibelle("Cod_Pays", "Cod_Ville", Cod_Ville_Text.Text, "Param_Ville")
            End If
            If Cod_Pay_Text.Text = "" Then Cod_Pay_Text.Text = Societe.Cod_Pays
            Dim Tbl As DataTable = DATA_READER_GRD($"declare @v nvarchar(50)='{Cod_Ville_Text.Text}'
;
with Tbl as (select Cod_Ville_Depart as Cod_Ville, Distance_Km from Param_Ville_Distances where Cod_Ville_Destination=@v
union all
select Cod_Ville_Destination, Distance_Km from Param_Ville_Distances where Cod_Ville_Depart=@v)
select @v Cod_Ville, Ville , max(isnull(Distance_Km,0)) as Distance
from Tbl t right join Param_Ville v on t.Cod_Ville=v.Cod_Ville
where Cod_Pays='{Cod_Pay_Text.Text}' and v.Cod_Ville!=@v
group by t.Cod_Ville, Ville
Order by Ville")
            With Tbl
                For i = 0 To .Rows.Count - 1
                    Grd_Villes.Rows.Add(.Rows(i)("Cod_Ville"), .Rows(i)("Ville"), .Rows(i)("Distance"))
                Next

            End With

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Adding()

        Cod_Ville_Text.Text = ""
        Ville_Text.Text = ""

        Dim A As String = InputBox("Saisissez le nouveau code", "Nouveau").ToUpper
        If A.Contains("'") Or A.Contains("%") Or A.Contains("&") Or A.Contains(",") Then
            MessageBoxRHP(51)
            Exit Sub
        ElseIf A.Length > 5 Then
            MessageBoxRHP(52, "5")
            Exit Sub
        End If
        If A <> "" Then
            If CnExecuting("Select count(*) from Param_Ville where Cod_Ville ='" & A & "'").Fields(0).Value >= 1 Then
                MessageBoxRHP(53, CnExecuting("select Ville from Param_Ville where Cod_Ville ='" & A & "'").Fields(0).Value)
                Exit Sub
            End If

            Cod_Ville_Text.Text = A
        End If
        If Cod_Pay_Text.Text = "" Then Cod_Pay_Text.Text = Societe.Cod_Pays
    End Sub

    Private Sub Saving()
        Try
            Dim rs As New ADODB.Recordset
            If Cod_Pay_Text.Text.Length > 5 Then
                MessageBoxRHP(598)
                Exit Sub
            End If
            If LTrim(Cod_Ville_Text.Text) = "" Then Exit Sub

            If LTrim(Ville_Text.Text) = "" Then
                MessageBoxRHP(599)
                Exit Sub
            End If
            rs.Open($"select * from Param_Ville where Cod_Ville='{Cod_Ville_Text.Text}'", cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Cod_Ville").Value = Cod_Ville_Text.Text
                rs("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
                rs("Created_By").Value = theUser.Login
            Else
                rs.Update()
                rs("Modified_By").Value = theUser.Login
                rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
            End If
            rs("Cod_Pays").Value = Cod_Pay_Text.Text
            rs("Ville").Value = Ville_Text.Text
            rs.Update()
            rs.Close()
            With Grd_Villes
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(Cod_Ville.Index, i).Value, "") <> "" Then
                        rs.Open($"select * from Param_Ville_Distances where (Cod_Ville_Depart='{Cod_Ville_Text.Text}' and Cod_Ville_Destination='{ .Item(Cod_Ville.Index, i).Value}') or (Cod_Ville_Destination='{Cod_Ville_Text.Text}' and Cod_Ville_Depart='{ .Item(Cod_Ville.Index, i).Value}')", cn, 2, 2)
                        If rs.EOF Then
                            rs.AddNew()
                            rs("Cod_Ville_Depart").Value = Cod_Ville_Text.Text
                            rs("Cod_Ville_Destination").Value = .Item(Cod_Ville.Index, i).Value
                            rs("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
                            rs("Created_By").Value = theUser.Login
                        Else
                            rs.Update()
                            rs("Modified_By").Value = theUser.Login
                            rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
                        End If
                        rs("Distance_Km").Value = IsNull(.Item(Distance_Km.Index, i).Value, 0)
                        rs.Update()
                        rs.Close()
                    End If
                Next
            End With
            ShowMessageBox("Enregistré avec succès")
            Request()
        Catch ex As Exception
            ShowMessageBox("Erreur" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub Cod_Pay_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Pay_Text.TextChanged
        Nom_Pay_Text.Text = FindLibelle("Pays", "Cod_Pays", Cod_Pay_Text.Text, "Param_Pays")
    End Sub

    Sub Div_First()
        If Cod_Ville_Text.Text <> "" Then
            Diviseur_First("Param_Ville", "Cod_Ville", "Cod_Ville", Cod_Ville_Text)
        End If
    End Sub
    Sub Div_Back()
        If Cod_Ville_Text.Text <> "" Then
            Diviseur_Back("Param_Ville", "Cod_Ville", "Cod_Ville", Cod_Ville_Text)
        End If
    End Sub

    Sub Div_Next()
        If Cod_Ville_Text.Text <> "" Then

            Diviseur_Next("Param_Ville", "Cod_Ville", "Cod_Ville", Cod_Ville_Text)
        End If
    End Sub

    Sub Div_Last()
        If Cod_Ville_Text.Text <> "" Then

            Diviseur_Last("Param_Ville", "Cod_Ville", "Cod_Ville", Cod_Ville_Text)
        End If
    End Sub

    Sub Nouveau()
        Adding()
    End Sub

    Sub Deleting()
        If Cod_Ville_Text.Text <> "" Then
            Diviseur_delete("Param_Ville", "Cod_Ville", "Cod_Ville", Cod_Ville_Text, Me)
        End If
    End Sub

    Sub Enregistrer()
        Saving()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Zoom1("MS145", Cod_Ville_Text, Me, "Cod_Pays like '%" & Cod_Pay_Text.Text & "%'")
    End Sub

    Private Sub Param_Ville_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
    End Sub
    Sub Chargement()
        If Save_D Is Nothing Then Save_D = dictButtons("Save_D")
        If Cod_Pay_Text.Text = "" Then Cod_Pay_Text.Text = Societe.Cod_Pays
    End Sub


End Class