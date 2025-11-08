Public Class Zoom_RH_Saisie_EV
    Friend silentMode As Boolean = False
    Friend myVBS As New vsEngine
    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Zoom_Libre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EV_GRD.Rows.Clear()
        Combo_GRD(Typ_Param)
        Me.KeyPreview = True
        If EV_GRD.Rows.Count = 0 Then Request()
        EV_GRD.Fit()

    End Sub
    Sub Request()
        EV_GRD.Rows.Clear()
        Dim C1, C2, C3, C4 As Object
        Dim Tbl As DataTable = DATA_READER_GRD("select Cod_Rubrique, Lib_Rubrique, Typ_Retour, Val_Defaut from RH_Paie_Rubrique where isnull(EV,0)=1 and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = .Rows(i)("Cod_Rubrique")
                C2 = .Rows(i)("Lib_Rubrique")
                C3 = .Rows(i)("Typ_Retour")
                C4 = .Rows(i)("Val_Defaut")
                EV_GRD.Rows.Add(C1, C2, C3, C4)
            Next
        End With
    End Sub
    Private Sub EV_GRD_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles EV_GRD.CellPainting
        If e.ColumnIndex <> Valeur.Index Or e.RowIndex < 0 Then Exit Sub
        Dim oX, oY As Integer
        oX = e.CellBounds.Location.X + e.CellBounds.Width
        oY = (e.RowIndex + 1) * e.CellBounds.Height + 12
        With EV_GRD
            If IsNull(.Item("Typ_Param", e.RowIndex).Value, "") = "smalldatetime" Then
                e.Graphics.DrawImage(My.Resources.calendrier, oX, oY)
                .Item(Valeur.Index, e.RowIndex).ReadOnly = True
                .Item("Valeur", e.RowIndex).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Else
                .Item("Valeur", e.RowIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                .Item(Valeur.Index, e.RowIndex).ReadOnly = False
            End If
        End With
    End Sub

    Private Sub EV_GRD_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EV_GRD.DoubleClick
        With EV_GRD
            Dim r, c As Integer
            r = .CurrentRow.Index
            c = .CurrentCell.ColumnIndex
            If c <> Valeur.Index Or r < 0 Then Exit Sub
            If IsNull(.Item("Typ_Param", .CurrentCell.RowIndex).Value, "") = "smalldatetime" Then
                Appel_Calender(.CurrentCell, Me)
            End If
        End With
    End Sub
    Private Sub EV_GRD_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles EV_GRD.EditingControlShowing
        With EV_GRD
            If .CurrentCell.ColumnIndex = Valeur.Index Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With EV_GRD
            If .Item("Typ_Param", .CurrentCell.RowIndex).Value = "float" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, False, False, False, False)
            ElseIf .Item("Typ_Param", .CurrentCell.RowIndex).Value = "int" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                ControleSaisie(.CurrentCell, e, True, True, False, False, False)
            ElseIf .Item("Typ_Param", .CurrentCell.RowIndex).Value = "bit" Then
                .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
                If e.KeyChar <> "0" And e.KeyChar <> "1" Then
                    e.Handled = False
                End If
            End If
        End With
    End Sub
    Private Sub Fermer_D_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Sub Save_D_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        If LeMatricule_txt.Text.Trim <> "" Then LeMatricule_txt.Text = FindLibelle("Matricule", "Matricule", LeMatricule_txt.Text, "RH_Agent").trim()
        If LeMatricule_txt.Text.Trim = "" Then LeMatricule_txt.Text = FindLibelle("Matricule", "Matricule", Societe.LeMatricule, "RH_Agent").trim()
        If LeMatricule_txt.Text.Trim = "" Then
            If Not silentMode Then
                ShowMessageBox("Renseignez le matricule par défaut", "Matricule par défaut", MessageBoxButtons.OK, msgIcon.Stop)
                LeMatricule_txt.Text = ""
            End If
            Return
        Else
            If LeMatricule_txt.Text.Trim <> Societe.LeMatricule Then Societe.LeMatricule = LeMatricule_txt.Text
        End If
        Dim StrVar As String = ""
        Dim currentPlan As String = FindLibelle("Plan_Paie", "Matricule", LeMatricule_txt.Text, "RH_Agent")
        myVBS.setPlan(currentPlan)
        myVBS.AffectationEB(Societe.LeMatricule, Now.Date)
        With EV_GRD
            For i = 0 To .RowCount - 1
                StrVar &= vbCrLf & "AffectVar " & .Item(Cod_Rubrique.Index, i).Value & " ; " & ParDefaut(IIf(IsNull(.Item(Typ_Param.Index, i).Value, "").ToUpper = "INT" Or IsNull(.Item(Typ_Param.Index, i).Value, "").ToUpper = "FLOAT", .Item(Valeur.Index, i).Value, """" & .Item(Valeur.Index, i).Value & """"), .Item(Typ_Param.Index, i).Value)
            Next
        End With
        StrVar = TraitementCaractere(StrVar)
        'Dim sw As New IO.StreamWriter(My.Application.Info.DirectoryPath & "\rsc\dbg_" & Societe.id_Societe & ".vbs", True)
        'sw.Write(StrVar)
        'sw.Close()


        Try
            myVBS.ExecuteStatement(StrVar)
        Catch ex As Exception
            ShowMessageBox("Erreur de compilation VBS. Veuillez vérifier le fichier : " & vbCrLf & My.Application.Info.DirectoryPath & "\rsc\dbg_" & Societe.id_Societe & ".vbs", "Erreur Compilation", MessageBoxButtons.OK, msgIcon.Stop)
        End Try
        Me.Close()
    End Sub
    Private Sub LeMatricule_txt_TextChanged(sender As Object, e As EventArgs) Handles LeMatricule_txt.TextChanged
        Nom_Matricule_txt.Text = FindLibelle("Nom_Agent + ' ' + Prenom_Agent", "Matricule", LeMatricule_txt.Text, "RH_Agent")
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Appel_Zoom1("MS067", LeMatricule_txt, Me)
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles Actualiser_pb.Click
        Request()
    End Sub
End Class