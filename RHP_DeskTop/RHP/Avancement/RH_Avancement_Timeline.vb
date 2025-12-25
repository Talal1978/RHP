Imports ADODB

Public Class RH_Avancement_Timeline
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me)
    End Sub

    Private Sub LoadTimeline()
        flpTimeline.Controls.Clear()

        Dim sql As String = "SELECT " &
                            "GETDATE() as Dat_Effet, " &
                            "P.Lib_Poste AS Nouveau_Poste, " &
                            "G.Lib_Grade AS Nouveau_Grade, " &
                            "E.Lib_Entite AS Nouvelle_Entite, " &
                            "'' as Motif, '' as Mission," &
                            "'ACTUEL' as Type_Avancement, '' as Cod_Avancement " &
                            "FROM RH_Agent A " &
                            "LEFT JOIN Org_Poste P ON A.Cod_Poste = P.Cod_Poste AND A.id_Societe = P.id_Societe " &
                            "LEFT JOIN Org_Grade G ON A.Cod_Grade = G.Cod_Grade AND A.id_Societe = G.id_Societe " &
                            "LEFT JOIN Org_Entite E ON A.Cod_Entite = E.Cod_Entite AND A.id_Societe = E.id_Societe " &
                            "WHERE A.Matricule = '" & Matricule_txt.Text & "' " &
                            "AND A.id_Societe = " & Societe.id_Societe & " " &
                            "UNION ALL " &
                            "SELECT " &
                            "A.Dat_Effet, " &
                            "P.Lib_Poste AS Nouveau_Poste, " &
                            "G.Lib_Grade AS Nouveau_Grade, " &
                            "E.Lib_Entite AS Nouvelle_Entite, " &
                            "A.Motif, P.Mission," &
                            "A.Type_Avancement, A.Cod_Avancement " &
                            "FROM RH_Avancement A " &
                            "LEFT JOIN Org_Poste P ON A.Nouveau_Poste = P.Cod_Poste AND A.id_Societe = P.id_Societe " &
                            "LEFT JOIN Org_Grade G ON A.Nouveau_Grade = G.Cod_Grade AND A.id_Societe = G.id_Societe " &
                            "LEFT JOIN Org_Entite E ON A.Nouvelle_Entite = E.Cod_Entite AND A.id_Societe = E.id_Societe " &
                            "WHERE A.Matricule = '" & Matricule_txt.Text & "' " &
                            "AND A.id_Societe = " & Societe.id_Societe & " " &
                            "AND A.Statut IN ('VA', 'SG') " &
                            "ORDER BY Dat_Effet DESC"

        Dim rs As Recordset = CnExecuting(sql)

        If rs.EOF Then
            Dim lbl As New Label()
            lbl.Text = "Aucun historique trouvé."
            lbl.ForeColor = Color.White
            lbl.Font = New Font("Segoe UI", 12)
            lbl.AutoSize = True
            lbl.Margin = New Padding(50)
            flpTimeline.Controls.Add(lbl)
            Return
        End If

        Do While Not rs.EOF
            Dim item As New UC_Timeline_Item()
            Dim typeAvRaw As String = IsNull(rs("Type_Avancement").Value, "")

            Dim dt As Date = If(IsDBNull(rs("Dat_Effet").Value), Now, CDate(rs("Dat_Effet").Value))

            If typeAvRaw = "ACTUEL" Then
                item.DateText = "Aujourd'hui"
                item.Tags = "#Actuel"
            Else
                item.DateText = dt.ToString("dd MMM yyyy")
                ' Determine Tags based on Type_Avancement
                Dim typeAv As String = FindRubriques("Avancement", typeAvRaw)
                If typeAv = "" Then typeAv = "Avancement"
                item.Tags = "#" & typeAv
            End If

            item.JobTitle = IsNull(rs("Nouveau_Poste").Value, "Poste inconnu").ToUpper

            Dim grade As String = IsNull(rs("Nouveau_Grade").Value, "")
            Dim entite As String = IsNull(rs("Nouvelle_Entite").Value, "")
            item.Subtitle = grade & If(grade <> "" And entite <> "", " • ", "") & entite

            Dim mission = IsNull(rs("Mission").Value, "").ToUpper
            item.Mission = If(mission.Length > 180, Gauche(mission, 180) + "...", mission)
            item.Motif = IsNull(rs("Motif").Value, "")

            Dim codeAv As String = IsNull(rs("Cod_Avancement").Value, "")
            item.Code = codeAv

            ' Handle Click to open details
            If typeAvRaw <> "ACTUEL" Then
                AddHandler item.CodeClicked, Sub(s, args)
                                                 Dim f As New RH_Avancement
                                                 f.Cod_Avancement_txt.Text = codeAv
                                                 f.Request()
                                                 newShowEcran(f, True)
                                             End Sub
            End If

            item.Width = flpTimeline.Width - 30 ' Full width with some padding
            flpTimeline.Controls.Add(item)
            
            rs.MoveNext()
        Loop
        
        rs.Close()
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent+' ' + Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        LoadTimeline()
    End Sub
End Class
