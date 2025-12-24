Public Class Ctb_Plan_Ctb
    Friend Code As String = ""
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim New_D As ud_btn
    Dim Duplik_D As ud_btn
    Private Sub Ctb_Plan_Ctb_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Itt_Cpt_Text.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and id_Societe=" & Societe.id_Societe & " and Value='" & Cpt_Gnr_Text.Text & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Private Sub Ctb_Plan_Ctb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Next_D = dictButtons("Next_D")
        Back_D = dictButtons("Back_D")
        Last_D = dictButtons("Last_D")
        First_D = dictButtons("First_D")
        New_D = dictButtons("New_D")
        Duplik_D = dictButtons("Duplik_D")
        Typ_Cpt_Combo.fromRubrique()
        Nat_Cpt_Combo.fromRubrique()
        Sen_Naturel_Combo.fromRubrique()
        Typ_Clf_Combo.fromRubrique()
        Typ_Cpt_Combo.SelectedIndex = -1
        Sen_Naturel_Combo.SelectedIndex = -1
        Typ_Clf_Combo.SelectedIndex = -1
    End Sub

    Private Sub CompteGeneralLink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles CompteGeneralLink.LinkClicked
        Appel_Zoom1("MS025", Cpt_Gnr_Text, Me)
    End Sub
    Private Sub Cpt_Gnr_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cpt_Gnr_Text.TextChanged
        Try
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and id_Societe=" & Societe.id_Societe & "  and Value='" & Code & "'")
            End If
            If Not Cpt_Gnr_Text.ReadOnly Then Return
            DroitAcces(Me, DroitModify_Fiche(Cpt_Gnr_Text.Text, Me))
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Cpt_Gnr_Text.Text)
                Code = Cpt_Gnr_Text.Text
            End If
            Itt_Cpt_Text.Text = FindLibelle("Itt_Cpt", "Cpt_Gnr", Cpt_Gnr_Text.Text, "Compta_Plan_Ctb")
            Typ_Cpt_Combo.SelectedValue = FindLibelle("Typ_Cpt", "Cpt_Gnr", Cpt_Gnr_Text.Text, "Compta_Plan_Ctb")
            Cpt_Red_Text.Text = FindLibelle("Cpt_Red", "Cpt_Gnr", Cpt_Gnr_Text.Text, "Compta_Plan_Ctb")
            Cpt_Eco_txt.Text = FindLibelle("Cpt_Eco", "Cpt_Gnr", Cpt_Gnr_Text.Text, "Compta_Plan_Ctb")
            Cpt_Budget_txt.Text = FindLibelle("Cpt_Budget", "Cpt_Gnr", Cpt_Gnr_Text.Text, "Compta_Plan_Ctb")
            Typ_Clf_Combo.SelectedValue = FindLibelle("Typ_Clf", "Cpt_Gnr", Cpt_Gnr_Text.Text, "Compta_Plan_Ctb")
            Sen_Naturel_Combo.SelectedValue = FindLibelle("Sen_Naturel", "Cpt_Gnr", Cpt_Gnr_Text.Text, "Compta_Plan_Ctb")
            Nat_Cpt_Combo.SelectedValue = FindLibelle("Nat_Cpt", "Cpt_Gnr", Cpt_Gnr_Text.Text, "Compta_Plan_Ctb")
            If Cpt_Gnr_Text.Text = "" Then
                Duplik_D.Visible = False
            Else
                Duplik_D.Visible = True
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        With Cpt_Gnr_Text
            .ReadOnly = False
            .Select()
        End With
    End Sub

    Sub Deleting()
        If Cpt_Gnr_Text.Text <> "" Then
            Diviseur_delete("Compta_Plan_Ctb", "Cpt_Gnr", "Cpt_Gnr", Cpt_Gnr_Text, Me)
        End If
    End Sub

    Sub Saving()
        Dim rs As New ADODB.Recordset
        If Cpt_Gnr_Text.Text = "" Then Exit Sub
        Dim rg As New System.Text.RegularExpressions.Regex("\W")
        If rg.IsMatch(Cpt_Gnr_Text.Text) Then
            ShowMessageBox("Evitez les caractères spéciaux", "Création", MessageBoxButtons.OK, msgIcon.Error)
            Cpt_Gnr_Text.Select()
            Return
        End If
        If Sen_Naturel_Combo.SelectedIndex = -1 Then
            Sen_Naturel_Combo.DroppedDown = True
            Exit Sub
        End If
        If Itt_Cpt_Text.Text = "" Then
            ShowMessageBox("Intitulé vide")
            Itt_Cpt_Text.Select()
            Exit Sub
        End If
        If Typ_Cpt_Combo.SelectedIndex = -1 Then
            Typ_Cpt_Combo.DroppedDown = True
            Exit Sub
        End If

        rs.Open("select * from Compta_Plan_Ctb where Cpt_Gnr='" & Cpt_Gnr_Text.Text & "'", cn, 2, 2)
        If CnExecuting("Select count(*) from Compta_Plan_Ctb where Cpt_Gnr='" & Cpt_Gnr_Text.Text & "'").Fields(0).Value = 0 Then
            rs.AddNew()
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
            rs("Cpt_Gnr").Value = Cpt_Gnr_Text.Text
            rs("id_Societe").Value = Societe.id_Societe
        Else
            rs.Update()
        End If
        rs("Itt_Cpt").Value = Itt_Cpt_Text.Text
        rs("Typ_Cpt").Value = Typ_Cpt_Combo.SelectedValue
        rs("Cpt_Red").Value = Cpt_Red_Text.Text
        rs("Cpt_Eco").Value = Cpt_Eco_txt.Text
        rs("Cpt_Budget").Value = Cpt_Budget_txt.Text
        rs("Typ_Clf").Value = Typ_Clf_Combo.SelectedValue
        rs("Sen_Naturel").Value = Sen_Naturel_Combo.SelectedValue
        rs("Nat_Cpt").Value = Nat_Cpt_Combo.SelectedValue
        rs("Modified_By").Value = theUser.Login
        rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
        rs.Update()
        rs.Close()
        ShowMessageBox("Enregistré")

    End Sub

    Sub Dupliquer()
        With Cpt_Gnr_Text
            .ReadOnly = False
            .Text &= "*"
            .Select()
        End With
    End Sub

    Sub Decalage_Text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ControleSaisie(sender, e, True, True, False, False, False)
    End Sub
    Sub Div_First()
        If Cpt_Gnr_Text.Text <> "" Then

            Diviseur_First("Compta_Plan_Ctb", "Cpt_Gnr", "Cpt_Gnr", Cpt_Gnr_Text)
        End If
    End Sub

    Sub Div_Back()
        If Cpt_Gnr_Text.Text <> "" Then

            Diviseur_Back("Compta_Plan_Ctb", "Cpt_Gnr", "Cpt_Gnr", Cpt_Gnr_Text)
        End If
    End Sub

    Sub Div_Next()
        If Cpt_Gnr_Text.Text <> "" Then

            Diviseur_Next("Compta_Plan_Ctb", "Cpt_Gnr", "Cpt_Gnr", Cpt_Gnr_Text)
        End If
    End Sub

    Sub Div_Last()
        If Cpt_Gnr_Text.Text <> "" Then
            Diviseur_Last("Compta_Plan_Ctb", "Cpt_Gnr", "Cpt_Gnr", Cpt_Gnr_Text)
        End If
    End Sub

    Private Sub Cpt_Gnr_Text_Leave(sender As Object, e As EventArgs) Handles Cpt_Gnr_Text.Leave
        Dim rg As New System.Text.RegularExpressions.Regex("\W")
        If rg.IsMatch(Cpt_Gnr_Text.Text) Then
            ShowMessageBox("Evitez les caractères spéciaux", "Création", MessageBoxButtons.OK, msgIcon.Error)
            Cpt_Gnr_Text.Select()
            Return
        End If
        Enabling(Cpt_Gnr_Text, False)
    End Sub


End Class