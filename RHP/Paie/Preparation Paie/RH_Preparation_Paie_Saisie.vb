Imports System.ComponentModel
Imports System.Text.RegularExpressions
Public Class RH_Preparation_Paie_Saisie
    Friend WithEvents BKG_Calcul, BKG_Save, BKG_CollerPressPapier, BKG_NetToBrut As New BackgroundWorker
    Dim PnlWait As New ud_PanelWait
    Friend PrePaie As New PayRollEngine
    Dim avecCloture As Boolean = False
    Dim avecControle As Boolean = False
    Friend EP_str As String
    Friend TblEP As New DataTable
    Friend WithEvents TblPrePaie As New DataTable
    Friend dicLbl As New Dictionary(Of String, Label)
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim New_D As ud_btn
    Dim Import_D As ud_btn
    Dim Conge_D As ud_btn
    Dim Cloture_D As ud_btn
    Dim add_agent_D As ud_btn
    Dim Calcul_D As ud_btn
    Dim Code As String = ""
    Friend _caractereSablier As String = ChrW(&H231B)
    Friend _caractereCurrent As String = ChrW(9733)
    Dim mnu1, mnu2, mnu3, mnu4, mnu5 As New ToolStripMenuItem
    Friend elementDetailBulletinPaie As String()
    Dim _ToolTip As New System.Windows.Forms.ToolTip
    Friend EBSalBase, ECSalNet, ECSalaireBrut, ECChargesPAtronales, EVJrConge, EVAvance, EVPret, EVInteret, EVRembFraisMedic, EVPrimeABrutifier, EVPrimeBrutifiee, EVNoteFrais As String
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Conge_D = dictButtons("Conge_D")
        Cloture_D = dictButtons("Cloture_D")
        add_agent_D = dictButtons("add_agent_D")
        New_D = dictButtons("New_D")
        Import_D = dictButtons("Import_D")
        Calcul_D = dictButtons("Calcul_D")

        With mnu1
            .Name = "collerLeContenu"
            .Text = "Coller le contenu depuis le presse papier"
            .Image = My.Resources.coller_presspapier
            AddHandler .Click, AddressOf CollerLeContenu
        End With
        With mnu2
            .Name = "Supprimer"
            .Text = "Supprimer les matricules"
            .Image = My.Resources.supprimerligne
            AddHandler .Click, AddressOf SupprimerLesLignes
        End With
        With mnu3
            .Name = "ModeFichePaie"
            .Text = "Mode fiche de paie"
            .Image = My.Resources.zoom
            AddHandler .Click, AddressOf ModeFiche
        End With
        With mnu4
            .Name = "ReinitialiserLaColonne"
            .Text = "Vider les valeurs de cette rubrique"
            .Image = My.Resources._Erase
            AddHandler .Click, Sub()
                                   If TblPrePaie.Rows.Count = 0 Then Return
                                   If TypeOf elementPaie_Pln.Tag IsNot Label Then Return
                                   If TblEP.Rows.Count = 0 Then Return
                                   Dim _rubrique = elementPaie_Pln.Tag.name
                                   Dim _rw() As DataRow = TblPrePaie.Select($"Cod_Rubrique='{_rubrique}'")
                                   For Each r In _rw
                                       r("Valeur") = 0
                                   Next
                                   ChargerMatricules()
                                   setRubriqueModified(_rubrique)
                                   CalculTotalRubrique()
                               End Sub
        End With
        With mnu5
            .Name = "FicheAgent"
            .Text = "Ouvrir de la fiche agent"
            .Image = My.Resources.Client
            AddHandler .Click, Sub()
                                   If TblPrePaie.Rows.Count = 0 Then Return
                                   If PrePaie_Grd.SelectedCells.Count = 0 Then Return
                                   Dim Mat = PrePaie_Grd.SelectedCells(0).Value
                                   Dim f As New RH_Agent
                                   With f
                                       .Chargement()
                                       .Matricule_Text.Text = Mat
                                       newShowEcran(f, True)
                                   End With
                               End Sub
        End With
        PrePaie_Grd.ContextMenuStrip.Items.Insert(0, mnu1)
        PrePaie_Grd.ContextMenuStrip.Items.Add(mnu2)
        PrePaie_Grd.ContextMenuStrip.Items.Insert(1, mnu3)
        PrePaie_Grd.ContextMenuStrip.Items.Add(mnu4)
        PrePaie_Grd.ContextMenuStrip.Items.Add(mnu5)

    End Sub
    Sub ModeFiche()
        If PrePaie_Grd.RowCount = 0 Then Return
        Dim _r = TblEP.Select("Modified='true'")
        If _r.Length > 0 Then
            ShowMessageBox("Votre préparation n'est pas encore enregistrée. Les modifications ne seront pas pris en charge.", "Mode fiche de paie")
        End If
        Dim r As Integer = -1
        If PrePaie_Grd.SelectedCells.Count > 0 Then
            r = PrePaie_Grd.SelectedCells(0).RowIndex
        End If
        If r = -1 Then Return
        Dim f As New Zoom_RH_Preparation_Paie_Saisie
        With f
            .frmPrePaie = Me
            .Cloture_Check.Checked = Cloture_Check.Checked
            .CodPlan = Cod_Plan_Paie_Text.Text
            .CodPreparation = Cod_Preparation_Text.Text
            .inDx = r
            .Matricule_txt.Text = PrePaie_Grd.Item("Matricule", r).Value
            .Bulletin_chk.Checked = (elementDetailBulletinPaie?.Length > 0)
            .Request()
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Cod_Preparation_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Preparation_Text.TextChanged
        CnExecuting("delete from Controle_Access where id_Societe='" & Societe.id_Societe & "' and  Name_Ecran='RH_Preparation_Paie' and value='" & Code & "'")
        Save_D.Enabled = True
        Conge_D.Enabled = True
        Import_D.Enabled = True
        add_agent_D.Enabled = True
        Calcul_D.Enabled = True
        Cloture_D.Image = My.Resources.btn_unlock
        Cloture_D.Enabled = True
        Del_D.Enabled = True
        DroitAcces(Me, DroitModify_Fiche(Cod_Preparation_Text.Text, Me))
        Dim TblPrepa As DataTable = DATA_READER_GRD("Select isnull(Lib_Preparation,'') as Lib_Preparation,isnull(Cod_Plan_Paie,'') as Cod_Plan_Paie,
                                                    Dat_Deb_Periode, Dat_Fin_Periode, isnull(Cloture,'false') as Cloture ,isnull(ElementPaie,'') as ElementPaie  ,isnull(ElementDetail,'') as ElementDetail  
                                                    from RH_Preparation_Paie where Cod_Preparation='" & Cod_Preparation_Text.Text & "'")
        If TblPrepa.Rows.Count > 0 Then
            Dat_Deb_Periode_Text.Text = TblPrepa.Rows(0).Item("Dat_Deb_Periode")
            Dat_Fin_Periode_Text.Text = TblPrepa.Rows(0).Item("Dat_Fin_Periode")
            Cloture_Check.Checked = TblPrepa.Rows(0).Item("Cloture")
            Cod_Plan_Paie_Text.Text = TblPrepa.Rows(0).Item("Cod_Plan_Paie")
        Else
            Cod_Plan_Paie_Text.Text = ""
            Dat_Deb_Periode_Text.Text = ""
            Dat_Fin_Periode_Text.Text = ""
            Cloture_Check.Checked = False
            Reset_Form(Me)
        End If
        If Cloture_Check.Checked Then
            Cloture_D.Image = My.Resources.btn_lock
            Cloture_D.Enabled = False
            Save_D.Enabled = False
            Del_D.Enabled = False
            add_agent_D.Enabled = False
            Calcul_D.Enabled = False
        Else
            Cloture_D.Image = My.Resources.btn_unlock
        End If
        Conge_D.Enabled = Save_D.Enabled
        Import_D.Enabled = Save_D.Enabled
        add_agent_D.Enabled = Save_D.Enabled
        Calcul_D.Enabled = Save_D.Enabled
        mnu1.Enabled = Save_D.Enabled
        mnu2.Enabled = Save_D.Enabled
        If Save_D.Enabled = True And Cod_Preparation_Text.Text.Trim <> "" And Code <> Cod_Preparation_Text.Text Then
            Code = Cod_Preparation_Text.Text
            Check_Accessible("RH_Preparation_Paie", Code)
        End If
    End Sub
    Private Sub Plan_Paie__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Plan_Paie_.LinkClicked
        If Cod_Preparation_Text.Text <> "" Then
            MessageBoxRHP(710)
            Exit Sub
        End If
        Appel_Zoom1("MS069", Cod_Plan_Paie_Text, Me)
    End Sub
    Private Sub Cod_Preparation__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Cod_Preparation_.LinkClicked
        Appel_Zoom1("MS013", Cod_Preparation_Text, Me)
    End Sub
    Private Sub Plan_Paie_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        If Cod_Plan_Paie_Text.Text = "" Then
            Initialisation()
            Return
        End If
        Dim TblPlan As DataTable = DATA_READER_GRD("select * from RH_Param_Plan_Paie where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        EB_chk.Enabled = Cod_Plan_Paie_Text.Text <> ""
        EV_chk.Enabled = Cod_Plan_Paie_Text.Text <> ""
        Tout_Chk.Enabled = Cod_Plan_Paie_Text.Text <> ""
        With TblPlan
            If .Rows.Count > 0 Then
                EVJrConge = IsNull(.Rows(0)("NbJrConge"), "")
                EVAvance = IsNull(.Rows(0)("Avance"), "")
                EVPret = IsNull(.Rows(0)("Pret"), "")
                EVInteret = IsNull(.Rows(0)("Interet"), "")
                EVRembFraisMedic = IsNull(.Rows(0)("RembFraisMedic"), "")
                EVNoteFrais = IsNull(.Rows(0)("RembNoteFrais"), "")
                EVPrimeABrutifier = IsNull(.Rows(0)("PrimeABrutifier"), "")
                EVPrimeBrutifiee = IsNull(.Rows(0)("PrimeBrutifiee"), "")
                ECSalNet = IsNull(.Rows(0)("SalNet"), "")
                EBSalBase = IsNull(.Rows(0)("SalBase"), "")
                ECSalaireBrut = IsNull(.Rows(0)("SalBrut"), "")
                ECChargesPAtronales = IsNull(.Rows(0)("ChargesPatronales"), "")
                EP_str = IsNull(.Rows(0)("Element_Paie"), "")
                Lib_Plan_Paie_Text.Text = IsNull(.Rows(0)("Lib_Plan_Paie"), "")
                elementDetailBulletinPaie = IsNull(.Rows(0)("Element_Detail"), "").Trim.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                If Cod_Preparation_Text.Text = "" Then
                    Dim JourDeb As Integer = 1
                    Dim AnneePaie As Integer = CnExecuting($"select isnull((select top 1 year(Dat_Fin) Annee from Param_Periode_Paie where id_Societe={Societe.id_Societe} and isnull(Cloture,'false')='false'  order by Dat_Deb desc), year(getdate()))").Fields(0).Value
                    Dim DateDeb As Date = CDate("01/" & Now.Month & "/" & AnneePaie)
                    Dim dt As String = ""
                    JourDeb = IsNull(.Rows(0)("JourPaie"), 1)
                    dt = JourDeb & "/" & IsNull(.Rows(0)("LastMoisPaie"), "") & "/" & IsNull(.Rows(0)("LastAnneePaie"), "")
                    If IsDate(dt) Then
                        DateDeb = CDate(dt).AddMonths(1)
                    End If
                    Dat_Deb_Periode_Text.Text = DateDeb.ToShortDateString
                    Dat_Fin_Periode_Text.Text = DateDeb.AddMonths(1).AddDays(-1).ToShortDateString
                End If
            Else
                EP_str = ""
                Lib_Plan_Paie_Text.Text = ""
                EVJrConge = ""
                EVAvance = ""
                EVPret = ""
                EVInteret = ""
                EVRembFraisMedic = ""
                EVNoteFrais = ""
                EVPrimeABrutifier = ""
                EVPrimeBrutifiee = ""
                EBSalBase = ""
                ECSalNet = ""
                ECSalaireBrut = ""
                ECChargesPAtronales = ""
                elementDetailBulletinPaie = "".Split(";")
            End If
        End With
        If Not Refreshing() Then
            Initialisation()
            Return
        End If
        MajDonneePlan()
    End Sub
    Sub MajDonneePlan()
        Cursor = Cursors.WaitCursor
        Dim sqlStr = $"declare @Ep varchar(max),@idSoc int
IF OBJECT_ID('tempdb..#tbl') IS NOT NULL
    DROP TABLE #tbl;
set @idSoc={Societe.id_Societe}
set @Ep='{EP_str}'
select   Cod_Rubrique ,1 as nb 
into #tbl
from RH_Preparation_Paie_Detail
where Cod_Preparation='{Cod_Preparation_Text.Text}' and Typ_Rubrique in ('EV','EB') and id_Societe=@idSoc group by Cod_Rubrique having sum(Valeur)!=0
select e.Cod_Rubrique,Lib_Rubrique,Val_Defaut as DefaultValeur,case when EB=1 then 'EB' else 'EV' end Typ_Rubrique,
isnull(t.nb,0) as nb,  
case when Typ_Retour='int' then 'N0' 
when Typ_Retour='float' then 'N'+convert(nvarchar(1),Nb_Decimal) 
when Typ_Retour='float' and Est_Pourcentage=1 then 'P2'
end as Typ_Retour ,convert(bit,'false') as Modified
from RH_Paie_Rubrique e left join #Tbl t on e.Cod_Rubrique=t.Cod_Rubrique
outer apply(select items,indx from dbo.Splitfn(@EP,';') where e.Cod_Rubrique=items)ep
where (EV=1 or EB=1) and isnull(nullif(id_Societe,-1),@idSoc)=@idSoc and ISNULL(ep.items,'')!='' 
order by indx"
        TblEP = DATA_READER_GRD(sqlStr)
        TblEP.Columns("Modified").ReadOnly = False
        sqlStr = $"declare @CodPreparation nvarchar(50), @CodPlanPaie nvarchar(50),@EP varchar(max),@idSoc int
set @CodPreparation='{Cod_Preparation_Text.Text}'
set @idSoc={Societe.id_Societe}
set @CodPlanPaie='{Cod_Plan_Paie_Text.Text }'
if @CodPreparation!=''
begin
select Matricule,Nom,Cod_Rubrique,Valeur from RH_Preparation_Paie_Detail d
outer apply (select Nom_Agent+' '+Prenom_Agent as Nom from RH_Agent where id_Societe=d.id_Societe and Matricule=d.Matricule)a
where Cod_Preparation=@CodPreparation and Typ_Rubrique in ('EV','EB')
order by Matricule
end
else
begin
select @EP = Element_Paie from RH_Param_Plan_Paie where id_Societe=@idSoc
select Matricule, Nom_Agent+' '+Prenom_Agent as  Nom,Cod_Function as Cod_Rubrique,convert(float,case when isnumeric(isnull(Valeur,Formule_Function))=1 then isnull(Valeur,Formule_Function) else 0 end)  as Valeur from  
 RH_Agent a cross join RH_Elements_Paie p 
outer apply(select Valeur from RH_Agent_Element_Paie where id_Societe=a.id_Societe and Matricule=a.Matricule and Cod_Rubrique=p.Cod_Function) ep
 where a.id_Societe=isnull(nullif(p.id_Societe,-1),a.id_Societe) and a.id_Societe=@idSoc and Plan_Paie=@CodPlanPaie
 and Typ_Function in ('EV','EB')
and ';'+@EP+';' like '%;'+Cod_Function+';%' and ISNULL(Droit_Paie,0)=1    
and not exists(select 1 from RH_Preparation_Paie_Detail d left join RH_Preparation_Paie e on e.Cod_Preparation=d.Cod_Preparation
                    where '" & Dat_Deb_Periode_Text.Text & "' <= Dat_Fin_Periode and '" & Dat_Fin_Periode_Text.Text & "' >= Dat_Deb_Periode  and isnull(Plan_Paie,'')=@CodPlanPaie  and d.id_Societe=@idSoc and d.Matricule=a.Matricule and d.Cod_Preparation!='" & Cod_Preparation_Text.Text & "')
order by Matricule
end "
        TblPrePaie = DATA_READER_GRD(sqlStr)
        TblPrePaie.Columns("Valeur").ReadOnly = False
        TblPrePaie.Columns("Valeur").DefaultValue = 0
        If Not EB_chk.Checked And Not EV_chk.Checked And Not Tout_Chk.Checked Then
            EV_chk.Checked = True
        Else
            generateEP()
        End If
        Cursor = Cursors.Default
    End Sub
    Sub generateEP()
        elementPaie_Pln.Controls.Clear()
        dicLbl.Clear()
        If TblEP Is Nothing Then Return
        If TblEP.Rows.Count = 0 Then Return
        Dim TblEPTmp = If(Tout_Chk.Checked, TblEP.Select().CopyToDataTable, TblEP.Select($"Typ_Rubrique='{If(EB_chk.Checked, "EB", "EV")}'").CopyToDataTable)
        If TblEPTmp Is Nothing Then Return
        If TblEPTmp.Rows.Count = 0 Then Return
        Dim sp As Integer = 3
        Dim oX As Integer = sp
        Dim oY As Integer = sp
        With TblEPTmp
            For i = 0 To .Rows.Count - 1
                Dim contextMenu As New ContextMenuStrip
                Dim _mnu As New ToolStripMenuItem
                Dim index As Integer = i
                With _mnu
                    .Text = "Editer la rubrique"
                    .Image = My.Resources.edit_6_xxl
                    AddHandler .Click, Sub()
                                           Dim f As New RH_Parametrage_Rubrique_Paie
                                           With f
                                               .Cod_Rubrique_txt.Text = TblEPTmp.Rows(index).Item("Cod_Rubrique")
                                               .Request()
                                               newShowEcran(f, True)
                                           End With
                                       End Sub
                End With
                contextMenu.Items.Add(_mnu)
                Dim obtn As New Label
                With obtn
                    .BorderStyle = BorderStyle.None
                    .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
                    .Tag = i = 0
                    .ContextMenuStrip = contextMenu
                    .BackColor = colorBase04
                    .ForeColor = colorBase01
                    .Name = TblEPTmp.Rows(i).Item("Cod_Rubrique")
                    .AutoSize = True
                    .MinimumSize = New Size(80, 25)
                    .MaximumSize = New Size(200, 25)
                    .Text = If(CBool(TblEPTmp.Rows(i)("Modified")), _caractereSablier, If(TblEPTmp.Rows(i).Item("nb") = 0, "", _caractereCurrent)) & " " & TblEPTmp.Rows(i)("Lib_Rubrique")
                    .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    _ToolTip.SetToolTip(obtn, .Name & vbCrLf & .Text)
                    .Cursor = Cursors.Hand
                    elementPaie_Pln.Controls.Add(obtn)
                    dicLbl.Add(.Name, obtn)
                    AddHandler .Paint, AddressOf LblBordure
                    AddHandler .MouseUp, Sub()
                                             elementPaieClicked(obtn)
                                         End Sub
                    If i = 0 Then
                        elementPaie_Pln.Tag = obtn
                        elementPaieClicked(obtn)
                    End If
                End With
            Next

        End With
        ReorganiserLbl()
    End Sub
    Sub ReorganiserLbl()
        Dim sp As Integer = 3
        Dim oX As Integer = sp
        Dim oY As Integer = sp
        For Each lb In elementPaie_Pln.Controls
            With lb
                .Location = New Point(oX, oY)
                If oX + .Width + sp < elementPaie_Pln.Width - 130 Then
                    oX += .Width + sp
                Else
                    oX = sp
                    oY += .Height + sp
                End If
            End With
        Next
    End Sub
    Dim formatString As String = "N2"
    Sub elementPaieClicked(btn As Label)
        Dim _rw() = TblEP.Select($"Cod_Rubrique='{btn.Name}'")
        If _rw.Length = 0 Then Return
        With btn
            If TypeOf elementPaie_Pln.Tag Is Label Then
                With CType(elementPaie_Pln.Tag, Label)
                    .Tag = False
                    .BackColor = colorBase04
                    .ForeColor = colorBase01
                End With
            End If

            If CBool(.Tag) Then
                .BackColor = colorBase04
                .ForeColor = colorBase01
            Else
                .BackColor = colorBase01
                .ForeColor = Color.White
            End If
            elementPaie_Pln.Tag = btn
            .Tag = Not CBool(.Tag)
        End With
        If PrePaie_Grd.Columns.Count > 0 Then
            PrePaie_Grd.Columns("Valeur").HeaderText = _rw(0)("Lib_Rubrique")
        End If
        TotalRubrique_txt.Text = "0,00"
        formatString = _rw(0)("Typ_Retour")
        ChargerMatricules()
        CalculTotalRubrique()
    End Sub
    Sub ChargerMatricules()
        If TblPrePaie Is Nothing Then Return
        If TblPrePaie.Rows.Count = 0 Then Return
        ' Apply changes to remove the rows from the DataTable
        TblPrePaie.AcceptChanges()
        Dim TblTmp As New DataTable
        Dim rows As DataRow() = TblPrePaie.Select($"Cod_Rubrique='{elementPaie_Pln.Tag.Name}'")
        If rows.Length > 0 Then
            TblTmp = rows.CopyToDataTable() ' Copy the rows to the DataTable if there are any
        Else
            TblTmp = TblPrePaie.Clone
            For Each r As DataRow In TblPrePaie.DefaultView.ToTable(True, "Matricule", "Nom").Rows
                TblPrePaie.Rows.Add(r("Matricule"), r("Nom"), elementPaie_Pln.Tag.Name, 0)
                TblTmp.Rows.Add(r("Matricule"), r("Nom"), elementPaie_Pln.Tag.Name, 0)
            Next
        End If
        With TblTmp
            .Columns("Valeur").ReadOnly = False
            .Columns("Valeur").DefaultValue = 0
        End With

        With PrePaie_Grd
            .DataSource = TblTmp
            .Columns("Cod_Rubrique").Visible = False
            .Columns("Matricule").ReadOnly = True
            .Columns("Nom").ReadOnly = True
            With .Columns("Valeur").DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .NullValue = "0,00" ' Set a default value if the cell is empty
                .Format = formatString ' Apply numeric format with 2 decimal places
            End With
        End With
    End Sub
    Sub LblBordure(sender As Label, e As PaintEventArgs)
        ControlPaint.DrawBorder(e.Graphics, sender.DisplayRectangle, colorBase01, ButtonBorderStyle.Solid)
    End Sub
    Private Sub Dat_Deb_Periode__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Dat_Deb_Periode_.LinkClicked
        If Cod_Preparation_Text.Text <> "" Then Return
        Appel_Calender_Blocage(Dat_Deb_Periode_Text, Me, "Compta")
        MajDonneePlan()
    End Sub
    Private Sub Dat_Deb_Periode_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dat_Deb_Periode_Text.TextChanged
        If Not EstDate(Dat_Deb_Periode_Text.Text) Then Exit Sub
        Dat_Fin_Periode_Text.Text = FormatDateTime((CDate(Dat_Deb_Periode_Text.Text).AddMonths(1).AddDays(-1)).Date, DateFormat.ShortDate)

    End Sub
    Private Sub Dat_Fin_Periode_Text_TextChanged_1(sender As Object, e As EventArgs) Handles Dat_Fin_Periode_Text.TextChanged
        PrePaie_Grd.DataSource = Nothing

    End Sub
    Private Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        MajDonneePlan()
    End Sub
    Private Sub PrePaie_Grd_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles PrePaie_Grd.EditingControlShowing
        With PrePaie_Grd
            If .CurrentCell.ColumnIndex = .Columns("Valeur").Index Then
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With PrePaie_Grd
            Dim NomCol As String = .Columns(.CurrentCell.ColumnIndex).Name
            If .CurrentCell.ColumnIndex = .Columns("Valeur").Index Then
                ControleSaisie(.CurrentCell, e, True, False, False, False, False)
            End If
        End With
    End Sub
    Sub Initialisation()
        PrePaie = New PayRollEngine
        PrePaie_Grd.DataSource = Nothing
        Reset_Form(EntPnl)
        Code = "XYZ"
        otimer.Stop()
        PrePaie.oAvancementStr = ""
        PrePaie.oAvancementStrTitre = ""
        PrePaie.PaieCloture = False

    End Sub
    Sub Nouveau()
        Dim pln As String = IsNull(Cod_Plan_Paie_Text.Text, FindLibelle("Cod_Plan_Paie", "id_Societe", Societe.id_Societe, "Rh_Param_Plan_Paie"))
        Initialisation()
        Cod_Plan_Paie_Text.Text = pln
    End Sub
    Function Refreshing() As Boolean
        Cursor = Cursors.WaitCursor
        Dim nBMat As New ADODB.Recordset
        If Cod_Plan_Paie_Text.Text = "" Then
            MessageBoxRHP(706)
            Cursor = Cursors.Default
            Return False
        Else
            Dim f As New RH_Parametrage_Plan_Paie
            With f
                .Cod_Plan_Paie_Text.Text = Cod_Plan_Paie_Text.Text
                .Request()
                If Not .Saving(True) Then
                    ShowMessageBox("Veuillez d'abord valider le plan de paie avant de continuer votre préparation.", "Contrôle", MessageBoxButtons.OK, msgIcon.Error)
                    Cursor = Cursors.Default
                    Return False
                End If
            End With
        End If
        If Not EstDate(Dat_Deb_Periode_Text.Text) Or Not EstDate(Dat_Fin_Periode_Text.Text) Then
            MessageBoxRHP(707)
            Cursor = Cursors.Default
            Return False
        End If
        If CDate(Dat_Deb_Periode_Text.Text) >= CDate(Dat_Fin_Periode_Text.Text) Then
            ShowMessageBox("Incohérence date début et date fin", "Erreur date", MessageBoxButtons.OK, msgIcon.Stop)
            Cursor = Cursors.Default
            Return False
        End If
        If CnExecuting("Select count(*) from Param_Periode_Paie where isnull(Cloture,'false')='false' and Annee='" & ConvertDate(Dat_Fin_Periode_Text.Text).Year & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
            ShowMessageBox("Année de paie non ouverte", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Dim f As New Zoom_PPeriodeAjouter
            f.ShowDialog()
            Cursor = Cursors.Default
            Return False
        End If
        Dim TblConge As DataTable = DATA_READER_GRD("select * 
from RH_Conge_Suivi s
where isnull(Statut,'')='' and id_Societe=" & Societe.id_Societe & "
and Dat_Fin_Conge<='" & Dat_Fin_Periode_Text.Text & "' 
and exists(select Matricule from RH_Agent where id_Societe=s.id_Societe 
and Matricule=s.Matricule and Plan_Paie='" & Cod_Plan_Paie_Text.Text & "') ")
        If TblConge.Rows.Count > 0 Then
            ShowMessageBox("Il existe des demandes de congé non encore traitées.", "Congés non traités", MessageBoxButtons.OK, msgIcon.Stop)
            Cursor = Cursors.Default
            Return False
        End If
        If CnExecuting("Select count(*) as   nb
FROM         RH_Paie_Avance
WHERE     (id_Societe = " & Societe.id_Societe & ") AND (Dat_Demande <= '" & Dat_Fin_Periode_Text.Text & "') AND (ISNULL(Statut, N'') = '')").Fields(0).Value > 0 Then
            ShowMessageBox("Il existe des demandes d'avance non encore traitées.", "Avances non traitées", MessageBoxButtons.OK, msgIcon.Stop)
            Cursor = Cursors.Default
            Return False
        End If
        If CnExecuting("Select count(*) as   nb
FROM         RH_Pret
WHERE     (id_Societe = " & Societe.id_Societe & ") AND (Dat_Demande <= '" & Dat_Fin_Periode_Text.Text & "') AND (ISNULL(Statut, N'') = '')").Fields(0).Value > 0 Then
            ShowMessageBox("Il existe des prêts non encore traitées.", "Prêts non traités", MessageBoxButtons.OK, msgIcon.Stop)
            Cursor = Cursors.Default
            Return False
        End If
        If Cod_Preparation_Text.Text = "" Then
            If CnExecuting("Select count(*) from  RH_Preparation_Paie where  Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and isnull(Cloture,'false')='false' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
                ShowMessageBox("Il existe en moins une préparation non clôturée pour ce plan", "Nouvelle paie", MessageBoxButtons.OK, msgIcon.Stop)
                Cursor = Cursors.Default
                Return False
            End If
            Dim NbStr As String = "declare @D1 smalldatetime,@D2 smalldatetime 
                              set @D1='" & Dat_Deb_Periode_Text.Text & "' 
                              set @D2='" & Dat_Fin_Periode_Text.Text & "' 
                             select Matricule,Cod_Preparation from Sys_RH_Preparation_Paie 
where Cod_Preparation<>'' and Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe & "
and ((@D1 between convert(smalldatetime,Dat_Deb_Periode) 
and convert(smalldatetime,Dat_Fin_Periode))or(@D2 between convert(smalldatetime,Dat_Deb_Periode) 
and convert(smalldatetime,Dat_Fin_Periode)))
group by Matricule,Cod_Preparation"

            nBMat.Open(NbStr, cn, 3, 3)
            If Not nBMat.EOF Then
                MessageBoxRHP(703, nBMat("Cod_Preparation").Value & ";" & nBMat("Matricule").Value)
                Cursor = Cursors.Default
                Return False
            End If
            nBMat.Close()
        End If
        PrePaie.strEP = IsNull(CnExecuting("declare @EE nvarchar(max)
select @EE = ';'+isnull(Element_Paie,'')+';' from RH_Param_Plan_Paie where id_Societe =" & Societe.id_Societe & " and Cod_Plan_Paie ='" & Cod_Plan_Paie_Text.Text & "'
select isnull((select top 1 Cod_Rubrique  
from RH_Preparation_Paie_Detail where id_Societe =" & Societe.id_Societe & "
group by Cod_Rubrique
order by case when patindex('%;'+Cod_Rubrique+';%',@EE)=0 then 999999 else patindex('%;'+Cod_Rubrique+';%',@EE) end),'')").Fields(0).Value, ";").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        Cursor = Cursors.Default
        Return True
    End Function
    Sub Cloturer()
        avecCloture = True
        Saving()
    End Sub
    Sub Saving()
        If BKG_Save.IsBusy Then
            ShowMessageBox("Opération d'enregistrement en cours", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Cloture_Check.Checked Then
            MessageBoxRHP(705)
            Cursor = Cursors.Default
            Exit Sub
        End If
        If Cod_Plan_Paie_Text.Text = "" Then
            MessageBoxRHP(706)
            Cursor = Cursors.Default
            Exit Sub
        End If
        If Not EstDate(Dat_Deb_Periode_Text.Text) Or Not EstDate(Dat_Fin_Periode_Text.Text) Then
            MessageBoxRHP(707)
            Cursor = Cursors.Default
            Exit Sub
        End If
        If CDate(Dat_Deb_Periode_Text.Text) >= CDate(Dat_Fin_Periode_Text.Text) Then
            ShowMessageBox("Incohérence date début et date fin", "Erreur date", MessageBoxButtons.OK, msgIcon.Stop)
            Cursor = Cursors.Default
            Exit Sub
        End If
        If CnExecuting("Select count(*) from Param_Periode_Paie where isnull(Cloture,'false')='false' and Annee='" & ConvertDate(Dat_Fin_Periode_Text.Text).Year & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
            ShowMessageBox("Année de paie non ouverte", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        AttendreProcess(True)
        If Not avecCloture Then avecControle = ShowMessageBox("Voulez-vous contrôler la paie à l'enregistrement?", "Contrôle des erreurs", MessageBoxButtons.YesNo, msgIcon.Question) = MsgBoxResult.Yes
        BKG_Save.RunWorkerAsync()
    End Sub
    Dim rslSaving As New PayRollEngine.savingResult
    Private Sub BKG_Save_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_Save.DoWork
        Dim k As Integer = 1
        Dim ep() = TblEP.Select($"Typ_Rubrique='EB' and Modified='true'")
        If ep.Length > 0 Then
            Dim maj = ShowMessageBox("Vous êtes sur le point de mettre à jour les éléments de base des agents sélectionnés." & vbCrLf & "Etes-vous sûr de vouloir continuer?", "Mise à jour des élements de base", MessageBoxButtons.YesNoCancel, msgIcon.Stop)
            If maj = MsgBoxResult.Cancel Then
                Return
            ElseIf maj = MsgBoxResult.Yes Then
                'Mise à jour des éléments de base EB
                _msgAttente = "Enregister les éléments de base"
                Dim rs As New ADODB.Recordset
                Dim flg As Integer = (New Random).Next(100, 9000)
                For Each _eb As DataRow In ep
                    '2.1 j'insère chaque ligne de TblPrepaie vers PrePaie.TblPrePaie
                    k = 1
                    Dim _pr() = TblPrePaie.Select($"Cod_Rubrique='{_eb("Cod_Rubrique")}'")
                    For Each p In _pr
                        _msgAttente = "Enregister les éléments de base" & vbCrLf & _eb("Lib_Rubrique") & $" : {k} / { _pr.Length}"
                        rs.Open($"select * from RH_Agent_Element_Paie where id_Societe={Societe.id_Societe} and Matricule='{p("Matricule")}' and Cod_Rubrique='{_eb("Cod_Rubrique")}'", cn, 2, 2)
                        If rs.EOF Then
                            rs.AddNew()
                            rs("id_Societe").Value = Societe.id_Societe
                            rs("Matricule").Value = p("Matricule")
                            rs("Cod_Rubrique").Value = p("Cod_Rubrique")
                        Else
                            rs.Update()
                        End If
                        rs("Valeur").Value = p("Valeur")
                        rs("Flg").Value = flg
                        rs.Update()
                        rs.Close()
                        k += 1
                    Next
                Next
                'Supprimer les EB null
                CnExecuting($"delete from RH_Agent_Element_Paie where id_Societe={Societe.id_Societe} and Valeur=0")
                k = 1
            End If
        End If
        _msgAttente = ""
        PrePaie.Request(Cod_Preparation_Text.Text, Cod_Plan_Paie_Text.Text, Dat_Deb_Periode_Text.Text, Dat_Fin_Periode_Text.Text, False)
        '1-Je synchronise les matricules
        '1.1 ajouter les nouveaux matricules
        Dim Mat = TblPrePaie.DefaultView.ToTable(True, "Matricule")
        For Each r In Mat.Rows
            If PrePaie.TblPrePaie.Select($"Matricule='{r("Matricule")}'").Length = 0 Then
                Dim dr = PrePaie.TblPrePaie.NewRow
                dr("Matricule") = r("Matricule")
                For Each c As DataColumn In PrePaie.TblPrePaie.Columns
                    If c.DataType = System.Type.GetType("System.Boolean") Or c.DataType = System.Type.GetType("System.Double") Or c.DataType = System.Type.GetType("System.Integer") Then
                        dr(c.ColumnName) = 0
                    End If
                Next
                PrePaie.TblPrePaie.Rows.Add(dr)
            End If
        Next
        '1.2 supprimer les matricules non existents ou supprimés
        Mat = PrePaie.TblPrePaie.DefaultView.ToTable(True, "Matricule")
        For i = Mat.Rows.Count - 1 To 0 Step -1
            If TblPrePaie.Select($"Matricule='{Mat.Rows(i)("Matricule")}'").Length = 0 Then
                PrePaie.TblPrePaie.Rows.RemoveAt(i)
            End If
        Next
        '2 insértion des données
        For Each _r As DataRow In TblEP.Select(If(Cod_Preparation_Text.Text = "", "", "Modified='true'"))
            '2 je Vérifie si toutes les rubriques existent au niveau de la table  PrePaie.TblPrePaie sinon je les crée
            If Not PrePaie.TblPrePaie.Columns.Contains(_r("Cod_Rubrique")) Then
                Dim c As New DataColumn With {
                        .ColumnName = _r("Cod_Rubrique"), .DataType = System.Type.GetType("System.Double"), .ReadOnly = False, .DefaultValue = 0
                    }
                PrePaie.TblPrePaie.Columns.Add(c)
            End If
            '2.1 j'insère chaque ligne de TblPrepaie vers PrePaie.TblPrePaie
            Dim _row As DataRow() = TblPrePaie.Select($"Cod_Rubrique='{_r("Cod_Rubrique")}'")
            For i = 0 To _row.Length - 1
                PrePaie.TblPrePaie.Select($"Matricule='{_row(i)("Matricule")}'")(0)(_r("Cod_Rubrique")) = _row(i)("Valeur")
            Next
        Next
        'j'insère chaque ligne de TblPrepaie vers PrePaie.TblPrePaie
        rslSaving = PrePaie.Saving($"Paie du plan {Cod_Plan_Paie_Text.Text} du {Dat_Deb_Periode_Text.Text} au {Dat_Fin_Periode_Text.Text}", avecCloture Or avecControle, avecCloture)
    End Sub
    Private Sub BKG_Save_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_Save.RunWorkerCompleted
        If rslSaving.result Then
            PrePaie.CalculAuto = False
            If PrePaie.CodPreparation <> IsNull(Cod_Preparation_Text.Text, "") Then
                Cod_Preparation_Text.Text = PrePaie.CodPreparation
            End If
            If avecCloture Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
                avecCloture = False
                Cloture_Check.Checked = True
                Cloture_D.Image = My.Resources.btn_lock
                Cloture_D.Enabled = False
                Save_D.Enabled = False
                Del_D.Enabled = False
                add_agent_D.Enabled = False
                Calcul_D.Enabled = False
            End If
            PrePaie.CalculAuto = True
            PrePaie.Modifie = False
            Plan_Paie_Text_TextChanged(Nothing, Nothing)
            AttendreProcess(False)
        Else
            ShowMessageBox(rslSaving.message, "Enregistrer la préparation de paie", MessageBoxButtons.OK, msgIcon.Stop)
            If rslSaving.NotDroitPaie.Count > 0 Then
                With PrePaie_Grd
                    Dim firstLig As Integer = -1
                    For i = 0 To .RowCount - 1
                        If rslSaving.NotDroitPaie.Contains(.Item("Matricule", i).Value) Then
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                            firstLig = i
                        ElseIf .Rows(i).DefaultCellStyle.ForeColor = Color.Red Then
                            .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                        End If
                    Next
                    If firstLig >= 0 Then .FirstDisplayedCell = .Item(0, firstLig)
                End With
            End If
            AttendreProcess(False)
        End If
        If PrePaie.Tbl_Controles.Rows.Count > 0 And PrePaie.Tbl_Controles.Select("Bloquant='true'").Length = 0 Then
            ShowMessageBox("Votre préparation contient des erreurs.", "Contrôle", MessageBoxButtons.OK, msgIcon.Warning)
            Dim f As New Zoom_Libre
            With f
                .Text = "Contrôle des erreurs de la paie"
                .Libre_GRD.DataSource = PrePaie.Tbl_Controles
                .ShowDialog()
            End With
        End If
    End Sub
    Sub Import()
        If PrePaie_Grd.RowCount = 0 Then
            ShowMessageBox("Veuillez générer d'abord votre préparation", "Importation des éléments variables", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        If elementPaie_Pln.Controls.Count = 0 Then
            ShowMessageBox("Veuillez générer charger les éléments de la paie du plan.", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        Dim f As New RH_Preparation_Paie_Saisie_Import
        With f
            .frm_Paie = Me
            If TypeOf elementPaie_Pln.Tag Is Label Then ._currentEP = elementPaie_Pln.Tag.name
            If Not Tout_Chk.Checked Then ._filter = IIf(EB_chk.Checked, "Typ_Rubrique='EB'", "Typ_Rubrique='EV'")
            newShowEcran(f, True)
        End With
    End Sub
    Private Sub EV_chk_CheckedChanged(sender As Object, e As EventArgs) Handles EV_chk.CheckedChanged, EB_chk.CheckedChanged, Tout_Chk.CheckedChanged
        If sender.Checked Then
            generateEP()
        End If
    End Sub
    Private Sub PrePaie_Grd_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles PrePaie_Grd.CellValidated
        With PrePaie_Grd
            If e.RowIndex < 0 Then Return
            If .Rows.Count = 0 Then Return
            If dicLbl.Count = 0 Then Return
            If e.ColumnIndex = .Columns("Valeur").Index And IsNull(.Item(.Columns("Matricule").Index, e.RowIndex).Value, "") <> "" Then
                If Not IsNumeric(IsNull(.Item("Valeur", e.RowIndex).Value, "xx")) Then
                    .Item("Valeur", e.RowIndex).Value = 0
                    Dim nrw() = TblPrePaie.Select($"Matricule='{ .Item(.Columns("Matricule").Index, e.RowIndex).Value}' and Cod_Rubrique='{elementPaie_Pln.Tag.name}'")
                    If nrw.Length > 0 Then
                        nrw(0)("Valeur") = 0
                    End If
                End If
                If TypeOf elementPaie_Pln.Tag Is Label Then
                    If elementPaie_Pln.Tag.name = .Item("Cod_Rubrique", e.RowIndex).Value Then
                        Dim nrw() = TblPrePaie.Select($"Matricule='{ .Item(.Columns("Matricule").Index, e.RowIndex).Value}' and Cod_Rubrique='{elementPaie_Pln.Tag.name}'")
                        If nrw.Length > 0 Then
                            nrw(0)("Valeur") = CDbl(.CurrentCell.Value)
                            setRubriqueModified(nrw(0)("Cod_Rubrique"))
                        End If
                        CalculTotalRubrique()
                    End If
                End If
            End If

        End With
    End Sub
    Sub setRubriqueModified(CodRubrique As String)
        Dim _r = TblEP.Select($"Cod_Rubrique='{CodRubrique}'")
        If _r.Length > 0 Then
            _r(0)("Modified") = True
            If dicLbl.ContainsKey(CodRubrique) Then
                If Not dicLbl(CodRubrique).Text.Contains(_caractereSablier) Then
                    If Not PrePaie?.Modifie Then PrePaie.Modifie = True
                    dicLbl(CodRubrique).Text = _caractereSablier & " " & dicLbl(CodRubrique).Text
                    ReorganiserLbl()
                End If
            End If
        End If
    End Sub
    Sub CalculTotalRubrique()
        Dim tot As Double = 0
        Dim nbDec = 2
        With PrePaie_Grd
            If .Columns.Count > 0 Then
                nbDec = IsNull(?.Columns("Valeur").DefaultCellStyle?.Format.Replace("N", "").Replace("P", ""), 2)
                If IsNumeric(nbDec) Then
                    nbDec = CDbl(nbDec)
                Else
                    nbDec = 0
                End If
                For i = 0 To .RowCount - 1
                    If IsNumeric(.Item(.Columns("Valeur").Index, i).Value) Then tot += CDbl(.Item(.Columns("Valeur").Index, i).Value)
                Next
            End If
            TotalRubrique_txt.Text = FormatNumber(tot, nbDec)
        End With
    End Sub

    Private Sub Search_txt_TextChanged(sender As Object, e As EventArgs) Handles Search_txt.TextChanged
        Try
            If elementPaie_Pln.Controls.Count = 0 Then Return
            For Each c As Label In elementPaie_Pln.Controls.OfType(Of Label)()
                If (c.Name.ToUpper().Contains(Search_txt.Text.ToUpper) Or c.Text.ToUpper().Contains(Search_txt.Text.ToUpper)) And Search_txt.Text.Trim <> "" Then
                    With c
                        .Font = New Font("Century Gothic", 9.0!, FontStyle.Underline)
                        .BackColor = Color.FromArgb(35, 0, 0, 255)
                        .ForeColor = colorBase03
                    End With
                ElseIf elementPaie_Pln.Tag Is c Then
                    With c
                        .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
                        .BackColor = colorBase01
                        .ForeColor = Color.White
                    End With
                Else
                    With c
                        .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
                        .BackColor = colorBase04
                        .ForeColor = colorBase01
                    End With
                End If
                c.Refresh()
            Next
        Catch ex As Exception
            Search_txt.Text = ""
        End Try

    End Sub
    Dim clipboardText As String = ""
    Dim _msgAttente As String = ""
    Dim _progressAttente As String = ""
    Dim tblClipBoardTmp As New DataTable
    Sub CollerLeContenu()
        _progressAttente = "Merci de patenter"
        AttendreProcess(True)
        clipboardText = Clipboard.GetText().Trim
        BKG_CollerPressPapier.RunWorkerAsync()
    End Sub
    Sub SupprimerLesLignes()
        If TypeOf elementPaie_Pln.Tag IsNot Label Then Return
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer la sélection des matricules?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Stop) = MsgBoxResult.Cancel Then Return
        Dim deleted As New ArrayList
        For Each r As DataGridViewRow In PrePaie_Grd.SelectedRows
            deleted.Add(r.Cells("Matricule").Value)
        Next
        For Each d In deleted
            Dim rowsToDelete() As DataRow = TblPrePaie.Select($"Matricule='{d}'")
            ' Delete each row that meets the condition
            For Each row As DataRow In rowsToDelete
                row.Delete() ' Marks the row for deletion
            Next
        Next
        ChargerMatricules()
        For Each _r In TblEP.Rows
            setRubriqueModified(_r("Cod_Rubrique"))
        Next
        ReorganiserLbl()
    End Sub


    Dim _ismodified = False
    Private Sub BKG_CollerPressPapier_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_CollerPressPapier.DoWork
        If tblClipBoardTmp.Columns.Count = 0 Then
            With tblClipBoardTmp
                .Columns.Add("Matricule", System.Type.GetType("System.String"))
                .Columns.Add("Valeur", System.Type.GetType("System.Double"))
                .Columns.Add("Found", System.Type.GetType("System.Boolean"))
            End With
        End If
        tblClipBoardTmp.Rows.Clear()
        ' Vérifiez que le contenu du presse-papiers est du texte
        If clipboardText <> "" Then
            ' Obtenez le texte du presse-papiers
            _msgAttente = "Coller les données depuis le presse papier"
            ' Divisez le texte en lignes
            Dim lines As String() = clipboardText.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
            Dim k = 1
            Dim pattern = "(?<=\d)[\s.,](?=\d{3}(?:[\s.,]|$))"
            Dim valeur As Object = "NAN"
            ' Commencez à ajouter les lignes dans la DataGridView
            For Each line As String In lines
                _msgAttente = $"Coller les données depuis le presse papier {k} ligne{If(k <= 1, "", "s")}"
                ' Divisez chaque ligne en colonnes
                Dim columns As String() = line.Split(vbTab) ' Utilisation du tabulation comme séparateur pour les colonnes

                ' Assurez-vous qu'il y a exactement 3 colonnes pour éviter les erreurs
                If columns.Length = 2 Then
                    ' Ajoutez une nouvelle ligne dans la DataGridView
                    valeur = Regex.Replace(columns(1).Trim, pattern, "")

                ElseIf columns.Length > 2 Then
                    ' Ajoutez une nouvelle ligne dans la DataGridView
                    valeur = Regex.Replace(columns(2).Trim, pattern, "")
                End If
                If columns(0).Trim <> "" And IsNumeric(valeur) Then tblClipBoardTmp.Rows.Add(columns(0).Trim, valeur, False)
                valeur = "NAN"
                k += 1
            Next
            If tblClipBoardTmp.Rows.Count = 0 Then
                ShowMessageBox("Le presse-papiers ne contient pas de données.", "Coller le contenu", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
            k = 1
            _ismodified = False
            For Each r As DataRow In tblClipBoardTmp.Rows
                _msgAttente &= vbCrLf & $"Affecter les données : {k & " / " & tblClipBoardTmp.Rows.Count}"
                _progressAttente = k & " / " & tblClipBoardTmp.Rows.Count
                Dim _prw() = TblPrePaie.Select($"Matricule='{r("Matricule")}' and Cod_Rubrique='{elementPaie_Pln.Tag.name}'")
                If _prw.Length > 0 Then
                    _prw(0)("Valeur") = r("Valeur")
                    _ismodified = True
                    r("Found") = True
                End If
                k += 1
            Next

            Dim nb = tblClipBoardTmp.Select("Found='false'").Length
            If nb > 0 Then
                ShowMessageBox($"Au moins {nb} matricule{If(nb = 1, " n'a pas été affecté.", "s n'ont pas été affectés.")}", "Coller le contenu", MessageBoxButtons.OK, msgIcon.Error)
            End If
        Else
            ShowMessageBox("Le presse-papiers ne contient pas de données.", "Coller le contenu", MessageBoxButtons.OK, msgIcon.Error)
        End If
    End Sub

    Private Sub BKG_CollerPressPapier_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_CollerPressPapier.RunWorkerCompleted
        If _ismodified Then
            setRubriqueModified(elementPaie_Pln.Tag.name)
        End If
        tblClipBoardTmp.Rows.Clear()
        clipboardText = ""
        _progressAttente = ""
        _msgAttente = ""
        ChargerMatricules()
        AttendreProcess(False)
    End Sub
    Sub AttendreProcess(Debut As Boolean)
        PrePaie.oAvancementStrTitre = ""
        PrePaie.oAvancementStr = ""
        If Debut Then
            Cursor = Cursors.WaitCursor
            leMenu.pnl_sideBarL.Visible = False
            myTimer.Start()
            With PnlWait
                Me.Controls.Add(PnlWait)
                .lblProgress.Visible = True
                .Visible = True
                .lblAvancement.BringToFront()
                .BringToFront()
                .BringToFront()
                .CircularProgress1.SendToBack()
                .CircularProgress1.SendToBack()
            End With
        Else
            _msgAttente = ""
            _progressAttente = ""
            Cursor = Cursors.Default
            PnlWait.lblProgress.Visible = True
            myTimer.Stop()
            leMenu.pnl_sideBarL.Visible = True
            If Me.Controls.Contains(PnlWait) Then Me.Controls.Remove(PnlWait)
        End If
        CalculTotalRubrique()
    End Sub
    Private Sub myTimer_Tick(sender As Object, e As EventArgs) Handles myTimer.Tick
        With PnlWait
            .CircularProgress1.Value = IIf(.CircularProgress1.Value = 100, 0, .CircularProgress1.Value) + 10
            .lblAvancement.Text = If(_msgAttente = "", If(PrePaie.oAvancementStrTitre = "", EtapeStr, PrePaie.oAvancementStrTitre), _msgAttente)
            .lblAvancement.Refresh()
            .lblProgress.Text = If(_progressAttente = "", PrePaie.oAvancementStr, _progressAttente)
            .lblProgress.Refresh()
        End With
    End Sub
    Sub Deleting()
        If Cloture_Check.Checked Then
            MessageBoxRHP(711)
            Exit Sub
        End If
        Dim CodPlan As String = Cod_Plan_Paie_Text.Text
        Diviseur_delete("RH_Preparation_Paie", "Cod_Preparation", "Cod_Preparation", Cod_Preparation_Text, Me)
        CnExecuting("update RH_Param_Plan_Paie set DatDernierePaie=f.Dat, LastAnneePaie=year(f.Dat), LastMoisPaie=month(f.Dat)
    from (select Cod_Plan_Paie,max(Dat_Deb_Periode) as Dat from RH_Preparation_Paie where Cod_Plan_Paie='" & CodPlan & "' and id_Societe=" & Societe.id_Societe & " Group by Cod_Plan_Paie ) f
    where RH_Param_Plan_Paie.Cod_Plan_Paie=f.Cod_Plan_Paie and RH_Param_Plan_Paie.Cod_Plan_Paie='" & CodPlan & "'  and id_Societe=" & Societe.id_Societe)
        Nouveau()
    End Sub
    Sub GetDataFromOtherModules()
        Try
            If PrePaie_Grd Is Nothing OrElse PrePaie_Grd?.Rows.Count = 0 Then
                ShowMessageBox("Votre grille est vide.", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            If PrePaie_Grd.ModeFiltreActive Then
                ShowMessageBox("Votre grille comporte un filtre." & vbCrLf & "Avant de continuer, veuillez défiltrer votre selection", "Filtre", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            Dim f As New Zoom_RH_Preparation_Paie_RegenrationEV
            With f
                .DatDeb = Dat_Deb_Periode_Text.Text
                .DatFin = Dat_Fin_Periode_Text.Text
                .CodPlan = Cod_Plan_Paie_Text.Text
                .TblPrePaie = TblPrePaie
                .modeSaisiePaie = "Classique"
                .chargement()
                newShowEcran(f, True)
            End With
            Cursor = Cursors.Default
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Function getModulesExternes(CodPlan As String, DatDeb As Date, DatFin As Date, updConge As Boolean, updAvance As Boolean, updPret As Boolean, updInteret As Boolean, updRemb As Boolean, updNF As Boolean) As String
        Dim sqlStr As String = "select Matricule " &
                                  IIf(updConge = "0", "", ", convert(float,isnull(Duree_Conge,0)) as '" & EVJrConge & "'") &
                                  If(updNF = "0", "", ", convert(float,isnull(Mnt_NF,0)) as '" & EVNoteFrais & "'") &
                                  IIf(updAvance = "0", "", ", Convert(float, IsNull(Montant_Avance, 0)) as '" & EVAvance & "'") &
                                  IIf(updPret = "0", "", ", Convert(float,IsNull(Mensualite,0)) As '" & EVPret & "'") &
                                  IIf(updInteret = "0", "", ", convert(float,isnull(Interet,0)) as '" & EVInteret & "'") &
                                  IIf(updRemb = "0", "", ", convert(float,isnull(Mnt_Remboursement,0)) as '" & EVRembFraisMedic & "'") &
                                  " from RH_Agent a " &
                                  IIf(updConge = "0", "", " outer apply (select isnull(Duree_Conge,0) as Duree_Conge from dbo.Sys_GetCongePris('" & CodPlan & "','" & DatDeb & "','" & DatFin & "'," & Societe.id_Societe & ") where Matricule= a.Matricule) conge ") &
                                  If(updNF = "0", "", " outer apply (select sum(Mnt_NF) as Mnt_NF from RH_Note_Frais where Matricule= a.Matricule and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and isnull(Statut,'') in ('V','SG','VA') and isnull(Traite,0)=0 and Dat_NF<='" & DatFin & "' having sum(Mnt_NF)>0) nf  ") &
                                  IIf(updAvance = "0", "", " outer apply (select sum(isnull(Montant_Avance,0)-isnull(Reglement,0)) as Montant_Avance from RH_Paie_Avance where id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and isnull(Statut,'') in ('V','SG','VA') and isnull(Traite,0)=0 and Dat_Demande<='" & DatFin & "' having sum(isnull(Montant_Avance,0)-isnull(Reglement,0))>0) av ") &
                                  IIf(updRemb = "0", "", " outer apply (select sum(Mnt_Remboursement) as Mnt_Remboursement from RH_Dossier_Maladie where id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and isnull(Statut,'') in ('P','SG') and isnull(Traite,0)=0 and Dat_Dossier<='" & DatFin & "') rbfrmd ") &
                                  IIf(updPret = "0", "", " outer apply (select sum(isnull(Mensualite,0)) as Mensualite  from RH_Pret_Detail d
                                            where exists(select Num_Pret from RH_Pret where isnull(Typ_Pret,'')<>'I' and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Num_Pret=d.Num_Pret) and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Echeance between '" & DatDeb & "' and '" & DatFin & "') pret ") &
                                  IIf(updInteret = "0", "", "  outer apply (select sum(isnull(Interet,0)) as Interet  from RH_Pret_Detail d
                                            where exists(select Num_Pret from RH_Pret where isnull(Typ_Pret,'')='I' and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Num_Pret=d.Num_Pret) and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Echeance between '" & DatDeb & "' and '" & DatFin & "') int ") &
                                  " where id_Societe=" & Societe.id_Societe & " and isnull(Droit_Paie,0)=1 and isnull(Plan_Paie,'')='" & CodPlan & "'"
        Return sqlStr
    End Function
    Sub AddAgent()
        Dim swhere As String = ""
        With PrePaie_Grd
            '    If .RowCount <= 0 Then Return
            If Cod_Plan_Paie_Text.Text = "" Then Return
            '  If .ColumnCount <= 7 Then Return
            For i = 0 To .RowCount - 1
                swhere &= IIf(swhere = "", "", ",") & "'" & .Item("Matricule", i).Value & "'"
            Next
        End With
        Dim f As New Zoom_Preparation_Paie_Saisie_Add_Agent
        With f
            .swhere = swhere
            .PlanPaie = Cod_Plan_Paie_Text.Text
            .f_preparation = Me
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub btn_ChargerEB_Click(sender As Object, e As EventArgs) Handles btn_ChargerEB.Click
        If Cloture_Check.Checked Then Return
        If TblPrePaie.Rows.Count = 0 Then Return
        Dim stMatrictles = String.Join("','", TblPrePaie.DefaultView.ToTable(True, "Matricule").AsEnumerable().Select(Function(x) x("Matricule")).ToArray())
        Dim _tblEB = DATA_READER_GRD($"select * from RH_Agent_Element_Paie where id_Societe={Societe.id_Societe} and Matricule in ('{stMatrictles}')")
        With TblPrePaie
            For i = 0 To .Rows.Count - 1
                Dim _rw() As DataRow = _tblEB.Select($"Matricule='{ .Rows(i)("Matricule")}' and Cod_Rubrique='{ .Rows(i)("Cod_Rubrique")}'")
                If _rw.Length > 0 Then
                    .Rows(i)("Valeur") = _rw(0)("Valeur")
                Else
                    .Rows(i)("Valeur") = 0
                End If
            Next
        End With
        ChargerMatricules()
    End Sub
    Sub NetToBrut()
        If BKG_NetToBrut.IsBusy Then Return
        If TblPrePaie?.Columns.Count = 0 Then
            Return
        End If
        If EVPrimeABrutifier = "" OrElse EVPrimeBrutifiee = "" Then
            ShowMessageBox("Pour exécuter ce traitement, vous dever déclarer d'abord les éléments variables relatifs" & vbCrLf & "aux primes brutifiées et à brutifier, au niveau du paramétrage du plan de paie", "Paramétrage du plan de paie", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Not EV_chk.Checked Then EV_chk.Checked = True
        If Not dicLbl.ContainsKey(EVPrimeABrutifier) Or elementPaie_Pln.Tag Is Nothing Then
            ShowMessageBox($"Veuillez sélectionner la prime à brutifier." & vbCrLf & EVPrimeABrutifier, "Préparation de la paie", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        ElseIf elementPaie_Pln.Tag.name <> EVPrimeABrutifier Then
            _msgAttente = "Sélectionner la prime nette à brutifier"
            elementPaieClicked(dicLbl(EVPrimeABrutifier))
        End If
        If Not dicLbl.ContainsKey(EVPrimeBrutifiee) Then
            ShowMessageBox($"Veuillez vous assurer que vos éléments variables comprennent la prime brutifiée." & vbCrLf & EVPrimeBrutifiee, "Préparation de la paie", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        _msgAttente = "Vérifications générales"
        AttendreProcess(True)
        BKG_NetToBrut.RunWorkerAsync()

    End Sub
    Private Sub BKG_NetToBrut_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_NetToBrut.DoWork
        If TblPrePaie?.Columns.Count = 0 Then
            Return
        End If
        _msgAttente = "Vérifications générales"
        If EVPrimeABrutifier = "" OrElse EVPrimeBrutifiee = "" Then
            ShowMessageBox("Pour exécuter ce traitement, vous dever déclarer d'abord les éléments variables relatifs" & vbCrLf & "aux primes brutifiées et à brutifier, au niveau du paramétrage du plan de paie", "Paramétrage du plan de paie", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Not EV_chk.Checked Then EV_chk.Checked = True
        If Not dicLbl.ContainsKey(EVPrimeABrutifier) Or elementPaie_Pln.Tag Is Nothing Then
            ShowMessageBox($"Veuillez sélectionner la prime à brutifier." & vbCrLf & EVPrimeABrutifier, "Préparation de la paie", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        ElseIf elementPaie_Pln.Tag.name <> EVPrimeABrutifier Then
            _msgAttente = "Sélectionner la prime nette à brutifier"
            elementPaieClicked(dicLbl(EVPrimeABrutifier))
        End If
        If Not dicLbl.ContainsKey(EVPrimeBrutifiee) Then
            ShowMessageBox($"Veuillez vous assurer que vos éléments variables comprennent la prime brutifiée." & vbCrLf & EVPrimeBrutifiee, "Préparation de la paie", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If PrePaie?.TblPrePaie?.Columns.Count() = 0 Then
            _msgAttente = "Initialisation et chargement des éléments de la paie"
            PrePaie.Request(Cod_Preparation_Text.Text, Cod_Plan_Paie_Text.Text, Dat_Deb_Periode_Text.Text, Dat_Fin_Periode_Text.Text, False)
        End If
        If Zoom_Generation_NetToBrut.BKG_NetToBrut.IsBusy Then
            ShowMessageBox("Un traitement est toujours en cours", "Merci de réessayer", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        Dim _rw() As DataRow = TblPrePaie.Select($"Cod_Rubrique='{EVPrimeABrutifier}'")
        For Each r In _rw
            Dim _r() = PrePaie.TblPrePaie.Select($"Matricule='{r("Matricule")}'")
            If _r.Length > 0 Then _r(0)(EVPrimeABrutifier) = r("Valeur")
        Next
        _msgAttente = "Début de la génération de la brutification des primes nettes"
        _msgAttente = ""
        If PrePaie.CalculNetToBrut() Then
            _rw = TblPrePaie.Select($"Cod_Rubrique='{EVPrimeABrutifier}'")
            For Each r In _rw
                r("Valeur") = 0
            Next
            _rw = TblPrePaie.Select($"Cod_Rubrique='{EVPrimeBrutifiee}'")
            For Each r In _rw
                _msgAttente = "Traitement du matricule : " & r("Matricule")
                Dim _r() = PrePaie.TblPrePaie.Select($"Matricule='{r("Matricule")}'")
                If _r.Length > 0 Then r("Valeur") = _r(0)(EVPrimeBrutifiee)
            Next
            _msgAttente = "Fin de traitement "
        End If

    End Sub

    Private Sub BKG_NetToBrut_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_NetToBrut.RunWorkerCompleted
        setRubriqueModified(EVPrimeABrutifier)
        elementPaieClicked(dicLbl(EVPrimeBrutifiee))
        setRubriqueModified(EVPrimeBrutifiee)
        AttendreProcess(False)
    End Sub

    Private Sub RH_Preparation_Paie_Saisie_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        With PrePaie_Grd
            If .RowCount > 0 And Save_D.Enabled Then
                If PrePaie?.Modifie Then
                    If ShowMessageBox("Voulez-vous abondonner les modifications?", "Fermer", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then
                        e.Cancel = True
                        Return
                    End If
                End If
            End If
        End With
        PrePaie_Grd.DataSource = Nothing
        CnExecuting("Delete from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=" & Societe.id_Societe & " and Process_Id=" & ProcessId)
    End Sub

    Private Sub ModierPlan_btn_Click(sender As Object, e As EventArgs) Handles ModierPlan_btn.Click
        Dim f As New RH_Parametrage_Plan_Paie
        Dim _strEP As String = ""
        With f
            .Cod_Plan_Paie_Text.Text = Cod_Plan_Paie_Text.Text
            AddHandler .FormClosing, Sub()
                                         _strEP = String.Join(",", .strEP)
                                     End Sub
            .Request()
            newShowEcran(f, True)
            If PrePaie_Grd.Columns.Count > 0 Then
                If (String.Join(",", PrePaie.strEP) = _strEP) Then
                    Refreshing()
                End If
            End If
        End With
    End Sub

#Region "Recalcul"
    Sub Recalcul()
        If Cod_Plan_Paie_Text.Text = "" Then Return
        If Not EstDate(Dat_Deb_Periode_Text.Text) Then Return
        If Not EstDate(Dat_Fin_Periode_Text.Text) Then Return
        If BKG_Calcul.IsBusy Then
            ShowMessageBox("Un calcul est en cours", "Recalcul global", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        avecControle = ShowMessageBox("Voulez-vous contrôler la paie à l'enregistrement?", "Contrôle des erreurs", MessageBoxButtons.YesNo, msgIcon.Question) = MsgBoxResult.Yes
        PrePaie.InitialisationPaie(Cod_Preparation_Text.Text, Cod_Plan_Paie_Text.Text, Dat_Deb_Periode_Text.Text, Dat_Fin_Periode_Text.Text, avecControle)
        PrePaie.Tbl_Controles.Rows.Clear()
        AttendreProcess(True)
        BKG_Calcul.RunWorkerAsync()
    End Sub
    Private Sub BKG_Calcul_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_Calcul.DoWork
        PrePaie.CalculTotal(True)
    End Sub
    Private Sub BKG_Calcul_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_Calcul.RunWorkerCompleted

        AttendreProcess(False)
    End Sub
#End Region
    Private Sub PrePaie_Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles PrePaie_Grd.DataError

    End Sub


End Class