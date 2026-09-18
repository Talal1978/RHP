Public Class Admin_Dashboard_Config
    'Duplication de la configuration du tableau de bord du portail (table
    'Portail_Dashboard_Config — widgets + sections, écrite par le portail à
    'chaque personnalisation) :
    '  - copie de la configuration d'un agent source vers les agents cochés
    '    de la grille (bouton "Dupliquer la configuration") ;
    '  - enregistrement de cette configuration comme modèle par défaut,
    '    global (G) ou par profil (P) (bouton "Enregistrer comme modèle") ;
    'les modèles s'appliquent aux utilisateurs sans configuration
    'personnelle. Résolution côté portail : U (agent) > P (profil) > G.
    Dim Save_D As ud_btn
    Dim Request_D As ud_btn
    Dim Model_D As ud_btn

    Private Sub Admin_Dashboard_Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Request_D = dictButtons("Request_D")
        Model_D = dictButtons("Model_D")
        chargementComboModele()
        Requesting()
    End Sub

    Sub chargementComboModele()
        'Cibles du modèle par défaut : globale (G) ou un profil actif (P:<cod>)
        Dim Tbl As DataTable = DATA_READER_GRD("select 'G' as Cle, N'Modèle global (tous les utilisateurs)' as Lib, 0 as Rang " &
                                               "union all " &
                                               "select 'P:' + convert(nvarchar(10), Cod_Profile), N'Profil : ' + Lib_Profile, 1 " &
                                               "from Controle_Profile where isnull(Actif,1)=1 order by Rang, Lib")
        Modele_cmb.DataSource = Tbl
        Modele_cmb.ValueMember = "Cle"
        Modele_cmb.DisplayMember = "Lib"
        Modele_cmb.SelectedIndex = -1
    End Sub

    Private Sub Agent_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Agent_lbl.LinkClicked
        Appel_Zoom1("MS018", Matricule_Source_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
    End Sub

    Private Sub Matricule_Source_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_Source_txt.TextChanged
        Dim mat As String = Matricule_Source_txt.Text.Trim
        If mat = "" Then
            Nom_Source_txt.Text = ""
            Info_Config_lbl.Text = "Sélectionnez l'agent dont vous souhaitez réutiliser la configuration du tableau de bord."
        Else
            Dim Tbl As DataTable = DATA_READER_GRD("select isnull(Nom_Agent,'') + ' ' + isnull(Prenom_Agent,'') as Nom from RH_Agent " &
                                                   "where Matricule='" & mat.Replace("'", "''") & "' and id_Societe=" & Societe.id_Societe)
            Nom_Source_txt.Text = If(Tbl.Rows.Count > 0, IsNull(Tbl.Rows(0)("Nom"), ""), "")
            ChargerInfoConfig()
        End If
        Requesting()
    End Sub

    Sub ChargerInfoConfig()
        'Présence et fraîcheur de la configuration source en base
        Dim Tbl As DataTable = LireConfigSource()
        If Tbl.Rows.Count = 0 Then
            Info_Config_lbl.Text = "Aucune configuration en base pour cet agent (son tableau de bord reste celui par défaut)."
        Else
            Dim d As String = ""
            If Not IsDBNull(Tbl.Rows(0)("Dat_Modif")) Then d = CDate(Tbl.Rows(0)("Dat_Modif")).ToString("dd/MM/yyyy HH:mm")
            Info_Config_lbl.Text = "Configuration du " & d & " (par " & IsNull(Tbl.Rows(0)("Modified_By"), "") & ")."
        End If
    End Sub

    Function LireConfigSource() As DataTable
        Dim mat As String = Matricule_Source_txt.Text.Trim
        If mat = "" Then Return New DataTable()
        Return DATA_READER_GRD("select Config_Json, Dat_Modif, Modified_By from Portail_Dashboard_Config " &
                               "where Typ_Config='U' and Cle_Config='" & mat.Replace("'", "''") & "' and id_Societe=" & Societe.id_Societe)
    End Function

    Function ValiderSource() As String
        'JSON de la configuration source, ou "" si inexploitable
        If Matricule_Source_txt.Text.Trim = "" Then
            ShowMessageBox("Sélectionnez un agent source.", "Configuration source", MessageBoxButtons.OK, msgIcon.Stop)
            Return ""
        End If
        Dim Tbl As DataTable = LireConfigSource()
        If Tbl.Rows.Count = 0 Then
            ShowMessageBox("Cet agent n'a aucune configuration en base." & vbCrLf &
                           "Il doit avoir personnalisé son tableau de bord sur le portail (ou s'y être connecté).",
                           "Configuration source", MessageBoxButtons.OK, msgIcon.Stop)
            Return ""
        End If
        Return IsNull(Tbl.Rows(0)("Config_Json"), "")
    End Function

    Private Sub Entite_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Entite_lbl.LinkClicked
        Appel_Zoom1("MS010", Cod_Entite_txt, Me)
    End Sub

    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
        Requesting()
    End Sub

    Sub Requesting()
        Cursor = Cursors.WaitCursor
        Try
            Dim swhere As String = " a.id_Societe=" & Societe.id_Societe & " and a.Dat_Sortie is null"
            If Cod_Entite_txt.Text.Trim <> "" Then
                swhere &= " and a.Cod_Entite='" & Cod_Entite_txt.Text.Trim.Replace("'", "''") & "'"
            End If
            'L'agent source n'est jamais sa propre cible
            Dim mat As String = Matricule_Source_txt.Text.Trim
            If mat <> "" Then
                swhere &= " and a.Matricule<>'" & mat.Replace("'", "''") & "'"
            End If
            Dim Tbl As DataTable = DATA_READER_GRD("select a.Matricule,isnull(a.Nom_Agent,'') as Nom_Agent,isnull(a.Prenom_Agent,'') as Prenom_Agent," &
                                                   "isnull(e.Lib_Entite,'') as Lib_Entite,isnull(p.Lib_Profile,'') as Lib_Profile," &
                                                   "case when c.Cle_Config is null then '' else 'Oui' end as Config_Existante " &
                                                   "from RH_Agent a " &
                                                   "outer apply (select top 1 Lib_Entite from Org_Entite o where o.Cod_Entite=a.Cod_Entite and o.id_Societe=a.id_Societe) e " &
                                                   "left join Controle_Profile p on p.Cod_Profile=a.Cod_Profile " &
                                                   "left join Portail_Dashboard_Config c on c.Typ_Config='U' and c.Cle_Config=a.Matricule and c.id_Societe=a.id_Societe " &
                                                   "where" & swhere & " order by a.Nom_Agent, a.Prenom_Agent")
            Grd.Rows.Clear()
            With Tbl
                For i = 0 To .Rows.Count - 1
                    Grd.Rows.Add(True, IsNull(.Rows(i)("Matricule"), ""), IsNull(.Rows(i)("Nom_Agent"), ""), IsNull(.Rows(i)("Prenom_Agent"), ""),
                                 IsNull(.Rows(i)("Lib_Entite"), ""), IsNull(.Rows(i)("Lib_Profile"), ""), IsNull(.Rows(i)("Config_Existante"), ""))
                Next
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Function EstCoche(ByVal i As Integer) As Boolean
        Dim v As Object = Grd.Item(Appliquer.Index, i).Value
        If v Is Nothing OrElse IsDBNull(v) Then Return False
        Dim b As Boolean = False
        Boolean.TryParse(v.ToString(), b)
        Return b
    End Function

    Sub Saving()
        'Duplication de la configuration source vers les agents cochés
        Dim json As String = ValiderSource()
        If json = "" Then Exit Sub
        Grd.EndEdit()
        Dim cibles As New List(Of String)
        For i = 0 To Grd.RowCount - 1
            If Not EstCoche(i) Then Continue For
            Dim mat As String = IsNull(Grd.Item(Matricule.Index, i).Value, "")
            If mat <> "" Then cibles.Add(mat)
        Next
        If cibles.Count = 0 Then
            ShowMessageBox("Cochez au moins un agent cible.", "Duplication", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If ShowMessageBox("Dupliquer la configuration de " & Nom_Source_txt.Text.Trim & " vers " & cibles.Count & " agent(s) ?" &
                          If(Ecraser_chk.Checked, "", vbCrLf & "Les agents ayant déjà une configuration personnelle seront ignorés."),
                          "Duplication", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Exit Sub
        Cursor = Cursors.WaitCursor
        Try
            Dim nbOk As Integer = 0, nbSkip As Integer = 0
            Dim login As String = theUser.Login.Replace("'", "''")
            Dim jsonEsc As String = json.Replace("'", "''")
            For Each mat In cibles
                Dim matEsc As String = mat.Replace("'", "''")
                Dim existe As Boolean = DATA_READER_GRD("select 1 as x from Portail_Dashboard_Config " &
                                                        "where Typ_Config='U' and Cle_Config='" & matEsc & "' and id_Societe=" & Societe.id_Societe).Rows.Count > 0
                If existe AndAlso Not Ecraser_chk.Checked Then
                    nbSkip += 1
                    Continue For
                End If
                CnExecuting("merge into Portail_Dashboard_Config as tbl " &
                            "using (values ('U', N'" & matEsc & "', " & Societe.id_Societe & ", N'" & jsonEsc & "', N'" & login & "')) as src (Typ_Config, Cle_Config, id_Societe, Config_Json, Modified_By) " &
                            "on tbl.Typ_Config=src.Typ_Config and tbl.Cle_Config=src.Cle_Config and tbl.id_Societe=src.id_Societe " &
                            "when matched then update set Config_Json=src.Config_Json, Dat_Modif=getdate(), Modified_By=src.Modified_By " &
                            "when not matched then insert (Typ_Config, Cle_Config, id_Societe, Config_Json, Modified_By) " &
                            "values (src.Typ_Config, src.Cle_Config, src.id_Societe, src.Config_Json, src.Modified_By);")
                nbOk += 1
            Next
            MessageBoxRHP(352)
            If nbSkip > 0 Then
                ShowMessageBox(nbSkip & " agent(s) ignoré(s) (configuration existante non écrasée).", "Duplication", MessageBoxButtons.OK, msgIcon.Information)
            End If
            Requesting()
        Catch ex As Exception
            ErrorMsg(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Sub SavingModel()
        'Enregistrement de la configuration source comme modèle par défaut
        Dim json As String = ValiderSource()
        If json = "" Then Exit Sub
        Dim cle As String = IsNull(Modele_cmb.SelectedValue, "")
        If cle = "" Then
            ShowMessageBox("Sélectionnez la cible du modèle par défaut (globale ou un profil).", "Modèle par défaut", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        Dim typ As String = "G", cleCfg As String = "*"
        If cle.StartsWith("P:") Then
            typ = "P"
            cleCfg = cle.Substring(2)
        End If
        If ShowMessageBox("Enregistrer la configuration de " & Nom_Source_txt.Text.Trim & " comme « " & Modele_cmb.Text.Trim & " » ?" & vbCrLf &
                          "Elle s'appliquera aux utilisateurs concernés n'ayant pas de configuration personnelle.",
                          "Modèle par défaut", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Exit Sub
        Try
            CnExecuting("merge into Portail_Dashboard_Config as tbl " &
                        "using (values ('" & typ & "', N'" & cleCfg.Replace("'", "''") & "', -1, N'" & json.Replace("'", "''") & "', N'" & theUser.Login.Replace("'", "''") & "')) as src (Typ_Config, Cle_Config, id_Societe, Config_Json, Modified_By) " &
                        "on tbl.Typ_Config=src.Typ_Config and tbl.Cle_Config=src.Cle_Config and tbl.id_Societe=src.id_Societe " &
                        "when matched then update set Config_Json=src.Config_Json, Dat_Modif=getdate(), Modified_By=src.Modified_By " &
                        "when not matched then insert (Typ_Config, Cle_Config, id_Societe, Config_Json, Modified_By) " &
                        "values (src.Typ_Config, src.Cle_Config, src.id_Societe, src.Config_Json, src.Modified_By);")
            MessageBoxRHP(352)
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd.DataError
        'Valeur de cellule non convertible : ignorée (la cellule reste vide)
    End Sub
End Class
