''' <summary>
''' Écran modal de PRÉVISUALISATION d'un import JSON de page (SP_Page_Designer).
''' Présente le rapport d'analyse avant application : mode (création / mise à
''' jour), éléments détectés, diff ajoutés / modifiés / supprimés / inchangés
''' pour une mise à jour, avertissements de dépendances et rappel que les
''' habilitations ne sont pas concernées. Aucune écriture n'est déclenchée ici :
''' 'Valider' (DialogResult.OK) laisse l'appelant appliquer l'état au Designer,
''' qui reste seul responsable de la sauvegarde en base (bouton 'Enregistrer').
''' Interface : Zoom_SP_ImportApercu.Designer.vb (convention permanente : tout
''' le code de design est dans le .Designer.vb ; ce fichier ne contient que la
''' logique — événements et résultat).
''' </summary>
Public Class Zoom_SP_ImportApercu

    ''' <summary>Crée l'aperçu. titre : libellé du bandeau ; rapport : texte
    ''' multiligne de prévisualisation (construit par l'appelant).</summary>
    Public Sub New(titre As String, rapport As String)
        InitializeComponent()
        Zoom_lbl.Text = titre
        txtRapport.Text = rapport
    End Sub

    ''' <summary>Valider : l'import est appliqué aux contrôles et grilles du
    ''' Designer par l'appelant (aucune écriture en base à ce stade).</summary>
    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ''' <summary>Annuler : l'écran du Designer reste strictement inchangé.</summary>
    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>Échap = annuler, Entrée = valider.</summary>
    Private Sub Zoom_SP_ImportApercu_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.SuppressKeyPress = True
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter AndAlso Not (TypeOf Me.ActiveControl Is TextBox) Then
            e.SuppressKeyPress = True
            Save_pb_Click(Save_pb, EventArgs.Empty)
        End If
    End Sub

End Class
