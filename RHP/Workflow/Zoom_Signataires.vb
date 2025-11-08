Public Class Zoom_Signataires
    Dim oSize As New Size
    Dim oLoc As New Point
    Friend Indx As String = ""
    Friend TypDoc As String = ""
    Friend frm As New Form
    Friend btn_Signature As mybtn_Signature
    Dim Operande_Signature As String = "ET"
    Dim signatureStr As String = "<font color=""green"">(+)Signer</font>&nbsp;&nbsp;&nbsp;<font color=""red"">(-)Rejeter</font>"
    Dim signerWidth As Integer = 0
    Dim rejeterStart As Integer = 0
    Dim leStatut As String = ""
    Dim Titre As String = "Liste des signataire"
    Dim dansOrdre As Boolean = False
    Private Sub Zoom_Escape(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub
    Private Sub Zoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not CBool(LicenceJson.WorkFlow) Then
            ShowMessageBox("Le module 'Workflow'  n'est pas activé pour votre licence.", "Licence", MessageBoxButtons.OK, msgIcon.Stop)
            Me.Close()
            Return
        End If
        If Not btn_Signature Is Nothing Then
            TypDoc = btn_Signature.tbl.rows(0)("Typ_Document")
            Indx = btn_Signature.valeurIndex
            frm = btn_Signature.frm
        End If
        Dim sqlSign = "select Statut, Typ_Signature,Operande_Signature, Dans_Ordre, e.Num_Ligne, 
Signataire,Nom, Decision, Dat_Signature , l.RowId, e.Statut , commentaire
from Signatures_Ent e left join Signatures_Lig l on e.Typ_Document=l.Typ_Document and e.id_Societe=l.id_Societe and e.Valeur_Index=l.Valeur_Index and e.Num_Ligne=l.Num_Ligne
outer apply (select ltrim(rtrim(isnull(Prenom_Agent,'')+' '+isnull(Nom_Agent,''))) as Nom from Rh_agent where Matricule=Signataire and id_Societe=e.id_Societe)u
where e.Typ_Document='" & TypDoc & "' and e.Valeur_Index='" & Indx & "' and e.id_Societe=" & Societe.id_Societe & "
order by RowId"
        Dim Tbl As DataTable = DATA_READER_GRD(sqlSign)
        With Grd
            .Rows.Clear()
            Dim C1, C2, C3, C4, C5 As Object
            Dim estSignataire As Boolean = True
            Dim img As New Bitmap(1, 1)
            Dim g As Graphics = Graphics.FromImage(img)
            With Tbl
                If .Rows.Count > 0 Then
                    leStatut = IsNull(.Rows(0)("Statut"), "")
                    Operande_Signature = IsNull(.Rows(0)("Operande_Signature"), "ET")
                    dansOrdre = (IsNull(.Rows(0)("Dans_Ordre"), False) And (Operande_Signature = "ET"))
                    For i = 0 To .Rows.Count - 1
                        C1 = .Rows(i)("Signataire")
                        C2 = .Rows(i)("Nom")
                        C3 = IsNull(.Rows(i)("Decision"), "").Trim
                        If C3 = "" And IsNull(.Rows(i)("Statut"), "").Trim <> "SG" And IsNull(.Rows(i)("Statut"), "").Trim <> "RJ" Then
                            estSignataire = (IsNull(.Rows(i)("Signataire"), "").ToUpper = theUser.Matricule.ToUpper Or IsNull(.Rows(i)("Signataire"), "").ToUpper = theUser.Login.ToUpper)
                            If dansOrdre Then
                                If estSignataire Then
                                    If i > 0 Then
                                        estSignataire = (IsNull(.Rows(i - 1)("Decision"), "") <> "")
                                    End If
                                End If
                            End If
                            If estSignataire Then
                                C3 = signatureStr
                            End If
                        End If
                        C3 = IIf(C3 = "SG" Or C3 = "RJ", FindRubriques("Decision_Signature", C3), C3)
                        C4 = IsNull(.Rows(i)("Commentaire"), "")
                        C5 = .Rows(i)("Dat_Signature")
                        Grd.Rows.Add(C1, C2, C3, C4, C5)
                        Grd.Rows(i).Tag = .Rows(i)("RowId")
                        Grd.Rows(i).ReadOnly = Not estSignataire
                    Next
                End If
            End With
            signerWidth = g.MeasureString("(+)Signer", .Font).Width
            rejeterStart = signerWidth + 16
            Titre_lbl.Text = Titre & If(dansOrdre, " dans l'ordre ", "") & If(Operande_Signature.ToUpper = "ET", "", " (par un des signataires) ")
            .Fit()
        End With
    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
    Private Sub Normalize_D_Click(sender As Object, e As EventArgs) Handles Normalize_pb.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Size = oSize
            Me.Location = oLoc
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Private Sub Grd_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd.CellMouseClick
        Dim decide As Boolean = False
        If e.ColumnIndex = Decision.Index Then
            With Grd
                If .Item(Decision.Index, e.RowIndex).Value = signatureStr Then
                    Dim rtg As Rectangle = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                    If e.X <= signerWidth Then
                        If ShowMessageBox("Etes-vous sûr de vouloir signer?", "Confirmation de signature", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.OK Then
                            CnExecuting("update Signatures_Lig set Decision='SG', Dat_Signature=getdate() where RowId=" & Grd.Rows(e.RowIndex).Tag)
                            decide = True
                        End If
                    ElseIf e.X >= rejeterStart Then
                        If ShowMessageBox("Etes-vous sûr de vouloir rejeter la signature?", "Confirmation de rejet", MessageBoxButtons.OKCancel, msgIcon.Stop) = DialogResult.OK Then
                            CnExecuting("update Signatures_Lig set Decision='RJ', Dat_Signature=getdate() where RowId=" & Grd.Rows(e.RowIndex).Tag)
                            decide = True
                        End If
                    End If
                End If
                If decide Then
                    Dim Tbl As DataTable = DATA_READER_GRD("Sys_Workflow_Maj_Statut_Signature '" & TypDoc & "','" & Societe.id_Societe & "','" & Indx & "'")
                    'If Tbl.Rows.Count > 0 Then
                    '    Dim Statut As String = IsNull(Tbl.Rows(0)(0), "")
                    '    If Statut <> "" Then
                    '        If Statut = "SG" Or Statut = "RJ" Then
                    '            If Not CallByName(frm, "SignatureEffect", CallType.Method) Then
                    '                CnExecuting("update Signatures_Lig set Decision='', Dat_Signature=null where RowId=" & Grd.Rows(e.RowIndex).Tag)
                    '                CnExecuting("update Signatures_Ent set Statut ='" & leStatut & "' where Typ_Document='" & TypDoc & "' and id_Societe='" & Societe.id_Societe & "' and Valeur_Index ='" & Indx & "'")
                    '            End If
                    '        End If
                    '    End If
                    'End If
                    Me.Close()
                End If
            End With
        End If
    End Sub

    Private Sub Grd_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        If e.RowIndex < 0 Then
            Grd.Cursor = Cursors.Default
            Return
        End If
        If e.ColumnIndex = Decision.Index Then
            With Grd
                If .Item(Decision.Index, e.RowIndex).Value = signatureStr Then
                    Dim rtg As Rectangle = sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                    If e.X <= signerWidth Then
                        .Cursor = Cursors.Hand
                    ElseIf e.X >= rejeterStart Then
                        .Cursor = Cursors.Hand
                    Else
                        .Cursor = Cursors.Default
                    End If
                Else
                    .Cursor = Cursors.Default
                End If
            End With
        Else
            Grd.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Zoom_Signataires_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim rs As New ADODB.Recordset
        With Grd
            For i = 0 To .Rows.Count - 1
                rs.Open("select * from Signatures_Lig where RowId=" & Grd.Rows(i).Tag, cn, 2, 2)
                rs.Update()
                rs("Commentaire").Value = IsNull(.Item(commentaire.Index, i).Value, "")
                rs.Update()
                rs.Close()
            Next
        End With
        If Not btn_Signature Is Nothing Then
            Dim statut As String = CnExecuting("select isnull((select isnull(Statut,'NSS') as Statut from Signatures_Ent where Typ_Document= '" & TypDoc & "' and id_Societe='" & Societe.id_Societe & "'  and Valeur_Index='" & Indx & "'),'NSS') as Statut").Fields(0).Value
            btn_Signature.statut = statut
            btn_Signature.ToolTip = FindRubriques("Statut_Signature", statut)
            btn_Signature.Refresh()
        end If
    end Sub
End Class