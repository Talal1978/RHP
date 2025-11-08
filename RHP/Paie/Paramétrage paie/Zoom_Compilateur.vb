Imports System.ComponentModel
Imports System.Text.RegularExpressions
Public Class Zoom_Compilateur
    Friend frmPreparation As RH_Preparation_Paie
    Dim WithEvents Cntx As New ContextMenuStrip
    Dim Mnu As New ToolStripMenuItem
    Dim backArr As New ArrayList
    Dim currentPos As Integer = 0
    Private Sub Zoom_Calculateur_VBS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With frmPreparation
            If .PrePaie_Grd.CurrentCell IsNot Nothing Then
                .PrePaie.CalculPaie(.PrePaie_Grd.Item("Matricule", .PrePaie_Grd.CurrentRow.Index).Value, False)
                Formule_Function_Text.Text = .PrePaie_Grd.Columns(.PrePaie_Grd.CurrentCell.ColumnIndex).Name
                Compiler()
            End If
        End With

        With Mnu
            .Text = "Zoomer pour analyser"
            .Image = My.Resources.btn_analyse
            AddHandler .Click, AddressOf getDetail
        End With
        Cntx.Items.Add(Mnu)
        Formule_Function_Text.ContextMenuStrip = Cntx

    End Sub
    Private Sub Formula_txt_TextChanged(sender As Object, e As EventArgs) Handles Formule_Function_Text.TextChanged
        Resultat.Text = ""
        Dim oRw() As DataRow = Nothing
        Dim rg As New Regex("\b(\w+)\b", RegexOptions.IgnoreCase)
        With Formule_Function_Text
            Dim selpos As Integer = .SelectionStart
            For Each c As Match In rg.Matches(.Text)
                .Select(c.Index, c.Length)
                oRw = frmPreparation.PrePaie.TblFunction.Select("[Cod_Function] = '" & c.Value & "'")
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
    Private Sub Simuler_D_Click(sender As Object, e As EventArgs) Handles Simuler_pb.Click
        Compiler()
    End Sub
    Sub sendBack(itm As String)
        If backArr.Count > 0 Then
            If backArr(backArr.Count - 1) = itm Then Return
        End If
        backArr.Add(itm)
        currentPos = backArr.Count - 1
    End Sub
    Sub Compiler()
        Resultat.Text = ""
        Try
            If Formule_Function_Text.Text.Trim <> "" Then
                Dim rgg As New Regex("function\s+(\w+)\(.*\)\s*", RegexOptions.IgnoreCase)
                Dim rgFU As New Regex("(?<=\b(return)|(=>))\W*\b.+", RegexOptions.IgnoreCase)
                If rgFU.IsMatch(Formule_Function_Text.Text) Then
                    'case des FU
                    Dim rnd As New Random
                    Dim functionName = Chr(rnd.Next(65, 90)) & Chr(rnd.Next(65, 90)) & Chr(rnd.Next(65, 90)) & Chr(rnd.Next(65, 90)) & Chr(rnd.Next(65, 90)) & Chr(rnd.Next(65, 90))
                    Dim strFunction = Formule_Function_Text.Text
                    Dim mac = rgFU.Matches(Formule_Function_Text.Text)
                    strFunction = rgFU.Replace(strFunction, " SiNull(" & mac(0).Value & ";""0"" )")
                    rgFU = New Regex("return|=>", RegexOptions.IgnoreCase)
                    strFunction = rgFU.Replace(strFunction, functionName & " = ").Trim
                    strFunction = "Function " & functionName & "()" & vbCrLf & strFunction & vbCrLf & "End Function" & vbCrLf
                    strFunction = TraitementCaractere(strFunction)
                    frmPreparation.PrePaie.myVBS.ExecuteStatement(strFunction)
                    Resultat.Text = frmPreparation.PrePaie.myVBS.Eval(functionName & "()")
                ElseIf rgg.IsMatch(Formule_Function_Text.Text) Then
                    'cas des FP et FS
                    Dim match As Match = rgg.Match(Formule_Function_Text.Text)
                    Resultat.Text &= frmPreparation.PrePaie.myVBS.Eval(TraitementCaractere(match.Groups(1).Value))
                Else
                    'Default
                    Resultat.Text = frmPreparation.PrePaie.myVBS.Eval(TraitementCaractere(Formule_Function_Text.Text))
                End If
                sendBack(Formule_Function_Text.Text.Trim)
            End If
        Catch ex As Exception
            Resultat.Text = ex.Message
        End Try
    End Sub
    Sub getDetail(sender As Object, e As EventArgs)
        Dim strRub As String = IsNull(Formule_Function_Text.SelectedText, "").Trim()
        Dim oRw() As DataRow = frmPreparation.PrePaie.TblFunction.Select("[Cod_Function] = '" & strRub & "'")
        If oRw.Length > 0 Then
            sendBack(Formule_Function_Text.Text.Trim)
            Formule_Function_Text.Text = If("FU;EX;FS;EC;FP".Split(";").Contains(oRw(0)("Typ_Function")), IsNull(oRw(0)("Formule_Function"), oRw(0)("Cod_Function")), oRw(0)("Cod_Function"))
        End If
        Compiler()
    End Sub
    Private Sub Cntx_Opening(sender As Object, e As CancelEventArgs) Handles Cntx.Opening
        Dim strRub As String = IsNull(Formule_Function_Text.SelectedText, "").Trim()
        Dim oRw() As DataRow = frmPreparation.PrePaie.TblFunction.Select("[Cod_Function] = '" & strRub & "'")
        Mnu.Enabled = (oRw.Length > 0 And strRub <> "")
    End Sub

    Private Sub RubriqueAdd_D_Click(sender As Object, e As EventArgs) Handles RubriqueAdd_pb.Click
        Dim strRub As String = IsNull(Formule_Function_Text.SelectedText, "").Trim()
        Dim oRw() As DataRow = frmPreparation.PrePaie.TblFunction.Select("[Cod_Function] = '" & strRub & "'")
        If oRw.Length = 0 Then Return
        Dim f As New RH_Parametrage_Rubrique_Paie
        With f
            If "EC;CS;EV;EB;EX".Split(";").Contains(oRw(0)("Typ_Function")) Then
                .Cod_Rubrique_txt.Text = strRub
                .Cod_Rubrique_txt_Leave(Nothing, Nothing)
            ElseIf "RC".Split(";").Contains(oRw(0)("Typ_Function")) Then
                .Cod_Rubrique_txt.Text = strRub.Replace("Cumul_", "")
                .Cod_Rubrique_txt_Leave(Nothing, Nothing)
            End If
            .StartPosition = FormStartPosition.CenterScreen
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub Back_D_Click(sender As Object, e As EventArgs) Handles Back_pb.Click
        If currentPos > 0 Then
            Formule_Function_Text.Text = backArr(currentPos - 1)
            currentPos -= 1
        End If
    End Sub

    Private Sub Next_D_Click(sender As Object, e As EventArgs) Handles Next_pb.Click
        If currentPos <= backArr.Count - 2 Then
            Formule_Function_Text.Text = backArr(currentPos + 1)
            currentPos += 1
        End If
    End Sub

    Private Sub FunctionAdd_D_Click(sender As Object, e As EventArgs) Handles FunctionAdd_pb.Click
        Dim strRub As String = IsNull(Formule_Function_Text.SelectedText, "").Trim()
        Dim oRw() As DataRow = frmPreparation.PrePaie.TblFunction.Select("[Cod_Function] = '" & strRub & "'")
        If oRw.Length = 0 Then Return
        Dim f As New RH_Functions
        With f
            If "FU;FP;FS".Split(";").Contains(oRw(0)("Typ_Function")) Then
                .Cod_Function_Text.Text = strRub
                .Cod_Function_Text_Leave(Nothing, Nothing)
            End If
            .StartPosition = FormStartPosition.CenterScreen
            newShowEcran(f, True)
        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

End Class