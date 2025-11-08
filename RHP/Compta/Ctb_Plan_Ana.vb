Public Class Ctb_Plan_Ana
    Dim TblGrade As New DataTable
    Friend Code As String = ""
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim New_D As ud_btn

    Sub Request()
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and id_Societe=" & Societe.id_Societe & "  and Value='" & Code & "'")
        End If
        DroitAcces(Me, DroitModify_Fiche(Cod_Axe_txt.Text, Me))
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Axe_txt.Text)
            Code = Cod_Axe_txt.Text
        End If
        Lib_Axe_txt.Text = FindLibelle("Lib_Axe", "Cod_Axe", Cod_Axe_txt.Text, "Compta_Axe_Ana")
        TblGrade = DATA_READER_GRD("select Cod_Sec_Ana as Code, Lib_Sec_Ana as Section from Compta_Plan_Ana where id_Societe=" & Societe.id_Societe & " and Cod_Axe='" & Cod_Axe_txt.Text & "' order by Code")
        With TblGrade
            .Columns("Code").ReadOnly = False
            .Columns("Section").ReadOnly = False
        End With
        Grd.DataSource = TblGrade
        Grd.Columns("Section").MinimumWidth = 350
    End Sub
    Private Sub Grd_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles Grd.CellValidating
        If e.RowIndex < 0 Then Return
        With Grd
            If e.ColumnIndex = .Columns("Code").Index Then
                If IsNull(e.FormattedValue, "") = "" And e.RowIndex < Grd.RowCount - 1 Then
                    e.Cancel = True
                End If

                Dim CodGrd As String = ""
                For i = 0 To .RowCount - 2
                    If i <> e.RowIndex Then
                        If IsNull(e.FormattedValue, "").Trim = IsNull(.Item("Code", i).Value, "").Trim Then
                            ShowMessageBox("Code déjà utilisé")
                            e.Cancel = True
                        End If
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub Grd_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles Grd.UserDeletingRow
        With Grd
            Dim CodGrd As String = IsNull(.Item("Code", e.Row.Index).Value, "").Trim
            If CodGrd <> "" Then
                If CnExecuting("Select count(*) from RH_Preparation_Paie_Analytique where id_Societe=" & Societe.id_Societe & " and Cod_Sec_Ana='" & CodGrd & "' and Cod_Axe='" & Cod_Axe_txt.Text & "'").Fields(0).Value > 0 Then
                    ShowMessageBox("Elément utilisé dans une préparation de la paie", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
                    e.Cancel = True
                    Return
                End If
            End If
        End With
    End Sub
    Sub Nouveau()
        Cod_Axe_txt.Text = ""
        Request()
        Enabling(Cod_Axe_txt, True)
        Cod_Axe_txt.Select()
    End Sub
    Function Saving() As Boolean
        If Cod_Axe_txt.Text.Trim = "" Then
            Return False
        End If
        If Lib_Axe_txt.Text.Trim = "" Then
            ShowMessageBox("Libellé vide")
            Lib_Axe_txt.Select()
            Return False
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Compta_Axe_Ana where id_Societe=" & Societe.id_Societe & " and Cod_Axe='" & Cod_Axe_txt.Text & "'", cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("id_Societe").Value = Societe.id_Societe
            rs("Cod_Axe").Value = Cod_Axe_txt.Text
        Else
            rs.Update()
        End If
        rs("Lib_Axe").Value = Lib_Axe_txt.Text
        rs.Update()
        rs.Close()

        CnExecuting("delete from Compta_Plan_Ana where id_Societe=" & Societe.id_Societe & " and Cod_Axe='" & Cod_Axe_txt.Text & "'")

        rs.Open("select * from Compta_Plan_Ana", cn, 2, 2)
        With Grd
            For i = 0 To .RowCount - 2
                If IsNull(.Item("Code", i).Value, "").Trim <> "" Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Cod_Axe").Value = Cod_Axe_txt.Text
                    rs("Cod_Sec_Ana").Value = IsNull(.Item("Code", i).Value, "").Trim
                    rs("Lib_Sec_Ana").Value = IsNull(.Item("Section", i).Value, "").Trim
                    rs.Update()
                End If
            Next
        End With
        rs.Close()
        Return True
    End Function
    Private Sub CompteGeneralLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CompteGeneralLink.LinkClicked
        Appel_Zoom1("MS107", Cod_Axe_txt, Me)
    End Sub
    Sub Deleting()
        If Cod_Axe_txt.Text <> "" Then
            If ShowMessageBox("Etes-vous sûr de vouloir supprimer l'axe :" & Cod_Axe_txt.Text & "?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
            If CnExecuting("Select count(*) from RH_Preparation_Paie_Analytique where id_Societe=" & Societe.id_Societe & " and Cod_Sec_Ana in (select Cod_Sec_Ana from Compta_Plan_Ana where Cod_Axe='" & Cod_Axe_txt.Text & "' and id_Societe='" & Societe.id_Societe & "')").Fields(0).Value > 0 Then
                ShowMessageBox("Elément utilisé dans une préparation de la paie", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            CnExecuting("delete from Compta_Axe_Ana where Cod_Axe='" & Cod_Axe_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            Reset_Form(Me)
        End If
    End Sub
    Sub Div_First()
        If Cod_Axe_txt.Text <> "" Then
            Diviseur_First("Compta_Axe_Ana", "Cod_Axe", "Cod_Axe", Cod_Axe_txt)
        End If
    End Sub
    Sub Div_Back()
        If Cod_Axe_txt.Text <> "" Then
            Diviseur_Back("Compta_Axe_Ana", "Cod_Axe", "Cod_Axe", Cod_Axe_txt)
        End If
    End Sub
    Sub Div_Next()
        If Cod_Axe_txt.Text <> "" Then
            Diviseur_Next("Compta_Axe_Ana", "Cod_Axe", "Cod_Axe", Cod_Axe_txt)
        End If
    End Sub
    Sub Div_Last()
        If Cod_Axe_txt.Text <> "" Then
            Diviseur_Last("Compta_Axe_Ana", "Cod_Axe", "Cod_Axe", Cod_Axe_txt)
        End If
    End Sub
    Private Sub Ctb_Plan_Ana_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Next_D = dictButtons("Next_D")
        Back_D = dictButtons("Back_D")
        Last_D = dictButtons("Last_D")
        First_D = dictButtons("First_D")
        New_D = dictButtons("New_D")
        Grd.ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        Request()
    End Sub
    Private Sub Cod_Axe_txt_Leave(sender As Object, e As EventArgs) Handles Cod_Axe_txt.Leave
        Dim rg As New System.Text.RegularExpressions.Regex("\W")
        If rg.IsMatch(Cod_Axe_txt.Text) And Cod_Axe_txt.Text <> "" Then
            ShowMessageBox("Evitez les caractères non alphanumériques.", "Format", MessageBoxButtons.OK, msgIcon.Error)
            Cod_Axe_txt.Select()
            Return
        End If
        Enabling(Cod_Axe_txt, False)
    End Sub

    Private Sub Cod_Axe_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Axe_txt.TextChanged
        If Not Cod_Axe_txt.ReadOnly Then Return
        Request()
    End Sub
End Class