Public Class Zoom_TraitementsSpecifiques
    Friend Tbl_TraitementsSpecifiques As New DataTable
    Dim oSize As New Size
    Dim oLoc As New Point

    Private Sub Zoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlStr = "SELECT     Cod_Traitement as Code,(select Traitement from Sys_Def_Ecran_Traitements_Specifiques where Code=t.Cod_Traitement) as Traitement,isnull(Typ_Traitement,'QRY') Typ_Traitement, isnull(Relation ,'') as Relation
                                    FROM         Controle_Def_Ecran_Traitements_Specifiques t 
                                    outer apply (select isnull(Visible,'false') as Visible from Controle_Droit where Name_Ecran=t.Cod_Traitement and Cod_Profile='" & theUser.Cod_Profile & "') d
                                    where Name_Ecran='" & leMenu.currentEcran.Name & "' and " & IIf(theUser.Cod_Profile = 1, "'True'", "d.Visible") & "='True' order by  Rang"
        Tbl_TraitementsSpecifiques = DATA_READER_GRD(sqlStr)
        With Zoom_Grd
            .DataSource = Tbl_TraitementsSpecifiques
            .Columns("Relation").Visible = False
            .setFilter({0, 1})
            .Fit()
        End With
        oSize = Me.Size
        oLoc = Me.Location
    End Sub
    Private Sub Zoom_Grd_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Zoom_Grd.CellDoubleClick
        If e.RowIndex >= 0 Then ClickTraitementSpe(e.RowIndex)
    End Sub

    Sub ClickTraitementSpe(rowInd As Integer)
        Dim nrw As DataRow() = Tbl_TraitementsSpecifiques.Select("Code='" & Zoom_Grd.Item("Code", rowInd).Value & "'")
        If nrw.Length = 0 Then Return
        Try
            Cursor.Current = Cursors.WaitCursor
            'Chargement de la relation
            Dim oRelation As String = nrw(0)("Relation")
            If oRelation.Trim = "" Then Exit Sub
            Dim Critere As New ArrayList
            Dim ValeurCritere As New ArrayList
            ' Chargement des variables de critères et leurs valeurs
            Dim Relation As String() = Split(oRelation, ";")
            Dim chmp() As String = Nothing
            For i = 0 To Relation.Length - 1
                chmp = Split(Relation(i).Trim.ToUpper, ":=")
                If chmp.Length > 0 Then
                    Critere.Add(chmp(0))
                    ValeurCritere.Add(chmp(1))
                End If
            Next
            For i = 0 To ValeurCritere.Count - 1
                If ValeurCritere(i).ToString.Contains("{") Then
                    ValeurCritere(i) = ValeurCritere(i).Replace("{", "").Replace("}", "")
                ElseIf ValeurCritere(i).ToString.StartsWith("GV_") Then
                    ValeurCritere(i) = GlobalVar(ValeurCritere(i))
                ElseIf ValeurCritere(i).ToString.StartsWith("""") Then
                    ValeurCritere(i) = ValeurCritere(i).Replace("""", "")
                ElseIf IsNull(ValeurCritere(i), "") <> "" Then
                    Dim obj As Object = GetControlByName(ValeurCritere(i), leMenu.currentEcran)
                    If obj IsNot Nothing Then
                        If obj.GetType.Name = "ud_TextBox" Or obj.GetType.Name = "TextBox" Then
                            Dim Index_Value As String = obj.Text
                            ValeurCritere(i) = Index_Value
                        End If
                    End If
                End If
            Next
            If IsNull(nrw(0)("Typ_Traitement"), "") = "PYT" Then
                Dim f As New Param_Python_Saisi With {
                    .Text = nrw(0)("Traitement")
                }
                f.Python_Generator(nrw(0)("Code"), f.Text)
                For i = 0 To Critere.Count - 1
                    If ValeurCritere(i).ToString.Trim.StartsWith("SELECT") Then
                        For j = 0 To Critere.Count - 1
                            ValeurCritere(i) = ValeurCritere(i).ToString.Replace(Critere(j), "'" & ValeurCritere(j) & "'")
                        Next
                        Try
                            ValeurCritere(i) = IsNull(CnExecuting(ValeurCritere(i)).Fields(0).Value, "")
                        Catch ex As Exception

                        End Try
                    End If
                    Affectation(f, Critere(i), ValeurCritere(i))
                Next
                newShowEcran(f)
            ElseIf IsNull(nrw(0)("Typ_Traitement"), "") = "EML" Then
                Dim f As New Mailing_Saisi With {
                    .Text = nrw(0)("Traitement")
                }
                f.Mailing_Generator(nrw(0)("Code"), f.Text)
                For i = 0 To Critere.Count - 1
                    If ValeurCritere(i).ToString.Trim.StartsWith("SELECT") Then
                        For j = 0 To Critere.Count - 1
                            ValeurCritere(i) = ValeurCritere(i).ToString.Replace(Critere(j), "'" & ValeurCritere(j) & "'")
                        Next
                        Try
                            ValeurCritere(i) = IsNull(CnExecuting(ValeurCritere(i)).Fields(0).Value, "")
                        Catch ex As Exception

                        End Try
                    End If
                    Affectation(f, Critere(i), ValeurCritere(i))
                Next
                newShowEcran(f)
            Else
                Dim f As New Param_Query_Saisi
                f.Text = nrw(0)("Traitement")
                f.Query_Generator(nrw(0)("Code"), f.Text)
                For i = 0 To Critere.Count - 1
                    If ValeurCritere(i).ToString.Trim.StartsWith("SELECT") Then
                        For j = 0 To Critere.Count - 1
                            ValeurCritere(i) = ValeurCritere(i).ToString.Replace(Critere(j), "'" & ValeurCritere(j) & "'")
                        Next
                        Try
                            ValeurCritere(i) = IsNull(CnExecuting(ValeurCritere(i)).Fields(0).Value, "")
                        Catch ex As Exception

                        End Try
                    End If
                    Affectation(f, Critere(i), ValeurCritere(i))
                Next
                If IsNull(nrw(0)("Typ_Traitement"), "") <> "TRT" And IsNull(nrw(0)("Typ_Traitement"), "") <> "EXP" Then
                    newShowEcran(f)
                Else
                    f.Request()
                End If
            End If

            Me.Close()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub
    Sub Maximize_btn_Click(sender As Object, e As EventArgs) Handles Maximize_btn.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Size = oSize
            Me.Location = oLoc
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Select Case keyData
            Case Keys.Escape
                Me.Close()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub Close_btn_Load(sender As Object, e As EventArgs) Handles Close_btn.Click
        Me.Close()
    End Sub
End Class