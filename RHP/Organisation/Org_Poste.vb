Imports System.Reflection

Public Class Org_Poste
    Friend Code As String = ""
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim New_D As ud_btn
    Dim niveauGrade As Integer = 0
    Private WithEvents TagEditor as ud_TextBox
    Private ReadOnly SoftSkillAC As New AutoCompleteStringCollection()
    Sub Chargement()
        If Background_Academique_cbo.Items.Count = 0 Then Background_Academique_cbo.fromRubrique("Niveau")
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Next_D = dictButtons("Next_D")
            Back_D = dictButtons("Back_D")
            Last_D = dictButtons("Last_D")
            First_D = dictButtons("First_D")
            New_D = dictButtons("New_D")
        End If
    End Sub
    Private Sub Org_Poste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        InitTagsPanel()
        Dim img As New ImageList()
        img.ImageSize = New Size(1, 22)    ' 36 px de hauteur de ligne
        TachesAttributions_lv.SmallImageList = img
        Responsabilites_lv.SmallImageList = img
    End Sub
    Sub Request()
        Chargement()
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'  and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
        End If
        If Lib_Poste_txt.Text = "************" Then Exit Sub
        DroitAcces(Me, IIf(theUser.Typ_Role = "Org_Poste", False, DroitModify_Fiche(Cod_Poste_txt.Text, Me)))

        niveauGrade = 0
        Domaines_Competence_Pnl.Controls.Clear()
        Domaines_Competence_Pnl.Text = ""
        Soft_Skills_Pnl.Controls.Clear()
        Soft_Skills_Pnl.Text = ""
        TachesAttributions_lv.Items.Clear()
        TachesAttributions_lv.Tag = ""
        Dim SqlStr As String = $"SELECT Cod_Poste, Lib_Poste, Cod_Grade, Soft_Skills, Domaines_Competence, 
                            Background_Academique, nb_Annees_Experience, Mission, TachesAttributions,Responsabilites,
                            Dependance_Hierarchique, Dependance_fonctionnelle
