Public Class Formation_Cabinet
    Friend Cod_Sql5 As String = ""
    Friend Code As String = ""
    Private Sub Fiche_Fou_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Raison_Sociale_txt.Enabled = True Then
                If Cod_Cabinet_txt.Text = "" Or CnExecuting("select count(*) from Formation_Cabinet where Cod_Cabinet='" & Cod_Cabinet_txt.Text & "'  and id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
                    Exit Sub
                End If
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Cabinet_txt.Text & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Fiche_Fou_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Chargement()
        If Cod_Pays_txt.Text = "" Then Cod_Pays_txt.Text = FindParam("Cod_Pays")
        With pic
            .BackColor = Color.Transparent
            .SizeMode = PictureBoxSizeMode.AutoSize
            Grd_Experiences.Controls.Add(pic)
            .Visible = False
        End With
        AutoComplete("select distinct Etablissement  from Formation_Formateur_CV where Typ_CV='E'", Grd_Experiences, Me, "", {2})
        AutoComplete("select distinct Etablissement  from Formation_Formateur_CV where Typ_CV='F'", Grd_CV, Me, "", {2})
        ' AutoComplete("select distinct Diplome  from Formation_Formateur_CV", Grd_CV, Me, "", {1})
    End Sub

    Sub Chargement()
        If Organisme.Items.Count = 0 Then Combo_GRD(Organisme)
        If Typ_Coordonnees_Combo.Items.Count = 0 Then Combo_GRD(Typ_Coordonnees_Combo)
        If Niveau.Items.Count = 0 Then Combo_GRD(Niveau)
    End Sub
    Private Sub request()
        Reset_Form(TabControl1)
        Try
            Chargement()
            If Raison_Sociale_txt.Text.Contains("***") Then Return
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
            DroitAcces(Me, DroitModify_Fiche(Cod_Cabinet_txt.Text, Me))
            Dim laTbl As New DataTable
            laTbl = DATA_READER_GRD("Select * from Formation_Cabinet where Cod_Cabinet='" & Cod_Cabinet_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            If laTbl.Rows.Count > 0 Then
                Raison_Sociale_txt.Text = IsNull(laTbl.Rows(0).Item("Raison_Sociale"), "")
                Adresse_txt.Text = IsNull(laTbl.Rows(0).Item("Adresse"), "")
                CP_txt.Text = IsNull(laTbl.Rows(0).Item("CP"), "")
                Cod_Pays_txt.Text = IsNull(laTbl.Rows(0).Item("Cod_Pays"), "")
                Cod_Ville_txt.Text = IsNull(laTbl.Rows(0).Item("Cod_Ville"), "")
                Mail_txt.Text = IsNull(laTbl.Rows(0).Item("Mail"), "")
                Tel1_txt.Text = IsNull(laTbl.Rows(0).Item("Tel1"), "")
                Tel2_txt.Text = IsNull(laTbl.Rows(0).Item("Tel2"), "")
                Tel3_txt.Text = IsNull(laTbl.Rows(0).Item("Tel3"), "")
                Tel4_txt.Text = IsNull(laTbl.Rows(0).Item("Tel4"), "")
                Tel5_txt.Text = IsNull(laTbl.Rows(0).Item("Tel5"), "")
                Fax_txt.Text = IsNull(laTbl.Rows(0).Item("Fax"), "")
                Form_Jur_txt.Text = IsNull(laTbl.Rows(0).Item("Form_Jur"), "")
                Cap_txt.Text = IsNull(laTbl.Rows(0).Item("Cap"), "")
                RC_txt.Text = IsNull(laTbl.Rows(0).Item("Rc"), "")
                Pat_txt.Text = IsNull(laTbl.Rows(0).Item("PAT"), "")
                Id_Fisc_txt.Text = IsNull(laTbl.Rows(0).Item("Id_Fisc"), "")
                CNSS_txt.Text = IsNull(laTbl.Rows(0).Item("CNSS"), "")
                ICE_txt.Text = IsNull(laTbl.Rows(0).Item("ICE"), "")
                Sml_chk.Checked = IsNull(laTbl.Rows(0).Item("Sml"), False)
                Black_List_chk.Checked = IsNull(laTbl.Rows(0).Item("Black_List"), False)
                Commentaire_rtb.Rtb.RtfText = IsNull(laTbl.Rows(0).Item("Commentaire"), "")
                laTbl = DATA_READER_GRD("Select * from Formation_Cabinet_Organismes where Cod_Cabinet='" & Cod_Cabinet_txt.Text & "' and id_Societe=" & Societe.id_Societe)
                With Grd_Organismes
                    .Rows.Clear()
                    With laTbl
                        Dim C1, C2, C3 As Object
                        For i = 0 To .Rows.Count - 1
                            C1 = IsNull(.Rows(i)("Organisme"), "")
                            C2 = IsNull(.Rows(i)("Acredite"), False)
                            C3 = IsNull(.Rows(i)("Commentaire"), "")
                            Grd_Organismes.Rows.Add(C1, C2, C3)
                        Next
                    End With
                End With
                laTbl = DATA_READER_GRD("select isnull(c.Domaines_Competence,'') as Domaines_Competence , 
isnull(d.Lib_Domaines_Competence,'') as  Lib_Domaines_Competence,  
isnull(c.Typ_Formation,'') as Cod_Formation, isnull(t.Typ_Formation,'') as Lib_Typ_Formation,
isnull(c.Acreditations,'') as Acreditations ,c.RowId
from Formation_Cabinet_Domaines_Competences c
left join GPEC_Domaines_Competence d on c.id_Societe =d.id_Societe and c.Domaines_Competence =d.Domaines_Competence 
left join Formation_Typ_Formation t on t.id_Societe =d.id_Societe and t.Domaines_Competence =d.Domaines_Competence and c.Typ_Formation = t.RowId 
where c.id_Societe =" & Societe.id_Societe & " and c.Cod_Cabinet ='" & Cod_Cabinet_txt.Text & "'")
                With Grd_Domaines_Competences
                    .Rows.Clear()
                    With laTbl
                        Dim C1, C2, C3, C4, C5, C6 As Object
                        For i = 0 To .Rows.Count - 1
                            C1 = .Rows(i)("Domaines_Competence")
                            C2 = .Rows(i)("Lib_Domaines_Competence")
                            C3 = .Rows(i)("Cod_Formation")
                            C4 = .Rows(i)("Lib_Typ_Formation")
                            C5 = .Rows(i)("Acreditations")
                            C6 = .Rows(i)("RowId")
                            Grd_Domaines_Competences.Rows.Add(C1, C2, C3, C4, C5, C6)
                        Next
                    End With
                End With
            End If
            MajEquipeFormateur()
            If dictButtons("Save_D").Enabled = True Then
                Check_Accessible(Me.Name, Cod_Cabinet_txt.Text)
                Code = Cod_Cabinet_txt.Text
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Raison_Sociale_txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Raison_Sociale_txt.Leave
        If Raison_Sociale_txt.Text = "" Then Exit Sub
        If Cod_Cabinet_txt.Text = "" Or CnExecuting("select count(*) from Formation_Cabinet where Cod_Cabinet='" & Cod_Cabinet_txt.Text & "'").Fields(0).Value = 0 Then
            If CnExecuting("select count(*) from Formation_Cabinet where ltrim(rtrim(Raison_Sociale)) = '" & Raison_Sociale_txt.Text.Replace("'", "''").Trim & "'").Fields(0).Value > 0 Then
                ShowMessageBox(128)
                Raison_Sociale_txt.Text = ""
                Raison_Sociale_txt.Select()
            End If
        End If

    End Sub
    Sub Saving()
        Grd_Formateurs.EndEdit(True)
        Grd_Formateur_Competences.EndEdit(True)
        Grd_Organismes.EndEdit(True)
        Grd_Domaines_Competences.EndEdit(True)
        Grd_Coordonnees.EndEdit(True)
        Grd_CV.EndEdit(True)

        Dim rs As New ADODB.Recordset
        If FindParam("Compteur_Cabinet_Formation") = "O" And Cod_Cabinet_txt.Text = "" Then
            CnExecuting("exec Sys_Compteur 'Cabinet_Formation'," & Societe.id_Societe)
            Code = FindLibelle("Last_Code", "Fichier", "Cabinet_Formation", "Param_Compteur")
        Else
            Code = Cod_Cabinet_txt.Text
        End If
        Dim Cod_Sql As String = "select * from Formation_Cabinet where Cod_Cabinet='" & Code & "' and id_Societe=" & Societe.id_Societe
        rs.Open(Cod_Sql, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Cod_Cabinet").Value = Code
            rs("id_Societe").Value = Societe.id_Societe
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = Now
        Else
            rs.Update()
        End If
        rs("Raison_Sociale").Value = Raison_Sociale_txt.Text
        rs("Adresse").Value = Adresse_txt.Text
        rs("CP").Value = CP_txt.Text
        rs("Cod_Pays").Value = Cod_Pays_txt.Text
        rs("Cod_Ville").Value = Cod_Ville_txt.Text
        rs("Mail").Value = Mail_txt.Text
        rs("Tel1").Value = Tel1_txt.Text
        rs("Tel2").Value = Tel2_txt.Text
        rs("Tel3").Value = Tel3_txt.Text
        rs("Tel4").Value = Tel4_txt.Text
        rs("Tel5").Value = Tel5_txt.Text
        rs("Fax").Value = Fax_txt.Text
        rs("Form_Jur").Value = Form_Jur_txt.Text
        rs("Cap").Value = Cap_txt.Text
        rs("Rc").Value = RC_txt.Text
        rs("PAT").Value = Pat_txt.Text
        rs("Id_Fisc").Value = Id_Fisc_txt.Text
        rs("CNSS").Value = CNSS_txt.Text
        rs("ICE").Value = ICE_txt.Text
        rs("Sml").Value = Sml_chk.Checked
        rs("Black_List").Value = Black_List_chk.Checked
        rs("Commentaire").Value = Commentaire_rtb.Rtb.RtfText
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = theUser.Login

        rs.Update()
        rs.Close()

        With Grd_Domaines_Competences
            CnExecuting("delete from Formation_Cabinet_Domaines_Competences where Cod_Cabinet='" & Code & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from Formation_Cabinet_Domaines_Competences where Cod_Cabinet='" & Code & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Domaine_Competence.Index, i).Value, "") <> "" Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Cod_Cabinet").Value = Code
                    rs("Domaines_Competence").Value = .Item(Domaine_Competence.Index, i).Value
                    If IsNull(.Item(Typ_Formation.Index, i).Value, "-1") <> "-1" Then rs("Typ_Formation").Value = .Item(Typ_Formation.Index, i).Value
                    rs("Acreditations").Value = IsNull(.Item(Acreditations.Index, i).Value, "")
                    rs.Update()
                End If
            Next
            rs.Close()
        End With
        With Grd_Organismes
            CnExecuting("delete from Formation_Cabinet_Organismes where Cod_Cabinet='" & Code & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from Formation_Cabinet_Organismes where Cod_Cabinet='" & Code & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Organisme.Index, i).Value, "") <> "" Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Cod_Cabinet").Value = Code
                    rs("Organisme").Value = .Item(Organisme.Index, i).Value
                    rs("Acredite").Value = IsNull(.Item(Acredite.Index, i).Value, False)
                    rs("Commentaire").Value = IsNull(.Item(Commentaire.Index, i).Value, "")
                    rs.Update()
                End If
            Next
            rs.Close()
        End With
        If Nom_txt.Text.Trim <> "" Then
            SavingFormateur(Code)
        End If
        Cod_Cabinet_txt.Text = Code

    End Sub

    Private Sub CAP_Text_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cap_txt.TextChanged
        If sender.text = "" Then
            sender.text = 0
        End If
    End Sub
    Private Sub IS_MUMERIQUE(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cap_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub

    Private Sub LinkLabel20_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel20.LinkClicked
        Appel_Rubrique("Cod_Pays_Combo", Cod_Pays_txt, Me)
    End Sub
    Private Sub Cod_Pays_Liv_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Pays_txt.TextChanged
        Cod_Ville_txt.Text = ""
        Lib_Cod_Ville_txt.Text = ""
    End Sub

    Private Sub LinkLabel21_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel21.LinkClicked
        Appel_Zoom("Cod_Ville", "ville", "Param_Ville", "Cod_Pays ='" & Cod_Pays_txt.Text & "'", Cod_Ville_txt, Me)
    End Sub

    Private Sub Cod_Ville_Liv_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Ville_txt.TextChanged
        Lib_Cod_Ville_txt.Text = FindLibelle("ville", "Cod_Ville", Cod_Ville_txt.Text, "Param_Ville")
        AutoComplete("select distinct isnull(CP,'') from Formation_Cabinet where Cod_Ville ='" & Cod_Ville_txt.Text & "' and Cod_Pays='" & Cod_Pays_txt.Text & "'", CP_txt, Me, connectionString)
    End Sub
    Private Sub LinkLabel15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Appel_Rubrique("Cod_Pst_Combo", CP_txt, Me)
    End Sub
    Private Sub FORM_JUR_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Form_Jur_txt.TextChanged
        Lib_Form_Jur_txt.Text = FindRubriques("Form_Jur_Combo", Form_Jur_txt.Text)
    End Sub

    Private Sub LinkLabel2_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Rubrique("Form_Jur_Combo", Form_Jur_txt, Me)
    End Sub
    Sub Div_First()
        If Cod_Cabinet_txt.Text <> "" Then

            Diviseur_First("Formation_Cabinet", "Cod_Cabinet", "Cod_Cabinet", Cod_Cabinet_txt)
        End If
    End Sub
    Sub Div_Back()
        If Cod_Cabinet_txt.Text <> "" Then

            Diviseur_Back("Formation_Cabinet", "Cod_Cabinet", "Cod_Cabinet", Cod_Cabinet_txt)
        End If
    End Sub
    Sub Div_Next()
        If Cod_Cabinet_txt.Text <> "" Then

            Diviseur_Next("Formation_Cabinet", "Cod_Cabinet", "Cod_Cabinet", Cod_Cabinet_txt)
        End If
    End Sub
    Sub Div_Last()
        If Cod_Cabinet_txt.Text <> "" Then

            Diviseur_Last("Formation_Cabinet", "Cod_Cabinet", "Cod_Cabinet", Cod_Cabinet_txt)
        End If
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Select Case FindParam("Compteur_Cabinet_Formation")
            Case "N"
                Enabling(Cod_Cabinet_txt, True)
                Cod_Cabinet_txt.Select()
            Case "O"
                Raison_Sociale_txt.Select()
        End Select
        If Cod_Pays_txt.Text = "" Then Cod_Pays_txt.Text = FindParam("Cod_Pays")
        CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        Code = ""
        TabControl1.SelectedIndex = 0
    End Sub
    Sub Deleting()
        If Cod_Cabinet_txt.Text = "" Then Exit Sub
        Diviseur_delete("Formation_Cabinet", "Cod_Cabinet", "Cod_Cabinet", Cod_Cabinet_txt, Me)
    End Sub
    Sub Enregistrer()
        Raison_Sociale_txt.Select()
        If Raison_Sociale_txt.Text.Contains("***") Then
            TabControl1.SelectedIndex = 0
            Raison_Sociale_txt.SelectAll()
            MessageBoxRHP(126)
            Exit Sub
        End If
        If LTrim(Cod_Cabinet_txt.Text) = "" And FindParam("Compteur_Cabinet_Formation") <> "O" Then
            TabControl1.SelectedIndex = 0
            MessageBoxRHP(117)
            Exit Sub
        End If

        If LTrim(Raison_Sociale_txt.Text) = "" Then
            TabControl1.SelectedIndex = 0
            MessageBoxRHP(126)
            Raison_Sociale_txt.SelectAll()
            Exit Sub
        End If
        If Mail_txt.Text <> "" Then
            If Not estEmail(Mail_txt.Text) Then
                TabControl1.SelectedIndex = 0
                ShowMessageBox("Erreur format mail", "Mail erreur", MessageBoxButtons.OK, msgIcon.Stop)
                Mail_txt.Select()
                Return
            End If
        End If

        If ICE_txt.Text.Trim.Length > 15 And ICE_txt.Text.Trim <> "" Then
            ShowMessageBox("Veuillez renseigner l'ICE sur 15 chiffres")
            Return
        End If
        Saving()
        MessageBoxRHP(109, Raison_Sociale_txt.Text)
        TabControl1.SelectedIndex = 0
    End Sub
    Private Sub Ana_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EstAxeAna(Me.Name)
    End Sub
    Private Sub Cod_Cabinet_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Cabinet_txt.TextChanged
        If Cod_Cabinet_txt.ReadOnly Then
            request()
        End If
    End Sub
    Private Sub Cod_Cabinet_txt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Cabinet_txt.Leave
        If Not Cod_Cabinet_txt.ReadOnly Then
            Dim rg As New System.Text.RegularExpressions.Regex("\W")
            If rg.IsMatch(Cod_Cabinet_txt.Text) Then
                ShowMessageBox(51)
                Cod_Cabinet_txt.Select()
                Return
            End If
            If Cod_Cabinet_txt.Text.Trim = "" Then
                Reset_Form(Me)
                Enabling(Cod_Cabinet_txt, False)
                Return
            End If
            Dim tbl As DataTable = DATA_READER_GRD("select Nom_Clt from Sys_Part_Clt where Cod_Clt ='" & Cod_Cabinet_txt.Text.Trim & "'")
            If tbl.Rows.Count >= 1 Then
                ShowMessageBox(53, tbl.Rows(0)("Nom_Clt"))
                Cod_Cabinet_txt.Select()
                Exit Sub
            End If
        End If
        Enabling(Cod_Cabinet_txt, False)
    End Sub

    Private Sub Cod_Fou_LINK_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Fou_LINK.LinkClicked
        Appel_Zoom1("MS150", Cod_Cabinet_txt, Me)
    End Sub
    Private Sub Cod_Formateur_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Formateur_txt.TextChanged
        Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 As Object
        Dim laTbl As DataTable = DATA_READER_GRD("select isnull(c.Domaines_Competence,'') as Domaines_Competence , 
isnull(d.Lib_Domaines_Competence,'') as  Lib_Domaines_Competence,  
isnull(c.Typ_Formation,'') as Cod_Formation, isnull(t.Typ_Formation,'') as Lib_Typ_Formation,
isnull(c.Acreditations,'') as Acreditations ,c.RowId
from Formation_Formateur_Domaines_Competences c
left join GPEC_Domaines_Competence d on c.id_Societe =d.id_Societe and c.Domaines_Competence =d.Domaines_Competence 
left join Formation_Typ_Formation t on t.id_Societe =d.id_Societe and t.Domaines_Competence =d.Domaines_Competence and c.Typ_Formation = t.RowId 
where c.id_Societe =" & Societe.id_Societe & " and c.Cod_Formateur =" & IsNull(Cod_Formateur_txt.Text, -1))
        With Grd_Formateur_Competences
            .Rows.Clear()
            With laTbl
                For i = 0 To .Rows.Count - 1
                    C1 = .Rows(i)("Domaines_Competence")
                    C2 = .Rows(i)("Lib_Domaines_Competence")
                    C3 = .Rows(i)("Cod_Formation")
                    C4 = .Rows(i)("Lib_Typ_Formation")
                    C5 = .Rows(i)("Acreditations")
                    C6 = .Rows(i)("RowId")
                    Grd_Formateur_Competences.Rows.Add(C1, C2, C3, C4, C5, C6)
                Next
            End With
        End With
        laTbl = DATA_READER_GRD("SELECT isnull(Typ_Coordonnee,'') as Typ_Coordonnee, isnull(Coordonnee,'') as Coordonnee, RowId
FROM Formation_Formateur_Coordonnees
where Cod_Formateur =" & IsNull(Cod_Formateur_txt.Text, -1))
        With Grd_Coordonnees
            .Rows.Clear()
            With laTbl
                For i = 0 To .Rows.Count - 1
                    C1 = .Rows(i)("Typ_Coordonnee")
                    C2 = .Rows(i)("Coordonnee")
                    C3 = .Rows(i)("RowId")
                    Grd_Coordonnees.Rows.Add(C1, C2, C3)
                Next
            End With
        End With
        'Afficher CV
        laTbl = DATA_READER_GRD("select isnull(Typ_CV,'') as Typ_CV, isnull(Annee,1900) as Annee, isnull(Dat_Deb,'') Dat_Deb, 
isnull(Dat_Fin,'') Dat_Fin, isnull(Etablissement,'') Etablissement, 
isnull(Diplome,'') Diplome, isnull(Poste,'') Poste, isnull(Niveau,'') Niveau, 
isnull(Commentaire,'') Commentaire
from Formation_Formateur_CV
where Cod_Formateur =" & IsNull(Cod_Formateur_txt.Text, -1) & "  and id_Societe=" & Societe.id_Societe)
        With laTbl
            For i = 0 To .Rows.Count - 1
                C2 = .Rows(i).Item("Typ_CV")
                C3 = CStr(IsNull(.Rows(i).Item("Annee"), ""))
                C4 = .Rows(i).Item("Dat_Deb")
                C5 = .Rows(i).Item("Dat_Fin")
                C6 = .Rows(i).Item("Etablissement")
                C7 = .Rows(i).Item("Diplome")
                C8 = .Rows(i).Item("Poste")
                C9 = .Rows(i).Item("Niveau")
                C10 = .Rows(i).Item("Commentaire")
                If C2 = "F" Then
                    Grd_CV.Rows.Add(C3, C7, C6, C9, C10)
                ElseIf C2 = "E" Then
                    Grd_Experiences.Rows.Add(C4, C5, C6, C8, C10)
                End If
            Next
            Grd_CV.Sort(Annee, System.ComponentModel.ListSortDirection.Descending)
            Grd_Experiences.Sort(Dat_Fin, System.ComponentModel.ListSortDirection.Descending)
        End With


    End Sub

    Private Sub Grd_Formateurs_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Formateurs.CellDoubleClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex < 0 Then Return
        With Grd_Formateurs
            If .RowCount = 0 Then Return
            Cod_Formateur_txt.Text = .Item("Code", e.RowIndex).Value
            Nom_txt.Text = .Item("Nom", e.RowIndex).Value
            Prenom_txt.Text = .Item("Prénom", e.RowIndex).Value
            En_exercice_chk.Checked = .Item("En exercice", e.RowIndex).Value
            Homme_Rd.Checked = (.Item("Civilité", e.RowIndex).Value = "H")
            Femme_Rd.Checked = Not (.Item("Civilité", e.RowIndex).Value = "H")
        End With

    End Sub
    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        SavingFormateur(Cod_Cabinet_txt.Text)
    End Sub
    Sub SavingFormateur(Code As String)
        Dim rg As New System.Text.RegularExpressions.Regex("\W")
        If Code.Trim = "" Then
            ShowMessageBox("Cabinet de formation non encore créé.", "Formateur", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        If Nom_txt.Text = "" Then
            ShowMessageBox("Nom de formateur non renseigné.", "Formateur", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        If rg.IsMatch(Nom_txt.Text) Then
            ShowMessageBox("Nom de formateur contient un caractère spécial.", "Formateur", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        If Prenom_txt.Text = "" Then
            ShowMessageBox("Prénom de formateur non renseigné.", "Formateur", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        If rg.IsMatch(Prenom_txt.Text) Then
            ShowMessageBox("Prénom de formateur contient un caractère spécial.", "Formateur", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        With Grd_Experiences
            For i = 0 To .RowCount - 1
                If EstDate(.Item("Dat_Deb", i).Value) Then
                    If EstDate(.Item("Dat_Fin", i).Value) Then
                        If CDate(.Item("Dat_Deb", i).Value) >= CDate(.Item("Dat_Fin", i).Value) Then
                            ShowMessageBox("incohérence date début d'expéreince et date fin", "Expérience formateur", MessageBoxButtons.OK, msgIcon.Stop)
                            Return
                        End If
                    End If
                    If IsNull(.Item(Etablissement_0.Index, i).Value, "") = "" Then
                        ShowMessageBox("Etablissement d'expérience vide", "Expérience formateur", MessageBoxButtons.OK, msgIcon.Stop)
                        Return
                    End If
                End If
            Next
        End With
        Dim rs As New ADODB.Recordset
        Dim CodFormateur As Integer = IsNull(Cod_Formateur_txt.Text, -1)
        rs.Open("select * from Formation_Formateur where Cod_Formateur=" & CodFormateur, cn, 1, 3)
        If rs.EOF Then
            rs.AddNew()
            rs("Cod_Cabinet").Value = Code
            rs("id_Societe").Value = Societe.id_Societe
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()
        End If
        rs("Nom").Value = Nom_txt.Text
        rs("Prenom").Value = Prenom_txt.Text
        rs("Civilite").Value = IIf(Femme_Rd.Checked, "F", "H")
        rs("En_Exercice").Value = En_exercice_chk.Checked
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        If CodFormateur = -1 Then
            CodFormateur = rs("Cod_Formateur").Value
        End If
        rs.Close()
        With Grd_Coordonnees
            CnExecuting("delete from Formation_Formateur_Coordonnees where Cod_Formateur=" & CodFormateur)
            rs.Open("select * from Formation_Formateur_Coordonnees where Cod_Formateur=" & CodFormateur, cn, 2, 2)
            For i = 0 To .RowCount - 2
                rs.AddNew()
                rs("Cod_Formateur").Value = CodFormateur
                rs("Typ_Coordonnee").Value = .Item(Typ_Coordonnees_Combo.Index, i).Value
                rs("Coordonnee").Value = .Item(Coordonnee.Index, i).Value
                rs.Update()
            Next
            rs.Close()
        End With
        'Enregistrer le CV :
        CnExecuting("delete from Formation_Formateur_CV where Cod_Formateur='" & CodFormateur & "' and id_Societe=" & Societe.id_Societe)
        rs.Open("select * from Formation_Formateur_CV", cn, 2, 2)
        With Grd_CV
            For i = 0 To .RowCount - 1
                If .Item(0, i).Value <> "" Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Cod_Formateur").Value = CodFormateur
                    rs("Typ_CV").Value = "F"
                    rs("Annee").Value = .Item("Annee", i).Value
                    rs("Diplome").Value = .Item("Diplome", i).Value
                    rs("Etablissement").Value = .Item(Etablissement.Index, i).Value
                    rs("Niveau").Value = .Item("Niveau", i).Value
                    rs("Commentaire").Value = .Item(Commentaire_CV.Index, i).Value
                    rs.Update()
                End If
            Next
        End With
        With Grd_Experiences
            For i = 0 To .RowCount - 1
                If EstDate(.Item("Dat_Deb", i).Value) Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Cod_Formateur").Value = CodFormateur
                    rs("Typ_CV").Value = "E"
                    rs("Dat_Deb").Value = .Item(Dat_Deb.Index, i).Value
                    rs("Dat_Fin").Value = .Item(Dat_Fin.Index, i).Value
                    rs("Etablissement").Value = .Item(Etablissement_0.Index, i).Value
                    rs("Poste").Value = .Item(Poste.Index, i).Value
                    rs("Commentaire").Value = .Item(Commentaire_0.Index, i).Value
                    rs.Update()
                End If
            Next
        End With
        rs.Close()
        With Grd_Formateur_Competences
            CnExecuting("delete from Formation_Formateur_Domaines_Competences where Cod_Formateur=" & CodFormateur)
            rs.Open("select * from Formation_Formateur_Domaines_Competences where Cod_Formateur=" & CodFormateur, cn, 2, 2)
            For i = 0 To .RowCount - 2
                rs.AddNew()
                rs("id_Societe").Value = Societe.id_Societe
                rs("Cod_Formateur").Value = CodFormateur
                rs("Domaines_Competence").Value = .Item(Domaines_Competence_1.Index, i).Value
                If IsNull(.Item(Typ_Formation_1.Index, i).Value, "") <> "" Then rs("Typ_Formation").Value = .Item(Typ_Formation_1.Index, i).Value
                rs("Acreditations").Value = IsNull(.Item(Acreditations_1.Index, i).Value, "")
                rs.Update()
            Next
            rs.Close()
        End With
        MajEquipeFormateur()
        resetFormateur()
    End Sub
    Sub resetFormateur()
        Cod_Formateur_txt.ResetText()
        Nom_txt.ResetText()
        Prenom_txt.ResetText()
        Grd_Formateur_Competences.Rows.Clear()
        Grd_CV.Rows.Clear()
        Grd_Coordonnees.Rows.Clear()
        Grd_Experiences.Rows.Clear()
    End Sub
    Sub MajEquipeFormateur()
        GRD("select  Cod_Formateur as 'Code', isnull(Nom,'') as Nom,ISNULL(Prenom,'') as Prénom, Civilite as Civilité, En_Exercice as 'En exercice', Commentaire
FROM Formation_Formateur where isnull(Cod_Cabinet,'X84DzS651')='" & Cod_Cabinet_txt.Text & "' and id_Societe=" & Societe.id_Societe, Grd_Formateurs)
        Grd_Formateurs.Columns("Code").Visible = False
    End Sub

    Private Sub Delete_btn_Click(sender As Object, e As EventArgs) Handles Del_pb.Click
        Dim CodFormateur As Integer = IsNull(Cod_Formateur_txt.Text, -1)
        If CodFormateur = -1 Then
            Return
        End If
        Diviseur_delete("Formation_Formateur", "Cod_Formateur", "Cod_Formateur", Cod_Formateur_txt, Me, True, False)
        Reset_Form(Formateurs)
        MajEquipeFormateur()
    End Sub
    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles New_pb.Click
        resetFormateur()
        Nom_txt.Select()
    End Sub
    Private Sub Grd_Domaines_Competences_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Domaines_Competences.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        Select Case e.ColumnIndex
            Case Lib_Domaine_Competence.Index, Lib_Typ_Formation.Index
                Cursor = Cursors.Hand
            Case Else
                Cursor = Cursors.Default
        End Select
    End Sub
    Private Sub Grd_Formateur_Competences_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Formateur_Competences.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        Select Case e.ColumnIndex
            Case Lib_Domaines_Competence_1.Index, Lib_Typ_Formation_1.Index
                Cursor = Cursors.Hand
            Case Else
                Cursor = Cursors.Default
        End Select
    End Sub

    Private Sub Grd_Domaines_Competences_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Domaines_Competences.CellMouseDoubleClick
        Dim r As Integer = e.RowIndex
        Dim c As Integer = e.ColumnIndex
        If r < 0 Then Return
        If c < 0 Then Return
        With Grd_Domaines_Competences
            If r = .RowCount - 1 Then
                .Rows.Add("")
            End If
            Select Case e.ColumnIndex
                Case Lib_Domaine_Competence.Index
                    Appel_Zoom1("MS149", .Item(Domaine_Competence.Index, r), Me, "", "", .Item(c, r))
                    .Item(c, r).Value = FindLibelle("Lib_Domaines_Competence", "Domaines_Competence", .Item(Domaine_Competence.Index, r).Value, "GPEC_Domaines_Competence")
                    .Item(Typ_Formation.Index, r).Value = ""
                    .Item(Lib_Typ_Formation.Index, r).Value = ""
                Case Lib_Typ_Formation.Index
                    Appel_Zoom1("MS151", .Item(Typ_Formation.Index, r), Me, " Domaines_Competence='" & IsNull(.Item(Domaine_Competence.Index, r).Value, "") & "' and id_Societe=" & Societe.id_Societe, "", .Item(c, r))
                    .Item(c, r).Value = FindLibelle("Typ_Formation", "RowId", .Item(Typ_Formation.Index, r).Value, "Formation_Typ_Formation")
            End Select
        End With
    End Sub

    Private Sub Grd_Formateur_Competences_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Formateur_Competences.CellMouseDoubleClick
        Dim r As Integer = e.RowIndex
        Dim c As Integer = e.ColumnIndex
        If r < 0 Then Return
        If c < 0 Then Return
        With Grd_Formateur_Competences
            If r = .RowCount - 1 Then
                .Rows.Add("")
            End If
            Select Case c
                Case Lib_Domaines_Competence_1.Index
                    Appel_Zoom1("MS149", .Item(Domaines_Competence_1.Index, r), Me, "", "", .Item(c, r))
                    .Item(c, r).Value = FindLibelle("Lib_Domaines_Competence", "Domaines_Competence", .Item(Domaines_Competence_1.Index, r).Value, "GPEC_Domaines_Competence")
                    .Item(Typ_Formation_1.Index, r).Value = ""
                    .Item(Lib_Typ_Formation_1.Index, r).Value = ""
                Case Lib_Typ_Formation_1.Index
                    Appel_Zoom1("MS151", .Item(Typ_Formation_1.Index, r), Me, " Domaines_Competence='" & IsNull(.Item(Domaines_Competence_1.Index, r).Value, "") & "' and id_Societe=" & Societe.id_Societe, "", .Item(c, r))
                    .Item(c, r).Value = FindLibelle("Typ_Formation", "RowId", .Item(Typ_Formation_1.Index, r).Value, "Formation_Typ_Formation")
            End Select
        End With
    End Sub

    Private Sub Formations_GRD_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_CV.DataError

    End Sub
    Private Sub Grd_Coordonnees_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Coordonnees.DataError

    End Sub
    Private Sub Grd_Domaines_Competences_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Domaines_Competences.DataError

    End Sub
    Private Sub Grd_Formateur_Competences_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Formateur_Competences.DataError

    End Sub
    Private Sub Grd_Organismes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Organismes.DataError

    End Sub
    Private Sub Grd_Formateurs_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Formateurs.DataError

    End Sub
    Friend pic As New PictureBox
    Private Sub Grd_Experiences_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grd_Experiences.CellMouseEnter
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = Dat_Deb.Index Or e.ColumnIndex = Dat_Fin.Index Then
            Dim pt As New Point
            pt.X = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.X + sender.Item(e.ColumnIndex, e.RowIndex).Size.Width - pic.Width
            pt.Y = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.Y
            With pic
                .Parent = Grd_Experiences
                .Image = My.Resources.calendrier
                .Location = pt
                .Visible = True
            End With
        End If

    End Sub

    Private Sub Grd_Experiences_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grd_Experiences.CellMouseLeave
        With pic
            .Visible = False
        End With
    End Sub

    Private Sub Grd_Experiences_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grd_Experiences.DoubleClick
        If Grd_Experiences.CurrentRow Is Nothing Then Exit Sub

        Dim r As Integer = Grd_Experiences.CurrentRow.Index
        Dim c As Integer = Grd_Experiences.CurrentCell.ColumnIndex
        Select Case Grd_Experiences.CurrentCell.ColumnIndex
            Case Grd_Experiences.Columns.IndexOf(Dat_Deb), Grd_Experiences.Columns.IndexOf(Dat_Fin)
                Appel_Calender(Grd_Experiences.CurrentCell, Me)
        End Select
    End Sub
End Class
