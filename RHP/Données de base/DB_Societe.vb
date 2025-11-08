Imports System.ComponentModel
Public Class DB_Societe
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim selectedBrush As New SolidBrush(Color.Red) ' Set the color you want for the header text
        Dim tabFont As Font = TabControl1.Font
        Dim tabText As String = TabControl1.TabPages(e.Index).Text

        ' Check if the tab is selected
        If e.State = DrawItemState.Selected Then
            tabFont = New Font(tabFont, FontStyle.Bold)
        End If

        ' Draw the text
        e.Graphics.DrawString(tabText, tabFont, selectedBrush, e.Bounds.X, e.Bounds.Y)
    End Sub
    Sub chargerSociete()
        Dim CodSql As String = "select * from Param_Societe " & oFiltreSociete
        TblSociete = DATA_READER_GRD(CodSql)
        Menu_Societes.Generer_Societe()
        If CNSS_Agence.Items.Count = 0 Then CNSS_Agence.FromSQL("select Cod_Agence_Cnss, Nom_Agence_Cnss+' ('+convert(nvarchar(10),Cod_Agence_Cnss)+')' from Param_DamanCom_Agence order by Nom_Agence_Cnss")
        If Cod_TFP_cbo.Items.Count = 0 Then Cod_TFP_cbo.FromSQL("select Cod_TFP,Cod_TFP+ ' - '+ Lib_TFP from Param_IR_Taux_FP where year(getdate()) between year(Dat_Deb) and year(Dat_Fin)")
        If Cod_Commune_Combo.Items.Count = 0 Then Cod_Commune_Combo.FromSQL("select Cod_Commune, Lib_Commune from Param_IR_Commune order by Lib_Commune")
    End Sub
    Sub Enregistrer()
        Dim idSociete As Integer = IsNull(idScociete_txt.Text, "0")
        If txtDen.Text.Trim = "" Then
            ShowMessageBox("Dénomination vide", "Vérification avant enregistrement", MessageBoxButtons.OK, msgIcon.Error)
            TabControl1.SelectedIndex = 0
            txtDen.Select()
            Return
        End If
        If IsNull(idScociete_txt.Text, "0") = "0" Then
            If CnExecuting("Select count(*) from Param_Societe where ltrim(rtrim(Den))='" & txtDen.Text.Trim & "'").Fields(0).Value > 0 Then
                ShowMessageBox("La société : " & txtDen.Text.Trim & " est déjà créée", "Vérification avant enregistrement", MessageBoxButtons.OK, msgIcon.Error)
                TabControl1.SelectedIndex = 0
                txtDen.Select()
                Return
            End If
        End If
        If cboFJ.SelectedIndex = -1 Then
            ShowMessageBox("Forme juridique vide", "Vérification avant enregistrement", MessageBoxButtons.OK, msgIcon.Error)
            TabControl1.SelectedIndex = 0
            cboFJ.DroppedDown = True
            Return
        End If
        If Not IsNumeric(txtIdentFisc.Text) Then
            ShowMessageBox("Identifiant fiscal vide", "Vérification avant enregistrement", MessageBoxButtons.OK, msgIcon.Error)
            TabControl1.SelectedIndex = 0
            txtIdentFisc.Select()
            Return
        End If
        If Not IsNumeric(txtRC.Text) Then
            ShowMessageBox("RC vide", "Vérification avant enregistrement", MessageBoxButtons.OK, msgIcon.Error)
            TabControl1.SelectedIndex = 0
            txtRC.Select()
            Return
        End If
        If Not IsNumeric(txtTP.Text) Then
            ShowMessageBox("TP vide", "Vérification avant enregistrement", MessageBoxButtons.OK, msgIcon.Error)
            TabControl1.SelectedIndex = 0
            txtTP.Select()
            Return
        End If
        If Not IsNumeric(txtCNSS.Text) Then
            ShowMessageBox("CNSS vide", "Vérification avant enregistrement", MessageBoxButtons.OK, msgIcon.Error)
            TabControl1.SelectedIndex = 0
            txtCNSS.Select()
            Return
        End If
        If Not IsNumeric(Capital_txt.Text) Then
            Capital_txt.Text = 0
        End If
        If Not IsNumeric(txtICE.Text) Or txtICE.Text.Length <> 15 Then
            ShowMessageBox("ICE non conforme")
            TabControl1.SelectedIndex = 0
            txtICE.Select()
            Return
        End If
        If Cod_TFP_cbo.SelectedIndex = -1 Then
            ShowMessageBox("Taux des frais professionnels non renseigné.")
            TabControl1.SelectedIndex = 1
            Racine_text.Select()
            Return
        End If
        If Compteur_Auto.Checked Then
            If Racine_text.Text = "" Then
                ShowMessageBox("Racine non renseignée.")
                TabControl1.SelectedIndex = 1
                Racine_text.Select()
                Return
            End If
        End If
        Droit_NbSociete()
        If Droits.NbSocCree + 1 > Droits.NbMaxSoc Then
            ShowMessageBox("Votre serveur comporte plus de sociétés créées que ce qui est autorisé pour votre licence")
            Return
        End If
        Droit_NbSociete()
        If Droits.NbSocCree + 1 > Droits.NbMaxSoc Then
            ShowMessageBox("Votre serveur comporte plus de sociétés créées que ce qui est autorisé pour votre licence")
            Return
        End If
        Dim Dat As Date = Now.Date
        Dim strJour As String = IIf(Lundi_chk.Checked, 1, 0)
        strJour &= ";" & IIf(Mardi_chk.Checked, 1, 0)
        strJour &= ";" & IIf(Mercredi_chk.Checked, 1, 0)
        strJour &= ";" & IIf(Jeudi_chk.Checked, 1, 0)
        strJour &= ";" & IIf(Vendredi_chk.Checked, 1, 0)
        strJour &= ";" & IIf(Samedi_chk.Checked, 1, 0)
        strJour &= ";" & IIf(Dimanche_chk.Checked, 1, 0)
        Dim ModEdition As String = ";"
        With Grd_Soc
            For i = 0 To .RowCount - 1
                If CBool(IsNull(.Item("_chek", i).Value, False)) Then
                    ModEdition &= .Item("Cod_Report", i).Value & ";"
                End If
            Next
        End With
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM Param_Societe where id_Societe=" & idSociete, cn, 1, 3)
        If rs.EOF Then
            rs.AddNew()
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = Dat
        Else
            rs.Update()
        End If
        rs("Den").Value = txtDen.Text
        rs("FJ").Value = cboFJ.Text
        rs("Activite").Value = txtActivite.Text
        rs("IdentFisc").Value = txtIdentFisc.Text
        rs("Rc").Value = txtRC.Text
        rs("TP").Value = txtTP.Text
        rs("CNSS").Value = txtCNSS.Text
        rs("CNSS_Agence").Value = CNSS_Agence.SelectedValue
        rs("Adresse").Value = txtAdresse.Text
        rs("JourOuvrables").Value = strJour
        rs("CP").Value = txtCP.Text
        rs("ICE").Value = txtICE.Text
        rs("Ville").Value = Cod_Ville_Text.Text
        rs("Cod_Pays").Value = Cod_Pays_Text.Text
        rs("Cod_TFP").Value = Cod_TFP_cbo.SelectedValue
        rs("Cod_Commune").Value = Cod_Commune_Combo.SelectedValue
        rs("Tel").Value = txtTel.Text
        rs("Fax").Value = txtFax.Text
        rs("Email").Value = txtEmail.Text
        rs("Groupe").Value = txtGroupe.Text.Trim
        rs("Droits").Value = txtDroits.Text
        rs("Prioritie").Value = Prioritie.Value
        rs("Compteur_Auto").Value = Compteur_Auto.Checked
        rs("Sequence").Value = Sequence.Value
        rs("Racine").Value = Racine_text.Text
        rs("Masquer_Element_Paie_Agent").Value = Masquer_Element_Paie_Agent_chk.Checked
        rs("Obliger_Demande_Pret").Value = Obliger_Demande_Pret_chk.Checked
        rs("Capital").Value = Capital_txt.Text
        rs("Mod_Edition").Value = IIf(ModEdition = ";", "", ModEdition)
        rs("Logo").Value = PhotoToByte(pbLogo.Image)
        rs("Dat_Modif").Value = Dat
        rs("Modified_By").Value = theUser.Login
        rs("Mis_Sml").Value = Mis_Sml.Value
        rs.Update()
        If idSociete <= 0 Then
            idSociete = rs("id_Societe").Value
        End If
        rs.Close()

        Dim rnd As New Random
        Dim flg As Integer = rnd.Next(50, 9854)
        With Grd_JoursFeries
            For i = 0 To .RowCount - 1
                If ConvertNombre(.Item("Durée", i).Value) > 0 Then
                    rs.Open("select * from Param_Societe_Jours_Feries where convert(nvarchar(50),RowId)='" & IsNull(.Item("id", i).Value, "") & "' and id_Societe=" & idSociete, cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("id_Societe").Value = idSociete
                    Else
                        rs.Update()
                    End If
                    rs("Lib_Jour").Value = .Item("Fête", i).Value
                    rs("Dat").Value = .Item("Date", i).Value
                    rs("Duree").Value = .Item("Durée", i).Value
                    rs("Repete").Value = .Item("Répéter", i).Value
                    rs("Hijir").Value = .Item("Hijir", i).Value
                    rs("id_Jour").Value = .Item("id_Jour", i).Value
                    rs("Flg").Value = flg
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With
        CnExecuting("delete from Param_Societe_Jours_Feries where isnull(Flg,0) <> " & flg & " and id_Societe=" & idSociete)
        rs.Open("select * from Param_Compteur where id_Societe=" & idSociete & " and Fichier='Agent'", cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = Now
        Else
            rs.Update()
        End If
        rs("Fichier").Value = "Agent"
        rs("id_Societe").Value = idSociete
        rs("Taille").Value = Sequence.Value
        rs("Expression").Value = Racine_text.Text
        rs("Sequence").Value = Sequence.Value
        rs("Table_Name").Value = "RH_Agent"
        rs("Champs").Value = "Matricule"
        Dim rsTr As String = CnExecuting("select isnull((select replace(max(Matricule),'" & Racine_text.Text.Replace("'", "''") & "','') from RH_Agent where id_Societe=" & idSociete & " and Matricule like '" & Racine_text.Text & "%'),0)").Fields(0).Value
        Dim compt As Integer = 0
        If IsNumeric(rsTr) Then
            compt = CInt(rsTr)
        End If
        rs("Compte").Value = compt
        rs("Last_Code").Value = Racine_text.Text & Droite(StrDup(CInt(Sequence.Value), "0") & compt, CInt(Sequence.Value))
        rs("Modified_By").Value = theUser.Login
        rs("Dat_Modif").Value = Now
        rs.Update()
        rs.Close()
        chargerSociete()
        If idSociete <> Societe.id_Societe Then
            Societe.id_Societe = idSociete
            idScociete_txt.Text = idSociete
        End If
        OuvrirSociete(idSociete, False)
        ShowMessageBox("La société " & txtDen.Text & " est enregistrée avec succès", "Enregistrement")
        If CnExecuting("select count(*) from Rh_Agent where id_Societe = " & idSociete).Fields(0).Value = 0 Then
            Dim rsl = ShowMessageBox("Cette société ne contient pas d'agents renseignés. Voulez-vous ajouter des agents?", "Ajouter des agents", MessageBoxButtons.OKCancel, msgIcon.Information)
            If rsl = 1 Then
                Dim f As New RH_Agent
                newShowEcran(f)
            End If
        Else
            If leMenu.pnl_PersonnalContent.Controls.Contains(Menu_Operationnel) Then
                Menu_Operationnel.BringToFront()
            Else
                newShowEcran(Menu_Operationnel)
            End If
            Cursor.Current = Cursors.Default
        End If
        Me.Close()
    End Sub
    Sub frmDossiers_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        chargerSociete()
        cboFJ.Text = "Société à responsabilité limitée"
        Requesting()
        txtDen.Select()
        Dim Mnu1, Mnu2, Mnu3 As New ToolStripMenuItem
        Dim ContextMnu As New ContextMenuStrip
        With Mnu1
            .Text = "Charger une Image"
            AddHandler .Click, AddressOf ChargerImage
        End With
        With Mnu2
            .Text = "Supprimer l'Image"
            AddHandler .Click, AddressOf SupprimerImage
        End With
        With Mnu3
            .Text = "Copier l'Image"
            AddHandler .Click, AddressOf CopierImage
        End With
        With ContextMnu
            .Items.Insert(0, Mnu1)
            .Items.Insert(1, Mnu2)
            .Items.Insert(1, Mnu3)
        End With
        pbLogo.ContextMenuStrip = ContextMnu
    End Sub
    Sub ChargerImage()
        ChargerPhoto(pbLogo)
    End Sub
    Sub SupprimerImage()
        pbLogo.Image = Nothing
    End Sub
    Sub CopierImage()
        If Not pbLogo.Image Is Nothing Then Clipboard.SetImage(pbLogo.Image)
    End Sub
    Sub Requesting()
        If cboFJ.Items.Count = 0 Then cboFJ.fromRubrique("FJ")
        Dim nrw() As DataRow = TblSociete.Select("[id_Societe]=" & Societe.id_Societe)
        Dim ModEdition As String = ""
        With nrw
            If .Length > 0 Then
                idScociete_txt.Text = Societe.id_Societe
                txtDen.Text = nrw(0).Item("Den")
                CNSS_Agence.SelectedValue = IsNull(nrw(0).Item("CNSS_Agence"), "")
                cboFJ.Text = nrw(0).Item("FJ")
                txtActivite.Text = IsNull(nrw(0).Item("Activite"), "")
                txtIdentFisc.Text = IsNull(nrw(0).Item("IdentFisc"), "")
                txtAdresse.Text = IsNull(nrw(0).Item("Adresse"), "")
                txtTel.Text = IsNull(nrw(0).Item("Tel"), "")
                txtFax.Text = IsNull(nrw(0).Item("Fax"), "")
                txtCP.Text = IsNull(nrw(0).Item("CP"), "")
                Cod_Ville_Text.Text = IsNull(nrw(0).Item("Ville"), "CASAB")
                Cod_Pays_Text.Text = IsNull(nrw(0).Item("Cod_Pays"), "MAR")
                txtEmail.Text = IsNull(nrw(0).Item("Email"), "")
                txtCNSS.Text = IsNull(nrw(0).Item("CNSS"), "")
                txtTP.Text = IsNull(nrw(0).Item("TP"), "")
                txtRC.Text = IsNull(nrw(0).Item("RC"), "")
                txtICE.Text = IsNull(nrw(0).Item("ICE"), "")
                txtGroupe.Text = IsNull(nrw(0).Item("Groupe"), "")
                txtDroits.Text = IsNull(nrw(0).Item("Droits"), "")
                Prioritie.Value = IsNull(nrw(0).Item("Prioritie"), 0)
                Racine_text.Text = IsNull(nrw(0).Item("Racine"), "")
                Sequence.Value = IsNull(Math.Max(nrw(0).Item("Sequence"), 3), 20)
                Compteur_Auto.Checked = IsNull(nrw(0).Item("Compteur_Auto"), True)
                Capital_txt.Text = IsNull(nrw(0).Item("Capital"), 0)
                Masquer_Element_Paie_Agent_chk.Checked = IsNull(nrw(0).Item("Masquer_Element_Paie_Agent"), False)
                Obliger_Demande_Pret_chk.Checked = IsNull(nrw(0).Item("Obliger_Demande_Pret"), False)
                Cod_TFP_cbo.SelectedValue = IsNull(nrw(0).Item("Cod_TFP"), "TPP.25.2009")
                Cod_Commune_Combo.SelectedValue = IsNull(nrw(0).Item("Cod_Commune"), "")
                Mis_Sml.Value = IsNull(nrw(0).Item("Mis_Sml"), False)
                ModEdition = IsNull(nrw(0).Item("Mod_Edition"), "")
                Dim strJour() As String = IsNull(nrw(0)("JourOuvrables"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                If strJour.Length >= 6 Then
                    Lundi_chk.Checked = (strJour(0) = "1")
                    Mardi_chk.Checked = (strJour(1) = "1")
                    Mercredi_chk.Checked = (strJour(2) = "1")
                    Jeudi_chk.Checked = (strJour(3) = "1")
                    Vendredi_chk.Checked = (strJour(4) = "1")
                    Samedi_chk.Checked = (strJour(5) = "1")
                    Dimanche_chk.Checked = (strJour(6) = "1")
                End If
                Try
                    'Afficher la photo
                    Dim ImageData As Object = CnExecuting("select Logo from Param_Societe where id_Societe='" & Societe.id_Societe & "'").Fields(0).Value
                    pbLogo.Image = AffichagePhoto(ImageData)
                Catch ex As Exception

                End Try
            End If
        End With
        Dim Tbl As DataTable = DATA_READER_GRD("SELECT id_Jour,convert(nvarchar(10),RowId) as 'id', Lib_Jour as 'Fête', Dat as 'Date', Duree as 'Durée', Repete as 'Répéter', Hijir
FROM Param_Societe_Jours_Feries where id_Societe='" & idScociete_txt.Text & "' order by Dat")
        If Tbl.Rows.Count = 0 Then
            Tbl = DATA_READER_GRD("SELECT id_Jour,'' as 'id', Lib_Jour as 'Fête', Dat as 'Date', Duree as 'Durée', Repete as 'Répéter', Hijir
FROM Param_Jours_Feries  order by Dat")
        End If
        With Grd_JoursFeries
            .DataSource = Tbl
            .Columns("id").Visible = False
            .Columns("id_Jour").Visible = False
            Tbl.Columns("Fête").ReadOnly = False
            Tbl.Columns("Date").ReadOnly = False
            Tbl.Columns("Durée").ReadOnly = False
            Tbl.Columns("Répéter").ReadOnly = False
            Tbl.Columns("Hijir").ReadOnly = False
            .Columns("Durée").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        txtDen.Select()
        If Not ModEdition.StartsWith(";") And ModEdition <> "" Then ModEdition = ";" & ModEdition
        If Not ModEdition.EndsWith(";") And ModEdition <> "" Then ModEdition = ModEdition & ";"
        Tbl = DATA_READER_GRD("select  convert(bit,case when ';'+'" & ModEdition & "'+';' like '%;'+Cod_Report+';%' then 'true' else 'false' end) as _chek,
Cod_Report,Nom_Report
from  Param_Mod_Edition 
where isnull(parSociete,'false')='true'")
        Tbl.Columns("_chek").ReadOnly = False
        With Grd_Soc
            .DataSource = Tbl
            .Columns("Cod_Report").Visible = False
            .Columns("Nom_Report").HeaderText = "Modèle d'édition"
            .Columns("_chek").HeaderText = "+"
        End With

    End Sub
    Sub Grd_Soc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Soc.CellClick
        If e.ColumnIndex = 0 And e.RowIndex < 0 Then
            With Grd_Soc
                For i = 0 To .RowCount - 1
                    Grd_Soc.Item("_chek", i).Value = Not CBool(Grd_Soc.Item("_chek", i).Value)
                Next
            End With
        End If
    End Sub
    Sub New_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Reset_Form(Me)
        Droit_NbSociete()
        Lundi_chk.Checked = True
        Mardi_chk.Checked = True
        Mercredi_chk.Checked = True
        Jeudi_chk.Checked = True
        Vendredi_chk.Checked = True
        Samedi_chk.Checked = True
        Dimanche_chk.Checked = False
        Droit_NbSociete()
        If Droits.NbSocCree > Droits.NbMaxSoc Then
            ShowMessageBox("Attention votre serveur comporte plus de sociétés créées que ce qui est autorisé pour votre licence")
        End If
    End Sub
    Sub Deleting()
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette Société: " & txtDen.Text & "?", "RHP", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Exit Sub
        If CnExecuting("Select count(*) from RH_Preparation_Paie where id_Societe=" & idScociete_txt.Text).Fields(0).Value > 0 Then
            ShowMessageBox("Cette société contient des périodes de paie déclarées", "Vérifications", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If CnExecuting("Select count(*) from RH_Conge_Suivi where id_Societe=" & idScociete_txt.Text).Fields(0).Value > 0 Then
            ShowMessageBox("Cette société contient des congés déclarés", "Vérifications", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If CnExecuting("Select count(*) from Rh_Agent where id_Societe=" & idScociete_txt.Text).Fields(0).Value > 0 Then
            If ShowMessageBox("Cette société contient des agents renseignés, êtes-vous sûr de vouloir continuer?", "RHP", MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Exit Sub
        End If
        CnExecuting("Delete from Param_Societe where id_Societe=" & Societe.id_Societe)
        chargerSociete()
        If leMenu.pnl_PersonnalContent.Controls.Contains(Menu_Societes) Then
            Menu_Societes.BringToFront()
        Else
            newShowEcran(Menu_Societes)
        End If
        Cursor.Current = Cursors.Default
        Me.Close()
    End Sub
    Sub Close_D_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Sub btnDroits_Click(sender As Object, e As EventArgs) Handles btnDroits.Click
        Dim f As New Zoom_Hibilitation
        With f
            .otxtDroits = txtDroits
            .ShowDialog()
        End With
    End Sub

    Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click, Label9.Click
        Appel_Zoom("Groupe", "Groupe", "(select distinct ltrim(rtrim(isnull(Groupe,''))) Groupe from Param_Societe where ltrim(rtrim(isnull(Groupe,'')))<>'') f", "1=1", txtGroupe, Me)
    End Sub

    Sub SaiseNumerique(sender As Object, e As KeyPressEventArgs) Handles txtIdentFisc.KeyPress, txtRC.KeyPress, txtICE.KeyPress, txtTP.KeyPress, txtCNSS.KeyPress
        ControleSaisie(sender, e, True, True, True, False, False)
    End Sub

    Sub txtTP_Validating(sender As Object, e As CancelEventArgs) Handles txtIdentFisc.Validating, txtRC.Validating, txtICE.Validating, txtTP.Validating, txtCNSS.Validating
        If sender.text.trim <> "" Then
            If Not IsNumeric(sender.text) Then
                e.Cancel = True
            ElseIf CDbl(sender.text) <> Math.Floor(CDbl(sender.text)) Then
                sender.text = Math.Floor(CDbl(sender.text))
            End If
        End If
    End Sub
    Sub Grd_JoursFeries_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd_JoursFeries.DataError
        Try

        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try
    End Sub

    Sub Duplication()
        If idScociete_txt.Text.Trim = "" Or idScociete_txt.Text.Trim = "-1" Then
            ShowMessageBox("Société non encore créée", "Vérifications", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If CnExecuting("Select count(*) from RH_Preparation_Paie where id_Societe=" & idScociete_txt.Text).Fields(0).Value > 0 Then
            If ShowMessageBox("Cette société contient des périodes de paie déclarées" & vbCrLf & "Si vous continez vous risquez de compromettre votre paramétrage actuel." & "Etes-vous sûr de vouloir continuer?", "Attention", MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        If CnExecuting("Select count(*) from RH_Conge_Suivi where id_Societe=" & idScociete_txt.Text).Fields(0).Value > 0 Then
            If ShowMessageBox("Cette société contient des congés déclarés." & vbCrLf & "Si vous continez vous risquez de compromettre votre paramétrage actuel." & "Etes-vous sûr de vouloir continuer?", "Attention", MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        Dim err As Integer = 0
        If ShowMessageBox("Il est très recommandé de faire une sauvegarde avant de continuer." & vbCrLf & "Voulez-vous lancer la sauvegarde?", "Sauvegarde", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.OK Then
            Dim BachupSqlServer As String = FindParam("Lecteur_Digital_BackUp")
            Try
                cn.Execute("backup database  [" & DB & "] to disk='" & BachupSqlServer & "'")
            Catch ex As Exception
                err = 1
            End Try
        End If
        If err = 1 Then
            If ShowMessageBox("La sauvegarde n'a pas été effectuée." & vbCrLf & "Voulez-vous lancer la sauvegarde manuellement avant de continuer?", "Sauvegarde", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.OK Then
                Exit Sub
            End If
        End If
        Dim f As New Zoom_Societe_Duplication
        With f
            .F = Me
            .To_.Enabled = False
            .id_Societe_Des_txt.Text = idScociete_txt.Text
            .ShowDialog()
        End With
    End Sub

    Sub Capital_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Capital_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub

    Sub Capital_txt_Leave(sender As Object, e As EventArgs) Handles Capital_txt.Leave
        If Not IsNumeric(Capital_txt.Text) Then Capital_txt.Text = 0
    End Sub

    Sub Grd_Soc_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Soc.CellMouseMove
        If e.ColumnIndex < 0 Then Return
        If e.ColumnIndex = 0 And e.RowIndex < 0 Then
            Grd_Soc.Cursor = Cursors.Hand
        Else
            Grd_Soc.Cursor = Cursors.Default
        End If
    End Sub
    Sub Cod_Ville__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Ville_.LinkClicked
        Appel_Zoom("Cod_Ville", "ville", "Param_Ville", "Cod_Pays ='" & Cod_Pays_Text.Text & "'", Cod_Ville_Text, Me)
    End Sub
    Sub Cod_Ville_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Ville_Text.TextChanged
        Lib_Ville_Liv_Text.Text = FindLibelle("Ville", "Cod_Ville", Cod_Ville_Text.Text, "Param_Ville")
    End Sub
    Sub Cod_Pays__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Pays_.LinkClicked
        Appel_Zoom1("MS024", Cod_Pays_Text, Me)
    End Sub
    Sub Cod_Pays_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Pays_Text.TextChanged
        Lib_Pays_Text.Text = FindLibelle("Pays", "Cod_Pays", Cod_Pays_Text.Text, "Param_Pays")
    End Sub
End Class