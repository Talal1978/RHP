Public Class RH_Bulletin_Liste
    Friend swhere As String = " id_Societe=" & Societe.id_Societe
    Dim VenTbl As New DataTable
    Private Sub Ges_Pie_Clt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Matricule_txt.Text = "" And theUser.Typ_Role = "Agent" Then Matricule_txt.Text = theUser.Matricule
        Grille.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Dat_Debut.Text = Now.AddDays(-Now.Day + 1).ToShortDateString
        Dat_Fin.Text = Now.AddMonths(1).AddDays(-Now.Day).ToShortDateString
    End Sub
    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_Debut, Me)
    End Sub
    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Appel_Calender(Dat_Fin, Me)
    End Sub
    Sub Requesting()
        Grille.DataSource = Nothing
        Grille.Columns.Clear()
        If Not EstDate(Dat_Debut.Text) Then Dat_Debut.Text = Now.AddDays(-Now.Day + 1).ToShortDateString
        If Not EstDate(Dat_Fin.Text) Then Dat_Fin.Text = Now.AddMonths(1).AddDays(-Now.Day).ToShortDateString
        swhere = " id_Societe=" & Societe.id_Societe
        Cursor = Cursors.WaitCursor
        Dim Cod_Sql As String = ""
        If EstDate(Dat_Debut.Text) And EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and  Dat_Deb_Periode between '" & Dat_Debut.Text & "' and '" & Dat_Fin.Text & "' "
        ElseIf EstDate(Dat_Debut.Text) Then
            swhere = swhere & " and Dat_Deb_Periode >= '" & Dat_Debut.Text & "'"
        ElseIf EstDate(Dat_Fin.Text) Then
            swhere = swhere & " and Dat_Deb_Periode <= '" & Dat_Fin.Text & "'"
        End If
        Cod_Sql = " select  Cod_Preparation as Préparation, Annee_Paie as 'Année', Mois_Paie as 'Mois' 
