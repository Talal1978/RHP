Public Class ud_pathBar
    Dim _path As String = ""
    Sub New()
        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        ' Ajoutez une Initialisation quelconque après l'appel InitializeComponent().
    End Sub
    Function Path(nameEcr As String) As String
        Dim _path As String = ""
        Dim prw As DataRow() = Tbl_Controle_TreeView.Select("Name_Ecran='" & nameEcr & "'")
        If prw.Length > 0 Then
            _path = prw(0)("Racine")
        End If
        path_pnl.Controls.Clear()
        DB_lbl.Text = Societe.Denomination & " (" & Societe.id_Societe & ")"
        Dim ecr() As String = _path.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        If ecr.Length > 0 Then
            Dim nrw() As DataRow = Tbl_Controle_Droit_Mnu.Select("Name_Ecran in ('" & String.Join("','", ecr) & "')")
            If nrw.Length > 0 Then
                Dim _tbl As DataTable = nrw.CopyToDataTable()
                For i = ecr.Length - 2 To 0 Step -1
                    nrw = _tbl.Select("Name_Ecran ='" & ecr(i) & "'")
                    If nrw.Length > 0 Then
                        Dim lb As New Label
                        With lb
                            .Name = ecr(i)
                            .Text = nrw(0)("Text_Ecran")
                            .Tag = nrw(0)("Typ_Ecran")
                            .AutoSize = True
                            .Cursor = Cursors.Hand
                            .Dock = DockStyle.Left
                            .Font = DB_lbl.Font
                            .ForeColor = DB_lbl.ForeColor
                            .Location = New Point(0, 0)
                            .MinimumSize = New Size(25, path_pnl.Height - 2)
                            .TextAlign = ContentAlignment.MiddleLeft
                            .Padding = New Padding(0)
                            .Margin = New Padding(0)
                        End With
                        path_pnl.Controls.Add(lb)
                        If i > 0 Then
                            Dim sep As New Label
                            With sep
                                .AutoSize = False
                                .Dock = DockStyle.Left
                                .Font = Separateur_lbl.Font
                                .ForeColor = Separateur_lbl.ForeColor
                                .Location = New Point(47, 0)
                                .MaximumSize = Separateur_lbl.MaximumSize
                                .MinimumSize = Separateur_lbl.MinimumSize
                                .TextAlign = Separateur_lbl.TextAlign
                                .Padding = Separateur_lbl.Padding
                                .Size = Separateur_lbl.Size
                                .TabIndex = 1
                                .Text = ">"
                                .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                                .Padding = New Padding(0)
                                .Margin = New Padding(0)
                                path_pnl.Controls.Add(sep)
                            End With
                        End If
                    End If

                Next
            End If
        End If
        Return _path
    End Function

    Private Sub DB_lbl_Click(sender As Object, e As EventArgs) Handles DB_lbl.Click
        If Societe.id_Societe > 0 Then
            If leMenu.pnl_PersonnalContent.Controls.Contains(Menu_Operationnel) Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=" & Societe.id_Societe & " and Process_Id=" & ProcessId)
                Menu_Operationnel.BringToFront()
            Else
                newShowEcran(Menu_Operationnel)
            End If
        End If
    End Sub

    Private Sub pb_Back_MouseEnter(sender As Object, e As EventArgs) Handles pb_Back.MouseEnter
        pb_Back.Image = ConvertToTargetColor(My.Resources.btn_back, True)
    End Sub

    Private Sub pb_Back_MouseLeave(sender As Object, e As EventArgs) Handles pb_Back.MouseLeave
        pb_Back.Image = My.Resources.btn_back
    End Sub
    Private Sub pb_Refresh_MouseEnter(sender As Object, e As EventArgs) Handles pb_Refresh.MouseEnter
        pb_Refresh.Image = ConvertToTargetColor(My.Resources.btn_request, True)
    End Sub

    Private Sub pb_Refresh_MouseLeave(sender As Object, e As EventArgs) Handles pb_Refresh.MouseLeave
        pb_Refresh.Image = My.Resources.btn_request
    End Sub
    Private Sub pb_Back_Click(sender As Object, e As EventArgs) Handles pb_Back.Click
        goBack()
    End Sub
    Private Sub pb_Refresh_Click(sender As Object, e As EventArgs) Handles pb_Refresh.Click
        InitialisationGlobale()
    End Sub
End Class
