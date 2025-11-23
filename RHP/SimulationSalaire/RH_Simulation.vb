Imports System.ComponentModel
Public Class RH_Simulation
    Friend Grd_Zoom As New Dictionary(Of DataGridViewColumn, String)
    Dim oGrdFilter As New GrdFilter_Simulation
    Dim filter_pb As New PictureBox
    Dim dicMat As New Dictionary(Of String, Dictionary(Of String, Double))
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim CalculInverse_D As ud_btn
    Dim Del_D As ud_btn
    Dim Valide_D As ud_btn
    Dim add_agent_D As ud_btn
    Dim _VBS As New vsEngine
    Friend EBSalBaseRef, ECSalNet As String
    Public Statut As String = ""
    Dim strEP() As String = Nothing
    Friend strEM() As String = Nothing
    Friend TblSimulation As New DataTable
    Friend modeRequest As Boolean = False
    Friend modeMajMatricule As Boolean = False
    Dim TblRubriqueCumulable As New DataTable
    Dim TblConstantantes As New DataTable
    Sub Chargement()
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            CalculInverse_D = dictButtons("CalculInverse_D")
            Del_D = dictButtons("Del_D")
            add_agent_D = dictButtons("add_agent_D")
            Valide_D = dictButtons("Valide_D")
        End If
        If Situation.Items.Count = 0 Then Situation.fromRubrique()
        If Typ_Agent.Items.Count = 0 Then Typ_Agent.fromRubrique()
        If Typ_Contrat.Items.Count = 0 Then Typ_Contrat.fromRubrique()
        If Typ_Periode.Items.Count = 0 Then Typ_Periode.fromRubrique()
        If Not EstDate(Dat_Entree_Text.Text) Then Dat_Entree_Text.Text = Now.ToShortDateString
        If Not EstDate(Dat_Naissance_Text.Text) Then Dat_Naissance_Text.Text = Now.AddYears(-18).ToShortDateString
        If Civilite_Combo.Items.Count = 0 Then
            Civilite_Combo.fromRubrique()
            TabControl1.SelectedIndex = 0
            Nom_Agent_Text.Select()
            considerCumuls_chk.Checked = True
            Typ_Agent.SelectedValue = "M"
            Typ_Contrat.SelectedValue = "CDI"
            Typ_Periode.SelectedValue = "0"
            Cod_Plan_Paie_Text.Text = FindLibelle("Cod_Plan_Paie", "id_Societe", Societe.id_Societe, "Rh_Param_Plan_Paie")
            Civilite_Combo.SelectedValue = "Mr"
            Situation.SelectedValue = "C"
            Dat_Entree_Text.Text = Now.ToShortDateString
            Dat_Naissance_Text.Text = Now.AddYears(-20).ToShortDateString
        End If

    End Sub
    Sub initialiserVBS()
        _VBS = New vsEngine
        Dim strAG As String = ""
        If TblConstantantes.Columns.Count = 0 Then DATA_READER_GRD("select Cod_Function, Formule_Function from RH_Elements_Paie where Typ_Function='CS' and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
        For Each cs In TblConstantantes.Rows
            strAG &= vbCrLf & "AffectVar Cumul_" & cs("Cod_Function") & " ; " & IsNull(cs("Formule_Function"), 0)
        Next
        _VBS.ExecuteStatement(TraitementCaractere(strAG))
    End Sub
    Private Sub Zoom_Rh_Simulation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        '  AddHandler MyGrd.EditingControlShowing, AddressOf Grd_EditingControlShowing
        MyGrd.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        With filter_pb
            .Image = My.Resources.btn_filter_w
            .BackColor = Color.Transparent
            .Size = New Size(20, 20)
            .SizeMode = PictureBoxSizeMode.StretchImage
            .Location = New Point(5, 5)
            MyGrd.Controls.Add(filter_pb)
            AddHandler .Click, AddressOf AfficherListeColonnes
        End With
        With oGrdFilter
            .MyGrd = MyGrd
            .Location = New Point(5, 5)
            .Parent = MyGrd
            .Visible = False
            .BringToFront()
            .BringToFront()
        End With
        With MyGrd
            .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        End With
        initialiserVBS()

    End Sub
    Sub ChargerElementsPaieAgent()
        If modeRequest Then Return
        Dim _TblAgentEP = DATA_READER_GRD("select Cod_Function, Typ_Function, isnull(Valeur,0) as Valeur 
from RH_Elements_Paie e 
outer apply (select Valeur from RH_Agent_Element_Paie p where p.id_Societe= isnull(nullif(e.id_Societe,-1),p.id_Societe) and Matricule='" & Matricule_Text.Text & "' and Cod_Rubrique=e.Cod_Function) a
where Typ_Function in ('EB','EX')  and isnull(nullif(e.id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
        'Vérifier si la table TblSimulation n'est pas vide
        If (TblSimulation.Columns.Count = 0) Then ChargerTblSimulation()
        'Mise à jour les éléments de la table TblSimulation
        With TblSimulation
            'Mise à jour des éléments de paie de l'agent
            For Each rw As DataRow In TblSimulation.Select("Typ_Function in ('EB','EX')")
                Dim codFunction As String = rw("Cod_Function")
                Dim arw = _TblAgentEP.Select("Cod_Function='" & codFunction & "'")
                If arw.Length() > 0 Then
                    rw("Valeur") = arw(0)("Valeur")
                Else
                    rw("Valeur") = 0
                End If
            Next
            'Mise à jour des cumuls de la paie
            If considerCumuls_chk.Checked Then
                TblRubriqueCumulable = DATA_READER_GRD("select * from dbo.Sys_RH_Paie_Calcul_Rubrique_Cumulable ('" & DatSimulation.Value.Year & "','" & DatSimulation.Value.Month & "','" & Societe.id_Societe & "','" & Matricule_Text.Text & "')")
            ElseIf TblRubriqueCumulable.Columns.Count = 0 Then
                TblRubriqueCumulable.Columns.Add("Matricule")
                TblRubriqueCumulable.Columns.Add("Cod_Rubrique")
                TblRubriqueCumulable.Columns.Add("Cumul", GetType(Decimal))
            Else
                TblRubriqueCumulable.Rows.Clear()
            End If
            For Each rw As DataRow In TblSimulation.Select("Cod_Function like 'Cumul_%'")
                Dim codFunction As String = rw("Cod_Function")
                Dim crw = TblRubriqueCumulable.Select("Cod_Rubrique='" & codFunction & "' and Cumul<>0")
                If crw.Length() > 0 Then
                    rw("Valeur") = crw(0)("Valeur")
                Else
                    rw("Valeur") = 0
                End If
            Next
        End With
        Calcul()
    End Sub
    Sub AfficherListeColonnes()
        If Cod_Plan_Paie_Text.Text = "" Then Return
        With oGrdFilter
            .CodPlan = Cod_Plan_Paie_Text.Text
            .TblSimulation = TblSimulation
            .Visible = True
            .FilterList.Select()
        End With

    End Sub
    Sub MasquerListeColonnes(sender As CheckedListBox, e As EventArgs)
        sender.Visible = False
        If CType(sender.Parent, DataGridView).ColumnCount = 0 Then Exit Sub
        If MyGrd.Rows.Count = 0 Then Return
        Dim str As String = ""
        With sender
            For i = 0 To .Items.Count - 1
                MyGrd.Rows(i).Visible = IIf(IsNull(MyGrd.Item("Cod_Function", i).Value, "") = EBSalBaseRef Or IsNull(MyGrd.Item("Cod_Function", i).Value, "") = ECSalNet, True, .GetItemChecked(i))
                If Not MyGrd.Rows(i).Visible Then
                    str &= IIf(str = "", "", ";") & MyGrd.Item("Cod_Function", i).Value
                End If
            Next
        End With
        CnExecuting("update RH_Param_Plan_Paie set Element_Masques_Simulation='" & str.Replace("'", "''") & "' where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)
    End Sub
    Sub CheckDate(sender As TextBox, e As CancelEventArgs)
        e.Cancel = Not EstDate(sender.Text)
    End Sub
    Private Sub Grd_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        If MyGrd.Rows.Count = 0 Then Return
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        With sender
            If Not .Rows(.CurrentCell.RowIndex).readonly And MyGrd.Columns(.CurrentCell.ColumnIndex).name = "Valeur" Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With MyGrd
            If .Rows.Count = 0 Then Return
            If Not .Rows(.CurrentCell.RowIndex).ReadOnly And MyGrd.Columns(.CurrentCell.ColumnIndex).Name = "Valeur" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, IIf(.CurrentCell.Style.Format = "N0", True, False), False, False, False)
            End If
        End With
    End Sub
    Private Sub Grade__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Grade_.LinkClicked
        Appel_Zoom1("MS015", Grade_Text, Me)
    End Sub

    Private Sub Grade_Text_TextChanged(sender As Object, e As EventArgs) Handles Grade_Text.TextChanged
        Lib_Grade_Text.Text = FindLibelle("Lib_Grade", "Cod_Grade", Grade_Text.Text, "Org_Grade")
        Calcul()
    End Sub

    Private Sub Poste__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Poste_.LinkClicked
        Appel_Zoom1("MS016", Poste_Text, Me, "Cod_Grade='" & Grade_Text.Text & "'")
    End Sub

    Private Sub Poste_Text_TextChanged(sender As Object, e As EventArgs) Handles Poste_Text.TextChanged
        Lib_Poste_Text.Text = FindLibelle("Lib_Poste", "Cod_Poste", Poste_Text.Text, "Org_Poste")
    End Sub

    Private Sub Entite__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Entite_.LinkClicked
        Appel_Zoom1("MS010", Cod_Entite_txt, Me)
    End Sub

    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
        Calcul()
    End Sub

    Private Sub Plan_Paie__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Plan_Paie_.LinkClicked
        If Cod_Simulation_Text.Text <> "" Then Return
        Appel_Zoom1("MS069", Cod_Plan_Paie_Text, Me)
    End Sub

    Private Sub Cod_Plan_Paie_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        Lib_Plan_Paie_Text.Text = FindLibelle("Lib_Plan_Paie", "Cod_Plan_Paie", Cod_Plan_Paie_Text.Text, "RH_Param_Plan_Paie")

        If Not EstDate(Dat_Naissance_Text.Text) Then Dat_Naissance_Text.Text = Now.AddYears(-20).ToShortDateString
        strEM = FindLibelle("Element_Masques", "Cod_Plan_Paie", Cod_Plan_Paie_Text.Text, "RH_Param_Plan_Paie").Split(";")
        EBSalBaseRef = FindLibelle("SalBaseRef", "Cod_Plan_Paie", Cod_Plan_Paie_Text.Text, "RH_Param_Plan_Paie")
        ECSalNet = FindLibelle("SalNet", "Cod_Plan_Paie", Cod_Plan_Paie_Text.Text, "RH_Param_Plan_Paie")
        _VBS.setPlan(Cod_Plan_Paie_Text.Text)
        ChargerTblSimulation()
        Calcul()
    End Sub
#Region "Request"
    Sub Request()
        MyGrd.DataSource = Nothing
        modeRequest = True
        dicMat = New Dictionary(Of String, Dictionary(Of String, Double))
        Dim Tbl As DataTable = DATA_READER_GRD("select * from RH_Simulation where Cod_Simulation='" & Cod_Simulation_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        With Tbl
            If .Rows.Count > 0 Then
                DatSimulation.Value = IsNull(.Rows(0)("Dat_Simulation"), Now.ToShortDateString)
                Cod_Plan_Paie_Text.Text = IsNull(.Rows(0)("Cod_Plan_Paie"), "")
                Lib_Simulation_Text.Text = IsNull(.Rows(0)("Lib_Simulation"), "")
                Matricule_Text.Text = IsNull(.Rows(0)("Matricule"), "")
                estNouvelleRecrue_chk.Checked = IsNull(.Rows(0)("estNouvelleRecrue"), False)
                Civilite_Combo.SelectedValue = IsNull(.Rows(0).Item("Civilite"), "Mr")
                Nom_Agent_Text.Text = IsNull(.Rows(0)("Nom_Agent"), "")
                Prenom_Agent_Text.Text = IsNull(.Rows(0)("Prenom_Agent"), "")
                Titre_txt.Text = IsNull(.Rows(0)("Titre"), "")
                Poste_Text.Text = IsNull(.Rows(0)("Cod_Poste"), "")
                Grade_Text.Text = IsNull(.Rows(0)("Cod_Grade"), "")
                Cod_Entite_txt.Text = IsNull(.Rows(0)("Cod_Entite"), "")
                Nbr_Personne_A_Charge.Value = IsNull(.Rows(0)("Nbr_Personne_A_Charge"), 0)
                Dat_Entree_Text.Text = IsNull(.Rows(0)("Dat_Entree"), Now.ToShortDateString)
                Statut = IsNull(.Rows(0)("Statut"), "")
                Situation.SelectedValue = IsNull(.Rows(0).Item("Situation"), "")
                Dat_Naissance_Text.Text = IsNull(.Rows(0).Item("Dat_Naissance"), "")
                Typ_Agent.SelectedValue = IsNull(.Rows(0).Item("Typ_Agent"), "M")
                Typ_Contrat.SelectedValue = IsNull(.Rows(0).Item("Typ_Contrat"), "CDI")
                Typ_Periode.SelectedValue = IsNull(.Rows(0).Item("Typ_Periode"), "")
                CNSS_Text.Text = IsNull(.Rows(0).Item("CNSS"), "")
                Organisme1_Text.Text = IsNull(.Rows(0).Item("Organisme1"), "")
                Organisme2_Text.Text = IsNull(.Rows(0).Item("Organisme2"), "")
                Organisme3_Text.Text = IsNull(.Rows(0).Item("Organisme3"), "")
                Organisme4_Text.Text = IsNull(.Rows(0).Item("Organisme4"), "")
            Else
                DatSimulation.Value = Now.ToShortDateString
                Cod_Plan_Paie_Text.Text = If(Cod_Plan_Paie_Text.Text = "", FindLibelle("Cod_Plan_Paie", "id_Societe", Societe.id_Societe, "Rh_Param_Plan_Paie"), Cod_Plan_Paie_Text.Text)
                estNouvelleRecrue_chk.Checked = False
                Lib_Simulation_Text.Text = ""
                Matricule_Text.Text = ""
                Nom_Agent_Text.Text = ""
                Civilite_Combo.SelectedIndex = -1
                Prenom_Agent_Text.Text = ""
                Titre_txt.Text = ""
                Poste_Text.Text = ""
                Grade_Text.Text = ""
                Cod_Entite_txt.Text = ""
                Nbr_Personne_A_Charge.Value = 0
                Dat_Entree_Text.Text = Now.ToShortDateString
                Statut = ""
                Situation.SelectedIndex = -1
                Dat_Naissance_Text.Text = Now.ToShortDateString
                Typ_Agent.SelectedValue = "M"
                Typ_Contrat.SelectedValue = "CDI"
                Typ_Periode.SelectedValue = "C"
                CNSS_Text.Text = ""
                Organisme1_Text.Text = ""
                Organisme2_Text.Text = ""
                Organisme3_Text.Text = ""
                Organisme4_Text.Text = ""
            End If
        End With
        Valide_Check.Checked = (IsNull(Statut, "") <> "")
        Save_D.Enabled = Not Valide_Check.Checked
        Del_D.Enabled = Not Valide_Check.Checked
        Valide_D.Enabled = Not Valide_Check.Checked
        CalculInverse_D.Enabled = Not Valide_Check.Checked
        With statut_lb
            .Text = "Statut : (" & IsNull(FindRubriques("Statut_Signature", Statut), "Draft") & ")"
            .Refresh()
        End With
        ChargerTblSimulation()
        modeRequest = False
    End Sub
    Sub ChargerTblSimulation()
        dicMat.Clear()
        'Preparation de la table des formules
        Dim SimulationStr As String = ""
        If Cod_Simulation_Text.Text = "" Then
            SimulationStr = ("declare @Plan nvarchar(50), @idSoc int
set @Plan='" & Cod_Plan_Paie_Text.Text & "'
set @idSoc = " & Societe.id_Societe & "
select Cod_Function, Lib_Abr as Rubrique,Typ_Function,Typ_Retour,isnull(f.Visible,p.Visible) as Visible, isnull(Bulletin, 'false') as estBulletin,isnull(Gain_Retenue,'A') as Gain_Retenue,isnull(Patronal,'false') as Patronal, isnull(Cumulable,'false') as Cumulable, isnull(Nb,'') as Nb, isnull(Tx,'') as Tx, isnull(Base,'') as Base, isnull(Formule_Function,'') as Formule,
convert(float,1.0000* case when isnumeric(Formule_Function)=1 then Formule_Function else 0 end) as Valeur,isnull(Est_Pourcentage,'false') as Est_Pourcentage, isnull(Nb_Decimal,2) as Nb_Decimal,
case when Typ_Function in ('EB','EX') then 0 else 1000000 end + Rng as Rang 
from RH_Elements_Paie e 
outer apply (select charindex(';'+Cod_Function+';',';'+isnull(Element_Paie,'')+';') as Rng, 
case when ';'+Element_Detail+';' like '%;'+Cod_Function+';%'  then 'true' else 'false' end as Visible, 
case when charindex(';'+Cod_Function+';',';'+isnull(Element_Detail,'')+';')>0 then 'true' else 'false' end as Bulletin
from Rh_Param_Plan_Paie where Cod_Plan_Paie=@Plan and id_Societe=@idSoc  )p
outer apply (select Cumulable, Tx, Nb, Base, Gain_Retenue, Patronal from RH_Paie_Rubrique where Cod_Rubrique=Cod_Function and id_Societe=e.id_Societe)r
outer apply(select top 1 iif(charindex(';'+Cod_Function+';',';'+isnull(Syntaxe,'')+';',1)=0,'true','false') as Visible from RH_Param_Plan_Paie_Filtre where id_Societe=@idSoc and Cod_Plan_Paie=@Plan and Typ_Filtre='C' order by Actif desc) f
where isnull(nullif(id_Societe,-1),@idSoc)=@idSoc and Typ_Function not in ('RC','CS','AG','EP') and Rng>0
order by  Rang
")
        Else
            SimulationStr = ("declare @Plan nvarchar(50),@Matricule nvarchar(50), @idSoc int
set @Plan='" & Cod_Plan_Paie_Text.Text & "'
set @idSoc = " & Societe.id_Societe & "
select Cod_Function, Lib_Abr as Rubrique,Typ_Function,Typ_Retour, isnull(s.Visible, p.Visible) as Visible, isnull(Bulletin, 'false') as estBulletin,isnull(Gain_Retenue,'A') as Gain_Retenue,isnull(Patronal,'false') as Patronal, isnull(Cumulable,'false') as Cumulable, isnull(r.Nb,'') as Nb, isnull(r.Tx,'') as Tx, isnull(r.Base,'') as Base, isnull(Formule_Function,'') as Formule,
case when isnumeric(Valeur)=1 then Valeur else 0 end as Valeur,isnull(Est_Pourcentage,'false') as Est_Pourcentage, isnull(Nb_Decimal,2) as Nb_Decimal,
case when Typ_Function in ('EB','EX') then 0 else 1000000 end + Rng as Rang , isnull(s.Tx,0) as Tx_Val, isnull(s.Nb,0) as Nb_Val, isnull(s.Base,0) as Base_Val
from RH_Elements_Paie e 
outer apply (select charindex(';'+Cod_Function+';',';'+isnull(Element_Paie,'')+';') as Rng, 
case when ';'+Element_Detail+';' like '%;'+Cod_Function+';%'  then 'true' else 'false' end as Visible, 
case when charindex(';'+Cod_Function+';',';'+isnull(Element_Detail,'')+';')>0 then 'true' else 'false' end as Bulletin
from Rh_Param_Plan_Paie where Cod_Plan_Paie=@Plan and id_Societe=@idSoc  )p
outer apply (select Cumulable, Tx, Nb, Base, Gain_Retenue, Patronal from RH_Paie_Rubrique where Cod_Rubrique=Cod_Function and id_Societe=e.id_Societe )r
outer apply (select Valeur, Nb, Tx, Base, Visible from RH_Simulation_Detail where id_Societe=@idSoc and Cod_Simulation='" & Cod_Simulation_Text.Text & "' and Cod_Rubrique=Cod_Function)s
where isnull(nullif(id_Societe,-1),@idSoc)=@idSoc and Typ_Function not in ('RC','CS','AG','EP') and Rng>0
order by  Rang")

        End If
        TblSimulation = DATA_READER_GRD(SimulationStr)
        TblSimulation.Columns("Valeur").ReadOnly = False
        If Statut <> "" Then
            With TblSimulation
                For i = 0 To .Rows.Count - 1
                    If .Rows(i)("Typ_Function") = "EC" And CBool(.Rows(i)("estBulletin")) Then
                        Dim dicRubDetail As New Dictionary(Of String, Double) From {
                            {"Nb_Val", 0},
                            {"Tx_Val", 0},
                            {"Base_Val", 0}
                        }
                        dicMat.Add(.Rows(i)("Cod_Function"), dicRubDetail)
                    End If
                Next
            End With
        End If
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Cod_Simulation_Text.Text <> "" Then Return
        If estNouvelleRecrue_chk.Checked Then
            Appel_Zoom1("MS161", Matricule_Text, Me)
        Else
            Appel_Zoom1("MS067", Matricule_Text, Me)
        End If
    End Sub

    Private Sub Dat_Entree__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Entree_.LinkClicked
        Appel_Calender(Dat_Entree_Text, Me)
    End Sub

    Sub Enregistrer()
        Dim rsl = Saving(False)
        ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))

    End Sub

    Private Sub Cod_Simulation__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Simulation_.LinkClicked
        Appel_Zoom1("MS027", Cod_Simulation_Text, Me)
    End Sub
#End Region
    Private Sub Dat_Entree_Text_TextChanged(sender As Object, e As EventArgs) Handles Dat_Entree_Text.TextChanged
        Calcul()
    End Sub

    Private Sub Cod_Simulation_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Simulation_Text.TextChanged
        Request()
    End Sub
    Sub Nouveau()
        Reset_Form(Me, False)
        initialiserVBS()
        TabControl1.SelectedIndex = 0
        Nom_Agent_Text.Select()
        considerCumuls_chk.Checked = False
        Typ_Agent.SelectedValue = "M"
        Typ_Contrat.SelectedValue = "CDI"
        Typ_Periode.SelectedValue = "0"
        Civilite_Combo.SelectedValue = "Mr"
        Situation.SelectedValue = "C"
        Dat_Entree_Text.Text = Now.ToShortDateString
        Dat_Naissance_Text.Text = Now.AddYears(-20).ToShortDateString
        Cod_Plan_Paie_Text.Text = FindLibelle("Cod_Plan_Paie", "id_Societe", Societe.id_Societe, "Rh_Param_Plan_Paie")
    End Sub
    Sub Deleting()
        If Cod_Simulation_Text.Text.Trim = "" Then Return
        If ShowMessageBox("Etes-vous sûr de bien vouloir supprimer la présente simulation", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Simulation where Cod_Simulation='" & Cod_Simulation_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        Reset_Form(Me, False)
        Nom_Agent_Text.Select()
        TabControl1.SelectedIndex = 0
    End Sub
    Sub CreerAgent()
        If Cod_Simulation_Text.Text = "" Then Return
        If Not "VA;SG".Split(";").Contains(Statut) Then
            ShowMessageBox("Simulation non encore validée", Me.Text, MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        Dim oMat = FindLibelle("Matricule", "Cod_Simulation", Cod_Simulation_Text.Text, "RH_Agent")
        If oMat <> "" Then
            ShowMessageBox("Cette simulation a déjà généré un matricule: " & oMat, Me.Text, MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        Dim f As New RH_Agent
        With f
            If Matricule_Text.Text <> "" And Not estNouvelleRecrue_chk.Checked Then
                .Matricule_Text.Text = Matricule_Text.Text
            ElseIf Matricule_Text.Text <> "" And estNouvelleRecrue_chk.Checked Then
                If Not Societe.Compteur_Auto Then
                    Dim Mat As String = f.getMatricule()
                    If Mat = "" Then
                        Return
                    Else
                        .Matricule_Text.Text = Mat
                    End If
                End If
                Dim cv As New CVTheque
                cv.Matricule_Text.Text = Matricule_Text.Text
                .Ref_Candidature_txt.Text = Matricule_Text.Text
                .Civilite_Combo.SelectedValue = cv.Civilite_Combo.SelectedValue
                .Nom_Agent_Text.Text = cv.Nom_Text.Text
                .Prenom_Agent_Text.Text = cv.Prenom_Text.Text
                .Dat_Naissance_Text.Text = cv.Dat_Naissance_Text.Text
                .Dat_Entree_Text.Text = Dat_Entree_Text.Text
                .Cod_Plan_Paie_Text.Text = Cod_Plan_Paie_Text.Text
                .Poste_Text.Text = Poste_Text.Text
                .Cod_Entite_txt.Text = Cod_Entite_txt.Text
                .Grade_Text.Text = Grade_Text.Text
                .Titre_txt.Text = Titre_txt.Text
                .Organisme1_Text.Text = Organisme1_Text.Text
                .Identifiant01_txt.Text = Organisme2_Text.Text
                .Identifiant02_txt.Text = Organisme3_Text.Text
                .Identifiant03_txt.Text = Organisme4_Text.Text
                .Typ_Agent.SelectedIndex = Typ_Agent.SelectedIndex
                .Typ_Contrat.SelectedValue = Typ_Contrat.SelectedValue
                .Typ_Periode.SelectedValue = Typ_Periode.SelectedValue
                .Nbr_Personne_A_Charge.Value = Nbr_Personne_A_Charge.Value
                .Situation.SelectedValue = Situation.SelectedValue
                .CNSS_Text.Text = CNSS_Text.Text
                .Cod_Simulation = Cod_Simulation_Text.Text
                .Lieu_Naissance_Text.Text = cv.Lieu_Naissance_Text.Text
                .Adresse_Text.Text = cv.Adresse_Text.Text
                .PictureBox1.Image = cv.PictureBox1.Image
                .CIN_Agent_Text.Text = cv.CIN_Agent_Text.Text
                .NumCE_txt.Text = cv.NumCE_txt.Text
                .Gsm_Text.Text = cv.Gsm_Text.Text
                .Mail_Text.Text = cv.Mail_Text.Text
                .Cod_Ville_Text.Text = cv.Cod_Ville_Text.Text
                .Cod_Pays_Text.Text = cv.Cod_Pays_Text.Text
                .NumPPR_txt.Text = cv.NumPPR_txt.Text
                .Domaines_Competence_Pnl.Text = cv.Domaines_Competence_Pnl.Text
                Dim laListe = IsNull(.Domaines_Competence_Pnl.Text, "").Split(";").ToList()
                If laListe.Count > 0 Then
                    For Each c In laListe
                        If Not String.IsNullOrWhiteSpace(c) Then
                            If .Domaines_Competence_Pnl.Controls.Find(c, True).Length = 0 Then
                                .AddCompetence(c)
                            End If
                        End If
                    Next
                    .RearrangeControls()
                End If
                .Droit_Conge_Mensuel_txt.Text = cv.Droit_Conge_Mensuel_txt.Text
                For Each row As DataGridViewRow In cv.Formations_GRD.Rows
                    If Not row.IsNewRow Then
                        Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                        For i As Integer = 0 To row.Cells.Count - 1
                            newRow.Cells(i).Value = row.Cells(i).Value
                        Next
                        .Formations_GRD.Rows.Add(newRow)
                    End If
                Next
                For Each row As DataGridViewRow In cv.Experiences_Grd.Rows
                    If Not row.IsNewRow Then
                        Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                        For i As Integer = 0 To row.Cells.Count - 1
                            newRow.Cells(i).Value = row.Cells(i).Value
                        Next
                        .Experiences_Grd.Rows.Add(newRow)
                    End If
                Next
            Else
                If Not Societe.Compteur_Auto Then
                    Dim Mat As String = f.getMatricule()
                    If Mat = "" Then
                        Return
                    Else
                        .Matricule_Text.Text = Mat
                    End If
                End If
                .Civilite_Combo.SelectedValue = Civilite_Combo.SelectedValue
                .Nom_Agent_Text.Text = Nom_Agent_Text.Text
                .Prenom_Agent_Text.Text = Prenom_Agent_Text.Text
                .Dat_Naissance_Text.Text = Dat_Naissance_Text.Text
                .Dat_Entree_Text.Text = Dat_Entree_Text.Text
                .Cod_Plan_Paie_Text.Text = Cod_Plan_Paie_Text.Text
                .Poste_Text.Text = Poste_Text.Text
                .Cod_Entite_txt.Text = Cod_Entite_txt.Text
                .Grade_Text.Text = Grade_Text.Text
                .Titre_txt.Text = Titre_txt.Text
                .Organisme1_Text.Text = Organisme1_Text.Text
                .Identifiant01_txt.Text = Organisme2_Text.Text
                .Identifiant02_txt.Text = Organisme3_Text.Text
                .Identifiant03_txt.Text = Organisme4_Text.Text
                .Typ_Agent.SelectedIndex = Typ_Agent.SelectedIndex
                .Typ_Contrat.SelectedValue = Typ_Contrat.SelectedValue
                .Typ_Periode.SelectedValue = Typ_Periode.SelectedValue
                .Nbr_Personne_A_Charge.Value = Nbr_Personne_A_Charge.Value
                .Situation.SelectedValue = Situation.SelectedValue
                .CNSS_Text.Text = CNSS_Text.Text
                .Cod_Simulation = Cod_Simulation_Text.Text
            End If
            .EB_Grd.Rows.Clear()
            Dim TblEBS As DataTable = DATA_READER_GRD("select * from RH_Simulation_Detail d outer apply (select Lib_Rubrique from RH_Paie_Rubrique where Cod_Rubrique=d.Cod_Rubrique and id_Societe=d.id_Societe)r where Typ_Rubrique in ('EB','EX') and Valeur<>0 and Cod_Simulation='" & Cod_Simulation_Text.Text & "' and id_Societe=" & Societe.id_Societe)
            With TblEBS
                For i = 0 To .Rows.Count - 1
                    f.EB_Grd.Rows.Add(.Rows(i)("Cod_Rubrique"), .Rows(i)("Lib_Rubrique"), .Rows(i)("Typ_Retour"), .Rows(i)("Valeur"))
                Next
            End With
            newShowEcran(f)
            Me.Close()
        End With
    End Sub

    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_Text.TextChanged
        Dim TblAgent = DATA_READER_GRD("select Civilite,Nom as Nom_Agent,Prenom Prenom_Agent,Titre,Cod_Poste,Cod_Grade,'' Cod_Entite,Nbr_Personne_A_Charge,Dat_Entree,Plan_Paie,Situation,Dat_Naissance,Typ_Agent,Typ_Contrat,Typ_Periode,CNSS,Organisme1 
from CVTheque where Matricule='" & Matricule_Text.Text & "' and id_Societe=" & Societe.id_Societe & " union all
select Civilite, Nom_Agent, Prenom_Agent,Titre,Cod_Poste,Cod_Grade,Cod_Entite,Nbr_Personne_A_Charge,Dat_Entree,Plan_Paie,Situation,Dat_Naissance,Typ_Agent,Typ_Contrat,Typ_Periode,CNSS,Organisme1  from RH_Agent where Matricule='" & Matricule_Text.Text & "' and id_Societe=" & Societe.id_Societe)

        modeMajMatricule = True
        With TblAgent
            If .Rows.Count > 0 Then
                considerCumuls_chk.Checked = True
                Civilite_Combo.SelectedValue = IsNull(.Rows(0).Item("Civilite"), "")
                Nom_Agent_Text.Text = IsNull(.Rows(0)("Nom_Agent"), "")
                Prenom_Agent_Text.Text = IsNull(.Rows(0)("Prenom_Agent"), "")
                Titre_txt.Text = IsNull(.Rows(0)("Titre"), "")
                Poste_Text.Text = IsNull(.Rows(0)("Cod_Poste"), "")
                Grade_Text.Text = IsNull(.Rows(0)("Cod_Grade"), "")
                Cod_Entite_txt.Text = IsNull(.Rows(0)("Cod_Entite"), "")
                Nbr_Personne_A_Charge.Value = IsNull(.Rows(0)("Nbr_Personne_A_Charge"), 0)
                Dat_Entree_Text.Text = IsNull(.Rows(0)("Dat_Entree"), Now.ToShortDateString)
                Cod_Plan_Paie_Text.Text = IsNull(.Rows(0)("Plan_Paie"), "")
                Situation.SelectedValue = IsNull(.Rows(0).Item("Situation"), "")
                Dat_Naissance_Text.Text = IsNull(.Rows(0).Item("Dat_Naissance"), "")
                Typ_Agent.SelectedValue = IsNull(.Rows(0).Item("Typ_Agent"), "")
                Typ_Contrat.SelectedValue = IsNull(.Rows(0).Item("Typ_Contrat"), "")
                Typ_Periode.SelectedValue = IsNull(.Rows(0).Item("Typ_Periode"), "")
                CNSS_Text.Text = IsNull(.Rows(0).Item("CNSS"), "")
                Organisme1_Text.Text = IsNull(.Rows(0).Item("Organisme1"), "")
            Else
                Civilite_Combo.SelectedValue = "Mr"
                Nom_Agent_Text.Text = ""
                Prenom_Agent_Text.Text = ""
                Titre_txt.Text = ""
                Poste_Text.Text = ""
                Grade_Text.Text = ""
                Cod_Entite_txt.Text = ""
                Nbr_Personne_A_Charge.Value = 0
                Dat_Entree_Text.Text = Now.ToShortDateString
                Cod_Plan_Paie_Text.Text = FindLibelle("Cod_Plan_Paie", "id_Societe", Societe.id_Societe, "Rh_Param_Plan_Paie")
                Situation.SelectedValue = "C"
                Dat_Naissance_Text.Text = Now.AddYears(-20).ToShortDateString
                Typ_Agent.SelectedValue = "M"
                Typ_Contrat.SelectedValue = "CDI"
                Typ_Periode.SelectedValue = "0"
                CNSS_Text.Text = ""
                Organisme1_Text.Text = ""
            End If
        End With
        modeMajMatricule = False
        ChargerElementsPaieAgent()
    End Sub

    Private Sub Dat_Naissance__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Dat_Naissance_.LinkClicked
        Appel_Calender(Dat_Naissance_Text, Me)
    End Sub
    Sub Simuler()
        If Cod_Plan_Paie_Text.Text = "" Then
            ShowMessageBox("Plan vide", "Calcul inversé", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 0
            Return
        End If
        If EBSalBaseRef = "" Then
            ShowMessageBox("Plan ne contenant pas l'élément de base relatif au salaire de base.", "Calcul inversé", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 0
            Return
        End If
        If ECSalNet = "" Then
            ShowMessageBox("Plan ne contenant pas l'élément calculé relatif au salaire de Net.", "Calcul inversé", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 0
            Return
        End If
        If MyGrd.RowCount = 0 Then
            ShowMessageBox("Aucune rubrique de calcul de la paie", "Calcul inversé", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 1
            Return
        End If
        If Not EstDate(DatSimulation.Value) Then
            DatSimulation.Value = Now.ToShortDateString
        End If
        If Not EstDate(Dat_Entree_Text.Text) Then
            Dat_Entree_Text.Text = DatSimulation.Value
        End If
        If Not EstDate(Dat_Naissance_Text.Text) Then
            Dat_Naissance_Text.Text = DatSimulation.Value.AddYears(-18)
        End If
        If Typ_Agent.SelectedIndex = -1 Then
            Typ_Agent.SelectedValue = "M"
        End If
        If Typ_Contrat.SelectedIndex = -1 Then
            Typ_Contrat.SelectedValue = "CDI"
        End If
        If Typ_Periode.SelectedIndex = -1 Then
            Typ_Periode.SelectedValue = "0"
        End If
        If Not EstDate(Dat_Entree_Text.Text) Then Dat_Entree_Text.Text = Now.ToShortDateString
        Dim f As New Zoom_Simulation_Calculinverse
        With f
            .f = Me
            .StartPosition = FormStartPosition.CenterScreen
            newShowEcran(f, True)
        End With
    End Sub
    Private Sub Nbr_Personne_A_Charge_ValueChanged(sender As Object, e As EventArgs) Handles Nbr_Personne_A_Charge.ValueChanged
        Calcul()
    End Sub
    Private Sub DatSimulation_ValueChanged(sender As Object, e As EventArgs) Handles DatSimulation.ValueChanged
        ChargerElementsPaieAgent()
    End Sub

    Private Sub Typ_Agent_DropDownClosed(sender As Object, e As EventArgs) Handles Typ_Agent.DropDownClosed
        Calcul()
    End Sub
    Private Sub Typ_Contrat_DropDownClosed(sender As Object, e As EventArgs) Handles Typ_Contrat.DropDownClosed
        Calcul()
    End Sub
    Private Sub Typ_Periode_DropDownClosed(sender As Object, e As EventArgs) Handles Typ_Periode.DropDownClosed
        Calcul()
    End Sub
    Private Sub considerCumuls_chk_CheckedChanged(sender As Object, e As EventArgs) Handles considerCumuls_chk.CheckedChanged
        ChargerElementsPaieAgent()
    End Sub

    Private Sub Grd_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles MyGrd.CellValidated
        Try
            With MyGrd
                If .Columns(e.ColumnIndex).Name = "Valeur" Then
                    If Not .Rows(e.RowIndex).ReadOnly Then
                        Calcul()
                    End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        MsgBox(1)
        Return Saving(False)
    End Function
    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function
    Function Valider()
        If ShowMessageBox("Etes-vous sûr de vouloir valider cette simulation", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving(True)
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function

    Private Sub CNSS_Text_TextChanged(sender As Object, e As EventArgs) Handles CNSS_Text.TextChanged
        Calcul()
    End Sub

    Private Sub Organisme1_Text_TextChanged(sender As Object, e As EventArgs) Handles Organisme1_Text.TextChanged
        Calcul()
    End Sub
    Private Sub Organisme2_Text_TextChanged(sender As Object, e As EventArgs) Handles Organisme2_Text.TextChanged
        Calcul()
    End Sub
    Private Sub Organisme3_Text_TextChanged(sender As Object, e As EventArgs) Handles Organisme3_Text.TextChanged
        Calcul()
    End Sub
    Private Sub Organisme4_Text_TextChanged(sender As Object, e As EventArgs) Handles Organisme4_Text.TextChanged
        Calcul()
    End Sub
#End Region
    Public Function Calcul(Optional ByVal withChecks As Boolean = True) As Boolean
        Try
            If modeRequest Or modeMajMatricule Then Return False
            If Cod_Plan_Paie_Text.Text = "" Then Return False
            If TblSimulation.Rows.Count = 0 Then Return False
            If IsNull(Statut, "") <> "" Then Return False
            If withChecks Then
                If Not EstDate(DatSimulation.Value) Then
                    DatSimulation.Value = Now.ToShortDateString
                    '   Return False
                End If
                If Not EstDate(Dat_Entree_Text.Text) Then
                    Dat_Entree_Text.Text = DatSimulation.Value
                    '    Return False
                End If
                If Not EstDate(Dat_Naissance_Text.Text) Then
                    Dat_Naissance_Text.Text = DatSimulation.Value.AddYears(-18)
                    '  Return False
                End If
                If Typ_Agent.SelectedIndex = -1 Then
                    Typ_Agent.SelectedValue = "M"
                    '    Return False
                End If
                If Typ_Contrat.SelectedIndex = -1 Then
                    Typ_Contrat.SelectedValue = "CDI"
                    '  Return False
                End If
                If Typ_Periode.SelectedIndex = -1 Then
                    Typ_Periode.SelectedValue = "0"
                    '    Return False
                End If
                '   MsgBox("Fin Calcul  ")
            End If

            'initialiser l'Engine de vbsCode
            initialiserVBS()
            Dim strAG As String = ""
            'Affectation des EP
            strAG &= vbCrLf & "AffectVar Dat_Deb_Periode; """ & DatSimulation.Value.AddDays(-DatSimulation.Value.Day + 1).ToShortDateString & """"
            strAG &= vbCrLf & "AffectVar Dat_Fin_Periode; """ & DatSimulation.Value.AddMonths(1).AddDays(-DatSimulation.Value.Day).ToShortDateString & """"

            'Mise à jour des AG
            strAG &= vbCrLf & "AffectVar CNSS; """ & CNSS_Text.Text & """"
            strAG &= vbCrLf & "AffectVar Organisme1; """ & Organisme1_Text.Text & """"
            strAG &= vbCrLf & "AffectVar Dat_Entree; """ & Dat_Entree_Text.Text & """"
            strAG &= vbCrLf & "AffectVar Typ_Agent; """ & Typ_Agent.SelectedValue & """"
            strAG &= vbCrLf & "AffectVar Grade; """ & Grade_Text.Text & """"
            strAG &= vbCrLf & "AffectVar Nbr_Personne_A_Charge; " & Nbr_Personne_A_Charge.Value
            strAG &= vbCrLf & "AffectVar Typ_Contrat; """ & Typ_Contrat.SelectedValue & """"
            strAG &= vbCrLf & "AffectVar Entite; """ & Cod_Entite_txt.Text & """"
            strAG &= vbCrLf & "AffectVar Nom_Agent; """ & Nom_Agent_Text.Text & """"
            strAG &= vbCrLf & "AffectVar Cod_Plan_Paie; """ & Cod_Plan_Paie_Text.Text & """"
            strAG &= vbCrLf & "AffectVar Dat_Naissance; """ & Dat_Naissance_Text.Text & """"
            strAG &= vbCrLf & "AffectVar Matricule; """ & Matricule_Text.Text & """"
            'mise à jour des cumuls
            With TblRubriqueCumulable
                For Each rw As DataRow In .Rows
                    strAG &= vbCrLf & "AffectVar Cumul_" & rw("Cod_Rubrique") & " ; " & IsNull(rw("Cumul"), 0)
                Next
            End With
            With TblSimulation
                'Mise à jour des éléments au niveau du vbsEngine directement depuis TblSimulation 
                For Each rw As DataRow In TblSimulation.Select("Typ_Function in ('EB','EX','EV') and Typ_Retour in ('float','int')", "Rang Asc")
                    Dim codFunction = rw("Cod_Function")
                    Dim valeur As Double = IsNull(IIf(Not IsNumeric(rw("Valeur")), 0, rw("Valeur")), 0)
                    If "EV;EB".Split(";").Contains(rw("Typ_Function")) Then
                        strAG &= vbCrLf & "AffectVar " & codFunction & " ; " & valeur
                    Else
                        strAG &= vbCrLf & "V_" & codFunction & " = " & valeur
                    End If
                Next
                If strAG <> "" Then _VBS.ExecuteStatement(TraitementCaractere(strAG))
                'calcul
                For Each rp As DataRow In TblSimulation.Select("Typ_Function in ('EC','FU','FP','FS')", "Rang Asc")
                    Dim codFunction = rp("Cod_Function")
                    Dim valeur As Double = _VBS.Eval(TraitementCaractere(codFunction))
                    If Not IsNumeric(valeur) Then valeur = 0
                    rp("Valeur") = valeur
                    If rp("Typ_Function") = "EC" And CBool(rp("estBulletin")) Then
                        If Not dicMat.ContainsKey(codFunction) Then
                            Dim dicRubDetail As New Dictionary(Of String, Double) From {
                                {"Nb", 0},
                                {"Tx", 0},
                                {"Base", 0}
                            }
                            dicMat.Add(codFunction, dicRubDetail)
                        Else
                            dicMat(codFunction)("Nb") = 0
                            dicMat(codFunction)("Tx") = 0
                            dicMat(codFunction)("Base") = 0
                        End If
                        If IsNull(rp("Nb"), "").Trim() = "" Then
                            dicMat(codFunction)("Nb") = 0
                        Else
                            dicMat(codFunction)("Nb") = ConvertNombre(_VBS.Eval(TraitementCaractere(rp("Nb"))))
                        End If
                        If IsNull(rp("Tx"), "").Trim() = "" Then
                            dicMat(codFunction)("Tx") = 0
                        Else
                            dicMat(codFunction)("Tx") = ConvertNombre(_VBS.Eval(TraitementCaractere(rp("Tx"))))
                        End If
                        If IsNull(rp("Base"), "").Trim() = "" Then
                            dicMat(codFunction)("Base") = 0
                        Else
                            dicMat(codFunction)("Base") = ConvertNombre(_VBS.Eval(TraitementCaractere(rp("Base"))))
                        End If
                    End If
                Next
            End With

            'Dim sw As New IO.StreamWriter("e:\traketTumag.txt", True)
            'sw.Write(_VBS.innerCodeStr)
            'sw.Close()
            Return True
        Catch ex As Exception
            ShowMessageBox(ex.Message)
            Return False
        End Try
    End Function
    Function Saving(avecValidation As Boolean) As savingResult
        Dim objSC As Object
        Dim CodFunction As String = ""
        Dim TypFunction As String = ""
        Dim TypRetour As String = ""
        Dim rnd As New Random
        Dim flg As Integer = rnd.Next(1111, 999999)
        Dim dicTmp As New Dictionary(Of String, Double)
        Dim oDat As String = Now
        If Nom_Agent_Text.Text = "" Or Prenom_Agent_Text.Text = "" Then
            Return New savingResult With {.message = "Nom de l'agent vide", .result = False}
        End If
        If Cod_Plan_Paie_Text.Text.Trim = "" Then
            Return New savingResult With {.message = "Plan vide", .result = False}
        End If
        If TblSimulation.Rows.Count = 0 Then
            Return New savingResult With {.message = "Simulation vide", .result = False}
        End If
        If ECSalNet = "" Then
            Return New savingResult With {.message = "Votre plan de paie ne contient pas la rubrique relative au salaire net.", .result = False}
        End If
        If EBSalBaseRef = "" Then
            Return New savingResult With {.message = "Votre plan de paie ne contient pas la rubrique relative au salaire de base.", .result = False}
        End If
        'Calcul
        If Not Calcul() Then
            Return New savingResult With {.message = "Erreur calcul", .result = False}
        End If
        Dim _rw() As DataRow = TblSimulation.Select("Cod_Function='" & ECSalNet & "'")
        If _rw.Length = 0 Then
            Return New savingResult With {.message = "Net à payer null", .result = False}
        ElseIf Not IsNumeric(_rw(0)("Valeur")) Then
            Return New savingResult With {.message = "Net à payer null", .result = False}
        ElseIf CDbl(_rw(0)("Valeur")) = 0 Then
            Return New savingResult With {.message = "Net à payer null", .result = False}
        End If
        Dim CodSimulation = Cod_Simulation_Text.Text
        If CodSimulation = "" Then
            Dim Cp As New ADODB.Recordset
            Cp = CnExecuting("select Top 1 convert(int,right(Cod_Simulation,6)) from RH_Simulation where id_Societe=" & Societe.id_Societe & " order by Cod_Simulation Desc")
            If Not Cp.EOF Then
                CodSimulation = "SM" & Societe.id_Societe & "-" & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
            Else
                CodSimulation = "SM" & Societe.id_Societe & "-000001"
            End If
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from RH_Simulation where Cod_Simulation='" & CodSimulation & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Dat_Crea").Value = oDat
            rs("Created_By").Value = theUser.Login
            rs("id_Societe").Value = Societe.id_Societe
        Else
            rs.Update()
        End If
        rs("Civilite").Value = Civilite_Combo.SelectedValue
        rs("Cod_Simulation").Value = CodSimulation
        rs("Lib_Simulation").Value = Gauche(Lib_Simulation_Text.Text, 250)
        rs("Matricule").Value = Matricule_Text.Text
        rs("Nom_Agent").Value = Nom_Agent_Text.Text
        rs("Prenom_Agent").Value = Prenom_Agent_Text.Text
        rs("Titre").Value = Titre_txt.Text
        rs("Cod_Poste").Value = Poste_Text.Text
        rs("Cod_Grade").Value = Grade_Text.Text
        rs("Cod_Entite").Value = Cod_Entite_txt.Text
        rs("Nbr_Personne_A_Charge").Value = Nbr_Personne_A_Charge.Value
        rs("Cod_Plan_Paie").Value = Cod_Plan_Paie_Text.Text
        If EstDate(Dat_Entree_Text.Text) Then
            rs("Dat_Entree").Value = Dat_Entree_Text.Text
        Else
            rs("Dat_Entree").Value = Now.ToShortDateString
        End If
        rs("Dat_Simulation").Value = rs("Dat_Crea").Value
        rs("Situation").Value = Situation.SelectedValue
        rs("Dat_Naissance").Value = Dat_Naissance_Text.Text
        rs("Typ_Agent").Value = Typ_Agent.SelectedValue
        rs("Typ_Contrat").Value = Typ_Contrat.SelectedValue
        rs("Typ_Periode").Value = Typ_Periode.SelectedValue
        rs("CNSS").Value = CNSS_Text.Text
        rs("Organisme1").Value = Organisme1_Text.Text
        rs("Organisme2").Value = Organisme2_Text.Text
        rs("Organisme3").Value = Organisme3_Text.Text
        rs("Organisme4").Value = Organisme4_Text.Text
        rs("Flag_Maj").Value = flg
        rs("Dat_Modif").Value = oDat
        rs("Modified_By").Value = theUser.Login
        rs("estNouvelleRecrue").Value = estNouvelleRecrue_chk.Checked
        If avecValidation Then
            rs("Statut").Value = "VA"
        End If
        rs.Update()
        rs.Close()
        With TblSimulation
            rs.Open("select * from RH_Simulation_Detail", cn, 2, 2)
            For i = 0 To .Rows.Count - 1
                CodFunction = .Rows(i)("Cod_Function")
                TypFunction = .Rows(i)("Typ_Function")
                TypRetour = .Rows(i)("Typ_Retour")
                objSC = .Rows(i)("Valeur")
                rs.AddNew()
                rs("id_Societe").Value = Societe.id_Societe
                rs("Cod_Simulation").Value = CodSimulation
                rs("Cod_Rubrique").Value = CodFunction
                rs("Typ_Rubrique").Value = TypFunction
                rs("Typ_Retour").Value = TypRetour
                rs("Valeur").Value = ConvertNombre(objSC)
                If dicMat.ContainsKey(CodFunction) Then
                    dicTmp = dicMat(CodFunction)
                    rs("Nb").Value = dicTmp("Nb")
                    rs("Tx").Value = dicTmp("Tx")
                    rs("Base").Value = dicTmp("Base")
                End If
                rs("Rang").Value = i + 1
                rs("Visible").Value = .Rows(i)("Visible")
                rs("Flag_Maj").Value = flg
                rs.Update()
            Next
            rs.Close()
        End With
        CnExecuting("delete from  Rh_Simulation_Detail where id_Societe=" & Societe.id_Societe & " and Cod_Simulation ='" & CodSimulation & "' and Flag_Maj<>" & flg)
        If Cod_Simulation_Text.Text.Trim = "" Then
            Cod_Simulation_Text.Text = CodSimulation
        Else
            Request()
        End If
        TabControl1.SelectedIndex = 0
        Return New savingResult With {.message = "Enregistré avec succès", .result = True}
    End Function

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then

            '   ChargerElementsPaieAgent()

            With MyGrd
                .DataSource = TblSimulation
                If .Columns.Count > 0 Then
                    For Each column As DataGridViewColumn In .Columns
                        column.SortMode = DataGridViewColumnSortMode.NotSortable
                        column.Visible = "Cod_Function;Rubrique;Valeur".Split(";").Contains(column.Name)
                        If Not column.ReadOnly And column.Name <> "Valeur" Then column.ReadOnly = True
                    Next
                    .Columns("Cod_Function").HeaderText = "Code"
                    .Columns("Valeur").DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
                    For i = 0 To .RowCount - 1
                        Dim nRows As DataRow() = TblSimulation.Select("Cod_Function='" & .Item("Cod_Function", i).Value & "'")
                        If .Item("Cod_Function", i).Value = EBSalBaseRef Then
                            .Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(250, 243, 240)
                            .Rows(i).Visible = True
                        ElseIf .Item("Cod_Function", i).Value = ECSalNet Then
                            .Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(219, 196, 240)
                            .Rows(i).Visible = True
                        Else
                            Try
                                .Rows(i).Visible = IsNull(nRows(0)("Visible"), False)
                            Catch ex As Exception

                            End Try

                        End If
                        With .Item("Valeur", i).Style
                            If nRows(0)("Est_Pourcentage") = True Then
                                .Format = "#0.00%"
                            Else
                                .Format = "N" & nRows(0)("Nb_Decimal")
                            End If
                        End With
                        .Rows(i).ReadOnly = Not "EB;EV;EX".Split({";"}, StringSplitOptions.RemoveEmptyEntries).Contains(TblSimulation.Select("Cod_Function='" & .Item("Cod_Function", i).Value & "'")(0)("Typ_Function"))
                        .Rows(i).HeaderCell.Value = TblSimulation.Select("Cod_Function='" & .Item("Cod_Function", i).Value & "'")(0)("Typ_Function")
                        If Not .Rows(i).ReadOnly And .Item("Cod_Function", i).Value <> ECSalNet And .Item("Cod_Function", i).Value <> EBSalBaseRef Then
                            .Item("Valeur", i).Style.BackColor = colorBase04
                        End If
                    Next
                End If
                .AlternatingRowsDefaultCellStyle = Nothing
            End With
        End If
    End Sub

    Private Sub Dat_Naissance_Text_TextChanged(sender As Object, e As EventArgs) Handles Dat_Naissance_Text.TextChanged
        Calcul()
    End Sub

End Class