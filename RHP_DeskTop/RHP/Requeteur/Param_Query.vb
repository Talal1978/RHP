Imports System.Text.RegularExpressions

Public Class Param_Query
    Friend Code As String = ""
    Dim Largeur_Fixe As String = ""
    Dim First_D As ud_btn
    Dim Back_D As ud_btn
    Dim Next_D As ud_btn
    Dim Last_D As ud_btn
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Dupliquer_D As ud_btn
    Dim Exec_D As ud_btn
    ' Les contrôles de l'onglet "Widget portail" (Param_Query_Widget) sont
    ' déclarés dans le designer (Param_Query.designer.vb, onglet TabWidget).
    Sub Chargement()
        If First_D Is Nothing Then
            First_D = dictButtons("First_D")
            Back_D = dictButtons("Back_D")
            Next_D = dictButtons("Next_D")
            Last_D = dictButtons("Last_D")
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Dupliquer_D = dictButtons("Dupliquer_D")
            Exec_D = dictButtons("Exec_D")
        End If
    End Sub
    Private Sub Admin_TreeView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Chargement()
        If Nature_Query.Items.Count = 0 Then Nature_Query.fromRubrique("Nature_Query")
        Combo_GRD(Typ_Param)
        Combo_GRD(Fonction_Critere)

        Dim menu_context_copy As New ContextMenuStrip
        Dim oMenu1 As New ToolStripMenuItem
        With oMenu1
            .Text = "Copier le Contenu de la liste"
            AddHandler .Click, AddressOf menu_context_grd
        End With
        Dim oMenu2 As New ToolStripMenuItem
        With oMenu2
            .Text = "Supprimer la Ligne"
            AddHandler .Click, AddressOf DelRow
        End With
        menu_context_copy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {oMenu1, oMenu2})
        With Criterias_GRD
            .ContextMenuStrip = menu_context_copy
        End With
        With Colonnes_GRD

        End With
        With Securite_Grd

        End With
        InitWidgetTab()
    End Sub

    ''' <summary>
    ''' Crée l'onglet "Widget portail" permettant de déclarer la requête comme
    ''' widget du tableau de bord (métadonnées stockées dans Param_Query_Widget).
    ''' La visibilité par profil reste gérée par les droits (Controle_Droit).
    ''' Paramètres de contexte alimentés automatiquement par le portail :
    ''' @idSoc, @Matricule, @CodEntite, @CodPoste, @Login, @idUser, @CodProfile,
    ''' @DatJour, @DebMois, @FinMois.
    ''' </summary>
    ''' <summary>
    ''' Initialise l'onglet "Widget portail" (contrôles déclarés dans le designer,
    ''' onglet TabWidget) : branche les gestionnaires d'événements et la pastille couleur.
    ''' </summary>
    Private Sub InitWidgetTab()
        WidgetCombosEnsure()
        ' Dockage de la zone d'aperçu imposé au runtime (robuste aux régénérations
        ' du fichier designer qui peuvent réinitialiser la taille des contrôles).
        Widget_Preview_Pnl.Dock = DockStyle.Bottom
        AddHandler Widget_Icone_Btn.Click, AddressOf Widget_Icone_Btn_Click
        AddHandler Widget_Preview_Btn.Click, AddressOf Widget_Preview_Btn_Click
        AddHandler Widget_Couleur_Btn.Click, AddressOf Widget_Couleur_Btn_Click
        AddHandler Widget_Couleur_Txt.TextChanged, AddressOf Widget_Couleur_Txt_TextChanged
        MajCouleurSwatch()
    End Sub

    ''' <summary>Peuple les combos au runtime : le designer Visual Studio ne sérialise
    ''' pas les collections Items des contrôles utilisateur (elles seraient perdues
    ''' à chaque régénération du fichier designer).</summary>
    Private Sub WidgetCombosEnsure()
        If Widget_Type_Cmb.Items.Count = 0 Then Widget_Type_Cmb.Items.AddRange(New Object() {"kpi", "chart", "table"})
        If Widget_ChartType_Cmb.Items.Count = 0 Then Widget_ChartType_Cmb.Items.AddRange(New Object() {"pie", "bar", "line", "area"})
        If Widget_Span_Cmb.Items.Count = 0 Then Widget_Span_Cmb.Items.AddRange(New Object() {"3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Widget_Type_Cmb.DropDownStyle = ComboBoxStyle.DropDownList
        Widget_ChartType_Cmb.DropDownStyle = ComboBoxStyle.DropDownList
        Widget_Span_Cmb.DropDownStyle = ComboBoxStyle.DropDownList
        ' Bloc "Page de consultation (menu du portail)" : section portail +
        ' texte d'aide (contenu long, posé au runtime comme le dockage de l'aperçu).
        If Portail_Menu_cmb.Items.Count = 0 Then Portail_Menu_cmb.fromRubrique("SP_Menu_Portail")
        Portail_Menu_cmb.DropDownStyle = ComboBoxStyle.DropDownList
        Portail_LblInfo.Text = "La requête devient une page du menu du portail (entrée directe, sans liste) : " &
                               "l'agent saisit les critères, clique 'Interroger' et le résultat s'affiche " &
                               "dans une grille en lecture seule ('Nouveau' vide les critères)." & vbCrLf &
                               "Visibilité par profil : droit 'Actif' de la requête pour le profil " &
                               "(écran des profils, comme les widgets du tableau de bord ; profil '1' voit tout)." & vbCrLf &
                               "Jamais saisis, alimentés automatiquement : @idSoc, @Matricule, @CodEntite, " &
                               "@CodPoste, @Login, @idUser, @CodProfile, @TeamLeader, @DatJour, @DebMois, " &
                               "@FinMois (ou Default_Value GV_*) ; les autres critères sont demandés." & vbCrLf &
                               "La requête doit rester en lecture seule (SELECT / WITH / EXEC dbo.Sys_* " &
                               "mono-instruction) : le portail la refuse sinon."
    End Sub

    Private Sub Widget_Couleur_Btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim dlg As New ColorDialog
        dlg.FullOpen = True
        Try
            dlg.Color = ColorTranslator.FromHtml(Widget_Couleur_Txt.Text)
        Catch ex As Exception
        End Try
        If dlg.ShowDialog() = DialogResult.OK Then
            Widget_Couleur_Txt.Text = String.Format("#{0:X2}{1:X2}{2:X2}", dlg.Color.R, dlg.Color.G, dlg.Color.B)
        End If
    End Sub

    Private Sub Widget_Couleur_Txt_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        MajCouleurSwatch()
    End Sub

    Private Sub MajCouleurSwatch()
        Try
            Widget_Couleur_Pnl.BackColor = ColorTranslator.FromHtml(Widget_Couleur_Txt.Text)
        Catch ex As Exception
            Widget_Couleur_Pnl.BackColor = Color.Transparent
        End Try
    End Sub

    Sub ChargerWidgetMeta()
        If Widget_Chk Is Nothing Then Exit Sub
        WidgetCombosEnsure()
        Widget_Chk.Checked = False
        Widget_Type_Cmb.SelectedIndex = 2
        Widget_ChartType_Cmb.SelectedIndex = 0
        Widget_Icone_Txt.Text = "TableChart"
        Widget_Couleur_Txt.Text = "#1976d2"
        Widget_Span_Cmb.SelectedItem = "6"
        Widget_Description_Txt.Text = ""
        ' Bloc "Page de consultation (menu du portail)" : réinitialisé puis relu
        ' (colonnes ajoutées par la migration 001_Param_Query_Page_Portail.sql —
        ' test d'existence pour rester compatible avec une base non migrée).
        Portail_Chk.Checked = False
        Portail_Menu_cmb.SelectedIndex = -1
        Portail_Rang_Txt.Value = 99
        MajCouleurSwatch()
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Param_Query_Widget where Cod_Query='" & Cod_Query_Text.Text & "'")
        If Tbl.Rows.Count = 0 Then Exit Sub
        With Tbl.Rows(0)
            Widget_Chk.Checked = IsNull(.Item("estWidget"), False)
            Dim t As String = IsNull(.Item("Widget_Type"), "table")
            If Widget_Type_Cmb.Items.Contains(t) Then Widget_Type_Cmb.SelectedItem = t
            Dim ct As String = IsNull(.Item("Widget_ChartType"), "pie")
            If Widget_ChartType_Cmb.Items.Contains(ct) Then Widget_ChartType_Cmb.SelectedItem = ct
            Widget_Icone_Txt.Text = IsNull(.Item("Icone"), "TableChart")
            Widget_Couleur_Txt.Text = IsNull(.Item("Couleur"), "#1976d2")
            Dim sp As String = CStr(IsNull(.Item("DefaultSpan"), 6))
            If Widget_Span_Cmb.Items.Contains(sp) Then Widget_Span_Cmb.SelectedItem = sp
            Widget_Description_Txt.Text = IsNull(.Item("Description"), "")
            If Tbl.Columns.Contains("estPortail") Then Portail_Chk.Checked = IsNull(.Item("estPortail"), False)
            If Tbl.Columns.Contains("Menu_Parent") Then Portail_Menu_cmb.SelectedValue = IsNull(.Item("Menu_Parent"), "")
            If Tbl.Columns.Contains("Rang") Then Portail_Rang_Txt.Value = CDec(Math.Max(Portail_Rang_Txt.Minimum, Math.Min(Portail_Rang_Txt.Maximum, CDec(Val(IsNull(.Item("Rang"), "99").ToString())))))
        End With
        MajCouleurSwatch()
    End Sub

    ''' <summary>Persiste l'exposition portail de la requête (Param_Query_Widget) :
    ''' la ligne existe dès qu'UNE exposition est demandée (widget du tableau de bord
    ''' ET/OU page de consultation du menu) ; elle n'est supprimée que si les deux
    ''' sont désactivées. Les colonnes estPortail/Menu_Parent/Rang proviennent de la
    ''' migration 001_Param_Query_Page_Portail.sql (absentes sur une base non migrée :
    ''' l'exposition page est alors simplement ignorée).</summary>
    Sub SauverWidgetMeta()
        If Widget_Chk Is Nothing Then Exit Sub
        Dim estPortail As Boolean = (Portail_Chk IsNot Nothing AndAlso Portail_Chk.Checked)
        If Not Widget_Chk.Checked AndAlso Not estPortail Then
            CnExecuting("delete from Param_Query_Widget where Cod_Query='" & Cod_Query_Text.Text & "'")
            Exit Sub
        End If
        Dim colonnesPage As Boolean =
            CInt(CnExecuting("select isnull(col_length('dbo.Param_Query_Widget','estPortail'),-1)").Fields(0).Value) >= 0
        Dim strType As String = IsNull(Widget_Type_Cmb.SelectedItem, "table")
        Dim strChart As String = IsNull(Widget_ChartType_Cmb.SelectedItem, "pie")
        Dim strIcone As String = Widget_Icone_Txt.Text.Replace("'", "''")
        Dim strCouleur As String = Widget_Couleur_Txt.Text.Replace("'", "''")
        Dim strDesc As String = Widget_Description_Txt.Text.Replace("'", "''")
        Dim sqlPage As String = ""
        Dim colsPage As String = ""
        Dim valsPage As String = ""
        If colonnesPage Then
            Dim menuParent As String = IsNull(Portail_Menu_cmb.SelectedValue, "").ToString().Trim.Replace("'", "''")
            Dim rang As Integer = CInt(If(Portail_Rang_Txt IsNot Nothing, Portail_Rang_Txt.Value, 99))
            sqlPage = ", estPortail=" & If(estPortail, 1, 0) & ", Menu_Parent=N'" & menuParent & "', Rang=" & rang
            colsPage = ", estPortail, Menu_Parent, Rang"
            valsPage = "," & If(estPortail, 1, 0) & ",N'" & menuParent & "'," & rang
        End If
        If CnExecuting("select count(*) from Param_Query_Widget where Cod_Query='" & Cod_Query_Text.Text & "'").Fields(0).Value > 0 Then
            CnExecuting("update Param_Query_Widget set estWidget='" & B(Widget_Chk.Checked) & "', Widget_Type='" & strType & "', Widget_ChartType='" & strChart & "', Icone=N'" & strIcone & "', Couleur='" & strCouleur & "', DefaultSpan=" & CInt(IsNull(Widget_Span_Cmb.SelectedItem, "6")) & ", Description=N'" & strDesc & "'" & sqlPage & ", Modified_By='" & theUser.Login & "', Dat_Modif=getdate() where Cod_Query='" & Cod_Query_Text.Text & "'")
        Else
            CnExecuting("insert into Param_Query_Widget (Cod_Query, estWidget, Widget_Type, Widget_ChartType, Icone, Couleur, DefaultSpan, Description" & colsPage & ", Created_By, Dat_Crea) values ('" & Cod_Query_Text.Text & "','" & B(Widget_Chk.Checked) & "','" & strType & "','" & strChart & "',N'" & strIcone & "','" & strCouleur & "'," & CInt(IsNull(Widget_Span_Cmb.SelectedItem, "6")) & ",N'" & strDesc & "'" & valsPage & ",'" & theUser.Login & "',getdate())")
        End If
    End Sub

    ''' <summary>'true'/'false' (colonnes bit lues en chaîne, convention du socle).</summary>
    Private Function B(valeur As Boolean) As String
        Return If(valeur, "true", "false")
    End Function

    ''' <summary>Garde-fou lecture seule des requêtes exposées au portail (miroir
    ''' exact du backend : littéraux neutralisés avant le test multi-instructions ;
    ''' sp_* interdit quelle que soit la casse).</summary>
    Private Function EstRequeteLectureSeule(sqlText As String) As Boolean
        Dim nettoye As String = Regex.Replace(IsNull(sqlText, ""), "'(?:[^']|'')*'", "''").Trim()
        If Not Regex.IsMatch(nettoye, "^(select|with)\b", RegexOptions.IgnoreCase) AndAlso
           Not Regex.IsMatch(nettoye, "^exec(ute)?\s+(dbo\.)?Sys_\w+", RegexOptions.IgnoreCase) Then Return False
        If Regex.IsMatch(nettoye, ";\s*\S") Then Return False
        If Regex.IsMatch(nettoye, "\b(insert|update|delete|drop|alter|create|truncate|grant|revoke|merge|bulk|openrowset|opendatasource|xp_\w+|sp_\w+)\b", RegexOptions.IgnoreCase) Then Return False
        Return True
    End Function

    Private Sub Widget_Icone_Btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim f As New Widget_Icones_Picker
        If f.ShowDialog() = DialogResult.OK AndAlso f.SelectedIcone <> "" Then
            Widget_Icone_Txt.Text = f.SelectedIcone
        End If
    End Sub

    Private Sub Widget_Preview_Btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ApercuWidget()
    End Sub

    ''' <summary>Paramètres de contexte résolus côté desktop (équivalents de ceux du JWT portail),
    ''' retournés sous forme de littéraux SQL pour Query_Converter.</summary>
    Private Function WidgetContextMap() As Dictionary(Of String, String)
        Dim m As New Dictionary(Of String, String)
        Dim mat As String = IsNull(theUser.Matricule, "")
        Dim codEntite As String = ""
        Dim codPoste As String = ""
        If mat <> "" Then
            codEntite = IsNull(FindLibelle("Cod_Entite", "Matricule", mat & "' and id_Societe='" & Societe.id_Societe, "RH_Agent"), "")
            codPoste = IsNull(FindLibelle("Cod_Poste", "Matricule", mat & "' and id_Societe='" & Societe.id_Societe, "RH_Agent"), "")
        End If
        m("@idsoc") = CStr(Societe.id_Societe)
        m("@matricule") = "'" & mat.Replace("'", "''") & "'"
        m("@codentite") = "'" & codEntite.Replace("'", "''") & "'"
        m("@codposte") = "'" & codPoste.Replace("'", "''") & "'"
        m("@login") = "'" & IsNull(theUser.Login, "").Replace("'", "''") & "'"
        m("@iduser") = "'" & CStr(IsNull(theUser.id_User, "")).Replace("'", "''") & "'"
        m("@codprofile") = "'" & CStr(IsNull(theUser.Cod_Profile, "")).Replace("'", "''") & "'"
        m("@teamleader") = "'" & IsNull(theUser.TeamLeader, "").ToString().Replace("'", "''") & "'"
        m("@datjour") = "'" & Now.ToString("yyyy-MM-dd") & "'"
        m("@debmois") = "'" & New Date(Now.Year, Now.Month, 1).ToString("yyyy-MM-dd") & "'"
        m("@finmois") = "'" & New Date(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month)).ToString("yyyy-MM-dd") & "'"
        Return m
    End Function

    ''' <summary>Alias GV_* du desktop vers les paramètres de contexte (aligné sur le backend).</summary>
    Private Function WidgetGvAlias() As Dictionary(Of String, String)
        Dim m As New Dictionary(Of String, String)
        m("gv_idsoc") = "@idsoc"
        m("gv_user") = "@iduser"
        m("gv_login") = "@login"
        m("gv_now") = "@datjour"
        m("gv_debmois") = "@debmois"
        m("gv_finmois") = "@finmois"
        Return m
    End Function

    ''' <summary>Met en forme un littéral SQL selon le type de critère déclaré.</summary>
    Private Function WidgetSqlLiteral(ByVal typCritere As String, ByVal valeur As String) As String
        Dim t As String = IsNull(typCritere, "").ToLower()
        If t.StartsWith("int") Or t.StartsWith("bigint") Or t.StartsWith("smallint") Or t.StartsWith("tinyint") Or
           t.StartsWith("float") Or t.StartsWith("real") Or t.StartsWith("decimal") Or t.StartsWith("numeric") Or t.StartsWith("money") Then
            Return valeur.Replace(",", ".")
        End If
        If t.Contains("date") Or t.Contains("time") Then
            Try
                Return "'" & CDate(valeur).ToString("yyyy-MM-dd") & "'"
            Catch ex As Exception
                Return "'" & valeur.Replace("'", "''") & "'"
            End Try
        End If
        Return "'" & valeur.Replace("'", "''") & "'"
    End Function

    Private Function WidgetCouleur() As Color
        Try
            Return ColorTranslator.FromHtml(Widget_Couleur_Txt.Text)
        Catch ex As Exception
            Return Color.FromArgb(25, 118, 210)
        End Try
    End Function

    ''' <summary>Exécute la requête avec les paramètres de contexte et affiche le rendu final
    ''' (carte KPI / graphe / grille) dans la zone d'aperçu de l'onglet.</summary>
    Sub ApercuWidget()
        If Widget_Preview_Pnl Is Nothing Or Cod_Query_Text.Text = "" Then Exit Sub
        For Each c As Control In Widget_Preview_Pnl.Controls.OfType(Of Control).ToList()
            c.Dispose()
        Next

        ' Résolution des critères : contexte > alias GV_* > Default_Value
        Dim TblCrit As DataTable = DATA_READER_GRD("select Critere, Typ_Critere, Default_Value from Param_Query_Criteres where Cod_Query='" & Cod_Query_Text.Text & "' order by Rang")
        Dim ctx As Dictionary(Of String, String) = WidgetContextMap()
        Dim gvs As Dictionary(Of String, String) = WidgetGvAlias()
        Dim vars As New List(Of String)
        For Each rw As DataRow In TblCrit.Rows
            Dim crit As String = IsNull(rw("Critere"), "")
            Dim defVal As String = IsNull(rw("Default_Value"), "").Trim
            Dim key As String = crit.ToLower()
            Dim gvKey As String = defVal.ToLower()
            If ctx.ContainsKey(key) Then
                vars.Add(ctx(key))
            ElseIf gvKey.StartsWith("gv_") AndAlso gvs.ContainsKey(gvKey) AndAlso ctx.ContainsKey(gvs(gvKey)) Then
                vars.Add(ctx(gvs(gvKey)))
            ElseIf defVal <> "" And Not gvKey.StartsWith("gv_") Then
                vars.Add(WidgetSqlLiteral(IsNull(rw("Typ_Critere"), ""), defVal))
            Else
                AfficherMessagePreview("Paramètre non résoluble sans saisie : " & crit)
                Exit Sub
            End If
        Next

        ' Exécution (Declare/Set + Cod_Sql, comme le requêteur)
        Dim TblData As DataTable
        Try
            TblData = DATA_READER_GRD(Query_Converter(Cod_Query_Text.Text, String.Join("#", vars)))
        Catch ex As Exception
            AfficherMessagePreview("Erreur d'exécution : " & ex.Message)
            Exit Sub
        End Try
        If TblData Is Nothing OrElse TblData.Columns.Count = 0 Then
            AfficherMessagePreview("La requête ne retourne aucune colonne.")
            Exit Sub
        End If

        ' Rendu selon le type déclaré
        Dim strType As String = IsNull(Widget_Type_Cmb.SelectedItem, "table")
        Select Case strType
            Case "kpi"
                RenderWidgetKpi(TblData)
            Case "chart"
                RenderWidgetChart(TblData)
            Case Else
                RenderWidgetTable(TblData)
        End Select
    End Sub

    Private Sub AfficherMessagePreview(ByVal msg As String)
        Dim lbl As New Label
        With lbl
            .Text = msg
            .AutoSize = True
            .Location = New Point(10, 10)
            .ForeColor = Color.FromArgb(211, 47, 47)
        End With
        Widget_Preview_Pnl.Controls.Add(lbl)
    End Sub

    Private Function WidgetPreviewTitre() As Label
        Dim lbl As New Label
        With lbl
            .Text = "[" & Widget_Icone_Txt.Text & "]  " & Nom_Query_Text.Text
            .AutoSize = True
            .Location = New Point(10, 8)
            .Font = New Font(.Font.FontFamily, 10, FontStyle.Bold)
            .ForeColor = WidgetCouleur()
        End With
        Return lbl
    End Function

    Private Sub RenderWidgetKpi(ByVal TblData As DataTable)
        Dim card As New Panel
        With card
            .BackColor = Color.White
            .BorderStyle = BorderStyle.FixedSingle
            .Location = New Point(10, 35)
            .Size = New Size(320, 130)
        End With
        Dim valeur As String = ""
        Dim detail As String = ""
        If TblData.Rows.Count > 0 Then
            valeur = IsNull(TblData.Rows(0)(0), "")
            If TblData.Columns.Count > 1 Then detail = IsNull(TblData.Rows(0)(1), "")
        End If
        Dim lblVal As New Label
        With lblVal
            .Text = valeur
            .AutoSize = True
            .Location = New Point(15, 25)
            .Font = New Font(.Font.FontFamily, 22, FontStyle.Bold)
        End With
        Dim lblDet As New Label
        With lblDet
            .Text = detail
            .AutoSize = True
            .Location = New Point(17, 75)
            .ForeColor = Color.Gray
        End With
        Dim strip As New Panel
        With strip
            .BackColor = WidgetCouleur()
            .Size = New Size(4, 130)
            .Location = New Point(0, 0)
        End With
        card.Controls.AddRange(New Control() {strip, lblVal, lblDet})
        Widget_Preview_Pnl.Controls.AddRange(New Control() {WidgetPreviewTitre(), card})
    End Sub

    ''' <summary>Taille de la carte d'aperçu : largeur proportionnelle à la largeur
    ''' déclarée (span sur 12), hauteur adaptée à la zone d'aperçu (dockée en bas).</summary>
    Private Function WidgetPreviewCardSize() As Size
        Dim largeurDispo As Integer = Math.Max(360, Widget_Preview_Pnl.Width - 20)
        Dim w As Integer = CInt(Math.Max(320, Math.Min(largeurDispo, largeurDispo * CInt(IsNull(Widget_Span_Cmb.SelectedItem, "6")) / 12)))
        Dim h As Integer = Math.Max(340, Widget_Preview_Pnl.Height - 45)
        Return New Size(w, h)
    End Function

    Private Sub RenderWidgetChart(ByVal TblData As DataTable)
        Dim strChart As String = IsNull(Widget_ChartType_Cmb.SelectedItem, "pie")
        Dim chartType As System.Windows.Forms.DataVisualization.Charting.SeriesChartType
        Select Case strChart
            Case "bar" : chartType = DataVisualization.Charting.SeriesChartType.Column
            Case "line" : chartType = DataVisualization.Charting.SeriesChartType.Line
            Case "area" : chartType = DataVisualization.Charting.SeriesChartType.Area
            Case Else : chartType = DataVisualization.Charting.SeriesChartType.Pie
        End Select

        Dim card As New Panel
        With card
            .BackColor = Color.White
            .BorderStyle = BorderStyle.FixedSingle
            .Location = New Point(10, 35)
            .Size = WidgetPreviewCardSize()
        End With

        Dim oChart As New DataVisualization.Charting.Chart
        With oChart
            .Dock = DockStyle.Fill
            .BackColor = Color.White
        End With
        Dim ca As New DataVisualization.Charting.ChartArea
        oChart.ChartAreas.Add(ca)
        oChart.Legends.Add(New DataVisualization.Charting.Legend)

        Dim labelCol As String = TblData.Columns(0).ColumnName
        Dim numericCols As New List(Of String)
        For Each col As DataColumn In TblData.Columns
            If col.Ordinal = 0 Then Continue For
            If col.DataType Is GetType(Integer) OrElse col.DataType Is GetType(Long) OrElse
               col.DataType Is GetType(Double) OrElse col.DataType Is GetType(Decimal) OrElse
               col.DataType Is GetType(Single) OrElse col.DataType Is GetType(Short) Then
                numericCols.Add(col.ColumnName)
            End If
        Next
        If numericCols.Count = 0 AndAlso TblData.Columns.Count > 1 Then numericCols.Add(TblData.Columns(1).ColumnName)
        If chartType = DataVisualization.Charting.SeriesChartType.Pie AndAlso numericCols.Count > 1 Then
            numericCols = numericCols.Take(1).ToList()
        End If

        For Each cn As String In numericCols
            Dim oSerie As New DataVisualization.Charting.Series
            With oSerie
                .Name = cn
                .ChartType = chartType
                .IsValueShownAsLabel = True
                .ToolTip = "#VAL"
            End With
            For Each rw As DataRow In TblData.Rows
                Dim y As Double = 0
                Try
                    y = CDbl(IsNull(rw(cn), 0))
                Catch ex As Exception
                    y = 0
                End Try
                oSerie.Points.AddXY(IsNull(rw(labelCol), "").ToString(), y)
            Next
            oChart.Series.Add(oSerie)
        Next
        card.Controls.Add(oChart)
        Widget_Preview_Pnl.Controls.AddRange(New Control() {WidgetPreviewTitre(), card})
    End Sub

    Private Sub RenderWidgetTable(ByVal TblData As DataTable)
        Dim card As New Panel
        With card
            .BackColor = Color.White
            .BorderStyle = BorderStyle.FixedSingle
            .Location = New Point(10, 35)
            .Size = WidgetPreviewCardSize()
        End With
        Dim grd As New ud_Grd
        With grd
            .Dock = DockStyle.Fill
            .DataSource = TblData
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
        Dim lblCount As New Label
        With lblCount
            .Text = TblData.Rows.Count & " ligne(s)"
            .Dock = DockStyle.Bottom
            .Height = 18
            .TextAlign = ContentAlignment.MiddleRight
            .ForeColor = Color.Gray
        End With
        card.Controls.Add(grd)
        card.Controls.Add(lblCount)
        Widget_Preview_Pnl.Controls.AddRange(New Control() {WidgetPreviewTitre(), card})
    End Sub

    Sub Request()
        Dim Cod_Sql As String
        Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 As Object
        Cod_Sql = "Select  * From Param_Query_Criteres where Cod_Query='" & Cod_Query_Text.Text & "'"
        Criterias_GRD.Rows.Clear()
        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Critere"), "")
                C2 = IsNull(.Rows(i).Item("Lib_Critere"), "")
                C3 = IsNull(.Rows(i).Item("Typ_Critere"), "")
                C4 = IsNull(.Rows(i).Item("Fonction_Critere"), "")
                C5 = IsNull(.Rows(i).Item("Table_Critere"), "")
                C6 = IsNull(.Rows(i).Item("Champs_01"), "")
                C7 = IsNull(.Rows(i).Item("Champs_02"), "")
                C8 = IsNull(.Rows(i).Item("Condition"), "")
                C10 = IsNull(.Rows(i).Item("Default_Value"), "")
                C9 = IsNull(.Rows(i).Item("Rang"), "")
                Criterias_GRD.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C10, C9)
            Next
        End With


        'Colonnes
        Cod_Sql = "Select  * From Param_Query_Colonnes where Cod_Query='" & Cod_Query_Text.Text & "'"


        Colonnes_GRD.Rows.Clear()
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Colonne"), "")
                C2 = IsNull(.Rows(i).Item("LinkTo"), "")
                C3 = IsNull(.Rows(i).Item("Typ_Ecran"), "")
                C4 = IsNull(.Rows(i).Item("Relation"), "")
                Colonnes_GRD.Rows.Add(C1, C2, C3, C4)

            Next
        End With
        Securite_Grd.Rows.Clear()
        Cod_Sql = "SELECT Cod_Profile,Lib_Profile,ISNULL((SELECT Visible FROM Controle_Droit WHERE Name_Ecran='" & Cod_Query_Text.Text & "' AND Cod_Profile=Controle_Profile.Cod_Profile),'False') as 'Visible'   FROM dbo.Controle_Profile"
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Cod_Profile"), "")
                C2 = IsNull(.Rows(i).Item("Lib_Profile"), "")
                C3 = IsNull(.Rows(i).Item("Visible"), "")
                Securite_Grd.Rows.Add(C1, C2, C3)
            Next
        End With
        GrdExportFormatRequest()
    End Sub

    Sub DelRow(ByVal sender, ByVal e)
        With Criterias_GRD
            For Each c As DataGridViewRow In .SelectedRows
                If Not c.IsNewRow Then .Rows.Remove(c)
            Next
        End With
    End Sub
    Sub Deleting()
        If Cod_Query_Text.Text = "" Then Exit Sub
        If MessageBoxRHP(560, Nom_Query_Text.Text) = MsgBoxResult.Cancel Then Exit Sub



        'Supprimer le Modèle ou le Procedure
        If CnExecuting("Select count(*) from Param_Query where Cod_Query='" & Cod_Query_Text.Text & "'").Fields(0).Value > 0 Then
            CnExecuting("delete from Param_Query where Cod_Query='" & Cod_Query_Text.Text & "'")
        End If
        CnExecuting("delete from Param_Query_Widget where Cod_Query='" & Cod_Query_Text.Text & "'")

        'Supprimer le lien du Procedure
        CnExecuting("delete from Controle_TreeView where Name_Ecran='" & Cod_Query_Text.Text & "' and Typ_Ecran='QRY'")
        CnExecuting("delete from Controle_Menu where Name_Ecran='" & Cod_Query_Text.Text & "' and Typ_Ecran='QRY'")
        'Supprimer le lien des favoris
        CnExecuting("delete from Param_Favoris where Form_Name='" & Cod_Query_Text.Text & "'")
        CnExecuting($"delete from Controle_Def_Ecran_Traitements_Specifiques where Cod_Traitement='{Cod_Query_Text.Text}'")
        Reset_Form(Me)
        '     Reset_Form(Me)
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If Nom_Query_Text.Text = "************" Then Nom_Query_Text.Text = ""
        Appel_Zoom1("MS050", Cod_Query_Text, Me)
    End Sub

    Private Sub Name_Ecran_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Query_Text.TextChanged
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
        DroitAcces(Me, DroitModify_Fiche(Cod_Query_Text.Text, Me))
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Query_Text.Text)
            Code = Cod_Query_Text.Text
        End If
        If Nom_Query_Text.Text = "************" Then Exit Sub

        If Nature_Query.Items.Count = 0 Then Nature_Query.fromRubrique("Nature_Query")
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Param_Query where Cod_Query='" & Cod_Query_Text.Text & "'")
        Grd_ExportFormat.Rows.Clear()
        With Tbl
            If .Rows.Count > 0 Then
                Nom_Query_Text.Text = .Rows(0)("Nom_Query")
                Cod_Sql_Text.Text = .Rows(0)("Cod_Sql")
                HeaderVisible_Check.Checked = IsNull(.Rows(0)("HeaderVisible"), False)
                Pivot_chk.Checked = IsNull(.Rows(0)("estPivot"), False)
                Resume_Check.Checked = IsNull(.Rows(0)("Resume"), False)
                Typ_Query_Text.Text = .Rows(0)("Typ_Query")
                Afficher_Graphe_Valeur.Checked = IsNull(.Rows(0)("Afficher_Graphe_Valeur"), False)
                Afficher3D.Checked = IsNull(.Rows(0)("Afficher3D"), False)
                Typ_Graphe.SelectedIndex = IsNull(.Rows(0)("Typ_Graphe"), 0)
                Largeur_Fixe = IsNull(.Rows(0)("Largeur_Fixe"), "")
                Separateur_txt.Text = IsNull(.Rows(0)("Separateur"), "")
                If IsNull(.Rows(0)("Typ_ExportFormat"), "") = "LF" Then
                    Rd_0.Checked = True
                Else
                    Rd_1.Checked = True
                End If
                Nature_Query.SelectedValue = IsNull(.Rows(0)("Nature_Query"), "QRY")
            Else
                Nom_Query_Text.Text = ""
                Cod_Sql_Text.Text = ""
                HeaderVisible_Check.Checked = True
                Pivot_chk.Checked = True
                Resume_Check.Checked = False
                Typ_Query_Text.Text = "U"
                Nature_Query.SelectedValue = "QRY"
                Afficher_Graphe_Valeur.Checked = False
                Afficher3D.Checked = False
                Typ_Graphe.SelectedIndex = 0
                Rd_0.Checked = False
                Rd_1.Checked = True
                Separateur_txt.Text = ";"
                Largeur_Fixe = ""
            End If
        End With
        ChargerWidgetMeta()
        If Typ_Query_Text.Text = "S" Then
            Del_D.Enabled = False
            Enabling(Cod_Sql_Text, False)
            Criterias_GRD.ReadOnly = True

        Else
            Del_D.Enabled = True
            Enabling(Cod_Sql_Text, True)
            Criterias_GRD.ReadOnly = False

        End If

        Request()
        Grd_Totaux.Rows.Clear()

    End Sub

    Private Sub Saving()
        If Cod_Query_Text.Text = "" Then Exit Sub

        ' Page de consultation portail : cohérence de l'exposition (onglet 'Widget
        ' portail') — la section est exigée (sinon la page est invisible) et la
        ' requête doit passer le garde-fou lecture seule du portail.
        If Portail_Chk IsNot Nothing AndAlso Portail_Chk.Checked Then
            If IsNull(Portail_Menu_cmb.SelectedValue, "").ToString().Trim = "" Then
                ShowMessageBox("Page de consultation portail : choisissez la section du menu portail (onglet 'Widget portail').",
                               "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
                Exit Sub
            End If
            If Not EstRequeteLectureSeule(Cod_Sql_Text.Text) Then
                ShowMessageBox("Page de consultation portail : la requête doit être en lecture seule " &
                               "(SELECT / WITH / EXEC dbo.Sys_* en une seule instruction) — le portail la refuserait à l'exécution.",
                               "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
                Exit Sub
            End If
        End If

        If Cod_Query_Text.Text.Contains("'") = True Or
Cod_Query_Text.Text.Contains(",") = True Or
Cod_Query_Text.Text.Contains("&") = True Then
            MessageBoxRHP(51)
            Exit Sub
        End If

        If Nom_Query_Text.Text = "" Then
            MessageBoxRHP(561)
            Exit Sub
        End If

        With Criterias_GRD
            For i As Integer = 0 To .RowCount - 2
                If Microsoft.VisualBasic.Left(IsNull(.Item(Critere.Index, i).Value, ""), 1) <> "@" Then
                    MessageBoxRHP(562)
                    .Item(Critere.Index, i).Style.ForeColor = Color.Red
                    Exit Sub
                ElseIf .Item("Rang", i).Value Is Nothing Then
                    MessageBoxRHP(361)
                    .Item("Rang", i).Style.ForeColor = Color.Red
                    Exit Sub
                Else
                    For j As Integer = 0 To .RowCount - 2
                        If .Item(Critere.Index, i).Value = .Item(Critere.Index, j).Value And i <> j Then
                            MessageBoxRHP(563)
                            .Item(Critere.Index, i).Style.ForeColor = Color.Red
                            Exit Sub
                        End If
                    Next
                End If
            Next
        End With
        If IsNull(Nature_Query.SelectedValue, "") <> "EXP" Then
            Largeur_Fixe = ""
        ElseIf Rd_1.Checked Then
            Separateur_txt.Text = IIf(Separateur_txt.Text.Trim = "", ";", Separateur_txt.Text.Trim)
            Largeur_Fixe = ""
            Rd_0.Checked = False
        ElseIf Rd_0.Checked Then
            Rd_1.Checked = False
            Largeur_Fixe = ""
            With Grd_ExportFormat
                For i = 0 To .RowCount - 1
                    Largeur_Fixe &= IIf(Largeur_Fixe = "", "", "|") & .Item(Champs.Index, i).Value & ":" & .Item(Largeur.Index, i).Value
                Next
            End With
        End If

        Dim rs, rs1, rs2 As New ADODB.Recordset
        'Insertion du modèle d'édition dans Param_Query
        rs.Open("Select * from Param_Query where Cod_Query='" & Cod_Query_Text.Text & "'", cn, 2, 2)
        If Not rs.EOF Then
            rs.Update()
        Else
            rs.AddNew()
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = Now
        End If
        rs("Cod_Query").Value = Cod_Query_Text.Text
        rs("Nom_Query").Value = Nom_Query_Text.Text
        rs("Cod_Sql").Value = Cod_Sql_Text.Text
        rs("Nature_Query").Value = Nature_Query.SelectedValue
        rs("Typ_Graphe").Value = Typ_Graphe.SelectedIndex
        rs("Afficher_Graphe_Valeur").Value = Afficher_Graphe_Valeur.Checked
        rs("Afficher3D").Value = Afficher3D.Checked
        rs("HeaderVisible").Value = HeaderVisible_Check.Checked
        rs("estPivot").Value = Pivot_chk.Checked
        rs("Resume").Value = Resume_Check.Checked
        If Resume_Check.Checked Then
            Dim str As String = ""
            With Grd_Totaux
                For i = 0 To .RowCount - 1
                    If CBool(.Item(ColonneTotal.Index, i).Value) Then
                        str &= IIf(str = "", "", ";") & .Item(oColonne.Index, i).Value
                    End If
                Next
            End With
            rs("ColonneSomme").Value = str
        Else
            rs("ColonneSomme").Value = ""
        End If
        rs("Modified_By").Value = theUser.Login
        rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
        rs("Typ_ExportFormat").Value = IIf(Rd_0.Checked, "LF", "SP")
        rs("Separateur").Value = IIf(Rd_1.Checked, Separateur_txt.Text.Trim, "")
        rs("Largeur_Fixe").Value = IIf(Rd_0.Checked, Largeur_Fixe, "")
        rs.Update()
        SauverWidgetMeta()
        rs.Close()
        'Insertion  dans la table génératrice du treeview
        rs1.Open("Select * from Controle_TreeView where Name_Ecran='" & Cod_Query_Text.Text & "'", cn, 2, 2)
        If Not rs1.EOF Then
            rs1.Update()
        Else
            rs1.AddNew()
        End If
        rs1("Name_Ecran").Value = Cod_Query_Text.Text
        rs1("Text_Ecran").Value = Nom_Query_Text.Text
        rs1("Typ_Ecran").Value = Nature_Query.SelectedValue
        rs1.Update()
        rs1.Close()

        'Insertion  dans la table Menu et Menu_Droit
        rs1.Open("Select * from Controle_Menu where Name_Ecran='" & Cod_Query_Text.Text & "'", cn, 2, 2)
        If Not rs1.EOF Then
            rs1.Update()
        Else
            rs1.AddNew()
        End If
        rs1("Name_Ecran").Value = Cod_Query_Text.Text
        rs1("Text_Ecran").Value = Nom_Query_Text.Text
        rs1("Typ_Ecran").Value = Nature_Query.SelectedValue
        rs1("Image1").Value = Nature_Query.SelectedValue
        rs1.Update()
        rs1.Close()
        With Criterias_GRD
            Dim Cod_Sql As String = ""
            For i = 0 To .RowCount - 1
                If Not .Item(0, i).Value Is Nothing Then
                    If Cod_Sql = "" Then
                        Cod_Sql = "'" & .Item(0, i).Value & "'"
                    Else
                        Cod_Sql = Cod_Sql & ",'" & .Item(0, i).Value & "'"
                    End If
                End If
            Next

            If Cod_Sql <> "" Then
                CnExecuting("Delete from Param_Query_Criteres where Cod_Query='" & Cod_Query_Text.Text & "' and Critere not in (" & Cod_Sql & ")")
            Else
                CnExecuting("Delete from Param_Query_Criteres where Cod_Query='" & Cod_Query_Text.Text & "'")
            End If
            For i = 0 To .RowCount - 1
                If Not .Item(0, i).Value Is Nothing Then
                    rs1.Open("select * from Param_Query_Criteres where Cod_Query='" & Cod_Query_Text.Text & "' and Critere ='" & .Item(0, i).Value & "'", cn, 2, 2)
                    If rs1.EOF Then
                        rs1.AddNew()
                    Else
                        rs1.Update()
                    End If
                    rs1("Cod_Query").Value = Cod_Query_Text.Text
                    rs1("Critere").Value = .Item(0, i).Value
                    rs1("Lib_Critere").Value = .Item(1, i).Value
                    rs1("Typ_Critere").Value = .Item(2, i).Value
                    rs1("Fonction_Critere").Value = .Item(3, i).Value
                    If .Item(3, i).Value = "Appel_Zoom" Then
                        rs1("Table_Critere").Value = .Item(4, i).Value
                        rs1("Champs_01").Value = .Item(5, i).Value
                        rs1("Champs_02").Value = .Item(6, i).Value
                        rs1("Condition").Value = .Item(7, i).Value

                    ElseIf .Item(3, i).Value = "Combo" Then
                        rs1("Table_Critere").Value = "Param_Rubriques"
                        rs1("Champs_01").Value = "Valeur"
                        rs1("Champs_02").Value = "Membre"
                        rs1("Condition").Value = .Item(7, i).Value

                    End If
                    rs1("Default_Value").Value = .Item("Default_Value", i).Value
                    rs1("Rang").Value = .Item("Rang", i).Value
                    rs1.Update()
                    rs1.Close()
                End If
            Next
        End With

        'Colonnes

        With Colonnes_GRD
            Dim Cod_Sql As String = ""
            For i = 0 To .RowCount - 1
                If Not .Item(0, i).Value Is Nothing Then
                    If Cod_Sql = "" Then
                        Cod_Sql = "'" & .Item(0, i).Value & "'"
                    Else
                        Cod_Sql = Cod_Sql & ",'" & .Item(0, i).Value & "'"
                    End If
                End If
            Next

            If Cod_Sql <> "" Then
                CnExecuting("Delete from Param_Query_Colonnes where Cod_Query='" & Cod_Query_Text.Text & "' and Colonne not in (" & Cod_Sql & ")")
            Else
                CnExecuting("Delete from Param_Query_Colonnes where Cod_Query='" & Cod_Query_Text.Text & "'")
            End If
            For i = 0 To .RowCount - 1
                If Not .Item(0, i).Value Is Nothing Then
                    rs1.Open("select * from Param_Query_Colonnes where Cod_Query='" & Cod_Query_Text.Text & "' and Colonne ='" & .Item(0, i).Value & "'", cn, 2, 2)
                    If rs1.EOF Then
                        rs1.AddNew()
                    Else
                        rs1.Update()
                    End If
                    rs1("Cod_Query").Value = Cod_Query_Text.Text
                    rs1("Colonne").Value = .Item(0, i).Value
                    rs1("LinkTo").Value = .Item(1, i).Value
                    rs1("Typ_Ecran").Value = .Item(2, i).Value
                    rs1("Relation").Value = .Item(3, i).Value
                    rs1.Update()
                    rs1.Close()
                End If
            Next
        End With

    End Sub

    Private Sub Modele_Query_GRD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Criterias_GRD.KeyUp
        With Criterias_GRD
            If e.KeyData = Keys.F6 Then
                If .CurrentCell.ColumnIndex = 4 Then
                    Appel_Zoom("Name", "Name", "sysobjects", "xtype='U' order by Name ", .CurrentCell, Me)
                End If

                If .CurrentCell.ColumnIndex = 5 Or .CurrentCell.ColumnIndex = 6 Then
                    Appel_Zoom("Name", "Name", "sysColumns", "id in (select id from sysobjects where name='" & .Item(4, .CurrentRow.Index).Value & "') order by Name", .CurrentCell, Me)
                End If

            End If
        End With
    End Sub

    Sub Adding()
        Reset()
        Dim A As String = InputBox("Saisissez le Nom du Modèle", "Nouvel Etat ou Procedure")
        If A.Contains("'") Or A.Contains("%") Or A.Contains("&") Or A.Contains(",") Then
            MessageBoxRHP(51)
            Exit Sub
        End If
        If CnExecuting("Select count(*) from Controle_Menu where Name_Ecran='" & A & "'").Fields(0).Value > 0 Then
            MessageBoxRHP(564, FindLibelle("Text_Ecran", "Name_Ecran", Cod_Query_Text.Text, "Controle_Menu"))
            Exit Sub
        End If
        If A <> "" Then
            Cod_Query_Text.Text = A
        End If
        Enabling(Nom_Query_Text, True)
    End Sub

    Sub Executing()
        If Cod_Query_Text.Text = "" Then Exit Sub
        If Cod_Sql_Text.Text = "" Then Exit Sub
        openLink(Cod_Query_Text.Text, Nom_Query_Text.Text, "QRY")
    End Sub

    Sub Dupliquer()
        If Cod_Query_Text.Text = "" Then Exit Sub

        Nom_Query_Text.Text = "************"
        Dim a As String = InputBox("Saisisser le Code de la Requête :", "Duplication de l'élément : " & Nom_Query_Text.Text).ToUpper
        If a.Contains("'") Or a.Contains("%") Or a.Contains("&") Or a.Contains(",") Then
            MessageBoxRHP(51)
            Exit Sub
        ElseIf a = "" Then
            MessageBoxRHP(110)
            Exit Sub
        ElseIf a.Length > 50 Then
            MessageBoxRHP(52, "50")
            Exit Sub
        End If

        If CnExecuting("Select count(*) from Param_Query where Cod_Query ='" & a & "'").Fields(0).Value >= 1 Then
            MessageBoxRHP(565, CnExecuting("select Nom_Query from Param_Query where Cod_Query ='" & a & "'").Fields(0).Value)
            Exit Sub
        End If
        Cod_Query_Text.Text = a
    End Sub
    Private Sub Colonnes_GRD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Colonnes_GRD.KeyUp
        Try
            If e.KeyData <> Keys.F6 Then Exit Sub
            Dim c As Integer
            Dim r As Integer
            With Colonnes_GRD
                c = .CurrentCell.ColumnIndex
                r = .CurrentCell.RowIndex
            End With
            If r < 0 Then Exit Sub
            Select Case c
                Case 0

                    If Cod_Sql_Text.Text = "" Then Exit Sub
                    Dim CodSql As String = ""
                    With Criterias_GRD
                        For i = 0 To .RowCount - 2
                            CodSql = CodSql & vbCrLf & " Declare " & .Item(0, i).Value & " as " & .Item(2, i).Value
                        Next
                    End With
                    CodSql = CodSql & vbCrLf & Cod_Sql_Text.Text
                    Dim SqlResulat As DataTable = DATA_READER_GRD(CodSql)
                    Dim SqlColumns As New DataTable
                    With SqlColumns
                        .Columns.Add("Nom de Colonne")
                    End With
                    For Each cl As DataColumn In SqlResulat.Columns
                        SqlColumns.Rows.Add(cl.ColumnName)
                    Next
                    Dim f As New Zoom_Libre
                    With f
                        .ZoomObject = Colonnes_GRD.Item(c, r)
                        .Libre_GRD.DataSource = SqlColumns
                        newShowEcran(f, True)
                    End With

                Case 1
                    If Colonnes_GRD.Item(0, r).Value = "" Then
                        MessageBoxRHP(566)
                        Exit Sub
                    End If
                    Appel_Zoom("Name_Ecran", "Text_Ecran", "Controle_Menu", "Typ_Ecran in ('ECR','QRY')", Colonnes_GRD.Item(c, r), Me)
                    Colonnes_GRD.Item(c + 1, r).Value = FindLibelle("Typ_Ecran", "Name_Ecran", Colonnes_GRD.Item(c, r).Value, "Controle_Menu")
            End Select
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub


    Private Sub SecuriteUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_ud.Click
        Dim rs As New ADODB.Recordset
        'Seul le droit Visible est géré ici : le droit Actif des requêtes exposées
        'au portail (pages-requêtes / widgets du tableau de bord) est géré profil
        'par profil dans Admin_Profile (onglet Portail) et ne doit pas être perdu —
        'les lignes dont Actif est acquis sont conservées, seul Visible est MAJ.
        CnExecuting("Delete from Controle_Droit where Name_Ecran='" & Cod_Query_Text.Text & "' and Cod_Profile<>1 and isnull(Actif,'false')<>'true'")
        CnExecuting("update Controle_Droit set Visible='False' where Name_Ecran='" & Cod_Query_Text.Text & "' and Cod_Profile<>1")
        With Securite_Grd
            For i = 0 To .RowCount - 1
                If IsNull(.Item("Visibl", i).Value, "False") = "True" And IsNull(.Item(id_User.Index, i).Value, "0") <> "1" Then
                    rs.Open("select * from Controle_Droit where Name_Ecran='" & Cod_Query_Text.Text & "' and Cod_Profile='" & .Item(id_User.Index, i).Value & "'", cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Name_Ecran").Value = Cod_Query_Text.Text
                        rs("Cod_Profile").Value = .Item(id_User.Index, i).Value
                    Else
                        rs.Update()
                    End If
                    rs("Visible").Value = .Item("Visibl", i).Value
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With
    End Sub
    Sub Enregistrer()
        Saving()
    End Sub
    Sub Nouveau()
        Adding()
    End Sub
    Sub Div_First()
        If Cod_Query_Text.Text <> "" Then
            Diviseur_First("Param_Query", "Cod_Query", "Cod_Query", Cod_Query_Text)
        End If
    End Sub

    Sub Div_Back()
        If Cod_Query_Text.Text <> "" Then
            Diviseur_Back("Param_Query", "Cod_Query", "Cod_Query", Cod_Query_Text)
        End If
    End Sub

    Sub Div_Next()
        If Cod_Query_Text.Text <> "" Then
            Diviseur_Next("Param_Query", "Cod_Query", "Cod_Query", Cod_Query_Text)
        End If
    End Sub

    Sub Div_Last()
        If Cod_Query_Text.Text <> "" Then
            Diviseur_Last("Param_Query", "Cod_Query", "Cod_Query", Cod_Query_Text)
        End If
    End Sub

    Private Sub TabControl1_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If Not TabControl1.SelectedTab Is TabPage5 Or Not Resume_Check.Checked Then Return
        If Cod_Sql_Text.Text = "" Then Exit Sub
        Dim CodSql As String = ""
        With Criterias_GRD
            For i = 0 To .RowCount - 2
                CodSql = CodSql & vbCrLf & " Declare " & .Item(0, i).Value & " as " & .Item(2, i).Value
            Next
        End With
        CodSql = CodSql & vbCrLf & Cod_Sql_Text.Text
        Dim SqlResulat As DataTable = DATA_READER_GRD(CodSql)
        Dim SqlColumns As New DataTable
        With SqlColumns
            .Columns.Add("Colonne")
            .Columns.Add("Typ_Colonne")

        End With
        For Each cl As DataColumn In SqlResulat.Columns
            SqlColumns.Rows.Add(cl.ColumnName, cl.DataType.Name)
        Next
        Dim str As String = IsNull(FindLibelle("ColonneSomme", "Cod_Query", Cod_Query_Text.Text, "Param_Query"), "")


        Dim C1, C2, C3 As Object
        With SqlColumns
            For i = 0 To .Rows.Count - 1
                C1 = .Rows(i).Item("Colonne")
                C2 = .Rows(i).Item("Typ_Colonne")
                If str <> "" Then
                    C3 = IIf(str.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Contains(C1), True, False)
                Else
                    C3 = IIf(C2.ToString.ToUpper = "DOUBLE", True, False)
                End If
                Grd_Totaux.Rows.Add(C1, C2, C3)
                Grd_Totaux.Rows(i).ReadOnly = Not CBool(C3)
            Next
        End With
    End Sub
    Private Sub Cod_Sql_Text_DoubleClick(sender As Object, e As EventArgs) Handles Cod_Sql_Text.DoubleClick
        Cod_Sql_Text.SelectAll()
    End Sub
    Private Sub Typ_Graphe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Typ_Graphe.SelectedIndexChanged
        If Typ_Graphe.SelectedIndex < 0 Then Return
        Dim Tbl As New DataTable
        Tbl.Columns.Add("Année")
        Tbl.Columns.Add("Valeur")
        Tbl.Columns("Valeur").DataType = System.Type.GetType("System.Decimal")
        Tbl.Rows.Add(Now.Year, 100000)
        Tbl.Rows.Add(Now.Year - 1, 90000)
        Tbl.Rows.Add(Now.Year - 2, 110000)
        Tbl.Rows.Add(Now.Year - 3, 75000)
        Tbl.Rows.Add(Now.Year - 4, 85000)
        ChargerChart(Chart1, Tbl, Typ_Graphe.SelectedIndex, Afficher_Graphe_Valeur.Checked, Afficher3D.Checked)
    End Sub
    Private Sub Afficher_Graphe_Valeur_CheckedChanged(sender As Object, e As EventArgs) Handles Afficher_Graphe_Valeur.CheckedChanged
        With Chart1
            For i As Integer = 0 To .Series.Count - 1
                .Series(i).IsValueShownAsLabel = Afficher_Graphe_Valeur.Checked
            Next
        End With
    End Sub

    Private Sub Param_Query_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Query_Text.Text & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Nature_Query_DropDownClosed(sender As Object, e As EventArgs) Handles Nature_Query.DropDownClosed
        If Nature_Query.Items.Count = 0 Then Return
        TabExport.Visible = (IsNull(Nature_Query.SelectedValue, "") = "EXP")
        TabGraph.Visible = (IsNull(Nature_Query.SelectedValue, "") = "CHR")
    End Sub
    Sub GrdExportFormatRequest()
        Try
            Grd_ExportFormat.Rows.Clear()
            If Cod_Sql_Text.Text = "" Then Exit Sub
            Dim oArray As New Dictionary(Of String, String)
            If Not Rd_0.Checked Then Return
            If Largeur_Fixe.Trim <> "" Then
                For i = 0 To Largeur_Fixe.Split("|").Length - 1
                    oArray.Add(Largeur_Fixe.Split("|")(i).Split(":")(0), Largeur_Fixe.Split("|")(i).Split(":")(1))
                Next
            End If
            Dim CodSql As String = ""
            With Criterias_GRD
                For i = 0 To .RowCount - 2
                    CodSql &= vbCrLf & " Declare " & .Item(0, i).Value & " as " & .Item(2, i).Value
                Next
            End With
            CodSql &= vbCrLf & Cod_Sql_Text.Text
            Dim SqlResulat As DataTable = DATA_READER_GRD(CodSql)
            With SqlResulat
                For i = 0 To .Columns.Count - 1
                    If oArray.ContainsKey(.Columns(i).ColumnName) Then
                        Grd_ExportFormat.Rows.Add(.Columns(i).ColumnName, .Columns(i).DataType.Name, oArray(.Columns(i).ColumnName))
                    Else
                        Grd_ExportFormat.Rows.Add(.Columns(i).ColumnName, .Columns(i).DataType.Name, .Columns(i).MaxLength)
                    End If
                Next
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Cod_Sql_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Sql_Text.TextChanged
        If Rd_0.Checked And IsNull(Nature_Query.SelectedValue, "") = "EXP" Then
            If Grd_ExportFormat.Rows.Count = 0 Then
                GrdExportFormatRequest()
            End If
        End If
    End Sub
    Private Sub Rd_0_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_0.CheckedChanged, Rd_1.CheckedChanged
        If Rd_0.Checked And IsNull(Nature_Query.SelectedValue, "") = "EXP" Then
            If Grd_ExportFormat.Rows.Count = 0 Then
                GrdExportFormatRequest()
            End If
        Else
            Grd_ExportFormat.Rows.Clear()
        End If
    End Sub

    Private Sub Actif_Check_CheckedChanged(sender As Object, e As EventArgs) Handles HeaderVisible_Check.CheckedChanged
        If Not HeaderVisible_Check.Checked Then Pivot_chk.Checked = False
    End Sub

    Private Sub Pivot_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Pivot_chk.CheckedChanged
        If Not HeaderVisible_Check.Checked And Pivot_chk.Checked Then Pivot_chk.Checked = False
    End Sub

    Private Sub Save_D_Click(sender As Object, e As EventArgs)

    End Sub
End Class