Public Class Zoom_Org_Organigramme
    Friend frm As New Org_Organigramme
    Dim NivHierar As Integer = -1
    Friend ModeCreationModification As String = "C"
    Sub ChargerCombo()
        Dim TypEntite As String = ""
        Dim SqlE As String = ""
        Dim nrw() As DataRow = frm.Tbl_Org_Entite.Select("[Cod_Entite]='" & Parent_txt.Text & "'")
        If nrw.Length > 0 And Parent_txt.Text.Trim <> "" Then
            Dim vrw() As DataRow = frm.Tbl_Org_Typ_Entite.Select("[Typ_Entite]='" & nrw(0)("Typ_Entite") & "'")
            Lib_Parent_txt.Text = nrw(0)("Lib_Entite")
            NivHierar = vrw(0)("Niveau_Hierarchique")
            SqlE = "select Typ_Entite, Intitule from Org_Typ_Entite where Niveau_Hierarchique>" & NivHierar & " order by Niveau_Hierarchique"
        Else
            NivHierar = 0
            Lib_Parent_txt.Text = ""
            SqlE = "Select Typ_Entite, Intitule from Org_Typ_Entite where Niveau_Hierarchique=0"
        End If
        If Typ_Entite_cbo.SelectedIndex >= 0 Then TypEntite = Typ_Entite_cbo.SelectedValue
        Dim Tbl As DataTable = DATA_READER_GRD(SqlE)
        With Typ_Entite_cbo
            .DataSource = Tbl
            .DisplayMember = "Intitule"
            .ValueMember = "Typ_Entite"
        End With
        Typ_Entite_cbo.SelectedValue = TypEntite
    End Sub
    Private Sub Parent_txt_TextChanged(sender As Object, e As EventArgs) Handles Parent_txt.TextChanged
        Lib_Parent_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Parent_txt.Text, "Org_Entite")
        ChargerCombo()
    End Sub
    Private Sub Zoom_Add_Entite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ModeCreationModification = "C" Then
            Cod_Entite_txt.Select()
        End If
        Enabling(Cod_Entite_txt, (ModeCreationModification = "C"))
        ChargerCombo()
    End Sub
    Sub Button1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        Dim nrw As DataRow() = Nothing
        If Typ_Entite_cbo.SelectedIndex < 0 Then
            ShowMessageBox("Veuillez choisir le Type", "Type Entité", MessageBoxButtons.OK, msgIcon.Stop)
            Typ_Entite_cbo.DroppedDown = True
            Return
        End If
        If (Parent_txt.Text = "" Or Typ_Entite_cbo.SelectedValue = "DIRG") And ModeCreationModification = "C" Then
            nrw = frm.Tbl_Org_Entite.Select("Typ_Entite='DIRG'")
            If nrw.Length > 0 Then
                ShowMessageBox("Votre organisation comporte déjà une entité ayant le niveau de 'Direction Générale'", "Incohérence Entité", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
        End If
        If Check_Special_Char(Cod_Entite_txt, 0) > 0 Then
            ShowMessageBox("Evitez les caractères spéciaux", "Entité", MessageBoxButtons.OK, msgIcon.Stop)
            Cod_Entite_txt.Select()
            Return
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Org_Entite where Cod_Entite='" & Cod_Entite_txt.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("id_Societe").Value = Societe.id_Societe
            rs("Cod_Entite").Value = Cod_Entite_txt.Text
        Else
            rs.Update()
        End If
        rs("Lib_Entite").Value = Lib_Entite_txt.Text
        rs("Typ_Entite").Value = Typ_Entite_cbo.SelectedValue
        rs("Attachement_Hierarchique").Value = Parent_txt.Text
        rs("Responsable").Value = Matricule_Text.Text
        rs.Update()
        rs.Close()
        If Matricule_Text.Text <> "" Then CnExecuting("update RH_Agent set Cod_Entite='" & Cod_Entite_txt.Text & "' where Matricule='" & Matricule_Text.Text & "' and  id_Societe=" & Societe.id_Societe)
        frm.InitialisationOrg()
        frm.Interroger()
        Me.Close()
    End Sub

    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Dim nrw() As DataRow = frm.Tbl_Org_Entite.Select("[Cod_Entite]='" & Cod_Entite_txt.Text & "'")
        ChargerCombo()
        If nrw.Length > 0 Then
            Lib_Entite_txt.Text = nrw(0)("Lib_Entite")
            Parent_txt.Text = nrw(0)("Attachement_Hierarchique")
            Typ_Entite_cbo.SelectedValue = nrw(0)("Typ_Entite")
            Matricule_Text.Text = nrw(0)("Responsable")
        Else
            Lib_Entite_txt.Text = ""
            Matricule_Text.Text = ""
        End If
        nrw = frm.Tbl_Org_Entite.Select("[Attachement_Hierarchique]='" & Cod_Entite_txt.Text & "'")
        If nrw.Length > 0 Then
            Enabling(Cod_Entite_txt, False)
            '     Typ_Entite_cbo.Enabled = False
        Else
            Enabling(Cod_Entite_txt, True)
            Typ_Entite_cbo.Enabled = True
        End If
    End Sub
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS067", Matricule_Text, Me)
    End Sub

    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_Text.TextChanged
        Nom_Agent_Text.Text = FindLibelle("upper(Nom_Agent+' ' +Prenom_Agent)", "Matricule", Matricule_Text.Text, "RH_Agent")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Typ_Entite_cbo.SelectedIndex < 0 Then
            ShowMessageBox("Selectionnez le Type")
            Typ_Entite_cbo.DroppedDown = True
        End If
        Appel_Zoom1("MS010", Parent_txt, Me, " Typ_Entite in (select Typ_Entite from Org_Typ_Entite where Niveau_Hierarchique<(select Niveau_Hierarchique from Org_Typ_Entite where Typ_Entite='" & Typ_Entite_cbo.SelectedValue & "'))")
    End Sub
    Private Sub Typ_Entite_cbo_DropDownClosed(sender As Object, e As EventArgs) Handles Typ_Entite_cbo.DropDownClosed
        Dim nrw() As DataRow = frm.Tbl_Org_Entite.Select("[Cod_Entite]='" & Parent_txt.Text & "'")
        If nrw.Length > 0 Then
            Dim vrw() As DataRow = frm.Tbl_Org_Typ_Entite.Select("[Typ_Entite]='" & nrw(0)("Typ_Entite") & "'")
            If vrw.Length > 0 Then
                NivHierar = vrw(0)("Niveau_Hierarchique")
            Else
                NivHierar = 0
            End If
        Else
            NivHierar = 0
        End If
    End Sub
End Class