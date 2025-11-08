Public Class IR_Permanents_Exonore
    Dim titre As String = "Année de la déclaration : "
    Dim _Annee() As Integer = {-1}
    Dim SaisieLibre As Boolean = CnExecuting("select isnull((select top 1 isnull(Saisie_Libre,'false') from RH_Param_Declarations where id_Societe=" & Societe.id_Societe & " and Cod_Declaration='IR_Permanent_Exoneres'),'false')").Fields(0).Value
    Dim oCell As DataGridViewCell = Nothing
    Dim TblDefD As DataTable = DATA_READER_GRD("SELECT Cod_Element, Lib_Element, Typ_Data, Def_Valeur, Obligatoire, Rang, Flag
FROM         RH_Def_Declaration_Element
WHERE     (Cod_Declaration = 'IR_Permanent_Exoneres')
ORDER BY Rang")
    Sub Enregistrer()
        If EstCloturee = "C" Then
            ShowMessageBox("Période clôturée")
            Exit Sub
        End If
        If ShowMessageBox("Voulez-vous enregistrer?", "RHP", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then Exit Sub
        Try

            Cursor = Cursors.WaitCursor
            Dim rs As New ADODB.Recordset
            Dim swhere As String = ""
            'vérification des champs obligatoires
            With Grd
                For i = 0 To .RowCount - IIf(.AllowUserToAddRows, 2, 1)
                    If Not IsNumeric(IsNull(.Item(montantExonere.Index, i).Value, "").Trim) Then .Item(montantExonere.Index, i).Value = 0
                    If IsNull(.Item(Matricule.Index, i).Value, "").Trim = "" Or IsNull(.Item(refNatureElementExonere.Index, i).Value, "").Trim = "" Then
                        ShowMessageBox("Le matricule, la nature sont obligatoires", "RHP")
                        .Rows(i).Selected = True
                        Exit Sub

                    End If
                    'Vérification des doublons
                    swhere &= IIf(swhere = "", "", ",") & IsNull(.Item("Clef", i).Value, -1)
                Next
                'Début d'enregistrement
                If swhere = "" Then
                    CnExecuting("delete from IR_Permanent_Exoneres where id_Societe=" & Societe.id_Societe & " and Annee_Paie=" & _Annee(0))
                Else
                    CnExecuting("delete from IR_Permanent_Exoneres where Clef not in (" & swhere & ") and id_Societe=" & Societe.id_Societe & " and Annee_Paie=" & _Annee(0))
                End If
                'Début d'enregistrement
                For i = 0 To .RowCount - IIf(.AllowUserToAddRows, 2, 1)
                    rs.Open("select * from IR_Permanent_Exoneres where Clef ='" & IsNull(.Item(Clef.Index, i).Value, "-1") & "' and id_Societe=" & Societe.id_Societe & " and Annee_Paie=" & _Annee(0), cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Annee_Paie").Value = _Annee(0)
                        rs("id_Societe").Value = Societe.id_Societe
                    Else
                        rs.Update()
                    End If
                    rs("Matricule").Value = IsNull(.Item(Matricule.Index, i).Value, "")
                    rs("refNatureElementExonere").Value = .Item(refNatureElementExonere.Index, i).Value
                    rs("montantExonere").Value = IsNull(.Item(montantExonere.Index, i).Value, 0)
                    rs.Update()
                    rs.Close()
                Next
            End With
            Notification("Enregistrement", "Enregistré avec succès", 1, "OK")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub frm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Combo_GRD_Linked(refNatureElementExonere, "SELECT     Code Valeur, refNatureElementExonere Membre FROM Param_IR_NatureElementExonere")
        Dim TblAnnee As DataTable = DATA_READER_GRD("select Annee_Paie from RH_Preparation_Paie where  id_Societe=" & Societe.id_Societe & " group by Annee_Paie")
        With Grd
            .ContextMenuStrip = AddContextMenu(True, True, False, True, True, True, True, False)
            .AllowUserToAddRows = SaisieLibre
        End With
        If _Annee(0) = -1 Then _Annee = {CnExecuting("select isnull((select top 1 Annee from Param_Periode_Paie where id_Societe=" & Societe.id_Societe & " order by Annee desc),year(getdate()))").Fields(0).Value}
        request()
        montantExonere.Tag = "float"
    End Sub

    Sub request()
        Grd.Rows.Clear()
        Dim C1, C2, C3, C4 As Object
        Dim CodSql As String = "select * from IR_Permanent_Exoneres  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & _Annee(0) & "'"
        Dim Tbl As DataTable = DATA_READER_GRD(CodSql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = .Rows(i).Item("Clef")
                C2 = .Rows(i).Item("Matricule")
                C3 = .Rows(i).Item("refNatureElementExonere")
                C4 = FormatNumber(IsNull(.Rows(i).Item("montantExonere"), 0), 2)
                Grd.Rows.Add(C1, C2, C3, C4)
            Next
        End With
        Grd.setFilter({0, 1})
        Contenu_Grp.Text = titre & " " & _Annee(0)
    End Sub
    Private Sub New_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Grd.FirstDisplayedCell = Grd.Item(1, Grd.Rows.Count - 2)
        Grd.Item(1, Grd.Rows.Count - 1).Selected = True
    End Sub
    Private Sub Grd_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Grd.EditingControlShowing
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        Dim c As Integer = Grd.CurrentCell.ColumnIndex
        Select Case c
            Case montantExonere.Index
                AddHandler e.Control.KeyPress, AddressOf CheckCell
        End Select
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Grd.CurrentRow Is Nothing Then Exit Sub
        Dim c As Integer = Grd.CurrentCell.ColumnIndex
        ControleSaisie(Grd.CurrentCell, e, True, False, True, False, False)
    End Sub
    Sub Searching()
        With Zoom_Chercher
            .Grd = Grd
            .Show()
        End With
    End Sub
    Sub Printing()
        Dim f As New Zoom_Edition_Odbc
        With f
            .etat = "00013.mtm"
            .ParamList.Add("Annee_Paie")
            .ValList.Add(_Annee(0))
            newShowEcran(f, True)
        End With
    End Sub
    Sub Deleting()
        If EstCloturee = "C" Then
            ShowMessageBox("Période clôturée")
            Exit Sub
        End If
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette liste?", "RHP", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Exit Sub
        Try
            CnExecuting("Delete from IR_Permanent_Exoneres where id_Societe=" & Societe.id_Societe & " and Annee_Paie =" & _Annee(0))
            request()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Requesting()
        If SaisieLibre Then
            Dim f As New IR_Import
            With f
                .Combo_oModeleImport.SelectedValue = "IR_Permanent_Exoneres"
                .swhere = "  where Cod_Modele = 'IR_Permanent_Exoneres'  "
                newShowEcran(f, True)
            End With
        Else
            If Not Grd.DataSource Is Nothing Or Grd?.Columns.Count > 0 Then
                If ShowMessageBox("Etes-vous sûr de vouloir regénérer la déclaration?" & vbCrLf & "Attention : votre déclaration actuelle sera supprimée", "Regénération", MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.Cancel Then Return
            End If
            If Not IsNumeric(_Annee(0)) Then
                ShowMessageBox("Sélectionnez l'année", "Regénération", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            CnExecuting("exec Sys_Declaration " & Societe.id_Societe & ",'IR_Permanent_Exoneres'," & _Annee(0) & ", ''")
        End If
        request()
    End Sub
    Private Sub DataGridView1_DataError(ByVal sender As Object,
ByVal e As DataGridViewDataErrorEventArgs) _
Handles Grd.DataError
        Try
            ShowMessageBox("Erreur nature element exonere")
        Catch ex As Exception

        End Try
    End Sub

    Sub getExonere()
        Dim f As New Zoom_Libre
        With f
            Dim Cod_Sql As String = "select Code as Code,refNatureElementExonere as 'Nature élément éxoneré' FROM Param_IR_NatureElementExonere order by Clef"
            Dim ow As Integer = 0
            With .Libre_GRD
                .DataSource = DATA_READER_GRD(Cod_Sql)
                .ReadOnly = True
                .setFilter({0, 1})
            End With
            .Show()
        End With
    End Sub
    Sub Actualiser()
        request()
    End Sub
    Sub selectAnnee()
        Dim f As New Zoom_Annee
        With f
            AddHandler .FormClosing, Sub()
                                         _Annee = ._annnee
                                     End Sub
            .ShowDialog()
            request()
        End With
    End Sub
End Class