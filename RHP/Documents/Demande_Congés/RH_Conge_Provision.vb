Public Class RH_Conge_Provision
    Friend TblPrepa, TblFunction, TblAgent, TblRubriqueCumulable As New DataTable
    Dim TblRubPaie As DataTable = DATA_READER_GRD("select Cod_Rubrique, Typ_Retour, Nb_Decimal from RH_Paie_Rubrique where id_Societe=" & Societe.id_Societe & " and isnull(EC,0)=1")
    Dim oMnu2, oMnu3 As New ToolStripMenuItem
    Friend Code As String = "XYZ"
    Dim NbJrConge, SalBrut, ChargesPatronales As String
    Dim PnlWait As New ud_PanelWait
    Friend WithEvents oTimer As New Timer
    Dim oAvancementStr As String = ""
    Dim oAvancementStrTitre As String = ""
    Friend CalculAuto As Boolean = True
    Dim myVBS As New vsEngine
    Dim New_D As ud_btn
    Dim Request_D As ud_btn
    Dim Save_D As ud_btn
    Dim Import_D As ud_btn
    Dim Cloture_D As ud_btn
    Dim Del_D As ud_btn

    Sub PreparationTables()
        Dim oDat As Date = Now
        If EstDate(Dat_Periode_txt.Text) Then oDat = CDate(Dat_Periode_txt.Text)
        TblRubriqueCumulable = DATA_READER_GRD("select * from dbo.Sys_RH_Paie_Calcul_Rubrique_Cumulable ('" & Year(oDat) & "','" & Month(oDat) & "','" & Societe.id_Societe & "','')")
        TblFunction = DATA_READER_GRD(" Select Cod_Function, Typ_Function, Lib_Abr, Formule_Function,
                                        Typ_Retour, IsNull(Nb_Decimal, 2) As Nb_Decimal, IsNull(Est_Pourcentage,'false') as Est_Pourcentage from  RH_Elements_Paie where id_Societe=" & Societe.id_Societe)
        TblAgent = DATA_READER_GRD("select Matricule, Nom_Agent, Prenom_Agent, Droit_Paie from RH_Agent where id_Societe=" & Societe.id_Societe & " and isnull(Plan_Paie,'')='" & Cod_Plan_Paie_txt.Text & "'")

    End Sub
    Private Sub RH_Conge_Provision_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Grd_Conge.DataSource = Nothing
        CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and id_Societe=" & Societe.id_Societe & " and Process_Id=" & ProcessId)
    End Sub
    Sub AfficherRubrique()
        If Grd_Conge.SelectedCells.Count = 0 Then Return
        Dim c As Integer = Grd_Conge.SelectedCells(0).ColumnIndex
        Select Case Grd_Conge.Columns(c).Name
            Case "Salaire_Brut"
                Dim f As New RH_Parametrage_Rubrique_Paie
                With f
                    .Cod_Rubrique_txt.Text = SalBrut
                    .Request()
                    newShowEcran(f, True)
                End With
            Case "Charges_Patronales"
                Dim f As New RH_Parametrage_Rubrique_Paie
                With f
                    .Cod_Rubrique_txt.Text = ChargesPatronales
                    .Request()
                    newShowEcran(f, True)
                End With
        End Select
    End Sub
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        New_D = dictButtons("New_D")
        Request_D = dictButtons("Request_D")
        Save_D = dictButtons("Save_D")
        Import_D = dictButtons("Import_D")
        Cloture_D = dictButtons("Cloture_D")
        Del_D = dictButtons("Del_D")
        Cloture_Check.Checked = False
        With oMnu2
            .Text = "Consulter la rubrique de paie"
            .Image = My.Resources.Dollar
            AddHandler .Click, AddressOf AfficherRubrique
        End With
        With oMnu3
            .Text = "Recalcul de la ligne"
            .Image = My.Resources.Calculator213122
            AddHandler .Click, AddressOf RecalculDeLaLigne
        End With
        Check_Accessible(Me.Name, Code)
        If CnExecuting("Select count(*) from Controle_Access where Process_Id<>" & ProcessId & " and Name_Ecran='" & Me.Name & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            MessageBoxRHP(687)
            With Save_D
                .Enabled = False
                .Tag = ""
            End With
        End If
        Grd_Conge.ContextMenuStrip = AddContextMenu(False, True, False, False, False, False, False, False)
        Grd_Conge.ContextMenuStrip.Items.Insert(1, oMnu2)
        Grd_Conge.ContextMenuStrip.Items.Insert(2, oMnu3)

    End Sub
    Sub RecalculDeLaLigne()
        If Num_ProvConge_txt.Text = "" Then Return
        If Grd_Conge.ColumnCount = 0 Then Return
        If Grd_Conge.SelectedCells.Count = 0 Then Return
        Dim r As Integer = Grd_Conge.SelectedCells(0).OwningRow.Index
        If r < 0 Then Return
        CalculPaie(r, False)
    End Sub
    Sub Nouveau()
        Reset_Form(Me)
        Request()
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Num_ProvConge_txt.Text <> "" Then Return
        Appel_Calender_Blocage(Dat_Periode_txt, Me, "Compta")
    End Sub

    Private Sub Num_ProvConge_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_ProvConge_txt.TextChanged
        Dat_Periode_txt.Text = FindLibelle("Dat_Periode", "Num_ProvConge", Num_ProvConge_txt.Text, "RH_Conge_Provision")
        Cod_Plan_Paie_txt.Text = FindLibelle("Cod_Plan_Paie", "Num_ProvConge", Num_ProvConge_txt.Text, "RH_Conge_Provision")
        Cloture_Check.Checked = FindLibelle("Cloture", "Num_ProvConge", Num_ProvConge_txt.Text, "RH_Conge_Provision")
        PreparationTables()
        Request()
    End Sub

    Sub Calcul()
        If Cloture_Check.Checked Then Return
        If Not EstDate(Dat_Periode_txt.Text) Then
            ShowMessageBox("Date non renseignée", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Cod_Plan_Paie_txt.Text = "" Then
            ShowMessageBox("Plan non renseignée", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If CnExecuting("Select count(*) from Param_Periode_Paie where isnull(Cloture,'false')='false' and Annee='" & ConvertDate(Dat_Periode_txt.Text).Year & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
            ShowMessageBox("Année de paie non ouverte", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        PreparationTables()
        With Grd_Conge
            For i = 0 To .RowCount - 1
                CalculPaie(i, False, False)
            Next
        End With
    End Sub
    Private Sub Cod_Plan_Paie_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Plan_Paie_txt.TextChanged
        Lib_Plan_Paie_txt.Text = FindLibelle("Lib_Plan_Paie", "Cod_Plan_Paie", Cod_Plan_Paie_txt.Text, "RH_Param_Plan_Paie")
        NbJrConge = FindLibelle("NbJrConge", "Cod_Plan_Paie", Cod_Plan_Paie_txt.Text, "RH_Param_Plan_Paie")
        SalBrut = FindLibelle("SalBrut", "Cod_Plan_Paie", Cod_Plan_Paie_txt.Text, "RH_Param_Plan_Paie")
        ChargesPatronales = FindLibelle("ChargesPatronales", "Cod_Plan_Paie", Cod_Plan_Paie_txt.Text, "RH_Param_Plan_Paie")
        myVBS.setPlan(Cod_Plan_Paie_txt.Text)
    End Sub

    Private Sub Num_CongeProv__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Num_CongeProv_.LinkClicked
        Appel_Zoom1("MS028", Num_ProvConge_txt, Me)
    End Sub

    Private Sub Plan_Paie__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Plan_Paie_.LinkClicked
        If Num_ProvConge_txt.Text <> "" Then
            MessageBoxRHP(710)
            Exit Sub
        End If
        Appel_Zoom1("MS069", Cod_Plan_Paie_txt, Me)
    End Sub

    Sub Enregistrer()
        Saving(False)
    End Sub
    Sub Saving(avecCloture As Boolean)
        Cursor = Cursors.WaitCursor
        Dim Num As String = Num_ProvConge_txt.Text
        Dim oDat As Date = Now
        Dim rnd As New Random
        Dim flg As Integer = rnd.Next(1111, 999999)
        Dim NotDroitPaie As New ArrayList
        Dim Matricule As String = ""
        With Grd_Conge
            For i = 0 To .RowCount - 1
                If Not CalculPaie(i, True, False) Then Return
                If TblAgent.Select("Matricule='" & IsNull(.Item("Matricule", i).Value, "") & "' and Droit_Paie='true'").Length = 0 Then
                    NotDroitPaie.Add(.Item("Matricule", i).Value)
                End If
            Next
        End With
        If NotDroitPaie.Count > 0 Then
            If ShowMessageBox("Certains matricules n'ont pas droit à la paie." & vbCrLf &
                                     "Si vous continuez, ces derniers ne seront pas enregistrés." & vbCrLf &
                                     "Voulez-vous continuer?", "Enregistrer", MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then
                Return
            End If
        End If
        If Num = "" Then
            Dim Cp As New ADODB.Recordset
            Cp = CnExecuting("select Top 1 convert(int,right(Num_ProvConge,6)) from RH_Conge_Provision where id_Societe=" & Societe.id_Societe & " order by Num_ProvConge Desc")
            If Not Cp.EOF Then
                Num = "CP" & Societe.id_Societe & "-" & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
            Else
                Num = "CP" & Societe.id_Societe & "-000001"
            End If
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from RH_Conge_Provision where Num_ProvConge='" & Num & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Dat_Crea").Value = oDat
            rs("Created_By").Value = theUser.Login
            rs("id_Societe").Value = Societe.id_Societe
            rs("Num_ProvConge").Value = Num
        Else
            rs.Update()
        End If
        rs("Cod_Plan_Paie").Value = Cod_Plan_Paie_txt.Text
        rs("Dat_Periode").Value = Dat_Periode_txt.Text
        rs("Cloture").Value = avecCloture
        rs("Dat_Modif").Value = oDat
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()
        With Grd_Conge
            rs.Open("select * from RH_Conge_Provision_Detail", cn, 2, 2)
            For i = 0 To .RowCount - 1
                Matricule = .Item("Matricule", i).Value
                If Not NotDroitPaie.Contains(Matricule) Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Num_ProvConge").Value = Num
                    rs("Matricule").Value = Matricule
                    rs("Solde_Conge").Value = .Item("Solde_Conge", i).Value
                    rs("Salaire_Brut").Value = .Item("Salaire_Brut", i).Value
                    rs("Charges_Patronales").Value = .Item("Charges_Patronales", i).Value
                    rs("Provision_Conge").Value = .Item("Provision_Conge", i).Value
                    rs("Flag_Maj").Value = flg
                    rs.Update()
                End If
            Next
            rs.Close()
        End With
        CnExecuting("delete from RH_Conge_Provision_Detail where Num_ProvConge= '" & Num & "' and id_Societe=" & Societe.id_Societe & " and isnull(Flag_Maj,0)<>" & flg)
        If Num_ProvConge_txt.Text = "" Then
            Code = Num
            Num_ProvConge_txt.Text = Num
        Else
            Num_ProvConge_txt_TextChanged(Nothing, Nothing)
        End If
        Cursor = Cursors.Default
    End Sub

    Sub Cloturer()
        If ShowMessageBox("Etes-vous sûr de vouloir clôturer cette provision?", "Clôture", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        Saving(True)
    End Sub

    Sub Deleting()
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette provision?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Conge_Provision where Num_ProvConge= '" & Num_ProvConge_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Reset_Form(Me)
    End Sub

    Sub Importer()
        Dim f As New RH_Conge_Provision_Import_EV
        With f
            .frm_ProvConge = Me
            newShowEcran(f, True)
        End With
    End Sub

    Function CalculPaie(ByVal oLgnInd As Integer, CalculDetail As Boolean, Optional CheckDroitPaie As Boolean = True) As Boolean
        If Cloture_Check.Checked Then Return False
        If Not CalculAuto Then Return False
        If NbJrConge = "" Or SalBrut = "" Or ChargesPatronales = "" Then Return False
        Dim EVstr As String = ""
        Dim vrw() As DataRow = Nothing
        Dim ColName As String = ""
        Try
            With Grd_Conge
                .Rows(oLgnInd).DefaultCellStyle.ForeColor = Color.Black
                If TblAgent.Select("Matricule='" & IsNull(.Item("Matricule", oLgnInd).Value, "") & "' and Droit_Paie='true'").Length = 0 Then
                    .Rows(oLgnInd).DefaultCellStyle.ForeColor = Color.Red
                    If CheckDroitPaie Then
                        ShowMessageBox("Le matricule : " & IsNull(.Item("Matricule", oLgnInd).Value, "") & " n'a pas droit à la paie. son calcul sera incorrect.", "Attention", MessageBoxButtons.OK, msgIcon.Stop)
                        Return False
                    End If
                End If
                If ConvertNombre(.Item("Solde_Conge", oLgnInd).Value) <= 0 Then
                    .Item("Salaire_Brut", oLgnInd).Value = 0
                    .Item("Charges_Patronales", oLgnInd).Value = 0
                    .Item("Provision_Conge", oLgnInd).Value = 0
                Else
                    Dim Crw() As DataRow = TblRubriqueCumulable.Select("Matricule='" & .Item("Matricule", oLgnInd).Value & "'")
                    '   Dim Srw() As DataRow = TblElementSpecifique.Select("Matricule='" & .Item("Matricule", oLgnInd).Value & "'")
                    'Affectation des EB
                    '        AffectationEB(.Item("Matricule", oLgnInd).Value, Dat_Periode_txt.Text, False)
                    'Affectation des EV
                    EVstr &= " AffectVar " & NbJrConge & ";" & IsNull(.Item("Solde_Conge", oLgnInd).Value, 0)
                    'Affectation des Rubriques cumulables
                    For i = 0 To Crw.Length - 1
                        EVstr &= IIf(EVstr = "", "", vbCrLf) & " AffectVar Cumul_" & Crw(i)("Cod_Rubrique") & ";" & IsNull(Crw(i)("Cumul"), 0)
                    Next
                    EVstr = TraitementCaractere(EVstr)
                    myVBS.ExecuteStatement(EVstr)
                    'Salaire Brut
                    .Item("Salaire_Brut", oLgnInd).Value = ConvertNombre(myVBS.Eval(TraitementCaractere(SalBrut)))
                    .Item("Charges_Patronales", oLgnInd).Value = ConvertNombre(myVBS.Eval(TraitementCaractere(ChargesPatronales)))
                    .Item("Provision_Conge", oLgnInd).Value = CDbl(.Item("Salaire_Brut", oLgnInd).Value) + CDbl(.Item("Charges_Patronales", oLgnInd).Value)
                End If
            End With
            Return True
        Catch ex As Exception
            If Not ex.HResult = -2146233079 Then
                ShowMessageBox("Erreur de calcul de la ligne : " & oLgnInd + 1 & ", Rubrique : " & ColName & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
            End If
            Return False
        End Try
    End Function
    Private Sub Grd_Conge_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Conge.CellContentClick
        With Grd_Conge
            If .RowCount = 0 Then Return
            If e.RowIndex < 0 Then Return
            If e.ColumnIndex < 0 Then Return
            If .Columns("Matricule").Index = e.ColumnIndex Then
                Dim f As New RH_Agent
                With f
                    .Chargement()
                    .Matricule_Text.Text = Grd_Conge.Item("Matricule", e.RowIndex).Value
                    .StartPosition = FormStartPosition.CenterScreen
                    newShowEcran(f, True)
                End With
            End If
        End With
    End Sub
    Private Sub Grd_Conge_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Conge.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        If Cod_Plan_Paie_txt.Text = "" Then Exit Sub
        If e.ColumnIndex = Grd_Conge.Columns("Solde_Conge").Index Then CalculPaie(e.RowIndex, False)
    End Sub
    Sub Requesting()
        If Not EstDate(Dat_Periode_txt.Text) Then
            ShowMessageBox("Date non renseignée", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Cod_Plan_Paie_txt.Text = "" Then
            ShowMessageBox("Plan non renseignée", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If CnExecuting("Select count(*) from Param_Periode_Paie where isnull(Cloture,'false')='false' and Annee='" & ConvertDate(Dat_Periode_txt.Text).Year & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
            ShowMessageBox("Année de paie non ouverte", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Num_ProvConge_txt.Text = "" And CnExecuting("Select count(*) from RH_Conge_Provision where isnull(Cloture,0)=0 and id_Societe=" & Societe.id_Societe & " and isnull(Cod_Plan_Paie,'')='" & Cod_Plan_Paie_txt.Text & "'").Fields(0).Value > 0 Then
            ShowMessageBox("Il existe des provisions pour congé non validées.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If

        Dim TblConge As DataTable = DATA_READER_GRD("select * 
from RH_Conge_Suivi s
where isnull(Statut,'')='' and id_Societe=" & Societe.id_Societe & "
and Dat_Fin_Conge<='" & Dat_Periode_txt.Text & "' 
and exists(select Matricule from RH_Agent where id_Societe=s.id_Societe 
and Matricule=s.Matricule and Plan_Paie='" & Cod_Plan_Paie_txt.Text & "') ")
        If TblConge.Rows.Count > 0 Then
            ShowMessageBox("Il existe des demandes de congé non encore traitées.", "Congés non traités", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If

        Request()
    End Sub
    Sub AttendreProcess(Debut As Boolean)
        oAvancementStrTitre = ""
        oAvancementStr = ""
        If Debut Then
            oTimer.Start()
            With PnlWait
                Me.Controls.Add(PnlWait)
                .lblProgress.Visible = True
                .Visible = True
                .lblAvancement.BringToFront()
                .BringToFront()
                .CircularProgress1.SendToBack()
                .CircularProgress1.SendToBack()
            End With
        Else
            PnlWait.lblProgress.Visible = True
            oTimer.Stop()
            If Me.Controls.Contains(PnlWait) Then Me.Controls.Remove(PnlWait)
        End If

    End Sub
    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        With PnlWait
            .CircularProgress1.Value = IIf(.CircularProgress1.Value = 100, 0, .CircularProgress1.Value) + 10
            .lblAvancement.Text = oAvancementStrTitre
            .lblAvancement.Refresh()
            .lblProgress.Text = oAvancementStr
            .lblProgress.Refresh()
        End With
    End Sub
    Sub Request()
        Try
            CnExecuting("delete from Controle_Access where id_Societe='" & Societe.id_Societe & "' and  Name_Ecran='" & Me.Name & "' and value='" & Code & "'")
            Save_D.Enabled = True
            Import_D.Enabled = True
            Request_D.Enabled = True
            DroitAcces(Me, DroitModify_Fiche(Num_ProvConge_txt.Text, Me))

            Grd_Conge.DataSource = Nothing
            Cursor = Cursors.WaitCursor

            TblPrepa = DATA_READER_GRD("exec Sys_Conge_Provision '" & Societe.id_Societe & "','" & Cod_Plan_Paie_txt.Text & "', '" & Num_ProvConge_txt.Text & "','" & Dat_Periode_txt.Text & "'")
            Dim oCStyle As New DataGridViewCellStyle
            With oCStyle
                .Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Format = "N2"
            End With
            With Grd_Conge
                .DataSource = TblPrepa
                .Columns("Solde_Conge").HeaderText = "Solde de congé"
                .Columns("Salaire_Brut").HeaderText = "Salaire brut"
                .Columns("Charges_Patronales").HeaderText = "Charges patronales"
                .Columns("Provision_Conge").HeaderText = "Congé à payer"
                .Columns("Solde_Conge").DefaultCellStyle = oCStyle
                .Columns("Salaire_Brut").DefaultCellStyle = oCStyle
                .Columns("Charges_Patronales").DefaultCellStyle = oCStyle
                .Columns("Provision_Conge").DefaultCellStyle = oCStyle
                TblPrepa.Columns("Solde_Conge").ReadOnly = False
                TblPrepa.Columns("Salaire_Brut").ReadOnly = False
                TblPrepa.Columns("Charges_Patronales").ReadOnly = False
                TblPrepa.Columns("Provision_Conge").ReadOnly = False
                .Columns("Solde_Conge").ReadOnly = False
                If .Columns.Contains("Matricule") Then
                    .Columns.Remove("Matricule")
                    Dim oMat As New DataGridViewLinkColumn
                    With oMat
                        .Name = "Matricule"
                        .HeaderText = "Matricule"
                        .DataPropertyName = "Matricule"
                    End With
                    .Columns.Insert(0, oMat)
                End If
                Grd_Conge.setFilter({0, 1})
            End With
            If Num_ProvConge_txt.Text = "" Then
                If EstDate(Dat_Periode_txt.Text) And Cod_Plan_Paie_txt.Text <> "" Then Calcul()
            End If
            If Cloture_Check.Checked Then
                Cloture_D.Enabled = False
                Save_D.Enabled = False
                Del_D.Enabled = False
                Cloture_D.Image = My.Resources.btn_lock
            Else
                Cloture_D.Image = My.Resources.btn_unlock
            End If
            Import_D.Enabled = Save_D.Enabled
            Request_D.Enabled = Save_D.Enabled
            If Save_D.Enabled = True And Num_ProvConge_txt.Text.Trim <> "" And Code <> Num_ProvConge_txt.Text Then
                Code = Num_ProvConge_txt.Text
                Check_Accessible(Me.Name, Code)
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            ShowMessageBox("Erreur : " & ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
            Cursor = Cursors.Default
        End Try
    End Sub
End Class