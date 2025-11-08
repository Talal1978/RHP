Public Class Zoom_Societe_Duplication
    Friend F As New DB_Societe
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        If id_Societe_Des_txt.Text.Trim = "" Then
            ShowMessageBox("Société de destination vide", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If id_Societe_Org_txt.Text.Trim = "" Then
            ShowMessageBox("Société source vide", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Cursor = Cursors.WaitCursor
        If chk_1.Checked Then If Not Rubrique() Then Return
        If chk_2.Checked Then If Not Plan() Then Return
        If chk_3.Checked Then If Not Journaux() Then Return
        If chk_4.Checked Then If Not declarations() Then Return
        If chk_10.Checked Then joursferies()
        If chk_11.Checked Then plancompta()
        If chk_12.Checked Then Mod_Edition()
        If chk_5.Checked Then entites()
        If chk_6.Checked Then grades()
        If chk_7.Checked Then fonctions()
        Cursor = Cursors.Default
        F.chargerSociete()
        F.Requesting()

    End Sub
    Function Journaux() As Boolean
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'Journaux'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text
        Try
            CnExecuting(sqlstr)
            pb_3.Image = My.Resources.success
            Return True
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_3.Image = My.Resources.erreur
            pb_3.Tag = ex.Message
            otl.SetToolTip(pb_3, ex.Message)
            Cursor = Cursors.Default
            Return False
        End Try
    End Function
    Function Rubrique() As Boolean
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'Rubrique'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text
        Try
            CnExecuting(sqlstr)
            pb_1.Image = My.Resources.success
            Return True
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_1.Image = My.Resources.erreur
            pb_1.Tag = ex.Message
            otl.SetToolTip(pb_1, ex.Message)
            Cursor = Cursors.Default
            Return False
        End Try
    End Function
    Function Plan() As Boolean
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'Plan'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text
        Try
            CnExecuting(sqlstr)
            pb_2.Image = My.Resources.success
            Return True
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_2.Image = My.Resources.erreur
            pb_2.Tag = ex.Message
            otl.SetToolTip(pb_2, ex.Message)
            Cursor = Cursors.Default
            Return False
        End Try
    End Function
    Function declarations()
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'declarations'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text

        Try
            CnExecuting(sqlstr)
            pb_4.Image = My.Resources.success
            Return True
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_4.Image = My.Resources.erreur
            pb_4.Tag = ex.Message
            otl.SetToolTip(pb_4, ex.Message)
            Cursor = Cursors.Default
            Return False
        End Try
    End Function
    Sub plancompta()
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'plancompta'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text

        Try
            CnExecuting(sqlstr)
            pb_11.Image = My.Resources.success
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_11.Image = My.Resources.erreur
            pb_11.Tag = ex.Message
            Cursor = Cursors.Default
            otl.SetToolTip(pb_11, ex.Message)
        End Try
    End Sub
    Sub joursferies()
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'joursferies'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text
        Try
            CnExecuting(sqlstr)
            pb_10.Image = My.Resources.success
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_10.Image = My.Resources.erreur
            pb_10.Tag = ex.Message
            Cursor = Cursors.Default
            otl.SetToolTip(pb_10, ex.Message)
        End Try
    End Sub
    Sub Mod_Edition()
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'Mod_Edition'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text
        Try
            CnExecuting(sqlstr)
            pb_12.Image = My.Resources.success
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_12.Image = My.Resources.erreur
            pb_12.Tag = ex.Message
            Cursor = Cursors.Default
            otl.SetToolTip(pb_12, ex.Message)
        End Try
    End Sub
    Sub entites()
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'entites'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text
        Try
            CnExecuting(sqlstr)
            pb_5.Image = My.Resources.success
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_5.Image = My.Resources.erreur
            pb_5.Tag = ex.Message
            Cursor = Cursors.Default
            otl.SetToolTip(pb_5, ex.Message)
        End Try
    End Sub
    Sub grades()
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'grades'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text

        Try
            CnExecuting(sqlstr)
            pb_6.Image = My.Resources.success
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_6.Image = My.Resources.erreur
            pb_6.Tag = ex.Message
            otl.SetToolTip(pb_6, ex.Message)
            Cursor = Cursors.Default
        End Try
    End Sub
    Sub fonctions()
        Dim sqlstr As String = "exec Sys_Societe_Duplicate 'fonctions'," & id_Societe_Des_txt.Text & "," & id_Societe_Org_txt.Text

        Try
            CnExecuting(sqlstr)
            pb_7.Image = My.Resources.success
        Catch ex As Exception
            Dim otl As New ToolTip
            pb_7.Image = My.Resources.erreur
            pb_7.Tag = ex.Message
            otl.SetToolTip(pb_7, ex.Message)
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Cod_Plan_Paie__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Plan_Paie_.LinkClicked
        Appel_Zoom1("MS014", id_Societe_Org_txt, Me, "id_Societe<>" & IsNull(id_Societe_Des_txt.Text, -9999))
    End Sub

    Private Sub Id_Societe_Org_txt_TextChanged(sender As Object, e As EventArgs) Handles id_Societe_Org_txt.TextChanged
        Lib_Societe_Org_txt.Text = FindLibelle("Den", "id_Societe", id_Societe_Org_txt.Text, "Param_Societe")
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles To_.LinkClicked
        Appel_Zoom1("MS014", id_Societe_Des_txt, Me)
    End Sub
    Private Sub Id_Societe_Des_txt_TextChanged(sender As Object, e As EventArgs) Handles id_Societe_Des_txt.TextChanged
        Lib_Societe_Des_txt.Text = FindLibelle("Den", "id_Societe", id_Societe_Des_txt.Text, "Param_Societe")
    End Sub

    Private Sub Chk_2_CheckedChanged(sender As Object, e As EventArgs) Handles chk_2.CheckedChanged
        If chk_2.Checked Then
            If Not chk_1.Checked Then chk_1.Checked = True
        Else
            If chk_4.Checked Then chk_4.Checked = False
        End If
    End Sub

    Private Sub Chk_4_CheckedChanged(sender As Object, e As EventArgs) Handles chk_4.CheckedChanged
        If chk_4.Checked Then
            If Not chk_2.Checked Then chk_2.Checked = True
            If Not chk_1.Checked Then chk_1.Checked = True
        End If
    End Sub

    Private Sub Chk_1_CheckedChanged(sender As Object, e As EventArgs) Handles chk_1.CheckedChanged
        If Not chk_1.Checked Then
            If chk_2.Checked Then chk_2.Checked = False
            If chk_4.Checked Then chk_4.Checked = False
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub

    Private Sub Zoom_Societe_Duplication_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        F.chargerSociete()
        F.Requesting()
    End Sub
End Class