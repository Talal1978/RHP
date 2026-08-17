Public Class Admin_Profil_Agent
    'Affectation de masse des profils portail (Controle_Profile) aux agents :
    'met à jour RH_Agent.Cod_Profile (vide = pas d'affectation -> le profil
    'portail par défaut s'applique au login du portail).
    Dim TblOrig As New Dictionary(Of String, String)
    Dim Save_D As ud_btn
    Dim Request_D As ud_btn

    Private Sub Admin_Profil_Agent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Request_D = dictButtons("Request_D")
        chargementCombo()
        Requesting()
    End Sub

    Sub chargementCombo()
        'Liste des profils actifs + ligne vide "(aucun profil)" (Cod_Profile NULL)
        Combo_GRD_Linked(Cod_Profile, "select '' as Cod_Profile, N'(aucun profil)' as Lib_Profile, 0 as Rang " &
                                      "union all " &
                                      "select convert(nvarchar(10),Cod_Profile), Lib_Profile, 1 from Controle_Profile where isnull(Actif,1)=1 " &
                                      "order by Rang, Lib_Profile")
    End Sub

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
            Dim Tbl As DataTable = DATA_READER_GRD("select a.Matricule,isnull(a.Nom_Agent,'') as Nom_Agent,isnull(a.Prenom_Agent,'') as Prenom_Agent," &
                                                   "isnull(e.Lib_Entite,'') as Lib_Entite,isnull(convert(nvarchar(10),a.Cod_Profile),'') as Cod_Profile " &
                                                   "from RH_Agent a " &
                                                   "outer apply (select top 1 Lib_Entite from Org_Entite o where o.Cod_Entite=a.Cod_Entite and o.id_Societe=a.id_Societe) e " &
                                                   "where" & swhere & " order by a.Nom_Agent, a.Prenom_Agent")
            TblOrig.Clear()
            Grd.Rows.Clear()
            With Tbl
                For i = 0 To .Rows.Count - 1
                    Dim mat As String = IsNull(.Rows(i)("Matricule"), "")
                    Dim prf As String = IsNull(.Rows(i)("Cod_Profile"), "")
                    Grd.Rows.Add(mat, IsNull(.Rows(i)("Nom_Agent"), ""), IsNull(.Rows(i)("Prenom_Agent"), ""), IsNull(.Rows(i)("Lib_Entite"), ""), prf)
                    TblOrig(mat) = prf
                Next
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Sub Saving()
        Try
            Grd.EndEdit()
            Dim nb As Integer = 0
            With Grd
                For i = 0 To .RowCount - 1
                    Dim mat As String = IsNull(.Item(Matricule.Index, i).Value, "")
                    If mat = "" Then Continue For
                    Dim prf As String = IsNull(.Item(Cod_Profile.Index, i).Value, "").Trim
                    If prf <> "" AndAlso Not IsNumeric(prf) Then Continue For
                    If TblOrig.ContainsKey(mat) AndAlso TblOrig(mat) = prf Then Continue For
                    CnExecuting("update RH_Agent set Cod_Profile=" & If(prf = "", "null", prf) &
                                ", Modified_By='" & theUser.Login.Replace("'", "''") & "', Dat_Modif=getdate() " &
                                "where Matricule='" & mat.Replace("'", "''") & "' and id_Societe=" & Societe.id_Societe)
                    nb += 1
                Next
            End With
            MessageBoxRHP(352)
            Requesting()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd.DataError
        'Valeur de combo absente de la liste : ignorée (la cellule reste vide)
    End Sub
End Class
