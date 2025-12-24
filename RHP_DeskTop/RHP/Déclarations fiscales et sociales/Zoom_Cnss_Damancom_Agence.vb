Public Class Zoom_Cnss_Damancom_Agence
    Dim Tbl As New DataTable
    Private Sub Agence_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Agence_txt.KeyPress
        ControleSaisie(sender, e, True, True, True, False, False)
    End Sub

    Private Sub Agence_txt_TextChanged(sender As Object, e As EventArgs) Handles Agence_txt.TextChanged
        Dim rw() As DataRow = Tbl.Select("Code='" & Agence_txt.Text.Trim & "'")
        If rw.Length > 0 Then
            Lib_Agence_txt.Text = IsNull(rw(0).Item("Agence"), "")
            Adresse_txt.Text = IsNull(rw(0).Item("Adresse"), "")
        Else
            Lib_Agence_txt.Text = ""
            Adresse_txt.Text = ""
        End If
    End Sub

    Private Sub Zoom_Cnss_Damancom_Agence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateGrd()
    End Sub
    Sub UpdateGrd()
        Tbl = DATA_READER_GRD("SELECT Cod_Agence_Cnss as Code, Nom_Agence_Cnss as Agence, Adresse FROM Param_DamanCom_Agence order by Cod_Agence_Cnss")
        With Grd
            .DataSource = Tbl
            .ContextMenuStrip = AddContextMenu(False, True, False, False, False, False, False, False)
            Grd.setFilter({0, 1, 2})
        End With
    End Sub

    Sub Deleting()
        If Agence_txt.Text.Trim = "" Then Return
        If ShowMessageBox("Etes vous sûr de vouloir supprimer cette agence?", "Damancom : Suppression Agence", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        Dim rw() As DataRow = Tbl.Select("Code='" & Agence_txt.Text.Trim & "'")
        If rw.Length = 0 Then
            Agence_txt.Text = ""
            Return
        End If
        If CnExecuting("Select count(*) from Damancom_Ent where Agence='" & Agence_txt.Text.Trim & "'").Fields(0).Value > 0 Then
            ShowMessageBox("Cette agence est utilisée dans une déclaration", "Damancom : Suppression Agence", MessageBoxButtons.OKCancel, msgIcon.Error)
            Return
        End If
        CnExecuting("delete from  Param_DamanCom_Agence where Cod_Agence_Cnss='" & Agence_txt.Text.Trim & "'")
        Agence_txt.Text = ""
        UpdateGrd()
    End Sub
    Sub Saving()
        If Agence_txt.Text.Trim = "" Then Return
        Dim rs As New ADODB.Recordset
        rs.Open("select * from  Param_DamanCom_Agence where Cod_Agence_Cnss='" & Agence_txt.Text.Trim & "'", cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Cod_Agence_Cnss").Value = Agence_txt.Text.Trim
        Else
            rs.Update()
        End If
        rs("Nom_Agence_Cnss").Value = Lib_Agence_txt.Text
        rs("Adresse").Value = Adresse_txt.Text
        rs.Update()
        rs.Close()
        Agence_txt.Text = ""
        UpdateGrd()
    End Sub

    Private Sub Grd_DoubleClick(sender As Object, e As EventArgs) Handles Grd.DoubleClick
        If Grd.SelectedCells.Count = 0 Then Return
        Dim r As Integer = Grd.SelectedCells(0).RowIndex
        If r < 0 Then Return
        Agence_txt.Text = IsNull(Grd.Item("Code", r).Value, "")
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Enter
                Saving()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Sub Nouveau()
        Agence_txt.Text = ""
        UpdateGrd()
        Agence_txt.Select()
    End Sub
End Class