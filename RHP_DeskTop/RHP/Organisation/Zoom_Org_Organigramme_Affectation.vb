Imports DevComponents.AdvTree
Public Class Zoom_Org_Organigramme_Affectation
    Friend frm As New Org_Affectation_RH
    Dim NivHierar As Integer = -1
    Friend ModeCreationModification As String = "C"
    Friend oNode, pNode As New Node
    Sub ChargerCombo()
        Dim TypEntite As String = ""
        Dim SqlE As String = ""
        If Not pNode Is frm.nSoc Then
            Lib_Parent_txt.Text = pNode.Text
            NivHierar = pNode.Tag
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
    Private Sub Zoom_Add_Entite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If oNode Is Nothing And Not pNode Is frm.nSoc Then
            ModeCreationModification = "C"
            Cod_Entite_txt.Select()
            Parent_txt.Text = pNode.Name
            Lib_Parent_txt.Text = pNode.Text
        ElseIf Not oNode Is Nothing Then
            ModeCreationModification = "M"
            Parent_txt.Text = pNode.Name
            Lib_Parent_txt.Text = pNode.Text
            Cod_Entite_txt.Text = oNode.Name
            Lib_Entite_txt.Text = oNode.Text
            Lib_Entite_txt.Select()
        End If
        Enabling(Cod_Entite_txt, (ModeCreationModification = "C"))
        ChargerCombo()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        Dim nrw As DataRow() = Nothing
        Dim Hrw() As DataRow = frm.Tbl_RH_Agent.Select("Matricule='" & Matricule_Text.Text & "'")
        If Typ_Entite_cbo.SelectedIndex < 0 Then
            ShowMessageBox("Veuillez choisir le Type", "Type Entité", MessageBoxButtons.OK, msgIcon.Stop)
            Typ_Entite_cbo.DroppedDown = True
            Return
        End If
        If (Parent_txt.Text = "" Or pNode Is frm.nSoc) And ModeCreationModification = "C" And Typ_Entite_cbo.SelectedValue <> "DIRG" Then
            ShowMessageBox("Seul le niveau de 'Direction Générale' est autorisé à ce niveau", "Incohérence Entité", MessageBoxButtons.OK, msgIcon.Stop)
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
        If oNode Is Nothing Then
            oNode = New Node
            With oNode
                .Name = Cod_Entite_txt.Text
                .Text = Lib_Entite_txt.Text
                .Tag = If(pNode Is frm.nSoc, 0, NivHierar + Typ_Entite_cbo.SelectedIndex + 1)
                .ImageIndex = 1
                .ContextMenu = frm.oCnt_Org
                .Expanded = True
                frm.oTable.Rows.Add(.Name, .Text, frm.nbRst)
                frm.nbRst += 1
                If Matricule_Text.Text <> "" Then
                    If Hrw.Length > 0 Then
                        Dim rNode As New Node
                        With rNode
                            .Name = Matricule_Text.Text
                            .Text = Nom_Agent_Text.Text
                            .Cells.Add(New Cell)
                            .Cells(1).Text = Hrw(0)("Lib_Grade")
                            .ImageIndex = IIf(Hrw(0)("Sexe") = "F", 3, 2)
                            .Tag = "RHM"
                            .ContextMenu = frm.oCnt_RH
                            frm.oTable.Rows.Add(.Name, .Text, frm.nbRst)
                            frm.nbRst += 1
                        End With
                        .Nodes.Add(rNode)
                        frm.dicRespEntite.Add(oNode, rNode)
                    End If
                End If
            End With
            pNode.Nodes.Add(oNode)
            frm.Tbl_Org_Entite.Rows.Add(oNode.Name, oNode.Text, Typ_Entite_cbo.SelectedValue, Typ_Entite_cbo.Text, oNode.Tag, pNode.Name, Matricule_Text.Text)
        ElseIf Not oNode Is Nothing Then
            With oNode
                .Text = Lib_Entite_txt.Text
                .Tag = NivHierar + Typ_Entite_cbo.SelectedIndex + 1
                .ImageIndex = 1
                .ContextMenu = frm.oCnt_Org
                .Expanded = True
                Dim ndR() = frm.Tbl_Org_Entite.Select("Cod_Entite='" & oNode.Name & "'")
                If ndR.Length > 0 Then
                    ndR(0)("Lib_Entite") = .Text
                    ndR(0)("Typ_Entite") = Typ_Entite_cbo.SelectedValue
                    ndR(0)("Intitule") = Typ_Entite_cbo.Text
                    ndR(0)("Niveau_Hierarchique") = .Tag
                    ndR(0)("Responsable") = Matricule_Text.Text
                End If
                If frm.dicRespEntite.ContainsKey(oNode) Then
                    If Matricule_Text.Text = "" Then
                        With frm.dicRespEntite(oNode)
                            .Tag = "RHA"
                            .ImageIndex = 0
                        End With
                        frm.dicRespEntite.Remove(oNode)
                    ElseIf frm.dicRespEntite(oNode).Name <> Matricule_Text.Text Then
                        With frm.dicRespEntite(oNode)
                            .Tag = "RHA"
                            .ImageIndex = 0
                        End With
                        Dim rNode As New Node
                        If oNode.Nodes.Find(Matricule_Text.Text, False).Count > 0 Then
                            rNode = oNode.Nodes.Find(Matricule_Text.Text, False)(0)
                            With rNode
                                If Hrw.Length > 0 Then
                                    .ImageIndex = IIf(Hrw(0)("Sexe") = "F", 3, 2)
                                Else
                                    .ImageIndex = 2
                                End If
                                .Tag = "RHM"
                            End With
                            frm.dicRespEntite(oNode) = rNode
                        Else
                            If Hrw.Length > 0 Then
                                With rNode
                                    .Name = Matricule_Text.Text
                                    .Text = Nom_Agent_Text.Text
                                    .Cells.Add(New Cell)
                                    .Cells(1).Text = Hrw(0)("Lib_Grade")
                                    .ImageIndex = IIf(Hrw(0)("Sexe") = "F", 3, 2)
                                    .Tag = "RHM"
                                    .ContextMenu = frm.oCnt_RH
                                    frm.oTable.Rows.Add(.Name, .Text, frm.nbRst)
                                    frm.nbRst += 1
                                End With
                                .Nodes.Insert(0, rNode)
                                frm.dicRespEntite(oNode) = rNode
                            End If
                        End If
                    End If
                Else
                    If Matricule_Text.Text <> "" Then
                        If Hrw.Length > 0 Then
                            Dim rNode As New Node
                            With rNode
                                .Name = Matricule_Text.Text
                                .Text = Nom_Agent_Text.Text
                                .Cells.Add(New Cell)
                                .Cells(1).Text = Hrw(0)("Lib_Grade")
                                .ImageIndex = IIf(Hrw(0)("Sexe") = "F", 3, 2)
                                .Tag = "RHM"
                                .ContextMenu = frm.oCnt_RH
                                frm.oTable.Rows.Add(.Name, .Text, frm.nbRst)
                                frm.nbRst += 1
                            End With
                            .Nodes.Add(rNode)
                            frm.dicRespEntite.Add(oNode, rNode)
                        End If
                    End If
                End If
            End With
        End If
        Me.Close()
    End Sub

    Private Sub Cod_Entite_txt_Leave(sender As Object, e As EventArgs) Handles Cod_Entite_txt.Leave
        ChargerCombo()
        Dim nrw() As DataRow = frm.Tbl_Org_Entite.Select("[Cod_Entite]='" & Cod_Entite_txt.Text & "'")
        If nrw.Length > 0 And ModeCreationModification = "C" Then
            ShowMessageBox("Code déjà attribué à l'entité : " & Cod_Entite_txt.Text & " : " & nrw(0)("Lib_Entite"), "Création Entité", MessageBoxButtons.OK, msgIcon.Stop)
            Cod_Entite_txt.Select()
            Return
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
        Appel_Zoom1("MS018", Matricule_Text, Me)
    End Sub
    Private Sub Matricule_Text_TextChanged(sender As Object, e As EventArgs) Handles Matricule_Text.TextChanged
        Nom_Agent_Text.Text = FindLibelle("upper(Nom_Agent+' ' +Prenom_Agent)", "Matricule", Matricule_Text.Text, "RH_Agent")
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
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