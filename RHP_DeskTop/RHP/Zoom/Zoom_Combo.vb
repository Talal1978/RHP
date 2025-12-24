Public Class Zoom_Combo
    Friend TypBoolean As String = "O/N"
    Friend TblList As New DataTable
    Friend TypCombo As String = "Boolean"
    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Zoom__Boolean_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TblList.Rows.Clear()
        TblList.Columns.Clear()
        oListBox.DataSource = Nothing
        If TypCombo = "Boolean" Then
            TblList.Columns.Add("Valeur")
            TblList.Columns.Add("Membre")
            Me.KeyPreview = True
            If TypBoolean = "O/N" Then
                TblList.Rows.Add("O", "Oui")
                TblList.Rows.Add("N", "Non")
            ElseIf TypBoolean = "T/F" Then
                TblList.Rows.Add("True", "True")
                TblList.Rows.Add("False", "False")
            ElseIf TypBoolean = "0/1" Then
                TblList.Rows.Add("1", "True")
                TblList.Rows.Add("0", "False")
            End If
        Else
            TblList = DATA_READER_GRD("select Membre, Valeur From Param_Rubriques WHERE Nom_Controle='" & TypCombo & "' ")
        End If
        With oListBox
            .DataSource = TblList
            .DisplayMember = "Membre"
            .ValueMember = "Valeur"
        End With

    End Sub

    Private Sub oListBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles oListBox.DoubleClick
        Select Case Zoom_Object.GetType.Name
            Case "TextBox"
                Zoom_Object.Text = ""
                Zoom_Object.Text = oListBox.SelectedValue
            Case "LinkLabel"
                Zoom_Object.Text = ""
                Zoom_Object.Text = oListBox.SelectedValue
            Case "ComboBox"
                Zoom_Object.Selectedvalue = oListBox.SelectedValue
            Case "DataGridViewTextBoxCell"
                Zoom_Object.value = oListBox.SelectedValue
        End Select
        Zoom_Text.ResetText()
        Me.Close()
    End Sub


End Class