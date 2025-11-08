Imports System.Data.OleDb

Module Module_AutoCompeleTextBox
    Friend MyConList As New ListBox
    Dim dict As New Dictionary(Of Object, Dictionary(Of String, Object))
    Sub AutoComplete(ByVal CodSql As String, ByVal MyTextBox As Object, ByVal MyForm As Form, Optional Conn As String = "", Optional Col() As Integer = Nothing)
        If Conn = "" Then Conn = connectionString
        If dict.Count = 0 Then
            With MyConList
                AddHandler .DoubleClick, AddressOf ValueChoosing
                AddHandler .KeyUp, AddressOf MyConListEnterChoosing
            End With
        End If
        If Not dict.ContainsKey(MyTextBox) Then
            With MyTextBox
                Select Case MyTextBox.GetType
                    Case GetType(TextBox)
                        With CType(MyTextBox, TextBox)
                            AddHandler .TextChanged, AddressOf ValueChanged
                            AddHandler .KeyUp, AddressOf UpDown
                            AddHandler .Leave, AddressOf Leaving
                        End With
                    Case GetType(DataGridView)
                        With CType(MyTextBox, DataGridView)
                            AddHandler .EditingControlShowing, AddressOf DataValueChanged
                            AddHandler .KeyUp, AddressOf UpDown
                        End With
                    Case GetType(ud_Grd)
                        With CType(MyTextBox, ud_Grd)
                            AddHandler .EditingControlShowing, AddressOf DataValueChanged
                            AddHandler .KeyUp, AddressOf UpDown

                        End With
                End Select
            End With
            Dim sousDict As New Dictionary(Of String, Object)
            sousDict.Add("Data", MyConnTbl_Linked(CodSql, Conn))
            sousDict.Add("Conn", Conn)
            sousDict.Add("Form", MyForm)
            sousDict.Add("Colonnes", Col)
            dict.Add(MyTextBox, sousDict)
        Else
            dict(MyTextBox)("Data") = MyConnTbl_Linked(CodSql, Conn)
        End If
    End Sub
    Sub DataValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim col() As Integer = dict(sender)("Colonnes")
        If col.Count > 0 Then
            With sender
                If col.Contains(.CurrentCell.ColumnIndex) Then
                    AddHandler e.Control.KeyUp, AddressOf ValueChanged
                    AddHandler e.Control.Leave, AddressOf Leaving
                Else
                    RemoveHandler e.Control.KeyUp, AddressOf ValueChanged
                    RemoveHandler e.Control.KeyUp, AddressOf ValueChanged
                    RemoveHandler e.Control.Leave, AddressOf Leaving
                    RemoveHandler e.Control.Leave, AddressOf Leaving
                End If
            End With
        End If

    End Sub
    Sub ValueChanged(sender, e)
        Try
            Dim obj, sobj As Object
            Dim oWidth As Integer = 50
            Select Case sender.GetType
                Case GetType(DataGridViewTextBoxEditingControl)
                    obj = CType(sender, DataGridViewTextBoxEditingControl).EditingControlDataGridView
                    sobj = obj.currentcell
                    oWidth = obj.columns(obj.currentcell.columnindex).width
                Case Else
                    obj = sender
                    sobj = sender
                    oWidth = sender.width
            End Select
            Dim MaForm As Form = dict(obj)("Form")
            Dim MyConnTbl As DataTable = CType(dict(obj)("Data"), DataTable).Copy
            Dim Valeur As String = ""
            Select Case sobj.GetType
                Case GetType(TextBox)
                    Valeur = sobj.Text
                Case GetType(DataGridViewCell), GetType(DataGridViewTextBoxCell)
                    obj.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    Valeur = CType(sobj, DataGridViewCell).EditedFormattedValue
            End Select
            Valeur = IsNull(Valeur, "")
            Dim MyListCon As DataView = MyConnTbl.DefaultView
            Dim ColName As String = MyConnTbl.Columns(0).ColumnName
            MyListCon.RowFilter = String.Format("[{0}] like '%" & Valeur & "%'", ColName)
            With MyConList
                .DataSource = MyListCon.Table
                .ValueMember = ColName
                .DisplayMember = ColName
                .Width = oWidth
                .Tag = obj
                If MyListCon.Table.Rows.Count = 0 Then
                    MaForm.Controls.Remove(MyConList)
                Else
                    MaForm.Controls.Add(MyConList)
                    .BringToFront()
                End If
                .Location = getPositionToScreen(sobj, MaForm)
            End With
        Catch ex As Exception

        End Try

    End Sub
    Sub MyConListEnterChoosing(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            ValueChoosing(sender, e)
        End If

    End Sub

    Sub UpDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Up Or e.KeyData = Keys.Down Then
            MyConList.Select()
        End If
    End Sub


    Function MyConnTbl_Linked(ByVal Cod_Sql As String, ByVal Conn As String)
        Try
            Dim cn1 As New OleDb.OleDbConnection
            cn1.ConnectionString = Conn
            Dim CMD As OleDbCommand = cn1.CreateCommand()
            CMD.CommandText = Cod_Sql
            cn1.Open()
            Dim monreader As OleDbDataReader = CMD.ExecuteReader()
            Dim dtr As New DataTable("Table")
            dtr.Load(monreader)
            Return dtr
            cn1.Close()
        Catch ex As Exception
            ErrorMsg(ex)
            Return Nothing
        End Try
    End Function
    Sub ValueChoosing(sender, e)
        Try
            Dim maForm As New Form
            Select Case sender.tag.GetType
                Case GetType(TextBox)
                    sender.tag.Text = MyConList.Text
                    maForm = dict(sender.tag)("Form")
                Case GetType(DataGridView), GetType(ud_Grd)
                    maForm = dict(sender.tag)("Form")
                    sender.tag.currentcell.value = MyConList.Text
            End Select
            maForm.Controls.Remove(MyConList)
        Catch ex As Exception

        End Try

    End Sub
    Sub Leaving(sender, e)
        Try
            If MyConList.Focused = False Then
                Dim maForm As New Form
                Select Case sender.GetType
                    Case GetType(DataGridViewTextBoxEditingControl)
                        Dim obj As DataGridView = CType(sender, DataGridViewTextBoxEditingControl).EditingControlDataGridView
                        maForm = dict(obj)("Form")
                    Case Else
                        maForm = dict(sender)("Form")
                End Select
                maForm.Controls.Remove(MyConList)
                MyConList.FindForm()
            End If
        Catch ex As Exception

        End Try

    End Sub
End Module
