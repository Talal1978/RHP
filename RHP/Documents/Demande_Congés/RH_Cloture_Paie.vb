Imports System.ComponentModel
Public Class RH_Cloture_Paie
    Dim TblRecapConge As New DataTable
    Friend WithEvents oTimer As New Timer
    Dim strLog As String = ""
    Dim pnl As New Panel
    Dim picWait As New PictureBox
    Dim lbl As New Label
    Dim laDat As Date = Now.ToShortDateString
    Dim TblRubPaie As DataTable = DATA_READER_GRD("select Cod_Rubrique, Typ_Retour, Nb_Decimal, Relation  from RH_Paie_Rubrique where id_Societe=" & Societe.id_Societe & " and isnull(EC,0)=1")
    Dim myVBS As New vsEngine
    Dim Annee As Integer
    Dim PeriodeCloturee As Boolean = False
    Dim titre As String = ""
    Private Sub RH_Cloture_Paie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Annee = CnExecuting("select isnull((select max(Annee) from Param_Periode_Paie where id_Societe=" & Societe.id_Societe & "),0)").Fields(0).Value
        PeriodeCloturee = FindLibelle("Cloture", "Annee", Annee, "Param_Periode_Paie")
        Grp.Text = "Clôture de la paie de l'annéee : " & Annee & IIf(PeriodeCloturee, " (Période clôturée)", "")
        dictButtons("Cloture_D").Enabled = Not PeriodeCloturee
        Request()
        With oTimer
            .Interval = 10
        End With
        With lbl
            .AutoSize = False
            .Size = New Size(150, 50)
            .TextAlign = ContentAlignment.MiddleCenter
        End With
    End Sub
    Private Sub Interroger_D_Click(sender As Object, e As EventArgs)
        Request()
    End Sub
    Sub Request()
        If Annee <= 2000 Then
            ShowMessageBox("Année à clôturer manquante", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim Sqlstr As String = "select Matricule,Nom,[Date entrée],Plan_Paie as 'Plan',Conge_Annuel as 'Congé annuel',Acquis_Anciennete as 'Acquis anciennté',
Droit_Conge as 'Droit au congé',Reliquat_Anterieur as 'Reliquats antérieurs',Conge_Pris as 'Congé pris',Solde, isnull(CongeAnciennete,'') as 'Rub. anc. congé'
from dbo.Sys_RH_Conge_Recap(" & Societe.id_Societe & "," & Annee & ") c
outer apply (select CongeAnciennete from RH_Param_Plan_Paie where id_Societe=" & Societe.id_Societe & " and Cod_Plan_Paie=c.Plan_Paie) v
order by Plan_Paie, Matricule"
        TblRecapConge = DATA_READER_GRD(Sqlstr)
        With Rh_GRD
            .DataSource = TblRecapConge
            TblRecapConge.Columns("Acquis anciennté").ReadOnly = False
            TblRecapConge.Columns("Droit au congé").ReadOnly = False
            TblRecapConge.Columns("Reliquats antérieurs").ReadOnly = False
            TblRecapConge.Columns("Congé pris").ReadOnly = False
            TblRecapConge.Columns("Solde").ReadOnly = False
            .Columns("Date entrée").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Plan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Congé annuel").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Acquis anciennté").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Droit au congé").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Reliquats antérieurs").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Congé pris").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Solde").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Rh_GRD.setFilter({ .Columns("Matricule").Index, .Columns("Nom").Index, .Columns("Date entrée").Index,
                                .Columns("Plan").Index, .Columns("Congé annuel").Index, .Columns("Acquis anciennté").Index, .Columns("Reliquats antérieurs").Index, .Columns("Droit au congé").Index, .Columns("Congé pris").Index, .Columns("Solde").Index})
        End With
    End Sub
    Sub Cloturer()
        If Rh_GRD.RowCount = 0 Then Return
        If Rh_GRD.ModeFiltreActive Then
            ShowMessageBox("Votre grille comporte un filtre." & vbCrLf & "Veuillez défiltrer votre selection", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ShowMessageBox("Etes-vous sûr de vouloir clôturer la periode : " & Annee, Me.Text, MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Return
        Dim nb As Integer = CnExecuting("Select count(*) from RH_Preparation_Paie where id_Societe=" & Societe.id_Societe & " and Annee_Paie=" & Annee).Fields(0).Value
        If nb = 0 Then
            If ShowMessageBox("Aucune paie n'est enregistrée sur cette période." & vbCrLf & "Etes-vous sûr de vouloir continuer", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Return
        End If
        nb = CnExecuting("select isnull(sum(isnull(Conge_Pris,0)),0) from RH_Conge where isnull(id_Societe,-1)=" & Societe.id_Societe & " and Annee=" & Annee).Fields(0).Value
        If nb = 0 Then
            If ShowMessageBox("Aucun congé pris sur cette période." & vbCrLf & "Etes-vous sûr de vouloir continuer", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Return
        End If
        Dim strPlan As String = CnExecuting("select isnull((select Top 1 Cod_Plan_Paie from RH_Param_Plan_Paie where id_Societe=" & Societe.id_Societe & " and isnull(CongeAnciennete,'')=''),'')").Fields(0).Value
        If strPlan <> "" Then
            If ShowMessageBox("Lv variable de calcul de l'ancienneté de congé n'est pas renseignée pour au moins un Plan de paie : " & strPlan & vbCrLf & "Etes-vous sûr de vouloir continuer", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Return
        End If
        With pnl
            leMenu.Controls.Add(pnl)
            .BringToFront()
            .Dock = DockStyle.Fill
            .BackColor = Me.BackColor
        End With
        With picWait
            .BackColor = Color.Transparent
            .Image = My.Resources.Waiting
            .Size = New Size(307, 307)
            .Location = New Point((pnl.Width - .Width) / 2, (pnl.Height - .Height) / 2)
            pnl.Controls.Add(picWait)
            .BringToFront()
        End With
        With lbl
            .BackColor = Color.Transparent
            .Location = New Point((pnl.Width - .Width) / 2, (pnl.Height - .Height) / 2)
            pnl.Controls.Add(lbl)
            .BringToFront()
        End With
        oTimer.Start()
        laDat = CnExecuting("select isnull((select Dat_Fin from Param_Periode_Paie where id_Societe=" & Societe.id_Societe & " and Annee='" & Annee & "'),getdate())").Fields(0).Value
        BKG_Conge.RunWorkerAsync()
    End Sub

    Function CalculConge(ByVal oLgnInd As Integer) As Boolean
        If PeriodeCloturee Then Return False
        Try
            With TblRecapConge
                'Affectation des EB
                If .Rows(oLgnInd)("Rub. anc. congé") <> "" Then
                    Dim vrw() As DataRow = TblRubPaie.Select("Cod_Rubrique='" & .Rows(oLgnInd)("Rub. anc. congé") & "'")
                    If vrw.Length > 0 Then
                        If IsNull(vrw(0)("Relation"), "") <> "" Then
                            '      AffectationEB(.Rows(oLgnInd)("Matricule"), laDat, False)
                            .Rows(oLgnInd)("Acquis anciennté") = ConvertNombre(myVBS.Eval(TraitementCaractere(vrw(0)("Relation"))))
                        Else
                            .Rows(oLgnInd)("Acquis anciennté") = 0
                        End If
                    Else
                        .Rows(oLgnInd)("Acquis anciennté") = 0
                    End If

                Else
                    .Rows(oLgnInd)("Acquis anciennté") = 0
                End If
                .Rows(oLgnInd)("Droit au congé") = ConvertNombre(.Rows(oLgnInd)("Congé annuel")) + ConvertNombre(.Rows(oLgnInd)("Acquis anciennté"))
                .Rows(oLgnInd)("Reliquats antérieurs") = .Rows(oLgnInd)("Solde")
                .Rows(oLgnInd)("Congé pris") = 0
                .Rows(oLgnInd)("Solde") = .Rows(oLgnInd)("Droit au congé") + .Rows(oLgnInd)("Reliquats antérieurs")
            End With
            Return True
        Catch ex As Exception
            ShowMessageBox("Erreur de calcul de la ligne : " & oLgnInd + 1 & vbCrLf & ex.Message, "Erreur : " & Rh_GRD.Item("Matricule", oLgnInd).Value, MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End Try
    End Function

    Private Sub BKG_Conge_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_Conge.DoWork
        Dim rs As New ADODB.Recordset
        Dim currentPlan As String = ""
        With Rh_GRD
            CnExecuting("delete from RH_Conge where Annee='" & ConvertEntier(Annee) + 1 & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from  RH_Conge where Annee='" & ConvertEntier(Annee) + 1 & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            For i = 0 To .RowCount - 1
                If currentPlan <> .Item("Plan", i).Value Then
                    currentPlan = .Item("Plan", i).Value
                    myVBS.setPlan(.Item("Plan", i).Value)
                End If
                CalculConge(i)
                rs.AddNew()
                rs("id_Societe").Value = Societe.id_Societe
                rs("Matricule").Value = .Item("Matricule", i).Value
                rs("Annee").Value = ConvertEntier(Annee) + 1
                rs("Conge_Annuel").Value = .Item("Congé annuel", i).Value
                rs("Acquis_Anciennete").Value = .Item("Acquis anciennté", i).Value
                rs("Droit_Conge").Value = .Item("Droit au congé", i).Value
                rs("Reliquat_Anterieurs").Value = .Item("Reliquats antérieurs", i).Value
                rs("Conge_Pris").Value = 0
                rs("Solde_Conge").Value = .Item("Solde", i).Value
                strLog = "Ligne : " & i + 1 & "/" & .RowCount & vbCrLf & .Item("Matricule", i).Value
                rs.Update()
            Next
            rs.Close()
            CnExecuting("Update Param_Periode_Paie set Cloture='True', Conge_Genere='True', Dat_Cloture=getdate() where Annee=" & Annee & " and id_Societe=" & Societe.id_Societe &
                        " insert into  Param_Periode_Paie ( id_Societe, Annee, Mois, Dat_Deb, Dat_Fin, Pre_Dat_Deb, Pre_Dat_Fin, Pre_Annee, Pre_Mois, Cloture, Conge_Genere)
select " & Societe.id_Societe & ", " & ConvertEntier(Annee) + 1 & ", Mois ,  dateadd(day,1,Dat_Fin), dateadd(year,1,Dat_Fin), Dat_Deb, Dat_Fin, Annee, Mois, 'False' as Cloture, 'False' as Conge_Genere
FROM  Param_Periode_Paie where Annee=" & Annee & " and id_Societe=" & Societe.id_Societe)

        End With
    End Sub
    Private Sub BKG_Conge_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_Conge.RunWorkerCompleted
        If leMenu.Controls.Contains(pnl) Then
            leMenu.Controls.Remove(pnl)
        End If
        Dim f As New Param_Periode_Paie
        newShowEcran(f)
        Me.Close()
    End Sub

    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        With lbl
            .Text = strLog
            .Refresh()
        End With
    End Sub
End Class