Imports System.Text.RegularExpressions
Public Class Param_Modele_Edition_Saisi
    Dim Tbl As New DataTable
    Sub Report_Generator(ByVal ReportName As String, ByVal ReportText As String)
        If Not EstModEditionAutorisePourLaSocieteEncours(ReportName) Then
            ShowMessageBox("Ce modèle d'édition n'est pas paramétré pour cette société (cf. Fiche société)", "Impression", MessageBoxButtons.OK, msgIcon.Stop)
            Me.Close()
            Return
        End If
        Cod_Report_txt.Text = ReportName
        Nom_Report_txt.Text = ReportText
        Dim Cod_Sql As String = "Select Critere,Lib_Critere,Fonction_Critere,Default_Value from Param_Mod_Edition_Criteres where Cod_Report='" & ReportName & "' order by rang"
        Dim C1, C2, C3, C4 As Object
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(Tbl.Rows(i).Item("Critere"), "")
                C2 = IsNull(Tbl.Rows(i).Item("Lib_Critere"), "")
                If C1.ToString.ToUpper.Trim = "IDSOC" Then
                    C3 = Societe.id_Societe
                Else
                    C3 = GetDefaultValue(IsNull(.Rows(i).Item("Default_Value"), ""))
                End If
                C4 = IsNull(Tbl.Rows(i).Item("Fonction_Critere"), "")
                Criteres_Grd.Rows.Add(C1, C2, C3, C4)
                Criteres_Grd.Rows(i).Visible = (C1.ToString.ToUpper.Trim <> "IDSOC")
            Next
        End With
    End Sub
    Function GetDefaultValue(ByVal Relation) As String
        Dim Variable As New ArrayList
        Dim ValeurVariable As New ArrayList
        Try
            ' Chargement des variables de critères et leurs valeurs
            If Microsoft.VisualBasic.Left(Relation, 1) = Chr(34) Then
                Relation = Relation.Replace(Chr(34), "")
            End If
            If Microsoft.VisualBasic.Left(Relation, 1) = "{" Then
                Relation = Relation.Replace("{", "").Replace("}", "")
                If Relation.Contains("@") Then
                    For j = 0 To Criteres_Grd.RowCount - 1
                        If Not Criteres_Grd.Item(Critere.Index, j).Value Is Nothing Then
                            If Relation.ToUpper.Contains(Criteres_Grd.Item(Critere.Index, j).Value.ToUpper) Then
                                Variable.Add(Criteres_Grd.Item(Critere.Index, j).Value)
                                ValeurVariable.Add(Criteres_Grd.Item(Critere.Index, j).Value)
                            End If
                        End If
                    Next
                End If
                For j = 0 To Variable.Count - 1
                    If Relation.toupper.contains(Variable(j).toupper) Then
                        Relation = Relation.Replace(Variable(j), "'" & ValeurVariable(j) & "'")
                    End If
                Next
                Relation = IsNull(CnExecuting(Relation).Fields(0).Value, "")
                'Cas des Variables Globales
            ElseIf Relation.ToString.Trim.ToUpper.Contains("GV_") Then
                Relation = GlobalVar(Relation.trim.ToString)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
        Return Relation
    End Function
    Private Sub Criteres_Grd_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Criteres_Grd.CellPainting
        If e.RowIndex < 0 Or e.ColumnIndex <> Valeur.Index Then Exit Sub
        Dim oX = CInt(e.CellBounds.Right - 20)
        Dim oY = CInt(e.CellBounds.Top + e.CellBounds.Height / 2 - My.Resources.MenuLocal.Height / 2)
        e.Paint(e.ClipBounds, DataGridViewPaintParts.Background)

        If Tbl.Rows(e.RowIndex).Item("Fonction_Critere") = "Calender" Then
            e.Graphics.DrawImage(My.Resources.calendar, oX, oY)
            Criteres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = True
        ElseIf Tbl.Rows(e.RowIndex).Item("Fonction_Critere") = "Appel_Zoom" Then
            e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
            Criteres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = True
        ElseIf Tbl.Rows(e.RowIndex).Item("Fonction_Critere") = "Combo" Then
            e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
            Criteres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = True
        ElseIf Tbl.Rows(e.RowIndex).Item("Fonction_Critere") = "Boolean" Then
            e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
            Criteres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = True
        Else
            Criteres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = False
        End If
        ' Paint the rest of the cell
        e.Paint(e.ClipBounds, DataGridViewPaintParts.Border Or DataGridViewPaintParts.ContentForeground)

        ' Tell the DataGridView that you've handled this paint event
        e.Handled = True
    End Sub
    Private Sub Criteres_Grd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Criteres_Grd.DoubleClick
        Dim r, c As Integer
        r = Criteres_Grd.CurrentRow.Index
        c = Criteres_Grd.CurrentCell.ColumnIndex
        If c <> Valeur.Index Or r < 0 Then Exit Sub
        Dim Fonction_Critere As String = Criteres_Grd.Item(Type.Index, r).Value
        Dim oCell As DataGridViewTextBoxCell = TryCast(Criteres_Grd.Item(Valeur.Index, r), DataGridViewTextBoxCell)
        Select Case Fonction_Critere
            Case "Calender"
                Appel_Calender(oCell, Me)
            Case "Boolean"
                Appel_Zoom_Boolean(oCell, Me)
            Case "Appel_Zoom"
                Dim Cod_Sql As String = "Select * from Param_Mod_Edition_Criteres where Critere='" & Criteres_Grd.Item(Critere.Index, r).Value & "' and Cod_Report = '" & Cod_Report_txt.Text & "' order by rang"
                Dim Condition As String = "1=1"
                Dim Tbl As New DataTable
                Tbl = DATA_READER_GRD(Cod_Sql)
                With Tbl
                    If Tbl.Rows.Count > 0 Then
                        If RTrim(LTrim(IsNull(.Rows(0).Item("Condition"), ""))) <> "" Then
                            Condition = IsNull(.Rows(0).Item("Condition"), "")
                            Dim remplacementDict As New Dictionary(Of String, String)()
                            ' Remplissage du dictionnaire avec les valeurs de la première et deuxième colonne du DataGridView
                            For Each row As DataGridViewRow In Criteres_Grd.Rows
                                If Not row.IsNewRow Then
                                    Dim key As String = "@" & row.Cells("Critere").Value.ToString() ' Prend la valeur de la première colonne
                                    Dim value As String = row.Cells("Valeur").Value.ToString() ' Prend la valeur de la deuxième colonne
                                    remplacementDict(key) = value
                                End If
                            Next
                            Dim pattern As String = "@\w+" ' Cherche tous les mots commençant par "@"
                            Dim result As String = Regex.Replace(Condition, pattern, Function(match)
                                                                                         Dim mot As String = match.Value
                                                                                         If remplacementDict.ContainsKey(mot) Then
                                                                                             Return remplacementDict(mot)
                                                                                         Else
                                                                                             Return mot ' Garde le mot original s'il n'y a pas de correspondance
                                                                                         End If
                                                                                     End Function, RegexOptions.IgnoreCase)
                            Condition = result
                        End If
                        Appel_Zoom(.Rows(0).Item("Champs_01"), .Rows(0).Item("Champs_02"), .Rows(0).Item("Table_Critere"), Condition, oCell, Me)
                    End If
                End With
            Case "Combo"
                Dim Cod_Sql As String = "Select * from Param_Mod_Edition_Criteres where Critere='" & Criteres_Grd.Item(Critere.Index, r).Value & "' and Cod_Report = '" & Cod_Report_txt.Text & "' order by rang"
                Dim Condition As String = "1=1"
                Dim Tbl As New DataTable
                Tbl = DATA_READER_GRD(Cod_Sql)
                With Tbl
                    If Tbl.Rows.Count > 0 Then
                        Appel_Zoom_Boolean(oCell, Me, IsNull(.Rows(0).Item("Table_Critere"), ""))
                    End If
                End With
        End Select
    End Sub
    Private Sub Visualiser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimer_pb.Click
        Try
            If Cod_Report_txt.Text = "" Then Exit Sub
            Dim Path As String = FindParam("Lecteur_Digital_Mod_Edition")
            Dim Report As String = Cod_Report_txt.Text
            Dim Rpt As String = Path + "\" + Report + ".rpt"
            If Not IO.File.Exists(Rpt) Then
                MessageBoxRHP(588)
                Exit Sub
            End If
            Dim f As New Zoom_Edition_Odbc
            With f
                .etat = Rpt
                .ParamList.Clear()
                .ValList.Clear()
                .oMailSujet = Nom_Report_txt.Text
                For i = 0 To Criteres_Grd.RowCount - 1
                    If IsNull(Criteres_Grd.Item(Critere.Index, i).Value, "").ToUpper.Trim <> "IDSOC" And IsNull(Criteres_Grd.Item(Critere.Index, i).Value, "").ToUpper.Trim <> "@IDSOC" Then
                        .ParamList.Add(Criteres_Grd.Item(Critere.Index, i).Value)
                        .ValList.Add(Criteres_Grd.Item(Valeur.Index, i).Value)
                    Else
                        .ParamList.Add(Criteres_Grd.Item(Critere.Index, i).Value)
                        .ValList.Add(Societe.id_Societe)
                    End If
                Next
                .Show()
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub Param_Modele_Edition_Saisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = leMenu.Icon
        Me.DoubleBuffered = True
    End Sub
    Private Sub Criteres_Grd_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Criteres_Grd.CellMouseMove
        If Criteres_Grd.Rows.Count = 0 Then Return
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex = Valeur.Index And Criteres_Grd.Item(e.ColumnIndex, e.RowIndex).ReadOnly Then
            Criteres_Grd.Cursor = Cursors.Hand
        Else
            Criteres_Grd.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class