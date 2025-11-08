Imports System.Text.RegularExpressions
Public Class RH_Functions
    Dim ModeDuplic As Boolean = False
    Friend Code As String = ""
    Dim TblTrv As DataTable = DATA_READER_GRD("select * from RH_Elements_Paie where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe)
    Dim nRows() As DataRow
    Dim TblTitre As DataTable = DATA_READER_GRD("select Valeur,Membre from Param_Rubriques where Nom_Controle='Function' order by Rang")
    Friend ModeSilent As Boolean = False
    Friend ModeSilentCalcul As Boolean = False
    Dim First_D As ud_btn
    Dim Back_D As ud_btn
    Dim Next_D As ud_btn
    Dim Last_D As ud_btn
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Dupliquer_D As ud_btn
    Dim Request_D As ud_btn
    Dim Calcul_D As ud_btn

    Private Sub Ctb_Compta_Axe_Ana_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Function_Text.Text & "'  and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)

            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Cod_Function_Text_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cod_Function_Text.Leave
        Cod_Function_Text.Text = Cod_Function_Text.Text.Trim()
        Dim rg As New Regex("[^a-zA-Z0-9_]", RegexOptions.IgnoreCase)
        If rg.IsMatch(Cod_Function_Text.Text) Then
            ShowMessageBox("Evitez les caractères spéciaux et les accents.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
            Cod_Function_Text.Select()
            Enabling(Cod_Function_Text, True)
            Return
        ElseIf Not EstCaractèreConformeVBScript(Cod_Function_Text.Text) Then
            ShowMessageBox("Evitez les caractères spéciaux et les accents.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
            Cod_Function_Text.Select()
            Enabling(Cod_Function_Text, True)
            Return
        ElseIf Cod_Function_Text.Text.ToLower.StartsWith("s_") Then
            If Not ModeSilent Then ShowMessageBox("Les fonctions commençant par 'S_' sont réservées.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
            Cod_Function_Text.Select()
            Enabling(Cod_Function_Text, True)
            Return
        ElseIf Cod_Function_Text.Text.ToLower.StartsWith("cumul_") Then
            If Not ModeSilent Then ShowMessageBox("Les fonctions commençant par 'Cumul_' sont réservées.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
            Cod_Function_Text.Select()
            Enabling(Cod_Function_Text, True)
            Return
        End If
        Dim rsl As Boolean = Request()
        Enabling(Cod_Function_Text, Not rsl)
        If Not rsl Then
            Cod_Function_Text.Select()
        End If
    End Sub
    Function Request() As Boolean
        Try
            Chargement()
            Dim TblFunction As DataTable = DATA_READER_GRD("Select * from RH_Elements_Paie where id_Societe=" & Societe.id_Societe)
            If TblFunction.Select("[cod_Function]='" & Cod_Function_Text.Text & "' and Typ_Function<>'FU'").Length > 0 Then
                ShowMessageBox("Code déjà attribué à un élément de calcul de la paie", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
                Return False
            End If
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "' and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            End If
            DroitAcces(Me, DroitModify_Fiche(Cod_Function_Text.Text, Me))
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Cod_Function_Text.Text)
                Code = Cod_Function_Text.Text
            End If
            Sql_Text.Text = ""
            Resultat.Text = ""
            TblFunction = DATA_READER_GRD("Select * from Sys_RH_Param_Functions  where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            Dim orow() As DataRow = TblFunction.Select("[cod_Function]='" & Cod_Function_Text.Text & "'")
            If orow.Length > 0 Then
                Formule_Function_Text.Text = IsNull(orow(0).Item("Formule_Function"), "")
                Lib_Function_Text.Text = IsNull(orow(0).Item("Lib_Function"), "")
                Typ_Param.SelectedValue = IsNull(orow(0).Item("Typ_Retour"), "float")
                Lib_Abr_Text.Text = IsNull(orow(0).Item("Lib_Abr"), "")
                Nb_Decimal.Value = IsNull(orow(0).Item("Nb_Decimal"), 0)
                Est_Pourcentage_chk.Checked = IsNull(orow(0).Item("Est_Pourcentage"), False)
                estSysteme_chk.Checked = IsNull(orow(0).Item("estSysteme"), False)
                Fonction_Globale_chk.Checked = IsNull(orow(0).Item("Fonction_Globale"), False) Or estSysteme_chk.Checked
                Utilise_chk.Checked = (RubriqueUtilise(Cod_Function_Text.Text, Fonction_Globale_chk.Checked) <> "" Or estSysteme_chk.Checked)
                If estSysteme_chk.Checked Then
                    estSysteme_chk.Tag = IsNull(orow(0).Item("lastVersion"), 0)
                    estSysteme_chk.Text = IsNull("Système v. " & Droite("00000" & orow(0).Item("lastVersion"), 5), "Fonction système")
                    Save_D.Enabled = False
                    Del_D.Enabled = False
                    Utilise_chk.Checked = True
                End If
            Else
                If ModeDuplic Then Return True
                Formule_Function_Text.Text = ""
                Lib_Function_Text.Text = ""
                Typ_Param.SelectedIndex = -1
                Lib_Abr_Text.Text = ""
                Nb_Decimal.Value = 0
                Est_Pourcentage_chk.Checked = False
                estSysteme_chk.Checked = False
                Fonction_Globale_chk.Checked = False
                estSysteme_chk.Checked = False
                estSysteme_chk.Tag = 0
                estSysteme_chk.Text = "Fonction système"
            End If
            Fonction_Globale_chk.Enabled = Not Utilise_chk.Checked Or Not estSysteme_chk.Checked
            Enabling(Formule_Function_Text, Save_D.Enabled)
            Return True
        Catch ex As Exception
            ErrorMsg(ex)
            Return True
        End Try
    End Function

    Sub Deleting()
        Try
            If Cod_Function_Text.Text.Trim() = "" Then Return
            If Not Save_D.Enabled Then Return
            If ShowMessageBox("Etes-vous sûr de vouloir supprimer la fonction : " & Cod_Function_Text.Text, "Confirmation de suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
            Dim Rsl As String = RubriqueUtilise(Cod_Function_Text.Text, Fonction_Globale_chk.Checked)
            If Rsl <> "" Then
                Utilise_chk.Checked = True
                ShowMessageBox(Rsl, "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            CnExecuting("delete from RH_Param_Functions where Cod_Function='" & Cod_Function_Text.Text & "'  and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            ShowMessageBox("Elément supprimé", "Suppression", MessageBoxButtons.OK, msgIcon.Information)
            Reseting()
            CnExecuting("exec Sys_RH_Rubriques_Plan " & Societe.id_Societe)
            ModeDuplic = False
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Function RubriqueUtiliseOld() As String
        Dim Tbl As DataTable = DATA_READER_GRD("select Cod_Function from RH_Param_Functions where Cod_Function='" & Cod_Function_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count = 0 Then
            Return ""
        End If
        If CnExecuting("Select count(*) from RH_Preparation_Paie_Detail where Cod_Rubrique='" & Cod_Function_Text.Text & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            Return "Fonction utilisée dans un calcul de paie précédent"
        End If
        Tbl = DATA_READER_GRD("select Cod_Function,Formule_Function from RH_Param_Functions where isnull(Formule_Function,'') like '%" & Cod_Function_Text.Text & "%' and id_Societe=" & Societe.id_Societe)
        Dim rg As New Regex("\b(" & Cod_Function_Text.Text & ")\b")
        With Tbl
            For i = 0 To .Rows.Count - 1
                If rg.IsMatch(.Rows(i)("Formule_Function")) Then
                    Return "Fonction utilisée dans la fonction de calcul de paie : " & .Rows(i)("Cod_Function")
                End If
            Next
        End With
        Tbl = DATA_READER_GRD("select Cod_Rubrique, Relation_VBS from RH_Paie_Rubrique where isnull(Relation_VBS,'') like '%" & Cod_Function_Text.Text & "%' and id_Societe=" & Societe.id_Societe)
        rg = New Regex("\b(" & Cod_Function_Text.Text & ")\b")
        With Tbl
            For i = 0 To .Rows.Count - 1
                If rg.IsMatch(.Rows(i)("Relation_VBS")) Then
                    Return "Fonction utilisée dans une relation de calcul de la rubrique : " & .Rows(i)("Cod_Rubrique")
                End If
            Next
        End With
        Tbl = DATA_READER_GRD("select Cod_Plan_Paie,Lib_Plan_Paie,isnull(Element_Paie,'') as Element_Paie from RH_Param_Plan_Paie where isnull(Element_Paie,'')<>'' and id_Societe=" & Societe.id_Societe)
        Dim EP() As String
        With Tbl
            For i = 0 To .Rows.Count - 1
                EP = .Rows(i)("Element_Paie").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                If EP.Contains(Cod_Function_Text.Text) Then
                    Return "Rubrique utilisée dans le plan de paie : " & .Rows(i)("Cod_Plan_Paie") & ", " & .Rows(i)("Lib_Plan_Paie")
                End If
            Next
        End With
        Return ""
    End Function
    Function Saving() As ArrayList
        Try
            Dim ErrStr As String = ""
            If Cod_Function_Text.Text = "" Then
                Return New ArrayList({"Le code est vide", -1})
            End If
            Dim rs As New ADODB.Recordset
            If Not EstCaractèreConformeVBScript(Cod_Function_Text.Text) Then
                Cod_Function_Text.Select()
                Return New ArrayList({"Le code contient des caractères spéciaux ou des accents", -1})
            End If
            If Lib_Function_Text.Text = "" Then
                Return New ArrayList({MessageBoxRHPText(688), -1})
            End If
            If Lib_Abr_Text.Text = "" Then
                Return New ArrayList({MessageBoxRHPText(689), -1})
            End If
            If Cod_Function_Text.Text.Contains("*") Then
                Cod_Function_Text.Select()
                Return New ArrayList({"Code fonction contient un caractère intérdit '*'", -1})
            End If
            If Lib_Function_Text.Text.Contains("*") Then
                Lib_Function_Text.Select()
                Return New ArrayList({"Intitulé fonction contient un caractère intérdit '*'", -1})
            End If
            If Lib_Abr_Text.Text.Contains("*") Then
                Lib_Abr_Text.Select()
                Return New ArrayList({"Abréviation fonction contient un caractère intérdit '*'", -1})
            End If
            If CnExecuting("select count(*) from RH_Elements_Paie where (lower(ltrim(rtrim(Cod_Function)))=lower(ltrim(rtrim('" & Cod_Function_Text.Text & "')))) " & IIf(Fonction_Globale_chk.Checked, " and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")!=" & Societe.id_Societe, " and id_Societe=-1 ")).Fields(0).Value > 0 Then
                Cod_Function_Text.Select()
                Return New ArrayList({"Code déjà utilisé par une autre rubrique globale.", -1})
            End If
            If CnExecuting("select count(*) from RH_Elements_Paie where Cod_Function!='" & Cod_Function_Text.Text & "' and   (lower(ltrim(rtrim(Lib_Function)))=lower(ltrim(rtrim('" & Lib_Function_Text.Text.Replace("'", "''") & "'))) or lower(ltrim(rtrim(Lib_Abr)))=lower(ltrim(rtrim('" & Lib_Function_Text.Text.Replace("'", "''") & "')))) and  id_Societe =-1").Fields(0).Value > 0 Then
                Lib_Function_Text.Select()
                Return New ArrayList({"Libellé déjà utilisé par une autre rubrique globale.", -1})
            End If
            If CnExecuting("select count(*) from RH_Elements_Paie where Cod_Function!='" & Cod_Function_Text.Text & "' and (lower(ltrim(rtrim(Lib_Function)))=lower(ltrim(rtrim('" & Lib_Abr_Text.Text.Replace("'", "''") & "'))) or lower(ltrim(rtrim(Lib_Abr)))=lower(ltrim(rtrim('" & Lib_Abr_Text.Text.Replace("'", "''") & "')))) and  id_Societe =-1").Fields(0).Value > 0 Then
                Lib_Abr_Text.Select()
                Return New ArrayList({"Abréviation déjà utilisée par une autre rubrique globale.", -1})
            End If
            If Typ_Param.SelectedIndex = -1 Then
                Typ_Param.DroppedDown = True
                Return New ArrayList({"Renseignez le type de retour", -1})
            End If
            Resultat.Text = RH_FunctionExec(Cod_Function_Text.Text, Formule_Function_Text.Text, Typ_Param.SelectedValue, False)
            TabControl1.SelectedTab = TabFunction
            If Resultat.Text.ToUpper.Contains("#ERR") Or Resultat.Text.ToUpper.Contains("ERREUR") Then
                Formule_Function_Text.Select()
                ErrStr = "Votre fonction contient une erreur de syntaxe mais enregistrée quand même, merci de la vérifier"
            End If
            rs.Open("select * from RH_Param_Functions where Cod_Function='" & Cod_Function_Text.Text & "' and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Dat_Crea").Value = Now
                rs("Created_By").Value = theUser.Login
                rs("Cod_Function").Value = Cod_Function_Text.Text
            Else

                rs.Update()
            End If
            rs("id_Societe").Value = IIf(Fonction_Globale_chk.Checked Or estSysteme_chk.Checked, -1, Societe.id_Societe)
            rs("Fonction_Globale").Value = Fonction_Globale_chk.Checked Or estSysteme_chk.Checked
            rs("Lib_Function").Value = Lib_Function_Text.Text
            rs("Lib_Abr").Value = Lib_Abr_Text.Text
            rs("Abr_Function").Value = Cod_Function_Text.Text
            rs("Formule_Function").Value = Formule_Function_Text.Text
            rs("Typ_Retour").Value = Typ_Param.SelectedValue
            If Typ_Param.SelectedValue.ToString.ToUpper <> "FLOAT" Then Est_Pourcentage_chk.Checked = False
            rs("Est_Pourcentage").Value = Est_Pourcentage_chk.Checked
            rs("Nb_Decimal").Value = Nb_Decimal.Value
            rs("Regex").Value = "\b(" & Cod_Function_Text.Text & ")\b"
            rs("Dat_Modif").Value = Now
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            If ErrStr <> "" Then
                Return New ArrayList({ErrStr, 0})
            Else
                Return New ArrayList({"Enregistré avec succès", 1})
            End If
            Request()
            CnExecuting("exec Sys_RH_Rubriques_Plan " & Societe.id_Societe)
        Catch ex As Exception
            Return New ArrayList({ex.Message, -1})
        End Try
        ModeDuplic = False
    End Function
    Sub Reseting()
        Reset_Form(Me)
        ModeDuplic = False
        FunctionTrvMAJ()
    End Sub
    Sub Div_First()
        If Cod_Function_Text.Text <> "" Then
            Diviseur_First("Sys_RH_Param_Functions", "Cod_Function", "Lib_Function", Cod_Function_Text)
            Request()
            ModeDuplic = False
        End If
    End Sub

    Sub Div_Back()
        If Cod_Function_Text.Text <> "" Then
            Diviseur_Back("Sys_RH_Param_Functions", "Cod_Function", "Lib_Function", Cod_Function_Text)
            Request()
            ModeDuplic = False
        End If
    End Sub

    Sub Div_Next()
        If Cod_Function_Text.Text <> "" Then
            Diviseur_Next("Sys_RH_Param_Functions", "Cod_Function", "Lib_Function", Cod_Function_Text)
            Request()
            ModeDuplic = False
        End If
    End Sub

    Sub Div_Last()
        If Cod_Function_Text.Text <> "" Then
            Diviseur_Last("Sys_RH_Param_Functions", "Cod_Function", "Lib_Function", Cod_Function_Text)
            Request()
            ModeDuplic = False
        End If
    End Sub

    Sub Nouveau()
        Reseting()
        Enabling(Cod_Function_Text, True)
        Enabling(Save_D, True)
        Enabling(Del_D, True)
        Enabling(Formule_Function_Text, True)
        Fonction_Globale_chk.Enabled = True
        TabControl1.SelectedTab = TabFunction
        Cod_Function_Text.Select()
        Request()
        ModeDuplic = False
    End Sub
    Sub Enregistrer()
        Dim rsl As ArrayList = Saving()
        If Not ModeSilent Then
            ShowMessageBox(rsl(0), "Enregistrer", MessageBoxButtons.OK, IIf(rsl(1) = 1, msgIcon.Information, IIf(rsl(1) = -1, msgIcon.Stop, msgIcon.Warning)))
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Chargement()
    End Sub
    Sub Chargement()
        Try
            If New_D Is Nothing Then
                First_D = dictButtons("First_D")
                Back_D = dictButtons("Back_D")
                Next_D = dictButtons("Next_D")
                Last_D = dictButtons("Last_D")
                New_D = dictButtons("New_D")
                Save_D = dictButtons("Save_D")
                Del_D = dictButtons("Del_D")
                Dupliquer_D = dictButtons("Dupliquer_D")
                Request_D = dictButtons("Request_D")
                Calcul_D = dictButtons("Calcul_D")
            End If
            If Typ_Param.Items.Count = 0 Then
                Typ_Param.fromRubrique()
                FunctionTrvMAJ()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub FunctionTrvMAJ()
        TabControl1.SelectedIndex = 0
        TblTrv = DATA_READER_GRD("select * from RH_Elements_Paie where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe & " order by Cod_Function")
        With TblTitre
            Function_Trv.Nodes(0).Nodes.Clear()
            Function_Trv.Nodes(1).Nodes.Clear()
            Function_Trv.Nodes(2).Nodes.Clear()
            Function_Trv.Nodes(3).Nodes.Clear()
            Function_Trv.Nodes(4).Nodes.Clear()
            Function_Trv.Nodes(5).Nodes.Clear()
            For i = 0 To .Rows.Count - 1
                Dim m As New TreeNode
                With m
                    .Name = TblTitre.Rows(i).Item("Valeur")
                    .Text = TblTitre.Rows(i).Item("Membre")
                    Function_Trv.Nodes(Gauche(.Name, 2)).Nodes.Add(m)
                    'Select Case Gauche(.Name, 2)
                    '    Case "FS"
                    '        Function_Trv.Nodes(0).Nodes.Add(m)
                    '    Case "FU"
                    '        Function_Trv.Nodes(1).Nodes.Add(m)
                    '    Case "RB"
                    '        Function_Trv.Nodes(2).Nodes.Add(m)
                    '    Case "AG"
                    '        Function_Trv.Nodes(3).Nodes.Add(m)
                    '    Case "EP"
                    '        Function_Trv.Nodes(4).Nodes.Add(m)
                    'End Select
                End With

                nRows = TblTrv.Select("[Groupe_Function]='" & TblTitre.Rows(i).Item("Valeur") & "'")
                For j = 0 To nRows.Length - 1
                    Dim n As New TreeNode
                    With n
                        .Name = nRows(j).Item("Cod_Function")
                        .ToolTipText = nRows(j).Item("Lib_Function")
                        .Text = nRows(j).Item("Cod_Function") & " : " & .ToolTipText
                        .Tag = IsNull(nRows(j).Item("Abr_Function"), nRows(j).Item("Cod_Function"))
                        .ForeColor = Color.Gray
                    End With
                    m.Nodes.Add(n)
                Next
            Next
        End With
        Function_Trv.ExpandAll()
    End Sub
    Private Sub Function_Trv_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Function_Trv.MouseMove
        Dim theNode As TreeNode = Function_Trv.GetNodeAt(e.X, e.Y)

        ' Check if mouse is paused over an actual node.
        If Not (theNode Is Nothing) Then
            ' Only update the ToolTip if tip needs to be changed.
            If (theNode.ToolTipText <> ToolTip1.GetToolTip(Function_Trv) And theNode.Tag IsNot Nothing) Then
                ToolTip1.SetToolTip(Function_Trv, theNode.ToolTipText)
            End If
        Else
            ' Mouse is not paused over a node. Therefore, clear the ToolTip.
            ToolTip1.SetToolTip(Function_Trv, "")
        End If
    End Sub
    Private Sub Function_Trv_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Function_Trv.NodeMouseDoubleClick
        If Cod_Function_Text.Text = Function_Trv.SelectedNode.Tag Then
            MessageBoxRHP(691)
            Exit Sub
        End If
        With Formule_Function_Text
            .Select()
            Dim SelPos As Integer = Formule_Function_Text.SelectionStart
            Dim ValeurNode As String = " " & Function_Trv.SelectedNode.Tag & " "
            .Text = Formule_Function_Text.Text.Insert(SelPos, ValeurNode)
            .Select()
            .SelectionStart = SelPos + ValeurNode.Length
        End With
    End Sub
    Private Sub Formule_Function_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Formule_Function_Text.TextChanged
        Sql_Text.Text = ""
        Resultat.Text = ""
        Dim oRw() As DataRow = Nothing
        Dim rg As New Regex("\b(\w+)\b", RegexOptions.IgnoreCase)
        With Formule_Function_Text
            Dim selpos As Integer = .SelectionStart
            For Each c As Match In rg.Matches(.Text)
                .Select(c.Index, c.Length)
                oRw = TblTrv.Select("[Cod_Function] = '" & c.Value & "'")
                If oRw.Length > 0 Then
                    .SelectionColor = getFunctionColor(oRw(0).Item("Typ_Function"))
                Else
                    .SelectionColor = Color.Black
                End If
            Next
            .SelectionStart = selpos
            .SelectionLength = 0
        End With
    End Sub
    Private Sub Typ_Param_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Typ_Param.DropDownClosed
        Sql_Text.Text = ""
        Resultat.Text = ""
    End Sub

    Private Sub Function__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Function_.LinkClicked
        ModeDuplic = False
        Appel_Zoom1("MS011", Cod_Function_Text, Me)
        Request()
    End Sub

    Private Sub Resultat_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Resultat.MouseDoubleClick
        Resultat.SelectAll()
    End Sub

    Private Sub Actualiser()
        Request()
    End Sub
    Sub Dupliquer()
        If Cod_Function_Text.Text.Trim = "" Then Return
        Utilise_chk.Checked = False
        If estSysteme_chk.Checked Then
            Dim rgf As New Regex("^Function\s(?<codfunction>\w+)\(\)", RegexOptions.IgnoreCase)
            If rgf.IsMatch(Formule_Function_Text.Text) Then
                For Each c As Match In rgf.Matches(Formule_Function_Text.Text)
                    If c.Groups.Count > 1 Then
                        Dim rg2 As New Regex("\b(" & c.Groups(1).Value & ")\b", RegexOptions.IgnoreCase)
                        Dim rnd As New Random()
                        Dim lt As String = Chr(rnd.Next(65, 90)) & Chr(rnd.Next(65, 90))
                        Dim orgFunction As String = rgf.Replace(Formule_Function_Text.Text, "").Trim()
                        orgFunction = rg2.Replace(orgFunction, lt)
                        orgFunction = orgFunction.Replace("End Function", "=> " & lt).Trim
                        Formule_Function_Text.Text = orgFunction
                        Exit For
                    End If
                Next
            End If
        End If
        estSysteme_chk.Checked = False
        Fonction_Globale_chk.Enabled = True
        Cod_Function_Text.Text &= "***"
        Lib_Function_Text.Text &= "***"
        Lib_Abr_Text.Text &= "***"
        Cod_Function_Text.Select()
        ModeDuplic = True
        Enabling(Cod_Function_Text, True)
        Enabling(Formule_Function_Text, True)
        Enabling(Save_D, True)
        Enabling(Del_D, True)
    End Sub
    Sub Simuler()
        If Typ_Param.SelectedIndex < 0 Then
            ShowMessageBox("Type retour non renseigné")
            Typ_Param.DroppedDown = True
            Return
        End If
        Resultat.Text = RH_FunctionExec(Cod_Function_Text.Text, Formule_Function_Text.Text, Typ_Param.SelectedValue, True)
        TabControl1.SelectedTab = TabFunction
        If Resultat.Text.ToUpper.Contains("#ERR") Or Resultat.Text.ToUpper.Contains("ERREUR") Then
            ShowMessageBox("Erreur de syntaxe, merci de vérifier", "Erreur", MessageBoxButtons.OK, msgIcon.Error)
            Formule_Function_Text.Select()
        End If
    End Sub
    Private Sub EvaluerLaValeurDeLaVariableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EvaluerLaValeurDeLaVariableToolStripMenuItem.Click
        With Function_Trv
            If .SelectedNode Is Nothing Then Return
            Dim elm As String = .SelectedNode.Name
            Dim oRw() As DataRow = TblTrv.Select("Cod_Function='" & elm & "'")
            If oRw.Length = 0 Then Return
            If IsNull(oRw(0)("Typ_Function"), "FS") = "FS" Then Return
            Dim myVBS As New vsEngine
            Dim f As New Zoom_RH_Saisie_EV
            With f
                .myVBS = myVBS
                .silentMode = Societe.LeMatricule <> ""
                If .silentMode Then
                    .Save_D_Click(Nothing, Nothing)
                Else
                    .ShowDialog()
                End If
            End With
            Try
                ShowMessageBox("La valeur de l'élément [" & .SelectedNode.Text & "] est : " & vbCrLf & myVBS.Eval(.SelectedNode.Name), "Evaluer une valeur", MessageBoxButtons.OK, msgIcon.Information)
            Catch ex As Exception
                ShowMessageBox(ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)
            End Try
        End With
    End Sub
    Private Sub Fonction_Globale_chk_Click(sender As Object, e As EventArgs) Handles Fonction_Globale_chk.Click
        If ShowMessageBox("Il s'agit de modifier une rubrique globale. Ceci risque d'impacter les autres sociétés déclarées. Voulez-vous continuer?", "Rubrique globale", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then
            Fonction_Globale_chk.Checked = Not Fonction_Globale_chk.Checked
            Return
        End If
        If CnExecuting("select count(*) from RH_Param_Plan_Paie where id_Societe!=" & Societe.id_Societe & " and ';'+Element_Paie+';' like '%;" & Cod_Function_Text.Text & ";%'").Fields(0).Value > 0 Then
            ShowMessageBox("Vous ne pouvez pas changer cet élément car utilisé dans d'autres plans.", "Plans utilisés", MessageBoxButtons.OK, msgIcon.Error)
            Fonction_Globale_chk.Checked = Not Fonction_Globale_chk.Checked
            Return
        End If
    End Sub
    Private Sub Cod_Function_Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cod_Function_Text.KeyPress
        If Not e.KeyChar = Chr(Keys.Back) Then
            Dim rg As New Regex("[^a-zA-Z0-9_]", RegexOptions.IgnoreCase)
            e.Handled = rg.IsMatch(e.KeyChar)
        End If
    End Sub
    Function RH_FunctionExec(functionName As String, strFunction As String, TypRetour As String, NouveauMatricule As Boolean) As Object
        Dim oRsl As Object
        'Extraire la variable résultat qu' on souhaite connaître
        Dim Rs As New Regex("\s*(return|=>)\s*", RegexOptions.IgnoreCase)
        Dim mac As MatchCollection = Rs.Matches(strFunction)
        If mac.Count = 0 Then
            oRsl = "#Err : La fonction ne retourne par de résultat, le résultat retourné doit commencé en dernière ligne par ""Return"" ou le symbole '=>'."
            Return oRsl
            Exit Function
        Else
            Dim Rs0 As New Regex("(?<=\b(return)|(=>))\W*\b.+", RegexOptions.IgnoreCase)
            mac = Rs0.Matches(strFunction)
            strFunction = Rs0.Replace(strFunction, " SiNull(" & mac(0).Value & ";" & GetValeurParDefaut(TypRetour) & " )")
            Rs0 = New Regex("return|=>", RegexOptions.IgnoreCase)
            strFunction = Rs0.Replace(strFunction, functionName & " = ").Trim
        End If
        strFunction = "Function " & functionName & "()" & vbCrLf & strFunction & vbCrLf & "End Function" & vbCrLf
        strFunction = TraitementCaractere(strFunction)
        Dim myVBS As New vsEngine
        myVBS.ExecuteStatement(strFunction)
        If Societe.LeMatricule = "" Or NouveauMatricule Then
            Dim f As New Zoom_RH_Saisie_EV
            With f
                .myVBS = myVBS
                .ShowDialog()
            End With
        End If
        Dim Rslt As Object = Nothing
        Try
            Rslt = myVBS.Eval(functionName & "()")
            Return Rslt
        Catch ex As Exception
            Return "#ERR " & functionName & vbCrLf & ex.Message
        End Try
        Return Rslt
    End Function
    Dim dicMaskedNodes As New Dictionary(Of TreeNode, TreeNode)
    Private Sub Rechercher_txt_TextChanged(sender As Object, e As EventArgs) Handles Rechercher_txt.TextChanged
        Dim txt As String = Rechercher_txt.Text.Replace("'", "''").Trim()
        Function_Trv.ExpandAll()
        With TblTrv
            For i = 0 To .Rows.Count - 1
                Dim nd() As TreeNode = Function_Trv.Nodes.Find(.Rows(i)("Cod_Function"), True)
                If nd.Length > 0 Then
                    'masquer les nodes affiché ne répondant pas à la recherche
                    If TblTrv.Select("(Cod_Function='" & nd(0).Name & "') and (Cod_Function like '%" & txt & "%' or Lib_Function like '%" & txt & "%' or Abr_Function like '%" & txt & "%') ").Length = 0 Then
                        dicMaskedNodes.Add(nd(0), nd(0).Parent)
                        nd(0).Remove()
                    End If
                Else
                    'Afficher les nodes masqués répondant à la recherche
                    Dim nrw() As DataRow = TblTrv.Select("(Cod_Function='" & .Rows(i)("Cod_Function") & "') and (Cod_Function like '%" & txt & "%' or Lib_Function like '%" & txt & "%' or Abr_Function like '%" & txt & "%') ")
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

    Private Sub Lib_Function_Text_Leave(sender As Object, e As EventArgs) Handles Lib_Function_Text.Leave
        If Not Lib_Function_Text.Text.Contains("**") Then
            If Lib_Abr_Text.Text.Contains("**") Then Lib_Abr_Text.Text = Lib_Function_Text.Text
        End If
    End Sub


End Class