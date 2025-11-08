Public Class Org_Poste_Old
    Dim TblPoste As New DataTable
    Dim TblPosteUsed As New DataTable
    Friend WithEvents JobDescription_rtb As New ud_RT
    Dim dicPost As New Dictionary(Of String, Dictionary(Of String, String))
    Dim Save_D As ud_btn
    Dim _laLigne As Integer = -1
    Sub Chargement()
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
        End If
    End Sub
    Private Sub Org_Poste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Poste_Grd
            .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        End With
        TblPosteUsed = DATA_READER_GRD("SELECT distinct Cod_Poste from RH_Agent where isnull(Cod_Poste,'')<>'' and id_Societe=" & Societe.id_Societe)
        Request()

    End Sub
    Sub Request()
        dicPost.Clear()
        Domaines_Competence_Pnl.Controls.Clear()
        Domaines_Competence_Pnl.Text = ""
        _laLigne = -1
        Poste_Grd.Rows.Clear()
        Dim CodSql As String = "SELECT   Cod_Poste, Lib_Poste,Cod_Grade,Lib_Grade, JobDescription,isnull(Domaines_Competence,'') Domaines_Competence, cast(case when isnull(nb,0)>0 then 1 else 0 end as bit) as 'ReadOnly'  
                                FROM Org_Poste f
                                outer apply (select count(*) nb from Rh_Agent where id_Societe=f.id_Societe and isnull(Cod_Poste,'')=f.Cod_Poste) r
                                outer apply (select Lib_Grade from Org_Grade where Cod_Grade=f.Cod_Grade  and id_Societe=f.id_Societe) g 
                                where id_Societe=" & Societe.id_Societe & " order by Lib_Poste"
        TblPoste = DATA_READER_GRD(CodSql)
        With TblPoste
            For i = 0 To .Rows.Count - 1
                Poste_Grd.Rows.Add(IsNull(.Rows(i)("Cod_Poste"), ""), IsNull(.Rows(i)("Lib_Poste"), ""), IsNull(.Rows(i)("Cod_Grade"), ""), IsNull(.Rows(i)("Lib_Grade"), ""))
                Poste_Grd.Item(Cod_Poste.Index, i).ReadOnly = (TblPosteUsed.Select("Cod_Poste='" & .Rows(i)("Cod_Poste").replace("'", "''") & "'").Length > 0)
                dicPost.Add(IsNull(.Rows(i)("Cod_Poste"), ""), New Dictionary(Of String, String) From {{"JobDescription", IsNull(.Rows(i)("JobDescription"), "")}, {"Domaines_Competence", IsNull(.Rows(i)("Domaines_Competence"), "")}})

                If i = 0 Then
                    LireJobDiscription()
                End If
                If CBool(.Rows(i)("ReadOnly")) Then
                    With Poste_Grd.Rows(i)
                        .ReadOnly = True
                        .DefaultCellStyle.ForeColor = Color.Gray
                    End With
                End If
            Next
        End With

    End Sub
    Private Sub Poste_Grd_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Poste_Grd.CellMouseClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return
        ValiderRtf()
        _laLigne = e.RowIndex
        LireJobDiscription()
        If e.ColumnIndex = Lib_Grade.Index Then
            Appel_Zoom1("MS015", Poste_Grd.Item(Cod_Grade.Index, e.RowIndex), Me, "", "", Poste_Grd.Item(Lib_Grade.Index, e.RowIndex))
            Poste_Grd.Item(Lib_Grade.Index, e.RowIndex).Value = FindLibelle("Lib_Grade", "Cod_Grade", Poste_Grd.Item(Cod_Grade.Index, e.RowIndex).Value, "Org_Grade")
        Else
            If _isCollapsed Then Collapse()
        End If
    End Sub
    Sub LireJobDiscription()
        With Poste_Grd
            If .Rows.Count = 0 Then Return
            If .CurrentCell Is Nothing Then Return
            If _laLigne = -1 Then _laLigne = .CurrentRow.Index
            If IsNull(.Item(Cod_Poste.Index, _laLigne).Value, "") = "" Then Return
            If Not dicPost.ContainsKey(.Item(Cod_Poste.Index, _laLigne).Value) Then
                dicPost.Add(IsNull(.Item(Cod_Poste.Index, _laLigne).Value, ""), New Dictionary(Of String, String) From {{"JobDescription", ""}, {"Domaines_Competence", ""}})
            End If
            If IsNull(dicPost(.Item(Cod_Poste.Index, _laLigne).Value)("JobDescription"), "") = "" Then
                JobDescription_rtb.Rtb.LoadDocument(My.Application.Info.DirectoryPath & "\rsc\jd.rtf")
            Else
                JobDescription_rtb.Rtb.RtfText = dicPost(.Item(Cod_Poste.Index, _laLigne).Value)("JobDescription")
            End If
            Domaines_Competence_Pnl.Text = dicPost(.Item(Cod_Poste.Index, _laLigne).Value)("Domaines_Competence")
            RequestDomaineCompetences()
            With Titre_lbl
                .Text = IsNull(Poste_Grd.Item(Lib_Poste.Index, _laLigne).Value, "")
                .Tag = .Text
                .Refresh()
            End With
        End With
    End Sub
    Private Sub JobDescription_rtb_Validated(sender As Object, e As EventArgs) Handles JobDescription_rtb.Validated
        ValiderRtf()
    End Sub
    Sub ValiderRtf()
        With Poste_Grd
            If .Rows.Count = 0 Then Return
            If _laLigne < 0 Then Return
            If IsNull(.Item(Cod_Poste.Index, _laLigne).Value, "") = "" Then Return
            If Not dicPost.ContainsKey(.Item(Cod_Poste.Index, _laLigne).Value) Then Return
            dicPost(.Item(Cod_Poste.Index, _laLigne).Value)("JobDescription") = JobDescription_rtb.Rtb.RtfText
            Domaines_Competence_Pnl.Text = ""
            For Each cnt As ud_Domaine_Competence In Domaines_Competence_Pnl.Controls
                Domaines_Competence_Pnl.Text &= If(String.IsNullOrWhiteSpace(Domaines_Competence_Pnl.Text), "", ";") & cnt.Name & "$" & cnt.Rating()
            Next
            dicPost(.Item(Cod_Poste.Index, _laLigne).Value)("Domaines_Competence") = Domaines_Competence_Pnl.Text
        End With
    End Sub
    Function Saving() As Boolean
        Try
            ValiderRtf()
            Dim rs As New ADODB.Recordset
            Dim swhere As String = ""
            With Poste_Grd
                For i = 0 To .RowCount - 1
                    If Not .Rows(i).ReadOnly Then
                        If IsNull(.Item(Cod_Poste.Index, i).Value, "").Trim <> "" Then
                            If IsNull(.Item(Lib_Poste.Index, i).Value, "").Trim = "" Then
                                ShowMessageBox("Erreur :" & vbCrLf & "Intitulé de poste vide", Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
                                .Rows(i).Selected = True
                                .FirstDisplayedCell = .Item(Cod_Poste.Index, i)
                                Return False
                            End If
                            swhere &= IIf(swhere = "", "", ",") & "'" & .Item(Cod_Poste.Index, i).Value & "'"
                        End If
                    End If
                Next
                If swhere <> "" Then
                    CnExecuting("delete Org_Poste where Cod_Poste not in (" & swhere & ") and not exists(select Matricule from Rh_Agent where id_Societe=Org_Poste.id_Societe and isnull(Cod_Poste,'')=Org_Poste.Cod_Poste) and id_Societe=" & Societe.id_Societe)
                Else
                    CnExecuting("delete Org_Poste where not exists(select Matricule from Rh_Agent where id_Societe=Org_Poste.id_Societe and isnull(Cod_Poste,'')=Org_Poste.Cod_Poste) and id_Societe=" & Societe.id_Societe)
                End If
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(Cod_Poste.Index, i).Value, "").Trim <> "" Then
                        rs.Open("select * from Org_Poste where Cod_Poste='" & .Item(Cod_Poste.Index, i).Value & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
                        If rs.EOF Then
                            rs.AddNew()
                            rs("id_Societe").Value = Societe.id_Societe
                            rs("Cod_Poste").Value = .Item(Cod_Poste.Index, i).Value
                        Else
                            rs.Update()
                        End If
                        rs("Lib_Poste").Value = .Item(Lib_Poste.Index, i).Value
                        rs("Cod_Grade").Value = .Item(Cod_Grade.Index, i).Value
                        rs("JobDescription").Value = If(dicPost.ContainsKey(.Item(Cod_Poste.Index, i).Value), dicPost(.Item(Cod_Poste.Index, i).Value)("JobDescription"), "")
                        rs("Domaines_Competence").Value = If(dicPost.ContainsKey(.Item(Cod_Poste.Index, i).Value), dicPost(.Item(Cod_Poste.Index, i).Value)("Domaines_Competence"), "")
                        rs.Update()
                        rs.Close()
                    End If
                Next
            End With
            Return True
        Catch ex As Exception
            ShowMessageBox("Erreur :" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End Try
    End Function
    Private Sub Poste_Grd_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles Poste_Grd.UserDeletingRow
        With Poste_Grd
            e.Cancel = .Item(Cod_Poste.Index, e.Row.Index).ReadOnly
        End With
    End Sub
    Sub Nouveau()
        With Poste_Grd
            .FirstDisplayedCell = .Item(Cod_Poste.Index, .RowCount - 1)
            .CurrentCell = .Item(Cod_Poste.Index, .RowCount - 1)
            .BeginEdit(True)
        End With
    End Sub
    Private Sub Poste_Grd_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Poste_Grd.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        If e.ColumnIndex = Lib_Grade.Index Then
            Poste_Grd.Cursor = Cursors.Hand
        Else
            Poste_Grd.Cursor = Cursors.Default
        End If
    End Sub
    Sub Collapse()
        With Ent_pnl
            If Not _isCollapsed Then
                .Size = New System.Drawing.Size(36, Height)
                .RowCount = 2
                .ColumnCount = 1
                .RowStyles.Clear()
                .ColumnStyles.Clear()
                .RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
                .RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
                .ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
                .Controls.Clear()
                .Controls.Add(Me.Menu_pb, 0, 0)
                .Controls.Add(Me.Titre_lbl, 0, 1)
                .Dock = System.Windows.Forms.DockStyle.Right
                .Margin = New System.Windows.Forms.Padding(0)
                Pnl_Jobdescription.Size = .Size
            Else
                If Not Pnl_Jobdescription.Controls.Contains(JobDescription_rtb) Then
                    With JobDescription_rtb
                        .Dock = System.Windows.Forms.DockStyle.Fill
                        .Location = New System.Drawing.Point(0, 36)
                        .Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
                        .Name = "JobDescription_rtb"
                        .Size = New System.Drawing.Size(739, 564)
                        .TabIndex = 0
                    End With
                    Pnl_Jobdescription.Controls.Add(JobDescription_rtb)
                    JobDescription_rtb.BringToFront()
                End If
                .Size = New Size(Width * 0.65, 36)
                .ColumnCount = 2
                .RowCount = 1
                .RowStyles.Clear()
                .ColumnStyles.Clear()
                .ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
                .ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
                .RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
                .Controls.Clear()
                .Controls.Add(Me.Menu_pb, 0, 0)
                .Controls.Add(Me.Titre_lbl, 1, 0)
                .Dock = System.Windows.Forms.DockStyle.Top
                .Margin = New System.Windows.Forms.Padding(0)
                Pnl_Jobdescription.Size = New System.Drawing.Size(Width * 0.65, Height)
            End If
        End With
        _isCollapsed = Not _isCollapsed
        With JobDescription_rtb
            .Visible = Not _isCollapsed
        End With
        With Titre_lbl
            .Invalidate()
        End With
    End Sub
    Dim _isCollapsed As Boolean = True
    Private Sub Menu_pb_Click(sender As Object, e As EventArgs) Handles Menu_pb.Click
        Collapse()
    End Sub
    Private Sub Titre_lbl_Paint(sender As Object, e As PaintEventArgs) Handles Titre_lbl.Paint
        If _isCollapsed Then
            Titre_lbl.Text = ""
            Dim brc As New SolidBrush(Titre_lbl.ForeColor)
            e.Graphics.TranslateTransform(CSng(Titre_lbl.Width / 2), CSng(Titre_lbl.Height / 2) + 10)
            e.Graphics.RotateTransform(90)
            e.Graphics.DrawString(Titre_lbl.Tag, Titre_lbl.Font, brc, New Point(0, 0))
            e.Graphics.ResetTransform()
        Else
            Titre_lbl.Text = Titre_lbl.Tag
        End If
    End Sub
    Private Sub Comptence_Pnl_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Domaines_Competence_Pnl.MouseDoubleClick
        Dim laListe = IsNull(Domaines_Competence_Pnl.Text, "").Split(";").ToList()
        Dim f As New Zoom_GPEC_Domaines_Competence
        With f
            .domaines = laListe
            .ShowDialog()
        End With
        Dim domList = stringToDictionary(String.Join(";"c, laListe)).Keys()
        For i = Domaines_Competence_Pnl.Controls.Count - 1 To 0 Step -1
            If Not domList.Contains(Domaines_Competence_Pnl.Controls(i).Name) Then
                Domaines_Competence_Pnl.Controls.RemoveAt(i)
            End If
        Next
        For Each c In laListe
            If Not String.IsNullOrWhiteSpace(c) Then
                If Domaines_Competence_Pnl.Controls.Find(c.Split("$")(0), True).Length = 0 Then
                    AddCompetence(c)
                End If
            End If
        Next
        RearrangeControls()
        Domaines_Competence_Pnl.Text = String.Join(";", laListe)
        ValiderRtf()
    End Sub
    Sub AddCompetence(competenceName As String)
        If String.IsNullOrWhiteSpace(competenceName) Then Return
        Dim nomCom As String = ""
        Dim note As Double = 1
        Dim _rw = competenceName.Split("$"c)
        nomCom = _rw(0)
        If _rw.Length > 1 Then
            If IsNumeric(_rw(1)) Then note = CDbl(_rw(1))
        End If
        Dim ud As New ud_Domaine_Competence
        With ud
            .canRate = True
            .Nom = nomCom
            .Rating = note
            Domaines_Competence_Pnl.Controls.Add(ud)
        End With
    End Sub
    Public Sub RearrangeControls()
        Dim x, y, sp As Integer
        sp = 5 ' Espace entre les contrôles
        x = sp
        y = sp

        Dim controlHeight As Integer = 0 ' Utilisé pour suivre la hauteur du dernier contrôle traité
        Domaines_Competence_Pnl.Text = ""
        For Each cnt As ud_Domaine_Competence In Domaines_Competence_Pnl.Controls
            If controlHeight = 0 Then
                controlHeight = cnt.Height ' Initialisez avec la hauteur du premier contrôle si non défini
            End If

            ' Calculez la nouvelle position x, y pour le contrôle actuel
            If x + cnt.Width + sp <= Domaines_Competence_Pnl.Width Then
                ' Assez d'espace pour placer ce contrôle à côté du précédent
                cnt.Location = New Point(x, y)
                x += cnt.Width + sp
            Else
                ' Pas assez d'espace, revenez au début et déplacez vers le bas
                x = sp
                y += controlHeight + sp
                cnt.Location = New Point(x, y)
                x += cnt.Width + sp
            End If
            Domaines_Competence_Pnl.Text &= If(String.IsNullOrWhiteSpace(Domaines_Competence_Pnl.Text), "", ";") & cnt.Name & "$" & cnt.Rating()
        Next
    End Sub
    Sub SuppressionDomaine(ud As ud_Domaine_Competence)
        Domaines_Competence_Pnl.Controls.Remove(ud)
        RearrangeControls()
    End Sub

    Private Sub Domaines_Competence_Pnl_SizeChanged(sender As Object, e As EventArgs) Handles Domaines_Competence_Pnl.SizeChanged
        RearrangeControls()
    End Sub

    Sub RequestDomaineCompetences()
        Domaines_Competence_Pnl.Controls.Clear()
        Dim laListe = IsNull(Domaines_Competence_Pnl.Text, "").Split(";").ToList()
        If laListe.Count > 0 Then
            For Each c In laListe
                If Not String.IsNullOrWhiteSpace(c) Then
                    If Domaines_Competence_Pnl.Controls.Find(c, True).Length = 0 Then
                        AddCompetence(c)
                    End If
                End If
            Next
            RearrangeControls()
        End If
    End Sub

    Private Sub Poste_Grd_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Poste_Grd.CellValidated
        With Poste_Grd
            If e.ColumnIndex = Cod_Poste.Index Then
                If e.RowIndex < 0 Then
                    _laLigne = -1
                    Return
                End If
                If IsNull(.Item(Cod_Poste.Index, e.RowIndex).Value, "") = "" Then Return
                If _laLigne <> e.RowIndex Then
                    ValiderRtf()
                    _laLigne = e.RowIndex
                    LireJobDiscription()
                End If
            End If
        End With
    End Sub
End Class