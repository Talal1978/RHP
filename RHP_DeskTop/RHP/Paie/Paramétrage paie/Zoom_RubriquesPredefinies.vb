Public Class Zoom_RubriquesPredefinies
    Friend fPlan As New RH_Parametrage_Plan_Paie
    Dim TblEPUsed As DataTable = DATA_READER_GRD("declare @idSoc int =" & Societe.id_Societe & "
select Cod_Rubrique, Abr_Rubrique, Lib_Rubrique,convert(bit, case when nbr>0 then 1 else 0 end) as ExistsInOtherSociete
from RH_Paie_Rubrique_Predefinie p 
outer apply (select count(*) as nbr from RH_Paie_Rubrique where isnull(nullif(id_Societe,-1),@idSoc)!=@idSoc and Cod_Rubrique=p.Cod_Rubrique)x
where not exists(select Cod_Rubrique from RH_Paie_Rubrique where Cod_Rubrique=p.Cod_Rubrique and isnull(nullif(id_Societe,-1),@idSoc)=@idSoc)")
    Private Sub Zoom_FsRb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With TblEPUsed
            For i = 0 To .Rows.Count - 1
                Dim itm As New ListViewItem
                With itm
                    .Checked = False
                    .Name = TblEPUsed.Rows(i)("Cod_Rubrique")
                    .Text = TblEPUsed.Rows(i)("Abr_Rubrique")
                    .SubItems.Add(TblEPUsed.Rows(i)("Lib_Rubrique"))
                    .SubItems.Add("")
                End With
                lv.Items.Add(itm)
            Next
        End With
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        Cursor = Cursors.WaitCursor
        verif()
        Dim rs As New ADODB.Recordset
        Dim f As New RH_Parametrage_Rubrique_Paie
        For Each itm As ListViewItem In lv.Items
            If itm.Checked Then
                Dim SqlStr As String = "insert into RH_Paie_Rubrique (id_Societe, Cod_Rubrique, Lib_Rubrique, Abr_Rubrique, EV, EC, EB, CS, Cumulable, Ventilable, Modifiable, Typ_Frequence, Nb, Base, Tx, Relation, Relation_VBS, Typ_Retour, Nb_Decimal, Est_Pourcentage, Gain_Retenue, estSysteme, 
                  lastVersion, Salarial, Patronal, Bulletin, Val_Defaut, Typ_Rubrique_Paie, Nature_Element_Exonere, Imposable_IR, Imposable_CNSS, Deductible_IR, Deductible_CNSS, Rubrique_Globale, Cpt_Debit, Cpt_Credit, Commentaire, Couleur, 
                  estMajAuto )
SELECT " & IIf(RubriqueGlobal_chk.Checked, -1, Societe.id_Societe) & ", Cod_Rubrique, Lib_Rubrique, Abr_Rubrique, EV, EC, EB, CS, Cumulable, Ventilable, Modifiable, Typ_Frequence, Nb, Base, Tx, Relation, Relation_VBS, Typ_Retour, Nb_Decimal, Est_Pourcentage, Gain_Retenue, estSysteme, 
                  lastVersion, Salarial, Patronal, Bulletin, Val_Defaut, Typ_Rubrique_Paie, Nature_Element_Exonere, Imposable_IR, Imposable_CNSS, Deductible_IR, Deductible_CNSS,'" & RubriqueGlobal_chk.Checked & "' Rubrique_Globale, Cpt_Debit, Cpt_Credit, Commentaire, Couleur, 
                  estMajAuto
FROM     RH_Paie_Rubrique_Predefinie where Cod_Rubrique='" & itm.Name & "'"
                CnExecuting(SqlStr)
                f.Cod_Rubrique_txt.Text = itm.Name
                f.Lib_Rubrique_txt.Select()
                f.Saving()
            End If
        Next
        Cursor = Cursors.Default
        fPlan.MajTreeView()
        For Each itm As ListViewItem In lv.Items
            If itm.Checked Then
                Dim nd() As TreeNode = fPlan.Function_Trv.Nodes.Find(itm.Name, True)
                If nd.Length > 0 Then
                    nd(0).Checked = True
                End If
            End If
        Next
        Me.Close()
    End Sub
    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
    Private Sub RubriqueGlobal_chk_CheckedChanged(sender As Object, e As EventArgs) Handles RubriqueGlobal_chk.CheckedChanged
        verif()
    End Sub
    Sub verif()
        For Each itm As ListViewItem In lv.Items
            With itm
                .ForeColor = If(TblEPUsed.Select("Cod_Rubrique='" & itm.Name & "' and ExistsInOtherSociete='true'").Length > 0 And RubriqueGlobal_chk.Checked, Color.Red, Color.Black)
                .SubItems(2).Text = If(.ForeColor = Color.Red, "Utilisée dans une autre société.", "")
            End With
            If RubriqueGlobal_chk.Checked Then
                If itm.Checked Then
                    itm.Checked = (TblEPUsed.Select("Cod_Rubrique='" & itm.Name & "' and ExistsInOtherSociete='true'").Length = 0)
                End If
            End If
        Next
    End Sub

    Private Sub Select_All_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Select_All_chk.CheckedChanged
        For Each itm As ListViewItem In lv.Items
            itm.Checked = Select_All_chk.Checked
        Next
        verif()
    End Sub
End Class