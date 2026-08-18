Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

''' <summary>
''' Gestion des modèles LLM de l'assistant IA (table Ai_Agent) — écran séparé de
''' la base de connaissances (AI_KnowledgeBase, réservée à l'embedding).
''' MULTI-MODÈLES : plusieurs configurations (fournisseur/modèle/url/clé API/mémoire/
''' instruction) par portée (globale id_Societe=-1 ou propre à la société — case
''' 'Paramétrage global') ; la grille du haut les liste (la plus prioritaire en
''' tête : défaut de la société, puis défaut global, puis les autres) et la case
''' 'Modèle par défaut' désigne celui utilisé par l'assistant IA (portail, desktop,
''' scripts) — un seul défaut par portée (index UX_Ai_Agent_Par_Defaut).
''' INSTRUCTION (onglet 'Instruction') : commune à tous les modèles — répliquée sur
''' toutes les lignes Ai_Agent à l'enregistrement et reprise de la base en mode
''' 'Nouveau' (jamais vidée).
''' Boutons : Nouveau_pb (vider le formulaire pour ajouter un modèle),
''' SupprimerModele_pb (supprimer le modèle chargé — un autre modèle de la portée
''' est promu défaut si besoin), AddModele_pb (catalogue des modèles
''' Ai_LLM_Modeles), TesterConn_pb (tester la connexion du formulaire).
''' </summary>
Partial Public Class AI_Modeles
    Dim Save_D As ud_btn
#Region "Variables"

    ''' <summary>Id Ai_Agent du modèle affiché dans le formulaire (0 = nouveau, pas encore enregistré).</summary>
    Private _idModeleCharge As Integer = 0
    ''' <summary>Portée (id_Societe) du modèle affiché au chargement — permet de détecter
    ''' un changement de portée à l'enregistrement (0 = nouveau).</summary>
    Private _scopeModeleCharge As Integer = 0
    ''' <summary>True pendant l'alimentation/sélection de la grille des modèles
    ''' (empêche Grd_Modeles_SelectionChanged de recharger le formulaire).</summary>
    Private _chargementModeles As Boolean = False

#End Region

#Region "Chargement"

    Private Sub AI_Modeles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Request()
    End Sub

    Sub Chargement()
        If Provider_cbo.Items.Count = 0 Then
            Provider_cbo.FromSQL("SELECT distinct Modele, Provider from Ai_LLM_Modeles order by Provider")
        End If
        If Save_D Is Nothing Then
            Save_D = dictButtons("Save_D")
        End If
    End Sub

    Sub Request()
        Chargement()
        ChargerModeles()
    End Sub

    ''' <summary>Alimente la grille des modèles enregistrés (table Ai_Agent : portée
    ''' globale + société courante, triés par priorité — défaut société, défaut global,
    ''' puis les autres) et charge dans le formulaire le modèle demandé (provider/modèle/
    ''' portée) ou, à défaut, le premier — c.-à-d. le modèle PAR DÉFAUT. Sans aucun
    ''' modèle enregistré, le formulaire est vidé (mode 'Nouveau').</summary>
    Sub ChargerModeles(Optional selProvider As String = "", Optional selModele As String = "", Optional selScope As Integer = Integer.MinValue)
        _chargementModeles = True
        Try
            Dim Tbl As DataTable = DATA_READER_GRD($"SELECT Id, id_Societe, Provider, Modele, aiUrl, ApiKey, Instructions, nb_Msg_Memory, ISNULL(Par_Defaut,'false') AS Par_Defaut,
                                                   CASE WHEN id_Societe = -1 THEN N'Globale' ELSE N'Société' END AS Portee
                                                   FROM Ai_Agent
                                                   WHERE ISNULL(NULLIF(id_Societe, -1), {Societe.id_Societe}) = {Societe.id_Societe}
                                                   ORDER BY CASE WHEN ISNULL(Par_Defaut,'false')='true' THEN 0 ELSE 1 END,
                                                            CASE WHEN id_Societe = {Societe.id_Societe} THEN 0 ELSE 1 END,
                                                            Provider, Modele")
            Grd_Modeles.DataSource = Tbl
            Grd_Modeles.CurrentCell = Nothing
            ' Cible : la ligne demandée, sinon la première (= le modèle par défaut)
            Dim cible As DataGridViewRow = Nothing
            For Each r As DataGridViewRow In Grd_Modeles.Rows
                Dim drv = TryCast(r.DataBoundItem, DataRowView)
                If drv Is Nothing Then Continue For
                If selProvider = "" Then
                    cible = r
                    Exit For
                ElseIf IsNull(drv("Provider"), "").ToString() = selProvider AndAlso
                       IsNull(drv("Modele"), "").ToString() = selModele AndAlso
                       CInt(IsNull(drv("id_Societe"), -1)) = selScope Then
                    cible = r
                    Exit For
                End If
            Next
            If cible IsNot Nothing Then
                cible.Selected = True
                Grd_Modeles.CurrentCell = cible.Cells(1)
                ChargerModeleDansFormulaire(CType(cible.DataBoundItem, DataRowView))
            Else
                Nouveau()
            End If
        Finally
            _chargementModeles = False
        End Try
    End Sub

    ''' <summary>Charge un modèle enregistré dans le formulaire (mémorise son Id pour
    ''' que Saving fasse un UPDATE de cette ligne plutôt qu'un INSERT).</summary>
    Sub ChargerModeleDansFormulaire(drv As DataRowView)
        _idModeleCharge = CInt(IsNull(drv("Id"), 0))
        _scopeModeleCharge = CInt(IsNull(drv("id_Societe"), -1))
        Dim provider As String = IsNull(drv("Provider"), "").ToString().Trim()
        Provider_cbo.Text = provider
        ' Provider absent du catalogue (liste non alimentée par l'événement) : alimenter manuellement
        If Modele_cbo.Items.Count = 0 AndAlso provider <> "" Then
            For Each m As String In IsNull(FindLibelle("Modele", "Provider", provider, "Ai_LLM_Modeles"), "").ToString().Split("|"c)
                If m.Trim() <> "" Then Modele_cbo.Items.Add(m.Trim())
            Next
        End If
        AiUrl_txt.Tag = IsNull(FindLibelle("aiUrl", "Provider", provider, "Ai_LLM_Modeles"), "")
        Modele_cbo.Text = IsNull(drv("Modele"), "").ToString()
        AiUrl_txt.Text = IsNull(drv("aiUrl"), "").ToString()
        ApiKey_txt.Text = IsNull(drv("ApiKey"), "").ToString()
        Instructions_txt.Text = IsNull(drv("Instructions"), "").ToString()
        nb_Msg_Memory.Value = CInt(IsNull(drv("nb_Msg_Memory"), 5))
        Global_chk.Checked = (CInt(IsNull(drv("id_Societe"), -1)) = -1)
        Defaut_chk.Checked = (IsNull(drv("Par_Defaut"), "false").ToString() = "true")
    End Sub

    ''' <summary>Vide le formulaire pour saisir un NOUVEAU modèle (Id = 0 -> Saving fera un INSERT).</summary>
    Sub Nouveau()
        _idModeleCharge = 0
        _scopeModeleCharge = 0
        Provider_cbo.SelectedIndex = -1
        Modele_cbo.Items.Clear()
        Modele_cbo.SelectedIndex = -1
        AiUrl_txt.Text = ""
        AiUrl_txt.Tag = ""
        ApiKey_txt.Text = ""
        ' Instruction commune à tous les modèles : reprise de celle en base (jamais vidée)
        Dim rsInst As ADODB.Recordset = CnExecuting("SELECT TOP 1 Instructions FROM Ai_Agent WHERE NULLIF(Instructions, '') IS NOT NULL")
        Instructions_txt.Text = If(rsInst IsNot Nothing AndAlso Not rsInst.EOF, IsNull(rsInst.Fields(0).Value, "").ToString(), "")
        nb_Msg_Memory.Value = 5
        Defaut_chk.Checked = False
    End Sub

    Private Sub Grd_Modeles_SelectionChanged(sender As Object, e As EventArgs) Handles Grd_Modeles.SelectionChanged
        If _chargementModeles Then Return
        Dim r As DataGridViewRow = Grd_Modeles.CurrentRow
        If r Is Nothing Then Return
        Dim drv = TryCast(r.DataBoundItem, DataRowView)
        If drv Is Nothing Then Return
        ChargerModeleDansFormulaire(drv)
    End Sub

#End Region

#Region "Boutons"

    Private Sub Nouveau_pb_Click(sender As Object, e As EventArgs) Handles Nouveau_pb.Click
        _chargementModeles = True
        Try
            Grd_Modeles.ClearSelection()
            Grd_Modeles.CurrentCell = Nothing
            Nouveau()
        Finally
            _chargementModeles = False
        End Try
        Provider_cbo.Focus()
    End Sub

    ''' <summary>Supprime le modèle chargé dans le formulaire. Si c'était le modèle par
    ''' défaut de sa portée, le premier modèle restant de la portée est promu défaut.</summary>
    Private Sub SupprimerModele_pb_Click(sender As Object, e As EventArgs) Handles SupprimerModele_pb.Click
        If _idModeleCharge = 0 Then
            ShowMessageBox("Sélectionnez d'abord un modèle enregistré (grille du haut).", "Suppression", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        Dim scope As Integer = If(Global_chk.Checked, -1, Societe.id_Societe)
        Dim nom As String = Provider_cbo.Text.Trim() & " / " & Modele_cbo.Text.Trim()
        If ShowMessageBox($"Supprimer le modèle '{nom}' ?", "Confirmation", MessageBoxButtons.YesNo, msgIcon.Question) = DialogResult.No Then Return
        CnExecuting($"DELETE FROM Ai_Agent WHERE Id = {_idModeleCharge}
                      UPDATE Ai_Agent SET Par_Defaut = 'true'
                      WHERE Id = (SELECT MIN(Id) FROM Ai_Agent WHERE id_Societe = {scope})
                        AND NOT EXISTS (SELECT 1 FROM Ai_Agent d WHERE d.id_Societe = {scope} AND d.Par_Defaut = 'true')")
        _idModeleCharge = 0
        ChargerModeles()
        ShowMessageBox("Modèle supprimé.", "Succès", MessageBoxButtons.OK, msgIcon.Information)
    End Sub

    Sub Saving()
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
        If Instructions_txt.Text.Trim() = "" Then
            ShowMessageBox("Veuillez entrer l'instruction.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If

        Dim idSociete = If(Global_chk.Checked, -1, Societe.id_Societe)
        Dim providerSel = Provider_cbo.Text?.ToString().Trim()
        Dim modeleSel = Modele_cbo.Text?.ToString().Trim()
        Dim provider = If(providerSel, "").Replace("'", "''")
        Dim modele = If(modeleSel, "").Replace("'", "''")
        Dim aiUrl = AiUrl_txt.Text.Trim().Replace("'", "''")
        Dim apiKey = ApiKey_txt.Text.Trim().Replace("'", "''")
        Dim instructions = Instructions_txt.Text.Trim().Replace("'", "''")
        Dim memoire = CInt(IsNull(nb_Msg_Memory.Value, 5))
        Dim defaut As String = If(Defaut_chk.Checked, "true", "false")

        ' Unicité du couple Service/Modèle dans la portée (hors ligne en cours d'édition)
        Dim rs = CnExecuting($"SELECT COUNT(*) FROM Ai_Agent WHERE id_Societe = {idSociete} AND Provider = '{provider}' AND Modele = '{modele}' AND Id <> {_idModeleCharge}")
        If CInt(rs.Fields(0).Value) > 0 Then
            ShowMessageBox("Ce modèle est déjà enregistré pour cette portée.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Exit Sub
        End If

        Dim sql As String = ""
        If Defaut_chk.Checked Then
            ' Un seul modèle par défaut par portée (index UX_Ai_Agent_Par_Defaut)
            sql &= $"UPDATE Ai_Agent SET Par_Defaut = 'false' WHERE id_Societe = {idSociete};" & vbCrLf
        End If
        If _idModeleCharge = 0 Then
            sql &= $"INSERT INTO Ai_Agent (id_Societe, Provider, Modele, aiUrl, ApiKey, Instructions, nb_Msg_Memory, Par_Defaut)
                     VALUES ({idSociete}, '{provider}', '{modele}', '{aiUrl}', '{apiKey}', '{instructions}', {memoire}, '{defaut}');" & vbCrLf
        Else
            sql &= $"UPDATE Ai_Agent SET id_Societe = {idSociete}, Provider = '{provider}', Modele = '{modele}', aiUrl = '{aiUrl}',
                            ApiKey = '{apiKey}', Instructions = '{instructions}', nb_Msg_Memory = {memoire}, Par_Defaut = '{defaut}'
                     WHERE Id = {_idModeleCharge};" & vbCrLf
        End If
        ' Instruction commune à tous les modèles : répliquée sur toutes les lignes Ai_Agent
        sql &= $"UPDATE Ai_Agent SET Instructions = '{instructions}';" & vbCrLf
        ' Garantir un modèle par défaut dans la portée (première configuration ou défaut retiré)
        sql &= $"UPDATE Ai_Agent SET Par_Defaut = 'true'
                 WHERE id_Societe = {idSociete} AND Provider = '{provider}' AND Modele = '{modele}'
                   AND NOT EXISTS (SELECT 1 FROM Ai_Agent d WHERE d.id_Societe = {idSociete} AND d.Par_Defaut = 'true')"
        ' La ligne a changé de portée (global <-> société) : garantir un défaut dans l'ancienne portée
        If _idModeleCharge <> 0 AndAlso _scopeModeleCharge <> 0 AndAlso _scopeModeleCharge <> idSociete Then
            sql &= vbCrLf & $"UPDATE Ai_Agent SET Par_Defaut = 'true'
                 WHERE Id = (SELECT MIN(Id) FROM Ai_Agent WHERE id_Societe = {_scopeModeleCharge})
                   AND NOT EXISTS (SELECT 1 FROM Ai_Agent d WHERE d.id_Societe = {_scopeModeleCharge} AND d.Par_Defaut = 'true')"
        End If
        CnExecuting(sql)
        ShowMessageBox("Configuration enregistrée avec succès.", "Succès", MessageBoxButtons.OK, msgIcon.Information)
        ChargerModeles(providerSel, modeleSel, idSociete)
    End Sub

    Private Sub Cbo_Provider_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Provider_cbo.SelectedIndexChanged
        Chargement()
        Modele_cbo.Items.Clear()
        If Provider_cbo.SelectedIndex = -1 Then Exit Sub
        Dim strModeles As String = Provider_cbo.SelectedValue
        For Each modele As String In strModeles.Split("|"c)
            Modele_cbo.Items.Add(modele.Trim())
        Next
        AiUrl_txt.Tag = FindLibelle("aiUrl", "Provider", Provider_cbo.Text, "Ai_LLM_Modeles")
    End Sub

    Private Sub Modele_cbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Modele_cbo.SelectedIndexChanged
        AiUrl_txt.Text = IsNull(AiUrl_txt.Tag, "").Replace("{MODEL}", Modele_cbo.Text)
    End Sub

    Private Async Sub TesterConn_pb_Click(sender As Object, e As EventArgs) Handles TesterConn_pb.Click
        ' Validation
        If Provider_cbo.SelectedIndex = -1 Then
            ShowMessageBox("Selectionnez un Provider", "Validation", MessageBoxButtons.OK, msgIcon.Warning)
            Exit Sub
        End If
        If Modele_cbo.SelectedIndex = -1 Then
            ShowMessageBox("Selectionnez un Modele", "Validation", MessageBoxButtons.OK, msgIcon.Warning)
            Exit Sub
        End If
        If AiUrl_txt.Text = "" Then
            ShowMessageBox("Saisissez l'Url", "Validation", MessageBoxButtons.OK, msgIcon.Warning)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            Dim provider = Provider_cbo.Text.ToUpper()
            Dim modele = Modele_cbo.Text
            Dim url = AiUrl_txt.Text.Replace("{MODEL}", modele)
            Dim apiKey = ApiKey_txt.Text.Trim()

            ' Special URL handling
            If provider = "GEMINI" AndAlso Not url.Contains("key=") Then
                url &= $"?key={apiKey}"
            End If

            ' Create Request
            Dim request = WebRequest.Create(url)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.Timeout = 10000 ' 10s timeout

            ' Auth Headers
            If provider <> "GEMINI" AndAlso provider <> "OLLAMA" AndAlso apiKey <> "" Then
                request.Headers.Add("Authorization", "Bearer " & apiKey)
            ElseIf provider = "AZUREOPENAI" Then
                request.Headers.Add("api-key", apiKey)
            End If

            ' Build Payload
            Dim payload As Object
            If provider = "GEMINI" Then
                payload = New With {
                    .contents = New Object() {
                        New With {
                            .parts = New Object() {
                                New With {.text = "Hello"}
                            }
                        }
                    }
                }
            ElseIf provider = "OLLAMA" Then
                payload = New With {
                    .model = modele,
                    .prompt = "Hello",
                    .stream = False
                }
            Else
                ' OpenAI Standard (Mistral, Groq, etc)
                payload = New With {
                    .model = modele,
                    .messages = New Object() {
                        New With {
                            .role = "user",
                            .content = "Hello"
                        }
                    }
                }
            End If

            ' Send Request
            Dim data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload))
            request.ContentLength = data.Length
            Using stream = Await request.GetRequestStreamAsync()
                Await stream.WriteAsync(data, 0, data.Length)
            End Using

            ' Get Response
            Using response = Await request.GetResponseAsync()
                Using reader = New StreamReader(response.GetResponseStream())
                    Dim result = Await reader.ReadToEndAsync()
                    ShowMessageBox($"Connexion Réussie!{vbCrLf}Réponse reçue du serveur.", "Succès", MessageBoxButtons.OK, msgIcon.Information)
                End Using
            End Using

        Catch ex As Exception
            Dim msg = ex.Message
            If TypeOf ex Is WebException Then
                Dim wex = CType(ex, WebException)
                If wex.Response IsNot Nothing Then
                    Using reader = New StreamReader(wex.Response.GetResponseStream())
                        msg &= vbCrLf & "Details: " & reader.ReadToEnd()
                    End Using
                End If
            End If
            ShowMessageBox("Erreur de connexion:" & vbCrLf & msg, "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AddModele_pb_Click(sender As Object, e As EventArgs) Handles AddModele_pb.Click
        Dim f As New Zoom_AddModele
        With f
            .Typ_Modele_lbl.Text = "LLM"
            .Provider_txt.Text = Provider_cbo.Text.Trim
            .modele_txt.Text = Modele_cbo.Text.Trim
            .Url_txt.Text = AiUrl_txt.Tag.Trim
            .frm01 = Me
            .ShowDialog()
        End With
    End Sub

#End Region

End Class
