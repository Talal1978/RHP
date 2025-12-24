Public Class Param_Periode_Paie
    Dim TblPeriodePaie As New DataTable
    Public Sub Request()
        Grille.Rows.Clear()
        Dim C1, C2, C3, C4, C6, C7, C8, C9, C10, C11 As Object
        Dim codSql As String = " SELECT     Annee, convert(nvarchar(10),Dat_Deb,103) as Du ,convert(nvarchar(10),Dat_Fin,103) as Au,  
  isnull(convert(nvarchar(10),Pre_Dat_Deb ,103),'') as Pre_Dat_Deb, isnull(convert(nvarchar(10),Pre_Dat_Fin ,103),'') Pre_Dat_Fin, 
  isnull(Cloture,'false') as Cloture,isnull(Conge_Genere ,'false') as 'Conge_Genere'
  FROM Param_Periode_Paie where id_Societe=" & Societe.id_Societe & " order by Dat_Deb desc"

        TblPeriodePaie = DATA_READER_GRD(codSql)
        With TblPeriodePaie
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Annee"), 0)
                C2 = "Du " & .Rows(i).Item("Du") & " au " & .Rows(i).Item("Au")
                C3 = IIf(.Rows(i).Item("Pre_Dat_Deb") = "", "", "Du " & .Rows(i).Item("Pre_Dat_Deb") & " au " & .Rows(i).Item("Pre_Dat_Fin"))
                C4 = IIf(ConvertBoolean(.Rows(i).Item("Cloture")), "Clôturée", "Ouverte")
                C6 = IsNull(.Rows(i).Item("Du"), "")
                C7 = IsNull(.Rows(i).Item("Au"), "")
                C8 = IsNull(.Rows(i).Item("Pre_Dat_Deb"), "")
                C9 = IsNull(.Rows(i).Item("Pre_Dat_Fin"), "")
                C10 = IsNull(.Rows(i).Item("Conge_Genere"), False)
                C11 = IIf(i = 0, My.Resources.success, My.Resources.Blank)
                Grille.Rows.Add(C1, C2, C3, C4, C6, C7, C8, C9, C10, C11)
            Next
        End With
    End Sub
    Private Sub frmPPeriode_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        SelectedPeriode.DisplayIndex = 0
        Request()
    End Sub
    Sub CloturerPeriode()
        With Grille
            Dim r As Integer = .CurrentCell.RowIndex
            If ShowMessageBox("Etes vous-sûr de vouloir clôturer la période : '" & .Item(Periode.Index, r).Value & "' ?", "Confirmation", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then Exit Sub
            If IsNull(.Item(Annee.Index, r).Value, "") <> "" Then
                Dim Tbl As DataTable = DATA_READER_GRD("Select count(*) as   nb from RH_Preparation_Paie where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & .Item(Annee.Index, r).Value & "'")
                If CDbl(Tbl.Rows(0)("nb")) = 0 Then
                    ShowMessageBox("Aucune paie sur l'année de paie demandée.")
                    Exit Sub
                End If
                Tbl = DATA_READER_GRD("select * from Param_Periode_Paie where Annee='" & .Item(Annee.Index, r).Value & "' and isnull(Conge_Genere,'false')='false' and id_Societe=" & Societe.id_Societe)
                If Tbl.Rows.Count > 0 Then
                    ShowMessageBox("Congés n'ont générés pour cette période.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                    Exit Sub
                End If
                Dim nrw() As DataRow = TblPeriodePaie.Select("Cloture='false' and Annee<'" & .Item(Annee.Index, r).Value & "'")
                If nrw.Length > 0 Then
                    ShowMessageBox("Des périodes précédantes non encore clôturées", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                    Exit Sub
                End If
                Dim f As New RH_Cloture_Paie
                With f
                    newShowEcran(f, True)
                End With
            End If
        End With

    End Sub
    Sub ModifierPeriode()
        With Grille
            Dim r As Integer = .CurrentCell.RowIndex
            If IsNull(.Item(Annee.Index, r).Value, "") = "" Then Exit Sub
            If IsNull(.Item(Statut.Index, r).Value, "") = "Clôturée" Then
                ShowMessageBox("Période Clôturée")
                Exit Sub
            End If
            If CBool(IsNull(.Item(Conge_Genere.Index, r).Value, False)) Then
                ShowMessageBox("Des congés sont générés pour cette période.")
                Exit Sub
            End If
            Dim Tbl As DataTable = DATA_READER_GRD("Select count(*) as   nb from RH_Preparation_Paie where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & .Item(Annee.Index, r).Value & "'")
            If CDbl(Tbl.Rows(0)("nb")) > 0 Then
                ShowMessageBox("Au moins une paie existe sur la période de paie demandée.", "Vérifications", MessageBoxButtons.OK, msgIcon.Stop)
                Exit Sub
            End If
            With Zoom_PPeriodeAjouter
                .ActAu = Grille.Item(ActAu.Index, r).Value
                .ActDu = Grille.Item(ActDu.Index, r).Value
                .PreAu = Grille.Item(PreAu.Index, r).Value
                .PreDu = Grille.Item(PreDu.Index, r).Value
                .lAnnee = Grille.Item(Annee.Index, r).Value
                .f = Me
                .ShowDialog()
            End With
        End With
    End Sub
    Sub Deleting()
        With Grille
            Dim r As Integer = .CurrentCell.RowIndex
            If ShowMessageBox("Etes vous-sûr de vouloir supprimer la période : '" & .Item(Periode.Index, r).Value & "' ?", "Confirmation", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Exit Sub
            If IsNull(.Item(Annee.Index, r).Value, "") <> "" Then
                If IsNull(.Item(Statut.Index, r).Value, "") = "Clôturée" Then
                    ShowMessageBox("Période Clôturée")
                    Exit Sub
                End If
                Dim Tbl As DataTable = DATA_READER_GRD("Select count(*) as   nb from RH_Preparation_Paie where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & .Item(Annee.Index, r).Value & "'")
                If CDbl(Tbl.Rows(0)("nb")) > 0 Then
                    ShowMessageBox("Au moins une paie existe sur la période de paie demandée.", "Vérifications", MessageBoxButtons.OK, msgIcon.Stop)
                    Exit Sub
                End If
                If CBool(IsNull(.Item(Conge_Genere.Index, r).Value, False)) Then
                    ShowMessageBox("Des congés sont générés pour cette période.")
                    Exit Sub
                End If
                CnExecuting("delete from Param_Periode_Paie where Annee='" & .Item(Annee.Index, r).Value & "' and id_Societe=" & Societe.id_Societe)
            End If
            Request()
        End With
    End Sub
    Sub Nouveau()
        Dim PeriodeNonCloture As Boolean = False
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Param_Periode_Paie where isnull(Cloture,'false')='false' and id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count > 1 Then
            ShowMessageBox("Il existe au moins deux périodes de paie non clôturées.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            PeriodeNonCloture = True
        End If
        If Not PeriodeNonCloture Then
            Tbl = DATA_READER_GRD("select * from Param_Periode_Paie where isnull(Conge_Genere,'false')='false' and id_Societe=" & Societe.id_Societe)
            If Tbl.Rows.Count > 0 Then
                ShowMessageBox("Il existe au une période de paie pour laquelle les congés n'ont pas été générés.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                PeriodeNonCloture = True
            End If
        End If
        If Not PeriodeNonCloture Then
            Dim f As New Zoom_PPeriodeAjouter
            With f
                .f = Me
                .ShowDialog()
            End With
        ElseIf ShowMessageBox("Voulez-vous procéder à la clôture de la période pour ouvrir une nouvelle?", "Vérification", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.OK Then
            Dim f As New RH_Cloture_Paie
            With f
                newShowEcran(f)
            End With
            Me.Close()
        End If

    End Sub

    Private Sub Close_D_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class