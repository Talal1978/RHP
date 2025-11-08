Public Class RH_Paiement
    Dim Code As String = ""
    Dim TblSource As DataTable = Nothing
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Request_D As ud_btn
    Dim Del_D As ud_btn
    Dim Cloture_D As ud_btn
    Sub ChargementCombo()
        If Mod_Paiement.Items.Count = 0 Then Mod_Paiement.fromRubrique("Mod_Paiement")
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Request_D = dictButtons("Request_D")
            Del_D = dictButtons("Del_D")
            Cloture_D = dictButtons("Cloture_D")
        End If
    End Sub
    Private Sub Cod_Preparation__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Preparation_.LinkClicked
        If Cod_Paiement_txt.Text <> "" Then Return
        Appel_Zoom1("MS013", Cod_Preparation_Text, Me, "Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "'")
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Zoom1("MS055", Cod_Caisse_Bank_Text, Me)
    End Sub
    Private Sub Cod_Caisse_Bank_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Caisse_Bank_Text.TextChanged
        Bank_txt.Text = FindLibelle("Bank", "Cod_Caisse_Bank", Cod_Caisse_Bank_Text.Text, "Compta_Caisse_Banque")
    End Sub
    Private Sub Cod_Preparation_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Preparation_Text.TextChanged
        R_Paie.Checked = (Cod_Preparation_Text.Text <> "")
        If R_Paie.Checked And Cod_Paiement_txt.Text = "" Then
            Num_List_Avance_txt.Text = ""
            RequestDetail()
        End If
    End Sub
    Private Sub Cod_Paiement_TextChanged(sender As Object, e As EventArgs) Handles Cod_Paiement_txt.TextChanged
        Request()
    End Sub
    Sub Request()
        Save_D.Enabled = True
        Del_D.Enabled = True
        Cloture_D.Enabled = True
        Request_D.Enabled = True
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Cod_Paiement_txt.Text, Me))
        ChargementCombo()
        Dim Tbl As DataTable = DATA_READER_GRD("select * from RH_Paiement where Cod_Paiement= '" & Cod_Paiement_txt.Text & "'")
        With Tbl
            If .Rows.Count > 0 Then
                Lib_Paiement_txt.Text = IsNull(.Rows(0)("Lib_Paiement"), "")
                Dat_Paiement.Value = IsNull(.Rows(0)("Dat_Paiement"), Now.Date)
                Cod_Caisse_Bank_Text.Text = IsNull(.Rows(0)("Cod_Caisse_Bank"), "")
                Bank_txt.Text = IsNull(.Rows(0)("Bank"), "")
                Cod_Plan_Paie_Text.Text = IsNull(.Rows(0)("Cod_Plan_Paie"), "")
                Mod_Paiement.SelectedValue = IsNull(.Rows(0)("Mod_Paiement"), "")
                Cod_Preparation_Text.Text = IsNull(.Rows(0)("Cod_Preparation"), "")
                Num_List_Avance_txt.Text = IsNull(.Rows(0)("Num_List_Avance"), "")
                Traite_Check.Checked = IsNull(.Rows(0)("Traite"), False)
                Cloture_D.Enabled = Not CBool(IsNull(.Rows(0)("Cloture"), False))
                Cpt_Bnk_chk.Checked = CBool(IsNull(.Rows(0)("Cpt_Bnk"), False))
            Else
                Lib_Paiement_txt.Text = ""
                Dat_Paiement.Value = Now.Date.ToShortDateString
                Cod_Caisse_Bank_Text.Text = ""
                Bank_txt.Text = ""
                Cod_Plan_Paie_Text.Text = ""
                Mod_Paiement.SelectedIndex = -1
                Cod_Preparation_Text.Text = ""
                Num_List_Avance_txt.Text = ""
                Traite_Check.Checked = False
                Cloture_D.Enabled = True
                R_Paie.Checked = True
                R_Avance.Checked = True
                Cpt_Bnk_chk.Checked = True
            End If
        End With
        If Cod_Paiement_txt.Text <> "" Then
            Dim Sqlstr As String = "SELECT  p.Matricule,a.Nom_Agent +' ' +a.Prenom_Agent as Nom, Salaire as 'Montant Dû',
                isnull(Paye,0)  as 'Payé', Montant as 'Montant à payer', p.Banque,p.RIB, p.Compte_Bancaire as Compte,  
                p.Agence,isnull(p.Salaire_Domicilie,'false') as Domicilié ,RowId
                FROM     RH_Paiement e left join RH_Paiement_Detail p on e.Cod_Paiement=p.Cod_Paiement and e.id_Societe =p.id_Societe
                left join RH_Agent a on p.Matricule =a.Matricule and p.id_Societe =a.id_Societe 
                outer apply (select sum(isnull( Montant,0)) as Paye
				from RH_Paiement ee inner join RH_Paiement_Detail d on ee.Cod_Paiement=d.Cod_Paiement and ee.id_Societe =d.id_Societe
				where ee.id_Societe =p.id_Societe  and d.Matricule=p.Matricule and d.Cod_Paiement<>p.Cod_Paiement 
                and ISNULL(e.Cod_Preparation,'')=ISNULL(ee.Cod_Preparation,'') and ISNULL(e.Num_List_Avance ,'')=ISNULL(ee.Num_List_Avance ,'') )o
                where p.Cod_Paiement='" & Cod_Paiement_txt.Text & "' and p.id_Societe=" & Societe.id_Societe & " order by Matricule"
            GRD(Sqlstr, Grd_Paiement)
            With Grd_Paiement
                Dim ind(.DisplayedColumnCount(False)) As Integer
                Dim nb As Integer = 0
                .Columns("RowId").Visible = False
                .ReadOnly = False
                CType(.DataSource, DataTable).Columns("Montant à payer").ReadOnly = False
                .RowHeadersVisible = True
                For i = 0 To .DisplayedColumnCount(False) - 1
                    If .Columns(i).Visible Then ind(nb) = .Columns(i).Index
                    nb += 1
                Next
                ReDim Preserve ind(nb - 1)
                Grd_Paiement.setFilter(ind)
                .AllowUserToDeleteRows = True
            End With
        Else
            RequestDetail()
        End If

        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Paiement_txt.Text)
            Code = Cod_Paiement_txt.Text
        Else
            Code = ""
        End If
        If Not Cloture_D.Enabled Then
            Save_D.Enabled = False
            Del_D.Enabled = False
            Request_D.Enabled = False
        End If
        Cloture_D.Image = If(Cloture_D.Enabled, My.Resources.btn_unlock, My.Resources.btn_lock)
        TblSource = Grd_Paiement.DataSource
    End Sub
    Sub RequestDetail()
        GRD("exec Sys_Paiement '" & Cod_Preparation_Text.Text & "','" & Num_List_Avance_txt.Text & "','" & Mod_Paiement.SelectedValue & "'," & Societe.id_Societe, Grd_Paiement)
        With Grd_Paiement
            Dim ind(.DisplayedColumnCount(False) - 1) As Integer
            Dim nb As Integer = 0
            .ReadOnly = False
            CType(.DataSource, DataTable).Columns("Montant à payer").ReadOnly = False
            .RowHeadersVisible = True
            For i = 0 To .DisplayedColumnCount(False) - 1
                ind(0) = .Columns(i).Index
            Next
            ReDim Preserve ind(nb - 1)
            Grd_Paiement.setFilter(ind)
            CType(.DataSource, DataTable).Columns.Add("RowId")
            .Columns("RowId").Visible = False
            .AllowUserToDeleteRows = True
            TblSource = .DataSource
        End With
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If Cod_Paiement_txt.Text <> "" Then Return
        Appel_Zoom1("MS012", Cod_Plan_Paie_Text, Me)
    End Sub

    Private Sub Cod_Plan_Paie_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        Cod_Preparation_Text.Text = ""
        Num_List_Avance_txt.Text = ""
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If Cod_Paiement_txt.Text <> "" Then Return
        Appel_Zoom1("MS146", Num_List_Avance_txt, Me, "Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "'")
    End Sub
    Private Sub Num_List_Avance_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_List_Avance_txt.TextChanged
        R_Avance.Checked = (Num_List_Avance_txt.Text <> "")
        If R_Avance.Checked And Cod_Paiement_txt.Text = "" Then
            Cod_Preparation_Text.Text = ""
            RequestDetail()
        End If
    End Sub
    Sub Enregistrer()
        Saving(False)
    End Sub
    Function Saving(avecValidation As Boolean) As Boolean
        Dim TypCaisseBank As String = FindLibelle("Typ_Caisse_Bank", "Cod_Caisse_Bank", Cod_Caisse_Bank_Text.Text, "Compta_Caisse_Banque")
        If Not Cloture_D.Enabled Then Return False
        If Cod_Preparation_Text.Text = "" And Num_List_Avance_txt.Text = "" Then
            ShowMessageBox("Veuillez renseigner la nature du paiement", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
        If Cod_Caisse_Bank_Text.Text = "" Then
            ShowMessageBox("Veuillez renseigner le code caisse ou banque d'origine des fonds", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
        If Mod_Paiement.SelectedIndex = -1 Then
            ShowMessageBox("Veuillez renseigner le mode de paiement", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
        If Mod_Paiement.SelectedValue = "ESPC" And TypCaisseBank <> "C" Then
            ShowMessageBox("Incohérence entre le mode de paiement et l'origine des fonds", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
        If Mod_Paiement.SelectedValue <> "ESPC" And TypCaisseBank <> "B" Then
            ShowMessageBox("Incohérence entre le mode de paiement et l'origine des fonds", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
        If Not EstDate(Dat_Paiement.Value) Then
            ShowMessageBox("Erreur date de paiement", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
        With Grd_Paiement
            Dim dt As DataTable = CType(.DataSource, DataTable).DefaultView.ToTable(True, {"Matricule", "Montant Dû", "Payé", "Montant à payer"})
            dt = dt.AsEnumerable().GroupBy(Function(r) r.Field(Of String)("Matricule")).Select(Function(g)
                                                                                                   Dim row = dt.NewRow()
                                                                                                   row("Matricule") = g.Key
                                                                                                   row("Montant Dû") = g.Max(Function(r) r.Field(Of Double)("Montant Dû"))
                                                                                                   row("Payé") = g.Sum(Function(r) r.Field(Of Double)("Payé"))
                                                                                                   row("Montant à payer") = g.Sum(Function(r) r.Field(Of Double)("Montant à payer"))
                                                                                                   Return row
                                                                                               End Function).CopyToDataTable()
            Dim dtr As DataRow() = dt.Select("[Payé]+[Montant à payer]>[Montant Dû]")
            If dtr.Length > 0 Then
                ShowMessageBox("le montant à payer est incohérent avec le montant dû pour le matricule " & dtr(0)("Matricule"), "Vérifications", MessageBoxButtons.OK, msgIcon.Error)
                dt = CType(.DataSource, DataTable)
                dtr = dt.Select("Matricule='" & dtr(0)("Matricule") & "'")
                Dim r As Integer = 0
                For i = 0 To dtr.Length - 1
                    r = dt.Rows.IndexOf(dtr(i))
                    If i = 0 Then
                        .FirstDisplayedCell = .Item("Matricule", r)
                    End If
                Next

                Return False
            End If
            For i = 0 To .RowCount - 1
                If TypCaisseBank = "B" Then
                    If IsNull(.Item("Banque", i).Value, "") = "" Then
                        ShowMessageBox("Banque non renseignée", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
                        .FirstDisplayedCell = .Item("Banque", i)
                        .Rows(i).Selected = True
                        Return False
                    ElseIf IsNull(.Item("RIB", i).Value, "") = "" Or Not IsNumeric(IsNull(.Item("RIB", i).Value, "")) Or IsNull(.Item("RIB", i).Value, "").Length <> 24 Then
                        ShowMessageBox("RIB erroné", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
                        .FirstDisplayedCell = .Item("RIB", i)
                        .Rows(i).Selected = True
                        Return False
                    ElseIf (IsNull(.Item("Compte", i).Value, "") = "" Or Not IsNumeric(IsNull(.Item("Compte", i).Value, ""))) And Cpt_Bnk_chk.Checked Then
                        ShowMessageBox("Compte erroné", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
                        .FirstDisplayedCell = .Item("Compte", i)
                        .Rows(i).Selected = True
                        Return False
                    End If
                End If
                If CDbl(IsNull(.Item("Montant à payer", i).Value, 0)) <= 0 Then
                    ShowMessageBox("Montant montant à payer erroné ou null", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
                    .FirstDisplayedCell = .Item("Montant à payer", i)
                    .Rows(i).Selected = True
                    Return False
                End If
            Next
        End With
        Dim CodPaiement As String = Cod_Paiement_txt.Text
        If CodPaiement = "" Then
            Dim Cp As New ADODB.Recordset
            Cp = CnExecuting("select Top 1 convert(int,right(Cod_Paiement,6)) from RH_Paiement where id_Societe=" & Societe.id_Societe & " order by Cod_Paiement Desc")
            If Not Cp.EOF Then
                CodPaiement = "CP" & Societe.id_Societe & "-" & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
            Else
                CodPaiement = "CP" & Societe.id_Societe & "-000001"
            End If
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from RH_Paiement where Cod_Paiement='" & Cod_Paiement_txt.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
            rs("Cod_Paiement").Value = CodPaiement
            rs("id_Societe").Value = Societe.id_Societe
        Else
            rs.Update()
        End If
        rs("Lib_Paiement").Value = Lib_Paiement_txt.Text
        rs("Dat_Paiement").Value = Dat_Paiement.Value.ToShortDateString
        rs("Cod_Caisse_Bank").Value = Cod_Caisse_Bank_Text.Text
        rs("Bank").Value = Bank_txt.Text
        rs("Typ_Caisse_Bank").Value = TypCaisseBank
        rs("Mod_Paiement").Value = Mod_Paiement.SelectedValue
        rs("Cod_Preparation").Value = Cod_Preparation_Text.Text
        rs("Cod_Plan_Paie").Value = Cod_Plan_Paie_Text.Text
        rs("Num_List_Avance").Value = Num_List_Avance_txt.Text
        rs("Cpt_Bnk").Value = Cpt_Bnk_chk.Checked
        rs("Cloture").Value = avecValidation
        rs("Traite").Value = IIf(avecValidation, Traite_Check.Checked, False)
        rs("Cloture_Par").Value = IIf(avecValidation, theUser.Login, "")
        rs("Dat_Cloture").Value = IIf(avecValidation, Now, Nothing)
        rs("Dat_Modif").Value = Now
        rs("Modified_by").Value = theUser.Login
        rs.Update()
        rs.Close()
        Dim swhere As String = ""
        With Grd_Paiement
            For i = 0 To .RowCount - 1
                If IsNull(.Item("RowId", i).Value, "") <> "" Then
                    swhere &= IIf(swhere = "", "", ",") & IsNull(.Item("RowId", i).Value, "")
                End If
            Next
            If swhere <> "" Then
                CnExecuting("delete from RH_Paiement_Detail where RowId not in (" & swhere & ") and Cod_Paiement='" & CodPaiement & "' and id_Societe=" & Societe.id_Societe)
            Else
                CnExecuting("delete from RH_Paiement_Detail where Cod_Paiement='" & Cod_Paiement_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            End If
            For i = 0 To .RowCount - 1
                If IsNull(.Item("Matricule", i).Value, "") <> "" And CDbl(IsNull(.Item("Montant à payer", i).Value, 0)) > 0 Then
                    rs.Open("select * from RH_Paiement_Detail where RowId='" & IsNull(.Item("RowId", i).Value, -1) & "'  and Cod_Paiement='" & CodPaiement & "' and id_Societe=" & Societe.id_Societe)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Dat_Crea").Value = Now
                        rs("Created_By").Value = theUser.Login
                        rs("Cod_Paiement").Value = CodPaiement
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Matricule").Value = .Item("Matricule", i).Value
                    Else
                        rs.Update()
                    End If
                    rs("Montant").Value = .Item("Montant à payer", i).Value
                    rs("Salaire").Value = .Item("Montant dû", i).Value
                    rs("Compte_Bancaire").Value = .Item("Compte", i).Value
                    rs("RIB").Value = .Item("RIB", i).Value
                    rs("Banque").Value = .Item("Banque", i).Value
                    rs("Agence").Value = .Item("Agence", i).Value
                    rs("Salaire_Domicilie").Value = .Item("Domicilié", i).Value
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With
        If Cod_Paiement_txt.Text = "" Then
            Cod_Paiement_txt.Text = CodPaiement
        Else
            Request()
        End If
        Return True
    End Function
    Sub Cloturer()
        If ShowMessageBox("Etes-vous sûr de vouloir clôturer?", "Clôture", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
        Saving(True)
    End Sub
    Private Sub R_Paie_CheckedChanged(sender As Object, e As EventArgs) Handles R_Paie.CheckedChanged
        If R_Paie.Checked Then Num_List_Avance_txt.ResetText()
    End Sub
    Private Sub R_Avance_CheckedChanged(sender As Object, e As EventArgs) Handles R_Avance.CheckedChanged
        If R_Avance.Checked Then Cod_Preparation_Text.ResetText()
    End Sub
    Sub Requesting()
        If Not Save_D.Enabled Then Return
        If Grd_Paiement.RowCount > 0 Then
            If ShowMessageBox("Attention: votre grille contient des enregistrements, si vous continuez ils seront effacés." & vbCancel & "Voulez-vous continuer?", "Attention", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        End If
        If Mod_Paiement.SelectedIndex < 0 Then
            ShowMessageBox("Veuillez sélectionner le mode de paiement", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Mod_Paiement.DroppedDown = True
            Return
        End If
        If CnExecuting("select COUNT(*) from RH_Paiement where ISNULL(Cloture,0)=0 and id_Societe =" & Societe.id_Societe).Fields(0).Value > 0 Then
            ShowMessageBox("Au moins un ordre de paiement est non clôturé.", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        RequestDetail()
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS147", Cod_Paiement_txt, Me)
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        ChargementCombo()
        Lib_Paiement_txt.Select()
        R_Paie.Checked = True
        Cod_Caisse_Bank_Text.Text = CnExecuting("select isnull((select top 1 Cod_Caisse_Bank from Compta_Caisse_Banque where Typ_Caisse_Bank='B' and id_Societe=" & Societe.id_Societe & "),'')").Fields(0).Value
        Cod_Plan_Paie_Text.Text = CnExecuting("select isnull((select top 1 Cod_Plan_Paie  from RH_Param_Plan_Paie where  id_Societe=" & Societe.id_Societe & "),'')").Fields(0).Value
        Mod_Paiement.SelectedValue = "VIRE"
        Cpt_Bnk_chk.Checked = True
    End Sub
    Private Sub RH_Paiement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargementCombo()
    End Sub
    Sub Deleting()
        Diviseur_delete("RH_Paiement", "Cod_Paiement", "Cod_Paiement", Cod_Paiement_txt, Me, True)
        TblSource = Nothing
    End Sub
    Private Sub RH_Paiement_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
    Private Sub Grd_Avance_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Paiement.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Grd_Avance_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grd_Paiement.EditingControlShowing
        With Grd_Paiement
            If .CurrentCell.ColumnIndex = .Columns("Montant à payer").Index Then
                AddHandler e.Control.KeyPress, AddressOf PoitToComma
            Else
                RemoveHandler e.Control.KeyPress, AddressOf PoitToComma
            End If
        End With
    End Sub
    Sub PoitToComma(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "." Then e.KeyChar = ","
    End Sub

    Private Sub R_RIB1_CheckedChanged(sender As Object, e As EventArgs) Handles R_RIB1.CheckedChanged
        Try
            If R_RIB1.Checked Then
                With Grd_Paiement
                    If TblSource Is Nothing Then
                        TblSource = .DataSource
                    End If
                    Filtre_chk.Checked = True
                    Dim dv As DataView = TblSource.DefaultView
                    dv.RowFilter = "RIB<>'' " & IIf(R_BNK0.Checked, " and Banque=''", "") & IIf(R_BNK1.Checked, " and Banque<>''", "")
                    .DataSource = dv.ToTable
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub R_RIB0_CheckedChanged(sender As Object, e As EventArgs) Handles R_RIB0.CheckedChanged
        Try
            If R_RIB0.Checked Then
                With Grd_Paiement
                    If TblSource Is Nothing Then
                        TblSource = .DataSource
                    End If
                    Filtre_chk.Checked = True
                    Dim dv As DataView = TblSource.DefaultView
                    dv.RowFilter = "RIB=''" & IIf(R_BNK0.Checked, " and Banque=''", "") & IIf(R_BNK1.Checked, " and Banque<>''", "")
                    .DataSource = dv.ToTable
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub R_BNK1_CheckedChanged(sender As Object, e As EventArgs) Handles R_BNK1.CheckedChanged
        Try
            If R_BNK1.Checked Then
                With Grd_Paiement
                    If TblSource Is Nothing Then
                        TblSource = .DataSource
                    End If
                    Filtre_chk.Checked = True
                    Dim dv As DataView = TblSource.DefaultView
                    dv.RowFilter = "Banque<>''" & IIf(R_RIB0.Checked, " and RIB=''", "") & IIf(R_RIB1.Checked, " and RIB<>''", "")
                    .DataSource = dv.ToTable
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub R_BNK0_CheckedChanged(sender As Object, e As EventArgs) Handles R_BNK0.CheckedChanged
        Try
            If R_BNK0.Checked Then
                With Grd_Paiement
                    If TblSource Is Nothing Then
                        TblSource = .DataSource
                    End If
                    Filtre_chk.Checked = True
                    Dim dv As DataView = TblSource.DefaultView
                    dv.RowFilter = "Banque=''" & IIf(R_RIB0.Checked, " and RIB=''", "") & IIf(R_RIB1.Checked, " and RIB<>''", "")
                    .DataSource = dv.ToTable
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Filtre_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Filtre_chk.CheckedChanged
        Try
            If Not Filtre_chk.Checked Then
                If Not TblSource Is Nothing Then
                    With Grd_Paiement
                        Dim dv As DataView = TblSource.DefaultView
                        dv.RowFilter = ""
                        .DataSource = dv.ToTable
                        TblSource = Nothing
                    End With
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class