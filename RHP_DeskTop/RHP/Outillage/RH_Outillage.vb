
Public Class RH_Outillage
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Sub Chargement()
        If Save_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Next_D = dictButtons("Next_D")
            Back_D = dictButtons("Back_D")
            Last_D = dictButtons("Last_D")
            First_D = dictButtons("First_D")
        End If
        ChargementCombo()
    End Sub
    Sub ChargementCombo()
        If Typ_Outillage_cmb.Items.Count = 0 Then Typ_Outillage_cmb.fromRubrique("Typ_Outillage")
    End Sub
    Private Sub RH_Outillage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Chargement()
        Requesting()
    End Sub
    Private Sub RH_Outillage_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Save_D IsNot Nothing AndAlso Save_D.Enabled Then Enregistrer()
        End If
    End Sub
    Sub Requesting()
        GRD("select Cod_Outillage as Code, Lib_Outillage as [Désignation], dbo.FindRubrique('Typ_Outillage',Typ_Outillage) as [Type], Num_Serie as [N° Série], Qte_Initial as [Qté Initiale], Qte_Disponible as [Qté Disponible] " &
            " from RH_Outillage_Dispo where id_Societe=" & Societe.id_Societe & " order by Cod_Outillage", Grd_Outillage)
        AjouterMenuAffectations()
    End Sub
    Sub AjouterMenuAffectations()
        If Grd_Outillage.ContextMenuStrip Is Nothing Then Return
        Dim item As New ToolStripMenuItem
        With item
            .Text = "Agents bénéficiaires"
            .Image = My.Resources.btn_affect
            AddHandler .Click, Sub()
                                   If Grd_Outillage.CurrentRow IsNot Nothing AndAlso Grd_Outillage.CurrentRow.Index >= 0 Then
                                       VoirAffectations(IsNull(Grd_Outillage.Item("Code", Grd_Outillage.CurrentRow.Index).Value, ""))
                                   End If
                               End Sub
        End With
        Grd_Outillage.ContextMenuStrip.Items.Add(New ToolStripSeparator())
        Grd_Outillage.ContextMenuStrip.Items.Add(item)
    End Sub
    Sub Request()
        Chargement()
        If Code <> "" Then
            CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
            Code = ""
        End If
        DroitAcces(Me, DroitModify_Fiche(Cod_Outillage_txt.Text, Me))
        Dim SqlStr As String = "SELECT * FROM RH_Outillage where Cod_Outillage='" & Cod_Outillage_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        With Tbl
            If .Rows.Count > 0 Then
                Lib_Outillage_txt.Text = IsNull(.Rows(0)("Lib_Outillage"), "")
                Typ_Outillage_cmb.SelectedValue = IsNull(.Rows(0)("Typ_Outillage"), "")
                Num_Serie_txt.Text = IsNull(.Rows(0)("Num_Serie"), "")
                Qte_Initial_txt.Text = IsNull(.Rows(0)("Qte_Initial"), "0")
                Qte_Dispo_txt.Text = IsNull(FindLibelle("Qte_Disponible", "Cod_Outillage", Cod_Outillage_txt.Text, "RH_Outillage_Dispo"), "0")
            ElseIf Cod_Outillage_txt.Text.Trim = "" Then
                Reset_Form(GroupBox1)
            End If
        End With
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Outillage_txt.Text)
            Code = Cod_Outillage_txt.Text
        End If
    End Sub
    Sub Nouveau()
        Reset_Form(GroupBox1)
        With Cod_Outillage_txt
            Enabling(Cod_Outillage_txt, True)
            .Select()
        End With
    End Sub
    Sub Enregistrer()
        Dim rsl As savingResult = Saving()
        ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
        If rsl.result Then
            Nouveau()
            Requesting()
        End If
    End Sub
    Function Saving() As savingResult
        Try
            If Cod_Outillage_txt.Text.Trim = "" Then
                Return New savingResult With {.result = False, .message = "Code outillage non renseigné"}
            End If
            If Lib_Outillage_txt.Text.Trim = "" Then
                Return New savingResult With {.result = False, .message = "Désignation non renseignée"}
            End If
            If Not IsNumeric(Qte_Initial_txt.Text) OrElse CDbl(Qte_Initial_txt.Text) < 0 Then
                Return New savingResult With {.result = False, .message = "Quantité initiale invalide"}
            End If
            Dim rs As New ADODB.Recordset
            rs.Open("select * from RH_Outillage where Cod_Outillage='" & Cod_Outillage_txt.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Cod_Outillage").Value = Cod_Outillage_txt.Text
                rs("id_Societe").Value = Societe.id_Societe
                rs("Dat_Crea").Value = Now
                rs("Created_By").Value = theUser.Login
            Else
                rs.Update()
            End If
            rs("Lib_Outillage").Value = Lib_Outillage_txt.Text
            rs("Typ_Outillage").Value = If(Typ_Outillage_cmb.SelectedIndex >= 0, Typ_Outillage_cmb.SelectedValue, "")
            rs("Num_Serie").Value = Num_Serie_txt.Text
            rs("Qte_Initial").Value = CDbl(Qte_Initial_txt.Text)
            rs("Dat_Modif").Value = Now
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            Return New savingResult With {.result = True, .message = "Enregistré avec succès."}
        Catch ex As Exception
            Return New savingResult With {.result = False, .message = ex.Message}
        End Try
    End Function
    Sub Deleting()
        If Cod_Outillage_txt.Text = "" Then Return
        If CnExecuting("select count(*) from RH_Outillage_Mouvement_Detail where Cod_Outillage='" & Cod_Outillage_txt.Text & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            ShowMessageBox("Cet outillage est utilisé dans des mouvements. Suppression impossible.", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cet outillage?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Outillage where Cod_Outillage='" & Cod_Outillage_txt.Text & "' And id_Societe=" & Societe.id_Societe &
                    " insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('RH_Outillage','Cod_Outillage','" & Cod_Outillage_txt.Text & "','" & theUser.Login & "', getdate())")
        Nouveau()
        Requesting()
    End Sub
    Private Sub Grd_Outillage_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Outillage.CellDoubleClick
        If e.RowIndex < 0 Then Return
        Enabling(Cod_Outillage_txt, False)
        Cod_Outillage_txt.Text = IsNull(Grd_Outillage.Item("Code", e.RowIndex).Value, "")
    End Sub
    Private Sub Grd_Outillage_MouseDown(sender As Object, e As MouseEventArgs) Handles Grd_Outillage.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim hit = Grd_Outillage.HitTest(e.X, e.Y)
            If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
                Grd_Outillage.CurrentCell = Grd_Outillage.Item(hit.ColumnIndex, hit.RowIndex)
            End If
        End If
    End Sub
    Sub VoirAffectations(Optional codOutillage As String = "")
        If codOutillage.Trim = "" Then codOutillage = Cod_Outillage_txt.Text.Trim
        If codOutillage = "" Then Return
        Dim Tbl As DataTable = DATA_READER_GRD("select h.Matricule, isnull(ag.Nom_Agent,'') + ' ' + isnull(ag.Prenom_Agent,'') as [Agent], " &
            " sum(case when h.Typ_Mouvement='A' then d.Qte else 0 end) as [Qté affectée], " &
            " sum(case when h.Typ_Mouvement='R' then d.Qte else 0 end) as [Qté retirée], " &
            " sum(case when h.Typ_Mouvement='A' then d.Qte else -d.Qte end) as [Qté détenue] " &
            " from RH_Outillage_Mouvement_Detail d " &
            " inner join RH_Outillage_Mouvement h on h.Num_Mouvement=d.Num_Mouvement and h.id_Societe=d.id_Societe " &
            " left join RH_Agent ag on ag.Matricule=h.Matricule and ag.id_Societe=h.id_Societe " &
            " where d.Cod_Outillage='" & codOutillage & "' and d.id_Societe=" & Societe.id_Societe & " and isnull(h.Statut,'')<>'RJ' " &
            " group by h.Matricule, ag.Nom_Agent, ag.Prenom_Agent " &
            " having sum(case when h.Typ_Mouvement='A' then d.Qte else -d.Qte end) > 0 " &
            " order by h.Matricule")
        If Tbl.Rows.Count = 0 Then
            ShowMessageBox("Aucune affectation en cours pour cet outillage.", "Affectations", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        Dim Z As New Zoom_Libre
        With Z
            .Text = "Affectations de l'outillage : " & codOutillage & " - " & FindLibelle("Lib_Outillage", "Cod_Outillage", codOutillage, "RH_Outillage")
            With .Libre_GRD
                .DataSource = Tbl
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
                .RowHeadersVisible = False
                For i = 2 To .ColumnCount - 1
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Next
            End With
            .ShowDialog()
        End With
    End Sub
    Sub Div_First()
        If Cod_Outillage_txt.Text <> "" Then
            Diviseur_First("RH_Outillage", "Cod_Outillage", "Cod_Outillage", Cod_Outillage_txt)
        End If
    End Sub
    Sub Div_Back()
        If Cod_Outillage_txt.Text <> "" Then
            Diviseur_Back("RH_Outillage", "Cod_Outillage", "Cod_Outillage", Cod_Outillage_txt)
        End If
    End Sub
    Sub Div_Next()
        If Cod_Outillage_txt.Text <> "" Then
            Diviseur_Next("RH_Outillage", "Cod_Outillage", "Cod_Outillage", Cod_Outillage_txt)
        End If
    End Sub
    Sub Div_Last()
        If Cod_Outillage_txt.Text <> "" Then
            Diviseur_Last("RH_Outillage", "Cod_Outillage", "Cod_Outillage", Cod_Outillage_txt)
        End If
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS210", Cod_Outillage_txt, Me)
    End Sub
    Private Sub Cod_Outillage_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Outillage_txt.TextChanged
        Try
            If Not Cod_Outillage_txt.ReadOnly Then Return
            Request()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Cod_Outillage_txt_Leave(sender As Object, e As EventArgs) Handles Cod_Outillage_txt.Leave
        Try
            If Cod_Outillage_txt.ReadOnly Then Return
            Request()
            Enabling(Cod_Outillage_txt, False)
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Qte_Initial_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Qte_Initial_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub
    Private Sub RH_Outillage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
End Class
