Imports System.Text.RegularExpressions
Public Class RH_Preparation_Paie_SelectionFiltree
    Friend Grd As New ud_Grd
    Friend oMnu As New ToolStripMenuItem
    Dim Formule, FormuleRegStr As New ArrayList
    Dim rgFormule As New Regex("")
    Dim rgChamps As New Regex("")
    Friend CodPlan As String = ""
    Dim TblSelect As New DataTable
    Sub Chargement()
        '    Try
        TblSelect = DATA_READER_GRD("select * from RH_Param_Plan_Paie_Filtre where id_Societe='" & Societe.id_Societe & "' and Cod_Plan_Paie='" & CodPlan & "' and Typ_Filtre='R'")
        For i = 0 To TblSelect.Rows.Count - 1
            ModeleSaisie_cbo.Items.Add(TblSelect.Rows(i)("Cod_Filtre"))
        Next
        '  Catch ex As Exception

        '   End Try

    End Sub
    Private Sub Zoom_FiltreAvance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If oMnu IsNot Nothing Then
            For Each c As ToolStripMenuItem In oMnu.DropDownItems
                If c.Checked Then
                    ModeleSaisie_cbo.Text = c.Name
                    Exit For
                End If
            Next
        End If
        Dim rgstr As String = ""
        With Grd
            For i = 0 To .ColumnCount - 1
                Dim oItm As New ListViewItem
                oItm.Text = .Columns(i).HeaderText
                oItm.Name = .Columns(i).Name
                oItm.Checked = False
                LvChamps.Items.Add(oItm)
                rgstr &= IIf(rgstr = "", "", "|") & "(\b(" & .Columns(i).Name & ")\b)"
            Next

            rgChamps = New Regex(rgstr, RegexOptions.IgnoreCase)
        End With


        rgstr = "(\b(Comme)\b)|(\b(Différent)\b)|(\b(Parmi)\b)|(\b(Pas)\b)|(\b(Ou)\b)|(\b(Et)\b)|[\=\<\>\(\)\+\-\\]|(\b(x)\b)"
        rgFormule = New Regex(rgstr, RegexOptions.IgnoreCase)
        For Each obj In btn_pnl.Controls
            If obj.GetType Is GetType(ud_button) Then
                AddHandler CType(obj, ud_button).Click, AddressOf pb_Formule
            End If
        Next

        Filtre_txt.Text = Grd.FiltreStr

    End Sub


    Private Sub Filtre_txt_TextChanged(sender As Object, e As EventArgs) Handles Filtre_txt.TextChanged
        With Filtre_txt
            Dim selPos As Integer = .SelectionStart
            .SelectionStart = 0
            .Select(1, .TextLength)
            .SelectionColor = Color.Black
            .SelectionStart = 0
            For Each c As Match In rgFormule.Matches(.Text)
                .Select(c.Index, c.Length)
                .SelectionColor = Color.Pink
            Next
            For Each c As Match In rgChamps.Matches(.Text)
                .Select(c.Index, c.Length)
                .SelectionColor = Color.Blue
            Next
            .Focus()
            .Select()
            .SelectionStart = selPos
            .SelectionLength = 0

        End With
    End Sub

    Private Sub LvChamps_MouseClick(sender As Object, e As MouseEventArgs) Handles LvChamps.MouseClick
        If LvChamps.SelectedItems.Count = 0 Then Return
        Dim itm As ListViewItem = LvChamps.SelectedItems(0)
        With Filtre_txt
            Dim SelPos As Integer = .SelectionStart
            Dim ValeurNode As String = " [" & itm.Name & "] "
            .Text = .Text.Insert(SelPos, ValeurNode)
            .Focus()
            .Focus()
            .Select()
            .SelectionStart = SelPos + ValeurNode.Length
            .SelectionLength = 0
        End With

    End Sub
    Function FilterSyntaxe(strFiltre As String) As String
        Dim rg As New Regex("")
        'Ajouter les formule autorisées
        Formule.Add("\*")
        Formule.Add("Comme")
        Formule.Add("Différent")
        Formule.Add("Parmi")
        Formule.Add("Pas")
        Formule.Add("Ou")
        Formule.Add("Et")
        Formule.Add("x")
        FormuleRegStr.Add("%")
        FormuleRegStr.Add("Like")
        FormuleRegStr.Add("Not Like")
        FormuleRegStr.Add("IN")
        FormuleRegStr.Add("Not")
        FormuleRegStr.Add("Or")
        FormuleRegStr.Add("and")
        FormuleRegStr.Add("*")
        For i = 0 To Formule.Count - 1
            rg = New Regex("(\b(" & Formule(i) & ")\b)", RegexOptions.IgnoreCase)
            strFiltre = rg.Replace(strFiltre, FormuleRegStr(i))
        Next
        Return strFiltre.Replace("""", "'")
    End Function
    Function FiltrerSelection(filterstr As String) As Boolean
        For i = 0 To Grd.ColumnCount - 1
            Grd.Columns(i).HeaderCell.Style.ForeColor = Color.White
        Next
        Grd.FiltreStr = filterstr
        '  Try
        If Grd.FiltreStr <> "" Then
            Grd.DataSource.DefaultView.RowFilter = FilterSyntaxe(filterstr)
            oMnu.Checked = True
            Dim rgstr As String = ""
            With Grd
                For i = 0 To .ColumnCount - 1
                    rgstr &= IIf(rgstr = "", "", "|") & "(\b(" & .Columns(i).Name & ")\b)"
                Next
                rgChamps = New Regex(rgstr, RegexOptions.IgnoreCase)
            End With
            For Each ct As Match In rgChamps.Matches(filterstr)
                If Grd.Columns.Contains(ct.Value) Then Grd.Columns(ct.Value).HeaderCell.Style.ForeColor = Color.Red
            Next
        Else
            Grd.DataSource.DefaultView.RowFilter = "1=1"
            oMnu.Checked = False
        End If


        Return True
        '  Catch ex As Exception
        '   ShowMessageBox(ex.Message, "Erreur Filtre", MessageBoxButtons.OK, msgIcon.Warning)
        '  Return False
        '   End Try
    End Function
    Private Sub filter_pb_Click(sender As Object, e As EventArgs) Handles Filter_pb.Click
        If FiltrerSelection(Filtre_txt.Text.Trim) Then
            Me.Close()
        End If
    End Sub
    Function NouveauModeleSaisie() As Boolean
        Dim MStr As String = InputBox("Veuillez saisir le nom de la sélection", "Ajouter une sélection")
        If (MStr.Contains("'") Or MStr.Contains(Chr(34)) Or MStr.Contains("&")) Then
            ShowMessageBox("Evitez les caractères spéciaux", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End If
        With ModeleSaisie_cbo
            For i = 0 To .Items.Count - 1
                If .Items(i).ToString.Trim = MStr.Trim Then
                    ShowMessageBox("Ce nom de sélection existe déjà", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                    Return False
                End If
            Next
            .Items.Add(MStr.Trim)
            .SelectedIndex = .Items.IndexOf(MStr.Trim)
        End With
        Return True
    End Function
    Private Sub New_pb_Click(sender As Object, e As EventArgs) Handles New_pb.Click
        NouveauModeleSaisie()
    End Sub
    Private Sub Save_pb_Click_1(sender As Object, e As EventArgs) Handles Save_pb.Click
        FiltrerSelection(Filtre_txt.Text.Trim)
        Dim Nom As String = "xd5456151535dcdscdsc44"
        With ModeleSaisie_cbo
            If .SelectedIndex >= 0 Then
                If Filtre_txt.Text.Trim <> "" Then
                    Nom = ModeleSaisie_cbo.Text
                    Dim rs As New ADODB.Recordset
                    rs.Open("select * from RH_Param_Plan_Paie_Filtre where Cod_Filtre='" & ModeleSaisie_cbo.Text.Trim.Replace("'", "''") & "'
   and id_Societe=" & Societe.id_Societe & " and Typ_Filtre='R' and Cod_Plan_Paie='" & CodPlan & "'", cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Cod_Plan_Paie").Value = CodPlan
                        rs("Cod_Filtre").Value = ModeleSaisie_cbo.Text.Trim
                    Else
                        rs.Update()
                    End If
                    rs("Typ_Filtre").Value = "R"
                    rs("Syntaxe").Value = Grd.FiltreStr
                    rs.Update()
                    rs.Close()
                Else
                    CnExecuting("delete from RH_Param_Plan_Paie_Filtre where Cod_Filtre='" & ModeleSaisie_cbo.Text.Trim.Replace("'", "''") & "'
   and id_Societe=" & Societe.id_Societe & " and Typ_Filtre='R' and Cod_Plan_Paie='" & CodPlan & "'")
                    ModeleSaisie_cbo.Items.RemoveAt(.SelectedIndex)
                End If
                Chargement()
                oMnu.DropDownItems.Clear()
                For i = 0 To TblSelect.Rows.Count - 1
                    Dim osMnu As New ToolStripMenuItem
                    With osMnu
                        .Name = TblSelect.Rows(i)("Cod_Filtre")
                        .Text = .Name
                        .Checked = (.Name = Nom)
                        .Tag = {Grd, FilterSyntaxe(IsNull(TblSelect.Rows(i)("Syntaxe"), ""))}
                        AddHandler .Click, AddressOf AppliquerLeFiltre
                    End With
                    oMnu.DropDownItems.Add(osMnu)
                Next
            End If
        End With
        Me.Close()
    End Sub
    Public Sub AppliquerLeFiltre(sender As ToolStripMenuItem, e As EventArgs)
        If sender.Checked Then
            FiltrerSelection("")
            sender.Checked = False
        Else
            For Each mn As ToolStripMenuItem In sender.Owner.Items
                mn.Checked = False
            Next
            FiltrerSelection(sender.Tag(1))
            sender.Checked = True
        End If
    End Sub
    Sub pb_Formule(sender As Object, e As EventArgs)
        With Filtre_txt
            Dim SelPos As Integer = .SelectionStart
            Dim ValeurNode As String = " " & sender.tag.trim & " "
            .Text = .Text.Insert(SelPos, ValeurNode)
            .Focus()
            .Focus()
            .Select()
            .SelectionStart = SelPos + IIf(ValeurNode.EndsWith("*'"), ValeurNode.Length - 2, IIf(ValeurNode.EndsWith("'"), ValeurNode.Length - 1, ValeurNode.Length))
            .SelectionLength = 0
        End With
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click, New_pb.Click, Filter_pb.Click
        Me.Close()
    End Sub

    Private Sub ModeleSaisie_cbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ModeleSaisie_cbo.SelectedIndexChanged
        With ModeleSaisie_cbo
            If .Items.Count = 0 Then Return
            If .SelectedIndex < 0 Then Return
            If .Text.Trim = "" Then Return
            Dim nrw() As DataRow = TblSelect.Select("Cod_Filtre='" & .Text.Trim.Replace("'", "''") & "'")
            If nrw.Length > 0 Then
                Filtre_txt.Text = IsNull(nrw(0)("Syntaxe"), "")
            End If
        End With
    End Sub
End Class