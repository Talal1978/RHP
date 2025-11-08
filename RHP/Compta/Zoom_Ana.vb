Imports DevComponents.DotNetBar
Public Class Zoom_Ana
    Friend CodPreparation As String = ""
    Friend CodPlan As String = ""
    Friend oIndx As Integer = 0
    Dim TblRub As DataTable = DATA_READER_GRD("select Cod_Rubrique, Lib_Rubrique from RH_Paie_Rubrique where id_Societe=" & Societe.id_Societe & " and isnull(Ventilable,0)=1")
    Dim TblPlanAna As DataTable = DATA_READER_GRD("select * from Compta_Plan_Ana where id_Societe=" & Societe.id_Societe)
    Dim TblAxe As DataTable = DATA_READER_GRD("select Cod_Axe, Lib_Axe from Compta_Axe_Ana where id_Societe=" & Societe.id_Societe)
    Dim TblAna As New DataTable
    Dim dicAxe As New Dictionary(Of String, ArrayList)
    Friend pGrd As New DataGridView
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim Appliquer_D As ud_btn
    Sub Chargement()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        With DataGridViewCellStyle2
            .Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            .BackColor = System.Drawing.SystemColors.Window
            .Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .ForeColor = Color.FromArgb(56, 36, 36)
            .SelectionBackColor = System.Drawing.SystemColors.Highlight
            .SelectionForeColor = Color.FromArgb(56, 36, 36)
            .WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        End With
        TblAna = DATA_READER_GRD("exec Sys_RH_Paie_Analytique '" & Cod_Preparation_txt.Text & "','" & Matricule_txt.Text & "','" & CodPlan & "', " & Societe.id_Societe)
        If TblAna.Rows.Count > 0 And TblAna.Columns.Count > 2 Then
            Dim nrw As DataRow = TblAna.NewRow
            nrw(0) = ""
            nrw(1) = "Ventilé"
            For i = 2 To TblAna.Columns.Count - 1
                nrw(i) = 0
                TblAna.Columns(i).AllowDBNull = True
                TblAna.Columns(i).ReadOnly = False
            Next
            TblAna.Rows.InsertAt(nrw, 1)
        End If
        With TblAxe
            For i = 0 To .Rows.Count - 1
                Dim sTab As New TabPage
                Dim anaGrd As New ud_Grd
                With sTab
                    .Name = "Tab_" & TblAxe.Rows(i)("Cod_Axe")
                    .Text = TblAxe.Rows(i)("Lib_Axe")
                    .Dock = System.Windows.Forms.DockStyle.Fill
                    .Location = New System.Drawing.Point(0, 25)
                    .Name = "Pnl_" & TblAxe.Rows(i)("Cod_Axe")
                    .Size = New System.Drawing.Size(708, 579)
                    .TabIndex = 1
                End With
                TabControl1.TabPages.Add(sTab)
                With anaGrd
                    .AllowUserToOrderColumns = False
                    .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
                    .DefaultCellStyle = DataGridViewCellStyle2
                    .Dock = System.Windows.Forms.DockStyle.Fill
                    .Location = New System.Drawing.Point(0, 0)
                    .Name = "Grd_" & TblAxe.Rows(i)("Cod_Axe")
                    Dim Dv As DataView = TblAna.DefaultView
                    Dv.RowFilter = "Cod_Axe='' or Cod_Axe='" & TblAxe.Rows(i)("Cod_Axe") & "'"
                    .DataSource = Dv.ToTable
                    For j = 0 To .ColumnCount - 1
                        .DataSource.Columns(j).readonly = False
                        .DataSource.Columns(j).allowdbnull = True
                        If .Columns(j).Name = "Cod_Axe" Then
                            .Columns(j).Visible = False
                        ElseIf .Columns(j).Name = "Cod_Sec_Ana" Then
                            .Columns(j).HeaderText = "Section"
                            .Columns(j).ReadOnly = True
                            .Columns(j).MinimumWidth = 120
                        ElseIf TblRub.Select("Cod_Rubrique='" & .Columns(j).Name & "'").Length > 0 Then
                            .Columns(j).HeaderText = TblRub.Select("Cod_Rubrique='" & .Columns(j).Name & "'")(0)("Lib_Rubrique")
                            .Columns(j).ReadOnly = False
                            With .Columns(j).DefaultCellStyle
                                .Alignment = DataGridViewContentAlignment.MiddleRight
                                .NullValue = 0
                            End With
                            Calcul(anaGrd, j)
                        End If
                    Next
                    If .RowCount > 2 Then
                        .Rows(0).ReadOnly = True
                        .Rows(1).ReadOnly = True
                    End If
                    AddHandler .CellMouseEnter, AddressOf MouseEnteree
                    AddHandler .CellMouseDoubleClick, AddressOf MouseDbClik
                    AddHandler .EditingControlShowing, AddressOf _Grd_EditingControlShowing
                    AddHandler .CellValidated, AddressOf _CellValidated
                    AddHandler .DataError, AddressOf _DataError
                    AddHandler .RowsRemoved, AddressOf _RowsRemoved
                End With
                dicAxe.Add(TblAxe.Rows(i)("Cod_Axe"), New ArrayList({anaGrd, sTab}))
                sTab.Controls.Add(anaGrd)
            Next
            If TabControl1.TabPages.Count > 0 Then TabControl1.SelectedIndex = 0
        End With
    End Sub
    Sub Request()
        TblAna = DATA_READER_GRD("exec Sys_RH_Paie_Analytique '" & Cod_Preparation_txt.Text & "','" & Matricule_txt.Text & "','" & CodPlan & "', " & Societe.id_Societe)
        Dim _Grd As New DataGridView
        If TblAna.Rows.Count > 0 And TblAna.Columns.Count > 2 Then
            Dim nrw As DataRow = TblAna.NewRow
            nrw(0) = ""
            nrw(1) = "Ventilé"
            For i = 2 To TblAna.Columns.Count - 1
                nrw(i) = 0
            Next
            TblAna.Rows.InsertAt(nrw, 1)
        End If
        For i = 0 To dicAxe.Count - 1
            Dim Dv As DataView = TblAna.DefaultView
            Dv.RowFilter = "Cod_Axe='' or Cod_Axe='" & dicAxe.Keys(i) & "'"
            _Grd = CType(dicAxe.Values(i)(0), DataGridView)
            With _Grd
                .DataSource = Dv.ToTable
                If .ColumnCount > 2 Then
                    For j = 2 To .ColumnCount - 1
                        .DataSource.Columns(j).readonly = False
                        .DataSource.Columns(j).allowdbnull = True
                        If .Columns(j).Name = "Cod_Axe" Then
                            .Columns(j).Visible = False
                        ElseIf .Columns(j).Name = "Cod_Sec_Ana" Then
                            .Columns(j).HeaderText = "Section"
                            .Columns(j).ReadOnly = True
                            .Columns(j).MinimumWidth = 120
                        ElseIf TblRub.Select("Cod_Rubrique='" & .Columns(j).Name & "'").Length > 0 Then
                            .Columns(j).HeaderText = TblRub.Select("Cod_Rubrique='" & .Columns(j).Name & "'")(0)("Lib_Rubrique")
                            .Columns(j).ReadOnly = False
                            .Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            Calcul(_Grd, j)
                        End If
                    Next
                End If
            End With
        Next
    End Sub
    Private Sub _RowsRemoved(sender As DataGridView, e As DataGridViewRowsRemovedEventArgs)
        With sender
            If .ColumnCount <= 2 Then Return
            For i = 2 To .ColumnCount - 1
                Calcul(sender, i)
            Next
        End With
    End Sub
    Private Sub _DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        Try
        Catch ex As Exception

        End Try
    End Sub
    Function Calcul(_Grd As DataGridView, cl As Integer) As Boolean
        Dim Tt As Double = 0
        With _Grd
            If .RowCount > 2 Then
                If Not IsNumeric(.Item(cl, 0).Value) Then .Item(cl, 0).Value = 0
                For i = 2 To .RowCount - 2
                    If IsNull(.Item("Cod_Sec_Ana", i).Value, "") <> "" And IsNull(.Item("Cod_Axe", i).Value, "") <> "" Then
                        Tt += IsNull(.Item(cl, i).Value, 0)
                    End If
                Next
                .Item(cl, 1).Value = Math.Round(Tt, 3)
            End If
        End With
        Return True
    End Function
    Private Sub _CellValidated(sender As DataGridView, e As DataGridViewCellEventArgs)
        With sender
            If e.ColumnIndex > .Columns("Cod_Sec_Ana").Index And e.RowIndex >= 2 Then
                Calcul(sender, e.ColumnIndex)
            ElseIf e.ColumnIndex = .Columns("Cod_Sec_Ana").Index And e.RowIndex >= 2 Then
                Dim nrw() As DataRow = TblPlanAna.Select("Cod_Sec_Ana='" & .Item("Cod_Sec_Ana", e.RowIndex).Value & "'")
                If nrw.Length > 0 Then
                    .Item("Cod_Axe", e.RowIndex).Value = nrw(0)("Cod_Axe")
                End If
            End If
        End With
    End Sub
    Sub MouseEnteree(sender As DataGridView, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = sender.Columns("Cod_Sec_Ana").Index And e.RowIndex >= 0 Then
            sender.Cursor = Cursors.Hand
        Else
            sender.Cursor = Cursors.Default
        End If
    End Sub
    Sub MouseDbClik(sender As DataGridView, e As DataGridViewCellMouseEventArgs)
        With sender
            Dim r As Integer = e.RowIndex
            If .Rows(r).IsNewRow Then
                .DataSource.Rows.Add("")
                .DataSource.rows.removeat(r)
            End If
            If e.ColumnIndex = .Columns("Cod_Sec_Ana").Index And Not .Rows(r).ReadOnly Then
                Appel_Zoom1("MS118", .Item("Cod_Sec_Ana", r), Me, "Cod_Axe='" & .Name.Replace("Grd_", "") & "'")
                If .ColumnCount > 2 Then
                    For i = 2 To .ColumnCount - 1
                        Calcul(sender, i)
                        If IsNull(.Item(i, r).Value, 0) <= 0 Then
                            .Item(i, r).Value = Math.Max(Math.Round(CDbl(.Item(i, 0).Value) - CDbl(.Item(i, 1).Value), 3), 0)
                        End If
                        Calcul(sender, i)
                    Next
                    .CurrentCell = .Item(2, r)
                    .BeginEdit(True)
                End If

            End If
        End With

    End Sub
    Private Sub _Grd_EditingControlShowing(sender As DataGridView, e As DataGridViewEditingControlShowingEventArgs)
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        RemoveHandler e.Control.KeyPress, AddressOf CheckCell
        With sender
            If .CurrentCell.ColumnIndex > .Columns("Cod_Sec_Ana").Index And .CurrentCell.RowIndex >= 0 Then
                e.Control.Tag = sender
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        End With
    End Sub
    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With sender.tag
            .CurrentCell.Style.Alignment = DataGridViewContentAlignment.TopRight
            ControleSaisie(.CurrentCell, e, True, False, False, False, False)
        End With
    End Sub
    Private Sub Zoom_Ana_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Next_D = dictButtons("Next_D")
        Back_D = dictButtons("Back_D")
        Last_D = dictButtons("Last_D")
        First_D = dictButtons("First_D")
        Appliquer_D = dictButtons("Appliquer_D")
        Chargement()

    End Sub
    Sub Deleting()
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer la ventilation analytique?", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        If ShowMessageBox("Voulez-vous supprimer toute la ventilation pour cette préparation?", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.OK Then
            CnExecuting("delete from RH_Preparation_Paie_Analytique where id_Societe=" & Societe.id_Societe & " and Cod_Preparation='" & Cod_Preparation_txt.Text & "'")
        Else
            CnExecuting("delete from RH_Preparation_Paie_Analytique where id_Societe=" & Societe.id_Societe & " and Cod_Preparation='" & Cod_Preparation_txt.Text & "' and Matricule='" & Matricule_txt.Text & "'")
        End If
        Me.Close()
    End Sub
    Sub Enregistrer()
        If Saving() Then
            Me.Close()
        End If
    End Sub
    Function Saving() As Boolean
        Dim sGrd As New DataGridView
        Dim sTab As New TabPage
        Dim rs As New ADODB.Recordset
        'vérification
        For i = 0 To dicAxe.Count - 1
            sGrd = dicAxe.Values(i)(0)
            sTab = dicAxe.Values(i)(1)
            With sGrd
                If .RowCount > 2 Then
                    For j = 2 To .ColumnCount - 1
                        Calcul(sGrd, j)
                        If CDbl(.Item(j, 0).Value) <> CDbl(.Item(j, 1).Value) Then
                            ShowMessageBox("Ventilation non appurée", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
                            TabControl1.SelectedTab = sTab
                            .Item(j, 1).Selected = True
                            .FirstDisplayedCell = .Item(j, 1)
                            Return False
                        End If
                    Next
                Else
                    Return False
                End If
            End With
        Next
        'Enregistrer
        CnExecuting("delete from RH_Preparation_Paie_Analytique where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_txt.Text & "' and Cod_Preparation='" & Cod_Preparation_txt.Text & "'")
        For i = 0 To dicAxe.Count - 1
            sGrd = dicAxe.Values(i)(0)
            sTab = dicAxe.Values(i)(1)
            With sGrd
                For j = 2 To .ColumnCount - 1
                    For k = 2 To .RowCount - 2
                        If IsNull(.Item("Cod_Axe", k).Value, "") <> "" And IsNull(.Item("Cod_Sec_Ana", k).Value, "") <> "" Then
                            rs.Open("select * from RH_Preparation_Paie_Analytique where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_txt.Text & "' and Cod_Preparation='" & Cod_Preparation_txt.Text & "'", cn, 2, 2)
                            rs.AddNew()
                            rs("id_Societe").Value = Societe.id_Societe
                            rs("Cod_Preparation").Value = Cod_Preparation_txt.Text
                            rs("Matricule").Value = Matricule_txt.Text
                            rs("Cod_Rubrique").Value = .Columns(j).Name
                            rs("Cod_Axe").Value = .Item("Cod_Axe", k).Value
                            rs("Cod_Sec_Ana").Value = .Item("Cod_Sec_Ana", k).Value
                            If CDbl(.Item(j, 0).Value) > 0 Then
                                rs("Pourcentage").Value = Math.Round(CDbl(.Item(j, k).Value) / CDbl(.Item(j, 0).Value), 4)
                            Else
                                rs("Pourcentage").Value = 0
                            End If
                            rs("Valeur").Value = CDbl(.Item(j, k).Value)
                            rs.Update()
                            rs.Close()
                        End If
                    Next
                Next
            End With
        Next

        Return True
    End Function
    Sub Appliquer()
        If ShowMessageBox("Etes-vous sûr de vouloir dupliquer cette ventilation analytique à tous les matricules de la présente préparation?", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        If ShowMessageBox("Avant de lancer la ventilation analytique, veuillez-vous assurer que votre préparation a bien été enregistrée.", Me.Text, MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        Try
            Cursor = Cursors.WaitCursor
            If Saving() Then
                Dim sGrd As New DataGridView
                Dim sTab As New SuperTabItem
                Dim rs As New ADODB.Recordset
                Dim Mat As String = ""
                Dim Mnt As Double = 0
                Dim Rub As String = ""
                With pGrd
                    For p = 0 To .RowCount - 1
                        Mat = IsNull(.Item("Matricule", p).Value, "")
                        If Mat <> Matricule_txt.Text Then
                            'Enregistrer
                            CnExecuting("delete from RH_Preparation_Paie_Analytique where id_Societe=" & Societe.id_Societe & " and Matricule='" & Mat & "' and Cod_Preparation='" & Cod_Preparation_txt.Text & "'")
                            For i = 0 To dicAxe.Count - 1
                                sGrd = dicAxe.Values(i)(0)
                                sTab = dicAxe.Values(i)(1)
                                With sGrd
                                    For j = 2 To .ColumnCount - 1
                                        Rub = sGrd.Columns(j).Name
                                        Mnt = IsNull(pGrd.Item(Rub, p).Value, 0)
                                        For k = 2 To .RowCount - 2
                                            If IsNull(.Item("Cod_Axe", k).Value, "") <> "" And IsNull(.Item("Cod_Sec_Ana", k).Value, "") <> "" Then
                                                rs.Open("select * from RH_Preparation_Paie_Analytique where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_txt.Text & "' and Cod_Preparation='" & Cod_Preparation_txt.Text & "'", cn, 2, 2)
                                                rs.AddNew()
                                                rs("id_Societe").Value = Societe.id_Societe
                                                rs("Cod_Preparation").Value = Cod_Preparation_txt.Text
                                                rs("Matricule").Value = Mat
                                                rs("Cod_Rubrique").Value = .Columns(j).Name
                                                rs("Cod_Axe").Value = .Item("Cod_Axe", k).Value
                                                rs("Cod_Sec_Ana").Value = .Item("Cod_Sec_Ana", k).Value
                                                If CDbl(.Item(j, 0).Value) > 0 Then
                                                    rs("Pourcentage").Value = Math.Round(CDbl(.Item(j, k).Value) / CDbl(.Item(j, 0).Value), 4)
                                                Else
                                                    rs("Pourcentage").Value = 0
                                                End If
                                                rs("Valeur").Value = Math.Round(Mnt * rs("Pourcentage").Value, 3)
                                                rs.Update()
                                                rs.Close()
                                            End If
                                        Next
                                    Next
                                End With
                            Next
                        End If
                    Next
                End With
            End If
            Cursor = Cursors.Default
            ShowMessageBox("Ventilation terminée", Me.Text, MessageBoxButtons.OK, msgIcon.Information)
        Catch ex As Exception
            Cursor = Cursors.Default
            ShowMessageBox(ex.Message)
        End Try
    End Sub
    Sub Div_First()
        oIndx = 0
        Matricule_txt.Text = pGrd.Item("Matricule", oIndx).Value
        Nom_txt.Text = pGrd.Item("Nom", oIndx).Value
        Request()
    End Sub

    Sub Div_Last()
        oIndx = pGrd.RowCount - 1
        Matricule_txt.Text = pGrd.Item("Matricule", oIndx).Value
        Nom_txt.Text = pGrd.Item("Nom", oIndx).Value
        Request()
    End Sub

    Sub Div_Back()
        If oIndx <= 0 Then
            ShowMessageBox("C'est le premier matricule", "Ventilation analytique", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        oIndx -= 1
        Matricule_txt.Text = pGrd.Item("Matricule", oIndx).Value
        Nom_txt.Text = pGrd.Item("Nom", oIndx).Value
        Request()
    End Sub
    Sub Div_Next()
        If oIndx >= pGrd.RowCount - 1 Then
            ShowMessageBox("C'est le dernier matricule", "Ventilation analytique", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        oIndx += 1
        Matricule_txt.Text = pGrd.Item("Matricule", oIndx).Value
        Nom_txt.Text = pGrd.Item("Nom", oIndx).Value
        Request()
    End Sub
End Class