Imports System.ComponentModel

Public Class Zoom_RH_Preparation_Paie_Saisie
    Friend CodPlan As String = ""
    Friend CodPreparation As String
    Friend inDx As Integer = 0
    Dim TblAgent As New DataTable
    Dim Tbl_RubriquesBase, Tbl_Paie As New DataTable
    Friend PaieCloture As Boolean = False
    Friend frmPrePaie As New RH_Preparation_Paie_Saisie
    Private Sub Zoom_RH_Preparation_Paie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Bulletin_chk
            .Checked = (frmPrePaie.elementDetailBulletinPaie.Length > 0)
            .Enabled = .Checked
        End With
        With Mensuel_chk
            .Checked = False
        End With
    End Sub
    Sub ChargerAgent()
        If TblAgent?.Rows.Count = 0 Then TblAgent = DATA_READER_GRD("SELECT  Matricule, ltrim(rtrim(isnull( Nom_Agent,'')+ ' '+isnull( Prenom_Agent,''))) as Nom, convert(bit,case when isnull(Sexe,'H')='H' then 1 else 0 end) as EstH,
convert(bit,case when isnull(Sexe,'H')='F' then 1 else 0 end) as EstF,
Dat_Naissance, [dbo].[FindRubrique]('Typ_Agent',Typ_Agent) as Typ_Agent,
[dbo].[FindRubrique]('Typ_Contrat', Typ_Contrat) as Typ_Contrat , Dat_Entree, [dbo].[FindRubrique]('Typ_Periode',Typ_Periode) as Typ_Periode, Photo
FROM            RH_Agent
where id_Societe=" & Societe.id_Societe & " and isnull(Plan_Paie,'')='" & CodPlan & "'")
    End Sub
    Sub Request()
        Dim ostyle As New DataGridViewCellStyle
        With ostyle
            .Alignment = DataGridViewContentAlignment.MiddleRight
            .Format = "N2"
        End With
        If frmPrePaie.elementDetailBulletinPaie.Length = 0 Then Bulletin_chk.Checked = False
        Recap_Pnl.Visible = Bulletin_chk.Checked
        Mensuel_chk.Checked = Not Bulletin_chk.Checked
        ChargerAgent()
        Dim CodSql As String = ""
        With MyGrd
            If Bulletin_chk.Checked Then
                CodSql = "select Cod_Rubrique as Code,Rubrique,convert(nvarchar(5),nullif(100.00*Tx,0))+'%' as Taux,case when  isnull(Gain_Retenue,'A')='A' then 1 else nullif(Nb,0) end as Nb,case when  isnull(Gain_Retenue,'A')='A' then Valeur else Base end as Base, case when isnull(Typ_Rubrique_Paie,'')='A_Remb' or isnull(Gain_Retenue,'A')='G' then Valeur else null end as Gain,case when  isnull(Gain_Retenue,'A')='R' then Valeur else null end as Retenue ,isnull(Typ_Rubrique_Paie,'') Typ_Rubrique_Paie   
                        from Rh_Preparation_Paie_Detail d
                        outer apply (select Gain_Retenue,Lib_Rubrique as Rubrique, Typ_Rubrique_Paie from RH_Paie_Rubrique where isnull(nullif(id_Societe,-1),d.id_Societe)=d.id_Societe and Cod_Rubrique=d.Cod_Rubrique)r
                        where id_Societe =" & Societe.id_Societe & " and Cod_Preparation='" & CodPreparation & "' and Matricule='" & Matricule_txt.Text & "' and Valeur!=0
                        and (Cod_Rubrique in ('" & Join(frmPrePaie.elementDetailBulletinPaie, "','") & "') or Cod_Rubrique in ('" & frmPrePaie.ECSalNet & "','" & frmPrePaie.ECSalaireBrut & "')) order by charindex(';'+Cod_Rubrique+';',';" & Join(frmPrePaie.elementDetailBulletinPaie, ";") & ";',0)"
                Dim TblPaie = DATA_READER_GRD(CodSql)
                Dim TblDetail = TblPaie.Clone()
                For i = 0 To TblPaie.Rows.Count - 1
                    If (TblPaie.Rows(i)("Code") = frmPrePaie.ECSalNet) Then
                        NetCalcul_txt.Text = FormatNumber(IsNull(TblPaie.Rows(i)("Base"), 0), 2)
                    ElseIf (TblPaie.Rows(i)("Code") = frmPrePaie.ECSalaireBrut) Then
                        BrutCalcule_txt.Text = FormatNumber(IsNull(TblPaie.Rows(i)("Base"), 0), 2)
                    Else
                        Dim dr = TblDetail.NewRow
                        dr("Code") = TblPaie.Rows(i)("Code")
                        dr("Rubrique") = TblPaie.Rows(i)("Rubrique")
                        dr("Taux") = TblPaie.Rows(i)("Taux")
                        dr("Nb") = TblPaie.Rows(i)("Nb")
                        dr("Base") = TblPaie.Rows(i)("Base")
                        dr("Gain") = TblPaie.Rows(i)("Gain")
                        dr("Retenue") = TblPaie.Rows(i)("Retenue")
                        dr("Typ_Rubrique_Paie") = TblPaie.Rows(i)("Typ_Rubrique_Paie")
                        TblDetail.Rows.Add(dr)
                    End If
                Next
                .DataSource = TblDetail
                .Columns("Typ_Rubrique_Paie").Visible = False
                .Columns("Code").Visible = Afficher_Rubriques_chk.Checked
                .Columns("Gain").DefaultCellStyle = ostyle
                .Columns("Retenue").DefaultCellStyle = ostyle
                .Columns("Base").DefaultCellStyle = ostyle
                .Columns("NB").DefaultCellStyle = ostyle
                .Columns("Taux").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dim brut As Double = 0
                Dim remb As Double = 0
                Dim net As Double = 0
                If TblDetail IsNot Nothing Then
                    For i = 0 To .Rows.Count - 1
                        brut += CDbl(IsNull(.Item("Gain", i).Value, 0))
                        If IsNull(.Item("Typ_Rubrique_Paie", i).Value, "") = "A_Remb" Then remb += CDbl(IsNull(.Item("Gain", i).Value, 0))
                        net += CDbl(IsNull(.Item("Gain", i).Value, 0)) - CDbl(IsNull(.Item("Retenue", i).Value, 0))
                    Next
                End If
                BrutBulletin_txt.Text = FormatNumber(brut - remb, 2)
                NetBulletin_txt.Text = FormatNumber(Math.Round(net, 0), 2)
                EcartBrut_txt.Text = FormatNumber(CDbl(BrutBulletin_txt.Text) - CDbl(IsNull(BrutCalcule_txt.Text, 0)), 2)
                EcartNet_txt.Text = FormatNumber(CDbl(NetBulletin_txt.Text) - CDbl(IsNull(NetCalcul_txt.Text, 0)), 2)
            Else
                If Not EstDate(frmPrePaie.Dat_Deb_Periode_Text.Text) Then Return
                Dim Tbl As DataTable = DATA_READER_GRD("exec Sys_Rh_Paie_Matricule " & Societe.id_Societe & ", '" & Matricule_txt.Text & "', '" & CDate(frmPrePaie.Dat_Fin_Periode_Text.Text).Month & "', '" & CDate(frmPrePaie.Dat_Fin_Periode_Text.Text).Year & "'")
                With MyGrd
                    .DataSource = Tbl
                    If .ColumnCount = 0 Then Return
                    For i = 1 To .ColumnCount - 1
                        If Tbl.Columns(i).DataType = GetType(Double) Then
                            .Columns(i).DefaultCellStyle.Format = "N2"
                            .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        ElseIf Tbl.Columns(i).DataType = GetType(Integer) Then
                            .Columns(i).DefaultCellStyle.Format = "N0"
                            .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End If
                    Next
                    With .Columns("Rubrique")
                        .Width = 150
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    End With
                    With .Columns("Code")
                        .Width = 100
                    End With
                End With
            End If
        End With

    End Sub

    Sub CestUnNombre(sender As TextBox, e As EventArgs)
        ControleSaisie(sender, e, True, False, False, False, False)
    End Sub
    Sub CheckNombre(sender As TextBox, e As CancelEventArgs)
        e.Cancel = Not IsNumeric(sender.Text)
    End Sub
    Sub CheckDate(sender As TextBox, e As CancelEventArgs)
        e.Cancel = Not EstDate(sender.Text)
    End Sub
    Sub Div_First()
        frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Selected = False
        inDx = 0
        Matricule_txt.Text = frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Value
        frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Selected = True
        Request()
    End Sub
    Sub Div_Last()
        frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Selected = False
        inDx = frmPrePaie.PrePaie_Grd.RowCount - 1
        If inDx >= 0 Then
            Matricule_txt.Text = frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Value
            frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Selected = True
            Request()
        End If
    End Sub
    Sub Div_Next()

        If inDx < frmPrePaie.PrePaie_Grd.RowCount - 1 Then
            frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Selected = False
            inDx += 1
            Matricule_txt.Text = frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Value
            frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Selected = True
            Request()
        Else
            ShowMessageBox("Dernière ligne", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
        End If
    End Sub
    Sub Div_Back()
        If inDx > 0 Then
            frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Selected = False
            inDx -= 1
            Matricule_txt.Text = frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Value
            frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Selected = True
            Request()
        Else
            ShowMessageBox("Première ligne", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
        End If
    End Sub
    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        ChargerAgent()
        If TblAgent Is Nothing Then GoTo suite
        If TblAgent.Rows.Count = 0 Then GoTo suite
        Dim nrw() As DataRow = TblAgent.Select("Matricule='" & Matricule_txt.Text & "'")
        If nrw.Length = 0 Then GoTo suite
        Nom_txt.Text = nrw(0)("Nom")
        Dat_Naissance_txt.Text = nrw(0)("Dat_Naissance")
        Typ_Agent_txt.Text = nrw(0)("Typ_Agent")
        Typ_Contrat_txt.Text = nrw(0)("Typ_Contrat")
        Dat_Entree_txt.Text = nrw(0)("Dat_Entree")
        Typ_Periode_txt.Text = nrw(0)("Typ_Periode")

        'Afficher la photo
        Dim ImageData As Object = nrw(0)("Photo") 'CnExecuting("select Photo from RH_Agent where Matricule='" & Matricule_Text.Text & "'  and id_Societe=" & Societe.id_Societe).Fields(0).Value
        pbPhoto.Image = AffichagePhoto(ImageData)
        Exit Sub
suite:
        Nom_txt.Text = ""
        Dat_Naissance_txt.Text = ""
        Typ_Agent_txt.Text = ""
        Typ_Contrat_txt.Text = ""
        Dat_Entree_txt.Text = ""
        Typ_Periode_txt.Text = ""
        pbPhoto.Image = Nothing
    End Sub
    Private Sub Bulletin_chk_CheckedChanged(sender As Object, e As EventArgs)
        If Me.IsHandleCreated Then
            Request()
        End If
    End Sub
    Private Sub Mensuel_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Mensuel_chk.CheckedChanged, Bulletin_chk.CheckedChanged
        If IsHandleCreated And Visible Then
            Request()
        End If
    End Sub

    Private Sub Afficher_Rubriques_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Afficher_Rubriques_chk.CheckedChanged
        With MyGrd
            If .DataSource Is Nothing Then Return
            If .Columns.Count = 0 Then Return
            .Columns("Code").Visible = Afficher_Rubriques_chk.Checked
        End With
    End Sub
End Class