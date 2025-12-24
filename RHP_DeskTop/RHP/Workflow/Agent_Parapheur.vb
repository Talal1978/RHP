Public Class Agent_Parapheur
#Region "Parapheur de signatures"
    Sub Request_Parapheur()
        Dim CodSql As String = "select Intitule as 'Type de documents',Valeur_Index as Référence, case when Typ_Signature ='L' then 'Lignes' else 'Entête' end 'Type de signature',
Operande_Signature as 'Opérande', t.Statut, Name_Ecran, Index_Ecran,Typ_Document from dbo.Sys_Parapheur_Signature('" & If(theUser.Typ_Role = "Agent", theUser.Matricule, theUser.Login) & "','" & Societe.id_Societe & "') s
outer apply (select Membre as Statut from Param_Rubriques where Nom_Controle = 'Statut_Signature' and Valeur=s.Statut) t
order by Intitule,Valeur_Index"
        Dim Tbl0 As DataTable = ChargerGrille(CodSql)
        With Grd_Parapheur
            If .Columns.Contains("Signature") Then .Columns.Remove(.Columns("Signature"))
            .DataSource = Tbl0
            .Columns("Name_Ecran").Visible = False
            .Columns("Index_Ecran").Visible = False
            .Columns("Typ_Document").Visible = False
            .Columns("Référence").DefaultCellStyle.BackColor = colorBase04
            Dim imgCol As New DataGridViewImageColumn
            With imgCol
                .Name = "Signature"
                .HeaderText = ""
                .MinimumWidth = 50
            End With
            .Columns.Add(imgCol)
            Grd_Parapheur.setFilter({ .Columns("Type de documents").Index, .Columns("Référence").Index, .Columns("Type de signature").Index, .Columns("Opérande").Index, .Columns("Statut").Index})
        End With
    End Sub
    Private Sub ActualiserLeParapheurToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualiserLeParapheurToolStripMenuItem.Click
        Request_Parapheur()
    End Sub
    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Grd_Parapheur.CellPainting
        ' Check if the current cell is being painted
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Set the selection style to match the cell's normal style
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor
        End If
    End Sub
    Private Sub ExporterLeContenuVersExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExporterLeContenuVersExcelToolStripMenuItem.Click
        ToExcel(sender, e)
    End Sub
    Private Sub Grd_Parapheur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Parapheur.CellDoubleClick
        If e.RowIndex < 0 Then Return
        With Grd_Parapheur
            If .Rows.Count = 0 Then Return
            If Not .Columns.Contains("Name_Ecran") Or Not .Columns.Contains("Index_Ecran") Then
                Return
            End If
            Dim frmName As String = IsNull(.Item("Name_Ecran", e.RowIndex).Value, "")
            Dim ind As String = IsNull(.Item("Index_Ecran", e.RowIndex).Value, "")
            If frmName.Trim = "" Or ind.Trim = "" Then
                Return
            End If
            Dim frm As Form = GetFormByName(frmName)
            If frm Is Nothing Then
                Return
            End If
            Dim index As Object = GetControlByName(ind, frm)
            If index Is Nothing Then
                Return
            End If
            If index.GetType() IsNot GetType(TextBox) And index.GetType() IsNot GetType(ud_TextBox) Then
                Return
            End If
            If e.ColumnIndex = .Columns("Référence").Index Then
                index.text = IsNull(Grd_Parapheur.Item("Référence", e.RowIndex).Value, "")
                newShowEcran(frm, True)
                CallByName(frm, "requestAfterSignature", CallType.Method, {})
                Request_Parapheur()
            End If
        End With
    End Sub
    Private Sub Grd_Parapheur_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Grd_Parapheur.CellFormatting
        With Grd_Parapheur
            If .Rows.Count > 0 And .Columns.Contains("Signature") Then
                If e.RowIndex >= 0 And e.ColumnIndex = .Columns("Signature").Index Then
                    e.Value = My.Resources.btn_sign
                End If
            End If
        End With
    End Sub
    Private Sub Grd_Parapheur_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Parapheur.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        With Grd_Parapheur
            If e.ColumnIndex = .Columns("Référence").Index Or e.ColumnIndex = .Columns("Signature").Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
    Private Sub Agent_Parapheur_Load(sender As Object, e As EventArgs) Handles Me.Load
        Request_Parapheur()
    End Sub
    Private Sub Grd_Parapheur_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Parapheur.CellMouseEnter
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        With Grd_Parapheur
            For Each c As DataGridViewCell In .Rows(e.RowIndex).Cells
                If c.ColumnIndex <> .Columns("Référence").Index Then
                    c.Style.BackColor = colorBase04
                End If
            Next
        End With
    End Sub

    Private Sub Grd_Parapheur_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Parapheur.CellMouseLeave
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        With Grd_Parapheur
            For Each c As DataGridViewCell In .Rows(e.RowIndex).Cells
                If c.ColumnIndex <> .Columns("Référence").Index Then
                    c.Style.BackColor = Color.White
                End If
            Next
        End With
    End Sub

    Private Sub Grd_Parapheur_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Parapheur.CellMouseClick
        If e.RowIndex < 0 Then Return
        With Grd_Parapheur
            If .Rows.Count = 0 Then Return
            If Not .Columns.Contains("Name_Ecran") Or Not .Columns.Contains("Index_Ecran") Then
                Return
            End If
            Dim frmName As String = IsNull(.Item("Name_Ecran", e.RowIndex).Value, "")
            Dim ind As String = IsNull(.Item("Index_Ecran", e.RowIndex).Value, "")
            If frmName.Trim = "" Or ind.Trim = "" Then
                Return
            End If
            Dim frm As Form = GetFormByName(frmName)
            If frm Is Nothing Then
                Return
            End If
            Dim index As Object = GetControlByName(ind, frm)
            If index Is Nothing Then
                Return
            End If
            If index.GetType() IsNot GetType(TextBox) And index.GetType() IsNot GetType(ud_TextBox) Then
                Return
            End If
            If e.ColumnIndex = .Columns("Signature").Index Then
                index.text = IsNull(Grd_Parapheur.Item("Référence", e.RowIndex).Value, "")
                Dim f As New Zoom_Signataires
                With f
                    .Indx = IsNull(Grd_Parapheur.Item("Référence", e.RowIndex).Value, "")
                    .TypDoc = IsNull(Grd_Parapheur.Item("Typ_Document", e.RowIndex).Value, "")
                    .frm = frm
                    .btn_Signature = Nothing
                    .ShowDialog()
                    Request_Parapheur()
                End With
            End If
        End With
    End Sub
#End Region
End Class