Public Class Zoom_Ai_EmbeddingConfig
    Dim configModified As Boolean = False
    Private Sub Zoom_Ai_EmbeddingConfig_Load(sender As Object, e As EventArgs) Handles Me.Load
        Request()
    End Sub
    Sub Request()
        chargement()
        Dim Tbl As DataTable = DATA_READER_GRD($"SELECT top 1 * FROM Ai_Embedding WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe})={Societe.id_Societe} order by id_Societe")
        With Tbl
            If .Rows.Count > 0 Then
                Dim Dr As DataRow = .Rows(0)
                If Not IsDBNull(Dr("Provider")) Then
                    Provider_cbo.Text = Dr("Provider")
                End If
                If Not IsDBNull(Dr("Modele")) Then
                    Modele_cbo.Text = Dr("Modele")
                End If
                AiUrl_txt.Text = IsNull(Dr("AiUrl"), "")
                ApiKey_txt.Text = IsNull(Dr("ApiKey"), "")
            Else
                Provider_cbo.SelectedIndex = -1
                Modele_cbo.SelectedIndex = -1
                AiUrl_txt.Text = ""
                ApiKey_txt.Text = ""
            End If
        End With
        configModified = False
    End Sub
    Sub chargement()
        If Provider_cbo.Items.Count = 0 Then
            Provider_cbo.FromSQL("SELECT distinct Modele, Provider from Ai_Embedding_Modeles order by Provider")
        End If

    End Sub
    Private Sub Cbo_Provider_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Provider_cbo.SelectedIndexChanged
        chargement()
        Modele_cbo.Items.Clear()
        If Provider_cbo.SelectedIndex = -1 Then Exit Sub
        Dim strModeles As String = Provider_cbo.SelectedValue
        For Each modele As String In strModeles.Split("|"c)
            Modele_cbo.Items.Add(modele.Trim())
        Next
        configModified = True
        AiUrl_txt.Tag = FindLibelle("aiUrl", "Provider", Provider_cbo.Text, "Ai_Embedding_Modeles")
    End Sub
    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Try
            If Provider_cbo.SelectedIndex = -1 Then
                ShowMessageBox("Veuillez sélectionner un fournisseur.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                Exit Sub
            End If
            If Modele_cbo.SelectedIndex = -1 Then
                ShowMessageBox("Veuillez sélectionner un modèle.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                Exit Sub
            End If
            If AiUrl_txt.Text.Trim() = "" Then
                ShowMessageBox("Veuillez entrer l'URL de l'API.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                Exit Sub
            End If
            Dim supprimerDonneeObsolete As Boolean = False

            If CnExecuting($"select count(*) from Ai_KnowledgeBase where ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe})={Societe.id_Societe} and isnull(Provider_Used,'')!='{Provider_cbo.Text}' or isnull(Modele_Used,'')!='{Modele_cbo.Text}'").Fields(0).Value > 0 Then
                If ShowMessageBox("Votre base de connaissances contient des données traitées avec un modèle différent,
                            si vous modifiez la configuration vous devez supprimer les données obsolètes.
                            Voulez-vous que le système les supprime pour vous?.", "Vérification", MessageBoxButtons.OKCancel, msgIcon.Stop) = MsgBoxResult.Cancel Then Return
                Exit Sub
                supprimerDonneeObsolete = True
            End If
            If configModified Then
                ShowMessageBox("Veuillez tester la connection d'abord.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                Exit Sub
            End If
            Dim idSociete = If(Global_chk.Checked, -1, Societe.id_Societe)
            Dim provider = Provider_cbo.Text?.ToString().Replace("'", "''")
            Dim modele = Modele_cbo.Text?.ToString().Replace("'", "''")
            Dim aiUrl = AiUrl_txt.Text.Trim().Replace("'", "''")
            Dim apiKey = ApiKey_txt.Text.Trim().Replace("'", "''")
            Dim sql = $"delete FROM Ai_Embedding WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe})={Societe.id_Societe}
                    INSERT INTO Ai_Embedding (id_Societe, Provider, Modele, AiUrl, ApiKey)
                    VALUES ({idSociete}, '{provider}', '{modele}', '{aiUrl}', '{apiKey}')"
            If supprimerDonneeObsolete Then
                sql &= $"
                    DELETE FROM Ai_KnowledgeBase WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe})={Societe.id_Societe} and isnull(Provider_Used,'')!='{Provider_cbo.Text}' or isnull(Modele_Used,'')!='{Modele_cbo.Text}'"
            End If
            CnExecuting(sql)

            ' Mettre à jour le singleton immédiatement

            With Ai_Embedding.Instance.Config
                .Provider = Provider_cbo.Text
                .Modele = Modele_cbo.Text
                .Url = AiUrl_txt.Text.Trim()
                .ApiKey = ApiKey_txt.Text.Trim()
            End With
            ShowMessageBox("Configuration enregistrée avec succès.", "Succès", MessageBoxButtons.OK, msgIcon.Information)
        Catch ex As Exception
            Debug.WriteLine("Erreur lors de la mise à jour du singleton: " & ex.Message)
        End Try


    End Sub

    Private Async Sub TesterConn_pb_Click(sender As Object, e As EventArgs) Handles TesterConn_pb.Click

        ' Récupérer les valeurs du formulaire
        Dim provider = Provider_cbo.Text
        Dim modele = Modele_cbo.Text
        Dim aiUrl = AiUrl_txt.Text.Trim()
        Dim apiKey = ApiKey_txt.Text.Trim()

        ' Validation
        If String.IsNullOrEmpty(provider) OrElse String.IsNullOrEmpty(aiUrl) Then
            ShowMessageBox("Veuillez sélectionner un provider et une URL.", "Validation", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If

        ' Configurer temporairement
        Dim oldConfig = Ai_Embedding.Instance.Config
        Ai_Embedding.Instance.Config = New Ai_Embedding.EmbeddingConfig() With {
            .Provider = provider,
            .Url = aiUrl,
            .Modele = modele,
            .ApiKey = apiKey,
            .TimeoutSeconds = 30,
            .RetryCount = 1
        }

        ' Tester
        Cursor = Cursors.WaitCursor
        TesterConn_pb.Enabled = False
        Save_pb.Enabled = False
        Close_pb.Enabled = False
        Try
            Dim result = Await Ai_Embedding.Instance.TestConnectionAsync()

            If result.Success Then
                ShowMessageBox(
                    $"✅ Connexion réussie !" & vbCrLf & vbCrLf &
                    $"Provider: {result.Provider}" & vbCrLf &
                    $"Modèle: {result.Modele}" & vbCrLf &
                    $"Dimension: {result.Dimension}" & vbCrLf &
                    $"Latence: {result.LatencyMs} ms",
                    "Test API",
                    MessageBoxButtons.OK,
                    msgIcon.Information)
                configModified = False
            Else
                ShowMessageBox(
                    $"❌ Échec de connexion" & vbCrLf & vbCrLf &
                    $"Erreur: {result.Message}",
                    "Test API",
                    MessageBoxButtons.OK,
                    msgIcon.Stop)
            End If

        Catch ex As Exception
            ShowMessageBox(
                $"❌ Erreur: {ex.Message}",
                "Test API",
                MessageBoxButtons.OK,
                msgIcon.Stop)
        Finally
            Ai_Embedding.Instance.Config = oldConfig
            Cursor = Cursors.Default
            TesterConn_pb.Enabled = True
            Save_pb.Enabled = True
            Close_pb.Enabled = True
        End Try
    End Sub

    Private Sub Modele_cbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Modele_cbo.SelectedIndexChanged
        AiUrl_txt.Text = IsNull(AiUrl_txt.Tag, "").Replace("{MODEL}", Modele_cbo.Text)
        configModified = True
    End Sub

    Private Sub AiUrl_txt_TextChanged(sender As Object, e As EventArgs) Handles AiUrl_txt.TextChanged
        configModified = True
    End Sub

    Private Sub ApiKey_txt_TextChanged(sender As Object, e As EventArgs) Handles ApiKey_txt.TextChanged
        configModified = True
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub

    Private Sub AddModele_pb_Click(sender As Object, e As EventArgs) Handles AddModele_pb.Click
        Dim f As New Zoom_AddModele
        With f
            .Typ_Modele_lbl.Text = "Embedding"
            .Provider_txt.Text = Provider_cbo.Text.Trim
            .modele_txt.Text = Modele_cbo.Text.Trim
            .Url_txt.Text = AiUrl_txt.Tag.Trim
            .frm02 = Me
            .ShowDialog()
        End With
    End Sub
End Class