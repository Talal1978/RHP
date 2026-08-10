Public Class RH_Conge_Planning
    Private _mois As Date = New Date(Today.Year, Today.Month, 1)
    Private TblAgents As New DataTable
    Private TblConges As New DataTable
    Private TblFeries As New DataTable
    Private ReadOnly JrsSemaine As String() = {"lu", "ma", "me", "je", "ve", "sa", "di"}

    Private Sub RH_Conge_Planning_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
        Planning_Grd.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Requesting()
    End Sub

#Region "Critères"
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Matricule_txt, Me)
        End If
    End Sub
    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
    End Sub
    Private Sub Entite_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Entite_lbl.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS010", Cod_Entite_txt, Me, filtreEntite)
            End If
        Else
            Appel_Zoom1("MS010", Cod_Entite_txt, Me)
        End If
    End Sub
    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub
#End Region

#Region "Navigation mois"
    Private Sub Mois_Prec_pb_Click(sender As Object, e As EventArgs) Handles Mois_Prec_pb.Click
        _mois = _mois.AddMonths(-1)
        Requesting()
    End Sub
    Private Sub Mois_Suiv_pb_Click(sender As Object, e As EventArgs) Handles Mois_Suiv_pb.Click
        _mois = _mois.AddMonths(1)
        Requesting()
    End Sub
    Private Sub Aujourdhui_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Aujourdhui_lbl.LinkClicked
        _mois = New Date(Today.Year, Today.Month, 1)
        Requesting()
    End Sub
