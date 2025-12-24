Public Class Param_Abonnement
    Friend Code As String = ""
    Dim ZoomCod, ZoomLib, ZoomTbl, ZoomWhere As String
    Dim ZoomCod0, ZoomLib0, ZoomTbl0, ZoomWhere0 As String
    Dim Save_D As ud_btn
    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Typ_Frequence_Combo.Items.Count = 0 Then Typ_Frequence_Combo.fromRubrique("Typ_Frequence")
        If Source_Abonnement.Items.Count = 0 Then Source_Abonnement.fromRubrique("Source_Abonnement")
        If Cod_Abonnement_Text.Text = "" Then Source_Abonnement.SelectedIndex = -1
        If Save_D Is Nothing Then Save_D = dictButtons("Save_D")
    End Sub
    Sub Request()
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
        DroitAcces(Me, DroitModify_Fiche(Cod_Abonnement_Text.Text, Me))
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Abonnement_Text.Text)
            Code = Cod_Abonnement_Text.Text
        End If
        If Typ_Frequence_Combo.Items.Count = 0 Then Typ_Frequence_Combo.fromRubrique("Typ_Frequence")
        Lib_Abonnement_Text.Text = FindLibelle("Lib_Abonnement", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Ref_Abonnement.Text = FindLibelle("Ref_Abonnement", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Source_Abonnement.SelectedValue = FindLibelle("Source_Abonnement", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Typ_Pie_Abonnement.Text = FindLibelle("Typ_Pie_Abonnement", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Actif_Check.Checked = FindLibelle("Actif", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Dat_Deb_Application_Text.Text = IsNull(FindLibelle("Dat_Mis_Application", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement"), Now.Date)
        Heure_Abonnement_Mtxt.Text = IsNull(FindLibelle("Heure_Abonnement", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement"), Now)
        Dat_Fin_Application_Text.Text = FindLibelle("Dat_Fin_Application", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Frequence.Value = IsNull(FindLibelle("Frequence", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement"), 1)
        Typ_Frequence_Combo.SelectedValue = FindLibelle("Typ_Frequence", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Lundi_Check.Checked = FindLibelle("Lundi", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Mardi_Check.Checked = FindLibelle("Mardi", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Mercredi_Check.Checked = FindLibelle("Mercredi", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Jeudi_Check.Checked = FindLibelle("Jeudi", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Vendredi_Check.Checked = FindLibelle("Vendredi", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Samedi_Check.Checked = FindLibelle("Samedi", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        Dimanche_Check.Checked = FindLibelle("Dimanche", "Cod_Abonnement", Cod_Abonnement_Text.Text, "Param_Abonnement")
        UpdatingSource()
        If ZoomCod0 = "" Then
            Lib_Typ_Pie_Abonnement.Text = ""
        Else
            Lib_Typ_Pie_Abonnement.Text = FindLibelle(ZoomLib0, ZoomCod0, Typ_Pie_Abonnement.Text, ZoomTbl0)
        End If
        If ZoomCod = "" Then
            Lib_Ref_Abonnement.Text = ""
        Else
            Lib_Ref_Abonnement.Text = FindLibelle(ZoomLib, ZoomCod, Ref_Abonnement.Text, ZoomTbl)
        End If
        RequestAbonnement()
    End Sub

    Sub RequestAbonnement()
        Dim CodSql As String = "SELECT   Top 10  Dat_Execution as  'Date Exécution', Dat_Next as 'Prochaine Date', Rapport, Execute_Par as 'Executé Par', Execute_Machine as 'Executé Depuis :', Execute_IP as 'IP'" &
                             " FROM Param_Abonnement_Rapport WHERE     (Cod_Abonnement = '" & Cod_Abonnement_Text.Text & "') order by convert(Datetime,Dat_Execution) desc"
        GRD(CodSql, Abonnement_Grd)
    End Sub
    Sub Deleting()
        If Cod_Abonnement_Text.Text = "" Then Exit Sub
        If MessageBoxRHP(552, Lib_Abonnement_Text.Text) = MsgBoxResult.Cancel Then Exit Sub
        'Supprimer le Modèle ou le Procedure
        If CnExecuting("Select count(*) from Param_Abonnement where Cod_Abonnement='" & Cod_Abonnement_Text.Text & "'").Fields(0).Value > 0 Then
            CnExecuting("delete from Param_Abonnement where Cod_Abonnement='" & Cod_Abonnement_Text.Text & "'")
        End If
        Reset_Form(Me)
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If Lib_Abonnement_Text.Text = "************" Then Lib_Abonnement_Text.Text = ""
        Appel_Zoom1("MS063", Cod_Abonnement_Text, Me)

    End Sub

    Private Sub Name_Ecran_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Abonnement_Text.TextChanged
        If Lib_Abonnement_Text.Text = "************" Then Exit Sub
        Request()
    End Sub

    Private Sub Saving()
        If Lib_Abonnement_Text.Text = "" Then
            MessageBoxRHP(553)
            Exit Sub
        End If

        If Dat_Deb_Application_Text.Text = "" Then
            MessageBoxRHP(554)
            Exit Sub
        End If
        If Typ_Frequence_Combo.SelectedValue = "" Then
            MessageBoxRHP(555)
            Exit Sub
        End If
        If Frequence.Value = 0 Then
            MessageBoxRHP(556)
            Exit Sub
        End If
        If Lundi_Check.Checked = False And
Mardi_Check.Checked = False And
Mercredi_Check.Checked = False And
Jeudi_Check.Checked = False And
Vendredi_Check.Checked = False And
Samedi_Check.Checked = False And
Dimanche_Check.Checked = False Then
            MessageBoxRHP(557)
            Exit Sub
        End If
        If CnExecuting("Select count(*) from Param_Abonnement where Source_Abonnement='" & Source_Abonnement.SelectedValue & "' and Ref_Abonnement='" & Ref_Abonnement.Text & "' and Cod_Abonnement<>'" & Cod_Abonnement_Text.Text & "'").Fields(0).Value > 0 Then
            MessageBoxRHP(558)
            Exit Sub
        End If
        Dim rs, rs1, rs2 As New ADODB.Recordset
        'Insertion du modèle d'édition dans Param_Abonnement
        rs.Open("Select * from Param_Abonnement where Cod_Abonnement='" & IsNull(Cod_Abonnement_Text.Text, -1) & "'", cn, 2, 2)
        If Not rs.EOF Then
            rs.Update()
        Else
            rs.AddNew()
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
        End If
        rs("Lib_Abonnement").Value = Lib_Abonnement_Text.Text.Trim
        rs("Actif").Value = Actif_Check.Checked
        rs("Source_Abonnement").Value = Source_Abonnement.SelectedValue
        rs("Ref_Abonnement").Value = Ref_Abonnement.Text
        rs("Typ_Pie_Abonnement").Value = Typ_Pie_Abonnement.Text
        rs("Dat_Mis_Application").Value = Dat_Deb_Application_Text.Text
        rs("Heure_Abonnement").Value = Heure_Abonnement_Mtxt.Text
        rs("Typ_Frequence").Value = Typ_Frequence_Combo.SelectedValue
        rs("Frequence").Value = Frequence.Value
        rs("Dat_Fin_Application").Value = Dat_Fin_Application_Text.Text
        rs("Statut").Value = 0
        rs("Dat_Next").Value = Nothing
        rs("Lundi").Value = Lundi_Check.Checked
        rs("Mardi").Value = Mardi_Check.Checked
        rs("Mercredi").Value = Mercredi_Check.Checked
        rs("Jeudi").Value = Jeudi_Check.Checked
        rs("Vendredi").Value = Vendredi_Check.Checked
        rs("Samedi").Value = Samedi_Check.Checked
        rs("Dimanche").Value = Dimanche_Check.Checked
        rs("Modified_By").Value = theUser.Login
        rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
        rs.Update()
        rs.Close()
        If Cod_Abonnement_Text.Text = "" Then
            Cod_Abonnement_Text.Text = CnExecuting("select max(Cod_Abonnement) from Param_Abonnement where ltrim(rtrim(Lib_Abonnement))='" & Lib_Abonnement_Text.Text.Trim & "' and Modified_By='" & theUser.id_User & "'").Fields(0).Value
        End If
    End Sub
    Private Sub Adding()
        Reset_Form(Me)
        Actif_Check.Checked = True
        Lib_Abonnement_Text.Select()
        Dat_Deb_Application_Text.Text = Date.Now.Date
    End Sub
    Sub Dupliquer()
        If Cod_Abonnement_Text.Text = "" Then Exit Sub

        Lib_Abonnement_Text.Text = "************"
        Cod_Abonnement_Text.Text = ""
        Actif_Check.Checked = True
    End Sub
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Calender(Dat_Deb_Application_Text, Me)
    End Sub
    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Calender(Dat_Fin_Application_Text, Me)
    End Sub
    Sub Enregistrer()
        Saving()
    End Sub
    Sub Nouveau()
        Adding()
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If ZoomCod = "" Then
            Lib_Ref_Abonnement.Text = ""
        Else
            Appel_Zoom2(ZoomCod, ZoomLib, ZoomTbl, ZoomWhere, Ref_Abonnement, Me)
            Lib_Ref_Abonnement.Text = FindLibelle(ZoomLib, ZoomCod, Ref_Abonnement.Text, ZoomTbl)
        End If
    End Sub
    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        If ZoomCod0 = "" Then
            Lib_Typ_Pie_Abonnement.Text = ""
        Else
            Appel_Zoom2(ZoomCod0, ZoomLib0, ZoomTbl0, ZoomWhere0, Typ_Pie_Abonnement, Me)
            Lib_Typ_Pie_Abonnement.Text = FindLibelle(ZoomLib0, ZoomCod0, Typ_Pie_Abonnement.Text, ZoomTbl0)
        End If

    End Sub

    Private Sub Source_Abonnement_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Source_Abonnement.DropDownClosed
        Ref_Abonnement.Text = ""
        Lib_Ref_Abonnement.Text = ""
        Typ_Pie_Abonnement.Text = ""
        Lib_Typ_Pie_Abonnement.Text = ""
        UpdatingSource()
    End Sub
    Sub UpdatingSource()
        Select Case Source_Abonnement.SelectedValue
            Case "Param_Query"
                ZoomCod = "Cod_Query"
                ZoomLib = "Nom_Query"
                ZoomTbl = "Param_Query"
                ZoomWhere = "1=1"
                ZoomCod0 = "Code"
                ZoomLib0 = "Libelle"
                ZoomTbl0 = "(select 'QRY' as Code,'Requete' as Libelle) f"
                ZoomWhere0 = "1=1"
            Case "Mailing"
                ZoomCod = "Cod_Mailing"
                ZoomLib = "Lib_Mailing"
                ZoomTbl = "Mailing"
                ZoomWhere = "1=1"
                ZoomCod0 = "Code"
                ZoomLib0 = "Libelle"
                ZoomTbl0 = "(select 'EML' as Code,'Compagne Mail' as Libelle) f"
                ZoomWhere0 = "1=1"
            Case "Ctb_Saisie_Ctb"
                ZoomCod = "Num_Lot"
                ZoomLib = "Lib_Lot + ' du ' + Dat_Ecr "
                ZoomTbl = "Compta_His_Gnr"
                ZoomWhere = "Org_Ecr='H'"
                ZoomCod0 = "Code"
                ZoomLib0 = "Libelle"
                ZoomTbl0 = "(select 'HC' as Code,'Pièce Comptable' as Libelle) f"
                ZoomWhere0 = "1=1"
            Case Else
                ZoomCod = ""
                ZoomLib = ""
                ZoomTbl = ""
                ZoomWhere = ""
                ZoomCod0 = ""
                ZoomLib0 = ""
                ZoomTbl0 = ""
                ZoomWhere0 = ""
        End Select
    End Sub
    Private Sub Param_Abonnement_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
    End Sub
End Class