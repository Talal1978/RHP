Imports System.ComponentModel

Public Class Zoom_RH_Preparation_Paie
    Friend CodPlan As String = ""
    Friend CodPreparation As String
    Friend inDx As Integer = 0
    Friend WithEvents Grd As New DataGridView
    Friend TblFunction As New DataTable
    Dim Pic As New PictureBox
    Dim oList As New CheckedListBox
    Dim TblAgent As New DataTable
    Dim Tbl_RubriquesBase, Tbl_Paie As New DataTable
    Friend PaieCloture As Boolean = False
    Friend frmPrePaie As New RH_Preparation_Paie
    Friend WithEvents MyGrdMensuel As New DataGridView
    Private Sub Zoom_RH_Preparation_Paie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MyGrd.RowCount = 0 Then PreparationInitiale()
        MyGrd.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        With Pic
            .Image = My.Resources.Grd_NonFilteree
            .BackColor = Color.Transparent
            .Parent = MyGrd
            .Size = New Size(20, 20)
            .Location = New Point(5, 5)
            MyGrd.Controls.Add(Pic)
            AddHandler .Click, AddressOf AfficherListeColonnes
        End With
        With oList
            .Location = New Point(5, 25)
            .Visible = False
            .Width = 300
            .Height = 450
            MyGrd.Controls.Add(oList)
            AddHandler .Leave, AddressOf MasquerListeColonnes
            AddHandler .ItemCheck, AddressOf itemCheckListe
        End With
        With Bulletin_chk
            .Checked = (frmPrePaie.PrePaie.elementDetailBulletinPaie.Length > 0)
            .Enabled = .Checked
        End With
        With Mensuel_chk
            .Checked = False
        End With
        Cod_Colonne.Visible = False
        With MyGrdMensuel
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
            .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
            .Dock = DockStyle.Fill
            .Visible = False
        End With
        Pnl.Controls.Add(MyGrdMensuel)
        Valeur.Tag = "float"
        Base.Tag = "float"
        Gain.Tag = "float"
        Retenue.Tag = "float"
        Tout_rb.Checked = True
    End Sub
    Sub itemCheckListe()
        If Not oList.Visible Then Return
        Tout_rb.Checked = False
        ShowCP_rb.Checked = False
        ShowEV_rb.Checked = False
        ShowGains_rb.Checked = False
        ShowRetenues_rb.Checked = False
    End Sub
    Sub AfficherListeColonnes()
        If Bulletin_chk.Checked Then Return
        oList.Visible = True
        oList.Select()
    End Sub
    Sub MasquerListeColonnes()
        If Bulletin_chk.Checked Then Return
        oList.Visible = False
        If MyGrd.ColumnCount = 0 Then Exit Sub
        With oList
            For i = 0 To .Items.Count - 1
                MyGrd.Rows(i).Visible = .GetItemChecked(i)
            Next
        End With
    End Sub
    Sub Request()
        If frmPrePaie.PrePaie.elementDetailBulletinPaie.Length = 0 Then Bulletin_chk.Checked = False
        Valeur.Visible = Not Bulletin_chk.Checked
        Base.Visible = Bulletin_chk.Checked
        Tx.Visible = Bulletin_chk.Checked
        Gain.Visible = Bulletin_chk.Checked
        Retenue.Visible = Bulletin_chk.Checked
        Recap_Pnl.Visible = Bulletin_chk.Checked

        With MyGrd
            If .RowCount = 0 Then PreparationInitiale()
            .Rows.Clear()
            Dim ColNom As String = ""
            Matricule_txt.Text = IsNull(Grd.Item("Matricule", inDx).Value, "")
            Dim nb As Integer = 0
            Dim Gains As Double = 0
            Dim Retenues As Double = 0
            Dim Remb As Double = 0
            If Bulletin_chk.Checked Then
                MyGrdMensuel.Visible = False
                .Visible = True
                If Not Cloture_Check.Checked And Tbl_Paie.Rows.Count > 0 Then frmPrePaie.PrePaie.CalculPaie(frmPrePaie.PrePaie_Grd.Item("Matricule", inDx).Value, True)
                For i = 0 To frmPrePaie.PrePaie.elementDetailBulletinPaie.Length - 1
                    ColNom = frmPrePaie.PrePaie.elementDetailBulletinPaie(i)
                    If Grd.Columns.Contains(ColNom) Then
                        Dim vrw() As DataRow = Tbl_RubriquesBase.Select("Cod_Rubrique='" & ColNom & "'")
                        Dim prw() As DataRow = Tbl_Paie.Select("Cod_Rubrique='" & ColNom & "' and Matricule='" & Matricule_txt.Text & "'")
                        Dim TypRubrique As String = IsNull(vrw(0)("Gain_Retenue"), "A")
                        Dim v_base, v_tx, v_nb As Double
                        v_base = 0
                        v_nb = 0
                        v_tx = 0
                        If TypRubrique = "R" Or TypRubrique = "G" Or IsNull(vrw(0)("Typ_Rubrique_Paie"), "") = "A_Remb" Then
                            If Grd.Columns(ColNom).Tag = "EC" Then
                                If Cloture_Check.Checked And prw.Length > 0 Then
                                    If IsNull(vrw(0)("Base"), "") <> "" Then v_base = prw(0)("Base")
                                    If IsNull(vrw(0)("Tx"), "") <> "" Then v_tx = prw(0)("Tx")
                                    If IsNull(vrw(0)("Nb"), "") <> "" Then v_nb = prw(0)("Nb")
                                Else
                                    Dim dicMat As Dictionary(Of String, Dictionary(Of String, Double)) = frmPrePaie.PrePaie.dicMat
                                    If dicMat.ContainsKey(Matricule_txt.Text & "_|_" & ColNom) Then
                                        If IsNull(vrw(0)("Base"), "") <> "" Then v_base = dicMat(Matricule_txt.Text & "_|_" & ColNom)("Base")
                                        If IsNull(vrw(0)("Tx"), "") <> "" Then v_tx = dicMat(Matricule_txt.Text & "_|_" & ColNom)("Tx")
                                        If IsNull(vrw(0)("Nb"), "") <> "" Then v_nb = dicMat(Matricule_txt.Text & "_|_" & ColNom)("Nb")
                                    End If
                                End If
                            Else
                                v_base = Grd.Item(ColNom, inDx).Value
                                v_nb = 1
                                v_tx = 0
                            End If

                        Else
                            v_base = Grd.Item(ColNom, inDx).Value
                            v_nb = Nothing
                            v_tx = Nothing
                        End If
                        If TypRubrique = "G" Then Gains += IsNull(Grd.Item(ColNom, inDx).Value, 0)
                        If TypRubrique = "R" Then Retenues += IsNull(Grd.Item(ColNom, inDx).Value, 0)
                        If TypRubrique = "A" And IsNull(vrw(0)("Typ_Rubrique_Paie"), "") = "A_Remb" Then
                            Gains += IsNull(Grd.Item(ColNom, inDx).Value, 0)
                            Remb += IsNull(Grd.Item(ColNom, inDx).Value, 0)
                            TypRubrique = "G"
                        End If
                        .Rows.Add(Grd.Columns(ColNom).HeaderText, Grd.Item(ColNom, inDx).Value, ColNom, v_base, IIf(v_tx <> 0, Math.Round(v_tx * 100, 2) & "%", CStr(v_nb)), IIf(TypRubrique = "G", Grd.Item(ColNom, inDx).Value, Nothing), IIf(TypRubrique = "R", Grd.Item(ColNom, inDx).Value, Nothing))
                        .Rows(nb).Visible = (CDbl(IIf(IsNumeric(Grd.Item(ColNom, inDx).Value), Grd.Item(ColNom, inDx).Value, 0)) <> 0)
                        .Rows(nb).Tag = Grd.Columns(ColNom).Tag
                        .Rows(nb).DefaultCellStyle = Grd.Columns(ColNom).DefaultCellStyle
                        .Item(Valeur.Index, nb).ReadOnly = Grd.Columns(i).ReadOnly
                        .Item(Valeur.Index, nb).Style.Format = Grd.Columns(i).DefaultCellStyle.Format
                        nb += 1
                    End If
                Next
                NetBulletin_txt.Text = FormatNumber(Math.Round(Gains - Retenues, 0), 2)
                NetCalcul_txt.Text = FormatNumber(IsNull(Grd.Item(frmPrePaie.PrePaie.ECSalNet, inDx).Value, 0), 2)
                EcartNet_txt.Text = FormatNumber(CDbl(NetBulletin_txt.Text) - CDbl(NetCalcul_txt.Text), 2)
                BrutBulletin_txt.Text = FormatNumber(Gains - Remb, 2)
                BrutCalcule_txt.Text = FormatNumber(IsNull(Grd.Item(frmPrePaie.PrePaie.ECSalaireBrut, inDx).Value, 0), 2)
                EcartBrut_txt.Text = FormatNumber(CDbl(BrutBulletin_txt.Text) - CDbl(BrutCalcule_txt.Text), 2)
            ElseIf Classic_chk.Checked Then
                MyGrdMensuel.Visible = False
                .Visible = True
                nb = 0
                For i = 0 To Grd.ColumnCount - 1
                    ColNom = Grd.Columns(i).Name
                    Select Case Grd.Columns(i).Tag
                        Case "EV", "EC", "EB", "CS", "FS", "FU", "FP", "EX"
                            .Rows.Add(Grd.Columns(i).HeaderText, Grd.Item(i, inDx).Value, ColNom, 0, 0, 0, 0)
                            .Rows(nb).Tag = Grd.Columns(ColNom).Tag
                            .Rows(nb).DefaultCellStyle = Grd.Columns(ColNom).DefaultCellStyle
                            .Item(Valeur.Index, nb).ReadOnly = Grd.Columns(i).ReadOnly
                            .Item(Valeur.Index, nb).Style.Format = Grd.Columns(i).DefaultCellStyle.Format
                            .Item(Valeur.Index, nb).Style.Alignment = IIf(IsNumeric(.Item(Valeur.Index, nb).Value), DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft)
                            .Rows(nb).Visible = oList.GetItemChecked(nb)
                            nb += 1
                    End Select
                Next
            ElseIf Mensuel_chk.Checked Then
                MyGrdMensuel.Visible = True
                .Visible = False
                RequestMensuel()
            End If
        End With

    End Sub
    Sub PreparationInitiale()
        oList.Items.Clear()
        TblAgent = DATA_READER_GRD("SELECT  Matricule, ltrim(rtrim(isnull( Nom_Agent,'')+ ' '+isnull( Prenom_Agent,''))) as Nom, convert(bit,case when isnull(Sexe,'H')='H' then 1 else 0 end) as EstH,
convert(bit,case when isnull(Sexe,'H')='F' then 1 else 0 end) as EstF,
Dat_Naissance, [dbo].[FindRubrique]('Typ_Agent',Typ_Agent) as Typ_Agent,
[dbo].[FindRubrique]('Typ_Contrat', Typ_Contrat) as Typ_Contrat , Dat_Entree, [dbo].[FindRubrique]('Typ_Periode',Typ_Periode) as Typ_Periode, Photo
FROM            RH_Agent
where id_Societe=" & Societe.id_Societe & " and isnull(Plan_Paie,'')='" & CodPlan & "'")
        Dim CodSql As String = "select Cod_Rubrique,Tx,Nb,Base,Relation_VBS , isnull(Gain_Retenue,'A') as Gain_Retenue, Typ_Rubrique_Paie from RH_Paie_Rubrique where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ") =" & Societe.id_Societe & " and Cod_Rubrique in ('" & Join(frmPrePaie.PrePaie.elementDetailBulletinPaie, "','") & "')"
        Tbl_RubriquesBase = DATA_READER_GRD(CodSql)
        CodSql = "select Matricule,Cod_Rubrique,Tx,Nb,Base,isnull(Gain_Retenue,'A') as Gain_Retenue 
                        from Rh_Preparation_Paie_Detail d
                        outer apply (select Gain_Retenue from RH_Paie_Rubrique where id_Societe=d.id_Societe and Cod_Rubrique=d.Cod_Rubrique)r
                        where id_Societe =" & Societe.id_Societe & " and Cod_Preparation='" & CodPreparation & "'
                        and Cod_Rubrique in ('" & Join(frmPrePaie.PrePaie.elementDetailBulletinPaie, "','") & "')"
        Tbl_Paie = DATA_READER_GRD(CodSql)
        With Grd
            If oList.Items.Count = 0 Then
                With Grd
                    For i = 0 To .Columns.Count - 1
                        Select Case Grd.Columns(i).Tag
                            Case "EV", "EC", "EB", "CS", "FS", "FU", "FP", "EX"
                                oList.Items.Add(.Columns(i).HeaderText, .Columns(i).Visible)
                        End Select
                    Next
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
        inDx = 0
        Request()
    End Sub
    Sub Div_Last()
        inDx = Grd.RowCount - 1
        If inDx >= 0 Then Request()
    End Sub
    Sub Div_Next()
        If inDx < Grd.RowCount - 1 Then
            inDx += 1
            Request()
        Else
            ShowMessageBox("Dernière ligne", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
        End If
    End Sub
    Sub Div_Back()
        If inDx > 0 Then
            inDx -= 1
            Request()
        Else
            ShowMessageBox("Première ligne", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
        End If
    End Sub
    Private Sub MyGrd_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles MyGrd.EditingControlShowing
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        With MyGrd
            If .Rows(.CurrentCell.RowIndex).Tag = "EV" And .CurrentCell.ColumnIndex = Valeur.Index Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With MyGrd
            If .Rows(.CurrentCell.RowIndex).Tag = "EV" And .CurrentCell.ColumnIndex = Valeur.Index Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, IIf(.CurrentCell.Style.Format = "N0", True, False), False, False, False)
            End If
        End With
    End Sub
    Private Sub ShowEV_rb_Click(sender As Object, e As EventArgs) Handles ShowCP_rb.CheckedChanged, ShowEV_rb.CheckedChanged, ShowGains_rb.CheckedChanged, ShowRetenues_rb.CheckedChanged, Tout_rb.CheckedChanged
        If Visible And IsHandleCreated And Classic_chk.Checked Then
            Dim estVisible As Boolean = False
            Dim rw() As DataRow = Nothing
            With MyGrd
                For i = 0 To .Rows.Count - 1
                    rw = TblFunction.Select("Cod_Function='" & .Item(Cod_Colonne.Index, i).Value & "'")
                    If rw.Length > 0 Then
                        If ShowEV_rb.Checked Or ShowGains_rb.Checked Or ShowRetenues_rb.Checked Or ShowCP_rb.Checked Then
                            estVisible = False
                            If rw(0)("Typ_Function") = "EV" And ShowEV_rb.Checked Then estVisible = True
                            If rw(0)("Gain_Retenue") = "G" And ShowGains_rb.Checked Then estVisible = True
                            If rw(0)("Gain_Retenue") = "R" And ShowRetenues_rb.Checked Then estVisible = True
                            If rw(0)("Patronal") And ShowCP_rb.Checked Then estVisible = True
                        Else
                            estVisible = Grd.Columns(CStr(.Item(Cod_Colonne.Index, i).Value)).Visible
                        End If
                        oList.SetItemChecked(i, estVisible)
                        .Rows(i).Visible = estVisible
                    End If
                Next
            End With
        End If

    End Sub
    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
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
    Private Sub Afficher_Rubriques_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Afficher_Rubriques_chk.CheckedChanged
        Cod_Colonne.Visible = Afficher_Rubriques_chk.Checked
        If MyGrdMensuel.Visible Then
            If MyGrdMensuel.Columns.Contains("Code") Then
                MyGrdMensuel.Columns("Code").Visible = Afficher_Rubriques_chk.Checked
            End If
        End If
    End Sub
    Private Sub Bulletin_chk_CheckedChanged(sender As Object, e As EventArgs)
        If Me.IsHandleCreated Then
            Request()
        End If
    End Sub
    Private Sub MyGrd_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles MyGrd.CellValidating
        If Grd Is Nothing Then Return
        Dim r As Integer = e.RowIndex
        Try
            If r < 0 Then Return
            If e.ColumnIndex = Valeur.Index Then
                With MyGrd
                    If .Rows(.CurrentCell.RowIndex).Tag = "EV" Then
                        Dim ColNam As String = ""
                        ColNam = .Item(Cod_Colonne.Index, r).Value
                        Grd.Item(ColNam, inDx).Value = e.FormattedValue
                        .Item(Valeur.Index, r).Style = Grd.Item(ColNam, inDx).Style
                        For i = 0 To .RowCount - 1
                            .Item(Valeur.Index, i).Value = Grd.Item(CStr(.Item(Cod_Colonne.Index, i).Value), inDx).Value
                        Next
                    End If
                End With
            End If
        Catch ex As Exception
            ShowMessageBox(ex.Message, Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
            e.Cancel = True
        End Try
    End Sub
    Private Sub Mensuel_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Mensuel_chk.CheckedChanged, Classic_chk.CheckedChanged, Bulletin_chk.CheckedChanged
        If IsHandleCreated And Visible Then
            Filtre_pnl.Visible = Classic_chk.Checked
            Request()
        End If
    End Sub
    Sub RequestMensuel()
        If Not MyGrdMensuel.Visible Then Return
        If Not EstDate(frmPrePaie.Dat_Deb_Periode_Text.Text) Then Return
        Dim Tbl As DataTable = DATA_READER_GRD("exec Sys_Rh_Paie_Matricule " & Societe.id_Societe & ", '" & Matricule_txt.Text & "', '" & CDate(frmPrePaie.Dat_Fin_Periode_Text.Text).Month & "', '" & CDate(frmPrePaie.Dat_Fin_Periode_Text.Text).Year & "'")
        With MyGrdMensuel
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
                .Frozen = True
            End With
            With .Columns("Code")
                .Width = 100
                .Visible = Afficher_Rubriques_chk.Checked
            End With
        End With
    End Sub
    Private Sub Zoom_RH_Preparation_Paie_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Grd = Nothing
    End Sub
End Class