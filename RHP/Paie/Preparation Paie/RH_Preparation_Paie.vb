Imports System.ComponentModel
Public Class RH_Preparation_Paie
    Dim oMnu, oMnu2, oMnu3, anaMnu, oMnu5, oMnu6, oMnu7, oMnu8, oMnu8_0, oMnu8_1 As New ToolStripMenuItem
    Dim WithEvents oCntx As New ContextMenuStrip
    Friend Code As String = "XYZ"
    Dim flter_pb As New PictureBox
    Dim PnlWait As New ud_PanelWait
    Friend WithEvents OTimer As New Timer
    Friend WithEvents BKG_Calcul, BKG_Save, BKG_Request, BKG_Del As New BackgroundWorker
    Dim oGrdFilter As New GrdFilter
    Friend PrePaie As New PayRollEngine
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim New_D As ud_btn
    Dim Import_D As ud_btn
    Dim Conge_D As ud_btn
    Dim Simuler_D As ud_btn
    Dim Cloture_D As ud_btn
    Dim add_agent_D As ud_btn
    Dim Calcul_D As ud_btn
    Dim NetToBrut_D As ud_btn
    Private Sub RH_Preparation_Paie_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        With PrePaie_Grd
            If .RowCount > 0 And Save_D.Enabled Then
                If PrePaie.Modifie Then
                    If ShowMessageBox("Voulez-vous abondonner les modifications?", "Fermer", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then
                        e.Cancel = True
                        Return
                    End If
                End If
            End If
        End With
        PrePaie_Grd.DataSource = Nothing
        CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and id_Societe=" & Societe.id_Societe & " and Process_Id=" & ProcessId)
    End Sub

    Sub ModeFiche()
        If PrePaie_Grd.RowCount = 0 Then Return
        Dim r As Integer = 0
        If PrePaie_Grd.SelectedCells.Count > 0 Then
            r = PrePaie_Grd.SelectedCells(0).RowIndex
        End If
        Dim f As New Zoom_RH_Preparation_Paie
        With f
            .frmPrePaie = Me
            .Cloture_Check.Checked = Cloture_Check.Checked
            .ShowCP_rb.Checked = ShowCP_chk.Checked
            .ShowEV_rb.Checked = ShowEV_chk.Checked
            .ShowGains_rb.Checked = ShowGains_chk.Checked
            .ShowRetenues_rb.Checked = ShowRetenues_chk.Checked
            .TblFunction = PrePaie.TblFunction
            .CodPlan = Cod_Plan_Paie_Text.Text
            .CodPreparation = Cod_Preparation_Text.Text
            .Grd = PrePaie_Grd
            .inDx = r
            .Bulletin_chk.Checked = (PrePaie.elementDetailBulletinPaie.Length > 0)
            If Not .Bulletin_chk.Checked Then .Classic_chk.Checked = True
            .PreparationInitiale()
            .Request()
            newShowEcran(f, True)
        End With
    End Sub
    Sub AfficherRubrique()
        If PrePaie_Grd.SelectedCells.Count = 0 Then Return
        Dim c As Integer = PrePaie_Grd.SelectedCells(0).ColumnIndex
        Select Case PrePaie_Grd.Columns(c).Tag
            Case "EV", "EC", "EB", "CS", "EX"
                Dim f As New RH_Parametrage_Rubrique_Paie
                With f
                    .Cod_Rubrique_txt.Text = PrePaie_Grd.Columns(c).Name
                    .Request()
                    newShowEcran(f, True)
                End With
            Case "FU", "FP", "FS"
                Dim f As New RH_Functions
                With f
                    .Cod_Function_Text.Text = PrePaie_Grd.Columns(c).Name
                    .Request()
                    newShowEcran(f, True)
                End With
        End Select
        PrePaie.InitialisationPaie(Cod_Preparation_Text.Text, Cod_Plan_Paie_Text.Text, Dat_Deb_Periode_Text.Text, Dat_Fin_Periode_Text.Text, withLog_chk.Checked)
    End Sub
    Enum inserRubrique
        Avant = 0
        Apres = 1
    End Enum
    Sub insererRubrique(AvantApres As inserRubrique)
        If Not Save_D.Enabled Then Return
        With PrePaie_Grd
            If .DataSource Is Nothing Then Return
            If .Rows.Count = 0 Then Return
            If .Columns.Count = 0 Then Return
            If .CurrentCell Is Nothing Then Return
            Dim c As Integer = .SelectedCells(0).ColumnIndex
            If Not "EV;EC;EB;CS;EX;FU;FP;FS".Split(";").Contains(IsNull(.Columns(c).Tag, "")) Then Return
            Dim cuurentRub As String = .Columns(c).Name
            Dim newRub As String = ""
            Dim lst = PrePaie.strEP.ToList()
            If lst.Count = 0 Then Return
            Dim f As New Zoom_Libre
            With f
                GRD("select Cod_Function as Rubrique, Lib_Function as Désignation, Typ_Function as Type
from RH_Elements_Paie where id_Societe in (-1," & Societe.id_Societe & ") and Cod_Function not in ('" & String.Join("','", lst) & "')
and Typ_Function in ('EV','EC','EB','CS','EX','FU','FP')
order by Cod_Function ", .Libre_GRD)
                AddHandler .Libre_GRD.CellDoubleClick, Sub(sender As DataGridView, e As DataGridViewCellEventArgs)
                                                           If .Libre_GRD.SelectedCells Is Nothing Then Return
                                                           If .Libre_GRD.SelectedCells.Count = 0 Then Return
                                                           If e.RowIndex < 0 Then Return
                                                           If e.ColumnIndex < 0 Then Return
                                                           newRub = .Libre_GRD("Rubrique", e.RowIndex).Value
                                                           .Close()
                                                       End Sub
                newShowEcran(f, True)
            End With
            If newRub = "" Then Return
            If lst.Contains(newRub) Then lst.Remove(newRub)
            Dim ind = Array.IndexOf(PrePaie.strEP, cuurentRub)
            If ind >= 0 Then
                If AvantApres = inserRubrique.Apres Then
                    ind += 1
                Else
                    ind -= 1
                End If
            End If
            ind = Math.Max(0, ind)
            lst.Insert(ind, newRub)
            CnExecuting("update RH_Param_Plan_Paie set Element_Paie = '" & String.Join(";", lst) & "' where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)
            If Cod_Preparation_Text.Text <> "" Then CnExecuting("update RH_Preparation_Paie set ElementPaie  = '" & String.Join(";", lst) & "' where Cod_Preparation='" & Cod_Preparation_Text.Text & "' and id_Societe=" & Societe.id_Societe)
            CnExecuting("exec Sys_RH_Rubriques_Plan_Bulletin " & Societe.id_Societe & ", '" & Cod_Plan_Paie_Text.Text & "'")
            Request()
        End With

    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Conge_D = dictButtons("Conge_D")
        Simuler_D = dictButtons("Simuler_D")
        Cloture_D = dictButtons("Cloture_D")
        add_agent_D = dictButtons("add_agent_D")
        New_D = dictButtons("New_D")
        Import_D = dictButtons("Import_D")
        Calcul_D = dictButtons("Calcul_D")
        NetToBrut_D = dictButtons("NetToBrut_D")
        With oMnu
            .Name = "oMnu"
            .Text = "Sélection avancée"
            .Image = My.Resources.Filtrer
            AddHandler .Click, AddressOf SelectionAvancee
        End With
        With oMnu2
            .Text = "Editer la rubrique de paie"
            .Image = My.Resources.Dollar
            AddHandler .Click, AddressOf AfficherRubrique
        End With
        With oMnu3
            .Text = "Mode Fiche"
            .Image = My.Resources.zoom
            AddHandler .Click, AddressOf ModeFiche
        End With
        With anaMnu
            .Text = "Ventilation analytique"
            .Image = My.Resources.CHR
            AddHandler .Click, AddressOf AffectationAna
        End With
        With oMnu5
            .Text = "Recalcul de la ligne"
            .Image = My.Resources.Calculator213122
            AddHandler .Click, AddressOf RecalculDeLaLigne
        End With
        With oMnu6
            .Text = "Supprimer les lignes"
            .Image = My.Resources.supprimerligne
            AddHandler .Click, AddressOf SupprimerLigne
        End With
        With oMnu7
            .Text = "Compilateur"
            .Image = My.Resources.devis
            AddHandler .Click, AddressOf Compilateur
        End With
        With oMnu8
            .Text = "Insérer une rubrique de paie"
            .Image = My.Resources.login
        End With
        With oMnu8_0
            .Text = "Avant"
            AddHandler .Click, Sub()
                                   insererRubrique(inserRubrique.Avant)
                               End Sub
        End With
        With oMnu8_1
            .Text = "Après"
            AddHandler .Click, Sub()
                                   insererRubrique(inserRubrique.Avant)
                               End Sub
        End With
        oMnu8.DropDownItems.AddRange({oMnu8_0, oMnu8_1})
        Check_Accessible(Me.Name, Code)
        If CnExecuting("Select count(*) from Controle_Access where Process_Id<>" & ProcessId & " and Name_Ecran='" & Me.Name & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            MessageBoxRHP(687)
            With Save_D
                .Enabled = False
                .Tag = ""
            End With
        End If

        oCntx = AddContextMenu(False, True, False, False, False, False, False, False)
        With oCntx
            .Items.Insert(0, oMnu5)
            .Items.Insert(1, oMnu3)
            .Items.Insert(2, oMnu7)
            .Items.Insert(3, oMnu8)
            .Items.Insert(3, oMnu2)
            .Items.Insert(4, anaMnu)
            .Items.Insert(5, oMnu)
            .Items.Add(oMnu6)
        End With
        PrePaie_Grd.ContextMenuStrip = oCntx
        With flter_pb
            .Image = My.Resources.btn_filter_w
            .BackColor = Color.Transparent
            .Cursor = Cursors.Hand
            .SizeMode = PictureBoxSizeMode.StretchImage
            .Size = New Size(20, 20)
            .Location = New Point(5, 5)
            PrePaie_Grd.Controls.Add(flter_pb)
            AddHandler .Click, AddressOf AfficherListeColonnes
        End With
        With oGrdFilter
            .Location = New Point(5, 5)
            .PrePaie_Grd = PrePaie_Grd
            .Parent = PrePaie_Grd
            .CodPlan = Cod_Plan_Paie_Text.Text
            .Visible = False
            .BringToFront()
            .BringToFront()
        End With
        Grd_Controles.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        OTimer.Interval = 100
    End Sub
    Dim lst_matricules_supprimes As New ArrayList
    Sub Compilateur()
        With PrePaie_Grd
            If .Rows.Count <= 0 Then Return
            If .Columns.Count <= 0 Then Return
            If .CurrentCell Is Nothing Then Return
            If Not "EV;EC;CS;FU;FP;FS;EB;EX;RC".Contains(IsNull(.Columns(.CurrentCell.ColumnIndex).Tag, "")) Then Return
            Dim f As New Zoom_Compilateur
            With f
                .frmPreparation = Me
                .ShowDialog()
            End With
        End With
    End Sub
    Sub SupprimerLigne()
        With PrePaie_Grd
            If .SelectedRows.Count <= 0 Then Return
            If .SelectedRows(0).Index < 0 Then Return
            If .ColumnCount <= 0 Then Return
            If BKG_Del.IsBusy Then Return
            If ShowMessageBox("Etes vous sûr de vouloir supprimer ces lignes?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
            If .SelectedRows.Count > 20 Then AttendreProcess(True)
            .SuspendLayout()
            BKG_Del.RunWorkerAsync()
        End With
    End Sub
    Private Sub BKG_Del_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_Del.DoWork
        With PrePaie_Grd
            Dim deleted As New ArrayList
            For Each r As DataGridViewRow In PrePaie_Grd.SelectedRows
                deleted.Add(r.Cells("Matricule").Value)
            Next
            For Each d In deleted
                Dim rowsToDelete() As DataRow = PrePaie.TblPrePaie.Select($"Matricule='{d}'")
                ' Delete each row that meets the condition
                For Each row As DataRow In rowsToDelete
                    row.Delete() ' Marks the row for deletion
                Next
            Next
            PrePaie.TblPrePaie.AcceptChanges()
            PrePaie.Modifie = True
        End With
    End Sub
    'Private Sub BKG_Del_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_Del.DoWork
    '    ' Suspend la liaison des données pour éviter les mises à jour intempestives
    '    Dim currencyManager As CurrencyManager = CType(PrePaie_Grd.BindingContext(PrePaie_Grd.DataSource), CurrencyManager)
    '    currencyManager.SuspendBinding()

    '    With PrePaie_Grd
    '        Dim lst As New List(Of DataRow)
    '        Dim nb As Integer = .SelectedRows.Count
    '        Dim i As Integer = 1

    '        ' Collecte les DataRows à supprimer
    '        For Each r As DataGridViewRow In .SelectedRows
    '            PrePaie.oAvancementStrTitre = "Préparation de la suppression de : " & i & "/ " & nb
    '            ' S'assurer que DataBoundItem est valide et correspond à une DataRow
    '            If r.DataBoundItem IsNot Nothing Then
    '                lst.Add(CType(r.DataBoundItem, DataRowView).Row)
    '            End If
    '            i += 1
    '        Next

    '        ' Suppression des DataRows dans l'ordre inverse
    '        i = 1
    '        For j As Integer = lst.Count - 1 To 0 Step -1
    '            Dim r As DataRow = lst(j)
    '            PrePaie.oAvancementStrTitre = "Suppression du matricule : " & r("Matricule") & ", " & i & "/ " & lst.Count
    '            lst_matricules_supprimes.Add(r("Matricule"))
    '            r.Delete() ' Marque la ligne pour suppression dans la source de données
    '            i += 1
    '        Next

    '        ' Applique les changements à la DataTable
    '        CType(.DataSource, DataTable).AcceptChanges()
    '        PrePaie.Modifie = True
    '    End With

    '    ' Reprend la liaison des données
    '    currencyManager.ResumeBinding()
    'End Sub
    Private Sub BKG_Del_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_Del.RunWorkerCompleted
        AttendreProcess(False)
        PrePaie_Grd.ResumeLayout(True)
        PrePaie_Grd.Invalidate()

    End Sub
    Sub RecalculDeLaLigne()
        If Cod_Preparation_Text.Text = "" Then Return
        If PrePaie_Grd.ColumnCount = 0 Then Return
        If PrePaie_Grd.SelectedCells.Count = 0 Then Return
        Dim r As Integer = PrePaie_Grd.SelectedCells(0).OwningRow.Index
        If r < 0 Then Return
        PrePaie.CalculPaie(PrePaie_Grd.Item("Matricule", r).Value, False)
    End Sub
    Sub AffectationAna()
        '   Try
        If PrePaie.strEP.Length = 0 Then Return
        If Cod_Preparation_Text.Text = "" Then Return
        If PrePaie_Grd.ColumnCount = 0 Then Return
        If PrePaie_Grd.SelectedCells.Count = 0 Then Return
        Dim r As Integer = PrePaie_Grd.SelectedCells(0).OwningRow.Index
        If r < 0 Then Return
        Dim nb As Integer = CnExecuting("Select count(*) from dbo.RH_Paie_Rubrique 
where isnull(Ventilable,'false')='true' and id_Societe=" & Societe.id_Societe & " and Cod_Rubrique in ('" & Join(PrePaie.strEP, "','") & "')").Fields(0).Value
        If nb = 0 Then
            ShowMessageBox("Aucune rubrique déclarée ventilable analytiquement", "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim f As New Zoom_Ana
        With f
            .oIndx = r
            .Cod_Preparation_txt.Text = Cod_Preparation_Text.Text
            .CodPlan = Cod_Plan_Paie_Text.Text
            .Matricule_txt.Text = PrePaie_Grd.Item("Matricule", r).Value
            .Nom_txt.Text = PrePaie_Grd.Item("Nom", r).Value
            .pGrd = PrePaie_Grd
            newShowEcran(f)
        End With
        '   Catch ex As Exception
        '   ShowMessageBox(ex.Message, "Contrôle", MessageBoxButtons.OK, msgIcon.Stop)
        '  Return
        '  End Try

    End Sub
    Sub SelectionAvancee(sender As Object, e As EventArgs)
        If Cod_Plan_Paie_Text.Text.Trim = "" Then Return
        'Dim grd As New ud_Grd
        'grd = sender.getcurrentparent.sourcecontrol
        'grd.DataSource = grd.dataSourceOrigine
        'Dim nb As Integer = 0
        'For i = 0 To grd.Tag(1).count - 1
        '    If IsNull(grd.Tag(2)(i), "") <> "" Then
        '        grd.Tag(0)(i) = My.Resources.recherche
        '        grd.Tag(2)(i) = ""
        '        nb += 1
        '    End If
        'Next
        'If nb > 0 Then
        '    grd.Filtering()
        '    grd.Focus()
        '    If grd.RowCount > 0 Then
        '        grd.Item(0, 0).Selected = True
        '    End If
        'End If
        Dim f As New RH_Preparation_Paie_SelectionFiltree
        With f
            .CodPlan = Cod_Plan_Paie_Text.Text
            .Grd = PrePaie_Grd 'grd
            .ModeleSaisie_cbo.Text = sender.name
            .oMnu = sender
            newShowEcran(f, True)
        End With
    End Sub
    Sub AfficherListeColonnes()
        If Cod_Plan_Paie_Text.Text = "" Then Return
        If PrePaie_Grd.Rows.Count = 0 Then Return
        oGrdFilter.CodPlan = Cod_Plan_Paie_Text.Text
        oGrdFilter.Visible = True
        oGrdFilter.FilterList.Select()

    End Sub
    Private Sub Cod_Preparation__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Cod_Preparation_.LinkClicked
        Appel_Zoom1("MS013", Cod_Preparation_Text, Me)
    End Sub
    Private Sub Plan_Paie__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Plan_Paie_.LinkClicked
        If Cod_Preparation_Text.Text <> "" Then
            MessageBoxRHP(710)
            Exit Sub
        End If
        PrePaie_Grd.DataSource = Nothing
        Appel_Zoom1("MS069", Cod_Plan_Paie_Text, Me)
    End Sub

    Private Sub Plan_Paie_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        PrePaie.CodPlan = Cod_Plan_Paie_Text.Text
        Dim TblPlan As DataTable = DATA_READER_GRD("select * from RH_Param_Plan_Paie where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        With TblPlan
            If .Rows.Count > 0 Then
                Lib_Plan_Paie_Text.Text = IsNull(.Rows(0)("Lib_Plan_Paie"), "")
                If Cod_Preparation_Text.Text = "" Then
                    Dim JourDeb As Integer = 1
                    Dim DateDeb As Date = CDate("01/" & Now.Month & "/" & Now.Year)
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
                Lib_Plan_Paie_Text.Text = ""
            End If
        End With
        ChargementFiltre()
    End Sub
    Private Sub Dat_Deb_Periode__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Dat_Deb_Periode_.LinkClicked
        If Cod_Preparation_Text.Text <> "" Then Return
        Appel_Calender_Blocage(Dat_Deb_Periode_Text, Me, "Compta")
    End Sub
    Private Sub Cod_Preparation_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Preparation_Text.TextChanged
        CnExecuting("delete from Controle_Access where id_Societe='" & Societe.id_Societe & "' and  Name_Ecran='" & Me.Name & "' and value='" & Code & "'")
        Save_D.Enabled = True
        Conge_D.Enabled = True
        Import_D.Enabled = True
        Simuler_D.Enabled = True
        add_agent_D.Enabled = True
        Calcul_D.Enabled = True
        NetToBrut_D.Enabled = True
        Cloture_D.Image = My.Resources.btn_unlock
        Cloture_D.Enabled = True
        Del_D.Enabled = True
        DroitAcces(Me, DroitModify_Fiche(Cod_Preparation_Text.Text, Me))
        Dim TblPrepa As DataTable = DATA_READER_GRD("Select isnull(Lib_Preparation,'') as Lib_Preparation,isnull(Cod_Plan_Paie,'') as Cod_Plan_Paie,
                                                    Dat_Deb_Periode, Dat_Fin_Periode, isnull(Cloture,'false') as Cloture ,isnull(ElementPaie,'') as ElementPaie  ,isnull(ElementDetail,'') as ElementDetail  
                                                    from RH_Preparation_Paie where Cod_Preparation='" & Cod_Preparation_Text.Text & "'")
        If TblPrepa.Rows.Count > 0 Then
            Lib_Preparation_Text.Text = TblPrepa.Rows(0).Item("Lib_Preparation")
            Cod_Plan_Paie_Text.Text = TblPrepa.Rows(0).Item("Cod_Plan_Paie")
            Dat_Deb_Periode_Text.Text = TblPrepa.Rows(0).Item("Dat_Deb_Periode")
            Dat_Fin_Periode_Text.Text = TblPrepa.Rows(0).Item("Dat_Fin_Periode")
            Cloture_Check.Checked = TblPrepa.Rows(0).Item("Cloture")
            PrePaie.PaieCloture = Cloture_Check.Checked
            PrePaie.strEP = TblPrepa.Rows(0).Item("ElementPaie").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            Request()
        Else

            Lib_Preparation_Text.Text = ""
            Cod_Plan_Paie_Text.Text = ""
            Dat_Deb_Periode_Text.Text = ""
            Dat_Fin_Periode_Text.Text = ""
            Cloture_Check.Checked = False
            Reset_Form(Me)
            Initialisation()
        End If
        If Cloture_Check.Checked Then
            Cloture_D.Image = My.Resources.btn_lock
            Cloture_D.Enabled = False
            Save_D.Enabled = False
            Del_D.Enabled = False
            add_agent_D.Enabled = False
            Calcul_D.Enabled = False
            NetToBrut_D.Enabled = False
        Else
            Cloture_D.Image = My.Resources.btn_unlock
        End If
        Conge_D.Enabled = Save_D.Enabled
        Import_D.Enabled = Save_D.Enabled
        Simuler_D.Enabled = Save_D.Enabled
        add_agent_D.Enabled = Save_D.Enabled
        Calcul_D.Enabled = Save_D.Enabled
        NetToBrut_D.Enabled = Save_D.Enabled
        If Save_D.Enabled = True And Cod_Preparation_Text.Text.Trim <> "" And Code <> Cod_Preparation_Text.Text Then
            Code = Cod_Preparation_Text.Text
            Check_Accessible(Me.Name, Code)
        End If
    End Sub
    Private Sub Dat_Deb_Periode_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dat_Deb_Periode_Text.TextChanged
        If Not EstDate(Dat_Deb_Periode_Text.Text) Then Exit Sub
        Dat_Fin_Periode_Text.Text = FormatDateTime((CDate(Dat_Deb_Periode_Text.Text).AddMonths(1).AddDays(-1)).Date, DateFormat.ShortDate)
        If EstDate(Dat_Deb_Periode_Text.Text) Then
            PrePaie.DatDeb = Dat_Deb_Periode_Text.Text
            PrePaie.myVBS.ExecuteStatement("AffectVar Dat_Deb_Periode, """ & Dat_Deb_Periode_Text.Text & """")
        End If
    End Sub
    Sub Refreshing()
        If Cod_Preparation_Text.Text <> "" Then
            If ShowMessageBox("Vous êtes entrain de réinitialiser votre préparation. Tous les éléments autres que variables seront supprimés." & vbCrLf & "Voulez-vous continuer?", "RéInitialisation", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
            PrePaie.reinitialiserPreparation = True
        End If
        Cursor = Cursors.WaitCursor
        Dim nBMat As New ADODB.Recordset
        If Cod_Plan_Paie_Text.Text = "" Then
            MessageBoxRHP(706)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Exit Sub
        ElseIf CnExecuting($"select isnull(Valide,'false') Valide from RH_Param_Plan_Paie where id_Societe={Societe.id_Societe} and Cod_Plan_Paie='{Cod_Plan_Paie_Text.Text }'").Fields(0).Value = False Then
            ShowMessageBox("Veuillez d'abord valider le plan de paie avant de continuer votre préparation.", "Contrôle", MessageBoxButtons.OK, msgIcon.Error)
            Cursor = Cursors.Default
            Return
        End If
        If Not EstDate(Dat_Deb_Periode_Text.Text) Or Not EstDate(Dat_Fin_Periode_Text.Text) Then
            MessageBoxRHP(707)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Exit Sub
        End If
        If CDate(Dat_Deb_Periode_Text.Text) >= CDate(Dat_Fin_Periode_Text.Text) Then
            ShowMessageBox("Incohérence date début et date fin", "Erreur date", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Exit Sub
        End If
        If CnExecuting("Select count(*) from Param_Periode_Paie where isnull(Cloture,'false')='false' and Annee='" & ConvertDate(Dat_Fin_Periode_Text.Text).Year & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
            ShowMessageBox("Année de paie non ouverte", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Dim f As New Zoom_PPeriodeAjouter
            f.ShowDialog()
            Cursor = Cursors.Default
            Return
        End If
        Dim TblConge As DataTable = DATA_READER_GRD("select * 
from RH_Conge_Suivi s
where isnull(Statut,'')='' and id_Societe=" & Societe.id_Societe & "
and Dat_Fin_Conge<='" & Dat_Fin_Periode_Text.Text & "' 
and exists(select Matricule from RH_Agent where id_Societe=s.id_Societe 
and Matricule=s.Matricule and Plan_Paie='" & Cod_Plan_Paie_Text.Text & "') ")
        If TblConge.Rows.Count > 0 Then
            ShowMessageBox("Il existe des demandes de congé non encore traitées.", "Congés non traités", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Return
        End If
        If CnExecuting("Select count(*) as   nb
FROM         RH_Paie_Avance
WHERE     (id_Societe = " & Societe.id_Societe & ") AND (Dat_Demande <= '" & Dat_Fin_Periode_Text.Text & "') AND (ISNULL(Statut, N'') = '')").Fields(0).Value > 0 Then
            ShowMessageBox("Il existe des demandes d'avance non encore traitées.", "Avances non traitées", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Return
        End If
        If CnExecuting("Select count(*) as   nb
FROM         RH_Pret
WHERE     (id_Societe = " & Societe.id_Societe & ") AND (Dat_Demande <= '" & Dat_Fin_Periode_Text.Text & "') AND (ISNULL(Statut, N'') = '')").Fields(0).Value > 0 Then
            ShowMessageBox("Il existe des prêts non encore traitées.", "Prêts non traités", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Return
        End If
        If Cod_Preparation_Text.Text = "" Then
            If CnExecuting("Select count(*) from  RH_Preparation_Paie where  Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and isnull(Cloture,'false')='false' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
                ShowMessageBox("Il existe en moins une préparation non clôturée pour ce plan", "Nouvelle paie", MessageBoxButtons.OK, msgIcon.Stop)
                Cursor = Cursors.Default
                Return
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
                Exit Sub
            End If
            nBMat.Close()
        End If
        PrePaie.strEP = IsNull(CnExecuting("declare @EE nvarchar(max)
select @EE = ';'+isnull(Element_Paie,'')+';' from RH_Param_Plan_Paie where id_Societe =" & Societe.id_Societe & " and Cod_Plan_Paie ='" & Cod_Plan_Paie_Text.Text & "'
select isnull((select top 1 Cod_Rubrique  
from RH_Preparation_Paie_Detail where id_Societe =" & Societe.id_Societe & "
group by Cod_Rubrique
order by case when patindex('%;'+Cod_Rubrique+';%',@EE)=0 then 999999 else patindex('%;'+Cod_Rubrique+';%',@EE) end),'')").Fields(0).Value, ";").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        New_D.Enabled = False
        Request()
    End Sub
    Sub Initialisation()
        PrePaie = New PayRollEngine
        PrePaie.myVBS.withLog = withLog_chk.Checked
        PrePaie_Grd.DataSource = Nothing
        oGrdFilter.FilterList.Controls.Clear()
        Dim ch1 As Boolean = Controler_chk.Checked
        Dim ch2 As Boolean = HighLightEV_Chk.Checked
        Dim ch3 As Boolean = HighLightResume_Chk.Checked
        Dim pln As String = IsNull(Cod_Plan_Paie_Text.Text, FindLibelle("Cod_Plan_Paie", "id_Societe", Societe.id_Societe, "Rh_Param_Plan_Paie"))
        Reset_Form(EntPnl)
        Controler_chk.Checked = ch1
        HighLightEV_Chk.Checked = ch2
        HighLightResume_Chk.Checked = ch3
        Code = "XYZ"
        OTimer.Stop()
        PrePaie.oAvancementStr = ""
        PrePaie.oAvancementStrTitre = ""
        TabControl1.SelectedIndex = 0
        PrePaie.PaieCloture = False
        Cod_Plan_Paie_Text.Text = pln
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
    End Sub
    Sub GetDataFromOtherModules()
        Try
            If PrePaie_Grd.ModeFiltreActive Then
                ShowMessageBox("Votre grille comporte un filtre." & vbCrLf & "Avant de continuer, veuillez défiltrer votre selection", "Filtre", MessageBoxButtons.OK, msgIcon.Stop)
                TabControl1.SelectedIndex = 1
                Return
            End If
            Dim strChk As String = ""
            Dim f As New Zoom_RH_Preparation_Paie_RegenrationEV
            With f
                newShowEcran(f, True)
                AddHandler .FormClosing, Sub()
                                             strChk = .getModules()
                                         End Sub
            End With
            Dim str() As String = strChk.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            If str.Length < 5 Then Return
            If Not str.Contains("1") Then Return
            Cursor = Cursors.WaitCursor
            PrePaie.MiseAJourModulesAnnexes(Cod_Plan_Paie_Text.Text, Dat_Deb_Periode_Text.Text, Dat_Fin_Periode_Text.Text, str(0), str(2), str(1), str(3), str(4), str(5))
            Cursor = Cursors.Default
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Private Sub PrePaie_Grd_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles PrePaie_Grd.EditingControlShowing
        With PrePaie_Grd
            If .Columns(.CurrentCell.ColumnIndex).Tag = "EV" Then
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With PrePaie_Grd
            Dim NomCol As String = .Columns(.CurrentCell.ColumnIndex).Name
            If .Columns(.CurrentCell.ColumnIndex).Tag = "EV" Then
                ControleSaisie(.CurrentCell, e, True, IIf(.DataSource.columns(NomCol).datatype.ToString.ToUpper.Contains("INT"), True, False), False, False, False)
            End If
        End With
    End Sub
    Sub Nouveau()
        Initialisation()
        Refreshing()
    End Sub
    Private Sub PrePaie_Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles PrePaie_Grd.DataError
        Try
        Catch ex As Exception

        End Try
    End Sub
    Sub Import()
        If PrePaie_Grd.RowCount = 0 Then
            ShowMessageBox("Veuillez générer d'abord votre préparation", "Importation des éléments variables", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        Dim f As New RH_Preparation_Paie_Import_EV
        With f
            .frm_Paie = Me
            newShowEcran(f, True)
        End With
    End Sub
    Private Sub PrePaie_Grd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles PrePaie_Grd.CellValueChanged
        If e.RowIndex < 0 Then Exit Sub
        If Cod_Plan_Paie_Text.Text = "" Then Exit Sub
        Dim nrw() As DataRow = PrePaie.TblFunction.Select("Cod_Function='" & PrePaie_Grd.Columns(e.ColumnIndex).Name & "'")
        If nrw.Length = 0 Then Return
        If nrw(0)("Typ_Retour").ToString.ToUpper = "FLOAT" Or nrw(0)("Typ_Retour").ToString.ToUpper = "INT" Then
            If Not IsNumeric(IsNull(PrePaie_Grd.Item(e.ColumnIndex, e.RowIndex).Value, "")) Then
                PrePaie_Grd.Item(e.ColumnIndex, e.RowIndex).Value = 0
            End If
        End If
        If Not (PrePaie_Grd.Columns(e.ColumnIndex).Tag = "EV") Then Exit Sub
        PrePaie.CalculPaie(PrePaie_Grd.Item("Matricule", e.RowIndex).Value, False)
    End Sub
    Private Sub PrePaie_Grd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles PrePaie_Grd.CellDoubleClick
        With PrePaie_Grd
            If .RowCount = 0 Then Return
            If e.RowIndex < 0 Then Return
            If e.ColumnIndex < 0 Then Return
            If .Columns("Matricule").Index = e.ColumnIndex Then
                Dim f As New RH_Agent
                With f
                    .Chargement()
                    .Matricule_Text.Text = PrePaie_Grd.Item("Matricule", e.RowIndex).Value
                    .StartPosition = FormStartPosition.CenterScreen
                    newShowEcran(f, True)
                End With
            End If
        End With
    End Sub
    Sub AttendreProcess(Debut As Boolean)
        PrePaie.oAvancementStrTitre = ""
        PrePaie.oAvancementStr = ""
        If Debut Then
            leMenu.pnl_sideBarL.Visible = False
            OTimer.Start()
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
            OTimer.Stop()
            leMenu.pnl_sideBarL.Visible = True
            If Me.Controls.Contains(PnlWait) Then Me.Controls.Remove(PnlWait)
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub OTimer_Tick(sender As Object, e As EventArgs) Handles OTimer.Tick
        With PnlWait
            .CircularProgress1.Value = IIf(.CircularProgress1.Value = 100, 0, .CircularProgress1.Value) + 10
            .lblAvancement.Text = PrePaie.oAvancementStrTitre
            .lblAvancement.Refresh()
            .lblProgress.Text = PrePaie.oAvancementStr
            .lblProgress.Refresh()
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
        PrePaie.InitialisationPaie(Cod_Preparation_Text.Text, Cod_Plan_Paie_Text.Text, Dat_Deb_Periode_Text.Text, Dat_Fin_Periode_Text.Text, withLog_chk.Checked)
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
#Region "Saving"
    Sub Cloturer()
        avecCloture = True
        Enregistrer()
    End Sub
    Sub Enregistrer()
        With PrePaie_Grd
            If .DataSource Is Nothing Then Return
            If .RowCount = 0 Then Return
        End With

        If PrePaie_Grd.ModeFiltreActive Then
            ShowMessageBox("Votre grille comporte un filtre." & vbCrLf & "Avant d'enregistrer veuillez défiltrer votre selection", "Filtre", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 1
            Return
        End If
        If Cod_Plan_Paie_Text.Text = "" Then
            MessageBoxRHP(706)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Exit Sub
        ElseIf CnExecuting($"select isnull(Valide,'false') Valide from RH_Param_Plan_Paie where id_Societe={Societe.id_Societe} and Cod_Plan_Paie='{Cod_Plan_Paie_Text.Text }'").Fields(0).Value = False Then
            ShowMessageBox("Veuillez d'abord valider le plan de paie avant de continuer votre préparation.", "Contrôle", MessageBoxButtons.OK, msgIcon.Error)
            Cursor = Cursors.Default
            Return
        End If
        New_D.Enabled = False
        Dim str As String = "AffectVar Dat_Deb_Periode, """ & Dat_Deb_Periode_Text.Text & """" & vbCrLf &
        "AffectVar Dat_Fin_Periode, """ & Dat_Fin_Periode_Text.Text & """"
        PrePaie.myVBS.ExecuteStatement(str)
        Saving()
        New_D.Enabled = True
    End Sub
    Sub Saving()
        If BKG_Save.IsBusy Then
            ShowMessageBox("Opération d'enregistrement en cours", "Enregistrer", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Cloture_Check.Checked Then
            MessageBoxRHP(705)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Exit Sub
        End If
        If Cod_Plan_Paie_Text.Text = "" Then
            MessageBoxRHP(706)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Exit Sub
        End If
        If Not EstDate(Dat_Deb_Periode_Text.Text) Or Not EstDate(Dat_Fin_Periode_Text.Text) Then
            MessageBoxRHP(707)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Exit Sub
        End If
        If CDate(Dat_Deb_Periode_Text.Text) >= CDate(Dat_Fin_Periode_Text.Text) Then
            ShowMessageBox("Incohérence date début et date fin", "Erreur date", MessageBoxButtons.OK, msgIcon.Stop)
            TabControl1.SelectedIndex = 0
            Cursor = Cursors.Default
            Exit Sub
        End If
        If CnExecuting("Select count(*) from Param_Periode_Paie where isnull(Cloture,'false')='false' and Annee='" & ConvertDate(Dat_Fin_Periode_Text.Text).Year & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value = 0 Then
            ShowMessageBox("Année de paie non ouverte", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Lib_Preparation_Text.Text.Trim = "" Then Lib_Preparation_Text.Text = "Paie du plan " & Cod_Plan_Paie_Text.Text & " du " & Dat_Deb_Periode_Text.Text & " au " & Dat_Fin_Periode_Text.Text
        If PrePaie.EVPrimeBrutifiee <> "" And PrePaie.EVPrimeABrutifier <> "" Then
            With PrePaie_Grd
                If .Columns.Contains(PrePaie.EVPrimeABrutifier) And .Columns.Contains(PrePaie.EVPrimeBrutifiee) Then
                    If PrePaie.TblPrePaie.Compute("sum(" & PrePaie.EVPrimeABrutifier & ")", "1=1") <> 0 Or PrePaie.TblPrePaie.Compute("sum(" & PrePaie.EVPrimeBrutifiee & ")", "1=1") <> 0 Then
                        If ShowMessageBox("Votre paie comporte des primes à brutifier, voulez-vous relancer le calcul des primes brutes correspondantes?", "Primes à brutifier", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.OK Then
                            PrePaie.CalculNetToBrut()
                        End If
                    End If
                End If
            End With
        End If
        AttendreProcess(True)
        PrePaie.Tbl_Controles.Rows.Clear()
        BKG_Save.RunWorkerAsync()
    End Sub
    Dim rslSaving As New PayRollEngine.savingResult
    Dim avecCloture As Boolean = False
    Private Sub BKG_Save_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_Save.DoWork
        With PrePaie_Grd
            If Cod_Preparation_Text.Text <> "" Then
                Dim swh As String = ""
                For i = 0 To lst_matricules_supprimes.Count - 1
                    swh &= IIf(swh = "", "", ",") & "'" & IsNull(lst_matricules_supprimes(i), "") & "'"
                Next
                If swh <> "" Then
                    PrePaie.oAvancementStrTitre &= vbCrLf & "Suppression de lignes. "
                    CnExecuting("delete from RH_Preparation_Paie_Detail where Matricule in (" & swh & ") and id_Societe='" & Societe.id_Societe & "' and Cod_Preparation='" & Cod_Preparation_Text.Text & "'
                                 delete from RH_Preparation_Paie_Analytique where Matricule in (" & swh & ") and id_Societe='" & Societe.id_Societe & "' and Cod_Preparation='" & Cod_Preparation_Text.Text & "'")
                    lst_matricules_supprimes.Clear()
                End If
            End If
        End With
        rslSaving = PrePaie.Saving(Lib_Preparation_Text.Text, Controler_chk.Checked, avecCloture)
    End Sub

    Private Sub ShowEV_chk_CheckedChanged(sender As Object, e As EventArgs) Handles ShowEV_chk.CheckedChanged, ShowCP_chk.CheckedChanged, ShowGains_chk.CheckedChanged, ShowRetenues_chk.CheckedChanged
        Dim rw() As DataRow = Nothing
        With PrePaie_Grd
            For i = 6 To .Columns.Count - 1
                rw = PrePaie.TblFunction.Select("Cod_Function='" & .Columns(i).Name & "'")
                If rw.Length > 0 Then
                    .Columns(i).Visible = Not (ShowEV_chk.Checked Or ShowGains_chk.Checked Or ShowRetenues_chk.Checked Or ShowCP_chk.Checked)
                    If rw(0)("Typ_Function") = "EV" And ShowEV_chk.Checked Then .Columns(i).Visible = True
                    If rw(0)("Gain_Retenue") = "G" And ShowGains_chk.Checked Then .Columns(i).Visible = True
                    If rw(0)("Gain_Retenue") = "R" And ShowRetenues_chk.Checked Then .Columns(i).Visible = True
                    If rw(0)("Patronal") And ShowCP_chk.Checked Then .Columns(i).Visible = True
                End If
            Next
        End With
    End Sub
    Private Sub HighLightEV_Chk_CheckedChanged(sender As Object, e As EventArgs) Handles HighLightEV_Chk.CheckedChanged
        HighLighter()
    End Sub
    Private Sub HighLightResume_Chk_CheckedChanged(sender As Object, e As EventArgs) Handles HighLightResume_Chk.CheckedChanged
        HighLighter()
    End Sub
    Sub HighLighter()
        If PrePaie_Grd.Rows.Count = 0 Then Return
        For Each k In PrePaie.dicColor.Keys
            If PrePaie_Grd.Columns.Contains(k) Then
                If HighLightResume_Chk.Checked Then
                    PrePaie_Grd.Columns(k).DefaultCellStyle.BackColor = PrePaie.dicColor(k)
                Else
                    PrePaie_Grd.Columns(k).DefaultCellStyle.BackColor = Nothing
                End If

            End If
        Next
        Dim rw() As DataRow = Nothing
        With PrePaie_Grd
            rw = PrePaie.TblFunction.Select("Typ_Function='EV'")
            For i = 0 To rw.Length - 1
                If .Columns.Contains(rw(i)("Cod_Function")) Then
                    If HighLightEV_Chk.Checked Then
                        .Columns(rw(i)("Cod_Function")).DefaultCellStyle.BackColor = Color.FromArgb(251, 255, 217)
                    Else
                        .Columns(rw(i)("Cod_Function")).DefaultCellStyle.BackColor = Nothing
                    End If
                End If
            Next
        End With
    End Sub
    Private Sub BKG_Save_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_Save.RunWorkerCompleted
        Grd_Controles.DataSource = PrePaie.Tbl_Controles
        If rslSaving.result Then
            PrePaie.CalculAuto = False
            If PrePaie.CodPreparation <> Cod_Preparation_Text.Text Then
                Cod_Preparation_Text.Text = PrePaie.CodPreparation
                ' Else
                '     Cod_Preparation_Text_TextChanged(Nothing, Nothing)
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
                NetToBrut_D.Enabled = False
            End If
            PrePaie.CalculAuto = True
            PrePaie.Modifie = False
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
            TabControl1.SelectedIndex = 2
        End If
    End Sub
#End Region
#Region "Request"
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Cod_Preparation_Text.Text <> "" Then Return
        Appel_Calender_Blocage(Dat_Fin_Periode_Text, Me, "Compta")
    End Sub
    Sub Request()
        PrePaie_Grd.DataSource = Nothing
        AttendreProcess(True)
        If Not BKG_Request.IsBusy Then BKG_Request.RunWorkerAsync()
    End Sub
    Private Sub Grd_Controles_Cell(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Controles.CellDoubleClick
        With PrePaie_Grd
            If e.RowIndex < 0 Then Return
            If .RowCount = 0 Then Return
            If e.ColumnIndex = 1 Then
                Dim r As Integer = -1
                For i = 0 To .RowCount - 1
                    If .Item("Matricule", i).Value = Grd_Controles.Item("Matricule", e.RowIndex).Value Then
                        r = i
                        Exit For
                    End If
                Next
                If r >= 0 Then
                    Dim f As New Zoom_RH_Preparation_Paie
                    With f
                        .frmPrePaie = Me
                        .Cloture_Check.Checked = Cloture_Check.Checked
                        .ShowCP_rb.Checked = ShowCP_chk.Checked
                        .ShowEV_rb.Checked = ShowEV_chk.Checked
                        .ShowGains_rb.Checked = ShowGains_chk.Checked
                        .ShowRetenues_rb.Checked = ShowRetenues_chk.Checked
                        .TblFunction = PrePaie.TblFunction
                        .CodPlan = Cod_Plan_Paie_Text.Text
                        .CodPreparation = Cod_Preparation_Text.Text
                        .Grd = PrePaie_Grd
                        .inDx = r
                        .Bulletin_chk.Checked = (PrePaie.elementDetailBulletinPaie.Length > 0)
                        .PreparationInitiale()
                        .Request()
                        newShowEcran(f, True)
                    End With
                End If
            End If
        End With
    End Sub
    Private Sub Dat_Fin_Periode_Text_TextChanged_1(sender As Object, e As EventArgs) Handles Dat_Fin_Periode_Text.TextChanged
        PrePaie_Grd.DataSource = Nothing
        oGrdFilter.FilterList.Controls.Clear()
        If EstDate(Dat_Fin_Periode_Text.Text) Then
            PrePaie.DatFin = Dat_Fin_Periode_Text.Text
            PrePaie.myVBS.ExecuteStatement("AffectVar Dat_Fin_Periode, """ & Dat_Fin_Periode_Text.Text & """")
        End If
    End Sub
    Sub ChargementFiltre()
        Dim CodPlan As String = Cod_Plan_Paie_Text.Text.Trim
        Dim TblSelect As DataTable = DATA_READER_GRD("select Cod_Filtre, Syntaxe from RH_Param_Plan_Paie_Filtre where id_Societe='" & Societe.id_Societe & "' and Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and Typ_Filtre='R'")
        Dim f As New RH_Preparation_Paie_SelectionFiltree
        oMnu.DropDownItems.Clear()
        For i = 0 To TblSelect.Rows.Count - 1
            Dim osMnu As New ToolStripMenuItem
            With osMnu
                .Name = TblSelect.Rows(i)("Cod_Filtre")
                .Text = .Name
                .Tag = {PrePaie_Grd, f.FilterSyntaxe(IsNull(TblSelect.Rows(i)("Syntaxe"), ""))}
                AddHandler .Click, AddressOf f.AppliquerLeFiltre
            End With
            oMnu.DropDownItems.Add(osMnu)
        Next
    End Sub
    Sub AddAgent()
        Dim swhere As String = ""
        With PrePaie_Grd
            '    If .RowCount <= 0 Then Return
            If Cod_Plan_Paie_Text.Text = "" Then Return
            '  If .ColumnCount <= 7 Then Return
            For i = 0 To .RowCount - 1
                swhere &= IIf(swhere = "", "", ",") & "'" & .Item("Matricule", i).Value & "'"
            Next
            TabControl1.SelectedIndex = 1
        End With
        Dim f As New Zoom_Preparation_Paie_Add_Agent
        With f
            .swhere = swhere
            .PlanPaie = Cod_Plan_Paie_Text.Text
            .f_preparation = Me
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub BKG_Request_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG_Request.DoWork
        PrePaie.Request(Cod_Preparation_Text.Text, Cod_Plan_Paie_Text.Text, Dat_Deb_Periode_Text.Text, Dat_Fin_Periode_Text.Text, withLog_chk.Checked)
    End Sub
    Sub MisEnFormeGrd()
        oGrdFilter.FilterList.Controls.Clear()
        'Style des colonnes
        Dim oCStyle As New DataGridViewCellStyle
        With oCStyle
            .Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        End With
        With PrePaie_Grd
            .DataSource = PrePaie.TblPrePaie
            '          .RowTemplate = New GrdNumberedRow
            If .Columns.Contains("Entité") Then
                .Columns("Entité").ReadOnly = True
            End If
            If .Columns.Contains("Grade") Then
                .Columns("Grade").ReadOnly = True
            End If
            If .Columns.Contains("Date Entrée") Then
                .Columns("Date Entrée").ReadOnly = True
            End If
            If .Columns.Contains("Type agent") Then
                .Columns("Type agent").ReadOnly = True
            End If
            If .Columns.Contains("Type contrat") Then
                .Columns("Type contrat").ReadOnly = True
            End If
            If .Columns.Contains("Matricule") Then
                .Columns("Matricule").ReadOnly = True
            End If
            With PrePaie_Grd
                .setFilter({0, 1, 2, 3})
            End With

            If .Columns.Contains("Nom") Then
                With .Columns("Nom")
                    .ReadOnly = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Frozen = True
                End With
            End If
            'Chargement des EV et FU et CS
            Dim ColNam As String = ""
            Dim nRows() As DataRow = Nothing
            For i = 0 To .ColumnCount - 1
                ColNam = .Columns(i).Name
                If PrePaie.strEP.Contains(ColNam) Then
                    nRows = PrePaie.TblFunction.Select("Cod_Function='" & ColNam & "'")
                    If nRows.Length > 0 Then
                        If PrePaie.TblPrePaie.Columns.Contains(ColNam) Then
                            PrePaie.TblPrePaie.Columns(i).ReadOnly = False
                            With .Columns(i)
                                .ReadOnly = Not (nRows(0)("Typ_Function") = "EV")
                                .HeaderText = nRows(0)("Lib_Abr") & vbCrLf & "(" & nRows(0)("Typ_Function") & ")"
                                .Tag = nRows(0)("Typ_Function")
                                With .DefaultCellStyle
                                    If PrePaie.dicColor.ContainsKey(ColNam) Then
                                        If ShowEV_chk.Checked Then .BackColor = PrePaie.dicColor(ColNam)
                                    End If
                                    If nRows(0)("Typ_Function") = "EV" And HighLightEV_Chk.Checked Then
                                        .BackColor = Color.FromArgb(251, 255, 217)
                                    End If
                                    .Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
                                    If nRows(0)("Est_Pourcentage") = True Then
                                        .Format = "#0.00%"
                                    Else
                                        .Format = "N" & nRows(0)("Nb_Decimal")
                                    End If
                                End With
                            End With
                        Else
                            ShowMessageBox("La Rubrique ou fonction : " & ColNam & " n'existe pas ou n'est pas de type numérique", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
                        End If
                    End If
                End If
                .Columns(i).Visible = Not PrePaie.strEM.Contains(ColNam)
            Next
        End With
        AppyFilter()
        TabControl1.SelectedIndex = 1
    End Sub
    Sub AppyFilter()
        Dim visibleColumns = From column In PrePaie_Grd.Columns.Cast(Of DataGridViewColumn)()
                             Where column.Visible
                             Select column
        If visibleColumns.Count = PrePaie_Grd.ColumnCount Then
            flter_pb.Image = My.Resources.btn_filter_w
        Else
            flter_pb.Image = ConvertToTargetColor(My.Resources.btn_filter_w, True, colorBase03)
        End If
    End Sub
    Private Sub BKG_Request_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG_Request.RunWorkerCompleted
        MisEnFormeGrd()
        HighLighter()
        AttendreProcess(False)
        New_D.Enabled = True
        PrePaie.Modifie = False
    End Sub


    Private Sub PrePaie_Grd_SelectionChanged(sender As Object, e As EventArgs) Handles PrePaie_Grd.SelectionChanged
        Try
            If Not TabControl1.SelectedIndex = 1 Then Return
            If PrePaie_Grd.SelectedCells.Count = 0 Then Return
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Grd_Controles_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Controles.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        If e.ColumnIndex = 1 Then
            Grd_Controles.Cursor = Cursors.Hand
        Else
            Grd_Controles.Cursor = Cursors.Default
        End If
    End Sub
#End Region
    Private Sub PrePaie_Grd_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles PrePaie_Grd.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        With PrePaie_Grd
            If .ColumnCount > 0 Then
                If .Columns.Contains("Matricule") Then
                    If e.ColumnIndex = .Columns("Matricule").Index Then
                        .Cursor = Cursors.Hand
                    Else
                        .Cursor = Cursors.Default
                    End If
                End If
            End If
        End With
    End Sub
    Sub NetToBrut()
        If Zoom_Generation_NetToBrut.BKG_NetToBrut.IsBusy Then
            ShowMessageBox("Un traitement est toujours en cours", "Merci de réessayer", MessageBoxButtons.OK, msgIcon.Information)
            Return
        End If
        PrePaie.CalculNetToBrut()
    End Sub

    Private Sub oCntx_Opening(sender As Object, e As CancelEventArgs) Handles oCntx.Opening
        oMnu7.Enabled = Not Cloture_Check.Checked
    End Sub
    Private Sub PrePaie_Grd_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles PrePaie_Grd.RowsRemoved
        If e.RowIndex < 0 OrElse e.RowIndex >= PrePaie_Grd.Rows.Count Then Return
        Dim matriculeSupp = ""
        With PrePaie_Grd
            If .Columns.Count = 0 Then Return
            If .DataSource Is Nothing Then Return
            matriculeSupp = IsNull(.Item("Matricule", e.RowIndex).Value, "")
        End With
        If matriculeSupp = "" Then Return

        With PrePaie.TblPrePaie
            Dim drw() = .Select("Matricule='" & matriculeSupp & "'")
            For Each r In drw
                .Rows.Remove(r)
            Next
            .AcceptChanges()
        End With
    End Sub
    Private Sub PrePaie_Grd_KeyUp(sender As Object, e As KeyEventArgs) Handles PrePaie_Grd.KeyUp
        If e.KeyData = Keys.Delete Then
            e.SuppressKeyPress = True
            e.Handled = True
        End If
    End Sub
    Private Sub PrePaie_Grd_KeyDown(sender As Object, e As KeyEventArgs) Handles PrePaie_Grd.KeyDown
        If e.KeyData = Keys.Delete Then
            e.SuppressKeyPress = True
            e.Handled = True
        End If
    End Sub

    Private Sub Ud_button1_Click(sender As Object, e As EventArgs) Handles ModifierPlan_btn.Click
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

    Private Sub withLog_chk_CheckedChanged(sender As Object, e As EventArgs) Handles withLog_chk.CheckedChanged
        PrePaie.myVBS.withLog = withLog_chk.Checked
    End Sub

    Private Sub rowHeaderVisible_chk_CheckedChanged(sender As Object, e As EventArgs) Handles rowHeaderVisible_chk.CheckedChanged
        PrePaie_Grd.RowHeadersVisible = rowHeaderVisible_chk.Checked
    End Sub
    Private Sub AlternerLesLignes_chk_CheckedChanged(sender As Object, e As EventArgs) Handles AlternerLesLignes_chk.CheckedChanged
        PrePaie_Grd.AlternerLesLignes = AlternerLesLignes_chk.Checked
    End Sub
End Class