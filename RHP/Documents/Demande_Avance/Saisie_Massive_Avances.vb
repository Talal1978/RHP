Public Class Saisie_Massive_Avances
    Dim Code As String = ""
    dim New_D as ud_btn
    dim Refresh_D as ud_btn
    dim Save_D as ud_btn
    dim Import_D as ud_btn
    dim Cloture_D as ud_btn
    dim Del_D as ud_btn
    dim Servir_D as ud_btn

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If Num_List_Avance_txt.Text <> "" Then Return
        Appel_Zoom1("MS012", Cod_Plan_Paie_Text, Me)
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS146", Num_List_Avance_txt, Me)
    End Sub

    Private Sub Num_List_Avance_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_List_Avance_txt.TextChanged
        Request()
    End Sub
    Sub Request()
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_List_Avance_txt.Text, Me))
        Dim Tbl As DataTable = DATA_READER_GRD("select * from RH_Paie_Avance_Liste where Num_List_Avance= '" & Num_List_Avance_txt.Text & "'")
        With Tbl
            If .Rows.Count > 0 Then
                Lib_List_Avance_txt.Text = IsNull(.Rows(0)("Lib_List_Avance"), "")
                Dat_Avance.Value = IsNull(.Rows(0)("Dat_Avance"), Now.Date)
                Cod_Plan_Paie_Text.Text = IsNull(.Rows(0)("Cod_Plan_Paie"), "")
                Cloture_D.Enabled = Not CBool(IsNull(.Rows(0)("Cloture"), False))
            Else
                Lib_List_Avance_txt.Text = ""
                Dat_Avance.Value = Now.ToShortDateString
                Cod_Plan_Paie_Text.Text = ""
                Cloture_D.Enabled = True
            End If
        End With
        If Num_List_Avance_txt.Text <> "" Then
            Dim Sqlstr As String = "select Matricule, Nom , ISNULL(Dernier_Salaire,0)  as 'Dernier salaire net', ISNULL( Montant_Avance,0) as Avance 
