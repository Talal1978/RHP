Imports DevComponents.AdvTree

''' <summary>
''' Habilitations d'une page SP_ (conçue avec le Designer de pages portail) pour
''' le profil courant — ouvert depuis le menu contextuel des pages SP_ de
''' l'onglet Portail d'Admin_Profile (« Habilitations de la page... »).
''' Édite les actions de Controle_Designer_Droit AUTRES que Consulter (Créer,
''' Modifier, Supprimer, Valider, Imprimer, GED) — Consulter est géré par la
''' case Visible de la page dans l'arbre de l'onglet Portail (pour ces pages,
''' affichage au menu et accès ne font qu'un). « Va et vient » avec l'onglet
''' Habilitations de SP_Page_Designer, les deux écrans lisant et écrivant la
''' même table. Les valeurs validées (Save_pb) sont stockées dans le Tag du
''' nœud de l'arbre (Tag(2)) et persistées avec le profil (SavingPortailNodes).
''' Close_pb annule.
''' Thème visuel et layout : Zoom_Profile_Droits_SP.Designer.vb (thème de
''' référence des écrans exclusivement modaux — instruction permanente).
''' </summary>
Public Class Zoom_Profile_Droits_SP

    ''' <summary>Profil courant de l'écran des profils.</summary>
    Friend CodProfile As String = ""
    ''' <summary>Nœud de la page SP_ dans l'arbre portail (Name = Cod_Page ;
    ''' Tag(1) = Acces_Personnalise ; Tag(2) = habilitations éditées ici).</summary>
    Friend oNod As Node

    'Une ligne : les 7 habilitations de la page pour le profil (chaînes 'true'/'false',
    'convention de stockage de Controle_Designer_Droit).
    Dim oTable As DataTable

    Public Sub New()
        ' Cet appel est requis par le concepteur.
        InitializeComponent()
    End Sub

    Private Sub Zoom_Profile_Droits_SP_Load(sender As Object, e As EventArgs) Handles Me.Load
        Zoom_lbl.Text = "Habilitations de la page — " & FindLibelle("Nom_Page", "Cod_Page", oNod.Name, "Controle_Designer") &
                        "  (profil : " & FindLibelle("Lib_Profile", "Cod_Profile", CodProfile, "Controle_Profile") & ")"
        Lbl_Aide.Text = "La visibilité de la page (Consulter) se gère par la case Visible de l'onglet Portail." & vbCrLf &
                        "Les habilitations ci-dessus sont appliquées à l'enregistrement du profil (écran des profils)."
        If Not oNod.Tag(2) Is Nothing Then
            'Habilitations déjà éditées dans cette session (non encore enregistrées)
            oTable = oNod.Tag(2)
        Else
            oTable = DATA_READER_GRD("select isnull(Consulter,'false') as Consulter,isnull(Creer,'false') as Creer,isnull(Modifier,'false') as Modifier," &
                                     "isnull(Supprimer,'false') as Supprimer,isnull(Valider,'false') as Valider,isnull(Imprimer,'false') as Imprimer," &
                                     "isnull(GED,'false') as GED from Controle_Designer_Droit " &
                                     "where Cod_Page='" & oNod.Name & "' and Cod_Profile='" & CodProfile & "'")
            If oTable.Rows.Count = 0 Then
                oTable.Rows.Add("false", "false", "false", "false", "false", "false", "false")
            End If
        End If
        For Each col As DataColumn In oTable.Columns
            col.ReadOnly = False
        Next
        With oTable.Rows(0)
            Chk_Creer.Checked = (.Item("Creer").ToString() = "true")
            Chk_Modifier.Checked = (.Item("Modifier").ToString() = "true")
            Chk_Supprimer.Checked = (.Item("Supprimer").ToString() = "true")
            Chk_Valider.Checked = (.Item("Valider").ToString() = "true")
            Chk_Imprimer.Checked = (.Item("Imprimer").ToString() = "true")
            Chk_GED.Checked = (.Item("GED").ToString() = "true")
        End With
    End Sub

    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        With oTable.Rows(0)
            .Item("Creer") = If(Chk_Creer.Checked, "true", "false")
            .Item("Modifier") = If(Chk_Modifier.Checked, "true", "false")
            .Item("Supprimer") = If(Chk_Supprimer.Checked, "true", "false")
            .Item("Valider") = If(Chk_Valider.Checked, "true", "false")
            .Item("Imprimer") = If(Chk_Imprimer.Checked, "true", "false")
            .Item("GED") = If(Chk_GED.Checked, "true", "false")
        End With
        oNod.Tag(2) = oTable
        Me.Close()
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class
