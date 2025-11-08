Imports System.ComponentModel
Public Class Formation_Types
    Friend Code As String = ""
    Private Sub Ctb_Compta_Axe_Ana_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If dictButtons("Save_D").Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS149", Domaine_Comepence_txt, Me)
    End Sub
    Sub chargementCombo()
        Combo_GRD(Genre_Formation)
    End Sub
    Private Sub Formation_Typ_Formation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chargementCombo()
    End Sub
    Sub Request()
        Try
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
            DroitAcces(Me, DroitModify_Fiche(Domaine_Comepence_txt.Text, Me))
            If dictButtons("Save_D").Enabled = True Then
                Check_Accessible(Me.Name, Domaine_Comepence_txt.Text)
                Code = Domaine_Comepence_txt.Text
            End If
            chargementCombo()
            Lib_Domaine_Comepence_txt.Text = FindLibelle("Lib_Domaines_Competence", "Domaines_Competence", Domaine_Comepence_txt.Text, "GPEC_Domaines_Competence")
            Dim Tbl As DataTable = DATA_READER_GRD("select * from Formation_Typ_Formation where Domaines_Competence='" & Domaine_Comepence_txt.Text & "' and id_Societe=" & Societe.id_Societe & " order by isnull(Rang,0)")
            Dim Tbl_used As DataTable = DATA_READER_GRD("select Typ_Formation from Formation_Cabinet_Domaines_Competences
                                                                where id_Societe =" & Societe.id_Societe & " and Domaines_Competence ='" & Domaine_Comepence_txt.Text & "'
                                                                union all
                                                                select Typ_Formation from Formation_Formateur_Domaines_Competences
                                                                where id_Societe =" & Societe.id_Societe & " and Domaines_Competence ='" & Domaine_Comepence_txt.Text & "'")
            Dim C1, C2, C3 As Object
            With Tbl
                Grd.Rows.Clear()
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i)("RowId"), 0)
                    C2 = IsNull(.Rows(i)("Typ_Formation"), "")
                    C3 = IsNull(.Rows(i)("Genre_Formation"), "")
                    Grd.Rows.Add(C1, C2, C3)
                    With Grd.Rows(i)
                        .ReadOnly = (Tbl_used.Select("Typ_Formation='" & C1 & "'").Length > 0)
                        If .ReadOnly Then
                            .DefaultCellStyle.ForeColor = Color.Gray
                            .DefaultCellStyle.SelectionForeColor = Color.Gray
                        End If
                    End With
                Next
            End With

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Private Sub Domaines_Competence_txt_TextChanged(sender As Object, e As EventArgs) Handles Domaine_Comepence_txt.TextChanged
        If Domaine_Comepence_txt.ReadOnly Then Request()
    End Sub

    Private Sub Grd_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles Grd.UserDeletingRow
        e.Cancel = e.Row.ReadOnly
    End Sub

    Private Sub Domaines_Competence_txt_Leave(sender As Object, e As EventArgs) Handles Domaine_Comepence_txt.Leave

        Enabling(Domaine_Comepence_txt, False)
        Request()
        Lib_Domaine_Comepence_txt.Select()
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        Enabling(Domaine_Comepence_txt, True)
        Domaine_Comepence_txt.Select()
    End Sub
    Sub Enregistrer()
        If Domaine_Comepence_txt.Text = "" Then
            ShowMessageBox("Nom du groupe vide.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Lib_Domaine_Comepence_txt.Text = "" Then
            ShowMessageBox("Renseignez le libellé du domaine de compétence.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim nb As Integer = 0
        Dim swhere As String = ""
        With Grd
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Typ_Formation.Index, i).Value, "") <> "" Then
                    nb += 1
                    If IsNull(.Item(RowId.Index, i).Value, "") <> "" Then swhere &= IIf(swhere = "", "", ",") & .Item(RowId.Index, i).Value
                End If
            Next
        End With
        If nb = 0 Then
            ShowMessageBox("Domaine de compétence vide.", "Validation", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from GPEC_Domaines_Competence where Domaines_Competence='" & Domaine_Comepence_txt.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Domaines_Competence").Value = Domaine_Comepence_txt.Text
            rs("id_Societe").Value = Societe.id_Societe
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()
        End If
        rs("Lib_Domaines_Competence").Value = Lib_Domaine_Comepence_txt.Text
        rs.Update()
        rs.Close()
        With Grd
            If swhere <> "" Then
                CnExecuting("delete from Formation_Typ_Formation where Domaines_Competence='" & Domaine_Comepence_txt.Text & "' and id_Societe=" & Societe.id_Societe & " and RowId not in (" & swhere & ")")
            End If
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Typ_Formation.Index, i).Value, "") <> "" Then
                    rs.Open("select * from Formation_Typ_Formation where Domaines_Competence='" & Domaine_Comepence_txt.Text & "' and id_Societe=" & Societe.id_Societe & " and RowId ='" & IsNull(.Item(RowId.Index, i).Value, 0) & "'")
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Domaines_Competence").Value = Domaine_Comepence_txt.Text
                        rs("id_Societe").Value = Societe.id_Societe
                    Else
                        rs.Update()
                    End If
                    If Not .Rows(i).ReadOnly Then rs("Typ_Formation").Value = IsNull(.Item(Typ_Formation.Index, i).Value, "")
                    rs("Genre_Formation").Value = IsNull(.Item(Genre_Formation.Index, i).Value, "")
                    rs("Rang").Value = i
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With
        Request()
    End Sub
    Private Sub Grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grd.DataError

    End Sub
    Sub Deleting()
        If Domaine_Comepence_txt.Text = "" Then Return
        Dim Tbl As DataTable = DATA_READER_GRD("select top 1 * from Formation_Formateur_Domaines_Competences where isnull(Domaines_Competence,'')='" & Domaine_Comepence_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count > 0 Then
            ShowMessageBox("Ce domaine de compétence est utilisé dans la fiche des Formateurs", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Tbl = DATA_READER_GRD("select top 1 * from Formation_Cabinet_Domaines_Competences where isnull(Domaines_Competence,'')='" & Domaine_Comepence_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        If Tbl.Rows.Count > 0 Then
            ShowMessageBox("Ce domaine de compétence est utilisé dans la fiche des Cabinet de formation", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim swhere As String = ""
        With Grd
            For i = 0 To .RowCount - 2
                If .Rows(i).ReadOnly Then swhere &= IIf(swhere = "", "", ",") & .Item(RowId.Index, i).Value
            Next
        End With
        If swhere <> "" Then
            ShowMessageBox("Certains types de formation de ce domaine de compétence sont utilisés.", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim domCaom = Domaine_Comepence_txt.Text
        If Diviseur_delete("GPEC_Domaines_Competence", "Domaines_Competence", "Domaines_Competence", Domaine_Comepence_txt, Me, True) Then
            CnExecuting("delete from Formation_Typ_Formation where Domaines_Competence='" & domCaom & "' and id_Societe=" & Societe.id_Societe)
        End If
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click
        If Grd.CurrentRow Is Nothing Then Return
        If Grd.CurrentRow.ReadOnly Then Return
        Dim r As Integer = Grd.CurrentRow.Index
        Grd.Rows.RemoveAt(r)
    End Sub

    Private Sub CntScripts_Opening(sender As Object, e As CancelEventArgs) Handles CntScripts.Opening
        Try
            SupprimerToolStripMenuItem.Enabled = Not Grd.Rows(Grd.CurrentCell.RowIndex).ReadOnly
        Catch ex As Exception

        End Try
    End Sub
End Class