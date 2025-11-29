Public Class Mailing_List
    Private Sub Cod_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles COD.LinkClicked
        Appel_Zoom1("MS104", Cod_list_Text, Me)
    End Sub

    Private Sub Cod_List_Text_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cod_list_Text.Leave
        Cod_list_Text.BackColor = Me.BackColor
        Cod_list_Text.ReadOnly = True
    End Sub

    Private Sub Cod_List_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_list_Text.TextChanged
        Request()
    End Sub

    Sub Request()
        Dim ocheck As String = IIf(Cod_list_Text.Text.Trim = "", "convert(bit,1)", "convert(bit,case when Liste like '%," & Cod_list_Text.Text & ",%' or Liste like '%," & Cod_list_Text.Text & "' or Liste like '" & Cod_list_Text.Text & ",%' then 1 else 0 end)")
        Dim swhere As String = ""
        Dim Cod_Sql As String = ""
        Lib_List_Text.Text = FindLibelle("Lib_List", "Cod_List", Cod_list_Text.Text, "Mailing_List")
        Select Case Cod_list_Text.Text
            Case "1"
                swhere = " where isnull(Typ_Tiers,'')='Clt' "
            Case "2"
                swhere = " where isnull(Typ_Tiers,'')='Fou' "
            Case "3"
                swhere = " where isnull(Typ_Tiers,'') in ('Clt','Fou') "
        End Select
        Cod_Sql = "select " & ocheck & " as 'Check',
        Civilite as Civilité, Nom, Prenom as 'Prénom',Email, isnull(Membre,'') as 'Type Tiers', 
        isnull(Cod_Tiers,'') as Code, isnull(Nom_Tiers,'') as Tiers, isnull(Fonction,'') as Fonction,id_Destinataire
        from Mailing_Destinataire d
        outer apply (select Membre from Param_Rubriques where Nom_Controle like 'Typ_Tiers' and Valeur=isnull(Typ_Tiers,''))c
        " & swhere & " 
        order by [Check] desc, isnull(Nom_Tiers,''), Nom, Prenom"
        Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
        With Grd_Destinataire
            .DataSource = Tbl
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Tbl.Columns("Check").ReadOnly = False
            .Columns("id_Destinataire").Visible = False
            .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
            Grd_Destinataire.setFilter({ .Columns("Civilité").Index, .Columns("Nom").Index, .Columns("Prénom").Index, .Columns("Email").Index, .Columns("Type Tiers").Index, .Columns("Tiers").Index, .Columns("Code").Index})
        End With
    End Sub
    Private Sub Saving()
        If Cod_list_Text.Text = "0" Then
            ShowMessageBox("La liste globale n'est pas modifiable", "Liste globale", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Mailing_List where Cod_List='" & IsNull(Cod_list_Text.Text, -99) & "'", cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
        Else
            rs.Update()
        End If
        rs("Lib_List").Value = Lib_List_Text.Text
        rs.Update()
        rs.Close()
        Dim CodList As String = Cod_list_Text.Text.Trim
        If CodList = "" Then
            CodList = IsNull(CnExecuting("select max(Cod_List) From Mailing_List where isnull(Lib_List,'')='" & Lib_List_Text.Text & "'").Fields(0).Value, "")
        Else
            CnExecuting("update Mailing_Destinataire set Liste=replace(replace(Liste,'," & CodList & ",',''),',,',',')")
        End If

        With Grd_Destinataire
            .EndEdit()
            For i = 0 To .RowCount - 1
                If CBool(.Item("Check", i).Value) Then
                    CnExecuting("update Mailing_Destinataire set Liste=isnull(Liste,'0')+case when right(liste,1)=',' then '' else ',' end+'" & CodList & ",' where id_Destinataire='" & .Item("id_Destinataire", i).Value & "'")
                End If
            Next
        End With
        MessageBoxRHP(352)
        Cod_list_Text.Text = CodList
        Request()
    End Sub
    Private Sub Adding()
        Reset_Form(Me)
        Request()
        Lib_List_Text.Text = ""
        Lib_List_Text.Select()
    End Sub
    Sub Nouveau()
        Adding()
    End Sub
    Sub Enregistrer()
        Saving()
    End Sub
    Private Sub Grd_Destinataire_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Destinataire.CellClick
        With Grd_Destinataire
            If .DataSource Is Nothing Then Return
            Dim r As Integer = e.RowIndex
            If r < 0 Then Return
            If .RowCount = 0 Then Return
            If e.ColumnIndex = .Columns("Check").Index Then
                .Item("Check", r).Value = Not CBool(.Item("Check", r).Value)
            End If
        End With
    End Sub
    Sub SelectTout()
        With Grd_Destinataire
            If .DataSource Is Nothing Then Return
            If .RowCount = 0 Then Return
            For i = 0 To .RowCount - 1
                .Item("Check", i).Value = Not CBool(.Item("Check", i).Value)
            Next
        End With
    End Sub

    Sub Deleting()
        If Cod_list_Text.Text.Trim = "" Then Return
        If Cod_list_Text.Text = "0" Or Cod_list_Text.Text = "1" Or Cod_list_Text.Text = "3" Or Cod_list_Text.Text = "2" Then
            ShowMessageBox("Les listes systèmes ne peuvent pas êtres supprimées", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer la liste en cours?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        Dim CodList As String = Cod_list_Text.Text.Trim
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Mailing where Mailing_List='" & CodList & "'")
        If Tbl.Rows.Count > 0 Then
            ShowMessageBox("cette liste est utilisée dans une compagne : " & Tbl.Rows(0)("Cod_Mailing"), "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        CnExecuting("delete from  Mailing_List where Cod_List='" & CodList & "'")
        CnExecuting("update Mailing_Destinataire set Liste=replace(Liste,'," & CodList & ",','')")
        Adding()
    End Sub

End Class