#End Region

    Sub Requesting()
        Cursor = Cursors.WaitCursor
        Try
            Mois_lbl.Text = _mois.ToString("MMMM yyyy", New Globalization.CultureInfo("fr-FR"))
            Dim datDu As Date = _mois
            Dim datAu As Date = _mois.AddMonths(1).AddDays(-1)

            ' Périmètre des collaborateurs visibles
            Dim swhere As String = " a.id_Societe=" & Societe.id_Societe & " and a.Dat_Sortie is null"
            If theUser.Typ_Role = "Agent" Then
                If theUser.TeamLeader Then
                    If Matricule_txt.Text <> "" Then
                        swhere &= " and a.Matricule='" & Matricule_txt.Text & "'"
                    Else
                        ' Manager : lui-même + les agents des entités de sa branche
                        swhere &= " and (a.Matricule='" & theUser.Matricule & "' or " & String.Format(filtreUser, {"a"}) & ")"
                    End If
                Else
                    ' Collaborateur simple : uniquement son propre planning
                    swhere &= " and a.Matricule='" & theUser.Matricule & "'"
                End If
            Else
                If Matricule_txt.Text <> "" Then swhere &= " and a.Matricule='" & Matricule_txt.Text & "'"
            End If
            If Cod_Entite_txt.Text <> "" Then swhere &= " and a.Cod_Entite='" & Cod_Entite_txt.Text & "'"

            TblAgents = DATA_READER_GRD("select a.Matricule, Nom_Agent + ' ' + Prenom_Agent as Nom, isnull(e.Lib_Entite,'') as Entite
from RH_Agent a
left join Org_Entite e on e.id_Societe=a.id_Societe and e.Cod_Entite=a.Cod_Entite
where " & swhere & "
order by case when a.Matricule='" & theUser.Matricule & "' then 0 else 1 end, Nom_Agent, Prenom_Agent")

            ' Congés de ces collaborateurs chevauchant le mois (hors brouillons et rejetés)
            TblConges = DATA_READER_GRD("select c.Matricule, c.Num_Conge, c.Dat_Deb_Conge, c.Dat_Fin_Conge,
isnull(c.Statut,'') as Statut,
isnull(nullif(dbo.FindRubrique('Typ_Conge',c.Typ_Conge),''),isnull(c.Typ_Conge,'CAD')) as Lib_Type,
isnull(dbo.FindRubrique('Statut_Signature',c.Statut),'') as Lib_Statut
from RH_Conge_Suivi c
where c.id_Societe=" & Societe.id_Societe & "
and isnull(c.Statut,'') not in ('','RJ')
and c.Dat_Deb_Conge <= '" & datAu.ToString("dd/MM/yyyy") & "' and c.Dat_Fin_Conge >= '" & datDu.ToString("dd/MM/yyyy") & "'
and exists(select 1 from RH_Agent a where a.id_Societe=c.id_Societe and a.Matricule=c.Matricule and " & swhere & ")")

            ' Jours fériés de la fiche société, bornés au mois affiché
            TblFeries = DATA_READER_GRD("select Lib_Jour, DatDeb, DatFin from dbo.Sys_JourFeries('" & datDu.ToString("dd/MM/yyyy") & "'," & Societe.id_Societe & ")")

            ConstruireGrille(datDu, datAu)
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ConstruireGrille(datDu As Date, datAu As Date)
        Dim nbJours As Integer = DateTime.DaysInMonth(_mois.Year, _mois.Month)
        Dim JoursOuvres() As String = IsNull(Societe.JourOuvrables, "1;1;1;1;1;1;0").Split({";"}, StringSplitOptions.RemoveEmptyEntries)

        ' Jours fériés indexés par date
        Dim feriesDic As New Dictionary(Of Date, String)
        For Each fr As DataRow In TblFeries.Rows
            Dim d1 As Date = CDate(fr("DatDeb")).Date
            Dim d2 As Date = CDate(fr("DatFin")).Date
            If d2 < datDu Or d1 > datAu Then Continue For
            Dim d As Date = d1
            While d <= d2
                If d >= datDu And d <= datAu Then feriesDic(d) = IsNull(fr("Lib_Jour"), "")
                d = d.AddDays(1)
            End While
        Next

        ' Congés indexés par matricule
        Dim congesDic As New Dictionary(Of String, List(Of DataRow))
        For Each cr As DataRow In TblConges.Rows
            Dim mat As String = CStr(cr("Matricule"))
            If Not congesDic.ContainsKey(mat) Then congesDic.Add(mat, New List(Of DataRow))
            congesDic(mat).Add(cr)
        Next

        Dim couleurCongeValide As Color = colorBase02
        Dim couleurCongeAttente As Color = Color.FromArgb(198, 236, 211)
        Dim couleurFerie As Color = Color.FromArgb(250, 197, 169)
        Dim couleurRepos As Color = Color.FromArgb(235, 235, 235)

        With Planning_Grd
            .DataSource = Nothing
            .Columns.Clear()
            .Rows.Clear()

            ' Colonne du collaborateur (figée)
            Dim colAg As New DataGridViewTextBoxColumn
            With colAg
                .Name = "Collaborateur"
                .HeaderText = "Collaborateur"
                .Frozen = True
                .Width = 220
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .HeaderCell.Style.Padding = New Padding(0)
            End With
            .Columns.Add(colAg)

            ' Une colonne par jour du mois
            For i = 1 To nbJours
                Dim d As New Date(_mois.Year, _mois.Month, i)
                Dim idxJour As Integer = If(d.DayOfWeek = DayOfWeek.Sunday, 6, CInt(d.DayOfWeek) - 1)
                Dim col As New DataGridViewTextBoxColumn
                With col
                    .Name = "J" & i
                    .HeaderText = JrsSemaine(idxJour) & " " & i.ToString("00")
                    .Width = 34
                    .ReadOnly = True
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Padding = New Padding(0)
                    If feriesDic.ContainsKey(d) Then
                        .HeaderCell.Style.BackColor = couleurFerie
                        .HeaderCell.Style.ForeColor = Color.FromArgb(64, 64, 64)
                        .HeaderCell.ToolTipText = feriesDic(d)
                    ElseIf JoursOuvres.Length = 7 AndAlso JoursOuvres(idxJour) = "0" Then
                        .HeaderCell.Style.BackColor = couleurRepos
                        .HeaderCell.Style.ForeColor = Color.FromArgb(64, 64, 64)
                    End If
                    If d = Today Then
                        .HeaderCell.Style.ForeColor = colorBase03
                    End If
                End With
                .Columns.Add(col)
            Next

            ' Une ligne par collaborateur
            For Each ag As DataRow In TblAgents.Rows
                Dim mat As String = CStr(ag("Matricule"))
                Dim ridx As Integer = .Rows.Add()
                Dim ligne As DataGridViewRow = .Rows(ridx)
                ligne.Height = 26
                ligne.ReadOnly = True
                With ligne.Cells(0)
                    .Value = CStr(ag("Nom"))
                    .ToolTipText = CStr(ag("Nom")) & If(CStr(ag("Entite")) <> "", " - " & CStr(ag("Entite")), "")
                End With
                For i = 1 To nbJours
                    Dim d As New Date(_mois.Year, _mois.Month, i)
                    Dim idxJour As Integer = If(d.DayOfWeek = DayOfWeek.Sunday, 6, CInt(d.DayOfWeek) - 1)
                    Dim cell As DataGridViewCell = ligne.Cells(i)
                    Dim bulle As New List(Of String)
                    bulle.Add(CStr(ag("Nom")) & " - " & d.ToString("dd/MM/yyyy"))

                    Dim conge As DataRow = Nothing
                    If congesDic.ContainsKey(mat) Then
                        For Each cr As DataRow In congesDic(mat)
                            If CDate(cr("Dat_Deb_Conge")).Date <= d AndAlso CDate(cr("Dat_Fin_Conge")).Date >= d Then
                                conge = cr
                                Exit For
                            End If
                        Next
                    End If

                    If conge IsNot Nothing Then
                        cell.Style.BackColor = If(CStr(conge("Statut")) = "SS", couleurCongeAttente, couleurCongeValide)
                        cell.Tag = CStr(conge("Num_Conge"))
                        bulle.Add(CStr(conge("Lib_Type")) & " du " & CDate(conge("Dat_Deb_Conge")).ToString("dd/MM/yyyy") & " au " & CDate(conge("Dat_Fin_Conge")).ToString("dd/MM/yyyy") & " (" & CStr(conge("Lib_Statut")) & ")")
                    ElseIf feriesDic.ContainsKey(d) Then
                        cell.Style.BackColor = couleurFerie
                    ElseIf JoursOuvres.Length = 7 AndAlso JoursOuvres(idxJour) = "0" Then
                        cell.Style.BackColor = couleurRepos
                    End If
                    If feriesDic.ContainsKey(d) Then bulle.Add("Férié : " & feriesDic(d))
                    cell.ToolTipText = String.Join(vbCrLf, bulle)
                Next
            Next
            ' Evite tout artefact visuel de sélection sur les cellules colorées
            .ClearSelection()
            If .Rows.Count > 0 Then .CurrentCell = Nothing
            .Refresh()
        End With
    End Sub

    ' Double-clic sur une cellule de congé : ouvre la demande correspondante
    Private Sub Planning_Grd_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Planning_Grd.CellDoubleClick
        If e.RowIndex < 0 Or e.ColumnIndex <= 0 Then Return
        Dim numConge As String = IsNull(Planning_Grd.Item(e.ColumnIndex, e.RowIndex).Tag, "").ToString
        If numConge = "" Then Return
        Dim f As New RH_Demande_Conge
        With f
            .Num_Conge_txt.Text = numConge
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Planning_Grd_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Planning_Grd.CellMouseMove
        With Planning_Grd
            If e.RowIndex < 0 Or e.ColumnIndex <= 0 Then
                .Cursor = Cursors.Default
            ElseIf IsNull(.Item(e.ColumnIndex, e.RowIndex).Tag, "").ToString <> "" Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
End Class
