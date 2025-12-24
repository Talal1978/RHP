Public Class Mailing_Destinataires
    Dim TblTiers As New DataTable
    Dim match As DataGridViewCell() = Nothing


    Private Sub Mailing_Destinataires_Load(sender As Object, e As EventArgs) Handles Me.Load

        With Grd_Destinataire
            .ContextMenuStrip = AddContextMenu(True, True, True, True, True, True, True, True)
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
        Request()
    End Sub
    Sub chargerPartenaire()
        Try
            Dim rs5 As New ADODB.Recordset
            Dim CodSql As String = "insert into Mailing_Destinataire (Email, Civilite, Nom, Prenom, Typ_Tiers, Cod_Tiers, Nom_Tiers, Fonction,Liste)
    SELECT  Email, Civilite, Nom_Contact, Prenom_Contact, Typ_Tiers, Cod_Clt, Nom_Clt, Fonction,case  Typ_Tiers when 'Fou' then '0,2,3,' when 'Clt' then '0,1,3,' else '0,' end Liste
                From Sys_Part_Tiers_Contact c
    where not exists(select Email from Mailing_Destinataire where Email=c.Email)"
            rs5.Open("select * from Param_Query where Cod_Query='R_Mailing_Destinataire'", cn, 2, 2)
            If rs5.EOF Then
                rs5.AddNew()
            Else
                rs5.Update()
            End If
            rs5("Cod_Query").Value = "R_Mailing_Destinataire"
            rs5("Nom_Query").Value = "Importation des email des tiers"
            rs5("Cod_Sql").Value = CodSql
            rs5("HeaderVisible").Value = False
            rs5("Resume").Value = False
            rs5("Typ_Query").Value = "S"
            rs5("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
            rs5("Created_By").Value = 1
            rs5("Dat_Modif").Value = rs5("Dat_Crea").Value
            rs5("Modified_By").Value = 1
            rs5.Update()
            rs5.Close()

            CodSql = "  if (Select count(*) from Param_Abonnement where Ref_Abonnement='R_Mailing_Destinataire')=0" &
    "  begin" &
    "  insert into Param_Abonnement (Lib_Abonnement, Source_Abonnement, Ref_Abonnement,Typ_Pie_Abonnement, Actif, Dat_Mis_Application, Heure_Abonnement, Typ_Frequence, " &
    "                        Frequence, Statut, Dat_Fin_Application, Dat_Next, Lundi, Mardi, Mercredi, Jeudi, Vendredi, Samedi, Dimanche, Dat_Crea, Created_By, Dat_Modif, Modified_By)" &
    "  SELECT      'Importation automatique des email des tiers', 'Param_Query', 'R_Mailing_Destinataire', 'QRY', 1, convert(nvarchar(10),getdate(),103), convert(nvarchar(10),getdate(),8), 'Second', " &
    "                        1, 0, '31/12/2099', null, 1, 1, 1, 1, 1, 1, 1, getdate(), 1, getdate(), 1" &
    "  end"

            CnExecuting(CodSql)
            MessageBoxRHP(1)
        Catch ex As Exception

        End Try
    End Sub
    Sub Importer()
        Dim frm As New Mailing_Dest_Import
        With frm
            .SrcForm = Me
            newShowEcran(frm, True)
        End With
    End Sub
    Sub Nouveau()
        With Grd_Destinataire
            .FirstDisplayedCell = .Item(0, .RowCount - 1)
        End With
    End Sub
    Sub Deleting()

    End Sub
    Sub Enregistrer()
        Try
            Dim TblTiers As DataTable = DATA_READER_GRD("select case when Typ_Tiers='F' then 'Fou' else 'Clt' end as Typ_Tiers
    ,Cod_Clt as Cod_Tiers,Nom_Clt as Nom_Tiers 
    from Sys_Part_Tiers")
            Dim rnd As New Random
            Dim oflag As Long = rnd.Next(1234, 789654)

            With Grd_Destinataire
                For i = 0 To .RowCount - 2
                    .Rows(i).Selected = False
                    If Not estEmail(.Item(Email.Index, i).Value) Then
                        ShowMessageBox("Erreur format mail", "Vérification des emails", MessageBoxButtons.OK, msgIcon.Stop)
                        .FirstDisplayedCell = .Item(Email.Index, i)
                        .CurrentCell = .Item(Email.Index, i)
                        .Item(Email.Index, i).Selected = True
                        Return
                    End If
                    If IsNull(.Item(Typ_Tiers.Index, i).Value, "").Trim = "Clt" Or IsNull(.Item(Typ_Tiers.Index, i).Value, "").Trim = "Fou" Then
                        If TblTiers.Select("Typ_Tiers='" & IsNull(.Item(Typ_Tiers.Index, i).Value, "").Trim & "' and Cod_Tiers='" & IsNull(.Item(Cod_Tiers.Index, i).Value, "").Trim & "'").Length = 0 Then
                            ShowMessageBox("Erreur Tiers : " & vbCrLf & "Le tiers : " & .Item(Tiers.Index, i).Value & " n'est pas enregistré en tant que " & IIf(IsNull(.Item(Typ_Tiers.Index, i).Value, "").Trim = "Fou", "Fournisseur", "Client"), "Vérification des emails", MessageBoxButtons.OK, msgIcon.Stop)
                            .FirstDisplayedCell = .Item(Email.Index, i)
                            .CurrentCell = .Item(Email.Index, i)
                            .Item(Email.Index, i).Selected = True
                            Return
                        End If
                    End If
                Next
                For i = 0 To .RowCount - 2
                    For j = i To .RowCount - 2
                        If i <> j And .Item(Email.Index, i).Value.ToString.Trim.ToUpper = .Item(Email.Index, j).Value.ToString.Trim.ToUpper _
                            And IsNull(.Item(Typ_Tiers.Index, i).Value, "").Trim.ToUpper = IsNull(.Item(Typ_Tiers.Index, j).Value, "").Trim.ToUpper Then
                            ShowMessageBox("Mail en double", "Vérification des emails", MessageBoxButtons.OK, msgIcon.Stop)
                            .FirstDisplayedCell = .Item(Email.Index, i)
                            .Rows(i).Selected = True
                            .Rows(j).Selected = True
                            Return
                        End If
                    Next
                Next
                Dim rs As New ADODB.Recordset
                For i = 0 To .RowCount - 2
                    rs.Open("select top 1 * from Mailing_Destinataire where id_Destinataire=" & IsNull(.Item(id_Destinataire.Index, i).Value, -9999), cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        If .Item(Typ_Tiers.Index, i).Value = "Fou" Then
                            rs("Liste").Value = "0,2,3,"
                        ElseIf .Item(Typ_Tiers.Index, i).Value = "Clt" Then
                            rs("Liste").Value = "0,1,3,"
                        Else
                            rs("Liste").Value = "0,"
                        End If
                    Else
                        rs.Update()
                    End If
                    rs("Email").Value = .Item(Email.Index, i).Value
                    rs("Civilite").Value = .Item(Civilite.Index, i).Value
                    rs("Nom").Value = .Item(Nom.Index, i).Value
                    rs("Prenom").Value = .Item(Prenom.Index, i).Value
                    rs("Typ_Tiers").Value = .Item(Typ_Tiers.Index, i).Value
                    rs("Cod_Tiers").Value = .Item(Cod_Tiers.Index, i).Value
                    rs("Nom_Tiers").Value = .Item(Tiers.Index, i).Value
                    rs("Fonction").Value = .Item(Fonction.Index, i).Value
                    rs("Flag_Maj").Value = oflag
                    rs.Update()
                    rs.Close()
                Next
            End With
            CnExecuting("delete from Mailing_Destinataire where isnull(Flag_Maj,0)<>'" & oflag & "'")
            MessageBoxRHP(1)
            Request()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Requesting()
        Request()
    End Sub
    Sub Request()
        Return
        Try
            If Civilite.Items.Count = 0 Then Combo_GRD(Civilite, "Civilite_Combo")
            Dim C1, C2, C3, C4, C5, C6, C7, C8, C9 As String
            Grd_Destinataire.Rows.Clear()
            Dim Tbl As DataTable = DATA_READER_GRD("select  id_Destinataire, Email, Civilite, Nom, Prenom, Typ_Tiers, Cod_Tiers, case when Typ_Tiers in ('Fou','Clt') then Nom_Clt else Nom_Tiers end as Nom_Tiers, Fonction
    from Mailing_Destinataire d
    outer apply (select Nom_Clt ,Cod_Clt from Sys_Part_Tiers where Cod_Clt=Cod_Tiers and Typ_Tiers=left(d.Typ_Tiers,1)) t
    order by Nom_Tiers,Nom,Prenom")
            With Tbl
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i)("Civilite"), "")
                    C2 = IsNull(.Rows(i)("Nom"), "")
                    C3 = IsNull(.Rows(i)("Prenom"), "")
                    C4 = IsNull(.Rows(i)("Email"), "")
                    C5 = IsNull(.Rows(i)("Typ_Tiers"), "")
                    C6 = IsNull(.Rows(i)("Cod_Tiers"), "")
                    C7 = IsNull(.Rows(i)("Nom_Tiers"), "")
                    C8 = IsNull(.Rows(i)("Fonction"), "")
                    C9 = IsNull(.Rows(i)("id_Destinataire"), -1)
                    With Grd_Destinataire
                        .Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C9)
                        .Item(Cod_Tiers.Index, i).ReadOnly = (C5 = "Fou" Or C5 = "Clt" Or C5 = "Prospect")
                    End With
                Next
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Searching()
        With Zoom_Chercher
            .Grd = Grd_Destinataire
            .Show()
        End With
    End Sub
    Private Sub Grd_Destinataire_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Destinataire.CellMouseMove
        With Grd_Destinataire
            If e.RowIndex < 0 Then Return
            If e.ColumnIndex < 0 Then Return
            If .RowCount = 0 Then Return
            If .Item(Cod_Tiers.Index, e.RowIndex).ReadOnly And e.ColumnIndex = Cod_Tiers.Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
    Private Sub Grd_Destinataire_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Destinataire.CellLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub Grd_Destinataire_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Destinataire.CellMouseDoubleClick
        With Grd_Destinataire
            If .Item(Cod_Tiers.Index, e.RowIndex).ReadOnly And e.ColumnIndex = Cod_Tiers.Index Then
                If IsNull(.Item(Typ_Tiers.Index, e.RowIndex).Value, "").Trim = "Fou" Then
                    Appel_Zoom1("MS024", .Item(Cod_Tiers.Index, e.RowIndex), Me)
                    .Item(Tiers.Index, e.RowIndex).Value = FindLibelle("Nom_Fou", "Cod_Fou", IsNull(.Item(Cod_Tiers.Index, e.RowIndex).Value, ""), "Part_Fou")
                ElseIf IsNull(.Item(Typ_Tiers.Index, e.RowIndex).Value, "").Trim = "Clt" Then
                    Appel_Zoom1("MS023", .Item(Cod_Tiers.Index, e.RowIndex), Me)
                    .Item(Tiers.Index, e.RowIndex).Value = FindLibelle("Nom_Clt", "Cod_Clt", IsNull(.Item(Cod_Tiers.Index, e.RowIndex).Value, ""), "Part_Clt")
                End If
            End If
        End With
    End Sub
    Private Sub Grd_Destinataire_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Destinataire.CellValidated
        With Grd_Destinataire
            If e.RowIndex < 0 Then Return
            If e.ColumnIndex < 0 Then Return
            If .RowCount = 0 Then Return
            If e.ColumnIndex = Typ_Tiers.Index Then
                .Item(Cod_Tiers.Index, e.RowIndex).ReadOnly = (IsNull(.Item(Typ_Tiers.Index, e.RowIndex).Value, "").Trim = "Fou" Or IsNull(.Item(Typ_Tiers.Index, e.RowIndex).Value, "").Trim = "Clt" Or IsNull(.Item(Typ_Tiers.Index, e.RowIndex).Value, "").Trim = "Prospect")
            End If
        End With
    End Sub
    Private Sub Grd_Destinataire_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Destinataire.CellMouseEnter
        With Grd_Destinataire
            If e.RowIndex < 0 Then Return
            If e.ColumnIndex < 0 Then Return
            If .RowCount = 0 Then Return
            If e.ColumnIndex = Tiers.Index And IsNull(.Item(Cod_Tiers.Index, e.RowIndex).Value, "") <> "" Then
                .Cursor = Cursors.Hand
            ElseIf .Item(Cod_Tiers.Index, e.RowIndex).ReadOnly And e.ColumnIndex = Cod_Tiers.Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
End Class