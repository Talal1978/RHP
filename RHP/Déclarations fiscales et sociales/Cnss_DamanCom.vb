Public Class Cnss_DamanCom
    Friend Nouveau As Boolean = True
    Dim oCell As DataGridViewCell = Nothing
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Request_D As ud_btn
    Dim Print_D As ud_btn
    Dim Import_D As ud_btn
    Dim Search_D As ud_btn
    Dim New_D As ud_btn
    Dim Preetabli_D As ud_btn
    Dim BDS_D As ud_btn
    Dim Cloture_D As ud_btn
    Private Function Enregistrer(AvecValidation As Boolean) As Boolean
        If pbValide.Visible Then
            ShowMessageBox("Période de déclaration validée?", "RHP")
            Return False
        End If
        If Not IsNumeric(Num_Affilie_txt.Text.Trim) Then
            ShowMessageBox("Numéro Affilié non numerique: doit être un entier", "RHP")
            Return False
        End If
        If Num_Affilie_txt.Text <> Societe.CNSS Then
            ShowMessageBox("Numéro Affilié ne correspond pas à celui des renseignements de la Société : " & Societe.Denomination, "RHP")
            Return False
        End If
        If Identif_Transfert_Text.Text.Trim = "" And Dat_Import_Preetabli_txt.Text <> "" Then
            ShowMessageBox("Identifiant de transfert non renseigné", "RHP")
            Return False
        ElseIf Identif_Transfert_Text.Text.Trim = "" Then
            Nouveau = True
            Identif_Transfert_Text.Text = Num_Affilie_txt.Text & Droite(CStr(Annee.Value), 2) & Periode_Cbo.SelectedValue & Societe.id_Societe
            Nouveau = False
        End If
        If Not IsNumeric(Identif_Transfert_Text.Text.Trim) Then
            ShowMessageBox("Identifiant de transfert non numerique: doit être un entier", "RHP")
            Return False
        End If

        If Not EstDate(Date_Emission_txt.Text) Then
            ShowMessageBox("Erreur date émission", "RHP")
            Return False
        End If
        If Not EstDate(Date_Exig_txt.Text) Then
            ShowMessageBox("Erreur date exigibilité", "RHP")
            Return False
        End If

        Dim rs As New ADODB.Recordset
        Dim owh As String = ""
        Dim nb As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            'vérification des champs obligatoires
            'Supprimer de la base les lignes supprimés de la grille
            CnExecuting("delete from Damancom_Ent where  Identif_Transfert='" & Identif_Transfert_Text.Text & "'")
            CnExecuting("delete from Damancom_Lig where  Identif_Transfert='" & Identif_Transfert_Text.Text & "'")
            With Grd_Permanent
                For i = 0 To .RowCount - IIf(.AllowUserToAddRows, 2, 1)
                    If Not IsNumeric(.Item(Num_Assure.Index, i).Value) Then
                        ShowMessageBox("Permanents - Erreur N° Assuré ligne : " & i + 1)
                        Return False
                    End If
                    If IsNull(.Item(Nom.Index, i).Value, "").Trim = "" And IsNull(.Item(Prenom.Index, i).Value, "").Trim = "" Then
                        ShowMessageBox("Permanents - Erreur Non, Prénom Assuré ligne : " & i + 1)
                        Return False
                    End If
                Next
            End With
            With Grd_Entrants
                For i = 0 To .RowCount - IIf(.AllowUserToAddRows, 2, 1)
                    If Not IsNumeric(.Item(Num_Assure_E.Index, i).Value) Then
                        ShowMessageBox("Entrants - Erreur N° Assuré ligne : " & i + 1)
                        Return False
                    End If
                    If IsNull(.Item(Nom_E.Index, i).Value, "").Trim = "" Or IsNull(.Item(Prenom_E.Index, i).Value, "").Trim = "" Then
                        ShowMessageBox("Entrants - Erreur Non, Prénom Assuré ligne : " & i + 1)
                        Return False
                    End If
                    If IsNull(.Item(Num_CIN_E.Index, i).Value, "").Trim = "" Then
                        ShowMessageBox("Entrants - Erreur N° CIN Assuré ligne : " & i + 1)
                        Return False
                    End If
                Next
            End With
            rs.Open("Select *  from Damancom_Ent", cn, 2, 2)
            rs.AddNew()
            rs("Identif_Transfert").Value = Identif_Transfert_Text.Text
            rs("id_Societe").Value = Societe.id_Societe
            rs("Num_Affilie").Value = Num_Affilie_txt.Text
            rs("Raison_Sociale").Value = Raison_Sociale_txt.Text
            rs("Activite").Value = Activite_txt.Text
            rs("Adresse").Value = Adresse_txt.Text
            rs("Ville").Value = Ville_txt.Text
            rs("CP").Value = CP_txt.Text
            rs("Agence").Value = Agence_txt.Text
            rs("Source_Preetabli").Value = Source_Preetabli_chk.Checked
            rs("Periode").Value = Periode_Cbo.SelectedValue
            rs("Valide").Value = IIf(AvecValidation = True, 1, 0)
            rs("Annee").Value = Annee.Value
            rs("Date_Emission").Value = Date_Emission_txt.Text
            rs("Date_Exig").Value = Date_Exig_txt.Text
            If IsDate(Dat_Import_Preetabli_txt.Text) Then
                rs("Dat_Import_Preetabli").Value = Dat_Import_Preetabli_txt.Text
            Else
                rs("Dat_Import_Preetabli").Value = Nothing
            End If
            If IsDate(Dat_Import_Permanent_txt.Text) Then
                rs("Dat_Import_Permanent").Value = Dat_Import_Permanent_txt.Text
            Else
                rs("Dat_Import_Permanent").Value = Nothing
            End If
            If IsDate(Dat_Import_Entrant_txt.Text) Then
                rs("Dat_Import_Entrant").Value = Dat_Import_Entrant_txt.Text
            Else
                rs("Dat_Import_Entrant").Value = Nothing
            End If
            rs("Dat_Modif").Value = Now
            rs.Update()
            rs.Close()

            With Grd_Permanent
                'Début d'enregistrement
                rs.Open("Select * from Damancom_Lig", cn, 2, 2)
                For i = 0 To .RowCount - IIf(.AllowUserToAddRows, 2, 1)
                    rs.AddNew()
                    rs("Num_Assure").Value = .Item(Num_Assure.Index, i).Value
                    rs("Nom").Value = .Item(Nom.Index, i).Value
                    rs("Prenom").Value = .Item(Prenom.Index, i).Value
                    rs("N_Enfants").Value = .Item(N_Enfants.Index, i).Value
                    rs("AF_A_Payer").Value = .Item(AF_A_Payer.Index, i).Value
                    rs("AF_A_Deduire").Value = .Item(AF_A_Deduire.Index, i).Value
                    rs("AF_Net_A_Payer").Value = .Item(AF_Net_A_Payer.Index, i).Value
                    rs("AF_A_Reverser").Value = .Item(AF_A_Reverser.Index, i).Value
                    rs("Jours_Declares").Value = .Item(Jours_Declares.Index, i).Value
                    rs("Salaire_Reel").Value = .Item(Salaire_Reel.Index, i).Value
                    rs("Salaire_Plaf").Value = .Item(Salaire_Plaf.Index, i).Value
                    rs("Situation").Value = .Item(Situation.Index, i).Value
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Typ_Assure").Value = "B02"
                    rs("Identif_Transfert").Value = Identif_Transfert_Text.Text
                    rs("Rang").Value = nb
                    rs("ImportData").Value = .Item(ImportData.Index, i).Value
                    rs.Update()
                    nb += 1
                Next
                rs.Close()
            End With


            With Grd_Entrants
                'Début d'enregistrement
                rs.Open("Select * from Damancom_Lig", cn, 2, 2)
                For i = 0 To .RowCount - IIf(.AllowUserToAddRows, 2, 1)
                    rs.AddNew()
                    rs("Num_Assure").Value = .Item(Num_Assure.Index, i).Value
                    rs("Nom").Value = .Item(Nom.Index, i).Value
                    rs("Prenom").Value = .Item(Prenom.Index, i).Value
                    rs("CIN").Value = .Item(Num_CIN_E.Index, i).Value
                    rs("Jours_Declares").Value = .Item(Nbr_Jours_E.Index, i).Value
                    rs("Salaire_Reel").Value = .Item(Sal_Reel_E.Index, i).Value
                    rs("Salaire_Plaf").Value = .Item(Sal_Plaf_E.Index, i).Value
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Typ_Assure").Value = "B04"
                    rs("Identif_Transfert").Value = Identif_Transfert_Text.Text
                    rs("Rang").Value = nb
                    rs.Update()
                    nb += 1
                Next
                rs.Close()
            End With

            ShowMessageBox("Enregistré avec succès", "RHP-DamanCom")
            Cursor = Cursors.Default
            Return True
        Catch ex As Exception
            ShowMessageBox(ex.Message, "RHP-DamanCom")
            Cursor = Cursors.Default
            Return False
        End Try
    End Function
    Sub ChargementCombo()
        If Periode_Cbo.Items.Count = 0 Then Periode_Cbo.FromSQL("select Cod_Periode, Lib_Periode from Param_DamnCom_Periode order by Cod_Periode")
        If Situation.Items.Count = 0 Then Combo_GRD_Linked(Situation, "select ltrim(rtrim(Cod_Situation)) Cod_Situation, Lib_Situation from Param_DamanCom_Situation order by Rang")
    End Sub
    Private Sub frm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Request_D = dictButtons("Request_D")
        Print_D = dictButtons("Print_D")
        Import_D = dictButtons("Import_D")
        Search_D = dictButtons("Search_D")
        New_D = dictButtons("New_D")
        Preetabli_D = dictButtons("Preetabli_D")
        BDS_D = dictButtons("BDS_D")
        Cloture_D = dictButtons("Cloture_D")
        ChargementCombo()
        If Nouveau Then
            If Now.Month = 1 Then
                Annee.Value = Now.Year - 1
            Else
                Annee.Value = Now.Year
            End If
            If Agence_txt.Text = "" Then Agence_txt.Text = Societe.CNSS_Agence
            Periode_Cbo.SelectedValue = Droite("00" & DateAdd(DateInterval.Month, -1, Now).Month, 2)
            Grd_Permanent.DataSource = Nothing
        End If
        Grd_Permanent.ContextMenuStrip = AddContextMenu(True, True, False, True, True, True, True, False)
        Grd_Entrants.ContextMenuStrip = AddContextMenu(True, True, False, True, True, True, True, False)
        Nom.Tag = "string"
        Prenom.Tag = "string"
        N_Enfants.Tag = "int"
        AF_A_Payer.Tag = "float"
        AF_A_Deduire.Tag = "float"
        AF_Net_A_Payer.Tag = "float"
        AF_A_Reverser.Tag = "float"
        Jours_Declares.Tag = "float"
        Salaire_Reel.Tag = "float"
        Salaire_Plaf.Tag = "float"
        Situation.Tag = "string"
        Nom_E.Tag = "string"
        Prenom_E.Tag = "string"
        Nbr_Jours_E.Tag = "float"
        Sal_Reel_E.Tag = "float"
        Sal_Plaf_E.Tag = "float"
        Num_CIN_E.Tag = "string"
        If Nouveau Then Request()
    End Sub
    Sub Request()
        Cursor = Cursors.Default
        ChargementCombo()
        Dim CodSql As String = "SELECT * FROM Damancom_Ent where Identif_Transfert='" & Identif_Transfert_Text.Text & "'"
        Dim Tbl As DataTable = DATA_READER_GRD(CodSql)
        With Tbl
            If Tbl.Rows.Count > 0 Then
                Identif_Transfert_Text.Text = IsNull(.Rows(0).Item("Identif_Transfert"), "")
                Num_Affilie_txt.Text = IsNull(.Rows(0).Item("Num_Affilie"), "")
                Raison_Sociale_txt.Text = IsNull(.Rows(0).Item("Raison_Sociale"), "")
                Activite_txt.Text = IsNull(.Rows(0).Item("Activite"), "")
                Adresse_txt.Text = IsNull(.Rows(0).Item("Adresse"), "")
                Ville_txt.Text = IsNull(.Rows(0).Item("Ville"), "")
                CP_txt.Text = IsNull(.Rows(0).Item("CP"), "")
                Agence_txt.Text = IsNull(.Rows(0).Item("Agence"), "")
                Source_Preetabli_chk.Checked = IsNull(.Rows(0).Item("Source_Preetabli"), False)
                Annee.Value = IsNull(.Rows(0).Item("Annee"), Now.Year)
                Periode_Cbo.SelectedValue = IsNull(.Rows(0).Item("Periode"), "")
                Dat_Import_Preetabli_txt.Text = IsNull(.Rows(0).Item("Dat_Import_Preetabli"), "")
                Dat_Import_Permanent_txt.Text = IsNull(.Rows(0).Item("Dat_Import_Permanent"), "")
                Dat_Import_Entrant_txt.Text = IsNull(.Rows(0).Item("Dat_Import_Entrant"), "")
                pbValide.Visible = IsNull(.Rows(0).Item("Valide"), False)
                Date_Emission_txt.Text = IsNull(.Rows(0).Item("Date_Emission"), Now.Date)
                Date_Exig_txt.Text = IsNull(.Rows(0).Item("Date_Exig"), Now.Date)
                request_Permanent()
                request_Entrant()
            Else
                initialiserDamancom()
            End If
        End With
        TabControl1.SelectedIndex = 0
    End Sub
    Sub request_Permanent()
        Grd_Permanent.Rows.Clear()
        Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, c12, C13 As Object

        Dim CodSql As String = "SELECT * FROM Damancom_Lig where Identif_Transfert='" & Identif_Transfert_Text.Text & "' and isnull(Typ_Assure,'')='B02'  order by Rang"
        Dim TblLig As DataTable = DATA_READER_GRD(CodSql)
        With TblLig
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Num_Assure"), "")
                C2 = IsNull(.Rows(i).Item("Nom"), "")
                C3 = IsNull(.Rows(i).Item("Prenom"), "")
                C4 = FormatNumber(.Rows(i).Item("N_Enfants"), 0)
                C5 = FormatNumber(.Rows(i).Item("AF_A_Payer"), 2)
                C6 = FormatNumber(.Rows(i).Item("AF_A_Deduire"), 2)
                C7 = FormatNumber(.Rows(i).Item("AF_Net_A_Payer"), 2)
                C8 = FormatNumber(.Rows(i).Item("AF_A_Reverser"), 2)
                C9 = FormatNumber(.Rows(i).Item("Jours_Declares"), 2)
                C10 = FormatNumber(.Rows(i).Item("Salaire_Reel"), 2)
                C11 = FormatNumber(.Rows(i).Item("Salaire_Plaf"), 2)
                c12 = IsNull(.Rows(i).Item("Situation"), "")
                C13 = IsNull(.Rows(i).Item("ImportData"), False)
                Grd_Permanent.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, c12, C13)
            Next
        End With

    End Sub

    Sub request_Entrant()
        Grd_Entrants.Rows.Clear()
        Dim C1, C2, C3, C4, C5, C6, C7 As Object
        Dim CodSql As String = "Select *  FROM Damancom_Lig 
       where  Identif_Transfert='" & Identif_Transfert_Text.Text & "' and isnull(Typ_Assure,'')='B04' order by Rang "
        Dim Tbl As DataTable = DATA_READER_GRD(CodSql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Num_Assure"), "")
                C2 = IsNull(.Rows(i).Item("Nom"), "")
                C3 = IsNull(.Rows(i).Item("Prenom"), "")
                C4 = .Rows(i).Item("CIN")
                C5 = FormatNumber(.Rows(i).Item("Jours_Declares"), 2)
                C6 = FormatNumber(.Rows(i).Item("Salaire_Reel"), 2)
                C7 = FormatNumber(.Rows(i).Item("Salaire_Plaf"), 2)
                Grd_Entrants.Rows.Add(C1, C2, C3, C4, C5, C6, C7)
            Next
        End With

    End Sub

    Private Sub Grd_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grd_Permanent.CellValidated
        MAJGrd(e.RowIndex, Grd_Permanent)
    End Sub
    Private Sub GrdEntrant_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grd_Entrants.CellValidated
        MAJGrd(e.RowIndex, Grd_Entrants)
    End Sub
    Private Sub Grd_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Grd_Permanent.EditingControlShowing
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        Dim c As Integer = Grd_Permanent.CurrentCell.ColumnIndex
        Select Case Grd_Permanent.Columns(c).Tag
            Case "int", "bigint", "float"
                AddHandler e.Control.KeyPress, AddressOf CheckCell

        End Select
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Grd_Permanent.CurrentRow Is Nothing Then Exit Sub
        Dim c As Integer = Grd_Permanent.CurrentCell.ColumnIndex
        Select Case Grd_Permanent.Columns(c).Tag
            Case "int", "bigint"
                ControleSaisie(sender, e, True, True, True, False, False)
            Case "float"
                ControleSaisie(sender, e, True, True, False, False, False)
        End Select
    End Sub
    Private Sub Grd_Entrants_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Grd_Entrants.EditingControlShowing
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell_Entrant
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell_Entrant
        Dim c As Integer = Grd_Entrants.CurrentCell.ColumnIndex
        Select Case Grd_Permanent.Columns(c).Tag
            Case "int", "bigint", "float"
                AddHandler e.Control.KeyPress, AddressOf CheckCell_Entrant

        End Select
    End Sub
    Private Sub CheckCell_Entrant(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Grd_Entrants.CurrentRow Is Nothing Then Exit Sub
        Dim c As Integer = Grd_Entrants.CurrentCell.ColumnIndex
        Select Case Grd_Entrants.Columns(c).Tag
            Case "int", "bigint"
                ControleSaisie(sender, e, True, True, True, False, False)
            Case "float"
                ControleSaisie(sender, e, True, True, False, False, False)
        End Select
    End Sub
    Private Sub Annee_Value_ValueChanged(sender As Object, e As System.EventArgs)
        Request()
    End Sub

    Private Sub PeriodeTVA_Combo_DropDownClosed(sender As Object, e As System.EventArgs)
        Request()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Up, Keys.Down, Keys.Left, Keys.Right

        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Sub MAJGrd(numLig As Integer, MyGrd As DataGridView)

        With MyGrd
            For j = 0 To .ColumnCount - 1

                Select Case .Columns(j).Tag
                    Case "int", "bigint"
                        If Not IsNumeric(.Item(j, numLig).Value) Then .Item(j, numLig).Value = 0
                        .Item(j, numLig).Value = FormatNumber(.Item(j, numLig).Value, 0)
                    Case "float"
                        If Not IsNumeric(.Item(j, numLig).Value) Then .Item(j, numLig).Value = 0
                        .Item(j, numLig).Value = FormatNumber(.Item(j, numLig).Value, 2)
                End Select

            Next
        End With

    End Sub
    Sub Searching()
        With Zoom_Chercher
            .Grd = IIf(TabControl1.SelectedTab Is Permanents, Grd_Entrants, Grd_Permanent)
            .Show()
        End With
    End Sub
    Sub Saving()
        If ShowMessageBox("Voulez-vous enregistrer?", "RHP-DamanCom", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then Exit Sub
        If Enregistrer(False) Then
            Request()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub Importer()
        If pbValide.Visible Then
            ShowMessageBox("Période de déclaration Clôturée", "DamanCom : Accès", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Not Source_Preetabli_chk.Checked Then
            ShowMessageBox("Attention : Vous n'avez pas importé le fichier préétabli", "DamanCom : Attention", MessageBoxButtons.OK, msgIcon.Warning)
            ' Return
        End If
        Dim f As New Cnss_DamanCom_Import
        With f
            .frm = Me
            .FormBorderStyle = FormBorderStyle.FixedSingle
            .Annee = Annee.Value
            .oPeriode = Periode_Cbo.SelectedValue
            newShowEcran(f, True)
        End With
    End Sub
    Sub Cloturer()
        If ShowMessageBox("Etes vous sûr de vouloir valider définitivement cette période?", "RHP", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then Return
        If Enregistrer(True) Then
            Request()
        End If
    End Sub
    Sub Printing()
        If CnExecuting("Select count(*) from DamanCom_Ent where id_Societe=" & Societe.id_Societe & " and Annee=" & Annee.Value & " and Periode='" & Periode_Cbo.SelectedValue & "'").Fields(0).Value = 0 Then Return
        Dim f As New Zoom_Edition_Odbc
        With f
            .etat = "00010.mtm"
            .ParamList.Add("Societe")
            .ValList.Add(Societe.id_Societe)
            .ParamList.Add("Periode")
            .ValList.Add(Periode_Cbo.SelectedValue)
            .ParamList.Add("Annee")
            .ValList.Add(Annee.Value)
            newShowEcran(f, True)
        End With
    End Sub
    Sub BDS()
        If Not Droits.DamanCom Then
            ShowMessageBox("Fonction non autorisée par votre licence")
            Return
        End If
        If Identif_Transfert_Text.Text.Trim = "" Then
            ShowMessageBox("Identifiant de transfert Vide")
            Return
        End If
        If Not Source_Preetabli_chk.Checked Then
            ShowMessageBox("Attention : Votre déclaration ne provient pas d'un modèle préétabli de la CNSS", "Attention", MessageBoxButtons.OK, msgIcon.Warning)
        End If
        If (CnExecuting("Select count(*) from DamanCom_Lig WHERE Identif_Transfert='" & Identif_Transfert_Text.Text & "'").Fields(0).Value = 0) Then
            Interaction.MsgBox(("La déclaration ne contient aucune écriture pour cette période"), MsgBoxStyle.Information, Nothing)
        Else
            Dim dialog As New SaveFileDialog
            dialog.Reset()
            Dim dialog2 As SaveFileDialog = dialog
            dialog2.FileName = "DS_" & Societe.CNSS & "_" & CDate(Date_Emission_txt.Text).Year & Droite("00" & CDate(Date_Emission_txt.Text).Month, 2) & ".txt"
            dialog2.Filter = "Fichiers txt|*.txt*"
            dialog2.DefaultExt = "txt"
            dialog2.AddExtension = True
            dialog2.ShowDialog()
            Dim fileName As String = dialog2.FileName
            dialog2 = Nothing
            If (fileName <> "") Then
                Cursor = Cursors.WaitCursor
                DamanComEDI.GenererEDI_DamanCom(fileName, Annee.Value, Periode_Cbo.SelectedValue, Identif_Transfert_Text.Text)

                Cursor = Cursors.Default
            End If
        End If
    End Sub
    Sub Preetabli()
        If EstDate(Dat_Import_Permanent_txt.Text) Then
            If ShowMessageBox("Des données ont été déjà importées." & vbCrLf & "En continuant, ces données vont être supprimées", "DamanCom : Importation du fichier préétabli", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then
                Return
            End If
        End If

        Dim f As New Zoom_Cnss_Damancom_Preetabli
        With f
            .frm = Me
            .StartPosition = FormStartPosition.CenterScreen
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Source_Preetabli_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Source_Preetabli_chk.CheckedChanged
        Identif_Transfert_Text.ReadOnly = Source_Preetabli_chk.Checked
        Num_Affilie_txt.ReadOnly = Source_Preetabli_chk.Checked
        Annee.Enabled = Not Source_Preetabli_chk.Checked
        Periode_Cbo.Enabled = Not Source_Preetabli_chk.Checked
        Raison_Sociale_txt.ReadOnly = Source_Preetabli_chk.Checked
        Activite_txt.ReadOnly = Source_Preetabli_chk.Checked
        Adresse_txt.ReadOnly = Source_Preetabli_chk.Checked
        Ville_txt.ReadOnly = Source_Preetabli_chk.Checked
        CP_txt.ReadOnly = Source_Preetabli_chk.Checked
        Agence_txt.ReadOnly = Source_Preetabli_chk.Checked
        Lib_Agence_txt.ReadOnly = Source_Preetabli_chk.Checked
        Date_Emission_txt.ReadOnly = Source_Preetabli_chk.Checked
        Date_Exig_txt.ReadOnly = Source_Preetabli_chk.Checked
        With Grd_Permanent
            .AllowUserToAddRows = Source_Preetabli_chk.Checked
            .AllowUserToDeleteRows = Source_Preetabli_chk.Checked
        End With

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Nouveau = False
        Appel_Zoom1("MS026", Identif_Transfert_Text, Me, "id_Societe=" & Societe.id_Societe)
    End Sub

    Private Sub Identif_Transfert_Text_TextChanged(sender As Object, e As EventArgs) Handles Identif_Transfert_Text.TextChanged
        If Not Nouveau Then Request()
    End Sub

    Sub Adding()
        Nouveau = False
        Reset_Form(Me, False)
        If Now.Month = 1 Then
            Annee.Value = Now.Year - 1
        Else
            Annee.Value = Now.Year
        End If
        Periode_Cbo.SelectedValue = Droite("00" & DateAdd(DateInterval.Month, -1, Now).Month, 2)
        If Num_Affilie_txt.Text.Trim = "" Then Num_Affilie_txt.Text = Societe.CNSS
        If Activite_txt.Text.Trim = "" Then Activite_txt.Text = Societe.Activite
        If Adresse_txt.Text.Trim = "" Then Adresse_txt.Text = Societe.Adresse
        If Ville_txt.Text.Trim = "" Then Ville_txt.Text = Societe.Ville
        If CP_txt.Text.Trim = "" Then CP_txt.Text = Societe.Cp
        If Agence_txt.Text.Trim = "" Then Agence_txt.Text = Societe.CNSS_Agence
        If Raison_Sociale_txt.Text.Trim = "" Then Raison_Sociale_txt.Text = Societe.Denomination
        Dat_Import_Preetabli_txt.Text = ""
        Dat_Import_Entrant_txt.Text = ""
        Dat_Import_Permanent_txt.Text = ""
        Source_Preetabli_chk.Checked = False
    End Sub
    Sub initialiserDamancom()
        Num_Affilie_txt.Text = ""
        Periode_Cbo.SelectedValue = ""
        Raison_Sociale_txt.Text = ""
        Activite_txt.Text = ""
        Adresse_txt.Text = ""
        Ville_txt.Text = ""
        CP_txt.Text = ""
        Agence_txt.Text = ""
        Lib_Agence_txt.Text = ""
        Date_Emission_txt.Text = ""
        Date_Exig_txt.Text = ""
        Dat_Import_Permanent_txt.Text = ""
        Dat_Import_Preetabli_txt.Text = ""
        Source_Preetabli_chk.Checked = False
        pbValide.Visible = False
        With Grd_Permanent
            .Rows.Clear()
        End With
        With Grd_Entrants
            .Rows.Clear()
        End With

    End Sub

    Private Sub Identif_Transfert_Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Identif_Transfert_Text.KeyPress, Num_Affilie_txt.KeyPress
        ControleSaisie(sender, e, True, True, True, False, False)
    End Sub

    Sub Deleting()
        If Identif_Transfert_Text.Text.Trim = "" Then Return
        If pbValide.Visible Then Return
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette déclaration", "DamanCom Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from Damancom_Ent where  Identif_Transfert='" & Identif_Transfert_Text.Text & "'")
        CnExecuting("delete from Damancom_Lig where  Identif_Transfert='" & Identif_Transfert_Text.Text & "'")
        Identif_Transfert_Text.Text = ""
    End Sub

    Private Sub EmisLe_lbl_Click(sender As Object, e As EventArgs) Handles EmisLe_lbl.Click
        If Source_Preetabli_chk.Checked Then Return
        Appel_Calender(Date_Emission_txt, Me)
    End Sub

    Private Sub ExigibleLe_lbl_Click(sender As Object, e As EventArgs) Handles ExigibleLe_lbl.Click
        If Source_Preetabli_chk.Checked Then Return
        Appel_Calender(Date_Exig_txt, Me)
    End Sub

    Private Sub Grd_Permanent_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_Permanent.DataError
        ShowMessageBox("Erreur au niveau de la colonne : [" & Grd_Permanent.Columns(e.ColumnIndex).HeaderText & "], ligne : " & e.RowIndex + 1 & vbCrLf & "Message de l'erreur :" & vbCrLf & e.Exception.Message, "Erreur Importation", MessageBoxButtons.OK, msgIcon.Error)
        e.Cancel = True
    End Sub

    Private Sub Agence_txt_TextChanged(sender As Object, e As EventArgs) Handles Agence_txt.TextChanged
        Lib_Agence_txt.Text = CnExecuting("select isnull((select Nom_Agence_Cnss from Param_DamanCom_Agence where Cod_Agence_Cnss='" & Agence_txt.Text & "'),'')").Fields(0).Value
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        If Source_Preetabli_chk.Checked Then Return
        Appel_Zoom1("MS011", Agence_txt, Me)
    End Sub

    Private Sub AddAgence_Click(sender As Object, e As EventArgs) Handles AddAgence_btn.Click
        Dim f As New Zoom_Cnss_Damancom_Agence
        newShowEcran(f, True)
    End Sub

    Sub Requesting()
        Try
            If Identif_Transfert_Text.Text.Trim <> "" Then
                ShowMessageBox("Veuillez choisir une nouvelle déclaration", "Erreur", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
            If Grd_Permanent.RowCount > 1 Or Grd_Entrants.RowCount > 1 Then
                If ShowMessageBox("Attention : Vous allez supprimer la déclaration actuelle." & vbCrLf & "Voulez-vous continuer.", "Attention", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then
                    Return
                End If
            End If
            If Periode_Cbo.SelectedIndex < 0 Then
                ShowMessageBox("Veuillez renseigner la période.", "Attention", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
            If CnExecuting("select count(*) from Param_Periode_Paie where id_Societe =" & Societe.id_Societe & " and '15/" & Periode_Cbo.SelectedValue & "/" & Annee.Value & "' between Dat_Deb and Dat_Fin and ISNULL(Cloture,0)=0").Fields(0).Value = 0 Then
                ShowMessageBox("Cette période est non ouverte", "Erreur", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
            If CnExecuting("select COUNT(*) from Damancom_Ent where Periode ='" & Periode_Cbo.SelectedValue & "' and Annee ='" & Annee.Value & "' and id_Societe =" & Societe.id_Societe).Fields(0).Value > 0 Then
                ShowMessageBox("Une déclaration pour la même période est déjà créée", "Erreur", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
            If Num_Affilie_txt.Text.Trim = "" Then Num_Affilie_txt.Text = Societe.CNSS
            If Activite_txt.Text.Trim = "" Then Activite_txt.Text = Societe.Activite
            If Adresse_txt.Text.Trim = "" Then Adresse_txt.Text = Societe.Adresse
            If Ville_txt.Text.Trim = "" Then Ville_txt.Text = Societe.Ville
            If CP_txt.Text.Trim = "" Then CP_txt.Text = Societe.Cp
            If Agence_txt.Text.Trim = "" Then Agence_txt.Text = Societe.CNSS_Agence
            If Raison_Sociale_txt.Text.Trim = "" Then Raison_Sociale_txt.Text = Societe.Denomination
            Dat_Import_Preetabli_txt.Text = ""
            Dat_Import_Entrant_txt.Text = ""
            Dat_Import_Permanent_txt.Text = ""
            Source_Preetabli_chk.Checked = False
            Date_Emission_txt.Text = "10/" & Periode_Cbo.SelectedValue & "/" & Annee.Value
            Date_Exig_txt.Text = "15/" & Periode_Cbo.SelectedValue & "/" & Annee.Value
            Dim TblPaie As DataTable = DATA_READER_GRD("exec Sys_Declaration " & Societe.id_Societe & ",'Damancom_Ent'," & Annee.Value & "," & Periode_Cbo.SelectedValue)
            If TblPaie.Columns.Count <= 1 Then
                ShowMessageBox("Merci de paramétrer la déclaration CNSS DamanCom d'abord.", "DamanCom", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
            Grd_Permanent.Rows.Clear()
            Grd_Entrants.Rows.Clear()
            Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, c12 As Object
            With TblPaie
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i)("Num_Assure"), "")
                    C2 = IsNull(.Rows(i)("Nom"), "")
                    C3 = IsNull(.Rows(i)("Prenom"), "")
                    C4 = FormatNumber(IsNull(.Rows(i)("N_Enfants"), 0), 0)
                    C5 = FormatNumber(IsNull(.Rows(i)("AF_A_Payer"), 0), 2)
                    C6 = FormatNumber(IsNull(.Rows(i)("AF_A_Deduire"), 0), 2)
                    C7 = FormatNumber(IsNull(.Rows(i)("AF_Net_A_Payer"), 0), 2)
                    C8 = "0,00"
                    C9 = FormatNumber(IsNull(.Rows(i)("Jours_Declares"), 0), 2)
                    C10 = FormatNumber(IsNull(.Rows(i)("Salaire_Reel"), 0), 2)
                    C11 = FormatNumber(IsNull(.Rows(i)("Salaire_Plaf"), 0), 2)
                    c12 = ""
                    Grd_Permanent.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, c12)
                Next
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Private Sub Grd_Permanent_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grd_Permanent.RowsAdded
        Annee.Enabled = (Grd_Entrants.RowCount <= 1 And Grd_Permanent.RowCount <= 1)
        Periode_Cbo.Enabled = Annee.Enabled
    End Sub

    Private Sub Grd_Permanent_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Grd_Permanent.RowsRemoved
        Annee.Enabled = (Grd_Entrants.RowCount <= 1 And Grd_Permanent.RowCount <= 1)
        Periode_Cbo.Enabled = Annee.Enabled
    End Sub

    Private Sub Grd_Entrants_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Grd_Entrants.RowsRemoved
        Annee.Enabled = (Grd_Entrants.RowCount <= 1 And Grd_Permanent.RowCount <= 1)
        Periode_Cbo.Enabled = Annee.Enabled
    End Sub

    Private Sub Grd_Entrants_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grd_Entrants.RowsAdded
        Annee.Enabled = (Grd_Entrants.RowCount <= 1 And Grd_Permanent.RowCount <= 1)
        Periode_Cbo.Enabled = Annee.Enabled
    End Sub

    Private Sub Dat_Import_Preetabli_txt_TextChanged(sender As Object, e As EventArgs) Handles Dat_Import_Preetabli_txt.TextChanged
        Request_D.Enabled = (Dat_Import_Preetabli_txt.Text = "")
    End Sub

    Private Sub pbValide_VisibleChanged(sender As Object, e As EventArgs) Handles pbValide.VisibleChanged
        If Not Cloture_D Is Nothing Then
            Cloture_D.Enabled = Not pbValide.Visible
        End If

    End Sub

    Private Sub AddAgence_btn_Load(sender As Object, e As EventArgs) Handles AddAgence_btn.Load

    End Sub
End Class