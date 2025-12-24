Imports System.Text.RegularExpressions
Public Class RH_Parametrage_Plan_Paie
    Dim myVBS As New vsEngine
    Friend Code As String = ""
    Dim ArrTypFunc, ArrTypFuncColor As New ArrayList
    Dim ArrRub As New List(Of ud_rubriqueLbl)
    Dim TblFunction As New DataTable
    Friend strEP() As String = Nothing
    Dim strEM() As String = Nothing
    Dim dicColorRub As New Dictionary(Of String, ArrayList)
    Dim lbSep As New Label
    Dim dist As Integer = 5
    Friend TblRubNew As New DataTable
    Dim dicRub As New Dictionary(Of String, ud_rubriqueLbl)
    Dim MaxNb As Integer = 0
    Dim ModeDuplic As Boolean = False
    Dim dicMaskedNodes As New Dictionary(Of TreeNode, TreeNode)
    Dim TblRub As DataTable = DATA_READER_GRD("SELECT Rubrique as Rub, Intitule  as Lib_Rub, Cumulable, Obligatoire, Typ_Element, Gain_Retenue, Nb, Base, Tx, Relation, Relation_VBS, Val_Defaut, Typ_Rubrique_Paie, Nature_Element_Exonere, Visible, Salarial, Patronal, Imposable_IR, 
                  Imposable_CNSS, Deductible_IR, Deductible_CNSS, isnull(estMajAuto,'false') as estMajAuto, Rang, isnull(estSysteme,'false') as estSysteme
FROM     RH_Param_Plan_Paie_Rubriques
where ';'+Cod_Pays+';' like '%;" & Societe.Cod_Pays & ";%'
ORDER BY Rang")
    Dim lblCntx As New ContextMenuStrip
    Dim selectedLbl As New ud_rubriqueLbl
    Private Sub RH_Parametrage_Plan_Paie_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If dictButtons("Save_D").Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Plan_Paie_Text.Text & "'  and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
        Reset_Form(Me)
    End Sub
    Sub Chargement()
        If Criticite_cbo.Items.Count = 0 Then Criticite_cbo.fromRubrique()
        If dicColorRub.Count = 0 Then dicColorRub = setTypRubriqueColor()
        TblFunction = DATA_READER_GRD("select Typ_Function,Cod_Function,Lib_Function,Lib_Abr as Abr_Function ,Lib_Typ_Function,Groupe_Function,Typ_Retour, isnull(Couleur,'') as Couleur,isnull(Formule_Function,'') Formule_Function, isnull(Cumulable,'false') Cumulable
from dbo.RH_Elements_Paie e
outer apply(select Membre as Lib_Typ_Function from Param_Rubriques where Nom_Controle='Typ_Function' and Valeur=e.Typ_Function) f
outer apply (select Cumulable, Couleur  from RH_Paie_Rubrique where id_Societe=e.id_Societe and Cod_Function=Cod_Rubrique)r
where  Typ_Function<>'FS' and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe & " order by Cod_Function,Lib_Function")

        Dim estFirstChargement As Boolean = False
        With TblRubNew
            If .Columns.Count = 0 Then
                estFirstChargement = True
                .Columns.Add("Rub")
                .Columns.Add("X")
                .Columns.Add("Y")
                .Columns.Add("Scale")
                .Columns("X").DataType = System.Type.GetType("System.Int64")
                .Columns("Y").DataType = System.Type.GetType("System.Int64")
                .Columns("Scale").DataType = System.Type.GetType("System.Int64")
            End If
            If estFirstChargement Then
                lblM = Nothing
                With lbSep
                    Plx.Controls.Add(lbSep)
                    .Visible = False
                    .AutoSize = False
                    .Width = 2
                    .Height = 42
                    .BackColor = colorBase02
                End With

                'vérifier si une rubrique manque à la table RH_Param_Plan_Paie
                Dim chk As DataTable = DATA_READER_GRD("SELECT  'alter table RH_Param_Plan_Paie add '+Rubrique+' nvarchar(50) null' as chk
FROM  RH_Param_Plan_Paie_Rubriques   
 where not  exists(select Column_name from INFORMATION_SCHEMA.Columns where TABLE_NAME='RH_Param_Plan_Paie' and Column_name=Rubrique)
ORDER BY CONVERT(int, Rang)")
                With chk
                    For i = 0 To .Rows.Count - 1
                        CnExecuting(.Rows(i)("chk"))
                    Next
                End With
                With Grd_Rubriques
                    .Rows.Clear()
                    Dim C1, C2, C3, C4, C5 As Object
                    With TblRub
                        For i = 0 To .Rows.Count - 1
                            C1 = IsNull(.Rows(i)("Rub"), "")
                            C4 = IsNull(.Rows(i)("Obligatoire"), False)
                            C2 = IsNull(.Rows(i)("Lib_Rub"), "") & IIf(C4, " (*)", "")
                            C3 = If(TblRub.Select("Rub='" & C1 & "' and (estSysteme='true' or Typ_Element not in ('EB','EC','EV','CS'))").Length > 0, C1, "")
                            C5 = IsNull(.Rows(i)("Typ_Element"), "*")
                            Grd_Rubriques.Rows.Add(C1, C2, C3, C4, C5)
                        Next
                    End With
                End With
                Dim Mnu01 As New ToolStripMenuItem
                With Mnu01
                    .Text = "Editer l'élément"
                    AddHandler .Click, AddressOf EditerElement

                End With
                lblCntx.Items.Add(Mnu01)
            End If
        End With
    End Sub
    Private Sub RH_Parametrage_Plan_Paie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MajTreeView()
        With rubrique_search_txt
            .ForeColor = colorBase01
            .BackColor = colorBase04
            .Font = New Font(.Font.FontFamily, .Height / 2 + 2)
        End With
        With Rechercher_txt
            .ForeColor = colorBase01
            .BackColor = colorBase04
            .Font = New Font(.Font.FontFamily, .Height / 2 + 2)
        End With

    End Sub
    Sub EditerElement(sender As Object, e As EventArgs)
        Dim obj As Object = sender.GetCurrentParent.sourcecontrol
        Dim rubName As String = ""
        Select Case True
            Case obj.GetType Is GetType(ud_rubriqueLbl)
                rubName = obj.name
            Case obj.GetType Is GetType(TreeView)
                rubName = obj.selectednode.name
        End Select
        If rubName <> "" Then
            Dim nrW() As DataRow = TblFunction.Select("Cod_Function='" & rubName & "'")
            If nrW.Length > 0 Then
                If "FU;FP".Split({";"}, StringSplitOptions.RemoveEmptyEntries).Contains(nrW(0)("Typ_Function")) Then
                    Dim f As New RH_Functions
                    With f
                        .Cod_Function_Text.Text = rubName
                        .Cod_Function_Text_Leave(Nothing, Nothing)
                        .StartPosition = FormStartPosition.CenterScreen
                        newShowEcran(f, True)
                        Refreshing()
                    End With

                ElseIf "EC;EB;EV;CS;EX".Split({";"}, StringSplitOptions.RemoveEmptyEntries).Contains(nrW(0)("Typ_Function")) Then
                    Dim f As New RH_Parametrage_Rubrique_Paie
                    With f
                        .Cod_Rubrique_txt.Text = rubName
                        .Cod_Rubrique_txt_Leave(Nothing, Nothing)
                        .StartPosition = FormStartPosition.CenterScreen
                        newShowEcran(f, True)
                        Refreshing()
                    End With
                End If
            End If
        End If
    End Sub
    Sub MajTreeView()
        Chargement()
        Function_Trv.ExpandAll()
        Dim nRows() As DataRow
        Dim TblTitre As DataTable = DATA_READER_GRD("select Valeur,Membre from Param_Rubriques where Nom_Controle='Function' and (isnull( Valeur,'') not like 'FS%' or isnull( Valeur,'') like 'FS_Paie') order by Rang")

        With TblTitre
            Function_Trv.Nodes(0).Nodes.Clear()
            Function_Trv.Nodes(1).Nodes.Clear()
            Function_Trv.Nodes(2).Nodes.Clear()
            Function_Trv.Nodes(3).Nodes.Clear()
            Function_Trv.Nodes(4).Nodes.Clear()
            For i = 0 To .Rows.Count - 1
                Dim m As New TreeNode
                With m
                    .Name = TblTitre.Rows(i).Item("Valeur")
                    .Text = TblTitre.Rows(i).Item("Membre")
                    .ImageIndex = 0
                    .ForeColor = Color.FromArgb(56, 56, 56) 'dicColor(IsNull(.Name, ""))(0)
                    .NodeFont = New System.Drawing.Font("Century Gothic", 8.25!, FontStyle.Bold)
                    Select Case Gauche(.Name, 2)
                        Case "FU"
                            Function_Trv.Nodes(3).Nodes.Add(m)
                        Case "RB"
                            Function_Trv.Nodes(1).Nodes.Add(m)
                        Case "AG"
                            Function_Trv.Nodes(2).Nodes.Add(m)
                        Case "EP"
                            Function_Trv.Nodes(4).Nodes.Add(m)
                        Case "FS"
                            Function_Trv.Nodes(0).Nodes.Add(m)
                    End Select
                End With
                nRows = TblFunction.Select("[Groupe_Function]='" & TblTitre.Rows(i).Item("Valeur") & "' and Typ_Retour in ('int','float') ", "Cod_Function, Lib_Function")
                For j = 0 To nRows.Length - 1
                    Dim n As New TreeNode
                    With n
                        .Name = nRows(j).Item("Cod_Function")
                        .Checked = dicRub.ContainsKey(.Name)
                        .Text = .Name & " : " & nRows(j).Item("Lib_Function")
                        .ToolTipText = nRows(j).Item("Cod_Function")
                        .Tag = "Var"
                        .ImageIndex = IIf(.Checked, 2, 1)
                        .SelectedImageIndex = .ImageIndex
                        .ForeColor = Color.Gray
                        .ContextMenuStrip = lblCntx
                    End With
                    m.Nodes.Add(n)
                Next
                m.ExpandAll()
            Next
        End With
        Function_Trv.ExpandAll()
    End Sub
    Private Sub Cod_Plan_Paie__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Cod_Plan_Paie_.LinkClicked
        Appel_Zoom1("MS012", Cod_Plan_Paie_Text, Me)
        Request()
        Lib_Plan_Paie_Text.Select()
    End Sub

    Private Sub Cod_Plan_Paie_Text_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Plan_Paie_Text.Leave
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "' and id_Societe=" & Societe.id_Societe)
        End If
        If Cod_Plan_Paie_Text.ReadOnly Then Return
        Request()

        DroitAcces(Me, DroitModify_Fiche(Cod_Plan_Paie_Text.Text, Me))

        If dictButtons("Save_D").Enabled = True Then
            Check_Accessible(Me.Name, Cod_Plan_Paie_Text.Text)
            Code = Cod_Plan_Paie_Text.Text
        End If
        Enabling(Cod_Plan_Paie_Text, False)
    End Sub
    Sub Request()
        If ModeDuplic = True Then Return
        Plx.Controls.Clear()
        ArrRub.Clear()
        dicRub.Clear()
        Rechercher_txt.Text = ""
        With Function_Trv
            If .Nodes.Count = 0 Then
                MajTreeView()
            ElseIf .Nodes(0).Nodes.Count = 0 Then
                MajTreeView()
            Else
                For i = 0 To .Nodes.Count - 1
                    UncheckTrv(.Nodes(i))
                Next
            End If
        End With
        '   Try
        Dim lnd() As TreeNode
        Dim TblPlan As DataTable = DATA_READER_GRD("select * from RH_Param_Plan_Paie where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        With TblPlan
            If .Rows.Count > 0 Then
                Lib_Plan_Paie_Text.Text = IsNull(.Rows(0)("Lib_Plan_Paie"), "")
                LastAnneePaie_txt.Text = IsNull(.Rows(0)("LastAnneePaie"), "")
                LastMoisPaie_txt.Text = IsNull(.Rows(0)("LastMoisPaie"), "")
                Modele_Bulletin_txt.Text = IsNull(.Rows(0)("Modele_Bulletin"), "")
                JourPaie.Value = IsNull(.Rows(0)("JourPaie"), 1)
                strEP = IsNull(.Rows(0)("Element_Paie"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                strEM = IsNull(.Rows(0)("Element_Masques"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                With Function_Trv
                    If Not strEP Is Nothing Then
                        For i = 0 To strEP.Length - 1
                            Dim rb As String = strEP(i)
                            lnd = .Nodes.Find(strEP(i), True)
                            If lnd.Length > 0 Then
                                lnd(0).Checked = True
                            ElseIf TblFunction.Select("Cod_Function='" & strEP(i) & "'").Length = 0 Then
                                ShowMessageBox("La rubrique : '" & strEP(i) & "' est introuvable", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
                            End If
                        Next
                    End If
                End With
                With Grd_Rubriques
                    For i = 0 To .Rows.Count - 1
                        .Item(Valeur.Index, i).Value = IsNull(TblPlan.Rows(0)(.Item(Rubrique.Index, i).Value), If(TblRub.Select("Rub='" & .Item(Rubrique.Index, i).Value & "' and (estSysteme='true' or Typ_Element not in ('EB','EC','EV','CS'))").Length > 0, .Item(Rubrique.Index, i).Value, ""))
                    Next
                End With
            Else
                Lib_Plan_Paie_Text.Text = ""
                LastAnneePaie_txt.Text = ""
                LastMoisPaie_txt.Text = ""
                Modele_Bulletin_txt.Text = ""
                JourPaie.Value = 1
                strEP = Nothing
                strEM = Nothing
                With Grd_Rubriques
                    For i = 0 To .Rows.Count - 1
                        .Item(Valeur.Index, i).Value = If(TblRub.Select("Rub='" & .Item(Rubrique.Index, i).Value & "' and (estSysteme='true' or Typ_Element not in ('EB','EC','EV','CS'))").Length > 0, .Item(Rubrique.Index, i).Value, "")
                    Next
                End With
            End If
        End With
        Function_Trv.ExpandAll()
        RequestRegleControle()
        '   Catch ex As Exception
        '     ShowMessageBox(ex.Message, Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
        '    End Try
    End Sub
    Sub UncheckTrv(Nd As TreeNode)
        Nd.Checked = False
        For Each a As TreeNode In Nd.Nodes
            UncheckTrv(a)
        Next
    End Sub
    Function FindNodeByNameChild(Nod As TreeNode, NdName As String, bn As TreeNode) As TreeNode
        If Not bn Is Nothing Then
            Return bn
            Exit Function
        End If
        If Nod.Name.ToUpper.Trim = NdName.ToUpper.Trim Then
            bn = Nod
        Else
            For Each nd As TreeNode In Nod.Nodes
                bn = FindNodeByNameChild(nd, NdName, bn)
            Next
        End If
        Return bn
    End Function
    Sub AjouterRubrique(CodRubrique As String)
        If dicRub.ContainsKey(CodRubrique) Then Return
        Dim nRow() As DataRow = TblFunction.Select("Cod_Function='" & CodRubrique & "'")
        Dim infobulle As New System.Windows.Forms.ToolTip
        If nRow.Length = 0 Then Return
        Dim lb As New ud_rubriqueLbl
        With lb
            .Name = CodRubrique
            .Text = IsNull(nRow(0)("Abr_Function"), nRow(0)("Lib_Function")).Trim()
            .CodCouleur = nRow(0)("Couleur")
            .BorderStyle = BorderStyle.None
            .Cursor = Cursors.Hand
            AddHandler .Click, AddressOf ClickEv
            AddHandler .MouseDown, AddressOf lb_MouseDown
            AddHandler .MouseMove, AddressOf lb_MouseMove
            AddHandler .MouseUp, AddressOf lb_MouseUp
            If Not strEM Is Nothing Then
                .Visibility = (Not strEM.Contains(.Name))
            Else
                .Visibility = True
            End If
            .ContextMenuStrip = lblCntx
            .Rang = ArrRub.Count + 1
            infobulle.SetToolTip(lb, IsNull(nRow(0)("Cod_Function"), "") & vbCrLf & IsNull(nRow(0)("Lib_Function"), "") & vbCrLf & IsNull(nRow(0)("Lib_Typ_Function"), ""))
            Plx.Controls.Add(lb)
            If ArrRub.Count = 0 Then
                .Location = New Point(dist, dist)
            Else
                Dim LastLbl As ud_rubriqueLbl = ArrRub(ArrRub.Count - 1)

                If (LastLbl.Location.X + LastLbl.Width + dist + .Width + dist <= Plx.Width) Then
                    .Location = New Point(LastLbl.Location.X + LastLbl.Width + dist, LastLbl.Location.Y)
                Else
                    .Location = New Point(dist, LastLbl.Location.Y + LastLbl.Height + dist)
                End If
            End If
            ArrRub.Add(lb)
            dicRub.Add(CodRubrique, lb)
            Dim nd() As TreeNode = Function_Trv.Nodes.Find(CodRubrique, True)
            If nd.Length > 0 Then
                If Not nd(0).Checked Then
                    nd(0).Checked = True
                End If
            End If
        End With
        '  PreparerTableauOrdreLbl()
    End Sub
    Sub rubrique_search_txt_textChanged(sender As TextBox, e As EventArgs) Handles rubrique_search_txt.TextChanged
        For i = 0 To dicRub.Values.Count - 1
            dicRub.Values(i).Visible = (dicRub.Values(i).Name.ToUpper.Contains(rubrique_search_txt.Text.Trim.ToUpper) Or dicRub.Values(i).Text.ToUpper.Contains(rubrique_search_txt.Text.Trim.ToUpper))
            dicRub.Values(i).canMove = (rubrique_search_txt.Text = "")
        Next
        ReorrganiserRub(False)
    End Sub
    Sub ClickEv(sender As ud_rubriqueLbl, e As EventArgs)
        Dim nd() As TreeNode = Function_Trv.Nodes.Find(sender.Name, True)
        If nd.Length = 0 Then Return
        Function_Trv.Select()
        Function_Trv.SelectedNode = nd(0)
    End Sub
    Sub SupprimerRubrique(lb As ud_rubriqueLbl)
        Dim Loc As Point = lb.Location
        Dim sz As Size = lb.Size
        Dim ind As Integer = ArrRub.IndexOf(lb)
        Plx.Controls.Remove(lb)
        Do While ind < ArrRub.Count - 1
            ind += 1
            With ArrRub(ind)
                If Loc.X + .width + dist < Plx.Width - dist Then
                    .location = Loc
                Else
                    .location = New Point(dist, Loc.Y + sz.Height + dist)
                End If
                Loc = New Point(.location.X + .width + dist, .location.Y)
                .rang = ind
            End With
        Loop
        ArrRub.Remove(lb)
        dicRub.Remove(lb.Name)
    End Sub
    Private Sub Function_Trv_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Function_Trv.AfterCheck
        If Not IsNull(e.Node.Tag, "") = "Var" Then Exit Sub
        If e.Node.Checked Then
            'ajout de valeur
            If Not dicRub.ContainsKey(e.Node.Name) Then
                AjouterRubrique(e.Node.Name)
            End If
        ElseIf dicRub.ContainsKey(e.Node.Name) Then
            Dim rulestr As String = CnExecuting("declare @s varchar(max)
                                        set @s=''
                                        select @s=@s+case when @s='' then '' else ';' end+isnull(ErreurSi,'')+';'+isnull(Msg_Erreur,'')
                                        from RH_Param_Plan_Paie_Controle where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "'  and id_Societe=" & Societe.id_Societe & "
                                        select ISNULL(@s,'')").Fields(0).Value
            If rulestr.Trim <> "" Then
                Dim rgrules As New Regex("\b(" & e.Node.Name & ")\b")
                If rgrules.IsMatch(rulestr) Then
                    ShowMessageBox("La rubrique '" & e.Node.Text & "' est utilisée dans une règle de contrôle", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                    e.Node.Checked = True
                    Return
                End If
            End If
            SupprimerRubrique(dicRub(e.Node.Name))
        End If
        e.Node.ImageIndex = If(e.Node.Checked, 2, 1)
        e.Node.SelectedImageIndex = e.Node.ImageIndex
    End Sub
    Sub Enregistrer()
        Saving()
    End Sub
    Function Saving(Optional silentMode As Boolean = False) As Boolean
        '      Try
        Cursor = Cursors.WaitCursor
            If Cod_Plan_Paie_Text.Text = "" Then
                Cursor = Cursors.Default
                If Not silentMode Then MessageBoxRHP(700)
                Return False
            End If
            If Lib_Plan_Paie_Text.Text.Trim = "" Then
                Cursor = Cursors.Default
                If Not silentMode Then MessageBoxRHP(701)
                Return False
            End If
            If ArrRub.Count = 0 Then
                Cursor = Cursors.Default
                If Not silentMode Then MessageBoxRHP(702)
                Return False
            End If
            Dim _strEP As String = ""
            Dim _strEM As String = ""

            For i = 0 To ArrRub.Count - 1
                If _strEP = "" Then
                    _strEP &= ArrRub(i).name
                Else
                    _strEP &= ";" & ArrRub(i).name
                End If
            Next
            For i = 0 To ArrRub.Count - 1
                If Not CBool(ArrRub(i).visibility) Then
                    If _strEM = "" Then
                        _strEM &= ArrRub(i).name
                    Else
                        _strEM &= ";" & ArrRub(i).name
                    End If
                End If
            Next

            With Grd_Rubriques
                For i = 0 To .Rows.Count - 1
                    If CBool(.Item(Obligatoire.Index, i).Value) Then
                        If IsNull(.Item(Valeur.Index, i).Value, "").Trim = "" Then
                            If Not silentMode Then
                                Cursor = Cursors.Default
                                ShowMessageBox("La rubrique relative à : " & vbCrLf & .Item(Lib_Rubrique.Index, i).Value & vbCrLf & "n'est pas renseignée", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
                                TabControl1.SelectedIndex = 1
                                .Rows(i).Selected = True
                                .FirstDisplayedCell = .Item(Lib_Rubrique.Index, i)
                            End If
                            Return False
                        End If
                    End If
                    If IsNull(.Item(Valeur.Index, i).Value, "").Trim <> "" Then
                        If Not dicRub.ContainsKey(.Item(Valeur.Index, i).Value.Trim) Then
                            If Not silentMode Then
                                Cursor = Cursors.Default
                                ShowMessageBox("La rubrique relative à : " & vbCrLf & .Item(Lib_Rubrique.Index, i).Value & vbCrLf & "ne figure pas parmi les éléments à traiter", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
                                TabControl1.SelectedIndex = 1
                                .Rows(i).Selected = True
                                .FirstDisplayedCell = .Item(Lib_Rubrique.Index, i)
                            End If
                            Return False
                        End If
                    End If
                Next
            End With
            Dim TblEB As DataTable = DATA_READER_GRD("select Matricule,Cod_Rubrique from RH_Agent_Element_Paie  e
                        where id_Societe=" & Societe.id_Societe & "  
                        and exists(select Matricule from RH_Agent a where id_Societe=e.id_Societe and Matricule=e.Matricule and Plan_Paie='" & Cod_Plan_Paie_Text.Text & "')")
            With TblEB.DefaultView().ToTable(True, "Cod_Rubrique")
                For i = 0 To .Rows.Count - 1
                    If Not dicRub.ContainsKey(.Rows(i)("Cod_Rubrique")) Then
                        Cursor = Cursors.Default
                        If Not silentMode Then ShowMessageBox("Au moins un élément de base de la paie ([" & .Rows(i)("Cod_Rubrique") & "]) renseigné pour le Matricule [" & TblEB.Select("Cod_Rubrique='" & .Rows(i)("Cod_Rubrique") & "'")(0)("Matricule") & "], ne figurant pas sur ce plan.", "Controle", MessageBoxButtons.OK, msgIcon.Stop)
                        Return False
                    End If
                Next
            End With
            If Modele_Bulletin_txt.Text = "" Then
                If Not silentMode Then
                    Cursor = Cursors.Default
                    ShowMessageBox("Vous devez sélectionner un modèle d'édition pour les bulletins de paie.", "Controle", MessageBoxButtons.OK, msgIcon.Stop)
                    TabControl1.SelectedIndex = 1
                    LinkLabel4_LinkClicked(Nothing, Nothing)
                End If
                Return False
            Else
                Dim Rpt As String = FindParam("Lecteur_Digital_Mod_Edition") & "\" & Modele_Bulletin_txt.Text & ".rpt"
                If IO.File.Exists(Rpt) = False Then
                    Cursor = Cursors.Default
                    ShowMessageBox("Le modèle de bulletin de paie choisi n'existe pas.", "Controle", MessageBoxButtons.OK, msgIcon.Stop)
                    TabControl1.SelectedIndex = 1
                    LinkLabel4_LinkClicked(Nothing, Nothing)
                    Return False
                End If
            End If
            Dim rubCumManquantes = simplifierFormule()
            If rubCumManquantes.Trim <> "" Then
                Cursor = Cursors.Default
                ShowMessageBox("Au moins une rubrique cumulée est utilisée dans un élément calculé, alors qu'elle n'est pas comprise dans le plan." & vbCrLf & rubCumManquantes & vbCrLf & "Elle sera ajoutée automatiquement.", "Controle", MessageBoxButtons.OK, msgIcon.Stop)
                AjouterRubrique(rubCumManquantes)
                With dicRub(rubCumManquantes)
                    .Visibility = False
                End With
                TabControl1.SelectedIndex = 0
                Return False
            End If
            Dim oDat As String = Now
        Dim rs As New ADODB.Recordset
        rs.Open("select * from RH_Param_Plan_Paie where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
                rs.AddNew()
                rs("Dat_Crea").Value = oDat
                rs("Created_By").Value = theUser.Login
                rs("id_Societe").Value = Societe.id_Societe
                rs("Cod_Plan_Paie").Value = Cod_Plan_Paie_Text.Text
            Else
                rs.Update()
            End If
            rs("JourPaie").Value = JourPaie.Value
            rs("Lib_Plan_Paie").Value = Lib_Plan_Paie_Text.Text
            rs("Modele_Bulletin").Value = Modele_Bulletin_txt.Text
            rs("Element_Paie").Value = _strEP
            rs("Element_Masques").Value = _strEM
            With Grd_Rubriques
                For i = 0 To .Rows.Count - 1
                    rs(.Item(Rubrique.Index, i).Value).Value = .Item(Valeur.Index, i).Value
                Next
            End With
            rs("Dat_Modif").Value = oDat
            rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()
        'après avoir enregistré la ligne mettre à jour le statur Valide
        CnExecuting("update RH_Param_Plan_Paie set Valide='true' where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)

        Dim nRw As DataRow()
            Dim estMaj As String = ""
            With Grd_Rubriques
                For i = 0 To .RowCount - 1
                    nRw = TblRub.Select("isnull(estMajAuto,'false')='true' and Rub='" & .Item(Rubrique.Index, i).Value & "'")
                    If nRw.Length > 0 Then
                        estMaj &= IIf(estMaj = "", "", "','") & .Item(Valeur.Index, i).Value
                    End If
                Next
            End With
            estMaj = "'" & estMaj & "'"
            CnExecuting("update RH_Paie_Rubrique set estMajAuto= case when Cod_Rubrique in (" & estMaj & ") then estMajAuto else 'false' end where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe & " and Cod_Rubrique in('" & String.Join("','", _strEP.Split({";"}, StringSplitOptions.RemoveEmptyEntries)) & "')")
            CnExecuting("exec Sys_RH_Rubriques_Plan " & Societe.id_Societe)
            CnExecuting("exec Sys_RH_Rubriques_Plan_Bulletin " & Societe.id_Societe & ", '" & Cod_Plan_Paie_Text.Text & "'")
            ModeDuplic = False
            If If(strEP Is Nothing, "", String.Join(";", strEP)) <> _strEP Then
                If ShowMessageBox("Vous avez modifié la structure du plan de paie. Voulez-vous modifier le paramétrage du bulletin de paie?", "Bulletin de paie", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.OK Then
                    Dim f As New RH_Parametrage_Bulletin_Paie
                    f.Cod_Plan_Paie_Text.Text = Cod_Plan_Paie_Text.Text
                    newShowEcran(f, Me.estModal)
                    silentMode = True
                End If
            End If
            Cursor = Cursors.Default
            Request()
            If silentMode Then
                Me.Close()
            Else
                ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
            End If
            Return True
        '    Catch ex As Exception
        '   Cursor = Cursors.Default
        '   '      If Not silentMode Then ShowMessageBox(ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)
        '  ModeDuplic = False
        '   Return False
        '   End Try
    End Function
    Sub Nouveau()
        ModeDuplic = False
        Reset_Form(Plan_Grp)
        Modele_Bulletin_txt.Text = FindLibelle("Cod_Report", "isnull(Typ_Modele_Edition,'A')", "BP", "Param_Mod_Edition")
        Cod_Plan_Paie_Text_Leave(Nothing, Nothing)
        Enabling(Cod_Plan_Paie_Text, True)
        Cod_Plan_Paie_Text.Select()
        TabControl1.SelectedIndex = 0
    End Sub
    Sub Dupliquer()
        Cod_Plan_Paie_Text.Text &= "***"
        Lib_Plan_Paie_Text.Text &= "***"
        Cod_Plan_Paie_Text.Select()
        ModeDuplic = True
        Enabling(Cod_Plan_Paie_Text, True)
    End Sub
    Sub Actualiser()
        Refreshing()
    End Sub
    Sub Refreshing()
        MajTreeView()
        ReorrganiserRub(True)
    End Sub
    Dim lblM As New ud_rubriqueLbl
    Dim lblTarget As New ud_rubriqueLbl
    Dim P0 As New Point
    Dim initialLoc As New Point
    Dim codCouleur As String = "0;255;0"
    Dim codCouleurOrigine As String = ""
    Private Sub lb_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If rubrique_search_txt.Text <> "" Then Return
        If e.Button = MouseButtons.Right Then Return
        Dim lb As Object = Plx.GetChildAtPoint(New Point(e.X + sender.location.x, e.Y + sender.location.y))
        If Not lb Is Nothing Then
            lblM = lb
            P0 = New Point(e.X, e.Y)
            initialLoc = lb.location
        End If
        lblM.BringToFront()
    End Sub
    Private Sub lb_MouseMove(sender As Object, e As MouseEventArgs)
        If rubrique_search_txt.Text <> "" Then Return
        If lblM Is Nothing Then Return
        If e.Button = MouseButtons.Right Then Return
        Dim lb As Object = Plx.GetChildAtPoint(New Point(e.X + sender.location.x, e.Y + sender.location.y))
        If lb Is lblM Then Return
        lblM.Location = New Point(e.X + sender.location.x - P0.X, e.Y + sender.location.y - P0.Y)
        Dim Xp, Yp, Xx, Yy As Integer
        Xp = sender.location.x
        Yp = sender.location.y
        If lb IsNot Nothing Then
            Xx = lb.location.x - 2
            Yy = lb.location.y
            With lbSep
                .BringToFront()
                .Visible = True
                .Location = New Point(Xx - 1, Yy)
                If Not Plx.Controls.Contains(lbSep) Then Plx.Controls.Add(lbSep)
            End With
            If lb IsNot lblTarget And lb.GetType = GetType(ud_rubriqueLbl) Then
                If lblTarget IsNot Nothing Then
                    lblTarget.CodCouleur = codCouleurOrigine
                End If
                codCouleurOrigine = lb.CodCouleur
                lblTarget = lb
                lblTarget.CodCouleur = codCouleur
            End If
        Else
            lbSep.Visible = False
            Xx = Xp
            Yy = Yp
            If lblTarget IsNot Nothing Then
                lblTarget.CodCouleur = codCouleurOrigine
                lblTarget = Nothing
                codCouleurOrigine = ""
            End If
        End If
    End Sub
    Private Sub lb_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then Return
        If rubrique_search_txt.Text <> "" Then Return
        If lblTarget IsNot Nothing Then
            ArrRub.Remove(sender)
            Dim ind = ArrRub.IndexOf(lblTarget)
            If ind >= 0 Then
                ArrRub.Insert(ind, sender)
            Else
                ArrRub.Add(sender)
            End If
            sender.location = New Point(lblTarget.Location.X - 1, lbSep.Location.Y)
            lbSep.Visible = False
            lblTarget.CodCouleur = codCouleurOrigine
            lblTarget = Nothing
            codCouleurOrigine = ""
        End If
        lblM = Nothing
        ReorrganiserRub(False)
    End Sub
    Sub ReorrganiserRub(withMaj As Boolean)
        Dim infobulle As New ToolTip
        Dim LastLbl As New ud_rubriqueLbl
        Dim k = 0
        With ArrRub
            For i = 0 To .Count - 1
                Dim lb = ArrRub(i)
                lb.Rang = i + 1
                If lb.Visible Then
                    If withMaj Then
                        Dim nRow() As DataRow = TblFunction.Select("Cod_Function='" & lb.Name & "'")
                        If nRow.Length > 0 Then
                            With lb
                                .Text = IsNull(nRow(0)("Abr_Function"), nRow(0)("Lib_Function")).Trim()
                                .CodCouleur = nRow(0)("Couleur")
                                infobulle.SetToolTip(lb, IsNull(nRow(0)("Cod_Function"), "") & vbCrLf & IsNull(nRow(0)("Lib_Function"), "") & vbCrLf & IsNull(nRow(0)("Lib_Typ_Function"), ""))
                            End With
                        End If
                    End If
                    If k = 0 Then
                        lb.Location = New Point(dist, dist - Plx.VerticalScroll.Value)
                    Else

                        If (LastLbl.Location.X + LastLbl.Size.Width + lb.Width + dist <= Plx.Width - dist) Then
                            lb.Location = New Point(LastLbl.Location.X + LastLbl.Size.Width + dist, LastLbl.Location.Y)
                        Else
                            lb.Location = New Point(dist, LastLbl.Location.Y + LastLbl.Size.Height + dist)
                        End If
                    End If
                    LastLbl = lb
                    k += 1
                End If
            Next
        End With
    End Sub
    Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        If Societe.LeMatricule = "" Then
            Zoom_RH_Saisie_EV.ShowDialog()
        End If
        If Cod_Plan_Paie_Text.Text = "" Then
            Return
        End If
        If Cod_Plan_Paie_Text.Text = "" Then
            ShowMessageBox("Code plan vide", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim xwh As String = ""
        With Plx
            For Each lb In .Controls
                xwh &= IIf(xwh = "", "", ",") & "'" & lb.name & "'"
            Next
        End With
        If xwh = "" Then
            ShowMessageBox("Contenu du plan vide", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim f As New Zoom_RH_Editeur_Formule
        With f
            .myVBS = myVBS
            .xwhere = " and (Typ_Function in ('FS','CS','EB') or Cod_Function in (" & xwh & ")) "
            .TypRetour = "bit"
            .otxt = ErreurSi_txt
            .Formule_Function_Text.Text = ErreurSi_txt.Text
            .ShowDialog()
        End With
    End Sub
    Private Sub Ajouter_D_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        If Cod_Plan_Paie_Text.Text = "" Then
            ShowMessageBox("Veuillez choisir d'abord un plan de paie", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ErreurSi_txt.Text = "" Then
            ShowMessageBox("Règle de contrôle d'erreur vide", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Msg_Erreur_txt.Text = "" Then
            ShowMessageBox("Texte du message d'erreur vide", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from RH_Param_Plan_Paie_Controle where id_Societe=" & Societe.id_Societe & " and Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and  id_Controle='" & id_Controle_txt.Text & "'", cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
        Else
            rs.Update()
        End If
        rs("id_Societe").Value = Societe.id_Societe
        rs("Cod_Plan_Paie").Value = Cod_Plan_Paie_Text.Text
        rs("ErreurSi").Value = ErreurSi_txt.Text
        rs("Msg_Erreur").Value = Msg_Erreur_txt.Text
        rs("Criticite").Value = Criticite_cbo.SelectedValue
        rs("Bloquant").Value = Bloquant_chk.Checked
        rs.Update()
        rs.Close()
        RequestRegleControle()
    End Sub

    Private Sub Supprimer_D_Click(sender As Object, e As EventArgs) Handles Del_pb.Click
        If id_Controle_txt.Text = "" Then Return
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette règle?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Param_Plan_Paie_Controle where id_Societe=" & Societe.id_Societe & " and Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Controle= '" & id_Controle_txt.Text & "'")
        RequestRegleControle()
    End Sub
    Private Sub Nouveau_D_Click(sender As Object, e As EventArgs) Handles New_pb.Click
        Reset_Form(Controle_Pnl)
    End Sub

    Sub Deleting()
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer ce plan de paie?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        If CnExecuting("Select count(*) from RH_Agent where Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            ShowMessageBox("Plan utilisé dans la fiche agent", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        CnExecuting("delete from RH_Param_Plan_Paie where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        CnExecuting("delete from RH_Param_Plan_Paie_Controle where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        CnExecuting("delete from RH_Param_Plan_Paie_Filtre where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        Nouveau()
    End Sub
    Private Sub Grd_Controles_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Controles.CellMouseDoubleClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex < 0 Then Return
        If Grd_Controles.RowCount <= 0 Then Return
        With Grd_Controles
            id_Controle_txt.Text = .Item("N° Règle", e.RowIndex).Value
            ErreurSi_txt.Text = .Item("Erreur si", e.RowIndex).Value
            Msg_Erreur_txt.Text = .Item("Message", e.RowIndex).Value
            Criticite_cbo.SelectedValue = .Item("Criticité", e.RowIndex).Value
            Bloquant_chk.Checked = .Item("Bloquant", e.RowIndex).Value
        End With
    End Sub
    Sub RequestRegleControle()
        GRD("select id_Controle as 'N° Règle', ErreurSi 'Erreur si', Msg_Erreur 'Message', 
Criticite as 'Criticité', Bloquant
FROM  RH_Param_Plan_Paie_Controle
where id_Societe=" & Societe.id_Societe & " and Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "'", Grd_Controles)
        With Grd_Controles
            .Columns("Bloquant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Criticité").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Message").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Reset_Form(Controle_Pnl)
    End Sub
    Private Sub Grd_Rubriques_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Rubriques.CellMouseDoubleClick
        With Grd_Rubriques
            If e.ColumnIndex = Valeur.Index And e.RowIndex >= 0 Then
                Select Case True
                    Case IsNull(.Item(Typ_Element.Index, e.RowIndex).Value, "").StartsWith("EC")
                        Appel_Zoom1("MS006", .Item(Valeur.Index, e.RowIndex), Me, "Typ_Function='EC'")
                    Case IsNull(.Item(Typ_Element.Index, e.RowIndex).Value, "").StartsWith("EV")
                        Appel_Zoom1("MS006", .Item(Valeur.Index, e.RowIndex), Me, "Typ_Function='EV'")
                    Case IsNull(.Item(Typ_Element.Index, e.RowIndex).Value, "").StartsWith("EB")
                        Appel_Zoom1("MS006", .Item(Valeur.Index, e.RowIndex), Me, "Typ_Function='EB'")
                    Case IsNull(.Item(Typ_Element.Index, e.RowIndex).Value, "").StartsWith("CS")
                        Appel_Zoom1("MS006", .Item(Valeur.Index, e.RowIndex), Me, "Typ_Function='CS'")
                    Case Else
                        Appel_Zoom1("MS006", .Item(Valeur.Index, e.RowIndex), Me)
                End Select
                Dim rubStr As String = IsNull(.Item(Valeur.Index, e.RowIndex).Value, "").Trim
                If rubStr <> "" And Not dicRub.ContainsKey(rubStr) Then
                    MajTreeView()
                    If CnExecuting("select count(*) from RH_Paie_Rubrique where id_Societe=" & Societe.id_Societe & " and Cod_Rubrique ='" & rubStr & "'").Fields(0).Value > 0 Then
                        AjouterRubrique(rubStr)
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Grd_Rubriques_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Rubriques.CellMouseClick
        If e.ColumnIndex = Edit.Index And e.RowIndex >= 0 Then
            Createrubrique(e.RowIndex, False)
            MajTreeView()
            With Grd_Rubriques
                Dim rubStr As String = IsNull(.Item(Valeur.Index, e.RowIndex).Value, "").Trim
                If rubStr <> "" Then
                    If TblFunction.Select("Cod_Function='" & rubStr & "'").Length > 0 Then
                        .Item(Valeur.Index, e.RowIndex).Value = rubStr
                        AjouterRubrique(rubStr)
                        Dim trnN As TreeNode() = Function_Trv.Nodes.Find(rubStr, True)
                        If trnN.Count > 0 Then
                            trnN(0).Checked = True
                        End If
                    End If
                End If
            End With
        End If
    End Sub
    Function cheCkSocieteAvecAgent() As Boolean
        Return (CnExecuting("select count(*) from RH_Agent where id_Societe='" & Societe.id_Societe & "'").Fields(0).Value > 0)
    End Function

    Private Sub Rafale_btn_Click(sender As Object, e As EventArgs) Handles Rafale_btn.Click
        Me.Cursor = Cursors.WaitCursor
        CreationRafale()
        Me.Cursor = Cursors.Default
    End Sub
    Sub CreationRafale()
        If Not cheCkSocieteAvecAgent() Then
            ShowMessageBox("Veuillez créer au moins un agent.", "Société vide", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ShowMessageBox("Etes-vous sûr de vouloir générer en rafale les rubriques manqauntes?", "Génération en rafale", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then Return
        With Grd_Rubriques
            For i = 0 To .RowCount - 1
                If IsNull(.Item(Valeur.Index, i).Value, "") = "" Then
                    If TblRub.Select("Rub='" & .Item(Rubrique.Index, i).Value & "' and estSysteme='false' and Typ_Element in ('EV','EC','EB','CS')").Length > 0 Then
                        'créer uniquement les rubriques non système de type EV, CS, EB, EC
                        Createrubrique(i, True)
                    End If
                End If
            Next
            MajTreeView()
            For i = 0 To .RowCount - 1
                Dim rubStr As String = IsNull(.Item(Valeur.Index, i).Value, "").Trim
                If rubStr <> "" Then
                    If TblFunction.Select("Cod_Function='" & rubStr & "'").Length > 0 Then
                        .Item(Valeur.Index, i).Value = rubStr
                        AjouterRubrique(rubStr)
                        Dim trnN As TreeNode() = Function_Trv.Nodes.Find(rubStr, True)
                        If trnN.Count > 0 Then
                            trnN(0).Checked = True
                        End If
                    End If
                End If
            Next

        End With
    End Sub
    Sub Createrubrique(rIndx As Integer, Optional Silent As Boolean = False)
        If Not cheCkSocieteAvecAgent() Then
            ShowMessageBox("Veuillez créer au moins un agent.", "Société vide", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If

        'création de l arubrique
        With Grd_Rubriques
            'si c'est une rubrique système ou un autre type d'élément de la paie exemple "function" => return
            Dim withSaving As Boolean = True
            Dim nrw As DataRow() = TblRub.Select("Rub='" & .Item(Rubrique.Index, rIndx).Value & "'")
            Dim rubStr As String = IsNull(.Item(Valeur.Index, rIndx).Value, "").Trim
            If rubStr = "" Then
                rubStr = CnExecuting("select isnull((select Top 1 Cod_Function from RH_Elements_Paie where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe & " and (Cod_Function ='" & IsNull(.Item(Rubrique.Index, rIndx).Value, "").Trim & "' or (Cod_Function like '" & IsNull(.Item(Rubrique.Index, rIndx).Value, "").Trim & "[_]___' and isnumeric(right(Cod_Function,3))=1)) order by Cod_Function),'')").Fields(0).Value
                If rubStr.Trim() <> "" Then
                    withSaving = False
                ElseIf CnExecuting("select count(*) from RH_Param_Plan_Paie where id_Societe=" & Societe.id_Societe & " and Cod_Plan_Paie!='" & Cod_Plan_Paie_Text.Text & "'").Fields(0).Value > 0 Then
                    rubStr = CnExecuting("declare @Rub nvarchar(50)
set @Rub='" & IsNull(.Item(Rubrique.Index, rIndx).Value, "") & "'
select @Rub+'_'+right('000'+convert(nvarchar(3),isnull((select convert(int,max(right(Cod_Rubrique,3))) from RH_Paie_Rubrique where id_Societe=" & Societe.id_Societe & " and Cod_Rubrique like @Rub+'[_]___' and isnumeric(right(Cod_Rubrique,3))=1),0)+1),3)
").Fields(0).Value
                Else
                    rubStr = IsNull(.Item(Rubrique.Index, rIndx).Value, "").Trim
                End If
            End If
            Dim f As New RH_Parametrage_Rubrique_Paie
            With f
                .StartPosition = FormStartPosition.CenterScreen
                .chargement()
                .Cod_Rubrique_txt.Text = rubStr
                If IsNull(Grd_Rubriques.Item(Valeur.Index, rIndx).Value, "").Trim = "" Then
                    .Cumulable_chk.Checked = IsNull(nrw(0)("Cumulable"), False)
                    .Utilise_chk.Checked = False
                    .Lib_Rubrique_txt.Text = IsNull(Grd_Rubriques.Item(Lib_Rubrique.Index, rIndx).Value, "").Replace("(*)", "").Trim()
                    .Abr_Rubrique_txt.Text = .Lib_Rubrique_txt.Text
                    .Typ_Retour.SelectedValue = "float"
                    .Nb_Decimal.Value = 2
                    .EC_Rd.Checked = (nrw(0)("Typ_Element") = "EC") Or (nrw(0)("Typ_Element") = "*")
                    .EV_Rd.Checked = (nrw(0)("Typ_Element") = "EV")
                    .EB_Rd.Checked = (nrw(0)("Typ_Element") = "EB")
                    .CS_rd.Checked = (nrw(0)("Typ_Element") = "CS")
                    .Imposable_IR_chk.Checked = IsNull(nrw(0)("Imposable_IR"), False)
                    .Imposable_CNSS_chk.Checked = IsNull(nrw(0)("Imposable_CNSS"), False)
                    .Deductible_IR_chk.Checked = IsNull(nrw(0)("Deductible_IR"), False)
                    .Deductible_CNSS_chk.Checked = IsNull(nrw(0)("Deductible_CNSS"), False)
                    .Val_Defaut_txt.Text = 0
                    If .EC_Rd.Checked Then
                        .Nb_txt.Text = IsNull(nrw(0)("Nb"), "")
                        .Tx_txt.Text = IsNull(nrw(0)("Tx"), "")
                        .Base_txt.Text = IsNull(nrw(0)("Base"), "")
                        .Relation_txt.Text = IsNull(nrw(0)("Relation"), "")
                    Else
                        .Val_Defaut_txt.Text = IsNull(nrw(0)("Val_Defaut"), 0)
                    End If
                    .Gain_rd.Checked = (nrw(0)("Gain_Retenue") = "G")
                    .Retenue_rd.Checked = (nrw(0)("Gain_Retenue") = "R")
                    .Autre_Rd.Checked = (Not .Gain_rd.Checked And Not .Retenue_rd.Checked)
                    .Typ_Rubrique_Paie.SelectedValue = IsNull(nrw(0)("Typ_Rubrique_Paie"), "A_Autres")
                    .Nature_Element_Exonere_txt.Text = IsNull(nrw(0)("Nature_Element_Exonere"), "")
                    .estMajAuto_chk.Checked = IsNull(nrw(0)("estMajAuto"), False)
                Else
                    .Cod_Rubrique_txt_Leave(Nothing, Nothing)
                End If
                Using f
                    If Silent Then
                        If withSaving Then f.Saving()  'appelle la logique directement
                        f.fermeture()
                        f.Close()
                    Else
                        newShowEcran(f, True) 'FormClosing se déclenchera normalement
                    End If
                End Using
            End With
            .Item(Valeur.Index, rIndx).Value = rubStr
        End With
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Zoom("Cod_Report", "Nom_Report", "Param_Mod_Edition", "isnull(Typ_Modele_Edition,'A')='BP'", Modele_Bulletin_txt, Me)
    End Sub
    Sub ImporterRubriquesPredefinie()
        Dim f As New Zoom_RubriquesPredefinies
        With f
            .fPlan = Me
            .ShowDialog()
        End With
    End Sub

    Private Sub HideIfNoMandatory_chk_CheckedChanged(sender As Object, e As EventArgs) Handles HideIfNoMandatory_chk.CheckedChanged

        With Grd_Rubriques
            For i = 0 To .RowCount - 1
                Dim nrw As DataRow() = TblRub.Select("Rub='" & .Item(Rubrique.Index, i).Value & "'")
                .Rows(i).Visible = (Not HideIfNoMandatory_chk.Checked Or CBool(IsNull(nrw(0)("Obligatoire"), False)))
            Next
        End With
    End Sub

    Private Sub Function_Trv_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Function_Trv.AfterSelect
        With selectedLbl
            .ForeColor = Color.Black
            .Font = New System.Drawing.Font("Century Gothic", 8.25!)
        End With
        selectedLbl = New ud_rubriqueLbl
        If e IsNot Nothing Then
            If dicRub.ContainsKey(e.Node.Name) Then
                selectedLbl = dicRub(e.Node.Name)
                With selectedLbl
                    .ForeColor = Color.Red
                    .Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Underline)
                End With
            End If
        End If
    End Sub

    Private Sub Rechercher_txt_TextChanged(sender As Object, e As EventArgs) Handles Rechercher_txt.TextChanged
        Dim txt As String = Rechercher_txt.Text.Replace("'", "''").Trim()
        With TblFunction
            For i = 0 To .Rows.Count - 1
                Dim nd() As TreeNode = Function_Trv.Nodes.Find(.Rows(i)("Cod_Function"), True)
                If nd.Length > 0 Then
                    'masquer les nodes affiché ne répondant pas à la recherche
                    If TblFunction.Select("(Cod_Function='" & nd(0).Name & "') and (Cod_Function like '%" & txt & "%' or Lib_Function like '%" & txt & "%' or Abr_Function like '%" & txt & "%') ").Length = 0 Then
                        dicMaskedNodes.Add(nd(0), nd(0).Parent)
                        nd(0).Remove()
                    End If
                Else
                    'Afficher les nodes masqués répondant à la recherche
                    Dim nrw() As DataRow = TblFunction.Select("(Cod_Function='" & .Rows(i)("Cod_Function") & "') and (Cod_Function like '%" & txt & "%' or Lib_Function like '%" & txt & "%' or Abr_Function like '%" & txt & "%') ")
                    If nrw.Length > 0 Then
                        For Each n As TreeNode In dicMaskedNodes.Keys
                            If n.Name = nrw(0)("Cod_Function") Then
                                dicMaskedNodes(n).Nodes.Add(n)
                                dicMaskedNodes.Remove(n)
                                n.EnsureVisible()
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub Function_Trv_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Function_Trv.NodeMouseClick
        e.Node.Checked = Not e.Node.Checked
    End Sub
    Private Sub pb_View_Click(sender As Object, e As EventArgs) Handles pb_View.Click
        Dim strPlan As String = ""
        For Each lb In ArrRub
            With lb
                If lb.Visibility Then strPlan &= IIf(strPlan = "", "", ", ") & " 0 as '" & lb.Text.Replace("'", "''") & "'"
            End With
        Next
        strPlan = "select top 10 Matricule,Nom_Agent+' '+Prenom_Agent as Nom " & IIf(strPlan = "", "", "," & strPlan) & " from Rh_Agent where id_Societe= " & Societe.id_Societe
        Dim f As New Zoom_Libre
        With f
            .Size = New Size(Me.Width * 0.8, 300)
            .Libre_GRD.DataSource = DATA_READER_GRD(strPlan)
            With .Libre_GRD
                .Columns("Matricule").HeaderCell.Style.BackColor = colorBase04
                .Columns("Matricule").HeaderCell.Style.ForeColor = Color.Black
                .Columns("Nom").HeaderCell.Style.BackColor = colorBase04
                .Columns("Nom").HeaderCell.Style.ForeColor = Color.Black
                .Columns("Nom").Frozen = True
            End With
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
    End Sub
    Private Sub pb_Refresh_Click(sender As Object, e As EventArgs) Handles pb_Refresh.Click
        Request()
    End Sub

#Region "Vérifier l'existence de Rubrique cumulées non incluses"
    Function simplifierFormule() As String
        Dim rub = "'" & String.Join("','", dicRub.Keys) & "'"
        ' Rubriques cumulables non intégrées au plan
        Dim rbCumul() As DataRow = TblFunction.Select("Cumulable='true' and Cod_Function not in (" & rub & ")")
        If rbCumul.Length = 0 Then Return ""
        Dim rubCumulable = IsNull(String.Join(")\b|\b(", From rw As DataRow In rbCumul Select rw("Cod_Function")), "")
        If rubCumulable = "" Then
            Return ""
        Else
            rubCumulable = "\b(" & rubCumulable & ")\b"
        End If

        ' Eléments calculés
        Dim nrw() As DataRow = TblFunction.Select("Typ_Function in ('FP','FU','EC','EX') and isnull(Formule_Function,'')<>'' and Cod_Function in (" & rub & ")")
        If nrw.Length = 0 Then Return ""
        Dim formuleCumul As String = String.Join(", ", From row As DataRow In nrw Select RemplacerFonction(row("Formule_Function"), row("Cod_Function")))

        ' 1- Vérification de l'existence de rubrique cumulable directement dans l'expression des formules
        formuleCumul = formuleCumul.Replace("Function", "").Replace("function", "").Replace("End", "").Replace("end", "").Replace("()", "")
        Dim rgCumul As New Regex(rubCumulable, RegexOptions.IgnoreCase)
        Dim mat = rgCumul.Matches(formuleCumul)
        If mat.Count > 0 Then
            Return mat(0).Value
        End If

        ' Récupération des fonctions à aplatir
        Dim rgStr As String = CnExecuting("select isnull((select '\b('+ STRING_AGG( Cod_Function ,')\b|\b(')+')\b' " &
                                          "from dbo.RH_Elements_Paie " &
                                          "where Typ_Function in ('EX','EC','FU','FP') and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe & "),'')").Fields(0).Value
        Dim rg As New Regex(rgStr, RegexOptions.IgnoreCase)

        ' 2- Vérification des rubriques cumulables dans les formules récursives
        For Each rw As DataRow In nrw
            ' 2.a) Aplatir les fonctions récursivement
            Dim expFormule = rw("Formule_Function")
            expFormule = AplatirFormule(expFormule, rg, New HashSet(Of String)())
            ' 2.b) Vérifier les rubriques cumulables dans la formule aplatie
            Dim _mat = rgCumul.Matches(expFormule) ' Correction : vérifier dans expFormule, pas formuleCumul
            If _mat.Count > 0 Then
                Return _mat(0).Value
            End If
        Next
        Return ""
    End Function

    ' Fonction récursive pour aplatir les formules
    Private Function AplatirFormule(formule As String, rg As Regex, processedFunctions As HashSet(Of String), Optional maxDepth As Integer = 100) As String
        ' Vérifier si on atteint la profondeur maximale (sécurité contre récursivité infinie)
        If maxDepth <= 0 Then
            MsgBox("Profondeur maximale atteinte, possible récursivité infinie.")
            Return formule
        End If

        ' Vérifier s'il y a des correspondances à remplacer
        If Not rg.IsMatch(formule) Then
            Return formule
        End If

        ' Parcourir toutes les correspondances
        For Each m As Match In rg.Matches(formule)
            Dim funcName As String = m.Value

            ' Vérifier les cycles
            If processedFunctions.Contains(funcName) Then
                Continue For ' Sauter si déjà traité dans cette branche pour éviter les boucles infinies
            End If
            processedFunctions.Add(funcName)

            ' Remplacer Cumul_{funcName} par rien
            formule = (New Regex($"\b(Cumul_{funcName})\b", RegexOptions.IgnoreCase)).Replace(formule, "")
            ' MsgBox($"Après suppression de Cumul_{funcName} : {formule}")

            ' Récupérer le corps de la fonction
            Dim corpsFormule = TblFunction.Select("Cod_Function='" & funcName & "'")(0)("Formule_Function").ToString()
            corpsFormule = RemplacerFonction(corpsFormule, funcName) ' Supprimer Function/End
            corpsFormule = (New Regex($"\b(Cumul_{funcName})\b", RegexOptions.IgnoreCase)).Replace(corpsFormule, "")
            ' MsgBox($"Corps après traitement : {corpsFormule}")

            ' Remplacer l'appel de la fonction par son corps
            formule = (New Regex($"\b({funcName})\b", RegexOptions.IgnoreCase)).Replace(formule, "( " & corpsFormule & " )")
            ' MsgBox($"Après remplacement de {funcName} : {formule}")

            ' Appeler récursivement pour traiter les sous-fonctions dans le corps inséré
            formule = AplatirFormule(formule, rg, processedFunctions, maxDepth - 1)
        Next

        Return formule
    End Function

    ' Fonction pour supprimer Function/End d'une définition de fonction
    Private Function RemplacerFonction(input As String, nomFonction As String) As String
        Dim nomFonctionEscaped As String = Regex.Escape(nomFonction)
        Dim pattern As String = $"Function\s+{nomFonctionEscaped}\(\)\s*(.*?)\s*End\s+Function"
        Dim rg As New Regex(pattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        Return rg.Replace(input, "$1")
    End Function
#End Region
End Class