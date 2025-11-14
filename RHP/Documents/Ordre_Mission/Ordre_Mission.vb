Public Class Ordre_Mission
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Valide_D As ud_btn

    ' API key pour le calcul de distance (Google Maps API ou autre)
    Private Const API_KEY As String = "YOUR_API_KEY_HERE"

    Sub Chargement()
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Valide_D = dictButtons("Valide_D")
        End If
        ' Initialiser les types de déplacement
        If Typ_Deplacement_cbo.Items.Count = 0 Then
            Typ_Deplacement_cbo.fromRubrique("Typ_Deplacement")
        End If
        If Ville_Depart_txt.Text = "" And rd_nationale.Checked Then Ville_Depart_txt.Text = Societe.Ville
    End Sub

    Private Sub Ordre_Mission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()

        ' Initialiser les valeurs par défaut
        If Donneur_Ordre_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then
            Donneur_Ordre_txt.Text = theUser.Matricule
            requestDonneurOrdre()
        End If

        If Not EstDate(Dat_OM_txt.Text) Then
            Dat_OM_txt.Text = Now.ToShortDateString
        End If

        ' Vérifier si une préparation/clôture de paie est en cours
        If CnExecuting("Select count(*) from Controle_Access where Name_Ecran in ('RH_Preparation_Paie','RH_Cloture_Paie') and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            ShowMessageBox("Une préparation ou clôture de la paie est en cours. Réessayez plus tard.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If

        With Grd_Interesses
            .DefaultCellStyle.SelectionBackColor = colorBase04
        End With
    End Sub

    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        Dim canModify As Boolean = (Num_OM_txt.Text = "")

        Dim SqlStr As String = "SELECT * FROM RH_Ordre_Mission WHERE Num_OM='" & Num_OM_txt.Text & "' AND id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)

        With Tbl
            If .Rows.Count > 0 Then
                Donneur_Ordre_txt.Text = IsNull(.Rows(0)("Donneur_Ordre"), "")
                requestDonneurOrdre()
                Dat_OM_txt.Text = IsNull(.Rows(0)("Dat_OM"), "")
                Typ_Deplacement_cbo.SelectedValue = IsNull(.Rows(0)("Typ_Deplacement"), "")
                Objet_Mission_txt.Text = IsNull(.Rows(0)("Objet_Mission"), "")
                Ville_Depart_txt.Text = IsNull(.Rows(0)("Ville_Depart"), "")
                Ville_Destination_txt.Text = IsNull(.Rows(0)("Ville_Destination"), "")
                Pays_Destination_txt.Text = IsNull(.Rows(0)("Pays_Destination"), "")
                Dat_Du_txt.Text = IsNull(.Rows(0)("Dat_Du"), "")
                Dat_Au_txt.Text = IsNull(.Rows(0)("Dat_Au"), "")
                Distance_txt.Text = IsNull(.Rows(0)("Distance"), "0,00")
                AllerRetour_chk.Checked = IsNull(.Rows(0)("AllerRetour"), False)
                Commentaire_txt.Text = IsNull(.Rows(0)("Commentaire"), "")
                Dim TypMission = IsNull(.Rows(0)("Typ_Mission"), "1")
                rd_nationale.Checked = (TypMission = "1")
                rd_local.Checked = (TypMission = "0")
                rd_internationale.Checked = (TypMission = "2")
                With pb_Valide
                    .Tag = ""
                    Select Case IsNull(Tbl.Rows(0)("Statut"), "")
                        Case "VA"
                            .Image = My.Resources.valide01
                            .Tag = "VA"
                        Case "RJ"
                            .Image = My.Resources.refuse
                            .Tag = "RJ"
                    End Select
                    .Visible = ("VA;RJ".Split(";").Contains(IsNull(Tbl.Rows(0)("Statut"), "")))
                    canModify = (IsNull(Tbl.Rows(0)("Statut"), "") = "")

                    If IsNull(Tbl.Rows(0)("Statut"), "") <> "" Then
                        Save_D.Enabled = False
                        Del_D.Enabled = False
                        Valide_D.Enabled = False
                    End If
                End With
            Else
                ' Vider les champs si pas de données
                Donneur_Ordre_txt.Text = ""
                Nom_Donneur_txt.Text = ""
                Typ_Deplacement_cbo.SelectedIndex = -1
                Objet_Mission_txt.Text = ""
                Ville_Depart_txt.Text = ""
                Ville_Destination_txt.Text = ""
                Distance_txt.Text = "0"
                Dat_Du_txt.Text = ""
                Dat_Au_txt.Text = ""
                Commentaire_txt.Text = ""
                Pays_Destination_txt.ResetText()
                rd_nationale.Checked = True
                rd_local.Checked = False
                rd_internationale.Checked = False
                AllerRetour_chk.Checked = True
            End If

            ' Charger les intéressés
            Dim TblInteresses = DATA_READER_GRD($"select RowId,Matricule,Nom, Cod_Poste, Lib_Poste, Cod_Grade,Lib_Grade, Cod_Entite ,Lib_Entite
 from RH_Ordre_Mission_Detail d
outer apply (select Nom_Agent+' '+Prenom_Agent as Nom from RH_Agent p where p.id_Societe=d.id_Societe and Matricule=d.Matricule)a
outer apply (select Lib_Poste from Org_Poste p where p.id_Societe=d.id_Societe and Cod_Poste=d.Cod_Poste)o
outer apply (select Lib_Grade from Org_Grade where id_Societe=d.id_Societe and Cod_Grade=d.Cod_Grade)g
outer apply (select Lib_Entite from Org_Entite where  id_Societe=d.id_Societe and Cod_Entite=d.Cod_Entite)e
 where Num_OM='{Num_OM_txt.Text }' and id_Societe=" & Societe.id_Societe)

            With TblInteresses
                Grd_Interesses.Rows.Clear()
                If Grd_Interesses.Columns.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        Grd_Interesses.Rows.Add(.Rows(i)("Matricule"), .Rows(i)("Nom"), .Rows(i)("Cod_Poste"),
                                               .Rows(i)("Lib_Poste"), .Rows(i)("Cod_Grade"), .Rows(i)("Lib_Grade"), .Rows(i)("Cod_Entite"), .Rows(i)("Lib_Entite"))
                        Grd_Interesses.Rows(i).Tag = .Rows(i)("RowId")
                    Next
                End If
            End With

            ' Gérer les droits d'accès
            If canModify Then
                canModify = ((Donneur_Ordre_txt.Text = theUser.Matricule And theUser.Typ_Role = "Agent") Or theUser.Typ_Role <> "Agent")
            End If

            Save_D.Enabled = canModify
            Del_D.Enabled = canModify
            Valide_D.Enabled = canModify
        End With
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If Num_OM_txt.Text <> "" Then
            If Not ShowMessageBox("Vous ne pouvez pas modifier le donneur d'ordre d'un ordre créé." & vbCrLf & "Voulez-vous créer un nouvel ordre?", "Ordre de Mission", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Return
            Else
                Nouveau()
                Return
            End If
        End If

        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Donneur_Ordre_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Donneur_Ordre_txt, Me)
        End If
    End Sub

    Sub requestDonneurOrdre()
        Dim SqlStr As String = "SELECT * FROM RH_Agent WHERE Matricule='" & Donneur_Ordre_txt.Text & "' AND id_Societe=" & Societe.id_Societe
        Dim CltTbl As DataTable = DATA_READER_GRD(SqlStr)

        If CltTbl.Rows.Count > 0 Then
            Nom_Donneur_txt.Text = IsNull(CltTbl.Rows(0)("Nom_Agent"), "") & " " & IsNull(CltTbl.Rows(0)("Prenom_Agent"), "")
        ElseIf Donneur_Ordre_txt.Text.Trim = "" Then
            Nom_Donneur_txt.Text = ""
        End If
    End Sub

    Private Sub Donneur_Ordre_txt_TextChanged(sender As Object, e As EventArgs) Handles Donneur_Ordre_txt.TextChanged
        If Num_OM_txt.Text <> "" Then Return
        requestDonneurOrdre()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS095", Num_OM_txt, Me, " Donneur_Ordre = '" & Donneur_Ordre_txt.Text & "'")
            End If
        Else
            Appel_Zoom1("MS095", Num_OM_txt, Me)
        End If
    End Sub

    Private Sub Num_OM_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_OM_txt.TextChanged
        CnExecuting("DELETE FROM Controle_Access WHERE Name_Ecran='" & Me.Name & "' AND value='" & Code & "' AND Process_Id=" & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_OM_txt.Text, Me))
        Request()

        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_OM_txt.Text)
            Code = Num_OM_txt.Text
        End If
    End Sub

    Function Valider() As Boolean
        If ShowMessageBox("Êtes-vous sûr de vouloir valider cet ordre de mission?", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then
            Return False
        End If

        Dim rs = Saving("VA")
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function

    Sub Saving()
        Dim rsl As savingResult = Saving("")
        If IsNull(rsl.message, "") <> "" Then
            ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
        End If
    End Sub

    Function Saving(statut As String) As savingResult
        If CnExecuting("SELECT count(*) FROM Controle_Access WHERE Name_Ecran='RH_Preparation_Paie' AND id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
            Return New savingResult With {.result = False, .message = "Une préparation de la paie est en cours. Réessayez plus tard."}
        End If

        ' Validations
        If Donneur_Ordre_txt.Text = "" Then
            Return New savingResult With {.result = False, .message = "Donneur d'ordre non renseigné"}
        End If

        If Typ_Deplacement_cbo.Text = "" Then
            Return New savingResult With {.result = False, .message = "Type de déplacement non renseigné"}
        End If

        If Objet_Mission_txt.Text.Trim = "" Then
            Return New savingResult With {.result = False, .message = "Objet de la mission non renseigné"}
        End If
        If rd_nationale.Checked Then
            If Ville_Depart_txt.Text.Trim = "" Then
                Return New savingResult With {.result = False, .message = "Ville de départ non renseignée"}
            End If

            If Ville_Destination_txt.Text.Trim = "" Then
                Return New savingResult With {.result = False, .message = "Ville de destination non renseignée"}
            End If
            If Ville_Destination_txt.Text.Trim = Ville_Depart_txt.Text.Trim Then
                Return New savingResult With {.result = False, .message = "Ville de destination et de départ identiques."}
            End If
            Distance_txt.Text = GetDistanceFromAPI(Ville_Depart_txt.Text, Ville_Destination_txt.Text)
        Else
            Ville_Destination_txt.Text = ""
            Ville_Depart_txt.Text = ""
            Distance_txt.Text = 0
        End If
        If rd_internationale.Checked Then
            If Pays_Destination_txt.Text.Trim = "" Then
                Return New savingResult With {.result = False, .message = "Ville de départ non renseignée"}
            End If
        Else
            Pays_Destination_txt.Text = ""
        End If

        If Not EstDate(Dat_Du_txt.Text) Then
            Return New savingResult With {.result = False, .message = "Date de début invalide"}
        End If

        If Not EstDate(Dat_Au_txt.Text) Then
            Return New savingResult With {.result = False, .message = "Date de fin invalide"}
        End If

        If CDate(Dat_Au_txt.Text) < CDate(Dat_Du_txt.Text) Then
            Return New savingResult With {.result = False, .message = "La date de fin ne peut pas être antérieure à la date de début"}
        End If

        ' Vérifier qu'il y a au moins un intéressé
        If Grd_Interesses.RowCount <= 1 Then
            Return New savingResult With {.result = False, .message = "Aucun intéressé défini pour cette mission"}
        End If

        Dim numOM As String = Num_OM_txt.Text
        If numOM = "" Then
            ' Générer un nouveau numéro d'ordre de mission
            Dim Cp As New ADODB.Recordset
            Dim SqlStr As String = "SELECT ISNULL(MAX(racine),0) AS racine FROM (
                                   SELECT CONVERT(INT, CASE WHEN ISNUMERIC(ISNULL(racine,''))!=1 THEN 0 ELSE racine END) AS Racine 
                                   FROM RH_Ordre_Mission 
                                   OUTER APPLY(SELECT CHARINDEX('_',Num_OM,1)-1 aa)a
                                   OUTER APPLY(SELECT CASE WHEN aa<0 THEN RIGHT(Num_OM,6) ELSE RIGHT(LEFT(Num_OM,aa),6) END AS racine)n
                                   WHERE id_Societe=" & Societe.id_Societe & " AND YEAR(Dat_OM)=" & CDate(Dat_OM_txt.Text).Year & ")f"
            Cp = CnExecuting(SqlStr)
            numOM = "OM" & Societe.id_Societe & "-" & CDate(Dat_OM_txt.Text).Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
        End If

        Dim oDat As Date = Now
        If Not EstDate(Dat_OM_txt.Text) Then Dat_OM_txt.Text = oDat.ToShortDateString

        ' Sauvegarder l'ordre de mission principal
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM RH_Ordre_Mission WHERE Num_OM='" & numOM & "' AND id_Societe=" & Societe.id_Societe, cn, 2, 2)

        If rs.EOF Then
            rs.AddNew()
            rs("Num_OM").Value = numOM
            rs("id_Societe").Value = Societe.id_Societe
            rs("Donneur_Ordre").Value = Donneur_Ordre_txt.Text
            rs("Dat_Crea").Value = oDat
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()
        End If

        rs("Dat_OM").Value = Dat_OM_txt.Text
        rs("Typ_Deplacement").Value = If(Typ_Deplacement_cbo.SelectedIndex > 0, Typ_Deplacement_cbo.SelectedValue, "")
        rs("Objet_Mission").Value = Objet_Mission_txt.Text
        rs("Ville_Depart").Value = Ville_Depart_txt.Text
        rs("Ville_Destination").Value = Ville_Destination_txt.Text
        rs("Pays_Destination").Value = Pays_Destination_txt.Text
        rs("Distance").Value = If(IsNumeric(Distance_txt.Text), CDbl(Distance_txt.Text), 0)
        rs("Typ_Mission").Value = If(rd_internationale.Checked, 2, If(rd_local.Checked, 0, 1))
        rs("Dat_Du").Value = Dat_Du_txt.Text
        rs("Dat_Au").Value = Dat_Au_txt.Text
        rs("AllerRetour").Value = AllerRetour_chk.Checked
        rs("Commentaire").Value = Commentaire_txt.Text
        rs("Statut").Value = statut
        rs("Dat_Modif").Value = oDat
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()

        ' Sauvegarder les intéressés
        With Grd_Interesses
            Dim swhere = ""
            For i = 0 To .RowCount - 2
                If Not IsNull(.Rows(i).Tag, "") = "" Then
                    swhere &= IIf(swhere = "", "", ",") & .Rows(i).Tag
                End If
            Next

            If Not swhere.Trim = "" Then
                CnExecuting("DELETE FROM RH_Ordre_Mission_Detail WHERE Num_OM='" & numOM & "' AND id_Societe='" & Societe.id_Societe & "' AND RowId NOT IN (" & swhere & ")")
            End If
            For i = 0 To .RowCount - 2
                If Not IsNull(.Item(Matricule.Index, i).Value, "") = "" Then
                    rs.Open("SELECT * FROM RH_Ordre_Mission_Detail WHERE Num_OM='" & numOM & "' AND id_Societe='" & Societe.id_Societe & "' AND RowId ='" & IsNull(.Rows(i).Tag, "") & "'", cn, 2, 2)
                    If rs.EOF Then
                        rs.AddNew()
                        rs("Num_OM").Value = numOM
                        rs("id_Societe").Value = Societe.id_Societe
                    Else
                        rs.Update()
                    End If

                    rs("Matricule").Value = IsNull(.Item(Matricule.Index, i).Value, "")
                    rs("Cod_Poste").Value = IsNull(.Item(Cod_Poste.Index, i).Value, "")
                    rs("Cod_Grade").Value = IsNull(.Item(Cod_Grade.Index, i).Value, "")
                    rs("Cod_Entite").Value = IsNull(.Item(Cod_Entite.Index, i).Value, "")
                    rs.Update()
                    rs.Close()
                End If
            Next
        End With

        If Num_OM_txt.Text <> "" Then
            Request()
        Else
            Num_OM_txt.Text = numOM
        End If

        Return New savingResult With {.result = True, .message = "Enregistré avec succès"}
    End Function

    Sub Deleting()
        If ShowMessageBox("Êtes-vous sûr de vouloir supprimer cet ordre de mission?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return

        CnExecuting("DELETE FROM RH_Ordre_Mission WHERE Num_OM='" & Num_OM_txt.Text & "' AND id_Societe=" & Societe.id_Societe &
                   " INSERT INTO Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) " &
                   "VALUES ('RH_Ordre_Mission','Num_OM','" & Num_OM_txt.Text & "','" & theUser.id_User & "', GETDATE())")

        Reset_Form(Me)
        If Donneur_Ordre_txt.Text = "" Then
            Donneur_Ordre_txt.Text = theUser.Matricule
            requestDonneurOrdre()
        End If
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        Request()
        If Donneur_Ordre_txt.Text = "" Then
            Donneur_Ordre_txt.Text = theUser.Matricule
            requestDonneurOrdre()
        End If
        Dat_OM_txt.Text = Now.ToShortDateString
        rd_nationale.Checked = True
        Ville_Depart_txt.Text = Societe.Ville
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Calender(Dat_OM_txt, Me)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Appel_Calender(Dat_Du_txt, Me)
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Appel_Calender(Dat_Au_txt, Me)
    End Sub

    Private Function GetDistanceFromAPI(origin As String, destination As String) As Double
        If origin = "" Or destination = "" Then Return 0
        Dim distance As Double = 0
        distance = CnExecuting($"declare @v1 nvarchar(50)='{origin}', @v2 nvarchar(50)='{destination}'
select isnull((select Distance_Km from Param_Ville_Distances where (Cod_Ville_Depart=@v1 and Cod_Ville_Destination=@v2) or (Cod_Ville_Depart=@v2 and Cod_Ville_Destination=@v1)),0)").Fields(0).Value

        Return distance
    End Function

    Private Sub Grd_Interesses_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Interesses.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Matricule.Index Then
            ' Appeler le zoom pour sélectionner un agent
            Dim currentMatricule As String = If(Grd_Interesses.Item(Matricule.Index, e.RowIndex).Value, "").ToString()
            Dim isLastRow As Boolean = (e.RowIndex = Grd_Interesses.RowCount - 1)
            If isLastRow Then
                Grd_Interesses.Rows.Add("")
                Grd_Interesses.Invalidate(True)
            End If
            Dim r As Integer = e.RowIndex
            If theUser.Typ_Role = "Agent" Then
                If theUser.TeamLeader Then
                    Appel_Zoom1("MS018", Grd_Interesses.Item(Matricule.Index, r), Me, String.Format(filtreUser, {"RH_Agent"}))
                End If
            Else
                Appel_Zoom1("MS018", Grd_Interesses.Item(Matricule.Index, r), Me)
            End If
            Dim newMatricule As String = IsNull(Grd_Interesses.Item(Matricule.Index, r).Value, "").Trim
            ' Récupérer les informations de l'agent sélectionné
            If newMatricule <> currentMatricule AndAlso newMatricule <> "" Then
                Dim AgentTbl As DataTable = DATA_READER_GRD($" select Matricule,Nom_Agent+' '+Prenom_Agent as Nom, Cod_Poste, Lib_Poste, Cod_Grade,Lib_Grade, Cod_Entite ,Lib_Entite
 from RH_Agent d
outer apply (select Lib_Poste from Org_Poste p where p.id_Societe=d.id_Societe and Cod_Poste=d.Cod_Poste)o
outer apply (select Lib_Grade from Org_Grade where id_Societe=d.id_Societe and Cod_Grade=d.Cod_Grade)g
outer apply (select Lib_Entite from Org_Entite where  id_Societe=d.id_Societe and Cod_Entite=d.Cod_Entite)e
 where Matricule='{newMatricule}' and id_Societe=" & Societe.id_Societe)
                If AgentTbl.Rows.Count > 0 Then
                    With AgentTbl.Rows(0)
                        Grd_Interesses.Item(Matricule.Index, r).Value = IsNull(.Item("Matricule"), "")
                        Grd_Interesses.Item(Nom.Index, r).Value = IsNull(.Item("Nom"), "")
                        Grd_Interesses.Item(Cod_Poste.Index, r).Value = IsNull(.Item("Cod_Poste"), "")
                        Grd_Interesses.Item(Lib_Poste.Index, r).Value = IsNull(.Item("Lib_Poste"), "")
                        Grd_Interesses.Item(Cod_Grade.Index, r).Value = IsNull(.Item("Cod_Grade"), "")
                        Grd_Interesses.Item(Lib_Grade.Index, r).Value = IsNull(.Item("Lib_Grade"), "")
                        Grd_Interesses.Item(Cod_Entite.Index, r).Value = IsNull(.Item("Cod_Entite"), "")
                        Grd_Interesses.Item(Lib_Entite.Index, r).Value = IsNull(.Item("Lib_Entite"), "")
                    End With

                Else
                    ' Effacer les valeurs si l'agent n'est pas trouvé
                    Grd_Interesses.Item(Matricule.Index, r).Value = ""
                    Grd_Interesses.Item(Nom.Index, r).Value = ""
                    Grd_Interesses.Item(Cod_Poste.Index, r).Value = ""
                    Grd_Interesses.Item(Lib_Poste.Index, r).Value = ""
                    Grd_Interesses.Item(Cod_Grade.Index, r).Value = ""
                    Grd_Interesses.Item(Lib_Grade.Index, r).Value = ""
                    Grd_Interesses.Item(Cod_Entite.Index, r).Value = ""
                    Grd_Interesses.Item(Lib_Entite.Index, r).Value = ""
                End If
            End If
        End If
    End Sub

    Private Sub Grd_Interesses_KeyDown(sender As Object, e As KeyEventArgs) Handles Grd_Interesses.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Grd_Interesses.CurrentRow IsNot Nothing AndAlso Grd_Interesses.CurrentRow.Index < Grd_Interesses.RowCount - 1 Then
                If ShowMessageBox("Voulez-vous supprimer cet intéressé?", "Suppression", MessageBoxButtons.YesNo, msgIcon.Question) = DialogResult.Yes Then
                    Grd_Interesses.Rows.RemoveAt(Grd_Interesses.CurrentRow.Index)
                End If
            End If
        End If
    End Sub
    Private Sub modifyDistance_btn_Click(sender As Object, e As EventArgs) Handles modifyDistance_btn.Click
        Dim f As New Param_Ville
        With f
            .Cod_Pay_Text.Text = Societe.Cod_Pays
            .Cod_Ville_Text.Text = Ville_Depart_txt.Text
            newShowEcran(f, True)
        End With
        Distance_txt.Text = GetDistanceFromAPI(Ville_Depart_txt.Text, Ville_Destination_txt.Text)
    End Sub
    Private Sub Ordre_Mission_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("DELETE FROM Controle_Access WHERE Name_Ecran='" & Me.Name & "' AND value='" & Code & "' AND Process_Id=" & ProcessId)
    End Sub
    Private Sub rd_internationale_CheckedChanged(sender As Object, e As EventArgs) Handles rd_internationale.CheckedChanged, rd_local.CheckedChanged, rd_nationale.CheckedChanged
        If sender IsNot rd_nationale Then
            Ville_Depart_txt.Text = ""
            Ville_Destination_txt.Text = ""
            Distance_txt.Text = 0
        Else
            If Ville_Depart_txt.Text = "" Then Ville_Depart_txt.Text = Societe.Ville
        End If
        If sender IsNot rd_internationale Then
            Pays_Destination_txt.ResetText()
        ElseIf Pays_Destination_txt.Text = "" Then
            Pays_Destination_txt.Text = Societe.Cod_Pays
        End If
        pnl_nationale.Visible = rd_nationale.Checked
        pnl_internationale.Visible = rd_internationale.Checked
    End Sub
    Private Sub Ville_Depart_txt_TextChanged(sender As Object, e As EventArgs) Handles Ville_Depart_txt.TextChanged
        Lib_Ville_Depart_txt.Text = FindLibelle("Ville", "Cod_Ville", Ville_Depart_txt.Text & "' and Cod_Pays='" & Societe.Cod_Pays, "Param_Ville")
    End Sub
    Private Sub Ville_Destination_txt_TextChanged(sender As Object, e As EventArgs) Handles Ville_Destination_txt.TextChanged
        Lib_Ville_Destination_txt.Text = FindLibelle("Ville", "Cod_Ville", Ville_Destination_txt.Text & "' and Cod_Pays='" & Societe.Cod_Pays, "Param_Ville")
    End Sub
    Private Sub Pays_Destination_txt_TextChanged(sender As Object, e As EventArgs) Handles Pays_Destination_txt.TextChanged
        Lib_Pays_Destination_txt.Text = FindRubriques("Cod_Pays_Combo", Pays_Destination_txt.Text)
    End Sub
    Private Sub Grd_Interesses_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Interesses.CellMouseMove
        If e.ColumnIndex = Matricule.Index Then
            Grd_Interesses.Cursor = Cursors.Hand
        Else
            Grd_Interesses.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Zoom1("MS145", Ville_Depart_txt, Me, $"Cod_Pays='{Societe.Cod_Pays}'  and Cod_Ville!='{Ville_Destination_txt}'")
        Distance_txt.Text = GetDistanceFromAPI(Ville_Depart_txt.Text, Ville_Destination_txt.Text)
    End Sub
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Appel_Zoom1("MS145", Ville_Destination_txt, Me, $"Cod_Pays='{Societe.Cod_Pays}' and Cod_Ville!='{Ville_Depart_txt}'")
        Distance_txt.Text = GetDistanceFromAPI(Ville_Depart_txt.Text, Ville_Destination_txt.Text)
    End Sub
    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Appel_Rubrique("Cod_Pays_Combo", Ville_Destination_txt, Me)
    End Sub
#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        Return Saving("SS")
    End Function

    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function
#End Region
End Class