Imports System.Data.OleDb
Public Class ud_ComboBox
    Public Event DropDownClosed As EventHandler
    Public Event SelectedIndexChanged As EventHandler
    Public Event TextContentChanged As EventHandler
    Public Shadows Property Text As String
        Get
            Return innerComboBox.Text
        End Get
        Set(value As String)
            innerComboBox.Text = value
        End Set
    End Property
    Public Property DataSource As DataTable
        Get
            Return innerComboBox.DataSource
        End Get
        Set(value As DataTable)
            innerComboBox.DataSource = value
        End Set
    End Property
    Public Property ValueMember As String
        Get
            Return innerComboBox.ValueMember
        End Get
        Set(value As String)
            innerComboBox.ValueMember = value
        End Set
    End Property
    Public Property DisplayMember As String
        Get
            Return innerComboBox.DisplayMember
        End Get
        Set(value As String)
            innerComboBox.DisplayMember = value
        End Set
    End Property
    Public Shadows Property SelectedValue As String
        Get
            Return innerComboBox.SelectedValue
        End Get
        Set(value As String)
            If value <> Nothing Then
                innerComboBox.SelectedValue = value
            Else
                innerComboBox.SelectedIndex = -1
            End If
        End Set
    End Property
    Public Shadows Property SelectedItem As String
        Get
            Return innerComboBox.SelectedItem
        End Get
        Set(value As String)
            innerComboBox.SelectedItem = value
        End Set
    End Property
    Public Shadows Property Enabled As Boolean
        Get
            Return innerComboBox.Enabled
        End Get
        Set(value As Boolean)
            innerComboBox.Enabled = value
        End Set
    End Property
    Public Shadows Property SelectedIndex As Integer
        Get
            Return innerComboBox.SelectedIndex
        End Get
        Set(value As Integer)
            If innerComboBox.DataSource Is Nothing And innerComboBox.Items.Count = 0 Then
                innerComboBox.SelectedIndex = -1
                Return
            End If
            innerComboBox.SelectedIndex = value
        End Set
    End Property
    Public Property DroppedDown As Boolean
        Get
            Return innerComboBox.DroppedDown
        End Get
        Set(value As Boolean)
            innerComboBox.DroppedDown = value
        End Set
    End Property
    Public Property Items As ComboBox.ObjectCollection
        Get
            innerComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            Return innerComboBox.Items
        End Get
        Set(value As ComboBox.ObjectCollection)
            innerComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            For Each obj As Object In value
                innerComboBox.Items.Add(obj)
            Next
        End Set
    End Property
    Private Sub ud_ComboBox_DropDowClosed(sender As Object, e As EventArgs) Handles innerComboBox.DropDownClosed
        RaiseEvent DropDownClosed(sender, e)
    End Sub
    Private Sub ud_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles innerComboBox.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub

    Sub FromSQL(sqlStr As String)
        Try
            Dim TblCombo As DataTable = DATA_READER_GRD(sqlStr)
            With Me.innerComboBox
                .DataSource = TblCombo
                .DisplayMember = TblCombo.Columns(1).Caption
                .ValueMember = TblCombo.Columns(0).Caption
                .DropDownStyle = ComboBoxStyle.DropDownList
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub fromRubrique(Optional NomControle As String = "", Optional swhere As String = "")
        Try
            Dim cn1 As New OleDb.OleDbConnection
            cn1.ConnectionString = connectionString
            Dim CMD As OleDbCommand = cn1.CreateCommand()
            NomControle = If(NomControle = "", Me.Name, NomControle)
            CMD.CommandText = "select Membre,Valeur from Param_Rubriques where Nom_Controle='" & NomControle & "' " & IIf(swhere.Trim <> "", "and " & swhere, "") & " Group by Nom_Controle,Membre,valeur,Rang  order by isnull(Rang,Membre)"
            cn1.Open()
            Dim monreader As OleDbDataReader = CMD.ExecuteReader()
            Dim dtr As New DataTable(Me.Name)
            dtr.Load(monreader)
            cn1.Close()
            With Me.innerComboBox
                .DropDownStyle = ComboBoxStyle.DropDownList
                .DataSource = dtr
                .DisplayMember = "Membre"
                .ValueMember = "Valeur"
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub innerTextBox_GotFocus(sender As Object, e As EventArgs) Handles innerComboBox.GotFocus
        If Not Enabled Then Return
        LB_lbl.BackColor = colorBase03
    End Sub
    Private Sub innerTextBox_LostFocus(sender As Object, e As EventArgs) Handles innerComboBox.LostFocus
        If Not Enabled Then Return
        LB_lbl.BackColor = colorBase01
    End Sub

    Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()
    End Sub

    Private Sub innerComboBox_TextChanged(sender As Object, e As EventArgs) Handles innerComboBox.TextChanged
        RaiseEvent TextContentChanged(sender, e)  ' Use the renamed event
    End Sub
End Class
