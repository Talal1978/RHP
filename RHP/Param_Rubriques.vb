Public Class Param_Rubriques

    Private Sub Cod_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles COD.LinkClicked
        Appel_Zoom1("MS086", Nom_Controle_Text, Me)
    End Sub

    Private Sub Nom_Controle_Text_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Nom_Controle_Text.Leave
        Nom_Controle_Text.BackColor = Me.BackColor
        Nom_Controle_Text.ReadOnly = True
    End Sub

    Private Sub Nom_Controle_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nom_Controle_Text.TextChanged
        Request()
    End Sub

    Sub Request()
        Dim Cod_Sql As String
        Cod_Sql = "select * from Param_Rubriques where Nom_Controle = '" & Nom_Controle_Text.Text & "'"
        Texte_Rubrique_Text.Text = FindLibelle("Texte_Rubrique", "Nom_Controle", Nom_Controle_Text.Text, "Param_Rubriques")
        NoAddRows_chk.Checked = FindLibelle("NoAddRows", "Nom_Controle", Nom_Controle_Text.Text, "Param_Rubriques")
        Dim C1, C2, C3, C4, C5, C6 As Object
        With Grille
            .Rows.Clear()
            .AllowUserToAddRows = Not NoAddRows_chk.Checked
        End With

        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Nom_Controle"), "")
                C2 = IsNull(.Rows(i).Item("Valeur"), "").Trim.Replace("'", "").Replace(".", "").Replace(",", "")
                C3 = IsNull(.Rows(i).Item("Membre"), "")
                C4 = IsNull(.Rows(i).Item("Champs02"), "")
                C6 = IsNull(.Rows(i).Item("Rang"), "")
                C5 = IsNull(.Rows(i).Item("Typ"), "")
                Grille.Rows.Add(C2, C3, C4, C6, C5, C1)
                Grille.Rows(i).ReadOnly = (C4 = "S")
            Next
        End With
    End Sub

    Sub Saving()
        Dim rs As New ADODB.Recordset
        Dim Cod_Sql As String
        Dim swhere As String = ""
        With Grille
            For i = 0 To .RowCount - 2
                For j = i + 1 To .RowCount - 2
                    If IsNull(.Item(0, i).Value, "").Trim.Replace("'", "").Replace(".", "").Replace(",", "") = IsNull(.Item(0, j).Value, "").Trim.Replace("'", "").Replace(".", "").Replace(",", "") Then
                        ShowMessageBox("Le code : <b>" & IsNull(.Item(0, i).Value, "").Trim.Replace("'", "").Replace(".", "").Replace(",", "") & "</b> est en double")
                        .Rows(i).Selected = True
                        .Rows(j).Selected = True
                        .FirstDisplayedCell = .Item(0, i)
                        Return
                    End If
                Next
                .Item(0, i).Value = IsNull(.Item(0, i).Value, "").Trim.Replace("'", "").Replace(".", "").Replace(",", "")
            Next


            For i = 0 To .RowCount - 2
                If IsNull(.Item("Valeur", i).Value, "") <> "" Then
                    swhere = swhere & ",'" & .Item("Valeur", i).Value & "'"
                End If
            Next
            If swhere <> "" Then
                swhere = Microsoft.VisualBasic.Right(swhere, swhere.Length - 1)
                CnExecuting("Delete From Param_Rubriques where Nom_Controle='" & Nom_Controle_Text.Text & "' and Valeur not in (" & swhere & ") and Typ<>'S'")
            ElseIf .RowCount - 1 = 0 Then
                CnExecuting("Delete From Param_Rubriques where Nom_Controle='" & Nom_Controle_Text.Text & "' and Typ<>'S'")
            End If

            For i = 0 To .RowCount - 2
                If IsNull(.Item("Typ", i).Value, "U") <> "S" Then
                    Cod_Sql = "select * from Param_Rubriques where Nom_Controle='" & Nom_Controle_Text.Text & "' and rtrim(ltrim(isnull(Valeur,'')))='" & IsNull(.Item("Valeur", i).Value, "").Trim.Replace("'", "").Replace(".", "").Replace(",", "") & "'"
                    rs.Open(Cod_Sql, cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Typ").Value = "U"
                        rs("Created_By").Value = theUser.Login
                        rs("Dat_Crea").Value = Now
                    Else
                        rs.Update()
                    End If
                    rs("Nom_Controle").Value = Nom_Controle_Text.Text
                    rs("Valeur").Value = IsNull(.Item("Valeur", i).Value, "").Trim.Replace("'", "").Replace(".", "").Replace(",", "")
                    rs("Membre").Value = .Item(Membre.Index, i).Value
                    rs("Champs02").Value = .Item(Champs02.Index, i).Value
                    rs("Rang").Value = .Item(Rang.Index, i).Value
                    rs("Modified_By").Value = theUser.Login
                    rs("Dat_Modif").Value = Now
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With
        CnExecuting("update Param_Rubriques set Texte_Rubrique='" & Texte_Rubrique_Text.Text.Trim.Replace("'", "''") & "' where Nom_Controle='" & Nom_Controle_Text.Text & "'")
        MessageBoxRHP(352)
        Request()
    End Sub

    Private Sub SuppressionDesLignesSélectionnéesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MessageBoxRHP(594) = MsgBoxResult.Cancel Then Exit Sub
        With Grille
            For Each c In .SelectedRows
                If c.index < .RowCount - 1 Then
                    If .Item("Typ", c.index).Value = "S" Then
                        MessageBoxRHP(595)
                        c.selected = False
                    Else
                        CnExecuting("delete from Param_Rubriques where Nom_controle='" & Nom_Controle_Text.Text & "' and valeur='" & .Item("Valeur", c.index).Value & "'")
                        Grille.Rows.Remove(c)
                    End If
                Else
                    c.selected = False
                End If
            Next
        End With


    End Sub

    Private Sub Param_Rubriques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim menu_context_copy As New ContextMenuStrip
        Dim oMenu1, oMenu2 As New ToolStripMenuItem
        With oMenu1
            .Text = "Copier le Contenu de la liste"
            AddHandler .Click, AddressOf menu_context_grd
        End With
        With oMenu2
            .Text = "Exporter le Contenu vers Excel"
            AddHandler .Click, AddressOf ToExcel
        End With
        menu_context_copy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {oMenu1, oMenu2})
        With Grille

            .ContextMenuStrip = menu_context_copy
        End With
    End Sub

    Private Sub Adding()
        Reset_Form(Me)
        Nom_Controle_Text.ReadOnly = False
        Nom_Controle_Text.BackColor = Color.White
        Nom_Controle_Text.Select()

    End Sub
    Sub Nouveau()
        Adding()
    End Sub

    Sub Enregistrer()
        Saving()
    End Sub
End Class