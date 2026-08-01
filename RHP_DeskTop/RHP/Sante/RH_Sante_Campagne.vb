Public Class RH_Sante_Campagne
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Generer_D As ud_btn

    Sub Chargement()
        If Save_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Generer_D = dictButtons("Generer_D")
        End If
        If Typ_Visite_cbo.Items.Count = 0 Then Typ_Visite_cbo.fromRubrique("Typ_Visite")
        If Statut_cbo.Items.Count = 0 Then Statut_cbo.fromRubrique("Statut_Campagne")
        If Grd_Convocations.Columns.Count > 0 AndAlso CType(Grd_Convocations.Columns("Statut_Convocation"), DataGridViewComboBoxColumn).Items.Count = 0 Then
            Combo_GRD(CType(Grd_Convocations.Columns("Statut_Convocation"), DataGridViewComboBoxColumn), "Statut_Convocation")
        End If
    End Sub

    Private Sub RH_Sante_Campagne_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Not Sante_CheckAccess("ADMIN", Me.Name) Then
            ShowMessageBox("Accès non autorisé.", "Accès", MessageBoxButtons.OK, msgIcon.Stop)
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If
    End Sub

    Sub Request()
        Chargement()
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT * FROM RH_Sante_Campagne where Cod_Campagne='" & Cod_Campagne_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        With Tbl
            If .Rows.Count > 0 Then
                Lib_Campagne_txt.Text = IsNull(.Rows(0)("Lib_Campagne"), "")
                Typ_Visite_cbo.SelectedValue = IsNull(.Rows(0)("Typ_Visite"), "")
                Dat_Deb_txt.Text = IsNull(.Rows(0)("Dat_Deb"), "")
                Dat_Fin_txt.Text = IsNull(.Rows(0)("Dat_Fin"), "")
                Cod_Medecin_txt.Text = IsNull(.Rows(0)("Cod_Medecin"), "")
                Lieu_txt.Text = IsNull(.Rows(0)("Lieu"), "")
                Statut_cbo.SelectedValue = IsNull(.Rows(0)("Statut"), "")
            End If
        End With
        RequestConvocations()
    End Sub

    Sub RequestConvocations()
        Dim Tbl As DataTable = DATA_READER_GRD(
            "select Matricule, Dat_Convocation, Heure, Statut_Convocation, Dat_Envoi, Num_Visite, Commentaire, RowId " &
            "from RH_Sante_Convocation where Cod_Campagne='" & Cod_Campagne_txt.Text & "' and id_Societe=" & Societe.id_Societe & " order by Dat_Convocation")
        With Grd_Convocations
            .Rows.Clear()
            If .Columns.Count > 0 Then
                For i = 0 To Tbl.Rows.Count - 1
                    .Rows.Add(Tbl.Rows(i)("Matricule"), Tbl.Rows(i)("Dat_Convocation"), Tbl.Rows(i)("Heure"), Tbl.Rows(i)("Statut_Convocation"), Tbl.Rows(i)("Dat_Envoi"), Tbl.Rows(i)("Num_Visite"), Tbl.Rows(i)("Commentaire"))
                    .Rows(i).Tag = Tbl.Rows(i)("RowId")
                Next
            End If
        End With
    End Sub

    Sub Enregistrer()
        If Lib_Campagne_txt.Text.Trim = "" Then
            ShowMessageBox("Libellé campagne non renseigné", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim codCamp As String = Cod_Campagne_txt.Text
        Dim estCreation As Boolean = (codCamp = "")
        If estCreation Then
            Dim rs = CnExecuting("select 'CP'+convert(nvarchar(10)," & Societe.id_Societe & ")+'-'+right('000'+convert(nvarchar(3),isnull(max(racine),0)+1),3) as num from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end) as racine from RH_Sante_Campagne outer apply(select RIGHT(Cod_Campagne,3) as racine)n where id_Societe=" & Societe.id_Societe & ")f")
            codCamp = rs.Fields(0).Value
        End If
        Dim ok As Boolean
        If estCreation Then
            ok = Sante_Execute(
                "insert into RH_Sante_Campagne (Cod_Campagne, id_Societe, Lib_Campagne, Typ_Visite, Dat_Deb, Dat_Fin, Cod_Medecin, Lieu, Statut, Dat_Crea, Created_By) " &
                "values (?,?,?,?,?,?,?,?,?,getdate(),?)",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 20, codCamp},
                 {"p2", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe},
                 {"p3", ADODB.DataTypeEnum.adVarWChar, 150, Lib_Campagne_txt.Text},
                 {"p4", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Typ_Visite_cbo.SelectedValue, "")},
                 {"p5", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Deb_txt.Text), CDate(Dat_Deb_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p6", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Fin_txt.Text), CDate(Dat_Fin_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Medecin_txt.Text},
                 {"p8", ADODB.DataTypeEnum.adVarWChar, 150, Lieu_txt.Text},
                 {"p9", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_cbo.SelectedValue, "")},
                 {"p10", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login}})
        Else
            ok = Sante_Execute(
                "update RH_Sante_Campagne set Lib_Campagne=?, Typ_Visite=?, Dat_Deb=?, Dat_Fin=?, Cod_Medecin=?, Lieu=?, Statut=?, Dat_Modif=getdate(), Modified_By=? " &
                "where Cod_Campagne=? and id_Societe=?",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 150, Lib_Campagne_txt.Text},
                 {"p2", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Typ_Visite_cbo.SelectedValue, "")},
                 {"p3", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Deb_txt.Text), CDate(Dat_Deb_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p4", ADODB.DataTypeEnum.adDate, 0, If(EstDate(Dat_Fin_txt.Text), CDate(Dat_Fin_txt.Text), DirectCast(DBNull.Value, Object))},
                 {"p5", ADODB.DataTypeEnum.adVarWChar, 20, Cod_Medecin_txt.Text},
                 {"p6", ADODB.DataTypeEnum.adVarWChar, 150, Lieu_txt.Text},
                 {"p7", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Statut_cbo.SelectedValue, "")},
                 {"p8", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                 {"p9", ADODB.DataTypeEnum.adVarWChar, 20, codCamp},
                 {"p10", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}})
        End If
        If Not ok Then Return

        ' Synchronisation des convocations (statuts modifiables dans la grille)
        Grd_Convocations.EndEdit()
        For i = 0 To Grd_Convocations.RowCount - 1
            If Grd_Convocations.Rows(i).IsNewRow Then Continue For
            Dim tagId As String = IsNull(Grd_Convocations.Rows(i).Tag, "")
            If tagId = "" Then Continue For
            Sante_Execute(
                "update RH_Sante_Convocation set Statut_Convocation=?, Heure=?, Dat_Convocation=?, Commentaire=?, Dat_Modif=getdate(), Modified_By=? where RowId=? and id_Societe=?",
                {{"p1", ADODB.DataTypeEnum.adVarWChar, 10, IsNull(Grd_Convocations.Item("Statut_Convocation", i).Value, "")},
                 {"p2", ADODB.DataTypeEnum.adVarWChar, 5, IsNull(Grd_Convocations.Item("Heure", i).Value, "")},
                 {"p3", ADODB.DataTypeEnum.adDate, 0, If(IsDate(Grd_Convocations.Item("Dat_Convocation", i).Value), CDate(Grd_Convocations.Item("Dat_Convocation", i).Value), DirectCast(DBNull.Value, Object))},
                 {"p4", ADODB.DataTypeEnum.adVarWChar, 250, IsNull(Grd_Convocations.Item("Commentaire", i).Value, "")},
                 {"p5", ADODB.DataTypeEnum.adVarWChar, 50, theUser.Login},
                 {"p6", ADODB.DataTypeEnum.adInteger, 0, CInt(tagId)},
                 {"p7", ADODB.DataTypeEnum.adInteger, 0, Societe.id_Societe}})
        Next
        Sante_Audit(IIf(estCreation, "CREA", "MODI"), "RH_Sante_Campagne", codCamp)
        ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
        If Cod_Campagne_txt.Text = "" Then Cod_Campagne_txt.Text = codCamp Else Request()
    End Sub

    Sub GenererConvocations()
        If Cod_Campagne_txt.Text = "" Then
            ShowMessageBox("Enregistrez d'abord la campagne.", "Générer", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        Dim datConv As Object = If(EstDate(Dat_Deb_txt.Text), CDate(Dat_Deb_txt.Text), Now)
        Dim rs = CnExecuting(
            "insert into RH_Sante_Convocation (Cod_Campagne, id_Societe, Matricule, Dat_Convocation, Heure, Statut_Convocation, Dat_Crea, Created_By) " &
            "select '" & Cod_Campagne_txt.Text & "', " & Societe.id_Societe & ", d.Matricule, '" & CDate(datConv).ToString("yyyy-MM-dd") & "', '', 'PRE', getdate(), '" & theUser.Login & "' " &
            "from RH_Sante_Dossier d where d.id_Societe=" & Societe.id_Societe & " and isnull(d.Archive,'false')='false' " &
            " and (d.Dat_Prochaine_Visite is null or d.Dat_Prochaine_Visite <= " & IIf(EstDate(Dat_Fin_txt.Text), "'" & CDate(Dat_Fin_txt.Text).ToString("yyyy-MM-dd") & "'", "'2045-12-31'") & ") " &
            " and not exists (select 1 from RH_Sante_Convocation c where c.Cod_Campagne='" & Cod_Campagne_txt.Text & "' and c.id_Societe=" & Societe.id_Societe & " and c.Matricule=d.Matricule)" &
            " select @@ROWCOUNT")
        Dim nb As Integer = 0
        If rs IsNot Nothing AndAlso Not rs.EOF Then nb = CInt(IsNull(rs.Fields(0).Value, 0))
        Sante_Audit("CREA", "RH_Sante_Convocation", Cod_Campagne_txt.Text, "", True, nb & " convocation(s) générée(s)")
        ShowMessageBox(nb & " convocation(s) générée(s) (agents dont l'échéance tombe dans la campagne ou sans visite).", "Générer", MessageBoxButtons.OK, msgIcon.Information)
        RequestConvocations()
    End Sub

    Sub Deleting()
        If ShowMessageBox("Supprimer cette campagne et ses convocations non réalisées ?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Sante_Convocation where Cod_Campagne='" & Cod_Campagne_txt.Text & "' and id_Societe=" & Societe.id_Societe & " and isnull(Num_Visite,'')=''")
        CnExecuting("delete from RH_Sante_Campagne where Cod_Campagne='" & Cod_Campagne_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Sante_Audit("SUPP", "RH_Sante_Campagne", Cod_Campagne_txt.Text)
        Reset_Form(Me)
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        Grd_Convocations.Rows.Clear()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS305", Cod_Campagne_txt, Me)
    End Sub

    Private Sub Cod_Campagne_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Campagne_txt.TextChanged
        Request()
    End Sub

    Private Sub Cod_Medecin_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Medecin_Link.LinkClicked
        Appel_Zoom1("MS306", Cod_Medecin_txt, Me)
    End Sub

    Private Sub Cod_Medecin_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Medecin_txt.TextChanged
        Nom_Medecin_txt.Text = FindLibelle("Nom + ' ' + isnull(Prenom,'')", "Cod_Intervenant", Cod_Medecin_txt.Text, "Param_Sante_Intervenant")
    End Sub

    Private Sub Dat_Deb_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Deb_Link.LinkClicked
        Appel_Calender(Dat_Deb_txt, Me)
    End Sub

    Private Sub Dat_Fin_Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Fin_Link.LinkClicked
        Appel_Calender(Dat_Fin_txt, Me)
    End Sub
End Class
