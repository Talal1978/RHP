Imports System.Text.RegularExpressions
Public Class RH_Parametrage_Rubrique_Paie
    Dim myVBS As New vsEngine
    Friend Code As String = ""
    Friend ModeSilent As Boolean = False
    Friend ModeSilentCalcul As Boolean = False
    Dim ModeCrea As Boolean = False
    Dim ModeDuplic As Boolean = False
    Dim First_D As ud_btn
    Dim Back_D As ud_btn
    Dim Next_D As ud_btn
    Dim Last_D As ud_btn
    Dim New_D As ud_btn
    Friend Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Dupliquer_D As ud_btn
    Dim Request_D As ud_btn
    Dim Calcul_D As ud_btn
    Dim Optional_D As ud_btn

    Sub Cod_Rubrique_txt_Leave(sender As Object, e As EventArgs) Handles Cod_Rubrique_txt.Leave
        ModeCrea = Not Cod_Rubrique_txt.ReadOnly
        Cod_Rubrique_txt.Text = Cod_Rubrique_txt.Text.Trim()
        If Cod_Rubrique_txt.Text <> "" Then
            Dim rg As New Regex("[^a-zA-Z0-9_]", RegexOptions.IgnoreCase)
            Dim rg1 As New Regex("^[a-zA-Z]")
            If rg.IsMatch(Cod_Rubrique_txt.Text) Then
                ShowMessageBox("Evitez les caractères spéciaux et les accents.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
                Cod_Rubrique_txt.Select()
            ElseIf Not EstCaractèreConformeVBScript(Cod_Rubrique_txt.Text) Then
                If Not ModeSilent Then ShowMessageBox("Evitez les caractères spéciaux et les accents.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
                Cod_Rubrique_txt.Select()
            ElseIf Cod_Rubrique_txt.Text.ToLower.StartsWith("s_") Then
                If Not ModeSilent Then ShowMessageBox("Les rubriques commençant par 'S_' sont réservées.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
                Cod_Rubrique_txt.Select()
            ElseIf Cod_Rubrique_txt.Text.ToLower.StartsWith("v_") Then
                If Not ModeSilent Then ShowMessageBox("Les rubriques commençant par 'V_' sont réservées.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
                Cod_Rubrique_txt.Select()
            ElseIf Not rg1.IsMatch(Cod_Rubrique_txt.Text) Then
                If Not ModeSilent Then ShowMessageBox("Les rubriques doivent commencer par des lettres de A-Z.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
                Cod_Rubrique_txt.Select()
            ElseIf Cod_Rubrique_txt.Text.ToLower.StartsWith("cumul_") Then
                If Not ModeSilent Then ShowMessageBox("Les rubriques commençant par 'Cumul_' sont réservées.", "Vérification code", MessageBoxButtons.OK, msgIcon.Error)
                Cod_Rubrique_txt.Select()
            End If
        End If
        Dim rsl As Boolean = Request()
        Enabling(Cod_Rubrique_txt, Not rsl)
        If Not rsl Then
            Cod_Rubrique_txt.Select()
        End If
    End Sub

    Function Request() As Boolean
        Try
            Enabling(Del_D, True)
            Grp2.Enabled = True
            EnablingGrp3(True)
            Typ_Retour.Enabled = True
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "' and isnull(id_Societe,-1)=" & Societe.id_Societe)
            End If
            DroitAcces(Me, DroitModify_Fiche(Cod_Rubrique_txt.Text, Me))
            chargement()
            Dim Tbl As DataTable = DATA_READER_GRD("Select * from RH_Paie_Rubrique where Cod_Rubrique='" & Cod_Rubrique_txt.Text & "' and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            If Tbl.Rows.Count = 0 Then
                If CnExecuting("Select count(*) from RH_Elements_Paie where Cod_Function='" & Cod_Rubrique_txt.Text & "' and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe).Fields(0).Value > 0 Then
                    ShowMessageBox("Code déjà attribué à un élément de calcul de la paie", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
                    Return False
                End If
            Else
                ModeDuplic = False
            End If
            If ModeDuplic Then Return True
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Cod_Rubrique_txt.Text)
                Code = Cod_Rubrique_txt.Text
            End If
            If Tbl.Rows.Count > 0 Then
                With Tbl
                    Lib_Rubrique_txt.Text = IsNull(.Rows(0)("Lib_Rubrique"), "")
                    Abr_Rubrique_txt.Text = IsNull(.Rows(0)("Abr_Rubrique"), "")
                    EC_Rd.Checked = IsNull(.Rows(0)("EC"), False)
                    EB_Rd.Checked = IsNull(.Rows(0)("EB"), False)
                    EX_Rd.Checked = IsNull(.Rows(0)("EX"), False)
                    EV_Rd.Checked = IsNull(.Rows(0)("EV"), False)
                    CS_rd.Checked = IsNull(.Rows(0)("CS"), False)
                    Cumulable_chk.Checked = IsNull(.Rows(0)("Cumulable"), False)
                    Nb_txt.Text = IsNull(.Rows(0)("Nb"), "")
                    Base_txt.Text = IsNull(.Rows(0)("Base"), "")
                    Tx_txt.Text = IsNull(.Rows(0)("Tx"), "")
                    Relation_txt.Text = IsNull(.Rows(0)("Relation"), "")
                    Retenue_rd.Checked = (IsNull(.Rows(0)("Gain_Retenue"), "A") = "R")
                    Gain_rd.Checked = (IsNull(.Rows(0)("Gain_Retenue"), "A") = "G")
                    Autre_Rd.Checked = (IsNull(.Rows(0)("Gain_Retenue"), "A") = "A")
                    Salarial_rd.Checked = IsNull(.Rows(0)("Salarial"), False)
                    Patronal_rd.Checked = IsNull(.Rows(0)("Patronal"), False)
                    Cpt_Debit_txt.Text = IsNull(.Rows(0)("Cpt_Debit"), "")
                    Cpt_Credit_txt.Text = IsNull(.Rows(0)("Cpt_Credit"), "")
                    Ventilable_chk.Checked = IsNull(.Rows(0)("Ventilable"), False)
                    Typ_Retour.SelectedValue = IsNull(.Rows(0)("Typ_Retour"), "")
                    Nature_Element_Exonere_txt.Text = IsNull(.Rows(0)("Nature_Element_Exonere"), "")
                    Nb_Decimal.Value = IsNull(.Rows(0)("Nb_Decimal"), 0)
                    Typ_Rubrique_Paie.SelectedValue = IsNull(.Rows(0)("Typ_Rubrique_Paie"), "")
                    Val_Defaut_txt.Text = ParDefaut(IsNull(.Rows(0)("Val_Defaut"), ""), Typ_Retour.SelectedValue)
                    Est_Pourcentage_chk.Checked = IsNull(.Rows(0).Item("Est_Pourcentage"), False)
                    Imposable_IR_chk.Checked = IsNull(.Rows(0).Item("Imposable_IR"), False)
                    Imposable_CNSS_chk.Checked = IsNull(.Rows(0).Item("Imposable_CNSS"), False)
                    Deductible_IR_chk.Checked = IsNull(.Rows(0).Item("Deductible_IR"), False)
                    Deductible_CNSS_chk.Checked = IsNull(.Rows(0).Item("Deductible_CNSS"), False)
                    estSysteme_chk.Checked = IsNull(.Rows(0).Item("estSysteme"), False)
                    estMajAuto_chk.Checked = IsNull(.Rows(0).Item("estMajAuto"), False)
                    Ud_Proteger.Checked = IsNull(.Rows(0).Item("Proteger"), False)
                    Rubrique_Globale_chk.Checked = IsNull(.Rows(0).Item("Rubrique_Globale"), False) Or estSysteme_chk.Checked
                    Utilise_chk.Checked = (RubriqueUtilise(Cod_Rubrique_txt.Text, Rubrique_Globale_chk.Checked) <> "")
                    If estSysteme_chk.Checked And Not Ud_Proteger.Checked Then
                        estSysteme_chk.Tag = IsNull(.Rows(0).Item("lastVersion"), 0)
                        estSysteme_chk.Text = IsNull("Système v. " & Droite("00000" & .Rows(0).Item("lastVersion"), 5), "Rubrique système")
                        Grp2.Enabled = False
                        EnablingGrp3(False)
                        Typ_Retour.Enabled = False
                        Del_D.Enabled = False
                        Utilise_chk.Checked = True
                    End If
                    Dim comment As String = IsNull(.Rows(0).Item("Commentaire"), "")
                    If comment.StartsWith("{\rtf1\ansi") Then
                        Commentaire.rtb.Rtf = comment
                    Else
                        Commentaire.rtb.Text = comment
                    End If
                    Dim StrCouleur As String = IsNull(.Rows(0)("Couleur"), "")
                    If StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Length = 3 Then
                        If IsNumeric(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(0)) And IsNumeric(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(1)) And IsNumeric(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(2)) Then
                            lblColor.BackColor = Color.FromArgb(CInt(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(0)), CInt(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(1)), CInt(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(2)))
                        Else
                            lblColor.BackColor = Nothing
                        End If
                    Else
                        lblColor.BackColor = Nothing
                    End If
                End With
                If estMajAuto(Cod_Rubrique_txt.Text) Then
                    msg_lbl.Visible = True
                    estMajAuto_chk.Visible = True
                Else
                    msg_lbl.Visible = False
                    estMajAuto_chk.Visible = False
                End If
            Else
                estMajAuto_chk.Checked = False
                Rubrique_Globale_chk.Checked = False
                Lib_Rubrique_txt.Text = ""
                Abr_Rubrique_txt.Text = ""
                Nb_txt.Text = ""
                Base_txt.Text = ""
                Tx_txt.Text = ""
                Relation_txt.Text = ""
                Retenue_rd.Checked = False
                Gain_rd.Checked = False
                Salarial_rd.Checked = False
                Patronal_rd.Checked = False
                Cpt_Debit_txt.Text = ""
                Cpt_Credit_txt.Text = ""
                Ventilable_chk.Checked = False
                Typ_Retour.SelectedIndex = -1
                Nature_Element_Exonere_txt.Text = ""
                Nb_Decimal.Value = 0
                Typ_Rubrique_Paie.SelectedIndex = -1
                Utilise_chk.Checked = False
                EC_Rd.Checked = False
                EB_Rd.Checked = False
                EX_Rd.Checked = False
                EV_Rd.Checked = True
                CS_rd.Checked = False
                Val_Defaut_txt.Text = ""
                Est_Pourcentage_chk.Checked = False
                Commentaire.rtb.Text = ""
                lblColor.BackColor = Nothing
                Imposable_IR_chk.Checked = False
                Imposable_CNSS_chk.Checked = False
                Deductible_IR_chk.Checked = False
                Deductible_CNSS_chk.Checked = False
                estSysteme_chk.Checked = False
                estSysteme_chk.Tag = 0
                estSysteme_chk.Text = "Rubrique système"
            End If
            If Typ_Rubrique_Paie.SelectedValue = "G_PrimeExo" Or Typ_Rubrique_Paie.SelectedValue = "G_IndExo" Then
                NatureElementExonere.Enabled = True
            Else
                NatureElementExonere.Enabled = False
                Nature_Element_Exonere_txt.Text = ""
            End If
            Enabling(Val_Defaut_txt, (EV_Rd.Checked Or CS_rd.Checked))
            showElementCalcul()
            EB_Rd.Enabled = Not Utilise_chk.Checked
            EC_Rd.Enabled = Not Utilise_chk.Checked
            EV_Rd.Enabled = Not Utilise_chk.Checked
            CS_rd.Enabled = Not Utilise_chk.Checked
            EX_Rd.Enabled = Not Utilise_chk.Checked
            Pnl_Categorie.Enabled = Not Utilise_chk.Checked
            Rubrique_Globale_chk.Enabled = Not Utilise_chk.Checked Or Not estSysteme_chk.Checked
            Cumulable_chk.Enabled = Not Utilise_chk.Checked
            If Utilise_chk.Checked Then
                Enabling(Del_D, False)
            End If
            detail_4_btn.Enabled = Not estMajAuto_chk.Checked And Not estSysteme_chk.Checked
            formule_4_btn.Enabled = Not estMajAuto_chk.Checked And Not estSysteme_chk.Checked
            Return True
        Catch ex As Exception
            ErrorMsg(ex)
            Return False
        End Try

    End Function

    Private Sub RH_Parametrage_Rubrique_Paie_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        fermeture()
    End Sub
    Function fermeture()
        Try
            If Save_D.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Cod_Rubrique_txt.Text & "'  and isnull(Nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            End If
            Return True
        Catch ex As Exception
            ErrorMsg(ex)
            Return False
        End Try
    End Function
    Function RubriqueUtiliseOld() As String
        Dim Tbl As DataTable = DATA_READER_GRD("select Cod_Rubrique from RH_Paie_Rubrique where (Cod_Rubrique='" & Cod_Rubrique_txt.Text & "' or Cod_Rubrique='Cumul_" & Cod_Rubrique_txt.Text & "') and (id_Societe=" & Societe.id_Societe & " or id_Societe=-1)")
        If Tbl.Rows.Count = 0 Then
            Return ""
        End If
        If CnExecuting("Select count(*) from RH_Preparation_Paie_Detail where (Cod_Rubrique='" & Cod_Rubrique_txt.Text & "' or Cod_Rubrique='Cumul_" & Cod_Rubrique_txt.Text & "') and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            Return "Rubrique utilisée dans un calcul de paie précédent"
        End If
        Tbl = DATA_READER_GRD("select Cod_Function,Formule_Function from RH_Param_Functions where isnull(Formule_Function,'') like '%" & Cod_Rubrique_txt.Text & "%' and id_Societe=" & Societe.id_Societe)
        Dim rg As New Regex("\b(" & Cod_Rubrique_txt.Text & ")\b|\b(Cumul_" & Cod_Rubrique_txt.Text & ")\b")
        With Tbl
            For i = 0 To .Rows.Count - 1
                If rg.IsMatch(.Rows(i)("Formule_Function")) Then
                    Return "Rubrique utilisée dans la fonction de calcul de paie : " & .Rows(i)("Cod_Function")
                End If
            Next
        End With
        Tbl = DATA_READER_GRD("select Cod_Rubrique,Tx,Nb,Base, Relation, Relation_VBS from RH_Paie_Rubrique where isnull(EC,0)=1 " & IIf(Rubrique_Globale_chk.Checked, "", " and id_Societe=" & Societe.id_Societe))
        rg = New Regex("\b(" & Cod_Rubrique_txt.Text & ")\b|\b(Cumul_" & Cod_Rubrique_txt.Text & ")\b")
        With Tbl
            For i = 0 To .Rows.Count - 1
                If rg.IsMatch(IsNull(.Rows(i)("Relation_VBS"), "")) Or rg.IsMatch(IsNull(.Rows(i)("Relation"), "")) Or rg.IsMatch(IsNull(.Rows(i)("Nb"), "")) Or rg.IsMatch(IsNull(.Rows(i)("Tx"), "")) Or rg.IsMatch(IsNull(.Rows(i)("Base"), "")) Then
                    Return "Rubrique utilisée dans une relation de calcul de la rubrique : " & .Rows(i)("Cod_Rubrique")
                End If
            Next
        End With
        Tbl = DATA_READER_GRD("select * from RH_Param_Plan_Paie p outer apply (select Den from Param_Societe where id_Societe=p.id_Societe)s where (';'+Element_Paie+';' like '%;" & Cod_Rubrique_txt.Text & ";%' or ';'+Element_Paie+';' like '%;Cumul_" & Cod_Rubrique_txt.Text & ";%') " & IIf(Rubrique_Globale_chk.Checked, "", " and id_Societe=" & Societe.id_Societe))

        If Tbl.Rows.Count > 0 Then
            ShowMessageBox("Vous ne pouvez pas changer cet élément car utilisé dans d'autres plans.", "Plans utilisés", MessageBoxButtons.OK, msgIcon.Error)
            Rubrique_Globale_chk.Checked = Not Rubrique_Globale_chk.Checked
            Return "Rubrique utilisée dans un plan de paie : " & Tbl.Rows(0)("Cod_Plan_Paie") & ", " & Tbl.Rows(0)("Lib_Plan_Paie") & ", Société: " & Tbl.Rows(0)("Den")
        End If
        Tbl = DATA_READER_GRD("select Cod_Plan_Paie,Lib_Plan_Paie,isnull(Element_Paie,'') as Element_Paie from RH_Param_Plan_Paie where isnull(Element_Paie,'')<>'' and id_Societe=" & Societe.id_Societe)
        Dim EP() As String
        With Tbl
            For i = 0 To .Rows.Count - 1
                EP = .Rows(i)("Element_Paie").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                If EP.Contains(Cod_Rubrique_txt.Text) Or EP.Contains("Cumul_" & Cod_Rubrique_txt.Text) Then
                    Return "Rubrique utilisée dans le plan de paie : " & .Rows(i)("Cod_Plan_Paie") & ", " & .Rows(i)("Lib_Plan_Paie")
                End If
            Next
        End With
        Return ""
    End Function
    Sub Deleting()
        If Cod_Rubrique_txt.Text.Trim = "" Then Return
        Try
            If ShowMessageBox("Etes-vous sûr de vouloir supprimer la rubrique : " & Cod_Rubrique_txt.Text, "Confirmation de suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
            Dim Rsl As String = RubriqueUtilise(Cod_Rubrique_txt.Text, Rubrique_Globale_chk.Checked)
            If Rsl <> "" Then
                Utilise_chk.Checked = True
                ShowMessageBox(Rsl, "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            Dim TblPlan As DataTable = DATA_READER_GRD("select Cod_Plan_Paie, Element_Paie, Element_Masques, Element_Masques_Simulation, Element_Detail  
from RH_Param_Plan_Paie p
where   ';'+isnull(p.Element_Paie,'')+';' like '%;" & Cod_Rubrique_txt.Text & ";%' and id_Societe = " & Societe.id_Societe)
            Dim EP, EM, EMS, ED As String
            Dim rg As New Regex("(?<=^|;)" & Cod_Rubrique_txt.Text & "(?=;|$)")
            With TblPlan
                For i = 0 To .Rows.Count - 1
                    EP = Join((";" & IsNull(.Rows(0)("Element_Paie"), "") & ";").Replace(";" & Cod_Rubrique_txt.Text & ";", ";").Split({";"}, StringSplitOptions.RemoveEmptyEntries), ";")
                    EM = Join((";" & IsNull(.Rows(0)("Element_Masques"), "") & ";").Replace(";" & Cod_Rubrique_txt.Text & ";", ";").Split({";"}, StringSplitOptions.RemoveEmptyEntries), ";")
                    EMS = Join((";" & IsNull(.Rows(0)("Element_Masques_Simulation"), "") & ";").Replace(";" & Cod_Rubrique_txt.Text & ";", ";").Split({";"}, StringSplitOptions.RemoveEmptyEntries), ";")
                    ED = Join((";" & IsNull(.Rows(0)("Element_Detail"), "") & ";").Replace(";" & Cod_Rubrique_txt.Text & ";", ";").Split({";"}, StringSplitOptions.RemoveEmptyEntries), ";")
                    CnExecuting("Update RH_Param_Plan_Paie set Element_Paie='" & EP & "', Element_Masques='" & EM & "', Element_Masques_Simulation='" & EMS & "', Element_Detail='" & ED & "' where Cod_Plan_Paie='" & .Rows(0)("Cod_Plan_Paie") & "' and id_Societe = " & Societe.id_Societe)
                Next
            End With
            CnExecuting("delete from RH_Paie_Rubrique where Cod_Rubrique='" & Cod_Rubrique_txt.Text & "' and isnull(estSysteme,'false')='false' and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
            ShowMessageBox("Elément supprimé", "Suppression", MessageBoxButtons.OK, msgIcon.Information)
            Reseting()
            CnExecuting("exec Sys_RH_Rubriques_Plan " & Societe.id_Societe)
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
        ModeDuplic = False
    End Sub
    Function Saving() As ArrayList
        chargement()
        Try
            If Not Save_D.Enabled Then Return New ArrayList({"Enregistrement désactivé", -1})
            Dim ErrStr As String = ""
            If Cod_Rubrique_txt.Text = "" Then
                Cod_Rubrique_txt.Select()
                Return New ArrayList({"Code vide", -1})
            End If
            If Not EstCaractèreConformeVBScript(Cod_Rubrique_txt.Text) Then
                Cod_Rubrique_txt.Select()
                Return New ArrayList({"Le code contient des caractères spéciaux ou des accents", -1})
            End If
            Dim rs As New ADODB.Recordset
            If Lib_Rubrique_txt.Text = "" Then
                Lib_Rubrique_txt.Select()
                Return New ArrayList({"Intitulé vide", -1})
            End If
            If Abr_Rubrique_txt.Text = "" Then
                Abr_Rubrique_txt.Select()
                Return New ArrayList({"Intitulé court vide", -1})
            End If
            If Typ_Retour.SelectedIndex = -1 Then
                Typ_Retour.DroppedDown = True
                Return New ArrayList({"Type de retour vide", -1})
            End If
            If Not EC_Rd.Checked And Not EV_Rd.Checked And Not CS_rd.Checked And Not EB_Rd.Checked And Not EX_Rd.Checked Then
                Return New ArrayList({"Le type de la rubrique est obligatoire", -1})
            End If

            If EC_Rd.Checked Then
                If Tx_txt.Text.Trim = "" And Nb_txt.Text.Trim = "" And Base_txt.Text.Trim = "" Then
                    '     Return New ArrayList({"Les variables de la rubrique sont vides",-1})
                    '     Return
                End If
                If Relation_txt.Text = "" Then
                    Relation_txt.Select()
                    Return New ArrayList({"La relation de calcul de la rubrique n'est pas renseignée", -1})
                End If
                If Not ModeSilentCalcul Then
                    Dim strFormula As String = FormaterRelation(Relation_txt.Text)
                    If Not VrifierCalcul(strFormula) Then
                        Return New ArrayList({"La syntaxe de la relation de calcul de la rubrique est erronée", -1})
                    End If
                    If Tx_txt.Text.Trim() <> "" Then
                        If Not VrifierCalcul(Tx_txt.Text.Trim()) Then

                            Return New ArrayList({"La syntaxe de la formule du champs 'Taux' est erronée", -1})
                        End If
                    End If
                    If Nb_txt.Text.Trim() <> "" Then
                        If Not VrifierCalcul(Nb_txt.Text.Trim()) Then
                            Return New ArrayList({"La syntaxe de la formule du champs 'Nombre' est erronée", -1})
                        End If
                    End If
                    If Base_txt.Text.Trim() <> "" Then
                        If Not VrifierCalcul(Base_txt.Text.Trim()) Then
                            Return New ArrayList({"La syntaxe de la formule du champs 'Base' est erronée", -1})
                        End If
                    End If
                End If
            ElseIf EX_Rd.Checked Then
                Base_txt.Text = ""
                Tx_txt.Text = ""
                Nb_txt.Text = ""
                If Relation_txt.Text = "" Then
                    Relation_txt.Select()
                    Return New ArrayList({"La relation de calcul de la rubrique n'est pas renseignée", -1})
                End If
                If Not ModeSilentCalcul Then
                    Dim strFormula As String = FormaterRelation(Relation_txt.Text)
                    If Not VrifierCalcul(strFormula) Then
                        Return New ArrayList({"La syntaxe de la relation de calcul de la rubrique est erronée", -1})
                    End If
                End If
            ElseIf (Tx_txt.Text.Trim <> "" Or Nb_txt.Text.Trim <> "" Or Base_txt.Text.Trim <> "" Or Relation_txt.Text.Trim <> "") Then
                Tx_txt.Text = ""
                Nb_txt.Text = ""
                Base_txt.Text = ""
                Relation_txt.Text = ""
            End If
            If Cod_Rubrique_txt.Text.Contains("*") Then
                Cod_Rubrique_txt.Select()
                Return New ArrayList({"Code rubrique contient un caractère intérdit '*'", -1})
            End If
            If Lib_Rubrique_txt.Text.Contains("*") Then
                Lib_Rubrique_txt.Select()
                Return New ArrayList({"Intitulé contient un caractère intérdit '*'", -1})
            End If
            If Abr_Rubrique_txt.Text.Contains("*") Then
                Abr_Rubrique_txt.Select()
                Return New ArrayList({"Abréviation contient un caractère intérdit '*'", -1})
            End If
            If Not estSysteme_chk.Checked And Not Rubrique_Globale_chk.Checked Then
                If CnExecuting("select count(*) from RH_Elements_Paie where  isnull(estSysteme,'false')='false' and (lower(ltrim(rtrim(Cod_Function)))=lower(ltrim(rtrim('" & Cod_Rubrique_txt.Text & "')))) " & IIf(Rubrique_Globale_chk.Checked, " and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")!=" & Societe.id_Societe, " and id_Societe=-1")).Fields(0).Value > 0 Then
                    Cod_Rubrique_txt.Select()
                    Return New ArrayList({"Code déjà utilisé par une autre rubrique locale ou globale dans une autre société.", -1})
                End If
                If CnExecuting("select count(*) from RH_Elements_Paie where (lower(ltrim(rtrim(Lib_Function)))=lower(ltrim(rtrim('" & Lib_Rubrique_txt.Text.Replace("'", "''") & "'))) or lower(ltrim(rtrim(Lib_Abr)))=lower(ltrim(rtrim('" & Lib_Rubrique_txt.Text.Replace("'", "''") & "')))) " & IIf(Rubrique_Globale_chk.Checked, " and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")!=" & Societe.id_Societe, " and id_Societe=-1 ")).Fields(0).Value > 0 Then
                    Lib_Rubrique_txt.Select()
                    Return New ArrayList({"Libellé déjà utilisé par une autre rubrique locale ou globale dans une autre société.", -1})
                End If
                If CnExecuting("select count(*) from RH_Elements_Paie where (lower(ltrim(rtrim(Lib_Function)))=lower(ltrim(rtrim('" & Abr_Rubrique_txt.Text.Replace("'", "''") & "'))) or lower(ltrim(rtrim(Lib_Abr)))=lower(ltrim(rtrim('" & Abr_Rubrique_txt.Text.Replace("'", "''") & "'))))" & IIf(Rubrique_Globale_chk.Checked, " and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")!=" & Societe.id_Societe, " and id_Societe=-1 ")).Fields(0).Value > 0 Then
                    Abr_Rubrique_txt.Select()
                    Return New ArrayList({"Abréviation déjà utilisée par une autre rubrique locale ou globale dans une autre société.", -1})
                End If
            End If
            Dim checkCoherenceTypRubriquePaieStr = checkCoherenceTypRubriquePaie()
            If Not checkCoherenceTypRubriquePaieStr = "" Then
                Return New ArrayList({checkCoherenceTypRubriquePaieStr, -1})
            End If
            If EV_Rd.Checked Then
                Val_Defaut_txt.Text = If(Val_Defaut_txt.Text.Trim = "" And "int;float".Split(";").Contains(Typ_Retour.SelectedValue.ToString.ToLower), 0, Val_Defaut_txt.Text.Trim)
                If Val_Defaut_txt.Text.Trim = "" Then
                    Val_Defaut_txt.Select()
                    Return New ArrayList({"Attention : Valeur par défaut non renseignée", -1})
                Else
                    Val_Defaut_txt.Text = Val_Defaut_txt.Text.Trim
                    Dim EstErr As Boolean = False
                    Select Case Typ_Retour.SelectedValue.ToString.ToLower
                        Case "int", "float"
                            EstErr = (Not IsNumeric(Val_Defaut_txt.Text))
                        Case "smalldatetime", "datetime"
                            EstErr = (Not EstDate(Val_Defaut_txt.Text))
                        Case "boolean"
                            EstErr = (Not (Val_Defaut_txt.Text.ToLower = "true" Or Val_Defaut_txt.Text.ToLower = "false" Or Val_Defaut_txt.Text.ToLower = "vrai" Or Val_Defaut_txt.Text.ToLower = "faux" Or Val_Defaut_txt.Text.ToLower = "oui" Or Val_Defaut_txt.Text.ToLower = "non" Or Val_Defaut_txt.Text.ToLower = "1" Or Val_Defaut_txt.Text.ToLower = "0" Or Val_Defaut_txt.Text.ToLower = "o" Or Val_Defaut_txt.Text.ToLower = "n"))
                    End Select
                    If EstErr Then
                        Val_Defaut_txt.Select()
                        Return New ArrayList({"Erreur format de la valeur par défaut par rapport au type de retour", -1})
                    End If
                End If
            End If
            If CS_rd.Checked Then
                If Val_Defaut_txt.Text.Trim = "" Then
                    Val_Defaut_txt.Select()
                    Return New ArrayList({"Valeur de retour non renseignée", -1})
                Else
                    Val_Defaut_txt.Text = Val_Defaut_txt.Text.Trim
                    Dim EstErr As Boolean = False
                    Select Case Typ_Retour.SelectedValue.ToString.ToLower
                        Case "int", "float"
                            EstErr = (Not IsNumeric(Val_Defaut_txt.Text))
                        Case "smalldatetime", "datetime"
                            EstErr = (Not EstDate(Val_Defaut_txt.Text))
                        Case "boolean"
                            EstErr = (Not (Val_Defaut_txt.Text.ToLower = "true" Or Val_Defaut_txt.Text.ToLower = "false" Or Val_Defaut_txt.Text.ToLower = "vrai" Or Val_Defaut_txt.Text.ToLower = "faux" Or Val_Defaut_txt.Text.ToLower = "oui" Or Val_Defaut_txt.Text.ToLower = "non" Or Val_Defaut_txt.Text.ToLower = "1" Or Val_Defaut_txt.Text.ToLower = "0" Or Val_Defaut_txt.Text.ToLower = "o" Or Val_Defaut_txt.Text.ToLower = "n"))
                    End Select
                    If EstErr Then
                        Val_Defaut_txt.Select()
                        Return New ArrayList({"Erreur format de la valeur de retour par rapport au type de retour", -1})
                    End If
                End If
            End If
            If Typ_Retour.SelectedValue.ToString.ToUpper <> "FLOAT" Then
                Nb_Decimal.Value = 0
            End If
            Dim oDat As DateTime = CnExecuting("select getdate()").Fields(0).Value
            Dim etatGlobalBefore As Integer = -1
            Dim nouveau As Boolean = False
            rs.Open("select * from RH_Paie_Rubrique where Cod_Rubrique='" & Cod_Rubrique_txt.Text & "' and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.EOF Then
                If estSysteme_chk.Checked Then Return New ArrayList({"Rubrique système non encore créée.", -1})
                rs.AddNew()
                rs("Cod_Rubrique").Value = Cod_Rubrique_txt.Text
                rs("lastVersion").Value = IsNull(estSysteme_chk.Tag, 0)
                rs("Cod_Rubrique").Value = Cod_Rubrique_txt.Text
                rs("Dat_Crea").Value = oDat
                rs("Created_By").Value = theUser.Login
                nouveau = True
                etatGlobalBefore = 0
            Else
                rs.Update()
                nouveau = False
                etatGlobalBefore = If(IsNull(rs("Rubrique_Globale").Value, False), 2, 1)
            End If
            If Not estSysteme_chk.Checked Or Ud_Proteger.Checked Then
                rs("id_Societe").Value = IIf(Rubrique_Globale_chk.Checked Or estSysteme_chk.Checked, -1, Societe.id_Societe)
                rs("Lib_Rubrique").Value = Lib_Rubrique_txt.Text
                rs("Abr_Rubrique").Value = Abr_Rubrique_txt.Text
                rs("EC").Value = EC_Rd.Checked
                rs("EV").Value = EV_Rd.Checked
                rs("EB").Value = EB_Rd.Checked
                rs("EX").Value = EX_Rd.Checked
                rs("CS").Value = CS_rd.Checked
                rs("Rubrique_Globale").Value = Rubrique_Globale_chk.Checked Or estSysteme_chk.Checked
                rs("Cumulable").Value = Cumulable_chk.Checked
                rs("Typ_Retour").Value = Typ_Retour.SelectedValue
                rs("Nb_Decimal").Value = Nb_Decimal.Value
                If Typ_Retour.SelectedValue.ToString.ToUpper <> "FLOAT" Then Est_Pourcentage_chk.Checked = False
                rs("Est_Pourcentage").Value = Est_Pourcentage_chk.Checked
                rs("Typ_Rubrique_Paie").Value = Typ_Rubrique_Paie.SelectedValue
                rs("Nature_Element_Exonere").Value = Nature_Element_Exonere_txt.Text
                rs("Nb").Value = Nb_txt.Text
                rs("Base").Value = Base_txt.Text
                rs("Val_Defaut").Value = ParDefaut(Val_Defaut_txt.Text.Trim, Typ_Retour.SelectedValue)
                rs("Tx").Value = Tx_txt.Text
                rs("Relation").Value = Relation_txt.Text
                rs("Relation_VBS").Value = FormaterRelation(Relation_txt.Text)
                rs("Gain_Retenue").Value = IIf(Gain_rd.Checked, "G", IIf(Retenue_rd.Checked, "R", "A"))
                rs("Salarial").Value = Salarial_rd.Checked
                rs("Patronal").Value = Patronal_rd.Checked
                rs("estMajAuto").Value = (estMajAuto_chk.Checked And (Not Me.Visible OrElse estMajAuto_chk.Visible))
                rs("Imposable_IR").Value = Imposable_IR_chk.Checked
                rs("Imposable_CNSS").Value = Imposable_CNSS_chk.Checked
                rs("Deductible_CNSS").Value = Deductible_CNSS_chk.Checked
                rs("Deductible_IR").Value = Deductible_IR_chk.Checked
            End If
            rs("Cpt_Debit").Value = Cpt_Debit_txt.Text
            rs("Cpt_Credit").Value = Cpt_Credit_txt.Text
            rs("Ventilable").Value = Ventilable_chk.Checked
            rs("Commentaire").Value = Commentaire.rtb.Rtf
            If lblColor.BackColor = Nothing Or lblColor.BackColor = lblColor.Parent.BackColor Then
                rs("Couleur").Value = ""
            Else
                rs("Couleur").Value = lblColor.BackColor.R & ";" & lblColor.BackColor.G & ";" & lblColor.BackColor.B
            End If
            rs("Proteger").Value = Ud_Proteger.Checked
            rs("Ventilable").Value = Ventilable_chk.Checked
            rs("Dat_Modif").Value = oDat
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            Request()
            'En cas dinsertion de mise à jour du statut Global d'une rubrique ou de sa création
            If nouveau Then
                CnExecuting("update RH_Param_Plan_Paie set Element_Paie  = isnull(Element_Paie+';','')+'" & Cod_Rubrique_txt.Text & "'" & If(Rubrique_Globale_chk.Checked, "", " where id_Societe=" & Societe.id_Societe))
            ElseIf (etatGlobalBefore = 1 And Rubrique_Globale_chk.Checked) Then
                CnExecuting("update RH_Param_Plan_Paie set Element_Paie  = isnull(Element_Paie+';','')+'" & Cod_Rubrique_txt.Text & "' where ';'+Element_Paie+';' not like '%;" & Cod_Rubrique_txt.Text & ";%'")
            End If

            CnExecuting("exec Sys_RH_Rubriques_Plan " & Societe.id_Societe)
            If ErrStr <> "" Then
                Return New ArrayList({ErrStr, 0})
            Else
                Return New ArrayList({"Enregistré avec succès", 1, Cod_Rubrique_txt.Text})
            End If
            ModeDuplic = False
        Catch ex As Exception
            Return New ArrayList({ex.Message, -1})
            ModeDuplic = False
        End Try

    End Function
    Function checkCoherenceTypRubriquePaie() As String
        If Not Gain_rd.Checked And Not Retenue_rd.Checked And Not Autre_Rd.Checked Then
            Autre_Rd.Checked = True
            ud_RadioBox1.Checked = True
        End If
        If Typ_Rubrique_Paie.SelectedIndex = -1 Then Typ_Rubrique_Paie.SelectedValue = "A_Autres"
        If (Typ_Rubrique_Paie.SelectedValue = "G_PrimeExo" Or Typ_Rubrique_Paie.SelectedValue = "G_IndExo") And Nature_Element_Exonere_txt.Text = "" Then
            Return "Veuillez renseigner la nature de l'élément exonéré."
        Else
            If Gain_rd.Checked And Not "G_PrimeExo;G_PrimeImp;G_Sal;G_IndExo;G_IndImp".Contains(Typ_Rubrique_Paie.SelectedValue) Then
                Return "Vérifiez la cohérence du groupe de la rubrique et sa catégorie."
            ElseIf Retenue_rd.Checked And Not "R_Cotis;R_Retenues".Contains(Typ_Rubrique_Paie.SelectedValue) Then
                Return "Vérifiez la cohérence du groupe de la rubrique et sa catégorie."
            End If
        End If
        If Gain_rd.Checked Or Retenue_rd.Checked Then
            Salarial_rd.Checked = True
            'Element du bulletin de paie
            If EC_Rd.Checked Then
                If Base_txt.Text.Trim = "" Then
                    Return "Les rubriques de type 'Gain' ou 'Retenue' doivent préciser la 'Base'"
                ElseIf Tx_txt.Text.Trim = "" And Nb_txt.Text.Trim = "" Then
                    Return "Les rubriques de type 'Gain' ou 'Retenue' doivent préciser le 'Taux' ou le 'Nombre'"
                ElseIf Tx_txt.Text.Trim <> "" And Nb_txt.Text.Trim <> "" Then
                    Return "Les rubriques de type 'Gain' ou 'Retenue' ne doivent pas préciser le 'Taux' et le 'Nombre' en même temps"
                End If
                If Relation_txt.Text.Trim = "" Then
                    Relation_txt.Select()
                    Return "La relation de calcul de la rubrique n'est pas renseignée"
                End If
            End If
        End If
        If "R_Autres".Contains(Typ_Rubrique_Paie.SelectedValue) Then
            Autre_Rd.Checked = True
        End If
        If "G_PrimeExo;G_PrimeImp;G_Sal;G_IndExo;G_IndImp".Contains(Typ_Rubrique_Paie.SelectedValue) Then
            If Not Gain_rd.Checked Then
                Gain_rd.Checked = True
            End If
        End If
        If "R_Cotis".Contains(Typ_Rubrique_Paie.SelectedValue) Then
            If Not Salarial_rd.Checked And Not Patronal_rd.Checked Then
                Return "Veuillez préciser s'il s'agit de cotisation salariale ou patronale."
            ElseIf Salarial_rd.Checked Then
                Retenue_rd.Checked = True
            End If
        End If
        If "R_Retenues".Contains(Typ_Rubrique_Paie.SelectedValue) Then
            If Not Salarial_rd.Checked Or Not Retenue_rd.Checked Then
                Salarial_rd.Checked = True
                Retenue_rd.Checked = True
            End If
        End If
        If ("G_PrimeExo;G_IndExo").Split({";"}, StringSplitOptions.RemoveEmptyEntries).Contains(Typ_Rubrique_Paie.SelectedValue) Then
            If Imposable_CNSS_chk.Checked And Imposable_IR_chk.Checked Then
                Return "Veuillez préciser si cette rubrique est exonérée à l'IR ou à la CNSS"
            End If
        End If

        If Imposable_CNSS_chk.Checked And Imposable_IR_chk.Checked Then
            If ("G_PrimeExo;G_IndExo").Split({";"}, StringSplitOptions.RemoveEmptyEntries).Contains(Typ_Rubrique_Paie.SelectedValue) Then
                Return "Veuillez préciser si cette rubrique est exonérée à l'IR ou à la CNSS"
            End If
        End If
        Return ""
    End Function
    Function FormaterRelation(strFormula As String) As String
        Dim rg As New Regex("\b(Nb)\b", RegexOptions.IgnoreCase)
        strFormula = rg.Replace(strFormula, "(" & Nb_txt.Text.Replace(vbCrLf, " ").Trim() & ")")
        rg = New Regex("\b(Base)\b", RegexOptions.IgnoreCase)
        strFormula = rg.Replace(strFormula, "(" & Base_txt.Text.Replace(vbCrLf, " ").Trim() & ")")
        rg = New Regex("\b(Tx)\b", RegexOptions.IgnoreCase)
        strFormula = rg.Replace(strFormula, "(" & Tx_txt.Text.Replace(vbCrLf, " ").Trim() & ")")
        rg = New Regex("\b(" & Cod_Rubrique_txt.Text & ")\b", RegexOptions.IgnoreCase)
        strFormula = rg.Replace(strFormula, "(V_" & Cod_Rubrique_txt.Text.Replace(vbCrLf, " ").Trim() & ")")
        Return strFormula
    End Function
    Function VrifierCalcul(strFormula As String) As Boolean
        Try
            If strFormula = "" Then Return True
            Dim f As New Zoom_RH_Saisie_EV
            With f
                .myVBS = myVBS
                .silentMode = (Societe.LeMatricule <> "")
                If .silentMode Then
                    .Save_D_Click(Nothing, Nothing)
                Else
                    .ShowDialog()
                End If
            End With
            strFormula = TraitementCaractere(strFormula)
            Dim Result As String = myVBS.Eval(strFormula)
            Return True
        Catch ex As Exception
            ErrorMsg(ex)
            Return False
        End Try
    End Function
    Sub Reseting()
        Reset_Form(Me)
        ModeDuplic = False
    End Sub
    Sub Div_First()
        If Cod_Rubrique_txt.Text <> "" Then
            Diviseur_First("RH_Paie_Rubrique", "Cod_Rubrique", "Lib_Rubrique", Cod_Rubrique_txt)
            ModeDuplic = False
            Request()
        End If
    End Sub
    Sub Div_Back()
        If Cod_Rubrique_txt.Text <> "" Then
            Diviseur_Back("RH_Paie_Rubrique", "Cod_Rubrique", "Lib_Rubrique", Cod_Rubrique_txt)
            ModeDuplic = False
            Request()
        End If
    End Sub
    Sub Div_Next()
        If Cod_Rubrique_txt.Text <> "" Then
            Diviseur_Next("RH_Paie_Rubrique", "Cod_Rubrique", "Lib_Rubrique", Cod_Rubrique_txt)
            ModeDuplic = False
            Request()
        End If
    End Sub
    Sub Div_Last()
        If Cod_Rubrique_txt.Text <> "" Then
            Diviseur_Last("RH_Paie_Rubrique", "Cod_Rubrique", "Lib_Rubrique", Cod_Rubrique_txt)
            ModeDuplic = False
            Request()
        End If
    End Sub
    Sub Nouveau()
        Adding()
    End Sub
    Sub Adding()
        Reseting()
        ModeDuplic = False
        Enabling(Cod_Rubrique_txt, True)
        Del_D.Enabled = True
        Save_D.Enabled = True
        Request()
        EC_Rd.Checked = True
        Autre_Rd.Checked = True
        Salarial_rd.Checked = True
        Typ_Retour.SelectedValue = "float"
        showElementCalcul()
        Typ_Rubrique_Paie.SelectedValue = "Autres"
        Cod_Rubrique_txt.Select()
    End Sub
    Sub Enregistrer()
        Dim rsl As ArrayList = Saving()
        If Not ModeSilent Then
            ShowMessageBox(rsl(0), "Enregistrer", MessageBoxButtons.OK, IIf(rsl(1) = 1, msgIcon.Information, IIf(rsl(1) = -1, msgIcon.Stop, msgIcon.Warning)))
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles detail_1_btn.Click
        Appel_Zoom1("MS006", Tx_txt, Me)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles detail_2_btn.Click
        Appel_Zoom1("MS007", Nb_txt, Me)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles detail_3_btn.Click
        Appel_Zoom1("MS008", Base_txt, Me)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles detail_4_btn.Click
        If estSysteme_chk.Checked And Not Ud_Proteger.Checked Then Return
        If Tx_txt.Text.Trim = "" And Nb_txt.Text.Trim = "" And Base_txt.Text.Trim = "" Then
            ShowMessageBox("Les variables de la rubrique sont vides", "Erreur", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        With Zoom_Rubrique_Relation
            .Tx_pb.Enabled = (Tx_txt.Text.Trim <> "")
            .Nb_pb.Enabled = (Nb_txt.Text.Trim <> "")
            .Base_pb.Enabled = (Base_txt.Text.Trim <> "")
            .Zone_txt.Text = Relation_txt.Text
            .Relation_txt = Relation_txt
            .ShowDialog()
        End With
    End Sub
    Private Sub Rub__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Rub_.LinkClicked
        ModeDuplic = False
        Appel_Zoom1("MS009", Cod_Rubrique_txt, Me)
        Cod_Rubrique_txt.Select()
        Lib_Rubrique_txt.Select()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Appel_Zoom1("MS025", Cpt_Debit_txt, Me)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Appel_Zoom1("MS025", Cpt_Credit_txt, Me)
    End Sub

    Private Sub Tx_txt_TextChanged(sender As Object, e As EventArgs) Handles Tx_txt.TextChanged, Nb_txt.TextChanged, Base_txt.TextChanged
        '   Relation_txt.ResetText()
    End Sub
    Private Sub Calcule_chk_CheckedChanged(sender As Object, e As EventArgs) Handles EC_Rd.CheckedChanged
        showElementCalcul()
    End Sub
    Private Sub RH_Parametrage_Rubrique_Paie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chargement()
    End Sub
    Sub chargement()
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
            Optional_D = dictButtons("Optional_D")
        End If
        If Typ_Retour.Items.Count = 0 Then
            Typ_Retour.fromRubrique("Typ_Param")
            If Typ_Rubrique_Paie.Items.Count = 0 Then Typ_Rubrique_Paie.fromRubrique("Typ_Rubrique_Paie")
            Grp2.Enabled = True
            EnablingGrp3(True)
            Typ_Retour.Enabled = True
            detail_4_btn.Enabled = True
            formule_4_btn.Enabled = True
            msg_lbl.Visible = False
            estMajAuto_chk.Visible = False
            Enabling(Val_Defaut_txt, (EV_Rd.Checked Or CS_rd.Checked))
        End If
    End Sub
    Sub Dupliquer()
        Utilise_chk.Checked = False
        estSysteme_chk.Checked = False
        Rubrique_Globale_chk.Checked = False
        Del_D.Enabled = True
        Save_D.Enabled = True
        Cod_Rubrique_txt.Text &= "***"
        Lib_Rubrique_txt.Text &= "***"
        Abr_Rubrique_txt.Text &= "***"
        Cod_Rubrique_txt.Select()
        ModeDuplic = True
        Request()
        Enabling(Cod_Rubrique_txt, True)
        Grp2.Enabled = True
        EnablingGrp3(True)
        Typ_Retour.Enabled = True
        EB_Rd.Enabled = True
        EC_Rd.Enabled = True
        EV_Rd.Enabled = True
        CS_rd.Enabled = True
        Pnl_Categorie.Enabled = True
        Rubrique_Globale_chk.Enabled = True
        Cumulable_chk.Enabled = True
        Enabling(Val_Defaut_txt, (EV_Rd.Checked Or CS_rd.Checked))
    End Sub
    Private Sub EV_Rd_CheckedChanged(sender As Object, e As EventArgs) Handles EV_Rd.CheckedChanged
        Enabling(Val_Defaut_txt, (EV_Rd.Checked Or CS_rd.Checked))
        If EV_Rd.Checked Then
            With lb_Val
                .Location = New Point(.Location.X, EV_Rd.Location.Y)
                .Visible = True
            End With
            With Val_Defaut_txt
                .ResetText()
                .Visible = True
                .Location = New Point(.Location.X, EV_Rd.Location.Y)
            End With
        Else
            With lb_Val
                .Visible = False
            End With
            With Val_Defaut_txt
                If Not CS_rd.Checked Then .ResetText()
                .Visible = False
            End With
        End If
        showElementCalcul()
    End Sub

    Private Sub CS_rd_CheckedChanged(sender As Object, e As EventArgs) Handles CS_rd.CheckedChanged
        Enabling(Val_Defaut_txt, (EV_Rd.Checked Or CS_rd.Checked))
        If CS_rd.Checked Then
            With lb_Val
                .Location = New Point(.Location.X, CS_rd.Location.Y)
                .Visible = True
            End With
            With Val_Defaut_txt
                .ResetText()
                .Visible = True
                .Location = New Point(.Location.X, CS_rd.Location.Y)
                .Select()
            End With
        Else
            With lb_Val
                .Visible = False
            End With
            With Val_Defaut_txt
                If Not EV_Rd.Checked Then .ResetText()
                .Visible = False
            End With
        End If
        showElementCalcul()
    End Sub

    Private Sub Val_Defaut_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Val_Defaut_txt.KeyPress
        Dim oTyp As String = ""
        If Typ_Retour.SelectedIndex >= 0 Then
            oTyp = IsNull(Typ_Retour.SelectedValue, "").ToLower
        End If
        ControleSaisie(sender, e, IIf(oTyp = "int" Or oTyp = "float", True, False), IIf(oTyp = "int", True, False), False, IIf(oTyp = "int" Or oTyp = "float", False, True), False)
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles formule_4_btn.Click
        CallEditeurFunction(Relation_txt)
    End Sub
    Sub CallEditeurFunction(ZoneTxt As ud_TextBox, Optional ByVal LecteureSeule As Boolean = False)
        If estSysteme_chk.Checked And Not (Ud_Proteger.Checked Or LecteureSeule) Then Return
        If Cod_Rubrique_txt.Text = "" Then
            Cod_Rubrique_txt.Select()
            Exit Sub
        End If
        If Not EstCaractèreConformeVBScript(Cod_Rubrique_txt.Text) Then
            ShowMessageBox("Le code contient des caractères spéciaux ou des accents", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
            Cod_Rubrique_txt.Select()
            Exit Sub
        End If
        If Lib_Rubrique_txt.Text = "" Then
            ShowMessageBox("Intitulé vide", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
            Lib_Rubrique_txt.Select()
            Exit Sub
        End If
        If Abr_Rubrique_txt.Text = "" Then
            ShowMessageBox("Intitulé court vide", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
            Abr_Rubrique_txt.Select()
            Exit Sub
        End If
        If Typ_Retour.SelectedIndex = -1 Then
            ShowMessageBox("Type de retour vide", "Enregistrer", MessageBoxButtons.OK, msgIcon.Error)
            Typ_Retour.DroppedDown = True
            Exit Sub
        End If
        Dim f As New Zoom_RH_Editeur_Formule
        With f
            .Save_pb.Visible = Not LecteureSeule
            .myVBS = myVBS
            .CodRubrique = Cod_Rubrique_txt.Text
            .TypRetour = Typ_Retour.SelectedValue
            .otxt = ZoneTxt
            .formulafunction = If(EX_Rd.Checked, ZoneTxt.Text, FormaterRelation(ZoneTxt.Text))
            .ShowDialog()
        End With
    End Sub
    Sub Simuler()
        If Typ_Retour.SelectedIndex < 0 Then
            ShowMessageBox("Type retour non renseigné")
            Typ_Retour.DroppedDown = True
            Return
        End If
        Dim f As New Zoom_RH_Saisie_EV
        With f
            .myVBS = myVBS
            .ShowDialog()
        End With
        Try
            ShowMessageBox("La valeur de l'élément [" & Cod_Rubrique_txt.Text & "] est : " & vbCrLf & myVBS.Eval(Cod_Rubrique_txt.Text), "Evaluer une valeur", MessageBoxButtons.OK, msgIcon.Information)
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)
        End Try
    End Sub

    Private Sub Nb_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Nb_txt.KeyPress, Tx_txt.KeyPress, Base_txt.KeyPress
        If e.KeyChar = "," Then e.KeyChar = "."
    End Sub

    Private Sub EB_Rd_CheckedChanged(sender As Object, e As EventArgs) Handles EB_Rd.CheckedChanged
        showElementCalcul()
    End Sub
    Sub Actualiser()
        Request()
    End Sub
    Private Sub Lib_Rubrique_txt_Leave(sender As Object, e As EventArgs) Handles Lib_Rubrique_txt.Leave
        If ModeCrea Then
            If Abr_Rubrique_txt.Text = "" Or Abr_Rubrique_txt.Text.Contains("**") Then
                Abr_Rubrique_txt.Text = Gauche(Lib_Rubrique_txt.Text, 50)
            End If
        End If
    End Sub
    Private Sub Abr_Rubrique_txt_Leave(sender As Object, e As EventArgs) Handles Abr_Rubrique_txt.Leave
        If ModeCrea Then
            If Typ_Retour.SelectedIndex = -1 Then
                Typ_Retour.SelectedValue = "float"
                Nb_Decimal.Value = 2
            End If
        End If
    End Sub
    Private Sub Typ_Retour_DropDownClosed(sender As Object, e As EventArgs) Handles Typ_Retour.DropDownClosed
        If Typ_Retour.SelectedIndex > 1 Then
            If Nb_Decimal.Value = 0 Then
                Select Case Typ_Retour.SelectedValue
                    Case "float"
                        Nb_Decimal.Value = 2
                    Case Else
                        Nb_Decimal.Value = 0
                End Select
            End If
        End If
    End Sub
    Private Sub Typ_Rubrique_Paie_DropDownClosed(sender As Object, e As EventArgs) Handles Typ_Rubrique_Paie.DropDownClosed
        Try
            If Typ_Rubrique_Paie.SelectedValue = "G_PrimeExo" Or Typ_Rubrique_Paie.SelectedValue = "G_IndExo" Then
                NatureElementExonere.Enabled = True
            Else
                NatureElementExonere.Enabled = False
                Nature_Element_Exonere_txt.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Nature_Element_Exonere_txt_TextChanged(sender As Object, e As EventArgs) Handles Nature_Element_Exonere_txt.TextChanged
        Lib_Nature_Element_Exonere_txt.Text = FindLibelle("refNatureElementExonere", "Code", Nature_Element_Exonere_txt.Text, "Param_IR_NatureElementExonere")
    End Sub
    Private Sub NatureElementExonere_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles NatureElementExonere.LinkClicked
        Appel_Zoom1("MS148", Nature_Element_Exonere_txt, Me)
    End Sub
    Private Sub Gain_rd_CheckedChanged(sender As Object, e As EventArgs) Handles Gain_rd.CheckedChanged
        If Gain_rd.Checked Then
            Salarial_rd.Checked = True
            Deductible_CNSS_chk.Checked = False
            Deductible_IR_chk.Checked = False
            Deductible_CNSS_chk.Enabled = False
            Deductible_IR_chk.Enabled = False
            Imposable_IR_chk.Enabled = True
            Imposable_CNSS_chk.Enabled = True
            Imposable_IR_chk.Checked = True
            Imposable_CNSS_chk.Checked = True
            Salarial_rd.Checked = True
            Patronal_rd.Checked = False
            ud_RadioBox1.Checked = False
            Patronal_rd.Enabled = False
            ud_RadioBox1.Enabled = False
        End If

    End Sub
    Private Sub Retenue_rd_CheckedChanged(sender As Object, e As EventArgs) Handles Retenue_rd.CheckedChanged
        If Retenue_rd.Checked Then
            Salarial_rd.Checked = True
            Deductible_CNSS_chk.Checked = False
            Deductible_IR_chk.Checked = False
            Deductible_CNSS_chk.Enabled = True
            Deductible_IR_chk.Enabled = True
            Imposable_IR_chk.Enabled = False
            Imposable_CNSS_chk.Enabled = False
            Imposable_IR_chk.Checked = False
            Imposable_CNSS_chk.Checked = False
            Salarial_rd.Checked = True
            Patronal_rd.Checked = False
            ud_RadioBox1.Checked = False
            Patronal_rd.Enabled = False
            ud_RadioBox1.Enabled = False
        End If
    End Sub
    Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Dim oCol As New ColorDialog
        With oCol
            .Color = lblColor.BackColor
            .ShowDialog()
            lblColor.BackColor = .Color
        End With
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles formule_3_btn.Click
        CallEditeurFunction(Base_txt)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles formule_2_btn.Click
        CallEditeurFunction(Nb_txt)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles formule_1_btn.Click
        CallEditeurFunction(Tx_txt)
    End Sub
    Private Sub Rubrique_Globale_chk_Click(sender As Object, e As EventArgs) Handles Rubrique_Globale_chk.Click
        If ShowMessageBox("Il s'agit de modifier une rubrique globale. Ceci risque d'impacter les autres sociétés déclarées. Voulez-vous continuer?", "Rubrique globale", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then
            Rubrique_Globale_chk.Checked = Not Rubrique_Globale_chk.Checked
            Return
        End If
        If CnExecuting("select count(*) from RH_Param_Plan_Paie where id_Societe!=" & Societe.id_Societe & " and ';'+Element_Paie+';' like '%;" & Cod_Rubrique_txt.Text & ";%'").Fields(0).Value > 0 Then
            ShowMessageBox("Vous ne pouvez pas changer cet élément car utilisé dans d'autres plans.", "Plans utilisés", MessageBoxButtons.OK, msgIcon.Error)
            Rubrique_Globale_chk.Checked = Not Rubrique_Globale_chk.Checked
            Return
        End If
    End Sub

    Private Sub Autre_Rd_CheckedChanged(sender As Object, e As EventArgs) Handles Autre_Rd.CheckedChanged
        If Autre_Rd.Checked Then
            Salarial_rd.Checked = False
            Salarial_rd.Enabled = False
            Patronal_rd.Enabled = True
            Autre_Rd.Enabled = True
            Imposable_CNSS_chk.Checked = False
            Imposable_IR_chk.Checked = False
            Deductible_CNSS_chk.Checked = False
            Deductible_IR_chk.Checked = False
        End If
    End Sub

    Private Sub estMajAuto_chk_CheckedChanged(sender As Object, e As EventArgs) Handles estMajAuto_chk.CheckedChanged
        If estMajAuto_chk.Visible Then
            detail_4_btn.Enabled = Not estMajAuto_chk.Checked
            formule_4_btn.Enabled = Not estMajAuto_chk.Checked
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Utilise_chk.Checked Then
            ShowMessageBox(RubriqueUtilise(Cod_Rubrique_txt.Text, Rubrique_Globale_chk.Checked), "Rubrique utilisée")
        End If
    End Sub
    Private Sub Cod_Rubrique_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cod_Rubrique_txt.KeyPress
        Dim rg As New Regex("[^a-zA-Z0-9_]", RegexOptions.IgnoreCase)
        ' Vérifiez si le caractère est un caractère spécial, mais autorisez backspace
        If rg.IsMatch(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Proportionnel_chk_CheckedChanged(sender As Object, e As EventArgs)
        showElementCalcul()
    End Sub
    Sub ImporterRubriquesPredefinie()
        Dim f As New Zoom_RubriquesPredefinies
        With f
            .ShowDialog()
        End With
    End Sub
    Sub showElementCalcul()
        eleCalcul_pnl.Visible = EC_Rd.Checked Or EX_Rd.Checked
        element_calcul_pnl.RowStyles(0).Height = If(EC_Rd.Checked, 30, 0)
        element_calcul_pnl.RowStyles(1).Height = If(EC_Rd.Checked, 30, 0)
        element_calcul_pnl.RowStyles(2).Height = If(EC_Rd.Checked, 30, 0)
    End Sub

    Private Sub EX_Rd_CheckedChanged(sender As Object, e As EventArgs) Handles EX_Rd.CheckedChanged
        showElementCalcul()
        If Relation_txt.Text = "" Then Relation_txt.Text = Cod_Rubrique_txt.Text
    End Sub
    Private Sub Ud_Proteger_Click(sender As Object, e As EventArgs) Handles Ud_Proteger.Click

    End Sub

    Private Sub Ud_Proteger_CheckedChanged(sender As Object, e As EventArgs) Handles Ud_Proteger.CheckedChanged
        Dim canChange = Not estSysteme_chk.Checked Or Ud_Proteger.Checked
        Grp2.Enabled = canChange
        EnablingGrp3(canChange)
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        CallEditeurFunction(Relation_txt, Not formule_4_btn.Enabled)
    End Sub
    Sub EnablingGrp3(actif As Boolean)
        estMajAuto_chk.Enabled = actif
        Val_Defaut_txt.ReadOnly = Not actif
        detail_1_btn.Enabled = actif
        formule_1_btn.Enabled = actif
        detail_2_btn.Enabled = actif
        formule_2_btn.Enabled = actif
        detail_3_btn.Enabled = actif
        formule_3_btn.Enabled = actif
        detail_4_btn.Enabled = actif
        formule_4_btn.Enabled = actif
    End Sub
End Class