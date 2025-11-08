Public Class Zoom_Editions
    Friend Tbl_Editions As New DataTable
    Dim oSize As New Size
    Dim oLoc As New Point
    Friend ecr As New Ecran
    Private Sub Zoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tbl_Editions = TableDesModEdition(ecr.Name)
        With Zoom_Grd
            .DataSource = Tbl_Editions
            .setFilter({0, 1})
            .Fit()
        End With
        oSize = Me.Size
        oLoc = Me.Location
    End Sub
    Private Sub Zoom_Grd_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Zoom_Grd.CellDoubleClick
        If e.RowIndex >= 0 Then ClickImpression(e.RowIndex)
    End Sub

    Sub ClickImpression(rowInd As Integer)
        Try
            Dim PathEdition As String = FindParam("Lecteur_Digital_Mod_Edition")
            Dim nrw() As DataRow = Tbl_Controle_Def_Ecran.Select("Name_Ecran='" & ecr.Name & "'")
            Dim TblModEdition As DataTable = DATA_READER_GRD("select * from Param_Mod_Edition_Criteres 
        where Cod_Report='" & Zoom_Grd.Item("Rapport", rowInd).Value & "' and Critere<>'idSoc'")
            Dim Crt As String = CnExecuting("select isnull((select isnull(Criteres,'') from Controle_Def_Ecran_Mod_Edition where Name_Ecran='" & ecr.Name & "' and Cod_Report='" & Zoom_Grd.Item("Rapport", rowInd).Value & "'),'')").Fields(0).Value
            Dim dfv As String = ""
            Dim rg As New System.Text.RegularExpressions.Regex("GV_[a-z]+\w+", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            If nrw.Length > 0 Then
                Dim f As New Zoom_Edition_Odbc
                If Crt <> "" Then
                    Dim crts() As String = Crt.Split({";"}, StringSplitOptions.RemoveEmptyEntries)

                    Dim chmps() As String = Nothing
                    For i = 0 To crts.Length - 1
                        chmps = crts(i).Trim.Split(":=")
                        If chmps.Length = 2 Then
                            chmps(0) = chmps(0).Trim.ToUpper
                            chmps(1) = chmps(1).Trim.Replace("=", "").ToUpper
                            If chmps(1).Contains("IDSOC") Then
                                f.ParamList.Add(chmps(0))
                                f.ValList.Add(Societe.id_Societe)
                            ElseIf chmps(1).StartsWith("GV_") Then
                                f.ParamList.Add(chmps(0))
                                f.ValList.Add(GlobalVar(chmps(1)))
                            ElseIf chmps(1).StartsWith("""") Then
                                f.ParamList.Add(chmps(0))
                                f.ValList.Add(chmps(1).Replace("""", "").Trim)
                            ElseIf IsNull(chmps(1), "").Trim = "" Then
                                f.ParamList.Add(chmps(0))
                                f.ValList.Add(chmps(1))
                            Else
                                Dim obj() As Object = ecr.Controls.Find(chmps(1), True)
                                If obj.Length > 0 Then
                                    f.ParamList.Add(chmps(0))

                                    Select Case True
                                        Case obj(0).GetType Is GetType(TextBox) Or obj(0).GetType Is GetType(DevComponents.DotNetBar.Controls.TextBoxX) Or obj(0).GetType Is GetType(ud_TextBox)
                                            f.ValList.Add(obj(0).Text)
                                        Case obj(0).GetType Is GetType(ComboBox) Or obj(0).GetType Is GetType(DevComponents.DotNetBar.Controls.ComboBoxEx) Or obj(0).GetType Is GetType(ud_ComboBox)
                                            f.ValList.Add(obj(0).SelectedValue)
                                        Case obj(0).GetType Is GetType(CheckBox) Or obj(0).GetType Is GetType(ud_CheckBox) Or obj(0).GetType Is GetType(ud_CheckBox)
                                            f.ValList.Add(obj(0).Checked)
                                    End Select
                                Else
                                    f.ParamList.Add(chmps(0))
                                    f.ValList.Add(chmps(1))
                                End If
                            End If
                        End If
                    Next
                ElseIf TblModEdition.Rows.Count > 0 Then
                    Dim obj() As Object = ecr.Controls.Find(nrw(0)("Index_Ecran"), True)
                    If obj.Length > 0 Then
                        With f
                            With TblModEdition
                                For i = 0 To .Rows.Count - 1
                                    f.ParamList.Add(.Rows(i)("Critere").ToString.ToUpper)
                                    dfv = .Rows(i)("Default_Value").ToString.ToUpper
                                    If i = 0 Then
                                        f.ValList.Add(obj(0).text)
                                    Else
                                        For Each c As System.Text.RegularExpressions.Match In rg.Matches(dfv)
                                            dfv = dfv.Replace(c.Value, GlobalVar(c.Value))
                                        Next
                                        f.ValList.Add(dfv)
                                    End If
                                Next
                            End With
                        End With
                    End If
                End If

                With f
                    .etat = PathEdition + "\" + Zoom_Grd.Item("Rapport", rowInd).Value + ".rpt"
                    If .ParamList.Contains("IDSOC") Then
                        Dim i As Integer = .ParamList.IndexOf("IDSOC")
                        .ValList(i) = Societe.id_Societe
                    Else
                        .ParamList.Add("IDSOC")
                        .ValList.Add(Societe.id_Societe)
                    End If
                    Dim isModal = False
                    Dim frmModal As New Ecran_Container
                    For Each frm In Application.OpenForms
                        If TypeOf frm Is Ecran_Container Then
                            ' Form1 is open
                            isModal = True
                            frmModal = frm
                            Exit For
                        End If
                    Next
                    If isModal Then
                        .Show(frmModal)
                    ElseIf theUser.Typ_Role = "Agent" Then
                        .Show(Menu_Agent)
                    Else
                        .Show(leMenu)
                    End If

                    System.Threading.Thread.Sleep(1000)
                    Me.Close()
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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