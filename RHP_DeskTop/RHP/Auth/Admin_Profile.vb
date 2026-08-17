Imports DevComponents.AdvTree
Imports DevComponents.DotNetBar
Public Class Admin_Profile
    Dim NbNodes As Integer = 0
    Dim ElementStyle2, ElementStyle3 As New DevComponents.DotNetBar.ElementStyle()
    Dim oTable As New DataTable
    Friend Code As String = ""
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim New_D As ud_btn
    Dim Duplik_D As ud_btn
    Private Sub Cod_Profile_Label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Cod_Profile_Label.LinkClicked
        Appel_Zoom1("MS060", Cod_Profile_Text, Me)
        If Cod_Profile_Text.Text = "1" Then
            MessageBoxRHP(350)
            Cod_Profile_Text.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Cod_Profile_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Profile_Text.TextChanged
        Request()
    End Sub

    Sub Request()
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
        DroitAcces(Me, DroitModify_Fiche(Cod_Profile_Text.Text, Me))
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Profile_Text.Text)
            Code = Cod_Profile_Text.Text
        End If


        Lib_Profile_Text.Text = FindLibelle("Lib_Profile", "Cod_Profile", Cod_Profile_Text.Text, "Controle_Profile")
        Actif_Check.Checked = FindLibelle("Actif", "Cod_Profile", Cod_Profile_Text.Text, "Controle_Profile")
        Portail_Defaut_Check.Checked = (IsNull(FindLibelle("Portail_Defaut", "Cod_Profile", Cod_Profile_Text.Text, "Controle_Profile"), "false").ToString().ToLower() = "true")
        LeProfil.Text = Lib_Profile_Text.Text
        If Cod_Profile_Text.Text = "1" Then
            Actif_Check.Enabled = False
            Portail_Defaut_Check.Enabled = False
        Else
            Actif_Check.Enabled = True
            Portail_Defaut_Check.Enabled = True
        End If

        RequestAccess()
        RequestPortail()

    End Sub

    'Arborescence portail du profil :
    '- pages standards et sections de menus.json (référentiel Controle_Menu_Portail) ;
    '- sections créées en base (rubrique SP_Menu_Portail, Zoom_SP_Nouvelle_Section)
    '  absentes du référentiel ;
    '- requêtes exposées au portail (Param_Query_Widget : pages-requêtes estPortail
    '  et widgets du tableau de bord estWidget), Typ_Ecran = 'QRY' ;
    '- pages SP_ publiées du Designer (Controle_Designer), Typ_Ecran = 'SPP'.
    'Droits Visible/Actif du profil (Controle_Droit) : Name_Ecran = 'PRT_' + page/section
    '(le préfixe isole les droits portail des écrans desktop de mêmes noms), sauf les
    'requêtes, lues sous leur Cod_Query SANS préfixe (le backend portail contrôle leur
    'droit Actif sur Name_Ecran = Cod_Query). Pages SP_ : la case VISIBLE porte le
    'droit Consulter de Controle_Designer_Droit (pour ces pages, affichage au menu et
    'accès ne font qu'un) ; les autres habilitations (Créer/Modifier/...) se gèrent via
    'le menu contextuel du nœud (Zoom_Profile_Droits_SP).
    'Tous les outer apply sont en TOP 1 : une ligne Controle_Droit dupliquée en base
    'ne doit pas dupliquer l'entrée dans l'arbre.
    Sub RequestPortail()
        Try
            AdvPortail.Nodes.Clear()
            Dim CodSql As String = "select m.Name_Ecran,isnull(m.Text_Ecran,'') as Text_Ecran,isnull(m.Typ_Ecran,'ECR') as Typ_Ecran,isnull(m.Menu_Parent,'') as Menu_Parent,isnull(m.Rang,99) as Rang,isnull(o.Visible,'False') as Visible,isnull(o.Actif,'False') as Actif,cast('' as varchar(5)) as estPortail,cast('' as varchar(5)) as AccesPerso " &
                                   "from Controle_Menu_Portail m " &
                                   "outer apply (select top 1 Visible,Actif from Controle_Droit where Name_Ecran='PRT_' + m.Name_Ecran and Cod_Profile='" & Cod_Profile_Text.Text & "') o " &
                                   "union all " &
                                   "select r.Valeur,isnull(r.Membre,''),'MNU','',isnull(try_cast(r.Rang as int),99),isnull(o.Visible,'False'),isnull(o.Actif,'False'),cast('' as varchar(5)),cast('' as varchar(5)) " &
                                   "from Param_Rubriques r " &
                                   "outer apply (select top 1 Visible,Actif from Controle_Droit where Name_Ecran='PRT_' + r.Valeur and Cod_Profile='" & Cod_Profile_Text.Text & "') o " &
                                   "where r.Nom_Controle='SP_Menu_Portail' and isnull(r.Valeur,'')<>'' " &
                                   "and not exists (select 1 from Controle_Menu_Portail m2 where m2.Name_Ecran=r.Valeur) " &
                                   "union all " &
                                   "select q.Cod_Query,isnull(q.Nom_Query,''),'QRY',case when isnull(w.estPortail,'false')='true' then isnull(w.Menu_Parent,'') else '' end,isnull(w.Rang,99),isnull(o.Visible,'False'),isnull(o.Actif,'False'),case when isnull(w.estPortail,'false')='true' then 'true' else 'false' end,cast('' as varchar(5)) " &
                                   "from Param_Query q " &
                                   "join Param_Query_Widget w on w.Cod_Query=q.Cod_Query and (isnull(w.estWidget,'false')='true' or isnull(w.estPortail,'false')='true') " &
                                   "outer apply (select top 1 Visible,Actif from Controle_Droit where Name_Ecran=q.Cod_Query and Cod_Profile='" & Cod_Profile_Text.Text & "') o " &
                                   "union all " &
                                   "select p.Cod_Page,isnull(p.Nom_Page,''),'SPP',isnull(p.Menu_Parent,''),isnull(p.Rang,99),isnull(d.Consulter,'false'),'False',cast('' as varchar(5)),isnull(p.Acces_Personnalise,'true') " &
                                   "from Controle_Designer p " &
                                   "outer apply (select top 1 Consulter from Controle_Designer_Droit d where d.Cod_Page=p.Cod_Page and d.Cod_Profile='" & Cod_Profile_Text.Text & "') d " &
                                   "where p.Statut_Page='PUBLIE' " &
                                   "order by Rang"
            Dim pTable As DataTable = DATA_READER_GRD(CodSql)
            Dim nRows() As DataRow = pTable.Select("[Typ_Ecran]='MNU'", "Rang Asc")
            For i = 0 To nRows.Length - 1
                Dim N As New Node
                With N
                    .Name = nRows(i)("Name_Ecran")
                    .Text = nRows(i)("Text_Ecran")
                    .Cells.Add(New Cell)
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = True
                    .Cells(2).CheckBoxVisible = True
                    .Cells(1).Checked = CBool(nRows(i)("Visible"))
                    .Cells(2).Checked = CBool(nRows(i)("Actif"))
                    .Tag = {nRows(i)("Typ_Ecran"), Nothing, Nothing}
                    .Style = ElementStyle2
                End With
                AdvPortail.Nodes.Add(N)
                Dim mRows() As DataRow = pTable.Select("[Menu_Parent]='" & N.Name & "'", "Rang Asc")
                For j = 0 To mRows.GetUpperBound(0)
                    Dim M As New Node
                    With M
                        .Name = mRows(j)("Name_Ecran")
                        .Text = mRows(j)("Text_Ecran") & SuffixePortail(mRows(j)("Typ_Ecran"), mRows(j)("AccesPerso"))
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        'Pages SP_ (Typ SPP) : la case VISIBLE porte Consulter (affichage
                        'au menu et accès ne font qu'un pour ces pages) ; pas de case Actif
                        '(pas de contrôle distinct) ; aucune case quand l'accès est ouvert
                        'à tous les profils (Acces_Personnalise='false').
                        'Menu contextuel : les autres habilitations (Créer, Modifier, GED...).
                        .Cells(1).CheckBoxVisible = (mRows(j)("Typ_Ecran") <> "SPP" OrElse mRows(j)("AccesPerso") <> "false")
                        .Cells(2).CheckBoxVisible = (mRows(j)("Typ_Ecran") <> "SPP")
                        .Cells(1).Checked = CBool(mRows(j)("Visible"))
                        .Cells(2).Checked = CBool(mRows(j)("Actif"))
                        .Tag = {mRows(j)("Typ_Ecran"), mRows(j)("AccesPerso"), Nothing}
                        If mRows(j)("Typ_Ecran") = "SPP" Then .ContextMenu = CntDroitsSP
                    End With
                    VerrouillerAccueil(M)
                    N.Nodes.Add(M)
                Next
                'Une section contenant au moins un élément accessible à tout le monde
                '(page SP_ en accès ouvert, Acces_Personnalise='false') reste toujours
                'visible — sinon la page ouverte serait inaccessible : case Visible
                'cochée d'office (règle aussi appliquée par sp_menu_portail, et
                'forcée à True à l'enregistrement — cf. SavingPortailNodes).
                Dim Ouverte As Boolean = False
                For Each child As Node In N.Nodes
                    If IsNull(child.Tag(0), "") = "SPP" AndAlso IsNull(child.Tag(1), "") = "false" Then
                        Ouverte = True
                        Exit For
                    End If
                Next
                If Ouverte Then N.Cells(1).Checked = True
            Next
            'Pages racines (sans section : Dashboard, DiverseEditions..., pages-requêtes
            'et pages SP_ sans section) regroupées sous un dossier virtuel (Name = ""
            '-> jamais enregistré dans Controle_Droit)
            Dim rw() As DataRow = pTable.Select("[Menu_Parent]='' and (Typ_Ecran='ECR' or (Typ_Ecran='QRY' and estPortail='true') or Typ_Ecran='SPP')", "Rang Asc")
            If rw.Length > 0 Then
                Dim N As New Node
                With N
                    .Name = ""
                    .Text = "Pages racines"
                    .Cells.Add(New Cell)
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = False
                    .Cells(2).CheckBoxVisible = False
                    .Tag = {"FDR", Nothing, Nothing}
                    .Style = ElementStyle3
                End With
                For j = 0 To rw.GetUpperBound(0)
                    Dim M As New Node
                    With M
                        .Name = rw(j)("Name_Ecran")
                        .Text = rw(j)("Text_Ecran") & SuffixePortail(rw(j)("Typ_Ecran"), rw(j)("AccesPerso"))
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        'Pages SP_ : cf. bloc des sections (Visible = Consulter, pas de
                        'case Actif ; aucune case si accès ouvert à tous les profils ;
                        'menu contextuel pour les autres habilitations).
                        .Cells(1).CheckBoxVisible = (rw(j)("Typ_Ecran") <> "SPP" OrElse rw(j)("AccesPerso") <> "false")
                        .Cells(2).CheckBoxVisible = (rw(j)("Typ_Ecran") <> "SPP")
                        .Cells(1).Checked = CBool(rw(j)("Visible"))
                        .Cells(2).Checked = CBool(rw(j)("Actif"))
                        .Tag = {rw(j)("Typ_Ecran"), rw(j)("AccesPerso"), Nothing}
                        If rw(j)("Typ_Ecran") = "SPP" Then .ContextMenu = CntDroitsSP
                    End With
                    VerrouillerAccueil(M)
                    N.Nodes.Add(M)
                Next
                AdvPortail.Nodes.Add(N)
            End If
            'Widgets du tableau de bord (Param_Query_Widget.estWidget, hors pages-requêtes
            'déjà affichées ci-dessus) : dossier virtuel (Name = "" -> jamais enregistré) ;
            'chaque widget est enregistré sous son Cod_Query, sans préfixe PRT_ (le backend
            'portail contrôle le droit Actif sur Name_Ecran = Cod_Query). Les cases du
            'dossier cochent/décochent tous ses widgets d'un coup, comme les sections.
            Dim wg() As DataRow = pTable.Select("Typ_Ecran='QRY' and estPortail<>'true'", "Text_Ecran Asc")
            If wg.Length > 0 Then
                Dim N As New Node
                With N
                    .Name = ""
                    .Text = "Widgets du tableau de bord"
                    .Cells.Add(New Cell)
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = True
                    .Cells(2).CheckBoxVisible = True
                    .Tag = {"FDR", Nothing, Nothing}
                    .Style = ElementStyle3
                End With
                For j = 0 To wg.GetUpperBound(0)
                    Dim M As New Node
                    With M
                        .Name = wg(j)("Name_Ecran")
                        .Text = wg(j)("Text_Ecran") & " (Widget)"
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(1).CheckBoxVisible = True
                        .Cells(2).CheckBoxVisible = True
                        .Cells(1).Checked = CBool(wg(j)("Visible"))
                        .Cells(2).Checked = CBool(wg(j)("Actif"))
                        .Tag = {wg(j)("Typ_Ecran"), Nothing, Nothing}
                    End With
                    N.Nodes.Add(M)
                Next
                'Etat initial des cases du dossier : coché si tous ses widgets le sont
                '(pure présentation — le dossier virtuel n'est jamais enregistré).
                N.Cells(1).Checked = IsChecked(N, 1)
                N.Cells(2).Checked = IsChecked(N, 2)
                AdvPortail.Nodes.Add(N)
            End If
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    'Suffixe d'affichage des nœuds de l'onglet Portail, selon la nature de l'entrée :
    '"(Requête)" pour une page-requête, "(Designer)" pour une page SP_ du Designer —
    'avec la mention "ouverte à tous" quand l'accès n'est pas personnalisé par profil
    '(Acces_Personnalise = 'false' : consultation ouverte, sans case à cocher).
    Function SuffixePortail(TypEcran As String, AccesPerso As String) As String
        Select Case TypEcran
            Case "QRY" : Return " (Requête)"
            Case "SPP" : Return If(AccesPerso = "false", " (Designer — ouverte à tous)", " (Designer)")
            Case Else : Return ""
        End Select
    End Function

    'Page d'accueil du portail (route par défaut /myspace -> Dashboard) :
    'toujours accessible, quel que soit le profil — cases verrouillées cochées,
    'sinon le portail serait inaccessible pour les agents du profil (aucune
    'page d'atterrissage). Sécurisé aussi côté backend (PAGE_ACCUEIL_PORTAIL).
    Sub VerrouillerAccueil(M As Node)
        If IsNull(M.Name, "") <> "Dashboard" Then Return
        M.Cells(1).Checked = True
        M.Cells(2).Checked = True
        M.Cells(1).CheckBoxVisible = False
        M.Cells(2).CheckBoxVisible = False
    End Sub

    Private Sub AdvPortail_NodeClick(sender As Object, e As TreeNodeMouseEventArgs) Handles AdvPortail.NodeClick
        If e.Node.SelectedCell Is Nothing Then Return
        'Propagation à la descendance uniquement depuis une case à cocher visible :
        'la colonne de texte, les cases verrouillées (page d'accueil) et les
        'dossiers virtuels sans cases (ex. "Pages racines") ne déclenchent rien ;
        'les sections et le dossier "Widgets du tableau de bord" cochent/décochent
        'tous leurs fils d'un coup.
        Dim Indx As Integer = e.Node.Cells.IndexOf(e.Node.SelectedCell)
        If Indx < 1 OrElse Indx > 2 Then Return
        If Not e.Node.Cells(Indx).CheckBoxVisible Then Return
        Checking(e.Node, Indx, e.Node.SelectedCell.Checked)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Cod_Profile_Text.Text = "" Then Exit Sub
        Appel_Zoom1("MS061", Cod_Profile_Target_Text, Me)
    End Sub

    Private Sub Cod_Profile_Target_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Profile_Target_Text.TextChanged
        Lib_Profile_Target_Text.Text = FindLibelle("Lib_Profile", "Cod_Profile", Cod_Profile_Target_Text.Text, "Controle_Profile")
    End Sub

    Sub RequestAccess()
        Try
            NbNodes = 1
            Dim CodSql As String = ""
            CodSql = "select isnull(Parent,'') as Parent,f.Name_Ecran,isnull(Text_Ecran,'') as Text_Ecran,isnull(Typ_Ecran,'') as Typ_Ecran,isnull(Image1,'') as Image1,isnull(o.Visible,'False') as Visible,isnull(o.Actif,'False') as Actif ,isnull(Rang,'0') as Rang ,0 as RowId
                       From Controle_Treeview f  
                       outer apply(select Image1 from Controle_Menu where Name_Ecran=f.Name_Ecran) m  
                       outer apply (select * from Controle_Droit where Name_Ecran=f.Name_Ecran  and Cod_Profile='" & Cod_Profile_Text.Text & "') o 
                       where (isnull(Parent,'')<>'' or  Typ_Ecran='MNU' or (isnull(Parent,'')='' and  Typ_Ecran='ECR'))
                       order by Rang"
            oTable = DATA_READER_GRD(CodSql)
            With oTable
                .Columns("RowId").ReadOnly = False
            End With
            Dim nRows() As DataRow
            nRows = oTable.Select("[Typ_Ecran]='MNU'", "Rang Asc")
            Adv.Nodes.Clear()
            For i = 0 To nRows.Length - 1
                Dim N As New Node
                With N
                    .Name = nRows(i)("Name_Ecran")
                    .Text = nRows(i)("Text_Ecran")
                    .Cells.Add(New Cell)
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = True
                    .Cells(2).CheckBoxVisible = True
                    .Cells(1).Checked = CBool(nRows(i)("Visible"))
                    .Cells(2).Checked = CBool(nRows(i)("Actif"))
                    .ImageIndex = MenuImageArray.IndexOf(nRows(i)("Image1"))
                    .Tag = {nRows(i)("Typ_Ecran"), Nothing, Nothing}
                    .Style = ElementStyle2
                    nRows(i)("RowId") = NbNodes
                End With
                Adv.Nodes.Add(N)
                NbNodes += 1
                Dim mRows() As DataRow
                mRows = oTable.Select("[Parent]='" & N.Name & "'", "Rang Asc")
                For j = 0 To mRows.GetUpperBound(0)
                    Dim M As New Node
                    With M
                        .Name = mRows(j)("Name_Ecran")
                        .Text = mRows(j)("Text_Ecran")
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(1).CheckBoxVisible = True
                        .Cells(2).CheckBoxVisible = True
                        .Cells(1).Checked = CBool(mRows(j)("Visible"))
                        .Cells(2).Checked = CBool(mRows(j)("Actif"))
                        .ImageIndex = MenuImageArray.IndexOf(mRows(j)("Image1"))
                        .Tag = {mRows(j)("Typ_Ecran"), Nothing, Nothing}
                        If mRows(j)("Typ_Ecran") = "FDR" Then .Style = ElementStyle3
                        If mRows(j)("Typ_Ecran") = "ECR" Then
                            .ContextMenu = CntScripts
                        End If
                        mRows(j)("RowId") = NbNodes
                    End With
                    N.Nodes.Add(M)
                    NbNodes += 1
                    Dim oRows() As DataRow
                    oRows = oTable.Select("[Parent]='" & M.Name & "'")
                    For k = 0 To oRows.Length - 1
                        Dim O As New Node
                        With O
                            .Name = oRows(k)("Name_Ecran")
                            .Text = oRows(k)("Text_Ecran")
                            .Cells.Add(New Cell)
                            .Cells.Add(New Cell)
                            .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                            .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                            .Cells(1).CheckBoxVisible = True
                            .Cells(2).CheckBoxVisible = True
                            .Cells(1).Checked = CBool(oRows(k)("Visible"))
                            .Cells(2).Checked = CBool(oRows(k)("Actif"))
                            .ImageIndex = MenuImageArray.IndexOf(oRows(k)("Image1"))
                            .Tag = {oRows(k)("Typ_Ecran"), Nothing, Nothing}
                            oRows(k)("RowId") = NbNodes
                            If oRows(k)("Typ_Ecran") = "ECR" Then
                                .ContextMenu = CntScripts
                            End If
                        End With
                        M.Nodes.Add(O)
                        NbNodes += 1
                        Dim pRows() As DataRow
                        pRows = oTable.Select("[Parent]='" & O.Name & "'")
                        For h = 0 To pRows.Length - 1
                            Dim P As New Node
                            With P
                                .Name = pRows(h)("Name_Ecran")
                                .Text = pRows(h)("Text_Ecran")
                                .Cells.Add(New Cell)
                                .Cells.Add(New Cell)
                                .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                                .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                                .Cells(1).CheckBoxVisible = True
                                .Cells(2).CheckBoxVisible = True
                                .Cells(1).Checked = CBool(pRows(h)("Visible"))
                                .Cells(2).Checked = CBool(pRows(h)("Actif"))
                                .ImageIndex = MenuImageArray.IndexOf(pRows(h)("Image1"))
                                .Tag = {pRows(h)("Typ_Ecran"), Nothing, Nothing}
                                If pRows(h)("Typ_Ecran") = "ECR" Then
                                    .ContextMenu = CntScripts
                                End If
                                pRows(h)("RowId") = NbNodes
                            End With
                            O.Nodes.Add(P)
                            NbNodes += 1
                        Next
                    Next
                Next
            Next
            Dim rw() As DataRow
            rw = oTable.Select("[Parent]='' and Typ_Ecran='ECR'", "Rang Asc")
            If rw.Length > 0 Then
                Dim N As New Node
                With N
                    .Text = "Dossier générique"
                    .Cells.Add(New Cell)
                    .Cells.Add(New Cell)
                    .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                    .Cells(1).CheckBoxVisible = True
                    .Cells(2).CheckBoxVisible = True
                    .Cells(1).Checked = False
                    .Cells(2).Checked = False
                    .ImageIndex = MenuImageArray.IndexOf("FDR")
                    .Tag = {"FDR", Nothing, Nothing}
                    .Style = ElementStyle3
                End With
                For j = 0 To rw.GetUpperBound(0)
                    Dim M As New Node
                    With M
                        .Name = rw(j)("Name_Ecran")
                        .Text = rw(j)("Text_Ecran")
                        .Cells.Add(New Cell)
                        .Cells.Add(New Cell)
                        .Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                        .Cells(1).CheckBoxVisible = True
                        .Cells(2).CheckBoxVisible = True
                        .Cells(1).Checked = CBool(rw(j)("Visible"))
                        .Cells(2).Checked = CBool(rw(j)("Actif"))
                        .ImageIndex = MenuImageArray.IndexOf(rw(j)("Image1"))
                        .Tag = {rw(j)("Typ_Ecran"), Nothing, Nothing}
                        .ContextMenu = CntScripts
                        rw(j)("RowId") = NbNodes
                    End With
                    N.Nodes.Add(M)
                Next
                Adv.Nodes.Add(N)
            End If

            RequestFunctions()
            With Tbl_Grd
                .Rows.Clear()
                Dim TblGrd As DataTable = DATA_READER_GRD("select * from Controle_Profile_Regles where Cod_Profile='" & Cod_Profile_Text.Text & "' order by Table_Ref")
                With TblGrd
                    For i = 0 To .Rows.Count - 1
                        Tbl_Grd.Rows.Add(IsNull(.Rows(i)("Table_Ref"), ""), IsNull(.Rows(i)("Regle"), ""))
                    Next
                End With
            End With
            TabControl1.SelectedIndex = 0
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try

    End Sub

    Sub RequestFunctions()
        LeProfil.Nodes.Clear()
        Dim CodSql As String = " select Function_Sec,isnull(Description,'') as Lib_Function ,isnull(Visible,'false') Visible,isnull(Actif,'false')Actif, d.RowId 
                                 from Controle_Menu_Functions f 
                                 outer apply (Select Visible,Actif,RowId from Controle_Droit_Functions 
                                 where f.Function_Sec=Function_Sec And Cod_Profile='" & Cod_Profile_Text.Text & "') d 
                                 where isnull(Function_Sec,'')<>'' order by isnull(Description,'')"
        Dim fTbl As DataTable = DATA_READER_GRD(CodSql)
        With fTbl
            For i = 0 To .Rows.Count - 1
                Dim wnd As New Node
                wnd.Name = .Rows(i).Item("Function_Sec")
                wnd.Text = .Rows(i).Item("Lib_Function")
                wnd.Cells.Add(New Cell)
                wnd.Cells.Add(New Cell)
                wnd.Cells(1).CheckBoxStyle = eCheckBoxStyle.CheckBox
                wnd.Cells(2).CheckBoxStyle = eCheckBoxStyle.CheckBox
                wnd.Cells(1).CheckBoxVisible = True
                wnd.Cells(2).CheckBoxVisible = True
                wnd.Cells(1).Checked = .Rows(i).Item("Visible")
                wnd.Cells(2).Checked = .Rows(i).Item("Actif")
                wnd.Image = My.Resources.btn_check_on
                LeProfil.Nodes.Add(wnd)
            Next
        End With

    End Sub

    Private Sub Adv_NodeClick(sender As Object, e As TreeNodeMouseEventArgs) Handles Adv.NodeClick
        If e.Node.SelectedCell Is Nothing Then Return
        Checking(e.Node, e.Node.Cells.IndexOf(e.Node.SelectedCell), e.Node.SelectedCell.Checked)

    End Sub
    Sub Checking(oNd As Node, Indx As Integer, obool As Boolean)
        For Each a As Node In oNd.Nodes
            a.Cells(Indx).Checked = obool
            If a.Nodes.Count > 0 Then
                Checking(a, Indx, obool)
            End If
        Next
    End Sub
    Function IsChecked(oNd As Node, Indx As Integer) As Boolean
        Dim nb As Integer = 0
        For i = 0 To oNd.Nodes.Count - 1
            If oNd.Nodes(i).Cells(Indx).Checked Then
                nb += 1
            End If
        Next
        Return (nb = oNd.Nodes.Count)
    End Function

    Private Sub Admin_Users_Menus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Next_D = dictButtons("Next_D")
        Back_D = dictButtons("Back_D")
        Last_D = dictButtons("Last_D")
        First_D = dictButtons("First_D")
        New_D = dictButtons("New_D")
        Duplik_D = dictButtons("Duplik_D")
        With Adv
            .ImageList = MenuImage
            .Styles.Add(ElementStyle2)
            .Styles.Add(ElementStyle3)
        End With

        With ElementStyle2
            .BackColor = System.Drawing.Color.White
            .BackColor2 = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
            .BackColorGradientAngle = 90
            .BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderBottomWidth = 1
            .BorderColor = System.Drawing.Color.DarkGray
            .BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderLeftWidth = 1
            .BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderRightWidth = 1
            .BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderTopWidth = 1
            .Class = ""
            .CornerDiameter = 4
            .CornerType = DevComponents.DotNetBar.eCornerType.Square
            .Description = "Gray"
            .Name = "ElementStyle2"
            .PaddingBottom = 1
            .PaddingLeft = 1
            .PaddingRight = 1
            .PaddingTop = 1
            .TextColor = System.Drawing.Color.Black
        End With
        With ElementStyle3
            .BackColor = System.Drawing.Color.White
            .BackColor2 = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(230, Byte), Integer))
            .BackColorGradientAngle = 90
            .BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderBottomWidth = 1
            .BorderColor = System.Drawing.Color.DarkGray
            .BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderLeftWidth = 1
            .BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderRightWidth = 1
            .BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            .BorderTopWidth = 1
            .Class = ""
            .CornerDiameter = 3
            .CornerType = DevComponents.DotNetBar.eCornerType.Square
            .Description = "Gray"
            .Name = "ElementStyle3"
            .PaddingBottom = 1
            .PaddingLeft = 1
            .PaddingRight = 1
            .PaddingTop = 1
            .TextColor = System.Drawing.Color.Black
        End With
        With OuvrirParNiveau_ud
            .Items.AddRange({"Que les Menus", "Que les Dossiers", "Tout"})
        End With
    End Sub
    Sub Saving()
        Try
            If Cod_Profile_Text.Text = "1" Then
                MessageBoxRHP(350)
                Exit Sub
            End If
            Dim rs, rs1 As New ADODB.Recordset
            If RTrim(LTrim(Lib_Profile_Text.Text)) = "" Then
                MessageBoxRHP(351)
                Exit Sub
            End If
            rs.Open("Select *  from Controle_Profile where Cod_Profile='" & Cod_Profile_Text.Text & "'", cn, 2, 2)
            If rs.EOF Then
                'Cas d'un nouvel Création
                rs.AddNew()
                rs("Created_By").Value = theUser.Login
                rs("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
            Else
                'Cas de MAJ
                rs.Update()
            End If
            rs("Lib_Profile").Value = Lib_Profile_Text.Text
            rs("Actif").Value = Actif_Check.Checked
            rs("Portail_Defaut").Value = If(Portail_Defaut_Check.Checked, "true", "false")
            rs("Modified_By").Value = theUser.Login
            rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
            rs.Update()
            rs.Close()
            Dim CodProfil As Integer = 0
            If Cod_Profile_Text.Text = "" Then
                CodProfil = CnExecuting("select max(Cod_Profile)from Controle_Profile").Fields(0).Value
            Else
                CodProfil = Cod_Profile_Text.Text
            End If
            'Un seul profil portail par défaut (index filtré unique en base)
            If Portail_Defaut_Check.Checked Then
                CnExecuting("update Controle_Profile set Portail_Defaut='false' where Cod_Profile<>'" & CodProfil & "' and Portail_Defaut='true'")
            End If
            CnExecuting("Delete from Controle_Profile_Regles WHERE    Cod_Profile='" & CodProfil & "'")
            With Tbl_Grd
                rs1.Open(" select * from Controle_Profile_Regles", cn, 2, 2)
                For j = 0 To .RowCount - 1
                    If IsNull(.Item(Table_Ref.Index, j).Value, "") <> "" Then
                        rs1.AddNew()
                        rs1("Cod_Profile").Value = CodProfil
                        rs1("Table_Ref").Value = .Item(Table_Ref.Index, j).Value
                        rs1("Regle").Value = .Item(Regle.Index, j).Value
                        rs1.Update()
                    End If
                Next
                rs1.Close()
            End With
            'Ne supprimer que les droits gérés par cet écran : écrans de
            'l'arborescence desktop (Controle_Treeview), pages et sections du
            'portail (PRT_) et requêtes exposées au portail (Cod_Query de
            'Param_Query_Widget). Les lignes Controle_Droit des autres requêtes
            '(onglet Sécurité de Param_Query) ne doivent pas être perdues à
            'l'enregistrement d'un profil.
            CnExecuting("Delete from Controle_Droit where Cod_Profile='" & CodProfil & "'" &
                        " and (isnull(Name_Ecran,'')=''" &
                        " or Name_Ecran in (select Name_Ecran from Controle_Treeview)" &
                        " or Name_Ecran like 'PRT\_%' escape '\'" &
                        " or Name_Ecran in (select Cod_Query from Param_Query_Widget where isnull(estWidget,'false')='true' or isnull(estPortail,'false')='true'))")
            For Each c As Node In Adv.Nodes
                SavingNodes(c, CodProfil)
            Next
            'Droits du portail (onglet Portail : pages standards, sections créées
            'en base, pages-requêtes et widgets) : réinsérés après le delete, au
            'même titre que les écrans desktop.
            For Each c As Node In AdvPortail.Nodes
                SavingPortailNodes(c, CodProfil)
            Next
            CnExecuting("Delete from Controle_Droit_Functions where Cod_Profile='" & CodProfil & "'")
            For Each c As Node In AdvFonction.Nodes(0).Nodes
                SavingFunctions(c, CodProfil)
            Next
            MessageBoxRHP(352)
            Cod_Profile_Text.Text = CodProfil
            Request()
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    Sub SavingNodes(ByVal oNode As Node, CodProfil As String)
        'Les dossiers virtuels sans Name (ex. "Dossier générique") ne génèrent
        'aucune ligne Controle_Droit.
        If IsNull(oNode.Name, "") <> "" Then
            Dim rs As New ADODB.Recordset
            rs.Open("Select * from Controle_Droit", cn, 2, 2)
            rs.AddNew()
            rs("Name_Ecran").Value = oNode.Name
            rs("Cod_Profile").Value = Cod_Profile_Text.Text
            rs("Visible").Value = oNode.Cells(1).Checked
            rs("Actif").Value = oNode.Cells(2).Checked
            rs.Update()
            rs.Close()
            If oNode.Tag(0) = "ECR" Then
                If Not oNode.Tag(1) Is Nothing Then
                    Dim oTbl As DataTable = oNode.Tag(1)
                    With oTbl
                        For i = 0 To .Rows.Count - 1
                            rs.Open("Select * from Controle_Droit_Avance where Cod_Profile='" & CodProfil & "' and Name_Ecran='" & oNode.Name & "' and Name_Controle='" & .Rows(i).Item("Name_Controle") & "'", cn, 2, 2)
                            If rs.EOF Then
                                rs.AddNew()
                                rs("Name_Ecran").Value = oNode.Name
                                rs("Cod_Profile").Value = Cod_Profile_Text.Text
                                rs("Name_Controle").Value = .Rows(i).Item("Name_Controle")
                            Else
                                rs.Update()
                            End If
                            rs("Visible").Value = .Rows(i).Item("Visible")
                            rs("Actif").Value = .Rows(i).Item("Actif")
                            rs.Update()
                            rs.Close()
                        Next
                    End With
                End If
            End If
        End If

        If oNode.Nodes.Count > 0 Then
            For Each c As Node In oNode.Nodes
                SavingNodes(c, CodProfil)
            Next
        End If
    End Sub
    Sub SavingPortailNodes(ByVal oNode As Node, CodProfil As String)
        'Les dossiers virtuels (Name = "") ne génèrent aucune ligne de droit.
        'Pages standards et sections : Controle_Droit, Name_Ecran = 'PRT_' + nom
        '(droits portail isolés des écrans desktop de mêmes noms). Exception : les
        'requêtes (Typ QRY — pages-requêtes et widgets du portail) sont enregistrées
        'sous leur Cod_Query, SANS préfixe (le backend contrôle Actif sur
        'Name_Ecran = Cod_Query).
        'Pages SP_ du Designer (Typ SPP) : Consulter (case VISIBLE de l'arbre — pour
        'ces pages, affichage au menu et accès ne font qu'un) et, si elles ont été
        'éditées via le menu contextuel (Zoom_Profile_Droits_SP, Tag(2)), les autres
        'habilitations (Créer/Modifier/Supprimer/Valider/Imprimer/GED) —
        'enregistrées dans Controle_Designer_Droit, en préservant les colonnes non
        'portées ici (matrice complète aussi gérée dans SP_Page_Designer : va et
        'vient entre les deux écrans). Les pages en accès ouvert
        '(Acces_Personnalise='false', Tag(1) — sans case dans l'arbre) ne sont
        'enregistrées que si leurs habilitations ont été éditées (Consulter est
        'sans effet pour elles : consultation ouverte à tous les profils).
        If IsNull(oNode.Name, "") <> "" Then
            If IsNull(oNode.Tag(0), "") = "SPP" Then
                Dim oDroits As DataTable = Nothing
                If Not oNode.Tag(2) Is Nothing Then oDroits = oNode.Tag(2)
                If IsNull(oNode.Tag(1), "") <> "false" OrElse Not oDroits Is Nothing Then
                    Dim rs As New ADODB.Recordset
                    rs.Open("select * from Controle_Designer_Droit where Cod_Page='" & oNode.Name & "' and Cod_Profile='" & CodProfil & "'", cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Cod_Page").Value = oNode.Name
                        rs("Cod_Profile").Value = CodProfil
                        rs("Created_By").Value = theUser.Login
                        rs("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
                    Else
                        rs.Update()
                    End If
                    rs("Consulter").Value = If(oNode.Cells(1).Checked, "true", "false")
                    If Not oDroits Is Nothing Then
                        rs("Creer").Value = oDroits.Rows(0)("Creer").ToString()
                        rs("Modifier").Value = oDroits.Rows(0)("Modifier").ToString()
                        rs("Supprimer").Value = oDroits.Rows(0)("Supprimer").ToString()
                        rs("Valider").Value = oDroits.Rows(0)("Valider").ToString()
                        rs("Imprimer").Value = oDroits.Rows(0)("Imprimer").ToString()
                        rs("GED").Value = oDroits.Rows(0)("GED").ToString()
                    End If
                    rs("Modified_By").Value = theUser.Login
                    rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
                    rs.Update()
                    rs.Close()
                End If
            Else
                Dim rs As New ADODB.Recordset
                rs.Open("Select * from Controle_Droit", cn, 2, 2)
                rs.AddNew()
                rs("Name_Ecran").Value = If(IsNull(oNode.Tag(0), "") = "QRY", "", "PRT_") & oNode.Name
                rs("Cod_Profile").Value = CodProfil
                'Une section contenant au moins un élément accessible à tout le monde
                '(page SP_ en accès ouvert) reste toujours visible : Visible forcé à
                'True quelle que soit la case (règle aussi appliquée par sp_menu_portail).
                Dim forceVisible As Boolean = False
                If IsNull(oNode.Tag(0), "") = "MNU" Then
                    For Each child As Node In oNode.Nodes
                        If IsNull(child.Tag(0), "") = "SPP" AndAlso IsNull(child.Tag(1), "") = "false" Then
                            forceVisible = True
                            Exit For
                        End If
                    Next
                End If
                rs("Visible").Value = If(forceVisible, True, oNode.Cells(1).Checked)
                rs("Actif").Value = oNode.Cells(2).Checked
                rs.Update()
                rs.Close()
            End If
        End If
        If oNode.Nodes.Count > 0 Then
            For Each c As Node In oNode.Nodes
                SavingPortailNodes(c, CodProfil)
            Next
        End If
    End Sub
    Sub SavingFunctions(ByVal oNode As Node, CodProfil As String)
        Dim rs As New ADODB.Recordset
        rs.Open("Select * from Controle_Droit_Functions", cn, 2, 2)
        rs.AddNew()
        rs("Cod_Profile").Value = Cod_Profile_Text.Text
        rs("Function_Sec").Value = oNode.Name
        rs("Visible").Value = oNode.Cells(1).Checked
        rs("Actif").Value = oNode.Cells(2).Checked
        rs.Update()
        rs.Close()

    End Sub
    'Menu contextuel des pages SP_ (Designer) de l'onglet Portail : habilitations
    'complètes de la page pour le profil courant (Zoom_Profile_Droits_SP —
    'Consulter, Créer, Modifier, Supprimer, Valider, Imprimer, GED). Les valeurs
    'sont conservées dans le Tag du nœud (Tag(2)) et persistées avec le profil.
    Private Sub DroitsSP_Click(sender As Object, e As EventArgs) Handles DroitsSP.Click
        Dim oNd As Node = AdvPortail.SelectedNode
        If oNd Is Nothing Then Return
        If IsNull(oNd.Name, "") = "" OrElse IsNull(oNd.Tag(0), "") <> "SPP" Then Return
        Dim f As New Zoom_Profile_Droits_SP
        With f
            .oNod = oNd
            .CodProfile = Cod_Profile_Text.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub Scripts_Click(sender As Object, e As EventArgs) Handles Scripts.Click
        Dim oNd As Node = Adv.SelectedNode
        Dim f As New Zoom_Profile_Scripts
        With f
            .oNod = oNd
            .CodProfile = Cod_Profile_Text.Text
            .Adv.Nodes(0).Name = .CodProfile
            .Adv.Nodes(0).Text = Lib_Profile_Text.Text
            .Adv.Nodes(0).Nodes(0).Name = oNd.Name
            .Adv.Nodes(0).Nodes(0).Text = oNd.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
    End Sub
#Region "Recherche"
    Dim rRow As DataRow()
    Dim rRang As Integer = -1
    Dim NbRsl As Integer = 0
    Dim cRsl As Integer = 0
    Private Sub OuvrirParNiveau_ud_DropDowClosed(sender As Object, e As EventArgs) Handles OuvrirParNiveau_ud.DropDownClosed
        Select Case OuvrirParNiveau_ud.SelectedIndex
            Case 0
                For i = Adv.Nodes.Count - 1 To 0 Step -1
                    Adv.Nodes(i).Collapse()
                Next
            Case 1
                Adv.ExpandAll()
                For i = 0 To Adv.Nodes.Count - 1
                    For j = 0 To Adv.Nodes(i).Nodes.Count - 1
                        Adv.Nodes(i).Nodes(j).Collapse()
                    Next
                Next
            Case 2
                Adv.ExpandAll()
        End Select
    End Sub
    Private Sub Recherche_txt_ud_TextChanged(sender As Object, e As EventArgs) Handles Recherche_txt_ud.TextChanged
        rRang = -1
        NbRsl = 0
        cRsl = 0
        Rsl_Recherche.Text = ""
        Rsl_Recherche.Refresh()
    End Sub
    Sub Rechercher()
        If Recherche_txt_ud.Text = "" Then Return
        rRow = oTable.Select("(Name_Ecran like '%" & Recherche_txt_ud.Text & "%' or Text_Ecran like '%" & Recherche_txt_ud.Text & "%') and Rowid>" & rRang, "Rowid Asc")
        If rRow.Length = 0 Then
            ShowMessageBox("Aucun élément ne correspond à votre sélection")
            Return
        End If
        Adv.Select()
        If NbRsl = 0 Then
            NbRsl = rRow.Length
        End If
        For i = 0 To rRow.Length - 1
            If Adv.Nodes.Find(rRow(i).Item("Name_Ecran"), True).Length > 0 Then
                With Adv
                    .SelectedNode = Adv.FindNodeByName(rRow(i).Item("Name_Ecran"))
                End With
                rRang = rRow(i).Item("RowId")
                cRsl += 1
                Rsl_Recherche.Text = cRsl & "/" & NbRsl
                Rsl_Recherche.Refresh()
                Exit Sub
            End If
        Next
    End Sub
    Private Sub Recherche_txt_ud_KeyUp(sender As Object, e As KeyEventArgs) Handles Recherche_txt_ud.KeyUp
        If e.KeyCode = Keys.Enter Then
            Rechercher()
        End If
    End Sub
#End Region
#Region "Duplication"
    Sub Dupliquer()
        If Cod_Profile_Text.Text = "" Then Exit Sub
        If Cod_Profile_Target_Text.Text = "" Then
            ShowMessageBox("Sélectionner un profile cible", "Duplication", MessageBoxButtons.OK, msgIcon.Stop)
            Appel_Zoom1("MS061", Cod_Profile_Target_Text, Me)
            Return
        End If
        Dim a As String = Cod_Profile_Target_Text.Text
        If CnExecuting("Select count(*) from Controle_Profile where Cod_Profile='" & a & "'").Fields(0).Value > 0 Then
            Dim nom As String = CnExecuting("Select Lib_Profile from Controle_Profile where Cod_Profile='" & a & "'").Fields(0).Value
            If MessageBoxRHP(4, nom) = MsgBoxResult.Cancel Then Exit Sub
            CnExecuting("delete from Controle_Droit where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from Controle_Droit_Avance where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            If a = "1" Then
                CnExecuting("insert into Controle_Droit (Name_Ecran,Cod_Profile,Visible,Actif,Consult,Modify,Delet) " &
                          " select Name_Ecran,'" & Cod_Profile_Text.Text & "','True','True','True','True','True'  from Controle_Menu")
                CnExecuting("insert into Controle_Droit_Avance (Name_Ecran,Cod_Profile,Name_Controle,Visible,Actif) " &
                          " select Name_Ecran,'" & Cod_Profile_Text.Text & "',Name_Controle,'True','True' from Controle_Menu_Avance")
            Else
                CnExecuting("insert into Controle_Droit (Name_Ecran,Cod_Profile,Visible,Actif,Consult,Modify,Delet) " &
                          " select Name_Ecran,'" & Cod_Profile_Text.Text & "',Visible,Actif,Consult,Modify,Delet  from Controle_Droit where Cod_Profile='" & a & "'")
                CnExecuting("insert into Controle_Droit_Avance (Name_Ecran,Cod_Profile,Name_Controle,Visible,Actif) " &
                          " select Name_Ecran,'" & Cod_Profile_Text.Text & "',Name_Controle,Visible,Actif from Controle_Droit_Avance where Cod_Profile='" & a & "'")
            End If
        Else
            MessageBoxRHP(353)
        End If
        Request()
    End Sub
#End Region
#Region "Diviseurs d'enregistrement"
    Sub Div_First()
        Try
            Reset()
            If Cod_Profile_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Profile_Text.Text & "'")
                End If


                Diviseur_First("Controle_Profile", "Cod_Profile", "Lib_Profile", Cod_Profile_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Div_Back()
        Try
            Reset()
            If Cod_Profile_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Profile_Text.Text & "'")
                End If


                Diviseur_Back("Controle_Profile", "Cod_Profile", "Lib_Profile", Cod_Profile_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub Div_Next()
        Try
            If Cod_Profile_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Profile_Text.Text & "'")
                End If


                Diviseur_Next("Controle_Profile", "Cod_Profile", "Lib_Profile", Cod_Profile_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Deleting()
        Try
            If Cod_Profile_Text.Text = "" Then
                ShowMessageBox("Aucun profile à supprimer", "Suppression de profile", MessageBoxButtons.OK, msgIcon.Information)
                Return
            End If
            If CnExecuting("Select count(*) from Controle_Users where Cod_Profile='" & Cod_Profile_Text.Text & "'").Fields(0).Value > 0 Then
                ShowMessageBox("Ce profile est utilisé dans la table des utilisateurs", "Suppression de profile", MessageBoxButtons.OK, msgIcon.Information)
                Return
            End If
            If CnExecuting("Select count(*) from RH_Agent where Cod_Profile='" & Cod_Profile_Text.Text & "'").Fields(0).Value > 0 Then
                ShowMessageBox("Ce profile est affecté à des agents (profil portail)", "Suppression de profile", MessageBoxButtons.OK, msgIcon.Information)
                Return
            End If
            If ShowMessageBox("Etes-vous sûr de vouloir supprimer ce profile?", "Suppression de profile", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then
                Return
            End If
            CnExecuting("delete from  Controle_Profile where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from  Controle_Profile_Regles where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from  Controle_Droit_Functions where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from  Controle_Droit where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("delete from  Controle_Droit_Avance where Cod_Profile='" & Cod_Profile_Text.Text & "'")
            CnExecuting("insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('Controle_Profile','Cod_Profile','" & Cod_Profile_Text.Text & "','" & theUser.id_User & "',getdate())")
            ShowMessageBox("Profile supprimé")
            Reseting()
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    Sub Div_Last()
        Try
            Reset()
            If Cod_Profile_Text.Text <> "" Then

                If Save_D.Enabled = True Then
                    CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Profile_Text.Text & "'")
                End If

                Diviseur_Last("Controle_Profile", "Cod_Profile", "Lib_Profile", Cod_Profile_Text)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

#End Region
#Region "Reseting"
    Sub Reseting()
        Cod_Profile_Text.Text = ""
        Adv.Nodes.Clear()
        AdvPortail.Nodes.Clear()
        Portail_Defaut_Check.Checked = False
        TabControl1.SelectedIndex = 0
    End Sub
    Sub Nouveau()
        Reseting()
        Lib_Profile_Text.Select()
    End Sub
#End Region
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Enter
                Rechercher()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Search_pb_Click(sender As Object, e As EventArgs) Handles Search_pb.Click
        Rechercher()
    End Sub

    Private Sub Admin_Profile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
    End Sub
End Class