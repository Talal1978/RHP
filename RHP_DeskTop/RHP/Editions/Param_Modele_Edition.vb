Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Param_Modele_Edition
    Friend Code As String = ""
    Dim modeDupli As Boolean = False
    Private Sub Admin_TreeView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Typ_Critere.Items.Count = 0 Then Combo_GRD(Typ_Critere)
        If Fonction_Critere.Items.Count = 0 Then Combo_GRD(Fonction_Critere)
        If Typ_Modele_Edition_cbo.Items.Count = 0 Then Typ_Modele_Edition_cbo.fromRubrique("Typ_Modele_Edition")
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
        With Criteres_Grd

            .ContextMenuStrip = menu_context_copy
        End With
    End Sub

    Sub Request()
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
        DroitAcces(Me, DroitModify_Fiche(Cod_Report_Text.Text, Me))
        Enabling(Cod_Report_Text, False)
        If dictButtons("Save_D").Enabled = True Then
            Check_Accessible(Me.Name, Cod_Report_Text.Text)
            Code = Cod_Report_Text.Text
        End If

        If Cod_Report_Text.Text.Trim <> "" Then
            Dim Rpt As String = FindParam("Lecteur_Digital_Mod_Edition") & "\" & Cod_Report_Text.Text & ".rpt"
            If IO.File.Exists(Rpt) = False Then
                ReportExists_Label.Visible = True
            Else
                ReportExists_Label.Visible = False
            End If
        End If
        If modeDupli Then
            modeDupli = False
            Exit Sub
        End If
        Nom_Report_Text.Text = FindLibelle("Nom_Report", "Cod_Report", Cod_Report_Text.Text, "Param_Mod_Edition")
        withPassword_chk.Checked = FindLibelle("withPassword", "Cod_Report", Cod_Report_Text.Text, "Param_Mod_Edition")
        parSociete_chk.Checked = FindLibelle("parSociete", "Cod_Report", Cod_Report_Text.Text, "Param_Mod_Edition")
        Portail_chk.Checked = FindLibelle("Portail", "Cod_Report", Cod_Report_Text.Text, "Param_Mod_Edition")
        Typ_Modele_Edition_cbo.SelectedValue = FindLibelle("Typ_Modele_Edition", "Cod_Report", Cod_Report_Text.Text, "Param_Mod_Edition")
        Dim Cod_Sql = "Select  * From Param_Mod_Edition_Criteres where Cod_Report='" & Cod_Report_Text.Text & "'"
        Dim Tbl = DATA_READER_GRD(Cod_Sql)
        If Tbl.Rows.Count = 0 And Cod_Report_Text.Text <> "" Then
            ChargerLesParametres()
            Return
        End If
        Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 As Object
        Criteres_Grd.Rows.Clear()
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
                Criteres_Grd.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C10, C9)
            Next
        End With
        Cod_Sql = "select convert(bit,case when ';'+isnull(Mod_Edition,'')+';' like '%;'+'" & IIf(Cod_Report_Text.Text = "", "12cTvo___8421rtvn", Cod_Report_Text.Text) & "'+';%' then 'true' else 'false' end) as _chek,id_Societe, Den as 'Société' from Param_Societe order by Den"
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Grd_Soc
            .DataSource = Tbl
            .Columns("_chek").HeaderText = "+"
            .Columns("id_Societe").Visible = False
            Tbl.Columns("_chek").ReadOnly = False
        End With
    End Sub
    Sub DelRow(ByVal sender, ByVal e)
        With Criteres_Grd
            For Each c As DataGridViewRow In .SelectedRows
                If Not c.IsNewRow Then .Rows.Remove(c)
            Next
        End With
    End Sub
    Sub Deleting()
        If Cod_Report_Text.Text = "" Then Exit Sub
        If MessageBoxRHP(552, Nom_Report_Text.Text) = MsgBoxResult.Cancel Then Exit Sub



        'Supprimer le Modèle ou le Report
        If CnExecuting("Select count(*) from Param_Mod_Edition where Cod_Report='" & Cod_Report_Text.Text & "'").Fields(0).Value > 0 Then
            CnExecuting("delete from Param_Mod_Edition where Cod_Report='" & Cod_Report_Text.Text & "'")
        End If

        'Supprimer le lien du Report

        CnExecuting("delete from Controle_TreeView where Name_Ecran='" & Cod_Report_Text.Text & "' and Typ_Ecran='RPT'")
        CnExecuting("delete from Controle_Menu where Name_Ecran='" & Cod_Report_Text.Text & "'")
        'Supprimer le lien des favoris
        CnExecuting("delete from Param_Favoris where Form_Name='" & Cod_Report_Text.Text & "'")
        Reset_Form(Me)
    End Sub

    Private Sub Initialisation()
        Reset_Form(Me)
        ReportExists_Label.Visible = False
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If Nom_Report_Text.Text = "************" Then Nom_Report_Text.Text = ""
        Appel_Zoom("Cod_Report", "Nom_Report", "Param_Mod_Edition", "1=1", Cod_Report_Text, Me)
    End Sub

    Private Sub Name_Ecran_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Report_Text.TextChanged
        If Not Cod_Report_Text.ReadOnly Then Return
        Request()
    End Sub
    Private Function checkBulletin(codReport As String) As savingResult
        Dim Rpt As String = FindParam("Lecteur_Digital_Mod_Edition") & "\" & codReport & ".rpt"
        If IO.File.Exists(Rpt) = False Then
            Return New savingResult With {.result = False, .message = "Le modèle de bulletin de paie choisi n'existe pas."}
        End If
        Dim paramBP() As String = "idSoc;CodPlan;MatDeb;MatFin;DatDeb;DatFin;CodPreparation".Split(";")
        For i = 0 To paramBP.Length - 1
            Dim existe As Boolean = False
            With Criteres_Grd
                For j = 0 To .Rows.Count - 2
                    If IsNull(.Item(Critere.Index, j).Value, "").ToLower() = paramBP(i).ToLower() Then
                        existe = True
                        Exit For
                    End If
                Next
            End With
            If Not existe Then
                Return New savingResult With {.result = False, .message = "Un modèle d'édition de type 'bulletin de paie' doit obligatoirement contenir les critères suivants :" & vbCrLf & "  idSoc, CodPlan, MatDeb, MatFin, DatDeb, DatFin, CodPreparation" & vbCrLf & "Manque : " & paramBP(i)}
            End If
        Next
        Return New savingResult With {.result = True, .message = ""}
    End Function
    Function Saving() As savingResult
        If Cod_Report_Text.Text = "" Then Return New savingResult With {.result = False, .message = "Code vide."}
        If Cod_Report_Text.Text.Contains("'") = True Or