FROM     Org_Poste
where Cod_Poste='{Cod_Poste_txt.Text}' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        If Tbl.Rows.Count > 0 Then
            With Tbl
                Cod_Poste_txt.Text = IsNull(.Rows(0).Item("Cod_Poste"), "")
                Lib_Poste_txt.Text = IsNull(.Rows(0).Item("Lib_Poste"), "")
                Cod_Grade_txt.Text = IsNull(.Rows(0).Item("Cod_Grade"), "")
                Soft_Skills_Pnl.Text = IsNull(.Rows(0).Item("Soft_Skills"), "")
                Domaines_Competence_Pnl.Text = IsNull(.Rows(0).Item("Domaines_Competence"), "")
                Background_Academique_cbo.SelectedValue = IsNull(.Rows(0).Item("Background_Academique"), "")
                nb_Annees_Experience.Value = IsNull(.Rows(0).Item("nb_Annees_Experience"), 0)
                Dependance_Hierarchique_txt.Text = IsNull(.Rows(0).Item("Dependance_Hierarchique"), "")
                Dependance_fonctionnelle_txt.Text = IsNull(.Rows(0).Item("Dependance_fonctionnelle"), "")
                TachesAttributions_lv.Tag = IsNull(.Rows(0).Item("TachesAttributions"), "")
                Responsabilites_lv.Tag = IsNull(.Rows(0).Item("Responsabilites"), "")
                Mission_txt.Text = IsNull(.Rows(0).Item("Mission"), "")
            End With
            'chargement des compétences
            Dim laListe = IsNull(Domaines_Competence_Pnl.Text, "").Split(";").ToList()
            If laListe.Count > 0 Then
                For Each c In laListe
                    If Not String.IsNullOrWhiteSpace(c) Then
                        If Domaines_Competence_Pnl.Controls.Find(c, True).Length = 0 Then
                            AddCompetence(c)
                        End If
                    End If
                Next
                RearrangeControls()
            End If
            'Chargement des skills
            laListe = IsNull(Soft_Skills_Pnl.Text, "").Split(";").ToList()
            AddTagsToPanel(laListe)

            'charger les attribution
            laListe = IsNull(TachesAttributions_lv.Tag, "").Split(";").ToList()

            For Each c In laListe
                If Not String.IsNullOrWhiteSpace(c) Then
                    If TachesAttributions_lv.Items.Find(c, True).Length = 0 Then
                        normalizeItem(TachesAttributions_lv, New ListViewItem, c)
                    End If
                End If
            Next
            'charger les responsabilités
            laListe = IsNull(Responsabilites_lv.Tag, "").Split(";").ToList()
            ' laListe = "Superviser la comptabilité générale et auxiliaire; Piloter les clôtures mensuelles et annuelles; Mettre en place des contrôles; Produire le reporting; Coordonner CAC et DGI".Split(";").ToList()
            For Each c In laListe
                If Not String.IsNullOrWhiteSpace(c) Then
                    If Responsabilites_lv.Items.Find(c, True).Length = 0 Then
                        normalizeItem(Responsabilites_lv, New ListViewItem, c)
                    End If
                End If
            Next
        ElseIf Cod_Poste_txt.Text.Trim = "" Then
            Reset_Form(Me)
        End If
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Poste_txt.Text)
            Code = Cod_Poste_txt.Text
        End If
    End Sub
    Sub Enregistrer()
        Dim rsl As savingResult = Saving()

        ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
        If rsl.result Then Cod_Post_txt_TextChanged(Nothing, Nothing)

    End Sub
    Function Saving() As savingResult
        Try
            If CnExecuting("Select count(*) from Controle_Access where Name_Ecran='RH_Preparation_Paie' and Process_Id!='" & ProcessId & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
                MessageBoxRHP(687)
            End If
            Dim ErrStr As String = ""
            If Trim(Cod_Poste_txt.Text) = "" Then
                Return New savingResult With {.message = "Code poste vide", .result = False}
            End If
            If Lib_Poste_txt.Text.Contains("**") Then
                Return New savingResult With {.message = "Erreur Nom du poste (contient **)", .result = False}
            End If
            If Trim(Cod_Grade_txt.Text) = "" Then
                Return New savingResult With {.message = "Grade vide", .result = False}
            End If
            majNiveauGrade()

            If Background_Academique_cbo.SelectedIndex = -1 Then
                ErrStr = "Renseignez le background économique requis"
            End If
            If Dependance_Hierarchique_txt.Text.Trim <> "" Then
                Dim sqlStr = $"select count(*) from Org_Poste p
                        where Cod_Poste='{Dependance_Hierarchique_txt.Text}' and id_Societe={Societe.id_Societe} and 
                        exists(select 1 from Org_Grade where Cod_Grade=p.Cod_Grade  and id_Societe={Societe.id_Societe} and Niveau<{niveauGrade})"
                Dim nb = CnExecuting(sqlStr).Fields(0).Value
                If (nb = 0) Then
                    Return New savingResult With {.message = "Incohérence entre le niveau hiérarchique  la dépendance hiérarchique et le poste en cours.", .result = False}
                End If
            End If
            If Dependance_fonctionnelle_txt.Text.Trim <> "" Then
                Dim sqlStr = $"select count(*) from Org_Poste p
                        where Cod_Poste='{Dependance_fonctionnelle_txt.Text}' and id_Societe={Societe.id_Societe} and 
                        exists(select 1 from Org_Grade where Cod_Grade=p.Cod_Grade and id_Societe={Societe.id_Societe} and Niveau<{niveauGrade})"
                Dim nb = CnExecuting(sqlStr).Fields(0).Value
                If (nb = 0) Then
                    Return New savingResult With {.message = "Incohérence entre le niveau hiérarchique de la dépendance fonctionnelle et le poste en cours.", .result = False}
                End If
            End If

            Domaines_Competence_Pnl.Text = ""
            For Each cnt As ud_Domaine_Competence In Domaines_Competence_Pnl.Controls
                Domaines_Competence_Pnl.Text &= If(String.IsNullOrWhiteSpace(Domaines_Competence_Pnl.Text), "", ";") & cnt.Name & "$" & cnt.Rating()
            Next
            Soft_Skills_Pnl.Text = ""
            For Each cnt As ud_TagChip In Soft_Skills_Pnl.Controls
                Soft_Skills_Pnl.Text &= If(String.IsNullOrWhiteSpace(Soft_Skills_Pnl.Text), "", ";") & cnt.Tag
            Next
            TachesAttributions_lv.Tag = ""
            For Each cnt As ListViewItem In TachesAttributions_lv.Items
                TachesAttributions_lv.Tag &= If(String.IsNullOrWhiteSpace(TachesAttributions_lv.Tag), "", ";") & cnt.Name
            Next
            Responsabilites_lv.Tag = ""
            For Each cnt As ListViewItem In Responsabilites_lv.Items
                Responsabilites_lv.Tag &= If(String.IsNullOrWhiteSpace(Responsabilites_lv.Tag), "", ";") & cnt.Name
            Next
            Dim rs As New ADODB.Recordset
            Dim Dat As Date = Now.Date
            Dim CompteurAuto As Boolean = Societe.Compteur_Auto
            Code = Cod_Poste_txt.Text
            Dim Cod_Sql As String = "select * from Org_Poste where Cod_Poste='" & Cod_Poste_txt.Text & "' and isnull(Cod_Poste,'')<>''  and id_Societe=" & Societe.id_Societe
            rs.Open(Cod_Sql, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Cod_Poste").Value = Code
                rs("id_Societe").Value = Societe.id_Societe
                rs("Created_By").Value = theUser.Login
                rs("Dat_Crea").Value = Dat
            Else
                rs.Update()
            End If
            rs("Lib_Poste").Value = Lib_Poste_txt.Text
            rs("Cod_Grade").Value = Cod_Grade_txt.Text
            rs("Background_Academique").Value = If(Background_Academique_cbo.SelectedIndex >= 0, Background_Academique_cbo.SelectedValue, "")
            rs("nb_Annees_Experience").Value = nb_Annees_Experience.Value
            rs("Dependance_Hierarchique").Value = Dependance_Hierarchique_txt.Text
            rs("Dependance_fonctionnelle").Value = Dependance_fonctionnelle_txt.Text
            rs("Domaines_Competence").Value = Domaines_Competence_Pnl.Text
            rs("Mission").Value = Mission_txt.Text
            rs("TachesAttributions").Value = TachesAttributions_lv.Tag
            rs("Responsabilites").Value = Responsabilites_lv.Tag
            rs("Soft_Skills").Value = Soft_Skills_Pnl.Text
            rs("Dat_Modif").Value = Dat
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()

            If ErrStr <> "" Then
                Return New savingResult With {.message = ErrStr, .result = True}
            Else
                Return New savingResult With {.message = "Enregistré avec succès", .result = True}
            End If
        Catch ex As Exception
            Return New savingResult With {.message = ex.Message, .result = False}
        End Try
    End Function
    Private Sub DependanceHiera_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles DependanceHiera.LinkClicked
        majNiveauGrade()
        Appel_Zoom1("MS016", Dependance_Hierarchique_txt, Me, $" exists(select 1 from Org_Grade g where g.Cod_Grade=Org_Poste.Cod_Grade and id_Societe={Societe.id_Societe} and Niveau<{niveauGrade})")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        majNiveauGrade()
        Appel_Zoom1("MS016", Dependance_fonctionnelle_txt, Me, $" exists(select 1 from Org_Grade g where g.Cod_Grade=Org_Poste.Cod_Grade and id_Societe={Societe.id_Societe} and Niveau<{niveauGrade})")
    End Sub

    Private Sub poste__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles poste_.LinkClicked
        Appel_Zoom1("MS016", Cod_Poste_txt, Me)
    End Sub

    Private Sub Grade__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Grade_.LinkClicked
        Appel_Zoom1("MS015", Cod_Grade_txt, Me)
    End Sub
    Private Sub Cod_Grade_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Grade_txt.TextChanged
        Lib_Grade_txt.Text = FindLibelle("Lib_Grade", "Cod_Grade", Cod_Grade_txt.Text, "Org_Grade")
        majNiveauGrade()
    End Sub
    Sub majNiveauGrade()
        Dim niv = FindLibelle("Niveau", "Cod_Grade", Cod_Grade_txt.Text, "Org_Grade")
        If IsNumeric(niv) Then
            niveauGrade = CInt(niv)
        Else
            niveauGrade = 0
        End If
    End Sub
    Private Sub Cod_Post_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Poste_txt.TextChanged
        Try
            If Not Cod_Poste_txt.ReadOnly Then Return
            Request()

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Cod_Poste_txt_Leave(sender As Object, e As EventArgs) Handles Cod_Poste_txt.Leave
        Try
            If Cod_Poste_txt.ReadOnly Then Return
            Request()
            Enabling(Cod_Poste_txt, False)
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Domaines_Competence_Pnl.Controls.Clear()
        Domaines_Competence_Pnl.ResetText()
        Soft_Skills_Pnl.Controls.Clear()
        Soft_Skills_Pnl.ResetText()
        With Cod_Poste_txt
            Enabling(Cod_Poste_txt, True)
            .Select()
        End With
    End Sub
    Sub Div_First()
        If Cod_Poste_txt.Text <> "" Then
            Diviseur_First("Org_Poste", "Cod_Poste", "Cod_Poste", Cod_Poste_txt)
        End If
    End Sub
    Sub Div_Back()
        If Cod_Poste_txt.Text <> "" Then
            Diviseur_Back("Org_Poste", "Cod_Poste", "Cod_Poste", Cod_Poste_txt)
        End If
    End Sub
    Sub Div_Next()
        If Cod_Poste_txt.Text <> "" Then
            Diviseur_Next("Org_Poste", "Cod_Poste", "Cod_Poste", Cod_Poste_txt)
        End If
    End Sub
    Sub Div_Last()
        If Cod_Poste_txt.Text <> "" Then
            Diviseur_Last("Org_Poste", "Cod_Poste", "Cod_Poste", Cod_Poste_txt)
        End If
    End Sub
    Sub Deleting()
        If Cod_Poste_txt.Text = "" Then Exit Sub
        If ShowMessageBox("Etes vous sûr de vouloir supprimer ce poste?" & Cod_Poste_txt.Text, "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        Dim StrDel As String = String.Format("select 'RH_Agent' as Tbl,count(*) Nb from RH_Agent where Cod_Poste='{0}' and id_Societe='{1}' 
union all 
select 'RH_Agent_Historique' as Tbl,count(*) from Recrutement_Demande where Cod_Poste='{0}' and id_Societe='{1}'  
select 'RH_Conge_Provision_Detail' as Tbl,count(*) from RH_Simulation where Cod_Poste='{0}' and id_Societe='{1}'  union all 
select 'RH_Conge_Suivi' as Tbl,count(*) from RH_Conge_Suivi where Cod_Poste='{0}' and id_Societe='{1}'  union all 
select 'RH_Dossier_Maladie' as Tbl,count(*) from CVTheque where Cod_Poste='{0}' and id_Societe='{1}' 
", Cod_Poste_txt.Text, Societe.id_Societe)
        Dim TblDel As DataTable = DATA_READER_GRD(StrDel)
        Dim nrw() As DataRow = TblDel.Select("Nb>0")
        If nrw.Length > 0 Then
            ShowMessageBox("Ce poste est utilisé dans la table : " & nrw(0)("Tbl"), "Suppression", MessageBoxButtons.OKCancel, msgIcon.Stop)
            Return
        End If
        CnExecuting("delete from Org_Poste where id_Societe=" & Societe.id_Societe & " and Cod_Poste='" & Cod_Poste_txt.Text & "'")
        ShowMessageBox("Le poste " & Lib_Poste_txt.Text & " a été supprimé avec succès ", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Stop)
        Reset_Form(Me)
    End Sub
    Private Sub Dependance_fonctionnelle_txt_TextChanged(sender As Object, e As EventArgs) Handles Dependance_fonctionnelle_txt.TextChanged
        Lib_Dependance_fonctionnelle_txt.Text = FindLibelle("Lib_Poste", "Cod_Poste", Dependance_fonctionnelle_txt.Text, "Org_Poste")
    End Sub
    Private Sub Dependance_Hierarchique_txt_TextChanged(sender As Object, e As EventArgs) Handles Dependance_Hierarchique_txt.TextChanged
        Lib_Dependance_Hierarchique_txt.Text = FindLibelle("Lib_Poste", "Cod_Poste", Dependance_Hierarchique_txt.Text, "Org_Poste")
    End Sub
#Region "Competence"
    Private Sub Comptence_Pnl_MouseDoubleClick(sender As Panel, e As MouseEventArgs) Handles Domaines_Competence_Pnl.MouseDoubleClick

        Dim laListe = IsNull(sender.Text, "").Split(";").ToList()
        Dim f As New Zoom_GPEC_Domaines_Competence
        With f
            .domaines = laListe
            .ShowDialog()
        End With
        Dim domList = stringToDictionary(String.Join(";"c, laListe)).Keys()
        For i = sender.Controls.Count - 1 To 0 Step -1
            If Not domList.Contains(sender.Controls(i).Name) Then
                sender.Controls.RemoveAt(i)
            End If
        Next
        For Each c In laListe
            If Not String.IsNullOrWhiteSpace(c) Then
                If sender.Controls.Find(c.Split("$")(0), True).Length = 0 Then
                    AddCompetence(c)
                End If
            End If
        Next
        RearrangeControls()
        sender.Text = String.Join(";", laListe)
    End Sub
    Sub AddCompetence(competenceName As String)
        If String.IsNullOrWhiteSpace(competenceName) Then Return
        Dim nomCom As String = ""
        Dim note As Double = 1
        Dim _rw = competenceName.Split("$"c)
        nomCom = _rw(0)
        If _rw.Length > 1 Then
            If IsNumeric(_rw(1)) Then note = CDbl(_rw(1))
        End If
        Dim ud As New ud_Domaine_Competence
        With ud
            .canRate = True
            .Nom = nomCom
            .Rating = note
            Domaines_Competence_Pnl.Controls.Add(ud)
        End With
    End Sub
    Public Sub RearrangeControls()
        Dim x, y, sp As Integer
        sp = 5 ' Espace entre les contrôles
        x = sp
        y = sp

        Dim controlHeight As Integer = 0 ' Utilisé pour suivre la hauteur du dernier contrôle traité
        Domaines_Competence_Pnl.Text = ""
        For Each cnt As ud_Domaine_Competence In Domaines_Competence_Pnl.Controls
            If controlHeight = 0 Then
                controlHeight = cnt.Height ' Initialisez avec la hauteur du premier contrôle si non défini
            End If

            ' Calculez la nouvelle position x, y pour le contrôle actuel
            If x + cnt.Width + sp <= Domaines_Competence_Pnl.Width Then
                ' Assez d'espace pour placer ce contrôle à côté du précédent
                cnt.Location = New Point(x, y)
                x += cnt.Width + sp
            Else
                ' Pas assez d'espace, revenez au début et déplacez vers le bas
                x = sp
                y += controlHeight + sp
                cnt.Location = New Point(x, y)
                x += cnt.Width + sp
            End If
            Domaines_Competence_Pnl.Text &= If(String.IsNullOrWhiteSpace(Domaines_Competence_Pnl.Text), "", ";") & cnt.Name & "$" & cnt.Rating()
        Next
    End Sub
    Sub SuppressionDomaine(ud As ud_Domaine_Competence)
        Domaines_Competence_Pnl.Controls.Remove(ud)
        RearrangeControls()
    End Sub
#End Region
#Region "Skills"
    ' Appelle une fois (ex. dans Form_Load)
    Private Sub InitTagsPanel()
        Soft_Skills_Pnl.AutoScroll = True
        AddHandler Soft_Skills_Pnl.Resize, Sub() RearrangeControls()
        AddHandler Soft_Skills_Pnl.DoubleClick, Sub()
                                                    Dim txt As New TextBox
                                                    Dim f As New Zoom_Libre
                                                    Using f
                                                        f.Libre_GRD.DataSource = DATA_READER_GRD($"select value as Code,value as Intitulé from String_Split( (select STRING_AGG( Soft_Skills ,';') as softSkill  from Org_Poste where id_societe={Societe.id_Societe} and isnull(Soft_Skills,'')!=''),';') group by value")
                                                        f.ZoomObject = txt
                                                        f.ShowDialog()
                                                    End Using
                                                    If txt.Text.Trim <> "" Then
                                                        Dim str = IsNull(Soft_Skills_Pnl.Text, "") & If(IsNull(Soft_Skills_Pnl.Text, "") <> "", ";", "") & txt.Text.Trim
                                                        AddTagsToPanel(str.Split(";"))
                                                    End If
                                                End Sub

    End Sub

    Private Sub AddTagsToPanel(tags As IEnumerable(Of String))
        For Each raw In tags
            Dim t = NormalizeTag(raw)
            If t = "" Then Continue For
            If Soft_Skills_Pnl.Controls.OfType(Of ud_TagChip)().Any(Function(ch) String.Equals(ch.TextTag, t, StringComparison.OrdinalIgnoreCase)) Then Continue For

            Dim tg As New ud_TagChip With {
            .Name = "tg_" & SafeName(t),
            .TextTag = t,
            .Tag = raw,
            .Margin = New Padding(4)
        }
            AddHandler tg.Removed, Sub()
                                       Soft_Skills_Pnl.Controls.Remove(tg)
                                       tg.Dispose()
                                       RearrangeControls(Soft_Skills_Pnl)
                                   End Sub

            Soft_Skills_Pnl.Controls.Add(tg)
        Next
        RearrangeControls(Soft_Skills_Pnl)
    End Sub

    Private Sub RearrangeControls(pnl As Panel)
        Dim hGap = 6, vGap = 6
        Dim x = pnl.Padding.Left, y = pnl.Padding.Top
        Dim maxW = pnl.ClientSize.Width - pnl.Padding.Right
        Dim lineH = 0
        pnl.ResetText()

        ' Garde l'ordre d’ajout
        For Each c In pnl.Controls.OfType(Of ud_TagChip)().OrderBy(Function(z) z.TabIndex)
            c.AutoSize = True
            c.PerformLayout()

            If x > pnl.Padding.Left AndAlso x + c.Width > maxW Then
                x = pnl.Padding.Left
                y += lineH + vGap
                lineH = 0
            End If

            c.Location = New Point(x, y)
            x += c.Width + hGap
            lineH = Math.Max(lineH, c.Height)
            pnl.Text = If(pnl.Text.Trim = "", "", ";") & c.Tag
        Next
    End Sub

    Private Function NormalizeTag(s As String) As String
        If s Is Nothing Then Return ""
        s = s.Trim()
        If s = "" Then Return ""
        If Not s.StartsWith("#") Then s = "#" & s.Replace("#", "")
        Return s.Replace(" ", "")
    End Function

    Private Function SafeName(t As String) As String
        Dim n = New String(t.Where(Function(ch) Char.IsLetterOrDigit(ch)).ToArray())
        If n = "" Then n = Guid.NewGuid().ToString("N")
        Return n.ToLowerInvariant()
    End Function
    Private Sub Ajouter_btn_Click(sender As Object, e As EventArgs) Handles Ajouter_btn.Click
        Dim rsl As String = ShowInputBox("Saisissez un nouveau soft skill", "Soft skill", ChampType._String)
        If IsNull(rsl, "").Trim <> "" Then
            Dim str = IsNull(Soft_Skills_Pnl.Text, "") & If(IsNull(Soft_Skills_Pnl.Text, "") <> "", ";", "") & rsl
            AddTagsToPanel(str.Split(";"))
        End If
    End Sub
#End Region
    Sub normalizeItem(lv As ListView, itm As ListViewItem, str As String)
        itm.Name = str
        With lv
            If Not lv.Items.Contains(itm) Then
                lv.Items.Add(itm)
            End If
            Dim nb = .Items.Count
            For Each c As ListViewItem In .Items
                str = c.Name.Trim
                str = str.Substring(0, 1).ToUpper() & str.Substring(1, str.Length - 1)
                c.Text = "-" & Droite("000000" & c.Index + 1, (nb.ToString.Length)) & ". " & str
            Next
        End With
    End Sub
    Public Sub MoveListViewItem(lv As ListView, index As Integer, delta As Integer)
        If index < 0 OrElse index >= lv.Items.Count OrElse delta = 0 Then Return
        Dim target = Math.Max(0, Math.Min(lv.Items.Count - 1, index + delta))
        If target = index Then Return

        lv.BeginUpdate()
        Try
            Dim it As ListViewItem = lv.Items(index)
            lv.Items.RemoveAt(index)             ' ne pas décrémenter target
            If target > lv.Items.Count Then target = lv.Items.Count ' sécurité fin de liste
            lv.Items.Insert(target, it)

            lv.SelectedIndices.Clear()
            it.Selected = True : it.Focused = True
            lv.EnsureVisible(target)
            normalizeItem(lv, it, it.Name)
        Finally
            lv.EndUpdate()
        End Try
    End Sub
    Private Sub task_edit_btn_Click(sender As Object, e As EventArgs) Handles task_edit_btn.Click
        With TachesAttributions_lv
            Dim _itms = .SelectedItems
            If _itms.Count = 0 Then Return

            Dim rsl As String = ShowInputBox("Modifier une tâche ou attributions", "Tâches et attributions", ChampType._String, msgIcon.Information, _itms(0).Text)
            If IsNull(rsl, "").Trim <> "" Then
                normalizeItem(TachesAttributions_lv, _itms(0), rsl)
                .Tag = ""
                For i = 0 To .Items.Count - 1
                    .Tag &= IIf(IsNull(.Tag, "") = "", "", ";") & .Items(i).Name
                Next
            End If
        End With
    End Sub
    Private Sub task_up_btn_Click(sender As Object, e As EventArgs) Handles task_up_btn.Click
        With TachesAttributions_lv
            If .SelectedIndices.Count = 0 Then Return
            MoveListViewItem(TachesAttributions_lv, .SelectedIndices(0), -1)
            .Tag = ""
            For i = 0 To .Items.Count - 1
                .Tag &= IIf(IsNull(.Tag, "") = "", "", ";") & .Items(i).Name
            Next
        End With
    End Sub
    Private Sub task_down_btn_Click(sender As Object, e As EventArgs) Handles task_down_btn.Click
        With TachesAttributions_lv
            If .SelectedIndices.Count = 0 Then Return
            MoveListViewItem(TachesAttributions_lv, .SelectedIndices(0), +1)
            .Tag = ""
            For i = 0 To .Items.Count - 1
                .Tag &= IIf(IsNull(.Tag, "") = "", "", ";") & .Items(i).Name
            Next
        End With
    End Sub
    Private Sub task_add_new_btn_Click(sender As Object, e As EventArgs) Handles task_add_new_btn.Click
        Dim rsl As String = ShowInputBox("Saisissez une nouvelle tâche ou attributions", "Tâches et attributions", ChampType._String)
        If IsNull(rsl, "").Trim <> "" Then
            Dim str = IsNull(TachesAttributions_lv.Tag, "") & If(IsNull(TachesAttributions_lv.Tag, "") <> "", ";", "") & rsl
            For Each c In rsl.Split(";")
                normalizeItem(TachesAttributions_lv, New ListViewItem, c.Trim)
            Next

            TachesAttributions_lv.Tag = str
        End If
    End Sub
    Private Sub task_add_btn_Click(sender As Object, e As EventArgs) Handles task_add_btn.Click
        Dim txt As New TextBox
        Dim f As New Zoom_Libre
        Using f
            f.Libre_GRD.DataSource = DATA_READER_GRD($"select value as Code,value as Intitulé from String_Split( (select STRING_AGG( TachesAttributions ,';') as TachesAttributions  from Org_Poste where id_societe={Societe.id_Societe} and isnull(TachesAttributions,'')!=''),';') group by value")
            f.ZoomObject = txt
            f.ShowDialog()
        End Using
        If txt.Text.Trim <> "" Then
            Dim str = IsNull(Soft_Skills_Pnl.Text, "") & If(IsNull(Soft_Skills_Pnl.Text, "") <> "", ";", "") & txt.Text.Trim
            normalizeItem(TachesAttributions_lv, New ListViewItem, txt.Text.Trim)
            TachesAttributions_lv.Tag = str
        End If
    End Sub
    Private Sub task_del_btn_Click(sender As Object, e As EventArgs) Handles task_del_btn.Click
        With TachesAttributions_lv
            Dim _itms = .SelectedItems
            If _itms.Count = 0 Then Return
            For i = .Items.Count - 1 To 0 Step -1
                If .Items(i).Selected Then .Items.RemoveAt(i)
            Next
            .Tag = ""
            For i = 0 To .Items.Count - 1
                .Tag &= IIf(IsNull(.Tag, "") = "", "", ";") & .Items(i).Text
            Next
        End With
    End Sub
#Region "Responsabilités"
    Private Sub resp_edit_btn_Click(sender As Object, e As EventArgs) Handles resp_edit_btn.Click
        With Responsabilites_lv
            Dim _itms = .SelectedItems
            If _itms.Count = 0 Then Return

            Dim rsl As String = ShowInputBox("Modifier une tâche ou attributions", "Tâches et attributions", ChampType._String, msgIcon.Information, _itms(0).Name)
            If IsNull(rsl, "").Trim <> "" Then
                normalizeItem(Responsabilites_lv, _itms(0), rsl)
                .Tag = ""
                For i = 0 To .Items.Count - 1
                    .Tag &= IIf(IsNull(.Tag, "") = "", "", ";") & .Items(i).Name
                Next
            End If
        End With
    End Sub
    Private Sub resp_up_btn_Click(sender As Object, e As EventArgs) Handles resp_up_btn.Click
        With Responsabilites_lv
            If .SelectedIndices.Count = 0 Then Return
            MoveListViewItem(Responsabilites_lv, .SelectedIndices(0), -1)
            .Tag = ""
            For i = 0 To .Items.Count - 1
                .Tag &= IIf(IsNull(.Tag, "") = "", "", ";") & .Items(i).Name
            Next
        End With
    End Sub
    Private Sub resp_down_btn_Click(sender As Object, e As EventArgs) Handles resp_down_btn.Click
        With Responsabilites_lv
            If .SelectedIndices.Count = 0 Then Return
            MoveListViewItem(Responsabilites_lv, .SelectedIndices(0), +1)
            .Tag = ""
            For i = 0 To .Items.Count - 1
                .Tag &= IIf(IsNull(.Tag, "") = "", "", ";") & .Items(i).Name
            Next
        End With
    End Sub
    Private Sub resp_add_new_btn_Click(sender As Object, e As EventArgs) Handles resp_add_new_btn.Click
        Dim rsl As String = ShowInputBox("Saisissez une nouvelle tâche ou attributions", "Tâches et attributions", ChampType._String)
        If IsNull(rsl, "").Trim <> "" Then
            Dim str = IsNull(Responsabilites_lv.Tag, "") & If(IsNull(Responsabilites_lv.Tag, "") <> "", ";", "") & rsl
            For Each c In rsl.Split(";")
                normalizeItem(Responsabilites_lv, New ListViewItem, c.Trim)
            Next

            Responsabilites_lv.Tag = str
        End If
    End Sub
    Private Sub resp_add_btn_Click(sender As Object, e As EventArgs) Handles resp_add_btn.Click
        Dim txt As New TextBox
        Dim f As New Zoom_Libre
        Using f
            f.Libre_GRD.DataSource = DATA_READER_GRD($"select value as Code,value as Intitulé from String_Split( (select STRING_AGG( TachesAttributions ,';') as TachesAttributions  from Org_Poste where id_societe={Societe.id_Societe} and isnull(TachesAttributions,'')!=''),';') group by value")
            f.ZoomObject = txt
            f.ShowDialog()
        End Using
        If txt.Text.Trim <> "" Then
            Dim str = IsNull(Soft_Skills_Pnl.Text, "") & If(IsNull(Soft_Skills_Pnl.Text, "") <> "", ";", "") & txt.Text.Trim
            normalizeItem(Responsabilites_lv, New ListViewItem, txt.Text.Trim)
            Responsabilites_lv.Tag = str
        End If
    End Sub
    Private Sub resp_del_btn_Click(sender As Object, e As EventArgs) Handles resp_del_btn.Click
        With Responsabilites_lv
            Dim _itms = .SelectedItems
            If _itms.Count = 0 Then Return
            For i = .Items.Count - 1 To 0 Step -1
                If .Items(i).Selected Then .Items.RemoveAt(i)
            Next
            .Tag = ""
            For i = 0 To .Items.Count - 1
                .Tag &= IIf(IsNull(.Tag, "") = "", "", ";") & .Items(i).Text
            Next
        End With
    End Sub
#End Region
End Class