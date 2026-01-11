Public Class Zoom_AddModele
    Friend frm01 As New AI_KnowledgeBase
    Friend frm02 As New Zoom_Ai_EmbeddingConfig
    Private Sub Zoom_PPeriodeAjouter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btEnregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_ud.Click
        If modele_txt.Text = "" Then
            ShowMessageBox("Veuillez saisir le modèle.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If Provider_txt.Text.Trim = "" Then
            ShowMessageBox("Veuillez sélectionner le Provider.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If Typ_Modele_lbl.Text.Trim = "" Then
            ShowMessageBox("Veuillez sélectionner le Type de Modèle.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        Dim rs As New ADODB.Recordset
        rs.Open($"select * from Ai_{Typ_Modele_lbl.Text}_Modeles where Provider='{Provider_txt.Text }'", cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Provider").Value = Provider_txt.Text.Trim
            rs("Modele").Value = modele_txt.Text.Trim
        Else
            rs.Update()
        End If
        Dim modelesExistants As String = IsNull(rs("Modele").Value, "")
        If Not modelesExistants.Split("|"c).Contains(modele_txt.Text.Trim) Then
            If modelesExistants.Trim = "" Then
                rs("Modele").Value = modele_txt.Text.Trim
            Else
                rs("Modele").Value = modelesExistants & "|" & modele_txt.Text.Trim
            End If
        ElseIf modelesExistants.Split("|"c).Contains(modele_txt.Text.Trim) Then
            If modele_txt.ForeColor = Color.Red Then
                Dim lst As List(Of String) = modelesExistants.Split("|"c).ToList()
                lst.Remove(modele_txt.Text.Trim)
                rs("Modele").Value = String.Join("|", lst)
            End If
        End If
        rs("aiUrl").Value = Url_txt.Text.Trim
        rs.Update()
        rs.Close()
        MajModeles()
        Me.Close()
    End Sub
    Sub MajModeles()
        If Typ_Modele_lbl.Text = "LLM" Then
            frm01.Provider_cbo.FromSQL($"SELECT distinct Modele, Provider from Ai_LLM_Modeles order by Provider")
            frm01.Provider_cbo.Text = Provider_txt.Text.Trim
            frm01.Modele_cbo.Text = modele_txt.Text.Trim
        ElseIf Typ_Modele_lbl.Text = "Embedding" Then
            frm02.Provider_cbo.FromSQL($"SELECT distinct Modele, Provider from Ai_Embedding_Modeles order by Provider")
            frm02.Provider_cbo.Text = Provider_txt.Text.Trim
            frm02.Modele_cbo.Text = modele_txt.Text.Trim
        End If
    End Sub
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub

    Private Sub Supprimer_ud_Click(sender As Object, e As EventArgs) Handles Supprimer_ud.Click
        If Provider_txt.Text = "" Then
            ShowMessageBox("Veuillez saisir le modèle.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer ce modèle ?", "Confirmation", MessageBoxButtons.YesNo, msgIcon.Warning) = DialogResult.No Then
            Exit Sub
        End If
        CnExecuting($"DELETE FROM Ai_{Typ_Modele_lbl.Text}_Modeles WHERE Provider='{Provider_txt.Text}'")
        MajModeles()
        Me.Close()
    End Sub

    Private Sub DelModele_pb_Click(sender As Object, e As EventArgs) Handles DelModele_pb.Click
        If modele_txt.ForeColor = Color.Red Then
            ' Undelete/Restore state
            modele_txt.ForeColor = Color.Black
            modele_txt.Font = New Font(modele_txt.Font, FontStyle.Regular)
            DelModele_pb.Image = My.Resources.Resources.btn_delete
        Else
            ' Delete state
            modele_txt.ForeColor = Color.Red
            modele_txt.Font = New Font(modele_txt.Font, FontStyle.Strikeout)
            DelModele_pb.Image = My.Resources.Resources.btn_refresh
        End If
    End Sub
End Class