Cod_Report_Text.Text.Contains(",") = True Or
Cod_Report_Text.Text.Contains("&") = True Then

            Return New savingResult With {.result = False, .message = MessageBoxRHPText(51)}
        End If

        If Criteres_Grd.RowCount > 10 Then
            Return New savingResult With {.result = False, .message = MessageBoxRHPText(52, "10")}
        End If
        If Nom_Report_Text.Text = "" Then
            Return New savingResult With {.result = False, .message = MessageBoxRHPText(573)}
        End If
        If Typ_Modele_Edition_cbo.SelectedIndex = -1 Then
            Typ_Modele_Edition_cbo.SelectedValue = "A"
        End If
        If Typ_Modele_Edition_cbo.SelectedValue = "BP" Then
            Dim rsl As savingResult = checkBulletin(Cod_Report_Text.Text)
            If Not rsl.result Then Return rsl
        Else
            If ReportExists_Label.Visible = True Then
                Return New savingResult With {.result = False, .message = MessageBoxRHPText(572, FindParam("Lecteur_Digital_Mod_Edition"))}
            End If
        End If
        If Not parSociete_chk.Checked Then
            Dim Tbl As DataTable = Grd_Soc.DataSource
            If Tbl IsNot Nothing Then
                If Tbl.Columns.Contains("_chek") Then
                    parSociete_chk.Checked = (Tbl.Select("_chek='true'").Length > 0)
                End If
            End If
        End If
        Dim TypPie As String = ""
        If TypPie <> "" Then TypPie = Microsoft.VisualBasic.Left(TypPie, TypPie.Length - 1)
        If CnExecuting("Select count(*) from Controle_Menu where Name_Ecran='" & Cod_Report_Text.Text & "' and Typ_Ecran!='RPT'").Fields(0).Value > 0 Then
            Return New savingResult With {.result = False, .message = "Ce nom est déjà utilisé par un autre objet."}
        End If
        Dim rs, rs1, rs2 As New ADODB.Recordset
        'Insertion du modèle d'édition dans Param_Mod_Edition
        rs.Open("Select * from Param_Mod_Edition where Cod_Report='" & Cod_Report_Text.Text & "'", cn, 2, 2)
        If Not rs.EOF Then
            rs.Update()
        Else
            rs.AddNew()
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = CnExecuting("Select getdate()").Fields(0).Value
        End If
        rs("Cod_Report").Value = Cod_Report_Text.Text
        rs("Nom_Report").Value = Nom_Report_Text.Text
        rs("Typ_Pie").Value = TypPie
        rs("parSociete").Value = parSociete_chk.Checked
        rs("Portail").Value = Portail_chk.Checked
        rs("withPassword").Value = withPassword_chk.Checked
        rs("Typ_Modele_Edition").Value = Typ_Modele_Edition_cbo.SelectedValue
        rs("Modified_By").Value = theUser.Login
        rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
        rs.Update()
        rs.Close()
        'par société
        Dim ModEdition As String = ""
        With Grd_Soc
            For i = 0 To .RowCount - 1
                ModEdition = FindLibelle("Mod_Edition", "id_Societe", IsNull(.Item("id_Societe", i).Value, "-1"), "Param_Societe")
                If Not ModEdition.StartsWith(";") Then ModEdition = ";" & ModEdition
                If Not ModEdition.EndsWith(";") Then ModEdition = ModEdition & ";"
                If IsNull(.Item("_chek", i).Value, False) Then
                    If Not ModEdition.Contains(";" & Cod_Report_Text.Text & ";") Then
                        ModEdition &= ";" & Cod_Report_Text.Text & ";"
                    End If
                Else
                    ModEdition = ModEdition.Replace(";" & Cod_Report_Text.Text & ";", "")
                End If
                CnExecuting("update Param_Societe set Mod_Edition='" & ModEdition & "' where id_Societe=" & IsNull(.Item("id_Societe", i).Value, "-1"))
            Next
        End With

        'Insertion du modèle d'édition dans la table génératrice du treeview

        If CnExecuting("Select count(*) from Controle_TreeView where Name_Ecran='" & Cod_Report_Text.Text & "'").Fields(0).Value > 0 Then
            rs1.Open("Select * from Controle_TreeView where Name_Ecran='" & Cod_Report_Text.Text & "'", cn, 2, 2)
            rs1.Update()
        Else
            rs1.Open("Select * from Controle_TreeView", cn, 2, 2)
            rs1.AddNew()
        End If
        rs1("Name_Ecran").Value = Cod_Report_Text.Text
        rs1("Text_Ecran").Value = Nom_Report_Text.Text
        rs1("Typ_Ecran").Value = "RPT"
        rs1.Update()
        rs1.Close()

        'Insertion  dans la table Menu et Menu_Droit

        If CnExecuting("Select count(*) from Controle_Menu where Name_Ecran='" & Cod_Report_Text.Text & "'").Fields(0).Value > 0 Then
            rs1.Open("Select * from Controle_Menu where Name_Ecran='" & Cod_Report_Text.Text & "'", cn, 2, 2)
            rs1.Update()
        Else
            rs1.Open("Select * from Controle_Menu", cn, 2, 2)
            rs1.AddNew()
        End If
        rs1("Name_Ecran").Value = Cod_Report_Text.Text
        rs1("Text_Ecran").Value = Nom_Report_Text.Text
        rs1("Typ_Ecran").Value = "RPT"
        rs1.Update()
        rs1.Close()
        With Criteres_Grd
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
                CnExecuting("Delete from Param_Mod_Edition_Criteres where Cod_Report='" & Cod_Report_Text.Text & "' and Critere not in (" & Cod_Sql & ")")
            Else
                CnExecuting("Delete from Param_Mod_Edition_Criteres where Cod_Report='" & Cod_Report_Text.Text & "'")
            End If
            For i = 0 To .RowCount - 1
                If Not .Item(0, i).Value Is Nothing Then
                    If CnExecuting("Select count(*) from Param_Mod_Edition_Criteres where Cod_Report='" & Cod_Report_Text.Text & "' and Critere ='" & .Item(0, i).Value & "'").Fields(0).Value = 0 Then
                        rs1.Open("select * from Param_Mod_Edition_Criteres", cn, 2, 2)
                        rs1.AddNew()
                    Else
                        rs1.Open("select * from Param_Mod_Edition_Criteres where Cod_Report='" & Cod_Report_Text.Text & "' and Critere ='" & .Item(0, i).Value & "'", cn, 2, 2)
                        rs1.Update()
                    End If

                    rs1("Cod_Report").Value = Cod_Report_Text.Text
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
                        rs1("Table_Critere").Value = .Item(4, i).Value
                        rs1("Champs_01").Value = ""
                        rs1("Champs_02").Value = ""
                        rs1("Condition").Value = .Item(7, i).Value
                    End If
                    rs1("Default_Value").Value = .Item("Default_Value", i).Value
                    rs1("Rang").Value = IIf(IsNull(.Item("Rang", i).Value, "") <> "", .Item("Rang", i).Value, Droite("0000" & (i + 1), 4))
                    rs1.Update()
                    rs1.Close()
                End If
            Next
        End With
        Return New savingResult With {.result = True, .message = "Enregistré avec succès."}
    End Function
    Private Sub Modele_Edition_GRD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Criteres_Grd.KeyUp
        With Criteres_Grd
            If e.KeyData = Keys.F6 Then
                If .CurrentCell.ColumnIndex = 4 And .Item(Fonction_Critere.Index, .CurrentRow.Index).Value = "Menu Local" Then
                    Appel_Zoom("Name", "Name", "sysobjects", "xtype='U' order by Name ", .CurrentCell, Me)
                ElseIf .CurrentCell.ColumnIndex = 4 And .Item(Fonction_Critere.Index, .CurrentRow.Index).Value = "Combo" Then
                    Appel_Zoom("Nom_Controle", "Texte_Rubrique", "(SELECT DISTINCT Nom_Controle, Texte_Rubrique FROM Param_Rubriques) f", "1=1", .CurrentCell, Me)
                End If

                If .CurrentCell.ColumnIndex = 5 Or .CurrentCell.ColumnIndex = 6 Then
                    Appel_Zoom("Name", "Name", "sysColumns", "id in (select id from sysobjects where name='" & .Item(4, .CurrentRow.Index).Value & "') order by Name", .CurrentCell, Me)
                End If

            End If
        End With

    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        Enabling(Cod_Report_Text, True)
        Cod_Report_Text.Select()
    End Sub

    Sub ChargerLesParametres()
        If Cod_Report_Text.Text.Trim = "" Then Exit Sub

        If ReportExists_Label.Visible = True Then
            MessageBoxRHP(572, FindParam("Lecteur_Digital_Mod_Edition"))
            Exit Sub
        End If

        Dim cryRpt As New ReportDocument
        Dim oReport As String = FindParam("Lecteur_Digital_Mod_Edition") & "\" & Cod_Report_Text.Text & ".rpt"
        cryRpt.Load(oReport)

        Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 As Object
        Criteres_Grd.Rows.Clear()
        Dim R As Integer = 1
        For Each c As ParameterField In cryRpt.ParameterFields

            C1 = c.Name
            C2 = ""
            C3 = ""
            C4 = ""
            C5 = ""
            C6 = ""
            C7 = ""
            C8 = ""
            C10 = ""
            C9 = R
            Criteres_Grd.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C10, C9)
            R += 1
        Next
        cryRpt.Close()
    End Sub

    Sub Duplication()
        Enabling(Cod_Report_Text, True)
        modeDupli = True
        Cod_Report_Text.SelectAll()
    End Sub

    Sub Printing()
        If Cod_Report_Text.Text = "" Then Exit Sub
        openLink(Cod_Report_Text.Text, Nom_Report_Text.Text, "RPT")

    End Sub
    Sub Enregistrer()
        Dim rsl As savingResult = Saving()
        If IsNull(rsl.message, "") <> "" Then
            ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
        End If
    End Sub
    Private Sub Param_Modele_Edition_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
    End Sub

    Private Sub Grd_Soc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Soc.CellClick
        If e.ColumnIndex < 0 Then Return
        If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
            Grd_Soc.Item("_chek", e.RowIndex).Value = Not CBool(Grd_Soc.Item("_chek", e.RowIndex).Value)
        ElseIf e.ColumnIndex = 0 And e.RowIndex < 0 Then
            With Grd_Soc
                For i = 0 To .RowCount - 1
                    Grd_Soc.Item("_chek", i).Value = Not CBool(Grd_Soc.Item("_chek", i).Value)
                Next
            End With
        End If
    End Sub
    Private Sub Grd_Soc_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Soc.CellMouseMove
        If e.ColumnIndex = 0 And e.RowIndex < 0 Then
            Grd_Soc.Cursor = Cursors.Hand
        Else
            Grd_Soc.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Modele_Edition_GRD_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Criteres_Grd.RowsAdded
        With Criteres_Grd
            .Rows(e.RowIndex).Visible = Not (IsNull(.Item(Critere.Index, e.RowIndex).Value, "").ToUpper.Trim = "IDSOC" Or IsNull(.Item(Critere.Index, e.RowIndex).Value, "").ToUpper.Trim = "@IDSOC")
        End With
    End Sub
    Private Sub Cod_Report_Text_Leave(sender As Object, e As EventArgs) Handles Cod_Report_Text.Leave
        If Not Cod_Report_Text.ReadOnly Then Request()
    End Sub
End Class