from RH_Preparation_Paie e
where exists(select Matricule from RH_Preparation_Paie_Detail d where e.Cod_Preparation=d.Cod_Preparation and e.id_Societe=d.id_Societe and Matricule='" & Matricule_txt.Text & "')
and isnull(Cloture,'false')='true'
and " & swhere & " Order by [Année],[Mois] desc"
        Dim Tbl0 As DataTable = DATA_READER_GRD(Cod_Sql)
        With Grille
            .DataSource = Tbl0
            .Columns("Année").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Mois").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dim prt As New DataGridViewImageColumn
            With prt
                .Name = "Print"
                .HeaderText = " "
                .Image = My.Resources.printer_2
            End With
            .Columns.Insert(0, prt)
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
        Cursor = Cursors.Default
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Matricule_txt, Me)
        End If
    End Sub
    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent + ' ' +Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        Cod_Plan_Paie_txt.Text = FindLibelle("Plan_Paie", "Matricule", Matricule_txt.Text, "RH_Agent")
        Modele_Bulletin_txt.Text = FindLibelle("Modele_Bulletin", "Cod_Plan_Paie", Cod_Plan_Paie_txt.Text, "RH_Param_Plan_Paie")
        Grille.DataSource = Nothing
    End Sub
    Private Sub Cod_Report_Text_TextChanged(sender As Object, e As EventArgs) Handles Modele_Bulletin_txt.TextChanged
        If Modele_Bulletin_txt.Text.Trim <> "" Then
            Dim Rpt As String = FindParam("Lecteur_Digital_Mod_Edition") & "\" & Modele_Bulletin_txt.Text & ".rpt"
            If IO.File.Exists(Rpt) = False Then
                ReportExists_Label.Visible = True
            Else
                ReportExists_Label.Visible = False
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If theUser.Typ_Role = "Agent" Then Return
        Appel_Zoom("Cod_Report", "Nom_Report", "Param_Mod_Edition", "isnull(Typ_Modele_Edition,'A')='BP'", Modele_Bulletin_txt, Me)
    End Sub

    Sub Printing()
        If Grille.Rows.Count = 0 Then
            ShowMessageBox("Sélection de bulletins de paie vide.", "Impression des bulletins de paie", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        If Modele_Bulletin_txt.Text.Trim() = "" Then
            ShowMessageBox("Le modèle de bulletin n'est pas renseigné.", "Impression des bulletins de paie", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        Dim TblCriteres = DATA_READER_GRD("select * from Param_Mod_Edition_Criteres where Cod_Report='" & Modele_Bulletin_txt.Text & "'")
        Dim crt() = "idSoc;CodPlan;MatDeb;MatFin;DatDeb;DatFin;CodPreparation".Split(";")
        For Each c In crt
            If TblCriteres.Select("Critere='" & c & "'").Length = 0 Then
                ShowMessageBox("Le modèle de bulletin ne comporte pas tous les critères demandés." & vbCrLf & c & vbCrLf & String.Join(", ", crt), "Impression des bulletins de paie", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
        Next
        If ReportExists_Label.Visible Then
            ShowMessageBox("Le modèle de bulletin de paie choisi n'existe pas.", "Impression des bulletins de paie", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        Dim Path As String = FindParam("Lecteur_Digital_Mod_Edition")
        Dim Report As String = Modele_Bulletin_txt.Text
        Dim Rpt As String = Path + "\" + Report + ".rpt"
        Dim f As New Zoom_Edition_Odbc
        With f
            .ParamList.Clear()
            .ValList.Clear()
            .oMailSujet = "Bulletin de paie"
            .DisplayTree = True
            .etat = Rpt
            .ParamList.Add("idSoc")
            .ValList.Add(Societe.id_Societe)
            .ParamList.Add("CodPlan")
            .ValList.Add("")
            .ParamList.Add("MatDeb")
            .ValList.Add(Matricule_txt.Text)
            .ParamList.Add("MatFin")
            .ValList.Add(Matricule_txt.Text)
            .ParamList.Add("DatDeb")
            .ValList.Add(Dat_Debut.Text)
            .ParamList.Add("DatFin")
            .ValList.Add(Dat_Fin.Text)
            .ParamList.Add("CodPreparation")
            .ValList.Add("")
            .Show()
        End With
    End Sub

    Private Sub Dat_Debut_TextChanged(sender As Object, e As EventArgs) Handles Dat_Debut.TextChanged
        Grille.DataSource = Nothing
    End Sub

    Private Sub Dat_Fin_TextChanged(sender As Object, e As EventArgs) Handles Dat_Fin.TextChanged
        Grille.DataSource = Nothing
    End Sub
    Private Sub Grille_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grille.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        Grille.Cursor = Cursors.Default
        If e.ColumnIndex = 0 Then
            If e.RowIndex >= 0 Then
                Grille.Cursor = Cursors.Hand
            End If
        End If
    End Sub

    Private Sub Grille_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grille.CellMouseClick
        If e.RowIndex < 0 Or e.ColumnIndex <> 0 Then Return
        If Grille.Rows.Count = 0 Then
            ShowMessageBox("Sélection de bulletins de paie vide.", "Impression des bulletins de paie", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        If Modele_Bulletin_txt.Text.Trim() = "" Then
            ShowMessageBox("Le modèle de bulletin n'est pas renseigné.", "Impression des bulletins de paie", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        If ReportExists_Label.Visible Then
            ShowMessageBox("Le modèle de bulletin de paie choisi n'existe pas.", "Impression des bulletins de paie", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        Dim TblCriteres = DATA_READER_GRD("select * from Param_Mod_Edition_Criteres where Cod_Report='" & Modele_Bulletin_txt.Text & "'")
        Dim crt() = "idSoc;CodPlan;MatDeb;MatFin;DatDeb;DatFin;CodPreparation".Split(";")
        For Each c In crt
            If TblCriteres.Select("Critere='" & c & "'").Length = 0 Then
                ShowMessageBox("Le modèle de bulletin ne comporte pas tous les critères demandés." & vbCrLf & c & vbCrLf & String.Join(", ", crt), "Impression des bulletins de paie", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
        Next
        Dim Path As String = FindParam("Lecteur_Digital_Mod_Edition")
        Dim Report As String = Modele_Bulletin_txt.Text
        Dim Rpt As String = Path + "\" + Report + ".rpt"
        Dim f As New Zoom_Edition_Odbc
        With f
            .ParamList.Clear()
            .ValList.Clear()
            .oMailSujet = "Bulletin de paie"
            .DisplayTree = True
            .etat = Rpt
            .ParamList.Add("idSoc")
            .ValList.Add(Societe.id_Societe)
            .ParamList.Add("CodPlan")
            .ValList.Add("")
            .ParamList.Add("MatDeb")
            .ValList.Add(Matricule_txt.Text)
            .ParamList.Add("MatFin")
            .ValList.Add(Matricule_txt.Text)
            .ParamList.Add("DatDeb")
            .ValList.Add(Dat_Debut.Text)
            .ParamList.Add("DatFin")
            .ValList.Add(Dat_Fin.Text)
            .ParamList.Add("CodPreparation")
            .ValList.Add(Grille.Item("Préparation", e.RowIndex).Value)
            .Show()
        End With
    End Sub
End Class