from RH_Paie_Avance_Liste e left join RH_Paie_Avance p on p.Num_List_Avance =e.Num_List_Avance and e.id_Societe =p.id_Societe 
outer apply (select Nom_Agent +' ' +Prenom_Agent as Nom from RH_Agent where id_Societe =e.id_Societe  and p.Matricule=Matricule)a		
where e.Num_List_Avance ='" & Num_List_Avance_txt.Text & "' and e.id_Societe=" & Societe.id_Societe & " order by Matricule"
            GRD(Sqlstr, Grd_Avance)
            With Grd_Avance
                .ReadOnly = False
                With CType(.DataSource, DataTable)
                    .Columns("Avance").ReadOnly = False
                    .Columns.Add("Pourcentage", GetType(Decimal), "iif([Dernier salaire net]>0,([Avance]/[Dernier salaire net])*100,0)")
                End With
                With .Columns("Pourcentage").DefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleRight
                    .Format = "N2"
                End With
                Dim ind(.ColumnCount - 1) As Integer
                .RowHeadersVisible = True
                For i = 0 To .ColumnCount - 1
                    If .Columns(i).Visible Then ind(i) = .Columns(i).Index
                Next
                Grd_Avance.setFilter(ind)
                .AllowUserToDeleteRows = True
            End With
        Else
            RequestDetail()
        End If
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_List_Avance_txt.Text)
            Code = Num_List_Avance_txt.Text
        Else
            Code = ""
        End If
        If Not Cloture_D.Enabled Then
            Save_D.Enabled = False
            Del_D.Enabled = False
            Cloture_D.Image = My.Resources.btn_lock
        Else
            Cloture_D.Image = My.Resources.btn_unlock
        End If
    End Sub
    Sub Requesting()
        If Grd_Avance.Rows.Count > 0 Then
            If ShowMessageBox("Attention: Votre liste contient déjà des avances saisies. Si vous continuez elles seront écrasées.", "Charger de nouveau", MessageBoxButtons.OKCancel, msgIcon.Warning) = MsgBoxResult.Cancel Then Return
        End If
        If Cod_Plan_Paie_Text.Text.Trim = "" Then
            ShowMessageBox("Plan non renseigné", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        RequestDetail()
    End Sub

    Sub RequestDetail()

        If Cod_Plan_Paie_Text.Text.Trim = "" Then
            ShowMessageBox("Veuillez choisir un plan.")
            Return
        End If
        Cursor = Cursors.WaitCursor
        With Grd_Avance
            Dim Tbl As DataTable = RequestTbl(Societe.id_Societe, Cod_Plan_Paie_Text.Text)
            With Tbl
                .Columns("Avance").ReadOnly = False
                .Columns.Add("Pourcentage", GetType(Decimal), "iif([Dernier salaire net]>0,CONVERT( ([Avance]/[Dernier salaire net])*10000, System.Int64 ) / 100,0)")
            End With
            .DataSource = Tbl
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
        Cursor = Cursors.Default

    End Sub
    Sub Enregistrer()
        Cursor = Cursors.WaitCursor
        Saving(False)
        Cursor = Cursors.Default
    End Sub
    Function Saving(avecValidation As Boolean) As Boolean
        If Not Cloture_D.Enabled Then Return False
        Dim rnd As New Random()
        Dim Flg_Maj As Integer = rnd.Next(123, 9563)
        If Cod_Plan_Paie_Text.Text.Trim = "" Then
            ShowMessageBox("Renseignez le plan de paie", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
        If Lib_List_Avance_txt.Text.Trim = "" Then
            ShowMessageBox("Renseignez le libellé", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If
        If CnExecuting("Select count(*) from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            ShowMessageBox("Une préparation de la paie est en cours. Réessayez plus tard.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End If
        With Grd_Avance
            For i = 0 To .RowCount - 1
                If CDbl(IsNull(.Item("Pourcentage", i).Value, 0)) < 0 Or CDbl(IsNull(.Item("Pourcentage", i).Value, 0)) > 100 Then
                    ShowMessageBox("Montant de l'avance incohérent avec le salaire", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
                    .FirstDisplayedCell = .Item("Pourcentage", i)
                    .Rows(i).Selected = True
                    Return False
                End If
            Next
        End With
        Dim NumAvce As String = Num_List_Avance_txt.Text
        If NumAvce = "" Then
            Dim Cp As New ADODB.Recordset
            Cp = CnExecuting("select Top 1 convert(int,right(Num_List_Avance,6)) from RH_Paie_Avance_Liste where id_Societe=" & Societe.id_Societe & " order by Num_List_Avance Desc")
            If Not Cp.EOF Then
                NumAvce = "MV" & Societe.id_Societe & "-" & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
            Else
                NumAvce = "MV" & Societe.id_Societe & "-000001"
            End If
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from RH_Paie_Avance_Liste where Num_List_Avance='" & Num_List_Avance_txt.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
            rs("Num_List_Avance").Value = NumAvce
            rs("id_Societe").Value = Societe.id_Societe
        Else
            rs.Update()
        End If
        rs("Lib_List_Avance").Value = Lib_List_Avance_txt.Text
        rs("Dat_Avance").Value = Dat_Avance.Value.ToShortDateString
        rs("Cod_Plan_Paie").Value = Cod_Plan_Paie_Text.Text
        rs("Cloture").Value = avecValidation
        rs("Cloture_Par").Value = IIf(avecValidation, theUser.Login, "")
        rs("Dat_Cloture").Value = IIf(avecValidation, Now, Nothing)
        rs("Dat_Modif").Value = Now
        rs("Modified_by").Value = theUser.Login
        rs.Update()
        rs.Close()
        Dim swhere As String = ""
        With Grd_Avance
            For i = 0 To .RowCount - 1
                If IsNull(.Item("Matricule", i).Value, "") <> "" And CDbl(IsNull(.Item("Avance", i).Value, 0)) > 0 Then
                    rs.Open("select * from RH_Paie_Avance where isnull(Matricule,'')='" & .Item("Matricule", i).Value & "'  and isnull(Num_List_Avance,'')='" & NumAvce & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Dat_Crea").Value = Now
                        rs("Created_By").Value = theUser.Login
                        rs("Num_List_Avance").Value = NumAvce
                        rs("Num_Avance").Value = NumAvce & "_" & i + 1
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Matricule").Value = .Item("Matricule", i).Value
                    Else
                        rs.Update()
                    End If
                    rs("Flg_Maj").Value = Flg_Maj
                    rs("Montant_Avance").Value = .Item("Avance", i).Value
                    rs("Dernier_Salaire").Value = .Item("Dernier salaire net", i).Value
                    rs("Dat_Demande").Value = Dat_Avance.Value.ToShortDateString
                    rs("Dat_Modif").Value = Now
                    rs("Modified_By").Value = theUser.Login
                    If avecValidation Then
                        rs("Statut").Value = "VA"
                    End If
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With
        CnExecuting("delete from RH_Paie_Avance where isnull(Num_List_Avance,'')='" & NumAvce & "' and Flg_Maj<>" & Flg_Maj & " and id_Societe=" & Societe.id_Societe)
        If Num_List_Avance_txt.Text = "" Then
            Num_List_Avance_txt.Text = NumAvce
        Else
            Request()
        End If
        Return True
    End Function
    Sub Cloturer()
        If ShowMessageBox("Etes-vous sûr de vouloir clôturer cette liste d'avances?", "Clôture", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
        Saving(True)
    End Sub
    Sub Nouveau()
        Reset_Form(EntPnl)
        Save_D.Enabled = True
        Del_D.Enabled = True
        Cloture_D.Enabled = True
        Lib_List_Avance_txt.Select()
        Cod_Plan_Paie_Text.Text = CnExecuting("select isnull((select top 1 Cod_Plan_Paie  from RH_Param_Plan_Paie where  id_Societe=" & Societe.id_Societe & "),'')").Fields(0).Value
        With Grd_Avance
            Dim Tbl As DataTable = RequestTbl()
            With Tbl
                .Columns("Avance").ReadOnly = False
                .Columns.Add("Pourcentage", GetType(Decimal), "iif([Dernier salaire net]>0,CONVERT( ([Avance]/[Dernier salaire net])*10000, System.Int64 ) / 100,0)")
            End With
            .DataSource = Tbl
        End With

    End Sub
    Private Sub Grd_Avance_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Avance.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Grd_Avance_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grd_Avance.EditingControlShowing
        With Grd_Avance
            If .CurrentCell.ColumnIndex = .Columns("Avance").Index Then
                AddHandler e.Control.KeyPress, AddressOf PoitToComma
            Else
                RemoveHandler e.Control.KeyPress, AddressOf PoitToComma
            End If
        End With

    End Sub
    Sub PoitToComma(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "." Then e.KeyChar = ","
    End Sub
    Private Sub mE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
    Sub Importer()
        If Cod_Plan_Paie_Text.Text.Trim = "" Then
            ShowMessageBox("Plan non renseigné", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
Reprendre:
        If Grd_Avance.RowCount = 0 Then
            If ShowMessageBox("Votre liste est vide, voulez-vous la charger?", "Vérification", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return
            RequestDetail()
            If Grd_Avance.RowCount = 0 Then
                ShowMessageBox("Echec de chargement. Votre liste est toujours vide.", "Vérification", MessageBoxButtons.OK, msgIcon.Question)
                Return
            End If
        End If
        Dim f As New Saisie_Massive_Avances_Import
        With f
            .frm_Avance = Me
            newShowEcran(f, True)
        End With
    End Sub
    Sub Servir()
        If Cod_Plan_Paie_Text.Text.Trim = "" Then
            ShowMessageBox("Plan non renseigné", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Grd_Avance.RowCount = 0 Then
            ShowMessageBox("Votre liste est vide, voulez-vous la charger?", "Vérification", MessageBoxButtons.OK, msgIcon.Question)
            Return
        End If
        If Num_List_Avance_txt.Text.Trim = "" Then
            ShowMessageBox("Votre liste est non encore créée.", "Vérification", MessageBoxButtons.OK, msgIcon.Question)
            Return
        End If
        If Cloture_D.Enabled Then
            ShowMessageBox("Votre liste n'est pas encore clôturée", "Vérification", MessageBoxButtons.OK, msgIcon.Question)
            Return
        End If
        Dim f As New RH_Paiement
        With f
            .Cod_Plan_Paie_Text.Text = Cod_Plan_Paie_Text.Text
            .Lib_Paiement_txt.Text = "Paiement des avances : " & Lib_List_Avance_txt.Text
            .R_Avance.Checked = True
            .Num_List_Avance_txt.Text = Num_List_Avance_txt.Text
            .RequestDetail()
            newShowEcran(f)
        End With
    End Sub

    Private Sub RH_Avance_Liste_Load(sender As Object, e As EventArgs) Handles Me.Load
        New_D = dictButtons("New_D")
        Refresh_D = dictButtons("Refresh_D")
        Save_D = dictButtons("Save_D")
        Import_D = dictButtons("Import_D")
        Cloture_D = dictButtons("Cloture_D")
        Del_D = dictButtons("Del_D")
        Servir_D = dictButtons("Servir_D")
        With Grd_Avance
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ContextMenuStrip = AddContextMenu(False, True, True, True, False, False, True, False)
            .AllowUserToAddRows = False
            Dim Tbl As DataTable = RequestTbl()
            With Tbl
                .Columns("Avance").ReadOnly = False
                .Columns.Add("Pourcentage", GetType(Decimal), "iif([Dernier salaire net]>0,CONVERT( ([Avance]/[Dernier salaire net])*10000, System.Int64 ) / 100,0)")
            End With
            .DataSource = Tbl
            With .Columns("Pourcentage")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            With .Columns("Dernier salaire net")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            With .Columns("Avance")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            Grd_Avance.setFilter({0, 1, 2, 3})
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .AllowUserToDeleteRows = True
        End With
    End Sub
    Function RequestTbl(Optional idSoc As Integer = -999, Optional CodPlan As String = "sqczeqsq") As DataTable
        Dim SqlStr As String = "declare @EVSalNet as nvarchar(50) 
select @EVSalNet=SalNet from RH_Param_Plan_Paie where id_Societe =" & idSoc & " and Cod_Plan_Paie ='" & CodPlan & "' 
select  Matricule,Nom_Agent +' ' +Prenom_Agent as Nom , isnull(SalNet,0) as 'Dernier salaire net',1*0.00 as Avance
			from RH_Agent a
outer apply (select top 1 isnull(Valeur,0) as SalNet from RH_Preparation_Paie_Detail d 
			where id_Societe =" & idSoc & " and d.Matricule=a.Matricule and Cod_Rubrique=@EVSalNet order by Cod_Preparation desc)s
where id_Societe =" & idSoc & " and Plan_Paie ='" & CodPlan & "' and ISNULL(a.Droit_Paie ,0)=1"
        Return DATA_READER_GRD(SqlStr)
    End Function
    Sub Deleting()
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette liste?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Paie_Avance_Liste where Num_List_Avance='" & Num_List_Avance_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        CnExecuting("delete from RH_Paie_Avance where isnull(Num_List_Avance,'')='" & Num_List_Avance_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Reset_Form(Me)
    End Sub
End Class