Imports System.Text.RegularExpressions
Public Class ud_9421
    Dim ToolTip1 As New ToolTip
    Friend frm_declaration As New RH_Parametrage_Declarations_Fiscales_Sociales
    Public Shadows Property Text As String
        Get
            Return lbl.Text
        End Get
        Set(value As String)
            lbl.Text = value
            lbl.Refresh()
            ToolTip1.SetToolTip(lbl, value)
        End Set
    End Property
    Private Sub Formule_Function_Text_TextChanged(sender As Object, e As EventArgs) Handles Formule_Function_Text.TextChanged
        MiseEnforme()
    End Sub
    Sub MiseEnforme()
        Dim oRw() As DataRow = Nothing
        Dim rg As New Regex("\b(\w+)\b", RegexOptions.IgnoreCase)
        With Formule_Function_Text
            Dim selpos As Integer = .SelectionStart
            For Each c As Match In rg.Matches(.Text)
                .Select(c.Index, c.Length)
                oRw = frm_declaration.TblFunction.Select("[Cod_Function] = '" & c.Value & "'")
                If oRw.Length > 0 Then
                    .SelectionColor = getFunctionColor(oRw(0).Item("Typ_Function"))
                Else
                    .SelectionColor = Color.Black
                End If
            Next
            .SelectionStart = selpos
            .SelectionLength = 0
        End With
    End Sub
    Function VerifierFormule() As Boolean
        If Formule_Function_Text.Text.Trim = "" Then Return False
        Dim rg As New Regex(sql_injection, RegexOptions.IgnoreCase)
        If rg.IsMatch(Formule_Function_Text.Text.Trim) Then
            ShowMessageBox("Votre expression contient des expressions intérdites", "Injection", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End If

        Dim strFormula As String = IsNull(Aggregation_cbo.SelectedValue, "sum") & "(Valeur)"
        rg = New Regex("\b(\w+)\b", RegexOptions.IgnoreCase)
        Dim tblStr As String = ""
        Dim outerstr As String = ""
        Dim swhere As String = ""
        Dim nb As Integer = 0
        Dim lst As New ArrayList
        For Each c As Match In rg.Matches(Formule_Function_Text.Text.Trim)
            If frm_declaration.TblFunction.Select("[Cod_Function] = '" & c.Value & "'").Length > 0 And Not lst.Contains(c.Value) Then
                tblStr = $"(Select {strFormula} As [{c.Value}] from  RH_Preparation_Paie_Detail where id_Societe={Societe.id_Societe} and Annee_Paie={Now.Year} and Cod_Rubrique='{c.Value}') r" & nb
                outerstr &= IIf(outerstr = "", tblStr, $",{tblStr}")
                nb += 1
                lst.Add(c.Value)
            End If
        Next
        If outerstr = "" Then Return False
        outerstr = $"select {Formule_Function_Text.Text.Trim} from (select * from {outerstr})f"
        Try
            CnExecuting(outerstr)
            Return True
        Catch ex As Exception
            MsgBox(outerstr)
            Return False
        End Try
        Return True
    End Function
    Public Property Valeur As String
        Get
            Return Formule_Function_Text.Text
        End Get
        Set(value As String)
            Formule_Function_Text.Text = value
        End Set
    End Property

    Private Sub ChargerLesRubriquesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChargerLesRubriquesToolStripMenuItem.Click
        AddElementPaie("MS007", "Cod_Function")
    End Sub
    Sub AddElementPaie(numZoom As String, elementPaie As String)
        Dim elePaie As String = elementPaie & $" in (select value from String_Split( (select String_Agg(Element_Paie,';') from RH_Param_Plan_Paie where id_Societe={Societe.id_Societe}),';'))"
        Appel_Zoom1(numZoom, Cod_Rubrique_txt, Me.FindForm, elePaie)
        With Formule_Function_Text
            .Select()
            Dim SelPos As Integer = Formule_Function_Text.SelectionStart
            .Text = Formule_Function_Text.Text.Insert(SelPos, " " & Cod_Rubrique_txt.Text & " ")
            .Select()
            .SelectionStart = SelPos + (" " & Cod_Rubrique_txt.Text & " ").Length
        End With
        Cod_Rubrique_txt.ResetText()
    End Sub
    Private Sub ud_9421_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Aggregation_cbo.Items.Count = 0 Then
            Aggregation_cbo.fromRubrique("Aggregation")
            Aggregation_cbo.SelectedIndex = 0
        End If
    End Sub
    Public Property Aggregation As String
        Get
            Return If(Aggregation_cbo.SelectedIndex = -1, "sum", Aggregation_cbo.SelectedValue)
        End Get
        Set(value As String)
            Aggregation_cbo.SelectedValue = value
        End Set
    End Property
End Class
