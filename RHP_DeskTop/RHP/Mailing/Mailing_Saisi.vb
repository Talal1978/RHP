Imports System.ComponentModel
Imports System.Text.RegularExpressions
Public Class Mailing_Saisi
    Dim Tbl As New DataTable
    Sub Mailing_Generator(ByVal MailingName As String, ByVal MailingText As String)
        Cod_Mailing_txt.Text = MailingName
        Lib_Mailing_txt.Text = MailingText
        Dim Cod_Sql As String = "Select Parametre,Lib_Parametre,Fonction_Parametre,Default_Value from Mailing_Parametres where Cod_Mailing='" & MailingName & "' order by rang"
        '   MsgBox(Cod_Sql)
        Dim C1, C2, C3, C4 As Object
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(Tbl.Rows(i).Item("Parametre"), "")
                C2 = IsNull(Tbl.Rows(i).Item("Lib_Parametre"), "")
                If C1.ToString.ToUpper.Trim = "IDSOC" Then
                    C3 = Societe.id_Societe
                Else
                    C3 = GetDefaultValue(IsNull(.Rows(i).Item("Default_Value"), ""))
                End If
                C4 = IsNull(Tbl.Rows(i).Item("Fonction_Parametre"), "")
                Parametres_Grd.Rows.Add(C1, C2, C3, C4)
                Parametres_Grd.Rows(i).Visible = (C1.ToString.ToUpper.Trim <> "IDSOC")
            Next
            '   MsgBox(Parametres_Grd.Rows.Count)
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
                    For j = 0 To Parametres_Grd.RowCount - 1
                        If Not Parametres_Grd.Item(Parametre.Index, j).Value Is Nothing Then
                            If Relation.ToUpper.Contains(Parametres_Grd.Item(Parametre.Index, j).Value.ToUpper) Then
                                Variable.Add(Parametres_Grd.Item(Parametre.Index, j).Value)
                                ValeurVariable.Add(Parametres_Grd.Item(Parametre.Index, j).Value)
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
    Private Sub Parametres_Grd_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Parametres_Grd.CellPainting
        If e.RowIndex < 0 Or e.ColumnIndex <> Valeur.Index Then Exit Sub
        Dim oX = CInt(e.CellBounds.Right - 20)
        Dim oY = CInt(e.CellBounds.Top + e.CellBounds.Height / 2 - My.Resources.MenuLocal.Height / 2)
        e.Paint(e.ClipBounds, DataGridViewPaintParts.Background)

        If Tbl.Rows(e.RowIndex).Item("Fonction_Parametre") = "Calender" Then
            e.Graphics.DrawImage(My.Resources.calendar, oX, oY)
            Parametres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = True
        ElseIf Tbl.Rows(e.RowIndex).Item("Fonction_Parametre") = "Appel_Zoom" Then
            e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
            Parametres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = True
        ElseIf Tbl.Rows(e.RowIndex).Item("Fonction_Parametre") = "Combo" Then
            e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
            Parametres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = True
        ElseIf Tbl.Rows(e.RowIndex).Item("Fonction_Parametre") = "Boolean" Then
            e.Graphics.DrawImage(My.Resources.MenuLocal, oX, oY)
            Parametres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = True
        Else
            Parametres_Grd.Item(Valeur.Index, e.RowIndex).ReadOnly = False
        End If
        ' Paint the rest of the cell
        e.Paint(e.ClipBounds, DataGridViewPaintParts.Border Or DataGridViewPaintParts.ContentForeground)

        ' Tell the DataGridView that you've handled this paint event
        e.Handled = True
    End Sub
    Private Sub Parametres_Grd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Parametres_Grd.DoubleClick
        Dim r, c As Integer
        r = Parametres_Grd.CurrentRow.Index
        c = Parametres_Grd.CurrentCell.ColumnIndex
        If c <> Valeur.Index Or r < 0 Then Exit Sub
        Dim Fonction_Parametre As String = Parametres_Grd.Item(Type.Index, r).Value
        Dim oCell As DataGridViewTextBoxCell = TryCast(Parametres_Grd.Item(Valeur.Index, r), DataGridViewTextBoxCell)
        Select Case Fonction_Parametre
            Case "Calender"
                Appel_Calender(oCell, Me)
            Case "Boolean"
                Appel_Zoom_Boolean(oCell, Me)
            Case "Appel_Zoom"
                Dim Cod_Sql As String = "Select * from Mailing_Parametres where Parametre='" & Parametres_Grd.Item(Parametre.Index, r).Value & "' and Cod_Mailing = '" & Cod_Mailing_txt.Text & "' order by rang"
                Dim Condition As String = "1=1"
                Dim Tbl As New DataTable
                Tbl = DATA_READER_GRD(Cod_Sql)
                With Tbl
                    If Tbl.Rows.Count > 0 Then
                        If RTrim(LTrim(IsNull(.Rows(0).Item("Condition"), ""))) <> "" Then
                            Condition = IsNull(.Rows(0).Item("Condition"), "")
                            Dim remplacementDict As New Dictionary(Of String, String)()
                            ' Remplissage du dictionnaire avec les valeurs de la première et deuxième colonne du DataGridView
                            For Each row As DataGridViewRow In Parametres_Grd.Rows
                                If Not row.IsNewRow Then
                                    Dim key As String = "@" & row.Cells("Parametre").Value.ToString() ' Prend la valeur de la première colonne
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
                        Appel_Zoom(.Rows(0).Item("Champs_01"), .Rows(0).Item("Champs_02"), .Rows(0).Item("Table_Parametre"), Condition, oCell, Me)
                    End If
                End With
            Case "Combo"
                Dim Cod_Sql As String = "Select * from Mailing_Parametres where Parametre='" & Parametres_Grd.Item(Parametre.Index, r).Value & "' and Cod_Mailing = '" & Cod_Mailing_txt.Text & "' order by rang"
                Dim Condition As String = "1=1"
                Dim Tbl As New DataTable
                Tbl = DATA_READER_GRD(Cod_Sql)
                With Tbl
                    If Tbl.Rows.Count > 0 Then
                        Appel_Zoom_Boolean(oCell, Me, IsNull(.Rows(0).Item("Table_Parametre"), ""))
                    End If
                End With
        End Select
    End Sub
    Private Sub Param_Modele_Edition_Saisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = leMenu.Icon
        Me.DoubleBuffered = True
    End Sub
    Private Sub Parametres_Grd_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Parametres_Grd.CellMouseMove
        If Parametres_Grd.Rows.Count = 0 Then Return
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex = Valeur.Index And Parametres_Grd.Item(e.ColumnIndex, e.RowIndex).ReadOnly Then
            Parametres_Grd.Cursor = Cursors.Hand
        Else
            Parametres_Grd.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
    Private WithEvents bgwMailing As New BackgroundWorker
    Dim WithEvents oTmr As New Timer
    Dim oListe As New List(Of String)
    Dim debutEnvoi As String = ""
    Private Sub oTmr_Tick(sender As Object, e As EventArgs) Handles oTmr.Tick
        Results_txt.Text = debutEnvoi & If(finMailing, "", "  " & New String("."c, Now.Second Mod 6)) & vbCrLf & String.Join(vbCrLf, oListe)
        If finMailing Then Results_txt.Text &= vbCrLf & "Fin du traitement"
        Results_txt.Refresh()
        If finMailing Then oTmr.Stop()

    End Sub
    Private Sub sendMail_pb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendMail_pb.Click
        Try
            If Cod_Mailing_txt.Text = "" Then Return
            Dim dicParam As New Dictionary(Of String, Object)
            oListe.Clear()
            finMailing = False
            Results_txt.ResetText()
            With Parametres_Grd
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(Parametre.Index, i).Value, "").ToUpper.Trim() <> "" Then
                        If Not dicParam.ContainsKey(.Item(Parametre.Index, i).Value) Then
                            If IsNull(.Item(Parametre.Index, i).Value, "").ToUpper.Trim <> "IDSOC" And IsNull(.Item(Parametre.Index, i).Value, "").ToUpper.Trim <> "@IDSOC" Then
                                dicParam.Add(.Item(Parametre.Index, i).Value, .Item(Valeur.Index, i).Value)
                            Else
                                dicParam.Add(.Item(Parametre.Index, i).Value, Societe.id_Societe)
                            End If
                        End If
                    End If
                Next
            End With
            bgwMailing.WorkerReportsProgress = True
            bgwMailing.RunWorkerAsync(New Object() {Cod_Mailing_txt.Text, dicParam, oListe})
            debutEnvoi = "Début d'envoi : " & Now
            Cursor = Cursors.WaitCursor
            With oTmr
                .Interval = 100
                .Start()
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub bgwMailing_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwMailing.DoWork
        Dim args = DirectCast(e.Argument, Object())
        Dim CodMailing As String = CStr(args(0))
        Dim dicParametres As Dictionary(Of String, Object) = TryCast(args(1), Dictionary(Of String, Object))
        Dim _liste As List(Of String) = TryCast(args(2), List(Of String))
        CompagneMailing(CodMailing, dicParametres, _liste)
    End Sub
    Dim finMailing As Boolean = False
    Private Sub bgwMailing_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwMailing.RunWorkerCompleted
        finMailing = True
        Cursor = Cursors.Default
        '  Results_txt.Text = Results_txt.Text & vbCrLf & "Fin"
        '  oTmr.Stop()
    End Sub
End Class