Public Class Ctb_Compta_Caisse_Banque
    Friend Code As String = ""
    Dim ModeCrea As Boolean = False
    Dim ModeDuplic As Boolean = False
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim New_D As ud_btn
    Dim Duplik_D As ud_btn
    Sub Cod_Caisse_Bank_Text_Leave(sender As Object, e As EventArgs) Handles Cod_Caisse_Bank_Text.Leave, Bank_txt.Leave
        ModeCrea = Not Cod_Caisse_Bank_Text.ReadOnly
        If Not EstCaractèreConformeVBScript(Cod_Caisse_Bank_Text.Text) Then
            ShowMessageBox("Evitez les caractères spéciaux et les accents.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
            Cod_Caisse_Bank_Text.Select()
        End If
        Dim rsl As Boolean = Request()
        Enabling(Cod_Caisse_Bank_Text, Not rsl)
        If Not rsl Then
            Cod_Caisse_Bank_Text.Select()
        End If
    End Sub
    Function Request() As Boolean
        If ModeDuplic Then Return True
        Try
            Dim Tbl As DataTable = DATA_READER_GRD("Select * from Compta_Caisse_Banque where Cod_Caisse_Bank='" & Cod_Caisse_Bank_Text.Text & "' and id_Societe=" & Societe.id_Societe)
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "' and isnull(id_Societe,-1)=" & Societe.id_Societe)
            End If
            DroitAcces(Me, DroitModify_Fiche(Cod_Caisse_Bank_Text.Text, Me))
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Cod_Caisse_Bank_Text.Text)
                Code = Cod_Caisse_Bank_Text.Text
            End If
            If Tbl.Rows.Count > 0 Then
                With Tbl
                    Lib_Caisse_Bank_Text.Text = IsNull(.Rows(0)("Lib_Caisse_Bank"), "")
                    Typ_Caisse_Bank_Text.Text = IsNull(.Rows(0)("Typ_Caisse_Bank"), "")
                    Rib_Text.Text = IsNull(.Rows(0)("RIB"), "")
                    Bank_txt.Text = IsNull(.Rows(0)("Bank"), "")
                    Compte_Bancaire_Text.Text = IsNull(.Rows(0)("Compte_Bancaire"), "")
                    Addresse_Text.Text = IsNull(.Rows(0)("Addresse"), "")
                    Mis_Sml_Check.Checked = IsNull(.Rows(0)("Mis_Sml"), False)
                    Mouvemente_Check.Checked = IsNull(.Rows(0)("Mouvemente"), False)
                    Swift_Text.Text = IsNull(.Rows(0)("Swift"), "")
                End With
            Else
                Lib_Caisse_Bank_Text.Text = ""
                Typ_Caisse_Bank_Text.Text = ""
                Rib_Text.Text = ""
                Compte_Bancaire_Text.Text = ""
                Addresse_Text.Text = ""
                Mis_Sml_Check.Checked = False
                Mouvemente_Check.Checked = False
                Swift_Text.Text = ""
                Bank_txt.Text = ""
            End If
            Return True
        Catch ex As Exception
            ErrorMsg(ex)
            Return True
        End Try
    End Function
    Private Sub Ctb_Compta_Caisse_Banque_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Caisse_Bank_Text.Text & "'  and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Reseting()
        Reset_Form(Me)
        ModeDuplic = False
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Lib_Caisse_Bank_Text.Text.Contains("**") Then Lib_Caisse_Bank_Text.Text = ""
        Appel_Zoom1("MS055", Cod_Caisse_Bank_Text, Me)
        Request()
    End Sub
    Sub Nouveau()
        Reseting()
        ModeDuplic = False
        Enabling(Cod_Caisse_Bank_Text, True)
        Cod_Caisse_Bank_Text.Select()
    End Sub

    Sub Deleting()
        If Cod_Caisse_Bank_Text.Text = "" Then Exit Sub
        Diviseur_delete("Compta_Caisse_Banque", "Cod_Caisse_Bank", "Cod_Caisse_Bank", Cod_Caisse_Bank_Text, Me)
    End Sub

    Sub Saving()
        Try
            If Cod_Caisse_Bank_Text.Text = "" Then
                ShowMessageBox("Code vide", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
                Exit Sub
            ElseIf Typ_Caisse_Bank_Text.Text = "" Then
                ShowMessageBox("Type vide", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
                Exit Sub
            ElseIf (IsNumeric(Rib_Text.Text) = False Or Rib_Text.Text.Trim.Length <> 24) And (Typ_Caisse_Bank_Text.Text = "B") Then
                ShowMessageBox("Longueur de RIB erronée : " & Rib_Text.Text.Trim.Length & " (différente de 24)", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
                Exit Sub
            ElseIf Lib_Caisse_Bank_Text.Text = "" Then
                MessageBoxRHP(405)
                Exit Sub
            ElseIf Cod_Caisse_Bank_Text.Text.Contains("*") Or Lib_Caisse_Bank_Text.Text.Contains("*") Then
                ShowMessageBox("Evitez le caractère (*)", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
                Exit Sub
            ElseIf Cod_Caisse_Bank_Text.Text.Contains("'") Or Lib_Caisse_Bank_Text.Text.Contains("'") Then
                ShowMessageBox("Evitez le caractère (')", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
                Exit Sub
            ElseIf Cod_Caisse_Bank_Text.Text.Contains("%") Or Lib_Caisse_Bank_Text.Text.Contains("%") Then
                ShowMessageBox("Evitez le caractère (%)", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
                Exit Sub
            ElseIf Cod_Caisse_Bank_Text.Text.Contains("_") Or Lib_Caisse_Bank_Text.Text.Contains("_") Then
                ShowMessageBox("Evitez le caractère (_)", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
                Exit Sub
            ElseIf Typ_Caisse_Bank_Text.Text = "B" Then
                If Bank_txt.Text.Trim = "" Then
                    ShowMessageBox("Renseignez la banque", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
                    Exit Sub
                End If
            End If
            Dim tbl As DataTable = DATA_READER_GRD("select  * from Compta_Caisse_Banque where RIB='" & Rib_Text.Text.Trim & "' and Typ_Caisse_Bank='B'")
            If tbl.Rows.Count > 1 Then
                ShowMessageBox("RIB déjà attribué : " & tbl.Rows(1)("Lib_Caisse_Bank"), "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
            End If
            Dim rs As New ADODB.Recordset
            rs.Open("select * from Compta_Caisse_Banque where Cod_Caisse_Bank='" & Cod_Caisse_Bank_Text.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Dat_Crea").Value = Now
                rs("Created_By").Value = theUser.Login
                rs("id_Societe").Value = Societe.id_Societe
                rs("Cod_Caisse_Bank").Value = Cod_Caisse_Bank_Text.Text
            Else
                rs.Update()
            End If
            rs("Lib_Caisse_Bank").Value = Lib_Caisse_Bank_Text.Text
            rs("Typ_Caisse_Bank").Value = Typ_Caisse_Bank_Text.Text
            rs("RIB").Value = Rib_Text.Text
            rs("Bank").Value = Bank_txt.Text
            rs("Compte_Bancaire").Value = Compte_Bancaire_Text.Text
            rs("Addresse").Value = Addresse_Text.Text
            rs("Mis_Sml").Value = Mis_Sml_Check.Checked
            rs("Mouvemente").Value = Mouvemente_Check.Checked
            rs("Swift").Value = Swift_Text.Text
            rs("Dat_Modif").Value = Now
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
        ModeDuplic = False

        MessageBoxRHP(352)
    End Sub

    Private Sub Typ_Caisse_Bank_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Typ_Caisse_Bank_Text.TextChanged
        Lib_Typ_Caisse_Bank_Text.Text = FindRubriques("Typ_Caisse_Bank_Text", Typ_Caisse_Bank_Text.Text)

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Rubrique("Typ_Caisse_Bank_Text", Typ_Caisse_Bank_Text, Me)
    End Sub
    Sub Dupliquer()
        Enabling(Cod_Caisse_Bank_Text, True)
        ModeDuplic = True
        Cod_Caisse_Bank_Text.Text = ""
        Lib_Caisse_Bank_Text.Text = "***"
        Cod_Caisse_Bank_Text.Select()
    End Sub
    Sub Div_First()
        If Cod_Caisse_Bank_Text.Text <> "" Then
            Diviseur_First("Compta_Caisse_Banque", "Cod_Caisse_Bank", "Cod_Caisse_Bank", Cod_Caisse_Bank_Text)
        End If
    End Sub

    Sub Div_Back()
        If Cod_Caisse_Bank_Text.Text <> "" Then
            Diviseur_Back("Compta_Caisse_Banque", "Cod_Caisse_Bank", "Cod_Caisse_Bank", Cod_Caisse_Bank_Text)
        End If
    End Sub

    Sub Div_Next()
        If Cod_Caisse_Bank_Text.Text <> "" Then
            Diviseur_Next("Compta_Caisse_Banque", "Cod_Caisse_Bank", "Cod_Caisse_Bank", Cod_Caisse_Bank_Text)
        End If
    End Sub

    Sub Div_Last()
        If Cod_Caisse_Bank_Text.Text <> "" Then
            Diviseur_Last("Compta_Caisse_Banque", "Cod_Caisse_Bank", "Cod_Caisse_Bank", Cod_Caisse_Bank_Text)
        End If
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Rubrique("Banque", Bank_txt, Me)
    End Sub

    Private Sub Bank_txt_TextChanged(sender As Object, e As EventArgs) Handles Bank_txt.TextChanged
        Lib_Bank_txt.Text = FindRubriques("Banque", Bank_txt.Text)
    End Sub

    Private Sub Ctb_Compta_Caisse_Banque_Load(sender As Object, e As EventArgs) Handles Me.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Next_D = dictButtons("Next_D")
        Back_D = dictButtons("Back_D")
        Last_D = dictButtons("Last_D")
        First_D = dictButtons("First_D")
        New_D = dictButtons("New_D")
        Duplik_D = dictButtons("Duplik_D")
    End Sub

    Private Sub Cod_Caisse_Bank_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Caisse_Bank_Text.TextChanged
        If Not Cod_Caisse_Bank_Text.ReadOnly Then Return
        Request()
    End Sub
End Class